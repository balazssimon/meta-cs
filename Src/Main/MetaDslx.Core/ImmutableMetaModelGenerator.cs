using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core //1:1
{
    using __Hidden_ImmutableMetaModelGenerator_1241823053;
    namespace __Hidden_ImmutableMetaModelGenerator_1241823053
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
            if (result == "" && classKind != ClassKind.ChildBuilder) //66:2
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
            string __tmp9Line = "public interface "; //111:1
            if (__tmp9Line != null) __out.Append(__tmp9Line);
            StringBuilder __tmp10 = new StringBuilder();
            __tmp10.Append(cls.CSharpName(ClassKind.ChildBuilder));
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
            __tmp11.Append(GetAncestors(cls, ClassKind.ChildBuilder));
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
                    __out.AppendLine(false); //111:101
                }
            }
            __out.Append("{"); //112:1
            __out.AppendLine(false); //112:2
            var __loop13_results = 
                (from __loop13_var1 in __Enumerate((cls).GetEnumerator()) //113:11
                from prop in __Enumerate((__loop13_var1.Properties).GetEnumerator()) //113:16
                select new { __loop13_var1 = __loop13_var1, prop = prop}
                ).ToList(); //113:6
            int __loop13_iteration = 0;
            foreach (var __tmp12 in __loop13_results)
            {
                ++__loop13_iteration;
                var __loop13_var1 = __tmp12.__loop13_var1;
                var prop = __tmp12.prop;
                string __tmp13Prefix = "    "; //114:1
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(GenerateChildBuilderProperty(prop));
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
                        __out.AppendLine(false); //114:41
                    }
                }
            }
            __out.Append("}"); //116:1
            __out.AppendLine(false); //116:2
            __out.AppendLine(true); //117:1
            return __out.ToString();
        }

        public string GenerateImmutableProperty(MetaProperty prop) //120:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //121:2
            {
                __out.Append("new "); //122:1
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
            string __tmp3Line = " "; //124:54
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
            string __tmp5Line = " { get; }"; //124:66
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            __out.AppendLine(false); //124:75
            return __out.ToString();
        }

        public string GenerateImmutableField(MetaClass cls, MetaProperty prop) //127:1
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
                    __out.AppendLine(false); //128:54
                }
            }
            string __tmp4Line = "private "; //129:1
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
            string __tmp6Line = " "; //129:62
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
            string __tmp8Line = ";"; //129:87
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //129:88
            return __out.ToString();
        }

        public string GenerateBuilderProperty(MetaProperty prop) //132:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //133:2
            {
                __out.Append("new "); //134:1
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //136:3
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
                string __tmp3Line = " "; //137:52
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
                string __tmp5Line = " { get; set; }"; //137:64
                if (__tmp5Line != null) __out.Append(__tmp5Line);
                __out.AppendLine(false); //137:78
            }
            else //138:3
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
                string __tmp8Line = " "; //139:52
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
                string __tmp10Line = " { get; }"; //139:64
                if (__tmp10Line != null) __out.Append(__tmp10Line);
                __out.AppendLine(false); //139:73
            }
            if (!(prop.Type is MetaCollectionType)) //141:2
            {
                if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //142:3
                {
                    __out.Append("new "); //143:1
                }
                string __tmp12Line = "Func<"; //145:1
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
                string __tmp14Line = "> "; //145:57
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
                string __tmp16Line = "Lazy { get; set; }"; //145:70
                if (__tmp16Line != null) __out.Append(__tmp16Line);
                __out.AppendLine(false); //145:88
            }
            if (prop.Kind == MetaPropertyKind.Containment && (((prop.Type is MetaCollectionType) && (((MetaCollectionType)prop.Type).InnerType is MetaClass)) || (!(prop.Type is MetaCollectionType) && prop.Type is MetaClass))) //147:2
            {
                if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //148:3
                {
                    __out.Append("new "); //149:1
                }
                if (prop.Type is MetaCollectionType) //151:3
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
                    string __tmp19Line = " "; //152:89
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
                    string __tmp21Line = "LazyChild { get; }"; //152:101
                    if (__tmp21Line != null) __out.Append(__tmp21Line);
                    __out.AppendLine(false); //152:119
                }
                else //153:3
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
                    string __tmp24Line = " "; //154:57
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
                    string __tmp26Line = "LazyChild { get; }"; //154:69
                    if (__tmp26Line != null) __out.Append(__tmp26Line);
                    __out.AppendLine(false); //154:87
                }
            }
            return __out.ToString();
        }

        public string GenerateChildBuilderProperty(MetaProperty prop) //159:1
        {
            StringBuilder __out = new StringBuilder();
            if (!(prop.Type is MetaCollectionType)) //160:2
            {
                if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //161:3
                {
                    __out.Append("new "); //162:1
                }
                string __tmp2Line = "Func<"; //164:1
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
                string __tmp4Line = "> "; //164:57
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
                string __tmp6Line = " { set; }"; //164:70
                if (__tmp6Line != null) __out.Append(__tmp6Line);
                __out.AppendLine(false); //164:79
            }
            return __out.ToString();
        }

        public string GenerateBuilderField(MetaClass cls, MetaProperty prop) //168:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "private "; //169:1
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
            string __tmp4Line = " "; //169:60
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
            string __tmp6Line = ";"; //169:85
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            __out.AppendLine(false); //169:86
            return __out.ToString();
        }

        public string GetParameters(MetaFunction op, ClassKind classKind) //172:1
        {
            string result = ""; //173:2
            var __loop14_results = 
                (from __loop14_var1 in __Enumerate((op).GetEnumerator()) //174:7
                from param in __Enumerate((__loop14_var1.Parameters).GetEnumerator()) //174:11
                select new { __loop14_var1 = __loop14_var1, param = param}
                ).ToList(); //174:2
            int __loop14_iteration = 0;
            string delim = ""; //174:29
            foreach (var __tmp1 in __loop14_results)
            {
                ++__loop14_iteration;
                if (__loop14_iteration >= 2) //174:48
                {
                    delim = ", "; //174:48
                }
                var __loop14_var1 = __tmp1.__loop14_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(classKind) + " " + param.Name; //175:3
            }
            return result; //177:2
        }

        public string GetImplParameters(MetaClass cls, MetaOperation op) //180:1
        {
            string result = cls.CSharpFullName(ClassKind.Immutable) + " @this"; //181:2
            string delim = ", "; //182:2
            var __loop15_results = 
                (from __loop15_var1 in __Enumerate((op).GetEnumerator()) //183:7
                from param in __Enumerate((__loop15_var1.Parameters).GetEnumerator()) //183:11
                select new { __loop15_var1 = __loop15_var1, param = param}
                ).ToList(); //183:2
            int __loop15_iteration = 0;
            foreach (var __tmp1 in __loop15_results)
            {
                ++__loop15_iteration;
                var __loop15_var1 = __tmp1.__loop15_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(ClassKind.Immutable) + " " + param.Name; //184:3
            }
            return result; //186:2
        }

        public string GetImplParameters(MetaEnum enm, MetaOperation op) //189:1
        {
            string result = enm.CSharpFullName(ClassKind.Immutable) + " @this"; //190:2
            string delim = ", "; //191:2
            var __loop16_results = 
                (from __loop16_var1 in __Enumerate((op).GetEnumerator()) //192:7
                from param in __Enumerate((__loop16_var1.Parameters).GetEnumerator()) //192:11
                select new { __loop16_var1 = __loop16_var1, param = param}
                ).ToList(); //192:2
            int __loop16_iteration = 0;
            foreach (var __tmp1 in __loop16_results)
            {
                ++__loop16_iteration;
                var __loop16_var1 = __tmp1.__loop16_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(ClassKind.Immutable) + " " + param.Name; //193:3
            }
            return result; //195:2
        }

        public string GetEnumImplParameters(MetaEnum enm, MetaOperation op) //198:1
        {
            string result = "this " + enm.CSharpFullName(ClassKind.Immutable) + " @this"; //199:2
            string delim = ", "; //200:2
            var __loop17_results = 
                (from __loop17_var1 in __Enumerate((op).GetEnumerator()) //201:7
                from param in __Enumerate((__loop17_var1.Parameters).GetEnumerator()) //201:11
                select new { __loop17_var1 = __loop17_var1, param = param}
                ).ToList(); //201:2
            int __loop17_iteration = 0;
            foreach (var __tmp1 in __loop17_results)
            {
                ++__loop17_iteration;
                var __loop17_var1 = __tmp1.__loop17_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(ClassKind.Immutable) + " " + param.Name; //202:3
            }
            return result; //204:2
        }

        public string GetEnumImplCallParameterNames(MetaOperation op) //207:1
        {
            string result = "@this"; //208:2
            string delim = ", "; //209:2
            var __loop18_results = 
                (from __loop18_var1 in __Enumerate((op).GetEnumerator()) //210:7
                from param in __Enumerate((__loop18_var1.Parameters).GetEnumerator()) //210:11
                select new { __loop18_var1 = __loop18_var1, param = param}
                ).ToList(); //210:2
            int __loop18_iteration = 0;
            foreach (var __tmp1 in __loop18_results)
            {
                ++__loop18_iteration;
                var __loop18_var1 = __tmp1.__loop18_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //211:3
            }
            return result; //213:2
        }

        public string GetImplCallParameterNames(MetaOperation op) //216:1
        {
            string result = "this"; //217:2
            string delim = ", "; //218:2
            var __loop19_results = 
                (from __loop19_var1 in __Enumerate((op).GetEnumerator()) //219:7
                from param in __Enumerate((__loop19_var1.Parameters).GetEnumerator()) //219:11
                select new { __loop19_var1 = __loop19_var1, param = param}
                ).ToList(); //219:2
            int __loop19_iteration = 0;
            foreach (var __tmp1 in __loop19_results)
            {
                ++__loop19_iteration;
                var __loop19_var1 = __tmp1.__loop19_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //220:3
            }
            return result; //222:2
        }

        public string GenerateOperation(MetaOperation op) //225:1
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
            string __tmp3Line = " "; //226:58
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
            string __tmp5Line = "("; //226:68
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
            string __tmp7Line = ");"; //226:109
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //226:111
            return __out.ToString();
        }

        public string GenerateImmutableInterfaceImpl(MetaModel model, MetaClass cls) //229:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal class "; //230:1
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
            string __tmp4Line = " : global::MetaDslx.Core.Immutable.ImmutableRedSymbolBase, "; //230:57
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
                    __out.AppendLine(false); //230:157
                }
            }
            __out.Append("{"); //231:1
            __out.AppendLine(false); //231:2
            var __loop20_results = 
                (from __loop20_var1 in __Enumerate((cls).GetEnumerator()) //232:11
                from prop in __Enumerate((__loop20_var1.GetAllProperties()).GetEnumerator()) //232:16
                select new { __loop20_var1 = __loop20_var1, prop = prop}
                ).ToList(); //232:6
            int __loop20_iteration = 0;
            foreach (var __tmp6 in __loop20_results)
            {
                ++__loop20_iteration;
                var __loop20_var1 = __tmp6.__loop20_var1;
                var prop = __tmp6.prop;
                string __tmp7Prefix = "    "; //233:1
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
                        __out.AppendLine(false); //233:40
                    }
                }
            }
            __out.AppendLine(true); //235:1
            string __tmp10Line = "    internal "; //236:1
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
            string __tmp12Line = "(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableRedModelPart model)"; //236:36
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //236:142
            __out.Append("		: base(id, model)"); //237:1
            __out.AppendLine(false); //237:20
            __out.Append("    {"); //238:1
            __out.AppendLine(false); //238:6
            __out.Append("    }"); //239:1
            __out.AppendLine(false); //239:6
            __out.AppendLine(true); //240:1
            __out.Append("    public override object MMetaModel"); //241:1
            __out.AppendLine(false); //241:38
            __out.Append("    {"); //242:1
            __out.AppendLine(false); //242:6
            string __tmp14Line = "        get { return null;/*"; //243:1
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
            string __tmp16Line = ";*/ }"; //243:65
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            __out.AppendLine(false); //243:70
            __out.Append("    }"); //244:1
            __out.AppendLine(false); //244:6
            __out.AppendLine(true); //245:1
            __out.Append("    public override object MMetaClass"); //246:1
            __out.AppendLine(false); //246:38
            __out.Append("    {"); //247:1
            __out.AppendLine(false); //247:6
            string __tmp18Line = "        get { return null; /*"; //248:1
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
            string __tmp20Line = ";*/ }"; //248:60
            if (__tmp20Line != null) __out.Append(__tmp20Line);
            __out.AppendLine(false); //248:65
            __out.Append("    }"); //249:1
            __out.AppendLine(false); //249:6
            __out.AppendLine(true); //250:1
            var __loop21_results = 
                (from __loop21_var1 in __Enumerate((cls).GetEnumerator()) //251:11
                from prop in __Enumerate((__loop21_var1.GetAllProperties()).GetEnumerator()) //251:16
                select new { __loop21_var1 = __loop21_var1, prop = prop}
                ).ToList(); //251:6
            int __loop21_iteration = 0;
            foreach (var __tmp21 in __loop21_results)
            {
                ++__loop21_iteration;
                var __loop21_var1 = __tmp21.__loop21_var1;
                var prop = __tmp21.prop;
                string __tmp22Prefix = "    "; //252:1
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
                        __out.AppendLine(false); //252:54
                    }
                }
            }
            var __loop22_results = 
                (from __loop22_var1 in __Enumerate((cls).GetEnumerator()) //254:11
                from op in __Enumerate((__loop22_var1.GetAllOperations()).GetEnumerator()) //254:16
                select new { __loop22_var1 = __loop22_var1, op = op}
                ).ToList(); //254:6
            int __loop22_iteration = 0;
            foreach (var __tmp24 in __loop22_results)
            {
                ++__loop22_iteration;
                var __loop22_var1 = __tmp24.__loop22_var1;
                var op = __tmp24.op;
                string __tmp25Prefix = "    "; //255:1
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
                        __out.AppendLine(false); //255:39
                    }
                }
            }
            __out.Append("}"); //257:1
            __out.AppendLine(false); //257:2
            __out.AppendLine(true); //258:1
            return __out.ToString();
        }

        public string GenerateBuilderInterfaceImpl(MetaModel model, MetaClass cls) //261:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal class "; //262:1
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
            string __tmp4Line = " : global::MetaDslx.Core.Immutable.MutableRedSymbolBase, "; //262:55
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
                    __out.AppendLine(false); //262:151
                }
            }
            __out.Append("{"); //263:1
            __out.AppendLine(false); //263:2
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((cls).GetEnumerator()) //264:11
                from prop in __Enumerate((__loop23_var1.GetAllProperties()).GetEnumerator()) //264:16
                where prop.Type is MetaCollectionType //264:40
                select new { __loop23_var1 = __loop23_var1, prop = prop}
                ).ToList(); //264:6
            int __loop23_iteration = 0;
            foreach (var __tmp6 in __loop23_results)
            {
                ++__loop23_iteration;
                var __loop23_var1 = __tmp6.__loop23_var1;
                var prop = __tmp6.prop;
                string __tmp7Prefix = "    "; //265:1
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
                        __out.AppendLine(false); //265:38
                    }
                }
            }
            __out.AppendLine(true); //267:1
            string __tmp10Line = "    internal "; //268:1
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
            string __tmp12Line = "(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableRedModelPart model)"; //268:53
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //268:157
            __out.Append("		: base(id, model)"); //269:1
            __out.AppendLine(false); //269:20
            __out.Append("    {"); //270:1
            __out.AppendLine(false); //270:6
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((cls).GetEnumerator()) //271:9
                from prop in __Enumerate((__loop24_var1.GetAllProperties()).GetEnumerator()) //271:14
                select new { __loop24_var1 = __loop24_var1, prop = prop}
                ).ToList(); //271:4
            int __loop24_iteration = 0;
            foreach (var __tmp13 in __loop24_results)
            {
                ++__loop24_iteration;
                var __loop24_var1 = __tmp13.__loop24_var1;
                var prop = __tmp13.prop;
                string __tmp15Line = "        this.MAttachProperty("; //272:1
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
                string __tmp17Line = ");"; //272:82
                if (__tmp17Line != null) __out.Append(__tmp17Line);
                __out.AppendLine(false); //272:84
            }
            __out.Append("        this.MInit();"); //274:1
            __out.AppendLine(false); //274:22
            __out.Append("    }"); //275:1
            __out.AppendLine(false); //275:6
            __out.AppendLine(true); //276:1
            __out.Append("    protected override void MDoInit()"); //277:1
            __out.AppendLine(false); //277:38
            __out.Append("    {"); //278:1
            __out.AppendLine(false); //278:6
            string __tmp18Prefix = "		"; //279:1
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
            string __tmp20Line = "ImplementationProvider.Implementation."; //279:15
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
            string __tmp22Line = "(this);"; //279:71
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            __out.AppendLine(false); //279:78
            __out.Append("    }"); //280:1
            __out.AppendLine(false); //280:6
            __out.AppendLine(true); //281:1
            __out.Append("    public override object MMetaModel"); //282:1
            __out.AppendLine(false); //282:38
            __out.Append("    {"); //283:1
            __out.AppendLine(false); //283:6
            string __tmp24Line = "        get { return null;/*"; //284:1
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
            string __tmp26Line = ";*/ }"; //284:65
            if (__tmp26Line != null) __out.Append(__tmp26Line);
            __out.AppendLine(false); //284:70
            __out.Append("    }"); //285:1
            __out.AppendLine(false); //285:6
            __out.AppendLine(true); //286:1
            __out.Append("    public override object MMetaClass"); //287:1
            __out.AppendLine(false); //287:38
            __out.Append("    {"); //288:1
            __out.AppendLine(false); //288:6
            string __tmp28Line = "        get { return null;/*"; //289:1
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
            string __tmp30Line = ";*/ }"; //289:59
            if (__tmp30Line != null) __out.Append(__tmp30Line);
            __out.AppendLine(false); //289:64
            __out.Append("    }"); //290:1
            __out.AppendLine(false); //290:6
            __out.AppendLine(true); //291:1
            var __loop25_results = 
                (from __loop25_var1 in __Enumerate((cls).GetEnumerator()) //292:11
                from prop in __Enumerate((__loop25_var1.GetAllProperties()).GetEnumerator()) //292:16
                select new { __loop25_var1 = __loop25_var1, prop = prop}
                ).ToList(); //292:6
            int __loop25_iteration = 0;
            foreach (var __tmp31 in __loop25_results)
            {
                ++__loop25_iteration;
                var __loop25_var1 = __tmp31.__loop25_var1;
                var prop = __tmp31.prop;
                string __tmp32Prefix = "    "; //293:1
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
                        __out.AppendLine(false); //293:52
                    }
                }
            }
            __out.Append("}"); //295:1
            __out.AppendLine(false); //295:2
            __out.AppendLine(true); //296:1
            string __tmp35Line = "public class "; //297:1
            if (__tmp35Line != null) __out.Append(__tmp35Line);
            StringBuilder __tmp36 = new StringBuilder();
            __tmp36.Append(cls.CSharpImplName(ClassKind.ChildBuilder));
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
            string __tmp37Line = " : global::MetaDslx.Core.Immutable.LazyChildBuilderBase, "; //297:58
            if (__tmp37Line != null) __out.Append(__tmp37Line);
            StringBuilder __tmp38 = new StringBuilder();
            __tmp38.Append(cls.CSharpFullName(ClassKind.ChildBuilder));
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
                    __out.AppendLine(false); //297:159
                }
            }
            __out.Append("{"); //298:1
            __out.AppendLine(false); //298:2
            string __tmp40Line = "    internal "; //299:1
            if (__tmp40Line != null) __out.Append(__tmp40Line);
            StringBuilder __tmp41 = new StringBuilder();
            __tmp41.Append(cls.CSharpImplName(ClassKind.ChildBuilder));
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
            string __tmp42Line = "(global::MetaDslx.Core.Immutable.MutableRedSymbolBase parent, global::MetaDslx.Core.Immutable.ModelProperty property)"; //299:58
            if (__tmp42Line != null) __out.Append(__tmp42Line);
            __out.AppendLine(false); //299:175
            __out.Append("		: base(parent, property)"); //300:1
            __out.AppendLine(false); //300:27
            __out.Append("    {"); //301:1
            __out.AppendLine(false); //301:6
            __out.Append("    }"); //302:1
            __out.AppendLine(false); //302:6
            __out.AppendLine(true); //303:1
            var __loop26_results = 
                (from __loop26_var1 in __Enumerate((cls).GetEnumerator()) //304:11
                from prop in __Enumerate((__loop26_var1.GetAllProperties()).GetEnumerator()) //304:16
                select new { __loop26_var1 = __loop26_var1, prop = prop}
                ).ToList(); //304:6
            int __loop26_iteration = 0;
            foreach (var __tmp43 in __loop26_results)
            {
                ++__loop26_iteration;
                var __loop26_var1 = __tmp43.__loop26_var1;
                var prop = __tmp43.prop;
                string __tmp44Prefix = "    "; //305:1
                StringBuilder __tmp45 = new StringBuilder();
                __tmp45.Append(GenerateChildBuilderPropertyImpl(model, cls, prop));
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
                        __out.AppendLine(false); //305:57
                    }
                }
            }
            __out.Append("}"); //307:1
            __out.AppendLine(false); //307:2
            __out.AppendLine(true); //308:1
            return __out.ToString();
        }

        public string GeneratePropertyDeclaration(MetaModel model, MetaClass cls, MetaProperty prop) //311:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class == cls) //312:2
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
                        __out.AppendLine(false); //313:28
                    }
                }
                if (prop.Kind == MetaPropertyKind.Containment) //314:2
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
                            __out.AppendLine(false); //315:27
                        }
                    }
                }
                if (prop.Kind != MetaPropertyKind.Normal && prop.Kind != MetaPropertyKind.Containment) //317:2
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
                            __out.AppendLine(false); //318:24
                        }
                    }
                }
                var __loop27_results = 
                    (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //320:7
                    select new { p = p}
                    ).ToList(); //320:2
                int __loop27_iteration = 0;
                foreach (var __tmp7 in __loop27_results)
                {
                    ++__loop27_iteration;
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
                            __out.AppendLine(false); //321:92
                        }
                    }
                }
                var __loop28_results = 
                    (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //323:7
                    select new { p = p}
                    ).ToList(); //323:2
                int __loop28_iteration = 0;
                foreach (var __tmp14 in __loop28_results)
                {
                    ++__loop28_iteration;
                    var p = __tmp14.p;
                    if (cls.GetAllSuperClasses(true).Contains(p.Class)) //324:3
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
                                __out.AppendLine(false); //325:91
                            }
                        }
                    }
                    else //326:3
                    {
                        string __tmp22Line = "// ERROR: subsetted property '"; //327:1
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
                        string __tmp24Line = "' must be a property of an ancestor class"; //327:61
                        if (__tmp24Line != null) __out.Append(__tmp24Line);
                        __out.AppendLine(false); //327:102
                    }
                }
                var __loop29_results = 
                    (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //330:7
                    select new { p = p}
                    ).ToList(); //330:2
                int __loop29_iteration = 0;
                foreach (var __tmp25 in __loop29_results)
                {
                    ++__loop29_iteration;
                    var p = __tmp25.p;
                    if (cls.GetAllSuperClasses(true).Contains(p.Class)) //331:3
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
                                __out.AppendLine(false); //332:93
                            }
                        }
                    }
                    else //333:3
                    {
                        string __tmp33Line = "// ERROR: redefined property '"; //334:1
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
                        string __tmp35Line = "' must be a property of an ancestor class"; //334:61
                        if (__tmp35Line != null) __out.Append(__tmp35Line);
                        __out.AppendLine(false); //334:102
                    }
                }
                if (prop.Type is MetaCollectionType) //337:2
                {
                    MetaCollectionType collType = (MetaCollectionType)prop.Type; //338:3
                    string __tmp37Line = "public static readonly global::MetaDslx.Core.Immutable.ModelProperty "; //339:1
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
                    string __tmp39Line = "Property ="; //339:81
                    if (__tmp39Line != null) __out.Append(__tmp39Line);
                    __out.AppendLine(false); //339:91
                    string __tmp41Line = "    global::MetaDslx.Core.Immutable.ModelProperty.Register(\""; //340:1
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
                    string __tmp43Line = "\", typeof("; //340:72
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
                    string __tmp45Line = "."; //340:123
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
                    string __tmp47Line = "),"; //340:149
                    if (__tmp47Line != null) __out.Append(__tmp47Line);
                    __out.AppendLine(false); //340:151
                    string __tmp49Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //341:1
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
                    string __tmp51Line = "), typeof("; //341:136
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
                    string __tmp53Line = "), typeof("; //341:199
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
                    string __tmp55Line = ")),"; //341:257
                    if (__tmp55Line != null) __out.Append(__tmp55Line);
                    __out.AppendLine(false); //341:260
                    string __tmp57Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //342:1
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
                    string __tmp59Line = "), typeof("; //342:134
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
                    string __tmp61Line = "), typeof("; //342:195
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
                    string __tmp63Line = ")));"; //342:251
                    if (__tmp63Line != null) __out.Append(__tmp63Line);
                    __out.AppendLine(false); //342:255
                }
                else //343:2
                {
                    string __tmp65Line = "public static readonly global::MetaDslx.Core.Immutable.ModelProperty "; //344:1
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
                    string __tmp67Line = "Property ="; //344:81
                    if (__tmp67Line != null) __out.Append(__tmp67Line);
                    __out.AppendLine(false); //344:91
                    string __tmp69Line = "    global::MetaDslx.Core.Immutable.ModelProperty.Register(\""; //345:1
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
                    string __tmp71Line = "\", typeof("; //345:72
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
                    string __tmp73Line = "."; //345:123
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
                    string __tmp75Line = "),"; //345:149
                    if (__tmp75Line != null) __out.Append(__tmp75Line);
                    __out.AppendLine(false); //345:151
                    string __tmp77Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //346:1
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
                    string __tmp79Line = "), null, typeof("; //346:127
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
                    string __tmp81Line = ")),"; //346:191
                    if (__tmp81Line != null) __out.Append(__tmp81Line);
                    __out.AppendLine(false); //346:194
                    string __tmp83Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //347:1
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
                    string __tmp85Line = "), null, typeof("; //347:125
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
                    string __tmp87Line = ")));"; //347:187
                    if (__tmp87Line != null) __out.Append(__tmp87Line);
                    __out.AppendLine(false); //347:191
                }
            }
            __out.AppendLine(true); //350:1
            return __out.ToString();
        }

        public string GenerateImmutablePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //353:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //354:1
            if (cls.GetAllFinalProperties().Contains(prop)) //355:2
            {
                string __tmp2Line = "public "; //356:1
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
                string __tmp4Line = " "; //356:61
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
                        __out.AppendLine(false); //356:73
                    }
                }
            }
            else //357:2
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
                        __out.AppendLine(false); //358:54
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
                string __tmp10Line = " "; //359:54
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
                string __tmp12Line = "."; //359:103
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
                        __out.AppendLine(false); //359:115
                    }
                }
            }
            __out.Append("{"); //361:1
            __out.AppendLine(false); //361:2
            if (prop.Type is MetaCollectionType) //362:6
            {
                string __tmp15Line = "    get { return this.GetList<"; //363:1
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
                string __tmp17Line = ">("; //363:116
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
                string __tmp19Line = ", ref "; //363:170
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
                string __tmp21Line = "); }"; //363:200
                if (__tmp21Line != null) __out.Append(__tmp21Line);
                __out.AppendLine(false); //363:204
            }
            else if (prop.Type.IsReferenceType()) //364:3
            {
                string __tmp23Line = "    get { return this.GetReference<"; //365:1
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
                string __tmp25Line = ">("; //365:89
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
                string __tmp27Line = ", ref "; //365:143
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
                string __tmp29Line = "); }"; //365:173
                if (__tmp29Line != null) __out.Append(__tmp29Line);
                __out.AppendLine(false); //365:177
            }
            else //366:3
            {
                string __tmp31Line = "    get { return this.GetValue<"; //367:1
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
                string __tmp33Line = ">("; //367:85
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
                string __tmp35Line = ", ref "; //367:139
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
                string __tmp37Line = "); }"; //367:169
                if (__tmp37Line != null) __out.Append(__tmp37Line);
                __out.AppendLine(false); //367:173
            }
            __out.Append("}"); //369:1
            __out.AppendLine(false); //369:2
            return __out.ToString();
        }

        public string GenerateBuilderPropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //372:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //373:1
            if (cls.GetAllFinalProperties().Contains(prop)) //374:2
            {
                string __tmp2Line = "public "; //375:1
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
                string __tmp4Line = " "; //375:59
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
                        __out.AppendLine(false); //375:71
                    }
                }
            }
            else //376:2
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
                        __out.AppendLine(false); //377:54
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
                string __tmp10Line = " "; //378:52
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
                string __tmp12Line = "."; //378:99
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
                        __out.AppendLine(false); //378:111
                    }
                }
            }
            __out.Append("{"); //380:1
            __out.AppendLine(false); //380:2
            if (prop.Type is MetaCollectionType) //381:6
            {
                string __tmp15Line = "    get { return this.GetList<"; //382:1
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
                string __tmp17Line = ">("; //382:114
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
                string __tmp19Line = ", ref "; //382:166
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
                string __tmp21Line = "); }"; //382:196
                if (__tmp21Line != null) __out.Append(__tmp21Line);
                __out.AppendLine(false); //382:200
            }
            else if (prop.Type.IsReferenceType()) //383:3
            {
                string __tmp23Line = "    get { return this.GetReference<"; //384:1
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
                string __tmp25Line = ">("; //384:87
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
                string __tmp27Line = "); }"; //384:139
                if (__tmp27Line != null) __out.Append(__tmp27Line);
                __out.AppendLine(false); //384:143
            }
            else //385:3
            {
                string __tmp29Line = "    get { return this.GetValue<"; //386:1
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
                string __tmp31Line = ">("; //386:83
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
                string __tmp33Line = "); }"; //386:135
                if (__tmp33Line != null) __out.Append(__tmp33Line);
                __out.AppendLine(false); //386:139
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //388:3
            {
                if (prop.Type.IsReferenceType()) //389:4
                {
                    string __tmp35Line = "    set { this.SetReference<"; //390:1
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
                    string __tmp37Line = ">("; //390:80
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
                    string __tmp39Line = ", value); }"; //390:132
                    if (__tmp39Line != null) __out.Append(__tmp39Line);
                    __out.AppendLine(false); //390:143
                }
                else //391:4
                {
                    string __tmp41Line = "    set { this.SetValue<"; //392:1
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
                    string __tmp43Line = ">("; //392:76
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
                    string __tmp45Line = ", value); }"; //392:128
                    if (__tmp45Line != null) __out.Append(__tmp45Line);
                    __out.AppendLine(false); //392:139
                }
            }
            __out.Append("}"); //395:1
            __out.AppendLine(false); //395:2
            if (!(prop.Type is MetaCollectionType)) //396:2
            {
                __out.AppendLine(true); //397:1
                if (cls.GetAllFinalProperties().Contains(prop)) //398:3
                {
                    string __tmp47Line = "public Func<"; //399:1
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
                    string __tmp49Line = "> "; //399:64
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
                    string __tmp51Line = "Lazy"; //399:77
                    if (__tmp51Line != null) __out.Append(__tmp51Line);
                    __out.AppendLine(false); //399:81
                }
                else //400:3
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
                            __out.AppendLine(false); //401:54
                        }
                    }
                    string __tmp55Line = "Func<"; //402:1
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
                    string __tmp57Line = "> "; //402:57
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
                    string __tmp59Line = "."; //402:105
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
                    string __tmp61Line = "Lazy"; //402:117
                    if (__tmp61Line != null) __out.Append(__tmp61Line);
                    __out.AppendLine(false); //402:121
                }
                __out.Append("{"); //404:1
                __out.AppendLine(false); //404:2
                if (prop.Type.IsReferenceType()) //405:4
                {
                    string __tmp63Line = "    get { return this.GetLazyReference<"; //406:1
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
                    string __tmp65Line = ">("; //406:91
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
                    string __tmp67Line = "); }"; //406:143
                    if (__tmp67Line != null) __out.Append(__tmp67Line);
                    __out.AppendLine(false); //406:147
                    string __tmp69Line = "    set { this.SetLazyReference("; //407:1
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
                    string __tmp71Line = ", value); }"; //407:83
                    if (__tmp71Line != null) __out.Append(__tmp71Line);
                    __out.AppendLine(false); //407:94
                }
                else //408:4
                {
                    string __tmp73Line = "    get { return this.GetLazyValue<"; //409:1
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
                    string __tmp75Line = ">("; //409:87
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
                    string __tmp77Line = "); }"; //409:139
                    if (__tmp77Line != null) __out.Append(__tmp77Line);
                    __out.AppendLine(false); //409:143
                    string __tmp79Line = "    set { this.SetLazyValue("; //410:1
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
                    string __tmp81Line = ", value); }"; //410:79
                    if (__tmp81Line != null) __out.Append(__tmp81Line);
                    __out.AppendLine(false); //410:90
                }
                __out.Append("}"); //412:1
                __out.AppendLine(false); //412:2
            }
            if (prop.Kind == MetaPropertyKind.Containment && (((prop.Type is MetaCollectionType) && (((MetaCollectionType)prop.Type).InnerType is MetaClass)) || (!(prop.Type is MetaCollectionType) && prop.Type is MetaClass))) //414:2
            {
                __out.AppendLine(true); //415:1
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
                        __out.AppendLine(false); //416:54
                    }
                }
                if (cls.GetAllFinalProperties().Contains(prop)) //417:3
                {
                    if (prop.Type is MetaCollectionType) //418:4
                    {
                        string __tmp85Line = "public "; //419:1
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
                        string __tmp87Line = " "; //419:96
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
                        string __tmp89Line = "LazyChild"; //419:108
                        if (__tmp89Line != null) __out.Append(__tmp89Line);
                        __out.AppendLine(false); //419:117
                    }
                    else //420:4
                    {
                        string __tmp91Line = "public "; //421:1
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
                        string __tmp93Line = " "; //421:64
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
                        string __tmp95Line = "LazyChild"; //421:76
                        if (__tmp95Line != null) __out.Append(__tmp95Line);
                        __out.AppendLine(false); //421:85
                    }
                }
                else //423:3
                {
                    if (prop.Type is MetaCollectionType) //424:4
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
                        string __tmp98Line = " "; //425:89
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
                        string __tmp100Line = "."; //425:136
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
                        string __tmp102Line = "LazyChild"; //425:148
                        if (__tmp102Line != null) __out.Append(__tmp102Line);
                        __out.AppendLine(false); //425:157
                    }
                    else //426:4
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
                        string __tmp105Line = " "; //427:57
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
                        string __tmp107Line = "."; //427:104
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
                        string __tmp109Line = "LazyChild"; //427:116
                        if (__tmp109Line != null) __out.Append(__tmp109Line);
                        __out.AppendLine(false); //427:125
                    }
                }
                if (prop.Type is MetaCollectionType) //430:4
                {
                    __out.Append("{"); //431:1
                    __out.AppendLine(false); //431:2
                    string __tmp111Line = "    get { return new "; //432:1
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
                    string __tmp113Line = "Impl(this, "; //432:117
                    if (__tmp113Line != null) __out.Append(__tmp113Line);
                    StringBuilder __tmp114 = new StringBuilder();
                    __tmp114.Append(prop.CSharpFullDescriptorName(ClassKind.Builder));
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
                    string __tmp115Line = "); }"; //432:178
                    if (__tmp115Line != null) __out.Append(__tmp115Line);
                    __out.AppendLine(false); //432:182
                    __out.Append("}"); //433:1
                    __out.AppendLine(false); //433:2
                }
                else //434:4
                {
                    __out.Append("{"); //435:1
                    __out.AppendLine(false); //435:2
                    string __tmp117Line = "    get { return new "; //436:1
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
                    string __tmp119Line = "Impl(this, "; //436:85
                    if (__tmp119Line != null) __out.Append(__tmp119Line);
                    StringBuilder __tmp120 = new StringBuilder();
                    __tmp120.Append(prop.CSharpFullDescriptorName(ClassKind.Builder));
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
                    string __tmp121Line = "); }"; //436:146
                    if (__tmp121Line != null) __out.Append(__tmp121Line);
                    __out.AppendLine(false); //436:150
                    __out.Append("}"); //437:1
                    __out.AppendLine(false); //437:2
                }
            }
            return __out.ToString();
        }

        public string GenerateChildBuilderPropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //442:1
        {
            StringBuilder __out = new StringBuilder();
            if (!(prop.Type is MetaCollectionType)) //443:2
            {
                __out.AppendLine(true); //444:1
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
                        __out.AppendLine(false); //445:54
                    }
                }
                if (cls.GetAllFinalProperties().Contains(prop)) //446:3
                {
                    string __tmp4Line = "public Func<"; //447:1
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
                    string __tmp6Line = "> "; //447:64
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
                            __out.AppendLine(false); //447:77
                        }
                    }
                }
                else //448:3
                {
                    string __tmp9Line = "Func<"; //449:1
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
                    string __tmp11Line = "> "; //449:57
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
                    string __tmp13Line = "."; //449:110
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
                            __out.AppendLine(false); //449:122
                        }
                    }
                }
                __out.Append("{"); //451:1
                __out.AppendLine(false); //451:2
                if (prop.Type.IsReferenceType()) //452:4
                {
                    string __tmp16Line = "    set { this.MParent.MChildLazyAdd(this.MProperty, "; //453:1
                    if (__tmp16Line != null) __out.Append(__tmp16Line);
                    StringBuilder __tmp17 = new StringBuilder();
                    __tmp17.Append(prop.CSharpFullDescriptorName(ClassKind.Builder));
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
                    string __tmp18Line = ", value); }"; //453:104
                    if (__tmp18Line != null) __out.Append(__tmp18Line);
                    __out.AppendLine(false); //453:115
                }
                else //454:4
                {
                    string __tmp20Line = "    set { this.MParent.MChildLazyAdd(this.MProperty, "; //455:1
                    if (__tmp20Line != null) __out.Append(__tmp20Line);
                    StringBuilder __tmp21 = new StringBuilder();
                    __tmp21.Append(prop.CSharpFullDescriptorName(ClassKind.Builder));
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
                    string __tmp22Line = ", () => value); }"; //455:104
                    if (__tmp22Line != null) __out.Append(__tmp22Line);
                    __out.AppendLine(false); //455:121
                }
                __out.Append("}"); //457:1
                __out.AppendLine(false); //457:2
            }
            return __out.ToString();
        }

        public string GetReturn(MetaOperation op) //461:1
        {
            if (op.ReturnType.CSharpName() == "void") //462:5
            {
                return ""; //463:3
            }
            else //464:2
            {
                return "return "; //465:3
            }
        }

        public string GenerateOperationImpl(MetaModel model, MetaOperation op) //469:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //470:1
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
            string __tmp3Line = " "; //471:58
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
            string __tmp5Line = "."; //471:106
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
            string __tmp7Line = "("; //471:116
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
            string __tmp9Line = ")"; //471:157
            if (__tmp9Line != null) __out.Append(__tmp9Line);
            __out.AppendLine(false); //471:158
            __out.Append("{"); //472:1
            __out.AppendLine(false); //472:2
            string __tmp10Prefix = "    "; //473:1
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
            string __tmp13Line = "."; //473:77
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
            string __tmp15Line = "_"; //473:102
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
            string __tmp17Line = "("; //473:112
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
            string __tmp19Line = ");"; //473:144
            if (__tmp19Line != null) __out.Append(__tmp19Line);
            __out.AppendLine(false); //473:146
            __out.Append("}"); //474:1
            __out.AppendLine(false); //474:2
            return __out.ToString();
        }

        public string GetSuperClasses(MetaClass cls) //477:1
        {
            string result = ""; //478:2
            var __loop30_results = 
                (from __loop30_var1 in __Enumerate((cls).GetEnumerator()) //479:10
                from sup in __Enumerate((__loop30_var1.SuperClasses).GetEnumerator()) //479:15
                select new { __loop30_var1 = __loop30_var1, sup = sup}
                ).ToList(); //479:5
            int __loop30_iteration = 0;
            string delim = ""; //479:33
            foreach (var __tmp1 in __loop30_results)
            {
                ++__loop30_iteration;
                if (__loop30_iteration >= 2) //479:52
                {
                    delim = ", "; //479:52
                }
                var __loop30_var1 = __tmp1.__loop30_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpFullName(); //480:3
            }
            return result; //482:2
        }

        public string GetAllSuperClasses(MetaClass cls) //485:1
        {
            string result = ""; //486:2
            var __loop31_results = 
                (from __loop31_var1 in __Enumerate((cls).GetEnumerator()) //487:10
                from sup in __Enumerate((__loop31_var1.GetAllSuperClasses(false)).GetEnumerator()) //487:15
                select new { __loop31_var1 = __loop31_var1, sup = sup}
                ).ToList(); //487:5
            int __loop31_iteration = 0;
            string delim = ""; //487:46
            foreach (var __tmp1 in __loop31_results)
            {
                ++__loop31_iteration;
                if (__loop31_iteration >= 2) //487:65
                {
                    delim = ", "; //487:65
                }
                var __loop31_var1 = __tmp1.__loop31_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpFullName(); //488:3
            }
            return result; //490:2
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //493:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "public static class "; //494:1
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
                    __out.AppendLine(false); //494:51
                }
            }
            __out.Append("{"); //495:1
            __out.AppendLine(false); //495:2
            __out.Append("	private static global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty> properties = new global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty>();"); //496:1
            __out.AppendLine(false); //496:210
            __out.AppendLine(true); //497:1
            string __tmp5Line = "    static "; //498:1
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
            string __tmp7Line = "()"; //498:42
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //498:44
            __out.Append("    {"); //499:1
            __out.AppendLine(false); //499:6
            var __loop32_results = 
                (from __loop32_var1 in __Enumerate((model).GetEnumerator()) //500:11
                from Namespace in __Enumerate((__loop32_var1.Namespace).GetEnumerator()) //500:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //500:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //500:43
                from prop in __Enumerate((cls.Properties).GetEnumerator()) //500:66
                select new { __loop32_var1 = __loop32_var1, Namespace = Namespace, Declarations = Declarations, cls = cls, prop = prop}
                ).ToList(); //500:6
            int __loop32_iteration = 0;
            foreach (var __tmp8 in __loop32_results)
            {
                ++__loop32_iteration;
                var __loop32_var1 = __tmp8.__loop32_var1;
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
            __out.AppendLine(true); //503:1
            __out.Append("        foreach (var property in properties)"); //504:1
            __out.AppendLine(false); //504:45
            __out.Append("        {"); //505:1
            __out.AppendLine(false); //505:10
            __out.Append("            property.Init();"); //506:1
            __out.AppendLine(false); //506:29
            __out.Append("        }"); //507:1
            __out.AppendLine(false); //507:10
            __out.Append("    }"); //508:1
            __out.AppendLine(false); //508:6
            __out.AppendLine(true); //509:1
            __out.Append("    public static void Init()"); //510:1
            __out.AppendLine(false); //510:30
            __out.Append("    {"); //511:1
            __out.AppendLine(false); //511:6
            __out.Append("    }"); //513:1
            __out.AppendLine(false); //513:6
            __out.AppendLine(true); //514:1
            string __tmp16Line = "	public const string Uri = \""; //515:1
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
            string __tmp18Line = "\";"; //515:40
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //515:42
            __out.AppendLine(true); //516:1
            var __loop33_results = 
                (from __loop33_var1 in __Enumerate((model).GetEnumerator()) //517:11
                from Namespace in __Enumerate((__loop33_var1.Namespace).GetEnumerator()) //517:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //517:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //517:43
                select new { __loop33_var1 = __loop33_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //517:6
            int __loop33_iteration = 0;
            foreach (var __tmp19 in __loop33_results)
            {
                ++__loop33_iteration;
                var __loop33_var1 = __tmp19.__loop33_var1;
                var Namespace = __tmp19.Namespace;
                var Declarations = __tmp19.Declarations;
                var cls = __tmp19.cls;
                string __tmp20Prefix = "    "; //518:1
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
                        __out.AppendLine(false); //518:34
                    }
                }
            }
            __out.Append("}"); //520:1
            __out.AppendLine(false); //520:2
            __out.AppendLine(true); //521:1
            return __out.ToString();
        }

        public string GenerateMetaModelClass(MetaClass cls) //525:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //526:1
            string __tmp2Line = "public static class "; //527:1
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
                    __out.AppendLine(false); //527:39
                }
            }
            __out.Append("{"); //528:1
            __out.AppendLine(false); //528:2
            __out.AppendLine(true); //529:1
            if (cls.CSharpName() == "MetaClass") //530:2
            {
                __out.Append("    public static global::MetaDslx.Core.Immutable.MetaClass _MetaClass"); //531:1
                __out.AppendLine(false); //531:71
            }
            else //532:2
            {
                __out.Append("    public static global::MetaDslx.Core.Immutable.MetaClass MetaClass"); //533:1
                __out.AppendLine(false); //533:70
            }
            __out.Append("    {"); //535:1
            __out.AppendLine(false); //535:6
            string __tmp5Line = "        get { return null;/*"; //536:1
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
            string __tmp7Line = ";*/ }"; //536:59
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //536:64
            __out.Append("    }"); //537:1
            __out.AppendLine(false); //537:6
            __out.AppendLine(true); //538:1
            var __loop34_results = 
                (from __loop34_var1 in __Enumerate((cls).GetEnumerator()) //539:11
                from prop in __Enumerate((__loop34_var1.Properties).GetEnumerator()) //539:16
                select new { __loop34_var1 = __loop34_var1, prop = prop}
                ).ToList(); //539:6
            int __loop34_iteration = 0;
            foreach (var __tmp8 in __loop34_results)
            {
                ++__loop34_iteration;
                var __loop34_var1 = __tmp8.__loop34_var1;
                var prop = __tmp8.prop;
                string __tmp9Prefix = "    "; //540:1
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
                        __out.AppendLine(false); //540:56
                    }
                }
            }
            __out.Append("}"); //542:1
            __out.AppendLine(false); //542:2
            return __out.ToString();
        }

        public MetaSynthetizedPropertyInitializer GetSynthetizedInitializerFor(MetaClass cls, MetaProperty prop) //546:1
        {
            MetaSynthetizedPropertyInitializer lastInit = null; //547:2
            var __loop35_results = 
                (from __loop35_var1 in __Enumerate((cls).GetEnumerator()) //548:7
                from sup in __Enumerate((__loop35_var1.GetAllSuperClasses(true)).GetEnumerator()) //548:12
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //548:42
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //548:55
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaSynthetizedPropertyInitializer>() //548:69
                select new { __loop35_var1 = __loop35_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //548:2
            int __loop35_iteration = 0;
            foreach (var __tmp1 in __loop35_results)
            {
                ++__loop35_iteration;
                var __loop35_var1 = __tmp1.__loop35_var1;
                var sup = __tmp1.sup;
                var Constructor = __tmp1.Constructor;
                var Initializers = __tmp1.Initializers;
                var init = __tmp1.init;
                if (init.Property == prop) //549:3
                {
                    lastInit = init; //550:4
                }
            }
            return lastInit; //553:2
        }

        public string GenerateImplementationProvider(MetaModel model) //557:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal static class "; //558:1
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
            string __tmp4Line = "ImplementationProvider"; //558:35
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //558:57
            __out.Append("{"); //559:1
            __out.AppendLine(false); //559:2
            string __tmp6Line = "    // If there is a compile error at this line, create a new class called "; //560:1
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
            string __tmp8Line = "Implementation"; //560:88
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //560:102
            string __tmp10Line = "	// which is a subclass of "; //561:1
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
            string __tmp12Line = "ImplementationBase:"; //561:40
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //561:59
            string __tmp14Line = "    private static "; //562:1
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
            string __tmp16Line = "Implementation implementation = new "; //562:32
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
            string __tmp18Line = "Implementation();"; //562:80
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //562:97
            __out.AppendLine(true); //563:1
            string __tmp20Line = "    public static "; //564:1
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
            string __tmp22Line = "Implementation Implementation"; //564:31
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            __out.AppendLine(false); //564:60
            __out.Append("    {"); //565:1
            __out.AppendLine(false); //565:6
            string __tmp24Line = "        get { return "; //566:1
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
            string __tmp26Line = "ImplementationProvider.implementation; }"; //566:34
            if (__tmp26Line != null) __out.Append(__tmp26Line);
            __out.AppendLine(false); //566:74
            __out.Append("    }"); //567:1
            __out.AppendLine(false); //567:6
            __out.Append("}"); //568:1
            __out.AppendLine(false); //568:2
            var __loop36_results = 
                (from __loop36_var1 in __Enumerate((model).GetEnumerator()) //569:8
                from Namespace in __Enumerate((__loop36_var1.Namespace).GetEnumerator()) //569:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //569:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //569:40
                select new { __loop36_var1 = __loop36_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //569:3
            int __loop36_iteration = 0;
            foreach (var __tmp27 in __loop36_results)
            {
                ++__loop36_iteration;
                var __loop36_var1 = __tmp27.__loop36_var1;
                var Namespace = __tmp27.Namespace;
                var Declarations = __tmp27.Declarations;
                var enm = __tmp27.enm;
                __out.AppendLine(true); //570:1
                string __tmp29Line = "public static class "; //571:1
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
                string __tmp31Line = "Extensions"; //571:31
                if (__tmp31Line != null) __out.Append(__tmp31Line);
                __out.AppendLine(false); //571:41
                __out.Append("{"); //572:1
                __out.AppendLine(false); //572:2
                var __loop37_results = 
                    (from __loop37_var1 in __Enumerate((enm).GetEnumerator()) //573:11
                    from op in __Enumerate((__loop37_var1.Operations).GetEnumerator()) //573:16
                    select new { __loop37_var1 = __loop37_var1, op = op}
                    ).ToList(); //573:6
                int __loop37_iteration = 0;
                foreach (var __tmp32 in __loop37_results)
                {
                    ++__loop37_iteration;
                    var __loop37_var1 = __tmp32.__loop37_var1;
                    var op = __tmp32.op;
                    string __tmp34Line = "    public static "; //574:1
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
                    string __tmp36Line = " "; //574:76
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
                    string __tmp38Line = "("; //574:86
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
                    string __tmp40Line = ")"; //574:119
                    if (__tmp40Line != null) __out.Append(__tmp40Line);
                    __out.AppendLine(false); //574:120
                    __out.Append("    {"); //575:1
                    __out.AppendLine(false); //575:6
                    string __tmp41Prefix = "        "; //576:1
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
                    string __tmp44Line = "ImplementationProvider.Implementation."; //576:36
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
                    string __tmp46Line = "_"; //576:98
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
                    string __tmp48Line = "("; //576:108
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
                    string __tmp50Line = ");"; //576:144
                    if (__tmp50Line != null) __out.Append(__tmp50Line);
                    __out.AppendLine(false); //576:146
                    __out.Append("    }"); //577:1
                    __out.AppendLine(false); //577:6
                }
                __out.Append("}"); //579:1
                __out.AppendLine(false); //579:2
            }
            __out.AppendLine(true); //581:1
            __out.Append("/// <summary>"); //582:1
            __out.AppendLine(false); //582:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //583:1
            __out.AppendLine(false); //583:68
            string __tmp52Line = "/// This class has to be be overriden in "; //584:1
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
            string __tmp54Line = "Implementation to provide custom"; //584:54
            if (__tmp54Line != null) __out.Append(__tmp54Line);
            __out.AppendLine(false); //584:86
            __out.Append("/// implementation for the constructors, operations and property values."); //585:1
            __out.AppendLine(false); //585:73
            __out.Append("/// </summary>"); //586:1
            __out.AppendLine(false); //586:15
            string __tmp56Line = "internal abstract class "; //587:1
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
            string __tmp58Line = "ImplementationBase"; //587:37
            if (__tmp58Line != null) __out.Append(__tmp58Line);
            __out.AppendLine(false); //587:55
            __out.Append("{"); //588:1
            __out.AppendLine(false); //588:2
            var __loop38_results = 
                (from __loop38_var1 in __Enumerate((model).GetEnumerator()) //589:8
                from Namespace in __Enumerate((__loop38_var1.Namespace).GetEnumerator()) //589:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //589:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //589:40
                select new { __loop38_var1 = __loop38_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //589:3
            int __loop38_iteration = 0;
            foreach (var __tmp59 in __loop38_results)
            {
                ++__loop38_iteration;
                var __loop38_var1 = __tmp59.__loop38_var1;
                var Namespace = __tmp59.Namespace;
                var Declarations = __tmp59.Declarations;
                var cls = __tmp59.cls;
                __out.Append("    /// <summary>"); //590:1
                __out.AppendLine(false); //590:18
                string __tmp61Line = "	/// Implements the constructor: "; //591:1
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
                string __tmp63Line = "()"; //591:52
                if (__tmp63Line != null) __out.Append(__tmp63Line);
                __out.AppendLine(false); //591:54
                __out.Append("    /// </summary>"); //592:1
                __out.AppendLine(false); //592:19
                if ((from __loop39_var1 in __Enumerate((cls).GetEnumerator()) //593:15
                from sup in __Enumerate((__loop39_var1.SuperClasses).GetEnumerator()) //593:20
                select new { __loop39_var1 = __loop39_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //593:3
                {
                    string __tmp65Line = "	/// Direct superclasses: "; //594:1
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
                            __out.AppendLine(false); //594:49
                        }
                    }
                    string __tmp68Line = "	/// All superclasses: "; //595:1
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
                            __out.AppendLine(false); //595:49
                        }
                    }
                }
                if ((from __loop40_var1 in __Enumerate((cls).GetEnumerator()) //597:15
                from prop in __Enumerate((__loop40_var1.Properties).GetEnumerator()) //597:20
                where prop.Kind == MetaPropertyKind.Readonly //597:36
                select new { __loop40_var1 = __loop40_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //597:3
                {
                    __out.Append("    /// Initializes the following readonly properties:"); //598:1
                    __out.AppendLine(false); //598:55
                    __out.Append("	/// <ul>"); //599:1
                    __out.AppendLine(false); //599:10
                    var __loop41_results = 
                        (from __loop41_var1 in __Enumerate((cls).GetEnumerator()) //600:11
                        from prop in __Enumerate((__loop41_var1.Properties).GetEnumerator()) //600:16
                        where prop.Kind == MetaPropertyKind.Readonly //600:32
                        select new { __loop41_var1 = __loop41_var1, prop = prop}
                        ).ToList(); //600:6
                    int __loop41_iteration = 0;
                    foreach (var __tmp70 in __loop41_results)
                    {
                        ++__loop41_iteration;
                        var __loop41_var1 = __tmp70.__loop41_var1;
                        var prop = __tmp70.prop;
                        string __tmp72Line = "    ///     <li>"; //601:1
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
                        string __tmp74Line = "</li>"; //601:28
                        if (__tmp74Line != null) __out.Append(__tmp74Line);
                        __out.AppendLine(false); //601:33
                    }
                    __out.Append("	/// </ul>"); //603:1
                    __out.AppendLine(false); //603:11
                }
                if ((from __loop42_var1 in __Enumerate((cls).GetEnumerator()) //605:15
                from prop in __Enumerate((__loop42_var1.Properties).GetEnumerator()) //605:20
                where prop.Kind == MetaPropertyKind.Lazy //605:36
                select new { __loop42_var1 = __loop42_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //605:3
                {
                    __out.Append("    /// Initializes the following lazy properties:"); //606:1
                    __out.AppendLine(false); //606:51
                    __out.Append("	/// <ul>"); //607:1
                    __out.AppendLine(false); //607:10
                    var __loop43_results = 
                        (from __loop43_var1 in __Enumerate((cls).GetEnumerator()) //608:11
                        from prop in __Enumerate((__loop43_var1.Properties).GetEnumerator()) //608:16
                        where prop.Kind == MetaPropertyKind.Lazy //608:32
                        select new { __loop43_var1 = __loop43_var1, prop = prop}
                        ).ToList(); //608:6
                    int __loop43_iteration = 0;
                    foreach (var __tmp75 in __loop43_results)
                    {
                        ++__loop43_iteration;
                        var __loop43_var1 = __tmp75.__loop43_var1;
                        var prop = __tmp75.prop;
                        string __tmp77Line = "    ///     <li>"; //609:1
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
                        string __tmp79Line = "</li>"; //609:28
                        if (__tmp79Line != null) __out.Append(__tmp79Line);
                        __out.AppendLine(false); //609:33
                    }
                    __out.Append("	/// </ul>"); //611:1
                    __out.AppendLine(false); //611:11
                }
                if ((from __loop44_var1 in __Enumerate((cls).GetEnumerator()) //613:15
                from prop in __Enumerate((__loop44_var1.Properties).GetEnumerator()) //613:20
                where prop.Kind == MetaPropertyKind.Derived //613:36
                select new { __loop44_var1 = __loop44_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //613:3
                {
                    __out.Append("    /// Initializes the following derived properties:"); //614:1
                    __out.AppendLine(false); //614:54
                    __out.Append("	/// <ul>"); //615:1
                    __out.AppendLine(false); //615:10
                    var __loop45_results = 
                        (from __loop45_var1 in __Enumerate((cls).GetEnumerator()) //616:11
                        from prop in __Enumerate((__loop45_var1.Properties).GetEnumerator()) //616:16
                        where prop.Kind == MetaPropertyKind.Derived //616:32
                        select new { __loop45_var1 = __loop45_var1, prop = prop}
                        ).ToList(); //616:6
                    int __loop45_iteration = 0;
                    foreach (var __tmp80 in __loop45_results)
                    {
                        ++__loop45_iteration;
                        var __loop45_var1 = __tmp80.__loop45_var1;
                        var prop = __tmp80.prop;
                        string __tmp82Line = "    ///     <li>"; //617:1
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
                        string __tmp84Line = "</li>"; //617:28
                        if (__tmp84Line != null) __out.Append(__tmp84Line);
                        __out.AppendLine(false); //617:33
                    }
                    __out.Append("	/// </ul>"); //619:1
                    __out.AppendLine(false); //619:11
                }
                string __tmp86Line = "    public virtual void "; //621:1
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
                string __tmp88Line = "("; //621:43
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
                string __tmp90Line = " @this)"; //621:79
                if (__tmp90Line != null) __out.Append(__tmp90Line);
                __out.AppendLine(false); //621:86
                __out.Append("    {"); //622:1
                __out.AppendLine(false); //622:6
                var __loop46_results = 
                    (from __loop46_var1 in __Enumerate((cls).GetEnumerator()) //623:9
                    from sup in __Enumerate((__loop46_var1.SuperClasses).GetEnumerator()) //623:14
                    select new { __loop46_var1 = __loop46_var1, sup = sup}
                    ).ToList(); //623:4
                int __loop46_iteration = 0;
                foreach (var __tmp91 in __loop46_results)
                {
                    ++__loop46_iteration;
                    var __loop46_var1 = __tmp91.__loop46_var1;
                    var sup = __tmp91.sup;
                    string __tmp93Line = "        this."; //624:1
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
                    string __tmp95Line = "(@this);"; //624:32
                    if (__tmp95Line != null) __out.Append(__tmp95Line);
                    __out.AppendLine(false); //624:40
                }
                string __tmp96Prefix = "		"; //626:1
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
                        __out.AppendLine(false); //626:43
                    }
                }
                __out.Append("    }"); //627:1
                __out.AppendLine(false); //627:6
                var __loop47_results = 
                    (from __loop47_var1 in __Enumerate((cls).GetEnumerator()) //628:11
                    from op in __Enumerate((__loop47_var1.Operations).GetEnumerator()) //628:16
                    select new { __loop47_var1 = __loop47_var1, op = op}
                    ).ToList(); //628:6
                int __loop47_iteration = 0;
                foreach (var __tmp98 in __loop47_results)
                {
                    ++__loop47_iteration;
                    var __loop47_var1 = __tmp98.__loop47_var1;
                    var op = __tmp98.op;
                    __out.AppendLine(true); //629:1
                    __out.Append("    /// <summary>"); //630:1
                    __out.AppendLine(false); //630:18
                    string __tmp100Line = "    /// Implements the operation: "; //631:1
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
                    string __tmp102Line = "."; //631:53
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
                    string __tmp104Line = "()"; //631:63
                    if (__tmp104Line != null) __out.Append(__tmp104Line);
                    __out.AppendLine(false); //631:65
                    __out.Append("    /// </summary>"); //632:1
                    __out.AppendLine(false); //632:19
                    string __tmp106Line = "    public virtual "; //633:1
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
                    string __tmp108Line = " "; //633:77
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
                    string __tmp110Line = "_"; //633:96
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
                    string __tmp112Line = "("; //633:106
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
                    string __tmp114Line = ")"; //633:135
                    if (__tmp114Line != null) __out.Append(__tmp114Line);
                    __out.AppendLine(false); //633:136
                    __out.Append("    {"); //634:1
                    __out.AppendLine(false); //634:6
                    __out.Append("        throw new NotImplementedException();"); //635:1
                    __out.AppendLine(false); //635:45
                    __out.Append("    }"); //636:1
                    __out.AppendLine(false); //636:6
                }
                __out.AppendLine(true); //638:1
            }
            var __loop48_results = 
                (from __loop48_var1 in __Enumerate((model).GetEnumerator()) //640:8
                from Namespace in __Enumerate((__loop48_var1.Namespace).GetEnumerator()) //640:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //640:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //640:40
                select new { __loop48_var1 = __loop48_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //640:3
            int __loop48_iteration = 0;
            foreach (var __tmp115 in __loop48_results)
            {
                ++__loop48_iteration;
                var __loop48_var1 = __tmp115.__loop48_var1;
                var Namespace = __tmp115.Namespace;
                var Declarations = __tmp115.Declarations;
                var enm = __tmp115.enm;
                var __loop49_results = 
                    (from __loop49_var1 in __Enumerate((enm).GetEnumerator()) //641:11
                    from op in __Enumerate((__loop49_var1.Operations).GetEnumerator()) //641:16
                    select new { __loop49_var1 = __loop49_var1, op = op}
                    ).ToList(); //641:6
                int __loop49_iteration = 0;
                foreach (var __tmp116 in __loop49_results)
                {
                    ++__loop49_iteration;
                    var __loop49_var1 = __tmp116.__loop49_var1;
                    var op = __tmp116.op;
                    __out.AppendLine(true); //642:1
                    __out.Append("    /// <summary>"); //643:1
                    __out.AppendLine(false); //643:18
                    string __tmp118Line = "    /// Implements the operation: "; //644:1
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
                    string __tmp120Line = "."; //644:53
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
                            __out.AppendLine(false); //644:63
                        }
                    }
                    __out.Append("    /// </summary>"); //645:1
                    __out.AppendLine(false); //645:19
                    string __tmp123Line = "    public virtual "; //646:1
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
                    string __tmp125Line = " "; //646:77
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
                    string __tmp127Line = "_"; //646:96
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
                    string __tmp129Line = "("; //646:106
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
                    string __tmp131Line = ")"; //646:135
                    if (__tmp131Line != null) __out.Append(__tmp131Line);
                    __out.AppendLine(false); //646:136
                    __out.Append("    {"); //647:1
                    __out.AppendLine(false); //647:6
                    __out.Append("        throw new NotImplementedException();"); //648:1
                    __out.AppendLine(false); //648:45
                    __out.Append("    }"); //649:1
                    __out.AppendLine(false); //649:6
                }
                __out.AppendLine(true); //651:1
            }
            __out.AppendLine(true); //653:1
            var __loop50_results = 
                (from __loop50_var1 in __Enumerate((model).GetEnumerator()) //654:8
                from Namespace in __Enumerate((__loop50_var1.Namespace).GetEnumerator()) //654:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //654:26
                from func in __Enumerate((Declarations).GetEnumerator()).OfType<MetaFunction>() //654:40
                select new { __loop50_var1 = __loop50_var1, Namespace = Namespace, Declarations = Declarations, func = func}
                ).ToList(); //654:3
            int __loop50_iteration = 0;
            foreach (var __tmp132 in __loop50_results)
            {
                ++__loop50_iteration;
                var __loop50_var1 = __tmp132.__loop50_var1;
                var Namespace = __tmp132.Namespace;
                var Declarations = __tmp132.Declarations;
                var func = __tmp132.func;
                string __tmp133Prefix = "	"; //655:1
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
                        __out.AppendLine(false); //655:45
                    }
                }
            }
            __out.Append("}"); //657:1
            __out.AppendLine(false); //657:2
            __out.AppendLine(true); //658:1
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //661:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //662:1
            __out.AppendLine(false); //662:14
            __out.Append("/// Factory class for creating instances of model elements."); //663:1
            __out.AppendLine(false); //663:60
            __out.Append("/// </summary>"); //664:1
            __out.AppendLine(false); //664:15
            string __tmp2Line = "public class "; //665:1
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
            string __tmp4Line = " : global::MetaDslx.Core.Immutable.ModelFactory"; //665:41
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //665:88
            __out.Append("{"); //666:1
            __out.AppendLine(false); //666:2
            string __tmp6Line = "    public "; //667:1
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
            string __tmp8Line = "()"; //667:39
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //667:41
            __out.Append("        : base()"); //668:1
            __out.AppendLine(false); //668:17
            __out.Append("    {"); //669:1
            __out.AppendLine(false); //669:6
            string __tmp9Prefix = "		"; //670:1
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
            string __tmp11Line = ".Init();"; //670:33
            if (__tmp11Line != null) __out.Append(__tmp11Line);
            __out.AppendLine(false); //670:41
            __out.Append("    }"); //671:1
            __out.AppendLine(false); //671:6
            __out.AppendLine(true); //672:1
            string __tmp13Line = "    public "; //673:1
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
            string __tmp15Line = "(global::MetaDslx.Core.Immutable.MutableRedModel model)"; //673:39
            if (__tmp15Line != null) __out.Append(__tmp15Line);
            __out.AppendLine(false); //673:94
            __out.Append("        : base(model)"); //674:1
            __out.AppendLine(false); //674:22
            __out.Append("    {"); //675:1
            __out.AppendLine(false); //675:6
            string __tmp16Prefix = "		"; //676:1
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
            string __tmp18Line = ".Init();"; //676:33
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //676:41
            __out.Append("    }"); //677:1
            __out.AppendLine(false); //677:6
            __out.AppendLine(true); //678:1
            string __tmp20Line = "    public "; //679:1
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
            string __tmp22Line = "(global::MetaDslx.Core.Immutable.MutableRedModel model, global::MetaDslx.Core.Immutable.MutableRedModelPart part)"; //679:39
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            __out.AppendLine(false); //679:152
            __out.Append("        : base(model, part)"); //680:1
            __out.AppendLine(false); //680:28
            __out.Append("    {"); //681:1
            __out.AppendLine(false); //681:6
            string __tmp23Prefix = "		"; //682:1
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
            string __tmp25Line = ".Init();"; //682:33
            if (__tmp25Line != null) __out.Append(__tmp25Line);
            __out.AppendLine(false); //682:41
            __out.Append("    }"); //683:1
            __out.AppendLine(false); //683:6
            __out.AppendLine(true); //684:1
            __out.Append("    public override global::MetaDslx.Core.Immutable.MutableRedSymbol Create(string type)"); //685:1
            __out.AppendLine(false); //685:89
            __out.Append("    {"); //686:1
            __out.AppendLine(false); //686:6
            __out.Append("        switch (type)"); //687:1
            __out.AppendLine(false); //687:22
            __out.Append("        {"); //688:1
            __out.AppendLine(false); //688:10
            var __loop51_results = 
                (from __loop51_var1 in __Enumerate((model).GetEnumerator()) //689:10
                from Namespace in __Enumerate((__loop51_var1.Namespace).GetEnumerator()) //689:17
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //689:28
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //689:42
                select new { __loop51_var1 = __loop51_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //689:5
            int __loop51_iteration = 0;
            foreach (var __tmp26 in __loop51_results)
            {
                ++__loop51_iteration;
                var __loop51_var1 = __tmp26.__loop51_var1;
                var Namespace = __tmp26.Namespace;
                var Declarations = __tmp26.Declarations;
                var cls = __tmp26.cls;
                if (!cls.IsAbstract) //690:6
                {
                    string __tmp28Line = "            case \""; //691:1
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
                    string __tmp30Line = "\": return (MutableRedSymbol)this."; //691:37
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
                    string __tmp32Line = "();"; //691:88
                    if (__tmp32Line != null) __out.Append(__tmp32Line);
                    __out.AppendLine(false); //691:91
                }
            }
            __out.Append("            default:"); //694:1
            __out.AppendLine(false); //694:21
            __out.Append("                throw new ModelException(\"Unknown type name: \" + type);"); //695:1
            __out.AppendLine(false); //695:72
            __out.Append("        }"); //696:1
            __out.AppendLine(false); //696:10
            __out.Append("    }"); //697:1
            __out.AppendLine(false); //697:6
            var __loop52_results = 
                (from __loop52_var1 in __Enumerate((model).GetEnumerator()) //698:8
                from Namespace in __Enumerate((__loop52_var1.Namespace).GetEnumerator()) //698:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //698:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //698:40
                select new { __loop52_var1 = __loop52_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //698:3
            int __loop52_iteration = 0;
            foreach (var __tmp33 in __loop52_results)
            {
                ++__loop52_iteration;
                var __loop52_var1 = __tmp33.__loop52_var1;
                var Namespace = __tmp33.Namespace;
                var Declarations = __tmp33.Declarations;
                var cls = __tmp33.cls;
                if (!cls.IsAbstract) //699:4
                {
                    __out.AppendLine(true); //700:1
                    __out.Append("    /// <summary>"); //701:1
                    __out.AppendLine(false); //701:18
                    string __tmp35Line = "    /// Creates a new instance of "; //702:1
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
                    string __tmp37Line = "."; //702:53
                    if (__tmp37Line != null) __out.Append(__tmp37Line);
                    __out.AppendLine(false); //702:54
                    __out.Append("    /// </summary>"); //703:1
                    __out.AppendLine(false); //703:19
                    string __tmp39Line = "    public "; //704:1
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
                    string __tmp41Line = " "; //704:47
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
                    string __tmp43Line = "(params global::MetaDslx.Core.Immutable.PropertyInit"; //704:66
                    if (__tmp43Line != null) __out.Append(__tmp43Line);
                    StringBuilder __tmp44 = new StringBuilder();
                    __tmp44.Append("[]");
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
                    string __tmp45Line = " propertyInitializers)"; //704:124
                    if (__tmp45Line != null) __out.Append(__tmp45Line);
                    __out.AppendLine(false); //704:146
                    __out.Append("	{"); //705:1
                    __out.AppendLine(false); //705:3
                    string __tmp47Line = "		global::MetaDslx.Core.Immutable.MutableRedSymbolBase symbol = (global::MetaDslx.Core.Immutable.MutableRedSymbolBase)this.AddSymbol(new "; //706:1
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
                    string __tmp49Line = "());"; //706:168
                    if (__tmp49Line != null) __out.Append(__tmp49Line);
                    __out.AppendLine(false); //706:172
                    __out.Append("		symbol.MInitProperties(propertyInitializers);"); //707:1
                    __out.AppendLine(false); //707:48
                    __out.Append("		symbol.MMakeCreated();"); //708:1
                    __out.AppendLine(false); //708:25
                    string __tmp51Line = "		return ("; //709:1
                    if (__tmp51Line != null) __out.Append(__tmp51Line);
                    StringBuilder __tmp52 = new StringBuilder();
                    __tmp52.Append(cls.CSharpName(ClassKind.Builder));
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
                    string __tmp53Line = ")symbol;"; //709:46
                    if (__tmp53Line != null) __out.Append(__tmp53Line);
                    __out.AppendLine(false); //709:54
                    __out.Append("	}"); //710:1
                    __out.AppendLine(false); //710:3
                }
            }
            __out.Append("}"); //713:1
            __out.AppendLine(false); //713:2
            __out.AppendLine(true); //714:1
            return __out.ToString();
        }

        public string GenerateFunction(MetaFunction func, ClassKind classKind) //717:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "public abstract "; //718:1
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
            string __tmp4Line = " "; //718:66
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
            string __tmp6Line = "("; //718:78
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
            string __tmp8Line = ");"; //718:111
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //718:113
            return __out.ToString();
        }

        public string GenerateInitImplementation(MetaModel model, MetaClass cls) //721:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop53_results = 
                (from __loop53_var1 in __Enumerate((cls).GetEnumerator()) //722:7
                from prop in __Enumerate((__loop53_var1.Properties).GetEnumerator()) //722:12
                select new { __loop53_var1 = __loop53_var1, prop = prop}
                ).ToList(); //722:2
            int __loop53_iteration = 0;
            foreach (var __tmp1 in __loop53_results)
            {
                ++__loop53_iteration;
                var __loop53_var1 = __tmp1.__loop53_var1;
                var prop = __tmp1.prop;
                MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //723:3
                if (synInit != null) //724:3
                {
                    if (ModelCompilerContext.Current.TypeProvider.GetTypeOf(synInit.Value) is MetaCollectionType) //725:4
                    {
                        string __tmp3Line = "@this."; //726:1
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
                        string __tmp5Line = ".ClearLazy();"; //726:18
                        if (__tmp5Line != null) __out.Append(__tmp5Line);
                        __out.AppendLine(false); //726:31
                        if (synInit.Value.Type is MetaCollectionType) //727:5
                        {
                            string __tmp7Line = "@this."; //728:1
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
                            string __tmp9Line = ".LazyAddRange("; //728:18
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
                            string __tmp11Line = ");"; //728:67
                            if (__tmp11Line != null) __out.Append(__tmp11Line);
                            __out.AppendLine(false); //728:69
                        }
                        else //729:5
                        {
                            string __tmp13Line = "@this."; //730:1
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
                            string __tmp15Line = ".LazyAdd("; //730:18
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
                            string __tmp17Line = ");"; //730:62
                            if (__tmp17Line != null) __out.Append(__tmp17Line);
                            __out.AppendLine(false); //730:64
                        }
                    }
                    else //732:4
                    {
                        string __tmp19Line = "@this."; //733:1
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
                        string __tmp21Line = "Lazy = () => ("; //733:18
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
                        string __tmp23Line = ")("; //733:77
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
                        string __tmp25Line = ");"; //733:114
                        if (__tmp25Line != null) __out.Append(__tmp25Line);
                        __out.AppendLine(false); //733:116
                    }
                }
            }
            var __loop54_results = 
                (from __loop54_var1 in __Enumerate((cls).GetEnumerator()) //737:7
                from Constructor in __Enumerate((__loop54_var1.Constructor).GetEnumerator()) //737:12
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //737:25
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaInheritedPropertyInitializer>() //737:39
                select new { __loop54_var1 = __loop54_var1, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //737:2
            int __loop54_iteration = 0;
            foreach (var __tmp26 in __loop54_results)
            {
                ++__loop54_iteration;
                var __loop54_var1 = __tmp26.__loop54_var1;
                var Constructor = __tmp26.Constructor;
                var Initializers = __tmp26.Initializers;
                var init = __tmp26.init;
                if (init.Object != null && init.Property != null) //738:3
                {
                    if (((MetaClass)init.Object.Type).GetAllSuperClasses(true).Contains(init.PropertyContext)) //739:4
                    {
                        if (init.Value.Type is MetaCollectionType) //740:5
                        {
                            string __tmp28Line = "@this."; //741:1
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
                            string __tmp30Line = "LazyChild."; //741:24
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
                            string __tmp32Line = " = () => "; //741:53
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
                            string __tmp34Line = "; "; //741:94
                            if (__tmp34Line != null) __out.Append(__tmp34Line);
                            __out.AppendLine(false); //741:96
                        }
                        else //742:5
                        {
                            string __tmp36Line = "@this."; //743:1
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
                            string __tmp38Line = "LazyChild."; //743:24
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
                            string __tmp40Line = " = () => "; //743:53
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
                            string __tmp42Line = ";"; //743:94
                            if (__tmp42Line != null) __out.Append(__tmp42Line);
                            __out.AppendLine(false); //743:95
                        }
                    }
                    else //745:4
                    {
                        string __tmp44Line = "((MutableRedSymbolBase)@this).MChildLazyAdd("; //746:1
                        if (__tmp44Line != null) __out.Append(__tmp44Line);
                        StringBuilder __tmp45 = new StringBuilder();
                        __tmp45.Append(init.Object.CSharpFullDescriptorName(ClassKind.Builder));
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
                        string __tmp46Line = ", "; //746:102
                        if (__tmp46Line != null) __out.Append(__tmp46Line);
                        StringBuilder __tmp47 = new StringBuilder();
                        __tmp47.Append(init.Property.CSharpFullDescriptorName(ClassKind.Builder));
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
                        string __tmp48Line = ", () => "; //746:163
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
                        string __tmp50Line = ");"; //746:203
                        if (__tmp50Line != null) __out.Append(__tmp50Line);
                        __out.AppendLine(false); //746:205
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateExpression(MetaExpression expr) //752:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //753:10
            if (expr is MetaBracketExpression) //754:2
            {
                string __tmp4Line = "("; //754:33
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
                string __tmp6Line = ")"; //754:71
                if (__tmp6Line != null) __out.Append(__tmp6Line);
            }
            else if (expr is MetaThisExpression) //755:2
            {
                __out.Append("@this"); //755:30
            }
            else if (expr is MetaNullExpression) //756:2
            {
                __out.Append("null"); //756:30
            }
            else if (expr is MetaTypeAsExpression) //757:2
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
                string __tmp10Line = " as "; //757:69
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
            else if (expr is MetaTypeCastExpression) //758:2
            {
                string __tmp14Line = "("; //758:34
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
                string __tmp16Line = ")"; //758:85
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
            else if (expr is MetaTypeCheckExpression) //759:2
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
                string __tmp21Line = " is "; //759:72
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
            else if (expr is MetaTypeOfExpression) //760:2
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
            else if (expr is MetaConditionalExpression) //761:2
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
                string __tmp29Line = " ? "; //761:73
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
                string __tmp31Line = " : "; //761:107
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
            else if (expr is MetaConstantExpression) //762:2
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
            else if (expr is MetaIdentifierExpression) //763:2
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
            else if (expr is MetaMemberAccessExpression) //764:2
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
                string __tmp42Line = "."; //764:75
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
            else if (expr is MetaFunctionCallExpression) //765:2
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
            else if (expr is MetaIndexerExpression) //766:2
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
            else if (expr is MetaOperatorExpression) //767:2
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
            else if (expr is MetaNewExpression) //768:2
            {
                string __tmp55Line = "new "; //768:29
                if (__tmp55Line != null) __out.Append(__tmp55Line);
                StringBuilder __tmp56 = new StringBuilder();
                __tmp56.Append(((MetaNewExpression)expr).TypeReference.Model.CSharpFullFactoryName(ClassKind.Immutable));
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
                string __tmp57Line = "(this.MModelPart)."; //768:102
                if (__tmp57Line != null) __out.Append(__tmp57Line);
                StringBuilder __tmp58 = new StringBuilder();
                __tmp58.Append(((MetaNewExpression)expr).TypeReference.CSharpName(ClassKind.Immutable));
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
                string __tmp59Line = "("; //768:172
                if (__tmp59Line != null) __out.Append(__tmp59Line);
                StringBuilder __tmp60 = new StringBuilder();
                __tmp60.Append(GenerateNewPropertyInitializers(((MetaNewExpression)expr)));
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
                string __tmp61Line = ")"; //768:212
                if (__tmp61Line != null) __out.Append(__tmp61Line);
            }
            else if (expr is MetaNewCollectionExpression) //769:2
            {
                string __tmp64Line = "new List<Func<object>>() { "; //769:39
                if (__tmp64Line != null) __out.Append(__tmp64Line);
                StringBuilder __tmp65 = new StringBuilder();
                __tmp65.Append(GenerateNewCollectionValues(((MetaNewCollectionExpression)expr)));
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
                string __tmp66Line = " }"; //769:101
                if (__tmp66Line != null) __out.Append(__tmp66Line);
            }
            else //770:2
            {
                __out.Append("***unknown expression type***"); //770:11
                __out.AppendLine(false); //770:40
            }//771:2
            return __out.ToString();
        }

        public string GenerateIdentifierExpression(MetaIdentifierExpression expr) //774:1
        {
            StringBuilder __out = new StringBuilder();
            if (expr.Definition is MetaProperty) //775:2
            {
                string __tmp2Line = "@this."; //776:1
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
            else //777:2
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

        public bool SameFunction(MetaGlobalFunction mfunc1, MetaGlobalFunction mfunc2) //782:1
        {
            return mfunc1.Name == mfunc2.Name && ModelCompilerContext.Current.TypeProvider.Equals((ModelObject)mfunc1.Type, (ModelObject)mfunc2.Type); //783:2
        }

        public string GenerateFunctionCall(MetaFunctionCallExpression call) //786:1
        {
            StringBuilder __out = new StringBuilder();
            if (call.Definition is MetaGlobalFunction && SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.TypeOf)) //787:2
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
            else //788:2
            {
                string __tmp6Line = "this."; //788:7
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
                string __tmp8Line = "("; //788:49
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
                string __tmp10Line = ")"; //788:83
                if (__tmp10Line != null) __out.Append(__tmp10Line);
            }
            return __out.ToString();
        }

        public string GenerateIndexerCall(MetaIndexerExpression call) //792:1
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

        public string GenerateTypeOf(object expr) //796:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //797:9
            if (expr is MetaPrimitiveType) //798:2
            {
                var __tmp2 = ((MetaPrimitiveType)expr).Name; //799:9
                if (__tmp2 == "*none*") //800:2
                {
                    __out.Append("MetaInstance.None"); //800:17
                }
                else if (__tmp2 == "*error*") //801:2
                {
                    __out.Append("MetaInstance.Error"); //801:18
                }
                else if (__tmp2 == "*any*") //802:2
                {
                    __out.Append("MetaInstance.Any"); //802:16
                }
                else if (__tmp2 == "object") //803:2
                {
                    __out.Append("MetaInstance.Object"); //803:17
                }
                else if (__tmp2 == "string") //804:2
                {
                    __out.Append("MetaInstance.String"); //804:17
                }
                else if (__tmp2 == "int") //805:2
                {
                    __out.Append("MetaInstance.Int"); //805:14
                }
                else if (__tmp2 == "long") //806:2
                {
                    __out.Append("MetaInstance.Long"); //806:15
                }
                else if (__tmp2 == "float") //807:2
                {
                    __out.Append("MetaInstance.Float"); //807:16
                }
                else if (__tmp2 == "double") //808:2
                {
                    __out.Append("MetaInstance.Double"); //808:17
                }
                else if (__tmp2 == "byte") //809:2
                {
                    __out.Append("MetaInstance.Byte"); //809:15
                }
                else if (__tmp2 == "bool") //810:2
                {
                    __out.Append("MetaInstance.Bool"); //810:15
                }
                else if (__tmp2 == "void") //811:2
                {
                    __out.Append("MetaInstance.Void"); //811:15
                }
                else if (__tmp2 == "ModelObject") //812:2
                {
                    __out.Append("MetaInstance.ModelObject"); //812:22
                }
                else if (__tmp2 == "ModelObjectList") //813:2
                {
                    __out.Append("MetaInstance.ModelObjectList"); //813:26
                }//814:2
            }
            else if (expr is MetaTypeOfExpression) //815:2
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
            else if (expr is MetaClass) //816:2
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
                string __tmp9Line = ".MetaClass"; //816:73
                if (__tmp9Line != null) __out.Append(__tmp9Line);
            }
            else if (expr is MetaCollectionType) //817:2
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
            else //818:2
            {
                __out.Append("***error***"); //818:11
            }//819:2
            return __out.ToString();
        }

        public string GenerateCallArguments(MetaBoundExpression call, string prefix) //822:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop55_results = 
                (from __loop55_var1 in __Enumerate((call).GetEnumerator()) //823:7
                from arg in __Enumerate((__loop55_var1.Arguments).GetEnumerator()) //823:13
                select new { __loop55_var1 = __loop55_var1, arg = arg}
                ).ToList(); //823:2
            int __loop55_iteration = 0;
            string delim = ""; //823:28
            foreach (var __tmp1 in __loop55_results)
            {
                ++__loop55_iteration;
                if (__loop55_iteration >= 2) //823:47
                {
                    delim = ", "; //823:47
                }
                var __loop55_var1 = __tmp1.__loop55_var1;
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

        public string GenerateOperator(MetaOperatorExpression expr) //828:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //829:10
            if (expr is MetaUnaryExpression) //830:2
            {
                if (((MetaUnaryExpression)expr) is MetaPostIncrementAssignExpression || ((MetaUnaryExpression)expr) is MetaPostDecrementAssignExpression) //831:3
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
                else //833:3
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
            else if (expr is MetaBinaryExpression) //836:2
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
            }//838:2
            return __out.ToString();
        }

        public string GenerateNewPropertyInitializers(MetaNewExpression expr) //841:1
        {
            StringBuilder __out = new StringBuilder();
            if ((from __loop56_var1 in __Enumerate((expr).GetEnumerator()) //842:14
            from pi in __Enumerate((__loop56_var1.PropertyInitializers).GetEnumerator()) //842:20
            select new { __loop56_var1 = __loop56_var1, pi = pi}
            ).GetEnumerator().MoveNext()) //842:2
            {
                var __loop57_results = 
                    (from __loop57_var1 in __Enumerate((expr).GetEnumerator()) //843:7
                    from pi in __Enumerate((__loop57_var1.PropertyInitializers).GetEnumerator()) //843:13
                    select new { __loop57_var1 = __loop57_var1, pi = pi}
                    ).ToList(); //843:2
                int __loop57_iteration = 0;
                string delim = ""; //843:38
                foreach (var __tmp1 in __loop57_results)
                {
                    ++__loop57_iteration;
                    if (__loop57_iteration >= 2) //843:57
                    {
                        delim = ", "; //843:57
                    }
                    var __loop57_var1 = __tmp1.__loop57_var1;
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
                    string __tmp4Line = "new PropertyInit("; //844:8
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
                    string __tmp6Line = ", () => "; //844:84
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
                    string __tmp8Line = ")"; //844:122
                    if (__tmp8Line != null) __out.Append(__tmp8Line);
                }
            }
            return __out.ToString();
        }

        public string GenerateNewCollectionValues(MetaNewCollectionExpression expr) //849:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop58_results = 
                (from __loop58_var1 in __Enumerate((expr).GetEnumerator()) //850:7
                from v in __Enumerate((__loop58_var1.Values).GetEnumerator()) //850:13
                select new { __loop58_var1 = __loop58_var1, v = v}
                ).ToList(); //850:2
            int __loop58_iteration = 0;
            string delim = ""; //850:23
            foreach (var __tmp1 in __loop58_results)
            {
                ++__loop58_iteration;
                if (__loop58_iteration >= 2) //850:42
                {
                    delim = ", \n"; //850:42
                }
                var __loop58_var1 = __tmp1.__loop58_var1;
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

        public string GetCSharpValue(object value) //855:1
        {
            if (value == null) //856:2
            {
                return "null"; //856:21
            }
            else if (value is bool && ((bool)value) == true) //857:2
            {
                return "true"; //857:51
            }
            else if (value is bool && ((bool)value) == false) //858:2
            {
                return "false"; //858:52
            }
            else if (value is string) //859:2
            {
                return "\"" + value.ToString() + "\""; //859:28
            }
            else if (value is MetaExpression) //860:2
            {
                return GenerateExpression((MetaExpression)value); //860:36
            }
            else //861:2
            {
                return value.ToString(); //861:7
            }
        }

        public string GetCSharpIdentifier(object value) //865:1
        {
            if (value == null) //866:2
            {
                return null; //867:3
            }
            if (value is MetaConstantExpression && ((MetaConstantExpression)value).Value != null) //869:2
            {
                return ((MetaConstantExpression)value).Value.ToString(); //870:3
            }
            else if (value is string) //871:2
            {
                return value.ToString(); //872:3
            }
            else //873:2
            {
                return null; //874:3
            }
        }

        public string GetCSharpOperator(MetaOperatorExpression expr) //878:1
        {
            var __tmp1 = expr; //879:9
            if (expr is MetaUnaryPlusExpression) //880:3
            {
                return "+"; //880:36
            }
            else if (expr is MetaNegateExpression) //881:3
            {
                return "-"; //881:33
            }
            else if (expr is MetaOnesComplementExpression) //882:3
            {
                return "~"; //882:41
            }
            else if (expr is MetaNotExpression) //883:3
            {
                return "!"; //883:30
            }
            else if (expr is MetaPostIncrementAssignExpression) //884:3
            {
                return "++"; //884:46
            }
            else if (expr is MetaPostDecrementAssignExpression) //885:3
            {
                return "--"; //885:46
            }
            else if (expr is MetaPreIncrementAssignExpression) //886:3
            {
                return "++"; //886:45
            }
            else if (expr is MetaPreDecrementAssignExpression) //887:3
            {
                return "--"; //887:45
            }
            else if (expr is MetaMultiplyExpression) //888:3
            {
                return "*"; //888:35
            }
            else if (expr is MetaDivideExpression) //889:3
            {
                return "/"; //889:33
            }
            else if (expr is MetaModuloExpression) //890:3
            {
                return "%"; //890:33
            }
            else if (expr is MetaAddExpression) //891:3
            {
                return "+"; //891:30
            }
            else if (expr is MetaSubtractExpression) //892:3
            {
                return "-"; //892:35
            }
            else if (expr is MetaLeftShiftExpression) //893:3
            {
                return "<<"; //893:36
            }
            else if (expr is MetaRightShiftExpression) //894:3
            {
                return ">>"; //894:37
            }
            else if (expr is MetaLessThanExpression) //895:3
            {
                return "<"; //895:35
            }
            else if (expr is MetaLessThanOrEqualExpression) //896:3
            {
                return "<="; //896:42
            }
            else if (expr is MetaGreaterThanExpression) //897:3
            {
                return ">"; //897:38
            }
            else if (expr is MetaGreaterThanOrEqualExpression) //898:3
            {
                return ">="; //898:45
            }
            else if (expr is MetaEqualExpression) //899:3
            {
                return "=="; //899:32
            }
            else if (expr is MetaNotEqualExpression) //900:3
            {
                return "!="; //900:35
            }
            else if (expr is MetaAndExpression) //901:3
            {
                return "&"; //901:30
            }
            else if (expr is MetaOrExpression) //902:3
            {
                return "|"; //902:29
            }
            else if (expr is MetaExclusiveOrExpression) //903:3
            {
                return "^"; //903:38
            }
            else if (expr is MetaAndAlsoExpression) //904:3
            {
                return "&&"; //904:34
            }
            else if (expr is MetaOrElseExpression) //905:3
            {
                return "||"; //905:33
            }
            else if (expr is MetaNullCoalescingExpression) //906:3
            {
                return "??"; //906:41
            }
            else if (expr is MetaMultiplyAssignExpression) //907:3
            {
                return "*="; //907:41
            }
            else if (expr is MetaDivideAssignExpression) //908:3
            {
                return "/="; //908:39
            }
            else if (expr is MetaModuloAssignExpression) //909:3
            {
                return "%="; //909:39
            }
            else if (expr is MetaAddAssignExpression) //910:3
            {
                return "+="; //910:36
            }
            else if (expr is MetaSubtractAssignExpression) //911:3
            {
                return "-="; //911:41
            }
            else if (expr is MetaLeftShiftAssignExpression) //912:3
            {
                return "<<="; //912:42
            }
            else if (expr is MetaRightShiftAssignExpression) //913:3
            {
                return ">>="; //913:43
            }
            else if (expr is MetaAndAssignExpression) //914:3
            {
                return "&="; //914:36
            }
            else if (expr is MetaExclusiveOrAssignExpression) //915:3
            {
                return "^="; //915:44
            }
            else if (expr is MetaOrAssignExpression) //916:3
            {
                return "|="; //916:35
            }
            else //917:3
            {
                return ""; //917:12
            }//918:2
        }

        public string GetTypeName(MetaExpression expr) //921:1
        {
            if (expr is MetaTypeOfExpression) //922:2
            {
                return ((MetaTypeOfExpression)expr).TypeReference.CSharpFullName(ClassKind.Immutable); //922:36
            }
            else //923:2
            {
                return null; //923:7
            }
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
