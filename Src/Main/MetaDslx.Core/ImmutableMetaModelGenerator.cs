using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core //1:1
{
    using __Hidden_ImmutableMetaModelGenerator_1034343338;
    namespace __Hidden_ImmutableMetaModelGenerator_1034343338
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
            string __tmp6Prefix = "	"; //23:1
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(GenerateMetaModelInstance(model));
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
                    __out.AppendLine(false); //23:36
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
            foreach (var __tmp8 in __loop2_results)
            {
                ++__loop2_iteration;
                var __loop2_var1 = __tmp8.__loop2_var1;
                var Namespace = __tmp8.Namespace;
                var Declarations = __tmp8.Declarations;
                var enm = __tmp8.enm;
                string __tmp9Prefix = "    "; //25:1
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(GenerateEnum(enm));
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
            foreach (var __tmp11 in __loop3_results)
            {
                ++__loop3_iteration;
                var __loop3_var1 = __tmp11.__loop3_var1;
                var Namespace = __tmp11.Namespace;
                var Declarations = __tmp11.Declarations;
                var cls = __tmp11.cls;
                string __tmp12Prefix = "    "; //28:1
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(GenerateInterface(cls));
                using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                {
                    bool __tmp13_first = true;
                    bool __tmp13_last = __tmp13Reader.EndOfStream;
                    while(__tmp13_first || !__tmp13_last)
                    {
                        __tmp13_first = false;
                        string __tmp13Line = __tmp13Reader.ReadLine();
                        __tmp13_last = __tmp13Reader.EndOfStream;
                        __out.Append(__tmp12Prefix);
                        if (__tmp13Line != null) __out.Append(__tmp13Line);
                        if (!__tmp13_last) __out.AppendLine(true);
                        __out.AppendLine(false); //28:29
                    }
                }
                string __tmp14Prefix = "    "; //29:1
                StringBuilder __tmp15 = new StringBuilder();
                __tmp15.Append(GenerateInterfaceImpl(model, cls));
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
                        __out.AppendLine(false); //29:40
                    }
                }
            }
            string __tmp16Prefix = "    "; //31:1
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(GenerateFactory(model));
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
                    __out.AppendLine(false); //31:29
                }
            }
            string __tmp18Prefix = "    "; //32:1
            StringBuilder __tmp19 = new StringBuilder();
            __tmp19.Append(GenerateImplementationProvider(model));
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
                    __out.AppendLine(false); //32:44
                }
            }
            __out.Append("}"); //33:1
            __out.AppendLine(false); //33:2
            return __out.ToString();
        }

        public string GenerateAnnotations(MetaAnnotatedElement elem) //36:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop4_results = 
                (from __loop4_var1 in __Enumerate((elem).GetEnumerator()) //37:7
                from annot in __Enumerate((__loop4_var1.Annotations).GetEnumerator()) //37:13
                select new { __loop4_var1 = __loop4_var1, annot = annot}
                ).ToList(); //37:2
            int __loop4_iteration = 0;
            foreach (var __tmp1 in __loop4_results)
            {
                ++__loop4_iteration;
                var __loop4_var1 = __tmp1.__loop4_var1;
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
                        __out.AppendLine(false); //38:23
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateEnum(MetaEnum enm) //42:1
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
                    __out.AppendLine(false); //43:27
                }
            }
            string __tmp4Line = "public enum "; //44:1
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
                    __out.AppendLine(false); //44:31
                }
            }
            __out.Append("{"); //45:1
            __out.AppendLine(false); //45:2
            var __loop5_results = 
                (from __loop5_var1 in __Enumerate((enm).GetEnumerator()) //46:11
                from value in __Enumerate((__loop5_var1.EnumLiterals).GetEnumerator()) //46:16
                select new { __loop5_var1 = __loop5_var1, value = value}
                ).ToList(); //46:6
            int __loop5_iteration = 0;
            foreach (var __tmp6 in __loop5_results)
            {
                ++__loop5_iteration;
                var __loop5_var1 = __tmp6.__loop5_var1;
                var value = __tmp6.value;
                string __tmp7Prefix = "    "; //47:1
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
                string __tmp9Line = ","; //47:17
                if (__tmp9Line != null) __out.Append(__tmp9Line);
                __out.AppendLine(false); //47:18
            }
            __out.Append("}"); //49:1
            __out.AppendLine(false); //49:2
            __out.AppendLine(true); //50:1
            return __out.ToString();
        }

        public string GetAncestors(MetaClass cls, bool immutable) //53:1
        {
            string result = ""; //54:2
            var __loop6_results = 
                (from __loop6_var1 in __Enumerate((cls).GetEnumerator()) //55:7
                from super in __Enumerate((__loop6_var1.SuperClasses).GetEnumerator()) //55:12
                select new { __loop6_var1 = __loop6_var1, super = super}
                ).ToList(); //55:2
            int __loop6_iteration = 0;
            string delim = " : "; //55:32
            foreach (var __tmp1 in __loop6_results)
            {
                ++__loop6_iteration;
                if (__loop6_iteration >= 2) //55:54
                {
                    delim = ", "; //55:54
                }
                var __loop6_var1 = __tmp1.__loop6_var1;
                var super = __tmp1.super;
                result += delim + super.CSharpFullName(immutable); //56:3
            }
            if (result == "") //58:2
            {
                result = "global::MetaDslx.Core.Immutable.RedSymbol"; //59:3
            }
            return result; //61:2
        }

        public string GenerateImmutableInterface(MetaClass cls) //64:1
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
                    __out.AppendLine(false); //65:27
                }
            }
            string __tmp4Line = "public interface "; //66:1
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(cls.CSharpName());
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
            __tmp6.Append(GetAncestors(cls, true));
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
                    __out.AppendLine(false); //66:61
                }
            }
            __out.Append("{"); //67:1
            __out.AppendLine(false); //67:2
            var __loop7_results = 
                (from __loop7_var1 in __Enumerate((cls).GetEnumerator()) //68:11
                from prop in __Enumerate((__loop7_var1.Properties).GetEnumerator()) //68:16
                select new { __loop7_var1 = __loop7_var1, prop = prop}
                ).ToList(); //68:6
            int __loop7_iteration = 0;
            foreach (var __tmp7 in __loop7_results)
            {
                ++__loop7_iteration;
                var __loop7_var1 = __tmp7.__loop7_var1;
                var prop = __tmp7.prop;
                string __tmp8Prefix = "    "; //69:1
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
                        __out.AppendLine(false); //69:38
                    }
                }
            }
            __out.AppendLine(true); //71:1
            var __loop8_results = 
                (from __loop8_var1 in __Enumerate((cls).GetEnumerator()) //72:11
                from op in __Enumerate((__loop8_var1.Operations).GetEnumerator()) //72:16
                select new { __loop8_var1 = __loop8_var1, op = op}
                ).ToList(); //72:6
            int __loop8_iteration = 0;
            foreach (var __tmp10 in __loop8_results)
            {
                ++__loop8_iteration;
                var __loop8_var1 = __tmp10.__loop8_var1;
                var op = __tmp10.op;
                string __tmp11Prefix = "    "; //73:1
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(GenerateImmutableOperation(op));
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
                        __out.AppendLine(false); //73:37
                    }
                }
            }
            __out.Append("}"); //75:1
            __out.AppendLine(false); //75:2
            __out.AppendLine(true); //76:1
            return __out.ToString();
        }

        public string GenerateInterface(MetaClass cls) //79:1
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
                    __out.AppendLine(false); //80:27
                }
            }
            string __tmp4Line = "public interface "; //81:1
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(cls.CSharpName());
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
            __tmp6.Append(GetAncestors(cls, false));
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
                    __out.AppendLine(false); //81:62
                }
            }
            __out.Append("{"); //82:1
            __out.AppendLine(false); //82:2
            var __loop9_results = 
                (from __loop9_var1 in __Enumerate((cls).GetEnumerator()) //83:11
                from prop in __Enumerate((__loop9_var1.Properties).GetEnumerator()) //83:16
                select new { __loop9_var1 = __loop9_var1, prop = prop}
                ).ToList(); //83:6
            int __loop9_iteration = 0;
            foreach (var __tmp7 in __loop9_results)
            {
                ++__loop9_iteration;
                var __loop9_var1 = __tmp7.__loop9_var1;
                var prop = __tmp7.prop;
                string __tmp8Prefix = "    "; //84:1
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append(GenerateProperty(prop));
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
                        __out.AppendLine(false); //84:29
                    }
                }
            }
            __out.AppendLine(true); //86:1
            var __loop10_results = 
                (from __loop10_var1 in __Enumerate((cls).GetEnumerator()) //87:11
                from op in __Enumerate((__loop10_var1.Operations).GetEnumerator()) //87:16
                select new { __loop10_var1 = __loop10_var1, op = op}
                ).ToList(); //87:6
            int __loop10_iteration = 0;
            foreach (var __tmp10 in __loop10_results)
            {
                ++__loop10_iteration;
                var __loop10_var1 = __tmp10.__loop10_var1;
                var op = __tmp10.op;
                string __tmp11Prefix = "    "; //88:1
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
                        __out.AppendLine(false); //88:28
                    }
                }
            }
            __out.Append("}"); //90:1
            __out.AppendLine(false); //90:2
            __out.AppendLine(true); //91:1
            return __out.ToString();
        }

        public string GenerateImmutableProperty(MetaProperty prop) //94:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //95:2
            {
                __out.Append("new "); //96:1
            }
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(prop.Type.CSharpFullPublicName(true));
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
            string __tmp3Line = " "; //98:39
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
            string __tmp5Line = " { get; }"; //98:51
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            __out.AppendLine(false); //98:60
            return __out.ToString();
        }

        public string GenerateProperty(MetaProperty prop) //101:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //102:2
            {
                __out.Append("new "); //103:1
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //105:3
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
                string __tmp3Line = " "; //106:35
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
                string __tmp5Line = " { get; set; }"; //106:47
                if (__tmp5Line != null) __out.Append(__tmp5Line);
                __out.AppendLine(false); //106:61
            }
            else //107:3
            {
                StringBuilder __tmp7 = new StringBuilder();
                __tmp7.Append(prop.Type.CSharpFullPublicName());
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
                string __tmp8Line = " "; //108:35
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
                string __tmp10Line = " { get; }"; //108:47
                if (__tmp10Line != null) __out.Append(__tmp10Line);
                __out.AppendLine(false); //108:56
            }
            return __out.ToString();
        }

        public string GetImmutableParameters(MetaOperation op, bool defaultValues) //112:1
        {
            string result = ""; //113:2
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((op).GetEnumerator()) //114:7
                from param in __Enumerate((__loop11_var1.Parameters).GetEnumerator()) //114:11
                select new { __loop11_var1 = __loop11_var1, param = param}
                ).ToList(); //114:2
            int __loop11_iteration = 0;
            string delim = ""; //114:29
            foreach (var __tmp1 in __loop11_results)
            {
                ++__loop11_iteration;
                if (__loop11_iteration >= 2) //114:48
                {
                    delim = ", "; //114:48
                }
                var __loop11_var1 = __tmp1.__loop11_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(true) + " " + param.Name; //115:3
            }
            return result; //117:2
        }

        public string GetParameters(MetaOperation op, bool defaultValues) //120:1
        {
            string result = ""; //121:2
            var __loop12_results = 
                (from __loop12_var1 in __Enumerate((op).GetEnumerator()) //122:7
                from param in __Enumerate((__loop12_var1.Parameters).GetEnumerator()) //122:11
                select new { __loop12_var1 = __loop12_var1, param = param}
                ).ToList(); //122:2
            int __loop12_iteration = 0;
            string delim = ""; //122:29
            foreach (var __tmp1 in __loop12_results)
            {
                ++__loop12_iteration;
                if (__loop12_iteration >= 2) //122:48
                {
                    delim = ", "; //122:48
                }
                var __loop12_var1 = __tmp1.__loop12_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName() + " " + param.Name; //123:3
            }
            return result; //125:2
        }

        public string GetImplParameters(MetaClass cls, MetaOperation op) //128:1
        {
            string result = cls.CSharpFullName() + " @this"; //129:2
            string delim = ", "; //130:2
            var __loop13_results = 
                (from __loop13_var1 in __Enumerate((op).GetEnumerator()) //131:7
                from param in __Enumerate((__loop13_var1.Parameters).GetEnumerator()) //131:11
                select new { __loop13_var1 = __loop13_var1, param = param}
                ).ToList(); //131:2
            int __loop13_iteration = 0;
            foreach (var __tmp1 in __loop13_results)
            {
                ++__loop13_iteration;
                var __loop13_var1 = __tmp1.__loop13_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName() + " " + param.Name; //132:3
            }
            return result; //134:2
        }

        public string GetImplParameters(MetaEnum enm, MetaOperation op) //137:1
        {
            string result = enm.CSharpFullName() + " @this"; //138:2
            string delim = ", "; //139:2
            var __loop14_results = 
                (from __loop14_var1 in __Enumerate((op).GetEnumerator()) //140:7
                from param in __Enumerate((__loop14_var1.Parameters).GetEnumerator()) //140:11
                select new { __loop14_var1 = __loop14_var1, param = param}
                ).ToList(); //140:2
            int __loop14_iteration = 0;
            foreach (var __tmp1 in __loop14_results)
            {
                ++__loop14_iteration;
                var __loop14_var1 = __tmp1.__loop14_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName() + " " + param.Name; //141:3
            }
            return result; //143:2
        }

        public string GetEnumImplParameters(MetaEnum enm, MetaOperation op) //146:1
        {
            string result = "this " + enm.CSharpFullName() + " @this"; //147:2
            string delim = ", "; //148:2
            var __loop15_results = 
                (from __loop15_var1 in __Enumerate((op).GetEnumerator()) //149:7
                from param in __Enumerate((__loop15_var1.Parameters).GetEnumerator()) //149:11
                select new { __loop15_var1 = __loop15_var1, param = param}
                ).ToList(); //149:2
            int __loop15_iteration = 0;
            foreach (var __tmp1 in __loop15_results)
            {
                ++__loop15_iteration;
                var __loop15_var1 = __tmp1.__loop15_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName() + " " + param.Name; //150:3
            }
            return result; //152:2
        }

        public string GetEnumImplCallParameterNames(MetaOperation op) //155:1
        {
            string result = "@this"; //156:2
            string delim = ", "; //157:2
            var __loop16_results = 
                (from __loop16_var1 in __Enumerate((op).GetEnumerator()) //158:7
                from param in __Enumerate((__loop16_var1.Parameters).GetEnumerator()) //158:11
                select new { __loop16_var1 = __loop16_var1, param = param}
                ).ToList(); //158:2
            int __loop16_iteration = 0;
            foreach (var __tmp1 in __loop16_results)
            {
                ++__loop16_iteration;
                var __loop16_var1 = __tmp1.__loop16_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //159:3
            }
            return result; //161:2
        }

        public string GetImplCallParameterNames(MetaOperation op) //164:1
        {
            string result = "this"; //165:2
            string delim = ", "; //166:2
            var __loop17_results = 
                (from __loop17_var1 in __Enumerate((op).GetEnumerator()) //167:7
                from param in __Enumerate((__loop17_var1.Parameters).GetEnumerator()) //167:11
                select new { __loop17_var1 = __loop17_var1, param = param}
                ).ToList(); //167:2
            int __loop17_iteration = 0;
            foreach (var __tmp1 in __loop17_results)
            {
                ++__loop17_iteration;
                var __loop17_var1 = __tmp1.__loop17_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //168:3
            }
            return result; //170:2
        }

        public string GenerateImmutableOperation(MetaOperation op) //173:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(op.ReturnType.CSharpFullPublicName(true));
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
            string __tmp3Line = " "; //174:43
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
            string __tmp5Line = "("; //174:53
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(GetImmutableParameters(op, true));
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
            string __tmp7Line = ");"; //174:88
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //174:90
            return __out.ToString();
        }

        public string GenerateOperation(MetaOperation op) //177:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(op.ReturnType.CSharpFullPublicName());
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
            string __tmp3Line = " "; //178:39
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
            string __tmp5Line = "("; //178:49
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
            string __tmp7Line = ");"; //178:75
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //178:77
            return __out.ToString();
        }

        public string GenerateImmutableInterfaceImpl(MetaModel model, MetaClass cls) //181:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal class "; //182:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.CSharpImplName());
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
            string __tmp4Line = " : global::MetaDslx.Core.Immutable.ImmutableRedSymbolBase, "; //182:38
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(cls.CSharpFullName());
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
                    __out.AppendLine(false); //182:119
                }
            }
            __out.Append("{"); //183:1
            __out.AppendLine(false); //183:2
            var __loop18_results = 
                (from __loop18_var1 in __Enumerate((cls).GetEnumerator()) //184:11
                from prop in __Enumerate((__loop18_var1.GetAllProperties()).GetEnumerator()) //184:16
                select new { __loop18_var1 = __loop18_var1, prop = prop}
                ).ToList(); //184:6
            int __loop18_iteration = 0;
            foreach (var __tmp6 in __loop18_results)
            {
                ++__loop18_iteration;
                var __loop18_var1 = __tmp6.__loop18_var1;
                var prop = __tmp6.prop;
                string __tmp7Prefix = "    "; //185:1
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(GenerateImmutablePropertyImpl(model, cls, prop));
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
                        __out.AppendLine(false); //185:54
                    }
                }
            }
            __out.AppendLine(true); //187:1
            string __tmp10Line = "    internal "; //188:1
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
            string __tmp12Line = "(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableRedModelPart model)"; //188:36
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //188:142
            __out.Append("		: base(id, model)"); //189:1
            __out.AppendLine(false); //189:20
            __out.Append("    {"); //190:1
            __out.AppendLine(false); //190:6
            __out.Append("    }"); //191:1
            __out.AppendLine(false); //191:6
            __out.AppendLine(true); //192:1
            __out.Append("    public override global::MetaDslx.Core.Immutable.MetaModel MMetaModel"); //193:1
            __out.AppendLine(false); //193:73
            __out.Append("    {"); //194:1
            __out.AppendLine(false); //194:6
            string __tmp14Line = "        get { return "; //195:1
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
            string __tmp16Line = "; }"; //195:58
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            __out.AppendLine(false); //195:61
            __out.Append("    }"); //196:1
            __out.AppendLine(false); //196:6
            __out.AppendLine(true); //197:1
            __out.Append("    public override global::MetaDslx.Core.Immutable.ImmutableRedSymbol MMetaClass"); //198:1
            __out.AppendLine(false); //198:82
            __out.Append("    {"); //199:1
            __out.AppendLine(false); //199:6
            string __tmp18Line = "        get { return "; //200:1
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
            string __tmp20Line = "; }"; //200:52
            if (__tmp20Line != null) __out.Append(__tmp20Line);
            __out.AppendLine(false); //200:55
            __out.Append("    }"); //201:1
            __out.AppendLine(false); //201:6
            __out.AppendLine(true); //202:1
            var __loop19_results = 
                (from __loop19_var1 in __Enumerate((cls).GetEnumerator()) //203:11
                from prop in __Enumerate((__loop19_var1.GetAllProperties()).GetEnumerator()) //203:16
                select new { __loop19_var1 = __loop19_var1, prop = prop}
                ).ToList(); //203:6
            int __loop19_iteration = 0;
            foreach (var __tmp21 in __loop19_results)
            {
                ++__loop19_iteration;
                var __loop19_var1 = __tmp21.__loop19_var1;
                var prop = __tmp21.prop;
                string __tmp22Prefix = "    "; //204:1
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
                        __out.AppendLine(false); //204:54
                    }
                }
            }
            var __loop20_results = 
                (from __loop20_var1 in __Enumerate((cls).GetEnumerator()) //206:11
                from op in __Enumerate((__loop20_var1.GetAllOperations()).GetEnumerator()) //206:16
                select new { __loop20_var1 = __loop20_var1, op = op}
                ).ToList(); //206:6
            int __loop20_iteration = 0;
            foreach (var __tmp24 in __loop20_results)
            {
                ++__loop20_iteration;
                var __loop20_var1 = __tmp24.__loop20_var1;
                var op = __tmp24.op;
                string __tmp25Prefix = "    "; //207:1
                StringBuilder __tmp26 = new StringBuilder();
                __tmp26.Append(GenerateImmutableOperationImpl(model, op));
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
                        __out.AppendLine(false); //207:48
                    }
                }
            }
            __out.Append("}"); //209:1
            __out.AppendLine(false); //209:2
            __out.AppendLine(true); //210:1
            return __out.ToString();
        }

        public string GenerateInterfaceImpl(MetaModel model, MetaClass cls) //213:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal class "; //214:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.CSharpImplName());
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
            string __tmp4Line = " : global::MetaDslx.Core.Immutable.MutableRedSymbolBase, "; //214:38
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(cls.CSharpFullName());
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
                    __out.AppendLine(false); //214:117
                }
            }
            __out.Append("{"); //215:1
            __out.AppendLine(false); //215:2
            string __tmp7Line = "    internal "; //216:1
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(cls.CSharpImplName());
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
            string __tmp9Line = "(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableRedModelPart model)"; //216:36
            if (__tmp9Line != null) __out.Append(__tmp9Line);
            __out.AppendLine(false); //216:140
            __out.Append("		: base(id, model)"); //217:1
            __out.AppendLine(false); //217:20
            __out.Append("    {"); //218:1
            __out.AppendLine(false); //218:6
            var __loop21_results = 
                (from __loop21_var1 in __Enumerate((cls).GetEnumerator()) //219:9
                from prop in __Enumerate((__loop21_var1.GetAllProperties()).GetEnumerator()) //219:14
                select new { __loop21_var1 = __loop21_var1, prop = prop}
                ).ToList(); //219:4
            int __loop21_iteration = 0;
            foreach (var __tmp10 in __loop21_results)
            {
                ++__loop21_iteration;
                var __loop21_var1 = __tmp10.__loop21_var1;
                var prop = __tmp10.prop;
                string __tmp12Line = "        this.MAttachProperty("; //220:1
                if (__tmp12Line != null) __out.Append(__tmp12Line);
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(prop.CSharpFullDescriptorName());
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
                string __tmp14Line = ");"; //220:63
                if (__tmp14Line != null) __out.Append(__tmp14Line);
                __out.AppendLine(false); //220:65
            }
            __out.Append("        this.MInit();"); //222:1
            __out.AppendLine(false); //222:22
            __out.Append("    }"); //223:1
            __out.AppendLine(false); //223:6
            __out.AppendLine(true); //224:1
            __out.Append("    protected override void MDoInit()"); //225:1
            __out.AppendLine(false); //225:38
            __out.Append("    {"); //226:1
            __out.AppendLine(false); //226:6
            string __tmp15Prefix = "        "; //227:1
            StringBuilder __tmp16 = new StringBuilder();
            __tmp16.Append(GenerateInitImpl(model, cls));
            using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
            {
                bool __tmp16_first = true;
                bool __tmp16_last = __tmp16Reader.EndOfStream;
                while(__tmp16_first || !__tmp16_last)
                {
                    __tmp16_first = false;
                    string __tmp16Line = __tmp16Reader.ReadLine();
                    __tmp16_last = __tmp16Reader.EndOfStream;
                    __out.Append(__tmp15Prefix);
                    if (__tmp16Line != null) __out.Append(__tmp16Line);
                    if (!__tmp16_last) __out.AppendLine(true);
                    __out.AppendLine(false); //227:39
                }
            }
            __out.Append("    }"); //228:1
            __out.AppendLine(false); //228:6
            __out.AppendLine(true); //229:1
            __out.Append("    public override global::MetaDslx.Core.MetaModel MMetaModel"); //230:1
            __out.AppendLine(false); //230:63
            __out.Append("    {"); //231:1
            __out.AppendLine(false); //231:6
            string __tmp18Line = "        get { return "; //232:1
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            StringBuilder __tmp19 = new StringBuilder();
            __tmp19.Append(cls.Model.CSharpFullInstanceName());
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
            string __tmp20Line = "; }"; //232:58
            if (__tmp20Line != null) __out.Append(__tmp20Line);
            __out.AppendLine(false); //232:61
            __out.Append("    }"); //233:1
            __out.AppendLine(false); //233:6
            __out.AppendLine(true); //234:1
            __out.Append("    public override global::MetaDslx.Core.Immutable.MutableRedSymbol MMetaClass"); //235:1
            __out.AppendLine(false); //235:80
            __out.Append("    {"); //236:1
            __out.AppendLine(false); //236:6
            string __tmp22Line = "        get { return "; //237:1
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            StringBuilder __tmp23 = new StringBuilder();
            __tmp23.Append(cls.CSharpFullInstanceName());
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
            string __tmp24Line = "; }"; //237:52
            if (__tmp24Line != null) __out.Append(__tmp24Line);
            __out.AppendLine(false); //237:55
            __out.Append("    }"); //238:1
            __out.AppendLine(false); //238:6
            __out.AppendLine(true); //239:1
            var __loop22_results = 
                (from __loop22_var1 in __Enumerate((cls).GetEnumerator()) //240:11
                from prop in __Enumerate((__loop22_var1.GetAllProperties()).GetEnumerator()) //240:16
                select new { __loop22_var1 = __loop22_var1, prop = prop}
                ).ToList(); //240:6
            int __loop22_iteration = 0;
            foreach (var __tmp25 in __loop22_results)
            {
                ++__loop22_iteration;
                var __loop22_var1 = __tmp25.__loop22_var1;
                var prop = __tmp25.prop;
                string __tmp26Prefix = "    "; //241:1
                StringBuilder __tmp27 = new StringBuilder();
                __tmp27.Append(GeneratePropertyImpl(model, cls, prop));
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
                        __out.AppendLine(false); //241:45
                    }
                }
            }
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((cls).GetEnumerator()) //243:11
                from op in __Enumerate((__loop23_var1.GetAllOperations()).GetEnumerator()) //243:16
                select new { __loop23_var1 = __loop23_var1, op = op}
                ).ToList(); //243:6
            int __loop23_iteration = 0;
            foreach (var __tmp28 in __loop23_results)
            {
                ++__loop23_iteration;
                var __loop23_var1 = __tmp28.__loop23_var1;
                var op = __tmp28.op;
                string __tmp29Prefix = "    "; //244:1
                StringBuilder __tmp30 = new StringBuilder();
                __tmp30.Append(GenerateOperationImpl(model, op));
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
                        __out.AppendLine(false); //244:39
                    }
                }
            }
            __out.Append("}"); //246:1
            __out.AppendLine(false); //246:2
            __out.AppendLine(true); //247:1
            return __out.ToString();
        }

        public string GeneratePropertyDeclaration(MetaModel model, MetaClass cls, MetaProperty prop) //250:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class == cls) //251:2
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
                        __out.AppendLine(false); //252:28
                    }
                }
                if (prop.Kind == MetaPropertyKind.Containment) //253:2
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
                            __out.AppendLine(false); //254:27
                        }
                    }
                }
                if (prop.Kind != MetaPropertyKind.Normal && prop.Kind != MetaPropertyKind.Containment) //256:2
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
                            __out.AppendLine(false); //257:24
                        }
                    }
                }
                var __loop24_results = 
                    (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //259:7
                    select new { p = p}
                    ).ToList(); //259:2
                int __loop24_iteration = 0;
                foreach (var __tmp7 in __loop24_results)
                {
                    ++__loop24_iteration;
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
                            __out.AppendLine(false); //260:92
                        }
                    }
                }
                var __loop25_results = 
                    (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //262:7
                    select new { p = p}
                    ).ToList(); //262:2
                int __loop25_iteration = 0;
                foreach (var __tmp14 in __loop25_results)
                {
                    ++__loop25_iteration;
                    var p = __tmp14.p;
                    if (cls.GetAllSuperClasses(false).Contains(p.Class)) //263:3
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
                                __out.AppendLine(false); //264:91
                            }
                        }
                    }
                    else //265:3
                    {
                        string __tmp22Line = "// ERROR: subsetted property '"; //266:1
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
                        string __tmp24Line = "' must be a property of an ancestor class"; //266:61
                        if (__tmp24Line != null) __out.Append(__tmp24Line);
                        __out.AppendLine(false); //266:102
                    }
                }
                var __loop26_results = 
                    (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //269:7
                    select new { p = p}
                    ).ToList(); //269:2
                int __loop26_iteration = 0;
                foreach (var __tmp25 in __loop26_results)
                {
                    ++__loop26_iteration;
                    var p = __tmp25.p;
                    if (cls.GetAllSuperClasses(false).Contains(p.Class)) //270:3
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
                                __out.AppendLine(false); //271:93
                            }
                        }
                    }
                    else //272:3
                    {
                        string __tmp33Line = "// ERROR: redefined property '"; //273:1
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
                        string __tmp35Line = "' must be a property of an ancestor class"; //273:61
                        if (__tmp35Line != null) __out.Append(__tmp35Line);
                        __out.AppendLine(false); //273:102
                    }
                }
                string __tmp37Line = "public static readonly global::MetaDslx.Core.Immutable.ModelProperty "; //276:1
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
                string __tmp39Line = "Property ="; //276:81
                if (__tmp39Line != null) __out.Append(__tmp39Line);
                __out.AppendLine(false); //276:91
                string __tmp41Line = "    global::MetaDslx.Core.Immutable.ModelProperty.Register(\""; //277:1
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
                string __tmp43Line = "\", typeof("; //277:72
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
                string __tmp45Line = "Descriptor."; //277:117
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
                string __tmp47Line = ")"; //277:153
                if (__tmp47Line != null) __out.Append(__tmp47Line);
                __out.AppendLine(false); //277:154
                string __tmp49Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //278:1
                if (__tmp49Line != null) __out.Append(__tmp49Line);
                StringBuilder __tmp50 = new StringBuilder();
                __tmp50.Append(prop.Type.CSharpFullPublicName());
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
                string __tmp51Line = "), typeof("; //278:108
                if (__tmp51Line != null) __out.Append(__tmp51Line);
                StringBuilder __tmp52 = new StringBuilder();
                __tmp52.Append(prop.Type.CSharpFullPublicName());
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
                string __tmp53Line = "), typeof("; //278:152
                if (__tmp53Line != null) __out.Append(__tmp53Line);
                StringBuilder __tmp54 = new StringBuilder();
                __tmp54.Append(prop.Class.CSharpFullName(true));
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
                string __tmp55Line = ")),"; //278:195
                if (__tmp55Line != null) __out.Append(__tmp55Line);
                __out.AppendLine(false); //278:198
                string __tmp57Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //279:1
                if (__tmp57Line != null) __out.Append(__tmp57Line);
                StringBuilder __tmp58 = new StringBuilder();
                __tmp58.Append(prop.Type.CSharpFullPublicName());
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
                string __tmp59Line = "), typeof("; //279:108
                if (__tmp59Line != null) __out.Append(__tmp59Line);
                StringBuilder __tmp60 = new StringBuilder();
                __tmp60.Append(prop.Type.CSharpFullPublicName());
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
                string __tmp61Line = "), typeof("; //279:152
                if (__tmp61Line != null) __out.Append(__tmp61Line);
                StringBuilder __tmp62 = new StringBuilder();
                __tmp62.Append(prop.Class.CSharpFullName(false));
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
                string __tmp63Line = ")),"; //279:196
                if (__tmp63Line != null) __out.Append(__tmp63Line);
                __out.AppendLine(false); //279:199
                string __tmp65Line = "		() => "; //280:1
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
                string __tmp67Line = "Instance."; //280:44
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
                string __tmp69Line = "_"; //280:78
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
                string __tmp71Line = "Property);"; //280:90
                if (__tmp71Line != null) __out.Append(__tmp71Line);
                __out.AppendLine(false); //280:100
            }
            __out.AppendLine(true); //282:1
            return __out.ToString();
        }

        public string GenerateImmutablePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //285:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //286:1
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(prop.Type.CSharpFullPublicName(true));
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
            string __tmp3Line = " "; //287:39
            if (__tmp3Line != null) __out.Append(__tmp3Line);
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(prop.Class.CSharpFullName(true));
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
            string __tmp5Line = "."; //287:73
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(prop.Name);
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
                    __out.AppendLine(false); //287:85
                }
            }
            __out.Append("{"); //288:1
            __out.AppendLine(false); //288:2
            __out.Append("    get "); //289:1
            __out.AppendLine(false); //289:9
            __out.Append("    {"); //290:1
            __out.AppendLine(false); //290:6
            string __tmp8Line = "        return this.GetValue("; //291:1
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(prop.Type.CSharpFullPublicName());
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
            string __tmp10Line = ", ref "; //291:64
            if (__tmp10Line != null) __out.Append(__tmp10Line);
            StringBuilder __tmp11 = new StringBuilder();
            __tmp11.Append(this.prop.Name.ToCamelCase());
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
            string __tmp12Line = ");"; //291:100
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //291:102
            __out.Append("    }"); //292:1
            __out.AppendLine(false); //292:6
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //293:3
            {
                string __tmp14Line = "    set { this.MSet("; //294:1
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
                string __tmp16Line = ", value); }"; //294:54
                if (__tmp16Line != null) __out.Append(__tmp16Line);
                __out.AppendLine(false); //294:65
            }
            __out.Append("}"); //296:1
            __out.AppendLine(false); //296:2
            return __out.ToString();
        }

        public string GeneratePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //299:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //300:1
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
            string __tmp3Line = " "; //301:35
            if (__tmp3Line != null) __out.Append(__tmp3Line);
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(prop.Class.CSharpFullName());
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
            string __tmp5Line = "."; //301:65
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(prop.Name);
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
                    __out.AppendLine(false); //301:77
                }
            }
            __out.Append("{"); //302:1
            __out.AppendLine(false); //302:2
            __out.Append("    get "); //303:1
            __out.AppendLine(false); //303:9
            __out.Append("    {"); //304:1
            __out.AppendLine(false); //304:6
            string __tmp8Line = "        object result = this.MGet("; //305:1
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(prop.CSharpFullDescriptorName());
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
            string __tmp10Line = "); "; //305:68
            if (__tmp10Line != null) __out.Append(__tmp10Line);
            __out.AppendLine(false); //305:71
            string __tmp12Line = "        if (result != null) return ("; //306:1
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(prop.Type.CSharpFullPublicName());
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
            string __tmp14Line = ")result;"; //306:71
            if (__tmp14Line != null) __out.Append(__tmp14Line);
            __out.AppendLine(false); //306:79
            string __tmp16Line = "        else return default("; //307:1
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(prop.Type.CSharpFullPublicName());
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
            string __tmp18Line = ");"; //307:63
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //307:65
            __out.Append("    }"); //308:1
            __out.AppendLine(false); //308:6
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //309:3
            {
                string __tmp20Line = "    set { this.MSet("; //310:1
                if (__tmp20Line != null) __out.Append(__tmp20Line);
                StringBuilder __tmp21 = new StringBuilder();
                __tmp21.Append(prop.CSharpFullDescriptorName());
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
                string __tmp22Line = ", value); }"; //310:54
                if (__tmp22Line != null) __out.Append(__tmp22Line);
                __out.AppendLine(false); //310:65
            }
            __out.Append("}"); //312:1
            __out.AppendLine(false); //312:2
            return __out.ToString();
        }

        public string GetCollectionConstructorParams(MetaProperty prop) //315:1
        {
            MetaCollectionType mct = prop.Type as MetaCollectionType; //316:2
            if (mct != null && mct.InnerType is MetaClass) //317:2
            {
                return "this, " + prop.CSharpFullDescriptorName(); //318:3
            }
            else //319:2
            {
                return ""; //320:3
            }
        }

        public string GenerateExpression(MetaExpression expr) //325:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //326:10
            if (expr is MetaBracketExpression) //327:2
            {
                string __tmp4Line = "("; //327:33
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
                string __tmp6Line = ")"; //327:71
                if (__tmp6Line != null) __out.Append(__tmp6Line);
            }
            else if (expr is MetaThisExpression) //328:2
            {
                string __tmp9Line = "(("; //328:30
                if (__tmp9Line != null) __out.Append(__tmp9Line);
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(((MetaType)ModelContext.Current.Compiler.ResolutionProvider.GetCurrentTypeScopeOf((ModelObject)((MetaThisExpression)expr))).CSharpName());
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
                string __tmp11Line = ")this)"; //328:148
                if (__tmp11Line != null) __out.Append(__tmp11Line);
            }
            else if (expr is MetaNullExpression) //329:2
            {
                __out.Append("null"); //329:30
            }
            else if (expr is MetaTypeAsExpression) //330:2
            {
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(GenerateExpression(((MetaTypeAsExpression)expr).Expression));
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
                string __tmp15Line = " as "; //330:69
                if (__tmp15Line != null) __out.Append(__tmp15Line);
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(((MetaTypeAsExpression)expr).TypeReference.CSharpName());
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
            }
            else if (expr is MetaTypeCastExpression) //331:2
            {
                string __tmp19Line = "("; //331:34
                if (__tmp19Line != null) __out.Append(__tmp19Line);
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(((MetaTypeCastExpression)expr).TypeReference.CSharpName());
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
                string __tmp21Line = ")"; //331:68
                if (__tmp21Line != null) __out.Append(__tmp21Line);
                StringBuilder __tmp22 = new StringBuilder();
                __tmp22.Append(GenerateExpression(((MetaTypeCastExpression)expr).Expression));
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
            else if (expr is MetaTypeCheckExpression) //332:2
            {
                StringBuilder __tmp25 = new StringBuilder();
                __tmp25.Append(GenerateExpression(((MetaTypeCheckExpression)expr).Expression));
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
                string __tmp26Line = " is "; //332:72
                if (__tmp26Line != null) __out.Append(__tmp26Line);
                StringBuilder __tmp27 = new StringBuilder();
                __tmp27.Append(((MetaTypeCheckExpression)expr).TypeReference.CSharpName());
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
            }
            else if (expr is MetaTypeOfExpression) //333:2
            {
                StringBuilder __tmp30 = new StringBuilder();
                __tmp30.Append(GenerateTypeOf(((MetaTypeOfExpression)expr)));
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
            }
            else if (expr is MetaConditionalExpression) //334:2
            {
                StringBuilder __tmp33 = new StringBuilder();
                __tmp33.Append(GenerateExpression(((MetaConditionalExpression)expr).Condition));
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
                string __tmp34Line = " ? "; //334:73
                if (__tmp34Line != null) __out.Append(__tmp34Line);
                StringBuilder __tmp35 = new StringBuilder();
                __tmp35.Append(GenerateExpression(((MetaConditionalExpression)expr).Then));
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
                string __tmp36Line = " : "; //334:107
                if (__tmp36Line != null) __out.Append(__tmp36Line);
                StringBuilder __tmp37 = new StringBuilder();
                __tmp37.Append(GenerateExpression(((MetaConditionalExpression)expr).Else));
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
            }
            else if (expr is MetaConstantExpression) //335:2
            {
                StringBuilder __tmp40 = new StringBuilder();
                __tmp40.Append(GetCSharpValue(((MetaConstantExpression)expr).Value));
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
            }
            else if (expr is MetaIdentifierExpression) //336:2
            {
                StringBuilder __tmp43 = new StringBuilder();
                __tmp43.Append(GenerateIdentifierExpression(((MetaIdentifierExpression)expr)));
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
            else if (expr is MetaMemberAccessExpression) //337:2
            {
                StringBuilder __tmp46 = new StringBuilder();
                __tmp46.Append(GenerateExpression(((MetaMemberAccessExpression)expr).Expression));
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
                string __tmp47Line = "."; //337:75
                if (__tmp47Line != null) __out.Append(__tmp47Line);
                StringBuilder __tmp48 = new StringBuilder();
                __tmp48.Append(((MetaMemberAccessExpression)expr).Name);
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
            }
            else if (expr is MetaFunctionCallExpression) //338:2
            {
                StringBuilder __tmp51 = new StringBuilder();
                __tmp51.Append(GenerateFunctionCall(((MetaFunctionCallExpression)expr)));
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
            }
            else if (expr is MetaIndexerExpression) //339:2
            {
                StringBuilder __tmp54 = new StringBuilder();
                __tmp54.Append(GenerateIndexerCall(((MetaIndexerExpression)expr)));
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
            }
            else if (expr is MetaOperatorExpression) //340:2
            {
                StringBuilder __tmp57 = new StringBuilder();
                __tmp57.Append(GenerateOperator(((MetaOperatorExpression)expr)));
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
            }
            else if (expr is MetaNewExpression) //341:2
            {
                StringBuilder __tmp60 = new StringBuilder();
                __tmp60.Append(((MetaNewExpression)expr).TypeReference.CSharpFullFactoryMethodName());
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
                string __tmp61Line = "("; //341:79
                if (__tmp61Line != null) __out.Append(__tmp61Line);
                StringBuilder __tmp62 = new StringBuilder();
                __tmp62.Append(GenerateNewPropertyInitializers(((MetaNewExpression)expr)));
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
                string __tmp63Line = ")"; //341:119
                if (__tmp63Line != null) __out.Append(__tmp63Line);
            }
            else if (expr is MetaNewCollectionExpression) //342:2
            {
                string __tmp66Line = "new List<Lazy<object>>() { "; //342:39
                if (__tmp66Line != null) __out.Append(__tmp66Line);
                StringBuilder __tmp67 = new StringBuilder();
                __tmp67.Append(GenerateNewCollectionValues(((MetaNewCollectionExpression)expr)));
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
                string __tmp68Line = " }"; //342:101
                if (__tmp68Line != null) __out.Append(__tmp68Line);
            }
            else //343:2
            {
                __out.Append("***unknown expression type***"); //343:11
                __out.AppendLine(false); //343:40
            }//344:2
            return __out.ToString();
        }

        public string GenerateIdentifierExpression(MetaIdentifierExpression expr) //347:1
        {
            StringBuilder __out = new StringBuilder();
            if (expr.Definition is MetaProperty) //348:2
            {
                string __tmp2Line = "(("; //349:1
                if (__tmp2Line != null) __out.Append(__tmp2Line);
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(((MetaType)ModelContext.Current.Compiler.ResolutionProvider.GetCurrentTypeScopeOf((ModelObject)expr)).CSharpName());
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
                string __tmp4Line = ")this)."; //349:119
                if (__tmp4Line != null) __out.Append(__tmp4Line);
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
            else //350:2
            {
                StringBuilder __tmp7 = new StringBuilder();
                __tmp7.Append(expr.Name);
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
            return __out.ToString();
        }

        public bool SameFunction(MetaGlobalFunction mfunc1, MetaGlobalFunction mfunc2) //355:1
        {
            return mfunc1.Name == mfunc2.Name && ModelContext.Current.Compiler.TypeProvider.Equals((ModelObject)mfunc1.Type, (ModelObject)mfunc2.Type); //356:2
        }

        public string GenerateFunctionCall(MetaFunctionCallExpression call) //359:1
        {
            StringBuilder __out = new StringBuilder();
            if (call.Definition is MetaGlobalFunction && SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.TypeOf)) //360:2
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
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.GetValueType)) //361:2
            {
                string __tmp6Line = "ModelContext.Current.Compiler.TypeProvider.GetTypeOf("; //361:89
                if (__tmp6Line != null) __out.Append(__tmp6Line);
                StringBuilder __tmp7 = new StringBuilder();
                __tmp7.Append(GenerateCallArguments(call, ""));
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
                string __tmp8Line = ")"; //361:175
                if (__tmp8Line != null) __out.Append(__tmp8Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.GetReturnType)) //362:2
            {
                string __tmp11Line = "ModelContext.Current.Compiler.TypeProvider.GetReturnTypeOf("; //362:90
                if (__tmp11Line != null) __out.Append(__tmp11Line);
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(GenerateCallArguments(call, "(ModelObject)"));
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
                string __tmp13Line = ")"; //362:195
                if (__tmp13Line != null) __out.Append(__tmp13Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.CurrentType)) //363:2
            {
                string __tmp16Line = "ModelContext.Current.Compiler.ResolutionProvider.GetCurrentTypeScopeOf("; //363:88
                if (__tmp16Line != null) __out.Append(__tmp16Line);
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(GenerateCallArguments(call, "(ModelObject)"));
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
                string __tmp18Line = ")"; //363:205
                if (__tmp18Line != null) __out.Append(__tmp18Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.TypeCheck)) //364:2
            {
                string __tmp21Line = "ModelContext.Current.Compiler.TypeProvider.TypeCheck("; //364:86
                if (__tmp21Line != null) __out.Append(__tmp21Line);
                StringBuilder __tmp22 = new StringBuilder();
                __tmp22.Append(GenerateCallArguments(call, "(ModelObject)"));
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
                string __tmp23Line = ")"; //364:185
                if (__tmp23Line != null) __out.Append(__tmp23Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Balance)) //365:2
            {
                string __tmp26Line = "ModelContext.Current.Compiler.TypeProvider.Balance("; //365:84
                if (__tmp26Line != null) __out.Append(__tmp26Line);
                StringBuilder __tmp27 = new StringBuilder();
                __tmp27.Append(GenerateCallArguments(call, "(ModelObject)"));
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
                string __tmp28Line = ")"; //365:181
                if (__tmp28Line != null) __out.Append(__tmp28Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Resolve1)) //366:2
            {
                string __tmp31Line = "ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"; //366:85
                if (__tmp31Line != null) __out.Append(__tmp31Line);
                StringBuilder __tmp32 = new StringBuilder();
                __tmp32.Append("[]");
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
                string __tmp33Line = " { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.NameOrType, "; //366:163
                if (__tmp33Line != null) __out.Append(__tmp33Line);
                StringBuilder __tmp34 = new StringBuilder();
                __tmp34.Append(GenerateExpression(call.Arguments[0]));
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
                string __tmp35Line = ", new ResolutionInfo(), ResolveFlags.All)"; //366:303
                if (__tmp35Line != null) __out.Append(__tmp35Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Resolve2)) //367:2
            {
                string __tmp38Line = "ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"; //367:85
                if (__tmp38Line != null) __out.Append(__tmp38Line);
                StringBuilder __tmp39 = new StringBuilder();
                __tmp39.Append("[]");
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
                string __tmp40Line = " { (ModelObject)"; //367:163
                if (__tmp40Line != null) __out.Append(__tmp40Line);
                StringBuilder __tmp41 = new StringBuilder();
                __tmp41.Append(GenerateExpression(call.Arguments[0]));
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
                string __tmp42Line = " }, ResolveKind.NameOrType, "; //367:218
                if (__tmp42Line != null) __out.Append(__tmp42Line);
                StringBuilder __tmp43 = new StringBuilder();
                __tmp43.Append(GenerateExpression(call.Arguments[1]));
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
                string __tmp44Line = ", new ResolutionInfo(), ResolveFlags.All)"; //367:285
                if (__tmp44Line != null) __out.Append(__tmp44Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveType1)) //368:2
            {
                string __tmp47Line = "ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"; //368:89
                if (__tmp47Line != null) __out.Append(__tmp47Line);
                StringBuilder __tmp48 = new StringBuilder();
                __tmp48.Append("[]");
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
                string __tmp49Line = " { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Type, "; //368:167
                if (__tmp49Line != null) __out.Append(__tmp49Line);
                StringBuilder __tmp50 = new StringBuilder();
                __tmp50.Append(GenerateExpression(call.Arguments[0]));
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
                string __tmp51Line = ", new ResolutionInfo(), ResolveFlags.All)"; //368:301
                if (__tmp51Line != null) __out.Append(__tmp51Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveType2)) //369:2
            {
                string __tmp54Line = "ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"; //369:89
                if (__tmp54Line != null) __out.Append(__tmp54Line);
                StringBuilder __tmp55 = new StringBuilder();
                __tmp55.Append("[]");
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
                string __tmp56Line = " { (ModelObject)"; //369:167
                if (__tmp56Line != null) __out.Append(__tmp56Line);
                StringBuilder __tmp57 = new StringBuilder();
                __tmp57.Append(GenerateExpression(call.Arguments[0]));
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
                string __tmp58Line = " }, ResolveKind.Type, "; //369:222
                if (__tmp58Line != null) __out.Append(__tmp58Line);
                StringBuilder __tmp59 = new StringBuilder();
                __tmp59.Append(GenerateExpression(call.Arguments[1]));
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
                string __tmp60Line = ", new ResolutionInfo(), ResolveFlags.All)"; //369:283
                if (__tmp60Line != null) __out.Append(__tmp60Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveName1)) //370:2
            {
                string __tmp63Line = "ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"; //370:89
                if (__tmp63Line != null) __out.Append(__tmp63Line);
                StringBuilder __tmp64 = new StringBuilder();
                __tmp64.Append("[]");
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
                string __tmp65Line = " { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, "; //370:167
                if (__tmp65Line != null) __out.Append(__tmp65Line);
                StringBuilder __tmp66 = new StringBuilder();
                __tmp66.Append(GenerateExpression(call.Arguments[0]));
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
                string __tmp67Line = ", new ResolutionInfo(), ResolveFlags.All)"; //370:301
                if (__tmp67Line != null) __out.Append(__tmp67Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveName2)) //371:2
            {
                string __tmp70Line = "ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"; //371:89
                if (__tmp70Line != null) __out.Append(__tmp70Line);
                StringBuilder __tmp71 = new StringBuilder();
                __tmp71.Append("[]");
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
                string __tmp72Line = " { (ModelObject)"; //371:167
                if (__tmp72Line != null) __out.Append(__tmp72Line);
                StringBuilder __tmp73 = new StringBuilder();
                __tmp73.Append(GenerateExpression(call.Arguments[0]));
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
                string __tmp74Line = " }, ResolveKind.Name, "; //371:222
                if (__tmp74Line != null) __out.Append(__tmp74Line);
                StringBuilder __tmp75 = new StringBuilder();
                __tmp75.Append(GenerateExpression(call.Arguments[1]));
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
                    }
                }
                string __tmp76Line = ", new ResolutionInfo(), ResolveFlags.All)"; //371:283
                if (__tmp76Line != null) __out.Append(__tmp76Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind1)) //372:2
            {
                string __tmp79Line = "ModelContext.Current.Compiler.BindingProvider.Bind(this, new ModelObject"; //372:82
                if (__tmp79Line != null) __out.Append(__tmp79Line);
                StringBuilder __tmp80 = new StringBuilder();
                __tmp80.Append("[]");
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
                string __tmp81Line = " { (ModelObject)"; //372:160
                if (__tmp81Line != null) __out.Append(__tmp81Line);
                StringBuilder __tmp82 = new StringBuilder();
                __tmp82.Append(GenerateExpression(call.Arguments[0]));
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
                string __tmp83Line = " }, new BindingInfo())"; //372:215
                if (__tmp83Line != null) __out.Append(__tmp83Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind2)) //373:2
            {
                string __tmp86Line = "ModelContext.Current.Compiler.BindingProvider.Bind(this, "; //373:82
                if (__tmp86Line != null) __out.Append(__tmp86Line);
                StringBuilder __tmp87 = new StringBuilder();
                __tmp87.Append(GenerateExpression(call.Arguments[0]));
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
                string __tmp88Line = ", new BindingInfo())"; //373:178
                if (__tmp88Line != null) __out.Append(__tmp88Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind3)) //374:2
            {
                string __tmp91Line = "ModelContext.Current.Compiler.BindingProvider.Bind((ModelObject)"; //374:82
                if (__tmp91Line != null) __out.Append(__tmp91Line);
                StringBuilder __tmp92 = new StringBuilder();
                __tmp92.Append(GenerateExpression(call.Arguments[0]));
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
                string __tmp93Line = ", new ModelObject"; //374:185
                if (__tmp93Line != null) __out.Append(__tmp93Line);
                StringBuilder __tmp94 = new StringBuilder();
                __tmp94.Append("[]");
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
                string __tmp95Line = " { (ModelObject)"; //374:208
                if (__tmp95Line != null) __out.Append(__tmp95Line);
                StringBuilder __tmp96 = new StringBuilder();
                __tmp96.Append(GenerateExpression(call.Arguments[1]));
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
                string __tmp97Line = " }, new BindingInfo())"; //374:263
                if (__tmp97Line != null) __out.Append(__tmp97Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind4)) //375:2
            {
                string __tmp100Line = "ModelContext.Current.Compiler.BindingProvider.Bind((ModelObject)"; //375:82
                if (__tmp100Line != null) __out.Append(__tmp100Line);
                StringBuilder __tmp101 = new StringBuilder();
                __tmp101.Append(GenerateExpression(call.Arguments[0]));
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
                string __tmp102Line = ", "; //375:185
                if (__tmp102Line != null) __out.Append(__tmp102Line);
                StringBuilder __tmp103 = new StringBuilder();
                __tmp103.Append(GenerateExpression(call.Arguments[1]));
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
                string __tmp104Line = ", new BindingInfo())"; //375:226
                if (__tmp104Line != null) __out.Append(__tmp104Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.SelectOfType1)) //376:2
            {
                string __tmp107Line = "new object"; //376:90
                if (__tmp107Line != null) __out.Append(__tmp107Line);
                StringBuilder __tmp108 = new StringBuilder();
                __tmp108.Append("[]");
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
                string __tmp109Line = " { "; //376:106
                if (__tmp109Line != null) __out.Append(__tmp109Line);
                StringBuilder __tmp110 = new StringBuilder();
                __tmp110.Append(GenerateExpression(call.Arguments[0]));
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
                string __tmp111Line = " }.Where(e => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(e) is "; //376:148
                if (__tmp111Line != null) __out.Append(__tmp111Line);
                StringBuilder __tmp112 = new StringBuilder();
                __tmp112.Append(GetTypeName(call.Arguments[1]));
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
                string __tmp113Line = ").OfType<ModelObject>().ToList()"; //376:253
                if (__tmp113Line != null) __out.Append(__tmp113Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.SelectOfType2)) //377:2
            {
                string __tmp116Line = "("; //377:90
                if (__tmp116Line != null) __out.Append(__tmp116Line);
                StringBuilder __tmp117 = new StringBuilder();
                __tmp117.Append(GenerateExpression(call.Arguments[0]));
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
                string __tmp118Line = ").Where(e => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(e) is "; //377:130
                if (__tmp118Line != null) __out.Append(__tmp118Line);
                StringBuilder __tmp119 = new StringBuilder();
                __tmp119.Append(GetTypeName(call.Arguments[1]));
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
                string __tmp120Line = ").OfType<ModelObject>().ToList()"; //377:234
                if (__tmp120Line != null) __out.Append(__tmp120Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.SelectOfName1)) //378:2
            {
                string __tmp123Line = "new object"; //378:90
                if (__tmp123Line != null) __out.Append(__tmp123Line);
                StringBuilder __tmp124 = new StringBuilder();
                __tmp124.Append("[]");
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
                string __tmp125Line = " { "; //378:106
                if (__tmp125Line != null) __out.Append(__tmp125Line);
                StringBuilder __tmp126 = new StringBuilder();
                __tmp126.Append(GenerateExpression(call.Arguments[0]));
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
                string __tmp127Line = " }.Where(e => ModelContext.Current.Compiler.NameProvider.GetNameOf((ModelObject)e) == "; //378:148
                if (__tmp127Line != null) __out.Append(__tmp127Line);
                StringBuilder __tmp128 = new StringBuilder();
                __tmp128.Append(GenerateExpression(call.Arguments[1]));
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
                string __tmp129Line = ").OfType<ModelObject>().ToList()"; //378:273
                if (__tmp129Line != null) __out.Append(__tmp129Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.SelectOfName2)) //379:2
            {
                string __tmp132Line = "("; //379:90
                if (__tmp132Line != null) __out.Append(__tmp132Line);
                StringBuilder __tmp133 = new StringBuilder();
                __tmp133.Append(GenerateExpression(call.Arguments[0]));
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
                string __tmp134Line = ").Where(e => ModelContext.Current.Compiler.NameProvider.GetNameOf((ModelObject)e) == "; //379:130
                if (__tmp134Line != null) __out.Append(__tmp134Line);
                StringBuilder __tmp135 = new StringBuilder();
                __tmp135.Append(GenerateExpression(call.Arguments[1]));
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
                string __tmp136Line = ").OfType<ModelObject>().ToList()"; //379:254
                if (__tmp136Line != null) __out.Append(__tmp136Line);
            }
            else //380:2
            {
                StringBuilder __tmp139 = new StringBuilder();
                __tmp139.Append(GenerateExpression(call.Expression));
                using(StreamReader __tmp139Reader = new StreamReader(this.__ToStream(__tmp139.ToString())))
                {
                    bool __tmp139_first = true;
                    bool __tmp139_last = __tmp139Reader.EndOfStream;
                    while(__tmp139_first || !__tmp139_last)
                    {
                        __tmp139_first = false;
                        string __tmp139Line = __tmp139Reader.ReadLine();
                        __tmp139_last = __tmp139Reader.EndOfStream;
                        if (__tmp139Line != null) __out.Append(__tmp139Line);
                        if (!__tmp139_last) __out.AppendLine(true);
                    }
                }
                string __tmp140Line = "("; //380:44
                if (__tmp140Line != null) __out.Append(__tmp140Line);
                StringBuilder __tmp141 = new StringBuilder();
                __tmp141.Append(GenerateCallArguments(call, ""));
                using(StreamReader __tmp141Reader = new StreamReader(this.__ToStream(__tmp141.ToString())))
                {
                    bool __tmp141_first = true;
                    bool __tmp141_last = __tmp141Reader.EndOfStream;
                    while(__tmp141_first || !__tmp141_last)
                    {
                        __tmp141_first = false;
                        string __tmp141Line = __tmp141Reader.ReadLine();
                        __tmp141_last = __tmp141Reader.EndOfStream;
                        if (__tmp141Line != null) __out.Append(__tmp141Line);
                        if (!__tmp141_last) __out.AppendLine(true);
                    }
                }
                string __tmp142Line = ")"; //380:78
                if (__tmp142Line != null) __out.Append(__tmp142Line);
            }
            return __out.ToString();
        }

        public string GenerateIndexerCall(MetaIndexerExpression call) //384:1
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

        public string GenerateTypeOf(object expr) //388:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //389:9
            if (expr is MetaPrimitiveType) //390:2
            {
                var __tmp2 = ((MetaPrimitiveType)expr).Name; //391:10
                __out.Append("	"); //392:1
                if (__tmp2 == "*none*") //392:3
                {
                    __out.Append("MetaInstance.None"); //392:18
                    __out.Append("	"); //393:1
                }
                else if (__tmp2 == "*error*") //393:3
                {
                    __out.Append("MetaInstance.Error"); //393:19
                    __out.Append("	"); //394:1
                }
                else if (__tmp2 == "*any*") //394:3
                {
                    __out.Append("MetaInstance.Any"); //394:17
                    __out.Append("	"); //395:1
                }
                else if (__tmp2 == "object") //395:3
                {
                    __out.Append("MetaInstance.Object"); //395:18
                    __out.Append("	"); //396:1
                }
                else if (__tmp2 == "string") //396:3
                {
                    __out.Append("MetaInstance.String"); //396:18
                    __out.Append("	"); //397:1
                }
                else if (__tmp2 == "int") //397:3
                {
                    __out.Append("MetaInstance.Int"); //397:15
                    __out.Append("	"); //398:1
                }
                else if (__tmp2 == "long") //398:3
                {
                    __out.Append("MetaInstance.Long"); //398:16
                    __out.Append("	"); //399:1
                }
                else if (__tmp2 == "float") //399:3
                {
                    __out.Append("MetaInstance.Float"); //399:17
                    __out.Append("	"); //400:1
                }
                else if (__tmp2 == "double") //400:3
                {
                    __out.Append("MetaInstance.Double"); //400:18
                    __out.Append("	"); //401:1
                }
                else if (__tmp2 == "byte") //401:3
                {
                    __out.Append("MetaInstance.Byte"); //401:16
                    __out.Append("	"); //402:1
                }
                else if (__tmp2 == "bool") //402:3
                {
                    __out.Append("MetaInstance.Bool"); //402:16
                    __out.Append("	"); //403:1
                }
                else if (__tmp2 == "void") //403:3
                {
                    __out.Append("MetaInstance.Void"); //403:16
                    __out.Append("	"); //404:1
                }
                else if (__tmp2 == "ModelObject") //404:3
                {
                    __out.Append("MetaInstance.ModelObject"); //404:23
                    __out.Append("	"); //405:1
                }
                else if (__tmp2 == "ModelObjectList") //405:3
                {
                    __out.Append("MetaInstance.ModelObjectList"); //405:27
                }//406:3
            }
            else if (expr is MetaTypeOfExpression) //407:2
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
            else if (expr is MetaClass) //408:2
            {
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(((MetaClass)expr).CSharpFullDescriptorName());
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
                string __tmp9Line = ".MetaClass"; //408:54
                if (__tmp9Line != null) __out.Append(__tmp9Line);
            }
            else if (expr is MetaCollectionType) //409:2
            {
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(((MetaCollectionType)expr).CSharpFullName());
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
            else //410:2
            {
                __out.Append("***error***"); //410:11
            }//411:2
            return __out.ToString();
        }

        public string GenerateCallArguments(MetaBoundExpression call, string prefix) //414:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop27_results = 
                (from __loop27_var1 in __Enumerate((call).GetEnumerator()) //415:7
                from arg in __Enumerate((__loop27_var1.Arguments).GetEnumerator()) //415:13
                select new { __loop27_var1 = __loop27_var1, arg = arg}
                ).ToList(); //415:2
            int __loop27_iteration = 0;
            string delim = ""; //415:28
            foreach (var __tmp1 in __loop27_results)
            {
                ++__loop27_iteration;
                if (__loop27_iteration >= 2) //415:47
                {
                    delim = ", "; //415:47
                }
                var __loop27_var1 = __tmp1.__loop27_var1;
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

        public string GenerateOperator(MetaOperatorExpression expr) //420:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //421:10
            if (expr is MetaUnaryExpression) //422:2
            {
                if (((MetaUnaryExpression)expr) is MetaPostIncrementAssignExpression || ((MetaUnaryExpression)expr) is MetaPostDecrementAssignExpression) //423:3
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
                else //425:3
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
            else if (expr is MetaBinaryExpression) //428:2
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
            }//430:2
            return __out.ToString();
        }

        public string GenerateNewPropertyInitializers(MetaNewExpression expr) //433:1
        {
            StringBuilder __out = new StringBuilder();
            if ((from __loop28_var1 in __Enumerate((expr).GetEnumerator()) //434:14
            from pi in __Enumerate((__loop28_var1.PropertyInitializers).GetEnumerator()) //434:20
            select new { __loop28_var1 = __loop28_var1, pi = pi}
            ).GetEnumerator().MoveNext()) //434:2
            {
                __out.Append("new List<ModelPropertyInitializer>() {"); //435:1
                var __loop29_results = 
                    (from __loop29_var1 in __Enumerate((expr).GetEnumerator()) //436:7
                    from pi in __Enumerate((__loop29_var1.PropertyInitializers).GetEnumerator()) //436:13
                    select new { __loop29_var1 = __loop29_var1, pi = pi}
                    ).ToList(); //436:2
                int __loop29_iteration = 0;
                string delim = ""; //436:38
                foreach (var __tmp1 in __loop29_results)
                {
                    ++__loop29_iteration;
                    if (__loop29_iteration >= 2) //436:57
                    {
                        delim = ", "; //436:57
                    }
                    var __loop29_var1 = __tmp1.__loop29_var1;
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
                    string __tmp4Line = "new ModelPropertyInitializer("; //437:8
                    if (__tmp4Line != null) __out.Append(__tmp4Line);
                    StringBuilder __tmp5 = new StringBuilder();
                    __tmp5.Append(pi.Property.CSharpFullDescriptorName());
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
                    string __tmp6Line = ", new Lazy<object>(() => "; //437:77
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
                    string __tmp8Line = ", LazyThreadSafetyMode.ExecutionAndPublication))"; //437:132
                    if (__tmp8Line != null) __out.Append(__tmp8Line);
                }
                __out.Append("}"); //439:1
            }
            return __out.ToString();
        }

        public string GenerateNewCollectionValues(MetaNewCollectionExpression expr) //443:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop30_results = 
                (from __loop30_var1 in __Enumerate((expr).GetEnumerator()) //444:7
                from v in __Enumerate((__loop30_var1.Values).GetEnumerator()) //444:13
                select new { __loop30_var1 = __loop30_var1, v = v}
                ).ToList(); //444:2
            int __loop30_iteration = 0;
            string delim = ""; //444:23
            foreach (var __tmp1 in __loop30_results)
            {
                ++__loop30_iteration;
                if (__loop30_iteration >= 2) //444:42
                {
                    delim = ", \n"; //444:42
                }
                var __loop30_var1 = __tmp1.__loop30_var1;
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

        public string GetCSharpValue(object value) //449:1
        {
            if (value == null) //450:2
            {
                return "null"; //450:21
            }
            else if (value is bool && ((bool)value) == true) //451:2
            {
                return "true"; //451:51
            }
            else if (value is bool && ((bool)value) == false) //452:2
            {
                return "false"; //452:52
            }
            else if (value is string) //453:2
            {
                return "\"" + value.ToString() + "\""; //453:28
            }
            else if (value is MetaExpression) //454:2
            {
                return GenerateExpression((MetaExpression)value); //454:36
            }
            else //455:2
            {
                return value.ToString(); //455:7
            }
        }

        public string GetCSharpIdentifier(object value) //459:1
        {
            if (value == null) //460:2
            {
                return null; //461:3
            }
            if (value is MetaConstantExpression && ((MetaConstantExpression)value).Value != null) //463:2
            {
                return ((MetaConstantExpression)value).Value.ToString(); //464:3
            }
            else if (value is string) //465:2
            {
                return value.ToString(); //466:3
            }
            else //467:2
            {
                return null; //468:3
            }
        }

        public string GetCSharpOperator(MetaOperatorExpression expr) //472:1
        {
            var __tmp1 = expr; //473:9
            if (expr is MetaUnaryPlusExpression) //474:3
            {
                return "+"; //474:36
            }
            else if (expr is MetaNegateExpression) //475:3
            {
                return "-"; //475:33
            }
            else if (expr is MetaOnesComplementExpression) //476:3
            {
                return "~"; //476:41
            }
            else if (expr is MetaNotExpression) //477:3
            {
                return "!"; //477:30
            }
            else if (expr is MetaPostIncrementAssignExpression) //478:3
            {
                return "++"; //478:46
            }
            else if (expr is MetaPostDecrementAssignExpression) //479:3
            {
                return "--"; //479:46
            }
            else if (expr is MetaPreIncrementAssignExpression) //480:3
            {
                return "++"; //480:45
            }
            else if (expr is MetaPreDecrementAssignExpression) //481:3
            {
                return "--"; //481:45
            }
            else if (expr is MetaMultiplyExpression) //482:3
            {
                return "*"; //482:35
            }
            else if (expr is MetaDivideExpression) //483:3
            {
                return "/"; //483:33
            }
            else if (expr is MetaModuloExpression) //484:3
            {
                return "%"; //484:33
            }
            else if (expr is MetaAddExpression) //485:3
            {
                return "+"; //485:30
            }
            else if (expr is MetaSubtractExpression) //486:3
            {
                return "-"; //486:35
            }
            else if (expr is MetaLeftShiftExpression) //487:3
            {
                return "<<"; //487:36
            }
            else if (expr is MetaRightShiftExpression) //488:3
            {
                return ">>"; //488:37
            }
            else if (expr is MetaLessThanExpression) //489:3
            {
                return "<"; //489:35
            }
            else if (expr is MetaLessThanOrEqualExpression) //490:3
            {
                return "<="; //490:42
            }
            else if (expr is MetaGreaterThanExpression) //491:3
            {
                return ">"; //491:38
            }
            else if (expr is MetaGreaterThanOrEqualExpression) //492:3
            {
                return ">="; //492:45
            }
            else if (expr is MetaEqualExpression) //493:3
            {
                return "=="; //493:32
            }
            else if (expr is MetaNotEqualExpression) //494:3
            {
                return "!="; //494:35
            }
            else if (expr is MetaAndExpression) //495:3
            {
                return "&"; //495:30
            }
            else if (expr is MetaOrExpression) //496:3
            {
                return "|"; //496:29
            }
            else if (expr is MetaExclusiveOrExpression) //497:3
            {
                return "^"; //497:38
            }
            else if (expr is MetaAndAlsoExpression) //498:3
            {
                return "&&"; //498:34
            }
            else if (expr is MetaOrElseExpression) //499:3
            {
                return "||"; //499:33
            }
            else if (expr is MetaNullCoalescingExpression) //500:3
            {
                return "??"; //500:41
            }
            else if (expr is MetaMultiplyAssignExpression) //501:3
            {
                return "*="; //501:41
            }
            else if (expr is MetaDivideAssignExpression) //502:3
            {
                return "/="; //502:39
            }
            else if (expr is MetaModuloAssignExpression) //503:3
            {
                return "%="; //503:39
            }
            else if (expr is MetaAddAssignExpression) //504:3
            {
                return "+="; //504:36
            }
            else if (expr is MetaSubtractAssignExpression) //505:3
            {
                return "-="; //505:41
            }
            else if (expr is MetaLeftShiftAssignExpression) //506:3
            {
                return "<<="; //506:42
            }
            else if (expr is MetaRightShiftAssignExpression) //507:3
            {
                return ">>="; //507:43
            }
            else if (expr is MetaAndAssignExpression) //508:3
            {
                return "&="; //508:36
            }
            else if (expr is MetaExclusiveOrAssignExpression) //509:3
            {
                return "^="; //509:44
            }
            else if (expr is MetaOrAssignExpression) //510:3
            {
                return "|="; //510:35
            }
            else //511:3
            {
                return ""; //511:12
            }//512:2
        }

        public string GetTypeName(MetaExpression expr) //515:1
        {
            if (expr is MetaTypeOfExpression) //516:2
            {
                return ((MetaTypeOfExpression)expr).TypeReference.CSharpFullName(); //516:36
            }
            else //517:2
            {
                return null; //517:7
            }
        }

        public MetaSynthetizedPropertyInitializer GetSynthetizedInitializerFor(MetaClass cls, MetaProperty prop) //521:1
        {
            MetaSynthetizedPropertyInitializer lastInit = null; //522:2
            var __loop31_results = 
                (from __loop31_var1 in __Enumerate((cls).GetEnumerator()) //523:7
                from sup in __Enumerate((__loop31_var1.GetAllSuperClasses(true)).GetEnumerator()) //523:12
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //523:42
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //523:55
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaSynthetizedPropertyInitializer>() //523:69
                select new { __loop31_var1 = __loop31_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //523:2
            int __loop31_iteration = 0;
            foreach (var __tmp1 in __loop31_results)
            {
                ++__loop31_iteration;
                var __loop31_var1 = __tmp1.__loop31_var1;
                var sup = __tmp1.sup;
                var Constructor = __tmp1.Constructor;
                var Initializers = __tmp1.Initializers;
                var init = __tmp1.init;
                if (init.Property == prop) //524:3
                {
                    lastInit = init; //525:4
                }
            }
            return lastInit; //528:2
        }

        public string GenerateConstructorImpl(MetaModel model, MetaClass cls) //531:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "public "; //532:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.CSharpImplName());
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
            string __tmp4Line = "() "; //532:30
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //532:33
            __out.Append("{"); //533:1
            __out.AppendLine(false); //533:2
            var __loop32_results = 
                (from __loop32_var1 in __Enumerate((cls).GetEnumerator()) //534:8
                from prop in __Enumerate((__loop32_var1.GetAllProperties()).GetEnumerator()) //534:13
                select new { __loop32_var1 = __loop32_var1, prop = prop}
                ).ToList(); //534:3
            int __loop32_iteration = 0;
            foreach (var __tmp5 in __loop32_results)
            {
                ++__loop32_iteration;
                var __loop32_var1 = __tmp5.__loop32_var1;
                var prop = __tmp5.prop;
                MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //535:4
                if (synInit != null) //536:4
                {
                    if (prop.Kind != MetaPropertyKind.Derived) //537:5
                    {
                        if (ModelContext.Current.Compiler.TypeProvider.GetTypeOf(synInit.Value) is MetaCollectionType) //538:6
                        {
                            string __tmp7Line = "    this.MLazySet("; //539:1
                            if (__tmp7Line != null) __out.Append(__tmp7Line);
                            StringBuilder __tmp8 = new StringBuilder();
                            __tmp8.Append(prop.CSharpFullDescriptorName());
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
                            string __tmp9Line = ", new Lazy<object>(() => "; //539:52
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
                            string __tmp11Line = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //539:112
                            if (__tmp11Line != null) __out.Append(__tmp11Line);
                            __out.AppendLine(false); //539:161
                        }
                        else //540:6
                        {
                            string __tmp13Line = "    this.MLazySet("; //541:1
                            if (__tmp13Line != null) __out.Append(__tmp13Line);
                            StringBuilder __tmp14 = new StringBuilder();
                            __tmp14.Append(prop.CSharpFullDescriptorName());
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
                            string __tmp15Line = ", new Lazy<object>(() => "; //541:52
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
                            string __tmp17Line = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //541:112
                            if (__tmp17Line != null) __out.Append(__tmp17Line);
                            __out.AppendLine(false); //541:161
                        }
                    }
                    else //543:5
                    {
                        string __tmp19Line = "    this.MDerivedSet("; //544:1
                        if (__tmp19Line != null) __out.Append(__tmp19Line);
                        StringBuilder __tmp20 = new StringBuilder();
                        __tmp20.Append(prop.CSharpFullDescriptorName());
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
                        string __tmp21Line = ", () => "; //544:55
                        if (__tmp21Line != null) __out.Append(__tmp21Line);
                        StringBuilder __tmp22 = new StringBuilder();
                        __tmp22.Append(GenerateExpression(synInit.Value));
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
                        string __tmp23Line = ");"; //544:98
                        if (__tmp23Line != null) __out.Append(__tmp23Line);
                        __out.AppendLine(false); //544:100
                    }
                }
                else //546:4
                {
                    if (prop.Type is MetaCollectionType) //547:5
                    {
                        if (prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) //548:6
                        {
                            string __tmp25Line = "    this.MSet("; //549:1
                            if (__tmp25Line != null) __out.Append(__tmp25Line);
                            StringBuilder __tmp26 = new StringBuilder();
                            __tmp26.Append(prop.CSharpFullDescriptorName());
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
                            string __tmp27Line = ", new "; //549:48
                            if (__tmp27Line != null) __out.Append(__tmp27Line);
                            StringBuilder __tmp28 = new StringBuilder();
                            __tmp28.Append(prop.Type.CSharpName());
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
                            string __tmp29Line = "("; //549:78
                            if (__tmp29Line != null) __out.Append(__tmp29Line);
                            StringBuilder __tmp30 = new StringBuilder();
                            __tmp30.Append(GetCollectionConstructorParams(prop));
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
                            string __tmp31Line = "));"; //549:117
                            if (__tmp31Line != null) __out.Append(__tmp31Line);
                            __out.AppendLine(false); //549:120
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //550:6
                        {
                            string __tmp33Line = "    this.MLazySet("; //551:1
                            if (__tmp33Line != null) __out.Append(__tmp33Line);
                            StringBuilder __tmp34 = new StringBuilder();
                            __tmp34.Append(prop.CSharpFullDescriptorName());
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
                            string __tmp35Line = ", new Lazy<object>(() => "; //551:52
                            if (__tmp35Line != null) __out.Append(__tmp35Line);
                            StringBuilder __tmp36 = new StringBuilder();
                            __tmp36.Append(prop.Class.Model.CSharpFullImplementationName());
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
                            string __tmp37Line = "."; //551:126
                            if (__tmp37Line != null) __out.Append(__tmp37Line);
                            StringBuilder __tmp38 = new StringBuilder();
                            __tmp38.Append(prop.Class.CSharpName());
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
                            string __tmp39Line = "_"; //551:152
                            if (__tmp39Line != null) __out.Append(__tmp39Line);
                            StringBuilder __tmp40 = new StringBuilder();
                            __tmp40.Append(prop.Name);
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
                            string __tmp41Line = "(this), LazyThreadSafetyMode.ExecutionAndPublication));"; //551:164
                            if (__tmp41Line != null) __out.Append(__tmp41Line);
                            __out.AppendLine(false); //551:219
                        }
                        else if (prop.Kind == MetaPropertyKind.Derived) //552:6
                        {
                            string __tmp43Line = "    this.MDerivedSet("; //553:1
                            if (__tmp43Line != null) __out.Append(__tmp43Line);
                            StringBuilder __tmp44 = new StringBuilder();
                            __tmp44.Append(prop.CSharpFullDescriptorName());
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
                            string __tmp45Line = ", () => "; //553:55
                            if (__tmp45Line != null) __out.Append(__tmp45Line);
                            StringBuilder __tmp46 = new StringBuilder();
                            __tmp46.Append(prop.Class.Model.CSharpFullImplementationName());
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
                            string __tmp47Line = "."; //553:112
                            if (__tmp47Line != null) __out.Append(__tmp47Line);
                            StringBuilder __tmp48 = new StringBuilder();
                            __tmp48.Append(prop.Class.CSharpName());
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
                            string __tmp49Line = "_"; //553:138
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
                            string __tmp51Line = "(this));"; //553:150
                            if (__tmp51Line != null) __out.Append(__tmp51Line);
                            __out.AppendLine(false); //553:158
                        }
                        else if (prop.Kind == MetaPropertyKind.Readonly) //554:6
                        {
                            string __tmp53Line = "    // Init "; //555:1
                            if (__tmp53Line != null) __out.Append(__tmp53Line);
                            StringBuilder __tmp54 = new StringBuilder();
                            __tmp54.Append(prop.CSharpFullDescriptorName());
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
                            string __tmp55Line = " in "; //555:46
                            if (__tmp55Line != null) __out.Append(__tmp55Line);
                            StringBuilder __tmp56 = new StringBuilder();
                            __tmp56.Append(prop.Class.Model.CSharpFullImplementationName());
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
                            string __tmp57Line = "."; //555:99
                            if (__tmp57Line != null) __out.Append(__tmp57Line);
                            StringBuilder __tmp58 = new StringBuilder();
                            __tmp58.Append(cls.CSharpName());
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
                            string __tmp59Line = "_"; //555:118
                            if (__tmp59Line != null) __out.Append(__tmp59Line);
                            StringBuilder __tmp60 = new StringBuilder();
                            __tmp60.Append(cls.CSharpName());
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
                                    __out.AppendLine(false); //555:137
                                }
                            }
                        }
                    }
                    else //557:5
                    {
                        if (prop.Kind == MetaPropertyKind.Lazy) //558:6
                        {
                            string __tmp62Line = "    this.MLazySet("; //559:1
                            if (__tmp62Line != null) __out.Append(__tmp62Line);
                            StringBuilder __tmp63 = new StringBuilder();
                            __tmp63.Append(prop.CSharpFullDescriptorName());
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
                            string __tmp64Line = ", new Lazy<object>(() => "; //559:52
                            if (__tmp64Line != null) __out.Append(__tmp64Line);
                            StringBuilder __tmp65 = new StringBuilder();
                            __tmp65.Append(model.CSharpFullImplementationName());
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
                            string __tmp66Line = "."; //559:115
                            if (__tmp66Line != null) __out.Append(__tmp66Line);
                            StringBuilder __tmp67 = new StringBuilder();
                            __tmp67.Append(prop.Class.CSharpName());
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
                            string __tmp68Line = "_"; //559:141
                            if (__tmp68Line != null) __out.Append(__tmp68Line);
                            StringBuilder __tmp69 = new StringBuilder();
                            __tmp69.Append(prop.Name);
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
                            string __tmp70Line = "(this), LazyThreadSafetyMode.ExecutionAndPublication));"; //559:153
                            if (__tmp70Line != null) __out.Append(__tmp70Line);
                            __out.AppendLine(false); //559:208
                        }
                        else if (prop.Kind == MetaPropertyKind.Derived) //560:6
                        {
                            string __tmp72Line = "    this.MDerivedSet("; //561:1
                            if (__tmp72Line != null) __out.Append(__tmp72Line);
                            StringBuilder __tmp73 = new StringBuilder();
                            __tmp73.Append(prop.CSharpFullDescriptorName());
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
                            string __tmp74Line = ", () => "; //561:55
                            if (__tmp74Line != null) __out.Append(__tmp74Line);
                            StringBuilder __tmp75 = new StringBuilder();
                            __tmp75.Append(model.CSharpFullImplementationName());
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
                                }
                            }
                            string __tmp76Line = "."; //561:101
                            if (__tmp76Line != null) __out.Append(__tmp76Line);
                            StringBuilder __tmp77 = new StringBuilder();
                            __tmp77.Append(prop.Class.CSharpName());
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
                            string __tmp78Line = "_"; //561:127
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
                            string __tmp80Line = "(this));"; //561:139
                            if (__tmp80Line != null) __out.Append(__tmp80Line);
                            __out.AppendLine(false); //561:147
                        }
                        else if (prop.Kind == MetaPropertyKind.Readonly) //562:6
                        {
                            string __tmp82Line = "    // Init "; //563:1
                            if (__tmp82Line != null) __out.Append(__tmp82Line);
                            StringBuilder __tmp83 = new StringBuilder();
                            __tmp83.Append(prop.CSharpFullDescriptorName());
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
                            string __tmp84Line = " in "; //563:46
                            if (__tmp84Line != null) __out.Append(__tmp84Line);
                            StringBuilder __tmp85 = new StringBuilder();
                            __tmp85.Append(model.CSharpFullImplementationName());
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
                            string __tmp86Line = "."; //563:88
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
                            string __tmp88Line = "_"; //563:107
                            if (__tmp88Line != null) __out.Append(__tmp88Line);
                            StringBuilder __tmp89 = new StringBuilder();
                            __tmp89.Append(cls.CSharpName());
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
                                    __out.AppendLine(false); //563:126
                                }
                            }
                        }
                    }
                }
            }
            var __loop33_results = 
                (from __loop33_var1 in __Enumerate((cls).GetEnumerator()) //568:8
                from sup in __Enumerate((__loop33_var1.GetAllSuperClasses(true)).GetEnumerator()) //568:13
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //568:43
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //568:56
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaInheritedPropertyInitializer>() //568:70
                select new { __loop33_var1 = __loop33_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //568:3
            int __loop33_iteration = 0;
            foreach (var __tmp90 in __loop33_results)
            {
                ++__loop33_iteration;
                var __loop33_var1 = __tmp90.__loop33_var1;
                var sup = __tmp90.sup;
                var Constructor = __tmp90.Constructor;
                var Initializers = __tmp90.Initializers;
                var init = __tmp90.init;
                if (init.Object != null && init.Property != null) //569:4
                {
                    string __tmp92Line = "    this.MLazySetChild("; //570:1
                    if (__tmp92Line != null) __out.Append(__tmp92Line);
                    StringBuilder __tmp93 = new StringBuilder();
                    __tmp93.Append(init.Object.CSharpFullDescriptorName());
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
                    string __tmp94Line = ", "; //570:64
                    if (__tmp94Line != null) __out.Append(__tmp94Line);
                    StringBuilder __tmp95 = new StringBuilder();
                    __tmp95.Append(init.Property.CSharpFullDescriptorName());
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
                    string __tmp96Line = ", new Lazy<object>(() => "; //570:108
                    if (__tmp96Line != null) __out.Append(__tmp96Line);
                    StringBuilder __tmp97 = new StringBuilder();
                    __tmp97.Append(GenerateExpression(init.Value));
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
                    string __tmp98Line = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //570:165
                    if (__tmp98Line != null) __out.Append(__tmp98Line);
                    __out.AppendLine(false); //570:214
                }
            }
            string __tmp99Prefix = "    "; //573:1
            StringBuilder __tmp100 = new StringBuilder();
            __tmp100.Append(cls.Model.CSharpFullImplementationName());
            using(StreamReader __tmp100Reader = new StreamReader(this.__ToStream(__tmp100.ToString())))
            {
                bool __tmp100_first = true;
                bool __tmp100_last = __tmp100Reader.EndOfStream;
                while(__tmp100_first || !__tmp100_last)
                {
                    __tmp100_first = false;
                    string __tmp100Line = __tmp100Reader.ReadLine();
                    __tmp100_last = __tmp100Reader.EndOfStream;
                    __out.Append(__tmp99Prefix);
                    if (__tmp100Line != null) __out.Append(__tmp100Line);
                    if (!__tmp100_last) __out.AppendLine(true);
                }
            }
            string __tmp101Line = "."; //573:47
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
            string __tmp103Line = "_"; //573:66
            if (__tmp103Line != null) __out.Append(__tmp103Line);
            StringBuilder __tmp104 = new StringBuilder();
            __tmp104.Append(cls.CSharpName());
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
            string __tmp105Line = "(this);"; //573:85
            if (__tmp105Line != null) __out.Append(__tmp105Line);
            __out.AppendLine(false); //573:92
            var __loop34_results = 
                (from __loop34_var1 in __Enumerate((cls).GetEnumerator()) //574:11
                from prop in __Enumerate((__loop34_var1.GetAllProperties()).GetEnumerator()) //574:16
                select new { __loop34_var1 = __loop34_var1, prop = prop}
                ).ToList(); //574:6
            int __loop34_iteration = 0;
            foreach (var __tmp106 in __loop34_results)
            {
                ++__loop34_iteration;
                var __loop34_var1 = __tmp106.__loop34_var1;
                var prop = __tmp106.prop;
                if (prop.Kind == MetaPropertyKind.Readonly) //575:4
                {
                    string __tmp108Line = "    if (!this.MIsSet("; //576:1
                    if (__tmp108Line != null) __out.Append(__tmp108Line);
                    StringBuilder __tmp109 = new StringBuilder();
                    __tmp109.Append(prop.CSharpFullDescriptorName());
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
                    string __tmp110Line = ")) throw new ModelException(\"Readonly property "; //576:55
                    if (__tmp110Line != null) __out.Append(__tmp110Line);
                    StringBuilder __tmp111 = new StringBuilder();
                    __tmp111.Append(model.CSharpName());
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
                    string __tmp112Line = "."; //576:122
                    if (__tmp112Line != null) __out.Append(__tmp112Line);
                    StringBuilder __tmp113 = new StringBuilder();
                    __tmp113.Append(prop.Class.CSharpName());
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
                    string __tmp114Line = "."; //576:148
                    if (__tmp114Line != null) __out.Append(__tmp114Line);
                    StringBuilder __tmp115 = new StringBuilder();
                    __tmp115.Append(prop.Name);
                    using(StreamReader __tmp115Reader = new StreamReader(this.__ToStream(__tmp115.ToString())))
                    {
                        bool __tmp115_first = true;
                        bool __tmp115_last = __tmp115Reader.EndOfStream;
                        while(__tmp115_first || !__tmp115_last)
                        {
                            __tmp115_first = false;
                            string __tmp115Line = __tmp115Reader.ReadLine();
                            __tmp115_last = __tmp115Reader.EndOfStream;
                            if (__tmp115Line != null) __out.Append(__tmp115Line);
                            if (!__tmp115_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp116Line = "Property was not set in "; //576:160
                    if (__tmp116Line != null) __out.Append(__tmp116Line);
                    StringBuilder __tmp117 = new StringBuilder();
                    __tmp117.Append(cls.CSharpName());
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
                    string __tmp118Line = "_"; //576:202
                    if (__tmp118Line != null) __out.Append(__tmp118Line);
                    StringBuilder __tmp119 = new StringBuilder();
                    __tmp119.Append(cls.CSharpName());
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
                    string __tmp120Line = "().\");"; //576:221
                    if (__tmp120Line != null) __out.Append(__tmp120Line);
                    __out.AppendLine(false); //576:227
                }
            }
            __out.Append("    this.MMakeDefault();"); //579:1
            __out.AppendLine(false); //579:25
            __out.Append("}"); //580:1
            __out.AppendLine(false); //580:2
            return __out.ToString();
        }

        public string GetReturn(MetaOperation op) //583:1
        {
            if (op.ReturnType.CSharpName() == "void") //584:5
            {
                return ""; //585:3
            }
            else //586:2
            {
                return "return "; //587:3
            }
        }

        public string GenerateOperationImpl(MetaModel model, MetaOperation op) //591:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //592:1
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(op.ReturnType.CSharpFullPublicName());
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
            string __tmp3Line = " "; //593:39
            if (__tmp3Line != null) __out.Append(__tmp3Line);
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(op.Parent.CSharpFullName());
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
            string __tmp5Line = "."; //593:68
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
            string __tmp7Line = "("; //593:78
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
            string __tmp9Line = ")"; //593:105
            if (__tmp9Line != null) __out.Append(__tmp9Line);
            __out.AppendLine(false); //593:106
            __out.Append("{"); //594:1
            __out.AppendLine(false); //594:2
            string __tmp10Prefix = "    "; //595:1
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
            string __tmp13Line = "."; //595:58
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
            string __tmp15Line = "_"; //595:83
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
            string __tmp17Line = "("; //595:93
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
            string __tmp19Line = ");"; //595:125
            if (__tmp19Line != null) __out.Append(__tmp19Line);
            __out.AppendLine(false); //595:127
            __out.Append("}"); //596:1
            __out.AppendLine(false); //596:2
            return __out.ToString();
        }

        public string GetSuperClasses(MetaClass cls) //599:1
        {
            string result = ""; //600:2
            var __loop35_results = 
                (from __loop35_var1 in __Enumerate((cls).GetEnumerator()) //601:10
                from sup in __Enumerate((__loop35_var1.SuperClasses).GetEnumerator()) //601:15
                select new { __loop35_var1 = __loop35_var1, sup = sup}
                ).ToList(); //601:5
            int __loop35_iteration = 0;
            string delim = ""; //601:33
            foreach (var __tmp1 in __loop35_results)
            {
                ++__loop35_iteration;
                if (__loop35_iteration >= 2) //601:52
                {
                    delim = ", "; //601:52
                }
                var __loop35_var1 = __tmp1.__loop35_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpFullName(); //602:3
            }
            return result; //604:2
        }

        public string GetAllSuperClasses(MetaClass cls) //607:1
        {
            string result = ""; //608:2
            var __loop36_results = 
                (from __loop36_var1 in __Enumerate((cls).GetEnumerator()) //609:10
                from sup in __Enumerate((__loop36_var1.GetAllSuperClasses(false)).GetEnumerator()) //609:15
                select new { __loop36_var1 = __loop36_var1, sup = sup}
                ).ToList(); //609:5
            int __loop36_iteration = 0;
            string delim = ""; //609:46
            foreach (var __tmp1 in __loop36_results)
            {
                ++__loop36_iteration;
                if (__loop36_iteration >= 2) //609:65
                {
                    delim = ", "; //609:65
                }
                var __loop36_var1 = __tmp1.__loop36_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpFullName(); //610:3
            }
            return result; //612:2
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //615:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "public static class "; //616:1
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
                    __out.AppendLine(false); //616:51
                }
            }
            __out.Append("{"); //617:1
            __out.AppendLine(false); //617:2
            string __tmp5Line = "    static "; //618:1
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(model.Name);
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
            string __tmp7Line = "Descriptor()"; //618:24
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //618:36
            __out.Append("    {"); //619:1
            __out.AppendLine(false); //619:6
            var __loop37_results = 
                (from __loop37_var1 in __Enumerate((model).GetEnumerator()) //620:11
                from Namespace in __Enumerate((__loop37_var1.Namespace).GetEnumerator()) //620:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //620:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //620:43
                select new { __loop37_var1 = __loop37_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //620:6
            int __loop37_iteration = 0;
            foreach (var __tmp8 in __loop37_results)
            {
                ++__loop37_iteration;
                var __loop37_var1 = __tmp8.__loop37_var1;
                var Namespace = __tmp8.Namespace;
                var Declarations = __tmp8.Declarations;
                var cls = __tmp8.cls;
                string __tmp9Prefix = "        "; //621:1
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(cls.CSharpName());
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
                string __tmp11Line = ".StaticInit();"; //621:27
                if (__tmp11Line != null) __out.Append(__tmp11Line);
                __out.AppendLine(false); //621:41
            }
            __out.Append("    }"); //623:1
            __out.AppendLine(false); //623:6
            __out.AppendLine(true); //624:1
            __out.Append("    internal static void StaticInit()"); //625:1
            __out.AppendLine(false); //625:38
            __out.Append("    {"); //626:1
            __out.AppendLine(false); //626:6
            __out.Append("    }"); //627:1
            __out.AppendLine(false); //627:6
            __out.AppendLine(true); //628:1
            string __tmp13Line = "	public const string Uri = \""; //629:1
            if (__tmp13Line != null) __out.Append(__tmp13Line);
            StringBuilder __tmp14 = new StringBuilder();
            __tmp14.Append(model.Uri);
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
            string __tmp15Line = "\";"; //629:40
            if (__tmp15Line != null) __out.Append(__tmp15Line);
            __out.AppendLine(false); //629:42
            __out.AppendLine(true); //630:1
            var __loop38_results = 
                (from __loop38_var1 in __Enumerate((model).GetEnumerator()) //631:11
                from Namespace in __Enumerate((__loop38_var1.Namespace).GetEnumerator()) //631:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //631:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //631:43
                select new { __loop38_var1 = __loop38_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //631:6
            int __loop38_iteration = 0;
            foreach (var __tmp16 in __loop38_results)
            {
                ++__loop38_iteration;
                var __loop38_var1 = __tmp16.__loop38_var1;
                var Namespace = __tmp16.Namespace;
                var Declarations = __tmp16.Declarations;
                var cls = __tmp16.cls;
                string __tmp17Prefix = "    "; //632:1
                StringBuilder __tmp18 = new StringBuilder();
                __tmp18.Append(GenerateMetaModelClass(cls));
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
                        __out.AppendLine(false); //632:34
                    }
                }
            }
            __out.Append("}"); //634:1
            __out.AppendLine(false); //634:2
            __out.AppendLine(true); //635:1
            return __out.ToString();
        }

        public string GenerateMetaModelClass(MetaClass cls) //639:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //640:1
            string __tmp2Line = "public static class "; //641:1
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
                    __out.AppendLine(false); //641:39
                }
            }
            __out.Append("{"); //642:1
            __out.AppendLine(false); //642:2
            __out.Append("    internal static void StaticInit()"); //643:1
            __out.AppendLine(false); //643:38
            __out.Append("    {"); //644:1
            __out.AppendLine(false); //644:6
            __out.Append("    }"); //645:1
            __out.AppendLine(false); //645:6
            __out.AppendLine(true); //646:1
            string __tmp5Line = "    static "; //647:1
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(cls.CSharpName());
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
            string __tmp7Line = "()"; //647:30
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //647:32
            __out.Append("    {"); //648:1
            __out.AppendLine(false); //648:6
            string __tmp8Prefix = "        "; //649:1
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(cls.Model.CSharpFullDescriptorName());
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
                }
            }
            string __tmp10Line = ".StaticInit();"; //649:47
            if (__tmp10Line != null) __out.Append(__tmp10Line);
            __out.AppendLine(false); //649:61
            __out.Append("    }"); //650:1
            __out.AppendLine(false); //650:6
            __out.AppendLine(true); //651:1
            if (cls.CSharpName() == "MetaClass") //652:2
            {
                __out.Append("    public static global::MetaDslx.Core.MetaClass _MetaClass"); //653:1
                __out.AppendLine(false); //653:61
            }
            else //654:2
            {
                __out.Append("    public static global::MetaDslx.Core.MetaClass MetaClass"); //655:1
                __out.AppendLine(false); //655:60
            }
            __out.Append("    {"); //657:1
            __out.AppendLine(false); //657:6
            string __tmp12Line = "        get { return "; //658:1
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(cls.CSharpFullInstanceName());
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
            string __tmp14Line = "; }"; //658:52
            if (__tmp14Line != null) __out.Append(__tmp14Line);
            __out.AppendLine(false); //658:55
            __out.Append("    }"); //659:1
            __out.AppendLine(false); //659:6
            __out.AppendLine(true); //660:1
            var __loop39_results = 
                (from __loop39_var1 in __Enumerate((cls).GetEnumerator()) //661:11
                from prop in __Enumerate((__loop39_var1.Properties).GetEnumerator()) //661:16
                select new { __loop39_var1 = __loop39_var1, prop = prop}
                ).ToList(); //661:6
            int __loop39_iteration = 0;
            foreach (var __tmp15 in __loop39_results)
            {
                ++__loop39_iteration;
                var __loop39_var1 = __tmp15.__loop39_var1;
                var prop = __tmp15.prop;
                string __tmp16Prefix = "    "; //662:1
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(GeneratePropertyDeclaration(cls.Model, cls, prop));
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
                        __out.AppendLine(false); //662:56
                    }
                }
            }
            __out.Append("}"); //664:1
            __out.AppendLine(false); //664:2
            return __out.ToString();
        }

        public string GenerateModelConstant(MetaModel model, MetaConstant mconst) //668:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "public static readonly "; //669:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(mconst.Type.CSharpFullName());
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
            string __tmp4Line = " "; //669:54
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(mconst.Name);
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
            string __tmp6Line = ";"; //669:68
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            __out.AppendLine(false); //669:69
            return __out.ToString();
        }

        public string GenerateModelFunction(MetaModel model, MetaGlobalFunction mfunc) //672:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "public static readonly "; //673:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(MetaInstance.MetaGlobalFunction.CSharpFullName());
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
            string __tmp4Line = " "; //673:74
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(mfunc.Name);
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
            string __tmp6Line = ";"; //673:87
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            __out.AppendLine(false); //673:88
            return __out.ToString();
        }

        public string GenerateModelConstantImpl(MetaModel model, MetaConstant mconst, Dictionary<ModelObject,string> mobjToTmp) //676:1
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
            string __tmp3Line = " = "; //677:14
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
            string __tmp5Line = ";"; //677:51
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            __out.AppendLine(false); //677:52
            return __out.ToString();
        }

        public string GenerateModelFunctionImpl(MetaModel model, MetaGlobalFunction mfunc, Dictionary<ModelObject,string> mobjToTmp) //680:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(RegisterModelObject((ModelObject)mfunc, mobjToTmp, mfunc.Name));
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
            string __tmp3Line = " = "; //681:65
            if (__tmp3Line != null) __out.Append(__tmp3Line);
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(MetaInstance.MetaGlobalFunction.CSharpFullFactoryMethodName());
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
            string __tmp5Line = "();"; //681:131
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            __out.AppendLine(false); //681:134
            return __out.ToString();
        }

        public string GenerateMetaModelInstance(MetaModel model) //685:1
        {
            StringBuilder __out = new StringBuilder();
            Dictionary<ModelObject,string> mobjToTmp = new Dictionary<ModelObject,string>(); //686:2
            string __tmp2Line = "public static class "; //687:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.CSharpInstancesName());
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
                    __out.AppendLine(false); //687:50
                }
            }
            __out.Append("{"); //688:1
            __out.AppendLine(false); //688:2
            __out.Append("    private static global::MetaDslx.Core.Model model;"); //689:1
            __out.AppendLine(false); //689:54
            __out.AppendLine(true); //690:1
            __out.Append("    public static global::MetaDslx.Core.Model Model"); //691:1
            __out.AppendLine(false); //691:52
            __out.Append("    {"); //692:1
            __out.AppendLine(false); //692:6
            string __tmp5Line = "        get { return "; //693:1
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(model.Name);
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
            string __tmp7Line = "Instance.model; }"; //693:34
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //693:51
            __out.Append("    }"); //694:1
            __out.AppendLine(false); //694:6
            __out.AppendLine(true); //695:1
            __out.Append("    public static readonly global::MetaDslx.Core.MetaModel Meta;"); //696:1
            __out.AppendLine(false); //696:65
            __out.AppendLine(true); //697:1
            var __loop40_results = 
                (from __loop40_var1 in __Enumerate((model).GetEnumerator()) //698:11
                from Namespace in __Enumerate((__loop40_var1.Namespace).GetEnumerator()) //698:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //698:29
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //698:43
                select new { __loop40_var1 = __loop40_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //698:6
            int __loop40_iteration = 0;
            foreach (var __tmp8 in __loop40_results)
            {
                ++__loop40_iteration;
                var __loop40_var1 = __tmp8.__loop40_var1;
                var Namespace = __tmp8.Namespace;
                var Declarations = __tmp8.Declarations;
                var c = __tmp8.c;
                string __tmp9Prefix = "    "; //699:1
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(GenerateModelConstant(model, c));
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
                        __out.AppendLine(false); //699:38
                    }
                }
            }
            __out.AppendLine(true); //701:1
            string __tmp11Prefix = "	"; //702:1
            StringBuilder __tmp12 = new StringBuilder();
            __tmp12.Append(GenerateModelObjectInstanceDeclaration(((ModelObject)model).GetRootNamespace(), mobjToTmp));
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
                    __out.AppendLine(false); //702:94
                }
            }
            __out.AppendLine(true); //703:1
            var __loop41_results = 
                (from __loop41_var1 in __Enumerate((model).GetEnumerator()) //704:8
                from Namespace in __Enumerate((__loop41_var1.Namespace).GetEnumerator()) //704:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //704:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //704:40
                from prop in __Enumerate((cls.Properties).GetEnumerator()) //704:63
                where !HasBuiltInName((ModelObject)prop) //704:79
                select new { __loop41_var1 = __loop41_var1, Namespace = Namespace, Declarations = Declarations, cls = cls, prop = prop}
                ).ToList(); //704:3
            int __loop41_iteration = 0;
            foreach (var __tmp13 in __loop41_results)
            {
                ++__loop41_iteration;
                var __loop41_var1 = __tmp13.__loop41_var1;
                var Namespace = __tmp13.Namespace;
                var Declarations = __tmp13.Declarations;
                var cls = __tmp13.cls;
                var prop = __tmp13.prop;
                string __tmp15Line = "	public static readonly global::MetaDslx.Core.MetaProperty "; //705:1
                if (__tmp15Line != null) __out.Append(__tmp15Line);
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(cls.CSharpName());
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
                string __tmp17Line = "_"; //705:78
                if (__tmp17Line != null) __out.Append(__tmp17Line);
                StringBuilder __tmp18 = new StringBuilder();
                __tmp18.Append(prop.Name);
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
                string __tmp19Line = "Property;"; //705:90
                if (__tmp19Line != null) __out.Append(__tmp19Line);
                __out.AppendLine(false); //705:99
            }
            __out.AppendLine(true); //707:1
            string __tmp21Line = "    static "; //708:1
            if (__tmp21Line != null) __out.Append(__tmp21Line);
            StringBuilder __tmp22 = new StringBuilder();
            __tmp22.Append(model.CSharpInstancesName());
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
            string __tmp23Line = "()"; //708:41
            if (__tmp23Line != null) __out.Append(__tmp23Line);
            __out.AppendLine(false); //708:43
            __out.Append("    {"); //709:1
            __out.AppendLine(false); //709:6
            string __tmp24Prefix = "		"; //710:1
            StringBuilder __tmp25 = new StringBuilder();
            __tmp25.Append(model.CSharpDescriptorName());
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
                }
            }
            string __tmp26Line = ".StaticInit();"; //710:33
            if (__tmp26Line != null) __out.Append(__tmp26Line);
            __out.AppendLine(false); //710:47
            string __tmp27Prefix = "		"; //711:1
            StringBuilder __tmp28 = new StringBuilder();
            __tmp28.Append(model.CSharpInstancesName());
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
                }
            }
            string __tmp29Line = ".model = new global::MetaDslx.Core.Model();"; //711:32
            if (__tmp29Line != null) __out.Append(__tmp29Line);
            __out.AppendLine(false); //711:75
            string __tmp31Line = "   		using (new ModelContextScope("; //712:1
            if (__tmp31Line != null) __out.Append(__tmp31Line);
            StringBuilder __tmp32 = new StringBuilder();
            __tmp32.Append(model.CSharpInstancesName());
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
            string __tmp33Line = ".model))"; //712:64
            if (__tmp33Line != null) __out.Append(__tmp33Line);
            __out.AppendLine(false); //712:72
            __out.Append("		{"); //713:1
            __out.AppendLine(false); //713:4
            var __loop42_results = 
                (from __loop42_var1 in __Enumerate((model).GetEnumerator()) //714:13
                from Namespace in __Enumerate((__loop42_var1.Namespace).GetEnumerator()) //714:20
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //714:31
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //714:45
                select new { __loop42_var1 = __loop42_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //714:8
            int __loop42_iteration = 0;
            foreach (var __tmp34 in __loop42_results)
            {
                ++__loop42_iteration;
                var __loop42_var1 = __tmp34.__loop42_var1;
                var Namespace = __tmp34.Namespace;
                var Declarations = __tmp34.Declarations;
                var c = __tmp34.c;
                string __tmp35Prefix = "            "; //715:1
                StringBuilder __tmp36 = new StringBuilder();
                __tmp36.Append(GenerateModelConstantImpl(model, c, mobjToTmp));
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
                        __out.AppendLine(false); //715:61
                    }
                }
            }
            __out.AppendLine(true); //717:1
            string __tmp37Prefix = "			"; //718:1
            StringBuilder __tmp38 = new StringBuilder();
            __tmp38.Append(GenerateModelObjectInstance(((ModelObject)model).GetRootNamespace(), mobjToTmp));
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
                    __out.AppendLine(false); //718:85
                }
            }
            __out.AppendLine(true); //719:1
            string __tmp39Prefix = "			"; //720:1
            StringBuilder __tmp40 = new StringBuilder();
            __tmp40.Append(GenerateModelObjectInstanceInitializer(((ModelObject)model).GetRootNamespace(), mobjToTmp));
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
                    __out.AppendLine(false); //720:96
                }
            }
            __out.AppendLine(true); //721:1
            __out.Append("            foreach (var mo in ModelContext.Current.Model.Instances)"); //722:1
            __out.AppendLine(false); //722:69
            __out.Append("            {"); //723:1
            __out.AppendLine(false); //723:14
            __out.Append("                mo.MEvalLazyValues();"); //724:1
            __out.AppendLine(false); //724:38
            __out.Append("            }"); //725:1
            __out.AppendLine(false); //725:14
            __out.Append("		}"); //726:1
            __out.AppendLine(false); //726:4
            __out.Append("    }"); //727:1
            __out.AppendLine(false); //727:6
            __out.Append("}"); //728:1
            __out.AppendLine(false); //728:2
            return __out.ToString();
        }

        public string RegisterModelObject(ModelObject mobj, Dictionary<ModelObject,string> mobjToTmp, string name) //731:1
        {
            if (!mobjToTmp.ContainsKey(mobj)) //732:2
            {
                string tmpName = name; //733:3
                mobjToTmp.Add(mobj, tmpName); //734:3
                return tmpName; //735:3
            }
            else //736:2
            {
                return mobjToTmp[mobj]; //737:3
            }
        }

        public bool HasBuiltInName(ModelObject mobj) //741:1
        {
            MetaAnnotatedElement mannot = mobj as MetaAnnotatedElement; //742:2
            if (mannot != null && !(mobj is MetaConstant)) //743:2
            {
                var __loop43_results = 
                    (from __loop43_var1 in __Enumerate((mannot).GetEnumerator()) //744:8
                    from a in __Enumerate((__loop43_var1.Annotations).GetEnumerator()) //744:16
                    from p in __Enumerate((a.Properties).GetEnumerator()) //744:31
                    where a.Name == "BuiltInName" && p.Name == "Name" //744:44
                    select new { __loop43_var1 = __loop43_var1, a = a, p = p}
                    ).ToList(); //744:3
                int __loop43_iteration = 0;
                foreach (var __tmp1 in __loop43_results)
                {
                    ++__loop43_iteration;
                    var __loop43_var1 = __tmp1.__loop43_var1;
                    var a = __tmp1.a;
                    var p = __tmp1.p;
                    return true; //745:4
                }
            }
            MetaDeclaration mdecl = mobj as MetaDeclaration; //748:2
            if (mdecl != null && !(mdecl is MetaOperation) && !(mdecl is MetaConstant)) //749:2
            {
                return true; //750:3
            }
            return false; //752:2
        }

        public string GetInstanceName(ModelObject mobj) //755:1
        {
            MetaAnnotatedElement mannot = mobj as MetaAnnotatedElement; //756:2
            if (mannot != null && !(mobj is MetaConstant)) //757:2
            {
                var __loop44_results = 
                    (from __loop44_var1 in __Enumerate((mannot).GetEnumerator()) //758:8
                    from a in __Enumerate((__loop44_var1.Annotations).GetEnumerator()) //758:16
                    from p in __Enumerate((a.Properties).GetEnumerator()) //758:31
                    where a.Name == "BuiltInName" && p.Name == "Name" //758:44
                    select new { __loop44_var1 = __loop44_var1, a = a, p = p}
                    ).ToList(); //758:3
                int __loop44_iteration = 0;
                foreach (var __tmp1 in __loop44_results)
                {
                    ++__loop44_iteration;
                    var __loop44_var1 = __tmp1.__loop44_var1;
                    var a = __tmp1.a;
                    var p = __tmp1.p;
                    return GetCSharpIdentifier(p.Value); //759:4
                }
            }
            MetaDeclaration mdecl = mobj as MetaDeclaration; //762:2
            if (mdecl != null && !(mdecl is MetaOperation) && !(mobj is MetaConstant)) //763:2
            {
                return mdecl.CSharpInstanceName(); //764:3
            }
            MetaProperty mprop = mobj as MetaProperty; //766:2
            if (mprop != null) //767:2
            {
                return mprop.CSharpInstanceName(); //768:3
            }
            return null; //770:2
        }

        public string RegisterModelObject(ModelObject mobj, Dictionary<ModelObject,string> mobjToTmp) //773:1
        {
            if (!mobjToTmp.ContainsKey(mobj)) //774:2
            {
                string name = GetInstanceName(mobj); //775:3
                if (name == null) //776:3
                {
                    name = "tmp" + NextCounter(); //777:4
                }
                mobjToTmp.Add(mobj, name); //779:3
                return name; //780:3
            }
            else //781:2
            {
                return null; //782:3
            }
        }

        public string GenerateModelObjectInstanceDeclaration(ModelObject mobj, Dictionary<ModelObject,string> mobjToTmp) //786:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //787:2
            {
                if (!Instances.Contains(mobj)) //788:3
                {
                }
                else //789:3
                {
                    if (HasBuiltInName(mobj)) //790:4
                    {
                        string tmpName = RegisterModelObject(mobj, mobjToTmp); //791:5
                        if (tmpName != null) //792:5
                        {
                            if (tmpName.StartsWith("tmp")) //793:6
                            {
                            }
                            else //794:6
                            {
                                string __tmp2Line = "public static readonly global::MetaDslx.Core."; //795:1
                                if (__tmp2Line != null) __out.Append(__tmp2Line);
                                StringBuilder __tmp3 = new StringBuilder();
                                __tmp3.Append(mobj.MMetaClass.CSharpName());
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
                                string __tmp4Line = " "; //795:76
                                if (__tmp4Line != null) __out.Append(__tmp4Line);
                                StringBuilder __tmp5 = new StringBuilder();
                                __tmp5.Append(tmpName);
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
                                string __tmp6Line = ";"; //795:86
                                if (__tmp6Line != null) __out.Append(__tmp6Line);
                                __out.AppendLine(false); //795:87
                            }
                        }
                    }
                    var __loop45_results = 
                        (from __loop45_var1 in __Enumerate((mobj).GetEnumerator()) //799:9
                        from child in __Enumerate((__loop45_var1.MChildren).GetEnumerator()) //799:15
                        select new { __loop45_var1 = __loop45_var1, child = child}
                        ).ToList(); //799:4
                    int __loop45_iteration = 0;
                    foreach (var __tmp7 in __loop45_results)
                    {
                        ++__loop45_iteration;
                        var __loop45_var1 = __tmp7.__loop45_var1;
                        var child = __tmp7.child;
                        StringBuilder __tmp9 = new StringBuilder();
                        __tmp9.Append(GenerateModelObjectInstanceDeclaration(child, mobjToTmp));
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
                                __out.AppendLine(false); //800:59
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstance(ModelObject mobj, Dictionary<ModelObject,string> mobjToTmp) //806:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //807:2
            {
                if (!Instances.Contains(mobj)) //808:3
                {
                    string metaClassName = mobj.MMetaClass.Name; //809:4
                    if (mobj is MetaDeclaration || mobj is MetaProperty) //810:4
                    {
                        if (mobj is MetaProperty) //811:5
                        {
                            string tmpName = RegisterModelObject(mobj, mobjToTmp, ((MetaProperty)mobj).CSharpInstanceName()); //812:2
                        }
                        else //813:5
                        {
                            string tmpName = RegisterModelObject(mobj, mobjToTmp, ((MetaDeclaration)mobj).CSharpInstanceName()); //814:2
                        }
                    }
                    else //816:4
                    {
                        string __tmp2Line = "// OMITTED: "; //817:1
                        if (__tmp2Line != null) __out.Append(__tmp2Line);
                        StringBuilder __tmp3 = new StringBuilder();
                        __tmp3.Append(metaClassName);
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
                                __out.AppendLine(false); //817:28
                            }
                        }
                    }
                }
                else //819:3
                {
                    string tmpName = null; //820:4
                    if (mobjToTmp.ContainsKey(mobj)) //821:4
                    {
                        tmpName = mobjToTmp[mobj];
                    }
                    else //823:4
                    {
                        tmpName = RegisterModelObject(mobj, mobjToTmp);
                    }
                    if (tmpName != null) //826:4
                    {
                        if (tmpName.StartsWith("tmp")) //827:5
                        {
                            string __tmp5Line = "global::MetaDslx.Core."; //828:1
                            if (__tmp5Line != null) __out.Append(__tmp5Line);
                            StringBuilder __tmp6 = new StringBuilder();
                            __tmp6.Append(mobj.MMetaClass.CSharpName());
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
                            string __tmp7Line = " "; //828:53
                            if (__tmp7Line != null) __out.Append(__tmp7Line);
                            StringBuilder __tmp8 = new StringBuilder();
                            __tmp8.Append(tmpName);
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
                            string __tmp9Line = " = global::MetaDslx.Core.MetaFactory.Instance.Create"; //828:63
                            if (__tmp9Line != null) __out.Append(__tmp9Line);
                            StringBuilder __tmp10 = new StringBuilder();
                            __tmp10.Append(mobj.MMetaClass.CSharpName());
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
                            string __tmp11Line = "();"; //828:145
                            if (__tmp11Line != null) __out.Append(__tmp11Line);
                            __out.AppendLine(false); //828:148
                        }
                        else //829:5
                        {
                            StringBuilder __tmp13 = new StringBuilder();
                            __tmp13.Append(tmpName);
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
                            string __tmp14Line = " = global::MetaDslx.Core.MetaFactory.Instance.Create"; //830:10
                            if (__tmp14Line != null) __out.Append(__tmp14Line);
                            StringBuilder __tmp15 = new StringBuilder();
                            __tmp15.Append(mobj.MMetaClass.CSharpName());
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
                            string __tmp16Line = "();"; //830:92
                            if (__tmp16Line != null) __out.Append(__tmp16Line);
                            __out.AppendLine(false); //830:95
                        }
                        if (mobj is MetaModel) //832:5
                        {
                            string __tmp18Line = "Meta = "; //833:1
                            if (__tmp18Line != null) __out.Append(__tmp18Line);
                            StringBuilder __tmp19 = new StringBuilder();
                            __tmp19.Append(tmpName);
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
                            string __tmp20Line = ";"; //833:17
                            if (__tmp20Line != null) __out.Append(__tmp20Line);
                            __out.AppendLine(false); //833:18
                        }
                        var __loop46_results = 
                            (from __loop46_var1 in __Enumerate((mobj).GetEnumerator()) //835:10
                            from child in __Enumerate((__loop46_var1.MChildren).GetEnumerator()) //835:16
                            select new { __loop46_var1 = __loop46_var1, child = child}
                            ).ToList(); //835:5
                        int __loop46_iteration = 0;
                        foreach (var __tmp21 in __loop46_results)
                        {
                            ++__loop46_iteration;
                            var __loop46_var1 = __tmp21.__loop46_var1;
                            var child = __tmp21.child;
                            StringBuilder __tmp23 = new StringBuilder();
                            __tmp23.Append(GenerateModelObjectInstance(child, mobjToTmp));
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
                                    __out.AppendLine(false); //836:48
                                }
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceInitializer(ModelObject mobj, Dictionary<ModelObject,string> mobjToTmp) //843:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //844:2
            {
                if (!Instances.Contains(mobj)) //845:3
                {
                }
                else //846:3
                {
                    var __loop47_results = 
                        (from __loop47_var1 in __Enumerate((mobj).GetEnumerator()) //847:9
                        from prop in __Enumerate((__loop47_var1.MGetAllProperties()).GetEnumerator()) //847:15
                        select new { __loop47_var1 = __loop47_var1, prop = prop}
                        ).ToList(); //847:4
                    int __loop47_iteration = 0;
                    foreach (var __tmp1 in __loop47_results)
                    {
                        ++__loop47_iteration;
                        var __loop47_var1 = __tmp1.__loop47_var1;
                        var prop = __tmp1.prop;
                        if (prop.MetaProperty != null && prop.MetaProperty.Kind != MetaPropertyKind.Derived) //848:5
                        {
                            object propValue = mobj.MGet(prop); //849:6
                            StringBuilder __tmp3 = new StringBuilder();
                            __tmp3.Append(GenerateModelObjectPropertyValue(mobj, prop, propValue, mobjToTmp));
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
                                    __out.AppendLine(false); //850:69
                                }
                            }
                        }
                    }
                    var __loop48_results = 
                        (from __loop48_var1 in __Enumerate((mobj).GetEnumerator()) //853:9
                        from child in __Enumerate((__loop48_var1.MChildren).GetEnumerator()) //853:15
                        select new { __loop48_var1 = __loop48_var1, child = child}
                        ).ToList(); //853:4
                    int __loop48_iteration = 0;
                    foreach (var __tmp4 in __loop48_results)
                    {
                        ++__loop48_iteration;
                        var __loop48_var1 = __tmp4.__loop48_var1;
                        var child = __tmp4.child;
                        StringBuilder __tmp6 = new StringBuilder();
                        __tmp6.Append(GenerateModelObjectInstanceInitializer(child, mobjToTmp));
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
                                __out.AppendLine(false); //854:59
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectPropertyValue(ModelObject mobj, ModelProperty prop, object value, Dictionary<ModelObject,string> mobjToTmp) //860:1
        {
            StringBuilder __out = new StringBuilder();
            string tmpName = mobjToTmp[mobj]; //861:2
            string propDeclName = "global::" + prop.DeclaringType.FullName.Replace("+", ".") + "." + prop.DeclaredName; //862:2
            if (!prop.IsCollection) //863:2
            {
                string __tmp2Line = "((ModelObject)"; //864:1
                if (__tmp2Line != null) __out.Append(__tmp2Line);
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(tmpName);
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
                string __tmp4Line = ").MUnSet("; //864:24
                if (__tmp4Line != null) __out.Append(__tmp4Line);
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(propDeclName);
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
                string __tmp6Line = ");"; //864:47
                if (__tmp6Line != null) __out.Append(__tmp6Line);
                __out.AppendLine(false); //864:49
            }
            ModelObject moValue = value as ModelObject; //866:2
            if (value == null) //867:2
            {
                string __tmp8Line = "((ModelObject)"; //868:1
                if (__tmp8Line != null) __out.Append(__tmp8Line);
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append(tmpName);
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
                string __tmp10Line = ").MLazyAdd("; //868:24
                if (__tmp10Line != null) __out.Append(__tmp10Line);
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(propDeclName);
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
                string __tmp12Line = ", new Lazy<object>(() => null, LazyThreadSafetyMode.ExecutionAndPublication));"; //868:49
                if (__tmp12Line != null) __out.Append(__tmp12Line);
                __out.AppendLine(false); //868:127
            }
            else if (value is string) //869:2
            {
                string __tmp14Line = "((ModelObject)"; //870:1
                if (__tmp14Line != null) __out.Append(__tmp14Line);
                StringBuilder __tmp15 = new StringBuilder();
                __tmp15.Append(tmpName);
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
                string __tmp16Line = ").MLazyAdd("; //870:24
                if (__tmp16Line != null) __out.Append(__tmp16Line);
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(propDeclName);
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
                string __tmp18Line = ", new Lazy<object>(() => \""; //870:49
                if (__tmp18Line != null) __out.Append(__tmp18Line);
                StringBuilder __tmp19 = new StringBuilder();
                __tmp19.Append(value);
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
                string __tmp20Line = "\", LazyThreadSafetyMode.ExecutionAndPublication));"; //870:82
                if (__tmp20Line != null) __out.Append(__tmp20Line);
                __out.AppendLine(false); //870:132
            }
            else if (value is bool) //871:2
            {
                string __tmp22Line = "((ModelObject)"; //872:1
                if (__tmp22Line != null) __out.Append(__tmp22Line);
                StringBuilder __tmp23 = new StringBuilder();
                __tmp23.Append(tmpName);
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
                string __tmp24Line = ").MLazyAdd("; //872:24
                if (__tmp24Line != null) __out.Append(__tmp24Line);
                StringBuilder __tmp25 = new StringBuilder();
                __tmp25.Append(propDeclName);
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
                string __tmp26Line = ", new Lazy<object>(() => "; //872:49
                if (__tmp26Line != null) __out.Append(__tmp26Line);
                StringBuilder __tmp27 = new StringBuilder();
                __tmp27.Append(value.ToString().ToLower());
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
                string __tmp28Line = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //872:102
                if (__tmp28Line != null) __out.Append(__tmp28Line);
                __out.AppendLine(false); //872:151
            }
            else if (value.GetType().IsPrimitive) //873:2
            {
                string __tmp30Line = "((ModelObject)"; //874:1
                if (__tmp30Line != null) __out.Append(__tmp30Line);
                StringBuilder __tmp31 = new StringBuilder();
                __tmp31.Append(tmpName);
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
                string __tmp32Line = ").MLazyAdd("; //874:24
                if (__tmp32Line != null) __out.Append(__tmp32Line);
                StringBuilder __tmp33 = new StringBuilder();
                __tmp33.Append(propDeclName);
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
                string __tmp34Line = ", new Lazy<object>(() => "; //874:49
                if (__tmp34Line != null) __out.Append(__tmp34Line);
                StringBuilder __tmp35 = new StringBuilder();
                __tmp35.Append(value.ToString());
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
                string __tmp36Line = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //874:92
                if (__tmp36Line != null) __out.Append(__tmp36Line);
                __out.AppendLine(false); //874:141
            }
            else if (MetaBuiltInTypes.Types.Contains(value)) //875:2
            {
                string __tmp38Line = "((ModelObject)"; //876:1
                if (__tmp38Line != null) __out.Append(__tmp38Line);
                StringBuilder __tmp39 = new StringBuilder();
                __tmp39.Append(tmpName);
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
                string __tmp40Line = ").MLazyAdd("; //876:24
                if (__tmp40Line != null) __out.Append(__tmp40Line);
                StringBuilder __tmp41 = new StringBuilder();
                __tmp41.Append(propDeclName);
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
                string __tmp42Line = ", new Lazy<object>(() => "; //876:49
                if (__tmp42Line != null) __out.Append(__tmp42Line);
                StringBuilder __tmp43 = new StringBuilder();
                __tmp43.Append(GenerateTypeOf(value));
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
                string __tmp44Line = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //876:97
                if (__tmp44Line != null) __out.Append(__tmp44Line);
                __out.AppendLine(false); //876:146
            }
            else if (value is MetaPrimitiveType) //877:2
            {
                string __tmp46Line = "((ModelObject)"; //878:1
                if (__tmp46Line != null) __out.Append(__tmp46Line);
                StringBuilder __tmp47 = new StringBuilder();
                __tmp47.Append(tmpName);
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
                string __tmp48Line = ").MLazyAdd("; //878:24
                if (__tmp48Line != null) __out.Append(__tmp48Line);
                StringBuilder __tmp49 = new StringBuilder();
                __tmp49.Append(propDeclName);
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
                string __tmp50Line = ", new Lazy<object>(() => "; //878:49
                if (__tmp50Line != null) __out.Append(__tmp50Line);
                StringBuilder __tmp51 = new StringBuilder();
                __tmp51.Append(GenerateTypeOf(value));
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
                string __tmp52Line = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //878:97
                if (__tmp52Line != null) __out.Append(__tmp52Line);
                __out.AppendLine(false); //878:146
            }
            else if (value is Enum) //879:2
            {
                string __tmp54Line = "((ModelObject)"; //880:1
                if (__tmp54Line != null) __out.Append(__tmp54Line);
                StringBuilder __tmp55 = new StringBuilder();
                __tmp55.Append(tmpName);
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
                string __tmp56Line = ").MLazyAdd("; //880:24
                if (__tmp56Line != null) __out.Append(__tmp56Line);
                StringBuilder __tmp57 = new StringBuilder();
                __tmp57.Append(propDeclName);
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
                string __tmp58Line = ", new Lazy<object>(() => "; //880:49
                if (__tmp58Line != null) __out.Append(__tmp58Line);
                StringBuilder __tmp59 = new StringBuilder();
                __tmp59.Append(GetEnumValueOf(value));
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
                string __tmp60Line = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //880:97
                if (__tmp60Line != null) __out.Append(__tmp60Line);
                __out.AppendLine(false); //880:146
            }
            else if (moValue != null) //881:2
            {
                if (mobjToTmp.ContainsKey(moValue)) //882:3
                {
                    string __tmp62Line = "((ModelObject)"; //883:1
                    if (__tmp62Line != null) __out.Append(__tmp62Line);
                    StringBuilder __tmp63 = new StringBuilder();
                    __tmp63.Append(tmpName);
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
                    string __tmp64Line = ").MLazyAdd("; //883:24
                    if (__tmp64Line != null) __out.Append(__tmp64Line);
                    StringBuilder __tmp65 = new StringBuilder();
                    __tmp65.Append(propDeclName);
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
                    string __tmp66Line = ", new Lazy<object>(() => "; //883:49
                    if (__tmp66Line != null) __out.Append(__tmp66Line);
                    StringBuilder __tmp67 = new StringBuilder();
                    __tmp67.Append(mobjToTmp[moValue]);
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
                    string __tmp68Line = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //883:94
                    if (__tmp68Line != null) __out.Append(__tmp68Line);
                    __out.AppendLine(false); //883:143
                }
                else //884:3
                {
                    StringBuilder __tmp70 = new StringBuilder();
                    __tmp70.Append(GenerateModelObjectInstance(moValue, mobjToTmp));
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
                            __out.AppendLine(false); //885:50
                        }
                    }
                    StringBuilder __tmp72 = new StringBuilder();
                    __tmp72.Append(GenerateModelObjectInstanceInitializer(moValue, mobjToTmp));
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
                            __out.AppendLine(false); //886:61
                        }
                    }
                    if (mobjToTmp.ContainsKey(moValue)) //887:4
                    {
                        string tmpValueName = mobjToTmp[moValue]; //888:5
                        string __tmp74Line = "((ModelObject)"; //889:1
                        if (__tmp74Line != null) __out.Append(__tmp74Line);
                        StringBuilder __tmp75 = new StringBuilder();
                        __tmp75.Append(tmpName);
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
                            }
                        }
                        string __tmp76Line = ").MLazyAdd("; //889:24
                        if (__tmp76Line != null) __out.Append(__tmp76Line);
                        StringBuilder __tmp77 = new StringBuilder();
                        __tmp77.Append(propDeclName);
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
                        string __tmp78Line = ", new Lazy<object>(() => "; //889:49
                        if (__tmp78Line != null) __out.Append(__tmp78Line);
                        StringBuilder __tmp79 = new StringBuilder();
                        __tmp79.Append(tmpValueName);
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
                        string __tmp80Line = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //889:88
                        if (__tmp80Line != null) __out.Append(__tmp80Line);
                        __out.AppendLine(false); //889:137
                    }
                    else //890:4
                    {
                        string __tmp82Line = "// NOT FOUND: "; //891:1
                        if (__tmp82Line != null) __out.Append(__tmp82Line);
                        StringBuilder __tmp83 = new StringBuilder();
                        __tmp83.Append(moValue);
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
                                __out.AppendLine(false); //891:24
                            }
                        }
                    }
                }
            }
            else //894:2
            {
                IEnumerable<object> mc = (value as ModelCollection) as IEnumerable<object>; //895:3
                if (mc != null) //896:3
                {
                    var __loop49_results = 
                        (from cvalue in __Enumerate((mc).GetEnumerator()) //897:9
                        select new { cvalue = cvalue}
                        ).ToList(); //897:4
                    int __loop49_iteration = 0;
                    foreach (var __tmp84 in __loop49_results)
                    {
                        ++__loop49_iteration;
                        var cvalue = __tmp84.cvalue;
                        StringBuilder __tmp86 = new StringBuilder();
                        __tmp86.Append(GenerateModelObjectPropertyValue(mobj, prop, cvalue, mobjToTmp));
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
                                __out.AppendLine(false); //898:66
                            }
                        }
                    }
                }
                else //900:3
                {
                    string __tmp88Line = "// "; //901:1
                    if (__tmp88Line != null) __out.Append(__tmp88Line);
                    StringBuilder __tmp89 = new StringBuilder();
                    __tmp89.Append(propDeclName);
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
                    string __tmp90Line = " = "; //901:18
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
                            __out.AppendLine(false); //901:38
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GetEnumValueOf(object enm) //906:1
        {
            return "global::" + enm.GetType().FullName.Replace("+", ".") + "." + enm.ToString(); //907:2
        }

        public string GenerateClassMetaInstance(MetaClass cls) //910:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(cls.CSharpName());
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
            string __tmp3Line = " = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();"; //911:19
            if (__tmp3Line != null) __out.Append(__tmp3Line);
            __out.AppendLine(false); //911:83
            return __out.ToString();
        }

        public string GenerateClassMetaInstanceInitializer(MetaClass cls) //914:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(cls.CSharpName());
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
            string __tmp3Line = ".Name = \""; //915:19
            if (__tmp3Line != null) __out.Append(__tmp3Line);
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(cls.CSharpName());
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
            string __tmp5Line = "\";"; //915:46
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            __out.AppendLine(false); //915:48
            if (cls.IsAbstract) //916:2
            {
                StringBuilder __tmp7 = new StringBuilder();
                __tmp7.Append(cls.CSharpName());
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
                string __tmp8Line = ".IsAbstract = true;"; //917:19
                if (__tmp8Line != null) __out.Append(__tmp8Line);
                __out.AppendLine(false); //917:38
            }
            var __loop50_results = 
                (from __loop50_var1 in __Enumerate((cls).GetEnumerator()) //919:7
                from sup in __Enumerate((__loop50_var1.SuperClasses).GetEnumerator()) //919:12
                select new { __loop50_var1 = __loop50_var1, sup = sup}
                ).ToList(); //919:2
            int __loop50_iteration = 0;
            foreach (var __tmp9 in __loop50_results)
            {
                ++__loop50_iteration;
                var __loop50_var1 = __tmp9.__loop50_var1;
                var sup = __tmp9.sup;
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
                string __tmp12Line = ".SuperClasses.Add("; //920:19
                if (__tmp12Line != null) __out.Append(__tmp12Line);
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(sup.CSharpFullInstanceName());
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
                string __tmp14Line = ");"; //920:67
                if (__tmp14Line != null) __out.Append(__tmp14Line);
                __out.AppendLine(false); //920:69
            }
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //925:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal static class "; //926:1
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
            string __tmp4Line = "ImplementationProvider"; //926:35
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //926:57
            __out.Append("{"); //927:1
            __out.AppendLine(false); //927:2
            string __tmp6Line = "    // If there is a compile error at this line, create a new class called "; //928:1
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
            string __tmp8Line = "Implementation"; //928:88
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //928:102
            string __tmp10Line = "	// which is a subclass of "; //929:1
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
            string __tmp12Line = "ImplementationBase:"; //929:40
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //929:59
            string __tmp14Line = "    private static "; //930:1
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
            string __tmp16Line = "Implementation implementation = new "; //930:32
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
            string __tmp18Line = "Implementation();"; //930:80
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //930:97
            __out.AppendLine(true); //931:1
            string __tmp20Line = "    public static "; //932:1
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
            string __tmp22Line = "Implementation Implementation"; //932:31
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            __out.AppendLine(false); //932:60
            __out.Append("    {"); //933:1
            __out.AppendLine(false); //933:6
            string __tmp24Line = "        get { return "; //934:1
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
            string __tmp26Line = "ImplementationProvider.implementation; }"; //934:34
            if (__tmp26Line != null) __out.Append(__tmp26Line);
            __out.AppendLine(false); //934:74
            __out.Append("    }"); //935:1
            __out.AppendLine(false); //935:6
            __out.Append("}"); //936:1
            __out.AppendLine(false); //936:2
            var __loop51_results = 
                (from __loop51_var1 in __Enumerate((model).GetEnumerator()) //937:8
                from Namespace in __Enumerate((__loop51_var1.Namespace).GetEnumerator()) //937:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //937:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //937:40
                select new { __loop51_var1 = __loop51_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //937:3
            int __loop51_iteration = 0;
            foreach (var __tmp27 in __loop51_results)
            {
                ++__loop51_iteration;
                var __loop51_var1 = __tmp27.__loop51_var1;
                var Namespace = __tmp27.Namespace;
                var Declarations = __tmp27.Declarations;
                var enm = __tmp27.enm;
                __out.AppendLine(true); //938:1
                string __tmp29Line = "public static class "; //939:1
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
                string __tmp31Line = "Extensions"; //939:31
                if (__tmp31Line != null) __out.Append(__tmp31Line);
                __out.AppendLine(false); //939:41
                __out.Append("{"); //940:1
                __out.AppendLine(false); //940:2
                var __loop52_results = 
                    (from __loop52_var1 in __Enumerate((enm).GetEnumerator()) //941:11
                    from op in __Enumerate((__loop52_var1.Operations).GetEnumerator()) //941:16
                    select new { __loop52_var1 = __loop52_var1, op = op}
                    ).ToList(); //941:6
                int __loop52_iteration = 0;
                foreach (var __tmp32 in __loop52_results)
                {
                    ++__loop52_iteration;
                    var __loop52_var1 = __tmp32.__loop52_var1;
                    var op = __tmp32.op;
                    string __tmp34Line = "    public static "; //942:1
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
                    string __tmp36Line = " "; //942:57
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
                    string __tmp38Line = "("; //942:67
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
                    string __tmp40Line = ")"; //942:100
                    if (__tmp40Line != null) __out.Append(__tmp40Line);
                    __out.AppendLine(false); //942:101
                    __out.Append("    {"); //943:1
                    __out.AppendLine(false); //943:6
                    string __tmp41Prefix = "        "; //944:1
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
                    string __tmp44Line = "ImplementationProvider.Implementation."; //944:36
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
                    string __tmp46Line = "_"; //944:98
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
                    string __tmp48Line = "("; //944:108
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
                    string __tmp50Line = ");"; //944:144
                    if (__tmp50Line != null) __out.Append(__tmp50Line);
                    __out.AppendLine(false); //944:146
                    __out.Append("    }"); //945:1
                    __out.AppendLine(false); //945:6
                }
                __out.Append("}"); //947:1
                __out.AppendLine(false); //947:2
            }
            __out.AppendLine(true); //949:1
            __out.Append("/// <summary>"); //950:1
            __out.AppendLine(false); //950:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //951:1
            __out.AppendLine(false); //951:68
            string __tmp52Line = "/// This class has to be be overriden in "; //952:1
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
            string __tmp54Line = "Implementation to provide custom"; //952:54
            if (__tmp54Line != null) __out.Append(__tmp54Line);
            __out.AppendLine(false); //952:86
            __out.Append("/// implementation for the constructors, operations and property values."); //953:1
            __out.AppendLine(false); //953:73
            __out.Append("/// </summary>"); //954:1
            __out.AppendLine(false); //954:15
            string __tmp56Line = "internal abstract class "; //955:1
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
            string __tmp58Line = "ImplementationBase"; //955:37
            if (__tmp58Line != null) __out.Append(__tmp58Line);
            __out.AppendLine(false); //955:55
            __out.Append("{"); //956:1
            __out.AppendLine(false); //956:2
            var __loop53_results = 
                (from __loop53_var1 in __Enumerate((model).GetEnumerator()) //957:8
                from Namespace in __Enumerate((__loop53_var1.Namespace).GetEnumerator()) //957:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //957:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //957:40
                select new { __loop53_var1 = __loop53_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //957:3
            int __loop53_iteration = 0;
            foreach (var __tmp59 in __loop53_results)
            {
                ++__loop53_iteration;
                var __loop53_var1 = __tmp59.__loop53_var1;
                var Namespace = __tmp59.Namespace;
                var Declarations = __tmp59.Declarations;
                var cls = __tmp59.cls;
                __out.Append("    /// <summary>"); //958:1
                __out.AppendLine(false); //958:18
                string __tmp61Line = "	/// Implements the constructor: "; //959:1
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
                string __tmp63Line = "()"; //959:52
                if (__tmp63Line != null) __out.Append(__tmp63Line);
                __out.AppendLine(false); //959:54
                if ((from __loop54_var1 in __Enumerate((cls).GetEnumerator()) //960:15
                from sup in __Enumerate((__loop54_var1.SuperClasses).GetEnumerator()) //960:20
                select new { __loop54_var1 = __loop54_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //960:3
                {
                    string __tmp65Line = "	/// Direct superclasses: "; //961:1
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
                            __out.AppendLine(false); //961:49
                        }
                    }
                    string __tmp68Line = "	/// All superclasses: "; //962:1
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
                            __out.AppendLine(false); //962:49
                        }
                    }
                }
                if ((from __loop55_var1 in __Enumerate((cls).GetEnumerator()) //964:15
                from prop in __Enumerate((__loop55_var1.GetAllProperties()).GetEnumerator()) //964:20
                where prop.Kind == MetaPropertyKind.Readonly //964:44
                select new { __loop55_var1 = __loop55_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //964:3
                {
                    __out.Append("    /// Initializes the following readonly properties:"); //965:1
                    __out.AppendLine(false); //965:55
                }
                var __loop56_results = 
                    (from __loop56_var1 in __Enumerate((cls).GetEnumerator()) //967:11
                    from prop in __Enumerate((__loop56_var1.GetAllProperties()).GetEnumerator()) //967:16
                    select new { __loop56_var1 = __loop56_var1, prop = prop}
                    ).ToList(); //967:6
                int __loop56_iteration = 0;
                foreach (var __tmp70 in __loop56_results)
                {
                    ++__loop56_iteration;
                    var __loop56_var1 = __tmp70.__loop56_var1;
                    var prop = __tmp70.prop;
                    if (prop.Kind == MetaPropertyKind.Readonly) //968:3
                    {
                        string __tmp72Line = "    ///    "; //969:1
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
                        string __tmp74Line = "."; //969:29
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
                                __out.AppendLine(false); //969:41
                            }
                        }
                    }
                }
                __out.Append("    /// </summary>"); //972:1
                __out.AppendLine(false); //972:19
                string __tmp77Line = "    public virtual void "; //973:1
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
                string __tmp79Line = "_"; //973:43
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
                string __tmp81Line = "("; //973:62
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
                string __tmp83Line = " @this)"; //973:81
                if (__tmp83Line != null) __out.Append(__tmp83Line);
                __out.AppendLine(false); //973:88
                __out.Append("    {"); //974:1
                __out.AppendLine(false); //974:6
                var __loop57_results = 
                    (from __loop57_var1 in __Enumerate((cls).GetEnumerator()) //975:9
                    from sup in __Enumerate((__loop57_var1.SuperClasses).GetEnumerator()) //975:14
                    select new { __loop57_var1 = __loop57_var1, sup = sup}
                    ).ToList(); //975:4
                int __loop57_iteration = 0;
                foreach (var __tmp84 in __loop57_results)
                {
                    ++__loop57_iteration;
                    var __loop57_var1 = __tmp84.__loop57_var1;
                    var sup = __tmp84.sup;
                    string __tmp86Line = "        this."; //976:1
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
                    string __tmp88Line = "_"; //976:32
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
                    string __tmp90Line = "(@this);"; //976:51
                    if (__tmp90Line != null) __out.Append(__tmp90Line);
                    __out.AppendLine(false); //976:59
                }
                __out.Append("    }"); //978:1
                __out.AppendLine(false); //978:6
                var __loop58_results = 
                    (from __loop58_var1 in __Enumerate((cls).GetEnumerator()) //979:11
                    from prop in __Enumerate((__loop58_var1.Properties).GetEnumerator()) //979:16
                    select new { __loop58_var1 = __loop58_var1, prop = prop}
                    ).ToList(); //979:6
                int __loop58_iteration = 0;
                foreach (var __tmp91 in __loop58_results)
                {
                    ++__loop58_iteration;
                    var __loop58_var1 = __tmp91.__loop58_var1;
                    var prop = __tmp91.prop;
                    MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //980:4
                    if (synInit == null) //981:4
                    {
                        if (prop.Kind == MetaPropertyKind.Derived) //982:5
                        {
                            __out.AppendLine(true); //983:1
                            __out.Append("    /// <summary>"); //984:1
                            __out.AppendLine(false); //984:18
                            string __tmp93Line = "    /// Returns the value of the derived property: "; //985:1
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
                            string __tmp95Line = "."; //985:70
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
                                    __out.AppendLine(false); //985:82
                                }
                            }
                            __out.Append("    /// </summary>"); //986:1
                            __out.AppendLine(false); //986:19
                            string __tmp98Line = "    public virtual "; //987:1
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
                            string __tmp100Line = " "; //987:54
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
                            string __tmp102Line = "_"; //987:73
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
                            string __tmp104Line = "("; //987:85
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
                            string __tmp106Line = " @this)"; //987:104
                            if (__tmp106Line != null) __out.Append(__tmp106Line);
                            __out.AppendLine(false); //987:111
                            __out.Append("    {"); //988:1
                            __out.AppendLine(false); //988:6
                            __out.Append("        throw new NotImplementedException();"); //989:1
                            __out.AppendLine(false); //989:45
                            __out.Append("    }"); //990:1
                            __out.AppendLine(false); //990:6
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //991:5
                        {
                            __out.AppendLine(true); //992:1
                            __out.Append("    /// <summary>"); //993:1
                            __out.AppendLine(false); //993:18
                            string __tmp108Line = "    /// Returns the value of the lazy property: "; //994:1
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
                            string __tmp110Line = "."; //994:67
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
                                    __out.AppendLine(false); //994:79
                                }
                            }
                            __out.Append("    /// </summary>"); //995:1
                            __out.AppendLine(false); //995:19
                            string __tmp113Line = "    public virtual "; //996:1
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
                            string __tmp115Line = " "; //996:54
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
                            string __tmp117Line = "_"; //996:73
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
                            string __tmp119Line = "("; //996:85
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
                            string __tmp121Line = " @this)"; //996:104
                            if (__tmp121Line != null) __out.Append(__tmp121Line);
                            __out.AppendLine(false); //996:111
                            __out.Append("    {"); //997:1
                            __out.AppendLine(false); //997:6
                            __out.Append("        throw new NotImplementedException();"); //998:1
                            __out.AppendLine(false); //998:45
                            __out.Append("    }"); //999:1
                            __out.AppendLine(false); //999:6
                        }
                    }
                }
                var __loop59_results = 
                    (from __loop59_var1 in __Enumerate((cls).GetEnumerator()) //1003:11
                    from op in __Enumerate((__loop59_var1.Operations).GetEnumerator()) //1003:16
                    select new { __loop59_var1 = __loop59_var1, op = op}
                    ).ToList(); //1003:6
                int __loop59_iteration = 0;
                foreach (var __tmp122 in __loop59_results)
                {
                    ++__loop59_iteration;
                    var __loop59_var1 = __tmp122.__loop59_var1;
                    var op = __tmp122.op;
                    __out.AppendLine(true); //1004:1
                    __out.Append("    /// <summary>"); //1005:1
                    __out.AppendLine(false); //1005:18
                    string __tmp124Line = "    /// Implements the operation: "; //1006:1
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
                    string __tmp126Line = "."; //1006:53
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
                    string __tmp128Line = "()"; //1006:63
                    if (__tmp128Line != null) __out.Append(__tmp128Line);
                    __out.AppendLine(false); //1006:65
                    __out.Append("    /// </summary>"); //1007:1
                    __out.AppendLine(false); //1007:19
                    string __tmp130Line = "    public virtual "; //1008:1
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
                    string __tmp132Line = " "; //1008:58
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
                    string __tmp134Line = "_"; //1008:77
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
                    string __tmp136Line = "("; //1008:87
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
                    string __tmp138Line = ")"; //1008:116
                    if (__tmp138Line != null) __out.Append(__tmp138Line);
                    __out.AppendLine(false); //1008:117
                    __out.Append("    {"); //1009:1
                    __out.AppendLine(false); //1009:6
                    __out.Append("        throw new NotImplementedException();"); //1010:1
                    __out.AppendLine(false); //1010:45
                    __out.Append("    }"); //1011:1
                    __out.AppendLine(false); //1011:6
                }
                __out.AppendLine(true); //1013:1
            }
            var __loop60_results = 
                (from __loop60_var1 in __Enumerate((model).GetEnumerator()) //1015:8
                from Namespace in __Enumerate((__loop60_var1.Namespace).GetEnumerator()) //1015:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //1015:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //1015:40
                select new { __loop60_var1 = __loop60_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //1015:3
            int __loop60_iteration = 0;
            foreach (var __tmp139 in __loop60_results)
            {
                ++__loop60_iteration;
                var __loop60_var1 = __tmp139.__loop60_var1;
                var Namespace = __tmp139.Namespace;
                var Declarations = __tmp139.Declarations;
                var enm = __tmp139.enm;
                var __loop61_results = 
                    (from __loop61_var1 in __Enumerate((enm).GetEnumerator()) //1016:11
                    from op in __Enumerate((__loop61_var1.Operations).GetEnumerator()) //1016:16
                    select new { __loop61_var1 = __loop61_var1, op = op}
                    ).ToList(); //1016:6
                int __loop61_iteration = 0;
                foreach (var __tmp140 in __loop61_results)
                {
                    ++__loop61_iteration;
                    var __loop61_var1 = __tmp140.__loop61_var1;
                    var op = __tmp140.op;
                    __out.AppendLine(true); //1017:1
                    __out.Append("    /// <summary>"); //1018:1
                    __out.AppendLine(false); //1018:18
                    string __tmp142Line = "    /// Implements the operation: "; //1019:1
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
                    string __tmp144Line = "."; //1019:53
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
                            __out.AppendLine(false); //1019:63
                        }
                    }
                    __out.Append("    /// </summary>"); //1020:1
                    __out.AppendLine(false); //1020:19
                    string __tmp147Line = "    public virtual "; //1021:1
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
                    string __tmp149Line = " "; //1021:58
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
                    string __tmp151Line = "_"; //1021:77
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
                    string __tmp153Line = "("; //1021:87
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
                    string __tmp155Line = ")"; //1021:116
                    if (__tmp155Line != null) __out.Append(__tmp155Line);
                    __out.AppendLine(false); //1021:117
                    __out.Append("    {"); //1022:1
                    __out.AppendLine(false); //1022:6
                    __out.Append("        throw new NotImplementedException();"); //1023:1
                    __out.AppendLine(false); //1023:45
                    __out.Append("    }"); //1024:1
                    __out.AppendLine(false); //1024:6
                }
                __out.AppendLine(true); //1026:1
            }
            __out.Append("}"); //1028:1
            __out.AppendLine(false); //1028:2
            __out.AppendLine(true); //1029:1
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //1032:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //1033:1
            __out.AppendLine(false); //1033:14
            __out.Append("/// Factory class for creating instances of model elements."); //1034:1
            __out.AppendLine(false); //1034:60
            __out.Append("/// </summary>"); //1035:1
            __out.AppendLine(false); //1035:15
            string __tmp2Line = "public class "; //1036:1
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
            string __tmp4Line = " : ModelFactory"; //1036:41
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //1036:56
            __out.Append("{"); //1037:1
            __out.AppendLine(false); //1037:2
            string __tmp6Line = "    private static "; //1038:1
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
            string __tmp8Line = " instance = new "; //1038:47
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(model.CSharpFactoryName());
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
            string __tmp10Line = "();"; //1038:90
            if (__tmp10Line != null) __out.Append(__tmp10Line);
            __out.AppendLine(false); //1038:93
            __out.AppendLine(true); //1039:1
            string __tmp12Line = "	private "; //1040:1
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(model.CSharpFactoryName());
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
            string __tmp14Line = "()"; //1040:37
            if (__tmp14Line != null) __out.Append(__tmp14Line);
            __out.AppendLine(false); //1040:39
            __out.Append("	{"); //1041:1
            __out.AppendLine(false); //1041:3
            __out.Append("	}"); //1042:1
            __out.AppendLine(false); //1042:3
            __out.AppendLine(true); //1043:1
            __out.Append("    /// <summary>"); //1044:1
            __out.AppendLine(false); //1044:18
            __out.Append("    /// The singleton instance of the factory."); //1045:1
            __out.AppendLine(false); //1045:47
            __out.Append("    /// </summary>"); //1046:1
            __out.AppendLine(false); //1046:19
            string __tmp16Line = "    public static "; //1047:1
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(model.CSharpFactoryName());
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
            string __tmp18Line = " Instance"; //1047:46
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //1047:55
            __out.Append("    {"); //1048:1
            __out.AppendLine(false); //1048:6
            string __tmp20Line = "        get { return "; //1049:1
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
            string __tmp22Line = ".instance; }"; //1049:49
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            __out.AppendLine(false); //1049:61
            __out.Append("    }"); //1050:1
            __out.AppendLine(false); //1050:6
            var __loop62_results = 
                (from __loop62_var1 in __Enumerate((model).GetEnumerator()) //1051:8
                from Namespace in __Enumerate((__loop62_var1.Namespace).GetEnumerator()) //1051:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //1051:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //1051:40
                select new { __loop62_var1 = __loop62_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //1051:3
            int __loop62_iteration = 0;
            foreach (var __tmp23 in __loop62_results)
            {
                ++__loop62_iteration;
                var __loop62_var1 = __tmp23.__loop62_var1;
                var Namespace = __tmp23.Namespace;
                var Declarations = __tmp23.Declarations;
                var cls = __tmp23.cls;
                if (!cls.IsAbstract) //1052:4
                {
                    __out.AppendLine(true); //1053:1
                    __out.Append("    /// <summary>"); //1054:1
                    __out.AppendLine(false); //1054:18
                    string __tmp25Line = "    /// Creates a new instance of "; //1055:1
                    if (__tmp25Line != null) __out.Append(__tmp25Line);
                    StringBuilder __tmp26 = new StringBuilder();
                    __tmp26.Append(cls.CSharpName());
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
                    string __tmp27Line = "."; //1055:53
                    if (__tmp27Line != null) __out.Append(__tmp27Line);
                    __out.AppendLine(false); //1055:54
                    __out.Append("    /// </summary>"); //1056:1
                    __out.AppendLine(false); //1056:19
                    string __tmp29Line = "    public "; //1057:1
                    if (__tmp29Line != null) __out.Append(__tmp29Line);
                    StringBuilder __tmp30 = new StringBuilder();
                    __tmp30.Append(cls.CSharpName());
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
                    string __tmp31Line = " Create"; //1057:30
                    if (__tmp31Line != null) __out.Append(__tmp31Line);
                    StringBuilder __tmp32 = new StringBuilder();
                    __tmp32.Append(cls.CSharpName());
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
                    string __tmp33Line = "(IEnumerable<ModelPropertyInitializer> initializers = null)"; //1057:55
                    if (__tmp33Line != null) __out.Append(__tmp33Line);
                    __out.AppendLine(false); //1057:114
                    __out.Append("	{"); //1058:1
                    __out.AppendLine(false); //1058:3
                    string __tmp34Prefix = "		"; //1059:1
                    StringBuilder __tmp35 = new StringBuilder();
                    __tmp35.Append(cls.CSharpName());
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
                        }
                    }
                    string __tmp36Line = " result = new "; //1059:21
                    if (__tmp36Line != null) __out.Append(__tmp36Line);
                    StringBuilder __tmp37 = new StringBuilder();
                    __tmp37.Append(cls.CSharpFullName());
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
                    string __tmp38Line = "Impl();"; //1059:57
                    if (__tmp38Line != null) __out.Append(__tmp38Line);
                    __out.AppendLine(false); //1059:64
                    __out.Append("		if (initializers != null)"); //1060:1
                    __out.AppendLine(false); //1060:28
                    __out.Append("		{"); //1061:1
                    __out.AppendLine(false); //1061:4
                    __out.Append("			this.Init((ModelObject)result, initializers);"); //1062:1
                    __out.AppendLine(false); //1062:49
                    __out.Append("		}"); //1063:1
                    __out.AppendLine(false); //1063:4
                    __out.Append("		return result;"); //1064:1
                    __out.AppendLine(false); //1064:17
                    __out.Append("	}"); //1065:1
                    __out.AppendLine(false); //1065:3
                }
            }
            __out.Append("}"); //1068:1
            __out.AppendLine(false); //1068:2
            __out.AppendLine(true); //1069:1
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
