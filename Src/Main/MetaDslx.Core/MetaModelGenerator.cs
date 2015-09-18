using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core //1:1
{
    using __Hidden_MetaModelGenerator_1700497138;
    namespace __Hidden_MetaModelGenerator_1700497138
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
        private IEnumerable<ModelObject> Instances; //2:1
        public MetaModelGenerator(IEnumerable<ModelObject> instances) //2:1
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
                (from __loop1_var1 in __Enumerate((Instances).GetEnumerator()) //12:8
                from mm in __Enumerate((__loop1_var1).GetEnumerator()).OfType<MetaModel>() //12:19
                select new { __loop1_var1 = __loop1_var1, mm = mm}
                ).ToList(); //12:3
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
            __tmp6.Append(GenerateMetaModelDescriptor(model));
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
                    __out.AppendLine(); //20:41
                }
            }
            string __tmp7Prefix = "	"; //21:1
            string __tmp8Suffix = string.Empty; 
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(GenerateMetaModelInstance(model));
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
                    __out.AppendLine(); //21:36
                }
            }
            var __loop2_results = 
                (from __loop2_var1 in __Enumerate((model).GetEnumerator()) //22:8
                from Namespace in __Enumerate((__loop2_var1.Namespace).GetEnumerator()) //22:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //22:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //22:40
                select new { __loop2_var1 = __loop2_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //22:3
            int __loop2_iteration = 0;
            foreach (var __tmp10 in __loop2_results)
            {
                ++__loop2_iteration;
                var __loop2_var1 = __tmp10.__loop2_var1;
                var Namespace = __tmp10.Namespace;
                var Declarations = __tmp10.Declarations;
                var enm = __tmp10.enm;
                string __tmp11Prefix = "    "; //23:1
                string __tmp12Suffix = string.Empty; 
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(GenerateEnum(enm));
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
                        __out.AppendLine(); //23:24
                    }
                }
            }
            var __loop3_results = 
                (from __loop3_var1 in __Enumerate((model).GetEnumerator()) //25:8
                from Namespace in __Enumerate((__loop3_var1.Namespace).GetEnumerator()) //25:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //25:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //25:40
                select new { __loop3_var1 = __loop3_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //25:3
            int __loop3_iteration = 0;
            foreach (var __tmp14 in __loop3_results)
            {
                ++__loop3_iteration;
                var __loop3_var1 = __tmp14.__loop3_var1;
                var Namespace = __tmp14.Namespace;
                var Declarations = __tmp14.Declarations;
                var cls = __tmp14.cls;
                string __tmp15Prefix = "    "; //26:1
                string __tmp16Suffix = string.Empty; 
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(GenerateInterface(cls));
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
                        __out.AppendLine(); //26:29
                    }
                }
                string __tmp18Prefix = "    "; //27:1
                string __tmp19Suffix = string.Empty; 
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(GenerateInterfaceImpl(model, cls));
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
                        __out.AppendLine(); //27:40
                    }
                }
            }
            string __tmp21Prefix = "    "; //29:1
            string __tmp22Suffix = string.Empty; 
            StringBuilder __tmp23 = new StringBuilder();
            __tmp23.Append(GenerateFactory(model));
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
                    __out.AppendLine(); //29:29
                }
            }
            string __tmp24Prefix = "    "; //30:1
            string __tmp25Suffix = string.Empty; 
            StringBuilder __tmp26 = new StringBuilder();
            __tmp26.Append(GenerateImplementationProvider(model));
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
                    __out.AppendLine(); //30:44
                }
            }
            __out.Append("}"); //31:1
            __out.AppendLine(); //31:2
            return __out.ToString();
        }

        public string GenerateAnnotations(MetaAnnotatedElement elem) //34:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop4_results = 
                (from __loop4_var1 in __Enumerate((elem).GetEnumerator()) //35:7
                from annot in __Enumerate((__loop4_var1.Annotations).GetEnumerator()) //35:13
                select new { __loop4_var1 = __loop4_var1, annot = annot}
                ).ToList(); //35:2
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
                        __out.AppendLine(); //36:23
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateEnum(MetaEnum enm) //40:1
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
                    __out.AppendLine(); //41:27
                }
            }
            string __tmp4Prefix = "public enum "; //42:1
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
                    __out.AppendLine(); //42:31
                }
            }
            __out.Append("{"); //43:1
            __out.AppendLine(); //43:2
            var __loop5_results = 
                (from __loop5_var1 in __Enumerate((enm).GetEnumerator()) //44:11
                from value in __Enumerate((__loop5_var1.EnumLiterals).GetEnumerator()) //44:16
                select new { __loop5_var1 = __loop5_var1, value = value}
                ).ToList(); //44:6
            int __loop5_iteration = 0;
            foreach (var __tmp7 in __loop5_results)
            {
                ++__loop5_iteration;
                var __loop5_var1 = __tmp7.__loop5_var1;
                var value = __tmp7.value;
                string __tmp8Prefix = "    "; //45:1
                string __tmp9Suffix = ","; //45:17
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
                        __out.AppendLine(); //45:18
                    }
                }
            }
            __out.Append("}"); //47:1
            __out.AppendLine(); //47:2
            __out.AppendLine(); //48:2
            return __out.ToString();
        }

        public string GetAncestors(MetaClass cls) //51:1
        {
            string result = ""; //52:2
            var __loop6_results = 
                (from __loop6_var1 in __Enumerate((cls).GetEnumerator()) //53:7
                from super in __Enumerate((__loop6_var1.SuperClasses).GetEnumerator()) //53:12
                select new { __loop6_var1 = __loop6_var1, super = super}
                ).ToList(); //53:2
            int __loop6_iteration = 0;
            string delim = " : "; //53:32
            foreach (var __tmp1 in __loop6_results)
            {
                ++__loop6_iteration;
                if (__loop6_iteration >= 2) //53:54
                {
                    delim = ", "; //53:54
                }
                var __loop6_var1 = __tmp1.__loop6_var1;
                var super = __tmp1.super;
                result += delim + super.Namespace.CSharpName() + "." + super.CSharpName(); //54:3
            }
            return result; //56:2
        }

        public string GenerateInterface(MetaClass cls) //59:1
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
                    __out.AppendLine(); //60:27
                }
            }
            string __tmp4Prefix = "public interface "; //61:1
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
                    __out.AppendLine(); //61:55
                }
            }
            __out.Append("{"); //62:1
            __out.AppendLine(); //62:2
            var __loop7_results = 
                (from __loop7_var1 in __Enumerate((cls).GetEnumerator()) //63:11
                from prop in __Enumerate((__loop7_var1.Properties).GetEnumerator()) //63:16
                select new { __loop7_var1 = __loop7_var1, prop = prop}
                ).ToList(); //63:6
            int __loop7_iteration = 0;
            foreach (var __tmp8 in __loop7_results)
            {
                ++__loop7_iteration;
                var __loop7_var1 = __tmp8.__loop7_var1;
                var prop = __tmp8.prop;
                string __tmp9Prefix = "    "; //64:1
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
                        __out.AppendLine(); //64:29
                    }
                }
            }
            __out.AppendLine(); //66:2
            var __loop8_results = 
                (from __loop8_var1 in __Enumerate((cls).GetEnumerator()) //67:11
                from op in __Enumerate((__loop8_var1.Operations).GetEnumerator()) //67:16
                select new { __loop8_var1 = __loop8_var1, op = op}
                ).ToList(); //67:6
            int __loop8_iteration = 0;
            foreach (var __tmp12 in __loop8_results)
            {
                ++__loop8_iteration;
                var __loop8_var1 = __tmp12.__loop8_var1;
                var op = __tmp12.op;
                string __tmp13Prefix = "    "; //68:1
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
                        __out.AppendLine(); //68:28
                    }
                }
            }
            __out.Append("}"); //70:1
            __out.AppendLine(); //70:2
            __out.AppendLine(); //71:2
            return __out.ToString();
        }

        public string GenerateProperty(MetaProperty prop) //74:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //75:2
            {
                __out.Append("new "); //76:1
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //78:3
            {
                string __tmp1Prefix = string.Empty; 
                string __tmp2Suffix = " { get; set; }"; //79:43
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
                string __tmp4Line = " "; //79:31
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
                        __out.AppendLine(); //79:57
                    }
                }
            }
            else //80:3
            {
                string __tmp6Prefix = string.Empty; 
                string __tmp7Suffix = " { get; }"; //81:43
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
                string __tmp9Line = " "; //81:31
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
                        __out.AppendLine(); //81:52
                    }
                }
            }
            return __out.ToString();
        }

        public string GetParameters(MetaOperation op, bool defaultValues) //85:1
        {
            string result = ""; //86:2
            var __loop9_results = 
                (from __loop9_var1 in __Enumerate((op).GetEnumerator()) //87:7
                from param in __Enumerate((__loop9_var1.Parameters).GetEnumerator()) //87:11
                select new { __loop9_var1 = __loop9_var1, param = param}
                ).ToList(); //87:2
            int __loop9_iteration = 0;
            string delim = ""; //87:29
            foreach (var __tmp1 in __loop9_results)
            {
                ++__loop9_iteration;
                if (__loop9_iteration >= 2) //87:48
                {
                    delim = ", "; //87:48
                }
                var __loop9_var1 = __tmp1.__loop9_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpPublicName() + " " + param.Name; //88:3
            }
            return result; //93:2
        }

        public string GetImplParameters(MetaClass cls, MetaOperation op) //96:1
        {
            string result = cls.CSharpName() + " @this"; //97:2
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

        public string GetImplParameters(MetaEnum enm, MetaOperation op) //105:1
        {
            string result = enm.CSharpName() + " @this"; //106:2
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

        public string GetEnumImplParameters(MetaEnum enm, MetaOperation op) //114:1
        {
            string result = "this " + enm.CSharpName() + " @this"; //115:2
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
                result += delim + param.Type.CSharpPublicName() + " " + param.Name; //118:3
            }
            return result; //120:2
        }

        public string GetEnumImplCallParameterNames(MetaOperation op) //123:1
        {
            string result = "@this"; //124:2
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

        public string GetImplCallParameterNames(MetaOperation op) //132:1
        {
            string result = "this"; //133:2
            string delim = ", "; //134:2
            var __loop14_results = 
                (from __loop14_var1 in __Enumerate((op).GetEnumerator()) //135:7
                from param in __Enumerate((__loop14_var1.Parameters).GetEnumerator()) //135:11
                select new { __loop14_var1 = __loop14_var1, param = param}
                ).ToList(); //135:2
            int __loop14_iteration = 0;
            foreach (var __tmp1 in __loop14_results)
            {
                ++__loop14_iteration;
                var __loop14_var1 = __tmp1.__loop14_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //136:3
            }
            return result; //138:2
        }

        public string GenerateOperation(MetaOperation op) //141:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = ");"; //142:71
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
            string __tmp4Line = " "; //142:35
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
            string __tmp6Line = "("; //142:45
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
                    __out.AppendLine(); //142:73
                }
            }
            return __out.ToString();
        }

        public string GenerateInterfaceImpl(MetaModel model, MetaClass cls) //145:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "internal class "; //146:1
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
            string __tmp4Line = " : ModelObject, "; //146:38
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
            string __tmp6Line = "."; //146:82
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
                    __out.AppendLine(); //146:101
                }
            }
            __out.Append("{"); //147:1
            __out.AppendLine(); //147:2
            string __tmp8Prefix = "    static "; //148:1
            string __tmp9Suffix = "()"; //148:34
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
                    __out.AppendLine(); //148:36
                }
            }
            __out.Append("    {"); //149:1
            __out.AppendLine(); //149:6
            string __tmp11Prefix = "        "; //150:1
            string __tmp12Suffix = ".StaticInit();"; //150:33
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
                    __out.AppendLine(); //150:47
                }
            }
            __out.Append("    }"); //151:1
            __out.AppendLine(); //151:6
            __out.AppendLine(); //152:2
            string __tmp14Prefix = "    "; //153:1
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
                    __out.AppendLine(); //153:42
                }
            }
            var __loop15_results = 
                (from __loop15_var1 in __Enumerate((cls).GetEnumerator()) //154:11
                from prop in __Enumerate((__loop15_var1.GetAllProperties()).GetEnumerator()) //154:16
                select new { __loop15_var1 = __loop15_var1, prop = prop}
                ).ToList(); //154:6
            int __loop15_iteration = 0;
            foreach (var __tmp17 in __loop15_results)
            {
                ++__loop15_iteration;
                var __loop15_var1 = __tmp17.__loop15_var1;
                var prop = __tmp17.prop;
                string __tmp18Prefix = "    "; //155:1
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
                        __out.AppendLine(); //155:45
                    }
                }
            }
            var __loop16_results = 
                (from __loop16_var1 in __Enumerate((cls).GetEnumerator()) //157:11
                from op in __Enumerate((__loop16_var1.GetAllOperations()).GetEnumerator()) //157:16
                select new { __loop16_var1 = __loop16_var1, op = op}
                ).ToList(); //157:6
            int __loop16_iteration = 0;
            foreach (var __tmp21 in __loop16_results)
            {
                ++__loop16_iteration;
                var __loop16_var1 = __tmp21.__loop16_var1;
                var op = __tmp21.op;
                string __tmp22Prefix = "    "; //158:1
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
                        __out.AppendLine(); //158:39
                    }
                }
            }
            __out.Append("}"); //160:1
            __out.AppendLine(); //160:2
            __out.AppendLine(); //161:2
            return __out.ToString();
        }

        public string GeneratePropertyDeclaration(MetaModel model, MetaClass cls, MetaProperty prop) //164:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class == cls) //165:2
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
                        __out.AppendLine(); //166:28
                    }
                }
                if (prop.Kind == MetaPropertyKind.Containment) //167:2
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
                            __out.AppendLine(); //168:27
                        }
                    }
                }
                if (prop.Kind != MetaPropertyKind.Normal && prop.Kind != MetaPropertyKind.Containment && !(prop.Type is MetaCollectionType)) //170:2
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
                            __out.AppendLine(); //171:24
                        }
                    }
                }
                var __loop17_results = 
                    (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //173:7
                    select new { p = p}
                    ).ToList(); //173:2
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
                    string __tmp15Line = "."; //174:63
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
                            __out.AppendLine(); //174:111
                        }
                    }
                }
                var __loop18_results = 
                    (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //176:7
                    select new { p = p}
                    ).ToList(); //176:2
                int __loop18_iteration = 0;
                foreach (var __tmp20 in __loop18_results)
                {
                    ++__loop18_iteration;
                    var p = __tmp20.p;
                    if (cls.GetAllSuperClasses(false).Contains(p.Class)) //177:3
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
                        string __tmp25Line = "."; //178:62
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
                                __out.AppendLine(); //178:110
                            }
                        }
                    }
                    else //179:3
                    {
                        string __tmp30Prefix = "// ERROR: subsetted property '"; //180:1
                        string __tmp31Suffix = "' must be a property of an ancestor class"; //180:95
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
                        string __tmp33Line = "."; //180:63
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
                        string __tmp35Line = "."; //180:86
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
                                __out.AppendLine(); //180:136
                            }
                        }
                    }
                }
                var __loop19_results = 
                    (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //183:7
                    select new { p = p}
                    ).ToList(); //183:2
                int __loop19_iteration = 0;
                foreach (var __tmp37 in __loop19_results)
                {
                    ++__loop19_iteration;
                    var p = __tmp37.p;
                    if (cls.GetAllSuperClasses(false).Contains(p.Class)) //184:3
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
                        string __tmp42Line = "."; //185:64
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
                                __out.AppendLine(); //185:112
                            }
                        }
                    }
                    else //186:3
                    {
                        string __tmp47Prefix = "// ERROR: redefined property '"; //187:1
                        string __tmp48Suffix = "' must be a property of an ancestor class"; //187:95
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
                        string __tmp50Line = "."; //187:63
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
                        string __tmp52Line = "."; //187:86
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
                                __out.AppendLine(); //187:136
                            }
                        }
                    }
                }
                string __tmp54Prefix = "public static readonly ModelProperty "; //190:1
                string __tmp55Suffix = "Property ="; //190:49
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
                        __out.AppendLine(); //190:59
                    }
                }
                string __tmp57Prefix = "    ModelProperty.Register(\""; //191:1
                string __tmp58Suffix = "));"; //191:194
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
                string __tmp60Line = "\", typeof("; //191:40
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
                string __tmp62Line = "), typeof("; //191:84
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
                string __tmp64Line = "), typeof("; //191:123
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
                string __tmp66Line = "."; //191:168
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
                        __out.AppendLine(); //191:197
                    }
                }
            }
            __out.AppendLine(); //193:2
            return __out.ToString();
        }

        public string GeneratePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //196:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //197:2
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
            string __tmp4Line = " "; //198:31
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
            string __tmp6Line = "."; //198:57
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
                    __out.AppendLine(); //198:69
                }
            }
            __out.Append("{"); //199:1
            __out.AppendLine(); //199:2
            if (prop.Kind == MetaPropertyKind.Derived) //200:3
            {
                MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //201:4
                if (synInit == null) //202:4
                {
                    string __tmp8Prefix = "    get { return "; //203:1
                    string __tmp9Suffix = "(this); }"; //203:105
                    StringBuilder __tmp10 = new StringBuilder();
                    __tmp10.Append(model.Name);
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
                    string __tmp11Line = "ImplementationProvider.Implementation."; //203:30
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
                    string __tmp13Line = "_"; //203:93
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
                            __out.AppendLine(); //203:114
                        }
                    }
                }
                else //204:4
                {
                    string __tmp15Prefix = "    get { return "; //205:1
                    string __tmp16Suffix = "; }"; //205:53
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
                            __out.AppendLine(); //205:56
                        }
                    }
                }
            }
            else //207:3
            {
                __out.Append("    get "); //208:1
                __out.AppendLine(); //208:9
                __out.Append("    {"); //209:1
                __out.AppendLine(); //209:6
                string __tmp18Prefix = "        object result = this.MGet("; //210:1
                string __tmp19Suffix = "Property); "; //210:97
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
                string __tmp21Line = "."; //210:59
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
                string __tmp23Line = "."; //210:85
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
                        __out.AppendLine(); //210:108
                    }
                }
                string __tmp25Prefix = "        if (result != null) return ("; //211:1
                string __tmp26Suffix = ")result;"; //211:67
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
                        __out.AppendLine(); //211:75
                    }
                }
                string __tmp28Prefix = "        else return default("; //212:1
                string __tmp29Suffix = ");"; //212:59
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
                        __out.AppendLine(); //212:61
                    }
                }
                __out.Append("    }"); //213:1
                __out.AppendLine(); //213:6
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //215:3
            {
                string __tmp31Prefix = "    set { this.MSet("; //216:1
                string __tmp32Suffix = "Property, value); }"; //216:83
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
                string __tmp34Line = "."; //216:45
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
                string __tmp36Line = "."; //216:71
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
                        __out.AppendLine(); //216:102
                    }
                }
            }
            __out.Append("}"); //218:1
            __out.AppendLine(); //218:2
            return __out.ToString();
        }

        public string GetCollectionConstructorParams(MetaProperty prop) //221:1
        {
            MetaCollectionType mct = prop.Type as MetaCollectionType; //222:2
            if (mct != null && mct.InnerType is MetaClass) //223:2
            {
                return "this, " + prop.Class.Model.CSharpFullName() + "." + prop.Class.CSharpName() + "." + prop.Name + "Property"; //224:3
            }
            else //225:2
            {
                return ""; //226:3
            }
        }

        public string GenerateConstantValueExpression(string name, MetaExpression expr, string nameType) //230:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //231:10
            if (expr is MetaNewExpression) //232:2
            {
                string tmpName = "tmp" + NextCounter(); //233:2
                string tmpType = ((MetaNewExpression)expr).TypeReference.CSharpFullName(); //234:2
                string __tmp2Prefix = string.Empty; 
                string __tmp3Suffix = "();"; //235:110
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
                string __tmp5Line = " "; //235:10
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
                string __tmp7Line = " = "; //235:20
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
                string __tmp9Line = "Factory.Instance.Create"; //235:54
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
                        __out.AppendLine(); //235:113
                    }
                }
                if (nameType != null) //236:2
                {
                    string __tmp11Prefix = string.Empty; 
                    string __tmp12Suffix = " "; //237:11
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
                string __tmp15Suffix = ";"; //239:19
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
                string __tmp17Line = " = "; //239:7
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
                        __out.AppendLine(); //239:20
                    }
                }
                var __loop20_results = 
                    (from __loop20_var1 in __Enumerate((((MetaNewExpression)expr)).GetEnumerator()) //240:8
                    from pi in __Enumerate((__loop20_var1.PropertyInitializers).GetEnumerator()) //240:14
                    select new { __loop20_var1 = __loop20_var1, pi = pi}
                    ).ToList(); //240:2
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
                            __out.AppendLine(); //241:79
                        }
                    }
                }
            }
            else if (expr is MetaNewCollectionExpression) //243:2
            {
                var __loop21_results = 
                    (from __loop21_var1 in __Enumerate((((MetaNewCollectionExpression)expr)).GetEnumerator()) //244:8
                    from v in __Enumerate((__loop21_var1.Values).GetEnumerator()) //244:14
                    select new { __loop21_var1 = __loop21_var1, v = v}
                    ).ToList(); //244:2
                int __loop21_iteration = 0;
                foreach (var __tmp23 in __loop21_results)
                {
                    ++__loop21_iteration;
                    var __loop21_var1 = __tmp23.__loop21_var1;
                    var v = __tmp23.v;
                    string tmpName = "tmp" + NextCounter(); //245:2
                    string tmpType = v.Type.CSharpFullName(); //246:2
                    if (v is MetaNewExpression) //247:3
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
                                __out.AppendLine(); //248:55
                            }
                        }
                        string __tmp27Prefix = string.Empty; 
                        string __tmp28Suffix = ");"; //249:21
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
                        string __tmp30Line = ".Add("; //249:7
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
                                __out.AppendLine(); //249:23
                            }
                        }
                    }
                    else if (v is MetaNewCollectionExpression) //250:3
                    {
                        __out.Append("// TODO"); //251:1
                        __out.AppendLine(); //251:8
                    }
                    else //252:3
                    {
                        string __tmp32Prefix = string.Empty; 
                        string __tmp33Suffix = ");"; //253:38
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
                        string __tmp35Line = ".Add("; //253:7
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
                                __out.AppendLine(); //253:40
                            }
                        }
                    }
                }
            }
            else //256:2
            {
                __out.Append(name);
                __out.Append(" = "); //256:17
                __out.Append(GenerateExpression(expr));
                __out.Append(";"); //256:46
                __out.AppendLine(); //256:47
            }//257:2
            return __out.ToString();
        }

        public string GenerateNewObject() //260:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateExpression(MetaExpression expr) //263:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //264:10
            if (expr is MetaBracketExpression) //265:2
            {
                __out.Append("("); //265:33
                __out.Append(GenerateExpression(((MetaBracketExpression)expr).Expression));
                __out.Append(")"); //265:71
            }
            else if (expr is MetaThisExpression) //266:2
            {
                __out.Append("(("); //266:30
                __out.Append(((MetaType)ModelContext.Current.Compiler.ResolutionProvider.GetCurrentTypeScopeOf((ModelObject)((MetaThisExpression)expr))).CSharpName());
                __out.Append(")this)"); //266:148
            }
            else if (expr is MetaNullExpression) //267:2
            {
                __out.Append("null"); //267:30
            }
            else if (expr is MetaTypeAsExpression) //268:2
            {
                __out.Append(GenerateExpression(((MetaTypeAsExpression)expr).Expression));
                __out.Append(" as "); //268:69
                __out.Append(((MetaTypeAsExpression)expr).TypeReference.CSharpName());
            }
            else if (expr is MetaTypeCastExpression) //269:2
            {
                __out.Append("("); //269:34
                __out.Append(((MetaTypeCastExpression)expr).TypeReference.CSharpName());
                __out.Append(")"); //269:68
                __out.Append(GenerateExpression(((MetaTypeCastExpression)expr).Expression));
            }
            else if (expr is MetaTypeCheckExpression) //270:2
            {
                __out.Append(GenerateExpression(((MetaTypeCheckExpression)expr).Expression));
                __out.Append(" is "); //270:72
                __out.Append(((MetaTypeCheckExpression)expr).TypeReference.CSharpName());
            }
            else if (expr is MetaTypeOfExpression) //271:2
            {
                __out.Append(GenerateTypeOf(((MetaTypeOfExpression)expr)));
            }
            else if (expr is MetaConditionalExpression) //272:2
            {
                __out.Append(GenerateExpression(((MetaConditionalExpression)expr).Condition));
                __out.Append(" ? "); //272:73
                __out.Append(GenerateExpression(((MetaConditionalExpression)expr).Then));
                __out.Append(" : "); //272:107
                __out.Append(GenerateExpression(((MetaConditionalExpression)expr).Else));
            }
            else if (expr is MetaConstantExpression) //273:2
            {
                __out.Append(GetCSharpValue(((MetaConstantExpression)expr).Value));
            }
            else if (expr is MetaIdentifierExpression) //274:2
            {
                __out.Append(GenerateIdentifierExpression(((MetaIdentifierExpression)expr)));
            }
            else if (expr is MetaMemberAccessExpression) //275:2
            {
                __out.Append(GenerateExpression(((MetaMemberAccessExpression)expr).Expression));
                __out.Append("."); //275:75
                __out.Append(((MetaMemberAccessExpression)expr).Name);
            }
            else if (expr is MetaFunctionCallExpression) //276:2
            {
                __out.Append(GenerateFunctionCall(((MetaFunctionCallExpression)expr)));
            }
            else if (expr is MetaIndexerExpression) //277:2
            {
                __out.Append(GenerateIndexerCall(((MetaIndexerExpression)expr)));
            }
            else if (expr is MetaOperatorExpression) //278:2
            {
                __out.Append(GenerateOperator(((MetaOperatorExpression)expr)));
            }
            else //279:2
            {
                __out.Append("***unknown expression type***"); //279:11
                __out.AppendLine(); //279:40
            }//280:2
            return __out.ToString();
        }

        public string GenerateIdentifierExpression(MetaIdentifierExpression expr) //283:1
        {
            StringBuilder __out = new StringBuilder();
            if (expr.Definition is MetaProperty) //284:2
            {
                string __tmp1Prefix = "(("; //285:1
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
                string __tmp4Line = ")this)."; //285:119
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
            else //286:2
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

        public string GenerateFunctionCall(MetaFunctionCallExpression call) //291:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = call.Definition; //292:9
            if (__tmp1 == MetaDescriptor.Constants.TypeOf) //293:2
            {
                __out.Append(GenerateTypeOf(call.Arguments[0]));
            }
            else if (__tmp1 == MetaDescriptor.Constants.GetValueType) //294:2
            {
                __out.Append("ModelContext.Current.Compiler.TypeProvider.GetTypeOf("); //294:46
                __out.Append(GenerateCallArguments(call, ""));
                __out.Append(")"); //294:132
            }
            else if (__tmp1 == MetaDescriptor.Constants.GetReturnType) //295:2
            {
                __out.Append("ModelContext.Current.Compiler.TypeProvider.GetReturnTypeOf("); //295:47
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //295:152
            }
            else if (__tmp1 == MetaDescriptor.Constants.CurrentType) //296:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.GetCurrentTypeScopeOf("); //296:45
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //296:162
            }
            else if (__tmp1 == MetaDescriptor.Constants.TypeCheck) //297:2
            {
                __out.Append("ModelContext.Current.Compiler.TypeProvider.TypeCheck("); //297:43
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //297:142
            }
            else if (__tmp1 == MetaDescriptor.Constants.Balance) //298:2
            {
                __out.Append("ModelContext.Current.Compiler.TypeProvider.Balance("); //298:41
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //298:138
            }
            else if (__tmp1 == MetaDescriptor.Constants.Resolve1) //299:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //299:42
                __out.Append("[]");
                __out.Append(" { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.NameOrType, "); //299:120
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //299:260
            }
            else if (__tmp1 == MetaDescriptor.Constants.Resolve2) //300:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //300:42
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //300:120
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, ResolveKind.NameOrType, "); //300:175
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //300:242
            }
            else if (__tmp1 == MetaDescriptor.Constants.ResolveType1) //301:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //301:46
                __out.Append("[]");
                __out.Append(" { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Type, "); //301:124
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //301:258
            }
            else if (__tmp1 == MetaDescriptor.Constants.ResolveType2) //302:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //302:46
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //302:124
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, ResolveKind.Type, "); //302:179
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //302:240
            }
            else if (__tmp1 == MetaDescriptor.Constants.ResolveName1) //303:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //303:46
                __out.Append("[]");
                __out.Append(" { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, "); //303:124
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //303:258
            }
            else if (__tmp1 == MetaDescriptor.Constants.ResolveName2) //304:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //304:46
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //304:124
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, ResolveKind.Name, "); //304:179
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //304:240
            }
            else if (__tmp1 == MetaDescriptor.Constants.Bind1) //305:2
            {
                __out.Append("ModelContext.Current.Compiler.BindingProvider.Bind(this, new ModelObject"); //305:39
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //305:117
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, new BindingInfo())"); //305:172
            }
            else if (__tmp1 == MetaDescriptor.Constants.Bind2) //306:2
            {
                __out.Append("ModelContext.Current.Compiler.BindingProvider.Bind(this, "); //306:39
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new BindingInfo())"); //306:135
            }
            else if (__tmp1 == MetaDescriptor.Constants.Bind3) //307:2
            {
                __out.Append("ModelContext.Current.Compiler.BindingProvider.Bind((ModelObject)"); //307:39
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ModelObject"); //307:142
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //307:165
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(" }, new BindingInfo())"); //307:220
            }
            else if (__tmp1 == MetaDescriptor.Constants.Bind4) //308:2
            {
                __out.Append("ModelContext.Current.Compiler.BindingProvider.Bind((ModelObject)"); //308:39
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", "); //308:142
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new BindingInfo())"); //308:183
            }
            else if (__tmp1 == MetaDescriptor.Constants.SelectOfType1) //309:2
            {
                __out.Append("new object"); //309:47
                __out.Append("[]");
                __out.Append(" { "); //309:63
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }.Where(e => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(e) is "); //309:105
                __out.Append(GetTypeName(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //309:210
            }
            else if (__tmp1 == MetaDescriptor.Constants.SelectOfType2) //310:2
            {
                __out.Append("("); //310:47
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(").Where(e => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(e) is "); //310:87
                __out.Append(GetTypeName(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //310:191
            }
            else if (__tmp1 == MetaDescriptor.Constants.SelectOfName1) //311:2
            {
                __out.Append("new object"); //311:47
                __out.Append("[]");
                __out.Append(" { "); //311:63
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }.Where(e => ModelContext.Current.Compiler.NameProvider.GetNameOf((ModelObject)e) == "); //311:105
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //311:230
            }
            else if (__tmp1 == MetaDescriptor.Constants.SelectOfName2) //312:2
            {
                __out.Append("("); //312:47
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(").Where(e => ModelContext.Current.Compiler.NameProvider.GetNameOf((ModelObject)e) == "); //312:87
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //312:211
            }
            else //313:2
            {
                __out.Append(GenerateExpression(call.Expression));
                __out.Append("("); //313:48
                __out.Append(GenerateCallArguments(call, ""));
                __out.Append(")"); //313:82
            }//314:2
            return __out.ToString();
        }

        public string GenerateIndexerCall(MetaIndexerExpression call) //317:1
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

        public string GenerateTypeOf(object expr) //321:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //322:9
            if (__tmp1 == MetaDescriptor.Constants.None) //323:2
            {
                __out.Append("MetaDescriptor.Constants.None"); //323:38
            }
            else if (__tmp1 == MetaDescriptor.Constants.Error) //324:2
            {
                __out.Append("MetaDescriptor.Constants.Error"); //324:39
            }
            else if (__tmp1 == MetaDescriptor.Constants.Any) //325:2
            {
                __out.Append("MetaDescriptor.Constants.Any"); //325:37
            }
            else if (__tmp1 == MetaDescriptor.Constants.Object) //326:2
            {
                __out.Append("MetaDescriptor.Constants.Object"); //326:40
            }
            else if (__tmp1 == MetaDescriptor.Constants.String) //327:2
            {
                __out.Append("MetaDescriptor.Constants.String"); //327:40
            }
            else if (__tmp1 == MetaDescriptor.Constants.Int) //328:2
            {
                __out.Append("MetaDescriptor.Constants.Int"); //328:37
            }
            else if (__tmp1 == MetaDescriptor.Constants.Long) //329:2
            {
                __out.Append("MetaDescriptor.Constants.Long"); //329:38
            }
            else if (__tmp1 == MetaDescriptor.Constants.Float) //330:2
            {
                __out.Append("MetaDescriptor.Constants.Float"); //330:39
            }
            else if (__tmp1 == MetaDescriptor.Constants.Double) //331:2
            {
                __out.Append("MetaDescriptor.Constants.Double"); //331:40
            }
            else if (__tmp1 == MetaDescriptor.Constants.Byte) //332:2
            {
                __out.Append("MetaDescriptor.Constants.Byte"); //332:38
            }
            else if (__tmp1 == MetaDescriptor.Constants.Bool) //333:2
            {
                __out.Append("MetaDescriptor.Constants.Bool"); //333:38
            }
            else if (__tmp1 == MetaDescriptor.Constants.Void) //334:2
            {
                __out.Append("MetaDescriptor.Constants.Void"); //334:38
            }
            else if (__tmp1 == MetaDescriptor.Constants.ModelObject) //335:2
            {
                __out.Append("MetaDescriptor.Constants.ModelObject"); //335:45
            }
            else if (__tmp1 == MetaDescriptor.Constants.ModelObjectList) //336:2
            {
                __out.Append("MetaDescriptor.Constants.ModelObjectList"); //336:49
            }
            else if (expr is MetaTypeOfExpression) //337:2
            {
                __out.Append(GenerateTypeOf(((MetaTypeOfExpression)expr).TypeReference));
            }
            else if (expr is MetaClass) //338:2
            {
                __out.Append(((MetaClass)expr).Model.Name);
                __out.Append("Instance."); //338:38
                __out.Append(((MetaClass)expr).CSharpName());
            }
            else if (expr is MetaCollectionType) //339:2
            {
                __out.Append(((MetaCollectionType)expr).CSharpFullName());
            }
            else //340:2
            {
                __out.Append("***error***"); //340:11
            }//341:2
            return __out.ToString();
        }

        public string GenerateCallArguments(MetaBoundExpression call, string prefix) //344:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop22_results = 
                (from __loop22_var1 in __Enumerate((call).GetEnumerator()) //345:7
                from arg in __Enumerate((__loop22_var1.Arguments).GetEnumerator()) //345:13
                select new { __loop22_var1 = __loop22_var1, arg = arg}
                ).ToList(); //345:2
            int __loop22_iteration = 0;
            string delim = ""; //345:28
            foreach (var __tmp1 in __loop22_results)
            {
                ++__loop22_iteration;
                if (__loop22_iteration >= 2) //345:47
                {
                    delim = ", "; //345:47
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

        public string GenerateOperator(MetaOperatorExpression expr) //350:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //351:10
            if (expr is MetaUnaryExpression) //352:2
            {
                if (((MetaUnaryExpression)expr) is MetaPostIncrementAssignExpression || ((MetaUnaryExpression)expr) is MetaPostDecrementAssignExpression) //353:3
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
                else //355:3
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
            else if (expr is MetaBinaryExpression) //358:2
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
            }//360:2
            return __out.ToString();
        }

        public string GenerateNewPropertyInitializers(MetaNewExpression expr) //363:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((expr).GetEnumerator()) //364:7
                from pi in __Enumerate((__loop23_var1.PropertyInitializers).GetEnumerator()) //364:13
                select new { __loop23_var1 = __loop23_var1, pi = pi}
                ).ToList(); //364:2
            int __loop23_iteration = 0;
            string delim = ""; //364:38
            foreach (var __tmp1 in __loop23_results)
            {
                ++__loop23_iteration;
                if (__loop23_iteration >= 2) //364:57
                {
                    delim = ", "; //364:57
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
                string __tmp6Line = " = "; //365:26
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

        public string GenerateNewCollectionInitializers(MetaNewCollectionExpression expr) //369:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((expr).GetEnumerator()) //370:7
                from v in __Enumerate((__loop24_var1.Values).GetEnumerator()) //370:13
                select new { __loop24_var1 = __loop24_var1, v = v}
                ).ToList(); //370:2
            int __loop24_iteration = 0;
            string delim = ""; //370:23
            foreach (var __tmp1 in __loop24_results)
            {
                ++__loop24_iteration;
                if (__loop24_iteration >= 2) //370:42
                {
                    delim = ", "; //370:42
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

        public string GetCSharpValue(object value) //375:1
        {
            if (value == null) //376:2
            {
                return "null"; //376:21
            }
            else if (value is bool && ((bool)value) == true) //377:2
            {
                return "true"; //377:51
            }
            else if (value is bool && ((bool)value) == false) //378:2
            {
                return "false"; //378:52
            }
            else if (value is string) //379:2
            {
                return "\"" + value.ToString() + "\""; //379:28
            }
            else if (value is MetaExpression) //380:2
            {
                return GenerateExpression((MetaExpression)value); //380:36
            }
            else //381:2
            {
                return value.ToString(); //381:7
            }
        }

        public string GetCSharpOperator(MetaOperatorExpression expr) //385:1
        {
            var __tmp1 = expr; //386:9
            if (expr is MetaUnaryPlusExpression) //387:3
            {
                return "+"; //387:36
            }
            else if (expr is MetaNegateExpression) //388:3
            {
                return "-"; //388:33
            }
            else if (expr is MetaOnesComplementExpression) //389:3
            {
                return "~"; //389:41
            }
            else if (expr is MetaNotExpression) //390:3
            {
                return "!"; //390:30
            }
            else if (expr is MetaPostIncrementAssignExpression) //391:3
            {
                return "++"; //391:46
            }
            else if (expr is MetaPostDecrementAssignExpression) //392:3
            {
                return "--"; //392:46
            }
            else if (expr is MetaPreIncrementAssignExpression) //393:3
            {
                return "++"; //393:45
            }
            else if (expr is MetaPreDecrementAssignExpression) //394:3
            {
                return "--"; //394:45
            }
            else if (expr is MetaMultiplyExpression) //395:3
            {
                return "*"; //395:35
            }
            else if (expr is MetaDivideExpression) //396:3
            {
                return "/"; //396:33
            }
            else if (expr is MetaModuloExpression) //397:3
            {
                return "%"; //397:33
            }
            else if (expr is MetaAddExpression) //398:3
            {
                return "+"; //398:30
            }
            else if (expr is MetaSubtractExpression) //399:3
            {
                return "-"; //399:35
            }
            else if (expr is MetaLeftShiftExpression) //400:3
            {
                return "<<"; //400:36
            }
            else if (expr is MetaRightShiftExpression) //401:3
            {
                return ">>"; //401:37
            }
            else if (expr is MetaLessThanExpression) //402:3
            {
                return "<"; //402:35
            }
            else if (expr is MetaLessThanOrEqualExpression) //403:3
            {
                return "<="; //403:42
            }
            else if (expr is MetaGreaterThanExpression) //404:3
            {
                return ">"; //404:38
            }
            else if (expr is MetaGreaterThanOrEqualExpression) //405:3
            {
                return ">="; //405:45
            }
            else if (expr is MetaEqualExpression) //406:3
            {
                return "=="; //406:32
            }
            else if (expr is MetaNotEqualExpression) //407:3
            {
                return "!="; //407:35
            }
            else if (expr is MetaAndExpression) //408:3
            {
                return "&"; //408:30
            }
            else if (expr is MetaOrExpression) //409:3
            {
                return "|"; //409:29
            }
            else if (expr is MetaExclusiveOrExpression) //410:3
            {
                return "^"; //410:38
            }
            else if (expr is MetaAndAlsoExpression) //411:3
            {
                return "&&"; //411:34
            }
            else if (expr is MetaOrElseExpression) //412:3
            {
                return "||"; //412:33
            }
            else if (expr is MetaNullCoalescingExpression) //413:3
            {
                return "??"; //413:41
            }
            else if (expr is MetaMultiplyAssignExpression) //414:3
            {
                return "*="; //414:41
            }
            else if (expr is MetaDivideAssignExpression) //415:3
            {
                return "/="; //415:39
            }
            else if (expr is MetaModuloAssignExpression) //416:3
            {
                return "%="; //416:39
            }
            else if (expr is MetaAddAssignExpression) //417:3
            {
                return "+="; //417:36
            }
            else if (expr is MetaSubtractAssignExpression) //418:3
            {
                return "-="; //418:41
            }
            else if (expr is MetaLeftShiftAssignExpression) //419:3
            {
                return "<<="; //419:42
            }
            else if (expr is MetaRightShiftAssignExpression) //420:3
            {
                return ">>="; //420:43
            }
            else if (expr is MetaAndAssignExpression) //421:3
            {
                return "&="; //421:36
            }
            else if (expr is MetaExclusiveOrAssignExpression) //422:3
            {
                return "^="; //422:44
            }
            else if (expr is MetaOrAssignExpression) //423:3
            {
                return "|="; //423:35
            }
            else //424:3
            {
                return ""; //424:12
            }//425:2
        }

        public string GetTypeName(MetaExpression expr) //428:1
        {
            if (expr is MetaTypeOfExpression) //429:2
            {
                return ((MetaTypeOfExpression)expr).TypeReference.CSharpName(); //429:36
            }
            else //430:2
            {
                return null; //430:7
            }
        }

        public MetaSynthetizedPropertyInitializer GetSynthetizedInitializerFor(MetaClass cls, MetaProperty prop) //434:1
        {
            MetaSynthetizedPropertyInitializer lastInit = null; //435:2
            var __loop25_results = 
                (from __loop25_var1 in __Enumerate((cls).GetEnumerator()) //436:7
                from sup in __Enumerate((__loop25_var1.GetAllSuperClasses(true)).GetEnumerator()) //436:12
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //436:42
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //436:55
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaSynthetizedPropertyInitializer>() //436:69
                select new { __loop25_var1 = __loop25_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //436:2
            int __loop25_iteration = 0;
            foreach (var __tmp1 in __loop25_results)
            {
                ++__loop25_iteration;
                var __loop25_var1 = __tmp1.__loop25_var1;
                var sup = __tmp1.sup;
                var Constructor = __tmp1.Constructor;
                var Initializers = __tmp1.Initializers;
                var init = __tmp1.init;
                if (init.Property == prop) //437:3
                {
                    lastInit = init; //438:4
                }
            }
            return lastInit; //441:2
        }

        public string GenerateConstructorImpl(MetaModel model, MetaClass cls) //444:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public "; //445:1
            string __tmp2Suffix = "() "; //445:30
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
                    __out.AppendLine(); //445:33
                }
            }
            __out.Append("{"); //446:1
            __out.AppendLine(); //446:2
            var __loop26_results = 
                (from __loop26_var1 in __Enumerate((cls).GetEnumerator()) //447:8
                from prop in __Enumerate((__loop26_var1.GetAllProperties()).GetEnumerator()) //447:13
                select new { __loop26_var1 = __loop26_var1, prop = prop}
                ).ToList(); //447:3
            int __loop26_iteration = 0;
            foreach (var __tmp4 in __loop26_results)
            {
                ++__loop26_iteration;
                var __loop26_var1 = __tmp4.__loop26_var1;
                var prop = __tmp4.prop;
                MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //448:4
                if (synInit != null) //449:4
                {
                    if (prop.Kind != MetaPropertyKind.Derived) //450:5
                    {
                        if (ModelContext.Current.Compiler.TypeProvider.GetTypeOf(synInit.Value) is MetaCollectionType) //451:6
                        {
                            string __tmp5Prefix = "    this.MLazySet("; //452:1
                            string __tmp6Suffix = "));"; //452:149
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
                            string __tmp8Line = "."; //452:43
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
                            string __tmp10Line = "."; //452:69
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
                            string __tmp12Line = "Property, new Lazy<object>(() => "; //452:81
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
                                    __out.AppendLine(); //452:152
                                }
                            }
                        }
                        else //453:6
                        {
                            string __tmp14Prefix = "    this.MLazySet("; //454:1
                            string __tmp15Suffix = "));"; //454:149
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
                            string __tmp17Line = "."; //454:43
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
                            string __tmp19Line = "."; //454:69
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
                            string __tmp21Line = "Property, new Lazy<object>(() => "; //454:81
                            __out.Append(__tmp21Line);
                            StringBuilder __tmp22 = new StringBuilder();
                            __tmp22.Append(GenerateExpression(synInit.Value));
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
                                    __out.Append(__tmp15Suffix);
                                    __out.AppendLine(); //454:152
                                }
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
                            string __tmp23Prefix = "    this.MSet("; //460:1
                            string __tmp24Suffix = "));"; //460:154
                            StringBuilder __tmp25 = new StringBuilder();
                            __tmp25.Append(model.CSharpFullName());
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
                                }
                            }
                            string __tmp26Line = "."; //460:39
                            __out.Append(__tmp26Line);
                            StringBuilder __tmp27 = new StringBuilder();
                            __tmp27.Append(prop.Class.CSharpName());
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
                            string __tmp28Line = "."; //460:65
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
                            string __tmp30Line = "Property, new "; //460:77
                            __out.Append(__tmp30Line);
                            StringBuilder __tmp31 = new StringBuilder();
                            __tmp31.Append(prop.Type.CSharpName());
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
                            string __tmp32Line = "("; //460:115
                            __out.Append(__tmp32Line);
                            StringBuilder __tmp33 = new StringBuilder();
                            __tmp33.Append(GetCollectionConstructorParams(prop));
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
                                    __out.Append(__tmp24Suffix);
                                    __out.AppendLine(); //460:157
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //461:6
                        {
                            string __tmp34Prefix = "    this.MLazySet("; //462:1
                            string __tmp35Suffix = "(this)));"; //462:201
                            StringBuilder __tmp36 = new StringBuilder();
                            __tmp36.Append(model.CSharpFullName());
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
                            string __tmp37Line = "."; //462:43
                            __out.Append(__tmp37Line);
                            StringBuilder __tmp38 = new StringBuilder();
                            __tmp38.Append(prop.Class.CSharpName());
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
                            string __tmp39Line = "."; //462:69
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
                            string __tmp41Line = "Property, new Lazy<object>(() => "; //462:81
                            __out.Append(__tmp41Line);
                            StringBuilder __tmp42 = new StringBuilder();
                            __tmp42.Append(model.Name);
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
                            string __tmp43Line = "ImplementationProvider.Implementation."; //462:126
                            __out.Append(__tmp43Line);
                            StringBuilder __tmp44 = new StringBuilder();
                            __tmp44.Append(prop.Class.CSharpName());
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
                            string __tmp45Line = "_"; //462:189
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
                                    __out.Append(__tmp35Suffix);
                                    __out.AppendLine(); //462:210
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Readonly) //463:6
                        {
                            string __tmp47Prefix = "    // Init "; //464:1
                            string __tmp48Suffix = string.Empty; 
                            StringBuilder __tmp49 = new StringBuilder();
                            __tmp49.Append(model.CSharpFullName());
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
                            string __tmp50Line = "."; //464:37
                            __out.Append(__tmp50Line);
                            StringBuilder __tmp51 = new StringBuilder();
                            __tmp51.Append(prop.Class.CSharpName());
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
                            string __tmp52Line = "."; //464:63
                            __out.Append(__tmp52Line);
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
                                    __out.Append(__tmp53Line);
                                }
                            }
                            string __tmp54Line = "Property in "; //464:75
                            __out.Append(__tmp54Line);
                            StringBuilder __tmp55 = new StringBuilder();
                            __tmp55.Append(model.Name);
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
                            string __tmp56Line = "Implementation."; //464:99
                            __out.Append(__tmp56Line);
                            StringBuilder __tmp57 = new StringBuilder();
                            __tmp57.Append(cls.CSharpName());
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
                            string __tmp58Line = "_"; //464:132
                            __out.Append(__tmp58Line);
                            StringBuilder __tmp59 = new StringBuilder();
                            __tmp59.Append(cls.CSharpName());
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
                                    __out.Append(__tmp48Suffix);
                                    __out.AppendLine(); //464:151
                                }
                            }
                        }
                    }
                    else //466:5
                    {
                        if (prop.Kind == MetaPropertyKind.Lazy) //467:6
                        {
                            string __tmp60Prefix = "    this.MLazySet("; //468:1
                            string __tmp61Suffix = "(this)));"; //468:201
                            StringBuilder __tmp62 = new StringBuilder();
                            __tmp62.Append(model.CSharpFullName());
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
                                }
                            }
                            string __tmp63Line = "."; //468:43
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
                                }
                            }
                            string __tmp65Line = "."; //468:69
                            __out.Append(__tmp65Line);
                            StringBuilder __tmp66 = new StringBuilder();
                            __tmp66.Append(prop.Name);
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
                                    __out.Append(__tmp66Line);
                                }
                            }
                            string __tmp67Line = "Property, new Lazy<object>(() => "; //468:81
                            __out.Append(__tmp67Line);
                            StringBuilder __tmp68 = new StringBuilder();
                            __tmp68.Append(model.Name);
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
                            string __tmp69Line = "ImplementationProvider.Implementation."; //468:126
                            __out.Append(__tmp69Line);
                            StringBuilder __tmp70 = new StringBuilder();
                            __tmp70.Append(prop.Class.CSharpName());
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
                            string __tmp71Line = "_"; //468:189
                            __out.Append(__tmp71Line);
                            StringBuilder __tmp72 = new StringBuilder();
                            __tmp72.Append(prop.Name);
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
                                    __out.Append(__tmp61Suffix);
                                    __out.AppendLine(); //468:210
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Readonly) //469:6
                        {
                            string __tmp73Prefix = "    // Init "; //470:1
                            string __tmp74Suffix = string.Empty; 
                            StringBuilder __tmp75 = new StringBuilder();
                            __tmp75.Append(model.CSharpFullName());
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
                                    __out.Append(__tmp73Prefix);
                                    __out.Append(__tmp75Line);
                                }
                            }
                            string __tmp76Line = "."; //470:37
                            __out.Append(__tmp76Line);
                            StringBuilder __tmp77 = new StringBuilder();
                            __tmp77.Append(prop.Class.CSharpName());
                            using(StreamReader __tmp77Reader = new StreamReader(this.__ToStream(__tmp77.ToString())))
                            {
                                bool __tmp77_first = true;
                                while(__tmp77_first || !__tmp77Reader.EndOfStream)
                                {
                                    __tmp77_first = false;
                                    string __tmp77Line = __tmp77Reader.ReadLine();
                                    if (__tmp77Line == null)
                                    {
                                        __tmp77Line = "";
                                    }
                                    __out.Append(__tmp77Line);
                                }
                            }
                            string __tmp78Line = "."; //470:63
                            __out.Append(__tmp78Line);
                            StringBuilder __tmp79 = new StringBuilder();
                            __tmp79.Append(prop.Name);
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
                                    __out.Append(__tmp79Line);
                                }
                            }
                            string __tmp80Line = "Property in "; //470:75
                            __out.Append(__tmp80Line);
                            StringBuilder __tmp81 = new StringBuilder();
                            __tmp81.Append(model.Name);
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
                                }
                            }
                            string __tmp82Line = "Implementation."; //470:99
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
                            string __tmp84Line = "_"; //470:132
                            __out.Append(__tmp84Line);
                            StringBuilder __tmp85 = new StringBuilder();
                            __tmp85.Append(cls.CSharpName());
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
                                    __out.Append(__tmp74Suffix);
                                    __out.AppendLine(); //470:151
                                }
                            }
                        }
                    }
                }
            }
            var __loop27_results = 
                (from __loop27_var1 in __Enumerate((cls).GetEnumerator()) //475:8
                from sup in __Enumerate((__loop27_var1.GetAllSuperClasses(true)).GetEnumerator()) //475:13
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //475:43
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //475:56
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaInheritedPropertyInitializer>() //475:70
                select new { __loop27_var1 = __loop27_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //475:3
            int __loop27_iteration = 0;
            foreach (var __tmp86 in __loop27_results)
            {
                ++__loop27_iteration;
                var __loop27_var1 = __tmp86.__loop27_var1;
                var sup = __tmp86.sup;
                var Constructor = __tmp86.Constructor;
                var Initializers = __tmp86.Initializers;
                var init = __tmp86.init;
                if (init.Object != null && init.Property != null) //476:4
                {
                    string __tmp87Prefix = "    this.MLazySetChild("; //477:1
                    string __tmp88Suffix = "));"; //477:293
                    StringBuilder __tmp89 = new StringBuilder();
                    __tmp89.Append(init.Object.Class.Model.CSharpFullName());
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
                            __out.Append(__tmp87Prefix);
                            __out.Append(__tmp89Line);
                        }
                    }
                    string __tmp90Line = "."; //477:66
                    __out.Append(__tmp90Line);
                    StringBuilder __tmp91 = new StringBuilder();
                    __tmp91.Append(init.Object.Class.CSharpName());
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
                    string __tmp92Line = "."; //477:99
                    __out.Append(__tmp92Line);
                    StringBuilder __tmp93 = new StringBuilder();
                    __tmp93.Append(init.Object.Name);
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
                        }
                    }
                    string __tmp94Line = "Property, "; //477:118
                    __out.Append(__tmp94Line);
                    StringBuilder __tmp95 = new StringBuilder();
                    __tmp95.Append(init.Property.Class.Model.CSharpFullName());
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
                            __out.Append(__tmp95Line);
                        }
                    }
                    string __tmp96Line = "."; //477:172
                    __out.Append(__tmp96Line);
                    StringBuilder __tmp97 = new StringBuilder();
                    __tmp97.Append(init.Property.Class.CSharpName());
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
                    string __tmp98Line = "."; //477:207
                    __out.Append(__tmp98Line);
                    StringBuilder __tmp99 = new StringBuilder();
                    __tmp99.Append(init.Property.Name);
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
                    string __tmp100Line = "Property, new Lazy<object>(() => "; //477:228
                    __out.Append(__tmp100Line);
                    StringBuilder __tmp101 = new StringBuilder();
                    __tmp101.Append(GenerateExpression(init.Value));
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
                            __out.Append(__tmp88Suffix);
                            __out.AppendLine(); //477:296
                        }
                    }
                }
            }
            string __tmp102Prefix = "    "; //480:1
            string __tmp103Suffix = "(this);"; //480:96
            StringBuilder __tmp104 = new StringBuilder();
            __tmp104.Append(cls.Model.Name);
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
                    __out.Append(__tmp102Prefix);
                    __out.Append(__tmp104Line);
                }
            }
            string __tmp105Line = "ImplementationProvider.Implementation."; //480:21
            __out.Append(__tmp105Line);
            StringBuilder __tmp106 = new StringBuilder();
            __tmp106.Append(cls.CSharpName());
            using(StreamReader __tmp106Reader = new StreamReader(this.__ToStream(__tmp106.ToString())))
            {
                bool __tmp106_first = true;
                while(__tmp106_first || !__tmp106Reader.EndOfStream)
                {
                    __tmp106_first = false;
                    string __tmp106Line = __tmp106Reader.ReadLine();
                    if (__tmp106Line == null)
                    {
                        __tmp106Line = "";
                    }
                    __out.Append(__tmp106Line);
                }
            }
            string __tmp107Line = "_"; //480:77
            __out.Append(__tmp107Line);
            StringBuilder __tmp108 = new StringBuilder();
            __tmp108.Append(cls.CSharpName());
            using(StreamReader __tmp108Reader = new StreamReader(this.__ToStream(__tmp108.ToString())))
            {
                bool __tmp108_first = true;
                while(__tmp108_first || !__tmp108Reader.EndOfStream)
                {
                    __tmp108_first = false;
                    string __tmp108Line = __tmp108Reader.ReadLine();
                    if (__tmp108Line == null)
                    {
                        __tmp108Line = "";
                    }
                    __out.Append(__tmp108Line);
                    __out.Append(__tmp103Suffix);
                    __out.AppendLine(); //480:103
                }
            }
            var __loop28_results = 
                (from __loop28_var1 in __Enumerate((cls).GetEnumerator()) //481:11
                from prop in __Enumerate((__loop28_var1.GetAllProperties()).GetEnumerator()) //481:16
                select new { __loop28_var1 = __loop28_var1, prop = prop}
                ).ToList(); //481:6
            int __loop28_iteration = 0;
            foreach (var __tmp109 in __loop28_results)
            {
                ++__loop28_iteration;
                var __loop28_var1 = __tmp109.__loop28_var1;
                var prop = __tmp109.prop;
                if (prop.Kind == MetaPropertyKind.Readonly) //482:4
                {
                    string __tmp110Prefix = "    if (!this.MIsSet("; //483:1
                    string __tmp111Suffix = "().\");"; //483:258
                    StringBuilder __tmp112 = new StringBuilder();
                    __tmp112.Append(model.CSharpFullName());
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
                            __out.Append(__tmp110Prefix);
                            __out.Append(__tmp112Line);
                        }
                    }
                    string __tmp113Line = "."; //483:46
                    __out.Append(__tmp113Line);
                    StringBuilder __tmp114 = new StringBuilder();
                    __tmp114.Append(prop.Class.CSharpName());
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
                    string __tmp115Line = "."; //483:72
                    __out.Append(__tmp115Line);
                    StringBuilder __tmp116 = new StringBuilder();
                    __tmp116.Append(prop.Name);
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
                        }
                    }
                    string __tmp117Line = "Property)) throw new ModelException(\"Readonly property "; //483:84
                    __out.Append(__tmp117Line);
                    StringBuilder __tmp118 = new StringBuilder();
                    __tmp118.Append(model.CSharpName());
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
                    string __tmp119Line = "."; //483:159
                    __out.Append(__tmp119Line);
                    StringBuilder __tmp120 = new StringBuilder();
                    __tmp120.Append(prop.Class.CSharpName());
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
                    string __tmp121Line = "."; //483:185
                    __out.Append(__tmp121Line);
                    StringBuilder __tmp122 = new StringBuilder();
                    __tmp122.Append(prop.Name);
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
                        }
                    }
                    string __tmp123Line = "Property was not set in "; //483:197
                    __out.Append(__tmp123Line);
                    StringBuilder __tmp124 = new StringBuilder();
                    __tmp124.Append(cls.CSharpName());
                    using(StreamReader __tmp124Reader = new StreamReader(this.__ToStream(__tmp124.ToString())))
                    {
                        bool __tmp124_first = true;
                        while(__tmp124_first || !__tmp124Reader.EndOfStream)
                        {
                            __tmp124_first = false;
                            string __tmp124Line = __tmp124Reader.ReadLine();
                            if (__tmp124Line == null)
                            {
                                __tmp124Line = "";
                            }
                            __out.Append(__tmp124Line);
                        }
                    }
                    string __tmp125Line = "_"; //483:239
                    __out.Append(__tmp125Line);
                    StringBuilder __tmp126 = new StringBuilder();
                    __tmp126.Append(cls.CSharpName());
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
                            __out.Append(__tmp126Line);
                            __out.Append(__tmp111Suffix);
                            __out.AppendLine(); //483:264
                        }
                    }
                }
            }
            __out.Append("    this.MMakeDefault();"); //486:1
            __out.AppendLine(); //486:25
            __out.Append("}"); //487:1
            __out.AppendLine(); //487:2
            return __out.ToString();
        }

        public string GetReturn(MetaOperation op) //490:1
        {
            if (op.ReturnType.CSharpName() == "void") //491:5
            {
                return ""; //492:3
            }
            else //493:2
            {
                return "return "; //494:3
            }
        }

        public string GenerateOperationImpl(MetaModel model, MetaOperation op) //498:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //499:2
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = ")"; //500:97
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
            string __tmp4Line = " "; //500:35
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
            string __tmp6Line = "."; //500:60
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
            string __tmp8Line = "("; //500:70
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
                    __out.AppendLine(); //500:98
                }
            }
            __out.Append("{"); //501:1
            __out.AppendLine(); //501:2
            string __tmp10Prefix = "    "; //502:1
            string __tmp11Suffix = ");"; //502:136
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
            __tmp13.Append(model.Name);
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
            string __tmp14Line = "ImplementationProvider.Implementation."; //502:32
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
            string __tmp16Line = "_"; //502:94
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
            string __tmp18Line = "("; //502:104
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
                    __out.AppendLine(); //502:138
                }
            }
            __out.Append("}"); //503:1
            __out.AppendLine(); //503:2
            return __out.ToString();
        }

        public string GetSuperClasses(MetaClass cls) //506:1
        {
            string result = ""; //507:2
            var __loop29_results = 
                (from __loop29_var1 in __Enumerate((cls).GetEnumerator()) //508:10
                from sup in __Enumerate((__loop29_var1.SuperClasses).GetEnumerator()) //508:15
                select new { __loop29_var1 = __loop29_var1, sup = sup}
                ).ToList(); //508:5
            int __loop29_iteration = 0;
            string delim = ""; //508:33
            foreach (var __tmp1 in __loop29_results)
            {
                ++__loop29_iteration;
                if (__loop29_iteration >= 2) //508:52
                {
                    delim = ", "; //508:52
                }
                var __loop29_var1 = __tmp1.__loop29_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpName(); //509:3
            }
            return result; //511:2
        }

        public string GetAllSuperClasses(MetaClass cls) //514:1
        {
            string result = ""; //515:2
            var __loop30_results = 
                (from __loop30_var1 in __Enumerate((cls).GetEnumerator()) //516:10
                from sup in __Enumerate((__loop30_var1.GetAllSuperClasses(false)).GetEnumerator()) //516:15
                select new { __loop30_var1 = __loop30_var1, sup = sup}
                ).ToList(); //516:5
            int __loop30_iteration = 0;
            string delim = ""; //516:46
            foreach (var __tmp1 in __loop30_results)
            {
                ++__loop30_iteration;
                if (__loop30_iteration >= 2) //516:65
                {
                    delim = ", "; //516:65
                }
                var __loop30_var1 = __tmp1.__loop30_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpName(); //517:3
            }
            return result; //519:2
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //522:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public static class "; //523:1
            string __tmp2Suffix = "Descriptor"; //523:33
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
                    __out.AppendLine(); //523:43
                }
            }
            __out.Append("{"); //524:1
            __out.AppendLine(); //524:2
            string __tmp4Prefix = "    static "; //525:1
            string __tmp5Suffix = "Descriptor()"; //525:24
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
                    __out.AppendLine(); //525:36
                }
            }
            __out.Append("    {"); //526:1
            __out.AppendLine(); //526:6
            var __loop31_results = 
                (from __loop31_var1 in __Enumerate((model).GetEnumerator()) //527:11
                from Namespace in __Enumerate((__loop31_var1.Namespace).GetEnumerator()) //527:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //527:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //527:43
                select new { __loop31_var1 = __loop31_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //527:6
            int __loop31_iteration = 0;
            foreach (var __tmp7 in __loop31_results)
            {
                ++__loop31_iteration;
                var __loop31_var1 = __tmp7.__loop31_var1;
                var Namespace = __tmp7.Namespace;
                var Declarations = __tmp7.Declarations;
                var cls = __tmp7.cls;
                string __tmp8Prefix = "        "; //528:1
                string __tmp9Suffix = ".StaticInit();"; //528:27
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
                        __out.AppendLine(); //528:41
                    }
                }
            }
            __out.Append("    }"); //530:1
            __out.AppendLine(); //530:6
            __out.AppendLine(); //531:2
            __out.Append("    internal static void StaticInit()"); //532:1
            __out.AppendLine(); //532:38
            __out.Append("    {"); //533:1
            __out.AppendLine(); //533:6
            __out.Append("    }"); //534:1
            __out.AppendLine(); //534:6
            __out.AppendLine(); //535:2
            string __tmp11Prefix = "	public const string Uri = \""; //536:1
            string __tmp12Suffix = "\";"; //536:40
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
                    __out.AppendLine(); //536:42
                }
            }
            __out.AppendLine(); //537:2
            __out.Append("    public static class Constants"); //538:1
            __out.AppendLine(); //538:34
            __out.Append("    {"); //539:1
            __out.AppendLine(); //539:6
            __out.Append("        static Constants()"); //540:1
            __out.AppendLine(); //540:27
            __out.Append("        {"); //541:1
            __out.AppendLine(); //541:10
            var __loop32_results = 
                (from __loop32_var1 in __Enumerate((model).GetEnumerator()) //542:11
                from Namespace in __Enumerate((__loop32_var1.Namespace).GetEnumerator()) //542:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //542:29
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //542:43
                select new { __loop32_var1 = __loop32_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //542:6
            int __loop32_iteration = 0;
            foreach (var __tmp14 in __loop32_results)
            {
                ++__loop32_iteration;
                var __loop32_var1 = __tmp14.__loop32_var1;
                var Namespace = __tmp14.Namespace;
                var Declarations = __tmp14.Declarations;
                var c = __tmp14.c;
                string __tmp15Prefix = "            "; //543:1
                string __tmp16Suffix = string.Empty; 
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(GenerateModelConstantImpl(model, c));
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
                        __out.AppendLine(); //543:50
                    }
                }
            }
            __out.AppendLine(); //545:2
            var __loop33_results = 
                (from __loop33_var1 in __Enumerate((model).GetEnumerator()) //546:11
                from Namespace in __Enumerate((__loop33_var1.Namespace).GetEnumerator()) //546:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //546:29
                from f in __Enumerate((Declarations).GetEnumerator()).OfType<MetaFunction>() //546:43
                select new { __loop33_var1 = __loop33_var1, Namespace = Namespace, Declarations = Declarations, f = f}
                ).ToList(); //546:6
            int __loop33_iteration = 0;
            foreach (var __tmp18 in __loop33_results)
            {
                ++__loop33_iteration;
                var __loop33_var1 = __tmp18.__loop33_var1;
                var Namespace = __tmp18.Namespace;
                var Declarations = __tmp18.Declarations;
                var f = __tmp18.f;
                string __tmp19Prefix = "            "; //547:1
                string __tmp20Suffix = string.Empty; 
                StringBuilder __tmp21 = new StringBuilder();
                __tmp21.Append(GenerateModelFunctionImpl(model, f));
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
                        __out.AppendLine(); //547:50
                    }
                }
            }
            __out.Append("        }"); //549:1
            __out.AppendLine(); //549:10
            __out.AppendLine(); //550:2
            var __loop34_results = 
                (from __loop34_var1 in __Enumerate((model).GetEnumerator()) //551:11
                from Namespace in __Enumerate((__loop34_var1.Namespace).GetEnumerator()) //551:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //551:29
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //551:43
                select new { __loop34_var1 = __loop34_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //551:6
            int __loop34_iteration = 0;
            foreach (var __tmp22 in __loop34_results)
            {
                ++__loop34_iteration;
                var __loop34_var1 = __tmp22.__loop34_var1;
                var Namespace = __tmp22.Namespace;
                var Declarations = __tmp22.Declarations;
                var c = __tmp22.c;
                string __tmp23Prefix = "        "; //552:1
                string __tmp24Suffix = string.Empty; 
                StringBuilder __tmp25 = new StringBuilder();
                __tmp25.Append(GenerateModelConstant(model, c));
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
                        __out.AppendLine(); //552:42
                    }
                }
            }
            __out.AppendLine(); //554:2
            var __loop35_results = 
                (from __loop35_var1 in __Enumerate((model).GetEnumerator()) //555:11
                from Namespace in __Enumerate((__loop35_var1.Namespace).GetEnumerator()) //555:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //555:29
                from f in __Enumerate((Declarations).GetEnumerator()).OfType<MetaFunction>() //555:43
                select new { __loop35_var1 = __loop35_var1, Namespace = Namespace, Declarations = Declarations, f = f}
                ).ToList(); //555:6
            int __loop35_iteration = 0;
            foreach (var __tmp26 in __loop35_results)
            {
                ++__loop35_iteration;
                var __loop35_var1 = __tmp26.__loop35_var1;
                var Namespace = __tmp26.Namespace;
                var Declarations = __tmp26.Declarations;
                var f = __tmp26.f;
                string __tmp27Prefix = "        "; //556:1
                string __tmp28Suffix = string.Empty; 
                StringBuilder __tmp29 = new StringBuilder();
                __tmp29.Append(GenerateModelFunction(model, f));
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
                        __out.AppendLine(); //556:42
                    }
                }
            }
            __out.Append("    }"); //558:1
            __out.AppendLine(); //558:6
            __out.AppendLine(); //559:2
            var __loop36_results = 
                (from __loop36_var1 in __Enumerate((model).GetEnumerator()) //560:11
                from Namespace in __Enumerate((__loop36_var1.Namespace).GetEnumerator()) //560:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //560:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //560:43
                select new { __loop36_var1 = __loop36_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //560:6
            int __loop36_iteration = 0;
            foreach (var __tmp30 in __loop36_results)
            {
                ++__loop36_iteration;
                var __loop36_var1 = __tmp30.__loop36_var1;
                var Namespace = __tmp30.Namespace;
                var Declarations = __tmp30.Declarations;
                var cls = __tmp30.cls;
                string __tmp31Prefix = "    "; //561:1
                string __tmp32Suffix = string.Empty; 
                StringBuilder __tmp33 = new StringBuilder();
                __tmp33.Append(GenerateMetaModelClass(cls));
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
                        __out.AppendLine(); //561:34
                    }
                }
            }
            __out.Append("}"); //563:1
            __out.AppendLine(); //563:2
            __out.AppendLine(); //564:2
            return __out.ToString();
        }

        public string GenerateMetaModelClass(MetaClass cls) //568:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //569:2
            string __tmp1Prefix = "public static class "; //570:1
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
                    __out.AppendLine(); //570:39
                }
            }
            __out.Append("{"); //571:1
            __out.AppendLine(); //571:2
            __out.Append("    internal static void StaticInit()"); //572:1
            __out.AppendLine(); //572:38
            __out.Append("    {"); //573:1
            __out.AppendLine(); //573:6
            __out.Append("    }"); //574:1
            __out.AppendLine(); //574:6
            __out.AppendLine(); //575:2
            string __tmp4Prefix = "    static "; //576:1
            string __tmp5Suffix = "()"; //576:30
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
                    __out.AppendLine(); //576:32
                }
            }
            __out.Append("    {"); //577:1
            __out.AppendLine(); //577:6
            string __tmp7Prefix = "        "; //578:1
            string __tmp8Suffix = ".StaticInit();"; //578:37
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
                    __out.AppendLine(); //578:51
                }
            }
            __out.Append("    }"); //579:1
            __out.AppendLine(); //579:6
            __out.AppendLine(); //580:2
            var __loop37_results = 
                (from __loop37_var1 in __Enumerate((cls).GetEnumerator()) //581:11
                from prop in __Enumerate((__loop37_var1.Properties).GetEnumerator()) //581:16
                select new { __loop37_var1 = __loop37_var1, prop = prop}
                ).ToList(); //581:6
            int __loop37_iteration = 0;
            foreach (var __tmp10 in __loop37_results)
            {
                ++__loop37_iteration;
                var __loop37_var1 = __tmp10.__loop37_var1;
                var prop = __tmp10.prop;
                string __tmp11Prefix = "    "; //582:1
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
                        __out.AppendLine(); //582:56
                    }
                }
            }
            __out.Append("}"); //584:1
            __out.AppendLine(); //584:2
            return __out.ToString();
        }

        public string GenerateModelConstant(MetaModel model, MetaConstant mconst) //588:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public static readonly "; //589:1
            string __tmp2Suffix = ";"; //589:68
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
            string __tmp4Line = " "; //589:54
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
                    __out.AppendLine(); //589:69
                }
            }
            return __out.ToString();
        }

        public string GenerateModelFunction(MetaModel model, MetaFunction mfunc) //592:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public static readonly global::MetaDslx.Core.MetaFunction "; //593:1
            string __tmp2Suffix = ";"; //593:71
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
                    __out.AppendLine(); //593:72
                }
            }
            return __out.ToString();
        }

        public string GenerateModelConstantImpl(MetaModel model, MetaConstant mconst) //596:1
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
                    __out.AppendLine(); //597:67
                }
            }
            return __out.ToString();
        }

        public string GenerateModelFunctionImpl(MetaModel model, MetaFunction mfunc) //600:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = "Factory.Instance.CreateMetaFunction();"; //601:50
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
                }
            }
            string __tmp4Line = " = global::MetaDslx.Core."; //601:13
            __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(model.Name);
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
                    __out.AppendLine(); //601:88
                }
            }
            if ((from __loop38_var1 in __Enumerate((mfunc).GetEnumerator()) //602:14
            from a in __Enumerate((__loop38_var1.Annotations).GetEnumerator()) //602:21
            where a.Name == "Name" //602:35
            select new { __loop38_var1 = __loop38_var1, a = a}
            ).GetEnumerator().MoveNext()) //602:2
            {
                var __loop39_results = 
                    (from __loop39_var1 in __Enumerate((mfunc).GetEnumerator()) //603:8
                    from a in __Enumerate((__loop39_var1.Annotations).GetEnumerator()) //603:15
                    from p in __Enumerate((a.Properties).GetEnumerator()) //603:30
                    where a.Name == "Name" && p.Name == "Name" //603:43
                    select new { __loop39_var1 = __loop39_var1, a = a, p = p}
                    ).ToList(); //603:3
                int __loop39_iteration = 0;
                foreach (var __tmp6 in __loop39_results)
                {
                    ++__loop39_iteration;
                    var __loop39_var1 = __tmp6.__loop39_var1;
                    var a = __tmp6.a;
                    var p = __tmp6.p;
                    string __tmp7Prefix = string.Empty; 
                    string __tmp8Suffix = ";"; //604:50
                    StringBuilder __tmp9 = new StringBuilder();
                    __tmp9.Append(mfunc.Name);
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
                    string __tmp10Line = ".Name = "; //604:13
                    __out.Append(__tmp10Line);
                    StringBuilder __tmp11 = new StringBuilder();
                    __tmp11.Append(GenerateExpression(p.Value));
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
                            __out.AppendLine(); //604:51
                        }
                    }
                }
            }
            else //606:2
            {
                string __tmp12Prefix = string.Empty; 
                string __tmp13Suffix = "\";"; //607:34
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
                        __out.Append(__tmp12Prefix);
                        __out.Append(__tmp14Line);
                    }
                }
                string __tmp15Line = ".Name = \""; //607:13
                __out.Append(__tmp15Line);
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(mfunc.Name);
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
                        __out.AppendLine(); //607:36
                    }
                }
            }
            string __tmp17Prefix = string.Empty;
            string __tmp18Suffix = string.Empty;
            StringBuilder __tmp19 = new StringBuilder();
            __tmp19.Append(GenerateModelFunctionImplTypeOf(model, mfunc.Name, "global::MetaDslx.Core." + model.Name + "Descriptor.MetaFunction.ReturnTypeProperty", mfunc.ReturnType));
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
                    __out.AppendLine(); //609:153
                }
            }
            var __loop40_results = 
                (from __loop40_var1 in __Enumerate((mfunc).GetEnumerator()) //610:7
                from p in __Enumerate((__loop40_var1.Parameters).GetEnumerator()) //610:14
                select new { __loop40_var1 = __loop40_var1, p = p}
                ).ToList(); //610:2
            int __loop40_iteration = 0;
            foreach (var __tmp20 in __loop40_results)
            {
                ++__loop40_iteration;
                var __loop40_var1 = __tmp20.__loop40_var1;
                var p = __tmp20.p;
                string tmpName = "tmp" + NextCounter(); //611:2
                string __tmp21Prefix = "global::MetaDslx.Core.MetaParameter "; //612:1
                string __tmp22Suffix = "Factory.Instance.CreateMetaParameter();"; //612:83
                StringBuilder __tmp23 = new StringBuilder();
                __tmp23.Append(tmpName);
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
                string __tmp24Line = " = global::MetaDslx.Core."; //612:46
                __out.Append(__tmp24Line);
                StringBuilder __tmp25 = new StringBuilder();
                __tmp25.Append(model.Name);
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
                        __out.AppendLine(); //612:122
                    }
                }
                string __tmp26Prefix = string.Empty; 
                string __tmp27Suffix = "\";"; //613:27
                StringBuilder __tmp28 = new StringBuilder();
                __tmp28.Append(tmpName);
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
                string __tmp29Line = ".Name = \""; //613:10
                __out.Append(__tmp29Line);
                StringBuilder __tmp30 = new StringBuilder();
                __tmp30.Append(p.Name);
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
                        __out.AppendLine(); //613:29
                    }
                }
                string __tmp31Prefix = string.Empty;
                string __tmp32Suffix = string.Empty;
                StringBuilder __tmp33 = new StringBuilder();
                __tmp33.Append(GenerateModelFunctionImplTypeOf(model, tmpName, "global::MetaDslx.Core." + model.Name + "Descriptor.MetaTypedElement.TypeProperty", p.Type));
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
                        __out.AppendLine(); //614:138
                    }
                }
                string __tmp34Prefix = string.Empty; 
                string __tmp35Suffix = ");"; //615:38
                StringBuilder __tmp36 = new StringBuilder();
                __tmp36.Append(mfunc.Name);
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
                string __tmp37Line = ".Parameters.Add("; //615:13
                __out.Append(__tmp37Line);
                StringBuilder __tmp38 = new StringBuilder();
                __tmp38.Append(tmpName);
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
                        __out.Append(__tmp35Suffix);
                        __out.AppendLine(); //615:40
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelFunctionImplTypeOf(MetaModel model, string name, string propertyName, MetaType mtype) //619:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = mtype; //620:9
            if (mtype is MetaCollectionType) //621:2
            {
                string tmpName = "tmp" + NextCounter(); //622:2
                string __tmp2Prefix = "global::MetaDslx.Core.MetaCollectionType "; //623:1
                string __tmp3Suffix = "Factory.Instance.CreateMetaCollectionType();"; //623:88
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
                    }
                }
                string __tmp5Line = " = global::MetaDslx.Core."; //623:51
                __out.Append(__tmp5Line);
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
                        __out.Append(__tmp6Line);
                        __out.Append(__tmp3Suffix);
                        __out.AppendLine(); //623:132
                    }
                }
                string __tmp7Prefix = string.Empty; 
                string __tmp8Suffix = ";"; //624:49
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
                string __tmp10Line = ".Kind = MetaCollectionKind."; //624:10
                __out.Append(__tmp10Line);
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(((MetaCollectionType)mtype).Kind);
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
                        __out.AppendLine(); //624:50
                    }
                }
                string __tmp12Prefix = string.Empty;
                string __tmp13Suffix = string.Empty;
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(GenerateModelFunctionImplTypeOf(model, tmpName, "global::MetaDslx.Core." + model.Name + "Descriptor.MetaCollectionType.InnerTypeProperty", ((MetaCollectionType)mtype).InnerType));
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
                        __out.AppendLine(); //625:154
                    }
                }
                if (propertyName != null) //626:2
                {
                    string __tmp15Prefix = "((ModelObject)"; //627:1
                    string __tmp16Suffix = "));"; //627:80
                    StringBuilder __tmp17 = new StringBuilder();
                    __tmp17.Append(name);
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
                    string __tmp18Line = ").MLazyAdd("; //627:21
                    __out.Append(__tmp18Line);
                    StringBuilder __tmp19 = new StringBuilder();
                    __tmp19.Append(propertyName);
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
                    string __tmp20Line = ", new Lazy<object>(() => "; //627:46
                    __out.Append(__tmp20Line);
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
                            __out.Append(__tmp21Line);
                            __out.Append(__tmp16Suffix);
                            __out.AppendLine(); //627:83
                        }
                    }
                }
                else //628:2
                {
                    string __tmp22Prefix = string.Empty; 
                    string __tmp23Suffix = ";"; //629:19
                    StringBuilder __tmp24 = new StringBuilder();
                    __tmp24.Append(name);
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
                    string __tmp25Line = " = "; //629:7
                    __out.Append(__tmp25Line);
                    StringBuilder __tmp26 = new StringBuilder();
                    __tmp26.Append(tmpName);
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
                            __out.AppendLine(); //629:20
                        }
                    }
                }
            }
            else //631:2
            {
                if (propertyName != null) //632:2
                {
                    string __tmp27Prefix = "((ModelObject)"; //633:1
                    string __tmp28Suffix = "));"; //633:94
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
                    string __tmp30Line = ").MLazyAdd("; //633:21
                    __out.Append(__tmp30Line);
                    StringBuilder __tmp31 = new StringBuilder();
                    __tmp31.Append(propertyName);
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
                    string __tmp32Line = ", new Lazy<object>(() => "; //633:46
                    __out.Append(__tmp32Line);
                    StringBuilder __tmp33 = new StringBuilder();
                    __tmp33.Append(GenerateTypeOf(mtype));
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
                            __out.AppendLine(); //633:97
                        }
                    }
                }
                else //634:2
                {
                    string __tmp34Prefix = string.Empty; 
                    string __tmp35Suffix = ";"; //635:33
                    StringBuilder __tmp36 = new StringBuilder();
                    __tmp36.Append(name);
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
                    string __tmp37Line = " = "; //635:7
                    __out.Append(__tmp37Line);
                    StringBuilder __tmp38 = new StringBuilder();
                    __tmp38.Append(GenerateTypeOf(mtype));
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
                            __out.Append(__tmp35Suffix);
                            __out.AppendLine(); //635:34
                        }
                    }
                }
            }//637:2
            return __out.ToString();
        }

        public string GenerateMetaModelInstance(MetaModel model) //641:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public static class "; //642:1
            string __tmp2Suffix = "Instance"; //642:33
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
                    __out.AppendLine(); //642:41
                }
            }
            __out.Append("{"); //643:1
            __out.AppendLine(); //643:2
            __out.Append("    internal static global::MetaDslx.Core.Model model;"); //644:1
            __out.AppendLine(); //644:55
            __out.AppendLine(); //645:2
            string __tmp4Prefix = "    static "; //646:1
            string __tmp5Suffix = "Instance()"; //646:24
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
                    __out.AppendLine(); //646:34
                }
            }
            __out.Append("    {"); //647:1
            __out.AppendLine(); //647:6
            string __tmp7Prefix = "		"; //648:1
            string __tmp8Suffix = "Descriptor.StaticInit();"; //648:15
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
                    __out.AppendLine(); //648:39
                }
            }
            string __tmp10Prefix = "		"; //649:1
            string __tmp11Suffix = "Instance.model = new global::MetaDslx.Core.Model();"; //649:15
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
                    __out.AppendLine(); //649:66
                }
            }
            string __tmp13Prefix = "   		using (new ModelContextScope("; //650:1
            string __tmp14Suffix = "Instance.model))"; //650:47
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
                    __out.Append(__tmp14Suffix);
                    __out.AppendLine(); //650:63
                }
            }
            __out.Append("		{"); //651:1
            __out.AppendLine(); //651:4
            var __loop41_results = 
                (from __loop41_var1 in __Enumerate((model).GetEnumerator()) //652:10
                from Namespace in __Enumerate((__loop41_var1.Namespace).GetEnumerator()) //652:17
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //652:28
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //652:42
                select new { __loop41_var1 = __loop41_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //652:5
            int __loop41_iteration = 0;
            foreach (var __tmp16 in __loop41_results)
            {
                ++__loop41_iteration;
                var __loop41_var1 = __tmp16.__loop41_var1;
                var Namespace = __tmp16.Namespace;
                var Declarations = __tmp16.Declarations;
                var cls = __tmp16.cls;
                string __tmp17Prefix = "			"; //653:1
                string __tmp18Suffix = string.Empty; 
                StringBuilder __tmp19 = new StringBuilder();
                __tmp19.Append(GenerateClassMetaInstance(cls));
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
                        __out.AppendLine(); //653:36
                    }
                }
            }
            __out.AppendLine(); //655:2
            var __loop42_results = 
                (from __loop42_var1 in __Enumerate((model).GetEnumerator()) //656:10
                from Namespace in __Enumerate((__loop42_var1.Namespace).GetEnumerator()) //656:17
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //656:28
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //656:42
                select new { __loop42_var1 = __loop42_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //656:5
            int __loop42_iteration = 0;
            foreach (var __tmp20 in __loop42_results)
            {
                ++__loop42_iteration;
                var __loop42_var1 = __tmp20.__loop42_var1;
                var Namespace = __tmp20.Namespace;
                var Declarations = __tmp20.Declarations;
                var cls = __tmp20.cls;
                string __tmp21Prefix = "			"; //657:1
                string __tmp22Suffix = string.Empty; 
                StringBuilder __tmp23 = new StringBuilder();
                __tmp23.Append(GenerateClassMetaInstanceInitializer(cls));
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
                        __out.AppendLine(); //657:47
                    }
                }
            }
            __out.Append("		}"); //659:1
            __out.AppendLine(); //659:4
            __out.Append("    }"); //660:1
            __out.AppendLine(); //660:6
            __out.AppendLine(); //661:2
            __out.Append("    public static global::MetaDslx.Core.Model Model"); //662:1
            __out.AppendLine(); //662:52
            __out.Append("    {"); //663:1
            __out.AppendLine(); //663:6
            __out.Append("        get "); //664:1
            __out.AppendLine(); //664:13
            __out.Append("		{ "); //665:1
            __out.AppendLine(); //665:5
            string __tmp24Prefix = "			return "; //666:1
            string __tmp25Suffix = "Instance.model; "; //666:23
            StringBuilder __tmp26 = new StringBuilder();
            __tmp26.Append(model.Name);
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
                    __out.AppendLine(); //666:39
                }
            }
            __out.Append("		}"); //667:1
            __out.AppendLine(); //667:4
            __out.Append("    }"); //668:1
            __out.AppendLine(); //668:6
            __out.AppendLine(); //669:2
            var __loop43_results = 
                (from __loop43_var1 in __Enumerate((model).GetEnumerator()) //670:8
                from Namespace in __Enumerate((__loop43_var1.Namespace).GetEnumerator()) //670:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //670:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //670:40
                select new { __loop43_var1 = __loop43_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //670:3
            int __loop43_iteration = 0;
            foreach (var __tmp27 in __loop43_results)
            {
                ++__loop43_iteration;
                var __loop43_var1 = __tmp27.__loop43_var1;
                var Namespace = __tmp27.Namespace;
                var Declarations = __tmp27.Declarations;
                var cls = __tmp27.cls;
                string __tmp28Prefix = "	public static readonly MetaClass "; //671:1
                string __tmp29Suffix = ";"; //671:53
                StringBuilder __tmp30 = new StringBuilder();
                __tmp30.Append(cls.CSharpName());
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
                        __out.AppendLine(); //671:54
                    }
                }
            }
            __out.Append("}"); //673:1
            __out.AppendLine(); //673:2
            return __out.ToString();
        }

        public string GenerateClassMetaInstance(MetaClass cls) //676:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = "Factory.Instance.CreateMetaClass();"; //677:60
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
            string __tmp4Line = " = global::MetaDslx.Core."; //677:19
            __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(cls.Model.Name);
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
                    __out.AppendLine(); //677:95
                }
            }
            return __out.ToString();
        }

        public string GenerateClassMetaInstanceInitializer(MetaClass cls) //680:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = "\";"; //681:46
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
            string __tmp4Line = ".Name = \""; //681:19
            __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(cls.CSharpName());
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
                    __out.AppendLine(); //681:48
                }
            }
            if (cls.IsAbstract) //682:2
            {
                string __tmp6Prefix = string.Empty; 
                string __tmp7Suffix = ".IsAbstract = true;"; //683:19
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(cls.CSharpName());
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
                        __out.AppendLine(); //683:38
                    }
                }
            }
            var __loop44_results = 
                (from __loop44_var1 in __Enumerate((cls).GetEnumerator()) //685:7
                from sup in __Enumerate((__loop44_var1.SuperClasses).GetEnumerator()) //685:12
                select new { __loop44_var1 = __loop44_var1, sup = sup}
                ).ToList(); //685:2
            int __loop44_iteration = 0;
            foreach (var __tmp9 in __loop44_results)
            {
                ++__loop44_iteration;
                var __loop44_var1 = __tmp9.__loop44_var1;
                var sup = __tmp9.sup;
                string __tmp10Prefix = string.Empty; 
                string __tmp11Suffix = ");"; //686:80
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
                    }
                }
                string __tmp13Line = ".SuperClasses.Add("; //686:19
                __out.Append(__tmp13Line);
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(sup.Model.Name);
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
                string __tmp15Line = "Instance."; //686:53
                __out.Append(__tmp15Line);
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(sup.CSharpName());
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
                        __out.Append(__tmp11Suffix);
                        __out.AppendLine(); //686:82
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //690:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "internal static class "; //691:1
            string __tmp2Suffix = "ImplementationProvider"; //691:35
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
                    __out.AppendLine(); //691:57
                }
            }
            __out.Append("{"); //692:1
            __out.AppendLine(); //692:2
            string __tmp4Prefix = "    // If there is a compile error at this line, create a new class called "; //693:1
            string __tmp5Suffix = "Implementation"; //693:88
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
                    __out.AppendLine(); //693:102
                }
            }
            string __tmp7Prefix = "	// which is a subclass of "; //694:1
            string __tmp8Suffix = "ImplementationBase:"; //694:40
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
                    __out.AppendLine(); //694:59
                }
            }
            string __tmp10Prefix = "    private static "; //695:1
            string __tmp11Suffix = "Implementation();"; //695:80
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
            string __tmp13Line = "Implementation implementation = new "; //695:32
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
                    __out.AppendLine(); //695:97
                }
            }
            __out.AppendLine(); //696:2
            string __tmp15Prefix = "    public static "; //697:1
            string __tmp16Suffix = "Implementation Implementation"; //697:31
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
                    __out.AppendLine(); //697:60
                }
            }
            __out.Append("    {"); //698:1
            __out.AppendLine(); //698:6
            string __tmp18Prefix = "        get { return "; //699:1
            string __tmp19Suffix = "ImplementationProvider.implementation; }"; //699:34
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
                    __out.AppendLine(); //699:74
                }
            }
            __out.Append("    }"); //700:1
            __out.AppendLine(); //700:6
            __out.Append("}"); //701:1
            __out.AppendLine(); //701:2
            var __loop45_results = 
                (from __loop45_var1 in __Enumerate((model).GetEnumerator()) //702:8
                from Namespace in __Enumerate((__loop45_var1.Namespace).GetEnumerator()) //702:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //702:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //702:40
                select new { __loop45_var1 = __loop45_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //702:3
            int __loop45_iteration = 0;
            foreach (var __tmp21 in __loop45_results)
            {
                ++__loop45_iteration;
                var __loop45_var1 = __tmp21.__loop45_var1;
                var Namespace = __tmp21.Namespace;
                var Declarations = __tmp21.Declarations;
                var enm = __tmp21.enm;
                __out.AppendLine(); //703:2
                string __tmp22Prefix = "public static class "; //704:1
                string __tmp23Suffix = "Extensions"; //704:31
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(enm.Name);
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
                        __out.AppendLine(); //704:41
                    }
                }
                __out.Append("{"); //705:1
                __out.AppendLine(); //705:2
                var __loop46_results = 
                    (from __loop46_var1 in __Enumerate((enm).GetEnumerator()) //706:11
                    from op in __Enumerate((__loop46_var1.Operations).GetEnumerator()) //706:16
                    select new { __loop46_var1 = __loop46_var1, op = op}
                    ).ToList(); //706:6
                int __loop46_iteration = 0;
                foreach (var __tmp25 in __loop46_results)
                {
                    ++__loop46_iteration;
                    var __loop46_var1 = __tmp25.__loop46_var1;
                    var op = __tmp25.op;
                    string __tmp26Prefix = "    public static "; //707:1
                    string __tmp27Suffix = ")"; //707:96
                    StringBuilder __tmp28 = new StringBuilder();
                    __tmp28.Append(op.ReturnType.CSharpPublicName());
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
                    string __tmp29Line = " "; //707:53
                    __out.Append(__tmp29Line);
                    StringBuilder __tmp30 = new StringBuilder();
                    __tmp30.Append(op.Name);
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
                    string __tmp31Line = "("; //707:63
                    __out.Append(__tmp31Line);
                    StringBuilder __tmp32 = new StringBuilder();
                    __tmp32.Append(GetEnumImplParameters(enm, op));
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
                            __out.Append(__tmp27Suffix);
                            __out.AppendLine(); //707:97
                        }
                    }
                    __out.Append("    {"); //708:1
                    __out.AppendLine(); //708:6
                    string __tmp33Prefix = "        "; //709:1
                    string __tmp34Suffix = ");"; //709:144
                    StringBuilder __tmp35 = new StringBuilder();
                    __tmp35.Append(GetReturn(op));
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
                        }
                    }
                    StringBuilder __tmp36 = new StringBuilder();
                    __tmp36.Append(model.Name);
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
                    string __tmp37Line = "ImplementationProvider.Implementation."; //709:36
                    __out.Append(__tmp37Line);
                    StringBuilder __tmp38 = new StringBuilder();
                    __tmp38.Append(op.Parent.CSharpName());
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
                    string __tmp39Line = "_"; //709:98
                    __out.Append(__tmp39Line);
                    StringBuilder __tmp40 = new StringBuilder();
                    __tmp40.Append(op.Name);
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
                    string __tmp41Line = "("; //709:108
                    __out.Append(__tmp41Line);
                    StringBuilder __tmp42 = new StringBuilder();
                    __tmp42.Append(GetEnumImplCallParameterNames(op));
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
                            __out.Append(__tmp34Suffix);
                            __out.AppendLine(); //709:146
                        }
                    }
                    __out.Append("    }"); //710:1
                    __out.AppendLine(); //710:6
                }
                __out.Append("}"); //712:1
                __out.AppendLine(); //712:2
            }
            __out.AppendLine(); //714:2
            __out.Append("/// <summary>"); //715:1
            __out.AppendLine(); //715:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //716:1
            __out.AppendLine(); //716:68
            string __tmp43Prefix = "/// This class has to be be overriden in "; //717:1
            string __tmp44Suffix = "Implementation to provide custom"; //717:54
            StringBuilder __tmp45 = new StringBuilder();
            __tmp45.Append(model.Name);
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
                    __out.AppendLine(); //717:86
                }
            }
            __out.Append("/// implementation for the constructors, operations and property values."); //718:1
            __out.AppendLine(); //718:73
            __out.Append("/// </summary>"); //719:1
            __out.AppendLine(); //719:15
            string __tmp46Prefix = "internal abstract class "; //720:1
            string __tmp47Suffix = "ImplementationBase"; //720:37
            StringBuilder __tmp48 = new StringBuilder();
            __tmp48.Append(model.Name);
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
                    __out.Append(__tmp47Suffix);
                    __out.AppendLine(); //720:55
                }
            }
            __out.Append("{"); //721:1
            __out.AppendLine(); //721:2
            var __loop47_results = 
                (from __loop47_var1 in __Enumerate((model).GetEnumerator()) //722:8
                from Namespace in __Enumerate((__loop47_var1.Namespace).GetEnumerator()) //722:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //722:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //722:40
                select new { __loop47_var1 = __loop47_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //722:3
            int __loop47_iteration = 0;
            foreach (var __tmp49 in __loop47_results)
            {
                ++__loop47_iteration;
                var __loop47_var1 = __tmp49.__loop47_var1;
                var Namespace = __tmp49.Namespace;
                var Declarations = __tmp49.Declarations;
                var cls = __tmp49.cls;
                __out.Append("    /// <summary>"); //723:1
                __out.AppendLine(); //723:18
                string __tmp50Prefix = "	/// Implements the constructor: "; //724:1
                string __tmp51Suffix = "()"; //724:52
                StringBuilder __tmp52 = new StringBuilder();
                __tmp52.Append(cls.CSharpName());
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
                        __out.AppendLine(); //724:54
                    }
                }
                if ((from __loop48_var1 in __Enumerate((cls).GetEnumerator()) //725:15
                from sup in __Enumerate((__loop48_var1.SuperClasses).GetEnumerator()) //725:20
                select new { __loop48_var1 = __loop48_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //725:3
                {
                    string __tmp53Prefix = "	/// Direct superclasses: "; //726:1
                    string __tmp54Suffix = string.Empty; 
                    StringBuilder __tmp55 = new StringBuilder();
                    __tmp55.Append(GetSuperClasses(cls));
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
                            __out.Append(__tmp54Suffix);
                            __out.AppendLine(); //726:49
                        }
                    }
                    string __tmp56Prefix = "	/// All superclasses: "; //727:1
                    string __tmp57Suffix = string.Empty; 
                    StringBuilder __tmp58 = new StringBuilder();
                    __tmp58.Append(GetAllSuperClasses(cls));
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
                            __out.Append(__tmp56Prefix);
                            __out.Append(__tmp58Line);
                            __out.Append(__tmp57Suffix);
                            __out.AppendLine(); //727:49
                        }
                    }
                }
                if ((from __loop49_var1 in __Enumerate((cls).GetEnumerator()) //729:15
                from prop in __Enumerate((__loop49_var1.GetAllProperties()).GetEnumerator()) //729:20
                where prop.Kind == MetaPropertyKind.Readonly //729:44
                select new { __loop49_var1 = __loop49_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //729:3
                {
                    __out.Append("    // Initializes the following readonly properties:"); //730:1
                    __out.AppendLine(); //730:54
                }
                var __loop50_results = 
                    (from __loop50_var1 in __Enumerate((cls).GetEnumerator()) //732:11
                    from prop in __Enumerate((__loop50_var1.GetAllProperties()).GetEnumerator()) //732:16
                    select new { __loop50_var1 = __loop50_var1, prop = prop}
                    ).ToList(); //732:6
                int __loop50_iteration = 0;
                foreach (var __tmp59 in __loop50_results)
                {
                    ++__loop50_iteration;
                    var __loop50_var1 = __tmp59.__loop50_var1;
                    var prop = __tmp59.prop;
                    if (prop.Kind == MetaPropertyKind.Readonly) //733:3
                    {
                        string __tmp60Prefix = "    ///    "; //734:1
                        string __tmp61Suffix = string.Empty; 
                        StringBuilder __tmp62 = new StringBuilder();
                        __tmp62.Append(prop.Class.Name);
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
                            }
                        }
                        string __tmp63Line = "."; //734:29
                        __out.Append(__tmp63Line);
                        StringBuilder __tmp64 = new StringBuilder();
                        __tmp64.Append(prop.Name);
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
                                __out.Append(__tmp61Suffix);
                                __out.AppendLine(); //734:41
                            }
                        }
                    }
                }
                __out.Append("    /// </summary>"); //737:1
                __out.AppendLine(); //737:19
                string __tmp65Prefix = "    public virtual void "; //738:1
                string __tmp66Suffix = " @this)"; //738:81
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
                        __out.Append(__tmp65Prefix);
                        __out.Append(__tmp67Line);
                    }
                }
                string __tmp68Line = "_"; //738:43
                __out.Append(__tmp68Line);
                StringBuilder __tmp69 = new StringBuilder();
                __tmp69.Append(cls.CSharpName());
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
                string __tmp70Line = "("; //738:62
                __out.Append(__tmp70Line);
                StringBuilder __tmp71 = new StringBuilder();
                __tmp71.Append(cls.CSharpName());
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
                        __out.Append(__tmp66Suffix);
                        __out.AppendLine(); //738:88
                    }
                }
                __out.Append("    {"); //739:1
                __out.AppendLine(); //739:6
                var __loop51_results = 
                    (from __loop51_var1 in __Enumerate((cls).GetEnumerator()) //740:9
                    from sup in __Enumerate((__loop51_var1.SuperClasses).GetEnumerator()) //740:14
                    select new { __loop51_var1 = __loop51_var1, sup = sup}
                    ).ToList(); //740:4
                int __loop51_iteration = 0;
                foreach (var __tmp72 in __loop51_results)
                {
                    ++__loop51_iteration;
                    var __loop51_var1 = __tmp72.__loop51_var1;
                    var sup = __tmp72.sup;
                    string __tmp73Prefix = "        this."; //741:1
                    string __tmp74Suffix = "(@this);"; //741:51
                    StringBuilder __tmp75 = new StringBuilder();
                    __tmp75.Append(sup.CSharpName());
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
                            __out.Append(__tmp73Prefix);
                            __out.Append(__tmp75Line);
                        }
                    }
                    string __tmp76Line = "_"; //741:32
                    __out.Append(__tmp76Line);
                    StringBuilder __tmp77 = new StringBuilder();
                    __tmp77.Append(sup.CSharpName());
                    using(StreamReader __tmp77Reader = new StreamReader(this.__ToStream(__tmp77.ToString())))
                    {
                        bool __tmp77_first = true;
                        while(__tmp77_first || !__tmp77Reader.EndOfStream)
                        {
                            __tmp77_first = false;
                            string __tmp77Line = __tmp77Reader.ReadLine();
                            if (__tmp77Line == null)
                            {
                                __tmp77Line = "";
                            }
                            __out.Append(__tmp77Line);
                            __out.Append(__tmp74Suffix);
                            __out.AppendLine(); //741:59
                        }
                    }
                }
                __out.Append("    }"); //743:1
                __out.AppendLine(); //743:6
                var __loop52_results = 
                    (from __loop52_var1 in __Enumerate((cls).GetEnumerator()) //744:11
                    from prop in __Enumerate((__loop52_var1.Properties).GetEnumerator()) //744:16
                    select new { __loop52_var1 = __loop52_var1, prop = prop}
                    ).ToList(); //744:6
                int __loop52_iteration = 0;
                foreach (var __tmp78 in __loop52_results)
                {
                    ++__loop52_iteration;
                    var __loop52_var1 = __tmp78.__loop52_var1;
                    var prop = __tmp78.prop;
                    MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //745:4
                    if (synInit == null) //746:4
                    {
                        if (prop.Kind == MetaPropertyKind.Derived) //747:5
                        {
                            __out.AppendLine(); //748:2
                            __out.Append("    /// <summary>"); //749:1
                            __out.AppendLine(); //749:18
                            string __tmp79Prefix = "    /// Returns the value of the derived property: "; //750:1
                            string __tmp80Suffix = string.Empty; 
                            StringBuilder __tmp81 = new StringBuilder();
                            __tmp81.Append(cls.CSharpName());
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
                            string __tmp82Line = "."; //750:70
                            __out.Append(__tmp82Line);
                            StringBuilder __tmp83 = new StringBuilder();
                            __tmp83.Append(prop.Name);
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
                                    __out.Append(__tmp80Suffix);
                                    __out.AppendLine(); //750:82
                                }
                            }
                            __out.Append("    /// </summary>"); //751:1
                            __out.AppendLine(); //751:19
                            string __tmp84Prefix = "    public virtual "; //752:1
                            string __tmp85Suffix = " @this)"; //752:100
                            StringBuilder __tmp86 = new StringBuilder();
                            __tmp86.Append(prop.Type.CSharpPublicName());
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
                                    __out.Append(__tmp84Prefix);
                                    __out.Append(__tmp86Line);
                                }
                            }
                            string __tmp87Line = " "; //752:50
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
                                }
                            }
                            string __tmp89Line = "_"; //752:69
                            __out.Append(__tmp89Line);
                            StringBuilder __tmp90 = new StringBuilder();
                            __tmp90.Append(prop.Name);
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
                            string __tmp91Line = "("; //752:81
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
                                    __out.Append(__tmp85Suffix);
                                    __out.AppendLine(); //752:107
                                }
                            }
                            __out.Append("    {"); //753:1
                            __out.AppendLine(); //753:6
                            __out.Append("        throw new NotImplementedException();"); //754:1
                            __out.AppendLine(); //754:45
                            __out.Append("    }"); //755:1
                            __out.AppendLine(); //755:6
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //756:5
                        {
                            __out.AppendLine(); //757:2
                            __out.Append("    /// <summary>"); //758:1
                            __out.AppendLine(); //758:18
                            string __tmp93Prefix = "    /// Returns the value of the lazy property: "; //759:1
                            string __tmp94Suffix = string.Empty; 
                            StringBuilder __tmp95 = new StringBuilder();
                            __tmp95.Append(cls.CSharpName());
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
                            string __tmp96Line = "."; //759:67
                            __out.Append(__tmp96Line);
                            StringBuilder __tmp97 = new StringBuilder();
                            __tmp97.Append(prop.Name);
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
                                    __out.Append(__tmp94Suffix);
                                    __out.AppendLine(); //759:79
                                }
                            }
                            __out.Append("    /// </summary>"); //760:1
                            __out.AppendLine(); //760:19
                            string __tmp98Prefix = "    public virtual "; //761:1
                            string __tmp99Suffix = " @this)"; //761:100
                            StringBuilder __tmp100 = new StringBuilder();
                            __tmp100.Append(prop.Type.CSharpPublicName());
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
                                    __out.Append(__tmp98Prefix);
                                    __out.Append(__tmp100Line);
                                }
                            }
                            string __tmp101Line = " "; //761:50
                            __out.Append(__tmp101Line);
                            StringBuilder __tmp102 = new StringBuilder();
                            __tmp102.Append(cls.CSharpName());
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
                            string __tmp103Line = "_"; //761:69
                            __out.Append(__tmp103Line);
                            StringBuilder __tmp104 = new StringBuilder();
                            __tmp104.Append(prop.Name);
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
                                }
                            }
                            string __tmp105Line = "("; //761:81
                            __out.Append(__tmp105Line);
                            StringBuilder __tmp106 = new StringBuilder();
                            __tmp106.Append(cls.CSharpName());
                            using(StreamReader __tmp106Reader = new StreamReader(this.__ToStream(__tmp106.ToString())))
                            {
                                bool __tmp106_first = true;
                                while(__tmp106_first || !__tmp106Reader.EndOfStream)
                                {
                                    __tmp106_first = false;
                                    string __tmp106Line = __tmp106Reader.ReadLine();
                                    if (__tmp106Line == null)
                                    {
                                        __tmp106Line = "";
                                    }
                                    __out.Append(__tmp106Line);
                                    __out.Append(__tmp99Suffix);
                                    __out.AppendLine(); //761:107
                                }
                            }
                            __out.Append("    {"); //762:1
                            __out.AppendLine(); //762:6
                            __out.Append("        throw new NotImplementedException();"); //763:1
                            __out.AppendLine(); //763:45
                            __out.Append("    }"); //764:1
                            __out.AppendLine(); //764:6
                        }
                    }
                }
                var __loop53_results = 
                    (from __loop53_var1 in __Enumerate((cls).GetEnumerator()) //768:11
                    from op in __Enumerate((__loop53_var1.Operations).GetEnumerator()) //768:16
                    select new { __loop53_var1 = __loop53_var1, op = op}
                    ).ToList(); //768:6
                int __loop53_iteration = 0;
                foreach (var __tmp107 in __loop53_results)
                {
                    ++__loop53_iteration;
                    var __loop53_var1 = __tmp107.__loop53_var1;
                    var op = __tmp107.op;
                    __out.AppendLine(); //769:2
                    __out.Append("    /// <summary>"); //770:1
                    __out.AppendLine(); //770:18
                    string __tmp108Prefix = "    /// Implements the operation: "; //771:1
                    string __tmp109Suffix = "()"; //771:63
                    StringBuilder __tmp110 = new StringBuilder();
                    __tmp110.Append(cls.CSharpName());
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
                    string __tmp111Line = "."; //771:53
                    __out.Append(__tmp111Line);
                    StringBuilder __tmp112 = new StringBuilder();
                    __tmp112.Append(op.Name);
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
                            __out.Append(__tmp109Suffix);
                            __out.AppendLine(); //771:65
                        }
                    }
                    __out.Append("    /// </summary>"); //772:1
                    __out.AppendLine(); //772:19
                    string __tmp113Prefix = "    public virtual "; //773:1
                    string __tmp114Suffix = ")"; //773:112
                    StringBuilder __tmp115 = new StringBuilder();
                    __tmp115.Append(op.ReturnType.CSharpPublicName());
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
                    string __tmp116Line = " "; //773:54
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
                        }
                    }
                    string __tmp118Line = "_"; //773:73
                    __out.Append(__tmp118Line);
                    StringBuilder __tmp119 = new StringBuilder();
                    __tmp119.Append(op.Name);
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
                    string __tmp120Line = "("; //773:83
                    __out.Append(__tmp120Line);
                    StringBuilder __tmp121 = new StringBuilder();
                    __tmp121.Append(GetImplParameters(cls, op));
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
                            __out.Append(__tmp114Suffix);
                            __out.AppendLine(); //773:113
                        }
                    }
                    __out.Append("    {"); //774:1
                    __out.AppendLine(); //774:6
                    __out.Append("        throw new NotImplementedException();"); //775:1
                    __out.AppendLine(); //775:45
                    __out.Append("    }"); //776:1
                    __out.AppendLine(); //776:6
                }
                __out.AppendLine(); //778:2
            }
            var __loop54_results = 
                (from __loop54_var1 in __Enumerate((model).GetEnumerator()) //780:8
                from Namespace in __Enumerate((__loop54_var1.Namespace).GetEnumerator()) //780:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //780:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //780:40
                select new { __loop54_var1 = __loop54_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //780:3
            int __loop54_iteration = 0;
            foreach (var __tmp122 in __loop54_results)
            {
                ++__loop54_iteration;
                var __loop54_var1 = __tmp122.__loop54_var1;
                var Namespace = __tmp122.Namespace;
                var Declarations = __tmp122.Declarations;
                var enm = __tmp122.enm;
                var __loop55_results = 
                    (from __loop55_var1 in __Enumerate((enm).GetEnumerator()) //781:11
                    from op in __Enumerate((__loop55_var1.Operations).GetEnumerator()) //781:16
                    select new { __loop55_var1 = __loop55_var1, op = op}
                    ).ToList(); //781:6
                int __loop55_iteration = 0;
                foreach (var __tmp123 in __loop55_results)
                {
                    ++__loop55_iteration;
                    var __loop55_var1 = __tmp123.__loop55_var1;
                    var op = __tmp123.op;
                    __out.AppendLine(); //782:2
                    __out.Append("    /// <summary>"); //783:1
                    __out.AppendLine(); //783:18
                    string __tmp124Prefix = "    /// Implements the operation: "; //784:1
                    string __tmp125Suffix = string.Empty; 
                    StringBuilder __tmp126 = new StringBuilder();
                    __tmp126.Append(enm.CSharpName());
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
                    string __tmp127Line = "."; //784:53
                    __out.Append(__tmp127Line);
                    StringBuilder __tmp128 = new StringBuilder();
                    __tmp128.Append(op.Name);
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
                            __out.Append(__tmp125Suffix);
                            __out.AppendLine(); //784:63
                        }
                    }
                    __out.Append("    /// </summary>"); //785:1
                    __out.AppendLine(); //785:19
                    string __tmp129Prefix = "    public virtual "; //786:1
                    string __tmp130Suffix = ")"; //786:112
                    StringBuilder __tmp131 = new StringBuilder();
                    __tmp131.Append(op.ReturnType.CSharpPublicName());
                    using(StreamReader __tmp131Reader = new StreamReader(this.__ToStream(__tmp131.ToString())))
                    {
                        bool __tmp131_first = true;
                        while(__tmp131_first || !__tmp131Reader.EndOfStream)
                        {
                            __tmp131_first = false;
                            string __tmp131Line = __tmp131Reader.ReadLine();
                            if (__tmp131Line == null)
                            {
                                __tmp131Line = "";
                            }
                            __out.Append(__tmp129Prefix);
                            __out.Append(__tmp131Line);
                        }
                    }
                    string __tmp132Line = " "; //786:54
                    __out.Append(__tmp132Line);
                    StringBuilder __tmp133 = new StringBuilder();
                    __tmp133.Append(enm.CSharpName());
                    using(StreamReader __tmp133Reader = new StreamReader(this.__ToStream(__tmp133.ToString())))
                    {
                        bool __tmp133_first = true;
                        while(__tmp133_first || !__tmp133Reader.EndOfStream)
                        {
                            __tmp133_first = false;
                            string __tmp133Line = __tmp133Reader.ReadLine();
                            if (__tmp133Line == null)
                            {
                                __tmp133Line = "";
                            }
                            __out.Append(__tmp133Line);
                        }
                    }
                    string __tmp134Line = "_"; //786:73
                    __out.Append(__tmp134Line);
                    StringBuilder __tmp135 = new StringBuilder();
                    __tmp135.Append(op.Name);
                    using(StreamReader __tmp135Reader = new StreamReader(this.__ToStream(__tmp135.ToString())))
                    {
                        bool __tmp135_first = true;
                        while(__tmp135_first || !__tmp135Reader.EndOfStream)
                        {
                            __tmp135_first = false;
                            string __tmp135Line = __tmp135Reader.ReadLine();
                            if (__tmp135Line == null)
                            {
                                __tmp135Line = "";
                            }
                            __out.Append(__tmp135Line);
                        }
                    }
                    string __tmp136Line = "("; //786:83
                    __out.Append(__tmp136Line);
                    StringBuilder __tmp137 = new StringBuilder();
                    __tmp137.Append(GetImplParameters(enm, op));
                    using(StreamReader __tmp137Reader = new StreamReader(this.__ToStream(__tmp137.ToString())))
                    {
                        bool __tmp137_first = true;
                        while(__tmp137_first || !__tmp137Reader.EndOfStream)
                        {
                            __tmp137_first = false;
                            string __tmp137Line = __tmp137Reader.ReadLine();
                            if (__tmp137Line == null)
                            {
                                __tmp137Line = "";
                            }
                            __out.Append(__tmp137Line);
                            __out.Append(__tmp130Suffix);
                            __out.AppendLine(); //786:113
                        }
                    }
                    __out.Append("    {"); //787:1
                    __out.AppendLine(); //787:6
                    __out.Append("        throw new NotImplementedException();"); //788:1
                    __out.AppendLine(); //788:45
                    __out.Append("    }"); //789:1
                    __out.AppendLine(); //789:6
                }
                __out.AppendLine(); //791:2
            }
            __out.Append("}"); //793:1
            __out.AppendLine(); //793:2
            __out.AppendLine(); //794:2
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //797:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //798:1
            __out.AppendLine(); //798:14
            __out.Append("/// Factory class for creating instances of model elements."); //799:1
            __out.AppendLine(); //799:60
            __out.Append("/// </summary>"); //800:1
            __out.AppendLine(); //800:15
            string __tmp1Prefix = "public class "; //801:1
            string __tmp2Suffix = "Factory : ModelFactory"; //801:26
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
                    __out.AppendLine(); //801:48
                }
            }
            __out.Append("{"); //802:1
            __out.AppendLine(); //802:2
            string __tmp4Prefix = "    private static "; //803:1
            string __tmp5Suffix = "Factory();"; //803:67
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
            string __tmp7Line = "Factory instance = new "; //803:32
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
                    __out.AppendLine(); //803:77
                }
            }
            __out.AppendLine(); //804:2
            string __tmp9Prefix = "	private "; //805:1
            string __tmp10Suffix = "Factory()"; //805:22
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
                    __out.AppendLine(); //805:31
                }
            }
            __out.Append("	{"); //806:1
            __out.AppendLine(); //806:3
            __out.Append("	}"); //807:1
            __out.AppendLine(); //807:3
            __out.AppendLine(); //808:2
            __out.Append("    /// <summary>"); //809:1
            __out.AppendLine(); //809:18
            __out.Append("    /// The singleton instance of the factory."); //810:1
            __out.AppendLine(); //810:47
            __out.Append("    /// </summary>"); //811:1
            __out.AppendLine(); //811:19
            string __tmp12Prefix = "    public static "; //812:1
            string __tmp13Suffix = "Factory Instance"; //812:31
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
                    __out.AppendLine(); //812:47
                }
            }
            __out.Append("    {"); //813:1
            __out.AppendLine(); //813:6
            string __tmp15Prefix = "        get { return "; //814:1
            string __tmp16Suffix = "Factory.instance; }"; //814:34
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
                    __out.AppendLine(); //814:53
                }
            }
            __out.Append("    }"); //815:1
            __out.AppendLine(); //815:6
            var __loop56_results = 
                (from __loop56_var1 in __Enumerate((model).GetEnumerator()) //816:8
                from Namespace in __Enumerate((__loop56_var1.Namespace).GetEnumerator()) //816:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //816:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //816:40
                select new { __loop56_var1 = __loop56_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //816:3
            int __loop56_iteration = 0;
            foreach (var __tmp18 in __loop56_results)
            {
                ++__loop56_iteration;
                var __loop56_var1 = __tmp18.__loop56_var1;
                var Namespace = __tmp18.Namespace;
                var Declarations = __tmp18.Declarations;
                var cls = __tmp18.cls;
                if (!cls.IsAbstract) //817:4
                {
                    __out.AppendLine(); //818:2
                    __out.Append("    /// <summary>"); //819:1
                    __out.AppendLine(); //819:18
                    string __tmp19Prefix = "    /// Creates a new instance of "; //820:1
                    string __tmp20Suffix = "."; //820:53
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
                            __out.AppendLine(); //820:54
                        }
                    }
                    __out.Append("    /// </summary>"); //821:1
                    __out.AppendLine(); //821:19
                    string __tmp22Prefix = "    public "; //822:1
                    string __tmp23Suffix = "()"; //822:55
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
                    string __tmp25Line = " Create"; //822:30
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
                            __out.AppendLine(); //822:57
                        }
                    }
                    __out.Append("	{"); //823:1
                    __out.AppendLine(); //823:3
                    string __tmp27Prefix = "		"; //824:1
                    string __tmp28Suffix = "Impl();"; //824:57
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
                    string __tmp30Line = " result = new "; //824:21
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
                            __out.AppendLine(); //824:64
                        }
                    }
                    __out.Append("		return result;"); //825:1
                    __out.AppendLine(); //825:17
                    __out.Append("	}"); //826:1
                    __out.AppendLine(); //826:3
                }
            }
            __out.Append("}"); //829:1
            __out.AppendLine(); //829:2
            __out.AppendLine(); //830:2
            return __out.ToString();
        }

    }
}

