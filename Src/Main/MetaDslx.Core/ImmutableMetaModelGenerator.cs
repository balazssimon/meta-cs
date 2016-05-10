using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core //1:1
{
    using __Hidden_ImmutableMetaModelGenerator_416761282;
    namespace __Hidden_ImmutableMetaModelGenerator_416761282
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
            __out.AppendLine(true); //13:1
            var __loop1_results = 
                (from __loop1_var1 in __Enumerate((Instances).GetEnumerator()) //14:8
                from mm in __Enumerate((__loop1_var1).GetEnumerator()).OfType<MetaModel>() //14:19
                select new { __loop1_var1 = __loop1_var1, mm = mm}
                ).ToList(); //14:3
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
                        __out.AppendLine(false); //15:24
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateMetamodel(MetaModel model) //19:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "namespace "; //20:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.Namespace.CSharpName());
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
                    __out.AppendLine(false); //20:41
                }
            }
            __out.Append("{"); //21:1
            __out.AppendLine(false); //21:2
            string __tmp4Prefix = "    "; //22:1
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
                    __out.AppendLine(false); //22:41
                }
            }
            var __loop2_results = 
                (from __loop2_var1 in __Enumerate((model).GetEnumerator()) //23:8
                from Namespace in __Enumerate((__loop2_var1.Namespace).GetEnumerator()) //23:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //23:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //23:40
                select new { __loop2_var1 = __loop2_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //23:3
            int __loop2_iteration = 0;
            foreach (var __tmp6 in __loop2_results)
            {
                ++__loop2_iteration;
                var __loop2_var1 = __tmp6.__loop2_var1;
                var Namespace = __tmp6.Namespace;
                var Declarations = __tmp6.Declarations;
                var enm = __tmp6.enm;
                string __tmp7Prefix = "    "; //24:1
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
                        __out.AppendLine(false); //24:24
                    }
                }
            }
            var __loop3_results = 
                (from __loop3_var1 in __Enumerate((model).GetEnumerator()) //26:8
                from Namespace in __Enumerate((__loop3_var1.Namespace).GetEnumerator()) //26:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //26:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //26:40
                select new { __loop3_var1 = __loop3_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //26:3
            int __loop3_iteration = 0;
            foreach (var __tmp9 in __loop3_results)
            {
                ++__loop3_iteration;
                var __loop3_var1 = __tmp9.__loop3_var1;
                var Namespace = __tmp9.Namespace;
                var Declarations = __tmp9.Declarations;
                var cls = __tmp9.cls;
                string __tmp10Prefix = "    "; //27:1
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
                        __out.AppendLine(false); //27:38
                    }
                }
            }
            var __loop4_results = 
                (from __loop4_var1 in __Enumerate((model).GetEnumerator()) //29:8
                from Namespace in __Enumerate((__loop4_var1.Namespace).GetEnumerator()) //29:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //29:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //29:40
                select new { __loop4_var1 = __loop4_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //29:3
            int __loop4_iteration = 0;
            foreach (var __tmp12 in __loop4_results)
            {
                ++__loop4_iteration;
                var __loop4_var1 = __tmp12.__loop4_var1;
                var Namespace = __tmp12.Namespace;
                var Declarations = __tmp12.Declarations;
                var cls = __tmp12.cls;
                string __tmp13Prefix = "    "; //30:1
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
                        __out.AppendLine(false); //30:36
                    }
                }
            }
            var __loop5_results = 
                (from __loop5_var1 in __Enumerate((model).GetEnumerator()) //32:8
                from Namespace in __Enumerate((__loop5_var1.Namespace).GetEnumerator()) //32:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //32:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //32:40
                select new { __loop5_var1 = __loop5_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //32:3
            int __loop5_iteration = 0;
            foreach (var __tmp15 in __loop5_results)
            {
                ++__loop5_iteration;
                var __loop5_var1 = __tmp15.__loop5_var1;
                var Namespace = __tmp15.Namespace;
                var Declarations = __tmp15.Declarations;
                var cls = __tmp15.cls;
                string __tmp16Prefix = "    "; //33:1
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
                        __out.AppendLine(false); //33:49
                    }
                }
            }
            var __loop6_results = 
                (from __loop6_var1 in __Enumerate((model).GetEnumerator()) //35:8
                from Namespace in __Enumerate((__loop6_var1.Namespace).GetEnumerator()) //35:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //35:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //35:40
                select new { __loop6_var1 = __loop6_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //35:3
            int __loop6_iteration = 0;
            foreach (var __tmp18 in __loop6_results)
            {
                ++__loop6_iteration;
                var __loop6_var1 = __tmp18.__loop6_var1;
                var Namespace = __tmp18.Namespace;
                var Declarations = __tmp18.Declarations;
                var cls = __tmp18.cls;
                string __tmp19Prefix = "    "; //36:1
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
                        __out.AppendLine(false); //36:47
                    }
                }
            }
            string __tmp21Prefix = "    "; //38:1
            StringBuilder __tmp22 = new StringBuilder();
            __tmp22.Append(GenerateFactory(model));
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
                    __out.AppendLine(false); //38:29
                }
            }
            string __tmp23Prefix = "    "; //39:1
            StringBuilder __tmp24 = new StringBuilder();
            __tmp24.Append(GenerateImplementationProvider(model));
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
                    __out.AppendLine(false); //39:44
                }
            }
            __out.Append("}"); //40:1
            __out.AppendLine(false); //40:2
            return __out.ToString();
        }

        public string GenerateAnnotations(MetaAnnotatedElement elem) //43:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop7_results = 
                (from __loop7_var1 in __Enumerate((elem).GetEnumerator()) //44:7
                from annot in __Enumerate((__loop7_var1.Annotations).GetEnumerator()) //44:13
                select new { __loop7_var1 = __loop7_var1, annot = annot}
                ).ToList(); //44:2
            int __loop7_iteration = 0;
            foreach (var __tmp1 in __loop7_results)
            {
                ++__loop7_iteration;
                var __loop7_var1 = __tmp1.__loop7_var1;
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
                        __out.AppendLine(false); //45:23
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateEnum(MetaEnum enm) //49:1
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
                    __out.AppendLine(false); //50:27
                }
            }
            string __tmp4Line = "public enum "; //51:1
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
                    __out.AppendLine(false); //51:31
                }
            }
            __out.Append("{"); //52:1
            __out.AppendLine(false); //52:2
            var __loop8_results = 
                (from __loop8_var1 in __Enumerate((enm).GetEnumerator()) //53:11
                from value in __Enumerate((__loop8_var1.EnumLiterals).GetEnumerator()) //53:16
                select new { __loop8_var1 = __loop8_var1, value = value}
                ).ToList(); //53:6
            int __loop8_iteration = 0;
            foreach (var __tmp6 in __loop8_results)
            {
                ++__loop8_iteration;
                var __loop8_var1 = __tmp6.__loop8_var1;
                var value = __tmp6.value;
                string __tmp7Prefix = "    "; //54:1
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
                string __tmp9Line = ","; //54:17
                if (__tmp9Line != null) __out.Append(__tmp9Line);
                __out.AppendLine(false); //54:18
            }
            __out.Append("}"); //56:1
            __out.AppendLine(false); //56:2
            __out.AppendLine(true); //57:1
            return __out.ToString();
        }

        public string GetAncestors(MetaClass cls, ClassKind classKind) //60:1
        {
            string result = ""; //61:2
            var __loop9_results = 
                (from __loop9_var1 in __Enumerate((cls).GetEnumerator()) //62:7
                from super in __Enumerate((__loop9_var1.SuperClasses).GetEnumerator()) //62:12
                select new { __loop9_var1 = __loop9_var1, super = super}
                ).ToList(); //62:2
            int __loop9_iteration = 0;
            string delim = " : "; //62:32
            foreach (var __tmp1 in __loop9_results)
            {
                ++__loop9_iteration;
                if (__loop9_iteration >= 2) //62:54
                {
                    delim = ", "; //62:54
                }
                var __loop9_var1 = __tmp1.__loop9_var1;
                var super = __tmp1.super;
                result += delim + super.CSharpFullName(classKind); //63:3
            }
            if (result == "") //65:2
            {
                result = "global::MetaDslx.Core.Immutable.RedSymbol"; //66:3
            }
            return result; //68:2
        }

        public string GenerateImmutableInterface(MetaClass cls) //71:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(GenerateAnnotations(cls));
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
                    __out.AppendLine(false); //72:27
                }
            }
            string __tmp4Line = "public interface "; //73:1
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(cls.CSharpName(ClassKind.Immutable));
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
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(GetAncestors(cls, ClassKind.Immutable));
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
                    __out.AppendLine(false); //73:95
                }
            }
            __out.Append("{"); //74:1
            __out.AppendLine(false); //74:2
            var __loop10_results = 
                (from __loop10_var1 in __Enumerate((cls).GetEnumerator()) //75:11
                from prop in __Enumerate((__loop10_var1.Properties).GetEnumerator()) //75:16
                select new { __loop10_var1 = __loop10_var1, prop = prop}
                ).ToList(); //75:6
            int __loop10_iteration = 0;
            foreach (var __tmp7 in __loop10_results)
            {
                ++__loop10_iteration;
                var __loop10_var1 = __tmp7.__loop10_var1;
                var prop = __tmp7.prop;
                string __tmp8Prefix = "    "; //76:1
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append(GenerateImmutableProperty(prop));
                using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                {
                    bool __tmp9_first = true;
                    bool __tmp9_last = __tmp9Reader.EndOfStream;
                    while(__tmp9_first || !__tmp9_last)
                    {
                        __tmp9_first = false;
                        string __tmp9Line = __tmp9Reader.ReadLine();
                        __tmp9_last = __tmp9Reader.EndOfStream;
                        __out.Append(__tmp8Prefix);
                        if (__tmp9Line != null) __out.Append(__tmp9Line);
                        if (!__tmp9_last) __out.AppendLine(true);
                        __out.AppendLine(false); //76:38
                    }
                }
            }
            __out.AppendLine(true); //78:1
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((cls).GetEnumerator()) //79:11
                from op in __Enumerate((__loop11_var1.Operations).GetEnumerator()) //79:16
                select new { __loop11_var1 = __loop11_var1, op = op}
                ).ToList(); //79:6
            int __loop11_iteration = 0;
            foreach (var __tmp10 in __loop11_results)
            {
                ++__loop11_iteration;
                var __loop11_var1 = __tmp10.__loop11_var1;
                var op = __tmp10.op;
                string __tmp11Prefix = "    "; //80:1
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(GenerateOperation(op));
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
                        __out.AppendLine(false); //80:28
                    }
                }
            }
            __out.Append("}"); //82:1
            __out.AppendLine(false); //82:2
            __out.AppendLine(true); //83:1
            return __out.ToString();
        }

        public string GenerateBuilderInterface(MetaClass cls) //86:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "public interface "; //87:1
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
                    __out.AppendLine(false); //87:91
                }
            }
            __out.Append("{"); //88:1
            __out.AppendLine(false); //88:2
            var __loop12_results = 
                (from __loop12_var1 in __Enumerate((cls).GetEnumerator()) //89:11
                from prop in __Enumerate((__loop12_var1.Properties).GetEnumerator()) //89:16
                select new { __loop12_var1 = __loop12_var1, prop = prop}
                ).ToList(); //89:6
            int __loop12_iteration = 0;
            foreach (var __tmp5 in __loop12_results)
            {
                ++__loop12_iteration;
                var __loop12_var1 = __tmp5.__loop12_var1;
                var prop = __tmp5.prop;
                string __tmp6Prefix = "    "; //90:1
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
                        __out.AppendLine(false); //90:36
                    }
                }
            }
            __out.Append("}"); //92:1
            __out.AppendLine(false); //92:2
            __out.AppendLine(true); //93:1
            return __out.ToString();
        }

        public string GenerateImmutableProperty(MetaProperty prop) //96:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //97:2
            {
                __out.Append("new "); //98:1
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
            string __tmp3Line = " "; //100:54
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
            string __tmp5Line = " { get; }"; //100:66
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            __out.AppendLine(false); //100:75
            return __out.ToString();
        }

        public string GenerateImmutableField(MetaProperty prop) //103:1
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
                    __out.AppendLine(false); //104:54
                }
            }
            string __tmp4Line = "private "; //105:1
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
            string __tmp6Line = " _"; //105:62
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
                }
            }
            string __tmp8Line = ";"; //105:75
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //105:76
            return __out.ToString();
        }

        public string GenerateBuilderProperty(MetaProperty prop) //108:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //109:2
            {
                __out.Append("new "); //110:1
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //112:3
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
                string __tmp3Line = " "; //113:52
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
                string __tmp5Line = " { get; set; }"; //113:64
                if (__tmp5Line != null) __out.Append(__tmp5Line);
                __out.AppendLine(false); //113:78
            }
            else //114:3
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
                string __tmp8Line = " "; //115:52
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
                string __tmp10Line = " { get; }"; //115:64
                if (__tmp10Line != null) __out.Append(__tmp10Line);
                __out.AppendLine(false); //115:73
            }
            return __out.ToString();
        }

        public string GenerateBuilderField(MetaProperty prop) //119:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "private "; //120:1
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
            string __tmp4Line = " _"; //120:60
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
            string __tmp6Line = ";"; //120:73
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            __out.AppendLine(false); //120:74
            return __out.ToString();
        }

        public string GetParameters(MetaOperation op, bool defaultValues) //123:1
        {
            string result = ""; //124:2
            var __loop13_results = 
                (from __loop13_var1 in __Enumerate((op).GetEnumerator()) //125:7
                from param in __Enumerate((__loop13_var1.Parameters).GetEnumerator()) //125:11
                select new { __loop13_var1 = __loop13_var1, param = param}
                ).ToList(); //125:2
            int __loop13_iteration = 0;
            string delim = ""; //125:29
            foreach (var __tmp1 in __loop13_results)
            {
                ++__loop13_iteration;
                if (__loop13_iteration >= 2) //125:48
                {
                    delim = ", "; //125:48
                }
                var __loop13_var1 = __tmp1.__loop13_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(ClassKind.Immutable) + " " + param.Name; //126:3
            }
            return result; //128:2
        }

        public string GetImplParameters(MetaClass cls, MetaOperation op) //131:1
        {
            string result = cls.CSharpFullName(ClassKind.Immutable) + " @this"; //132:2
            string delim = ", "; //133:2
            var __loop14_results = 
                (from __loop14_var1 in __Enumerate((op).GetEnumerator()) //134:7
                from param in __Enumerate((__loop14_var1.Parameters).GetEnumerator()) //134:11
                select new { __loop14_var1 = __loop14_var1, param = param}
                ).ToList(); //134:2
            int __loop14_iteration = 0;
            foreach (var __tmp1 in __loop14_results)
            {
                ++__loop14_iteration;
                var __loop14_var1 = __tmp1.__loop14_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(ClassKind.Immutable) + " " + param.Name; //135:3
            }
            return result; //137:2
        }

        public string GetImplParameters(MetaEnum enm, MetaOperation op) //140:1
        {
            string result = enm.CSharpFullName() + " @this"; //141:2
            string delim = ", "; //142:2
            var __loop15_results = 
                (from __loop15_var1 in __Enumerate((op).GetEnumerator()) //143:7
                from param in __Enumerate((__loop15_var1.Parameters).GetEnumerator()) //143:11
                select new { __loop15_var1 = __loop15_var1, param = param}
                ).ToList(); //143:2
            int __loop15_iteration = 0;
            foreach (var __tmp1 in __loop15_results)
            {
                ++__loop15_iteration;
                var __loop15_var1 = __tmp1.__loop15_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(ClassKind.Immutable) + " " + param.Name; //144:3
            }
            return result; //146:2
        }

        public string GetEnumImplParameters(MetaEnum enm, MetaOperation op) //149:1
        {
            string result = "this " + enm.CSharpFullName() + " @this"; //150:2
            string delim = ", "; //151:2
            var __loop16_results = 
                (from __loop16_var1 in __Enumerate((op).GetEnumerator()) //152:7
                from param in __Enumerate((__loop16_var1.Parameters).GetEnumerator()) //152:11
                select new { __loop16_var1 = __loop16_var1, param = param}
                ).ToList(); //152:2
            int __loop16_iteration = 0;
            foreach (var __tmp1 in __loop16_results)
            {
                ++__loop16_iteration;
                var __loop16_var1 = __tmp1.__loop16_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(ClassKind.Immutable) + " " + param.Name; //153:3
            }
            return result; //155:2
        }

        public string GetEnumImplCallParameterNames(MetaOperation op) //158:1
        {
            string result = "@this"; //159:2
            string delim = ", "; //160:2
            var __loop17_results = 
                (from __loop17_var1 in __Enumerate((op).GetEnumerator()) //161:7
                from param in __Enumerate((__loop17_var1.Parameters).GetEnumerator()) //161:11
                select new { __loop17_var1 = __loop17_var1, param = param}
                ).ToList(); //161:2
            int __loop17_iteration = 0;
            foreach (var __tmp1 in __loop17_results)
            {
                ++__loop17_iteration;
                var __loop17_var1 = __tmp1.__loop17_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //162:3
            }
            return result; //164:2
        }

        public string GetImplCallParameterNames(MetaOperation op) //167:1
        {
            string result = "this"; //168:2
            string delim = ", "; //169:2
            var __loop18_results = 
                (from __loop18_var1 in __Enumerate((op).GetEnumerator()) //170:7
                from param in __Enumerate((__loop18_var1.Parameters).GetEnumerator()) //170:11
                select new { __loop18_var1 = __loop18_var1, param = param}
                ).ToList(); //170:2
            int __loop18_iteration = 0;
            foreach (var __tmp1 in __loop18_results)
            {
                ++__loop18_iteration;
                var __loop18_var1 = __tmp1.__loop18_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //171:3
            }
            return result; //173:2
        }

        public string GenerateOperation(MetaOperation op) //176:1
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
            string __tmp3Line = " "; //177:58
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
            string __tmp5Line = "("; //177:68
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(GetParameters(op, true));
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
            string __tmp7Line = ");"; //177:94
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //177:96
            return __out.ToString();
        }

        public string GenerateImmutableInterfaceImpl(MetaModel model, MetaClass cls) //180:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal class "; //181:1
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
            string __tmp4Line = " : global::MetaDslx.Core.Immutable.ImmutableRedSymbolBase, "; //181:57
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
                    __out.AppendLine(false); //181:157
                }
            }
            __out.Append("{"); //182:1
            __out.AppendLine(false); //182:2
            var __loop19_results = 
                (from __loop19_var1 in __Enumerate((cls).GetEnumerator()) //183:11
                from prop in __Enumerate((__loop19_var1.Properties).GetEnumerator()) //183:16
                select new { __loop19_var1 = __loop19_var1, prop = prop}
                ).ToList(); //183:6
            int __loop19_iteration = 0;
            foreach (var __tmp6 in __loop19_results)
            {
                ++__loop19_iteration;
                var __loop19_var1 = __tmp6.__loop19_var1;
                var prop = __tmp6.prop;
                string __tmp7Prefix = "    "; //184:1
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(GenerateImmutableField(prop));
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
                        __out.AppendLine(false); //184:35
                    }
                }
            }
            __out.AppendLine(true); //186:1
            string __tmp10Line = "    internal "; //187:1
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
            string __tmp12Line = "(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableRedModelPart model)"; //187:36
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //187:142
            __out.Append("		: base(id, model)"); //188:1
            __out.AppendLine(false); //188:20
            __out.Append("    {"); //189:1
            __out.AppendLine(false); //189:6
            __out.Append("    }"); //190:1
            __out.AppendLine(false); //190:6
            __out.AppendLine(true); //191:1
            __out.Append("    public override global::MetaDslx.Core.Immutable.MetaModel MMetaModel"); //192:1
            __out.AppendLine(false); //192:73
            __out.Append("    {"); //193:1
            __out.AppendLine(false); //193:6
            string __tmp14Line = "        get { return null;/*"; //194:1
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
            string __tmp16Line = ";*/ }"; //194:65
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            __out.AppendLine(false); //194:70
            __out.Append("    }"); //195:1
            __out.AppendLine(false); //195:6
            __out.AppendLine(true); //196:1
            __out.Append("    public override global::MetaDslx.Core.Immutable.ImmutableRedSymbol MMetaClass"); //197:1
            __out.AppendLine(false); //197:82
            __out.Append("    {"); //198:1
            __out.AppendLine(false); //198:6
            string __tmp18Line = "        get { return null; /*"; //199:1
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
            string __tmp20Line = ";*/ }"; //199:60
            if (__tmp20Line != null) __out.Append(__tmp20Line);
            __out.AppendLine(false); //199:65
            __out.Append("    }"); //200:1
            __out.AppendLine(false); //200:6
            __out.AppendLine(true); //201:1
            var __loop20_results = 
                (from __loop20_var1 in __Enumerate((cls).GetEnumerator()) //202:11
                from prop in __Enumerate((__loop20_var1.GetAllProperties()).GetEnumerator()) //202:16
                select new { __loop20_var1 = __loop20_var1, prop = prop}
                ).ToList(); //202:6
            int __loop20_iteration = 0;
            foreach (var __tmp21 in __loop20_results)
            {
                ++__loop20_iteration;
                var __loop20_var1 = __tmp21.__loop20_var1;
                var prop = __tmp21.prop;
                string __tmp22Prefix = "    "; //203:1
                StringBuilder __tmp23 = new StringBuilder();
                __tmp23.Append(GenerateImmutablePropertyImpl(model, cls, prop));
                using(StreamReader __tmp23Reader = new StreamReader(this.__ToStream(__tmp23.ToString())))
                {
                    bool __tmp23_first = true;
                    bool __tmp23_last = __tmp23Reader.EndOfStream;
                    while(__tmp23_first || !__tmp23_last)
                    {
                        __tmp23_first = false;
                        string __tmp23Line = __tmp23Reader.ReadLine();
                        __tmp23_last = __tmp23Reader.EndOfStream;
                        __out.Append(__tmp22Prefix);
                        if (__tmp23Line != null) __out.Append(__tmp23Line);
                        if (!__tmp23_last) __out.AppendLine(true);
                        __out.AppendLine(false); //203:54
                    }
                }
            }
            var __loop21_results = 
                (from __loop21_var1 in __Enumerate((cls).GetEnumerator()) //205:11
                from op in __Enumerate((__loop21_var1.GetAllOperations()).GetEnumerator()) //205:16
                select new { __loop21_var1 = __loop21_var1, op = op}
                ).ToList(); //205:6
            int __loop21_iteration = 0;
            foreach (var __tmp24 in __loop21_results)
            {
                ++__loop21_iteration;
                var __loop21_var1 = __tmp24.__loop21_var1;
                var op = __tmp24.op;
                string __tmp25Prefix = "    "; //206:1
                StringBuilder __tmp26 = new StringBuilder();
                __tmp26.Append(GenerateOperationImpl(model, op));
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
                        __out.AppendLine(false); //206:39
                    }
                }
            }
            __out.Append("}"); //208:1
            __out.AppendLine(false); //208:2
            __out.AppendLine(true); //209:1
            return __out.ToString();
        }

        public string GenerateBuilderInterfaceImpl(MetaModel model, MetaClass cls) //212:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal class "; //213:1
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
            string __tmp4Line = " : global::MetaDslx.Core.Immutable.MutableRedSymbolBase, "; //213:55
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
                    __out.AppendLine(false); //213:151
                }
            }
            __out.Append("{"); //214:1
            __out.AppendLine(false); //214:2
            var __loop22_results = 
                (from __loop22_var1 in __Enumerate((cls).GetEnumerator()) //215:11
                from prop in __Enumerate((__loop22_var1.Properties).GetEnumerator()) //215:16
                where prop.Type is MetaCollectionType //215:32
                select new { __loop22_var1 = __loop22_var1, prop = prop}
                ).ToList(); //215:6
            int __loop22_iteration = 0;
            foreach (var __tmp6 in __loop22_results)
            {
                ++__loop22_iteration;
                var __loop22_var1 = __tmp6.__loop22_var1;
                var prop = __tmp6.prop;
                string __tmp7Prefix = "    "; //216:1
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(GenerateBuilderField(prop));
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
                        __out.AppendLine(false); //216:33
                    }
                }
            }
            __out.AppendLine(true); //218:1
            string __tmp10Line = "    internal "; //219:1
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
            string __tmp12Line = "(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableRedModelPart model)"; //219:53
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //219:157
            __out.Append("		: base(id, model)"); //220:1
            __out.AppendLine(false); //220:20
            __out.Append("    {"); //221:1
            __out.AppendLine(false); //221:6
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((cls).GetEnumerator()) //222:9
                from prop in __Enumerate((__loop23_var1.GetAllProperties()).GetEnumerator()) //222:14
                select new { __loop23_var1 = __loop23_var1, prop = prop}
                ).ToList(); //222:4
            int __loop23_iteration = 0;
            foreach (var __tmp13 in __loop23_results)
            {
                ++__loop23_iteration;
                var __loop23_var1 = __tmp13.__loop23_var1;
                var prop = __tmp13.prop;
                string __tmp15Line = "        this.MAttachProperty("; //223:1
                if (__tmp15Line != null) __out.Append(__tmp15Line);
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(prop.CSharpFullDescriptorName());
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
                string __tmp17Line = ");"; //223:63
                if (__tmp17Line != null) __out.Append(__tmp17Line);
                __out.AppendLine(false); //223:65
            }
            __out.Append("        this.MInit();"); //225:1
            __out.AppendLine(false); //225:22
            __out.Append("    }"); //226:1
            __out.AppendLine(false); //226:6
            __out.AppendLine(true); //227:1
            __out.Append("    protected override void MDoInit()"); //228:1
            __out.AppendLine(false); //228:38
            __out.Append("    {"); //229:1
            __out.AppendLine(false); //229:6
            __out.Append("    }"); //230:1
            __out.AppendLine(false); //230:6
            __out.AppendLine(true); //231:1
            __out.Append("    public override global::MetaDslx.Core.MetaModel MMetaModel"); //232:1
            __out.AppendLine(false); //232:63
            __out.Append("    {"); //233:1
            __out.AppendLine(false); //233:6
            string __tmp19Line = "        get { return null;/*"; //234:1
            if (__tmp19Line != null) __out.Append(__tmp19Line);
            StringBuilder __tmp20 = new StringBuilder();
            __tmp20.Append(cls.Model.CSharpFullInstanceName());
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
            string __tmp21Line = ";*/ }"; //234:65
            if (__tmp21Line != null) __out.Append(__tmp21Line);
            __out.AppendLine(false); //234:70
            __out.Append("    }"); //235:1
            __out.AppendLine(false); //235:6
            __out.AppendLine(true); //236:1
            __out.Append("    public override global::MetaDslx.Core.Immutable.MutableRedSymbol MMetaClass"); //237:1
            __out.AppendLine(false); //237:80
            __out.Append("    {"); //238:1
            __out.AppendLine(false); //238:6
            string __tmp23Line = "        get { return null;/*"; //239:1
            if (__tmp23Line != null) __out.Append(__tmp23Line);
            StringBuilder __tmp24 = new StringBuilder();
            __tmp24.Append(cls.CSharpFullInstanceName());
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
            string __tmp25Line = ";*/ }"; //239:59
            if (__tmp25Line != null) __out.Append(__tmp25Line);
            __out.AppendLine(false); //239:64
            __out.Append("    }"); //240:1
            __out.AppendLine(false); //240:6
            __out.AppendLine(true); //241:1
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((cls).GetEnumerator()) //242:11
                from prop in __Enumerate((__loop24_var1.GetAllProperties()).GetEnumerator()) //242:16
                select new { __loop24_var1 = __loop24_var1, prop = prop}
                ).ToList(); //242:6
            int __loop24_iteration = 0;
            foreach (var __tmp26 in __loop24_results)
            {
                ++__loop24_iteration;
                var __loop24_var1 = __tmp26.__loop24_var1;
                var prop = __tmp26.prop;
                string __tmp27Prefix = "    "; //243:1
                StringBuilder __tmp28 = new StringBuilder();
                __tmp28.Append(GenerateBuilderPropertyImpl(model, cls, prop));
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
                        __out.AppendLine(false); //243:52
                    }
                }
            }
            __out.Append("}"); //245:1
            __out.AppendLine(false); //245:2
            __out.AppendLine(true); //246:1
            return __out.ToString();
        }

        public string GeneratePropertyDeclaration(MetaModel model, MetaClass cls, MetaProperty prop) //249:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class == cls) //250:2
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
                        __out.AppendLine(false); //251:28
                    }
                }
                if (prop.Kind == MetaPropertyKind.Containment) //252:2
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
                            __out.AppendLine(false); //253:27
                        }
                    }
                }
                if (prop.Kind != MetaPropertyKind.Normal && prop.Kind != MetaPropertyKind.Containment) //255:2
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
                            __out.AppendLine(false); //256:24
                        }
                    }
                }
                var __loop25_results = 
                    (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //258:7
                    select new { p = p}
                    ).ToList(); //258:2
                int __loop25_iteration = 0;
                foreach (var __tmp7 in __loop25_results)
                {
                    ++__loop25_iteration;
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
                    __tmp10.Append(p.Class.CSharpFullDescriptorName());
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
                            __out.AppendLine(false); //259:92
                        }
                    }
                }
                var __loop26_results = 
                    (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //261:7
                    select new { p = p}
                    ).ToList(); //261:2
                int __loop26_iteration = 0;
                foreach (var __tmp14 in __loop26_results)
                {
                    ++__loop26_iteration;
                    var p = __tmp14.p;
                    if (cls.GetAllSuperClasses(false).Contains(p.Class)) //262:3
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
                        __tmp17.Append(p.Class.CSharpFullDescriptorName());
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
                                __out.AppendLine(false); //263:91
                            }
                        }
                    }
                    else //264:3
                    {
                        string __tmp22Line = "// ERROR: subsetted property '"; //265:1
                        if (__tmp22Line != null) __out.Append(__tmp22Line);
                        StringBuilder __tmp23 = new StringBuilder();
                        __tmp23.Append(p.CSharpFullDescriptorName());
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
                        string __tmp24Line = "' must be a property of an ancestor class"; //265:61
                        if (__tmp24Line != null) __out.Append(__tmp24Line);
                        __out.AppendLine(false); //265:102
                    }
                }
                var __loop27_results = 
                    (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //268:7
                    select new { p = p}
                    ).ToList(); //268:2
                int __loop27_iteration = 0;
                foreach (var __tmp25 in __loop27_results)
                {
                    ++__loop27_iteration;
                    var p = __tmp25.p;
                    if (cls.GetAllSuperClasses(false).Contains(p.Class)) //269:3
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
                        __tmp28.Append(p.Class.CSharpFullDescriptorName());
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
                                __out.AppendLine(false); //270:93
                            }
                        }
                    }
                    else //271:3
                    {
                        string __tmp33Line = "// ERROR: redefined property '"; //272:1
                        if (__tmp33Line != null) __out.Append(__tmp33Line);
                        StringBuilder __tmp34 = new StringBuilder();
                        __tmp34.Append(p.CSharpFullDescriptorName());
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
                        string __tmp35Line = "' must be a property of an ancestor class"; //272:61
                        if (__tmp35Line != null) __out.Append(__tmp35Line);
                        __out.AppendLine(false); //272:102
                    }
                }
                if (prop.Type is MetaCollectionType) //275:2
                {
                    MetaCollectionType collType = (MetaCollectionType)prop.Type; //276:3
                    string __tmp37Line = "public static readonly global::MetaDslx.Core.Immutable.ModelProperty "; //277:1
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
                    string __tmp39Line = "Property ="; //277:81
                    if (__tmp39Line != null) __out.Append(__tmp39Line);
                    __out.AppendLine(false); //277:91
                    string __tmp41Line = "    global::MetaDslx.Core.Immutable.ModelProperty.Register(\""; //278:1
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
                    string __tmp43Line = "\", typeof("; //278:72
                    if (__tmp43Line != null) __out.Append(__tmp43Line);
                    StringBuilder __tmp44 = new StringBuilder();
                    __tmp44.Append(prop.Class.Model.CSharpFullName());
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
                    string __tmp45Line = "Descriptor."; //278:117
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
                    string __tmp47Line = ")"; //278:153
                    if (__tmp47Line != null) __out.Append(__tmp47Line);
                    __out.AppendLine(false); //278:154
                    string __tmp49Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //279:1
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
                    string __tmp51Line = "), typeof("; //279:136
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
                    string __tmp53Line = "), typeof("; //279:199
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
                    string __tmp55Line = ")),"; //279:257
                    if (__tmp55Line != null) __out.Append(__tmp55Line);
                    __out.AppendLine(false); //279:260
                    string __tmp57Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //280:1
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
                    string __tmp59Line = "), typeof("; //280:134
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
                    string __tmp61Line = "), typeof("; //280:195
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
                    string __tmp63Line = ")),"; //280:251
                    if (__tmp63Line != null) __out.Append(__tmp63Line);
                    __out.AppendLine(false); //280:254
                    string __tmp65Line = "		() => "; //281:1
                    if (__tmp65Line != null) __out.Append(__tmp65Line);
                    StringBuilder __tmp66 = new StringBuilder();
                    __tmp66.Append(prop.Class.Model.CSharpFullName());
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
                    string __tmp67Line = "Instance."; //281:44
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
                    string __tmp69Line = "_"; //281:78
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
                    string __tmp71Line = "Property);"; //281:90
                    if (__tmp71Line != null) __out.Append(__tmp71Line);
                    __out.AppendLine(false); //281:100
                }
                else //282:2
                {
                    string __tmp73Line = "public static readonly global::MetaDslx.Core.Immutable.ModelProperty "; //283:1
                    if (__tmp73Line != null) __out.Append(__tmp73Line);
                    StringBuilder __tmp74 = new StringBuilder();
                    __tmp74.Append(prop.Name);
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
                    string __tmp75Line = "Property ="; //283:81
                    if (__tmp75Line != null) __out.Append(__tmp75Line);
                    __out.AppendLine(false); //283:91
                    string __tmp77Line = "    global::MetaDslx.Core.Immutable.ModelProperty.Register(\""; //284:1
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
                    string __tmp79Line = "\", typeof("; //284:72
                    if (__tmp79Line != null) __out.Append(__tmp79Line);
                    StringBuilder __tmp80 = new StringBuilder();
                    __tmp80.Append(prop.Class.Model.CSharpFullName());
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
                    string __tmp81Line = "Descriptor."; //284:117
                    if (__tmp81Line != null) __out.Append(__tmp81Line);
                    StringBuilder __tmp82 = new StringBuilder();
                    __tmp82.Append(prop.Class.CSharpName());
                    using(StreamReader __tmp82Reader = new StreamReader(this.__ToStream(__tmp82.ToString())))
                    {
                        bool __tmp82_first = true;
                        bool __tmp82_last = __tmp82Reader.EndOfStream;
                        while(__tmp82_first || !__tmp82_last)
                        {
                            __tmp82_first = false;
                            string __tmp82Line = __tmp82Reader.ReadLine();
                            __tmp82_last = __tmp82Reader.EndOfStream;
                            if (__tmp82Line != null) __out.Append(__tmp82Line);
                            if (!__tmp82_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp83Line = ")"; //284:153
                    if (__tmp83Line != null) __out.Append(__tmp83Line);
                    __out.AppendLine(false); //284:154
                    string __tmp85Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //285:1
                    if (__tmp85Line != null) __out.Append(__tmp85Line);
                    StringBuilder __tmp86 = new StringBuilder();
                    __tmp86.Append(prop.Type.CSharpFullPublicName());
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
                    string __tmp87Line = "), null, typeof("; //285:108
                    if (__tmp87Line != null) __out.Append(__tmp87Line);
                    StringBuilder __tmp88 = new StringBuilder();
                    __tmp88.Append(prop.Class.CSharpFullName(ClassKind.Immutable));
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
                    string __tmp89Line = ")),"; //285:172
                    if (__tmp89Line != null) __out.Append(__tmp89Line);
                    __out.AppendLine(false); //285:175
                    string __tmp91Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //286:1
                    if (__tmp91Line != null) __out.Append(__tmp91Line);
                    StringBuilder __tmp92 = new StringBuilder();
                    __tmp92.Append(prop.Type.CSharpFullPublicName());
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
                    string __tmp93Line = "), null, typeof("; //286:108
                    if (__tmp93Line != null) __out.Append(__tmp93Line);
                    StringBuilder __tmp94 = new StringBuilder();
                    __tmp94.Append(prop.Class.CSharpFullName(ClassKind.Builder));
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
                    string __tmp95Line = ")),"; //286:170
                    if (__tmp95Line != null) __out.Append(__tmp95Line);
                    __out.AppendLine(false); //286:173
                    string __tmp97Line = "		() => "; //287:1
                    if (__tmp97Line != null) __out.Append(__tmp97Line);
                    StringBuilder __tmp98 = new StringBuilder();
                    __tmp98.Append(prop.Class.Model.CSharpFullName());
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
                        }
                    }
                    string __tmp99Line = "Instance."; //287:44
                    if (__tmp99Line != null) __out.Append(__tmp99Line);
                    StringBuilder __tmp100 = new StringBuilder();
                    __tmp100.Append(prop.Class.CSharpName());
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
                    string __tmp101Line = "_"; //287:78
                    if (__tmp101Line != null) __out.Append(__tmp101Line);
                    StringBuilder __tmp102 = new StringBuilder();
                    __tmp102.Append(prop.Name);
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
                    string __tmp103Line = "Property);"; //287:90
                    if (__tmp103Line != null) __out.Append(__tmp103Line);
                    __out.AppendLine(false); //287:100
                }
            }
            __out.AppendLine(true); //290:1
            return __out.ToString();
        }

        public string GenerateImmutablePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //293:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //294:1
            if (cls.Properties.Contains(prop)) //295:2
            {
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
                string __tmp3Line = " "; //296:54
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
                        __out.AppendLine(false); //296:66
                    }
                }
            }
            else //297:2
            {
                StringBuilder __tmp6 = new StringBuilder();
                __tmp6.Append("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
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
                        __out.AppendLine(false); //298:54
                    }
                }
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(prop.Type.CSharpFullPublicName(ClassKind.Immutable));
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
                string __tmp9Line = " "; //299:54
                if (__tmp9Line != null) __out.Append(__tmp9Line);
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(prop.Class.CSharpFullName(ClassKind.Immutable));
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
                string __tmp11Line = "."; //299:103
                if (__tmp11Line != null) __out.Append(__tmp11Line);
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(prop.Name);
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
                        __out.AppendLine(false); //299:115
                    }
                }
            }
            __out.Append("{"); //301:1
            __out.AppendLine(false); //301:2
            string __tmp14Line = "    get { return this.GetValue("; //302:1
            if (__tmp14Line != null) __out.Append(__tmp14Line);
            StringBuilder __tmp15 = new StringBuilder();
            __tmp15.Append(prop.CSharpFullDescriptorName());
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
            string __tmp16Line = ", ref _"; //302:65
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(prop.Name);
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
            string __tmp18Line = "); }"; //302:83
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //302:87
            __out.Append("}"); //303:1
            __out.AppendLine(false); //303:2
            return __out.ToString();
        }

        public string GenerateBuilderPropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //306:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //307:1
            if (cls.Properties.Contains(prop)) //308:2
            {
                StringBuilder __tmp2 = new StringBuilder();
                __tmp2.Append(prop.Type.CSharpFullPublicName());
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
                string __tmp3Line = " "; //309:35
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
                        __out.AppendLine(false); //309:47
                    }
                }
            }
            else //310:2
            {
                StringBuilder __tmp6 = new StringBuilder();
                __tmp6.Append("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
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
                        __out.AppendLine(false); //311:54
                    }
                }
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(prop.Type.CSharpFullPublicName());
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
                string __tmp9Line = " "; //312:35
                if (__tmp9Line != null) __out.Append(__tmp9Line);
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(prop.Class.CSharpFullName(ClassKind.Builder));
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
                string __tmp11Line = "."; //312:82
                if (__tmp11Line != null) __out.Append(__tmp11Line);
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(prop.Name);
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
                        __out.AppendLine(false); //312:94
                    }
                }
            }
            __out.Append("{"); //314:1
            __out.AppendLine(false); //314:2
            if (prop.Type is MetaCollectionType) //315:6
            {
                string __tmp14Line = "    get { return this.GetList("; //316:1
                if (__tmp14Line != null) __out.Append(__tmp14Line);
                StringBuilder __tmp15 = new StringBuilder();
                __tmp15.Append(prop.CSharpFullDescriptorName());
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
                string __tmp16Line = ", ref "; //316:64
                if (__tmp16Line != null) __out.Append(__tmp16Line);
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(prop.Name);
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
                string __tmp18Line = "); }"; //316:81
                if (__tmp18Line != null) __out.Append(__tmp18Line);
                __out.AppendLine(false); //316:85
            }
            else //317:3
            {
                string __tmp20Line = "    get { return this.GetValue<"; //318:1
                if (__tmp20Line != null) __out.Append(__tmp20Line);
                StringBuilder __tmp21 = new StringBuilder();
                __tmp21.Append(prop.Type.CSharpFullPublicName());
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
                string __tmp22Line = ">("; //318:66
                if (__tmp22Line != null) __out.Append(__tmp22Line);
                StringBuilder __tmp23 = new StringBuilder();
                __tmp23.Append(prop.CSharpFullDescriptorName());
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
                string __tmp24Line = "); }"; //318:101
                if (__tmp24Line != null) __out.Append(__tmp24Line);
                __out.AppendLine(false); //318:105
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //320:3
            {
                string __tmp26Line = "    set { this.SetValue("; //321:1
                if (__tmp26Line != null) __out.Append(__tmp26Line);
                StringBuilder __tmp27 = new StringBuilder();
                __tmp27.Append(prop.CSharpFullDescriptorName());
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
                string __tmp28Line = ", value); }"; //321:58
                if (__tmp28Line != null) __out.Append(__tmp28Line);
                __out.AppendLine(false); //321:69
            }
            __out.Append("}"); //323:1
            __out.AppendLine(false); //323:2
            return __out.ToString();
        }

        public string GetReturn(MetaOperation op) //326:1
        {
            if (op.ReturnType.CSharpName() == "void") //327:5
            {
                return ""; //328:3
            }
            else //329:2
            {
                return "return "; //330:3
            }
        }

        public string GenerateOperationImpl(MetaModel model, MetaOperation op) //334:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //335:1
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
            string __tmp3Line = " "; //336:58
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
            string __tmp5Line = "."; //336:106
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
            string __tmp7Line = "("; //336:116
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(GetParameters(op, false));
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
            string __tmp9Line = ")"; //336:143
            if (__tmp9Line != null) __out.Append(__tmp9Line);
            __out.AppendLine(false); //336:144
            __out.Append("{"); //337:1
            __out.AppendLine(false); //337:2
            string __tmp10Prefix = "    "; //338:1
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
            __tmp12.Append(model.CSharpFullImplementationName());
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
            string __tmp13Line = "."; //338:58
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
            string __tmp15Line = "_"; //338:83
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
            string __tmp17Line = "("; //338:93
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
            string __tmp19Line = ");"; //338:125
            if (__tmp19Line != null) __out.Append(__tmp19Line);
            __out.AppendLine(false); //338:127
            __out.Append("}"); //339:1
            __out.AppendLine(false); //339:2
            return __out.ToString();
        }

        public string GetSuperClasses(MetaClass cls) //342:1
        {
            string result = ""; //343:2
            var __loop28_results = 
                (from __loop28_var1 in __Enumerate((cls).GetEnumerator()) //344:10
                from sup in __Enumerate((__loop28_var1.SuperClasses).GetEnumerator()) //344:15
                select new { __loop28_var1 = __loop28_var1, sup = sup}
                ).ToList(); //344:5
            int __loop28_iteration = 0;
            string delim = ""; //344:33
            foreach (var __tmp1 in __loop28_results)
            {
                ++__loop28_iteration;
                if (__loop28_iteration >= 2) //344:52
                {
                    delim = ", "; //344:52
                }
                var __loop28_var1 = __tmp1.__loop28_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpFullName(); //345:3
            }
            return result; //347:2
        }

        public string GetAllSuperClasses(MetaClass cls) //350:1
        {
            string result = ""; //351:2
            var __loop29_results = 
                (from __loop29_var1 in __Enumerate((cls).GetEnumerator()) //352:10
                from sup in __Enumerate((__loop29_var1.GetAllSuperClasses(false)).GetEnumerator()) //352:15
                select new { __loop29_var1 = __loop29_var1, sup = sup}
                ).ToList(); //352:5
            int __loop29_iteration = 0;
            string delim = ""; //352:46
            foreach (var __tmp1 in __loop29_results)
            {
                ++__loop29_iteration;
                if (__loop29_iteration >= 2) //352:65
                {
                    delim = ", "; //352:65
                }
                var __loop29_var1 = __tmp1.__loop29_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpFullName(); //353:3
            }
            return result; //355:2
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //358:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "public static class "; //359:1
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
                    __out.AppendLine(false); //359:51
                }
            }
            __out.Append("{"); //360:1
            __out.AppendLine(false); //360:2
            __out.Append("	private static global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty> properties = new global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty>();"); //361:1
            __out.AppendLine(false); //361:210
            string __tmp5Line = "    static "; //363:1
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
            string __tmp7Line = "()"; //363:42
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //363:44
            __out.Append("    {"); //364:1
            __out.AppendLine(false); //364:6
            var __loop30_results = 
                (from __loop30_var1 in __Enumerate((model).GetEnumerator()) //365:11
                from Namespace in __Enumerate((__loop30_var1.Namespace).GetEnumerator()) //365:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //365:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //365:43
                from prop in __Enumerate((cls.Properties).GetEnumerator()) //365:66
                select new { __loop30_var1 = __loop30_var1, Namespace = Namespace, Declarations = Declarations, cls = cls, prop = prop}
                ).ToList(); //365:6
            int __loop30_iteration = 0;
            foreach (var __tmp8 in __loop30_results)
            {
                ++__loop30_iteration;
                var __loop30_var1 = __tmp8.__loop30_var1;
                var Namespace = __tmp8.Namespace;
                var Declarations = __tmp8.Declarations;
                var cls = __tmp8.cls;
                var prop = __tmp8.prop;
                string __tmp10Line = "        properties.Add("; //366:1
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
                string __tmp12Line = "."; //366:42
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
                string __tmp14Line = "Property);"; //366:54
                if (__tmp14Line != null) __out.Append(__tmp14Line);
                __out.AppendLine(false); //366:64
            }
            __out.Append("        foreach (var property in properties)"); //369:1
            __out.AppendLine(false); //369:45
            __out.Append("        {"); //370:1
            __out.AppendLine(false); //370:10
            __out.Append("            property.Init();"); //371:1
            __out.AppendLine(false); //371:29
            __out.Append("        }"); //372:1
            __out.AppendLine(false); //372:10
            __out.Append("    }"); //373:1
            __out.AppendLine(false); //373:6
            __out.Append("    public static void Init()"); //375:1
            __out.AppendLine(false); //375:30
            __out.Append("    {"); //376:1
            __out.AppendLine(false); //376:6
            __out.Append("    }"); //378:1
            __out.AppendLine(false); //378:6
            __out.AppendLine(true); //379:1
            string __tmp16Line = "	public const string Uri = \""; //380:1
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
            string __tmp18Line = "\";"; //380:40
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //380:42
            __out.AppendLine(true); //381:1
            var __loop31_results = 
                (from __loop31_var1 in __Enumerate((model).GetEnumerator()) //382:11
                from Namespace in __Enumerate((__loop31_var1.Namespace).GetEnumerator()) //382:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //382:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //382:43
                select new { __loop31_var1 = __loop31_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //382:6
            int __loop31_iteration = 0;
            foreach (var __tmp19 in __loop31_results)
            {
                ++__loop31_iteration;
                var __loop31_var1 = __tmp19.__loop31_var1;
                var Namespace = __tmp19.Namespace;
                var Declarations = __tmp19.Declarations;
                var cls = __tmp19.cls;
                string __tmp20Prefix = "    "; //383:1
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
                        __out.AppendLine(false); //383:34
                    }
                }
            }
            __out.Append("}"); //385:1
            __out.AppendLine(false); //385:2
            __out.AppendLine(true); //386:1
            return __out.ToString();
        }

        public string GenerateMetaModelClass(MetaClass cls) //390:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //391:1
            string __tmp2Line = "public static class "; //392:1
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
                    __out.AppendLine(false); //392:39
                }
            }
            __out.Append("{"); //393:1
            __out.AppendLine(false); //393:2
            __out.AppendLine(true); //394:1
            if (cls.CSharpName() == "MetaClass") //395:2
            {
                __out.Append("    public static global::MetaDslx.Core.Immutable.MetaClass _MetaClass"); //396:1
                __out.AppendLine(false); //396:71
            }
            else //397:2
            {
                __out.Append("    public static global::MetaDslx.Core.Immutable.MetaClass MetaClass"); //398:1
                __out.AppendLine(false); //398:70
            }
            __out.Append("    {"); //400:1
            __out.AppendLine(false); //400:6
            string __tmp5Line = "        get { return null;/*"; //401:1
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
            string __tmp7Line = ";*/ }"; //401:59
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //401:64
            __out.Append("    }"); //402:1
            __out.AppendLine(false); //402:6
            __out.AppendLine(true); //403:1
            var __loop32_results = 
                (from __loop32_var1 in __Enumerate((cls).GetEnumerator()) //404:11
                from prop in __Enumerate((__loop32_var1.Properties).GetEnumerator()) //404:16
                select new { __loop32_var1 = __loop32_var1, prop = prop}
                ).ToList(); //404:6
            int __loop32_iteration = 0;
            foreach (var __tmp8 in __loop32_results)
            {
                ++__loop32_iteration;
                var __loop32_var1 = __tmp8.__loop32_var1;
                var prop = __tmp8.prop;
                string __tmp9Prefix = "    "; //405:1
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
                        __out.AppendLine(false); //405:56
                    }
                }
            }
            __out.Append("}"); //407:1
            __out.AppendLine(false); //407:2
            return __out.ToString();
        }

        public MetaSynthetizedPropertyInitializer GetSynthetizedInitializerFor(MetaClass cls, MetaProperty prop) //411:1
        {
            MetaSynthetizedPropertyInitializer lastInit = null; //412:2
            var __loop33_results = 
                (from __loop33_var1 in __Enumerate((cls).GetEnumerator()) //413:7
                from sup in __Enumerate((__loop33_var1.GetAllSuperClasses(true)).GetEnumerator()) //413:12
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //413:42
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //413:55
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaSynthetizedPropertyInitializer>() //413:69
                select new { __loop33_var1 = __loop33_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //413:2
            int __loop33_iteration = 0;
            foreach (var __tmp1 in __loop33_results)
            {
                ++__loop33_iteration;
                var __loop33_var1 = __tmp1.__loop33_var1;
                var sup = __tmp1.sup;
                var Constructor = __tmp1.Constructor;
                var Initializers = __tmp1.Initializers;
                var init = __tmp1.init;
                if (init.Property == prop) //414:3
                {
                    lastInit = init; //415:4
                }
            }
            return lastInit; //418:2
        }

        public string GenerateImplementationProvider(MetaModel model) //422:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal static class "; //423:1
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
            string __tmp4Line = "ImplementationProvider"; //423:35
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //423:57
            __out.Append("{"); //424:1
            __out.AppendLine(false); //424:2
            string __tmp6Line = "    // If there is a compile error at this line, create a new class called "; //425:1
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
            string __tmp8Line = "Implementation"; //425:88
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //425:102
            string __tmp10Line = "	// which is a subclass of "; //426:1
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
            string __tmp12Line = "ImplementationBase:"; //426:40
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //426:59
            string __tmp14Line = "    private static "; //427:1
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
            string __tmp16Line = "Implementation implementation = new "; //427:32
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
            string __tmp18Line = "Implementation();"; //427:80
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //427:97
            __out.AppendLine(true); //428:1
            string __tmp20Line = "    public static "; //429:1
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
            string __tmp22Line = "Implementation Implementation"; //429:31
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            __out.AppendLine(false); //429:60
            __out.Append("    {"); //430:1
            __out.AppendLine(false); //430:6
            string __tmp24Line = "        get { return "; //431:1
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
            string __tmp26Line = "ImplementationProvider.implementation; }"; //431:34
            if (__tmp26Line != null) __out.Append(__tmp26Line);
            __out.AppendLine(false); //431:74
            __out.Append("    }"); //432:1
            __out.AppendLine(false); //432:6
            __out.Append("}"); //433:1
            __out.AppendLine(false); //433:2
            var __loop34_results = 
                (from __loop34_var1 in __Enumerate((model).GetEnumerator()) //434:8
                from Namespace in __Enumerate((__loop34_var1.Namespace).GetEnumerator()) //434:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //434:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //434:40
                select new { __loop34_var1 = __loop34_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //434:3
            int __loop34_iteration = 0;
            foreach (var __tmp27 in __loop34_results)
            {
                ++__loop34_iteration;
                var __loop34_var1 = __tmp27.__loop34_var1;
                var Namespace = __tmp27.Namespace;
                var Declarations = __tmp27.Declarations;
                var enm = __tmp27.enm;
                __out.AppendLine(true); //435:1
                string __tmp29Line = "public static class "; //436:1
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
                string __tmp31Line = "Extensions"; //436:31
                if (__tmp31Line != null) __out.Append(__tmp31Line);
                __out.AppendLine(false); //436:41
                __out.Append("{"); //437:1
                __out.AppendLine(false); //437:2
                var __loop35_results = 
                    (from __loop35_var1 in __Enumerate((enm).GetEnumerator()) //438:11
                    from op in __Enumerate((__loop35_var1.Operations).GetEnumerator()) //438:16
                    select new { __loop35_var1 = __loop35_var1, op = op}
                    ).ToList(); //438:6
                int __loop35_iteration = 0;
                foreach (var __tmp32 in __loop35_results)
                {
                    ++__loop35_iteration;
                    var __loop35_var1 = __tmp32.__loop35_var1;
                    var op = __tmp32.op;
                    string __tmp34Line = "    public static "; //439:1
                    if (__tmp34Line != null) __out.Append(__tmp34Line);
                    StringBuilder __tmp35 = new StringBuilder();
                    __tmp35.Append(op.ReturnType.CSharpFullPublicName());
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
                    string __tmp36Line = " "; //439:57
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
                    string __tmp38Line = "("; //439:67
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
                    string __tmp40Line = ")"; //439:100
                    if (__tmp40Line != null) __out.Append(__tmp40Line);
                    __out.AppendLine(false); //439:101
                    __out.Append("    {"); //440:1
                    __out.AppendLine(false); //440:6
                    string __tmp41Prefix = "        "; //441:1
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
                    string __tmp44Line = "ImplementationProvider.Implementation."; //441:36
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
                    string __tmp46Line = "_"; //441:98
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
                    string __tmp48Line = "("; //441:108
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
                    string __tmp50Line = ");"; //441:144
                    if (__tmp50Line != null) __out.Append(__tmp50Line);
                    __out.AppendLine(false); //441:146
                    __out.Append("    }"); //442:1
                    __out.AppendLine(false); //442:6
                }
                __out.Append("}"); //444:1
                __out.AppendLine(false); //444:2
            }
            __out.AppendLine(true); //446:1
            __out.Append("/// <summary>"); //447:1
            __out.AppendLine(false); //447:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //448:1
            __out.AppendLine(false); //448:68
            string __tmp52Line = "/// This class has to be be overriden in "; //449:1
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
            string __tmp54Line = "Implementation to provide custom"; //449:54
            if (__tmp54Line != null) __out.Append(__tmp54Line);
            __out.AppendLine(false); //449:86
            __out.Append("/// implementation for the constructors, operations and property values."); //450:1
            __out.AppendLine(false); //450:73
            __out.Append("/// </summary>"); //451:1
            __out.AppendLine(false); //451:15
            string __tmp56Line = "internal abstract class "; //452:1
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
            string __tmp58Line = "ImplementationBase"; //452:37
            if (__tmp58Line != null) __out.Append(__tmp58Line);
            __out.AppendLine(false); //452:55
            __out.Append("{"); //453:1
            __out.AppendLine(false); //453:2
            var __loop36_results = 
                (from __loop36_var1 in __Enumerate((model).GetEnumerator()) //454:8
                from Namespace in __Enumerate((__loop36_var1.Namespace).GetEnumerator()) //454:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //454:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //454:40
                select new { __loop36_var1 = __loop36_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //454:3
            int __loop36_iteration = 0;
            foreach (var __tmp59 in __loop36_results)
            {
                ++__loop36_iteration;
                var __loop36_var1 = __tmp59.__loop36_var1;
                var Namespace = __tmp59.Namespace;
                var Declarations = __tmp59.Declarations;
                var cls = __tmp59.cls;
                __out.Append("    /// <summary>"); //455:1
                __out.AppendLine(false); //455:18
                string __tmp61Line = "	/// Implements the constructor: "; //456:1
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
                string __tmp63Line = "()"; //456:52
                if (__tmp63Line != null) __out.Append(__tmp63Line);
                __out.AppendLine(false); //456:54
                if ((from __loop37_var1 in __Enumerate((cls).GetEnumerator()) //457:15
                from sup in __Enumerate((__loop37_var1.SuperClasses).GetEnumerator()) //457:20
                select new { __loop37_var1 = __loop37_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //457:3
                {
                    string __tmp65Line = "	/// Direct superclasses: "; //458:1
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
                            __out.AppendLine(false); //458:49
                        }
                    }
                    string __tmp68Line = "	/// All superclasses: "; //459:1
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
                            __out.AppendLine(false); //459:49
                        }
                    }
                }
                if ((from __loop38_var1 in __Enumerate((cls).GetEnumerator()) //461:15
                from prop in __Enumerate((__loop38_var1.GetAllProperties()).GetEnumerator()) //461:20
                where prop.Kind == MetaPropertyKind.Readonly //461:44
                select new { __loop38_var1 = __loop38_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //461:3
                {
                    __out.Append("    /// Initializes the following readonly properties:"); //462:1
                    __out.AppendLine(false); //462:55
                }
                var __loop39_results = 
                    (from __loop39_var1 in __Enumerate((cls).GetEnumerator()) //464:11
                    from prop in __Enumerate((__loop39_var1.GetAllProperties()).GetEnumerator()) //464:16
                    select new { __loop39_var1 = __loop39_var1, prop = prop}
                    ).ToList(); //464:6
                int __loop39_iteration = 0;
                foreach (var __tmp70 in __loop39_results)
                {
                    ++__loop39_iteration;
                    var __loop39_var1 = __tmp70.__loop39_var1;
                    var prop = __tmp70.prop;
                    if (prop.Kind == MetaPropertyKind.Readonly) //465:3
                    {
                        string __tmp72Line = "    ///    "; //466:1
                        if (__tmp72Line != null) __out.Append(__tmp72Line);
                        StringBuilder __tmp73 = new StringBuilder();
                        __tmp73.Append(prop.Class.Name);
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
                        string __tmp74Line = "."; //466:29
                        if (__tmp74Line != null) __out.Append(__tmp74Line);
                        StringBuilder __tmp75 = new StringBuilder();
                        __tmp75.Append(prop.Name);
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
                                __out.AppendLine(false); //466:41
                            }
                        }
                    }
                }
                __out.Append("    /// </summary>"); //469:1
                __out.AppendLine(false); //469:19
                string __tmp77Line = "    public virtual void "; //470:1
                if (__tmp77Line != null) __out.Append(__tmp77Line);
                StringBuilder __tmp78 = new StringBuilder();
                __tmp78.Append(cls.CSharpName());
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
                string __tmp79Line = "_"; //470:43
                if (__tmp79Line != null) __out.Append(__tmp79Line);
                StringBuilder __tmp80 = new StringBuilder();
                __tmp80.Append(cls.CSharpName());
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
                string __tmp81Line = "("; //470:62
                if (__tmp81Line != null) __out.Append(__tmp81Line);
                StringBuilder __tmp82 = new StringBuilder();
                __tmp82.Append(cls.CSharpName());
                using(StreamReader __tmp82Reader = new StreamReader(this.__ToStream(__tmp82.ToString())))
                {
                    bool __tmp82_first = true;
                    bool __tmp82_last = __tmp82Reader.EndOfStream;
                    while(__tmp82_first || !__tmp82_last)
                    {
                        __tmp82_first = false;
                        string __tmp82Line = __tmp82Reader.ReadLine();
                        __tmp82_last = __tmp82Reader.EndOfStream;
                        if (__tmp82Line != null) __out.Append(__tmp82Line);
                        if (!__tmp82_last) __out.AppendLine(true);
                    }
                }
                string __tmp83Line = " @this)"; //470:81
                if (__tmp83Line != null) __out.Append(__tmp83Line);
                __out.AppendLine(false); //470:88
                __out.Append("    {"); //471:1
                __out.AppendLine(false); //471:6
                var __loop40_results = 
                    (from __loop40_var1 in __Enumerate((cls).GetEnumerator()) //472:9
                    from sup in __Enumerate((__loop40_var1.SuperClasses).GetEnumerator()) //472:14
                    select new { __loop40_var1 = __loop40_var1, sup = sup}
                    ).ToList(); //472:4
                int __loop40_iteration = 0;
                foreach (var __tmp84 in __loop40_results)
                {
                    ++__loop40_iteration;
                    var __loop40_var1 = __tmp84.__loop40_var1;
                    var sup = __tmp84.sup;
                    string __tmp86Line = "        this."; //473:1
                    if (__tmp86Line != null) __out.Append(__tmp86Line);
                    StringBuilder __tmp87 = new StringBuilder();
                    __tmp87.Append(sup.CSharpName());
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
                    string __tmp88Line = "_"; //473:32
                    if (__tmp88Line != null) __out.Append(__tmp88Line);
                    StringBuilder __tmp89 = new StringBuilder();
                    __tmp89.Append(sup.CSharpName());
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
                    string __tmp90Line = "(@this);"; //473:51
                    if (__tmp90Line != null) __out.Append(__tmp90Line);
                    __out.AppendLine(false); //473:59
                }
                __out.Append("    }"); //475:1
                __out.AppendLine(false); //475:6
                var __loop41_results = 
                    (from __loop41_var1 in __Enumerate((cls).GetEnumerator()) //476:11
                    from prop in __Enumerate((__loop41_var1.Properties).GetEnumerator()) //476:16
                    select new { __loop41_var1 = __loop41_var1, prop = prop}
                    ).ToList(); //476:6
                int __loop41_iteration = 0;
                foreach (var __tmp91 in __loop41_results)
                {
                    ++__loop41_iteration;
                    var __loop41_var1 = __tmp91.__loop41_var1;
                    var prop = __tmp91.prop;
                    MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //477:4
                    if (synInit == null) //478:4
                    {
                        if (prop.Kind == MetaPropertyKind.Derived) //479:5
                        {
                            __out.AppendLine(true); //480:1
                            __out.Append("    /// <summary>"); //481:1
                            __out.AppendLine(false); //481:18
                            string __tmp93Line = "    /// Returns the value of the derived property: "; //482:1
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
                            string __tmp95Line = "."; //482:70
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
                                    __out.AppendLine(false); //482:82
                                }
                            }
                            __out.Append("    /// </summary>"); //483:1
                            __out.AppendLine(false); //483:19
                            string __tmp98Line = "    public virtual "; //484:1
                            if (__tmp98Line != null) __out.Append(__tmp98Line);
                            StringBuilder __tmp99 = new StringBuilder();
                            __tmp99.Append(prop.Type.CSharpFullPublicName());
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
                            string __tmp100Line = " "; //484:54
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
                            string __tmp102Line = "_"; //484:73
                            if (__tmp102Line != null) __out.Append(__tmp102Line);
                            StringBuilder __tmp103 = new StringBuilder();
                            __tmp103.Append(prop.Name);
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
                            string __tmp104Line = "("; //484:85
                            if (__tmp104Line != null) __out.Append(__tmp104Line);
                            StringBuilder __tmp105 = new StringBuilder();
                            __tmp105.Append(cls.CSharpName());
                            using(StreamReader __tmp105Reader = new StreamReader(this.__ToStream(__tmp105.ToString())))
                            {
                                bool __tmp105_first = true;
                                bool __tmp105_last = __tmp105Reader.EndOfStream;
                                while(__tmp105_first || !__tmp105_last)
                                {
                                    __tmp105_first = false;
                                    string __tmp105Line = __tmp105Reader.ReadLine();
                                    __tmp105_last = __tmp105Reader.EndOfStream;
                                    if (__tmp105Line != null) __out.Append(__tmp105Line);
                                    if (!__tmp105_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp106Line = " @this)"; //484:104
                            if (__tmp106Line != null) __out.Append(__tmp106Line);
                            __out.AppendLine(false); //484:111
                            __out.Append("    {"); //485:1
                            __out.AppendLine(false); //485:6
                            __out.Append("        throw new NotImplementedException();"); //486:1
                            __out.AppendLine(false); //486:45
                            __out.Append("    }"); //487:1
                            __out.AppendLine(false); //487:6
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //488:5
                        {
                            __out.AppendLine(true); //489:1
                            __out.Append("    /// <summary>"); //490:1
                            __out.AppendLine(false); //490:18
                            string __tmp108Line = "    /// Returns the value of the lazy property: "; //491:1
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
                            string __tmp110Line = "."; //491:67
                            if (__tmp110Line != null) __out.Append(__tmp110Line);
                            StringBuilder __tmp111 = new StringBuilder();
                            __tmp111.Append(prop.Name);
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
                                    __out.AppendLine(false); //491:79
                                }
                            }
                            __out.Append("    /// </summary>"); //492:1
                            __out.AppendLine(false); //492:19
                            string __tmp113Line = "    public virtual "; //493:1
                            if (__tmp113Line != null) __out.Append(__tmp113Line);
                            StringBuilder __tmp114 = new StringBuilder();
                            __tmp114.Append(prop.Type.CSharpFullPublicName());
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
                            string __tmp115Line = " "; //493:54
                            if (__tmp115Line != null) __out.Append(__tmp115Line);
                            StringBuilder __tmp116 = new StringBuilder();
                            __tmp116.Append(cls.CSharpName());
                            using(StreamReader __tmp116Reader = new StreamReader(this.__ToStream(__tmp116.ToString())))
                            {
                                bool __tmp116_first = true;
                                bool __tmp116_last = __tmp116Reader.EndOfStream;
                                while(__tmp116_first || !__tmp116_last)
                                {
                                    __tmp116_first = false;
                                    string __tmp116Line = __tmp116Reader.ReadLine();
                                    __tmp116_last = __tmp116Reader.EndOfStream;
                                    if (__tmp116Line != null) __out.Append(__tmp116Line);
                                    if (!__tmp116_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp117Line = "_"; //493:73
                            if (__tmp117Line != null) __out.Append(__tmp117Line);
                            StringBuilder __tmp118 = new StringBuilder();
                            __tmp118.Append(prop.Name);
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
                            string __tmp119Line = "("; //493:85
                            if (__tmp119Line != null) __out.Append(__tmp119Line);
                            StringBuilder __tmp120 = new StringBuilder();
                            __tmp120.Append(cls.CSharpName());
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
                            string __tmp121Line = " @this)"; //493:104
                            if (__tmp121Line != null) __out.Append(__tmp121Line);
                            __out.AppendLine(false); //493:111
                            __out.Append("    {"); //494:1
                            __out.AppendLine(false); //494:6
                            __out.Append("        throw new NotImplementedException();"); //495:1
                            __out.AppendLine(false); //495:45
                            __out.Append("    }"); //496:1
                            __out.AppendLine(false); //496:6
                        }
                    }
                }
                var __loop42_results = 
                    (from __loop42_var1 in __Enumerate((cls).GetEnumerator()) //500:11
                    from op in __Enumerate((__loop42_var1.Operations).GetEnumerator()) //500:16
                    select new { __loop42_var1 = __loop42_var1, op = op}
                    ).ToList(); //500:6
                int __loop42_iteration = 0;
                foreach (var __tmp122 in __loop42_results)
                {
                    ++__loop42_iteration;
                    var __loop42_var1 = __tmp122.__loop42_var1;
                    var op = __tmp122.op;
                    __out.AppendLine(true); //501:1
                    __out.Append("    /// <summary>"); //502:1
                    __out.AppendLine(false); //502:18
                    string __tmp124Line = "    /// Implements the operation: "; //503:1
                    if (__tmp124Line != null) __out.Append(__tmp124Line);
                    StringBuilder __tmp125 = new StringBuilder();
                    __tmp125.Append(cls.CSharpName());
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
                    string __tmp126Line = "."; //503:53
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
                    string __tmp128Line = "()"; //503:63
                    if (__tmp128Line != null) __out.Append(__tmp128Line);
                    __out.AppendLine(false); //503:65
                    __out.Append("    /// </summary>"); //504:1
                    __out.AppendLine(false); //504:19
                    string __tmp130Line = "    public virtual "; //505:1
                    if (__tmp130Line != null) __out.Append(__tmp130Line);
                    StringBuilder __tmp131 = new StringBuilder();
                    __tmp131.Append(op.ReturnType.CSharpFullPublicName());
                    using(StreamReader __tmp131Reader = new StreamReader(this.__ToStream(__tmp131.ToString())))
                    {
                        bool __tmp131_first = true;
                        bool __tmp131_last = __tmp131Reader.EndOfStream;
                        while(__tmp131_first || !__tmp131_last)
                        {
                            __tmp131_first = false;
                            string __tmp131Line = __tmp131Reader.ReadLine();
                            __tmp131_last = __tmp131Reader.EndOfStream;
                            if (__tmp131Line != null) __out.Append(__tmp131Line);
                            if (!__tmp131_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp132Line = " "; //505:58
                    if (__tmp132Line != null) __out.Append(__tmp132Line);
                    StringBuilder __tmp133 = new StringBuilder();
                    __tmp133.Append(cls.CSharpName());
                    using(StreamReader __tmp133Reader = new StreamReader(this.__ToStream(__tmp133.ToString())))
                    {
                        bool __tmp133_first = true;
                        bool __tmp133_last = __tmp133Reader.EndOfStream;
                        while(__tmp133_first || !__tmp133_last)
                        {
                            __tmp133_first = false;
                            string __tmp133Line = __tmp133Reader.ReadLine();
                            __tmp133_last = __tmp133Reader.EndOfStream;
                            if (__tmp133Line != null) __out.Append(__tmp133Line);
                            if (!__tmp133_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp134Line = "_"; //505:77
                    if (__tmp134Line != null) __out.Append(__tmp134Line);
                    StringBuilder __tmp135 = new StringBuilder();
                    __tmp135.Append(op.Name);
                    using(StreamReader __tmp135Reader = new StreamReader(this.__ToStream(__tmp135.ToString())))
                    {
                        bool __tmp135_first = true;
                        bool __tmp135_last = __tmp135Reader.EndOfStream;
                        while(__tmp135_first || !__tmp135_last)
                        {
                            __tmp135_first = false;
                            string __tmp135Line = __tmp135Reader.ReadLine();
                            __tmp135_last = __tmp135Reader.EndOfStream;
                            if (__tmp135Line != null) __out.Append(__tmp135Line);
                            if (!__tmp135_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp136Line = "("; //505:87
                    if (__tmp136Line != null) __out.Append(__tmp136Line);
                    StringBuilder __tmp137 = new StringBuilder();
                    __tmp137.Append(GetImplParameters(cls, op));
                    using(StreamReader __tmp137Reader = new StreamReader(this.__ToStream(__tmp137.ToString())))
                    {
                        bool __tmp137_first = true;
                        bool __tmp137_last = __tmp137Reader.EndOfStream;
                        while(__tmp137_first || !__tmp137_last)
                        {
                            __tmp137_first = false;
                            string __tmp137Line = __tmp137Reader.ReadLine();
                            __tmp137_last = __tmp137Reader.EndOfStream;
                            if (__tmp137Line != null) __out.Append(__tmp137Line);
                            if (!__tmp137_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp138Line = ")"; //505:116
                    if (__tmp138Line != null) __out.Append(__tmp138Line);
                    __out.AppendLine(false); //505:117
                    __out.Append("    {"); //506:1
                    __out.AppendLine(false); //506:6
                    __out.Append("        throw new NotImplementedException();"); //507:1
                    __out.AppendLine(false); //507:45
                    __out.Append("    }"); //508:1
                    __out.AppendLine(false); //508:6
                }
                __out.AppendLine(true); //510:1
            }
            var __loop43_results = 
                (from __loop43_var1 in __Enumerate((model).GetEnumerator()) //512:8
                from Namespace in __Enumerate((__loop43_var1.Namespace).GetEnumerator()) //512:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //512:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //512:40
                select new { __loop43_var1 = __loop43_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //512:3
            int __loop43_iteration = 0;
            foreach (var __tmp139 in __loop43_results)
            {
                ++__loop43_iteration;
                var __loop43_var1 = __tmp139.__loop43_var1;
                var Namespace = __tmp139.Namespace;
                var Declarations = __tmp139.Declarations;
                var enm = __tmp139.enm;
                var __loop44_results = 
                    (from __loop44_var1 in __Enumerate((enm).GetEnumerator()) //513:11
                    from op in __Enumerate((__loop44_var1.Operations).GetEnumerator()) //513:16
                    select new { __loop44_var1 = __loop44_var1, op = op}
                    ).ToList(); //513:6
                int __loop44_iteration = 0;
                foreach (var __tmp140 in __loop44_results)
                {
                    ++__loop44_iteration;
                    var __loop44_var1 = __tmp140.__loop44_var1;
                    var op = __tmp140.op;
                    __out.AppendLine(true); //514:1
                    __out.Append("    /// <summary>"); //515:1
                    __out.AppendLine(false); //515:18
                    string __tmp142Line = "    /// Implements the operation: "; //516:1
                    if (__tmp142Line != null) __out.Append(__tmp142Line);
                    StringBuilder __tmp143 = new StringBuilder();
                    __tmp143.Append(enm.CSharpName());
                    using(StreamReader __tmp143Reader = new StreamReader(this.__ToStream(__tmp143.ToString())))
                    {
                        bool __tmp143_first = true;
                        bool __tmp143_last = __tmp143Reader.EndOfStream;
                        while(__tmp143_first || !__tmp143_last)
                        {
                            __tmp143_first = false;
                            string __tmp143Line = __tmp143Reader.ReadLine();
                            __tmp143_last = __tmp143Reader.EndOfStream;
                            if (__tmp143Line != null) __out.Append(__tmp143Line);
                            if (!__tmp143_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp144Line = "."; //516:53
                    if (__tmp144Line != null) __out.Append(__tmp144Line);
                    StringBuilder __tmp145 = new StringBuilder();
                    __tmp145.Append(op.Name);
                    using(StreamReader __tmp145Reader = new StreamReader(this.__ToStream(__tmp145.ToString())))
                    {
                        bool __tmp145_first = true;
                        bool __tmp145_last = __tmp145Reader.EndOfStream;
                        while(__tmp145_first || !__tmp145_last)
                        {
                            __tmp145_first = false;
                            string __tmp145Line = __tmp145Reader.ReadLine();
                            __tmp145_last = __tmp145Reader.EndOfStream;
                            if (__tmp145Line != null) __out.Append(__tmp145Line);
                            if (!__tmp145_last) __out.AppendLine(true);
                            __out.AppendLine(false); //516:63
                        }
                    }
                    __out.Append("    /// </summary>"); //517:1
                    __out.AppendLine(false); //517:19
                    string __tmp147Line = "    public virtual "; //518:1
                    if (__tmp147Line != null) __out.Append(__tmp147Line);
                    StringBuilder __tmp148 = new StringBuilder();
                    __tmp148.Append(op.ReturnType.CSharpFullPublicName());
                    using(StreamReader __tmp148Reader = new StreamReader(this.__ToStream(__tmp148.ToString())))
                    {
                        bool __tmp148_first = true;
                        bool __tmp148_last = __tmp148Reader.EndOfStream;
                        while(__tmp148_first || !__tmp148_last)
                        {
                            __tmp148_first = false;
                            string __tmp148Line = __tmp148Reader.ReadLine();
                            __tmp148_last = __tmp148Reader.EndOfStream;
                            if (__tmp148Line != null) __out.Append(__tmp148Line);
                            if (!__tmp148_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp149Line = " "; //518:58
                    if (__tmp149Line != null) __out.Append(__tmp149Line);
                    StringBuilder __tmp150 = new StringBuilder();
                    __tmp150.Append(enm.CSharpName());
                    using(StreamReader __tmp150Reader = new StreamReader(this.__ToStream(__tmp150.ToString())))
                    {
                        bool __tmp150_first = true;
                        bool __tmp150_last = __tmp150Reader.EndOfStream;
                        while(__tmp150_first || !__tmp150_last)
                        {
                            __tmp150_first = false;
                            string __tmp150Line = __tmp150Reader.ReadLine();
                            __tmp150_last = __tmp150Reader.EndOfStream;
                            if (__tmp150Line != null) __out.Append(__tmp150Line);
                            if (!__tmp150_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp151Line = "_"; //518:77
                    if (__tmp151Line != null) __out.Append(__tmp151Line);
                    StringBuilder __tmp152 = new StringBuilder();
                    __tmp152.Append(op.Name);
                    using(StreamReader __tmp152Reader = new StreamReader(this.__ToStream(__tmp152.ToString())))
                    {
                        bool __tmp152_first = true;
                        bool __tmp152_last = __tmp152Reader.EndOfStream;
                        while(__tmp152_first || !__tmp152_last)
                        {
                            __tmp152_first = false;
                            string __tmp152Line = __tmp152Reader.ReadLine();
                            __tmp152_last = __tmp152Reader.EndOfStream;
                            if (__tmp152Line != null) __out.Append(__tmp152Line);
                            if (!__tmp152_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp153Line = "("; //518:87
                    if (__tmp153Line != null) __out.Append(__tmp153Line);
                    StringBuilder __tmp154 = new StringBuilder();
                    __tmp154.Append(GetImplParameters(enm, op));
                    using(StreamReader __tmp154Reader = new StreamReader(this.__ToStream(__tmp154.ToString())))
                    {
                        bool __tmp154_first = true;
                        bool __tmp154_last = __tmp154Reader.EndOfStream;
                        while(__tmp154_first || !__tmp154_last)
                        {
                            __tmp154_first = false;
                            string __tmp154Line = __tmp154Reader.ReadLine();
                            __tmp154_last = __tmp154Reader.EndOfStream;
                            if (__tmp154Line != null) __out.Append(__tmp154Line);
                            if (!__tmp154_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp155Line = ")"; //518:116
                    if (__tmp155Line != null) __out.Append(__tmp155Line);
                    __out.AppendLine(false); //518:117
                    __out.Append("    {"); //519:1
                    __out.AppendLine(false); //519:6
                    __out.Append("        throw new NotImplementedException();"); //520:1
                    __out.AppendLine(false); //520:45
                    __out.Append("    }"); //521:1
                    __out.AppendLine(false); //521:6
                }
                __out.AppendLine(true); //523:1
            }
            __out.Append("}"); //525:1
            __out.AppendLine(false); //525:2
            __out.AppendLine(true); //526:1
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //529:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //530:1
            __out.AppendLine(false); //530:14
            __out.Append("/// Factory class for creating instances of model elements."); //531:1
            __out.AppendLine(false); //531:60
            __out.Append("/// </summary>"); //532:1
            __out.AppendLine(false); //532:15
            string __tmp2Line = "public class "; //533:1
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
            string __tmp4Line = " : global::MetaDslx.Core.Immutable.ModelFactory"; //533:41
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //533:88
            __out.Append("{"); //534:1
            __out.AppendLine(false); //534:2
            string __tmp6Line = "    public "; //535:1
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
            string __tmp8Line = "()"; //535:39
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //535:41
            __out.Append("        : base()"); //536:1
            __out.AppendLine(false); //536:17
            __out.Append("    {"); //537:1
            __out.AppendLine(false); //537:6
            string __tmp9Prefix = "		"; //538:1
            StringBuilder __tmp10 = new StringBuilder();
            __tmp10.Append(model.CSharpDescriptorName());
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
            string __tmp11Line = ".Init();"; //538:33
            if (__tmp11Line != null) __out.Append(__tmp11Line);
            __out.AppendLine(false); //538:41
            __out.Append("    }"); //539:1
            __out.AppendLine(false); //539:6
            __out.AppendLine(true); //540:1
            string __tmp13Line = "    public "; //541:1
            if (__tmp13Line != null) __out.Append(__tmp13Line);
            StringBuilder __tmp14 = new StringBuilder();
            __tmp14.Append(model.CSharpFactoryName());
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
            string __tmp15Line = "(global::MetaDslx.Core.Immutable.MutableRedModel model)"; //541:39
            if (__tmp15Line != null) __out.Append(__tmp15Line);
            __out.AppendLine(false); //541:94
            __out.Append("        : base(model)"); //542:1
            __out.AppendLine(false); //542:22
            __out.Append("    {"); //543:1
            __out.AppendLine(false); //543:6
            string __tmp16Prefix = "		"; //544:1
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(model.CSharpDescriptorName());
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
            string __tmp18Line = ".Init();"; //544:33
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //544:41
            __out.Append("    }"); //545:1
            __out.AppendLine(false); //545:6
            __out.AppendLine(true); //546:1
            string __tmp20Line = "    public "; //547:1
            if (__tmp20Line != null) __out.Append(__tmp20Line);
            StringBuilder __tmp21 = new StringBuilder();
            __tmp21.Append(model.CSharpFactoryName());
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
            string __tmp22Line = "(global::MetaDslx.Core.Immutable.MutableRedModel model, global::MetaDslx.Core.Immutable.MutableRedModelPart part)"; //547:39
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            __out.AppendLine(false); //547:152
            __out.Append("        : base(model, part)"); //548:1
            __out.AppendLine(false); //548:28
            __out.Append("    {"); //549:1
            __out.AppendLine(false); //549:6
            string __tmp23Prefix = "		"; //550:1
            StringBuilder __tmp24 = new StringBuilder();
            __tmp24.Append(model.CSharpDescriptorName());
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
                }
            }
            string __tmp25Line = ".Init();"; //550:33
            if (__tmp25Line != null) __out.Append(__tmp25Line);
            __out.AppendLine(false); //550:41
            __out.Append("    }"); //551:1
            __out.AppendLine(false); //551:6
            __out.AppendLine(true); //552:1
            __out.Append("    public override MutableRedSymbol Create(string type)"); //553:1
            __out.AppendLine(false); //553:57
            __out.Append("    {"); //554:1
            __out.AppendLine(false); //554:6
            __out.Append("        switch (type)"); //555:1
            __out.AppendLine(false); //555:22
            __out.Append("        {"); //556:1
            __out.AppendLine(false); //556:10
            var __loop45_results = 
                (from __loop45_var1 in __Enumerate((model).GetEnumerator()) //557:10
                from Namespace in __Enumerate((__loop45_var1.Namespace).GetEnumerator()) //557:17
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //557:28
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //557:42
                select new { __loop45_var1 = __loop45_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //557:5
            int __loop45_iteration = 0;
            foreach (var __tmp26 in __loop45_results)
            {
                ++__loop45_iteration;
                var __loop45_var1 = __tmp26.__loop45_var1;
                var Namespace = __tmp26.Namespace;
                var Declarations = __tmp26.Declarations;
                var cls = __tmp26.cls;
                if (!cls.IsAbstract) //558:6
                {
                    string __tmp28Line = "            case \""; //559:1
                    if (__tmp28Line != null) __out.Append(__tmp28Line);
                    StringBuilder __tmp29 = new StringBuilder();
                    __tmp29.Append(cls.CSharpName());
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
                    string __tmp30Line = "\": return (MutableRedSymbol)this."; //559:37
                    if (__tmp30Line != null) __out.Append(__tmp30Line);
                    StringBuilder __tmp31 = new StringBuilder();
                    __tmp31.Append(cls.CSharpName());
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
                    string __tmp32Line = "();"; //559:88
                    if (__tmp32Line != null) __out.Append(__tmp32Line);
                    __out.AppendLine(false); //559:91
                }
            }
            __out.Append("            default:"); //562:1
            __out.AppendLine(false); //562:21
            __out.Append("                throw new ModelException(\"Unknown type name: \" + type);"); //563:1
            __out.AppendLine(false); //563:72
            __out.Append("        }"); //564:1
            __out.AppendLine(false); //564:10
            __out.Append("    }"); //565:1
            __out.AppendLine(false); //565:6
            var __loop46_results = 
                (from __loop46_var1 in __Enumerate((model).GetEnumerator()) //566:8
                from Namespace in __Enumerate((__loop46_var1.Namespace).GetEnumerator()) //566:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //566:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //566:40
                select new { __loop46_var1 = __loop46_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //566:3
            int __loop46_iteration = 0;
            foreach (var __tmp33 in __loop46_results)
            {
                ++__loop46_iteration;
                var __loop46_var1 = __tmp33.__loop46_var1;
                var Namespace = __tmp33.Namespace;
                var Declarations = __tmp33.Declarations;
                var cls = __tmp33.cls;
                if (!cls.IsAbstract) //567:4
                {
                    __out.AppendLine(true); //568:1
                    __out.Append("    /// <summary>"); //569:1
                    __out.AppendLine(false); //569:18
                    string __tmp35Line = "    /// Creates a new instance of "; //570:1
                    if (__tmp35Line != null) __out.Append(__tmp35Line);
                    StringBuilder __tmp36 = new StringBuilder();
                    __tmp36.Append(cls.CSharpName());
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
                    string __tmp37Line = "."; //570:53
                    if (__tmp37Line != null) __out.Append(__tmp37Line);
                    __out.AppendLine(false); //570:54
                    __out.Append("    /// </summary>"); //571:1
                    __out.AppendLine(false); //571:19
                    string __tmp39Line = "    public "; //572:1
                    if (__tmp39Line != null) __out.Append(__tmp39Line);
                    StringBuilder __tmp40 = new StringBuilder();
                    __tmp40.Append(cls.CSharpName(ClassKind.Builder));
                    using(StreamReader __tmp40Reader = new StreamReader(this.__ToStream(__tmp40.ToString())))
                    {
                        bool __tmp40_first = true;
                        bool __tmp40_last = __tmp40Reader.EndOfStream;
                        while(__tmp40_first || !__tmp40_last)
                        {
                            __tmp40_first = false;
                            string __tmp40Line = __tmp40Reader.ReadLine();
                            __tmp40_last = __tmp40Reader.EndOfStream;
                            if (__tmp40Line != null) __out.Append(__tmp40Line);
                            if (!__tmp40_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp41Line = " "; //572:47
                    if (__tmp41Line != null) __out.Append(__tmp41Line);
                    StringBuilder __tmp42 = new StringBuilder();
                    __tmp42.Append(cls.CSharpName());
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
                    string __tmp43Line = "()"; //572:66
                    if (__tmp43Line != null) __out.Append(__tmp43Line);
                    __out.AppendLine(false); //572:68
                    __out.Append("	{"); //573:1
                    __out.AppendLine(false); //573:3
                    string __tmp45Line = "		return ("; //574:1
                    if (__tmp45Line != null) __out.Append(__tmp45Line);
                    StringBuilder __tmp46 = new StringBuilder();
                    __tmp46.Append(cls.CSharpName(ClassKind.Builder));
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
                    string __tmp47Line = ")this.AddSymbol(new "; //574:46
                    if (__tmp47Line != null) __out.Append(__tmp47Line);
                    StringBuilder __tmp48 = new StringBuilder();
                    __tmp48.Append(cls.CSharpName(ClassKind.Id));
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
                    string __tmp49Line = "());"; //574:96
                    if (__tmp49Line != null) __out.Append(__tmp49Line);
                    __out.AppendLine(false); //574:100
                    __out.Append("	}"); //575:1
                    __out.AppendLine(false); //575:3
                }
            }
            __out.Append("}"); //578:1
            __out.AppendLine(false); //578:2
            __out.AppendLine(true); //579:1
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
