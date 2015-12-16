using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core //1:1
{
    using __Hidden_MetaModelJavaGenerator_1860972450;
    namespace __Hidden_MetaModelJavaGenerator_1860972450
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

        public string Generate() //4:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop1_results = 
                (from __loop1_var1 in __Enumerate((Instances).GetEnumerator()) //5:8
                from mm in __Enumerate((__loop1_var1).GetEnumerator()).OfType<MetaModel>() //5:19
                select new { __loop1_var1 = __loop1_var1, mm = mm}
                ).ToList(); //5:3
            int __loop1_iteration = 0;
            foreach (var __tmp1 in __loop1_results)
            {
                ++__loop1_iteration;
                var __loop1_var1 = __tmp1.__loop1_var1;
                var mm = __tmp1.mm;
                string __tmp2Prefix = string.Empty;
                string __tmp3Suffix = string.Empty;
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append(GenerateMetamodel(mm));
                using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                {
                    bool __tmp4_first = true;
                    while(__tmp4_first || !__tmp4Reader.EndOfStream)
                    {
                        __tmp4_first = false;
                        string __tmp4Line = __tmp4Reader.ReadLine();
                        if (__tmp4Line == null)
                        {
                            __tmp4Line = "";
                        }
                        __out.Append(__tmp2Prefix);
                        __out.Append(__tmp4Line);
                        __out.Append(__tmp3Suffix);
                        __out.AppendLine(); //6:24
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateMetamodel(MetaModel model) //10:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty;
            string __tmp2Suffix = string.Empty;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateMetaModelDescriptor(model));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //11:37
                }
            }
            string __tmp4Prefix = string.Empty;
            string __tmp5Suffix = string.Empty;
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(GenerateMetaModelInstance(model));
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                while(__tmp6_first || !__tmp6Reader.EndOfStream)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    if (__tmp6Line == null)
                    {
                        __tmp6Line = "";
                    }
                    __out.Append(__tmp4Prefix);
                    __out.Append(__tmp6Line);
                    __out.Append(__tmp5Suffix);
                    __out.AppendLine(); //12:35
                }
            }
            var __loop2_results = 
                (from __loop2_var1 in __Enumerate((model).GetEnumerator()) //13:7
                from Namespace in __Enumerate((__loop2_var1.Namespace).GetEnumerator()) //13:14
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //13:25
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //13:39
                select new { __loop2_var1 = __loop2_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //13:2
            int __loop2_iteration = 0;
            foreach (var __tmp7 in __loop2_results)
            {
                ++__loop2_iteration;
                var __loop2_var1 = __tmp7.__loop2_var1;
                var Namespace = __tmp7.Namespace;
                var Declarations = __tmp7.Declarations;
                var enm = __tmp7.enm;
                string __tmp8Prefix = string.Empty;
                string __tmp9Suffix = string.Empty;
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(GenerateEnum(enm));
                using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
                {
                    bool __tmp10_first = true;
                    while(__tmp10_first || !__tmp10Reader.EndOfStream)
                    {
                        __tmp10_first = false;
                        string __tmp10Line = __tmp10Reader.ReadLine();
                        if (__tmp10Line == null)
                        {
                            __tmp10Line = "";
                        }
                        __out.Append(__tmp8Prefix);
                        __out.Append(__tmp10Line);
                        __out.Append(__tmp9Suffix);
                        __out.AppendLine(); //14:20
                    }
                }
            }
            var __loop3_results = 
                (from __loop3_var1 in __Enumerate((model).GetEnumerator()) //16:7
                from Namespace in __Enumerate((__loop3_var1.Namespace).GetEnumerator()) //16:14
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //16:25
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //16:39
                select new { __loop3_var1 = __loop3_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //16:2
            int __loop3_iteration = 0;
            foreach (var __tmp11 in __loop3_results)
            {
                ++__loop3_iteration;
                var __loop3_var1 = __tmp11.__loop3_var1;
                var Namespace = __tmp11.Namespace;
                var Declarations = __tmp11.Declarations;
                var cls = __tmp11.cls;
                string __tmp12Prefix = string.Empty;
                string __tmp13Suffix = string.Empty;
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(GenerateInterface(cls));
                using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
                {
                    bool __tmp14_first = true;
                    while(__tmp14_first || !__tmp14Reader.EndOfStream)
                    {
                        __tmp14_first = false;
                        string __tmp14Line = __tmp14Reader.ReadLine();
                        if (__tmp14Line == null)
                        {
                            __tmp14Line = "";
                        }
                        __out.Append(__tmp12Prefix);
                        __out.Append(__tmp14Line);
                        __out.Append(__tmp13Suffix);
                        __out.AppendLine(); //17:25
                    }
                }
                string __tmp15Prefix = string.Empty;
                string __tmp16Suffix = string.Empty;
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(GenerateInterfaceImpl(model, cls));
                using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
                {
                    bool __tmp17_first = true;
                    while(__tmp17_first || !__tmp17Reader.EndOfStream)
                    {
                        __tmp17_first = false;
                        string __tmp17Line = __tmp17Reader.ReadLine();
                        if (__tmp17Line == null)
                        {
                            __tmp17Line = "";
                        }
                        __out.Append(__tmp15Prefix);
                        __out.Append(__tmp17Line);
                        __out.Append(__tmp16Suffix);
                        __out.AppendLine(); //18:36
                    }
                }
            }
            string __tmp18Prefix = string.Empty;
            string __tmp19Suffix = string.Empty;
            StringBuilder __tmp20 = new StringBuilder();
            __tmp20.Append(GenerateFactory(model));
            using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
            {
                bool __tmp20_first = true;
                while(__tmp20_first || !__tmp20Reader.EndOfStream)
                {
                    __tmp20_first = false;
                    string __tmp20Line = __tmp20Reader.ReadLine();
                    if (__tmp20Line == null)
                    {
                        __tmp20Line = "";
                    }
                    __out.Append(__tmp18Prefix);
                    __out.Append(__tmp20Line);
                    __out.Append(__tmp19Suffix);
                    __out.AppendLine(); //20:25
                }
            }
            string __tmp21Prefix = string.Empty;
            string __tmp22Suffix = string.Empty;
            StringBuilder __tmp23 = new StringBuilder();
            __tmp23.Append(GenerateImplementationProvider(model));
            using(StreamReader __tmp23Reader = new StreamReader(this.__ToStream(__tmp23.ToString())))
            {
                bool __tmp23_first = true;
                while(__tmp23_first || !__tmp23Reader.EndOfStream)
                {
                    __tmp23_first = false;
                    string __tmp23Line = __tmp23Reader.ReadLine();
                    if (__tmp23Line == null)
                    {
                        __tmp23Line = "";
                    }
                    __out.Append(__tmp21Prefix);
                    __out.Append(__tmp23Line);
                    __out.Append(__tmp22Suffix);
                    __out.AppendLine(); //21:40
                }
            }
            string __tmp24Prefix = string.Empty;
            string __tmp25Suffix = string.Empty;
            StringBuilder __tmp26 = new StringBuilder();
            __tmp26.Append(GenerateImplementationBase(model));
            using(StreamReader __tmp26Reader = new StreamReader(this.__ToStream(__tmp26.ToString())))
            {
                bool __tmp26_first = true;
                while(__tmp26_first || !__tmp26Reader.EndOfStream)
                {
                    __tmp26_first = false;
                    string __tmp26Line = __tmp26Reader.ReadLine();
                    if (__tmp26Line == null)
                    {
                        __tmp26Line = "";
                    }
                    __out.Append(__tmp24Prefix);
                    __out.Append(__tmp26Line);
                    __out.Append(__tmp25Suffix);
                    __out.AppendLine(); //22:36
                }
            }
            return __out.ToString();
        }

        public string GenerateAnnotations(MetaAnnotatedElement elem) //25:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop4_results = 
                (from __loop4_var1 in __Enumerate((elem).GetEnumerator()) //26:7
                from annot in __Enumerate((__loop4_var1.Annotations).GetEnumerator()) //26:13
                select new { __loop4_var1 = __loop4_var1, annot = annot}
                ).ToList(); //26:2
            int __loop4_iteration = 0;
            foreach (var __tmp1 in __loop4_results)
            {
                ++__loop4_iteration;
                var __loop4_var1 = __tmp1.__loop4_var1;
                var annot = __tmp1.annot;
                string __tmp2Prefix = "@"; //27:1
                string __tmp3Suffix = string.Empty; 
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append(annot.Name);
                using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                {
                    bool __tmp4_first = true;
                    while(__tmp4_first || !__tmp4Reader.EndOfStream)
                    {
                        __tmp4_first = false;
                        string __tmp4Line = __tmp4Reader.ReadLine();
                        if (__tmp4Line == null)
                        {
                            __tmp4Line = "";
                        }
                        __out.Append(__tmp2Prefix);
                        __out.Append(__tmp4Line);
                        __out.Append(__tmp3Suffix);
                        __out.AppendLine(); //27:14
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateEnum(MetaEnum enm) //31:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "package "; //32:1
            string __tmp2Suffix = ";"; //32:35
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(enm.Namespace.JavaName());
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //32:36
                }
            }
            __out.AppendLine(); //33:1
            string __tmp4Prefix = string.Empty;
            string __tmp5Suffix = string.Empty;
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(GenerateAnnotations(enm));
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                while(__tmp6_first || !__tmp6Reader.EndOfStream)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    if (__tmp6Line == null)
                    {
                        __tmp6Line = "";
                    }
                    __out.Append(__tmp4Prefix);
                    __out.Append(__tmp6Line);
                    __out.Append(__tmp5Suffix);
                    __out.AppendLine(); //34:27
                }
            }
            string __tmp7Prefix = "public enum "; //35:1
            string __tmp8Suffix = " {"; //35:29
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(enm.JavaName());
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_first = true;
                while(__tmp9_first || !__tmp9Reader.EndOfStream)
                {
                    __tmp9_first = false;
                    string __tmp9Line = __tmp9Reader.ReadLine();
                    if (__tmp9Line == null)
                    {
                        __tmp9Line = "";
                    }
                    __out.Append(__tmp7Prefix);
                    __out.Append(__tmp9Line);
                    __out.Append(__tmp8Suffix);
                    __out.AppendLine(); //35:31
                }
            }
            var __loop5_results = 
                (from __loop5_var1 in __Enumerate((enm).GetEnumerator()) //36:11
                from value in __Enumerate((__loop5_var1.EnumLiterals).GetEnumerator()) //36:16
                select new { __loop5_var1 = __loop5_var1, value = value}
                ).ToList(); //36:6
            int __loop5_iteration = 0;
            string delim = ""; //36:36
            foreach (var __tmp10 in __loop5_results)
            {
                ++__loop5_iteration;
                if (__loop5_iteration >= 2) //36:55
                {
                    delim = ","; //36:55
                }
                var __loop5_var1 = __tmp10.__loop5_var1;
                var value = __tmp10.value;
                string __tmp11Prefix = string.Empty;
                string __tmp12Suffix = string.Empty;
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(delim);
                using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                {
                    bool __tmp13_first = true;
                    while(__tmp13_first || !__tmp13Reader.EndOfStream)
                    {
                        __tmp13_first = false;
                        string __tmp13Line = __tmp13Reader.ReadLine();
                        if (__tmp13Line == null)
                        {
                            __tmp13Line = "";
                        }
                        __out.Append(__tmp11Prefix);
                        __out.Append(__tmp13Line);
                        __out.Append(__tmp12Suffix);
                        __out.AppendLine(); //37:8
                    }
                }
                string __tmp14Prefix = "    "; //38:1
                string __tmp15Suffix = string.Empty; 
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(value.Name);
                using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
                {
                    bool __tmp16_first = true;
                    while(__tmp16_first || !__tmp16Reader.EndOfStream)
                    {
                        __tmp16_first = false;
                        string __tmp16Line = __tmp16Reader.ReadLine();
                        if (__tmp16Line == null)
                        {
                            __tmp16Line = "";
                        }
                        __out.Append(__tmp14Prefix);
                        __out.Append(__tmp16Line);
                        __out.Append(__tmp15Suffix);
                    }
                }
            }
            __out.Append(";"); //40:1
            __out.AppendLine(); //40:2
            var __loop6_results = 
                (from __loop6_var1 in __Enumerate((enm).GetEnumerator()) //41:7
                from op in __Enumerate((__loop6_var1.Operations).GetEnumerator()) //41:12
                select new { __loop6_var1 = __loop6_var1, op = op}
                ).ToList(); //41:2
            int __loop6_iteration = 0;
            foreach (var __tmp17 in __loop6_results)
            {
                ++__loop6_iteration;
                var __loop6_var1 = __tmp17.__loop6_var1;
                var op = __tmp17.op;
                __out.AppendLine(); //42:1
                string __tmp18Prefix = "    public "; //43:1
                string __tmp19Suffix = ") {"; //43:105
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(op.ReturnType.JavaFullPublicName());
                using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
                {
                    bool __tmp20_first = true;
                    while(__tmp20_first || !__tmp20Reader.EndOfStream)
                    {
                        __tmp20_first = false;
                        string __tmp20Line = __tmp20Reader.ReadLine();
                        if (__tmp20Line == null)
                        {
                            __tmp20Line = "";
                        }
                        __out.Append(__tmp18Prefix);
                        __out.Append(__tmp20Line);
                    }
                }
                string __tmp21Line = " "; //43:48
                __out.Append(__tmp21Line);
                StringBuilder __tmp22 = new StringBuilder();
                __tmp22.Append(op.Name.ToCamelCase());
                using(StreamReader __tmp22Reader = new StreamReader(this.__ToStream(__tmp22.ToString())))
                {
                    bool __tmp22_first = true;
                    while(__tmp22_first || !__tmp22Reader.EndOfStream)
                    {
                        __tmp22_first = false;
                        string __tmp22Line = __tmp22Reader.ReadLine();
                        if (__tmp22Line == null)
                        {
                            __tmp22Line = "";
                        }
                        __out.Append(__tmp22Line);
                    }
                }
                string __tmp23Line = "("; //43:72
                __out.Append(__tmp23Line);
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(GetEnumImplParameters(enm, op));
                using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
                {
                    bool __tmp24_first = true;
                    while(__tmp24_first || !__tmp24Reader.EndOfStream)
                    {
                        __tmp24_first = false;
                        string __tmp24Line = __tmp24Reader.ReadLine();
                        if (__tmp24Line == null)
                        {
                            __tmp24Line = "";
                        }
                        __out.Append(__tmp24Line);
                        __out.Append(__tmp19Suffix);
                        __out.AppendLine(); //43:108
                    }
                }
                string __tmp25Prefix = "        "; //44:1
                string __tmp26Suffix = ");"; //44:162
                StringBuilder __tmp27 = new StringBuilder();
                __tmp27.Append(GetReturn(op));
                using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
                {
                    bool __tmp27_first = true;
                    while(__tmp27_first || !__tmp27Reader.EndOfStream)
                    {
                        __tmp27_first = false;
                        string __tmp27Line = __tmp27Reader.ReadLine();
                        if (__tmp27Line == null)
                        {
                            __tmp27Line = "";
                        }
                        __out.Append(__tmp25Prefix);
                        __out.Append(__tmp27Line);
                    }
                }
                StringBuilder __tmp28 = new StringBuilder();
                __tmp28.Append(enm.Model.Name);
                using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
                {
                    bool __tmp28_first = true;
                    while(__tmp28_first || !__tmp28Reader.EndOfStream)
                    {
                        __tmp28_first = false;
                        string __tmp28Line = __tmp28Reader.ReadLine();
                        if (__tmp28Line == null)
                        {
                            __tmp28Line = "";
                        }
                        __out.Append(__tmp28Line);
                    }
                }
                string __tmp29Line = "ImplementationProvider.implementation()."; //44:40
                __out.Append(__tmp29Line);
                StringBuilder __tmp30 = new StringBuilder();
                __tmp30.Append(op.Parent.JavaName());
                using(StreamReader __tmp30Reader = new StreamReader(this.__ToStream(__tmp30.ToString())))
                {
                    bool __tmp30_first = true;
                    while(__tmp30_first || !__tmp30Reader.EndOfStream)
                    {
                        __tmp30_first = false;
                        string __tmp30Line = __tmp30Reader.ReadLine();
                        if (__tmp30Line == null)
                        {
                            __tmp30Line = "";
                        }
                        __out.Append(__tmp30Line);
                    }
                }
                string __tmp31Line = "_"; //44:102
                __out.Append(__tmp31Line);
                StringBuilder __tmp32 = new StringBuilder();
                __tmp32.Append(op.Name.ToCamelCase());
                using(StreamReader __tmp32Reader = new StreamReader(this.__ToStream(__tmp32.ToString())))
                {
                    bool __tmp32_first = true;
                    while(__tmp32_first || !__tmp32Reader.EndOfStream)
                    {
                        __tmp32_first = false;
                        string __tmp32Line = __tmp32Reader.ReadLine();
                        if (__tmp32Line == null)
                        {
                            __tmp32Line = "";
                        }
                        __out.Append(__tmp32Line);
                    }
                }
                string __tmp33Line = "("; //44:126
                __out.Append(__tmp33Line);
                StringBuilder __tmp34 = new StringBuilder();
                __tmp34.Append(GetEnumImplCallParameterNames(op));
                using(StreamReader __tmp34Reader = new StreamReader(this.__ToStream(__tmp34.ToString())))
                {
                    bool __tmp34_first = true;
                    while(__tmp34_first || !__tmp34Reader.EndOfStream)
                    {
                        __tmp34_first = false;
                        string __tmp34Line = __tmp34Reader.ReadLine();
                        if (__tmp34Line == null)
                        {
                            __tmp34Line = "";
                        }
                        __out.Append(__tmp34Line);
                        __out.Append(__tmp26Suffix);
                        __out.AppendLine(); //44:164
                    }
                }
                __out.Append("    }"); //45:1
                __out.AppendLine(); //45:6
            }
            __out.Append("}"); //47:1
            __out.AppendLine(); //47:2
            __out.AppendLine(); //48:1
            return __out.ToString();
        }

        public string GetAncestors(MetaClass cls) //51:1
        {
            string result = ""; //52:2
            var __loop7_results = 
                (from __loop7_var1 in __Enumerate((cls).GetEnumerator()) //53:7
                from super in __Enumerate((__loop7_var1.SuperClasses).GetEnumerator()) //53:12
                select new { __loop7_var1 = __loop7_var1, super = super}
                ).ToList(); //53:2
            int __loop7_iteration = 0;
            string delim = " extends "; //53:32
            foreach (var __tmp1 in __loop7_results)
            {
                ++__loop7_iteration;
                if (__loop7_iteration >= 2) //53:60
                {
                    delim = ", "; //53:60
                }
                var __loop7_var1 = __tmp1.__loop7_var1;
                var super = __tmp1.super;
                result += delim + super.JavaFullName(); //54:3
            }
            return result; //56:2
        }

        public string GenerateInterface(MetaClass cls) //59:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "package "; //60:1
            string __tmp2Suffix = ";"; //60:35
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.Namespace.JavaName());
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //60:36
                }
            }
            __out.AppendLine(); //61:1
            string __tmp4Prefix = string.Empty;
            string __tmp5Suffix = string.Empty;
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(GenerateAnnotations(cls));
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                while(__tmp6_first || !__tmp6Reader.EndOfStream)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    if (__tmp6Line == null)
                    {
                        __tmp6Line = "";
                    }
                    __out.Append(__tmp4Prefix);
                    __out.Append(__tmp6Line);
                    __out.Append(__tmp5Suffix);
                    __out.AppendLine(); //62:27
                }
            }
            string __tmp7Prefix = "public interface "; //63:1
            string __tmp8Suffix = string.Empty; 
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(cls.JavaName());
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_first = true;
                while(__tmp9_first || !__tmp9Reader.EndOfStream)
                {
                    __tmp9_first = false;
                    string __tmp9Line = __tmp9Reader.ReadLine();
                    if (__tmp9Line == null)
                    {
                        __tmp9Line = "";
                    }
                    __out.Append(__tmp7Prefix);
                    __out.Append(__tmp9Line);
                }
            }
            StringBuilder __tmp10 = new StringBuilder();
            __tmp10.Append(GetAncestors(cls));
            using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
            {
                bool __tmp10_first = true;
                while(__tmp10_first || !__tmp10Reader.EndOfStream)
                {
                    __tmp10_first = false;
                    string __tmp10Line = __tmp10Reader.ReadLine();
                    if (__tmp10Line == null)
                    {
                        __tmp10Line = "";
                    }
                    __out.Append(__tmp10Line);
                    __out.Append(__tmp8Suffix);
                    __out.AppendLine(); //63:53
                }
            }
            __out.Append("{"); //64:1
            __out.AppendLine(); //64:2
            var __loop8_results = 
                (from __loop8_var1 in __Enumerate((cls).GetEnumerator()) //65:11
                from prop in __Enumerate((__loop8_var1.Properties).GetEnumerator()) //65:16
                select new { __loop8_var1 = __loop8_var1, prop = prop}
                ).ToList(); //65:6
            int __loop8_iteration = 0;
            foreach (var __tmp11 in __loop8_results)
            {
                ++__loop8_iteration;
                var __loop8_var1 = __tmp11.__loop8_var1;
                var prop = __tmp11.prop;
                string __tmp12Prefix = "    "; //66:1
                string __tmp13Suffix = string.Empty; 
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(GenerateProperty(prop));
                using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
                {
                    bool __tmp14_first = true;
                    while(__tmp14_first || !__tmp14Reader.EndOfStream)
                    {
                        __tmp14_first = false;
                        string __tmp14Line = __tmp14Reader.ReadLine();
                        if (__tmp14Line == null)
                        {
                            __tmp14Line = "";
                        }
                        __out.Append(__tmp12Prefix);
                        __out.Append(__tmp14Line);
                        __out.Append(__tmp13Suffix);
                        __out.AppendLine(); //66:29
                    }
                }
            }
            __out.AppendLine(); //68:1
            var __loop9_results = 
                (from __loop9_var1 in __Enumerate((cls).GetEnumerator()) //69:11
                from op in __Enumerate((__loop9_var1.Operations).GetEnumerator()) //69:16
                select new { __loop9_var1 = __loop9_var1, op = op}
                ).ToList(); //69:6
            int __loop9_iteration = 0;
            foreach (var __tmp15 in __loop9_results)
            {
                ++__loop9_iteration;
                var __loop9_var1 = __tmp15.__loop9_var1;
                var op = __tmp15.op;
                string __tmp16Prefix = "    "; //70:1
                string __tmp17Suffix = string.Empty; 
                StringBuilder __tmp18 = new StringBuilder();
                __tmp18.Append(GenerateOperation(op));
                using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
                {
                    bool __tmp18_first = true;
                    while(__tmp18_first || !__tmp18Reader.EndOfStream)
                    {
                        __tmp18_first = false;
                        string __tmp18Line = __tmp18Reader.ReadLine();
                        if (__tmp18Line == null)
                        {
                            __tmp18Line = "";
                        }
                        __out.Append(__tmp16Prefix);
                        __out.Append(__tmp18Line);
                        __out.Append(__tmp17Suffix);
                        __out.AppendLine(); //70:28
                    }
                }
            }
            __out.Append("}"); //72:1
            __out.AppendLine(); //72:2
            __out.AppendLine(); //73:1
            return __out.ToString();
        }

        public string GenerateProperty(MetaProperty prop) //76:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = "();"; //77:68
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(prop.Type.JavaFullPublicName());
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                }
            }
            string __tmp4Line = " "; //77:33
            __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(("get" + prop.Name).SafeJavaName());
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_first = true;
                while(__tmp5_first || !__tmp5Reader.EndOfStream)
                {
                    __tmp5_first = false;
                    string __tmp5Line = __tmp5Reader.ReadLine();
                    if (__tmp5Line == null)
                    {
                        __tmp5Line = "";
                    }
                    __out.Append(__tmp5Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //77:71
                }
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //78:3
            {
                string __tmp6Prefix = "void "; //79:1
                string __tmp7Suffix = " value);"; //79:73
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(("set" + prop.Name).SafeJavaName());
                using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                {
                    bool __tmp8_first = true;
                    while(__tmp8_first || !__tmp8Reader.EndOfStream)
                    {
                        __tmp8_first = false;
                        string __tmp8Line = __tmp8Reader.ReadLine();
                        if (__tmp8Line == null)
                        {
                            __tmp8Line = "";
                        }
                        __out.Append(__tmp6Prefix);
                        __out.Append(__tmp8Line);
                    }
                }
                string __tmp9Line = "("; //79:40
                __out.Append(__tmp9Line);
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(prop.Type.JavaFullPublicName());
                using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
                {
                    bool __tmp10_first = true;
                    while(__tmp10_first || !__tmp10Reader.EndOfStream)
                    {
                        __tmp10_first = false;
                        string __tmp10Line = __tmp10Reader.ReadLine();
                        if (__tmp10Line == null)
                        {
                            __tmp10Line = "";
                        }
                        __out.Append(__tmp10Line);
                        __out.Append(__tmp7Suffix);
                        __out.AppendLine(); //79:81
                    }
                }
            }
            return __out.ToString();
        }

        public string GetParameters(MetaOperation op, bool defaultValues) //83:1
        {
            string result = ""; //84:2
            var __loop10_results = 
                (from __loop10_var1 in __Enumerate((op).GetEnumerator()) //85:7
                from param in __Enumerate((__loop10_var1.Parameters).GetEnumerator()) //85:11
                select new { __loop10_var1 = __loop10_var1, param = param}
                ).ToList(); //85:2
            int __loop10_iteration = 0;
            string delim = ""; //85:29
            foreach (var __tmp1 in __loop10_results)
            {
                ++__loop10_iteration;
                if (__loop10_iteration >= 2) //85:48
                {
                    delim = ", "; //85:48
                }
                var __loop10_var1 = __tmp1.__loop10_var1;
                var param = __tmp1.param;
                result += delim + param.Type.JavaFullPublicName() + " " + param.Name; //86:3
            }
            return result; //88:2
        }

        public string GetImplParameters(MetaClass cls, MetaOperation op) //91:1
        {
            string result = cls.JavaFullName() + " _this"; //92:2
            string delim = ", "; //93:2
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((op).GetEnumerator()) //94:7
                from param in __Enumerate((__loop11_var1.Parameters).GetEnumerator()) //94:11
                select new { __loop11_var1 = __loop11_var1, param = param}
                ).ToList(); //94:2
            int __loop11_iteration = 0;
            foreach (var __tmp1 in __loop11_results)
            {
                ++__loop11_iteration;
                var __loop11_var1 = __tmp1.__loop11_var1;
                var param = __tmp1.param;
                result += delim + param.Type.JavaFullPublicName() + " " + param.Name; //95:3
            }
            return result; //97:2
        }

        public string GetImplParameters(MetaEnum enm, MetaOperation op) //100:1
        {
            string result = enm.JavaFullName() + " _this"; //101:2
            string delim = ", "; //102:2
            var __loop12_results = 
                (from __loop12_var1 in __Enumerate((op).GetEnumerator()) //103:7
                from param in __Enumerate((__loop12_var1.Parameters).GetEnumerator()) //103:11
                select new { __loop12_var1 = __loop12_var1, param = param}
                ).ToList(); //103:2
            int __loop12_iteration = 0;
            foreach (var __tmp1 in __loop12_results)
            {
                ++__loop12_iteration;
                var __loop12_var1 = __tmp1.__loop12_var1;
                var param = __tmp1.param;
                result += delim + param.Type.JavaFullPublicName() + " " + param.Name; //104:3
            }
            return result; //106:2
        }

        public string GetEnumImplParameters(MetaEnum enm, MetaOperation op) //109:1
        {
            string result = enm.JavaFullName() + " _this"; //110:2
            string delim = ", "; //111:2
            var __loop13_results = 
                (from __loop13_var1 in __Enumerate((op).GetEnumerator()) //112:7
                from param in __Enumerate((__loop13_var1.Parameters).GetEnumerator()) //112:11
                select new { __loop13_var1 = __loop13_var1, param = param}
                ).ToList(); //112:2
            int __loop13_iteration = 0;
            foreach (var __tmp1 in __loop13_results)
            {
                ++__loop13_iteration;
                var __loop13_var1 = __tmp1.__loop13_var1;
                var param = __tmp1.param;
                result += delim + param.Type.JavaFullPublicName() + " " + param.Name; //113:3
            }
            return result; //115:2
        }

        public string GetEnumImplCallParameterNames(MetaOperation op) //118:1
        {
            string result = "_this"; //119:2
            string delim = ", "; //120:2
            var __loop14_results = 
                (from __loop14_var1 in __Enumerate((op).GetEnumerator()) //121:7
                from param in __Enumerate((__loop14_var1.Parameters).GetEnumerator()) //121:11
                select new { __loop14_var1 = __loop14_var1, param = param}
                ).ToList(); //121:2
            int __loop14_iteration = 0;
            foreach (var __tmp1 in __loop14_results)
            {
                ++__loop14_iteration;
                var __loop14_var1 = __tmp1.__loop14_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //122:3
            }
            return result; //124:2
        }

        public string GetImplCallParameterNames(MetaOperation op) //127:1
        {
            string result = "this"; //128:2
            string delim = ", "; //129:2
            var __loop15_results = 
                (from __loop15_var1 in __Enumerate((op).GetEnumerator()) //130:7
                from param in __Enumerate((__loop15_var1.Parameters).GetEnumerator()) //130:11
                select new { __loop15_var1 = __loop15_var1, param = param}
                ).ToList(); //130:2
            int __loop15_iteration = 0;
            foreach (var __tmp1 in __loop15_results)
            {
                ++__loop15_iteration;
                var __loop15_var1 = __tmp1.__loop15_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //131:3
            }
            return result; //133:2
        }

        public string GenerateOperation(MetaOperation op) //136:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = ");"; //137:87
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(op.ReturnType.JavaFullPublicName());
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                }
            }
            string __tmp4Line = " "; //137:37
            __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(op.Name.ToCamelCase());
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_first = true;
                while(__tmp5_first || !__tmp5Reader.EndOfStream)
                {
                    __tmp5_first = false;
                    string __tmp5Line = __tmp5Reader.ReadLine();
                    if (__tmp5Line == null)
                    {
                        __tmp5Line = "";
                    }
                    __out.Append(__tmp5Line);
                }
            }
            string __tmp6Line = "("; //137:61
            __out.Append(__tmp6Line);
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(GetParameters(op, true));
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_first = true;
                while(__tmp7_first || !__tmp7Reader.EndOfStream)
                {
                    __tmp7_first = false;
                    string __tmp7Line = __tmp7Reader.ReadLine();
                    if (__tmp7Line == null)
                    {
                        __tmp7Line = "";
                    }
                    __out.Append(__tmp7Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //137:89
                }
            }
            return __out.ToString();
        }

        public string GenerateInterfaceImpl(MetaModel model, MetaClass cls) //140:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "package "; //141:1
            string __tmp2Suffix = ";"; //141:35
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.Namespace.JavaName());
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //141:36
                }
            }
            __out.AppendLine(); //142:1
            string __tmp4Prefix = "class "; //143:1
            string __tmp5Suffix = " {"; //143:93
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(cls.JavaImplName());
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                while(__tmp6_first || !__tmp6Reader.EndOfStream)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    if (__tmp6Line == null)
                    {
                        __tmp6Line = "";
                    }
                    __out.Append(__tmp4Prefix);
                    __out.Append(__tmp6Line);
                }
            }
            string __tmp7Line = " extends metadslx.core.ModelObject implements "; //143:27
            __out.Append(__tmp7Line);
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(cls.JavaFullName());
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_first = true;
                while(__tmp8_first || !__tmp8Reader.EndOfStream)
                {
                    __tmp8_first = false;
                    string __tmp8Line = __tmp8Reader.ReadLine();
                    if (__tmp8Line == null)
                    {
                        __tmp8Line = "";
                    }
                    __out.Append(__tmp8Line);
                    __out.Append(__tmp5Suffix);
                    __out.AppendLine(); //143:95
                }
            }
            __out.Append("    static {"); //144:1
            __out.AppendLine(); //144:13
            string __tmp9Prefix = "        "; //145:1
            string __tmp10Suffix = ".staticInit();"; //145:45
            StringBuilder __tmp11 = new StringBuilder();
            __tmp11.Append(cls.Model.JavaFullDescriptorName());
            using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
            {
                bool __tmp11_first = true;
                while(__tmp11_first || !__tmp11Reader.EndOfStream)
                {
                    __tmp11_first = false;
                    string __tmp11Line = __tmp11Reader.ReadLine();
                    if (__tmp11Line == null)
                    {
                        __tmp11Line = "";
                    }
                    __out.Append(__tmp9Prefix);
                    __out.Append(__tmp11Line);
                    __out.Append(__tmp10Suffix);
                    __out.AppendLine(); //145:59
                }
            }
            __out.Append("    }"); //146:1
            __out.AppendLine(); //146:6
            __out.AppendLine(); //147:1
            __out.Append("	@Override"); //148:1
            __out.AppendLine(); //148:11
            __out.Append("    public metadslx.core.MetaModel mMetaModel() {"); //149:1
            __out.AppendLine(); //149:50
            string __tmp12Prefix = "        return "; //150:1
            string __tmp13Suffix = "; "; //150:50
            StringBuilder __tmp14 = new StringBuilder();
            __tmp14.Append(cls.Model.JavaFullInstanceName());
            using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
            {
                bool __tmp14_first = true;
                while(__tmp14_first || !__tmp14Reader.EndOfStream)
                {
                    __tmp14_first = false;
                    string __tmp14Line = __tmp14Reader.ReadLine();
                    if (__tmp14Line == null)
                    {
                        __tmp14Line = "";
                    }
                    __out.Append(__tmp12Prefix);
                    __out.Append(__tmp14Line);
                    __out.Append(__tmp13Suffix);
                    __out.AppendLine(); //150:52
                }
            }
            __out.Append("    }"); //151:1
            __out.AppendLine(); //151:6
            __out.AppendLine(); //152:1
            __out.Append("	@Override"); //153:1
            __out.AppendLine(); //153:11
            __out.Append("    public metadslx.core.MetaClass mMetaClass() {"); //154:1
            __out.AppendLine(); //154:50
            string __tmp15Prefix = "        return "; //155:1
            string __tmp16Suffix = "; "; //155:44
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(cls.JavaFullInstanceName());
            using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
            {
                bool __tmp17_first = true;
                while(__tmp17_first || !__tmp17Reader.EndOfStream)
                {
                    __tmp17_first = false;
                    string __tmp17Line = __tmp17Reader.ReadLine();
                    if (__tmp17Line == null)
                    {
                        __tmp17Line = "";
                    }
                    __out.Append(__tmp15Prefix);
                    __out.Append(__tmp17Line);
                    __out.Append(__tmp16Suffix);
                    __out.AppendLine(); //155:46
                }
            }
            __out.Append("    }"); //156:1
            __out.AppendLine(); //156:6
            __out.AppendLine(); //157:1
            string __tmp18Prefix = "    "; //158:1
            string __tmp19Suffix = string.Empty; 
            StringBuilder __tmp20 = new StringBuilder();
            __tmp20.Append(GenerateConstructorImpl(model, cls));
            using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
            {
                bool __tmp20_first = true;
                while(__tmp20_first || !__tmp20Reader.EndOfStream)
                {
                    __tmp20_first = false;
                    string __tmp20Line = __tmp20Reader.ReadLine();
                    if (__tmp20Line == null)
                    {
                        __tmp20Line = "";
                    }
                    __out.Append(__tmp18Prefix);
                    __out.Append(__tmp20Line);
                    __out.Append(__tmp19Suffix);
                    __out.AppendLine(); //158:42
                }
            }
            HashSet<string> propMethodNames = new HashSet<string>(); //159:3
            var __loop16_results = 
                (from __loop16_var1 in __Enumerate((cls).GetEnumerator()) //160:11
                from prop in __Enumerate((__loop16_var1.GetAllProperties()).GetEnumerator()) //160:16
                select new { __loop16_var1 = __loop16_var1, prop = prop}
                ).ToList(); //160:6
            int __loop16_iteration = 0;
            foreach (var __tmp21 in __loop16_results)
            {
                ++__loop16_iteration;
                var __loop16_var1 = __tmp21.__loop16_var1;
                var prop = __tmp21.prop;
                string __tmp22Prefix = "    "; //161:1
                string __tmp23Suffix = string.Empty; 
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(GeneratePropertyImpl(model, cls, prop, propMethodNames));
                using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
                {
                    bool __tmp24_first = true;
                    while(__tmp24_first || !__tmp24Reader.EndOfStream)
                    {
                        __tmp24_first = false;
                        string __tmp24Line = __tmp24Reader.ReadLine();
                        if (__tmp24Line == null)
                        {
                            __tmp24Line = "";
                        }
                        __out.Append(__tmp22Prefix);
                        __out.Append(__tmp24Line);
                        __out.Append(__tmp23Suffix);
                        __out.AppendLine(); //161:62
                    }
                }
            }
            HashSet<string> methodNames = new HashSet<string>(); //163:3
            var __loop17_results = 
                (from __loop17_var1 in __Enumerate((cls).GetEnumerator()) //164:11
                from op in __Enumerate((__loop17_var1.GetAllOperations()).GetEnumerator()) //164:16
                select new { __loop17_var1 = __loop17_var1, op = op}
                ).ToList(); //164:6
            int __loop17_iteration = 0;
            foreach (var __tmp25 in __loop17_results)
            {
                ++__loop17_iteration;
                var __loop17_var1 = __tmp25.__loop17_var1;
                var op = __tmp25.op;
                string __tmp26Prefix = "    "; //165:1
                string __tmp27Suffix = string.Empty; 
                StringBuilder __tmp28 = new StringBuilder();
                __tmp28.Append(GenerateOperationImpl(model, op, methodNames));
                using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
                {
                    bool __tmp28_first = true;
                    while(__tmp28_first || !__tmp28Reader.EndOfStream)
                    {
                        __tmp28_first = false;
                        string __tmp28Line = __tmp28Reader.ReadLine();
                        if (__tmp28Line == null)
                        {
                            __tmp28Line = "";
                        }
                        __out.Append(__tmp26Prefix);
                        __out.Append(__tmp28Line);
                        __out.Append(__tmp27Suffix);
                        __out.AppendLine(); //165:52
                    }
                }
            }
            __out.Append("}"); //167:1
            __out.AppendLine(); //167:2
            __out.AppendLine(); //168:1
            return __out.ToString();
        }

        public string GeneratePropertyDeclaration(MetaModel model, MetaClass cls, MetaProperty prop) //171:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class == cls) //172:2
            {
                string __tmp1Prefix = string.Empty;
                string __tmp2Suffix = string.Empty;
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(GenerateAnnotations(prop));
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_first = true;
                    while(__tmp3_first || !__tmp3Reader.EndOfStream)
                    {
                        __tmp3_first = false;
                        string __tmp3Line = __tmp3Reader.ReadLine();
                        if (__tmp3Line == null)
                        {
                            __tmp3Line = "";
                        }
                        __out.Append(__tmp1Prefix);
                        __out.Append(__tmp3Line);
                        __out.Append(__tmp2Suffix);
                        __out.AppendLine(); //173:28
                    }
                }
                if (prop.Kind == MetaPropertyKind.Containment) //174:2
                {
                    __out.Append("@metadslx.core.Containment"); //175:1
                    __out.AppendLine(); //175:27
                }
                if (prop.Kind != MetaPropertyKind.Normal && prop.Kind != MetaPropertyKind.Containment) //177:2
                {
                    __out.Append("@metadslx.core.Readonly"); //178:1
                    __out.AppendLine(); //178:24
                }
                var __loop18_results = 
                    (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //180:7
                    select new { p = p}
                    ).ToList(); //180:2
                int __loop18_iteration = 0;
                foreach (var __tmp4 in __loop18_results)
                {
                    ++__loop18_iteration;
                    var p = __tmp4.p;
                    string __tmp5Prefix = "@metadslx.core.Opposite(declaringType="; //181:1
                    string __tmp6Suffix = "\")"; //181:103
                    StringBuilder __tmp7 = new StringBuilder();
                    __tmp7.Append(p.Class.JavaFullDescriptorName());
                    using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
                    {
                        bool __tmp7_first = true;
                        while(__tmp7_first || !__tmp7Reader.EndOfStream)
                        {
                            __tmp7_first = false;
                            string __tmp7Line = __tmp7Reader.ReadLine();
                            if (__tmp7Line == null)
                            {
                                __tmp7Line = "";
                            }
                            __out.Append(__tmp5Prefix);
                            __out.Append(__tmp7Line);
                        }
                    }
                    string __tmp8Line = ".class, propertyName=\""; //181:73
                    __out.Append(__tmp8Line);
                    StringBuilder __tmp9 = new StringBuilder();
                    __tmp9.Append(p.Name);
                    using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                    {
                        bool __tmp9_first = true;
                        while(__tmp9_first || !__tmp9Reader.EndOfStream)
                        {
                            __tmp9_first = false;
                            string __tmp9Line = __tmp9Reader.ReadLine();
                            if (__tmp9Line == null)
                            {
                                __tmp9Line = "";
                            }
                            __out.Append(__tmp9Line);
                            __out.Append(__tmp6Suffix);
                            __out.AppendLine(); //181:105
                        }
                    }
                }
                var __loop19_results = 
                    (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //183:7
                    select new { p = p}
                    ).ToList(); //183:2
                int __loop19_iteration = 0;
                foreach (var __tmp10 in __loop19_results)
                {
                    ++__loop19_iteration;
                    var p = __tmp10.p;
                    if (cls.GetAllSuperClasses(false).Contains(p.Class)) //184:3
                    {
                        string __tmp11Prefix = "@metadslx.core.Subsets(declaringType="; //185:1
                        string __tmp12Suffix = "\")"; //185:102
                        StringBuilder __tmp13 = new StringBuilder();
                        __tmp13.Append(p.Class.JavaFullDescriptorName());
                        using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                        {
                            bool __tmp13_first = true;
                            while(__tmp13_first || !__tmp13Reader.EndOfStream)
                            {
                                __tmp13_first = false;
                                string __tmp13Line = __tmp13Reader.ReadLine();
                                if (__tmp13Line == null)
                                {
                                    __tmp13Line = "";
                                }
                                __out.Append(__tmp11Prefix);
                                __out.Append(__tmp13Line);
                            }
                        }
                        string __tmp14Line = ".class, propertyName=\""; //185:72
                        __out.Append(__tmp14Line);
                        StringBuilder __tmp15 = new StringBuilder();
                        __tmp15.Append(p.Name);
                        using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
                        {
                            bool __tmp15_first = true;
                            while(__tmp15_first || !__tmp15Reader.EndOfStream)
                            {
                                __tmp15_first = false;
                                string __tmp15Line = __tmp15Reader.ReadLine();
                                if (__tmp15Line == null)
                                {
                                    __tmp15Line = "";
                                }
                                __out.Append(__tmp15Line);
                                __out.Append(__tmp12Suffix);
                                __out.AppendLine(); //185:104
                            }
                        }
                    }
                    else //186:3
                    {
                        string __tmp16Prefix = "// ERROR: subsetted property '"; //187:1
                        string __tmp17Suffix = "' must be a property of an ancestor class"; //187:59
                        StringBuilder __tmp18 = new StringBuilder();
                        __tmp18.Append(p.JavaFullDescriptorName());
                        using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
                        {
                            bool __tmp18_first = true;
                            while(__tmp18_first || !__tmp18Reader.EndOfStream)
                            {
                                __tmp18_first = false;
                                string __tmp18Line = __tmp18Reader.ReadLine();
                                if (__tmp18Line == null)
                                {
                                    __tmp18Line = "";
                                }
                                __out.Append(__tmp16Prefix);
                                __out.Append(__tmp18Line);
                                __out.Append(__tmp17Suffix);
                                __out.AppendLine(); //187:100
                            }
                        }
                    }
                }
                var __loop20_results = 
                    (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //190:7
                    select new { p = p}
                    ).ToList(); //190:2
                int __loop20_iteration = 0;
                foreach (var __tmp19 in __loop20_results)
                {
                    ++__loop20_iteration;
                    var p = __tmp19.p;
                    if (cls.GetAllSuperClasses(false).Contains(p.Class)) //191:3
                    {
                        string __tmp20Prefix = "@metadslx.core.Redefines(declaringType="; //192:1
                        string __tmp21Suffix = "\")"; //192:104
                        StringBuilder __tmp22 = new StringBuilder();
                        __tmp22.Append(p.Class.JavaFullDescriptorName());
                        using(StreamReader __tmp22Reader = new StreamReader(this.__ToStream(__tmp22.ToString())))
                        {
                            bool __tmp22_first = true;
                            while(__tmp22_first || !__tmp22Reader.EndOfStream)
                            {
                                __tmp22_first = false;
                                string __tmp22Line = __tmp22Reader.ReadLine();
                                if (__tmp22Line == null)
                                {
                                    __tmp22Line = "";
                                }
                                __out.Append(__tmp20Prefix);
                                __out.Append(__tmp22Line);
                            }
                        }
                        string __tmp23Line = ".class, propertyName=\""; //192:74
                        __out.Append(__tmp23Line);
                        StringBuilder __tmp24 = new StringBuilder();
                        __tmp24.Append(p.Name);
                        using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
                        {
                            bool __tmp24_first = true;
                            while(__tmp24_first || !__tmp24Reader.EndOfStream)
                            {
                                __tmp24_first = false;
                                string __tmp24Line = __tmp24Reader.ReadLine();
                                if (__tmp24Line == null)
                                {
                                    __tmp24Line = "";
                                }
                                __out.Append(__tmp24Line);
                                __out.Append(__tmp21Suffix);
                                __out.AppendLine(); //192:106
                            }
                        }
                    }
                    else //193:3
                    {
                        string __tmp25Prefix = "// ERROR: redefined property '"; //194:1
                        string __tmp26Suffix = "' must be a property of an ancestor class"; //194:59
                        StringBuilder __tmp27 = new StringBuilder();
                        __tmp27.Append(p.JavaFullDescriptorName());
                        using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
                        {
                            bool __tmp27_first = true;
                            while(__tmp27_first || !__tmp27Reader.EndOfStream)
                            {
                                __tmp27_first = false;
                                string __tmp27Line = __tmp27Reader.ReadLine();
                                if (__tmp27Line == null)
                                {
                                    __tmp27Line = "";
                                }
                                __out.Append(__tmp25Prefix);
                                __out.Append(__tmp27Line);
                                __out.Append(__tmp26Suffix);
                                __out.AppendLine(); //194:100
                            }
                        }
                    }
                }
                if (prop.Type is MetaCollectionType) //197:2
                {
                    string __tmp28Prefix = "public static final ModelProperty "; //198:1
                    string __tmp29Suffix = "Property ="; //198:46
                    StringBuilder __tmp30 = new StringBuilder();
                    __tmp30.Append(prop.Name);
                    using(StreamReader __tmp30Reader = new StreamReader(this.__ToStream(__tmp30.ToString())))
                    {
                        bool __tmp30_first = true;
                        while(__tmp30_first || !__tmp30Reader.EndOfStream)
                        {
                            __tmp30_first = false;
                            string __tmp30Line = __tmp30Reader.ReadLine();
                            if (__tmp30Line == null)
                            {
                                __tmp30Line = "";
                            }
                            __out.Append(__tmp28Prefix);
                            __out.Append(__tmp30Line);
                            __out.Append(__tmp29Suffix);
                            __out.AppendLine(); //198:56
                        }
                    }
                    string __tmp31Prefix = "    metadslx.core.ModelProperty.register(\""; //199:1
                    string __tmp32Suffix = "Property, true));"; //199:396
                    StringBuilder __tmp33 = new StringBuilder();
                    __tmp33.Append(prop.Name);
                    using(StreamReader __tmp33Reader = new StreamReader(this.__ToStream(__tmp33.ToString())))
                    {
                        bool __tmp33_first = true;
                        while(__tmp33_first || !__tmp33Reader.EndOfStream)
                        {
                            __tmp33_first = false;
                            string __tmp33Line = __tmp33Reader.ReadLine();
                            if (__tmp33Line == null)
                            {
                                __tmp33Line = "";
                            }
                            __out.Append(__tmp31Prefix);
                            __out.Append(__tmp33Line);
                        }
                    }
                    string __tmp34Line = "\", "; //199:54
                    __out.Append(__tmp34Line);
                    StringBuilder __tmp35 = new StringBuilder();
                    __tmp35.Append(prop.Type.JavaNonGenericFullName());
                    using(StreamReader __tmp35Reader = new StreamReader(this.__ToStream(__tmp35.ToString())))
                    {
                        bool __tmp35_first = true;
                        while(__tmp35_first || !__tmp35Reader.EndOfStream)
                        {
                            __tmp35_first = false;
                            string __tmp35Line = __tmp35Reader.ReadLine();
                            if (__tmp35Line == null)
                            {
                                __tmp35Line = "";
                            }
                            __out.Append(__tmp35Line);
                        }
                    }
                    string __tmp36Line = ".class, "; //199:93
                    __out.Append(__tmp36Line);
                    StringBuilder __tmp37 = new StringBuilder();
                    __tmp37.Append(((MetaCollectionType)prop.Type).InnerType.JavaNonGenericFullName());
                    using(StreamReader __tmp37Reader = new StreamReader(this.__ToStream(__tmp37.ToString())))
                    {
                        bool __tmp37_first = true;
                        while(__tmp37_first || !__tmp37Reader.EndOfStream)
                        {
                            __tmp37_first = false;
                            string __tmp37Line = __tmp37Reader.ReadLine();
                            if (__tmp37Line == null)
                            {
                                __tmp37Line = "";
                            }
                            __out.Append(__tmp37Line);
                        }
                    }
                    string __tmp38Line = ".class, "; //199:169
                    __out.Append(__tmp38Line);
                    StringBuilder __tmp39 = new StringBuilder();
                    __tmp39.Append(prop.Class.JavaFullName());
                    using(StreamReader __tmp39Reader = new StreamReader(this.__ToStream(__tmp39.ToString())))
                    {
                        bool __tmp39_first = true;
                        while(__tmp39_first || !__tmp39Reader.EndOfStream)
                        {
                            __tmp39_first = false;
                            string __tmp39Line = __tmp39Reader.ReadLine();
                            if (__tmp39Line == null)
                            {
                                __tmp39Line = "";
                            }
                            __out.Append(__tmp39Line);
                        }
                    }
                    string __tmp40Line = ".class, "; //199:204
                    __out.Append(__tmp40Line);
                    StringBuilder __tmp41 = new StringBuilder();
                    __tmp41.Append(prop.Class.Model.JavaFullName());
                    using(StreamReader __tmp41Reader = new StreamReader(this.__ToStream(__tmp41.ToString())))
                    {
                        bool __tmp41_first = true;
                        while(__tmp41_first || !__tmp41Reader.EndOfStream)
                        {
                            __tmp41_first = false;
                            string __tmp41Line = __tmp41Reader.ReadLine();
                            if (__tmp41Line == null)
                            {
                                __tmp41Line = "";
                            }
                            __out.Append(__tmp41Line);
                        }
                    }
                    string __tmp42Line = "Descriptor."; //199:245
                    __out.Append(__tmp42Line);
                    StringBuilder __tmp43 = new StringBuilder();
                    __tmp43.Append(prop.Class.JavaName());
                    using(StreamReader __tmp43Reader = new StreamReader(this.__ToStream(__tmp43.ToString())))
                    {
                        bool __tmp43_first = true;
                        while(__tmp43_first || !__tmp43Reader.EndOfStream)
                        {
                            __tmp43_first = false;
                            string __tmp43Line = __tmp43Reader.ReadLine();
                            if (__tmp43Line == null)
                            {
                                __tmp43Line = "";
                            }
                            __out.Append(__tmp43Line);
                        }
                    }
                    string __tmp44Line = ".class, metadslx.core.Lazy.create(() -> "; //199:279
                    __out.Append(__tmp44Line);
                    StringBuilder __tmp45 = new StringBuilder();
                    __tmp45.Append(prop.Class.Model.JavaFullName());
                    using(StreamReader __tmp45Reader = new StreamReader(this.__ToStream(__tmp45.ToString())))
                    {
                        bool __tmp45_first = true;
                        while(__tmp45_first || !__tmp45Reader.EndOfStream)
                        {
                            __tmp45_first = false;
                            string __tmp45Line = __tmp45Reader.ReadLine();
                            if (__tmp45Line == null)
                            {
                                __tmp45Line = "";
                            }
                            __out.Append(__tmp45Line);
                        }
                    }
                    string __tmp46Line = "Instance."; //199:352
                    __out.Append(__tmp46Line);
                    StringBuilder __tmp47 = new StringBuilder();
                    __tmp47.Append(prop.Class.JavaName());
                    using(StreamReader __tmp47Reader = new StreamReader(this.__ToStream(__tmp47.ToString())))
                    {
                        bool __tmp47_first = true;
                        while(__tmp47_first || !__tmp47Reader.EndOfStream)
                        {
                            __tmp47_first = false;
                            string __tmp47Line = __tmp47Reader.ReadLine();
                            if (__tmp47Line == null)
                            {
                                __tmp47Line = "";
                            }
                            __out.Append(__tmp47Line);
                        }
                    }
                    string __tmp48Line = "_"; //199:384
                    __out.Append(__tmp48Line);
                    StringBuilder __tmp49 = new StringBuilder();
                    __tmp49.Append(prop.Name);
                    using(StreamReader __tmp49Reader = new StreamReader(this.__ToStream(__tmp49.ToString())))
                    {
                        bool __tmp49_first = true;
                        while(__tmp49_first || !__tmp49Reader.EndOfStream)
                        {
                            __tmp49_first = false;
                            string __tmp49Line = __tmp49Reader.ReadLine();
                            if (__tmp49Line == null)
                            {
                                __tmp49Line = "";
                            }
                            __out.Append(__tmp49Line);
                            __out.Append(__tmp32Suffix);
                            __out.AppendLine(); //199:413
                        }
                    }
                }
                else //200:2
                {
                    string __tmp50Prefix = "public static final ModelProperty "; //201:1
                    string __tmp51Suffix = "Property ="; //201:46
                    StringBuilder __tmp52 = new StringBuilder();
                    __tmp52.Append(prop.Name);
                    using(StreamReader __tmp52Reader = new StreamReader(this.__ToStream(__tmp52.ToString())))
                    {
                        bool __tmp52_first = true;
                        while(__tmp52_first || !__tmp52Reader.EndOfStream)
                        {
                            __tmp52_first = false;
                            string __tmp52Line = __tmp52Reader.ReadLine();
                            if (__tmp52Line == null)
                            {
                                __tmp52Line = "";
                            }
                            __out.Append(__tmp50Prefix);
                            __out.Append(__tmp52Line);
                            __out.Append(__tmp51Suffix);
                            __out.AppendLine(); //201:56
                        }
                    }
                    string __tmp53Prefix = "    metadslx.core.ModelProperty.register(\""; //202:1
                    string __tmp54Suffix = "Property, true));"; //202:322
                    StringBuilder __tmp55 = new StringBuilder();
                    __tmp55.Append(prop.Name);
                    using(StreamReader __tmp55Reader = new StreamReader(this.__ToStream(__tmp55.ToString())))
                    {
                        bool __tmp55_first = true;
                        while(__tmp55_first || !__tmp55Reader.EndOfStream)
                        {
                            __tmp55_first = false;
                            string __tmp55Line = __tmp55Reader.ReadLine();
                            if (__tmp55Line == null)
                            {
                                __tmp55Line = "";
                            }
                            __out.Append(__tmp53Prefix);
                            __out.Append(__tmp55Line);
                        }
                    }
                    string __tmp56Line = "\", "; //202:54
                    __out.Append(__tmp56Line);
                    StringBuilder __tmp57 = new StringBuilder();
                    __tmp57.Append(prop.Type.JavaFullPublicName());
                    using(StreamReader __tmp57Reader = new StreamReader(this.__ToStream(__tmp57.ToString())))
                    {
                        bool __tmp57_first = true;
                        while(__tmp57_first || !__tmp57Reader.EndOfStream)
                        {
                            __tmp57_first = false;
                            string __tmp57Line = __tmp57Reader.ReadLine();
                            if (__tmp57Line == null)
                            {
                                __tmp57Line = "";
                            }
                            __out.Append(__tmp57Line);
                        }
                    }
                    string __tmp58Line = ".class, null, "; //202:89
                    __out.Append(__tmp58Line);
                    StringBuilder __tmp59 = new StringBuilder();
                    __tmp59.Append(prop.Class.JavaFullName());
                    using(StreamReader __tmp59Reader = new StreamReader(this.__ToStream(__tmp59.ToString())))
                    {
                        bool __tmp59_first = true;
                        while(__tmp59_first || !__tmp59Reader.EndOfStream)
                        {
                            __tmp59_first = false;
                            string __tmp59Line = __tmp59Reader.ReadLine();
                            if (__tmp59Line == null)
                            {
                                __tmp59Line = "";
                            }
                            __out.Append(__tmp59Line);
                        }
                    }
                    string __tmp60Line = ".class, "; //202:130
                    __out.Append(__tmp60Line);
                    StringBuilder __tmp61 = new StringBuilder();
                    __tmp61.Append(prop.Class.Model.JavaFullName());
                    using(StreamReader __tmp61Reader = new StreamReader(this.__ToStream(__tmp61.ToString())))
                    {
                        bool __tmp61_first = true;
                        while(__tmp61_first || !__tmp61Reader.EndOfStream)
                        {
                            __tmp61_first = false;
                            string __tmp61Line = __tmp61Reader.ReadLine();
                            if (__tmp61Line == null)
                            {
                                __tmp61Line = "";
                            }
                            __out.Append(__tmp61Line);
                        }
                    }
                    string __tmp62Line = "Descriptor."; //202:171
                    __out.Append(__tmp62Line);
                    StringBuilder __tmp63 = new StringBuilder();
                    __tmp63.Append(prop.Class.JavaName());
                    using(StreamReader __tmp63Reader = new StreamReader(this.__ToStream(__tmp63.ToString())))
                    {
                        bool __tmp63_first = true;
                        while(__tmp63_first || !__tmp63Reader.EndOfStream)
                        {
                            __tmp63_first = false;
                            string __tmp63Line = __tmp63Reader.ReadLine();
                            if (__tmp63Line == null)
                            {
                                __tmp63Line = "";
                            }
                            __out.Append(__tmp63Line);
                        }
                    }
                    string __tmp64Line = ".class, metadslx.core.Lazy.create(() -> "; //202:205
                    __out.Append(__tmp64Line);
                    StringBuilder __tmp65 = new StringBuilder();
                    __tmp65.Append(prop.Class.Model.JavaFullName());
                    using(StreamReader __tmp65Reader = new StreamReader(this.__ToStream(__tmp65.ToString())))
                    {
                        bool __tmp65_first = true;
                        while(__tmp65_first || !__tmp65Reader.EndOfStream)
                        {
                            __tmp65_first = false;
                            string __tmp65Line = __tmp65Reader.ReadLine();
                            if (__tmp65Line == null)
                            {
                                __tmp65Line = "";
                            }
                            __out.Append(__tmp65Line);
                        }
                    }
                    string __tmp66Line = "Instance."; //202:278
                    __out.Append(__tmp66Line);
                    StringBuilder __tmp67 = new StringBuilder();
                    __tmp67.Append(prop.Class.JavaName());
                    using(StreamReader __tmp67Reader = new StreamReader(this.__ToStream(__tmp67.ToString())))
                    {
                        bool __tmp67_first = true;
                        while(__tmp67_first || !__tmp67Reader.EndOfStream)
                        {
                            __tmp67_first = false;
                            string __tmp67Line = __tmp67Reader.ReadLine();
                            if (__tmp67Line == null)
                            {
                                __tmp67Line = "";
                            }
                            __out.Append(__tmp67Line);
                        }
                    }
                    string __tmp68Line = "_"; //202:310
                    __out.Append(__tmp68Line);
                    StringBuilder __tmp69 = new StringBuilder();
                    __tmp69.Append(prop.Name);
                    using(StreamReader __tmp69Reader = new StreamReader(this.__ToStream(__tmp69.ToString())))
                    {
                        bool __tmp69_first = true;
                        while(__tmp69_first || !__tmp69Reader.EndOfStream)
                        {
                            __tmp69_first = false;
                            string __tmp69Line = __tmp69Reader.ReadLine();
                            if (__tmp69Line == null)
                            {
                                __tmp69Line = "";
                            }
                            __out.Append(__tmp69Line);
                            __out.Append(__tmp54Suffix);
                            __out.AppendLine(); //202:339
                        }
                    }
                }
            }
            __out.AppendLine(); //205:1
            return __out.ToString();
        }

        public string GeneratePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop, HashSet<string> generated) //208:1
        {
            StringBuilder __out = new StringBuilder();
            if (generated.Add("get" + prop.Name)) //209:2
            {
                __out.AppendLine(); //210:1
                string __tmp1Prefix = "public "; //211:1
                string __tmp2Suffix = "() {"; //211:75
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(prop.Type.JavaFullPublicName());
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_first = true;
                    while(__tmp3_first || !__tmp3Reader.EndOfStream)
                    {
                        __tmp3_first = false;
                        string __tmp3Line = __tmp3Reader.ReadLine();
                        if (__tmp3Line == null)
                        {
                            __tmp3Line = "";
                        }
                        __out.Append(__tmp1Prefix);
                        __out.Append(__tmp3Line);
                    }
                }
                string __tmp4Line = " "; //211:40
                __out.Append(__tmp4Line);
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(("get" + prop.Name).SafeJavaName());
                using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                {
                    bool __tmp5_first = true;
                    while(__tmp5_first || !__tmp5Reader.EndOfStream)
                    {
                        __tmp5_first = false;
                        string __tmp5Line = __tmp5Reader.ReadLine();
                        if (__tmp5Line == null)
                        {
                            __tmp5Line = "";
                        }
                        __out.Append(__tmp5Line);
                        __out.Append(__tmp2Suffix);
                        __out.AppendLine(); //211:79
                    }
                }
                string __tmp6Prefix = "    Object result = this.mGet("; //212:1
                string __tmp7Suffix = "); "; //212:62
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(prop.JavaFullDescriptorName());
                using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                {
                    bool __tmp8_first = true;
                    while(__tmp8_first || !__tmp8Reader.EndOfStream)
                    {
                        __tmp8_first = false;
                        string __tmp8Line = __tmp8Reader.ReadLine();
                        if (__tmp8Line == null)
                        {
                            __tmp8Line = "";
                        }
                        __out.Append(__tmp6Prefix);
                        __out.Append(__tmp8Line);
                        __out.Append(__tmp7Suffix);
                        __out.AppendLine(); //212:65
                    }
                }
                string __tmp9Prefix = "    if (result != null) return ("; //213:1
                string __tmp10Suffix = ")result;"; //213:65
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(prop.Type.JavaFullPublicName());
                using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                {
                    bool __tmp11_first = true;
                    while(__tmp11_first || !__tmp11Reader.EndOfStream)
                    {
                        __tmp11_first = false;
                        string __tmp11Line = __tmp11Reader.ReadLine();
                        if (__tmp11Line == null)
                        {
                            __tmp11Line = "";
                        }
                        __out.Append(__tmp9Prefix);
                        __out.Append(__tmp11Line);
                        __out.Append(__tmp10Suffix);
                        __out.AppendLine(); //213:73
                    }
                }
                string __tmp12Prefix = "    else return ("; //214:1
                string __tmp13Suffix = ";"; //214:81
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(prop.Type.JavaFullPublicName());
                using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
                {
                    bool __tmp14_first = true;
                    while(__tmp14_first || !__tmp14Reader.EndOfStream)
                    {
                        __tmp14_first = false;
                        string __tmp14Line = __tmp14Reader.ReadLine();
                        if (__tmp14Line == null)
                        {
                            __tmp14Line = "";
                        }
                        __out.Append(__tmp12Prefix);
                        __out.Append(__tmp14Line);
                    }
                }
                string __tmp15Line = ")"; //214:50
                __out.Append(__tmp15Line);
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(prop.Type.JavaDefaultValue());
                using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
                {
                    bool __tmp16_first = true;
                    while(__tmp16_first || !__tmp16Reader.EndOfStream)
                    {
                        __tmp16_first = false;
                        string __tmp16Line = __tmp16Reader.ReadLine();
                        if (__tmp16Line == null)
                        {
                            __tmp16Line = "";
                        }
                        __out.Append(__tmp16Line);
                        __out.Append(__tmp13Suffix);
                        __out.AppendLine(); //214:82
                    }
                }
                __out.Append("}"); //215:1
                __out.AppendLine(); //215:2
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //217:2
            {
                if (generated.Add("set" + prop.Name)) //218:2
                {
                    __out.AppendLine(); //219:1
                    string __tmp17Prefix = "public void "; //220:1
                    string __tmp18Suffix = " value) {"; //220:80
                    StringBuilder __tmp19 = new StringBuilder();
                    __tmp19.Append(("set" + prop.Name).SafeJavaName());
                    using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
                    {
                        bool __tmp19_first = true;
                        while(__tmp19_first || !__tmp19Reader.EndOfStream)
                        {
                            __tmp19_first = false;
                            string __tmp19Line = __tmp19Reader.ReadLine();
                            if (__tmp19Line == null)
                            {
                                __tmp19Line = "";
                            }
                            __out.Append(__tmp17Prefix);
                            __out.Append(__tmp19Line);
                        }
                    }
                    string __tmp20Line = "("; //220:47
                    __out.Append(__tmp20Line);
                    StringBuilder __tmp21 = new StringBuilder();
                    __tmp21.Append(prop.Type.JavaFullPublicName());
                    using(StreamReader __tmp21Reader = new StreamReader(this.__ToStream(__tmp21.ToString())))
                    {
                        bool __tmp21_first = true;
                        while(__tmp21_first || !__tmp21Reader.EndOfStream)
                        {
                            __tmp21_first = false;
                            string __tmp21Line = __tmp21Reader.ReadLine();
                            if (__tmp21Line == null)
                            {
                                __tmp21Line = "";
                            }
                            __out.Append(__tmp21Line);
                            __out.Append(__tmp18Suffix);
                            __out.AppendLine(); //220:89
                        }
                    }
                    string __tmp22Prefix = "    this.mSet("; //221:1
                    string __tmp23Suffix = ", value);"; //221:46
                    StringBuilder __tmp24 = new StringBuilder();
                    __tmp24.Append(prop.JavaFullDescriptorName());
                    using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
                    {
                        bool __tmp24_first = true;
                        while(__tmp24_first || !__tmp24Reader.EndOfStream)
                        {
                            __tmp24_first = false;
                            string __tmp24Line = __tmp24Reader.ReadLine();
                            if (__tmp24Line == null)
                            {
                                __tmp24Line = "";
                            }
                            __out.Append(__tmp22Prefix);
                            __out.Append(__tmp24Line);
                            __out.Append(__tmp23Suffix);
                            __out.AppendLine(); //221:55
                        }
                    }
                    __out.Append("}"); //222:1
                    __out.AppendLine(); //222:2
                }
            }
            return __out.ToString();
        }

        public string GetCollectionConstructorParams(MetaProperty prop) //227:1
        {
            MetaCollectionType mct = prop.Type as MetaCollectionType; //228:2
            if (mct != null && mct.InnerType is MetaClass) //229:2
            {
                return "this, " + prop.JavaFullDescriptorName(); //230:3
            }
            else //231:2
            {
                return ""; //232:3
            }
        }

        public string GenerateExpression(MetaExpression expr) //237:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //238:10
            if (expr is MetaBracketExpression) //239:2
            {
                __out.Append("("); //239:33
                __out.Append(GenerateExpression(((MetaBracketExpression)expr).Expression));
                __out.Append(")"); //239:71
            }
            else if (expr is MetaThisExpression) //240:2
            {
                __out.Append("(("); //240:30
                __out.Append(((MetaType)ModelCompilerContext.Current.ResolutionProvider.GetCurrentTypeScopeOf((ModelObject)((MetaThisExpression)expr))).JavaName());
                __out.Append(")this)"); //240:145
            }
            else if (expr is MetaNullExpression) //241:2
            {
                __out.Append("null"); //241:30
            }
            else if (expr is MetaTypeAsExpression) //242:2
            {
                __out.Append("metadslx.core.ModelUtils.as("); //242:32
                __out.Append(((MetaTypeAsExpression)expr).TypeReference.JavaName());
                __out.Append(".class,"); //242:91
                __out.Append(GenerateExpression(((MetaTypeAsExpression)expr).Expression));
                __out.Append(")"); //242:135
            }
            else if (expr is MetaTypeCastExpression) //243:2
            {
                __out.Append("("); //243:34
                __out.Append(((MetaTypeCastExpression)expr).TypeReference.JavaName());
                __out.Append(")"); //243:66
                __out.Append(GenerateExpression(((MetaTypeCastExpression)expr).Expression));
            }
            else if (expr is MetaTypeCheckExpression) //244:2
            {
                __out.Append(GenerateExpression(((MetaTypeCheckExpression)expr).Expression));
                __out.Append(" instanceof "); //244:72
                __out.Append(((MetaTypeCheckExpression)expr).TypeReference.JavaName());
            }
            else if (expr is MetaTypeOfExpression) //245:2
            {
                __out.Append(GenerateTypeOf(((MetaTypeOfExpression)expr)));
            }
            else if (expr is MetaConditionalExpression) //246:2
            {
                __out.Append(GenerateExpression(((MetaConditionalExpression)expr).Condition));
                __out.Append(" ? "); //246:73
                __out.Append(GenerateExpression(((MetaConditionalExpression)expr).Then));
                __out.Append(" : "); //246:107
                __out.Append(GenerateExpression(((MetaConditionalExpression)expr).Else));
            }
            else if (expr is MetaConstantExpression) //247:2
            {
                __out.Append(GetJavaValue(((MetaConstantExpression)expr).Value));
            }
            else if (expr is MetaIdentifierExpression) //248:2
            {
                __out.Append(GenerateIdentifierExpression(((MetaIdentifierExpression)expr)));
            }
            else if (expr is MetaMemberAccessExpression) //249:2
            {
                __out.Append(GenerateExpression(((MetaMemberAccessExpression)expr).Expression));
                __out.Append(".get"); //249:75
                __out.Append(((MetaMemberAccessExpression)expr).Name);
                __out.Append("()"); //249:90
            }
            else if (expr is MetaFunctionCallExpression) //250:2
            {
                __out.Append(GenerateFunctionCall(((MetaFunctionCallExpression)expr)));
            }
            else if (expr is MetaIndexerExpression) //251:2
            {
                __out.Append(GenerateIndexerCall(((MetaIndexerExpression)expr)));
            }
            else if (expr is MetaOperatorExpression) //252:2
            {
                __out.Append(GenerateOperator(((MetaOperatorExpression)expr)));
            }
            else if (expr is MetaNewExpression) //253:2
            {
                __out.Append(((MetaNewExpression)expr).TypeReference.JavaFullFactoryMethodName());
                __out.Append("("); //253:77
                __out.Append(GenerateNewPropertyInitializers(((MetaNewExpression)expr)));
                __out.Append(")"); //253:117
            }
            else if (expr is MetaNewCollectionExpression) //254:2
            {
                __out.Append("new java.util.ArrayList<metadslx.core.Lazy<Object>>() { "); //254:39
                __out.Append(GenerateNewCollectionValues(((MetaNewCollectionExpression)expr)));
                __out.Append(" }"); //254:130
            }
            else //255:2
            {
                __out.Append("***unknown expression type***"); //255:11
                __out.AppendLine(); //255:40
            }//256:2
            return __out.ToString();
        }

        public string GenerateIdentifierExpression(MetaIdentifierExpression expr) //259:1
        {
            StringBuilder __out = new StringBuilder();
            if (expr.Definition is MetaProperty) //260:2
            {
                string __tmp1Prefix = "(("; //261:1
                string __tmp2Suffix = "()"; //261:137
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(((MetaType)ModelCompilerContext.Current.ResolutionProvider.GetCurrentTypeScopeOf((ModelObject)expr)).JavaName());
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_first = true;
                    while(__tmp3_first || !__tmp3Reader.EndOfStream)
                    {
                        __tmp3_first = false;
                        string __tmp3Line = __tmp3Reader.ReadLine();
                        if (__tmp3Line == null)
                        {
                            __tmp3Line = "";
                        }
                        __out.Append(__tmp1Prefix);
                        __out.Append(__tmp3Line);
                    }
                }
                string __tmp4Line = ")this).get"; //261:116
                __out.Append(__tmp4Line);
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(expr.Name);
                using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                {
                    bool __tmp5_first = true;
                    while(__tmp5_first || !__tmp5Reader.EndOfStream)
                    {
                        __tmp5_first = false;
                        string __tmp5Line = __tmp5Reader.ReadLine();
                        if (__tmp5Line == null)
                        {
                            __tmp5Line = "";
                        }
                        __out.Append(__tmp5Line);
                        __out.Append(__tmp2Suffix);
                    }
                }
            }
            else //262:2
            {
                string __tmp6Prefix = string.Empty;
                string __tmp7Suffix = string.Empty;
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(expr.Name);
                using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                {
                    bool __tmp8_first = true;
                    while(__tmp8_first || !__tmp8Reader.EndOfStream)
                    {
                        __tmp8_first = false;
                        string __tmp8Line = __tmp8Reader.ReadLine();
                        if (__tmp8Line == null)
                        {
                            __tmp8Line = "";
                        }
                        __out.Append(__tmp6Prefix);
                        __out.Append(__tmp8Line);
                        __out.Append(__tmp7Suffix);
                    }
                }
            }
            return __out.ToString();
        }

        public bool SameFunction(MetaGlobalFunction mfunc1, MetaGlobalFunction mfunc2) //267:1
        {
            return mfunc1.Name == mfunc2.Name && ModelCompilerContext.Current.TypeProvider.Equals((ModelObject)mfunc1.Type, (ModelObject)mfunc2.Type); //268:2
        }

        public string GenerateFunctionCall(MetaFunctionCallExpression call) //271:1
        {
            StringBuilder __out = new StringBuilder();
            if (call.Definition is MetaGlobalFunction && SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.TypeOf)) //272:2
            {
                __out.Append(GenerateTypeOf(call.Arguments[0]));
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.GetValueType)) //273:2
            {
                __out.Append("ModelCompilerContext.current().getTypeProvider().getTypeOf("); //273:89
                __out.Append(GenerateCallArguments(call, ""));
                __out.Append(")"); //273:181
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.GetReturnType)) //274:2
            {
                __out.Append("ModelCompilerContext.current().getTypeProvider().getReturnTypeOf("); //274:90
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //274:201
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.CurrentType)) //275:2
            {
                __out.Append("ModelCompilerContext.current().getResolutionProvider().getCurrentTypeScopeOf("); //275:88
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //275:211
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.TypeCheck)) //276:2
            {
                __out.Append("ModelCompilerContext.current().getTypeProvider().typeCheck("); //276:86
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //276:191
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Balance)) //277:2
            {
                __out.Append("ModelCompilerContext.current().getTypeProvider().balance("); //277:84
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //277:187
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Resolve1)) //278:2
            {
                __out.Append("ModelCompilerContext.current().getResolutionProvider().resolve(java.util.Arrays.asList(new metadslx.core.ModelObject"); //278:85
                __out.Append("[]");
                __out.Append(" { ModelCompilerContext.current().getResolutionProvider().getCurrentScope(this) }), ResolveKind.NameOrType, "); //278:207
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //278:354
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Resolve2)) //279:2
            {
                __out.Append("ModelCompilerContext.current().getResolutionProvider().resolve(java.util.Arrays.asList(new metadslx.core.ModelObject"); //279:85
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //279:207
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }), ResolveKind.NameOrType, "); //279:262
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //279:330
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveType1)) //280:2
            {
                __out.Append("ModelCompilerContext.current().getResolutionProvider().resolve(java.util.Arrays.asList(new metadslx.core.ModelObject"); //280:89
                __out.Append("[]");
                __out.Append(" { ModelCompilerContext.current().getResolutionProvider().getCurrentScope(this) }), ResolveKind.Type, "); //280:211
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //280:352
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveType2)) //281:2
            {
                __out.Append("ModelCompilerContext.current().getResolutionProvider().resolve(java.util.Arrays.asList(new metadslx.core.ModelObject"); //281:89
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //281:211
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }), ResolveKind.Type, "); //281:266
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //281:328
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveName1)) //282:2
            {
                __out.Append("ModelCompilerContext.current().getResolutionProvider().resolve(java.util.Arrays.asList(new metadslx.core.ModelObject"); //282:89
                __out.Append("[]");
                __out.Append(" { ModelCompilerContext.current().getResolutionProvider().getCurrentScope(this) }), ResolveKind.Name, "); //282:211
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //282:352
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveName2)) //283:2
            {
                __out.Append("ModelCompilerContext.current().getResolutionProvider().resolve(java.util.Arrays.asList(new metadslx.core.ModelObject"); //283:89
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //283:211
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }), ResolveKind.Name, "); //283:266
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //283:328
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind1)) //284:2
            {
                __out.Append("ModelCompilerContext.current().getBindingProvider().bind(this, java.util.Arrays.asList(new metadslx.core.ModelObject"); //284:82
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //284:204
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }), new BindingInfo())"); //284:259
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind2)) //285:2
            {
                __out.Append("ModelCompilerContext.current().getBindingProvider().bind(this, "); //285:82
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new BindingInfo())"); //285:184
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind3)) //286:2
            {
                __out.Append("ModelCompilerContext.current().getBindingProvider().bind((ModelObject)"); //286:82
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", java.util.Arrays.asList(new metadslx.core.ModelObject"); //286:191
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //286:252
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(" }), new BindingInfo())"); //286:307
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind4)) //287:2
            {
                __out.Append("ModelCompilerContext.current().getBindingProvider().bind((ModelObject)"); //287:82
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", "); //287:191
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new BindingInfo())"); //287:232
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.SelectOfType1)) //288:2
            {
                __out.Append("java.util.Arrays.asList(new Object"); //288:90
                __out.Append("[]");
                __out.Append(" { "); //288:130
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }).stream().filter(e -> ModelCompilerContext.current().getTypeProvider().getTypeOf(e) instanceof "); //288:172
                __out.Append(GetTypeName(call.Arguments[1]));
                __out.Append(").collect(java.util.stream.Collectors.toList())"); //288:302
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.SelectOfType2)) //289:2
            {
                __out.Append("("); //289:90
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(").stream().filter(e -> ModelCompilerContext.current().getTypeProvider().getTypeOf(e) instanceof "); //289:130
                __out.Append(GetTypeName(call.Arguments[1]));
                __out.Append(").collect(java.util.stream.Collectors.toList())"); //289:258
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.SelectOfName1)) //290:2
            {
                __out.Append("java.util.Arrays.asList(new Object"); //290:90
                __out.Append("[]");
                __out.Append(" { "); //290:130
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }).stream().filter(e -> ModelCompilerContext.current().getNameProvider().getNameOf((ModelObject)e) == "); //290:172
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(").collect(java.util.stream.Collectors.toList())"); //290:314
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.SelectOfName2)) //291:2
            {
                __out.Append("("); //291:90
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(").stream().filter(e -> ModelCompilerContext.current().getNameProvider().getNameOf((ModelObject)e) == "); //291:130
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(").collect(java.util.stream.Collectors.toList())"); //291:270
            }
            else //292:2
            {
                __out.Append(GenerateExpression(call.Expression));
                __out.Append("("); //292:44
                __out.Append(GenerateCallArguments(call, ""));
                __out.Append(")"); //292:78
            }
            return __out.ToString();
        }

        public string GenerateIndexerCall(MetaIndexerExpression call) //296:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = string.Empty; 
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateExpression(call.Expression));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                }
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append("[");
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_first = true;
                while(__tmp4_first || !__tmp4Reader.EndOfStream)
                {
                    __tmp4_first = false;
                    string __tmp4Line = __tmp4Reader.ReadLine();
                    if (__tmp4Line == null)
                    {
                        __tmp4Line = "";
                    }
                    __out.Append(__tmp4Line);
                }
            }
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(GenerateCallArguments(call, ""));
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_first = true;
                while(__tmp5_first || !__tmp5Reader.EndOfStream)
                {
                    __tmp5_first = false;
                    string __tmp5Line = __tmp5Reader.ReadLine();
                    if (__tmp5Line == null)
                    {
                        __tmp5Line = "";
                    }
                    __out.Append(__tmp5Line);
                }
            }
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append("]");
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                while(__tmp6_first || !__tmp6Reader.EndOfStream)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    if (__tmp6Line == null)
                    {
                        __tmp6Line = "";
                    }
                    __out.Append(__tmp6Line);
                    __out.Append(__tmp2Suffix);
                }
            }
            return __out.ToString();
        }

        public string GenerateTypeOf(object expr) //300:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //301:9
            if (expr is MetaPrimitiveType) //302:2
            {
                var __tmp2 = ((MetaPrimitiveType)expr).Name; //303:10
                __out.Append("	"); //304:1
                if (__tmp2 == "*none*") //304:3
                {
                    __out.Append("MetaInstance.None"); //304:18
                    __out.Append("	"); //305:1
                }
                else if (__tmp2 == "*error*") //305:3
                {
                    __out.Append("MetaInstance.Error"); //305:19
                    __out.Append("	"); //306:1
                }
                else if (__tmp2 == "*any*") //306:3
                {
                    __out.Append("MetaInstance.Any"); //306:17
                    __out.Append("	"); //307:1
                }
                else if (__tmp2 == "object") //307:3
                {
                    __out.Append("MetaInstance.Object"); //307:18
                    __out.Append("	"); //308:1
                }
                else if (__tmp2 == "string") //308:3
                {
                    __out.Append("MetaInstance.String"); //308:18
                    __out.Append("	"); //309:1
                }
                else if (__tmp2 == "int") //309:3
                {
                    __out.Append("MetaInstance.Int"); //309:15
                    __out.Append("	"); //310:1
                }
                else if (__tmp2 == "long") //310:3
                {
                    __out.Append("MetaInstance.Long"); //310:16
                    __out.Append("	"); //311:1
                }
                else if (__tmp2 == "float") //311:3
                {
                    __out.Append("MetaInstance.Float"); //311:17
                    __out.Append("	"); //312:1
                }
                else if (__tmp2 == "double") //312:3
                {
                    __out.Append("MetaInstance.Double"); //312:18
                    __out.Append("	"); //313:1
                }
                else if (__tmp2 == "byte") //313:3
                {
                    __out.Append("MetaInstance.Byte"); //313:16
                    __out.Append("	"); //314:1
                }
                else if (__tmp2 == "bool") //314:3
                {
                    __out.Append("MetaInstance.Bool"); //314:16
                    __out.Append("	"); //315:1
                }
                else if (__tmp2 == "void") //315:3
                {
                    __out.Append("MetaInstance.Void"); //315:16
                    __out.Append("	"); //316:1
                }
                else if (__tmp2 == "ModelObject") //316:3
                {
                    __out.Append("MetaInstance.ModelObject"); //316:23
                    __out.Append("	"); //317:1
                }
                else if (__tmp2 == "ModelObjectList") //317:3
                {
                    __out.Append("MetaInstance.ModelObjectList"); //317:27
                }//318:3
            }
            else if (expr is MetaTypeOfExpression) //319:2
            {
                __out.Append(GenerateTypeOf(((MetaTypeOfExpression)expr).TypeReference));
            }
            else if (expr is MetaClass) //320:2
            {
                __out.Append(((MetaClass)expr).JavaFullDescriptorName());
                __out.Append(".getMetaClass()"); //320:52
            }
            else if (expr is MetaCollectionType) //321:2
            {
                __out.Append(((MetaCollectionType)expr).JavaFullName());
            }
            else //322:2
            {
                __out.Append("***error***"); //322:11
            }//323:2
            return __out.ToString();
        }

        public string GenerateCallArguments(MetaBoundExpression call, string prefix) //326:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop21_results = 
                (from __loop21_var1 in __Enumerate((call).GetEnumerator()) //327:7
                from arg in __Enumerate((__loop21_var1.Arguments).GetEnumerator()) //327:13
                select new { __loop21_var1 = __loop21_var1, arg = arg}
                ).ToList(); //327:2
            int __loop21_iteration = 0;
            string delim = ""; //327:28
            foreach (var __tmp1 in __loop21_results)
            {
                ++__loop21_iteration;
                if (__loop21_iteration >= 2) //327:47
                {
                    delim = ", "; //327:47
                }
                var __loop21_var1 = __tmp1.__loop21_var1;
                var arg = __tmp1.arg;
                string __tmp2Prefix = string.Empty; 
                string __tmp3Suffix = string.Empty; 
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append(delim);
                using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                {
                    bool __tmp4_first = true;
                    while(__tmp4_first || !__tmp4Reader.EndOfStream)
                    {
                        __tmp4_first = false;
                        string __tmp4Line = __tmp4Reader.ReadLine();
                        if (__tmp4Line == null)
                        {
                            __tmp4Line = "";
                        }
                        __out.Append(__tmp2Prefix);
                        __out.Append(__tmp4Line);
                    }
                }
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(prefix);
                using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                {
                    bool __tmp5_first = true;
                    while(__tmp5_first || !__tmp5Reader.EndOfStream)
                    {
                        __tmp5_first = false;
                        string __tmp5Line = __tmp5Reader.ReadLine();
                        if (__tmp5Line == null)
                        {
                            __tmp5Line = "";
                        }
                        __out.Append(__tmp5Line);
                    }
                }
                StringBuilder __tmp6 = new StringBuilder();
                __tmp6.Append(GenerateExpression(arg));
                using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
                {
                    bool __tmp6_first = true;
                    while(__tmp6_first || !__tmp6Reader.EndOfStream)
                    {
                        __tmp6_first = false;
                        string __tmp6Line = __tmp6Reader.ReadLine();
                        if (__tmp6Line == null)
                        {
                            __tmp6Line = "";
                        }
                        __out.Append(__tmp6Line);
                        __out.Append(__tmp3Suffix);
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateOperator(MetaOperatorExpression expr) //332:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //333:10
            if (expr is MetaUnaryExpression) //334:2
            {
                if (((MetaUnaryExpression)expr) is MetaPostIncrementAssignExpression || ((MetaUnaryExpression)expr) is MetaPostDecrementAssignExpression) //335:3
                {
                    string __tmp2Prefix = string.Empty; 
                    string __tmp3Suffix = string.Empty; 
                    StringBuilder __tmp4 = new StringBuilder();
                    __tmp4.Append(GenerateExpression(((MetaUnaryExpression)expr).Expression));
                    using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                    {
                        bool __tmp4_first = true;
                        while(__tmp4_first || !__tmp4Reader.EndOfStream)
                        {
                            __tmp4_first = false;
                            string __tmp4Line = __tmp4Reader.ReadLine();
                            if (__tmp4Line == null)
                            {
                                __tmp4Line = "";
                            }
                            __out.Append(__tmp2Prefix);
                            __out.Append(__tmp4Line);
                        }
                    }
                    StringBuilder __tmp5 = new StringBuilder();
                    __tmp5.Append(GetJavaOperator(((MetaUnaryExpression)expr)));
                    using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                    {
                        bool __tmp5_first = true;
                        while(__tmp5_first || !__tmp5Reader.EndOfStream)
                        {
                            __tmp5_first = false;
                            string __tmp5Line = __tmp5Reader.ReadLine();
                            if (__tmp5Line == null)
                            {
                                __tmp5Line = "";
                            }
                            __out.Append(__tmp5Line);
                            __out.Append(__tmp3Suffix);
                        }
                    }
                }
                else //337:3
                {
                    string __tmp6Prefix = string.Empty; 
                    string __tmp7Suffix = string.Empty; 
                    StringBuilder __tmp8 = new StringBuilder();
                    __tmp8.Append(GetJavaOperator(((MetaUnaryExpression)expr)));
                    using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                    {
                        bool __tmp8_first = true;
                        while(__tmp8_first || !__tmp8Reader.EndOfStream)
                        {
                            __tmp8_first = false;
                            string __tmp8Line = __tmp8Reader.ReadLine();
                            if (__tmp8Line == null)
                            {
                                __tmp8Line = "";
                            }
                            __out.Append(__tmp6Prefix);
                            __out.Append(__tmp8Line);
                        }
                    }
                    StringBuilder __tmp9 = new StringBuilder();
                    __tmp9.Append(GenerateExpression(((MetaUnaryExpression)expr).Expression));
                    using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                    {
                        bool __tmp9_first = true;
                        while(__tmp9_first || !__tmp9Reader.EndOfStream)
                        {
                            __tmp9_first = false;
                            string __tmp9Line = __tmp9Reader.ReadLine();
                            if (__tmp9Line == null)
                            {
                                __tmp9Line = "";
                            }
                            __out.Append(__tmp9Line);
                            __out.Append(__tmp7Suffix);
                        }
                    }
                }
            }
            else if (expr is MetaBinaryExpression) //340:2
            {
                string __tmp10Prefix = string.Empty; 
                string __tmp11Suffix = string.Empty; 
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(GenerateExpression(((MetaBinaryExpression)expr).Left));
                using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
                {
                    bool __tmp12_first = true;
                    while(__tmp12_first || !__tmp12Reader.EndOfStream)
                    {
                        __tmp12_first = false;
                        string __tmp12Line = __tmp12Reader.ReadLine();
                        if (__tmp12Line == null)
                        {
                            __tmp12Line = "";
                        }
                        __out.Append(__tmp10Prefix);
                        __out.Append(__tmp12Line);
                    }
                }
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(GetJavaOperator(((MetaBinaryExpression)expr)));
                using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                {
                    bool __tmp13_first = true;
                    while(__tmp13_first || !__tmp13Reader.EndOfStream)
                    {
                        __tmp13_first = false;
                        string __tmp13Line = __tmp13Reader.ReadLine();
                        if (__tmp13Line == null)
                        {
                            __tmp13Line = "";
                        }
                        __out.Append(__tmp13Line);
                    }
                }
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(GenerateExpression(((MetaBinaryExpression)expr).Right));
                using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
                {
                    bool __tmp14_first = true;
                    while(__tmp14_first || !__tmp14Reader.EndOfStream)
                    {
                        __tmp14_first = false;
                        string __tmp14Line = __tmp14Reader.ReadLine();
                        if (__tmp14Line == null)
                        {
                            __tmp14Line = "";
                        }
                        __out.Append(__tmp14Line);
                        __out.Append(__tmp11Suffix);
                    }
                }
            }//342:2
            return __out.ToString();
        }

        public string GenerateNewPropertyInitializers(MetaNewExpression expr) //345:1
        {
            StringBuilder __out = new StringBuilder();
            if ((from __loop22_var1 in __Enumerate((expr).GetEnumerator()) //346:14
            from pi in __Enumerate((__loop22_var1.PropertyInitializers).GetEnumerator()) //346:20
            select new { __loop22_var1 = __loop22_var1, pi = pi}
            ).GetEnumerator().MoveNext()) //346:2
            {
                string __tmp1Prefix = "java.util.Arrays.asList(new metadslx.core.ModelPropertyInitializer"; //347:1
                string __tmp2Suffix = " {"; //347:73
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append("[]");
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_first = true;
                    while(__tmp3_first || !__tmp3Reader.EndOfStream)
                    {
                        __tmp3_first = false;
                        string __tmp3Line = __tmp3Reader.ReadLine();
                        if (__tmp3Line == null)
                        {
                            __tmp3Line = "";
                        }
                        __out.Append(__tmp1Prefix);
                        __out.Append(__tmp3Line);
                        __out.Append(__tmp2Suffix);
                    }
                }
                var __loop23_results = 
                    (from __loop23_var1 in __Enumerate((expr).GetEnumerator()) //348:7
                    from pi in __Enumerate((__loop23_var1.PropertyInitializers).GetEnumerator()) //348:13
                    select new { __loop23_var1 = __loop23_var1, pi = pi}
                    ).ToList(); //348:2
                int __loop23_iteration = 0;
                string delim = ""; //348:38
                foreach (var __tmp4 in __loop23_results)
                {
                    ++__loop23_iteration;
                    if (__loop23_iteration >= 2) //348:57
                    {
                        delim = ", "; //348:57
                    }
                    var __loop23_var1 = __tmp4.__loop23_var1;
                    var pi = __tmp4.pi;
                    string __tmp5Prefix = string.Empty; 
                    string __tmp6Suffix = ", true))"; //349:153
                    StringBuilder __tmp7 = new StringBuilder();
                    __tmp7.Append(delim);
                    using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
                    {
                        bool __tmp7_first = true;
                        while(__tmp7_first || !__tmp7Reader.EndOfStream)
                        {
                            __tmp7_first = false;
                            string __tmp7Line = __tmp7Reader.ReadLine();
                            if (__tmp7Line == null)
                            {
                                __tmp7Line = "";
                            }
                            __out.Append(__tmp5Prefix);
                            __out.Append(__tmp7Line);
                        }
                    }
                    string __tmp8Line = "new metadslx.core.ModelPropertyInitializer("; //349:8
                    __out.Append(__tmp8Line);
                    StringBuilder __tmp9 = new StringBuilder();
                    __tmp9.Append(pi.Property.JavaFullDescriptorName());
                    using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                    {
                        bool __tmp9_first = true;
                        while(__tmp9_first || !__tmp9Reader.EndOfStream)
                        {
                            __tmp9_first = false;
                            string __tmp9Line = __tmp9Reader.ReadLine();
                            if (__tmp9Line == null)
                            {
                                __tmp9Line = "";
                            }
                            __out.Append(__tmp9Line);
                        }
                    }
                    string __tmp10Line = ", metadslx.core.Lazy.create(() -> "; //349:89
                    __out.Append(__tmp10Line);
                    StringBuilder __tmp11 = new StringBuilder();
                    __tmp11.Append(GenerateExpression(pi.Value));
                    using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                    {
                        bool __tmp11_first = true;
                        while(__tmp11_first || !__tmp11Reader.EndOfStream)
                        {
                            __tmp11_first = false;
                            string __tmp11Line = __tmp11Reader.ReadLine();
                            if (__tmp11Line == null)
                            {
                                __tmp11Line = "";
                            }
                            __out.Append(__tmp11Line);
                            __out.Append(__tmp6Suffix);
                        }
                    }
                }
                __out.Append("})"); //351:1
            }
            return __out.ToString();
        }

        public string GenerateNewCollectionValues(MetaNewCollectionExpression expr) //355:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((expr).GetEnumerator()) //356:7
                from v in __Enumerate((__loop24_var1.Values).GetEnumerator()) //356:13
                select new { __loop24_var1 = __loop24_var1, v = v}
                ).ToList(); //356:2
            int __loop24_iteration = 0;
            string delim = ""; //356:23
            foreach (var __tmp1 in __loop24_results)
            {
                ++__loop24_iteration;
                if (__loop24_iteration >= 2) //356:42
                {
                    delim = ", \n"; //356:42
                }
                var __loop24_var1 = __tmp1.__loop24_var1;
                var v = __tmp1.v;
                string __tmp2Prefix = string.Empty; 
                string __tmp3Suffix = string.Empty; 
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append(delim);
                using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                {
                    bool __tmp4_first = true;
                    while(__tmp4_first || !__tmp4Reader.EndOfStream)
                    {
                        __tmp4_first = false;
                        string __tmp4Line = __tmp4Reader.ReadLine();
                        if (__tmp4Line == null)
                        {
                            __tmp4Line = "";
                        }
                        __out.Append(__tmp2Prefix);
                        __out.Append(__tmp4Line);
                    }
                }
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(GenerateExpression(v));
                using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                {
                    bool __tmp5_first = true;
                    while(__tmp5_first || !__tmp5Reader.EndOfStream)
                    {
                        __tmp5_first = false;
                        string __tmp5Line = __tmp5Reader.ReadLine();
                        if (__tmp5Line == null)
                        {
                            __tmp5Line = "";
                        }
                        __out.Append(__tmp5Line);
                        __out.Append(__tmp3Suffix);
                    }
                }
            }
            return __out.ToString();
        }

        public string GetJavaValue(object value) //361:1
        {
            if (value == null) //362:2
            {
                return "null"; //362:21
            }
            else if (value is bool && ((bool)value) == true) //363:2
            {
                return "true"; //363:51
            }
            else if (value is bool && ((bool)value) == false) //364:2
            {
                return "false"; //364:52
            }
            else if (value is string) //365:2
            {
                return "\"" + value.ToString() + "\""; //365:28
            }
            else if (value is MetaExpression) //366:2
            {
                return GenerateExpression((MetaExpression)value); //366:36
            }
            else //367:2
            {
                return value.ToString(); //367:7
            }
        }

        public string GetJavaIdentifier(object value) //371:1
        {
            if (value == null) //372:2
            {
                return null; //373:3
            }
            if (value is MetaConstantExpression && ((MetaConstantExpression)value).Value != null) //375:2
            {
                return ((MetaConstantExpression)value).Value.ToString(); //376:3
            }
            else if (value is string) //377:2
            {
                return value.ToString(); //378:3
            }
            else //379:2
            {
                return null; //380:3
            }
        }

        public string GetJavaOperator(MetaOperatorExpression expr) //384:1
        {
            var __tmp1 = expr; //385:9
            if (expr is MetaUnaryPlusExpression) //386:3
            {
                return "+"; //386:36
            }
            else if (expr is MetaNegateExpression) //387:3
            {
                return "-"; //387:33
            }
            else if (expr is MetaOnesComplementExpression) //388:3
            {
                return "~"; //388:41
            }
            else if (expr is MetaNotExpression) //389:3
            {
                return "!"; //389:30
            }
            else if (expr is MetaPostIncrementAssignExpression) //390:3
            {
                return "++"; //390:46
            }
            else if (expr is MetaPostDecrementAssignExpression) //391:3
            {
                return "--"; //391:46
            }
            else if (expr is MetaPreIncrementAssignExpression) //392:3
            {
                return "++"; //392:45
            }
            else if (expr is MetaPreDecrementAssignExpression) //393:3
            {
                return "--"; //393:45
            }
            else if (expr is MetaMultiplyExpression) //394:3
            {
                return "*"; //394:35
            }
            else if (expr is MetaDivideExpression) //395:3
            {
                return "/"; //395:33
            }
            else if (expr is MetaModuloExpression) //396:3
            {
                return "%"; //396:33
            }
            else if (expr is MetaAddExpression) //397:3
            {
                return "+"; //397:30
            }
            else if (expr is MetaSubtractExpression) //398:3
            {
                return "-"; //398:35
            }
            else if (expr is MetaLeftShiftExpression) //399:3
            {
                return "<<"; //399:36
            }
            else if (expr is MetaRightShiftExpression) //400:3
            {
                return ">>"; //400:37
            }
            else if (expr is MetaLessThanExpression) //401:3
            {
                return "<"; //401:35
            }
            else if (expr is MetaLessThanOrEqualExpression) //402:3
            {
                return "<="; //402:42
            }
            else if (expr is MetaGreaterThanExpression) //403:3
            {
                return ">"; //403:38
            }
            else if (expr is MetaGreaterThanOrEqualExpression) //404:3
            {
                return ">="; //404:45
            }
            else if (expr is MetaEqualExpression) //405:3
            {
                return "=="; //405:32
            }
            else if (expr is MetaNotEqualExpression) //406:3
            {
                return "!="; //406:35
            }
            else if (expr is MetaAndExpression) //407:3
            {
                return "&"; //407:30
            }
            else if (expr is MetaOrExpression) //408:3
            {
                return "|"; //408:29
            }
            else if (expr is MetaExclusiveOrExpression) //409:3
            {
                return "^"; //409:38
            }
            else if (expr is MetaAndAlsoExpression) //410:3
            {
                return "&&"; //410:34
            }
            else if (expr is MetaOrElseExpression) //411:3
            {
                return "||"; //411:33
            }
            else if (expr is MetaNullCoalescingExpression) //412:3
            {
                return "??"; //412:41
            }
            else if (expr is MetaMultiplyAssignExpression) //413:3
            {
                return "*="; //413:41
            }
            else if (expr is MetaDivideAssignExpression) //414:3
            {
                return "/="; //414:39
            }
            else if (expr is MetaModuloAssignExpression) //415:3
            {
                return "%="; //415:39
            }
            else if (expr is MetaAddAssignExpression) //416:3
            {
                return "+="; //416:36
            }
            else if (expr is MetaSubtractAssignExpression) //417:3
            {
                return "-="; //417:41
            }
            else if (expr is MetaLeftShiftAssignExpression) //418:3
            {
                return "<<="; //418:42
            }
            else if (expr is MetaRightShiftAssignExpression) //419:3
            {
                return ">>="; //419:43
            }
            else if (expr is MetaAndAssignExpression) //420:3
            {
                return "&="; //420:36
            }
            else if (expr is MetaExclusiveOrAssignExpression) //421:3
            {
                return "^="; //421:44
            }
            else if (expr is MetaOrAssignExpression) //422:3
            {
                return "|="; //422:35
            }
            else //423:3
            {
                return ""; //423:12
            }//424:2
        }

        public string GetTypeName(MetaExpression expr) //427:1
        {
            if (expr is MetaTypeOfExpression) //428:2
            {
                return ((MetaTypeOfExpression)expr).TypeReference.JavaFullName(); //428:36
            }
            else //429:2
            {
                return null; //429:7
            }
        }

        public MetaSynthetizedPropertyInitializer GetSynthetizedInitializerFor(MetaClass cls, MetaProperty prop) //433:1
        {
            MetaSynthetizedPropertyInitializer lastInit = null; //434:2
            var __loop25_results = 
                (from __loop25_var1 in __Enumerate((cls).GetEnumerator()) //435:7
                from sup in __Enumerate((__loop25_var1.GetAllSuperClasses(true)).GetEnumerator()) //435:12
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //435:42
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //435:55
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaSynthetizedPropertyInitializer>() //435:69
                select new { __loop25_var1 = __loop25_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //435:2
            int __loop25_iteration = 0;
            foreach (var __tmp1 in __loop25_results)
            {
                ++__loop25_iteration;
                var __loop25_var1 = __tmp1.__loop25_var1;
                var sup = __tmp1.sup;
                var Constructor = __tmp1.Constructor;
                var Initializers = __tmp1.Initializers;
                var init = __tmp1.init;
                if (init.Property == prop) //436:3
                {
                    lastInit = init; //437:4
                }
            }
            return lastInit; //440:2
        }

        public string GenerateConstructorImpl(MetaModel model, MetaClass cls) //443:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public "; //444:1
            string __tmp2Suffix = "() {"; //444:28
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.JavaImplName());
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //444:32
                }
            }
            var __loop26_results = 
                (from __loop26_var1 in __Enumerate((cls).GetEnumerator()) //445:8
                from prop in __Enumerate((__loop26_var1.GetAllProperties()).GetEnumerator()) //445:13
                select new { __loop26_var1 = __loop26_var1, prop = prop}
                ).ToList(); //445:3
            int __loop26_iteration = 0;
            foreach (var __tmp4 in __loop26_results)
            {
                ++__loop26_iteration;
                var __loop26_var1 = __tmp4.__loop26_var1;
                var prop = __tmp4.prop;
                MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //446:4
                if (synInit != null) //447:4
                {
                    if (prop.Kind != MetaPropertyKind.Derived) //448:5
                    {
                        if (ModelCompilerContext.Current.TypeProvider.GetTypeOf(synInit.Value) is MetaCollectionType) //449:6
                        {
                            string __tmp5Prefix = "    this.mLazySet("; //450:1
                            string __tmp6Suffix = ", true));"; //450:119
                            StringBuilder __tmp7 = new StringBuilder();
                            __tmp7.Append(prop.JavaFullDescriptorName());
                            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
                            {
                                bool __tmp7_first = true;
                                while(__tmp7_first || !__tmp7Reader.EndOfStream)
                                {
                                    __tmp7_first = false;
                                    string __tmp7Line = __tmp7Reader.ReadLine();
                                    if (__tmp7Line == null)
                                    {
                                        __tmp7Line = "";
                                    }
                                    __out.Append(__tmp5Prefix);
                                    __out.Append(__tmp7Line);
                                }
                            }
                            string __tmp8Line = ", metadslx.core.Lazy.create(() -> "; //450:50
                            __out.Append(__tmp8Line);
                            StringBuilder __tmp9 = new StringBuilder();
                            __tmp9.Append(GenerateExpression(synInit.Value));
                            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                            {
                                bool __tmp9_first = true;
                                while(__tmp9_first || !__tmp9Reader.EndOfStream)
                                {
                                    __tmp9_first = false;
                                    string __tmp9Line = __tmp9Reader.ReadLine();
                                    if (__tmp9Line == null)
                                    {
                                        __tmp9Line = "";
                                    }
                                    __out.Append(__tmp9Line);
                                    __out.Append(__tmp6Suffix);
                                    __out.AppendLine(); //450:128
                                }
                            }
                        }
                        else //451:6
                        {
                            string __tmp10Prefix = "    this.mLazySet("; //452:1
                            string __tmp11Suffix = ", true));"; //452:119
                            StringBuilder __tmp12 = new StringBuilder();
                            __tmp12.Append(prop.JavaFullDescriptorName());
                            using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
                            {
                                bool __tmp12_first = true;
                                while(__tmp12_first || !__tmp12Reader.EndOfStream)
                                {
                                    __tmp12_first = false;
                                    string __tmp12Line = __tmp12Reader.ReadLine();
                                    if (__tmp12Line == null)
                                    {
                                        __tmp12Line = "";
                                    }
                                    __out.Append(__tmp10Prefix);
                                    __out.Append(__tmp12Line);
                                }
                            }
                            string __tmp13Line = ", metadslx.core.Lazy.create(() -> "; //452:50
                            __out.Append(__tmp13Line);
                            StringBuilder __tmp14 = new StringBuilder();
                            __tmp14.Append(GenerateExpression(synInit.Value));
                            using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
                            {
                                bool __tmp14_first = true;
                                while(__tmp14_first || !__tmp14Reader.EndOfStream)
                                {
                                    __tmp14_first = false;
                                    string __tmp14Line = __tmp14Reader.ReadLine();
                                    if (__tmp14Line == null)
                                    {
                                        __tmp14Line = "";
                                    }
                                    __out.Append(__tmp14Line);
                                    __out.Append(__tmp11Suffix);
                                    __out.AppendLine(); //452:128
                                }
                            }
                        }
                    }
                    else //454:5
                    {
                        string __tmp15Prefix = "    this.mDerivedSet("; //455:1
                        string __tmp16Suffix = ");"; //455:96
                        StringBuilder __tmp17 = new StringBuilder();
                        __tmp17.Append(prop.JavaFullDescriptorName());
                        using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
                        {
                            bool __tmp17_first = true;
                            while(__tmp17_first || !__tmp17Reader.EndOfStream)
                            {
                                __tmp17_first = false;
                                string __tmp17Line = __tmp17Reader.ReadLine();
                                if (__tmp17Line == null)
                                {
                                    __tmp17Line = "";
                                }
                                __out.Append(__tmp15Prefix);
                                __out.Append(__tmp17Line);
                            }
                        }
                        string __tmp18Line = ", () -> "; //455:53
                        __out.Append(__tmp18Line);
                        StringBuilder __tmp19 = new StringBuilder();
                        __tmp19.Append(GenerateExpression(synInit.Value));
                        using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
                        {
                            bool __tmp19_first = true;
                            while(__tmp19_first || !__tmp19Reader.EndOfStream)
                            {
                                __tmp19_first = false;
                                string __tmp19Line = __tmp19Reader.ReadLine();
                                if (__tmp19Line == null)
                                {
                                    __tmp19Line = "";
                                }
                                __out.Append(__tmp19Line);
                                __out.Append(__tmp16Suffix);
                                __out.AppendLine(); //455:98
                            }
                        }
                    }
                }
                else //457:4
                {
                    if (prop.Type is MetaCollectionType) //458:5
                    {
                        if (prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) //459:6
                        {
                            string __tmp20Prefix = "    this.mSet("; //460:1
                            string __tmp21Suffix = "));"; //460:113
                            StringBuilder __tmp22 = new StringBuilder();
                            __tmp22.Append(prop.JavaFullDescriptorName());
                            using(StreamReader __tmp22Reader = new StreamReader(this.__ToStream(__tmp22.ToString())))
                            {
                                bool __tmp22_first = true;
                                while(__tmp22_first || !__tmp22Reader.EndOfStream)
                                {
                                    __tmp22_first = false;
                                    string __tmp22Line = __tmp22Reader.ReadLine();
                                    if (__tmp22Line == null)
                                    {
                                        __tmp22Line = "";
                                    }
                                    __out.Append(__tmp20Prefix);
                                    __out.Append(__tmp22Line);
                                }
                            }
                            string __tmp23Line = ", new "; //460:46
                            __out.Append(__tmp23Line);
                            StringBuilder __tmp24 = new StringBuilder();
                            __tmp24.Append(prop.Type.JavaName());
                            using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
                            {
                                bool __tmp24_first = true;
                                while(__tmp24_first || !__tmp24Reader.EndOfStream)
                                {
                                    __tmp24_first = false;
                                    string __tmp24Line = __tmp24Reader.ReadLine();
                                    if (__tmp24Line == null)
                                    {
                                        __tmp24Line = "";
                                    }
                                    __out.Append(__tmp24Line);
                                }
                            }
                            string __tmp25Line = "("; //460:74
                            __out.Append(__tmp25Line);
                            StringBuilder __tmp26 = new StringBuilder();
                            __tmp26.Append(GetCollectionConstructorParams(prop));
                            using(StreamReader __tmp26Reader = new StreamReader(this.__ToStream(__tmp26.ToString())))
                            {
                                bool __tmp26_first = true;
                                while(__tmp26_first || !__tmp26Reader.EndOfStream)
                                {
                                    __tmp26_first = false;
                                    string __tmp26Line = __tmp26Reader.ReadLine();
                                    if (__tmp26Line == null)
                                    {
                                        __tmp26Line = "";
                                    }
                                    __out.Append(__tmp26Line);
                                    __out.Append(__tmp21Suffix);
                                    __out.AppendLine(); //460:116
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //461:6
                        {
                            string __tmp27Prefix = "    this.mLazySet("; //462:1
                            string __tmp28Suffix = "(this), true));"; //462:167
                            StringBuilder __tmp29 = new StringBuilder();
                            __tmp29.Append(prop.JavaFullDescriptorName());
                            using(StreamReader __tmp29Reader = new StreamReader(this.__ToStream(__tmp29.ToString())))
                            {
                                bool __tmp29_first = true;
                                while(__tmp29_first || !__tmp29Reader.EndOfStream)
                                {
                                    __tmp29_first = false;
                                    string __tmp29Line = __tmp29Reader.ReadLine();
                                    if (__tmp29Line == null)
                                    {
                                        __tmp29Line = "";
                                    }
                                    __out.Append(__tmp27Prefix);
                                    __out.Append(__tmp29Line);
                                }
                            }
                            string __tmp30Line = ", metadslx.core.Lazy.create(() -> "; //462:50
                            __out.Append(__tmp30Line);
                            StringBuilder __tmp31 = new StringBuilder();
                            __tmp31.Append(prop.Class.Model.JavaFullImplementationName());
                            using(StreamReader __tmp31Reader = new StreamReader(this.__ToStream(__tmp31.ToString())))
                            {
                                bool __tmp31_first = true;
                                while(__tmp31_first || !__tmp31Reader.EndOfStream)
                                {
                                    __tmp31_first = false;
                                    string __tmp31Line = __tmp31Reader.ReadLine();
                                    if (__tmp31Line == null)
                                    {
                                        __tmp31Line = "";
                                    }
                                    __out.Append(__tmp31Line);
                                }
                            }
                            string __tmp32Line = "."; //462:131
                            __out.Append(__tmp32Line);
                            StringBuilder __tmp33 = new StringBuilder();
                            __tmp33.Append(prop.Class.JavaName());
                            using(StreamReader __tmp33Reader = new StreamReader(this.__ToStream(__tmp33.ToString())))
                            {
                                bool __tmp33_first = true;
                                while(__tmp33_first || !__tmp33Reader.EndOfStream)
                                {
                                    __tmp33_first = false;
                                    string __tmp33Line = __tmp33Reader.ReadLine();
                                    if (__tmp33Line == null)
                                    {
                                        __tmp33Line = "";
                                    }
                                    __out.Append(__tmp33Line);
                                }
                            }
                            string __tmp34Line = "_"; //462:155
                            __out.Append(__tmp34Line);
                            StringBuilder __tmp35 = new StringBuilder();
                            __tmp35.Append(prop.Name);
                            using(StreamReader __tmp35Reader = new StreamReader(this.__ToStream(__tmp35.ToString())))
                            {
                                bool __tmp35_first = true;
                                while(__tmp35_first || !__tmp35Reader.EndOfStream)
                                {
                                    __tmp35_first = false;
                                    string __tmp35Line = __tmp35Reader.ReadLine();
                                    if (__tmp35Line == null)
                                    {
                                        __tmp35Line = "";
                                    }
                                    __out.Append(__tmp35Line);
                                    __out.Append(__tmp28Suffix);
                                    __out.AppendLine(); //462:182
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Derived) //463:6
                        {
                            string __tmp36Prefix = "    this.mDerivedSet("; //464:1
                            string __tmp37Suffix = "(this));"; //464:144
                            StringBuilder __tmp38 = new StringBuilder();
                            __tmp38.Append(prop.JavaFullDescriptorName());
                            using(StreamReader __tmp38Reader = new StreamReader(this.__ToStream(__tmp38.ToString())))
                            {
                                bool __tmp38_first = true;
                                while(__tmp38_first || !__tmp38Reader.EndOfStream)
                                {
                                    __tmp38_first = false;
                                    string __tmp38Line = __tmp38Reader.ReadLine();
                                    if (__tmp38Line == null)
                                    {
                                        __tmp38Line = "";
                                    }
                                    __out.Append(__tmp36Prefix);
                                    __out.Append(__tmp38Line);
                                }
                            }
                            string __tmp39Line = ", () -> "; //464:53
                            __out.Append(__tmp39Line);
                            StringBuilder __tmp40 = new StringBuilder();
                            __tmp40.Append(prop.Class.Model.JavaFullImplementationName());
                            using(StreamReader __tmp40Reader = new StreamReader(this.__ToStream(__tmp40.ToString())))
                            {
                                bool __tmp40_first = true;
                                while(__tmp40_first || !__tmp40Reader.EndOfStream)
                                {
                                    __tmp40_first = false;
                                    string __tmp40Line = __tmp40Reader.ReadLine();
                                    if (__tmp40Line == null)
                                    {
                                        __tmp40Line = "";
                                    }
                                    __out.Append(__tmp40Line);
                                }
                            }
                            string __tmp41Line = "."; //464:108
                            __out.Append(__tmp41Line);
                            StringBuilder __tmp42 = new StringBuilder();
                            __tmp42.Append(prop.Class.JavaName());
                            using(StreamReader __tmp42Reader = new StreamReader(this.__ToStream(__tmp42.ToString())))
                            {
                                bool __tmp42_first = true;
                                while(__tmp42_first || !__tmp42Reader.EndOfStream)
                                {
                                    __tmp42_first = false;
                                    string __tmp42Line = __tmp42Reader.ReadLine();
                                    if (__tmp42Line == null)
                                    {
                                        __tmp42Line = "";
                                    }
                                    __out.Append(__tmp42Line);
                                }
                            }
                            string __tmp43Line = "_"; //464:132
                            __out.Append(__tmp43Line);
                            StringBuilder __tmp44 = new StringBuilder();
                            __tmp44.Append(prop.Name);
                            using(StreamReader __tmp44Reader = new StreamReader(this.__ToStream(__tmp44.ToString())))
                            {
                                bool __tmp44_first = true;
                                while(__tmp44_first || !__tmp44Reader.EndOfStream)
                                {
                                    __tmp44_first = false;
                                    string __tmp44Line = __tmp44Reader.ReadLine();
                                    if (__tmp44Line == null)
                                    {
                                        __tmp44Line = "";
                                    }
                                    __out.Append(__tmp44Line);
                                    __out.Append(__tmp37Suffix);
                                    __out.AppendLine(); //464:152
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Readonly) //465:6
                        {
                            string __tmp45Prefix = "    // Init "; //466:1
                            string __tmp46Suffix = string.Empty; 
                            StringBuilder __tmp47 = new StringBuilder();
                            __tmp47.Append(prop.JavaFullDescriptorName());
                            using(StreamReader __tmp47Reader = new StreamReader(this.__ToStream(__tmp47.ToString())))
                            {
                                bool __tmp47_first = true;
                                while(__tmp47_first || !__tmp47Reader.EndOfStream)
                                {
                                    __tmp47_first = false;
                                    string __tmp47Line = __tmp47Reader.ReadLine();
                                    if (__tmp47Line == null)
                                    {
                                        __tmp47Line = "";
                                    }
                                    __out.Append(__tmp45Prefix);
                                    __out.Append(__tmp47Line);
                                }
                            }
                            string __tmp48Line = " in "; //466:44
                            __out.Append(__tmp48Line);
                            StringBuilder __tmp49 = new StringBuilder();
                            __tmp49.Append(prop.Class.Model.JavaFullImplementationName());
                            using(StreamReader __tmp49Reader = new StreamReader(this.__ToStream(__tmp49.ToString())))
                            {
                                bool __tmp49_first = true;
                                while(__tmp49_first || !__tmp49Reader.EndOfStream)
                                {
                                    __tmp49_first = false;
                                    string __tmp49Line = __tmp49Reader.ReadLine();
                                    if (__tmp49Line == null)
                                    {
                                        __tmp49Line = "";
                                    }
                                    __out.Append(__tmp49Line);
                                }
                            }
                            string __tmp50Line = "."; //466:95
                            __out.Append(__tmp50Line);
                            StringBuilder __tmp51 = new StringBuilder();
                            __tmp51.Append(cls.JavaName());
                            using(StreamReader __tmp51Reader = new StreamReader(this.__ToStream(__tmp51.ToString())))
                            {
                                bool __tmp51_first = true;
                                while(__tmp51_first || !__tmp51Reader.EndOfStream)
                                {
                                    __tmp51_first = false;
                                    string __tmp51Line = __tmp51Reader.ReadLine();
                                    if (__tmp51Line == null)
                                    {
                                        __tmp51Line = "";
                                    }
                                    __out.Append(__tmp51Line);
                                }
                            }
                            string __tmp52Line = "_"; //466:112
                            __out.Append(__tmp52Line);
                            StringBuilder __tmp53 = new StringBuilder();
                            __tmp53.Append(cls.JavaName());
                            using(StreamReader __tmp53Reader = new StreamReader(this.__ToStream(__tmp53.ToString())))
                            {
                                bool __tmp53_first = true;
                                while(__tmp53_first || !__tmp53Reader.EndOfStream)
                                {
                                    __tmp53_first = false;
                                    string __tmp53Line = __tmp53Reader.ReadLine();
                                    if (__tmp53Line == null)
                                    {
                                        __tmp53Line = "";
                                    }
                                    __out.Append(__tmp53Line);
                                    __out.Append(__tmp46Suffix);
                                    __out.AppendLine(); //466:129
                                }
                            }
                        }
                    }
                    else //468:5
                    {
                        if (prop.Kind == MetaPropertyKind.Lazy) //469:6
                        {
                            string __tmp54Prefix = "    this.mLazySet("; //470:1
                            string __tmp55Suffix = "(this), true));"; //470:156
                            StringBuilder __tmp56 = new StringBuilder();
                            __tmp56.Append(prop.JavaFullDescriptorName());
                            using(StreamReader __tmp56Reader = new StreamReader(this.__ToStream(__tmp56.ToString())))
                            {
                                bool __tmp56_first = true;
                                while(__tmp56_first || !__tmp56Reader.EndOfStream)
                                {
                                    __tmp56_first = false;
                                    string __tmp56Line = __tmp56Reader.ReadLine();
                                    if (__tmp56Line == null)
                                    {
                                        __tmp56Line = "";
                                    }
                                    __out.Append(__tmp54Prefix);
                                    __out.Append(__tmp56Line);
                                }
                            }
                            string __tmp57Line = ", metadslx.core.Lazy.create(() -> "; //470:50
                            __out.Append(__tmp57Line);
                            StringBuilder __tmp58 = new StringBuilder();
                            __tmp58.Append(model.JavaFullImplementationName());
                            using(StreamReader __tmp58Reader = new StreamReader(this.__ToStream(__tmp58.ToString())))
                            {
                                bool __tmp58_first = true;
                                while(__tmp58_first || !__tmp58Reader.EndOfStream)
                                {
                                    __tmp58_first = false;
                                    string __tmp58Line = __tmp58Reader.ReadLine();
                                    if (__tmp58Line == null)
                                    {
                                        __tmp58Line = "";
                                    }
                                    __out.Append(__tmp58Line);
                                }
                            }
                            string __tmp59Line = "."; //470:120
                            __out.Append(__tmp59Line);
                            StringBuilder __tmp60 = new StringBuilder();
                            __tmp60.Append(prop.Class.JavaName());
                            using(StreamReader __tmp60Reader = new StreamReader(this.__ToStream(__tmp60.ToString())))
                            {
                                bool __tmp60_first = true;
                                while(__tmp60_first || !__tmp60Reader.EndOfStream)
                                {
                                    __tmp60_first = false;
                                    string __tmp60Line = __tmp60Reader.ReadLine();
                                    if (__tmp60Line == null)
                                    {
                                        __tmp60Line = "";
                                    }
                                    __out.Append(__tmp60Line);
                                }
                            }
                            string __tmp61Line = "_"; //470:144
                            __out.Append(__tmp61Line);
                            StringBuilder __tmp62 = new StringBuilder();
                            __tmp62.Append(prop.Name);
                            using(StreamReader __tmp62Reader = new StreamReader(this.__ToStream(__tmp62.ToString())))
                            {
                                bool __tmp62_first = true;
                                while(__tmp62_first || !__tmp62Reader.EndOfStream)
                                {
                                    __tmp62_first = false;
                                    string __tmp62Line = __tmp62Reader.ReadLine();
                                    if (__tmp62Line == null)
                                    {
                                        __tmp62Line = "";
                                    }
                                    __out.Append(__tmp62Line);
                                    __out.Append(__tmp55Suffix);
                                    __out.AppendLine(); //470:171
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Derived) //471:6
                        {
                            string __tmp63Prefix = "    this.mDerivedSet("; //472:1
                            string __tmp64Suffix = "(this));"; //472:133
                            StringBuilder __tmp65 = new StringBuilder();
                            __tmp65.Append(prop.JavaFullDescriptorName());
                            using(StreamReader __tmp65Reader = new StreamReader(this.__ToStream(__tmp65.ToString())))
                            {
                                bool __tmp65_first = true;
                                while(__tmp65_first || !__tmp65Reader.EndOfStream)
                                {
                                    __tmp65_first = false;
                                    string __tmp65Line = __tmp65Reader.ReadLine();
                                    if (__tmp65Line == null)
                                    {
                                        __tmp65Line = "";
                                    }
                                    __out.Append(__tmp63Prefix);
                                    __out.Append(__tmp65Line);
                                }
                            }
                            string __tmp66Line = ", () -> "; //472:53
                            __out.Append(__tmp66Line);
                            StringBuilder __tmp67 = new StringBuilder();
                            __tmp67.Append(model.JavaFullImplementationName());
                            using(StreamReader __tmp67Reader = new StreamReader(this.__ToStream(__tmp67.ToString())))
                            {
                                bool __tmp67_first = true;
                                while(__tmp67_first || !__tmp67Reader.EndOfStream)
                                {
                                    __tmp67_first = false;
                                    string __tmp67Line = __tmp67Reader.ReadLine();
                                    if (__tmp67Line == null)
                                    {
                                        __tmp67Line = "";
                                    }
                                    __out.Append(__tmp67Line);
                                }
                            }
                            string __tmp68Line = "."; //472:97
                            __out.Append(__tmp68Line);
                            StringBuilder __tmp69 = new StringBuilder();
                            __tmp69.Append(prop.Class.JavaName());
                            using(StreamReader __tmp69Reader = new StreamReader(this.__ToStream(__tmp69.ToString())))
                            {
                                bool __tmp69_first = true;
                                while(__tmp69_first || !__tmp69Reader.EndOfStream)
                                {
                                    __tmp69_first = false;
                                    string __tmp69Line = __tmp69Reader.ReadLine();
                                    if (__tmp69Line == null)
                                    {
                                        __tmp69Line = "";
                                    }
                                    __out.Append(__tmp69Line);
                                }
                            }
                            string __tmp70Line = "_"; //472:121
                            __out.Append(__tmp70Line);
                            StringBuilder __tmp71 = new StringBuilder();
                            __tmp71.Append(prop.Name);
                            using(StreamReader __tmp71Reader = new StreamReader(this.__ToStream(__tmp71.ToString())))
                            {
                                bool __tmp71_first = true;
                                while(__tmp71_first || !__tmp71Reader.EndOfStream)
                                {
                                    __tmp71_first = false;
                                    string __tmp71Line = __tmp71Reader.ReadLine();
                                    if (__tmp71Line == null)
                                    {
                                        __tmp71Line = "";
                                    }
                                    __out.Append(__tmp71Line);
                                    __out.Append(__tmp64Suffix);
                                    __out.AppendLine(); //472:141
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Readonly) //473:6
                        {
                            string __tmp72Prefix = "    // Init "; //474:1
                            string __tmp73Suffix = string.Empty; 
                            StringBuilder __tmp74 = new StringBuilder();
                            __tmp74.Append(prop.JavaFullDescriptorName());
                            using(StreamReader __tmp74Reader = new StreamReader(this.__ToStream(__tmp74.ToString())))
                            {
                                bool __tmp74_first = true;
                                while(__tmp74_first || !__tmp74Reader.EndOfStream)
                                {
                                    __tmp74_first = false;
                                    string __tmp74Line = __tmp74Reader.ReadLine();
                                    if (__tmp74Line == null)
                                    {
                                        __tmp74Line = "";
                                    }
                                    __out.Append(__tmp72Prefix);
                                    __out.Append(__tmp74Line);
                                }
                            }
                            string __tmp75Line = " in "; //474:44
                            __out.Append(__tmp75Line);
                            StringBuilder __tmp76 = new StringBuilder();
                            __tmp76.Append(model.JavaFullImplementationName());
                            using(StreamReader __tmp76Reader = new StreamReader(this.__ToStream(__tmp76.ToString())))
                            {
                                bool __tmp76_first = true;
                                while(__tmp76_first || !__tmp76Reader.EndOfStream)
                                {
                                    __tmp76_first = false;
                                    string __tmp76Line = __tmp76Reader.ReadLine();
                                    if (__tmp76Line == null)
                                    {
                                        __tmp76Line = "";
                                    }
                                    __out.Append(__tmp76Line);
                                }
                            }
                            string __tmp77Line = "."; //474:84
                            __out.Append(__tmp77Line);
                            StringBuilder __tmp78 = new StringBuilder();
                            __tmp78.Append(cls.JavaName());
                            using(StreamReader __tmp78Reader = new StreamReader(this.__ToStream(__tmp78.ToString())))
                            {
                                bool __tmp78_first = true;
                                while(__tmp78_first || !__tmp78Reader.EndOfStream)
                                {
                                    __tmp78_first = false;
                                    string __tmp78Line = __tmp78Reader.ReadLine();
                                    if (__tmp78Line == null)
                                    {
                                        __tmp78Line = "";
                                    }
                                    __out.Append(__tmp78Line);
                                }
                            }
                            string __tmp79Line = "_"; //474:101
                            __out.Append(__tmp79Line);
                            StringBuilder __tmp80 = new StringBuilder();
                            __tmp80.Append(cls.JavaName());
                            using(StreamReader __tmp80Reader = new StreamReader(this.__ToStream(__tmp80.ToString())))
                            {
                                bool __tmp80_first = true;
                                while(__tmp80_first || !__tmp80Reader.EndOfStream)
                                {
                                    __tmp80_first = false;
                                    string __tmp80Line = __tmp80Reader.ReadLine();
                                    if (__tmp80Line == null)
                                    {
                                        __tmp80Line = "";
                                    }
                                    __out.Append(__tmp80Line);
                                    __out.Append(__tmp73Suffix);
                                    __out.AppendLine(); //474:118
                                }
                            }
                        }
                    }
                }
            }
            var __loop27_results = 
                (from __loop27_var1 in __Enumerate((cls).GetEnumerator()) //479:8
                from sup in __Enumerate((__loop27_var1.GetAllSuperClasses(true)).GetEnumerator()) //479:13
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //479:43
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //479:56
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaInheritedPropertyInitializer>() //479:70
                select new { __loop27_var1 = __loop27_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //479:3
            int __loop27_iteration = 0;
            foreach (var __tmp81 in __loop27_results)
            {
                ++__loop27_iteration;
                var __loop27_var1 = __tmp81.__loop27_var1;
                var sup = __tmp81.sup;
                var Constructor = __tmp81.Constructor;
                var Initializers = __tmp81.Initializers;
                var init = __tmp81.init;
                if (init.Object != null && init.Property != null) //480:4
                {
                    string __tmp82Prefix = "    this.mLazySetChild("; //481:1
                    string __tmp83Suffix = ", true));"; //481:170
                    StringBuilder __tmp84 = new StringBuilder();
                    __tmp84.Append(init.Object.JavaFullDescriptorName());
                    using(StreamReader __tmp84Reader = new StreamReader(this.__ToStream(__tmp84.ToString())))
                    {
                        bool __tmp84_first = true;
                        while(__tmp84_first || !__tmp84Reader.EndOfStream)
                        {
                            __tmp84_first = false;
                            string __tmp84Line = __tmp84Reader.ReadLine();
                            if (__tmp84Line == null)
                            {
                                __tmp84Line = "";
                            }
                            __out.Append(__tmp82Prefix);
                            __out.Append(__tmp84Line);
                        }
                    }
                    string __tmp85Line = ", "; //481:62
                    __out.Append(__tmp85Line);
                    StringBuilder __tmp86 = new StringBuilder();
                    __tmp86.Append(init.Property.JavaFullDescriptorName());
                    using(StreamReader __tmp86Reader = new StreamReader(this.__ToStream(__tmp86.ToString())))
                    {
                        bool __tmp86_first = true;
                        while(__tmp86_first || !__tmp86Reader.EndOfStream)
                        {
                            __tmp86_first = false;
                            string __tmp86Line = __tmp86Reader.ReadLine();
                            if (__tmp86Line == null)
                            {
                                __tmp86Line = "";
                            }
                            __out.Append(__tmp86Line);
                        }
                    }
                    string __tmp87Line = ", metadslx.core.Lazy.create(() -> "; //481:104
                    __out.Append(__tmp87Line);
                    StringBuilder __tmp88 = new StringBuilder();
                    __tmp88.Append(GenerateExpression(init.Value));
                    using(StreamReader __tmp88Reader = new StreamReader(this.__ToStream(__tmp88.ToString())))
                    {
                        bool __tmp88_first = true;
                        while(__tmp88_first || !__tmp88Reader.EndOfStream)
                        {
                            __tmp88_first = false;
                            string __tmp88Line = __tmp88Reader.ReadLine();
                            if (__tmp88Line == null)
                            {
                                __tmp88Line = "";
                            }
                            __out.Append(__tmp88Line);
                            __out.Append(__tmp83Suffix);
                            __out.AppendLine(); //481:179
                        }
                    }
                }
            }
            string __tmp89Prefix = "    "; //484:1
            string __tmp90Suffix = "(this);"; //484:62
            StringBuilder __tmp91 = new StringBuilder();
            __tmp91.Append(cls.Model.JavaFullImplementationName());
            using(StreamReader __tmp91Reader = new StreamReader(this.__ToStream(__tmp91.ToString())))
            {
                bool __tmp91_first = true;
                while(__tmp91_first || !__tmp91Reader.EndOfStream)
                {
                    __tmp91_first = false;
                    string __tmp91Line = __tmp91Reader.ReadLine();
                    if (__tmp91Line == null)
                    {
                        __tmp91Line = "";
                    }
                    __out.Append(__tmp89Prefix);
                    __out.Append(__tmp91Line);
                }
            }
            string __tmp92Line = "."; //484:45
            __out.Append(__tmp92Line);
            StringBuilder __tmp93 = new StringBuilder();
            __tmp93.Append(cls.JavaName());
            using(StreamReader __tmp93Reader = new StreamReader(this.__ToStream(__tmp93.ToString())))
            {
                bool __tmp93_first = true;
                while(__tmp93_first || !__tmp93Reader.EndOfStream)
                {
                    __tmp93_first = false;
                    string __tmp93Line = __tmp93Reader.ReadLine();
                    if (__tmp93Line == null)
                    {
                        __tmp93Line = "";
                    }
                    __out.Append(__tmp93Line);
                    __out.Append(__tmp90Suffix);
                    __out.AppendLine(); //484:69
                }
            }
            var __loop28_results = 
                (from __loop28_var1 in __Enumerate((cls).GetEnumerator()) //485:11
                from prop in __Enumerate((__loop28_var1.GetAllProperties()).GetEnumerator()) //485:16
                select new { __loop28_var1 = __loop28_var1, prop = prop}
                ).ToList(); //485:6
            int __loop28_iteration = 0;
            foreach (var __tmp94 in __loop28_results)
            {
                ++__loop28_iteration;
                var __loop28_var1 = __tmp94.__loop28_var1;
                var prop = __tmp94.prop;
                if (prop.Kind == MetaPropertyKind.Readonly) //486:4
                {
                    string __tmp95Prefix = "    if (!this.mIsSet("; //487:1
                    string __tmp96Suffix = "().\");"; //487:211
                    StringBuilder __tmp97 = new StringBuilder();
                    __tmp97.Append(prop.JavaFullDescriptorName());
                    using(StreamReader __tmp97Reader = new StreamReader(this.__ToStream(__tmp97.ToString())))
                    {
                        bool __tmp97_first = true;
                        while(__tmp97_first || !__tmp97Reader.EndOfStream)
                        {
                            __tmp97_first = false;
                            string __tmp97Line = __tmp97Reader.ReadLine();
                            if (__tmp97Line == null)
                            {
                                __tmp97Line = "";
                            }
                            __out.Append(__tmp95Prefix);
                            __out.Append(__tmp97Line);
                        }
                    }
                    string __tmp98Line = ")) throw new ModelException(\"Readonly property "; //487:53
                    __out.Append(__tmp98Line);
                    StringBuilder __tmp99 = new StringBuilder();
                    __tmp99.Append(model.JavaName());
                    using(StreamReader __tmp99Reader = new StreamReader(this.__ToStream(__tmp99.ToString())))
                    {
                        bool __tmp99_first = true;
                        while(__tmp99_first || !__tmp99Reader.EndOfStream)
                        {
                            __tmp99_first = false;
                            string __tmp99Line = __tmp99Reader.ReadLine();
                            if (__tmp99Line == null)
                            {
                                __tmp99Line = "";
                            }
                            __out.Append(__tmp99Line);
                        }
                    }
                    string __tmp100Line = "."; //487:118
                    __out.Append(__tmp100Line);
                    StringBuilder __tmp101 = new StringBuilder();
                    __tmp101.Append(prop.Class.JavaName());
                    using(StreamReader __tmp101Reader = new StreamReader(this.__ToStream(__tmp101.ToString())))
                    {
                        bool __tmp101_first = true;
                        while(__tmp101_first || !__tmp101Reader.EndOfStream)
                        {
                            __tmp101_first = false;
                            string __tmp101Line = __tmp101Reader.ReadLine();
                            if (__tmp101Line == null)
                            {
                                __tmp101Line = "";
                            }
                            __out.Append(__tmp101Line);
                        }
                    }
                    string __tmp102Line = "."; //487:142
                    __out.Append(__tmp102Line);
                    StringBuilder __tmp103 = new StringBuilder();
                    __tmp103.Append(prop.Name);
                    using(StreamReader __tmp103Reader = new StreamReader(this.__ToStream(__tmp103.ToString())))
                    {
                        bool __tmp103_first = true;
                        while(__tmp103_first || !__tmp103Reader.EndOfStream)
                        {
                            __tmp103_first = false;
                            string __tmp103Line = __tmp103Reader.ReadLine();
                            if (__tmp103Line == null)
                            {
                                __tmp103Line = "";
                            }
                            __out.Append(__tmp103Line);
                        }
                    }
                    string __tmp104Line = "Property was not set in "; //487:154
                    __out.Append(__tmp104Line);
                    StringBuilder __tmp105 = new StringBuilder();
                    __tmp105.Append(cls.JavaName());
                    using(StreamReader __tmp105Reader = new StreamReader(this.__ToStream(__tmp105.ToString())))
                    {
                        bool __tmp105_first = true;
                        while(__tmp105_first || !__tmp105Reader.EndOfStream)
                        {
                            __tmp105_first = false;
                            string __tmp105Line = __tmp105Reader.ReadLine();
                            if (__tmp105Line == null)
                            {
                                __tmp105Line = "";
                            }
                            __out.Append(__tmp105Line);
                        }
                    }
                    string __tmp106Line = "_"; //487:194
                    __out.Append(__tmp106Line);
                    StringBuilder __tmp107 = new StringBuilder();
                    __tmp107.Append(cls.JavaName());
                    using(StreamReader __tmp107Reader = new StreamReader(this.__ToStream(__tmp107.ToString())))
                    {
                        bool __tmp107_first = true;
                        while(__tmp107_first || !__tmp107Reader.EndOfStream)
                        {
                            __tmp107_first = false;
                            string __tmp107Line = __tmp107Reader.ReadLine();
                            if (__tmp107Line == null)
                            {
                                __tmp107Line = "";
                            }
                            __out.Append(__tmp107Line);
                            __out.Append(__tmp96Suffix);
                            __out.AppendLine(); //487:217
                        }
                    }
                }
            }
            __out.Append("    this.mMakeDefault();"); //490:1
            __out.AppendLine(); //490:25
            __out.Append("}"); //491:1
            __out.AppendLine(); //491:2
            return __out.ToString();
        }

        public string GetReturn(MetaOperation op) //494:1
        {
            if (op.ReturnType.JavaName() == "void") //495:5
            {
                return ""; //496:3
            }
            else //497:2
            {
                return "return "; //498:3
            }
        }

        public string GenerateOperationImpl(MetaModel model, MetaOperation op, HashSet<string> generated) //502:1
        {
            StringBuilder __out = new StringBuilder();
            if (generated.Add(op.Name)) //503:2
            {
                __out.AppendLine(); //504:1
                string __tmp1Prefix = "public "; //505:1
                string __tmp2Suffix = ") {"; //505:95
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(op.ReturnType.JavaFullPublicName());
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_first = true;
                    while(__tmp3_first || !__tmp3Reader.EndOfStream)
                    {
                        __tmp3_first = false;
                        string __tmp3Line = __tmp3Reader.ReadLine();
                        if (__tmp3Line == null)
                        {
                            __tmp3Line = "";
                        }
                        __out.Append(__tmp1Prefix);
                        __out.Append(__tmp3Line);
                    }
                }
                string __tmp4Line = " "; //505:44
                __out.Append(__tmp4Line);
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(op.Name.ToCamelCase());
                using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                {
                    bool __tmp5_first = true;
                    while(__tmp5_first || !__tmp5Reader.EndOfStream)
                    {
                        __tmp5_first = false;
                        string __tmp5Line = __tmp5Reader.ReadLine();
                        if (__tmp5Line == null)
                        {
                            __tmp5Line = "";
                        }
                        __out.Append(__tmp5Line);
                    }
                }
                string __tmp6Line = "("; //505:68
                __out.Append(__tmp6Line);
                StringBuilder __tmp7 = new StringBuilder();
                __tmp7.Append(GetParameters(op, false));
                using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
                {
                    bool __tmp7_first = true;
                    while(__tmp7_first || !__tmp7Reader.EndOfStream)
                    {
                        __tmp7_first = false;
                        string __tmp7Line = __tmp7Reader.ReadLine();
                        if (__tmp7Line == null)
                        {
                            __tmp7Line = "";
                        }
                        __out.Append(__tmp7Line);
                        __out.Append(__tmp2Suffix);
                        __out.AppendLine(); //505:98
                    }
                }
                string __tmp8Prefix = "    "; //506:1
                string __tmp9Suffix = ");"; //506:135
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(GetReturn(op));
                using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
                {
                    bool __tmp10_first = true;
                    while(__tmp10_first || !__tmp10Reader.EndOfStream)
                    {
                        __tmp10_first = false;
                        string __tmp10Line = __tmp10Reader.ReadLine();
                        if (__tmp10Line == null)
                        {
                            __tmp10Line = "";
                        }
                        __out.Append(__tmp8Prefix);
                        __out.Append(__tmp10Line);
                    }
                }
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(model.JavaFullImplementationName());
                using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                {
                    bool __tmp11_first = true;
                    while(__tmp11_first || !__tmp11Reader.EndOfStream)
                    {
                        __tmp11_first = false;
                        string __tmp11Line = __tmp11Reader.ReadLine();
                        if (__tmp11Line == null)
                        {
                            __tmp11Line = "";
                        }
                        __out.Append(__tmp11Line);
                    }
                }
                string __tmp12Line = "."; //506:56
                __out.Append(__tmp12Line);
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(op.Parent.JavaName());
                using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                {
                    bool __tmp13_first = true;
                    while(__tmp13_first || !__tmp13Reader.EndOfStream)
                    {
                        __tmp13_first = false;
                        string __tmp13Line = __tmp13Reader.ReadLine();
                        if (__tmp13Line == null)
                        {
                            __tmp13Line = "";
                        }
                        __out.Append(__tmp13Line);
                    }
                }
                string __tmp14Line = "_"; //506:79
                __out.Append(__tmp14Line);
                StringBuilder __tmp15 = new StringBuilder();
                __tmp15.Append(op.Name.ToCamelCase());
                using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
                {
                    bool __tmp15_first = true;
                    while(__tmp15_first || !__tmp15Reader.EndOfStream)
                    {
                        __tmp15_first = false;
                        string __tmp15Line = __tmp15Reader.ReadLine();
                        if (__tmp15Line == null)
                        {
                            __tmp15Line = "";
                        }
                        __out.Append(__tmp15Line);
                    }
                }
                string __tmp16Line = "("; //506:103
                __out.Append(__tmp16Line);
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(GetImplCallParameterNames(op));
                using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
                {
                    bool __tmp17_first = true;
                    while(__tmp17_first || !__tmp17Reader.EndOfStream)
                    {
                        __tmp17_first = false;
                        string __tmp17Line = __tmp17Reader.ReadLine();
                        if (__tmp17Line == null)
                        {
                            __tmp17Line = "";
                        }
                        __out.Append(__tmp17Line);
                        __out.Append(__tmp9Suffix);
                        __out.AppendLine(); //506:137
                    }
                }
                __out.Append("}"); //507:1
                __out.AppendLine(); //507:2
            }
            return __out.ToString();
        }

        public string GetSuperClasses(MetaClass cls) //511:1
        {
            string result = ""; //512:2
            var __loop29_results = 
                (from __loop29_var1 in __Enumerate((cls).GetEnumerator()) //513:10
                from sup in __Enumerate((__loop29_var1.SuperClasses).GetEnumerator()) //513:15
                select new { __loop29_var1 = __loop29_var1, sup = sup}
                ).ToList(); //513:5
            int __loop29_iteration = 0;
            string delim = ""; //513:33
            foreach (var __tmp1 in __loop29_results)
            {
                ++__loop29_iteration;
                if (__loop29_iteration >= 2) //513:52
                {
                    delim = ", "; //513:52
                }
                var __loop29_var1 = __tmp1.__loop29_var1;
                var sup = __tmp1.sup;
                result += delim + sup.JavaFullName(); //514:3
            }
            return result; //516:2
        }

        public string GetAllSuperClasses(MetaClass cls) //519:1
        {
            string result = ""; //520:2
            var __loop30_results = 
                (from __loop30_var1 in __Enumerate((cls).GetEnumerator()) //521:10
                from sup in __Enumerate((__loop30_var1.GetAllSuperClasses(false)).GetEnumerator()) //521:15
                select new { __loop30_var1 = __loop30_var1, sup = sup}
                ).ToList(); //521:5
            int __loop30_iteration = 0;
            string delim = ""; //521:46
            foreach (var __tmp1 in __loop30_results)
            {
                ++__loop30_iteration;
                if (__loop30_iteration >= 2) //521:65
                {
                    delim = ", "; //521:65
                }
                var __loop30_var1 = __tmp1.__loop30_var1;
                var sup = __tmp1.sup;
                result += delim + sup.JavaFullName(); //522:3
            }
            return result; //524:2
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //527:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "package "; //528:1
            string __tmp2Suffix = ";"; //528:37
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.Namespace.JavaName());
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //528:38
                }
            }
            __out.AppendLine(); //529:1
            string __tmp4Prefix = "public final class "; //530:1
            string __tmp5Suffix = " {"; //530:48
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(model.JavaDescriptorName());
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                while(__tmp6_first || !__tmp6Reader.EndOfStream)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    if (__tmp6Line == null)
                    {
                        __tmp6Line = "";
                    }
                    __out.Append(__tmp4Prefix);
                    __out.Append(__tmp6Line);
                    __out.Append(__tmp5Suffix);
                    __out.AppendLine(); //530:50
                }
            }
            __out.Append("    static {"); //531:1
            __out.AppendLine(); //531:13
            var __loop31_results = 
                (from __loop31_var1 in __Enumerate((model).GetEnumerator()) //532:11
                from Namespace in __Enumerate((__loop31_var1.Namespace).GetEnumerator()) //532:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //532:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //532:43
                select new { __loop31_var1 = __loop31_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //532:6
            int __loop31_iteration = 0;
            foreach (var __tmp7 in __loop31_results)
            {
                ++__loop31_iteration;
                var __loop31_var1 = __tmp7.__loop31_var1;
                var Namespace = __tmp7.Namespace;
                var Declarations = __tmp7.Declarations;
                var cls = __tmp7.cls;
                string __tmp8Prefix = "        "; //533:1
                string __tmp9Suffix = ".staticInit();"; //533:25
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(cls.JavaName());
                using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
                {
                    bool __tmp10_first = true;
                    while(__tmp10_first || !__tmp10Reader.EndOfStream)
                    {
                        __tmp10_first = false;
                        string __tmp10Line = __tmp10Reader.ReadLine();
                        if (__tmp10Line == null)
                        {
                            __tmp10Line = "";
                        }
                        __out.Append(__tmp8Prefix);
                        __out.Append(__tmp10Line);
                        __out.Append(__tmp9Suffix);
                        __out.AppendLine(); //533:39
                    }
                }
            }
            __out.Append("    }"); //535:1
            __out.AppendLine(); //535:6
            __out.AppendLine(); //536:1
            __out.Append("    static void staticInit() {}"); //537:1
            __out.AppendLine(); //537:32
            __out.AppendLine(); //538:1
            string __tmp11Prefix = "	public static final String Uri = \""; //539:1
            string __tmp12Suffix = "\";"; //539:47
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(model.Uri);
            using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
            {
                bool __tmp13_first = true;
                while(__tmp13_first || !__tmp13Reader.EndOfStream)
                {
                    __tmp13_first = false;
                    string __tmp13Line = __tmp13Reader.ReadLine();
                    if (__tmp13Line == null)
                    {
                        __tmp13Line = "";
                    }
                    __out.Append(__tmp11Prefix);
                    __out.Append(__tmp13Line);
                    __out.Append(__tmp12Suffix);
                    __out.AppendLine(); //539:49
                }
            }
            __out.AppendLine(); //540:1
            var __loop32_results = 
                (from __loop32_var1 in __Enumerate((model).GetEnumerator()) //541:11
                from Namespace in __Enumerate((__loop32_var1.Namespace).GetEnumerator()) //541:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //541:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //541:43
                select new { __loop32_var1 = __loop32_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //541:6
            int __loop32_iteration = 0;
            foreach (var __tmp14 in __loop32_results)
            {
                ++__loop32_iteration;
                var __loop32_var1 = __tmp14.__loop32_var1;
                var Namespace = __tmp14.Namespace;
                var Declarations = __tmp14.Declarations;
                var cls = __tmp14.cls;
                string __tmp15Prefix = "    "; //542:1
                string __tmp16Suffix = string.Empty; 
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(GenerateMetaModelClass(cls));
                using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
                {
                    bool __tmp17_first = true;
                    while(__tmp17_first || !__tmp17Reader.EndOfStream)
                    {
                        __tmp17_first = false;
                        string __tmp17Line = __tmp17Reader.ReadLine();
                        if (__tmp17Line == null)
                        {
                            __tmp17Line = "";
                        }
                        __out.Append(__tmp15Prefix);
                        __out.Append(__tmp17Line);
                        __out.Append(__tmp16Suffix);
                        __out.AppendLine(); //542:34
                    }
                }
            }
            __out.Append("}"); //544:1
            __out.AppendLine(); //544:2
            __out.AppendLine(); //545:1
            return __out.ToString();
        }

        public string GenerateMetaModelClass(MetaClass cls) //549:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //550:1
            string __tmp1Prefix = "public static final class "; //551:1
            string __tmp2Suffix = " {"; //551:43
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.JavaName());
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //551:45
                }
            }
            __out.Append("    static void staticInit() {}"); //552:1
            __out.AppendLine(); //552:32
            __out.AppendLine(); //553:1
            __out.Append("    static {"); //554:1
            __out.AppendLine(); //554:13
            string __tmp4Prefix = "        "; //555:1
            string __tmp5Suffix = ".staticInit();"; //555:45
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(cls.Model.JavaFullDescriptorName());
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                while(__tmp6_first || !__tmp6Reader.EndOfStream)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    if (__tmp6Line == null)
                    {
                        __tmp6Line = "";
                    }
                    __out.Append(__tmp4Prefix);
                    __out.Append(__tmp6Line);
                    __out.Append(__tmp5Suffix);
                    __out.AppendLine(); //555:59
                }
            }
            __out.Append("    }"); //556:1
            __out.AppendLine(); //556:6
            __out.AppendLine(); //557:1
            __out.Append("    public static metadslx.core.MetaClass getMetaClass() {"); //558:1
            __out.AppendLine(); //558:59
            string __tmp7Prefix = "        return "; //559:1
            string __tmp8Suffix = "; "; //559:44
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(cls.JavaFullInstanceName());
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_first = true;
                while(__tmp9_first || !__tmp9Reader.EndOfStream)
                {
                    __tmp9_first = false;
                    string __tmp9Line = __tmp9Reader.ReadLine();
                    if (__tmp9Line == null)
                    {
                        __tmp9Line = "";
                    }
                    __out.Append(__tmp7Prefix);
                    __out.Append(__tmp9Line);
                    __out.Append(__tmp8Suffix);
                    __out.AppendLine(); //559:46
                }
            }
            __out.Append("    }"); //560:1
            __out.AppendLine(); //560:6
            __out.AppendLine(); //561:1
            var __loop33_results = 
                (from __loop33_var1 in __Enumerate((cls).GetEnumerator()) //562:11
                from prop in __Enumerate((__loop33_var1.Properties).GetEnumerator()) //562:16
                select new { __loop33_var1 = __loop33_var1, prop = prop}
                ).ToList(); //562:6
            int __loop33_iteration = 0;
            foreach (var __tmp10 in __loop33_results)
            {
                ++__loop33_iteration;
                var __loop33_var1 = __tmp10.__loop33_var1;
                var prop = __tmp10.prop;
                string __tmp11Prefix = "    "; //563:1
                string __tmp12Suffix = string.Empty; 
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(GeneratePropertyDeclaration(cls.Model, cls, prop));
                using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                {
                    bool __tmp13_first = true;
                    while(__tmp13_first || !__tmp13Reader.EndOfStream)
                    {
                        __tmp13_first = false;
                        string __tmp13Line = __tmp13Reader.ReadLine();
                        if (__tmp13Line == null)
                        {
                            __tmp13Line = "";
                        }
                        __out.Append(__tmp11Prefix);
                        __out.Append(__tmp13Line);
                        __out.Append(__tmp12Suffix);
                        __out.AppendLine(); //563:56
                    }
                }
            }
            __out.Append("}"); //565:1
            __out.AppendLine(); //565:2
            return __out.ToString();
        }

        public string GenerateModelConstant(MetaModel model, MetaConstant mconst) //569:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public static final "; //570:1
            string __tmp2Suffix = ";"; //570:63
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(mconst.Type.JavaFullName());
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                }
            }
            string __tmp4Line = " "; //570:49
            __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(mconst.Name);
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_first = true;
                while(__tmp5_first || !__tmp5Reader.EndOfStream)
                {
                    __tmp5_first = false;
                    string __tmp5Line = __tmp5Reader.ReadLine();
                    if (__tmp5Line == null)
                    {
                        __tmp5Line = "";
                    }
                    __out.Append(__tmp5Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //570:64
                }
            }
            return __out.ToString();
        }

        public string GenerateModelFunction(MetaModel model, MetaGlobalFunction mfunc) //573:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public static final "; //574:1
            string __tmp2Suffix = ";"; //574:82
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(MetaInstance.MetaGlobalFunction.JavaFullName());
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                }
            }
            string __tmp4Line = " "; //574:69
            __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(mfunc.Name);
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_first = true;
                while(__tmp5_first || !__tmp5Reader.EndOfStream)
                {
                    __tmp5_first = false;
                    string __tmp5Line = __tmp5Reader.ReadLine();
                    if (__tmp5Line == null)
                    {
                        __tmp5Line = "";
                    }
                    __out.Append(__tmp5Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //574:83
                }
            }
            return __out.ToString();
        }

        public string GenerateModelConstantImpl(MetaModel model, MetaConstant mconst, Dictionary<ModelObject,string> mobjToTmp) //577:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = ";"; //578:51
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(mconst.Name);
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                }
            }
            string __tmp4Line = " = "; //578:14
            __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(GenerateExpression(mconst.Value));
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_first = true;
                while(__tmp5_first || !__tmp5Reader.EndOfStream)
                {
                    __tmp5_first = false;
                    string __tmp5Line = __tmp5Reader.ReadLine();
                    if (__tmp5Line == null)
                    {
                        __tmp5Line = "";
                    }
                    __out.Append(__tmp5Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //578:52
                }
            }
            return __out.ToString();
        }

        public string GenerateModelFunctionImpl(MetaModel model, MetaGlobalFunction mfunc, Dictionary<ModelObject,string> mobjToTmp) //581:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = "();"; //582:129
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(RegisterModelObject((ModelObject)mfunc, mobjToTmp, mfunc.Name));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                }
            }
            string __tmp4Line = " = "; //582:65
            __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(MetaInstance.MetaGlobalFunction.JavaFullFactoryMethodName());
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_first = true;
                while(__tmp5_first || !__tmp5Reader.EndOfStream)
                {
                    __tmp5_first = false;
                    string __tmp5Line = __tmp5Reader.ReadLine();
                    if (__tmp5Line == null)
                    {
                        __tmp5Line = "";
                    }
                    __out.Append(__tmp5Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //582:132
                }
            }
            return __out.ToString();
        }

        public string GenerateMetaModelInstance(MetaModel model) //586:1
        {
            StringBuilder __out = new StringBuilder();
            Dictionary<ModelObject,string> mobjToTmp = new Dictionary<ModelObject,string>(); //587:2
            string __tmp1Prefix = "package "; //588:1
            string __tmp2Suffix = ";"; //588:37
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.Namespace.JavaName());
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //588:38
                }
            }
            __out.AppendLine(); //589:1
            string __tmp4Prefix = "public final class "; //590:1
            string __tmp5Suffix = " {"; //590:47
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(model.JavaInstancesName());
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                while(__tmp6_first || !__tmp6Reader.EndOfStream)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    if (__tmp6Line == null)
                    {
                        __tmp6Line = "";
                    }
                    __out.Append(__tmp4Prefix);
                    __out.Append(__tmp6Line);
                    __out.Append(__tmp5Suffix);
                    __out.AppendLine(); //590:49
                }
            }
            __out.Append("    private static metadslx.core.Model model;"); //591:1
            __out.AppendLine(); //591:46
            __out.AppendLine(); //592:1
            __out.Append("    public static metadslx.core.Model model() {"); //593:1
            __out.AppendLine(); //593:48
            string __tmp7Prefix = "        return "; //594:1
            string __tmp8Suffix = "Instance.model;"; //594:28
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(model.Name);
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_first = true;
                while(__tmp9_first || !__tmp9Reader.EndOfStream)
                {
                    __tmp9_first = false;
                    string __tmp9Line = __tmp9Reader.ReadLine();
                    if (__tmp9Line == null)
                    {
                        __tmp9Line = "";
                    }
                    __out.Append(__tmp7Prefix);
                    __out.Append(__tmp9Line);
                    __out.Append(__tmp8Suffix);
                    __out.AppendLine(); //594:43
                }
            }
            __out.Append("    }"); //595:1
            __out.AppendLine(); //595:6
            __out.AppendLine(); //596:1
            __out.Append("    public static final metadslx.core.MetaModel Meta;"); //597:1
            __out.AppendLine(); //597:54
            __out.AppendLine(); //598:1
            var __loop34_results = 
                (from __loop34_var1 in __Enumerate((model).GetEnumerator()) //599:11
                from Namespace in __Enumerate((__loop34_var1.Namespace).GetEnumerator()) //599:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //599:29
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //599:43
                select new { __loop34_var1 = __loop34_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //599:6
            int __loop34_iteration = 0;
            foreach (var __tmp10 in __loop34_results)
            {
                ++__loop34_iteration;
                var __loop34_var1 = __tmp10.__loop34_var1;
                var Namespace = __tmp10.Namespace;
                var Declarations = __tmp10.Declarations;
                var c = __tmp10.c;
                string __tmp11Prefix = "    "; //600:1
                string __tmp12Suffix = string.Empty; 
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(GenerateModelConstant(model, c));
                using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                {
                    bool __tmp13_first = true;
                    while(__tmp13_first || !__tmp13Reader.EndOfStream)
                    {
                        __tmp13_first = false;
                        string __tmp13Line = __tmp13Reader.ReadLine();
                        if (__tmp13Line == null)
                        {
                            __tmp13Line = "";
                        }
                        __out.Append(__tmp11Prefix);
                        __out.Append(__tmp13Line);
                        __out.Append(__tmp12Suffix);
                        __out.AppendLine(); //600:38
                    }
                }
            }
            __out.AppendLine(); //602:1
            string __tmp14Prefix = "	"; //603:1
            string __tmp15Suffix = string.Empty; 
            StringBuilder __tmp16 = new StringBuilder();
            __tmp16.Append(GenerateModelObjectInstanceDeclaration(((ModelObject)model).GetRootNamespace(), mobjToTmp));
            using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
            {
                bool __tmp16_first = true;
                while(__tmp16_first || !__tmp16Reader.EndOfStream)
                {
                    __tmp16_first = false;
                    string __tmp16Line = __tmp16Reader.ReadLine();
                    if (__tmp16Line == null)
                    {
                        __tmp16Line = "";
                    }
                    __out.Append(__tmp14Prefix);
                    __out.Append(__tmp16Line);
                    __out.Append(__tmp15Suffix);
                    __out.AppendLine(); //603:94
                }
            }
            __out.AppendLine(); //604:1
            __out.Append("    static {"); //605:1
            __out.AppendLine(); //605:13
            string __tmp17Prefix = "		"; //606:1
            string __tmp18Suffix = ".staticInit();"; //606:31
            StringBuilder __tmp19 = new StringBuilder();
            __tmp19.Append(model.JavaDescriptorName());
            using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
            {
                bool __tmp19_first = true;
                while(__tmp19_first || !__tmp19Reader.EndOfStream)
                {
                    __tmp19_first = false;
                    string __tmp19Line = __tmp19Reader.ReadLine();
                    if (__tmp19Line == null)
                    {
                        __tmp19Line = "";
                    }
                    __out.Append(__tmp17Prefix);
                    __out.Append(__tmp19Line);
                    __out.Append(__tmp18Suffix);
                    __out.AppendLine(); //606:45
                }
            }
            string __tmp20Prefix = "		"; //607:1
            string __tmp21Suffix = ".model = new metadslx.core.Model();"; //607:30
            StringBuilder __tmp22 = new StringBuilder();
            __tmp22.Append(model.JavaInstancesName());
            using(StreamReader __tmp22Reader = new StreamReader(this.__ToStream(__tmp22.ToString())))
            {
                bool __tmp22_first = true;
                while(__tmp22_first || !__tmp22Reader.EndOfStream)
                {
                    __tmp22_first = false;
                    string __tmp22Line = __tmp22Reader.ReadLine();
                    if (__tmp22Line == null)
                    {
                        __tmp22Line = "";
                    }
                    __out.Append(__tmp20Prefix);
                    __out.Append(__tmp22Line);
                    __out.Append(__tmp21Suffix);
                    __out.AppendLine(); //607:65
                }
            }
            string __tmp23Prefix = "   		try (metadslx.core.ModelContextScope _scope = new metadslx.core.ModelContextScope("; //608:1
            string __tmp24Suffix = ".model)) {"; //608:115
            StringBuilder __tmp25 = new StringBuilder();
            __tmp25.Append(model.JavaInstancesName());
            using(StreamReader __tmp25Reader = new StreamReader(this.__ToStream(__tmp25.ToString())))
            {
                bool __tmp25_first = true;
                while(__tmp25_first || !__tmp25Reader.EndOfStream)
                {
                    __tmp25_first = false;
                    string __tmp25Line = __tmp25Reader.ReadLine();
                    if (__tmp25Line == null)
                    {
                        __tmp25Line = "";
                    }
                    __out.Append(__tmp23Prefix);
                    __out.Append(__tmp25Line);
                    __out.Append(__tmp24Suffix);
                    __out.AppendLine(); //608:125
                }
            }
            var __loop35_results = 
                (from __loop35_var1 in __Enumerate((model).GetEnumerator()) //609:13
                from Namespace in __Enumerate((__loop35_var1.Namespace).GetEnumerator()) //609:20
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //609:31
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //609:45
                select new { __loop35_var1 = __loop35_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //609:8
            int __loop35_iteration = 0;
            foreach (var __tmp26 in __loop35_results)
            {
                ++__loop35_iteration;
                var __loop35_var1 = __tmp26.__loop35_var1;
                var Namespace = __tmp26.Namespace;
                var Declarations = __tmp26.Declarations;
                var c = __tmp26.c;
                string __tmp27Prefix = "            "; //610:1
                string __tmp28Suffix = string.Empty; 
                StringBuilder __tmp29 = new StringBuilder();
                __tmp29.Append(GenerateModelConstantImpl(model, c, mobjToTmp));
                using(StreamReader __tmp29Reader = new StreamReader(this.__ToStream(__tmp29.ToString())))
                {
                    bool __tmp29_first = true;
                    while(__tmp29_first || !__tmp29Reader.EndOfStream)
                    {
                        __tmp29_first = false;
                        string __tmp29Line = __tmp29Reader.ReadLine();
                        if (__tmp29Line == null)
                        {
                            __tmp29Line = "";
                        }
                        __out.Append(__tmp27Prefix);
                        __out.Append(__tmp29Line);
                        __out.Append(__tmp28Suffix);
                        __out.AppendLine(); //610:61
                    }
                }
            }
            __out.AppendLine(); //612:1
            string __tmp30Prefix = "			"; //613:1
            string __tmp31Suffix = string.Empty; 
            StringBuilder __tmp32 = new StringBuilder();
            __tmp32.Append(GenerateModelObjectInstance(((ModelObject)model).GetRootNamespace(), mobjToTmp));
            using(StreamReader __tmp32Reader = new StreamReader(this.__ToStream(__tmp32.ToString())))
            {
                bool __tmp32_first = true;
                while(__tmp32_first || !__tmp32Reader.EndOfStream)
                {
                    __tmp32_first = false;
                    string __tmp32Line = __tmp32Reader.ReadLine();
                    if (__tmp32Line == null)
                    {
                        __tmp32Line = "";
                    }
                    __out.Append(__tmp30Prefix);
                    __out.Append(__tmp32Line);
                    __out.Append(__tmp31Suffix);
                    __out.AppendLine(); //613:85
                }
            }
            __out.AppendLine(); //614:1
            __out.Append("			initializeInstances();"); //615:1
            __out.AppendLine(); //615:26
            __out.AppendLine(); //616:1
            __out.Append("            for (ModelObject mo: metadslx.core.ModelContext.current().instances()) {"); //617:1
            __out.AppendLine(); //617:85
            __out.Append("                mo.mEvalLazyValues();"); //618:1
            __out.AppendLine(); //618:38
            __out.Append("            }"); //619:1
            __out.AppendLine(); //619:14
            __out.Append("		}"); //620:1
            __out.AppendLine(); //620:4
            __out.Append("    }"); //621:1
            __out.AppendLine(); //621:6
            __out.AppendLine(); //622:1
            __out.Append("	private static void initializeInstances() {"); //623:1
            __out.AppendLine(); //623:45
            string __tmp33Prefix = "		"; //624:1
            string __tmp34Suffix = string.Empty; 
            StringBuilder __tmp35 = new StringBuilder();
            __tmp35.Append(GenerateModelObjectInstanceInitializer(((ModelObject)model).GetRootNamespace(), mobjToTmp));
            using(StreamReader __tmp35Reader = new StreamReader(this.__ToStream(__tmp35.ToString())))
            {
                bool __tmp35_first = true;
                while(__tmp35_first || !__tmp35Reader.EndOfStream)
                {
                    __tmp35_first = false;
                    string __tmp35Line = __tmp35Reader.ReadLine();
                    if (__tmp35Line == null)
                    {
                        __tmp35Line = "";
                    }
                    __out.Append(__tmp33Prefix);
                    __out.Append(__tmp35Line);
                    __out.Append(__tmp34Suffix);
                    __out.AppendLine(); //624:95
                }
            }
            __out.Append("	}"); //625:1
            __out.AppendLine(); //625:3
            __out.Append("}"); //626:1
            __out.AppendLine(); //626:2
            return __out.ToString();
        }

        public string RegisterModelObject(ModelObject mobj, Dictionary<ModelObject,string> mobjToTmp, string name) //629:1
        {
            if (!mobjToTmp.ContainsKey(mobj)) //630:2
            {
                string tmpName = name; //631:3
                mobjToTmp.Add(mobj, tmpName); //632:3
                return tmpName; //633:3
            }
            else //634:2
            {
                return mobjToTmp[mobj]; //635:3
            }
        }

        public bool HasBuiltInName(ModelObject mobj) //639:1
        {
            MetaAnnotatedElement mannot = mobj as MetaAnnotatedElement; //640:2
            if (mannot != null && !(mobj is MetaConstant)) //641:2
            {
                var __loop36_results = 
                    (from __loop36_var1 in __Enumerate((mannot).GetEnumerator()) //642:8
                    from a in __Enumerate((__loop36_var1.Annotations).GetEnumerator()) //642:16
                    from p in __Enumerate((a.Properties).GetEnumerator()) //642:31
                    where a.Name == "BuiltInName" && p.Name == "Name" //642:44
                    select new { __loop36_var1 = __loop36_var1, a = a, p = p}
                    ).ToList(); //642:3
                int __loop36_iteration = 0;
                foreach (var __tmp1 in __loop36_results)
                {
                    ++__loop36_iteration;
                    var __loop36_var1 = __tmp1.__loop36_var1;
                    var a = __tmp1.a;
                    var p = __tmp1.p;
                    return true; //643:4
                }
            }
            MetaDeclaration mdecl = mobj as MetaDeclaration; //646:2
            if (mdecl != null && !(mdecl is MetaOperation) && !(mdecl is MetaConstant)) //647:2
            {
                return true; //648:3
            }
            return false; //650:2
        }

        public string GetInstanceName(ModelObject mobj) //653:1
        {
            MetaAnnotatedElement mannot = mobj as MetaAnnotatedElement; //654:2
            if (mannot != null && !(mobj is MetaConstant)) //655:2
            {
                var __loop37_results = 
                    (from __loop37_var1 in __Enumerate((mannot).GetEnumerator()) //656:8
                    from a in __Enumerate((__loop37_var1.Annotations).GetEnumerator()) //656:16
                    from p in __Enumerate((a.Properties).GetEnumerator()) //656:31
                    where a.Name == "BuiltInName" && p.Name == "Name" //656:44
                    select new { __loop37_var1 = __loop37_var1, a = a, p = p}
                    ).ToList(); //656:3
                int __loop37_iteration = 0;
                foreach (var __tmp1 in __loop37_results)
                {
                    ++__loop37_iteration;
                    var __loop37_var1 = __tmp1.__loop37_var1;
                    var a = __tmp1.a;
                    var p = __tmp1.p;
                    return GetJavaIdentifier(p.Value); //657:4
                }
            }
            MetaDeclaration mdecl = mobj as MetaDeclaration; //660:2
            if (mdecl != null && !(mdecl is MetaOperation) && !(mobj is MetaConstant)) //661:2
            {
                return mdecl.JavaInstanceName(); //662:3
            }
            MetaProperty mprop = mobj as MetaProperty; //664:2
            if (mprop != null) //665:2
            {
                return mprop.JavaInstanceName(); //666:3
            }
            return null; //668:2
        }

        public string RegisterModelObject(ModelObject mobj, Dictionary<ModelObject,string> mobjToTmp) //671:1
        {
            if (!mobjToTmp.ContainsKey(mobj)) //672:2
            {
                string name = GetInstanceName(mobj); //673:3
                if (name == null) //674:3
                {
                    name = "tmp" + NextCounter(); //675:4
                }
                mobjToTmp.Add(mobj, name); //677:3
                return name; //678:3
            }
            else //679:2
            {
                return null; //680:3
            }
        }

        public string GenerateModelObjectInstanceDeclaration(ModelObject mobj, Dictionary<ModelObject,string> mobjToTmp) //684:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //685:2
            {
                if (!Instances.Contains(mobj)) //686:3
                {
                }
                else //687:3
                {
                    if (true) //688:4
                    {
                        string tmpName = RegisterModelObject(mobj, mobjToTmp); //689:5
                        if (tmpName != null) //690:5
                        {
                            if (tmpName.StartsWith("tmp")) //691:6
                            {
                                string __tmp1Prefix = "private static final metadslx.core."; //692:1
                                string __tmp2Suffix = ";"; //692:74
                                StringBuilder __tmp3 = new StringBuilder();
                                __tmp3.Append(mobj.MMetaClass.JavaName());
                                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                                {
                                    bool __tmp3_first = true;
                                    while(__tmp3_first || !__tmp3Reader.EndOfStream)
                                    {
                                        __tmp3_first = false;
                                        string __tmp3Line = __tmp3Reader.ReadLine();
                                        if (__tmp3Line == null)
                                        {
                                            __tmp3Line = "";
                                        }
                                        __out.Append(__tmp1Prefix);
                                        __out.Append(__tmp3Line);
                                    }
                                }
                                string __tmp4Line = " "; //692:64
                                __out.Append(__tmp4Line);
                                StringBuilder __tmp5 = new StringBuilder();
                                __tmp5.Append(tmpName);
                                using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                                {
                                    bool __tmp5_first = true;
                                    while(__tmp5_first || !__tmp5Reader.EndOfStream)
                                    {
                                        __tmp5_first = false;
                                        string __tmp5Line = __tmp5Reader.ReadLine();
                                        if (__tmp5Line == null)
                                        {
                                            __tmp5Line = "";
                                        }
                                        __out.Append(__tmp5Line);
                                        __out.Append(__tmp2Suffix);
                                        __out.AppendLine(); //692:75
                                    }
                                }
                            }
                            else //693:6
                            {
                                string __tmp6Prefix = "public static final metadslx.core."; //694:1
                                string __tmp7Suffix = ";"; //694:73
                                StringBuilder __tmp8 = new StringBuilder();
                                __tmp8.Append(mobj.MMetaClass.JavaName());
                                using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                                {
                                    bool __tmp8_first = true;
                                    while(__tmp8_first || !__tmp8Reader.EndOfStream)
                                    {
                                        __tmp8_first = false;
                                        string __tmp8Line = __tmp8Reader.ReadLine();
                                        if (__tmp8Line == null)
                                        {
                                            __tmp8Line = "";
                                        }
                                        __out.Append(__tmp6Prefix);
                                        __out.Append(__tmp8Line);
                                    }
                                }
                                string __tmp9Line = " "; //694:63
                                __out.Append(__tmp9Line);
                                StringBuilder __tmp10 = new StringBuilder();
                                __tmp10.Append(tmpName);
                                using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
                                {
                                    bool __tmp10_first = true;
                                    while(__tmp10_first || !__tmp10Reader.EndOfStream)
                                    {
                                        __tmp10_first = false;
                                        string __tmp10Line = __tmp10Reader.ReadLine();
                                        if (__tmp10Line == null)
                                        {
                                            __tmp10Line = "";
                                        }
                                        __out.Append(__tmp10Line);
                                        __out.Append(__tmp7Suffix);
                                        __out.AppendLine(); //694:74
                                    }
                                }
                            }
                        }
                    }
                    var __loop38_results = 
                        (from __loop38_var1 in __Enumerate((mobj).GetEnumerator()) //698:9
                        from prop in __Enumerate((__loop38_var1.MGetAllProperties()).GetEnumerator()) //698:15
                        select new { __loop38_var1 = __loop38_var1, prop = prop}
                        ).ToList(); //698:4
                    int __loop38_iteration = 0;
                    foreach (var __tmp11 in __loop38_results)
                    {
                        ++__loop38_iteration;
                        var __loop38_var1 = __tmp11.__loop38_var1;
                        var prop = __tmp11.prop;
                        if (prop.MetaProperty != null && prop.MetaProperty.Kind != MetaPropertyKind.Derived) //699:5
                        {
                            object propValue = mobj.MGet(prop); //700:6
                            string __tmp12Prefix = string.Empty;
                            string __tmp13Suffix = string.Empty;
                            StringBuilder __tmp14 = new StringBuilder();
                            __tmp14.Append(GenerateModelObjectPropertyValueDeclaration(mobj, prop, propValue, mobjToTmp));
                            using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
                            {
                                bool __tmp14_first = true;
                                while(__tmp14_first || !__tmp14Reader.EndOfStream)
                                {
                                    __tmp14_first = false;
                                    string __tmp14Line = __tmp14Reader.ReadLine();
                                    if (__tmp14Line == null)
                                    {
                                        __tmp14Line = "";
                                    }
                                    __out.Append(__tmp12Prefix);
                                    __out.Append(__tmp14Line);
                                    __out.Append(__tmp13Suffix);
                                    __out.AppendLine(); //701:80
                                }
                            }
                        }
                    }
                    var __loop39_results = 
                        (from __loop39_var1 in __Enumerate((mobj).GetEnumerator()) //704:9
                        from child in __Enumerate((__loop39_var1.MChildren).GetEnumerator()) //704:15
                        select new { __loop39_var1 = __loop39_var1, child = child}
                        ).ToList(); //704:4
                    int __loop39_iteration = 0;
                    foreach (var __tmp15 in __loop39_results)
                    {
                        ++__loop39_iteration;
                        var __loop39_var1 = __tmp15.__loop39_var1;
                        var child = __tmp15.child;
                        string __tmp16Prefix = string.Empty;
                        string __tmp17Suffix = string.Empty;
                        StringBuilder __tmp18 = new StringBuilder();
                        __tmp18.Append(GenerateModelObjectInstanceDeclaration(child, mobjToTmp));
                        using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
                        {
                            bool __tmp18_first = true;
                            while(__tmp18_first || !__tmp18Reader.EndOfStream)
                            {
                                __tmp18_first = false;
                                string __tmp18Line = __tmp18Reader.ReadLine();
                                if (__tmp18Line == null)
                                {
                                    __tmp18Line = "";
                                }
                                __out.Append(__tmp16Prefix);
                                __out.Append(__tmp18Line);
                                __out.Append(__tmp17Suffix);
                                __out.AppendLine(); //705:59
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstance(ModelObject mobj, Dictionary<ModelObject,string> mobjToTmp) //711:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //712:2
            {
                if (!Instances.Contains(mobj)) //713:3
                {
                    string metaClassName = mobj.MMetaClass.Name; //714:4
                    if (mobj is MetaDeclaration || mobj is MetaProperty) //715:4
                    {
                        if (mobj is MetaProperty) //716:5
                        {
                            string tmpName = RegisterModelObject(mobj, mobjToTmp, ((MetaProperty)mobj).JavaInstanceName()); //717:2
                        }
                        else //718:5
                        {
                            string tmpName = RegisterModelObject(mobj, mobjToTmp, ((MetaDeclaration)mobj).JavaInstanceName()); //719:2
                        }
                    }
                    else //721:4
                    {
                        string __tmp1Prefix = "// OMITTED: "; //722:1
                        string __tmp2Suffix = string.Empty; 
                        StringBuilder __tmp3 = new StringBuilder();
                        __tmp3.Append(metaClassName);
                        using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                        {
                            bool __tmp3_first = true;
                            while(__tmp3_first || !__tmp3Reader.EndOfStream)
                            {
                                __tmp3_first = false;
                                string __tmp3Line = __tmp3Reader.ReadLine();
                                if (__tmp3Line == null)
                                {
                                    __tmp3Line = "";
                                }
                                __out.Append(__tmp1Prefix);
                                __out.Append(__tmp3Line);
                                __out.Append(__tmp2Suffix);
                                __out.AppendLine(); //722:28
                            }
                        }
                    }
                }
                else //724:3
                {
                    string tmpName = null; //725:4
                    if (mobjToTmp.ContainsKey(mobj)) //726:4
                    {
                        tmpName = mobjToTmp[mobj];
                    }
                    else //728:4
                    {
                        tmpName = RegisterModelObject(mobj, mobjToTmp);
                        string __tmp4Prefix = "metadslx.core."; //730:1
                        string __tmp5Suffix = " "; //730:43
                        StringBuilder __tmp6 = new StringBuilder();
                        __tmp6.Append(mobj.MMetaClass.JavaName());
                        using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
                        {
                            bool __tmp6_first = true;
                            while(__tmp6_first || !__tmp6Reader.EndOfStream)
                            {
                                __tmp6_first = false;
                                string __tmp6Line = __tmp6Reader.ReadLine();
                                if (__tmp6Line == null)
                                {
                                    __tmp6Line = "";
                                }
                                __out.Append(__tmp4Prefix);
                                __out.Append(__tmp6Line);
                                __out.Append(__tmp5Suffix);
                            }
                        }
                    }
                    if (tmpName != null) //732:4
                    {
                        if (tmpName.StartsWith("tmp")) //733:5
                        {
                            string __tmp7Prefix = string.Empty; 
                            string __tmp8Suffix = "();"; //734:84
                            StringBuilder __tmp9 = new StringBuilder();
                            __tmp9.Append(tmpName);
                            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                            {
                                bool __tmp9_first = true;
                                while(__tmp9_first || !__tmp9Reader.EndOfStream)
                                {
                                    __tmp9_first = false;
                                    string __tmp9Line = __tmp9Reader.ReadLine();
                                    if (__tmp9Line == null)
                                    {
                                        __tmp9Line = "";
                                    }
                                    __out.Append(__tmp7Prefix);
                                    __out.Append(__tmp9Line);
                                }
                            }
                            string __tmp10Line = " = metadslx.core.MetaFactory.instance().create"; //734:10
                            __out.Append(__tmp10Line);
                            StringBuilder __tmp11 = new StringBuilder();
                            __tmp11.Append(mobj.MMetaClass.JavaName());
                            using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                            {
                                bool __tmp11_first = true;
                                while(__tmp11_first || !__tmp11Reader.EndOfStream)
                                {
                                    __tmp11_first = false;
                                    string __tmp11Line = __tmp11Reader.ReadLine();
                                    if (__tmp11Line == null)
                                    {
                                        __tmp11Line = "";
                                    }
                                    __out.Append(__tmp11Line);
                                    __out.Append(__tmp8Suffix);
                                    __out.AppendLine(); //734:87
                                }
                            }
                        }
                        else //735:5
                        {
                            string __tmp12Prefix = string.Empty; 
                            string __tmp13Suffix = "();"; //736:84
                            StringBuilder __tmp14 = new StringBuilder();
                            __tmp14.Append(tmpName);
                            using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
                            {
                                bool __tmp14_first = true;
                                while(__tmp14_first || !__tmp14Reader.EndOfStream)
                                {
                                    __tmp14_first = false;
                                    string __tmp14Line = __tmp14Reader.ReadLine();
                                    if (__tmp14Line == null)
                                    {
                                        __tmp14Line = "";
                                    }
                                    __out.Append(__tmp12Prefix);
                                    __out.Append(__tmp14Line);
                                }
                            }
                            string __tmp15Line = " = metadslx.core.MetaFactory.instance().create"; //736:10
                            __out.Append(__tmp15Line);
                            StringBuilder __tmp16 = new StringBuilder();
                            __tmp16.Append(mobj.MMetaClass.JavaName());
                            using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
                            {
                                bool __tmp16_first = true;
                                while(__tmp16_first || !__tmp16Reader.EndOfStream)
                                {
                                    __tmp16_first = false;
                                    string __tmp16Line = __tmp16Reader.ReadLine();
                                    if (__tmp16Line == null)
                                    {
                                        __tmp16Line = "";
                                    }
                                    __out.Append(__tmp16Line);
                                    __out.Append(__tmp13Suffix);
                                    __out.AppendLine(); //736:87
                                }
                            }
                        }
                        if (mobj is MetaModel) //738:5
                        {
                            string __tmp17Prefix = "Meta = "; //739:1
                            string __tmp18Suffix = ";"; //739:17
                            StringBuilder __tmp19 = new StringBuilder();
                            __tmp19.Append(tmpName);
                            using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
                            {
                                bool __tmp19_first = true;
                                while(__tmp19_first || !__tmp19Reader.EndOfStream)
                                {
                                    __tmp19_first = false;
                                    string __tmp19Line = __tmp19Reader.ReadLine();
                                    if (__tmp19Line == null)
                                    {
                                        __tmp19Line = "";
                                    }
                                    __out.Append(__tmp17Prefix);
                                    __out.Append(__tmp19Line);
                                    __out.Append(__tmp18Suffix);
                                    __out.AppendLine(); //739:18
                                }
                            }
                        }
                        var __loop40_results = 
                            (from __loop40_var1 in __Enumerate((mobj).GetEnumerator()) //741:10
                            from prop in __Enumerate((__loop40_var1.MGetAllProperties()).GetEnumerator()) //741:16
                            select new { __loop40_var1 = __loop40_var1, prop = prop}
                            ).ToList(); //741:5
                        int __loop40_iteration = 0;
                        foreach (var __tmp20 in __loop40_results)
                        {
                            ++__loop40_iteration;
                            var __loop40_var1 = __tmp20.__loop40_var1;
                            var prop = __tmp20.prop;
                            if (prop.MetaProperty != null && prop.MetaProperty.Kind != MetaPropertyKind.Derived) //742:6
                            {
                                object propValue = mobj.MGet(prop); //743:7
                                string __tmp21Prefix = string.Empty;
                                string __tmp22Suffix = string.Empty;
                                StringBuilder __tmp23 = new StringBuilder();
                                __tmp23.Append(GenerateModelObjectPropertyValueInstance(mobj, prop, propValue, mobjToTmp));
                                using(StreamReader __tmp23Reader = new StreamReader(this.__ToStream(__tmp23.ToString())))
                                {
                                    bool __tmp23_first = true;
                                    while(__tmp23_first || !__tmp23Reader.EndOfStream)
                                    {
                                        __tmp23_first = false;
                                        string __tmp23Line = __tmp23Reader.ReadLine();
                                        if (__tmp23Line == null)
                                        {
                                            __tmp23Line = "";
                                        }
                                        __out.Append(__tmp21Prefix);
                                        __out.Append(__tmp23Line);
                                        __out.Append(__tmp22Suffix);
                                        __out.AppendLine(); //744:77
                                    }
                                }
                            }
                        }
                        var __loop41_results = 
                            (from __loop41_var1 in __Enumerate((mobj).GetEnumerator()) //747:10
                            from child in __Enumerate((__loop41_var1.MChildren).GetEnumerator()) //747:16
                            select new { __loop41_var1 = __loop41_var1, child = child}
                            ).ToList(); //747:5
                        int __loop41_iteration = 0;
                        foreach (var __tmp24 in __loop41_results)
                        {
                            ++__loop41_iteration;
                            var __loop41_var1 = __tmp24.__loop41_var1;
                            var child = __tmp24.child;
                            string __tmp25Prefix = string.Empty;
                            string __tmp26Suffix = string.Empty;
                            StringBuilder __tmp27 = new StringBuilder();
                            __tmp27.Append(GenerateModelObjectInstance(child, mobjToTmp));
                            using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
                            {
                                bool __tmp27_first = true;
                                while(__tmp27_first || !__tmp27Reader.EndOfStream)
                                {
                                    __tmp27_first = false;
                                    string __tmp27Line = __tmp27Reader.ReadLine();
                                    if (__tmp27Line == null)
                                    {
                                        __tmp27Line = "";
                                    }
                                    __out.Append(__tmp25Prefix);
                                    __out.Append(__tmp27Line);
                                    __out.Append(__tmp26Suffix);
                                    __out.AppendLine(); //748:48
                                }
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceInitializer(ModelObject mobj, Dictionary<ModelObject,string> mobjToTmp) //755:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //756:2
            {
                if (!Instances.Contains(mobj)) //757:3
                {
                }
                else //758:3
                {
                    var __loop42_results = 
                        (from __loop42_var1 in __Enumerate((mobj).GetEnumerator()) //759:9
                        from prop in __Enumerate((__loop42_var1.MGetAllProperties()).GetEnumerator()) //759:15
                        select new { __loop42_var1 = __loop42_var1, prop = prop}
                        ).ToList(); //759:4
                    int __loop42_iteration = 0;
                    foreach (var __tmp1 in __loop42_results)
                    {
                        ++__loop42_iteration;
                        var __loop42_var1 = __tmp1.__loop42_var1;
                        var prop = __tmp1.prop;
                        if (prop.MetaProperty != null && prop.MetaProperty.Kind != MetaPropertyKind.Derived) //760:5
                        {
                            object propValue = mobj.MGet(prop); //761:6
                            string __tmp2Prefix = string.Empty;
                            string __tmp3Suffix = string.Empty;
                            StringBuilder __tmp4 = new StringBuilder();
                            __tmp4.Append(GenerateModelObjectPropertyValue(mobj, prop, propValue, mobjToTmp));
                            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                            {
                                bool __tmp4_first = true;
                                while(__tmp4_first || !__tmp4Reader.EndOfStream)
                                {
                                    __tmp4_first = false;
                                    string __tmp4Line = __tmp4Reader.ReadLine();
                                    if (__tmp4Line == null)
                                    {
                                        __tmp4Line = "";
                                    }
                                    __out.Append(__tmp2Prefix);
                                    __out.Append(__tmp4Line);
                                    __out.Append(__tmp3Suffix);
                                    __out.AppendLine(); //762:69
                                }
                            }
                        }
                    }
                    var __loop43_results = 
                        (from __loop43_var1 in __Enumerate((mobj).GetEnumerator()) //765:9
                        from child in __Enumerate((__loop43_var1.MChildren).GetEnumerator()) //765:15
                        select new { __loop43_var1 = __loop43_var1, child = child}
                        ).ToList(); //765:4
                    int __loop43_iteration = 0;
                    foreach (var __tmp5 in __loop43_results)
                    {
                        ++__loop43_iteration;
                        var __loop43_var1 = __tmp5.__loop43_var1;
                        var child = __tmp5.child;
                        string __tmp6Prefix = string.Empty;
                        string __tmp7Suffix = string.Empty;
                        StringBuilder __tmp8 = new StringBuilder();
                        __tmp8.Append(GenerateModelObjectInstanceInitializer(child, mobjToTmp));
                        using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                        {
                            bool __tmp8_first = true;
                            while(__tmp8_first || !__tmp8Reader.EndOfStream)
                            {
                                __tmp8_first = false;
                                string __tmp8Line = __tmp8Reader.ReadLine();
                                if (__tmp8Line == null)
                                {
                                    __tmp8Line = "";
                                }
                                __out.Append(__tmp6Prefix);
                                __out.Append(__tmp8Line);
                                __out.Append(__tmp7Suffix);
                                __out.AppendLine(); //766:59
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectPropertyValue(ModelObject mobj, ModelProperty prop, object value, Dictionary<ModelObject,string> mobjToTmp) //772:1
        {
            StringBuilder __out = new StringBuilder();
            string tmpName = mobjToTmp[mobj]; //773:2
            string propDeclName = prop.JavaFullDeclaredName(); //774:2
            if (!prop.IsCollection) //775:2
            {
                string __tmp1Prefix = "((metadslx.core.ModelObject)"; //776:1
                string __tmp2Suffix = ");"; //776:61
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(tmpName);
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_first = true;
                    while(__tmp3_first || !__tmp3Reader.EndOfStream)
                    {
                        __tmp3_first = false;
                        string __tmp3Line = __tmp3Reader.ReadLine();
                        if (__tmp3Line == null)
                        {
                            __tmp3Line = "";
                        }
                        __out.Append(__tmp1Prefix);
                        __out.Append(__tmp3Line);
                    }
                }
                string __tmp4Line = ").mUnSet("; //776:38
                __out.Append(__tmp4Line);
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(propDeclName);
                using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                {
                    bool __tmp5_first = true;
                    while(__tmp5_first || !__tmp5Reader.EndOfStream)
                    {
                        __tmp5_first = false;
                        string __tmp5Line = __tmp5Reader.ReadLine();
                        if (__tmp5Line == null)
                        {
                            __tmp5Line = "";
                        }
                        __out.Append(__tmp5Line);
                        __out.Append(__tmp2Suffix);
                        __out.AppendLine(); //776:63
                    }
                }
            }
            ModelObject moValue = value as ModelObject; //778:2
            if (value == null) //779:2
            {
                string __tmp6Prefix = "((metadslx.core.ModelObject)"; //780:1
                string __tmp7Suffix = ", metadslx.core.Lazy.create(() -> null, true));"; //780:63
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(tmpName);
                using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                {
                    bool __tmp8_first = true;
                    while(__tmp8_first || !__tmp8Reader.EndOfStream)
                    {
                        __tmp8_first = false;
                        string __tmp8Line = __tmp8Reader.ReadLine();
                        if (__tmp8Line == null)
                        {
                            __tmp8Line = "";
                        }
                        __out.Append(__tmp6Prefix);
                        __out.Append(__tmp8Line);
                    }
                }
                string __tmp9Line = ").mLazyAdd("; //780:38
                __out.Append(__tmp9Line);
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(propDeclName);
                using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
                {
                    bool __tmp10_first = true;
                    while(__tmp10_first || !__tmp10Reader.EndOfStream)
                    {
                        __tmp10_first = false;
                        string __tmp10Line = __tmp10Reader.ReadLine();
                        if (__tmp10Line == null)
                        {
                            __tmp10Line = "";
                        }
                        __out.Append(__tmp10Line);
                        __out.Append(__tmp7Suffix);
                        __out.AppendLine(); //780:110
                    }
                }
            }
            else if (value is string) //781:2
            {
                string __tmp11Prefix = "((metadslx.core.ModelObject)"; //782:1
                string __tmp12Suffix = "\", true));"; //782:105
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(tmpName);
                using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                {
                    bool __tmp13_first = true;
                    while(__tmp13_first || !__tmp13Reader.EndOfStream)
                    {
                        __tmp13_first = false;
                        string __tmp13Line = __tmp13Reader.ReadLine();
                        if (__tmp13Line == null)
                        {
                            __tmp13Line = "";
                        }
                        __out.Append(__tmp11Prefix);
                        __out.Append(__tmp13Line);
                    }
                }
                string __tmp14Line = ").mLazyAdd("; //782:38
                __out.Append(__tmp14Line);
                StringBuilder __tmp15 = new StringBuilder();
                __tmp15.Append(propDeclName);
                using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
                {
                    bool __tmp15_first = true;
                    while(__tmp15_first || !__tmp15Reader.EndOfStream)
                    {
                        __tmp15_first = false;
                        string __tmp15Line = __tmp15Reader.ReadLine();
                        if (__tmp15Line == null)
                        {
                            __tmp15Line = "";
                        }
                        __out.Append(__tmp15Line);
                    }
                }
                string __tmp16Line = ", metadslx.core.Lazy.create(() -> \""; //782:63
                __out.Append(__tmp16Line);
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(value);
                using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
                {
                    bool __tmp17_first = true;
                    while(__tmp17_first || !__tmp17Reader.EndOfStream)
                    {
                        __tmp17_first = false;
                        string __tmp17Line = __tmp17Reader.ReadLine();
                        if (__tmp17Line == null)
                        {
                            __tmp17Line = "";
                        }
                        __out.Append(__tmp17Line);
                        __out.Append(__tmp12Suffix);
                        __out.AppendLine(); //782:115
                    }
                }
            }
            else if (value is bool) //783:2
            {
                string __tmp18Prefix = "((metadslx.core.ModelObject)"; //784:1
                string __tmp19Suffix = ", true));"; //784:125
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(tmpName);
                using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
                {
                    bool __tmp20_first = true;
                    while(__tmp20_first || !__tmp20Reader.EndOfStream)
                    {
                        __tmp20_first = false;
                        string __tmp20Line = __tmp20Reader.ReadLine();
                        if (__tmp20Line == null)
                        {
                            __tmp20Line = "";
                        }
                        __out.Append(__tmp18Prefix);
                        __out.Append(__tmp20Line);
                    }
                }
                string __tmp21Line = ").mLazyAdd("; //784:38
                __out.Append(__tmp21Line);
                StringBuilder __tmp22 = new StringBuilder();
                __tmp22.Append(propDeclName);
                using(StreamReader __tmp22Reader = new StreamReader(this.__ToStream(__tmp22.ToString())))
                {
                    bool __tmp22_first = true;
                    while(__tmp22_first || !__tmp22Reader.EndOfStream)
                    {
                        __tmp22_first = false;
                        string __tmp22Line = __tmp22Reader.ReadLine();
                        if (__tmp22Line == null)
                        {
                            __tmp22Line = "";
                        }
                        __out.Append(__tmp22Line);
                    }
                }
                string __tmp23Line = ", metadslx.core.Lazy.create(() -> "; //784:63
                __out.Append(__tmp23Line);
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(value.ToString().ToLower());
                using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
                {
                    bool __tmp24_first = true;
                    while(__tmp24_first || !__tmp24Reader.EndOfStream)
                    {
                        __tmp24_first = false;
                        string __tmp24Line = __tmp24Reader.ReadLine();
                        if (__tmp24Line == null)
                        {
                            __tmp24Line = "";
                        }
                        __out.Append(__tmp24Line);
                        __out.Append(__tmp19Suffix);
                        __out.AppendLine(); //784:134
                    }
                }
            }
            else if (value.GetType().IsPrimitive) //785:2
            {
                string __tmp25Prefix = "((metadslx.core.ModelObject)"; //786:1
                string __tmp26Suffix = ", true));"; //786:115
                StringBuilder __tmp27 = new StringBuilder();
                __tmp27.Append(tmpName);
                using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
                {
                    bool __tmp27_first = true;
                    while(__tmp27_first || !__tmp27Reader.EndOfStream)
                    {
                        __tmp27_first = false;
                        string __tmp27Line = __tmp27Reader.ReadLine();
                        if (__tmp27Line == null)
                        {
                            __tmp27Line = "";
                        }
                        __out.Append(__tmp25Prefix);
                        __out.Append(__tmp27Line);
                    }
                }
                string __tmp28Line = ").mLazyAdd("; //786:38
                __out.Append(__tmp28Line);
                StringBuilder __tmp29 = new StringBuilder();
                __tmp29.Append(propDeclName);
                using(StreamReader __tmp29Reader = new StreamReader(this.__ToStream(__tmp29.ToString())))
                {
                    bool __tmp29_first = true;
                    while(__tmp29_first || !__tmp29Reader.EndOfStream)
                    {
                        __tmp29_first = false;
                        string __tmp29Line = __tmp29Reader.ReadLine();
                        if (__tmp29Line == null)
                        {
                            __tmp29Line = "";
                        }
                        __out.Append(__tmp29Line);
                    }
                }
                string __tmp30Line = ", metadslx.core.Lazy.create(() -> "; //786:63
                __out.Append(__tmp30Line);
                StringBuilder __tmp31 = new StringBuilder();
                __tmp31.Append(value.ToString());
                using(StreamReader __tmp31Reader = new StreamReader(this.__ToStream(__tmp31.ToString())))
                {
                    bool __tmp31_first = true;
                    while(__tmp31_first || !__tmp31Reader.EndOfStream)
                    {
                        __tmp31_first = false;
                        string __tmp31Line = __tmp31Reader.ReadLine();
                        if (__tmp31Line == null)
                        {
                            __tmp31Line = "";
                        }
                        __out.Append(__tmp31Line);
                        __out.Append(__tmp26Suffix);
                        __out.AppendLine(); //786:124
                    }
                }
            }
            else if (MetaBuiltInTypes.Types.Contains(value)) //787:2
            {
                string __tmp32Prefix = "((metadslx.core.ModelObject)"; //788:1
                string __tmp33Suffix = ", true));"; //788:120
                StringBuilder __tmp34 = new StringBuilder();
                __tmp34.Append(tmpName);
                using(StreamReader __tmp34Reader = new StreamReader(this.__ToStream(__tmp34.ToString())))
                {
                    bool __tmp34_first = true;
                    while(__tmp34_first || !__tmp34Reader.EndOfStream)
                    {
                        __tmp34_first = false;
                        string __tmp34Line = __tmp34Reader.ReadLine();
                        if (__tmp34Line == null)
                        {
                            __tmp34Line = "";
                        }
                        __out.Append(__tmp32Prefix);
                        __out.Append(__tmp34Line);
                    }
                }
                string __tmp35Line = ").mLazyAdd("; //788:38
                __out.Append(__tmp35Line);
                StringBuilder __tmp36 = new StringBuilder();
                __tmp36.Append(propDeclName);
                using(StreamReader __tmp36Reader = new StreamReader(this.__ToStream(__tmp36.ToString())))
                {
                    bool __tmp36_first = true;
                    while(__tmp36_first || !__tmp36Reader.EndOfStream)
                    {
                        __tmp36_first = false;
                        string __tmp36Line = __tmp36Reader.ReadLine();
                        if (__tmp36Line == null)
                        {
                            __tmp36Line = "";
                        }
                        __out.Append(__tmp36Line);
                    }
                }
                string __tmp37Line = ", metadslx.core.Lazy.create(() -> "; //788:63
                __out.Append(__tmp37Line);
                StringBuilder __tmp38 = new StringBuilder();
                __tmp38.Append(GenerateTypeOf(value));
                using(StreamReader __tmp38Reader = new StreamReader(this.__ToStream(__tmp38.ToString())))
                {
                    bool __tmp38_first = true;
                    while(__tmp38_first || !__tmp38Reader.EndOfStream)
                    {
                        __tmp38_first = false;
                        string __tmp38Line = __tmp38Reader.ReadLine();
                        if (__tmp38Line == null)
                        {
                            __tmp38Line = "";
                        }
                        __out.Append(__tmp38Line);
                        __out.Append(__tmp33Suffix);
                        __out.AppendLine(); //788:129
                    }
                }
            }
            else if (value is MetaPrimitiveType) //789:2
            {
                string __tmp39Prefix = "((metadslx.core.ModelObject)"; //790:1
                string __tmp40Suffix = ", true));"; //790:120
                StringBuilder __tmp41 = new StringBuilder();
                __tmp41.Append(tmpName);
                using(StreamReader __tmp41Reader = new StreamReader(this.__ToStream(__tmp41.ToString())))
                {
                    bool __tmp41_first = true;
                    while(__tmp41_first || !__tmp41Reader.EndOfStream)
                    {
                        __tmp41_first = false;
                        string __tmp41Line = __tmp41Reader.ReadLine();
                        if (__tmp41Line == null)
                        {
                            __tmp41Line = "";
                        }
                        __out.Append(__tmp39Prefix);
                        __out.Append(__tmp41Line);
                    }
                }
                string __tmp42Line = ").mLazyAdd("; //790:38
                __out.Append(__tmp42Line);
                StringBuilder __tmp43 = new StringBuilder();
                __tmp43.Append(propDeclName);
                using(StreamReader __tmp43Reader = new StreamReader(this.__ToStream(__tmp43.ToString())))
                {
                    bool __tmp43_first = true;
                    while(__tmp43_first || !__tmp43Reader.EndOfStream)
                    {
                        __tmp43_first = false;
                        string __tmp43Line = __tmp43Reader.ReadLine();
                        if (__tmp43Line == null)
                        {
                            __tmp43Line = "";
                        }
                        __out.Append(__tmp43Line);
                    }
                }
                string __tmp44Line = ", metadslx.core.Lazy.create(() -> "; //790:63
                __out.Append(__tmp44Line);
                StringBuilder __tmp45 = new StringBuilder();
                __tmp45.Append(GenerateTypeOf(value));
                using(StreamReader __tmp45Reader = new StreamReader(this.__ToStream(__tmp45.ToString())))
                {
                    bool __tmp45_first = true;
                    while(__tmp45_first || !__tmp45Reader.EndOfStream)
                    {
                        __tmp45_first = false;
                        string __tmp45Line = __tmp45Reader.ReadLine();
                        if (__tmp45Line == null)
                        {
                            __tmp45Line = "";
                        }
                        __out.Append(__tmp45Line);
                        __out.Append(__tmp40Suffix);
                        __out.AppendLine(); //790:129
                    }
                }
            }
            else if (value is Enum) //791:2
            {
                string __tmp46Prefix = "((metadslx.core.ModelObject)"; //792:1
                string __tmp47Suffix = ", true));"; //792:122
                StringBuilder __tmp48 = new StringBuilder();
                __tmp48.Append(tmpName);
                using(StreamReader __tmp48Reader = new StreamReader(this.__ToStream(__tmp48.ToString())))
                {
                    bool __tmp48_first = true;
                    while(__tmp48_first || !__tmp48Reader.EndOfStream)
                    {
                        __tmp48_first = false;
                        string __tmp48Line = __tmp48Reader.ReadLine();
                        if (__tmp48Line == null)
                        {
                            __tmp48Line = "";
                        }
                        __out.Append(__tmp46Prefix);
                        __out.Append(__tmp48Line);
                    }
                }
                string __tmp49Line = ").mLazyAdd("; //792:38
                __out.Append(__tmp49Line);
                StringBuilder __tmp50 = new StringBuilder();
                __tmp50.Append(propDeclName);
                using(StreamReader __tmp50Reader = new StreamReader(this.__ToStream(__tmp50.ToString())))
                {
                    bool __tmp50_first = true;
                    while(__tmp50_first || !__tmp50Reader.EndOfStream)
                    {
                        __tmp50_first = false;
                        string __tmp50Line = __tmp50Reader.ReadLine();
                        if (__tmp50Line == null)
                        {
                            __tmp50Line = "";
                        }
                        __out.Append(__tmp50Line);
                    }
                }
                string __tmp51Line = ", metadslx.core.Lazy.create(() -> "; //792:63
                __out.Append(__tmp51Line);
                StringBuilder __tmp52 = new StringBuilder();
                __tmp52.Append(value.JavaEnumValueOf());
                using(StreamReader __tmp52Reader = new StreamReader(this.__ToStream(__tmp52.ToString())))
                {
                    bool __tmp52_first = true;
                    while(__tmp52_first || !__tmp52Reader.EndOfStream)
                    {
                        __tmp52_first = false;
                        string __tmp52Line = __tmp52Reader.ReadLine();
                        if (__tmp52Line == null)
                        {
                            __tmp52Line = "";
                        }
                        __out.Append(__tmp52Line);
                        __out.Append(__tmp47Suffix);
                        __out.AppendLine(); //792:131
                    }
                }
            }
            else if (moValue != null) //793:2
            {
                if (mobjToTmp.ContainsKey(moValue)) //794:3
                {
                    string __tmp53Prefix = "((metadslx.core.ModelObject)"; //795:1
                    string __tmp54Suffix = ", true));"; //795:117
                    StringBuilder __tmp55 = new StringBuilder();
                    __tmp55.Append(tmpName);
                    using(StreamReader __tmp55Reader = new StreamReader(this.__ToStream(__tmp55.ToString())))
                    {
                        bool __tmp55_first = true;
                        while(__tmp55_first || !__tmp55Reader.EndOfStream)
                        {
                            __tmp55_first = false;
                            string __tmp55Line = __tmp55Reader.ReadLine();
                            if (__tmp55Line == null)
                            {
                                __tmp55Line = "";
                            }
                            __out.Append(__tmp53Prefix);
                            __out.Append(__tmp55Line);
                        }
                    }
                    string __tmp56Line = ").mLazyAdd("; //795:38
                    __out.Append(__tmp56Line);
                    StringBuilder __tmp57 = new StringBuilder();
                    __tmp57.Append(propDeclName);
                    using(StreamReader __tmp57Reader = new StreamReader(this.__ToStream(__tmp57.ToString())))
                    {
                        bool __tmp57_first = true;
                        while(__tmp57_first || !__tmp57Reader.EndOfStream)
                        {
                            __tmp57_first = false;
                            string __tmp57Line = __tmp57Reader.ReadLine();
                            if (__tmp57Line == null)
                            {
                                __tmp57Line = "";
                            }
                            __out.Append(__tmp57Line);
                        }
                    }
                    string __tmp58Line = ", metadslx.core.Lazy.create(() -> "; //795:63
                    __out.Append(__tmp58Line);
                    StringBuilder __tmp59 = new StringBuilder();
                    __tmp59.Append(mobjToTmp[moValue]);
                    using(StreamReader __tmp59Reader = new StreamReader(this.__ToStream(__tmp59.ToString())))
                    {
                        bool __tmp59_first = true;
                        while(__tmp59_first || !__tmp59Reader.EndOfStream)
                        {
                            __tmp59_first = false;
                            string __tmp59Line = __tmp59Reader.ReadLine();
                            if (__tmp59Line == null)
                            {
                                __tmp59Line = "";
                            }
                            __out.Append(__tmp59Line);
                            __out.Append(__tmp54Suffix);
                            __out.AppendLine(); //795:126
                        }
                    }
                }
                else //796:3
                {
                    string __tmp60Prefix = string.Empty;
                    string __tmp61Suffix = string.Empty;
                    StringBuilder __tmp62 = new StringBuilder();
                    __tmp62.Append(GenerateModelObjectInstanceInitializer(moValue, mobjToTmp));
                    using(StreamReader __tmp62Reader = new StreamReader(this.__ToStream(__tmp62.ToString())))
                    {
                        bool __tmp62_first = true;
                        while(__tmp62_first || !__tmp62Reader.EndOfStream)
                        {
                            __tmp62_first = false;
                            string __tmp62Line = __tmp62Reader.ReadLine();
                            if (__tmp62Line == null)
                            {
                                __tmp62Line = "";
                            }
                            __out.Append(__tmp60Prefix);
                            __out.Append(__tmp62Line);
                            __out.Append(__tmp61Suffix);
                            __out.AppendLine(); //797:61
                        }
                    }
                    if (mobjToTmp.ContainsKey(moValue)) //798:4
                    {
                        string tmpValueName = mobjToTmp[moValue]; //799:5
                        string __tmp63Prefix = "((metadslx.core.ModelObject)"; //800:1
                        string __tmp64Suffix = ", true));"; //800:111
                        StringBuilder __tmp65 = new StringBuilder();
                        __tmp65.Append(tmpName);
                        using(StreamReader __tmp65Reader = new StreamReader(this.__ToStream(__tmp65.ToString())))
                        {
                            bool __tmp65_first = true;
                            while(__tmp65_first || !__tmp65Reader.EndOfStream)
                            {
                                __tmp65_first = false;
                                string __tmp65Line = __tmp65Reader.ReadLine();
                                if (__tmp65Line == null)
                                {
                                    __tmp65Line = "";
                                }
                                __out.Append(__tmp63Prefix);
                                __out.Append(__tmp65Line);
                            }
                        }
                        string __tmp66Line = ").mLazyAdd("; //800:38
                        __out.Append(__tmp66Line);
                        StringBuilder __tmp67 = new StringBuilder();
                        __tmp67.Append(propDeclName);
                        using(StreamReader __tmp67Reader = new StreamReader(this.__ToStream(__tmp67.ToString())))
                        {
                            bool __tmp67_first = true;
                            while(__tmp67_first || !__tmp67Reader.EndOfStream)
                            {
                                __tmp67_first = false;
                                string __tmp67Line = __tmp67Reader.ReadLine();
                                if (__tmp67Line == null)
                                {
                                    __tmp67Line = "";
                                }
                                __out.Append(__tmp67Line);
                            }
                        }
                        string __tmp68Line = ", metadslx.core.Lazy.create(() -> "; //800:63
                        __out.Append(__tmp68Line);
                        StringBuilder __tmp69 = new StringBuilder();
                        __tmp69.Append(tmpValueName);
                        using(StreamReader __tmp69Reader = new StreamReader(this.__ToStream(__tmp69.ToString())))
                        {
                            bool __tmp69_first = true;
                            while(__tmp69_first || !__tmp69Reader.EndOfStream)
                            {
                                __tmp69_first = false;
                                string __tmp69Line = __tmp69Reader.ReadLine();
                                if (__tmp69Line == null)
                                {
                                    __tmp69Line = "";
                                }
                                __out.Append(__tmp69Line);
                                __out.Append(__tmp64Suffix);
                                __out.AppendLine(); //800:120
                            }
                        }
                    }
                    else //801:4
                    {
                        string __tmp70Prefix = "// NOT FOUND: "; //802:1
                        string __tmp71Suffix = string.Empty; 
                        StringBuilder __tmp72 = new StringBuilder();
                        __tmp72.Append(moValue);
                        using(StreamReader __tmp72Reader = new StreamReader(this.__ToStream(__tmp72.ToString())))
                        {
                            bool __tmp72_first = true;
                            while(__tmp72_first || !__tmp72Reader.EndOfStream)
                            {
                                __tmp72_first = false;
                                string __tmp72Line = __tmp72Reader.ReadLine();
                                if (__tmp72Line == null)
                                {
                                    __tmp72Line = "";
                                }
                                __out.Append(__tmp70Prefix);
                                __out.Append(__tmp72Line);
                                __out.Append(__tmp71Suffix);
                                __out.AppendLine(); //802:24
                            }
                        }
                    }
                }
            }
            else //805:2
            {
                IEnumerable<object> mc = (value as ModelCollection) as IEnumerable<object>; //806:3
                if (mc != null) //807:3
                {
                    var __loop44_results = 
                        (from cvalue in __Enumerate((mc).GetEnumerator()) //808:9
                        select new { cvalue = cvalue}
                        ).ToList(); //808:4
                    int __loop44_iteration = 0;
                    foreach (var __tmp73 in __loop44_results)
                    {
                        ++__loop44_iteration;
                        var cvalue = __tmp73.cvalue;
                        string __tmp74Prefix = string.Empty;
                        string __tmp75Suffix = string.Empty;
                        StringBuilder __tmp76 = new StringBuilder();
                        __tmp76.Append(GenerateModelObjectPropertyValue(mobj, prop, cvalue, mobjToTmp));
                        using(StreamReader __tmp76Reader = new StreamReader(this.__ToStream(__tmp76.ToString())))
                        {
                            bool __tmp76_first = true;
                            while(__tmp76_first || !__tmp76Reader.EndOfStream)
                            {
                                __tmp76_first = false;
                                string __tmp76Line = __tmp76Reader.ReadLine();
                                if (__tmp76Line == null)
                                {
                                    __tmp76Line = "";
                                }
                                __out.Append(__tmp74Prefix);
                                __out.Append(__tmp76Line);
                                __out.Append(__tmp75Suffix);
                                __out.AppendLine(); //809:66
                            }
                        }
                    }
                }
                else //811:3
                {
                    string __tmp77Prefix = "// "; //812:1
                    string __tmp78Suffix = string.Empty; 
                    StringBuilder __tmp79 = new StringBuilder();
                    __tmp79.Append(propDeclName);
                    using(StreamReader __tmp79Reader = new StreamReader(this.__ToStream(__tmp79.ToString())))
                    {
                        bool __tmp79_first = true;
                        while(__tmp79_first || !__tmp79Reader.EndOfStream)
                        {
                            __tmp79_first = false;
                            string __tmp79Line = __tmp79Reader.ReadLine();
                            if (__tmp79Line == null)
                            {
                                __tmp79Line = "";
                            }
                            __out.Append(__tmp77Prefix);
                            __out.Append(__tmp79Line);
                        }
                    }
                    string __tmp80Line = " = "; //812:18
                    __out.Append(__tmp80Line);
                    StringBuilder __tmp81 = new StringBuilder();
                    __tmp81.Append(value.GetType());
                    using(StreamReader __tmp81Reader = new StreamReader(this.__ToStream(__tmp81.ToString())))
                    {
                        bool __tmp81_first = true;
                        while(__tmp81_first || !__tmp81Reader.EndOfStream)
                        {
                            __tmp81_first = false;
                            string __tmp81Line = __tmp81Reader.ReadLine();
                            if (__tmp81Line == null)
                            {
                                __tmp81Line = "";
                            }
                            __out.Append(__tmp81Line);
                            __out.Append(__tmp78Suffix);
                            __out.AppendLine(); //812:38
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectPropertyValueDeclaration(ModelObject mobj, ModelProperty prop, object value, Dictionary<ModelObject,string> mobjToTmp) //817:1
        {
            StringBuilder __out = new StringBuilder();
            string tmpName = mobjToTmp[mobj]; //818:2
            string propDeclName = prop.JavaFullDeclaredName(); //819:2
            ModelObject moValue = value as ModelObject; //820:2
            if (value == null) //821:2
            {
            }
            else if (value is string) //822:2
            {
            }
            else if (value is bool) //823:2
            {
            }
            else if (value.GetType().IsPrimitive) //824:2
            {
            }
            else if (MetaBuiltInTypes.Types.Contains(value)) //825:2
            {
            }
            else if (value is MetaPrimitiveType) //826:2
            {
            }
            else if (value is Enum) //827:2
            {
            }
            else if (moValue != null) //828:2
            {
                if (mobjToTmp.ContainsKey(moValue)) //829:3
                {
                }
                else //830:3
                {
                    string __tmp1Prefix = string.Empty;
                    string __tmp2Suffix = string.Empty;
                    StringBuilder __tmp3 = new StringBuilder();
                    __tmp3.Append(GenerateModelObjectInstanceDeclaration(moValue, mobjToTmp));
                    using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                    {
                        bool __tmp3_first = true;
                        while(__tmp3_first || !__tmp3Reader.EndOfStream)
                        {
                            __tmp3_first = false;
                            string __tmp3Line = __tmp3Reader.ReadLine();
                            if (__tmp3Line == null)
                            {
                                __tmp3Line = "";
                            }
                            __out.Append(__tmp1Prefix);
                            __out.Append(__tmp3Line);
                            __out.Append(__tmp2Suffix);
                            __out.AppendLine(); //831:61
                        }
                    }
                }
            }
            else //833:2
            {
                IEnumerable<object> mc = (value as ModelCollection) as IEnumerable<object>; //834:3
                if (mc != null) //835:3
                {
                    var __loop45_results = 
                        (from cvalue in __Enumerate((mc).GetEnumerator()) //836:9
                        select new { cvalue = cvalue}
                        ).ToList(); //836:4
                    int __loop45_iteration = 0;
                    foreach (var __tmp4 in __loop45_results)
                    {
                        ++__loop45_iteration;
                        var cvalue = __tmp4.cvalue;
                        string __tmp5Prefix = string.Empty;
                        string __tmp6Suffix = string.Empty;
                        StringBuilder __tmp7 = new StringBuilder();
                        __tmp7.Append(GenerateModelObjectPropertyValueDeclaration(mobj, prop, cvalue, mobjToTmp));
                        using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
                        {
                            bool __tmp7_first = true;
                            while(__tmp7_first || !__tmp7Reader.EndOfStream)
                            {
                                __tmp7_first = false;
                                string __tmp7Line = __tmp7Reader.ReadLine();
                                if (__tmp7Line == null)
                                {
                                    __tmp7Line = "";
                                }
                                __out.Append(__tmp5Prefix);
                                __out.Append(__tmp7Line);
                                __out.Append(__tmp6Suffix);
                                __out.AppendLine(); //837:77
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectPropertyValueInstance(ModelObject mobj, ModelProperty prop, object value, Dictionary<ModelObject,string> mobjToTmp) //843:1
        {
            StringBuilder __out = new StringBuilder();
            string tmpName = mobjToTmp[mobj]; //844:2
            string propDeclName = prop.JavaFullDeclaredName(); //845:2
            ModelObject moValue = value as ModelObject; //846:2
            if (value == null) //847:2
            {
            }
            else if (value is string) //848:2
            {
            }
            else if (value is bool) //849:2
            {
            }
            else if (value.GetType().IsPrimitive) //850:2
            {
            }
            else if (MetaBuiltInTypes.Types.Contains(value)) //851:2
            {
            }
            else if (value is MetaPrimitiveType) //852:2
            {
            }
            else if (value is Enum) //853:2
            {
            }
            else if (moValue != null) //854:2
            {
                if (mobjToTmp.ContainsKey(moValue)) //855:3
                {
                }
                else //856:3
                {
                    string __tmp1Prefix = string.Empty;
                    string __tmp2Suffix = string.Empty;
                    StringBuilder __tmp3 = new StringBuilder();
                    __tmp3.Append(GenerateModelObjectInstance(moValue, mobjToTmp));
                    using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                    {
                        bool __tmp3_first = true;
                        while(__tmp3_first || !__tmp3Reader.EndOfStream)
                        {
                            __tmp3_first = false;
                            string __tmp3Line = __tmp3Reader.ReadLine();
                            if (__tmp3Line == null)
                            {
                                __tmp3Line = "";
                            }
                            __out.Append(__tmp1Prefix);
                            __out.Append(__tmp3Line);
                            __out.Append(__tmp2Suffix);
                            __out.AppendLine(); //857:50
                        }
                    }
                }
            }
            else //859:2
            {
                IEnumerable<object> mc = (value as ModelCollection) as IEnumerable<object>; //860:3
                if (mc != null) //861:3
                {
                    var __loop46_results = 
                        (from cvalue in __Enumerate((mc).GetEnumerator()) //862:9
                        select new { cvalue = cvalue}
                        ).ToList(); //862:4
                    int __loop46_iteration = 0;
                    foreach (var __tmp4 in __loop46_results)
                    {
                        ++__loop46_iteration;
                        var cvalue = __tmp4.cvalue;
                        string __tmp5Prefix = string.Empty;
                        string __tmp6Suffix = string.Empty;
                        StringBuilder __tmp7 = new StringBuilder();
                        __tmp7.Append(GenerateModelObjectPropertyValueInstance(mobj, prop, cvalue, mobjToTmp));
                        using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
                        {
                            bool __tmp7_first = true;
                            while(__tmp7_first || !__tmp7Reader.EndOfStream)
                            {
                                __tmp7_first = false;
                                string __tmp7Line = __tmp7Reader.ReadLine();
                                if (__tmp7Line == null)
                                {
                                    __tmp7Line = "";
                                }
                                __out.Append(__tmp5Prefix);
                                __out.Append(__tmp7Line);
                                __out.Append(__tmp6Suffix);
                                __out.AppendLine(); //863:74
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateClassMetaInstance(MetaClass cls) //868:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = " = metadslx.core.MetaFactory.instance().createMetaClass();"; //869:17
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.JavaName());
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //869:75
                }
            }
            return __out.ToString();
        }

        public string GenerateClassMetaInstanceInitializer(MetaClass cls) //872:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = "\");"; //873:43
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.JavaName());
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                }
            }
            string __tmp4Line = ".setName(\""; //873:17
            __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(cls.JavaName());
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_first = true;
                while(__tmp5_first || !__tmp5Reader.EndOfStream)
                {
                    __tmp5_first = false;
                    string __tmp5Line = __tmp5Reader.ReadLine();
                    if (__tmp5Line == null)
                    {
                        __tmp5Line = "";
                    }
                    __out.Append(__tmp5Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //873:46
                }
            }
            if (cls.IsAbstract) //874:2
            {
                string __tmp6Prefix = string.Empty; 
                string __tmp7Suffix = ".setIsAbstract(true);"; //875:17
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(cls.JavaName());
                using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                {
                    bool __tmp8_first = true;
                    while(__tmp8_first || !__tmp8Reader.EndOfStream)
                    {
                        __tmp8_first = false;
                        string __tmp8Line = __tmp8Reader.ReadLine();
                        if (__tmp8Line == null)
                        {
                            __tmp8Line = "";
                        }
                        __out.Append(__tmp6Prefix);
                        __out.Append(__tmp8Line);
                        __out.Append(__tmp7Suffix);
                        __out.AppendLine(); //875:38
                    }
                }
            }
            var __loop47_results = 
                (from __loop47_var1 in __Enumerate((cls).GetEnumerator()) //877:7
                from sup in __Enumerate((__loop47_var1.SuperClasses).GetEnumerator()) //877:12
                select new { __loop47_var1 = __loop47_var1, sup = sup}
                ).ToList(); //877:2
            int __loop47_iteration = 0;
            foreach (var __tmp9 in __loop47_results)
            {
                ++__loop47_iteration;
                var __loop47_var1 = __tmp9.__loop47_var1;
                var sup = __tmp9.sup;
                string __tmp10Prefix = string.Empty; 
                string __tmp11Suffix = ");"; //878:68
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(cls.JavaName());
                using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
                {
                    bool __tmp12_first = true;
                    while(__tmp12_first || !__tmp12Reader.EndOfStream)
                    {
                        __tmp12_first = false;
                        string __tmp12Line = __tmp12Reader.ReadLine();
                        if (__tmp12Line == null)
                        {
                            __tmp12Line = "";
                        }
                        __out.Append(__tmp10Prefix);
                        __out.Append(__tmp12Line);
                    }
                }
                string __tmp13Line = ".getSuperClasses().add("; //878:17
                __out.Append(__tmp13Line);
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(sup.JavaFullInstanceName());
                using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
                {
                    bool __tmp14_first = true;
                    while(__tmp14_first || !__tmp14Reader.EndOfStream)
                    {
                        __tmp14_first = false;
                        string __tmp14Line = __tmp14Reader.ReadLine();
                        if (__tmp14Line == null)
                        {
                            __tmp14Line = "";
                        }
                        __out.Append(__tmp14Line);
                        __out.Append(__tmp11Suffix);
                        __out.AppendLine(); //878:70
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //883:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "package "; //884:1
            string __tmp2Suffix = ";"; //884:37
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.Namespace.JavaName());
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //884:38
                }
            }
            __out.AppendLine(); //885:1
            string __tmp4Prefix = "final class "; //886:1
            string __tmp5Suffix = "ImplementationProvider {"; //886:25
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(model.Name);
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                while(__tmp6_first || !__tmp6Reader.EndOfStream)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    if (__tmp6Line == null)
                    {
                        __tmp6Line = "";
                    }
                    __out.Append(__tmp4Prefix);
                    __out.Append(__tmp6Line);
                    __out.Append(__tmp5Suffix);
                    __out.AppendLine(); //886:49
                }
            }
            string __tmp7Prefix = "    // If there is a compile error at this line, create a new class called "; //887:1
            string __tmp8Suffix = "Implementation"; //887:88
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(model.Name);
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_first = true;
                while(__tmp9_first || !__tmp9Reader.EndOfStream)
                {
                    __tmp9_first = false;
                    string __tmp9Line = __tmp9Reader.ReadLine();
                    if (__tmp9Line == null)
                    {
                        __tmp9Line = "";
                    }
                    __out.Append(__tmp7Prefix);
                    __out.Append(__tmp9Line);
                    __out.Append(__tmp8Suffix);
                    __out.AppendLine(); //887:102
                }
            }
            string __tmp10Prefix = "	// which is a subclass of "; //888:1
            string __tmp11Suffix = "ImplementationBase:"; //888:40
            StringBuilder __tmp12 = new StringBuilder();
            __tmp12.Append(model.Name);
            using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
            {
                bool __tmp12_first = true;
                while(__tmp12_first || !__tmp12Reader.EndOfStream)
                {
                    __tmp12_first = false;
                    string __tmp12Line = __tmp12Reader.ReadLine();
                    if (__tmp12Line == null)
                    {
                        __tmp12Line = "";
                    }
                    __out.Append(__tmp10Prefix);
                    __out.Append(__tmp12Line);
                    __out.Append(__tmp11Suffix);
                    __out.AppendLine(); //888:59
                }
            }
            string __tmp13Prefix = "    private static "; //889:1
            string __tmp14Suffix = "Implementation();"; //889:80
            StringBuilder __tmp15 = new StringBuilder();
            __tmp15.Append(model.Name);
            using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
            {
                bool __tmp15_first = true;
                while(__tmp15_first || !__tmp15Reader.EndOfStream)
                {
                    __tmp15_first = false;
                    string __tmp15Line = __tmp15Reader.ReadLine();
                    if (__tmp15Line == null)
                    {
                        __tmp15Line = "";
                    }
                    __out.Append(__tmp13Prefix);
                    __out.Append(__tmp15Line);
                }
            }
            string __tmp16Line = "Implementation implementation = new "; //889:32
            __out.Append(__tmp16Line);
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(model.Name);
            using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
            {
                bool __tmp17_first = true;
                while(__tmp17_first || !__tmp17Reader.EndOfStream)
                {
                    __tmp17_first = false;
                    string __tmp17Line = __tmp17Reader.ReadLine();
                    if (__tmp17Line == null)
                    {
                        __tmp17Line = "";
                    }
                    __out.Append(__tmp17Line);
                    __out.Append(__tmp14Suffix);
                    __out.AppendLine(); //889:97
                }
            }
            __out.AppendLine(); //890:1
            string __tmp18Prefix = "    public static "; //891:1
            string __tmp19Suffix = "Implementation implementation() {"; //891:31
            StringBuilder __tmp20 = new StringBuilder();
            __tmp20.Append(model.Name);
            using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
            {
                bool __tmp20_first = true;
                while(__tmp20_first || !__tmp20Reader.EndOfStream)
                {
                    __tmp20_first = false;
                    string __tmp20Line = __tmp20Reader.ReadLine();
                    if (__tmp20Line == null)
                    {
                        __tmp20Line = "";
                    }
                    __out.Append(__tmp18Prefix);
                    __out.Append(__tmp20Line);
                    __out.Append(__tmp19Suffix);
                    __out.AppendLine(); //891:64
                }
            }
            string __tmp21Prefix = "        return "; //892:1
            string __tmp22Suffix = "ImplementationProvider.implementation;"; //892:28
            StringBuilder __tmp23 = new StringBuilder();
            __tmp23.Append(model.Name);
            using(StreamReader __tmp23Reader = new StreamReader(this.__ToStream(__tmp23.ToString())))
            {
                bool __tmp23_first = true;
                while(__tmp23_first || !__tmp23Reader.EndOfStream)
                {
                    __tmp23_first = false;
                    string __tmp23Line = __tmp23Reader.ReadLine();
                    if (__tmp23Line == null)
                    {
                        __tmp23Line = "";
                    }
                    __out.Append(__tmp21Prefix);
                    __out.Append(__tmp23Line);
                    __out.Append(__tmp22Suffix);
                    __out.AppendLine(); //892:66
                }
            }
            __out.Append("    }"); //893:1
            __out.AppendLine(); //893:6
            __out.Append("}"); //894:1
            __out.AppendLine(); //894:2
            return __out.ToString();
        }

        public string GenerateImplementationBase(MetaModel model) //897:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "package "; //898:1
            string __tmp2Suffix = ";"; //898:37
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.Namespace.JavaName());
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //898:38
                }
            }
            __out.AppendLine(); //899:1
            __out.Append("/**"); //900:1
            __out.AppendLine(); //900:4
            __out.Append(" * Base class for implementing the behavior of the model elements."); //901:1
            __out.AppendLine(); //901:67
            string __tmp4Prefix = " * This class has to be be overriden in "; //902:1
            string __tmp5Suffix = "Implementation to provide custom"; //902:53
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(model.Name);
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                while(__tmp6_first || !__tmp6Reader.EndOfStream)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    if (__tmp6Line == null)
                    {
                        __tmp6Line = "";
                    }
                    __out.Append(__tmp4Prefix);
                    __out.Append(__tmp6Line);
                    __out.Append(__tmp5Suffix);
                    __out.AppendLine(); //902:85
                }
            }
            __out.Append(" * implementation for the constructors, operations and property values."); //903:1
            __out.AppendLine(); //903:72
            __out.Append(" */"); //904:1
            __out.AppendLine(); //904:4
            string __tmp7Prefix = "abstract class "; //905:1
            string __tmp8Suffix = "ImplementationBase {"; //905:28
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(model.Name);
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_first = true;
                while(__tmp9_first || !__tmp9Reader.EndOfStream)
                {
                    __tmp9_first = false;
                    string __tmp9Line = __tmp9Reader.ReadLine();
                    if (__tmp9Line == null)
                    {
                        __tmp9Line = "";
                    }
                    __out.Append(__tmp7Prefix);
                    __out.Append(__tmp9Line);
                    __out.Append(__tmp8Suffix);
                    __out.AppendLine(); //905:48
                }
            }
            var __loop48_results = 
                (from __loop48_var1 in __Enumerate((model).GetEnumerator()) //906:8
                from Namespace in __Enumerate((__loop48_var1.Namespace).GetEnumerator()) //906:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //906:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //906:40
                select new { __loop48_var1 = __loop48_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //906:3
            int __loop48_iteration = 0;
            foreach (var __tmp10 in __loop48_results)
            {
                ++__loop48_iteration;
                var __loop48_var1 = __tmp10.__loop48_var1;
                var Namespace = __tmp10.Namespace;
                var Declarations = __tmp10.Declarations;
                var cls = __tmp10.cls;
                __out.Append("    /**"); //907:1
                __out.AppendLine(); //907:8
                string __tmp11Prefix = "	 * Implements the constructor: "; //908:1
                string __tmp12Suffix = "()"; //908:49
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(cls.JavaName());
                using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                {
                    bool __tmp13_first = true;
                    while(__tmp13_first || !__tmp13Reader.EndOfStream)
                    {
                        __tmp13_first = false;
                        string __tmp13Line = __tmp13Reader.ReadLine();
                        if (__tmp13Line == null)
                        {
                            __tmp13Line = "";
                        }
                        __out.Append(__tmp11Prefix);
                        __out.Append(__tmp13Line);
                        __out.Append(__tmp12Suffix);
                        __out.AppendLine(); //908:51
                    }
                }
                if ((from __loop49_var1 in __Enumerate((cls).GetEnumerator()) //909:15
                from sup in __Enumerate((__loop49_var1.SuperClasses).GetEnumerator()) //909:20
                select new { __loop49_var1 = __loop49_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //909:3
                {
                    string __tmp14Prefix = "	 * Direct superclasses: "; //910:1
                    string __tmp15Suffix = string.Empty; 
                    StringBuilder __tmp16 = new StringBuilder();
                    __tmp16.Append(GetSuperClasses(cls));
                    using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
                    {
                        bool __tmp16_first = true;
                        while(__tmp16_first || !__tmp16Reader.EndOfStream)
                        {
                            __tmp16_first = false;
                            string __tmp16Line = __tmp16Reader.ReadLine();
                            if (__tmp16Line == null)
                            {
                                __tmp16Line = "";
                            }
                            __out.Append(__tmp14Prefix);
                            __out.Append(__tmp16Line);
                            __out.Append(__tmp15Suffix);
                            __out.AppendLine(); //910:48
                        }
                    }
                    string __tmp17Prefix = "	 * All superclasses: "; //911:1
                    string __tmp18Suffix = string.Empty; 
                    StringBuilder __tmp19 = new StringBuilder();
                    __tmp19.Append(GetAllSuperClasses(cls));
                    using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
                    {
                        bool __tmp19_first = true;
                        while(__tmp19_first || !__tmp19Reader.EndOfStream)
                        {
                            __tmp19_first = false;
                            string __tmp19Line = __tmp19Reader.ReadLine();
                            if (__tmp19Line == null)
                            {
                                __tmp19Line = "";
                            }
                            __out.Append(__tmp17Prefix);
                            __out.Append(__tmp19Line);
                            __out.Append(__tmp18Suffix);
                            __out.AppendLine(); //911:48
                        }
                    }
                }
                if ((from __loop50_var1 in __Enumerate((cls).GetEnumerator()) //913:15
                from prop in __Enumerate((__loop50_var1.GetAllProperties()).GetEnumerator()) //913:20
                where prop.Kind == MetaPropertyKind.Readonly //913:44
                select new { __loop50_var1 = __loop50_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //913:3
                {
                    __out.Append("     * Initializes the following readonly properties:"); //914:1
                    __out.AppendLine(); //914:54
                }
                var __loop51_results = 
                    (from __loop51_var1 in __Enumerate((cls).GetEnumerator()) //916:11
                    from prop in __Enumerate((__loop51_var1.GetAllProperties()).GetEnumerator()) //916:16
                    select new { __loop51_var1 = __loop51_var1, prop = prop}
                    ).ToList(); //916:6
                int __loop51_iteration = 0;
                foreach (var __tmp20 in __loop51_results)
                {
                    ++__loop51_iteration;
                    var __loop51_var1 = __tmp20.__loop51_var1;
                    var prop = __tmp20.prop;
                    if (prop.Kind == MetaPropertyKind.Readonly) //917:3
                    {
                        string __tmp21Prefix = "     *    "; //918:1
                        string __tmp22Suffix = string.Empty; 
                        StringBuilder __tmp23 = new StringBuilder();
                        __tmp23.Append(prop.Class.Name);
                        using(StreamReader __tmp23Reader = new StreamReader(this.__ToStream(__tmp23.ToString())))
                        {
                            bool __tmp23_first = true;
                            while(__tmp23_first || !__tmp23Reader.EndOfStream)
                            {
                                __tmp23_first = false;
                                string __tmp23Line = __tmp23Reader.ReadLine();
                                if (__tmp23Line == null)
                                {
                                    __tmp23Line = "";
                                }
                                __out.Append(__tmp21Prefix);
                                __out.Append(__tmp23Line);
                            }
                        }
                        string __tmp24Line = "."; //918:28
                        __out.Append(__tmp24Line);
                        StringBuilder __tmp25 = new StringBuilder();
                        __tmp25.Append(prop.Name);
                        using(StreamReader __tmp25Reader = new StreamReader(this.__ToStream(__tmp25.ToString())))
                        {
                            bool __tmp25_first = true;
                            while(__tmp25_first || !__tmp25Reader.EndOfStream)
                            {
                                __tmp25_first = false;
                                string __tmp25Line = __tmp25Reader.ReadLine();
                                if (__tmp25Line == null)
                                {
                                    __tmp25Line = "";
                                }
                                __out.Append(__tmp25Line);
                                __out.Append(__tmp22Suffix);
                                __out.AppendLine(); //918:40
                            }
                        }
                    }
                }
                __out.Append("    */"); //921:1
                __out.AppendLine(); //921:7
                string __tmp26Prefix = "    public void "; //922:1
                string __tmp27Suffix = " _this) {"; //922:50
                StringBuilder __tmp28 = new StringBuilder();
                __tmp28.Append(cls.JavaName());
                using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
                {
                    bool __tmp28_first = true;
                    while(__tmp28_first || !__tmp28Reader.EndOfStream)
                    {
                        __tmp28_first = false;
                        string __tmp28Line = __tmp28Reader.ReadLine();
                        if (__tmp28Line == null)
                        {
                            __tmp28Line = "";
                        }
                        __out.Append(__tmp26Prefix);
                        __out.Append(__tmp28Line);
                    }
                }
                string __tmp29Line = "("; //922:33
                __out.Append(__tmp29Line);
                StringBuilder __tmp30 = new StringBuilder();
                __tmp30.Append(cls.JavaName());
                using(StreamReader __tmp30Reader = new StreamReader(this.__ToStream(__tmp30.ToString())))
                {
                    bool __tmp30_first = true;
                    while(__tmp30_first || !__tmp30Reader.EndOfStream)
                    {
                        __tmp30_first = false;
                        string __tmp30Line = __tmp30Reader.ReadLine();
                        if (__tmp30Line == null)
                        {
                            __tmp30Line = "";
                        }
                        __out.Append(__tmp30Line);
                        __out.Append(__tmp27Suffix);
                        __out.AppendLine(); //922:59
                    }
                }
                var __loop52_results = 
                    (from __loop52_var1 in __Enumerate((cls).GetEnumerator()) //923:9
                    from sup in __Enumerate((__loop52_var1.SuperClasses).GetEnumerator()) //923:14
                    select new { __loop52_var1 = __loop52_var1, sup = sup}
                    ).ToList(); //923:4
                int __loop52_iteration = 0;
                foreach (var __tmp31 in __loop52_results)
                {
                    ++__loop52_iteration;
                    var __loop52_var1 = __tmp31.__loop52_var1;
                    var sup = __tmp31.sup;
                    string __tmp32Prefix = "        this."; //924:1
                    string __tmp33Suffix = "(_this);"; //924:30
                    StringBuilder __tmp34 = new StringBuilder();
                    __tmp34.Append(sup.JavaName());
                    using(StreamReader __tmp34Reader = new StreamReader(this.__ToStream(__tmp34.ToString())))
                    {
                        bool __tmp34_first = true;
                        while(__tmp34_first || !__tmp34Reader.EndOfStream)
                        {
                            __tmp34_first = false;
                            string __tmp34Line = __tmp34Reader.ReadLine();
                            if (__tmp34Line == null)
                            {
                                __tmp34Line = "";
                            }
                            __out.Append(__tmp32Prefix);
                            __out.Append(__tmp34Line);
                            __out.Append(__tmp33Suffix);
                            __out.AppendLine(); //924:38
                        }
                    }
                }
                __out.Append("    }"); //926:1
                __out.AppendLine(); //926:6
                var __loop53_results = 
                    (from __loop53_var1 in __Enumerate((cls).GetEnumerator()) //927:11
                    from prop in __Enumerate((__loop53_var1.Properties).GetEnumerator()) //927:16
                    select new { __loop53_var1 = __loop53_var1, prop = prop}
                    ).ToList(); //927:6
                int __loop53_iteration = 0;
                foreach (var __tmp35 in __loop53_results)
                {
                    ++__loop53_iteration;
                    var __loop53_var1 = __tmp35.__loop53_var1;
                    var prop = __tmp35.prop;
                    MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //928:4
                    if (synInit == null) //929:4
                    {
                        if (prop.Kind == MetaPropertyKind.Derived) //930:5
                        {
                            __out.AppendLine(); //931:1
                            __out.Append("    /**"); //932:1
                            __out.AppendLine(); //932:8
                            string __tmp36Prefix = "     * Returns the value of the derived property: "; //933:1
                            string __tmp37Suffix = string.Empty; 
                            StringBuilder __tmp38 = new StringBuilder();
                            __tmp38.Append(cls.JavaName());
                            using(StreamReader __tmp38Reader = new StreamReader(this.__ToStream(__tmp38.ToString())))
                            {
                                bool __tmp38_first = true;
                                while(__tmp38_first || !__tmp38Reader.EndOfStream)
                                {
                                    __tmp38_first = false;
                                    string __tmp38Line = __tmp38Reader.ReadLine();
                                    if (__tmp38Line == null)
                                    {
                                        __tmp38Line = "";
                                    }
                                    __out.Append(__tmp36Prefix);
                                    __out.Append(__tmp38Line);
                                }
                            }
                            string __tmp39Line = "."; //933:67
                            __out.Append(__tmp39Line);
                            StringBuilder __tmp40 = new StringBuilder();
                            __tmp40.Append(prop.Name);
                            using(StreamReader __tmp40Reader = new StreamReader(this.__ToStream(__tmp40.ToString())))
                            {
                                bool __tmp40_first = true;
                                while(__tmp40_first || !__tmp40Reader.EndOfStream)
                                {
                                    __tmp40_first = false;
                                    string __tmp40Line = __tmp40Reader.ReadLine();
                                    if (__tmp40Line == null)
                                    {
                                        __tmp40Line = "";
                                    }
                                    __out.Append(__tmp40Line);
                                    __out.Append(__tmp37Suffix);
                                    __out.AppendLine(); //933:79
                                }
                            }
                            __out.Append("     */"); //934:1
                            __out.AppendLine(); //934:8
                            string __tmp41Prefix = "    public "; //935:1
                            string __tmp42Suffix = " _this) {"; //935:90
                            StringBuilder __tmp43 = new StringBuilder();
                            __tmp43.Append(prop.Type.JavaFullPublicName());
                            using(StreamReader __tmp43Reader = new StreamReader(this.__ToStream(__tmp43.ToString())))
                            {
                                bool __tmp43_first = true;
                                while(__tmp43_first || !__tmp43Reader.EndOfStream)
                                {
                                    __tmp43_first = false;
                                    string __tmp43Line = __tmp43Reader.ReadLine();
                                    if (__tmp43Line == null)
                                    {
                                        __tmp43Line = "";
                                    }
                                    __out.Append(__tmp41Prefix);
                                    __out.Append(__tmp43Line);
                                }
                            }
                            string __tmp44Line = " "; //935:44
                            __out.Append(__tmp44Line);
                            StringBuilder __tmp45 = new StringBuilder();
                            __tmp45.Append(cls.JavaName());
                            using(StreamReader __tmp45Reader = new StreamReader(this.__ToStream(__tmp45.ToString())))
                            {
                                bool __tmp45_first = true;
                                while(__tmp45_first || !__tmp45Reader.EndOfStream)
                                {
                                    __tmp45_first = false;
                                    string __tmp45Line = __tmp45Reader.ReadLine();
                                    if (__tmp45Line == null)
                                    {
                                        __tmp45Line = "";
                                    }
                                    __out.Append(__tmp45Line);
                                }
                            }
                            string __tmp46Line = "_"; //935:61
                            __out.Append(__tmp46Line);
                            StringBuilder __tmp47 = new StringBuilder();
                            __tmp47.Append(prop.Name);
                            using(StreamReader __tmp47Reader = new StreamReader(this.__ToStream(__tmp47.ToString())))
                            {
                                bool __tmp47_first = true;
                                while(__tmp47_first || !__tmp47Reader.EndOfStream)
                                {
                                    __tmp47_first = false;
                                    string __tmp47Line = __tmp47Reader.ReadLine();
                                    if (__tmp47Line == null)
                                    {
                                        __tmp47Line = "";
                                    }
                                    __out.Append(__tmp47Line);
                                }
                            }
                            string __tmp48Line = "("; //935:73
                            __out.Append(__tmp48Line);
                            StringBuilder __tmp49 = new StringBuilder();
                            __tmp49.Append(cls.JavaName());
                            using(StreamReader __tmp49Reader = new StreamReader(this.__ToStream(__tmp49.ToString())))
                            {
                                bool __tmp49_first = true;
                                while(__tmp49_first || !__tmp49Reader.EndOfStream)
                                {
                                    __tmp49_first = false;
                                    string __tmp49Line = __tmp49Reader.ReadLine();
                                    if (__tmp49Line == null)
                                    {
                                        __tmp49Line = "";
                                    }
                                    __out.Append(__tmp49Line);
                                    __out.Append(__tmp42Suffix);
                                    __out.AppendLine(); //935:99
                                }
                            }
                            __out.Append("        throw new UnsupportedOperationException();"); //936:1
                            __out.AppendLine(); //936:51
                            __out.Append("    }"); //937:1
                            __out.AppendLine(); //937:6
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //938:5
                        {
                            __out.AppendLine(); //939:1
                            __out.Append("    /**"); //940:1
                            __out.AppendLine(); //940:8
                            string __tmp50Prefix = "     * Returns the value of the lazy property: "; //941:1
                            string __tmp51Suffix = string.Empty; 
                            StringBuilder __tmp52 = new StringBuilder();
                            __tmp52.Append(cls.JavaName());
                            using(StreamReader __tmp52Reader = new StreamReader(this.__ToStream(__tmp52.ToString())))
                            {
                                bool __tmp52_first = true;
                                while(__tmp52_first || !__tmp52Reader.EndOfStream)
                                {
                                    __tmp52_first = false;
                                    string __tmp52Line = __tmp52Reader.ReadLine();
                                    if (__tmp52Line == null)
                                    {
                                        __tmp52Line = "";
                                    }
                                    __out.Append(__tmp50Prefix);
                                    __out.Append(__tmp52Line);
                                }
                            }
                            string __tmp53Line = "."; //941:64
                            __out.Append(__tmp53Line);
                            StringBuilder __tmp54 = new StringBuilder();
                            __tmp54.Append(prop.Name);
                            using(StreamReader __tmp54Reader = new StreamReader(this.__ToStream(__tmp54.ToString())))
                            {
                                bool __tmp54_first = true;
                                while(__tmp54_first || !__tmp54Reader.EndOfStream)
                                {
                                    __tmp54_first = false;
                                    string __tmp54Line = __tmp54Reader.ReadLine();
                                    if (__tmp54Line == null)
                                    {
                                        __tmp54Line = "";
                                    }
                                    __out.Append(__tmp54Line);
                                    __out.Append(__tmp51Suffix);
                                    __out.AppendLine(); //941:76
                                }
                            }
                            __out.Append("     */"); //942:1
                            __out.AppendLine(); //942:8
                            string __tmp55Prefix = "    public "; //943:1
                            string __tmp56Suffix = " _this) {"; //943:90
                            StringBuilder __tmp57 = new StringBuilder();
                            __tmp57.Append(prop.Type.JavaFullPublicName());
                            using(StreamReader __tmp57Reader = new StreamReader(this.__ToStream(__tmp57.ToString())))
                            {
                                bool __tmp57_first = true;
                                while(__tmp57_first || !__tmp57Reader.EndOfStream)
                                {
                                    __tmp57_first = false;
                                    string __tmp57Line = __tmp57Reader.ReadLine();
                                    if (__tmp57Line == null)
                                    {
                                        __tmp57Line = "";
                                    }
                                    __out.Append(__tmp55Prefix);
                                    __out.Append(__tmp57Line);
                                }
                            }
                            string __tmp58Line = " "; //943:44
                            __out.Append(__tmp58Line);
                            StringBuilder __tmp59 = new StringBuilder();
                            __tmp59.Append(cls.JavaName());
                            using(StreamReader __tmp59Reader = new StreamReader(this.__ToStream(__tmp59.ToString())))
                            {
                                bool __tmp59_first = true;
                                while(__tmp59_first || !__tmp59Reader.EndOfStream)
                                {
                                    __tmp59_first = false;
                                    string __tmp59Line = __tmp59Reader.ReadLine();
                                    if (__tmp59Line == null)
                                    {
                                        __tmp59Line = "";
                                    }
                                    __out.Append(__tmp59Line);
                                }
                            }
                            string __tmp60Line = "_"; //943:61
                            __out.Append(__tmp60Line);
                            StringBuilder __tmp61 = new StringBuilder();
                            __tmp61.Append(prop.Name);
                            using(StreamReader __tmp61Reader = new StreamReader(this.__ToStream(__tmp61.ToString())))
                            {
                                bool __tmp61_first = true;
                                while(__tmp61_first || !__tmp61Reader.EndOfStream)
                                {
                                    __tmp61_first = false;
                                    string __tmp61Line = __tmp61Reader.ReadLine();
                                    if (__tmp61Line == null)
                                    {
                                        __tmp61Line = "";
                                    }
                                    __out.Append(__tmp61Line);
                                }
                            }
                            string __tmp62Line = "("; //943:73
                            __out.Append(__tmp62Line);
                            StringBuilder __tmp63 = new StringBuilder();
                            __tmp63.Append(cls.JavaName());
                            using(StreamReader __tmp63Reader = new StreamReader(this.__ToStream(__tmp63.ToString())))
                            {
                                bool __tmp63_first = true;
                                while(__tmp63_first || !__tmp63Reader.EndOfStream)
                                {
                                    __tmp63_first = false;
                                    string __tmp63Line = __tmp63Reader.ReadLine();
                                    if (__tmp63Line == null)
                                    {
                                        __tmp63Line = "";
                                    }
                                    __out.Append(__tmp63Line);
                                    __out.Append(__tmp56Suffix);
                                    __out.AppendLine(); //943:99
                                }
                            }
                            __out.Append("        throw new UnsupportedOperationException();"); //944:1
                            __out.AppendLine(); //944:51
                            __out.Append("    }"); //945:1
                            __out.AppendLine(); //945:6
                        }
                    }
                }
                var __loop54_results = 
                    (from __loop54_var1 in __Enumerate((cls).GetEnumerator()) //949:11
                    from op in __Enumerate((__loop54_var1.Operations).GetEnumerator()) //949:16
                    select new { __loop54_var1 = __loop54_var1, op = op}
                    ).ToList(); //949:6
                int __loop54_iteration = 0;
                foreach (var __tmp64 in __loop54_results)
                {
                    ++__loop54_iteration;
                    var __loop54_var1 = __tmp64.__loop54_var1;
                    var op = __tmp64.op;
                    __out.AppendLine(); //950:1
                    __out.Append("    /**"); //951:1
                    __out.AppendLine(); //951:8
                    string __tmp65Prefix = "     * Implements the operation: "; //952:1
                    string __tmp66Suffix = "()"; //952:60
                    StringBuilder __tmp67 = new StringBuilder();
                    __tmp67.Append(cls.JavaName());
                    using(StreamReader __tmp67Reader = new StreamReader(this.__ToStream(__tmp67.ToString())))
                    {
                        bool __tmp67_first = true;
                        while(__tmp67_first || !__tmp67Reader.EndOfStream)
                        {
                            __tmp67_first = false;
                            string __tmp67Line = __tmp67Reader.ReadLine();
                            if (__tmp67Line == null)
                            {
                                __tmp67Line = "";
                            }
                            __out.Append(__tmp65Prefix);
                            __out.Append(__tmp67Line);
                        }
                    }
                    string __tmp68Line = "."; //952:50
                    __out.Append(__tmp68Line);
                    StringBuilder __tmp69 = new StringBuilder();
                    __tmp69.Append(op.Name);
                    using(StreamReader __tmp69Reader = new StreamReader(this.__ToStream(__tmp69.ToString())))
                    {
                        bool __tmp69_first = true;
                        while(__tmp69_first || !__tmp69Reader.EndOfStream)
                        {
                            __tmp69_first = false;
                            string __tmp69Line = __tmp69Reader.ReadLine();
                            if (__tmp69Line == null)
                            {
                                __tmp69Line = "";
                            }
                            __out.Append(__tmp69Line);
                            __out.Append(__tmp66Suffix);
                            __out.AppendLine(); //952:62
                        }
                    }
                    __out.Append("     */"); //953:1
                    __out.AppendLine(); //953:8
                    string __tmp70Prefix = "    public "; //954:1
                    string __tmp71Suffix = ") {"; //954:118
                    StringBuilder __tmp72 = new StringBuilder();
                    __tmp72.Append(op.ReturnType.JavaFullPublicName());
                    using(StreamReader __tmp72Reader = new StreamReader(this.__ToStream(__tmp72.ToString())))
                    {
                        bool __tmp72_first = true;
                        while(__tmp72_first || !__tmp72Reader.EndOfStream)
                        {
                            __tmp72_first = false;
                            string __tmp72Line = __tmp72Reader.ReadLine();
                            if (__tmp72Line == null)
                            {
                                __tmp72Line = "";
                            }
                            __out.Append(__tmp70Prefix);
                            __out.Append(__tmp72Line);
                        }
                    }
                    string __tmp73Line = " "; //954:48
                    __out.Append(__tmp73Line);
                    StringBuilder __tmp74 = new StringBuilder();
                    __tmp74.Append(cls.JavaName());
                    using(StreamReader __tmp74Reader = new StreamReader(this.__ToStream(__tmp74.ToString())))
                    {
                        bool __tmp74_first = true;
                        while(__tmp74_first || !__tmp74Reader.EndOfStream)
                        {
                            __tmp74_first = false;
                            string __tmp74Line = __tmp74Reader.ReadLine();
                            if (__tmp74Line == null)
                            {
                                __tmp74Line = "";
                            }
                            __out.Append(__tmp74Line);
                        }
                    }
                    string __tmp75Line = "_"; //954:65
                    __out.Append(__tmp75Line);
                    StringBuilder __tmp76 = new StringBuilder();
                    __tmp76.Append(op.Name.ToCamelCase());
                    using(StreamReader __tmp76Reader = new StreamReader(this.__ToStream(__tmp76.ToString())))
                    {
                        bool __tmp76_first = true;
                        while(__tmp76_first || !__tmp76Reader.EndOfStream)
                        {
                            __tmp76_first = false;
                            string __tmp76Line = __tmp76Reader.ReadLine();
                            if (__tmp76Line == null)
                            {
                                __tmp76Line = "";
                            }
                            __out.Append(__tmp76Line);
                        }
                    }
                    string __tmp77Line = "("; //954:89
                    __out.Append(__tmp77Line);
                    StringBuilder __tmp78 = new StringBuilder();
                    __tmp78.Append(GetImplParameters(cls, op));
                    using(StreamReader __tmp78Reader = new StreamReader(this.__ToStream(__tmp78.ToString())))
                    {
                        bool __tmp78_first = true;
                        while(__tmp78_first || !__tmp78Reader.EndOfStream)
                        {
                            __tmp78_first = false;
                            string __tmp78Line = __tmp78Reader.ReadLine();
                            if (__tmp78Line == null)
                            {
                                __tmp78Line = "";
                            }
                            __out.Append(__tmp78Line);
                            __out.Append(__tmp71Suffix);
                            __out.AppendLine(); //954:121
                        }
                    }
                    __out.Append("        throw new UnsupportedOperationException();"); //955:1
                    __out.AppendLine(); //955:51
                    __out.Append("    }"); //956:1
                    __out.AppendLine(); //956:6
                }
                __out.AppendLine(); //958:1
            }
            var __loop55_results = 
                (from __loop55_var1 in __Enumerate((model).GetEnumerator()) //960:8
                from Namespace in __Enumerate((__loop55_var1.Namespace).GetEnumerator()) //960:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //960:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //960:40
                select new { __loop55_var1 = __loop55_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //960:3
            int __loop55_iteration = 0;
            foreach (var __tmp79 in __loop55_results)
            {
                ++__loop55_iteration;
                var __loop55_var1 = __tmp79.__loop55_var1;
                var Namespace = __tmp79.Namespace;
                var Declarations = __tmp79.Declarations;
                var enm = __tmp79.enm;
                var __loop56_results = 
                    (from __loop56_var1 in __Enumerate((enm).GetEnumerator()) //961:11
                    from op in __Enumerate((__loop56_var1.Operations).GetEnumerator()) //961:16
                    select new { __loop56_var1 = __loop56_var1, op = op}
                    ).ToList(); //961:6
                int __loop56_iteration = 0;
                foreach (var __tmp80 in __loop56_results)
                {
                    ++__loop56_iteration;
                    var __loop56_var1 = __tmp80.__loop56_var1;
                    var op = __tmp80.op;
                    __out.AppendLine(); //962:1
                    __out.Append("    /**"); //963:1
                    __out.AppendLine(); //963:8
                    string __tmp81Prefix = "     * Implements the operation: "; //964:1
                    string __tmp82Suffix = string.Empty; 
                    StringBuilder __tmp83 = new StringBuilder();
                    __tmp83.Append(enm.JavaName());
                    using(StreamReader __tmp83Reader = new StreamReader(this.__ToStream(__tmp83.ToString())))
                    {
                        bool __tmp83_first = true;
                        while(__tmp83_first || !__tmp83Reader.EndOfStream)
                        {
                            __tmp83_first = false;
                            string __tmp83Line = __tmp83Reader.ReadLine();
                            if (__tmp83Line == null)
                            {
                                __tmp83Line = "";
                            }
                            __out.Append(__tmp81Prefix);
                            __out.Append(__tmp83Line);
                        }
                    }
                    string __tmp84Line = "."; //964:50
                    __out.Append(__tmp84Line);
                    StringBuilder __tmp85 = new StringBuilder();
                    __tmp85.Append(op.Name);
                    using(StreamReader __tmp85Reader = new StreamReader(this.__ToStream(__tmp85.ToString())))
                    {
                        bool __tmp85_first = true;
                        while(__tmp85_first || !__tmp85Reader.EndOfStream)
                        {
                            __tmp85_first = false;
                            string __tmp85Line = __tmp85Reader.ReadLine();
                            if (__tmp85Line == null)
                            {
                                __tmp85Line = "";
                            }
                            __out.Append(__tmp85Line);
                            __out.Append(__tmp82Suffix);
                            __out.AppendLine(); //964:60
                        }
                    }
                    __out.Append("     */"); //965:1
                    __out.AppendLine(); //965:8
                    string __tmp86Prefix = "    public "; //966:1
                    string __tmp87Suffix = ") {"; //966:118
                    StringBuilder __tmp88 = new StringBuilder();
                    __tmp88.Append(op.ReturnType.JavaFullPublicName());
                    using(StreamReader __tmp88Reader = new StreamReader(this.__ToStream(__tmp88.ToString())))
                    {
                        bool __tmp88_first = true;
                        while(__tmp88_first || !__tmp88Reader.EndOfStream)
                        {
                            __tmp88_first = false;
                            string __tmp88Line = __tmp88Reader.ReadLine();
                            if (__tmp88Line == null)
                            {
                                __tmp88Line = "";
                            }
                            __out.Append(__tmp86Prefix);
                            __out.Append(__tmp88Line);
                        }
                    }
                    string __tmp89Line = " "; //966:48
                    __out.Append(__tmp89Line);
                    StringBuilder __tmp90 = new StringBuilder();
                    __tmp90.Append(enm.JavaName());
                    using(StreamReader __tmp90Reader = new StreamReader(this.__ToStream(__tmp90.ToString())))
                    {
                        bool __tmp90_first = true;
                        while(__tmp90_first || !__tmp90Reader.EndOfStream)
                        {
                            __tmp90_first = false;
                            string __tmp90Line = __tmp90Reader.ReadLine();
                            if (__tmp90Line == null)
                            {
                                __tmp90Line = "";
                            }
                            __out.Append(__tmp90Line);
                        }
                    }
                    string __tmp91Line = "_"; //966:65
                    __out.Append(__tmp91Line);
                    StringBuilder __tmp92 = new StringBuilder();
                    __tmp92.Append(op.Name.ToCamelCase());
                    using(StreamReader __tmp92Reader = new StreamReader(this.__ToStream(__tmp92.ToString())))
                    {
                        bool __tmp92_first = true;
                        while(__tmp92_first || !__tmp92Reader.EndOfStream)
                        {
                            __tmp92_first = false;
                            string __tmp92Line = __tmp92Reader.ReadLine();
                            if (__tmp92Line == null)
                            {
                                __tmp92Line = "";
                            }
                            __out.Append(__tmp92Line);
                        }
                    }
                    string __tmp93Line = "("; //966:89
                    __out.Append(__tmp93Line);
                    StringBuilder __tmp94 = new StringBuilder();
                    __tmp94.Append(GetImplParameters(enm, op));
                    using(StreamReader __tmp94Reader = new StreamReader(this.__ToStream(__tmp94.ToString())))
                    {
                        bool __tmp94_first = true;
                        while(__tmp94_first || !__tmp94Reader.EndOfStream)
                        {
                            __tmp94_first = false;
                            string __tmp94Line = __tmp94Reader.ReadLine();
                            if (__tmp94Line == null)
                            {
                                __tmp94Line = "";
                            }
                            __out.Append(__tmp94Line);
                            __out.Append(__tmp87Suffix);
                            __out.AppendLine(); //966:121
                        }
                    }
                    __out.Append("        throw new UnsupportedOperationException();"); //967:1
                    __out.AppendLine(); //967:51
                    __out.Append("    }"); //968:1
                    __out.AppendLine(); //968:6
                }
                __out.AppendLine(); //970:1
            }
            __out.Append("}"); //972:1
            __out.AppendLine(); //972:2
            __out.AppendLine(); //973:1
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //976:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "package "; //977:1
            string __tmp2Suffix = ";"; //977:37
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.Namespace.JavaName());
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //977:38
                }
            }
            __out.AppendLine(); //978:1
            __out.Append("/**"); //979:1
            __out.AppendLine(); //979:4
            __out.Append(" * Factory class for creating instances of model elements."); //980:1
            __out.AppendLine(); //980:59
            __out.Append(" */"); //981:1
            __out.AppendLine(); //981:4
            string __tmp4Prefix = "public class "; //982:1
            string __tmp5Suffix = " extends ModelFactory {"; //982:39
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(model.JavaFactoryName());
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                while(__tmp6_first || !__tmp6Reader.EndOfStream)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    if (__tmp6Line == null)
                    {
                        __tmp6Line = "";
                    }
                    __out.Append(__tmp4Prefix);
                    __out.Append(__tmp6Line);
                    __out.Append(__tmp5Suffix);
                    __out.AppendLine(); //982:62
                }
            }
            string __tmp7Prefix = "    private static "; //983:1
            string __tmp8Suffix = "();"; //983:86
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(model.JavaFactoryName());
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_first = true;
                while(__tmp9_first || !__tmp9Reader.EndOfStream)
                {
                    __tmp9_first = false;
                    string __tmp9Line = __tmp9Reader.ReadLine();
                    if (__tmp9Line == null)
                    {
                        __tmp9Line = "";
                    }
                    __out.Append(__tmp7Prefix);
                    __out.Append(__tmp9Line);
                }
            }
            string __tmp10Line = " instance = new "; //983:45
            __out.Append(__tmp10Line);
            StringBuilder __tmp11 = new StringBuilder();
            __tmp11.Append(model.JavaFactoryName());
            using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
            {
                bool __tmp11_first = true;
                while(__tmp11_first || !__tmp11Reader.EndOfStream)
                {
                    __tmp11_first = false;
                    string __tmp11Line = __tmp11Reader.ReadLine();
                    if (__tmp11Line == null)
                    {
                        __tmp11Line = "";
                    }
                    __out.Append(__tmp11Line);
                    __out.Append(__tmp8Suffix);
                    __out.AppendLine(); //983:89
                }
            }
            __out.AppendLine(); //984:1
            string __tmp12Prefix = "	private "; //985:1
            string __tmp13Suffix = "()"; //985:35
            StringBuilder __tmp14 = new StringBuilder();
            __tmp14.Append(model.JavaFactoryName());
            using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
            {
                bool __tmp14_first = true;
                while(__tmp14_first || !__tmp14Reader.EndOfStream)
                {
                    __tmp14_first = false;
                    string __tmp14Line = __tmp14Reader.ReadLine();
                    if (__tmp14Line == null)
                    {
                        __tmp14Line = "";
                    }
                    __out.Append(__tmp12Prefix);
                    __out.Append(__tmp14Line);
                    __out.Append(__tmp13Suffix);
                    __out.AppendLine(); //985:37
                }
            }
            __out.Append("	{"); //986:1
            __out.AppendLine(); //986:3
            __out.Append("	}"); //987:1
            __out.AppendLine(); //987:3
            __out.AppendLine(); //988:1
            __out.Append("    /**"); //989:1
            __out.AppendLine(); //989:8
            __out.Append("     * The singleton instance of the factory."); //990:1
            __out.AppendLine(); //990:46
            __out.Append("     */"); //991:1
            __out.AppendLine(); //991:8
            string __tmp15Prefix = "    public static "; //992:1
            string __tmp16Suffix = " instance() {"; //992:44
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(model.JavaFactoryName());
            using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
            {
                bool __tmp17_first = true;
                while(__tmp17_first || !__tmp17Reader.EndOfStream)
                {
                    __tmp17_first = false;
                    string __tmp17Line = __tmp17Reader.ReadLine();
                    if (__tmp17Line == null)
                    {
                        __tmp17Line = "";
                    }
                    __out.Append(__tmp15Prefix);
                    __out.Append(__tmp17Line);
                    __out.Append(__tmp16Suffix);
                    __out.AppendLine(); //992:57
                }
            }
            string __tmp18Prefix = "        return "; //993:1
            string __tmp19Suffix = ".instance;"; //993:41
            StringBuilder __tmp20 = new StringBuilder();
            __tmp20.Append(model.JavaFactoryName());
            using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
            {
                bool __tmp20_first = true;
                while(__tmp20_first || !__tmp20Reader.EndOfStream)
                {
                    __tmp20_first = false;
                    string __tmp20Line = __tmp20Reader.ReadLine();
                    if (__tmp20Line == null)
                    {
                        __tmp20Line = "";
                    }
                    __out.Append(__tmp18Prefix);
                    __out.Append(__tmp20Line);
                    __out.Append(__tmp19Suffix);
                    __out.AppendLine(); //993:51
                }
            }
            __out.Append("    }"); //994:1
            __out.AppendLine(); //994:6
            var __loop57_results = 
                (from __loop57_var1 in __Enumerate((model).GetEnumerator()) //995:8
                from Namespace in __Enumerate((__loop57_var1.Namespace).GetEnumerator()) //995:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //995:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //995:40
                select new { __loop57_var1 = __loop57_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //995:3
            int __loop57_iteration = 0;
            foreach (var __tmp21 in __loop57_results)
            {
                ++__loop57_iteration;
                var __loop57_var1 = __tmp21.__loop57_var1;
                var Namespace = __tmp21.Namespace;
                var Declarations = __tmp21.Declarations;
                var cls = __tmp21.cls;
                if (!cls.IsAbstract) //996:4
                {
                    __out.AppendLine(); //997:1
                    __out.Append("    /**"); //998:1
                    __out.AppendLine(); //998:8
                    string __tmp22Prefix = "     * Creates a new instance of "; //999:1
                    string __tmp23Suffix = "."; //999:50
                    StringBuilder __tmp24 = new StringBuilder();
                    __tmp24.Append(cls.JavaName());
                    using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
                    {
                        bool __tmp24_first = true;
                        while(__tmp24_first || !__tmp24Reader.EndOfStream)
                        {
                            __tmp24_first = false;
                            string __tmp24Line = __tmp24Reader.ReadLine();
                            if (__tmp24Line == null)
                            {
                                __tmp24Line = "";
                            }
                            __out.Append(__tmp22Prefix);
                            __out.Append(__tmp24Line);
                            __out.Append(__tmp23Suffix);
                            __out.AppendLine(); //999:51
                        }
                    }
                    __out.Append("     */"); //1000:1
                    __out.AppendLine(); //1000:8
                    string __tmp25Prefix = "    public "; //1001:1
                    string __tmp26Suffix = "() {"; //1001:51
                    StringBuilder __tmp27 = new StringBuilder();
                    __tmp27.Append(cls.JavaName());
                    using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
                    {
                        bool __tmp27_first = true;
                        while(__tmp27_first || !__tmp27Reader.EndOfStream)
                        {
                            __tmp27_first = false;
                            string __tmp27Line = __tmp27Reader.ReadLine();
                            if (__tmp27Line == null)
                            {
                                __tmp27Line = "";
                            }
                            __out.Append(__tmp25Prefix);
                            __out.Append(__tmp27Line);
                        }
                    }
                    string __tmp28Line = " create"; //1001:28
                    __out.Append(__tmp28Line);
                    StringBuilder __tmp29 = new StringBuilder();
                    __tmp29.Append(cls.JavaName());
                    using(StreamReader __tmp29Reader = new StreamReader(this.__ToStream(__tmp29.ToString())))
                    {
                        bool __tmp29_first = true;
                        while(__tmp29_first || !__tmp29Reader.EndOfStream)
                        {
                            __tmp29_first = false;
                            string __tmp29Line = __tmp29Reader.ReadLine();
                            if (__tmp29Line == null)
                            {
                                __tmp29Line = "";
                            }
                            __out.Append(__tmp29Line);
                            __out.Append(__tmp26Suffix);
                            __out.AppendLine(); //1001:55
                        }
                    }
                    string __tmp30Prefix = "		return this.create"; //1002:1
                    string __tmp31Suffix = "(null);"; //1002:37
                    StringBuilder __tmp32 = new StringBuilder();
                    __tmp32.Append(cls.JavaName());
                    using(StreamReader __tmp32Reader = new StreamReader(this.__ToStream(__tmp32.ToString())))
                    {
                        bool __tmp32_first = true;
                        while(__tmp32_first || !__tmp32Reader.EndOfStream)
                        {
                            __tmp32_first = false;
                            string __tmp32Line = __tmp32Reader.ReadLine();
                            if (__tmp32Line == null)
                            {
                                __tmp32Line = "";
                            }
                            __out.Append(__tmp30Prefix);
                            __out.Append(__tmp32Line);
                            __out.Append(__tmp31Suffix);
                            __out.AppendLine(); //1002:44
                        }
                    }
                    __out.Append("	}"); //1003:1
                    __out.AppendLine(); //1003:3
                    __out.Append("    /**"); //1005:1
                    __out.AppendLine(); //1005:8
                    string __tmp33Prefix = "     * Creates a new instance of "; //1006:1
                    string __tmp34Suffix = "."; //1006:50
                    StringBuilder __tmp35 = new StringBuilder();
                    __tmp35.Append(cls.JavaName());
                    using(StreamReader __tmp35Reader = new StreamReader(this.__ToStream(__tmp35.ToString())))
                    {
                        bool __tmp35_first = true;
                        while(__tmp35_first || !__tmp35Reader.EndOfStream)
                        {
                            __tmp35_first = false;
                            string __tmp35Line = __tmp35Reader.ReadLine();
                            if (__tmp35Line == null)
                            {
                                __tmp35Line = "";
                            }
                            __out.Append(__tmp33Prefix);
                            __out.Append(__tmp35Line);
                            __out.Append(__tmp34Suffix);
                            __out.AppendLine(); //1006:51
                        }
                    }
                    __out.Append("     */"); //1007:1
                    __out.AppendLine(); //1007:8
                    string __tmp36Prefix = "    public "; //1008:1
                    string __tmp37Suffix = "(Iterable<ModelPropertyInitializer> initializers) {"; //1008:51
                    StringBuilder __tmp38 = new StringBuilder();
                    __tmp38.Append(cls.JavaName());
                    using(StreamReader __tmp38Reader = new StreamReader(this.__ToStream(__tmp38.ToString())))
                    {
                        bool __tmp38_first = true;
                        while(__tmp38_first || !__tmp38Reader.EndOfStream)
                        {
                            __tmp38_first = false;
                            string __tmp38Line = __tmp38Reader.ReadLine();
                            if (__tmp38Line == null)
                            {
                                __tmp38Line = "";
                            }
                            __out.Append(__tmp36Prefix);
                            __out.Append(__tmp38Line);
                        }
                    }
                    string __tmp39Line = " create"; //1008:28
                    __out.Append(__tmp39Line);
                    StringBuilder __tmp40 = new StringBuilder();
                    __tmp40.Append(cls.JavaName());
                    using(StreamReader __tmp40Reader = new StreamReader(this.__ToStream(__tmp40.ToString())))
                    {
                        bool __tmp40_first = true;
                        while(__tmp40_first || !__tmp40Reader.EndOfStream)
                        {
                            __tmp40_first = false;
                            string __tmp40Line = __tmp40Reader.ReadLine();
                            if (__tmp40Line == null)
                            {
                                __tmp40Line = "";
                            }
                            __out.Append(__tmp40Line);
                            __out.Append(__tmp37Suffix);
                            __out.AppendLine(); //1008:102
                        }
                    }
                    string __tmp41Prefix = "		"; //1009:1
                    string __tmp42Suffix = "Impl();"; //1009:53
                    StringBuilder __tmp43 = new StringBuilder();
                    __tmp43.Append(cls.JavaName());
                    using(StreamReader __tmp43Reader = new StreamReader(this.__ToStream(__tmp43.ToString())))
                    {
                        bool __tmp43_first = true;
                        while(__tmp43_first || !__tmp43Reader.EndOfStream)
                        {
                            __tmp43_first = false;
                            string __tmp43Line = __tmp43Reader.ReadLine();
                            if (__tmp43Line == null)
                            {
                                __tmp43Line = "";
                            }
                            __out.Append(__tmp41Prefix);
                            __out.Append(__tmp43Line);
                        }
                    }
                    string __tmp44Line = " result = new "; //1009:19
                    __out.Append(__tmp44Line);
                    StringBuilder __tmp45 = new StringBuilder();
                    __tmp45.Append(cls.JavaFullName());
                    using(StreamReader __tmp45Reader = new StreamReader(this.__ToStream(__tmp45.ToString())))
                    {
                        bool __tmp45_first = true;
                        while(__tmp45_first || !__tmp45Reader.EndOfStream)
                        {
                            __tmp45_first = false;
                            string __tmp45Line = __tmp45Reader.ReadLine();
                            if (__tmp45Line == null)
                            {
                                __tmp45Line = "";
                            }
                            __out.Append(__tmp45Line);
                            __out.Append(__tmp42Suffix);
                            __out.AppendLine(); //1009:60
                        }
                    }
                    __out.Append("		if (initializers != null) {"); //1010:1
                    __out.AppendLine(); //1010:30
                    __out.Append("			this.init((ModelObject)result, initializers);"); //1011:1
                    __out.AppendLine(); //1011:49
                    __out.Append("		}"); //1012:1
                    __out.AppendLine(); //1012:4
                    __out.Append("		return result;"); //1013:1
                    __out.AppendLine(); //1013:17
                    __out.Append("	}"); //1014:1
                    __out.AppendLine(); //1014:3
                }
            }
            __out.Append("}"); //1017:1
            __out.AppendLine(); //1017:2
            __out.AppendLine(); //1018:1
            return __out.ToString();
        }

    }
}
