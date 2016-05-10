using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core //1:1
{
    using __Hidden_ImmutableMetaModelGenerator_1349323322;
    namespace __Hidden_ImmutableMetaModelGenerator_1349323322
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
            string __tmp21Prefix = "    "; //39:1
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
                    __out.AppendLine(false); //39:29
                }
            }
            string __tmp23Prefix = "    "; //40:1
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
                    __out.AppendLine(false); //40:44
                }
            }
            __out.Append("}"); //41:1
            __out.AppendLine(false); //41:2
            return __out.ToString();
        }

        public string GenerateAnnotations(MetaAnnotatedElement elem) //44:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop7_results = 
                (from __loop7_var1 in __Enumerate((elem).GetEnumerator()) //45:7
                from annot in __Enumerate((__loop7_var1.Annotations).GetEnumerator()) //45:13
                select new { __loop7_var1 = __loop7_var1, annot = annot}
                ).ToList(); //45:2
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
                        __out.AppendLine(false); //46:23
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateEnum(MetaEnum enm) //50:1
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
                    __out.AppendLine(false); //51:27
                }
            }
            string __tmp4Line = "public enum "; //52:1
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
                    __out.AppendLine(false); //52:31
                }
            }
            __out.Append("{"); //53:1
            __out.AppendLine(false); //53:2
            var __loop8_results = 
                (from __loop8_var1 in __Enumerate((enm).GetEnumerator()) //54:11
                from value in __Enumerate((__loop8_var1.EnumLiterals).GetEnumerator()) //54:16
                select new { __loop8_var1 = __loop8_var1, value = value}
                ).ToList(); //54:6
            int __loop8_iteration = 0;
            foreach (var __tmp6 in __loop8_results)
            {
                ++__loop8_iteration;
                var __loop8_var1 = __tmp6.__loop8_var1;
                var value = __tmp6.value;
                string __tmp7Prefix = "    "; //55:1
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
                string __tmp9Line = ","; //55:17
                if (__tmp9Line != null) __out.Append(__tmp9Line);
                __out.AppendLine(false); //55:18
            }
            __out.Append("}"); //57:1
            __out.AppendLine(false); //57:2
            __out.AppendLine(true); //58:1
            return __out.ToString();
        }

        public string GetAncestors(MetaClass cls, ClassKind classKind) //61:1
        {
            string result = ""; //62:2
            var __loop9_results = 
                (from __loop9_var1 in __Enumerate((cls).GetEnumerator()) //63:7
                from super in __Enumerate((__loop9_var1.SuperClasses).GetEnumerator()) //63:12
                select new { __loop9_var1 = __loop9_var1, super = super}
                ).ToList(); //63:2
            int __loop9_iteration = 0;
            string delim = " : "; //63:32
            foreach (var __tmp1 in __loop9_results)
            {
                ++__loop9_iteration;
                if (__loop9_iteration >= 2) //63:54
                {
                    delim = ", "; //63:54
                }
                var __loop9_var1 = __tmp1.__loop9_var1;
                var super = __tmp1.super;
                result += delim + super.CSharpFullName(classKind); //64:3
            }
            if (result == "") //66:2
            {
                result = " : global::MetaDslx.Core.Immutable.RedSymbol"; //67:3
            }
            return result; //69:2
        }

        public string GenerateImmutableInterface(MetaClass cls) //72:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal class "; //73:1
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
            string __tmp4Line = "Id : SymbolId"; //73:53
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //73:66
            __out.Append("{"); //74:1
            __out.AppendLine(false); //74:2
            string __tmp6Line = "    public override Type ImmutableType { get { return typeof("; //75:1
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
            string __tmp8Line = "); } }"; //75:99
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //75:105
            string __tmp10Line = "    public override Type MutableType { get { return typeof("; //76:1
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
            string __tmp12Line = "); } }"; //76:95
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //76:101
            __out.AppendLine(true); //77:1
            __out.Append("    public override ImmutableRedSymbol CreateImmutableRed(ImmutableRedModelPart model)"); //78:1
            __out.AppendLine(false); //78:87
            __out.Append("    {"); //79:1
            __out.AppendLine(false); //79:6
            string __tmp14Line = "        return new "; //80:1
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
            string __tmp16Line = "(this, model);"; //80:61
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            __out.AppendLine(false); //80:75
            __out.Append("    }"); //81:1
            __out.AppendLine(false); //81:6
            __out.AppendLine(true); //82:1
            __out.Append("    public override MutableRedSymbol CreateMutableRed(MutableRedModelPart model)"); //83:1
            __out.AppendLine(false); //83:81
            __out.Append("    {"); //84:1
            __out.AppendLine(false); //84:6
            string __tmp18Line = "        return new "; //85:1
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
            string __tmp20Line = "(this, model);"; //85:59
            if (__tmp20Line != null) __out.Append(__tmp20Line);
            __out.AppendLine(false); //85:73
            __out.Append("    }"); //86:1
            __out.AppendLine(false); //86:6
            __out.Append("}"); //87:1
            __out.AppendLine(false); //87:2
            __out.AppendLine(true); //88:1
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
                    __out.AppendLine(false); //89:27
                }
            }
            string __tmp24Line = "public interface "; //90:1
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
                    __out.AppendLine(false); //90:95
                }
            }
            __out.Append("{"); //91:1
            __out.AppendLine(false); //91:2
            var __loop10_results = 
                (from __loop10_var1 in __Enumerate((cls).GetEnumerator()) //92:11
                from prop in __Enumerate((__loop10_var1.Properties).GetEnumerator()) //92:16
                select new { __loop10_var1 = __loop10_var1, prop = prop}
                ).ToList(); //92:6
            int __loop10_iteration = 0;
            foreach (var __tmp27 in __loop10_results)
            {
                ++__loop10_iteration;
                var __loop10_var1 = __tmp27.__loop10_var1;
                var prop = __tmp27.prop;
                string __tmp28Prefix = "    "; //93:1
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
                        __out.AppendLine(false); //93:38
                    }
                }
            }
            __out.AppendLine(true); //95:1
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((cls).GetEnumerator()) //96:11
                from op in __Enumerate((__loop11_var1.Operations).GetEnumerator()) //96:16
                select new { __loop11_var1 = __loop11_var1, op = op}
                ).ToList(); //96:6
            int __loop11_iteration = 0;
            foreach (var __tmp30 in __loop11_results)
            {
                ++__loop11_iteration;
                var __loop11_var1 = __tmp30.__loop11_var1;
                var op = __tmp30.op;
                string __tmp31Prefix = "    "; //97:1
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
                        __out.AppendLine(false); //97:28
                    }
                }
            }
            __out.Append("}"); //99:1
            __out.AppendLine(false); //99:2
            __out.AppendLine(true); //100:1
            return __out.ToString();
        }

        public string GenerateBuilderInterface(MetaClass cls) //103:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "public interface "; //104:1
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
                    __out.AppendLine(false); //104:91
                }
            }
            __out.Append("{"); //105:1
            __out.AppendLine(false); //105:2
            var __loop12_results = 
                (from __loop12_var1 in __Enumerate((cls).GetEnumerator()) //106:11
                from prop in __Enumerate((__loop12_var1.Properties).GetEnumerator()) //106:16
                select new { __loop12_var1 = __loop12_var1, prop = prop}
                ).ToList(); //106:6
            int __loop12_iteration = 0;
            foreach (var __tmp5 in __loop12_results)
            {
                ++__loop12_iteration;
                var __loop12_var1 = __tmp5.__loop12_var1;
                var prop = __tmp5.prop;
                string __tmp6Prefix = "    "; //107:1
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
                        __out.AppendLine(false); //107:36
                    }
                }
            }
            __out.Append("}"); //109:1
            __out.AppendLine(false); //109:2
            __out.AppendLine(true); //110:1
            return __out.ToString();
        }

        public string GenerateImmutableProperty(MetaProperty prop) //113:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //114:2
            {
                __out.Append("new "); //115:1
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
            string __tmp3Line = " "; //117:54
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
            string __tmp5Line = " { get; }"; //117:66
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            __out.AppendLine(false); //117:75
            return __out.ToString();
        }

        public string GenerateImmutableField(MetaProperty prop) //120:1
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
                    __out.AppendLine(false); //121:54
                }
            }
            string __tmp4Line = "private "; //122:1
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
            string __tmp6Line = " _"; //122:62
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
            string __tmp8Line = ";"; //122:75
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //122:76
            return __out.ToString();
        }

        public string GenerateBuilderProperty(MetaProperty prop) //125:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //126:2
            {
                __out.Append("new "); //127:1
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //129:3
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
                string __tmp3Line = " "; //130:52
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
                string __tmp5Line = " { get; set; }"; //130:64
                if (__tmp5Line != null) __out.Append(__tmp5Line);
                __out.AppendLine(false); //130:78
            }
            else //131:3
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
                string __tmp8Line = " "; //132:52
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
                string __tmp10Line = " { get; }"; //132:64
                if (__tmp10Line != null) __out.Append(__tmp10Line);
                __out.AppendLine(false); //132:73
            }
            if (!(prop.Type is MetaCollectionType)) //134:2
            {
                if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //135:3
                {
                    __out.Append("new "); //136:1
                }
                string __tmp12Line = "Func<"; //138:1
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
                string __tmp14Line = "> "; //138:57
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
                string __tmp16Line = "Lazy { get; set; }"; //138:70
                if (__tmp16Line != null) __out.Append(__tmp16Line);
                __out.AppendLine(false); //138:88
            }
            return __out.ToString();
        }

        public string GenerateBuilderField(MetaProperty prop) //142:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "private "; //143:1
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
            string __tmp4Line = " _"; //143:60
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
            string __tmp6Line = ";"; //143:73
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            __out.AppendLine(false); //143:74
            return __out.ToString();
        }

        public string GetParameters(MetaOperation op, bool defaultValues) //146:1
        {
            string result = ""; //147:2
            var __loop13_results = 
                (from __loop13_var1 in __Enumerate((op).GetEnumerator()) //148:7
                from param in __Enumerate((__loop13_var1.Parameters).GetEnumerator()) //148:11
                select new { __loop13_var1 = __loop13_var1, param = param}
                ).ToList(); //148:2
            int __loop13_iteration = 0;
            string delim = ""; //148:29
            foreach (var __tmp1 in __loop13_results)
            {
                ++__loop13_iteration;
                if (__loop13_iteration >= 2) //148:48
                {
                    delim = ", "; //148:48
                }
                var __loop13_var1 = __tmp1.__loop13_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(ClassKind.Immutable) + " " + param.Name; //149:3
            }
            return result; //151:2
        }

        public string GetImplParameters(MetaClass cls, MetaOperation op) //154:1
        {
            string result = cls.CSharpFullName(ClassKind.Immutable) + " @this"; //155:2
            string delim = ", "; //156:2
            var __loop14_results = 
                (from __loop14_var1 in __Enumerate((op).GetEnumerator()) //157:7
                from param in __Enumerate((__loop14_var1.Parameters).GetEnumerator()) //157:11
                select new { __loop14_var1 = __loop14_var1, param = param}
                ).ToList(); //157:2
            int __loop14_iteration = 0;
            foreach (var __tmp1 in __loop14_results)
            {
                ++__loop14_iteration;
                var __loop14_var1 = __tmp1.__loop14_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(ClassKind.Immutable) + " " + param.Name; //158:3
            }
            return result; //160:2
        }

        public string GetImplParameters(MetaEnum enm, MetaOperation op) //163:1
        {
            string result = enm.CSharpFullName(ClassKind.Immutable) + " @this"; //164:2
            string delim = ", "; //165:2
            var __loop15_results = 
                (from __loop15_var1 in __Enumerate((op).GetEnumerator()) //166:7
                from param in __Enumerate((__loop15_var1.Parameters).GetEnumerator()) //166:11
                select new { __loop15_var1 = __loop15_var1, param = param}
                ).ToList(); //166:2
            int __loop15_iteration = 0;
            foreach (var __tmp1 in __loop15_results)
            {
                ++__loop15_iteration;
                var __loop15_var1 = __tmp1.__loop15_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(ClassKind.Immutable) + " " + param.Name; //167:3
            }
            return result; //169:2
        }

        public string GetEnumImplParameters(MetaEnum enm, MetaOperation op) //172:1
        {
            string result = "this " + enm.CSharpFullName(ClassKind.Immutable) + " @this"; //173:2
            string delim = ", "; //174:2
            var __loop16_results = 
                (from __loop16_var1 in __Enumerate((op).GetEnumerator()) //175:7
                from param in __Enumerate((__loop16_var1.Parameters).GetEnumerator()) //175:11
                select new { __loop16_var1 = __loop16_var1, param = param}
                ).ToList(); //175:2
            int __loop16_iteration = 0;
            foreach (var __tmp1 in __loop16_results)
            {
                ++__loop16_iteration;
                var __loop16_var1 = __tmp1.__loop16_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(ClassKind.Immutable) + " " + param.Name; //176:3
            }
            return result; //178:2
        }

        public string GetEnumImplCallParameterNames(MetaOperation op) //181:1
        {
            string result = "@this"; //182:2
            string delim = ", "; //183:2
            var __loop17_results = 
                (from __loop17_var1 in __Enumerate((op).GetEnumerator()) //184:7
                from param in __Enumerate((__loop17_var1.Parameters).GetEnumerator()) //184:11
                select new { __loop17_var1 = __loop17_var1, param = param}
                ).ToList(); //184:2
            int __loop17_iteration = 0;
            foreach (var __tmp1 in __loop17_results)
            {
                ++__loop17_iteration;
                var __loop17_var1 = __tmp1.__loop17_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //185:3
            }
            return result; //187:2
        }

        public string GetImplCallParameterNames(MetaOperation op) //190:1
        {
            string result = "this"; //191:2
            string delim = ", "; //192:2
            var __loop18_results = 
                (from __loop18_var1 in __Enumerate((op).GetEnumerator()) //193:7
                from param in __Enumerate((__loop18_var1.Parameters).GetEnumerator()) //193:11
                select new { __loop18_var1 = __loop18_var1, param = param}
                ).ToList(); //193:2
            int __loop18_iteration = 0;
            foreach (var __tmp1 in __loop18_results)
            {
                ++__loop18_iteration;
                var __loop18_var1 = __tmp1.__loop18_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //194:3
            }
            return result; //196:2
        }

        public string GenerateOperation(MetaOperation op) //199:1
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
            string __tmp3Line = " "; //200:58
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
            string __tmp5Line = "("; //200:68
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
            string __tmp7Line = ");"; //200:94
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //200:96
            return __out.ToString();
        }

        public string GenerateImmutableInterfaceImpl(MetaModel model, MetaClass cls) //203:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal class "; //204:1
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
            string __tmp4Line = " : global::MetaDslx.Core.Immutable.ImmutableRedSymbolBase, "; //204:57
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
                    __out.AppendLine(false); //204:157
                }
            }
            __out.Append("{"); //205:1
            __out.AppendLine(false); //205:2
            var __loop19_results = 
                (from __loop19_var1 in __Enumerate((cls).GetEnumerator()) //206:11
                from prop in __Enumerate((__loop19_var1.GetAllFinalProperties()).GetEnumerator()) //206:16
                select new { __loop19_var1 = __loop19_var1, prop = prop}
                ).ToList(); //206:6
            int __loop19_iteration = 0;
            foreach (var __tmp6 in __loop19_results)
            {
                ++__loop19_iteration;
                var __loop19_var1 = __tmp6.__loop19_var1;
                var prop = __tmp6.prop;
                string __tmp7Prefix = "    "; //207:1
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
                        __out.AppendLine(false); //207:35
                    }
                }
            }
            __out.AppendLine(true); //209:1
            string __tmp10Line = "    internal "; //210:1
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
            string __tmp12Line = "(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableRedModelPart model)"; //210:36
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //210:142
            __out.Append("		: base(id, model)"); //211:1
            __out.AppendLine(false); //211:20
            __out.Append("    {"); //212:1
            __out.AppendLine(false); //212:6
            __out.Append("    }"); //213:1
            __out.AppendLine(false); //213:6
            __out.AppendLine(true); //214:1
            __out.Append("    public override object MMetaModel"); //215:1
            __out.AppendLine(false); //215:38
            __out.Append("    {"); //216:1
            __out.AppendLine(false); //216:6
            string __tmp14Line = "        get { return null;/*"; //217:1
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
            string __tmp16Line = ";*/ }"; //217:65
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            __out.AppendLine(false); //217:70
            __out.Append("    }"); //218:1
            __out.AppendLine(false); //218:6
            __out.AppendLine(true); //219:1
            __out.Append("    public override object MMetaClass"); //220:1
            __out.AppendLine(false); //220:38
            __out.Append("    {"); //221:1
            __out.AppendLine(false); //221:6
            string __tmp18Line = "        get { return null; /*"; //222:1
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
            string __tmp20Line = ";*/ }"; //222:60
            if (__tmp20Line != null) __out.Append(__tmp20Line);
            __out.AppendLine(false); //222:65
            __out.Append("    }"); //223:1
            __out.AppendLine(false); //223:6
            __out.AppendLine(true); //224:1
            var __loop20_results = 
                (from __loop20_var1 in __Enumerate((cls).GetEnumerator()) //225:11
                from prop in __Enumerate((__loop20_var1.GetAllProperties()).GetEnumerator()) //225:16
                select new { __loop20_var1 = __loop20_var1, prop = prop}
                ).ToList(); //225:6
            int __loop20_iteration = 0;
            foreach (var __tmp21 in __loop20_results)
            {
                ++__loop20_iteration;
                var __loop20_var1 = __tmp21.__loop20_var1;
                var prop = __tmp21.prop;
                string __tmp22Prefix = "    "; //226:1
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
                        __out.AppendLine(false); //226:54
                    }
                }
            }
            var __loop21_results = 
                (from __loop21_var1 in __Enumerate((cls).GetEnumerator()) //228:11
                from op in __Enumerate((__loop21_var1.GetAllOperations()).GetEnumerator()) //228:16
                select new { __loop21_var1 = __loop21_var1, op = op}
                ).ToList(); //228:6
            int __loop21_iteration = 0;
            foreach (var __tmp24 in __loop21_results)
            {
                ++__loop21_iteration;
                var __loop21_var1 = __tmp24.__loop21_var1;
                var op = __tmp24.op;
                string __tmp25Prefix = "    "; //229:1
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
                        __out.AppendLine(false); //229:39
                    }
                }
            }
            __out.Append("}"); //231:1
            __out.AppendLine(false); //231:2
            __out.AppendLine(true); //232:1
            return __out.ToString();
        }

        public string GenerateBuilderInterfaceImpl(MetaModel model, MetaClass cls) //235:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal class "; //236:1
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
            string __tmp4Line = " : global::MetaDslx.Core.Immutable.MutableRedSymbolBase, "; //236:55
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
                    __out.AppendLine(false); //236:151
                }
            }
            __out.Append("{"); //237:1
            __out.AppendLine(false); //237:2
            var __loop22_results = 
                (from __loop22_var1 in __Enumerate((cls).GetEnumerator()) //238:11
                from prop in __Enumerate((__loop22_var1.GetAllFinalProperties()).GetEnumerator()) //238:16
                where prop.Type is MetaCollectionType //238:45
                select new { __loop22_var1 = __loop22_var1, prop = prop}
                ).ToList(); //238:6
            int __loop22_iteration = 0;
            foreach (var __tmp6 in __loop22_results)
            {
                ++__loop22_iteration;
                var __loop22_var1 = __tmp6.__loop22_var1;
                var prop = __tmp6.prop;
                string __tmp7Prefix = "    "; //239:1
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
                        __out.AppendLine(false); //239:33
                    }
                }
            }
            __out.AppendLine(true); //241:1
            string __tmp10Line = "    internal "; //242:1
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
            string __tmp12Line = "(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableRedModelPart model)"; //242:53
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //242:157
            __out.Append("		: base(id, model)"); //243:1
            __out.AppendLine(false); //243:20
            __out.Append("    {"); //244:1
            __out.AppendLine(false); //244:6
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((cls).GetEnumerator()) //245:9
                from prop in __Enumerate((__loop23_var1.GetAllProperties()).GetEnumerator()) //245:14
                select new { __loop23_var1 = __loop23_var1, prop = prop}
                ).ToList(); //245:4
            int __loop23_iteration = 0;
            foreach (var __tmp13 in __loop23_results)
            {
                ++__loop23_iteration;
                var __loop23_var1 = __tmp13.__loop23_var1;
                var prop = __tmp13.prop;
                string __tmp15Line = "        this.MAttachProperty("; //246:1
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
                string __tmp17Line = ");"; //246:82
                if (__tmp17Line != null) __out.Append(__tmp17Line);
                __out.AppendLine(false); //246:84
            }
            __out.Append("        this.MInit();"); //248:1
            __out.AppendLine(false); //248:22
            __out.Append("    }"); //249:1
            __out.AppendLine(false); //249:6
            __out.AppendLine(true); //250:1
            __out.Append("    protected override void MDoInit()"); //251:1
            __out.AppendLine(false); //251:38
            __out.Append("    {"); //252:1
            __out.AppendLine(false); //252:6
            string __tmp18Prefix = "		"; //253:1
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
            string __tmp20Line = "ImplementationProvider.Implementation."; //253:15
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
            string __tmp22Line = "(this);"; //253:71
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            __out.AppendLine(false); //253:78
            __out.Append("    }"); //254:1
            __out.AppendLine(false); //254:6
            __out.AppendLine(true); //255:1
            __out.Append("    public override object MMetaModel"); //256:1
            __out.AppendLine(false); //256:38
            __out.Append("    {"); //257:1
            __out.AppendLine(false); //257:6
            string __tmp24Line = "        get { return null;/*"; //258:1
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
            string __tmp26Line = ";*/ }"; //258:65
            if (__tmp26Line != null) __out.Append(__tmp26Line);
            __out.AppendLine(false); //258:70
            __out.Append("    }"); //259:1
            __out.AppendLine(false); //259:6
            __out.AppendLine(true); //260:1
            __out.Append("    public override object MMetaClass"); //261:1
            __out.AppendLine(false); //261:38
            __out.Append("    {"); //262:1
            __out.AppendLine(false); //262:6
            string __tmp28Line = "        get { return null;/*"; //263:1
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
            string __tmp30Line = ";*/ }"; //263:59
            if (__tmp30Line != null) __out.Append(__tmp30Line);
            __out.AppendLine(false); //263:64
            __out.Append("    }"); //264:1
            __out.AppendLine(false); //264:6
            __out.AppendLine(true); //265:1
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((cls).GetEnumerator()) //266:11
                from prop in __Enumerate((__loop24_var1.GetAllProperties()).GetEnumerator()) //266:16
                select new { __loop24_var1 = __loop24_var1, prop = prop}
                ).ToList(); //266:6
            int __loop24_iteration = 0;
            foreach (var __tmp31 in __loop24_results)
            {
                ++__loop24_iteration;
                var __loop24_var1 = __tmp31.__loop24_var1;
                var prop = __tmp31.prop;
                string __tmp32Prefix = "    "; //267:1
                StringBuilder __tmp33 = new StringBuilder();
                __tmp33.Append(GenerateBuilderPropertyImpl(model, cls, prop));
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
                        __out.AppendLine(false); //267:52
                    }
                }
            }
            __out.Append("}"); //269:1
            __out.AppendLine(false); //269:2
            __out.AppendLine(true); //270:1
            return __out.ToString();
        }

        public string GeneratePropertyDeclaration(MetaModel model, MetaClass cls, MetaProperty prop) //273:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class == cls) //274:2
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
                        __out.AppendLine(false); //275:28
                    }
                }
                if (prop.Kind == MetaPropertyKind.Containment) //276:2
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
                            __out.AppendLine(false); //277:27
                        }
                    }
                }
                if (prop.Kind != MetaPropertyKind.Normal && prop.Kind != MetaPropertyKind.Containment) //279:2
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
                            __out.AppendLine(false); //280:24
                        }
                    }
                }
                var __loop25_results = 
                    (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //282:7
                    select new { p = p}
                    ).ToList(); //282:2
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
                            __out.AppendLine(false); //283:92
                        }
                    }
                }
                var __loop26_results = 
                    (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //285:7
                    select new { p = p}
                    ).ToList(); //285:2
                int __loop26_iteration = 0;
                foreach (var __tmp14 in __loop26_results)
                {
                    ++__loop26_iteration;
                    var p = __tmp14.p;
                    if (cls.GetAllSuperClasses(true).Contains(p.Class)) //286:3
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
                                __out.AppendLine(false); //287:91
                            }
                        }
                    }
                    else //288:3
                    {
                        string __tmp22Line = "// ERROR: subsetted property '"; //289:1
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
                        string __tmp24Line = "' must be a property of an ancestor class"; //289:61
                        if (__tmp24Line != null) __out.Append(__tmp24Line);
                        __out.AppendLine(false); //289:102
                    }
                }
                var __loop27_results = 
                    (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //292:7
                    select new { p = p}
                    ).ToList(); //292:2
                int __loop27_iteration = 0;
                foreach (var __tmp25 in __loop27_results)
                {
                    ++__loop27_iteration;
                    var p = __tmp25.p;
                    if (cls.GetAllSuperClasses(true).Contains(p.Class)) //293:3
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
                                __out.AppendLine(false); //294:93
                            }
                        }
                    }
                    else //295:3
                    {
                        string __tmp33Line = "// ERROR: redefined property '"; //296:1
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
                        string __tmp35Line = "' must be a property of an ancestor class"; //296:61
                        if (__tmp35Line != null) __out.Append(__tmp35Line);
                        __out.AppendLine(false); //296:102
                    }
                }
                if (prop.Type is MetaCollectionType) //299:2
                {
                    MetaCollectionType collType = (MetaCollectionType)prop.Type; //300:3
                    string __tmp37Line = "public static readonly global::MetaDslx.Core.Immutable.ModelProperty "; //301:1
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
                    string __tmp39Line = "Property ="; //301:81
                    if (__tmp39Line != null) __out.Append(__tmp39Line);
                    __out.AppendLine(false); //301:91
                    string __tmp41Line = "    global::MetaDslx.Core.Immutable.ModelProperty.Register(\""; //302:1
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
                    string __tmp43Line = "\", typeof("; //302:72
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
                    string __tmp45Line = "."; //302:123
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
                    string __tmp47Line = "),"; //302:149
                    if (__tmp47Line != null) __out.Append(__tmp47Line);
                    __out.AppendLine(false); //302:151
                    string __tmp49Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //303:1
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
                    string __tmp51Line = "), typeof("; //303:136
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
                    string __tmp53Line = "), typeof("; //303:199
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
                    string __tmp55Line = ")),"; //303:257
                    if (__tmp55Line != null) __out.Append(__tmp55Line);
                    __out.AppendLine(false); //303:260
                    string __tmp57Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //304:1
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
                    string __tmp59Line = "), typeof("; //304:134
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
                    string __tmp61Line = "), typeof("; //304:195
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
                    string __tmp63Line = ")));"; //304:251
                    if (__tmp63Line != null) __out.Append(__tmp63Line);
                    __out.AppendLine(false); //304:255
                }
                else //305:2
                {
                    string __tmp65Line = "public static readonly global::MetaDslx.Core.Immutable.ModelProperty "; //306:1
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
                    string __tmp67Line = "Property ="; //306:81
                    if (__tmp67Line != null) __out.Append(__tmp67Line);
                    __out.AppendLine(false); //306:91
                    string __tmp69Line = "    global::MetaDslx.Core.Immutable.ModelProperty.Register(\""; //307:1
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
                    string __tmp71Line = "\", typeof("; //307:72
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
                    string __tmp73Line = "."; //307:123
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
                    string __tmp75Line = "),"; //307:149
                    if (__tmp75Line != null) __out.Append(__tmp75Line);
                    __out.AppendLine(false); //307:151
                    string __tmp77Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //308:1
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
                    string __tmp79Line = "), null, typeof("; //308:127
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
                    string __tmp81Line = ")),"; //308:191
                    if (__tmp81Line != null) __out.Append(__tmp81Line);
                    __out.AppendLine(false); //308:194
                    string __tmp83Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //309:1
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
                    string __tmp85Line = "), null, typeof("; //309:125
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
                    string __tmp87Line = ")));"; //309:187
                    if (__tmp87Line != null) __out.Append(__tmp87Line);
                    __out.AppendLine(false); //309:191
                }
            }
            __out.AppendLine(true); //312:1
            return __out.ToString();
        }

        public string GenerateImmutablePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //315:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //316:1
            if (cls.GetAllFinalProperties().Contains(prop)) //317:2
            {
                string __tmp2Line = "public "; //318:1
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
                string __tmp4Line = " "; //318:61
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
                        __out.AppendLine(false); //318:73
                    }
                }
                __out.Append("{"); //319:1
                __out.AppendLine(false); //319:2
                if (prop.Type is MetaCollectionType) //320:6
                {
                    string __tmp7Line = "    get { return this.GetList<"; //321:1
                    if (__tmp7Line != null) __out.Append(__tmp7Line);
                    StringBuilder __tmp8 = new StringBuilder();
                    __tmp8.Append(((MetaCollectionType)prop.Type).InnerType.CSharpFullPublicName(ClassKind.Immutable));
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
                    string __tmp9Line = ">("; //321:116
                    if (__tmp9Line != null) __out.Append(__tmp9Line);
                    StringBuilder __tmp10 = new StringBuilder();
                    __tmp10.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
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
                    string __tmp11Line = ", ref _"; //321:170
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
                        }
                    }
                    string __tmp13Line = "); }"; //321:188
                    if (__tmp13Line != null) __out.Append(__tmp13Line);
                    __out.AppendLine(false); //321:192
                }
                else if (prop.Type.IsReferenceType()) //322:3
                {
                    string __tmp15Line = "    get { return this.GetReference<"; //323:1
                    if (__tmp15Line != null) __out.Append(__tmp15Line);
                    StringBuilder __tmp16 = new StringBuilder();
                    __tmp16.Append(prop.Type.CSharpFullPublicName(ClassKind.Immutable));
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
                    string __tmp17Line = ">("; //323:89
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
                    string __tmp19Line = ", ref _"; //323:143
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
                    string __tmp21Line = "); }"; //323:161
                    if (__tmp21Line != null) __out.Append(__tmp21Line);
                    __out.AppendLine(false); //323:165
                }
                else //324:3
                {
                    string __tmp23Line = "    get { return this.GetValue<"; //325:1
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
                    string __tmp25Line = ">("; //325:85
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
                    string __tmp27Line = ", ref _"; //325:139
                    if (__tmp27Line != null) __out.Append(__tmp27Line);
                    StringBuilder __tmp28 = new StringBuilder();
                    __tmp28.Append(prop.Name);
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
                    string __tmp29Line = "); }"; //325:157
                    if (__tmp29Line != null) __out.Append(__tmp29Line);
                    __out.AppendLine(false); //325:161
                }
                __out.Append("}"); //327:1
                __out.AppendLine(false); //327:2
            }
            else //328:2
            {
                StringBuilder __tmp31 = new StringBuilder();
                __tmp31.Append("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
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
                        __out.AppendLine(false); //329:54
                    }
                }
                StringBuilder __tmp33 = new StringBuilder();
                __tmp33.Append(prop.Type.CSharpFullPublicName(ClassKind.Immutable));
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
                string __tmp34Line = " "; //330:54
                if (__tmp34Line != null) __out.Append(__tmp34Line);
                StringBuilder __tmp35 = new StringBuilder();
                __tmp35.Append(prop.Class.CSharpFullName(ClassKind.Immutable));
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
                string __tmp36Line = "."; //330:103
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
                        __out.AppendLine(false); //330:115
                    }
                }
                __out.Append("{"); //331:1
                __out.AppendLine(false); //331:2
                string __tmp39Line = "    get { return this."; //332:1
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
                string __tmp41Line = "; }"; //332:34
                if (__tmp41Line != null) __out.Append(__tmp41Line);
                __out.AppendLine(false); //332:37
                __out.Append("}"); //333:1
                __out.AppendLine(false); //333:2
            }
            return __out.ToString();
        }

        public string GenerateBuilderPropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //337:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //338:1
            if (cls.GetAllFinalProperties().Contains(prop)) //339:2
            {
                string __tmp2Line = "public "; //340:1
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
                string __tmp4Line = " "; //340:59
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
                        __out.AppendLine(false); //340:71
                    }
                }
            }
            else //341:2
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
                        __out.AppendLine(false); //342:54
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
                string __tmp10Line = " "; //343:52
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
                string __tmp12Line = "."; //343:99
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
                        __out.AppendLine(false); //343:111
                    }
                }
            }
            __out.Append("{"); //345:1
            __out.AppendLine(false); //345:2
            if (prop.Type is MetaCollectionType) //346:6
            {
                string __tmp15Line = "    get { return this.GetList<"; //347:1
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
                string __tmp17Line = ">("; //347:114
                if (__tmp17Line != null) __out.Append(__tmp17Line);
                StringBuilder __tmp18 = new StringBuilder();
                __tmp18.Append(prop.CSharpFullDescriptorName(ClassKind.Builder));
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
                string __tmp19Line = ", ref _"; //347:166
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
                string __tmp21Line = "); }"; //347:184
                if (__tmp21Line != null) __out.Append(__tmp21Line);
                __out.AppendLine(false); //347:188
            }
            else if (prop.Type.IsReferenceType()) //348:3
            {
                string __tmp23Line = "    get { return this.GetReference<"; //349:1
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
                string __tmp25Line = ">("; //349:87
                if (__tmp25Line != null) __out.Append(__tmp25Line);
                StringBuilder __tmp26 = new StringBuilder();
                __tmp26.Append(prop.CSharpFullDescriptorName(ClassKind.Builder));
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
                string __tmp27Line = "); }"; //349:139
                if (__tmp27Line != null) __out.Append(__tmp27Line);
                __out.AppendLine(false); //349:143
            }
            else //350:3
            {
                string __tmp29Line = "    get { return this.GetValue<"; //351:1
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
                string __tmp31Line = ">("; //351:83
                if (__tmp31Line != null) __out.Append(__tmp31Line);
                StringBuilder __tmp32 = new StringBuilder();
                __tmp32.Append(prop.CSharpFullDescriptorName(ClassKind.Builder));
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
                string __tmp33Line = "); }"; //351:135
                if (__tmp33Line != null) __out.Append(__tmp33Line);
                __out.AppendLine(false); //351:139
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //353:3
            {
                if (prop.Type.IsReferenceType()) //354:4
                {
                    string __tmp35Line = "    set { this.SetReference<"; //355:1
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
                    string __tmp37Line = ">("; //355:80
                    if (__tmp37Line != null) __out.Append(__tmp37Line);
                    StringBuilder __tmp38 = new StringBuilder();
                    __tmp38.Append(prop.CSharpFullDescriptorName(ClassKind.Builder));
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
                    string __tmp39Line = ", value); }"; //355:132
                    if (__tmp39Line != null) __out.Append(__tmp39Line);
                    __out.AppendLine(false); //355:143
                }
                else //356:4
                {
                    string __tmp41Line = "    set { this.SetValue<"; //357:1
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
                    string __tmp43Line = ">("; //357:76
                    if (__tmp43Line != null) __out.Append(__tmp43Line);
                    StringBuilder __tmp44 = new StringBuilder();
                    __tmp44.Append(prop.CSharpFullDescriptorName(ClassKind.Builder));
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
                    string __tmp45Line = ", value); }"; //357:128
                    if (__tmp45Line != null) __out.Append(__tmp45Line);
                    __out.AppendLine(false); //357:139
                }
            }
            __out.Append("}"); //360:1
            __out.AppendLine(false); //360:2
            if (!(prop.Type is MetaCollectionType)) //361:2
            {
                __out.AppendLine(true); //362:1
                if (cls.GetAllFinalProperties().Contains(prop)) //363:3
                {
                    string __tmp47Line = "public Func<"; //364:1
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
                    string __tmp49Line = "> "; //364:64
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
                    string __tmp51Line = "Lazy"; //364:77
                    if (__tmp51Line != null) __out.Append(__tmp51Line);
                    __out.AppendLine(false); //364:81
                }
                else //365:3
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
                            __out.AppendLine(false); //366:54
                        }
                    }
                    string __tmp55Line = "Func<"; //367:1
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
                    string __tmp57Line = "> "; //367:57
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
                    string __tmp59Line = "."; //367:105
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
                    string __tmp61Line = "Lazy"; //367:117
                    if (__tmp61Line != null) __out.Append(__tmp61Line);
                    __out.AppendLine(false); //367:121
                }
                __out.Append("{"); //369:1
                __out.AppendLine(false); //369:2
                if (prop.Type.IsReferenceType()) //370:4
                {
                    string __tmp63Line = "    get { return this.GetLazyReference<"; //371:1
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
                    string __tmp65Line = ">("; //371:91
                    if (__tmp65Line != null) __out.Append(__tmp65Line);
                    StringBuilder __tmp66 = new StringBuilder();
                    __tmp66.Append(prop.CSharpFullDescriptorName(ClassKind.Builder));
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
                    string __tmp67Line = "); }"; //371:143
                    if (__tmp67Line != null) __out.Append(__tmp67Line);
                    __out.AppendLine(false); //371:147
                    string __tmp69Line = "    set { this.SetLazyReference("; //372:1
                    if (__tmp69Line != null) __out.Append(__tmp69Line);
                    StringBuilder __tmp70 = new StringBuilder();
                    __tmp70.Append(prop.CSharpFullDescriptorName(ClassKind.Builder));
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
                    string __tmp71Line = ", value); }"; //372:83
                    if (__tmp71Line != null) __out.Append(__tmp71Line);
                    __out.AppendLine(false); //372:94
                }
                else //373:4
                {
                    string __tmp73Line = "    get { return this.GetLazyValue<"; //374:1
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
                    string __tmp75Line = ">("; //374:87
                    if (__tmp75Line != null) __out.Append(__tmp75Line);
                    StringBuilder __tmp76 = new StringBuilder();
                    __tmp76.Append(prop.CSharpFullDescriptorName(ClassKind.Builder));
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
                    string __tmp77Line = "); }"; //374:139
                    if (__tmp77Line != null) __out.Append(__tmp77Line);
                    __out.AppendLine(false); //374:143
                    string __tmp79Line = "    set { this.SetLazyValue("; //375:1
                    if (__tmp79Line != null) __out.Append(__tmp79Line);
                    StringBuilder __tmp80 = new StringBuilder();
                    __tmp80.Append(prop.CSharpFullDescriptorName(ClassKind.Builder));
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
                    string __tmp81Line = ", value); }"; //375:79
                    if (__tmp81Line != null) __out.Append(__tmp81Line);
                    __out.AppendLine(false); //375:90
                }
                __out.Append("}"); //377:1
                __out.AppendLine(false); //377:2
            }
            return __out.ToString();
        }

        public string GetReturn(MetaOperation op) //381:1
        {
            if (op.ReturnType.CSharpName() == "void") //382:5
            {
                return ""; //383:3
            }
            else //384:2
            {
                return "return "; //385:3
            }
        }

        public string GenerateOperationImpl(MetaModel model, MetaOperation op) //389:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //390:1
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
            string __tmp3Line = " "; //391:58
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
            string __tmp5Line = "."; //391:106
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
            string __tmp7Line = "("; //391:116
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
            string __tmp9Line = ")"; //391:143
            if (__tmp9Line != null) __out.Append(__tmp9Line);
            __out.AppendLine(false); //391:144
            __out.Append("{"); //392:1
            __out.AppendLine(false); //392:2
            string __tmp10Prefix = "    "; //393:1
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
            string __tmp13Line = "."; //393:77
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
            string __tmp15Line = "_"; //393:102
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
            string __tmp17Line = "("; //393:112
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
            string __tmp19Line = ");"; //393:144
            if (__tmp19Line != null) __out.Append(__tmp19Line);
            __out.AppendLine(false); //393:146
            __out.Append("}"); //394:1
            __out.AppendLine(false); //394:2
            return __out.ToString();
        }

        public string GetSuperClasses(MetaClass cls) //397:1
        {
            string result = ""; //398:2
            var __loop28_results = 
                (from __loop28_var1 in __Enumerate((cls).GetEnumerator()) //399:10
                from sup in __Enumerate((__loop28_var1.SuperClasses).GetEnumerator()) //399:15
                select new { __loop28_var1 = __loop28_var1, sup = sup}
                ).ToList(); //399:5
            int __loop28_iteration = 0;
            string delim = ""; //399:33
            foreach (var __tmp1 in __loop28_results)
            {
                ++__loop28_iteration;
                if (__loop28_iteration >= 2) //399:52
                {
                    delim = ", "; //399:52
                }
                var __loop28_var1 = __tmp1.__loop28_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpFullName(); //400:3
            }
            return result; //402:2
        }

        public string GetAllSuperClasses(MetaClass cls) //405:1
        {
            string result = ""; //406:2
            var __loop29_results = 
                (from __loop29_var1 in __Enumerate((cls).GetEnumerator()) //407:10
                from sup in __Enumerate((__loop29_var1.GetAllSuperClasses(false)).GetEnumerator()) //407:15
                select new { __loop29_var1 = __loop29_var1, sup = sup}
                ).ToList(); //407:5
            int __loop29_iteration = 0;
            string delim = ""; //407:46
            foreach (var __tmp1 in __loop29_results)
            {
                ++__loop29_iteration;
                if (__loop29_iteration >= 2) //407:65
                {
                    delim = ", "; //407:65
                }
                var __loop29_var1 = __tmp1.__loop29_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpFullName(); //408:3
            }
            return result; //410:2
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //413:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "public static class "; //414:1
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
                    __out.AppendLine(false); //414:51
                }
            }
            __out.Append("{"); //415:1
            __out.AppendLine(false); //415:2
            __out.Append("	private static global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty> properties = new global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty>();"); //416:1
            __out.AppendLine(false); //416:210
            __out.AppendLine(true); //417:1
            string __tmp5Line = "    static "; //418:1
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
            string __tmp7Line = "()"; //418:42
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //418:44
            __out.Append("    {"); //419:1
            __out.AppendLine(false); //419:6
            var __loop30_results = 
                (from __loop30_var1 in __Enumerate((model).GetEnumerator()) //420:11
                from Namespace in __Enumerate((__loop30_var1.Namespace).GetEnumerator()) //420:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //420:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //420:43
                from prop in __Enumerate((cls.Properties).GetEnumerator()) //420:66
                select new { __loop30_var1 = __loop30_var1, Namespace = Namespace, Declarations = Declarations, cls = cls, prop = prop}
                ).ToList(); //420:6
            int __loop30_iteration = 0;
            foreach (var __tmp8 in __loop30_results)
            {
                ++__loop30_iteration;
                var __loop30_var1 = __tmp8.__loop30_var1;
                var Namespace = __tmp8.Namespace;
                var Declarations = __tmp8.Declarations;
                var cls = __tmp8.cls;
                var prop = __tmp8.prop;
                string __tmp10Line = "        properties.Add("; //421:1
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
                string __tmp12Line = "."; //421:42
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
                string __tmp14Line = "Property);"; //421:54
                if (__tmp14Line != null) __out.Append(__tmp14Line);
                __out.AppendLine(false); //421:64
            }
            __out.AppendLine(true); //423:1
            __out.Append("        foreach (var property in properties)"); //424:1
            __out.AppendLine(false); //424:45
            __out.Append("        {"); //425:1
            __out.AppendLine(false); //425:10
            __out.Append("            property.Init();"); //426:1
            __out.AppendLine(false); //426:29
            __out.Append("        }"); //427:1
            __out.AppendLine(false); //427:10
            __out.Append("    }"); //428:1
            __out.AppendLine(false); //428:6
            __out.AppendLine(true); //429:1
            __out.Append("    public static void Init()"); //430:1
            __out.AppendLine(false); //430:30
            __out.Append("    {"); //431:1
            __out.AppendLine(false); //431:6
            __out.Append("    }"); //433:1
            __out.AppendLine(false); //433:6
            __out.AppendLine(true); //434:1
            string __tmp16Line = "	public const string Uri = \""; //435:1
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
            string __tmp18Line = "\";"; //435:40
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //435:42
            __out.AppendLine(true); //436:1
            var __loop31_results = 
                (from __loop31_var1 in __Enumerate((model).GetEnumerator()) //437:11
                from Namespace in __Enumerate((__loop31_var1.Namespace).GetEnumerator()) //437:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //437:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //437:43
                select new { __loop31_var1 = __loop31_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //437:6
            int __loop31_iteration = 0;
            foreach (var __tmp19 in __loop31_results)
            {
                ++__loop31_iteration;
                var __loop31_var1 = __tmp19.__loop31_var1;
                var Namespace = __tmp19.Namespace;
                var Declarations = __tmp19.Declarations;
                var cls = __tmp19.cls;
                string __tmp20Prefix = "    "; //438:1
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
                        __out.AppendLine(false); //438:34
                    }
                }
            }
            __out.Append("}"); //440:1
            __out.AppendLine(false); //440:2
            __out.AppendLine(true); //441:1
            return __out.ToString();
        }

        public string GenerateMetaModelClass(MetaClass cls) //445:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //446:1
            string __tmp2Line = "public static class "; //447:1
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
                    __out.AppendLine(false); //447:39
                }
            }
            __out.Append("{"); //448:1
            __out.AppendLine(false); //448:2
            __out.AppendLine(true); //449:1
            if (cls.CSharpName() == "MetaClass") //450:2
            {
                __out.Append("    public static global::MetaDslx.Core.Immutable.MetaClass _MetaClass"); //451:1
                __out.AppendLine(false); //451:71
            }
            else //452:2
            {
                __out.Append("    public static global::MetaDslx.Core.Immutable.MetaClass MetaClass"); //453:1
                __out.AppendLine(false); //453:70
            }
            __out.Append("    {"); //455:1
            __out.AppendLine(false); //455:6
            string __tmp5Line = "        get { return null;/*"; //456:1
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
            string __tmp7Line = ";*/ }"; //456:59
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //456:64
            __out.Append("    }"); //457:1
            __out.AppendLine(false); //457:6
            __out.AppendLine(true); //458:1
            var __loop32_results = 
                (from __loop32_var1 in __Enumerate((cls).GetEnumerator()) //459:11
                from prop in __Enumerate((__loop32_var1.Properties).GetEnumerator()) //459:16
                select new { __loop32_var1 = __loop32_var1, prop = prop}
                ).ToList(); //459:6
            int __loop32_iteration = 0;
            foreach (var __tmp8 in __loop32_results)
            {
                ++__loop32_iteration;
                var __loop32_var1 = __tmp8.__loop32_var1;
                var prop = __tmp8.prop;
                string __tmp9Prefix = "    "; //460:1
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
                        __out.AppendLine(false); //460:56
                    }
                }
            }
            __out.Append("}"); //462:1
            __out.AppendLine(false); //462:2
            return __out.ToString();
        }

        public MetaSynthetizedPropertyInitializer GetSynthetizedInitializerFor(MetaClass cls, MetaProperty prop) //466:1
        {
            MetaSynthetizedPropertyInitializer lastInit = null; //467:2
            var __loop33_results = 
                (from __loop33_var1 in __Enumerate((cls).GetEnumerator()) //468:7
                from sup in __Enumerate((__loop33_var1.GetAllSuperClasses(true)).GetEnumerator()) //468:12
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //468:42
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //468:55
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaSynthetizedPropertyInitializer>() //468:69
                select new { __loop33_var1 = __loop33_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //468:2
            int __loop33_iteration = 0;
            foreach (var __tmp1 in __loop33_results)
            {
                ++__loop33_iteration;
                var __loop33_var1 = __tmp1.__loop33_var1;
                var sup = __tmp1.sup;
                var Constructor = __tmp1.Constructor;
                var Initializers = __tmp1.Initializers;
                var init = __tmp1.init;
                if (init.Property == prop) //469:3
                {
                    lastInit = init; //470:4
                }
            }
            return lastInit; //473:2
        }

        public string GenerateImplementationProvider(MetaModel model) //477:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal static class "; //478:1
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
            string __tmp4Line = "ImplementationProvider"; //478:35
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //478:57
            __out.Append("{"); //479:1
            __out.AppendLine(false); //479:2
            string __tmp6Line = "    // If there is a compile error at this line, create a new class called "; //480:1
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
            string __tmp8Line = "Implementation"; //480:88
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //480:102
            string __tmp10Line = "	// which is a subclass of "; //481:1
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
            string __tmp12Line = "ImplementationBase:"; //481:40
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //481:59
            string __tmp14Line = "    private static "; //482:1
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
            string __tmp16Line = "Implementation implementation = new "; //482:32
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
            string __tmp18Line = "Implementation();"; //482:80
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //482:97
            __out.AppendLine(true); //483:1
            string __tmp20Line = "    public static "; //484:1
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
            string __tmp22Line = "Implementation Implementation"; //484:31
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            __out.AppendLine(false); //484:60
            __out.Append("    {"); //485:1
            __out.AppendLine(false); //485:6
            string __tmp24Line = "        get { return "; //486:1
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
            string __tmp26Line = "ImplementationProvider.implementation; }"; //486:34
            if (__tmp26Line != null) __out.Append(__tmp26Line);
            __out.AppendLine(false); //486:74
            __out.Append("    }"); //487:1
            __out.AppendLine(false); //487:6
            __out.Append("}"); //488:1
            __out.AppendLine(false); //488:2
            var __loop34_results = 
                (from __loop34_var1 in __Enumerate((model).GetEnumerator()) //489:8
                from Namespace in __Enumerate((__loop34_var1.Namespace).GetEnumerator()) //489:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //489:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //489:40
                select new { __loop34_var1 = __loop34_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //489:3
            int __loop34_iteration = 0;
            foreach (var __tmp27 in __loop34_results)
            {
                ++__loop34_iteration;
                var __loop34_var1 = __tmp27.__loop34_var1;
                var Namespace = __tmp27.Namespace;
                var Declarations = __tmp27.Declarations;
                var enm = __tmp27.enm;
                __out.AppendLine(true); //490:1
                string __tmp29Line = "public static class "; //491:1
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
                string __tmp31Line = "Extensions"; //491:31
                if (__tmp31Line != null) __out.Append(__tmp31Line);
                __out.AppendLine(false); //491:41
                __out.Append("{"); //492:1
                __out.AppendLine(false); //492:2
                var __loop35_results = 
                    (from __loop35_var1 in __Enumerate((enm).GetEnumerator()) //493:11
                    from op in __Enumerate((__loop35_var1.Operations).GetEnumerator()) //493:16
                    select new { __loop35_var1 = __loop35_var1, op = op}
                    ).ToList(); //493:6
                int __loop35_iteration = 0;
                foreach (var __tmp32 in __loop35_results)
                {
                    ++__loop35_iteration;
                    var __loop35_var1 = __tmp32.__loop35_var1;
                    var op = __tmp32.op;
                    string __tmp34Line = "    public static "; //494:1
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
                    string __tmp36Line = " "; //494:76
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
                    string __tmp38Line = "("; //494:86
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
                    string __tmp40Line = ")"; //494:119
                    if (__tmp40Line != null) __out.Append(__tmp40Line);
                    __out.AppendLine(false); //494:120
                    __out.Append("    {"); //495:1
                    __out.AppendLine(false); //495:6
                    string __tmp41Prefix = "        "; //496:1
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
                    string __tmp44Line = "ImplementationProvider.Implementation."; //496:36
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
                    string __tmp46Line = "_"; //496:98
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
                    string __tmp48Line = "("; //496:108
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
                    string __tmp50Line = ");"; //496:144
                    if (__tmp50Line != null) __out.Append(__tmp50Line);
                    __out.AppendLine(false); //496:146
                    __out.Append("    }"); //497:1
                    __out.AppendLine(false); //497:6
                }
                __out.Append("}"); //499:1
                __out.AppendLine(false); //499:2
            }
            __out.AppendLine(true); //501:1
            __out.Append("/// <summary>"); //502:1
            __out.AppendLine(false); //502:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //503:1
            __out.AppendLine(false); //503:68
            string __tmp52Line = "/// This class has to be be overriden in "; //504:1
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
            string __tmp54Line = "Implementation to provide custom"; //504:54
            if (__tmp54Line != null) __out.Append(__tmp54Line);
            __out.AppendLine(false); //504:86
            __out.Append("/// implementation for the constructors, operations and property values."); //505:1
            __out.AppendLine(false); //505:73
            __out.Append("/// </summary>"); //506:1
            __out.AppendLine(false); //506:15
            string __tmp56Line = "internal abstract class "; //507:1
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
            string __tmp58Line = "ImplementationBase"; //507:37
            if (__tmp58Line != null) __out.Append(__tmp58Line);
            __out.AppendLine(false); //507:55
            __out.Append("{"); //508:1
            __out.AppendLine(false); //508:2
            var __loop36_results = 
                (from __loop36_var1 in __Enumerate((model).GetEnumerator()) //509:8
                from Namespace in __Enumerate((__loop36_var1.Namespace).GetEnumerator()) //509:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //509:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //509:40
                select new { __loop36_var1 = __loop36_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //509:3
            int __loop36_iteration = 0;
            foreach (var __tmp59 in __loop36_results)
            {
                ++__loop36_iteration;
                var __loop36_var1 = __tmp59.__loop36_var1;
                var Namespace = __tmp59.Namespace;
                var Declarations = __tmp59.Declarations;
                var cls = __tmp59.cls;
                __out.Append("    /// <summary>"); //510:1
                __out.AppendLine(false); //510:18
                string __tmp61Line = "	/// Implements the constructor: "; //511:1
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
                string __tmp63Line = "()"; //511:52
                if (__tmp63Line != null) __out.Append(__tmp63Line);
                __out.AppendLine(false); //511:54
                if ((from __loop37_var1 in __Enumerate((cls).GetEnumerator()) //512:15
                from sup in __Enumerate((__loop37_var1.SuperClasses).GetEnumerator()) //512:20
                select new { __loop37_var1 = __loop37_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //512:3
                {
                    string __tmp65Line = "	/// Direct superclasses: "; //513:1
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
                            __out.AppendLine(false); //513:49
                        }
                    }
                    string __tmp68Line = "	/// All superclasses: "; //514:1
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
                            __out.AppendLine(false); //514:49
                        }
                    }
                }
                if ((from __loop38_var1 in __Enumerate((cls).GetEnumerator()) //516:15
                from prop in __Enumerate((__loop38_var1.GetAllProperties()).GetEnumerator()) //516:20
                where prop.Kind == MetaPropertyKind.Readonly //516:44
                select new { __loop38_var1 = __loop38_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //516:3
                {
                    __out.Append("    /// Initializes the following readonly properties:"); //517:1
                    __out.AppendLine(false); //517:55
                }
                var __loop39_results = 
                    (from __loop39_var1 in __Enumerate((cls).GetEnumerator()) //519:11
                    from prop in __Enumerate((__loop39_var1.GetAllProperties()).GetEnumerator()) //519:16
                    select new { __loop39_var1 = __loop39_var1, prop = prop}
                    ).ToList(); //519:6
                int __loop39_iteration = 0;
                foreach (var __tmp70 in __loop39_results)
                {
                    ++__loop39_iteration;
                    var __loop39_var1 = __tmp70.__loop39_var1;
                    var prop = __tmp70.prop;
                    if (prop.Kind == MetaPropertyKind.Readonly) //520:3
                    {
                        string __tmp72Line = "    ///    "; //521:1
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
                        string __tmp74Line = "."; //521:29
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
                                __out.AppendLine(false); //521:41
                            }
                        }
                    }
                }
                __out.Append("    /// </summary>"); //524:1
                __out.AppendLine(false); //524:19
                string __tmp77Line = "    public virtual void "; //525:1
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
                string __tmp79Line = "("; //525:43
                if (__tmp79Line != null) __out.Append(__tmp79Line);
                StringBuilder __tmp80 = new StringBuilder();
                __tmp80.Append(cls.CSharpName(ClassKind.Builder));
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
                string __tmp81Line = " @this)"; //525:79
                if (__tmp81Line != null) __out.Append(__tmp81Line);
                __out.AppendLine(false); //525:86
                __out.Append("    {"); //526:1
                __out.AppendLine(false); //526:6
                var __loop40_results = 
                    (from __loop40_var1 in __Enumerate((cls).GetEnumerator()) //527:9
                    from sup in __Enumerate((__loop40_var1.SuperClasses).GetEnumerator()) //527:14
                    select new { __loop40_var1 = __loop40_var1, sup = sup}
                    ).ToList(); //527:4
                int __loop40_iteration = 0;
                foreach (var __tmp82 in __loop40_results)
                {
                    ++__loop40_iteration;
                    var __loop40_var1 = __tmp82.__loop40_var1;
                    var sup = __tmp82.sup;
                    string __tmp84Line = "        this."; //528:1
                    if (__tmp84Line != null) __out.Append(__tmp84Line);
                    StringBuilder __tmp85 = new StringBuilder();
                    __tmp85.Append(sup.CSharpName());
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
                    string __tmp86Line = "(@this);"; //528:32
                    if (__tmp86Line != null) __out.Append(__tmp86Line);
                    __out.AppendLine(false); //528:40
                }
                __out.Append("    }"); //530:1
                __out.AppendLine(false); //530:6
                var __loop41_results = 
                    (from __loop41_var1 in __Enumerate((cls).GetEnumerator()) //531:11
                    from prop in __Enumerate((__loop41_var1.Properties).GetEnumerator()) //531:16
                    select new { __loop41_var1 = __loop41_var1, prop = prop}
                    ).ToList(); //531:6
                int __loop41_iteration = 0;
                foreach (var __tmp87 in __loop41_results)
                {
                    ++__loop41_iteration;
                    var __loop41_var1 = __tmp87.__loop41_var1;
                    var prop = __tmp87.prop;
                    MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //532:4
                    if (synInit == null) //533:4
                    {
                        if (prop.Kind == MetaPropertyKind.Derived) //534:5
                        {
                            __out.AppendLine(true); //535:1
                            __out.Append("    /// <summary>"); //536:1
                            __out.AppendLine(false); //536:18
                            string __tmp89Line = "    /// Returns the value of the derived property: "; //537:1
                            if (__tmp89Line != null) __out.Append(__tmp89Line);
                            StringBuilder __tmp90 = new StringBuilder();
                            __tmp90.Append(cls.CSharpName());
                            using(StreamReader __tmp90Reader = new StreamReader(this.__ToStream(__tmp90.ToString())))
                            {
                                bool __tmp90_first = true;
                                bool __tmp90_last = __tmp90Reader.EndOfStream;
                                while(__tmp90_first || !__tmp90_last)
                                {
                                    __tmp90_first = false;
                                    string __tmp90Line = __tmp90Reader.ReadLine();
                                    __tmp90_last = __tmp90Reader.EndOfStream;
                                    if (__tmp90Line != null) __out.Append(__tmp90Line);
                                    if (!__tmp90_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp91Line = "."; //537:70
                            if (__tmp91Line != null) __out.Append(__tmp91Line);
                            StringBuilder __tmp92 = new StringBuilder();
                            __tmp92.Append(prop.Name);
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
                                    __out.AppendLine(false); //537:82
                                }
                            }
                            __out.Append("    /// </summary>"); //538:1
                            __out.AppendLine(false); //538:19
                            string __tmp94Line = "    public virtual "; //539:1
                            if (__tmp94Line != null) __out.Append(__tmp94Line);
                            StringBuilder __tmp95 = new StringBuilder();
                            __tmp95.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
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
                            string __tmp96Line = " "; //539:71
                            if (__tmp96Line != null) __out.Append(__tmp96Line);
                            StringBuilder __tmp97 = new StringBuilder();
                            __tmp97.Append(cls.CSharpName());
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
                            string __tmp98Line = "_"; //539:90
                            if (__tmp98Line != null) __out.Append(__tmp98Line);
                            StringBuilder __tmp99 = new StringBuilder();
                            __tmp99.Append(prop.Name);
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
                            string __tmp100Line = "("; //539:102
                            if (__tmp100Line != null) __out.Append(__tmp100Line);
                            StringBuilder __tmp101 = new StringBuilder();
                            __tmp101.Append(cls.CSharpName(ClassKind.Builder));
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
                            string __tmp102Line = " @this)"; //539:138
                            if (__tmp102Line != null) __out.Append(__tmp102Line);
                            __out.AppendLine(false); //539:145
                            __out.Append("    {"); //540:1
                            __out.AppendLine(false); //540:6
                            __out.Append("        throw new NotImplementedException();"); //541:1
                            __out.AppendLine(false); //541:45
                            __out.Append("    }"); //542:1
                            __out.AppendLine(false); //542:6
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //543:5
                        {
                            __out.AppendLine(true); //544:1
                            __out.Append("    /// <summary>"); //545:1
                            __out.AppendLine(false); //545:18
                            string __tmp104Line = "    /// Returns the value of the lazy property: "; //546:1
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
                            string __tmp106Line = "."; //546:67
                            if (__tmp106Line != null) __out.Append(__tmp106Line);
                            StringBuilder __tmp107 = new StringBuilder();
                            __tmp107.Append(prop.Name);
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
                                    __out.AppendLine(false); //546:79
                                }
                            }
                            __out.Append("    /// </summary>"); //547:1
                            __out.AppendLine(false); //547:19
                            string __tmp109Line = "    public virtual "; //548:1
                            if (__tmp109Line != null) __out.Append(__tmp109Line);
                            StringBuilder __tmp110 = new StringBuilder();
                            __tmp110.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
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
                            string __tmp111Line = " "; //548:71
                            if (__tmp111Line != null) __out.Append(__tmp111Line);
                            StringBuilder __tmp112 = new StringBuilder();
                            __tmp112.Append(cls.CSharpName());
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
                            string __tmp113Line = "_"; //548:90
                            if (__tmp113Line != null) __out.Append(__tmp113Line);
                            StringBuilder __tmp114 = new StringBuilder();
                            __tmp114.Append(prop.Name);
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
                            string __tmp115Line = "("; //548:102
                            if (__tmp115Line != null) __out.Append(__tmp115Line);
                            StringBuilder __tmp116 = new StringBuilder();
                            __tmp116.Append(cls.CSharpName(ClassKind.Builder));
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
                            string __tmp117Line = " @this)"; //548:138
                            if (__tmp117Line != null) __out.Append(__tmp117Line);
                            __out.AppendLine(false); //548:145
                            __out.Append("    {"); //549:1
                            __out.AppendLine(false); //549:6
                            __out.Append("        throw new NotImplementedException();"); //550:1
                            __out.AppendLine(false); //550:45
                            __out.Append("    }"); //551:1
                            __out.AppendLine(false); //551:6
                        }
                    }
                }
                var __loop42_results = 
                    (from __loop42_var1 in __Enumerate((cls).GetEnumerator()) //555:11
                    from op in __Enumerate((__loop42_var1.Operations).GetEnumerator()) //555:16
                    select new { __loop42_var1 = __loop42_var1, op = op}
                    ).ToList(); //555:6
                int __loop42_iteration = 0;
                foreach (var __tmp118 in __loop42_results)
                {
                    ++__loop42_iteration;
                    var __loop42_var1 = __tmp118.__loop42_var1;
                    var op = __tmp118.op;
                    __out.AppendLine(true); //556:1
                    __out.Append("    /// <summary>"); //557:1
                    __out.AppendLine(false); //557:18
                    string __tmp120Line = "    /// Implements the operation: "; //558:1
                    if (__tmp120Line != null) __out.Append(__tmp120Line);
                    StringBuilder __tmp121 = new StringBuilder();
                    __tmp121.Append(cls.CSharpName());
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
                    string __tmp122Line = "."; //558:53
                    if (__tmp122Line != null) __out.Append(__tmp122Line);
                    StringBuilder __tmp123 = new StringBuilder();
                    __tmp123.Append(op.Name);
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
                    string __tmp124Line = "()"; //558:63
                    if (__tmp124Line != null) __out.Append(__tmp124Line);
                    __out.AppendLine(false); //558:65
                    __out.Append("    /// </summary>"); //559:1
                    __out.AppendLine(false); //559:19
                    string __tmp126Line = "    public virtual "; //560:1
                    if (__tmp126Line != null) __out.Append(__tmp126Line);
                    StringBuilder __tmp127 = new StringBuilder();
                    __tmp127.Append(op.ReturnType.CSharpFullPublicName(ClassKind.Immutable));
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
                    string __tmp128Line = " "; //560:77
                    if (__tmp128Line != null) __out.Append(__tmp128Line);
                    StringBuilder __tmp129 = new StringBuilder();
                    __tmp129.Append(cls.CSharpName());
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
                    string __tmp130Line = "_"; //560:96
                    if (__tmp130Line != null) __out.Append(__tmp130Line);
                    StringBuilder __tmp131 = new StringBuilder();
                    __tmp131.Append(op.Name);
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
                    string __tmp132Line = "("; //560:106
                    if (__tmp132Line != null) __out.Append(__tmp132Line);
                    StringBuilder __tmp133 = new StringBuilder();
                    __tmp133.Append(GetImplParameters(cls, op));
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
                    string __tmp134Line = ")"; //560:135
                    if (__tmp134Line != null) __out.Append(__tmp134Line);
                    __out.AppendLine(false); //560:136
                    __out.Append("    {"); //561:1
                    __out.AppendLine(false); //561:6
                    __out.Append("        throw new NotImplementedException();"); //562:1
                    __out.AppendLine(false); //562:45
                    __out.Append("    }"); //563:1
                    __out.AppendLine(false); //563:6
                }
                __out.AppendLine(true); //565:1
            }
            var __loop43_results = 
                (from __loop43_var1 in __Enumerate((model).GetEnumerator()) //567:8
                from Namespace in __Enumerate((__loop43_var1.Namespace).GetEnumerator()) //567:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //567:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //567:40
                select new { __loop43_var1 = __loop43_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //567:3
            int __loop43_iteration = 0;
            foreach (var __tmp135 in __loop43_results)
            {
                ++__loop43_iteration;
                var __loop43_var1 = __tmp135.__loop43_var1;
                var Namespace = __tmp135.Namespace;
                var Declarations = __tmp135.Declarations;
                var enm = __tmp135.enm;
                var __loop44_results = 
                    (from __loop44_var1 in __Enumerate((enm).GetEnumerator()) //568:11
                    from op in __Enumerate((__loop44_var1.Operations).GetEnumerator()) //568:16
                    select new { __loop44_var1 = __loop44_var1, op = op}
                    ).ToList(); //568:6
                int __loop44_iteration = 0;
                foreach (var __tmp136 in __loop44_results)
                {
                    ++__loop44_iteration;
                    var __loop44_var1 = __tmp136.__loop44_var1;
                    var op = __tmp136.op;
                    __out.AppendLine(true); //569:1
                    __out.Append("    /// <summary>"); //570:1
                    __out.AppendLine(false); //570:18
                    string __tmp138Line = "    /// Implements the operation: "; //571:1
                    if (__tmp138Line != null) __out.Append(__tmp138Line);
                    StringBuilder __tmp139 = new StringBuilder();
                    __tmp139.Append(enm.CSharpName());
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
                    string __tmp140Line = "."; //571:53
                    if (__tmp140Line != null) __out.Append(__tmp140Line);
                    StringBuilder __tmp141 = new StringBuilder();
                    __tmp141.Append(op.Name);
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
                            __out.AppendLine(false); //571:63
                        }
                    }
                    __out.Append("    /// </summary>"); //572:1
                    __out.AppendLine(false); //572:19
                    string __tmp143Line = "    public virtual "; //573:1
                    if (__tmp143Line != null) __out.Append(__tmp143Line);
                    StringBuilder __tmp144 = new StringBuilder();
                    __tmp144.Append(op.ReturnType.CSharpFullPublicName(ClassKind.Immutable));
                    using(StreamReader __tmp144Reader = new StreamReader(this.__ToStream(__tmp144.ToString())))
                    {
                        bool __tmp144_first = true;
                        bool __tmp144_last = __tmp144Reader.EndOfStream;
                        while(__tmp144_first || !__tmp144_last)
                        {
                            __tmp144_first = false;
                            string __tmp144Line = __tmp144Reader.ReadLine();
                            __tmp144_last = __tmp144Reader.EndOfStream;
                            if (__tmp144Line != null) __out.Append(__tmp144Line);
                            if (!__tmp144_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp145Line = " "; //573:77
                    if (__tmp145Line != null) __out.Append(__tmp145Line);
                    StringBuilder __tmp146 = new StringBuilder();
                    __tmp146.Append(enm.CSharpName());
                    using(StreamReader __tmp146Reader = new StreamReader(this.__ToStream(__tmp146.ToString())))
                    {
                        bool __tmp146_first = true;
                        bool __tmp146_last = __tmp146Reader.EndOfStream;
                        while(__tmp146_first || !__tmp146_last)
                        {
                            __tmp146_first = false;
                            string __tmp146Line = __tmp146Reader.ReadLine();
                            __tmp146_last = __tmp146Reader.EndOfStream;
                            if (__tmp146Line != null) __out.Append(__tmp146Line);
                            if (!__tmp146_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp147Line = "_"; //573:96
                    if (__tmp147Line != null) __out.Append(__tmp147Line);
                    StringBuilder __tmp148 = new StringBuilder();
                    __tmp148.Append(op.Name);
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
                    string __tmp149Line = "("; //573:106
                    if (__tmp149Line != null) __out.Append(__tmp149Line);
                    StringBuilder __tmp150 = new StringBuilder();
                    __tmp150.Append(GetImplParameters(enm, op));
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
                    string __tmp151Line = ")"; //573:135
                    if (__tmp151Line != null) __out.Append(__tmp151Line);
                    __out.AppendLine(false); //573:136
                    __out.Append("    {"); //574:1
                    __out.AppendLine(false); //574:6
                    __out.Append("        throw new NotImplementedException();"); //575:1
                    __out.AppendLine(false); //575:45
                    __out.Append("    }"); //576:1
                    __out.AppendLine(false); //576:6
                }
                __out.AppendLine(true); //578:1
            }
            __out.Append("}"); //580:1
            __out.AppendLine(false); //580:2
            __out.AppendLine(true); //581:1
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //584:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //585:1
            __out.AppendLine(false); //585:14
            __out.Append("/// Factory class for creating instances of model elements."); //586:1
            __out.AppendLine(false); //586:60
            __out.Append("/// </summary>"); //587:1
            __out.AppendLine(false); //587:15
            string __tmp2Line = "public class "; //588:1
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
            string __tmp4Line = " : global::MetaDslx.Core.Immutable.ModelFactory"; //588:41
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //588:88
            __out.Append("{"); //589:1
            __out.AppendLine(false); //589:2
            string __tmp6Line = "    public "; //590:1
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
            string __tmp8Line = "()"; //590:39
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //590:41
            __out.Append("        : base()"); //591:1
            __out.AppendLine(false); //591:17
            __out.Append("    {"); //592:1
            __out.AppendLine(false); //592:6
            string __tmp9Prefix = "		"; //593:1
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
            string __tmp11Line = ".Init();"; //593:33
            if (__tmp11Line != null) __out.Append(__tmp11Line);
            __out.AppendLine(false); //593:41
            __out.Append("    }"); //594:1
            __out.AppendLine(false); //594:6
            __out.AppendLine(true); //595:1
            string __tmp13Line = "    public "; //596:1
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
            string __tmp15Line = "(global::MetaDslx.Core.Immutable.MutableRedModel model)"; //596:39
            if (__tmp15Line != null) __out.Append(__tmp15Line);
            __out.AppendLine(false); //596:94
            __out.Append("        : base(model)"); //597:1
            __out.AppendLine(false); //597:22
            __out.Append("    {"); //598:1
            __out.AppendLine(false); //598:6
            string __tmp16Prefix = "		"; //599:1
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
            string __tmp18Line = ".Init();"; //599:33
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //599:41
            __out.Append("    }"); //600:1
            __out.AppendLine(false); //600:6
            __out.AppendLine(true); //601:1
            string __tmp20Line = "    public "; //602:1
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
            string __tmp22Line = "(global::MetaDslx.Core.Immutable.MutableRedModel model, global::MetaDslx.Core.Immutable.MutableRedModelPart part)"; //602:39
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            __out.AppendLine(false); //602:152
            __out.Append("        : base(model, part)"); //603:1
            __out.AppendLine(false); //603:28
            __out.Append("    {"); //604:1
            __out.AppendLine(false); //604:6
            string __tmp23Prefix = "		"; //605:1
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
            string __tmp25Line = ".Init();"; //605:33
            if (__tmp25Line != null) __out.Append(__tmp25Line);
            __out.AppendLine(false); //605:41
            __out.Append("    }"); //606:1
            __out.AppendLine(false); //606:6
            __out.AppendLine(true); //607:1
            __out.Append("    public override MutableRedSymbol Create(string type)"); //608:1
            __out.AppendLine(false); //608:57
            __out.Append("    {"); //609:1
            __out.AppendLine(false); //609:6
            __out.Append("        switch (type)"); //610:1
            __out.AppendLine(false); //610:22
            __out.Append("        {"); //611:1
            __out.AppendLine(false); //611:10
            var __loop45_results = 
                (from __loop45_var1 in __Enumerate((model).GetEnumerator()) //612:10
                from Namespace in __Enumerate((__loop45_var1.Namespace).GetEnumerator()) //612:17
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //612:28
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //612:42
                select new { __loop45_var1 = __loop45_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //612:5
            int __loop45_iteration = 0;
            foreach (var __tmp26 in __loop45_results)
            {
                ++__loop45_iteration;
                var __loop45_var1 = __tmp26.__loop45_var1;
                var Namespace = __tmp26.Namespace;
                var Declarations = __tmp26.Declarations;
                var cls = __tmp26.cls;
                if (!cls.IsAbstract) //613:6
                {
                    string __tmp28Line = "            case \""; //614:1
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
                    string __tmp30Line = "\": return (MutableRedSymbol)this."; //614:37
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
                    string __tmp32Line = "();"; //614:88
                    if (__tmp32Line != null) __out.Append(__tmp32Line);
                    __out.AppendLine(false); //614:91
                }
            }
            __out.Append("            default:"); //617:1
            __out.AppendLine(false); //617:21
            __out.Append("                throw new ModelException(\"Unknown type name: \" + type);"); //618:1
            __out.AppendLine(false); //618:72
            __out.Append("        }"); //619:1
            __out.AppendLine(false); //619:10
            __out.Append("    }"); //620:1
            __out.AppendLine(false); //620:6
            var __loop46_results = 
                (from __loop46_var1 in __Enumerate((model).GetEnumerator()) //621:8
                from Namespace in __Enumerate((__loop46_var1.Namespace).GetEnumerator()) //621:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //621:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //621:40
                select new { __loop46_var1 = __loop46_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //621:3
            int __loop46_iteration = 0;
            foreach (var __tmp33 in __loop46_results)
            {
                ++__loop46_iteration;
                var __loop46_var1 = __tmp33.__loop46_var1;
                var Namespace = __tmp33.Namespace;
                var Declarations = __tmp33.Declarations;
                var cls = __tmp33.cls;
                if (!cls.IsAbstract) //622:4
                {
                    __out.AppendLine(true); //623:1
                    __out.Append("    /// <summary>"); //624:1
                    __out.AppendLine(false); //624:18
                    string __tmp35Line = "    /// Creates a new instance of "; //625:1
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
                    string __tmp37Line = "."; //625:53
                    if (__tmp37Line != null) __out.Append(__tmp37Line);
                    __out.AppendLine(false); //625:54
                    __out.Append("    /// </summary>"); //626:1
                    __out.AppendLine(false); //626:19
                    string __tmp39Line = "    public "; //627:1
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
                    string __tmp41Line = " "; //627:47
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
                    string __tmp43Line = "()"; //627:66
                    if (__tmp43Line != null) __out.Append(__tmp43Line);
                    __out.AppendLine(false); //627:68
                    __out.Append("	{"); //628:1
                    __out.AppendLine(false); //628:3
                    string __tmp45Line = "		return ("; //629:1
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
                    string __tmp47Line = ")this.AddSymbol(new "; //629:46
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
                    string __tmp49Line = "());"; //629:96
                    if (__tmp49Line != null) __out.Append(__tmp49Line);
                    __out.AppendLine(false); //629:100
                    __out.Append("	}"); //630:1
                    __out.AppendLine(false); //630:3
                }
            }
            __out.Append("}"); //633:1
            __out.AppendLine(false); //633:2
            __out.AppendLine(true); //634:1
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
