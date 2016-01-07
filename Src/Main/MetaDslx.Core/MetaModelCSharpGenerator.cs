using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core //1:1
{
    using __Hidden_MetaModelCSharpGenerator_122625229;
    namespace __Hidden_MetaModelCSharpGenerator_122625229
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

    public class MetaModelCSharpGenerator //2:1
    {
        private IEnumerable<ModelObject> Instances; //2:1

        public MetaModelCSharpGenerator() //2:1
        {
        }

        public MetaModelCSharpGenerator(IEnumerable<ModelObject> instances) : this() //2:1
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
            __out.Append("using System.Threading;"); //10:1
            __out.AppendLine(); //10:24
            __out.Append("using System.Threading.Tasks;"); //11:1
            __out.AppendLine(); //11:30
            __out.Append("using MetaDslx.Core;"); //12:1
            __out.AppendLine(); //12:21
            __out.AppendLine(); //13:1
            var __loop1_results = 
                (from __loop1_var1 in __Enumerate((Instances).GetEnumerator()) //14:8
                from mm in __Enumerate((__loop1_var1).GetEnumerator()).OfType<MetaModel>() //14:19
                select new { __loop1_var1 = __loop1_var1, mm = mm}
                ).ToList(); //14:3
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
                        __out.AppendLine(); //15:24
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateMetamodel(MetaModel model) //19:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "namespace "; //20:1
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
                    __out.AppendLine(); //20:41
                }
            }
            __out.Append("{"); //21:1
            __out.AppendLine(); //21:2
            string __tmp4Prefix = "    "; //22:1
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
                    __out.AppendLine(); //22:41
                }
            }
            string __tmp7Prefix = "	"; //23:1
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
                    __out.AppendLine(); //23:36
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
            foreach (var __tmp10 in __loop2_results)
            {
                ++__loop2_iteration;
                var __loop2_var1 = __tmp10.__loop2_var1;
                var Namespace = __tmp10.Namespace;
                var Declarations = __tmp10.Declarations;
                var enm = __tmp10.enm;
                string __tmp11Prefix = "    "; //25:1
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
                        __out.AppendLine(); //25:24
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
            foreach (var __tmp14 in __loop3_results)
            {
                ++__loop3_iteration;
                var __loop3_var1 = __tmp14.__loop3_var1;
                var Namespace = __tmp14.Namespace;
                var Declarations = __tmp14.Declarations;
                var cls = __tmp14.cls;
                string __tmp15Prefix = "    "; //28:1
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
                        __out.AppendLine(); //28:29
                    }
                }
                string __tmp18Prefix = "    "; //29:1
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
                        __out.AppendLine(); //29:40
                    }
                }
            }
            string __tmp21Prefix = "    "; //31:1
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
                    __out.AppendLine(); //31:29
                }
            }
            string __tmp24Prefix = "    "; //32:1
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
                    __out.AppendLine(); //32:44
                }
            }
            __out.Append("}"); //33:1
            __out.AppendLine(); //33:2
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
                        __out.AppendLine(); //38:23
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateEnum(MetaEnum enm) //42:1
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
                    __out.AppendLine(); //43:27
                }
            }
            string __tmp4Prefix = "public enum "; //44:1
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
                    __out.AppendLine(); //44:31
                }
            }
            __out.Append("{"); //45:1
            __out.AppendLine(); //45:2
            var __loop5_results = 
                (from __loop5_var1 in __Enumerate((enm).GetEnumerator()) //46:11
                from value in __Enumerate((__loop5_var1.EnumLiterals).GetEnumerator()) //46:16
                select new { __loop5_var1 = __loop5_var1, value = value}
                ).ToList(); //46:6
            int __loop5_iteration = 0;
            foreach (var __tmp7 in __loop5_results)
            {
                ++__loop5_iteration;
                var __loop5_var1 = __tmp7.__loop5_var1;
                var value = __tmp7.value;
                string __tmp8Prefix = "    "; //47:1
                string __tmp9Suffix = ","; //47:17
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
                        __out.AppendLine(); //47:18
                    }
                }
            }
            __out.Append("}"); //49:1
            __out.AppendLine(); //49:2
            __out.AppendLine(); //50:1
            return __out.ToString();
        }

        public string GetAncestors(MetaClass cls) //53:1
        {
            string result = ""; //54:2
            var __loop6_results = 
                (from __loop6_var1 in __Enumerate((cls).GetEnumerator()) //55:7
                from super in __Enumerate((__loop6_var1.SuperClasses).GetEnumerator()) //55:12
                select new { __loop6_var1 = __loop6_var1, super = super}
                ).ToList(); //55:2
            int __loop6_iteration = 0;
            string delim = " : "; //55:32
            foreach (var __tmp1 in __loop6_results)
            {
                ++__loop6_iteration;
                if (__loop6_iteration >= 2) //55:54
                {
                    delim = ", "; //55:54
                }
                var __loop6_var1 = __tmp1.__loop6_var1;
                var super = __tmp1.super;
                result += delim + super.CSharpFullName(); //56:3
            }
            return result; //58:2
        }

        public string GenerateInterface(MetaClass cls) //61:1
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
                    __out.AppendLine(); //62:27
                }
            }
            string __tmp4Prefix = "public interface "; //63:1
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
                    __out.AppendLine(); //63:55
                }
            }
            __out.Append("{"); //64:1
            __out.AppendLine(); //64:2
            var __loop7_results = 
                (from __loop7_var1 in __Enumerate((cls).GetEnumerator()) //65:11
                from prop in __Enumerate((__loop7_var1.Properties).GetEnumerator()) //65:16
                select new { __loop7_var1 = __loop7_var1, prop = prop}
                ).ToList(); //65:6
            int __loop7_iteration = 0;
            foreach (var __tmp8 in __loop7_results)
            {
                ++__loop7_iteration;
                var __loop7_var1 = __tmp8.__loop7_var1;
                var prop = __tmp8.prop;
                string __tmp9Prefix = "    "; //66:1
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
                        __out.AppendLine(); //66:29
                    }
                }
            }
            __out.AppendLine(); //68:1
            var __loop8_results = 
                (from __loop8_var1 in __Enumerate((cls).GetEnumerator()) //69:11
                from op in __Enumerate((__loop8_var1.Operations).GetEnumerator()) //69:16
                select new { __loop8_var1 = __loop8_var1, op = op}
                ).ToList(); //69:6
            int __loop8_iteration = 0;
            foreach (var __tmp12 in __loop8_results)
            {
                ++__loop8_iteration;
                var __loop8_var1 = __tmp12.__loop8_var1;
                var op = __tmp12.op;
                string __tmp13Prefix = "    "; //70:1
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
            if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //77:2
            {
                __out.Append("new "); //78:1
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //80:3
            {
                string __tmp1Prefix = string.Empty; 
                string __tmp2Suffix = " { get; set; }"; //81:47
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(prop.Type.CSharpFullPublicName());
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
                string __tmp4Line = " "; //81:35
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
                        __out.AppendLine(); //81:61
                    }
                }
            }
            else //82:3
            {
                string __tmp6Prefix = string.Empty; 
                string __tmp7Suffix = " { get; }"; //83:47
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(prop.Type.CSharpFullPublicName());
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
                string __tmp9Line = " "; //83:35
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
                        __out.AppendLine(); //83:56
                    }
                }
            }
            return __out.ToString();
        }

        public string GetParameters(MetaOperation op, bool defaultValues) //87:1
        {
            string result = ""; //88:2
            var __loop9_results = 
                (from __loop9_var1 in __Enumerate((op).GetEnumerator()) //89:7
                from param in __Enumerate((__loop9_var1.Parameters).GetEnumerator()) //89:11
                select new { __loop9_var1 = __loop9_var1, param = param}
                ).ToList(); //89:2
            int __loop9_iteration = 0;
            string delim = ""; //89:29
            foreach (var __tmp1 in __loop9_results)
            {
                ++__loop9_iteration;
                if (__loop9_iteration >= 2) //89:48
                {
                    delim = ", "; //89:48
                }
                var __loop9_var1 = __tmp1.__loop9_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName() + " " + param.Name; //90:3
            }
            return result; //95:2
        }

        public string GetImplParameters(MetaClass cls, MetaOperation op) //98:1
        {
            string result = cls.CSharpFullName() + " @this"; //99:2
            string delim = ", "; //100:2
            var __loop10_results = 
                (from __loop10_var1 in __Enumerate((op).GetEnumerator()) //101:7
                from param in __Enumerate((__loop10_var1.Parameters).GetEnumerator()) //101:11
                select new { __loop10_var1 = __loop10_var1, param = param}
                ).ToList(); //101:2
            int __loop10_iteration = 0;
            foreach (var __tmp1 in __loop10_results)
            {
                ++__loop10_iteration;
                var __loop10_var1 = __tmp1.__loop10_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName() + " " + param.Name; //102:3
            }
            return result; //104:2
        }

        public string GetImplParameters(MetaEnum enm, MetaOperation op) //107:1
        {
            string result = enm.CSharpFullName() + " @this"; //108:2
            string delim = ", "; //109:2
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((op).GetEnumerator()) //110:7
                from param in __Enumerate((__loop11_var1.Parameters).GetEnumerator()) //110:11
                select new { __loop11_var1 = __loop11_var1, param = param}
                ).ToList(); //110:2
            int __loop11_iteration = 0;
            foreach (var __tmp1 in __loop11_results)
            {
                ++__loop11_iteration;
                var __loop11_var1 = __tmp1.__loop11_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName() + " " + param.Name; //111:3
            }
            return result; //113:2
        }

        public string GetEnumImplParameters(MetaEnum enm, MetaOperation op) //116:1
        {
            string result = "this " + enm.CSharpFullName() + " @this"; //117:2
            string delim = ", "; //118:2
            var __loop12_results = 
                (from __loop12_var1 in __Enumerate((op).GetEnumerator()) //119:7
                from param in __Enumerate((__loop12_var1.Parameters).GetEnumerator()) //119:11
                select new { __loop12_var1 = __loop12_var1, param = param}
                ).ToList(); //119:2
            int __loop12_iteration = 0;
            foreach (var __tmp1 in __loop12_results)
            {
                ++__loop12_iteration;
                var __loop12_var1 = __tmp1.__loop12_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName() + " " + param.Name; //120:3
            }
            return result; //122:2
        }

        public string GetEnumImplCallParameterNames(MetaOperation op) //125:1
        {
            string result = "@this"; //126:2
            string delim = ", "; //127:2
            var __loop13_results = 
                (from __loop13_var1 in __Enumerate((op).GetEnumerator()) //128:7
                from param in __Enumerate((__loop13_var1.Parameters).GetEnumerator()) //128:11
                select new { __loop13_var1 = __loop13_var1, param = param}
                ).ToList(); //128:2
            int __loop13_iteration = 0;
            foreach (var __tmp1 in __loop13_results)
            {
                ++__loop13_iteration;
                var __loop13_var1 = __tmp1.__loop13_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //129:3
            }
            return result; //131:2
        }

        public string GetImplCallParameterNames(MetaOperation op) //134:1
        {
            string result = "this"; //135:2
            string delim = ", "; //136:2
            var __loop14_results = 
                (from __loop14_var1 in __Enumerate((op).GetEnumerator()) //137:7
                from param in __Enumerate((__loop14_var1.Parameters).GetEnumerator()) //137:11
                select new { __loop14_var1 = __loop14_var1, param = param}
                ).ToList(); //137:2
            int __loop14_iteration = 0;
            foreach (var __tmp1 in __loop14_results)
            {
                ++__loop14_iteration;
                var __loop14_var1 = __tmp1.__loop14_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //138:3
            }
            return result; //140:2
        }

        public string GenerateOperation(MetaOperation op) //143:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = ");"; //144:75
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(op.ReturnType.CSharpFullPublicName());
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
            string __tmp4Line = " "; //144:39
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
            string __tmp6Line = "("; //144:49
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
                    __out.AppendLine(); //144:77
                }
            }
            return __out.ToString();
        }

        public string GenerateInterfaceImpl(MetaModel model, MetaClass cls) //147:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "internal class "; //148:1
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
            string __tmp4Line = " : ModelObject, "; //148:38
            __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(cls.CSharpFullName());
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
                    __out.AppendLine(); //148:76
                }
            }
            __out.Append("{"); //149:1
            __out.AppendLine(); //149:2
            string __tmp6Prefix = "    static "; //150:1
            string __tmp7Suffix = "()"; //150:34
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(cls.CSharpImplName());
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
                    __out.AppendLine(); //150:36
                }
            }
            __out.Append("    {"); //151:1
            __out.AppendLine(); //151:6
            string __tmp9Prefix = "        "; //152:1
            string __tmp10Suffix = ".StaticInit();"; //152:47
            StringBuilder __tmp11 = new StringBuilder();
            __tmp11.Append(cls.Model.CSharpFullDescriptorName());
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
                    __out.AppendLine(); //152:61
                }
            }
            __out.Append("    }"); //153:1
            __out.AppendLine(); //153:6
            __out.AppendLine(); //154:1
            __out.Append("    public override global::MetaDslx.Core.MetaModel MMetaModel"); //155:1
            __out.AppendLine(); //155:63
            __out.Append("    {"); //156:1
            __out.AppendLine(); //156:6
            string __tmp12Prefix = "        get { return "; //157:1
            string __tmp13Suffix = "; }"; //157:58
            StringBuilder __tmp14 = new StringBuilder();
            __tmp14.Append(cls.Model.CSharpFullInstanceName());
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
                    __out.AppendLine(); //157:61
                }
            }
            __out.Append("    }"); //158:1
            __out.AppendLine(); //158:6
            __out.AppendLine(); //159:1
            __out.Append("    public override global::MetaDslx.Core.MetaClass MMetaClass"); //160:1
            __out.AppendLine(); //160:63
            __out.Append("    {"); //161:1
            __out.AppendLine(); //161:6
            string __tmp15Prefix = "        get { return "; //162:1
            string __tmp16Suffix = "; }"; //162:52
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(cls.CSharpFullInstanceName());
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
                    __out.AppendLine(); //162:55
                }
            }
            __out.Append("    }"); //163:1
            __out.AppendLine(); //163:6
            __out.AppendLine(); //164:1
            string __tmp18Prefix = "    "; //165:1
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
                    __out.AppendLine(); //165:42
                }
            }
            var __loop15_results = 
                (from __loop15_var1 in __Enumerate((cls).GetEnumerator()) //166:11
                from prop in __Enumerate((__loop15_var1.GetAllProperties()).GetEnumerator()) //166:16
                select new { __loop15_var1 = __loop15_var1, prop = prop}
                ).ToList(); //166:6
            int __loop15_iteration = 0;
            foreach (var __tmp21 in __loop15_results)
            {
                ++__loop15_iteration;
                var __loop15_var1 = __tmp21.__loop15_var1;
                var prop = __tmp21.prop;
                string __tmp22Prefix = "    "; //167:1
                string __tmp23Suffix = string.Empty; 
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(GeneratePropertyImpl(model, cls, prop));
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
                        __out.AppendLine(); //167:45
                    }
                }
            }
            var __loop16_results = 
                (from __loop16_var1 in __Enumerate((cls).GetEnumerator()) //169:11
                from op in __Enumerate((__loop16_var1.GetAllOperations()).GetEnumerator()) //169:16
                select new { __loop16_var1 = __loop16_var1, op = op}
                ).ToList(); //169:6
            int __loop16_iteration = 0;
            foreach (var __tmp25 in __loop16_results)
            {
                ++__loop16_iteration;
                var __loop16_var1 = __tmp25.__loop16_var1;
                var op = __tmp25.op;
                string __tmp26Prefix = "    "; //170:1
                string __tmp27Suffix = string.Empty; 
                StringBuilder __tmp28 = new StringBuilder();
                __tmp28.Append(GenerateOperationImpl(model, op));
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
                        __out.AppendLine(); //170:39
                    }
                }
            }
            __out.Append("}"); //172:1
            __out.AppendLine(); //172:2
            __out.AppendLine(); //173:1
            return __out.ToString();
        }

        public string GeneratePropertyDeclaration(MetaModel model, MetaClass cls, MetaProperty prop) //176:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class == cls) //177:2
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
                        __out.AppendLine(); //178:28
                    }
                }
                if (prop.Kind == MetaPropertyKind.Containment) //179:2
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
                            __out.AppendLine(); //180:27
                        }
                    }
                }
                if (prop.Kind != MetaPropertyKind.Normal && prop.Kind != MetaPropertyKind.Containment) //182:2
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
                            __out.AppendLine(); //183:24
                        }
                    }
                }
                var __loop17_results = 
                    (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //185:7
                    select new { p = p}
                    ).ToList(); //185:2
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
                    __tmp14.Append(p.Class.CSharpFullDescriptorName());
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
                    __tmp15.Append("), \"");
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
                    __tmp16.Append(p.Name);
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
                    __tmp17.Append("\")]");
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
                            __out.AppendLine(); //186:92
                        }
                    }
                }
                var __loop18_results = 
                    (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //188:7
                    select new { p = p}
                    ).ToList(); //188:2
                int __loop18_iteration = 0;
                foreach (var __tmp18 in __loop18_results)
                {
                    ++__loop18_iteration;
                    var p = __tmp18.p;
                    if (cls.GetAllSuperClasses(false).Contains(p.Class)) //189:3
                    {
                        string __tmp19Prefix = string.Empty; 
                        string __tmp20Suffix = string.Empty; 
                        StringBuilder __tmp21 = new StringBuilder();
                        __tmp21.Append("[SubsetsAttribute(typeof(");
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
                            }
                        }
                        StringBuilder __tmp22 = new StringBuilder();
                        __tmp22.Append(p.Class.CSharpFullDescriptorName());
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
                        StringBuilder __tmp23 = new StringBuilder();
                        __tmp23.Append("), \"");
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
                            }
                        }
                        StringBuilder __tmp25 = new StringBuilder();
                        __tmp25.Append("\")]");
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
                                __out.Append(__tmp20Suffix);
                                __out.AppendLine(); //190:91
                            }
                        }
                    }
                    else //191:3
                    {
                        string __tmp26Prefix = "// ERROR: subsetted property '"; //192:1
                        string __tmp27Suffix = "' must be a property of an ancestor class"; //192:61
                        StringBuilder __tmp28 = new StringBuilder();
                        __tmp28.Append(p.CSharpFullDescriptorName());
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
                                __out.AppendLine(); //192:102
                            }
                        }
                    }
                }
                var __loop19_results = 
                    (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //195:7
                    select new { p = p}
                    ).ToList(); //195:2
                int __loop19_iteration = 0;
                foreach (var __tmp29 in __loop19_results)
                {
                    ++__loop19_iteration;
                    var p = __tmp29.p;
                    if (cls.GetAllSuperClasses(false).Contains(p.Class)) //196:3
                    {
                        string __tmp30Prefix = string.Empty; 
                        string __tmp31Suffix = string.Empty; 
                        StringBuilder __tmp32 = new StringBuilder();
                        __tmp32.Append("[RedefinesAttribute(typeof(");
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
                        StringBuilder __tmp33 = new StringBuilder();
                        __tmp33.Append(p.Class.CSharpFullDescriptorName());
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
                        StringBuilder __tmp34 = new StringBuilder();
                        __tmp34.Append("), \"");
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
                        StringBuilder __tmp35 = new StringBuilder();
                        __tmp35.Append(p.Name);
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
                        StringBuilder __tmp36 = new StringBuilder();
                        __tmp36.Append("\")]");
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
                                __out.AppendLine(); //197:93
                            }
                        }
                    }
                    else //198:3
                    {
                        string __tmp37Prefix = "// ERROR: redefined property '"; //199:1
                        string __tmp38Suffix = "' must be a property of an ancestor class"; //199:61
                        StringBuilder __tmp39 = new StringBuilder();
                        __tmp39.Append(p.CSharpFullDescriptorName());
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
                                __out.AppendLine(); //199:102
                            }
                        }
                    }
                }
                string __tmp40Prefix = "public static readonly ModelProperty "; //202:1
                string __tmp41Suffix = "Property ="; //202:49
                StringBuilder __tmp42 = new StringBuilder();
                __tmp42.Append(prop.Name);
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
                        __out.AppendLine(); //202:59
                    }
                }
                string __tmp43Prefix = "    ModelProperty.Register(\""; //203:1
                string __tmp44Suffix = "Property, LazyThreadSafetyMode.ExecutionAndPublication));"; //203:339
                StringBuilder __tmp45 = new StringBuilder();
                __tmp45.Append(prop.Name);
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
                    }
                }
                string __tmp46Line = "\", typeof("; //203:40
                __out.Append(__tmp46Line);
                StringBuilder __tmp47 = new StringBuilder();
                __tmp47.Append(prop.Type.CSharpFullPublicName());
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
                string __tmp48Line = "), typeof("; //203:84
                __out.Append(__tmp48Line);
                StringBuilder __tmp49 = new StringBuilder();
                __tmp49.Append(prop.Class.CSharpFullName());
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
                string __tmp50Line = "), typeof("; //203:123
                __out.Append(__tmp50Line);
                StringBuilder __tmp51 = new StringBuilder();
                __tmp51.Append(prop.Class.Model.CSharpFullName());
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
                string __tmp52Line = "Descriptor."; //203:168
                __out.Append(__tmp52Line);
                StringBuilder __tmp53 = new StringBuilder();
                __tmp53.Append(prop.Class.CSharpName());
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
                string __tmp54Line = "), new Lazy<global::MetaDslx.Core.MetaProperty>(() => "; //203:204
                __out.Append(__tmp54Line);
                StringBuilder __tmp55 = new StringBuilder();
                __tmp55.Append(prop.Class.Model.CSharpFullName());
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
                string __tmp56Line = "Instance."; //203:293
                __out.Append(__tmp56Line);
                StringBuilder __tmp57 = new StringBuilder();
                __tmp57.Append(prop.Class.CSharpName());
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
                string __tmp58Line = "_"; //203:327
                __out.Append(__tmp58Line);
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
                        __out.Append(__tmp59Line);
                        __out.Append(__tmp44Suffix);
                        __out.AppendLine(); //203:396
                    }
                }
            }
            __out.AppendLine(); //205:1
            return __out.ToString();
        }

        public string GeneratePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //208:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //209:1
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = string.Empty; 
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(prop.Type.CSharpFullPublicName());
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
            string __tmp4Line = " "; //210:35
            __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(prop.Class.CSharpFullName());
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
            string __tmp6Line = "."; //210:65
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
                    __out.AppendLine(); //210:77
                }
            }
            __out.Append("{"); //211:1
            __out.AppendLine(); //211:2
            __out.Append("    get "); //212:1
            __out.AppendLine(); //212:9
            __out.Append("    {"); //213:1
            __out.AppendLine(); //213:6
            string __tmp8Prefix = "        object result = this.MGet("; //214:1
            string __tmp9Suffix = "); "; //214:68
            StringBuilder __tmp10 = new StringBuilder();
            __tmp10.Append(prop.CSharpFullDescriptorName());
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
                    __out.AppendLine(); //214:71
                }
            }
            string __tmp11Prefix = "        if (result != null) return ("; //215:1
            string __tmp12Suffix = ")result;"; //215:71
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(prop.Type.CSharpFullPublicName());
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
                    __out.AppendLine(); //215:79
                }
            }
            string __tmp14Prefix = "        else return default("; //216:1
            string __tmp15Suffix = ");"; //216:63
            StringBuilder __tmp16 = new StringBuilder();
            __tmp16.Append(prop.Type.CSharpFullPublicName());
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
                    __out.AppendLine(); //216:65
                }
            }
            __out.Append("    }"); //217:1
            __out.AppendLine(); //217:6
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //218:3
            {
                string __tmp17Prefix = "    set { this.MSet("; //219:1
                string __tmp18Suffix = ", value); }"; //219:54
                StringBuilder __tmp19 = new StringBuilder();
                __tmp19.Append(prop.CSharpFullDescriptorName());
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
                        __out.AppendLine(); //219:65
                    }
                }
            }
            __out.Append("}"); //221:1
            __out.AppendLine(); //221:2
            return __out.ToString();
        }

        public string GetCollectionConstructorParams(MetaProperty prop) //224:1
        {
            MetaCollectionType mct = prop.Type as MetaCollectionType; //225:2
            if (mct != null && mct.InnerType is MetaClass) //226:2
            {
                return "this, " + prop.CSharpFullDescriptorName(); //227:3
            }
            else //228:2
            {
                return ""; //229:3
            }
        }

        public string GenerateExpression(MetaExpression expr) //234:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //235:10
            if (expr is MetaBracketExpression) //236:2
            {
                __out.Append("("); //236:33
                __out.Append(GenerateExpression(((MetaBracketExpression)expr).Expression));
                __out.Append(")"); //236:71
            }
            else if (expr is MetaThisExpression) //237:2
            {
                __out.Append("(("); //237:30
                __out.Append(((MetaType)ModelCompilerContext.Current.ResolutionProvider.GetCurrentTypeScopeOf((ModelObject)((MetaThisExpression)expr))).CSharpName());
                __out.Append(")this)"); //237:147
            }
            else if (expr is MetaNullExpression) //238:2
            {
                __out.Append("null"); //238:30
            }
            else if (expr is MetaTypeAsExpression) //239:2
            {
                __out.Append(GenerateExpression(((MetaTypeAsExpression)expr).Expression));
                __out.Append(" as "); //239:69
                __out.Append(((MetaTypeAsExpression)expr).TypeReference.CSharpName());
            }
            else if (expr is MetaTypeCastExpression) //240:2
            {
                __out.Append("("); //240:34
                __out.Append(((MetaTypeCastExpression)expr).TypeReference.CSharpName());
                __out.Append(")"); //240:68
                __out.Append(GenerateExpression(((MetaTypeCastExpression)expr).Expression));
            }
            else if (expr is MetaTypeCheckExpression) //241:2
            {
                __out.Append(GenerateExpression(((MetaTypeCheckExpression)expr).Expression));
                __out.Append(" is "); //241:72
                __out.Append(((MetaTypeCheckExpression)expr).TypeReference.CSharpName());
            }
            else if (expr is MetaTypeOfExpression) //242:2
            {
                __out.Append(GenerateTypeOf(((MetaTypeOfExpression)expr)));
            }
            else if (expr is MetaConditionalExpression) //243:2
            {
                __out.Append(GenerateExpression(((MetaConditionalExpression)expr).Condition));
                __out.Append(" ? "); //243:73
                __out.Append(GenerateExpression(((MetaConditionalExpression)expr).Then));
                __out.Append(" : "); //243:107
                __out.Append(GenerateExpression(((MetaConditionalExpression)expr).Else));
            }
            else if (expr is MetaConstantExpression) //244:2
            {
                __out.Append(GetCSharpValue(((MetaConstantExpression)expr).Value));
            }
            else if (expr is MetaIdentifierExpression) //245:2
            {
                __out.Append(GenerateIdentifierExpression(((MetaIdentifierExpression)expr)));
            }
            else if (expr is MetaMemberAccessExpression) //246:2
            {
                __out.Append(GenerateExpression(((MetaMemberAccessExpression)expr).Expression));
                __out.Append("."); //246:75
                __out.Append(((MetaMemberAccessExpression)expr).Name);
            }
            else if (expr is MetaFunctionCallExpression) //247:2
            {
                __out.Append(GenerateFunctionCall(((MetaFunctionCallExpression)expr)));
            }
            else if (expr is MetaIndexerExpression) //248:2
            {
                __out.Append(GenerateIndexerCall(((MetaIndexerExpression)expr)));
            }
            else if (expr is MetaOperatorExpression) //249:2
            {
                __out.Append(GenerateOperator(((MetaOperatorExpression)expr)));
            }
            else if (expr is MetaNewExpression) //250:2
            {
                __out.Append(((MetaNewExpression)expr).TypeReference.CSharpFullFactoryMethodName());
                __out.Append("("); //250:79
                __out.Append(GenerateNewPropertyInitializers(((MetaNewExpression)expr)));
                __out.Append(")"); //250:119
            }
            else if (expr is MetaNewCollectionExpression) //251:2
            {
                __out.Append("new List<Lazy<object>>() { "); //251:39
                __out.Append(GenerateNewCollectionValues(((MetaNewCollectionExpression)expr)));
                __out.Append(" }"); //251:101
            }
            else //252:2
            {
                __out.Append("***unknown expression type***"); //252:11
                __out.AppendLine(); //252:40
            }//253:2
            return __out.ToString();
        }

        public string GenerateIdentifierExpression(MetaIdentifierExpression expr) //256:1
        {
            StringBuilder __out = new StringBuilder();
            if (expr.Definition is MetaProperty) //257:2
            {
                string __tmp1Prefix = "(("; //258:1
                string __tmp2Suffix = string.Empty; 
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(((MetaType)ModelCompilerContext.Current.ResolutionProvider.GetCurrentTypeScopeOf((ModelObject)expr)).CSharpName());
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
                string __tmp4Line = ")this)."; //258:118
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
            else //259:2
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

        public bool SameFunction(MetaGlobalFunction mfunc1, MetaGlobalFunction mfunc2) //264:1
        {
            return mfunc1.Name == mfunc2.Name && ModelCompilerContext.Current.TypeProvider.Equals((ModelObject)mfunc1.Type, (ModelObject)mfunc2.Type); //265:2
        }

        public string GenerateFunctionCall(MetaFunctionCallExpression call) //268:1
        {
            StringBuilder __out = new StringBuilder();
            if (call.Definition is MetaGlobalFunction && SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.TypeOf)) //269:2
            {
                __out.Append(GenerateTypeOf(call.Arguments[0]));
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.GetValueType)) //270:2
            {
                __out.Append("ModelCompilerContext.Current.TypeProvider.GetTypeOf("); //270:89
                __out.Append(GenerateCallArguments(call, ""));
                __out.Append(")"); //270:174
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.GetReturnType)) //271:2
            {
                __out.Append("ModelCompilerContext.Current.TypeProvider.GetReturnTypeOf("); //271:90
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //271:194
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.CurrentType)) //272:2
            {
                __out.Append("ModelCompilerContext.Current.ResolutionProvider.GetCurrentTypeScopeOf("); //272:88
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //272:204
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.TypeCheck)) //273:2
            {
                __out.Append("ModelCompilerContext.Current.TypeProvider.TypeCheck("); //273:86
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //273:184
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Balance)) //274:2
            {
                __out.Append("ModelCompilerContext.Current.TypeProvider.Balance("); //274:84
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //274:180
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Resolve1)) //275:2
            {
                __out.Append("ModelCompilerContext.Current.ResolutionProvider.Resolve(new ModelObject"); //275:85
                __out.Append("[]");
                __out.Append(" { ModelCompilerContext.Current.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.NameOrType, "); //275:162
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //275:301
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Resolve2)) //276:2
            {
                __out.Append("ModelCompilerContext.Current.ResolutionProvider.Resolve(new ModelObject"); //276:85
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //276:162
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, ResolveKind.NameOrType, "); //276:217
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //276:284
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveType1)) //277:2
            {
                __out.Append("ModelCompilerContext.Current.ResolutionProvider.Resolve(new ModelObject"); //277:89
                __out.Append("[]");
                __out.Append(" { ModelCompilerContext.Current.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Type, "); //277:166
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //277:299
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveType2)) //278:2
            {
                __out.Append("ModelCompilerContext.Current.ResolutionProvider.Resolve(new ModelObject"); //278:89
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //278:166
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, ResolveKind.Type, "); //278:221
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //278:282
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveName1)) //279:2
            {
                __out.Append("ModelCompilerContext.Current.ResolutionProvider.Resolve(new ModelObject"); //279:89
                __out.Append("[]");
                __out.Append(" { ModelCompilerContext.Current.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, "); //279:166
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //279:299
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveName2)) //280:2
            {
                __out.Append("ModelCompilerContext.Current.ResolutionProvider.Resolve(new ModelObject"); //280:89
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //280:166
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, ResolveKind.Name, "); //280:221
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //280:282
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind1)) //281:2
            {
                __out.Append("ModelCompilerContext.Current.BindingProvider.Bind(this, new ModelObject"); //281:82
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //281:159
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, new BindingInfo())"); //281:214
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind2)) //282:2
            {
                __out.Append("ModelCompilerContext.Current.BindingProvider.Bind(this, "); //282:82
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new BindingInfo())"); //282:177
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind3)) //283:2
            {
                __out.Append("ModelCompilerContext.Current.BindingProvider.Bind((ModelObject)"); //283:82
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ModelObject"); //283:184
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //283:207
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(" }, new BindingInfo())"); //283:262
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind4)) //284:2
            {
                __out.Append("ModelCompilerContext.Current.BindingProvider.Bind((ModelObject)"); //284:82
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", "); //284:184
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new BindingInfo())"); //284:225
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.SelectOfType1)) //285:2
            {
                __out.Append("new object"); //285:90
                __out.Append("[]");
                __out.Append(" { "); //285:106
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }.Where(e => ModelCompilerContext.Current.TypeProvider.GetTypeOf(e) is "); //285:148
                __out.Append(GetTypeName(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //285:252
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.SelectOfType2)) //286:2
            {
                __out.Append("("); //286:90
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(").Where(e => ModelCompilerContext.Current.TypeProvider.GetTypeOf(e) is "); //286:130
                __out.Append(GetTypeName(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //286:233
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.SelectOfName1)) //287:2
            {
                __out.Append("new object"); //287:90
                __out.Append("[]");
                __out.Append(" { "); //287:106
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }.Where(e => ModelCompilerContext.Current.NameProvider.GetNameOf((ModelObject)e) == "); //287:148
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //287:272
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.SelectOfName2)) //288:2
            {
                __out.Append("("); //288:90
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(").Where(e => ModelCompilerContext.Current.NameProvider.GetNameOf((ModelObject)e) == "); //288:130
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //288:253
            }
            else //289:2
            {
                __out.Append(GenerateExpression(call.Expression));
                __out.Append("("); //289:44
                __out.Append(GenerateCallArguments(call, ""));
                __out.Append(")"); //289:78
            }
            return __out.ToString();
        }

        public string GenerateIndexerCall(MetaIndexerExpression call) //293:1
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

        public string GenerateTypeOf(object expr) //297:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //298:9
            if (expr is MetaPrimitiveType) //299:2
            {
                var __tmp2 = ((MetaPrimitiveType)expr).Name; //300:10
                __out.Append("	"); //301:1
                if (__tmp2 == "*none*") //301:3
                {
                    __out.Append("MetaInstance.None"); //301:18
                    __out.Append("	"); //302:1
                }
                else if (__tmp2 == "*error*") //302:3
                {
                    __out.Append("MetaInstance.Error"); //302:19
                    __out.Append("	"); //303:1
                }
                else if (__tmp2 == "*any*") //303:3
                {
                    __out.Append("MetaInstance.Any"); //303:17
                    __out.Append("	"); //304:1
                }
                else if (__tmp2 == "object") //304:3
                {
                    __out.Append("MetaInstance.Object"); //304:18
                    __out.Append("	"); //305:1
                }
                else if (__tmp2 == "string") //305:3
                {
                    __out.Append("MetaInstance.String"); //305:18
                    __out.Append("	"); //306:1
                }
                else if (__tmp2 == "int") //306:3
                {
                    __out.Append("MetaInstance.Int"); //306:15
                    __out.Append("	"); //307:1
                }
                else if (__tmp2 == "long") //307:3
                {
                    __out.Append("MetaInstance.Long"); //307:16
                    __out.Append("	"); //308:1
                }
                else if (__tmp2 == "float") //308:3
                {
                    __out.Append("MetaInstance.Float"); //308:17
                    __out.Append("	"); //309:1
                }
                else if (__tmp2 == "double") //309:3
                {
                    __out.Append("MetaInstance.Double"); //309:18
                    __out.Append("	"); //310:1
                }
                else if (__tmp2 == "byte") //310:3
                {
                    __out.Append("MetaInstance.Byte"); //310:16
                    __out.Append("	"); //311:1
                }
                else if (__tmp2 == "bool") //311:3
                {
                    __out.Append("MetaInstance.Bool"); //311:16
                    __out.Append("	"); //312:1
                }
                else if (__tmp2 == "void") //312:3
                {
                    __out.Append("MetaInstance.Void"); //312:16
                    __out.Append("	"); //313:1
                }
                else if (__tmp2 == "ModelObject") //313:3
                {
                    __out.Append("MetaInstance.ModelObject"); //313:23
                    __out.Append("	"); //314:1
                }
                else if (__tmp2 == "ModelObjectList") //314:3
                {
                    __out.Append("MetaInstance.ModelObjectList"); //314:27
                }//315:3
            }
            else if (expr is MetaTypeOfExpression) //316:2
            {
                __out.Append(GenerateTypeOf(((MetaTypeOfExpression)expr).TypeReference));
            }
            else if (expr is MetaClass) //317:2
            {
                __out.Append(((MetaClass)expr).CSharpFullDescriptorName());
                __out.Append(".MetaClass"); //317:54
            }
            else if (expr is MetaCollectionType) //318:2
            {
                __out.Append(((MetaCollectionType)expr).CSharpFullName());
            }
            else //319:2
            {
                __out.Append("***error***"); //319:11
            }//320:2
            return __out.ToString();
        }

        public string GenerateCallArguments(MetaBoundExpression call, string prefix) //323:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop20_results = 
                (from __loop20_var1 in __Enumerate((call).GetEnumerator()) //324:7
                from arg in __Enumerate((__loop20_var1.Arguments).GetEnumerator()) //324:13
                select new { __loop20_var1 = __loop20_var1, arg = arg}
                ).ToList(); //324:2
            int __loop20_iteration = 0;
            string delim = ""; //324:28
            foreach (var __tmp1 in __loop20_results)
            {
                ++__loop20_iteration;
                if (__loop20_iteration >= 2) //324:47
                {
                    delim = ", "; //324:47
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

        public string GenerateOperator(MetaOperatorExpression expr) //329:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //330:10
            if (expr is MetaUnaryExpression) //331:2
            {
                if (((MetaUnaryExpression)expr) is MetaPostIncrementAssignExpression || ((MetaUnaryExpression)expr) is MetaPostDecrementAssignExpression) //332:3
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
                else //334:3
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
            else if (expr is MetaBinaryExpression) //337:2
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
            }//339:2
            return __out.ToString();
        }

        public string GenerateNewPropertyInitializers(MetaNewExpression expr) //342:1
        {
            StringBuilder __out = new StringBuilder();
            if ((from __loop21_var1 in __Enumerate((expr).GetEnumerator()) //343:14
            from pi in __Enumerate((__loop21_var1.PropertyInitializers).GetEnumerator()) //343:20
            select new { __loop21_var1 = __loop21_var1, pi = pi}
            ).GetEnumerator().MoveNext()) //343:2
            {
                __out.Append("new List<ModelPropertyInitializer>() {"); //344:1
                var __loop22_results = 
                    (from __loop22_var1 in __Enumerate((expr).GetEnumerator()) //345:7
                    from pi in __Enumerate((__loop22_var1.PropertyInitializers).GetEnumerator()) //345:13
                    select new { __loop22_var1 = __loop22_var1, pi = pi}
                    ).ToList(); //345:2
                int __loop22_iteration = 0;
                string delim = ""; //345:38
                foreach (var __tmp1 in __loop22_results)
                {
                    ++__loop22_iteration;
                    if (__loop22_iteration >= 2) //345:57
                    {
                        delim = ", "; //345:57
                    }
                    var __loop22_var1 = __tmp1.__loop22_var1;
                    var pi = __tmp1.pi;
                    string __tmp2Prefix = string.Empty; 
                    string __tmp3Suffix = ", LazyThreadSafetyMode.ExecutionAndPublication))"; //346:132
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
                    string __tmp5Line = "new ModelPropertyInitializer("; //346:8
                    __out.Append(__tmp5Line);
                    StringBuilder __tmp6 = new StringBuilder();
                    __tmp6.Append(pi.Property.CSharpFullDescriptorName());
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
                    string __tmp7Line = ", new Lazy<object>(() => "; //346:77
                    __out.Append(__tmp7Line);
                    StringBuilder __tmp8 = new StringBuilder();
                    __tmp8.Append(GenerateExpression(pi.Value));
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
                            __out.Append(__tmp3Suffix);
                        }
                    }
                }
                __out.Append("}"); //348:1
            }
            return __out.ToString();
        }

        public string GenerateNewCollectionValues(MetaNewCollectionExpression expr) //352:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((expr).GetEnumerator()) //353:7
                from v in __Enumerate((__loop23_var1.Values).GetEnumerator()) //353:13
                select new { __loop23_var1 = __loop23_var1, v = v}
                ).ToList(); //353:2
            int __loop23_iteration = 0;
            string delim = ""; //353:23
            foreach (var __tmp1 in __loop23_results)
            {
                ++__loop23_iteration;
                if (__loop23_iteration >= 2) //353:42
                {
                    delim = ", \n"; //353:42
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

        public string GetCSharpValue(object value) //358:1
        {
            if (value == null) //359:2
            {
                return "null"; //359:21
            }
            else if (value is bool && ((bool)value) == true) //360:2
            {
                return "true"; //360:51
            }
            else if (value is bool && ((bool)value) == false) //361:2
            {
                return "false"; //361:52
            }
            else if (value is string) //362:2
            {
                return "\"" + value.ToString() + "\""; //362:28
            }
            else if (value is MetaExpression) //363:2
            {
                return GenerateExpression((MetaExpression)value); //363:36
            }
            else //364:2
            {
                return value.ToString(); //364:7
            }
        }

        public string GetCSharpIdentifier(object value) //368:1
        {
            if (value == null) //369:2
            {
                return null; //370:3
            }
            if (value is MetaConstantExpression && ((MetaConstantExpression)value).Value != null) //372:2
            {
                return ((MetaConstantExpression)value).Value.ToString(); //373:3
            }
            else if (value is string) //374:2
            {
                return value.ToString(); //375:3
            }
            else //376:2
            {
                return null; //377:3
            }
        }

        public string GetCSharpOperator(MetaOperatorExpression expr) //381:1
        {
            var __tmp1 = expr; //382:9
            if (expr is MetaUnaryPlusExpression) //383:3
            {
                return "+"; //383:36
            }
            else if (expr is MetaNegateExpression) //384:3
            {
                return "-"; //384:33
            }
            else if (expr is MetaOnesComplementExpression) //385:3
            {
                return "~"; //385:41
            }
            else if (expr is MetaNotExpression) //386:3
            {
                return "!"; //386:30
            }
            else if (expr is MetaPostIncrementAssignExpression) //387:3
            {
                return "++"; //387:46
            }
            else if (expr is MetaPostDecrementAssignExpression) //388:3
            {
                return "--"; //388:46
            }
            else if (expr is MetaPreIncrementAssignExpression) //389:3
            {
                return "++"; //389:45
            }
            else if (expr is MetaPreDecrementAssignExpression) //390:3
            {
                return "--"; //390:45
            }
            else if (expr is MetaMultiplyExpression) //391:3
            {
                return "*"; //391:35
            }
            else if (expr is MetaDivideExpression) //392:3
            {
                return "/"; //392:33
            }
            else if (expr is MetaModuloExpression) //393:3
            {
                return "%"; //393:33
            }
            else if (expr is MetaAddExpression) //394:3
            {
                return "+"; //394:30
            }
            else if (expr is MetaSubtractExpression) //395:3
            {
                return "-"; //395:35
            }
            else if (expr is MetaLeftShiftExpression) //396:3
            {
                return "<<"; //396:36
            }
            else if (expr is MetaRightShiftExpression) //397:3
            {
                return ">>"; //397:37
            }
            else if (expr is MetaLessThanExpression) //398:3
            {
                return "<"; //398:35
            }
            else if (expr is MetaLessThanOrEqualExpression) //399:3
            {
                return "<="; //399:42
            }
            else if (expr is MetaGreaterThanExpression) //400:3
            {
                return ">"; //400:38
            }
            else if (expr is MetaGreaterThanOrEqualExpression) //401:3
            {
                return ">="; //401:45
            }
            else if (expr is MetaEqualExpression) //402:3
            {
                return "=="; //402:32
            }
            else if (expr is MetaNotEqualExpression) //403:3
            {
                return "!="; //403:35
            }
            else if (expr is MetaAndExpression) //404:3
            {
                return "&"; //404:30
            }
            else if (expr is MetaOrExpression) //405:3
            {
                return "|"; //405:29
            }
            else if (expr is MetaExclusiveOrExpression) //406:3
            {
                return "^"; //406:38
            }
            else if (expr is MetaAndAlsoExpression) //407:3
            {
                return "&&"; //407:34
            }
            else if (expr is MetaOrElseExpression) //408:3
            {
                return "||"; //408:33
            }
            else if (expr is MetaNullCoalescingExpression) //409:3
            {
                return "??"; //409:41
            }
            else if (expr is MetaMultiplyAssignExpression) //410:3
            {
                return "*="; //410:41
            }
            else if (expr is MetaDivideAssignExpression) //411:3
            {
                return "/="; //411:39
            }
            else if (expr is MetaModuloAssignExpression) //412:3
            {
                return "%="; //412:39
            }
            else if (expr is MetaAddAssignExpression) //413:3
            {
                return "+="; //413:36
            }
            else if (expr is MetaSubtractAssignExpression) //414:3
            {
                return "-="; //414:41
            }
            else if (expr is MetaLeftShiftAssignExpression) //415:3
            {
                return "<<="; //415:42
            }
            else if (expr is MetaRightShiftAssignExpression) //416:3
            {
                return ">>="; //416:43
            }
            else if (expr is MetaAndAssignExpression) //417:3
            {
                return "&="; //417:36
            }
            else if (expr is MetaExclusiveOrAssignExpression) //418:3
            {
                return "^="; //418:44
            }
            else if (expr is MetaOrAssignExpression) //419:3
            {
                return "|="; //419:35
            }
            else //420:3
            {
                return ""; //420:12
            }//421:2
        }

        public string GetTypeName(MetaExpression expr) //424:1
        {
            if (expr is MetaTypeOfExpression) //425:2
            {
                return ((MetaTypeOfExpression)expr).TypeReference.CSharpFullName(); //425:36
            }
            else //426:2
            {
                return null; //426:7
            }
        }

        public MetaSynthetizedPropertyInitializer GetSynthetizedInitializerFor(MetaClass cls, MetaProperty prop) //430:1
        {
            MetaSynthetizedPropertyInitializer lastInit = null; //431:2
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((cls).GetEnumerator()) //432:7
                from sup in __Enumerate((__loop24_var1.GetAllSuperClasses(true)).GetEnumerator()) //432:12
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //432:42
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //432:55
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaSynthetizedPropertyInitializer>() //432:69
                select new { __loop24_var1 = __loop24_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //432:2
            int __loop24_iteration = 0;
            foreach (var __tmp1 in __loop24_results)
            {
                ++__loop24_iteration;
                var __loop24_var1 = __tmp1.__loop24_var1;
                var sup = __tmp1.sup;
                var Constructor = __tmp1.Constructor;
                var Initializers = __tmp1.Initializers;
                var init = __tmp1.init;
                if (init.Property == prop) //433:3
                {
                    lastInit = init; //434:4
                }
            }
            return lastInit; //437:2
        }

        public string GenerateConstructorImpl(MetaModel model, MetaClass cls) //440:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public "; //441:1
            string __tmp2Suffix = "() "; //441:30
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
                    __out.AppendLine(); //441:33
                }
            }
            __out.Append("{"); //442:1
            __out.AppendLine(); //442:2
            var __loop25_results = 
                (from __loop25_var1 in __Enumerate((cls).GetEnumerator()) //443:8
                from prop in __Enumerate((__loop25_var1.GetAllProperties()).GetEnumerator()) //443:13
                select new { __loop25_var1 = __loop25_var1, prop = prop}
                ).ToList(); //443:3
            int __loop25_iteration = 0;
            foreach (var __tmp4 in __loop25_results)
            {
                ++__loop25_iteration;
                var __loop25_var1 = __tmp4.__loop25_var1;
                var prop = __tmp4.prop;
                MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //444:4
                if (synInit != null) //445:4
                {
                    if (prop.Kind != MetaPropertyKind.Derived) //446:5
                    {
                        if (ModelCompilerContext.Current.TypeProvider.GetTypeOf(synInit.Value) is MetaCollectionType) //447:6
                        {
                            string __tmp5Prefix = "    this.MLazySet("; //448:1
                            string __tmp6Suffix = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //448:112
                            StringBuilder __tmp7 = new StringBuilder();
                            __tmp7.Append(prop.CSharpFullDescriptorName());
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
                            string __tmp8Line = ", new Lazy<object>(() => "; //448:52
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
                                    __out.AppendLine(); //448:161
                                }
                            }
                        }
                        else //449:6
                        {
                            string __tmp10Prefix = "    this.MLazySet("; //450:1
                            string __tmp11Suffix = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //450:112
                            StringBuilder __tmp12 = new StringBuilder();
                            __tmp12.Append(prop.CSharpFullDescriptorName());
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
                            string __tmp13Line = ", new Lazy<object>(() => "; //450:52
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
                                    __out.AppendLine(); //450:161
                                }
                            }
                        }
                    }
                    else //452:5
                    {
                        string __tmp15Prefix = "    this.MDerivedSet("; //453:1
                        string __tmp16Suffix = ");"; //453:98
                        StringBuilder __tmp17 = new StringBuilder();
                        __tmp17.Append(prop.CSharpFullDescriptorName());
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
                        string __tmp18Line = ", () => "; //453:55
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
                                __out.AppendLine(); //453:100
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
                            string __tmp20Prefix = "    this.MSet("; //458:1
                            string __tmp21Suffix = "));"; //458:117
                            StringBuilder __tmp22 = new StringBuilder();
                            __tmp22.Append(prop.CSharpFullDescriptorName());
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
                            string __tmp23Line = ", new "; //458:48
                            __out.Append(__tmp23Line);
                            StringBuilder __tmp24 = new StringBuilder();
                            __tmp24.Append(prop.Type.CSharpName());
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
                            string __tmp25Line = "("; //458:78
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
                                    __out.AppendLine(); //458:120
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //459:6
                        {
                            string __tmp27Prefix = "    this.MLazySet("; //460:1
                            string __tmp28Suffix = "(this), LazyThreadSafetyMode.ExecutionAndPublication));"; //460:164
                            StringBuilder __tmp29 = new StringBuilder();
                            __tmp29.Append(prop.CSharpFullDescriptorName());
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
                            string __tmp30Line = ", new Lazy<object>(() => "; //460:52
                            __out.Append(__tmp30Line);
                            StringBuilder __tmp31 = new StringBuilder();
                            __tmp31.Append(prop.Class.Model.CSharpFullImplementationName());
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
                            string __tmp32Line = "."; //460:126
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
                            string __tmp34Line = "_"; //460:152
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
                                    __out.AppendLine(); //460:219
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Derived) //461:6
                        {
                            string __tmp36Prefix = "    this.MDerivedSet("; //462:1
                            string __tmp37Suffix = "(this));"; //462:150
                            StringBuilder __tmp38 = new StringBuilder();
                            __tmp38.Append(prop.CSharpFullDescriptorName());
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
                            string __tmp39Line = ", () => "; //462:55
                            __out.Append(__tmp39Line);
                            StringBuilder __tmp40 = new StringBuilder();
                            __tmp40.Append(prop.Class.Model.CSharpFullImplementationName());
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
                            string __tmp41Line = "."; //462:112
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
                            string __tmp43Line = "_"; //462:138
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
                                    __out.AppendLine(); //462:158
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Readonly) //463:6
                        {
                            string __tmp45Prefix = "    // Init "; //464:1
                            string __tmp46Suffix = string.Empty; 
                            StringBuilder __tmp47 = new StringBuilder();
                            __tmp47.Append(prop.CSharpFullDescriptorName());
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
                            string __tmp48Line = " in "; //464:46
                            __out.Append(__tmp48Line);
                            StringBuilder __tmp49 = new StringBuilder();
                            __tmp49.Append(prop.Class.Model.CSharpFullImplementationName());
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
                            string __tmp50Line = "."; //464:99
                            __out.Append(__tmp50Line);
                            StringBuilder __tmp51 = new StringBuilder();
                            __tmp51.Append(cls.CSharpName());
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
                            string __tmp52Line = "_"; //464:118
                            __out.Append(__tmp52Line);
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
                                    __out.Append(__tmp53Line);
                                    __out.Append(__tmp46Suffix);
                                    __out.AppendLine(); //464:137
                                }
                            }
                        }
                    }
                    else //466:5
                    {
                        if (prop.Kind == MetaPropertyKind.Lazy) //467:6
                        {
                            string __tmp54Prefix = "    this.MLazySet("; //468:1
                            string __tmp55Suffix = "(this), LazyThreadSafetyMode.ExecutionAndPublication));"; //468:153
                            StringBuilder __tmp56 = new StringBuilder();
                            __tmp56.Append(prop.CSharpFullDescriptorName());
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
                            string __tmp57Line = ", new Lazy<object>(() => "; //468:52
                            __out.Append(__tmp57Line);
                            StringBuilder __tmp58 = new StringBuilder();
                            __tmp58.Append(model.CSharpFullImplementationName());
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
                            string __tmp59Line = "."; //468:115
                            __out.Append(__tmp59Line);
                            StringBuilder __tmp60 = new StringBuilder();
                            __tmp60.Append(prop.Class.CSharpName());
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
                            string __tmp61Line = "_"; //468:141
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
                                    __out.AppendLine(); //468:208
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Derived) //469:6
                        {
                            string __tmp63Prefix = "    this.MDerivedSet("; //470:1
                            string __tmp64Suffix = "(this));"; //470:139
                            StringBuilder __tmp65 = new StringBuilder();
                            __tmp65.Append(prop.CSharpFullDescriptorName());
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
                            string __tmp66Line = ", () => "; //470:55
                            __out.Append(__tmp66Line);
                            StringBuilder __tmp67 = new StringBuilder();
                            __tmp67.Append(model.CSharpFullImplementationName());
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
                            string __tmp68Line = "."; //470:101
                            __out.Append(__tmp68Line);
                            StringBuilder __tmp69 = new StringBuilder();
                            __tmp69.Append(prop.Class.CSharpName());
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
                            string __tmp70Line = "_"; //470:127
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
                                    __out.AppendLine(); //470:147
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Readonly) //471:6
                        {
                            string __tmp72Prefix = "    // Init "; //472:1
                            string __tmp73Suffix = string.Empty; 
                            StringBuilder __tmp74 = new StringBuilder();
                            __tmp74.Append(prop.CSharpFullDescriptorName());
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
                            string __tmp75Line = " in "; //472:46
                            __out.Append(__tmp75Line);
                            StringBuilder __tmp76 = new StringBuilder();
                            __tmp76.Append(model.CSharpFullImplementationName());
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
                            string __tmp77Line = "."; //472:88
                            __out.Append(__tmp77Line);
                            StringBuilder __tmp78 = new StringBuilder();
                            __tmp78.Append(cls.CSharpName());
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
                            string __tmp79Line = "_"; //472:107
                            __out.Append(__tmp79Line);
                            StringBuilder __tmp80 = new StringBuilder();
                            __tmp80.Append(cls.CSharpName());
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
                                    __out.AppendLine(); //472:126
                                }
                            }
                        }
                    }
                }
            }
            var __loop26_results = 
                (from __loop26_var1 in __Enumerate((cls).GetEnumerator()) //477:8
                from sup in __Enumerate((__loop26_var1.GetAllSuperClasses(true)).GetEnumerator()) //477:13
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //477:43
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //477:56
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaInheritedPropertyInitializer>() //477:70
                select new { __loop26_var1 = __loop26_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //477:3
            int __loop26_iteration = 0;
            foreach (var __tmp81 in __loop26_results)
            {
                ++__loop26_iteration;
                var __loop26_var1 = __tmp81.__loop26_var1;
                var sup = __tmp81.sup;
                var Constructor = __tmp81.Constructor;
                var Initializers = __tmp81.Initializers;
                var init = __tmp81.init;
                if (init.Object != null && init.Property != null) //478:4
                {
                    string __tmp82Prefix = "    this.MLazySetChild("; //479:1
                    string __tmp83Suffix = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //479:165
                    StringBuilder __tmp84 = new StringBuilder();
                    __tmp84.Append(init.Object.CSharpFullDescriptorName());
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
                    string __tmp85Line = ", "; //479:64
                    __out.Append(__tmp85Line);
                    StringBuilder __tmp86 = new StringBuilder();
                    __tmp86.Append(init.Property.CSharpFullDescriptorName());
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
                    string __tmp87Line = ", new Lazy<object>(() => "; //479:108
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
                            __out.AppendLine(); //479:214
                        }
                    }
                }
            }
            string __tmp89Prefix = "    "; //482:1
            string __tmp90Suffix = "(this);"; //482:85
            StringBuilder __tmp91 = new StringBuilder();
            __tmp91.Append(cls.Model.CSharpFullImplementationName());
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
            string __tmp92Line = "."; //482:47
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
                }
            }
            string __tmp94Line = "_"; //482:66
            __out.Append(__tmp94Line);
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
                    __out.Append(__tmp95Line);
                    __out.Append(__tmp90Suffix);
                    __out.AppendLine(); //482:92
                }
            }
            var __loop27_results = 
                (from __loop27_var1 in __Enumerate((cls).GetEnumerator()) //483:11
                from prop in __Enumerate((__loop27_var1.GetAllProperties()).GetEnumerator()) //483:16
                select new { __loop27_var1 = __loop27_var1, prop = prop}
                ).ToList(); //483:6
            int __loop27_iteration = 0;
            foreach (var __tmp96 in __loop27_results)
            {
                ++__loop27_iteration;
                var __loop27_var1 = __tmp96.__loop27_var1;
                var prop = __tmp96.prop;
                if (prop.Kind == MetaPropertyKind.Readonly) //484:4
                {
                    string __tmp97Prefix = "    if (!this.MIsSet("; //485:1
                    string __tmp98Suffix = "().\");"; //485:221
                    StringBuilder __tmp99 = new StringBuilder();
                    __tmp99.Append(prop.CSharpFullDescriptorName());
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
                    string __tmp100Line = ")) throw new ModelException(\"Readonly property "; //485:55
                    __out.Append(__tmp100Line);
                    StringBuilder __tmp101 = new StringBuilder();
                    __tmp101.Append(model.CSharpName());
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
                    string __tmp102Line = "."; //485:122
                    __out.Append(__tmp102Line);
                    StringBuilder __tmp103 = new StringBuilder();
                    __tmp103.Append(prop.Class.CSharpName());
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
                    string __tmp104Line = "."; //485:148
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
                    string __tmp106Line = "Property was not set in "; //485:160
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
                        }
                    }
                    string __tmp108Line = "_"; //485:202
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
                            __out.Append(__tmp98Suffix);
                            __out.AppendLine(); //485:227
                        }
                    }
                }
            }
            __out.Append("    this.MMakeDefault();"); //488:1
            __out.AppendLine(); //488:25
            __out.Append("}"); //489:1
            __out.AppendLine(); //489:2
            return __out.ToString();
        }

        public string GetReturn(MetaOperation op) //492:1
        {
            if (op.ReturnType.CSharpName() == "void") //493:5
            {
                return ""; //494:3
            }
            else //495:2
            {
                return "return "; //496:3
            }
        }

        public string GenerateOperationImpl(MetaModel model, MetaOperation op) //500:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //501:1
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = ")"; //502:105
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(op.ReturnType.CSharpFullPublicName());
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
            string __tmp4Line = " "; //502:39
            __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(op.Parent.CSharpFullName());
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
            string __tmp6Line = "."; //502:68
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
            string __tmp8Line = "("; //502:78
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
                    __out.AppendLine(); //502:106
                }
            }
            __out.Append("{"); //503:1
            __out.AppendLine(); //503:2
            string __tmp10Prefix = "    "; //504:1
            string __tmp11Suffix = ");"; //504:125
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
            __tmp13.Append(model.CSharpFullImplementationName());
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
            string __tmp14Line = "."; //504:58
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
            string __tmp16Line = "_"; //504:83
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
            string __tmp18Line = "("; //504:93
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
                    __out.AppendLine(); //504:127
                }
            }
            __out.Append("}"); //505:1
            __out.AppendLine(); //505:2
            return __out.ToString();
        }

        public string GetSuperClasses(MetaClass cls) //508:1
        {
            string result = ""; //509:2
            var __loop28_results = 
                (from __loop28_var1 in __Enumerate((cls).GetEnumerator()) //510:10
                from sup in __Enumerate((__loop28_var1.SuperClasses).GetEnumerator()) //510:15
                select new { __loop28_var1 = __loop28_var1, sup = sup}
                ).ToList(); //510:5
            int __loop28_iteration = 0;
            string delim = ""; //510:33
            foreach (var __tmp1 in __loop28_results)
            {
                ++__loop28_iteration;
                if (__loop28_iteration >= 2) //510:52
                {
                    delim = ", "; //510:52
                }
                var __loop28_var1 = __tmp1.__loop28_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpFullName(); //511:3
            }
            return result; //513:2
        }

        public string GetAllSuperClasses(MetaClass cls) //516:1
        {
            string result = ""; //517:2
            var __loop29_results = 
                (from __loop29_var1 in __Enumerate((cls).GetEnumerator()) //518:10
                from sup in __Enumerate((__loop29_var1.GetAllSuperClasses(false)).GetEnumerator()) //518:15
                select new { __loop29_var1 = __loop29_var1, sup = sup}
                ).ToList(); //518:5
            int __loop29_iteration = 0;
            string delim = ""; //518:46
            foreach (var __tmp1 in __loop29_results)
            {
                ++__loop29_iteration;
                if (__loop29_iteration >= 2) //518:65
                {
                    delim = ", "; //518:65
                }
                var __loop29_var1 = __tmp1.__loop29_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpFullName(); //519:3
            }
            return result; //521:2
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //524:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public static class "; //525:1
            string __tmp2Suffix = string.Empty; 
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.CSharpDescriptorName());
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
                    __out.AppendLine(); //525:51
                }
            }
            __out.Append("{"); //526:1
            __out.AppendLine(); //526:2
            string __tmp4Prefix = "    static "; //527:1
            string __tmp5Suffix = "Descriptor()"; //527:24
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
                    __out.AppendLine(); //527:36
                }
            }
            __out.Append("    {"); //528:1
            __out.AppendLine(); //528:6
            var __loop30_results = 
                (from __loop30_var1 in __Enumerate((model).GetEnumerator()) //529:11
                from Namespace in __Enumerate((__loop30_var1.Namespace).GetEnumerator()) //529:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //529:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //529:43
                select new { __loop30_var1 = __loop30_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //529:6
            int __loop30_iteration = 0;
            foreach (var __tmp7 in __loop30_results)
            {
                ++__loop30_iteration;
                var __loop30_var1 = __tmp7.__loop30_var1;
                var Namespace = __tmp7.Namespace;
                var Declarations = __tmp7.Declarations;
                var cls = __tmp7.cls;
                string __tmp8Prefix = "        "; //530:1
                string __tmp9Suffix = ".StaticInit();"; //530:27
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
                        __out.AppendLine(); //530:41
                    }
                }
            }
            __out.Append("    }"); //532:1
            __out.AppendLine(); //532:6
            __out.AppendLine(); //533:1
            __out.Append("    internal static void StaticInit()"); //534:1
            __out.AppendLine(); //534:38
            __out.Append("    {"); //535:1
            __out.AppendLine(); //535:6
            __out.Append("    }"); //536:1
            __out.AppendLine(); //536:6
            __out.AppendLine(); //537:1
            string __tmp11Prefix = "	public const string Uri = \""; //538:1
            string __tmp12Suffix = "\";"; //538:40
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
                    __out.AppendLine(); //538:42
                }
            }
            __out.AppendLine(); //539:1
            var __loop31_results = 
                (from __loop31_var1 in __Enumerate((model).GetEnumerator()) //540:11
                from Namespace in __Enumerate((__loop31_var1.Namespace).GetEnumerator()) //540:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //540:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //540:43
                select new { __loop31_var1 = __loop31_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //540:6
            int __loop31_iteration = 0;
            foreach (var __tmp14 in __loop31_results)
            {
                ++__loop31_iteration;
                var __loop31_var1 = __tmp14.__loop31_var1;
                var Namespace = __tmp14.Namespace;
                var Declarations = __tmp14.Declarations;
                var cls = __tmp14.cls;
                string __tmp15Prefix = "    "; //541:1
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
                        __out.AppendLine(); //541:34
                    }
                }
            }
            __out.Append("}"); //543:1
            __out.AppendLine(); //543:2
            __out.AppendLine(); //544:1
            return __out.ToString();
        }

        public string GenerateMetaModelClass(MetaClass cls) //548:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //549:1
            string __tmp1Prefix = "public static class "; //550:1
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
                    __out.AppendLine(); //550:39
                }
            }
            __out.Append("{"); //551:1
            __out.AppendLine(); //551:2
            __out.Append("    internal static void StaticInit()"); //552:1
            __out.AppendLine(); //552:38
            __out.Append("    {"); //553:1
            __out.AppendLine(); //553:6
            __out.Append("    }"); //554:1
            __out.AppendLine(); //554:6
            __out.AppendLine(); //555:1
            string __tmp4Prefix = "    static "; //556:1
            string __tmp5Suffix = "()"; //556:30
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
                    __out.AppendLine(); //556:32
                }
            }
            __out.Append("    {"); //557:1
            __out.AppendLine(); //557:6
            string __tmp7Prefix = "        "; //558:1
            string __tmp8Suffix = ".StaticInit();"; //558:47
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(cls.Model.CSharpFullDescriptorName());
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
                    __out.AppendLine(); //558:61
                }
            }
            __out.Append("    }"); //559:1
            __out.AppendLine(); //559:6
            __out.AppendLine(); //560:1
            if (cls.CSharpName() == "MetaClass") //561:2
            {
                __out.Append("    public static global::MetaDslx.Core.MetaClass _MetaClass"); //562:1
                __out.AppendLine(); //562:61
            }
            else //563:2
            {
                __out.Append("    public static global::MetaDslx.Core.MetaClass MetaClass"); //564:1
                __out.AppendLine(); //564:60
            }
            __out.Append("    {"); //566:1
            __out.AppendLine(); //566:6
            string __tmp10Prefix = "        get { return "; //567:1
            string __tmp11Suffix = "; }"; //567:52
            StringBuilder __tmp12 = new StringBuilder();
            __tmp12.Append(cls.CSharpFullInstanceName());
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
                    __out.AppendLine(); //567:55
                }
            }
            __out.Append("    }"); //568:1
            __out.AppendLine(); //568:6
            __out.AppendLine(); //569:1
            var __loop32_results = 
                (from __loop32_var1 in __Enumerate((cls).GetEnumerator()) //570:11
                from prop in __Enumerate((__loop32_var1.Properties).GetEnumerator()) //570:16
                select new { __loop32_var1 = __loop32_var1, prop = prop}
                ).ToList(); //570:6
            int __loop32_iteration = 0;
            foreach (var __tmp13 in __loop32_results)
            {
                ++__loop32_iteration;
                var __loop32_var1 = __tmp13.__loop32_var1;
                var prop = __tmp13.prop;
                string __tmp14Prefix = "    "; //571:1
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
                        __out.AppendLine(); //571:56
                    }
                }
            }
            __out.Append("}"); //573:1
            __out.AppendLine(); //573:2
            return __out.ToString();
        }

        public string GenerateModelConstant(MetaModel model, MetaConstant mconst) //577:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public static readonly "; //578:1
            string __tmp2Suffix = ";"; //578:68
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
            string __tmp4Line = " "; //578:54
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
                    __out.AppendLine(); //578:69
                }
            }
            return __out.ToString();
        }

        public string GenerateModelConstantImpl(MetaModel model, MetaConstant mconst, Dictionary<ModelObject,string> mobjToTmp) //581:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = ";"; //582:51
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
            string __tmp4Line = " = "; //582:14
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
                    __out.AppendLine(); //582:52
                }
            }
            return __out.ToString();
        }

        public string GenerateMetaModelInstance(MetaModel model) //586:1
        {
            StringBuilder __out = new StringBuilder();
            Dictionary<ModelObject,string> mobjToName = model.GetNamedModelObjects(); //587:2
            string __tmp1Prefix = "public static class "; //588:1
            string __tmp2Suffix = string.Empty; 
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.CSharpInstancesName());
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
                    __out.AppendLine(); //588:50
                }
            }
            __out.Append("{"); //589:1
            __out.AppendLine(); //589:2
            __out.Append("    private static global::MetaDslx.Core.Model model;"); //590:1
            __out.AppendLine(); //590:54
            __out.AppendLine(); //591:1
            __out.Append("    public static global::MetaDslx.Core.Model Model"); //592:1
            __out.AppendLine(); //592:52
            __out.Append("    {"); //593:1
            __out.AppendLine(); //593:6
            string __tmp4Prefix = "        get { return "; //594:1
            string __tmp5Suffix = "Instance.model; }"; //594:34
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
                    __out.AppendLine(); //594:51
                }
            }
            __out.Append("    }"); //595:1
            __out.AppendLine(); //595:6
            __out.AppendLine(); //596:1
            __out.Append("    public static readonly global::MetaDslx.Core.MetaModel Meta;"); //597:1
            __out.AppendLine(); //597:65
            __out.AppendLine(); //598:1
            var __loop33_results = 
                (from __loop33_var1 in __Enumerate((model).GetEnumerator()) //599:11
                from Namespace in __Enumerate((__loop33_var1.Namespace).GetEnumerator()) //599:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //599:29
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //599:43
                select new { __loop33_var1 = __loop33_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //599:6
            int __loop33_iteration = 0;
            foreach (var __tmp7 in __loop33_results)
            {
                ++__loop33_iteration;
                var __loop33_var1 = __tmp7.__loop33_var1;
                var Namespace = __tmp7.Namespace;
                var Declarations = __tmp7.Declarations;
                var c = __tmp7.c;
                string __tmp8Prefix = "    "; //600:1
                string __tmp9Suffix = string.Empty; 
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(GenerateModelConstant(model, c));
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
                        __out.AppendLine(); //600:38
                    }
                }
            }
            __out.AppendLine(); //602:1
            var __loop34_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //603:11
                select new { mobj = mobj}
                ).ToList(); //603:6
            int __loop34_iteration = 0;
            foreach (var __tmp11 in __loop34_results)
            {
                ++__loop34_iteration;
                var mobj = __tmp11.mobj;
                string __tmp12Prefix = "	"; //604:1
                string __tmp13Suffix = string.Empty; 
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(GenerateModelObjectInstanceDeclaration(mobj, mobjToName));
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
                        __out.AppendLine(); //604:60
                    }
                }
            }
            __out.AppendLine(); //606:1
            string __tmp15Prefix = "    static "; //607:1
            string __tmp16Suffix = "()"; //607:41
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(model.CSharpInstancesName());
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
                    __out.AppendLine(); //607:43
                }
            }
            __out.Append("    {"); //608:1
            __out.AppendLine(); //608:6
            string __tmp18Prefix = "		"; //609:1
            string __tmp19Suffix = ".StaticInit();"; //609:33
            StringBuilder __tmp20 = new StringBuilder();
            __tmp20.Append(model.CSharpDescriptorName());
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
                    __out.AppendLine(); //609:47
                }
            }
            string __tmp21Prefix = "		"; //610:1
            string __tmp22Suffix = ".model = new global::MetaDslx.Core.Model();"; //610:32
            StringBuilder __tmp23 = new StringBuilder();
            __tmp23.Append(model.CSharpInstancesName());
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
                    __out.AppendLine(); //610:75
                }
            }
            string __tmp24Prefix = "   		using (new ModelContextScope("; //611:1
            string __tmp25Suffix = ".model))"; //611:64
            StringBuilder __tmp26 = new StringBuilder();
            __tmp26.Append(model.CSharpInstancesName());
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
                    __out.AppendLine(); //611:72
                }
            }
            __out.Append("		{"); //612:1
            __out.AppendLine(); //612:4
            var __loop35_results = 
                (from __loop35_var1 in __Enumerate((model).GetEnumerator()) //613:13
                from Namespace in __Enumerate((__loop35_var1.Namespace).GetEnumerator()) //613:20
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //613:31
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //613:45
                select new { __loop35_var1 = __loop35_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //613:8
            int __loop35_iteration = 0;
            foreach (var __tmp27 in __loop35_results)
            {
                ++__loop35_iteration;
                var __loop35_var1 = __tmp27.__loop35_var1;
                var Namespace = __tmp27.Namespace;
                var Declarations = __tmp27.Declarations;
                var c = __tmp27.c;
                string __tmp28Prefix = "            "; //614:1
                string __tmp29Suffix = string.Empty; 
                StringBuilder __tmp30 = new StringBuilder();
                __tmp30.Append(GenerateModelConstantImpl(model, c, mobjToName));
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
                        __out.AppendLine(); //614:62
                    }
                }
            }
            __out.AppendLine(); //616:1
            var __loop36_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //617:10
                select new { mobj = mobj}
                ).ToList(); //617:5
            int __loop36_iteration = 0;
            foreach (var __tmp31 in __loop36_results)
            {
                ++__loop36_iteration;
                var mobj = __tmp31.mobj;
                string __tmp32Prefix = "			"; //618:1
                string __tmp33Suffix = string.Empty; 
                StringBuilder __tmp34 = new StringBuilder();
                __tmp34.Append(GenerateModelObjectInstance(mobj, mobjToName));
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
                        __out.AppendLine(); //618:51
                    }
                }
            }
            __out.AppendLine(); //620:1
            var __loop37_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //621:10
                select new { mobj = mobj}
                ).ToList(); //621:5
            int __loop37_iteration = 0;
            foreach (var __tmp35 in __loop37_results)
            {
                ++__loop37_iteration;
                var mobj = __tmp35.mobj;
                string __tmp36Prefix = "			"; //622:1
                string __tmp37Suffix = string.Empty; 
                StringBuilder __tmp38 = new StringBuilder();
                __tmp38.Append(GenerateModelObjectInstanceInitializer(mobj, mobjToName));
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
                        __out.Append(__tmp37Suffix);
                        __out.AppendLine(); //622:62
                    }
                }
            }
            __out.AppendLine(); //624:1
            string __tmp39Prefix = "            "; //625:1
            string __tmp40Suffix = ".model.EvalLazyValues();"; //625:42
            StringBuilder __tmp41 = new StringBuilder();
            __tmp41.Append(model.CSharpInstancesName());
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
                    __out.AppendLine(); //625:66
                }
            }
            __out.Append("		}"); //626:1
            __out.AppendLine(); //626:4
            __out.Append("    }"); //627:1
            __out.AppendLine(); //627:6
            __out.Append("}"); //628:1
            __out.AppendLine(); //628:2
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceDeclaration(ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //632:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //633:2
            {
                if (mobjToName.ContainsKey(mobj)) //634:3
                {
                    string name = mobjToName[mobj]; //635:4
                    if (name.StartsWith("__")) //636:4
                    {
                        string __tmp1Prefix = "private static readonly global::MetaDslx.Core."; //637:1
                        string __tmp2Suffix = ";"; //637:84
                        StringBuilder __tmp3 = new StringBuilder();
                        __tmp3.Append(mobj.MMetaClass.CSharpName());
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
                        string __tmp4Line = " "; //637:77
                        __out.Append(__tmp4Line);
                        StringBuilder __tmp5 = new StringBuilder();
                        __tmp5.Append(name);
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
                                __out.AppendLine(); //637:85
                            }
                        }
                    }
                    else //638:4
                    {
                        string __tmp6Prefix = "public static readonly global::MetaDslx.Core."; //639:1
                        string __tmp7Suffix = ";"; //639:83
                        StringBuilder __tmp8 = new StringBuilder();
                        __tmp8.Append(mobj.MMetaClass.CSharpName());
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
                        string __tmp9Line = " "; //639:76
                        __out.Append(__tmp9Line);
                        StringBuilder __tmp10 = new StringBuilder();
                        __tmp10.Append(name);
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
                                __out.AppendLine(); //639:84
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstance(ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //646:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //647:2
            {
                if (mobjToName.ContainsKey(mobj)) //648:3
                {
                    string name = mobjToName[mobj]; //649:4
                    string __tmp1Prefix = string.Empty; 
                    string __tmp2Suffix = "();"; //650:89
                    StringBuilder __tmp3 = new StringBuilder();
                    __tmp3.Append(name);
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
                    string __tmp4Line = " = global::MetaDslx.Core.MetaFactory.Instance.Create"; //650:7
                    __out.Append(__tmp4Line);
                    StringBuilder __tmp5 = new StringBuilder();
                    __tmp5.Append(mobj.MMetaClass.CSharpName());
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
                            __out.AppendLine(); //650:92
                        }
                    }
                    if (mobj is MetaModel) //651:4
                    {
                        string __tmp6Prefix = "Meta = "; //652:1
                        string __tmp7Suffix = ";"; //652:14
                        StringBuilder __tmp8 = new StringBuilder();
                        __tmp8.Append(name);
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
                                __out.AppendLine(); //652:15
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceInitializer(ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //659:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //660:2
            {
                if (mobjToName.ContainsKey(mobj)) //661:3
                {
                    var __loop38_results = 
                        (from __loop38_var1 in __Enumerate((mobj).GetEnumerator()) //662:9
                        from prop in __Enumerate((__loop38_var1.MGetAllProperties()).GetEnumerator()) //662:15
                        select new { __loop38_var1 = __loop38_var1, prop = prop}
                        ).ToList(); //662:4
                    int __loop38_iteration = 0;
                    foreach (var __tmp1 in __loop38_results)
                    {
                        ++__loop38_iteration;
                        var __loop38_var1 = __tmp1.__loop38_var1;
                        var prop = __tmp1.prop;
                        if (prop.MetaProperty != null && prop.MetaProperty.Kind != MetaPropertyKind.Derived) //663:5
                        {
                            object propValue = mobj.MGet(prop); //664:6
                            string __tmp2Prefix = string.Empty;
                            string __tmp3Suffix = string.Empty;
                            StringBuilder __tmp4 = new StringBuilder();
                            __tmp4.Append(GenerateModelObjectPropertyValue(mobj, prop, propValue, mobjToName));
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
                                    __out.AppendLine(); //665:70
                                }
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectPropertyValue(ModelObject mobj, ModelProperty prop, object value, Dictionary<ModelObject,string> mobjToName) //673:1
        {
            StringBuilder __out = new StringBuilder();
            string name = mobjToName[mobj]; //674:2
            string propDeclName = "global::" + prop.DeclaringType.FullName.Replace("+", ".") + "." + prop.DeclaredName; //675:2
            if (!prop.IsCollection) //676:2
            {
                string __tmp1Prefix = "((ModelObject)"; //677:1
                string __tmp2Suffix = ");"; //677:44
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(name);
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
                string __tmp4Line = ").MUnSet("; //677:21
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
                        __out.AppendLine(); //677:46
                    }
                }
            }
            ModelObject moValue = value as ModelObject; //679:2
            if (value == null) //680:2
            {
                string __tmp6Prefix = "((ModelObject)"; //681:1
                string __tmp7Suffix = ", new Lazy<object>(() => null, LazyThreadSafetyMode.ExecutionAndPublication));"; //681:46
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(name);
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
                string __tmp9Line = ").MLazyAdd("; //681:21
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
                        __out.AppendLine(); //681:124
                    }
                }
            }
            else if (value is string) //682:2
            {
                string __tmp11Prefix = "((ModelObject)"; //683:1
                string __tmp12Suffix = "\", LazyThreadSafetyMode.ExecutionAndPublication));"; //683:79
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(name);
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
                string __tmp14Line = ").MLazyAdd("; //683:21
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
                string __tmp16Line = ", new Lazy<object>(() => \""; //683:46
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
                        __out.AppendLine(); //683:129
                    }
                }
            }
            else if (value is bool) //684:2
            {
                string __tmp18Prefix = "((ModelObject)"; //685:1
                string __tmp19Suffix = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //685:99
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(name);
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
                string __tmp21Line = ").MLazyAdd("; //685:21
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
                string __tmp23Line = ", new Lazy<object>(() => "; //685:46
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
                        __out.AppendLine(); //685:148
                    }
                }
            }
            else if (value.GetType().IsPrimitive) //686:2
            {
                string __tmp25Prefix = "((ModelObject)"; //687:1
                string __tmp26Suffix = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //687:89
                StringBuilder __tmp27 = new StringBuilder();
                __tmp27.Append(name);
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
                string __tmp28Line = ").MLazyAdd("; //687:21
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
                string __tmp30Line = ", new Lazy<object>(() => "; //687:46
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
                        __out.AppendLine(); //687:138
                    }
                }
            }
            else if (MetaBuiltInTypes.Types.Contains(value)) //688:2
            {
                string __tmp32Prefix = "((ModelObject)"; //689:1
                string __tmp33Suffix = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //689:94
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
                string __tmp35Line = ").MLazyAdd("; //689:21
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
                string __tmp37Line = ", new Lazy<object>(() => "; //689:46
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
                        __out.AppendLine(); //689:143
                    }
                }
            }
            else if (value is MetaPrimitiveType) //690:2
            {
                string __tmp39Prefix = "((ModelObject)"; //691:1
                string __tmp40Suffix = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //691:94
                StringBuilder __tmp41 = new StringBuilder();
                __tmp41.Append(name);
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
                string __tmp42Line = ").MLazyAdd("; //691:21
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
                string __tmp44Line = ", new Lazy<object>(() => "; //691:46
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
                        __out.AppendLine(); //691:143
                    }
                }
            }
            else if (value is Enum) //692:2
            {
                string __tmp46Prefix = "((ModelObject)"; //693:1
                string __tmp47Suffix = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //693:94
                StringBuilder __tmp48 = new StringBuilder();
                __tmp48.Append(name);
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
                string __tmp49Line = ").MLazyAdd("; //693:21
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
                string __tmp51Line = ", new Lazy<object>(() => "; //693:46
                __out.Append(__tmp51Line);
                StringBuilder __tmp52 = new StringBuilder();
                __tmp52.Append(GetEnumValueOf(value));
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
                        __out.AppendLine(); //693:143
                    }
                }
            }
            else if (moValue != null) //694:2
            {
                if (mobjToName.ContainsKey(moValue)) //695:3
                {
                    string __tmp53Prefix = "((ModelObject)"; //696:1
                    string __tmp54Suffix = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //696:92
                    StringBuilder __tmp55 = new StringBuilder();
                    __tmp55.Append(name);
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
                    string __tmp56Line = ").MLazyAdd("; //696:21
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
                    string __tmp58Line = ", new Lazy<object>(() => "; //696:46
                    __out.Append(__tmp58Line);
                    StringBuilder __tmp59 = new StringBuilder();
                    __tmp59.Append(mobjToName[moValue]);
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
                            __out.AppendLine(); //696:141
                        }
                    }
                }
                else //697:3
                {
                    string __tmp60Prefix = "// Omitted since not part of the model: "; //698:1
                    string __tmp61Suffix = string.Empty; 
                    StringBuilder __tmp62 = new StringBuilder();
                    __tmp62.Append(name);
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
                    string __tmp63Line = "."; //698:47
                    __out.Append(__tmp63Line);
                    StringBuilder __tmp64 = new StringBuilder();
                    __tmp64.Append(propDeclName);
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
                    string __tmp65Line = " = "; //698:62
                    __out.Append(__tmp65Line);
                    StringBuilder __tmp66 = new StringBuilder();
                    __tmp66.Append(moValue);
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
                            __out.Append(__tmp61Suffix);
                            __out.AppendLine(); //698:74
                        }
                    }
                }
            }
            else //700:2
            {
                IEnumerable<object> mc = (value as ModelCollection) as IEnumerable<object>; //701:3
                if (mc != null) //702:3
                {
                    var __loop39_results = 
                        (from cvalue in __Enumerate((mc).GetEnumerator()) //703:9
                        select new { cvalue = cvalue}
                        ).ToList(); //703:4
                    int __loop39_iteration = 0;
                    foreach (var __tmp67 in __loop39_results)
                    {
                        ++__loop39_iteration;
                        var cvalue = __tmp67.cvalue;
                        string __tmp68Prefix = string.Empty;
                        string __tmp69Suffix = string.Empty;
                        StringBuilder __tmp70 = new StringBuilder();
                        __tmp70.Append(GenerateModelObjectPropertyValue(mobj, prop, cvalue, mobjToName));
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
                                __out.Append(__tmp69Suffix);
                                __out.AppendLine(); //704:67
                            }
                        }
                    }
                }
                else //706:3
                {
                    string __tmp71Prefix = "// Invalid property value type: "; //707:1
                    string __tmp72Suffix = string.Empty; 
                    StringBuilder __tmp73 = new StringBuilder();
                    __tmp73.Append(name);
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
                            __out.Append(__tmp71Prefix);
                            __out.Append(__tmp73Line);
                        }
                    }
                    string __tmp74Line = "."; //707:39
                    __out.Append(__tmp74Line);
                    StringBuilder __tmp75 = new StringBuilder();
                    __tmp75.Append(propDeclName);
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
                    string __tmp76Line = " = "; //707:54
                    __out.Append(__tmp76Line);
                    StringBuilder __tmp77 = new StringBuilder();
                    __tmp77.Append(value.GetType());
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
                            __out.Append(__tmp72Suffix);
                            __out.AppendLine(); //707:74
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GetInstanceName(ModelObject mobj) //713:1
        {
            MetaAnnotatedElement mannot = mobj as MetaAnnotatedElement; //714:2
            if (mannot != null && !(mobj is MetaConstant)) //715:2
            {
                var __loop40_results = 
                    (from __loop40_var1 in __Enumerate((mannot).GetEnumerator()) //716:8
                    from a in __Enumerate((__loop40_var1.Annotations).GetEnumerator()) //716:16
                    from p in __Enumerate((a.Properties).GetEnumerator()) //716:31
                    where a.Name == "BuiltInName" && p.Name == "Name" //716:44
                    select new { __loop40_var1 = __loop40_var1, a = a, p = p}
                    ).ToList(); //716:3
                int __loop40_iteration = 0;
                foreach (var __tmp1 in __loop40_results)
                {
                    ++__loop40_iteration;
                    var __loop40_var1 = __tmp1.__loop40_var1;
                    var a = __tmp1.a;
                    var p = __tmp1.p;
                    return GetCSharpIdentifier(p.Value); //717:4
                }
            }
            MetaDeclaration mdecl = mobj as MetaDeclaration; //720:2
            if (mdecl != null && !(mdecl is MetaOperation) && !(mobj is MetaConstant)) //721:2
            {
                return mdecl.CSharpInstanceName(); //722:3
            }
            MetaProperty mprop = mobj as MetaProperty; //724:2
            if (mprop != null) //725:2
            {
                return mprop.CSharpInstanceName(); //726:3
            }
            return null; //728:2
        }

        public string GetEnumValueOf(object enm) //733:1
        {
            return "global::" + enm.GetType().FullName.Replace("+", ".") + "." + enm.ToString(); //734:2
        }

        public string GenerateClassMetaInstance(MetaClass cls) //737:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = " = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();"; //738:19
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
                    __out.AppendLine(); //738:83
                }
            }
            return __out.ToString();
        }

        public string GenerateClassMetaInstanceInitializer(MetaClass cls) //741:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = "\";"; //742:46
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
            string __tmp4Line = ".Name = \""; //742:19
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
                    __out.AppendLine(); //742:48
                }
            }
            if (cls.IsAbstract) //743:2
            {
                string __tmp6Prefix = string.Empty; 
                string __tmp7Suffix = ".IsAbstract = true;"; //744:19
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
                        __out.AppendLine(); //744:38
                    }
                }
            }
            var __loop41_results = 
                (from __loop41_var1 in __Enumerate((cls).GetEnumerator()) //746:7
                from sup in __Enumerate((__loop41_var1.SuperClasses).GetEnumerator()) //746:12
                select new { __loop41_var1 = __loop41_var1, sup = sup}
                ).ToList(); //746:2
            int __loop41_iteration = 0;
            foreach (var __tmp9 in __loop41_results)
            {
                ++__loop41_iteration;
                var __loop41_var1 = __tmp9.__loop41_var1;
                var sup = __tmp9.sup;
                string __tmp10Prefix = string.Empty; 
                string __tmp11Suffix = ");"; //747:67
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
                string __tmp13Line = ".SuperClasses.Add("; //747:19
                __out.Append(__tmp13Line);
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(sup.CSharpFullInstanceName());
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
                        __out.AppendLine(); //747:69
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //752:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "internal static class "; //753:1
            string __tmp2Suffix = "ImplementationProvider"; //753:35
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
                    __out.AppendLine(); //753:57
                }
            }
            __out.Append("{"); //754:1
            __out.AppendLine(); //754:2
            string __tmp4Prefix = "    // If there is a compile error at this line, create a new class called "; //755:1
            string __tmp5Suffix = "Implementation"; //755:88
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
                    __out.AppendLine(); //755:102
                }
            }
            string __tmp7Prefix = "	// which is a subclass of "; //756:1
            string __tmp8Suffix = "ImplementationBase:"; //756:40
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
                    __out.AppendLine(); //756:59
                }
            }
            string __tmp10Prefix = "    private static "; //757:1
            string __tmp11Suffix = "Implementation();"; //757:80
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
            string __tmp13Line = "Implementation implementation = new "; //757:32
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
                    __out.AppendLine(); //757:97
                }
            }
            __out.AppendLine(); //758:1
            string __tmp15Prefix = "    public static "; //759:1
            string __tmp16Suffix = "Implementation Implementation"; //759:31
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
                    __out.AppendLine(); //759:60
                }
            }
            __out.Append("    {"); //760:1
            __out.AppendLine(); //760:6
            string __tmp18Prefix = "        get { return "; //761:1
            string __tmp19Suffix = "ImplementationProvider.implementation; }"; //761:34
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
                    __out.AppendLine(); //761:74
                }
            }
            __out.Append("    }"); //762:1
            __out.AppendLine(); //762:6
            __out.Append("}"); //763:1
            __out.AppendLine(); //763:2
            var __loop42_results = 
                (from __loop42_var1 in __Enumerate((model).GetEnumerator()) //764:8
                from Namespace in __Enumerate((__loop42_var1.Namespace).GetEnumerator()) //764:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //764:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //764:40
                select new { __loop42_var1 = __loop42_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //764:3
            int __loop42_iteration = 0;
            foreach (var __tmp21 in __loop42_results)
            {
                ++__loop42_iteration;
                var __loop42_var1 = __tmp21.__loop42_var1;
                var Namespace = __tmp21.Namespace;
                var Declarations = __tmp21.Declarations;
                var enm = __tmp21.enm;
                __out.AppendLine(); //765:1
                string __tmp22Prefix = "public static class "; //766:1
                string __tmp23Suffix = "Extensions"; //766:31
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
                        __out.AppendLine(); //766:41
                    }
                }
                __out.Append("{"); //767:1
                __out.AppendLine(); //767:2
                var __loop43_results = 
                    (from __loop43_var1 in __Enumerate((enm).GetEnumerator()) //768:11
                    from op in __Enumerate((__loop43_var1.Operations).GetEnumerator()) //768:16
                    select new { __loop43_var1 = __loop43_var1, op = op}
                    ).ToList(); //768:6
                int __loop43_iteration = 0;
                foreach (var __tmp25 in __loop43_results)
                {
                    ++__loop43_iteration;
                    var __loop43_var1 = __tmp25.__loop43_var1;
                    var op = __tmp25.op;
                    string __tmp26Prefix = "    public static "; //769:1
                    string __tmp27Suffix = ")"; //769:100
                    StringBuilder __tmp28 = new StringBuilder();
                    __tmp28.Append(op.ReturnType.CSharpFullPublicName());
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
                    string __tmp29Line = " "; //769:57
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
                    string __tmp31Line = "("; //769:67
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
                            __out.AppendLine(); //769:101
                        }
                    }
                    __out.Append("    {"); //770:1
                    __out.AppendLine(); //770:6
                    string __tmp33Prefix = "        "; //771:1
                    string __tmp34Suffix = ");"; //771:144
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
                    string __tmp37Line = "ImplementationProvider.Implementation."; //771:36
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
                    string __tmp39Line = "_"; //771:98
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
                    string __tmp41Line = "("; //771:108
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
                            __out.AppendLine(); //771:146
                        }
                    }
                    __out.Append("    }"); //772:1
                    __out.AppendLine(); //772:6
                }
                __out.Append("}"); //774:1
                __out.AppendLine(); //774:2
            }
            __out.AppendLine(); //776:1
            __out.Append("/// <summary>"); //777:1
            __out.AppendLine(); //777:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //778:1
            __out.AppendLine(); //778:68
            string __tmp43Prefix = "/// This class has to be be overriden in "; //779:1
            string __tmp44Suffix = "Implementation to provide custom"; //779:54
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
                    __out.AppendLine(); //779:86
                }
            }
            __out.Append("/// implementation for the constructors, operations and property values."); //780:1
            __out.AppendLine(); //780:73
            __out.Append("/// </summary>"); //781:1
            __out.AppendLine(); //781:15
            string __tmp46Prefix = "internal abstract class "; //782:1
            string __tmp47Suffix = "ImplementationBase"; //782:37
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
                    __out.AppendLine(); //782:55
                }
            }
            __out.Append("{"); //783:1
            __out.AppendLine(); //783:2
            var __loop44_results = 
                (from __loop44_var1 in __Enumerate((model).GetEnumerator()) //784:8
                from Namespace in __Enumerate((__loop44_var1.Namespace).GetEnumerator()) //784:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //784:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //784:40
                select new { __loop44_var1 = __loop44_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //784:3
            int __loop44_iteration = 0;
            foreach (var __tmp49 in __loop44_results)
            {
                ++__loop44_iteration;
                var __loop44_var1 = __tmp49.__loop44_var1;
                var Namespace = __tmp49.Namespace;
                var Declarations = __tmp49.Declarations;
                var cls = __tmp49.cls;
                __out.Append("    /// <summary>"); //785:1
                __out.AppendLine(); //785:18
                string __tmp50Prefix = "	/// Implements the constructor: "; //786:1
                string __tmp51Suffix = "()"; //786:52
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
                        __out.AppendLine(); //786:54
                    }
                }
                if ((from __loop45_var1 in __Enumerate((cls).GetEnumerator()) //787:15
                from sup in __Enumerate((__loop45_var1.SuperClasses).GetEnumerator()) //787:20
                select new { __loop45_var1 = __loop45_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //787:3
                {
                    string __tmp53Prefix = "	/// Direct superclasses: "; //788:1
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
                            __out.AppendLine(); //788:49
                        }
                    }
                    string __tmp56Prefix = "	/// All superclasses: "; //789:1
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
                            __out.AppendLine(); //789:49
                        }
                    }
                }
                if ((from __loop46_var1 in __Enumerate((cls).GetEnumerator()) //791:15
                from prop in __Enumerate((__loop46_var1.GetAllProperties()).GetEnumerator()) //791:20
                where prop.Kind == MetaPropertyKind.Readonly //791:44
                select new { __loop46_var1 = __loop46_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //791:3
                {
                    __out.Append("    /// Initializes the following readonly properties:"); //792:1
                    __out.AppendLine(); //792:55
                }
                var __loop47_results = 
                    (from __loop47_var1 in __Enumerate((cls).GetEnumerator()) //794:11
                    from prop in __Enumerate((__loop47_var1.GetAllProperties()).GetEnumerator()) //794:16
                    select new { __loop47_var1 = __loop47_var1, prop = prop}
                    ).ToList(); //794:6
                int __loop47_iteration = 0;
                foreach (var __tmp59 in __loop47_results)
                {
                    ++__loop47_iteration;
                    var __loop47_var1 = __tmp59.__loop47_var1;
                    var prop = __tmp59.prop;
                    if (prop.Kind == MetaPropertyKind.Readonly) //795:3
                    {
                        string __tmp60Prefix = "    ///    "; //796:1
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
                        string __tmp63Line = "."; //796:29
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
                                __out.AppendLine(); //796:41
                            }
                        }
                    }
                }
                __out.Append("    /// </summary>"); //799:1
                __out.AppendLine(); //799:19
                string __tmp65Prefix = "    public virtual void "; //800:1
                string __tmp66Suffix = " @this)"; //800:81
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
                string __tmp68Line = "_"; //800:43
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
                string __tmp70Line = "("; //800:62
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
                        __out.AppendLine(); //800:88
                    }
                }
                __out.Append("    {"); //801:1
                __out.AppendLine(); //801:6
                var __loop48_results = 
                    (from __loop48_var1 in __Enumerate((cls).GetEnumerator()) //802:9
                    from sup in __Enumerate((__loop48_var1.SuperClasses).GetEnumerator()) //802:14
                    select new { __loop48_var1 = __loop48_var1, sup = sup}
                    ).ToList(); //802:4
                int __loop48_iteration = 0;
                foreach (var __tmp72 in __loop48_results)
                {
                    ++__loop48_iteration;
                    var __loop48_var1 = __tmp72.__loop48_var1;
                    var sup = __tmp72.sup;
                    string __tmp73Prefix = "        this."; //803:1
                    string __tmp74Suffix = "(@this);"; //803:51
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
                    string __tmp76Line = "_"; //803:32
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
                            __out.AppendLine(); //803:59
                        }
                    }
                }
                __out.Append("    }"); //805:1
                __out.AppendLine(); //805:6
                var __loop49_results = 
                    (from __loop49_var1 in __Enumerate((cls).GetEnumerator()) //806:11
                    from prop in __Enumerate((__loop49_var1.Properties).GetEnumerator()) //806:16
                    select new { __loop49_var1 = __loop49_var1, prop = prop}
                    ).ToList(); //806:6
                int __loop49_iteration = 0;
                foreach (var __tmp78 in __loop49_results)
                {
                    ++__loop49_iteration;
                    var __loop49_var1 = __tmp78.__loop49_var1;
                    var prop = __tmp78.prop;
                    MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //807:4
                    if (synInit == null) //808:4
                    {
                        if (prop.Kind == MetaPropertyKind.Derived) //809:5
                        {
                            __out.AppendLine(); //810:1
                            __out.Append("    /// <summary>"); //811:1
                            __out.AppendLine(); //811:18
                            string __tmp79Prefix = "    /// Returns the value of the derived property: "; //812:1
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
                            string __tmp82Line = "."; //812:70
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
                                    __out.AppendLine(); //812:82
                                }
                            }
                            __out.Append("    /// </summary>"); //813:1
                            __out.AppendLine(); //813:19
                            string __tmp84Prefix = "    public virtual "; //814:1
                            string __tmp85Suffix = " @this)"; //814:104
                            StringBuilder __tmp86 = new StringBuilder();
                            __tmp86.Append(prop.Type.CSharpFullPublicName());
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
                            string __tmp87Line = " "; //814:54
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
                            string __tmp89Line = "_"; //814:73
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
                            string __tmp91Line = "("; //814:85
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
                                    __out.AppendLine(); //814:111
                                }
                            }
                            __out.Append("    {"); //815:1
                            __out.AppendLine(); //815:6
                            __out.Append("        throw new NotImplementedException();"); //816:1
                            __out.AppendLine(); //816:45
                            __out.Append("    }"); //817:1
                            __out.AppendLine(); //817:6
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //818:5
                        {
                            __out.AppendLine(); //819:1
                            __out.Append("    /// <summary>"); //820:1
                            __out.AppendLine(); //820:18
                            string __tmp93Prefix = "    /// Returns the value of the lazy property: "; //821:1
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
                            string __tmp96Line = "."; //821:67
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
                                    __out.AppendLine(); //821:79
                                }
                            }
                            __out.Append("    /// </summary>"); //822:1
                            __out.AppendLine(); //822:19
                            string __tmp98Prefix = "    public virtual "; //823:1
                            string __tmp99Suffix = " @this)"; //823:104
                            StringBuilder __tmp100 = new StringBuilder();
                            __tmp100.Append(prop.Type.CSharpFullPublicName());
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
                            string __tmp101Line = " "; //823:54
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
                            string __tmp103Line = "_"; //823:73
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
                            string __tmp105Line = "("; //823:85
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
                                    __out.AppendLine(); //823:111
                                }
                            }
                            __out.Append("    {"); //824:1
                            __out.AppendLine(); //824:6
                            __out.Append("        throw new NotImplementedException();"); //825:1
                            __out.AppendLine(); //825:45
                            __out.Append("    }"); //826:1
                            __out.AppendLine(); //826:6
                        }
                    }
                }
                var __loop50_results = 
                    (from __loop50_var1 in __Enumerate((cls).GetEnumerator()) //830:11
                    from op in __Enumerate((__loop50_var1.Operations).GetEnumerator()) //830:16
                    select new { __loop50_var1 = __loop50_var1, op = op}
                    ).ToList(); //830:6
                int __loop50_iteration = 0;
                foreach (var __tmp107 in __loop50_results)
                {
                    ++__loop50_iteration;
                    var __loop50_var1 = __tmp107.__loop50_var1;
                    var op = __tmp107.op;
                    __out.AppendLine(); //831:1
                    __out.Append("    /// <summary>"); //832:1
                    __out.AppendLine(); //832:18
                    string __tmp108Prefix = "    /// Implements the operation: "; //833:1
                    string __tmp109Suffix = "()"; //833:63
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
                    string __tmp111Line = "."; //833:53
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
                            __out.AppendLine(); //833:65
                        }
                    }
                    __out.Append("    /// </summary>"); //834:1
                    __out.AppendLine(); //834:19
                    string __tmp113Prefix = "    public virtual "; //835:1
                    string __tmp114Suffix = ")"; //835:116
                    StringBuilder __tmp115 = new StringBuilder();
                    __tmp115.Append(op.ReturnType.CSharpFullPublicName());
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
                    string __tmp116Line = " "; //835:58
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
                    string __tmp118Line = "_"; //835:77
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
                    string __tmp120Line = "("; //835:87
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
                            __out.AppendLine(); //835:117
                        }
                    }
                    __out.Append("    {"); //836:1
                    __out.AppendLine(); //836:6
                    __out.Append("        throw new NotImplementedException();"); //837:1
                    __out.AppendLine(); //837:45
                    __out.Append("    }"); //838:1
                    __out.AppendLine(); //838:6
                }
                __out.AppendLine(); //840:1
            }
            var __loop51_results = 
                (from __loop51_var1 in __Enumerate((model).GetEnumerator()) //842:8
                from Namespace in __Enumerate((__loop51_var1.Namespace).GetEnumerator()) //842:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //842:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //842:40
                select new { __loop51_var1 = __loop51_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //842:3
            int __loop51_iteration = 0;
            foreach (var __tmp122 in __loop51_results)
            {
                ++__loop51_iteration;
                var __loop51_var1 = __tmp122.__loop51_var1;
                var Namespace = __tmp122.Namespace;
                var Declarations = __tmp122.Declarations;
                var enm = __tmp122.enm;
                var __loop52_results = 
                    (from __loop52_var1 in __Enumerate((enm).GetEnumerator()) //843:11
                    from op in __Enumerate((__loop52_var1.Operations).GetEnumerator()) //843:16
                    select new { __loop52_var1 = __loop52_var1, op = op}
                    ).ToList(); //843:6
                int __loop52_iteration = 0;
                foreach (var __tmp123 in __loop52_results)
                {
                    ++__loop52_iteration;
                    var __loop52_var1 = __tmp123.__loop52_var1;
                    var op = __tmp123.op;
                    __out.AppendLine(); //844:1
                    __out.Append("    /// <summary>"); //845:1
                    __out.AppendLine(); //845:18
                    string __tmp124Prefix = "    /// Implements the operation: "; //846:1
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
                    string __tmp127Line = "."; //846:53
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
                            __out.AppendLine(); //846:63
                        }
                    }
                    __out.Append("    /// </summary>"); //847:1
                    __out.AppendLine(); //847:19
                    string __tmp129Prefix = "    public virtual "; //848:1
                    string __tmp130Suffix = ")"; //848:116
                    StringBuilder __tmp131 = new StringBuilder();
                    __tmp131.Append(op.ReturnType.CSharpFullPublicName());
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
                    string __tmp132Line = " "; //848:58
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
                    string __tmp134Line = "_"; //848:77
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
                    string __tmp136Line = "("; //848:87
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
                            __out.AppendLine(); //848:117
                        }
                    }
                    __out.Append("    {"); //849:1
                    __out.AppendLine(); //849:6
                    __out.Append("        throw new NotImplementedException();"); //850:1
                    __out.AppendLine(); //850:45
                    __out.Append("    }"); //851:1
                    __out.AppendLine(); //851:6
                }
                __out.AppendLine(); //853:1
            }
            __out.Append("}"); //855:1
            __out.AppendLine(); //855:2
            __out.AppendLine(); //856:1
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //859:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //860:1
            __out.AppendLine(); //860:14
            __out.Append("/// Factory class for creating instances of model elements."); //861:1
            __out.AppendLine(); //861:60
            __out.Append("/// </summary>"); //862:1
            __out.AppendLine(); //862:15
            string __tmp1Prefix = "public class "; //863:1
            string __tmp2Suffix = " : ModelFactory"; //863:41
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.CSharpFactoryName());
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
                    __out.AppendLine(); //863:56
                }
            }
            __out.Append("{"); //864:1
            __out.AppendLine(); //864:2
            string __tmp4Prefix = "    private static "; //865:1
            string __tmp5Suffix = "();"; //865:90
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(model.CSharpFactoryName());
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
            string __tmp7Line = " instance = new "; //865:47
            __out.Append(__tmp7Line);
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(model.CSharpFactoryName());
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
                    __out.AppendLine(); //865:93
                }
            }
            __out.AppendLine(); //866:1
            string __tmp9Prefix = "	private "; //867:1
            string __tmp10Suffix = "()"; //867:37
            StringBuilder __tmp11 = new StringBuilder();
            __tmp11.Append(model.CSharpFactoryName());
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
                    __out.AppendLine(); //867:39
                }
            }
            __out.Append("	{"); //868:1
            __out.AppendLine(); //868:3
            __out.Append("	}"); //869:1
            __out.AppendLine(); //869:3
            __out.AppendLine(); //870:1
            __out.Append("    /// <summary>"); //871:1
            __out.AppendLine(); //871:18
            __out.Append("    /// The singleton instance of the factory."); //872:1
            __out.AppendLine(); //872:47
            __out.Append("    /// </summary>"); //873:1
            __out.AppendLine(); //873:19
            string __tmp12Prefix = "    public static "; //874:1
            string __tmp13Suffix = " Instance"; //874:46
            StringBuilder __tmp14 = new StringBuilder();
            __tmp14.Append(model.CSharpFactoryName());
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
                    __out.AppendLine(); //874:55
                }
            }
            __out.Append("    {"); //875:1
            __out.AppendLine(); //875:6
            string __tmp15Prefix = "        get { return "; //876:1
            string __tmp16Suffix = ".instance; }"; //876:49
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(model.CSharpFactoryName());
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
                    __out.AppendLine(); //876:61
                }
            }
            __out.Append("    }"); //877:1
            __out.AppendLine(); //877:6
            var __loop53_results = 
                (from __loop53_var1 in __Enumerate((model).GetEnumerator()) //878:8
                from Namespace in __Enumerate((__loop53_var1.Namespace).GetEnumerator()) //878:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //878:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //878:40
                select new { __loop53_var1 = __loop53_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //878:3
            int __loop53_iteration = 0;
            foreach (var __tmp18 in __loop53_results)
            {
                ++__loop53_iteration;
                var __loop53_var1 = __tmp18.__loop53_var1;
                var Namespace = __tmp18.Namespace;
                var Declarations = __tmp18.Declarations;
                var cls = __tmp18.cls;
                if (!cls.IsAbstract) //879:4
                {
                    __out.AppendLine(); //880:1
                    __out.Append("    /// <summary>"); //881:1
                    __out.AppendLine(); //881:18
                    string __tmp19Prefix = "    /// Creates a new instance of "; //882:1
                    string __tmp20Suffix = "."; //882:53
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
                            __out.AppendLine(); //882:54
                        }
                    }
                    __out.Append("    /// </summary>"); //883:1
                    __out.AppendLine(); //883:19
                    string __tmp22Prefix = "    public "; //884:1
                    string __tmp23Suffix = "(IEnumerable<ModelPropertyInitializer> initializers = null)"; //884:55
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
                    string __tmp25Line = " Create"; //884:30
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
                            __out.AppendLine(); //884:114
                        }
                    }
                    __out.Append("	{"); //885:1
                    __out.AppendLine(); //885:3
                    string __tmp27Prefix = "		"; //886:1
                    string __tmp28Suffix = "Impl();"; //886:57
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
                    string __tmp30Line = " result = new "; //886:21
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
                            __out.AppendLine(); //886:64
                        }
                    }
                    __out.Append("		if (initializers != null)"); //887:1
                    __out.AppendLine(); //887:28
                    __out.Append("		{"); //888:1
                    __out.AppendLine(); //888:4
                    __out.Append("			this.Init((ModelObject)result, initializers);"); //889:1
                    __out.AppendLine(); //889:49
                    __out.Append("		}"); //890:1
                    __out.AppendLine(); //890:4
                    __out.Append("		return result;"); //891:1
                    __out.AppendLine(); //891:17
                    __out.Append("	}"); //892:1
                    __out.AppendLine(); //892:3
                }
            }
            __out.Append("}"); //895:1
            __out.AppendLine(); //895:2
            __out.AppendLine(); //896:1
            return __out.ToString();
        }

    }
}

