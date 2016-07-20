using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core //1:1
{
    using __Hidden_ImmutableMetaModelGenerator_1261512665;
    namespace __Hidden_ImmutableMetaModelGenerator_1261512665
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

    public class ImmutableMetaModelGenerator //2:1
    {
        private IEnumerable<ModelObject> Instances; //2:1

        public ImmutableMetaModelGenerator() //2:1
        {
        }

        public ImmutableMetaModelGenerator(IEnumerable<ModelObject> instances) : this() //2:1
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
            __out.Append("using MetaDslx.Core;"); //12:1
            __out.AppendLine(false); //12:21
            __out.Append("using System.Diagnostics;"); //13:1
            __out.AppendLine(false); //13:26
            __out.AppendLine(true); //14:1
            var __loop1_results = 
                (from __loop1_var1 in __Enumerate((Instances).GetEnumerator()) //15:8
                from mm in __Enumerate((__loop1_var1).GetEnumerator()).OfType<MetaModel>() //15:19
                select new { __loop1_var1 = __loop1_var1, mm = mm}
                ).ToList(); //15:3
            int __loop1_iteration = 0;
            foreach (var __tmp1 in __loop1_results)
            {
                ++__loop1_iteration;
                var __loop1_var1 = __tmp1.__loop1_var1;
                var mm = __tmp1.mm;
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(GenerateMetamodel(mm));
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_first = true;
                    bool __tmp3_last = __tmp3Reader.EndOfStream;
                    while(__tmp3_first || !__tmp3_last)
                    {
                        __tmp3_first = false;
                        string __tmp3Line = __tmp3Reader.ReadLine();
                        __tmp3_last = __tmp3Reader.EndOfStream;
                        if (__tmp3Line != null) __out.Append(__tmp3Line);
                        if (!__tmp3_last) __out.AppendLine(true);
                        __out.AppendLine(false); //16:24
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateMetamodel(MetaModel model) //20:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "namespace "; //21:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.Namespace.CSharpName(ClassKind.Immutable));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(__tmp3_first || !__tmp3_last)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    if (!__tmp3_last) __out.AppendLine(true);
                    __out.AppendLine(false); //21:60
                }
            }
            __out.Append("{"); //22:1
            __out.AppendLine(false); //22:2
            string __tmp4Prefix = "    "; //23:1
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(GenerateMetaModelDescriptor(model));
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_first = true;
                bool __tmp5_last = __tmp5Reader.EndOfStream;
                while(__tmp5_first || !__tmp5_last)
                {
                    __tmp5_first = false;
                    string __tmp5Line = __tmp5Reader.ReadLine();
                    __tmp5_last = __tmp5Reader.EndOfStream;
                    __out.Append(__tmp4Prefix);
                    if (__tmp5Line != null) __out.Append(__tmp5Line);
                    if (!__tmp5_last) __out.AppendLine(true);
                    __out.AppendLine(false); //23:41
                }
            }
            var __loop2_results = 
                (from __loop2_var1 in __Enumerate((model).GetEnumerator()) //24:8
                from Namespace in __Enumerate((__loop2_var1.Namespace).GetEnumerator()) //24:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //24:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //24:40
                select new { __loop2_var1 = __loop2_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //24:3
            int __loop2_iteration = 0;
            foreach (var __tmp6 in __loop2_results)
            {
                ++__loop2_iteration;
                var __loop2_var1 = __tmp6.__loop2_var1;
                var Namespace = __tmp6.Namespace;
                var Declarations = __tmp6.Declarations;
                var enm = __tmp6.enm;
                string __tmp7Prefix = "    "; //25:1
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(GenerateEnum(enm));
                using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                {
                    bool __tmp8_first = true;
                    bool __tmp8_last = __tmp8Reader.EndOfStream;
                    while(__tmp8_first || !__tmp8_last)
                    {
                        __tmp8_first = false;
                        string __tmp8Line = __tmp8Reader.ReadLine();
                        __tmp8_last = __tmp8Reader.EndOfStream;
                        __out.Append(__tmp7Prefix);
                        if (__tmp8Line != null) __out.Append(__tmp8Line);
                        if (!__tmp8_last) __out.AppendLine(true);
                        __out.AppendLine(false); //25:24
                    }
                }
            }
            var __loop3_results = 
                (from __loop3_var1 in __Enumerate((model).GetEnumerator()) //27:8
                from Namespace in __Enumerate((__loop3_var1.Namespace).GetEnumerator()) //27:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //27:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //27:40
                select new { __loop3_var1 = __loop3_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //27:3
            int __loop3_iteration = 0;
            foreach (var __tmp9 in __loop3_results)
            {
                ++__loop3_iteration;
                var __loop3_var1 = __tmp9.__loop3_var1;
                var Namespace = __tmp9.Namespace;
                var Declarations = __tmp9.Declarations;
                var cls = __tmp9.cls;
                string __tmp10Prefix = "    "; //28:1
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(GenerateImmutableInterface(cls));
                using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                {
                    bool __tmp11_first = true;
                    bool __tmp11_last = __tmp11Reader.EndOfStream;
                    while(__tmp11_first || !__tmp11_last)
                    {
                        __tmp11_first = false;
                        string __tmp11Line = __tmp11Reader.ReadLine();
                        __tmp11_last = __tmp11Reader.EndOfStream;
                        __out.Append(__tmp10Prefix);
                        if (__tmp11Line != null) __out.Append(__tmp11Line);
                        if (!__tmp11_last) __out.AppendLine(true);
                        __out.AppendLine(false); //28:38
                    }
                }
            }
            var __loop4_results = 
                (from __loop4_var1 in __Enumerate((model).GetEnumerator()) //30:8
                from Namespace in __Enumerate((__loop4_var1.Namespace).GetEnumerator()) //30:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //30:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //30:40
                select new { __loop4_var1 = __loop4_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //30:3
            int __loop4_iteration = 0;
            foreach (var __tmp12 in __loop4_results)
            {
                ++__loop4_iteration;
                var __loop4_var1 = __tmp12.__loop4_var1;
                var Namespace = __tmp12.Namespace;
                var Declarations = __tmp12.Declarations;
                var cls = __tmp12.cls;
                string __tmp13Prefix = "    "; //31:1
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(GenerateBuilderInterface(cls));
                using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
                {
                    bool __tmp14_first = true;
                    bool __tmp14_last = __tmp14Reader.EndOfStream;
                    while(__tmp14_first || !__tmp14_last)
                    {
                        __tmp14_first = false;
                        string __tmp14Line = __tmp14Reader.ReadLine();
                        __tmp14_last = __tmp14Reader.EndOfStream;
                        __out.Append(__tmp13Prefix);
                        if (__tmp14Line != null) __out.Append(__tmp14Line);
                        if (!__tmp14_last) __out.AppendLine(true);
                        __out.AppendLine(false); //31:36
                    }
                }
            }
            var __loop5_results = 
                (from __loop5_var1 in __Enumerate((model).GetEnumerator()) //33:8
                from Namespace in __Enumerate((__loop5_var1.Namespace).GetEnumerator()) //33:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //33:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //33:40
                select new { __loop5_var1 = __loop5_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //33:3
            int __loop5_iteration = 0;
            foreach (var __tmp15 in __loop5_results)
            {
                ++__loop5_iteration;
                var __loop5_var1 = __tmp15.__loop5_var1;
                var Namespace = __tmp15.Namespace;
                var Declarations = __tmp15.Declarations;
                var cls = __tmp15.cls;
                string __tmp16Prefix = "    "; //34:1
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(GenerateImmutableInterfaceImpl(model, cls));
                using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
                {
                    bool __tmp17_first = true;
                    bool __tmp17_last = __tmp17Reader.EndOfStream;
                    while(__tmp17_first || !__tmp17_last)
                    {
                        __tmp17_first = false;
                        string __tmp17Line = __tmp17Reader.ReadLine();
                        __tmp17_last = __tmp17Reader.EndOfStream;
                        __out.Append(__tmp16Prefix);
                        if (__tmp17Line != null) __out.Append(__tmp17Line);
                        if (!__tmp17_last) __out.AppendLine(true);
                        __out.AppendLine(false); //34:49
                    }
                }
            }
            var __loop6_results = 
                (from __loop6_var1 in __Enumerate((model).GetEnumerator()) //36:8
                from Namespace in __Enumerate((__loop6_var1.Namespace).GetEnumerator()) //36:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //36:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //36:40
                select new { __loop6_var1 = __loop6_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //36:3
            int __loop6_iteration = 0;
            foreach (var __tmp18 in __loop6_results)
            {
                ++__loop6_iteration;
                var __loop6_var1 = __tmp18.__loop6_var1;
                var Namespace = __tmp18.Namespace;
                var Declarations = __tmp18.Declarations;
                var cls = __tmp18.cls;
                string __tmp19Prefix = "    "; //37:1
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(GenerateBuilderInterfaceImpl(model, cls));
                using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
                {
                    bool __tmp20_first = true;
                    bool __tmp20_last = __tmp20Reader.EndOfStream;
                    while(__tmp20_first || !__tmp20_last)
                    {
                        __tmp20_first = false;
                        string __tmp20Line = __tmp20Reader.ReadLine();
                        __tmp20_last = __tmp20Reader.EndOfStream;
                        __out.Append(__tmp19Prefix);
                        if (__tmp20Line != null) __out.Append(__tmp20Line);
                        if (!__tmp20_last) __out.AppendLine(true);
                        __out.AppendLine(false); //37:47
                    }
                }
            }
            string __tmp21Prefix = "	"; //39:1
            StringBuilder __tmp22 = new StringBuilder();
            __tmp22.Append(GenerateMetaModelInstance(model));
            using(StreamReader __tmp22Reader = new StreamReader(this.__ToStream(__tmp22.ToString())))
            {
                bool __tmp22_first = true;
                bool __tmp22_last = __tmp22Reader.EndOfStream;
                while(__tmp22_first || !__tmp22_last)
                {
                    __tmp22_first = false;
                    string __tmp22Line = __tmp22Reader.ReadLine();
                    __tmp22_last = __tmp22Reader.EndOfStream;
                    __out.Append(__tmp21Prefix);
                    if (__tmp22Line != null) __out.Append(__tmp22Line);
                    if (!__tmp22_last) __out.AppendLine(true);
                    __out.AppendLine(false); //39:36
                }
            }
            string __tmp23Prefix = "    "; //40:1
            StringBuilder __tmp24 = new StringBuilder();
            __tmp24.Append(GenerateFactory(model));
            using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
            {
                bool __tmp24_first = true;
                bool __tmp24_last = __tmp24Reader.EndOfStream;
                while(__tmp24_first || !__tmp24_last)
                {
                    __tmp24_first = false;
                    string __tmp24Line = __tmp24Reader.ReadLine();
                    __tmp24_last = __tmp24Reader.EndOfStream;
                    __out.Append(__tmp23Prefix);
                    if (__tmp24Line != null) __out.Append(__tmp24Line);
                    if (!__tmp24_last) __out.AppendLine(true);
                    __out.AppendLine(false); //40:29
                }
            }
            string __tmp25Prefix = "    "; //41:1
            StringBuilder __tmp26 = new StringBuilder();
            __tmp26.Append(GenerateImplementationProvider(model));
            using(StreamReader __tmp26Reader = new StreamReader(this.__ToStream(__tmp26.ToString())))
            {
                bool __tmp26_first = true;
                bool __tmp26_last = __tmp26Reader.EndOfStream;
                while(__tmp26_first || !__tmp26_last)
                {
                    __tmp26_first = false;
                    string __tmp26Line = __tmp26Reader.ReadLine();
                    __tmp26_last = __tmp26Reader.EndOfStream;
                    __out.Append(__tmp25Prefix);
                    if (__tmp26Line != null) __out.Append(__tmp26Line);
                    if (!__tmp26_last) __out.AppendLine(true);
                    __out.AppendLine(false); //41:44
                }
            }
            __out.Append("}"); //42:1
            __out.AppendLine(false); //42:2
            return __out.ToString();
        }

        public string GenerateDocumentation(MetaDocumentedElement elem) //45:1
        {
            StringBuilder __out = new StringBuilder();
            IList<string> lines = elem.GetDocumentationLines(); //46:2
            if (lines.Count > 0) //47:2
            {
                __out.Append("/**"); //48:1
                __out.AppendLine(false); //48:4
                __out.Append(" * <summary>"); //49:1
                __out.AppendLine(false); //49:13
                var __loop7_results = 
                    (from line in __Enumerate((lines).GetEnumerator()) //50:8
                    select new { line = line}
                    ).ToList(); //50:3
                int __loop7_iteration = 0;
                foreach (var __tmp1 in __loop7_results)
                {
                    ++__loop7_iteration;
                    var line = __tmp1.line;
                    string __tmp3Line = " * "; //51:1
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    StringBuilder __tmp4 = new StringBuilder();
                    __tmp4.Append(line);
                    using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                    {
                        bool __tmp4_first = true;
                        bool __tmp4_last = __tmp4Reader.EndOfStream;
                        while(__tmp4_first || !__tmp4_last)
                        {
                            __tmp4_first = false;
                            string __tmp4Line = __tmp4Reader.ReadLine();
                            __tmp4_last = __tmp4Reader.EndOfStream;
                            if (__tmp4Line != null) __out.Append(__tmp4Line);
                            if (!__tmp4_last) __out.AppendLine(true);
                            __out.AppendLine(false); //51:10
                        }
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
            var __loop8_results = 
                (from __loop8_var1 in __Enumerate((elem).GetEnumerator()) //59:7
                from annot in __Enumerate((__loop8_var1.Annotations).GetEnumerator()) //59:13
                select new { __loop8_var1 = __loop8_var1, annot = annot}
                ).ToList(); //59:2
            int __loop8_iteration = 0;
            foreach (var __tmp1 in __loop8_results)
            {
                ++__loop8_iteration;
                var __loop8_var1 = __tmp1.__loop8_var1;
                var annot = __tmp1.annot;
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append("[");
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_first = true;
                    bool __tmp3_last = __tmp3Reader.EndOfStream;
                    while(__tmp3_first || !__tmp3_last)
                    {
                        __tmp3_first = false;
                        string __tmp3Line = __tmp3Reader.ReadLine();
                        __tmp3_last = __tmp3Reader.EndOfStream;
                        if (__tmp3Line != null) __out.Append(__tmp3Line);
                        if (!__tmp3_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append(annot.Name);
                using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                {
                    bool __tmp4_first = true;
                    bool __tmp4_last = __tmp4Reader.EndOfStream;
                    while(__tmp4_first || !__tmp4_last)
                    {
                        __tmp4_first = false;
                        string __tmp4Line = __tmp4Reader.ReadLine();
                        __tmp4_last = __tmp4Reader.EndOfStream;
                        if (__tmp4Line != null) __out.Append(__tmp4Line);
                        if (!__tmp4_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append("]");
                using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                {
                    bool __tmp5_first = true;
                    bool __tmp5_last = __tmp5Reader.EndOfStream;
                    while(__tmp5_first || !__tmp5_last)
                    {
                        __tmp5_first = false;
                        string __tmp5Line = __tmp5Reader.ReadLine();
                        __tmp5_last = __tmp5Reader.EndOfStream;
                        if (__tmp5Line != null) __out.Append(__tmp5Line);
                        if (!__tmp5_last) __out.AppendLine(true);
                        __out.AppendLine(false); //60:23
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateEnum(MetaEnum enm) //64:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(GenerateAnnotations(enm));
            using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
            {
                bool __tmp2_first = true;
                bool __tmp2_last = __tmp2Reader.EndOfStream;
                while(__tmp2_first || !__tmp2_last)
                {
                    __tmp2_first = false;
                    string __tmp2Line = __tmp2Reader.ReadLine();
                    __tmp2_last = __tmp2Reader.EndOfStream;
                    if (__tmp2Line != null) __out.Append(__tmp2Line);
                    if (!__tmp2_last) __out.AppendLine(true);
                    __out.AppendLine(false); //65:27
                }
            }
            string __tmp4Line = "public enum "; //66:1
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(enm.CSharpName());
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_first = true;
                bool __tmp5_last = __tmp5Reader.EndOfStream;
                while(__tmp5_first || !__tmp5_last)
                {
                    __tmp5_first = false;
                    string __tmp5Line = __tmp5Reader.ReadLine();
                    __tmp5_last = __tmp5Reader.EndOfStream;
                    if (__tmp5Line != null) __out.Append(__tmp5Line);
                    if (!__tmp5_last) __out.AppendLine(true);
                    __out.AppendLine(false); //66:31
                }
            }
            __out.Append("{"); //67:1
            __out.AppendLine(false); //67:2
            var __loop9_results = 
                (from __loop9_var1 in __Enumerate((enm).GetEnumerator()) //68:11
                from value in __Enumerate((__loop9_var1.EnumLiterals).GetEnumerator()) //68:16
                select new { __loop9_var1 = __loop9_var1, value = value}
                ).ToList(); //68:6
            int __loop9_iteration = 0;
            foreach (var __tmp6 in __loop9_results)
            {
                ++__loop9_iteration;
                var __loop9_var1 = __tmp6.__loop9_var1;
                var value = __tmp6.value;
                string __tmp7Prefix = "    "; //69:1
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(value.Name);
                using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                {
                    bool __tmp8_first = true;
                    bool __tmp8_last = __tmp8Reader.EndOfStream;
                    while(__tmp8_first || !__tmp8_last)
                    {
                        __tmp8_first = false;
                        string __tmp8Line = __tmp8Reader.ReadLine();
                        __tmp8_last = __tmp8Reader.EndOfStream;
                        __out.Append(__tmp7Prefix);
                        if (__tmp8Line != null) __out.Append(__tmp8Line);
                        if (!__tmp8_last) __out.AppendLine(true);
                    }
                }
                string __tmp9Line = ","; //69:17
                if (__tmp9Line != null) __out.Append(__tmp9Line);
                __out.AppendLine(false); //69:18
            }
            __out.Append("}"); //71:1
            __out.AppendLine(false); //71:2
            __out.AppendLine(true); //72:1
            return __out.ToString();
        }

        public string GetAncestors(MetaClass cls, ClassKind classKind) //75:1
        {
            string result = ""; //76:2
            var __loop10_results = 
                (from __loop10_var1 in __Enumerate((cls).GetEnumerator()) //77:7
                from super in __Enumerate((__loop10_var1.SuperClasses).GetEnumerator()) //77:12
                select new { __loop10_var1 = __loop10_var1, super = super}
                ).ToList(); //77:2
            int __loop10_iteration = 0;
            string delim = " : "; //77:32
            foreach (var __tmp1 in __loop10_results)
            {
                ++__loop10_iteration;
                if (__loop10_iteration >= 2) //77:54
                {
                    delim = ", "; //77:54
                }
                var __loop10_var1 = __tmp1.__loop10_var1;
                var super = __tmp1.super;
                result += delim + super.CSharpFullName(classKind); //78:3
            }
            if (result == "" && classKind == ClassKind.Immutable) //80:2
            {
                result = " : global::MetaDslx.Core.Immutable.ImmutableSymbol"; //81:3
            }
            if (result == "" && classKind == ClassKind.Builder) //83:2
            {
                result = " : global::MetaDslx.Core.Immutable.MutableSymbol"; //84:3
            }
            return result; //86:2
        }

        public string GetDescriptorAncestors(MetaClass cls, ClassKind classKind) //89:1
        {
            string result = ""; //90:2
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((cls).GetEnumerator()) //91:7
                from super in __Enumerate((__loop11_var1.SuperClasses).GetEnumerator()) //91:12
                select new { __loop11_var1 = __loop11_var1, super = super}
                ).ToList(); //91:2
            int __loop11_iteration = 0;
            string delim = ""; //91:32
            foreach (var __tmp1 in __loop11_results)
            {
                ++__loop11_iteration;
                if (__loop11_iteration >= 2) //91:51
                {
                    delim = ", "; //91:51
                }
                var __loop11_var1 = __tmp1.__loop11_var1;
                var super = __tmp1.super;
                result += delim + "typeof(" + super.CSharpFullName(classKind) + ")"; //92:3
            }
            return result; //94:2
        }

        public string GenerateImmutableInterface(MetaClass cls) //97:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal class "; //98:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.CSharpName(ClassKind.Immutable));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(__tmp3_first || !__tmp3_last)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    if (!__tmp3_last) __out.AppendLine(true);
                }
            }
            string __tmp4Line = "Id : global::MetaDslx.Core.Immutable.SymbolId"; //98:53
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //98:98
            __out.Append("{"); //99:1
            __out.AppendLine(false); //99:2
            string __tmp6Line = "	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return "; //100:1
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(cls.Model.CSharpDescriptorName());
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_first = true;
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(__tmp7_first || !__tmp7_last)
                {
                    __tmp7_first = false;
                    string __tmp7Line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    if (__tmp7Line != null) __out.Append(__tmp7Line);
                    if (!__tmp7_last) __out.AppendLine(true);
                }
            }
            string __tmp8Line = "."; //100:131
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(cls.CSharpName());
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_first = true;
                bool __tmp9_last = __tmp9Reader.EndOfStream;
                while(__tmp9_first || !__tmp9_last)
                {
                    __tmp9_first = false;
                    string __tmp9Line = __tmp9Reader.ReadLine();
                    __tmp9_last = __tmp9Reader.EndOfStream;
                    if (__tmp9Line != null) __out.Append(__tmp9Line);
                    if (!__tmp9_last) __out.AppendLine(true);
                }
            }
            string __tmp10Line = ".ModelSymbolInfo; } }"; //100:150
            if (__tmp10Line != null) __out.Append(__tmp10Line);
            __out.AppendLine(false); //100:171
            string __tmp12Line = "    public override global::System.Type ImmutableType { get { return typeof("; //101:1
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(cls.CSharpName(ClassKind.Immutable));
            using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
            {
                bool __tmp13_first = true;
                bool __tmp13_last = __tmp13Reader.EndOfStream;
                while(__tmp13_first || !__tmp13_last)
                {
                    __tmp13_first = false;
                    string __tmp13Line = __tmp13Reader.ReadLine();
                    __tmp13_last = __tmp13Reader.EndOfStream;
                    if (__tmp13Line != null) __out.Append(__tmp13Line);
                    if (!__tmp13_last) __out.AppendLine(true);
                }
            }
            string __tmp14Line = "); } }"; //101:114
            if (__tmp14Line != null) __out.Append(__tmp14Line);
            __out.AppendLine(false); //101:120
            string __tmp16Line = "    public override global::System.Type MutableType { get { return typeof("; //102:1
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(cls.CSharpName(ClassKind.Builder));
            using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
            {
                bool __tmp17_first = true;
                bool __tmp17_last = __tmp17Reader.EndOfStream;
                while(__tmp17_first || !__tmp17_last)
                {
                    __tmp17_first = false;
                    string __tmp17Line = __tmp17Reader.ReadLine();
                    __tmp17_last = __tmp17Reader.EndOfStream;
                    if (__tmp17Line != null) __out.Append(__tmp17Line);
                    if (!__tmp17_last) __out.AppendLine(true);
                }
            }
            string __tmp18Line = "); } }"; //102:110
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //102:116
            __out.AppendLine(true); //103:1
            __out.Append("    public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)"); //104:1
            __out.AppendLine(false); //104:142
            __out.Append("    {"); //105:1
            __out.AppendLine(false); //105:6
            string __tmp20Line = "        return new "; //106:1
            if (__tmp20Line != null) __out.Append(__tmp20Line);
            StringBuilder __tmp21 = new StringBuilder();
            __tmp21.Append(cls.CSharpImplName(ClassKind.Immutable));
            using(StreamReader __tmp21Reader = new StreamReader(this.__ToStream(__tmp21.ToString())))
            {
                bool __tmp21_first = true;
                bool __tmp21_last = __tmp21Reader.EndOfStream;
                while(__tmp21_first || !__tmp21_last)
                {
                    __tmp21_first = false;
                    string __tmp21Line = __tmp21Reader.ReadLine();
                    __tmp21_last = __tmp21Reader.EndOfStream;
                    if (__tmp21Line != null) __out.Append(__tmp21Line);
                    if (!__tmp21_last) __out.AppendLine(true);
                }
            }
            string __tmp22Line = "(this, model);"; //106:61
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            __out.AppendLine(false); //106:75
            __out.Append("    }"); //107:1
            __out.AppendLine(false); //107:6
            __out.AppendLine(true); //108:1
            __out.Append("    public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)"); //109:1
            __out.AppendLine(false); //109:151
            __out.Append("    {"); //110:1
            __out.AppendLine(false); //110:6
            string __tmp24Line = "        return new "; //111:1
            if (__tmp24Line != null) __out.Append(__tmp24Line);
            StringBuilder __tmp25 = new StringBuilder();
            __tmp25.Append(cls.CSharpImplName(ClassKind.Builder));
            using(StreamReader __tmp25Reader = new StreamReader(this.__ToStream(__tmp25.ToString())))
            {
                bool __tmp25_first = true;
                bool __tmp25_last = __tmp25Reader.EndOfStream;
                while(__tmp25_first || !__tmp25_last)
                {
                    __tmp25_first = false;
                    string __tmp25Line = __tmp25Reader.ReadLine();
                    __tmp25_last = __tmp25Reader.EndOfStream;
                    if (__tmp25Line != null) __out.Append(__tmp25Line);
                    if (!__tmp25_last) __out.AppendLine(true);
                }
            }
            string __tmp26Line = "(this, model, creating);"; //111:59
            if (__tmp26Line != null) __out.Append(__tmp26Line);
            __out.AppendLine(false); //111:83
            __out.Append("    }"); //112:1
            __out.AppendLine(false); //112:6
            __out.Append("}"); //113:1
            __out.AppendLine(false); //113:2
            __out.AppendLine(true); //114:1
            StringBuilder __tmp28 = new StringBuilder();
            __tmp28.Append(GenerateAnnotations(cls));
            using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
            {
                bool __tmp28_first = true;
                bool __tmp28_last = __tmp28Reader.EndOfStream;
                while(__tmp28_first || !__tmp28_last)
                {
                    __tmp28_first = false;
                    string __tmp28Line = __tmp28Reader.ReadLine();
                    __tmp28_last = __tmp28Reader.EndOfStream;
                    if (__tmp28Line != null) __out.Append(__tmp28Line);
                    if (!__tmp28_last) __out.AppendLine(true);
                    __out.AppendLine(false); //115:27
                }
            }
            string __tmp30Line = "public interface "; //116:1
            if (__tmp30Line != null) __out.Append(__tmp30Line);
            StringBuilder __tmp31 = new StringBuilder();
            __tmp31.Append(cls.CSharpName(ClassKind.Immutable));
            using(StreamReader __tmp31Reader = new StreamReader(this.__ToStream(__tmp31.ToString())))
            {
                bool __tmp31_first = true;
                bool __tmp31_last = __tmp31Reader.EndOfStream;
                while(__tmp31_first || !__tmp31_last)
                {
                    __tmp31_first = false;
                    string __tmp31Line = __tmp31Reader.ReadLine();
                    __tmp31_last = __tmp31Reader.EndOfStream;
                    if (__tmp31Line != null) __out.Append(__tmp31Line);
                    if (!__tmp31_last) __out.AppendLine(true);
                }
            }
            StringBuilder __tmp32 = new StringBuilder();
            __tmp32.Append(GetAncestors(cls, ClassKind.Immutable));
            using(StreamReader __tmp32Reader = new StreamReader(this.__ToStream(__tmp32.ToString())))
            {
                bool __tmp32_first = true;
                bool __tmp32_last = __tmp32Reader.EndOfStream;
                while(__tmp32_first || !__tmp32_last)
                {
                    __tmp32_first = false;
                    string __tmp32Line = __tmp32Reader.ReadLine();
                    __tmp32_last = __tmp32Reader.EndOfStream;
                    if (__tmp32Line != null) __out.Append(__tmp32Line);
                    if (!__tmp32_last) __out.AppendLine(true);
                    __out.AppendLine(false); //116:95
                }
            }
            __out.Append("{"); //117:1
            __out.AppendLine(false); //117:2
            var __loop12_results = 
                (from __loop12_var1 in __Enumerate((cls).GetEnumerator()) //118:11
                from prop in __Enumerate((__loop12_var1.Properties).GetEnumerator()) //118:16
                select new { __loop12_var1 = __loop12_var1, prop = prop}
                ).ToList(); //118:6
            int __loop12_iteration = 0;
            foreach (var __tmp33 in __loop12_results)
            {
                ++__loop12_iteration;
                var __loop12_var1 = __tmp33.__loop12_var1;
                var prop = __tmp33.prop;
                string __tmp34Prefix = "    "; //119:1
                StringBuilder __tmp35 = new StringBuilder();
                __tmp35.Append(GenerateImmutableProperty(prop));
                using(StreamReader __tmp35Reader = new StreamReader(this.__ToStream(__tmp35.ToString())))
                {
                    bool __tmp35_first = true;
                    bool __tmp35_last = __tmp35Reader.EndOfStream;
                    while(__tmp35_first || !__tmp35_last)
                    {
                        __tmp35_first = false;
                        string __tmp35Line = __tmp35Reader.ReadLine();
                        __tmp35_last = __tmp35Reader.EndOfStream;
                        __out.Append(__tmp34Prefix);
                        if (__tmp35Line != null) __out.Append(__tmp35Line);
                        if (!__tmp35_last) __out.AppendLine(true);
                        __out.AppendLine(false); //119:38
                    }
                }
            }
            __out.AppendLine(true); //121:1
            var __loop13_results = 
                (from __loop13_var1 in __Enumerate((cls).GetEnumerator()) //122:11
                from op in __Enumerate((__loop13_var1.Operations).GetEnumerator()) //122:16
                select new { __loop13_var1 = __loop13_var1, op = op}
                ).ToList(); //122:6
            int __loop13_iteration = 0;
            foreach (var __tmp36 in __loop13_results)
            {
                ++__loop13_iteration;
                var __loop13_var1 = __tmp36.__loop13_var1;
                var op = __tmp36.op;
                string __tmp37Prefix = "    "; //123:1
                StringBuilder __tmp38 = new StringBuilder();
                __tmp38.Append(GenerateOperation(op));
                using(StreamReader __tmp38Reader = new StreamReader(this.__ToStream(__tmp38.ToString())))
                {
                    bool __tmp38_first = true;
                    bool __tmp38_last = __tmp38Reader.EndOfStream;
                    while(__tmp38_first || !__tmp38_last)
                    {
                        __tmp38_first = false;
                        string __tmp38Line = __tmp38Reader.ReadLine();
                        __tmp38_last = __tmp38Reader.EndOfStream;
                        __out.Append(__tmp37Prefix);
                        if (__tmp38Line != null) __out.Append(__tmp38Line);
                        if (!__tmp38_last) __out.AppendLine(true);
                        __out.AppendLine(false); //123:28
                    }
                }
            }
            __out.AppendLine(true); //125:1
            string __tmp40Line = "	new "; //126:1
            if (__tmp40Line != null) __out.Append(__tmp40Line);
            StringBuilder __tmp41 = new StringBuilder();
            __tmp41.Append(cls.CSharpName(ClassKind.Builder));
            using(StreamReader __tmp41Reader = new StreamReader(this.__ToStream(__tmp41.ToString())))
            {
                bool __tmp41_first = true;
                bool __tmp41_last = __tmp41Reader.EndOfStream;
                while(__tmp41_first || !__tmp41_last)
                {
                    __tmp41_first = false;
                    string __tmp41Line = __tmp41Reader.ReadLine();
                    __tmp41_last = __tmp41Reader.EndOfStream;
                    if (__tmp41Line != null) __out.Append(__tmp41Line);
                    if (!__tmp41_last) __out.AppendLine(true);
                }
            }
            string __tmp42Line = " ToMutable();"; //126:41
            if (__tmp42Line != null) __out.Append(__tmp42Line);
            __out.AppendLine(false); //126:54
            string __tmp44Line = "	new "; //127:1
            if (__tmp44Line != null) __out.Append(__tmp44Line);
            StringBuilder __tmp45 = new StringBuilder();
            __tmp45.Append(cls.CSharpName(ClassKind.Builder));
            using(StreamReader __tmp45Reader = new StreamReader(this.__ToStream(__tmp45.ToString())))
            {
                bool __tmp45_first = true;
                bool __tmp45_last = __tmp45Reader.EndOfStream;
                while(__tmp45_first || !__tmp45_last)
                {
                    __tmp45_first = false;
                    string __tmp45Line = __tmp45Reader.ReadLine();
                    __tmp45_last = __tmp45Reader.EndOfStream;
                    if (__tmp45Line != null) __out.Append(__tmp45Line);
                    if (!__tmp45_last) __out.AppendLine(true);
                }
            }
            string __tmp46Line = " ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);"; //127:41
            if (__tmp46Line != null) __out.Append(__tmp46Line);
            __out.AppendLine(false); //127:104
            __out.Append("}"); //128:1
            __out.AppendLine(false); //128:2
            __out.AppendLine(true); //129:1
            return __out.ToString();
        }

        public string GenerateBuilderInterface(MetaClass cls) //132:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "public interface "; //133:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.CSharpName(ClassKind.Builder));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(__tmp3_first || !__tmp3_last)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    if (!__tmp3_last) __out.AppendLine(true);
                }
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(GetAncestors(cls, ClassKind.Builder));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_first = true;
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(__tmp4_first || !__tmp4_last)
                {
                    __tmp4_first = false;
                    string __tmp4Line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (__tmp4Line != null) __out.Append(__tmp4Line);
                    if (!__tmp4_last) __out.AppendLine(true);
                    __out.AppendLine(false); //133:91
                }
            }
            __out.Append("{"); //134:1
            __out.AppendLine(false); //134:2
            var __loop14_results = 
                (from __loop14_var1 in __Enumerate((cls).GetEnumerator()) //135:11
                from prop in __Enumerate((__loop14_var1.Properties).GetEnumerator()) //135:16
                select new { __loop14_var1 = __loop14_var1, prop = prop}
                ).ToList(); //135:6
            int __loop14_iteration = 0;
            foreach (var __tmp5 in __loop14_results)
            {
                ++__loop14_iteration;
                var __loop14_var1 = __tmp5.__loop14_var1;
                var prop = __tmp5.prop;
                string __tmp6Prefix = "    "; //136:1
                StringBuilder __tmp7 = new StringBuilder();
                __tmp7.Append(GenerateBuilderProperty(prop));
                using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
                {
                    bool __tmp7_first = true;
                    bool __tmp7_last = __tmp7Reader.EndOfStream;
                    while(__tmp7_first || !__tmp7_last)
                    {
                        __tmp7_first = false;
                        string __tmp7Line = __tmp7Reader.ReadLine();
                        __tmp7_last = __tmp7Reader.EndOfStream;
                        __out.Append(__tmp6Prefix);
                        if (__tmp7Line != null) __out.Append(__tmp7Line);
                        if (!__tmp7_last) __out.AppendLine(true);
                        __out.AppendLine(false); //136:36
                    }
                }
            }
            __out.AppendLine(true); //138:1
            string __tmp9Line = "	new "; //139:1
            if (__tmp9Line != null) __out.Append(__tmp9Line);
            StringBuilder __tmp10 = new StringBuilder();
            __tmp10.Append(cls.CSharpName(ClassKind.Immutable));
            using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
            {
                bool __tmp10_first = true;
                bool __tmp10_last = __tmp10Reader.EndOfStream;
                while(__tmp10_first || !__tmp10_last)
                {
                    __tmp10_first = false;
                    string __tmp10Line = __tmp10Reader.ReadLine();
                    __tmp10_last = __tmp10Reader.EndOfStream;
                    if (__tmp10Line != null) __out.Append(__tmp10Line);
                    if (!__tmp10_last) __out.AppendLine(true);
                }
            }
            string __tmp11Line = " ToImmutable();"; //139:43
            if (__tmp11Line != null) __out.Append(__tmp11Line);
            __out.AppendLine(false); //139:58
            string __tmp13Line = "	new "; //140:1
            if (__tmp13Line != null) __out.Append(__tmp13Line);
            StringBuilder __tmp14 = new StringBuilder();
            __tmp14.Append(cls.CSharpName(ClassKind.Immutable));
            using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
            {
                bool __tmp14_first = true;
                bool __tmp14_last = __tmp14Reader.EndOfStream;
                while(__tmp14_first || !__tmp14_last)
                {
                    __tmp14_first = false;
                    string __tmp14Line = __tmp14Reader.ReadLine();
                    __tmp14_last = __tmp14Reader.EndOfStream;
                    if (__tmp14Line != null) __out.Append(__tmp14Line);
                    if (!__tmp14_last) __out.AppendLine(true);
                }
            }
            string __tmp15Line = " ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);"; //140:43
            if (__tmp15Line != null) __out.Append(__tmp15Line);
            __out.AppendLine(false); //140:110
            __out.Append("}"); //141:1
            __out.AppendLine(false); //141:2
            __out.AppendLine(true); //142:1
            return __out.ToString();
        }

        public string GenerateImmutableProperty(MetaProperty prop) //145:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //146:2
            {
                __out.Append("new "); //147:1
            }
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(prop.Type.CSharpFullPublicName(ClassKind.Immutable));
            using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
            {
                bool __tmp2_first = true;
                bool __tmp2_last = __tmp2Reader.EndOfStream;
                while(__tmp2_first || !__tmp2_last)
                {
                    __tmp2_first = false;
                    string __tmp2Line = __tmp2Reader.ReadLine();
                    __tmp2_last = __tmp2Reader.EndOfStream;
                    if (__tmp2Line != null) __out.Append(__tmp2Line);
                    if (!__tmp2_last) __out.AppendLine(true);
                }
            }
            string __tmp3Line = " "; //149:54
            if (__tmp3Line != null) __out.Append(__tmp3Line);
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(prop.Name);
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_first = true;
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(__tmp4_first || !__tmp4_last)
                {
                    __tmp4_first = false;
                    string __tmp4Line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (__tmp4Line != null) __out.Append(__tmp4Line);
                    if (!__tmp4_last) __out.AppendLine(true);
                }
            }
            string __tmp5Line = " { get; }"; //149:66
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            __out.AppendLine(false); //149:75
            return __out.ToString();
        }

        public string GenerateImmutableField(MetaClass cls, MetaProperty prop) //152:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
            using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
            {
                bool __tmp2_first = true;
                bool __tmp2_last = __tmp2Reader.EndOfStream;
                while(__tmp2_first || !__tmp2_last)
                {
                    __tmp2_first = false;
                    string __tmp2Line = __tmp2Reader.ReadLine();
                    __tmp2_last = __tmp2Reader.EndOfStream;
                    if (__tmp2Line != null) __out.Append(__tmp2Line);
                    if (!__tmp2_last) __out.AppendLine(true);
                    __out.AppendLine(false); //153:54
                }
            }
            string __tmp4Line = "private "; //154:1
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(prop.Type.CSharpFullPublicName(ClassKind.Immutable));
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_first = true;
                bool __tmp5_last = __tmp5Reader.EndOfStream;
                while(__tmp5_first || !__tmp5_last)
                {
                    __tmp5_first = false;
                    string __tmp5Line = __tmp5Reader.ReadLine();
                    __tmp5_last = __tmp5Reader.EndOfStream;
                    if (__tmp5Line != null) __out.Append(__tmp5Line);
                    if (!__tmp5_last) __out.AppendLine(true);
                }
            }
            string __tmp6Line = " "; //154:62
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(prop.GetFieldName(cls));
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_first = true;
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(__tmp7_first || !__tmp7_last)
                {
                    __tmp7_first = false;
                    string __tmp7Line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    if (__tmp7Line != null) __out.Append(__tmp7Line);
                    if (!__tmp7_last) __out.AppendLine(true);
                }
            }
            string __tmp8Line = ";"; //154:87
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //154:88
            return __out.ToString();
        }

        public string GenerateBuilderProperty(MetaProperty prop) //157:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //158:2
            {
                __out.Append("new "); //159:1
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //161:3
            {
                StringBuilder __tmp2 = new StringBuilder();
                __tmp2.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
                {
                    bool __tmp2_first = true;
                    bool __tmp2_last = __tmp2Reader.EndOfStream;
                    while(__tmp2_first || !__tmp2_last)
                    {
                        __tmp2_first = false;
                        string __tmp2Line = __tmp2Reader.ReadLine();
                        __tmp2_last = __tmp2Reader.EndOfStream;
                        if (__tmp2Line != null) __out.Append(__tmp2Line);
                        if (!__tmp2_last) __out.AppendLine(true);
                    }
                }
                string __tmp3Line = " "; //162:52
                if (__tmp3Line != null) __out.Append(__tmp3Line);
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append(prop.Name);
                using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                {
                    bool __tmp4_first = true;
                    bool __tmp4_last = __tmp4Reader.EndOfStream;
                    while(__tmp4_first || !__tmp4_last)
                    {
                        __tmp4_first = false;
                        string __tmp4Line = __tmp4Reader.ReadLine();
                        __tmp4_last = __tmp4Reader.EndOfStream;
                        if (__tmp4Line != null) __out.Append(__tmp4Line);
                        if (!__tmp4_last) __out.AppendLine(true);
                    }
                }
                string __tmp5Line = " { get; set; }"; //162:64
                if (__tmp5Line != null) __out.Append(__tmp5Line);
                __out.AppendLine(false); //162:78
            }
            else //163:3
            {
                StringBuilder __tmp7 = new StringBuilder();
                __tmp7.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
                {
                    bool __tmp7_first = true;
                    bool __tmp7_last = __tmp7Reader.EndOfStream;
                    while(__tmp7_first || !__tmp7_last)
                    {
                        __tmp7_first = false;
                        string __tmp7Line = __tmp7Reader.ReadLine();
                        __tmp7_last = __tmp7Reader.EndOfStream;
                        if (__tmp7Line != null) __out.Append(__tmp7Line);
                        if (!__tmp7_last) __out.AppendLine(true);
                    }
                }
                string __tmp8Line = " "; //164:52
                if (__tmp8Line != null) __out.Append(__tmp8Line);
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append(prop.Name);
                using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                {
                    bool __tmp9_first = true;
                    bool __tmp9_last = __tmp9Reader.EndOfStream;
                    while(__tmp9_first || !__tmp9_last)
                    {
                        __tmp9_first = false;
                        string __tmp9Line = __tmp9Reader.ReadLine();
                        __tmp9_last = __tmp9Reader.EndOfStream;
                        if (__tmp9Line != null) __out.Append(__tmp9Line);
                        if (!__tmp9_last) __out.AppendLine(true);
                    }
                }
                string __tmp10Line = " { get; }"; //164:64
                if (__tmp10Line != null) __out.Append(__tmp10Line);
                __out.AppendLine(false); //164:73
            }
            if (!(prop.Type is MetaCollectionType)) //166:2
            {
                if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //167:3
                {
                    __out.Append("new "); //168:1
                }
                string __tmp12Line = "Func<"; //170:1
                if (__tmp12Line != null) __out.Append(__tmp12Line);
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                {
                    bool __tmp13_first = true;
                    bool __tmp13_last = __tmp13Reader.EndOfStream;
                    while(__tmp13_first || !__tmp13_last)
                    {
                        __tmp13_first = false;
                        string __tmp13Line = __tmp13Reader.ReadLine();
                        __tmp13_last = __tmp13Reader.EndOfStream;
                        if (__tmp13Line != null) __out.Append(__tmp13Line);
                        if (!__tmp13_last) __out.AppendLine(true);
                    }
                }
                string __tmp14Line = "> "; //170:57
                if (__tmp14Line != null) __out.Append(__tmp14Line);
                StringBuilder __tmp15 = new StringBuilder();
                __tmp15.Append(prop.Name);
                using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
                {
                    bool __tmp15_first = true;
                    bool __tmp15_last = __tmp15Reader.EndOfStream;
                    while(__tmp15_first || !__tmp15_last)
                    {
                        __tmp15_first = false;
                        string __tmp15Line = __tmp15Reader.ReadLine();
                        __tmp15_last = __tmp15Reader.EndOfStream;
                        if (__tmp15Line != null) __out.Append(__tmp15Line);
                        if (!__tmp15_last) __out.AppendLine(true);
                    }
                }
                string __tmp16Line = "Lazy { get; set; }"; //170:70
                if (__tmp16Line != null) __out.Append(__tmp16Line);
                __out.AppendLine(false); //170:88
            }
            if (prop.Kind == MetaPropertyKind.Containment && (((prop.Type is MetaCollectionType) && (((MetaCollectionType)prop.Type).InnerType is MetaClass)) || (!(prop.Type is MetaCollectionType) && prop.Type is MetaClass))) //172:2
            {
                if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //173:3
                {
                    __out.Append("new "); //174:1
                }
            }
            return __out.ToString();
        }

        public string GenerateBuilderField(MetaClass cls, MetaProperty prop) //179:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "private "; //180:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(__tmp3_first || !__tmp3_last)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    if (!__tmp3_last) __out.AppendLine(true);
                }
            }
            string __tmp4Line = " "; //180:60
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(prop.GetFieldName(cls));
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_first = true;
                bool __tmp5_last = __tmp5Reader.EndOfStream;
                while(__tmp5_first || !__tmp5_last)
                {
                    __tmp5_first = false;
                    string __tmp5Line = __tmp5Reader.ReadLine();
                    __tmp5_last = __tmp5Reader.EndOfStream;
                    if (__tmp5Line != null) __out.Append(__tmp5Line);
                    if (!__tmp5_last) __out.AppendLine(true);
                }
            }
            string __tmp6Line = ";"; //180:85
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            __out.AppendLine(false); //180:86
            return __out.ToString();
        }

        public string GetParameters(MetaFunction op, ClassKind classKind) //183:1
        {
            string result = ""; //184:2
            var __loop15_results = 
                (from __loop15_var1 in __Enumerate((op).GetEnumerator()) //185:7
                from param in __Enumerate((__loop15_var1.Parameters).GetEnumerator()) //185:11
                select new { __loop15_var1 = __loop15_var1, param = param}
                ).ToList(); //185:2
            int __loop15_iteration = 0;
            string delim = ""; //185:29
            foreach (var __tmp1 in __loop15_results)
            {
                ++__loop15_iteration;
                if (__loop15_iteration >= 2) //185:48
                {
                    delim = ", "; //185:48
                }
                var __loop15_var1 = __tmp1.__loop15_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(classKind) + " " + param.Name; //186:3
            }
            return result; //188:2
        }

        public string GetImplParameters(MetaClass cls, MetaOperation op) //191:1
        {
            string result = cls.CSharpFullName(ClassKind.Immutable) + " _this"; //192:2
            string delim = ", "; //193:2
            var __loop16_results = 
                (from __loop16_var1 in __Enumerate((op).GetEnumerator()) //194:7
                from param in __Enumerate((__loop16_var1.Parameters).GetEnumerator()) //194:11
                select new { __loop16_var1 = __loop16_var1, param = param}
                ).ToList(); //194:2
            int __loop16_iteration = 0;
            foreach (var __tmp1 in __loop16_results)
            {
                ++__loop16_iteration;
                var __loop16_var1 = __tmp1.__loop16_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(ClassKind.Immutable) + " " + param.Name; //195:3
            }
            return result; //197:2
        }

        public string GetImplParameters(MetaEnum enm, MetaOperation op) //200:1
        {
            string result = enm.CSharpFullName(ClassKind.Immutable) + " _this"; //201:2
            string delim = ", "; //202:2
            var __loop17_results = 
                (from __loop17_var1 in __Enumerate((op).GetEnumerator()) //203:7
                from param in __Enumerate((__loop17_var1.Parameters).GetEnumerator()) //203:11
                select new { __loop17_var1 = __loop17_var1, param = param}
                ).ToList(); //203:2
            int __loop17_iteration = 0;
            foreach (var __tmp1 in __loop17_results)
            {
                ++__loop17_iteration;
                var __loop17_var1 = __tmp1.__loop17_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(ClassKind.Immutable) + " " + param.Name; //204:3
            }
            return result; //206:2
        }

        public string GetEnumImplParameters(MetaEnum enm, MetaOperation op) //209:1
        {
            string result = "this " + enm.CSharpFullName(ClassKind.Immutable) + " _this"; //210:2
            string delim = ", "; //211:2
            var __loop18_results = 
                (from __loop18_var1 in __Enumerate((op).GetEnumerator()) //212:7
                from param in __Enumerate((__loop18_var1.Parameters).GetEnumerator()) //212:11
                select new { __loop18_var1 = __loop18_var1, param = param}
                ).ToList(); //212:2
            int __loop18_iteration = 0;
            foreach (var __tmp1 in __loop18_results)
            {
                ++__loop18_iteration;
                var __loop18_var1 = __tmp1.__loop18_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(ClassKind.Immutable) + " " + param.Name; //213:3
            }
            return result; //215:2
        }

        public string GetEnumImplCallParameterNames(MetaOperation op) //218:1
        {
            string result = "_this"; //219:2
            string delim = ", "; //220:2
            var __loop19_results = 
                (from __loop19_var1 in __Enumerate((op).GetEnumerator()) //221:7
                from param in __Enumerate((__loop19_var1.Parameters).GetEnumerator()) //221:11
                select new { __loop19_var1 = __loop19_var1, param = param}
                ).ToList(); //221:2
            int __loop19_iteration = 0;
            foreach (var __tmp1 in __loop19_results)
            {
                ++__loop19_iteration;
                var __loop19_var1 = __tmp1.__loop19_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //222:3
            }
            return result; //224:2
        }

        public string GetImplCallParameterNames(MetaOperation op) //227:1
        {
            string result = "this"; //228:2
            string delim = ", "; //229:2
            var __loop20_results = 
                (from __loop20_var1 in __Enumerate((op).GetEnumerator()) //230:7
                from param in __Enumerate((__loop20_var1.Parameters).GetEnumerator()) //230:11
                select new { __loop20_var1 = __loop20_var1, param = param}
                ).ToList(); //230:2
            int __loop20_iteration = 0;
            foreach (var __tmp1 in __loop20_results)
            {
                ++__loop20_iteration;
                var __loop20_var1 = __tmp1.__loop20_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //231:3
            }
            return result; //233:2
        }

        public string GenerateOperation(MetaOperation op) //236:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(op.ReturnType.CSharpFullPublicName(ClassKind.Immutable));
            using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
            {
                bool __tmp2_first = true;
                bool __tmp2_last = __tmp2Reader.EndOfStream;
                while(__tmp2_first || !__tmp2_last)
                {
                    __tmp2_first = false;
                    string __tmp2Line = __tmp2Reader.ReadLine();
                    __tmp2_last = __tmp2Reader.EndOfStream;
                    if (__tmp2Line != null) __out.Append(__tmp2Line);
                    if (!__tmp2_last) __out.AppendLine(true);
                }
            }
            string __tmp3Line = " "; //237:58
            if (__tmp3Line != null) __out.Append(__tmp3Line);
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(op.Name);
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_first = true;
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(__tmp4_first || !__tmp4_last)
                {
                    __tmp4_first = false;
                    string __tmp4Line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (__tmp4Line != null) __out.Append(__tmp4Line);
                    if (!__tmp4_last) __out.AppendLine(true);
                }
            }
            string __tmp5Line = "("; //237:68
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(GetParameters(op, ClassKind.Immutable));
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(__tmp6_first || !__tmp6_last)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if (__tmp6Line != null) __out.Append(__tmp6Line);
                    if (!__tmp6_last) __out.AppendLine(true);
                }
            }
            string __tmp7Line = ");"; //237:109
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //237:111
            return __out.ToString();
        }

        public string GenerateImmutableInterfaceImpl(MetaModel model, MetaClass cls) //240:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal class "; //241:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.CSharpImplName(ClassKind.Immutable));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(__tmp3_first || !__tmp3_last)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    if (!__tmp3_last) __out.AppendLine(true);
                }
            }
            string __tmp4Line = " : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, "; //241:57
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(cls.CSharpFullName(ClassKind.Immutable));
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_first = true;
                bool __tmp5_last = __tmp5Reader.EndOfStream;
                while(__tmp5_first || !__tmp5_last)
                {
                    __tmp5_first = false;
                    string __tmp5Line = __tmp5Reader.ReadLine();
                    __tmp5_last = __tmp5Reader.EndOfStream;
                    if (__tmp5Line != null) __out.Append(__tmp5Line);
                    if (!__tmp5_last) __out.AppendLine(true);
                    __out.AppendLine(false); //241:154
                }
            }
            __out.Append("{"); //242:1
            __out.AppendLine(false); //242:2
            var __loop21_results = 
                (from __loop21_var1 in __Enumerate((cls).GetEnumerator()) //243:11
                from prop in __Enumerate((__loop21_var1.GetAllProperties()).GetEnumerator()) //243:16
                select new { __loop21_var1 = __loop21_var1, prop = prop}
                ).ToList(); //243:6
            int __loop21_iteration = 0;
            foreach (var __tmp6 in __loop21_results)
            {
                ++__loop21_iteration;
                var __loop21_var1 = __tmp6.__loop21_var1;
                var prop = __tmp6.prop;
                string __tmp7Prefix = "    "; //244:1
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(GenerateImmutableField(cls, prop));
                using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                {
                    bool __tmp8_first = true;
                    bool __tmp8_last = __tmp8Reader.EndOfStream;
                    while(__tmp8_first || !__tmp8_last)
                    {
                        __tmp8_first = false;
                        string __tmp8Line = __tmp8Reader.ReadLine();
                        __tmp8_last = __tmp8Reader.EndOfStream;
                        __out.Append(__tmp7Prefix);
                        if (__tmp8Line != null) __out.Append(__tmp8Line);
                        if (!__tmp8_last) __out.AppendLine(true);
                        __out.AppendLine(false); //244:40
                    }
                }
            }
            __out.AppendLine(true); //246:1
            string __tmp10Line = "    internal "; //247:1
            if (__tmp10Line != null) __out.Append(__tmp10Line);
            StringBuilder __tmp11 = new StringBuilder();
            __tmp11.Append(cls.CSharpImplName());
            using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
            {
                bool __tmp11_first = true;
                bool __tmp11_last = __tmp11Reader.EndOfStream;
                while(__tmp11_first || !__tmp11_last)
                {
                    __tmp11_first = false;
                    string __tmp11Line = __tmp11Reader.ReadLine();
                    __tmp11_last = __tmp11Reader.EndOfStream;
                    if (__tmp11Line != null) __out.Append(__tmp11Line);
                    if (!__tmp11_last) __out.AppendLine(true);
                }
            }
            string __tmp12Line = "(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)"; //247:36
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //247:135
            __out.Append("		: base(id, model)"); //248:1
            __out.AppendLine(false); //248:20
            __out.Append("    {"); //249:1
            __out.AppendLine(false); //249:6
            __out.Append("    }"); //250:1
            __out.AppendLine(false); //250:6
            __out.AppendLine(true); //251:1
            __out.Append("    public override object MMetaModel"); //252:1
            __out.AppendLine(false); //252:38
            __out.Append("    {"); //253:1
            __out.AppendLine(false); //253:6
            string __tmp14Line = "        get { return null;/*"; //254:1
            if (__tmp14Line != null) __out.Append(__tmp14Line);
            StringBuilder __tmp15 = new StringBuilder();
            __tmp15.Append(cls.Model.CSharpFullInstanceName());
            using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
            {
                bool __tmp15_first = true;
                bool __tmp15_last = __tmp15Reader.EndOfStream;
                while(__tmp15_first || !__tmp15_last)
                {
                    __tmp15_first = false;
                    string __tmp15Line = __tmp15Reader.ReadLine();
                    __tmp15_last = __tmp15Reader.EndOfStream;
                    if (__tmp15Line != null) __out.Append(__tmp15Line);
                    if (!__tmp15_last) __out.AppendLine(true);
                }
            }
            string __tmp16Line = ";*/ }"; //254:65
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            __out.AppendLine(false); //254:70
            __out.Append("    }"); //255:1
            __out.AppendLine(false); //255:6
            __out.AppendLine(true); //256:1
            __out.Append("    public override object MMetaClass"); //257:1
            __out.AppendLine(false); //257:38
            __out.Append("    {"); //258:1
            __out.AppendLine(false); //258:6
            string __tmp18Line = "        get { return null; /*"; //259:1
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            StringBuilder __tmp19 = new StringBuilder();
            __tmp19.Append(cls.CSharpFullInstanceName());
            using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
            {
                bool __tmp19_first = true;
                bool __tmp19_last = __tmp19Reader.EndOfStream;
                while(__tmp19_first || !__tmp19_last)
                {
                    __tmp19_first = false;
                    string __tmp19Line = __tmp19Reader.ReadLine();
                    __tmp19_last = __tmp19Reader.EndOfStream;
                    if (__tmp19Line != null) __out.Append(__tmp19Line);
                    if (!__tmp19_last) __out.AppendLine(true);
                }
            }
            string __tmp20Line = ";*/ }"; //259:60
            if (__tmp20Line != null) __out.Append(__tmp20Line);
            __out.AppendLine(false); //259:65
            __out.Append("    }"); //260:1
            __out.AppendLine(false); //260:6
            __out.AppendLine(true); //261:1
            string __tmp22Line = "    public new "; //262:1
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            StringBuilder __tmp23 = new StringBuilder();
            __tmp23.Append(cls.CSharpFullName(ClassKind.Builder));
            using(StreamReader __tmp23Reader = new StreamReader(this.__ToStream(__tmp23.ToString())))
            {
                bool __tmp23_first = true;
                bool __tmp23_last = __tmp23Reader.EndOfStream;
                while(__tmp23_first || !__tmp23_last)
                {
                    __tmp23_first = false;
                    string __tmp23Line = __tmp23Reader.ReadLine();
                    __tmp23_last = __tmp23Reader.EndOfStream;
                    if (__tmp23Line != null) __out.Append(__tmp23Line);
                    if (!__tmp23_last) __out.AppendLine(true);
                }
            }
            string __tmp24Line = " ToMutable()"; //262:55
            if (__tmp24Line != null) __out.Append(__tmp24Line);
            __out.AppendLine(false); //262:67
            __out.Append("	{"); //263:1
            __out.AppendLine(false); //263:3
            string __tmp26Line = "		return ("; //264:1
            if (__tmp26Line != null) __out.Append(__tmp26Line);
            StringBuilder __tmp27 = new StringBuilder();
            __tmp27.Append(cls.CSharpFullName(ClassKind.Builder));
            using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
            {
                bool __tmp27_first = true;
                bool __tmp27_last = __tmp27Reader.EndOfStream;
                while(__tmp27_first || !__tmp27_last)
                {
                    __tmp27_first = false;
                    string __tmp27Line = __tmp27Reader.ReadLine();
                    __tmp27_last = __tmp27Reader.EndOfStream;
                    if (__tmp27Line != null) __out.Append(__tmp27Line);
                    if (!__tmp27_last) __out.AppendLine(true);
                }
            }
            string __tmp28Line = ")base.ToMutable();"; //264:50
            if (__tmp28Line != null) __out.Append(__tmp28Line);
            __out.AppendLine(false); //264:68
            __out.Append("	}"); //265:1
            __out.AppendLine(false); //265:3
            __out.AppendLine(true); //266:1
            string __tmp30Line = "    public new "; //267:1
            if (__tmp30Line != null) __out.Append(__tmp30Line);
            StringBuilder __tmp31 = new StringBuilder();
            __tmp31.Append(cls.CSharpFullName(ClassKind.Builder));
            using(StreamReader __tmp31Reader = new StreamReader(this.__ToStream(__tmp31.ToString())))
            {
                bool __tmp31_first = true;
                bool __tmp31_last = __tmp31Reader.EndOfStream;
                while(__tmp31_first || !__tmp31_last)
                {
                    __tmp31_first = false;
                    string __tmp31Line = __tmp31Reader.ReadLine();
                    __tmp31_last = __tmp31Reader.EndOfStream;
                    if (__tmp31Line != null) __out.Append(__tmp31Line);
                    if (!__tmp31_last) __out.AppendLine(true);
                }
            }
            string __tmp32Line = " ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)"; //267:55
            if (__tmp32Line != null) __out.Append(__tmp32Line);
            __out.AppendLine(false); //267:117
            __out.Append("	{"); //268:1
            __out.AppendLine(false); //268:3
            string __tmp34Line = "		return ("; //269:1
            if (__tmp34Line != null) __out.Append(__tmp34Line);
            StringBuilder __tmp35 = new StringBuilder();
            __tmp35.Append(cls.CSharpFullName(ClassKind.Builder));
            using(StreamReader __tmp35Reader = new StreamReader(this.__ToStream(__tmp35.ToString())))
            {
                bool __tmp35_first = true;
                bool __tmp35_last = __tmp35Reader.EndOfStream;
                while(__tmp35_first || !__tmp35_last)
                {
                    __tmp35_first = false;
                    string __tmp35Line = __tmp35Reader.ReadLine();
                    __tmp35_last = __tmp35Reader.EndOfStream;
                    if (__tmp35Line != null) __out.Append(__tmp35Line);
                    if (!__tmp35_last) __out.AppendLine(true);
                }
            }
            string __tmp36Line = ")base.ToMutable(model);"; //269:50
            if (__tmp36Line != null) __out.Append(__tmp36Line);
            __out.AppendLine(false); //269:73
            __out.Append("	}"); //270:1
            __out.AppendLine(false); //270:3
            var __loop22_results = 
                (from __loop22_var1 in __Enumerate((cls).GetEnumerator()) //271:8
                from sup in __Enumerate((__loop22_var1.GetAllSuperClasses()).GetEnumerator()) //271:13
                select new { __loop22_var1 = __loop22_var1, sup = sup}
                ).ToList(); //271:3
            int __loop22_iteration = 0;
            foreach (var __tmp37 in __loop22_results)
            {
                ++__loop22_iteration;
                var __loop22_var1 = __tmp37.__loop22_var1;
                var sup = __tmp37.sup;
                __out.AppendLine(true); //272:1
                string __tmp38Prefix = "    "; //273:1
                StringBuilder __tmp39 = new StringBuilder();
                __tmp39.Append(sup.CSharpFullName(ClassKind.Builder));
                using(StreamReader __tmp39Reader = new StreamReader(this.__ToStream(__tmp39.ToString())))
                {
                    bool __tmp39_first = true;
                    bool __tmp39_last = __tmp39Reader.EndOfStream;
                    while(__tmp39_first || !__tmp39_last)
                    {
                        __tmp39_first = false;
                        string __tmp39Line = __tmp39Reader.ReadLine();
                        __tmp39_last = __tmp39Reader.EndOfStream;
                        __out.Append(__tmp38Prefix);
                        if (__tmp39Line != null) __out.Append(__tmp39Line);
                        if (!__tmp39_last) __out.AppendLine(true);
                    }
                }
                string __tmp40Line = " "; //273:44
                if (__tmp40Line != null) __out.Append(__tmp40Line);
                StringBuilder __tmp41 = new StringBuilder();
                __tmp41.Append(sup.CSharpFullName(ClassKind.Immutable));
                using(StreamReader __tmp41Reader = new StreamReader(this.__ToStream(__tmp41.ToString())))
                {
                    bool __tmp41_first = true;
                    bool __tmp41_last = __tmp41Reader.EndOfStream;
                    while(__tmp41_first || !__tmp41_last)
                    {
                        __tmp41_first = false;
                        string __tmp41Line = __tmp41Reader.ReadLine();
                        __tmp41_last = __tmp41Reader.EndOfStream;
                        if (__tmp41Line != null) __out.Append(__tmp41Line);
                        if (!__tmp41_last) __out.AppendLine(true);
                    }
                }
                string __tmp42Line = ".ToMutable()"; //273:86
                if (__tmp42Line != null) __out.Append(__tmp42Line);
                __out.AppendLine(false); //273:98
                __out.Append("	{"); //274:1
                __out.AppendLine(false); //274:3
                __out.Append("		return this.ToMutable();"); //275:1
                __out.AppendLine(false); //275:27
                __out.Append("	}"); //276:1
                __out.AppendLine(false); //276:3
                __out.AppendLine(true); //277:1
                string __tmp43Prefix = "    "; //278:1
                StringBuilder __tmp44 = new StringBuilder();
                __tmp44.Append(sup.CSharpFullName(ClassKind.Builder));
                using(StreamReader __tmp44Reader = new StreamReader(this.__ToStream(__tmp44.ToString())))
                {
                    bool __tmp44_first = true;
                    bool __tmp44_last = __tmp44Reader.EndOfStream;
                    while(__tmp44_first || !__tmp44_last)
                    {
                        __tmp44_first = false;
                        string __tmp44Line = __tmp44Reader.ReadLine();
                        __tmp44_last = __tmp44Reader.EndOfStream;
                        __out.Append(__tmp43Prefix);
                        if (__tmp44Line != null) __out.Append(__tmp44Line);
                        if (!__tmp44_last) __out.AppendLine(true);
                    }
                }
                string __tmp45Line = " "; //278:44
                if (__tmp45Line != null) __out.Append(__tmp45Line);
                StringBuilder __tmp46 = new StringBuilder();
                __tmp46.Append(sup.CSharpFullName(ClassKind.Immutable));
                using(StreamReader __tmp46Reader = new StreamReader(this.__ToStream(__tmp46.ToString())))
                {
                    bool __tmp46_first = true;
                    bool __tmp46_last = __tmp46Reader.EndOfStream;
                    while(__tmp46_first || !__tmp46_last)
                    {
                        __tmp46_first = false;
                        string __tmp46Line = __tmp46Reader.ReadLine();
                        __tmp46_last = __tmp46Reader.EndOfStream;
                        if (__tmp46Line != null) __out.Append(__tmp46Line);
                        if (!__tmp46_last) __out.AppendLine(true);
                    }
                }
                string __tmp47Line = ".ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)"; //278:86
                if (__tmp47Line != null) __out.Append(__tmp47Line);
                __out.AppendLine(false); //278:148
                __out.Append("	{"); //279:1
                __out.AppendLine(false); //279:3
                __out.Append("		return this.ToMutable(model);"); //280:1
                __out.AppendLine(false); //280:32
                __out.Append("	}"); //281:1
                __out.AppendLine(false); //281:3
            }
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((cls).GetEnumerator()) //283:11
                from prop in __Enumerate((__loop23_var1.GetAllProperties()).GetEnumerator()) //283:16
                select new { __loop23_var1 = __loop23_var1, prop = prop}
                ).ToList(); //283:6
            int __loop23_iteration = 0;
            foreach (var __tmp48 in __loop23_results)
            {
                ++__loop23_iteration;
                var __loop23_var1 = __tmp48.__loop23_var1;
                var prop = __tmp48.prop;
                __out.AppendLine(true); //284:1
                string __tmp49Prefix = "    "; //285:1
                StringBuilder __tmp50 = new StringBuilder();
                __tmp50.Append(GenerateImmutablePropertyImpl(model, cls, prop));
                using(StreamReader __tmp50Reader = new StreamReader(this.__ToStream(__tmp50.ToString())))
                {
                    bool __tmp50_first = true;
                    bool __tmp50_last = __tmp50Reader.EndOfStream;
                    while(__tmp50_first || !__tmp50_last)
                    {
                        __tmp50_first = false;
                        string __tmp50Line = __tmp50Reader.ReadLine();
                        __tmp50_last = __tmp50Reader.EndOfStream;
                        __out.Append(__tmp49Prefix);
                        if (__tmp50Line != null) __out.Append(__tmp50Line);
                        if (!__tmp50_last) __out.AppendLine(true);
                        __out.AppendLine(false); //285:54
                    }
                }
            }
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((cls).GetEnumerator()) //287:11
                from op in __Enumerate((__loop24_var1.GetAllOperations()).GetEnumerator()) //287:16
                select new { __loop24_var1 = __loop24_var1, op = op}
                ).ToList(); //287:6
            int __loop24_iteration = 0;
            foreach (var __tmp51 in __loop24_results)
            {
                ++__loop24_iteration;
                var __loop24_var1 = __tmp51.__loop24_var1;
                var op = __tmp51.op;
                __out.AppendLine(true); //288:1
                string __tmp52Prefix = "    "; //289:1
                StringBuilder __tmp53 = new StringBuilder();
                __tmp53.Append(GenerateOperationImpl(model, op));
                using(StreamReader __tmp53Reader = new StreamReader(this.__ToStream(__tmp53.ToString())))
                {
                    bool __tmp53_first = true;
                    bool __tmp53_last = __tmp53Reader.EndOfStream;
                    while(__tmp53_first || !__tmp53_last)
                    {
                        __tmp53_first = false;
                        string __tmp53Line = __tmp53Reader.ReadLine();
                        __tmp53_last = __tmp53Reader.EndOfStream;
                        __out.Append(__tmp52Prefix);
                        if (__tmp53Line != null) __out.Append(__tmp53Line);
                        if (!__tmp53_last) __out.AppendLine(true);
                        __out.AppendLine(false); //289:39
                    }
                }
            }
            __out.Append("}"); //291:1
            __out.AppendLine(false); //291:2
            __out.AppendLine(true); //292:1
            return __out.ToString();
        }

        public string GenerateBuilderInterfaceImpl(MetaModel model, MetaClass cls) //295:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal class "; //296:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.CSharpImplName(ClassKind.Builder));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(__tmp3_first || !__tmp3_last)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    if (!__tmp3_last) __out.AppendLine(true);
                }
            }
            string __tmp4Line = " : global::MetaDslx.Core.Immutable.MutableSymbolBase, "; //296:55
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(cls.CSharpFullName(ClassKind.Builder));
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_first = true;
                bool __tmp5_last = __tmp5Reader.EndOfStream;
                while(__tmp5_first || !__tmp5_last)
                {
                    __tmp5_first = false;
                    string __tmp5Line = __tmp5Reader.ReadLine();
                    __tmp5_last = __tmp5Reader.EndOfStream;
                    if (__tmp5Line != null) __out.Append(__tmp5Line);
                    if (!__tmp5_last) __out.AppendLine(true);
                    __out.AppendLine(false); //296:148
                }
            }
            __out.Append("{"); //297:1
            __out.AppendLine(false); //297:2
            var __loop25_results = 
                (from __loop25_var1 in __Enumerate((cls).GetEnumerator()) //298:11
                from prop in __Enumerate((__loop25_var1.GetAllProperties()).GetEnumerator()) //298:16
                where prop.Type is MetaCollectionType //298:40
                select new { __loop25_var1 = __loop25_var1, prop = prop}
                ).ToList(); //298:6
            int __loop25_iteration = 0;
            foreach (var __tmp6 in __loop25_results)
            {
                ++__loop25_iteration;
                var __loop25_var1 = __tmp6.__loop25_var1;
                var prop = __tmp6.prop;
                string __tmp7Prefix = "    "; //299:1
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(GenerateBuilderField(cls, prop));
                using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                {
                    bool __tmp8_first = true;
                    bool __tmp8_last = __tmp8Reader.EndOfStream;
                    while(__tmp8_first || !__tmp8_last)
                    {
                        __tmp8_first = false;
                        string __tmp8Line = __tmp8Reader.ReadLine();
                        __tmp8_last = __tmp8Reader.EndOfStream;
                        __out.Append(__tmp7Prefix);
                        if (__tmp8Line != null) __out.Append(__tmp8Line);
                        if (!__tmp8_last) __out.AppendLine(true);
                        __out.AppendLine(false); //299:38
                    }
                }
            }
            __out.AppendLine(true); //301:1
            string __tmp10Line = "    internal "; //302:1
            if (__tmp10Line != null) __out.Append(__tmp10Line);
            StringBuilder __tmp11 = new StringBuilder();
            __tmp11.Append(cls.CSharpImplName(ClassKind.Builder));
            using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
            {
                bool __tmp11_first = true;
                bool __tmp11_last = __tmp11Reader.EndOfStream;
                while(__tmp11_first || !__tmp11_last)
                {
                    __tmp11_first = false;
                    string __tmp11Line = __tmp11Reader.ReadLine();
                    __tmp11_last = __tmp11Reader.EndOfStream;
                    if (__tmp11Line != null) __out.Append(__tmp11Line);
                    if (!__tmp11_last) __out.AppendLine(true);
                }
            }
            string __tmp12Line = "(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)"; //302:53
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //302:165
            __out.Append("		: base(id, model, creating)"); //303:1
            __out.AppendLine(false); //303:30
            __out.Append("    {"); //304:1
            __out.AppendLine(false); //304:6
            __out.Append("    }"); //305:1
            __out.AppendLine(false); //305:6
            __out.AppendLine(true); //306:1
            __out.Append("    internal protected override void MInit()"); //307:1
            __out.AppendLine(false); //307:45
            __out.Append("    {"); //308:1
            __out.AppendLine(false); //308:6
            var __loop26_results = 
                (from __loop26_var1 in __Enumerate((cls).GetEnumerator()) //309:9
                from sup in __Enumerate((__loop26_var1.GetAllSuperClasses(false)).GetEnumerator()) //309:14
                select new { __loop26_var1 = __loop26_var1, sup = sup}
                ).ToList(); //309:4
            int __loop26_iteration = 0;
            foreach (var __tmp13 in __loop26_results)
            {
                ++__loop26_iteration;
                var __loop26_var1 = __tmp13.__loop26_var1;
                var sup = __tmp13.sup;
                string __tmp14Prefix = "		"; //310:1
                StringBuilder __tmp15 = new StringBuilder();
                __tmp15.Append(sup.Model.Name);
                using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
                {
                    bool __tmp15_first = true;
                    bool __tmp15_last = __tmp15Reader.EndOfStream;
                    while(__tmp15_first || !__tmp15_last)
                    {
                        __tmp15_first = false;
                        string __tmp15Line = __tmp15Reader.ReadLine();
                        __tmp15_last = __tmp15Reader.EndOfStream;
                        __out.Append(__tmp14Prefix);
                        if (__tmp15Line != null) __out.Append(__tmp15Line);
                        if (!__tmp15_last) __out.AppendLine(true);
                    }
                }
                string __tmp16Line = "ImplementationProvider.Implementation."; //310:19
                if (__tmp16Line != null) __out.Append(__tmp16Line);
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(sup.CSharpName());
                using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
                {
                    bool __tmp17_first = true;
                    bool __tmp17_last = __tmp17Reader.EndOfStream;
                    while(__tmp17_first || !__tmp17_last)
                    {
                        __tmp17_first = false;
                        string __tmp17Line = __tmp17Reader.ReadLine();
                        __tmp17_last = __tmp17Reader.EndOfStream;
                        if (__tmp17Line != null) __out.Append(__tmp17Line);
                        if (!__tmp17_last) __out.AppendLine(true);
                    }
                }
                string __tmp18Line = "(this);"; //310:75
                if (__tmp18Line != null) __out.Append(__tmp18Line);
                __out.AppendLine(false); //310:82
            }
            string __tmp19Prefix = "		"; //312:1
            StringBuilder __tmp20 = new StringBuilder();
            __tmp20.Append(model.Name);
            using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
            {
                bool __tmp20_first = true;
                bool __tmp20_last = __tmp20Reader.EndOfStream;
                while(__tmp20_first || !__tmp20_last)
                {
                    __tmp20_first = false;
                    string __tmp20Line = __tmp20Reader.ReadLine();
                    __tmp20_last = __tmp20Reader.EndOfStream;
                    __out.Append(__tmp19Prefix);
                    if (__tmp20Line != null) __out.Append(__tmp20Line);
                    if (!__tmp20_last) __out.AppendLine(true);
                }
            }
            string __tmp21Line = "ImplementationProvider.Implementation."; //312:15
            if (__tmp21Line != null) __out.Append(__tmp21Line);
            StringBuilder __tmp22 = new StringBuilder();
            __tmp22.Append(cls.CSharpName());
            using(StreamReader __tmp22Reader = new StreamReader(this.__ToStream(__tmp22.ToString())))
            {
                bool __tmp22_first = true;
                bool __tmp22_last = __tmp22Reader.EndOfStream;
                while(__tmp22_first || !__tmp22_last)
                {
                    __tmp22_first = false;
                    string __tmp22Line = __tmp22Reader.ReadLine();
                    __tmp22_last = __tmp22Reader.EndOfStream;
                    if (__tmp22Line != null) __out.Append(__tmp22Line);
                    if (!__tmp22_last) __out.AppendLine(true);
                }
            }
            string __tmp23Line = "(this);"; //312:71
            if (__tmp23Line != null) __out.Append(__tmp23Line);
            __out.AppendLine(false); //312:78
            __out.Append("    }"); //313:1
            __out.AppendLine(false); //313:6
            __out.AppendLine(true); //314:1
            __out.Append("    public override object MMetaModel"); //315:1
            __out.AppendLine(false); //315:38
            __out.Append("    {"); //316:1
            __out.AppendLine(false); //316:6
            string __tmp25Line = "        get { return null;/*"; //317:1
            if (__tmp25Line != null) __out.Append(__tmp25Line);
            StringBuilder __tmp26 = new StringBuilder();
            __tmp26.Append(cls.Model.CSharpFullInstanceName());
            using(StreamReader __tmp26Reader = new StreamReader(this.__ToStream(__tmp26.ToString())))
            {
                bool __tmp26_first = true;
                bool __tmp26_last = __tmp26Reader.EndOfStream;
                while(__tmp26_first || !__tmp26_last)
                {
                    __tmp26_first = false;
                    string __tmp26Line = __tmp26Reader.ReadLine();
                    __tmp26_last = __tmp26Reader.EndOfStream;
                    if (__tmp26Line != null) __out.Append(__tmp26Line);
                    if (!__tmp26_last) __out.AppendLine(true);
                }
            }
            string __tmp27Line = ";*/ }"; //317:65
            if (__tmp27Line != null) __out.Append(__tmp27Line);
            __out.AppendLine(false); //317:70
            __out.Append("    }"); //318:1
            __out.AppendLine(false); //318:6
            __out.AppendLine(true); //319:1
            __out.Append("    public override object MMetaClass"); //320:1
            __out.AppendLine(false); //320:38
            __out.Append("    {"); //321:1
            __out.AppendLine(false); //321:6
            string __tmp29Line = "        get { return null;/*"; //322:1
            if (__tmp29Line != null) __out.Append(__tmp29Line);
            StringBuilder __tmp30 = new StringBuilder();
            __tmp30.Append(cls.CSharpFullInstanceName());
            using(StreamReader __tmp30Reader = new StreamReader(this.__ToStream(__tmp30.ToString())))
            {
                bool __tmp30_first = true;
                bool __tmp30_last = __tmp30Reader.EndOfStream;
                while(__tmp30_first || !__tmp30_last)
                {
                    __tmp30_first = false;
                    string __tmp30Line = __tmp30Reader.ReadLine();
                    __tmp30_last = __tmp30Reader.EndOfStream;
                    if (__tmp30Line != null) __out.Append(__tmp30Line);
                    if (!__tmp30_last) __out.AppendLine(true);
                }
            }
            string __tmp31Line = ";*/ }"; //322:59
            if (__tmp31Line != null) __out.Append(__tmp31Line);
            __out.AppendLine(false); //322:64
            __out.Append("    }"); //323:1
            __out.AppendLine(false); //323:6
            __out.AppendLine(true); //324:1
            string __tmp33Line = "    public new "; //325:1
            if (__tmp33Line != null) __out.Append(__tmp33Line);
            StringBuilder __tmp34 = new StringBuilder();
            __tmp34.Append(cls.CSharpFullName(ClassKind.Immutable));
            using(StreamReader __tmp34Reader = new StreamReader(this.__ToStream(__tmp34.ToString())))
            {
                bool __tmp34_first = true;
                bool __tmp34_last = __tmp34Reader.EndOfStream;
                while(__tmp34_first || !__tmp34_last)
                {
                    __tmp34_first = false;
                    string __tmp34Line = __tmp34Reader.ReadLine();
                    __tmp34_last = __tmp34Reader.EndOfStream;
                    if (__tmp34Line != null) __out.Append(__tmp34Line);
                    if (!__tmp34_last) __out.AppendLine(true);
                }
            }
            string __tmp35Line = " ToImmutable()"; //325:57
            if (__tmp35Line != null) __out.Append(__tmp35Line);
            __out.AppendLine(false); //325:71
            __out.Append("	{"); //326:1
            __out.AppendLine(false); //326:3
            string __tmp37Line = "		return ("; //327:1
            if (__tmp37Line != null) __out.Append(__tmp37Line);
            StringBuilder __tmp38 = new StringBuilder();
            __tmp38.Append(cls.CSharpFullName(ClassKind.Immutable));
            using(StreamReader __tmp38Reader = new StreamReader(this.__ToStream(__tmp38.ToString())))
            {
                bool __tmp38_first = true;
                bool __tmp38_last = __tmp38Reader.EndOfStream;
                while(__tmp38_first || !__tmp38_last)
                {
                    __tmp38_first = false;
                    string __tmp38Line = __tmp38Reader.ReadLine();
                    __tmp38_last = __tmp38Reader.EndOfStream;
                    if (__tmp38Line != null) __out.Append(__tmp38Line);
                    if (!__tmp38_last) __out.AppendLine(true);
                }
            }
            string __tmp39Line = ")base.ToImmutable();"; //327:52
            if (__tmp39Line != null) __out.Append(__tmp39Line);
            __out.AppendLine(false); //327:72
            __out.Append("	}"); //328:1
            __out.AppendLine(false); //328:3
            __out.AppendLine(true); //329:1
            string __tmp41Line = "    public new "; //330:1
            if (__tmp41Line != null) __out.Append(__tmp41Line);
            StringBuilder __tmp42 = new StringBuilder();
            __tmp42.Append(cls.CSharpFullName(ClassKind.Immutable));
            using(StreamReader __tmp42Reader = new StreamReader(this.__ToStream(__tmp42.ToString())))
            {
                bool __tmp42_first = true;
                bool __tmp42_last = __tmp42Reader.EndOfStream;
                while(__tmp42_first || !__tmp42_last)
                {
                    __tmp42_first = false;
                    string __tmp42Line = __tmp42Reader.ReadLine();
                    __tmp42_last = __tmp42Reader.EndOfStream;
                    if (__tmp42Line != null) __out.Append(__tmp42Line);
                    if (!__tmp42_last) __out.AppendLine(true);
                }
            }
            string __tmp43Line = " ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)"; //330:57
            if (__tmp43Line != null) __out.Append(__tmp43Line);
            __out.AppendLine(false); //330:123
            __out.Append("	{"); //331:1
            __out.AppendLine(false); //331:3
            string __tmp45Line = "		return ("; //332:1
            if (__tmp45Line != null) __out.Append(__tmp45Line);
            StringBuilder __tmp46 = new StringBuilder();
            __tmp46.Append(cls.CSharpFullName(ClassKind.Immutable));
            using(StreamReader __tmp46Reader = new StreamReader(this.__ToStream(__tmp46.ToString())))
            {
                bool __tmp46_first = true;
                bool __tmp46_last = __tmp46Reader.EndOfStream;
                while(__tmp46_first || !__tmp46_last)
                {
                    __tmp46_first = false;
                    string __tmp46Line = __tmp46Reader.ReadLine();
                    __tmp46_last = __tmp46Reader.EndOfStream;
                    if (__tmp46Line != null) __out.Append(__tmp46Line);
                    if (!__tmp46_last) __out.AppendLine(true);
                }
            }
            string __tmp47Line = ")base.ToImmutable(model);"; //332:52
            if (__tmp47Line != null) __out.Append(__tmp47Line);
            __out.AppendLine(false); //332:77
            __out.Append("	}"); //333:1
            __out.AppendLine(false); //333:3
            var __loop27_results = 
                (from __loop27_var1 in __Enumerate((cls).GetEnumerator()) //334:8
                from sup in __Enumerate((__loop27_var1.GetAllSuperClasses()).GetEnumerator()) //334:13
                select new { __loop27_var1 = __loop27_var1, sup = sup}
                ).ToList(); //334:3
            int __loop27_iteration = 0;
            foreach (var __tmp48 in __loop27_results)
            {
                ++__loop27_iteration;
                var __loop27_var1 = __tmp48.__loop27_var1;
                var sup = __tmp48.sup;
                __out.AppendLine(true); //335:1
                string __tmp49Prefix = "    "; //336:1
                StringBuilder __tmp50 = new StringBuilder();
                __tmp50.Append(sup.CSharpFullName(ClassKind.Immutable));
                using(StreamReader __tmp50Reader = new StreamReader(this.__ToStream(__tmp50.ToString())))
                {
                    bool __tmp50_first = true;
                    bool __tmp50_last = __tmp50Reader.EndOfStream;
                    while(__tmp50_first || !__tmp50_last)
                    {
                        __tmp50_first = false;
                        string __tmp50Line = __tmp50Reader.ReadLine();
                        __tmp50_last = __tmp50Reader.EndOfStream;
                        __out.Append(__tmp49Prefix);
                        if (__tmp50Line != null) __out.Append(__tmp50Line);
                        if (!__tmp50_last) __out.AppendLine(true);
                    }
                }
                string __tmp51Line = " "; //336:46
                if (__tmp51Line != null) __out.Append(__tmp51Line);
                StringBuilder __tmp52 = new StringBuilder();
                __tmp52.Append(sup.CSharpFullName(ClassKind.Builder));
                using(StreamReader __tmp52Reader = new StreamReader(this.__ToStream(__tmp52.ToString())))
                {
                    bool __tmp52_first = true;
                    bool __tmp52_last = __tmp52Reader.EndOfStream;
                    while(__tmp52_first || !__tmp52_last)
                    {
                        __tmp52_first = false;
                        string __tmp52Line = __tmp52Reader.ReadLine();
                        __tmp52_last = __tmp52Reader.EndOfStream;
                        if (__tmp52Line != null) __out.Append(__tmp52Line);
                        if (!__tmp52_last) __out.AppendLine(true);
                    }
                }
                string __tmp53Line = ".ToImmutable()"; //336:86
                if (__tmp53Line != null) __out.Append(__tmp53Line);
                __out.AppendLine(false); //336:100
                __out.Append("	{"); //337:1
                __out.AppendLine(false); //337:3
                __out.Append("		return this.ToImmutable();"); //338:1
                __out.AppendLine(false); //338:29
                __out.Append("	}"); //339:1
                __out.AppendLine(false); //339:3
                __out.AppendLine(true); //340:1
                string __tmp54Prefix = "    "; //341:1
                StringBuilder __tmp55 = new StringBuilder();
                __tmp55.Append(sup.CSharpFullName(ClassKind.Immutable));
                using(StreamReader __tmp55Reader = new StreamReader(this.__ToStream(__tmp55.ToString())))
                {
                    bool __tmp55_first = true;
                    bool __tmp55_last = __tmp55Reader.EndOfStream;
                    while(__tmp55_first || !__tmp55_last)
                    {
                        __tmp55_first = false;
                        string __tmp55Line = __tmp55Reader.ReadLine();
                        __tmp55_last = __tmp55Reader.EndOfStream;
                        __out.Append(__tmp54Prefix);
                        if (__tmp55Line != null) __out.Append(__tmp55Line);
                        if (!__tmp55_last) __out.AppendLine(true);
                    }
                }
                string __tmp56Line = " "; //341:46
                if (__tmp56Line != null) __out.Append(__tmp56Line);
                StringBuilder __tmp57 = new StringBuilder();
                __tmp57.Append(sup.CSharpFullName(ClassKind.Builder));
                using(StreamReader __tmp57Reader = new StreamReader(this.__ToStream(__tmp57.ToString())))
                {
                    bool __tmp57_first = true;
                    bool __tmp57_last = __tmp57Reader.EndOfStream;
                    while(__tmp57_first || !__tmp57_last)
                    {
                        __tmp57_first = false;
                        string __tmp57Line = __tmp57Reader.ReadLine();
                        __tmp57_last = __tmp57Reader.EndOfStream;
                        if (__tmp57Line != null) __out.Append(__tmp57Line);
                        if (!__tmp57_last) __out.AppendLine(true);
                    }
                }
                string __tmp58Line = ".ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)"; //341:86
                if (__tmp58Line != null) __out.Append(__tmp58Line);
                __out.AppendLine(false); //341:152
                __out.Append("	{"); //342:1
                __out.AppendLine(false); //342:3
                __out.Append("		return this.ToImmutable(model);"); //343:1
                __out.AppendLine(false); //343:34
                __out.Append("	}"); //344:1
                __out.AppendLine(false); //344:3
            }
            var __loop28_results = 
                (from __loop28_var1 in __Enumerate((cls).GetEnumerator()) //346:11
                from prop in __Enumerate((__loop28_var1.GetAllProperties()).GetEnumerator()) //346:16
                select new { __loop28_var1 = __loop28_var1, prop = prop}
                ).ToList(); //346:6
            int __loop28_iteration = 0;
            foreach (var __tmp59 in __loop28_results)
            {
                ++__loop28_iteration;
                var __loop28_var1 = __tmp59.__loop28_var1;
                var prop = __tmp59.prop;
                __out.AppendLine(true); //347:1
                string __tmp60Prefix = "    "; //348:1
                StringBuilder __tmp61 = new StringBuilder();
                __tmp61.Append(GenerateBuilderPropertyImpl(model, cls, prop));
                using(StreamReader __tmp61Reader = new StreamReader(this.__ToStream(__tmp61.ToString())))
                {
                    bool __tmp61_first = true;
                    bool __tmp61_last = __tmp61Reader.EndOfStream;
                    while(__tmp61_first || !__tmp61_last)
                    {
                        __tmp61_first = false;
                        string __tmp61Line = __tmp61Reader.ReadLine();
                        __tmp61_last = __tmp61Reader.EndOfStream;
                        __out.Append(__tmp60Prefix);
                        if (__tmp61Line != null) __out.Append(__tmp61Line);
                        if (!__tmp61_last) __out.AppendLine(true);
                        __out.AppendLine(false); //348:52
                    }
                }
            }
            __out.Append("}"); //350:1
            __out.AppendLine(false); //350:2
            __out.AppendLine(true); //351:1
            return __out.ToString();
        }

        public string GeneratePropertyDeclaration(MetaModel model, MetaClass cls, MetaProperty prop) //354:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class == cls) //355:2
            {
                StringBuilder __tmp2 = new StringBuilder();
                __tmp2.Append(GenerateAnnotations(prop));
                using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
                {
                    bool __tmp2_first = true;
                    bool __tmp2_last = __tmp2Reader.EndOfStream;
                    while(__tmp2_first || !__tmp2_last)
                    {
                        __tmp2_first = false;
                        string __tmp2Line = __tmp2Reader.ReadLine();
                        __tmp2_last = __tmp2Reader.EndOfStream;
                        if (__tmp2Line != null) __out.Append(__tmp2Line);
                        if (!__tmp2_last) __out.AppendLine(true);
                        __out.AppendLine(false); //356:28
                    }
                }
                if (prop.Kind == MetaPropertyKind.Containment) //357:2
                {
                    StringBuilder __tmp4 = new StringBuilder();
                    __tmp4.Append("[ContainmentAttribute]");
                    using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                    {
                        bool __tmp4_first = true;
                        bool __tmp4_last = __tmp4Reader.EndOfStream;
                        while(__tmp4_first || !__tmp4_last)
                        {
                            __tmp4_first = false;
                            string __tmp4Line = __tmp4Reader.ReadLine();
                            __tmp4_last = __tmp4Reader.EndOfStream;
                            if (__tmp4Line != null) __out.Append(__tmp4Line);
                            if (!__tmp4_last) __out.AppendLine(true);
                            __out.AppendLine(false); //358:27
                        }
                    }
                }
                if (prop.Kind != MetaPropertyKind.Normal && prop.Kind != MetaPropertyKind.Containment) //360:2
                {
                    StringBuilder __tmp6 = new StringBuilder();
                    __tmp6.Append("[ReadonlyAttribute]");
                    using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
                    {
                        bool __tmp6_first = true;
                        bool __tmp6_last = __tmp6Reader.EndOfStream;
                        while(__tmp6_first || !__tmp6_last)
                        {
                            __tmp6_first = false;
                            string __tmp6Line = __tmp6Reader.ReadLine();
                            __tmp6_last = __tmp6Reader.EndOfStream;
                            if (__tmp6Line != null) __out.Append(__tmp6Line);
                            if (!__tmp6_last) __out.AppendLine(true);
                            __out.AppendLine(false); //361:24
                        }
                    }
                }
                var __loop29_results = 
                    (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //363:7
                    select new { p = p}
                    ).ToList(); //363:2
                int __loop29_iteration = 0;
                foreach (var __tmp7 in __loop29_results)
                {
                    ++__loop29_iteration;
                    var p = __tmp7.p;
                    StringBuilder __tmp9 = new StringBuilder();
                    __tmp9.Append("[OppositeAttribute(typeof(");
                    using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                    {
                        bool __tmp9_first = true;
                        bool __tmp9_last = __tmp9Reader.EndOfStream;
                        while(__tmp9_first || !__tmp9_last)
                        {
                            __tmp9_first = false;
                            string __tmp9Line = __tmp9Reader.ReadLine();
                            __tmp9_last = __tmp9Reader.EndOfStream;
                            if (__tmp9Line != null) __out.Append(__tmp9Line);
                            if (!__tmp9_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp10 = new StringBuilder();
                    __tmp10.Append(p.Class.CSharpFullDescriptorName(ClassKind.Immutable));
                    using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
                    {
                        bool __tmp10_first = true;
                        bool __tmp10_last = __tmp10Reader.EndOfStream;
                        while(__tmp10_first || !__tmp10_last)
                        {
                            __tmp10_first = false;
                            string __tmp10Line = __tmp10Reader.ReadLine();
                            __tmp10_last = __tmp10Reader.EndOfStream;
                            if (__tmp10Line != null) __out.Append(__tmp10Line);
                            if (!__tmp10_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp11 = new StringBuilder();
                    __tmp11.Append("), \"");
                    using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                    {
                        bool __tmp11_first = true;
                        bool __tmp11_last = __tmp11Reader.EndOfStream;
                        while(__tmp11_first || !__tmp11_last)
                        {
                            __tmp11_first = false;
                            string __tmp11Line = __tmp11Reader.ReadLine();
                            __tmp11_last = __tmp11Reader.EndOfStream;
                            if (__tmp11Line != null) __out.Append(__tmp11Line);
                            if (!__tmp11_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp12 = new StringBuilder();
                    __tmp12.Append(p.Name);
                    using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
                    {
                        bool __tmp12_first = true;
                        bool __tmp12_last = __tmp12Reader.EndOfStream;
                        while(__tmp12_first || !__tmp12_last)
                        {
                            __tmp12_first = false;
                            string __tmp12Line = __tmp12Reader.ReadLine();
                            __tmp12_last = __tmp12Reader.EndOfStream;
                            if (__tmp12Line != null) __out.Append(__tmp12Line);
                            if (!__tmp12_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp13 = new StringBuilder();
                    __tmp13.Append("\")]");
                    using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                    {
                        bool __tmp13_first = true;
                        bool __tmp13_last = __tmp13Reader.EndOfStream;
                        while(__tmp13_first || !__tmp13_last)
                        {
                            __tmp13_first = false;
                            string __tmp13Line = __tmp13Reader.ReadLine();
                            __tmp13_last = __tmp13Reader.EndOfStream;
                            if (__tmp13Line != null) __out.Append(__tmp13Line);
                            if (!__tmp13_last) __out.AppendLine(true);
                            __out.AppendLine(false); //364:111
                        }
                    }
                }
                var __loop30_results = 
                    (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //366:7
                    select new { p = p}
                    ).ToList(); //366:2
                int __loop30_iteration = 0;
                foreach (var __tmp14 in __loop30_results)
                {
                    ++__loop30_iteration;
                    var p = __tmp14.p;
                    if (cls.GetAllSuperClasses(true).Contains(p.Class)) //367:3
                    {
                        StringBuilder __tmp16 = new StringBuilder();
                        __tmp16.Append("[SubsetsAttribute(typeof(");
                        using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
                        {
                            bool __tmp16_first = true;
                            bool __tmp16_last = __tmp16Reader.EndOfStream;
                            while(__tmp16_first || !__tmp16_last)
                            {
                                __tmp16_first = false;
                                string __tmp16Line = __tmp16Reader.ReadLine();
                                __tmp16_last = __tmp16Reader.EndOfStream;
                                if (__tmp16Line != null) __out.Append(__tmp16Line);
                                if (!__tmp16_last) __out.AppendLine(true);
                            }
                        }
                        StringBuilder __tmp17 = new StringBuilder();
                        __tmp17.Append(p.Class.CSharpFullDescriptorName(ClassKind.Immutable));
                        using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
                        {
                            bool __tmp17_first = true;
                            bool __tmp17_last = __tmp17Reader.EndOfStream;
                            while(__tmp17_first || !__tmp17_last)
                            {
                                __tmp17_first = false;
                                string __tmp17Line = __tmp17Reader.ReadLine();
                                __tmp17_last = __tmp17Reader.EndOfStream;
                                if (__tmp17Line != null) __out.Append(__tmp17Line);
                                if (!__tmp17_last) __out.AppendLine(true);
                            }
                        }
                        StringBuilder __tmp18 = new StringBuilder();
                        __tmp18.Append("), \"");
                        using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
                        {
                            bool __tmp18_first = true;
                            bool __tmp18_last = __tmp18Reader.EndOfStream;
                            while(__tmp18_first || !__tmp18_last)
                            {
                                __tmp18_first = false;
                                string __tmp18Line = __tmp18Reader.ReadLine();
                                __tmp18_last = __tmp18Reader.EndOfStream;
                                if (__tmp18Line != null) __out.Append(__tmp18Line);
                                if (!__tmp18_last) __out.AppendLine(true);
                            }
                        }
                        StringBuilder __tmp19 = new StringBuilder();
                        __tmp19.Append(p.Name);
                        using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
                        {
                            bool __tmp19_first = true;
                            bool __tmp19_last = __tmp19Reader.EndOfStream;
                            while(__tmp19_first || !__tmp19_last)
                            {
                                __tmp19_first = false;
                                string __tmp19Line = __tmp19Reader.ReadLine();
                                __tmp19_last = __tmp19Reader.EndOfStream;
                                if (__tmp19Line != null) __out.Append(__tmp19Line);
                                if (!__tmp19_last) __out.AppendLine(true);
                            }
                        }
                        StringBuilder __tmp20 = new StringBuilder();
                        __tmp20.Append("\")]");
                        using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
                        {
                            bool __tmp20_first = true;
                            bool __tmp20_last = __tmp20Reader.EndOfStream;
                            while(__tmp20_first || !__tmp20_last)
                            {
                                __tmp20_first = false;
                                string __tmp20Line = __tmp20Reader.ReadLine();
                                __tmp20_last = __tmp20Reader.EndOfStream;
                                if (__tmp20Line != null) __out.Append(__tmp20Line);
                                if (!__tmp20_last) __out.AppendLine(true);
                                __out.AppendLine(false); //368:110
                            }
                        }
                    }
                    else //369:3
                    {
                        string __tmp22Line = "// ERROR: subsetted property '"; //370:1
                        if (__tmp22Line != null) __out.Append(__tmp22Line);
                        StringBuilder __tmp23 = new StringBuilder();
                        __tmp23.Append(p.CSharpFullDescriptorName(ClassKind.Immutable));
                        using(StreamReader __tmp23Reader = new StreamReader(this.__ToStream(__tmp23.ToString())))
                        {
                            bool __tmp23_first = true;
                            bool __tmp23_last = __tmp23Reader.EndOfStream;
                            while(__tmp23_first || !__tmp23_last)
                            {
                                __tmp23_first = false;
                                string __tmp23Line = __tmp23Reader.ReadLine();
                                __tmp23_last = __tmp23Reader.EndOfStream;
                                if (__tmp23Line != null) __out.Append(__tmp23Line);
                                if (!__tmp23_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp24Line = "' must be a property of an ancestor class"; //370:80
                        if (__tmp24Line != null) __out.Append(__tmp24Line);
                        __out.AppendLine(false); //370:121
                    }
                }
                var __loop31_results = 
                    (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //373:7
                    select new { p = p}
                    ).ToList(); //373:2
                int __loop31_iteration = 0;
                foreach (var __tmp25 in __loop31_results)
                {
                    ++__loop31_iteration;
                    var p = __tmp25.p;
                    if (cls.GetAllSuperClasses(true).Contains(p.Class)) //374:3
                    {
                        StringBuilder __tmp27 = new StringBuilder();
                        __tmp27.Append("[RedefinesAttribute(typeof(");
                        using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
                        {
                            bool __tmp27_first = true;
                            bool __tmp27_last = __tmp27Reader.EndOfStream;
                            while(__tmp27_first || !__tmp27_last)
                            {
                                __tmp27_first = false;
                                string __tmp27Line = __tmp27Reader.ReadLine();
                                __tmp27_last = __tmp27Reader.EndOfStream;
                                if (__tmp27Line != null) __out.Append(__tmp27Line);
                                if (!__tmp27_last) __out.AppendLine(true);
                            }
                        }
                        StringBuilder __tmp28 = new StringBuilder();
                        __tmp28.Append(p.Class.CSharpFullDescriptorName(ClassKind.Immutable));
                        using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
                        {
                            bool __tmp28_first = true;
                            bool __tmp28_last = __tmp28Reader.EndOfStream;
                            while(__tmp28_first || !__tmp28_last)
                            {
                                __tmp28_first = false;
                                string __tmp28Line = __tmp28Reader.ReadLine();
                                __tmp28_last = __tmp28Reader.EndOfStream;
                                if (__tmp28Line != null) __out.Append(__tmp28Line);
                                if (!__tmp28_last) __out.AppendLine(true);
                            }
                        }
                        StringBuilder __tmp29 = new StringBuilder();
                        __tmp29.Append("), \"");
                        using(StreamReader __tmp29Reader = new StreamReader(this.__ToStream(__tmp29.ToString())))
                        {
                            bool __tmp29_first = true;
                            bool __tmp29_last = __tmp29Reader.EndOfStream;
                            while(__tmp29_first || !__tmp29_last)
                            {
                                __tmp29_first = false;
                                string __tmp29Line = __tmp29Reader.ReadLine();
                                __tmp29_last = __tmp29Reader.EndOfStream;
                                if (__tmp29Line != null) __out.Append(__tmp29Line);
                                if (!__tmp29_last) __out.AppendLine(true);
                            }
                        }
                        StringBuilder __tmp30 = new StringBuilder();
                        __tmp30.Append(p.Name);
                        using(StreamReader __tmp30Reader = new StreamReader(this.__ToStream(__tmp30.ToString())))
                        {
                            bool __tmp30_first = true;
                            bool __tmp30_last = __tmp30Reader.EndOfStream;
                            while(__tmp30_first || !__tmp30_last)
                            {
                                __tmp30_first = false;
                                string __tmp30Line = __tmp30Reader.ReadLine();
                                __tmp30_last = __tmp30Reader.EndOfStream;
                                if (__tmp30Line != null) __out.Append(__tmp30Line);
                                if (!__tmp30_last) __out.AppendLine(true);
                            }
                        }
                        StringBuilder __tmp31 = new StringBuilder();
                        __tmp31.Append("\")]");
                        using(StreamReader __tmp31Reader = new StreamReader(this.__ToStream(__tmp31.ToString())))
                        {
                            bool __tmp31_first = true;
                            bool __tmp31_last = __tmp31Reader.EndOfStream;
                            while(__tmp31_first || !__tmp31_last)
                            {
                                __tmp31_first = false;
                                string __tmp31Line = __tmp31Reader.ReadLine();
                                __tmp31_last = __tmp31Reader.EndOfStream;
                                if (__tmp31Line != null) __out.Append(__tmp31Line);
                                if (!__tmp31_last) __out.AppendLine(true);
                                __out.AppendLine(false); //375:112
                            }
                        }
                    }
                    else //376:3
                    {
                        string __tmp33Line = "// ERROR: redefined property '"; //377:1
                        if (__tmp33Line != null) __out.Append(__tmp33Line);
                        StringBuilder __tmp34 = new StringBuilder();
                        __tmp34.Append(p.CSharpFullDescriptorName(ClassKind.Immutable));
                        using(StreamReader __tmp34Reader = new StreamReader(this.__ToStream(__tmp34.ToString())))
                        {
                            bool __tmp34_first = true;
                            bool __tmp34_last = __tmp34Reader.EndOfStream;
                            while(__tmp34_first || !__tmp34_last)
                            {
                                __tmp34_first = false;
                                string __tmp34Line = __tmp34Reader.ReadLine();
                                __tmp34_last = __tmp34Reader.EndOfStream;
                                if (__tmp34Line != null) __out.Append(__tmp34Line);
                                if (!__tmp34_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp35Line = "' must be a property of an ancestor class"; //377:80
                        if (__tmp35Line != null) __out.Append(__tmp35Line);
                        __out.AppendLine(false); //377:121
                    }
                }
                if (prop.Type is MetaCollectionType) //380:2
                {
                    MetaCollectionType collType = (MetaCollectionType)prop.Type; //381:3
                    string __tmp37Line = "public static readonly global::MetaDslx.Core.Immutable.ModelProperty "; //382:1
                    if (__tmp37Line != null) __out.Append(__tmp37Line);
                    StringBuilder __tmp38 = new StringBuilder();
                    __tmp38.Append(prop.Name);
                    using(StreamReader __tmp38Reader = new StreamReader(this.__ToStream(__tmp38.ToString())))
                    {
                        bool __tmp38_first = true;
                        bool __tmp38_last = __tmp38Reader.EndOfStream;
                        while(__tmp38_first || !__tmp38_last)
                        {
                            __tmp38_first = false;
                            string __tmp38Line = __tmp38Reader.ReadLine();
                            __tmp38_last = __tmp38Reader.EndOfStream;
                            if (__tmp38Line != null) __out.Append(__tmp38Line);
                            if (!__tmp38_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp39Line = "Property ="; //382:81
                    if (__tmp39Line != null) __out.Append(__tmp39Line);
                    __out.AppendLine(false); //382:91
                    string __tmp41Line = "    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof("; //383:1
                    if (__tmp41Line != null) __out.Append(__tmp41Line);
                    StringBuilder __tmp42 = new StringBuilder();
                    __tmp42.Append(prop.Class.Model.CSharpDescriptorName());
                    using(StreamReader __tmp42Reader = new StreamReader(this.__ToStream(__tmp42.ToString())))
                    {
                        bool __tmp42_first = true;
                        bool __tmp42_last = __tmp42Reader.EndOfStream;
                        while(__tmp42_first || !__tmp42_last)
                        {
                            __tmp42_first = false;
                            string __tmp42Line = __tmp42Reader.ReadLine();
                            __tmp42_last = __tmp42Reader.EndOfStream;
                            if (__tmp42Line != null) __out.Append(__tmp42Line);
                            if (!__tmp42_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp43Line = "."; //383:108
                    if (__tmp43Line != null) __out.Append(__tmp43Line);
                    StringBuilder __tmp44 = new StringBuilder();
                    __tmp44.Append(prop.Class.CSharpName());
                    using(StreamReader __tmp44Reader = new StreamReader(this.__ToStream(__tmp44.ToString())))
                    {
                        bool __tmp44_first = true;
                        bool __tmp44_last = __tmp44Reader.EndOfStream;
                        while(__tmp44_first || !__tmp44_last)
                        {
                            __tmp44_first = false;
                            string __tmp44Line = __tmp44Reader.ReadLine();
                            __tmp44_last = __tmp44Reader.EndOfStream;
                            if (__tmp44Line != null) __out.Append(__tmp44Line);
                            if (!__tmp44_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp45Line = "), \""; //383:134
                    if (__tmp45Line != null) __out.Append(__tmp45Line);
                    StringBuilder __tmp46 = new StringBuilder();
                    __tmp46.Append(prop.Name);
                    using(StreamReader __tmp46Reader = new StreamReader(this.__ToStream(__tmp46.ToString())))
                    {
                        bool __tmp46_first = true;
                        bool __tmp46_last = __tmp46Reader.EndOfStream;
                        while(__tmp46_first || !__tmp46_last)
                        {
                            __tmp46_first = false;
                            string __tmp46Line = __tmp46Reader.ReadLine();
                            __tmp46_last = __tmp46Reader.EndOfStream;
                            if (__tmp46Line != null) __out.Append(__tmp46Line);
                            if (!__tmp46_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp47Line = "\","; //383:149
                    if (__tmp47Line != null) __out.Append(__tmp47Line);
                    __out.AppendLine(false); //383:151
                    string __tmp49Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //384:1
                    if (__tmp49Line != null) __out.Append(__tmp49Line);
                    StringBuilder __tmp50 = new StringBuilder();
                    __tmp50.Append(collType.InnerType.CSharpFullPublicName(ClassKind.Immutable));
                    using(StreamReader __tmp50Reader = new StreamReader(this.__ToStream(__tmp50.ToString())))
                    {
                        bool __tmp50_first = true;
                        bool __tmp50_last = __tmp50Reader.EndOfStream;
                        while(__tmp50_first || !__tmp50_last)
                        {
                            __tmp50_first = false;
                            string __tmp50Line = __tmp50Reader.ReadLine();
                            __tmp50_last = __tmp50Reader.EndOfStream;
                            if (__tmp50Line != null) __out.Append(__tmp50Line);
                            if (!__tmp50_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp51Line = "), typeof("; //384:136
                    if (__tmp51Line != null) __out.Append(__tmp51Line);
                    StringBuilder __tmp52 = new StringBuilder();
                    __tmp52.Append(prop.Type.CSharpFullPublicName(ClassKind.Immutable));
                    using(StreamReader __tmp52Reader = new StreamReader(this.__ToStream(__tmp52.ToString())))
                    {
                        bool __tmp52_first = true;
                        bool __tmp52_last = __tmp52Reader.EndOfStream;
                        while(__tmp52_first || !__tmp52_last)
                        {
                            __tmp52_first = false;
                            string __tmp52Line = __tmp52Reader.ReadLine();
                            __tmp52_last = __tmp52Reader.EndOfStream;
                            if (__tmp52Line != null) __out.Append(__tmp52Line);
                            if (!__tmp52_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp53Line = ")),"; //384:199
                    if (__tmp53Line != null) __out.Append(__tmp53Line);
                    __out.AppendLine(false); //384:202
                    string __tmp55Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //385:1
                    if (__tmp55Line != null) __out.Append(__tmp55Line);
                    StringBuilder __tmp56 = new StringBuilder();
                    __tmp56.Append(collType.InnerType.CSharpFullPublicName(ClassKind.Builder));
                    using(StreamReader __tmp56Reader = new StreamReader(this.__ToStream(__tmp56.ToString())))
                    {
                        bool __tmp56_first = true;
                        bool __tmp56_last = __tmp56Reader.EndOfStream;
                        while(__tmp56_first || !__tmp56_last)
                        {
                            __tmp56_first = false;
                            string __tmp56Line = __tmp56Reader.ReadLine();
                            __tmp56_last = __tmp56Reader.EndOfStream;
                            if (__tmp56Line != null) __out.Append(__tmp56Line);
                            if (!__tmp56_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp57Line = "), typeof("; //385:134
                    if (__tmp57Line != null) __out.Append(__tmp57Line);
                    StringBuilder __tmp58 = new StringBuilder();
                    __tmp58.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                    using(StreamReader __tmp58Reader = new StreamReader(this.__ToStream(__tmp58.ToString())))
                    {
                        bool __tmp58_first = true;
                        bool __tmp58_last = __tmp58Reader.EndOfStream;
                        while(__tmp58_first || !__tmp58_last)
                        {
                            __tmp58_first = false;
                            string __tmp58Line = __tmp58Reader.ReadLine();
                            __tmp58_last = __tmp58Reader.EndOfStream;
                            if (__tmp58Line != null) __out.Append(__tmp58Line);
                            if (!__tmp58_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp59Line = ")));"; //385:195
                    if (__tmp59Line != null) __out.Append(__tmp59Line);
                    __out.AppendLine(false); //385:199
                }
                else //386:2
                {
                    string __tmp61Line = "public static readonly global::MetaDslx.Core.Immutable.ModelProperty "; //387:1
                    if (__tmp61Line != null) __out.Append(__tmp61Line);
                    StringBuilder __tmp62 = new StringBuilder();
                    __tmp62.Append(prop.Name);
                    using(StreamReader __tmp62Reader = new StreamReader(this.__ToStream(__tmp62.ToString())))
                    {
                        bool __tmp62_first = true;
                        bool __tmp62_last = __tmp62Reader.EndOfStream;
                        while(__tmp62_first || !__tmp62_last)
                        {
                            __tmp62_first = false;
                            string __tmp62Line = __tmp62Reader.ReadLine();
                            __tmp62_last = __tmp62Reader.EndOfStream;
                            if (__tmp62Line != null) __out.Append(__tmp62Line);
                            if (!__tmp62_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp63Line = "Property ="; //387:81
                    if (__tmp63Line != null) __out.Append(__tmp63Line);
                    __out.AppendLine(false); //387:91
                    string __tmp65Line = "    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof("; //388:1
                    if (__tmp65Line != null) __out.Append(__tmp65Line);
                    StringBuilder __tmp66 = new StringBuilder();
                    __tmp66.Append(prop.Class.Model.CSharpDescriptorName());
                    using(StreamReader __tmp66Reader = new StreamReader(this.__ToStream(__tmp66.ToString())))
                    {
                        bool __tmp66_first = true;
                        bool __tmp66_last = __tmp66Reader.EndOfStream;
                        while(__tmp66_first || !__tmp66_last)
                        {
                            __tmp66_first = false;
                            string __tmp66Line = __tmp66Reader.ReadLine();
                            __tmp66_last = __tmp66Reader.EndOfStream;
                            if (__tmp66Line != null) __out.Append(__tmp66Line);
                            if (!__tmp66_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp67Line = "."; //388:108
                    if (__tmp67Line != null) __out.Append(__tmp67Line);
                    StringBuilder __tmp68 = new StringBuilder();
                    __tmp68.Append(prop.Class.CSharpName());
                    using(StreamReader __tmp68Reader = new StreamReader(this.__ToStream(__tmp68.ToString())))
                    {
                        bool __tmp68_first = true;
                        bool __tmp68_last = __tmp68Reader.EndOfStream;
                        while(__tmp68_first || !__tmp68_last)
                        {
                            __tmp68_first = false;
                            string __tmp68Line = __tmp68Reader.ReadLine();
                            __tmp68_last = __tmp68Reader.EndOfStream;
                            if (__tmp68Line != null) __out.Append(__tmp68Line);
                            if (!__tmp68_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp69Line = "), \""; //388:134
                    if (__tmp69Line != null) __out.Append(__tmp69Line);
                    StringBuilder __tmp70 = new StringBuilder();
                    __tmp70.Append(prop.Name);
                    using(StreamReader __tmp70Reader = new StreamReader(this.__ToStream(__tmp70.ToString())))
                    {
                        bool __tmp70_first = true;
                        bool __tmp70_last = __tmp70Reader.EndOfStream;
                        while(__tmp70_first || !__tmp70_last)
                        {
                            __tmp70_first = false;
                            string __tmp70Line = __tmp70Reader.ReadLine();
                            __tmp70_last = __tmp70Reader.EndOfStream;
                            if (__tmp70Line != null) __out.Append(__tmp70Line);
                            if (!__tmp70_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp71Line = "\","; //388:149
                    if (__tmp71Line != null) __out.Append(__tmp71Line);
                    __out.AppendLine(false); //388:151
                    string __tmp73Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //389:1
                    if (__tmp73Line != null) __out.Append(__tmp73Line);
                    StringBuilder __tmp74 = new StringBuilder();
                    __tmp74.Append(prop.Type.CSharpFullPublicName(ClassKind.Immutable));
                    using(StreamReader __tmp74Reader = new StreamReader(this.__ToStream(__tmp74.ToString())))
                    {
                        bool __tmp74_first = true;
                        bool __tmp74_last = __tmp74Reader.EndOfStream;
                        while(__tmp74_first || !__tmp74_last)
                        {
                            __tmp74_first = false;
                            string __tmp74Line = __tmp74Reader.ReadLine();
                            __tmp74_last = __tmp74Reader.EndOfStream;
                            if (__tmp74Line != null) __out.Append(__tmp74Line);
                            if (!__tmp74_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp75Line = "), null),"; //389:127
                    if (__tmp75Line != null) __out.Append(__tmp75Line);
                    __out.AppendLine(false); //389:136
                    string __tmp77Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //390:1
                    if (__tmp77Line != null) __out.Append(__tmp77Line);
                    StringBuilder __tmp78 = new StringBuilder();
                    __tmp78.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                    using(StreamReader __tmp78Reader = new StreamReader(this.__ToStream(__tmp78.ToString())))
                    {
                        bool __tmp78_first = true;
                        bool __tmp78_last = __tmp78Reader.EndOfStream;
                        while(__tmp78_first || !__tmp78_last)
                        {
                            __tmp78_first = false;
                            string __tmp78Line = __tmp78Reader.ReadLine();
                            __tmp78_last = __tmp78Reader.EndOfStream;
                            if (__tmp78Line != null) __out.Append(__tmp78Line);
                            if (!__tmp78_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp79Line = "), null));"; //390:125
                    if (__tmp79Line != null) __out.Append(__tmp79Line);
                    __out.AppendLine(false); //390:135
                }
            }
            __out.AppendLine(true); //393:1
            return __out.ToString();
        }

        public string GenerateImmutablePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //396:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //397:1
            if (cls.GetAllFinalProperties().Contains(prop)) //398:2
            {
                string __tmp2Line = "public "; //399:1
                if (__tmp2Line != null) __out.Append(__tmp2Line);
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(prop.Type.CSharpFullPublicName(ClassKind.Immutable));
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_first = true;
                    bool __tmp3_last = __tmp3Reader.EndOfStream;
                    while(__tmp3_first || !__tmp3_last)
                    {
                        __tmp3_first = false;
                        string __tmp3Line = __tmp3Reader.ReadLine();
                        __tmp3_last = __tmp3Reader.EndOfStream;
                        if (__tmp3Line != null) __out.Append(__tmp3Line);
                        if (!__tmp3_last) __out.AppendLine(true);
                    }
                }
                string __tmp4Line = " "; //399:61
                if (__tmp4Line != null) __out.Append(__tmp4Line);
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(prop.Name);
                using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                {
                    bool __tmp5_first = true;
                    bool __tmp5_last = __tmp5Reader.EndOfStream;
                    while(__tmp5_first || !__tmp5_last)
                    {
                        __tmp5_first = false;
                        string __tmp5Line = __tmp5Reader.ReadLine();
                        __tmp5_last = __tmp5Reader.EndOfStream;
                        if (__tmp5Line != null) __out.Append(__tmp5Line);
                        if (!__tmp5_last) __out.AppendLine(true);
                        __out.AppendLine(false); //399:73
                    }
                }
            }
            else //400:2
            {
                StringBuilder __tmp7 = new StringBuilder();
                __tmp7.Append("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
                using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
                {
                    bool __tmp7_first = true;
                    bool __tmp7_last = __tmp7Reader.EndOfStream;
                    while(__tmp7_first || !__tmp7_last)
                    {
                        __tmp7_first = false;
                        string __tmp7Line = __tmp7Reader.ReadLine();
                        __tmp7_last = __tmp7Reader.EndOfStream;
                        if (__tmp7Line != null) __out.Append(__tmp7Line);
                        if (!__tmp7_last) __out.AppendLine(true);
                        __out.AppendLine(false); //401:54
                    }
                }
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append(prop.Type.CSharpFullPublicName(ClassKind.Immutable));
                using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                {
                    bool __tmp9_first = true;
                    bool __tmp9_last = __tmp9Reader.EndOfStream;
                    while(__tmp9_first || !__tmp9_last)
                    {
                        __tmp9_first = false;
                        string __tmp9Line = __tmp9Reader.ReadLine();
                        __tmp9_last = __tmp9Reader.EndOfStream;
                        if (__tmp9Line != null) __out.Append(__tmp9Line);
                        if (!__tmp9_last) __out.AppendLine(true);
                    }
                }
                string __tmp10Line = " "; //402:54
                if (__tmp10Line != null) __out.Append(__tmp10Line);
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(prop.Class.CSharpFullName(ClassKind.Immutable));
                using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                {
                    bool __tmp11_first = true;
                    bool __tmp11_last = __tmp11Reader.EndOfStream;
                    while(__tmp11_first || !__tmp11_last)
                    {
                        __tmp11_first = false;
                        string __tmp11Line = __tmp11Reader.ReadLine();
                        __tmp11_last = __tmp11Reader.EndOfStream;
                        if (__tmp11Line != null) __out.Append(__tmp11Line);
                        if (!__tmp11_last) __out.AppendLine(true);
                    }
                }
                string __tmp12Line = "."; //402:103
                if (__tmp12Line != null) __out.Append(__tmp12Line);
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(prop.Name);
                using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                {
                    bool __tmp13_first = true;
                    bool __tmp13_last = __tmp13Reader.EndOfStream;
                    while(__tmp13_first || !__tmp13_last)
                    {
                        __tmp13_first = false;
                        string __tmp13Line = __tmp13Reader.ReadLine();
                        __tmp13_last = __tmp13Reader.EndOfStream;
                        if (__tmp13Line != null) __out.Append(__tmp13Line);
                        if (!__tmp13_last) __out.AppendLine(true);
                        __out.AppendLine(false); //402:115
                    }
                }
            }
            __out.Append("{"); //404:1
            __out.AppendLine(false); //404:2
            if (prop.Type is MetaCollectionType) //405:6
            {
                string __tmp15Line = "    get { return this.GetList<"; //406:1
                if (__tmp15Line != null) __out.Append(__tmp15Line);
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(((MetaCollectionType)prop.Type).InnerType.CSharpFullPublicName(ClassKind.Immutable));
                using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
                {
                    bool __tmp16_first = true;
                    bool __tmp16_last = __tmp16Reader.EndOfStream;
                    while(__tmp16_first || !__tmp16_last)
                    {
                        __tmp16_first = false;
                        string __tmp16Line = __tmp16Reader.ReadLine();
                        __tmp16_last = __tmp16Reader.EndOfStream;
                        if (__tmp16Line != null) __out.Append(__tmp16Line);
                        if (!__tmp16_last) __out.AppendLine(true);
                    }
                }
                string __tmp17Line = ">("; //406:116
                if (__tmp17Line != null) __out.Append(__tmp17Line);
                StringBuilder __tmp18 = new StringBuilder();
                __tmp18.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
                {
                    bool __tmp18_first = true;
                    bool __tmp18_last = __tmp18Reader.EndOfStream;
                    while(__tmp18_first || !__tmp18_last)
                    {
                        __tmp18_first = false;
                        string __tmp18Line = __tmp18Reader.ReadLine();
                        __tmp18_last = __tmp18Reader.EndOfStream;
                        if (__tmp18Line != null) __out.Append(__tmp18Line);
                        if (!__tmp18_last) __out.AppendLine(true);
                    }
                }
                string __tmp19Line = ", ref "; //406:170
                if (__tmp19Line != null) __out.Append(__tmp19Line);
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(prop.GetFieldName(cls));
                using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
                {
                    bool __tmp20_first = true;
                    bool __tmp20_last = __tmp20Reader.EndOfStream;
                    while(__tmp20_first || !__tmp20_last)
                    {
                        __tmp20_first = false;
                        string __tmp20Line = __tmp20Reader.ReadLine();
                        __tmp20_last = __tmp20Reader.EndOfStream;
                        if (__tmp20Line != null) __out.Append(__tmp20Line);
                        if (!__tmp20_last) __out.AppendLine(true);
                    }
                }
                string __tmp21Line = "); }"; //406:200
                if (__tmp21Line != null) __out.Append(__tmp21Line);
                __out.AppendLine(false); //406:204
            }
            else if (prop.Type.IsReferenceType()) //407:3
            {
                string __tmp23Line = "    get { return this.GetReference<"; //408:1
                if (__tmp23Line != null) __out.Append(__tmp23Line);
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(prop.Type.CSharpFullPublicName(ClassKind.Immutable));
                using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
                {
                    bool __tmp24_first = true;
                    bool __tmp24_last = __tmp24Reader.EndOfStream;
                    while(__tmp24_first || !__tmp24_last)
                    {
                        __tmp24_first = false;
                        string __tmp24Line = __tmp24Reader.ReadLine();
                        __tmp24_last = __tmp24Reader.EndOfStream;
                        if (__tmp24Line != null) __out.Append(__tmp24Line);
                        if (!__tmp24_last) __out.AppendLine(true);
                    }
                }
                string __tmp25Line = ">("; //408:89
                if (__tmp25Line != null) __out.Append(__tmp25Line);
                StringBuilder __tmp26 = new StringBuilder();
                __tmp26.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                using(StreamReader __tmp26Reader = new StreamReader(this.__ToStream(__tmp26.ToString())))
                {
                    bool __tmp26_first = true;
                    bool __tmp26_last = __tmp26Reader.EndOfStream;
                    while(__tmp26_first || !__tmp26_last)
                    {
                        __tmp26_first = false;
                        string __tmp26Line = __tmp26Reader.ReadLine();
                        __tmp26_last = __tmp26Reader.EndOfStream;
                        if (__tmp26Line != null) __out.Append(__tmp26Line);
                        if (!__tmp26_last) __out.AppendLine(true);
                    }
                }
                string __tmp27Line = ", ref "; //408:143
                if (__tmp27Line != null) __out.Append(__tmp27Line);
                StringBuilder __tmp28 = new StringBuilder();
                __tmp28.Append(prop.GetFieldName(cls));
                using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
                {
                    bool __tmp28_first = true;
                    bool __tmp28_last = __tmp28Reader.EndOfStream;
                    while(__tmp28_first || !__tmp28_last)
                    {
                        __tmp28_first = false;
                        string __tmp28Line = __tmp28Reader.ReadLine();
                        __tmp28_last = __tmp28Reader.EndOfStream;
                        if (__tmp28Line != null) __out.Append(__tmp28Line);
                        if (!__tmp28_last) __out.AppendLine(true);
                    }
                }
                string __tmp29Line = "); }"; //408:173
                if (__tmp29Line != null) __out.Append(__tmp29Line);
                __out.AppendLine(false); //408:177
            }
            else //409:3
            {
                string __tmp31Line = "    get { return this.GetValue<"; //410:1
                if (__tmp31Line != null) __out.Append(__tmp31Line);
                StringBuilder __tmp32 = new StringBuilder();
                __tmp32.Append(prop.Type.CSharpFullPublicName(ClassKind.Immutable));
                using(StreamReader __tmp32Reader = new StreamReader(this.__ToStream(__tmp32.ToString())))
                {
                    bool __tmp32_first = true;
                    bool __tmp32_last = __tmp32Reader.EndOfStream;
                    while(__tmp32_first || !__tmp32_last)
                    {
                        __tmp32_first = false;
                        string __tmp32Line = __tmp32Reader.ReadLine();
                        __tmp32_last = __tmp32Reader.EndOfStream;
                        if (__tmp32Line != null) __out.Append(__tmp32Line);
                        if (!__tmp32_last) __out.AppendLine(true);
                    }
                }
                string __tmp33Line = ">("; //410:85
                if (__tmp33Line != null) __out.Append(__tmp33Line);
                StringBuilder __tmp34 = new StringBuilder();
                __tmp34.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                using(StreamReader __tmp34Reader = new StreamReader(this.__ToStream(__tmp34.ToString())))
                {
                    bool __tmp34_first = true;
                    bool __tmp34_last = __tmp34Reader.EndOfStream;
                    while(__tmp34_first || !__tmp34_last)
                    {
                        __tmp34_first = false;
                        string __tmp34Line = __tmp34Reader.ReadLine();
                        __tmp34_last = __tmp34Reader.EndOfStream;
                        if (__tmp34Line != null) __out.Append(__tmp34Line);
                        if (!__tmp34_last) __out.AppendLine(true);
                    }
                }
                string __tmp35Line = ", ref "; //410:139
                if (__tmp35Line != null) __out.Append(__tmp35Line);
                StringBuilder __tmp36 = new StringBuilder();
                __tmp36.Append(prop.GetFieldName(cls));
                using(StreamReader __tmp36Reader = new StreamReader(this.__ToStream(__tmp36.ToString())))
                {
                    bool __tmp36_first = true;
                    bool __tmp36_last = __tmp36Reader.EndOfStream;
                    while(__tmp36_first || !__tmp36_last)
                    {
                        __tmp36_first = false;
                        string __tmp36Line = __tmp36Reader.ReadLine();
                        __tmp36_last = __tmp36Reader.EndOfStream;
                        if (__tmp36Line != null) __out.Append(__tmp36Line);
                        if (!__tmp36_last) __out.AppendLine(true);
                    }
                }
                string __tmp37Line = "); }"; //410:169
                if (__tmp37Line != null) __out.Append(__tmp37Line);
                __out.AppendLine(false); //410:173
            }
            __out.Append("}"); //412:1
            __out.AppendLine(false); //412:2
            return __out.ToString();
        }

        public string GenerateBuilderPropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //415:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //416:1
            if (cls.GetAllFinalProperties().Contains(prop)) //417:2
            {
                string __tmp2Line = "public "; //418:1
                if (__tmp2Line != null) __out.Append(__tmp2Line);
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_first = true;
                    bool __tmp3_last = __tmp3Reader.EndOfStream;
                    while(__tmp3_first || !__tmp3_last)
                    {
                        __tmp3_first = false;
                        string __tmp3Line = __tmp3Reader.ReadLine();
                        __tmp3_last = __tmp3Reader.EndOfStream;
                        if (__tmp3Line != null) __out.Append(__tmp3Line);
                        if (!__tmp3_last) __out.AppendLine(true);
                    }
                }
                string __tmp4Line = " "; //418:59
                if (__tmp4Line != null) __out.Append(__tmp4Line);
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(prop.Name);
                using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                {
                    bool __tmp5_first = true;
                    bool __tmp5_last = __tmp5Reader.EndOfStream;
                    while(__tmp5_first || !__tmp5_last)
                    {
                        __tmp5_first = false;
                        string __tmp5Line = __tmp5Reader.ReadLine();
                        __tmp5_last = __tmp5Reader.EndOfStream;
                        if (__tmp5Line != null) __out.Append(__tmp5Line);
                        if (!__tmp5_last) __out.AppendLine(true);
                        __out.AppendLine(false); //418:71
                    }
                }
            }
            else //419:2
            {
                StringBuilder __tmp7 = new StringBuilder();
                __tmp7.Append("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
                using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
                {
                    bool __tmp7_first = true;
                    bool __tmp7_last = __tmp7Reader.EndOfStream;
                    while(__tmp7_first || !__tmp7_last)
                    {
                        __tmp7_first = false;
                        string __tmp7Line = __tmp7Reader.ReadLine();
                        __tmp7_last = __tmp7Reader.EndOfStream;
                        if (__tmp7Line != null) __out.Append(__tmp7Line);
                        if (!__tmp7_last) __out.AppendLine(true);
                        __out.AppendLine(false); //420:54
                    }
                }
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                {
                    bool __tmp9_first = true;
                    bool __tmp9_last = __tmp9Reader.EndOfStream;
                    while(__tmp9_first || !__tmp9_last)
                    {
                        __tmp9_first = false;
                        string __tmp9Line = __tmp9Reader.ReadLine();
                        __tmp9_last = __tmp9Reader.EndOfStream;
                        if (__tmp9Line != null) __out.Append(__tmp9Line);
                        if (!__tmp9_last) __out.AppendLine(true);
                    }
                }
                string __tmp10Line = " "; //421:52
                if (__tmp10Line != null) __out.Append(__tmp10Line);
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(prop.Class.CSharpFullName(ClassKind.Builder));
                using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                {
                    bool __tmp11_first = true;
                    bool __tmp11_last = __tmp11Reader.EndOfStream;
                    while(__tmp11_first || !__tmp11_last)
                    {
                        __tmp11_first = false;
                        string __tmp11Line = __tmp11Reader.ReadLine();
                        __tmp11_last = __tmp11Reader.EndOfStream;
                        if (__tmp11Line != null) __out.Append(__tmp11Line);
                        if (!__tmp11_last) __out.AppendLine(true);
                    }
                }
                string __tmp12Line = "."; //421:99
                if (__tmp12Line != null) __out.Append(__tmp12Line);
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(prop.Name);
                using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                {
                    bool __tmp13_first = true;
                    bool __tmp13_last = __tmp13Reader.EndOfStream;
                    while(__tmp13_first || !__tmp13_last)
                    {
                        __tmp13_first = false;
                        string __tmp13Line = __tmp13Reader.ReadLine();
                        __tmp13_last = __tmp13Reader.EndOfStream;
                        if (__tmp13Line != null) __out.Append(__tmp13Line);
                        if (!__tmp13_last) __out.AppendLine(true);
                        __out.AppendLine(false); //421:111
                    }
                }
            }
            __out.Append("{"); //423:1
            __out.AppendLine(false); //423:2
            if (prop.Type is MetaCollectionType) //424:6
            {
                string __tmp15Line = "    get { return this.GetList<"; //425:1
                if (__tmp15Line != null) __out.Append(__tmp15Line);
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(((MetaCollectionType)prop.Type).InnerType.CSharpFullPublicName(ClassKind.Builder));
                using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
                {
                    bool __tmp16_first = true;
                    bool __tmp16_last = __tmp16Reader.EndOfStream;
                    while(__tmp16_first || !__tmp16_last)
                    {
                        __tmp16_first = false;
                        string __tmp16Line = __tmp16Reader.ReadLine();
                        __tmp16_last = __tmp16Reader.EndOfStream;
                        if (__tmp16Line != null) __out.Append(__tmp16Line);
                        if (!__tmp16_last) __out.AppendLine(true);
                    }
                }
                string __tmp17Line = ">("; //425:114
                if (__tmp17Line != null) __out.Append(__tmp17Line);
                StringBuilder __tmp18 = new StringBuilder();
                __tmp18.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
                {
                    bool __tmp18_first = true;
                    bool __tmp18_last = __tmp18Reader.EndOfStream;
                    while(__tmp18_first || !__tmp18_last)
                    {
                        __tmp18_first = false;
                        string __tmp18Line = __tmp18Reader.ReadLine();
                        __tmp18_last = __tmp18Reader.EndOfStream;
                        if (__tmp18Line != null) __out.Append(__tmp18Line);
                        if (!__tmp18_last) __out.AppendLine(true);
                    }
                }
                string __tmp19Line = ", ref "; //425:168
                if (__tmp19Line != null) __out.Append(__tmp19Line);
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(prop.GetFieldName(cls));
                using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
                {
                    bool __tmp20_first = true;
                    bool __tmp20_last = __tmp20Reader.EndOfStream;
                    while(__tmp20_first || !__tmp20_last)
                    {
                        __tmp20_first = false;
                        string __tmp20Line = __tmp20Reader.ReadLine();
                        __tmp20_last = __tmp20Reader.EndOfStream;
                        if (__tmp20Line != null) __out.Append(__tmp20Line);
                        if (!__tmp20_last) __out.AppendLine(true);
                    }
                }
                string __tmp21Line = "); }"; //425:198
                if (__tmp21Line != null) __out.Append(__tmp21Line);
                __out.AppendLine(false); //425:202
            }
            else if (prop.Type.IsReferenceType()) //426:3
            {
                string __tmp23Line = "    get { return this.GetReference<"; //427:1
                if (__tmp23Line != null) __out.Append(__tmp23Line);
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
                {
                    bool __tmp24_first = true;
                    bool __tmp24_last = __tmp24Reader.EndOfStream;
                    while(__tmp24_first || !__tmp24_last)
                    {
                        __tmp24_first = false;
                        string __tmp24Line = __tmp24Reader.ReadLine();
                        __tmp24_last = __tmp24Reader.EndOfStream;
                        if (__tmp24Line != null) __out.Append(__tmp24Line);
                        if (!__tmp24_last) __out.AppendLine(true);
                    }
                }
                string __tmp25Line = ">("; //427:87
                if (__tmp25Line != null) __out.Append(__tmp25Line);
                StringBuilder __tmp26 = new StringBuilder();
                __tmp26.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                using(StreamReader __tmp26Reader = new StreamReader(this.__ToStream(__tmp26.ToString())))
                {
                    bool __tmp26_first = true;
                    bool __tmp26_last = __tmp26Reader.EndOfStream;
                    while(__tmp26_first || !__tmp26_last)
                    {
                        __tmp26_first = false;
                        string __tmp26Line = __tmp26Reader.ReadLine();
                        __tmp26_last = __tmp26Reader.EndOfStream;
                        if (__tmp26Line != null) __out.Append(__tmp26Line);
                        if (!__tmp26_last) __out.AppendLine(true);
                    }
                }
                string __tmp27Line = "); }"; //427:141
                if (__tmp27Line != null) __out.Append(__tmp27Line);
                __out.AppendLine(false); //427:145
            }
            else //428:3
            {
                string __tmp29Line = "    get { return this.GetValue<"; //429:1
                if (__tmp29Line != null) __out.Append(__tmp29Line);
                StringBuilder __tmp30 = new StringBuilder();
                __tmp30.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                using(StreamReader __tmp30Reader = new StreamReader(this.__ToStream(__tmp30.ToString())))
                {
                    bool __tmp30_first = true;
                    bool __tmp30_last = __tmp30Reader.EndOfStream;
                    while(__tmp30_first || !__tmp30_last)
                    {
                        __tmp30_first = false;
                        string __tmp30Line = __tmp30Reader.ReadLine();
                        __tmp30_last = __tmp30Reader.EndOfStream;
                        if (__tmp30Line != null) __out.Append(__tmp30Line);
                        if (!__tmp30_last) __out.AppendLine(true);
                    }
                }
                string __tmp31Line = ">("; //429:83
                if (__tmp31Line != null) __out.Append(__tmp31Line);
                StringBuilder __tmp32 = new StringBuilder();
                __tmp32.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                using(StreamReader __tmp32Reader = new StreamReader(this.__ToStream(__tmp32.ToString())))
                {
                    bool __tmp32_first = true;
                    bool __tmp32_last = __tmp32Reader.EndOfStream;
                    while(__tmp32_first || !__tmp32_last)
                    {
                        __tmp32_first = false;
                        string __tmp32Line = __tmp32Reader.ReadLine();
                        __tmp32_last = __tmp32Reader.EndOfStream;
                        if (__tmp32Line != null) __out.Append(__tmp32Line);
                        if (!__tmp32_last) __out.AppendLine(true);
                    }
                }
                string __tmp33Line = "); }"; //429:137
                if (__tmp33Line != null) __out.Append(__tmp33Line);
                __out.AppendLine(false); //429:141
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //431:3
            {
                if (prop.Type.IsReferenceType()) //432:4
                {
                    string __tmp35Line = "    set { this.SetReference<"; //433:1
                    if (__tmp35Line != null) __out.Append(__tmp35Line);
                    StringBuilder __tmp36 = new StringBuilder();
                    __tmp36.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                    using(StreamReader __tmp36Reader = new StreamReader(this.__ToStream(__tmp36.ToString())))
                    {
                        bool __tmp36_first = true;
                        bool __tmp36_last = __tmp36Reader.EndOfStream;
                        while(__tmp36_first || !__tmp36_last)
                        {
                            __tmp36_first = false;
                            string __tmp36Line = __tmp36Reader.ReadLine();
                            __tmp36_last = __tmp36Reader.EndOfStream;
                            if (__tmp36Line != null) __out.Append(__tmp36Line);
                            if (!__tmp36_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp37Line = ">("; //433:80
                    if (__tmp37Line != null) __out.Append(__tmp37Line);
                    StringBuilder __tmp38 = new StringBuilder();
                    __tmp38.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                    using(StreamReader __tmp38Reader = new StreamReader(this.__ToStream(__tmp38.ToString())))
                    {
                        bool __tmp38_first = true;
                        bool __tmp38_last = __tmp38Reader.EndOfStream;
                        while(__tmp38_first || !__tmp38_last)
                        {
                            __tmp38_first = false;
                            string __tmp38Line = __tmp38Reader.ReadLine();
                            __tmp38_last = __tmp38Reader.EndOfStream;
                            if (__tmp38Line != null) __out.Append(__tmp38Line);
                            if (!__tmp38_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp39Line = ", value); }"; //433:134
                    if (__tmp39Line != null) __out.Append(__tmp39Line);
                    __out.AppendLine(false); //433:145
                }
                else //434:4
                {
                    string __tmp41Line = "    set { this.SetValue<"; //435:1
                    if (__tmp41Line != null) __out.Append(__tmp41Line);
                    StringBuilder __tmp42 = new StringBuilder();
                    __tmp42.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                    using(StreamReader __tmp42Reader = new StreamReader(this.__ToStream(__tmp42.ToString())))
                    {
                        bool __tmp42_first = true;
                        bool __tmp42_last = __tmp42Reader.EndOfStream;
                        while(__tmp42_first || !__tmp42_last)
                        {
                            __tmp42_first = false;
                            string __tmp42Line = __tmp42Reader.ReadLine();
                            __tmp42_last = __tmp42Reader.EndOfStream;
                            if (__tmp42Line != null) __out.Append(__tmp42Line);
                            if (!__tmp42_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp43Line = ">("; //435:76
                    if (__tmp43Line != null) __out.Append(__tmp43Line);
                    StringBuilder __tmp44 = new StringBuilder();
                    __tmp44.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                    using(StreamReader __tmp44Reader = new StreamReader(this.__ToStream(__tmp44.ToString())))
                    {
                        bool __tmp44_first = true;
                        bool __tmp44_last = __tmp44Reader.EndOfStream;
                        while(__tmp44_first || !__tmp44_last)
                        {
                            __tmp44_first = false;
                            string __tmp44Line = __tmp44Reader.ReadLine();
                            __tmp44_last = __tmp44Reader.EndOfStream;
                            if (__tmp44Line != null) __out.Append(__tmp44Line);
                            if (!__tmp44_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp45Line = ", value); }"; //435:130
                    if (__tmp45Line != null) __out.Append(__tmp45Line);
                    __out.AppendLine(false); //435:141
                }
            }
            __out.Append("}"); //438:1
            __out.AppendLine(false); //438:2
            if (!(prop.Type is MetaCollectionType)) //439:2
            {
                __out.AppendLine(true); //440:1
                if (cls.GetAllFinalProperties().Contains(prop)) //441:3
                {
                    string __tmp47Line = "public Func<"; //442:1
                    if (__tmp47Line != null) __out.Append(__tmp47Line);
                    StringBuilder __tmp48 = new StringBuilder();
                    __tmp48.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                    using(StreamReader __tmp48Reader = new StreamReader(this.__ToStream(__tmp48.ToString())))
                    {
                        bool __tmp48_first = true;
                        bool __tmp48_last = __tmp48Reader.EndOfStream;
                        while(__tmp48_first || !__tmp48_last)
                        {
                            __tmp48_first = false;
                            string __tmp48Line = __tmp48Reader.ReadLine();
                            __tmp48_last = __tmp48Reader.EndOfStream;
                            if (__tmp48Line != null) __out.Append(__tmp48Line);
                            if (!__tmp48_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp49Line = "> "; //442:64
                    if (__tmp49Line != null) __out.Append(__tmp49Line);
                    StringBuilder __tmp50 = new StringBuilder();
                    __tmp50.Append(prop.Name);
                    using(StreamReader __tmp50Reader = new StreamReader(this.__ToStream(__tmp50.ToString())))
                    {
                        bool __tmp50_first = true;
                        bool __tmp50_last = __tmp50Reader.EndOfStream;
                        while(__tmp50_first || !__tmp50_last)
                        {
                            __tmp50_first = false;
                            string __tmp50Line = __tmp50Reader.ReadLine();
                            __tmp50_last = __tmp50Reader.EndOfStream;
                            if (__tmp50Line != null) __out.Append(__tmp50Line);
                            if (!__tmp50_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp51Line = "Lazy"; //442:77
                    if (__tmp51Line != null) __out.Append(__tmp51Line);
                    __out.AppendLine(false); //442:81
                }
                else //443:3
                {
                    StringBuilder __tmp53 = new StringBuilder();
                    __tmp53.Append("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
                    using(StreamReader __tmp53Reader = new StreamReader(this.__ToStream(__tmp53.ToString())))
                    {
                        bool __tmp53_first = true;
                        bool __tmp53_last = __tmp53Reader.EndOfStream;
                        while(__tmp53_first || !__tmp53_last)
                        {
                            __tmp53_first = false;
                            string __tmp53Line = __tmp53Reader.ReadLine();
                            __tmp53_last = __tmp53Reader.EndOfStream;
                            if (__tmp53Line != null) __out.Append(__tmp53Line);
                            if (!__tmp53_last) __out.AppendLine(true);
                            __out.AppendLine(false); //444:54
                        }
                    }
                    string __tmp55Line = "Func<"; //445:1
                    if (__tmp55Line != null) __out.Append(__tmp55Line);
                    StringBuilder __tmp56 = new StringBuilder();
                    __tmp56.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                    using(StreamReader __tmp56Reader = new StreamReader(this.__ToStream(__tmp56.ToString())))
                    {
                        bool __tmp56_first = true;
                        bool __tmp56_last = __tmp56Reader.EndOfStream;
                        while(__tmp56_first || !__tmp56_last)
                        {
                            __tmp56_first = false;
                            string __tmp56Line = __tmp56Reader.ReadLine();
                            __tmp56_last = __tmp56Reader.EndOfStream;
                            if (__tmp56Line != null) __out.Append(__tmp56Line);
                            if (!__tmp56_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp57Line = "> "; //445:57
                    if (__tmp57Line != null) __out.Append(__tmp57Line);
                    StringBuilder __tmp58 = new StringBuilder();
                    __tmp58.Append(prop.Class.CSharpFullName(ClassKind.Builder));
                    using(StreamReader __tmp58Reader = new StreamReader(this.__ToStream(__tmp58.ToString())))
                    {
                        bool __tmp58_first = true;
                        bool __tmp58_last = __tmp58Reader.EndOfStream;
                        while(__tmp58_first || !__tmp58_last)
                        {
                            __tmp58_first = false;
                            string __tmp58Line = __tmp58Reader.ReadLine();
                            __tmp58_last = __tmp58Reader.EndOfStream;
                            if (__tmp58Line != null) __out.Append(__tmp58Line);
                            if (!__tmp58_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp59Line = "."; //445:105
                    if (__tmp59Line != null) __out.Append(__tmp59Line);
                    StringBuilder __tmp60 = new StringBuilder();
                    __tmp60.Append(prop.Name);
                    using(StreamReader __tmp60Reader = new StreamReader(this.__ToStream(__tmp60.ToString())))
                    {
                        bool __tmp60_first = true;
                        bool __tmp60_last = __tmp60Reader.EndOfStream;
                        while(__tmp60_first || !__tmp60_last)
                        {
                            __tmp60_first = false;
                            string __tmp60Line = __tmp60Reader.ReadLine();
                            __tmp60_last = __tmp60Reader.EndOfStream;
                            if (__tmp60Line != null) __out.Append(__tmp60Line);
                            if (!__tmp60_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp61Line = "Lazy"; //445:117
                    if (__tmp61Line != null) __out.Append(__tmp61Line);
                    __out.AppendLine(false); //445:121
                }
                __out.Append("{"); //447:1
                __out.AppendLine(false); //447:2
                if (prop.Type.IsReferenceType()) //448:4
                {
                    string __tmp63Line = "    get { return this.GetLazyReference<"; //449:1
                    if (__tmp63Line != null) __out.Append(__tmp63Line);
                    StringBuilder __tmp64 = new StringBuilder();
                    __tmp64.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                    using(StreamReader __tmp64Reader = new StreamReader(this.__ToStream(__tmp64.ToString())))
                    {
                        bool __tmp64_first = true;
                        bool __tmp64_last = __tmp64Reader.EndOfStream;
                        while(__tmp64_first || !__tmp64_last)
                        {
                            __tmp64_first = false;
                            string __tmp64Line = __tmp64Reader.ReadLine();
                            __tmp64_last = __tmp64Reader.EndOfStream;
                            if (__tmp64Line != null) __out.Append(__tmp64Line);
                            if (!__tmp64_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp65Line = ">("; //449:91
                    if (__tmp65Line != null) __out.Append(__tmp65Line);
                    StringBuilder __tmp66 = new StringBuilder();
                    __tmp66.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                    using(StreamReader __tmp66Reader = new StreamReader(this.__ToStream(__tmp66.ToString())))
                    {
                        bool __tmp66_first = true;
                        bool __tmp66_last = __tmp66Reader.EndOfStream;
                        while(__tmp66_first || !__tmp66_last)
                        {
                            __tmp66_first = false;
                            string __tmp66Line = __tmp66Reader.ReadLine();
                            __tmp66_last = __tmp66Reader.EndOfStream;
                            if (__tmp66Line != null) __out.Append(__tmp66Line);
                            if (!__tmp66_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp67Line = "); }"; //449:145
                    if (__tmp67Line != null) __out.Append(__tmp67Line);
                    __out.AppendLine(false); //449:149
                    string __tmp69Line = "    set { this.SetLazyReference("; //450:1
                    if (__tmp69Line != null) __out.Append(__tmp69Line);
                    StringBuilder __tmp70 = new StringBuilder();
                    __tmp70.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                    using(StreamReader __tmp70Reader = new StreamReader(this.__ToStream(__tmp70.ToString())))
                    {
                        bool __tmp70_first = true;
                        bool __tmp70_last = __tmp70Reader.EndOfStream;
                        while(__tmp70_first || !__tmp70_last)
                        {
                            __tmp70_first = false;
                            string __tmp70Line = __tmp70Reader.ReadLine();
                            __tmp70_last = __tmp70Reader.EndOfStream;
                            if (__tmp70Line != null) __out.Append(__tmp70Line);
                            if (!__tmp70_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp71Line = ", value); }"; //450:85
                    if (__tmp71Line != null) __out.Append(__tmp71Line);
                    __out.AppendLine(false); //450:96
                }
                else //451:4
                {
                    string __tmp73Line = "    get { return this.GetLazyValue<"; //452:1
                    if (__tmp73Line != null) __out.Append(__tmp73Line);
                    StringBuilder __tmp74 = new StringBuilder();
                    __tmp74.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                    using(StreamReader __tmp74Reader = new StreamReader(this.__ToStream(__tmp74.ToString())))
                    {
                        bool __tmp74_first = true;
                        bool __tmp74_last = __tmp74Reader.EndOfStream;
                        while(__tmp74_first || !__tmp74_last)
                        {
                            __tmp74_first = false;
                            string __tmp74Line = __tmp74Reader.ReadLine();
                            __tmp74_last = __tmp74Reader.EndOfStream;
                            if (__tmp74Line != null) __out.Append(__tmp74Line);
                            if (!__tmp74_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp75Line = ">("; //452:87
                    if (__tmp75Line != null) __out.Append(__tmp75Line);
                    StringBuilder __tmp76 = new StringBuilder();
                    __tmp76.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                    using(StreamReader __tmp76Reader = new StreamReader(this.__ToStream(__tmp76.ToString())))
                    {
                        bool __tmp76_first = true;
                        bool __tmp76_last = __tmp76Reader.EndOfStream;
                        while(__tmp76_first || !__tmp76_last)
                        {
                            __tmp76_first = false;
                            string __tmp76Line = __tmp76Reader.ReadLine();
                            __tmp76_last = __tmp76Reader.EndOfStream;
                            if (__tmp76Line != null) __out.Append(__tmp76Line);
                            if (!__tmp76_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp77Line = "); }"; //452:141
                    if (__tmp77Line != null) __out.Append(__tmp77Line);
                    __out.AppendLine(false); //452:145
                    string __tmp79Line = "    set { this.SetLazyValue("; //453:1
                    if (__tmp79Line != null) __out.Append(__tmp79Line);
                    StringBuilder __tmp80 = new StringBuilder();
                    __tmp80.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                    using(StreamReader __tmp80Reader = new StreamReader(this.__ToStream(__tmp80.ToString())))
                    {
                        bool __tmp80_first = true;
                        bool __tmp80_last = __tmp80Reader.EndOfStream;
                        while(__tmp80_first || !__tmp80_last)
                        {
                            __tmp80_first = false;
                            string __tmp80Line = __tmp80Reader.ReadLine();
                            __tmp80_last = __tmp80Reader.EndOfStream;
                            if (__tmp80Line != null) __out.Append(__tmp80Line);
                            if (!__tmp80_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp81Line = ", value); }"; //453:81
                    if (__tmp81Line != null) __out.Append(__tmp81Line);
                    __out.AppendLine(false); //453:92
                }
                __out.Append("}"); //455:1
                __out.AppendLine(false); //455:2
            }
            return __out.ToString();
        }

        public string GetReturn(MetaOperation op) //459:1
        {
            if (op.ReturnType.CSharpName() == "void") //460:5
            {
                return ""; //461:3
            }
            else //462:2
            {
                return "return "; //463:3
            }
        }

        public string GenerateOperationImpl(MetaModel model, MetaOperation op) //467:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //468:1
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(op.ReturnType.CSharpFullPublicName(ClassKind.Immutable));
            using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
            {
                bool __tmp2_first = true;
                bool __tmp2_last = __tmp2Reader.EndOfStream;
                while(__tmp2_first || !__tmp2_last)
                {
                    __tmp2_first = false;
                    string __tmp2Line = __tmp2Reader.ReadLine();
                    __tmp2_last = __tmp2Reader.EndOfStream;
                    if (__tmp2Line != null) __out.Append(__tmp2Line);
                    if (!__tmp2_last) __out.AppendLine(true);
                }
            }
            string __tmp3Line = " "; //469:58
            if (__tmp3Line != null) __out.Append(__tmp3Line);
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(op.Parent.CSharpFullName(ClassKind.Immutable));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_first = true;
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(__tmp4_first || !__tmp4_last)
                {
                    __tmp4_first = false;
                    string __tmp4Line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (__tmp4Line != null) __out.Append(__tmp4Line);
                    if (!__tmp4_last) __out.AppendLine(true);
                }
            }
            string __tmp5Line = "."; //469:106
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(op.Name);
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(__tmp6_first || !__tmp6_last)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if (__tmp6Line != null) __out.Append(__tmp6Line);
                    if (!__tmp6_last) __out.AppendLine(true);
                }
            }
            string __tmp7Line = "("; //469:116
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(GetParameters(op, ClassKind.Immutable));
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_first = true;
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(__tmp8_first || !__tmp8_last)
                {
                    __tmp8_first = false;
                    string __tmp8Line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if (__tmp8Line != null) __out.Append(__tmp8Line);
                    if (!__tmp8_last) __out.AppendLine(true);
                }
            }
            string __tmp9Line = ")"; //469:157
            if (__tmp9Line != null) __out.Append(__tmp9Line);
            __out.AppendLine(false); //469:158
            __out.Append("{"); //470:1
            __out.AppendLine(false); //470:2
            string __tmp10Prefix = "    "; //471:1
            StringBuilder __tmp11 = new StringBuilder();
            __tmp11.Append(GetReturn(op));
            using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
            {
                bool __tmp11_first = true;
                bool __tmp11_last = __tmp11Reader.EndOfStream;
                while(__tmp11_first || !__tmp11_last)
                {
                    __tmp11_first = false;
                    string __tmp11Line = __tmp11Reader.ReadLine();
                    __tmp11_last = __tmp11Reader.EndOfStream;
                    __out.Append(__tmp10Prefix);
                    if (__tmp11Line != null) __out.Append(__tmp11Line);
                    if (!__tmp11_last) __out.AppendLine(true);
                }
            }
            StringBuilder __tmp12 = new StringBuilder();
            __tmp12.Append(model.CSharpFullImplementationName(ClassKind.Immutable));
            using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
            {
                bool __tmp12_first = true;
                bool __tmp12_last = __tmp12Reader.EndOfStream;
                while(__tmp12_first || !__tmp12_last)
                {
                    __tmp12_first = false;
                    string __tmp12Line = __tmp12Reader.ReadLine();
                    __tmp12_last = __tmp12Reader.EndOfStream;
                    if (__tmp12Line != null) __out.Append(__tmp12Line);
                    if (!__tmp12_last) __out.AppendLine(true);
                }
            }
            string __tmp13Line = "."; //471:77
            if (__tmp13Line != null) __out.Append(__tmp13Line);
            StringBuilder __tmp14 = new StringBuilder();
            __tmp14.Append(op.Parent.CSharpName());
            using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
            {
                bool __tmp14_first = true;
                bool __tmp14_last = __tmp14Reader.EndOfStream;
                while(__tmp14_first || !__tmp14_last)
                {
                    __tmp14_first = false;
                    string __tmp14Line = __tmp14Reader.ReadLine();
                    __tmp14_last = __tmp14Reader.EndOfStream;
                    if (__tmp14Line != null) __out.Append(__tmp14Line);
                    if (!__tmp14_last) __out.AppendLine(true);
                }
            }
            string __tmp15Line = "_"; //471:102
            if (__tmp15Line != null) __out.Append(__tmp15Line);
            StringBuilder __tmp16 = new StringBuilder();
            __tmp16.Append(op.Name);
            using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
            {
                bool __tmp16_first = true;
                bool __tmp16_last = __tmp16Reader.EndOfStream;
                while(__tmp16_first || !__tmp16_last)
                {
                    __tmp16_first = false;
                    string __tmp16Line = __tmp16Reader.ReadLine();
                    __tmp16_last = __tmp16Reader.EndOfStream;
                    if (__tmp16Line != null) __out.Append(__tmp16Line);
                    if (!__tmp16_last) __out.AppendLine(true);
                }
            }
            string __tmp17Line = "("; //471:112
            if (__tmp17Line != null) __out.Append(__tmp17Line);
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append(GetImplCallParameterNames(op));
            using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
            {
                bool __tmp18_first = true;
                bool __tmp18_last = __tmp18Reader.EndOfStream;
                while(__tmp18_first || !__tmp18_last)
                {
                    __tmp18_first = false;
                    string __tmp18Line = __tmp18Reader.ReadLine();
                    __tmp18_last = __tmp18Reader.EndOfStream;
                    if (__tmp18Line != null) __out.Append(__tmp18Line);
                    if (!__tmp18_last) __out.AppendLine(true);
                }
            }
            string __tmp19Line = ");"; //471:144
            if (__tmp19Line != null) __out.Append(__tmp19Line);
            __out.AppendLine(false); //471:146
            __out.Append("}"); //472:1
            __out.AppendLine(false); //472:2
            return __out.ToString();
        }

        public string GetSuperClasses(MetaClass cls) //475:1
        {
            string result = ""; //476:2
            var __loop32_results = 
                (from __loop32_var1 in __Enumerate((cls).GetEnumerator()) //477:10
                from sup in __Enumerate((__loop32_var1.SuperClasses).GetEnumerator()) //477:15
                select new { __loop32_var1 = __loop32_var1, sup = sup}
                ).ToList(); //477:5
            int __loop32_iteration = 0;
            string delim = ""; //477:33
            foreach (var __tmp1 in __loop32_results)
            {
                ++__loop32_iteration;
                if (__loop32_iteration >= 2) //477:52
                {
                    delim = ", "; //477:52
                }
                var __loop32_var1 = __tmp1.__loop32_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpFullName(); //478:3
            }
            return result; //480:2
        }

        public string GetAllSuperClasses(MetaClass cls) //483:1
        {
            string result = ""; //484:2
            var __loop33_results = 
                (from __loop33_var1 in __Enumerate((cls).GetEnumerator()) //485:10
                from sup in __Enumerate((__loop33_var1.GetAllSuperClasses(false)).GetEnumerator()) //485:15
                select new { __loop33_var1 = __loop33_var1, sup = sup}
                ).ToList(); //485:5
            int __loop33_iteration = 0;
            string delim = ""; //485:46
            foreach (var __tmp1 in __loop33_results)
            {
                ++__loop33_iteration;
                if (__loop33_iteration >= 2) //485:65
                {
                    delim = ", "; //485:65
                }
                var __loop33_var1 = __tmp1.__loop33_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpFullName(); //486:3
            }
            return result; //488:2
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //491:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "public static class "; //492:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.CSharpDescriptorName());
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(__tmp3_first || !__tmp3_last)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    if (!__tmp3_last) __out.AppendLine(true);
                    __out.AppendLine(false); //492:51
                }
            }
            __out.Append("{"); //493:1
            __out.AppendLine(false); //493:2
            __out.Append("    private static global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty> properties;"); //494:1
            __out.AppendLine(false); //494:118
            __out.AppendLine(true); //495:1
            string __tmp5Line = "    static "; //496:1
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(model.CSharpDescriptorName());
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(__tmp6_first || !__tmp6_last)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if (__tmp6Line != null) __out.Append(__tmp6Line);
                    if (!__tmp6_last) __out.AppendLine(true);
                }
            }
            string __tmp7Line = "()"; //496:42
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //496:44
            __out.Append("    {"); //497:1
            __out.AppendLine(false); //497:6
            __out.Append("        MetaDescriptor.properties = new global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty>();"); //498:1
            __out.AppendLine(false); //498:130
            __out.Append("		global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty> properties = new global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty>();"); //499:1
            __out.AppendLine(false); //499:196
            var __loop34_results = 
                (from __loop34_var1 in __Enumerate((model).GetEnumerator()) //500:11
                from Namespace in __Enumerate((__loop34_var1.Namespace).GetEnumerator()) //500:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //500:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //500:43
                from prop in __Enumerate((cls.Properties).GetEnumerator()) //500:66
                select new { __loop34_var1 = __loop34_var1, Namespace = Namespace, Declarations = Declarations, cls = cls, prop = prop}
                ).ToList(); //500:6
            int __loop34_iteration = 0;
            foreach (var __tmp8 in __loop34_results)
            {
                ++__loop34_iteration;
                var __loop34_var1 = __tmp8.__loop34_var1;
                var Namespace = __tmp8.Namespace;
                var Declarations = __tmp8.Declarations;
                var cls = __tmp8.cls;
                var prop = __tmp8.prop;
                string __tmp10Line = "        properties.Add("; //501:1
                if (__tmp10Line != null) __out.Append(__tmp10Line);
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(cls.CSharpName());
                using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                {
                    bool __tmp11_first = true;
                    bool __tmp11_last = __tmp11Reader.EndOfStream;
                    while(__tmp11_first || !__tmp11_last)
                    {
                        __tmp11_first = false;
                        string __tmp11Line = __tmp11Reader.ReadLine();
                        __tmp11_last = __tmp11Reader.EndOfStream;
                        if (__tmp11Line != null) __out.Append(__tmp11Line);
                        if (!__tmp11_last) __out.AppendLine(true);
                    }
                }
                string __tmp12Line = "."; //501:42
                if (__tmp12Line != null) __out.Append(__tmp12Line);
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(prop.Name);
                using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                {
                    bool __tmp13_first = true;
                    bool __tmp13_last = __tmp13Reader.EndOfStream;
                    while(__tmp13_first || !__tmp13_last)
                    {
                        __tmp13_first = false;
                        string __tmp13Line = __tmp13Reader.ReadLine();
                        __tmp13_last = __tmp13Reader.EndOfStream;
                        if (__tmp13Line != null) __out.Append(__tmp13Line);
                        if (!__tmp13_last) __out.AppendLine(true);
                    }
                }
                string __tmp14Line = "Property);"; //501:54
                if (__tmp14Line != null) __out.Append(__tmp14Line);
                __out.AppendLine(false); //501:64
            }
            __out.Append("    }"); //503:1
            __out.AppendLine(false); //503:6
            __out.AppendLine(true); //504:1
            __out.Append("    public static void Initialize()"); //505:1
            __out.AppendLine(false); //505:36
            __out.Append("    {"); //506:1
            __out.AppendLine(false); //506:6
            __out.Append("    }"); //508:1
            __out.AppendLine(false); //508:6
            __out.AppendLine(true); //509:1
            string __tmp16Line = "	public const string Uri = \""; //510:1
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(model.Uri);
            using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
            {
                bool __tmp17_first = true;
                bool __tmp17_last = __tmp17Reader.EndOfStream;
                while(__tmp17_first || !__tmp17_last)
                {
                    __tmp17_first = false;
                    string __tmp17Line = __tmp17Reader.ReadLine();
                    __tmp17_last = __tmp17Reader.EndOfStream;
                    if (__tmp17Line != null) __out.Append(__tmp17Line);
                    if (!__tmp17_last) __out.AppendLine(true);
                }
            }
            string __tmp18Line = "\";"; //510:40
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //510:42
            __out.AppendLine(true); //511:1
            var __loop35_results = 
                (from __loop35_var1 in __Enumerate((model).GetEnumerator()) //512:11
                from Namespace in __Enumerate((__loop35_var1.Namespace).GetEnumerator()) //512:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //512:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //512:43
                select new { __loop35_var1 = __loop35_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //512:6
            int __loop35_iteration = 0;
            foreach (var __tmp19 in __loop35_results)
            {
                ++__loop35_iteration;
                var __loop35_var1 = __tmp19.__loop35_var1;
                var Namespace = __tmp19.Namespace;
                var Declarations = __tmp19.Declarations;
                var cls = __tmp19.cls;
                string __tmp20Prefix = "    "; //513:1
                StringBuilder __tmp21 = new StringBuilder();
                __tmp21.Append(GenerateMetaModelClass(cls));
                using(StreamReader __tmp21Reader = new StreamReader(this.__ToStream(__tmp21.ToString())))
                {
                    bool __tmp21_first = true;
                    bool __tmp21_last = __tmp21Reader.EndOfStream;
                    while(__tmp21_first || !__tmp21_last)
                    {
                        __tmp21_first = false;
                        string __tmp21Line = __tmp21Reader.ReadLine();
                        __tmp21_last = __tmp21Reader.EndOfStream;
                        __out.Append(__tmp20Prefix);
                        if (__tmp21Line != null) __out.Append(__tmp21Line);
                        if (!__tmp21_last) __out.AppendLine(true);
                        __out.AppendLine(false); //513:34
                    }
                }
            }
            __out.Append("}"); //515:1
            __out.AppendLine(false); //515:2
            __out.AppendLine(true); //516:1
            return __out.ToString();
        }

        public string GenerateMetaModelClass(MetaClass cls) //520:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //521:1
            if (cls.SuperClasses.Count > 0) //522:2
            {
                StringBuilder __tmp2 = new StringBuilder();
                __tmp2.Append("[ModelSymbolDecriptor(");
                using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
                {
                    bool __tmp2_first = true;
                    bool __tmp2_last = __tmp2Reader.EndOfStream;
                    while(__tmp2_first || !__tmp2_last)
                    {
                        __tmp2_first = false;
                        string __tmp2Line = __tmp2Reader.ReadLine();
                        __tmp2_last = __tmp2Reader.EndOfStream;
                        if (__tmp2Line != null) __out.Append(__tmp2Line);
                        if (!__tmp2_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(GetDescriptorAncestors(cls, ClassKind.Normal));
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_first = true;
                    bool __tmp3_last = __tmp3Reader.EndOfStream;
                    while(__tmp3_first || !__tmp3_last)
                    {
                        __tmp3_first = false;
                        string __tmp3Line = __tmp3Reader.ReadLine();
                        __tmp3_last = __tmp3Reader.EndOfStream;
                        if (__tmp3Line != null) __out.Append(__tmp3Line);
                        if (!__tmp3_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append(")]");
                using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                {
                    bool __tmp4_first = true;
                    bool __tmp4_last = __tmp4Reader.EndOfStream;
                    while(__tmp4_first || !__tmp4_last)
                    {
                        __tmp4_first = false;
                        string __tmp4Line = __tmp4Reader.ReadLine();
                        __tmp4_last = __tmp4Reader.EndOfStream;
                        if (__tmp4Line != null) __out.Append(__tmp4Line);
                        if (!__tmp4_last) __out.AppendLine(true);
                        __out.AppendLine(false); //523:80
                    }
                }
            }
            else //524:2
            {
                StringBuilder __tmp6 = new StringBuilder();
                __tmp6.Append("[ModelSymbolDecriptor]");
                using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
                {
                    bool __tmp6_first = true;
                    bool __tmp6_last = __tmp6Reader.EndOfStream;
                    while(__tmp6_first || !__tmp6_last)
                    {
                        __tmp6_first = false;
                        string __tmp6Line = __tmp6Reader.ReadLine();
                        __tmp6_last = __tmp6Reader.EndOfStream;
                        if (__tmp6Line != null) __out.Append(__tmp6Line);
                        if (!__tmp6_last) __out.AppendLine(true);
                        __out.AppendLine(false); //525:27
                    }
                }
            }
            string __tmp8Line = "public static class "; //527:1
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(cls.CSharpName());
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_first = true;
                bool __tmp9_last = __tmp9Reader.EndOfStream;
                while(__tmp9_first || !__tmp9_last)
                {
                    __tmp9_first = false;
                    string __tmp9Line = __tmp9Reader.ReadLine();
                    __tmp9_last = __tmp9Reader.EndOfStream;
                    if (__tmp9Line != null) __out.Append(__tmp9Line);
                    if (!__tmp9_last) __out.AppendLine(true);
                    __out.AppendLine(false); //527:39
                }
            }
            __out.Append("{"); //528:1
            __out.AppendLine(false); //528:2
            string __tmp11Line = "    static "; //529:1
            if (__tmp11Line != null) __out.Append(__tmp11Line);
            StringBuilder __tmp12 = new StringBuilder();
            __tmp12.Append(cls.CSharpName());
            using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
            {
                bool __tmp12_first = true;
                bool __tmp12_last = __tmp12Reader.EndOfStream;
                while(__tmp12_first || !__tmp12_last)
                {
                    __tmp12_first = false;
                    string __tmp12Line = __tmp12Reader.ReadLine();
                    __tmp12_last = __tmp12Reader.EndOfStream;
                    if (__tmp12Line != null) __out.Append(__tmp12Line);
                    if (!__tmp12_last) __out.AppendLine(true);
                }
            }
            string __tmp13Line = "()"; //529:30
            if (__tmp13Line != null) __out.Append(__tmp13Line);
            __out.AppendLine(false); //529:32
            __out.Append("    {"); //530:1
            __out.AppendLine(false); //530:6
            string __tmp14Prefix = "        "; //531:1
            StringBuilder __tmp15 = new StringBuilder();
            __tmp15.Append(cls.CSharpName());
            using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
            {
                bool __tmp15_first = true;
                bool __tmp15_last = __tmp15Reader.EndOfStream;
                while(__tmp15_first || !__tmp15_last)
                {
                    __tmp15_first = false;
                    string __tmp15Line = __tmp15Reader.ReadLine();
                    __tmp15_last = __tmp15Reader.EndOfStream;
                    __out.Append(__tmp14Prefix);
                    if (__tmp15Line != null) __out.Append(__tmp15Line);
                    if (!__tmp15_last) __out.AppendLine(true);
                }
            }
            string __tmp16Line = ".ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof("; //531:27
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(cls.CSharpName());
            using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
            {
                bool __tmp17_first = true;
                bool __tmp17_last = __tmp17Reader.EndOfStream;
                while(__tmp17_first || !__tmp17_last)
                {
                    __tmp17_first = false;
                    string __tmp17Line = __tmp17Reader.ReadLine();
                    __tmp17_last = __tmp17Reader.EndOfStream;
                    if (__tmp17Line != null) __out.Append(__tmp17Line);
                    if (!__tmp17_last) __out.AppendLine(true);
                }
            }
            string __tmp18Line = "));"; //531:133
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //531:136
            __out.Append("    }"); //532:1
            __out.AppendLine(false); //532:6
            __out.AppendLine(true); //533:1
            __out.Append("    public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }"); //534:1
            __out.AppendLine(false); //534:91
            __out.AppendLine(true); //535:1
            if (cls.CSharpName() == "MetaClass") //536:2
            {
                __out.Append("    public static global::MetaDslx.Core.Immutable.MetaClass _MetaClass"); //537:1
                __out.AppendLine(false); //537:71
            }
            else //538:2
            {
                __out.Append("    public static global::MetaDslx.Core.Immutable.MetaClass MetaClass"); //539:1
                __out.AppendLine(false); //539:70
            }
            __out.Append("    {"); //541:1
            __out.AppendLine(false); //541:6
            string __tmp20Line = "        get { return null;/*"; //542:1
            if (__tmp20Line != null) __out.Append(__tmp20Line);
            StringBuilder __tmp21 = new StringBuilder();
            __tmp21.Append(cls.CSharpFullInstanceName());
            using(StreamReader __tmp21Reader = new StreamReader(this.__ToStream(__tmp21.ToString())))
            {
                bool __tmp21_first = true;
                bool __tmp21_last = __tmp21Reader.EndOfStream;
                while(__tmp21_first || !__tmp21_last)
                {
                    __tmp21_first = false;
                    string __tmp21Line = __tmp21Reader.ReadLine();
                    __tmp21_last = __tmp21Reader.EndOfStream;
                    if (__tmp21Line != null) __out.Append(__tmp21Line);
                    if (!__tmp21_last) __out.AppendLine(true);
                }
            }
            string __tmp22Line = ";*/ }"; //542:59
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            __out.AppendLine(false); //542:64
            __out.Append("    }"); //543:1
            __out.AppendLine(false); //543:6
            __out.AppendLine(true); //544:1
            var __loop36_results = 
                (from __loop36_var1 in __Enumerate((cls).GetEnumerator()) //545:11
                from prop in __Enumerate((__loop36_var1.Properties).GetEnumerator()) //545:16
                select new { __loop36_var1 = __loop36_var1, prop = prop}
                ).ToList(); //545:6
            int __loop36_iteration = 0;
            foreach (var __tmp23 in __loop36_results)
            {
                ++__loop36_iteration;
                var __loop36_var1 = __tmp23.__loop36_var1;
                var prop = __tmp23.prop;
                string __tmp24Prefix = "    "; //546:1
                StringBuilder __tmp25 = new StringBuilder();
                __tmp25.Append(GeneratePropertyDeclaration(cls.Model, cls, prop));
                using(StreamReader __tmp25Reader = new StreamReader(this.__ToStream(__tmp25.ToString())))
                {
                    bool __tmp25_first = true;
                    bool __tmp25_last = __tmp25Reader.EndOfStream;
                    while(__tmp25_first || !__tmp25_last)
                    {
                        __tmp25_first = false;
                        string __tmp25Line = __tmp25Reader.ReadLine();
                        __tmp25_last = __tmp25Reader.EndOfStream;
                        __out.Append(__tmp24Prefix);
                        if (__tmp25Line != null) __out.Append(__tmp25Line);
                        if (!__tmp25_last) __out.AppendLine(true);
                        __out.AppendLine(false); //546:56
                    }
                }
            }
            __out.Append("}"); //548:1
            __out.AppendLine(false); //548:2
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //551:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal static class "; //552:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.Name);
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(__tmp3_first || !__tmp3_last)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    if (!__tmp3_last) __out.AppendLine(true);
                }
            }
            string __tmp4Line = "ImplementationProvider"; //552:35
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //552:57
            __out.Append("{"); //553:1
            __out.AppendLine(false); //553:2
            string __tmp6Line = "    // If there is a compile error at this line, create a new class called "; //554:1
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(model.Name);
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_first = true;
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(__tmp7_first || !__tmp7_last)
                {
                    __tmp7_first = false;
                    string __tmp7Line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    if (__tmp7Line != null) __out.Append(__tmp7Line);
                    if (!__tmp7_last) __out.AppendLine(true);
                }
            }
            string __tmp8Line = "Implementation"; //554:88
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //554:102
            string __tmp10Line = "	// which is a subclass of "; //555:1
            if (__tmp10Line != null) __out.Append(__tmp10Line);
            StringBuilder __tmp11 = new StringBuilder();
            __tmp11.Append(model.Name);
            using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
            {
                bool __tmp11_first = true;
                bool __tmp11_last = __tmp11Reader.EndOfStream;
                while(__tmp11_first || !__tmp11_last)
                {
                    __tmp11_first = false;
                    string __tmp11Line = __tmp11Reader.ReadLine();
                    __tmp11_last = __tmp11Reader.EndOfStream;
                    if (__tmp11Line != null) __out.Append(__tmp11Line);
                    if (!__tmp11_last) __out.AppendLine(true);
                }
            }
            string __tmp12Line = "ImplementationBase:"; //555:40
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //555:59
            string __tmp14Line = "    private static "; //556:1
            if (__tmp14Line != null) __out.Append(__tmp14Line);
            StringBuilder __tmp15 = new StringBuilder();
            __tmp15.Append(model.Name);
            using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
            {
                bool __tmp15_first = true;
                bool __tmp15_last = __tmp15Reader.EndOfStream;
                while(__tmp15_first || !__tmp15_last)
                {
                    __tmp15_first = false;
                    string __tmp15Line = __tmp15Reader.ReadLine();
                    __tmp15_last = __tmp15Reader.EndOfStream;
                    if (__tmp15Line != null) __out.Append(__tmp15Line);
                    if (!__tmp15_last) __out.AppendLine(true);
                }
            }
            string __tmp16Line = "Implementation implementation = new "; //556:32
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(model.Name);
            using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
            {
                bool __tmp17_first = true;
                bool __tmp17_last = __tmp17Reader.EndOfStream;
                while(__tmp17_first || !__tmp17_last)
                {
                    __tmp17_first = false;
                    string __tmp17Line = __tmp17Reader.ReadLine();
                    __tmp17_last = __tmp17Reader.EndOfStream;
                    if (__tmp17Line != null) __out.Append(__tmp17Line);
                    if (!__tmp17_last) __out.AppendLine(true);
                }
            }
            string __tmp18Line = "Implementation();"; //556:80
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //556:97
            __out.AppendLine(true); //557:1
            string __tmp20Line = "    public static "; //558:1
            if (__tmp20Line != null) __out.Append(__tmp20Line);
            StringBuilder __tmp21 = new StringBuilder();
            __tmp21.Append(model.Name);
            using(StreamReader __tmp21Reader = new StreamReader(this.__ToStream(__tmp21.ToString())))
            {
                bool __tmp21_first = true;
                bool __tmp21_last = __tmp21Reader.EndOfStream;
                while(__tmp21_first || !__tmp21_last)
                {
                    __tmp21_first = false;
                    string __tmp21Line = __tmp21Reader.ReadLine();
                    __tmp21_last = __tmp21Reader.EndOfStream;
                    if (__tmp21Line != null) __out.Append(__tmp21Line);
                    if (!__tmp21_last) __out.AppendLine(true);
                }
            }
            string __tmp22Line = "Implementation Implementation"; //558:31
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            __out.AppendLine(false); //558:60
            __out.Append("    {"); //559:1
            __out.AppendLine(false); //559:6
            string __tmp24Line = "        get { return "; //560:1
            if (__tmp24Line != null) __out.Append(__tmp24Line);
            StringBuilder __tmp25 = new StringBuilder();
            __tmp25.Append(model.Name);
            using(StreamReader __tmp25Reader = new StreamReader(this.__ToStream(__tmp25.ToString())))
            {
                bool __tmp25_first = true;
                bool __tmp25_last = __tmp25Reader.EndOfStream;
                while(__tmp25_first || !__tmp25_last)
                {
                    __tmp25_first = false;
                    string __tmp25Line = __tmp25Reader.ReadLine();
                    __tmp25_last = __tmp25Reader.EndOfStream;
                    if (__tmp25Line != null) __out.Append(__tmp25Line);
                    if (!__tmp25_last) __out.AppendLine(true);
                }
            }
            string __tmp26Line = "ImplementationProvider.implementation; }"; //560:34
            if (__tmp26Line != null) __out.Append(__tmp26Line);
            __out.AppendLine(false); //560:74
            __out.Append("    }"); //561:1
            __out.AppendLine(false); //561:6
            __out.Append("}"); //562:1
            __out.AppendLine(false); //562:2
            var __loop37_results = 
                (from __loop37_var1 in __Enumerate((model).GetEnumerator()) //563:8
                from Namespace in __Enumerate((__loop37_var1.Namespace).GetEnumerator()) //563:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //563:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //563:40
                select new { __loop37_var1 = __loop37_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //563:3
            int __loop37_iteration = 0;
            foreach (var __tmp27 in __loop37_results)
            {
                ++__loop37_iteration;
                var __loop37_var1 = __tmp27.__loop37_var1;
                var Namespace = __tmp27.Namespace;
                var Declarations = __tmp27.Declarations;
                var enm = __tmp27.enm;
                __out.AppendLine(true); //564:1
                string __tmp29Line = "public static class "; //565:1
                if (__tmp29Line != null) __out.Append(__tmp29Line);
                StringBuilder __tmp30 = new StringBuilder();
                __tmp30.Append(enm.Name);
                using(StreamReader __tmp30Reader = new StreamReader(this.__ToStream(__tmp30.ToString())))
                {
                    bool __tmp30_first = true;
                    bool __tmp30_last = __tmp30Reader.EndOfStream;
                    while(__tmp30_first || !__tmp30_last)
                    {
                        __tmp30_first = false;
                        string __tmp30Line = __tmp30Reader.ReadLine();
                        __tmp30_last = __tmp30Reader.EndOfStream;
                        if (__tmp30Line != null) __out.Append(__tmp30Line);
                        if (!__tmp30_last) __out.AppendLine(true);
                    }
                }
                string __tmp31Line = "Extensions"; //565:31
                if (__tmp31Line != null) __out.Append(__tmp31Line);
                __out.AppendLine(false); //565:41
                __out.Append("{"); //566:1
                __out.AppendLine(false); //566:2
                var __loop38_results = 
                    (from __loop38_var1 in __Enumerate((enm).GetEnumerator()) //567:11
                    from op in __Enumerate((__loop38_var1.Operations).GetEnumerator()) //567:16
                    select new { __loop38_var1 = __loop38_var1, op = op}
                    ).ToList(); //567:6
                int __loop38_iteration = 0;
                foreach (var __tmp32 in __loop38_results)
                {
                    ++__loop38_iteration;
                    var __loop38_var1 = __tmp32.__loop38_var1;
                    var op = __tmp32.op;
                    string __tmp34Line = "    public static "; //568:1
                    if (__tmp34Line != null) __out.Append(__tmp34Line);
                    StringBuilder __tmp35 = new StringBuilder();
                    __tmp35.Append(op.ReturnType.CSharpFullPublicName(ClassKind.Immutable));
                    using(StreamReader __tmp35Reader = new StreamReader(this.__ToStream(__tmp35.ToString())))
                    {
                        bool __tmp35_first = true;
                        bool __tmp35_last = __tmp35Reader.EndOfStream;
                        while(__tmp35_first || !__tmp35_last)
                        {
                            __tmp35_first = false;
                            string __tmp35Line = __tmp35Reader.ReadLine();
                            __tmp35_last = __tmp35Reader.EndOfStream;
                            if (__tmp35Line != null) __out.Append(__tmp35Line);
                            if (!__tmp35_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp36Line = " "; //568:76
                    if (__tmp36Line != null) __out.Append(__tmp36Line);
                    StringBuilder __tmp37 = new StringBuilder();
                    __tmp37.Append(op.Name);
                    using(StreamReader __tmp37Reader = new StreamReader(this.__ToStream(__tmp37.ToString())))
                    {
                        bool __tmp37_first = true;
                        bool __tmp37_last = __tmp37Reader.EndOfStream;
                        while(__tmp37_first || !__tmp37_last)
                        {
                            __tmp37_first = false;
                            string __tmp37Line = __tmp37Reader.ReadLine();
                            __tmp37_last = __tmp37Reader.EndOfStream;
                            if (__tmp37Line != null) __out.Append(__tmp37Line);
                            if (!__tmp37_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp38Line = "("; //568:86
                    if (__tmp38Line != null) __out.Append(__tmp38Line);
                    StringBuilder __tmp39 = new StringBuilder();
                    __tmp39.Append(GetEnumImplParameters(enm, op));
                    using(StreamReader __tmp39Reader = new StreamReader(this.__ToStream(__tmp39.ToString())))
                    {
                        bool __tmp39_first = true;
                        bool __tmp39_last = __tmp39Reader.EndOfStream;
                        while(__tmp39_first || !__tmp39_last)
                        {
                            __tmp39_first = false;
                            string __tmp39Line = __tmp39Reader.ReadLine();
                            __tmp39_last = __tmp39Reader.EndOfStream;
                            if (__tmp39Line != null) __out.Append(__tmp39Line);
                            if (!__tmp39_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp40Line = ")"; //568:119
                    if (__tmp40Line != null) __out.Append(__tmp40Line);
                    __out.AppendLine(false); //568:120
                    __out.Append("    {"); //569:1
                    __out.AppendLine(false); //569:6
                    string __tmp41Prefix = "        "; //570:1
                    StringBuilder __tmp42 = new StringBuilder();
                    __tmp42.Append(GetReturn(op));
                    using(StreamReader __tmp42Reader = new StreamReader(this.__ToStream(__tmp42.ToString())))
                    {
                        bool __tmp42_first = true;
                        bool __tmp42_last = __tmp42Reader.EndOfStream;
                        while(__tmp42_first || !__tmp42_last)
                        {
                            __tmp42_first = false;
                            string __tmp42Line = __tmp42Reader.ReadLine();
                            __tmp42_last = __tmp42Reader.EndOfStream;
                            __out.Append(__tmp41Prefix);
                            if (__tmp42Line != null) __out.Append(__tmp42Line);
                            if (!__tmp42_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp43 = new StringBuilder();
                    __tmp43.Append(model.Name);
                    using(StreamReader __tmp43Reader = new StreamReader(this.__ToStream(__tmp43.ToString())))
                    {
                        bool __tmp43_first = true;
                        bool __tmp43_last = __tmp43Reader.EndOfStream;
                        while(__tmp43_first || !__tmp43_last)
                        {
                            __tmp43_first = false;
                            string __tmp43Line = __tmp43Reader.ReadLine();
                            __tmp43_last = __tmp43Reader.EndOfStream;
                            if (__tmp43Line != null) __out.Append(__tmp43Line);
                            if (!__tmp43_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp44Line = "ImplementationProvider.Implementation."; //570:36
                    if (__tmp44Line != null) __out.Append(__tmp44Line);
                    StringBuilder __tmp45 = new StringBuilder();
                    __tmp45.Append(op.Parent.CSharpName());
                    using(StreamReader __tmp45Reader = new StreamReader(this.__ToStream(__tmp45.ToString())))
                    {
                        bool __tmp45_first = true;
                        bool __tmp45_last = __tmp45Reader.EndOfStream;
                        while(__tmp45_first || !__tmp45_last)
                        {
                            __tmp45_first = false;
                            string __tmp45Line = __tmp45Reader.ReadLine();
                            __tmp45_last = __tmp45Reader.EndOfStream;
                            if (__tmp45Line != null) __out.Append(__tmp45Line);
                            if (!__tmp45_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp46Line = "_"; //570:98
                    if (__tmp46Line != null) __out.Append(__tmp46Line);
                    StringBuilder __tmp47 = new StringBuilder();
                    __tmp47.Append(op.Name);
                    using(StreamReader __tmp47Reader = new StreamReader(this.__ToStream(__tmp47.ToString())))
                    {
                        bool __tmp47_first = true;
                        bool __tmp47_last = __tmp47Reader.EndOfStream;
                        while(__tmp47_first || !__tmp47_last)
                        {
                            __tmp47_first = false;
                            string __tmp47Line = __tmp47Reader.ReadLine();
                            __tmp47_last = __tmp47Reader.EndOfStream;
                            if (__tmp47Line != null) __out.Append(__tmp47Line);
                            if (!__tmp47_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp48Line = "("; //570:108
                    if (__tmp48Line != null) __out.Append(__tmp48Line);
                    StringBuilder __tmp49 = new StringBuilder();
                    __tmp49.Append(GetEnumImplCallParameterNames(op));
                    using(StreamReader __tmp49Reader = new StreamReader(this.__ToStream(__tmp49.ToString())))
                    {
                        bool __tmp49_first = true;
                        bool __tmp49_last = __tmp49Reader.EndOfStream;
                        while(__tmp49_first || !__tmp49_last)
                        {
                            __tmp49_first = false;
                            string __tmp49Line = __tmp49Reader.ReadLine();
                            __tmp49_last = __tmp49Reader.EndOfStream;
                            if (__tmp49Line != null) __out.Append(__tmp49Line);
                            if (!__tmp49_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp50Line = ");"; //570:144
                    if (__tmp50Line != null) __out.Append(__tmp50Line);
                    __out.AppendLine(false); //570:146
                    __out.Append("    }"); //571:1
                    __out.AppendLine(false); //571:6
                }
                __out.Append("}"); //573:1
                __out.AppendLine(false); //573:2
            }
            __out.AppendLine(true); //575:1
            __out.Append("/// <summary>"); //576:1
            __out.AppendLine(false); //576:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //577:1
            __out.AppendLine(false); //577:68
            string __tmp52Line = "/// This class has to be be overriden in "; //578:1
            if (__tmp52Line != null) __out.Append(__tmp52Line);
            StringBuilder __tmp53 = new StringBuilder();
            __tmp53.Append(model.Name);
            using(StreamReader __tmp53Reader = new StreamReader(this.__ToStream(__tmp53.ToString())))
            {
                bool __tmp53_first = true;
                bool __tmp53_last = __tmp53Reader.EndOfStream;
                while(__tmp53_first || !__tmp53_last)
                {
                    __tmp53_first = false;
                    string __tmp53Line = __tmp53Reader.ReadLine();
                    __tmp53_last = __tmp53Reader.EndOfStream;
                    if (__tmp53Line != null) __out.Append(__tmp53Line);
                    if (!__tmp53_last) __out.AppendLine(true);
                }
            }
            string __tmp54Line = "Implementation to provide custom"; //578:54
            if (__tmp54Line != null) __out.Append(__tmp54Line);
            __out.AppendLine(false); //578:86
            __out.Append("/// implementation for the constructors, operations and property values."); //579:1
            __out.AppendLine(false); //579:73
            __out.Append("/// </summary>"); //580:1
            __out.AppendLine(false); //580:15
            string __tmp56Line = "internal abstract class "; //581:1
            if (__tmp56Line != null) __out.Append(__tmp56Line);
            StringBuilder __tmp57 = new StringBuilder();
            __tmp57.Append(model.Name);
            using(StreamReader __tmp57Reader = new StreamReader(this.__ToStream(__tmp57.ToString())))
            {
                bool __tmp57_first = true;
                bool __tmp57_last = __tmp57Reader.EndOfStream;
                while(__tmp57_first || !__tmp57_last)
                {
                    __tmp57_first = false;
                    string __tmp57Line = __tmp57Reader.ReadLine();
                    __tmp57_last = __tmp57Reader.EndOfStream;
                    if (__tmp57Line != null) __out.Append(__tmp57Line);
                    if (!__tmp57_last) __out.AppendLine(true);
                }
            }
            string __tmp58Line = "ImplementationBase"; //581:37
            if (__tmp58Line != null) __out.Append(__tmp58Line);
            __out.AppendLine(false); //581:55
            __out.Append("{"); //582:1
            __out.AppendLine(false); //582:2
            var __loop39_results = 
                (from __loop39_var1 in __Enumerate((model).GetEnumerator()) //583:8
                from Namespace in __Enumerate((__loop39_var1.Namespace).GetEnumerator()) //583:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //583:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //583:40
                select new { __loop39_var1 = __loop39_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //583:3
            int __loop39_iteration = 0;
            foreach (var __tmp59 in __loop39_results)
            {
                ++__loop39_iteration;
                var __loop39_var1 = __tmp59.__loop39_var1;
                var Namespace = __tmp59.Namespace;
                var Declarations = __tmp59.Declarations;
                var cls = __tmp59.cls;
                __out.Append("    /// <summary>"); //584:1
                __out.AppendLine(false); //584:18
                string __tmp61Line = "	/// Implements the constructor: "; //585:1
                if (__tmp61Line != null) __out.Append(__tmp61Line);
                StringBuilder __tmp62 = new StringBuilder();
                __tmp62.Append(cls.CSharpName());
                using(StreamReader __tmp62Reader = new StreamReader(this.__ToStream(__tmp62.ToString())))
                {
                    bool __tmp62_first = true;
                    bool __tmp62_last = __tmp62Reader.EndOfStream;
                    while(__tmp62_first || !__tmp62_last)
                    {
                        __tmp62_first = false;
                        string __tmp62Line = __tmp62Reader.ReadLine();
                        __tmp62_last = __tmp62Reader.EndOfStream;
                        if (__tmp62Line != null) __out.Append(__tmp62Line);
                        if (!__tmp62_last) __out.AppendLine(true);
                    }
                }
                string __tmp63Line = "()"; //585:52
                if (__tmp63Line != null) __out.Append(__tmp63Line);
                __out.AppendLine(false); //585:54
                __out.Append("    /// </summary>"); //586:1
                __out.AppendLine(false); //586:19
                if ((from __loop40_var1 in __Enumerate((cls).GetEnumerator()) //587:15
                from sup in __Enumerate((__loop40_var1.SuperClasses).GetEnumerator()) //587:20
                select new { __loop40_var1 = __loop40_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //587:3
                {
                    string __tmp65Line = "	/// Direct superclasses: "; //588:1
                    if (__tmp65Line != null) __out.Append(__tmp65Line);
                    StringBuilder __tmp66 = new StringBuilder();
                    __tmp66.Append(GetSuperClasses(cls));
                    using(StreamReader __tmp66Reader = new StreamReader(this.__ToStream(__tmp66.ToString())))
                    {
                        bool __tmp66_first = true;
                        bool __tmp66_last = __tmp66Reader.EndOfStream;
                        while(__tmp66_first || !__tmp66_last)
                        {
                            __tmp66_first = false;
                            string __tmp66Line = __tmp66Reader.ReadLine();
                            __tmp66_last = __tmp66Reader.EndOfStream;
                            if (__tmp66Line != null) __out.Append(__tmp66Line);
                            if (!__tmp66_last) __out.AppendLine(true);
                            __out.AppendLine(false); //588:49
                        }
                    }
                    string __tmp68Line = "	/// All superclasses: "; //589:1
                    if (__tmp68Line != null) __out.Append(__tmp68Line);
                    StringBuilder __tmp69 = new StringBuilder();
                    __tmp69.Append(GetAllSuperClasses(cls));
                    using(StreamReader __tmp69Reader = new StreamReader(this.__ToStream(__tmp69.ToString())))
                    {
                        bool __tmp69_first = true;
                        bool __tmp69_last = __tmp69Reader.EndOfStream;
                        while(__tmp69_first || !__tmp69_last)
                        {
                            __tmp69_first = false;
                            string __tmp69Line = __tmp69Reader.ReadLine();
                            __tmp69_last = __tmp69Reader.EndOfStream;
                            if (__tmp69Line != null) __out.Append(__tmp69Line);
                            if (!__tmp69_last) __out.AppendLine(true);
                            __out.AppendLine(false); //589:49
                        }
                    }
                }
                if ((from __loop41_var1 in __Enumerate((cls).GetEnumerator()) //591:15
                from prop in __Enumerate((__loop41_var1.Properties).GetEnumerator()) //591:20
                where prop.Kind == MetaPropertyKind.Readonly //591:36
                select new { __loop41_var1 = __loop41_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //591:3
                {
                    __out.Append("    /// Initializes the following readonly properties:"); //592:1
                    __out.AppendLine(false); //592:55
                    __out.Append("	/// <ul>"); //593:1
                    __out.AppendLine(false); //593:10
                    var __loop42_results = 
                        (from __loop42_var1 in __Enumerate((cls).GetEnumerator()) //594:11
                        from prop in __Enumerate((__loop42_var1.Properties).GetEnumerator()) //594:16
                        where prop.Kind == MetaPropertyKind.Readonly //594:32
                        select new { __loop42_var1 = __loop42_var1, prop = prop}
                        ).ToList(); //594:6
                    int __loop42_iteration = 0;
                    foreach (var __tmp70 in __loop42_results)
                    {
                        ++__loop42_iteration;
                        var __loop42_var1 = __tmp70.__loop42_var1;
                        var prop = __tmp70.prop;
                        string __tmp72Line = "    ///     <li>"; //595:1
                        if (__tmp72Line != null) __out.Append(__tmp72Line);
                        StringBuilder __tmp73 = new StringBuilder();
                        __tmp73.Append(prop.Name);
                        using(StreamReader __tmp73Reader = new StreamReader(this.__ToStream(__tmp73.ToString())))
                        {
                            bool __tmp73_first = true;
                            bool __tmp73_last = __tmp73Reader.EndOfStream;
                            while(__tmp73_first || !__tmp73_last)
                            {
                                __tmp73_first = false;
                                string __tmp73Line = __tmp73Reader.ReadLine();
                                __tmp73_last = __tmp73Reader.EndOfStream;
                                if (__tmp73Line != null) __out.Append(__tmp73Line);
                                if (!__tmp73_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp74Line = "</li>"; //595:28
                        if (__tmp74Line != null) __out.Append(__tmp74Line);
                        __out.AppendLine(false); //595:33
                    }
                    __out.Append("	/// </ul>"); //597:1
                    __out.AppendLine(false); //597:11
                }
                if ((from __loop43_var1 in __Enumerate((cls).GetEnumerator()) //599:15
                from prop in __Enumerate((__loop43_var1.Properties).GetEnumerator()) //599:20
                where prop.Kind == MetaPropertyKind.Lazy //599:36
                select new { __loop43_var1 = __loop43_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //599:3
                {
                    __out.Append("    /// Initializes the following lazy properties:"); //600:1
                    __out.AppendLine(false); //600:51
                    __out.Append("	/// <ul>"); //601:1
                    __out.AppendLine(false); //601:10
                    var __loop44_results = 
                        (from __loop44_var1 in __Enumerate((cls).GetEnumerator()) //602:11
                        from prop in __Enumerate((__loop44_var1.Properties).GetEnumerator()) //602:16
                        where prop.Kind == MetaPropertyKind.Lazy //602:32
                        select new { __loop44_var1 = __loop44_var1, prop = prop}
                        ).ToList(); //602:6
                    int __loop44_iteration = 0;
                    foreach (var __tmp75 in __loop44_results)
                    {
                        ++__loop44_iteration;
                        var __loop44_var1 = __tmp75.__loop44_var1;
                        var prop = __tmp75.prop;
                        string __tmp77Line = "    ///     <li>"; //603:1
                        if (__tmp77Line != null) __out.Append(__tmp77Line);
                        StringBuilder __tmp78 = new StringBuilder();
                        __tmp78.Append(prop.Name);
                        using(StreamReader __tmp78Reader = new StreamReader(this.__ToStream(__tmp78.ToString())))
                        {
                            bool __tmp78_first = true;
                            bool __tmp78_last = __tmp78Reader.EndOfStream;
                            while(__tmp78_first || !__tmp78_last)
                            {
                                __tmp78_first = false;
                                string __tmp78Line = __tmp78Reader.ReadLine();
                                __tmp78_last = __tmp78Reader.EndOfStream;
                                if (__tmp78Line != null) __out.Append(__tmp78Line);
                                if (!__tmp78_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp79Line = "</li>"; //603:28
                        if (__tmp79Line != null) __out.Append(__tmp79Line);
                        __out.AppendLine(false); //603:33
                    }
                    __out.Append("	/// </ul>"); //605:1
                    __out.AppendLine(false); //605:11
                }
                if ((from __loop45_var1 in __Enumerate((cls).GetEnumerator()) //607:15
                from prop in __Enumerate((__loop45_var1.Properties).GetEnumerator()) //607:20
                where prop.Kind == MetaPropertyKind.Derived //607:36
                select new { __loop45_var1 = __loop45_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //607:3
                {
                    __out.Append("    /// Initializes the following derived properties:"); //608:1
                    __out.AppendLine(false); //608:54
                    __out.Append("	/// <ul>"); //609:1
                    __out.AppendLine(false); //609:10
                    var __loop46_results = 
                        (from __loop46_var1 in __Enumerate((cls).GetEnumerator()) //610:11
                        from prop in __Enumerate((__loop46_var1.Properties).GetEnumerator()) //610:16
                        where prop.Kind == MetaPropertyKind.Derived //610:32
                        select new { __loop46_var1 = __loop46_var1, prop = prop}
                        ).ToList(); //610:6
                    int __loop46_iteration = 0;
                    foreach (var __tmp80 in __loop46_results)
                    {
                        ++__loop46_iteration;
                        var __loop46_var1 = __tmp80.__loop46_var1;
                        var prop = __tmp80.prop;
                        string __tmp82Line = "    ///     <li>"; //611:1
                        if (__tmp82Line != null) __out.Append(__tmp82Line);
                        StringBuilder __tmp83 = new StringBuilder();
                        __tmp83.Append(prop.Name);
                        using(StreamReader __tmp83Reader = new StreamReader(this.__ToStream(__tmp83.ToString())))
                        {
                            bool __tmp83_first = true;
                            bool __tmp83_last = __tmp83Reader.EndOfStream;
                            while(__tmp83_first || !__tmp83_last)
                            {
                                __tmp83_first = false;
                                string __tmp83Line = __tmp83Reader.ReadLine();
                                __tmp83_last = __tmp83Reader.EndOfStream;
                                if (__tmp83Line != null) __out.Append(__tmp83Line);
                                if (!__tmp83_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp84Line = "</li>"; //611:28
                        if (__tmp84Line != null) __out.Append(__tmp84Line);
                        __out.AppendLine(false); //611:33
                    }
                    __out.Append("	/// </ul>"); //613:1
                    __out.AppendLine(false); //613:11
                }
                string __tmp86Line = "    public virtual void "; //615:1
                if (__tmp86Line != null) __out.Append(__tmp86Line);
                StringBuilder __tmp87 = new StringBuilder();
                __tmp87.Append(cls.CSharpName());
                using(StreamReader __tmp87Reader = new StreamReader(this.__ToStream(__tmp87.ToString())))
                {
                    bool __tmp87_first = true;
                    bool __tmp87_last = __tmp87Reader.EndOfStream;
                    while(__tmp87_first || !__tmp87_last)
                    {
                        __tmp87_first = false;
                        string __tmp87Line = __tmp87Reader.ReadLine();
                        __tmp87_last = __tmp87Reader.EndOfStream;
                        if (__tmp87Line != null) __out.Append(__tmp87Line);
                        if (!__tmp87_last) __out.AppendLine(true);
                    }
                }
                string __tmp88Line = "("; //615:43
                if (__tmp88Line != null) __out.Append(__tmp88Line);
                StringBuilder __tmp89 = new StringBuilder();
                __tmp89.Append(cls.CSharpName(ClassKind.Builder));
                using(StreamReader __tmp89Reader = new StreamReader(this.__ToStream(__tmp89.ToString())))
                {
                    bool __tmp89_first = true;
                    bool __tmp89_last = __tmp89Reader.EndOfStream;
                    while(__tmp89_first || !__tmp89_last)
                    {
                        __tmp89_first = false;
                        string __tmp89Line = __tmp89Reader.ReadLine();
                        __tmp89_last = __tmp89Reader.EndOfStream;
                        if (__tmp89Line != null) __out.Append(__tmp89Line);
                        if (!__tmp89_last) __out.AppendLine(true);
                    }
                }
                string __tmp90Line = " _this)"; //615:79
                if (__tmp90Line != null) __out.Append(__tmp90Line);
                __out.AppendLine(false); //615:86
                __out.Append("    {"); //616:1
                __out.AppendLine(false); //616:6
                __out.Append("    }"); //617:1
                __out.AppendLine(false); //617:6
                var __loop47_results = 
                    (from __loop47_var1 in __Enumerate((cls).GetEnumerator()) //618:11
                    from op in __Enumerate((__loop47_var1.Operations).GetEnumerator()) //618:16
                    select new { __loop47_var1 = __loop47_var1, op = op}
                    ).ToList(); //618:6
                int __loop47_iteration = 0;
                foreach (var __tmp91 in __loop47_results)
                {
                    ++__loop47_iteration;
                    var __loop47_var1 = __tmp91.__loop47_var1;
                    var op = __tmp91.op;
                    __out.AppendLine(true); //619:1
                    __out.Append("    /// <summary>"); //620:1
                    __out.AppendLine(false); //620:18
                    string __tmp93Line = "    /// Implements the operation: "; //621:1
                    if (__tmp93Line != null) __out.Append(__tmp93Line);
                    StringBuilder __tmp94 = new StringBuilder();
                    __tmp94.Append(cls.CSharpName());
                    using(StreamReader __tmp94Reader = new StreamReader(this.__ToStream(__tmp94.ToString())))
                    {
                        bool __tmp94_first = true;
                        bool __tmp94_last = __tmp94Reader.EndOfStream;
                        while(__tmp94_first || !__tmp94_last)
                        {
                            __tmp94_first = false;
                            string __tmp94Line = __tmp94Reader.ReadLine();
                            __tmp94_last = __tmp94Reader.EndOfStream;
                            if (__tmp94Line != null) __out.Append(__tmp94Line);
                            if (!__tmp94_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp95Line = "."; //621:53
                    if (__tmp95Line != null) __out.Append(__tmp95Line);
                    StringBuilder __tmp96 = new StringBuilder();
                    __tmp96.Append(op.Name);
                    using(StreamReader __tmp96Reader = new StreamReader(this.__ToStream(__tmp96.ToString())))
                    {
                        bool __tmp96_first = true;
                        bool __tmp96_last = __tmp96Reader.EndOfStream;
                        while(__tmp96_first || !__tmp96_last)
                        {
                            __tmp96_first = false;
                            string __tmp96Line = __tmp96Reader.ReadLine();
                            __tmp96_last = __tmp96Reader.EndOfStream;
                            if (__tmp96Line != null) __out.Append(__tmp96Line);
                            if (!__tmp96_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp97Line = "()"; //621:63
                    if (__tmp97Line != null) __out.Append(__tmp97Line);
                    __out.AppendLine(false); //621:65
                    __out.Append("    /// </summary>"); //622:1
                    __out.AppendLine(false); //622:19
                    string __tmp99Line = "    public virtual "; //623:1
                    if (__tmp99Line != null) __out.Append(__tmp99Line);
                    StringBuilder __tmp100 = new StringBuilder();
                    __tmp100.Append(op.ReturnType.CSharpFullPublicName(ClassKind.Immutable));
                    using(StreamReader __tmp100Reader = new StreamReader(this.__ToStream(__tmp100.ToString())))
                    {
                        bool __tmp100_first = true;
                        bool __tmp100_last = __tmp100Reader.EndOfStream;
                        while(__tmp100_first || !__tmp100_last)
                        {
                            __tmp100_first = false;
                            string __tmp100Line = __tmp100Reader.ReadLine();
                            __tmp100_last = __tmp100Reader.EndOfStream;
                            if (__tmp100Line != null) __out.Append(__tmp100Line);
                            if (!__tmp100_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp101Line = " "; //623:77
                    if (__tmp101Line != null) __out.Append(__tmp101Line);
                    StringBuilder __tmp102 = new StringBuilder();
                    __tmp102.Append(cls.CSharpName());
                    using(StreamReader __tmp102Reader = new StreamReader(this.__ToStream(__tmp102.ToString())))
                    {
                        bool __tmp102_first = true;
                        bool __tmp102_last = __tmp102Reader.EndOfStream;
                        while(__tmp102_first || !__tmp102_last)
                        {
                            __tmp102_first = false;
                            string __tmp102Line = __tmp102Reader.ReadLine();
                            __tmp102_last = __tmp102Reader.EndOfStream;
                            if (__tmp102Line != null) __out.Append(__tmp102Line);
                            if (!__tmp102_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp103Line = "_"; //623:96
                    if (__tmp103Line != null) __out.Append(__tmp103Line);
                    StringBuilder __tmp104 = new StringBuilder();
                    __tmp104.Append(op.Name);
                    using(StreamReader __tmp104Reader = new StreamReader(this.__ToStream(__tmp104.ToString())))
                    {
                        bool __tmp104_first = true;
                        bool __tmp104_last = __tmp104Reader.EndOfStream;
                        while(__tmp104_first || !__tmp104_last)
                        {
                            __tmp104_first = false;
                            string __tmp104Line = __tmp104Reader.ReadLine();
                            __tmp104_last = __tmp104Reader.EndOfStream;
                            if (__tmp104Line != null) __out.Append(__tmp104Line);
                            if (!__tmp104_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp105Line = "("; //623:106
                    if (__tmp105Line != null) __out.Append(__tmp105Line);
                    StringBuilder __tmp106 = new StringBuilder();
                    __tmp106.Append(GetImplParameters(cls, op));
                    using(StreamReader __tmp106Reader = new StreamReader(this.__ToStream(__tmp106.ToString())))
                    {
                        bool __tmp106_first = true;
                        bool __tmp106_last = __tmp106Reader.EndOfStream;
                        while(__tmp106_first || !__tmp106_last)
                        {
                            __tmp106_first = false;
                            string __tmp106Line = __tmp106Reader.ReadLine();
                            __tmp106_last = __tmp106Reader.EndOfStream;
                            if (__tmp106Line != null) __out.Append(__tmp106Line);
                            if (!__tmp106_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp107Line = ")"; //623:135
                    if (__tmp107Line != null) __out.Append(__tmp107Line);
                    __out.AppendLine(false); //623:136
                    __out.Append("    {"); //624:1
                    __out.AppendLine(false); //624:6
                    __out.Append("        throw new NotImplementedException();"); //625:1
                    __out.AppendLine(false); //625:45
                    __out.Append("    }"); //626:1
                    __out.AppendLine(false); //626:6
                }
                __out.AppendLine(true); //628:1
            }
            var __loop48_results = 
                (from __loop48_var1 in __Enumerate((model).GetEnumerator()) //630:8
                from Namespace in __Enumerate((__loop48_var1.Namespace).GetEnumerator()) //630:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //630:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //630:40
                select new { __loop48_var1 = __loop48_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //630:3
            int __loop48_iteration = 0;
            foreach (var __tmp108 in __loop48_results)
            {
                ++__loop48_iteration;
                var __loop48_var1 = __tmp108.__loop48_var1;
                var Namespace = __tmp108.Namespace;
                var Declarations = __tmp108.Declarations;
                var enm = __tmp108.enm;
                var __loop49_results = 
                    (from __loop49_var1 in __Enumerate((enm).GetEnumerator()) //631:11
                    from op in __Enumerate((__loop49_var1.Operations).GetEnumerator()) //631:16
                    select new { __loop49_var1 = __loop49_var1, op = op}
                    ).ToList(); //631:6
                int __loop49_iteration = 0;
                foreach (var __tmp109 in __loop49_results)
                {
                    ++__loop49_iteration;
                    var __loop49_var1 = __tmp109.__loop49_var1;
                    var op = __tmp109.op;
                    __out.AppendLine(true); //632:1
                    __out.Append("    /// <summary>"); //633:1
                    __out.AppendLine(false); //633:18
                    string __tmp111Line = "    /// Implements the operation: "; //634:1
                    if (__tmp111Line != null) __out.Append(__tmp111Line);
                    StringBuilder __tmp112 = new StringBuilder();
                    __tmp112.Append(enm.CSharpName());
                    using(StreamReader __tmp112Reader = new StreamReader(this.__ToStream(__tmp112.ToString())))
                    {
                        bool __tmp112_first = true;
                        bool __tmp112_last = __tmp112Reader.EndOfStream;
                        while(__tmp112_first || !__tmp112_last)
                        {
                            __tmp112_first = false;
                            string __tmp112Line = __tmp112Reader.ReadLine();
                            __tmp112_last = __tmp112Reader.EndOfStream;
                            if (__tmp112Line != null) __out.Append(__tmp112Line);
                            if (!__tmp112_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp113Line = "."; //634:53
                    if (__tmp113Line != null) __out.Append(__tmp113Line);
                    StringBuilder __tmp114 = new StringBuilder();
                    __tmp114.Append(op.Name);
                    using(StreamReader __tmp114Reader = new StreamReader(this.__ToStream(__tmp114.ToString())))
                    {
                        bool __tmp114_first = true;
                        bool __tmp114_last = __tmp114Reader.EndOfStream;
                        while(__tmp114_first || !__tmp114_last)
                        {
                            __tmp114_first = false;
                            string __tmp114Line = __tmp114Reader.ReadLine();
                            __tmp114_last = __tmp114Reader.EndOfStream;
                            if (__tmp114Line != null) __out.Append(__tmp114Line);
                            if (!__tmp114_last) __out.AppendLine(true);
                            __out.AppendLine(false); //634:63
                        }
                    }
                    __out.Append("    /// </summary>"); //635:1
                    __out.AppendLine(false); //635:19
                    string __tmp116Line = "    public virtual "; //636:1
                    if (__tmp116Line != null) __out.Append(__tmp116Line);
                    StringBuilder __tmp117 = new StringBuilder();
                    __tmp117.Append(op.ReturnType.CSharpFullPublicName(ClassKind.Immutable));
                    using(StreamReader __tmp117Reader = new StreamReader(this.__ToStream(__tmp117.ToString())))
                    {
                        bool __tmp117_first = true;
                        bool __tmp117_last = __tmp117Reader.EndOfStream;
                        while(__tmp117_first || !__tmp117_last)
                        {
                            __tmp117_first = false;
                            string __tmp117Line = __tmp117Reader.ReadLine();
                            __tmp117_last = __tmp117Reader.EndOfStream;
                            if (__tmp117Line != null) __out.Append(__tmp117Line);
                            if (!__tmp117_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp118Line = " "; //636:77
                    if (__tmp118Line != null) __out.Append(__tmp118Line);
                    StringBuilder __tmp119 = new StringBuilder();
                    __tmp119.Append(enm.CSharpName());
                    using(StreamReader __tmp119Reader = new StreamReader(this.__ToStream(__tmp119.ToString())))
                    {
                        bool __tmp119_first = true;
                        bool __tmp119_last = __tmp119Reader.EndOfStream;
                        while(__tmp119_first || !__tmp119_last)
                        {
                            __tmp119_first = false;
                            string __tmp119Line = __tmp119Reader.ReadLine();
                            __tmp119_last = __tmp119Reader.EndOfStream;
                            if (__tmp119Line != null) __out.Append(__tmp119Line);
                            if (!__tmp119_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp120Line = "_"; //636:96
                    if (__tmp120Line != null) __out.Append(__tmp120Line);
                    StringBuilder __tmp121 = new StringBuilder();
                    __tmp121.Append(op.Name);
                    using(StreamReader __tmp121Reader = new StreamReader(this.__ToStream(__tmp121.ToString())))
                    {
                        bool __tmp121_first = true;
                        bool __tmp121_last = __tmp121Reader.EndOfStream;
                        while(__tmp121_first || !__tmp121_last)
                        {
                            __tmp121_first = false;
                            string __tmp121Line = __tmp121Reader.ReadLine();
                            __tmp121_last = __tmp121Reader.EndOfStream;
                            if (__tmp121Line != null) __out.Append(__tmp121Line);
                            if (!__tmp121_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp122Line = "("; //636:106
                    if (__tmp122Line != null) __out.Append(__tmp122Line);
                    StringBuilder __tmp123 = new StringBuilder();
                    __tmp123.Append(GetImplParameters(enm, op));
                    using(StreamReader __tmp123Reader = new StreamReader(this.__ToStream(__tmp123.ToString())))
                    {
                        bool __tmp123_first = true;
                        bool __tmp123_last = __tmp123Reader.EndOfStream;
                        while(__tmp123_first || !__tmp123_last)
                        {
                            __tmp123_first = false;
                            string __tmp123Line = __tmp123Reader.ReadLine();
                            __tmp123_last = __tmp123Reader.EndOfStream;
                            if (__tmp123Line != null) __out.Append(__tmp123Line);
                            if (!__tmp123_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp124Line = ")"; //636:135
                    if (__tmp124Line != null) __out.Append(__tmp124Line);
                    __out.AppendLine(false); //636:136
                    __out.Append("    {"); //637:1
                    __out.AppendLine(false); //637:6
                    __out.Append("        throw new NotImplementedException();"); //638:1
                    __out.AppendLine(false); //638:45
                    __out.Append("    }"); //639:1
                    __out.AppendLine(false); //639:6
                }
                __out.AppendLine(true); //641:1
            }
            __out.Append("}"); //643:1
            __out.AppendLine(false); //643:2
            __out.AppendLine(true); //644:1
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //647:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //648:1
            __out.AppendLine(false); //648:14
            __out.Append("/// Factory class for creating instances of model elements."); //649:1
            __out.AppendLine(false); //649:60
            __out.Append("/// </summary>"); //650:1
            __out.AppendLine(false); //650:15
            string __tmp2Line = "public class "; //651:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.CSharpFactoryName());
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(__tmp3_first || !__tmp3_last)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    if (!__tmp3_last) __out.AppendLine(true);
                }
            }
            string __tmp4Line = " : global::MetaDslx.Core.Immutable.ModelFactory"; //651:41
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //651:88
            __out.Append("{"); //652:1
            __out.AppendLine(false); //652:2
            __out.Append("	private bool makeSymbolCreated = true;"); //653:1
            __out.AppendLine(false); //653:40
            __out.AppendLine(true); //654:1
            string __tmp6Line = "    public "; //655:1
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(model.CSharpFactoryName());
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_first = true;
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(__tmp7_first || !__tmp7_last)
                {
                    __tmp7_first = false;
                    string __tmp7Line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    if (__tmp7Line != null) __out.Append(__tmp7Line);
                    if (!__tmp7_last) __out.AppendLine(true);
                }
            }
            string __tmp8Line = "(MutableModel model, ModelFactoryFlags flags = ModelFactoryFlags.MakeSymbolsCreated)"; //655:39
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //655:123
            __out.Append("        : base(model, flags)"); //656:1
            __out.AppendLine(false); //656:29
            __out.Append("    {"); //657:1
            __out.AppendLine(false); //657:6
            string __tmp9Prefix = "		"; //658:1
            StringBuilder __tmp10 = new StringBuilder();
            __tmp10.Append(model.CSharpFullDescriptorName(ClassKind.Immutable));
            using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
            {
                bool __tmp10_first = true;
                bool __tmp10_last = __tmp10Reader.EndOfStream;
                while(__tmp10_first || !__tmp10_last)
                {
                    __tmp10_first = false;
                    string __tmp10Line = __tmp10Reader.ReadLine();
                    __tmp10_last = __tmp10Reader.EndOfStream;
                    __out.Append(__tmp9Prefix);
                    if (__tmp10Line != null) __out.Append(__tmp10Line);
                    if (!__tmp10_last) __out.AppendLine(true);
                }
            }
            string __tmp11Line = ".Initialize();"; //658:56
            if (__tmp11Line != null) __out.Append(__tmp11Line);
            __out.AppendLine(false); //658:70
            __out.Append("    }"); //659:1
            __out.AppendLine(false); //659:6
            __out.AppendLine(true); //660:1
            __out.Append("    public override global::MetaDslx.Core.Immutable.MutableSymbolBase Create(string type)"); //661:1
            __out.AppendLine(false); //661:90
            __out.Append("    {"); //662:1
            __out.AppendLine(false); //662:6
            __out.Append("        switch (type)"); //663:1
            __out.AppendLine(false); //663:22
            __out.Append("        {"); //664:1
            __out.AppendLine(false); //664:10
            var __loop50_results = 
                (from __loop50_var1 in __Enumerate((model).GetEnumerator()) //665:10
                from Namespace in __Enumerate((__loop50_var1.Namespace).GetEnumerator()) //665:17
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //665:28
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //665:42
                select new { __loop50_var1 = __loop50_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //665:5
            int __loop50_iteration = 0;
            foreach (var __tmp12 in __loop50_results)
            {
                ++__loop50_iteration;
                var __loop50_var1 = __tmp12.__loop50_var1;
                var Namespace = __tmp12.Namespace;
                var Declarations = __tmp12.Declarations;
                var cls = __tmp12.cls;
                if (!cls.IsAbstract) //666:6
                {
                    string __tmp14Line = "            case \""; //667:1
                    if (__tmp14Line != null) __out.Append(__tmp14Line);
                    StringBuilder __tmp15 = new StringBuilder();
                    __tmp15.Append(cls.CSharpName());
                    using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
                    {
                        bool __tmp15_first = true;
                        bool __tmp15_last = __tmp15Reader.EndOfStream;
                        while(__tmp15_first || !__tmp15_last)
                        {
                            __tmp15_first = false;
                            string __tmp15Line = __tmp15Reader.ReadLine();
                            __tmp15_last = __tmp15Reader.EndOfStream;
                            if (__tmp15Line != null) __out.Append(__tmp15Line);
                            if (!__tmp15_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp16Line = "\": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this."; //667:37
                    if (__tmp16Line != null) __out.Append(__tmp16Line);
                    StringBuilder __tmp17 = new StringBuilder();
                    __tmp17.Append(cls.CSharpName());
                    using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
                    {
                        bool __tmp17_first = true;
                        bool __tmp17_last = __tmp17Reader.EndOfStream;
                        while(__tmp17_first || !__tmp17_last)
                        {
                            __tmp17_first = false;
                            string __tmp17Line = __tmp17Reader.ReadLine();
                            __tmp17_last = __tmp17Reader.EndOfStream;
                            if (__tmp17Line != null) __out.Append(__tmp17Line);
                            if (!__tmp17_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp18Line = "();"; //667:121
                    if (__tmp18Line != null) __out.Append(__tmp18Line);
                    __out.AppendLine(false); //667:124
                }
            }
            __out.Append("            default:"); //670:1
            __out.AppendLine(false); //670:21
            __out.Append("                throw new ModelException(\"Unknown type name: \" + type);"); //671:1
            __out.AppendLine(false); //671:72
            __out.Append("        }"); //672:1
            __out.AppendLine(false); //672:10
            __out.Append("    }"); //673:1
            __out.AppendLine(false); //673:6
            var __loop51_results = 
                (from __loop51_var1 in __Enumerate((model).GetEnumerator()) //674:8
                from Namespace in __Enumerate((__loop51_var1.Namespace).GetEnumerator()) //674:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //674:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //674:40
                select new { __loop51_var1 = __loop51_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //674:3
            int __loop51_iteration = 0;
            foreach (var __tmp19 in __loop51_results)
            {
                ++__loop51_iteration;
                var __loop51_var1 = __tmp19.__loop51_var1;
                var Namespace = __tmp19.Namespace;
                var Declarations = __tmp19.Declarations;
                var cls = __tmp19.cls;
                if (!cls.IsAbstract) //675:4
                {
                    __out.AppendLine(true); //676:1
                    __out.Append("    /// <summary>"); //677:1
                    __out.AppendLine(false); //677:18
                    string __tmp21Line = "    /// Creates a new instance of "; //678:1
                    if (__tmp21Line != null) __out.Append(__tmp21Line);
                    StringBuilder __tmp22 = new StringBuilder();
                    __tmp22.Append(cls.CSharpName());
                    using(StreamReader __tmp22Reader = new StreamReader(this.__ToStream(__tmp22.ToString())))
                    {
                        bool __tmp22_first = true;
                        bool __tmp22_last = __tmp22Reader.EndOfStream;
                        while(__tmp22_first || !__tmp22_last)
                        {
                            __tmp22_first = false;
                            string __tmp22Line = __tmp22Reader.ReadLine();
                            __tmp22_last = __tmp22Reader.EndOfStream;
                            if (__tmp22Line != null) __out.Append(__tmp22Line);
                            if (!__tmp22_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp23Line = "."; //678:53
                    if (__tmp23Line != null) __out.Append(__tmp23Line);
                    __out.AppendLine(false); //678:54
                    __out.Append("    /// </summary>"); //679:1
                    __out.AppendLine(false); //679:19
                    string __tmp25Line = "    public "; //680:1
                    if (__tmp25Line != null) __out.Append(__tmp25Line);
                    StringBuilder __tmp26 = new StringBuilder();
                    __tmp26.Append(cls.CSharpName(ClassKind.Builder));
                    using(StreamReader __tmp26Reader = new StreamReader(this.__ToStream(__tmp26.ToString())))
                    {
                        bool __tmp26_first = true;
                        bool __tmp26_last = __tmp26Reader.EndOfStream;
                        while(__tmp26_first || !__tmp26_last)
                        {
                            __tmp26_first = false;
                            string __tmp26Line = __tmp26Reader.ReadLine();
                            __tmp26_last = __tmp26Reader.EndOfStream;
                            if (__tmp26Line != null) __out.Append(__tmp26Line);
                            if (!__tmp26_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp27Line = " "; //680:47
                    if (__tmp27Line != null) __out.Append(__tmp27Line);
                    StringBuilder __tmp28 = new StringBuilder();
                    __tmp28.Append(cls.CSharpName());
                    using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
                    {
                        bool __tmp28_first = true;
                        bool __tmp28_last = __tmp28Reader.EndOfStream;
                        while(__tmp28_first || !__tmp28_last)
                        {
                            __tmp28_first = false;
                            string __tmp28Line = __tmp28Reader.ReadLine();
                            __tmp28_last = __tmp28Reader.EndOfStream;
                            if (__tmp28Line != null) __out.Append(__tmp28Line);
                            if (!__tmp28_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp29Line = "()"; //680:66
                    if (__tmp29Line != null) __out.Append(__tmp29Line);
                    __out.AppendLine(false); //680:68
                    __out.Append("	{"); //681:1
                    __out.AppendLine(false); //681:3
                    string __tmp31Line = "		global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new "; //682:1
                    if (__tmp31Line != null) __out.Append(__tmp31Line);
                    StringBuilder __tmp32 = new StringBuilder();
                    __tmp32.Append(cls.CSharpName(ClassKind.Id));
                    using(StreamReader __tmp32Reader = new StreamReader(this.__ToStream(__tmp32.ToString())))
                    {
                        bool __tmp32_first = true;
                        bool __tmp32_last = __tmp32Reader.EndOfStream;
                        while(__tmp32_first || !__tmp32_last)
                        {
                            __tmp32_first = false;
                            string __tmp32Line = __tmp32Reader.ReadLine();
                            __tmp32_last = __tmp32Reader.EndOfStream;
                            if (__tmp32Line != null) __out.Append(__tmp32Line);
                            if (!__tmp32_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp33Line = "());"; //682:114
                    if (__tmp33Line != null) __out.Append(__tmp33Line);
                    __out.AppendLine(false); //682:118
                    string __tmp35Line = "		return ("; //683:1
                    if (__tmp35Line != null) __out.Append(__tmp35Line);
                    StringBuilder __tmp36 = new StringBuilder();
                    __tmp36.Append(cls.CSharpName(ClassKind.Builder));
                    using(StreamReader __tmp36Reader = new StreamReader(this.__ToStream(__tmp36.ToString())))
                    {
                        bool __tmp36_first = true;
                        bool __tmp36_last = __tmp36Reader.EndOfStream;
                        while(__tmp36_first || !__tmp36_last)
                        {
                            __tmp36_first = false;
                            string __tmp36Line = __tmp36Reader.ReadLine();
                            __tmp36_last = __tmp36Reader.EndOfStream;
                            if (__tmp36Line != null) __out.Append(__tmp36Line);
                            if (!__tmp36_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp37Line = ")symbol;"; //683:46
                    if (__tmp37Line != null) __out.Append(__tmp37Line);
                    __out.AppendLine(false); //683:54
                    __out.Append("	}"); //684:1
                    __out.AppendLine(false); //684:3
                }
            }
            __out.Append("}"); //687:1
            __out.AppendLine(false); //687:2
            __out.AppendLine(true); //688:1
            return __out.ToString();
        }

        public string GenerateMetaModelInstance(MetaModel model) //692:1
        {
            StringBuilder __out = new StringBuilder();
            Dictionary<ModelObject,string> mobjToName = model.GetNamedModelObjects(); //693:2
            bool coreModel = model.CSharpFullName(ClassKind.Immutable) == "global::MetaDslx.Core.Immutable.Meta"; //694:2
            string __tmp2Line = "internal class "; //695:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.CSharpInstancesName(ClassKind.Builder));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(__tmp3_first || !__tmp3_last)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    if (!__tmp3_last) __out.AppendLine(true);
                    __out.AppendLine(false); //695:62
                }
            }
            __out.Append("{"); //696:1
            __out.AppendLine(false); //696:2
            string __tmp5Line = "	internal static "; //697:1
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(model.CSharpInstancesName(ClassKind.Builder));
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(__tmp6_first || !__tmp6_last)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if (__tmp6Line != null) __out.Append(__tmp6Line);
                    if (!__tmp6_last) __out.AppendLine(true);
                }
            }
            string __tmp7Line = " instance = new "; //697:64
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(model.CSharpInstancesName(ClassKind.Builder));
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_first = true;
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(__tmp8_first || !__tmp8_last)
                {
                    __tmp8_first = false;
                    string __tmp8Line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if (__tmp8Line != null) __out.Append(__tmp8Line);
                    if (!__tmp8_last) __out.AppendLine(true);
                }
            }
            string __tmp9Line = "();"; //697:126
            if (__tmp9Line != null) __out.Append(__tmp9Line);
            __out.AppendLine(false); //697:129
            __out.AppendLine(true); //698:1
            if (coreModel) //699:3
            {
                __out.Append("	internal readonly global::MetaDslx.Core.Immutable.MetaModelBuilder _MetaModel;"); //700:1
                __out.AppendLine(false); //700:80
            }
            else //701:3
            {
                __out.Append("	internal readonly global::MetaDslx.Core.Immutable.MetaModelBuilder MetaModel;"); //702:1
                __out.AppendLine(false); //702:79
            }
            __out.AppendLine(true); //704:1
            var __loop52_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //705:11
                select new { mobj = mobj}
                ).ToList(); //705:6
            int __loop52_iteration = 0;
            foreach (var __tmp10 in __loop52_results)
            {
                ++__loop52_iteration;
                var mobj = __tmp10.mobj;
                string __tmp11Prefix = "	"; //706:1
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(GenerateModelObjectInstanceDeclaration(mobj, mobjToName));
                using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
                {
                    bool __tmp12_first = true;
                    bool __tmp12_last = __tmp12Reader.EndOfStream;
                    while(__tmp12_first || !__tmp12_last)
                    {
                        __tmp12_first = false;
                        string __tmp12Line = __tmp12Reader.ReadLine();
                        __tmp12_last = __tmp12Reader.EndOfStream;
                        __out.Append(__tmp11Prefix);
                        if (__tmp12Line != null) __out.Append(__tmp12Line);
                        if (!__tmp12_last) __out.AppendLine(true);
                        __out.AppendLine(false); //706:60
                    }
                }
            }
            __out.AppendLine(true); //708:1
            string __tmp14Line = "    private "; //709:1
            if (__tmp14Line != null) __out.Append(__tmp14Line);
            StringBuilder __tmp15 = new StringBuilder();
            __tmp15.Append(model.CSharpInstancesName(ClassKind.Builder));
            using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
            {
                bool __tmp15_first = true;
                bool __tmp15_last = __tmp15Reader.EndOfStream;
                while(__tmp15_first || !__tmp15_last)
                {
                    __tmp15_first = false;
                    string __tmp15Line = __tmp15Reader.ReadLine();
                    __tmp15_last = __tmp15Reader.EndOfStream;
                    if (__tmp15Line != null) __out.Append(__tmp15Line);
                    if (!__tmp15_last) __out.AppendLine(true);
                }
            }
            string __tmp16Line = "()"; //709:59
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            __out.AppendLine(false); //709:61
            __out.Append("    {"); //710:1
            __out.AppendLine(false); //710:6
            __out.Append("		global::MetaDslx.Core.Immutable.MutableModel model = new global::MetaDslx.Core.Immutable.MutableModel();"); //711:1
            __out.AppendLine(false); //711:107
            string __tmp17Prefix = "		"; //712:1
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append(model.CSharpFullFactoryName(ClassKind.Immutable));
            using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
            {
                bool __tmp18_first = true;
                bool __tmp18_last = __tmp18Reader.EndOfStream;
                while(__tmp18_first || !__tmp18_last)
                {
                    __tmp18_first = false;
                    string __tmp18Line = __tmp18Reader.ReadLine();
                    __tmp18_last = __tmp18Reader.EndOfStream;
                    __out.Append(__tmp17Prefix);
                    if (__tmp18Line != null) __out.Append(__tmp18Line);
                    if (!__tmp18_last) __out.AppendLine(true);
                }
            }
            string __tmp19Line = " factory = new "; //712:53
            if (__tmp19Line != null) __out.Append(__tmp19Line);
            StringBuilder __tmp20 = new StringBuilder();
            __tmp20.Append(model.CSharpFullFactoryName(ClassKind.Immutable));
            using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
            {
                bool __tmp20_first = true;
                bool __tmp20_last = __tmp20Reader.EndOfStream;
                while(__tmp20_first || !__tmp20_last)
                {
                    __tmp20_first = false;
                    string __tmp20Line = __tmp20Reader.ReadLine();
                    __tmp20_last = __tmp20Reader.EndOfStream;
                    if (__tmp20Line != null) __out.Append(__tmp20Line);
                    if (!__tmp20_last) __out.AppendLine(true);
                }
            }
            string __tmp21Line = "(model, global::MetaDslx.Core.Immutable.ModelFactoryFlags.None);"; //712:118
            if (__tmp21Line != null) __out.Append(__tmp21Line);
            __out.AppendLine(false); //712:182
            __out.AppendLine(true); //713:1
            var __loop53_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //714:9
                select new { mobj = mobj}
                ).ToList(); //714:4
            int __loop53_iteration = 0;
            foreach (var __tmp22 in __loop53_results)
            {
                ++__loop53_iteration;
                var mobj = __tmp22.mobj;
                string __tmp23Prefix = "		"; //715:1
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(GenerateModelObjectInstance(coreModel, mobj, mobjToName));
                using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
                {
                    bool __tmp24_first = true;
                    bool __tmp24_last = __tmp24Reader.EndOfStream;
                    while(__tmp24_first || !__tmp24_last)
                    {
                        __tmp24_first = false;
                        string __tmp24Line = __tmp24Reader.ReadLine();
                        __tmp24_last = __tmp24Reader.EndOfStream;
                        __out.Append(__tmp23Prefix);
                        if (__tmp24Line != null) __out.Append(__tmp24Line);
                        if (!__tmp24_last) __out.AppendLine(true);
                        __out.AppendLine(false); //715:61
                    }
                }
            }
            __out.AppendLine(true); //717:1
            var __loop54_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //718:9
                select new { mobj = mobj}
                ).ToList(); //718:4
            int __loop54_iteration = 0;
            foreach (var __tmp25 in __loop54_results)
            {
                ++__loop54_iteration;
                var mobj = __tmp25.mobj;
                string __tmp26Prefix = "		"; //719:1
                StringBuilder __tmp27 = new StringBuilder();
                __tmp27.Append(GenerateModelObjectInstanceInitializer(coreModel, mobj, mobjToName));
                using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
                {
                    bool __tmp27_first = true;
                    bool __tmp27_last = __tmp27Reader.EndOfStream;
                    while(__tmp27_first || !__tmp27_last)
                    {
                        __tmp27_first = false;
                        string __tmp27Line = __tmp27Reader.ReadLine();
                        __tmp27_last = __tmp27Reader.EndOfStream;
                        __out.Append(__tmp26Prefix);
                        if (__tmp27Line != null) __out.Append(__tmp27Line);
                        if (!__tmp27_last) __out.AppendLine(true);
                        __out.AppendLine(false); //719:72
                    }
                }
            }
            __out.AppendLine(true); //721:1
            var __loop55_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //722:9
                select new { mobj = mobj}
                ).ToList(); //722:4
            int __loop55_iteration = 0;
            foreach (var __tmp28 in __loop55_results)
            {
                ++__loop55_iteration;
                var mobj = __tmp28.mobj;
                string __tmp29Prefix = "		"; //723:1
                StringBuilder __tmp30 = new StringBuilder();
                __tmp30.Append(GenerateModelObjectInstanceFinalizer(mobj, mobjToName));
                using(StreamReader __tmp30Reader = new StreamReader(this.__ToStream(__tmp30.ToString())))
                {
                    bool __tmp30_first = true;
                    bool __tmp30_last = __tmp30Reader.EndOfStream;
                    while(__tmp30_first || !__tmp30_last)
                    {
                        __tmp30_first = false;
                        string __tmp30Line = __tmp30Reader.ReadLine();
                        __tmp30_last = __tmp30Reader.EndOfStream;
                        __out.Append(__tmp29Prefix);
                        if (__tmp30Line != null) __out.Append(__tmp30Line);
                        if (!__tmp30_last) __out.AppendLine(true);
                        __out.AppendLine(false); //723:59
                    }
                }
            }
            __out.AppendLine(true); //725:1
            __out.Append("        model.EvaluateLazyValues();"); //726:1
            __out.AppendLine(false); //726:36
            __out.Append("    }"); //727:1
            __out.AppendLine(false); //727:6
            __out.Append("}"); //728:1
            __out.AppendLine(false); //728:2
            __out.AppendLine(true); //729:1
            string __tmp32Line = "public class "; //730:1
            if (__tmp32Line != null) __out.Append(__tmp32Line);
            StringBuilder __tmp33 = new StringBuilder();
            __tmp33.Append(model.CSharpInstancesName(ClassKind.Immutable));
            using(StreamReader __tmp33Reader = new StreamReader(this.__ToStream(__tmp33.ToString())))
            {
                bool __tmp33_first = true;
                bool __tmp33_last = __tmp33Reader.EndOfStream;
                while(__tmp33_first || !__tmp33_last)
                {
                    __tmp33_first = false;
                    string __tmp33Line = __tmp33Reader.ReadLine();
                    __tmp33_last = __tmp33Reader.EndOfStream;
                    if (__tmp33Line != null) __out.Append(__tmp33Line);
                    if (!__tmp33_last) __out.AppendLine(true);
                    __out.AppendLine(false); //730:62
                }
            }
            __out.Append("{"); //731:1
            __out.AppendLine(false); //731:2
            __out.AppendLine(true); //732:1
            __out.Append("	private static bool initialized;"); //733:1
            __out.AppendLine(false); //733:34
            __out.AppendLine(true); //734:1
            __out.Append("	public static bool IsInitialized"); //735:1
            __out.AppendLine(false); //735:34
            __out.Append("	{"); //736:1
            __out.AppendLine(false); //736:3
            string __tmp35Line = "		get { return "; //737:1
            if (__tmp35Line != null) __out.Append(__tmp35Line);
            StringBuilder __tmp36 = new StringBuilder();
            __tmp36.Append(model.CSharpInstancesName(ClassKind.Immutable));
            using(StreamReader __tmp36Reader = new StreamReader(this.__ToStream(__tmp36.ToString())))
            {
                bool __tmp36_first = true;
                bool __tmp36_last = __tmp36Reader.EndOfStream;
                while(__tmp36_first || !__tmp36_last)
                {
                    __tmp36_first = false;
                    string __tmp36Line = __tmp36Reader.ReadLine();
                    __tmp36_last = __tmp36Reader.EndOfStream;
                    if (__tmp36Line != null) __out.Append(__tmp36Line);
                    if (!__tmp36_last) __out.AppendLine(true);
                }
            }
            string __tmp37Line = ".initialized; }"; //737:64
            if (__tmp37Line != null) __out.Append(__tmp37Line);
            __out.AppendLine(false); //737:79
            __out.Append("	}"); //738:1
            __out.AppendLine(false); //738:3
            __out.AppendLine(true); //739:1
            if (coreModel) //740:3
            {
                __out.Append("	public static readonly global::MetaDslx.Core.Immutable.MetaModel _MetaModel;"); //741:1
                __out.AppendLine(false); //741:78
            }
            else //742:3
            {
                __out.Append("	public static readonly global::MetaDslx.Core.Immutable.MetaModel MetaModel;"); //743:1
                __out.AppendLine(false); //743:77
            }
            __out.AppendLine(true); //745:1
            var __loop56_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //746:11
                where mobjToName.ContainsKey(mobj) && !mobjToName[mobj].StartsWith("__") //746:26
                select new { mobj = mobj}
                ).ToList(); //746:6
            int __loop56_iteration = 0;
            foreach (var __tmp38 in __loop56_results)
            {
                ++__loop56_iteration;
                var mobj = __tmp38.mobj;
                string __tmp39Prefix = "	"; //747:1
                StringBuilder __tmp40 = new StringBuilder();
                __tmp40.Append(GenerateImmutableModelObjectInstanceDeclaration(model, mobj, mobjToName));
                using(StreamReader __tmp40Reader = new StreamReader(this.__ToStream(__tmp40.ToString())))
                {
                    bool __tmp40_first = true;
                    bool __tmp40_last = __tmp40Reader.EndOfStream;
                    while(__tmp40_first || !__tmp40_last)
                    {
                        __tmp40_first = false;
                        string __tmp40Line = __tmp40Reader.ReadLine();
                        __tmp40_last = __tmp40Reader.EndOfStream;
                        __out.Append(__tmp39Prefix);
                        if (__tmp40Line != null) __out.Append(__tmp40Line);
                        if (!__tmp40_last) __out.AppendLine(true);
                        __out.AppendLine(false); //747:76
                    }
                }
            }
            __out.AppendLine(true); //749:1
            string __tmp42Line = "	static "; //750:1
            if (__tmp42Line != null) __out.Append(__tmp42Line);
            StringBuilder __tmp43 = new StringBuilder();
            __tmp43.Append(model.CSharpInstancesName(ClassKind.Immutable));
            using(StreamReader __tmp43Reader = new StreamReader(this.__ToStream(__tmp43.ToString())))
            {
                bool __tmp43_first = true;
                bool __tmp43_last = __tmp43Reader.EndOfStream;
                while(__tmp43_first || !__tmp43_last)
                {
                    __tmp43_first = false;
                    string __tmp43Line = __tmp43Reader.ReadLine();
                    __tmp43_last = __tmp43Reader.EndOfStream;
                    if (__tmp43Line != null) __out.Append(__tmp43Line);
                    if (!__tmp43_last) __out.AppendLine(true);
                }
            }
            string __tmp44Line = "()"; //750:57
            if (__tmp44Line != null) __out.Append(__tmp44Line);
            __out.AppendLine(false); //750:59
            __out.Append("	{"); //751:1
            __out.AppendLine(false); //751:3
            if (coreModel) //752:4
            {
                string __tmp45Prefix = "		"; //753:1
                StringBuilder __tmp46 = new StringBuilder();
                __tmp46.Append(model.CSharpInstancesName(ClassKind.Immutable));
                using(StreamReader __tmp46Reader = new StreamReader(this.__ToStream(__tmp46.ToString())))
                {
                    bool __tmp46_first = true;
                    bool __tmp46_last = __tmp46Reader.EndOfStream;
                    while(__tmp46_first || !__tmp46_last)
                    {
                        __tmp46_first = false;
                        string __tmp46Line = __tmp46Reader.ReadLine();
                        __tmp46_last = __tmp46Reader.EndOfStream;
                        __out.Append(__tmp45Prefix);
                        if (__tmp46Line != null) __out.Append(__tmp46Line);
                        if (!__tmp46_last) __out.AppendLine(true);
                    }
                }
                string __tmp47Line = "._MetaModel = "; //753:51
                if (__tmp47Line != null) __out.Append(__tmp47Line);
                StringBuilder __tmp48 = new StringBuilder();
                __tmp48.Append(model.CSharpInstancesName(ClassKind.Builder));
                using(StreamReader __tmp48Reader = new StreamReader(this.__ToStream(__tmp48.ToString())))
                {
                    bool __tmp48_first = true;
                    bool __tmp48_last = __tmp48Reader.EndOfStream;
                    while(__tmp48_first || !__tmp48_last)
                    {
                        __tmp48_first = false;
                        string __tmp48Line = __tmp48Reader.ReadLine();
                        __tmp48_last = __tmp48Reader.EndOfStream;
                        if (__tmp48Line != null) __out.Append(__tmp48Line);
                        if (!__tmp48_last) __out.AppendLine(true);
                    }
                }
                string __tmp49Line = ".instance._MetaModel.ToImmutable();"; //753:111
                if (__tmp49Line != null) __out.Append(__tmp49Line);
                __out.AppendLine(false); //753:146
            }
            else //754:4
            {
                string __tmp50Prefix = "		"; //755:1
                StringBuilder __tmp51 = new StringBuilder();
                __tmp51.Append(model.CSharpInstancesName(ClassKind.Immutable));
                using(StreamReader __tmp51Reader = new StreamReader(this.__ToStream(__tmp51.ToString())))
                {
                    bool __tmp51_first = true;
                    bool __tmp51_last = __tmp51Reader.EndOfStream;
                    while(__tmp51_first || !__tmp51_last)
                    {
                        __tmp51_first = false;
                        string __tmp51Line = __tmp51Reader.ReadLine();
                        __tmp51_last = __tmp51Reader.EndOfStream;
                        __out.Append(__tmp50Prefix);
                        if (__tmp51Line != null) __out.Append(__tmp51Line);
                        if (!__tmp51_last) __out.AppendLine(true);
                    }
                }
                string __tmp52Line = ".MetaModel = "; //755:51
                if (__tmp52Line != null) __out.Append(__tmp52Line);
                StringBuilder __tmp53 = new StringBuilder();
                __tmp53.Append(model.CSharpInstancesName(ClassKind.Builder));
                using(StreamReader __tmp53Reader = new StreamReader(this.__ToStream(__tmp53.ToString())))
                {
                    bool __tmp53_first = true;
                    bool __tmp53_last = __tmp53Reader.EndOfStream;
                    while(__tmp53_first || !__tmp53_last)
                    {
                        __tmp53_first = false;
                        string __tmp53Line = __tmp53Reader.ReadLine();
                        __tmp53_last = __tmp53Reader.EndOfStream;
                        if (__tmp53Line != null) __out.Append(__tmp53Line);
                        if (!__tmp53_last) __out.AppendLine(true);
                    }
                }
                string __tmp54Line = ".instance.MetaModel.ToImmutable();"; //755:110
                if (__tmp54Line != null) __out.Append(__tmp54Line);
                __out.AppendLine(false); //755:144
            }
            __out.AppendLine(true); //757:1
            var __loop57_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //758:9
                where mobjToName.ContainsKey(mobj) && !mobjToName[mobj].StartsWith("__") //758:24
                select new { mobj = mobj}
                ).ToList(); //758:4
            int __loop57_iteration = 0;
            foreach (var __tmp55 in __loop57_results)
            {
                ++__loop57_iteration;
                var mobj = __tmp55.mobj;
                string __tmp56Prefix = "		"; //759:1
                StringBuilder __tmp57 = new StringBuilder();
                __tmp57.Append(GenerateImmutableModelObjectInstanceDeclarationInitializer(model, mobj, mobjToName));
                using(StreamReader __tmp57Reader = new StreamReader(this.__ToStream(__tmp57.ToString())))
                {
                    bool __tmp57_first = true;
                    bool __tmp57_last = __tmp57Reader.EndOfStream;
                    while(__tmp57_first || !__tmp57_last)
                    {
                        __tmp57_first = false;
                        string __tmp57Line = __tmp57Reader.ReadLine();
                        __tmp57_last = __tmp57Reader.EndOfStream;
                        __out.Append(__tmp56Prefix);
                        if (__tmp57Line != null) __out.Append(__tmp57Line);
                        if (!__tmp57_last) __out.AppendLine(true);
                        __out.AppendLine(false); //759:88
                    }
                }
            }
            __out.AppendLine(true); //761:1
            string __tmp58Prefix = "		"; //762:1
            StringBuilder __tmp59 = new StringBuilder();
            __tmp59.Append(model.CSharpInstancesName(ClassKind.Immutable));
            using(StreamReader __tmp59Reader = new StreamReader(this.__ToStream(__tmp59.ToString())))
            {
                bool __tmp59_first = true;
                bool __tmp59_last = __tmp59Reader.EndOfStream;
                while(__tmp59_first || !__tmp59_last)
                {
                    __tmp59_first = false;
                    string __tmp59Line = __tmp59Reader.ReadLine();
                    __tmp59_last = __tmp59Reader.EndOfStream;
                    __out.Append(__tmp58Prefix);
                    if (__tmp59Line != null) __out.Append(__tmp59Line);
                    if (!__tmp59_last) __out.AppendLine(true);
                }
            }
            string __tmp60Line = ".initialized = true;"; //762:51
            if (__tmp60Line != null) __out.Append(__tmp60Line);
            __out.AppendLine(false); //762:71
            __out.Append("	}"); //763:1
            __out.AppendLine(false); //763:3
            __out.Append("}"); //764:1
            __out.AppendLine(false); //764:2
            return __out.ToString();
        }

        public string GenerateImmutableModelObjectInstanceDeclaration(MetaModel model, ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //767:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //768:2
            {
                if (mobjToName.ContainsKey(mobj)) //769:3
                {
                    if (!mobjToName[mobj].StartsWith("__")) //770:4
                    {
                        string name = mobjToName[mobj]; //771:2
                        if (mobj is MetaDocumentedElement) //772:5
                        {
                            StringBuilder __tmp2 = new StringBuilder();
                            __tmp2.Append(GenerateDocumentation(((MetaDocumentedElement)mobj)));
                            using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
                            {
                                bool __tmp2_first = true;
                                bool __tmp2_last = __tmp2Reader.EndOfStream;
                                while(__tmp2_first || !__tmp2_last)
                                {
                                    __tmp2_first = false;
                                    string __tmp2Line = __tmp2Reader.ReadLine();
                                    __tmp2_last = __tmp2Reader.EndOfStream;
                                    if (__tmp2Line != null) __out.Append(__tmp2Line);
                                    if (!__tmp2_last) __out.AppendLine(true);
                                    __out.AppendLine(false); //773:55
                                }
                            }
                        }
                        string __tmp4Line = "public static readonly global::MetaDslx.Core.Immutable."; //775:1
                        if (__tmp4Line != null) __out.Append(__tmp4Line);
                        StringBuilder __tmp5 = new StringBuilder();
                        __tmp5.Append(mobj.MMetaClass.CSharpName(ClassKind.Immutable));
                        using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                        {
                            bool __tmp5_first = true;
                            bool __tmp5_last = __tmp5Reader.EndOfStream;
                            while(__tmp5_first || !__tmp5_last)
                            {
                                __tmp5_first = false;
                                string __tmp5Line = __tmp5Reader.ReadLine();
                                __tmp5_last = __tmp5Reader.EndOfStream;
                                if (__tmp5Line != null) __out.Append(__tmp5Line);
                                if (!__tmp5_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp6Line = " "; //775:105
                        if (__tmp6Line != null) __out.Append(__tmp6Line);
                        StringBuilder __tmp7 = new StringBuilder();
                        __tmp7.Append(name);
                        using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
                        {
                            bool __tmp7_first = true;
                            bool __tmp7_last = __tmp7Reader.EndOfStream;
                            while(__tmp7_first || !__tmp7_last)
                            {
                                __tmp7_first = false;
                                string __tmp7Line = __tmp7Reader.ReadLine();
                                __tmp7_last = __tmp7Reader.EndOfStream;
                                if (__tmp7Line != null) __out.Append(__tmp7Line);
                                if (!__tmp7_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp8Line = ";"; //775:112
                        if (__tmp8Line != null) __out.Append(__tmp8Line);
                        __out.AppendLine(false); //775:113
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateImmutableModelObjectInstanceDeclarationInitializer(MetaModel model, ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //781:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //782:2
            {
                if (mobjToName.ContainsKey(mobj)) //783:3
                {
                    if (!mobjToName[mobj].StartsWith("__")) //784:4
                    {
                        string name = mobjToName[mobj]; //785:2
                        StringBuilder __tmp2 = new StringBuilder();
                        __tmp2.Append(model.CSharpInstancesName(ClassKind.Immutable));
                        using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
                        {
                            bool __tmp2_first = true;
                            bool __tmp2_last = __tmp2Reader.EndOfStream;
                            while(__tmp2_first || !__tmp2_last)
                            {
                                __tmp2_first = false;
                                string __tmp2Line = __tmp2Reader.ReadLine();
                                __tmp2_last = __tmp2Reader.EndOfStream;
                                if (__tmp2Line != null) __out.Append(__tmp2Line);
                                if (!__tmp2_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp3Line = "."; //786:49
                        if (__tmp3Line != null) __out.Append(__tmp3Line);
                        StringBuilder __tmp4 = new StringBuilder();
                        __tmp4.Append(name);
                        using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                        {
                            bool __tmp4_first = true;
                            bool __tmp4_last = __tmp4Reader.EndOfStream;
                            while(__tmp4_first || !__tmp4_last)
                            {
                                __tmp4_first = false;
                                string __tmp4Line = __tmp4Reader.ReadLine();
                                __tmp4_last = __tmp4Reader.EndOfStream;
                                if (__tmp4Line != null) __out.Append(__tmp4Line);
                                if (!__tmp4_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp5Line = " = "; //786:56
                        if (__tmp5Line != null) __out.Append(__tmp5Line);
                        StringBuilder __tmp6 = new StringBuilder();
                        __tmp6.Append(model.CSharpInstancesName(ClassKind.Builder));
                        using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
                        {
                            bool __tmp6_first = true;
                            bool __tmp6_last = __tmp6Reader.EndOfStream;
                            while(__tmp6_first || !__tmp6_last)
                            {
                                __tmp6_first = false;
                                string __tmp6Line = __tmp6Reader.ReadLine();
                                __tmp6_last = __tmp6Reader.EndOfStream;
                                if (__tmp6Line != null) __out.Append(__tmp6Line);
                                if (!__tmp6_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp7Line = ".instance."; //786:105
                        if (__tmp7Line != null) __out.Append(__tmp7Line);
                        StringBuilder __tmp8 = new StringBuilder();
                        __tmp8.Append(name);
                        using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                        {
                            bool __tmp8_first = true;
                            bool __tmp8_last = __tmp8Reader.EndOfStream;
                            while(__tmp8_first || !__tmp8_last)
                            {
                                __tmp8_first = false;
                                string __tmp8Line = __tmp8Reader.ReadLine();
                                __tmp8_last = __tmp8Reader.EndOfStream;
                                if (__tmp8Line != null) __out.Append(__tmp8Line);
                                if (!__tmp8_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp9Line = ".ToImmutable();"; //786:121
                        if (__tmp9Line != null) __out.Append(__tmp9Line);
                        __out.AppendLine(false); //786:136
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceDeclaration(ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //792:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //793:2
            {
                if (mobjToName.ContainsKey(mobj)) //794:3
                {
                    string name = mobjToName[mobj]; //795:4
                    if (name.StartsWith("__")) //796:4
                    {
                        string __tmp2Line = "private readonly global::MetaDslx.Core.Immutable."; //797:1
                        if (__tmp2Line != null) __out.Append(__tmp2Line);
                        StringBuilder __tmp3 = new StringBuilder();
                        __tmp3.Append(mobj.MMetaClass.CSharpName(ClassKind.Builder));
                        using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                        {
                            bool __tmp3_first = true;
                            bool __tmp3_last = __tmp3Reader.EndOfStream;
                            while(__tmp3_first || !__tmp3_last)
                            {
                                __tmp3_first = false;
                                string __tmp3Line = __tmp3Reader.ReadLine();
                                __tmp3_last = __tmp3Reader.EndOfStream;
                                if (__tmp3Line != null) __out.Append(__tmp3Line);
                                if (!__tmp3_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp4Line = " "; //797:97
                        if (__tmp4Line != null) __out.Append(__tmp4Line);
                        StringBuilder __tmp5 = new StringBuilder();
                        __tmp5.Append(name);
                        using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                        {
                            bool __tmp5_first = true;
                            bool __tmp5_last = __tmp5Reader.EndOfStream;
                            while(__tmp5_first || !__tmp5_last)
                            {
                                __tmp5_first = false;
                                string __tmp5Line = __tmp5Reader.ReadLine();
                                __tmp5_last = __tmp5Reader.EndOfStream;
                                if (__tmp5Line != null) __out.Append(__tmp5Line);
                                if (!__tmp5_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp6Line = ";"; //797:104
                        if (__tmp6Line != null) __out.Append(__tmp6Line);
                        __out.AppendLine(false); //797:105
                    }
                    else //798:4
                    {
                        string __tmp8Line = "internal readonly global::MetaDslx.Core.Immutable."; //799:1
                        if (__tmp8Line != null) __out.Append(__tmp8Line);
                        StringBuilder __tmp9 = new StringBuilder();
                        __tmp9.Append(mobj.MMetaClass.CSharpName(ClassKind.Builder));
                        using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                        {
                            bool __tmp9_first = true;
                            bool __tmp9_last = __tmp9Reader.EndOfStream;
                            while(__tmp9_first || !__tmp9_last)
                            {
                                __tmp9_first = false;
                                string __tmp9Line = __tmp9Reader.ReadLine();
                                __tmp9_last = __tmp9Reader.EndOfStream;
                                if (__tmp9Line != null) __out.Append(__tmp9Line);
                                if (!__tmp9_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp10Line = " "; //799:98
                        if (__tmp10Line != null) __out.Append(__tmp10Line);
                        StringBuilder __tmp11 = new StringBuilder();
                        __tmp11.Append(name);
                        using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                        {
                            bool __tmp11_first = true;
                            bool __tmp11_last = __tmp11Reader.EndOfStream;
                            while(__tmp11_first || !__tmp11_last)
                            {
                                __tmp11_first = false;
                                string __tmp11Line = __tmp11Reader.ReadLine();
                                __tmp11_last = __tmp11Reader.EndOfStream;
                                if (__tmp11Line != null) __out.Append(__tmp11Line);
                                if (!__tmp11_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp12Line = ";"; //799:105
                        if (__tmp12Line != null) __out.Append(__tmp12Line);
                        __out.AppendLine(false); //799:106
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstance(bool coreModel, ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //805:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //806:2
            {
                if (mobjToName.ContainsKey(mobj)) //807:3
                {
                    string name = mobjToName[mobj]; //808:4
                    StringBuilder __tmp2 = new StringBuilder();
                    __tmp2.Append(name);
                    using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
                    {
                        bool __tmp2_first = true;
                        bool __tmp2_last = __tmp2Reader.EndOfStream;
                        while(__tmp2_first || !__tmp2_last)
                        {
                            __tmp2_first = false;
                            string __tmp2Line = __tmp2Reader.ReadLine();
                            __tmp2_last = __tmp2Reader.EndOfStream;
                            if (__tmp2Line != null) __out.Append(__tmp2Line);
                            if (!__tmp2_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp3Line = " = factory."; //809:7
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    StringBuilder __tmp4 = new StringBuilder();
                    __tmp4.Append(mobj.MMetaClass.CSharpName());
                    using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                    {
                        bool __tmp4_first = true;
                        bool __tmp4_last = __tmp4Reader.EndOfStream;
                        while(__tmp4_first || !__tmp4_last)
                        {
                            __tmp4_first = false;
                            string __tmp4Line = __tmp4Reader.ReadLine();
                            __tmp4_last = __tmp4Reader.EndOfStream;
                            if (__tmp4Line != null) __out.Append(__tmp4Line);
                            if (!__tmp4_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp5Line = "();"; //809:48
                    if (__tmp5Line != null) __out.Append(__tmp5Line);
                    __out.AppendLine(false); //809:51
                    if (mobj is MetaModel) //810:4
                    {
                        if (coreModel) //811:5
                        {
                            string __tmp7Line = "_MetaModel = "; //812:1
                            if (__tmp7Line != null) __out.Append(__tmp7Line);
                            StringBuilder __tmp8 = new StringBuilder();
                            __tmp8.Append(name);
                            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                            {
                                bool __tmp8_first = true;
                                bool __tmp8_last = __tmp8Reader.EndOfStream;
                                while(__tmp8_first || !__tmp8_last)
                                {
                                    __tmp8_first = false;
                                    string __tmp8Line = __tmp8Reader.ReadLine();
                                    __tmp8_last = __tmp8Reader.EndOfStream;
                                    if (__tmp8Line != null) __out.Append(__tmp8Line);
                                    if (!__tmp8_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp9Line = ";"; //812:20
                            if (__tmp9Line != null) __out.Append(__tmp9Line);
                            __out.AppendLine(false); //812:21
                        }
                        else //813:5
                        {
                            string __tmp11Line = "MetaModel = "; //814:1
                            if (__tmp11Line != null) __out.Append(__tmp11Line);
                            StringBuilder __tmp12 = new StringBuilder();
                            __tmp12.Append(name);
                            using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
                            {
                                bool __tmp12_first = true;
                                bool __tmp12_last = __tmp12Reader.EndOfStream;
                                while(__tmp12_first || !__tmp12_last)
                                {
                                    __tmp12_first = false;
                                    string __tmp12Line = __tmp12Reader.ReadLine();
                                    __tmp12_last = __tmp12Reader.EndOfStream;
                                    if (__tmp12Line != null) __out.Append(__tmp12Line);
                                    if (!__tmp12_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp13Line = ";"; //814:19
                            if (__tmp13Line != null) __out.Append(__tmp13Line);
                            __out.AppendLine(false); //814:20
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceInitializer(bool coreModel, ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //821:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //822:2
            {
                if (mobjToName.ContainsKey(mobj)) //823:3
                {
                    var __loop58_results = 
                        (from __loop58_var1 in __Enumerate((mobj).GetEnumerator()) //824:9
                        from prop in __Enumerate((__loop58_var1.MGetProperties()).GetEnumerator()) //824:15
                        where !prop.IsReadonly //824:37
                        select new { __loop58_var1 = __loop58_var1, prop = prop}
                        ).ToList(); //824:4
                    int __loop58_iteration = 0;
                    foreach (var __tmp1 in __loop58_results)
                    {
                        ++__loop58_iteration;
                        var __loop58_var1 = __tmp1.__loop58_var1;
                        var prop = __tmp1.prop;
                        if (prop.MetaProperty != null && prop.MetaProperty.Kind != MetaPropertyKind.Derived) //825:5
                        {
                            object propValue = mobj.MGet(prop); //826:6
                            StringBuilder __tmp3 = new StringBuilder();
                            __tmp3.Append(GenerateModelObjectPropertyValue(coreModel, mobj, prop, propValue, mobjToName));
                            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                            {
                                bool __tmp3_first = true;
                                bool __tmp3_last = __tmp3Reader.EndOfStream;
                                while(__tmp3_first || !__tmp3_last)
                                {
                                    __tmp3_first = false;
                                    string __tmp3Line = __tmp3Reader.ReadLine();
                                    __tmp3_last = __tmp3Reader.EndOfStream;
                                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                                    if (!__tmp3_last) __out.AppendLine(true);
                                    __out.AppendLine(false); //827:81
                                }
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceFinalizer(ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //834:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //835:2
            {
                if (mobjToName.ContainsKey(mobj)) //836:3
                {
                    string name = mobjToName[mobj]; //837:4
                    string __tmp2Line = "((global::MetaDslx.Core.Immutable.MutableSymbolBase)"; //838:1
                    if (__tmp2Line != null) __out.Append(__tmp2Line);
                    StringBuilder __tmp3 = new StringBuilder();
                    __tmp3.Append(name);
                    using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                    {
                        bool __tmp3_first = true;
                        bool __tmp3_last = __tmp3Reader.EndOfStream;
                        while(__tmp3_first || !__tmp3_last)
                        {
                            __tmp3_first = false;
                            string __tmp3Line = __tmp3Reader.ReadLine();
                            __tmp3_last = __tmp3Reader.EndOfStream;
                            if (__tmp3Line != null) __out.Append(__tmp3Line);
                            if (!__tmp3_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp4Line = ").MMakeCreated();"; //838:59
                    if (__tmp4Line != null) __out.Append(__tmp4Line);
                    __out.AppendLine(false); //838:76
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectPropertyValue(bool coreModel, ModelObject mobj, ModelProperty prop, object value, Dictionary<ModelObject,string> mobjToName) //843:1
        {
            StringBuilder __out = new StringBuilder();
            string name = mobjToName[mobj]; //844:2
            ModelObject moValue = value as ModelObject; //845:2
            if (value == null) //846:2
            {
                if (prop.Type != null && prop.Type.IsClass) //847:3
                {
                    StringBuilder __tmp2 = new StringBuilder();
                    __tmp2.Append(name);
                    using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
                    {
                        bool __tmp2_first = true;
                        bool __tmp2_last = __tmp2Reader.EndOfStream;
                        while(__tmp2_first || !__tmp2_last)
                        {
                            __tmp2_first = false;
                            string __tmp2Line = __tmp2Reader.ReadLine();
                            __tmp2_last = __tmp2Reader.EndOfStream;
                            if (__tmp2Line != null) __out.Append(__tmp2Line);
                            if (!__tmp2_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp3Line = "."; //848:7
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    StringBuilder __tmp4 = new StringBuilder();
                    __tmp4.Append(prop.Name);
                    using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                    {
                        bool __tmp4_first = true;
                        bool __tmp4_last = __tmp4Reader.EndOfStream;
                        while(__tmp4_first || !__tmp4_last)
                        {
                            __tmp4_first = false;
                            string __tmp4Line = __tmp4Reader.ReadLine();
                            __tmp4_last = __tmp4Reader.EndOfStream;
                            if (__tmp4Line != null) __out.Append(__tmp4Line);
                            if (!__tmp4_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp5Line = " = null;"; //848:19
                    if (__tmp5Line != null) __out.Append(__tmp5Line);
                    __out.AppendLine(false); //848:27
                }
                else //849:3
                {
                    string __tmp7Line = "// "; //850:1
                    if (__tmp7Line != null) __out.Append(__tmp7Line);
                    StringBuilder __tmp8 = new StringBuilder();
                    __tmp8.Append(name);
                    using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                    {
                        bool __tmp8_first = true;
                        bool __tmp8_last = __tmp8Reader.EndOfStream;
                        while(__tmp8_first || !__tmp8_last)
                        {
                            __tmp8_first = false;
                            string __tmp8Line = __tmp8Reader.ReadLine();
                            __tmp8_last = __tmp8Reader.EndOfStream;
                            if (__tmp8Line != null) __out.Append(__tmp8Line);
                            if (!__tmp8_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp9Line = "."; //850:10
                    if (__tmp9Line != null) __out.Append(__tmp9Line);
                    StringBuilder __tmp10 = new StringBuilder();
                    __tmp10.Append(prop.Name);
                    using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
                    {
                        bool __tmp10_first = true;
                        bool __tmp10_last = __tmp10Reader.EndOfStream;
                        while(__tmp10_first || !__tmp10_last)
                        {
                            __tmp10_first = false;
                            string __tmp10Line = __tmp10Reader.ReadLine();
                            __tmp10_last = __tmp10Reader.EndOfStream;
                            if (__tmp10Line != null) __out.Append(__tmp10Line);
                            if (!__tmp10_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp11Line = " = null;"; //850:22
                    if (__tmp11Line != null) __out.Append(__tmp11Line);
                    __out.AppendLine(false); //850:30
                }
            }
            else if (value is string) //852:2
            {
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(name);
                using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                {
                    bool __tmp13_first = true;
                    bool __tmp13_last = __tmp13Reader.EndOfStream;
                    while(__tmp13_first || !__tmp13_last)
                    {
                        __tmp13_first = false;
                        string __tmp13Line = __tmp13Reader.ReadLine();
                        __tmp13_last = __tmp13Reader.EndOfStream;
                        if (__tmp13Line != null) __out.Append(__tmp13Line);
                        if (!__tmp13_last) __out.AppendLine(true);
                    }
                }
                string __tmp14Line = "."; //853:7
                if (__tmp14Line != null) __out.Append(__tmp14Line);
                StringBuilder __tmp15 = new StringBuilder();
                __tmp15.Append(prop.Name);
                using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
                {
                    bool __tmp15_first = true;
                    bool __tmp15_last = __tmp15Reader.EndOfStream;
                    while(__tmp15_first || !__tmp15_last)
                    {
                        __tmp15_first = false;
                        string __tmp15Line = __tmp15Reader.ReadLine();
                        __tmp15_last = __tmp15Reader.EndOfStream;
                        if (__tmp15Line != null) __out.Append(__tmp15Line);
                        if (!__tmp15_last) __out.AppendLine(true);
                    }
                }
                string __tmp16Line = " = \""; //853:19
                if (__tmp16Line != null) __out.Append(__tmp16Line);
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(value);
                using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
                {
                    bool __tmp17_first = true;
                    bool __tmp17_last = __tmp17Reader.EndOfStream;
                    while(__tmp17_first || !__tmp17_last)
                    {
                        __tmp17_first = false;
                        string __tmp17Line = __tmp17Reader.ReadLine();
                        __tmp17_last = __tmp17Reader.EndOfStream;
                        if (__tmp17Line != null) __out.Append(__tmp17Line);
                        if (!__tmp17_last) __out.AppendLine(true);
                    }
                }
                string __tmp18Line = "\";"; //853:30
                if (__tmp18Line != null) __out.Append(__tmp18Line);
                __out.AppendLine(false); //853:32
            }
            else if (value is bool) //854:2
            {
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(name);
                using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
                {
                    bool __tmp20_first = true;
                    bool __tmp20_last = __tmp20Reader.EndOfStream;
                    while(__tmp20_first || !__tmp20_last)
                    {
                        __tmp20_first = false;
                        string __tmp20Line = __tmp20Reader.ReadLine();
                        __tmp20_last = __tmp20Reader.EndOfStream;
                        if (__tmp20Line != null) __out.Append(__tmp20Line);
                        if (!__tmp20_last) __out.AppendLine(true);
                    }
                }
                string __tmp21Line = "."; //855:7
                if (__tmp21Line != null) __out.Append(__tmp21Line);
                StringBuilder __tmp22 = new StringBuilder();
                __tmp22.Append(prop.Name);
                using(StreamReader __tmp22Reader = new StreamReader(this.__ToStream(__tmp22.ToString())))
                {
                    bool __tmp22_first = true;
                    bool __tmp22_last = __tmp22Reader.EndOfStream;
                    while(__tmp22_first || !__tmp22_last)
                    {
                        __tmp22_first = false;
                        string __tmp22Line = __tmp22Reader.ReadLine();
                        __tmp22_last = __tmp22Reader.EndOfStream;
                        if (__tmp22Line != null) __out.Append(__tmp22Line);
                        if (!__tmp22_last) __out.AppendLine(true);
                    }
                }
                string __tmp23Line = " = "; //855:19
                if (__tmp23Line != null) __out.Append(__tmp23Line);
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(value.ToString().ToLower());
                using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
                {
                    bool __tmp24_first = true;
                    bool __tmp24_last = __tmp24Reader.EndOfStream;
                    while(__tmp24_first || !__tmp24_last)
                    {
                        __tmp24_first = false;
                        string __tmp24Line = __tmp24Reader.ReadLine();
                        __tmp24_last = __tmp24Reader.EndOfStream;
                        if (__tmp24Line != null) __out.Append(__tmp24Line);
                        if (!__tmp24_last) __out.AppendLine(true);
                    }
                }
                string __tmp25Line = ";"; //855:50
                if (__tmp25Line != null) __out.Append(__tmp25Line);
                __out.AppendLine(false); //855:51
            }
            else if (value.GetType().IsPrimitive) //856:2
            {
                StringBuilder __tmp27 = new StringBuilder();
                __tmp27.Append(name);
                using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
                {
                    bool __tmp27_first = true;
                    bool __tmp27_last = __tmp27Reader.EndOfStream;
                    while(__tmp27_first || !__tmp27_last)
                    {
                        __tmp27_first = false;
                        string __tmp27Line = __tmp27Reader.ReadLine();
                        __tmp27_last = __tmp27Reader.EndOfStream;
                        if (__tmp27Line != null) __out.Append(__tmp27Line);
                        if (!__tmp27_last) __out.AppendLine(true);
                    }
                }
                string __tmp28Line = "."; //857:7
                if (__tmp28Line != null) __out.Append(__tmp28Line);
                StringBuilder __tmp29 = new StringBuilder();
                __tmp29.Append(prop.Name);
                using(StreamReader __tmp29Reader = new StreamReader(this.__ToStream(__tmp29.ToString())))
                {
                    bool __tmp29_first = true;
                    bool __tmp29_last = __tmp29Reader.EndOfStream;
                    while(__tmp29_first || !__tmp29_last)
                    {
                        __tmp29_first = false;
                        string __tmp29Line = __tmp29Reader.ReadLine();
                        __tmp29_last = __tmp29Reader.EndOfStream;
                        if (__tmp29Line != null) __out.Append(__tmp29Line);
                        if (!__tmp29_last) __out.AppendLine(true);
                    }
                }
                string __tmp30Line = " = "; //857:19
                if (__tmp30Line != null) __out.Append(__tmp30Line);
                StringBuilder __tmp31 = new StringBuilder();
                __tmp31.Append(value.ToString());
                using(StreamReader __tmp31Reader = new StreamReader(this.__ToStream(__tmp31.ToString())))
                {
                    bool __tmp31_first = true;
                    bool __tmp31_last = __tmp31Reader.EndOfStream;
                    while(__tmp31_first || !__tmp31_last)
                    {
                        __tmp31_first = false;
                        string __tmp31Line = __tmp31Reader.ReadLine();
                        __tmp31_last = __tmp31Reader.EndOfStream;
                        if (__tmp31Line != null) __out.Append(__tmp31Line);
                        if (!__tmp31_last) __out.AppendLine(true);
                    }
                }
                string __tmp32Line = ";"; //857:40
                if (__tmp32Line != null) __out.Append(__tmp32Line);
                __out.AppendLine(false); //857:41
            }
            else if (MetaBuiltInTypes.Types.Contains(value)) //858:2
            {
                if (coreModel) //859:3
                {
                    if (mobjToName.ContainsKey(moValue)) //860:4
                    {
                        StringBuilder __tmp34 = new StringBuilder();
                        __tmp34.Append(name);
                        using(StreamReader __tmp34Reader = new StreamReader(this.__ToStream(__tmp34.ToString())))
                        {
                            bool __tmp34_first = true;
                            bool __tmp34_last = __tmp34Reader.EndOfStream;
                            while(__tmp34_first || !__tmp34_last)
                            {
                                __tmp34_first = false;
                                string __tmp34Line = __tmp34Reader.ReadLine();
                                __tmp34_last = __tmp34Reader.EndOfStream;
                                if (__tmp34Line != null) __out.Append(__tmp34Line);
                                if (!__tmp34_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp35Line = "."; //861:7
                        if (__tmp35Line != null) __out.Append(__tmp35Line);
                        StringBuilder __tmp36 = new StringBuilder();
                        __tmp36.Append(prop.Name);
                        using(StreamReader __tmp36Reader = new StreamReader(this.__ToStream(__tmp36.ToString())))
                        {
                            bool __tmp36_first = true;
                            bool __tmp36_last = __tmp36Reader.EndOfStream;
                            while(__tmp36_first || !__tmp36_last)
                            {
                                __tmp36_first = false;
                                string __tmp36Line = __tmp36Reader.ReadLine();
                                __tmp36_last = __tmp36Reader.EndOfStream;
                                if (__tmp36Line != null) __out.Append(__tmp36Line);
                                if (!__tmp36_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp37Line = "Lazy = () => "; //861:19
                        if (__tmp37Line != null) __out.Append(__tmp37Line);
                        StringBuilder __tmp38 = new StringBuilder();
                        __tmp38.Append(mobjToName[moValue]);
                        using(StreamReader __tmp38Reader = new StreamReader(this.__ToStream(__tmp38.ToString())))
                        {
                            bool __tmp38_first = true;
                            bool __tmp38_last = __tmp38Reader.EndOfStream;
                            while(__tmp38_first || !__tmp38_last)
                            {
                                __tmp38_first = false;
                                string __tmp38Line = __tmp38Reader.ReadLine();
                                __tmp38_last = __tmp38Reader.EndOfStream;
                                if (__tmp38Line != null) __out.Append(__tmp38Line);
                                if (!__tmp38_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp39Line = ";"; //861:53
                        if (__tmp39Line != null) __out.Append(__tmp39Line);
                        __out.AppendLine(false); //861:54
                    }
                    else //862:4
                    {
                        string __tmp41Line = "//"; //863:1
                        if (__tmp41Line != null) __out.Append(__tmp41Line);
                        StringBuilder __tmp42 = new StringBuilder();
                        __tmp42.Append(name);
                        using(StreamReader __tmp42Reader = new StreamReader(this.__ToStream(__tmp42.ToString())))
                        {
                            bool __tmp42_first = true;
                            bool __tmp42_last = __tmp42Reader.EndOfStream;
                            while(__tmp42_first || !__tmp42_last)
                            {
                                __tmp42_first = false;
                                string __tmp42Line = __tmp42Reader.ReadLine();
                                __tmp42_last = __tmp42Reader.EndOfStream;
                                if (__tmp42Line != null) __out.Append(__tmp42Line);
                                if (!__tmp42_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp43Line = "."; //863:9
                        if (__tmp43Line != null) __out.Append(__tmp43Line);
                        StringBuilder __tmp44 = new StringBuilder();
                        __tmp44.Append(prop.Name);
                        using(StreamReader __tmp44Reader = new StreamReader(this.__ToStream(__tmp44.ToString())))
                        {
                            bool __tmp44_first = true;
                            bool __tmp44_last = __tmp44Reader.EndOfStream;
                            while(__tmp44_first || !__tmp44_last)
                            {
                                __tmp44_first = false;
                                string __tmp44Line = __tmp44Reader.ReadLine();
                                __tmp44_last = __tmp44Reader.EndOfStream;
                                if (__tmp44Line != null) __out.Append(__tmp44Line);
                                if (!__tmp44_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp45Line = "Lazy = () => Error: "; //863:21
                        if (__tmp45Line != null) __out.Append(__tmp45Line);
                        StringBuilder __tmp46 = new StringBuilder();
                        __tmp46.Append(moValue);
                        using(StreamReader __tmp46Reader = new StreamReader(this.__ToStream(__tmp46.ToString())))
                        {
                            bool __tmp46_first = true;
                            bool __tmp46_last = __tmp46Reader.EndOfStream;
                            while(__tmp46_first || !__tmp46_last)
                            {
                                __tmp46_first = false;
                                string __tmp46Line = __tmp46Reader.ReadLine();
                                __tmp46_last = __tmp46Reader.EndOfStream;
                                if (__tmp46Line != null) __out.Append(__tmp46Line);
                                if (!__tmp46_last) __out.AppendLine(true);
                                __out.AppendLine(false); //863:50
                            }
                        }
                    }
                }
                else //865:3
                {
                    StringBuilder __tmp48 = new StringBuilder();
                    __tmp48.Append(name);
                    using(StreamReader __tmp48Reader = new StreamReader(this.__ToStream(__tmp48.ToString())))
                    {
                        bool __tmp48_first = true;
                        bool __tmp48_last = __tmp48Reader.EndOfStream;
                        while(__tmp48_first || !__tmp48_last)
                        {
                            __tmp48_first = false;
                            string __tmp48Line = __tmp48Reader.ReadLine();
                            __tmp48_last = __tmp48Reader.EndOfStream;
                            if (__tmp48Line != null) __out.Append(__tmp48Line);
                            if (!__tmp48_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp49Line = "."; //866:7
                    if (__tmp49Line != null) __out.Append(__tmp49Line);
                    StringBuilder __tmp50 = new StringBuilder();
                    __tmp50.Append(prop.Name);
                    using(StreamReader __tmp50Reader = new StreamReader(this.__ToStream(__tmp50.ToString())))
                    {
                        bool __tmp50_first = true;
                        bool __tmp50_last = __tmp50Reader.EndOfStream;
                        while(__tmp50_first || !__tmp50_last)
                        {
                            __tmp50_first = false;
                            string __tmp50Line = __tmp50Reader.ReadLine();
                            __tmp50_last = __tmp50Reader.EndOfStream;
                            if (__tmp50Line != null) __out.Append(__tmp50Line);
                            if (!__tmp50_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp51Line = " = "; //866:19
                    if (__tmp51Line != null) __out.Append(__tmp51Line);
                    StringBuilder __tmp52 = new StringBuilder();
                    __tmp52.Append(GenerateTypeOf(value));
                    using(StreamReader __tmp52Reader = new StreamReader(this.__ToStream(__tmp52.ToString())))
                    {
                        bool __tmp52_first = true;
                        bool __tmp52_last = __tmp52Reader.EndOfStream;
                        while(__tmp52_first || !__tmp52_last)
                        {
                            __tmp52_first = false;
                            string __tmp52Line = __tmp52Reader.ReadLine();
                            __tmp52_last = __tmp52Reader.EndOfStream;
                            if (__tmp52Line != null) __out.Append(__tmp52Line);
                            if (!__tmp52_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp53Line = ";"; //866:45
                    if (__tmp53Line != null) __out.Append(__tmp53Line);
                    __out.AppendLine(false); //866:46
                }
            }
            else if (value is MetaPrimitiveType) //868:2
            {
                if (coreModel) //869:3
                {
                    StringBuilder __tmp55 = new StringBuilder();
                    __tmp55.Append(name);
                    using(StreamReader __tmp55Reader = new StreamReader(this.__ToStream(__tmp55.ToString())))
                    {
                        bool __tmp55_first = true;
                        bool __tmp55_last = __tmp55Reader.EndOfStream;
                        while(__tmp55_first || !__tmp55_last)
                        {
                            __tmp55_first = false;
                            string __tmp55Line = __tmp55Reader.ReadLine();
                            __tmp55_last = __tmp55Reader.EndOfStream;
                            if (__tmp55Line != null) __out.Append(__tmp55Line);
                            if (!__tmp55_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp56Line = "."; //870:7
                    if (__tmp56Line != null) __out.Append(__tmp56Line);
                    StringBuilder __tmp57 = new StringBuilder();
                    __tmp57.Append(prop.Name);
                    using(StreamReader __tmp57Reader = new StreamReader(this.__ToStream(__tmp57.ToString())))
                    {
                        bool __tmp57_first = true;
                        bool __tmp57_last = __tmp57Reader.EndOfStream;
                        while(__tmp57_first || !__tmp57_last)
                        {
                            __tmp57_first = false;
                            string __tmp57Line = __tmp57Reader.ReadLine();
                            __tmp57_last = __tmp57Reader.EndOfStream;
                            if (__tmp57Line != null) __out.Append(__tmp57Line);
                            if (!__tmp57_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp58Line = "Lazy = () => "; //870:19
                    if (__tmp58Line != null) __out.Append(__tmp58Line);
                    StringBuilder __tmp59 = new StringBuilder();
                    __tmp59.Append(mobjToName[moValue]);
                    using(StreamReader __tmp59Reader = new StreamReader(this.__ToStream(__tmp59.ToString())))
                    {
                        bool __tmp59_first = true;
                        bool __tmp59_last = __tmp59Reader.EndOfStream;
                        while(__tmp59_first || !__tmp59_last)
                        {
                            __tmp59_first = false;
                            string __tmp59Line = __tmp59Reader.ReadLine();
                            __tmp59_last = __tmp59Reader.EndOfStream;
                            if (__tmp59Line != null) __out.Append(__tmp59Line);
                            if (!__tmp59_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp60Line = ";"; //870:53
                    if (__tmp60Line != null) __out.Append(__tmp60Line);
                    __out.AppendLine(false); //870:54
                }
                else //871:3
                {
                    StringBuilder __tmp62 = new StringBuilder();
                    __tmp62.Append(name);
                    using(StreamReader __tmp62Reader = new StreamReader(this.__ToStream(__tmp62.ToString())))
                    {
                        bool __tmp62_first = true;
                        bool __tmp62_last = __tmp62Reader.EndOfStream;
                        while(__tmp62_first || !__tmp62_last)
                        {
                            __tmp62_first = false;
                            string __tmp62Line = __tmp62Reader.ReadLine();
                            __tmp62_last = __tmp62Reader.EndOfStream;
                            if (__tmp62Line != null) __out.Append(__tmp62Line);
                            if (!__tmp62_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp63Line = "."; //872:7
                    if (__tmp63Line != null) __out.Append(__tmp63Line);
                    StringBuilder __tmp64 = new StringBuilder();
                    __tmp64.Append(prop.Name);
                    using(StreamReader __tmp64Reader = new StreamReader(this.__ToStream(__tmp64.ToString())))
                    {
                        bool __tmp64_first = true;
                        bool __tmp64_last = __tmp64Reader.EndOfStream;
                        while(__tmp64_first || !__tmp64_last)
                        {
                            __tmp64_first = false;
                            string __tmp64Line = __tmp64Reader.ReadLine();
                            __tmp64_last = __tmp64Reader.EndOfStream;
                            if (__tmp64Line != null) __out.Append(__tmp64Line);
                            if (!__tmp64_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp65Line = " = "; //872:19
                    if (__tmp65Line != null) __out.Append(__tmp65Line);
                    StringBuilder __tmp66 = new StringBuilder();
                    __tmp66.Append(GenerateTypeOf(value));
                    using(StreamReader __tmp66Reader = new StreamReader(this.__ToStream(__tmp66.ToString())))
                    {
                        bool __tmp66_first = true;
                        bool __tmp66_last = __tmp66Reader.EndOfStream;
                        while(__tmp66_first || !__tmp66_last)
                        {
                            __tmp66_first = false;
                            string __tmp66Line = __tmp66Reader.ReadLine();
                            __tmp66_last = __tmp66Reader.EndOfStream;
                            if (__tmp66Line != null) __out.Append(__tmp66Line);
                            if (!__tmp66_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp67Line = ";"; //872:45
                    if (__tmp67Line != null) __out.Append(__tmp67Line);
                    __out.AppendLine(false); //872:46
                }
            }
            else if (value is Enum) //874:2
            {
                StringBuilder __tmp69 = new StringBuilder();
                __tmp69.Append(name);
                using(StreamReader __tmp69Reader = new StreamReader(this.__ToStream(__tmp69.ToString())))
                {
                    bool __tmp69_first = true;
                    bool __tmp69_last = __tmp69Reader.EndOfStream;
                    while(__tmp69_first || !__tmp69_last)
                    {
                        __tmp69_first = false;
                        string __tmp69Line = __tmp69Reader.ReadLine();
                        __tmp69_last = __tmp69Reader.EndOfStream;
                        if (__tmp69Line != null) __out.Append(__tmp69Line);
                        if (!__tmp69_last) __out.AppendLine(true);
                    }
                }
                string __tmp70Line = "."; //875:7
                if (__tmp70Line != null) __out.Append(__tmp70Line);
                StringBuilder __tmp71 = new StringBuilder();
                __tmp71.Append(prop.Name);
                using(StreamReader __tmp71Reader = new StreamReader(this.__ToStream(__tmp71.ToString())))
                {
                    bool __tmp71_first = true;
                    bool __tmp71_last = __tmp71Reader.EndOfStream;
                    while(__tmp71_first || !__tmp71_last)
                    {
                        __tmp71_first = false;
                        string __tmp71Line = __tmp71Reader.ReadLine();
                        __tmp71_last = __tmp71Reader.EndOfStream;
                        if (__tmp71Line != null) __out.Append(__tmp71Line);
                        if (!__tmp71_last) __out.AppendLine(true);
                    }
                }
                string __tmp72Line = " = "; //875:19
                if (__tmp72Line != null) __out.Append(__tmp72Line);
                StringBuilder __tmp73 = new StringBuilder();
                __tmp73.Append(GetEnumValueOf(value));
                using(StreamReader __tmp73Reader = new StreamReader(this.__ToStream(__tmp73.ToString())))
                {
                    bool __tmp73_first = true;
                    bool __tmp73_last = __tmp73Reader.EndOfStream;
                    while(__tmp73_first || !__tmp73_last)
                    {
                        __tmp73_first = false;
                        string __tmp73Line = __tmp73Reader.ReadLine();
                        __tmp73_last = __tmp73Reader.EndOfStream;
                        if (__tmp73Line != null) __out.Append(__tmp73Line);
                        if (!__tmp73_last) __out.AppendLine(true);
                    }
                }
                string __tmp74Line = ";"; //875:45
                if (__tmp74Line != null) __out.Append(__tmp74Line);
                __out.AppendLine(false); //875:46
            }
            else if (moValue != null) //876:2
            {
                if (mobjToName.ContainsKey(moValue)) //877:3
                {
                    StringBuilder __tmp76 = new StringBuilder();
                    __tmp76.Append(name);
                    using(StreamReader __tmp76Reader = new StreamReader(this.__ToStream(__tmp76.ToString())))
                    {
                        bool __tmp76_first = true;
                        bool __tmp76_last = __tmp76Reader.EndOfStream;
                        while(__tmp76_first || !__tmp76_last)
                        {
                            __tmp76_first = false;
                            string __tmp76Line = __tmp76Reader.ReadLine();
                            __tmp76_last = __tmp76Reader.EndOfStream;
                            if (__tmp76Line != null) __out.Append(__tmp76Line);
                            if (!__tmp76_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp77Line = "."; //878:7
                    if (__tmp77Line != null) __out.Append(__tmp77Line);
                    StringBuilder __tmp78 = new StringBuilder();
                    __tmp78.Append(prop.Name);
                    using(StreamReader __tmp78Reader = new StreamReader(this.__ToStream(__tmp78.ToString())))
                    {
                        bool __tmp78_first = true;
                        bool __tmp78_last = __tmp78Reader.EndOfStream;
                        while(__tmp78_first || !__tmp78_last)
                        {
                            __tmp78_first = false;
                            string __tmp78Line = __tmp78Reader.ReadLine();
                            __tmp78_last = __tmp78Reader.EndOfStream;
                            if (__tmp78Line != null) __out.Append(__tmp78Line);
                            if (!__tmp78_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp79Line = "Lazy = () => "; //878:19
                    if (__tmp79Line != null) __out.Append(__tmp79Line);
                    StringBuilder __tmp80 = new StringBuilder();
                    __tmp80.Append(mobjToName[moValue]);
                    using(StreamReader __tmp80Reader = new StreamReader(this.__ToStream(__tmp80.ToString())))
                    {
                        bool __tmp80_first = true;
                        bool __tmp80_last = __tmp80Reader.EndOfStream;
                        while(__tmp80_first || !__tmp80_last)
                        {
                            __tmp80_first = false;
                            string __tmp80Line = __tmp80Reader.ReadLine();
                            __tmp80_last = __tmp80Reader.EndOfStream;
                            if (__tmp80Line != null) __out.Append(__tmp80Line);
                            if (!__tmp80_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp81Line = ";"; //878:53
                    if (__tmp81Line != null) __out.Append(__tmp81Line);
                    __out.AppendLine(false); //878:54
                }
                else //879:3
                {
                    string __tmp83Line = "// Omitted since not part of the model: "; //880:1
                    if (__tmp83Line != null) __out.Append(__tmp83Line);
                    StringBuilder __tmp84 = new StringBuilder();
                    __tmp84.Append(name);
                    using(StreamReader __tmp84Reader = new StreamReader(this.__ToStream(__tmp84.ToString())))
                    {
                        bool __tmp84_first = true;
                        bool __tmp84_last = __tmp84Reader.EndOfStream;
                        while(__tmp84_first || !__tmp84_last)
                        {
                            __tmp84_first = false;
                            string __tmp84Line = __tmp84Reader.ReadLine();
                            __tmp84_last = __tmp84Reader.EndOfStream;
                            if (__tmp84Line != null) __out.Append(__tmp84Line);
                            if (!__tmp84_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp85Line = "."; //880:47
                    if (__tmp85Line != null) __out.Append(__tmp85Line);
                    StringBuilder __tmp86 = new StringBuilder();
                    __tmp86.Append(prop.Name);
                    using(StreamReader __tmp86Reader = new StreamReader(this.__ToStream(__tmp86.ToString())))
                    {
                        bool __tmp86_first = true;
                        bool __tmp86_last = __tmp86Reader.EndOfStream;
                        while(__tmp86_first || !__tmp86_last)
                        {
                            __tmp86_first = false;
                            string __tmp86Line = __tmp86Reader.ReadLine();
                            __tmp86_last = __tmp86Reader.EndOfStream;
                            if (__tmp86Line != null) __out.Append(__tmp86Line);
                            if (!__tmp86_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp87Line = " = "; //880:59
                    if (__tmp87Line != null) __out.Append(__tmp87Line);
                    StringBuilder __tmp88 = new StringBuilder();
                    __tmp88.Append(moValue);
                    using(StreamReader __tmp88Reader = new StreamReader(this.__ToStream(__tmp88.ToString())))
                    {
                        bool __tmp88_first = true;
                        bool __tmp88_last = __tmp88Reader.EndOfStream;
                        while(__tmp88_first || !__tmp88_last)
                        {
                            __tmp88_first = false;
                            string __tmp88Line = __tmp88Reader.ReadLine();
                            __tmp88_last = __tmp88Reader.EndOfStream;
                            if (__tmp88Line != null) __out.Append(__tmp88Line);
                            if (!__tmp88_last) __out.AppendLine(true);
                            __out.AppendLine(false); //880:71
                        }
                    }
                }
            }
            else //882:2
            {
                IEnumerable<object> mc = (value as ModelCollection) as IEnumerable<object>; //883:3
                if (mc != null) //884:3
                {
                    var __loop59_results = 
                        (from cvalue in __Enumerate((mc).GetEnumerator()) //885:9
                        select new { cvalue = cvalue}
                        ).ToList(); //885:4
                    int __loop59_iteration = 0;
                    foreach (var __tmp89 in __loop59_results)
                    {
                        ++__loop59_iteration;
                        var cvalue = __tmp89.cvalue;
                        StringBuilder __tmp91 = new StringBuilder();
                        __tmp91.Append(GenerateModelObjectPropertyCollectionValue(coreModel, mobj, prop, cvalue, mobjToName));
                        using(StreamReader __tmp91Reader = new StreamReader(this.__ToStream(__tmp91.ToString())))
                        {
                            bool __tmp91_first = true;
                            bool __tmp91_last = __tmp91Reader.EndOfStream;
                            while(__tmp91_first || !__tmp91_last)
                            {
                                __tmp91_first = false;
                                string __tmp91Line = __tmp91Reader.ReadLine();
                                __tmp91_last = __tmp91Reader.EndOfStream;
                                if (__tmp91Line != null) __out.Append(__tmp91Line);
                                if (!__tmp91_last) __out.AppendLine(true);
                                __out.AppendLine(false); //886:88
                            }
                        }
                    }
                }
                else //888:3
                {
                    string __tmp93Line = "// Invalid property value type: "; //889:1
                    if (__tmp93Line != null) __out.Append(__tmp93Line);
                    StringBuilder __tmp94 = new StringBuilder();
                    __tmp94.Append(name);
                    using(StreamReader __tmp94Reader = new StreamReader(this.__ToStream(__tmp94.ToString())))
                    {
                        bool __tmp94_first = true;
                        bool __tmp94_last = __tmp94Reader.EndOfStream;
                        while(__tmp94_first || !__tmp94_last)
                        {
                            __tmp94_first = false;
                            string __tmp94Line = __tmp94Reader.ReadLine();
                            __tmp94_last = __tmp94Reader.EndOfStream;
                            if (__tmp94Line != null) __out.Append(__tmp94Line);
                            if (!__tmp94_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp95Line = "."; //889:39
                    if (__tmp95Line != null) __out.Append(__tmp95Line);
                    StringBuilder __tmp96 = new StringBuilder();
                    __tmp96.Append(prop.Name);
                    using(StreamReader __tmp96Reader = new StreamReader(this.__ToStream(__tmp96.ToString())))
                    {
                        bool __tmp96_first = true;
                        bool __tmp96_last = __tmp96Reader.EndOfStream;
                        while(__tmp96_first || !__tmp96_last)
                        {
                            __tmp96_first = false;
                            string __tmp96Line = __tmp96Reader.ReadLine();
                            __tmp96_last = __tmp96Reader.EndOfStream;
                            if (__tmp96Line != null) __out.Append(__tmp96Line);
                            if (!__tmp96_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp97Line = " = "; //889:51
                    if (__tmp97Line != null) __out.Append(__tmp97Line);
                    StringBuilder __tmp98 = new StringBuilder();
                    __tmp98.Append(value.GetType());
                    using(StreamReader __tmp98Reader = new StreamReader(this.__ToStream(__tmp98.ToString())))
                    {
                        bool __tmp98_first = true;
                        bool __tmp98_last = __tmp98Reader.EndOfStream;
                        while(__tmp98_first || !__tmp98_last)
                        {
                            __tmp98_first = false;
                            string __tmp98Line = __tmp98Reader.ReadLine();
                            __tmp98_last = __tmp98Reader.EndOfStream;
                            if (__tmp98Line != null) __out.Append(__tmp98Line);
                            if (!__tmp98_last) __out.AppendLine(true);
                            __out.AppendLine(false); //889:71
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectPropertyCollectionValue(bool coreModel, ModelObject mobj, ModelProperty prop, object value, Dictionary<ModelObject,string> mobjToName) //894:1
        {
            StringBuilder __out = new StringBuilder();
            string name = mobjToName[mobj]; //895:2
            ModelObject moValue = value as ModelObject; //896:2
            if (value == null) //897:2
            {
                StringBuilder __tmp2 = new StringBuilder();
                __tmp2.Append(name);
                using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
                {
                    bool __tmp2_first = true;
                    bool __tmp2_last = __tmp2Reader.EndOfStream;
                    while(__tmp2_first || !__tmp2_last)
                    {
                        __tmp2_first = false;
                        string __tmp2Line = __tmp2Reader.ReadLine();
                        __tmp2_last = __tmp2Reader.EndOfStream;
                        if (__tmp2Line != null) __out.Append(__tmp2Line);
                        if (!__tmp2_last) __out.AppendLine(true);
                    }
                }
                string __tmp3Line = "."; //898:7
                if (__tmp3Line != null) __out.Append(__tmp3Line);
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append(prop.Name);
                using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                {
                    bool __tmp4_first = true;
                    bool __tmp4_last = __tmp4Reader.EndOfStream;
                    while(__tmp4_first || !__tmp4_last)
                    {
                        __tmp4_first = false;
                        string __tmp4Line = __tmp4Reader.ReadLine();
                        __tmp4_last = __tmp4Reader.EndOfStream;
                        if (__tmp4Line != null) __out.Append(__tmp4Line);
                        if (!__tmp4_last) __out.AppendLine(true);
                    }
                }
                string __tmp5Line = ".Add(null);"; //898:19
                if (__tmp5Line != null) __out.Append(__tmp5Line);
                __out.AppendLine(false); //898:30
            }
            else if (value is string) //899:2
            {
                StringBuilder __tmp7 = new StringBuilder();
                __tmp7.Append(name);
                using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
                {
                    bool __tmp7_first = true;
                    bool __tmp7_last = __tmp7Reader.EndOfStream;
                    while(__tmp7_first || !__tmp7_last)
                    {
                        __tmp7_first = false;
                        string __tmp7Line = __tmp7Reader.ReadLine();
                        __tmp7_last = __tmp7Reader.EndOfStream;
                        if (__tmp7Line != null) __out.Append(__tmp7Line);
                        if (!__tmp7_last) __out.AppendLine(true);
                    }
                }
                string __tmp8Line = "."; //900:7
                if (__tmp8Line != null) __out.Append(__tmp8Line);
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append(prop.Name);
                using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                {
                    bool __tmp9_first = true;
                    bool __tmp9_last = __tmp9Reader.EndOfStream;
                    while(__tmp9_first || !__tmp9_last)
                    {
                        __tmp9_first = false;
                        string __tmp9Line = __tmp9Reader.ReadLine();
                        __tmp9_last = __tmp9Reader.EndOfStream;
                        if (__tmp9Line != null) __out.Append(__tmp9Line);
                        if (!__tmp9_last) __out.AppendLine(true);
                    }
                }
                string __tmp10Line = ".Add(\""; //900:19
                if (__tmp10Line != null) __out.Append(__tmp10Line);
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(value);
                using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                {
                    bool __tmp11_first = true;
                    bool __tmp11_last = __tmp11Reader.EndOfStream;
                    while(__tmp11_first || !__tmp11_last)
                    {
                        __tmp11_first = false;
                        string __tmp11Line = __tmp11Reader.ReadLine();
                        __tmp11_last = __tmp11Reader.EndOfStream;
                        if (__tmp11Line != null) __out.Append(__tmp11Line);
                        if (!__tmp11_last) __out.AppendLine(true);
                    }
                }
                string __tmp12Line = "\");"; //900:32
                if (__tmp12Line != null) __out.Append(__tmp12Line);
                __out.AppendLine(false); //900:35
            }
            else if (value is bool) //901:2
            {
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(name);
                using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
                {
                    bool __tmp14_first = true;
                    bool __tmp14_last = __tmp14Reader.EndOfStream;
                    while(__tmp14_first || !__tmp14_last)
                    {
                        __tmp14_first = false;
                        string __tmp14Line = __tmp14Reader.ReadLine();
                        __tmp14_last = __tmp14Reader.EndOfStream;
                        if (__tmp14Line != null) __out.Append(__tmp14Line);
                        if (!__tmp14_last) __out.AppendLine(true);
                    }
                }
                string __tmp15Line = "."; //902:7
                if (__tmp15Line != null) __out.Append(__tmp15Line);
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(prop.Name);
                using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
                {
                    bool __tmp16_first = true;
                    bool __tmp16_last = __tmp16Reader.EndOfStream;
                    while(__tmp16_first || !__tmp16_last)
                    {
                        __tmp16_first = false;
                        string __tmp16Line = __tmp16Reader.ReadLine();
                        __tmp16_last = __tmp16Reader.EndOfStream;
                        if (__tmp16Line != null) __out.Append(__tmp16Line);
                        if (!__tmp16_last) __out.AppendLine(true);
                    }
                }
                string __tmp17Line = ".Add("; //902:19
                if (__tmp17Line != null) __out.Append(__tmp17Line);
                StringBuilder __tmp18 = new StringBuilder();
                __tmp18.Append(value.ToString().ToLower());
                using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
                {
                    bool __tmp18_first = true;
                    bool __tmp18_last = __tmp18Reader.EndOfStream;
                    while(__tmp18_first || !__tmp18_last)
                    {
                        __tmp18_first = false;
                        string __tmp18Line = __tmp18Reader.ReadLine();
                        __tmp18_last = __tmp18Reader.EndOfStream;
                        if (__tmp18Line != null) __out.Append(__tmp18Line);
                        if (!__tmp18_last) __out.AppendLine(true);
                    }
                }
                string __tmp19Line = ");"; //902:52
                if (__tmp19Line != null) __out.Append(__tmp19Line);
                __out.AppendLine(false); //902:54
            }
            else if (value.GetType().IsPrimitive) //903:2
            {
                StringBuilder __tmp21 = new StringBuilder();
                __tmp21.Append(name);
                using(StreamReader __tmp21Reader = new StreamReader(this.__ToStream(__tmp21.ToString())))
                {
                    bool __tmp21_first = true;
                    bool __tmp21_last = __tmp21Reader.EndOfStream;
                    while(__tmp21_first || !__tmp21_last)
                    {
                        __tmp21_first = false;
                        string __tmp21Line = __tmp21Reader.ReadLine();
                        __tmp21_last = __tmp21Reader.EndOfStream;
                        if (__tmp21Line != null) __out.Append(__tmp21Line);
                        if (!__tmp21_last) __out.AppendLine(true);
                    }
                }
                string __tmp22Line = "."; //904:7
                if (__tmp22Line != null) __out.Append(__tmp22Line);
                StringBuilder __tmp23 = new StringBuilder();
                __tmp23.Append(prop.Name);
                using(StreamReader __tmp23Reader = new StreamReader(this.__ToStream(__tmp23.ToString())))
                {
                    bool __tmp23_first = true;
                    bool __tmp23_last = __tmp23Reader.EndOfStream;
                    while(__tmp23_first || !__tmp23_last)
                    {
                        __tmp23_first = false;
                        string __tmp23Line = __tmp23Reader.ReadLine();
                        __tmp23_last = __tmp23Reader.EndOfStream;
                        if (__tmp23Line != null) __out.Append(__tmp23Line);
                        if (!__tmp23_last) __out.AppendLine(true);
                    }
                }
                string __tmp24Line = ".Add("; //904:19
                if (__tmp24Line != null) __out.Append(__tmp24Line);
                StringBuilder __tmp25 = new StringBuilder();
                __tmp25.Append(value.ToString());
                using(StreamReader __tmp25Reader = new StreamReader(this.__ToStream(__tmp25.ToString())))
                {
                    bool __tmp25_first = true;
                    bool __tmp25_last = __tmp25Reader.EndOfStream;
                    while(__tmp25_first || !__tmp25_last)
                    {
                        __tmp25_first = false;
                        string __tmp25Line = __tmp25Reader.ReadLine();
                        __tmp25_last = __tmp25Reader.EndOfStream;
                        if (__tmp25Line != null) __out.Append(__tmp25Line);
                        if (!__tmp25_last) __out.AppendLine(true);
                    }
                }
                string __tmp26Line = ");"; //904:42
                if (__tmp26Line != null) __out.Append(__tmp26Line);
                __out.AppendLine(false); //904:44
            }
            else if (MetaBuiltInTypes.Types.Contains(value)) //905:2
            {
                if (coreModel) //906:3
                {
                    StringBuilder __tmp28 = new StringBuilder();
                    __tmp28.Append(name);
                    using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
                    {
                        bool __tmp28_first = true;
                        bool __tmp28_last = __tmp28Reader.EndOfStream;
                        while(__tmp28_first || !__tmp28_last)
                        {
                            __tmp28_first = false;
                            string __tmp28Line = __tmp28Reader.ReadLine();
                            __tmp28_last = __tmp28Reader.EndOfStream;
                            if (__tmp28Line != null) __out.Append(__tmp28Line);
                            if (!__tmp28_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp29Line = "."; //907:7
                    if (__tmp29Line != null) __out.Append(__tmp29Line);
                    StringBuilder __tmp30 = new StringBuilder();
                    __tmp30.Append(prop.Name);
                    using(StreamReader __tmp30Reader = new StreamReader(this.__ToStream(__tmp30.ToString())))
                    {
                        bool __tmp30_first = true;
                        bool __tmp30_last = __tmp30Reader.EndOfStream;
                        while(__tmp30_first || !__tmp30_last)
                        {
                            __tmp30_first = false;
                            string __tmp30Line = __tmp30Reader.ReadLine();
                            __tmp30_last = __tmp30Reader.EndOfStream;
                            if (__tmp30Line != null) __out.Append(__tmp30Line);
                            if (!__tmp30_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp31Line = ".AddLazy(() => "; //907:19
                    if (__tmp31Line != null) __out.Append(__tmp31Line);
                    StringBuilder __tmp32 = new StringBuilder();
                    __tmp32.Append(mobjToName[moValue]);
                    using(StreamReader __tmp32Reader = new StreamReader(this.__ToStream(__tmp32.ToString())))
                    {
                        bool __tmp32_first = true;
                        bool __tmp32_last = __tmp32Reader.EndOfStream;
                        while(__tmp32_first || !__tmp32_last)
                        {
                            __tmp32_first = false;
                            string __tmp32Line = __tmp32Reader.ReadLine();
                            __tmp32_last = __tmp32Reader.EndOfStream;
                            if (__tmp32Line != null) __out.Append(__tmp32Line);
                            if (!__tmp32_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp33Line = ");"; //907:55
                    if (__tmp33Line != null) __out.Append(__tmp33Line);
                    __out.AppendLine(false); //907:57
                }
                else //908:3
                {
                    StringBuilder __tmp35 = new StringBuilder();
                    __tmp35.Append(name);
                    using(StreamReader __tmp35Reader = new StreamReader(this.__ToStream(__tmp35.ToString())))
                    {
                        bool __tmp35_first = true;
                        bool __tmp35_last = __tmp35Reader.EndOfStream;
                        while(__tmp35_first || !__tmp35_last)
                        {
                            __tmp35_first = false;
                            string __tmp35Line = __tmp35Reader.ReadLine();
                            __tmp35_last = __tmp35Reader.EndOfStream;
                            if (__tmp35Line != null) __out.Append(__tmp35Line);
                            if (!__tmp35_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp36Line = "."; //909:7
                    if (__tmp36Line != null) __out.Append(__tmp36Line);
                    StringBuilder __tmp37 = new StringBuilder();
                    __tmp37.Append(prop.Name);
                    using(StreamReader __tmp37Reader = new StreamReader(this.__ToStream(__tmp37.ToString())))
                    {
                        bool __tmp37_first = true;
                        bool __tmp37_last = __tmp37Reader.EndOfStream;
                        while(__tmp37_first || !__tmp37_last)
                        {
                            __tmp37_first = false;
                            string __tmp37Line = __tmp37Reader.ReadLine();
                            __tmp37_last = __tmp37Reader.EndOfStream;
                            if (__tmp37Line != null) __out.Append(__tmp37Line);
                            if (!__tmp37_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp38Line = ".Add("; //909:19
                    if (__tmp38Line != null) __out.Append(__tmp38Line);
                    StringBuilder __tmp39 = new StringBuilder();
                    __tmp39.Append(GenerateTypeOf(value));
                    using(StreamReader __tmp39Reader = new StreamReader(this.__ToStream(__tmp39.ToString())))
                    {
                        bool __tmp39_first = true;
                        bool __tmp39_last = __tmp39Reader.EndOfStream;
                        while(__tmp39_first || !__tmp39_last)
                        {
                            __tmp39_first = false;
                            string __tmp39Line = __tmp39Reader.ReadLine();
                            __tmp39_last = __tmp39Reader.EndOfStream;
                            if (__tmp39Line != null) __out.Append(__tmp39Line);
                            if (!__tmp39_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp40Line = ");"; //909:47
                    if (__tmp40Line != null) __out.Append(__tmp40Line);
                    __out.AppendLine(false); //909:49
                }
            }
            else if (value is MetaPrimitiveType) //911:2
            {
                if (coreModel) //912:3
                {
                    StringBuilder __tmp42 = new StringBuilder();
                    __tmp42.Append(name);
                    using(StreamReader __tmp42Reader = new StreamReader(this.__ToStream(__tmp42.ToString())))
                    {
                        bool __tmp42_first = true;
                        bool __tmp42_last = __tmp42Reader.EndOfStream;
                        while(__tmp42_first || !__tmp42_last)
                        {
                            __tmp42_first = false;
                            string __tmp42Line = __tmp42Reader.ReadLine();
                            __tmp42_last = __tmp42Reader.EndOfStream;
                            if (__tmp42Line != null) __out.Append(__tmp42Line);
                            if (!__tmp42_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp43Line = "."; //913:7
                    if (__tmp43Line != null) __out.Append(__tmp43Line);
                    StringBuilder __tmp44 = new StringBuilder();
                    __tmp44.Append(prop.Name);
                    using(StreamReader __tmp44Reader = new StreamReader(this.__ToStream(__tmp44.ToString())))
                    {
                        bool __tmp44_first = true;
                        bool __tmp44_last = __tmp44Reader.EndOfStream;
                        while(__tmp44_first || !__tmp44_last)
                        {
                            __tmp44_first = false;
                            string __tmp44Line = __tmp44Reader.ReadLine();
                            __tmp44_last = __tmp44Reader.EndOfStream;
                            if (__tmp44Line != null) __out.Append(__tmp44Line);
                            if (!__tmp44_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp45Line = ".AddLazy(() => "; //913:19
                    if (__tmp45Line != null) __out.Append(__tmp45Line);
                    StringBuilder __tmp46 = new StringBuilder();
                    __tmp46.Append(mobjToName[moValue]);
                    using(StreamReader __tmp46Reader = new StreamReader(this.__ToStream(__tmp46.ToString())))
                    {
                        bool __tmp46_first = true;
                        bool __tmp46_last = __tmp46Reader.EndOfStream;
                        while(__tmp46_first || !__tmp46_last)
                        {
                            __tmp46_first = false;
                            string __tmp46Line = __tmp46Reader.ReadLine();
                            __tmp46_last = __tmp46Reader.EndOfStream;
                            if (__tmp46Line != null) __out.Append(__tmp46Line);
                            if (!__tmp46_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp47Line = ");"; //913:55
                    if (__tmp47Line != null) __out.Append(__tmp47Line);
                    __out.AppendLine(false); //913:57
                }
                else //914:3
                {
                    StringBuilder __tmp49 = new StringBuilder();
                    __tmp49.Append(name);
                    using(StreamReader __tmp49Reader = new StreamReader(this.__ToStream(__tmp49.ToString())))
                    {
                        bool __tmp49_first = true;
                        bool __tmp49_last = __tmp49Reader.EndOfStream;
                        while(__tmp49_first || !__tmp49_last)
                        {
                            __tmp49_first = false;
                            string __tmp49Line = __tmp49Reader.ReadLine();
                            __tmp49_last = __tmp49Reader.EndOfStream;
                            if (__tmp49Line != null) __out.Append(__tmp49Line);
                            if (!__tmp49_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp50Line = "."; //915:7
                    if (__tmp50Line != null) __out.Append(__tmp50Line);
                    StringBuilder __tmp51 = new StringBuilder();
                    __tmp51.Append(prop.Name);
                    using(StreamReader __tmp51Reader = new StreamReader(this.__ToStream(__tmp51.ToString())))
                    {
                        bool __tmp51_first = true;
                        bool __tmp51_last = __tmp51Reader.EndOfStream;
                        while(__tmp51_first || !__tmp51_last)
                        {
                            __tmp51_first = false;
                            string __tmp51Line = __tmp51Reader.ReadLine();
                            __tmp51_last = __tmp51Reader.EndOfStream;
                            if (__tmp51Line != null) __out.Append(__tmp51Line);
                            if (!__tmp51_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp52Line = ".Add("; //915:19
                    if (__tmp52Line != null) __out.Append(__tmp52Line);
                    StringBuilder __tmp53 = new StringBuilder();
                    __tmp53.Append(GenerateTypeOf(value));
                    using(StreamReader __tmp53Reader = new StreamReader(this.__ToStream(__tmp53.ToString())))
                    {
                        bool __tmp53_first = true;
                        bool __tmp53_last = __tmp53Reader.EndOfStream;
                        while(__tmp53_first || !__tmp53_last)
                        {
                            __tmp53_first = false;
                            string __tmp53Line = __tmp53Reader.ReadLine();
                            __tmp53_last = __tmp53Reader.EndOfStream;
                            if (__tmp53Line != null) __out.Append(__tmp53Line);
                            if (!__tmp53_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp54Line = ");"; //915:47
                    if (__tmp54Line != null) __out.Append(__tmp54Line);
                    __out.AppendLine(false); //915:49
                }
            }
            else if (value is Enum) //917:2
            {
                StringBuilder __tmp56 = new StringBuilder();
                __tmp56.Append(name);
                using(StreamReader __tmp56Reader = new StreamReader(this.__ToStream(__tmp56.ToString())))
                {
                    bool __tmp56_first = true;
                    bool __tmp56_last = __tmp56Reader.EndOfStream;
                    while(__tmp56_first || !__tmp56_last)
                    {
                        __tmp56_first = false;
                        string __tmp56Line = __tmp56Reader.ReadLine();
                        __tmp56_last = __tmp56Reader.EndOfStream;
                        if (__tmp56Line != null) __out.Append(__tmp56Line);
                        if (!__tmp56_last) __out.AppendLine(true);
                    }
                }
                string __tmp57Line = "."; //918:7
                if (__tmp57Line != null) __out.Append(__tmp57Line);
                StringBuilder __tmp58 = new StringBuilder();
                __tmp58.Append(prop.Name);
                using(StreamReader __tmp58Reader = new StreamReader(this.__ToStream(__tmp58.ToString())))
                {
                    bool __tmp58_first = true;
                    bool __tmp58_last = __tmp58Reader.EndOfStream;
                    while(__tmp58_first || !__tmp58_last)
                    {
                        __tmp58_first = false;
                        string __tmp58Line = __tmp58Reader.ReadLine();
                        __tmp58_last = __tmp58Reader.EndOfStream;
                        if (__tmp58Line != null) __out.Append(__tmp58Line);
                        if (!__tmp58_last) __out.AppendLine(true);
                    }
                }
                string __tmp59Line = ".Add("; //918:19
                if (__tmp59Line != null) __out.Append(__tmp59Line);
                StringBuilder __tmp60 = new StringBuilder();
                __tmp60.Append(GetEnumValueOf(value));
                using(StreamReader __tmp60Reader = new StreamReader(this.__ToStream(__tmp60.ToString())))
                {
                    bool __tmp60_first = true;
                    bool __tmp60_last = __tmp60Reader.EndOfStream;
                    while(__tmp60_first || !__tmp60_last)
                    {
                        __tmp60_first = false;
                        string __tmp60Line = __tmp60Reader.ReadLine();
                        __tmp60_last = __tmp60Reader.EndOfStream;
                        if (__tmp60Line != null) __out.Append(__tmp60Line);
                        if (!__tmp60_last) __out.AppendLine(true);
                    }
                }
                string __tmp61Line = ");"; //918:47
                if (__tmp61Line != null) __out.Append(__tmp61Line);
                __out.AppendLine(false); //918:49
            }
            else if (moValue != null) //919:2
            {
                if (mobjToName.ContainsKey(moValue)) //920:3
                {
                    StringBuilder __tmp63 = new StringBuilder();
                    __tmp63.Append(name);
                    using(StreamReader __tmp63Reader = new StreamReader(this.__ToStream(__tmp63.ToString())))
                    {
                        bool __tmp63_first = true;
                        bool __tmp63_last = __tmp63Reader.EndOfStream;
                        while(__tmp63_first || !__tmp63_last)
                        {
                            __tmp63_first = false;
                            string __tmp63Line = __tmp63Reader.ReadLine();
                            __tmp63_last = __tmp63Reader.EndOfStream;
                            if (__tmp63Line != null) __out.Append(__tmp63Line);
                            if (!__tmp63_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp64Line = "."; //921:7
                    if (__tmp64Line != null) __out.Append(__tmp64Line);
                    StringBuilder __tmp65 = new StringBuilder();
                    __tmp65.Append(prop.Name);
                    using(StreamReader __tmp65Reader = new StreamReader(this.__ToStream(__tmp65.ToString())))
                    {
                        bool __tmp65_first = true;
                        bool __tmp65_last = __tmp65Reader.EndOfStream;
                        while(__tmp65_first || !__tmp65_last)
                        {
                            __tmp65_first = false;
                            string __tmp65Line = __tmp65Reader.ReadLine();
                            __tmp65_last = __tmp65Reader.EndOfStream;
                            if (__tmp65Line != null) __out.Append(__tmp65Line);
                            if (!__tmp65_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp66Line = ".AddLazy(() => "; //921:19
                    if (__tmp66Line != null) __out.Append(__tmp66Line);
                    StringBuilder __tmp67 = new StringBuilder();
                    __tmp67.Append(mobjToName[moValue]);
                    using(StreamReader __tmp67Reader = new StreamReader(this.__ToStream(__tmp67.ToString())))
                    {
                        bool __tmp67_first = true;
                        bool __tmp67_last = __tmp67Reader.EndOfStream;
                        while(__tmp67_first || !__tmp67_last)
                        {
                            __tmp67_first = false;
                            string __tmp67Line = __tmp67Reader.ReadLine();
                            __tmp67_last = __tmp67Reader.EndOfStream;
                            if (__tmp67Line != null) __out.Append(__tmp67Line);
                            if (!__tmp67_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp68Line = ");"; //921:55
                    if (__tmp68Line != null) __out.Append(__tmp68Line);
                    __out.AppendLine(false); //921:57
                }
                else //922:3
                {
                    string __tmp70Line = "// Omitted since not part of the model: "; //923:1
                    if (__tmp70Line != null) __out.Append(__tmp70Line);
                    StringBuilder __tmp71 = new StringBuilder();
                    __tmp71.Append(name);
                    using(StreamReader __tmp71Reader = new StreamReader(this.__ToStream(__tmp71.ToString())))
                    {
                        bool __tmp71_first = true;
                        bool __tmp71_last = __tmp71Reader.EndOfStream;
                        while(__tmp71_first || !__tmp71_last)
                        {
                            __tmp71_first = false;
                            string __tmp71Line = __tmp71Reader.ReadLine();
                            __tmp71_last = __tmp71Reader.EndOfStream;
                            if (__tmp71Line != null) __out.Append(__tmp71Line);
                            if (!__tmp71_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp72Line = "."; //923:47
                    if (__tmp72Line != null) __out.Append(__tmp72Line);
                    StringBuilder __tmp73 = new StringBuilder();
                    __tmp73.Append(prop.Name);
                    using(StreamReader __tmp73Reader = new StreamReader(this.__ToStream(__tmp73.ToString())))
                    {
                        bool __tmp73_first = true;
                        bool __tmp73_last = __tmp73Reader.EndOfStream;
                        while(__tmp73_first || !__tmp73_last)
                        {
                            __tmp73_first = false;
                            string __tmp73Line = __tmp73Reader.ReadLine();
                            __tmp73_last = __tmp73Reader.EndOfStream;
                            if (__tmp73Line != null) __out.Append(__tmp73Line);
                            if (!__tmp73_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp74Line = " = "; //923:59
                    if (__tmp74Line != null) __out.Append(__tmp74Line);
                    StringBuilder __tmp75 = new StringBuilder();
                    __tmp75.Append(moValue);
                    using(StreamReader __tmp75Reader = new StreamReader(this.__ToStream(__tmp75.ToString())))
                    {
                        bool __tmp75_first = true;
                        bool __tmp75_last = __tmp75Reader.EndOfStream;
                        while(__tmp75_first || !__tmp75_last)
                        {
                            __tmp75_first = false;
                            string __tmp75Line = __tmp75Reader.ReadLine();
                            __tmp75_last = __tmp75Reader.EndOfStream;
                            if (__tmp75Line != null) __out.Append(__tmp75Line);
                            if (!__tmp75_last) __out.AppendLine(true);
                            __out.AppendLine(false); //923:71
                        }
                    }
                }
            }
            else //925:2
            {
                IEnumerable<object> mc = (value as ModelCollection) as IEnumerable<object>; //926:3
                if (mc != null) //927:3
                {
                    var __loop60_results = 
                        (from cvalue in __Enumerate((mc).GetEnumerator()) //928:9
                        select new { cvalue = cvalue}
                        ).ToList(); //928:4
                    int __loop60_iteration = 0;
                    foreach (var __tmp76 in __loop60_results)
                    {
                        ++__loop60_iteration;
                        var cvalue = __tmp76.cvalue;
                        StringBuilder __tmp78 = new StringBuilder();
                        __tmp78.Append(GenerateModelObjectPropertyCollectionValue(coreModel, mobj, prop, cvalue, mobjToName));
                        using(StreamReader __tmp78Reader = new StreamReader(this.__ToStream(__tmp78.ToString())))
                        {
                            bool __tmp78_first = true;
                            bool __tmp78_last = __tmp78Reader.EndOfStream;
                            while(__tmp78_first || !__tmp78_last)
                            {
                                __tmp78_first = false;
                                string __tmp78Line = __tmp78Reader.ReadLine();
                                __tmp78_last = __tmp78Reader.EndOfStream;
                                if (__tmp78Line != null) __out.Append(__tmp78Line);
                                if (!__tmp78_last) __out.AppendLine(true);
                                __out.AppendLine(false); //929:88
                            }
                        }
                    }
                }
                else //931:3
                {
                    string __tmp80Line = "// Invalid property value type: "; //932:1
                    if (__tmp80Line != null) __out.Append(__tmp80Line);
                    StringBuilder __tmp81 = new StringBuilder();
                    __tmp81.Append(name);
                    using(StreamReader __tmp81Reader = new StreamReader(this.__ToStream(__tmp81.ToString())))
                    {
                        bool __tmp81_first = true;
                        bool __tmp81_last = __tmp81Reader.EndOfStream;
                        while(__tmp81_first || !__tmp81_last)
                        {
                            __tmp81_first = false;
                            string __tmp81Line = __tmp81Reader.ReadLine();
                            __tmp81_last = __tmp81Reader.EndOfStream;
                            if (__tmp81Line != null) __out.Append(__tmp81Line);
                            if (!__tmp81_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp82Line = "."; //932:39
                    if (__tmp82Line != null) __out.Append(__tmp82Line);
                    StringBuilder __tmp83 = new StringBuilder();
                    __tmp83.Append(prop.Name);
                    using(StreamReader __tmp83Reader = new StreamReader(this.__ToStream(__tmp83.ToString())))
                    {
                        bool __tmp83_first = true;
                        bool __tmp83_last = __tmp83Reader.EndOfStream;
                        while(__tmp83_first || !__tmp83_last)
                        {
                            __tmp83_first = false;
                            string __tmp83Line = __tmp83Reader.ReadLine();
                            __tmp83_last = __tmp83Reader.EndOfStream;
                            if (__tmp83Line != null) __out.Append(__tmp83Line);
                            if (!__tmp83_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp84Line = " = "; //932:51
                    if (__tmp84Line != null) __out.Append(__tmp84Line);
                    StringBuilder __tmp85 = new StringBuilder();
                    __tmp85.Append(value.GetType());
                    using(StreamReader __tmp85Reader = new StreamReader(this.__ToStream(__tmp85.ToString())))
                    {
                        bool __tmp85_first = true;
                        bool __tmp85_last = __tmp85Reader.EndOfStream;
                        while(__tmp85_first || !__tmp85_last)
                        {
                            __tmp85_first = false;
                            string __tmp85Line = __tmp85Reader.ReadLine();
                            __tmp85_last = __tmp85Reader.EndOfStream;
                            if (__tmp85Line != null) __out.Append(__tmp85Line);
                            if (!__tmp85_last) __out.AppendLine(true);
                            __out.AppendLine(false); //932:71
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GetEnumValueOf(object enm) //937:1
        {
            string result = "global::" + enm.GetType().FullName.Replace("+", ".") + "." + enm.ToString(); //938:2
            if (!result.StartsWith("global::MetaDslx.Core.Immutable.") && result.StartsWith("global::MetaDslx.Core.")) //939:2
            {
                result = result.Replace("global::MetaDslx.Core.", "global::MetaDslx.Core.Immutable."); //940:3
            }
            return result; //942:2
        }

        public string GenerateTypeOf(object expr) //945:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //946:9
            if (expr is MetaPrimitiveType) //947:2
            {
                var __tmp2 = ((MetaPrimitiveType)expr).Name; //948:9
                if (__tmp2 == "*none*") //949:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.None.ToMutable() : null"); //949:17
                }
                else if (__tmp2 == "*error*") //950:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Error.ToMutable() : null"); //950:18
                }
                else if (__tmp2 == "*any*") //951:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Any.ToMutable() : null"); //951:16
                }
                else if (__tmp2 == "object") //952:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Object.ToMutable() : null"); //952:17
                }
                else if (__tmp2 == "string") //953:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.String.ToMutable() : null"); //953:17
                }
                else if (__tmp2 == "int") //954:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Int.ToMutable() : null"); //954:14
                }
                else if (__tmp2 == "long") //955:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Long.ToMutable() : null"); //955:15
                }
                else if (__tmp2 == "float") //956:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Float.ToMutable() : null"); //956:16
                }
                else if (__tmp2 == "double") //957:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Double.ToMutable() : null"); //957:17
                }
                else if (__tmp2 == "byte") //958:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Byte.ToMutable() : null"); //958:15
                }
                else if (__tmp2 == "bool") //959:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Bool.ToMutable() : null"); //959:15
                }
                else if (__tmp2 == "void") //960:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Void.ToMutable() : null"); //960:15
                }
                else if (__tmp2 == "ModelObject") //961:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.ModelObject.ToMutable() : null"); //961:22
                }
                else if (__tmp2 == "ModelObjectList") //962:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.ModelObjectList.ToMutable() : null"); //962:26
                }
                else if (__tmp2 == "DefinitionList") //963:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.DefinitionList.ToMutable() : null"); //963:25
                }//964:2
            }
            else if (expr is MetaClass) //965:2
            {
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(((MetaClass)expr).CSharpFullDescriptorName(ClassKind.Immutable));
                using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                {
                    bool __tmp5_first = true;
                    bool __tmp5_last = __tmp5Reader.EndOfStream;
                    while(__tmp5_first || !__tmp5_last)
                    {
                        __tmp5_first = false;
                        string __tmp5Line = __tmp5Reader.ReadLine();
                        __tmp5_last = __tmp5Reader.EndOfStream;
                        if (__tmp5Line != null) __out.Append(__tmp5Line);
                        if (!__tmp5_last) __out.AppendLine(true);
                    }
                }
                string __tmp6Line = ".MetaClass"; //965:73
                if (__tmp6Line != null) __out.Append(__tmp6Line);
            }
            else if (expr is MetaCollectionType) //966:2
            {
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append(((MetaCollectionType)expr).CSharpFullName(ClassKind.Immutable));
                using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                {
                    bool __tmp9_first = true;
                    bool __tmp9_last = __tmp9Reader.EndOfStream;
                    while(__tmp9_first || !__tmp9_last)
                    {
                        __tmp9_first = false;
                        string __tmp9Line = __tmp9Reader.ReadLine();
                        __tmp9_last = __tmp9Reader.EndOfStream;
                        if (__tmp9Line != null) __out.Append(__tmp9Line);
                        if (!__tmp9_last) __out.AppendLine(true);
                    }
                }
            }
            else //967:2
            {
                __out.Append("***error***"); //967:11
            }//968:2
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
