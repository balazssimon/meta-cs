using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core //1:1
{
    using __Hidden_MetaModelGenerator_1724766253;
    namespace __Hidden_MetaModelGenerator_1724766253
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
        private IEnumerable<MetaNamespace> Instances; //2:1
        public MetaModelGenerator(IEnumerable<MetaNamespace> instances) //2:1
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
                (from ns in __Enumerate((Instances).GetEnumerator()) //12:8
                select new { ns = ns}
                ).ToList(); //12:3
            int __loop1_iteration = 0;
            foreach (var __tmp1 in __loop1_results)
            {
                ++__loop1_iteration;
                var ns = __tmp1.ns;
                string __tmp2Prefix = string.Empty;
                string __tmp3Suffix = string.Empty;
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append(GenerateNamespace(ns));
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

        public string GenerateNamespace(MetaNamespace ns) //17:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "namespace "; //18:1
            string __tmp2Suffix = string.Empty; 
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(ns.Name);
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
                    __out.AppendLine(); //18:20
                }
            }
            __out.Append("{"); //19:1
            __out.AppendLine(); //19:2
            var __loop2_results = 
                (from __loop2_var1 in __Enumerate((ns).GetEnumerator()) //20:8
                from model in __Enumerate((__loop2_var1.Models).GetEnumerator()) //20:12
                select new { __loop2_var1 = __loop2_var1, model = model}
                ).ToList(); //20:3
            int __loop2_iteration = 0;
            foreach (var __tmp4 in __loop2_results)
            {
                ++__loop2_iteration;
                var __loop2_var1 = __tmp4.__loop2_var1;
                var model = __tmp4.model;
                var __loop3_results = 
                    (from __loop3_var1 in __Enumerate((model).GetEnumerator()) //21:9
                    from Types in __Enumerate((__loop3_var1.Types).GetEnumerator()) //21:16
                    from enm in __Enumerate((Types).GetEnumerator()).OfType<MetaEnum>() //21:23
                    select new { __loop3_var1 = __loop3_var1, Types = Types, enm = enm}
                    ).ToList(); //21:4
                int __loop3_iteration = 0;
                foreach (var __tmp5 in __loop3_results)
                {
                    ++__loop3_iteration;
                    var __loop3_var1 = __tmp5.__loop3_var1;
                    var Types = __tmp5.Types;
                    var enm = __tmp5.enm;
                    string __tmp6Prefix = "    "; //22:1
                    string __tmp7Suffix = string.Empty; 
                    StringBuilder __tmp8 = new StringBuilder();
                    __tmp8.Append(GenerateEnum(enm));
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
                            __out.AppendLine(); //22:24
                        }
                    }
                }
                var __loop4_results = 
                    (from __loop4_var1 in __Enumerate((model).GetEnumerator()) //24:9
                    from Types in __Enumerate((__loop4_var1.Types).GetEnumerator()) //24:16
                    from cls in __Enumerate((Types).GetEnumerator()).OfType<MetaClass>() //24:23
                    select new { __loop4_var1 = __loop4_var1, Types = Types, cls = cls}
                    ).ToList(); //24:4
                int __loop4_iteration = 0;
                foreach (var __tmp9 in __loop4_results)
                {
                    ++__loop4_iteration;
                    var __loop4_var1 = __tmp9.__loop4_var1;
                    var Types = __tmp9.Types;
                    var cls = __tmp9.cls;
                    string __tmp10Prefix = "    "; //25:1
                    string __tmp11Suffix = string.Empty; 
                    StringBuilder __tmp12 = new StringBuilder();
                    __tmp12.Append(GenerateInterface(cls));
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
                            __out.AppendLine(); //25:29
                        }
                    }
                    string __tmp13Prefix = "    "; //26:1
                    string __tmp14Suffix = string.Empty; 
                    StringBuilder __tmp15 = new StringBuilder();
                    __tmp15.Append(GenerateInterfaceImpl(model, cls));
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
                            __out.AppendLine(); //26:40
                        }
                    }
                }
                string __tmp16Prefix = "    "; //28:1
                string __tmp17Suffix = string.Empty; 
                StringBuilder __tmp18 = new StringBuilder();
                __tmp18.Append(GenerateFactory(model));
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
                        __out.AppendLine(); //28:29
                    }
                }
                string __tmp19Prefix = "    "; //29:1
                string __tmp20Suffix = string.Empty; 
                StringBuilder __tmp21 = new StringBuilder();
                __tmp21.Append(GenerateImplementationProvider(model));
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
                        __out.AppendLine(); //29:44
                    }
                }
            }
            __out.Append("}"); //31:1
            __out.AppendLine(); //31:2
            return __out.ToString();
        }

        public string GenerateEnum(MetaEnum enm) //34:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public enum "; //35:1
            string __tmp2Suffix = string.Empty; 
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(enm.Name);
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
                    __out.AppendLine(); //35:23
                }
            }
            __out.Append("{"); //36:1
            __out.AppendLine(); //36:2
            var __loop5_results = 
                (from __loop5_var1 in __Enumerate((enm).GetEnumerator()) //37:11
                from value in __Enumerate((__loop5_var1.EnumLiterals).GetEnumerator()) //37:16
                select new { __loop5_var1 = __loop5_var1, value = value}
                ).ToList(); //37:6
            int __loop5_iteration = 0;
            foreach (var __tmp4 in __loop5_results)
            {
                ++__loop5_iteration;
                var __loop5_var1 = __tmp4.__loop5_var1;
                var value = __tmp4.value;
                string __tmp5Prefix = "    "; //38:1
                string __tmp6Suffix = ","; //38:12
                StringBuilder __tmp7 = new StringBuilder();
                __tmp7.Append(value);
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
                        __out.AppendLine(); //38:13
                    }
                }
            }
            __out.Append("}"); //40:1
            __out.AppendLine(); //40:2
            __out.AppendLine(); //41:2
            return __out.ToString();
        }

        public string GetAncestors(MetaClass cls) //44:1
        {
            string result = ""; //45:2
            string nsName = cls.Namespace.CSharpPrefix(); //46:2
            var __loop6_results = 
                (from __loop6_var1 in __Enumerate((cls).GetEnumerator()) //47:7
                from super in __Enumerate((__loop6_var1.SuperClasses).GetEnumerator()) //47:12
                select new { __loop6_var1 = __loop6_var1, super = super}
                ).ToList(); //47:2
            int __loop6_iteration = 0;
            string delim = " : "; //47:32
            foreach (var __tmp1 in __loop6_results)
            {
                ++__loop6_iteration;
                if (__loop6_iteration >= 2) //47:54
                {
                    delim = ", "; //47:54
                }
                var __loop6_var1 = __tmp1.__loop6_var1;
                var super = __tmp1.super;
                result += delim + nsName + super.Name; //48:3
            }
            return result; //50:2
        }

        public string GenerateInterface(MetaClass cls) //53:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public interface "; //54:1
            string __tmp2Suffix = string.Empty; 
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.Name);
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
                    __out.AppendLine(); //54:47
                }
            }
            __out.Append("{"); //55:1
            __out.AppendLine(); //55:2
            var __loop7_results = 
                (from __loop7_var1 in __Enumerate((cls).GetEnumerator()) //56:11
                from prop in __Enumerate((__loop7_var1.Properties).GetEnumerator()) //56:16
                select new { __loop7_var1 = __loop7_var1, prop = prop}
                ).ToList(); //56:6
            int __loop7_iteration = 0;
            foreach (var __tmp5 in __loop7_results)
            {
                ++__loop7_iteration;
                var __loop7_var1 = __tmp5.__loop7_var1;
                var prop = __tmp5.prop;
                string __tmp6Prefix = "    "; //57:1
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
                        __out.AppendLine(); //57:29
                    }
                }
            }
            __out.AppendLine(); //59:2
            var __loop8_results = 
                (from __loop8_var1 in __Enumerate((cls).GetEnumerator()) //60:11
                from op in __Enumerate((__loop8_var1.Operations).GetEnumerator()) //60:16
                select new { __loop8_var1 = __loop8_var1, op = op}
                ).ToList(); //60:6
            int __loop8_iteration = 0;
            foreach (var __tmp9 in __loop8_results)
            {
                ++__loop8_iteration;
                var __loop8_var1 = __tmp9.__loop8_var1;
                var op = __tmp9.op;
                string __tmp10Prefix = "    "; //61:1
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
                        __out.AppendLine(); //61:28
                    }
                }
            }
            __out.Append("}"); //63:1
            __out.AppendLine(); //63:2
            __out.AppendLine(); //64:2
            return __out.ToString();
        }

        public string GenerateProperty(MetaProperty prop) //67:1
        {
            StringBuilder __out = new StringBuilder();
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //68:3
            {
                string __tmp1Prefix = string.Empty; 
                string __tmp2Suffix = " { get; set; }"; //69:43
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
                string __tmp4Line = " "; //69:31
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
                        __out.AppendLine(); //69:57
                    }
                }
            }
            else //70:3
            {
                string __tmp6Prefix = string.Empty; 
                string __tmp7Suffix = " { get; }"; //71:43
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
                string __tmp9Line = " "; //71:31
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
                        __out.AppendLine(); //71:52
                    }
                }
            }
            return __out.ToString();
        }

        public string GetParameters(MetaOperation op, bool defaultValues) //75:1
        {
            string result = ""; //76:2
            var __loop9_results = 
                (from __loop9_var1 in __Enumerate((op).GetEnumerator()) //77:7
                from param in __Enumerate((__loop9_var1.Parameters).GetEnumerator()) //77:11
                select new { __loop9_var1 = __loop9_var1, param = param}
                ).ToList(); //77:2
            int __loop9_iteration = 0;
            string delim = ""; //77:29
            foreach (var __tmp1 in __loop9_results)
            {
                ++__loop9_iteration;
                if (__loop9_iteration >= 2) //77:48
                {
                    delim = ", "; //77:48
                }
                var __loop9_var1 = __tmp1.__loop9_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpPublicName() + " " + param.Name; //78:3
                if (defaultValues && param.DefaultValue != null) //79:3
                {
                    result += " = " + param.DefaultValue; //80:4
                }
            }
            return result; //83:2
        }

        public string GetImplParameters(MetaClass cls, MetaOperation op) //86:1
        {
            string result = cls.CSharpName() + " @this"; //87:2
            string delim = ", "; //88:2
            var __loop10_results = 
                (from __loop10_var1 in __Enumerate((op).GetEnumerator()) //89:7
                from param in __Enumerate((__loop10_var1.Parameters).GetEnumerator()) //89:11
                select new { __loop10_var1 = __loop10_var1, param = param}
                ).ToList(); //89:2
            int __loop10_iteration = 0;
            foreach (var __tmp1 in __loop10_results)
            {
                ++__loop10_iteration;
                var __loop10_var1 = __tmp1.__loop10_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpPublicName() + " " + param.Name; //90:3
            }
            return result; //92:2
        }

        public string GetImplParameters(MetaEnum enm, MetaOperation op) //95:1
        {
            string result = enm.CSharpName() + " @this"; //96:2
            string delim = ", "; //97:2
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((op).GetEnumerator()) //98:7
                from param in __Enumerate((__loop11_var1.Parameters).GetEnumerator()) //98:11
                select new { __loop11_var1 = __loop11_var1, param = param}
                ).ToList(); //98:2
            int __loop11_iteration = 0;
            foreach (var __tmp1 in __loop11_results)
            {
                ++__loop11_iteration;
                var __loop11_var1 = __tmp1.__loop11_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpPublicName() + " " + param.Name; //99:3
            }
            return result; //101:2
        }

        public string GetEnumImplParameters(MetaEnum enm, MetaOperation op) //104:1
        {
            string result = "this " + enm.CSharpName() + " @this"; //105:2
            string delim = ", "; //106:2
            var __loop12_results = 
                (from __loop12_var1 in __Enumerate((op).GetEnumerator()) //107:7
                from param in __Enumerate((__loop12_var1.Parameters).GetEnumerator()) //107:11
                select new { __loop12_var1 = __loop12_var1, param = param}
                ).ToList(); //107:2
            int __loop12_iteration = 0;
            foreach (var __tmp1 in __loop12_results)
            {
                ++__loop12_iteration;
                var __loop12_var1 = __tmp1.__loop12_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpPublicName() + " " + param.Name; //108:3
            }
            return result; //110:2
        }

        public string GetEnumImplCallParameterNames(MetaOperation op) //113:1
        {
            string result = "@this"; //114:2
            string delim = ", "; //115:2
            var __loop13_results = 
                (from __loop13_var1 in __Enumerate((op).GetEnumerator()) //116:7
                from param in __Enumerate((__loop13_var1.Parameters).GetEnumerator()) //116:11
                select new { __loop13_var1 = __loop13_var1, param = param}
                ).ToList(); //116:2
            int __loop13_iteration = 0;
            foreach (var __tmp1 in __loop13_results)
            {
                ++__loop13_iteration;
                var __loop13_var1 = __tmp1.__loop13_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //117:3
            }
            return result; //119:2
        }

        public string GetImplCallParameterNames(MetaOperation op) //122:1
        {
            string result = "this"; //123:2
            string delim = ", "; //124:2
            var __loop14_results = 
                (from __loop14_var1 in __Enumerate((op).GetEnumerator()) //125:7
                from param in __Enumerate((__loop14_var1.Parameters).GetEnumerator()) //125:11
                select new { __loop14_var1 = __loop14_var1, param = param}
                ).ToList(); //125:2
            int __loop14_iteration = 0;
            foreach (var __tmp1 in __loop14_results)
            {
                ++__loop14_iteration;
                var __loop14_var1 = __tmp1.__loop14_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //126:3
            }
            return result; //128:2
        }

        public string GenerateOperation(MetaOperation op) //131:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = ");"; //132:71
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
            string __tmp4Line = " "; //132:35
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
            string __tmp6Line = "("; //132:45
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
                    __out.AppendLine(); //132:73
                }
            }
            return __out.ToString();
        }

        public string GenerateInterfaceImpl(MetaModel model, MetaClass cls) //135:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "internal class "; //136:1
            string __tmp2Suffix = string.Empty; 
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.Name);
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
            string __tmp4Line = "Impl : ModelObject, "; //136:26
            __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(cls.Namespace.CSharpPrefix());
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
            __tmp6.Append(cls.Name);
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
                    __out.AppendLine(); //136:86
                }
            }
            __out.Append("{"); //137:1
            __out.AppendLine(); //137:2
            if ((from __loop15_var1 in __Enumerate((cls).GetEnumerator()) //138:14
            from sup in __Enumerate((__loop15_var1.GetAllSuperClasses(false)).GetEnumerator()) //138:19
            select new { __loop15_var1 = __loop15_var1, sup = sup}
            ).GetEnumerator().MoveNext()) //138:2
            {
                string __tmp7Prefix = "    static "; //139:1
                string __tmp8Suffix = "Impl()"; //139:22
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append(cls.Name);
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
                        __out.AppendLine(); //139:28
                    }
                }
                __out.Append("    {"); //140:1
                __out.AppendLine(); //140:6
                var __loop16_results = 
                    (from __loop16_var1 in __Enumerate((cls).GetEnumerator()) //141:9
                    from sup in __Enumerate((__loop16_var1.GetAllSuperClasses(false)).GetEnumerator()) //141:14
                    select new { __loop16_var1 = __loop16_var1, sup = sup}
                    ).ToList(); //141:4
                int __loop16_iteration = 0;
                foreach (var __tmp10 in __loop16_results)
                {
                    ++__loop16_iteration;
                    var __loop16_var1 = __tmp10.__loop16_var1;
                    var sup = __tmp10.sup;
                    string __tmp11Prefix = "		"; //142:1
                    string __tmp12Suffix = "Impl.TriggerStaticInitialization();"; //142:13
                    StringBuilder __tmp13 = new StringBuilder();
                    __tmp13.Append(sup.Name);
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
                            __out.AppendLine(); //142:48
                        }
                    }
                }
                var __loop17_results = 
                    (from __loop17_var1 in __Enumerate((cls).GetEnumerator()) //144:9
                    from sup in __Enumerate((__loop17_var1.GetAllSuperClasses(false)).GetEnumerator()) //144:14
                    select new { __loop17_var1 = __loop17_var1, sup = sup}
                    ).ToList(); //144:4
                int __loop17_iteration = 0;
                foreach (var __tmp14 in __loop17_results)
                {
                    ++__loop17_iteration;
                    var __loop17_var1 = __tmp14.__loop17_var1;
                    var sup = __tmp14.sup;
                    string __tmp15Prefix = "		ModelProperty.RegisterAncestor(typeof("; //145:1
                    string __tmp16Suffix = "Impl));"; //145:75
                    StringBuilder __tmp17 = new StringBuilder();
                    __tmp17.Append(cls.Name);
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
                    string __tmp18Line = "Impl), typeof("; //145:51
                    __out.Append(__tmp18Line);
                    StringBuilder __tmp19 = new StringBuilder();
                    __tmp19.Append(sup.Name);
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
                            __out.AppendLine(); //145:82
                        }
                    }
                }
                __out.Append("    }"); //147:1
                __out.AppendLine(); //147:6
                __out.AppendLine(); //148:2
            }
            __out.Append("	public static void TriggerStaticInitialization()"); //150:1
            __out.AppendLine(); //150:50
            __out.Append("	{"); //151:1
            __out.AppendLine(); //151:3
            __out.Append("	}"); //152:1
            __out.AppendLine(); //152:3
            __out.AppendLine(); //153:2
            string __tmp20Prefix = "    "; //154:1
            string __tmp21Suffix = string.Empty; 
            StringBuilder __tmp22 = new StringBuilder();
            __tmp22.Append(GenerateConstructorImpl(model, cls));
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
                    __out.AppendLine(); //154:42
                }
            }
            var __loop18_results = 
                (from __loop18_var1 in __Enumerate((cls).GetEnumerator()) //155:11
                from prop in __Enumerate((__loop18_var1.GetAllProperties()).GetEnumerator()) //155:16
                select new { __loop18_var1 = __loop18_var1, prop = prop}
                ).ToList(); //155:6
            int __loop18_iteration = 0;
            foreach (var __tmp23 in __loop18_results)
            {
                ++__loop18_iteration;
                var __loop18_var1 = __tmp23.__loop18_var1;
                var prop = __tmp23.prop;
                string __tmp24Prefix = "    "; //156:1
                string __tmp25Suffix = string.Empty; 
                StringBuilder __tmp26 = new StringBuilder();
                __tmp26.Append(GeneratePropertyImpl(model, cls, prop));
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
                        __out.AppendLine(); //156:45
                    }
                }
            }
            var __loop19_results = 
                (from __loop19_var1 in __Enumerate((cls).GetEnumerator()) //158:11
                from op in __Enumerate((__loop19_var1.GetAllOperations()).GetEnumerator()) //158:16
                select new { __loop19_var1 = __loop19_var1, op = op}
                ).ToList(); //158:6
            int __loop19_iteration = 0;
            foreach (var __tmp27 in __loop19_results)
            {
                ++__loop19_iteration;
                var __loop19_var1 = __tmp27.__loop19_var1;
                var op = __tmp27.op;
                string __tmp28Prefix = "    "; //159:1
                string __tmp29Suffix = string.Empty; 
                StringBuilder __tmp30 = new StringBuilder();
                __tmp30.Append(GenerateOperationImpl(model, op));
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
                        __out.AppendLine(); //159:39
                    }
                }
            }
            __out.Append("}"); //161:1
            __out.AppendLine(); //161:2
            __out.AppendLine(); //162:2
            return __out.ToString();
        }

        public string GeneratePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //165:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //166:2
            if (prop.Class == cls) //167:2
            {
                if (prop.Kind == MetaPropertyKind.Containment) //168:2
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
                            __out.AppendLine(); //169:27
                        }
                    }
                }
                if (prop.Kind != MetaPropertyKind.Normal && prop.Kind != MetaPropertyKind.Containment && !(prop.Type is MetaCollectionType)) //171:2
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
                            __out.AppendLine(); //172:24
                        }
                    }
                }
                var __loop20_results = 
                    (from opp in __Enumerate((prop.Opposites).GetEnumerator()) //174:7
                    select new { opp = opp}
                    ).ToList(); //174:2
                int __loop20_iteration = 0;
                foreach (var __tmp7 in __loop20_results)
                {
                    ++__loop20_iteration;
                    var opp = __tmp7.opp;
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
                    __tmp11.Append(opp.Class.CSharpImplName());
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
                    StringBuilder __tmp12 = new StringBuilder();
                    __tmp12.Append("), \"");
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
                    StringBuilder __tmp13 = new StringBuilder();
                    __tmp13.Append(opp.Name);
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
                    __tmp14.Append("\")]");
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
                            __out.AppendLine(); //175:86
                        }
                    }
                }
                string __tmp15Prefix = "internal static readonly ModelProperty "; //177:1
                string __tmp16Suffix = "Property ="; //177:51
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(prop.Name);
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
                        __out.AppendLine(); //177:61
                    }
                }
                string __tmp18Prefix = "    ModelProperty.Register(\""; //178:1
                string __tmp19Suffix = "));"; //178:119
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
                        __out.Append(__tmp18Prefix);
                        __out.Append(__tmp20Line);
                    }
                }
                string __tmp21Line = "\", typeof("; //178:40
                __out.Append(__tmp21Line);
                StringBuilder __tmp22 = new StringBuilder();
                __tmp22.Append(prop.Type.CSharpPublicName());
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
                string __tmp23Line = "), typeof("; //178:80
                __out.Append(__tmp23Line);
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(prop.Class.CSharpImplName());
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
                        __out.AppendLine(); //178:122
                    }
                }
            }
            string __tmp25Prefix = "public "; //180:1
            string __tmp26Suffix = string.Empty; 
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
                }
            }
            string __tmp28Line = " "; //180:38
            __out.Append(__tmp28Line);
            StringBuilder __tmp29 = new StringBuilder();
            __tmp29.Append(prop.Name);
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
                    __out.AppendLine(); //180:50
                }
            }
            __out.Append("{"); //181:1
            __out.AppendLine(); //181:2
            if (prop.Kind == MetaPropertyKind.Derived) //182:3
            {
                string __tmp30Prefix = "    get { return "; //183:1
                string __tmp31Suffix = "(this); }"; //183:105
                StringBuilder __tmp32 = new StringBuilder();
                __tmp32.Append(model.CSharpName());
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
                string __tmp33Line = "ImplementationProvider.Implementation."; //183:38
                __out.Append(__tmp33Line);
                StringBuilder __tmp34 = new StringBuilder();
                __tmp34.Append(prop.Class.Name);
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
                string __tmp35Line = "_"; //183:93
                __out.Append(__tmp35Line);
                StringBuilder __tmp36 = new StringBuilder();
                __tmp36.Append(prop.Name);
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
                        __out.AppendLine(); //183:114
                    }
                }
            }
            else //184:3
            {
                string __tmp37Prefix = "    get { return ("; //185:1
                string __tmp38Suffix = "Property); }"; //185:106
                StringBuilder __tmp39 = new StringBuilder();
                __tmp39.Append(prop.Type.CSharpPublicName());
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
                string __tmp40Line = ")this.MGetValue("; //185:49
                __out.Append(__tmp40Line);
                StringBuilder __tmp41 = new StringBuilder();
                __tmp41.Append(prop.Class.CSharpImplName());
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
                string __tmp42Line = "."; //185:94
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
                        __out.Append(__tmp38Suffix);
                        __out.AppendLine(); //185:118
                    }
                }
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //187:3
            {
                string __tmp44Prefix = "    set { this.MSetValue("; //188:1
                string __tmp45Suffix = "Property, value); }"; //188:67
                StringBuilder __tmp46 = new StringBuilder();
                __tmp46.Append(prop.Class.CSharpImplName());
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
                string __tmp47Line = "."; //188:55
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
                        __out.Append(__tmp45Suffix);
                        __out.AppendLine(); //188:86
                    }
                }
            }
            __out.Append("}"); //190:1
            __out.AppendLine(); //190:2
            return __out.ToString();
        }

        public string GetCollectionConstructorParams(MetaProperty prop) //193:1
        {
            MetaCollectionType mct = prop.Type as MetaCollectionType; //194:2
            if (mct != null && mct.InnerType is MetaClass) //195:2
            {
                return "this, " + prop.Class.CSharpName() + "Impl." + prop.Name + "Property"; //196:3
            }
            else //197:2
            {
                return ""; //198:3
            }
        }

        public string GenerateConstructorImpl(MetaModel model, MetaClass cls) //202:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public "; //203:1
            string __tmp2Suffix = "Impl()"; //203:18
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.Name);
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
                    __out.AppendLine(); //203:24
                }
            }
            __out.Append("{"); //204:1
            __out.AppendLine(); //204:2
            var __loop21_results = 
                (from __loop21_var1 in __Enumerate((cls).GetEnumerator()) //205:8
                from prop in __Enumerate((__loop21_var1.GetAllProperties()).GetEnumerator()) //205:13
                select new { __loop21_var1 = __loop21_var1, prop = prop}
                ).ToList(); //205:3
            int __loop21_iteration = 0;
            foreach (var __tmp4 in __loop21_results)
            {
                ++__loop21_iteration;
                var __loop21_var1 = __tmp4.__loop21_var1;
                var prop = __tmp4.prop;
                if (prop.Type is MetaCollectionType) //206:4
                {
                    if (prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) //207:5
                    {
                        string __tmp5Prefix = "    this.MSetValue("; //208:1
                        string __tmp6Suffix = "));"; //208:138
                        StringBuilder __tmp7 = new StringBuilder();
                        __tmp7.Append(prop.Class.CSharpImplName());
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
                        string __tmp8Line = "."; //208:49
                        __out.Append(__tmp8Line);
                        StringBuilder __tmp9 = new StringBuilder();
                        __tmp9.Append(prop.Name);
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
                        string __tmp10Line = "Property, new "; //208:61
                        __out.Append(__tmp10Line);
                        StringBuilder __tmp11 = new StringBuilder();
                        __tmp11.Append(prop.Type.CSharpName());
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
                        string __tmp12Line = "("; //208:99
                        __out.Append(__tmp12Line);
                        StringBuilder __tmp13 = new StringBuilder();
                        __tmp13.Append(GetCollectionConstructorParams(prop));
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
                                __out.AppendLine(); //208:141
                            }
                        }
                    }
                    else if (prop.Kind == MetaPropertyKind.Lazy) //209:5
                    {
                        string __tmp14Prefix = "    this.MInitValue("; //210:1
                        string __tmp15Suffix = "(this));"; //210:165
                        StringBuilder __tmp16 = new StringBuilder();
                        __tmp16.Append(prop.Class.CSharpImplName());
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
                        string __tmp17Line = "."; //210:50
                        __out.Append(__tmp17Line);
                        StringBuilder __tmp18 = new StringBuilder();
                        __tmp18.Append(prop.Name);
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
                        string __tmp19Line = "Property, () => "; //210:62
                        __out.Append(__tmp19Line);
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
                                __out.Append(__tmp20Line);
                            }
                        }
                        string __tmp21Line = "ImplementationProvider.Implementation."; //210:98
                        __out.Append(__tmp21Line);
                        StringBuilder __tmp22 = new StringBuilder();
                        __tmp22.Append(prop.Class.Name);
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
                        string __tmp23Line = "_"; //210:153
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
                                __out.Append(__tmp15Suffix);
                                __out.AppendLine(); //210:173
                            }
                        }
                    }
                    else if (prop.Kind == MetaPropertyKind.Readonly) //211:5
                    {
                        string __tmp25Prefix = "    // Init "; //212:1
                        string __tmp26Suffix = string.Empty; 
                        StringBuilder __tmp27 = new StringBuilder();
                        __tmp27.Append(prop.Class.CSharpImplName());
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
                        string __tmp28Line = "."; //212:42
                        __out.Append(__tmp28Line);
                        StringBuilder __tmp29 = new StringBuilder();
                        __tmp29.Append(prop.Name);
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
                        string __tmp30Line = "Property in "; //212:54
                        __out.Append(__tmp30Line);
                        StringBuilder __tmp31 = new StringBuilder();
                        __tmp31.Append(model.CSharpName());
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
                        string __tmp32Line = "Implementation."; //212:86
                        __out.Append(__tmp32Line);
                        StringBuilder __tmp33 = new StringBuilder();
                        __tmp33.Append(cls.Name);
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
                        string __tmp34Line = "_"; //212:111
                        __out.Append(__tmp34Line);
                        StringBuilder __tmp35 = new StringBuilder();
                        __tmp35.Append(cls.Name);
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
                                __out.Append(__tmp26Suffix);
                                __out.AppendLine(); //212:122
                            }
                        }
                    }
                }
                else //214:7
                {
                    if (prop.Kind == MetaPropertyKind.Lazy) //215:5
                    {
                        string __tmp36Prefix = "    this.MInitValue("; //216:1
                        string __tmp37Suffix = "(this));"; //216:165
                        StringBuilder __tmp38 = new StringBuilder();
                        __tmp38.Append(prop.Class.CSharpImplName());
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
                        string __tmp39Line = "."; //216:50
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
                            }
                        }
                        string __tmp41Line = "Property, () => "; //216:62
                        __out.Append(__tmp41Line);
                        StringBuilder __tmp42 = new StringBuilder();
                        __tmp42.Append(model.CSharpName());
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
                        string __tmp43Line = "ImplementationProvider.Implementation."; //216:98
                        __out.Append(__tmp43Line);
                        StringBuilder __tmp44 = new StringBuilder();
                        __tmp44.Append(prop.Class.Name);
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
                        string __tmp45Line = "_"; //216:153
                        __out.Append(__tmp45Line);
                        StringBuilder __tmp46 = new StringBuilder();
                        __tmp46.Append(prop.Name);
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
                                __out.Append(__tmp37Suffix);
                                __out.AppendLine(); //216:173
                            }
                        }
                    }
                    else if (prop.Kind == MetaPropertyKind.Readonly) //217:5
                    {
                        string __tmp47Prefix = "    // Init "; //218:1
                        string __tmp48Suffix = string.Empty; 
                        StringBuilder __tmp49 = new StringBuilder();
                        __tmp49.Append(prop.Class.CSharpImplName());
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
                        string __tmp50Line = "."; //218:42
                        __out.Append(__tmp50Line);
                        StringBuilder __tmp51 = new StringBuilder();
                        __tmp51.Append(prop.Name);
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
                        string __tmp52Line = "Property in "; //218:54
                        __out.Append(__tmp52Line);
                        StringBuilder __tmp53 = new StringBuilder();
                        __tmp53.Append(model.CSharpName());
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
                            }
                        }
                        string __tmp54Line = "Implementation."; //218:86
                        __out.Append(__tmp54Line);
                        StringBuilder __tmp55 = new StringBuilder();
                        __tmp55.Append(cls.Name);
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
                        string __tmp56Line = "_"; //218:111
                        __out.Append(__tmp56Line);
                        StringBuilder __tmp57 = new StringBuilder();
                        __tmp57.Append(cls.Name);
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
                                __out.Append(__tmp48Suffix);
                                __out.AppendLine(); //218:122
                            }
                        }
                    }
                }
            }
            string __tmp58Prefix = "    "; //222:1
            string __tmp59Suffix = "(this);"; //222:88
            StringBuilder __tmp60 = new StringBuilder();
            __tmp60.Append(cls.Model.CSharpName());
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
                    __out.Append(__tmp58Prefix);
                    __out.Append(__tmp60Line);
                }
            }
            string __tmp61Line = "ImplementationProvider.Implementation."; //222:29
            __out.Append(__tmp61Line);
            StringBuilder __tmp62 = new StringBuilder();
            __tmp62.Append(cls.Name);
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
            string __tmp63Line = "_"; //222:77
            __out.Append(__tmp63Line);
            StringBuilder __tmp64 = new StringBuilder();
            __tmp64.Append(cls.Name);
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
                    __out.Append(__tmp59Suffix);
                    __out.AppendLine(); //222:95
                }
            }
            var __loop22_results = 
                (from __loop22_var1 in __Enumerate((cls).GetEnumerator()) //223:11
                from prop in __Enumerate((__loop22_var1.GetAllProperties()).GetEnumerator()) //223:16
                select new { __loop22_var1 = __loop22_var1, prop = prop}
                ).ToList(); //223:6
            int __loop22_iteration = 0;
            foreach (var __tmp65 in __loop22_results)
            {
                ++__loop22_iteration;
                var __loop22_var1 = __tmp65.__loop22_var1;
                var prop = __tmp65.prop;
                if (prop.Kind == MetaPropertyKind.Readonly) //224:4
                {
                    string __tmp66Prefix = "    if (!this.MIsSet("; //225:1
                    string __tmp67Suffix = "().\");"; //225:204
                    StringBuilder __tmp68 = new StringBuilder();
                    __tmp68.Append(prop.Class.CSharpImplName());
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
                    string __tmp69Line = "."; //225:51
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
                    string __tmp71Line = "Property)) throw new ModelException(\"Readonly property "; //225:63
                    __out.Append(__tmp71Line);
                    StringBuilder __tmp72 = new StringBuilder();
                    __tmp72.Append(prop.Class.CSharpImplName());
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
                    string __tmp73Line = "."; //225:147
                    __out.Append(__tmp73Line);
                    StringBuilder __tmp74 = new StringBuilder();
                    __tmp74.Append(prop.Name);
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
                    string __tmp75Line = "Property was not set in "; //225:159
                    __out.Append(__tmp75Line);
                    StringBuilder __tmp76 = new StringBuilder();
                    __tmp76.Append(cls.Name);
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
                    string __tmp77Line = "_"; //225:193
                    __out.Append(__tmp77Line);
                    StringBuilder __tmp78 = new StringBuilder();
                    __tmp78.Append(cls.Name);
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
                            __out.Append(__tmp67Suffix);
                            __out.AppendLine(); //225:210
                        }
                    }
                }
            }
            __out.Append("}"); //228:1
            __out.AppendLine(); //228:2
            return __out.ToString();
        }

        public string GetReturn(MetaOperation op) //231:1
        {
            if (op.ReturnType.Name == "void") //232:5
            {
                return ""; //233:3
            }
            else //234:2
            {
                return "return "; //235:3
            }
        }

        public string GenerateOperationImpl(MetaModel model, MetaOperation op) //239:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //240:2
            string __tmp1Prefix = "public "; //241:1
            string __tmp2Suffix = ")"; //241:79
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
            string __tmp4Line = " "; //241:42
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
            string __tmp6Line = "("; //241:52
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
                    __out.AppendLine(); //241:80
                }
            }
            __out.Append("{"); //242:1
            __out.AppendLine(); //242:2
            string __tmp8Prefix = "    "; //243:1
            string __tmp9Suffix = ");"; //243:135
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
            __tmp11.Append(model.CSharpName());
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
            string __tmp12Line = "ImplementationProvider.Implementation."; //243:40
            __out.Append(__tmp12Line);
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(op.Class.Name);
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
            string __tmp14Line = "_"; //243:93
            __out.Append(__tmp14Line);
            StringBuilder __tmp15 = new StringBuilder();
            __tmp15.Append(op.Name);
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
            string __tmp16Line = "("; //243:103
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
                    __out.AppendLine(); //243:137
                }
            }
            __out.Append("}"); //244:1
            __out.AppendLine(); //244:2
            return __out.ToString();
        }

        public string GetSuperClasses(MetaClass cls) //247:1
        {
            string result = ""; //248:2
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((cls).GetEnumerator()) //249:10
                from sup in __Enumerate((__loop23_var1.SuperClasses).GetEnumerator()) //249:15
                select new { __loop23_var1 = __loop23_var1, sup = sup}
                ).ToList(); //249:5
            int __loop23_iteration = 0;
            string delim = ""; //249:33
            foreach (var __tmp1 in __loop23_results)
            {
                ++__loop23_iteration;
                if (__loop23_iteration >= 2) //249:52
                {
                    delim = ", "; //249:52
                }
                var __loop23_var1 = __tmp1.__loop23_var1;
                var sup = __tmp1.sup;
                result += delim + sup.Name; //250:3
            }
            return result; //252:2
        }

        public string GetAllSuperClasses(MetaClass cls) //255:1
        {
            string result = ""; //256:2
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((cls).GetEnumerator()) //257:10
                from sup in __Enumerate((__loop24_var1.GetAllSuperClasses(false)).GetEnumerator()) //257:15
                select new { __loop24_var1 = __loop24_var1, sup = sup}
                ).ToList(); //257:5
            int __loop24_iteration = 0;
            string delim = ""; //257:46
            foreach (var __tmp1 in __loop24_results)
            {
                ++__loop24_iteration;
                if (__loop24_iteration >= 2) //257:65
                {
                    delim = ", "; //257:65
                }
                var __loop24_var1 = __tmp1.__loop24_var1;
                var sup = __tmp1.sup;
                result += delim + sup.Name; //258:3
            }
            return result; //260:2
        }

        public string GenerateImplementationProvider(MetaModel model) //263:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "internal static class "; //264:1
            string __tmp2Suffix = "ImplementationProvider"; //264:35
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
                    __out.AppendLine(); //264:57
                }
            }
            __out.Append("{"); //265:1
            __out.AppendLine(); //265:2
            string __tmp4Prefix = "    // If there is a compile error at this line, create a new class called "; //266:1
            string __tmp5Suffix = "Implementation"; //266:88
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
                    __out.AppendLine(); //266:102
                }
            }
            string __tmp7Prefix = "	// which is a subclass of "; //267:1
            string __tmp8Suffix = "ImplementationBase:"; //267:40
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
                    __out.AppendLine(); //267:59
                }
            }
            string __tmp10Prefix = "    private static "; //268:1
            string __tmp11Suffix = "Implementation();"; //268:80
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
                }
            }
            string __tmp13Line = "Implementation implementation = new "; //268:32
            __out.Append(__tmp13Line);
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
                    __out.Append(__tmp14Line);
                    __out.Append(__tmp11Suffix);
                    __out.AppendLine(); //268:97
                }
            }
            __out.AppendLine(); //269:2
            string __tmp15Prefix = "    public static "; //270:1
            string __tmp16Suffix = "Implementation Implementation"; //270:31
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
                    __out.AppendLine(); //270:60
                }
            }
            __out.Append("    {"); //271:1
            __out.AppendLine(); //271:6
            string __tmp18Prefix = "        get { return "; //272:1
            string __tmp19Suffix = "ImplementationProvider.implementation; }"; //272:34
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
                    __out.AppendLine(); //272:74
                }
            }
            __out.Append("    }"); //273:1
            __out.AppendLine(); //273:6
            __out.Append("}"); //274:1
            __out.AppendLine(); //274:2
            var __loop25_results = 
                (from __loop25_var1 in __Enumerate((model).GetEnumerator()) //275:8
                from Types in __Enumerate((__loop25_var1.Types).GetEnumerator()) //275:15
                from enm in __Enumerate((Types).GetEnumerator()).OfType<MetaEnum>() //275:22
                select new { __loop25_var1 = __loop25_var1, Types = Types, enm = enm}
                ).ToList(); //275:3
            int __loop25_iteration = 0;
            foreach (var __tmp21 in __loop25_results)
            {
                ++__loop25_iteration;
                var __loop25_var1 = __tmp21.__loop25_var1;
                var Types = __tmp21.Types;
                var enm = __tmp21.enm;
                __out.AppendLine(); //276:2
                string __tmp22Prefix = "public static class "; //277:1
                string __tmp23Suffix = "Extensions"; //277:43
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(model.Name);
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
                        __out.AppendLine(); //277:53
                    }
                }
                __out.Append("{"); //278:1
                __out.AppendLine(); //278:2
                var __loop26_results = 
                    (from __loop26_var1 in __Enumerate((enm).GetEnumerator()) //279:11
                    from op in __Enumerate((__loop26_var1.Operations).GetEnumerator()) //279:16
                    select new { __loop26_var1 = __loop26_var1, op = op}
                    ).ToList(); //279:6
                int __loop26_iteration = 0;
                foreach (var __tmp26 in __loop26_results)
                {
                    ++__loop26_iteration;
                    var __loop26_var1 = __tmp26.__loop26_var1;
                    var op = __tmp26.op;
                    string __tmp27Prefix = "    public static "; //280:1
                    string __tmp28Suffix = ")"; //280:96
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
                    string __tmp30Line = " "; //280:53
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
                    string __tmp32Line = "("; //280:63
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
                            __out.AppendLine(); //280:97
                        }
                    }
                    __out.Append("    {"); //281:1
                    __out.AppendLine(); //281:6
                    string __tmp34Prefix = "        "; //282:1
                    string __tmp35Suffix = ");"; //282:142
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
                    string __tmp38Line = "ImplementationProvider.Implementation."; //282:44
                    __out.Append(__tmp38Line);
                    StringBuilder __tmp39 = new StringBuilder();
                    __tmp39.Append(op.Enum.Name);
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
                    string __tmp40Line = "_"; //282:96
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
                    string __tmp42Line = "("; //282:106
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
                            __out.AppendLine(); //282:144
                        }
                    }
                    __out.Append("    }"); //283:1
                    __out.AppendLine(); //283:6
                }
                __out.Append("}"); //285:1
                __out.AppendLine(); //285:2
            }
            __out.AppendLine(); //287:2
            __out.Append("/// <summary>"); //288:1
            __out.AppendLine(); //288:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //289:1
            __out.AppendLine(); //289:68
            string __tmp44Prefix = "/// This class has to be be overriden in "; //290:1
            string __tmp45Suffix = "Implementation to provide custom"; //290:54
            StringBuilder __tmp46 = new StringBuilder();
            __tmp46.Append(model.Name);
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
                    __out.AppendLine(); //290:86
                }
            }
            __out.Append("/// implementation for the constructors, operations and property values."); //291:1
            __out.AppendLine(); //291:73
            __out.Append("/// </summary>"); //292:1
            __out.AppendLine(); //292:15
            string __tmp47Prefix = "internal abstract class "; //293:1
            string __tmp48Suffix = "ImplementationBase"; //293:37
            StringBuilder __tmp49 = new StringBuilder();
            __tmp49.Append(model.Name);
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
                    __out.AppendLine(); //293:55
                }
            }
            __out.Append("{"); //294:1
            __out.AppendLine(); //294:2
            string delim = ""; //295:3
            var __loop27_results = 
                (from __loop27_var1 in __Enumerate((model).GetEnumerator()) //296:8
                from Types in __Enumerate((__loop27_var1.Types).GetEnumerator()) //296:15
                from cls in __Enumerate((Types).GetEnumerator()).OfType<MetaClass>() //296:22
                select new { __loop27_var1 = __loop27_var1, Types = Types, cls = cls}
                ).ToList(); //296:3
            int __loop27_iteration = 0;
            foreach (var __tmp50 in __loop27_results)
            {
                ++__loop27_iteration;
                var __loop27_var1 = __tmp50.__loop27_var1;
                var Types = __tmp50.Types;
                var cls = __tmp50.cls;
                __out.Append("    /// <summary>"); //297:1
                __out.AppendLine(); //297:18
                string __tmp51Prefix = "	/// Implements the constructor: "; //298:1
                string __tmp52Suffix = "()"; //298:44
                StringBuilder __tmp53 = new StringBuilder();
                __tmp53.Append(cls.Name);
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
                        __out.AppendLine(); //298:46
                    }
                }
                if ((from __loop28_var1 in __Enumerate((cls).GetEnumerator()) //299:15
                from sup in __Enumerate((__loop28_var1.SuperClasses).GetEnumerator()) //299:20
                select new { __loop28_var1 = __loop28_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //299:3
                {
                    string __tmp54Prefix = "	/// Direct superclasses: "; //300:1
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
                            __out.AppendLine(); //300:49
                        }
                    }
                    string __tmp57Prefix = "	/// All superclasses: "; //301:1
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
                            __out.AppendLine(); //301:49
                        }
                    }
                }
                if ((from __loop29_var1 in __Enumerate((cls).GetEnumerator()) //303:15
                from prop in __Enumerate((__loop29_var1.GetAllProperties()).GetEnumerator()) //303:20
                where prop.Kind == MetaPropertyKind.Readonly //303:44
                select new { __loop29_var1 = __loop29_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //303:3
                {
                    __out.Append("    // Initializes the following readonly properties:"); //304:1
                    __out.AppendLine(); //304:54
                }
                var __loop30_results = 
                    (from __loop30_var1 in __Enumerate((cls).GetEnumerator()) //306:11
                    from prop in __Enumerate((__loop30_var1.GetAllProperties()).GetEnumerator()) //306:16
                    select new { __loop30_var1 = __loop30_var1, prop = prop}
                    ).ToList(); //306:6
                int __loop30_iteration = 0;
                foreach (var __tmp60 in __loop30_results)
                {
                    ++__loop30_iteration;
                    var __loop30_var1 = __tmp60.__loop30_var1;
                    var prop = __tmp60.prop;
                    if (prop.Kind == MetaPropertyKind.Readonly) //307:3
                    {
                        string __tmp61Prefix = "    ///    "; //308:1
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
                        string __tmp64Line = "."; //308:29
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
                                __out.AppendLine(); //308:41
                            }
                        }
                    }
                }
                __out.Append("    /// </summary>"); //311:1
                __out.AppendLine(); //311:19
                string __tmp66Prefix = "    public virtual void "; //312:1
                string __tmp67Suffix = " @this)"; //312:65
                StringBuilder __tmp68 = new StringBuilder();
                __tmp68.Append(cls.Name);
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
                string __tmp69Line = "_"; //312:35
                __out.Append(__tmp69Line);
                StringBuilder __tmp70 = new StringBuilder();
                __tmp70.Append(cls.Name);
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
                string __tmp71Line = "("; //312:46
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
                        __out.AppendLine(); //312:72
                    }
                }
                __out.Append("    {"); //313:1
                __out.AppendLine(); //313:6
                __out.Append("    }"); //314:1
                __out.AppendLine(); //314:6
                var __loop31_results = 
                    (from __loop31_var1 in __Enumerate((cls).GetEnumerator()) //315:11
                    from prop in __Enumerate((__loop31_var1.Properties).GetEnumerator()) //315:16
                    select new { __loop31_var1 = __loop31_var1, prop = prop}
                    ).ToList(); //315:6
                int __loop31_iteration = 0;
                foreach (var __tmp73 in __loop31_results)
                {
                    ++__loop31_iteration;
                    var __loop31_var1 = __tmp73.__loop31_var1;
                    var prop = __tmp73.prop;
                    if (prop.Kind == MetaPropertyKind.Derived) //316:3
                    {
                        __out.AppendLine(); //317:2
                        __out.Append("    /// <summary>"); //318:1
                        __out.AppendLine(); //318:18
                        string __tmp74Prefix = "    /// Returns the value of the derived property: "; //319:1
                        string __tmp75Suffix = string.Empty; 
                        StringBuilder __tmp76 = new StringBuilder();
                        __tmp76.Append(cls.Name);
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
                        string __tmp77Line = "."; //319:62
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
                                __out.AppendLine(); //319:74
                            }
                        }
                        __out.Append("    /// </summary>"); //320:1
                        __out.AppendLine(); //320:19
                        string __tmp79Prefix = "    public virtual "; //321:1
                        string __tmp80Suffix = " @this)"; //321:78
                        StringBuilder __tmp81 = new StringBuilder();
                        __tmp81.Append(prop.Type.CSharpName());
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
                        string __tmp82Line = " "; //321:44
                        __out.Append(__tmp82Line);
                        StringBuilder __tmp83 = new StringBuilder();
                        __tmp83.Append(cls.Name);
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
                        string __tmp84Line = "_"; //321:55
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
                        string __tmp86Line = "("; //321:67
                        __out.Append(__tmp86Line);
                        StringBuilder __tmp87 = new StringBuilder();
                        __tmp87.Append(cls.Name);
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
                                __out.AppendLine(); //321:85
                            }
                        }
                        __out.Append("    {"); //322:1
                        __out.AppendLine(); //322:6
                        __out.Append("        throw new NotImplementedException();"); //323:1
                        __out.AppendLine(); //323:45
                        __out.Append("    }"); //324:1
                        __out.AppendLine(); //324:6
                    }
                    else if (prop.Kind == MetaPropertyKind.Lazy) //325:3
                    {
                        __out.AppendLine(); //326:2
                        __out.Append("    /// <summary>"); //327:1
                        __out.AppendLine(); //327:18
                        string __tmp88Prefix = "    /// Returns the value of the lazy property: "; //328:1
                        string __tmp89Suffix = string.Empty; 
                        StringBuilder __tmp90 = new StringBuilder();
                        __tmp90.Append(cls.Name);
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
                        string __tmp91Line = "."; //328:59
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
                                __out.AppendLine(); //328:71
                            }
                        }
                        __out.Append("    /// </summary>"); //329:1
                        __out.AppendLine(); //329:19
                        string __tmp93Prefix = "    public virtual "; //330:1
                        string __tmp94Suffix = " @this)"; //330:78
                        StringBuilder __tmp95 = new StringBuilder();
                        __tmp95.Append(prop.Type.CSharpName());
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
                        string __tmp96Line = " "; //330:44
                        __out.Append(__tmp96Line);
                        StringBuilder __tmp97 = new StringBuilder();
                        __tmp97.Append(cls.Name);
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
                        string __tmp98Line = "_"; //330:55
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
                        string __tmp100Line = "("; //330:67
                        __out.Append(__tmp100Line);
                        StringBuilder __tmp101 = new StringBuilder();
                        __tmp101.Append(cls.Name);
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
                                __out.AppendLine(); //330:85
                            }
                        }
                        __out.Append("    {"); //331:1
                        __out.AppendLine(); //331:6
                        __out.Append("        throw new NotImplementedException();"); //332:1
                        __out.AppendLine(); //332:45
                        __out.Append("    }"); //333:1
                        __out.AppendLine(); //333:6
                    }
                }
                var __loop32_results = 
                    (from __loop32_var1 in __Enumerate((cls).GetEnumerator()) //336:11
                    from op in __Enumerate((__loop32_var1.Operations).GetEnumerator()) //336:16
                    select new { __loop32_var1 = __loop32_var1, op = op}
                    ).ToList(); //336:6
                int __loop32_iteration = 0;
                foreach (var __tmp102 in __loop32_results)
                {
                    ++__loop32_iteration;
                    var __loop32_var1 = __tmp102.__loop32_var1;
                    var op = __tmp102.op;
                    __out.AppendLine(); //337:2
                    __out.Append("    /// <summary>"); //338:1
                    __out.AppendLine(); //338:18
                    string __tmp103Prefix = "    /// Implements the operation: "; //339:1
                    string __tmp104Suffix = "()"; //339:55
                    StringBuilder __tmp105 = new StringBuilder();
                    __tmp105.Append(cls.Name);
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
                    string __tmp106Line = "."; //339:45
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
                            __out.AppendLine(); //339:57
                        }
                    }
                    __out.Append("    /// </summary>"); //340:1
                    __out.AppendLine(); //340:19
                    string __tmp108Prefix = "    public virtual "; //341:1
                    string __tmp109Suffix = ")"; //341:104
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
                    string __tmp111Line = " "; //341:54
                    __out.Append(__tmp111Line);
                    StringBuilder __tmp112 = new StringBuilder();
                    __tmp112.Append(cls.Name);
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
                    string __tmp113Line = "_"; //341:65
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
                    string __tmp115Line = "("; //341:75
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
                            __out.AppendLine(); //341:105
                        }
                    }
                    __out.Append("    {"); //342:1
                    __out.AppendLine(); //342:6
                    __out.Append("        throw new NotImplementedException();"); //343:1
                    __out.AppendLine(); //343:45
                    __out.Append("    }"); //344:1
                    __out.AppendLine(); //344:6
                }
                __out.AppendLine(); //346:2
            }
            var __loop33_results = 
                (from __loop33_var1 in __Enumerate((model).GetEnumerator()) //348:8
                from Types in __Enumerate((__loop33_var1.Types).GetEnumerator()) //348:15
                from enm in __Enumerate((Types).GetEnumerator()).OfType<MetaEnum>() //348:22
                select new { __loop33_var1 = __loop33_var1, Types = Types, enm = enm}
                ).ToList(); //348:3
            int __loop33_iteration = 0;
            foreach (var __tmp117 in __loop33_results)
            {
                ++__loop33_iteration;
                var __loop33_var1 = __tmp117.__loop33_var1;
                var Types = __tmp117.Types;
                var enm = __tmp117.enm;
                var __loop34_results = 
                    (from __loop34_var1 in __Enumerate((enm).GetEnumerator()) //349:11
                    from op in __Enumerate((__loop34_var1.Operations).GetEnumerator()) //349:16
                    select new { __loop34_var1 = __loop34_var1, op = op}
                    ).ToList(); //349:6
                int __loop34_iteration = 0;
                foreach (var __tmp118 in __loop34_results)
                {
                    ++__loop34_iteration;
                    var __loop34_var1 = __tmp118.__loop34_var1;
                    var op = __tmp118.op;
                    __out.AppendLine(); //350:2
                    __out.Append("    /// <summary>"); //351:1
                    __out.AppendLine(); //351:18
                    string __tmp119Prefix = "    /// Implements the operation: "; //352:1
                    string __tmp120Suffix = string.Empty; 
                    StringBuilder __tmp121 = new StringBuilder();
                    __tmp121.Append(enm.Name);
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
                    string __tmp122Line = "."; //352:45
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
                            __out.AppendLine(); //352:55
                        }
                    }
                    __out.Append("    /// </summary>"); //353:1
                    __out.AppendLine(); //353:19
                    string __tmp124Prefix = "    public virtual "; //354:1
                    string __tmp125Suffix = ")"; //354:104
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
                    string __tmp127Line = " "; //354:54
                    __out.Append(__tmp127Line);
                    StringBuilder __tmp128 = new StringBuilder();
                    __tmp128.Append(enm.Name);
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
                    string __tmp129Line = "_"; //354:65
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
                    string __tmp131Line = "("; //354:75
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
                            __out.AppendLine(); //354:105
                        }
                    }
                    __out.Append("    {"); //355:1
                    __out.AppendLine(); //355:6
                    __out.Append("        throw new NotImplementedException();"); //356:1
                    __out.AppendLine(); //356:45
                    __out.Append("    }"); //357:1
                    __out.AppendLine(); //357:6
                }
                __out.AppendLine(); //359:2
            }
            __out.Append("}"); //361:1
            __out.AppendLine(); //361:2
            __out.AppendLine(); //362:2
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //365:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //366:1
            __out.AppendLine(); //366:14
            __out.Append("/// Factory class for creating instances of model elements."); //367:1
            __out.AppendLine(); //367:60
            __out.Append("/// </summary>"); //368:1
            __out.AppendLine(); //368:15
            string __tmp1Prefix = "public class "; //369:1
            string __tmp2Suffix = "Factory : ModelFactory"; //369:26
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
                    __out.AppendLine(); //369:48
                }
            }
            __out.Append("{"); //370:1
            __out.AppendLine(); //370:2
            string __tmp4Prefix = "    private static "; //371:1
            string __tmp5Suffix = "Factory();"; //371:67
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
            string __tmp7Line = "Factory instance = new "; //371:32
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
                    __out.AppendLine(); //371:77
                }
            }
            __out.AppendLine(); //372:2
            string __tmp9Prefix = "	private "; //373:1
            string __tmp10Suffix = "Factory()"; //373:22
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
                    __out.AppendLine(); //373:31
                }
            }
            __out.Append("	{"); //374:1
            __out.AppendLine(); //374:3
            __out.Append("	}"); //375:1
            __out.AppendLine(); //375:3
            __out.AppendLine(); //376:2
            __out.Append("    /// <summary>"); //377:1
            __out.AppendLine(); //377:18
            __out.Append("    /// The singleton instance of the factory."); //378:1
            __out.AppendLine(); //378:47
            __out.Append("    /// </summary>"); //379:1
            __out.AppendLine(); //379:19
            string __tmp12Prefix = "    public static "; //380:1
            string __tmp13Suffix = "Factory Instance"; //380:31
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
                    __out.AppendLine(); //380:47
                }
            }
            __out.Append("    {"); //381:1
            __out.AppendLine(); //381:6
            string __tmp15Prefix = "        get { return "; //382:1
            string __tmp16Suffix = "Factory.instance; }"; //382:34
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
                    __out.AppendLine(); //382:53
                }
            }
            __out.Append("    }"); //383:1
            __out.AppendLine(); //383:6
            var __loop35_results = 
                (from __loop35_var1 in __Enumerate((model).GetEnumerator()) //384:8
                from Types in __Enumerate((__loop35_var1.Types).GetEnumerator()) //384:15
                from cls in __Enumerate((Types).GetEnumerator()).OfType<MetaClass>() //384:22
                select new { __loop35_var1 = __loop35_var1, Types = Types, cls = cls}
                ).ToList(); //384:3
            int __loop35_iteration = 0;
            foreach (var __tmp18 in __loop35_results)
            {
                ++__loop35_iteration;
                var __loop35_var1 = __tmp18.__loop35_var1;
                var Types = __tmp18.Types;
                var cls = __tmp18.cls;
                __out.AppendLine(); //385:2
                __out.Append("    /// <summary>"); //386:1
                __out.AppendLine(); //386:18
                string __tmp19Prefix = "    /// Creates a new instance of "; //387:1
                string __tmp20Suffix = "."; //387:45
                StringBuilder __tmp21 = new StringBuilder();
                __tmp21.Append(cls.Name);
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
                        __out.AppendLine(); //387:46
                    }
                }
                __out.Append("    /// </summary>"); //388:1
                __out.AppendLine(); //388:19
                string __tmp22Prefix = "    public "; //389:1
                string __tmp23Suffix = "()"; //389:39
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(cls.Name);
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
                string __tmp25Line = " Create"; //389:22
                __out.Append(__tmp25Line);
                StringBuilder __tmp26 = new StringBuilder();
                __tmp26.Append(cls.Name);
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
                        __out.AppendLine(); //389:41
                    }
                }
                __out.Append("	{"); //390:1
                __out.AppendLine(); //390:3
                string __tmp27Prefix = "		"; //391:1
                string __tmp28Suffix = "Impl();"; //391:37
                StringBuilder __tmp29 = new StringBuilder();
                __tmp29.Append(cls.Name);
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
                string __tmp30Line = " result = new "; //391:13
                __out.Append(__tmp30Line);
                StringBuilder __tmp31 = new StringBuilder();
                __tmp31.Append(cls.Name);
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
                        __out.AppendLine(); //391:44
                    }
                }
                __out.Append("		return result;"); //392:1
                __out.AppendLine(); //392:17
                __out.Append("	}"); //393:1
                __out.AppendLine(); //393:3
                __out.AppendLine(); //394:2
            }
            __out.Append("}"); //396:1
            __out.AppendLine(); //396:2
            __out.AppendLine(); //397:2
            return __out.ToString();
        }

    }
}

