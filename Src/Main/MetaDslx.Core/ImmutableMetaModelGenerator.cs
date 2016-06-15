using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core //1:1
{
    using __Hidden_ImmutableMetaModelGenerator_2000174965;
    namespace __Hidden_ImmutableMetaModelGenerator_2000174965
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
            if (result == "" && classKind != ClassKind.ChildBuilder) //80:2
            {
                result = " : global::MetaDslx.Core.Immutable.ISymbol"; //81:3
            }
            return result; //83:2
        }

        public string GenerateImmutableInterface(MetaClass cls) //86:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal class "; //87:1
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
            string __tmp4Line = "Id : SymbolId"; //87:53
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //87:66
            __out.Append("{"); //88:1
            __out.AppendLine(false); //88:2
            string __tmp6Line = "    public override System.Type ImmutableType { get { return typeof("; //89:1
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(cls.CSharpName(ClassKind.Immutable));
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
            string __tmp8Line = "); } }"; //89:106
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //89:112
            string __tmp10Line = "    public override System.Type MutableType { get { return typeof("; //90:1
            if (__tmp10Line != null) __out.Append(__tmp10Line);
            StringBuilder __tmp11 = new StringBuilder();
            __tmp11.Append(cls.CSharpName(ClassKind.Builder));
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
            string __tmp12Line = "); } }"; //90:102
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //90:108
            __out.AppendLine(true); //91:1
            __out.Append("    public override global::MetaDslx.Core.Immutable.IImmutableSymbol CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)"); //92:1
            __out.AppendLine(false); //92:139
            __out.Append("    {"); //93:1
            __out.AppendLine(false); //93:6
            string __tmp14Line = "        return new "; //94:1
            if (__tmp14Line != null) __out.Append(__tmp14Line);
            StringBuilder __tmp15 = new StringBuilder();
            __tmp15.Append(cls.CSharpImplName(ClassKind.Immutable));
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
            string __tmp16Line = "(this, model);"; //94:61
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            __out.AppendLine(false); //94:75
            __out.Append("    }"); //95:1
            __out.AppendLine(false); //95:6
            __out.AppendLine(true); //96:1
            __out.Append("    public override global::MetaDslx.Core.Immutable.IMutableSymbol CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool created)"); //97:1
            __out.AppendLine(false); //97:147
            __out.Append("    {"); //98:1
            __out.AppendLine(false); //98:6
            string __tmp18Line = "        return new "; //99:1
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            StringBuilder __tmp19 = new StringBuilder();
            __tmp19.Append(cls.CSharpImplName(ClassKind.Builder));
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
            string __tmp20Line = "(this, model, created);"; //99:59
            if (__tmp20Line != null) __out.Append(__tmp20Line);
            __out.AppendLine(false); //99:82
            __out.Append("    }"); //100:1
            __out.AppendLine(false); //100:6
            __out.Append("}"); //101:1
            __out.AppendLine(false); //101:2
            __out.AppendLine(true); //102:1
            StringBuilder __tmp22 = new StringBuilder();
            __tmp22.Append(GenerateAnnotations(cls));
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
                    __out.AppendLine(false); //103:27
                }
            }
            string __tmp24Line = "public interface "; //104:1
            if (__tmp24Line != null) __out.Append(__tmp24Line);
            StringBuilder __tmp25 = new StringBuilder();
            __tmp25.Append(cls.CSharpName(ClassKind.Immutable));
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
            StringBuilder __tmp26 = new StringBuilder();
            __tmp26.Append(GetAncestors(cls, ClassKind.Immutable));
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
                    __out.AppendLine(false); //104:95
                }
            }
            __out.Append("{"); //105:1
            __out.AppendLine(false); //105:2
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((cls).GetEnumerator()) //106:11
                from prop in __Enumerate((__loop11_var1.Properties).GetEnumerator()) //106:16
                select new { __loop11_var1 = __loop11_var1, prop = prop}
                ).ToList(); //106:6
            int __loop11_iteration = 0;
            foreach (var __tmp27 in __loop11_results)
            {
                ++__loop11_iteration;
                var __loop11_var1 = __tmp27.__loop11_var1;
                var prop = __tmp27.prop;
                string __tmp28Prefix = "    "; //107:1
                StringBuilder __tmp29 = new StringBuilder();
                __tmp29.Append(GenerateImmutableProperty(prop));
                using(StreamReader __tmp29Reader = new StreamReader(this.__ToStream(__tmp29.ToString())))
                {
                    bool __tmp29_first = true;
                    bool __tmp29_last = __tmp29Reader.EndOfStream;
                    while(__tmp29_first || !__tmp29_last)
                    {
                        __tmp29_first = false;
                        string __tmp29Line = __tmp29Reader.ReadLine();
                        __tmp29_last = __tmp29Reader.EndOfStream;
                        __out.Append(__tmp28Prefix);
                        if (__tmp29Line != null) __out.Append(__tmp29Line);
                        if (!__tmp29_last) __out.AppendLine(true);
                        __out.AppendLine(false); //107:38
                    }
                }
            }
            __out.AppendLine(true); //109:1
            var __loop12_results = 
                (from __loop12_var1 in __Enumerate((cls).GetEnumerator()) //110:11
                from op in __Enumerate((__loop12_var1.Operations).GetEnumerator()) //110:16
                select new { __loop12_var1 = __loop12_var1, op = op}
                ).ToList(); //110:6
            int __loop12_iteration = 0;
            foreach (var __tmp30 in __loop12_results)
            {
                ++__loop12_iteration;
                var __loop12_var1 = __tmp30.__loop12_var1;
                var op = __tmp30.op;
                string __tmp31Prefix = "    "; //111:1
                StringBuilder __tmp32 = new StringBuilder();
                __tmp32.Append(GenerateOperation(op));
                using(StreamReader __tmp32Reader = new StreamReader(this.__ToStream(__tmp32.ToString())))
                {
                    bool __tmp32_first = true;
                    bool __tmp32_last = __tmp32Reader.EndOfStream;
                    while(__tmp32_first || !__tmp32_last)
                    {
                        __tmp32_first = false;
                        string __tmp32Line = __tmp32Reader.ReadLine();
                        __tmp32_last = __tmp32Reader.EndOfStream;
                        __out.Append(__tmp31Prefix);
                        if (__tmp32Line != null) __out.Append(__tmp32Line);
                        if (!__tmp32_last) __out.AppendLine(true);
                        __out.AppendLine(false); //111:28
                    }
                }
            }
            __out.AppendLine(true); //113:1
            if (cls.SuperClasses.Count > 0) //114:3
            {
                string __tmp34Line = "	new "; //115:1
                if (__tmp34Line != null) __out.Append(__tmp34Line);
                StringBuilder __tmp35 = new StringBuilder();
                __tmp35.Append(cls.CSharpName(ClassKind.Builder));
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
                string __tmp36Line = " ToMutable();"; //115:41
                if (__tmp36Line != null) __out.Append(__tmp36Line);
                __out.AppendLine(false); //115:54
                string __tmp38Line = "	new "; //116:1
                if (__tmp38Line != null) __out.Append(__tmp38Line);
                StringBuilder __tmp39 = new StringBuilder();
                __tmp39.Append(cls.CSharpName(ClassKind.Builder));
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
                string __tmp40Line = " ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);"; //116:41
                if (__tmp40Line != null) __out.Append(__tmp40Line);
                __out.AppendLine(false); //116:104
            }
            else //117:3
            {
                string __tmp41Prefix = "	"; //118:1
                StringBuilder __tmp42 = new StringBuilder();
                __tmp42.Append(cls.CSharpName(ClassKind.Builder));
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
                string __tmp43Line = " ToMutable();"; //118:37
                if (__tmp43Line != null) __out.Append(__tmp43Line);
                __out.AppendLine(false); //118:50
                string __tmp44Prefix = "	"; //119:1
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
                        __out.Append(__tmp44Prefix);
                        if (__tmp45Line != null) __out.Append(__tmp45Line);
                        if (!__tmp45_last) __out.AppendLine(true);
                    }
                }
                string __tmp46Line = " ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);"; //119:37
                if (__tmp46Line != null) __out.Append(__tmp46Line);
                __out.AppendLine(false); //119:100
            }
            __out.Append("}"); //121:1
            __out.AppendLine(false); //121:2
            __out.AppendLine(true); //122:1
            return __out.ToString();
        }

        public string GenerateBuilderInterface(MetaClass cls) //125:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "public interface "; //126:1
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
                    __out.AppendLine(false); //126:91
                }
            }
            __out.Append("{"); //127:1
            __out.AppendLine(false); //127:2
            var __loop13_results = 
                (from __loop13_var1 in __Enumerate((cls).GetEnumerator()) //128:11
                from prop in __Enumerate((__loop13_var1.Properties).GetEnumerator()) //128:16
                select new { __loop13_var1 = __loop13_var1, prop = prop}
                ).ToList(); //128:6
            int __loop13_iteration = 0;
            foreach (var __tmp5 in __loop13_results)
            {
                ++__loop13_iteration;
                var __loop13_var1 = __tmp5.__loop13_var1;
                var prop = __tmp5.prop;
                string __tmp6Prefix = "    "; //129:1
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
                        __out.AppendLine(false); //129:36
                    }
                }
            }
            __out.AppendLine(true); //131:1
            if (cls.SuperClasses.Count > 0) //132:3
            {
                string __tmp9Line = "	new "; //133:1
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
                string __tmp11Line = " ToImmutable();"; //133:43
                if (__tmp11Line != null) __out.Append(__tmp11Line);
                __out.AppendLine(false); //133:58
                string __tmp13Line = "	new "; //134:1
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
                string __tmp15Line = " ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);"; //134:43
                if (__tmp15Line != null) __out.Append(__tmp15Line);
                __out.AppendLine(false); //134:110
            }
            else //135:3
            {
                string __tmp16Prefix = "	"; //136:1
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(cls.CSharpName(ClassKind.Immutable));
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
                    }
                }
                string __tmp18Line = " ToImmutable();"; //136:39
                if (__tmp18Line != null) __out.Append(__tmp18Line);
                __out.AppendLine(false); //136:54
                string __tmp19Prefix = "	"; //137:1
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(cls.CSharpName(ClassKind.Immutable));
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
                string __tmp21Line = " ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);"; //137:39
                if (__tmp21Line != null) __out.Append(__tmp21Line);
                __out.AppendLine(false); //137:106
            }
            __out.Append("}"); //139:1
            __out.AppendLine(false); //139:2
            __out.AppendLine(true); //140:1
            string __tmp23Line = "public interface "; //141:1
            if (__tmp23Line != null) __out.Append(__tmp23Line);
            StringBuilder __tmp24 = new StringBuilder();
            __tmp24.Append(cls.CSharpName(ClassKind.ChildBuilder));
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
            StringBuilder __tmp25 = new StringBuilder();
            __tmp25.Append(GetAncestors(cls, ClassKind.ChildBuilder));
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
                    __out.AppendLine(false); //141:101
                }
            }
            __out.Append("{"); //142:1
            __out.AppendLine(false); //142:2
            var __loop14_results = 
                (from __loop14_var1 in __Enumerate((cls).GetEnumerator()) //143:11
                from prop in __Enumerate((__loop14_var1.Properties).GetEnumerator()) //143:16
                select new { __loop14_var1 = __loop14_var1, prop = prop}
                ).ToList(); //143:6
            int __loop14_iteration = 0;
            foreach (var __tmp26 in __loop14_results)
            {
                ++__loop14_iteration;
                var __loop14_var1 = __tmp26.__loop14_var1;
                var prop = __tmp26.prop;
                string __tmp27Prefix = "    "; //144:1
                StringBuilder __tmp28 = new StringBuilder();
                __tmp28.Append(GenerateChildBuilderProperty(prop));
                using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
                {
                    bool __tmp28_first = true;
                    bool __tmp28_last = __tmp28Reader.EndOfStream;
                    while(__tmp28_first || !__tmp28_last)
                    {
                        __tmp28_first = false;
                        string __tmp28Line = __tmp28Reader.ReadLine();
                        __tmp28_last = __tmp28Reader.EndOfStream;
                        __out.Append(__tmp27Prefix);
                        if (__tmp28Line != null) __out.Append(__tmp28Line);
                        if (!__tmp28_last) __out.AppendLine(true);
                        __out.AppendLine(false); //144:41
                    }
                }
            }
            __out.Append("}"); //146:1
            __out.AppendLine(false); //146:2
            __out.AppendLine(true); //147:1
            return __out.ToString();
        }

        public string GenerateImmutableProperty(MetaProperty prop) //150:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //151:2
            {
                __out.Append("new "); //152:1
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
            string __tmp3Line = " "; //154:54
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
            string __tmp5Line = " { get; }"; //154:66
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            __out.AppendLine(false); //154:75
            return __out.ToString();
        }

        public string GenerateImmutableField(MetaClass cls, MetaProperty prop) //157:1
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
                    __out.AppendLine(false); //158:54
                }
            }
            string __tmp4Line = "private "; //159:1
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
            string __tmp6Line = " "; //159:62
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
            string __tmp8Line = ";"; //159:87
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //159:88
            return __out.ToString();
        }

        public string GenerateBuilderProperty(MetaProperty prop) //162:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //163:2
            {
                __out.Append("new "); //164:1
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //166:3
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
                string __tmp3Line = " "; //167:52
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
                string __tmp5Line = " { get; set; }"; //167:64
                if (__tmp5Line != null) __out.Append(__tmp5Line);
                __out.AppendLine(false); //167:78
            }
            else //168:3
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
                string __tmp8Line = " "; //169:52
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
                string __tmp10Line = " { get; }"; //169:64
                if (__tmp10Line != null) __out.Append(__tmp10Line);
                __out.AppendLine(false); //169:73
            }
            if (!(prop.Type is MetaCollectionType)) //171:2
            {
                if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //172:3
                {
                    __out.Append("new "); //173:1
                }
                string __tmp12Line = "Func<"; //175:1
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
                string __tmp14Line = "> "; //175:57
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
                string __tmp16Line = "Lazy { get; set; }"; //175:70
                if (__tmp16Line != null) __out.Append(__tmp16Line);
                __out.AppendLine(false); //175:88
            }
            if (prop.Kind == MetaPropertyKind.Containment && (((prop.Type is MetaCollectionType) && (((MetaCollectionType)prop.Type).InnerType is MetaClass)) || (!(prop.Type is MetaCollectionType) && prop.Type is MetaClass))) //177:2
            {
                if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //178:3
                {
                    __out.Append("new "); //179:1
                }
                if (prop.Type is MetaCollectionType) //181:3
                {
                    StringBuilder __tmp18 = new StringBuilder();
                    __tmp18.Append(((MetaCollectionType)prop.Type).InnerType.CSharpFullPublicName(ClassKind.ChildBuilder));
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
                    string __tmp19Line = " "; //182:89
                    if (__tmp19Line != null) __out.Append(__tmp19Line);
                    StringBuilder __tmp20 = new StringBuilder();
                    __tmp20.Append(prop.Name);
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
                    string __tmp21Line = "LazyChild { get; }"; //182:101
                    if (__tmp21Line != null) __out.Append(__tmp21Line);
                    __out.AppendLine(false); //182:119
                }
                else //183:3
                {
                    StringBuilder __tmp23 = new StringBuilder();
                    __tmp23.Append(prop.Type.CSharpFullPublicName(ClassKind.ChildBuilder));
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
                    string __tmp24Line = " "; //184:57
                    if (__tmp24Line != null) __out.Append(__tmp24Line);
                    StringBuilder __tmp25 = new StringBuilder();
                    __tmp25.Append(prop.Name);
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
                    string __tmp26Line = "LazyChild { get; }"; //184:69
                    if (__tmp26Line != null) __out.Append(__tmp26Line);
                    __out.AppendLine(false); //184:87
                }
            }
            return __out.ToString();
        }

        public string GenerateChildBuilderProperty(MetaProperty prop) //189:1
        {
            StringBuilder __out = new StringBuilder();
            if (!(prop.Type is MetaCollectionType)) //190:2
            {
                if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //191:3
                {
                    __out.Append("new "); //192:1
                }
                string __tmp2Line = "Func<"; //194:1
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
                string __tmp4Line = "> "; //194:57
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
                    }
                }
                string __tmp6Line = " { set; }"; //194:70
                if (__tmp6Line != null) __out.Append(__tmp6Line);
                __out.AppendLine(false); //194:79
            }
            return __out.ToString();
        }

        public string GenerateBuilderField(MetaClass cls, MetaProperty prop) //198:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "private "; //199:1
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
            string __tmp4Line = " "; //199:60
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
            string __tmp6Line = ";"; //199:85
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            __out.AppendLine(false); //199:86
            return __out.ToString();
        }

        public string GetParameters(MetaFunction op, ClassKind classKind) //202:1
        {
            string result = ""; //203:2
            var __loop15_results = 
                (from __loop15_var1 in __Enumerate((op).GetEnumerator()) //204:7
                from param in __Enumerate((__loop15_var1.Parameters).GetEnumerator()) //204:11
                select new { __loop15_var1 = __loop15_var1, param = param}
                ).ToList(); //204:2
            int __loop15_iteration = 0;
            string delim = ""; //204:29
            foreach (var __tmp1 in __loop15_results)
            {
                ++__loop15_iteration;
                if (__loop15_iteration >= 2) //204:48
                {
                    delim = ", "; //204:48
                }
                var __loop15_var1 = __tmp1.__loop15_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(classKind) + " " + param.Name; //205:3
            }
            return result; //207:2
        }

        public string GetImplParameters(MetaClass cls, MetaOperation op) //210:1
        {
            string result = cls.CSharpFullName(ClassKind.Immutable) + " @this"; //211:2
            string delim = ", "; //212:2
            var __loop16_results = 
                (from __loop16_var1 in __Enumerate((op).GetEnumerator()) //213:7
                from param in __Enumerate((__loop16_var1.Parameters).GetEnumerator()) //213:11
                select new { __loop16_var1 = __loop16_var1, param = param}
                ).ToList(); //213:2
            int __loop16_iteration = 0;
            foreach (var __tmp1 in __loop16_results)
            {
                ++__loop16_iteration;
                var __loop16_var1 = __tmp1.__loop16_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(ClassKind.Immutable) + " " + param.Name; //214:3
            }
            return result; //216:2
        }

        public string GetImplParameters(MetaEnum enm, MetaOperation op) //219:1
        {
            string result = enm.CSharpFullName(ClassKind.Immutable) + " @this"; //220:2
            string delim = ", "; //221:2
            var __loop17_results = 
                (from __loop17_var1 in __Enumerate((op).GetEnumerator()) //222:7
                from param in __Enumerate((__loop17_var1.Parameters).GetEnumerator()) //222:11
                select new { __loop17_var1 = __loop17_var1, param = param}
                ).ToList(); //222:2
            int __loop17_iteration = 0;
            foreach (var __tmp1 in __loop17_results)
            {
                ++__loop17_iteration;
                var __loop17_var1 = __tmp1.__loop17_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(ClassKind.Immutable) + " " + param.Name; //223:3
            }
            return result; //225:2
        }

        public string GetEnumImplParameters(MetaEnum enm, MetaOperation op) //228:1
        {
            string result = "this " + enm.CSharpFullName(ClassKind.Immutable) + " @this"; //229:2
            string delim = ", "; //230:2
            var __loop18_results = 
                (from __loop18_var1 in __Enumerate((op).GetEnumerator()) //231:7
                from param in __Enumerate((__loop18_var1.Parameters).GetEnumerator()) //231:11
                select new { __loop18_var1 = __loop18_var1, param = param}
                ).ToList(); //231:2
            int __loop18_iteration = 0;
            foreach (var __tmp1 in __loop18_results)
            {
                ++__loop18_iteration;
                var __loop18_var1 = __tmp1.__loop18_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(ClassKind.Immutable) + " " + param.Name; //232:3
            }
            return result; //234:2
        }

        public string GetEnumImplCallParameterNames(MetaOperation op) //237:1
        {
            string result = "@this"; //238:2
            string delim = ", "; //239:2
            var __loop19_results = 
                (from __loop19_var1 in __Enumerate((op).GetEnumerator()) //240:7
                from param in __Enumerate((__loop19_var1.Parameters).GetEnumerator()) //240:11
                select new { __loop19_var1 = __loop19_var1, param = param}
                ).ToList(); //240:2
            int __loop19_iteration = 0;
            foreach (var __tmp1 in __loop19_results)
            {
                ++__loop19_iteration;
                var __loop19_var1 = __tmp1.__loop19_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //241:3
            }
            return result; //243:2
        }

        public string GetImplCallParameterNames(MetaOperation op) //246:1
        {
            string result = "this"; //247:2
            string delim = ", "; //248:2
            var __loop20_results = 
                (from __loop20_var1 in __Enumerate((op).GetEnumerator()) //249:7
                from param in __Enumerate((__loop20_var1.Parameters).GetEnumerator()) //249:11
                select new { __loop20_var1 = __loop20_var1, param = param}
                ).ToList(); //249:2
            int __loop20_iteration = 0;
            foreach (var __tmp1 in __loop20_results)
            {
                ++__loop20_iteration;
                var __loop20_var1 = __tmp1.__loop20_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //250:3
            }
            return result; //252:2
        }

        public string GenerateOperation(MetaOperation op) //255:1
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
            string __tmp3Line = " "; //256:58
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
            string __tmp5Line = "("; //256:68
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
            string __tmp7Line = ");"; //256:109
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //256:111
            return __out.ToString();
        }

        public string GenerateImmutableInterfaceImpl(MetaModel model, MetaClass cls) //259:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal class "; //260:1
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
            string __tmp4Line = " : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, "; //260:57
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
                    __out.AppendLine(false); //260:154
                }
            }
            __out.Append("{"); //261:1
            __out.AppendLine(false); //261:2
            var __loop21_results = 
                (from __loop21_var1 in __Enumerate((cls).GetEnumerator()) //262:11
                from prop in __Enumerate((__loop21_var1.GetAllProperties()).GetEnumerator()) //262:16
                select new { __loop21_var1 = __loop21_var1, prop = prop}
                ).ToList(); //262:6
            int __loop21_iteration = 0;
            foreach (var __tmp6 in __loop21_results)
            {
                ++__loop21_iteration;
                var __loop21_var1 = __tmp6.__loop21_var1;
                var prop = __tmp6.prop;
                string __tmp7Prefix = "    "; //263:1
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
                        __out.AppendLine(false); //263:40
                    }
                }
            }
            __out.AppendLine(true); //265:1
            string __tmp10Line = "    internal "; //266:1
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
            string __tmp12Line = "(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)"; //266:36
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //266:135
            __out.Append("		: base(id, model)"); //267:1
            __out.AppendLine(false); //267:20
            __out.Append("    {"); //268:1
            __out.AppendLine(false); //268:6
            __out.Append("    }"); //269:1
            __out.AppendLine(false); //269:6
            __out.AppendLine(true); //270:1
            __out.Append("    public override object MMetaModel"); //271:1
            __out.AppendLine(false); //271:38
            __out.Append("    {"); //272:1
            __out.AppendLine(false); //272:6
            string __tmp14Line = "        get { return null;/*"; //273:1
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
            string __tmp16Line = ";*/ }"; //273:65
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            __out.AppendLine(false); //273:70
            __out.Append("    }"); //274:1
            __out.AppendLine(false); //274:6
            __out.AppendLine(true); //275:1
            __out.Append("    public override object MMetaClass"); //276:1
            __out.AppendLine(false); //276:38
            __out.Append("    {"); //277:1
            __out.AppendLine(false); //277:6
            string __tmp18Line = "        get { return null; /*"; //278:1
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
            string __tmp20Line = ";*/ }"; //278:60
            if (__tmp20Line != null) __out.Append(__tmp20Line);
            __out.AppendLine(false); //278:65
            __out.Append("    }"); //279:1
            __out.AppendLine(false); //279:6
            __out.AppendLine(true); //280:1
            string __tmp22Line = "    public new "; //281:1
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
            string __tmp24Line = " ToMutable()"; //281:55
            if (__tmp24Line != null) __out.Append(__tmp24Line);
            __out.AppendLine(false); //281:67
            __out.Append("	{"); //282:1
            __out.AppendLine(false); //282:3
            string __tmp26Line = "		return ("; //283:1
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
            string __tmp28Line = ")base.ToMutable();"; //283:50
            if (__tmp28Line != null) __out.Append(__tmp28Line);
            __out.AppendLine(false); //283:68
            __out.Append("	}"); //284:1
            __out.AppendLine(false); //284:3
            __out.AppendLine(true); //285:1
            string __tmp30Line = "    public new "; //286:1
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
            string __tmp32Line = " ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)"; //286:55
            if (__tmp32Line != null) __out.Append(__tmp32Line);
            __out.AppendLine(false); //286:117
            __out.Append("	{"); //287:1
            __out.AppendLine(false); //287:3
            string __tmp34Line = "		return ("; //288:1
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
            string __tmp36Line = ")base.ToMutable(model);"; //288:50
            if (__tmp36Line != null) __out.Append(__tmp36Line);
            __out.AppendLine(false); //288:73
            __out.Append("	}"); //289:1
            __out.AppendLine(false); //289:3
            var __loop22_results = 
                (from __loop22_var1 in __Enumerate((cls).GetEnumerator()) //290:8
                from sup in __Enumerate((__loop22_var1.GetAllSuperClasses()).GetEnumerator()) //290:13
                select new { __loop22_var1 = __loop22_var1, sup = sup}
                ).ToList(); //290:3
            int __loop22_iteration = 0;
            foreach (var __tmp37 in __loop22_results)
            {
                ++__loop22_iteration;
                var __loop22_var1 = __tmp37.__loop22_var1;
                var sup = __tmp37.sup;
                __out.AppendLine(true); //291:1
                string __tmp38Prefix = "    "; //292:1
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
                string __tmp40Line = " "; //292:44
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
                string __tmp42Line = ".ToMutable()"; //292:86
                if (__tmp42Line != null) __out.Append(__tmp42Line);
                __out.AppendLine(false); //292:98
                __out.Append("	{"); //293:1
                __out.AppendLine(false); //293:3
                __out.Append("		return this.ToMutable();"); //294:1
                __out.AppendLine(false); //294:27
                __out.Append("	}"); //295:1
                __out.AppendLine(false); //295:3
                __out.AppendLine(true); //296:1
                string __tmp43Prefix = "    "; //297:1
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
                string __tmp45Line = " "; //297:44
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
                string __tmp47Line = ".ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)"; //297:86
                if (__tmp47Line != null) __out.Append(__tmp47Line);
                __out.AppendLine(false); //297:148
                __out.Append("	{"); //298:1
                __out.AppendLine(false); //298:3
                __out.Append("		return this.ToMutable(model);"); //299:1
                __out.AppendLine(false); //299:32
                __out.Append("	}"); //300:1
                __out.AppendLine(false); //300:3
            }
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((cls).GetEnumerator()) //302:11
                from prop in __Enumerate((__loop23_var1.GetAllProperties()).GetEnumerator()) //302:16
                select new { __loop23_var1 = __loop23_var1, prop = prop}
                ).ToList(); //302:6
            int __loop23_iteration = 0;
            foreach (var __tmp48 in __loop23_results)
            {
                ++__loop23_iteration;
                var __loop23_var1 = __tmp48.__loop23_var1;
                var prop = __tmp48.prop;
                __out.AppendLine(true); //303:1
                string __tmp49Prefix = "    "; //304:1
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
                        __out.AppendLine(false); //304:54
                    }
                }
            }
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((cls).GetEnumerator()) //306:11
                from op in __Enumerate((__loop24_var1.GetAllOperations()).GetEnumerator()) //306:16
                select new { __loop24_var1 = __loop24_var1, op = op}
                ).ToList(); //306:6
            int __loop24_iteration = 0;
            foreach (var __tmp51 in __loop24_results)
            {
                ++__loop24_iteration;
                var __loop24_var1 = __tmp51.__loop24_var1;
                var op = __tmp51.op;
                __out.AppendLine(true); //307:1
                string __tmp52Prefix = "    "; //308:1
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
                        __out.AppendLine(false); //308:39
                    }
                }
            }
            __out.Append("}"); //310:1
            __out.AppendLine(false); //310:2
            __out.AppendLine(true); //311:1
            return __out.ToString();
        }

        public string GenerateBuilderInterfaceImpl(MetaModel model, MetaClass cls) //314:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal class "; //315:1
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
            string __tmp4Line = " : global::MetaDslx.Core.Immutable.MutableSymbolBase, "; //315:55
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
                    __out.AppendLine(false); //315:148
                }
            }
            __out.Append("{"); //316:1
            __out.AppendLine(false); //316:2
            var __loop25_results = 
                (from __loop25_var1 in __Enumerate((cls).GetEnumerator()) //317:11
                from prop in __Enumerate((__loop25_var1.GetAllProperties()).GetEnumerator()) //317:16
                where prop.Type is MetaCollectionType //317:40
                select new { __loop25_var1 = __loop25_var1, prop = prop}
                ).ToList(); //317:6
            int __loop25_iteration = 0;
            foreach (var __tmp6 in __loop25_results)
            {
                ++__loop25_iteration;
                var __loop25_var1 = __tmp6.__loop25_var1;
                var prop = __tmp6.prop;
                string __tmp7Prefix = "    "; //318:1
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
                        __out.AppendLine(false); //318:38
                    }
                }
            }
            __out.AppendLine(true); //320:1
            string __tmp10Line = "    internal "; //321:1
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
            string __tmp12Line = "(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool created)"; //321:53
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //321:164
            __out.Append("		: base(id, model, created)"); //322:1
            __out.AppendLine(false); //322:29
            __out.Append("    {"); //323:1
            __out.AppendLine(false); //323:6
            __out.Append("		if (!created)"); //324:1
            __out.AppendLine(false); //324:16
            __out.Append("		{"); //325:1
            __out.AppendLine(false); //325:4
            var __loop26_results = 
                (from __loop26_var1 in __Enumerate((cls).GetEnumerator()) //326:10
                from prop in __Enumerate((__loop26_var1.GetAllProperties()).GetEnumerator()) //326:15
                select new { __loop26_var1 = __loop26_var1, prop = prop}
                ).ToList(); //326:5
            int __loop26_iteration = 0;
            foreach (var __tmp13 in __loop26_results)
            {
                ++__loop26_iteration;
                var __loop26_var1 = __tmp13.__loop26_var1;
                var prop = __tmp13.prop;
                string __tmp15Line = "			this.MAttachProperty("; //327:1
                if (__tmp15Line != null) __out.Append(__tmp15Line);
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
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
                string __tmp17Line = ");"; //327:77
                if (__tmp17Line != null) __out.Append(__tmp17Line);
                __out.AppendLine(false); //327:79
            }
            __out.Append("			this.MInit();"); //329:1
            __out.AppendLine(false); //329:17
            __out.Append("		}"); //330:1
            __out.AppendLine(false); //330:4
            __out.Append("    }"); //331:1
            __out.AppendLine(false); //331:6
            __out.AppendLine(true); //332:1
            __out.Append("    protected override void MDoInit()"); //333:1
            __out.AppendLine(false); //333:38
            __out.Append("    {"); //334:1
            __out.AppendLine(false); //334:6
            string __tmp18Prefix = "		"; //335:1
            StringBuilder __tmp19 = new StringBuilder();
            __tmp19.Append(model.Name);
            using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
            {
                bool __tmp19_first = true;
                bool __tmp19_last = __tmp19Reader.EndOfStream;
                while(__tmp19_first || !__tmp19_last)
                {
                    __tmp19_first = false;
                    string __tmp19Line = __tmp19Reader.ReadLine();
                    __tmp19_last = __tmp19Reader.EndOfStream;
                    __out.Append(__tmp18Prefix);
                    if (__tmp19Line != null) __out.Append(__tmp19Line);
                    if (!__tmp19_last) __out.AppendLine(true);
                }
            }
            string __tmp20Line = "ImplementationProvider.Implementation."; //335:15
            if (__tmp20Line != null) __out.Append(__tmp20Line);
            StringBuilder __tmp21 = new StringBuilder();
            __tmp21.Append(cls.CSharpName());
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
            string __tmp22Line = "(this);"; //335:71
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            __out.AppendLine(false); //335:78
            __out.Append("    }"); //336:1
            __out.AppendLine(false); //336:6
            __out.AppendLine(true); //337:1
            __out.Append("    public override object MMetaModel"); //338:1
            __out.AppendLine(false); //338:38
            __out.Append("    {"); //339:1
            __out.AppendLine(false); //339:6
            string __tmp24Line = "        get { return null;/*"; //340:1
            if (__tmp24Line != null) __out.Append(__tmp24Line);
            StringBuilder __tmp25 = new StringBuilder();
            __tmp25.Append(cls.Model.CSharpFullInstanceName());
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
            string __tmp26Line = ";*/ }"; //340:65
            if (__tmp26Line != null) __out.Append(__tmp26Line);
            __out.AppendLine(false); //340:70
            __out.Append("    }"); //341:1
            __out.AppendLine(false); //341:6
            __out.AppendLine(true); //342:1
            __out.Append("    public override object MMetaClass"); //343:1
            __out.AppendLine(false); //343:38
            __out.Append("    {"); //344:1
            __out.AppendLine(false); //344:6
            string __tmp28Line = "        get { return null;/*"; //345:1
            if (__tmp28Line != null) __out.Append(__tmp28Line);
            StringBuilder __tmp29 = new StringBuilder();
            __tmp29.Append(cls.CSharpFullInstanceName());
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
            string __tmp30Line = ";*/ }"; //345:59
            if (__tmp30Line != null) __out.Append(__tmp30Line);
            __out.AppendLine(false); //345:64
            __out.Append("    }"); //346:1
            __out.AppendLine(false); //346:6
            __out.AppendLine(true); //347:1
            string __tmp32Line = "    public new "; //348:1
            if (__tmp32Line != null) __out.Append(__tmp32Line);
            StringBuilder __tmp33 = new StringBuilder();
            __tmp33.Append(cls.CSharpFullName(ClassKind.Immutable));
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
                }
            }
            string __tmp34Line = " ToImmutable()"; //348:57
            if (__tmp34Line != null) __out.Append(__tmp34Line);
            __out.AppendLine(false); //348:71
            __out.Append("	{"); //349:1
            __out.AppendLine(false); //349:3
            string __tmp36Line = "		return ("; //350:1
            if (__tmp36Line != null) __out.Append(__tmp36Line);
            StringBuilder __tmp37 = new StringBuilder();
            __tmp37.Append(cls.CSharpFullName(ClassKind.Immutable));
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
            string __tmp38Line = ")base.ToImmutable();"; //350:52
            if (__tmp38Line != null) __out.Append(__tmp38Line);
            __out.AppendLine(false); //350:72
            __out.Append("	}"); //351:1
            __out.AppendLine(false); //351:3
            __out.AppendLine(true); //352:1
            string __tmp40Line = "    public new "; //353:1
            if (__tmp40Line != null) __out.Append(__tmp40Line);
            StringBuilder __tmp41 = new StringBuilder();
            __tmp41.Append(cls.CSharpFullName(ClassKind.Immutable));
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
            string __tmp42Line = " ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)"; //353:57
            if (__tmp42Line != null) __out.Append(__tmp42Line);
            __out.AppendLine(false); //353:123
            __out.Append("	{"); //354:1
            __out.AppendLine(false); //354:3
            string __tmp44Line = "		return ("; //355:1
            if (__tmp44Line != null) __out.Append(__tmp44Line);
            StringBuilder __tmp45 = new StringBuilder();
            __tmp45.Append(cls.CSharpFullName(ClassKind.Immutable));
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
            string __tmp46Line = ")base.ToImmutable(model);"; //355:52
            if (__tmp46Line != null) __out.Append(__tmp46Line);
            __out.AppendLine(false); //355:77
            __out.Append("	}"); //356:1
            __out.AppendLine(false); //356:3
            var __loop27_results = 
                (from __loop27_var1 in __Enumerate((cls).GetEnumerator()) //357:8
                from sup in __Enumerate((__loop27_var1.GetAllSuperClasses()).GetEnumerator()) //357:13
                select new { __loop27_var1 = __loop27_var1, sup = sup}
                ).ToList(); //357:3
            int __loop27_iteration = 0;
            foreach (var __tmp47 in __loop27_results)
            {
                ++__loop27_iteration;
                var __loop27_var1 = __tmp47.__loop27_var1;
                var sup = __tmp47.sup;
                __out.AppendLine(true); //358:1
                string __tmp48Prefix = "    "; //359:1
                StringBuilder __tmp49 = new StringBuilder();
                __tmp49.Append(sup.CSharpFullName(ClassKind.Immutable));
                using(StreamReader __tmp49Reader = new StreamReader(this.__ToStream(__tmp49.ToString())))
                {
                    bool __tmp49_first = true;
                    bool __tmp49_last = __tmp49Reader.EndOfStream;
                    while(__tmp49_first || !__tmp49_last)
                    {
                        __tmp49_first = false;
                        string __tmp49Line = __tmp49Reader.ReadLine();
                        __tmp49_last = __tmp49Reader.EndOfStream;
                        __out.Append(__tmp48Prefix);
                        if (__tmp49Line != null) __out.Append(__tmp49Line);
                        if (!__tmp49_last) __out.AppendLine(true);
                    }
                }
                string __tmp50Line = " "; //359:46
                if (__tmp50Line != null) __out.Append(__tmp50Line);
                StringBuilder __tmp51 = new StringBuilder();
                __tmp51.Append(sup.CSharpFullName(ClassKind.Builder));
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
                string __tmp52Line = ".ToImmutable()"; //359:86
                if (__tmp52Line != null) __out.Append(__tmp52Line);
                __out.AppendLine(false); //359:100
                __out.Append("	{"); //360:1
                __out.AppendLine(false); //360:3
                __out.Append("		return this.ToImmutable();"); //361:1
                __out.AppendLine(false); //361:29
                __out.Append("	}"); //362:1
                __out.AppendLine(false); //362:3
                __out.AppendLine(true); //363:1
                string __tmp53Prefix = "    "; //364:1
                StringBuilder __tmp54 = new StringBuilder();
                __tmp54.Append(sup.CSharpFullName(ClassKind.Immutable));
                using(StreamReader __tmp54Reader = new StreamReader(this.__ToStream(__tmp54.ToString())))
                {
                    bool __tmp54_first = true;
                    bool __tmp54_last = __tmp54Reader.EndOfStream;
                    while(__tmp54_first || !__tmp54_last)
                    {
                        __tmp54_first = false;
                        string __tmp54Line = __tmp54Reader.ReadLine();
                        __tmp54_last = __tmp54Reader.EndOfStream;
                        __out.Append(__tmp53Prefix);
                        if (__tmp54Line != null) __out.Append(__tmp54Line);
                        if (!__tmp54_last) __out.AppendLine(true);
                    }
                }
                string __tmp55Line = " "; //364:46
                if (__tmp55Line != null) __out.Append(__tmp55Line);
                StringBuilder __tmp56 = new StringBuilder();
                __tmp56.Append(sup.CSharpFullName(ClassKind.Builder));
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
                string __tmp57Line = ".ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)"; //364:86
                if (__tmp57Line != null) __out.Append(__tmp57Line);
                __out.AppendLine(false); //364:152
                __out.Append("	{"); //365:1
                __out.AppendLine(false); //365:3
                __out.Append("		return this.ToImmutable(model);"); //366:1
                __out.AppendLine(false); //366:34
                __out.Append("	}"); //367:1
                __out.AppendLine(false); //367:3
            }
            var __loop28_results = 
                (from __loop28_var1 in __Enumerate((cls).GetEnumerator()) //369:11
                from prop in __Enumerate((__loop28_var1.GetAllProperties()).GetEnumerator()) //369:16
                select new { __loop28_var1 = __loop28_var1, prop = prop}
                ).ToList(); //369:6
            int __loop28_iteration = 0;
            foreach (var __tmp58 in __loop28_results)
            {
                ++__loop28_iteration;
                var __loop28_var1 = __tmp58.__loop28_var1;
                var prop = __tmp58.prop;
                __out.AppendLine(true); //370:1
                string __tmp59Prefix = "    "; //371:1
                StringBuilder __tmp60 = new StringBuilder();
                __tmp60.Append(GenerateBuilderPropertyImpl(model, cls, prop));
                using(StreamReader __tmp60Reader = new StreamReader(this.__ToStream(__tmp60.ToString())))
                {
                    bool __tmp60_first = true;
                    bool __tmp60_last = __tmp60Reader.EndOfStream;
                    while(__tmp60_first || !__tmp60_last)
                    {
                        __tmp60_first = false;
                        string __tmp60Line = __tmp60Reader.ReadLine();
                        __tmp60_last = __tmp60Reader.EndOfStream;
                        __out.Append(__tmp59Prefix);
                        if (__tmp60Line != null) __out.Append(__tmp60Line);
                        if (!__tmp60_last) __out.AppendLine(true);
                        __out.AppendLine(false); //371:52
                    }
                }
            }
            __out.Append("}"); //373:1
            __out.AppendLine(false); //373:2
            __out.AppendLine(true); //374:1
            string __tmp62Line = "public class "; //375:1
            if (__tmp62Line != null) __out.Append(__tmp62Line);
            StringBuilder __tmp63 = new StringBuilder();
            __tmp63.Append(cls.CSharpImplName(ClassKind.ChildBuilder));
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
            string __tmp64Line = " : global::MetaDslx.Core.Immutable.LazyChildBuilderBase, "; //375:58
            if (__tmp64Line != null) __out.Append(__tmp64Line);
            StringBuilder __tmp65 = new StringBuilder();
            __tmp65.Append(cls.CSharpFullName(ClassKind.ChildBuilder));
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
                    __out.AppendLine(false); //375:159
                }
            }
            __out.Append("{"); //376:1
            __out.AppendLine(false); //376:2
            string __tmp67Line = "    internal "; //377:1
            if (__tmp67Line != null) __out.Append(__tmp67Line);
            StringBuilder __tmp68 = new StringBuilder();
            __tmp68.Append(cls.CSharpImplName(ClassKind.ChildBuilder));
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
            string __tmp69Line = "(global::MetaDslx.Core.Immutable.MutableSymbolBase parent, global::MetaDslx.Core.Immutable.ModelProperty property)"; //377:58
            if (__tmp69Line != null) __out.Append(__tmp69Line);
            __out.AppendLine(false); //377:172
            __out.Append("		: base(parent, property)"); //378:1
            __out.AppendLine(false); //378:27
            __out.Append("    {"); //379:1
            __out.AppendLine(false); //379:6
            __out.Append("    }"); //380:1
            __out.AppendLine(false); //380:6
            __out.AppendLine(true); //381:1
            var __loop29_results = 
                (from __loop29_var1 in __Enumerate((cls).GetEnumerator()) //382:11
                from prop in __Enumerate((__loop29_var1.GetAllProperties()).GetEnumerator()) //382:16
                select new { __loop29_var1 = __loop29_var1, prop = prop}
                ).ToList(); //382:6
            int __loop29_iteration = 0;
            foreach (var __tmp70 in __loop29_results)
            {
                ++__loop29_iteration;
                var __loop29_var1 = __tmp70.__loop29_var1;
                var prop = __tmp70.prop;
                string __tmp71Prefix = "    "; //383:1
                StringBuilder __tmp72 = new StringBuilder();
                __tmp72.Append(GenerateChildBuilderPropertyImpl(model, cls, prop));
                using(StreamReader __tmp72Reader = new StreamReader(this.__ToStream(__tmp72.ToString())))
                {
                    bool __tmp72_first = true;
                    bool __tmp72_last = __tmp72Reader.EndOfStream;
                    while(__tmp72_first || !__tmp72_last)
                    {
                        __tmp72_first = false;
                        string __tmp72Line = __tmp72Reader.ReadLine();
                        __tmp72_last = __tmp72Reader.EndOfStream;
                        __out.Append(__tmp71Prefix);
                        if (__tmp72Line != null) __out.Append(__tmp72Line);
                        if (!__tmp72_last) __out.AppendLine(true);
                        __out.AppendLine(false); //383:57
                    }
                }
            }
            __out.Append("}"); //385:1
            __out.AppendLine(false); //385:2
            __out.AppendLine(true); //386:1
            return __out.ToString();
        }

        public string GeneratePropertyDeclaration(MetaModel model, MetaClass cls, MetaProperty prop) //389:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class == cls) //390:2
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
                        __out.AppendLine(false); //391:28
                    }
                }
                if (prop.Kind == MetaPropertyKind.Containment) //392:2
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
                            __out.AppendLine(false); //393:27
                        }
                    }
                }
                if (prop.Kind != MetaPropertyKind.Normal && prop.Kind != MetaPropertyKind.Containment) //395:2
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
                            __out.AppendLine(false); //396:24
                        }
                    }
                }
                var __loop30_results = 
                    (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //398:7
                    select new { p = p}
                    ).ToList(); //398:2
                int __loop30_iteration = 0;
                foreach (var __tmp7 in __loop30_results)
                {
                    ++__loop30_iteration;
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
                            __out.AppendLine(false); //399:111
                        }
                    }
                }
                var __loop31_results = 
                    (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //401:7
                    select new { p = p}
                    ).ToList(); //401:2
                int __loop31_iteration = 0;
                foreach (var __tmp14 in __loop31_results)
                {
                    ++__loop31_iteration;
                    var p = __tmp14.p;
                    if (cls.GetAllSuperClasses(true).Contains(p.Class)) //402:3
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
                                __out.AppendLine(false); //403:110
                            }
                        }
                    }
                    else //404:3
                    {
                        string __tmp22Line = "// ERROR: subsetted property '"; //405:1
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
                        string __tmp24Line = "' must be a property of an ancestor class"; //405:80
                        if (__tmp24Line != null) __out.Append(__tmp24Line);
                        __out.AppendLine(false); //405:121
                    }
                }
                var __loop32_results = 
                    (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //408:7
                    select new { p = p}
                    ).ToList(); //408:2
                int __loop32_iteration = 0;
                foreach (var __tmp25 in __loop32_results)
                {
                    ++__loop32_iteration;
                    var p = __tmp25.p;
                    if (cls.GetAllSuperClasses(true).Contains(p.Class)) //409:3
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
                                __out.AppendLine(false); //410:112
                            }
                        }
                    }
                    else //411:3
                    {
                        string __tmp33Line = "// ERROR: redefined property '"; //412:1
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
                        string __tmp35Line = "' must be a property of an ancestor class"; //412:80
                        if (__tmp35Line != null) __out.Append(__tmp35Line);
                        __out.AppendLine(false); //412:121
                    }
                }
                if (prop.Type is MetaCollectionType) //415:2
                {
                    MetaCollectionType collType = (MetaCollectionType)prop.Type; //416:3
                    string __tmp37Line = "public static readonly global::MetaDslx.Core.Immutable.ModelProperty "; //417:1
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
                    string __tmp39Line = "Property ="; //417:81
                    if (__tmp39Line != null) __out.Append(__tmp39Line);
                    __out.AppendLine(false); //417:91
                    string __tmp41Line = "    global::MetaDslx.Core.Immutable.ModelProperty.Register(\""; //418:1
                    if (__tmp41Line != null) __out.Append(__tmp41Line);
                    StringBuilder __tmp42 = new StringBuilder();
                    __tmp42.Append(prop.Name);
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
                    string __tmp43Line = "\", typeof("; //418:72
                    if (__tmp43Line != null) __out.Append(__tmp43Line);
                    StringBuilder __tmp44 = new StringBuilder();
                    __tmp44.Append(prop.Class.Model.CSharpDescriptorName());
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
                    string __tmp45Line = "."; //418:123
                    if (__tmp45Line != null) __out.Append(__tmp45Line);
                    StringBuilder __tmp46 = new StringBuilder();
                    __tmp46.Append(prop.Class.CSharpName());
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
                    string __tmp47Line = "),"; //418:149
                    if (__tmp47Line != null) __out.Append(__tmp47Line);
                    __out.AppendLine(false); //418:151
                    string __tmp49Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //419:1
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
                    string __tmp51Line = "), typeof("; //419:136
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
                    string __tmp53Line = "), typeof("; //419:199
                    if (__tmp53Line != null) __out.Append(__tmp53Line);
                    StringBuilder __tmp54 = new StringBuilder();
                    __tmp54.Append(prop.Class.CSharpFullName(ClassKind.Immutable));
                    using(StreamReader __tmp54Reader = new StreamReader(this.__ToStream(__tmp54.ToString())))
                    {
                        bool __tmp54_first = true;
                        bool __tmp54_last = __tmp54Reader.EndOfStream;
                        while(__tmp54_first || !__tmp54_last)
                        {
                            __tmp54_first = false;
                            string __tmp54Line = __tmp54Reader.ReadLine();
                            __tmp54_last = __tmp54Reader.EndOfStream;
                            if (__tmp54Line != null) __out.Append(__tmp54Line);
                            if (!__tmp54_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp55Line = ")),"; //419:257
                    if (__tmp55Line != null) __out.Append(__tmp55Line);
                    __out.AppendLine(false); //419:260
                    string __tmp57Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //420:1
                    if (__tmp57Line != null) __out.Append(__tmp57Line);
                    StringBuilder __tmp58 = new StringBuilder();
                    __tmp58.Append(collType.InnerType.CSharpFullPublicName(ClassKind.Builder));
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
                    string __tmp59Line = "), typeof("; //420:134
                    if (__tmp59Line != null) __out.Append(__tmp59Line);
                    StringBuilder __tmp60 = new StringBuilder();
                    __tmp60.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
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
                    string __tmp61Line = "), typeof("; //420:195
                    if (__tmp61Line != null) __out.Append(__tmp61Line);
                    StringBuilder __tmp62 = new StringBuilder();
                    __tmp62.Append(prop.Class.CSharpFullName(ClassKind.Builder));
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
                    string __tmp63Line = ")));"; //420:251
                    if (__tmp63Line != null) __out.Append(__tmp63Line);
                    __out.AppendLine(false); //420:255
                }
                else //421:2
                {
                    string __tmp65Line = "public static readonly global::MetaDslx.Core.Immutable.ModelProperty "; //422:1
                    if (__tmp65Line != null) __out.Append(__tmp65Line);
                    StringBuilder __tmp66 = new StringBuilder();
                    __tmp66.Append(prop.Name);
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
                    string __tmp67Line = "Property ="; //422:81
                    if (__tmp67Line != null) __out.Append(__tmp67Line);
                    __out.AppendLine(false); //422:91
                    string __tmp69Line = "    global::MetaDslx.Core.Immutable.ModelProperty.Register(\""; //423:1
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
                    string __tmp71Line = "\", typeof("; //423:72
                    if (__tmp71Line != null) __out.Append(__tmp71Line);
                    StringBuilder __tmp72 = new StringBuilder();
                    __tmp72.Append(prop.Class.Model.CSharpDescriptorName());
                    using(StreamReader __tmp72Reader = new StreamReader(this.__ToStream(__tmp72.ToString())))
                    {
                        bool __tmp72_first = true;
                        bool __tmp72_last = __tmp72Reader.EndOfStream;
                        while(__tmp72_first || !__tmp72_last)
                        {
                            __tmp72_first = false;
                            string __tmp72Line = __tmp72Reader.ReadLine();
                            __tmp72_last = __tmp72Reader.EndOfStream;
                            if (__tmp72Line != null) __out.Append(__tmp72Line);
                            if (!__tmp72_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp73Line = "."; //423:123
                    if (__tmp73Line != null) __out.Append(__tmp73Line);
                    StringBuilder __tmp74 = new StringBuilder();
                    __tmp74.Append(prop.Class.CSharpName());
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
                    string __tmp75Line = "),"; //423:149
                    if (__tmp75Line != null) __out.Append(__tmp75Line);
                    __out.AppendLine(false); //423:151
                    string __tmp77Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //424:1
                    if (__tmp77Line != null) __out.Append(__tmp77Line);
                    StringBuilder __tmp78 = new StringBuilder();
                    __tmp78.Append(prop.Type.CSharpFullPublicName(ClassKind.Immutable));
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
                    string __tmp79Line = "), null, typeof("; //424:127
                    if (__tmp79Line != null) __out.Append(__tmp79Line);
                    StringBuilder __tmp80 = new StringBuilder();
                    __tmp80.Append(prop.Class.CSharpFullName(ClassKind.Immutable));
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
                    string __tmp81Line = ")),"; //424:191
                    if (__tmp81Line != null) __out.Append(__tmp81Line);
                    __out.AppendLine(false); //424:194
                    string __tmp83Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //425:1
                    if (__tmp83Line != null) __out.Append(__tmp83Line);
                    StringBuilder __tmp84 = new StringBuilder();
                    __tmp84.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
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
                    string __tmp85Line = "), null, typeof("; //425:125
                    if (__tmp85Line != null) __out.Append(__tmp85Line);
                    StringBuilder __tmp86 = new StringBuilder();
                    __tmp86.Append(prop.Class.CSharpFullName(ClassKind.Builder));
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
                    string __tmp87Line = ")));"; //425:187
                    if (__tmp87Line != null) __out.Append(__tmp87Line);
                    __out.AppendLine(false); //425:191
                }
            }
            __out.AppendLine(true); //428:1
            return __out.ToString();
        }

        public string GenerateImmutablePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //431:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //432:1
            if (cls.GetAllFinalProperties().Contains(prop)) //433:2
            {
                string __tmp2Line = "public "; //434:1
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
                string __tmp4Line = " "; //434:61
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
                        __out.AppendLine(false); //434:73
                    }
                }
            }
            else //435:2
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
                        __out.AppendLine(false); //436:54
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
                string __tmp10Line = " "; //437:54
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
                string __tmp12Line = "."; //437:103
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
                        __out.AppendLine(false); //437:115
                    }
                }
            }
            __out.Append("{"); //439:1
            __out.AppendLine(false); //439:2
            if (prop.Type is MetaCollectionType) //440:6
            {
                string __tmp15Line = "    get { return this.GetList<"; //441:1
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
                string __tmp17Line = ">("; //441:116
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
                string __tmp19Line = ", ref "; //441:170
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
                string __tmp21Line = "); }"; //441:200
                if (__tmp21Line != null) __out.Append(__tmp21Line);
                __out.AppendLine(false); //441:204
            }
            else if (prop.Type.IsReferenceType()) //442:3
            {
                string __tmp23Line = "    get { return this.GetReference<"; //443:1
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
                string __tmp25Line = ">("; //443:89
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
                string __tmp27Line = ", ref "; //443:143
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
                string __tmp29Line = "); }"; //443:173
                if (__tmp29Line != null) __out.Append(__tmp29Line);
                __out.AppendLine(false); //443:177
            }
            else //444:3
            {
                string __tmp31Line = "    get { return this.GetValue<"; //445:1
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
                string __tmp33Line = ">("; //445:85
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
                string __tmp35Line = ", ref "; //445:139
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
                string __tmp37Line = "); }"; //445:169
                if (__tmp37Line != null) __out.Append(__tmp37Line);
                __out.AppendLine(false); //445:173
            }
            __out.Append("}"); //447:1
            __out.AppendLine(false); //447:2
            return __out.ToString();
        }

        public string GenerateBuilderPropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //450:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //451:1
            if (cls.GetAllFinalProperties().Contains(prop)) //452:2
            {
                string __tmp2Line = "public "; //453:1
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
                string __tmp4Line = " "; //453:59
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
                        __out.AppendLine(false); //453:71
                    }
                }
            }
            else //454:2
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
                        __out.AppendLine(false); //455:54
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
                string __tmp10Line = " "; //456:52
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
                string __tmp12Line = "."; //456:99
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
                        __out.AppendLine(false); //456:111
                    }
                }
            }
            __out.Append("{"); //458:1
            __out.AppendLine(false); //458:2
            if (prop.Type is MetaCollectionType) //459:6
            {
                string __tmp15Line = "    get { return this.GetList<"; //460:1
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
                string __tmp17Line = ">("; //460:114
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
                string __tmp19Line = ", ref "; //460:168
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
                string __tmp21Line = "); }"; //460:198
                if (__tmp21Line != null) __out.Append(__tmp21Line);
                __out.AppendLine(false); //460:202
            }
            else if (prop.Type.IsReferenceType()) //461:3
            {
                string __tmp23Line = "    get { return this.GetReference<"; //462:1
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
                string __tmp25Line = ">("; //462:87
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
                string __tmp27Line = "); }"; //462:141
                if (__tmp27Line != null) __out.Append(__tmp27Line);
                __out.AppendLine(false); //462:145
            }
            else //463:3
            {
                string __tmp29Line = "    get { return this.GetValue<"; //464:1
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
                string __tmp31Line = ">("; //464:83
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
                string __tmp33Line = "); }"; //464:137
                if (__tmp33Line != null) __out.Append(__tmp33Line);
                __out.AppendLine(false); //464:141
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //466:3
            {
                if (prop.Type.IsReferenceType()) //467:4
                {
                    string __tmp35Line = "    set { this.SetReference<"; //468:1
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
                    string __tmp37Line = ">("; //468:80
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
                    string __tmp39Line = ", value); }"; //468:134
                    if (__tmp39Line != null) __out.Append(__tmp39Line);
                    __out.AppendLine(false); //468:145
                }
                else //469:4
                {
                    string __tmp41Line = "    set { this.SetValue<"; //470:1
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
                    string __tmp43Line = ">("; //470:76
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
                    string __tmp45Line = ", value); }"; //470:130
                    if (__tmp45Line != null) __out.Append(__tmp45Line);
                    __out.AppendLine(false); //470:141
                }
            }
            __out.Append("}"); //473:1
            __out.AppendLine(false); //473:2
            if (!(prop.Type is MetaCollectionType)) //474:2
            {
                __out.AppendLine(true); //475:1
                if (cls.GetAllFinalProperties().Contains(prop)) //476:3
                {
                    string __tmp47Line = "public Func<"; //477:1
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
                    string __tmp49Line = "> "; //477:64
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
                    string __tmp51Line = "Lazy"; //477:77
                    if (__tmp51Line != null) __out.Append(__tmp51Line);
                    __out.AppendLine(false); //477:81
                }
                else //478:3
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
                            __out.AppendLine(false); //479:54
                        }
                    }
                    string __tmp55Line = "Func<"; //480:1
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
                    string __tmp57Line = "> "; //480:57
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
                    string __tmp59Line = "."; //480:105
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
                    string __tmp61Line = "Lazy"; //480:117
                    if (__tmp61Line != null) __out.Append(__tmp61Line);
                    __out.AppendLine(false); //480:121
                }
                __out.Append("{"); //482:1
                __out.AppendLine(false); //482:2
                if (prop.Type.IsReferenceType()) //483:4
                {
                    string __tmp63Line = "    get { return this.GetLazyReference<"; //484:1
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
                    string __tmp65Line = ">("; //484:91
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
                    string __tmp67Line = "); }"; //484:145
                    if (__tmp67Line != null) __out.Append(__tmp67Line);
                    __out.AppendLine(false); //484:149
                    string __tmp69Line = "    set { this.SetLazyReference("; //485:1
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
                    string __tmp71Line = ", value); }"; //485:85
                    if (__tmp71Line != null) __out.Append(__tmp71Line);
                    __out.AppendLine(false); //485:96
                }
                else //486:4
                {
                    string __tmp73Line = "    get { return this.GetLazyValue<"; //487:1
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
                    string __tmp75Line = ">("; //487:87
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
                    string __tmp77Line = "); }"; //487:141
                    if (__tmp77Line != null) __out.Append(__tmp77Line);
                    __out.AppendLine(false); //487:145
                    string __tmp79Line = "    set { this.SetLazyValue("; //488:1
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
                    string __tmp81Line = ", value); }"; //488:81
                    if (__tmp81Line != null) __out.Append(__tmp81Line);
                    __out.AppendLine(false); //488:92
                }
                __out.Append("}"); //490:1
                __out.AppendLine(false); //490:2
            }
            if (prop.Kind == MetaPropertyKind.Containment && (((prop.Type is MetaCollectionType) && (((MetaCollectionType)prop.Type).InnerType is MetaClass)) || (!(prop.Type is MetaCollectionType) && prop.Type is MetaClass))) //492:2
            {
                __out.AppendLine(true); //493:1
                StringBuilder __tmp83 = new StringBuilder();
                __tmp83.Append("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
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
                        __out.AppendLine(false); //494:54
                    }
                }
                if (cls.GetAllFinalProperties().Contains(prop)) //495:3
                {
                    if (prop.Type is MetaCollectionType) //496:4
                    {
                        string __tmp85Line = "public "; //497:1
                        if (__tmp85Line != null) __out.Append(__tmp85Line);
                        StringBuilder __tmp86 = new StringBuilder();
                        __tmp86.Append(((MetaCollectionType)prop.Type).InnerType.CSharpFullPublicName(ClassKind.ChildBuilder));
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
                        string __tmp87Line = " "; //497:96
                        if (__tmp87Line != null) __out.Append(__tmp87Line);
                        StringBuilder __tmp88 = new StringBuilder();
                        __tmp88.Append(prop.Name);
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
                            }
                        }
                        string __tmp89Line = "LazyChild"; //497:108
                        if (__tmp89Line != null) __out.Append(__tmp89Line);
                        __out.AppendLine(false); //497:117
                    }
                    else //498:4
                    {
                        string __tmp91Line = "public "; //499:1
                        if (__tmp91Line != null) __out.Append(__tmp91Line);
                        StringBuilder __tmp92 = new StringBuilder();
                        __tmp92.Append(prop.Type.CSharpFullPublicName(ClassKind.ChildBuilder));
                        using(StreamReader __tmp92Reader = new StreamReader(this.__ToStream(__tmp92.ToString())))
                        {
                            bool __tmp92_first = true;
                            bool __tmp92_last = __tmp92Reader.EndOfStream;
                            while(__tmp92_first || !__tmp92_last)
                            {
                                __tmp92_first = false;
                                string __tmp92Line = __tmp92Reader.ReadLine();
                                __tmp92_last = __tmp92Reader.EndOfStream;
                                if (__tmp92Line != null) __out.Append(__tmp92Line);
                                if (!__tmp92_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp93Line = " "; //499:64
                        if (__tmp93Line != null) __out.Append(__tmp93Line);
                        StringBuilder __tmp94 = new StringBuilder();
                        __tmp94.Append(prop.Name);
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
                        string __tmp95Line = "LazyChild"; //499:76
                        if (__tmp95Line != null) __out.Append(__tmp95Line);
                        __out.AppendLine(false); //499:85
                    }
                }
                else //501:3
                {
                    if (prop.Type is MetaCollectionType) //502:4
                    {
                        StringBuilder __tmp97 = new StringBuilder();
                        __tmp97.Append(((MetaCollectionType)prop.Type).InnerType.CSharpFullPublicName(ClassKind.ChildBuilder));
                        using(StreamReader __tmp97Reader = new StreamReader(this.__ToStream(__tmp97.ToString())))
                        {
                            bool __tmp97_first = true;
                            bool __tmp97_last = __tmp97Reader.EndOfStream;
                            while(__tmp97_first || !__tmp97_last)
                            {
                                __tmp97_first = false;
                                string __tmp97Line = __tmp97Reader.ReadLine();
                                __tmp97_last = __tmp97Reader.EndOfStream;
                                if (__tmp97Line != null) __out.Append(__tmp97Line);
                                if (!__tmp97_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp98Line = " "; //503:89
                        if (__tmp98Line != null) __out.Append(__tmp98Line);
                        StringBuilder __tmp99 = new StringBuilder();
                        __tmp99.Append(prop.Class.CSharpFullName(ClassKind.Builder));
                        using(StreamReader __tmp99Reader = new StreamReader(this.__ToStream(__tmp99.ToString())))
                        {
                            bool __tmp99_first = true;
                            bool __tmp99_last = __tmp99Reader.EndOfStream;
                            while(__tmp99_first || !__tmp99_last)
                            {
                                __tmp99_first = false;
                                string __tmp99Line = __tmp99Reader.ReadLine();
                                __tmp99_last = __tmp99Reader.EndOfStream;
                                if (__tmp99Line != null) __out.Append(__tmp99Line);
                                if (!__tmp99_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp100Line = "."; //503:136
                        if (__tmp100Line != null) __out.Append(__tmp100Line);
                        StringBuilder __tmp101 = new StringBuilder();
                        __tmp101.Append(prop.Name);
                        using(StreamReader __tmp101Reader = new StreamReader(this.__ToStream(__tmp101.ToString())))
                        {
                            bool __tmp101_first = true;
                            bool __tmp101_last = __tmp101Reader.EndOfStream;
                            while(__tmp101_first || !__tmp101_last)
                            {
                                __tmp101_first = false;
                                string __tmp101Line = __tmp101Reader.ReadLine();
                                __tmp101_last = __tmp101Reader.EndOfStream;
                                if (__tmp101Line != null) __out.Append(__tmp101Line);
                                if (!__tmp101_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp102Line = "LazyChild"; //503:148
                        if (__tmp102Line != null) __out.Append(__tmp102Line);
                        __out.AppendLine(false); //503:157
                    }
                    else //504:4
                    {
                        StringBuilder __tmp104 = new StringBuilder();
                        __tmp104.Append(prop.Type.CSharpFullPublicName(ClassKind.ChildBuilder));
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
                        string __tmp105Line = " "; //505:57
                        if (__tmp105Line != null) __out.Append(__tmp105Line);
                        StringBuilder __tmp106 = new StringBuilder();
                        __tmp106.Append(prop.Class.CSharpFullName(ClassKind.Builder));
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
                        string __tmp107Line = "."; //505:104
                        if (__tmp107Line != null) __out.Append(__tmp107Line);
                        StringBuilder __tmp108 = new StringBuilder();
                        __tmp108.Append(prop.Name);
                        using(StreamReader __tmp108Reader = new StreamReader(this.__ToStream(__tmp108.ToString())))
                        {
                            bool __tmp108_first = true;
                            bool __tmp108_last = __tmp108Reader.EndOfStream;
                            while(__tmp108_first || !__tmp108_last)
                            {
                                __tmp108_first = false;
                                string __tmp108Line = __tmp108Reader.ReadLine();
                                __tmp108_last = __tmp108Reader.EndOfStream;
                                if (__tmp108Line != null) __out.Append(__tmp108Line);
                                if (!__tmp108_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp109Line = "LazyChild"; //505:116
                        if (__tmp109Line != null) __out.Append(__tmp109Line);
                        __out.AppendLine(false); //505:125
                    }
                }
                if (prop.Type is MetaCollectionType) //508:4
                {
                    __out.Append("{"); //509:1
                    __out.AppendLine(false); //509:2
                    string __tmp111Line = "    get { return new "; //510:1
                    if (__tmp111Line != null) __out.Append(__tmp111Line);
                    StringBuilder __tmp112 = new StringBuilder();
                    __tmp112.Append(((MetaClass)((MetaCollectionType)prop.Type).InnerType).CSharpFullName(ClassKind.ChildBuilder));
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
                    string __tmp113Line = "Impl(this, "; //510:117
                    if (__tmp113Line != null) __out.Append(__tmp113Line);
                    StringBuilder __tmp114 = new StringBuilder();
                    __tmp114.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
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
                        }
                    }
                    string __tmp115Line = "); }"; //510:180
                    if (__tmp115Line != null) __out.Append(__tmp115Line);
                    __out.AppendLine(false); //510:184
                    __out.Append("}"); //511:1
                    __out.AppendLine(false); //511:2
                }
                else //512:4
                {
                    __out.Append("{"); //513:1
                    __out.AppendLine(false); //513:2
                    string __tmp117Line = "    get { return new "; //514:1
                    if (__tmp117Line != null) __out.Append(__tmp117Line);
                    StringBuilder __tmp118 = new StringBuilder();
                    __tmp118.Append(((MetaClass)prop.Type).CSharpFullName(ClassKind.ChildBuilder));
                    using(StreamReader __tmp118Reader = new StreamReader(this.__ToStream(__tmp118.ToString())))
                    {
                        bool __tmp118_first = true;
                        bool __tmp118_last = __tmp118Reader.EndOfStream;
                        while(__tmp118_first || !__tmp118_last)
                        {
                            __tmp118_first = false;
                            string __tmp118Line = __tmp118Reader.ReadLine();
                            __tmp118_last = __tmp118Reader.EndOfStream;
                            if (__tmp118Line != null) __out.Append(__tmp118Line);
                            if (!__tmp118_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp119Line = "Impl(this, "; //514:85
                    if (__tmp119Line != null) __out.Append(__tmp119Line);
                    StringBuilder __tmp120 = new StringBuilder();
                    __tmp120.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                    using(StreamReader __tmp120Reader = new StreamReader(this.__ToStream(__tmp120.ToString())))
                    {
                        bool __tmp120_first = true;
                        bool __tmp120_last = __tmp120Reader.EndOfStream;
                        while(__tmp120_first || !__tmp120_last)
                        {
                            __tmp120_first = false;
                            string __tmp120Line = __tmp120Reader.ReadLine();
                            __tmp120_last = __tmp120Reader.EndOfStream;
                            if (__tmp120Line != null) __out.Append(__tmp120Line);
                            if (!__tmp120_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp121Line = "); }"; //514:148
                    if (__tmp121Line != null) __out.Append(__tmp121Line);
                    __out.AppendLine(false); //514:152
                    __out.Append("}"); //515:1
                    __out.AppendLine(false); //515:2
                }
            }
            return __out.ToString();
        }

        public string GenerateChildBuilderPropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //520:1
        {
            StringBuilder __out = new StringBuilder();
            if (!(prop.Type is MetaCollectionType)) //521:2
            {
                __out.AppendLine(true); //522:1
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
                        __out.AppendLine(false); //523:54
                    }
                }
                if (cls.GetAllFinalProperties().Contains(prop)) //524:3
                {
                    string __tmp4Line = "public Func<"; //525:1
                    if (__tmp4Line != null) __out.Append(__tmp4Line);
                    StringBuilder __tmp5 = new StringBuilder();
                    __tmp5.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
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
                    string __tmp6Line = "> "; //525:64
                    if (__tmp6Line != null) __out.Append(__tmp6Line);
                    StringBuilder __tmp7 = new StringBuilder();
                    __tmp7.Append(prop.Name);
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
                            __out.AppendLine(false); //525:77
                        }
                    }
                }
                else //526:3
                {
                    string __tmp9Line = "Func<"; //527:1
                    if (__tmp9Line != null) __out.Append(__tmp9Line);
                    StringBuilder __tmp10 = new StringBuilder();
                    __tmp10.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
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
                    string __tmp11Line = "> "; //527:57
                    if (__tmp11Line != null) __out.Append(__tmp11Line);
                    StringBuilder __tmp12 = new StringBuilder();
                    __tmp12.Append(prop.Class.CSharpFullName(ClassKind.ChildBuilder));
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
                    string __tmp13Line = "."; //527:110
                    if (__tmp13Line != null) __out.Append(__tmp13Line);
                    StringBuilder __tmp14 = new StringBuilder();
                    __tmp14.Append(prop.Name);
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
                            __out.AppendLine(false); //527:122
                        }
                    }
                }
                __out.Append("{"); //529:1
                __out.AppendLine(false); //529:2
                if (prop.Type.IsReferenceType()) //530:4
                {
                    string __tmp16Line = "    set { this.MParent.MChildAddLazy(this.MProperty, "; //531:1
                    if (__tmp16Line != null) __out.Append(__tmp16Line);
                    StringBuilder __tmp17 = new StringBuilder();
                    __tmp17.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
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
                    string __tmp18Line = ", value); }"; //531:106
                    if (__tmp18Line != null) __out.Append(__tmp18Line);
                    __out.AppendLine(false); //531:117
                }
                else //532:4
                {
                    string __tmp20Line = "    set { this.MParent.MChildAddLazy(this.MProperty, "; //533:1
                    if (__tmp20Line != null) __out.Append(__tmp20Line);
                    StringBuilder __tmp21 = new StringBuilder();
                    __tmp21.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
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
                    string __tmp22Line = ", () => value); }"; //533:106
                    if (__tmp22Line != null) __out.Append(__tmp22Line);
                    __out.AppendLine(false); //533:123
                }
                __out.Append("}"); //535:1
                __out.AppendLine(false); //535:2
            }
            return __out.ToString();
        }

        public string GetReturn(MetaOperation op) //539:1
        {
            if (op.ReturnType.CSharpName() == "void") //540:5
            {
                return ""; //541:3
            }
            else //542:2
            {
                return "return "; //543:3
            }
        }

        public string GenerateOperationImpl(MetaModel model, MetaOperation op) //547:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //548:1
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
            string __tmp3Line = " "; //549:58
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
            string __tmp5Line = "."; //549:106
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
            string __tmp7Line = "("; //549:116
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
            string __tmp9Line = ")"; //549:157
            if (__tmp9Line != null) __out.Append(__tmp9Line);
            __out.AppendLine(false); //549:158
            __out.Append("{"); //550:1
            __out.AppendLine(false); //550:2
            string __tmp10Prefix = "    "; //551:1
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
            string __tmp13Line = "."; //551:77
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
            string __tmp15Line = "_"; //551:102
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
            string __tmp17Line = "("; //551:112
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
            string __tmp19Line = ");"; //551:144
            if (__tmp19Line != null) __out.Append(__tmp19Line);
            __out.AppendLine(false); //551:146
            __out.Append("}"); //552:1
            __out.AppendLine(false); //552:2
            return __out.ToString();
        }

        public string GetSuperClasses(MetaClass cls) //555:1
        {
            string result = ""; //556:2
            var __loop33_results = 
                (from __loop33_var1 in __Enumerate((cls).GetEnumerator()) //557:10
                from sup in __Enumerate((__loop33_var1.SuperClasses).GetEnumerator()) //557:15
                select new { __loop33_var1 = __loop33_var1, sup = sup}
                ).ToList(); //557:5
            int __loop33_iteration = 0;
            string delim = ""; //557:33
            foreach (var __tmp1 in __loop33_results)
            {
                ++__loop33_iteration;
                if (__loop33_iteration >= 2) //557:52
                {
                    delim = ", "; //557:52
                }
                var __loop33_var1 = __tmp1.__loop33_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpFullName(); //558:3
            }
            return result; //560:2
        }

        public string GetAllSuperClasses(MetaClass cls) //563:1
        {
            string result = ""; //564:2
            var __loop34_results = 
                (from __loop34_var1 in __Enumerate((cls).GetEnumerator()) //565:10
                from sup in __Enumerate((__loop34_var1.GetAllSuperClasses(false)).GetEnumerator()) //565:15
                select new { __loop34_var1 = __loop34_var1, sup = sup}
                ).ToList(); //565:5
            int __loop34_iteration = 0;
            string delim = ""; //565:46
            foreach (var __tmp1 in __loop34_results)
            {
                ++__loop34_iteration;
                if (__loop34_iteration >= 2) //565:65
                {
                    delim = ", "; //565:65
                }
                var __loop34_var1 = __tmp1.__loop34_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpFullName(); //566:3
            }
            return result; //568:2
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //571:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "public static class "; //572:1
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
                    __out.AppendLine(false); //572:51
                }
            }
            __out.Append("{"); //573:1
            __out.AppendLine(false); //573:2
            __out.Append("	private static global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty> properties = new global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty>();"); //574:1
            __out.AppendLine(false); //574:210
            __out.AppendLine(true); //575:1
            string __tmp5Line = "    static "; //576:1
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
            string __tmp7Line = "()"; //576:42
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //576:44
            __out.Append("    {"); //577:1
            __out.AppendLine(false); //577:6
            var __loop35_results = 
                (from __loop35_var1 in __Enumerate((model).GetEnumerator()) //578:11
                from Namespace in __Enumerate((__loop35_var1.Namespace).GetEnumerator()) //578:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //578:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //578:43
                from prop in __Enumerate((cls.Properties).GetEnumerator()) //578:66
                select new { __loop35_var1 = __loop35_var1, Namespace = Namespace, Declarations = Declarations, cls = cls, prop = prop}
                ).ToList(); //578:6
            int __loop35_iteration = 0;
            foreach (var __tmp8 in __loop35_results)
            {
                ++__loop35_iteration;
                var __loop35_var1 = __tmp8.__loop35_var1;
                var Namespace = __tmp8.Namespace;
                var Declarations = __tmp8.Declarations;
                var cls = __tmp8.cls;
                var prop = __tmp8.prop;
                string __tmp10Line = "        properties.Add("; //579:1
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
                string __tmp12Line = "."; //579:42
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
                string __tmp14Line = "Property);"; //579:54
                if (__tmp14Line != null) __out.Append(__tmp14Line);
                __out.AppendLine(false); //579:64
            }
            __out.AppendLine(true); //581:1
            __out.Append("        foreach (var property in properties)"); //582:1
            __out.AppendLine(false); //582:45
            __out.Append("        {"); //583:1
            __out.AppendLine(false); //583:10
            __out.Append("            property.Init();"); //584:1
            __out.AppendLine(false); //584:29
            __out.Append("        }"); //585:1
            __out.AppendLine(false); //585:10
            __out.Append("    }"); //586:1
            __out.AppendLine(false); //586:6
            __out.AppendLine(true); //587:1
            __out.Append("    public static void Init()"); //588:1
            __out.AppendLine(false); //588:30
            __out.Append("    {"); //589:1
            __out.AppendLine(false); //589:6
            __out.Append("    }"); //591:1
            __out.AppendLine(false); //591:6
            __out.AppendLine(true); //592:1
            string __tmp16Line = "	public const string Uri = \""; //593:1
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
            string __tmp18Line = "\";"; //593:40
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //593:42
            __out.AppendLine(true); //594:1
            var __loop36_results = 
                (from __loop36_var1 in __Enumerate((model).GetEnumerator()) //595:11
                from Namespace in __Enumerate((__loop36_var1.Namespace).GetEnumerator()) //595:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //595:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //595:43
                select new { __loop36_var1 = __loop36_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //595:6
            int __loop36_iteration = 0;
            foreach (var __tmp19 in __loop36_results)
            {
                ++__loop36_iteration;
                var __loop36_var1 = __tmp19.__loop36_var1;
                var Namespace = __tmp19.Namespace;
                var Declarations = __tmp19.Declarations;
                var cls = __tmp19.cls;
                string __tmp20Prefix = "    "; //596:1
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
                        __out.AppendLine(false); //596:34
                    }
                }
            }
            __out.Append("}"); //598:1
            __out.AppendLine(false); //598:2
            __out.AppendLine(true); //599:1
            return __out.ToString();
        }

        public string GenerateMetaModelClass(MetaClass cls) //603:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //604:1
            string __tmp2Line = "public static class "; //605:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.CSharpName());
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
                    __out.AppendLine(false); //605:39
                }
            }
            __out.Append("{"); //606:1
            __out.AppendLine(false); //606:2
            __out.AppendLine(true); //607:1
            if (cls.CSharpName() == "MetaClass") //608:2
            {
                __out.Append("    public static global::MetaDslx.Core.Immutable.MetaClass _MetaClass"); //609:1
                __out.AppendLine(false); //609:71
            }
            else //610:2
            {
                __out.Append("    public static global::MetaDslx.Core.Immutable.MetaClass MetaClass"); //611:1
                __out.AppendLine(false); //611:70
            }
            __out.Append("    {"); //613:1
            __out.AppendLine(false); //613:6
            string __tmp5Line = "        get { return null;/*"; //614:1
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(cls.CSharpFullInstanceName());
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
            string __tmp7Line = ";*/ }"; //614:59
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //614:64
            __out.Append("    }"); //615:1
            __out.AppendLine(false); //615:6
            __out.AppendLine(true); //616:1
            var __loop37_results = 
                (from __loop37_var1 in __Enumerate((cls).GetEnumerator()) //617:11
                from prop in __Enumerate((__loop37_var1.Properties).GetEnumerator()) //617:16
                select new { __loop37_var1 = __loop37_var1, prop = prop}
                ).ToList(); //617:6
            int __loop37_iteration = 0;
            foreach (var __tmp8 in __loop37_results)
            {
                ++__loop37_iteration;
                var __loop37_var1 = __tmp8.__loop37_var1;
                var prop = __tmp8.prop;
                string __tmp9Prefix = "    "; //618:1
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(GeneratePropertyDeclaration(cls.Model, cls, prop));
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
                        __out.AppendLine(false); //618:56
                    }
                }
            }
            __out.Append("}"); //620:1
            __out.AppendLine(false); //620:2
            return __out.ToString();
        }

        public MetaSynthetizedPropertyInitializer GetSynthetizedInitializerFor(MetaClass cls, MetaProperty prop) //624:1
        {
            MetaSynthetizedPropertyInitializer lastInit = null; //625:2
            var __loop38_results = 
                (from __loop38_var1 in __Enumerate((cls).GetEnumerator()) //626:7
                from sup in __Enumerate((__loop38_var1.GetAllSuperClasses(true)).GetEnumerator()) //626:12
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //626:42
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //626:55
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaSynthetizedPropertyInitializer>() //626:69
                select new { __loop38_var1 = __loop38_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //626:2
            int __loop38_iteration = 0;
            foreach (var __tmp1 in __loop38_results)
            {
                ++__loop38_iteration;
                var __loop38_var1 = __tmp1.__loop38_var1;
                var sup = __tmp1.sup;
                var Constructor = __tmp1.Constructor;
                var Initializers = __tmp1.Initializers;
                var init = __tmp1.init;
                if (init.Property == prop) //627:3
                {
                    lastInit = init; //628:4
                }
            }
            return lastInit; //631:2
        }

        public string GenerateImplementationProvider(MetaModel model) //635:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal static class "; //636:1
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
            string __tmp4Line = "ImplementationProvider"; //636:35
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //636:57
            __out.Append("{"); //637:1
            __out.AppendLine(false); //637:2
            string __tmp6Line = "    // If there is a compile error at this line, create a new class called "; //638:1
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
            string __tmp8Line = "Implementation"; //638:88
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //638:102
            string __tmp10Line = "	// which is a subclass of "; //639:1
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
            string __tmp12Line = "ImplementationBase:"; //639:40
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //639:59
            string __tmp14Line = "    private static "; //640:1
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
            string __tmp16Line = "Implementation implementation = new "; //640:32
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
            string __tmp18Line = "Implementation();"; //640:80
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //640:97
            __out.AppendLine(true); //641:1
            string __tmp20Line = "    public static "; //642:1
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
            string __tmp22Line = "Implementation Implementation"; //642:31
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            __out.AppendLine(false); //642:60
            __out.Append("    {"); //643:1
            __out.AppendLine(false); //643:6
            string __tmp24Line = "        get { return "; //644:1
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
            string __tmp26Line = "ImplementationProvider.implementation; }"; //644:34
            if (__tmp26Line != null) __out.Append(__tmp26Line);
            __out.AppendLine(false); //644:74
            __out.Append("    }"); //645:1
            __out.AppendLine(false); //645:6
            __out.Append("}"); //646:1
            __out.AppendLine(false); //646:2
            var __loop39_results = 
                (from __loop39_var1 in __Enumerate((model).GetEnumerator()) //647:8
                from Namespace in __Enumerate((__loop39_var1.Namespace).GetEnumerator()) //647:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //647:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //647:40
                select new { __loop39_var1 = __loop39_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //647:3
            int __loop39_iteration = 0;
            foreach (var __tmp27 in __loop39_results)
            {
                ++__loop39_iteration;
                var __loop39_var1 = __tmp27.__loop39_var1;
                var Namespace = __tmp27.Namespace;
                var Declarations = __tmp27.Declarations;
                var enm = __tmp27.enm;
                __out.AppendLine(true); //648:1
                string __tmp29Line = "public static class "; //649:1
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
                string __tmp31Line = "Extensions"; //649:31
                if (__tmp31Line != null) __out.Append(__tmp31Line);
                __out.AppendLine(false); //649:41
                __out.Append("{"); //650:1
                __out.AppendLine(false); //650:2
                var __loop40_results = 
                    (from __loop40_var1 in __Enumerate((enm).GetEnumerator()) //651:11
                    from op in __Enumerate((__loop40_var1.Operations).GetEnumerator()) //651:16
                    select new { __loop40_var1 = __loop40_var1, op = op}
                    ).ToList(); //651:6
                int __loop40_iteration = 0;
                foreach (var __tmp32 in __loop40_results)
                {
                    ++__loop40_iteration;
                    var __loop40_var1 = __tmp32.__loop40_var1;
                    var op = __tmp32.op;
                    string __tmp34Line = "    public static "; //652:1
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
                    string __tmp36Line = " "; //652:76
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
                    string __tmp38Line = "("; //652:86
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
                    string __tmp40Line = ")"; //652:119
                    if (__tmp40Line != null) __out.Append(__tmp40Line);
                    __out.AppendLine(false); //652:120
                    __out.Append("    {"); //653:1
                    __out.AppendLine(false); //653:6
                    string __tmp41Prefix = "        "; //654:1
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
                    string __tmp44Line = "ImplementationProvider.Implementation."; //654:36
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
                    string __tmp46Line = "_"; //654:98
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
                    string __tmp48Line = "("; //654:108
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
                    string __tmp50Line = ");"; //654:144
                    if (__tmp50Line != null) __out.Append(__tmp50Line);
                    __out.AppendLine(false); //654:146
                    __out.Append("    }"); //655:1
                    __out.AppendLine(false); //655:6
                }
                __out.Append("}"); //657:1
                __out.AppendLine(false); //657:2
            }
            __out.AppendLine(true); //659:1
            __out.Append("/// <summary>"); //660:1
            __out.AppendLine(false); //660:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //661:1
            __out.AppendLine(false); //661:68
            string __tmp52Line = "/// This class has to be be overriden in "; //662:1
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
            string __tmp54Line = "Implementation to provide custom"; //662:54
            if (__tmp54Line != null) __out.Append(__tmp54Line);
            __out.AppendLine(false); //662:86
            __out.Append("/// implementation for the constructors, operations and property values."); //663:1
            __out.AppendLine(false); //663:73
            __out.Append("/// </summary>"); //664:1
            __out.AppendLine(false); //664:15
            string __tmp56Line = "internal abstract class "; //665:1
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
            string __tmp58Line = "ImplementationBase"; //665:37
            if (__tmp58Line != null) __out.Append(__tmp58Line);
            __out.AppendLine(false); //665:55
            __out.Append("{"); //666:1
            __out.AppendLine(false); //666:2
            var __loop41_results = 
                (from __loop41_var1 in __Enumerate((model).GetEnumerator()) //667:8
                from Namespace in __Enumerate((__loop41_var1.Namespace).GetEnumerator()) //667:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //667:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //667:40
                select new { __loop41_var1 = __loop41_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //667:3
            int __loop41_iteration = 0;
            foreach (var __tmp59 in __loop41_results)
            {
                ++__loop41_iteration;
                var __loop41_var1 = __tmp59.__loop41_var1;
                var Namespace = __tmp59.Namespace;
                var Declarations = __tmp59.Declarations;
                var cls = __tmp59.cls;
                __out.Append("    /// <summary>"); //668:1
                __out.AppendLine(false); //668:18
                string __tmp61Line = "	/// Implements the constructor: "; //669:1
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
                string __tmp63Line = "()"; //669:52
                if (__tmp63Line != null) __out.Append(__tmp63Line);
                __out.AppendLine(false); //669:54
                __out.Append("    /// </summary>"); //670:1
                __out.AppendLine(false); //670:19
                if ((from __loop42_var1 in __Enumerate((cls).GetEnumerator()) //671:15
                from sup in __Enumerate((__loop42_var1.SuperClasses).GetEnumerator()) //671:20
                select new { __loop42_var1 = __loop42_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //671:3
                {
                    string __tmp65Line = "	/// Direct superclasses: "; //672:1
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
                            __out.AppendLine(false); //672:49
                        }
                    }
                    string __tmp68Line = "	/// All superclasses: "; //673:1
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
                            __out.AppendLine(false); //673:49
                        }
                    }
                }
                if ((from __loop43_var1 in __Enumerate((cls).GetEnumerator()) //675:15
                from prop in __Enumerate((__loop43_var1.Properties).GetEnumerator()) //675:20
                where prop.Kind == MetaPropertyKind.Readonly //675:36
                select new { __loop43_var1 = __loop43_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //675:3
                {
                    __out.Append("    /// Initializes the following readonly properties:"); //676:1
                    __out.AppendLine(false); //676:55
                    __out.Append("	/// <ul>"); //677:1
                    __out.AppendLine(false); //677:10
                    var __loop44_results = 
                        (from __loop44_var1 in __Enumerate((cls).GetEnumerator()) //678:11
                        from prop in __Enumerate((__loop44_var1.Properties).GetEnumerator()) //678:16
                        where prop.Kind == MetaPropertyKind.Readonly //678:32
                        select new { __loop44_var1 = __loop44_var1, prop = prop}
                        ).ToList(); //678:6
                    int __loop44_iteration = 0;
                    foreach (var __tmp70 in __loop44_results)
                    {
                        ++__loop44_iteration;
                        var __loop44_var1 = __tmp70.__loop44_var1;
                        var prop = __tmp70.prop;
                        string __tmp72Line = "    ///     <li>"; //679:1
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
                        string __tmp74Line = "</li>"; //679:28
                        if (__tmp74Line != null) __out.Append(__tmp74Line);
                        __out.AppendLine(false); //679:33
                    }
                    __out.Append("	/// </ul>"); //681:1
                    __out.AppendLine(false); //681:11
                }
                if ((from __loop45_var1 in __Enumerate((cls).GetEnumerator()) //683:15
                from prop in __Enumerate((__loop45_var1.Properties).GetEnumerator()) //683:20
                where prop.Kind == MetaPropertyKind.Lazy //683:36
                select new { __loop45_var1 = __loop45_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //683:3
                {
                    __out.Append("    /// Initializes the following lazy properties:"); //684:1
                    __out.AppendLine(false); //684:51
                    __out.Append("	/// <ul>"); //685:1
                    __out.AppendLine(false); //685:10
                    var __loop46_results = 
                        (from __loop46_var1 in __Enumerate((cls).GetEnumerator()) //686:11
                        from prop in __Enumerate((__loop46_var1.Properties).GetEnumerator()) //686:16
                        where prop.Kind == MetaPropertyKind.Lazy //686:32
                        select new { __loop46_var1 = __loop46_var1, prop = prop}
                        ).ToList(); //686:6
                    int __loop46_iteration = 0;
                    foreach (var __tmp75 in __loop46_results)
                    {
                        ++__loop46_iteration;
                        var __loop46_var1 = __tmp75.__loop46_var1;
                        var prop = __tmp75.prop;
                        string __tmp77Line = "    ///     <li>"; //687:1
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
                        string __tmp79Line = "</li>"; //687:28
                        if (__tmp79Line != null) __out.Append(__tmp79Line);
                        __out.AppendLine(false); //687:33
                    }
                    __out.Append("	/// </ul>"); //689:1
                    __out.AppendLine(false); //689:11
                }
                if ((from __loop47_var1 in __Enumerate((cls).GetEnumerator()) //691:15
                from prop in __Enumerate((__loop47_var1.Properties).GetEnumerator()) //691:20
                where prop.Kind == MetaPropertyKind.Derived //691:36
                select new { __loop47_var1 = __loop47_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //691:3
                {
                    __out.Append("    /// Initializes the following derived properties:"); //692:1
                    __out.AppendLine(false); //692:54
                    __out.Append("	/// <ul>"); //693:1
                    __out.AppendLine(false); //693:10
                    var __loop48_results = 
                        (from __loop48_var1 in __Enumerate((cls).GetEnumerator()) //694:11
                        from prop in __Enumerate((__loop48_var1.Properties).GetEnumerator()) //694:16
                        where prop.Kind == MetaPropertyKind.Derived //694:32
                        select new { __loop48_var1 = __loop48_var1, prop = prop}
                        ).ToList(); //694:6
                    int __loop48_iteration = 0;
                    foreach (var __tmp80 in __loop48_results)
                    {
                        ++__loop48_iteration;
                        var __loop48_var1 = __tmp80.__loop48_var1;
                        var prop = __tmp80.prop;
                        string __tmp82Line = "    ///     <li>"; //695:1
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
                        string __tmp84Line = "</li>"; //695:28
                        if (__tmp84Line != null) __out.Append(__tmp84Line);
                        __out.AppendLine(false); //695:33
                    }
                    __out.Append("	/// </ul>"); //697:1
                    __out.AppendLine(false); //697:11
                }
                string __tmp86Line = "    public virtual void "; //699:1
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
                string __tmp88Line = "("; //699:43
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
                string __tmp90Line = " @this)"; //699:79
                if (__tmp90Line != null) __out.Append(__tmp90Line);
                __out.AppendLine(false); //699:86
                __out.Append("    {"); //700:1
                __out.AppendLine(false); //700:6
                var __loop49_results = 
                    (from __loop49_var1 in __Enumerate((cls).GetEnumerator()) //701:9
                    from sup in __Enumerate((__loop49_var1.SuperClasses).GetEnumerator()) //701:14
                    select new { __loop49_var1 = __loop49_var1, sup = sup}
                    ).ToList(); //701:4
                int __loop49_iteration = 0;
                foreach (var __tmp91 in __loop49_results)
                {
                    ++__loop49_iteration;
                    var __loop49_var1 = __tmp91.__loop49_var1;
                    var sup = __tmp91.sup;
                    string __tmp93Line = "        this."; //702:1
                    if (__tmp93Line != null) __out.Append(__tmp93Line);
                    StringBuilder __tmp94 = new StringBuilder();
                    __tmp94.Append(sup.CSharpName());
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
                    string __tmp95Line = "(@this);"; //702:32
                    if (__tmp95Line != null) __out.Append(__tmp95Line);
                    __out.AppendLine(false); //702:40
                }
                string __tmp96Prefix = "		"; //704:1
                StringBuilder __tmp97 = new StringBuilder();
                __tmp97.Append(GenerateInitImplementation(model, cls));
                using(StreamReader __tmp97Reader = new StreamReader(this.__ToStream(__tmp97.ToString())))
                {
                    bool __tmp97_first = true;
                    bool __tmp97_last = __tmp97Reader.EndOfStream;
                    while(__tmp97_first || !__tmp97_last)
                    {
                        __tmp97_first = false;
                        string __tmp97Line = __tmp97Reader.ReadLine();
                        __tmp97_last = __tmp97Reader.EndOfStream;
                        __out.Append(__tmp96Prefix);
                        if (__tmp97Line != null) __out.Append(__tmp97Line);
                        if (!__tmp97_last) __out.AppendLine(true);
                        __out.AppendLine(false); //704:43
                    }
                }
                __out.Append("    }"); //705:1
                __out.AppendLine(false); //705:6
                var __loop50_results = 
                    (from __loop50_var1 in __Enumerate((cls).GetEnumerator()) //706:11
                    from op in __Enumerate((__loop50_var1.Operations).GetEnumerator()) //706:16
                    select new { __loop50_var1 = __loop50_var1, op = op}
                    ).ToList(); //706:6
                int __loop50_iteration = 0;
                foreach (var __tmp98 in __loop50_results)
                {
                    ++__loop50_iteration;
                    var __loop50_var1 = __tmp98.__loop50_var1;
                    var op = __tmp98.op;
                    __out.AppendLine(true); //707:1
                    __out.Append("    /// <summary>"); //708:1
                    __out.AppendLine(false); //708:18
                    string __tmp100Line = "    /// Implements the operation: "; //709:1
                    if (__tmp100Line != null) __out.Append(__tmp100Line);
                    StringBuilder __tmp101 = new StringBuilder();
                    __tmp101.Append(cls.CSharpName());
                    using(StreamReader __tmp101Reader = new StreamReader(this.__ToStream(__tmp101.ToString())))
                    {
                        bool __tmp101_first = true;
                        bool __tmp101_last = __tmp101Reader.EndOfStream;
                        while(__tmp101_first || !__tmp101_last)
                        {
                            __tmp101_first = false;
                            string __tmp101Line = __tmp101Reader.ReadLine();
                            __tmp101_last = __tmp101Reader.EndOfStream;
                            if (__tmp101Line != null) __out.Append(__tmp101Line);
                            if (!__tmp101_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp102Line = "."; //709:53
                    if (__tmp102Line != null) __out.Append(__tmp102Line);
                    StringBuilder __tmp103 = new StringBuilder();
                    __tmp103.Append(op.Name);
                    using(StreamReader __tmp103Reader = new StreamReader(this.__ToStream(__tmp103.ToString())))
                    {
                        bool __tmp103_first = true;
                        bool __tmp103_last = __tmp103Reader.EndOfStream;
                        while(__tmp103_first || !__tmp103_last)
                        {
                            __tmp103_first = false;
                            string __tmp103Line = __tmp103Reader.ReadLine();
                            __tmp103_last = __tmp103Reader.EndOfStream;
                            if (__tmp103Line != null) __out.Append(__tmp103Line);
                            if (!__tmp103_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp104Line = "()"; //709:63
                    if (__tmp104Line != null) __out.Append(__tmp104Line);
                    __out.AppendLine(false); //709:65
                    __out.Append("    /// </summary>"); //710:1
                    __out.AppendLine(false); //710:19
                    string __tmp106Line = "    public virtual "; //711:1
                    if (__tmp106Line != null) __out.Append(__tmp106Line);
                    StringBuilder __tmp107 = new StringBuilder();
                    __tmp107.Append(op.ReturnType.CSharpFullPublicName(ClassKind.Immutable));
                    using(StreamReader __tmp107Reader = new StreamReader(this.__ToStream(__tmp107.ToString())))
                    {
                        bool __tmp107_first = true;
                        bool __tmp107_last = __tmp107Reader.EndOfStream;
                        while(__tmp107_first || !__tmp107_last)
                        {
                            __tmp107_first = false;
                            string __tmp107Line = __tmp107Reader.ReadLine();
                            __tmp107_last = __tmp107Reader.EndOfStream;
                            if (__tmp107Line != null) __out.Append(__tmp107Line);
                            if (!__tmp107_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp108Line = " "; //711:77
                    if (__tmp108Line != null) __out.Append(__tmp108Line);
                    StringBuilder __tmp109 = new StringBuilder();
                    __tmp109.Append(cls.CSharpName());
                    using(StreamReader __tmp109Reader = new StreamReader(this.__ToStream(__tmp109.ToString())))
                    {
                        bool __tmp109_first = true;
                        bool __tmp109_last = __tmp109Reader.EndOfStream;
                        while(__tmp109_first || !__tmp109_last)
                        {
                            __tmp109_first = false;
                            string __tmp109Line = __tmp109Reader.ReadLine();
                            __tmp109_last = __tmp109Reader.EndOfStream;
                            if (__tmp109Line != null) __out.Append(__tmp109Line);
                            if (!__tmp109_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp110Line = "_"; //711:96
                    if (__tmp110Line != null) __out.Append(__tmp110Line);
                    StringBuilder __tmp111 = new StringBuilder();
                    __tmp111.Append(op.Name);
                    using(StreamReader __tmp111Reader = new StreamReader(this.__ToStream(__tmp111.ToString())))
                    {
                        bool __tmp111_first = true;
                        bool __tmp111_last = __tmp111Reader.EndOfStream;
                        while(__tmp111_first || !__tmp111_last)
                        {
                            __tmp111_first = false;
                            string __tmp111Line = __tmp111Reader.ReadLine();
                            __tmp111_last = __tmp111Reader.EndOfStream;
                            if (__tmp111Line != null) __out.Append(__tmp111Line);
                            if (!__tmp111_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp112Line = "("; //711:106
                    if (__tmp112Line != null) __out.Append(__tmp112Line);
                    StringBuilder __tmp113 = new StringBuilder();
                    __tmp113.Append(GetImplParameters(cls, op));
                    using(StreamReader __tmp113Reader = new StreamReader(this.__ToStream(__tmp113.ToString())))
                    {
                        bool __tmp113_first = true;
                        bool __tmp113_last = __tmp113Reader.EndOfStream;
                        while(__tmp113_first || !__tmp113_last)
                        {
                            __tmp113_first = false;
                            string __tmp113Line = __tmp113Reader.ReadLine();
                            __tmp113_last = __tmp113Reader.EndOfStream;
                            if (__tmp113Line != null) __out.Append(__tmp113Line);
                            if (!__tmp113_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp114Line = ")"; //711:135
                    if (__tmp114Line != null) __out.Append(__tmp114Line);
                    __out.AppendLine(false); //711:136
                    __out.Append("    {"); //712:1
                    __out.AppendLine(false); //712:6
                    __out.Append("        throw new NotImplementedException();"); //713:1
                    __out.AppendLine(false); //713:45
                    __out.Append("    }"); //714:1
                    __out.AppendLine(false); //714:6
                }
                __out.AppendLine(true); //716:1
            }
            var __loop51_results = 
                (from __loop51_var1 in __Enumerate((model).GetEnumerator()) //718:8
                from Namespace in __Enumerate((__loop51_var1.Namespace).GetEnumerator()) //718:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //718:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //718:40
                select new { __loop51_var1 = __loop51_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //718:3
            int __loop51_iteration = 0;
            foreach (var __tmp115 in __loop51_results)
            {
                ++__loop51_iteration;
                var __loop51_var1 = __tmp115.__loop51_var1;
                var Namespace = __tmp115.Namespace;
                var Declarations = __tmp115.Declarations;
                var enm = __tmp115.enm;
                var __loop52_results = 
                    (from __loop52_var1 in __Enumerate((enm).GetEnumerator()) //719:11
                    from op in __Enumerate((__loop52_var1.Operations).GetEnumerator()) //719:16
                    select new { __loop52_var1 = __loop52_var1, op = op}
                    ).ToList(); //719:6
                int __loop52_iteration = 0;
                foreach (var __tmp116 in __loop52_results)
                {
                    ++__loop52_iteration;
                    var __loop52_var1 = __tmp116.__loop52_var1;
                    var op = __tmp116.op;
                    __out.AppendLine(true); //720:1
                    __out.Append("    /// <summary>"); //721:1
                    __out.AppendLine(false); //721:18
                    string __tmp118Line = "    /// Implements the operation: "; //722:1
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
                    string __tmp120Line = "."; //722:53
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
                            __out.AppendLine(false); //722:63
                        }
                    }
                    __out.Append("    /// </summary>"); //723:1
                    __out.AppendLine(false); //723:19
                    string __tmp123Line = "    public virtual "; //724:1
                    if (__tmp123Line != null) __out.Append(__tmp123Line);
                    StringBuilder __tmp124 = new StringBuilder();
                    __tmp124.Append(op.ReturnType.CSharpFullPublicName(ClassKind.Immutable));
                    using(StreamReader __tmp124Reader = new StreamReader(this.__ToStream(__tmp124.ToString())))
                    {
                        bool __tmp124_first = true;
                        bool __tmp124_last = __tmp124Reader.EndOfStream;
                        while(__tmp124_first || !__tmp124_last)
                        {
                            __tmp124_first = false;
                            string __tmp124Line = __tmp124Reader.ReadLine();
                            __tmp124_last = __tmp124Reader.EndOfStream;
                            if (__tmp124Line != null) __out.Append(__tmp124Line);
                            if (!__tmp124_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp125Line = " "; //724:77
                    if (__tmp125Line != null) __out.Append(__tmp125Line);
                    StringBuilder __tmp126 = new StringBuilder();
                    __tmp126.Append(enm.CSharpName());
                    using(StreamReader __tmp126Reader = new StreamReader(this.__ToStream(__tmp126.ToString())))
                    {
                        bool __tmp126_first = true;
                        bool __tmp126_last = __tmp126Reader.EndOfStream;
                        while(__tmp126_first || !__tmp126_last)
                        {
                            __tmp126_first = false;
                            string __tmp126Line = __tmp126Reader.ReadLine();
                            __tmp126_last = __tmp126Reader.EndOfStream;
                            if (__tmp126Line != null) __out.Append(__tmp126Line);
                            if (!__tmp126_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp127Line = "_"; //724:96
                    if (__tmp127Line != null) __out.Append(__tmp127Line);
                    StringBuilder __tmp128 = new StringBuilder();
                    __tmp128.Append(op.Name);
                    using(StreamReader __tmp128Reader = new StreamReader(this.__ToStream(__tmp128.ToString())))
                    {
                        bool __tmp128_first = true;
                        bool __tmp128_last = __tmp128Reader.EndOfStream;
                        while(__tmp128_first || !__tmp128_last)
                        {
                            __tmp128_first = false;
                            string __tmp128Line = __tmp128Reader.ReadLine();
                            __tmp128_last = __tmp128Reader.EndOfStream;
                            if (__tmp128Line != null) __out.Append(__tmp128Line);
                            if (!__tmp128_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp129Line = "("; //724:106
                    if (__tmp129Line != null) __out.Append(__tmp129Line);
                    StringBuilder __tmp130 = new StringBuilder();
                    __tmp130.Append(GetImplParameters(enm, op));
                    using(StreamReader __tmp130Reader = new StreamReader(this.__ToStream(__tmp130.ToString())))
                    {
                        bool __tmp130_first = true;
                        bool __tmp130_last = __tmp130Reader.EndOfStream;
                        while(__tmp130_first || !__tmp130_last)
                        {
                            __tmp130_first = false;
                            string __tmp130Line = __tmp130Reader.ReadLine();
                            __tmp130_last = __tmp130Reader.EndOfStream;
                            if (__tmp130Line != null) __out.Append(__tmp130Line);
                            if (!__tmp130_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp131Line = ")"; //724:135
                    if (__tmp131Line != null) __out.Append(__tmp131Line);
                    __out.AppendLine(false); //724:136
                    __out.Append("    {"); //725:1
                    __out.AppendLine(false); //725:6
                    __out.Append("        throw new NotImplementedException();"); //726:1
                    __out.AppendLine(false); //726:45
                    __out.Append("    }"); //727:1
                    __out.AppendLine(false); //727:6
                }
                __out.AppendLine(true); //729:1
            }
            __out.AppendLine(true); //731:1
            var __loop53_results = 
                (from __loop53_var1 in __Enumerate((model).GetEnumerator()) //732:8
                from Namespace in __Enumerate((__loop53_var1.Namespace).GetEnumerator()) //732:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //732:26
                from func in __Enumerate((Declarations).GetEnumerator()).OfType<MetaFunction>() //732:40
                select new { __loop53_var1 = __loop53_var1, Namespace = Namespace, Declarations = Declarations, func = func}
                ).ToList(); //732:3
            int __loop53_iteration = 0;
            foreach (var __tmp132 in __loop53_results)
            {
                ++__loop53_iteration;
                var __loop53_var1 = __tmp132.__loop53_var1;
                var Namespace = __tmp132.Namespace;
                var Declarations = __tmp132.Declarations;
                var func = __tmp132.func;
                string __tmp133Prefix = "	"; //733:1
                StringBuilder __tmp134 = new StringBuilder();
                __tmp134.Append(GenerateFunction(func, ClassKind.Builder));
                using(StreamReader __tmp134Reader = new StreamReader(this.__ToStream(__tmp134.ToString())))
                {
                    bool __tmp134_first = true;
                    bool __tmp134_last = __tmp134Reader.EndOfStream;
                    while(__tmp134_first || !__tmp134_last)
                    {
                        __tmp134_first = false;
                        string __tmp134Line = __tmp134Reader.ReadLine();
                        __tmp134_last = __tmp134Reader.EndOfStream;
                        __out.Append(__tmp133Prefix);
                        if (__tmp134Line != null) __out.Append(__tmp134Line);
                        if (!__tmp134_last) __out.AppendLine(true);
                        __out.AppendLine(false); //733:45
                    }
                }
            }
            __out.Append("}"); //735:1
            __out.AppendLine(false); //735:2
            __out.AppendLine(true); //736:1
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //739:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //740:1
            __out.AppendLine(false); //740:14
            __out.Append("/// Factory class for creating instances of model elements."); //741:1
            __out.AppendLine(false); //741:60
            __out.Append("/// </summary>"); //742:1
            __out.AppendLine(false); //742:15
            string __tmp2Line = "public class "; //743:1
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
            string __tmp4Line = " : global::MetaDslx.Core.Immutable.ModelFactory"; //743:41
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //743:88
            __out.Append("{"); //744:1
            __out.AppendLine(false); //744:2
            __out.Append("	private bool makeSymbolCreated = true;"); //745:1
            __out.AppendLine(false); //745:40
            __out.AppendLine(true); //746:1
            string __tmp6Line = "    public "; //747:1
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
            string __tmp8Line = "(global::MetaDslx.Core.Immutable.MutableModel model = null, bool makeSymbolCreated = true)"; //747:39
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //747:129
            __out.Append("        : base(model)"); //748:1
            __out.AppendLine(false); //748:22
            __out.Append("    {"); //749:1
            __out.AppendLine(false); //749:6
            string __tmp9Prefix = "		"; //750:1
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
            string __tmp11Line = ".Init();"; //750:56
            if (__tmp11Line != null) __out.Append(__tmp11Line);
            __out.AppendLine(false); //750:64
            __out.Append("		this.makeSymbolCreated = makeSymbolCreated;"); //751:1
            __out.AppendLine(false); //751:46
            __out.Append("    }"); //752:1
            __out.AppendLine(false); //752:6
            __out.AppendLine(true); //753:1
            __out.Append("    public override global::MetaDslx.Core.Immutable.IMutableSymbol Create(string type)"); //754:1
            __out.AppendLine(false); //754:87
            __out.Append("    {"); //755:1
            __out.AppendLine(false); //755:6
            __out.Append("        switch (type)"); //756:1
            __out.AppendLine(false); //756:22
            __out.Append("        {"); //757:1
            __out.AppendLine(false); //757:10
            var __loop54_results = 
                (from __loop54_var1 in __Enumerate((model).GetEnumerator()) //758:10
                from Namespace in __Enumerate((__loop54_var1.Namespace).GetEnumerator()) //758:17
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //758:28
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //758:42
                select new { __loop54_var1 = __loop54_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //758:5
            int __loop54_iteration = 0;
            foreach (var __tmp12 in __loop54_results)
            {
                ++__loop54_iteration;
                var __loop54_var1 = __tmp12.__loop54_var1;
                var Namespace = __tmp12.Namespace;
                var Declarations = __tmp12.Declarations;
                var cls = __tmp12.cls;
                if (!cls.IsAbstract) //759:6
                {
                    string __tmp14Line = "            case \""; //760:1
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
                    string __tmp16Line = "\": return (global::MetaDslx.Core.Immutable.IMutableSymbol)this."; //760:37
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
                    string __tmp18Line = "();"; //760:118
                    if (__tmp18Line != null) __out.Append(__tmp18Line);
                    __out.AppendLine(false); //760:121
                }
            }
            __out.Append("            default:"); //763:1
            __out.AppendLine(false); //763:21
            __out.Append("                throw new ModelException(\"Unknown type name: \" + type);"); //764:1
            __out.AppendLine(false); //764:72
            __out.Append("        }"); //765:1
            __out.AppendLine(false); //765:10
            __out.Append("    }"); //766:1
            __out.AppendLine(false); //766:6
            var __loop55_results = 
                (from __loop55_var1 in __Enumerate((model).GetEnumerator()) //767:8
                from Namespace in __Enumerate((__loop55_var1.Namespace).GetEnumerator()) //767:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //767:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //767:40
                select new { __loop55_var1 = __loop55_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //767:3
            int __loop55_iteration = 0;
            foreach (var __tmp19 in __loop55_results)
            {
                ++__loop55_iteration;
                var __loop55_var1 = __tmp19.__loop55_var1;
                var Namespace = __tmp19.Namespace;
                var Declarations = __tmp19.Declarations;
                var cls = __tmp19.cls;
                if (!cls.IsAbstract) //768:4
                {
                    __out.AppendLine(true); //769:1
                    __out.Append("    /// <summary>"); //770:1
                    __out.AppendLine(false); //770:18
                    string __tmp21Line = "    /// Creates a new instance of "; //771:1
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
                    string __tmp23Line = "."; //771:53
                    if (__tmp23Line != null) __out.Append(__tmp23Line);
                    __out.AppendLine(false); //771:54
                    __out.Append("    /// </summary>"); //772:1
                    __out.AppendLine(false); //772:19
                    string __tmp25Line = "    public "; //773:1
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
                    string __tmp27Line = " "; //773:47
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
                    string __tmp29Line = "(params global::MetaDslx.Core.Immutable.PropertyInit"; //773:66
                    if (__tmp29Line != null) __out.Append(__tmp29Line);
                    StringBuilder __tmp30 = new StringBuilder();
                    __tmp30.Append("[]");
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
                    string __tmp31Line = " propertyInitializers)"; //773:124
                    if (__tmp31Line != null) __out.Append(__tmp31Line);
                    __out.AppendLine(false); //773:146
                    __out.Append("	{"); //774:1
                    __out.AppendLine(false); //774:3
                    string __tmp33Line = "		global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.AddSymbol(new "; //775:1
                    if (__tmp33Line != null) __out.Append(__tmp33Line);
                    StringBuilder __tmp34 = new StringBuilder();
                    __tmp34.Append(cls.CSharpName(ClassKind.Id));
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
                    string __tmp35Line = "());"; //775:162
                    if (__tmp35Line != null) __out.Append(__tmp35Line);
                    __out.AppendLine(false); //775:166
                    __out.Append("		symbol.MInitProperties(propertyInitializers);"); //776:1
                    __out.AppendLine(false); //776:48
                    __out.Append("		if (this.makeSymbolCreated) symbol.MMakeCreated();"); //777:1
                    __out.AppendLine(false); //777:53
                    string __tmp37Line = "		return ("; //778:1
                    if (__tmp37Line != null) __out.Append(__tmp37Line);
                    StringBuilder __tmp38 = new StringBuilder();
                    __tmp38.Append(cls.CSharpName(ClassKind.Builder));
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
                    string __tmp39Line = ")symbol;"; //778:46
                    if (__tmp39Line != null) __out.Append(__tmp39Line);
                    __out.AppendLine(false); //778:54
                    __out.Append("	}"); //779:1
                    __out.AppendLine(false); //779:3
                }
            }
            __out.Append("}"); //782:1
            __out.AppendLine(false); //782:2
            __out.AppendLine(true); //783:1
            return __out.ToString();
        }

        public string GenerateFunction(MetaFunction func, ClassKind classKind) //786:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "public abstract "; //787:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(func.ReturnType.CSharpFullPublicName(classKind));
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
            string __tmp4Line = " "; //787:66
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(func.Name);
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
            string __tmp6Line = "("; //787:78
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(GetParameters(func, classKind));
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
            string __tmp8Line = ");"; //787:111
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //787:113
            return __out.ToString();
        }

        public string GenerateInitImplementation(MetaModel model, MetaClass cls) //790:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop56_results = 
                (from __loop56_var1 in __Enumerate((cls).GetEnumerator()) //791:7
                from prop in __Enumerate((__loop56_var1.Properties).GetEnumerator()) //791:12
                select new { __loop56_var1 = __loop56_var1, prop = prop}
                ).ToList(); //791:2
            int __loop56_iteration = 0;
            foreach (var __tmp1 in __loop56_results)
            {
                ++__loop56_iteration;
                var __loop56_var1 = __tmp1.__loop56_var1;
                var prop = __tmp1.prop;
                MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //792:3
                if (synInit != null) //793:3
                {
                    if (ModelCompilerContext.Current.TypeProvider.GetTypeOf(synInit.Value) is MetaCollectionType) //794:4
                    {
                        string __tmp3Line = "@this."; //795:1
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
                        string __tmp5Line = ".ClearLazy();"; //795:18
                        if (__tmp5Line != null) __out.Append(__tmp5Line);
                        __out.AppendLine(false); //795:31
                        if (synInit.Value.Type is MetaCollectionType) //796:5
                        {
                            string __tmp7Line = "@this."; //797:1
                            if (__tmp7Line != null) __out.Append(__tmp7Line);
                            StringBuilder __tmp8 = new StringBuilder();
                            __tmp8.Append(prop.Name);
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
                            string __tmp9Line = ".LazyAddRange("; //797:18
                            if (__tmp9Line != null) __out.Append(__tmp9Line);
                            StringBuilder __tmp10 = new StringBuilder();
                            __tmp10.Append(GenerateExpression(synInit.Value));
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
                            string __tmp11Line = ");"; //797:67
                            if (__tmp11Line != null) __out.Append(__tmp11Line);
                            __out.AppendLine(false); //797:69
                        }
                        else //798:5
                        {
                            string __tmp13Line = "@this."; //799:1
                            if (__tmp13Line != null) __out.Append(__tmp13Line);
                            StringBuilder __tmp14 = new StringBuilder();
                            __tmp14.Append(prop.Name);
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
                            string __tmp15Line = ".LazyAdd("; //799:18
                            if (__tmp15Line != null) __out.Append(__tmp15Line);
                            StringBuilder __tmp16 = new StringBuilder();
                            __tmp16.Append(GenerateExpression(synInit.Value));
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
                            string __tmp17Line = ");"; //799:62
                            if (__tmp17Line != null) __out.Append(__tmp17Line);
                            __out.AppendLine(false); //799:64
                        }
                    }
                    else //801:4
                    {
                        string __tmp19Line = "@this."; //802:1
                        if (__tmp19Line != null) __out.Append(__tmp19Line);
                        StringBuilder __tmp20 = new StringBuilder();
                        __tmp20.Append(prop.Name);
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
                        string __tmp21Line = "Lazy = () => ("; //802:18
                        if (__tmp21Line != null) __out.Append(__tmp21Line);
                        StringBuilder __tmp22 = new StringBuilder();
                        __tmp22.Append(prop.Type.CSharpFullName(ClassKind.Builder));
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
                        string __tmp23Line = ")("; //802:77
                        if (__tmp23Line != null) __out.Append(__tmp23Line);
                        StringBuilder __tmp24 = new StringBuilder();
                        __tmp24.Append(GenerateExpression(synInit.Value));
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
                        string __tmp25Line = ");"; //802:114
                        if (__tmp25Line != null) __out.Append(__tmp25Line);
                        __out.AppendLine(false); //802:116
                    }
                }
            }
            var __loop57_results = 
                (from __loop57_var1 in __Enumerate((cls).GetEnumerator()) //806:7
                from Constructor in __Enumerate((__loop57_var1.Constructor).GetEnumerator()) //806:12
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //806:25
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaInheritedPropertyInitializer>() //806:39
                select new { __loop57_var1 = __loop57_var1, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //806:2
            int __loop57_iteration = 0;
            foreach (var __tmp26 in __loop57_results)
            {
                ++__loop57_iteration;
                var __loop57_var1 = __tmp26.__loop57_var1;
                var Constructor = __tmp26.Constructor;
                var Initializers = __tmp26.Initializers;
                var init = __tmp26.init;
                if (init.Object != null && init.Property != null) //807:3
                {
                    if (((MetaClass)init.Object.Type).GetAllSuperClasses(true).Contains(init.PropertyContext)) //808:4
                    {
                        if (init.Value.Type is MetaCollectionType) //809:5
                        {
                            string __tmp28Line = "@this."; //810:1
                            if (__tmp28Line != null) __out.Append(__tmp28Line);
                            StringBuilder __tmp29 = new StringBuilder();
                            __tmp29.Append(init.ObjectName);
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
                            string __tmp30Line = "LazyChild."; //810:24
                            if (__tmp30Line != null) __out.Append(__tmp30Line);
                            StringBuilder __tmp31 = new StringBuilder();
                            __tmp31.Append(init.PropertyName);
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
                            string __tmp32Line = " = () => "; //810:53
                            if (__tmp32Line != null) __out.Append(__tmp32Line);
                            StringBuilder __tmp33 = new StringBuilder();
                            __tmp33.Append(GenerateExpression(init.Value));
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
                                }
                            }
                            string __tmp34Line = "; "; //810:94
                            if (__tmp34Line != null) __out.Append(__tmp34Line);
                            __out.AppendLine(false); //810:96
                        }
                        else //811:5
                        {
                            string __tmp36Line = "@this."; //812:1
                            if (__tmp36Line != null) __out.Append(__tmp36Line);
                            StringBuilder __tmp37 = new StringBuilder();
                            __tmp37.Append(init.ObjectName);
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
                            string __tmp38Line = "LazyChild."; //812:24
                            if (__tmp38Line != null) __out.Append(__tmp38Line);
                            StringBuilder __tmp39 = new StringBuilder();
                            __tmp39.Append(init.PropertyName);
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
                            string __tmp40Line = " = () => "; //812:53
                            if (__tmp40Line != null) __out.Append(__tmp40Line);
                            StringBuilder __tmp41 = new StringBuilder();
                            __tmp41.Append(GenerateExpression(init.Value));
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
                            string __tmp42Line = ";"; //812:94
                            if (__tmp42Line != null) __out.Append(__tmp42Line);
                            __out.AppendLine(false); //812:95
                        }
                    }
                    else //814:4
                    {
                        string __tmp44Line = "((MutableSymbolBase)@this).MChildAddLazy("; //815:1
                        if (__tmp44Line != null) __out.Append(__tmp44Line);
                        StringBuilder __tmp45 = new StringBuilder();
                        __tmp45.Append(init.Object.CSharpFullDescriptorName(ClassKind.Immutable));
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
                        string __tmp46Line = ", "; //815:101
                        if (__tmp46Line != null) __out.Append(__tmp46Line);
                        StringBuilder __tmp47 = new StringBuilder();
                        __tmp47.Append(init.Property.CSharpFullDescriptorName(ClassKind.Immutable));
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
                        string __tmp48Line = ", () => "; //815:164
                        if (__tmp48Line != null) __out.Append(__tmp48Line);
                        StringBuilder __tmp49 = new StringBuilder();
                        __tmp49.Append(GenerateExpression(init.Value));
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
                        string __tmp50Line = ");"; //815:204
                        if (__tmp50Line != null) __out.Append(__tmp50Line);
                        __out.AppendLine(false); //815:206
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateExpression(MetaExpression expr) //821:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //822:10
            if (expr is MetaBracketExpression) //823:2
            {
                string __tmp4Line = "("; //823:33
                if (__tmp4Line != null) __out.Append(__tmp4Line);
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(GenerateExpression(((MetaBracketExpression)expr).Expression));
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
                string __tmp6Line = ")"; //823:71
                if (__tmp6Line != null) __out.Append(__tmp6Line);
            }
            else if (expr is MetaThisExpression) //824:2
            {
                __out.Append("@this"); //824:30
            }
            else if (expr is MetaNullExpression) //825:2
            {
                __out.Append("null"); //825:30
            }
            else if (expr is MetaTypeAsExpression) //826:2
            {
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append(GenerateExpression(((MetaTypeAsExpression)expr).Expression));
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
                string __tmp10Line = " as "; //826:69
                if (__tmp10Line != null) __out.Append(__tmp10Line);
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(((MetaTypeAsExpression)expr).TypeReference.CSharpName(ClassKind.Builder));
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
            }
            else if (expr is MetaTypeCastExpression) //827:2
            {
                string __tmp14Line = "("; //827:34
                if (__tmp14Line != null) __out.Append(__tmp14Line);
                StringBuilder __tmp15 = new StringBuilder();
                __tmp15.Append(((MetaTypeCastExpression)expr).TypeReference.CSharpName(ClassKind.Builder));
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
                string __tmp16Line = ")"; //827:85
                if (__tmp16Line != null) __out.Append(__tmp16Line);
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(GenerateExpression(((MetaTypeCastExpression)expr).Expression));
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
            }
            else if (expr is MetaTypeCheckExpression) //828:2
            {
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(GenerateExpression(((MetaTypeCheckExpression)expr).Expression));
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
                string __tmp21Line = " is "; //828:72
                if (__tmp21Line != null) __out.Append(__tmp21Line);
                StringBuilder __tmp22 = new StringBuilder();
                __tmp22.Append(((MetaTypeCheckExpression)expr).TypeReference.CSharpName(ClassKind.Builder));
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
            }
            else if (expr is MetaTypeOfExpression) //829:2
            {
                StringBuilder __tmp25 = new StringBuilder();
                __tmp25.Append(GenerateTypeOf(((MetaTypeOfExpression)expr)));
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
            }
            else if (expr is MetaConditionalExpression) //830:2
            {
                StringBuilder __tmp28 = new StringBuilder();
                __tmp28.Append(GenerateExpression(((MetaConditionalExpression)expr).Condition));
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
                string __tmp29Line = " ? "; //830:73
                if (__tmp29Line != null) __out.Append(__tmp29Line);
                StringBuilder __tmp30 = new StringBuilder();
                __tmp30.Append(GenerateExpression(((MetaConditionalExpression)expr).Then));
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
                string __tmp31Line = " : "; //830:107
                if (__tmp31Line != null) __out.Append(__tmp31Line);
                StringBuilder __tmp32 = new StringBuilder();
                __tmp32.Append(GenerateExpression(((MetaConditionalExpression)expr).Else));
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
            }
            else if (expr is MetaConstantExpression) //831:2
            {
                StringBuilder __tmp35 = new StringBuilder();
                __tmp35.Append(GetCSharpValue(((MetaConstantExpression)expr).Value));
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
            }
            else if (expr is MetaIdentifierExpression) //832:2
            {
                StringBuilder __tmp38 = new StringBuilder();
                __tmp38.Append(GenerateIdentifierExpression(((MetaIdentifierExpression)expr)));
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
            }
            else if (expr is MetaMemberAccessExpression) //833:2
            {
                StringBuilder __tmp41 = new StringBuilder();
                __tmp41.Append(GenerateExpression(((MetaMemberAccessExpression)expr).Expression));
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
                string __tmp42Line = "."; //833:75
                if (__tmp42Line != null) __out.Append(__tmp42Line);
                StringBuilder __tmp43 = new StringBuilder();
                __tmp43.Append(((MetaMemberAccessExpression)expr).Name);
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
            }
            else if (expr is MetaFunctionCallExpression) //834:2
            {
                StringBuilder __tmp46 = new StringBuilder();
                __tmp46.Append(GenerateFunctionCall(((MetaFunctionCallExpression)expr)));
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
            }
            else if (expr is MetaIndexerExpression) //835:2
            {
                StringBuilder __tmp49 = new StringBuilder();
                __tmp49.Append(GenerateIndexerCall(((MetaIndexerExpression)expr)));
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
            }
            else if (expr is MetaOperatorExpression) //836:2
            {
                StringBuilder __tmp52 = new StringBuilder();
                __tmp52.Append(GenerateOperator(((MetaOperatorExpression)expr)));
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
            }
            else if (expr is MetaNewExpression) //837:2
            {
                string __tmp55Line = "factory."; //837:29
                if (__tmp55Line != null) __out.Append(__tmp55Line);
                StringBuilder __tmp56 = new StringBuilder();
                __tmp56.Append(((MetaNewExpression)expr).TypeReference.CSharpName(ClassKind.Immutable));
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
                string __tmp57Line = "("; //837:89
                if (__tmp57Line != null) __out.Append(__tmp57Line);
                StringBuilder __tmp58 = new StringBuilder();
                __tmp58.Append(GenerateNewPropertyInitializers(((MetaNewExpression)expr)));
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
                string __tmp59Line = ")"; //837:129
                if (__tmp59Line != null) __out.Append(__tmp59Line);
            }
            else if (expr is MetaNewCollectionExpression) //838:2
            {
                string __tmp62Line = "new List<Func<object>>() { "; //838:39
                if (__tmp62Line != null) __out.Append(__tmp62Line);
                StringBuilder __tmp63 = new StringBuilder();
                __tmp63.Append(GenerateNewCollectionValues(((MetaNewCollectionExpression)expr)));
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
                string __tmp64Line = " }"; //838:101
                if (__tmp64Line != null) __out.Append(__tmp64Line);
            }
            else //839:2
            {
                __out.Append("***unknown expression type***"); //839:11
                __out.AppendLine(false); //839:40
            }//840:2
            return __out.ToString();
        }

        public string GenerateIdentifierExpression(MetaIdentifierExpression expr) //843:1
        {
            StringBuilder __out = new StringBuilder();
            if (expr.Definition is MetaProperty) //844:2
            {
                string __tmp2Line = "@this."; //845:1
                if (__tmp2Line != null) __out.Append(__tmp2Line);
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(expr.Name);
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
            }
            else //846:2
            {
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(expr.Name);
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
            }
            return __out.ToString();
        }

        public bool SameFunction(MetaGlobalFunction mfunc1, MetaGlobalFunction mfunc2) //851:1
        {
            return mfunc1.Name == mfunc2.Name && ModelCompilerContext.Current.TypeProvider.Equals((ModelObject)mfunc1.Type, (ModelObject)mfunc2.Type); //852:2
        }

        public string GenerateFunctionCall(MetaFunctionCallExpression call) //855:1
        {
            StringBuilder __out = new StringBuilder();
            if (call.Definition is MetaGlobalFunction && SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.TypeOf)) //856:2
            {
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(GenerateTypeOf(call.Arguments[0]));
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
            }
            else //857:2
            {
                string __tmp6Line = "this."; //857:7
                if (__tmp6Line != null) __out.Append(__tmp6Line);
                StringBuilder __tmp7 = new StringBuilder();
                __tmp7.Append(GenerateExpression(call.Expression));
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
                string __tmp8Line = "("; //857:49
                if (__tmp8Line != null) __out.Append(__tmp8Line);
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append(GenerateCallArguments(call, ""));
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
                string __tmp10Line = ")"; //857:83
                if (__tmp10Line != null) __out.Append(__tmp10Line);
            }
            return __out.ToString();
        }

        public string GenerateIndexerCall(MetaIndexerExpression call) //861:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(GenerateExpression(call.Expression));
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
            __tmp4.Append(GenerateCallArguments(call, ""));
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
                }
            }
            return __out.ToString();
        }

        public string GenerateTypeOf(object expr) //865:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //866:9
            if (expr is MetaPrimitiveType) //867:2
            {
                var __tmp2 = ((MetaPrimitiveType)expr).Name; //868:9
                if (__tmp2 == "*none*") //869:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.None.ToMutable()"); //869:17
                }
                else if (__tmp2 == "*error*") //870:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.Error.ToMutable()"); //870:18
                }
                else if (__tmp2 == "*any*") //871:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.Any.ToMutable()"); //871:16
                }
                else if (__tmp2 == "object") //872:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.Object.ToMutable()"); //872:17
                }
                else if (__tmp2 == "string") //873:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.String.ToMutable()"); //873:17
                }
                else if (__tmp2 == "int") //874:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.Int.ToMutable()"); //874:14
                }
                else if (__tmp2 == "long") //875:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.Long.ToMutable()"); //875:15
                }
                else if (__tmp2 == "float") //876:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.Float.ToMutable()"); //876:16
                }
                else if (__tmp2 == "double") //877:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.Double.ToMutable()"); //877:17
                }
                else if (__tmp2 == "byte") //878:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.Byte.ToMutable()"); //878:15
                }
                else if (__tmp2 == "bool") //879:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.Bool.ToMutable()"); //879:15
                }
                else if (__tmp2 == "void") //880:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.Void.ToMutable()"); //880:15
                }
                else if (__tmp2 == "ModelObject") //881:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.ModelObject.ToMutable()"); //881:22
                }
                else if (__tmp2 == "ModelObjectList") //882:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.ModelObjectList.ToMutable()"); //882:26
                }
                else if (__tmp2 == "DefinitionList") //883:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.DefinitionList.ToMutable()"); //883:25
                }//884:2
            }
            else if (expr is MetaTypeOfExpression) //885:2
            {
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(GenerateTypeOf(((MetaTypeOfExpression)expr).TypeReference));
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
            }
            else if (expr is MetaClass) //886:2
            {
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(((MetaClass)expr).CSharpFullDescriptorName(ClassKind.Immutable));
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
                string __tmp9Line = ".MetaClass"; //886:73
                if (__tmp9Line != null) __out.Append(__tmp9Line);
            }
            else if (expr is MetaCollectionType) //887:2
            {
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(((MetaCollectionType)expr).CSharpFullName(ClassKind.Immutable));
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
            }
            else //888:2
            {
                __out.Append("***error***"); //888:11
            }//889:2
            return __out.ToString();
        }

        public string GenerateCallArguments(MetaBoundExpression call, string prefix) //892:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop58_results = 
                (from __loop58_var1 in __Enumerate((call).GetEnumerator()) //893:7
                from arg in __Enumerate((__loop58_var1.Arguments).GetEnumerator()) //893:13
                select new { __loop58_var1 = __loop58_var1, arg = arg}
                ).ToList(); //893:2
            int __loop58_iteration = 0;
            string delim = ""; //893:28
            foreach (var __tmp1 in __loop58_results)
            {
                ++__loop58_iteration;
                if (__loop58_iteration >= 2) //893:47
                {
                    delim = ", "; //893:47
                }
                var __loop58_var1 = __tmp1.__loop58_var1;
                var arg = __tmp1.arg;
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(delim);
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
                __tmp4.Append(prefix);
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
                __tmp5.Append(GenerateExpression(arg));
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
            }
            return __out.ToString();
        }

        public string GenerateOperator(MetaOperatorExpression expr) //898:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //899:10
            if (expr is MetaUnaryExpression) //900:2
            {
                if (((MetaUnaryExpression)expr) is MetaPostIncrementAssignExpression || ((MetaUnaryExpression)expr) is MetaPostDecrementAssignExpression) //901:3
                {
                    StringBuilder __tmp3 = new StringBuilder();
                    __tmp3.Append(GenerateExpression(((MetaUnaryExpression)expr).Expression));
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
                    __tmp4.Append(GetCSharpOperator(((MetaUnaryExpression)expr)));
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
                }
                else //903:3
                {
                    StringBuilder __tmp6 = new StringBuilder();
                    __tmp6.Append(GetCSharpOperator(((MetaUnaryExpression)expr)));
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
                    StringBuilder __tmp7 = new StringBuilder();
                    __tmp7.Append(GenerateExpression(((MetaUnaryExpression)expr).Expression));
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
                }
            }
            else if (expr is MetaBinaryExpression) //906:2
            {
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append(GenerateExpression(((MetaBinaryExpression)expr).Left));
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
                __tmp10.Append(GetCSharpOperator(((MetaBinaryExpression)expr)));
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
                __tmp11.Append(GenerateExpression(((MetaBinaryExpression)expr).Right));
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
            }//908:2
            return __out.ToString();
        }

        public string GenerateNewPropertyInitializers(MetaNewExpression expr) //911:1
        {
            StringBuilder __out = new StringBuilder();
            if ((from __loop59_var1 in __Enumerate((expr).GetEnumerator()) //912:14
            from pi in __Enumerate((__loop59_var1.PropertyInitializers).GetEnumerator()) //912:20
            select new { __loop59_var1 = __loop59_var1, pi = pi}
            ).GetEnumerator().MoveNext()) //912:2
            {
                var __loop60_results = 
                    (from __loop60_var1 in __Enumerate((expr).GetEnumerator()) //913:7
                    from pi in __Enumerate((__loop60_var1.PropertyInitializers).GetEnumerator()) //913:13
                    select new { __loop60_var1 = __loop60_var1, pi = pi}
                    ).ToList(); //913:2
                int __loop60_iteration = 0;
                string delim = ""; //913:38
                foreach (var __tmp1 in __loop60_results)
                {
                    ++__loop60_iteration;
                    if (__loop60_iteration >= 2) //913:57
                    {
                        delim = ", "; //913:57
                    }
                    var __loop60_var1 = __tmp1.__loop60_var1;
                    var pi = __tmp1.pi;
                    StringBuilder __tmp3 = new StringBuilder();
                    __tmp3.Append(delim);
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
                    string __tmp4Line = "new PropertyInit("; //914:8
                    if (__tmp4Line != null) __out.Append(__tmp4Line);
                    StringBuilder __tmp5 = new StringBuilder();
                    __tmp5.Append(pi.Property.CSharpFullDescriptorName(ClassKind.Immutable));
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
                    string __tmp6Line = ", () => "; //914:84
                    if (__tmp6Line != null) __out.Append(__tmp6Line);
                    StringBuilder __tmp7 = new StringBuilder();
                    __tmp7.Append(GenerateExpression(pi.Value));
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
                    string __tmp8Line = ")"; //914:122
                    if (__tmp8Line != null) __out.Append(__tmp8Line);
                }
            }
            return __out.ToString();
        }

        public string GenerateNewCollectionValues(MetaNewCollectionExpression expr) //919:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop61_results = 
                (from __loop61_var1 in __Enumerate((expr).GetEnumerator()) //920:7
                from v in __Enumerate((__loop61_var1.Values).GetEnumerator()) //920:13
                select new { __loop61_var1 = __loop61_var1, v = v}
                ).ToList(); //920:2
            int __loop61_iteration = 0;
            string delim = ""; //920:23
            foreach (var __tmp1 in __loop61_results)
            {
                ++__loop61_iteration;
                if (__loop61_iteration >= 2) //920:42
                {
                    delim = ", \n"; //920:42
                }
                var __loop61_var1 = __tmp1.__loop61_var1;
                var v = __tmp1.v;
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(delim);
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
                __tmp4.Append(GenerateExpression(v));
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
            }
            return __out.ToString();
        }

        public string GetCSharpValue(object value) //925:1
        {
            if (value == null) //926:2
            {
                return "null"; //926:21
            }
            else if (value is bool && ((bool)value) == true) //927:2
            {
                return "true"; //927:51
            }
            else if (value is bool && ((bool)value) == false) //928:2
            {
                return "false"; //928:52
            }
            else if (value is string) //929:2
            {
                return "\"" + value.ToString() + "\""; //929:28
            }
            else if (value is MetaExpression) //930:2
            {
                return GenerateExpression((MetaExpression)value); //930:36
            }
            else //931:2
            {
                return value.ToString(); //931:7
            }
        }

        public string GetCSharpIdentifier(object value) //935:1
        {
            if (value == null) //936:2
            {
                return null; //937:3
            }
            if (value is MetaConstantExpression && ((MetaConstantExpression)value).Value != null) //939:2
            {
                return ((MetaConstantExpression)value).Value.ToString(); //940:3
            }
            else if (value is string) //941:2
            {
                return value.ToString(); //942:3
            }
            else //943:2
            {
                return null; //944:3
            }
        }

        public string GetCSharpOperator(MetaOperatorExpression expr) //948:1
        {
            var __tmp1 = expr; //949:9
            if (expr is MetaUnaryPlusExpression) //950:3
            {
                return "+"; //950:36
            }
            else if (expr is MetaNegateExpression) //951:3
            {
                return "-"; //951:33
            }
            else if (expr is MetaOnesComplementExpression) //952:3
            {
                return "~"; //952:41
            }
            else if (expr is MetaNotExpression) //953:3
            {
                return "!"; //953:30
            }
            else if (expr is MetaPostIncrementAssignExpression) //954:3
            {
                return "++"; //954:46
            }
            else if (expr is MetaPostDecrementAssignExpression) //955:3
            {
                return "--"; //955:46
            }
            else if (expr is MetaPreIncrementAssignExpression) //956:3
            {
                return "++"; //956:45
            }
            else if (expr is MetaPreDecrementAssignExpression) //957:3
            {
                return "--"; //957:45
            }
            else if (expr is MetaMultiplyExpression) //958:3
            {
                return "*"; //958:35
            }
            else if (expr is MetaDivideExpression) //959:3
            {
                return "/"; //959:33
            }
            else if (expr is MetaModuloExpression) //960:3
            {
                return "%"; //960:33
            }
            else if (expr is MetaAddExpression) //961:3
            {
                return "+"; //961:30
            }
            else if (expr is MetaSubtractExpression) //962:3
            {
                return "-"; //962:35
            }
            else if (expr is MetaLeftShiftExpression) //963:3
            {
                return "<<"; //963:36
            }
            else if (expr is MetaRightShiftExpression) //964:3
            {
                return ">>"; //964:37
            }
            else if (expr is MetaLessThanExpression) //965:3
            {
                return "<"; //965:35
            }
            else if (expr is MetaLessThanOrEqualExpression) //966:3
            {
                return "<="; //966:42
            }
            else if (expr is MetaGreaterThanExpression) //967:3
            {
                return ">"; //967:38
            }
            else if (expr is MetaGreaterThanOrEqualExpression) //968:3
            {
                return ">="; //968:45
            }
            else if (expr is MetaEqualExpression) //969:3
            {
                return "=="; //969:32
            }
            else if (expr is MetaNotEqualExpression) //970:3
            {
                return "!="; //970:35
            }
            else if (expr is MetaAndExpression) //971:3
            {
                return "&"; //971:30
            }
            else if (expr is MetaOrExpression) //972:3
            {
                return "|"; //972:29
            }
            else if (expr is MetaExclusiveOrExpression) //973:3
            {
                return "^"; //973:38
            }
            else if (expr is MetaAndAlsoExpression) //974:3
            {
                return "&&"; //974:34
            }
            else if (expr is MetaOrElseExpression) //975:3
            {
                return "||"; //975:33
            }
            else if (expr is MetaNullCoalescingExpression) //976:3
            {
                return "??"; //976:41
            }
            else if (expr is MetaMultiplyAssignExpression) //977:3
            {
                return "*="; //977:41
            }
            else if (expr is MetaDivideAssignExpression) //978:3
            {
                return "/="; //978:39
            }
            else if (expr is MetaModuloAssignExpression) //979:3
            {
                return "%="; //979:39
            }
            else if (expr is MetaAddAssignExpression) //980:3
            {
                return "+="; //980:36
            }
            else if (expr is MetaSubtractAssignExpression) //981:3
            {
                return "-="; //981:41
            }
            else if (expr is MetaLeftShiftAssignExpression) //982:3
            {
                return "<<="; //982:42
            }
            else if (expr is MetaRightShiftAssignExpression) //983:3
            {
                return ">>="; //983:43
            }
            else if (expr is MetaAndAssignExpression) //984:3
            {
                return "&="; //984:36
            }
            else if (expr is MetaExclusiveOrAssignExpression) //985:3
            {
                return "^="; //985:44
            }
            else if (expr is MetaOrAssignExpression) //986:3
            {
                return "|="; //986:35
            }
            else //987:3
            {
                return ""; //987:12
            }//988:2
        }

        public string GetTypeName(MetaExpression expr) //991:1
        {
            if (expr is MetaTypeOfExpression) //992:2
            {
                return ((MetaTypeOfExpression)expr).TypeReference.CSharpFullName(ClassKind.Immutable); //992:36
            }
            else //993:2
            {
                return null; //993:7
            }
        }

        public string GenerateMetaModelInstance(MetaModel model) //999:1
        {
            StringBuilder __out = new StringBuilder();
            Dictionary<ModelObject,string> mobjToName = model.GetNamedModelObjects(); //1000:2
            bool coreModel = model.CSharpFullName(ClassKind.Immutable) == "global::MetaDslx.Core.Immutable.Meta"; //1001:2
            string __tmp2Line = "internal class "; //1002:1
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
                    __out.AppendLine(false); //1002:62
                }
            }
            __out.Append("{"); //1003:1
            __out.AppendLine(false); //1003:2
            string __tmp5Line = "	internal static "; //1004:1
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
            string __tmp7Line = " instance = new "; //1004:64
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
            string __tmp9Line = "();"; //1004:126
            if (__tmp9Line != null) __out.Append(__tmp9Line);
            __out.AppendLine(false); //1004:129
            __out.AppendLine(true); //1005:1
            __out.Append("	internal global::MetaDslx.Core.Immutable.MetaModelBuilder metaModel;"); //1006:1
            __out.AppendLine(false); //1006:70
            __out.Append("	internal global::MetaDslx.Core.Immutable.MutableModel model;"); //1007:1
            __out.AppendLine(false); //1007:62
            __out.AppendLine(true); //1008:1
            var __loop62_results = 
                (from __loop62_var1 in __Enumerate((model).GetEnumerator()) //1009:11
                from Namespace in __Enumerate((__loop62_var1.Namespace).GetEnumerator()) //1009:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //1009:29
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //1009:43
                select new { __loop62_var1 = __loop62_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //1009:6
            int __loop62_iteration = 0;
            foreach (var __tmp10 in __loop62_results)
            {
                ++__loop62_iteration;
                var __loop62_var1 = __tmp10.__loop62_var1;
                var Namespace = __tmp10.Namespace;
                var Declarations = __tmp10.Declarations;
                var c = __tmp10.c;
                string __tmp11Prefix = "    "; //1010:1
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(GenerateModelConstant(model, c));
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
                        __out.AppendLine(false); //1010:38
                    }
                }
            }
            __out.AppendLine(true); //1012:1
            var __loop63_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //1013:11
                select new { mobj = mobj}
                ).ToList(); //1013:6
            int __loop63_iteration = 0;
            foreach (var __tmp13 in __loop63_results)
            {
                ++__loop63_iteration;
                var mobj = __tmp13.mobj;
                string __tmp14Prefix = "	"; //1014:1
                StringBuilder __tmp15 = new StringBuilder();
                __tmp15.Append(GenerateModelObjectInstanceDeclaration(mobj, mobjToName));
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
                        __out.AppendLine(false); //1014:60
                    }
                }
            }
            __out.AppendLine(true); //1016:1
            string __tmp17Line = "    private "; //1017:1
            if (__tmp17Line != null) __out.Append(__tmp17Line);
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append(model.CSharpInstancesName(ClassKind.Builder));
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
            string __tmp19Line = "()"; //1017:59
            if (__tmp19Line != null) __out.Append(__tmp19Line);
            __out.AppendLine(false); //1017:61
            __out.Append("    {"); //1018:1
            __out.AppendLine(false); //1018:6
            string __tmp20Prefix = "		"; //1019:1
            StringBuilder __tmp21 = new StringBuilder();
            __tmp21.Append(model.CSharpFullFactoryName(ClassKind.Immutable));
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
                }
            }
            string __tmp22Line = " factory = new "; //1019:53
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            StringBuilder __tmp23 = new StringBuilder();
            __tmp23.Append(model.CSharpFullFactoryName(ClassKind.Immutable));
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
            string __tmp24Line = "(model, false);"; //1019:118
            if (__tmp24Line != null) __out.Append(__tmp24Line);
            __out.AppendLine(false); //1019:133
            __out.AppendLine(true); //1020:1
            var __loop64_results = 
                (from __loop64_var1 in __Enumerate((model).GetEnumerator()) //1021:9
                from Namespace in __Enumerate((__loop64_var1.Namespace).GetEnumerator()) //1021:16
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //1021:27
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //1021:41
                select new { __loop64_var1 = __loop64_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //1021:4
            int __loop64_iteration = 0;
            foreach (var __tmp25 in __loop64_results)
            {
                ++__loop64_iteration;
                var __loop64_var1 = __tmp25.__loop64_var1;
                var Namespace = __tmp25.Namespace;
                var Declarations = __tmp25.Declarations;
                var c = __tmp25.c;
                string __tmp26Prefix = "        "; //1022:1
                StringBuilder __tmp27 = new StringBuilder();
                __tmp27.Append(GenerateModelConstantImpl(model, c, mobjToName));
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
                        __out.AppendLine(false); //1022:58
                    }
                }
            }
            __out.AppendLine(true); //1024:1
            var __loop65_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //1025:9
                select new { mobj = mobj}
                ).ToList(); //1025:4
            int __loop65_iteration = 0;
            foreach (var __tmp28 in __loop65_results)
            {
                ++__loop65_iteration;
                var mobj = __tmp28.mobj;
                string __tmp29Prefix = "		"; //1026:1
                StringBuilder __tmp30 = new StringBuilder();
                __tmp30.Append(GenerateModelObjectInstance(mobj, mobjToName));
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
                        __out.AppendLine(false); //1026:50
                    }
                }
            }
            __out.AppendLine(true); //1028:1
            var __loop66_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //1029:9
                select new { mobj = mobj}
                ).ToList(); //1029:4
            int __loop66_iteration = 0;
            foreach (var __tmp31 in __loop66_results)
            {
                ++__loop66_iteration;
                var mobj = __tmp31.mobj;
                string __tmp32Prefix = "		"; //1030:1
                StringBuilder __tmp33 = new StringBuilder();
                __tmp33.Append(GenerateModelObjectInstanceInitializer(coreModel, mobj, mobjToName));
                using(StreamReader __tmp33Reader = new StreamReader(this.__ToStream(__tmp33.ToString())))
                {
                    bool __tmp33_first = true;
                    bool __tmp33_last = __tmp33Reader.EndOfStream;
                    while(__tmp33_first || !__tmp33_last)
                    {
                        __tmp33_first = false;
                        string __tmp33Line = __tmp33Reader.ReadLine();
                        __tmp33_last = __tmp33Reader.EndOfStream;
                        __out.Append(__tmp32Prefix);
                        if (__tmp33Line != null) __out.Append(__tmp33Line);
                        if (!__tmp33_last) __out.AppendLine(true);
                        __out.AppendLine(false); //1030:72
                    }
                }
            }
            __out.AppendLine(true); //1032:1
            var __loop67_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //1033:9
                select new { mobj = mobj}
                ).ToList(); //1033:4
            int __loop67_iteration = 0;
            foreach (var __tmp34 in __loop67_results)
            {
                ++__loop67_iteration;
                var mobj = __tmp34.mobj;
                string __tmp35Prefix = "		"; //1034:1
                StringBuilder __tmp36 = new StringBuilder();
                __tmp36.Append(GenerateModelObjectInstanceFinalizer(mobj, mobjToName));
                using(StreamReader __tmp36Reader = new StreamReader(this.__ToStream(__tmp36.ToString())))
                {
                    bool __tmp36_first = true;
                    bool __tmp36_last = __tmp36Reader.EndOfStream;
                    while(__tmp36_first || !__tmp36_last)
                    {
                        __tmp36_first = false;
                        string __tmp36Line = __tmp36Reader.ReadLine();
                        __tmp36_last = __tmp36Reader.EndOfStream;
                        __out.Append(__tmp35Prefix);
                        if (__tmp36Line != null) __out.Append(__tmp36Line);
                        if (!__tmp36_last) __out.AppendLine(true);
                        __out.AppendLine(false); //1034:59
                    }
                }
            }
            __out.AppendLine(true); //1036:1
            __out.Append("        model.EvaluateLazyValues();"); //1037:1
            __out.AppendLine(false); //1037:36
            __out.Append("    }"); //1038:1
            __out.AppendLine(false); //1038:6
            __out.Append("}"); //1039:1
            __out.AppendLine(false); //1039:2
            __out.AppendLine(true); //1040:1
            string __tmp38Line = "public class "; //1041:1
            if (__tmp38Line != null) __out.Append(__tmp38Line);
            StringBuilder __tmp39 = new StringBuilder();
            __tmp39.Append(model.CSharpInstancesName(ClassKind.Immutable));
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
                    __out.AppendLine(false); //1041:62
                }
            }
            __out.Append("{"); //1042:1
            __out.AppendLine(false); //1042:2
            var __loop68_results = 
                (from __loop68_var1 in __Enumerate((model).GetEnumerator()) //1043:11
                from Namespace in __Enumerate((__loop68_var1.Namespace).GetEnumerator()) //1043:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //1043:29
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //1043:43
                select new { __loop68_var1 = __loop68_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //1043:6
            int __loop68_iteration = 0;
            foreach (var __tmp40 in __loop68_results)
            {
                ++__loop68_iteration;
                var __loop68_var1 = __tmp40.__loop68_var1;
                var Namespace = __tmp40.Namespace;
                var Declarations = __tmp40.Declarations;
                var c = __tmp40.c;
                string __tmp41Prefix = "    "; //1044:1
                StringBuilder __tmp42 = new StringBuilder();
                __tmp42.Append(GenerateImmutableModelConstant(model, c));
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
                        __out.AppendLine(false); //1044:47
                    }
                }
            }
            __out.AppendLine(true); //1046:1
            var __loop69_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //1047:11
                select new { mobj = mobj}
                ).ToList(); //1047:6
            int __loop69_iteration = 0;
            foreach (var __tmp43 in __loop69_results)
            {
                ++__loop69_iteration;
                var mobj = __tmp43.mobj;
                string __tmp44Prefix = "	"; //1048:1
                StringBuilder __tmp45 = new StringBuilder();
                __tmp45.Append(GenerateImmutableModelObjectInstanceDeclaration(model, mobj, mobjToName));
                using(StreamReader __tmp45Reader = new StreamReader(this.__ToStream(__tmp45.ToString())))
                {
                    bool __tmp45_first = true;
                    bool __tmp45_last = __tmp45Reader.EndOfStream;
                    while(__tmp45_first || !__tmp45_last)
                    {
                        __tmp45_first = false;
                        string __tmp45Line = __tmp45Reader.ReadLine();
                        __tmp45_last = __tmp45Reader.EndOfStream;
                        __out.Append(__tmp44Prefix);
                        if (__tmp45Line != null) __out.Append(__tmp45Line);
                        if (!__tmp45_last) __out.AppendLine(true);
                        __out.AppendLine(false); //1048:76
                    }
                }
            }
            __out.Append("}"); //1050:1
            __out.AppendLine(false); //1050:2
            return __out.ToString();
        }

        public string GenerateImmutableModelConstant(MetaModel model, MetaConstant mconst) //1054:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(GenerateDocumentation(mconst));
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
                    __out.AppendLine(false); //1055:32
                }
            }
            string __tmp4Line = "public static readonly "; //1056:1
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(mconst.Type.CSharpFullName(ClassKind.Immutable));
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
            string __tmp6Line = " "; //1056:73
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(mconst.Name);
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
            string __tmp8Line = " = "; //1056:87
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(model.CSharpInstancesName(ClassKind.Builder));
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
            string __tmp10Line = ".instance."; //1056:136
            if (__tmp10Line != null) __out.Append(__tmp10Line);
            StringBuilder __tmp11 = new StringBuilder();
            __tmp11.Append(mconst.Name);
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
            string __tmp12Line = ".ToImmutable();"; //1056:159
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //1056:174
            return __out.ToString();
        }

        public string GenerateImmutableModelObjectInstanceDeclaration(MetaModel model, ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //1059:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //1060:2
            {
                if (mobjToName.ContainsKey(mobj)) //1061:3
                {
                    if (!mobjToName[mobj].StartsWith("__")) //1062:4
                    {
                        string name = mobjToName[mobj]; //1063:2
                        if (mobj is MetaDocumentedElement) //1064:5
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
                                    __out.AppendLine(false); //1065:55
                                }
                            }
                        }
                        string __tmp4Line = "public static readonly global::MetaDslx.Core.Immutable."; //1067:1
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
                        string __tmp6Line = " "; //1067:105
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
                        string __tmp8Line = " = "; //1067:112
                        if (__tmp8Line != null) __out.Append(__tmp8Line);
                        StringBuilder __tmp9 = new StringBuilder();
                        __tmp9.Append(model.CSharpInstancesName(ClassKind.Builder));
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
                        string __tmp10Line = ".instance."; //1067:161
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
                        string __tmp12Line = ".ToImmutable();"; //1067:177
                        if (__tmp12Line != null) __out.Append(__tmp12Line);
                        __out.AppendLine(false); //1067:192
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelConstant(MetaModel model, MetaConstant mconst) //1073:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(GenerateDocumentation(mconst));
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
                    __out.AppendLine(false); //1074:32
                }
            }
            string __tmp4Line = "public readonly "; //1075:1
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(mconst.Type.CSharpFullName(ClassKind.Builder));
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
            string __tmp6Line = " "; //1075:64
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(mconst.Name);
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
            string __tmp8Line = ";"; //1075:78
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //1075:79
            return __out.ToString();
        }

        public string GenerateModelConstantImpl(MetaModel model, MetaConstant mconst, Dictionary<ModelObject,string> mobjToTmp) //1078:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(mconst.Name);
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
            string __tmp3Line = " = "; //1079:14
            if (__tmp3Line != null) __out.Append(__tmp3Line);
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(GenerateExpression(mconst.Value));
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
            string __tmp5Line = ";"; //1079:51
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            __out.AppendLine(false); //1079:52
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceDeclaration(ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //1082:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //1083:2
            {
                if (mobjToName.ContainsKey(mobj)) //1084:3
                {
                    string name = mobjToName[mobj]; //1085:4
                    if (name.StartsWith("__")) //1086:4
                    {
                        string __tmp2Line = "private readonly global::MetaDslx.Core.Immutable."; //1087:1
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
                        string __tmp4Line = " "; //1087:97
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
                        string __tmp6Line = ";"; //1087:104
                        if (__tmp6Line != null) __out.Append(__tmp6Line);
                        __out.AppendLine(false); //1087:105
                    }
                    else //1088:4
                    {
                        string __tmp8Line = "internal readonly global::MetaDslx.Core.Immutable."; //1089:1
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
                        string __tmp10Line = " "; //1089:98
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
                        string __tmp12Line = ";"; //1089:105
                        if (__tmp12Line != null) __out.Append(__tmp12Line);
                        __out.AppendLine(false); //1089:106
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstance(ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //1095:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //1096:2
            {
                if (mobjToName.ContainsKey(mobj)) //1097:3
                {
                    string name = mobjToName[mobj]; //1098:4
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
                    string __tmp3Line = " = factory."; //1099:7
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
                    string __tmp5Line = "();"; //1099:48
                    if (__tmp5Line != null) __out.Append(__tmp5Line);
                    __out.AppendLine(false); //1099:51
                    if (mobj is MetaModel) //1100:4
                    {
                        string __tmp7Line = "metaModel = "; //1101:1
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
                        string __tmp9Line = ";"; //1101:19
                        if (__tmp9Line != null) __out.Append(__tmp9Line);
                        __out.AppendLine(false); //1101:20
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceInitializer(bool coreModel, ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //1107:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //1108:2
            {
                if (mobjToName.ContainsKey(mobj)) //1109:3
                {
                    var __loop70_results = 
                        (from __loop70_var1 in __Enumerate((mobj).GetEnumerator()) //1110:9
                        from prop in __Enumerate((__loop70_var1.MGetProperties()).GetEnumerator()) //1110:15
                        where !prop.IsReadonly //1110:37
                        select new { __loop70_var1 = __loop70_var1, prop = prop}
                        ).ToList(); //1110:4
                    int __loop70_iteration = 0;
                    foreach (var __tmp1 in __loop70_results)
                    {
                        ++__loop70_iteration;
                        var __loop70_var1 = __tmp1.__loop70_var1;
                        var prop = __tmp1.prop;
                        if (prop.MetaProperty != null && prop.MetaProperty.Kind != MetaPropertyKind.Derived) //1111:5
                        {
                            object propValue = mobj.MGet(prop); //1112:6
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
                                    __out.AppendLine(false); //1113:81
                                }
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceFinalizer(ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //1120:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //1121:2
            {
                if (mobjToName.ContainsKey(mobj)) //1122:3
                {
                    string name = mobjToName[mobj]; //1123:4
                    string __tmp2Line = "((MetaDslx.Core.Immutable.MutableSymbolBase)"; //1124:1
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
                    string __tmp4Line = ").MMakeCreated();"; //1124:51
                    if (__tmp4Line != null) __out.Append(__tmp4Line);
                    __out.AppendLine(false); //1124:68
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectPropertyValue(bool coreModel, ModelObject mobj, ModelProperty prop, object value, Dictionary<ModelObject,string> mobjToName) //1129:1
        {
            StringBuilder __out = new StringBuilder();
            string name = mobjToName[mobj]; //1130:2
            ModelObject moValue = value as ModelObject; //1131:2
            if (value == null) //1132:2
            {
                if (prop.Type != null && prop.Type.IsClass) //1133:3
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
                    string __tmp3Line = "."; //1134:7
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
                    string __tmp5Line = " = null;"; //1134:19
                    if (__tmp5Line != null) __out.Append(__tmp5Line);
                    __out.AppendLine(false); //1134:27
                }
                else //1135:3
                {
                    string __tmp7Line = "// "; //1136:1
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
                    string __tmp9Line = "."; //1136:10
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
                    string __tmp11Line = " = null;"; //1136:22
                    if (__tmp11Line != null) __out.Append(__tmp11Line);
                    __out.AppendLine(false); //1136:30
                }
            }
            else if (value is string) //1138:2
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
                string __tmp14Line = "."; //1139:7
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
                string __tmp16Line = " = \""; //1139:19
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
                string __tmp18Line = "\";"; //1139:30
                if (__tmp18Line != null) __out.Append(__tmp18Line);
                __out.AppendLine(false); //1139:32
            }
            else if (value is bool) //1140:2
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
                string __tmp21Line = "."; //1141:7
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
                string __tmp23Line = " = "; //1141:19
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
                string __tmp25Line = ";"; //1141:50
                if (__tmp25Line != null) __out.Append(__tmp25Line);
                __out.AppendLine(false); //1141:51
            }
            else if (value.GetType().IsPrimitive) //1142:2
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
                string __tmp28Line = "."; //1143:7
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
                string __tmp30Line = " = "; //1143:19
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
                string __tmp32Line = ";"; //1143:40
                if (__tmp32Line != null) __out.Append(__tmp32Line);
                __out.AppendLine(false); //1143:41
            }
            else if (MetaBuiltInTypes.Types.Contains(value)) //1144:2
            {
                if (coreModel) //1145:3
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
                    string __tmp35Line = "."; //1146:7
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
                    string __tmp37Line = "Lazy = () => "; //1146:19
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
                    string __tmp39Line = ";"; //1146:53
                    if (__tmp39Line != null) __out.Append(__tmp39Line);
                    __out.AppendLine(false); //1146:54
                }
                else //1147:3
                {
                    StringBuilder __tmp41 = new StringBuilder();
                    __tmp41.Append(name);
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
                    string __tmp42Line = "."; //1148:7
                    if (__tmp42Line != null) __out.Append(__tmp42Line);
                    StringBuilder __tmp43 = new StringBuilder();
                    __tmp43.Append(prop.Name);
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
                    string __tmp44Line = " = "; //1148:19
                    if (__tmp44Line != null) __out.Append(__tmp44Line);
                    StringBuilder __tmp45 = new StringBuilder();
                    __tmp45.Append(GenerateTypeOf(value));
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
                    string __tmp46Line = ";"; //1148:45
                    if (__tmp46Line != null) __out.Append(__tmp46Line);
                    __out.AppendLine(false); //1148:46
                }
            }
            else if (value is MetaPrimitiveType) //1150:2
            {
                if (coreModel) //1151:3
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
                    string __tmp49Line = "."; //1152:7
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
                    string __tmp51Line = "Lazy = () => "; //1152:19
                    if (__tmp51Line != null) __out.Append(__tmp51Line);
                    StringBuilder __tmp52 = new StringBuilder();
                    __tmp52.Append(mobjToName[moValue]);
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
                    string __tmp53Line = ";"; //1152:53
                    if (__tmp53Line != null) __out.Append(__tmp53Line);
                    __out.AppendLine(false); //1152:54
                }
                else //1153:3
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
                    string __tmp56Line = "."; //1154:7
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
                    string __tmp58Line = " = "; //1154:19
                    if (__tmp58Line != null) __out.Append(__tmp58Line);
                    StringBuilder __tmp59 = new StringBuilder();
                    __tmp59.Append(GenerateTypeOf(value));
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
                    string __tmp60Line = ";"; //1154:45
                    if (__tmp60Line != null) __out.Append(__tmp60Line);
                    __out.AppendLine(false); //1154:46
                }
            }
            else if (value is Enum) //1156:2
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
                string __tmp63Line = "."; //1157:7
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
                string __tmp65Line = " = "; //1157:19
                if (__tmp65Line != null) __out.Append(__tmp65Line);
                StringBuilder __tmp66 = new StringBuilder();
                __tmp66.Append(GetEnumValueOf(value));
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
                string __tmp67Line = ";"; //1157:45
                if (__tmp67Line != null) __out.Append(__tmp67Line);
                __out.AppendLine(false); //1157:46
            }
            else if (moValue != null) //1158:2
            {
                if (mobjToName.ContainsKey(moValue)) //1159:3
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
                    string __tmp70Line = "."; //1160:7
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
                    string __tmp72Line = "Lazy = () => "; //1160:19
                    if (__tmp72Line != null) __out.Append(__tmp72Line);
                    StringBuilder __tmp73 = new StringBuilder();
                    __tmp73.Append(mobjToName[moValue]);
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
                    string __tmp74Line = ";"; //1160:53
                    if (__tmp74Line != null) __out.Append(__tmp74Line);
                    __out.AppendLine(false); //1160:54
                }
                else //1161:3
                {
                    string __tmp76Line = "// Omitted since not part of the model: "; //1162:1
                    if (__tmp76Line != null) __out.Append(__tmp76Line);
                    StringBuilder __tmp77 = new StringBuilder();
                    __tmp77.Append(name);
                    using(StreamReader __tmp77Reader = new StreamReader(this.__ToStream(__tmp77.ToString())))
                    {
                        bool __tmp77_first = true;
                        bool __tmp77_last = __tmp77Reader.EndOfStream;
                        while(__tmp77_first || !__tmp77_last)
                        {
                            __tmp77_first = false;
                            string __tmp77Line = __tmp77Reader.ReadLine();
                            __tmp77_last = __tmp77Reader.EndOfStream;
                            if (__tmp77Line != null) __out.Append(__tmp77Line);
                            if (!__tmp77_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp78Line = "."; //1162:47
                    if (__tmp78Line != null) __out.Append(__tmp78Line);
                    StringBuilder __tmp79 = new StringBuilder();
                    __tmp79.Append(prop.Name);
                    using(StreamReader __tmp79Reader = new StreamReader(this.__ToStream(__tmp79.ToString())))
                    {
                        bool __tmp79_first = true;
                        bool __tmp79_last = __tmp79Reader.EndOfStream;
                        while(__tmp79_first || !__tmp79_last)
                        {
                            __tmp79_first = false;
                            string __tmp79Line = __tmp79Reader.ReadLine();
                            __tmp79_last = __tmp79Reader.EndOfStream;
                            if (__tmp79Line != null) __out.Append(__tmp79Line);
                            if (!__tmp79_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp80Line = " = "; //1162:59
                    if (__tmp80Line != null) __out.Append(__tmp80Line);
                    StringBuilder __tmp81 = new StringBuilder();
                    __tmp81.Append(moValue);
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
                            __out.AppendLine(false); //1162:71
                        }
                    }
                }
            }
            else //1164:2
            {
                IEnumerable<object> mc = (value as ModelCollection) as IEnumerable<object>; //1165:3
                if (mc != null) //1166:3
                {
                    var __loop71_results = 
                        (from cvalue in __Enumerate((mc).GetEnumerator()) //1167:9
                        select new { cvalue = cvalue}
                        ).ToList(); //1167:4
                    int __loop71_iteration = 0;
                    foreach (var __tmp82 in __loop71_results)
                    {
                        ++__loop71_iteration;
                        var cvalue = __tmp82.cvalue;
                        StringBuilder __tmp84 = new StringBuilder();
                        __tmp84.Append(GenerateModelObjectPropertyCollectionValue(coreModel, mobj, prop, cvalue, mobjToName));
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
                                __out.AppendLine(false); //1168:88
                            }
                        }
                    }
                }
                else //1170:3
                {
                    string __tmp86Line = "// Invalid property value type: "; //1171:1
                    if (__tmp86Line != null) __out.Append(__tmp86Line);
                    StringBuilder __tmp87 = new StringBuilder();
                    __tmp87.Append(name);
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
                    string __tmp88Line = "."; //1171:39
                    if (__tmp88Line != null) __out.Append(__tmp88Line);
                    StringBuilder __tmp89 = new StringBuilder();
                    __tmp89.Append(prop.Name);
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
                    string __tmp90Line = " = "; //1171:51
                    if (__tmp90Line != null) __out.Append(__tmp90Line);
                    StringBuilder __tmp91 = new StringBuilder();
                    __tmp91.Append(value.GetType());
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
                            __out.AppendLine(false); //1171:71
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectPropertyCollectionValue(bool coreModel, ModelObject mobj, ModelProperty prop, object value, Dictionary<ModelObject,string> mobjToName) //1176:1
        {
            StringBuilder __out = new StringBuilder();
            string name = mobjToName[mobj]; //1177:2
            ModelObject moValue = value as ModelObject; //1178:2
            if (value == null) //1179:2
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
                string __tmp3Line = "."; //1180:7
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
                string __tmp5Line = ".Add(null);"; //1180:19
                if (__tmp5Line != null) __out.Append(__tmp5Line);
                __out.AppendLine(false); //1180:30
            }
            else if (value is string) //1181:2
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
                string __tmp8Line = "."; //1182:7
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
                string __tmp10Line = ".Add(\""; //1182:19
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
                string __tmp12Line = "\");"; //1182:32
                if (__tmp12Line != null) __out.Append(__tmp12Line);
                __out.AppendLine(false); //1182:35
            }
            else if (value is bool) //1183:2
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
                string __tmp15Line = "."; //1184:7
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
                string __tmp17Line = ".Add("; //1184:19
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
                string __tmp19Line = ");"; //1184:52
                if (__tmp19Line != null) __out.Append(__tmp19Line);
                __out.AppendLine(false); //1184:54
            }
            else if (value.GetType().IsPrimitive) //1185:2
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
                string __tmp22Line = "."; //1186:7
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
                string __tmp24Line = ".Add("; //1186:19
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
                string __tmp26Line = ");"; //1186:42
                if (__tmp26Line != null) __out.Append(__tmp26Line);
                __out.AppendLine(false); //1186:44
            }
            else if (MetaBuiltInTypes.Types.Contains(value)) //1187:2
            {
                if (coreModel) //1188:3
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
                    string __tmp29Line = "."; //1189:7
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
                    string __tmp31Line = ".AddLazy(() => "; //1189:19
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
                    string __tmp33Line = ");"; //1189:55
                    if (__tmp33Line != null) __out.Append(__tmp33Line);
                    __out.AppendLine(false); //1189:57
                }
                else //1190:3
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
                    string __tmp36Line = "."; //1191:7
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
                    string __tmp38Line = ".Add("; //1191:19
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
                    string __tmp40Line = ");"; //1191:47
                    if (__tmp40Line != null) __out.Append(__tmp40Line);
                    __out.AppendLine(false); //1191:49
                }
            }
            else if (value is MetaPrimitiveType) //1193:2
            {
                if (coreModel) //1194:3
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
                    string __tmp43Line = "."; //1195:7
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
                    string __tmp45Line = ".AddLazy(() => "; //1195:19
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
                    string __tmp47Line = ");"; //1195:55
                    if (__tmp47Line != null) __out.Append(__tmp47Line);
                    __out.AppendLine(false); //1195:57
                }
                else //1196:3
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
                    string __tmp50Line = "."; //1197:7
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
                    string __tmp52Line = ".Add("; //1197:19
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
                    string __tmp54Line = ");"; //1197:47
                    if (__tmp54Line != null) __out.Append(__tmp54Line);
                    __out.AppendLine(false); //1197:49
                }
            }
            else if (value is Enum) //1199:2
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
                string __tmp57Line = "."; //1200:7
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
                string __tmp59Line = ".Add("; //1200:19
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
                string __tmp61Line = ");"; //1200:47
                if (__tmp61Line != null) __out.Append(__tmp61Line);
                __out.AppendLine(false); //1200:49
            }
            else if (moValue != null) //1201:2
            {
                if (mobjToName.ContainsKey(moValue)) //1202:3
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
                    string __tmp64Line = "."; //1203:7
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
                    string __tmp66Line = ".AddLazy(() => "; //1203:19
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
                    string __tmp68Line = ");"; //1203:55
                    if (__tmp68Line != null) __out.Append(__tmp68Line);
                    __out.AppendLine(false); //1203:57
                }
                else //1204:3
                {
                    string __tmp70Line = "// Omitted since not part of the model: "; //1205:1
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
                    string __tmp72Line = "."; //1205:47
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
                    string __tmp74Line = " = "; //1205:59
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
                            __out.AppendLine(false); //1205:71
                        }
                    }
                }
            }
            else //1207:2
            {
                IEnumerable<object> mc = (value as ModelCollection) as IEnumerable<object>; //1208:3
                if (mc != null) //1209:3
                {
                    var __loop72_results = 
                        (from cvalue in __Enumerate((mc).GetEnumerator()) //1210:9
                        select new { cvalue = cvalue}
                        ).ToList(); //1210:4
                    int __loop72_iteration = 0;
                    foreach (var __tmp76 in __loop72_results)
                    {
                        ++__loop72_iteration;
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
                                __out.AppendLine(false); //1211:88
                            }
                        }
                    }
                }
                else //1213:3
                {
                    string __tmp80Line = "// Invalid property value type: "; //1214:1
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
                    string __tmp82Line = "."; //1214:39
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
                    string __tmp84Line = " = "; //1214:51
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
                            __out.AppendLine(false); //1214:71
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GetEnumValueOf(object enm) //1219:1
        {
            string result = "global::" + enm.GetType().FullName.Replace("+", ".") + "." + enm.ToString(); //1220:2
            if (!result.StartsWith("global::MetaDslx.Core.Immutable.") && result.StartsWith("global::MetaDslx.Core.")) //1221:2
            {
                result = result.Replace("global::MetaDslx.Core.", "global::MetaDslx.Core.Immutable."); //1222:3
            }
            return result; //1224:2
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
