using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core //1:1
{
    using __Hidden_MetaModelGenerator_1901854525;
    namespace __Hidden_MetaModelGenerator_1901854525
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
                string __tmp8Prefix = "    get { return "; //200:1
                string __tmp9Suffix = "(this); }"; //200:113
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
                string __tmp11Line = "ImplementationProvider.Implementation."; //200:38
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
                string __tmp13Line = "_"; //200:101
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
                        __out.AppendLine(); //200:122
                    }
                }
            }
            else //201:3
            {
                __out.Append("    get "); //202:1
                __out.AppendLine(); //202:9
                __out.Append("    {"); //203:1
                __out.AppendLine(); //203:6
                string __tmp15Prefix = "        object result = this.MGet("; //204:1
                string __tmp16Suffix = "Property); "; //204:97
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(model.CSharpFullName());
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
                string __tmp18Line = "."; //204:59
                __out.Append(__tmp18Line);
                StringBuilder __tmp19 = new StringBuilder();
                __tmp19.Append(prop.Class.CSharpName());
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
                    }
                }
                string __tmp20Line = "."; //204:85
                __out.Append(__tmp20Line);
                StringBuilder __tmp21 = new StringBuilder();
                __tmp21.Append(prop.Name);
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
                        __out.Append(__tmp16Suffix);
                        __out.AppendLine(); //204:108
                    }
                }
                string __tmp22Prefix = "        if (result != null) return ("; //205:1
                string __tmp23Suffix = ")result;"; //205:67
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(prop.Type.CSharpPublicName());
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
                        __out.AppendLine(); //205:75
                    }
                }
                string __tmp25Prefix = "        else return default("; //206:1
                string __tmp26Suffix = ");"; //206:59
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
                        __out.AppendLine(); //206:61
                    }
                }
                __out.Append("    }"); //207:1
                __out.AppendLine(); //207:6
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //209:3
            {
                string __tmp28Prefix = "    set { this.MSet("; //210:1
                string __tmp29Suffix = "Property, value); }"; //210:83
                StringBuilder __tmp30 = new StringBuilder();
                __tmp30.Append(model.CSharpFullName());
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
                    }
                }
                string __tmp31Line = "."; //210:45
                __out.Append(__tmp31Line);
                StringBuilder __tmp32 = new StringBuilder();
                __tmp32.Append(prop.Class.CSharpName());
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
                string __tmp33Line = "."; //210:71
                __out.Append(__tmp33Line);
                StringBuilder __tmp34 = new StringBuilder();
                __tmp34.Append(prop.Name);
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
                        __out.Append(__tmp29Suffix);
                        __out.AppendLine(); //210:102
                    }
                }
            }
            __out.Append("}"); //212:1
            __out.AppendLine(); //212:2
            return __out.ToString();
        }

        public string GetCollectionConstructorParams(MetaProperty prop) //215:1
        {
            MetaCollectionType mct = prop.Type as MetaCollectionType; //216:2
            if (mct != null && mct.InnerType is MetaClass) //217:2
            {
                return "this, " + prop.Class.Model.CSharpFullName() + "." + prop.Class.CSharpName() + "." + prop.Name + "Property"; //218:3
            }
            else //219:2
            {
                return ""; //220:3
            }
        }

        public string GenerateExpression(MetaExpression expr) //224:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public MetaSynthetizedPropertyInitializer GetSynthetizedInitializerFor(MetaClass cls, MetaProperty prop) //227:1
        {
            var __loop20_results = 
                (from __loop20_var1 in __Enumerate((cls).GetEnumerator()) //228:7
                from Constructor in __Enumerate((__loop20_var1.Constructor).GetEnumerator()) //228:12
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //228:25
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaSynthetizedPropertyInitializer>() //228:39
                select new { __loop20_var1 = __loop20_var1, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //228:2
            int __loop20_iteration = 0;
            foreach (var __tmp1 in __loop20_results)
            {
                ++__loop20_iteration;
                var __loop20_var1 = __tmp1.__loop20_var1;
                var Constructor = __tmp1.Constructor;
                var Initializers = __tmp1.Initializers;
                var init = __tmp1.init;
                if (init.Property == prop) //229:3
                {
                    return init; //230:4
                }
            }
            return null; //233:2
        }

        public string GenerateConstructorImpl(MetaModel model, MetaClass cls) //236:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public "; //237:1
            string __tmp2Suffix = "()"; //237:30
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
                    __out.AppendLine(); //237:32
                }
            }
            __out.Append("{"); //238:1
            __out.AppendLine(); //238:2
            var __loop21_results = 
                (from __loop21_var1 in __Enumerate((cls).GetEnumerator()) //239:8
                from prop in __Enumerate((__loop21_var1.GetAllProperties()).GetEnumerator()) //239:13
                select new { __loop21_var1 = __loop21_var1, prop = prop}
                ).ToList(); //239:3
            int __loop21_iteration = 0;
            foreach (var __tmp4 in __loop21_results)
            {
                ++__loop21_iteration;
                var __loop21_var1 = __tmp4.__loop21_var1;
                var prop = __tmp4.prop;
                MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //240:4
                if (synInit != null) //241:4
                {
                    string __tmp5Prefix = "    //this.MLazySet("; //242:1
                    string __tmp6Suffix = "));"; //242:151
                    StringBuilder __tmp7 = new StringBuilder();
                    __tmp7.Append(model.CSharpFullName());
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
                    string __tmp8Line = "."; //242:45
                    __out.Append(__tmp8Line);
                    StringBuilder __tmp9 = new StringBuilder();
                    __tmp9.Append(prop.Class.CSharpName());
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
                    string __tmp10Line = "."; //242:71
                    __out.Append(__tmp10Line);
                    StringBuilder __tmp11 = new StringBuilder();
                    __tmp11.Append(prop.Name);
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
                    string __tmp12Line = "Property, new Lazy<object>(() => "; //242:83
                    __out.Append(__tmp12Line);
                    StringBuilder __tmp13 = new StringBuilder();
                    __tmp13.Append(GenerateExpression(synInit.Value));
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
                            __out.Append(__tmp6Suffix);
                            __out.AppendLine(); //242:154
                        }
                    }
                }
                else //243:4
                {
                    if (prop.Type is MetaCollectionType) //244:5
                    {
                        if (prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) //245:6
                        {
                            string __tmp14Prefix = "    this.MSet("; //246:1
                            string __tmp15Suffix = "));"; //246:154
                            StringBuilder __tmp16 = new StringBuilder();
                            __tmp16.Append(model.CSharpFullName());
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
                            string __tmp17Line = "."; //246:39
                            __out.Append(__tmp17Line);
                            StringBuilder __tmp18 = new StringBuilder();
                            __tmp18.Append(prop.Class.CSharpName());
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
                            string __tmp19Line = "."; //246:65
                            __out.Append(__tmp19Line);
                            StringBuilder __tmp20 = new StringBuilder();
                            __tmp20.Append(prop.Name);
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
                                }
                            }
                            string __tmp21Line = "Property, new "; //246:77
                            __out.Append(__tmp21Line);
                            StringBuilder __tmp22 = new StringBuilder();
                            __tmp22.Append(prop.Type.CSharpName());
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
                            string __tmp23Line = "("; //246:115
                            __out.Append(__tmp23Line);
                            StringBuilder __tmp24 = new StringBuilder();
                            __tmp24.Append(GetCollectionConstructorParams(prop));
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
                                    __out.Append(__tmp15Suffix);
                                    __out.AppendLine(); //246:157
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //247:6
                        {
                            string __tmp25Prefix = "    this.MLazySet("; //248:1
                            string __tmp26Suffix = "(this)));"; //248:209
                            StringBuilder __tmp27 = new StringBuilder();
                            __tmp27.Append(model.CSharpFullName());
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
                            string __tmp28Line = "."; //248:43
                            __out.Append(__tmp28Line);
                            StringBuilder __tmp29 = new StringBuilder();
                            __tmp29.Append(prop.Class.CSharpName());
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
                            string __tmp30Line = "."; //248:69
                            __out.Append(__tmp30Line);
                            StringBuilder __tmp31 = new StringBuilder();
                            __tmp31.Append(prop.Name);
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
                            string __tmp32Line = "Property, new Lazy<object>(() => "; //248:81
                            __out.Append(__tmp32Line);
                            StringBuilder __tmp33 = new StringBuilder();
                            __tmp33.Append(model.CSharpName());
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
                            string __tmp34Line = "ImplementationProvider.Implementation."; //248:134
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
                            string __tmp36Line = "_"; //248:197
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
                                    __out.Append(__tmp26Suffix);
                                    __out.AppendLine(); //248:218
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Readonly) //249:6
                        {
                            string __tmp38Prefix = "    // Init "; //250:1
                            string __tmp39Suffix = string.Empty; 
                            StringBuilder __tmp40 = new StringBuilder();
                            __tmp40.Append(model.CSharpFullName());
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
                            string __tmp41Line = "."; //250:37
                            __out.Append(__tmp41Line);
                            StringBuilder __tmp42 = new StringBuilder();
                            __tmp42.Append(prop.Class.CSharpName());
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
                            string __tmp43Line = "."; //250:63
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
                                }
                            }
                            string __tmp45Line = "Property in "; //250:75
                            __out.Append(__tmp45Line);
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
                                    __out.Append(__tmp46Line);
                                }
                            }
                            string __tmp47Line = "Implementation."; //250:107
                            __out.Append(__tmp47Line);
                            StringBuilder __tmp48 = new StringBuilder();
                            __tmp48.Append(cls.CSharpName());
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
                                    __out.Append(__tmp48Line);
                                }
                            }
                            string __tmp49Line = "_"; //250:140
                            __out.Append(__tmp49Line);
                            StringBuilder __tmp50 = new StringBuilder();
                            __tmp50.Append(cls.CSharpName());
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
                                    __out.Append(__tmp39Suffix);
                                    __out.AppendLine(); //250:159
                                }
                            }
                        }
                    }
                    else //252:5
                    {
                        if (prop.Kind == MetaPropertyKind.Lazy) //253:6
                        {
                            string __tmp51Prefix = "    this.MLazySet("; //254:1
                            string __tmp52Suffix = "(this)));"; //254:209
                            StringBuilder __tmp53 = new StringBuilder();
                            __tmp53.Append(model.CSharpFullName());
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
                                }
                            }
                            string __tmp54Line = "."; //254:43
                            __out.Append(__tmp54Line);
                            StringBuilder __tmp55 = new StringBuilder();
                            __tmp55.Append(prop.Class.CSharpName());
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
                                    __out.Append(__tmp55Line);
                                }
                            }
                            string __tmp56Line = "."; //254:69
                            __out.Append(__tmp56Line);
                            StringBuilder __tmp57 = new StringBuilder();
                            __tmp57.Append(prop.Name);
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
                            string __tmp58Line = "Property, new Lazy<object>(() => "; //254:81
                            __out.Append(__tmp58Line);
                            StringBuilder __tmp59 = new StringBuilder();
                            __tmp59.Append(model.CSharpName());
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
                            string __tmp60Line = "ImplementationProvider.Implementation."; //254:134
                            __out.Append(__tmp60Line);
                            StringBuilder __tmp61 = new StringBuilder();
                            __tmp61.Append(prop.Class.CSharpName());
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
                            string __tmp62Line = "_"; //254:197
                            __out.Append(__tmp62Line);
                            StringBuilder __tmp63 = new StringBuilder();
                            __tmp63.Append(prop.Name);
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
                                    __out.Append(__tmp52Suffix);
                                    __out.AppendLine(); //254:218
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Readonly) //255:6
                        {
                            string __tmp64Prefix = "    // Init "; //256:1
                            string __tmp65Suffix = string.Empty; 
                            StringBuilder __tmp66 = new StringBuilder();
                            __tmp66.Append(model.CSharpFullName());
                            using(StreamReader __tmp66Reader = new StreamReader(this.__ToStream(__tmp66.ToString())))
                            {
                                bool __tmp66_first = true;
                                while(__tmp66_first || !__tmp66Reader.EndOfStream)
                                {
                                    __tmp66_first = false;
                                    string __tmp66Line = __tmp66Reader.ReadLine();
                                    if (__tmp66Line == null)
                                    {
                                        __tmp66Line = "";
                                    }
                                    __out.Append(__tmp64Prefix);
                                    __out.Append(__tmp66Line);
                                }
                            }
                            string __tmp67Line = "."; //256:37
                            __out.Append(__tmp67Line);
                            StringBuilder __tmp68 = new StringBuilder();
                            __tmp68.Append(prop.Class.CSharpName());
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
                                    __out.Append(__tmp68Line);
                                }
                            }
                            string __tmp69Line = "."; //256:63
                            __out.Append(__tmp69Line);
                            StringBuilder __tmp70 = new StringBuilder();
                            __tmp70.Append(prop.Name);
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
                            string __tmp71Line = "Property in "; //256:75
                            __out.Append(__tmp71Line);
                            StringBuilder __tmp72 = new StringBuilder();
                            __tmp72.Append(model.CSharpName());
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
                                }
                            }
                            string __tmp73Line = "Implementation."; //256:107
                            __out.Append(__tmp73Line);
                            StringBuilder __tmp74 = new StringBuilder();
                            __tmp74.Append(cls.CSharpName());
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
                            string __tmp75Line = "_"; //256:140
                            __out.Append(__tmp75Line);
                            StringBuilder __tmp76 = new StringBuilder();
                            __tmp76.Append(cls.CSharpName());
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
                                    __out.Append(__tmp65Suffix);
                                    __out.AppendLine(); //256:159
                                }
                            }
                        }
                    }
                }
            }
            var __loop22_results = 
                (from __loop22_var1 in __Enumerate((cls).GetEnumerator()) //261:8
                from Constructor in __Enumerate((__loop22_var1.Constructor).GetEnumerator()) //261:13
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //261:26
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaInheritedPropertyInitializer>() //261:40
                select new { __loop22_var1 = __loop22_var1, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //261:3
            int __loop22_iteration = 0;
            foreach (var __tmp77 in __loop22_results)
            {
                ++__loop22_iteration;
                var __loop22_var1 = __tmp77.__loop22_var1;
                var Constructor = __tmp77.Constructor;
                var Initializers = __tmp77.Initializers;
                var init = __tmp77.init;
                if (init.Object != null && init.Property != null) //262:4
                {
                    string __tmp78Prefix = "    //this.MLazySetChild("; //263:1
                    string __tmp79Suffix = "));"; //263:295
                    StringBuilder __tmp80 = new StringBuilder();
                    __tmp80.Append(init.Object.Class.Model.CSharpFullName());
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
                            __out.Append(__tmp78Prefix);
                            __out.Append(__tmp80Line);
                        }
                    }
                    string __tmp81Line = "."; //263:68
                    __out.Append(__tmp81Line);
                    StringBuilder __tmp82 = new StringBuilder();
                    __tmp82.Append(init.Object.Class.CSharpName());
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
                    string __tmp83Line = "."; //263:101
                    __out.Append(__tmp83Line);
                    StringBuilder __tmp84 = new StringBuilder();
                    __tmp84.Append(init.Object.Name);
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
                    string __tmp85Line = "Property, "; //263:120
                    __out.Append(__tmp85Line);
                    StringBuilder __tmp86 = new StringBuilder();
                    __tmp86.Append(init.Property.Class.Model.CSharpFullName());
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
                    string __tmp87Line = "."; //263:174
                    __out.Append(__tmp87Line);
                    StringBuilder __tmp88 = new StringBuilder();
                    __tmp88.Append(init.Property.Class.CSharpName());
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
                        }
                    }
                    string __tmp89Line = "."; //263:209
                    __out.Append(__tmp89Line);
                    StringBuilder __tmp90 = new StringBuilder();
                    __tmp90.Append(init.Property.Name);
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
                    string __tmp91Line = "Property, new Lazy<object>(() => "; //263:230
                    __out.Append(__tmp91Line);
                    StringBuilder __tmp92 = new StringBuilder();
                    __tmp92.Append(GenerateExpression(init.Value));
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
                            __out.Append(__tmp79Suffix);
                            __out.AppendLine(); //263:298
                        }
                    }
                }
            }
            string __tmp93Prefix = "    "; //266:1
            string __tmp94Suffix = "(this);"; //266:104
            StringBuilder __tmp95 = new StringBuilder();
            __tmp95.Append(cls.Model.CSharpName());
            using(StreamReader __tmp95Reader = new StreamReader(this.__ToStream(__tmp95.ToString())))
            {
                bool __tmp95_first = true;
                while(__tmp95_first || !__tmp95Reader.EndOfStream)
                {
                    __tmp95_first = false;
                    string __tmp95Line = __tmp95Reader.ReadLine();
                    if (__tmp95Line == null)
                    {
                        __tmp95Line = "";
                    }
                    __out.Append(__tmp93Prefix);
                    __out.Append(__tmp95Line);
                }
            }
            string __tmp96Line = "ImplementationProvider.Implementation."; //266:29
            __out.Append(__tmp96Line);
            StringBuilder __tmp97 = new StringBuilder();
            __tmp97.Append(cls.CSharpName());
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
                    __out.Append(__tmp97Line);
                }
            }
            string __tmp98Line = "_"; //266:85
            __out.Append(__tmp98Line);
            StringBuilder __tmp99 = new StringBuilder();
            __tmp99.Append(cls.CSharpName());
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
                    __out.Append(__tmp94Suffix);
                    __out.AppendLine(); //266:111
                }
            }
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((cls).GetEnumerator()) //267:11
                from prop in __Enumerate((__loop23_var1.GetAllProperties()).GetEnumerator()) //267:16
                select new { __loop23_var1 = __loop23_var1, prop = prop}
                ).ToList(); //267:6
            int __loop23_iteration = 0;
            foreach (var __tmp100 in __loop23_results)
            {
                ++__loop23_iteration;
                var __loop23_var1 = __tmp100.__loop23_var1;
                var prop = __tmp100.prop;
                if (prop.Kind == MetaPropertyKind.Readonly) //268:4
                {
                    string __tmp101Prefix = "    if (!this.MIsSet("; //269:1
                    string __tmp102Suffix = "().\");"; //269:258
                    StringBuilder __tmp103 = new StringBuilder();
                    __tmp103.Append(model.CSharpFullName());
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
                            __out.Append(__tmp101Prefix);
                            __out.Append(__tmp103Line);
                        }
                    }
                    string __tmp104Line = "."; //269:46
                    __out.Append(__tmp104Line);
                    StringBuilder __tmp105 = new StringBuilder();
                    __tmp105.Append(prop.Class.CSharpName());
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
                    string __tmp106Line = "."; //269:72
                    __out.Append(__tmp106Line);
                    StringBuilder __tmp107 = new StringBuilder();
                    __tmp107.Append(prop.Name);
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
                        }
                    }
                    string __tmp108Line = "Property)) throw new ModelException(\"Readonly property "; //269:84
                    __out.Append(__tmp108Line);
                    StringBuilder __tmp109 = new StringBuilder();
                    __tmp109.Append(model.CSharpName());
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
                    string __tmp110Line = "."; //269:159
                    __out.Append(__tmp110Line);
                    StringBuilder __tmp111 = new StringBuilder();
                    __tmp111.Append(prop.Class.CSharpName());
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
                        }
                    }
                    string __tmp112Line = "."; //269:185
                    __out.Append(__tmp112Line);
                    StringBuilder __tmp113 = new StringBuilder();
                    __tmp113.Append(prop.Name);
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
                        }
                    }
                    string __tmp114Line = "Property was not set in "; //269:197
                    __out.Append(__tmp114Line);
                    StringBuilder __tmp115 = new StringBuilder();
                    __tmp115.Append(cls.CSharpName());
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
                            __out.Append(__tmp115Line);
                        }
                    }
                    string __tmp116Line = "_"; //269:239
                    __out.Append(__tmp116Line);
                    StringBuilder __tmp117 = new StringBuilder();
                    __tmp117.Append(cls.CSharpName());
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
                            __out.Append(__tmp102Suffix);
                            __out.AppendLine(); //269:264
                        }
                    }
                }
            }
            __out.Append("    this.MMakeDefault();"); //272:1
            __out.AppendLine(); //272:25
            __out.Append("}"); //273:1
            __out.AppendLine(); //273:2
            return __out.ToString();
        }

        public string GetReturn(MetaOperation op) //276:1
        {
            if (op.ReturnType.CSharpName() == "void") //277:5
            {
                return ""; //278:3
            }
            else //279:2
            {
                return "return "; //280:3
            }
        }

        public string GenerateOperationImpl(MetaModel model, MetaOperation op) //284:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //285:2
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = ")"; //286:97
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
            string __tmp4Line = " "; //286:35
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
            string __tmp6Line = "."; //286:60
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
            string __tmp8Line = "("; //286:70
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
                    __out.AppendLine(); //286:98
                }
            }
            __out.Append("{"); //287:1
            __out.AppendLine(); //287:2
            string __tmp10Prefix = "    "; //288:1
            string __tmp11Suffix = ");"; //288:144
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
            string __tmp14Line = "ImplementationProvider.Implementation."; //288:40
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
            string __tmp16Line = "_"; //288:102
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
            string __tmp18Line = "("; //288:112
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
                    __out.AppendLine(); //288:146
                }
            }
            __out.Append("}"); //289:1
            __out.AppendLine(); //289:2
            return __out.ToString();
        }

        public string GetSuperClasses(MetaClass cls) //292:1
        {
            string result = ""; //293:2
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((cls).GetEnumerator()) //294:10
                from sup in __Enumerate((__loop24_var1.SuperClasses).GetEnumerator()) //294:15
                select new { __loop24_var1 = __loop24_var1, sup = sup}
                ).ToList(); //294:5
            int __loop24_iteration = 0;
            string delim = ""; //294:33
            foreach (var __tmp1 in __loop24_results)
            {
                ++__loop24_iteration;
                if (__loop24_iteration >= 2) //294:52
                {
                    delim = ", "; //294:52
                }
                var __loop24_var1 = __tmp1.__loop24_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpName(); //295:3
            }
            return result; //297:2
        }

        public string GetAllSuperClasses(MetaClass cls) //300:1
        {
            string result = ""; //301:2
            var __loop25_results = 
                (from __loop25_var1 in __Enumerate((cls).GetEnumerator()) //302:10
                from sup in __Enumerate((__loop25_var1.GetAllSuperClasses(false)).GetEnumerator()) //302:15
                select new { __loop25_var1 = __loop25_var1, sup = sup}
                ).ToList(); //302:5
            int __loop25_iteration = 0;
            string delim = ""; //302:46
            foreach (var __tmp1 in __loop25_results)
            {
                ++__loop25_iteration;
                if (__loop25_iteration >= 2) //302:65
                {
                    delim = ", "; //302:65
                }
                var __loop25_var1 = __tmp1.__loop25_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpName(); //303:3
            }
            return result; //305:2
        }

        public string GenerateMetaModel(MetaModel model) //308:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public static class "; //309:1
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
                    __out.AppendLine(); //309:41
                }
            }
            __out.Append("{"); //310:1
            __out.AppendLine(); //310:2
            string __tmp4Prefix = "    static "; //311:1
            string __tmp5Suffix = "()"; //311:32
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
                    __out.AppendLine(); //311:34
                }
            }
            __out.Append("    {"); //312:1
            __out.AppendLine(); //312:6
            var __loop26_results = 
                (from __loop26_var1 in __Enumerate((model).GetEnumerator()) //313:11
                from Types in __Enumerate((__loop26_var1.Types).GetEnumerator()) //313:18
                from cls in __Enumerate((Types).GetEnumerator()).OfType<MetaClass>() //313:25
                select new { __loop26_var1 = __loop26_var1, Types = Types, cls = cls}
                ).ToList(); //313:6
            int __loop26_iteration = 0;
            foreach (var __tmp7 in __loop26_results)
            {
                ++__loop26_iteration;
                var __loop26_var1 = __tmp7.__loop26_var1;
                var Types = __tmp7.Types;
                var cls = __tmp7.cls;
                string __tmp8Prefix = "        "; //314:1
                string __tmp9Suffix = ".StaticInit();"; //314:27
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(cls.CSharpName());
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
                        __out.AppendLine(); //314:41
                    }
                }
            }
            __out.Append("    }"); //316:1
            __out.AppendLine(); //316:6
            __out.AppendLine(); //317:2
            __out.Append("    internal static void StaticInit()"); //318:1
            __out.AppendLine(); //318:38
            __out.Append("    {"); //319:1
            __out.AppendLine(); //319:6
            __out.Append("    }"); //320:1
            __out.AppendLine(); //320:6
            __out.AppendLine(); //321:2
            var __loop27_results = 
                (from __loop27_var1 in __Enumerate((model).GetEnumerator()) //322:11
                from Types in __Enumerate((__loop27_var1.Types).GetEnumerator()) //322:18
                from cls in __Enumerate((Types).GetEnumerator()).OfType<MetaClass>() //322:25
                select new { __loop27_var1 = __loop27_var1, Types = Types, cls = cls}
                ).ToList(); //322:6
            int __loop27_iteration = 0;
            foreach (var __tmp11 in __loop27_results)
            {
                ++__loop27_iteration;
                var __loop27_var1 = __tmp11.__loop27_var1;
                var Types = __tmp11.Types;
                var cls = __tmp11.cls;
                string __tmp12Prefix = "    "; //323:1
                string __tmp13Suffix = string.Empty; 
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(GenerateMetaModelClass(cls));
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
                        __out.AppendLine(); //323:34
                    }
                }
            }
            __out.Append("}"); //325:1
            __out.AppendLine(); //325:2
            __out.AppendLine(); //326:2
            return __out.ToString();
        }

        public string GenerateMetaModelClass(MetaClass cls) //329:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //330:2
            string __tmp1Prefix = "public static class "; //331:1
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
                    __out.AppendLine(); //331:39
                }
            }
            __out.Append("{"); //332:1
            __out.AppendLine(); //332:2
            __out.Append("    internal static void StaticInit()"); //333:1
            __out.AppendLine(); //333:38
            __out.Append("    {"); //334:1
            __out.AppendLine(); //334:6
            __out.Append("    }"); //335:1
            __out.AppendLine(); //335:6
            __out.AppendLine(); //336:2
            string __tmp4Prefix = "    static "; //337:1
            string __tmp5Suffix = "()"; //337:30
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
                    __out.AppendLine(); //337:32
                }
            }
            __out.Append("    {"); //338:1
            __out.AppendLine(); //338:6
            __out.Append("    }"); //339:1
            __out.AppendLine(); //339:6
            __out.AppendLine(); //340:2
            var __loop28_results = 
                (from __loop28_var1 in __Enumerate((cls).GetEnumerator()) //341:11
                from prop in __Enumerate((__loop28_var1.Properties).GetEnumerator()) //341:16
                select new { __loop28_var1 = __loop28_var1, prop = prop}
                ).ToList(); //341:6
            int __loop28_iteration = 0;
            foreach (var __tmp7 in __loop28_results)
            {
                ++__loop28_iteration;
                var __loop28_var1 = __tmp7.__loop28_var1;
                var prop = __tmp7.prop;
                string __tmp8Prefix = "    "; //342:1
                string __tmp9Suffix = string.Empty; 
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(GeneratePropertyDeclaration(cls.Model, cls, prop));
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
                        __out.AppendLine(); //342:56
                    }
                }
            }
            __out.Append("}"); //344:1
            __out.AppendLine(); //344:2
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //347:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "internal static class "; //348:1
            string __tmp2Suffix = "ImplementationProvider"; //348:43
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
                    __out.AppendLine(); //348:65
                }
            }
            __out.Append("{"); //349:1
            __out.AppendLine(); //349:2
            string __tmp4Prefix = "    // If there is a compile error at this line, create a new class called "; //350:1
            string __tmp5Suffix = "Implementation"; //350:96
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
                    __out.AppendLine(); //350:110
                }
            }
            string __tmp7Prefix = "	// which is a subclass of "; //351:1
            string __tmp8Suffix = "ImplementationBase:"; //351:48
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
                    __out.AppendLine(); //351:67
                }
            }
            string __tmp10Prefix = "    private static "; //352:1
            string __tmp11Suffix = "Implementation();"; //352:96
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
            string __tmp13Line = "Implementation implementation = new "; //352:40
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
                    __out.AppendLine(); //352:113
                }
            }
            __out.AppendLine(); //353:2
            string __tmp15Prefix = "    public static "; //354:1
            string __tmp16Suffix = "Implementation Implementation"; //354:39
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
                    __out.AppendLine(); //354:68
                }
            }
            __out.Append("    {"); //355:1
            __out.AppendLine(); //355:6
            string __tmp18Prefix = "        get { return "; //356:1
            string __tmp19Suffix = "ImplementationProvider.implementation; }"; //356:42
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
                    __out.AppendLine(); //356:82
                }
            }
            __out.Append("    }"); //357:1
            __out.AppendLine(); //357:6
            __out.Append("}"); //358:1
            __out.AppendLine(); //358:2
            var __loop29_results = 
                (from __loop29_var1 in __Enumerate((model).GetEnumerator()) //359:8
                from Types in __Enumerate((__loop29_var1.Types).GetEnumerator()) //359:15
                from enm in __Enumerate((Types).GetEnumerator()).OfType<MetaEnum>() //359:22
                select new { __loop29_var1 = __loop29_var1, Types = Types, enm = enm}
                ).ToList(); //359:3
            int __loop29_iteration = 0;
            foreach (var __tmp21 in __loop29_results)
            {
                ++__loop29_iteration;
                var __loop29_var1 = __tmp21.__loop29_var1;
                var Types = __tmp21.Types;
                var enm = __tmp21.enm;
                __out.AppendLine(); //360:2
                string __tmp22Prefix = "public static class "; //361:1
                string __tmp23Suffix = "Extensions"; //361:51
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
                        __out.AppendLine(); //361:61
                    }
                }
                __out.Append("{"); //362:1
                __out.AppendLine(); //362:2
                var __loop30_results = 
                    (from __loop30_var1 in __Enumerate((enm).GetEnumerator()) //363:11
                    from op in __Enumerate((__loop30_var1.Operations).GetEnumerator()) //363:16
                    select new { __loop30_var1 = __loop30_var1, op = op}
                    ).ToList(); //363:6
                int __loop30_iteration = 0;
                foreach (var __tmp26 in __loop30_results)
                {
                    ++__loop30_iteration;
                    var __loop30_var1 = __tmp26.__loop30_var1;
                    var op = __tmp26.op;
                    string __tmp27Prefix = "    public static "; //364:1
                    string __tmp28Suffix = ")"; //364:96
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
                    string __tmp30Line = " "; //364:53
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
                    string __tmp32Line = "("; //364:63
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
                            __out.AppendLine(); //364:97
                        }
                    }
                    __out.Append("    {"); //365:1
                    __out.AppendLine(); //365:6
                    string __tmp34Prefix = "        "; //366:1
                    string __tmp35Suffix = ");"; //366:152
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
                    string __tmp38Line = "ImplementationProvider.Implementation."; //366:44
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
                    string __tmp40Line = "_"; //366:106
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
                    string __tmp42Line = "("; //366:116
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
                            __out.AppendLine(); //366:154
                        }
                    }
                    __out.Append("    }"); //367:1
                    __out.AppendLine(); //367:6
                }
                __out.Append("}"); //369:1
                __out.AppendLine(); //369:2
            }
            __out.AppendLine(); //371:2
            __out.Append("/// <summary>"); //372:1
            __out.AppendLine(); //372:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //373:1
            __out.AppendLine(); //373:68
            string __tmp44Prefix = "/// This class has to be be overriden in "; //374:1
            string __tmp45Suffix = "Implementation to provide custom"; //374:62
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
                    __out.AppendLine(); //374:94
                }
            }
            __out.Append("/// implementation for the constructors, operations and property values."); //375:1
            __out.AppendLine(); //375:73
            __out.Append("/// </summary>"); //376:1
            __out.AppendLine(); //376:15
            string __tmp47Prefix = "internal abstract class "; //377:1
            string __tmp48Suffix = "ImplementationBase"; //377:45
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
                    __out.AppendLine(); //377:63
                }
            }
            __out.Append("{"); //378:1
            __out.AppendLine(); //378:2
            string delim = ""; //379:3
            var __loop31_results = 
                (from __loop31_var1 in __Enumerate((model).GetEnumerator()) //380:8
                from Types in __Enumerate((__loop31_var1.Types).GetEnumerator()) //380:15
                from cls in __Enumerate((Types).GetEnumerator()).OfType<MetaClass>() //380:22
                select new { __loop31_var1 = __loop31_var1, Types = Types, cls = cls}
                ).ToList(); //380:3
            int __loop31_iteration = 0;
            foreach (var __tmp50 in __loop31_results)
            {
                ++__loop31_iteration;
                var __loop31_var1 = __tmp50.__loop31_var1;
                var Types = __tmp50.Types;
                var cls = __tmp50.cls;
                __out.Append("    /// <summary>"); //381:1
                __out.AppendLine(); //381:18
                string __tmp51Prefix = "	/// Implements the constructor: "; //382:1
                string __tmp52Suffix = "()"; //382:52
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
                        __out.AppendLine(); //382:54
                    }
                }
                if ((from __loop32_var1 in __Enumerate((cls).GetEnumerator()) //383:15
                from sup in __Enumerate((__loop32_var1.SuperClasses).GetEnumerator()) //383:20
                select new { __loop32_var1 = __loop32_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //383:3
                {
                    string __tmp54Prefix = "	/// Direct superclasses: "; //384:1
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
                            __out.AppendLine(); //384:49
                        }
                    }
                    string __tmp57Prefix = "	/// All superclasses: "; //385:1
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
                            __out.AppendLine(); //385:49
                        }
                    }
                }
                if ((from __loop33_var1 in __Enumerate((cls).GetEnumerator()) //387:15
                from prop in __Enumerate((__loop33_var1.GetAllProperties()).GetEnumerator()) //387:20
                where prop.Kind == MetaPropertyKind.Readonly //387:44
                select new { __loop33_var1 = __loop33_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //387:3
                {
                    __out.Append("    // Initializes the following readonly properties:"); //388:1
                    __out.AppendLine(); //388:54
                }
                var __loop34_results = 
                    (from __loop34_var1 in __Enumerate((cls).GetEnumerator()) //390:11
                    from prop in __Enumerate((__loop34_var1.GetAllProperties()).GetEnumerator()) //390:16
                    select new { __loop34_var1 = __loop34_var1, prop = prop}
                    ).ToList(); //390:6
                int __loop34_iteration = 0;
                foreach (var __tmp60 in __loop34_results)
                {
                    ++__loop34_iteration;
                    var __loop34_var1 = __tmp60.__loop34_var1;
                    var prop = __tmp60.prop;
                    if (prop.Kind == MetaPropertyKind.Readonly) //391:3
                    {
                        string __tmp61Prefix = "    ///    "; //392:1
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
                        string __tmp64Line = "."; //392:29
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
                                __out.AppendLine(); //392:41
                            }
                        }
                    }
                }
                __out.Append("    /// </summary>"); //395:1
                __out.AppendLine(); //395:19
                string __tmp66Prefix = "    public virtual void "; //396:1
                string __tmp67Suffix = " @this)"; //396:81
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
                string __tmp69Line = "_"; //396:43
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
                string __tmp71Line = "("; //396:62
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
                        __out.AppendLine(); //396:88
                    }
                }
                __out.Append("    {"); //397:1
                __out.AppendLine(); //397:6
                var __loop35_results = 
                    (from __loop35_var1 in __Enumerate((cls).GetEnumerator()) //398:9
                    from sup in __Enumerate((__loop35_var1.SuperClasses).GetEnumerator()) //398:14
                    select new { __loop35_var1 = __loop35_var1, sup = sup}
                    ).ToList(); //398:4
                int __loop35_iteration = 0;
                foreach (var __tmp73 in __loop35_results)
                {
                    ++__loop35_iteration;
                    var __loop35_var1 = __tmp73.__loop35_var1;
                    var sup = __tmp73.sup;
                    string __tmp74Prefix = "        this."; //399:1
                    string __tmp75Suffix = "(@this);"; //399:51
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
                    string __tmp77Line = "_"; //399:32
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
                            __out.AppendLine(); //399:59
                        }
                    }
                }
                __out.Append("    }"); //401:1
                __out.AppendLine(); //401:6
                var __loop36_results = 
                    (from __loop36_var1 in __Enumerate((cls).GetEnumerator()) //402:11
                    from prop in __Enumerate((__loop36_var1.Properties).GetEnumerator()) //402:16
                    select new { __loop36_var1 = __loop36_var1, prop = prop}
                    ).ToList(); //402:6
                int __loop36_iteration = 0;
                foreach (var __tmp79 in __loop36_results)
                {
                    ++__loop36_iteration;
                    var __loop36_var1 = __tmp79.__loop36_var1;
                    var prop = __tmp79.prop;
                    if (prop.Kind == MetaPropertyKind.Derived) //403:3
                    {
                        __out.AppendLine(); //404:2
                        __out.Append("    /// <summary>"); //405:1
                        __out.AppendLine(); //405:18
                        string __tmp80Prefix = "    /// Returns the value of the derived property: "; //406:1
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
                        string __tmp83Line = "."; //406:70
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
                                __out.AppendLine(); //406:82
                            }
                        }
                        __out.Append("    /// </summary>"); //407:1
                        __out.AppendLine(); //407:19
                        string __tmp85Prefix = "    public virtual "; //408:1
                        string __tmp86Suffix = " @this)"; //408:100
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
                        string __tmp88Line = " "; //408:50
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
                        string __tmp90Line = "_"; //408:69
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
                        string __tmp92Line = "("; //408:81
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
                                __out.AppendLine(); //408:107
                            }
                        }
                        __out.Append("    {"); //409:1
                        __out.AppendLine(); //409:6
                        __out.Append("        throw new NotImplementedException();"); //410:1
                        __out.AppendLine(); //410:45
                        __out.Append("    }"); //411:1
                        __out.AppendLine(); //411:6
                    }
                    else if (prop.Kind == MetaPropertyKind.Lazy) //412:3
                    {
                        __out.AppendLine(); //413:2
                        __out.Append("    /// <summary>"); //414:1
                        __out.AppendLine(); //414:18
                        string __tmp94Prefix = "    /// Returns the value of the lazy property: "; //415:1
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
                        string __tmp97Line = "."; //415:67
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
                                __out.AppendLine(); //415:79
                            }
                        }
                        __out.Append("    /// </summary>"); //416:1
                        __out.AppendLine(); //416:19
                        string __tmp99Prefix = "    public virtual "; //417:1
                        string __tmp100Suffix = " @this)"; //417:100
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
                        string __tmp102Line = " "; //417:50
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
                        string __tmp104Line = "_"; //417:69
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
                        string __tmp106Line = "("; //417:81
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
                                __out.AppendLine(); //417:107
                            }
                        }
                        __out.Append("    {"); //418:1
                        __out.AppendLine(); //418:6
                        __out.Append("        throw new NotImplementedException();"); //419:1
                        __out.AppendLine(); //419:45
                        __out.Append("    }"); //420:1
                        __out.AppendLine(); //420:6
                    }
                }
                var __loop37_results = 
                    (from __loop37_var1 in __Enumerate((cls).GetEnumerator()) //423:11
                    from op in __Enumerate((__loop37_var1.Operations).GetEnumerator()) //423:16
                    select new { __loop37_var1 = __loop37_var1, op = op}
                    ).ToList(); //423:6
                int __loop37_iteration = 0;
                foreach (var __tmp108 in __loop37_results)
                {
                    ++__loop37_iteration;
                    var __loop37_var1 = __tmp108.__loop37_var1;
                    var op = __tmp108.op;
                    __out.AppendLine(); //424:2
                    __out.Append("    /// <summary>"); //425:1
                    __out.AppendLine(); //425:18
                    string __tmp109Prefix = "    /// Implements the operation: "; //426:1
                    string __tmp110Suffix = "()"; //426:63
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
                    string __tmp112Line = "."; //426:53
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
                            __out.AppendLine(); //426:65
                        }
                    }
                    __out.Append("    /// </summary>"); //427:1
                    __out.AppendLine(); //427:19
                    string __tmp114Prefix = "    public virtual "; //428:1
                    string __tmp115Suffix = ")"; //428:112
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
                    string __tmp117Line = " "; //428:54
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
                    string __tmp119Line = "_"; //428:73
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
                    string __tmp121Line = "("; //428:83
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
                            __out.AppendLine(); //428:113
                        }
                    }
                    __out.Append("    {"); //429:1
                    __out.AppendLine(); //429:6
                    __out.Append("        throw new NotImplementedException();"); //430:1
                    __out.AppendLine(); //430:45
                    __out.Append("    }"); //431:1
                    __out.AppendLine(); //431:6
                }
                __out.AppendLine(); //433:2
            }
            var __loop38_results = 
                (from __loop38_var1 in __Enumerate((model).GetEnumerator()) //435:8
                from Types in __Enumerate((__loop38_var1.Types).GetEnumerator()) //435:15
                from enm in __Enumerate((Types).GetEnumerator()).OfType<MetaEnum>() //435:22
                select new { __loop38_var1 = __loop38_var1, Types = Types, enm = enm}
                ).ToList(); //435:3
            int __loop38_iteration = 0;
            foreach (var __tmp123 in __loop38_results)
            {
                ++__loop38_iteration;
                var __loop38_var1 = __tmp123.__loop38_var1;
                var Types = __tmp123.Types;
                var enm = __tmp123.enm;
                var __loop39_results = 
                    (from __loop39_var1 in __Enumerate((enm).GetEnumerator()) //436:11
                    from op in __Enumerate((__loop39_var1.Operations).GetEnumerator()) //436:16
                    select new { __loop39_var1 = __loop39_var1, op = op}
                    ).ToList(); //436:6
                int __loop39_iteration = 0;
                foreach (var __tmp124 in __loop39_results)
                {
                    ++__loop39_iteration;
                    var __loop39_var1 = __tmp124.__loop39_var1;
                    var op = __tmp124.op;
                    __out.AppendLine(); //437:2
                    __out.Append("    /// <summary>"); //438:1
                    __out.AppendLine(); //438:18
                    string __tmp125Prefix = "    /// Implements the operation: "; //439:1
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
                    string __tmp128Line = "."; //439:53
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
                            __out.AppendLine(); //439:63
                        }
                    }
                    __out.Append("    /// </summary>"); //440:1
                    __out.AppendLine(); //440:19
                    string __tmp130Prefix = "    public virtual "; //441:1
                    string __tmp131Suffix = ")"; //441:112
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
                    string __tmp133Line = " "; //441:54
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
                    string __tmp135Line = "_"; //441:73
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
                    string __tmp137Line = "("; //441:83
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
                            __out.AppendLine(); //441:113
                        }
                    }
                    __out.Append("    {"); //442:1
                    __out.AppendLine(); //442:6
                    __out.Append("        throw new NotImplementedException();"); //443:1
                    __out.AppendLine(); //443:45
                    __out.Append("    }"); //444:1
                    __out.AppendLine(); //444:6
                }
                __out.AppendLine(); //446:2
            }
            __out.Append("}"); //448:1
            __out.AppendLine(); //448:2
            __out.AppendLine(); //449:2
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //452:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //453:1
            __out.AppendLine(); //453:14
            __out.Append("/// Factory class for creating instances of model elements."); //454:1
            __out.AppendLine(); //454:60
            __out.Append("/// </summary>"); //455:1
            __out.AppendLine(); //455:15
            string __tmp1Prefix = "public class "; //456:1
            string __tmp2Suffix = "Factory : ModelFactory"; //456:26
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
                    __out.AppendLine(); //456:48
                }
            }
            __out.Append("{"); //457:1
            __out.AppendLine(); //457:2
            string __tmp4Prefix = "    private static "; //458:1
            string __tmp5Suffix = "Factory();"; //458:67
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
            string __tmp7Line = "Factory instance = new "; //458:32
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
                    __out.AppendLine(); //458:77
                }
            }
            __out.AppendLine(); //459:2
            string __tmp9Prefix = "	private "; //460:1
            string __tmp10Suffix = "Factory()"; //460:22
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
                    __out.AppendLine(); //460:31
                }
            }
            __out.Append("	{"); //461:1
            __out.AppendLine(); //461:3
            __out.Append("	}"); //462:1
            __out.AppendLine(); //462:3
            __out.AppendLine(); //463:2
            __out.Append("    /// <summary>"); //464:1
            __out.AppendLine(); //464:18
            __out.Append("    /// The singleton instance of the factory."); //465:1
            __out.AppendLine(); //465:47
            __out.Append("    /// </summary>"); //466:1
            __out.AppendLine(); //466:19
            string __tmp12Prefix = "    public static "; //467:1
            string __tmp13Suffix = "Factory Instance"; //467:31
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
                    __out.AppendLine(); //467:47
                }
            }
            __out.Append("    {"); //468:1
            __out.AppendLine(); //468:6
            string __tmp15Prefix = "        get { return "; //469:1
            string __tmp16Suffix = "Factory.instance; }"; //469:34
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
                    __out.AppendLine(); //469:53
                }
            }
            __out.Append("    }"); //470:1
            __out.AppendLine(); //470:6
            var __loop40_results = 
                (from __loop40_var1 in __Enumerate((model).GetEnumerator()) //471:8
                from Types in __Enumerate((__loop40_var1.Types).GetEnumerator()) //471:15
                from cls in __Enumerate((Types).GetEnumerator()).OfType<MetaClass>() //471:22
                select new { __loop40_var1 = __loop40_var1, Types = Types, cls = cls}
                ).ToList(); //471:3
            int __loop40_iteration = 0;
            foreach (var __tmp18 in __loop40_results)
            {
                ++__loop40_iteration;
                var __loop40_var1 = __tmp18.__loop40_var1;
                var Types = __tmp18.Types;
                var cls = __tmp18.cls;
                __out.AppendLine(); //472:2
                __out.Append("    /// <summary>"); //473:1
                __out.AppendLine(); //473:18
                string __tmp19Prefix = "    /// Creates a new instance of "; //474:1
                string __tmp20Suffix = "."; //474:53
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
                        __out.AppendLine(); //474:54
                    }
                }
                __out.Append("    /// </summary>"); //475:1
                __out.AppendLine(); //475:19
                string __tmp22Prefix = "    public "; //476:1
                string __tmp23Suffix = "()"; //476:55
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
                string __tmp25Line = " Create"; //476:30
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
                        __out.AppendLine(); //476:57
                    }
                }
                __out.Append("	{"); //477:1
                __out.AppendLine(); //477:3
                string __tmp27Prefix = "		"; //478:1
                string __tmp28Suffix = "();"; //478:57
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
                string __tmp30Line = " result = new "; //478:21
                __out.Append(__tmp30Line);
                StringBuilder __tmp31 = new StringBuilder();
                __tmp31.Append(cls.CSharpImplName());
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
                        __out.AppendLine(); //478:60
                    }
                }
                __out.Append("		return result;"); //479:1
                __out.AppendLine(); //479:17
                __out.Append("	}"); //480:1
                __out.AppendLine(); //480:3
                __out.AppendLine(); //481:2
            }
            __out.Append("}"); //483:1
            __out.AppendLine(); //483:2
            __out.AppendLine(); //484:2
            return __out.ToString();
        }

    }
}

