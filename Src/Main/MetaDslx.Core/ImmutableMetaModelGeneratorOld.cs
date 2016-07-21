using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core //1:1
{
    using __Hidden_ImmutableMetaModelGenerator_1882172962;
    namespace __Hidden_ImmutableMetaModelGenerator_1882172962
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
            for (int __loop1_iteration = 0; __loop1_iteration < __loop1_results.Count; ++__loop1_iteration)
            {
                var __tmp1 = __loop1_results[__loop1_iteration];
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
            for (int __loop2_iteration = 0; __loop2_iteration < __loop2_results.Count; ++__loop2_iteration)
            {
                var __tmp6 = __loop2_results[__loop2_iteration];
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
            for (int __loop3_iteration = 0; __loop3_iteration < __loop3_results.Count; ++__loop3_iteration)
            {
                var __tmp9 = __loop3_results[__loop3_iteration];
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
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                var __tmp12 = __loop4_results[__loop4_iteration];
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
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                var __tmp15 = __loop5_results[__loop5_iteration];
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
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp18 = __loop6_results[__loop6_iteration];
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
                for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
                {
                    var __tmp1 = __loop7_results[__loop7_iteration];
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
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp1 = __loop8_results[__loop8_iteration];
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
            for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
            {
                var __tmp6 = __loop9_results[__loop9_iteration];
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
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                string delim; //77:30
                if (__loop10_iteration+1 < __loop10_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop10_results[__loop10_iteration];
                var __loop10_var1 = __tmp1.__loop10_var1;
                var super = __tmp1.super;
                result += super.CSharpFullName(classKind) + delim; //78:3
            }
            if (result == "" && classKind == ClassKind.Immutable) //80:2
            {
                result = "global::MetaDslx.Core.Immutable.ImmutableSymbol"; //81:3
            }
            if (result == "" && classKind == ClassKind.Builder) //83:2
            {
                result = "global::MetaDslx.Core.Immutable.MutableSymbol"; //84:3
            }
            if (result != "") //86:2
            {
                result = " : " + result; //87:3
            }
            return result; //89:2
        }

        public string GetDescriptorAncestors(MetaClass cls) //92:1
        {
            string result = ""; //93:2
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((cls).GetEnumerator()) //94:7
                from super in __Enumerate((__loop11_var1.SuperClasses).GetEnumerator()) //94:12
                select new { __loop11_var1 = __loop11_var1, super = super}
                ).ToList(); //94:2
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                string delim; //94:30
                if (__loop11_iteration+1 < __loop11_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop11_results[__loop11_iteration];
                var __loop11_var1 = __tmp1.__loop11_var1;
                var super = __tmp1.super;
                result += "typeof(" + super.CSharpFullDescriptorName(ClassKind.Immutable) + ")" + delim; //95:3
            }
            return result; //97:2
        }

        public string GenerateImmutableInterface(MetaClass cls) //100:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal class "; //101:1
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
            string __tmp4Line = "Id : global::MetaDslx.Core.Immutable.SymbolId"; //101:53
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //101:98
            __out.Append("{"); //102:1
            __out.AppendLine(false); //102:2
            string __tmp6Line = "	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return "; //103:1
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
            string __tmp8Line = "."; //103:131
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
            string __tmp10Line = ".ModelSymbolInfo; } }"; //103:150
            if (__tmp10Line != null) __out.Append(__tmp10Line);
            __out.AppendLine(false); //103:171
            string __tmp12Line = "    public override global::System.Type ImmutableType { get { return typeof("; //104:1
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
            string __tmp14Line = "); } }"; //104:114
            if (__tmp14Line != null) __out.Append(__tmp14Line);
            __out.AppendLine(false); //104:120
            string __tmp16Line = "    public override global::System.Type MutableType { get { return typeof("; //105:1
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
            string __tmp18Line = "); } }"; //105:110
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //105:116
            __out.AppendLine(true); //106:1
            __out.Append("    public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)"); //107:1
            __out.AppendLine(false); //107:142
            __out.Append("    {"); //108:1
            __out.AppendLine(false); //108:6
            string __tmp20Line = "        return new "; //109:1
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
            string __tmp22Line = "(this, model);"; //109:61
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            __out.AppendLine(false); //109:75
            __out.Append("    }"); //110:1
            __out.AppendLine(false); //110:6
            __out.AppendLine(true); //111:1
            __out.Append("    public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)"); //112:1
            __out.AppendLine(false); //112:151
            __out.Append("    {"); //113:1
            __out.AppendLine(false); //113:6
            string __tmp24Line = "        return new "; //114:1
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
            string __tmp26Line = "(this, model, creating);"; //114:59
            if (__tmp26Line != null) __out.Append(__tmp26Line);
            __out.AppendLine(false); //114:83
            __out.Append("    }"); //115:1
            __out.AppendLine(false); //115:6
            __out.Append("}"); //116:1
            __out.AppendLine(false); //116:2
            __out.AppendLine(true); //117:1
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
                    __out.AppendLine(false); //118:27
                }
            }
            string __tmp30Line = "public interface "; //119:1
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
                    __out.AppendLine(false); //119:95
                }
            }
            __out.Append("{"); //120:1
            __out.AppendLine(false); //120:2
            var __loop12_results = 
                (from __loop12_var1 in __Enumerate((cls).GetEnumerator()) //121:11
                from prop in __Enumerate((__loop12_var1.Properties).GetEnumerator()) //121:16
                select new { __loop12_var1 = __loop12_var1, prop = prop}
                ).ToList(); //121:6
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp33 = __loop12_results[__loop12_iteration];
                var __loop12_var1 = __tmp33.__loop12_var1;
                var prop = __tmp33.prop;
                string __tmp34Prefix = "    "; //122:1
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
                        __out.AppendLine(false); //122:38
                    }
                }
            }
            __out.AppendLine(true); //124:1
            var __loop13_results = 
                (from __loop13_var1 in __Enumerate((cls).GetEnumerator()) //125:11
                from op in __Enumerate((__loop13_var1.Operations).GetEnumerator()) //125:16
                select new { __loop13_var1 = __loop13_var1, op = op}
                ).ToList(); //125:6
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp36 = __loop13_results[__loop13_iteration];
                var __loop13_var1 = __tmp36.__loop13_var1;
                var op = __tmp36.op;
                string __tmp37Prefix = "    "; //126:1
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
                        __out.AppendLine(false); //126:28
                    }
                }
            }
            __out.AppendLine(true); //128:1
            string __tmp40Line = "	new "; //129:1
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
            string __tmp42Line = " ToMutable();"; //129:41
            if (__tmp42Line != null) __out.Append(__tmp42Line);
            __out.AppendLine(false); //129:54
            string __tmp44Line = "	new "; //130:1
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
            string __tmp46Line = " ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);"; //130:41
            if (__tmp46Line != null) __out.Append(__tmp46Line);
            __out.AppendLine(false); //130:104
            __out.Append("}"); //131:1
            __out.AppendLine(false); //131:2
            __out.AppendLine(true); //132:1
            return __out.ToString();
        }

        public string GenerateBuilderInterface(MetaClass cls) //135:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "public interface "; //136:1
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
                    __out.AppendLine(false); //136:91
                }
            }
            __out.Append("{"); //137:1
            __out.AppendLine(false); //137:2
            var __loop14_results = 
                (from __loop14_var1 in __Enumerate((cls).GetEnumerator()) //138:11
                from prop in __Enumerate((__loop14_var1.Properties).GetEnumerator()) //138:16
                select new { __loop14_var1 = __loop14_var1, prop = prop}
                ).ToList(); //138:6
            for (int __loop14_iteration = 0; __loop14_iteration < __loop14_results.Count; ++__loop14_iteration)
            {
                var __tmp5 = __loop14_results[__loop14_iteration];
                var __loop14_var1 = __tmp5.__loop14_var1;
                var prop = __tmp5.prop;
                string __tmp6Prefix = "    "; //139:1
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
                        __out.AppendLine(false); //139:36
                    }
                }
            }
            __out.AppendLine(true); //141:1
            string __tmp9Line = "	new "; //142:1
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
            string __tmp11Line = " ToImmutable();"; //142:43
            if (__tmp11Line != null) __out.Append(__tmp11Line);
            __out.AppendLine(false); //142:58
            string __tmp13Line = "	new "; //143:1
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
            string __tmp15Line = " ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);"; //143:43
            if (__tmp15Line != null) __out.Append(__tmp15Line);
            __out.AppendLine(false); //143:110
            __out.Append("}"); //144:1
            __out.AppendLine(false); //144:2
            __out.AppendLine(true); //145:1
            return __out.ToString();
        }

        public string GenerateImmutableProperty(MetaProperty prop) //148:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //149:2
            {
                __out.Append("new "); //150:1
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
            string __tmp3Line = " "; //152:54
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
            string __tmp5Line = " { get; }"; //152:66
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            __out.AppendLine(false); //152:75
            return __out.ToString();
        }

        public string GenerateImmutableField(MetaClass cls, MetaProperty prop) //155:1
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
                    __out.AppendLine(false); //156:54
                }
            }
            string __tmp4Line = "private "; //157:1
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
            string __tmp6Line = " "; //157:62
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
            string __tmp8Line = ";"; //157:87
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //157:88
            return __out.ToString();
        }

        public string GenerateBuilderProperty(MetaProperty prop) //160:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //161:2
            {
                __out.Append("new "); //162:1
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //164:3
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
                string __tmp3Line = " "; //165:52
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
                string __tmp5Line = " { get; set; }"; //165:64
                if (__tmp5Line != null) __out.Append(__tmp5Line);
                __out.AppendLine(false); //165:78
            }
            else //166:3
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
                string __tmp8Line = " "; //167:52
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
                string __tmp10Line = " { get; }"; //167:64
                if (__tmp10Line != null) __out.Append(__tmp10Line);
                __out.AppendLine(false); //167:73
            }
            if (!(prop.Type is MetaCollectionType)) //169:2
            {
                if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //170:3
                {
                    __out.Append("new "); //171:1
                }
                string __tmp12Line = "Func<"; //173:1
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
                string __tmp14Line = "> "; //173:57
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
                string __tmp16Line = "Lazy { get; set; }"; //173:70
                if (__tmp16Line != null) __out.Append(__tmp16Line);
                __out.AppendLine(false); //173:88
            }
            if (prop.Kind == MetaPropertyKind.Containment && (((prop.Type is MetaCollectionType) && (((MetaCollectionType)prop.Type).InnerType is MetaClass)) || (!(prop.Type is MetaCollectionType) && prop.Type is MetaClass))) //175:2
            {
                if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //176:3
                {
                    __out.Append("new "); //177:1
                }
            }
            return __out.ToString();
        }

        public string GenerateBuilderField(MetaClass cls, MetaProperty prop) //182:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "private "; //183:1
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
            string __tmp4Line = " "; //183:60
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
            string __tmp6Line = ";"; //183:85
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            __out.AppendLine(false); //183:86
            return __out.ToString();
        }

        public string GetParameters(MetaFunction op, ClassKind classKind) //186:1
        {
            string result = ""; //187:2
            var __loop15_results = 
                (from __loop15_var1 in __Enumerate((op).GetEnumerator()) //188:7
                from param in __Enumerate((__loop15_var1.Parameters).GetEnumerator()) //188:11
                select new { __loop15_var1 = __loop15_var1, param = param}
                ).ToList(); //188:2
            for (int __loop15_iteration = 0; __loop15_iteration < __loop15_results.Count; ++__loop15_iteration)
            {
                string delim; //188:27
                if (__loop15_iteration+1 < __loop15_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop15_results[__loop15_iteration];
                var __loop15_var1 = __tmp1.__loop15_var1;
                var param = __tmp1.param;
                result += param.Type.CSharpFullPublicName(classKind) + " " + param.Name + delim; //189:3
            }
            return result; //191:2
        }

        public string GetImplParameters(MetaClass cls, MetaOperation op) //194:1
        {
            string result = cls.CSharpFullName(ClassKind.Immutable) + " _this"; //195:2
            string delim = ", "; //196:2
            var __loop16_results = 
                (from __loop16_var1 in __Enumerate((op).GetEnumerator()) //197:7
                from param in __Enumerate((__loop16_var1.Parameters).GetEnumerator()) //197:11
                select new { __loop16_var1 = __loop16_var1, param = param}
                ).ToList(); //197:2
            for (int __loop16_iteration = 0; __loop16_iteration < __loop16_results.Count; ++__loop16_iteration)
            {
                var __tmp1 = __loop16_results[__loop16_iteration];
                var __loop16_var1 = __tmp1.__loop16_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(ClassKind.Immutable) + " " + param.Name; //198:3
            }
            return result; //200:2
        }

        public string GetImplParameters(MetaEnum enm, MetaOperation op) //203:1
        {
            string result = enm.CSharpFullName(ClassKind.Immutable) + " _this"; //204:2
            string delim = ", "; //205:2
            var __loop17_results = 
                (from __loop17_var1 in __Enumerate((op).GetEnumerator()) //206:7
                from param in __Enumerate((__loop17_var1.Parameters).GetEnumerator()) //206:11
                select new { __loop17_var1 = __loop17_var1, param = param}
                ).ToList(); //206:2
            for (int __loop17_iteration = 0; __loop17_iteration < __loop17_results.Count; ++__loop17_iteration)
            {
                var __tmp1 = __loop17_results[__loop17_iteration];
                var __loop17_var1 = __tmp1.__loop17_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(ClassKind.Immutable) + " " + param.Name; //207:3
            }
            return result; //209:2
        }

        public string GetEnumImplParameters(MetaEnum enm, MetaOperation op) //212:1
        {
            string result = "this " + enm.CSharpFullName(ClassKind.Immutable) + " _this"; //213:2
            string delim = ", "; //214:2
            var __loop18_results = 
                (from __loop18_var1 in __Enumerate((op).GetEnumerator()) //215:7
                from param in __Enumerate((__loop18_var1.Parameters).GetEnumerator()) //215:11
                select new { __loop18_var1 = __loop18_var1, param = param}
                ).ToList(); //215:2
            for (int __loop18_iteration = 0; __loop18_iteration < __loop18_results.Count; ++__loop18_iteration)
            {
                var __tmp1 = __loop18_results[__loop18_iteration];
                var __loop18_var1 = __tmp1.__loop18_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(ClassKind.Immutable) + " " + param.Name; //216:3
            }
            return result; //218:2
        }

        public string GetEnumImplCallParameterNames(MetaOperation op) //221:1
        {
            string result = "_this"; //222:2
            string delim = ", "; //223:2
            var __loop19_results = 
                (from __loop19_var1 in __Enumerate((op).GetEnumerator()) //224:7
                from param in __Enumerate((__loop19_var1.Parameters).GetEnumerator()) //224:11
                select new { __loop19_var1 = __loop19_var1, param = param}
                ).ToList(); //224:2
            for (int __loop19_iteration = 0; __loop19_iteration < __loop19_results.Count; ++__loop19_iteration)
            {
                var __tmp1 = __loop19_results[__loop19_iteration];
                var __loop19_var1 = __tmp1.__loop19_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //225:3
            }
            return result; //227:2
        }

        public string GetImplCallParameterNames(MetaOperation op) //230:1
        {
            string result = "this"; //231:2
            string delim = ", "; //232:2
            var __loop20_results = 
                (from __loop20_var1 in __Enumerate((op).GetEnumerator()) //233:7
                from param in __Enumerate((__loop20_var1.Parameters).GetEnumerator()) //233:11
                select new { __loop20_var1 = __loop20_var1, param = param}
                ).ToList(); //233:2
            for (int __loop20_iteration = 0; __loop20_iteration < __loop20_results.Count; ++__loop20_iteration)
            {
                var __tmp1 = __loop20_results[__loop20_iteration];
                var __loop20_var1 = __tmp1.__loop20_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //234:3
            }
            return result; //236:2
        }

        public string GenerateOperation(MetaOperation op) //239:1
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
            string __tmp3Line = " "; //240:58
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
            string __tmp5Line = "("; //240:68
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
            string __tmp7Line = ");"; //240:109
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //240:111
            return __out.ToString();
        }

        public string GenerateImmutableInterfaceImpl(MetaModel model, MetaClass cls) //243:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal class "; //244:1
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
            string __tmp4Line = " : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, "; //244:57
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
                    __out.AppendLine(false); //244:154
                }
            }
            __out.Append("{"); //245:1
            __out.AppendLine(false); //245:2
            var __loop21_results = 
                (from __loop21_var1 in __Enumerate((cls).GetEnumerator()) //246:11
                from prop in __Enumerate((__loop21_var1.GetAllProperties()).GetEnumerator()) //246:16
                select new { __loop21_var1 = __loop21_var1, prop = prop}
                ).ToList(); //246:6
            for (int __loop21_iteration = 0; __loop21_iteration < __loop21_results.Count; ++__loop21_iteration)
            {
                var __tmp6 = __loop21_results[__loop21_iteration];
                var __loop21_var1 = __tmp6.__loop21_var1;
                var prop = __tmp6.prop;
                string __tmp7Prefix = "    "; //247:1
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
                        __out.AppendLine(false); //247:40
                    }
                }
            }
            __out.AppendLine(true); //249:1
            string __tmp10Line = "    internal "; //250:1
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
            string __tmp12Line = "(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)"; //250:36
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //250:135
            __out.Append("		: base(id, model)"); //251:1
            __out.AppendLine(false); //251:20
            __out.Append("    {"); //252:1
            __out.AppendLine(false); //252:6
            __out.Append("    }"); //253:1
            __out.AppendLine(false); //253:6
            __out.AppendLine(true); //254:1
            __out.Append("    public override object MMetaModel"); //255:1
            __out.AppendLine(false); //255:38
            __out.Append("    {"); //256:1
            __out.AppendLine(false); //256:6
            string __tmp14Line = "        get { return null;/*"; //257:1
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
            string __tmp16Line = ";*/ }"; //257:65
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            __out.AppendLine(false); //257:70
            __out.Append("    }"); //258:1
            __out.AppendLine(false); //258:6
            __out.AppendLine(true); //259:1
            __out.Append("    public override object MMetaClass"); //260:1
            __out.AppendLine(false); //260:38
            __out.Append("    {"); //261:1
            __out.AppendLine(false); //261:6
            string __tmp18Line = "        get { return null; /*"; //262:1
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
            string __tmp20Line = ";*/ }"; //262:60
            if (__tmp20Line != null) __out.Append(__tmp20Line);
            __out.AppendLine(false); //262:65
            __out.Append("    }"); //263:1
            __out.AppendLine(false); //263:6
            __out.AppendLine(true); //264:1
            string __tmp22Line = "    public new "; //265:1
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
            string __tmp24Line = " ToMutable()"; //265:55
            if (__tmp24Line != null) __out.Append(__tmp24Line);
            __out.AppendLine(false); //265:67
            __out.Append("	{"); //266:1
            __out.AppendLine(false); //266:3
            string __tmp26Line = "		return ("; //267:1
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
            string __tmp28Line = ")base.ToMutable();"; //267:50
            if (__tmp28Line != null) __out.Append(__tmp28Line);
            __out.AppendLine(false); //267:68
            __out.Append("	}"); //268:1
            __out.AppendLine(false); //268:3
            __out.AppendLine(true); //269:1
            string __tmp30Line = "    public new "; //270:1
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
            string __tmp32Line = " ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)"; //270:55
            if (__tmp32Line != null) __out.Append(__tmp32Line);
            __out.AppendLine(false); //270:117
            __out.Append("	{"); //271:1
            __out.AppendLine(false); //271:3
            string __tmp34Line = "		return ("; //272:1
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
            string __tmp36Line = ")base.ToMutable(model);"; //272:50
            if (__tmp36Line != null) __out.Append(__tmp36Line);
            __out.AppendLine(false); //272:73
            __out.Append("	}"); //273:1
            __out.AppendLine(false); //273:3
            var __loop22_results = 
                (from __loop22_var1 in __Enumerate((cls).GetEnumerator()) //274:8
                from sup in __Enumerate((__loop22_var1.GetAllSuperClasses()).GetEnumerator()) //274:13
                select new { __loop22_var1 = __loop22_var1, sup = sup}
                ).ToList(); //274:3
            for (int __loop22_iteration = 0; __loop22_iteration < __loop22_results.Count; ++__loop22_iteration)
            {
                var __tmp37 = __loop22_results[__loop22_iteration];
                var __loop22_var1 = __tmp37.__loop22_var1;
                var sup = __tmp37.sup;
                __out.AppendLine(true); //275:1
                string __tmp38Prefix = "    "; //276:1
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
                string __tmp40Line = " "; //276:44
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
                string __tmp42Line = ".ToMutable()"; //276:86
                if (__tmp42Line != null) __out.Append(__tmp42Line);
                __out.AppendLine(false); //276:98
                __out.Append("	{"); //277:1
                __out.AppendLine(false); //277:3
                __out.Append("		return this.ToMutable();"); //278:1
                __out.AppendLine(false); //278:27
                __out.Append("	}"); //279:1
                __out.AppendLine(false); //279:3
                __out.AppendLine(true); //280:1
                string __tmp43Prefix = "    "; //281:1
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
                string __tmp45Line = " "; //281:44
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
                string __tmp47Line = ".ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)"; //281:86
                if (__tmp47Line != null) __out.Append(__tmp47Line);
                __out.AppendLine(false); //281:148
                __out.Append("	{"); //282:1
                __out.AppendLine(false); //282:3
                __out.Append("		return this.ToMutable(model);"); //283:1
                __out.AppendLine(false); //283:32
                __out.Append("	}"); //284:1
                __out.AppendLine(false); //284:3
            }
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((cls).GetEnumerator()) //286:11
                from prop in __Enumerate((__loop23_var1.GetAllProperties()).GetEnumerator()) //286:16
                select new { __loop23_var1 = __loop23_var1, prop = prop}
                ).ToList(); //286:6
            for (int __loop23_iteration = 0; __loop23_iteration < __loop23_results.Count; ++__loop23_iteration)
            {
                var __tmp48 = __loop23_results[__loop23_iteration];
                var __loop23_var1 = __tmp48.__loop23_var1;
                var prop = __tmp48.prop;
                __out.AppendLine(true); //287:1
                string __tmp49Prefix = "    "; //288:1
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
                        __out.AppendLine(false); //288:54
                    }
                }
            }
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((cls).GetEnumerator()) //290:11
                from op in __Enumerate((__loop24_var1.GetAllOperations()).GetEnumerator()) //290:16
                select new { __loop24_var1 = __loop24_var1, op = op}
                ).ToList(); //290:6
            for (int __loop24_iteration = 0; __loop24_iteration < __loop24_results.Count; ++__loop24_iteration)
            {
                var __tmp51 = __loop24_results[__loop24_iteration];
                var __loop24_var1 = __tmp51.__loop24_var1;
                var op = __tmp51.op;
                __out.AppendLine(true); //291:1
                string __tmp52Prefix = "    "; //292:1
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
                        __out.AppendLine(false); //292:39
                    }
                }
            }
            __out.Append("}"); //294:1
            __out.AppendLine(false); //294:2
            __out.AppendLine(true); //295:1
            return __out.ToString();
        }

        public string GenerateBuilderInterfaceImpl(MetaModel model, MetaClass cls) //298:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal class "; //299:1
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
            string __tmp4Line = " : global::MetaDslx.Core.Immutable.MutableSymbolBase, "; //299:55
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
                    __out.AppendLine(false); //299:148
                }
            }
            __out.Append("{"); //300:1
            __out.AppendLine(false); //300:2
            var __loop25_results = 
                (from __loop25_var1 in __Enumerate((cls).GetEnumerator()) //301:11
                from prop in __Enumerate((__loop25_var1.GetAllProperties()).GetEnumerator()) //301:16
                where prop.Type is MetaCollectionType //301:40
                select new { __loop25_var1 = __loop25_var1, prop = prop}
                ).ToList(); //301:6
            for (int __loop25_iteration = 0; __loop25_iteration < __loop25_results.Count; ++__loop25_iteration)
            {
                var __tmp6 = __loop25_results[__loop25_iteration];
                var __loop25_var1 = __tmp6.__loop25_var1;
                var prop = __tmp6.prop;
                string __tmp7Prefix = "    "; //302:1
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
                        __out.AppendLine(false); //302:38
                    }
                }
            }
            __out.AppendLine(true); //304:1
            string __tmp10Line = "    internal "; //305:1
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
            string __tmp12Line = "(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)"; //305:53
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //305:165
            __out.Append("		: base(id, model, creating)"); //306:1
            __out.AppendLine(false); //306:30
            __out.Append("    {"); //307:1
            __out.AppendLine(false); //307:6
            __out.Append("    }"); //308:1
            __out.AppendLine(false); //308:6
            __out.AppendLine(true); //309:1
            __out.Append("    internal protected override void MInit()"); //310:1
            __out.AppendLine(false); //310:45
            __out.Append("    {"); //311:1
            __out.AppendLine(false); //311:6
            var __loop26_results = 
                (from __loop26_var1 in __Enumerate((cls).GetEnumerator()) //312:9
                from sup in __Enumerate((__loop26_var1.GetAllSuperClasses(false)).GetEnumerator()) //312:14
                select new { __loop26_var1 = __loop26_var1, sup = sup}
                ).ToList(); //312:4
            for (int __loop26_iteration = 0; __loop26_iteration < __loop26_results.Count; ++__loop26_iteration)
            {
                var __tmp13 = __loop26_results[__loop26_iteration];
                var __loop26_var1 = __tmp13.__loop26_var1;
                var sup = __tmp13.sup;
                string __tmp14Prefix = "		"; //313:1
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
                string __tmp16Line = "ImplementationProvider.Implementation."; //313:19
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
                string __tmp18Line = "(this);"; //313:75
                if (__tmp18Line != null) __out.Append(__tmp18Line);
                __out.AppendLine(false); //313:82
            }
            string __tmp19Prefix = "		"; //315:1
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
            string __tmp21Line = "ImplementationProvider.Implementation."; //315:15
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
            string __tmp23Line = "(this);"; //315:71
            if (__tmp23Line != null) __out.Append(__tmp23Line);
            __out.AppendLine(false); //315:78
            __out.Append("    }"); //316:1
            __out.AppendLine(false); //316:6
            __out.AppendLine(true); //317:1
            __out.Append("    public override object MMetaModel"); //318:1
            __out.AppendLine(false); //318:38
            __out.Append("    {"); //319:1
            __out.AppendLine(false); //319:6
            string __tmp25Line = "        get { return null;/*"; //320:1
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
            string __tmp27Line = ";*/ }"; //320:65
            if (__tmp27Line != null) __out.Append(__tmp27Line);
            __out.AppendLine(false); //320:70
            __out.Append("    }"); //321:1
            __out.AppendLine(false); //321:6
            __out.AppendLine(true); //322:1
            __out.Append("    public override object MMetaClass"); //323:1
            __out.AppendLine(false); //323:38
            __out.Append("    {"); //324:1
            __out.AppendLine(false); //324:6
            string __tmp29Line = "        get { return null;/*"; //325:1
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
            string __tmp31Line = ";*/ }"; //325:59
            if (__tmp31Line != null) __out.Append(__tmp31Line);
            __out.AppendLine(false); //325:64
            __out.Append("    }"); //326:1
            __out.AppendLine(false); //326:6
            __out.AppendLine(true); //327:1
            string __tmp33Line = "    public new "; //328:1
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
            string __tmp35Line = " ToImmutable()"; //328:57
            if (__tmp35Line != null) __out.Append(__tmp35Line);
            __out.AppendLine(false); //328:71
            __out.Append("	{"); //329:1
            __out.AppendLine(false); //329:3
            string __tmp37Line = "		return ("; //330:1
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
            string __tmp39Line = ")base.ToImmutable();"; //330:52
            if (__tmp39Line != null) __out.Append(__tmp39Line);
            __out.AppendLine(false); //330:72
            __out.Append("	}"); //331:1
            __out.AppendLine(false); //331:3
            __out.AppendLine(true); //332:1
            string __tmp41Line = "    public new "; //333:1
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
            string __tmp43Line = " ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)"; //333:57
            if (__tmp43Line != null) __out.Append(__tmp43Line);
            __out.AppendLine(false); //333:123
            __out.Append("	{"); //334:1
            __out.AppendLine(false); //334:3
            string __tmp45Line = "		return ("; //335:1
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
            string __tmp47Line = ")base.ToImmutable(model);"; //335:52
            if (__tmp47Line != null) __out.Append(__tmp47Line);
            __out.AppendLine(false); //335:77
            __out.Append("	}"); //336:1
            __out.AppendLine(false); //336:3
            var __loop27_results = 
                (from __loop27_var1 in __Enumerate((cls).GetEnumerator()) //337:8
                from sup in __Enumerate((__loop27_var1.GetAllSuperClasses()).GetEnumerator()) //337:13
                select new { __loop27_var1 = __loop27_var1, sup = sup}
                ).ToList(); //337:3
            for (int __loop27_iteration = 0; __loop27_iteration < __loop27_results.Count; ++__loop27_iteration)
            {
                var __tmp48 = __loop27_results[__loop27_iteration];
                var __loop27_var1 = __tmp48.__loop27_var1;
                var sup = __tmp48.sup;
                __out.AppendLine(true); //338:1
                string __tmp49Prefix = "    "; //339:1
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
                string __tmp51Line = " "; //339:46
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
                string __tmp53Line = ".ToImmutable()"; //339:86
                if (__tmp53Line != null) __out.Append(__tmp53Line);
                __out.AppendLine(false); //339:100
                __out.Append("	{"); //340:1
                __out.AppendLine(false); //340:3
                __out.Append("		return this.ToImmutable();"); //341:1
                __out.AppendLine(false); //341:29
                __out.Append("	}"); //342:1
                __out.AppendLine(false); //342:3
                __out.AppendLine(true); //343:1
                string __tmp54Prefix = "    "; //344:1
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
                string __tmp56Line = " "; //344:46
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
                string __tmp58Line = ".ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)"; //344:86
                if (__tmp58Line != null) __out.Append(__tmp58Line);
                __out.AppendLine(false); //344:152
                __out.Append("	{"); //345:1
                __out.AppendLine(false); //345:3
                __out.Append("		return this.ToImmutable(model);"); //346:1
                __out.AppendLine(false); //346:34
                __out.Append("	}"); //347:1
                __out.AppendLine(false); //347:3
            }
            var __loop28_results = 
                (from __loop28_var1 in __Enumerate((cls).GetEnumerator()) //349:11
                from prop in __Enumerate((__loop28_var1.GetAllProperties()).GetEnumerator()) //349:16
                select new { __loop28_var1 = __loop28_var1, prop = prop}
                ).ToList(); //349:6
            for (int __loop28_iteration = 0; __loop28_iteration < __loop28_results.Count; ++__loop28_iteration)
            {
                var __tmp59 = __loop28_results[__loop28_iteration];
                var __loop28_var1 = __tmp59.__loop28_var1;
                var prop = __tmp59.prop;
                __out.AppendLine(true); //350:1
                string __tmp60Prefix = "    "; //351:1
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
                        __out.AppendLine(false); //351:52
                    }
                }
            }
            __out.Append("}"); //353:1
            __out.AppendLine(false); //353:2
            __out.AppendLine(true); //354:1
            return __out.ToString();
        }

        public string GeneratePropertyDeclaration(MetaModel model, MetaClass cls, MetaProperty prop) //357:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class == cls) //358:2
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
                        __out.AppendLine(false); //359:28
                    }
                }
                if (prop.Kind == MetaPropertyKind.Containment) //360:2
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
                            __out.AppendLine(false); //361:27
                        }
                    }
                }
                if (prop.Kind != MetaPropertyKind.Normal && prop.Kind != MetaPropertyKind.Containment) //363:2
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
                            __out.AppendLine(false); //364:24
                        }
                    }
                }
                var __loop29_results = 
                    (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //366:7
                    select new { p = p}
                    ).ToList(); //366:2
                for (int __loop29_iteration = 0; __loop29_iteration < __loop29_results.Count; ++__loop29_iteration)
                {
                    var __tmp7 = __loop29_results[__loop29_iteration];
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
                            __out.AppendLine(false); //367:111
                        }
                    }
                }
                var __loop30_results = 
                    (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //369:7
                    select new { p = p}
                    ).ToList(); //369:2
                for (int __loop30_iteration = 0; __loop30_iteration < __loop30_results.Count; ++__loop30_iteration)
                {
                    var __tmp14 = __loop30_results[__loop30_iteration];
                    var p = __tmp14.p;
                    if (cls.GetAllSuperClasses(true).Contains(p.Class)) //370:3
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
                                __out.AppendLine(false); //371:110
                            }
                        }
                    }
                    else //372:3
                    {
                        string __tmp22Line = "// ERROR: subsetted property '"; //373:1
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
                        string __tmp24Line = "' must be a property of an ancestor class"; //373:80
                        if (__tmp24Line != null) __out.Append(__tmp24Line);
                        __out.AppendLine(false); //373:121
                    }
                }
                var __loop31_results = 
                    (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //376:7
                    select new { p = p}
                    ).ToList(); //376:2
                for (int __loop31_iteration = 0; __loop31_iteration < __loop31_results.Count; ++__loop31_iteration)
                {
                    var __tmp25 = __loop31_results[__loop31_iteration];
                    var p = __tmp25.p;
                    if (cls.GetAllSuperClasses(true).Contains(p.Class)) //377:3
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
                                __out.AppendLine(false); //378:112
                            }
                        }
                    }
                    else //379:3
                    {
                        string __tmp33Line = "// ERROR: redefined property '"; //380:1
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
                        string __tmp35Line = "' must be a property of an ancestor class"; //380:80
                        if (__tmp35Line != null) __out.Append(__tmp35Line);
                        __out.AppendLine(false); //380:121
                    }
                }
                if (prop.Type is MetaCollectionType) //383:2
                {
                    MetaCollectionType collType = (MetaCollectionType)prop.Type; //384:3
                    string __tmp37Line = "public static readonly global::MetaDslx.Core.Immutable.ModelProperty "; //385:1
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
                    string __tmp39Line = "Property ="; //385:81
                    if (__tmp39Line != null) __out.Append(__tmp39Line);
                    __out.AppendLine(false); //385:91
                    string __tmp41Line = "    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof("; //386:1
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
                    string __tmp43Line = "."; //386:108
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
                    string __tmp45Line = "), \""; //386:134
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
                    string __tmp47Line = "\","; //386:149
                    if (__tmp47Line != null) __out.Append(__tmp47Line);
                    __out.AppendLine(false); //386:151
                    string __tmp49Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //387:1
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
                    string __tmp51Line = "), typeof("; //387:136
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
                    string __tmp53Line = ")),"; //387:199
                    if (__tmp53Line != null) __out.Append(__tmp53Line);
                    __out.AppendLine(false); //387:202
                    string __tmp55Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //388:1
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
                    string __tmp57Line = "), typeof("; //388:134
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
                    string __tmp59Line = ")));"; //388:195
                    if (__tmp59Line != null) __out.Append(__tmp59Line);
                    __out.AppendLine(false); //388:199
                }
                else //389:2
                {
                    string __tmp61Line = "public static readonly global::MetaDslx.Core.Immutable.ModelProperty "; //390:1
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
                    string __tmp63Line = "Property ="; //390:81
                    if (__tmp63Line != null) __out.Append(__tmp63Line);
                    __out.AppendLine(false); //390:91
                    string __tmp65Line = "    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof("; //391:1
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
                    string __tmp67Line = "."; //391:108
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
                    string __tmp69Line = "), \""; //391:134
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
                    string __tmp71Line = "\","; //391:149
                    if (__tmp71Line != null) __out.Append(__tmp71Line);
                    __out.AppendLine(false); //391:151
                    string __tmp73Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //392:1
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
                    string __tmp75Line = "), null),"; //392:127
                    if (__tmp75Line != null) __out.Append(__tmp75Line);
                    __out.AppendLine(false); //392:136
                    string __tmp77Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //393:1
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
                    string __tmp79Line = "), null));"; //393:125
                    if (__tmp79Line != null) __out.Append(__tmp79Line);
                    __out.AppendLine(false); //393:135
                }
            }
            __out.AppendLine(true); //396:1
            return __out.ToString();
        }

        public string GenerateImmutablePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //399:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //400:1
            if (cls.GetAllFinalProperties().Contains(prop)) //401:2
            {
                string __tmp2Line = "public "; //402:1
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
                string __tmp4Line = " "; //402:61
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
                        __out.AppendLine(false); //402:73
                    }
                }
            }
            else //403:2
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
                        __out.AppendLine(false); //404:54
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
                string __tmp10Line = " "; //405:54
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
                string __tmp12Line = "."; //405:103
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
                        __out.AppendLine(false); //405:115
                    }
                }
            }
            __out.Append("{"); //407:1
            __out.AppendLine(false); //407:2
            if (prop.Type is MetaCollectionType) //408:6
            {
                string __tmp15Line = "    get { return this.GetList<"; //409:1
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
                string __tmp17Line = ">("; //409:116
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
                string __tmp19Line = ", ref "; //409:170
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
                string __tmp21Line = "); }"; //409:200
                if (__tmp21Line != null) __out.Append(__tmp21Line);
                __out.AppendLine(false); //409:204
            }
            else if (prop.Type.IsReferenceType()) //410:3
            {
                string __tmp23Line = "    get { return this.GetReference<"; //411:1
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
                string __tmp25Line = ">("; //411:89
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
                string __tmp27Line = ", ref "; //411:143
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
                string __tmp29Line = "); }"; //411:173
                if (__tmp29Line != null) __out.Append(__tmp29Line);
                __out.AppendLine(false); //411:177
            }
            else //412:3
            {
                string __tmp31Line = "    get { return this.GetValue<"; //413:1
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
                string __tmp33Line = ">("; //413:85
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
                string __tmp35Line = ", ref "; //413:139
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
                string __tmp37Line = "); }"; //413:169
                if (__tmp37Line != null) __out.Append(__tmp37Line);
                __out.AppendLine(false); //413:173
            }
            __out.Append("}"); //415:1
            __out.AppendLine(false); //415:2
            return __out.ToString();
        }

        public string GenerateBuilderPropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //418:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //419:1
            if (cls.GetAllFinalProperties().Contains(prop)) //420:2
            {
                string __tmp2Line = "public "; //421:1
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
                string __tmp4Line = " "; //421:59
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
                        __out.AppendLine(false); //421:71
                    }
                }
            }
            else //422:2
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
                        __out.AppendLine(false); //423:54
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
                string __tmp10Line = " "; //424:52
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
                string __tmp12Line = "."; //424:99
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
                        __out.AppendLine(false); //424:111
                    }
                }
            }
            __out.Append("{"); //426:1
            __out.AppendLine(false); //426:2
            if (prop.Type is MetaCollectionType) //427:6
            {
                string __tmp15Line = "    get { return this.GetList<"; //428:1
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
                string __tmp17Line = ">("; //428:114
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
                string __tmp19Line = ", ref "; //428:168
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
                string __tmp21Line = "); }"; //428:198
                if (__tmp21Line != null) __out.Append(__tmp21Line);
                __out.AppendLine(false); //428:202
            }
            else if (prop.Type.IsReferenceType()) //429:3
            {
                string __tmp23Line = "    get { return this.GetReference<"; //430:1
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
                string __tmp25Line = ">("; //430:87
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
                string __tmp27Line = "); }"; //430:141
                if (__tmp27Line != null) __out.Append(__tmp27Line);
                __out.AppendLine(false); //430:145
            }
            else //431:3
            {
                string __tmp29Line = "    get { return this.GetValue<"; //432:1
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
                string __tmp31Line = ">("; //432:83
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
                string __tmp33Line = "); }"; //432:137
                if (__tmp33Line != null) __out.Append(__tmp33Line);
                __out.AppendLine(false); //432:141
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //434:3
            {
                if (prop.Type.IsReferenceType()) //435:4
                {
                    string __tmp35Line = "    set { this.SetReference<"; //436:1
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
                    string __tmp37Line = ">("; //436:80
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
                    string __tmp39Line = ", value); }"; //436:134
                    if (__tmp39Line != null) __out.Append(__tmp39Line);
                    __out.AppendLine(false); //436:145
                }
                else //437:4
                {
                    string __tmp41Line = "    set { this.SetValue<"; //438:1
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
                    string __tmp43Line = ">("; //438:76
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
                    string __tmp45Line = ", value); }"; //438:130
                    if (__tmp45Line != null) __out.Append(__tmp45Line);
                    __out.AppendLine(false); //438:141
                }
            }
            __out.Append("}"); //441:1
            __out.AppendLine(false); //441:2
            if (!(prop.Type is MetaCollectionType)) //442:2
            {
                __out.AppendLine(true); //443:1
                if (cls.GetAllFinalProperties().Contains(prop)) //444:3
                {
                    string __tmp47Line = "public Func<"; //445:1
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
                    string __tmp49Line = "> "; //445:64
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
                    string __tmp51Line = "Lazy"; //445:77
                    if (__tmp51Line != null) __out.Append(__tmp51Line);
                    __out.AppendLine(false); //445:81
                }
                else //446:3
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
                            __out.AppendLine(false); //447:54
                        }
                    }
                    string __tmp55Line = "Func<"; //448:1
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
                    string __tmp57Line = "> "; //448:57
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
                    string __tmp59Line = "."; //448:105
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
                    string __tmp61Line = "Lazy"; //448:117
                    if (__tmp61Line != null) __out.Append(__tmp61Line);
                    __out.AppendLine(false); //448:121
                }
                __out.Append("{"); //450:1
                __out.AppendLine(false); //450:2
                if (prop.Type.IsReferenceType()) //451:4
                {
                    string __tmp63Line = "    get { return this.GetLazyReference<"; //452:1
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
                    string __tmp65Line = ">("; //452:91
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
                    string __tmp67Line = "); }"; //452:145
                    if (__tmp67Line != null) __out.Append(__tmp67Line);
                    __out.AppendLine(false); //452:149
                    string __tmp69Line = "    set { this.SetLazyReference("; //453:1
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
                    string __tmp71Line = ", value); }"; //453:85
                    if (__tmp71Line != null) __out.Append(__tmp71Line);
                    __out.AppendLine(false); //453:96
                }
                else //454:4
                {
                    string __tmp73Line = "    get { return this.GetLazyValue<"; //455:1
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
                    string __tmp75Line = ">("; //455:87
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
                    string __tmp77Line = "); }"; //455:141
                    if (__tmp77Line != null) __out.Append(__tmp77Line);
                    __out.AppendLine(false); //455:145
                    string __tmp79Line = "    set { this.SetLazyValue("; //456:1
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
                    string __tmp81Line = ", value); }"; //456:81
                    if (__tmp81Line != null) __out.Append(__tmp81Line);
                    __out.AppendLine(false); //456:92
                }
                __out.Append("}"); //458:1
                __out.AppendLine(false); //458:2
            }
            return __out.ToString();
        }

        public string GetReturn(MetaOperation op) //462:1
        {
            if (op.ReturnType.CSharpName() == "void") //463:5
            {
                return ""; //464:3
            }
            else //465:2
            {
                return "return "; //466:3
            }
        }

        public string GenerateOperationImpl(MetaModel model, MetaOperation op) //470:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //471:1
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
            string __tmp3Line = " "; //472:58
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
            string __tmp5Line = "."; //472:106
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
            string __tmp7Line = "("; //472:116
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
            string __tmp9Line = ")"; //472:157
            if (__tmp9Line != null) __out.Append(__tmp9Line);
            __out.AppendLine(false); //472:158
            __out.Append("{"); //473:1
            __out.AppendLine(false); //473:2
            string __tmp10Prefix = "    "; //474:1
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
            string __tmp13Line = "."; //474:77
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
            string __tmp15Line = "_"; //474:102
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
            string __tmp17Line = "("; //474:112
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
            string __tmp19Line = ");"; //474:144
            if (__tmp19Line != null) __out.Append(__tmp19Line);
            __out.AppendLine(false); //474:146
            __out.Append("}"); //475:1
            __out.AppendLine(false); //475:2
            return __out.ToString();
        }

        public string GetSuperClasses(MetaClass cls) //478:1
        {
            string result = ""; //479:2
            var __loop32_results = 
                (from __loop32_var1 in __Enumerate((cls).GetEnumerator()) //480:10
                from sup in __Enumerate((__loop32_var1.SuperClasses).GetEnumerator()) //480:15
                select new { __loop32_var1 = __loop32_var1, sup = sup}
                ).ToList(); //480:5
            for (int __loop32_iteration = 0; __loop32_iteration < __loop32_results.Count; ++__loop32_iteration)
            {
                string delim; //480:31
                if (__loop32_iteration+1 < __loop32_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop32_results[__loop32_iteration];
                var __loop32_var1 = __tmp1.__loop32_var1;
                var sup = __tmp1.sup;
                result += sup.CSharpFullName() + delim; //481:3
            }
            return result; //483:2
        }

        public string GetAllSuperClasses(MetaClass cls) //486:1
        {
            string result = ""; //487:2
            var __loop33_results = 
                (from __loop33_var1 in __Enumerate((cls).GetEnumerator()) //488:10
                from sup in __Enumerate((__loop33_var1.GetAllSuperClasses(false)).GetEnumerator()) //488:15
                select new { __loop33_var1 = __loop33_var1, sup = sup}
                ).ToList(); //488:5
            for (int __loop33_iteration = 0; __loop33_iteration < __loop33_results.Count; ++__loop33_iteration)
            {
                string delim; //488:44
                if (__loop33_iteration+1 < __loop33_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop33_results[__loop33_iteration];
                var __loop33_var1 = __tmp1.__loop33_var1;
                var sup = __tmp1.sup;
                result += sup.CSharpFullName() + delim; //489:3
            }
            return result; //491:2
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //494:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "public static class "; //495:1
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
                    __out.AppendLine(false); //495:51
                }
            }
            __out.Append("{"); //496:1
            __out.AppendLine(false); //496:2
            __out.Append("    private static global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty> properties;"); //497:1
            __out.AppendLine(false); //497:118
            __out.AppendLine(true); //498:1
            string __tmp5Line = "    static "; //499:1
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
            string __tmp7Line = "()"; //499:42
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //499:44
            __out.Append("    {"); //500:1
            __out.AppendLine(false); //500:6
            __out.Append("        MetaDescriptor.properties = new global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty>();"); //501:1
            __out.AppendLine(false); //501:130
            __out.Append("		global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty> properties = new global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty>();"); //502:1
            __out.AppendLine(false); //502:196
            var __loop34_results = 
                (from __loop34_var1 in __Enumerate((model).GetEnumerator()) //503:11
                from Namespace in __Enumerate((__loop34_var1.Namespace).GetEnumerator()) //503:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //503:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //503:43
                from prop in __Enumerate((cls.Properties).GetEnumerator()) //503:66
                select new { __loop34_var1 = __loop34_var1, Namespace = Namespace, Declarations = Declarations, cls = cls, prop = prop}
                ).ToList(); //503:6
            for (int __loop34_iteration = 0; __loop34_iteration < __loop34_results.Count; ++__loop34_iteration)
            {
                var __tmp8 = __loop34_results[__loop34_iteration];
                var __loop34_var1 = __tmp8.__loop34_var1;
                var Namespace = __tmp8.Namespace;
                var Declarations = __tmp8.Declarations;
                var cls = __tmp8.cls;
                var prop = __tmp8.prop;
                string __tmp10Line = "        properties.Add("; //504:1
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
                string __tmp12Line = "."; //504:42
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
                string __tmp14Line = "Property);"; //504:54
                if (__tmp14Line != null) __out.Append(__tmp14Line);
                __out.AppendLine(false); //504:64
            }
            __out.Append("    }"); //506:1
            __out.AppendLine(false); //506:6
            __out.AppendLine(true); //507:1
            __out.Append("    public static void Initialize()"); //508:1
            __out.AppendLine(false); //508:36
            __out.Append("    {"); //509:1
            __out.AppendLine(false); //509:6
            __out.Append("    }"); //511:1
            __out.AppendLine(false); //511:6
            __out.AppendLine(true); //512:1
            string __tmp16Line = "	public const string Uri = \""; //513:1
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
            string __tmp18Line = "\";"; //513:40
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //513:42
            __out.AppendLine(true); //514:1
            var __loop35_results = 
                (from __loop35_var1 in __Enumerate((model).GetEnumerator()) //515:11
                from Namespace in __Enumerate((__loop35_var1.Namespace).GetEnumerator()) //515:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //515:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //515:43
                select new { __loop35_var1 = __loop35_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //515:6
            for (int __loop35_iteration = 0; __loop35_iteration < __loop35_results.Count; ++__loop35_iteration)
            {
                var __tmp19 = __loop35_results[__loop35_iteration];
                var __loop35_var1 = __tmp19.__loop35_var1;
                var Namespace = __tmp19.Namespace;
                var Declarations = __tmp19.Declarations;
                var cls = __tmp19.cls;
                string __tmp20Prefix = "    "; //516:1
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
                        __out.AppendLine(false); //516:34
                    }
                }
            }
            __out.Append("}"); //518:1
            __out.AppendLine(false); //518:2
            __out.AppendLine(true); //519:1
            return __out.ToString();
        }

        public string GenerateMetaModelClass(MetaClass cls) //523:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //524:1
            if (cls.SuperClasses.Count > 0) //525:2
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
                __tmp3.Append(GetDescriptorAncestors(cls));
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
                        __out.AppendLine(false); //526:62
                    }
                }
            }
            else //527:2
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
                        __out.AppendLine(false); //528:27
                    }
                }
            }
            string __tmp8Line = "public static class "; //530:1
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
                    __out.AppendLine(false); //530:39
                }
            }
            __out.Append("{"); //531:1
            __out.AppendLine(false); //531:2
            string __tmp11Line = "    static "; //532:1
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
            string __tmp13Line = "()"; //532:30
            if (__tmp13Line != null) __out.Append(__tmp13Line);
            __out.AppendLine(false); //532:32
            __out.Append("    {"); //533:1
            __out.AppendLine(false); //533:6
            string __tmp14Prefix = "        "; //534:1
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
            string __tmp16Line = ".ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof("; //534:27
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
            string __tmp18Line = "));"; //534:133
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //534:136
            __out.Append("    }"); //535:1
            __out.AppendLine(false); //535:6
            __out.AppendLine(true); //536:1
            __out.Append("    public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }"); //537:1
            __out.AppendLine(false); //537:91
            __out.AppendLine(true); //538:1
            if (cls.CSharpName() == "MetaClass") //539:2
            {
                __out.Append("    public static global::MetaDslx.Core.Immutable.MetaClass _MetaClass"); //540:1
                __out.AppendLine(false); //540:71
            }
            else //541:2
            {
                __out.Append("    public static global::MetaDslx.Core.Immutable.MetaClass MetaClass"); //542:1
                __out.AppendLine(false); //542:70
            }
            __out.Append("    {"); //544:1
            __out.AppendLine(false); //544:6
            string __tmp20Line = "        get { return null;/*"; //545:1
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
            string __tmp22Line = ";*/ }"; //545:59
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            __out.AppendLine(false); //545:64
            __out.Append("    }"); //546:1
            __out.AppendLine(false); //546:6
            __out.AppendLine(true); //547:1
            var __loop36_results = 
                (from __loop36_var1 in __Enumerate((cls).GetEnumerator()) //548:11
                from prop in __Enumerate((__loop36_var1.Properties).GetEnumerator()) //548:16
                select new { __loop36_var1 = __loop36_var1, prop = prop}
                ).ToList(); //548:6
            for (int __loop36_iteration = 0; __loop36_iteration < __loop36_results.Count; ++__loop36_iteration)
            {
                var __tmp23 = __loop36_results[__loop36_iteration];
                var __loop36_var1 = __tmp23.__loop36_var1;
                var prop = __tmp23.prop;
                string __tmp24Prefix = "    "; //549:1
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
                        __out.AppendLine(false); //549:56
                    }
                }
            }
            __out.Append("}"); //551:1
            __out.AppendLine(false); //551:2
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //554:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal static class "; //555:1
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
            string __tmp4Line = "ImplementationProvider"; //555:35
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //555:57
            __out.Append("{"); //556:1
            __out.AppendLine(false); //556:2
            string __tmp6Line = "    // If there is a compile error at this line, create a new class called "; //557:1
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
            string __tmp8Line = "Implementation"; //557:88
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //557:102
            string __tmp10Line = "	// which is a subclass of "; //558:1
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
            string __tmp12Line = "ImplementationBase:"; //558:40
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //558:59
            string __tmp14Line = "    private static "; //559:1
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
            string __tmp16Line = "Implementation implementation = new "; //559:32
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
            string __tmp18Line = "Implementation();"; //559:80
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //559:97
            __out.AppendLine(true); //560:1
            string __tmp20Line = "    public static "; //561:1
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
            string __tmp22Line = "Implementation Implementation"; //561:31
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            __out.AppendLine(false); //561:60
            __out.Append("    {"); //562:1
            __out.AppendLine(false); //562:6
            string __tmp24Line = "        get { return "; //563:1
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
            string __tmp26Line = "ImplementationProvider.implementation; }"; //563:34
            if (__tmp26Line != null) __out.Append(__tmp26Line);
            __out.AppendLine(false); //563:74
            __out.Append("    }"); //564:1
            __out.AppendLine(false); //564:6
            __out.Append("}"); //565:1
            __out.AppendLine(false); //565:2
            var __loop37_results = 
                (from __loop37_var1 in __Enumerate((model).GetEnumerator()) //566:8
                from Namespace in __Enumerate((__loop37_var1.Namespace).GetEnumerator()) //566:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //566:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //566:40
                select new { __loop37_var1 = __loop37_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //566:3
            for (int __loop37_iteration = 0; __loop37_iteration < __loop37_results.Count; ++__loop37_iteration)
            {
                var __tmp27 = __loop37_results[__loop37_iteration];
                var __loop37_var1 = __tmp27.__loop37_var1;
                var Namespace = __tmp27.Namespace;
                var Declarations = __tmp27.Declarations;
                var enm = __tmp27.enm;
                __out.AppendLine(true); //567:1
                string __tmp29Line = "public static class "; //568:1
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
                string __tmp31Line = "Extensions"; //568:31
                if (__tmp31Line != null) __out.Append(__tmp31Line);
                __out.AppendLine(false); //568:41
                __out.Append("{"); //569:1
                __out.AppendLine(false); //569:2
                var __loop38_results = 
                    (from __loop38_var1 in __Enumerate((enm).GetEnumerator()) //570:11
                    from op in __Enumerate((__loop38_var1.Operations).GetEnumerator()) //570:16
                    select new { __loop38_var1 = __loop38_var1, op = op}
                    ).ToList(); //570:6
                for (int __loop38_iteration = 0; __loop38_iteration < __loop38_results.Count; ++__loop38_iteration)
                {
                    var __tmp32 = __loop38_results[__loop38_iteration];
                    var __loop38_var1 = __tmp32.__loop38_var1;
                    var op = __tmp32.op;
                    string __tmp34Line = "    public static "; //571:1
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
                    string __tmp36Line = " "; //571:76
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
                    string __tmp38Line = "("; //571:86
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
                    string __tmp40Line = ")"; //571:119
                    if (__tmp40Line != null) __out.Append(__tmp40Line);
                    __out.AppendLine(false); //571:120
                    __out.Append("    {"); //572:1
                    __out.AppendLine(false); //572:6
                    string __tmp41Prefix = "        "; //573:1
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
                    string __tmp44Line = "ImplementationProvider.Implementation."; //573:36
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
                    string __tmp46Line = "_"; //573:98
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
                    string __tmp48Line = "("; //573:108
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
                    string __tmp50Line = ");"; //573:144
                    if (__tmp50Line != null) __out.Append(__tmp50Line);
                    __out.AppendLine(false); //573:146
                    __out.Append("    }"); //574:1
                    __out.AppendLine(false); //574:6
                }
                __out.Append("}"); //576:1
                __out.AppendLine(false); //576:2
            }
            __out.AppendLine(true); //578:1
            __out.Append("/// <summary>"); //579:1
            __out.AppendLine(false); //579:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //580:1
            __out.AppendLine(false); //580:68
            string __tmp52Line = "/// This class has to be be overriden in "; //581:1
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
            string __tmp54Line = "Implementation to provide custom"; //581:54
            if (__tmp54Line != null) __out.Append(__tmp54Line);
            __out.AppendLine(false); //581:86
            __out.Append("/// implementation for the constructors, operations and property values."); //582:1
            __out.AppendLine(false); //582:73
            __out.Append("/// </summary>"); //583:1
            __out.AppendLine(false); //583:15
            string __tmp56Line = "internal abstract class "; //584:1
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
            string __tmp58Line = "ImplementationBase"; //584:37
            if (__tmp58Line != null) __out.Append(__tmp58Line);
            __out.AppendLine(false); //584:55
            __out.Append("{"); //585:1
            __out.AppendLine(false); //585:2
            string __tmp60Line = "	public virtual void "; //586:1
            if (__tmp60Line != null) __out.Append(__tmp60Line);
            StringBuilder __tmp61 = new StringBuilder();
            __tmp61.Append(model.CSharpInstancesName(ClassKind.Builder));
            using(StreamReader __tmp61Reader = new StreamReader(this.__ToStream(__tmp61.ToString())))
            {
                bool __tmp61_first = true;
                bool __tmp61_last = __tmp61Reader.EndOfStream;
                while(__tmp61_first || !__tmp61_last)
                {
                    __tmp61_first = false;
                    string __tmp61Line = __tmp61Reader.ReadLine();
                    __tmp61_last = __tmp61Reader.EndOfStream;
                    if (__tmp61Line != null) __out.Append(__tmp61Line);
                    if (!__tmp61_last) __out.AppendLine(true);
                }
            }
            string __tmp62Line = "("; //586:68
            if (__tmp62Line != null) __out.Append(__tmp62Line);
            StringBuilder __tmp63 = new StringBuilder();
            __tmp63.Append(model.CSharpInstancesName(ClassKind.Builder));
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
            string __tmp64Line = " _this)"; //586:115
            if (__tmp64Line != null) __out.Append(__tmp64Line);
            __out.AppendLine(false); //586:122
            __out.Append("	{"); //587:1
            __out.AppendLine(false); //587:3
            __out.Append("	}"); //588:1
            __out.AppendLine(false); //588:3
            var __loop39_results = 
                (from __loop39_var1 in __Enumerate((model).GetEnumerator()) //589:8
                from Namespace in __Enumerate((__loop39_var1.Namespace).GetEnumerator()) //589:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //589:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //589:40
                select new { __loop39_var1 = __loop39_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //589:3
            for (int __loop39_iteration = 0; __loop39_iteration < __loop39_results.Count; ++__loop39_iteration)
            {
                var __tmp65 = __loop39_results[__loop39_iteration];
                var __loop39_var1 = __tmp65.__loop39_var1;
                var Namespace = __tmp65.Namespace;
                var Declarations = __tmp65.Declarations;
                var cls = __tmp65.cls;
                __out.Append("    /// <summary>"); //590:1
                __out.AppendLine(false); //590:18
                string __tmp67Line = "	/// Implements the constructor: "; //591:1
                if (__tmp67Line != null) __out.Append(__tmp67Line);
                StringBuilder __tmp68 = new StringBuilder();
                __tmp68.Append(cls.CSharpName());
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
                string __tmp69Line = "()"; //591:52
                if (__tmp69Line != null) __out.Append(__tmp69Line);
                __out.AppendLine(false); //591:54
                __out.Append("    /// </summary>"); //592:1
                __out.AppendLine(false); //592:19
                if ((from __loop40_var1 in __Enumerate((cls).GetEnumerator()) //593:15
                from sup in __Enumerate((__loop40_var1.SuperClasses).GetEnumerator()) //593:20
                select new { __loop40_var1 = __loop40_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //593:3
                {
                    string __tmp71Line = "	/// Direct superclasses: "; //594:1
                    if (__tmp71Line != null) __out.Append(__tmp71Line);
                    StringBuilder __tmp72 = new StringBuilder();
                    __tmp72.Append(GetSuperClasses(cls));
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
                            __out.AppendLine(false); //594:49
                        }
                    }
                    string __tmp74Line = "	/// All superclasses: "; //595:1
                    if (__tmp74Line != null) __out.Append(__tmp74Line);
                    StringBuilder __tmp75 = new StringBuilder();
                    __tmp75.Append(GetAllSuperClasses(cls));
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
                            __out.AppendLine(false); //595:49
                        }
                    }
                }
                if ((from __loop41_var1 in __Enumerate((cls).GetEnumerator()) //597:15
                from prop in __Enumerate((__loop41_var1.Properties).GetEnumerator()) //597:20
                where prop.Kind == MetaPropertyKind.Readonly //597:36
                select new { __loop41_var1 = __loop41_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //597:3
                {
                    __out.Append("    /// Initializes the following readonly properties:"); //598:1
                    __out.AppendLine(false); //598:55
                    __out.Append("	/// <ul>"); //599:1
                    __out.AppendLine(false); //599:10
                    var __loop42_results = 
                        (from __loop42_var1 in __Enumerate((cls).GetEnumerator()) //600:11
                        from prop in __Enumerate((__loop42_var1.Properties).GetEnumerator()) //600:16
                        where prop.Kind == MetaPropertyKind.Readonly //600:32
                        select new { __loop42_var1 = __loop42_var1, prop = prop}
                        ).ToList(); //600:6
                    for (int __loop42_iteration = 0; __loop42_iteration < __loop42_results.Count; ++__loop42_iteration)
                    {
                        var __tmp76 = __loop42_results[__loop42_iteration];
                        var __loop42_var1 = __tmp76.__loop42_var1;
                        var prop = __tmp76.prop;
                        string __tmp78Line = "    ///     <li>"; //601:1
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
                        string __tmp80Line = "</li>"; //601:28
                        if (__tmp80Line != null) __out.Append(__tmp80Line);
                        __out.AppendLine(false); //601:33
                    }
                    __out.Append("	/// </ul>"); //603:1
                    __out.AppendLine(false); //603:11
                }
                if ((from __loop43_var1 in __Enumerate((cls).GetEnumerator()) //605:15
                from prop in __Enumerate((__loop43_var1.Properties).GetEnumerator()) //605:20
                where prop.Kind == MetaPropertyKind.Lazy //605:36
                select new { __loop43_var1 = __loop43_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //605:3
                {
                    __out.Append("    /// Initializes the following lazy properties:"); //606:1
                    __out.AppendLine(false); //606:51
                    __out.Append("	/// <ul>"); //607:1
                    __out.AppendLine(false); //607:10
                    var __loop44_results = 
                        (from __loop44_var1 in __Enumerate((cls).GetEnumerator()) //608:11
                        from prop in __Enumerate((__loop44_var1.Properties).GetEnumerator()) //608:16
                        where prop.Kind == MetaPropertyKind.Lazy //608:32
                        select new { __loop44_var1 = __loop44_var1, prop = prop}
                        ).ToList(); //608:6
                    for (int __loop44_iteration = 0; __loop44_iteration < __loop44_results.Count; ++__loop44_iteration)
                    {
                        var __tmp81 = __loop44_results[__loop44_iteration];
                        var __loop44_var1 = __tmp81.__loop44_var1;
                        var prop = __tmp81.prop;
                        string __tmp83Line = "    ///     <li>"; //609:1
                        if (__tmp83Line != null) __out.Append(__tmp83Line);
                        StringBuilder __tmp84 = new StringBuilder();
                        __tmp84.Append(prop.Name);
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
                        string __tmp85Line = "</li>"; //609:28
                        if (__tmp85Line != null) __out.Append(__tmp85Line);
                        __out.AppendLine(false); //609:33
                    }
                    __out.Append("	/// </ul>"); //611:1
                    __out.AppendLine(false); //611:11
                }
                if ((from __loop45_var1 in __Enumerate((cls).GetEnumerator()) //613:15
                from prop in __Enumerate((__loop45_var1.Properties).GetEnumerator()) //613:20
                where prop.Kind == MetaPropertyKind.Derived //613:36
                select new { __loop45_var1 = __loop45_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //613:3
                {
                    __out.Append("    /// Initializes the following derived properties:"); //614:1
                    __out.AppendLine(false); //614:54
                    __out.Append("	/// <ul>"); //615:1
                    __out.AppendLine(false); //615:10
                    var __loop46_results = 
                        (from __loop46_var1 in __Enumerate((cls).GetEnumerator()) //616:11
                        from prop in __Enumerate((__loop46_var1.Properties).GetEnumerator()) //616:16
                        where prop.Kind == MetaPropertyKind.Derived //616:32
                        select new { __loop46_var1 = __loop46_var1, prop = prop}
                        ).ToList(); //616:6
                    for (int __loop46_iteration = 0; __loop46_iteration < __loop46_results.Count; ++__loop46_iteration)
                    {
                        var __tmp86 = __loop46_results[__loop46_iteration];
                        var __loop46_var1 = __tmp86.__loop46_var1;
                        var prop = __tmp86.prop;
                        string __tmp88Line = "    ///     <li>"; //617:1
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
                        string __tmp90Line = "</li>"; //617:28
                        if (__tmp90Line != null) __out.Append(__tmp90Line);
                        __out.AppendLine(false); //617:33
                    }
                    __out.Append("	/// </ul>"); //619:1
                    __out.AppendLine(false); //619:11
                }
                string __tmp92Line = "    public virtual void "; //621:1
                if (__tmp92Line != null) __out.Append(__tmp92Line);
                StringBuilder __tmp93 = new StringBuilder();
                __tmp93.Append(cls.CSharpName());
                using(StreamReader __tmp93Reader = new StreamReader(this.__ToStream(__tmp93.ToString())))
                {
                    bool __tmp93_first = true;
                    bool __tmp93_last = __tmp93Reader.EndOfStream;
                    while(__tmp93_first || !__tmp93_last)
                    {
                        __tmp93_first = false;
                        string __tmp93Line = __tmp93Reader.ReadLine();
                        __tmp93_last = __tmp93Reader.EndOfStream;
                        if (__tmp93Line != null) __out.Append(__tmp93Line);
                        if (!__tmp93_last) __out.AppendLine(true);
                    }
                }
                string __tmp94Line = "("; //621:43
                if (__tmp94Line != null) __out.Append(__tmp94Line);
                StringBuilder __tmp95 = new StringBuilder();
                __tmp95.Append(cls.CSharpName(ClassKind.Builder));
                using(StreamReader __tmp95Reader = new StreamReader(this.__ToStream(__tmp95.ToString())))
                {
                    bool __tmp95_first = true;
                    bool __tmp95_last = __tmp95Reader.EndOfStream;
                    while(__tmp95_first || !__tmp95_last)
                    {
                        __tmp95_first = false;
                        string __tmp95Line = __tmp95Reader.ReadLine();
                        __tmp95_last = __tmp95Reader.EndOfStream;
                        if (__tmp95Line != null) __out.Append(__tmp95Line);
                        if (!__tmp95_last) __out.AppendLine(true);
                    }
                }
                string __tmp96Line = " _this)"; //621:79
                if (__tmp96Line != null) __out.Append(__tmp96Line);
                __out.AppendLine(false); //621:86
                __out.Append("    {"); //622:1
                __out.AppendLine(false); //622:6
                __out.Append("    }"); //623:1
                __out.AppendLine(false); //623:6
                var __loop47_results = 
                    (from __loop47_var1 in __Enumerate((cls).GetEnumerator()) //624:11
                    from op in __Enumerate((__loop47_var1.Operations).GetEnumerator()) //624:16
                    select new { __loop47_var1 = __loop47_var1, op = op}
                    ).ToList(); //624:6
                for (int __loop47_iteration = 0; __loop47_iteration < __loop47_results.Count; ++__loop47_iteration)
                {
                    var __tmp97 = __loop47_results[__loop47_iteration];
                    var __loop47_var1 = __tmp97.__loop47_var1;
                    var op = __tmp97.op;
                    __out.AppendLine(true); //625:1
                    __out.Append("    /// <summary>"); //626:1
                    __out.AppendLine(false); //626:18
                    string __tmp99Line = "    /// Implements the operation: "; //627:1
                    if (__tmp99Line != null) __out.Append(__tmp99Line);
                    StringBuilder __tmp100 = new StringBuilder();
                    __tmp100.Append(cls.CSharpName());
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
                    string __tmp101Line = "."; //627:53
                    if (__tmp101Line != null) __out.Append(__tmp101Line);
                    StringBuilder __tmp102 = new StringBuilder();
                    __tmp102.Append(op.Name);
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
                    string __tmp103Line = "()"; //627:63
                    if (__tmp103Line != null) __out.Append(__tmp103Line);
                    __out.AppendLine(false); //627:65
                    __out.Append("    /// </summary>"); //628:1
                    __out.AppendLine(false); //628:19
                    string __tmp105Line = "    public virtual "; //629:1
                    if (__tmp105Line != null) __out.Append(__tmp105Line);
                    StringBuilder __tmp106 = new StringBuilder();
                    __tmp106.Append(op.ReturnType.CSharpFullPublicName(ClassKind.Immutable));
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
                    string __tmp107Line = " "; //629:77
                    if (__tmp107Line != null) __out.Append(__tmp107Line);
                    StringBuilder __tmp108 = new StringBuilder();
                    __tmp108.Append(cls.CSharpName());
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
                    string __tmp109Line = "_"; //629:96
                    if (__tmp109Line != null) __out.Append(__tmp109Line);
                    StringBuilder __tmp110 = new StringBuilder();
                    __tmp110.Append(op.Name);
                    using(StreamReader __tmp110Reader = new StreamReader(this.__ToStream(__tmp110.ToString())))
                    {
                        bool __tmp110_first = true;
                        bool __tmp110_last = __tmp110Reader.EndOfStream;
                        while(__tmp110_first || !__tmp110_last)
                        {
                            __tmp110_first = false;
                            string __tmp110Line = __tmp110Reader.ReadLine();
                            __tmp110_last = __tmp110Reader.EndOfStream;
                            if (__tmp110Line != null) __out.Append(__tmp110Line);
                            if (!__tmp110_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp111Line = "("; //629:106
                    if (__tmp111Line != null) __out.Append(__tmp111Line);
                    StringBuilder __tmp112 = new StringBuilder();
                    __tmp112.Append(GetImplParameters(cls, op));
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
                    string __tmp113Line = ")"; //629:135
                    if (__tmp113Line != null) __out.Append(__tmp113Line);
                    __out.AppendLine(false); //629:136
                    __out.Append("    {"); //630:1
                    __out.AppendLine(false); //630:6
                    __out.Append("        throw new NotImplementedException();"); //631:1
                    __out.AppendLine(false); //631:45
                    __out.Append("    }"); //632:1
                    __out.AppendLine(false); //632:6
                }
                __out.AppendLine(true); //634:1
            }
            var __loop48_results = 
                (from __loop48_var1 in __Enumerate((model).GetEnumerator()) //636:8
                from Namespace in __Enumerate((__loop48_var1.Namespace).GetEnumerator()) //636:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //636:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //636:40
                select new { __loop48_var1 = __loop48_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //636:3
            for (int __loop48_iteration = 0; __loop48_iteration < __loop48_results.Count; ++__loop48_iteration)
            {
                var __tmp114 = __loop48_results[__loop48_iteration];
                var __loop48_var1 = __tmp114.__loop48_var1;
                var Namespace = __tmp114.Namespace;
                var Declarations = __tmp114.Declarations;
                var enm = __tmp114.enm;
                var __loop49_results = 
                    (from __loop49_var1 in __Enumerate((enm).GetEnumerator()) //637:11
                    from op in __Enumerate((__loop49_var1.Operations).GetEnumerator()) //637:16
                    select new { __loop49_var1 = __loop49_var1, op = op}
                    ).ToList(); //637:6
                for (int __loop49_iteration = 0; __loop49_iteration < __loop49_results.Count; ++__loop49_iteration)
                {
                    var __tmp115 = __loop49_results[__loop49_iteration];
                    var __loop49_var1 = __tmp115.__loop49_var1;
                    var op = __tmp115.op;
                    __out.AppendLine(true); //638:1
                    __out.Append("    /// <summary>"); //639:1
                    __out.AppendLine(false); //639:18
                    string __tmp117Line = "    /// Implements the operation: "; //640:1
                    if (__tmp117Line != null) __out.Append(__tmp117Line);
                    StringBuilder __tmp118 = new StringBuilder();
                    __tmp118.Append(enm.CSharpName());
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
                    string __tmp119Line = "."; //640:53
                    if (__tmp119Line != null) __out.Append(__tmp119Line);
                    StringBuilder __tmp120 = new StringBuilder();
                    __tmp120.Append(op.Name);
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
                            __out.AppendLine(false); //640:63
                        }
                    }
                    __out.Append("    /// </summary>"); //641:1
                    __out.AppendLine(false); //641:19
                    string __tmp122Line = "    public virtual "; //642:1
                    if (__tmp122Line != null) __out.Append(__tmp122Line);
                    StringBuilder __tmp123 = new StringBuilder();
                    __tmp123.Append(op.ReturnType.CSharpFullPublicName(ClassKind.Immutable));
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
                    string __tmp124Line = " "; //642:77
                    if (__tmp124Line != null) __out.Append(__tmp124Line);
                    StringBuilder __tmp125 = new StringBuilder();
                    __tmp125.Append(enm.CSharpName());
                    using(StreamReader __tmp125Reader = new StreamReader(this.__ToStream(__tmp125.ToString())))
                    {
                        bool __tmp125_first = true;
                        bool __tmp125_last = __tmp125Reader.EndOfStream;
                        while(__tmp125_first || !__tmp125_last)
                        {
                            __tmp125_first = false;
                            string __tmp125Line = __tmp125Reader.ReadLine();
                            __tmp125_last = __tmp125Reader.EndOfStream;
                            if (__tmp125Line != null) __out.Append(__tmp125Line);
                            if (!__tmp125_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp126Line = "_"; //642:96
                    if (__tmp126Line != null) __out.Append(__tmp126Line);
                    StringBuilder __tmp127 = new StringBuilder();
                    __tmp127.Append(op.Name);
                    using(StreamReader __tmp127Reader = new StreamReader(this.__ToStream(__tmp127.ToString())))
                    {
                        bool __tmp127_first = true;
                        bool __tmp127_last = __tmp127Reader.EndOfStream;
                        while(__tmp127_first || !__tmp127_last)
                        {
                            __tmp127_first = false;
                            string __tmp127Line = __tmp127Reader.ReadLine();
                            __tmp127_last = __tmp127Reader.EndOfStream;
                            if (__tmp127Line != null) __out.Append(__tmp127Line);
                            if (!__tmp127_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp128Line = "("; //642:106
                    if (__tmp128Line != null) __out.Append(__tmp128Line);
                    StringBuilder __tmp129 = new StringBuilder();
                    __tmp129.Append(GetImplParameters(enm, op));
                    using(StreamReader __tmp129Reader = new StreamReader(this.__ToStream(__tmp129.ToString())))
                    {
                        bool __tmp129_first = true;
                        bool __tmp129_last = __tmp129Reader.EndOfStream;
                        while(__tmp129_first || !__tmp129_last)
                        {
                            __tmp129_first = false;
                            string __tmp129Line = __tmp129Reader.ReadLine();
                            __tmp129_last = __tmp129Reader.EndOfStream;
                            if (__tmp129Line != null) __out.Append(__tmp129Line);
                            if (!__tmp129_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp130Line = ")"; //642:135
                    if (__tmp130Line != null) __out.Append(__tmp130Line);
                    __out.AppendLine(false); //642:136
                    __out.Append("    {"); //643:1
                    __out.AppendLine(false); //643:6
                    __out.Append("        throw new NotImplementedException();"); //644:1
                    __out.AppendLine(false); //644:45
                    __out.Append("    }"); //645:1
                    __out.AppendLine(false); //645:6
                }
                __out.AppendLine(true); //647:1
            }
            __out.Append("}"); //649:1
            __out.AppendLine(false); //649:2
            __out.AppendLine(true); //650:1
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //653:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //654:1
            __out.AppendLine(false); //654:14
            __out.Append("/// Factory class for creating instances of model elements."); //655:1
            __out.AppendLine(false); //655:60
            __out.Append("/// </summary>"); //656:1
            __out.AppendLine(false); //656:15
            string __tmp2Line = "public class "; //657:1
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
            string __tmp4Line = " : global::MetaDslx.Core.Immutable.ModelFactory"; //657:41
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //657:88
            __out.Append("{"); //658:1
            __out.AppendLine(false); //658:2
            string __tmp6Line = "    public "; //659:1
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
            string __tmp8Line = "(MutableModel model, ModelFactoryFlags flags = ModelFactoryFlags.None)"; //659:39
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //659:109
            __out.Append("        : base(model, flags)"); //660:1
            __out.AppendLine(false); //660:29
            __out.Append("    {"); //661:1
            __out.AppendLine(false); //661:6
            string __tmp9Prefix = "		"; //662:1
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
            string __tmp11Line = ".Initialize();"; //662:56
            if (__tmp11Line != null) __out.Append(__tmp11Line);
            __out.AppendLine(false); //662:70
            __out.Append("    }"); //663:1
            __out.AppendLine(false); //663:6
            __out.AppendLine(true); //664:1
            __out.Append("    public override global::MetaDslx.Core.Immutable.MutableSymbolBase Create(string type)"); //665:1
            __out.AppendLine(false); //665:90
            __out.Append("    {"); //666:1
            __out.AppendLine(false); //666:6
            __out.Append("        switch (type)"); //667:1
            __out.AppendLine(false); //667:22
            __out.Append("        {"); //668:1
            __out.AppendLine(false); //668:10
            var __loop50_results = 
                (from __loop50_var1 in __Enumerate((model).GetEnumerator()) //669:10
                from Namespace in __Enumerate((__loop50_var1.Namespace).GetEnumerator()) //669:17
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //669:28
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //669:42
                select new { __loop50_var1 = __loop50_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //669:5
            for (int __loop50_iteration = 0; __loop50_iteration < __loop50_results.Count; ++__loop50_iteration)
            {
                var __tmp12 = __loop50_results[__loop50_iteration];
                var __loop50_var1 = __tmp12.__loop50_var1;
                var Namespace = __tmp12.Namespace;
                var Declarations = __tmp12.Declarations;
                var cls = __tmp12.cls;
                if (!cls.IsAbstract) //670:6
                {
                    string __tmp14Line = "            case \""; //671:1
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
                    string __tmp16Line = "\": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this."; //671:37
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
                    string __tmp18Line = "();"; //671:121
                    if (__tmp18Line != null) __out.Append(__tmp18Line);
                    __out.AppendLine(false); //671:124
                }
            }
            __out.Append("            default:"); //674:1
            __out.AppendLine(false); //674:21
            __out.Append("                throw new ModelException(\"Unknown type name: \" + type);"); //675:1
            __out.AppendLine(false); //675:72
            __out.Append("        }"); //676:1
            __out.AppendLine(false); //676:10
            __out.Append("    }"); //677:1
            __out.AppendLine(false); //677:6
            var __loop51_results = 
                (from __loop51_var1 in __Enumerate((model).GetEnumerator()) //678:8
                from Namespace in __Enumerate((__loop51_var1.Namespace).GetEnumerator()) //678:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //678:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //678:40
                select new { __loop51_var1 = __loop51_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //678:3
            for (int __loop51_iteration = 0; __loop51_iteration < __loop51_results.Count; ++__loop51_iteration)
            {
                var __tmp19 = __loop51_results[__loop51_iteration];
                var __loop51_var1 = __tmp19.__loop51_var1;
                var Namespace = __tmp19.Namespace;
                var Declarations = __tmp19.Declarations;
                var cls = __tmp19.cls;
                if (!cls.IsAbstract) //679:4
                {
                    __out.AppendLine(true); //680:1
                    __out.Append("    /// <summary>"); //681:1
                    __out.AppendLine(false); //681:18
                    string __tmp21Line = "    /// Creates a new instance of "; //682:1
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
                    string __tmp23Line = "."; //682:53
                    if (__tmp23Line != null) __out.Append(__tmp23Line);
                    __out.AppendLine(false); //682:54
                    __out.Append("    /// </summary>"); //683:1
                    __out.AppendLine(false); //683:19
                    string __tmp25Line = "    public "; //684:1
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
                    string __tmp27Line = " "; //684:47
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
                    string __tmp29Line = "()"; //684:66
                    if (__tmp29Line != null) __out.Append(__tmp29Line);
                    __out.AppendLine(false); //684:68
                    __out.Append("	{"); //685:1
                    __out.AppendLine(false); //685:3
                    string __tmp31Line = "		global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new "; //686:1
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
                    string __tmp33Line = "());"; //686:114
                    if (__tmp33Line != null) __out.Append(__tmp33Line);
                    __out.AppendLine(false); //686:118
                    string __tmp35Line = "		return ("; //687:1
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
                    string __tmp37Line = ")symbol;"; //687:46
                    if (__tmp37Line != null) __out.Append(__tmp37Line);
                    __out.AppendLine(false); //687:54
                    __out.Append("	}"); //688:1
                    __out.AppendLine(false); //688:3
                }
            }
            __out.Append("}"); //691:1
            __out.AppendLine(false); //691:2
            __out.AppendLine(true); //692:1
            return __out.ToString();
        }

        public string GenerateMetaModelInstance(MetaModel model) //696:1
        {
            StringBuilder __out = new StringBuilder();
            Dictionary<ModelObject,string> mobjToName = model.GetNamedModelObjects(); //697:2
            bool coreModel = model.CSharpFullName(ClassKind.Immutable) == "global::MetaDslx.Core.Immutable.Meta"; //698:2
            string __tmp2Line = "internal class "; //699:1
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
                    __out.AppendLine(false); //699:62
                }
            }
            __out.Append("{"); //700:1
            __out.AppendLine(false); //700:2
            string __tmp5Line = "	internal static "; //701:1
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
            string __tmp7Line = " instance = new "; //701:64
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
            string __tmp9Line = "();"; //701:126
            if (__tmp9Line != null) __out.Append(__tmp9Line);
            __out.AppendLine(false); //701:129
            __out.AppendLine(true); //702:1
            if (coreModel) //703:3
            {
                __out.Append("	internal readonly global::MetaDslx.Core.Immutable.MetaModelBuilder _MetaModel;"); //704:1
                __out.AppendLine(false); //704:80
            }
            else //705:3
            {
                __out.Append("	internal readonly global::MetaDslx.Core.Immutable.MetaModelBuilder MetaModel;"); //706:1
                __out.AppendLine(false); //706:79
            }
            __out.Append("	internal readonly global::MetaDslx.Core.Immutable.MutableModel Model;"); //708:1
            __out.AppendLine(false); //708:71
            __out.AppendLine(true); //709:1
            var __loop52_results = 
                (from __loop52_var1 in __Enumerate((model).GetEnumerator()) //710:11
                from Namespace in __Enumerate((__loop52_var1.Namespace).GetEnumerator()) //710:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //710:29
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //710:43
                select new { __loop52_var1 = __loop52_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //710:6
            for (int __loop52_iteration = 0; __loop52_iteration < __loop52_results.Count; ++__loop52_iteration)
            {
                var __tmp10 = __loop52_results[__loop52_iteration];
                var __loop52_var1 = __tmp10.__loop52_var1;
                var Namespace = __tmp10.Namespace;
                var Declarations = __tmp10.Declarations;
                var c = __tmp10.c;
                string __tmp11Prefix = "    "; //711:1
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
                        __out.AppendLine(false); //711:38
                    }
                }
            }
            __out.AppendLine(true); //713:1
            var __loop53_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //714:11
                select new { mobj = mobj}
                ).ToList(); //714:6
            for (int __loop53_iteration = 0; __loop53_iteration < __loop53_results.Count; ++__loop53_iteration)
            {
                var __tmp13 = __loop53_results[__loop53_iteration];
                var mobj = __tmp13.mobj;
                string __tmp14Prefix = "	"; //715:1
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
                        __out.AppendLine(false); //715:60
                    }
                }
            }
            __out.AppendLine(true); //717:1
            string __tmp17Line = "    private "; //718:1
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
            string __tmp19Line = "()"; //718:59
            if (__tmp19Line != null) __out.Append(__tmp19Line);
            __out.AppendLine(false); //718:61
            __out.Append("    {"); //719:1
            __out.AppendLine(false); //719:6
            __out.Append("		this.Model = new global::MetaDslx.Core.Immutable.MutableModel();"); //720:1
            __out.AppendLine(false); //720:67
            string __tmp20Prefix = "		"; //721:1
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
            string __tmp22Line = " factory = new "; //721:53
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
            string __tmp24Line = "(this.Model, global::MetaDslx.Core.Immutable.ModelFactoryFlags.DontMakeSymbolsCreated);"; //721:118
            if (__tmp24Line != null) __out.Append(__tmp24Line);
            __out.AppendLine(false); //721:205
            string __tmp25Prefix = "		"; //722:1
            StringBuilder __tmp26 = new StringBuilder();
            __tmp26.Append(model.Name);
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
                }
            }
            string __tmp27Line = "ImplementationProvider.Implementation."; //722:15
            if (__tmp27Line != null) __out.Append(__tmp27Line);
            StringBuilder __tmp28 = new StringBuilder();
            __tmp28.Append(model.CSharpInstancesName(ClassKind.Builder));
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
            string __tmp29Line = "(this);"; //722:99
            if (__tmp29Line != null) __out.Append(__tmp29Line);
            __out.AppendLine(false); //722:106
            __out.AppendLine(true); //723:1
            var __loop54_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //724:9
                select new { mobj = mobj}
                ).ToList(); //724:4
            for (int __loop54_iteration = 0; __loop54_iteration < __loop54_results.Count; ++__loop54_iteration)
            {
                var __tmp30 = __loop54_results[__loop54_iteration];
                var mobj = __tmp30.mobj;
                string __tmp31Prefix = "		"; //725:1
                StringBuilder __tmp32 = new StringBuilder();
                __tmp32.Append(GenerateModelObjectInstance(coreModel, mobj, mobjToName));
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
                        __out.AppendLine(false); //725:61
                    }
                }
            }
            __out.AppendLine(true); //727:1
            var __loop55_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //728:9
                select new { mobj = mobj}
                ).ToList(); //728:4
            for (int __loop55_iteration = 0; __loop55_iteration < __loop55_results.Count; ++__loop55_iteration)
            {
                var __tmp33 = __loop55_results[__loop55_iteration];
                var mobj = __tmp33.mobj;
                string __tmp34Prefix = "		"; //729:1
                StringBuilder __tmp35 = new StringBuilder();
                __tmp35.Append(GenerateModelObjectInstanceInitializer(coreModel, mobj, mobjToName));
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
                        __out.AppendLine(false); //729:72
                    }
                }
            }
            __out.AppendLine(true); //731:1
            var __loop56_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //732:9
                select new { mobj = mobj}
                ).ToList(); //732:4
            for (int __loop56_iteration = 0; __loop56_iteration < __loop56_results.Count; ++__loop56_iteration)
            {
                var __tmp36 = __loop56_results[__loop56_iteration];
                var mobj = __tmp36.mobj;
                string __tmp37Prefix = "		"; //733:1
                StringBuilder __tmp38 = new StringBuilder();
                __tmp38.Append(GenerateModelObjectInstanceFinalizer(mobj, mobjToName));
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
                        __out.AppendLine(false); //733:59
                    }
                }
            }
            __out.AppendLine(true); //735:1
            __out.Append("        this.Model.EvaluateLazyValues();"); //736:1
            __out.AppendLine(false); //736:41
            __out.Append("    }"); //737:1
            __out.AppendLine(false); //737:6
            __out.Append("}"); //738:1
            __out.AppendLine(false); //738:2
            __out.AppendLine(true); //739:1
            string __tmp40Line = "public class "; //740:1
            if (__tmp40Line != null) __out.Append(__tmp40Line);
            StringBuilder __tmp41 = new StringBuilder();
            __tmp41.Append(model.CSharpInstancesName(ClassKind.Immutable));
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
                    __out.AppendLine(false); //740:62
                }
            }
            __out.Append("{"); //741:1
            __out.AppendLine(false); //741:2
            __out.AppendLine(true); //742:1
            __out.Append("	private static bool initialized;"); //743:1
            __out.AppendLine(false); //743:34
            __out.AppendLine(true); //744:1
            __out.Append("	public static bool IsInitialized"); //745:1
            __out.AppendLine(false); //745:34
            __out.Append("	{"); //746:1
            __out.AppendLine(false); //746:3
            string __tmp43Line = "		get { return "; //747:1
            if (__tmp43Line != null) __out.Append(__tmp43Line);
            StringBuilder __tmp44 = new StringBuilder();
            __tmp44.Append(model.CSharpInstancesName(ClassKind.Immutable));
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
            string __tmp45Line = ".initialized; }"; //747:64
            if (__tmp45Line != null) __out.Append(__tmp45Line);
            __out.AppendLine(false); //747:79
            __out.Append("	}"); //748:1
            __out.AppendLine(false); //748:3
            __out.AppendLine(true); //749:1
            if (coreModel) //750:3
            {
                __out.Append("	public static readonly global::MetaDslx.Core.Immutable.MetaModel _MetaModel;"); //751:1
                __out.AppendLine(false); //751:78
            }
            else //752:3
            {
                __out.Append("	public static readonly global::MetaDslx.Core.Immutable.MetaModel MetaModel;"); //753:1
                __out.AppendLine(false); //753:77
            }
            __out.Append("	public static readonly global::MetaDslx.Core.Immutable.ImmutableModel Model;"); //755:1
            __out.AppendLine(false); //755:78
            __out.AppendLine(true); //756:1
            var __loop57_results = 
                (from __loop57_var1 in __Enumerate((model).GetEnumerator()) //757:11
                from Namespace in __Enumerate((__loop57_var1.Namespace).GetEnumerator()) //757:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //757:29
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //757:43
                select new { __loop57_var1 = __loop57_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //757:6
            for (int __loop57_iteration = 0; __loop57_iteration < __loop57_results.Count; ++__loop57_iteration)
            {
                var __tmp46 = __loop57_results[__loop57_iteration];
                var __loop57_var1 = __tmp46.__loop57_var1;
                var Namespace = __tmp46.Namespace;
                var Declarations = __tmp46.Declarations;
                var c = __tmp46.c;
                string __tmp47Prefix = "    "; //758:1
                StringBuilder __tmp48 = new StringBuilder();
                __tmp48.Append(GenerateImmutableModelConstant(model, c));
                using(StreamReader __tmp48Reader = new StreamReader(this.__ToStream(__tmp48.ToString())))
                {
                    bool __tmp48_first = true;
                    bool __tmp48_last = __tmp48Reader.EndOfStream;
                    while(__tmp48_first || !__tmp48_last)
                    {
                        __tmp48_first = false;
                        string __tmp48Line = __tmp48Reader.ReadLine();
                        __tmp48_last = __tmp48Reader.EndOfStream;
                        __out.Append(__tmp47Prefix);
                        if (__tmp48Line != null) __out.Append(__tmp48Line);
                        if (!__tmp48_last) __out.AppendLine(true);
                        __out.AppendLine(false); //758:47
                    }
                }
            }
            __out.AppendLine(true); //760:1
            var __loop58_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //761:11
                where mobjToName.ContainsKey(mobj) && !mobjToName[mobj].StartsWith("__") //761:26
                select new { mobj = mobj}
                ).ToList(); //761:6
            for (int __loop58_iteration = 0; __loop58_iteration < __loop58_results.Count; ++__loop58_iteration)
            {
                var __tmp49 = __loop58_results[__loop58_iteration];
                var mobj = __tmp49.mobj;
                string __tmp50Prefix = "	"; //762:1
                StringBuilder __tmp51 = new StringBuilder();
                __tmp51.Append(GenerateImmutableModelObjectInstanceDeclaration(model, mobj, mobjToName));
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
                        __out.AppendLine(false); //762:76
                    }
                }
            }
            __out.AppendLine(true); //764:1
            string __tmp53Line = "	static "; //765:1
            if (__tmp53Line != null) __out.Append(__tmp53Line);
            StringBuilder __tmp54 = new StringBuilder();
            __tmp54.Append(model.CSharpInstancesName(ClassKind.Immutable));
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
            string __tmp55Line = "()"; //765:57
            if (__tmp55Line != null) __out.Append(__tmp55Line);
            __out.AppendLine(false); //765:59
            __out.Append("	{"); //766:1
            __out.AppendLine(false); //766:3
            string __tmp56Prefix = "		"; //767:1
            StringBuilder __tmp57 = new StringBuilder();
            __tmp57.Append(model.CSharpInstancesName(ClassKind.Immutable));
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
                }
            }
            string __tmp58Line = ".Model = "; //767:51
            if (__tmp58Line != null) __out.Append(__tmp58Line);
            StringBuilder __tmp59 = new StringBuilder();
            __tmp59.Append(model.CSharpInstancesName(ClassKind.Builder));
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
            string __tmp60Line = ".instance.Model.ToImmutable();"; //767:106
            if (__tmp60Line != null) __out.Append(__tmp60Line);
            __out.AppendLine(false); //767:136
            string __tmp62Line = "		global::MetaDslx.Core.Immutable.ImmutableModel model = "; //768:1
            if (__tmp62Line != null) __out.Append(__tmp62Line);
            StringBuilder __tmp63 = new StringBuilder();
            __tmp63.Append(model.CSharpInstancesName(ClassKind.Immutable));
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
            string __tmp64Line = ".Model;"; //768:106
            if (__tmp64Line != null) __out.Append(__tmp64Line);
            __out.AppendLine(false); //768:113
            if (coreModel) //769:4
            {
                string __tmp65Prefix = "		"; //770:1
                StringBuilder __tmp66 = new StringBuilder();
                __tmp66.Append(model.CSharpInstancesName(ClassKind.Immutable));
                using(StreamReader __tmp66Reader = new StreamReader(this.__ToStream(__tmp66.ToString())))
                {
                    bool __tmp66_first = true;
                    bool __tmp66_last = __tmp66Reader.EndOfStream;
                    while(__tmp66_first || !__tmp66_last)
                    {
                        __tmp66_first = false;
                        string __tmp66Line = __tmp66Reader.ReadLine();
                        __tmp66_last = __tmp66Reader.EndOfStream;
                        __out.Append(__tmp65Prefix);
                        if (__tmp66Line != null) __out.Append(__tmp66Line);
                        if (!__tmp66_last) __out.AppendLine(true);
                    }
                }
                string __tmp67Line = "._MetaModel = "; //770:51
                if (__tmp67Line != null) __out.Append(__tmp67Line);
                StringBuilder __tmp68 = new StringBuilder();
                __tmp68.Append(model.CSharpInstancesName(ClassKind.Builder));
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
                string __tmp69Line = ".instance._MetaModel.ToImmutable(model);"; //770:111
                if (__tmp69Line != null) __out.Append(__tmp69Line);
                __out.AppendLine(false); //770:151
            }
            else //771:4
            {
                string __tmp70Prefix = "		"; //772:1
                StringBuilder __tmp71 = new StringBuilder();
                __tmp71.Append(model.CSharpInstancesName(ClassKind.Immutable));
                using(StreamReader __tmp71Reader = new StreamReader(this.__ToStream(__tmp71.ToString())))
                {
                    bool __tmp71_first = true;
                    bool __tmp71_last = __tmp71Reader.EndOfStream;
                    while(__tmp71_first || !__tmp71_last)
                    {
                        __tmp71_first = false;
                        string __tmp71Line = __tmp71Reader.ReadLine();
                        __tmp71_last = __tmp71Reader.EndOfStream;
                        __out.Append(__tmp70Prefix);
                        if (__tmp71Line != null) __out.Append(__tmp71Line);
                        if (!__tmp71_last) __out.AppendLine(true);
                    }
                }
                string __tmp72Line = ".MetaModel = "; //772:51
                if (__tmp72Line != null) __out.Append(__tmp72Line);
                StringBuilder __tmp73 = new StringBuilder();
                __tmp73.Append(model.CSharpInstancesName(ClassKind.Builder));
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
                string __tmp74Line = ".instance.MetaModel.ToImmutable(model);"; //772:110
                if (__tmp74Line != null) __out.Append(__tmp74Line);
                __out.AppendLine(false); //772:149
            }
            __out.AppendLine(true); //774:1
            var __loop59_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //775:9
                where mobjToName.ContainsKey(mobj) && !mobjToName[mobj].StartsWith("__") //775:24
                select new { mobj = mobj}
                ).ToList(); //775:4
            for (int __loop59_iteration = 0; __loop59_iteration < __loop59_results.Count; ++__loop59_iteration)
            {
                var __tmp75 = __loop59_results[__loop59_iteration];
                var mobj = __tmp75.mobj;
                string __tmp76Prefix = "		"; //776:1
                StringBuilder __tmp77 = new StringBuilder();
                __tmp77.Append(GenerateImmutableModelObjectInstanceDeclarationInitializer(model, mobj, mobjToName));
                using(StreamReader __tmp77Reader = new StreamReader(this.__ToStream(__tmp77.ToString())))
                {
                    bool __tmp77_first = true;
                    bool __tmp77_last = __tmp77Reader.EndOfStream;
                    while(__tmp77_first || !__tmp77_last)
                    {
                        __tmp77_first = false;
                        string __tmp77Line = __tmp77Reader.ReadLine();
                        __tmp77_last = __tmp77Reader.EndOfStream;
                        __out.Append(__tmp76Prefix);
                        if (__tmp77Line != null) __out.Append(__tmp77Line);
                        if (!__tmp77_last) __out.AppendLine(true);
                        __out.AppendLine(false); //776:88
                    }
                }
            }
            __out.AppendLine(true); //778:1
            string __tmp78Prefix = "		"; //779:1
            StringBuilder __tmp79 = new StringBuilder();
            __tmp79.Append(model.CSharpInstancesName(ClassKind.Immutable));
            using(StreamReader __tmp79Reader = new StreamReader(this.__ToStream(__tmp79.ToString())))
            {
                bool __tmp79_first = true;
                bool __tmp79_last = __tmp79Reader.EndOfStream;
                while(__tmp79_first || !__tmp79_last)
                {
                    __tmp79_first = false;
                    string __tmp79Line = __tmp79Reader.ReadLine();
                    __tmp79_last = __tmp79Reader.EndOfStream;
                    __out.Append(__tmp78Prefix);
                    if (__tmp79Line != null) __out.Append(__tmp79Line);
                    if (!__tmp79_last) __out.AppendLine(true);
                }
            }
            string __tmp80Line = ".initialized = true;"; //779:51
            if (__tmp80Line != null) __out.Append(__tmp80Line);
            __out.AppendLine(false); //779:71
            __out.Append("	}"); //780:1
            __out.AppendLine(false); //780:3
            __out.Append("}"); //781:1
            __out.AppendLine(false); //781:2
            return __out.ToString();
        }

        public string GenerateImmutableModelConstant(MetaModel model, MetaConstant mconst) //784:1
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
                    __out.AppendLine(false); //785:32
                }
            }
            string __tmp4Line = "public static readonly "; //786:1
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
            string __tmp6Line = " "; //786:73
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
            string __tmp8Line = " = "; //786:87
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
            string __tmp10Line = ".instance."; //786:136
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
            string __tmp12Line = ".ToImmutable();"; //786:159
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //786:174
            return __out.ToString();
        }

        public string GenerateModelConstant(MetaModel model, MetaConstant mconst) //789:1
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
                    __out.AppendLine(false); //790:32
                }
            }
            string __tmp4Line = "internal "; //791:1
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
            string __tmp6Line = " "; //791:57
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
            string __tmp8Line = " = null;"; //791:71
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //791:79
            return __out.ToString();
        }

        public string GenerateImmutableModelObjectInstanceDeclaration(MetaModel model, ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //794:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //795:2
            {
                if (mobjToName.ContainsKey(mobj)) //796:3
                {
                    if (!mobjToName[mobj].StartsWith("__")) //797:4
                    {
                        string name = mobjToName[mobj]; //798:2
                        if (mobj is MetaDocumentedElement) //799:5
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
                                    __out.AppendLine(false); //800:55
                                }
                            }
                        }
                        string __tmp4Line = "public static readonly global::MetaDslx.Core.Immutable."; //802:1
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
                        string __tmp6Line = " "; //802:105
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
                        string __tmp8Line = ";"; //802:112
                        if (__tmp8Line != null) __out.Append(__tmp8Line);
                        __out.AppendLine(false); //802:113
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateImmutableModelObjectInstanceDeclarationInitializer(MetaModel model, ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //808:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //809:2
            {
                if (mobjToName.ContainsKey(mobj)) //810:3
                {
                    if (!mobjToName[mobj].StartsWith("__")) //811:4
                    {
                        string name = mobjToName[mobj]; //812:2
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
                        string __tmp3Line = "."; //813:49
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
                        string __tmp5Line = " = "; //813:56
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
                        string __tmp7Line = ".instance."; //813:105
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
                        string __tmp9Line = ".ToImmutable(model);"; //813:121
                        if (__tmp9Line != null) __out.Append(__tmp9Line);
                        __out.AppendLine(false); //813:141
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceDeclaration(ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //819:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //820:2
            {
                if (mobjToName.ContainsKey(mobj)) //821:3
                {
                    string name = mobjToName[mobj]; //822:4
                    if (name.StartsWith("__")) //823:4
                    {
                        string __tmp2Line = "private readonly global::MetaDslx.Core.Immutable."; //824:1
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
                        string __tmp4Line = " "; //824:97
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
                        string __tmp6Line = ";"; //824:104
                        if (__tmp6Line != null) __out.Append(__tmp6Line);
                        __out.AppendLine(false); //824:105
                    }
                    else //825:4
                    {
                        string __tmp8Line = "internal readonly global::MetaDslx.Core.Immutable."; //826:1
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
                        string __tmp10Line = " "; //826:98
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
                        string __tmp12Line = ";"; //826:105
                        if (__tmp12Line != null) __out.Append(__tmp12Line);
                        __out.AppendLine(false); //826:106
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstance(bool coreModel, ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //832:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //833:2
            {
                if (mobjToName.ContainsKey(mobj)) //834:3
                {
                    string name = mobjToName[mobj]; //835:4
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
                    string __tmp3Line = " = factory."; //836:7
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
                    string __tmp5Line = "();"; //836:48
                    if (__tmp5Line != null) __out.Append(__tmp5Line);
                    __out.AppendLine(false); //836:51
                    if (mobj is MetaModel) //837:4
                    {
                        if (coreModel) //838:5
                        {
                            string __tmp7Line = "_MetaModel = "; //839:1
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
                            string __tmp9Line = ";"; //839:20
                            if (__tmp9Line != null) __out.Append(__tmp9Line);
                            __out.AppendLine(false); //839:21
                        }
                        else //840:5
                        {
                            string __tmp11Line = "MetaModel = "; //841:1
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
                            string __tmp13Line = ";"; //841:19
                            if (__tmp13Line != null) __out.Append(__tmp13Line);
                            __out.AppendLine(false); //841:20
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceInitializer(bool coreModel, ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //848:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //849:2
            {
                if (mobjToName.ContainsKey(mobj)) //850:3
                {
                    var __loop60_results = 
                        (from __loop60_var1 in __Enumerate((mobj).GetEnumerator()) //851:9
                        from prop in __Enumerate((__loop60_var1.MGetProperties()).GetEnumerator()) //851:15
                        where !prop.IsReadonly //851:37
                        select new { __loop60_var1 = __loop60_var1, prop = prop}
                        ).ToList(); //851:4
                    for (int __loop60_iteration = 0; __loop60_iteration < __loop60_results.Count; ++__loop60_iteration)
                    {
                        var __tmp1 = __loop60_results[__loop60_iteration];
                        var __loop60_var1 = __tmp1.__loop60_var1;
                        var prop = __tmp1.prop;
                        if (prop.MetaProperty != null && prop.MetaProperty.Kind != MetaPropertyKind.Derived) //852:5
                        {
                            object propValue = mobj.MGet(prop); //853:6
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
                                    __out.AppendLine(false); //854:81
                                }
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceFinalizer(ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //861:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //862:2
            {
                if (mobjToName.ContainsKey(mobj)) //863:3
                {
                    string name = mobjToName[mobj]; //864:4
                    string __tmp2Line = "((global::MetaDslx.Core.Immutable.MutableSymbolBase)"; //865:1
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
                    string __tmp4Line = ").MMakeCreated();"; //865:59
                    if (__tmp4Line != null) __out.Append(__tmp4Line);
                    __out.AppendLine(false); //865:76
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectPropertyValue(bool coreModel, ModelObject mobj, ModelProperty prop, object value, Dictionary<ModelObject,string> mobjToName) //870:1
        {
            StringBuilder __out = new StringBuilder();
            string name = mobjToName[mobj]; //871:2
            ModelObject moValue = value as ModelObject; //872:2
            if (value == null) //873:2
            {
                if (prop.Type != null && prop.Type.IsClass) //874:3
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
                    string __tmp3Line = "."; //875:7
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
                    string __tmp5Line = " = null;"; //875:19
                    if (__tmp5Line != null) __out.Append(__tmp5Line);
                    __out.AppendLine(false); //875:27
                }
                else //876:3
                {
                    string __tmp7Line = "// "; //877:1
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
                    string __tmp9Line = "."; //877:10
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
                    string __tmp11Line = " = null;"; //877:22
                    if (__tmp11Line != null) __out.Append(__tmp11Line);
                    __out.AppendLine(false); //877:30
                }
            }
            else if (value is string) //879:2
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
                string __tmp14Line = "."; //880:7
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
                string __tmp16Line = " = \""; //880:19
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
                string __tmp18Line = "\";"; //880:30
                if (__tmp18Line != null) __out.Append(__tmp18Line);
                __out.AppendLine(false); //880:32
            }
            else if (value is bool) //881:2
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
                string __tmp21Line = "."; //882:7
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
                string __tmp23Line = " = "; //882:19
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
                string __tmp25Line = ";"; //882:50
                if (__tmp25Line != null) __out.Append(__tmp25Line);
                __out.AppendLine(false); //882:51
            }
            else if (value.GetType().IsPrimitive) //883:2
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
                string __tmp28Line = "."; //884:7
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
                string __tmp30Line = " = "; //884:19
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
                string __tmp32Line = ";"; //884:40
                if (__tmp32Line != null) __out.Append(__tmp32Line);
                __out.AppendLine(false); //884:41
            }
            else if (MetaBuiltInTypes.Types.Contains(value)) //885:2
            {
                if (coreModel) //886:3
                {
                    if (mobjToName.ContainsKey(moValue)) //887:4
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
                        string __tmp35Line = "."; //888:7
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
                        string __tmp37Line = "Lazy = () => "; //888:19
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
                        string __tmp39Line = ";"; //888:53
                        if (__tmp39Line != null) __out.Append(__tmp39Line);
                        __out.AppendLine(false); //888:54
                    }
                    else //889:4
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
                        string __tmp42Line = "."; //890:7
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
                        string __tmp44Line = "Lazy = () => this."; //890:19
                        if (__tmp44Line != null) __out.Append(__tmp44Line);
                        StringBuilder __tmp45 = new StringBuilder();
                        __tmp45.Append(((MetaPrimitiveType)moValue).Name.ToPascalCase());
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
                        string __tmp46Line = ";"; //890:87
                        if (__tmp46Line != null) __out.Append(__tmp46Line);
                        __out.AppendLine(false); //890:88
                    }
                }
                else //892:3
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
                    string __tmp49Line = "."; //893:7
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
                    string __tmp51Line = " = "; //893:19
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
                    string __tmp53Line = ";"; //893:45
                    if (__tmp53Line != null) __out.Append(__tmp53Line);
                    __out.AppendLine(false); //893:46
                }
            }
            else if (value is MetaPrimitiveType) //895:2
            {
                if (coreModel) //896:3
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
                    string __tmp56Line = "."; //897:7
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
                    string __tmp58Line = "Lazy = () => "; //897:19
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
                    string __tmp60Line = ";"; //897:53
                    if (__tmp60Line != null) __out.Append(__tmp60Line);
                    __out.AppendLine(false); //897:54
                }
                else //898:3
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
                    string __tmp63Line = "."; //899:7
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
                    string __tmp65Line = " = "; //899:19
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
                    string __tmp67Line = ";"; //899:45
                    if (__tmp67Line != null) __out.Append(__tmp67Line);
                    __out.AppendLine(false); //899:46
                }
            }
            else if (value is Enum) //901:2
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
                string __tmp70Line = "."; //902:7
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
                string __tmp72Line = " = "; //902:19
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
                string __tmp74Line = ";"; //902:45
                if (__tmp74Line != null) __out.Append(__tmp74Line);
                __out.AppendLine(false); //902:46
            }
            else if (moValue != null) //903:2
            {
                if (mobjToName.ContainsKey(moValue)) //904:3
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
                    string __tmp77Line = "."; //905:7
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
                    string __tmp79Line = "Lazy = () => "; //905:19
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
                    string __tmp81Line = ";"; //905:53
                    if (__tmp81Line != null) __out.Append(__tmp81Line);
                    __out.AppendLine(false); //905:54
                }
                else //906:3
                {
                    string __tmp83Line = "// Omitted since not part of the model: "; //907:1
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
                    string __tmp85Line = "."; //907:47
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
                    string __tmp87Line = " = "; //907:59
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
                            __out.AppendLine(false); //907:71
                        }
                    }
                }
            }
            else //909:2
            {
                IEnumerable<object> mc = (value as ModelCollection) as IEnumerable<object>; //910:3
                if (mc != null) //911:3
                {
                    var __loop61_results = 
                        (from cvalue in __Enumerate((mc).GetEnumerator()) //912:9
                        select new { cvalue = cvalue}
                        ).ToList(); //912:4
                    for (int __loop61_iteration = 0; __loop61_iteration < __loop61_results.Count; ++__loop61_iteration)
                    {
                        var __tmp89 = __loop61_results[__loop61_iteration];
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
                                __out.AppendLine(false); //913:88
                            }
                        }
                    }
                }
                else //915:3
                {
                    string __tmp93Line = "// Invalid property value type: "; //916:1
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
                    string __tmp95Line = "."; //916:39
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
                    string __tmp97Line = " = "; //916:51
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
                            __out.AppendLine(false); //916:71
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectPropertyCollectionValue(bool coreModel, ModelObject mobj, ModelProperty prop, object value, Dictionary<ModelObject,string> mobjToName) //921:1
        {
            StringBuilder __out = new StringBuilder();
            string name = mobjToName[mobj]; //922:2
            ModelObject moValue = value as ModelObject; //923:2
            if (value == null) //924:2
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
                string __tmp3Line = "."; //925:7
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
                string __tmp5Line = ".Add(null);"; //925:19
                if (__tmp5Line != null) __out.Append(__tmp5Line);
                __out.AppendLine(false); //925:30
            }
            else if (value is string) //926:2
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
                string __tmp8Line = "."; //927:7
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
                string __tmp10Line = ".Add(\""; //927:19
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
                string __tmp12Line = "\");"; //927:32
                if (__tmp12Line != null) __out.Append(__tmp12Line);
                __out.AppendLine(false); //927:35
            }
            else if (value is bool) //928:2
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
                string __tmp15Line = "."; //929:7
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
                string __tmp17Line = ".Add("; //929:19
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
                string __tmp19Line = ");"; //929:52
                if (__tmp19Line != null) __out.Append(__tmp19Line);
                __out.AppendLine(false); //929:54
            }
            else if (value.GetType().IsPrimitive) //930:2
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
                string __tmp22Line = "."; //931:7
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
                string __tmp24Line = ".Add("; //931:19
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
                string __tmp26Line = ");"; //931:42
                if (__tmp26Line != null) __out.Append(__tmp26Line);
                __out.AppendLine(false); //931:44
            }
            else if (MetaBuiltInTypes.Types.Contains(value)) //932:2
            {
                if (coreModel) //933:3
                {
                    if (mobjToName.ContainsKey(moValue)) //934:4
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
                        string __tmp29Line = "."; //935:7
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
                        string __tmp31Line = ".AddLazy(() => "; //935:19
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
                        string __tmp33Line = ");"; //935:55
                        if (__tmp33Line != null) __out.Append(__tmp33Line);
                        __out.AppendLine(false); //935:57
                    }
                    else //936:4
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
                        string __tmp36Line = "."; //937:7
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
                        string __tmp38Line = ".AddLazy(() => this."; //937:19
                        if (__tmp38Line != null) __out.Append(__tmp38Line);
                        StringBuilder __tmp39 = new StringBuilder();
                        __tmp39.Append(((MetaPrimitiveType)value).Name.ToPascalCase());
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
                        string __tmp40Line = ");"; //937:87
                        if (__tmp40Line != null) __out.Append(__tmp40Line);
                        __out.AppendLine(false); //937:89
                    }
                }
                else //939:3
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
                    string __tmp43Line = "."; //940:7
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
                    string __tmp45Line = ".Add("; //940:19
                    if (__tmp45Line != null) __out.Append(__tmp45Line);
                    StringBuilder __tmp46 = new StringBuilder();
                    __tmp46.Append(GenerateTypeOf(value));
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
                    string __tmp47Line = ");"; //940:47
                    if (__tmp47Line != null) __out.Append(__tmp47Line);
                    __out.AppendLine(false); //940:49
                }
            }
            else if (value is MetaPrimitiveType) //942:2
            {
                if (coreModel) //943:3
                {
                    if (mobjToName.ContainsKey(moValue)) //944:4
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
                        string __tmp50Line = "."; //945:7
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
                        string __tmp52Line = ".AddLazy(() => "; //945:19
                        if (__tmp52Line != null) __out.Append(__tmp52Line);
                        StringBuilder __tmp53 = new StringBuilder();
                        __tmp53.Append(mobjToName[moValue]);
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
                        string __tmp54Line = ");"; //945:55
                        if (__tmp54Line != null) __out.Append(__tmp54Line);
                        __out.AppendLine(false); //945:57
                    }
                    else //946:4
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
                        string __tmp57Line = "."; //947:7
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
                        string __tmp59Line = ".AddLazy(() => this."; //947:19
                        if (__tmp59Line != null) __out.Append(__tmp59Line);
                        StringBuilder __tmp60 = new StringBuilder();
                        __tmp60.Append(((MetaPrimitiveType)value).Name.ToPascalCase());
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
                        string __tmp61Line = ");"; //947:87
                        if (__tmp61Line != null) __out.Append(__tmp61Line);
                        __out.AppendLine(false); //947:89
                    }
                }
                else //949:3
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
                    string __tmp64Line = "."; //950:7
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
                    string __tmp66Line = ".Add("; //950:19
                    if (__tmp66Line != null) __out.Append(__tmp66Line);
                    StringBuilder __tmp67 = new StringBuilder();
                    __tmp67.Append(GenerateTypeOf(value));
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
                    string __tmp68Line = ");"; //950:47
                    if (__tmp68Line != null) __out.Append(__tmp68Line);
                    __out.AppendLine(false); //950:49
                }
            }
            else if (value is Enum) //952:2
            {
                StringBuilder __tmp70 = new StringBuilder();
                __tmp70.Append(name);
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
                string __tmp71Line = "."; //953:7
                if (__tmp71Line != null) __out.Append(__tmp71Line);
                StringBuilder __tmp72 = new StringBuilder();
                __tmp72.Append(prop.Name);
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
                string __tmp73Line = ".Add("; //953:19
                if (__tmp73Line != null) __out.Append(__tmp73Line);
                StringBuilder __tmp74 = new StringBuilder();
                __tmp74.Append(GetEnumValueOf(value));
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
                string __tmp75Line = ");"; //953:47
                if (__tmp75Line != null) __out.Append(__tmp75Line);
                __out.AppendLine(false); //953:49
            }
            else if (moValue != null) //954:2
            {
                if (mobjToName.ContainsKey(moValue)) //955:3
                {
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
                    string __tmp78Line = "."; //956:7
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
                    string __tmp80Line = ".AddLazy(() => "; //956:19
                    if (__tmp80Line != null) __out.Append(__tmp80Line);
                    StringBuilder __tmp81 = new StringBuilder();
                    __tmp81.Append(mobjToName[moValue]);
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
                    string __tmp82Line = ");"; //956:55
                    if (__tmp82Line != null) __out.Append(__tmp82Line);
                    __out.AppendLine(false); //956:57
                }
                else //957:3
                {
                    string __tmp84Line = "// Omitted since not part of the model: "; //958:1
                    if (__tmp84Line != null) __out.Append(__tmp84Line);
                    StringBuilder __tmp85 = new StringBuilder();
                    __tmp85.Append(name);
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
                        }
                    }
                    string __tmp86Line = "."; //958:47
                    if (__tmp86Line != null) __out.Append(__tmp86Line);
                    StringBuilder __tmp87 = new StringBuilder();
                    __tmp87.Append(prop.Name);
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
                    string __tmp88Line = " = "; //958:59
                    if (__tmp88Line != null) __out.Append(__tmp88Line);
                    StringBuilder __tmp89 = new StringBuilder();
                    __tmp89.Append(moValue);
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
                            __out.AppendLine(false); //958:71
                        }
                    }
                }
            }
            else //960:2
            {
                IEnumerable<object> mc = (value as ModelCollection) as IEnumerable<object>; //961:3
                if (mc != null) //962:3
                {
                    var __loop62_results = 
                        (from cvalue in __Enumerate((mc).GetEnumerator()) //963:9
                        select new { cvalue = cvalue}
                        ).ToList(); //963:4
                    for (int __loop62_iteration = 0; __loop62_iteration < __loop62_results.Count; ++__loop62_iteration)
                    {
                        var __tmp90 = __loop62_results[__loop62_iteration];
                        var cvalue = __tmp90.cvalue;
                        StringBuilder __tmp92 = new StringBuilder();
                        __tmp92.Append(GenerateModelObjectPropertyCollectionValue(coreModel, mobj, prop, cvalue, mobjToName));
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
                                __out.AppendLine(false); //964:88
                            }
                        }
                    }
                }
                else //966:3
                {
                    string __tmp94Line = "// Invalid property value type: "; //967:1
                    if (__tmp94Line != null) __out.Append(__tmp94Line);
                    StringBuilder __tmp95 = new StringBuilder();
                    __tmp95.Append(name);
                    using(StreamReader __tmp95Reader = new StreamReader(this.__ToStream(__tmp95.ToString())))
                    {
                        bool __tmp95_first = true;
                        bool __tmp95_last = __tmp95Reader.EndOfStream;
                        while(__tmp95_first || !__tmp95_last)
                        {
                            __tmp95_first = false;
                            string __tmp95Line = __tmp95Reader.ReadLine();
                            __tmp95_last = __tmp95Reader.EndOfStream;
                            if (__tmp95Line != null) __out.Append(__tmp95Line);
                            if (!__tmp95_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp96Line = "."; //967:39
                    if (__tmp96Line != null) __out.Append(__tmp96Line);
                    StringBuilder __tmp97 = new StringBuilder();
                    __tmp97.Append(prop.Name);
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
                    string __tmp98Line = " = "; //967:51
                    if (__tmp98Line != null) __out.Append(__tmp98Line);
                    StringBuilder __tmp99 = new StringBuilder();
                    __tmp99.Append(value.GetType());
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
                            __out.AppendLine(false); //967:71
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GetEnumValueOf(object enm) //972:1
        {
            string result = "global::" + enm.GetType().FullName.Replace("+", ".") + "." + enm.ToString(); //973:2
            if (!result.StartsWith("global::MetaDslx.Core.Immutable.") && result.StartsWith("global::MetaDslx.Core.")) //974:2
            {
                result = result.Replace("global::MetaDslx.Core.", "global::MetaDslx.Core.Immutable."); //975:3
            }
            return result; //977:2
        }

        public string GenerateTypeOf(object expr) //980:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //981:9
            if (expr is MetaPrimitiveType) //982:2
            {
                var __tmp2 = ((MetaPrimitiveType)expr).Name; //983:9
                if (__tmp2 == "*none*") //984:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.None.ToMutable() : null"); //984:17
                }
                else if (__tmp2 == "*error*") //985:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Error.ToMutable() : null"); //985:18
                }
                else if (__tmp2 == "*any*") //986:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Any.ToMutable() : null"); //986:16
                }
                else if (__tmp2 == "object") //987:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Object.ToMutable() : null"); //987:17
                }
                else if (__tmp2 == "string") //988:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.String.ToMutable() : null"); //988:17
                }
                else if (__tmp2 == "int") //989:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Int.ToMutable() : null"); //989:14
                }
                else if (__tmp2 == "long") //990:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Long.ToMutable() : null"); //990:15
                }
                else if (__tmp2 == "float") //991:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Float.ToMutable() : null"); //991:16
                }
                else if (__tmp2 == "double") //992:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Double.ToMutable() : null"); //992:17
                }
                else if (__tmp2 == "byte") //993:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Byte.ToMutable() : null"); //993:15
                }
                else if (__tmp2 == "bool") //994:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Bool.ToMutable() : null"); //994:15
                }
                else if (__tmp2 == "void") //995:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Void.ToMutable() : null"); //995:15
                }
                else if (__tmp2 == "ModelObject") //996:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.ModelObject.ToMutable() : null"); //996:22
                }
                else if (__tmp2 == "ModelObjectList") //997:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.ModelObjectList.ToMutable() : null"); //997:26
                }
                else if (__tmp2 == "DefinitionList") //998:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.DefinitionList.ToMutable() : null"); //998:25
                }//999:2
            }
            else if (expr is MetaClass) //1000:2
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
                string __tmp6Line = ".MetaClass"; //1000:73
                if (__tmp6Line != null) __out.Append(__tmp6Line);
            }
            else if (expr is MetaCollectionType) //1001:2
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
            else //1002:2
            {
                __out.Append("***error***"); //1002:11
            }//1003:2
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

