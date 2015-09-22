using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core //1:1
{
    using __Hidden_MetaModelGenerator_350203081;
    namespace __Hidden_MetaModelGenerator_350203081
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
            string __tmp12Suffix = "Descriptor.StaticInit();"; //150:37
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(cls.Model.CSharpFullName());
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
                    __out.AppendLine(); //150:61
                }
            }
            __out.Append("    }"); //151:1
            __out.AppendLine(); //151:6
            __out.AppendLine(); //152:2
            __out.Append("    public override global::MetaDslx.Core.MetaClass GetMetaClass()"); //153:1
            __out.AppendLine(); //153:67
            __out.Append("    {"); //154:1
            __out.AppendLine(); //154:6
            string __tmp14Prefix = "        return "; //155:1
            string __tmp15Suffix = ";"; //155:71
            StringBuilder __tmp16 = new StringBuilder();
            __tmp16.Append(cls.Model.CSharpFullName());
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
            string __tmp17Line = "Instance."; //155:44
            __out.Append(__tmp17Line);
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
                    __out.Append(__tmp18Line);
                    __out.Append(__tmp15Suffix);
                    __out.AppendLine(); //155:72
                }
            }
            __out.Append("    }"); //156:1
            __out.AppendLine(); //156:6
            __out.AppendLine(); //157:2
            string __tmp19Prefix = "    "; //158:1
            string __tmp20Suffix = string.Empty; 
            StringBuilder __tmp21 = new StringBuilder();
            __tmp21.Append(GenerateConstructorImpl(model, cls));
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
                    __out.AppendLine(); //158:42
                }
            }
            var __loop15_results = 
                (from __loop15_var1 in __Enumerate((cls).GetEnumerator()) //159:11
                from prop in __Enumerate((__loop15_var1.GetAllProperties()).GetEnumerator()) //159:16
                select new { __loop15_var1 = __loop15_var1, prop = prop}
                ).ToList(); //159:6
            int __loop15_iteration = 0;
            foreach (var __tmp22 in __loop15_results)
            {
                ++__loop15_iteration;
                var __loop15_var1 = __tmp22.__loop15_var1;
                var prop = __tmp22.prop;
                string __tmp23Prefix = "    "; //160:1
                string __tmp24Suffix = string.Empty; 
                StringBuilder __tmp25 = new StringBuilder();
                __tmp25.Append(GeneratePropertyImpl(model, cls, prop));
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
                        __out.AppendLine(); //160:45
                    }
                }
            }
            var __loop16_results = 
                (from __loop16_var1 in __Enumerate((cls).GetEnumerator()) //162:11
                from op in __Enumerate((__loop16_var1.GetAllOperations()).GetEnumerator()) //162:16
                select new { __loop16_var1 = __loop16_var1, op = op}
                ).ToList(); //162:6
            int __loop16_iteration = 0;
            foreach (var __tmp26 in __loop16_results)
            {
                ++__loop16_iteration;
                var __loop16_var1 = __tmp26.__loop16_var1;
                var op = __tmp26.op;
                string __tmp27Prefix = "    "; //163:1
                string __tmp28Suffix = string.Empty; 
                StringBuilder __tmp29 = new StringBuilder();
                __tmp29.Append(GenerateOperationImpl(model, op));
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
                        __out.AppendLine(); //163:39
                    }
                }
            }
            __out.Append("}"); //165:1
            __out.AppendLine(); //165:2
            __out.AppendLine(); //166:2
            return __out.ToString();
        }

        public string GeneratePropertyDeclaration(MetaModel model, MetaClass cls, MetaProperty prop) //169:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class == cls) //170:2
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
                        __out.AppendLine(); //171:28
                    }
                }
                if (prop.Kind == MetaPropertyKind.Containment) //172:2
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
                            __out.AppendLine(); //173:27
                        }
                    }
                }
                if (prop.Kind != MetaPropertyKind.Normal && prop.Kind != MetaPropertyKind.Containment) //175:2
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
                            __out.AppendLine(); //176:24
                        }
                    }
                }
                var __loop17_results = 
                    (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //178:7
                    select new { p = p}
                    ).ToList(); //178:2
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
                    string __tmp15Line = "Descriptor."; //179:63
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
                            __out.AppendLine(); //179:121
                        }
                    }
                }
                var __loop18_results = 
                    (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //181:7
                    select new { p = p}
                    ).ToList(); //181:2
                int __loop18_iteration = 0;
                foreach (var __tmp20 in __loop18_results)
                {
                    ++__loop18_iteration;
                    var p = __tmp20.p;
                    if (cls.GetAllSuperClasses(false).Contains(p.Class)) //182:3
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
                        string __tmp25Line = "Descriptor."; //183:62
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
                                __out.AppendLine(); //183:120
                            }
                        }
                    }
                    else //184:3
                    {
                        string __tmp30Prefix = "// ERROR: subsetted property '"; //185:1
                        string __tmp31Suffix = "' must be a property of an ancestor class"; //185:105
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
                        string __tmp33Line = "Descriptor."; //185:63
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
                        string __tmp35Line = "."; //185:96
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
                                __out.AppendLine(); //185:146
                            }
                        }
                    }
                }
                var __loop19_results = 
                    (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //188:7
                    select new { p = p}
                    ).ToList(); //188:2
                int __loop19_iteration = 0;
                foreach (var __tmp37 in __loop19_results)
                {
                    ++__loop19_iteration;
                    var p = __tmp37.p;
                    if (cls.GetAllSuperClasses(false).Contains(p.Class)) //189:3
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
                        string __tmp42Line = "Descriptor."; //190:64
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
                                __out.AppendLine(); //190:122
                            }
                        }
                    }
                    else //191:3
                    {
                        string __tmp47Prefix = "// ERROR: redefined property '"; //192:1
                        string __tmp48Suffix = "' must be a property of an ancestor class"; //192:105
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
                        string __tmp50Line = "Descriptor."; //192:63
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
                        string __tmp52Line = "."; //192:96
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
                                __out.AppendLine(); //192:146
                            }
                        }
                    }
                }
                string __tmp54Prefix = "public static readonly ModelProperty "; //195:1
                string __tmp55Suffix = "Property ="; //195:49
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
                        __out.AppendLine(); //195:59
                    }
                }
                string __tmp57Prefix = "    ModelProperty.Register(\""; //196:1
                string __tmp58Suffix = "Property));"; //196:339
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
                string __tmp60Line = "\", typeof("; //196:40
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
                string __tmp62Line = "), typeof("; //196:84
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
                string __tmp64Line = "), typeof("; //196:123
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
                string __tmp66Line = "Descriptor."; //196:168
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
                string __tmp68Line = "), new Lazy<global::MetaDslx.Core.MetaProperty>(() => "; //196:204
                __out.Append(__tmp68Line);
                StringBuilder __tmp69 = new StringBuilder();
                __tmp69.Append(prop.Class.Model.CSharpFullName());
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
                string __tmp70Line = "Instance."; //196:293
                __out.Append(__tmp70Line);
                StringBuilder __tmp71 = new StringBuilder();
                __tmp71.Append(prop.Class.CSharpName());
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
                string __tmp72Line = "_"; //196:327
                __out.Append(__tmp72Line);
                StringBuilder __tmp73 = new StringBuilder();
                __tmp73.Append(prop.Name);
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
                        __out.Append(__tmp58Suffix);
                        __out.AppendLine(); //196:350
                    }
                }
            }
            __out.AppendLine(); //198:2
            return __out.ToString();
        }

        public string GeneratePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //201:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //202:2
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
            string __tmp4Line = " "; //203:31
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
            string __tmp6Line = "."; //203:57
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
                    __out.AppendLine(); //203:69
                }
            }
            __out.Append("{"); //204:1
            __out.AppendLine(); //204:2
            if (prop.Kind == MetaPropertyKind.Derived) //205:3
            {
                MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //206:4
                if (synInit == null) //207:4
                {
                    string __tmp8Prefix = "    get { return "; //208:1
                    string __tmp9Suffix = "(this); }"; //208:105
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
                    string __tmp11Line = "ImplementationProvider.Implementation."; //208:30
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
                    string __tmp13Line = "_"; //208:93
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
                            __out.AppendLine(); //208:114
                        }
                    }
                }
                else //209:4
                {
                    string __tmp15Prefix = "    get { return "; //210:1
                    string __tmp16Suffix = "; }"; //210:53
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
                            __out.AppendLine(); //210:56
                        }
                    }
                }
            }
            else //212:3
            {
                __out.Append("    get "); //213:1
                __out.AppendLine(); //213:9
                __out.Append("    {"); //214:1
                __out.AppendLine(); //214:6
                string __tmp18Prefix = "        object result = this.MGet("; //215:1
                string __tmp19Suffix = "Property); "; //215:107
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
                string __tmp21Line = "Descriptor."; //215:59
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
                string __tmp23Line = "."; //215:95
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
                        __out.AppendLine(); //215:118
                    }
                }
                string __tmp25Prefix = "        if (result != null) return ("; //216:1
                string __tmp26Suffix = ")result;"; //216:67
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
                        __out.AppendLine(); //216:75
                    }
                }
                string __tmp28Prefix = "        else return default("; //217:1
                string __tmp29Suffix = ");"; //217:59
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
                        __out.AppendLine(); //217:61
                    }
                }
                __out.Append("    }"); //218:1
                __out.AppendLine(); //218:6
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //220:3
            {
                string __tmp31Prefix = "    set { this.MSet("; //221:1
                string __tmp32Suffix = "Property, value); }"; //221:93
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
                string __tmp34Line = "Descriptor."; //221:45
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
                string __tmp36Line = "."; //221:81
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
                        __out.AppendLine(); //221:112
                    }
                }
            }
            __out.Append("}"); //223:1
            __out.AppendLine(); //223:2
            return __out.ToString();
        }

        public string GetCollectionConstructorParams(MetaProperty prop) //226:1
        {
            MetaCollectionType mct = prop.Type as MetaCollectionType; //227:2
            if (mct != null && mct.InnerType is MetaClass) //228:2
            {
                return "this, " + prop.Class.Model.CSharpFullName() + "Descriptor." + prop.Class.CSharpName() + "." + prop.Name + "Property"; //229:3
            }
            else //230:2
            {
                return ""; //231:3
            }
        }

        public string GenerateExpression(MetaExpression expr) //236:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //237:10
            if (expr is MetaBracketExpression) //238:2
            {
                __out.Append("("); //238:33
                __out.Append(GenerateExpression(((MetaBracketExpression)expr).Expression));
                __out.Append(")"); //238:71
            }
            else if (expr is MetaThisExpression) //239:2
            {
                __out.Append("(("); //239:30
                __out.Append(((MetaType)ModelContext.Current.Compiler.ResolutionProvider.GetCurrentTypeScopeOf((ModelObject)((MetaThisExpression)expr))).CSharpName());
                __out.Append(")this)"); //239:148
            }
            else if (expr is MetaNullExpression) //240:2
            {
                __out.Append("null"); //240:30
            }
            else if (expr is MetaTypeAsExpression) //241:2
            {
                __out.Append(GenerateExpression(((MetaTypeAsExpression)expr).Expression));
                __out.Append(" as "); //241:69
                __out.Append(((MetaTypeAsExpression)expr).TypeReference.CSharpName());
            }
            else if (expr is MetaTypeCastExpression) //242:2
            {
                __out.Append("("); //242:34
                __out.Append(((MetaTypeCastExpression)expr).TypeReference.CSharpName());
                __out.Append(")"); //242:68
                __out.Append(GenerateExpression(((MetaTypeCastExpression)expr).Expression));
            }
            else if (expr is MetaTypeCheckExpression) //243:2
            {
                __out.Append(GenerateExpression(((MetaTypeCheckExpression)expr).Expression));
                __out.Append(" is "); //243:72
                __out.Append(((MetaTypeCheckExpression)expr).TypeReference.CSharpName());
            }
            else if (expr is MetaTypeOfExpression) //244:2
            {
                __out.Append(GenerateTypeOf(((MetaTypeOfExpression)expr)));
            }
            else if (expr is MetaConditionalExpression) //245:2
            {
                __out.Append(GenerateExpression(((MetaConditionalExpression)expr).Condition));
                __out.Append(" ? "); //245:73
                __out.Append(GenerateExpression(((MetaConditionalExpression)expr).Then));
                __out.Append(" : "); //245:107
                __out.Append(GenerateExpression(((MetaConditionalExpression)expr).Else));
            }
            else if (expr is MetaConstantExpression) //246:2
            {
                __out.Append(GetCSharpValue(((MetaConstantExpression)expr).Value));
            }
            else if (expr is MetaIdentifierExpression) //247:2
            {
                __out.Append(GenerateIdentifierExpression(((MetaIdentifierExpression)expr)));
            }
            else if (expr is MetaMemberAccessExpression) //248:2
            {
                __out.Append(GenerateExpression(((MetaMemberAccessExpression)expr).Expression));
                __out.Append("."); //248:75
                __out.Append(((MetaMemberAccessExpression)expr).Name);
            }
            else if (expr is MetaFunctionCallExpression) //249:2
            {
                __out.Append(GenerateFunctionCall(((MetaFunctionCallExpression)expr)));
            }
            else if (expr is MetaIndexerExpression) //250:2
            {
                __out.Append(GenerateIndexerCall(((MetaIndexerExpression)expr)));
            }
            else if (expr is MetaOperatorExpression) //251:2
            {
                __out.Append(GenerateOperator(((MetaOperatorExpression)expr)));
            }
            else if (expr is MetaNewExpression) //252:2
            {
                __out.Append(((MetaNewExpression)expr).TypeReference.Model.CSharpFullName());
                __out.Append("Factory.Instance.Create"); //252:72
                __out.Append(((MetaNewExpression)expr).TypeReference.CSharpName());
                __out.Append("("); //252:128
                __out.Append(GenerateNewPropertyInitializers(((MetaNewExpression)expr)));
                __out.Append(")"); //252:168
            }
            else if (expr is MetaNewCollectionExpression) //253:2
            {
                __out.Append("new List<Lazy<object>>() { "); //253:39
                __out.Append(GenerateNewCollectionValues(((MetaNewCollectionExpression)expr)));
                __out.Append(" }"); //253:101
            }
            else //254:2
            {
                __out.Append("***unknown expression type***"); //254:11
                __out.AppendLine(); //254:40
            }//255:2
            return __out.ToString();
        }

        public string GenerateIdentifierExpression(MetaIdentifierExpression expr) //258:1
        {
            StringBuilder __out = new StringBuilder();
            if (expr.Definition is MetaProperty) //259:2
            {
                string __tmp1Prefix = "(("; //260:1
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
                string __tmp4Line = ")this)."; //260:119
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
            else //261:2
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

        public bool SameFunction(MetaFunction mfunc1, MetaFunction mfunc2) //266:1
        {
            return mfunc1.Name == mfunc2.Name && ModelContext.Current.Compiler.TypeProvider.Equals((ModelObject)mfunc1.Type, (ModelObject)mfunc2.Type); //267:2
        }

        public string GenerateFunctionCall(MetaFunctionCallExpression call) //270:1
        {
            StringBuilder __out = new StringBuilder();
            if (SameFunction((MetaFunction)call.Definition, MetaDescriptor.Constants.TypeOf)) //271:2
            {
                __out.Append(GenerateTypeOf(call.Arguments[0]));
            }
            else if (SameFunction((MetaFunction)call.Definition, MetaDescriptor.Constants.GetValueType)) //272:2
            {
                __out.Append("ModelContext.Current.Compiler.TypeProvider.GetTypeOf("); //272:95
                __out.Append(GenerateCallArguments(call, ""));
                __out.Append(")"); //272:181
            }
            else if (SameFunction((MetaFunction)call.Definition, MetaDescriptor.Constants.GetReturnType)) //273:2
            {
                __out.Append("ModelContext.Current.Compiler.TypeProvider.GetReturnTypeOf("); //273:96
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //273:201
            }
            else if (SameFunction((MetaFunction)call.Definition, MetaDescriptor.Constants.CurrentType)) //274:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.GetCurrentTypeScopeOf("); //274:94
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //274:211
            }
            else if (SameFunction((MetaFunction)call.Definition, MetaDescriptor.Constants.TypeCheck)) //275:2
            {
                __out.Append("ModelContext.Current.Compiler.TypeProvider.TypeCheck("); //275:92
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //275:191
            }
            else if (SameFunction((MetaFunction)call.Definition, MetaDescriptor.Constants.Balance)) //276:2
            {
                __out.Append("ModelContext.Current.Compiler.TypeProvider.Balance("); //276:90
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //276:187
            }
            else if (SameFunction((MetaFunction)call.Definition, MetaDescriptor.Constants.Resolve1)) //277:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //277:91
                __out.Append("[]");
                __out.Append(" { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.NameOrType, "); //277:169
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //277:309
            }
            else if (SameFunction((MetaFunction)call.Definition, MetaDescriptor.Constants.Resolve2)) //278:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //278:91
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //278:169
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, ResolveKind.NameOrType, "); //278:224
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //278:291
            }
            else if (SameFunction((MetaFunction)call.Definition, MetaDescriptor.Constants.ResolveType1)) //279:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //279:95
                __out.Append("[]");
                __out.Append(" { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Type, "); //279:173
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //279:307
            }
            else if (SameFunction((MetaFunction)call.Definition, MetaDescriptor.Constants.ResolveType2)) //280:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //280:95
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //280:173
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, ResolveKind.Type, "); //280:228
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //280:289
            }
            else if (SameFunction((MetaFunction)call.Definition, MetaDescriptor.Constants.ResolveName1)) //281:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //281:95
                __out.Append("[]");
                __out.Append(" { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, "); //281:173
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //281:307
            }
            else if (SameFunction((MetaFunction)call.Definition, MetaDescriptor.Constants.ResolveName2)) //282:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //282:95
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //282:173
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, ResolveKind.Name, "); //282:228
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //282:289
            }
            else if (SameFunction((MetaFunction)call.Definition, MetaDescriptor.Constants.Bind1)) //283:2
            {
                __out.Append("ModelContext.Current.Compiler.BindingProvider.Bind(this, new ModelObject"); //283:88
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //283:166
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, new BindingInfo())"); //283:221
            }
            else if (SameFunction((MetaFunction)call.Definition, MetaDescriptor.Constants.Bind2)) //284:2
            {
                __out.Append("ModelContext.Current.Compiler.BindingProvider.Bind(this, "); //284:88
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new BindingInfo())"); //284:184
            }
            else if (SameFunction((MetaFunction)call.Definition, MetaDescriptor.Constants.Bind3)) //285:2
            {
                __out.Append("ModelContext.Current.Compiler.BindingProvider.Bind((ModelObject)"); //285:88
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ModelObject"); //285:191
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //285:214
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(" }, new BindingInfo())"); //285:269
            }
            else if (SameFunction((MetaFunction)call.Definition, MetaDescriptor.Constants.Bind4)) //286:2
            {
                __out.Append("ModelContext.Current.Compiler.BindingProvider.Bind((ModelObject)"); //286:88
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", "); //286:191
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new BindingInfo())"); //286:232
            }
            else if (SameFunction((MetaFunction)call.Definition, MetaDescriptor.Constants.SelectOfType1)) //287:2
            {
                __out.Append("new object"); //287:96
                __out.Append("[]");
                __out.Append(" { "); //287:112
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }.Where(e => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(e) is "); //287:154
                __out.Append(GetTypeName(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //287:259
            }
            else if (SameFunction((MetaFunction)call.Definition, MetaDescriptor.Constants.SelectOfType2)) //288:2
            {
                __out.Append("("); //288:96
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(").Where(e => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(e) is "); //288:136
                __out.Append(GetTypeName(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //288:240
            }
            else if (SameFunction((MetaFunction)call.Definition, MetaDescriptor.Constants.SelectOfName1)) //289:2
            {
                __out.Append("new object"); //289:96
                __out.Append("[]");
                __out.Append(" { "); //289:112
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }.Where(e => ModelContext.Current.Compiler.NameProvider.GetNameOf((ModelObject)e) == "); //289:154
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //289:279
            }
            else if (SameFunction((MetaFunction)call.Definition, MetaDescriptor.Constants.SelectOfName2)) //290:2
            {
                __out.Append("("); //290:96
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(").Where(e => ModelContext.Current.Compiler.NameProvider.GetNameOf((ModelObject)e) == "); //290:136
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //290:260
            }
            else //291:2
            {
                __out.Append(GenerateExpression(call.Expression));
                __out.Append("("); //291:44
                __out.Append(GenerateCallArguments(call, ""));
                __out.Append(")"); //291:78
            }
            return __out.ToString();
        }

        public string GenerateIndexerCall(MetaIndexerExpression call) //295:1
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

        public string GenerateTypeOf(object expr) //299:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //300:9
            if (expr is MetaPrimitiveType) //301:2
            {
                var __tmp2 = ((MetaPrimitiveType)expr).Name; //302:10
                __out.Append("	"); //303:1
                if (__tmp2 == "*none*") //303:3
                {
                    __out.Append("MetaDescriptor.Constants.None"); //303:18
                    __out.Append("	"); //304:1
                }
                else if (__tmp2 == "*error*") //304:3
                {
                    __out.Append("MetaDescriptor.Constants.Error"); //304:19
                    __out.Append("	"); //305:1
                }
                else if (__tmp2 == "*any*") //305:3
                {
                    __out.Append("MetaDescriptor.Constants.Any"); //305:17
                    __out.Append("	"); //306:1
                }
                else if (__tmp2 == "object") //306:3
                {
                    __out.Append("MetaDescriptor.Constants.Object"); //306:18
                    __out.Append("	"); //307:1
                }
                else if (__tmp2 == "string") //307:3
                {
                    __out.Append("MetaDescriptor.Constants.String"); //307:18
                    __out.Append("	"); //308:1
                }
                else if (__tmp2 == "int") //308:3
                {
                    __out.Append("MetaDescriptor.Constants.Int"); //308:15
                    __out.Append("	"); //309:1
                }
                else if (__tmp2 == "long") //309:3
                {
                    __out.Append("MetaDescriptor.Constants.Long"); //309:16
                    __out.Append("	"); //310:1
                }
                else if (__tmp2 == "float") //310:3
                {
                    __out.Append("MetaDescriptor.Constants.Float"); //310:17
                    __out.Append("	"); //311:1
                }
                else if (__tmp2 == "double") //311:3
                {
                    __out.Append("MetaDescriptor.Constants.Double"); //311:18
                    __out.Append("	"); //312:1
                }
                else if (__tmp2 == "byte") //312:3
                {
                    __out.Append("MetaDescriptor.Constants.Byte"); //312:16
                    __out.Append("	"); //313:1
                }
                else if (__tmp2 == "bool") //313:3
                {
                    __out.Append("MetaDescriptor.Constants.Bool"); //313:16
                    __out.Append("	"); //314:1
                }
                else if (__tmp2 == "void") //314:3
                {
                    __out.Append("MetaDescriptor.Constants.Void"); //314:16
                    __out.Append("	"); //315:1
                }
                else if (__tmp2 == "ModelObject") //315:3
                {
                    __out.Append("MetaDescriptor.Constants.ModelObject"); //315:23
                    __out.Append("	"); //316:1
                }
                else if (__tmp2 == "ModelObjectList") //316:3
                {
                    __out.Append("MetaDescriptor.Constants.ModelObjectList"); //316:27
                }//317:3
            }
            else if (expr is MetaTypeOfExpression) //318:2
            {
                __out.Append(GenerateTypeOf(((MetaTypeOfExpression)expr).TypeReference));
            }
            else if (expr is MetaClass) //319:2
            {
                __out.Append(((MetaClass)expr).Model.Name);
                __out.Append("Descriptor."); //319:38
                __out.Append(((MetaClass)expr).CSharpName());
                __out.Append(".GetMetaClass()"); //319:68
            }
            else if (expr is MetaCollectionType) //320:2
            {
                __out.Append(((MetaCollectionType)expr).CSharpFullName());
            }
            else //321:2
            {
                __out.Append("***error***"); //321:11
            }//322:2
            return __out.ToString();
        }

        public string GenerateCallArguments(MetaBoundExpression call, string prefix) //325:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop20_results = 
                (from __loop20_var1 in __Enumerate((call).GetEnumerator()) //326:7
                from arg in __Enumerate((__loop20_var1.Arguments).GetEnumerator()) //326:13
                select new { __loop20_var1 = __loop20_var1, arg = arg}
                ).ToList(); //326:2
            int __loop20_iteration = 0;
            string delim = ""; //326:28
            foreach (var __tmp1 in __loop20_results)
            {
                ++__loop20_iteration;
                if (__loop20_iteration >= 2) //326:47
                {
                    delim = ", "; //326:47
                }
                var __loop20_var1 = __tmp1.__loop20_var1;
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

        public string GenerateOperator(MetaOperatorExpression expr) //331:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //332:10
            if (expr is MetaUnaryExpression) //333:2
            {
                if (((MetaUnaryExpression)expr) is MetaPostIncrementAssignExpression || ((MetaUnaryExpression)expr) is MetaPostDecrementAssignExpression) //334:3
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
                else //336:3
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
            else if (expr is MetaBinaryExpression) //339:2
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
            }//341:2
            return __out.ToString();
        }

        public string GenerateNewPropertyInitializers(MetaNewExpression expr) //344:1
        {
            StringBuilder __out = new StringBuilder();
            if ((from __loop21_var1 in __Enumerate((expr).GetEnumerator()) //345:14
            from pi in __Enumerate((__loop21_var1.PropertyInitializers).GetEnumerator()) //345:20
            select new { __loop21_var1 = __loop21_var1, pi = pi}
            ).GetEnumerator().MoveNext()) //345:2
            {
                __out.Append("new List<ModelPropertyInitializer>() {"); //346:1
                var __loop22_results = 
                    (from __loop22_var1 in __Enumerate((expr).GetEnumerator()) //347:7
                    from pi in __Enumerate((__loop22_var1.PropertyInitializers).GetEnumerator()) //347:13
                    select new { __loop22_var1 = __loop22_var1, pi = pi}
                    ).ToList(); //347:2
                int __loop22_iteration = 0;
                string delim = ""; //347:38
                foreach (var __tmp1 in __loop22_results)
                {
                    ++__loop22_iteration;
                    if (__loop22_iteration >= 2) //347:57
                    {
                        delim = ", "; //347:57
                    }
                    var __loop22_var1 = __tmp1.__loop22_var1;
                    var pi = __tmp1.pi;
                    string __tmp2Prefix = string.Empty; 
                    string __tmp3Suffix = "))"; //348:204
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
                    string __tmp5Line = "new ModelPropertyInitializer("; //348:8
                    __out.Append(__tmp5Line);
                    StringBuilder __tmp6 = new StringBuilder();
                    __tmp6.Append(pi.Property.Class.Model.CSharpFullName());
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
                    string __tmp7Line = "Descriptor."; //348:79
                    __out.Append(__tmp7Line);
                    StringBuilder __tmp8 = new StringBuilder();
                    __tmp8.Append(pi.Property.Class.CSharpName());
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
                    string __tmp9Line = "."; //348:122
                    __out.Append(__tmp9Line);
                    StringBuilder __tmp10 = new StringBuilder();
                    __tmp10.Append(pi.Property.Name);
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
                        }
                    }
                    string __tmp11Line = "Property, new Lazy<object>(() => "; //348:141
                    __out.Append(__tmp11Line);
                    StringBuilder __tmp12 = new StringBuilder();
                    __tmp12.Append(GenerateExpression(pi.Value));
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
                            __out.Append(__tmp3Suffix);
                        }
                    }
                }
                __out.Append("}"); //350:1
            }
            return __out.ToString();
        }

        public string GenerateNewCollectionValues(MetaNewCollectionExpression expr) //354:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((expr).GetEnumerator()) //355:7
                from v in __Enumerate((__loop23_var1.Values).GetEnumerator()) //355:13
                select new { __loop23_var1 = __loop23_var1, v = v}
                ).ToList(); //355:2
            int __loop23_iteration = 0;
            string delim = ""; //355:23
            foreach (var __tmp1 in __loop23_results)
            {
                ++__loop23_iteration;
                if (__loop23_iteration >= 2) //355:42
                {
                    delim = ", \n"; //355:42
                }
                var __loop23_var1 = __tmp1.__loop23_var1;
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

        public string GetCSharpValue(object value) //360:1
        {
            if (value == null) //361:2
            {
                return "null"; //361:21
            }
            else if (value is bool && ((bool)value) == true) //362:2
            {
                return "true"; //362:51
            }
            else if (value is bool && ((bool)value) == false) //363:2
            {
                return "false"; //363:52
            }
            else if (value is string) //364:2
            {
                return "\"" + value.ToString() + "\""; //364:28
            }
            else if (value is MetaExpression) //365:2
            {
                return GenerateExpression((MetaExpression)value); //365:36
            }
            else //366:2
            {
                return value.ToString(); //366:7
            }
        }

        public string GetCSharpIdentifier(object value) //370:1
        {
            if (value == null) //371:2
            {
                return null; //372:3
            }
            if (value is MetaConstantExpression && ((MetaConstantExpression)value).Value != null) //374:2
            {
                return ((MetaConstantExpression)value).Value.ToString(); //375:3
            }
            else if (value is string) //376:2
            {
                return value.ToString(); //377:3
            }
            else //378:2
            {
                return null; //379:3
            }
        }

        public string GetCSharpOperator(MetaOperatorExpression expr) //383:1
        {
            var __tmp1 = expr; //384:9
            if (expr is MetaUnaryPlusExpression) //385:3
            {
                return "+"; //385:36
            }
            else if (expr is MetaNegateExpression) //386:3
            {
                return "-"; //386:33
            }
            else if (expr is MetaOnesComplementExpression) //387:3
            {
                return "~"; //387:41
            }
            else if (expr is MetaNotExpression) //388:3
            {
                return "!"; //388:30
            }
            else if (expr is MetaPostIncrementAssignExpression) //389:3
            {
                return "++"; //389:46
            }
            else if (expr is MetaPostDecrementAssignExpression) //390:3
            {
                return "--"; //390:46
            }
            else if (expr is MetaPreIncrementAssignExpression) //391:3
            {
                return "++"; //391:45
            }
            else if (expr is MetaPreDecrementAssignExpression) //392:3
            {
                return "--"; //392:45
            }
            else if (expr is MetaMultiplyExpression) //393:3
            {
                return "*"; //393:35
            }
            else if (expr is MetaDivideExpression) //394:3
            {
                return "/"; //394:33
            }
            else if (expr is MetaModuloExpression) //395:3
            {
                return "%"; //395:33
            }
            else if (expr is MetaAddExpression) //396:3
            {
                return "+"; //396:30
            }
            else if (expr is MetaSubtractExpression) //397:3
            {
                return "-"; //397:35
            }
            else if (expr is MetaLeftShiftExpression) //398:3
            {
                return "<<"; //398:36
            }
            else if (expr is MetaRightShiftExpression) //399:3
            {
                return ">>"; //399:37
            }
            else if (expr is MetaLessThanExpression) //400:3
            {
                return "<"; //400:35
            }
            else if (expr is MetaLessThanOrEqualExpression) //401:3
            {
                return "<="; //401:42
            }
            else if (expr is MetaGreaterThanExpression) //402:3
            {
                return ">"; //402:38
            }
            else if (expr is MetaGreaterThanOrEqualExpression) //403:3
            {
                return ">="; //403:45
            }
            else if (expr is MetaEqualExpression) //404:3
            {
                return "=="; //404:32
            }
            else if (expr is MetaNotEqualExpression) //405:3
            {
                return "!="; //405:35
            }
            else if (expr is MetaAndExpression) //406:3
            {
                return "&"; //406:30
            }
            else if (expr is MetaOrExpression) //407:3
            {
                return "|"; //407:29
            }
            else if (expr is MetaExclusiveOrExpression) //408:3
            {
                return "^"; //408:38
            }
            else if (expr is MetaAndAlsoExpression) //409:3
            {
                return "&&"; //409:34
            }
            else if (expr is MetaOrElseExpression) //410:3
            {
                return "||"; //410:33
            }
            else if (expr is MetaNullCoalescingExpression) //411:3
            {
                return "??"; //411:41
            }
            else if (expr is MetaMultiplyAssignExpression) //412:3
            {
                return "*="; //412:41
            }
            else if (expr is MetaDivideAssignExpression) //413:3
            {
                return "/="; //413:39
            }
            else if (expr is MetaModuloAssignExpression) //414:3
            {
                return "%="; //414:39
            }
            else if (expr is MetaAddAssignExpression) //415:3
            {
                return "+="; //415:36
            }
            else if (expr is MetaSubtractAssignExpression) //416:3
            {
                return "-="; //416:41
            }
            else if (expr is MetaLeftShiftAssignExpression) //417:3
            {
                return "<<="; //417:42
            }
            else if (expr is MetaRightShiftAssignExpression) //418:3
            {
                return ">>="; //418:43
            }
            else if (expr is MetaAndAssignExpression) //419:3
            {
                return "&="; //419:36
            }
            else if (expr is MetaExclusiveOrAssignExpression) //420:3
            {
                return "^="; //420:44
            }
            else if (expr is MetaOrAssignExpression) //421:3
            {
                return "|="; //421:35
            }
            else //422:3
            {
                return ""; //422:12
            }//423:2
        }

        public string GetTypeName(MetaExpression expr) //426:1
        {
            if (expr is MetaTypeOfExpression) //427:2
            {
                return ((MetaTypeOfExpression)expr).TypeReference.CSharpName(); //427:36
            }
            else //428:2
            {
                return null; //428:7
            }
        }

        public MetaSynthetizedPropertyInitializer GetSynthetizedInitializerFor(MetaClass cls, MetaProperty prop) //432:1
        {
            MetaSynthetizedPropertyInitializer lastInit = null; //433:2
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((cls).GetEnumerator()) //434:7
                from sup in __Enumerate((__loop24_var1.GetAllSuperClasses(true)).GetEnumerator()) //434:12
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //434:42
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //434:55
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaSynthetizedPropertyInitializer>() //434:69
                select new { __loop24_var1 = __loop24_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //434:2
            int __loop24_iteration = 0;
            foreach (var __tmp1 in __loop24_results)
            {
                ++__loop24_iteration;
                var __loop24_var1 = __tmp1.__loop24_var1;
                var sup = __tmp1.sup;
                var Constructor = __tmp1.Constructor;
                var Initializers = __tmp1.Initializers;
                var init = __tmp1.init;
                if (init.Property == prop) //435:3
                {
                    lastInit = init; //436:4
                }
            }
            return lastInit; //439:2
        }

        public string GenerateConstructorImpl(MetaModel model, MetaClass cls) //442:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public "; //443:1
            string __tmp2Suffix = "() "; //443:30
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
                    __out.AppendLine(); //443:33
                }
            }
            __out.Append("{"); //444:1
            __out.AppendLine(); //444:2
            var __loop25_results = 
                (from __loop25_var1 in __Enumerate((cls).GetEnumerator()) //445:8
                from prop in __Enumerate((__loop25_var1.GetAllProperties()).GetEnumerator()) //445:13
                select new { __loop25_var1 = __loop25_var1, prop = prop}
                ).ToList(); //445:3
            int __loop25_iteration = 0;
            foreach (var __tmp4 in __loop25_results)
            {
                ++__loop25_iteration;
                var __loop25_var1 = __tmp4.__loop25_var1;
                var prop = __tmp4.prop;
                MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //446:4
                if (synInit != null) //447:4
                {
                    if (prop.Kind != MetaPropertyKind.Derived) //448:5
                    {
                        if (ModelContext.Current.Compiler.TypeProvider.GetTypeOf(synInit.Value) is MetaCollectionType) //449:6
                        {
                            string __tmp5Prefix = "    this.MLazySet("; //450:1
                            string __tmp6Suffix = "));"; //450:159
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
                            string __tmp8Line = "Descriptor."; //450:43
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
                            string __tmp10Line = "."; //450:79
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
                            string __tmp12Line = "Property, new Lazy<object>(() => "; //450:91
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
                                    __out.AppendLine(); //450:162
                                }
                            }
                        }
                        else //451:6
                        {
                            string __tmp14Prefix = "    this.MLazySet("; //452:1
                            string __tmp15Suffix = "));"; //452:159
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
                            string __tmp17Line = "Descriptor."; //452:43
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
                            string __tmp19Line = "."; //452:79
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
                            string __tmp21Line = "Property, new Lazy<object>(() => "; //452:91
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
                                    __out.AppendLine(); //452:162
                                }
                            }
                        }
                    }
                }
                else //455:4
                {
                    if (prop.Type is MetaCollectionType) //456:5
                    {
                        if (prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) //457:6
                        {
                            string __tmp23Prefix = "    this.MSet("; //458:1
                            string __tmp24Suffix = "));"; //458:164
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
                            string __tmp26Line = "Descriptor."; //458:39
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
                            string __tmp28Line = "."; //458:75
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
                            string __tmp30Line = "Property, new "; //458:87
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
                            string __tmp32Line = "("; //458:125
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
                                    __out.AppendLine(); //458:167
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //459:6
                        {
                            string __tmp34Prefix = "    this.MLazySet("; //460:1
                            string __tmp35Suffix = "(this)));"; //460:211
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
                            string __tmp37Line = "Descriptor."; //460:43
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
                            string __tmp39Line = "."; //460:79
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
                            string __tmp41Line = "Property, new Lazy<object>(() => "; //460:91
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
                            string __tmp43Line = "ImplementationProvider.Implementation."; //460:136
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
                            string __tmp45Line = "_"; //460:199
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
                                    __out.AppendLine(); //460:220
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Readonly) //461:6
                        {
                            string __tmp47Prefix = "    // Init "; //462:1
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
                            string __tmp50Line = "Descriptor."; //462:37
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
                            string __tmp52Line = "."; //462:73
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
                            string __tmp54Line = "Property in "; //462:85
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
                            string __tmp56Line = "Implementation."; //462:109
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
                            string __tmp58Line = "_"; //462:142
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
                                    __out.AppendLine(); //462:161
                                }
                            }
                        }
                    }
                    else //464:5
                    {
                        if (prop.Kind == MetaPropertyKind.Lazy) //465:6
                        {
                            string __tmp60Prefix = "    this.MLazySet("; //466:1
                            string __tmp61Suffix = "(this)));"; //466:211
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
                            string __tmp63Line = "Descriptor."; //466:43
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
                            string __tmp65Line = "."; //466:79
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
                            string __tmp67Line = "Property, new Lazy<object>(() => "; //466:91
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
                            string __tmp69Line = "ImplementationProvider.Implementation."; //466:136
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
                            string __tmp71Line = "_"; //466:199
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
                                    __out.AppendLine(); //466:220
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Readonly) //467:6
                        {
                            string __tmp73Prefix = "    // Init "; //468:1
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
                            string __tmp76Line = "Descriptor."; //468:37
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
                            string __tmp78Line = "."; //468:73
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
                            string __tmp80Line = "Property in "; //468:85
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
                            string __tmp82Line = "Implementation."; //468:109
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
                            string __tmp84Line = "_"; //468:142
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
                                    __out.AppendLine(); //468:161
                                }
                            }
                        }
                    }
                }
            }
            var __loop26_results = 
                (from __loop26_var1 in __Enumerate((cls).GetEnumerator()) //473:8
                from sup in __Enumerate((__loop26_var1.GetAllSuperClasses(true)).GetEnumerator()) //473:13
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //473:43
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //473:56
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaInheritedPropertyInitializer>() //473:70
                select new { __loop26_var1 = __loop26_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //473:3
            int __loop26_iteration = 0;
            foreach (var __tmp86 in __loop26_results)
            {
                ++__loop26_iteration;
                var __loop26_var1 = __tmp86.__loop26_var1;
                var sup = __tmp86.sup;
                var Constructor = __tmp86.Constructor;
                var Initializers = __tmp86.Initializers;
                var init = __tmp86.init;
                if (init.Object != null && init.Property != null) //474:4
                {
                    string __tmp87Prefix = "    this.MLazySetChild("; //475:1
                    string __tmp88Suffix = "));"; //475:313
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
                    string __tmp90Line = "Descriptor."; //475:66
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
                    string __tmp92Line = "."; //475:109
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
                    string __tmp94Line = "Property, "; //475:128
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
                    string __tmp96Line = "Descriptor."; //475:182
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
                    string __tmp98Line = "."; //475:227
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
                    string __tmp100Line = "Property, new Lazy<object>(() => "; //475:248
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
                            __out.AppendLine(); //475:316
                        }
                    }
                }
            }
            string __tmp102Prefix = "    "; //478:1
            string __tmp103Suffix = "(this);"; //478:96
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
            string __tmp105Line = "ImplementationProvider.Implementation."; //478:21
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
            string __tmp107Line = "_"; //478:77
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
                    __out.AppendLine(); //478:103
                }
            }
            var __loop27_results = 
                (from __loop27_var1 in __Enumerate((cls).GetEnumerator()) //479:11
                from prop in __Enumerate((__loop27_var1.GetAllProperties()).GetEnumerator()) //479:16
                select new { __loop27_var1 = __loop27_var1, prop = prop}
                ).ToList(); //479:6
            int __loop27_iteration = 0;
            foreach (var __tmp109 in __loop27_results)
            {
                ++__loop27_iteration;
                var __loop27_var1 = __tmp109.__loop27_var1;
                var prop = __tmp109.prop;
                if (prop.Kind == MetaPropertyKind.Readonly) //480:4
                {
                    string __tmp110Prefix = "    if (!this.MIsSet("; //481:1
                    string __tmp111Suffix = "().\");"; //481:268
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
                    string __tmp113Line = "Descriptor."; //481:46
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
                    string __tmp115Line = "."; //481:82
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
                    string __tmp117Line = "Property)) throw new ModelException(\"Readonly property "; //481:94
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
                    string __tmp119Line = "."; //481:169
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
                    string __tmp121Line = "."; //481:195
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
                    string __tmp123Line = "Property was not set in "; //481:207
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
                    string __tmp125Line = "_"; //481:249
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
                            __out.AppendLine(); //481:274
                        }
                    }
                }
            }
            __out.Append("    this.MMakeDefault();"); //484:1
            __out.AppendLine(); //484:25
            __out.Append("}"); //485:1
            __out.AppendLine(); //485:2
            return __out.ToString();
        }

        public string GetReturn(MetaOperation op) //488:1
        {
            if (op.ReturnType.CSharpName() == "void") //489:5
            {
                return ""; //490:3
            }
            else //491:2
            {
                return "return "; //492:3
            }
        }

        public string GenerateOperationImpl(MetaModel model, MetaOperation op) //496:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //497:2
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = ")"; //498:97
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
            string __tmp4Line = " "; //498:35
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
            string __tmp6Line = "."; //498:60
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
            string __tmp8Line = "("; //498:70
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
                    __out.AppendLine(); //498:98
                }
            }
            __out.Append("{"); //499:1
            __out.AppendLine(); //499:2
            string __tmp10Prefix = "    "; //500:1
            string __tmp11Suffix = ");"; //500:136
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
            string __tmp14Line = "ImplementationProvider.Implementation."; //500:32
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
            string __tmp16Line = "_"; //500:94
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
            string __tmp18Line = "("; //500:104
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
                    __out.AppendLine(); //500:138
                }
            }
            __out.Append("}"); //501:1
            __out.AppendLine(); //501:2
            return __out.ToString();
        }

        public string GetSuperClasses(MetaClass cls) //504:1
        {
            string result = ""; //505:2
            var __loop28_results = 
                (from __loop28_var1 in __Enumerate((cls).GetEnumerator()) //506:10
                from sup in __Enumerate((__loop28_var1.SuperClasses).GetEnumerator()) //506:15
                select new { __loop28_var1 = __loop28_var1, sup = sup}
                ).ToList(); //506:5
            int __loop28_iteration = 0;
            string delim = ""; //506:33
            foreach (var __tmp1 in __loop28_results)
            {
                ++__loop28_iteration;
                if (__loop28_iteration >= 2) //506:52
                {
                    delim = ", "; //506:52
                }
                var __loop28_var1 = __tmp1.__loop28_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpName(); //507:3
            }
            return result; //509:2
        }

        public string GetAllSuperClasses(MetaClass cls) //512:1
        {
            string result = ""; //513:2
            var __loop29_results = 
                (from __loop29_var1 in __Enumerate((cls).GetEnumerator()) //514:10
                from sup in __Enumerate((__loop29_var1.GetAllSuperClasses(false)).GetEnumerator()) //514:15
                select new { __loop29_var1 = __loop29_var1, sup = sup}
                ).ToList(); //514:5
            int __loop29_iteration = 0;
            string delim = ""; //514:46
            foreach (var __tmp1 in __loop29_results)
            {
                ++__loop29_iteration;
                if (__loop29_iteration >= 2) //514:65
                {
                    delim = ", "; //514:65
                }
                var __loop29_var1 = __tmp1.__loop29_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpName(); //515:3
            }
            return result; //517:2
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //520:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public static class "; //521:1
            string __tmp2Suffix = "Descriptor"; //521:33
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
                    __out.AppendLine(); //521:43
                }
            }
            __out.Append("{"); //522:1
            __out.AppendLine(); //522:2
            string __tmp4Prefix = "    static "; //523:1
            string __tmp5Suffix = "Descriptor()"; //523:24
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
                    __out.AppendLine(); //523:36
                }
            }
            __out.Append("    {"); //524:1
            __out.AppendLine(); //524:6
            var __loop30_results = 
                (from __loop30_var1 in __Enumerate((model).GetEnumerator()) //525:11
                from Namespace in __Enumerate((__loop30_var1.Namespace).GetEnumerator()) //525:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //525:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //525:43
                select new { __loop30_var1 = __loop30_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //525:6
            int __loop30_iteration = 0;
            foreach (var __tmp7 in __loop30_results)
            {
                ++__loop30_iteration;
                var __loop30_var1 = __tmp7.__loop30_var1;
                var Namespace = __tmp7.Namespace;
                var Declarations = __tmp7.Declarations;
                var cls = __tmp7.cls;
                string __tmp8Prefix = "        "; //526:1
                string __tmp9Suffix = ".StaticInit();"; //526:27
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
                        __out.AppendLine(); //526:41
                    }
                }
            }
            __out.Append("    }"); //528:1
            __out.AppendLine(); //528:6
            __out.AppendLine(); //529:2
            __out.Append("    internal static void StaticInit()"); //530:1
            __out.AppendLine(); //530:38
            __out.Append("    {"); //531:1
            __out.AppendLine(); //531:6
            __out.Append("    }"); //532:1
            __out.AppendLine(); //532:6
            __out.AppendLine(); //533:2
            string __tmp11Prefix = "	public const string Uri = \""; //534:1
            string __tmp12Suffix = "\";"; //534:40
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
                    __out.AppendLine(); //534:42
                }
            }
            __out.AppendLine(); //535:2
            __out.Append("    public static class Constants"); //536:1
            __out.AppendLine(); //536:34
            __out.Append("    {"); //537:1
            __out.AppendLine(); //537:6
            var __loop31_results = 
                (from __loop31_var1 in __Enumerate((model).GetEnumerator()) //538:11
                from Namespace in __Enumerate((__loop31_var1.Namespace).GetEnumerator()) //538:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //538:29
                from mconst in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //538:43
                select new { __loop31_var1 = __loop31_var1, Namespace = Namespace, Declarations = Declarations, mconst = mconst}
                ).ToList(); //538:6
            int __loop31_iteration = 0;
            foreach (var __tmp14 in __loop31_results)
            {
                ++__loop31_iteration;
                var __loop31_var1 = __tmp14.__loop31_var1;
                var Namespace = __tmp14.Namespace;
                var Declarations = __tmp14.Declarations;
                var mconst = __tmp14.mconst;
                string __tmp15Prefix = "		public static "; //539:1
                string __tmp16Suffix = string.Empty; 
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(mconst.Type.CSharpFullName());
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
                string __tmp18Line = " "; //539:47
                __out.Append(__tmp18Line);
                StringBuilder __tmp19 = new StringBuilder();
                __tmp19.Append(mconst.Name);
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
                        __out.AppendLine(); //539:61
                    }
                }
                __out.Append("		{"); //540:1
                __out.AppendLine(); //540:4
                string __tmp20Prefix = "			get { return "; //541:1
                string __tmp21Suffix = "; }"; //541:51
                StringBuilder __tmp22 = new StringBuilder();
                __tmp22.Append(model.Name);
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
                string __tmp23Line = "Instance."; //541:29
                __out.Append(__tmp23Line);
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(mconst.Name);
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
                        __out.AppendLine(); //541:54
                    }
                }
                __out.Append("		}"); //542:1
                __out.AppendLine(); //542:4
            }
            __out.AppendLine(); //544:2
            var __loop32_results = 
                (from __loop32_var1 in __Enumerate((model).GetEnumerator()) //545:11
                from Namespace in __Enumerate((__loop32_var1.Namespace).GetEnumerator()) //545:18
                from decl in __Enumerate((Namespace.Declarations).GetEnumerator()) //545:29
                from a in __Enumerate((decl.Annotations).GetEnumerator()) //545:48
                from p in __Enumerate((a.Properties).GetEnumerator()) //545:63
                where a.Name == "BuiltInName" && p.Name == "Name" //545:76
                select new { __loop32_var1 = __loop32_var1, Namespace = Namespace, decl = decl, a = a, p = p}
                ).ToList(); //545:6
            int __loop32_iteration = 0;
            foreach (var __tmp25 in __loop32_results)
            {
                ++__loop32_iteration;
                var __loop32_var1 = __tmp25.__loop32_var1;
                var Namespace = __tmp25.Namespace;
                var decl = __tmp25.decl;
                var a = __tmp25.a;
                var p = __tmp25.p;
                string __tmp26Prefix = "		public static global::MetaDslx.Core."; //546:1
                string __tmp27Suffix = string.Empty; 
                StringBuilder __tmp28 = new StringBuilder();
                __tmp28.Append(((ModelObject)decl).GetMetaClass().CSharpName());
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
                string __tmp29Line = " "; //546:88
                __out.Append(__tmp29Line);
                StringBuilder __tmp30 = new StringBuilder();
                __tmp30.Append(GetCSharpIdentifier(p.Value));
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
                        __out.AppendLine(); //546:119
                    }
                }
                __out.Append("		{"); //547:1
                __out.AppendLine(); //547:4
                string __tmp31Prefix = "			get { return "; //548:1
                string __tmp32Suffix = "; }"; //548:68
                StringBuilder __tmp33 = new StringBuilder();
                __tmp33.Append(model.Name);
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
                string __tmp34Line = "Instance."; //548:29
                __out.Append(__tmp34Line);
                StringBuilder __tmp35 = new StringBuilder();
                __tmp35.Append(GetCSharpIdentifier(p.Value));
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
                        __out.Append(__tmp32Suffix);
                        __out.AppendLine(); //548:71
                    }
                }
                __out.Append("		}"); //549:1
                __out.AppendLine(); //549:4
            }
            __out.Append("    }"); //551:1
            __out.AppendLine(); //551:6
            __out.AppendLine(); //552:2
            var __loop33_results = 
                (from __loop33_var1 in __Enumerate((model).GetEnumerator()) //553:11
                from Namespace in __Enumerate((__loop33_var1.Namespace).GetEnumerator()) //553:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //553:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //553:43
                select new { __loop33_var1 = __loop33_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //553:6
            int __loop33_iteration = 0;
            foreach (var __tmp36 in __loop33_results)
            {
                ++__loop33_iteration;
                var __loop33_var1 = __tmp36.__loop33_var1;
                var Namespace = __tmp36.Namespace;
                var Declarations = __tmp36.Declarations;
                var cls = __tmp36.cls;
                string __tmp37Prefix = "    "; //554:1
                string __tmp38Suffix = string.Empty; 
                StringBuilder __tmp39 = new StringBuilder();
                __tmp39.Append(GenerateMetaModelClass(cls));
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
                        __out.Append(__tmp38Suffix);
                        __out.AppendLine(); //554:34
                    }
                }
            }
            __out.Append("}"); //556:1
            __out.AppendLine(); //556:2
            __out.AppendLine(); //557:2
            return __out.ToString();
        }

        public string GenerateMetaModelClass(MetaClass cls) //561:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //562:2
            string __tmp1Prefix = "public static class "; //563:1
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
                    __out.AppendLine(); //563:39
                }
            }
            __out.Append("{"); //564:1
            __out.AppendLine(); //564:2
            __out.Append("    internal static void StaticInit()"); //565:1
            __out.AppendLine(); //565:38
            __out.Append("    {"); //566:1
            __out.AppendLine(); //566:6
            __out.Append("    }"); //567:1
            __out.AppendLine(); //567:6
            __out.AppendLine(); //568:2
            string __tmp4Prefix = "    static "; //569:1
            string __tmp5Suffix = "()"; //569:30
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
                    __out.AppendLine(); //569:32
                }
            }
            __out.Append("    {"); //570:1
            __out.AppendLine(); //570:6
            string __tmp7Prefix = "        "; //571:1
            string __tmp8Suffix = "Descriptor.StaticInit();"; //571:37
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
                    __out.AppendLine(); //571:61
                }
            }
            __out.Append("    }"); //572:1
            __out.AppendLine(); //572:6
            __out.AppendLine(); //573:2
            __out.Append("    public static global::MetaDslx.Core.MetaClass GetMetaClass()"); //574:1
            __out.AppendLine(); //574:65
            __out.Append("    {"); //575:1
            __out.AppendLine(); //575:6
            string __tmp10Prefix = "        return "; //576:1
            string __tmp11Suffix = ";"; //576:71
            StringBuilder __tmp12 = new StringBuilder();
            __tmp12.Append(cls.Model.CSharpFullName());
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
            string __tmp13Line = "Instance."; //576:44
            __out.Append(__tmp13Line);
            StringBuilder __tmp14 = new StringBuilder();
            __tmp14.Append(cls.CSharpName());
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
                    __out.AppendLine(); //576:72
                }
            }
            __out.Append("    }"); //577:1
            __out.AppendLine(); //577:6
            __out.AppendLine(); //578:2
            var __loop34_results = 
                (from __loop34_var1 in __Enumerate((cls).GetEnumerator()) //579:11
                from prop in __Enumerate((__loop34_var1.Properties).GetEnumerator()) //579:16
                select new { __loop34_var1 = __loop34_var1, prop = prop}
                ).ToList(); //579:6
            int __loop34_iteration = 0;
            foreach (var __tmp15 in __loop34_results)
            {
                ++__loop34_iteration;
                var __loop34_var1 = __tmp15.__loop34_var1;
                var prop = __tmp15.prop;
                string __tmp16Prefix = "    "; //580:1
                string __tmp17Suffix = string.Empty; 
                StringBuilder __tmp18 = new StringBuilder();
                __tmp18.Append(GeneratePropertyDeclaration(cls.Model, cls, prop));
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
                        __out.AppendLine(); //580:56
                    }
                }
            }
            __out.Append("}"); //582:1
            __out.AppendLine(); //582:2
            return __out.ToString();
        }

        public string GenerateModelConstant(MetaModel model, MetaConstant mconst) //586:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public static readonly "; //587:1
            string __tmp2Suffix = ";"; //587:68
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
            string __tmp4Line = " "; //587:54
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
                    __out.AppendLine(); //587:69
                }
            }
            return __out.ToString();
        }

        public string GenerateModelFunction(MetaModel model, MetaFunction mfunc) //590:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public static readonly global::MetaDslx.Core.MetaFunction "; //591:1
            string __tmp2Suffix = ";"; //591:71
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
                    __out.AppendLine(); //591:72
                }
            }
            return __out.ToString();
        }

        public string GenerateModelConstantImpl(MetaModel model, MetaConstant mconst, Dictionary<ModelObject,string> mobjToTmp) //594:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = ";"; //595:51
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
            string __tmp4Line = " = "; //595:14
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
                    __out.AppendLine(); //595:52
                }
            }
            return __out.ToString();
        }

        public string GenerateModelFunctionImpl(MetaModel model, MetaFunction mfunc, Dictionary<ModelObject,string> mobjToTmp) //598:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = "Factory.Instance.CreateMetaFunction();"; //599:102
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
            string __tmp4Line = " = global::MetaDslx.Core."; //599:65
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
                    __out.AppendLine(); //599:140
                }
            }
            return __out.ToString();
        }

        public string GenerateModelFunctionImpl0(MetaModel model, MetaFunction mfunc, Dictionary<ModelObject,string> mobjToTmp) //603:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = "Factory.Instance.CreateMetaFunction();"; //604:102
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
            string __tmp4Line = " = global::MetaDslx.Core."; //604:65
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
                    __out.AppendLine(); //604:140
                }
            }
            if ((from __loop35_var1 in __Enumerate((mfunc).GetEnumerator()) //605:14
            from a in __Enumerate((__loop35_var1.Annotations).GetEnumerator()) //605:21
            where a.Name == "BuiltInName" //605:35
            select new { __loop35_var1 = __loop35_var1, a = a}
            ).GetEnumerator().MoveNext()) //605:2
            {
                var __loop36_results = 
                    (from __loop36_var1 in __Enumerate((mfunc).GetEnumerator()) //606:8
                    from a in __Enumerate((__loop36_var1.Annotations).GetEnumerator()) //606:15
                    from p in __Enumerate((a.Properties).GetEnumerator()) //606:30
                    where a.Name == "BuiltInName" && p.Name == "RenameTo" //606:43
                    select new { __loop36_var1 = __loop36_var1, a = a, p = p}
                    ).ToList(); //606:3
                int __loop36_iteration = 0;
                foreach (var __tmp6 in __loop36_results)
                {
                    ++__loop36_iteration;
                    var __loop36_var1 = __tmp6.__loop36_var1;
                    var a = __tmp6.a;
                    var p = __tmp6.p;
                    string __tmp7Prefix = string.Empty; 
                    string __tmp8Suffix = ";"; //607:50
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
                    string __tmp10Line = ".Name = "; //607:13
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
                            __out.AppendLine(); //607:51
                        }
                    }
                }
            }
            else //609:2
            {
                string __tmp12Prefix = string.Empty; 
                string __tmp13Suffix = "\";"; //610:34
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
                string __tmp15Line = ".Name = \""; //610:13
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
                        __out.AppendLine(); //610:36
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
                    __out.AppendLine(); //612:153
                }
            }
            var __loop37_results = 
                (from __loop37_var1 in __Enumerate((mfunc).GetEnumerator()) //613:7
                from p in __Enumerate((__loop37_var1.Parameters).GetEnumerator()) //613:14
                select new { __loop37_var1 = __loop37_var1, p = p}
                ).ToList(); //613:2
            int __loop37_iteration = 0;
            foreach (var __tmp20 in __loop37_results)
            {
                ++__loop37_iteration;
                var __loop37_var1 = __tmp20.__loop37_var1;
                var p = __tmp20.p;
                string tmpName = "tmp" + NextCounter(); //614:2
                string __tmp21Prefix = "global::MetaDslx.Core.MetaParameter "; //615:1
                string __tmp22Suffix = "Factory.Instance.CreateMetaParameter();"; //615:83
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
                string __tmp24Line = " = global::MetaDslx.Core."; //615:46
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
                        __out.AppendLine(); //615:122
                    }
                }
                string __tmp26Prefix = string.Empty; 
                string __tmp27Suffix = "\";"; //616:27
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
                string __tmp29Line = ".Name = \""; //616:10
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
                        __out.AppendLine(); //616:29
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
                        __out.AppendLine(); //617:138
                    }
                }
                string __tmp34Prefix = string.Empty; 
                string __tmp35Suffix = ");"; //618:38
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
                string __tmp37Line = ".Parameters.Add("; //618:13
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
                        __out.AppendLine(); //618:40
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelFunctionImplTypeOf(MetaModel model, string name, string propertyName, MetaType mtype) //622:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = mtype; //623:9
            if (mtype is MetaCollectionType) //624:2
            {
                string tmpName = "tmp" + NextCounter(); //625:2
                string __tmp2Prefix = "global::MetaDslx.Core.MetaCollectionType "; //626:1
                string __tmp3Suffix = "Factory.Instance.CreateMetaCollectionType();"; //626:88
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
                string __tmp5Line = " = global::MetaDslx.Core."; //626:51
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
                        __out.AppendLine(); //626:132
                    }
                }
                string __tmp7Prefix = string.Empty; 
                string __tmp8Suffix = ";"; //627:49
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
                string __tmp10Line = ".Kind = MetaCollectionKind."; //627:10
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
                        __out.AppendLine(); //627:50
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
                        __out.AppendLine(); //628:154
                    }
                }
                if (propertyName != null) //629:2
                {
                    string __tmp15Prefix = "((ModelObject)"; //630:1
                    string __tmp16Suffix = "));"; //630:80
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
                    string __tmp18Line = ").MLazyAdd("; //630:21
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
                    string __tmp20Line = ", new Lazy<object>(() => "; //630:46
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
                            __out.AppendLine(); //630:83
                        }
                    }
                }
                else //631:2
                {
                    string __tmp22Prefix = string.Empty; 
                    string __tmp23Suffix = ";"; //632:19
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
                    string __tmp25Line = " = "; //632:7
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
                            __out.AppendLine(); //632:20
                        }
                    }
                }
            }
            else //634:2
            {
                if (propertyName != null) //635:2
                {
                    string __tmp27Prefix = "((ModelObject)"; //636:1
                    string __tmp28Suffix = "));"; //636:94
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
                    string __tmp30Line = ").MLazyAdd("; //636:21
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
                    string __tmp32Line = ", new Lazy<object>(() => "; //636:46
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
                            __out.AppendLine(); //636:97
                        }
                    }
                }
                else //637:2
                {
                    string __tmp34Prefix = string.Empty; 
                    string __tmp35Suffix = ";"; //638:33
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
                    string __tmp37Line = " = "; //638:7
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
                            __out.AppendLine(); //638:34
                        }
                    }
                }
            }//640:2
            return __out.ToString();
        }

        public string GenerateMetaModelInstance(MetaModel model) //644:1
        {
            StringBuilder __out = new StringBuilder();
            Dictionary<ModelObject,string> mobjToTmp = new Dictionary<ModelObject,string>(); //645:2
            string __tmp1Prefix = "public static class "; //646:1
            string __tmp2Suffix = "Instance"; //646:33
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
                    __out.AppendLine(); //646:41
                }
            }
            __out.Append("{"); //647:1
            __out.AppendLine(); //647:2
            __out.Append("    internal static global::MetaDslx.Core.Model model;"); //648:1
            __out.AppendLine(); //648:55
            __out.AppendLine(); //649:2
            string __tmp4Prefix = "    static "; //650:1
            string __tmp5Suffix = "Instance()"; //650:24
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
                    __out.AppendLine(); //650:34
                }
            }
            __out.Append("    {"); //651:1
            __out.AppendLine(); //651:6
            string __tmp7Prefix = "		"; //652:1
            string __tmp8Suffix = "Descriptor.StaticInit();"; //652:15
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
                    __out.AppendLine(); //652:39
                }
            }
            string __tmp10Prefix = "		"; //653:1
            string __tmp11Suffix = "Instance.model = new global::MetaDslx.Core.Model();"; //653:15
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
                    __out.AppendLine(); //653:66
                }
            }
            string __tmp13Prefix = "   		using (new ModelContextScope("; //654:1
            string __tmp14Suffix = "Instance.model))"; //654:47
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
                    __out.AppendLine(); //654:63
                }
            }
            __out.Append("		{"); //655:1
            __out.AppendLine(); //655:4
            var __loop38_results = 
                (from __loop38_var1 in __Enumerate((model).GetEnumerator()) //656:13
                from Namespace in __Enumerate((__loop38_var1.Namespace).GetEnumerator()) //656:20
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //656:31
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //656:45
                select new { __loop38_var1 = __loop38_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //656:8
            int __loop38_iteration = 0;
            foreach (var __tmp16 in __loop38_results)
            {
                ++__loop38_iteration;
                var __loop38_var1 = __tmp16.__loop38_var1;
                var Namespace = __tmp16.Namespace;
                var Declarations = __tmp16.Declarations;
                var c = __tmp16.c;
                string __tmp17Prefix = "            "; //657:1
                string __tmp18Suffix = string.Empty; 
                StringBuilder __tmp19 = new StringBuilder();
                __tmp19.Append(GenerateModelConstantImpl(model, c, mobjToTmp));
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
                        __out.AppendLine(); //657:61
                    }
                }
            }
            __out.AppendLine(); //659:2
            string __tmp20Prefix = "			"; //660:1
            string __tmp21Suffix = string.Empty; 
            StringBuilder __tmp22 = new StringBuilder();
            __tmp22.Append(GenerateModelObjectInstance((ModelObject)model.Namespace.Parent, mobjToTmp));
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
                    __out.AppendLine(); //660:81
                }
            }
            __out.AppendLine(); //661:2
            var __loop39_results = 
                (from __loop39_var1 in __Enumerate((model).GetEnumerator()) //662:10
                from Namespace in __Enumerate((__loop39_var1.Namespace).GetEnumerator()) //662:17
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //662:28
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //662:42
                select new { __loop39_var1 = __loop39_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //662:5
            int __loop39_iteration = 0;
            foreach (var __tmp23 in __loop39_results)
            {
                ++__loop39_iteration;
                var __loop39_var1 = __tmp23.__loop39_var1;
                var Namespace = __tmp23.Namespace;
                var Declarations = __tmp23.Declarations;
                var cls = __tmp23.cls;
                string __tmp24Prefix = "			"; //663:1
                string __tmp25Suffix = ";"; //663:54
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
                        __out.Append(__tmp24Prefix);
                        __out.Append(__tmp26Line);
                    }
                }
                string __tmp27Line = " = "; //663:22
                __out.Append(__tmp27Line);
                StringBuilder __tmp28 = new StringBuilder();
                __tmp28.Append(mobjToTmp[(ModelObject)cls]);
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
                        __out.Append(__tmp25Suffix);
                        __out.AppendLine(); //663:55
                    }
                }
                var __loop40_results = 
                    (from __loop40_var1 in __Enumerate((cls).GetEnumerator()) //664:11
                    from prop in __Enumerate((__loop40_var1.Properties).GetEnumerator()) //664:16
                    select new { __loop40_var1 = __loop40_var1, prop = prop}
                    ).ToList(); //664:6
                int __loop40_iteration = 0;
                foreach (var __tmp29 in __loop40_results)
                {
                    ++__loop40_iteration;
                    var __loop40_var1 = __tmp29.__loop40_var1;
                    var prop = __tmp29.prop;
                    string __tmp30Prefix = "			"; //665:1
                    string __tmp31Suffix = ";"; //665:75
                    StringBuilder __tmp32 = new StringBuilder();
                    __tmp32.Append(cls.CSharpName());
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
                    string __tmp33Line = "_"; //665:22
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
                        }
                    }
                    string __tmp35Line = "Property = "; //665:34
                    __out.Append(__tmp35Line);
                    StringBuilder __tmp36 = new StringBuilder();
                    __tmp36.Append(mobjToTmp[(ModelObject)prop]);
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
                            __out.AppendLine(); //665:76
                        }
                    }
                }
            }
            __out.AppendLine(); //668:2
            string __tmp37Prefix = "			"; //669:1
            string __tmp38Suffix = string.Empty; 
            StringBuilder __tmp39 = new StringBuilder();
            __tmp39.Append(GenerateModelObjectInstanceInitializer((ModelObject)model.Namespace.Parent, mobjToTmp));
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
                    __out.Append(__tmp38Suffix);
                    __out.AppendLine(); //669:92
                }
            }
            __out.AppendLine(); //670:2
            __out.Append("            foreach (var mo in ModelContext.Current.Model.Instances)"); //671:1
            __out.AppendLine(); //671:69
            __out.Append("            {"); //672:1
            __out.AppendLine(); //672:14
            __out.Append("                mo.MEvalLazyValues();"); //673:1
            __out.AppendLine(); //673:38
            __out.Append("            }"); //674:1
            __out.AppendLine(); //674:14
            __out.Append("		}"); //675:1
            __out.AppendLine(); //675:4
            __out.Append("    }"); //676:1
            __out.AppendLine(); //676:6
            __out.AppendLine(); //677:2
            __out.Append("    public static global::MetaDslx.Core.Model Model"); //678:1
            __out.AppendLine(); //678:52
            __out.Append("    {"); //679:1
            __out.AppendLine(); //679:6
            __out.Append("        get "); //680:1
            __out.AppendLine(); //680:13
            __out.Append("		{ "); //681:1
            __out.AppendLine(); //681:5
            string __tmp40Prefix = "			return "; //682:1
            string __tmp41Suffix = "Instance.model; "; //682:23
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
                    __out.Append(__tmp40Prefix);
                    __out.Append(__tmp42Line);
                    __out.Append(__tmp41Suffix);
                    __out.AppendLine(); //682:39
                }
            }
            __out.Append("		}"); //683:1
            __out.AppendLine(); //683:4
            __out.Append("    }"); //684:1
            __out.AppendLine(); //684:6
            __out.AppendLine(); //685:2
            var __loop41_results = 
                (from __loop41_var1 in __Enumerate((model).GetEnumerator()) //686:11
                from Namespace in __Enumerate((__loop41_var1.Namespace).GetEnumerator()) //686:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //686:29
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //686:43
                select new { __loop41_var1 = __loop41_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //686:6
            int __loop41_iteration = 0;
            foreach (var __tmp43 in __loop41_results)
            {
                ++__loop41_iteration;
                var __loop41_var1 = __tmp43.__loop41_var1;
                var Namespace = __tmp43.Namespace;
                var Declarations = __tmp43.Declarations;
                var c = __tmp43.c;
                string __tmp44Prefix = "    "; //687:1
                string __tmp45Suffix = string.Empty; 
                StringBuilder __tmp46 = new StringBuilder();
                __tmp46.Append(GenerateModelConstant(model, c));
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
                        __out.AppendLine(); //687:38
                    }
                }
            }
            __out.AppendLine(); //689:2
            var __loop42_results = 
                (from __loop42_var1 in __Enumerate((model).GetEnumerator()) //690:11
                from Namespace in __Enumerate((__loop42_var1.Namespace).GetEnumerator()) //690:18
                from decl in __Enumerate((Namespace.Declarations).GetEnumerator()) //690:29
                from a in __Enumerate((decl.Annotations).GetEnumerator()) //690:48
                from p in __Enumerate((a.Properties).GetEnumerator()) //690:63
                where a.Name == "BuiltInName" && p.Name == "Name" //690:76
                select new { __loop42_var1 = __loop42_var1, Namespace = Namespace, decl = decl, a = a, p = p}
                ).ToList(); //690:6
            int __loop42_iteration = 0;
            foreach (var __tmp47 in __loop42_results)
            {
                ++__loop42_iteration;
                var __loop42_var1 = __tmp47.__loop42_var1;
                var Namespace = __tmp47.Namespace;
                var decl = __tmp47.decl;
                var a = __tmp47.a;
                var p = __tmp47.p;
                string __tmp48Prefix = "    public static readonly global::MetaDslx.Core."; //691:1
                string __tmp49Suffix = ";"; //691:130
                StringBuilder __tmp50 = new StringBuilder();
                __tmp50.Append(((ModelObject)decl).GetMetaClass().CSharpName());
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
                        __out.Append(__tmp48Prefix);
                        __out.Append(__tmp50Line);
                    }
                }
                string __tmp51Line = " "; //691:99
                __out.Append(__tmp51Line);
                StringBuilder __tmp52 = new StringBuilder();
                __tmp52.Append(GetCSharpIdentifier(p.Value));
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
                        __out.Append(__tmp49Suffix);
                        __out.AppendLine(); //691:131
                    }
                }
            }
            __out.AppendLine(); //693:2
            var __loop43_results = 
                (from __loop43_var1 in __Enumerate((model).GetEnumerator()) //694:8
                from Namespace in __Enumerate((__loop43_var1.Namespace).GetEnumerator()) //694:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //694:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //694:40
                select new { __loop43_var1 = __loop43_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //694:3
            int __loop43_iteration = 0;
            foreach (var __tmp53 in __loop43_results)
            {
                ++__loop43_iteration;
                var __loop43_var1 = __tmp53.__loop43_var1;
                var Namespace = __tmp53.Namespace;
                var Declarations = __tmp53.Declarations;
                var cls = __tmp53.cls;
                string __tmp54Prefix = "	public static readonly global::MetaDslx.Core.MetaClass "; //695:1
                string __tmp55Suffix = ";"; //695:75
                StringBuilder __tmp56 = new StringBuilder();
                __tmp56.Append(cls.CSharpName());
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
                        __out.AppendLine(); //695:76
                    }
                }
            }
            __out.AppendLine(); //697:2
            var __loop44_results = 
                (from __loop44_var1 in __Enumerate((model).GetEnumerator()) //698:8
                from Namespace in __Enumerate((__loop44_var1.Namespace).GetEnumerator()) //698:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //698:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //698:40
                from prop in __Enumerate((cls.Properties).GetEnumerator()) //698:63
                select new { __loop44_var1 = __loop44_var1, Namespace = Namespace, Declarations = Declarations, cls = cls, prop = prop}
                ).ToList(); //698:3
            int __loop44_iteration = 0;
            foreach (var __tmp57 in __loop44_results)
            {
                ++__loop44_iteration;
                var __loop44_var1 = __tmp57.__loop44_var1;
                var Namespace = __tmp57.Namespace;
                var Declarations = __tmp57.Declarations;
                var cls = __tmp57.cls;
                var prop = __tmp57.prop;
                string __tmp58Prefix = "	public static readonly global::MetaDslx.Core.MetaProperty "; //699:1
                string __tmp59Suffix = "Property;"; //699:90
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
                        __out.Append(__tmp58Prefix);
                        __out.Append(__tmp60Line);
                    }
                }
                string __tmp61Line = "_"; //699:78
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
                        __out.Append(__tmp59Suffix);
                        __out.AppendLine(); //699:99
                    }
                }
            }
            __out.Append("}"); //701:1
            __out.AppendLine(); //701:2
            return __out.ToString();
        }

        public string RegisterModelObject(ModelObject mobj, Dictionary<ModelObject,string> mobjToTmp, string name) //704:1
        {
            if (!mobjToTmp.ContainsKey(mobj)) //705:2
            {
                string tmpName = name; //706:3
                mobjToTmp.Add(mobj, tmpName); //707:3
                return tmpName; //708:3
            }
            else //709:2
            {
                return mobjToTmp[mobj]; //710:3
            }
        }

        public string RegisterModelObject(ModelObject mobj, Dictionary<ModelObject,string> mobjToTmp) //714:1
        {
            if (!mobjToTmp.ContainsKey(mobj)) //715:2
            {
                string name = null; //716:3
                MetaAnnotatedElement mannot = mobj as MetaAnnotatedElement; //717:3
                if (mannot != null) //718:3
                {
                    var __loop45_results = 
                        (from __loop45_var1 in __Enumerate((mannot).GetEnumerator()) //719:9
                        from a in __Enumerate((__loop45_var1.Annotations).GetEnumerator()) //719:17
                        from p in __Enumerate((a.Properties).GetEnumerator()) //719:32
                        where a.Name == "BuiltInName" && p.Name == "Name" //719:45
                        select new { __loop45_var1 = __loop45_var1, a = a, p = p}
                        ).ToList(); //719:4
                    int __loop45_iteration = 0;
                    foreach (var __tmp1 in __loop45_results)
                    {
                        ++__loop45_iteration;
                        var __loop45_var1 = __tmp1.__loop45_var1;
                        var a = __tmp1.a;
                        var p = __tmp1.p;
                        name = GetCSharpIdentifier(p.Value); //720:5
                    }
                }
                if (name == null) //723:3
                {
                    name = "tmp" + NextCounter(); //724:4
                }
                mobjToTmp.Add(mobj, name); //726:3
                return name; //727:3
            }
            else //728:2
            {
                return null; //729:3
            }
        }

        public string GenerateModelObjectInstance(ModelObject mobj, Dictionary<ModelObject,string> mobjToTmp) //733:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null) //734:2
            {
                string tmpName = RegisterModelObject(mobj, mobjToTmp); //735:3
                if (tmpName != null) //736:3
                {
                    if (tmpName.StartsWith("tmp")) //737:4
                    {
                        string __tmp1Prefix = "global::MetaDslx.Core."; //738:1
                        string __tmp2Suffix = "();"; //738:153
                        StringBuilder __tmp3 = new StringBuilder();
                        __tmp3.Append(mobj.GetMetaClass().CSharpName());
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
                        string __tmp4Line = " "; //738:57
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
                            }
                        }
                        string __tmp6Line = " = global::MetaDslx.Core.MetaFactory.Instance.Create"; //738:67
                        __out.Append(__tmp6Line);
                        StringBuilder __tmp7 = new StringBuilder();
                        __tmp7.Append(mobj.GetMetaClass().CSharpName());
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
                                __out.AppendLine(); //738:156
                            }
                        }
                    }
                    else //739:4
                    {
                        string __tmp8Prefix = string.Empty; 
                        string __tmp9Suffix = "();"; //740:96
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
                                __out.Append(__tmp8Prefix);
                                __out.Append(__tmp10Line);
                            }
                        }
                        string __tmp11Line = " = global::MetaDslx.Core.MetaFactory.Instance.Create"; //740:10
                        __out.Append(__tmp11Line);
                        StringBuilder __tmp12 = new StringBuilder();
                        __tmp12.Append(mobj.GetMetaClass().CSharpName());
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
                                __out.AppendLine(); //740:99
                            }
                        }
                    }
                    var __loop46_results = 
                        (from __loop46_var1 in __Enumerate((mobj).GetEnumerator()) //742:9
                        from child in __Enumerate((__loop46_var1.MChildren).GetEnumerator()) //742:15
                        select new { __loop46_var1 = __loop46_var1, child = child}
                        ).ToList(); //742:4
                    int __loop46_iteration = 0;
                    foreach (var __tmp13 in __loop46_results)
                    {
                        ++__loop46_iteration;
                        var __loop46_var1 = __tmp13.__loop46_var1;
                        var child = __tmp13.child;
                        string __tmp14Prefix = string.Empty;
                        string __tmp15Suffix = string.Empty;
                        StringBuilder __tmp16 = new StringBuilder();
                        __tmp16.Append(GenerateModelObjectInstance(child, mobjToTmp));
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
                                __out.AppendLine(); //743:48
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceInitializer(ModelObject mobj, Dictionary<ModelObject,string> mobjToTmp) //749:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null) //750:2
            {
                var __loop47_results = 
                    (from __loop47_var1 in __Enumerate((mobj).GetEnumerator()) //751:7
                    from prop in __Enumerate((__loop47_var1.MGetAllProperties()).GetEnumerator()) //751:13
                    select new { __loop47_var1 = __loop47_var1, prop = prop}
                    ).ToList(); //751:2
                int __loop47_iteration = 0;
                foreach (var __tmp1 in __loop47_results)
                {
                    ++__loop47_iteration;
                    var __loop47_var1 = __tmp1.__loop47_var1;
                    var prop = __tmp1.prop;
                    if (prop.MetaProperty != null && prop.MetaProperty.Kind != MetaPropertyKind.Derived) //752:2
                    {
                        object propValue = mobj.MGet(prop); //753:2
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
                                __out.AppendLine(); //754:69
                            }
                        }
                    }
                }
                var __loop48_results = 
                    (from __loop48_var1 in __Enumerate((mobj).GetEnumerator()) //757:7
                    from child in __Enumerate((__loop48_var1.MChildren).GetEnumerator()) //757:13
                    select new { __loop48_var1 = __loop48_var1, child = child}
                    ).ToList(); //757:2
                int __loop48_iteration = 0;
                foreach (var __tmp5 in __loop48_results)
                {
                    ++__loop48_iteration;
                    var __loop48_var1 = __tmp5.__loop48_var1;
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
                            __out.AppendLine(); //758:59
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectPropertyValue(ModelObject mobj, ModelProperty prop, object value, Dictionary<ModelObject,string> mobjToTmp) //763:1
        {
            StringBuilder __out = new StringBuilder();
            string tmpName = mobjToTmp[mobj]; //764:2
            if (!prop.IsCollection) //765:2
            {
                string __tmp1Prefix = "((ModelObject)"; //766:1
                string __tmp2Suffix = ");"; //766:107
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
                string __tmp4Line = ").MUnSet(global::"; //766:24
                __out.Append(__tmp4Line);
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(prop.DeclaringType.FullName.Replace("+", "."));
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
                string __tmp6Line = "."; //766:87
                __out.Append(__tmp6Line);
                StringBuilder __tmp7 = new StringBuilder();
                __tmp7.Append(prop.DeclaredName);
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
                        __out.AppendLine(); //766:109
                    }
                }
            }
            ModelObject moValue = value as ModelObject; //768:2
            if (value == null) //769:2
            {
                string __tmp8Prefix = "((ModelObject)"; //770:1
                string __tmp9Suffix = ", new Lazy<object>(() => null));"; //770:109
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
                        __out.Append(__tmp8Prefix);
                        __out.Append(__tmp10Line);
                    }
                }
                string __tmp11Line = ").MLazyAdd(global::"; //770:24
                __out.Append(__tmp11Line);
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(prop.DeclaringType.FullName.Replace("+", "."));
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
                string __tmp13Line = "."; //770:89
                __out.Append(__tmp13Line);
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(prop.DeclaredName);
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
                        __out.AppendLine(); //770:141
                    }
                }
            }
            else if (value is string) //771:2
            {
                string __tmp15Prefix = "((ModelObject)"; //772:1
                string __tmp16Suffix = "\"));"; //772:142
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(tmpName);
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
                string __tmp18Line = ").MLazyAdd(global::"; //772:24
                __out.Append(__tmp18Line);
                StringBuilder __tmp19 = new StringBuilder();
                __tmp19.Append(prop.DeclaringType.FullName.Replace("+", "."));
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
                string __tmp20Line = "."; //772:89
                __out.Append(__tmp20Line);
                StringBuilder __tmp21 = new StringBuilder();
                __tmp21.Append(prop.DeclaredName);
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
                string __tmp22Line = ", new Lazy<object>(() => \""; //772:109
                __out.Append(__tmp22Line);
                StringBuilder __tmp23 = new StringBuilder();
                __tmp23.Append(value);
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
                        __out.Append(__tmp16Suffix);
                        __out.AppendLine(); //772:146
                    }
                }
            }
            else if (value is bool) //773:2
            {
                string __tmp24Prefix = "((ModelObject)"; //774:1
                string __tmp25Suffix = "));"; //774:162
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
                        __out.Append(__tmp24Prefix);
                        __out.Append(__tmp26Line);
                    }
                }
                string __tmp27Line = ").MLazyAdd(global::"; //774:24
                __out.Append(__tmp27Line);
                StringBuilder __tmp28 = new StringBuilder();
                __tmp28.Append(prop.DeclaringType.FullName.Replace("+", "."));
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
                string __tmp29Line = "."; //774:89
                __out.Append(__tmp29Line);
                StringBuilder __tmp30 = new StringBuilder();
                __tmp30.Append(prop.DeclaredName);
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
                string __tmp31Line = ", new Lazy<object>(() => "; //774:109
                __out.Append(__tmp31Line);
                StringBuilder __tmp32 = new StringBuilder();
                __tmp32.Append(value.ToString().ToLower());
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
                        __out.Append(__tmp25Suffix);
                        __out.AppendLine(); //774:165
                    }
                }
            }
            else if (value.GetType().IsPrimitive) //775:2
            {
                string __tmp33Prefix = "((ModelObject)"; //776:1
                string __tmp34Suffix = "));"; //776:152
                StringBuilder __tmp35 = new StringBuilder();
                __tmp35.Append(tmpName);
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
                string __tmp36Line = ").MLazyAdd(global::"; //776:24
                __out.Append(__tmp36Line);
                StringBuilder __tmp37 = new StringBuilder();
                __tmp37.Append(prop.DeclaringType.FullName.Replace("+", "."));
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
                string __tmp38Line = "."; //776:89
                __out.Append(__tmp38Line);
                StringBuilder __tmp39 = new StringBuilder();
                __tmp39.Append(prop.DeclaredName);
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
                string __tmp40Line = ", new Lazy<object>(() => "; //776:109
                __out.Append(__tmp40Line);
                StringBuilder __tmp41 = new StringBuilder();
                __tmp41.Append(value.ToString());
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
                        __out.Append(__tmp34Suffix);
                        __out.AppendLine(); //776:155
                    }
                }
            }
            else if (MetaBuiltInTypes.Types.Contains(value)) //777:2
            {
                string __tmp42Prefix = "((ModelObject)"; //778:1
                string __tmp43Suffix = "));"; //778:157
                StringBuilder __tmp44 = new StringBuilder();
                __tmp44.Append(tmpName);
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
                string __tmp45Line = ").MLazyAdd(global::"; //778:24
                __out.Append(__tmp45Line);
                StringBuilder __tmp46 = new StringBuilder();
                __tmp46.Append(prop.DeclaringType.FullName.Replace("+", "."));
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
                string __tmp47Line = "."; //778:89
                __out.Append(__tmp47Line);
                StringBuilder __tmp48 = new StringBuilder();
                __tmp48.Append(prop.DeclaredName);
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
                string __tmp49Line = ", new Lazy<object>(() => "; //778:109
                __out.Append(__tmp49Line);
                StringBuilder __tmp50 = new StringBuilder();
                __tmp50.Append(GenerateTypeOf(value));
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
                        __out.Append(__tmp43Suffix);
                        __out.AppendLine(); //778:160
                    }
                }
            }
            else if (value is MetaPrimitiveType) //779:2
            {
                string __tmp51Prefix = "((ModelObject)"; //780:1
                string __tmp52Suffix = "));"; //780:157
                StringBuilder __tmp53 = new StringBuilder();
                __tmp53.Append(tmpName);
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
                string __tmp54Line = ").MLazyAdd(global::"; //780:24
                __out.Append(__tmp54Line);
                StringBuilder __tmp55 = new StringBuilder();
                __tmp55.Append(prop.DeclaringType.FullName.Replace("+", "."));
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
                string __tmp56Line = "."; //780:89
                __out.Append(__tmp56Line);
                StringBuilder __tmp57 = new StringBuilder();
                __tmp57.Append(prop.DeclaredName);
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
                string __tmp58Line = ", new Lazy<object>(() => "; //780:109
                __out.Append(__tmp58Line);
                StringBuilder __tmp59 = new StringBuilder();
                __tmp59.Append(GenerateTypeOf(value));
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
                        __out.Append(__tmp52Suffix);
                        __out.AppendLine(); //780:160
                    }
                }
            }
            else if (value is Enum) //781:2
            {
                string __tmp60Prefix = "((ModelObject)"; //782:1
                string __tmp61Suffix = "));"; //782:157
                StringBuilder __tmp62 = new StringBuilder();
                __tmp62.Append(tmpName);
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
                string __tmp63Line = ").MLazyAdd(global::"; //782:24
                __out.Append(__tmp63Line);
                StringBuilder __tmp64 = new StringBuilder();
                __tmp64.Append(prop.DeclaringType.FullName.Replace("+", "."));
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
                string __tmp65Line = "."; //782:89
                __out.Append(__tmp65Line);
                StringBuilder __tmp66 = new StringBuilder();
                __tmp66.Append(prop.DeclaredName);
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
                string __tmp67Line = ", new Lazy<object>(() => "; //782:109
                __out.Append(__tmp67Line);
                StringBuilder __tmp68 = new StringBuilder();
                __tmp68.Append(GetEnumValueOf(value));
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
                        __out.Append(__tmp61Suffix);
                        __out.AppendLine(); //782:160
                    }
                }
            }
            else if (moValue != null) //783:2
            {
                if (mobjToTmp.ContainsKey(moValue)) //784:3
                {
                    string __tmp69Prefix = "((ModelObject)"; //785:1
                    string __tmp70Suffix = "));"; //785:154
                    StringBuilder __tmp71 = new StringBuilder();
                    __tmp71.Append(tmpName);
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
                            __out.Append(__tmp69Prefix);
                            __out.Append(__tmp71Line);
                        }
                    }
                    string __tmp72Line = ").MLazyAdd(global::"; //785:24
                    __out.Append(__tmp72Line);
                    StringBuilder __tmp73 = new StringBuilder();
                    __tmp73.Append(prop.DeclaringType.FullName.Replace("+", "."));
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
                    string __tmp74Line = "."; //785:89
                    __out.Append(__tmp74Line);
                    StringBuilder __tmp75 = new StringBuilder();
                    __tmp75.Append(prop.DeclaredName);
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
                        }
                    }
                    string __tmp76Line = ", new Lazy<object>(() => "; //785:109
                    __out.Append(__tmp76Line);
                    StringBuilder __tmp77 = new StringBuilder();
                    __tmp77.Append(mobjToTmp[moValue]);
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
                            __out.Append(__tmp70Suffix);
                            __out.AppendLine(); //785:157
                        }
                    }
                }
                else //786:3
                {
                    string __tmp78Prefix = string.Empty;
                    string __tmp79Suffix = string.Empty;
                    StringBuilder __tmp80 = new StringBuilder();
                    __tmp80.Append(GenerateModelObjectInstance(moValue, mobjToTmp));
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
                            __out.Append(__tmp79Suffix);
                            __out.AppendLine(); //787:50
                        }
                    }
                    string __tmp81Prefix = string.Empty;
                    string __tmp82Suffix = string.Empty;
                    StringBuilder __tmp83 = new StringBuilder();
                    __tmp83.Append(GenerateModelObjectInstanceInitializer(moValue, mobjToTmp));
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
                            __out.Append(__tmp82Suffix);
                            __out.AppendLine(); //788:61
                        }
                    }
                    string tmpValueName = mobjToTmp[moValue]; //789:2
                    string __tmp84Prefix = "((ModelObject)"; //790:1
                    string __tmp85Suffix = "));"; //790:148
                    StringBuilder __tmp86 = new StringBuilder();
                    __tmp86.Append(tmpName);
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
                    string __tmp87Line = ").MLazyAdd(global::"; //790:24
                    __out.Append(__tmp87Line);
                    StringBuilder __tmp88 = new StringBuilder();
                    __tmp88.Append(prop.DeclaringType.FullName.Replace("+", "."));
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
                    string __tmp89Line = "."; //790:89
                    __out.Append(__tmp89Line);
                    StringBuilder __tmp90 = new StringBuilder();
                    __tmp90.Append(prop.DeclaredName);
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
                    string __tmp91Line = ", new Lazy<object>(() => "; //790:109
                    __out.Append(__tmp91Line);
                    StringBuilder __tmp92 = new StringBuilder();
                    __tmp92.Append(tmpValueName);
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
                            __out.AppendLine(); //790:151
                        }
                    }
                }
            }
            else //792:2
            {
                IEnumerable<object> mc = (value as ModelCollection) as IEnumerable<object>; //793:3
                if (mc != null) //794:3
                {
                    var __loop49_results = 
                        (from cvalue in __Enumerate((mc).GetEnumerator()) //795:9
                        select new { cvalue = cvalue}
                        ).ToList(); //795:4
                    int __loop49_iteration = 0;
                    foreach (var __tmp93 in __loop49_results)
                    {
                        ++__loop49_iteration;
                        var cvalue = __tmp93.cvalue;
                        string __tmp94Prefix = string.Empty;
                        string __tmp95Suffix = string.Empty;
                        StringBuilder __tmp96 = new StringBuilder();
                        __tmp96.Append(GenerateModelObjectPropertyValue(mobj, prop, cvalue, mobjToTmp));
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
                                __out.Append(__tmp95Suffix);
                                __out.AppendLine(); //796:66
                            }
                        }
                    }
                }
                else //798:3
                {
                    string __tmp97Prefix = "// "; //799:1
                    string __tmp98Suffix = string.Empty; 
                    StringBuilder __tmp99 = new StringBuilder();
                    __tmp99.Append(prop.DeclaringType.FullName);
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
                            __out.Append(__tmp97Prefix);
                            __out.Append(__tmp99Line);
                        }
                    }
                    string __tmp100Line = "."; //799:33
                    __out.Append(__tmp100Line);
                    StringBuilder __tmp101 = new StringBuilder();
                    __tmp101.Append(prop.DeclaredName);
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
                    string __tmp102Line = " = "; //799:53
                    __out.Append(__tmp102Line);
                    StringBuilder __tmp103 = new StringBuilder();
                    __tmp103.Append(value.GetType());
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
                            __out.Append(__tmp98Suffix);
                            __out.AppendLine(); //799:73
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GetEnumValueOf(object enm) //804:1
        {
            return "global::" + enm.GetType().FullName.Replace("+", ".") + "." + enm.ToString(); //805:2
        }

        public string GenerateClassMetaInstance(MetaClass cls) //808:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = " = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();"; //809:19
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
                    __out.AppendLine(); //809:83
                }
            }
            return __out.ToString();
        }

        public string GenerateClassMetaInstanceInitializer(MetaClass cls) //812:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = "\";"; //813:46
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
            string __tmp4Line = ".Name = \""; //813:19
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
                    __out.AppendLine(); //813:48
                }
            }
            if (cls.IsAbstract) //814:2
            {
                string __tmp6Prefix = string.Empty; 
                string __tmp7Suffix = ".IsAbstract = true;"; //815:19
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
                        __out.AppendLine(); //815:38
                    }
                }
            }
            var __loop50_results = 
                (from __loop50_var1 in __Enumerate((cls).GetEnumerator()) //817:7
                from sup in __Enumerate((__loop50_var1.SuperClasses).GetEnumerator()) //817:12
                select new { __loop50_var1 = __loop50_var1, sup = sup}
                ).ToList(); //817:2
            int __loop50_iteration = 0;
            foreach (var __tmp9 in __loop50_results)
            {
                ++__loop50_iteration;
                var __loop50_var1 = __tmp9.__loop50_var1;
                var sup = __tmp9.sup;
                string __tmp10Prefix = string.Empty; 
                string __tmp11Suffix = ");"; //818:80
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
                string __tmp13Line = ".SuperClasses.Add("; //818:19
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
                string __tmp15Line = "Instance."; //818:53
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
                        __out.AppendLine(); //818:82
                    }
                }
            }
            return __out.ToString();
        }

        public string GeneratePropertyMetaInstance(MetaProperty prop) //822:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = "Property = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();"; //823:38
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(prop.Class.CSharpName());
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
            string __tmp4Line = "_"; //823:26
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
                    __out.AppendLine(); //823:113
                }
            }
            return __out.ToString();
        }

        public string GeneratePropertyMetaInstanceInitializer(MetaProperty prop) //826:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = "\";"; //827:66
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(prop.Class.CSharpName());
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
            string __tmp4Line = "_"; //827:26
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
                }
            }
            string __tmp6Line = "Property.Name = \""; //827:38
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
                    __out.AppendLine(); //827:68
                }
            }
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //830:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "internal static class "; //831:1
            string __tmp2Suffix = "ImplementationProvider"; //831:35
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
                    __out.AppendLine(); //831:57
                }
            }
            __out.Append("{"); //832:1
            __out.AppendLine(); //832:2
            string __tmp4Prefix = "    // If there is a compile error at this line, create a new class called "; //833:1
            string __tmp5Suffix = "Implementation"; //833:88
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
                    __out.AppendLine(); //833:102
                }
            }
            string __tmp7Prefix = "	// which is a subclass of "; //834:1
            string __tmp8Suffix = "ImplementationBase:"; //834:40
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
                    __out.AppendLine(); //834:59
                }
            }
            string __tmp10Prefix = "    private static "; //835:1
            string __tmp11Suffix = "Implementation();"; //835:80
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
            string __tmp13Line = "Implementation implementation = new "; //835:32
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
                    __out.AppendLine(); //835:97
                }
            }
            __out.AppendLine(); //836:2
            string __tmp15Prefix = "    public static "; //837:1
            string __tmp16Suffix = "Implementation Implementation"; //837:31
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
                    __out.AppendLine(); //837:60
                }
            }
            __out.Append("    {"); //838:1
            __out.AppendLine(); //838:6
            string __tmp18Prefix = "        get { return "; //839:1
            string __tmp19Suffix = "ImplementationProvider.implementation; }"; //839:34
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
                    __out.AppendLine(); //839:74
                }
            }
            __out.Append("    }"); //840:1
            __out.AppendLine(); //840:6
            __out.Append("}"); //841:1
            __out.AppendLine(); //841:2
            var __loop51_results = 
                (from __loop51_var1 in __Enumerate((model).GetEnumerator()) //842:8
                from Namespace in __Enumerate((__loop51_var1.Namespace).GetEnumerator()) //842:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //842:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //842:40
                select new { __loop51_var1 = __loop51_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //842:3
            int __loop51_iteration = 0;
            foreach (var __tmp21 in __loop51_results)
            {
                ++__loop51_iteration;
                var __loop51_var1 = __tmp21.__loop51_var1;
                var Namespace = __tmp21.Namespace;
                var Declarations = __tmp21.Declarations;
                var enm = __tmp21.enm;
                __out.AppendLine(); //843:2
                string __tmp22Prefix = "public static class "; //844:1
                string __tmp23Suffix = "Extensions"; //844:31
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
                        __out.AppendLine(); //844:41
                    }
                }
                __out.Append("{"); //845:1
                __out.AppendLine(); //845:2
                var __loop52_results = 
                    (from __loop52_var1 in __Enumerate((enm).GetEnumerator()) //846:11
                    from op in __Enumerate((__loop52_var1.Operations).GetEnumerator()) //846:16
                    select new { __loop52_var1 = __loop52_var1, op = op}
                    ).ToList(); //846:6
                int __loop52_iteration = 0;
                foreach (var __tmp25 in __loop52_results)
                {
                    ++__loop52_iteration;
                    var __loop52_var1 = __tmp25.__loop52_var1;
                    var op = __tmp25.op;
                    string __tmp26Prefix = "    public static "; //847:1
                    string __tmp27Suffix = ")"; //847:96
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
                    string __tmp29Line = " "; //847:53
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
                    string __tmp31Line = "("; //847:63
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
                            __out.AppendLine(); //847:97
                        }
                    }
                    __out.Append("    {"); //848:1
                    __out.AppendLine(); //848:6
                    string __tmp33Prefix = "        "; //849:1
                    string __tmp34Suffix = ");"; //849:144
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
                    string __tmp37Line = "ImplementationProvider.Implementation."; //849:36
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
                    string __tmp39Line = "_"; //849:98
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
                    string __tmp41Line = "("; //849:108
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
                            __out.AppendLine(); //849:146
                        }
                    }
                    __out.Append("    }"); //850:1
                    __out.AppendLine(); //850:6
                }
                __out.Append("}"); //852:1
                __out.AppendLine(); //852:2
            }
            __out.AppendLine(); //854:2
            __out.Append("/// <summary>"); //855:1
            __out.AppendLine(); //855:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //856:1
            __out.AppendLine(); //856:68
            string __tmp43Prefix = "/// This class has to be be overriden in "; //857:1
            string __tmp44Suffix = "Implementation to provide custom"; //857:54
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
                    __out.AppendLine(); //857:86
                }
            }
            __out.Append("/// implementation for the constructors, operations and property values."); //858:1
            __out.AppendLine(); //858:73
            __out.Append("/// </summary>"); //859:1
            __out.AppendLine(); //859:15
            string __tmp46Prefix = "internal abstract class "; //860:1
            string __tmp47Suffix = "ImplementationBase"; //860:37
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
                    __out.AppendLine(); //860:55
                }
            }
            __out.Append("{"); //861:1
            __out.AppendLine(); //861:2
            var __loop53_results = 
                (from __loop53_var1 in __Enumerate((model).GetEnumerator()) //862:8
                from Namespace in __Enumerate((__loop53_var1.Namespace).GetEnumerator()) //862:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //862:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //862:40
                select new { __loop53_var1 = __loop53_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //862:3
            int __loop53_iteration = 0;
            foreach (var __tmp49 in __loop53_results)
            {
                ++__loop53_iteration;
                var __loop53_var1 = __tmp49.__loop53_var1;
                var Namespace = __tmp49.Namespace;
                var Declarations = __tmp49.Declarations;
                var cls = __tmp49.cls;
                __out.Append("    /// <summary>"); //863:1
                __out.AppendLine(); //863:18
                string __tmp50Prefix = "	/// Implements the constructor: "; //864:1
                string __tmp51Suffix = "()"; //864:52
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
                        __out.AppendLine(); //864:54
                    }
                }
                if ((from __loop54_var1 in __Enumerate((cls).GetEnumerator()) //865:15
                from sup in __Enumerate((__loop54_var1.SuperClasses).GetEnumerator()) //865:20
                select new { __loop54_var1 = __loop54_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //865:3
                {
                    string __tmp53Prefix = "	/// Direct superclasses: "; //866:1
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
                            __out.AppendLine(); //866:49
                        }
                    }
                    string __tmp56Prefix = "	/// All superclasses: "; //867:1
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
                            __out.AppendLine(); //867:49
                        }
                    }
                }
                if ((from __loop55_var1 in __Enumerate((cls).GetEnumerator()) //869:15
                from prop in __Enumerate((__loop55_var1.GetAllProperties()).GetEnumerator()) //869:20
                where prop.Kind == MetaPropertyKind.Readonly //869:44
                select new { __loop55_var1 = __loop55_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //869:3
                {
                    __out.Append("    /// Initializes the following readonly properties:"); //870:1
                    __out.AppendLine(); //870:55
                }
                var __loop56_results = 
                    (from __loop56_var1 in __Enumerate((cls).GetEnumerator()) //872:11
                    from prop in __Enumerate((__loop56_var1.GetAllProperties()).GetEnumerator()) //872:16
                    select new { __loop56_var1 = __loop56_var1, prop = prop}
                    ).ToList(); //872:6
                int __loop56_iteration = 0;
                foreach (var __tmp59 in __loop56_results)
                {
                    ++__loop56_iteration;
                    var __loop56_var1 = __tmp59.__loop56_var1;
                    var prop = __tmp59.prop;
                    if (prop.Kind == MetaPropertyKind.Readonly) //873:3
                    {
                        string __tmp60Prefix = "    ///    "; //874:1
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
                        string __tmp63Line = "."; //874:29
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
                                __out.AppendLine(); //874:41
                            }
                        }
                    }
                }
                __out.Append("    /// </summary>"); //877:1
                __out.AppendLine(); //877:19
                string __tmp65Prefix = "    public virtual void "; //878:1
                string __tmp66Suffix = " @this)"; //878:81
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
                string __tmp68Line = "_"; //878:43
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
                string __tmp70Line = "("; //878:62
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
                        __out.AppendLine(); //878:88
                    }
                }
                __out.Append("    {"); //879:1
                __out.AppendLine(); //879:6
                var __loop57_results = 
                    (from __loop57_var1 in __Enumerate((cls).GetEnumerator()) //880:9
                    from sup in __Enumerate((__loop57_var1.SuperClasses).GetEnumerator()) //880:14
                    select new { __loop57_var1 = __loop57_var1, sup = sup}
                    ).ToList(); //880:4
                int __loop57_iteration = 0;
                foreach (var __tmp72 in __loop57_results)
                {
                    ++__loop57_iteration;
                    var __loop57_var1 = __tmp72.__loop57_var1;
                    var sup = __tmp72.sup;
                    string __tmp73Prefix = "        this."; //881:1
                    string __tmp74Suffix = "(@this);"; //881:51
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
                    string __tmp76Line = "_"; //881:32
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
                            __out.AppendLine(); //881:59
                        }
                    }
                }
                __out.Append("    }"); //883:1
                __out.AppendLine(); //883:6
                var __loop58_results = 
                    (from __loop58_var1 in __Enumerate((cls).GetEnumerator()) //884:11
                    from prop in __Enumerate((__loop58_var1.Properties).GetEnumerator()) //884:16
                    select new { __loop58_var1 = __loop58_var1, prop = prop}
                    ).ToList(); //884:6
                int __loop58_iteration = 0;
                foreach (var __tmp78 in __loop58_results)
                {
                    ++__loop58_iteration;
                    var __loop58_var1 = __tmp78.__loop58_var1;
                    var prop = __tmp78.prop;
                    MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //885:4
                    if (synInit == null) //886:4
                    {
                        if (prop.Kind == MetaPropertyKind.Derived) //887:5
                        {
                            __out.AppendLine(); //888:2
                            __out.Append("    /// <summary>"); //889:1
                            __out.AppendLine(); //889:18
                            string __tmp79Prefix = "    /// Returns the value of the derived property: "; //890:1
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
                            string __tmp82Line = "."; //890:70
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
                                    __out.AppendLine(); //890:82
                                }
                            }
                            __out.Append("    /// </summary>"); //891:1
                            __out.AppendLine(); //891:19
                            string __tmp84Prefix = "    public virtual "; //892:1
                            string __tmp85Suffix = " @this)"; //892:100
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
                            string __tmp87Line = " "; //892:50
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
                            string __tmp89Line = "_"; //892:69
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
                            string __tmp91Line = "("; //892:81
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
                                    __out.AppendLine(); //892:107
                                }
                            }
                            __out.Append("    {"); //893:1
                            __out.AppendLine(); //893:6
                            __out.Append("        throw new NotImplementedException();"); //894:1
                            __out.AppendLine(); //894:45
                            __out.Append("    }"); //895:1
                            __out.AppendLine(); //895:6
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //896:5
                        {
                            __out.AppendLine(); //897:2
                            __out.Append("    /// <summary>"); //898:1
                            __out.AppendLine(); //898:18
                            string __tmp93Prefix = "    /// Returns the value of the lazy property: "; //899:1
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
                            string __tmp96Line = "."; //899:67
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
                                    __out.AppendLine(); //899:79
                                }
                            }
                            __out.Append("    /// </summary>"); //900:1
                            __out.AppendLine(); //900:19
                            string __tmp98Prefix = "    public virtual "; //901:1
                            string __tmp99Suffix = " @this)"; //901:100
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
                            string __tmp101Line = " "; //901:50
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
                            string __tmp103Line = "_"; //901:69
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
                            string __tmp105Line = "("; //901:81
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
                                    __out.AppendLine(); //901:107
                                }
                            }
                            __out.Append("    {"); //902:1
                            __out.AppendLine(); //902:6
                            __out.Append("        throw new NotImplementedException();"); //903:1
                            __out.AppendLine(); //903:45
                            __out.Append("    }"); //904:1
                            __out.AppendLine(); //904:6
                        }
                    }
                }
                var __loop59_results = 
                    (from __loop59_var1 in __Enumerate((cls).GetEnumerator()) //908:11
                    from op in __Enumerate((__loop59_var1.Operations).GetEnumerator()) //908:16
                    select new { __loop59_var1 = __loop59_var1, op = op}
                    ).ToList(); //908:6
                int __loop59_iteration = 0;
                foreach (var __tmp107 in __loop59_results)
                {
                    ++__loop59_iteration;
                    var __loop59_var1 = __tmp107.__loop59_var1;
                    var op = __tmp107.op;
                    __out.AppendLine(); //909:2
                    __out.Append("    /// <summary>"); //910:1
                    __out.AppendLine(); //910:18
                    string __tmp108Prefix = "    /// Implements the operation: "; //911:1
                    string __tmp109Suffix = "()"; //911:63
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
                    string __tmp111Line = "."; //911:53
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
                            __out.AppendLine(); //911:65
                        }
                    }
                    __out.Append("    /// </summary>"); //912:1
                    __out.AppendLine(); //912:19
                    string __tmp113Prefix = "    public virtual "; //913:1
                    string __tmp114Suffix = ")"; //913:112
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
                    string __tmp116Line = " "; //913:54
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
                    string __tmp118Line = "_"; //913:73
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
                    string __tmp120Line = "("; //913:83
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
                            __out.AppendLine(); //913:113
                        }
                    }
                    __out.Append("    {"); //914:1
                    __out.AppendLine(); //914:6
                    __out.Append("        throw new NotImplementedException();"); //915:1
                    __out.AppendLine(); //915:45
                    __out.Append("    }"); //916:1
                    __out.AppendLine(); //916:6
                }
                __out.AppendLine(); //918:2
            }
            var __loop60_results = 
                (from __loop60_var1 in __Enumerate((model).GetEnumerator()) //920:8
                from Namespace in __Enumerate((__loop60_var1.Namespace).GetEnumerator()) //920:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //920:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //920:40
                select new { __loop60_var1 = __loop60_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //920:3
            int __loop60_iteration = 0;
            foreach (var __tmp122 in __loop60_results)
            {
                ++__loop60_iteration;
                var __loop60_var1 = __tmp122.__loop60_var1;
                var Namespace = __tmp122.Namespace;
                var Declarations = __tmp122.Declarations;
                var enm = __tmp122.enm;
                var __loop61_results = 
                    (from __loop61_var1 in __Enumerate((enm).GetEnumerator()) //921:11
                    from op in __Enumerate((__loop61_var1.Operations).GetEnumerator()) //921:16
                    select new { __loop61_var1 = __loop61_var1, op = op}
                    ).ToList(); //921:6
                int __loop61_iteration = 0;
                foreach (var __tmp123 in __loop61_results)
                {
                    ++__loop61_iteration;
                    var __loop61_var1 = __tmp123.__loop61_var1;
                    var op = __tmp123.op;
                    __out.AppendLine(); //922:2
                    __out.Append("    /// <summary>"); //923:1
                    __out.AppendLine(); //923:18
                    string __tmp124Prefix = "    /// Implements the operation: "; //924:1
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
                    string __tmp127Line = "."; //924:53
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
                            __out.AppendLine(); //924:63
                        }
                    }
                    __out.Append("    /// </summary>"); //925:1
                    __out.AppendLine(); //925:19
                    string __tmp129Prefix = "    public virtual "; //926:1
                    string __tmp130Suffix = ")"; //926:112
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
                    string __tmp132Line = " "; //926:54
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
                    string __tmp134Line = "_"; //926:73
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
                    string __tmp136Line = "("; //926:83
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
                            __out.AppendLine(); //926:113
                        }
                    }
                    __out.Append("    {"); //927:1
                    __out.AppendLine(); //927:6
                    __out.Append("        throw new NotImplementedException();"); //928:1
                    __out.AppendLine(); //928:45
                    __out.Append("    }"); //929:1
                    __out.AppendLine(); //929:6
                }
                __out.AppendLine(); //931:2
            }
            __out.Append("}"); //933:1
            __out.AppendLine(); //933:2
            __out.AppendLine(); //934:2
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //937:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //938:1
            __out.AppendLine(); //938:14
            __out.Append("/// Factory class for creating instances of model elements."); //939:1
            __out.AppendLine(); //939:60
            __out.Append("/// </summary>"); //940:1
            __out.AppendLine(); //940:15
            string __tmp1Prefix = "public class "; //941:1
            string __tmp2Suffix = "Factory : ModelFactory"; //941:26
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
                    __out.AppendLine(); //941:48
                }
            }
            __out.Append("{"); //942:1
            __out.AppendLine(); //942:2
            string __tmp4Prefix = "    private static "; //943:1
            string __tmp5Suffix = "Factory();"; //943:67
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
            string __tmp7Line = "Factory instance = new "; //943:32
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
                    __out.AppendLine(); //943:77
                }
            }
            __out.AppendLine(); //944:2
            string __tmp9Prefix = "	private "; //945:1
            string __tmp10Suffix = "Factory()"; //945:22
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
                    __out.AppendLine(); //945:31
                }
            }
            __out.Append("	{"); //946:1
            __out.AppendLine(); //946:3
            __out.Append("	}"); //947:1
            __out.AppendLine(); //947:3
            __out.AppendLine(); //948:2
            __out.Append("    /// <summary>"); //949:1
            __out.AppendLine(); //949:18
            __out.Append("    /// The singleton instance of the factory."); //950:1
            __out.AppendLine(); //950:47
            __out.Append("    /// </summary>"); //951:1
            __out.AppendLine(); //951:19
            string __tmp12Prefix = "    public static "; //952:1
            string __tmp13Suffix = "Factory Instance"; //952:31
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
                    __out.AppendLine(); //952:47
                }
            }
            __out.Append("    {"); //953:1
            __out.AppendLine(); //953:6
            string __tmp15Prefix = "        get { return "; //954:1
            string __tmp16Suffix = "Factory.instance; }"; //954:34
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
                    __out.AppendLine(); //954:53
                }
            }
            __out.Append("    }"); //955:1
            __out.AppendLine(); //955:6
            var __loop62_results = 
                (from __loop62_var1 in __Enumerate((model).GetEnumerator()) //956:8
                from Namespace in __Enumerate((__loop62_var1.Namespace).GetEnumerator()) //956:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //956:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //956:40
                select new { __loop62_var1 = __loop62_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //956:3
            int __loop62_iteration = 0;
            foreach (var __tmp18 in __loop62_results)
            {
                ++__loop62_iteration;
                var __loop62_var1 = __tmp18.__loop62_var1;
                var Namespace = __tmp18.Namespace;
                var Declarations = __tmp18.Declarations;
                var cls = __tmp18.cls;
                if (!cls.IsAbstract) //957:4
                {
                    __out.AppendLine(); //958:2
                    __out.Append("    /// <summary>"); //959:1
                    __out.AppendLine(); //959:18
                    string __tmp19Prefix = "    /// Creates a new instance of "; //960:1
                    string __tmp20Suffix = "."; //960:53
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
                            __out.AppendLine(); //960:54
                        }
                    }
                    __out.Append("    /// </summary>"); //961:1
                    __out.AppendLine(); //961:19
                    string __tmp22Prefix = "    public "; //962:1
                    string __tmp23Suffix = "(IEnumerable<ModelPropertyInitializer> initializers = null)"; //962:55
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
                    string __tmp25Line = " Create"; //962:30
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
                            __out.AppendLine(); //962:114
                        }
                    }
                    __out.Append("	{"); //963:1
                    __out.AppendLine(); //963:3
                    string __tmp27Prefix = "		"; //964:1
                    string __tmp28Suffix = "Impl();"; //964:57
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
                    string __tmp30Line = " result = new "; //964:21
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
                            __out.AppendLine(); //964:64
                        }
                    }
                    __out.Append("		if (initializers != null)"); //965:1
                    __out.AppendLine(); //965:28
                    __out.Append("		{"); //966:1
                    __out.AppendLine(); //966:4
                    __out.Append("			this.Init((ModelObject)result, initializers);"); //967:1
                    __out.AppendLine(); //967:49
                    __out.Append("		}"); //968:1
                    __out.AppendLine(); //968:4
                    __out.Append("		return result;"); //969:1
                    __out.AppendLine(); //969:17
                    __out.Append("	}"); //970:1
                    __out.AppendLine(); //970:3
                }
            }
            __out.Append("}"); //973:1
            __out.AppendLine(); //973:2
            __out.AppendLine(); //974:2
            return __out.ToString();
        }

    }
}

