using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core //1:1
{
    using __Hidden_MetaModelGenerator_1554364042;
    namespace __Hidden_MetaModelGenerator_1554364042
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

    public class MetaModelGenerator //2:1
    {
        private IEnumerable<MetaModel> Instances; //2:1
        public MetaModelGenerator(IEnumerable<MetaModel> instances) //2:1
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
            __out.AppendLine(); //5:14
            __out.Append("using System.Collections.Generic;"); //6:1
            __out.AppendLine(); //6:34
            __out.Append("using System.IO;"); //7:1
            __out.AppendLine(); //7:17
            __out.Append("using System.Linq;"); //8:1
            __out.AppendLine(); //8:19
            __out.Append("using System.Text;"); //9:1
            __out.AppendLine(); //9:19
            __out.Append("using System.Threading.Tasks;"); //10:1
            __out.AppendLine(); //10:30
            __out.AppendLine(); //11:2
            var __loop1_results = 
                (from mm in __Enumerate((Instances).GetEnumerator()) //12:8
                select new { mm = mm}
                ).ToList(); //12:3
            int __loop1_iteration = 0;
            foreach (var __tmp1 in __loop1_results)
            {
                ++__loop1_iteration;
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
                        __out.AppendLine(); //13:24
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateMetamodel(MetaModel model) //17:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "namespace "; //18:1
            string __tmp2Suffix = string.Empty; 
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.Namespace.CSharpName());
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
                    __out.AppendLine(); //18:41
                }
            }
            __out.Append("{"); //19:1
            __out.AppendLine(); //19:2
            string __tmp4Prefix = "    "; //20:1
            string __tmp5Suffix = string.Empty; 
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(GenerateMetaModel(model));
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
                    __out.AppendLine(); //20:31
                }
            }
            var __loop2_results = 
                (from __loop2_var1 in __Enumerate((model).GetEnumerator()) //21:8
                from Types in __Enumerate((__loop2_var1.Types).GetEnumerator()) //21:15
                from enm in __Enumerate((Types).GetEnumerator()).OfType<MetaEnum>() //21:22
                select new { __loop2_var1 = __loop2_var1, Types = Types, enm = enm}
                ).ToList(); //21:3
            int __loop2_iteration = 0;
            foreach (var __tmp7 in __loop2_results)
            {
                ++__loop2_iteration;
                var __loop2_var1 = __tmp7.__loop2_var1;
                var Types = __tmp7.Types;
                var enm = __tmp7.enm;
                string __tmp8Prefix = "    "; //22:1
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
                        __out.AppendLine(); //22:24
                    }
                }
            }
            var __loop3_results = 
                (from __loop3_var1 in __Enumerate((model).GetEnumerator()) //24:8
                from Types in __Enumerate((__loop3_var1.Types).GetEnumerator()) //24:15
                from cls in __Enumerate((Types).GetEnumerator()).OfType<MetaClass>() //24:22
                select new { __loop3_var1 = __loop3_var1, Types = Types, cls = cls}
                ).ToList(); //24:3
            int __loop3_iteration = 0;
            foreach (var __tmp11 in __loop3_results)
            {
                ++__loop3_iteration;
                var __loop3_var1 = __tmp11.__loop3_var1;
                var Types = __tmp11.Types;
                var cls = __tmp11.cls;
                string __tmp12Prefix = "    "; //25:1
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
                        __out.AppendLine(); //25:29
                    }
                }
                string __tmp15Prefix = "    "; //26:1
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
                        __out.AppendLine(); //26:40
                    }
                }
            }
            string __tmp18Prefix = "    "; //28:1
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
                    __out.AppendLine(); //28:29
                }
            }
            string __tmp21Prefix = "    "; //29:1
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
                    __out.AppendLine(); //29:44
                }
            }
            __out.Append("}"); //30:1
            __out.AppendLine(); //30:2
            return __out.ToString();
        }

        public string GenerateAnnotations(MetaAnnotatedElement elem) //33:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop4_results = 
                (from __loop4_var1 in __Enumerate((elem).GetEnumerator()) //34:7
                from annot in __Enumerate((__loop4_var1.Annotations).GetEnumerator()) //34:13
                select new { __loop4_var1 = __loop4_var1, annot = annot}
                ).ToList(); //34:2
            int __loop4_iteration = 0;
            foreach (var __tmp1 in __loop4_results)
            {
                ++__loop4_iteration;
                var __loop4_var1 = __tmp1.__loop4_var1;
                var annot = __tmp1.annot;
                string __tmp2Prefix = string.Empty; 
                string __tmp3Suffix = string.Empty; 
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
                        __out.Append(__tmp2Prefix);
                        __out.Append(__tmp4Line);
                    }
                }
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(annot.Name);
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
                        __out.Append(__tmp3Suffix);
                        __out.AppendLine(); //35:23
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateEnum(MetaEnum enm) //39:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty;
            string __tmp2Suffix = string.Empty;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateAnnotations(enm));
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
                    __out.AppendLine(); //40:27
                }
            }
            string __tmp4Prefix = "public enum "; //41:1
            string __tmp5Suffix = string.Empty; 
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(enm.CSharpName());
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
                    __out.AppendLine(); //41:31
                }
            }
            __out.Append("{"); //42:1
            __out.AppendLine(); //42:2
            var __loop5_results = 
                (from __loop5_var1 in __Enumerate((enm).GetEnumerator()) //43:11
                from value in __Enumerate((__loop5_var1.EnumLiterals).GetEnumerator()) //43:16
                select new { __loop5_var1 = __loop5_var1, value = value}
                ).ToList(); //43:6
            int __loop5_iteration = 0;
            foreach (var __tmp7 in __loop5_results)
            {
                ++__loop5_iteration;
                var __loop5_var1 = __tmp7.__loop5_var1;
                var value = __tmp7.value;
                string __tmp8Prefix = "    "; //44:1
                string __tmp9Suffix = ","; //44:17
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(value.Name);
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
                        __out.AppendLine(); //44:18
                    }
                }
            }
            __out.Append("}"); //46:1
            __out.AppendLine(); //46:2
            __out.AppendLine(); //47:2
            return __out.ToString();
        }

        public string GetAncestors(MetaClass cls) //50:1
        {
            string result = ""; //51:2
            var __loop6_results = 
                (from __loop6_var1 in __Enumerate((cls).GetEnumerator()) //52:7
                from super in __Enumerate((__loop6_var1.SuperClasses).GetEnumerator()) //52:12
                select new { __loop6_var1 = __loop6_var1, super = super}
                ).ToList(); //52:2
            int __loop6_iteration = 0;
            string delim = " : "; //52:32
            foreach (var __tmp1 in __loop6_results)
            {
                ++__loop6_iteration;
                if (__loop6_iteration >= 2) //52:54
                {
                    delim = ", "; //52:54
                }
                var __loop6_var1 = __tmp1.__loop6_var1;
                var super = __tmp1.super;
                result += delim + super.Namespace.CSharpName() + "." + super.CSharpName(); //53:3
            }
            return result; //55:2
        }

        public string GenerateInterface(MetaClass cls) //58:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty;
            string __tmp2Suffix = string.Empty;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateAnnotations(cls));
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
                    __out.AppendLine(); //59:27
                }
            }
            string __tmp4Prefix = "public interface "; //60:1
            string __tmp5Suffix = string.Empty; 
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(cls.CSharpName());
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
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(GetAncestors(cls));
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
                    __out.Append(__tmp5Suffix);
                    __out.AppendLine(); //60:55
                }
            }
            __out.Append("{"); //61:1
            __out.AppendLine(); //61:2
            var __loop7_results = 
                (from __loop7_var1 in __Enumerate((cls).GetEnumerator()) //62:11
                from prop in __Enumerate((__loop7_var1.Properties).GetEnumerator()) //62:16
                select new { __loop7_var1 = __loop7_var1, prop = prop}
                ).ToList(); //62:6
            int __loop7_iteration = 0;
            foreach (var __tmp8 in __loop7_results)
            {
                ++__loop7_iteration;
                var __loop7_var1 = __tmp8.__loop7_var1;
                var prop = __tmp8.prop;
                string __tmp9Prefix = "    "; //63:1
                string __tmp10Suffix = string.Empty; 
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(GenerateProperty(prop));
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
                        __out.AppendLine(); //63:29
                    }
                }
            }
            __out.AppendLine(); //65:2
            var __loop8_results = 
                (from __loop8_var1 in __Enumerate((cls).GetEnumerator()) //66:11
                from op in __Enumerate((__loop8_var1.Operations).GetEnumerator()) //66:16
                select new { __loop8_var1 = __loop8_var1, op = op}
                ).ToList(); //66:6
            int __loop8_iteration = 0;
            foreach (var __tmp12 in __loop8_results)
            {
                ++__loop8_iteration;
                var __loop8_var1 = __tmp12.__loop8_var1;
                var op = __tmp12.op;
                string __tmp13Prefix = "    "; //67:1
                string __tmp14Suffix = string.Empty; 
                StringBuilder __tmp15 = new StringBuilder();
                __tmp15.Append(GenerateOperation(op));
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
                        __out.Append(__tmp14Suffix);
                        __out.AppendLine(); //67:28
                    }
                }
            }
            __out.Append("}"); //69:1
            __out.AppendLine(); //69:2
            __out.AppendLine(); //70:2
            return __out.ToString();
        }

        public string GenerateProperty(MetaProperty prop) //73:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //74:2
            {
                __out.Append("new "); //75:1
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //77:3
            {
                string __tmp1Prefix = string.Empty; 
                string __tmp2Suffix = " { get; set; }"; //78:43
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(prop.Type.CSharpPublicName());
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
                string __tmp4Line = " "; //78:31
                __out.Append(__tmp4Line);
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(prop.Name);
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
                        __out.AppendLine(); //78:57
                    }
                }
            }
            else //79:3
            {
                string __tmp6Prefix = string.Empty; 
                string __tmp7Suffix = " { get; }"; //80:43
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(prop.Type.CSharpPublicName());
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
                string __tmp9Line = " "; //80:31
                __out.Append(__tmp9Line);
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(prop.Name);
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
                        __out.AppendLine(); //80:52
                    }
                }
            }
            return __out.ToString();
        }

        public string GetParameters(MetaOperation op, bool defaultValues) //84:1
        {
            string result = ""; //85:2
            var __loop9_results = 
                (from __loop9_var1 in __Enumerate((op).GetEnumerator()) //86:7
                from param in __Enumerate((__loop9_var1.Parameters).GetEnumerator()) //86:11
                select new { __loop9_var1 = __loop9_var1, param = param}
                ).ToList(); //86:2
            int __loop9_iteration = 0;
            string delim = ""; //86:29
            foreach (var __tmp1 in __loop9_results)
            {
                ++__loop9_iteration;
                if (__loop9_iteration >= 2) //86:48
                {
                    delim = ", "; //86:48
                }
                var __loop9_var1 = __tmp1.__loop9_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpPublicName() + " " + param.Name; //87:3
            }
            return result; //92:2
        }

        public string GetImplParameters(MetaClass cls, MetaOperation op) //95:1
        {
            string result = cls.CSharpName() + " @this"; //96:2
            string delim = ", "; //97:2
            var __loop10_results = 
                (from __loop10_var1 in __Enumerate((op).GetEnumerator()) //98:7
                from param in __Enumerate((__loop10_var1.Parameters).GetEnumerator()) //98:11
                select new { __loop10_var1 = __loop10_var1, param = param}
                ).ToList(); //98:2
            int __loop10_iteration = 0;
            foreach (var __tmp1 in __loop10_results)
            {
                ++__loop10_iteration;
                var __loop10_var1 = __tmp1.__loop10_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpPublicName() + " " + param.Name; //99:3
            }
            return result; //101:2
        }

        public string GetImplParameters(MetaEnum enm, MetaOperation op) //104:1
        {
            string result = enm.CSharpName() + " @this"; //105:2
            string delim = ", "; //106:2
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((op).GetEnumerator()) //107:7
                from param in __Enumerate((__loop11_var1.Parameters).GetEnumerator()) //107:11
                select new { __loop11_var1 = __loop11_var1, param = param}
                ).ToList(); //107:2
            int __loop11_iteration = 0;
            foreach (var __tmp1 in __loop11_results)
            {
                ++__loop11_iteration;
                var __loop11_var1 = __tmp1.__loop11_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpPublicName() + " " + param.Name; //108:3
            }
            return result; //110:2
        }

        public string GetEnumImplParameters(MetaEnum enm, MetaOperation op) //113:1
        {
            string result = "this " + enm.CSharpName() + " @this"; //114:2
            string delim = ", "; //115:2
            var __loop12_results = 
                (from __loop12_var1 in __Enumerate((op).GetEnumerator()) //116:7
                from param in __Enumerate((__loop12_var1.Parameters).GetEnumerator()) //116:11
                select new { __loop12_var1 = __loop12_var1, param = param}
                ).ToList(); //116:2
            int __loop12_iteration = 0;
            foreach (var __tmp1 in __loop12_results)
            {
                ++__loop12_iteration;
                var __loop12_var1 = __tmp1.__loop12_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpPublicName() + " " + param.Name; //117:3
            }
            return result; //119:2
        }

        public string GetEnumImplCallParameterNames(MetaOperation op) //122:1
        {
            string result = "@this"; //123:2
            string delim = ", "; //124:2
            var __loop13_results = 
                (from __loop13_var1 in __Enumerate((op).GetEnumerator()) //125:7
                from param in __Enumerate((__loop13_var1.Parameters).GetEnumerator()) //125:11
                select new { __loop13_var1 = __loop13_var1, param = param}
                ).ToList(); //125:2
            int __loop13_iteration = 0;
            foreach (var __tmp1 in __loop13_results)
            {
                ++__loop13_iteration;
                var __loop13_var1 = __tmp1.__loop13_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //126:3
            }
            return result; //128:2
        }

        public string GetImplCallParameterNames(MetaOperation op) //131:1
        {
            string result = "this"; //132:2
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
                result += delim + param.Name; //135:3
            }
            return result; //137:2
        }

        public string GenerateOperation(MetaOperation op) //140:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = ");"; //141:71
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(op.ReturnType.CSharpPublicName());
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
            string __tmp4Line = " "; //141:35
            __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(op.Name);
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
            string __tmp6Line = "("; //141:45
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
                    __out.AppendLine(); //141:73
                }
            }
            return __out.ToString();
        }

        public string GenerateInterfaceImpl(MetaModel model, MetaClass cls) //144:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "internal class "; //145:1
            string __tmp2Suffix = string.Empty; 
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.CSharpImplName());
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
            string __tmp4Line = " : ModelObject, "; //145:38
            __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(cls.Namespace.CSharpName());
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
            string __tmp6Line = "."; //145:82
            __out.Append(__tmp6Line);
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(cls.CSharpName());
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
                    __out.AppendLine(); //145:101
                }
            }
            __out.Append("{"); //146:1
            __out.AppendLine(); //146:2
            string __tmp8Prefix = "    static "; //147:1
            string __tmp9Suffix = "()"; //147:34
            StringBuilder __tmp10 = new StringBuilder();
            __tmp10.Append(cls.CSharpImplName());
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
                    __out.AppendLine(); //147:36
                }
            }
            __out.Append("    {"); //148:1
            __out.AppendLine(); //148:6
            string __tmp11Prefix = "        "; //149:1
            string __tmp12Suffix = ".StaticInit();"; //149:33
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(model.CSharpFullName());
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
                    __out.AppendLine(); //149:47
                }
            }
            __out.Append("    }"); //150:1
            __out.AppendLine(); //150:6
            __out.AppendLine(); //151:2
            string __tmp14Prefix = "    "; //152:1
            string __tmp15Suffix = string.Empty; 
            StringBuilder __tmp16 = new StringBuilder();
            __tmp16.Append(GenerateConstructorImpl(model, cls));
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
                    __out.AppendLine(); //152:42
                }
            }
            var __loop15_results = 
                (from __loop15_var1 in __Enumerate((cls).GetEnumerator()) //153:11
                from prop in __Enumerate((__loop15_var1.GetAllProperties()).GetEnumerator()) //153:16
                select new { __loop15_var1 = __loop15_var1, prop = prop}
                ).ToList(); //153:6
            int __loop15_iteration = 0;
            foreach (var __tmp17 in __loop15_results)
            {
                ++__loop15_iteration;
                var __loop15_var1 = __tmp17.__loop15_var1;
                var prop = __tmp17.prop;
                string __tmp18Prefix = "    "; //154:1
                string __tmp19Suffix = string.Empty; 
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(GeneratePropertyImpl(model, cls, prop));
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
                        __out.AppendLine(); //154:45
                    }
                }
            }
            var __loop16_results = 
                (from __loop16_var1 in __Enumerate((cls).GetEnumerator()) //156:11
                from op in __Enumerate((__loop16_var1.GetAllOperations()).GetEnumerator()) //156:16
                select new { __loop16_var1 = __loop16_var1, op = op}
                ).ToList(); //156:6
            int __loop16_iteration = 0;
            foreach (var __tmp21 in __loop16_results)
            {
                ++__loop16_iteration;
                var __loop16_var1 = __tmp21.__loop16_var1;
                var op = __tmp21.op;
                string __tmp22Prefix = "    "; //157:1
                string __tmp23Suffix = string.Empty; 
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(GenerateOperationImpl(model, op));
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
                        __out.AppendLine(); //157:39
                    }
                }
            }
            __out.Append("}"); //159:1
            __out.AppendLine(); //159:2
            __out.AppendLine(); //160:2
            return __out.ToString();
        }

        public string GeneratePropertyDeclaration(MetaModel model, MetaClass cls, MetaProperty prop) //163:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class == cls) //164:2
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
                        __out.AppendLine(); //165:28
                    }
                }
                if (prop.Kind == MetaPropertyKind.Containment) //166:2
                {
                    string __tmp4Prefix = string.Empty;
                    string __tmp5Suffix = string.Empty;
                    StringBuilder __tmp6 = new StringBuilder();
                    __tmp6.Append("[ContainmentAttribute]");
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
                            __out.AppendLine(); //167:27
                        }
                    }
                }
                if (prop.Kind != MetaPropertyKind.Normal && prop.Kind != MetaPropertyKind.Containment && !(prop.Type is MetaCollectionType)) //169:2
                {
                    string __tmp7Prefix = string.Empty;
                    string __tmp8Suffix = string.Empty;
                    StringBuilder __tmp9 = new StringBuilder();
                    __tmp9.Append("[ReadonlyAttribute]");
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
                            __out.AppendLine(); //170:24
                        }
                    }
                }
                var __loop17_results = 
                    (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //172:7
                    select new { p = p}
                    ).ToList(); //172:2
                int __loop17_iteration = 0;
                foreach (var __tmp10 in __loop17_results)
                {
                    ++__loop17_iteration;
                    var p = __tmp10.p;
                    string __tmp11Prefix = string.Empty; 
                    string __tmp12Suffix = string.Empty; 
                    StringBuilder __tmp13 = new StringBuilder();
                    __tmp13.Append("[OppositeAttribute(typeof(");
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
                    StringBuilder __tmp14 = new StringBuilder();
                    __tmp14.Append(p.Class.Model.CSharpFullName());
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
                        }
                    }
                    string __tmp15Line = "."; //173:63
                    __out.Append(__tmp15Line);
                    StringBuilder __tmp16 = new StringBuilder();
                    __tmp16.Append(p.Class.CSharpName());
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
                        }
                    }
                    StringBuilder __tmp17 = new StringBuilder();
                    __tmp17.Append("), \"");
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
                        }
                    }
                    StringBuilder __tmp18 = new StringBuilder();
                    __tmp18.Append(p.Name);
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
                            __out.Append(__tmp18Line);
                        }
                    }
                    StringBuilder __tmp19 = new StringBuilder();
                    __tmp19.Append("\")]");
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
                            __out.Append(__tmp12Suffix);
                            __out.AppendLine(); //173:111
                        }
                    }
                }
                var __loop18_results = 
                    (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //175:7
                    select new { p = p}
                    ).ToList(); //175:2
                int __loop18_iteration = 0;
                foreach (var __tmp20 in __loop18_results)
                {
                    ++__loop18_iteration;
                    var p = __tmp20.p;
                    if (cls.GetAllSuperClasses(false).Contains(p.Class)) //176:3
                    {
                        string __tmp21Prefix = string.Empty; 
                        string __tmp22Suffix = string.Empty; 
                        StringBuilder __tmp23 = new StringBuilder();
                        __tmp23.Append("[SubsetsAttribute(typeof(");
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
                        StringBuilder __tmp24 = new StringBuilder();
                        __tmp24.Append(p.Class.Model.CSharpFullName());
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
                        string __tmp25Line = "."; //177:62
                        __out.Append(__tmp25Line);
                        StringBuilder __tmp26 = new StringBuilder();
                        __tmp26.Append(p.Class.CSharpName());
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
                            }
                        }
                        StringBuilder __tmp27 = new StringBuilder();
                        __tmp27.Append("), \"");
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
                                __out.Append(__tmp27Line);
                            }
                        }
                        StringBuilder __tmp28 = new StringBuilder();
                        __tmp28.Append(p.Name);
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
                        StringBuilder __tmp29 = new StringBuilder();
                        __tmp29.Append("\")]");
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
                                __out.Append(__tmp22Suffix);
                                __out.AppendLine(); //177:110
                            }
                        }
                    }
                    else //178:3
                    {
                        string __tmp30Prefix = "// ERROR: subsetted property '"; //179:1
                        string __tmp31Suffix = "' must be a property of an ancestor class"; //179:95
                        StringBuilder __tmp32 = new StringBuilder();
                        __tmp32.Append(p.Class.Model.CSharpFullName());
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
                            }
                        }
                        string __tmp33Line = "."; //179:63
                        __out.Append(__tmp33Line);
                        StringBuilder __tmp34 = new StringBuilder();
                        __tmp34.Append(p.Class.CSharpName());
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
                            }
                        }
                        string __tmp35Line = "."; //179:86
                        __out.Append(__tmp35Line);
                        StringBuilder __tmp36 = new StringBuilder();
                        __tmp36.Append(p.Name);
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
                                __out.Append(__tmp31Suffix);
                                __out.AppendLine(); //179:136
                            }
                        }
                    }
                }
                var __loop19_results = 
                    (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //182:7
                    select new { p = p}
                    ).ToList(); //182:2
                int __loop19_iteration = 0;
                foreach (var __tmp37 in __loop19_results)
                {
                    ++__loop19_iteration;
                    var p = __tmp37.p;
                    if (cls.GetAllSuperClasses(false).Contains(p.Class)) //183:3
                    {
                        string __tmp38Prefix = string.Empty; 
                        string __tmp39Suffix = string.Empty; 
                        StringBuilder __tmp40 = new StringBuilder();
                        __tmp40.Append("[RedefinesAttribute(typeof(");
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
                                __out.Append(__tmp38Prefix);
                                __out.Append(__tmp40Line);
                            }
                        }
                        StringBuilder __tmp41 = new StringBuilder();
                        __tmp41.Append(p.Class.Model.CSharpFullName());
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
                        string __tmp42Line = "."; //184:64
                        __out.Append(__tmp42Line);
                        StringBuilder __tmp43 = new StringBuilder();
                        __tmp43.Append(p.Class.CSharpName());
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
                        StringBuilder __tmp44 = new StringBuilder();
                        __tmp44.Append("), \"");
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
                            }
                        }
                        StringBuilder __tmp45 = new StringBuilder();
                        __tmp45.Append(p.Name);
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
                        StringBuilder __tmp46 = new StringBuilder();
                        __tmp46.Append("\")]");
                        using(StreamReader __tmp46Reader = new StreamReader(this.__ToStream(__tmp46.ToString())))
                        {
                            bool __tmp46_first = true;
                            while(__tmp46_first || !__tmp46Reader.EndOfStream)
                            {
                                __tmp46_first = false;
                                string __tmp46Line = __tmp46Reader.ReadLine();
                                if (__tmp46Line == null)
                                {
                                    __tmp46Line = "";
                                }
                                __out.Append(__tmp46Line);
                                __out.Append(__tmp39Suffix);
                                __out.AppendLine(); //184:112
                            }
                        }
                    }
                    else //185:3
                    {
                        string __tmp47Prefix = "// ERROR: redefined property '"; //186:1
                        string __tmp48Suffix = "' must be a property of an ancestor class"; //186:95
                        StringBuilder __tmp49 = new StringBuilder();
                        __tmp49.Append(p.Class.Model.CSharpFullName());
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
                                __out.Append(__tmp47Prefix);
                                __out.Append(__tmp49Line);
                            }
                        }
                        string __tmp50Line = "."; //186:63
                        __out.Append(__tmp50Line);
                        StringBuilder __tmp51 = new StringBuilder();
                        __tmp51.Append(p.Class.CSharpName());
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
                        string __tmp52Line = "."; //186:86
                        __out.Append(__tmp52Line);
                        StringBuilder __tmp53 = new StringBuilder();
                        __tmp53.Append(p.Name);
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
                                __out.Append(__tmp48Suffix);
                                __out.AppendLine(); //186:136
                            }
                        }
                    }
                }
                string __tmp54Prefix = "public static readonly ModelProperty "; //189:1
                string __tmp55Suffix = "Property ="; //189:49
                StringBuilder __tmp56 = new StringBuilder();
                __tmp56.Append(prop.Name);
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
                        __out.Append(__tmp55Suffix);
                        __out.AppendLine(); //189:59
                    }
                }
                string __tmp57Prefix = "    ModelProperty.Register(\""; //190:1
                string __tmp58Suffix = "));"; //190:194
                StringBuilder __tmp59 = new StringBuilder();
                __tmp59.Append(prop.Name);
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
                        __out.Append(__tmp57Prefix);
                        __out.Append(__tmp59Line);
                    }
                }
                string __tmp60Line = "\", typeof("; //190:40
                __out.Append(__tmp60Line);
                StringBuilder __tmp61 = new StringBuilder();
                __tmp61.Append(prop.Type.CSharpFullPublicName());
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
                string __tmp62Line = "), typeof("; //190:84
                __out.Append(__tmp62Line);
                StringBuilder __tmp63 = new StringBuilder();
                __tmp63.Append(prop.Class.CSharpFullName());
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
                string __tmp64Line = "), typeof("; //190:123
                __out.Append(__tmp64Line);
                StringBuilder __tmp65 = new StringBuilder();
                __tmp65.Append(prop.Class.Model.CSharpFullName());
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
                string __tmp66Line = "."; //190:168
                __out.Append(__tmp66Line);
                StringBuilder __tmp67 = new StringBuilder();
                __tmp67.Append(prop.Class.CSharpName());
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
                        __out.Append(__tmp58Suffix);
                        __out.AppendLine(); //190:197
                    }
                }
            }
            __out.AppendLine(); //192:2
            return __out.ToString();
        }

        public string GeneratePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //195:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //196:2
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = string.Empty; 
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(prop.Type.CSharpPublicName());
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
            string __tmp4Line = " "; //197:31
            __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(prop.Class.CSharpName());
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
            string __tmp6Line = "."; //197:57
            __out.Append(__tmp6Line);
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(prop.Name);
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
                    __out.AppendLine(); //197:69
                }
            }
            __out.Append("{"); //198:1
            __out.AppendLine(); //198:2
            if (prop.Kind == MetaPropertyKind.Derived) //199:3
            {
                MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //200:4
                if (synInit == null) //201:4
                {
                    string __tmp8Prefix = "    get { return "; //202:1
                    string __tmp9Suffix = "(this); }"; //202:113
                    StringBuilder __tmp10 = new StringBuilder();
                    __tmp10.Append(model.CSharpName());
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
                    string __tmp11Line = "ImplementationProvider.Implementation."; //202:38
                    __out.Append(__tmp11Line);
                    StringBuilder __tmp12 = new StringBuilder();
                    __tmp12.Append(prop.Class.CSharpName());
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
                            __out.Append(__tmp12Line);
                        }
                    }
                    string __tmp13Line = "_"; //202:101
                    __out.Append(__tmp13Line);
                    StringBuilder __tmp14 = new StringBuilder();
                    __tmp14.Append(prop.Name);
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
                            __out.Append(__tmp9Suffix);
                            __out.AppendLine(); //202:122
                        }
                    }
                }
                else //203:4
                {
                    string __tmp15Prefix = "    get { return "; //204:1
                    string __tmp16Suffix = "; }"; //204:53
                    StringBuilder __tmp17 = new StringBuilder();
                    __tmp17.Append(GenerateExpression(synInit.Value));
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
                            __out.AppendLine(); //204:56
                        }
                    }
                }
            }
            else //206:3
            {
                __out.Append("    get "); //207:1
                __out.AppendLine(); //207:9
                __out.Append("    {"); //208:1
                __out.AppendLine(); //208:6
                string __tmp18Prefix = "        object result = this.MGet("; //209:1
                string __tmp19Suffix = "Property); "; //209:97
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(model.CSharpFullName());
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
                string __tmp21Line = "."; //209:59
                __out.Append(__tmp21Line);
                StringBuilder __tmp22 = new StringBuilder();
                __tmp22.Append(prop.Class.CSharpName());
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
                string __tmp23Line = "."; //209:85
                __out.Append(__tmp23Line);
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(prop.Name);
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
                        __out.AppendLine(); //209:108
                    }
                }
                string __tmp25Prefix = "        if (result != null) return ("; //210:1
                string __tmp26Suffix = ")result;"; //210:67
                StringBuilder __tmp27 = new StringBuilder();
                __tmp27.Append(prop.Type.CSharpPublicName());
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
                        __out.AppendLine(); //210:75
                    }
                }
                string __tmp28Prefix = "        else return default("; //211:1
                string __tmp29Suffix = ");"; //211:59
                StringBuilder __tmp30 = new StringBuilder();
                __tmp30.Append(prop.Type.CSharpPublicName());
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
                        __out.AppendLine(); //211:61
                    }
                }
                __out.Append("    }"); //212:1
                __out.AppendLine(); //212:6
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //214:3
            {
                string __tmp31Prefix = "    set { this.MSet("; //215:1
                string __tmp32Suffix = "Property, value); }"; //215:83
                StringBuilder __tmp33 = new StringBuilder();
                __tmp33.Append(model.CSharpFullName());
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
                string __tmp34Line = "."; //215:45
                __out.Append(__tmp34Line);
                StringBuilder __tmp35 = new StringBuilder();
                __tmp35.Append(prop.Class.CSharpName());
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
                string __tmp36Line = "."; //215:71
                __out.Append(__tmp36Line);
                StringBuilder __tmp37 = new StringBuilder();
                __tmp37.Append(prop.Name);
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
                        __out.Append(__tmp32Suffix);
                        __out.AppendLine(); //215:102
                    }
                }
            }
            __out.Append("}"); //217:1
            __out.AppendLine(); //217:2
            return __out.ToString();
        }

        public string GetCollectionConstructorParams(MetaProperty prop) //220:1
        {
            MetaCollectionType mct = prop.Type as MetaCollectionType; //221:2
            if (mct != null && mct.InnerType is MetaClass) //222:2
            {
                return "this, " + prop.Class.Model.CSharpFullName() + "." + prop.Class.CSharpName() + "." + prop.Name + "Property"; //223:3
            }
            else //224:2
            {
                return ""; //225:3
            }
        }

        public string GenerateConstantValueExpression(string name, MetaExpression expr, string nameType) //229:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //230:10
            if (expr is MetaNewExpression) //231:2
            {
                string tmpName = "tmp" + NextCounter(); //232:2
                string tmpType = ((MetaNewExpression)expr).TypeReference.CSharpFullName(); //233:2
                string __tmp2Prefix = string.Empty; 
                string __tmp3Suffix = "();"; //234:110
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append(tmpType);
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
                string __tmp5Line = " "; //234:10
                __out.Append(__tmp5Line);
                StringBuilder __tmp6 = new StringBuilder();
                __tmp6.Append(tmpName);
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
                    }
                }
                string __tmp7Line = " = "; //234:20
                __out.Append(__tmp7Line);
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(((MetaNewExpression)expr).TypeReference.Model.Name);
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
                    }
                }
                string __tmp9Line = "Factory.Instance.Create"; //234:54
                __out.Append(__tmp9Line);
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(((MetaNewExpression)expr).TypeReference.CSharpName());
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
                        __out.Append(__tmp3Suffix);
                        __out.AppendLine(); //234:113
                    }
                }
                if (nameType != null) //235:2
                {
                    string __tmp11Prefix = string.Empty; 
                    string __tmp12Suffix = " "; //236:11
                    StringBuilder __tmp13 = new StringBuilder();
                    __tmp13.Append(nameType);
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
                        }
                    }
                }
                string __tmp14Prefix = string.Empty; 
                string __tmp15Suffix = ";"; //238:19
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(name);
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
                    }
                }
                string __tmp17Line = " = "; //238:7
                __out.Append(__tmp17Line);
                StringBuilder __tmp18 = new StringBuilder();
                __tmp18.Append(tmpName);
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
                        __out.Append(__tmp18Line);
                        __out.Append(__tmp15Suffix);
                        __out.AppendLine(); //238:20
                    }
                }
                var __loop20_results = 
                    (from __loop20_var1 in __Enumerate((((MetaNewExpression)expr)).GetEnumerator()) //239:8
                    from pi in __Enumerate((__loop20_var1.PropertyInitializers).GetEnumerator()) //239:14
                    select new { __loop20_var1 = __loop20_var1, pi = pi}
                    ).ToList(); //239:2
                int __loop20_iteration = 0;
                foreach (var __tmp19 in __loop20_results)
                {
                    ++__loop20_iteration;
                    var __loop20_var1 = __tmp19.__loop20_var1;
                    var pi = __tmp19.pi;
                    string __tmp20Prefix = string.Empty;
                    string __tmp21Suffix = string.Empty;
                    StringBuilder __tmp22 = new StringBuilder();
                    __tmp22.Append(GenerateConstantValueExpression(tmpName + "." + pi.PropertyName, pi.Value, null));
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
                            __out.AppendLine(); //240:79
                        }
                    }
                }
            }
            else if (expr is MetaNewCollectionExpression) //242:2
            {
                var __loop21_results = 
                    (from __loop21_var1 in __Enumerate((((MetaNewCollectionExpression)expr)).GetEnumerator()) //243:8
                    from v in __Enumerate((__loop21_var1.Values).GetEnumerator()) //243:14
                    select new { __loop21_var1 = __loop21_var1, v = v}
                    ).ToList(); //243:2
                int __loop21_iteration = 0;
                foreach (var __tmp23 in __loop21_results)
                {
                    ++__loop21_iteration;
                    var __loop21_var1 = __tmp23.__loop21_var1;
                    var v = __tmp23.v;
                    string tmpName = "tmp" + NextCounter(); //244:2
                    string tmpType = v.Type.CSharpFullName(); //245:2
                    if (v is MetaNewExpression) //246:3
                    {
                        string __tmp24Prefix = string.Empty;
                        string __tmp25Suffix = string.Empty;
                        StringBuilder __tmp26 = new StringBuilder();
                        __tmp26.Append(GenerateConstantValueExpression(tmpName, v, tmpType));
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
                                __out.AppendLine(); //247:55
                            }
                        }
                        string __tmp27Prefix = string.Empty; 
                        string __tmp28Suffix = ");"; //248:21
                        StringBuilder __tmp29 = new StringBuilder();
                        __tmp29.Append(name);
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
                        string __tmp30Line = ".Add("; //248:7
                        __out.Append(__tmp30Line);
                        StringBuilder __tmp31 = new StringBuilder();
                        __tmp31.Append(tmpName);
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
                                __out.Append(__tmp28Suffix);
                                __out.AppendLine(); //248:23
                            }
                        }
                    }
                    else if (v is MetaNewCollectionExpression) //249:3
                    {
                        __out.Append("// TODO"); //250:1
                        __out.AppendLine(); //250:8
                    }
                    else //251:3
                    {
                        string __tmp32Prefix = string.Empty; 
                        string __tmp33Suffix = ");"; //252:38
                        StringBuilder __tmp34 = new StringBuilder();
                        __tmp34.Append(name);
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
                        string __tmp35Line = ".Add("; //252:7
                        __out.Append(__tmp35Line);
                        StringBuilder __tmp36 = new StringBuilder();
                        __tmp36.Append(GenerateExpression(((MetaNewCollectionExpression)expr)));
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
                                __out.Append(__tmp33Suffix);
                                __out.AppendLine(); //252:40
                            }
                        }
                    }
                }
            }
            else //255:2
            {
                __out.Append(name);
                __out.Append(" = "); //255:17
                __out.Append(GenerateExpression(expr));
                __out.Append(";"); //255:46
                __out.AppendLine(); //255:47
            }//256:2
            return __out.ToString();
        }

        public string GenerateNewObject() //259:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateExpression(MetaExpression expr) //262:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //263:10
            if (expr is MetaBracketExpression) //264:2
            {
                __out.Append("("); //264:33
                __out.Append(GenerateExpression(((MetaBracketExpression)expr).Expression));
                __out.Append(")"); //264:71
            }
            else if (expr is MetaThisExpression) //265:2
            {
                __out.Append("(("); //265:30
                __out.Append(((MetaType)ModelContext.Current.Compiler.ResolutionProvider.GetCurrentTypeScopeOf((ModelObject)((MetaThisExpression)expr))).CSharpName());
                __out.Append(")this)"); //265:148
            }
            else if (expr is MetaNullExpression) //266:2
            {
                __out.Append("null"); //266:30
            }
            else if (expr is MetaTypeAsExpression) //267:2
            {
                __out.Append(GenerateExpression(((MetaTypeAsExpression)expr).Expression));
                __out.Append(" as "); //267:69
                __out.Append(((MetaTypeAsExpression)expr).TypeReference.CSharpName());
            }
            else if (expr is MetaTypeCastExpression) //268:2
            {
                __out.Append("("); //268:34
                __out.Append(((MetaTypeCastExpression)expr).TypeReference.CSharpName());
                __out.Append(")"); //268:68
                __out.Append(GenerateExpression(((MetaTypeCastExpression)expr).Expression));
            }
            else if (expr is MetaTypeCheckExpression) //269:2
            {
                __out.Append(GenerateExpression(((MetaTypeCheckExpression)expr).Expression));
                __out.Append(" is "); //269:72
                __out.Append(((MetaTypeCheckExpression)expr).TypeReference.CSharpName());
            }
            else if (expr is MetaTypeOfExpression) //270:2
            {
                __out.Append(GenerateTypeOf(((MetaTypeOfExpression)expr)));
            }
            else if (expr is MetaConditionalExpression) //271:2
            {
                __out.Append(GenerateExpression(((MetaConditionalExpression)expr).Condition));
                __out.Append(" ? "); //271:73
                __out.Append(GenerateExpression(((MetaConditionalExpression)expr).Then));
                __out.Append(" : "); //271:107
                __out.Append(GenerateExpression(((MetaConditionalExpression)expr).Else));
            }
            else if (expr is MetaConstantExpression) //272:2
            {
                __out.Append(GetCSharpValue(((MetaConstantExpression)expr).Value));
            }
            else if (expr is MetaIdentifierExpression) //273:2
            {
                __out.Append(GenerateIdentifierExpression(((MetaIdentifierExpression)expr)));
            }
            else if (expr is MetaMemberAccessExpression) //274:2
            {
                __out.Append(GenerateExpression(((MetaMemberAccessExpression)expr).Expression));
                __out.Append("."); //274:75
                __out.Append(((MetaMemberAccessExpression)expr).Name);
            }
            else if (expr is MetaFunctionCallExpression) //275:2
            {
                __out.Append(GenerateFunctionCall(((MetaFunctionCallExpression)expr)));
            }
            else if (expr is MetaIndexerExpression) //276:2
            {
                __out.Append(GenerateIndexerCall(((MetaIndexerExpression)expr)));
            }
            else if (expr is MetaOperatorExpression) //277:2
            {
                __out.Append(GenerateOperator(((MetaOperatorExpression)expr)));
            }
            else //278:2
            {
                __out.Append("***unknown expression type***"); //278:11
                __out.AppendLine(); //278:40
            }//279:2
            return __out.ToString();
        }

        public string GenerateIdentifierExpression(MetaIdentifierExpression expr) //282:1
        {
            StringBuilder __out = new StringBuilder();
            if (expr.Definition is MetaProperty) //283:2
            {
                string __tmp1Prefix = "(("; //284:1
                string __tmp2Suffix = string.Empty; 
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(((MetaType)ModelContext.Current.Compiler.ResolutionProvider.GetCurrentTypeScopeOf((ModelObject)expr)).CSharpName());
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
                string __tmp4Line = ")this)."; //284:119
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
            else //285:2
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

        public string GenerateFunctionCall(MetaFunctionCallExpression call) //290:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = call.Definition; //291:9
            if (__tmp1 == Meta.Constants.TypeOf) //292:2
            {
                __out.Append(GenerateTypeOf(call.Arguments[0]));
            }
            else if (__tmp1 == Meta.Constants.GetValueType) //293:2
            {
                __out.Append("ModelContext.Current.Compiler.TypeProvider.GetTypeOf("); //293:36
                __out.Append(GenerateCallArguments(call, ""));
                __out.Append(")"); //293:122
            }
            else if (__tmp1 == Meta.Constants.GetReturnType) //294:2
            {
                __out.Append("ModelContext.Current.Compiler.TypeProvider.GetReturnTypeOf("); //294:37
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //294:142
            }
            else if (__tmp1 == Meta.Constants.CurrentType) //295:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.GetCurrentTypeScopeOf("); //295:35
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //295:152
            }
            else if (__tmp1 == Meta.Constants.TypeCheck) //296:2
            {
                __out.Append("ModelContext.Current.Compiler.TypeProvider.TypeCheck("); //296:33
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //296:132
            }
            else if (__tmp1 == Meta.Constants.Balance) //297:2
            {
                __out.Append("ModelContext.Current.Compiler.TypeProvider.Balance("); //297:31
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //297:128
            }
            else if (__tmp1 == Meta.Constants.Resolve1) //298:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //298:32
                __out.Append("[]");
                __out.Append(" { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.NameOrType, "); //298:110
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //298:250
            }
            else if (__tmp1 == Meta.Constants.Resolve2) //299:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //299:32
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //299:110
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, ResolveKind.NameOrType, "); //299:165
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //299:232
            }
            else if (__tmp1 == Meta.Constants.ResolveType1) //300:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //300:36
                __out.Append("[]");
                __out.Append(" { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Type, "); //300:114
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //300:248
            }
            else if (__tmp1 == Meta.Constants.ResolveType2) //301:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //301:36
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //301:114
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, ResolveKind.Type, "); //301:169
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //301:230
            }
            else if (__tmp1 == Meta.Constants.ResolveName1) //302:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //302:36
                __out.Append("[]");
                __out.Append(" { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, "); //302:114
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //302:248
            }
            else if (__tmp1 == Meta.Constants.ResolveName2) //303:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //303:36
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //303:114
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, ResolveKind.Name, "); //303:169
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //303:230
            }
            else if (__tmp1 == Meta.Constants.Bind1) //304:2
            {
                __out.Append("ModelContext.Current.Compiler.BindingProvider.Bind(this, new ModelObject"); //304:29
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //304:107
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, new BindingInfo())"); //304:162
            }
            else if (__tmp1 == Meta.Constants.Bind2) //305:2
            {
                __out.Append("ModelContext.Current.Compiler.BindingProvider.Bind(this, "); //305:29
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new BindingInfo())"); //305:125
            }
            else if (__tmp1 == Meta.Constants.Bind3) //306:2
            {
                __out.Append("ModelContext.Current.Compiler.BindingProvider.Bind((ModelObject)"); //306:29
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ModelObject"); //306:132
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //306:155
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(" }, new BindingInfo())"); //306:210
            }
            else if (__tmp1 == Meta.Constants.Bind4) //307:2
            {
                __out.Append("ModelContext.Current.Compiler.BindingProvider.Bind((ModelObject)"); //307:29
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", "); //307:132
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new BindingInfo())"); //307:173
            }
            else if (__tmp1 == Meta.Constants.SelectOfType1) //308:2
            {
                __out.Append("new object"); //308:37
                __out.Append("[]");
                __out.Append(" { "); //308:53
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }.Where(e => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(e) is "); //308:95
                __out.Append(GetTypeName(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //308:200
            }
            else if (__tmp1 == Meta.Constants.SelectOfType2) //309:2
            {
                __out.Append("("); //309:37
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(").Where(e => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(e) is "); //309:77
                __out.Append(GetTypeName(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //309:181
            }
            else if (__tmp1 == Meta.Constants.SelectOfName1) //310:2
            {
                __out.Append("new object"); //310:37
                __out.Append("[]");
                __out.Append(" { "); //310:53
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }.Where(e => ModelContext.Current.Compiler.NameProvider.GetNameOf((ModelObject)e) == "); //310:95
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //310:220
            }
            else if (__tmp1 == Meta.Constants.SelectOfName2) //311:2
            {
                __out.Append("("); //311:37
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(").Where(e => ModelContext.Current.Compiler.NameProvider.GetNameOf((ModelObject)e) == "); //311:77
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //311:201
            }
            else //312:2
            {
                __out.Append(GenerateExpression(call.Expression));
                __out.Append("("); //312:48
                __out.Append(GenerateCallArguments(call, ""));
                __out.Append(")"); //312:82
            }//313:2
            return __out.ToString();
        }

        public string GenerateIndexerCall(MetaIndexerExpression call) //316:1
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

        public string GenerateTypeOf(object expr) //320:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //321:9
            if (__tmp1 == Meta.Constants.None) //322:2
            {
                __out.Append("Meta.Constants.None"); //322:28
            }
            else if (__tmp1 == Meta.Constants.Error) //323:2
            {
                __out.Append("Meta.Constants.Error"); //323:29
            }
            else if (__tmp1 == Meta.Constants.Any) //324:2
            {
                __out.Append("Meta.Constants.Any"); //324:27
            }
            else if (__tmp1 == Meta.Constants.Object) //325:2
            {
                __out.Append("Meta.Constants.Object"); //325:30
            }
            else if (__tmp1 == Meta.Constants.String) //326:2
            {
                __out.Append("Meta.Constants.String"); //326:30
            }
            else if (__tmp1 == Meta.Constants.Int) //327:2
            {
                __out.Append("Meta.Constants.Int"); //327:27
            }
            else if (__tmp1 == Meta.Constants.Long) //328:2
            {
                __out.Append("Meta.Constants.Long"); //328:28
            }
            else if (__tmp1 == Meta.Constants.Float) //329:2
            {
                __out.Append("Meta.Constants.Float"); //329:29
            }
            else if (__tmp1 == Meta.Constants.Double) //330:2
            {
                __out.Append("Meta.Constants.Double"); //330:30
            }
            else if (__tmp1 == Meta.Constants.Byte) //331:2
            {
                __out.Append("Meta.Constants.Byte"); //331:28
            }
            else if (__tmp1 == Meta.Constants.Bool) //332:2
            {
                __out.Append("Meta.Constants.Bool"); //332:28
            }
            else if (__tmp1 == Meta.Constants.Void) //333:2
            {
                __out.Append("Meta.Constants.Void"); //333:28
            }
            else if (__tmp1 == Meta.Constants.ModelObject) //334:2
            {
                __out.Append("Meta.Constants.ModelObject"); //334:35
            }
            else if (__tmp1 == Meta.Constants.ModelObjectList) //335:2
            {
                __out.Append("Meta.Constants.ModelObjectList"); //335:39
            }
            else if (expr is MetaTypeOfExpression) //336:2
            {
                __out.Append(GenerateTypeOf(((MetaTypeOfExpression)expr).TypeReference));
            }
            else if (expr is MetaClass) //337:2
            {
                __out.Append("global::MetaDslx.Core."); //337:21
                __out.Append(((MetaClass)expr).Model.CSharpName());
                __out.Append("."); //337:68
                __out.Append(((MetaClass)expr).CSharpName());
                __out.Append(".Instance"); //337:88
            }
            else if (expr is MetaCollectionType) //338:2
            {
                __out.Append(((MetaCollectionType)expr).CSharpFullName());
            }
            else //339:2
            {
                __out.Append("***error***"); //339:11
            }//340:2
            return __out.ToString();
        }

        public string GenerateCallArguments(MetaBoundExpression call, string prefix) //343:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop22_results = 
                (from __loop22_var1 in __Enumerate((call).GetEnumerator()) //344:7
                from arg in __Enumerate((__loop22_var1.Arguments).GetEnumerator()) //344:13
                select new { __loop22_var1 = __loop22_var1, arg = arg}
                ).ToList(); //344:2
            int __loop22_iteration = 0;
            string delim = ""; //344:28
            foreach (var __tmp1 in __loop22_results)
            {
                ++__loop22_iteration;
                if (__loop22_iteration >= 2) //344:47
                {
                    delim = ", "; //344:47
                }
                var __loop22_var1 = __tmp1.__loop22_var1;
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

        public string GenerateOperator(MetaOperatorExpression expr) //349:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //350:10
            if (expr is MetaUnaryExpression) //351:2
            {
                if (((MetaUnaryExpression)expr) is MetaPostIncrementAssignExpression || ((MetaUnaryExpression)expr) is MetaPostDecrementAssignExpression) //352:3
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
                    __tmp5.Append(GetCSharpOperator(((MetaUnaryExpression)expr)));
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
                else //354:3
                {
                    string __tmp6Prefix = string.Empty; 
                    string __tmp7Suffix = string.Empty; 
                    StringBuilder __tmp8 = new StringBuilder();
                    __tmp8.Append(GetCSharpOperator(((MetaUnaryExpression)expr)));
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
            else if (expr is MetaBinaryExpression) //357:2
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
                __tmp13.Append(GetCSharpOperator(((MetaBinaryExpression)expr)));
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
            }//359:2
            return __out.ToString();
        }

        public string GenerateNewPropertyInitializers(MetaNewExpression expr) //362:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((expr).GetEnumerator()) //363:7
                from pi in __Enumerate((__loop23_var1.PropertyInitializers).GetEnumerator()) //363:13
                select new { __loop23_var1 = __loop23_var1, pi = pi}
                ).ToList(); //363:2
            int __loop23_iteration = 0;
            string delim = ""; //363:38
            foreach (var __tmp1 in __loop23_results)
            {
                ++__loop23_iteration;
                if (__loop23_iteration >= 2) //363:57
                {
                    delim = ", "; //363:57
                }
                var __loop23_var1 = __tmp1.__loop23_var1;
                var pi = __tmp1.pi;
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
                __tmp5.Append(pi.Property.Name);
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
                string __tmp6Line = " = "; //364:26
                __out.Append(__tmp6Line);
                StringBuilder __tmp7 = new StringBuilder();
                __tmp7.Append(GenerateExpression(pi.Value));
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
                        __out.Append(__tmp3Suffix);
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateNewCollectionInitializers(MetaNewCollectionExpression expr) //368:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((expr).GetEnumerator()) //369:7
                from v in __Enumerate((__loop24_var1.Values).GetEnumerator()) //369:13
                select new { __loop24_var1 = __loop24_var1, v = v}
                ).ToList(); //369:2
            int __loop24_iteration = 0;
            string delim = ""; //369:23
            foreach (var __tmp1 in __loop24_results)
            {
                ++__loop24_iteration;
                if (__loop24_iteration >= 2) //369:42
                {
                    delim = ", "; //369:42
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

        public string GetCSharpValue(object value) //374:1
        {
            if (value == null) //375:2
            {
                return "null"; //375:21
            }
            else if (value is bool && ((bool)value) == true) //376:2
            {
                return "true"; //376:51
            }
            else if (value is bool && ((bool)value) == false) //377:2
            {
                return "false"; //377:52
            }
            else if (value is string) //378:2
            {
                return "\"" + value.ToString() + "\""; //378:28
            }
            else if (value is MetaExpression) //379:2
            {
                return GenerateExpression((MetaExpression)value); //379:36
            }
            else //380:2
            {
                return value.ToString(); //380:7
            }
        }

        public string GetCSharpOperator(MetaOperatorExpression expr) //384:1
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
                return ((MetaTypeOfExpression)expr).TypeReference.CSharpName(); //428:36
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
            string __tmp2Suffix = "() "; //444:30
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.CSharpImplName());
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
                    __out.AppendLine(); //444:33
                }
            }
            __out.Append("    : this(true)"); //445:1
            __out.AppendLine(); //445:17
            __out.Append("{"); //446:1
            __out.AppendLine(); //446:2
            __out.Append("}"); //447:1
            __out.AppendLine(); //447:2
            string __tmp4Prefix = "public "; //449:1
            string __tmp5Suffix = "(bool addToModelContext) "; //449:30
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(cls.CSharpImplName());
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
                    __out.AppendLine(); //449:55
                }
            }
            __out.Append("    : base(addToModelContext)"); //450:1
            __out.AppendLine(); //450:30
            __out.Append("{"); //451:1
            __out.AppendLine(); //451:2
            var __loop26_results = 
                (from __loop26_var1 in __Enumerate((cls).GetEnumerator()) //452:8
                from prop in __Enumerate((__loop26_var1.GetAllProperties()).GetEnumerator()) //452:13
                select new { __loop26_var1 = __loop26_var1, prop = prop}
                ).ToList(); //452:3
            int __loop26_iteration = 0;
            foreach (var __tmp7 in __loop26_results)
            {
                ++__loop26_iteration;
                var __loop26_var1 = __tmp7.__loop26_var1;
                var prop = __tmp7.prop;
                MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //453:4
                if (synInit != null) //454:4
                {
                    if (prop.Kind != MetaPropertyKind.Derived) //455:5
                    {
                        if (ModelContext.Current.Compiler.TypeProvider.GetTypeOf(synInit.Value) is MetaCollectionType) //456:6
                        {
                            string __tmp8Prefix = "    this.MLazySet("; //457:1
                            string __tmp9Suffix = "));"; //457:149
                            StringBuilder __tmp10 = new StringBuilder();
                            __tmp10.Append(model.CSharpFullName());
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
                            string __tmp11Line = "."; //457:43
                            __out.Append(__tmp11Line);
                            StringBuilder __tmp12 = new StringBuilder();
                            __tmp12.Append(prop.Class.CSharpName());
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
                                    __out.Append(__tmp12Line);
                                }
                            }
                            string __tmp13Line = "."; //457:69
                            __out.Append(__tmp13Line);
                            StringBuilder __tmp14 = new StringBuilder();
                            __tmp14.Append(prop.Name);
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
                                }
                            }
                            string __tmp15Line = "Property, new Lazy<object>(() => "; //457:81
                            __out.Append(__tmp15Line);
                            StringBuilder __tmp16 = new StringBuilder();
                            __tmp16.Append(GenerateExpression(synInit.Value));
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
                                    __out.Append(__tmp9Suffix);
                                    __out.AppendLine(); //457:152
                                }
                            }
                        }
                        else //458:6
                        {
                            string __tmp17Prefix = "    this.MLazySet("; //459:1
                            string __tmp18Suffix = "));"; //459:149
                            StringBuilder __tmp19 = new StringBuilder();
                            __tmp19.Append(model.CSharpFullName());
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
                            string __tmp20Line = "."; //459:43
                            __out.Append(__tmp20Line);
                            StringBuilder __tmp21 = new StringBuilder();
                            __tmp21.Append(prop.Class.CSharpName());
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
                                }
                            }
                            string __tmp22Line = "."; //459:69
                            __out.Append(__tmp22Line);
                            StringBuilder __tmp23 = new StringBuilder();
                            __tmp23.Append(prop.Name);
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
                                    __out.Append(__tmp23Line);
                                }
                            }
                            string __tmp24Line = "Property, new Lazy<object>(() => "; //459:81
                            __out.Append(__tmp24Line);
                            StringBuilder __tmp25 = new StringBuilder();
                            __tmp25.Append(GenerateExpression(synInit.Value));
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
                                    __out.Append(__tmp18Suffix);
                                    __out.AppendLine(); //459:152
                                }
                            }
                        }
                    }
                }
                else //462:4
                {
                    if (prop.Type is MetaCollectionType) //463:5
                    {
                        if (prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) //464:6
                        {
                            string __tmp26Prefix = "    this.MSet("; //465:1
                            string __tmp27Suffix = "));"; //465:154
                            StringBuilder __tmp28 = new StringBuilder();
                            __tmp28.Append(model.CSharpFullName());
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
                            string __tmp29Line = "."; //465:39
                            __out.Append(__tmp29Line);
                            StringBuilder __tmp30 = new StringBuilder();
                            __tmp30.Append(prop.Class.CSharpName());
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
                            string __tmp31Line = "."; //465:65
                            __out.Append(__tmp31Line);
                            StringBuilder __tmp32 = new StringBuilder();
                            __tmp32.Append(prop.Name);
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
                            string __tmp33Line = "Property, new "; //465:77
                            __out.Append(__tmp33Line);
                            StringBuilder __tmp34 = new StringBuilder();
                            __tmp34.Append(prop.Type.CSharpName());
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
                                }
                            }
                            string __tmp35Line = "("; //465:115
                            __out.Append(__tmp35Line);
                            StringBuilder __tmp36 = new StringBuilder();
                            __tmp36.Append(GetCollectionConstructorParams(prop));
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
                                    __out.Append(__tmp27Suffix);
                                    __out.AppendLine(); //465:157
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //466:6
                        {
                            string __tmp37Prefix = "    this.MLazySet("; //467:1
                            string __tmp38Suffix = "(this)));"; //467:209
                            StringBuilder __tmp39 = new StringBuilder();
                            __tmp39.Append(model.CSharpFullName());
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
                                    __out.Append(__tmp37Prefix);
                                    __out.Append(__tmp39Line);
                                }
                            }
                            string __tmp40Line = "."; //467:43
                            __out.Append(__tmp40Line);
                            StringBuilder __tmp41 = new StringBuilder();
                            __tmp41.Append(prop.Class.CSharpName());
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
                            string __tmp42Line = "."; //467:69
                            __out.Append(__tmp42Line);
                            StringBuilder __tmp43 = new StringBuilder();
                            __tmp43.Append(prop.Name);
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
                            string __tmp44Line = "Property, new Lazy<object>(() => "; //467:81
                            __out.Append(__tmp44Line);
                            StringBuilder __tmp45 = new StringBuilder();
                            __tmp45.Append(model.CSharpName());
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
                            string __tmp46Line = "ImplementationProvider.Implementation."; //467:134
                            __out.Append(__tmp46Line);
                            StringBuilder __tmp47 = new StringBuilder();
                            __tmp47.Append(prop.Class.CSharpName());
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
                            string __tmp48Line = "_"; //467:197
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
                                    __out.Append(__tmp38Suffix);
                                    __out.AppendLine(); //467:218
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Readonly) //468:6
                        {
                            string __tmp50Prefix = "    // Init "; //469:1
                            string __tmp51Suffix = string.Empty; 
                            StringBuilder __tmp52 = new StringBuilder();
                            __tmp52.Append(model.CSharpFullName());
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
                            string __tmp53Line = "."; //469:37
                            __out.Append(__tmp53Line);
                            StringBuilder __tmp54 = new StringBuilder();
                            __tmp54.Append(prop.Class.CSharpName());
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
                                }
                            }
                            string __tmp55Line = "."; //469:63
                            __out.Append(__tmp55Line);
                            StringBuilder __tmp56 = new StringBuilder();
                            __tmp56.Append(prop.Name);
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
                                    __out.Append(__tmp56Line);
                                }
                            }
                            string __tmp57Line = "Property in "; //469:75
                            __out.Append(__tmp57Line);
                            StringBuilder __tmp58 = new StringBuilder();
                            __tmp58.Append(model.CSharpName());
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
                            string __tmp59Line = "Implementation."; //469:107
                            __out.Append(__tmp59Line);
                            StringBuilder __tmp60 = new StringBuilder();
                            __tmp60.Append(cls.CSharpName());
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
                            string __tmp61Line = "_"; //469:140
                            __out.Append(__tmp61Line);
                            StringBuilder __tmp62 = new StringBuilder();
                            __tmp62.Append(cls.CSharpName());
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
                                    __out.Append(__tmp51Suffix);
                                    __out.AppendLine(); //469:159
                                }
                            }
                        }
                    }
                    else //471:5
                    {
                        if (prop.Kind == MetaPropertyKind.Lazy) //472:6
                        {
                            string __tmp63Prefix = "    this.MLazySet("; //473:1
                            string __tmp64Suffix = "(this)));"; //473:209
                            StringBuilder __tmp65 = new StringBuilder();
                            __tmp65.Append(model.CSharpFullName());
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
                            string __tmp66Line = "."; //473:43
                            __out.Append(__tmp66Line);
                            StringBuilder __tmp67 = new StringBuilder();
                            __tmp67.Append(prop.Class.CSharpName());
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
                            string __tmp68Line = "."; //473:69
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
                                }
                            }
                            string __tmp70Line = "Property, new Lazy<object>(() => "; //473:81
                            __out.Append(__tmp70Line);
                            StringBuilder __tmp71 = new StringBuilder();
                            __tmp71.Append(model.CSharpName());
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
                                }
                            }
                            string __tmp72Line = "ImplementationProvider.Implementation."; //473:134
                            __out.Append(__tmp72Line);
                            StringBuilder __tmp73 = new StringBuilder();
                            __tmp73.Append(prop.Class.CSharpName());
                            using(StreamReader __tmp73Reader = new StreamReader(this.__ToStream(__tmp73.ToString())))
                            {
                                bool __tmp73_first = true;
                                while(__tmp73_first || !__tmp73Reader.EndOfStream)
                                {
                                    __tmp73_first = false;
                                    string __tmp73Line = __tmp73Reader.ReadLine();
                                    if (__tmp73Line == null)
                                    {
                                        __tmp73Line = "";
                                    }
                                    __out.Append(__tmp73Line);
                                }
                            }
                            string __tmp74Line = "_"; //473:197
                            __out.Append(__tmp74Line);
                            StringBuilder __tmp75 = new StringBuilder();
                            __tmp75.Append(prop.Name);
                            using(StreamReader __tmp75Reader = new StreamReader(this.__ToStream(__tmp75.ToString())))
                            {
                                bool __tmp75_first = true;
                                while(__tmp75_first || !__tmp75Reader.EndOfStream)
                                {
                                    __tmp75_first = false;
                                    string __tmp75Line = __tmp75Reader.ReadLine();
                                    if (__tmp75Line == null)
                                    {
                                        __tmp75Line = "";
                                    }
                                    __out.Append(__tmp75Line);
                                    __out.Append(__tmp64Suffix);
                                    __out.AppendLine(); //473:218
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Readonly) //474:6
                        {
                            string __tmp76Prefix = "    // Init "; //475:1
                            string __tmp77Suffix = string.Empty; 
                            StringBuilder __tmp78 = new StringBuilder();
                            __tmp78.Append(model.CSharpFullName());
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
                                    __out.Append(__tmp76Prefix);
                                    __out.Append(__tmp78Line);
                                }
                            }
                            string __tmp79Line = "."; //475:37
                            __out.Append(__tmp79Line);
                            StringBuilder __tmp80 = new StringBuilder();
                            __tmp80.Append(prop.Class.CSharpName());
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
                                }
                            }
                            string __tmp81Line = "."; //475:63
                            __out.Append(__tmp81Line);
                            StringBuilder __tmp82 = new StringBuilder();
                            __tmp82.Append(prop.Name);
                            using(StreamReader __tmp82Reader = new StreamReader(this.__ToStream(__tmp82.ToString())))
                            {
                                bool __tmp82_first = true;
                                while(__tmp82_first || !__tmp82Reader.EndOfStream)
                                {
                                    __tmp82_first = false;
                                    string __tmp82Line = __tmp82Reader.ReadLine();
                                    if (__tmp82Line == null)
                                    {
                                        __tmp82Line = "";
                                    }
                                    __out.Append(__tmp82Line);
                                }
                            }
                            string __tmp83Line = "Property in "; //475:75
                            __out.Append(__tmp83Line);
                            StringBuilder __tmp84 = new StringBuilder();
                            __tmp84.Append(model.CSharpName());
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
                                    __out.Append(__tmp84Line);
                                }
                            }
                            string __tmp85Line = "Implementation."; //475:107
                            __out.Append(__tmp85Line);
                            StringBuilder __tmp86 = new StringBuilder();
                            __tmp86.Append(cls.CSharpName());
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
                            string __tmp87Line = "_"; //475:140
                            __out.Append(__tmp87Line);
                            StringBuilder __tmp88 = new StringBuilder();
                            __tmp88.Append(cls.CSharpName());
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
                                    __out.Append(__tmp77Suffix);
                                    __out.AppendLine(); //475:159
                                }
                            }
                        }
                    }
                }
            }
            var __loop27_results = 
                (from __loop27_var1 in __Enumerate((cls).GetEnumerator()) //480:8
                from sup in __Enumerate((__loop27_var1.GetAllSuperClasses(true)).GetEnumerator()) //480:13
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //480:43
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //480:56
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaInheritedPropertyInitializer>() //480:70
                select new { __loop27_var1 = __loop27_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //480:3
            int __loop27_iteration = 0;
            foreach (var __tmp89 in __loop27_results)
            {
                ++__loop27_iteration;
                var __loop27_var1 = __tmp89.__loop27_var1;
                var sup = __tmp89.sup;
                var Constructor = __tmp89.Constructor;
                var Initializers = __tmp89.Initializers;
                var init = __tmp89.init;
                if (init.Object != null && init.Property != null) //481:4
                {
                    string __tmp90Prefix = "    this.MLazySetChild("; //482:1
                    string __tmp91Suffix = "));"; //482:293
                    StringBuilder __tmp92 = new StringBuilder();
                    __tmp92.Append(init.Object.Class.Model.CSharpFullName());
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
                            __out.Append(__tmp90Prefix);
                            __out.Append(__tmp92Line);
                        }
                    }
                    string __tmp93Line = "."; //482:66
                    __out.Append(__tmp93Line);
                    StringBuilder __tmp94 = new StringBuilder();
                    __tmp94.Append(init.Object.Class.CSharpName());
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
                        }
                    }
                    string __tmp95Line = "."; //482:99
                    __out.Append(__tmp95Line);
                    StringBuilder __tmp96 = new StringBuilder();
                    __tmp96.Append(init.Object.Name);
                    using(StreamReader __tmp96Reader = new StreamReader(this.__ToStream(__tmp96.ToString())))
                    {
                        bool __tmp96_first = true;
                        while(__tmp96_first || !__tmp96Reader.EndOfStream)
                        {
                            __tmp96_first = false;
                            string __tmp96Line = __tmp96Reader.ReadLine();
                            if (__tmp96Line == null)
                            {
                                __tmp96Line = "";
                            }
                            __out.Append(__tmp96Line);
                        }
                    }
                    string __tmp97Line = "Property, "; //482:118
                    __out.Append(__tmp97Line);
                    StringBuilder __tmp98 = new StringBuilder();
                    __tmp98.Append(init.Property.Class.Model.CSharpFullName());
                    using(StreamReader __tmp98Reader = new StreamReader(this.__ToStream(__tmp98.ToString())))
                    {
                        bool __tmp98_first = true;
                        while(__tmp98_first || !__tmp98Reader.EndOfStream)
                        {
                            __tmp98_first = false;
                            string __tmp98Line = __tmp98Reader.ReadLine();
                            if (__tmp98Line == null)
                            {
                                __tmp98Line = "";
                            }
                            __out.Append(__tmp98Line);
                        }
                    }
                    string __tmp99Line = "."; //482:172
                    __out.Append(__tmp99Line);
                    StringBuilder __tmp100 = new StringBuilder();
                    __tmp100.Append(init.Property.Class.CSharpName());
                    using(StreamReader __tmp100Reader = new StreamReader(this.__ToStream(__tmp100.ToString())))
                    {
                        bool __tmp100_first = true;
                        while(__tmp100_first || !__tmp100Reader.EndOfStream)
                        {
                            __tmp100_first = false;
                            string __tmp100Line = __tmp100Reader.ReadLine();
                            if (__tmp100Line == null)
                            {
                                __tmp100Line = "";
                            }
                            __out.Append(__tmp100Line);
                        }
                    }
                    string __tmp101Line = "."; //482:207
                    __out.Append(__tmp101Line);
                    StringBuilder __tmp102 = new StringBuilder();
                    __tmp102.Append(init.Property.Name);
                    using(StreamReader __tmp102Reader = new StreamReader(this.__ToStream(__tmp102.ToString())))
                    {
                        bool __tmp102_first = true;
                        while(__tmp102_first || !__tmp102Reader.EndOfStream)
                        {
                            __tmp102_first = false;
                            string __tmp102Line = __tmp102Reader.ReadLine();
                            if (__tmp102Line == null)
                            {
                                __tmp102Line = "";
                            }
                            __out.Append(__tmp102Line);
                        }
                    }
                    string __tmp103Line = "Property, new Lazy<object>(() => "; //482:228
                    __out.Append(__tmp103Line);
                    StringBuilder __tmp104 = new StringBuilder();
                    __tmp104.Append(GenerateExpression(init.Value));
                    using(StreamReader __tmp104Reader = new StreamReader(this.__ToStream(__tmp104.ToString())))
                    {
                        bool __tmp104_first = true;
                        while(__tmp104_first || !__tmp104Reader.EndOfStream)
                        {
                            __tmp104_first = false;
                            string __tmp104Line = __tmp104Reader.ReadLine();
                            if (__tmp104Line == null)
                            {
                                __tmp104Line = "";
                            }
                            __out.Append(__tmp104Line);
                            __out.Append(__tmp91Suffix);
                            __out.AppendLine(); //482:296
                        }
                    }
                }
            }
            string __tmp105Prefix = "    "; //485:1
            string __tmp106Suffix = "(this);"; //485:104
            StringBuilder __tmp107 = new StringBuilder();
            __tmp107.Append(cls.Model.CSharpName());
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
                    __out.Append(__tmp105Prefix);
                    __out.Append(__tmp107Line);
                }
            }
            string __tmp108Line = "ImplementationProvider.Implementation."; //485:29
            __out.Append(__tmp108Line);
            StringBuilder __tmp109 = new StringBuilder();
            __tmp109.Append(cls.CSharpName());
            using(StreamReader __tmp109Reader = new StreamReader(this.__ToStream(__tmp109.ToString())))
            {
                bool __tmp109_first = true;
                while(__tmp109_first || !__tmp109Reader.EndOfStream)
                {
                    __tmp109_first = false;
                    string __tmp109Line = __tmp109Reader.ReadLine();
                    if (__tmp109Line == null)
                    {
                        __tmp109Line = "";
                    }
                    __out.Append(__tmp109Line);
                }
            }
            string __tmp110Line = "_"; //485:85
            __out.Append(__tmp110Line);
            StringBuilder __tmp111 = new StringBuilder();
            __tmp111.Append(cls.CSharpName());
            using(StreamReader __tmp111Reader = new StreamReader(this.__ToStream(__tmp111.ToString())))
            {
                bool __tmp111_first = true;
                while(__tmp111_first || !__tmp111Reader.EndOfStream)
                {
                    __tmp111_first = false;
                    string __tmp111Line = __tmp111Reader.ReadLine();
                    if (__tmp111Line == null)
                    {
                        __tmp111Line = "";
                    }
                    __out.Append(__tmp111Line);
                    __out.Append(__tmp106Suffix);
                    __out.AppendLine(); //485:111
                }
            }
            var __loop28_results = 
                (from __loop28_var1 in __Enumerate((cls).GetEnumerator()) //486:11
                from prop in __Enumerate((__loop28_var1.GetAllProperties()).GetEnumerator()) //486:16
                select new { __loop28_var1 = __loop28_var1, prop = prop}
                ).ToList(); //486:6
            int __loop28_iteration = 0;
            foreach (var __tmp112 in __loop28_results)
            {
                ++__loop28_iteration;
                var __loop28_var1 = __tmp112.__loop28_var1;
                var prop = __tmp112.prop;
                if (prop.Kind == MetaPropertyKind.Readonly) //487:4
                {
                    string __tmp113Prefix = "    if (!this.MIsSet("; //488:1
                    string __tmp114Suffix = "().\");"; //488:258
                    StringBuilder __tmp115 = new StringBuilder();
                    __tmp115.Append(model.CSharpFullName());
                    using(StreamReader __tmp115Reader = new StreamReader(this.__ToStream(__tmp115.ToString())))
                    {
                        bool __tmp115_first = true;
                        while(__tmp115_first || !__tmp115Reader.EndOfStream)
                        {
                            __tmp115_first = false;
                            string __tmp115Line = __tmp115Reader.ReadLine();
                            if (__tmp115Line == null)
                            {
                                __tmp115Line = "";
                            }
                            __out.Append(__tmp113Prefix);
                            __out.Append(__tmp115Line);
                        }
                    }
                    string __tmp116Line = "."; //488:46
                    __out.Append(__tmp116Line);
                    StringBuilder __tmp117 = new StringBuilder();
                    __tmp117.Append(prop.Class.CSharpName());
                    using(StreamReader __tmp117Reader = new StreamReader(this.__ToStream(__tmp117.ToString())))
                    {
                        bool __tmp117_first = true;
                        while(__tmp117_first || !__tmp117Reader.EndOfStream)
                        {
                            __tmp117_first = false;
                            string __tmp117Line = __tmp117Reader.ReadLine();
                            if (__tmp117Line == null)
                            {
                                __tmp117Line = "";
                            }
                            __out.Append(__tmp117Line);
                        }
                    }
                    string __tmp118Line = "."; //488:72
                    __out.Append(__tmp118Line);
                    StringBuilder __tmp119 = new StringBuilder();
                    __tmp119.Append(prop.Name);
                    using(StreamReader __tmp119Reader = new StreamReader(this.__ToStream(__tmp119.ToString())))
                    {
                        bool __tmp119_first = true;
                        while(__tmp119_first || !__tmp119Reader.EndOfStream)
                        {
                            __tmp119_first = false;
                            string __tmp119Line = __tmp119Reader.ReadLine();
                            if (__tmp119Line == null)
                            {
                                __tmp119Line = "";
                            }
                            __out.Append(__tmp119Line);
                        }
                    }
                    string __tmp120Line = "Property)) throw new ModelException(\"Readonly property "; //488:84
                    __out.Append(__tmp120Line);
                    StringBuilder __tmp121 = new StringBuilder();
                    __tmp121.Append(model.CSharpName());
                    using(StreamReader __tmp121Reader = new StreamReader(this.__ToStream(__tmp121.ToString())))
                    {
                        bool __tmp121_first = true;
                        while(__tmp121_first || !__tmp121Reader.EndOfStream)
                        {
                            __tmp121_first = false;
                            string __tmp121Line = __tmp121Reader.ReadLine();
                            if (__tmp121Line == null)
                            {
                                __tmp121Line = "";
                            }
                            __out.Append(__tmp121Line);
                        }
                    }
                    string __tmp122Line = "."; //488:159
                    __out.Append(__tmp122Line);
                    StringBuilder __tmp123 = new StringBuilder();
                    __tmp123.Append(prop.Class.CSharpName());
                    using(StreamReader __tmp123Reader = new StreamReader(this.__ToStream(__tmp123.ToString())))
                    {
                        bool __tmp123_first = true;
                        while(__tmp123_first || !__tmp123Reader.EndOfStream)
                        {
                            __tmp123_first = false;
                            string __tmp123Line = __tmp123Reader.ReadLine();
                            if (__tmp123Line == null)
                            {
                                __tmp123Line = "";
                            }
                            __out.Append(__tmp123Line);
                        }
                    }
                    string __tmp124Line = "."; //488:185
                    __out.Append(__tmp124Line);
                    StringBuilder __tmp125 = new StringBuilder();
                    __tmp125.Append(prop.Name);
                    using(StreamReader __tmp125Reader = new StreamReader(this.__ToStream(__tmp125.ToString())))
                    {
                        bool __tmp125_first = true;
                        while(__tmp125_first || !__tmp125Reader.EndOfStream)
                        {
                            __tmp125_first = false;
                            string __tmp125Line = __tmp125Reader.ReadLine();
                            if (__tmp125Line == null)
                            {
                                __tmp125Line = "";
                            }
                            __out.Append(__tmp125Line);
                        }
                    }
                    string __tmp126Line = "Property was not set in "; //488:197
                    __out.Append(__tmp126Line);
                    StringBuilder __tmp127 = new StringBuilder();
                    __tmp127.Append(cls.CSharpName());
                    using(StreamReader __tmp127Reader = new StreamReader(this.__ToStream(__tmp127.ToString())))
                    {
                        bool __tmp127_first = true;
                        while(__tmp127_first || !__tmp127Reader.EndOfStream)
                        {
                            __tmp127_first = false;
                            string __tmp127Line = __tmp127Reader.ReadLine();
                            if (__tmp127Line == null)
                            {
                                __tmp127Line = "";
                            }
                            __out.Append(__tmp127Line);
                        }
                    }
                    string __tmp128Line = "_"; //488:239
                    __out.Append(__tmp128Line);
                    StringBuilder __tmp129 = new StringBuilder();
                    __tmp129.Append(cls.CSharpName());
                    using(StreamReader __tmp129Reader = new StreamReader(this.__ToStream(__tmp129.ToString())))
                    {
                        bool __tmp129_first = true;
                        while(__tmp129_first || !__tmp129Reader.EndOfStream)
                        {
                            __tmp129_first = false;
                            string __tmp129Line = __tmp129Reader.ReadLine();
                            if (__tmp129Line == null)
                            {
                                __tmp129Line = "";
                            }
                            __out.Append(__tmp129Line);
                            __out.Append(__tmp114Suffix);
                            __out.AppendLine(); //488:264
                        }
                    }
                }
            }
            __out.Append("    this.MMakeDefault();"); //491:1
            __out.AppendLine(); //491:25
            __out.Append("}"); //492:1
            __out.AppendLine(); //492:2
            return __out.ToString();
        }

        public string GetReturn(MetaOperation op) //495:1
        {
            if (op.ReturnType.CSharpName() == "void") //496:5
            {
                return ""; //497:3
            }
            else //498:2
            {
                return "return "; //499:3
            }
        }

        public string GenerateOperationImpl(MetaModel model, MetaOperation op) //503:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //504:2
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = ")"; //505:97
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(op.ReturnType.CSharpPublicName());
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
            string __tmp4Line = " "; //505:35
            __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(op.Parent.CSharpName());
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
            string __tmp6Line = "."; //505:60
            __out.Append(__tmp6Line);
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(op.Name);
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
                }
            }
            string __tmp8Line = "("; //505:70
            __out.Append(__tmp8Line);
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(GetParameters(op, false));
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
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //505:98
                }
            }
            __out.Append("{"); //506:1
            __out.AppendLine(); //506:2
            string __tmp10Prefix = "    "; //507:1
            string __tmp11Suffix = ");"; //507:144
            StringBuilder __tmp12 = new StringBuilder();
            __tmp12.Append(GetReturn(op));
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
            __tmp13.Append(model.CSharpName());
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
            string __tmp14Line = "ImplementationProvider.Implementation."; //507:40
            __out.Append(__tmp14Line);
            StringBuilder __tmp15 = new StringBuilder();
            __tmp15.Append(op.Parent.CSharpName());
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
            string __tmp16Line = "_"; //507:102
            __out.Append(__tmp16Line);
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(op.Name);
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
                }
            }
            string __tmp18Line = "("; //507:112
            __out.Append(__tmp18Line);
            StringBuilder __tmp19 = new StringBuilder();
            __tmp19.Append(GetImplCallParameterNames(op));
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
                    __out.Append(__tmp11Suffix);
                    __out.AppendLine(); //507:146
                }
            }
            __out.Append("}"); //508:1
            __out.AppendLine(); //508:2
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
                result += delim + sup.CSharpName(); //514:3
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
                result += delim + sup.CSharpName(); //522:3
            }
            return result; //524:2
        }

        public string GenerateMetaModel(MetaModel model) //527:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public static class "; //528:1
            string __tmp2Suffix = string.Empty; 
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.CSharpName());
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
                    __out.AppendLine(); //528:41
                }
            }
            __out.Append("{"); //529:1
            __out.AppendLine(); //529:2
            __out.Append("	internal static global::MetaDslx.Core.Model model;"); //530:1
            __out.AppendLine(); //530:52
            __out.AppendLine(); //531:2
            string __tmp4Prefix = "    static "; //532:1
            string __tmp5Suffix = "()"; //532:32
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(model.CSharpName());
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
                    __out.AppendLine(); //532:34
                }
            }
            __out.Append("    {"); //533:1
            __out.AppendLine(); //533:6
            string __tmp7Prefix = "	    "; //534:1
            string __tmp8Suffix = ".model = new global::MetaDslx.Core.Model();"; //534:26
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(model.CSharpName());
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
                    __out.AppendLine(); //534:69
                }
            }
            var __loop31_results = 
                (from __loop31_var1 in __Enumerate((model).GetEnumerator()) //535:11
                from Types in __Enumerate((__loop31_var1.Types).GetEnumerator()) //535:18
                from cls in __Enumerate((Types).GetEnumerator()).OfType<MetaClass>() //535:25
                select new { __loop31_var1 = __loop31_var1, Types = Types, cls = cls}
                ).ToList(); //535:6
            int __loop31_iteration = 0;
            foreach (var __tmp10 in __loop31_results)
            {
                ++__loop31_iteration;
                var __loop31_var1 = __tmp10.__loop31_var1;
                var Types = __tmp10.Types;
                var cls = __tmp10.cls;
                string __tmp11Prefix = "        "; //536:1
                string __tmp12Suffix = ".StaticInit();"; //536:27
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(cls.CSharpName());
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
                        __out.AppendLine(); //536:41
                    }
                }
                string __tmp14Prefix = "        model.AddInstance((global::MetaDslx.Core.ModelObject)"; //537:1
                string __tmp15Suffix = ".Instance);"; //537:80
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(cls.CSharpName());
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
                        __out.AppendLine(); //537:91
                    }
                }
            }
            __out.Append("    }"); //539:1
            __out.AppendLine(); //539:6
            __out.AppendLine(); //540:2
            __out.Append("    internal static void StaticInit()"); //541:1
            __out.AppendLine(); //541:38
            __out.Append("    {"); //542:1
            __out.AppendLine(); //542:6
            __out.Append("    }"); //543:1
            __out.AppendLine(); //543:6
            __out.AppendLine(); //544:2
            string __tmp17Prefix = "	public const string Uri = \""; //545:1
            string __tmp18Suffix = "\";"; //545:40
            StringBuilder __tmp19 = new StringBuilder();
            __tmp19.Append(model.Uri);
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
                    __out.AppendLine(); //545:42
                }
            }
            string __tmp20Prefix = "	public const string Prefix = \""; //546:1
            string __tmp21Suffix = "\";"; //546:46
            StringBuilder __tmp22 = new StringBuilder();
            __tmp22.Append(model.Prefix);
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
                    __out.AppendLine(); //546:48
                }
            }
            __out.AppendLine(); //547:2
            __out.Append("    public static global::MetaDslx.Core.Model Model"); //548:1
            __out.AppendLine(); //548:52
            __out.Append("    {"); //549:1
            __out.AppendLine(); //549:6
            string __tmp23Prefix = "        get { return "; //550:1
            string __tmp24Suffix = ".model; }"; //550:42
            StringBuilder __tmp25 = new StringBuilder();
            __tmp25.Append(model.CSharpName());
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
                    __out.AppendLine(); //550:51
                }
            }
            __out.Append("    }"); //551:1
            __out.AppendLine(); //551:6
            __out.AppendLine(); //552:2
            __out.Append("    public static class Constants"); //553:1
            __out.AppendLine(); //553:34
            __out.Append("    {"); //554:1
            __out.AppendLine(); //554:6
            __out.Append("        static Constants()"); //555:1
            __out.AppendLine(); //555:27
            __out.Append("        {"); //556:1
            __out.AppendLine(); //556:10
            var __loop32_results = 
                (from __loop32_var1 in __Enumerate((model).GetEnumerator()) //557:11
                from c in __Enumerate((__loop32_var1.Constants).GetEnumerator()) //557:18
                select new { __loop32_var1 = __loop32_var1, c = c}
                ).ToList(); //557:6
            int __loop32_iteration = 0;
            foreach (var __tmp26 in __loop32_results)
            {
                ++__loop32_iteration;
                var __loop32_var1 = __tmp26.__loop32_var1;
                var c = __tmp26.c;
                string __tmp27Prefix = "            "; //558:1
                string __tmp28Suffix = string.Empty; 
                StringBuilder __tmp29 = new StringBuilder();
                __tmp29.Append(GenerateModelConstantImpl(c));
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
                        __out.AppendLine(); //558:43
                    }
                }
            }
            __out.AppendLine(); //560:2
            var __loop33_results = 
                (from __loop33_var1 in __Enumerate((model).GetEnumerator()) //561:11
                from f in __Enumerate((__loop33_var1.Functions).GetEnumerator()) //561:18
                select new { __loop33_var1 = __loop33_var1, f = f}
                ).ToList(); //561:6
            int __loop33_iteration = 0;
            foreach (var __tmp30 in __loop33_results)
            {
                ++__loop33_iteration;
                var __loop33_var1 = __tmp30.__loop33_var1;
                var f = __tmp30.f;
                string __tmp31Prefix = "            "; //562:1
                string __tmp32Suffix = string.Empty; 
                StringBuilder __tmp33 = new StringBuilder();
                __tmp33.Append(GenerateModelFunctionImpl(f));
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
                        __out.Append(__tmp32Suffix);
                        __out.AppendLine(); //562:43
                    }
                }
            }
            __out.Append("        }"); //564:1
            __out.AppendLine(); //564:10
            __out.AppendLine(); //565:2
            var __loop34_results = 
                (from __loop34_var1 in __Enumerate((model).GetEnumerator()) //566:11
                from c in __Enumerate((__loop34_var1.Constants).GetEnumerator()) //566:18
                select new { __loop34_var1 = __loop34_var1, c = c}
                ).ToList(); //566:6
            int __loop34_iteration = 0;
            foreach (var __tmp34 in __loop34_results)
            {
                ++__loop34_iteration;
                var __loop34_var1 = __tmp34.__loop34_var1;
                var c = __tmp34.c;
                string __tmp35Prefix = "        "; //567:1
                string __tmp36Suffix = string.Empty; 
                StringBuilder __tmp37 = new StringBuilder();
                __tmp37.Append(GenerateModelConstant(c));
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
                        __out.Append(__tmp35Prefix);
                        __out.Append(__tmp37Line);
                        __out.Append(__tmp36Suffix);
                        __out.AppendLine(); //567:35
                    }
                }
            }
            __out.AppendLine(); //569:2
            var __loop35_results = 
                (from __loop35_var1 in __Enumerate((model).GetEnumerator()) //570:11
                from f in __Enumerate((__loop35_var1.Functions).GetEnumerator()) //570:18
                select new { __loop35_var1 = __loop35_var1, f = f}
                ).ToList(); //570:6
            int __loop35_iteration = 0;
            foreach (var __tmp38 in __loop35_results)
            {
                ++__loop35_iteration;
                var __loop35_var1 = __tmp38.__loop35_var1;
                var f = __tmp38.f;
                string __tmp39Prefix = "        "; //571:1
                string __tmp40Suffix = string.Empty; 
                StringBuilder __tmp41 = new StringBuilder();
                __tmp41.Append(GenerateModelFunction(f));
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
                        __out.Append(__tmp40Suffix);
                        __out.AppendLine(); //571:35
                    }
                }
            }
            __out.Append("    }"); //573:1
            __out.AppendLine(); //573:6
            __out.AppendLine(); //574:2
            var __loop36_results = 
                (from __loop36_var1 in __Enumerate((model).GetEnumerator()) //575:11
                from Types in __Enumerate((__loop36_var1.Types).GetEnumerator()) //575:18
                from cls in __Enumerate((Types).GetEnumerator()).OfType<MetaClass>() //575:25
                select new { __loop36_var1 = __loop36_var1, Types = Types, cls = cls}
                ).ToList(); //575:6
            int __loop36_iteration = 0;
            foreach (var __tmp42 in __loop36_results)
            {
                ++__loop36_iteration;
                var __loop36_var1 = __tmp42.__loop36_var1;
                var Types = __tmp42.Types;
                var cls = __tmp42.cls;
                string __tmp43Prefix = "    "; //576:1
                string __tmp44Suffix = string.Empty; 
                StringBuilder __tmp45 = new StringBuilder();
                __tmp45.Append(GenerateMetaModelClass(cls));
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
                        __out.Append(__tmp43Prefix);
                        __out.Append(__tmp45Line);
                        __out.Append(__tmp44Suffix);
                        __out.AppendLine(); //576:34
                    }
                }
            }
            __out.Append("}"); //578:1
            __out.AppendLine(); //578:2
            __out.AppendLine(); //579:2
            return __out.ToString();
        }

        public string GenerateMetaModelClass(MetaClass cls) //582:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //583:2
            string __tmp1Prefix = "public static class "; //584:1
            string __tmp2Suffix = string.Empty; 
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.CSharpName());
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
                    __out.AppendLine(); //584:39
                }
            }
            __out.Append("{"); //585:1
            __out.AppendLine(); //585:2
            __out.Append("	internal static global::MetaDslx.Core.MetaClass instance;"); //586:1
            __out.AppendLine(); //586:59
            __out.Append("    internal static void StaticInit()"); //588:1
            __out.AppendLine(); //588:38
            __out.Append("    {"); //589:1
            __out.AppendLine(); //589:6
            __out.Append("    }"); //590:1
            __out.AppendLine(); //590:6
            __out.AppendLine(); //591:2
            string __tmp4Prefix = "    static "; //592:1
            string __tmp5Suffix = "()"; //592:30
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(cls.CSharpName());
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
                    __out.AppendLine(); //592:32
                }
            }
            __out.Append("    {"); //593:1
            __out.AppendLine(); //593:6
            string __tmp7Prefix = "        "; //594:1
            string __tmp8Suffix = ".StaticInit();"; //594:37
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(cls.Model.CSharpFullName());
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
                    __out.AppendLine(); //594:51
                }
            }
            string __tmp10Prefix = "        "; //595:1
            string __tmp11Suffix = ".instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);"; //595:27
            StringBuilder __tmp12 = new StringBuilder();
            __tmp12.Append(cls.CSharpName());
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
                    __out.AppendLine(); //595:110
                }
            }
            if (cls.IsAbstract) //596:4
            {
                string __tmp13Prefix = "		"; //597:1
                string __tmp14Suffix = ".instance.IsAbstract = true;"; //597:21
                StringBuilder __tmp15 = new StringBuilder();
                __tmp15.Append(cls.CSharpName());
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
                        __out.Append(__tmp14Suffix);
                        __out.AppendLine(); //597:49
                    }
                }
            }
            string __tmp16Prefix = "        "; //599:1
            string __tmp17Suffix = "\";"; //599:63
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append(cls.CSharpName());
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
                }
            }
            string __tmp19Line = ".instance.Name = \""; //599:27
            __out.Append(__tmp19Line);
            StringBuilder __tmp20 = new StringBuilder();
            __tmp20.Append(cls.CSharpName());
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
                    __out.Append(__tmp20Line);
                    __out.Append(__tmp17Suffix);
                    __out.AppendLine(); //599:65
                }
            }
            var __loop37_results = 
                (from __loop37_var1 in __Enumerate((cls).GetEnumerator()) //600:9
                from sup in __Enumerate((__loop37_var1.SuperClasses).GetEnumerator()) //600:14
                select new { __loop37_var1 = __loop37_var1, sup = sup}
                ).ToList(); //600:4
            int __loop37_iteration = 0;
            foreach (var __tmp21 in __loop37_results)
            {
                ++__loop37_iteration;
                var __loop37_var1 = __tmp21.__loop37_var1;
                var sup = __tmp21.sup;
                string __tmp22Prefix = "        ((ModelCollection)"; //601:1
                string __tmp23Suffix = ".Instance));"; //601:148
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(cls.CSharpName());
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
                    }
                }
                string __tmp25Line = ".instance.SuperClasses).MLazyAdd(new Lazy<object>(() => "; //601:45
                __out.Append(__tmp25Line);
                StringBuilder __tmp26 = new StringBuilder();
                __tmp26.Append(sup.Model.CSharpFullName());
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
                    }
                }
                string __tmp27Line = "."; //601:129
                __out.Append(__tmp27Line);
                StringBuilder __tmp28 = new StringBuilder();
                __tmp28.Append(sup.CSharpName());
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
                        __out.Append(__tmp23Suffix);
                        __out.AppendLine(); //601:160
                    }
                }
            }
            __out.Append("    }"); //603:1
            __out.AppendLine(); //603:6
            __out.AppendLine(); //604:2
            __out.Append("    public static global::MetaDslx.Core.MetaClass Instance"); //605:1
            __out.AppendLine(); //605:59
            __out.Append("    {"); //606:1
            __out.AppendLine(); //606:6
            string __tmp29Prefix = "        get { return "; //607:1
            string __tmp30Suffix = ".instance; }"; //607:40
            StringBuilder __tmp31 = new StringBuilder();
            __tmp31.Append(cls.CSharpName());
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
                    __out.Append(__tmp29Prefix);
                    __out.Append(__tmp31Line);
                    __out.Append(__tmp30Suffix);
                    __out.AppendLine(); //607:52
                }
            }
            __out.Append("    }"); //608:1
            __out.AppendLine(); //608:6
            __out.AppendLine(); //609:2
            var __loop38_results = 
                (from __loop38_var1 in __Enumerate((cls).GetEnumerator()) //610:11
                from prop in __Enumerate((__loop38_var1.Properties).GetEnumerator()) //610:16
                select new { __loop38_var1 = __loop38_var1, prop = prop}
                ).ToList(); //610:6
            int __loop38_iteration = 0;
            foreach (var __tmp32 in __loop38_results)
            {
                ++__loop38_iteration;
                var __loop38_var1 = __tmp32.__loop38_var1;
                var prop = __tmp32.prop;
                string __tmp33Prefix = "    "; //611:1
                string __tmp34Suffix = string.Empty; 
                StringBuilder __tmp35 = new StringBuilder();
                __tmp35.Append(GeneratePropertyDeclaration(cls.Model, cls, prop));
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
                        __out.AppendLine(); //611:56
                    }
                }
            }
            __out.Append("}"); //613:1
            __out.AppendLine(); //613:2
            return __out.ToString();
        }

        public string GenerateModelConstant(MetaConstant mconst) //617:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public static "; //618:1
            string __tmp2Suffix = " { get; private set; }"; //618:59
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(mconst.Type.CSharpFullName());
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
            string __tmp4Line = " "; //618:45
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
                    __out.AppendLine(); //618:81
                }
            }
            return __out.ToString();
        }

        public string GenerateModelFunction(MetaFunction mfunc) //621:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public static global::MetaDslx.Core.MetaFunction "; //622:1
            string __tmp2Suffix = " { get; private set; }"; //622:62
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(mfunc.Name);
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
                    __out.AppendLine(); //622:84
                }
            }
            return __out.ToString();
        }

        public string GenerateModelConstantImpl(MetaConstant mconst) //625:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty;
            string __tmp2Suffix = string.Empty;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateConstantValueExpression(mconst.Name, mconst.Value, null));
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
                    __out.AppendLine(); //626:67
                }
            }
            return __out.ToString();
        }

        public string GenerateModelFunctionImpl(MetaFunction mfunc) //629:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = " = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaFunction();"; //630:13
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(mfunc.Name);
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
                    __out.AppendLine(); //630:85
                }
            }
            if ((from __loop39_var1 in __Enumerate((mfunc).GetEnumerator()) //631:14
            from a in __Enumerate((__loop39_var1.Annotations).GetEnumerator()) //631:21
            where a.Name == "Name" //631:35
            select new { __loop39_var1 = __loop39_var1, a = a}
            ).GetEnumerator().MoveNext()) //631:2
            {
                var __loop40_results = 
                    (from __loop40_var1 in __Enumerate((mfunc).GetEnumerator()) //632:8
                    from a in __Enumerate((__loop40_var1.Annotations).GetEnumerator()) //632:15
                    from p in __Enumerate((a.Properties).GetEnumerator()) //632:30
                    where a.Name == "Name" && p.Name == "Name" //632:43
                    select new { __loop40_var1 = __loop40_var1, a = a, p = p}
                    ).ToList(); //632:3
                int __loop40_iteration = 0;
                foreach (var __tmp4 in __loop40_results)
                {
                    ++__loop40_iteration;
                    var __loop40_var1 = __tmp4.__loop40_var1;
                    var a = __tmp4.a;
                    var p = __tmp4.p;
                    string __tmp5Prefix = string.Empty; 
                    string __tmp6Suffix = ";"; //633:50
                    StringBuilder __tmp7 = new StringBuilder();
                    __tmp7.Append(mfunc.Name);
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
                    string __tmp8Line = ".Name = "; //633:13
                    __out.Append(__tmp8Line);
                    StringBuilder __tmp9 = new StringBuilder();
                    __tmp9.Append(GenerateExpression(p.Value));
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
                            __out.AppendLine(); //633:51
                        }
                    }
                }
            }
            else //635:2
            {
                string __tmp10Prefix = string.Empty; 
                string __tmp11Suffix = "\";"; //636:34
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(mfunc.Name);
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
                string __tmp13Line = ".Name = \""; //636:13
                __out.Append(__tmp13Line);
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(mfunc.Name);
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
                        __out.AppendLine(); //636:36
                    }
                }
            }
            string __tmp15Prefix = string.Empty;
            string __tmp16Suffix = string.Empty;
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(GenerateModelFunctionImplTypeOf(mfunc.Name + ".ReturnType", mfunc.ReturnType));
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
                    __out.AppendLine(); //638:78
                }
            }
            var __loop41_results = 
                (from __loop41_var1 in __Enumerate((mfunc).GetEnumerator()) //639:7
                from p in __Enumerate((__loop41_var1.Parameters).GetEnumerator()) //639:14
                select new { __loop41_var1 = __loop41_var1, p = p}
                ).ToList(); //639:2
            int __loop41_iteration = 0;
            foreach (var __tmp18 in __loop41_results)
            {
                ++__loop41_iteration;
                var __loop41_var1 = __tmp18.__loop41_var1;
                var p = __tmp18.p;
                string tmpName = "tmp" + NextCounter(); //640:2
                string __tmp19Prefix = "global::MetaDslx.Core.MetaParameter "; //641:1
                string __tmp20Suffix = " = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();"; //641:46
                StringBuilder __tmp21 = new StringBuilder();
                __tmp21.Append(tmpName);
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
                        __out.Append(__tmp19Prefix);
                        __out.Append(__tmp21Line);
                        __out.Append(__tmp20Suffix);
                        __out.AppendLine(); //641:119
                    }
                }
                string __tmp22Prefix = string.Empty; 
                string __tmp23Suffix = "\";"; //642:27
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(tmpName);
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
                    }
                }
                string __tmp25Line = ".Name = \""; //642:10
                __out.Append(__tmp25Line);
                StringBuilder __tmp26 = new StringBuilder();
                __tmp26.Append(p.Name);
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
                        __out.Append(__tmp23Suffix);
                        __out.AppendLine(); //642:29
                    }
                }
                string __tmp27Prefix = string.Empty;
                string __tmp28Suffix = string.Empty;
                StringBuilder __tmp29 = new StringBuilder();
                __tmp29.Append(GenerateModelFunctionImplTypeOf(tmpName + ".Type", p.Type));
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
                        __out.AppendLine(); //643:59
                    }
                }
                string __tmp30Prefix = string.Empty; 
                string __tmp31Suffix = ");"; //644:38
                StringBuilder __tmp32 = new StringBuilder();
                __tmp32.Append(mfunc.Name);
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
                    }
                }
                string __tmp33Line = ".Parameters.Add("; //644:13
                __out.Append(__tmp33Line);
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
                        __out.Append(__tmp34Line);
                        __out.Append(__tmp31Suffix);
                        __out.AppendLine(); //644:40
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelFunctionImplTypeOf(string name, MetaType mtype) //648:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = mtype; //649:9
            if (mtype is MetaCollectionType) //650:2
            {
                string tmpName = "tmp" + NextCounter(); //651:2
                string __tmp2Prefix = "global::MetaDslx.Core.MetaCollectionType "; //652:1
                string __tmp3Suffix = " = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaCollectionType();"; //652:51
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append(tmpName);
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
                        __out.AppendLine(); //652:129
                    }
                }
                string __tmp5Prefix = string.Empty; 
                string __tmp6Suffix = ";"; //653:19
                StringBuilder __tmp7 = new StringBuilder();
                __tmp7.Append(name);
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
                string __tmp8Line = " = "; //653:7
                __out.Append(__tmp8Line);
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
                        __out.Append(__tmp9Line);
                        __out.Append(__tmp6Suffix);
                        __out.AppendLine(); //653:20
                    }
                }
                string __tmp10Prefix = string.Empty; 
                string __tmp11Suffix = ";"; //654:49
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(tmpName);
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
                string __tmp13Line = ".Kind = MetaCollectionKind."; //654:10
                __out.Append(__tmp13Line);
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(((MetaCollectionType)mtype).Kind);
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
                        __out.AppendLine(); //654:50
                    }
                }
                string __tmp15Prefix = string.Empty;
                string __tmp16Suffix = string.Empty;
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(GenerateModelFunctionImplTypeOf(tmpName + ".InnerType", ((MetaCollectionType)mtype).InnerType));
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
                        __out.AppendLine(); //655:73
                    }
                }
            }
            else //656:2
            {
                __out.Append(name);
                __out.Append(" = "); //656:17
                __out.Append(GenerateTypeOf(mtype));
                __out.Append(";"); //656:43
                __out.AppendLine(); //656:44
            }//657:2
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //660:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "internal static class "; //661:1
            string __tmp2Suffix = "ImplementationProvider"; //661:43
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.CSharpName());
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
                    __out.AppendLine(); //661:65
                }
            }
            __out.Append("{"); //662:1
            __out.AppendLine(); //662:2
            string __tmp4Prefix = "    // If there is a compile error at this line, create a new class called "; //663:1
            string __tmp5Suffix = "Implementation"; //663:96
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(model.CSharpName());
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
                    __out.AppendLine(); //663:110
                }
            }
            string __tmp7Prefix = "	// which is a subclass of "; //664:1
            string __tmp8Suffix = "ImplementationBase:"; //664:48
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(model.CSharpName());
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
                    __out.AppendLine(); //664:67
                }
            }
            string __tmp10Prefix = "    private static "; //665:1
            string __tmp11Suffix = "Implementation();"; //665:96
            StringBuilder __tmp12 = new StringBuilder();
            __tmp12.Append(model.CSharpName());
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
            string __tmp13Line = "Implementation implementation = new "; //665:40
            __out.Append(__tmp13Line);
            StringBuilder __tmp14 = new StringBuilder();
            __tmp14.Append(model.CSharpName());
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
                    __out.AppendLine(); //665:113
                }
            }
            __out.AppendLine(); //666:2
            string __tmp15Prefix = "    public static "; //667:1
            string __tmp16Suffix = "Implementation Implementation"; //667:39
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(model.CSharpName());
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
                    __out.AppendLine(); //667:68
                }
            }
            __out.Append("    {"); //668:1
            __out.AppendLine(); //668:6
            string __tmp18Prefix = "        get { return "; //669:1
            string __tmp19Suffix = "ImplementationProvider.implementation; }"; //669:42
            StringBuilder __tmp20 = new StringBuilder();
            __tmp20.Append(model.CSharpName());
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
                    __out.AppendLine(); //669:82
                }
            }
            __out.Append("    }"); //670:1
            __out.AppendLine(); //670:6
            __out.Append("}"); //671:1
            __out.AppendLine(); //671:2
            var __loop42_results = 
                (from __loop42_var1 in __Enumerate((model).GetEnumerator()) //672:8
                from Types in __Enumerate((__loop42_var1.Types).GetEnumerator()) //672:15
                from enm in __Enumerate((Types).GetEnumerator()).OfType<MetaEnum>() //672:22
                select new { __loop42_var1 = __loop42_var1, Types = Types, enm = enm}
                ).ToList(); //672:3
            int __loop42_iteration = 0;
            foreach (var __tmp21 in __loop42_results)
            {
                ++__loop42_iteration;
                var __loop42_var1 = __tmp21.__loop42_var1;
                var Types = __tmp21.Types;
                var enm = __tmp21.enm;
                __out.AppendLine(); //673:2
                string __tmp22Prefix = "public static class "; //674:1
                string __tmp23Suffix = "Extensions"; //674:51
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(model.CSharpName());
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
                    }
                }
                StringBuilder __tmp25 = new StringBuilder();
                __tmp25.Append(enm.Name);
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
                        __out.Append(__tmp23Suffix);
                        __out.AppendLine(); //674:61
                    }
                }
                __out.Append("{"); //675:1
                __out.AppendLine(); //675:2
                var __loop43_results = 
                    (from __loop43_var1 in __Enumerate((enm).GetEnumerator()) //676:11
                    from op in __Enumerate((__loop43_var1.Operations).GetEnumerator()) //676:16
                    select new { __loop43_var1 = __loop43_var1, op = op}
                    ).ToList(); //676:6
                int __loop43_iteration = 0;
                foreach (var __tmp26 in __loop43_results)
                {
                    ++__loop43_iteration;
                    var __loop43_var1 = __tmp26.__loop43_var1;
                    var op = __tmp26.op;
                    string __tmp27Prefix = "    public static "; //677:1
                    string __tmp28Suffix = ")"; //677:96
                    StringBuilder __tmp29 = new StringBuilder();
                    __tmp29.Append(op.ReturnType.CSharpPublicName());
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
                    string __tmp30Line = " "; //677:53
                    __out.Append(__tmp30Line);
                    StringBuilder __tmp31 = new StringBuilder();
                    __tmp31.Append(op.Name);
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
                    string __tmp32Line = "("; //677:63
                    __out.Append(__tmp32Line);
                    StringBuilder __tmp33 = new StringBuilder();
                    __tmp33.Append(GetEnumImplParameters(enm, op));
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
                            __out.Append(__tmp28Suffix);
                            __out.AppendLine(); //677:97
                        }
                    }
                    __out.Append("    {"); //678:1
                    __out.AppendLine(); //678:6
                    string __tmp34Prefix = "        "; //679:1
                    string __tmp35Suffix = ");"; //679:152
                    StringBuilder __tmp36 = new StringBuilder();
                    __tmp36.Append(GetReturn(op));
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
                            __out.Append(__tmp34Prefix);
                            __out.Append(__tmp36Line);
                        }
                    }
                    StringBuilder __tmp37 = new StringBuilder();
                    __tmp37.Append(model.CSharpName());
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
                    string __tmp38Line = "ImplementationProvider.Implementation."; //679:44
                    __out.Append(__tmp38Line);
                    StringBuilder __tmp39 = new StringBuilder();
                    __tmp39.Append(op.Parent.CSharpName());
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
                    string __tmp40Line = "_"; //679:106
                    __out.Append(__tmp40Line);
                    StringBuilder __tmp41 = new StringBuilder();
                    __tmp41.Append(op.Name);
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
                    string __tmp42Line = "("; //679:116
                    __out.Append(__tmp42Line);
                    StringBuilder __tmp43 = new StringBuilder();
                    __tmp43.Append(GetEnumImplCallParameterNames(op));
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
                            __out.Append(__tmp35Suffix);
                            __out.AppendLine(); //679:154
                        }
                    }
                    __out.Append("    }"); //680:1
                    __out.AppendLine(); //680:6
                }
                __out.Append("}"); //682:1
                __out.AppendLine(); //682:2
            }
            __out.AppendLine(); //684:2
            __out.Append("/// <summary>"); //685:1
            __out.AppendLine(); //685:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //686:1
            __out.AppendLine(); //686:68
            string __tmp44Prefix = "/// This class has to be be overriden in "; //687:1
            string __tmp45Suffix = "Implementation to provide custom"; //687:62
            StringBuilder __tmp46 = new StringBuilder();
            __tmp46.Append(model.CSharpName());
            using(StreamReader __tmp46Reader = new StreamReader(this.__ToStream(__tmp46.ToString())))
            {
                bool __tmp46_first = true;
                while(__tmp46_first || !__tmp46Reader.EndOfStream)
                {
                    __tmp46_first = false;
                    string __tmp46Line = __tmp46Reader.ReadLine();
                    if (__tmp46Line == null)
                    {
                        __tmp46Line = "";
                    }
                    __out.Append(__tmp44Prefix);
                    __out.Append(__tmp46Line);
                    __out.Append(__tmp45Suffix);
                    __out.AppendLine(); //687:94
                }
            }
            __out.Append("/// implementation for the constructors, operations and property values."); //688:1
            __out.AppendLine(); //688:73
            __out.Append("/// </summary>"); //689:1
            __out.AppendLine(); //689:15
            string __tmp47Prefix = "internal abstract class "; //690:1
            string __tmp48Suffix = "ImplementationBase"; //690:45
            StringBuilder __tmp49 = new StringBuilder();
            __tmp49.Append(model.CSharpName());
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
                    __out.Append(__tmp47Prefix);
                    __out.Append(__tmp49Line);
                    __out.Append(__tmp48Suffix);
                    __out.AppendLine(); //690:63
                }
            }
            __out.Append("{"); //691:1
            __out.AppendLine(); //691:2
            var __loop44_results = 
                (from __loop44_var1 in __Enumerate((model).GetEnumerator()) //692:8
                from Types in __Enumerate((__loop44_var1.Types).GetEnumerator()) //692:15
                from cls in __Enumerate((Types).GetEnumerator()).OfType<MetaClass>() //692:22
                select new { __loop44_var1 = __loop44_var1, Types = Types, cls = cls}
                ).ToList(); //692:3
            int __loop44_iteration = 0;
            foreach (var __tmp50 in __loop44_results)
            {
                ++__loop44_iteration;
                var __loop44_var1 = __tmp50.__loop44_var1;
                var Types = __tmp50.Types;
                var cls = __tmp50.cls;
                __out.Append("    /// <summary>"); //693:1
                __out.AppendLine(); //693:18
                string __tmp51Prefix = "	/// Implements the constructor: "; //694:1
                string __tmp52Suffix = "()"; //694:52
                StringBuilder __tmp53 = new StringBuilder();
                __tmp53.Append(cls.CSharpName());
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
                        __out.Append(__tmp51Prefix);
                        __out.Append(__tmp53Line);
                        __out.Append(__tmp52Suffix);
                        __out.AppendLine(); //694:54
                    }
                }
                if ((from __loop45_var1 in __Enumerate((cls).GetEnumerator()) //695:15
                from sup in __Enumerate((__loop45_var1.SuperClasses).GetEnumerator()) //695:20
                select new { __loop45_var1 = __loop45_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //695:3
                {
                    string __tmp54Prefix = "	/// Direct superclasses: "; //696:1
                    string __tmp55Suffix = string.Empty; 
                    StringBuilder __tmp56 = new StringBuilder();
                    __tmp56.Append(GetSuperClasses(cls));
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
                            __out.Append(__tmp55Suffix);
                            __out.AppendLine(); //696:49
                        }
                    }
                    string __tmp57Prefix = "	/// All superclasses: "; //697:1
                    string __tmp58Suffix = string.Empty; 
                    StringBuilder __tmp59 = new StringBuilder();
                    __tmp59.Append(GetAllSuperClasses(cls));
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
                            __out.Append(__tmp57Prefix);
                            __out.Append(__tmp59Line);
                            __out.Append(__tmp58Suffix);
                            __out.AppendLine(); //697:49
                        }
                    }
                }
                if ((from __loop46_var1 in __Enumerate((cls).GetEnumerator()) //699:15
                from prop in __Enumerate((__loop46_var1.GetAllProperties()).GetEnumerator()) //699:20
                where prop.Kind == MetaPropertyKind.Readonly //699:44
                select new { __loop46_var1 = __loop46_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //699:3
                {
                    __out.Append("    // Initializes the following readonly properties:"); //700:1
                    __out.AppendLine(); //700:54
                }
                var __loop47_results = 
                    (from __loop47_var1 in __Enumerate((cls).GetEnumerator()) //702:11
                    from prop in __Enumerate((__loop47_var1.GetAllProperties()).GetEnumerator()) //702:16
                    select new { __loop47_var1 = __loop47_var1, prop = prop}
                    ).ToList(); //702:6
                int __loop47_iteration = 0;
                foreach (var __tmp60 in __loop47_results)
                {
                    ++__loop47_iteration;
                    var __loop47_var1 = __tmp60.__loop47_var1;
                    var prop = __tmp60.prop;
                    if (prop.Kind == MetaPropertyKind.Readonly) //703:3
                    {
                        string __tmp61Prefix = "    ///    "; //704:1
                        string __tmp62Suffix = string.Empty; 
                        StringBuilder __tmp63 = new StringBuilder();
                        __tmp63.Append(prop.Class.Name);
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
                                __out.Append(__tmp61Prefix);
                                __out.Append(__tmp63Line);
                            }
                        }
                        string __tmp64Line = "."; //704:29
                        __out.Append(__tmp64Line);
                        StringBuilder __tmp65 = new StringBuilder();
                        __tmp65.Append(prop.Name);
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
                                __out.Append(__tmp62Suffix);
                                __out.AppendLine(); //704:41
                            }
                        }
                    }
                }
                __out.Append("    /// </summary>"); //707:1
                __out.AppendLine(); //707:19
                string __tmp66Prefix = "    public virtual void "; //708:1
                string __tmp67Suffix = " @this)"; //708:81
                StringBuilder __tmp68 = new StringBuilder();
                __tmp68.Append(cls.CSharpName());
                using(StreamReader __tmp68Reader = new StreamReader(this.__ToStream(__tmp68.ToString())))
                {
                    bool __tmp68_first = true;
                    while(__tmp68_first || !__tmp68Reader.EndOfStream)
                    {
                        __tmp68_first = false;
                        string __tmp68Line = __tmp68Reader.ReadLine();
                        if (__tmp68Line == null)
                        {
                            __tmp68Line = "";
                        }
                        __out.Append(__tmp66Prefix);
                        __out.Append(__tmp68Line);
                    }
                }
                string __tmp69Line = "_"; //708:43
                __out.Append(__tmp69Line);
                StringBuilder __tmp70 = new StringBuilder();
                __tmp70.Append(cls.CSharpName());
                using(StreamReader __tmp70Reader = new StreamReader(this.__ToStream(__tmp70.ToString())))
                {
                    bool __tmp70_first = true;
                    while(__tmp70_first || !__tmp70Reader.EndOfStream)
                    {
                        __tmp70_first = false;
                        string __tmp70Line = __tmp70Reader.ReadLine();
                        if (__tmp70Line == null)
                        {
                            __tmp70Line = "";
                        }
                        __out.Append(__tmp70Line);
                    }
                }
                string __tmp71Line = "("; //708:62
                __out.Append(__tmp71Line);
                StringBuilder __tmp72 = new StringBuilder();
                __tmp72.Append(cls.CSharpName());
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
                        __out.Append(__tmp72Line);
                        __out.Append(__tmp67Suffix);
                        __out.AppendLine(); //708:88
                    }
                }
                __out.Append("    {"); //709:1
                __out.AppendLine(); //709:6
                var __loop48_results = 
                    (from __loop48_var1 in __Enumerate((cls).GetEnumerator()) //710:9
                    from sup in __Enumerate((__loop48_var1.SuperClasses).GetEnumerator()) //710:14
                    select new { __loop48_var1 = __loop48_var1, sup = sup}
                    ).ToList(); //710:4
                int __loop48_iteration = 0;
                foreach (var __tmp73 in __loop48_results)
                {
                    ++__loop48_iteration;
                    var __loop48_var1 = __tmp73.__loop48_var1;
                    var sup = __tmp73.sup;
                    string __tmp74Prefix = "        this."; //711:1
                    string __tmp75Suffix = "(@this);"; //711:51
                    StringBuilder __tmp76 = new StringBuilder();
                    __tmp76.Append(sup.CSharpName());
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
                        }
                    }
                    string __tmp77Line = "_"; //711:32
                    __out.Append(__tmp77Line);
                    StringBuilder __tmp78 = new StringBuilder();
                    __tmp78.Append(sup.CSharpName());
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
                            __out.Append(__tmp75Suffix);
                            __out.AppendLine(); //711:59
                        }
                    }
                }
                __out.Append("    }"); //713:1
                __out.AppendLine(); //713:6
                var __loop49_results = 
                    (from __loop49_var1 in __Enumerate((cls).GetEnumerator()) //714:11
                    from prop in __Enumerate((__loop49_var1.Properties).GetEnumerator()) //714:16
                    select new { __loop49_var1 = __loop49_var1, prop = prop}
                    ).ToList(); //714:6
                int __loop49_iteration = 0;
                foreach (var __tmp79 in __loop49_results)
                {
                    ++__loop49_iteration;
                    var __loop49_var1 = __tmp79.__loop49_var1;
                    var prop = __tmp79.prop;
                    MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //715:4
                    if (synInit == null) //716:4
                    {
                        if (prop.Kind == MetaPropertyKind.Derived) //717:5
                        {
                            __out.AppendLine(); //718:2
                            __out.Append("    /// <summary>"); //719:1
                            __out.AppendLine(); //719:18
                            string __tmp80Prefix = "    /// Returns the value of the derived property: "; //720:1
                            string __tmp81Suffix = string.Empty; 
                            StringBuilder __tmp82 = new StringBuilder();
                            __tmp82.Append(cls.CSharpName());
                            using(StreamReader __tmp82Reader = new StreamReader(this.__ToStream(__tmp82.ToString())))
                            {
                                bool __tmp82_first = true;
                                while(__tmp82_first || !__tmp82Reader.EndOfStream)
                                {
                                    __tmp82_first = false;
                                    string __tmp82Line = __tmp82Reader.ReadLine();
                                    if (__tmp82Line == null)
                                    {
                                        __tmp82Line = "";
                                    }
                                    __out.Append(__tmp80Prefix);
                                    __out.Append(__tmp82Line);
                                }
                            }
                            string __tmp83Line = "."; //720:70
                            __out.Append(__tmp83Line);
                            StringBuilder __tmp84 = new StringBuilder();
                            __tmp84.Append(prop.Name);
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
                                    __out.Append(__tmp84Line);
                                    __out.Append(__tmp81Suffix);
                                    __out.AppendLine(); //720:82
                                }
                            }
                            __out.Append("    /// </summary>"); //721:1
                            __out.AppendLine(); //721:19
                            string __tmp85Prefix = "    public virtual "; //722:1
                            string __tmp86Suffix = " @this)"; //722:100
                            StringBuilder __tmp87 = new StringBuilder();
                            __tmp87.Append(prop.Type.CSharpPublicName());
                            using(StreamReader __tmp87Reader = new StreamReader(this.__ToStream(__tmp87.ToString())))
                            {
                                bool __tmp87_first = true;
                                while(__tmp87_first || !__tmp87Reader.EndOfStream)
                                {
                                    __tmp87_first = false;
                                    string __tmp87Line = __tmp87Reader.ReadLine();
                                    if (__tmp87Line == null)
                                    {
                                        __tmp87Line = "";
                                    }
                                    __out.Append(__tmp85Prefix);
                                    __out.Append(__tmp87Line);
                                }
                            }
                            string __tmp88Line = " "; //722:50
                            __out.Append(__tmp88Line);
                            StringBuilder __tmp89 = new StringBuilder();
                            __tmp89.Append(cls.CSharpName());
                            using(StreamReader __tmp89Reader = new StreamReader(this.__ToStream(__tmp89.ToString())))
                            {
                                bool __tmp89_first = true;
                                while(__tmp89_first || !__tmp89Reader.EndOfStream)
                                {
                                    __tmp89_first = false;
                                    string __tmp89Line = __tmp89Reader.ReadLine();
                                    if (__tmp89Line == null)
                                    {
                                        __tmp89Line = "";
                                    }
                                    __out.Append(__tmp89Line);
                                }
                            }
                            string __tmp90Line = "_"; //722:69
                            __out.Append(__tmp90Line);
                            StringBuilder __tmp91 = new StringBuilder();
                            __tmp91.Append(prop.Name);
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
                                    __out.Append(__tmp91Line);
                                }
                            }
                            string __tmp92Line = "("; //722:81
                            __out.Append(__tmp92Line);
                            StringBuilder __tmp93 = new StringBuilder();
                            __tmp93.Append(cls.CSharpName());
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
                                    __out.Append(__tmp86Suffix);
                                    __out.AppendLine(); //722:107
                                }
                            }
                            __out.Append("    {"); //723:1
                            __out.AppendLine(); //723:6
                            __out.Append("        throw new NotImplementedException();"); //724:1
                            __out.AppendLine(); //724:45
                            __out.Append("    }"); //725:1
                            __out.AppendLine(); //725:6
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //726:5
                        {
                            __out.AppendLine(); //727:2
                            __out.Append("    /// <summary>"); //728:1
                            __out.AppendLine(); //728:18
                            string __tmp94Prefix = "    /// Returns the value of the lazy property: "; //729:1
                            string __tmp95Suffix = string.Empty; 
                            StringBuilder __tmp96 = new StringBuilder();
                            __tmp96.Append(cls.CSharpName());
                            using(StreamReader __tmp96Reader = new StreamReader(this.__ToStream(__tmp96.ToString())))
                            {
                                bool __tmp96_first = true;
                                while(__tmp96_first || !__tmp96Reader.EndOfStream)
                                {
                                    __tmp96_first = false;
                                    string __tmp96Line = __tmp96Reader.ReadLine();
                                    if (__tmp96Line == null)
                                    {
                                        __tmp96Line = "";
                                    }
                                    __out.Append(__tmp94Prefix);
                                    __out.Append(__tmp96Line);
                                }
                            }
                            string __tmp97Line = "."; //729:67
                            __out.Append(__tmp97Line);
                            StringBuilder __tmp98 = new StringBuilder();
                            __tmp98.Append(prop.Name);
                            using(StreamReader __tmp98Reader = new StreamReader(this.__ToStream(__tmp98.ToString())))
                            {
                                bool __tmp98_first = true;
                                while(__tmp98_first || !__tmp98Reader.EndOfStream)
                                {
                                    __tmp98_first = false;
                                    string __tmp98Line = __tmp98Reader.ReadLine();
                                    if (__tmp98Line == null)
                                    {
                                        __tmp98Line = "";
                                    }
                                    __out.Append(__tmp98Line);
                                    __out.Append(__tmp95Suffix);
                                    __out.AppendLine(); //729:79
                                }
                            }
                            __out.Append("    /// </summary>"); //730:1
                            __out.AppendLine(); //730:19
                            string __tmp99Prefix = "    public virtual "; //731:1
                            string __tmp100Suffix = " @this)"; //731:100
                            StringBuilder __tmp101 = new StringBuilder();
                            __tmp101.Append(prop.Type.CSharpPublicName());
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
                                    __out.Append(__tmp99Prefix);
                                    __out.Append(__tmp101Line);
                                }
                            }
                            string __tmp102Line = " "; //731:50
                            __out.Append(__tmp102Line);
                            StringBuilder __tmp103 = new StringBuilder();
                            __tmp103.Append(cls.CSharpName());
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
                            string __tmp104Line = "_"; //731:69
                            __out.Append(__tmp104Line);
                            StringBuilder __tmp105 = new StringBuilder();
                            __tmp105.Append(prop.Name);
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
                            string __tmp106Line = "("; //731:81
                            __out.Append(__tmp106Line);
                            StringBuilder __tmp107 = new StringBuilder();
                            __tmp107.Append(cls.CSharpName());
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
                                    __out.Append(__tmp100Suffix);
                                    __out.AppendLine(); //731:107
                                }
                            }
                            __out.Append("    {"); //732:1
                            __out.AppendLine(); //732:6
                            __out.Append("        throw new NotImplementedException();"); //733:1
                            __out.AppendLine(); //733:45
                            __out.Append("    }"); //734:1
                            __out.AppendLine(); //734:6
                        }
                    }
                }
                var __loop50_results = 
                    (from __loop50_var1 in __Enumerate((cls).GetEnumerator()) //738:11
                    from op in __Enumerate((__loop50_var1.Operations).GetEnumerator()) //738:16
                    select new { __loop50_var1 = __loop50_var1, op = op}
                    ).ToList(); //738:6
                int __loop50_iteration = 0;
                foreach (var __tmp108 in __loop50_results)
                {
                    ++__loop50_iteration;
                    var __loop50_var1 = __tmp108.__loop50_var1;
                    var op = __tmp108.op;
                    __out.AppendLine(); //739:2
                    __out.Append("    /// <summary>"); //740:1
                    __out.AppendLine(); //740:18
                    string __tmp109Prefix = "    /// Implements the operation: "; //741:1
                    string __tmp110Suffix = "()"; //741:63
                    StringBuilder __tmp111 = new StringBuilder();
                    __tmp111.Append(cls.CSharpName());
                    using(StreamReader __tmp111Reader = new StreamReader(this.__ToStream(__tmp111.ToString())))
                    {
                        bool __tmp111_first = true;
                        while(__tmp111_first || !__tmp111Reader.EndOfStream)
                        {
                            __tmp111_first = false;
                            string __tmp111Line = __tmp111Reader.ReadLine();
                            if (__tmp111Line == null)
                            {
                                __tmp111Line = "";
                            }
                            __out.Append(__tmp109Prefix);
                            __out.Append(__tmp111Line);
                        }
                    }
                    string __tmp112Line = "."; //741:53
                    __out.Append(__tmp112Line);
                    StringBuilder __tmp113 = new StringBuilder();
                    __tmp113.Append(op.Name);
                    using(StreamReader __tmp113Reader = new StreamReader(this.__ToStream(__tmp113.ToString())))
                    {
                        bool __tmp113_first = true;
                        while(__tmp113_first || !__tmp113Reader.EndOfStream)
                        {
                            __tmp113_first = false;
                            string __tmp113Line = __tmp113Reader.ReadLine();
                            if (__tmp113Line == null)
                            {
                                __tmp113Line = "";
                            }
                            __out.Append(__tmp113Line);
                            __out.Append(__tmp110Suffix);
                            __out.AppendLine(); //741:65
                        }
                    }
                    __out.Append("    /// </summary>"); //742:1
                    __out.AppendLine(); //742:19
                    string __tmp114Prefix = "    public virtual "; //743:1
                    string __tmp115Suffix = ")"; //743:112
                    StringBuilder __tmp116 = new StringBuilder();
                    __tmp116.Append(op.ReturnType.CSharpPublicName());
                    using(StreamReader __tmp116Reader = new StreamReader(this.__ToStream(__tmp116.ToString())))
                    {
                        bool __tmp116_first = true;
                        while(__tmp116_first || !__tmp116Reader.EndOfStream)
                        {
                            __tmp116_first = false;
                            string __tmp116Line = __tmp116Reader.ReadLine();
                            if (__tmp116Line == null)
                            {
                                __tmp116Line = "";
                            }
                            __out.Append(__tmp114Prefix);
                            __out.Append(__tmp116Line);
                        }
                    }
                    string __tmp117Line = " "; //743:54
                    __out.Append(__tmp117Line);
                    StringBuilder __tmp118 = new StringBuilder();
                    __tmp118.Append(cls.CSharpName());
                    using(StreamReader __tmp118Reader = new StreamReader(this.__ToStream(__tmp118.ToString())))
                    {
                        bool __tmp118_first = true;
                        while(__tmp118_first || !__tmp118Reader.EndOfStream)
                        {
                            __tmp118_first = false;
                            string __tmp118Line = __tmp118Reader.ReadLine();
                            if (__tmp118Line == null)
                            {
                                __tmp118Line = "";
                            }
                            __out.Append(__tmp118Line);
                        }
                    }
                    string __tmp119Line = "_"; //743:73
                    __out.Append(__tmp119Line);
                    StringBuilder __tmp120 = new StringBuilder();
                    __tmp120.Append(op.Name);
                    using(StreamReader __tmp120Reader = new StreamReader(this.__ToStream(__tmp120.ToString())))
                    {
                        bool __tmp120_first = true;
                        while(__tmp120_first || !__tmp120Reader.EndOfStream)
                        {
                            __tmp120_first = false;
                            string __tmp120Line = __tmp120Reader.ReadLine();
                            if (__tmp120Line == null)
                            {
                                __tmp120Line = "";
                            }
                            __out.Append(__tmp120Line);
                        }
                    }
                    string __tmp121Line = "("; //743:83
                    __out.Append(__tmp121Line);
                    StringBuilder __tmp122 = new StringBuilder();
                    __tmp122.Append(GetImplParameters(cls, op));
                    using(StreamReader __tmp122Reader = new StreamReader(this.__ToStream(__tmp122.ToString())))
                    {
                        bool __tmp122_first = true;
                        while(__tmp122_first || !__tmp122Reader.EndOfStream)
                        {
                            __tmp122_first = false;
                            string __tmp122Line = __tmp122Reader.ReadLine();
                            if (__tmp122Line == null)
                            {
                                __tmp122Line = "";
                            }
                            __out.Append(__tmp122Line);
                            __out.Append(__tmp115Suffix);
                            __out.AppendLine(); //743:113
                        }
                    }
                    __out.Append("    {"); //744:1
                    __out.AppendLine(); //744:6
                    __out.Append("        throw new NotImplementedException();"); //745:1
                    __out.AppendLine(); //745:45
                    __out.Append("    }"); //746:1
                    __out.AppendLine(); //746:6
                }
                __out.AppendLine(); //748:2
            }
            var __loop51_results = 
                (from __loop51_var1 in __Enumerate((model).GetEnumerator()) //750:8
                from Types in __Enumerate((__loop51_var1.Types).GetEnumerator()) //750:15
                from enm in __Enumerate((Types).GetEnumerator()).OfType<MetaEnum>() //750:22
                select new { __loop51_var1 = __loop51_var1, Types = Types, enm = enm}
                ).ToList(); //750:3
            int __loop51_iteration = 0;
            foreach (var __tmp123 in __loop51_results)
            {
                ++__loop51_iteration;
                var __loop51_var1 = __tmp123.__loop51_var1;
                var Types = __tmp123.Types;
                var enm = __tmp123.enm;
                var __loop52_results = 
                    (from __loop52_var1 in __Enumerate((enm).GetEnumerator()) //751:11
                    from op in __Enumerate((__loop52_var1.Operations).GetEnumerator()) //751:16
                    select new { __loop52_var1 = __loop52_var1, op = op}
                    ).ToList(); //751:6
                int __loop52_iteration = 0;
                foreach (var __tmp124 in __loop52_results)
                {
                    ++__loop52_iteration;
                    var __loop52_var1 = __tmp124.__loop52_var1;
                    var op = __tmp124.op;
                    __out.AppendLine(); //752:2
                    __out.Append("    /// <summary>"); //753:1
                    __out.AppendLine(); //753:18
                    string __tmp125Prefix = "    /// Implements the operation: "; //754:1
                    string __tmp126Suffix = string.Empty; 
                    StringBuilder __tmp127 = new StringBuilder();
                    __tmp127.Append(enm.CSharpName());
                    using(StreamReader __tmp127Reader = new StreamReader(this.__ToStream(__tmp127.ToString())))
                    {
                        bool __tmp127_first = true;
                        while(__tmp127_first || !__tmp127Reader.EndOfStream)
                        {
                            __tmp127_first = false;
                            string __tmp127Line = __tmp127Reader.ReadLine();
                            if (__tmp127Line == null)
                            {
                                __tmp127Line = "";
                            }
                            __out.Append(__tmp125Prefix);
                            __out.Append(__tmp127Line);
                        }
                    }
                    string __tmp128Line = "."; //754:53
                    __out.Append(__tmp128Line);
                    StringBuilder __tmp129 = new StringBuilder();
                    __tmp129.Append(op.Name);
                    using(StreamReader __tmp129Reader = new StreamReader(this.__ToStream(__tmp129.ToString())))
                    {
                        bool __tmp129_first = true;
                        while(__tmp129_first || !__tmp129Reader.EndOfStream)
                        {
                            __tmp129_first = false;
                            string __tmp129Line = __tmp129Reader.ReadLine();
                            if (__tmp129Line == null)
                            {
                                __tmp129Line = "";
                            }
                            __out.Append(__tmp129Line);
                            __out.Append(__tmp126Suffix);
                            __out.AppendLine(); //754:63
                        }
                    }
                    __out.Append("    /// </summary>"); //755:1
                    __out.AppendLine(); //755:19
                    string __tmp130Prefix = "    public virtual "; //756:1
                    string __tmp131Suffix = ")"; //756:112
                    StringBuilder __tmp132 = new StringBuilder();
                    __tmp132.Append(op.ReturnType.CSharpPublicName());
                    using(StreamReader __tmp132Reader = new StreamReader(this.__ToStream(__tmp132.ToString())))
                    {
                        bool __tmp132_first = true;
                        while(__tmp132_first || !__tmp132Reader.EndOfStream)
                        {
                            __tmp132_first = false;
                            string __tmp132Line = __tmp132Reader.ReadLine();
                            if (__tmp132Line == null)
                            {
                                __tmp132Line = "";
                            }
                            __out.Append(__tmp130Prefix);
                            __out.Append(__tmp132Line);
                        }
                    }
                    string __tmp133Line = " "; //756:54
                    __out.Append(__tmp133Line);
                    StringBuilder __tmp134 = new StringBuilder();
                    __tmp134.Append(enm.CSharpName());
                    using(StreamReader __tmp134Reader = new StreamReader(this.__ToStream(__tmp134.ToString())))
                    {
                        bool __tmp134_first = true;
                        while(__tmp134_first || !__tmp134Reader.EndOfStream)
                        {
                            __tmp134_first = false;
                            string __tmp134Line = __tmp134Reader.ReadLine();
                            if (__tmp134Line == null)
                            {
                                __tmp134Line = "";
                            }
                            __out.Append(__tmp134Line);
                        }
                    }
                    string __tmp135Line = "_"; //756:73
                    __out.Append(__tmp135Line);
                    StringBuilder __tmp136 = new StringBuilder();
                    __tmp136.Append(op.Name);
                    using(StreamReader __tmp136Reader = new StreamReader(this.__ToStream(__tmp136.ToString())))
                    {
                        bool __tmp136_first = true;
                        while(__tmp136_first || !__tmp136Reader.EndOfStream)
                        {
                            __tmp136_first = false;
                            string __tmp136Line = __tmp136Reader.ReadLine();
                            if (__tmp136Line == null)
                            {
                                __tmp136Line = "";
                            }
                            __out.Append(__tmp136Line);
                        }
                    }
                    string __tmp137Line = "("; //756:83
                    __out.Append(__tmp137Line);
                    StringBuilder __tmp138 = new StringBuilder();
                    __tmp138.Append(GetImplParameters(enm, op));
                    using(StreamReader __tmp138Reader = new StreamReader(this.__ToStream(__tmp138.ToString())))
                    {
                        bool __tmp138_first = true;
                        while(__tmp138_first || !__tmp138Reader.EndOfStream)
                        {
                            __tmp138_first = false;
                            string __tmp138Line = __tmp138Reader.ReadLine();
                            if (__tmp138Line == null)
                            {
                                __tmp138Line = "";
                            }
                            __out.Append(__tmp138Line);
                            __out.Append(__tmp131Suffix);
                            __out.AppendLine(); //756:113
                        }
                    }
                    __out.Append("    {"); //757:1
                    __out.AppendLine(); //757:6
                    __out.Append("        throw new NotImplementedException();"); //758:1
                    __out.AppendLine(); //758:45
                    __out.Append("    }"); //759:1
                    __out.AppendLine(); //759:6
                }
                __out.AppendLine(); //761:2
            }
            __out.Append("}"); //763:1
            __out.AppendLine(); //763:2
            __out.AppendLine(); //764:2
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //767:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //768:1
            __out.AppendLine(); //768:14
            __out.Append("/// Factory class for creating instances of model elements."); //769:1
            __out.AppendLine(); //769:60
            __out.Append("/// </summary>"); //770:1
            __out.AppendLine(); //770:15
            string __tmp1Prefix = "public class "; //771:1
            string __tmp2Suffix = "Factory : ModelFactory"; //771:26
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.Name);
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
                    __out.AppendLine(); //771:48
                }
            }
            __out.Append("{"); //772:1
            __out.AppendLine(); //772:2
            string __tmp4Prefix = "    private static "; //773:1
            string __tmp5Suffix = "Factory();"; //773:67
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
                }
            }
            string __tmp7Line = "Factory instance = new "; //773:32
            __out.Append(__tmp7Line);
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(model.Name);
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
                    __out.AppendLine(); //773:77
                }
            }
            __out.AppendLine(); //774:2
            string __tmp9Prefix = "	private "; //775:1
            string __tmp10Suffix = "Factory()"; //775:22
            StringBuilder __tmp11 = new StringBuilder();
            __tmp11.Append(model.Name);
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
                    __out.AppendLine(); //775:31
                }
            }
            __out.Append("	{"); //776:1
            __out.AppendLine(); //776:3
            __out.Append("	}"); //777:1
            __out.AppendLine(); //777:3
            __out.AppendLine(); //778:2
            __out.Append("    /// <summary>"); //779:1
            __out.AppendLine(); //779:18
            __out.Append("    /// The singleton instance of the factory."); //780:1
            __out.AppendLine(); //780:47
            __out.Append("    /// </summary>"); //781:1
            __out.AppendLine(); //781:19
            string __tmp12Prefix = "    public static "; //782:1
            string __tmp13Suffix = "Factory Instance"; //782:31
            StringBuilder __tmp14 = new StringBuilder();
            __tmp14.Append(model.Name);
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
                    __out.AppendLine(); //782:47
                }
            }
            __out.Append("    {"); //783:1
            __out.AppendLine(); //783:6
            string __tmp15Prefix = "        get { return "; //784:1
            string __tmp16Suffix = "Factory.instance; }"; //784:34
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
                    __out.Append(__tmp15Prefix);
                    __out.Append(__tmp17Line);
                    __out.Append(__tmp16Suffix);
                    __out.AppendLine(); //784:53
                }
            }
            __out.Append("    }"); //785:1
            __out.AppendLine(); //785:6
            var __loop53_results = 
                (from __loop53_var1 in __Enumerate((model).GetEnumerator()) //786:8
                from Types in __Enumerate((__loop53_var1.Types).GetEnumerator()) //786:15
                from cls in __Enumerate((Types).GetEnumerator()).OfType<MetaClass>() //786:22
                select new { __loop53_var1 = __loop53_var1, Types = Types, cls = cls}
                ).ToList(); //786:3
            int __loop53_iteration = 0;
            foreach (var __tmp18 in __loop53_results)
            {
                ++__loop53_iteration;
                var __loop53_var1 = __tmp18.__loop53_var1;
                var Types = __tmp18.Types;
                var cls = __tmp18.cls;
                if (!cls.IsAbstract) //787:4
                {
                    __out.AppendLine(); //788:2
                    __out.Append("    /// <summary>"); //789:1
                    __out.AppendLine(); //789:18
                    string __tmp19Prefix = "    /// Creates a new instance of "; //790:1
                    string __tmp20Suffix = "."; //790:53
                    StringBuilder __tmp21 = new StringBuilder();
                    __tmp21.Append(cls.CSharpName());
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
                            __out.Append(__tmp19Prefix);
                            __out.Append(__tmp21Line);
                            __out.Append(__tmp20Suffix);
                            __out.AppendLine(); //790:54
                        }
                    }
                    __out.Append("    /// </summary>"); //791:1
                    __out.AppendLine(); //791:19
                    string __tmp22Prefix = "    public "; //792:1
                    string __tmp23Suffix = "(bool addToModelContext = true)"; //792:55
                    StringBuilder __tmp24 = new StringBuilder();
                    __tmp24.Append(cls.CSharpName());
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
                        }
                    }
                    string __tmp25Line = " Create"; //792:30
                    __out.Append(__tmp25Line);
                    StringBuilder __tmp26 = new StringBuilder();
                    __tmp26.Append(cls.CSharpName());
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
                            __out.Append(__tmp23Suffix);
                            __out.AppendLine(); //792:86
                        }
                    }
                    __out.Append("	{"); //793:1
                    __out.AppendLine(); //793:3
                    string __tmp27Prefix = "		"; //794:1
                    string __tmp28Suffix = "Impl(addToModelContext);"; //794:57
                    StringBuilder __tmp29 = new StringBuilder();
                    __tmp29.Append(cls.CSharpName());
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
                    string __tmp30Line = " result = new "; //794:21
                    __out.Append(__tmp30Line);
                    StringBuilder __tmp31 = new StringBuilder();
                    __tmp31.Append(cls.CSharpFullName());
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
                            __out.Append(__tmp28Suffix);
                            __out.AppendLine(); //794:81
                        }
                    }
                    __out.Append("		return result;"); //795:1
                    __out.AppendLine(); //795:17
                    __out.Append("	}"); //796:1
                    __out.AppendLine(); //796:3
                }
            }
            __out.Append("}"); //799:1
            __out.AppendLine(); //799:2
            __out.AppendLine(); //800:2
            return __out.ToString();
        }

    }
}

