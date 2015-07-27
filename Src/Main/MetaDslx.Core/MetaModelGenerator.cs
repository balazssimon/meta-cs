using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core //1:1
{
    using __Hidden_MetaModelGenerator_1251959506;
    namespace __Hidden_MetaModelGenerator_1251959506
    {
        internal static class __Extensions
        {
            internal static IEnumerator<T> GetEnumerator<T>(this T item)
            {
                return new List<T> { item }.GetEnumerator();
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

        public string GenerateEnum(MetaEnum enm) //33:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public enum "; //34:1
            string __tmp2Suffix = string.Empty; 
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(enm.CSharpName());
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
                    __out.AppendLine(); //34:31
                }
            }
            __out.Append("{"); //35:1
            __out.AppendLine(); //35:2
            var __loop4_results = 
                (from __loop4_var1 in __Enumerate((enm).GetEnumerator()) //36:11
                from value in __Enumerate((__loop4_var1.EnumLiterals).GetEnumerator()) //36:16
                select new { __loop4_var1 = __loop4_var1, value = value}
                ).ToList(); //36:6
            int __loop4_iteration = 0;
            foreach (var __tmp4 in __loop4_results)
            {
                ++__loop4_iteration;
                var __loop4_var1 = __tmp4.__loop4_var1;
                var value = __tmp4.value;
                string __tmp5Prefix = "    "; //37:1
                string __tmp6Suffix = ","; //37:17
                StringBuilder __tmp7 = new StringBuilder();
                __tmp7.Append(value.Name);
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
                        __out.AppendLine(); //37:18
                    }
                }
            }
            __out.Append("}"); //39:1
            __out.AppendLine(); //39:2
            __out.AppendLine(); //40:2
            return __out.ToString();
        }

        public string GetAncestors(MetaClass cls) //43:1
        {
            string result = ""; //44:2
            var __loop5_results = 
                (from __loop5_var1 in __Enumerate((cls).GetEnumerator()) //45:7
                from super in __Enumerate((__loop5_var1.SuperClasses).GetEnumerator()) //45:12
                select new { __loop5_var1 = __loop5_var1, super = super}
                ).ToList(); //45:2
            int __loop5_iteration = 0;
            string delim = " : "; //45:32
            foreach (var __tmp1 in __loop5_results)
            {
                ++__loop5_iteration;
                if (__loop5_iteration >= 2) //45:54
                {
                    delim = ", "; //45:54
                }
                var __loop5_var1 = __tmp1.__loop5_var1;
                var super = __tmp1.super;
                result += delim + super.Namespace.CSharpName() + "." + super.CSharpName(); //46:3
            }
            return result; //48:2
        }

        public string GenerateInterface(MetaClass cls) //51:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public interface "; //52:1
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
                }
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(GetAncestors(cls));
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
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //52:55
                }
            }
            __out.Append("{"); //53:1
            __out.AppendLine(); //53:2
            var __loop6_results = 
                (from __loop6_var1 in __Enumerate((cls).GetEnumerator()) //54:11
                from prop in __Enumerate((__loop6_var1.Properties).GetEnumerator()) //54:16
                select new { __loop6_var1 = __loop6_var1, prop = prop}
                ).ToList(); //54:6
            int __loop6_iteration = 0;
            foreach (var __tmp5 in __loop6_results)
            {
                ++__loop6_iteration;
                var __loop6_var1 = __tmp5.__loop6_var1;
                var prop = __tmp5.prop;
                string __tmp6Prefix = "    "; //55:1
                string __tmp7Suffix = string.Empty; 
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(GenerateProperty(prop));
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
                        __out.AppendLine(); //55:29
                    }
                }
            }
            __out.AppendLine(); //57:2
            var __loop7_results = 
                (from __loop7_var1 in __Enumerate((cls).GetEnumerator()) //58:11
                from op in __Enumerate((__loop7_var1.Operations).GetEnumerator()) //58:16
                select new { __loop7_var1 = __loop7_var1, op = op}
                ).ToList(); //58:6
            int __loop7_iteration = 0;
            foreach (var __tmp9 in __loop7_results)
            {
                ++__loop7_iteration;
                var __loop7_var1 = __tmp9.__loop7_var1;
                var op = __tmp9.op;
                string __tmp10Prefix = "    "; //59:1
                string __tmp11Suffix = string.Empty; 
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(GenerateOperation(op));
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
                        __out.AppendLine(); //59:28
                    }
                }
            }
            __out.Append("}"); //61:1
            __out.AppendLine(); //61:2
            __out.AppendLine(); //62:2
            return __out.ToString();
        }

        public string GenerateProperty(MetaProperty prop) //65:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //66:2
            {
                __out.Append("new "); //67:1
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //69:3
            {
                string __tmp1Prefix = string.Empty; 
                string __tmp2Suffix = " { get; set; }"; //70:43
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
                string __tmp4Line = " "; //70:31
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
                        __out.AppendLine(); //70:57
                    }
                }
            }
            else //71:3
            {
                string __tmp6Prefix = string.Empty; 
                string __tmp7Suffix = " { get; }"; //72:43
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
                string __tmp9Line = " "; //72:31
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
                        __out.AppendLine(); //72:52
                    }
                }
            }
            return __out.ToString();
        }

        public string GetParameters(MetaOperation op, bool defaultValues) //76:1
        {
            string result = ""; //77:2
            var __loop8_results = 
                (from __loop8_var1 in __Enumerate((op).GetEnumerator()) //78:7
                from param in __Enumerate((__loop8_var1.Parameters).GetEnumerator()) //78:11
                select new { __loop8_var1 = __loop8_var1, param = param}
                ).ToList(); //78:2
            int __loop8_iteration = 0;
            string delim = ""; //78:29
            foreach (var __tmp1 in __loop8_results)
            {
                ++__loop8_iteration;
                if (__loop8_iteration >= 2) //78:48
                {
                    delim = ", "; //78:48
                }
                var __loop8_var1 = __tmp1.__loop8_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpPublicName() + " " + param.Name; //79:3
            }
            return result; //84:2
        }

        public string GetImplParameters(MetaClass cls, MetaOperation op) //87:1
        {
            string result = cls.CSharpName() + " @this"; //88:2
            string delim = ", "; //89:2
            var __loop9_results = 
                (from __loop9_var1 in __Enumerate((op).GetEnumerator()) //90:7
                from param in __Enumerate((__loop9_var1.Parameters).GetEnumerator()) //90:11
                select new { __loop9_var1 = __loop9_var1, param = param}
                ).ToList(); //90:2
            int __loop9_iteration = 0;
            foreach (var __tmp1 in __loop9_results)
            {
                ++__loop9_iteration;
                var __loop9_var1 = __tmp1.__loop9_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpPublicName() + " " + param.Name; //91:3
            }
            return result; //93:2
        }

        public string GetImplParameters(MetaEnum enm, MetaOperation op) //96:1
        {
            string result = enm.CSharpName() + " @this"; //97:2
            string delim = ", "; //98:2
            var __loop10_results = 
                (from __loop10_var1 in __Enumerate((op).GetEnumerator()) //99:7
                from param in __Enumerate((__loop10_var1.Parameters).GetEnumerator()) //99:11
                select new { __loop10_var1 = __loop10_var1, param = param}
                ).ToList(); //99:2
            int __loop10_iteration = 0;
            foreach (var __tmp1 in __loop10_results)
            {
                ++__loop10_iteration;
                var __loop10_var1 = __tmp1.__loop10_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpPublicName() + " " + param.Name; //100:3
            }
            return result; //102:2
        }

        public string GetEnumImplParameters(MetaEnum enm, MetaOperation op) //105:1
        {
            string result = "this " + enm.CSharpName() + " @this"; //106:2
            string delim = ", "; //107:2
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((op).GetEnumerator()) //108:7
                from param in __Enumerate((__loop11_var1.Parameters).GetEnumerator()) //108:11
                select new { __loop11_var1 = __loop11_var1, param = param}
                ).ToList(); //108:2
            int __loop11_iteration = 0;
            foreach (var __tmp1 in __loop11_results)
            {
                ++__loop11_iteration;
                var __loop11_var1 = __tmp1.__loop11_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpPublicName() + " " + param.Name; //109:3
            }
            return result; //111:2
        }

        public string GetEnumImplCallParameterNames(MetaOperation op) //114:1
        {
            string result = "@this"; //115:2
            string delim = ", "; //116:2
            var __loop12_results = 
                (from __loop12_var1 in __Enumerate((op).GetEnumerator()) //117:7
                from param in __Enumerate((__loop12_var1.Parameters).GetEnumerator()) //117:11
                select new { __loop12_var1 = __loop12_var1, param = param}
                ).ToList(); //117:2
            int __loop12_iteration = 0;
            foreach (var __tmp1 in __loop12_results)
            {
                ++__loop12_iteration;
                var __loop12_var1 = __tmp1.__loop12_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //118:3
            }
            return result; //120:2
        }

        public string GetImplCallParameterNames(MetaOperation op) //123:1
        {
            string result = "this"; //124:2
            string delim = ", "; //125:2
            var __loop13_results = 
                (from __loop13_var1 in __Enumerate((op).GetEnumerator()) //126:7
                from param in __Enumerate((__loop13_var1.Parameters).GetEnumerator()) //126:11
                select new { __loop13_var1 = __loop13_var1, param = param}
                ).ToList(); //126:2
            int __loop13_iteration = 0;
            foreach (var __tmp1 in __loop13_results)
            {
                ++__loop13_iteration;
                var __loop13_var1 = __tmp1.__loop13_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //127:3
            }
            return result; //129:2
        }

        public string GenerateOperation(MetaOperation op) //132:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = ");"; //133:71
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
            string __tmp4Line = " "; //133:35
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
            string __tmp6Line = "("; //133:45
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
                    __out.AppendLine(); //133:73
                }
            }
            return __out.ToString();
        }

        public string GenerateInterfaceImpl(MetaModel model, MetaClass cls) //136:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "internal class "; //137:1
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
            string __tmp4Line = " : ModelObject, "; //137:38
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
            string __tmp6Line = "."; //137:82
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
                    __out.AppendLine(); //137:101
                }
            }
            __out.Append("{"); //138:1
            __out.AppendLine(); //138:2
            string __tmp8Prefix = "    static "; //139:1
            string __tmp9Suffix = "()"; //139:34
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
                    __out.AppendLine(); //139:36
                }
            }
            __out.Append("    {"); //140:1
            __out.AppendLine(); //140:6
            string __tmp11Prefix = "        "; //141:1
            string __tmp12Suffix = ".StaticInit();"; //141:52
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
                }
            }
            string __tmp14Line = "."; //141:33
            __out.Append(__tmp14Line);
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
                    __out.Append(__tmp15Line);
                    __out.Append(__tmp12Suffix);
                    __out.AppendLine(); //141:66
                }
            }
            __out.Append("    }"); //142:1
            __out.AppendLine(); //142:6
            __out.AppendLine(); //143:2
            string __tmp16Prefix = "    "; //144:1
            string __tmp17Suffix = string.Empty; 
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append(GenerateConstructorImpl(model, cls));
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
                    __out.AppendLine(); //144:42
                }
            }
            var __loop14_results = 
                (from __loop14_var1 in __Enumerate((cls).GetEnumerator()) //145:11
                from prop in __Enumerate((__loop14_var1.GetAllProperties()).GetEnumerator()) //145:16
                select new { __loop14_var1 = __loop14_var1, prop = prop}
                ).ToList(); //145:6
            int __loop14_iteration = 0;
            foreach (var __tmp19 in __loop14_results)
            {
                ++__loop14_iteration;
                var __loop14_var1 = __tmp19.__loop14_var1;
                var prop = __tmp19.prop;
                string __tmp20Prefix = "    "; //146:1
                string __tmp21Suffix = string.Empty; 
                StringBuilder __tmp22 = new StringBuilder();
                __tmp22.Append(GeneratePropertyImpl(model, cls, prop));
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
                        __out.AppendLine(); //146:45
                    }
                }
            }
            var __loop15_results = 
                (from __loop15_var1 in __Enumerate((cls).GetEnumerator()) //148:11
                from op in __Enumerate((__loop15_var1.GetAllOperations()).GetEnumerator()) //148:16
                select new { __loop15_var1 = __loop15_var1, op = op}
                ).ToList(); //148:6
            int __loop15_iteration = 0;
            foreach (var __tmp23 in __loop15_results)
            {
                ++__loop15_iteration;
                var __loop15_var1 = __tmp23.__loop15_var1;
                var op = __tmp23.op;
                string __tmp24Prefix = "    "; //149:1
                string __tmp25Suffix = string.Empty; 
                StringBuilder __tmp26 = new StringBuilder();
                __tmp26.Append(GenerateOperationImpl(model, op));
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
                        __out.AppendLine(); //149:39
                    }
                }
            }
            __out.Append("}"); //151:1
            __out.AppendLine(); //151:2
            __out.AppendLine(); //152:2
            return __out.ToString();
        }

        public string GeneratePropertyDeclaration(MetaModel model, MetaClass cls, MetaProperty prop) //155:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class == cls) //156:2
            {
                if (prop.Kind == MetaPropertyKind.Containment) //157:2
                {
                    string __tmp1Prefix = string.Empty;
                    string __tmp2Suffix = string.Empty;
                    StringBuilder __tmp3 = new StringBuilder();
                    __tmp3.Append("[ContainmentAttribute]");
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
                            __out.AppendLine(); //158:27
                        }
                    }
                }
                if (prop.Kind != MetaPropertyKind.Normal && prop.Kind != MetaPropertyKind.Containment && !(prop.Type is MetaCollectionType)) //160:2
                {
                    string __tmp4Prefix = string.Empty;
                    string __tmp5Suffix = string.Empty;
                    StringBuilder __tmp6 = new StringBuilder();
                    __tmp6.Append("[ReadonlyAttribute]");
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
                            __out.AppendLine(); //161:24
                        }
                    }
                }
                var __loop16_results = 
                    (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //163:7
                    select new { p = p}
                    ).ToList(); //163:2
                int __loop16_iteration = 0;
                foreach (var __tmp7 in __loop16_results)
                {
                    ++__loop16_iteration;
                    var p = __tmp7.p;
                    string __tmp8Prefix = string.Empty; 
                    string __tmp9Suffix = string.Empty; 
                    StringBuilder __tmp10 = new StringBuilder();
                    __tmp10.Append("[OppositeAttribute(typeof(");
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
                    __tmp11.Append(p.Class.Model.CSharpFullName());
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
                    string __tmp12Line = "."; //164:63
                    __out.Append(__tmp12Line);
                    StringBuilder __tmp13 = new StringBuilder();
                    __tmp13.Append(p.Class.CSharpName());
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
                    __tmp14.Append("), \"");
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
                        }
                    }
                    StringBuilder __tmp16 = new StringBuilder();
                    __tmp16.Append("\")]");
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
                            __out.AppendLine(); //164:111
                        }
                    }
                }
                var __loop17_results = 
                    (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //166:7
                    select new { p = p}
                    ).ToList(); //166:2
                int __loop17_iteration = 0;
                foreach (var __tmp17 in __loop17_results)
                {
                    ++__loop17_iteration;
                    var p = __tmp17.p;
                    if (cls.GetAllSuperClasses(false).Contains(p.Class)) //167:3
                    {
                        string __tmp18Prefix = string.Empty; 
                        string __tmp19Suffix = string.Empty; 
                        StringBuilder __tmp20 = new StringBuilder();
                        __tmp20.Append("[SubsetsAttribute(typeof(");
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
                        StringBuilder __tmp21 = new StringBuilder();
                        __tmp21.Append(p.Class.Model.CSharpFullName());
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
                        string __tmp22Line = "."; //168:62
                        __out.Append(__tmp22Line);
                        StringBuilder __tmp23 = new StringBuilder();
                        __tmp23.Append(p.Class.CSharpName());
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
                        StringBuilder __tmp24 = new StringBuilder();
                        __tmp24.Append("), \"");
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
                        StringBuilder __tmp25 = new StringBuilder();
                        __tmp25.Append(p.Name);
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
                            }
                        }
                        StringBuilder __tmp26 = new StringBuilder();
                        __tmp26.Append("\")]");
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
                                __out.Append(__tmp19Suffix);
                                __out.AppendLine(); //168:110
                            }
                        }
                    }
                    else //169:3
                    {
                        string __tmp27Prefix = "// ERROR: subsetted property '"; //170:1
                        string __tmp28Suffix = "' must be a property of an ancestor class"; //170:95
                        StringBuilder __tmp29 = new StringBuilder();
                        __tmp29.Append(p.Class.Model.CSharpFullName());
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
                        string __tmp30Line = "."; //170:63
                        __out.Append(__tmp30Line);
                        StringBuilder __tmp31 = new StringBuilder();
                        __tmp31.Append(p.Class.CSharpName());
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
                        string __tmp32Line = "."; //170:86
                        __out.Append(__tmp32Line);
                        StringBuilder __tmp33 = new StringBuilder();
                        __tmp33.Append(p.Name);
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
                                __out.AppendLine(); //170:136
                            }
                        }
                    }
                }
                var __loop18_results = 
                    (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //173:7
                    select new { p = p}
                    ).ToList(); //173:2
                int __loop18_iteration = 0;
                foreach (var __tmp34 in __loop18_results)
                {
                    ++__loop18_iteration;
                    var p = __tmp34.p;
                    if (cls.GetAllSuperClasses(false).Contains(p.Class)) //174:3
                    {
                        string __tmp35Prefix = string.Empty; 
                        string __tmp36Suffix = string.Empty; 
                        StringBuilder __tmp37 = new StringBuilder();
                        __tmp37.Append("[RedefinesAttribute(typeof(");
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
                            }
                        }
                        StringBuilder __tmp38 = new StringBuilder();
                        __tmp38.Append(p.Class.Model.CSharpFullName());
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
                            }
                        }
                        string __tmp39Line = "."; //175:64
                        __out.Append(__tmp39Line);
                        StringBuilder __tmp40 = new StringBuilder();
                        __tmp40.Append(p.Class.CSharpName());
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
                        StringBuilder __tmp41 = new StringBuilder();
                        __tmp41.Append("), \"");
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
                        StringBuilder __tmp42 = new StringBuilder();
                        __tmp42.Append(p.Name);
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
                        StringBuilder __tmp43 = new StringBuilder();
                        __tmp43.Append("\")]");
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
                                __out.Append(__tmp36Suffix);
                                __out.AppendLine(); //175:112
                            }
                        }
                    }
                    else //176:3
                    {
                        string __tmp44Prefix = "// ERROR: redefined property '"; //177:1
                        string __tmp45Suffix = "' must be a property of an ancestor class"; //177:95
                        StringBuilder __tmp46 = new StringBuilder();
                        __tmp46.Append(p.Class.Model.CSharpFullName());
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
                            }
                        }
                        string __tmp47Line = "."; //177:63
                        __out.Append(__tmp47Line);
                        StringBuilder __tmp48 = new StringBuilder();
                        __tmp48.Append(p.Class.CSharpName());
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
                        string __tmp49Line = "."; //177:86
                        __out.Append(__tmp49Line);
                        StringBuilder __tmp50 = new StringBuilder();
                        __tmp50.Append(p.Name);
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
                                __out.Append(__tmp45Suffix);
                                __out.AppendLine(); //177:136
                            }
                        }
                    }
                }
                string __tmp51Prefix = "public static readonly ModelProperty "; //180:1
                string __tmp52Suffix = "Property ="; //180:49
                StringBuilder __tmp53 = new StringBuilder();
                __tmp53.Append(prop.Name);
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
                        __out.AppendLine(); //180:59
                    }
                }
                string __tmp54Prefix = "    ModelProperty.Register(\""; //181:1
                string __tmp55Suffix = "));"; //181:198
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
                    }
                }
                string __tmp57Line = "\", typeof("; //181:40
                __out.Append(__tmp57Line);
                StringBuilder __tmp58 = new StringBuilder();
                __tmp58.Append(prop.Type.CSharpFullPublicName());
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
                string __tmp59Line = "), typeof("; //181:84
                __out.Append(__tmp59Line);
                StringBuilder __tmp60 = new StringBuilder();
                __tmp60.Append(prop.Class.CSharpFullImplName());
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
                string __tmp61Line = "), typeof("; //181:127
                __out.Append(__tmp61Line);
                StringBuilder __tmp62 = new StringBuilder();
                __tmp62.Append(prop.Class.Model.CSharpFullName());
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
                    }
                }
                string __tmp63Line = "."; //181:172
                __out.Append(__tmp63Line);
                StringBuilder __tmp64 = new StringBuilder();
                __tmp64.Append(prop.Class.CSharpName());
                using(StreamReader __tmp64Reader = new StreamReader(this.__ToStream(__tmp64.ToString())))
                {
                    bool __tmp64_first = true;
                    while(__tmp64_first || !__tmp64Reader.EndOfStream)
                    {
                        __tmp64_first = false;
                        string __tmp64Line = __tmp64Reader.ReadLine();
                        if (__tmp64Line == null)
                        {
                            __tmp64Line = "";
                        }
                        __out.Append(__tmp64Line);
                        __out.Append(__tmp55Suffix);
                        __out.AppendLine(); //181:201
                    }
                }
            }
            __out.AppendLine(); //183:2
            return __out.ToString();
        }

        public string GeneratePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //186:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //187:2
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
            string __tmp4Line = " "; //188:31
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
            string __tmp6Line = "."; //188:57
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
                    __out.AppendLine(); //188:69
                }
            }
            __out.Append("{"); //189:1
            __out.AppendLine(); //189:2
            if (prop.Kind == MetaPropertyKind.Derived) //190:3
            {
                string __tmp8Prefix = "    get { return "; //191:1
                string __tmp9Suffix = "(this); }"; //191:113
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
                string __tmp11Line = "ImplementationProvider.Implementation."; //191:38
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
                string __tmp13Line = "_"; //191:101
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
                        __out.AppendLine(); //191:122
                    }
                }
            }
            else //192:3
            {
                __out.Append("    get "); //193:1
                __out.AppendLine(); //193:9
                __out.Append("    {"); //194:1
                __out.AppendLine(); //194:6
                string __tmp15Prefix = "        object result = this.MGet("; //195:1
                string __tmp16Suffix = "Property); "; //195:97
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
                string __tmp18Line = "."; //195:59
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
                string __tmp20Line = "."; //195:85
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
                        __out.AppendLine(); //195:108
                    }
                }
                string __tmp22Prefix = "        if (result != null) return ("; //196:1
                string __tmp23Suffix = ")result;"; //196:67
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
                        __out.AppendLine(); //196:75
                    }
                }
                string __tmp25Prefix = "        else return default("; //197:1
                string __tmp26Suffix = ");"; //197:59
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
                        __out.AppendLine(); //197:61
                    }
                }
                __out.Append("    }"); //198:1
                __out.AppendLine(); //198:6
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //200:3
            {
                string __tmp28Prefix = "    set { this.MSet("; //201:1
                string __tmp29Suffix = "Property, value); }"; //201:83
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
                string __tmp31Line = "."; //201:45
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
                string __tmp33Line = "."; //201:71
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
                        __out.AppendLine(); //201:102
                    }
                }
            }
            __out.Append("}"); //203:1
            __out.AppendLine(); //203:2
            return __out.ToString();
        }

        public string GetCollectionConstructorParams(MetaProperty prop) //206:1
        {
            MetaCollectionType mct = prop.Type as MetaCollectionType; //207:2
            if (mct != null && mct.InnerType is MetaClass) //208:2
            {
                return "this, " + prop.Class.Model.CSharpFullName() + "." + prop.Class.CSharpName() + "." + prop.Name + "Property"; //209:3
            }
            else //210:2
            {
                return ""; //211:3
            }
        }

        public string GenerateConstructorImpl(MetaModel model, MetaClass cls) //215:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public "; //216:1
            string __tmp2Suffix = "()"; //216:30
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
                    __out.AppendLine(); //216:32
                }
            }
            __out.Append("{"); //217:1
            __out.AppendLine(); //217:2
            var __loop19_results = 
                (from __loop19_var1 in __Enumerate((cls).GetEnumerator()) //218:8
                from prop in __Enumerate((__loop19_var1.GetAllProperties()).GetEnumerator()) //218:13
                select new { __loop19_var1 = __loop19_var1, prop = prop}
                ).ToList(); //218:3
            int __loop19_iteration = 0;
            foreach (var __tmp4 in __loop19_results)
            {
                ++__loop19_iteration;
                var __loop19_var1 = __tmp4.__loop19_var1;
                var prop = __tmp4.prop;
                if (prop.Type is MetaCollectionType) //219:4
                {
                    if (prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) //220:5
                    {
                        string __tmp5Prefix = "    this.MSet("; //221:1
                        string __tmp6Suffix = "));"; //221:154
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
                        string __tmp8Line = "."; //221:39
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
                        string __tmp10Line = "."; //221:65
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
                        string __tmp12Line = "Property, new "; //221:77
                        __out.Append(__tmp12Line);
                        StringBuilder __tmp13 = new StringBuilder();
                        __tmp13.Append(prop.Type.CSharpName());
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
                        string __tmp14Line = "("; //221:115
                        __out.Append(__tmp14Line);
                        StringBuilder __tmp15 = new StringBuilder();
                        __tmp15.Append(GetCollectionConstructorParams(prop));
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
                                __out.Append(__tmp6Suffix);
                                __out.AppendLine(); //221:157
                            }
                        }
                    }
                    else if (prop.Kind == MetaPropertyKind.Lazy) //222:5
                    {
                        string __tmp16Prefix = "    this.MLazySet("; //223:1
                        string __tmp17Suffix = "(this)));"; //223:209
                        StringBuilder __tmp18 = new StringBuilder();
                        __tmp18.Append(model.CSharpFullName());
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
                        string __tmp19Line = "."; //223:43
                        __out.Append(__tmp19Line);
                        StringBuilder __tmp20 = new StringBuilder();
                        __tmp20.Append(prop.Class.CSharpName());
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
                        string __tmp21Line = "."; //223:69
                        __out.Append(__tmp21Line);
                        StringBuilder __tmp22 = new StringBuilder();
                        __tmp22.Append(prop.Name);
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
                        string __tmp23Line = "Property, new Lazy<object>(() => "; //223:81
                        __out.Append(__tmp23Line);
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
                                __out.Append(__tmp24Line);
                            }
                        }
                        string __tmp25Line = "ImplementationProvider.Implementation."; //223:134
                        __out.Append(__tmp25Line);
                        StringBuilder __tmp26 = new StringBuilder();
                        __tmp26.Append(prop.Class.CSharpName());
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
                        string __tmp27Line = "_"; //223:197
                        __out.Append(__tmp27Line);
                        StringBuilder __tmp28 = new StringBuilder();
                        __tmp28.Append(prop.Name);
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
                                __out.Append(__tmp17Suffix);
                                __out.AppendLine(); //223:218
                            }
                        }
                    }
                    else if (prop.Kind == MetaPropertyKind.Readonly) //224:5
                    {
                        string __tmp29Prefix = "    // Init "; //225:1
                        string __tmp30Suffix = string.Empty; 
                        StringBuilder __tmp31 = new StringBuilder();
                        __tmp31.Append(model.CSharpFullName());
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
                            }
                        }
                        string __tmp32Line = "."; //225:37
                        __out.Append(__tmp32Line);
                        StringBuilder __tmp33 = new StringBuilder();
                        __tmp33.Append(prop.Class.CSharpName());
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
                        string __tmp34Line = "."; //225:63
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
                            }
                        }
                        string __tmp36Line = "Property in "; //225:75
                        __out.Append(__tmp36Line);
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
                        string __tmp38Line = "Implementation."; //225:107
                        __out.Append(__tmp38Line);
                        StringBuilder __tmp39 = new StringBuilder();
                        __tmp39.Append(cls.CSharpName());
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
                        string __tmp40Line = "_"; //225:140
                        __out.Append(__tmp40Line);
                        StringBuilder __tmp41 = new StringBuilder();
                        __tmp41.Append(cls.CSharpName());
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
                                __out.Append(__tmp30Suffix);
                                __out.AppendLine(); //225:159
                            }
                        }
                    }
                }
                else //227:7
                {
                    if (prop.Kind == MetaPropertyKind.Lazy) //228:5
                    {
                        string __tmp42Prefix = "    this.MLazySet("; //229:1
                        string __tmp43Suffix = "(this)));"; //229:209
                        StringBuilder __tmp44 = new StringBuilder();
                        __tmp44.Append(model.CSharpFullName());
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
                                __out.Append(__tmp42Prefix);
                                __out.Append(__tmp44Line);
                            }
                        }
                        string __tmp45Line = "."; //229:43
                        __out.Append(__tmp45Line);
                        StringBuilder __tmp46 = new StringBuilder();
                        __tmp46.Append(prop.Class.CSharpName());
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
                        string __tmp47Line = "."; //229:69
                        __out.Append(__tmp47Line);
                        StringBuilder __tmp48 = new StringBuilder();
                        __tmp48.Append(prop.Name);
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
                        string __tmp49Line = "Property, new Lazy<object>(() => "; //229:81
                        __out.Append(__tmp49Line);
                        StringBuilder __tmp50 = new StringBuilder();
                        __tmp50.Append(model.CSharpName());
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
                        string __tmp51Line = "ImplementationProvider.Implementation."; //229:134
                        __out.Append(__tmp51Line);
                        StringBuilder __tmp52 = new StringBuilder();
                        __tmp52.Append(prop.Class.CSharpName());
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
                            }
                        }
                        string __tmp53Line = "_"; //229:197
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
                                __out.Append(__tmp43Suffix);
                                __out.AppendLine(); //229:218
                            }
                        }
                    }
                    else if (prop.Kind == MetaPropertyKind.Readonly) //230:5
                    {
                        string __tmp55Prefix = "    // Init "; //231:1
                        string __tmp56Suffix = string.Empty; 
                        StringBuilder __tmp57 = new StringBuilder();
                        __tmp57.Append(model.CSharpFullName());
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
                        string __tmp58Line = "."; //231:37
                        __out.Append(__tmp58Line);
                        StringBuilder __tmp59 = new StringBuilder();
                        __tmp59.Append(prop.Class.CSharpName());
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
                        string __tmp60Line = "."; //231:63
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
                        string __tmp62Line = "Property in "; //231:75
                        __out.Append(__tmp62Line);
                        StringBuilder __tmp63 = new StringBuilder();
                        __tmp63.Append(model.CSharpName());
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
                        string __tmp64Line = "Implementation."; //231:107
                        __out.Append(__tmp64Line);
                        StringBuilder __tmp65 = new StringBuilder();
                        __tmp65.Append(cls.CSharpName());
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
                        string __tmp66Line = "_"; //231:140
                        __out.Append(__tmp66Line);
                        StringBuilder __tmp67 = new StringBuilder();
                        __tmp67.Append(cls.CSharpName());
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
                                __out.Append(__tmp56Suffix);
                                __out.AppendLine(); //231:159
                            }
                        }
                    }
                }
            }
            string __tmp68Prefix = "    "; //235:1
            string __tmp69Suffix = "(this);"; //235:104
            StringBuilder __tmp70 = new StringBuilder();
            __tmp70.Append(cls.Model.CSharpName());
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
                    __out.Append(__tmp68Prefix);
                    __out.Append(__tmp70Line);
                }
            }
            string __tmp71Line = "ImplementationProvider.Implementation."; //235:29
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
                }
            }
            string __tmp73Line = "_"; //235:85
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
                    __out.Append(__tmp69Suffix);
                    __out.AppendLine(); //235:111
                }
            }
            var __loop20_results = 
                (from __loop20_var1 in __Enumerate((cls).GetEnumerator()) //236:11
                from prop in __Enumerate((__loop20_var1.GetAllProperties()).GetEnumerator()) //236:16
                select new { __loop20_var1 = __loop20_var1, prop = prop}
                ).ToList(); //236:6
            int __loop20_iteration = 0;
            foreach (var __tmp75 in __loop20_results)
            {
                ++__loop20_iteration;
                var __loop20_var1 = __tmp75.__loop20_var1;
                var prop = __tmp75.prop;
                if (prop.Kind == MetaPropertyKind.Readonly) //237:4
                {
                    string __tmp76Prefix = "    if (!this.MIsSet("; //238:1
                    string __tmp77Suffix = "().\");"; //238:258
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
                    string __tmp79Line = "."; //238:46
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
                    string __tmp81Line = "."; //238:72
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
                    string __tmp83Line = "Property)) throw new ModelException(\"Readonly property "; //238:84
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
                    string __tmp85Line = "."; //238:159
                    __out.Append(__tmp85Line);
                    StringBuilder __tmp86 = new StringBuilder();
                    __tmp86.Append(prop.Class.CSharpName());
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
                    string __tmp87Line = "."; //238:185
                    __out.Append(__tmp87Line);
                    StringBuilder __tmp88 = new StringBuilder();
                    __tmp88.Append(prop.Name);
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
                    string __tmp89Line = "Property was not set in "; //238:197
                    __out.Append(__tmp89Line);
                    StringBuilder __tmp90 = new StringBuilder();
                    __tmp90.Append(cls.CSharpName());
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
                    string __tmp91Line = "_"; //238:239
                    __out.Append(__tmp91Line);
                    StringBuilder __tmp92 = new StringBuilder();
                    __tmp92.Append(cls.CSharpName());
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
                            __out.Append(__tmp77Suffix);
                            __out.AppendLine(); //238:264
                        }
                    }
                }
            }
            __out.Append("    this.MMakeDefault();"); //241:1
            __out.AppendLine(); //241:25
            __out.Append("}"); //242:1
            __out.AppendLine(); //242:2
            return __out.ToString();
        }

        public string GetReturn(MetaOperation op) //245:1
        {
            if (op.ReturnType.CSharpName() == "void") //246:5
            {
                return ""; //247:3
            }
            else //248:2
            {
                return "return "; //249:3
            }
        }

        public string GenerateOperationImpl(MetaModel model, MetaOperation op) //253:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //254:2
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = ")"; //255:97
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
            string __tmp4Line = " "; //255:35
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
            string __tmp6Line = "."; //255:60
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
            string __tmp8Line = "("; //255:70
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
                    __out.AppendLine(); //255:98
                }
            }
            __out.Append("{"); //256:1
            __out.AppendLine(); //256:2
            string __tmp10Prefix = "    "; //257:1
            string __tmp11Suffix = ");"; //257:144
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
            string __tmp14Line = "ImplementationProvider.Implementation."; //257:40
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
            string __tmp16Line = "_"; //257:102
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
            string __tmp18Line = "("; //257:112
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
                    __out.AppendLine(); //257:146
                }
            }
            __out.Append("}"); //258:1
            __out.AppendLine(); //258:2
            return __out.ToString();
        }

        public string GetSuperClasses(MetaClass cls) //261:1
        {
            string result = ""; //262:2
            var __loop21_results = 
                (from __loop21_var1 in __Enumerate((cls).GetEnumerator()) //263:10
                from sup in __Enumerate((__loop21_var1.SuperClasses).GetEnumerator()) //263:15
                select new { __loop21_var1 = __loop21_var1, sup = sup}
                ).ToList(); //263:5
            int __loop21_iteration = 0;
            string delim = ""; //263:33
            foreach (var __tmp1 in __loop21_results)
            {
                ++__loop21_iteration;
                if (__loop21_iteration >= 2) //263:52
                {
                    delim = ", "; //263:52
                }
                var __loop21_var1 = __tmp1.__loop21_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpName(); //264:3
            }
            return result; //266:2
        }

        public string GetAllSuperClasses(MetaClass cls) //269:1
        {
            string result = ""; //270:2
            var __loop22_results = 
                (from __loop22_var1 in __Enumerate((cls).GetEnumerator()) //271:10
                from sup in __Enumerate((__loop22_var1.GetAllSuperClasses(false)).GetEnumerator()) //271:15
                select new { __loop22_var1 = __loop22_var1, sup = sup}
                ).ToList(); //271:5
            int __loop22_iteration = 0;
            string delim = ""; //271:46
            foreach (var __tmp1 in __loop22_results)
            {
                ++__loop22_iteration;
                if (__loop22_iteration >= 2) //271:65
                {
                    delim = ", "; //271:65
                }
                var __loop22_var1 = __tmp1.__loop22_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpName(); //272:3
            }
            return result; //274:2
        }

        public string GenerateMetaModel(MetaModel model) //277:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public static class "; //278:1
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
                    __out.AppendLine(); //278:41
                }
            }
            __out.Append("{"); //279:1
            __out.AppendLine(); //279:2
            string __tmp4Prefix = "    static "; //280:1
            string __tmp5Suffix = "()"; //280:32
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
                    __out.AppendLine(); //280:34
                }
            }
            __out.Append("    {"); //281:1
            __out.AppendLine(); //281:6
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((model).GetEnumerator()) //282:11
                from Types in __Enumerate((__loop23_var1.Types).GetEnumerator()) //282:18
                from cls in __Enumerate((Types).GetEnumerator()).OfType<MetaClass>() //282:25
                select new { __loop23_var1 = __loop23_var1, Types = Types, cls = cls}
                ).ToList(); //282:6
            int __loop23_iteration = 0;
            foreach (var __tmp7 in __loop23_results)
            {
                ++__loop23_iteration;
                var __loop23_var1 = __tmp7.__loop23_var1;
                var Types = __tmp7.Types;
                var cls = __tmp7.cls;
                string __tmp8Prefix = "        "; //283:1
                string __tmp9Suffix = ".StaticInit();"; //283:27
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
                        __out.AppendLine(); //283:41
                    }
                }
            }
            __out.Append("    }"); //285:1
            __out.AppendLine(); //285:6
            __out.AppendLine(); //286:2
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((model).GetEnumerator()) //287:11
                from Types in __Enumerate((__loop24_var1.Types).GetEnumerator()) //287:18
                from cls in __Enumerate((Types).GetEnumerator()).OfType<MetaClass>() //287:25
                select new { __loop24_var1 = __loop24_var1, Types = Types, cls = cls}
                ).ToList(); //287:6
            int __loop24_iteration = 0;
            foreach (var __tmp11 in __loop24_results)
            {
                ++__loop24_iteration;
                var __loop24_var1 = __tmp11.__loop24_var1;
                var Types = __tmp11.Types;
                var cls = __tmp11.cls;
                string __tmp12Prefix = "    "; //288:1
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
                        __out.AppendLine(); //288:34
                    }
                }
            }
            __out.Append("}"); //290:1
            __out.AppendLine(); //290:2
            __out.AppendLine(); //291:2
            return __out.ToString();
        }

        public string GenerateMetaModelClass(MetaClass cls) //294:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //295:2
            string __tmp1Prefix = "public static class "; //296:1
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
                    __out.AppendLine(); //296:39
                }
            }
            __out.Append("{"); //297:1
            __out.AppendLine(); //297:2
            string __tmp4Prefix = "    static "; //298:1
            string __tmp5Suffix = "()"; //298:30
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
                    __out.AppendLine(); //298:32
                }
            }
            __out.Append("    {"); //299:1
            __out.AppendLine(); //299:6
            var __loop25_results = 
                (from __loop25_var1 in __Enumerate((cls).GetEnumerator()) //300:15
                from sup in __Enumerate((__loop25_var1.GetAllSuperClasses(false)).GetEnumerator()) //300:20
                select new { __loop25_var1 = __loop25_var1, sup = sup}
                ).ToList(); //300:10
            int __loop25_iteration = 0;
            foreach (var __tmp7 in __loop25_results)
            {
                ++__loop25_iteration;
                var __loop25_var1 = __tmp7.__loop25_var1;
                var sup = __tmp7.sup;
                string __tmp8Prefix = "        ModelProperty.RegisterAncestor(typeof("; //301:1
                string __tmp9Suffix = "));"; //301:109
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(cls.CSharpFullImplName());
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
                string __tmp11Line = "), typeof("; //301:73
                __out.Append(__tmp11Line);
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(sup.CSharpFullImplName());
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
                        __out.Append(__tmp9Suffix);
                        __out.AppendLine(); //301:112
                    }
                }
            }
            __out.Append("    }"); //303:1
            __out.AppendLine(); //303:6
            __out.AppendLine(); //304:2
            __out.Append("    internal static void StaticInit()"); //305:1
            __out.AppendLine(); //305:38
            __out.Append("    {"); //306:1
            __out.AppendLine(); //306:6
            __out.Append("    }"); //307:1
            __out.AppendLine(); //307:6
            __out.AppendLine(); //308:2
            var __loop26_results = 
                (from __loop26_var1 in __Enumerate((cls).GetEnumerator()) //309:11
                from prop in __Enumerate((__loop26_var1.Properties).GetEnumerator()) //309:16
                select new { __loop26_var1 = __loop26_var1, prop = prop}
                ).ToList(); //309:6
            int __loop26_iteration = 0;
            foreach (var __tmp13 in __loop26_results)
            {
                ++__loop26_iteration;
                var __loop26_var1 = __tmp13.__loop26_var1;
                var prop = __tmp13.prop;
                string __tmp14Prefix = "    "; //310:1
                string __tmp15Suffix = string.Empty; 
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(GeneratePropertyDeclaration(cls.Model, cls, prop));
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
                        __out.AppendLine(); //310:56
                    }
                }
            }
            __out.Append("}"); //312:1
            __out.AppendLine(); //312:2
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //315:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "internal static class "; //316:1
            string __tmp2Suffix = "ImplementationProvider"; //316:43
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
                    __out.AppendLine(); //316:65
                }
            }
            __out.Append("{"); //317:1
            __out.AppendLine(); //317:2
            string __tmp4Prefix = "    // If there is a compile error at this line, create a new class called "; //318:1
            string __tmp5Suffix = "Implementation"; //318:96
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
                    __out.AppendLine(); //318:110
                }
            }
            string __tmp7Prefix = "	// which is a subclass of "; //319:1
            string __tmp8Suffix = "ImplementationBase:"; //319:48
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
                    __out.AppendLine(); //319:67
                }
            }
            string __tmp10Prefix = "    private static "; //320:1
            string __tmp11Suffix = "Implementation();"; //320:96
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
            string __tmp13Line = "Implementation implementation = new "; //320:40
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
                    __out.AppendLine(); //320:113
                }
            }
            __out.AppendLine(); //321:2
            string __tmp15Prefix = "    public static "; //322:1
            string __tmp16Suffix = "Implementation Implementation"; //322:39
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
                    __out.AppendLine(); //322:68
                }
            }
            __out.Append("    {"); //323:1
            __out.AppendLine(); //323:6
            string __tmp18Prefix = "        get { return "; //324:1
            string __tmp19Suffix = "ImplementationProvider.implementation; }"; //324:42
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
                    __out.AppendLine(); //324:82
                }
            }
            __out.Append("    }"); //325:1
            __out.AppendLine(); //325:6
            __out.Append("}"); //326:1
            __out.AppendLine(); //326:2
            var __loop27_results = 
                (from __loop27_var1 in __Enumerate((model).GetEnumerator()) //327:8
                from Types in __Enumerate((__loop27_var1.Types).GetEnumerator()) //327:15
                from enm in __Enumerate((Types).GetEnumerator()).OfType<MetaEnum>() //327:22
                select new { __loop27_var1 = __loop27_var1, Types = Types, enm = enm}
                ).ToList(); //327:3
            int __loop27_iteration = 0;
            foreach (var __tmp21 in __loop27_results)
            {
                ++__loop27_iteration;
                var __loop27_var1 = __tmp21.__loop27_var1;
                var Types = __tmp21.Types;
                var enm = __tmp21.enm;
                __out.AppendLine(); //328:2
                string __tmp22Prefix = "public static class "; //329:1
                string __tmp23Suffix = "Extensions"; //329:51
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
                        __out.AppendLine(); //329:61
                    }
                }
                __out.Append("{"); //330:1
                __out.AppendLine(); //330:2
                var __loop28_results = 
                    (from __loop28_var1 in __Enumerate((enm).GetEnumerator()) //331:11
                    from op in __Enumerate((__loop28_var1.Operations).GetEnumerator()) //331:16
                    select new { __loop28_var1 = __loop28_var1, op = op}
                    ).ToList(); //331:6
                int __loop28_iteration = 0;
                foreach (var __tmp26 in __loop28_results)
                {
                    ++__loop28_iteration;
                    var __loop28_var1 = __tmp26.__loop28_var1;
                    var op = __tmp26.op;
                    string __tmp27Prefix = "    public static "; //332:1
                    string __tmp28Suffix = ")"; //332:96
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
                    string __tmp30Line = " "; //332:53
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
                    string __tmp32Line = "("; //332:63
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
                            __out.AppendLine(); //332:97
                        }
                    }
                    __out.Append("    {"); //333:1
                    __out.AppendLine(); //333:6
                    string __tmp34Prefix = "        "; //334:1
                    string __tmp35Suffix = ");"; //334:152
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
                    string __tmp38Line = "ImplementationProvider.Implementation."; //334:44
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
                    string __tmp40Line = "_"; //334:106
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
                    string __tmp42Line = "("; //334:116
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
                            __out.AppendLine(); //334:154
                        }
                    }
                    __out.Append("    }"); //335:1
                    __out.AppendLine(); //335:6
                }
                __out.Append("}"); //337:1
                __out.AppendLine(); //337:2
            }
            __out.AppendLine(); //339:2
            __out.Append("/// <summary>"); //340:1
            __out.AppendLine(); //340:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //341:1
            __out.AppendLine(); //341:68
            string __tmp44Prefix = "/// This class has to be be overriden in "; //342:1
            string __tmp45Suffix = "Implementation to provide custom"; //342:62
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
                    __out.AppendLine(); //342:94
                }
            }
            __out.Append("/// implementation for the constructors, operations and property values."); //343:1
            __out.AppendLine(); //343:73
            __out.Append("/// </summary>"); //344:1
            __out.AppendLine(); //344:15
            string __tmp47Prefix = "internal abstract class "; //345:1
            string __tmp48Suffix = "ImplementationBase"; //345:45
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
                    __out.AppendLine(); //345:63
                }
            }
            __out.Append("{"); //346:1
            __out.AppendLine(); //346:2
            string delim = ""; //347:3
            var __loop29_results = 
                (from __loop29_var1 in __Enumerate((model).GetEnumerator()) //348:8
                from Types in __Enumerate((__loop29_var1.Types).GetEnumerator()) //348:15
                from cls in __Enumerate((Types).GetEnumerator()).OfType<MetaClass>() //348:22
                select new { __loop29_var1 = __loop29_var1, Types = Types, cls = cls}
                ).ToList(); //348:3
            int __loop29_iteration = 0;
            foreach (var __tmp50 in __loop29_results)
            {
                ++__loop29_iteration;
                var __loop29_var1 = __tmp50.__loop29_var1;
                var Types = __tmp50.Types;
                var cls = __tmp50.cls;
                __out.Append("    /// <summary>"); //349:1
                __out.AppendLine(); //349:18
                string __tmp51Prefix = "	/// Implements the constructor: "; //350:1
                string __tmp52Suffix = "()"; //350:52
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
                        __out.AppendLine(); //350:54
                    }
                }
                if ((from __loop30_var1 in __Enumerate((cls).GetEnumerator()) //351:15
                from sup in __Enumerate((__loop30_var1.SuperClasses).GetEnumerator()) //351:20
                select new { __loop30_var1 = __loop30_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //351:3
                {
                    string __tmp54Prefix = "	/// Direct superclasses: "; //352:1
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
                            __out.AppendLine(); //352:49
                        }
                    }
                    string __tmp57Prefix = "	/// All superclasses: "; //353:1
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
                            __out.AppendLine(); //353:49
                        }
                    }
                }
                if ((from __loop31_var1 in __Enumerate((cls).GetEnumerator()) //355:15
                from prop in __Enumerate((__loop31_var1.GetAllProperties()).GetEnumerator()) //355:20
                where prop.Kind == MetaPropertyKind.Readonly //355:44
                select new { __loop31_var1 = __loop31_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //355:3
                {
                    __out.Append("    // Initializes the following readonly properties:"); //356:1
                    __out.AppendLine(); //356:54
                }
                var __loop32_results = 
                    (from __loop32_var1 in __Enumerate((cls).GetEnumerator()) //358:11
                    from prop in __Enumerate((__loop32_var1.GetAllProperties()).GetEnumerator()) //358:16
                    select new { __loop32_var1 = __loop32_var1, prop = prop}
                    ).ToList(); //358:6
                int __loop32_iteration = 0;
                foreach (var __tmp60 in __loop32_results)
                {
                    ++__loop32_iteration;
                    var __loop32_var1 = __tmp60.__loop32_var1;
                    var prop = __tmp60.prop;
                    if (prop.Kind == MetaPropertyKind.Readonly) //359:3
                    {
                        string __tmp61Prefix = "    ///    "; //360:1
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
                        string __tmp64Line = "."; //360:29
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
                                __out.AppendLine(); //360:41
                            }
                        }
                    }
                }
                __out.Append("    /// </summary>"); //363:1
                __out.AppendLine(); //363:19
                string __tmp66Prefix = "    public virtual void "; //364:1
                string __tmp67Suffix = " @this)"; //364:81
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
                string __tmp69Line = "_"; //364:43
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
                string __tmp71Line = "("; //364:62
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
                        __out.AppendLine(); //364:88
                    }
                }
                __out.Append("    {"); //365:1
                __out.AppendLine(); //365:6
                __out.Append("    }"); //366:1
                __out.AppendLine(); //366:6
                var __loop33_results = 
                    (from __loop33_var1 in __Enumerate((cls).GetEnumerator()) //367:11
                    from prop in __Enumerate((__loop33_var1.Properties).GetEnumerator()) //367:16
                    select new { __loop33_var1 = __loop33_var1, prop = prop}
                    ).ToList(); //367:6
                int __loop33_iteration = 0;
                foreach (var __tmp73 in __loop33_results)
                {
                    ++__loop33_iteration;
                    var __loop33_var1 = __tmp73.__loop33_var1;
                    var prop = __tmp73.prop;
                    if (prop.Kind == MetaPropertyKind.Derived) //368:3
                    {
                        __out.AppendLine(); //369:2
                        __out.Append("    /// <summary>"); //370:1
                        __out.AppendLine(); //370:18
                        string __tmp74Prefix = "    /// Returns the value of the derived property: "; //371:1
                        string __tmp75Suffix = string.Empty; 
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
                                __out.Append(__tmp74Prefix);
                                __out.Append(__tmp76Line);
                            }
                        }
                        string __tmp77Line = "."; //371:70
                        __out.Append(__tmp77Line);
                        StringBuilder __tmp78 = new StringBuilder();
                        __tmp78.Append(prop.Name);
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
                                __out.AppendLine(); //371:82
                            }
                        }
                        __out.Append("    /// </summary>"); //372:1
                        __out.AppendLine(); //372:19
                        string __tmp79Prefix = "    public virtual "; //373:1
                        string __tmp80Suffix = " @this)"; //373:100
                        StringBuilder __tmp81 = new StringBuilder();
                        __tmp81.Append(prop.Type.CSharpPublicName());
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
                                __out.Append(__tmp79Prefix);
                                __out.Append(__tmp81Line);
                            }
                        }
                        string __tmp82Line = " "; //373:50
                        __out.Append(__tmp82Line);
                        StringBuilder __tmp83 = new StringBuilder();
                        __tmp83.Append(cls.CSharpName());
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
                                __out.Append(__tmp83Line);
                            }
                        }
                        string __tmp84Line = "_"; //373:69
                        __out.Append(__tmp84Line);
                        StringBuilder __tmp85 = new StringBuilder();
                        __tmp85.Append(prop.Name);
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
                            }
                        }
                        string __tmp86Line = "("; //373:81
                        __out.Append(__tmp86Line);
                        StringBuilder __tmp87 = new StringBuilder();
                        __tmp87.Append(cls.CSharpName());
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
                                __out.Append(__tmp87Line);
                                __out.Append(__tmp80Suffix);
                                __out.AppendLine(); //373:107
                            }
                        }
                        __out.Append("    {"); //374:1
                        __out.AppendLine(); //374:6
                        __out.Append("        throw new NotImplementedException();"); //375:1
                        __out.AppendLine(); //375:45
                        __out.Append("    }"); //376:1
                        __out.AppendLine(); //376:6
                    }
                    else if (prop.Kind == MetaPropertyKind.Lazy) //377:3
                    {
                        __out.AppendLine(); //378:2
                        __out.Append("    /// <summary>"); //379:1
                        __out.AppendLine(); //379:18
                        string __tmp88Prefix = "    /// Returns the value of the lazy property: "; //380:1
                        string __tmp89Suffix = string.Empty; 
                        StringBuilder __tmp90 = new StringBuilder();
                        __tmp90.Append(cls.CSharpName());
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
                                __out.Append(__tmp88Prefix);
                                __out.Append(__tmp90Line);
                            }
                        }
                        string __tmp91Line = "."; //380:67
                        __out.Append(__tmp91Line);
                        StringBuilder __tmp92 = new StringBuilder();
                        __tmp92.Append(prop.Name);
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
                                __out.Append(__tmp89Suffix);
                                __out.AppendLine(); //380:79
                            }
                        }
                        __out.Append("    /// </summary>"); //381:1
                        __out.AppendLine(); //381:19
                        string __tmp93Prefix = "    public virtual "; //382:1
                        string __tmp94Suffix = " @this)"; //382:100
                        StringBuilder __tmp95 = new StringBuilder();
                        __tmp95.Append(prop.Type.CSharpPublicName());
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
                        string __tmp96Line = " "; //382:50
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
                        string __tmp98Line = "_"; //382:69
                        __out.Append(__tmp98Line);
                        StringBuilder __tmp99 = new StringBuilder();
                        __tmp99.Append(prop.Name);
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
                        string __tmp100Line = "("; //382:81
                        __out.Append(__tmp100Line);
                        StringBuilder __tmp101 = new StringBuilder();
                        __tmp101.Append(cls.CSharpName());
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
                                __out.Append(__tmp94Suffix);
                                __out.AppendLine(); //382:107
                            }
                        }
                        __out.Append("    {"); //383:1
                        __out.AppendLine(); //383:6
                        __out.Append("        throw new NotImplementedException();"); //384:1
                        __out.AppendLine(); //384:45
                        __out.Append("    }"); //385:1
                        __out.AppendLine(); //385:6
                    }
                }
                var __loop34_results = 
                    (from __loop34_var1 in __Enumerate((cls).GetEnumerator()) //388:11
                    from op in __Enumerate((__loop34_var1.Operations).GetEnumerator()) //388:16
                    select new { __loop34_var1 = __loop34_var1, op = op}
                    ).ToList(); //388:6
                int __loop34_iteration = 0;
                foreach (var __tmp102 in __loop34_results)
                {
                    ++__loop34_iteration;
                    var __loop34_var1 = __tmp102.__loop34_var1;
                    var op = __tmp102.op;
                    __out.AppendLine(); //389:2
                    __out.Append("    /// <summary>"); //390:1
                    __out.AppendLine(); //390:18
                    string __tmp103Prefix = "    /// Implements the operation: "; //391:1
                    string __tmp104Suffix = "()"; //391:63
                    StringBuilder __tmp105 = new StringBuilder();
                    __tmp105.Append(cls.CSharpName());
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
                            __out.Append(__tmp103Prefix);
                            __out.Append(__tmp105Line);
                        }
                    }
                    string __tmp106Line = "."; //391:53
                    __out.Append(__tmp106Line);
                    StringBuilder __tmp107 = new StringBuilder();
                    __tmp107.Append(op.Name);
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
                            __out.Append(__tmp104Suffix);
                            __out.AppendLine(); //391:65
                        }
                    }
                    __out.Append("    /// </summary>"); //392:1
                    __out.AppendLine(); //392:19
                    string __tmp108Prefix = "    public virtual "; //393:1
                    string __tmp109Suffix = ")"; //393:112
                    StringBuilder __tmp110 = new StringBuilder();
                    __tmp110.Append(op.ReturnType.CSharpPublicName());
                    using(StreamReader __tmp110Reader = new StreamReader(this.__ToStream(__tmp110.ToString())))
                    {
                        bool __tmp110_first = true;
                        while(__tmp110_first || !__tmp110Reader.EndOfStream)
                        {
                            __tmp110_first = false;
                            string __tmp110Line = __tmp110Reader.ReadLine();
                            if (__tmp110Line == null)
                            {
                                __tmp110Line = "";
                            }
                            __out.Append(__tmp108Prefix);
                            __out.Append(__tmp110Line);
                        }
                    }
                    string __tmp111Line = " "; //393:54
                    __out.Append(__tmp111Line);
                    StringBuilder __tmp112 = new StringBuilder();
                    __tmp112.Append(cls.CSharpName());
                    using(StreamReader __tmp112Reader = new StreamReader(this.__ToStream(__tmp112.ToString())))
                    {
                        bool __tmp112_first = true;
                        while(__tmp112_first || !__tmp112Reader.EndOfStream)
                        {
                            __tmp112_first = false;
                            string __tmp112Line = __tmp112Reader.ReadLine();
                            if (__tmp112Line == null)
                            {
                                __tmp112Line = "";
                            }
                            __out.Append(__tmp112Line);
                        }
                    }
                    string __tmp113Line = "_"; //393:73
                    __out.Append(__tmp113Line);
                    StringBuilder __tmp114 = new StringBuilder();
                    __tmp114.Append(op.Name);
                    using(StreamReader __tmp114Reader = new StreamReader(this.__ToStream(__tmp114.ToString())))
                    {
                        bool __tmp114_first = true;
                        while(__tmp114_first || !__tmp114Reader.EndOfStream)
                        {
                            __tmp114_first = false;
                            string __tmp114Line = __tmp114Reader.ReadLine();
                            if (__tmp114Line == null)
                            {
                                __tmp114Line = "";
                            }
                            __out.Append(__tmp114Line);
                        }
                    }
                    string __tmp115Line = "("; //393:83
                    __out.Append(__tmp115Line);
                    StringBuilder __tmp116 = new StringBuilder();
                    __tmp116.Append(GetImplParameters(cls, op));
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
                            __out.Append(__tmp116Line);
                            __out.Append(__tmp109Suffix);
                            __out.AppendLine(); //393:113
                        }
                    }
                    __out.Append("    {"); //394:1
                    __out.AppendLine(); //394:6
                    __out.Append("        throw new NotImplementedException();"); //395:1
                    __out.AppendLine(); //395:45
                    __out.Append("    }"); //396:1
                    __out.AppendLine(); //396:6
                }
                __out.AppendLine(); //398:2
            }
            var __loop35_results = 
                (from __loop35_var1 in __Enumerate((model).GetEnumerator()) //400:8
                from Types in __Enumerate((__loop35_var1.Types).GetEnumerator()) //400:15
                from enm in __Enumerate((Types).GetEnumerator()).OfType<MetaEnum>() //400:22
                select new { __loop35_var1 = __loop35_var1, Types = Types, enm = enm}
                ).ToList(); //400:3
            int __loop35_iteration = 0;
            foreach (var __tmp117 in __loop35_results)
            {
                ++__loop35_iteration;
                var __loop35_var1 = __tmp117.__loop35_var1;
                var Types = __tmp117.Types;
                var enm = __tmp117.enm;
                var __loop36_results = 
                    (from __loop36_var1 in __Enumerate((enm).GetEnumerator()) //401:11
                    from op in __Enumerate((__loop36_var1.Operations).GetEnumerator()) //401:16
                    select new { __loop36_var1 = __loop36_var1, op = op}
                    ).ToList(); //401:6
                int __loop36_iteration = 0;
                foreach (var __tmp118 in __loop36_results)
                {
                    ++__loop36_iteration;
                    var __loop36_var1 = __tmp118.__loop36_var1;
                    var op = __tmp118.op;
                    __out.AppendLine(); //402:2
                    __out.Append("    /// <summary>"); //403:1
                    __out.AppendLine(); //403:18
                    string __tmp119Prefix = "    /// Implements the operation: "; //404:1
                    string __tmp120Suffix = string.Empty; 
                    StringBuilder __tmp121 = new StringBuilder();
                    __tmp121.Append(enm.CSharpName());
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
                            __out.Append(__tmp119Prefix);
                            __out.Append(__tmp121Line);
                        }
                    }
                    string __tmp122Line = "."; //404:53
                    __out.Append(__tmp122Line);
                    StringBuilder __tmp123 = new StringBuilder();
                    __tmp123.Append(op.Name);
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
                            __out.Append(__tmp120Suffix);
                            __out.AppendLine(); //404:63
                        }
                    }
                    __out.Append("    /// </summary>"); //405:1
                    __out.AppendLine(); //405:19
                    string __tmp124Prefix = "    public virtual "; //406:1
                    string __tmp125Suffix = ")"; //406:112
                    StringBuilder __tmp126 = new StringBuilder();
                    __tmp126.Append(op.ReturnType.CSharpPublicName());
                    using(StreamReader __tmp126Reader = new StreamReader(this.__ToStream(__tmp126.ToString())))
                    {
                        bool __tmp126_first = true;
                        while(__tmp126_first || !__tmp126Reader.EndOfStream)
                        {
                            __tmp126_first = false;
                            string __tmp126Line = __tmp126Reader.ReadLine();
                            if (__tmp126Line == null)
                            {
                                __tmp126Line = "";
                            }
                            __out.Append(__tmp124Prefix);
                            __out.Append(__tmp126Line);
                        }
                    }
                    string __tmp127Line = " "; //406:54
                    __out.Append(__tmp127Line);
                    StringBuilder __tmp128 = new StringBuilder();
                    __tmp128.Append(enm.CSharpName());
                    using(StreamReader __tmp128Reader = new StreamReader(this.__ToStream(__tmp128.ToString())))
                    {
                        bool __tmp128_first = true;
                        while(__tmp128_first || !__tmp128Reader.EndOfStream)
                        {
                            __tmp128_first = false;
                            string __tmp128Line = __tmp128Reader.ReadLine();
                            if (__tmp128Line == null)
                            {
                                __tmp128Line = "";
                            }
                            __out.Append(__tmp128Line);
                        }
                    }
                    string __tmp129Line = "_"; //406:73
                    __out.Append(__tmp129Line);
                    StringBuilder __tmp130 = new StringBuilder();
                    __tmp130.Append(op.Name);
                    using(StreamReader __tmp130Reader = new StreamReader(this.__ToStream(__tmp130.ToString())))
                    {
                        bool __tmp130_first = true;
                        while(__tmp130_first || !__tmp130Reader.EndOfStream)
                        {
                            __tmp130_first = false;
                            string __tmp130Line = __tmp130Reader.ReadLine();
                            if (__tmp130Line == null)
                            {
                                __tmp130Line = "";
                            }
                            __out.Append(__tmp130Line);
                        }
                    }
                    string __tmp131Line = "("; //406:83
                    __out.Append(__tmp131Line);
                    StringBuilder __tmp132 = new StringBuilder();
                    __tmp132.Append(GetImplParameters(enm, op));
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
                            __out.Append(__tmp132Line);
                            __out.Append(__tmp125Suffix);
                            __out.AppendLine(); //406:113
                        }
                    }
                    __out.Append("    {"); //407:1
                    __out.AppendLine(); //407:6
                    __out.Append("        throw new NotImplementedException();"); //408:1
                    __out.AppendLine(); //408:45
                    __out.Append("    }"); //409:1
                    __out.AppendLine(); //409:6
                }
                __out.AppendLine(); //411:2
            }
            __out.Append("}"); //413:1
            __out.AppendLine(); //413:2
            __out.AppendLine(); //414:2
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //417:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //418:1
            __out.AppendLine(); //418:14
            __out.Append("/// Factory class for creating instances of model elements."); //419:1
            __out.AppendLine(); //419:60
            __out.Append("/// </summary>"); //420:1
            __out.AppendLine(); //420:15
            string __tmp1Prefix = "public class "; //421:1
            string __tmp2Suffix = "Factory : ModelFactory"; //421:26
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
                    __out.AppendLine(); //421:48
                }
            }
            __out.Append("{"); //422:1
            __out.AppendLine(); //422:2
            string __tmp4Prefix = "    private static "; //423:1
            string __tmp5Suffix = "Factory();"; //423:67
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
            string __tmp7Line = "Factory instance = new "; //423:32
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
                    __out.AppendLine(); //423:77
                }
            }
            __out.AppendLine(); //424:2
            string __tmp9Prefix = "	private "; //425:1
            string __tmp10Suffix = "Factory()"; //425:22
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
                    __out.AppendLine(); //425:31
                }
            }
            __out.Append("	{"); //426:1
            __out.AppendLine(); //426:3
            __out.Append("	}"); //427:1
            __out.AppendLine(); //427:3
            __out.AppendLine(); //428:2
            __out.Append("    /// <summary>"); //429:1
            __out.AppendLine(); //429:18
            __out.Append("    /// The singleton instance of the factory."); //430:1
            __out.AppendLine(); //430:47
            __out.Append("    /// </summary>"); //431:1
            __out.AppendLine(); //431:19
            string __tmp12Prefix = "    public static "; //432:1
            string __tmp13Suffix = "Factory Instance"; //432:31
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
                    __out.AppendLine(); //432:47
                }
            }
            __out.Append("    {"); //433:1
            __out.AppendLine(); //433:6
            string __tmp15Prefix = "        get { return "; //434:1
            string __tmp16Suffix = "Factory.instance; }"; //434:34
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
                    __out.AppendLine(); //434:53
                }
            }
            __out.Append("    }"); //435:1
            __out.AppendLine(); //435:6
            var __loop37_results = 
                (from __loop37_var1 in __Enumerate((model).GetEnumerator()) //436:8
                from Types in __Enumerate((__loop37_var1.Types).GetEnumerator()) //436:15
                from cls in __Enumerate((Types).GetEnumerator()).OfType<MetaClass>() //436:22
                select new { __loop37_var1 = __loop37_var1, Types = Types, cls = cls}
                ).ToList(); //436:3
            int __loop37_iteration = 0;
            foreach (var __tmp18 in __loop37_results)
            {
                ++__loop37_iteration;
                var __loop37_var1 = __tmp18.__loop37_var1;
                var Types = __tmp18.Types;
                var cls = __tmp18.cls;
                __out.AppendLine(); //437:2
                __out.Append("    /// <summary>"); //438:1
                __out.AppendLine(); //438:18
                string __tmp19Prefix = "    /// Creates a new instance of "; //439:1
                string __tmp20Suffix = "."; //439:53
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
                        __out.AppendLine(); //439:54
                    }
                }
                __out.Append("    /// </summary>"); //440:1
                __out.AppendLine(); //440:19
                string __tmp22Prefix = "    public "; //441:1
                string __tmp23Suffix = "()"; //441:55
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
                string __tmp25Line = " Create"; //441:30
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
                        __out.AppendLine(); //441:57
                    }
                }
                __out.Append("	{"); //442:1
                __out.AppendLine(); //442:3
                string __tmp27Prefix = "		"; //443:1
                string __tmp28Suffix = "();"; //443:57
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
                string __tmp30Line = " result = new "; //443:21
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
                        __out.AppendLine(); //443:60
                    }
                }
                __out.Append("		return result;"); //444:1
                __out.AppendLine(); //444:17
                __out.Append("	}"); //445:1
                __out.AppendLine(); //445:3
                __out.AppendLine(); //446:2
            }
            __out.Append("}"); //448:1
            __out.AppendLine(); //448:2
            __out.AppendLine(); //449:2
            return __out.ToString();
        }

    }
}

