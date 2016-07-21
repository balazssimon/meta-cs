using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core //1:1
{
    using __Hidden_MetaModelJavaGenerator_300832521;
    namespace __Hidden_MetaModelJavaGenerator_300832521
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

    public class MetaModelJavaGenerator //2:1
    {
        private IEnumerable<ModelObject> Instances; //2:1

        public MetaModelJavaGenerator() //2:1
        {
            this.Properties = new __Properties();
        }

        public MetaModelJavaGenerator(IEnumerable<ModelObject> instances) : this() //2:1
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
                this.LineCount = 0; //5:18
                this.FunctionCount = 0; //6:22
            }
            public int LineCount { get; set; } //5:2
            public int FunctionCount { get; set; } //6:2
        }

        public string Generate() //9:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop1_results = 
                (from __loop1_var1 in __Enumerate((Instances).GetEnumerator()) //10:8
                from mm in __Enumerate((__loop1_var1).GetEnumerator()).OfType<MetaModel>() //10:19
                select new { __loop1_var1 = __loop1_var1, mm = mm}
                ).ToList(); //10:3
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
                        __out.AppendLine(false); //11:24
                    }
                }
            }
            return __out.ToString();
        }

        public string ResetCounters() //15:1
        {
            Properties.LineCount = 0; //16:2
            Properties.FunctionCount = 0; //17:2
            return ""; //18:2
        }

        public string GenerateMetamodel(MetaModel model) //21:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(GenerateMetaModelDescriptor(model));
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
                    __out.AppendLine(false); //22:37
                }
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(GenerateMetaModelInstance(model));
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
                    __out.AppendLine(false); //23:35
                }
            }
            var __loop2_results = 
                (from __loop2_var1 in __Enumerate((model).GetEnumerator()) //24:7
                from Namespace in __Enumerate((__loop2_var1.Namespace).GetEnumerator()) //24:14
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //24:25
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //24:39
                select new { __loop2_var1 = __loop2_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //24:2
            for (int __loop2_iteration = 0; __loop2_iteration < __loop2_results.Count; ++__loop2_iteration)
            {
                var __tmp5 = __loop2_results[__loop2_iteration];
                var __loop2_var1 = __tmp5.__loop2_var1;
                var Namespace = __tmp5.Namespace;
                var Declarations = __tmp5.Declarations;
                var enm = __tmp5.enm;
                StringBuilder __tmp7 = new StringBuilder();
                __tmp7.Append(GenerateEnum(enm));
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
                        __out.AppendLine(false); //25:20
                    }
                }
            }
            var __loop3_results = 
                (from __loop3_var1 in __Enumerate((model).GetEnumerator()) //27:7
                from Namespace in __Enumerate((__loop3_var1.Namespace).GetEnumerator()) //27:14
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //27:25
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //27:39
                select new { __loop3_var1 = __loop3_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //27:2
            for (int __loop3_iteration = 0; __loop3_iteration < __loop3_results.Count; ++__loop3_iteration)
            {
                var __tmp8 = __loop3_results[__loop3_iteration];
                var __loop3_var1 = __tmp8.__loop3_var1;
                var Namespace = __tmp8.Namespace;
                var Declarations = __tmp8.Declarations;
                var cls = __tmp8.cls;
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(GenerateInterface(cls));
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
                        __out.AppendLine(false); //28:25
                    }
                }
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(GenerateInterfaceImpl(model, cls));
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
                        __out.AppendLine(false); //29:36
                    }
                }
            }
            StringBuilder __tmp14 = new StringBuilder();
            __tmp14.Append(GenerateFactory(model));
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
                    __out.AppendLine(false); //31:25
                }
            }
            StringBuilder __tmp16 = new StringBuilder();
            __tmp16.Append(GenerateImplementationProvider(model));
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
                    __out.AppendLine(false); //32:40
                }
            }
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append(GenerateImplementationBase(model));
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
                    __out.AppendLine(false); //33:36
                }
            }
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
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                var __tmp1 = __loop4_results[__loop4_iteration];
                var __loop4_var1 = __tmp1.__loop4_var1;
                var annot = __tmp1.annot;
                string __tmp3Line = "@metadslx.core."; //38:1
                if (__tmp3Line != null) __out.Append(__tmp3Line);
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
                        __out.AppendLine(false); //38:28
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateEnum(MetaEnum enm) //42:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "package "; //43:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(enm.Namespace.JavaName());
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
            string __tmp4Line = ";"; //43:35
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //43:36
            __out.AppendLine(true); //44:1
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(GenerateAnnotations(enm));
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
                    __out.AppendLine(false); //45:27
                }
            }
            string __tmp8Line = "public enum "; //46:1
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(enm.JavaName());
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
            string __tmp10Line = " {"; //46:29
            if (__tmp10Line != null) __out.Append(__tmp10Line);
            __out.AppendLine(false); //46:31
            var __loop5_results = 
                (from __loop5_var1 in __Enumerate((enm).GetEnumerator()) //47:11
                from value in __Enumerate((__loop5_var1.EnumLiterals).GetEnumerator()) //47:16
                select new { __loop5_var1 = __loop5_var1, value = value}
                ).ToList(); //47:6
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                string delim; //47:34
                if (__loop5_iteration+1 < __loop5_results.Count) delim = ",";
                else delim = string.Empty;
                var __tmp11 = __loop5_results[__loop5_iteration];
                var __loop5_var1 = __tmp11.__loop5_var1;
                var value = __tmp11.value;
                string __tmp12Prefix = "    "; //48:1
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(value.Name);
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
                    }
                }
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(delim);
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
                        __out.AppendLine(false); //48:24
                    }
                }
            }
            __out.Append(";"); //50:1
            __out.AppendLine(false); //50:2
            var __loop6_results = 
                (from __loop6_var1 in __Enumerate((enm).GetEnumerator()) //51:7
                from op in __Enumerate((__loop6_var1.Operations).GetEnumerator()) //51:12
                select new { __loop6_var1 = __loop6_var1, op = op}
                ).ToList(); //51:2
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp15 = __loop6_results[__loop6_iteration];
                var __loop6_var1 = __tmp15.__loop6_var1;
                var op = __tmp15.op;
                __out.AppendLine(true); //52:1
                string __tmp17Line = "    public "; //53:1
                if (__tmp17Line != null) __out.Append(__tmp17Line);
                StringBuilder __tmp18 = new StringBuilder();
                __tmp18.Append(op.ReturnType.JavaFullPublicName());
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
                string __tmp19Line = " "; //53:48
                if (__tmp19Line != null) __out.Append(__tmp19Line);
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(op.Name.ToCamelCase());
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
                string __tmp21Line = "("; //53:72
                if (__tmp21Line != null) __out.Append(__tmp21Line);
                StringBuilder __tmp22 = new StringBuilder();
                __tmp22.Append(GetEnumImplParameters(enm, op));
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
                string __tmp23Line = ") {"; //53:105
                if (__tmp23Line != null) __out.Append(__tmp23Line);
                __out.AppendLine(false); //53:108
                string __tmp24Prefix = "        "; //54:1
                StringBuilder __tmp25 = new StringBuilder();
                __tmp25.Append(GetReturn(op));
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
                StringBuilder __tmp26 = new StringBuilder();
                __tmp26.Append(enm.Model.Name);
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
                string __tmp27Line = "ImplementationProvider.implementation()."; //54:40
                if (__tmp27Line != null) __out.Append(__tmp27Line);
                StringBuilder __tmp28 = new StringBuilder();
                __tmp28.Append(op.Parent.JavaName());
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
                string __tmp29Line = "_"; //54:102
                if (__tmp29Line != null) __out.Append(__tmp29Line);
                StringBuilder __tmp30 = new StringBuilder();
                __tmp30.Append(op.Name.ToCamelCase());
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
                string __tmp31Line = "("; //54:126
                if (__tmp31Line != null) __out.Append(__tmp31Line);
                StringBuilder __tmp32 = new StringBuilder();
                __tmp32.Append(GetEnumImplCallParameterNames(op));
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
                string __tmp33Line = ");"; //54:162
                if (__tmp33Line != null) __out.Append(__tmp33Line);
                __out.AppendLine(false); //54:164
                __out.Append("    }"); //55:1
                __out.AppendLine(false); //55:6
            }
            __out.Append("}"); //57:1
            __out.AppendLine(false); //57:2
            __out.AppendLine(true); //58:1
            return __out.ToString();
        }

        public string GetAncestors(MetaClass cls) //61:1
        {
            string result = ""; //62:2
            var __loop7_results = 
                (from __loop7_var1 in __Enumerate((cls).GetEnumerator()) //63:7
                from super in __Enumerate((__loop7_var1.SuperClasses).GetEnumerator()) //63:12
                select new { __loop7_var1 = __loop7_var1, super = super}
                ).ToList(); //63:2
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                string delim; //63:30
                if (__loop7_iteration+1 < __loop7_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop7_results[__loop7_iteration];
                var __loop7_var1 = __tmp1.__loop7_var1;
                var super = __tmp1.super;
                result += delim + super.JavaFullName(); //64:3
            }
            if (result != "") //66:2
            {
                result = " extends " + result; //67:3
            }
            return result; //69:2
        }

        public string GenerateInterface(MetaClass cls) //72:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "package "; //73:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.Namespace.JavaName());
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
            string __tmp4Line = ";"; //73:35
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //73:36
            __out.AppendLine(true); //74:1
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(GenerateAnnotations(cls));
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
                    __out.AppendLine(false); //75:27
                }
            }
            string __tmp8Line = "public interface "; //76:1
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(cls.JavaName());
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
            __tmp10.Append(GetAncestors(cls));
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
                    __out.AppendLine(false); //76:53
                }
            }
            __out.Append("{"); //77:1
            __out.AppendLine(false); //77:2
            var __loop8_results = 
                (from __loop8_var1 in __Enumerate((cls).GetEnumerator()) //78:11
                from prop in __Enumerate((__loop8_var1.Properties).GetEnumerator()) //78:16
                select new { __loop8_var1 = __loop8_var1, prop = prop}
                ).ToList(); //78:6
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp11 = __loop8_results[__loop8_iteration];
                var __loop8_var1 = __tmp11.__loop8_var1;
                var prop = __tmp11.prop;
                string __tmp12Prefix = "    "; //79:1
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(GenerateProperty(prop));
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
                        __out.AppendLine(false); //79:29
                    }
                }
            }
            __out.AppendLine(true); //81:1
            var __loop9_results = 
                (from __loop9_var1 in __Enumerate((cls).GetEnumerator()) //82:11
                from op in __Enumerate((__loop9_var1.Operations).GetEnumerator()) //82:16
                select new { __loop9_var1 = __loop9_var1, op = op}
                ).ToList(); //82:6
            for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
            {
                var __tmp14 = __loop9_results[__loop9_iteration];
                var __loop9_var1 = __tmp14.__loop9_var1;
                var op = __tmp14.op;
                string __tmp15Prefix = "    "; //83:1
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(GenerateOperation(op));
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
                        __out.AppendLine(false); //83:28
                    }
                }
            }
            __out.Append("}"); //85:1
            __out.AppendLine(false); //85:2
            __out.AppendLine(true); //86:1
            return __out.ToString();
        }

        public string GenerateProperty(MetaProperty prop) //89:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(prop.Type.JavaFullPublicName());
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
            string __tmp3Line = " "; //90:33
            if (__tmp3Line != null) __out.Append(__tmp3Line);
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(("get" + prop.Name).SafeJavaName());
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
            string __tmp5Line = "();"; //90:68
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            __out.AppendLine(false); //90:71
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //91:3
            {
                string __tmp7Line = "void "; //92:1
                if (__tmp7Line != null) __out.Append(__tmp7Line);
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(("set" + prop.Name).SafeJavaName());
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
                string __tmp9Line = "("; //92:40
                if (__tmp9Line != null) __out.Append(__tmp9Line);
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(prop.Type.JavaFullPublicName());
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
                string __tmp11Line = " value);"; //92:73
                if (__tmp11Line != null) __out.Append(__tmp11Line);
                __out.AppendLine(false); //92:81
            }
            return __out.ToString();
        }

        public string GetParameters(MetaOperation op, bool defaultValues) //96:1
        {
            string result = ""; //97:2
            var __loop10_results = 
                (from __loop10_var1 in __Enumerate((op).GetEnumerator()) //98:7
                from param in __Enumerate((__loop10_var1.Parameters).GetEnumerator()) //98:11
                select new { __loop10_var1 = __loop10_var1, param = param}
                ).ToList(); //98:2
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                string delim; //98:27
                if (__loop10_iteration+1 < __loop10_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop10_results[__loop10_iteration];
                var __loop10_var1 = __tmp1.__loop10_var1;
                var param = __tmp1.param;
                result += param.Type.JavaFullPublicName() + " " + param.Name + delim; //99:3
            }
            return result; //101:2
        }

        public string GetImplParameters(MetaClass cls, MetaOperation op) //104:1
        {
            string result = cls.JavaFullName() + " _this"; //105:2
            string delim = ", "; //106:2
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((op).GetEnumerator()) //107:7
                from param in __Enumerate((__loop11_var1.Parameters).GetEnumerator()) //107:11
                select new { __loop11_var1 = __loop11_var1, param = param}
                ).ToList(); //107:2
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp1 = __loop11_results[__loop11_iteration];
                var __loop11_var1 = __tmp1.__loop11_var1;
                var param = __tmp1.param;
                result += delim + param.Type.JavaFullPublicName() + " " + param.Name; //108:3
            }
            return result; //110:2
        }

        public string GetImplParameters(MetaEnum enm, MetaOperation op) //113:1
        {
            string result = enm.JavaFullName() + " _this"; //114:2
            string delim = ", "; //115:2
            var __loop12_results = 
                (from __loop12_var1 in __Enumerate((op).GetEnumerator()) //116:7
                from param in __Enumerate((__loop12_var1.Parameters).GetEnumerator()) //116:11
                select new { __loop12_var1 = __loop12_var1, param = param}
                ).ToList(); //116:2
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp1 = __loop12_results[__loop12_iteration];
                var __loop12_var1 = __tmp1.__loop12_var1;
                var param = __tmp1.param;
                result += delim + param.Type.JavaFullPublicName() + " " + param.Name; //117:3
            }
            return result; //119:2
        }

        public string GetEnumImplParameters(MetaEnum enm, MetaOperation op) //122:1
        {
            string result = enm.JavaFullName() + " _this"; //123:2
            string delim = ", "; //124:2
            var __loop13_results = 
                (from __loop13_var1 in __Enumerate((op).GetEnumerator()) //125:7
                from param in __Enumerate((__loop13_var1.Parameters).GetEnumerator()) //125:11
                select new { __loop13_var1 = __loop13_var1, param = param}
                ).ToList(); //125:2
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp1 = __loop13_results[__loop13_iteration];
                var __loop13_var1 = __tmp1.__loop13_var1;
                var param = __tmp1.param;
                result += delim + param.Type.JavaFullPublicName() + " " + param.Name; //126:3
            }
            return result; //128:2
        }

        public string GetEnumImplCallParameterNames(MetaOperation op) //131:1
        {
            string result = "_this"; //132:2
            string delim = ", "; //133:2
            var __loop14_results = 
                (from __loop14_var1 in __Enumerate((op).GetEnumerator()) //134:7
                from param in __Enumerate((__loop14_var1.Parameters).GetEnumerator()) //134:11
                select new { __loop14_var1 = __loop14_var1, param = param}
                ).ToList(); //134:2
            for (int __loop14_iteration = 0; __loop14_iteration < __loop14_results.Count; ++__loop14_iteration)
            {
                var __tmp1 = __loop14_results[__loop14_iteration];
                var __loop14_var1 = __tmp1.__loop14_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //135:3
            }
            return result; //137:2
        }

        public string GetImplCallParameterNames(MetaOperation op) //140:1
        {
            string result = "this"; //141:2
            string delim = ", "; //142:2
            var __loop15_results = 
                (from __loop15_var1 in __Enumerate((op).GetEnumerator()) //143:7
                from param in __Enumerate((__loop15_var1.Parameters).GetEnumerator()) //143:11
                select new { __loop15_var1 = __loop15_var1, param = param}
                ).ToList(); //143:2
            for (int __loop15_iteration = 0; __loop15_iteration < __loop15_results.Count; ++__loop15_iteration)
            {
                var __tmp1 = __loop15_results[__loop15_iteration];
                var __loop15_var1 = __tmp1.__loop15_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //144:3
            }
            return result; //146:2
        }

        public string GenerateOperation(MetaOperation op) //149:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(op.ReturnType.JavaFullPublicName());
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
            string __tmp3Line = " "; //150:37
            if (__tmp3Line != null) __out.Append(__tmp3Line);
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(op.Name.ToCamelCase());
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
            string __tmp5Line = "("; //150:61
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
            string __tmp7Line = ");"; //150:87
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //150:89
            return __out.ToString();
        }

        public string GenerateInterfaceImpl(MetaModel model, MetaClass cls) //153:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "package "; //154:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.Namespace.JavaName());
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
            string __tmp4Line = ";"; //154:35
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //154:36
            __out.AppendLine(true); //155:1
            if ((from __loop16_var1 in __Enumerate((cls).GetEnumerator()) //156:13
            from prop in __Enumerate((__loop16_var1.GetAllProperties()).GetEnumerator()) //156:18
            where prop.Type is MetaCollectionType //156:42
            select new { __loop16_var1 = __loop16_var1, prop = prop}
            ).GetEnumerator().MoveNext()) //156:2
            {
                __out.Append("@SuppressWarnings(\"unchecked\")"); //157:1
                __out.AppendLine(false); //157:31
            }
            string __tmp6Line = "class "; //159:1
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(cls.JavaImplName());
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
            string __tmp8Line = " extends metadslx.core.ModelObject implements "; //159:27
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(cls.JavaFullName());
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
            string __tmp10Line = " {"; //159:93
            if (__tmp10Line != null) __out.Append(__tmp10Line);
            __out.AppendLine(false); //159:95
            __out.Append("    static {"); //160:1
            __out.AppendLine(false); //160:13
            string __tmp11Prefix = "        "; //161:1
            StringBuilder __tmp12 = new StringBuilder();
            __tmp12.Append(cls.Model.JavaFullDescriptorName());
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
                }
            }
            string __tmp13Line = ".staticInit();"; //161:45
            if (__tmp13Line != null) __out.Append(__tmp13Line);
            __out.AppendLine(false); //161:59
            __out.Append("    }"); //162:1
            __out.AppendLine(false); //162:6
            __out.AppendLine(true); //163:1
            __out.Append("	@Override"); //164:1
            __out.AppendLine(false); //164:11
            __out.Append("    public metadslx.core.MetaModel mMetaModel() {"); //165:1
            __out.AppendLine(false); //165:50
            string __tmp15Line = "        return "; //166:1
            if (__tmp15Line != null) __out.Append(__tmp15Line);
            StringBuilder __tmp16 = new StringBuilder();
            __tmp16.Append(cls.Model.JavaFullInstanceName());
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
            string __tmp17Line = "; "; //166:50
            if (__tmp17Line != null) __out.Append(__tmp17Line);
            __out.AppendLine(false); //166:52
            __out.Append("    }"); //167:1
            __out.AppendLine(false); //167:6
            __out.AppendLine(true); //168:1
            __out.Append("	@Override"); //169:1
            __out.AppendLine(false); //169:11
            __out.Append("    public metadslx.core.MetaClass mMetaClass() {"); //170:1
            __out.AppendLine(false); //170:50
            string __tmp19Line = "        return "; //171:1
            if (__tmp19Line != null) __out.Append(__tmp19Line);
            StringBuilder __tmp20 = new StringBuilder();
            __tmp20.Append(cls.JavaFullInstanceName());
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
            string __tmp21Line = "; "; //171:44
            if (__tmp21Line != null) __out.Append(__tmp21Line);
            __out.AppendLine(false); //171:46
            __out.Append("    }"); //172:1
            __out.AppendLine(false); //172:6
            __out.AppendLine(true); //173:1
            string __tmp22Prefix = "    "; //174:1
            StringBuilder __tmp23 = new StringBuilder();
            __tmp23.Append(GenerateConstructorImpl(model, cls));
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
                    __out.AppendLine(false); //174:42
                }
            }
            HashSet<string> propMethodNames = new HashSet<string>(); //175:3
            var __loop17_results = 
                (from __loop17_var1 in __Enumerate((cls).GetEnumerator()) //176:11
                from prop in __Enumerate((__loop17_var1.GetAllProperties()).GetEnumerator()) //176:16
                select new { __loop17_var1 = __loop17_var1, prop = prop}
                ).ToList(); //176:6
            for (int __loop17_iteration = 0; __loop17_iteration < __loop17_results.Count; ++__loop17_iteration)
            {
                var __tmp24 = __loop17_results[__loop17_iteration];
                var __loop17_var1 = __tmp24.__loop17_var1;
                var prop = __tmp24.prop;
                string __tmp25Prefix = "    "; //177:1
                StringBuilder __tmp26 = new StringBuilder();
                __tmp26.Append(GeneratePropertyImpl(model, cls, prop, propMethodNames));
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
                        __out.AppendLine(false); //177:62
                    }
                }
            }
            HashSet<string> methodNames = new HashSet<string>(); //179:3
            var __loop18_results = 
                (from __loop18_var1 in __Enumerate((cls).GetEnumerator()) //180:11
                from op in __Enumerate((__loop18_var1.GetAllOperations()).GetEnumerator()) //180:16
                select new { __loop18_var1 = __loop18_var1, op = op}
                ).ToList(); //180:6
            for (int __loop18_iteration = 0; __loop18_iteration < __loop18_results.Count; ++__loop18_iteration)
            {
                var __tmp27 = __loop18_results[__loop18_iteration];
                var __loop18_var1 = __tmp27.__loop18_var1;
                var op = __tmp27.op;
                string __tmp28Prefix = "    "; //181:1
                StringBuilder __tmp29 = new StringBuilder();
                __tmp29.Append(GenerateOperationImpl(model, op, methodNames));
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
                        __out.AppendLine(false); //181:52
                    }
                }
            }
            __out.Append("}"); //183:1
            __out.AppendLine(false); //183:2
            __out.AppendLine(true); //184:1
            return __out.ToString();
        }

        public string GeneratePropertyDeclaration(MetaModel model, MetaClass cls, MetaProperty prop) //187:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class == cls) //188:2
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
                        __out.AppendLine(false); //189:28
                    }
                }
                if (prop.Kind == MetaPropertyKind.Containment) //190:2
                {
                    __out.Append("@metadslx.core.Containment"); //191:1
                    __out.AppendLine(false); //191:27
                }
                if (prop.Kind != MetaPropertyKind.Normal && prop.Kind != MetaPropertyKind.Containment) //193:2
                {
                    __out.Append("@metadslx.core.Readonly"); //194:1
                    __out.AppendLine(false); //194:24
                }
                var __loop19_results = 
                    (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //196:7
                    select new { p = p}
                    ).ToList(); //196:2
                for (int __loop19_iteration = 0; __loop19_iteration < __loop19_results.Count; ++__loop19_iteration)
                {
                    var __tmp3 = __loop19_results[__loop19_iteration];
                    var p = __tmp3.p;
                    string __tmp5Line = "@metadslx.core.Opposite(declaringType="; //197:1
                    if (__tmp5Line != null) __out.Append(__tmp5Line);
                    StringBuilder __tmp6 = new StringBuilder();
                    __tmp6.Append(p.Class.JavaFullDescriptorName());
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
                    string __tmp7Line = ".class, propertyName=\""; //197:73
                    if (__tmp7Line != null) __out.Append(__tmp7Line);
                    StringBuilder __tmp8 = new StringBuilder();
                    __tmp8.Append(p.Name);
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
                    string __tmp9Line = "\")"; //197:103
                    if (__tmp9Line != null) __out.Append(__tmp9Line);
                    __out.AppendLine(false); //197:105
                }
                var __loop20_results = 
                    (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //199:7
                    select new { p = p}
                    ).ToList(); //199:2
                for (int __loop20_iteration = 0; __loop20_iteration < __loop20_results.Count; ++__loop20_iteration)
                {
                    var __tmp10 = __loop20_results[__loop20_iteration];
                    var p = __tmp10.p;
                    if (cls.GetAllSuperClasses(false).Contains(p.Class)) //200:3
                    {
                        string __tmp12Line = "@metadslx.core.Subsets(declaringType="; //201:1
                        if (__tmp12Line != null) __out.Append(__tmp12Line);
                        StringBuilder __tmp13 = new StringBuilder();
                        __tmp13.Append(p.Class.JavaFullDescriptorName());
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
                        string __tmp14Line = ".class, propertyName=\""; //201:72
                        if (__tmp14Line != null) __out.Append(__tmp14Line);
                        StringBuilder __tmp15 = new StringBuilder();
                        __tmp15.Append(p.Name);
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
                        string __tmp16Line = "\")"; //201:102
                        if (__tmp16Line != null) __out.Append(__tmp16Line);
                        __out.AppendLine(false); //201:104
                    }
                    else //202:3
                    {
                        string __tmp18Line = "// ERROR: subsetted property '"; //203:1
                        if (__tmp18Line != null) __out.Append(__tmp18Line);
                        StringBuilder __tmp19 = new StringBuilder();
                        __tmp19.Append(p.JavaFullDescriptorName());
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
                        string __tmp20Line = "' must be a property of an ancestor class"; //203:59
                        if (__tmp20Line != null) __out.Append(__tmp20Line);
                        __out.AppendLine(false); //203:100
                    }
                }
                var __loop21_results = 
                    (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //206:7
                    select new { p = p}
                    ).ToList(); //206:2
                for (int __loop21_iteration = 0; __loop21_iteration < __loop21_results.Count; ++__loop21_iteration)
                {
                    var __tmp21 = __loop21_results[__loop21_iteration];
                    var p = __tmp21.p;
                    if (cls.GetAllSuperClasses(false).Contains(p.Class)) //207:3
                    {
                        string __tmp23Line = "@metadslx.core.Redefines(declaringType="; //208:1
                        if (__tmp23Line != null) __out.Append(__tmp23Line);
                        StringBuilder __tmp24 = new StringBuilder();
                        __tmp24.Append(p.Class.JavaFullDescriptorName());
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
                        string __tmp25Line = ".class, propertyName=\""; //208:74
                        if (__tmp25Line != null) __out.Append(__tmp25Line);
                        StringBuilder __tmp26 = new StringBuilder();
                        __tmp26.Append(p.Name);
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
                        string __tmp27Line = "\")"; //208:104
                        if (__tmp27Line != null) __out.Append(__tmp27Line);
                        __out.AppendLine(false); //208:106
                    }
                    else //209:3
                    {
                        string __tmp29Line = "// ERROR: redefined property '"; //210:1
                        if (__tmp29Line != null) __out.Append(__tmp29Line);
                        StringBuilder __tmp30 = new StringBuilder();
                        __tmp30.Append(p.JavaFullDescriptorName());
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
                        string __tmp31Line = "' must be a property of an ancestor class"; //210:59
                        if (__tmp31Line != null) __out.Append(__tmp31Line);
                        __out.AppendLine(false); //210:100
                    }
                }
                if (prop.Type is MetaCollectionType) //213:2
                {
                    string __tmp33Line = "public static final metadslx.core.ModelProperty "; //214:1
                    if (__tmp33Line != null) __out.Append(__tmp33Line);
                    StringBuilder __tmp34 = new StringBuilder();
                    __tmp34.Append(prop.Name);
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
                    string __tmp35Line = "Property ="; //214:60
                    if (__tmp35Line != null) __out.Append(__tmp35Line);
                    __out.AppendLine(false); //214:70
                    string __tmp37Line = "    metadslx.core.ModelProperty.register(\""; //215:1
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
                    string __tmp39Line = "\", "; //215:54
                    if (__tmp39Line != null) __out.Append(__tmp39Line);
                    StringBuilder __tmp40 = new StringBuilder();
                    __tmp40.Append(prop.Type.JavaNonGenericFullName());
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
                    string __tmp41Line = ".class, "; //215:93
                    if (__tmp41Line != null) __out.Append(__tmp41Line);
                    StringBuilder __tmp42 = new StringBuilder();
                    __tmp42.Append(((MetaCollectionType)prop.Type).InnerType.JavaNonGenericFullName());
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
                    string __tmp43Line = ".class, "; //215:169
                    if (__tmp43Line != null) __out.Append(__tmp43Line);
                    StringBuilder __tmp44 = new StringBuilder();
                    __tmp44.Append(prop.Class.JavaFullName());
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
                    string __tmp45Line = ".class, "; //215:204
                    if (__tmp45Line != null) __out.Append(__tmp45Line);
                    StringBuilder __tmp46 = new StringBuilder();
                    __tmp46.Append(prop.Class.Model.JavaFullName());
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
                    string __tmp47Line = "Descriptor."; //215:245
                    if (__tmp47Line != null) __out.Append(__tmp47Line);
                    StringBuilder __tmp48 = new StringBuilder();
                    __tmp48.Append(prop.Class.JavaName());
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
                    string __tmp49Line = ".class, metadslx.core.Lazy.create(() -> "; //215:279
                    if (__tmp49Line != null) __out.Append(__tmp49Line);
                    StringBuilder __tmp50 = new StringBuilder();
                    __tmp50.Append(prop.Class.Model.JavaFullName());
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
                    string __tmp51Line = "Instance."; //215:352
                    if (__tmp51Line != null) __out.Append(__tmp51Line);
                    StringBuilder __tmp52 = new StringBuilder();
                    __tmp52.Append(prop.Class.JavaName());
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
                    string __tmp53Line = "_"; //215:384
                    if (__tmp53Line != null) __out.Append(__tmp53Line);
                    StringBuilder __tmp54 = new StringBuilder();
                    __tmp54.Append(prop.Name);
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
                    string __tmp55Line = "Property, true));"; //215:396
                    if (__tmp55Line != null) __out.Append(__tmp55Line);
                    __out.AppendLine(false); //215:413
                }
                else //216:2
                {
                    string __tmp57Line = "public static final metadslx.core.ModelProperty "; //217:1
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
                    string __tmp59Line = "Property ="; //217:60
                    if (__tmp59Line != null) __out.Append(__tmp59Line);
                    __out.AppendLine(false); //217:70
                    string __tmp61Line = "    metadslx.core.ModelProperty.register(\""; //218:1
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
                    string __tmp63Line = "\", "; //218:54
                    if (__tmp63Line != null) __out.Append(__tmp63Line);
                    StringBuilder __tmp64 = new StringBuilder();
                    __tmp64.Append(prop.Type.JavaFullPublicName());
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
                    string __tmp65Line = ".class, null, "; //218:89
                    if (__tmp65Line != null) __out.Append(__tmp65Line);
                    StringBuilder __tmp66 = new StringBuilder();
                    __tmp66.Append(prop.Class.JavaFullName());
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
                    string __tmp67Line = ".class, "; //218:130
                    if (__tmp67Line != null) __out.Append(__tmp67Line);
                    StringBuilder __tmp68 = new StringBuilder();
                    __tmp68.Append(prop.Class.Model.JavaFullName());
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
                    string __tmp69Line = "Descriptor."; //218:171
                    if (__tmp69Line != null) __out.Append(__tmp69Line);
                    StringBuilder __tmp70 = new StringBuilder();
                    __tmp70.Append(prop.Class.JavaName());
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
                    string __tmp71Line = ".class, metadslx.core.Lazy.create(() -> "; //218:205
                    if (__tmp71Line != null) __out.Append(__tmp71Line);
                    StringBuilder __tmp72 = new StringBuilder();
                    __tmp72.Append(prop.Class.Model.JavaFullName());
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
                    string __tmp73Line = "Instance."; //218:278
                    if (__tmp73Line != null) __out.Append(__tmp73Line);
                    StringBuilder __tmp74 = new StringBuilder();
                    __tmp74.Append(prop.Class.JavaName());
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
                    string __tmp75Line = "_"; //218:310
                    if (__tmp75Line != null) __out.Append(__tmp75Line);
                    StringBuilder __tmp76 = new StringBuilder();
                    __tmp76.Append(prop.Name);
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
                    string __tmp77Line = "Property, true));"; //218:322
                    if (__tmp77Line != null) __out.Append(__tmp77Line);
                    __out.AppendLine(false); //218:339
                }
            }
            __out.AppendLine(true); //221:1
            return __out.ToString();
        }

        public string GeneratePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop, HashSet<string> generated) //224:1
        {
            StringBuilder __out = new StringBuilder();
            if (generated.Add("get" + prop.Name)) //225:2
            {
                __out.AppendLine(true); //226:1
                string __tmp2Line = "public "; //227:1
                if (__tmp2Line != null) __out.Append(__tmp2Line);
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(prop.Type.JavaFullPublicName());
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
                string __tmp4Line = " "; //227:40
                if (__tmp4Line != null) __out.Append(__tmp4Line);
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(("get" + prop.Name).SafeJavaName());
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
                string __tmp6Line = "() {"; //227:75
                if (__tmp6Line != null) __out.Append(__tmp6Line);
                __out.AppendLine(false); //227:79
                string __tmp8Line = "    Object result = this.mGet("; //228:1
                if (__tmp8Line != null) __out.Append(__tmp8Line);
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append(prop.JavaFullDescriptorName());
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
                string __tmp10Line = "); "; //228:62
                if (__tmp10Line != null) __out.Append(__tmp10Line);
                __out.AppendLine(false); //228:65
                string __tmp12Line = "    if (result != null) return ("; //229:1
                if (__tmp12Line != null) __out.Append(__tmp12Line);
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(prop.Type.JavaFullPublicName());
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
                string __tmp14Line = ")result;"; //229:65
                if (__tmp14Line != null) __out.Append(__tmp14Line);
                __out.AppendLine(false); //229:73
                string __tmp16Line = "    else return ("; //230:1
                if (__tmp16Line != null) __out.Append(__tmp16Line);
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(prop.Type.JavaFullPublicName());
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
                string __tmp18Line = ")"; //230:50
                if (__tmp18Line != null) __out.Append(__tmp18Line);
                StringBuilder __tmp19 = new StringBuilder();
                __tmp19.Append(prop.Type.JavaDefaultValue());
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
                string __tmp20Line = ";"; //230:81
                if (__tmp20Line != null) __out.Append(__tmp20Line);
                __out.AppendLine(false); //230:82
                __out.Append("}"); //231:1
                __out.AppendLine(false); //231:2
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //233:2
            {
                if (generated.Add("set" + prop.Name)) //234:2
                {
                    __out.AppendLine(true); //235:1
                    string __tmp22Line = "public void "; //236:1
                    if (__tmp22Line != null) __out.Append(__tmp22Line);
                    StringBuilder __tmp23 = new StringBuilder();
                    __tmp23.Append(("set" + prop.Name).SafeJavaName());
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
                    string __tmp24Line = "("; //236:47
                    if (__tmp24Line != null) __out.Append(__tmp24Line);
                    StringBuilder __tmp25 = new StringBuilder();
                    __tmp25.Append(prop.Type.JavaFullPublicName());
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
                    string __tmp26Line = " value) {"; //236:80
                    if (__tmp26Line != null) __out.Append(__tmp26Line);
                    __out.AppendLine(false); //236:89
                    string __tmp28Line = "    this.mSet("; //237:1
                    if (__tmp28Line != null) __out.Append(__tmp28Line);
                    StringBuilder __tmp29 = new StringBuilder();
                    __tmp29.Append(prop.JavaFullDescriptorName());
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
                    string __tmp30Line = ", value);"; //237:46
                    if (__tmp30Line != null) __out.Append(__tmp30Line);
                    __out.AppendLine(false); //237:55
                    __out.Append("}"); //238:1
                    __out.AppendLine(false); //238:2
                }
            }
            return __out.ToString();
        }

        public string GetCollectionConstructorParams(MetaProperty prop) //243:1
        {
            MetaCollectionType mct = prop.Type as MetaCollectionType; //244:2
            if (mct != null && mct.InnerType is MetaClass) //245:2
            {
                return "this, " + prop.JavaFullDescriptorName(); //246:3
            }
            else //247:2
            {
                return ""; //248:3
            }
        }

        public string GenerateExpression(MetaExpression expr) //253:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //254:10
            if (expr is MetaBracketExpression) //255:2
            {
                string __tmp4Line = "("; //255:33
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
                string __tmp6Line = ")"; //255:71
                if (__tmp6Line != null) __out.Append(__tmp6Line);
            }
            else if (expr is MetaThisExpression) //256:2
            {
                string __tmp9Line = "(("; //256:30
                if (__tmp9Line != null) __out.Append(__tmp9Line);
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(((MetaType)ModelCompilerContext.Current.ResolutionProvider.GetCurrentTypeScopeOf((ModelObject)((MetaThisExpression)expr))).JavaName());
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
                string __tmp11Line = ")this)"; //256:145
                if (__tmp11Line != null) __out.Append(__tmp11Line);
            }
            else if (expr is MetaNullExpression) //257:2
            {
                __out.Append("null"); //257:30
            }
            else if (expr is MetaTypeAsExpression) //258:2
            {
                string __tmp14Line = "metadslx.core.ModelUtils.as("; //258:32
                if (__tmp14Line != null) __out.Append(__tmp14Line);
                StringBuilder __tmp15 = new StringBuilder();
                __tmp15.Append(((MetaTypeAsExpression)expr).TypeReference.JavaName());
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
                string __tmp16Line = ".class,"; //258:91
                if (__tmp16Line != null) __out.Append(__tmp16Line);
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(GenerateExpression(((MetaTypeAsExpression)expr).Expression));
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
                string __tmp18Line = ")"; //258:135
                if (__tmp18Line != null) __out.Append(__tmp18Line);
            }
            else if (expr is MetaTypeCastExpression) //259:2
            {
                string __tmp21Line = "("; //259:34
                if (__tmp21Line != null) __out.Append(__tmp21Line);
                StringBuilder __tmp22 = new StringBuilder();
                __tmp22.Append(((MetaTypeCastExpression)expr).TypeReference.JavaName());
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
                string __tmp23Line = ")"; //259:66
                if (__tmp23Line != null) __out.Append(__tmp23Line);
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(GenerateExpression(((MetaTypeCastExpression)expr).Expression));
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
            }
            else if (expr is MetaTypeCheckExpression) //260:2
            {
                StringBuilder __tmp27 = new StringBuilder();
                __tmp27.Append(GenerateExpression(((MetaTypeCheckExpression)expr).Expression));
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
                string __tmp28Line = " instanceof "; //260:72
                if (__tmp28Line != null) __out.Append(__tmp28Line);
                StringBuilder __tmp29 = new StringBuilder();
                __tmp29.Append(((MetaTypeCheckExpression)expr).TypeReference.JavaName());
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
            }
            else if (expr is MetaTypeOfExpression) //261:2
            {
                StringBuilder __tmp32 = new StringBuilder();
                __tmp32.Append(GenerateTypeOf(((MetaTypeOfExpression)expr)));
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
            else if (expr is MetaConditionalExpression) //262:2
            {
                StringBuilder __tmp35 = new StringBuilder();
                __tmp35.Append(GenerateExpression(((MetaConditionalExpression)expr).Condition));
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
                string __tmp36Line = " ? "; //262:73
                if (__tmp36Line != null) __out.Append(__tmp36Line);
                StringBuilder __tmp37 = new StringBuilder();
                __tmp37.Append(GenerateExpression(((MetaConditionalExpression)expr).Then));
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
                string __tmp38Line = " : "; //262:107
                if (__tmp38Line != null) __out.Append(__tmp38Line);
                StringBuilder __tmp39 = new StringBuilder();
                __tmp39.Append(GenerateExpression(((MetaConditionalExpression)expr).Else));
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
            }
            else if (expr is MetaConstantExpression) //263:2
            {
                StringBuilder __tmp42 = new StringBuilder();
                __tmp42.Append(GetJavaValue(((MetaConstantExpression)expr).Value));
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
            }
            else if (expr is MetaIdentifierExpression) //264:2
            {
                StringBuilder __tmp45 = new StringBuilder();
                __tmp45.Append(GenerateIdentifierExpression(((MetaIdentifierExpression)expr)));
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
            }
            else if (expr is MetaMemberAccessExpression) //265:2
            {
                StringBuilder __tmp48 = new StringBuilder();
                __tmp48.Append(GenerateExpression(((MetaMemberAccessExpression)expr).Expression));
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
                string __tmp49Line = ".get"; //265:75
                if (__tmp49Line != null) __out.Append(__tmp49Line);
                StringBuilder __tmp50 = new StringBuilder();
                __tmp50.Append(((MetaMemberAccessExpression)expr).Name);
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
                string __tmp51Line = "()"; //265:90
                if (__tmp51Line != null) __out.Append(__tmp51Line);
            }
            else if (expr is MetaFunctionCallExpression) //266:2
            {
                StringBuilder __tmp54 = new StringBuilder();
                __tmp54.Append(GenerateFunctionCall(((MetaFunctionCallExpression)expr)));
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
            else if (expr is MetaIndexerExpression) //267:2
            {
                StringBuilder __tmp57 = new StringBuilder();
                __tmp57.Append(GenerateIndexerCall(((MetaIndexerExpression)expr)));
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
            else if (expr is MetaOperatorExpression) //268:2
            {
                StringBuilder __tmp60 = new StringBuilder();
                __tmp60.Append(GenerateOperator(((MetaOperatorExpression)expr)));
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
            }
            else if (expr is MetaNewExpression) //269:2
            {
                StringBuilder __tmp63 = new StringBuilder();
                __tmp63.Append(((MetaNewExpression)expr).TypeReference.JavaFullFactoryMethodName());
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
                string __tmp64Line = "("; //269:77
                if (__tmp64Line != null) __out.Append(__tmp64Line);
                StringBuilder __tmp65 = new StringBuilder();
                __tmp65.Append(GenerateNewPropertyInitializers(((MetaNewExpression)expr)));
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
                string __tmp66Line = ")"; //269:117
                if (__tmp66Line != null) __out.Append(__tmp66Line);
            }
            else if (expr is MetaNewCollectionExpression) //270:2
            {
                string __tmp69Line = "new java.util.ArrayList<metadslx.core.Lazy<Object>>() { "; //270:39
                if (__tmp69Line != null) __out.Append(__tmp69Line);
                StringBuilder __tmp70 = new StringBuilder();
                __tmp70.Append(GenerateNewCollectionValues(((MetaNewCollectionExpression)expr)));
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
                string __tmp71Line = " }"; //270:130
                if (__tmp71Line != null) __out.Append(__tmp71Line);
            }
            else //271:2
            {
                __out.Append("***unknown expression type***"); //271:11
                __out.AppendLine(false); //271:40
            }//272:2
            return __out.ToString();
        }

        public string GenerateIdentifierExpression(MetaIdentifierExpression expr) //275:1
        {
            StringBuilder __out = new StringBuilder();
            if (expr.Definition is MetaProperty) //276:2
            {
                string __tmp2Line = "(("; //277:1
                if (__tmp2Line != null) __out.Append(__tmp2Line);
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(((MetaType)ModelCompilerContext.Current.ResolutionProvider.GetCurrentTypeScopeOf((ModelObject)expr)).JavaName());
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
                string __tmp4Line = ")this).get"; //277:116
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
                string __tmp6Line = "()"; //277:137
                if (__tmp6Line != null) __out.Append(__tmp6Line);
            }
            else //278:2
            {
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(expr.Name);
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
            }
            return __out.ToString();
        }

        public bool SameFunction(MetaGlobalFunction mfunc1, MetaGlobalFunction mfunc2) //283:1
        {
            return mfunc1.Name == mfunc2.Name && ModelCompilerContext.Current.TypeProvider.Equals((ModelObject)mfunc1.Type, (ModelObject)mfunc2.Type); //284:2
        }

        public string GenerateFunctionCall(MetaFunctionCallExpression call) //287:1
        {
            StringBuilder __out = new StringBuilder();
            if (call.Definition is MetaGlobalFunction && SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.TypeOf)) //288:2
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
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.GetValueType)) //289:2
            {
                string __tmp6Line = "metadslx.core.ModelCompilerContext.current().getTypeProvider().getTypeOf("; //289:89
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
                string __tmp8Line = ")"; //289:195
                if (__tmp8Line != null) __out.Append(__tmp8Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.GetReturnType)) //290:2
            {
                string __tmp11Line = "metadslx.core.ModelCompilerContext.current().getTypeProvider().getReturnTypeOf("; //290:90
                if (__tmp11Line != null) __out.Append(__tmp11Line);
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(GenerateCallArguments(call, "(metadslx.core.ModelObject)"));
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
                string __tmp13Line = ")"; //290:229
                if (__tmp13Line != null) __out.Append(__tmp13Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.CurrentType)) //291:2
            {
                string __tmp16Line = "metadslx.core.ModelCompilerContext.current().getResolutionProvider().getCurrentTypeScopeOf("; //291:88
                if (__tmp16Line != null) __out.Append(__tmp16Line);
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(GenerateCallArguments(call, "(metadslx.core.ModelObject)"));
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
                string __tmp18Line = ")"; //291:239
                if (__tmp18Line != null) __out.Append(__tmp18Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.TypeCheck)) //292:2
            {
                string __tmp21Line = "metadslx.core.ModelCompilerContext.current().getTypeProvider().typeCheck("; //292:86
                if (__tmp21Line != null) __out.Append(__tmp21Line);
                StringBuilder __tmp22 = new StringBuilder();
                __tmp22.Append(GenerateCallArguments(call, "(metadslx.core.ModelObject)"));
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
                string __tmp23Line = ")"; //292:219
                if (__tmp23Line != null) __out.Append(__tmp23Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Balance)) //293:2
            {
                string __tmp26Line = "metadslx.core.ModelCompilerContext.current().getTypeProvider().balance("; //293:84
                if (__tmp26Line != null) __out.Append(__tmp26Line);
                StringBuilder __tmp27 = new StringBuilder();
                __tmp27.Append(GenerateCallArguments(call, "(metadslx.core.ModelObject)"));
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
                string __tmp28Line = ")"; //293:215
                if (__tmp28Line != null) __out.Append(__tmp28Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Resolve1)) //294:2
            {
                string __tmp31Line = "metadslx.core.ModelCompilerContext.current().getResolutionProvider().resolve(new metadslx.core.ResolutionInfo(metadslx.core.ModelCompilerContext.current().getResolutionProvider().getCurrentScope(this), metadslx.core.ResolveKind.NameOrType, "; //294:85
                if (__tmp31Line != null) __out.Append(__tmp31Line);
                StringBuilder __tmp32 = new StringBuilder();
                __tmp32.Append(GenerateExpression(call.Arguments[0]));
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
                string __tmp33Line = "))"; //294:364
                if (__tmp33Line != null) __out.Append(__tmp33Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Resolve2)) //295:2
            {
                string __tmp36Line = "metadslx.core.ModelCompilerContext.current().getResolutionProvider().resolve(new metadslx.core.ResolutionInfo((metadslx.core.ModelObject)"; //295:85
                if (__tmp36Line != null) __out.Append(__tmp36Line);
                StringBuilder __tmp37 = new StringBuilder();
                __tmp37.Append(GenerateExpression(call.Arguments[0]));
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
                string __tmp38Line = ", metadslx.core.ResolveKind.NameOrType, "; //295:261
                if (__tmp38Line != null) __out.Append(__tmp38Line);
                StringBuilder __tmp39 = new StringBuilder();
                __tmp39.Append(GenerateExpression(call.Arguments[1]));
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
                string __tmp40Line = "))"; //295:340
                if (__tmp40Line != null) __out.Append(__tmp40Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveType1)) //296:2
            {
                string __tmp43Line = "metadslx.core.ModelCompilerContext.current().getResolutionProvider().resolve(new metadslx.core.ResolutionInfo(metadslx.core.ModelCompilerContext.current().getResolutionProvider().getCurrentScope(this), metadslx.core.ResolveKind.Type, "; //296:89
                if (__tmp43Line != null) __out.Append(__tmp43Line);
                StringBuilder __tmp44 = new StringBuilder();
                __tmp44.Append(GenerateExpression(call.Arguments[0]));
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
                string __tmp45Line = "))"; //296:362
                if (__tmp45Line != null) __out.Append(__tmp45Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveType2)) //297:2
            {
                string __tmp48Line = "metadslx.core.ModelCompilerContext.current().getResolutionProvider().resolve(new metadslx.core.ResolutionInfo((metadslx.core.ModelObject)"; //297:89
                if (__tmp48Line != null) __out.Append(__tmp48Line);
                StringBuilder __tmp49 = new StringBuilder();
                __tmp49.Append(GenerateExpression(call.Arguments[0]));
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
                string __tmp50Line = ", metadslx.core.ResolveKind.Type, "; //297:265
                if (__tmp50Line != null) __out.Append(__tmp50Line);
                StringBuilder __tmp51 = new StringBuilder();
                __tmp51.Append(GenerateExpression(call.Arguments[1]));
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
                string __tmp52Line = "))"; //297:338
                if (__tmp52Line != null) __out.Append(__tmp52Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveName1)) //298:2
            {
                string __tmp55Line = "metadslx.core.ModelCompilerContext.current().getResolutionProvider().resolve(new metadslx.core.ResolutionInfo(metadslx.core.ModelCompilerContext.current().getResolutionProvider().getCurrentScope(this), metadslx.core.ResolveKind.Name, "; //298:89
                if (__tmp55Line != null) __out.Append(__tmp55Line);
                StringBuilder __tmp56 = new StringBuilder();
                __tmp56.Append(GenerateExpression(call.Arguments[0]));
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
                string __tmp57Line = "))"; //298:362
                if (__tmp57Line != null) __out.Append(__tmp57Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveName2)) //299:2
            {
                string __tmp60Line = "metadslx.core.ModelCompilerContext.current().getResolutionProvider().resolve(new metadslx.core.ResolutionInfo((metadslx.core.ModelObject)"; //299:89
                if (__tmp60Line != null) __out.Append(__tmp60Line);
                StringBuilder __tmp61 = new StringBuilder();
                __tmp61.Append(GenerateExpression(call.Arguments[0]));
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
                string __tmp62Line = ", metadslx.core.ResolveKind.Name, "; //299:265
                if (__tmp62Line != null) __out.Append(__tmp62Line);
                StringBuilder __tmp63 = new StringBuilder();
                __tmp63.Append(GenerateExpression(call.Arguments[1]));
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
                string __tmp64Line = "))"; //299:338
                if (__tmp64Line != null) __out.Append(__tmp64Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ToDefinitionList)) //300:2
            {
                string __tmp67Line = "metadslx.core.BindingInfo.createFromDefinitions((metadslx.core.ModelObject)"; //300:93
                if (__tmp67Line != null) __out.Append(__tmp67Line);
                StringBuilder __tmp68 = new StringBuilder();
                __tmp68.Append(GenerateExpression(call.Arguments[0]));
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
                string __tmp69Line = ")"; //300:207
                if (__tmp69Line != null) __out.Append(__tmp69Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind1)) //301:2
            {
                string __tmp72Line = "metadslx.core.ModelCompilerContext.current().getBindingProvider().bind(null, "; //301:82
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
                string __tmp74Line = ")"; //301:198
                if (__tmp74Line != null) __out.Append(__tmp74Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind2)) //302:2
            {
                string __tmp77Line = "metadslx.core.ModelCompilerContext.current().getBindingProvider().bind((metadslx.core.ModelObject)"; //302:82
                if (__tmp77Line != null) __out.Append(__tmp77Line);
                StringBuilder __tmp78 = new StringBuilder();
                __tmp78.Append(GenerateExpression(call.Arguments[0]));
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
                string __tmp79Line = ", "; //302:219
                if (__tmp79Line != null) __out.Append(__tmp79Line);
                StringBuilder __tmp80 = new StringBuilder();
                __tmp80.Append(GenerateExpression(call.Arguments[1]));
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
                string __tmp81Line = ")"; //302:260
                if (__tmp81Line != null) __out.Append(__tmp81Line);
            }
            else //303:2
            {
                StringBuilder __tmp84 = new StringBuilder();
                __tmp84.Append(GenerateExpression(call.Expression));
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
                string __tmp85Line = "("; //303:44
                if (__tmp85Line != null) __out.Append(__tmp85Line);
                StringBuilder __tmp86 = new StringBuilder();
                __tmp86.Append(GenerateCallArguments(call, ""));
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
                string __tmp87Line = ")"; //303:78
                if (__tmp87Line != null) __out.Append(__tmp87Line);
            }
            return __out.ToString();
        }

        public string GenerateIndexerCall(MetaIndexerExpression call) //307:1
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

        public string GenerateTypeOf(object expr) //311:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //312:9
            if (expr is MetaPrimitiveType) //313:2
            {
                var __tmp2 = ((MetaPrimitiveType)expr).Name; //314:10
                __out.Append("	"); //315:1
                if (__tmp2 == "*none*") //315:3
                {
                    __out.Append("metadslx.core.MetaInstance.None"); //315:18
                    __out.Append("	"); //316:1
                }
                else if (__tmp2 == "*error*") //316:3
                {
                    __out.Append("metadslx.core.MetaInstance.Error"); //316:19
                    __out.Append("	"); //317:1
                }
                else if (__tmp2 == "*any*") //317:3
                {
                    __out.Append("metadslx.core.MetaInstance.Any"); //317:17
                    __out.Append("	"); //318:1
                }
                else if (__tmp2 == "object") //318:3
                {
                    __out.Append("metadslx.core.MetaInstance.Object"); //318:18
                    __out.Append("	"); //319:1
                }
                else if (__tmp2 == "string") //319:3
                {
                    __out.Append("metadslx.core.MetaInstance.String"); //319:18
                    __out.Append("	"); //320:1
                }
                else if (__tmp2 == "int") //320:3
                {
                    __out.Append("metadslx.core.MetaInstance.Int"); //320:15
                    __out.Append("	"); //321:1
                }
                else if (__tmp2 == "long") //321:3
                {
                    __out.Append("metadslx.core.MetaInstance.Long"); //321:16
                    __out.Append("	"); //322:1
                }
                else if (__tmp2 == "float") //322:3
                {
                    __out.Append("metadslx.core.MetaInstance.Float"); //322:17
                    __out.Append("	"); //323:1
                }
                else if (__tmp2 == "double") //323:3
                {
                    __out.Append("metadslx.core.MetaInstance.Double"); //323:18
                    __out.Append("	"); //324:1
                }
                else if (__tmp2 == "byte") //324:3
                {
                    __out.Append("metadslx.core.MetaInstance.Byte"); //324:16
                    __out.Append("	"); //325:1
                }
                else if (__tmp2 == "bool") //325:3
                {
                    __out.Append("metadslx.core.MetaInstance.Bool"); //325:16
                    __out.Append("	"); //326:1
                }
                else if (__tmp2 == "void") //326:3
                {
                    __out.Append("metadslx.core.MetaInstance.Void"); //326:16
                    __out.Append("	"); //327:1
                }
                else if (__tmp2 == "ModelObject") //327:3
                {
                    __out.Append("metadslx.core.MetaInstance.ModelObject"); //327:23
                    __out.Append("	"); //328:1
                }
                else if (__tmp2 == "DefinitionList") //328:3
                {
                    __out.Append("metadslx.core.MetaInstance.DefinitionList"); //328:26
                    __out.Append("	"); //329:1
                }
                else if (__tmp2 == "ModelObjectList") //329:3
                {
                    __out.Append("metadslx.core.MetaInstance.ModelObjectList"); //329:27
                }//330:3
            }
            else if (expr is MetaTypeOfExpression) //331:2
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
            else if (expr is MetaClass) //332:2
            {
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(((MetaClass)expr).JavaFullDescriptorName());
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
                string __tmp9Line = ".getMetaClass()"; //332:52
                if (__tmp9Line != null) __out.Append(__tmp9Line);
            }
            else if (expr is MetaCollectionType) //333:2
            {
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(((MetaCollectionType)expr).JavaFullName());
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
            else //334:2
            {
                __out.Append("***error***"); //334:11
            }//335:2
            return __out.ToString();
        }

        public string GenerateCallArguments(MetaBoundExpression call, string prefix) //338:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop22_results = 
                (from __loop22_var1 in __Enumerate((call).GetEnumerator()) //339:7
                from arg in __Enumerate((__loop22_var1.Arguments).GetEnumerator()) //339:13
                select new { __loop22_var1 = __loop22_var1, arg = arg}
                ).ToList(); //339:2
            for (int __loop22_iteration = 0; __loop22_iteration < __loop22_results.Count; ++__loop22_iteration)
            {
                string delim; //339:26
                if (__loop22_iteration+1 < __loop22_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop22_results[__loop22_iteration];
                var __loop22_var1 = __tmp1.__loop22_var1;
                var arg = __tmp1.arg;
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(prefix);
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
                __tmp4.Append(GenerateExpression(arg));
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
                __tmp5.Append(delim);
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

        public string GenerateOperator(MetaOperatorExpression expr) //344:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //345:10
            if (expr is MetaUnaryExpression) //346:2
            {
                if (((MetaUnaryExpression)expr) is MetaPostIncrementAssignExpression || ((MetaUnaryExpression)expr) is MetaPostDecrementAssignExpression) //347:3
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
                    __tmp4.Append(GetJavaOperator(((MetaUnaryExpression)expr)));
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
                else //349:3
                {
                    StringBuilder __tmp6 = new StringBuilder();
                    __tmp6.Append(GetJavaOperator(((MetaUnaryExpression)expr)));
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
            else if (expr is MetaBinaryExpression) //352:2
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
                __tmp10.Append(GetJavaOperator(((MetaBinaryExpression)expr)));
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
            }//354:2
            return __out.ToString();
        }

        public string GenerateNewPropertyInitializers(MetaNewExpression expr) //357:1
        {
            StringBuilder __out = new StringBuilder();
            if ((from __loop23_var1 in __Enumerate((expr).GetEnumerator()) //358:14
            from pi in __Enumerate((__loop23_var1.PropertyInitializers).GetEnumerator()) //358:20
            select new { __loop23_var1 = __loop23_var1, pi = pi}
            ).GetEnumerator().MoveNext()) //358:2
            {
                string __tmp2Line = "java.util.Arrays.asList(new metadslx.core.ModelPropertyInitializer"; //359:1
                if (__tmp2Line != null) __out.Append(__tmp2Line);
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append("[]");
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
                string __tmp4Line = " {"; //359:73
                if (__tmp4Line != null) __out.Append(__tmp4Line);
                var __loop24_results = 
                    (from __loop24_var1 in __Enumerate((expr).GetEnumerator()) //360:7
                    from pi in __Enumerate((__loop24_var1.PropertyInitializers).GetEnumerator()) //360:13
                    select new { __loop24_var1 = __loop24_var1, pi = pi}
                    ).ToList(); //360:2
                for (int __loop24_iteration = 0; __loop24_iteration < __loop24_results.Count; ++__loop24_iteration)
                {
                    string delim; //360:36
                    if (__loop24_iteration+1 < __loop24_results.Count) delim = ", ";
                    else delim = string.Empty;
                    var __tmp5 = __loop24_results[__loop24_iteration];
                    var __loop24_var1 = __tmp5.__loop24_var1;
                    var pi = __tmp5.pi;
                    string __tmp7Line = "new metadslx.core.ModelPropertyInitializer("; //361:1
                    if (__tmp7Line != null) __out.Append(__tmp7Line);
                    StringBuilder __tmp8 = new StringBuilder();
                    __tmp8.Append(pi.Property.JavaFullDescriptorName());
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
                    string __tmp9Line = ", metadslx.core.Lazy.create(() -> "; //361:82
                    if (__tmp9Line != null) __out.Append(__tmp9Line);
                    StringBuilder __tmp10 = new StringBuilder();
                    __tmp10.Append(GenerateExpression(pi.Value));
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
                    string __tmp11Line = ", true))"; //361:146
                    if (__tmp11Line != null) __out.Append(__tmp11Line);
                    StringBuilder __tmp12 = new StringBuilder();
                    __tmp12.Append(delim);
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
                __out.Append("})"); //363:1
            }
            return __out.ToString();
        }

        public string GenerateNewCollectionValues(MetaNewCollectionExpression expr) //367:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop25_results = 
                (from __loop25_var1 in __Enumerate((expr).GetEnumerator()) //368:7
                from v in __Enumerate((__loop25_var1.Values).GetEnumerator()) //368:13
                select new { __loop25_var1 = __loop25_var1, v = v}
                ).ToList(); //368:2
            for (int __loop25_iteration = 0; __loop25_iteration < __loop25_results.Count; ++__loop25_iteration)
            {
                string delim; //368:21
                if (__loop25_iteration+1 < __loop25_results.Count) delim = ", \n";
                else delim = string.Empty;
                var __tmp1 = __loop25_results[__loop25_iteration];
                var __loop25_var1 = __tmp1.__loop25_var1;
                var v = __tmp1.v;
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(GenerateExpression(v));
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
                __tmp4.Append(delim);
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

        public string GetJavaValue(object value) //373:1
        {
            if (value == null) //374:2
            {
                return "null"; //374:21
            }
            else if (value is bool && ((bool)value) == true) //375:2
            {
                return "true"; //375:51
            }
            else if (value is bool && ((bool)value) == false) //376:2
            {
                return "false"; //376:52
            }
            else if (value is string) //377:2
            {
                return "\"" + value.ToString() + "\""; //377:28
            }
            else if (value is MetaExpression) //378:2
            {
                return GenerateExpression((MetaExpression)value); //378:36
            }
            else //379:2
            {
                return value.ToString(); //379:7
            }
        }

        public string GetJavaIdentifier(object value) //383:1
        {
            if (value == null) //384:2
            {
                return null; //385:3
            }
            if (value is MetaConstantExpression && ((MetaConstantExpression)value).Value != null) //387:2
            {
                return ((MetaConstantExpression)value).Value.ToString(); //388:3
            }
            else if (value is string) //389:2
            {
                return value.ToString(); //390:3
            }
            else //391:2
            {
                return null; //392:3
            }
        }

        public string GetJavaOperator(MetaOperatorExpression expr) //396:1
        {
            var __tmp1 = expr; //397:9
            if (expr is MetaUnaryPlusExpression) //398:3
            {
                return "+"; //398:36
            }
            else if (expr is MetaNegateExpression) //399:3
            {
                return "-"; //399:33
            }
            else if (expr is MetaOnesComplementExpression) //400:3
            {
                return "~"; //400:41
            }
            else if (expr is MetaNotExpression) //401:3
            {
                return "!"; //401:30
            }
            else if (expr is MetaPostIncrementAssignExpression) //402:3
            {
                return "++"; //402:46
            }
            else if (expr is MetaPostDecrementAssignExpression) //403:3
            {
                return "--"; //403:46
            }
            else if (expr is MetaPreIncrementAssignExpression) //404:3
            {
                return "++"; //404:45
            }
            else if (expr is MetaPreDecrementAssignExpression) //405:3
            {
                return "--"; //405:45
            }
            else if (expr is MetaMultiplyExpression) //406:3
            {
                return "*"; //406:35
            }
            else if (expr is MetaDivideExpression) //407:3
            {
                return "/"; //407:33
            }
            else if (expr is MetaModuloExpression) //408:3
            {
                return "%"; //408:33
            }
            else if (expr is MetaAddExpression) //409:3
            {
                return "+"; //409:30
            }
            else if (expr is MetaSubtractExpression) //410:3
            {
                return "-"; //410:35
            }
            else if (expr is MetaLeftShiftExpression) //411:3
            {
                return "<<"; //411:36
            }
            else if (expr is MetaRightShiftExpression) //412:3
            {
                return ">>"; //412:37
            }
            else if (expr is MetaLessThanExpression) //413:3
            {
                return "<"; //413:35
            }
            else if (expr is MetaLessThanOrEqualExpression) //414:3
            {
                return "<="; //414:42
            }
            else if (expr is MetaGreaterThanExpression) //415:3
            {
                return ">"; //415:38
            }
            else if (expr is MetaGreaterThanOrEqualExpression) //416:3
            {
                return ">="; //416:45
            }
            else if (expr is MetaEqualExpression) //417:3
            {
                return "=="; //417:32
            }
            else if (expr is MetaNotEqualExpression) //418:3
            {
                return "!="; //418:35
            }
            else if (expr is MetaAndExpression) //419:3
            {
                return "&"; //419:30
            }
            else if (expr is MetaOrExpression) //420:3
            {
                return "|"; //420:29
            }
            else if (expr is MetaExclusiveOrExpression) //421:3
            {
                return "^"; //421:38
            }
            else if (expr is MetaAndAlsoExpression) //422:3
            {
                return "&&"; //422:34
            }
            else if (expr is MetaOrElseExpression) //423:3
            {
                return "||"; //423:33
            }
            else if (expr is MetaNullCoalescingExpression) //424:3
            {
                return "??"; //424:41
            }
            else if (expr is MetaMultiplyAssignExpression) //425:3
            {
                return "*="; //425:41
            }
            else if (expr is MetaDivideAssignExpression) //426:3
            {
                return "/="; //426:39
            }
            else if (expr is MetaModuloAssignExpression) //427:3
            {
                return "%="; //427:39
            }
            else if (expr is MetaAddAssignExpression) //428:3
            {
                return "+="; //428:36
            }
            else if (expr is MetaSubtractAssignExpression) //429:3
            {
                return "-="; //429:41
            }
            else if (expr is MetaLeftShiftAssignExpression) //430:3
            {
                return "<<="; //430:42
            }
            else if (expr is MetaRightShiftAssignExpression) //431:3
            {
                return ">>="; //431:43
            }
            else if (expr is MetaAndAssignExpression) //432:3
            {
                return "&="; //432:36
            }
            else if (expr is MetaExclusiveOrAssignExpression) //433:3
            {
                return "^="; //433:44
            }
            else if (expr is MetaOrAssignExpression) //434:3
            {
                return "|="; //434:35
            }
            else //435:3
            {
                return ""; //435:12
            }//436:2
        }

        public string GetTypeName(MetaExpression expr) //439:1
        {
            if (expr is MetaTypeOfExpression) //440:2
            {
                return ((MetaTypeOfExpression)expr).TypeReference.JavaFullName(); //440:36
            }
            else //441:2
            {
                return null; //441:7
            }
        }

        public MetaSynthetizedPropertyInitializer GetSynthetizedInitializerFor(MetaClass cls, MetaProperty prop) //445:1
        {
            MetaSynthetizedPropertyInitializer lastInit = null; //446:2
            var __loop26_results = 
                (from __loop26_var1 in __Enumerate((cls).GetEnumerator()) //447:7
                from sup in __Enumerate((__loop26_var1.GetAllSuperClasses(true)).GetEnumerator()) //447:12
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //447:42
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //447:55
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaSynthetizedPropertyInitializer>() //447:69
                select new { __loop26_var1 = __loop26_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //447:2
            for (int __loop26_iteration = 0; __loop26_iteration < __loop26_results.Count; ++__loop26_iteration)
            {
                var __tmp1 = __loop26_results[__loop26_iteration];
                var __loop26_var1 = __tmp1.__loop26_var1;
                var sup = __tmp1.sup;
                var Constructor = __tmp1.Constructor;
                var Initializers = __tmp1.Initializers;
                var init = __tmp1.init;
                if (init.Property == prop) //448:3
                {
                    lastInit = init; //449:4
                }
            }
            return lastInit; //452:2
        }

        public string GenerateConstructorImpl(MetaModel model, MetaClass cls) //455:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "public "; //456:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.JavaImplName());
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
            string __tmp4Line = "() {"; //456:28
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //456:32
            var __loop27_results = 
                (from __loop27_var1 in __Enumerate((cls).GetEnumerator()) //457:8
                from prop in __Enumerate((__loop27_var1.GetAllProperties()).GetEnumerator()) //457:13
                select new { __loop27_var1 = __loop27_var1, prop = prop}
                ).ToList(); //457:3
            for (int __loop27_iteration = 0; __loop27_iteration < __loop27_results.Count; ++__loop27_iteration)
            {
                var __tmp5 = __loop27_results[__loop27_iteration];
                var __loop27_var1 = __tmp5.__loop27_var1;
                var prop = __tmp5.prop;
                MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //458:4
                if (synInit != null) //459:4
                {
                    if (prop.Kind != MetaPropertyKind.Derived) //460:5
                    {
                        if (ModelCompilerContext.Current.TypeProvider.GetTypeOf(synInit.Value) is MetaCollectionType) //461:6
                        {
                            string __tmp7Line = "    this.mLazySet("; //462:1
                            if (__tmp7Line != null) __out.Append(__tmp7Line);
                            StringBuilder __tmp8 = new StringBuilder();
                            __tmp8.Append(prop.JavaFullDescriptorName());
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
                            string __tmp9Line = ", metadslx.core.Lazy.create(() -> "; //462:50
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
                            string __tmp11Line = ", true));"; //462:119
                            if (__tmp11Line != null) __out.Append(__tmp11Line);
                            __out.AppendLine(false); //462:128
                        }
                        else //463:6
                        {
                            string __tmp13Line = "    this.mLazySet("; //464:1
                            if (__tmp13Line != null) __out.Append(__tmp13Line);
                            StringBuilder __tmp14 = new StringBuilder();
                            __tmp14.Append(prop.JavaFullDescriptorName());
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
                            string __tmp15Line = ", metadslx.core.Lazy.create(() -> "; //464:50
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
                            string __tmp17Line = ", true));"; //464:119
                            if (__tmp17Line != null) __out.Append(__tmp17Line);
                            __out.AppendLine(false); //464:128
                        }
                    }
                    else //466:5
                    {
                        string __tmp19Line = "    this.mDerivedSet("; //467:1
                        if (__tmp19Line != null) __out.Append(__tmp19Line);
                        StringBuilder __tmp20 = new StringBuilder();
                        __tmp20.Append(prop.JavaFullDescriptorName());
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
                        string __tmp21Line = ", () -> "; //467:53
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
                        string __tmp23Line = ");"; //467:96
                        if (__tmp23Line != null) __out.Append(__tmp23Line);
                        __out.AppendLine(false); //467:98
                    }
                }
                else //469:4
                {
                    if (prop.Type is MetaCollectionType) //470:5
                    {
                        if (prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) //471:6
                        {
                            string __tmp25Line = "    this.mSet("; //472:1
                            if (__tmp25Line != null) __out.Append(__tmp25Line);
                            StringBuilder __tmp26 = new StringBuilder();
                            __tmp26.Append(prop.JavaFullDescriptorName());
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
                            string __tmp27Line = ", new "; //472:46
                            if (__tmp27Line != null) __out.Append(__tmp27Line);
                            StringBuilder __tmp28 = new StringBuilder();
                            __tmp28.Append(prop.Type.JavaName());
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
                            string __tmp29Line = "("; //472:74
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
                            string __tmp31Line = "));"; //472:113
                            if (__tmp31Line != null) __out.Append(__tmp31Line);
                            __out.AppendLine(false); //472:116
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //473:6
                        {
                            string __tmp33Line = "    this.mLazySet("; //474:1
                            if (__tmp33Line != null) __out.Append(__tmp33Line);
                            StringBuilder __tmp34 = new StringBuilder();
                            __tmp34.Append(prop.JavaFullDescriptorName());
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
                            string __tmp35Line = ", metadslx.core.Lazy.create(() -> "; //474:50
                            if (__tmp35Line != null) __out.Append(__tmp35Line);
                            StringBuilder __tmp36 = new StringBuilder();
                            __tmp36.Append(prop.Class.Model.JavaFullImplementationName());
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
                            string __tmp37Line = "."; //474:131
                            if (__tmp37Line != null) __out.Append(__tmp37Line);
                            StringBuilder __tmp38 = new StringBuilder();
                            __tmp38.Append(prop.Class.JavaName());
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
                            string __tmp39Line = "_"; //474:155
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
                            string __tmp41Line = "(this), true));"; //474:167
                            if (__tmp41Line != null) __out.Append(__tmp41Line);
                            __out.AppendLine(false); //474:182
                        }
                        else if (prop.Kind == MetaPropertyKind.Derived) //475:6
                        {
                            string __tmp43Line = "    this.mDerivedSet("; //476:1
                            if (__tmp43Line != null) __out.Append(__tmp43Line);
                            StringBuilder __tmp44 = new StringBuilder();
                            __tmp44.Append(prop.JavaFullDescriptorName());
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
                            string __tmp45Line = ", () -> "; //476:53
                            if (__tmp45Line != null) __out.Append(__tmp45Line);
                            StringBuilder __tmp46 = new StringBuilder();
                            __tmp46.Append(prop.Class.Model.JavaFullImplementationName());
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
                            string __tmp47Line = "."; //476:108
                            if (__tmp47Line != null) __out.Append(__tmp47Line);
                            StringBuilder __tmp48 = new StringBuilder();
                            __tmp48.Append(prop.Class.JavaName());
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
                            string __tmp49Line = "_"; //476:132
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
                            string __tmp51Line = "(this));"; //476:144
                            if (__tmp51Line != null) __out.Append(__tmp51Line);
                            __out.AppendLine(false); //476:152
                        }
                        else if (prop.Kind == MetaPropertyKind.Readonly) //477:6
                        {
                            string __tmp53Line = "    // Init "; //478:1
                            if (__tmp53Line != null) __out.Append(__tmp53Line);
                            StringBuilder __tmp54 = new StringBuilder();
                            __tmp54.Append(prop.JavaFullDescriptorName());
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
                            string __tmp55Line = " in "; //478:44
                            if (__tmp55Line != null) __out.Append(__tmp55Line);
                            StringBuilder __tmp56 = new StringBuilder();
                            __tmp56.Append(prop.Class.Model.JavaFullImplementationName());
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
                            string __tmp57Line = "."; //478:95
                            if (__tmp57Line != null) __out.Append(__tmp57Line);
                            StringBuilder __tmp58 = new StringBuilder();
                            __tmp58.Append(cls.JavaName());
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
                            string __tmp59Line = "_"; //478:112
                            if (__tmp59Line != null) __out.Append(__tmp59Line);
                            StringBuilder __tmp60 = new StringBuilder();
                            __tmp60.Append(cls.JavaName());
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
                                    __out.AppendLine(false); //478:129
                                }
                            }
                        }
                    }
                    else //480:5
                    {
                        if (prop.Kind == MetaPropertyKind.Lazy) //481:6
                        {
                            string __tmp62Line = "    this.mLazySet("; //482:1
                            if (__tmp62Line != null) __out.Append(__tmp62Line);
                            StringBuilder __tmp63 = new StringBuilder();
                            __tmp63.Append(prop.JavaFullDescriptorName());
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
                            string __tmp64Line = ", metadslx.core.Lazy.create(() -> "; //482:50
                            if (__tmp64Line != null) __out.Append(__tmp64Line);
                            StringBuilder __tmp65 = new StringBuilder();
                            __tmp65.Append(model.JavaFullImplementationName());
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
                            string __tmp66Line = "."; //482:120
                            if (__tmp66Line != null) __out.Append(__tmp66Line);
                            StringBuilder __tmp67 = new StringBuilder();
                            __tmp67.Append(prop.Class.JavaName());
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
                            string __tmp68Line = "_"; //482:144
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
                            string __tmp70Line = "(this), true));"; //482:156
                            if (__tmp70Line != null) __out.Append(__tmp70Line);
                            __out.AppendLine(false); //482:171
                        }
                        else if (prop.Kind == MetaPropertyKind.Derived) //483:6
                        {
                            string __tmp72Line = "    this.mDerivedSet("; //484:1
                            if (__tmp72Line != null) __out.Append(__tmp72Line);
                            StringBuilder __tmp73 = new StringBuilder();
                            __tmp73.Append(prop.JavaFullDescriptorName());
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
                            string __tmp74Line = ", () -> "; //484:53
                            if (__tmp74Line != null) __out.Append(__tmp74Line);
                            StringBuilder __tmp75 = new StringBuilder();
                            __tmp75.Append(model.JavaFullImplementationName());
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
                            string __tmp76Line = "."; //484:97
                            if (__tmp76Line != null) __out.Append(__tmp76Line);
                            StringBuilder __tmp77 = new StringBuilder();
                            __tmp77.Append(prop.Class.JavaName());
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
                            string __tmp78Line = "_"; //484:121
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
                            string __tmp80Line = "(this));"; //484:133
                            if (__tmp80Line != null) __out.Append(__tmp80Line);
                            __out.AppendLine(false); //484:141
                        }
                        else if (prop.Kind == MetaPropertyKind.Readonly) //485:6
                        {
                            string __tmp82Line = "    // Init "; //486:1
                            if (__tmp82Line != null) __out.Append(__tmp82Line);
                            StringBuilder __tmp83 = new StringBuilder();
                            __tmp83.Append(prop.JavaFullDescriptorName());
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
                            string __tmp84Line = " in "; //486:44
                            if (__tmp84Line != null) __out.Append(__tmp84Line);
                            StringBuilder __tmp85 = new StringBuilder();
                            __tmp85.Append(model.JavaFullImplementationName());
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
                            string __tmp86Line = "."; //486:84
                            if (__tmp86Line != null) __out.Append(__tmp86Line);
                            StringBuilder __tmp87 = new StringBuilder();
                            __tmp87.Append(cls.JavaName());
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
                            string __tmp88Line = "_"; //486:101
                            if (__tmp88Line != null) __out.Append(__tmp88Line);
                            StringBuilder __tmp89 = new StringBuilder();
                            __tmp89.Append(cls.JavaName());
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
                                    __out.AppendLine(false); //486:118
                                }
                            }
                        }
                    }
                }
            }
            var __loop28_results = 
                (from __loop28_var1 in __Enumerate((cls).GetEnumerator()) //491:8
                from sup in __Enumerate((__loop28_var1.GetAllSuperClasses(true)).GetEnumerator()) //491:13
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //491:43
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //491:56
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaInheritedPropertyInitializer>() //491:70
                select new { __loop28_var1 = __loop28_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //491:3
            for (int __loop28_iteration = 0; __loop28_iteration < __loop28_results.Count; ++__loop28_iteration)
            {
                var __tmp90 = __loop28_results[__loop28_iteration];
                var __loop28_var1 = __tmp90.__loop28_var1;
                var sup = __tmp90.sup;
                var Constructor = __tmp90.Constructor;
                var Initializers = __tmp90.Initializers;
                var init = __tmp90.init;
                if (init.Object != null && init.Property != null) //492:4
                {
                    string __tmp92Line = "    this.mLazySetChild("; //493:1
                    if (__tmp92Line != null) __out.Append(__tmp92Line);
                    StringBuilder __tmp93 = new StringBuilder();
                    __tmp93.Append(init.Object.JavaFullDescriptorName());
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
                    string __tmp94Line = ", "; //493:62
                    if (__tmp94Line != null) __out.Append(__tmp94Line);
                    StringBuilder __tmp95 = new StringBuilder();
                    __tmp95.Append(init.Property.JavaFullDescriptorName());
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
                    string __tmp96Line = ", metadslx.core.Lazy.create(() -> "; //493:104
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
                    string __tmp98Line = ", true));"; //493:170
                    if (__tmp98Line != null) __out.Append(__tmp98Line);
                    __out.AppendLine(false); //493:179
                }
            }
            string __tmp99Prefix = "    "; //496:1
            StringBuilder __tmp100 = new StringBuilder();
            __tmp100.Append(cls.Model.JavaFullImplementationName());
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
            string __tmp101Line = "."; //496:45
            if (__tmp101Line != null) __out.Append(__tmp101Line);
            StringBuilder __tmp102 = new StringBuilder();
            __tmp102.Append(cls.JavaName());
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
            string __tmp103Line = "(this);"; //496:62
            if (__tmp103Line != null) __out.Append(__tmp103Line);
            __out.AppendLine(false); //496:69
            var __loop29_results = 
                (from __loop29_var1 in __Enumerate((cls).GetEnumerator()) //497:11
                from prop in __Enumerate((__loop29_var1.GetAllProperties()).GetEnumerator()) //497:16
                select new { __loop29_var1 = __loop29_var1, prop = prop}
                ).ToList(); //497:6
            for (int __loop29_iteration = 0; __loop29_iteration < __loop29_results.Count; ++__loop29_iteration)
            {
                var __tmp104 = __loop29_results[__loop29_iteration];
                var __loop29_var1 = __tmp104.__loop29_var1;
                var prop = __tmp104.prop;
                if (prop.Kind == MetaPropertyKind.Readonly) //498:4
                {
                    string __tmp106Line = "    if (!this.mIsSet("; //499:1
                    if (__tmp106Line != null) __out.Append(__tmp106Line);
                    StringBuilder __tmp107 = new StringBuilder();
                    __tmp107.Append(prop.JavaFullDescriptorName());
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
                    string __tmp108Line = ")) throw new metadslx.core.ModelException(\"Readonly property "; //499:53
                    if (__tmp108Line != null) __out.Append(__tmp108Line);
                    StringBuilder __tmp109 = new StringBuilder();
                    __tmp109.Append(model.JavaName());
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
                    string __tmp110Line = "."; //499:132
                    if (__tmp110Line != null) __out.Append(__tmp110Line);
                    StringBuilder __tmp111 = new StringBuilder();
                    __tmp111.Append(prop.Class.JavaName());
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
                    string __tmp112Line = "."; //499:156
                    if (__tmp112Line != null) __out.Append(__tmp112Line);
                    StringBuilder __tmp113 = new StringBuilder();
                    __tmp113.Append(prop.Name);
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
                    string __tmp114Line = "Property was not set in "; //499:168
                    if (__tmp114Line != null) __out.Append(__tmp114Line);
                    StringBuilder __tmp115 = new StringBuilder();
                    __tmp115.Append(cls.JavaName());
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
                    string __tmp116Line = "_"; //499:208
                    if (__tmp116Line != null) __out.Append(__tmp116Line);
                    StringBuilder __tmp117 = new StringBuilder();
                    __tmp117.Append(cls.JavaName());
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
                    string __tmp118Line = "().\");"; //499:225
                    if (__tmp118Line != null) __out.Append(__tmp118Line);
                    __out.AppendLine(false); //499:231
                }
            }
            __out.Append("    this.mMakeDefault();"); //502:1
            __out.AppendLine(false); //502:25
            __out.Append("}"); //503:1
            __out.AppendLine(false); //503:2
            return __out.ToString();
        }

        public string GetReturn(MetaOperation op) //506:1
        {
            if (op.ReturnType.JavaName() == "void") //507:5
            {
                return ""; //508:3
            }
            else //509:2
            {
                return "return "; //510:3
            }
        }

        public string GenerateOperationImpl(MetaModel model, MetaOperation op, HashSet<string> generated) //514:1
        {
            StringBuilder __out = new StringBuilder();
            if (generated.Add(op.Name)) //515:2
            {
                __out.AppendLine(true); //516:1
                string __tmp2Line = "public "; //517:1
                if (__tmp2Line != null) __out.Append(__tmp2Line);
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(op.ReturnType.JavaFullPublicName());
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
                string __tmp4Line = " "; //517:44
                if (__tmp4Line != null) __out.Append(__tmp4Line);
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(op.Name.ToCamelCase());
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
                string __tmp6Line = "("; //517:68
                if (__tmp6Line != null) __out.Append(__tmp6Line);
                StringBuilder __tmp7 = new StringBuilder();
                __tmp7.Append(GetParameters(op, false));
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
                string __tmp8Line = ") {"; //517:95
                if (__tmp8Line != null) __out.Append(__tmp8Line);
                __out.AppendLine(false); //517:98
                string __tmp9Prefix = "    "; //518:1
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(GetReturn(op));
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
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(model.JavaFullImplementationName());
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
                string __tmp12Line = "."; //518:56
                if (__tmp12Line != null) __out.Append(__tmp12Line);
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(op.Parent.JavaName());
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
                string __tmp14Line = "_"; //518:79
                if (__tmp14Line != null) __out.Append(__tmp14Line);
                StringBuilder __tmp15 = new StringBuilder();
                __tmp15.Append(op.Name.ToCamelCase());
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
                string __tmp16Line = "("; //518:103
                if (__tmp16Line != null) __out.Append(__tmp16Line);
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(GetImplCallParameterNames(op));
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
                string __tmp18Line = ");"; //518:135
                if (__tmp18Line != null) __out.Append(__tmp18Line);
                __out.AppendLine(false); //518:137
                __out.Append("}"); //519:1
                __out.AppendLine(false); //519:2
            }
            return __out.ToString();
        }

        public string GetSuperClasses(MetaClass cls) //523:1
        {
            string result = ""; //524:2
            var __loop30_results = 
                (from __loop30_var1 in __Enumerate((cls).GetEnumerator()) //525:10
                from sup in __Enumerate((__loop30_var1.SuperClasses).GetEnumerator()) //525:15
                select new { __loop30_var1 = __loop30_var1, sup = sup}
                ).ToList(); //525:5
            for (int __loop30_iteration = 0; __loop30_iteration < __loop30_results.Count; ++__loop30_iteration)
            {
                string delim; //525:31
                if (__loop30_iteration+1 < __loop30_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop30_results[__loop30_iteration];
                var __loop30_var1 = __tmp1.__loop30_var1;
                var sup = __tmp1.sup;
                result += sup.JavaFullName() + delim; //526:3
            }
            return result; //528:2
        }

        public string GetAllSuperClasses(MetaClass cls) //531:1
        {
            string result = ""; //532:2
            var __loop31_results = 
                (from __loop31_var1 in __Enumerate((cls).GetEnumerator()) //533:10
                from sup in __Enumerate((__loop31_var1.GetAllSuperClasses(false)).GetEnumerator()) //533:15
                select new { __loop31_var1 = __loop31_var1, sup = sup}
                ).ToList(); //533:5
            for (int __loop31_iteration = 0; __loop31_iteration < __loop31_results.Count; ++__loop31_iteration)
            {
                string delim; //533:44
                if (__loop31_iteration+1 < __loop31_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop31_results[__loop31_iteration];
                var __loop31_var1 = __tmp1.__loop31_var1;
                var sup = __tmp1.sup;
                result += sup.JavaFullName() + delim; //534:3
            }
            return result; //536:2
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //539:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "package "; //540:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.Namespace.JavaName());
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
            string __tmp4Line = ";"; //540:37
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //540:38
            __out.AppendLine(true); //541:1
            string __tmp6Line = "public final class "; //542:1
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(model.JavaDescriptorName());
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
            string __tmp8Line = " {"; //542:48
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //542:50
            __out.Append("    static {"); //543:1
            __out.AppendLine(false); //543:13
            var __loop32_results = 
                (from __loop32_var1 in __Enumerate((model).GetEnumerator()) //544:11
                from Namespace in __Enumerate((__loop32_var1.Namespace).GetEnumerator()) //544:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //544:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //544:43
                select new { __loop32_var1 = __loop32_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //544:6
            for (int __loop32_iteration = 0; __loop32_iteration < __loop32_results.Count; ++__loop32_iteration)
            {
                var __tmp9 = __loop32_results[__loop32_iteration];
                var __loop32_var1 = __tmp9.__loop32_var1;
                var Namespace = __tmp9.Namespace;
                var Declarations = __tmp9.Declarations;
                var cls = __tmp9.cls;
                string __tmp10Prefix = "        "; //545:1
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(cls.JavaName());
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
                string __tmp12Line = ".staticInit();"; //545:25
                if (__tmp12Line != null) __out.Append(__tmp12Line);
                __out.AppendLine(false); //545:39
            }
            __out.Append("    }"); //547:1
            __out.AppendLine(false); //547:6
            __out.AppendLine(true); //548:1
            __out.Append("    static void staticInit() {}"); //549:1
            __out.AppendLine(false); //549:32
            __out.AppendLine(true); //550:1
            string __tmp14Line = "	public static final String Uri = \""; //551:1
            if (__tmp14Line != null) __out.Append(__tmp14Line);
            StringBuilder __tmp15 = new StringBuilder();
            __tmp15.Append(model.Uri);
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
            string __tmp16Line = "\";"; //551:47
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            __out.AppendLine(false); //551:49
            __out.AppendLine(true); //552:1
            var __loop33_results = 
                (from __loop33_var1 in __Enumerate((model).GetEnumerator()) //553:11
                from Namespace in __Enumerate((__loop33_var1.Namespace).GetEnumerator()) //553:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //553:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //553:43
                select new { __loop33_var1 = __loop33_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //553:6
            for (int __loop33_iteration = 0; __loop33_iteration < __loop33_results.Count; ++__loop33_iteration)
            {
                var __tmp17 = __loop33_results[__loop33_iteration];
                var __loop33_var1 = __tmp17.__loop33_var1;
                var Namespace = __tmp17.Namespace;
                var Declarations = __tmp17.Declarations;
                var cls = __tmp17.cls;
                string __tmp18Prefix = "    "; //554:1
                StringBuilder __tmp19 = new StringBuilder();
                __tmp19.Append(GenerateMetaModelClass(cls));
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
                        __out.AppendLine(false); //554:34
                    }
                }
            }
            __out.Append("}"); //556:1
            __out.AppendLine(false); //556:2
            __out.AppendLine(true); //557:1
            return __out.ToString();
        }

        public string GenerateMetaModelClass(MetaClass cls) //561:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //562:1
            string __tmp2Line = "public static final class "; //563:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.JavaName());
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
            string __tmp4Line = " {"; //563:43
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //563:45
            __out.Append("    static void staticInit() {}"); //564:1
            __out.AppendLine(false); //564:32
            __out.AppendLine(true); //565:1
            __out.Append("    static {"); //566:1
            __out.AppendLine(false); //566:13
            string __tmp5Prefix = "        "; //567:1
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(cls.Model.JavaFullDescriptorName());
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(__tmp6_first || !__tmp6_last)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    __out.Append(__tmp5Prefix);
                    if (__tmp6Line != null) __out.Append(__tmp6Line);
                    if (!__tmp6_last) __out.AppendLine(true);
                }
            }
            string __tmp7Line = ".staticInit();"; //567:45
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //567:59
            __out.Append("    }"); //568:1
            __out.AppendLine(false); //568:6
            __out.AppendLine(true); //569:1
            __out.Append("    public static metadslx.core.MetaClass getMetaClass() {"); //570:1
            __out.AppendLine(false); //570:59
            string __tmp9Line = "        return "; //571:1
            if (__tmp9Line != null) __out.Append(__tmp9Line);
            StringBuilder __tmp10 = new StringBuilder();
            __tmp10.Append(cls.JavaFullInstanceName());
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
            string __tmp11Line = "; "; //571:44
            if (__tmp11Line != null) __out.Append(__tmp11Line);
            __out.AppendLine(false); //571:46
            __out.Append("    }"); //572:1
            __out.AppendLine(false); //572:6
            __out.AppendLine(true); //573:1
            var __loop34_results = 
                (from __loop34_var1 in __Enumerate((cls).GetEnumerator()) //574:11
                from prop in __Enumerate((__loop34_var1.Properties).GetEnumerator()) //574:16
                select new { __loop34_var1 = __loop34_var1, prop = prop}
                ).ToList(); //574:6
            for (int __loop34_iteration = 0; __loop34_iteration < __loop34_results.Count; ++__loop34_iteration)
            {
                var __tmp12 = __loop34_results[__loop34_iteration];
                var __loop34_var1 = __tmp12.__loop34_var1;
                var prop = __tmp12.prop;
                string __tmp13Prefix = "    "; //575:1
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(GeneratePropertyDeclaration(cls.Model, cls, prop));
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
                        __out.AppendLine(false); //575:56
                    }
                }
            }
            __out.Append("}"); //577:1
            __out.AppendLine(false); //577:2
            return __out.ToString();
        }

        public string GenerateModelConstant(MetaModel model, MetaConstant mconst) //581:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "public static final "; //582:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(mconst.Type.JavaFullName());
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
            string __tmp4Line = " "; //582:49
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
            string __tmp6Line = ";"; //582:63
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            __out.AppendLine(false); //582:64
            return __out.ToString();
        }

        public string GenerateModelConstantImpl(MetaModel model, MetaConstant mconst, Dictionary<ModelObject,string> mobjToTmp) //585:1
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
            string __tmp3Line = " = "; //586:14
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
            string __tmp5Line = ";"; //586:51
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            __out.AppendLine(false); //586:52
            return __out.ToString();
        }

        public string GenerateMetaModelInstance(MetaModel model) //590:1
        {
            StringBuilder __out = new StringBuilder();
            Dictionary<ModelObject,string> mobjToName = model.GetNamedModelObjects(); //591:2
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(ResetCounters());
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
            string __tmp4Line = "package "; //593:1
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(model.Namespace.JavaName());
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
            string __tmp6Line = ";"; //593:37
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            __out.AppendLine(false); //593:38
            __out.AppendLine(true); //594:1
            string __tmp8Line = "public final class "; //595:1
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(model.CSharpInstancesName());
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
                    __out.AppendLine(false); //595:49
                }
            }
            __out.Append("{"); //596:1
            __out.AppendLine(false); //596:2
            __out.Append("    private static metadslx.core.Model model;"); //597:1
            __out.AppendLine(false); //597:46
            __out.AppendLine(true); //598:1
            __out.Append("    public static metadslx.core.Model model() {"); //599:1
            __out.AppendLine(false); //599:48
            string __tmp11Line = "        return "; //600:1
            if (__tmp11Line != null) __out.Append(__tmp11Line);
            StringBuilder __tmp12 = new StringBuilder();
            __tmp12.Append(model.Name);
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
            string __tmp13Line = "Instance.model;"; //600:28
            if (__tmp13Line != null) __out.Append(__tmp13Line);
            __out.AppendLine(false); //600:43
            __out.Append("    }"); //601:1
            __out.AppendLine(false); //601:6
            __out.AppendLine(true); //602:1
            __out.Append("    public static final metadslx.core.MetaModel Meta;"); //603:1
            __out.AppendLine(false); //603:54
            __out.AppendLine(true); //604:1
            var __loop35_results = 
                (from __loop35_var1 in __Enumerate((model).GetEnumerator()) //605:11
                from Namespace in __Enumerate((__loop35_var1.Namespace).GetEnumerator()) //605:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //605:29
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //605:43
                select new { __loop35_var1 = __loop35_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //605:6
            for (int __loop35_iteration = 0; __loop35_iteration < __loop35_results.Count; ++__loop35_iteration)
            {
                var __tmp14 = __loop35_results[__loop35_iteration];
                var __loop35_var1 = __tmp14.__loop35_var1;
                var Namespace = __tmp14.Namespace;
                var Declarations = __tmp14.Declarations;
                var c = __tmp14.c;
                string __tmp15Prefix = "    "; //606:1
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(GenerateModelConstant(model, c));
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
                        __out.AppendLine(false); //606:38
                    }
                }
            }
            __out.AppendLine(true); //608:1
            var __loop36_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //609:11
                select new { mobj = mobj}
                ).ToList(); //609:6
            for (int __loop36_iteration = 0; __loop36_iteration < __loop36_results.Count; ++__loop36_iteration)
            {
                var __tmp17 = __loop36_results[__loop36_iteration];
                var mobj = __tmp17.mobj;
                string __tmp18Prefix = "	"; //610:1
                StringBuilder __tmp19 = new StringBuilder();
                __tmp19.Append(GenerateModelObjectInstanceDeclaration(mobj, mobjToName));
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
                        __out.AppendLine(false); //610:60
                    }
                }
            }
            __out.AppendLine(true); //612:1
            __out.Append("    static {"); //613:1
            __out.AppendLine(false); //613:13
            string __tmp20Prefix = "		"; //614:1
            StringBuilder __tmp21 = new StringBuilder();
            __tmp21.Append(model.JavaDescriptorName());
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
            string __tmp22Line = ".staticInit();"; //614:31
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            __out.AppendLine(false); //614:45
            string __tmp23Prefix = "		"; //615:1
            StringBuilder __tmp24 = new StringBuilder();
            __tmp24.Append(model.JavaInstancesName());
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
            string __tmp25Line = ".model = new metadslx.core.Model();"; //615:30
            if (__tmp25Line != null) __out.Append(__tmp25Line);
            __out.AppendLine(false); //615:65
            string __tmp27Line = "   		try (metadslx.core.ModelContextScope _scope = new metadslx.core.ModelContextScope("; //616:1
            if (__tmp27Line != null) __out.Append(__tmp27Line);
            StringBuilder __tmp28 = new StringBuilder();
            __tmp28.Append(model.JavaInstancesName());
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
            string __tmp29Line = ".model)) {"; //616:115
            if (__tmp29Line != null) __out.Append(__tmp29Line);
            __out.AppendLine(false); //616:125
            var __loop37_results = 
                (from __loop37_var1 in __Enumerate((model).GetEnumerator()) //617:13
                from Namespace in __Enumerate((__loop37_var1.Namespace).GetEnumerator()) //617:20
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //617:31
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //617:45
                select new { __loop37_var1 = __loop37_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //617:8
            for (int __loop37_iteration = 0; __loop37_iteration < __loop37_results.Count; ++__loop37_iteration)
            {
                var __tmp30 = __loop37_results[__loop37_iteration];
                var __loop37_var1 = __tmp30.__loop37_var1;
                var Namespace = __tmp30.Namespace;
                var Declarations = __tmp30.Declarations;
                var c = __tmp30.c;
                string __tmp31Prefix = "            "; //618:1
                StringBuilder __tmp32 = new StringBuilder();
                __tmp32.Append(GenerateModelConstantImpl(model, c, mobjToName));
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
                        __out.AppendLine(false); //618:62
                    }
                }
            }
            __out.AppendLine(true); //620:1
            var __loop38_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //621:10
                select new { mobj = mobj}
                ).ToList(); //621:5
            for (int __loop38_iteration = 0; __loop38_iteration < __loop38_results.Count; ++__loop38_iteration)
            {
                var __tmp33 = __loop38_results[__loop38_iteration];
                var mobj = __tmp33.mobj;
                string __tmp34Prefix = "			"; //622:1
                StringBuilder __tmp35 = new StringBuilder();
                __tmp35.Append(GenerateModelObjectInstance(mobj, mobjToName));
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
                        __out.AppendLine(false); //622:51
                    }
                }
            }
            __out.AppendLine(true); //624:1
            __out.Append("			init();"); //625:1
            __out.AppendLine(false); //625:11
            __out.AppendLine(true); //626:1
            string __tmp36Prefix = "            "; //627:1
            StringBuilder __tmp37 = new StringBuilder();
            __tmp37.Append(model.JavaInstancesName());
            using(StreamReader __tmp37Reader = new StreamReader(this.__ToStream(__tmp37.ToString())))
            {
                bool __tmp37_first = true;
                bool __tmp37_last = __tmp37Reader.EndOfStream;
                while(__tmp37_first || !__tmp37_last)
                {
                    __tmp37_first = false;
                    string __tmp37Line = __tmp37Reader.ReadLine();
                    __tmp37_last = __tmp37Reader.EndOfStream;
                    __out.Append(__tmp36Prefix);
                    if (__tmp37Line != null) __out.Append(__tmp37Line);
                    if (!__tmp37_last) __out.AppendLine(true);
                }
            }
            string __tmp38Line = ".model.evalLazyValues();"; //627:40
            if (__tmp38Line != null) __out.Append(__tmp38Line);
            __out.AppendLine(false); //627:64
            __out.Append("		}"); //628:1
            __out.AppendLine(false); //628:4
            __out.Append("    }"); //629:1
            __out.AppendLine(false); //629:6
            __out.AppendLine(true); //630:1
            __out.Append("	private static void init0() {"); //631:1
            __out.AppendLine(false); //631:31
            var __loop39_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //632:8
                select new { mobj = mobj}
                ).ToList(); //632:3
            for (int __loop39_iteration = 0; __loop39_iteration < __loop39_results.Count; ++__loop39_iteration)
            {
                var __tmp39 = __loop39_results[__loop39_iteration];
                var mobj = __tmp39.mobj;
                string __tmp40Prefix = "	"; //633:1
                StringBuilder __tmp41 = new StringBuilder();
                __tmp41.Append(GenerateModelObjectInstanceInitializer(mobj, mobjToName));
                using(StreamReader __tmp41Reader = new StreamReader(this.__ToStream(__tmp41.ToString())))
                {
                    bool __tmp41_first = true;
                    bool __tmp41_last = __tmp41Reader.EndOfStream;
                    while(__tmp41_first || !__tmp41_last)
                    {
                        __tmp41_first = false;
                        string __tmp41Line = __tmp41Reader.ReadLine();
                        __tmp41_last = __tmp41Reader.EndOfStream;
                        __out.Append(__tmp40Prefix);
                        if (__tmp41Line != null) __out.Append(__tmp41Line);
                        if (!__tmp41_last) __out.AppendLine(true);
                        __out.AppendLine(false); //633:60
                    }
                }
            }
            __out.Append("	}"); //635:1
            __out.AppendLine(false); //635:3
            __out.AppendLine(true); //636:1
            __out.Append("	private static void init() {"); //637:1
            __out.AppendLine(false); //637:30
            var __loop40_results = 
                (from i in __Enumerate((Enumerable.Range(0, Properties.FunctionCount + 1)).GetEnumerator()) //638:8
                select new { i = i}
                ).ToList(); //638:3
            for (int __loop40_iteration = 0; __loop40_iteration < __loop40_results.Count; ++__loop40_iteration)
            {
                var __tmp42 = __loop40_results[__loop40_iteration];
                var i = __tmp42.i;
                string __tmp44Line = "		init"; //639:1
                if (__tmp44Line != null) __out.Append(__tmp44Line);
                StringBuilder __tmp45 = new StringBuilder();
                __tmp45.Append(i);
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
                string __tmp46Line = "();"; //639:10
                if (__tmp46Line != null) __out.Append(__tmp46Line);
                __out.AppendLine(false); //639:13
            }
            __out.Append("	}"); //641:1
            __out.AppendLine(false); //641:3
            __out.Append("}"); //642:1
            __out.AppendLine(false); //642:2
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceDeclaration(ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //646:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //647:2
            {
                if (mobjToName.ContainsKey(mobj)) //648:3
                {
                    string name = mobjToName[mobj]; //649:4
                    if (name.StartsWith("__")) //650:4
                    {
                        string __tmp2Line = "private static final metadslx.core."; //651:1
                        if (__tmp2Line != null) __out.Append(__tmp2Line);
                        StringBuilder __tmp3 = new StringBuilder();
                        __tmp3.Append(mobj.MMetaClass.JavaName());
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
                        string __tmp4Line = " "; //651:64
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
                        string __tmp6Line = ";"; //651:71
                        if (__tmp6Line != null) __out.Append(__tmp6Line);
                        __out.AppendLine(false); //651:72
                    }
                    else //652:4
                    {
                        string __tmp8Line = "public static final metadslx.core."; //653:1
                        if (__tmp8Line != null) __out.Append(__tmp8Line);
                        StringBuilder __tmp9 = new StringBuilder();
                        __tmp9.Append(mobj.MMetaClass.JavaName());
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
                        string __tmp10Line = " "; //653:63
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
                        string __tmp12Line = ";"; //653:70
                        if (__tmp12Line != null) __out.Append(__tmp12Line);
                        __out.AppendLine(false); //653:71
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstance(ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //660:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //661:2
            {
                if (mobjToName.ContainsKey(mobj)) //662:3
                {
                    string name = mobjToName[mobj]; //663:4
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
                    string __tmp3Line = " = metadslx.core.MetaFactory.instance().create"; //664:7
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
                    string __tmp5Line = "();"; //664:83
                    if (__tmp5Line != null) __out.Append(__tmp5Line);
                    __out.AppendLine(false); //664:86
                    if (mobj is MetaModel) //665:4
                    {
                        string __tmp7Line = "Meta = "; //666:1
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
                        string __tmp9Line = ";"; //666:14
                        if (__tmp9Line != null) __out.Append(__tmp9Line);
                        __out.AppendLine(false); //666:15
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceInitializer(ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //673:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //674:2
            {
                if (mobjToName.ContainsKey(mobj)) //675:3
                {
                    var __loop41_results = 
                        (from __loop41_var1 in __Enumerate((mobj).GetEnumerator()) //676:9
                        from prop in __Enumerate((__loop41_var1.MGetAllProperties()).GetEnumerator()) //676:15
                        select new { __loop41_var1 = __loop41_var1, prop = prop}
                        ).ToList(); //676:4
                    for (int __loop41_iteration = 0; __loop41_iteration < __loop41_results.Count; ++__loop41_iteration)
                    {
                        var __tmp1 = __loop41_results[__loop41_iteration];
                        var __loop41_var1 = __tmp1.__loop41_var1;
                        var prop = __tmp1.prop;
                        if (prop.MetaProperty != null && prop.MetaProperty.Kind != MetaPropertyKind.Derived) //677:5
                        {
                            object propValue = mobj.MGet(prop); //678:6
                            if ((++Properties.LineCount) % 1000 == 0) //679:6
                            {
                                __out.Append("}"); //680:1
                                __out.AppendLine(false); //680:2
                                string __tmp3Line = "private static void init"; //681:1
                                if (__tmp3Line != null) __out.Append(__tmp3Line);
                                StringBuilder __tmp4 = new StringBuilder();
                                __tmp4.Append(++Properties.FunctionCount);
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
                                string __tmp5Line = "() {"; //681:53
                                if (__tmp5Line != null) __out.Append(__tmp5Line);
                                __out.AppendLine(false); //681:57
                            }
                            string __tmp6Prefix = "	"; //683:1
                            StringBuilder __tmp7 = new StringBuilder();
                            __tmp7.Append(GenerateModelObjectPropertyValue(mobj, prop, propValue, mobjToName));
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
                                    __out.AppendLine(false); //683:71
                                }
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectPropertyValue(ModelObject mobj, ModelProperty prop, object value, Dictionary<ModelObject,string> mobjToName) //691:1
        {
            StringBuilder __out = new StringBuilder();
            string name = mobjToName[mobj]; //692:2
            string propDeclName = prop.JavaFullDeclaredName(); //693:2
            if (!prop.IsCollection) //694:2
            {
                string __tmp2Line = "((metadslx.core.ModelObject)"; //695:1
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
                string __tmp4Line = ").mUnSet("; //695:35
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
                string __tmp6Line = ");"; //695:58
                if (__tmp6Line != null) __out.Append(__tmp6Line);
                __out.AppendLine(false); //695:60
            }
            ModelObject moValue = value as ModelObject; //697:2
            if (value == null) //698:2
            {
                string __tmp8Line = "((metadslx.core.ModelObject)"; //699:1
                if (__tmp8Line != null) __out.Append(__tmp8Line);
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append(name);
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
                string __tmp10Line = ").mLazyAdd("; //699:35
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
                string __tmp12Line = ", metadslx.core.Lazy.create(() -> null, true));"; //699:60
                if (__tmp12Line != null) __out.Append(__tmp12Line);
                __out.AppendLine(false); //699:107
            }
            else if (value is string) //700:2
            {
                string __tmp14Line = "((metadslx.core.ModelObject)"; //701:1
                if (__tmp14Line != null) __out.Append(__tmp14Line);
                StringBuilder __tmp15 = new StringBuilder();
                __tmp15.Append(name);
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
                string __tmp16Line = ").mLazyAdd("; //701:35
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
                string __tmp18Line = ", metadslx.core.Lazy.create(() -> \""; //701:60
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
                string __tmp20Line = "\", true));"; //701:102
                if (__tmp20Line != null) __out.Append(__tmp20Line);
                __out.AppendLine(false); //701:112
            }
            else if (value is bool) //702:2
            {
                string __tmp22Line = "((metadslx.core.ModelObject)"; //703:1
                if (__tmp22Line != null) __out.Append(__tmp22Line);
                StringBuilder __tmp23 = new StringBuilder();
                __tmp23.Append(name);
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
                string __tmp24Line = ").mLazyAdd("; //703:35
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
                string __tmp26Line = ", metadslx.core.Lazy.create(() -> "; //703:60
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
                string __tmp28Line = ", true));"; //703:122
                if (__tmp28Line != null) __out.Append(__tmp28Line);
                __out.AppendLine(false); //703:131
            }
            else if (value.GetType().IsPrimitive) //704:2
            {
                string __tmp30Line = "((metadslx.core.ModelObject)"; //705:1
                if (__tmp30Line != null) __out.Append(__tmp30Line);
                StringBuilder __tmp31 = new StringBuilder();
                __tmp31.Append(name);
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
                string __tmp32Line = ").mLazyAdd("; //705:35
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
                string __tmp34Line = ", metadslx.core.Lazy.create(() -> "; //705:60
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
                string __tmp36Line = ", true));"; //705:112
                if (__tmp36Line != null) __out.Append(__tmp36Line);
                __out.AppendLine(false); //705:121
            }
            else if (MetaBuiltInTypes.Types.Contains(value)) //706:2
            {
                string __tmp38Line = "((metadslx.core.ModelObject)"; //707:1
                if (__tmp38Line != null) __out.Append(__tmp38Line);
                StringBuilder __tmp39 = new StringBuilder();
                __tmp39.Append(name);
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
                string __tmp40Line = ").mLazyAdd("; //707:35
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
                string __tmp42Line = ", metadslx.core.Lazy.create(() -> "; //707:60
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
                string __tmp44Line = ", true));"; //707:117
                if (__tmp44Line != null) __out.Append(__tmp44Line);
                __out.AppendLine(false); //707:126
            }
            else if (value is MetaPrimitiveType) //708:2
            {
                string __tmp46Line = "((metadslx.core.ModelObject)"; //709:1
                if (__tmp46Line != null) __out.Append(__tmp46Line);
                StringBuilder __tmp47 = new StringBuilder();
                __tmp47.Append(name);
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
                string __tmp48Line = ").mLazyAdd("; //709:35
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
                string __tmp50Line = ", metadslx.core.Lazy.create(() -> "; //709:60
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
                string __tmp52Line = ", true));"; //709:117
                if (__tmp52Line != null) __out.Append(__tmp52Line);
                __out.AppendLine(false); //709:126
            }
            else if (value is Enum) //710:2
            {
                string __tmp54Line = "((metadslx.core.ModelObject)"; //711:1
                if (__tmp54Line != null) __out.Append(__tmp54Line);
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
                string __tmp56Line = ").mLazyAdd("; //711:35
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
                string __tmp58Line = ", metadslx.core.Lazy.create(() -> "; //711:60
                if (__tmp58Line != null) __out.Append(__tmp58Line);
                StringBuilder __tmp59 = new StringBuilder();
                __tmp59.Append(value.JavaEnumValueOf());
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
                string __tmp60Line = ", true));"; //711:119
                if (__tmp60Line != null) __out.Append(__tmp60Line);
                __out.AppendLine(false); //711:128
            }
            else if (moValue != null) //712:2
            {
                if (mobjToName.ContainsKey(moValue)) //713:3
                {
                    string __tmp62Line = "((metadslx.core.ModelObject)"; //714:1
                    if (__tmp62Line != null) __out.Append(__tmp62Line);
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
                    string __tmp64Line = ").mLazyAdd("; //714:35
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
                    string __tmp66Line = ", metadslx.core.Lazy.create(() -> "; //714:60
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
                    string __tmp68Line = ", true));"; //714:115
                    if (__tmp68Line != null) __out.Append(__tmp68Line);
                    __out.AppendLine(false); //714:124
                }
                else //715:3
                {
                    string __tmp70Line = "// Omitted since not part of the model: "; //716:1
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
                    string __tmp72Line = "."; //716:47
                    if (__tmp72Line != null) __out.Append(__tmp72Line);
                    StringBuilder __tmp73 = new StringBuilder();
                    __tmp73.Append(propDeclName);
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
                    string __tmp74Line = " = "; //716:62
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
                            __out.AppendLine(false); //716:74
                        }
                    }
                }
            }
            else //718:2
            {
                IEnumerable<object> mc = (value as ModelCollection) as IEnumerable<object>; //719:3
                if (mc != null) //720:3
                {
                    var __loop42_results = 
                        (from cvalue in __Enumerate((mc).GetEnumerator()) //721:9
                        select new { cvalue = cvalue}
                        ).ToList(); //721:4
                    for (int __loop42_iteration = 0; __loop42_iteration < __loop42_results.Count; ++__loop42_iteration)
                    {
                        var __tmp76 = __loop42_results[__loop42_iteration];
                        var cvalue = __tmp76.cvalue;
                        if (!mobj.ContainedBySingleOpposite(prop, (ModelObject)cvalue)) //722:5
                        {
                            StringBuilder __tmp78 = new StringBuilder();
                            __tmp78.Append(GenerateModelObjectPropertyValue(mobj, prop, cvalue, mobjToName));
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
                                    __out.AppendLine(false); //723:67
                                }
                            }
                        }
                    }
                }
                else //726:3
                {
                    string __tmp80Line = "// Invalid property value type: "; //727:1
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
                    string __tmp82Line = "."; //727:39
                    if (__tmp82Line != null) __out.Append(__tmp82Line);
                    StringBuilder __tmp83 = new StringBuilder();
                    __tmp83.Append(propDeclName);
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
                    string __tmp84Line = " = "; //727:54
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
                            __out.AppendLine(false); //727:74
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //733:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "package "; //734:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.Namespace.JavaName());
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
            string __tmp4Line = ";"; //734:37
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //734:38
            __out.AppendLine(true); //735:1
            string __tmp6Line = "final class "; //736:1
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
            string __tmp8Line = "ImplementationProvider {"; //736:25
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //736:49
            string __tmp10Line = "    // If there is a compile error at this line, create a new class called "; //737:1
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
            string __tmp12Line = "Implementation"; //737:88
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //737:102
            string __tmp14Line = "	// which is a subclass of "; //738:1
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
            string __tmp16Line = "ImplementationBase:"; //738:40
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            __out.AppendLine(false); //738:59
            string __tmp18Line = "    private static "; //739:1
            if (__tmp18Line != null) __out.Append(__tmp18Line);
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
                    if (__tmp19Line != null) __out.Append(__tmp19Line);
                    if (!__tmp19_last) __out.AppendLine(true);
                }
            }
            string __tmp20Line = "Implementation implementation = new "; //739:32
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
            string __tmp22Line = "Implementation();"; //739:80
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            __out.AppendLine(false); //739:97
            __out.AppendLine(true); //740:1
            string __tmp24Line = "    public static "; //741:1
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
            string __tmp26Line = "Implementation implementation() {"; //741:31
            if (__tmp26Line != null) __out.Append(__tmp26Line);
            __out.AppendLine(false); //741:64
            string __tmp28Line = "        return "; //742:1
            if (__tmp28Line != null) __out.Append(__tmp28Line);
            StringBuilder __tmp29 = new StringBuilder();
            __tmp29.Append(model.Name);
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
            string __tmp30Line = "ImplementationProvider.implementation;"; //742:28
            if (__tmp30Line != null) __out.Append(__tmp30Line);
            __out.AppendLine(false); //742:66
            __out.Append("    }"); //743:1
            __out.AppendLine(false); //743:6
            __out.Append("}"); //744:1
            __out.AppendLine(false); //744:2
            return __out.ToString();
        }

        public string GenerateImplementationBase(MetaModel model) //747:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "package "; //748:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.Namespace.JavaName());
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
            string __tmp4Line = ";"; //748:37
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //748:38
            __out.AppendLine(true); //749:1
            __out.Append("/**"); //750:1
            __out.AppendLine(false); //750:4
            __out.Append(" * Base class for implementing the behavior of the model elements."); //751:1
            __out.AppendLine(false); //751:67
            string __tmp6Line = " * This class has to be be overriden in "; //752:1
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
            string __tmp8Line = "Implementation to provide custom"; //752:53
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //752:85
            __out.Append(" * implementation for the constructors, operations and property values."); //753:1
            __out.AppendLine(false); //753:72
            __out.Append(" */"); //754:1
            __out.AppendLine(false); //754:4
            string __tmp10Line = "abstract class "; //755:1
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
            string __tmp12Line = "ImplementationBase {"; //755:28
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //755:48
            var __loop43_results = 
                (from __loop43_var1 in __Enumerate((model).GetEnumerator()) //756:8
                from Namespace in __Enumerate((__loop43_var1.Namespace).GetEnumerator()) //756:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //756:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //756:40
                select new { __loop43_var1 = __loop43_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //756:3
            for (int __loop43_iteration = 0; __loop43_iteration < __loop43_results.Count; ++__loop43_iteration)
            {
                var __tmp13 = __loop43_results[__loop43_iteration];
                var __loop43_var1 = __tmp13.__loop43_var1;
                var Namespace = __tmp13.Namespace;
                var Declarations = __tmp13.Declarations;
                var cls = __tmp13.cls;
                __out.Append("    /**"); //757:1
                __out.AppendLine(false); //757:8
                string __tmp15Line = "	 * Implements the constructor: "; //758:1
                if (__tmp15Line != null) __out.Append(__tmp15Line);
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(cls.JavaName());
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
                string __tmp17Line = "()"; //758:49
                if (__tmp17Line != null) __out.Append(__tmp17Line);
                __out.AppendLine(false); //758:51
                if ((from __loop44_var1 in __Enumerate((cls).GetEnumerator()) //759:15
                from sup in __Enumerate((__loop44_var1.SuperClasses).GetEnumerator()) //759:20
                select new { __loop44_var1 = __loop44_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //759:3
                {
                    string __tmp19Line = "	 * Direct superclasses: "; //760:1
                    if (__tmp19Line != null) __out.Append(__tmp19Line);
                    StringBuilder __tmp20 = new StringBuilder();
                    __tmp20.Append(GetSuperClasses(cls));
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
                            __out.AppendLine(false); //760:48
                        }
                    }
                    string __tmp22Line = "	 * All superclasses: "; //761:1
                    if (__tmp22Line != null) __out.Append(__tmp22Line);
                    StringBuilder __tmp23 = new StringBuilder();
                    __tmp23.Append(GetAllSuperClasses(cls));
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
                            __out.AppendLine(false); //761:48
                        }
                    }
                }
                if ((from __loop45_var1 in __Enumerate((cls).GetEnumerator()) //763:15
                from prop in __Enumerate((__loop45_var1.GetAllProperties()).GetEnumerator()) //763:20
                where prop.Kind == MetaPropertyKind.Readonly //763:44
                select new { __loop45_var1 = __loop45_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //763:3
                {
                    __out.Append("     * Initializes the following readonly properties:"); //764:1
                    __out.AppendLine(false); //764:54
                }
                var __loop46_results = 
                    (from __loop46_var1 in __Enumerate((cls).GetEnumerator()) //766:11
                    from prop in __Enumerate((__loop46_var1.GetAllProperties()).GetEnumerator()) //766:16
                    select new { __loop46_var1 = __loop46_var1, prop = prop}
                    ).ToList(); //766:6
                for (int __loop46_iteration = 0; __loop46_iteration < __loop46_results.Count; ++__loop46_iteration)
                {
                    var __tmp24 = __loop46_results[__loop46_iteration];
                    var __loop46_var1 = __tmp24.__loop46_var1;
                    var prop = __tmp24.prop;
                    if (prop.Kind == MetaPropertyKind.Readonly) //767:3
                    {
                        string __tmp26Line = "     *    "; //768:1
                        if (__tmp26Line != null) __out.Append(__tmp26Line);
                        StringBuilder __tmp27 = new StringBuilder();
                        __tmp27.Append(prop.Class.Name);
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
                        string __tmp28Line = "."; //768:28
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
                                __out.AppendLine(false); //768:40
                            }
                        }
                    }
                }
                __out.Append("    */"); //771:1
                __out.AppendLine(false); //771:7
                string __tmp31Line = "    public void "; //772:1
                if (__tmp31Line != null) __out.Append(__tmp31Line);
                StringBuilder __tmp32 = new StringBuilder();
                __tmp32.Append(cls.JavaName());
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
                string __tmp33Line = "("; //772:33
                if (__tmp33Line != null) __out.Append(__tmp33Line);
                StringBuilder __tmp34 = new StringBuilder();
                __tmp34.Append(cls.JavaName());
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
                string __tmp35Line = " _this) {"; //772:50
                if (__tmp35Line != null) __out.Append(__tmp35Line);
                __out.AppendLine(false); //772:59
                var __loop47_results = 
                    (from __loop47_var1 in __Enumerate((cls).GetEnumerator()) //773:9
                    from sup in __Enumerate((__loop47_var1.SuperClasses).GetEnumerator()) //773:14
                    select new { __loop47_var1 = __loop47_var1, sup = sup}
                    ).ToList(); //773:4
                for (int __loop47_iteration = 0; __loop47_iteration < __loop47_results.Count; ++__loop47_iteration)
                {
                    var __tmp36 = __loop47_results[__loop47_iteration];
                    var __loop47_var1 = __tmp36.__loop47_var1;
                    var sup = __tmp36.sup;
                    string __tmp38Line = "        this."; //774:1
                    if (__tmp38Line != null) __out.Append(__tmp38Line);
                    StringBuilder __tmp39 = new StringBuilder();
                    __tmp39.Append(sup.JavaName());
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
                    string __tmp40Line = "(_this);"; //774:30
                    if (__tmp40Line != null) __out.Append(__tmp40Line);
                    __out.AppendLine(false); //774:38
                }
                __out.Append("    }"); //776:1
                __out.AppendLine(false); //776:6
                var __loop48_results = 
                    (from __loop48_var1 in __Enumerate((cls).GetEnumerator()) //777:11
                    from prop in __Enumerate((__loop48_var1.Properties).GetEnumerator()) //777:16
                    select new { __loop48_var1 = __loop48_var1, prop = prop}
                    ).ToList(); //777:6
                for (int __loop48_iteration = 0; __loop48_iteration < __loop48_results.Count; ++__loop48_iteration)
                {
                    var __tmp41 = __loop48_results[__loop48_iteration];
                    var __loop48_var1 = __tmp41.__loop48_var1;
                    var prop = __tmp41.prop;
                    MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //778:4
                    if (synInit == null) //779:4
                    {
                        if (prop.Kind == MetaPropertyKind.Derived) //780:5
                        {
                            __out.AppendLine(true); //781:1
                            __out.Append("    /**"); //782:1
                            __out.AppendLine(false); //782:8
                            string __tmp43Line = "     * Returns the value of the derived property: "; //783:1
                            if (__tmp43Line != null) __out.Append(__tmp43Line);
                            StringBuilder __tmp44 = new StringBuilder();
                            __tmp44.Append(cls.JavaName());
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
                            string __tmp45Line = "."; //783:67
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
                                    __out.AppendLine(false); //783:79
                                }
                            }
                            __out.Append("     */"); //784:1
                            __out.AppendLine(false); //784:8
                            string __tmp48Line = "    public "; //785:1
                            if (__tmp48Line != null) __out.Append(__tmp48Line);
                            StringBuilder __tmp49 = new StringBuilder();
                            __tmp49.Append(prop.Type.JavaFullPublicName());
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
                            string __tmp50Line = " "; //785:44
                            if (__tmp50Line != null) __out.Append(__tmp50Line);
                            StringBuilder __tmp51 = new StringBuilder();
                            __tmp51.Append(cls.JavaName());
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
                            string __tmp52Line = "_"; //785:61
                            if (__tmp52Line != null) __out.Append(__tmp52Line);
                            StringBuilder __tmp53 = new StringBuilder();
                            __tmp53.Append(prop.Name);
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
                            string __tmp54Line = "("; //785:73
                            if (__tmp54Line != null) __out.Append(__tmp54Line);
                            StringBuilder __tmp55 = new StringBuilder();
                            __tmp55.Append(cls.JavaName());
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
                            string __tmp56Line = " _this) {"; //785:90
                            if (__tmp56Line != null) __out.Append(__tmp56Line);
                            __out.AppendLine(false); //785:99
                            __out.Append("        throw new UnsupportedOperationException();"); //786:1
                            __out.AppendLine(false); //786:51
                            __out.Append("    }"); //787:1
                            __out.AppendLine(false); //787:6
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //788:5
                        {
                            __out.AppendLine(true); //789:1
                            __out.Append("    /**"); //790:1
                            __out.AppendLine(false); //790:8
                            string __tmp58Line = "     * Returns the value of the lazy property: "; //791:1
                            if (__tmp58Line != null) __out.Append(__tmp58Line);
                            StringBuilder __tmp59 = new StringBuilder();
                            __tmp59.Append(cls.JavaName());
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
                            string __tmp60Line = "."; //791:64
                            if (__tmp60Line != null) __out.Append(__tmp60Line);
                            StringBuilder __tmp61 = new StringBuilder();
                            __tmp61.Append(prop.Name);
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
                                    __out.AppendLine(false); //791:76
                                }
                            }
                            __out.Append("     */"); //792:1
                            __out.AppendLine(false); //792:8
                            string __tmp63Line = "    public "; //793:1
                            if (__tmp63Line != null) __out.Append(__tmp63Line);
                            StringBuilder __tmp64 = new StringBuilder();
                            __tmp64.Append(prop.Type.JavaFullPublicName());
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
                            string __tmp65Line = " "; //793:44
                            if (__tmp65Line != null) __out.Append(__tmp65Line);
                            StringBuilder __tmp66 = new StringBuilder();
                            __tmp66.Append(cls.JavaName());
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
                            string __tmp67Line = "_"; //793:61
                            if (__tmp67Line != null) __out.Append(__tmp67Line);
                            StringBuilder __tmp68 = new StringBuilder();
                            __tmp68.Append(prop.Name);
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
                            string __tmp69Line = "("; //793:73
                            if (__tmp69Line != null) __out.Append(__tmp69Line);
                            StringBuilder __tmp70 = new StringBuilder();
                            __tmp70.Append(cls.JavaName());
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
                            string __tmp71Line = " _this) {"; //793:90
                            if (__tmp71Line != null) __out.Append(__tmp71Line);
                            __out.AppendLine(false); //793:99
                            __out.Append("        throw new UnsupportedOperationException();"); //794:1
                            __out.AppendLine(false); //794:51
                            __out.Append("    }"); //795:1
                            __out.AppendLine(false); //795:6
                        }
                    }
                }
                var __loop49_results = 
                    (from __loop49_var1 in __Enumerate((cls).GetEnumerator()) //799:11
                    from op in __Enumerate((__loop49_var1.Operations).GetEnumerator()) //799:16
                    select new { __loop49_var1 = __loop49_var1, op = op}
                    ).ToList(); //799:6
                for (int __loop49_iteration = 0; __loop49_iteration < __loop49_results.Count; ++__loop49_iteration)
                {
                    var __tmp72 = __loop49_results[__loop49_iteration];
                    var __loop49_var1 = __tmp72.__loop49_var1;
                    var op = __tmp72.op;
                    __out.AppendLine(true); //800:1
                    __out.Append("    /**"); //801:1
                    __out.AppendLine(false); //801:8
                    string __tmp74Line = "     * Implements the operation: "; //802:1
                    if (__tmp74Line != null) __out.Append(__tmp74Line);
                    StringBuilder __tmp75 = new StringBuilder();
                    __tmp75.Append(cls.JavaName());
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
                    string __tmp76Line = "."; //802:50
                    if (__tmp76Line != null) __out.Append(__tmp76Line);
                    StringBuilder __tmp77 = new StringBuilder();
                    __tmp77.Append(op.Name);
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
                    string __tmp78Line = "()"; //802:60
                    if (__tmp78Line != null) __out.Append(__tmp78Line);
                    __out.AppendLine(false); //802:62
                    __out.Append("     */"); //803:1
                    __out.AppendLine(false); //803:8
                    string __tmp80Line = "    public "; //804:1
                    if (__tmp80Line != null) __out.Append(__tmp80Line);
                    StringBuilder __tmp81 = new StringBuilder();
                    __tmp81.Append(op.ReturnType.JavaFullPublicName());
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
                    string __tmp82Line = " "; //804:48
                    if (__tmp82Line != null) __out.Append(__tmp82Line);
                    StringBuilder __tmp83 = new StringBuilder();
                    __tmp83.Append(cls.JavaName());
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
                    string __tmp84Line = "_"; //804:65
                    if (__tmp84Line != null) __out.Append(__tmp84Line);
                    StringBuilder __tmp85 = new StringBuilder();
                    __tmp85.Append(op.Name.ToCamelCase());
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
                    string __tmp86Line = "("; //804:89
                    if (__tmp86Line != null) __out.Append(__tmp86Line);
                    StringBuilder __tmp87 = new StringBuilder();
                    __tmp87.Append(GetImplParameters(cls, op));
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
                    string __tmp88Line = ") {"; //804:118
                    if (__tmp88Line != null) __out.Append(__tmp88Line);
                    __out.AppendLine(false); //804:121
                    __out.Append("        throw new UnsupportedOperationException();"); //805:1
                    __out.AppendLine(false); //805:51
                    __out.Append("    }"); //806:1
                    __out.AppendLine(false); //806:6
                }
                __out.AppendLine(true); //808:1
            }
            var __loop50_results = 
                (from __loop50_var1 in __Enumerate((model).GetEnumerator()) //810:8
                from Namespace in __Enumerate((__loop50_var1.Namespace).GetEnumerator()) //810:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //810:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //810:40
                select new { __loop50_var1 = __loop50_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //810:3
            for (int __loop50_iteration = 0; __loop50_iteration < __loop50_results.Count; ++__loop50_iteration)
            {
                var __tmp89 = __loop50_results[__loop50_iteration];
                var __loop50_var1 = __tmp89.__loop50_var1;
                var Namespace = __tmp89.Namespace;
                var Declarations = __tmp89.Declarations;
                var enm = __tmp89.enm;
                var __loop51_results = 
                    (from __loop51_var1 in __Enumerate((enm).GetEnumerator()) //811:11
                    from op in __Enumerate((__loop51_var1.Operations).GetEnumerator()) //811:16
                    select new { __loop51_var1 = __loop51_var1, op = op}
                    ).ToList(); //811:6
                for (int __loop51_iteration = 0; __loop51_iteration < __loop51_results.Count; ++__loop51_iteration)
                {
                    var __tmp90 = __loop51_results[__loop51_iteration];
                    var __loop51_var1 = __tmp90.__loop51_var1;
                    var op = __tmp90.op;
                    __out.AppendLine(true); //812:1
                    __out.Append("    /**"); //813:1
                    __out.AppendLine(false); //813:8
                    string __tmp92Line = "     * Implements the operation: "; //814:1
                    if (__tmp92Line != null) __out.Append(__tmp92Line);
                    StringBuilder __tmp93 = new StringBuilder();
                    __tmp93.Append(enm.JavaName());
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
                    string __tmp94Line = "."; //814:50
                    if (__tmp94Line != null) __out.Append(__tmp94Line);
                    StringBuilder __tmp95 = new StringBuilder();
                    __tmp95.Append(op.Name);
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
                            __out.AppendLine(false); //814:60
                        }
                    }
                    __out.Append("     */"); //815:1
                    __out.AppendLine(false); //815:8
                    string __tmp97Line = "    public "; //816:1
                    if (__tmp97Line != null) __out.Append(__tmp97Line);
                    StringBuilder __tmp98 = new StringBuilder();
                    __tmp98.Append(op.ReturnType.JavaFullPublicName());
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
                    string __tmp99Line = " "; //816:48
                    if (__tmp99Line != null) __out.Append(__tmp99Line);
                    StringBuilder __tmp100 = new StringBuilder();
                    __tmp100.Append(enm.JavaName());
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
                    string __tmp101Line = "_"; //816:65
                    if (__tmp101Line != null) __out.Append(__tmp101Line);
                    StringBuilder __tmp102 = new StringBuilder();
                    __tmp102.Append(op.Name.ToCamelCase());
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
                    string __tmp103Line = "("; //816:89
                    if (__tmp103Line != null) __out.Append(__tmp103Line);
                    StringBuilder __tmp104 = new StringBuilder();
                    __tmp104.Append(GetImplParameters(enm, op));
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
                    string __tmp105Line = ") {"; //816:118
                    if (__tmp105Line != null) __out.Append(__tmp105Line);
                    __out.AppendLine(false); //816:121
                    __out.Append("        throw new UnsupportedOperationException();"); //817:1
                    __out.AppendLine(false); //817:51
                    __out.Append("    }"); //818:1
                    __out.AppendLine(false); //818:6
                }
                __out.AppendLine(true); //820:1
            }
            __out.Append("}"); //822:1
            __out.AppendLine(false); //822:2
            __out.AppendLine(true); //823:1
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //826:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "package "; //827:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.Namespace.JavaName());
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
            string __tmp4Line = ";"; //827:37
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //827:38
            __out.AppendLine(true); //828:1
            __out.Append("import metadslx.core.ModelFactory;"); //829:1
            __out.AppendLine(false); //829:35
            __out.Append("import metadslx.core.ModelObject;"); //830:1
            __out.AppendLine(false); //830:34
            __out.Append("import metadslx.core.ModelPropertyInitializer;"); //831:1
            __out.AppendLine(false); //831:47
            __out.AppendLine(true); //832:1
            __out.Append("/**"); //833:1
            __out.AppendLine(false); //833:4
            __out.Append(" * Factory class for creating instances of model elements."); //834:1
            __out.AppendLine(false); //834:59
            __out.Append(" */"); //835:1
            __out.AppendLine(false); //835:4
            string __tmp6Line = "public class "; //836:1
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(model.JavaFactoryName());
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
            string __tmp8Line = " extends ModelFactory {"; //836:39
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //836:62
            string __tmp10Line = "    private static "; //837:1
            if (__tmp10Line != null) __out.Append(__tmp10Line);
            StringBuilder __tmp11 = new StringBuilder();
            __tmp11.Append(model.JavaFactoryName());
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
            string __tmp12Line = " instance = new "; //837:45
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(model.JavaFactoryName());
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
            string __tmp14Line = "();"; //837:86
            if (__tmp14Line != null) __out.Append(__tmp14Line);
            __out.AppendLine(false); //837:89
            __out.AppendLine(true); //838:1
            string __tmp16Line = "	private "; //839:1
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(model.JavaFactoryName());
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
            string __tmp18Line = "()"; //839:35
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //839:37
            __out.Append("	{"); //840:1
            __out.AppendLine(false); //840:3
            __out.Append("	}"); //841:1
            __out.AppendLine(false); //841:3
            __out.AppendLine(true); //842:1
            __out.Append("    /**"); //843:1
            __out.AppendLine(false); //843:8
            __out.Append("     * The singleton instance of the factory."); //844:1
            __out.AppendLine(false); //844:46
            __out.Append("     */"); //845:1
            __out.AppendLine(false); //845:8
            string __tmp20Line = "    public static "; //846:1
            if (__tmp20Line != null) __out.Append(__tmp20Line);
            StringBuilder __tmp21 = new StringBuilder();
            __tmp21.Append(model.JavaFactoryName());
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
            string __tmp22Line = " instance() {"; //846:44
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            __out.AppendLine(false); //846:57
            string __tmp24Line = "        return "; //847:1
            if (__tmp24Line != null) __out.Append(__tmp24Line);
            StringBuilder __tmp25 = new StringBuilder();
            __tmp25.Append(model.JavaFactoryName());
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
            string __tmp26Line = ".instance;"; //847:41
            if (__tmp26Line != null) __out.Append(__tmp26Line);
            __out.AppendLine(false); //847:51
            __out.Append("    }"); //848:1
            __out.AppendLine(false); //848:6
            var __loop52_results = 
                (from __loop52_var1 in __Enumerate((model).GetEnumerator()) //849:8
                from Namespace in __Enumerate((__loop52_var1.Namespace).GetEnumerator()) //849:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //849:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //849:40
                select new { __loop52_var1 = __loop52_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //849:3
            for (int __loop52_iteration = 0; __loop52_iteration < __loop52_results.Count; ++__loop52_iteration)
            {
                var __tmp27 = __loop52_results[__loop52_iteration];
                var __loop52_var1 = __tmp27.__loop52_var1;
                var Namespace = __tmp27.Namespace;
                var Declarations = __tmp27.Declarations;
                var cls = __tmp27.cls;
                if (!cls.IsAbstract) //850:4
                {
                    __out.AppendLine(true); //851:1
                    __out.Append("    /**"); //852:1
                    __out.AppendLine(false); //852:8
                    string __tmp29Line = "     * Creates a new instance of "; //853:1
                    if (__tmp29Line != null) __out.Append(__tmp29Line);
                    StringBuilder __tmp30 = new StringBuilder();
                    __tmp30.Append(cls.JavaName());
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
                    string __tmp31Line = "."; //853:50
                    if (__tmp31Line != null) __out.Append(__tmp31Line);
                    __out.AppendLine(false); //853:51
                    __out.Append("     */"); //854:1
                    __out.AppendLine(false); //854:8
                    string __tmp33Line = "    public "; //855:1
                    if (__tmp33Line != null) __out.Append(__tmp33Line);
                    StringBuilder __tmp34 = new StringBuilder();
                    __tmp34.Append(cls.JavaName());
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
                    string __tmp35Line = " create"; //855:28
                    if (__tmp35Line != null) __out.Append(__tmp35Line);
                    StringBuilder __tmp36 = new StringBuilder();
                    __tmp36.Append(cls.JavaName());
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
                    string __tmp37Line = "() {"; //855:51
                    if (__tmp37Line != null) __out.Append(__tmp37Line);
                    __out.AppendLine(false); //855:55
                    string __tmp39Line = "		return this.create"; //856:1
                    if (__tmp39Line != null) __out.Append(__tmp39Line);
                    StringBuilder __tmp40 = new StringBuilder();
                    __tmp40.Append(cls.JavaName());
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
                    string __tmp41Line = "(null);"; //856:37
                    if (__tmp41Line != null) __out.Append(__tmp41Line);
                    __out.AppendLine(false); //856:44
                    __out.Append("	}"); //857:1
                    __out.AppendLine(false); //857:3
                    __out.Append("    /**"); //859:1
                    __out.AppendLine(false); //859:8
                    string __tmp43Line = "     * Creates a new instance of "; //860:1
                    if (__tmp43Line != null) __out.Append(__tmp43Line);
                    StringBuilder __tmp44 = new StringBuilder();
                    __tmp44.Append(cls.JavaName());
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
                    string __tmp45Line = "."; //860:50
                    if (__tmp45Line != null) __out.Append(__tmp45Line);
                    __out.AppendLine(false); //860:51
                    __out.Append("     */"); //861:1
                    __out.AppendLine(false); //861:8
                    string __tmp47Line = "    public "; //862:1
                    if (__tmp47Line != null) __out.Append(__tmp47Line);
                    StringBuilder __tmp48 = new StringBuilder();
                    __tmp48.Append(cls.JavaName());
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
                    string __tmp49Line = " create"; //862:28
                    if (__tmp49Line != null) __out.Append(__tmp49Line);
                    StringBuilder __tmp50 = new StringBuilder();
                    __tmp50.Append(cls.JavaName());
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
                    string __tmp51Line = "(Iterable<ModelPropertyInitializer> initializers) {"; //862:51
                    if (__tmp51Line != null) __out.Append(__tmp51Line);
                    __out.AppendLine(false); //862:102
                    string __tmp52Prefix = "		"; //863:1
                    StringBuilder __tmp53 = new StringBuilder();
                    __tmp53.Append(cls.JavaName());
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
                        }
                    }
                    string __tmp54Line = " result = new "; //863:19
                    if (__tmp54Line != null) __out.Append(__tmp54Line);
                    StringBuilder __tmp55 = new StringBuilder();
                    __tmp55.Append(cls.JavaFullName());
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
                    string __tmp56Line = "Impl();"; //863:53
                    if (__tmp56Line != null) __out.Append(__tmp56Line);
                    __out.AppendLine(false); //863:60
                    __out.Append("		if (initializers != null) {"); //864:1
                    __out.AppendLine(false); //864:30
                    __out.Append("			this.init((ModelObject)result, initializers);"); //865:1
                    __out.AppendLine(false); //865:49
                    __out.Append("		}"); //866:1
                    __out.AppendLine(false); //866:4
                    __out.Append("		return result;"); //867:1
                    __out.AppendLine(false); //867:17
                    __out.Append("	}"); //868:1
                    __out.AppendLine(false); //868:3
                }
            }
            __out.Append("}"); //871:1
            __out.AppendLine(false); //871:2
            __out.AppendLine(true); //872:1
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
