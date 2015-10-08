using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core //1:1
{
    using __Hidden_MetaModelGenerator_533952233;
    namespace __Hidden_MetaModelGenerator_533952233
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
            __out.Append("using MetaDslx.Core;"); //11:1
            __out.AppendLine(); //11:21
            __out.AppendLine(); //12:1
            var __loop1_results = 
                (from __loop1_var1 in __Enumerate((Instances).GetEnumerator()) //13:8
                from mm in __Enumerate((__loop1_var1).GetEnumerator()).OfType<MetaModel>() //13:19
                select new { __loop1_var1 = __loop1_var1, mm = mm}
                ).ToList(); //13:3
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
                        __out.AppendLine(); //14:24
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateMetamodel(MetaModel model) //18:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "namespace "; //19:1
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
                    __out.AppendLine(); //19:41
                }
            }
            __out.Append("{"); //20:1
            __out.AppendLine(); //20:2
            string __tmp4Prefix = "    "; //21:1
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
                    __out.AppendLine(); //21:41
                }
            }
            string __tmp7Prefix = "	"; //22:1
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
                    __out.AppendLine(); //22:36
                }
            }
            var __loop2_results = 
                (from __loop2_var1 in __Enumerate((model).GetEnumerator()) //23:8
                from Namespace in __Enumerate((__loop2_var1.Namespace).GetEnumerator()) //23:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //23:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //23:40
                select new { __loop2_var1 = __loop2_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //23:3
            int __loop2_iteration = 0;
            foreach (var __tmp10 in __loop2_results)
            {
                ++__loop2_iteration;
                var __loop2_var1 = __tmp10.__loop2_var1;
                var Namespace = __tmp10.Namespace;
                var Declarations = __tmp10.Declarations;
                var enm = __tmp10.enm;
                string __tmp11Prefix = "    "; //24:1
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
                        __out.AppendLine(); //24:24
                    }
                }
            }
            var __loop3_results = 
                (from __loop3_var1 in __Enumerate((model).GetEnumerator()) //26:8
                from Namespace in __Enumerate((__loop3_var1.Namespace).GetEnumerator()) //26:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //26:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //26:40
                select new { __loop3_var1 = __loop3_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //26:3
            int __loop3_iteration = 0;
            foreach (var __tmp14 in __loop3_results)
            {
                ++__loop3_iteration;
                var __loop3_var1 = __tmp14.__loop3_var1;
                var Namespace = __tmp14.Namespace;
                var Declarations = __tmp14.Declarations;
                var cls = __tmp14.cls;
                string __tmp15Prefix = "    "; //27:1
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
                        __out.AppendLine(); //27:29
                    }
                }
                string __tmp18Prefix = "    "; //28:1
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
                        __out.AppendLine(); //28:40
                    }
                }
            }
            string __tmp21Prefix = "    "; //30:1
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
                    __out.AppendLine(); //30:29
                }
            }
            string __tmp24Prefix = "    "; //31:1
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
                    __out.AppendLine(); //31:44
                }
            }
            __out.Append("}"); //32:1
            __out.AppendLine(); //32:2
            return __out.ToString();
        }

        public string GenerateAnnotations(MetaAnnotatedElement elem) //35:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop4_results = 
                (from __loop4_var1 in __Enumerate((elem).GetEnumerator()) //36:7
                from annot in __Enumerate((__loop4_var1.Annotations).GetEnumerator()) //36:13
                select new { __loop4_var1 = __loop4_var1, annot = annot}
                ).ToList(); //36:2
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
                        __out.AppendLine(); //37:23
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateEnum(MetaEnum enm) //41:1
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
                    __out.AppendLine(); //42:27
                }
            }
            string __tmp4Prefix = "public enum "; //43:1
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
                    __out.AppendLine(); //43:31
                }
            }
            __out.Append("{"); //44:1
            __out.AppendLine(); //44:2
            var __loop5_results = 
                (from __loop5_var1 in __Enumerate((enm).GetEnumerator()) //45:11
                from value in __Enumerate((__loop5_var1.EnumLiterals).GetEnumerator()) //45:16
                select new { __loop5_var1 = __loop5_var1, value = value}
                ).ToList(); //45:6
            int __loop5_iteration = 0;
            foreach (var __tmp7 in __loop5_results)
            {
                ++__loop5_iteration;
                var __loop5_var1 = __tmp7.__loop5_var1;
                var value = __tmp7.value;
                string __tmp8Prefix = "    "; //46:1
                string __tmp9Suffix = ","; //46:17
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
                        __out.AppendLine(); //46:18
                    }
                }
            }
            __out.Append("}"); //48:1
            __out.AppendLine(); //48:2
            __out.AppendLine(); //49:1
            return __out.ToString();
        }

        public string GetAncestors(MetaClass cls) //52:1
        {
            string result = ""; //53:2
            var __loop6_results = 
                (from __loop6_var1 in __Enumerate((cls).GetEnumerator()) //54:7
                from super in __Enumerate((__loop6_var1.SuperClasses).GetEnumerator()) //54:12
                select new { __loop6_var1 = __loop6_var1, super = super}
                ).ToList(); //54:2
            int __loop6_iteration = 0;
            string delim = " : "; //54:32
            foreach (var __tmp1 in __loop6_results)
            {
                ++__loop6_iteration;
                if (__loop6_iteration >= 2) //54:54
                {
                    delim = ", "; //54:54
                }
                var __loop6_var1 = __tmp1.__loop6_var1;
                var super = __tmp1.super;
                result += delim + super.CSharpFullName(); //55:3
            }
            return result; //57:2
        }

        public string GenerateInterface(MetaClass cls) //60:1
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
                    __out.AppendLine(); //61:27
                }
            }
            string __tmp4Prefix = "public interface "; //62:1
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
                    __out.AppendLine(); //62:55
                }
            }
            __out.Append("{"); //63:1
            __out.AppendLine(); //63:2
            var __loop7_results = 
                (from __loop7_var1 in __Enumerate((cls).GetEnumerator()) //64:11
                from prop in __Enumerate((__loop7_var1.Properties).GetEnumerator()) //64:16
                select new { __loop7_var1 = __loop7_var1, prop = prop}
                ).ToList(); //64:6
            int __loop7_iteration = 0;
            foreach (var __tmp8 in __loop7_results)
            {
                ++__loop7_iteration;
                var __loop7_var1 = __tmp8.__loop7_var1;
                var prop = __tmp8.prop;
                string __tmp9Prefix = "    "; //65:1
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
                        __out.AppendLine(); //65:29
                    }
                }
            }
            __out.AppendLine(); //67:1
            var __loop8_results = 
                (from __loop8_var1 in __Enumerate((cls).GetEnumerator()) //68:11
                from op in __Enumerate((__loop8_var1.Operations).GetEnumerator()) //68:16
                select new { __loop8_var1 = __loop8_var1, op = op}
                ).ToList(); //68:6
            int __loop8_iteration = 0;
            foreach (var __tmp12 in __loop8_results)
            {
                ++__loop8_iteration;
                var __loop8_var1 = __tmp12.__loop8_var1;
                var op = __tmp12.op;
                string __tmp13Prefix = "    "; //69:1
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
                        __out.AppendLine(); //69:28
                    }
                }
            }
            __out.Append("}"); //71:1
            __out.AppendLine(); //71:2
            __out.AppendLine(); //72:1
            return __out.ToString();
        }

        public string GenerateProperty(MetaProperty prop) //75:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //76:2
            {
                __out.Append("new "); //77:1
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //79:3
            {
                string __tmp1Prefix = string.Empty; 
                string __tmp2Suffix = " { get; set; }"; //80:47
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
                string __tmp4Line = " "; //80:35
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
                        __out.AppendLine(); //80:61
                    }
                }
            }
            else //81:3
            {
                string __tmp6Prefix = string.Empty; 
                string __tmp7Suffix = " { get; }"; //82:47
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
                string __tmp9Line = " "; //82:35
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
                        __out.AppendLine(); //82:56
                    }
                }
            }
            return __out.ToString();
        }

        public string GetParameters(MetaOperation op, bool defaultValues) //86:1
        {
            string result = ""; //87:2
            var __loop9_results = 
                (from __loop9_var1 in __Enumerate((op).GetEnumerator()) //88:7
                from param in __Enumerate((__loop9_var1.Parameters).GetEnumerator()) //88:11
                select new { __loop9_var1 = __loop9_var1, param = param}
                ).ToList(); //88:2
            int __loop9_iteration = 0;
            string delim = ""; //88:29
            foreach (var __tmp1 in __loop9_results)
            {
                ++__loop9_iteration;
                if (__loop9_iteration >= 2) //88:48
                {
                    delim = ", "; //88:48
                }
                var __loop9_var1 = __tmp1.__loop9_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName() + " " + param.Name; //89:3
            }
            return result; //94:2
        }

        public string GetImplParameters(MetaClass cls, MetaOperation op) //97:1
        {
            string result = cls.CSharpFullName() + " @this"; //98:2
            string delim = ", "; //99:2
            var __loop10_results = 
                (from __loop10_var1 in __Enumerate((op).GetEnumerator()) //100:7
                from param in __Enumerate((__loop10_var1.Parameters).GetEnumerator()) //100:11
                select new { __loop10_var1 = __loop10_var1, param = param}
                ).ToList(); //100:2
            int __loop10_iteration = 0;
            foreach (var __tmp1 in __loop10_results)
            {
                ++__loop10_iteration;
                var __loop10_var1 = __tmp1.__loop10_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName() + " " + param.Name; //101:3
            }
            return result; //103:2
        }

        public string GetImplParameters(MetaEnum enm, MetaOperation op) //106:1
        {
            string result = enm.CSharpFullName() + " @this"; //107:2
            string delim = ", "; //108:2
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((op).GetEnumerator()) //109:7
                from param in __Enumerate((__loop11_var1.Parameters).GetEnumerator()) //109:11
                select new { __loop11_var1 = __loop11_var1, param = param}
                ).ToList(); //109:2
            int __loop11_iteration = 0;
            foreach (var __tmp1 in __loop11_results)
            {
                ++__loop11_iteration;
                var __loop11_var1 = __tmp1.__loop11_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName() + " " + param.Name; //110:3
            }
            return result; //112:2
        }

        public string GetEnumImplParameters(MetaEnum enm, MetaOperation op) //115:1
        {
            string result = "this " + enm.CSharpFullName() + " @this"; //116:2
            string delim = ", "; //117:2
            var __loop12_results = 
                (from __loop12_var1 in __Enumerate((op).GetEnumerator()) //118:7
                from param in __Enumerate((__loop12_var1.Parameters).GetEnumerator()) //118:11
                select new { __loop12_var1 = __loop12_var1, param = param}
                ).ToList(); //118:2
            int __loop12_iteration = 0;
            foreach (var __tmp1 in __loop12_results)
            {
                ++__loop12_iteration;
                var __loop12_var1 = __tmp1.__loop12_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName() + " " + param.Name; //119:3
            }
            return result; //121:2
        }

        public string GetEnumImplCallParameterNames(MetaOperation op) //124:1
        {
            string result = "@this"; //125:2
            string delim = ", "; //126:2
            var __loop13_results = 
                (from __loop13_var1 in __Enumerate((op).GetEnumerator()) //127:7
                from param in __Enumerate((__loop13_var1.Parameters).GetEnumerator()) //127:11
                select new { __loop13_var1 = __loop13_var1, param = param}
                ).ToList(); //127:2
            int __loop13_iteration = 0;
            foreach (var __tmp1 in __loop13_results)
            {
                ++__loop13_iteration;
                var __loop13_var1 = __tmp1.__loop13_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //128:3
            }
            return result; //130:2
        }

        public string GetImplCallParameterNames(MetaOperation op) //133:1
        {
            string result = "this"; //134:2
            string delim = ", "; //135:2
            var __loop14_results = 
                (from __loop14_var1 in __Enumerate((op).GetEnumerator()) //136:7
                from param in __Enumerate((__loop14_var1.Parameters).GetEnumerator()) //136:11
                select new { __loop14_var1 = __loop14_var1, param = param}
                ).ToList(); //136:2
            int __loop14_iteration = 0;
            foreach (var __tmp1 in __loop14_results)
            {
                ++__loop14_iteration;
                var __loop14_var1 = __tmp1.__loop14_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //137:3
            }
            return result; //139:2
        }

        public string GenerateOperation(MetaOperation op) //142:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = ");"; //143:75
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
            string __tmp4Line = " "; //143:39
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
            string __tmp6Line = "("; //143:49
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
                    __out.AppendLine(); //143:77
                }
            }
            return __out.ToString();
        }

        public string GenerateInterfaceImpl(MetaModel model, MetaClass cls) //146:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "internal class "; //147:1
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
            string __tmp4Line = " : ModelObject, "; //147:38
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
                    __out.AppendLine(); //147:76
                }
            }
            __out.Append("{"); //148:1
            __out.AppendLine(); //148:2
            string __tmp6Prefix = "    static "; //149:1
            string __tmp7Suffix = "()"; //149:34
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
                    __out.AppendLine(); //149:36
                }
            }
            __out.Append("    {"); //150:1
            __out.AppendLine(); //150:6
            string __tmp9Prefix = "        "; //151:1
            string __tmp10Suffix = ".StaticInit();"; //151:47
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
                    __out.AppendLine(); //151:61
                }
            }
            __out.Append("    }"); //152:1
            __out.AppendLine(); //152:6
            __out.AppendLine(); //153:1
            __out.Append("    public override global::MetaDslx.Core.MetaModel MMetaModel"); //154:1
            __out.AppendLine(); //154:63
            __out.Append("    {"); //155:1
            __out.AppendLine(); //155:6
            string __tmp12Prefix = "        get { return "; //156:1
            string __tmp13Suffix = "; }"; //156:58
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
                    __out.AppendLine(); //156:61
                }
            }
            __out.Append("    }"); //157:1
            __out.AppendLine(); //157:6
            __out.AppendLine(); //158:1
            __out.Append("    public override global::MetaDslx.Core.MetaClass MMetaClass"); //159:1
            __out.AppendLine(); //159:63
            __out.Append("    {"); //160:1
            __out.AppendLine(); //160:6
            string __tmp15Prefix = "        get { return "; //161:1
            string __tmp16Suffix = "; }"; //161:52
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
                    __out.AppendLine(); //161:55
                }
            }
            __out.Append("    }"); //162:1
            __out.AppendLine(); //162:6
            __out.AppendLine(); //163:1
            string __tmp18Prefix = "    "; //164:1
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
                    __out.AppendLine(); //164:42
                }
            }
            var __loop15_results = 
                (from __loop15_var1 in __Enumerate((cls).GetEnumerator()) //165:11
                from prop in __Enumerate((__loop15_var1.GetAllProperties()).GetEnumerator()) //165:16
                select new { __loop15_var1 = __loop15_var1, prop = prop}
                ).ToList(); //165:6
            int __loop15_iteration = 0;
            foreach (var __tmp21 in __loop15_results)
            {
                ++__loop15_iteration;
                var __loop15_var1 = __tmp21.__loop15_var1;
                var prop = __tmp21.prop;
                string __tmp22Prefix = "    "; //166:1
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
                        __out.AppendLine(); //166:45
                    }
                }
            }
            var __loop16_results = 
                (from __loop16_var1 in __Enumerate((cls).GetEnumerator()) //168:11
                from op in __Enumerate((__loop16_var1.GetAllOperations()).GetEnumerator()) //168:16
                select new { __loop16_var1 = __loop16_var1, op = op}
                ).ToList(); //168:6
            int __loop16_iteration = 0;
            foreach (var __tmp25 in __loop16_results)
            {
                ++__loop16_iteration;
                var __loop16_var1 = __tmp25.__loop16_var1;
                var op = __tmp25.op;
                string __tmp26Prefix = "    "; //169:1
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
                        __out.AppendLine(); //169:39
                    }
                }
            }
            __out.Append("}"); //171:1
            __out.AppendLine(); //171:2
            __out.AppendLine(); //172:1
            return __out.ToString();
        }

        public string GeneratePropertyDeclaration(MetaModel model, MetaClass cls, MetaProperty prop) //175:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class == cls) //176:2
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
                        __out.AppendLine(); //177:28
                    }
                }
                if (prop.Kind == MetaPropertyKind.Containment) //178:2
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
                            __out.AppendLine(); //179:27
                        }
                    }
                }
                if (prop.Kind != MetaPropertyKind.Normal && prop.Kind != MetaPropertyKind.Containment) //181:2
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
                            __out.AppendLine(); //182:24
                        }
                    }
                }
                var __loop17_results = 
                    (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //184:7
                    select new { p = p}
                    ).ToList(); //184:2
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
                            __out.AppendLine(); //185:92
                        }
                    }
                }
                var __loop18_results = 
                    (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //187:7
                    select new { p = p}
                    ).ToList(); //187:2
                int __loop18_iteration = 0;
                foreach (var __tmp18 in __loop18_results)
                {
                    ++__loop18_iteration;
                    var p = __tmp18.p;
                    if (cls.GetAllSuperClasses(false).Contains(p.Class)) //188:3
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
                                __out.AppendLine(); //189:91
                            }
                        }
                    }
                    else //190:3
                    {
                        string __tmp26Prefix = "// ERROR: subsetted property '"; //191:1
                        string __tmp27Suffix = "' must be a property of an ancestor class"; //191:61
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
                                __out.AppendLine(); //191:102
                            }
                        }
                    }
                }
                var __loop19_results = 
                    (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //194:7
                    select new { p = p}
                    ).ToList(); //194:2
                int __loop19_iteration = 0;
                foreach (var __tmp29 in __loop19_results)
                {
                    ++__loop19_iteration;
                    var p = __tmp29.p;
                    if (cls.GetAllSuperClasses(false).Contains(p.Class)) //195:3
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
                                __out.AppendLine(); //196:93
                            }
                        }
                    }
                    else //197:3
                    {
                        string __tmp37Prefix = "// ERROR: redefined property '"; //198:1
                        string __tmp38Suffix = "' must be a property of an ancestor class"; //198:61
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
                                __out.AppendLine(); //198:102
                            }
                        }
                    }
                }
                string __tmp40Prefix = "public static readonly ModelProperty "; //201:1
                string __tmp41Suffix = "Property ="; //201:49
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
                        __out.AppendLine(); //201:59
                    }
                }
                string __tmp43Prefix = "    ModelProperty.Register(\""; //202:1
                string __tmp44Suffix = "Property));"; //202:339
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
                string __tmp46Line = "\", typeof("; //202:40
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
                string __tmp48Line = "), typeof("; //202:84
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
                string __tmp50Line = "), typeof("; //202:123
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
                string __tmp52Line = "Descriptor."; //202:168
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
                string __tmp54Line = "), new Lazy<global::MetaDslx.Core.MetaProperty>(() => "; //202:204
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
                string __tmp56Line = "Instance."; //202:293
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
                string __tmp58Line = "_"; //202:327
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
                        __out.AppendLine(); //202:350
                    }
                }
            }
            __out.AppendLine(); //204:1
            return __out.ToString();
        }

        public string GeneratePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //207:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //208:1
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
            string __tmp4Line = " "; //209:35
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
            string __tmp6Line = "."; //209:65
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
                    __out.AppendLine(); //209:77
                }
            }
            __out.Append("{"); //210:1
            __out.AppendLine(); //210:2
            __out.Append("    get "); //211:1
            __out.AppendLine(); //211:9
            __out.Append("    {"); //212:1
            __out.AppendLine(); //212:6
            string __tmp8Prefix = "        object result = this.MGet("; //213:1
            string __tmp9Suffix = "); "; //213:68
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
                    __out.AppendLine(); //213:71
                }
            }
            string __tmp11Prefix = "        if (result != null) return ("; //214:1
            string __tmp12Suffix = ")result;"; //214:71
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
                    __out.AppendLine(); //214:79
                }
            }
            string __tmp14Prefix = "        else return default("; //215:1
            string __tmp15Suffix = ");"; //215:63
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
                    __out.AppendLine(); //215:65
                }
            }
            __out.Append("    }"); //216:1
            __out.AppendLine(); //216:6
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //217:3
            {
                string __tmp17Prefix = "    set { this.MSet("; //218:1
                string __tmp18Suffix = ", value); }"; //218:54
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
                        __out.AppendLine(); //218:65
                    }
                }
            }
            __out.Append("}"); //220:1
            __out.AppendLine(); //220:2
            return __out.ToString();
        }

        public string GetCollectionConstructorParams(MetaProperty prop) //223:1
        {
            MetaCollectionType mct = prop.Type as MetaCollectionType; //224:2
            if (mct != null && mct.InnerType is MetaClass) //225:2
            {
                return "this, " + prop.CSharpFullDescriptorName(); //226:3
            }
            else //227:2
            {
                return ""; //228:3
            }
        }

        public string GenerateExpression(MetaExpression expr) //233:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //234:10
            if (expr is MetaBracketExpression) //235:2
            {
                __out.Append("("); //235:33
                __out.Append(GenerateExpression(((MetaBracketExpression)expr).Expression));
                __out.Append(")"); //235:71
            }
            else if (expr is MetaThisExpression) //236:2
            {
                __out.Append("(("); //236:30
                __out.Append(((MetaType)ModelContext.Current.Compiler.ResolutionProvider.GetCurrentTypeScopeOf((ModelObject)((MetaThisExpression)expr))).CSharpName());
                __out.Append(")this)"); //236:148
            }
            else if (expr is MetaNullExpression) //237:2
            {
                __out.Append("null"); //237:30
            }
            else if (expr is MetaTypeAsExpression) //238:2
            {
                __out.Append(GenerateExpression(((MetaTypeAsExpression)expr).Expression));
                __out.Append(" as "); //238:69
                __out.Append(((MetaTypeAsExpression)expr).TypeReference.CSharpName());
            }
            else if (expr is MetaTypeCastExpression) //239:2
            {
                __out.Append("("); //239:34
                __out.Append(((MetaTypeCastExpression)expr).TypeReference.CSharpName());
                __out.Append(")"); //239:68
                __out.Append(GenerateExpression(((MetaTypeCastExpression)expr).Expression));
            }
            else if (expr is MetaTypeCheckExpression) //240:2
            {
                __out.Append(GenerateExpression(((MetaTypeCheckExpression)expr).Expression));
                __out.Append(" is "); //240:72
                __out.Append(((MetaTypeCheckExpression)expr).TypeReference.CSharpName());
            }
            else if (expr is MetaTypeOfExpression) //241:2
            {
                __out.Append(GenerateTypeOf(((MetaTypeOfExpression)expr)));
            }
            else if (expr is MetaConditionalExpression) //242:2
            {
                __out.Append(GenerateExpression(((MetaConditionalExpression)expr).Condition));
                __out.Append(" ? "); //242:73
                __out.Append(GenerateExpression(((MetaConditionalExpression)expr).Then));
                __out.Append(" : "); //242:107
                __out.Append(GenerateExpression(((MetaConditionalExpression)expr).Else));
            }
            else if (expr is MetaConstantExpression) //243:2
            {
                __out.Append(GetCSharpValue(((MetaConstantExpression)expr).Value));
            }
            else if (expr is MetaIdentifierExpression) //244:2
            {
                __out.Append(GenerateIdentifierExpression(((MetaIdentifierExpression)expr)));
            }
            else if (expr is MetaMemberAccessExpression) //245:2
            {
                __out.Append(GenerateExpression(((MetaMemberAccessExpression)expr).Expression));
                __out.Append("."); //245:75
                __out.Append(((MetaMemberAccessExpression)expr).Name);
            }
            else if (expr is MetaFunctionCallExpression) //246:2
            {
                __out.Append(GenerateFunctionCall(((MetaFunctionCallExpression)expr)));
            }
            else if (expr is MetaIndexerExpression) //247:2
            {
                __out.Append(GenerateIndexerCall(((MetaIndexerExpression)expr)));
            }
            else if (expr is MetaOperatorExpression) //248:2
            {
                __out.Append(GenerateOperator(((MetaOperatorExpression)expr)));
            }
            else if (expr is MetaNewExpression) //249:2
            {
                __out.Append(((MetaNewExpression)expr).TypeReference.CSharpFullFactoryMethodName());
                __out.Append("("); //249:79
                __out.Append(GenerateNewPropertyInitializers(((MetaNewExpression)expr)));
                __out.Append(")"); //249:119
            }
            else if (expr is MetaNewCollectionExpression) //250:2
            {
                __out.Append("new List<Lazy<object>>() { "); //250:39
                __out.Append(GenerateNewCollectionValues(((MetaNewCollectionExpression)expr)));
                __out.Append(" }"); //250:101
            }
            else //251:2
            {
                __out.Append("***unknown expression type***"); //251:11
                __out.AppendLine(); //251:40
            }//252:2
            return __out.ToString();
        }

        public string GenerateIdentifierExpression(MetaIdentifierExpression expr) //255:1
        {
            StringBuilder __out = new StringBuilder();
            if (expr.Definition is MetaProperty) //256:2
            {
                string __tmp1Prefix = "(("; //257:1
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
                string __tmp4Line = ")this)."; //257:119
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
            else //258:2
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

        public bool SameFunction(MetaGlobalFunction mfunc1, MetaGlobalFunction mfunc2) //263:1
        {
            return mfunc1.Name == mfunc2.Name && ModelContext.Current.Compiler.TypeProvider.Equals((ModelObject)mfunc1.Type, (ModelObject)mfunc2.Type); //264:2
        }

        public string GenerateFunctionCall(MetaFunctionCallExpression call) //267:1
        {
            StringBuilder __out = new StringBuilder();
            if (call.Definition is MetaGlobalFunction && SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.TypeOf)) //268:2
            {
                __out.Append(GenerateTypeOf(call.Arguments[0]));
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.GetValueType)) //269:2
            {
                __out.Append("ModelContext.Current.Compiler.TypeProvider.GetTypeOf("); //269:89
                __out.Append(GenerateCallArguments(call, ""));
                __out.Append(")"); //269:175
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.GetReturnType)) //270:2
            {
                __out.Append("ModelContext.Current.Compiler.TypeProvider.GetReturnTypeOf("); //270:90
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //270:195
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.CurrentType)) //271:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.GetCurrentTypeScopeOf("); //271:88
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //271:205
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.TypeCheck)) //272:2
            {
                __out.Append("ModelContext.Current.Compiler.TypeProvider.TypeCheck("); //272:86
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //272:185
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Balance)) //273:2
            {
                __out.Append("ModelContext.Current.Compiler.TypeProvider.Balance("); //273:84
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //273:181
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Resolve1)) //274:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //274:85
                __out.Append("[]");
                __out.Append(" { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.NameOrType, "); //274:163
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //274:303
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Resolve2)) //275:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //275:85
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //275:163
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, ResolveKind.NameOrType, "); //275:218
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //275:285
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveType1)) //276:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //276:89
                __out.Append("[]");
                __out.Append(" { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Type, "); //276:167
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //276:301
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveType2)) //277:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //277:89
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //277:167
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, ResolveKind.Type, "); //277:222
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //277:283
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveName1)) //278:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //278:89
                __out.Append("[]");
                __out.Append(" { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, "); //278:167
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //278:301
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveName2)) //279:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //279:89
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //279:167
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, ResolveKind.Name, "); //279:222
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //279:283
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind1)) //280:2
            {
                __out.Append("ModelContext.Current.Compiler.BindingProvider.Bind(this, new ModelObject"); //280:82
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //280:160
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, new BindingInfo())"); //280:215
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind2)) //281:2
            {
                __out.Append("ModelContext.Current.Compiler.BindingProvider.Bind(this, "); //281:82
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new BindingInfo())"); //281:178
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind3)) //282:2
            {
                __out.Append("ModelContext.Current.Compiler.BindingProvider.Bind((ModelObject)"); //282:82
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ModelObject"); //282:185
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //282:208
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(" }, new BindingInfo())"); //282:263
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind4)) //283:2
            {
                __out.Append("ModelContext.Current.Compiler.BindingProvider.Bind((ModelObject)"); //283:82
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", "); //283:185
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new BindingInfo())"); //283:226
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.SelectOfType1)) //284:2
            {
                __out.Append("new object"); //284:90
                __out.Append("[]");
                __out.Append(" { "); //284:106
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }.Where(e => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(e) is "); //284:148
                __out.Append(GetTypeName(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //284:253
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.SelectOfType2)) //285:2
            {
                __out.Append("("); //285:90
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(").Where(e => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(e) is "); //285:130
                __out.Append(GetTypeName(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //285:234
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.SelectOfName1)) //286:2
            {
                __out.Append("new object"); //286:90
                __out.Append("[]");
                __out.Append(" { "); //286:106
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }.Where(e => ModelContext.Current.Compiler.NameProvider.GetNameOf((ModelObject)e) == "); //286:148
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //286:273
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.SelectOfName2)) //287:2
            {
                __out.Append("("); //287:90
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(").Where(e => ModelContext.Current.Compiler.NameProvider.GetNameOf((ModelObject)e) == "); //287:130
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //287:254
            }
            else //288:2
            {
                __out.Append(GenerateExpression(call.Expression));
                __out.Append("("); //288:44
                __out.Append(GenerateCallArguments(call, ""));
                __out.Append(")"); //288:78
            }
            return __out.ToString();
        }

        public string GenerateIndexerCall(MetaIndexerExpression call) //292:1
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

        public string GenerateTypeOf(object expr) //296:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //297:9
            if (expr is MetaPrimitiveType) //298:2
            {
                var __tmp2 = ((MetaPrimitiveType)expr).Name; //299:10
                __out.Append("	"); //300:1
                if (__tmp2 == "*none*") //300:3
                {
                    __out.Append("MetaInstance.None"); //300:18
                    __out.Append("	"); //301:1
                }
                else if (__tmp2 == "*error*") //301:3
                {
                    __out.Append("MetaInstance.Error"); //301:19
                    __out.Append("	"); //302:1
                }
                else if (__tmp2 == "*any*") //302:3
                {
                    __out.Append("MetaInstance.Any"); //302:17
                    __out.Append("	"); //303:1
                }
                else if (__tmp2 == "object") //303:3
                {
                    __out.Append("MetaInstance.Object"); //303:18
                    __out.Append("	"); //304:1
                }
                else if (__tmp2 == "string") //304:3
                {
                    __out.Append("MetaInstance.String"); //304:18
                    __out.Append("	"); //305:1
                }
                else if (__tmp2 == "int") //305:3
                {
                    __out.Append("MetaInstance.Int"); //305:15
                    __out.Append("	"); //306:1
                }
                else if (__tmp2 == "long") //306:3
                {
                    __out.Append("MetaInstance.Long"); //306:16
                    __out.Append("	"); //307:1
                }
                else if (__tmp2 == "float") //307:3
                {
                    __out.Append("MetaInstance.Float"); //307:17
                    __out.Append("	"); //308:1
                }
                else if (__tmp2 == "double") //308:3
                {
                    __out.Append("MetaInstance.Double"); //308:18
                    __out.Append("	"); //309:1
                }
                else if (__tmp2 == "byte") //309:3
                {
                    __out.Append("MetaInstance.Byte"); //309:16
                    __out.Append("	"); //310:1
                }
                else if (__tmp2 == "bool") //310:3
                {
                    __out.Append("MetaInstance.Bool"); //310:16
                    __out.Append("	"); //311:1
                }
                else if (__tmp2 == "void") //311:3
                {
                    __out.Append("MetaInstance.Void"); //311:16
                    __out.Append("	"); //312:1
                }
                else if (__tmp2 == "ModelObject") //312:3
                {
                    __out.Append("MetaInstance.ModelObject"); //312:23
                    __out.Append("	"); //313:1
                }
                else if (__tmp2 == "ModelObjectList") //313:3
                {
                    __out.Append("MetaInstance.ModelObjectList"); //313:27
                }//314:3
            }
            else if (expr is MetaTypeOfExpression) //315:2
            {
                __out.Append(GenerateTypeOf(((MetaTypeOfExpression)expr).TypeReference));
            }
            else if (expr is MetaClass) //316:2
            {
                __out.Append(((MetaClass)expr).CSharpFullDescriptorName());
                __out.Append(".MetaClass"); //316:54
            }
            else if (expr is MetaCollectionType) //317:2
            {
                __out.Append(((MetaCollectionType)expr).CSharpFullName());
            }
            else //318:2
            {
                __out.Append("***error***"); //318:11
            }//319:2
            return __out.ToString();
        }

        public string GenerateCallArguments(MetaBoundExpression call, string prefix) //322:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop20_results = 
                (from __loop20_var1 in __Enumerate((call).GetEnumerator()) //323:7
                from arg in __Enumerate((__loop20_var1.Arguments).GetEnumerator()) //323:13
                select new { __loop20_var1 = __loop20_var1, arg = arg}
                ).ToList(); //323:2
            int __loop20_iteration = 0;
            string delim = ""; //323:28
            foreach (var __tmp1 in __loop20_results)
            {
                ++__loop20_iteration;
                if (__loop20_iteration >= 2) //323:47
                {
                    delim = ", "; //323:47
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

        public string GenerateOperator(MetaOperatorExpression expr) //328:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //329:10
            if (expr is MetaUnaryExpression) //330:2
            {
                if (((MetaUnaryExpression)expr) is MetaPostIncrementAssignExpression || ((MetaUnaryExpression)expr) is MetaPostDecrementAssignExpression) //331:3
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
                else //333:3
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
            else if (expr is MetaBinaryExpression) //336:2
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
            }//338:2
            return __out.ToString();
        }

        public string GenerateNewPropertyInitializers(MetaNewExpression expr) //341:1
        {
            StringBuilder __out = new StringBuilder();
            if ((from __loop21_var1 in __Enumerate((expr).GetEnumerator()) //342:14
            from pi in __Enumerate((__loop21_var1.PropertyInitializers).GetEnumerator()) //342:20
            select new { __loop21_var1 = __loop21_var1, pi = pi}
            ).GetEnumerator().MoveNext()) //342:2
            {
                __out.Append("new List<ModelPropertyInitializer>() {"); //343:1
                var __loop22_results = 
                    (from __loop22_var1 in __Enumerate((expr).GetEnumerator()) //344:7
                    from pi in __Enumerate((__loop22_var1.PropertyInitializers).GetEnumerator()) //344:13
                    select new { __loop22_var1 = __loop22_var1, pi = pi}
                    ).ToList(); //344:2
                int __loop22_iteration = 0;
                string delim = ""; //344:38
                foreach (var __tmp1 in __loop22_results)
                {
                    ++__loop22_iteration;
                    if (__loop22_iteration >= 2) //344:57
                    {
                        delim = ", "; //344:57
                    }
                    var __loop22_var1 = __tmp1.__loop22_var1;
                    var pi = __tmp1.pi;
                    string __tmp2Prefix = string.Empty; 
                    string __tmp3Suffix = "))"; //345:132
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
                    string __tmp5Line = "new ModelPropertyInitializer("; //345:8
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
                    string __tmp7Line = ", new Lazy<object>(() => "; //345:77
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
                __out.Append("}"); //347:1
            }
            return __out.ToString();
        }

        public string GenerateNewCollectionValues(MetaNewCollectionExpression expr) //351:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((expr).GetEnumerator()) //352:7
                from v in __Enumerate((__loop23_var1.Values).GetEnumerator()) //352:13
                select new { __loop23_var1 = __loop23_var1, v = v}
                ).ToList(); //352:2
            int __loop23_iteration = 0;
            string delim = ""; //352:23
            foreach (var __tmp1 in __loop23_results)
            {
                ++__loop23_iteration;
                if (__loop23_iteration >= 2) //352:42
                {
                    delim = ", \n"; //352:42
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

        public string GetCSharpValue(object value) //357:1
        {
            if (value == null) //358:2
            {
                return "null"; //358:21
            }
            else if (value is bool && ((bool)value) == true) //359:2
            {
                return "true"; //359:51
            }
            else if (value is bool && ((bool)value) == false) //360:2
            {
                return "false"; //360:52
            }
            else if (value is string) //361:2
            {
                return "\"" + value.ToString() + "\""; //361:28
            }
            else if (value is MetaExpression) //362:2
            {
                return GenerateExpression((MetaExpression)value); //362:36
            }
            else //363:2
            {
                return value.ToString(); //363:7
            }
        }

        public string GetCSharpIdentifier(object value) //367:1
        {
            if (value == null) //368:2
            {
                return null; //369:3
            }
            if (value is MetaConstantExpression && ((MetaConstantExpression)value).Value != null) //371:2
            {
                return ((MetaConstantExpression)value).Value.ToString(); //372:3
            }
            else if (value is string) //373:2
            {
                return value.ToString(); //374:3
            }
            else //375:2
            {
                return null; //376:3
            }
        }

        public string GetCSharpOperator(MetaOperatorExpression expr) //380:1
        {
            var __tmp1 = expr; //381:9
            if (expr is MetaUnaryPlusExpression) //382:3
            {
                return "+"; //382:36
            }
            else if (expr is MetaNegateExpression) //383:3
            {
                return "-"; //383:33
            }
            else if (expr is MetaOnesComplementExpression) //384:3
            {
                return "~"; //384:41
            }
            else if (expr is MetaNotExpression) //385:3
            {
                return "!"; //385:30
            }
            else if (expr is MetaPostIncrementAssignExpression) //386:3
            {
                return "++"; //386:46
            }
            else if (expr is MetaPostDecrementAssignExpression) //387:3
            {
                return "--"; //387:46
            }
            else if (expr is MetaPreIncrementAssignExpression) //388:3
            {
                return "++"; //388:45
            }
            else if (expr is MetaPreDecrementAssignExpression) //389:3
            {
                return "--"; //389:45
            }
            else if (expr is MetaMultiplyExpression) //390:3
            {
                return "*"; //390:35
            }
            else if (expr is MetaDivideExpression) //391:3
            {
                return "/"; //391:33
            }
            else if (expr is MetaModuloExpression) //392:3
            {
                return "%"; //392:33
            }
            else if (expr is MetaAddExpression) //393:3
            {
                return "+"; //393:30
            }
            else if (expr is MetaSubtractExpression) //394:3
            {
                return "-"; //394:35
            }
            else if (expr is MetaLeftShiftExpression) //395:3
            {
                return "<<"; //395:36
            }
            else if (expr is MetaRightShiftExpression) //396:3
            {
                return ">>"; //396:37
            }
            else if (expr is MetaLessThanExpression) //397:3
            {
                return "<"; //397:35
            }
            else if (expr is MetaLessThanOrEqualExpression) //398:3
            {
                return "<="; //398:42
            }
            else if (expr is MetaGreaterThanExpression) //399:3
            {
                return ">"; //399:38
            }
            else if (expr is MetaGreaterThanOrEqualExpression) //400:3
            {
                return ">="; //400:45
            }
            else if (expr is MetaEqualExpression) //401:3
            {
                return "=="; //401:32
            }
            else if (expr is MetaNotEqualExpression) //402:3
            {
                return "!="; //402:35
            }
            else if (expr is MetaAndExpression) //403:3
            {
                return "&"; //403:30
            }
            else if (expr is MetaOrExpression) //404:3
            {
                return "|"; //404:29
            }
            else if (expr is MetaExclusiveOrExpression) //405:3
            {
                return "^"; //405:38
            }
            else if (expr is MetaAndAlsoExpression) //406:3
            {
                return "&&"; //406:34
            }
            else if (expr is MetaOrElseExpression) //407:3
            {
                return "||"; //407:33
            }
            else if (expr is MetaNullCoalescingExpression) //408:3
            {
                return "??"; //408:41
            }
            else if (expr is MetaMultiplyAssignExpression) //409:3
            {
                return "*="; //409:41
            }
            else if (expr is MetaDivideAssignExpression) //410:3
            {
                return "/="; //410:39
            }
            else if (expr is MetaModuloAssignExpression) //411:3
            {
                return "%="; //411:39
            }
            else if (expr is MetaAddAssignExpression) //412:3
            {
                return "+="; //412:36
            }
            else if (expr is MetaSubtractAssignExpression) //413:3
            {
                return "-="; //413:41
            }
            else if (expr is MetaLeftShiftAssignExpression) //414:3
            {
                return "<<="; //414:42
            }
            else if (expr is MetaRightShiftAssignExpression) //415:3
            {
                return ">>="; //415:43
            }
            else if (expr is MetaAndAssignExpression) //416:3
            {
                return "&="; //416:36
            }
            else if (expr is MetaExclusiveOrAssignExpression) //417:3
            {
                return "^="; //417:44
            }
            else if (expr is MetaOrAssignExpression) //418:3
            {
                return "|="; //418:35
            }
            else //419:3
            {
                return ""; //419:12
            }//420:2
        }

        public string GetTypeName(MetaExpression expr) //423:1
        {
            if (expr is MetaTypeOfExpression) //424:2
            {
                return ((MetaTypeOfExpression)expr).TypeReference.CSharpFullName(); //424:36
            }
            else //425:2
            {
                return null; //425:7
            }
        }

        public MetaSynthetizedPropertyInitializer GetSynthetizedInitializerFor(MetaClass cls, MetaProperty prop) //429:1
        {
            MetaSynthetizedPropertyInitializer lastInit = null; //430:2
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((cls).GetEnumerator()) //431:7
                from sup in __Enumerate((__loop24_var1.GetAllSuperClasses(true)).GetEnumerator()) //431:12
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //431:42
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //431:55
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaSynthetizedPropertyInitializer>() //431:69
                select new { __loop24_var1 = __loop24_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //431:2
            int __loop24_iteration = 0;
            foreach (var __tmp1 in __loop24_results)
            {
                ++__loop24_iteration;
                var __loop24_var1 = __tmp1.__loop24_var1;
                var sup = __tmp1.sup;
                var Constructor = __tmp1.Constructor;
                var Initializers = __tmp1.Initializers;
                var init = __tmp1.init;
                if (init.Property == prop) //432:3
                {
                    lastInit = init; //433:4
                }
            }
            return lastInit; //436:2
        }

        public string GenerateConstructorImpl(MetaModel model, MetaClass cls) //439:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public "; //440:1
            string __tmp2Suffix = "() "; //440:30
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
                    __out.AppendLine(); //440:33
                }
            }
            __out.Append("{"); //441:1
            __out.AppendLine(); //441:2
            var __loop25_results = 
                (from __loop25_var1 in __Enumerate((cls).GetEnumerator()) //442:8
                from prop in __Enumerate((__loop25_var1.GetAllProperties()).GetEnumerator()) //442:13
                select new { __loop25_var1 = __loop25_var1, prop = prop}
                ).ToList(); //442:3
            int __loop25_iteration = 0;
            foreach (var __tmp4 in __loop25_results)
            {
                ++__loop25_iteration;
                var __loop25_var1 = __tmp4.__loop25_var1;
                var prop = __tmp4.prop;
                MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //443:4
                if (synInit != null) //444:4
                {
                    if (prop.Kind != MetaPropertyKind.Derived) //445:5
                    {
                        if (ModelContext.Current.Compiler.TypeProvider.GetTypeOf(synInit.Value) is MetaCollectionType) //446:6
                        {
                            string __tmp5Prefix = "    this.MLazySet("; //447:1
                            string __tmp6Suffix = "));"; //447:112
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
                            string __tmp8Line = ", new Lazy<object>(() => "; //447:52
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
                                    __out.AppendLine(); //447:115
                                }
                            }
                        }
                        else //448:6
                        {
                            string __tmp10Prefix = "    this.MLazySet("; //449:1
                            string __tmp11Suffix = "));"; //449:112
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
                            string __tmp13Line = ", new Lazy<object>(() => "; //449:52
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
                                    __out.AppendLine(); //449:115
                                }
                            }
                        }
                    }
                    else //451:5
                    {
                        string __tmp15Prefix = "    this.MDerivedSet("; //452:1
                        string __tmp16Suffix = ");"; //452:98
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
                        string __tmp18Line = ", () => "; //452:55
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
                                __out.AppendLine(); //452:100
                            }
                        }
                    }
                }
                else //454:4
                {
                    if (prop.Type is MetaCollectionType) //455:5
                    {
                        if (prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) //456:6
                        {
                            string __tmp20Prefix = "    this.MSet("; //457:1
                            string __tmp21Suffix = "));"; //457:117
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
                            string __tmp23Line = ", new "; //457:48
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
                            string __tmp25Line = "("; //457:78
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
                                    __out.AppendLine(); //457:120
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //458:6
                        {
                            string __tmp27Prefix = "    this.MLazySet("; //459:1
                            string __tmp28Suffix = "(this)));"; //459:164
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
                            string __tmp30Line = ", new Lazy<object>(() => "; //459:52
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
                            string __tmp32Line = "."; //459:126
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
                            string __tmp34Line = "_"; //459:152
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
                                    __out.AppendLine(); //459:173
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Derived) //460:6
                        {
                            string __tmp36Prefix = "    this.MDerivedSet("; //461:1
                            string __tmp37Suffix = "(this));"; //461:150
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
                            string __tmp39Line = ", () => "; //461:55
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
                            string __tmp41Line = "."; //461:112
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
                            string __tmp43Line = "_"; //461:138
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
                                    __out.AppendLine(); //461:158
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Readonly) //462:6
                        {
                            string __tmp45Prefix = "    // Init "; //463:1
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
                            string __tmp48Line = " in "; //463:46
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
                            string __tmp50Line = "."; //463:99
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
                            string __tmp52Line = "_"; //463:118
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
                                    __out.AppendLine(); //463:137
                                }
                            }
                        }
                    }
                    else //465:5
                    {
                        if (prop.Kind == MetaPropertyKind.Lazy) //466:6
                        {
                            string __tmp54Prefix = "    this.MLazySet("; //467:1
                            string __tmp55Suffix = "(this)));"; //467:153
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
                            string __tmp57Line = ", new Lazy<object>(() => "; //467:52
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
                            string __tmp59Line = "."; //467:115
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
                            string __tmp61Line = "_"; //467:141
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
                                    __out.AppendLine(); //467:162
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Derived) //468:6
                        {
                            string __tmp63Prefix = "    this.MDerivedSet("; //469:1
                            string __tmp64Suffix = "(this));"; //469:139
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
                            string __tmp66Line = ", () => "; //469:55
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
                            string __tmp68Line = "."; //469:101
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
                            string __tmp70Line = "_"; //469:127
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
                                    __out.AppendLine(); //469:147
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Readonly) //470:6
                        {
                            string __tmp72Prefix = "    // Init "; //471:1
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
                            string __tmp75Line = " in "; //471:46
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
                            string __tmp77Line = "."; //471:88
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
                            string __tmp79Line = "_"; //471:107
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
                                    __out.AppendLine(); //471:126
                                }
                            }
                        }
                    }
                }
            }
            var __loop26_results = 
                (from __loop26_var1 in __Enumerate((cls).GetEnumerator()) //476:8
                from sup in __Enumerate((__loop26_var1.GetAllSuperClasses(true)).GetEnumerator()) //476:13
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //476:43
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //476:56
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaInheritedPropertyInitializer>() //476:70
                select new { __loop26_var1 = __loop26_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //476:3
            int __loop26_iteration = 0;
            foreach (var __tmp81 in __loop26_results)
            {
                ++__loop26_iteration;
                var __loop26_var1 = __tmp81.__loop26_var1;
                var sup = __tmp81.sup;
                var Constructor = __tmp81.Constructor;
                var Initializers = __tmp81.Initializers;
                var init = __tmp81.init;
                if (init.Object != null && init.Property != null) //477:4
                {
                    string __tmp82Prefix = "    this.MLazySetChild("; //478:1
                    string __tmp83Suffix = "));"; //478:165
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
                    string __tmp85Line = ", "; //478:64
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
                    string __tmp87Line = ", new Lazy<object>(() => "; //478:108
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
                            __out.AppendLine(); //478:168
                        }
                    }
                }
            }
            string __tmp89Prefix = "    "; //481:1
            string __tmp90Suffix = "(this);"; //481:85
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
            string __tmp92Line = "."; //481:47
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
            string __tmp94Line = "_"; //481:66
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
                    __out.AppendLine(); //481:92
                }
            }
            var __loop27_results = 
                (from __loop27_var1 in __Enumerate((cls).GetEnumerator()) //482:11
                from prop in __Enumerate((__loop27_var1.GetAllProperties()).GetEnumerator()) //482:16
                select new { __loop27_var1 = __loop27_var1, prop = prop}
                ).ToList(); //482:6
            int __loop27_iteration = 0;
            foreach (var __tmp96 in __loop27_results)
            {
                ++__loop27_iteration;
                var __loop27_var1 = __tmp96.__loop27_var1;
                var prop = __tmp96.prop;
                if (prop.Kind == MetaPropertyKind.Readonly) //483:4
                {
                    string __tmp97Prefix = "    if (!this.MIsSet("; //484:1
                    string __tmp98Suffix = "().\");"; //484:221
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
                    string __tmp100Line = ")) throw new ModelException(\"Readonly property "; //484:55
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
                    string __tmp102Line = "."; //484:122
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
                    string __tmp104Line = "."; //484:148
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
                    string __tmp106Line = "Property was not set in "; //484:160
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
                    string __tmp108Line = "_"; //484:202
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
                            __out.AppendLine(); //484:227
                        }
                    }
                }
            }
            __out.Append("    this.MMakeDefault();"); //487:1
            __out.AppendLine(); //487:25
            __out.Append("}"); //488:1
            __out.AppendLine(); //488:2
            return __out.ToString();
        }

        public string GetReturn(MetaOperation op) //491:1
        {
            if (op.ReturnType.CSharpName() == "void") //492:5
            {
                return ""; //493:3
            }
            else //494:2
            {
                return "return "; //495:3
            }
        }

        public string GenerateOperationImpl(MetaModel model, MetaOperation op) //499:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //500:1
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = ")"; //501:105
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
            string __tmp4Line = " "; //501:39
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
            string __tmp6Line = "."; //501:68
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
            string __tmp8Line = "("; //501:78
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
                    __out.AppendLine(); //501:106
                }
            }
            __out.Append("{"); //502:1
            __out.AppendLine(); //502:2
            string __tmp10Prefix = "    "; //503:1
            string __tmp11Suffix = ");"; //503:125
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
            string __tmp14Line = "."; //503:58
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
            string __tmp16Line = "_"; //503:83
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
            string __tmp18Line = "("; //503:93
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
                    __out.AppendLine(); //503:127
                }
            }
            __out.Append("}"); //504:1
            __out.AppendLine(); //504:2
            return __out.ToString();
        }

        public string GetSuperClasses(MetaClass cls) //507:1
        {
            string result = ""; //508:2
            var __loop28_results = 
                (from __loop28_var1 in __Enumerate((cls).GetEnumerator()) //509:10
                from sup in __Enumerate((__loop28_var1.SuperClasses).GetEnumerator()) //509:15
                select new { __loop28_var1 = __loop28_var1, sup = sup}
                ).ToList(); //509:5
            int __loop28_iteration = 0;
            string delim = ""; //509:33
            foreach (var __tmp1 in __loop28_results)
            {
                ++__loop28_iteration;
                if (__loop28_iteration >= 2) //509:52
                {
                    delim = ", "; //509:52
                }
                var __loop28_var1 = __tmp1.__loop28_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpFullName(); //510:3
            }
            return result; //512:2
        }

        public string GetAllSuperClasses(MetaClass cls) //515:1
        {
            string result = ""; //516:2
            var __loop29_results = 
                (from __loop29_var1 in __Enumerate((cls).GetEnumerator()) //517:10
                from sup in __Enumerate((__loop29_var1.GetAllSuperClasses(false)).GetEnumerator()) //517:15
                select new { __loop29_var1 = __loop29_var1, sup = sup}
                ).ToList(); //517:5
            int __loop29_iteration = 0;
            string delim = ""; //517:46
            foreach (var __tmp1 in __loop29_results)
            {
                ++__loop29_iteration;
                if (__loop29_iteration >= 2) //517:65
                {
                    delim = ", "; //517:65
                }
                var __loop29_var1 = __tmp1.__loop29_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpFullName(); //518:3
            }
            return result; //520:2
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //523:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public static class "; //524:1
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
                    __out.AppendLine(); //524:51
                }
            }
            __out.Append("{"); //525:1
            __out.AppendLine(); //525:2
            string __tmp4Prefix = "    static "; //526:1
            string __tmp5Suffix = "Descriptor()"; //526:24
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
                    __out.AppendLine(); //526:36
                }
            }
            __out.Append("    {"); //527:1
            __out.AppendLine(); //527:6
            var __loop30_results = 
                (from __loop30_var1 in __Enumerate((model).GetEnumerator()) //528:11
                from Namespace in __Enumerate((__loop30_var1.Namespace).GetEnumerator()) //528:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //528:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //528:43
                select new { __loop30_var1 = __loop30_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //528:6
            int __loop30_iteration = 0;
            foreach (var __tmp7 in __loop30_results)
            {
                ++__loop30_iteration;
                var __loop30_var1 = __tmp7.__loop30_var1;
                var Namespace = __tmp7.Namespace;
                var Declarations = __tmp7.Declarations;
                var cls = __tmp7.cls;
                string __tmp8Prefix = "        "; //529:1
                string __tmp9Suffix = ".StaticInit();"; //529:27
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
                        __out.AppendLine(); //529:41
                    }
                }
            }
            __out.Append("    }"); //531:1
            __out.AppendLine(); //531:6
            __out.AppendLine(); //532:1
            __out.Append("    internal static void StaticInit()"); //533:1
            __out.AppendLine(); //533:38
            __out.Append("    {"); //534:1
            __out.AppendLine(); //534:6
            __out.Append("    }"); //535:1
            __out.AppendLine(); //535:6
            __out.AppendLine(); //536:1
            string __tmp11Prefix = "	public const string Uri = \""; //537:1
            string __tmp12Suffix = "\";"; //537:40
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
                    __out.AppendLine(); //537:42
                }
            }
            __out.AppendLine(); //538:1
            var __loop31_results = 
                (from __loop31_var1 in __Enumerate((model).GetEnumerator()) //539:11
                from Namespace in __Enumerate((__loop31_var1.Namespace).GetEnumerator()) //539:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //539:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //539:43
                select new { __loop31_var1 = __loop31_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //539:6
            int __loop31_iteration = 0;
            foreach (var __tmp14 in __loop31_results)
            {
                ++__loop31_iteration;
                var __loop31_var1 = __tmp14.__loop31_var1;
                var Namespace = __tmp14.Namespace;
                var Declarations = __tmp14.Declarations;
                var cls = __tmp14.cls;
                string __tmp15Prefix = "    "; //540:1
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
                        __out.AppendLine(); //540:34
                    }
                }
            }
            __out.Append("}"); //542:1
            __out.AppendLine(); //542:2
            __out.AppendLine(); //543:1
            return __out.ToString();
        }

        public string GenerateMetaModelClass(MetaClass cls) //547:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //548:1
            string __tmp1Prefix = "public static class "; //549:1
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
                    __out.AppendLine(); //549:39
                }
            }
            __out.Append("{"); //550:1
            __out.AppendLine(); //550:2
            __out.Append("    internal static void StaticInit()"); //551:1
            __out.AppendLine(); //551:38
            __out.Append("    {"); //552:1
            __out.AppendLine(); //552:6
            __out.Append("    }"); //553:1
            __out.AppendLine(); //553:6
            __out.AppendLine(); //554:1
            string __tmp4Prefix = "    static "; //555:1
            string __tmp5Suffix = "()"; //555:30
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
                    __out.AppendLine(); //555:32
                }
            }
            __out.Append("    {"); //556:1
            __out.AppendLine(); //556:6
            string __tmp7Prefix = "        "; //557:1
            string __tmp8Suffix = ".StaticInit();"; //557:47
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
                    __out.AppendLine(); //557:61
                }
            }
            __out.Append("    }"); //558:1
            __out.AppendLine(); //558:6
            __out.AppendLine(); //559:1
            if (cls.CSharpName() == "MetaClass") //560:2
            {
                __out.Append("    public static global::MetaDslx.Core.MetaClass _MetaClass"); //561:1
                __out.AppendLine(); //561:61
            }
            else //562:2
            {
                __out.Append("    public static global::MetaDslx.Core.MetaClass MetaClass"); //563:1
                __out.AppendLine(); //563:60
            }
            __out.Append("    {"); //565:1
            __out.AppendLine(); //565:6
            string __tmp10Prefix = "        get { return "; //566:1
            string __tmp11Suffix = "; }"; //566:52
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
                    __out.AppendLine(); //566:55
                }
            }
            __out.Append("    }"); //567:1
            __out.AppendLine(); //567:6
            __out.AppendLine(); //568:1
            var __loop32_results = 
                (from __loop32_var1 in __Enumerate((cls).GetEnumerator()) //569:11
                from prop in __Enumerate((__loop32_var1.Properties).GetEnumerator()) //569:16
                select new { __loop32_var1 = __loop32_var1, prop = prop}
                ).ToList(); //569:6
            int __loop32_iteration = 0;
            foreach (var __tmp13 in __loop32_results)
            {
                ++__loop32_iteration;
                var __loop32_var1 = __tmp13.__loop32_var1;
                var prop = __tmp13.prop;
                string __tmp14Prefix = "    "; //570:1
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
                        __out.AppendLine(); //570:56
                    }
                }
            }
            __out.Append("}"); //572:1
            __out.AppendLine(); //572:2
            return __out.ToString();
        }

        public string GenerateModelConstant(MetaModel model, MetaConstant mconst) //576:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public static readonly "; //577:1
            string __tmp2Suffix = ";"; //577:68
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
            string __tmp4Line = " "; //577:54
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
                    __out.AppendLine(); //577:69
                }
            }
            return __out.ToString();
        }

        public string GenerateModelFunction(MetaModel model, MetaGlobalFunction mfunc) //580:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public static readonly "; //581:1
            string __tmp2Suffix = ";"; //581:87
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(MetaInstance.MetaGlobalFunction.CSharpFullName());
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
            string __tmp4Line = " "; //581:74
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
                    __out.AppendLine(); //581:88
                }
            }
            return __out.ToString();
        }

        public string GenerateModelConstantImpl(MetaModel model, MetaConstant mconst, Dictionary<ModelObject,string> mobjToTmp) //584:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = ";"; //585:51
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
            string __tmp4Line = " = "; //585:14
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
                    __out.AppendLine(); //585:52
                }
            }
            return __out.ToString();
        }

        public string GenerateModelFunctionImpl(MetaModel model, MetaGlobalFunction mfunc, Dictionary<ModelObject,string> mobjToTmp) //588:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = "();"; //589:131
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
            string __tmp4Line = " = "; //589:65
            __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(MetaInstance.MetaGlobalFunction.CSharpFullFactoryMethodName());
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
                    __out.AppendLine(); //589:134
                }
            }
            return __out.ToString();
        }

        public string GenerateMetaModelInstance(MetaModel model) //593:1
        {
            StringBuilder __out = new StringBuilder();
            Dictionary<ModelObject,string> mobjToTmp = new Dictionary<ModelObject,string>(); //594:2
            string __tmp1Prefix = "public static class "; //595:1
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
                    __out.AppendLine(); //595:50
                }
            }
            __out.Append("{"); //596:1
            __out.AppendLine(); //596:2
            __out.Append("    private static global::MetaDslx.Core.Model model;"); //597:1
            __out.AppendLine(); //597:54
            __out.AppendLine(); //598:1
            __out.Append("    public static global::MetaDslx.Core.Model Model"); //599:1
            __out.AppendLine(); //599:52
            __out.Append("    {"); //600:1
            __out.AppendLine(); //600:6
            string __tmp4Prefix = "        get { return "; //601:1
            string __tmp5Suffix = "Instance.model; }"; //601:34
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
                    __out.AppendLine(); //601:51
                }
            }
            __out.Append("    }"); //602:1
            __out.AppendLine(); //602:6
            __out.AppendLine(); //603:1
            __out.Append("    public static readonly global::MetaDslx.Core.MetaModel Meta;"); //604:1
            __out.AppendLine(); //604:65
            __out.AppendLine(); //605:1
            var __loop33_results = 
                (from __loop33_var1 in __Enumerate((model).GetEnumerator()) //606:11
                from Namespace in __Enumerate((__loop33_var1.Namespace).GetEnumerator()) //606:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //606:29
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //606:43
                select new { __loop33_var1 = __loop33_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //606:6
            int __loop33_iteration = 0;
            foreach (var __tmp7 in __loop33_results)
            {
                ++__loop33_iteration;
                var __loop33_var1 = __tmp7.__loop33_var1;
                var Namespace = __tmp7.Namespace;
                var Declarations = __tmp7.Declarations;
                var c = __tmp7.c;
                string __tmp8Prefix = "    "; //607:1
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
                        __out.AppendLine(); //607:38
                    }
                }
            }
            __out.AppendLine(); //609:1
            string __tmp11Prefix = "	"; //610:1
            string __tmp12Suffix = string.Empty; 
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(GenerateModelObjectInstanceDeclaration(((ModelObject)model).GetRootNamespace(), mobjToTmp));
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
                    __out.AppendLine(); //610:94
                }
            }
            __out.AppendLine(); //611:1
            var __loop34_results = 
                (from __loop34_var1 in __Enumerate((model).GetEnumerator()) //612:8
                from Namespace in __Enumerate((__loop34_var1.Namespace).GetEnumerator()) //612:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //612:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //612:40
                from prop in __Enumerate((cls.Properties).GetEnumerator()) //612:63
                where !HasBuiltInName((ModelObject)prop) //612:79
                select new { __loop34_var1 = __loop34_var1, Namespace = Namespace, Declarations = Declarations, cls = cls, prop = prop}
                ).ToList(); //612:3
            int __loop34_iteration = 0;
            foreach (var __tmp14 in __loop34_results)
            {
                ++__loop34_iteration;
                var __loop34_var1 = __tmp14.__loop34_var1;
                var Namespace = __tmp14.Namespace;
                var Declarations = __tmp14.Declarations;
                var cls = __tmp14.cls;
                var prop = __tmp14.prop;
                string __tmp15Prefix = "	public static readonly global::MetaDslx.Core.MetaProperty "; //613:1
                string __tmp16Suffix = "Property;"; //613:90
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(cls.CSharpName());
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
                string __tmp18Line = "_"; //613:78
                __out.Append(__tmp18Line);
                StringBuilder __tmp19 = new StringBuilder();
                __tmp19.Append(prop.Name);
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
                        __out.AppendLine(); //613:99
                    }
                }
            }
            __out.AppendLine(); //615:1
            string __tmp20Prefix = "    static "; //616:1
            string __tmp21Suffix = "()"; //616:41
            StringBuilder __tmp22 = new StringBuilder();
            __tmp22.Append(model.CSharpInstancesName());
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
                    __out.AppendLine(); //616:43
                }
            }
            __out.Append("    {"); //617:1
            __out.AppendLine(); //617:6
            string __tmp23Prefix = "		"; //618:1
            string __tmp24Suffix = ".StaticInit();"; //618:33
            StringBuilder __tmp25 = new StringBuilder();
            __tmp25.Append(model.CSharpDescriptorName());
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
                    __out.AppendLine(); //618:47
                }
            }
            string __tmp26Prefix = "		"; //619:1
            string __tmp27Suffix = ".model = new global::MetaDslx.Core.Model();"; //619:32
            StringBuilder __tmp28 = new StringBuilder();
            __tmp28.Append(model.CSharpInstancesName());
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
                    __out.AppendLine(); //619:75
                }
            }
            string __tmp29Prefix = "   		using (new ModelContextScope("; //620:1
            string __tmp30Suffix = ".model))"; //620:64
            StringBuilder __tmp31 = new StringBuilder();
            __tmp31.Append(model.CSharpInstancesName());
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
                    __out.AppendLine(); //620:72
                }
            }
            __out.Append("		{"); //621:1
            __out.AppendLine(); //621:4
            var __loop35_results = 
                (from __loop35_var1 in __Enumerate((model).GetEnumerator()) //622:13
                from Namespace in __Enumerate((__loop35_var1.Namespace).GetEnumerator()) //622:20
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //622:31
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //622:45
                select new { __loop35_var1 = __loop35_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //622:8
            int __loop35_iteration = 0;
            foreach (var __tmp32 in __loop35_results)
            {
                ++__loop35_iteration;
                var __loop35_var1 = __tmp32.__loop35_var1;
                var Namespace = __tmp32.Namespace;
                var Declarations = __tmp32.Declarations;
                var c = __tmp32.c;
                string __tmp33Prefix = "            "; //623:1
                string __tmp34Suffix = string.Empty; 
                StringBuilder __tmp35 = new StringBuilder();
                __tmp35.Append(GenerateModelConstantImpl(model, c, mobjToTmp));
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
                        __out.AppendLine(); //623:61
                    }
                }
            }
            __out.AppendLine(); //625:1
            string __tmp36Prefix = "			"; //626:1
            string __tmp37Suffix = string.Empty; 
            StringBuilder __tmp38 = new StringBuilder();
            __tmp38.Append(GenerateModelObjectInstance(((ModelObject)model).GetRootNamespace(), mobjToTmp));
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
                    __out.AppendLine(); //626:85
                }
            }
            __out.AppendLine(); //627:1
            string __tmp39Prefix = "			"; //628:1
            string __tmp40Suffix = string.Empty; 
            StringBuilder __tmp41 = new StringBuilder();
            __tmp41.Append(GenerateModelObjectInstanceInitializer(((ModelObject)model).GetRootNamespace(), mobjToTmp));
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
                    __out.AppendLine(); //628:96
                }
            }
            __out.AppendLine(); //629:1
            __out.Append("            foreach (var mo in ModelContext.Current.Model.Instances)"); //630:1
            __out.AppendLine(); //630:69
            __out.Append("            {"); //631:1
            __out.AppendLine(); //631:14
            __out.Append("                mo.MEvalLazyValues();"); //632:1
            __out.AppendLine(); //632:38
            __out.Append("            }"); //633:1
            __out.AppendLine(); //633:14
            __out.Append("		}"); //634:1
            __out.AppendLine(); //634:4
            __out.Append("    }"); //635:1
            __out.AppendLine(); //635:6
            __out.Append("}"); //636:1
            __out.AppendLine(); //636:2
            return __out.ToString();
        }

        public string RegisterModelObject(ModelObject mobj, Dictionary<ModelObject,string> mobjToTmp, string name) //639:1
        {
            if (!mobjToTmp.ContainsKey(mobj)) //640:2
            {
                string tmpName = name; //641:3
                mobjToTmp.Add(mobj, tmpName); //642:3
                return tmpName; //643:3
            }
            else //644:2
            {
                return mobjToTmp[mobj]; //645:3
            }
        }

        public bool HasBuiltInName(ModelObject mobj) //649:1
        {
            MetaAnnotatedElement mannot = mobj as MetaAnnotatedElement; //650:2
            if (mannot != null && !(mobj is MetaConstant)) //651:2
            {
                var __loop36_results = 
                    (from __loop36_var1 in __Enumerate((mannot).GetEnumerator()) //652:8
                    from a in __Enumerate((__loop36_var1.Annotations).GetEnumerator()) //652:16
                    from p in __Enumerate((a.Properties).GetEnumerator()) //652:31
                    where a.Name == "BuiltInName" && p.Name == "Name" //652:44
                    select new { __loop36_var1 = __loop36_var1, a = a, p = p}
                    ).ToList(); //652:3
                int __loop36_iteration = 0;
                foreach (var __tmp1 in __loop36_results)
                {
                    ++__loop36_iteration;
                    var __loop36_var1 = __tmp1.__loop36_var1;
                    var a = __tmp1.a;
                    var p = __tmp1.p;
                    return true; //653:4
                }
            }
            MetaDeclaration mdecl = mobj as MetaDeclaration; //656:2
            if (mdecl != null && !(mdecl is MetaOperation) && !(mdecl is MetaConstant)) //657:2
            {
                return true; //658:3
            }
            return false; //660:2
        }

        public string GetInstanceName(ModelObject mobj) //663:1
        {
            MetaAnnotatedElement mannot = mobj as MetaAnnotatedElement; //664:2
            if (mannot != null && !(mobj is MetaConstant)) //665:2
            {
                var __loop37_results = 
                    (from __loop37_var1 in __Enumerate((mannot).GetEnumerator()) //666:8
                    from a in __Enumerate((__loop37_var1.Annotations).GetEnumerator()) //666:16
                    from p in __Enumerate((a.Properties).GetEnumerator()) //666:31
                    where a.Name == "BuiltInName" && p.Name == "Name" //666:44
                    select new { __loop37_var1 = __loop37_var1, a = a, p = p}
                    ).ToList(); //666:3
                int __loop37_iteration = 0;
                foreach (var __tmp1 in __loop37_results)
                {
                    ++__loop37_iteration;
                    var __loop37_var1 = __tmp1.__loop37_var1;
                    var a = __tmp1.a;
                    var p = __tmp1.p;
                    return GetCSharpIdentifier(p.Value); //667:4
                }
            }
            MetaDeclaration mdecl = mobj as MetaDeclaration; //670:2
            if (mdecl != null && !(mdecl is MetaOperation) && !(mobj is MetaConstant)) //671:2
            {
                return mdecl.CSharpInstanceName(); //672:3
            }
            MetaProperty mprop = mobj as MetaProperty; //674:2
            if (mprop != null) //675:2
            {
                return mprop.CSharpInstanceName(); //676:3
            }
            return null; //678:2
        }

        public string RegisterModelObject(ModelObject mobj, Dictionary<ModelObject,string> mobjToTmp) //681:1
        {
            if (!mobjToTmp.ContainsKey(mobj)) //682:2
            {
                string name = GetInstanceName(mobj); //683:3
                if (name == null) //684:3
                {
                    name = "tmp" + NextCounter(); //685:4
                }
                mobjToTmp.Add(mobj, name); //687:3
                return name; //688:3
            }
            else //689:2
            {
                return null; //690:3
            }
        }

        public string GenerateModelObjectInstanceDeclaration(ModelObject mobj, Dictionary<ModelObject,string> mobjToTmp) //694:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //695:2
            {
                if (!Instances.Contains(mobj)) //696:3
                {
                }
                else //697:3
                {
                    if (HasBuiltInName(mobj)) //698:4
                    {
                        string tmpName = RegisterModelObject(mobj, mobjToTmp); //699:5
                        if (tmpName != null) //700:5
                        {
                            if (tmpName.StartsWith("tmp")) //701:6
                            {
                            }
                            else //702:6
                            {
                                string __tmp1Prefix = "public static readonly global::MetaDslx.Core."; //703:1
                                string __tmp2Suffix = ";"; //703:86
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
                                string __tmp4Line = " "; //703:76
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
                                        __out.AppendLine(); //703:87
                                    }
                                }
                            }
                        }
                    }
                    var __loop38_results = 
                        (from __loop38_var1 in __Enumerate((mobj).GetEnumerator()) //707:9
                        from child in __Enumerate((__loop38_var1.MChildren).GetEnumerator()) //707:15
                        select new { __loop38_var1 = __loop38_var1, child = child}
                        ).ToList(); //707:4
                    int __loop38_iteration = 0;
                    foreach (var __tmp6 in __loop38_results)
                    {
                        ++__loop38_iteration;
                        var __loop38_var1 = __tmp6.__loop38_var1;
                        var child = __tmp6.child;
                        string __tmp7Prefix = string.Empty;
                        string __tmp8Suffix = string.Empty;
                        StringBuilder __tmp9 = new StringBuilder();
                        __tmp9.Append(GenerateModelObjectInstanceDeclaration(child, mobjToTmp));
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
                                __out.AppendLine(); //708:59
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstance(ModelObject mobj, Dictionary<ModelObject,string> mobjToTmp) //714:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //715:2
            {
                if (!Instances.Contains(mobj)) //716:3
                {
                    string metaClassName = mobj.MMetaClass.Name; //717:4
                    if (mobj is MetaDeclaration || mobj is MetaProperty) //718:4
                    {
                        if (mobj is MetaProperty) //719:5
                        {
                            string tmpName = RegisterModelObject(mobj, mobjToTmp, ((MetaProperty)mobj).CSharpInstanceName()); //720:2
                        }
                        else //721:5
                        {
                            string tmpName = RegisterModelObject(mobj, mobjToTmp, ((MetaDeclaration)mobj).CSharpInstanceName()); //722:2
                        }
                    }
                    else //724:4
                    {
                        string __tmp1Prefix = "// OMITTED: "; //725:1
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
                                __out.AppendLine(); //725:28
                            }
                        }
                    }
                }
                else //727:3
                {
                    string tmpName = null; //728:4
                    if (mobjToTmp.ContainsKey(mobj)) //729:4
                    {
                        tmpName = mobjToTmp[mobj];
                    }
                    else //731:4
                    {
                        tmpName = RegisterModelObject(mobj, mobjToTmp);
                    }
                    if (tmpName != null) //734:4
                    {
                        if (tmpName.StartsWith("tmp")) //735:5
                        {
                            string __tmp4Prefix = "global::MetaDslx.Core."; //736:1
                            string __tmp5Suffix = "();"; //736:145
                            StringBuilder __tmp6 = new StringBuilder();
                            __tmp6.Append(mobj.MMetaClass.CSharpName());
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
                            string __tmp7Line = " "; //736:53
                            __out.Append(__tmp7Line);
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
                                    __out.Append(__tmp8Line);
                                }
                            }
                            string __tmp9Line = " = global::MetaDslx.Core.MetaFactory.Instance.Create"; //736:63
                            __out.Append(__tmp9Line);
                            StringBuilder __tmp10 = new StringBuilder();
                            __tmp10.Append(mobj.MMetaClass.CSharpName());
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
                                    __out.Append(__tmp5Suffix);
                                    __out.AppendLine(); //736:148
                                }
                            }
                        }
                        else //737:5
                        {
                            string __tmp11Prefix = string.Empty; 
                            string __tmp12Suffix = "();"; //738:92
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
                            string __tmp14Line = " = global::MetaDslx.Core.MetaFactory.Instance.Create"; //738:10
                            __out.Append(__tmp14Line);
                            StringBuilder __tmp15 = new StringBuilder();
                            __tmp15.Append(mobj.MMetaClass.CSharpName());
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
                                    __out.AppendLine(); //738:95
                                }
                            }
                        }
                        if (mobj is MetaModel) //740:5
                        {
                            string __tmp16Prefix = "Meta = "; //741:1
                            string __tmp17Suffix = ";"; //741:17
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
                                    __out.Append(__tmp16Prefix);
                                    __out.Append(__tmp18Line);
                                    __out.Append(__tmp17Suffix);
                                    __out.AppendLine(); //741:18
                                }
                            }
                        }
                        var __loop39_results = 
                            (from __loop39_var1 in __Enumerate((mobj).GetEnumerator()) //743:10
                            from child in __Enumerate((__loop39_var1.MChildren).GetEnumerator()) //743:16
                            select new { __loop39_var1 = __loop39_var1, child = child}
                            ).ToList(); //743:5
                        int __loop39_iteration = 0;
                        foreach (var __tmp19 in __loop39_results)
                        {
                            ++__loop39_iteration;
                            var __loop39_var1 = __tmp19.__loop39_var1;
                            var child = __tmp19.child;
                            string __tmp20Prefix = string.Empty;
                            string __tmp21Suffix = string.Empty;
                            StringBuilder __tmp22 = new StringBuilder();
                            __tmp22.Append(GenerateModelObjectInstance(child, mobjToTmp));
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
                                    __out.AppendLine(); //744:48
                                }
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceInitializer(ModelObject mobj, Dictionary<ModelObject,string> mobjToTmp) //751:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //752:2
            {
                if (!Instances.Contains(mobj)) //753:3
                {
                }
                else //754:3
                {
                    var __loop40_results = 
                        (from __loop40_var1 in __Enumerate((mobj).GetEnumerator()) //755:9
                        from prop in __Enumerate((__loop40_var1.MGetAllProperties()).GetEnumerator()) //755:15
                        select new { __loop40_var1 = __loop40_var1, prop = prop}
                        ).ToList(); //755:4
                    int __loop40_iteration = 0;
                    foreach (var __tmp1 in __loop40_results)
                    {
                        ++__loop40_iteration;
                        var __loop40_var1 = __tmp1.__loop40_var1;
                        var prop = __tmp1.prop;
                        if (prop.MetaProperty != null && prop.MetaProperty.Kind != MetaPropertyKind.Derived) //756:5
                        {
                            object propValue = mobj.MGet(prop); //757:6
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
                                    __out.AppendLine(); //758:69
                                }
                            }
                        }
                    }
                    var __loop41_results = 
                        (from __loop41_var1 in __Enumerate((mobj).GetEnumerator()) //761:9
                        from child in __Enumerate((__loop41_var1.MChildren).GetEnumerator()) //761:15
                        select new { __loop41_var1 = __loop41_var1, child = child}
                        ).ToList(); //761:4
                    int __loop41_iteration = 0;
                    foreach (var __tmp5 in __loop41_results)
                    {
                        ++__loop41_iteration;
                        var __loop41_var1 = __tmp5.__loop41_var1;
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
                                __out.AppendLine(); //762:59
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectPropertyValue(ModelObject mobj, ModelProperty prop, object value, Dictionary<ModelObject,string> mobjToTmp) //768:1
        {
            StringBuilder __out = new StringBuilder();
            string tmpName = mobjToTmp[mobj]; //769:2
            string propDeclName = "global::" + prop.DeclaringType.FullName.Replace("+", ".") + "." + prop.DeclaredName; //770:2
            if (!prop.IsCollection) //771:2
            {
                string __tmp1Prefix = "((ModelObject)"; //772:1
                string __tmp2Suffix = ");"; //772:47
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
                string __tmp4Line = ").MUnSet("; //772:24
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
                        __out.AppendLine(); //772:49
                    }
                }
            }
            ModelObject moValue = value as ModelObject; //774:2
            if (value == null) //775:2
            {
                string __tmp6Prefix = "((ModelObject)"; //776:1
                string __tmp7Suffix = ", new Lazy<object>(() => null));"; //776:49
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
                string __tmp9Line = ").MLazyAdd("; //776:24
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
                        __out.AppendLine(); //776:81
                    }
                }
            }
            else if (value is string) //777:2
            {
                string __tmp11Prefix = "((ModelObject)"; //778:1
                string __tmp12Suffix = "\"));"; //778:82
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
                string __tmp14Line = ").MLazyAdd("; //778:24
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
                string __tmp16Line = ", new Lazy<object>(() => \""; //778:49
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
                        __out.AppendLine(); //778:86
                    }
                }
            }
            else if (value is bool) //779:2
            {
                string __tmp18Prefix = "((ModelObject)"; //780:1
                string __tmp19Suffix = "));"; //780:102
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
                string __tmp21Line = ").MLazyAdd("; //780:24
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
                string __tmp23Line = ", new Lazy<object>(() => "; //780:49
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
                        __out.AppendLine(); //780:105
                    }
                }
            }
            else if (value.GetType().IsPrimitive) //781:2
            {
                string __tmp25Prefix = "((ModelObject)"; //782:1
                string __tmp26Suffix = "));"; //782:92
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
                string __tmp28Line = ").MLazyAdd("; //782:24
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
                string __tmp30Line = ", new Lazy<object>(() => "; //782:49
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
                        __out.AppendLine(); //782:95
                    }
                }
            }
            else if (MetaBuiltInTypes.Types.Contains(value)) //783:2
            {
                string __tmp32Prefix = "((ModelObject)"; //784:1
                string __tmp33Suffix = "));"; //784:97
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
                string __tmp35Line = ").MLazyAdd("; //784:24
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
                string __tmp37Line = ", new Lazy<object>(() => "; //784:49
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
                        __out.AppendLine(); //784:100
                    }
                }
            }
            else if (value is MetaPrimitiveType) //785:2
            {
                string __tmp39Prefix = "((ModelObject)"; //786:1
                string __tmp40Suffix = "));"; //786:97
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
                string __tmp42Line = ").MLazyAdd("; //786:24
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
                string __tmp44Line = ", new Lazy<object>(() => "; //786:49
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
                        __out.AppendLine(); //786:100
                    }
                }
            }
            else if (value is Enum) //787:2
            {
                string __tmp46Prefix = "((ModelObject)"; //788:1
                string __tmp47Suffix = "));"; //788:97
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
                string __tmp49Line = ").MLazyAdd("; //788:24
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
                string __tmp51Line = ", new Lazy<object>(() => "; //788:49
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
                        __out.AppendLine(); //788:100
                    }
                }
            }
            else if (moValue != null) //789:2
            {
                if (mobjToTmp.ContainsKey(moValue)) //790:3
                {
                    string __tmp53Prefix = "((ModelObject)"; //791:1
                    string __tmp54Suffix = "));"; //791:94
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
                    string __tmp56Line = ").MLazyAdd("; //791:24
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
                    string __tmp58Line = ", new Lazy<object>(() => "; //791:49
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
                            __out.AppendLine(); //791:97
                        }
                    }
                }
                else //792:3
                {
                    string __tmp60Prefix = string.Empty;
                    string __tmp61Suffix = string.Empty;
                    StringBuilder __tmp62 = new StringBuilder();
                    __tmp62.Append(GenerateModelObjectInstance(moValue, mobjToTmp));
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
                            __out.AppendLine(); //793:50
                        }
                    }
                    string __tmp63Prefix = string.Empty;
                    string __tmp64Suffix = string.Empty;
                    StringBuilder __tmp65 = new StringBuilder();
                    __tmp65.Append(GenerateModelObjectInstanceInitializer(moValue, mobjToTmp));
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
                            __out.Append(__tmp64Suffix);
                            __out.AppendLine(); //794:61
                        }
                    }
                    if (mobjToTmp.ContainsKey(moValue)) //795:4
                    {
                        string tmpValueName = mobjToTmp[moValue]; //796:5
                        string __tmp66Prefix = "((ModelObject)"; //797:1
                        string __tmp67Suffix = "));"; //797:88
                        StringBuilder __tmp68 = new StringBuilder();
                        __tmp68.Append(tmpName);
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
                        string __tmp69Line = ").MLazyAdd("; //797:24
                        __out.Append(__tmp69Line);
                        StringBuilder __tmp70 = new StringBuilder();
                        __tmp70.Append(propDeclName);
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
                        string __tmp71Line = ", new Lazy<object>(() => "; //797:49
                        __out.Append(__tmp71Line);
                        StringBuilder __tmp72 = new StringBuilder();
                        __tmp72.Append(tmpValueName);
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
                                __out.AppendLine(); //797:91
                            }
                        }
                    }
                    else //798:4
                    {
                        string __tmp73Prefix = "// NOT FOUND: "; //799:1
                        string __tmp74Suffix = string.Empty; 
                        StringBuilder __tmp75 = new StringBuilder();
                        __tmp75.Append(moValue);
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
                                __out.Append(__tmp74Suffix);
                                __out.AppendLine(); //799:24
                            }
                        }
                    }
                }
            }
            else //802:2
            {
                IEnumerable<object> mc = (value as ModelCollection) as IEnumerable<object>; //803:3
                if (mc != null) //804:3
                {
                    var __loop42_results = 
                        (from cvalue in __Enumerate((mc).GetEnumerator()) //805:9
                        select new { cvalue = cvalue}
                        ).ToList(); //805:4
                    int __loop42_iteration = 0;
                    foreach (var __tmp76 in __loop42_results)
                    {
                        ++__loop42_iteration;
                        var cvalue = __tmp76.cvalue;
                        string __tmp77Prefix = string.Empty;
                        string __tmp78Suffix = string.Empty;
                        StringBuilder __tmp79 = new StringBuilder();
                        __tmp79.Append(GenerateModelObjectPropertyValue(mobj, prop, cvalue, mobjToTmp));
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
                                __out.Append(__tmp78Suffix);
                                __out.AppendLine(); //806:66
                            }
                        }
                    }
                }
                else //808:3
                {
                    string __tmp80Prefix = "// "; //809:1
                    string __tmp81Suffix = string.Empty; 
                    StringBuilder __tmp82 = new StringBuilder();
                    __tmp82.Append(propDeclName);
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
                    string __tmp83Line = " = "; //809:18
                    __out.Append(__tmp83Line);
                    StringBuilder __tmp84 = new StringBuilder();
                    __tmp84.Append(value.GetType());
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
                            __out.AppendLine(); //809:38
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GetEnumValueOf(object enm) //814:1
        {
            return "global::" + enm.GetType().FullName.Replace("+", ".") + "." + enm.ToString(); //815:2
        }

        public string GenerateClassMetaInstance(MetaClass cls) //818:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = " = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();"; //819:19
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
                    __out.AppendLine(); //819:83
                }
            }
            return __out.ToString();
        }

        public string GenerateClassMetaInstanceInitializer(MetaClass cls) //822:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = "\";"; //823:46
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
            string __tmp4Line = ".Name = \""; //823:19
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
                    __out.AppendLine(); //823:48
                }
            }
            if (cls.IsAbstract) //824:2
            {
                string __tmp6Prefix = string.Empty; 
                string __tmp7Suffix = ".IsAbstract = true;"; //825:19
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
                        __out.AppendLine(); //825:38
                    }
                }
            }
            var __loop43_results = 
                (from __loop43_var1 in __Enumerate((cls).GetEnumerator()) //827:7
                from sup in __Enumerate((__loop43_var1.SuperClasses).GetEnumerator()) //827:12
                select new { __loop43_var1 = __loop43_var1, sup = sup}
                ).ToList(); //827:2
            int __loop43_iteration = 0;
            foreach (var __tmp9 in __loop43_results)
            {
                ++__loop43_iteration;
                var __loop43_var1 = __tmp9.__loop43_var1;
                var sup = __tmp9.sup;
                string __tmp10Prefix = string.Empty; 
                string __tmp11Suffix = ");"; //828:67
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
                string __tmp13Line = ".SuperClasses.Add("; //828:19
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
                        __out.AppendLine(); //828:69
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //833:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "internal static class "; //834:1
            string __tmp2Suffix = "ImplementationProvider"; //834:35
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
                    __out.AppendLine(); //834:57
                }
            }
            __out.Append("{"); //835:1
            __out.AppendLine(); //835:2
            string __tmp4Prefix = "    // If there is a compile error at this line, create a new class called "; //836:1
            string __tmp5Suffix = "Implementation"; //836:88
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
                    __out.AppendLine(); //836:102
                }
            }
            string __tmp7Prefix = "	// which is a subclass of "; //837:1
            string __tmp8Suffix = "ImplementationBase:"; //837:40
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
                    __out.AppendLine(); //837:59
                }
            }
            string __tmp10Prefix = "    private static "; //838:1
            string __tmp11Suffix = "Implementation();"; //838:80
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
            string __tmp13Line = "Implementation implementation = new "; //838:32
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
                    __out.AppendLine(); //838:97
                }
            }
            __out.AppendLine(); //839:1
            string __tmp15Prefix = "    public static "; //840:1
            string __tmp16Suffix = "Implementation Implementation"; //840:31
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
                    __out.AppendLine(); //840:60
                }
            }
            __out.Append("    {"); //841:1
            __out.AppendLine(); //841:6
            string __tmp18Prefix = "        get { return "; //842:1
            string __tmp19Suffix = "ImplementationProvider.implementation; }"; //842:34
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
                    __out.AppendLine(); //842:74
                }
            }
            __out.Append("    }"); //843:1
            __out.AppendLine(); //843:6
            __out.Append("}"); //844:1
            __out.AppendLine(); //844:2
            var __loop44_results = 
                (from __loop44_var1 in __Enumerate((model).GetEnumerator()) //845:8
                from Namespace in __Enumerate((__loop44_var1.Namespace).GetEnumerator()) //845:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //845:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //845:40
                select new { __loop44_var1 = __loop44_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //845:3
            int __loop44_iteration = 0;
            foreach (var __tmp21 in __loop44_results)
            {
                ++__loop44_iteration;
                var __loop44_var1 = __tmp21.__loop44_var1;
                var Namespace = __tmp21.Namespace;
                var Declarations = __tmp21.Declarations;
                var enm = __tmp21.enm;
                __out.AppendLine(); //846:1
                string __tmp22Prefix = "public static class "; //847:1
                string __tmp23Suffix = "Extensions"; //847:31
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
                        __out.AppendLine(); //847:41
                    }
                }
                __out.Append("{"); //848:1
                __out.AppendLine(); //848:2
                var __loop45_results = 
                    (from __loop45_var1 in __Enumerate((enm).GetEnumerator()) //849:11
                    from op in __Enumerate((__loop45_var1.Operations).GetEnumerator()) //849:16
                    select new { __loop45_var1 = __loop45_var1, op = op}
                    ).ToList(); //849:6
                int __loop45_iteration = 0;
                foreach (var __tmp25 in __loop45_results)
                {
                    ++__loop45_iteration;
                    var __loop45_var1 = __tmp25.__loop45_var1;
                    var op = __tmp25.op;
                    string __tmp26Prefix = "    public static "; //850:1
                    string __tmp27Suffix = ")"; //850:100
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
                    string __tmp29Line = " "; //850:57
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
                    string __tmp31Line = "("; //850:67
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
                            __out.AppendLine(); //850:101
                        }
                    }
                    __out.Append("    {"); //851:1
                    __out.AppendLine(); //851:6
                    string __tmp33Prefix = "        "; //852:1
                    string __tmp34Suffix = ");"; //852:144
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
                    string __tmp37Line = "ImplementationProvider.Implementation."; //852:36
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
                    string __tmp39Line = "_"; //852:98
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
                    string __tmp41Line = "("; //852:108
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
                            __out.AppendLine(); //852:146
                        }
                    }
                    __out.Append("    }"); //853:1
                    __out.AppendLine(); //853:6
                }
                __out.Append("}"); //855:1
                __out.AppendLine(); //855:2
            }
            __out.AppendLine(); //857:1
            __out.Append("/// <summary>"); //858:1
            __out.AppendLine(); //858:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //859:1
            __out.AppendLine(); //859:68
            string __tmp43Prefix = "/// This class has to be be overriden in "; //860:1
            string __tmp44Suffix = "Implementation to provide custom"; //860:54
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
                    __out.AppendLine(); //860:86
                }
            }
            __out.Append("/// implementation for the constructors, operations and property values."); //861:1
            __out.AppendLine(); //861:73
            __out.Append("/// </summary>"); //862:1
            __out.AppendLine(); //862:15
            string __tmp46Prefix = "internal abstract class "; //863:1
            string __tmp47Suffix = "ImplementationBase"; //863:37
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
                    __out.AppendLine(); //863:55
                }
            }
            __out.Append("{"); //864:1
            __out.AppendLine(); //864:2
            var __loop46_results = 
                (from __loop46_var1 in __Enumerate((model).GetEnumerator()) //865:8
                from Namespace in __Enumerate((__loop46_var1.Namespace).GetEnumerator()) //865:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //865:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //865:40
                select new { __loop46_var1 = __loop46_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //865:3
            int __loop46_iteration = 0;
            foreach (var __tmp49 in __loop46_results)
            {
                ++__loop46_iteration;
                var __loop46_var1 = __tmp49.__loop46_var1;
                var Namespace = __tmp49.Namespace;
                var Declarations = __tmp49.Declarations;
                var cls = __tmp49.cls;
                __out.Append("    /// <summary>"); //866:1
                __out.AppendLine(); //866:18
                string __tmp50Prefix = "	/// Implements the constructor: "; //867:1
                string __tmp51Suffix = "()"; //867:52
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
                        __out.AppendLine(); //867:54
                    }
                }
                if ((from __loop47_var1 in __Enumerate((cls).GetEnumerator()) //868:15
                from sup in __Enumerate((__loop47_var1.SuperClasses).GetEnumerator()) //868:20
                select new { __loop47_var1 = __loop47_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //868:3
                {
                    string __tmp53Prefix = "	/// Direct superclasses: "; //869:1
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
                            __out.AppendLine(); //869:49
                        }
                    }
                    string __tmp56Prefix = "	/// All superclasses: "; //870:1
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
                            __out.AppendLine(); //870:49
                        }
                    }
                }
                if ((from __loop48_var1 in __Enumerate((cls).GetEnumerator()) //872:15
                from prop in __Enumerate((__loop48_var1.GetAllProperties()).GetEnumerator()) //872:20
                where prop.Kind == MetaPropertyKind.Readonly //872:44
                select new { __loop48_var1 = __loop48_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //872:3
                {
                    __out.Append("    /// Initializes the following readonly properties:"); //873:1
                    __out.AppendLine(); //873:55
                }
                var __loop49_results = 
                    (from __loop49_var1 in __Enumerate((cls).GetEnumerator()) //875:11
                    from prop in __Enumerate((__loop49_var1.GetAllProperties()).GetEnumerator()) //875:16
                    select new { __loop49_var1 = __loop49_var1, prop = prop}
                    ).ToList(); //875:6
                int __loop49_iteration = 0;
                foreach (var __tmp59 in __loop49_results)
                {
                    ++__loop49_iteration;
                    var __loop49_var1 = __tmp59.__loop49_var1;
                    var prop = __tmp59.prop;
                    if (prop.Kind == MetaPropertyKind.Readonly) //876:3
                    {
                        string __tmp60Prefix = "    ///    "; //877:1
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
                        string __tmp63Line = "."; //877:29
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
                                __out.AppendLine(); //877:41
                            }
                        }
                    }
                }
                __out.Append("    /// </summary>"); //880:1
                __out.AppendLine(); //880:19
                string __tmp65Prefix = "    public virtual void "; //881:1
                string __tmp66Suffix = " @this)"; //881:81
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
                string __tmp68Line = "_"; //881:43
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
                string __tmp70Line = "("; //881:62
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
                        __out.AppendLine(); //881:88
                    }
                }
                __out.Append("    {"); //882:1
                __out.AppendLine(); //882:6
                var __loop50_results = 
                    (from __loop50_var1 in __Enumerate((cls).GetEnumerator()) //883:9
                    from sup in __Enumerate((__loop50_var1.SuperClasses).GetEnumerator()) //883:14
                    select new { __loop50_var1 = __loop50_var1, sup = sup}
                    ).ToList(); //883:4
                int __loop50_iteration = 0;
                foreach (var __tmp72 in __loop50_results)
                {
                    ++__loop50_iteration;
                    var __loop50_var1 = __tmp72.__loop50_var1;
                    var sup = __tmp72.sup;
                    string __tmp73Prefix = "        this."; //884:1
                    string __tmp74Suffix = "(@this);"; //884:51
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
                    string __tmp76Line = "_"; //884:32
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
                            __out.AppendLine(); //884:59
                        }
                    }
                }
                __out.Append("    }"); //886:1
                __out.AppendLine(); //886:6
                var __loop51_results = 
                    (from __loop51_var1 in __Enumerate((cls).GetEnumerator()) //887:11
                    from prop in __Enumerate((__loop51_var1.Properties).GetEnumerator()) //887:16
                    select new { __loop51_var1 = __loop51_var1, prop = prop}
                    ).ToList(); //887:6
                int __loop51_iteration = 0;
                foreach (var __tmp78 in __loop51_results)
                {
                    ++__loop51_iteration;
                    var __loop51_var1 = __tmp78.__loop51_var1;
                    var prop = __tmp78.prop;
                    MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //888:4
                    if (synInit == null) //889:4
                    {
                        if (prop.Kind == MetaPropertyKind.Derived) //890:5
                        {
                            __out.AppendLine(); //891:1
                            __out.Append("    /// <summary>"); //892:1
                            __out.AppendLine(); //892:18
                            string __tmp79Prefix = "    /// Returns the value of the derived property: "; //893:1
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
                            string __tmp82Line = "."; //893:70
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
                                    __out.AppendLine(); //893:82
                                }
                            }
                            __out.Append("    /// </summary>"); //894:1
                            __out.AppendLine(); //894:19
                            string __tmp84Prefix = "    public virtual "; //895:1
                            string __tmp85Suffix = " @this)"; //895:104
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
                            string __tmp87Line = " "; //895:54
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
                            string __tmp89Line = "_"; //895:73
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
                            string __tmp91Line = "("; //895:85
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
                                    __out.AppendLine(); //895:111
                                }
                            }
                            __out.Append("    {"); //896:1
                            __out.AppendLine(); //896:6
                            __out.Append("        throw new NotImplementedException();"); //897:1
                            __out.AppendLine(); //897:45
                            __out.Append("    }"); //898:1
                            __out.AppendLine(); //898:6
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //899:5
                        {
                            __out.AppendLine(); //900:1
                            __out.Append("    /// <summary>"); //901:1
                            __out.AppendLine(); //901:18
                            string __tmp93Prefix = "    /// Returns the value of the lazy property: "; //902:1
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
                            string __tmp96Line = "."; //902:67
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
                                    __out.AppendLine(); //902:79
                                }
                            }
                            __out.Append("    /// </summary>"); //903:1
                            __out.AppendLine(); //903:19
                            string __tmp98Prefix = "    public virtual "; //904:1
                            string __tmp99Suffix = " @this)"; //904:104
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
                            string __tmp101Line = " "; //904:54
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
                            string __tmp103Line = "_"; //904:73
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
                            string __tmp105Line = "("; //904:85
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
                                    __out.AppendLine(); //904:111
                                }
                            }
                            __out.Append("    {"); //905:1
                            __out.AppendLine(); //905:6
                            __out.Append("        throw new NotImplementedException();"); //906:1
                            __out.AppendLine(); //906:45
                            __out.Append("    }"); //907:1
                            __out.AppendLine(); //907:6
                        }
                    }
                }
                var __loop52_results = 
                    (from __loop52_var1 in __Enumerate((cls).GetEnumerator()) //911:11
                    from op in __Enumerate((__loop52_var1.Operations).GetEnumerator()) //911:16
                    select new { __loop52_var1 = __loop52_var1, op = op}
                    ).ToList(); //911:6
                int __loop52_iteration = 0;
                foreach (var __tmp107 in __loop52_results)
                {
                    ++__loop52_iteration;
                    var __loop52_var1 = __tmp107.__loop52_var1;
                    var op = __tmp107.op;
                    __out.AppendLine(); //912:1
                    __out.Append("    /// <summary>"); //913:1
                    __out.AppendLine(); //913:18
                    string __tmp108Prefix = "    /// Implements the operation: "; //914:1
                    string __tmp109Suffix = "()"; //914:63
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
                    string __tmp111Line = "."; //914:53
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
                            __out.AppendLine(); //914:65
                        }
                    }
                    __out.Append("    /// </summary>"); //915:1
                    __out.AppendLine(); //915:19
                    string __tmp113Prefix = "    public virtual "; //916:1
                    string __tmp114Suffix = ")"; //916:116
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
                    string __tmp116Line = " "; //916:58
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
                    string __tmp118Line = "_"; //916:77
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
                    string __tmp120Line = "("; //916:87
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
                            __out.AppendLine(); //916:117
                        }
                    }
                    __out.Append("    {"); //917:1
                    __out.AppendLine(); //917:6
                    __out.Append("        throw new NotImplementedException();"); //918:1
                    __out.AppendLine(); //918:45
                    __out.Append("    }"); //919:1
                    __out.AppendLine(); //919:6
                }
                __out.AppendLine(); //921:1
            }
            var __loop53_results = 
                (from __loop53_var1 in __Enumerate((model).GetEnumerator()) //923:8
                from Namespace in __Enumerate((__loop53_var1.Namespace).GetEnumerator()) //923:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //923:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //923:40
                select new { __loop53_var1 = __loop53_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //923:3
            int __loop53_iteration = 0;
            foreach (var __tmp122 in __loop53_results)
            {
                ++__loop53_iteration;
                var __loop53_var1 = __tmp122.__loop53_var1;
                var Namespace = __tmp122.Namespace;
                var Declarations = __tmp122.Declarations;
                var enm = __tmp122.enm;
                var __loop54_results = 
                    (from __loop54_var1 in __Enumerate((enm).GetEnumerator()) //924:11
                    from op in __Enumerate((__loop54_var1.Operations).GetEnumerator()) //924:16
                    select new { __loop54_var1 = __loop54_var1, op = op}
                    ).ToList(); //924:6
                int __loop54_iteration = 0;
                foreach (var __tmp123 in __loop54_results)
                {
                    ++__loop54_iteration;
                    var __loop54_var1 = __tmp123.__loop54_var1;
                    var op = __tmp123.op;
                    __out.AppendLine(); //925:1
                    __out.Append("    /// <summary>"); //926:1
                    __out.AppendLine(); //926:18
                    string __tmp124Prefix = "    /// Implements the operation: "; //927:1
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
                    string __tmp127Line = "."; //927:53
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
                            __out.AppendLine(); //927:63
                        }
                    }
                    __out.Append("    /// </summary>"); //928:1
                    __out.AppendLine(); //928:19
                    string __tmp129Prefix = "    public virtual "; //929:1
                    string __tmp130Suffix = ")"; //929:116
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
                    string __tmp132Line = " "; //929:58
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
                    string __tmp134Line = "_"; //929:77
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
                    string __tmp136Line = "("; //929:87
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
                            __out.AppendLine(); //929:117
                        }
                    }
                    __out.Append("    {"); //930:1
                    __out.AppendLine(); //930:6
                    __out.Append("        throw new NotImplementedException();"); //931:1
                    __out.AppendLine(); //931:45
                    __out.Append("    }"); //932:1
                    __out.AppendLine(); //932:6
                }
                __out.AppendLine(); //934:1
            }
            __out.Append("}"); //936:1
            __out.AppendLine(); //936:2
            __out.AppendLine(); //937:1
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //940:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //941:1
            __out.AppendLine(); //941:14
            __out.Append("/// Factory class for creating instances of model elements."); //942:1
            __out.AppendLine(); //942:60
            __out.Append("/// </summary>"); //943:1
            __out.AppendLine(); //943:15
            string __tmp1Prefix = "public class "; //944:1
            string __tmp2Suffix = " : ModelFactory"; //944:41
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
                    __out.AppendLine(); //944:56
                }
            }
            __out.Append("{"); //945:1
            __out.AppendLine(); //945:2
            string __tmp4Prefix = "    private static "; //946:1
            string __tmp5Suffix = "();"; //946:90
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
            string __tmp7Line = " instance = new "; //946:47
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
                    __out.AppendLine(); //946:93
                }
            }
            __out.AppendLine(); //947:1
            string __tmp9Prefix = "	private "; //948:1
            string __tmp10Suffix = "()"; //948:37
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
                    __out.AppendLine(); //948:39
                }
            }
            __out.Append("	{"); //949:1
            __out.AppendLine(); //949:3
            __out.Append("	}"); //950:1
            __out.AppendLine(); //950:3
            __out.AppendLine(); //951:1
            __out.Append("    /// <summary>"); //952:1
            __out.AppendLine(); //952:18
            __out.Append("    /// The singleton instance of the factory."); //953:1
            __out.AppendLine(); //953:47
            __out.Append("    /// </summary>"); //954:1
            __out.AppendLine(); //954:19
            string __tmp12Prefix = "    public static "; //955:1
            string __tmp13Suffix = " Instance"; //955:46
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
                    __out.AppendLine(); //955:55
                }
            }
            __out.Append("    {"); //956:1
            __out.AppendLine(); //956:6
            string __tmp15Prefix = "        get { return "; //957:1
            string __tmp16Suffix = ".instance; }"; //957:49
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
                    __out.AppendLine(); //957:61
                }
            }
            __out.Append("    }"); //958:1
            __out.AppendLine(); //958:6
            var __loop55_results = 
                (from __loop55_var1 in __Enumerate((model).GetEnumerator()) //959:8
                from Namespace in __Enumerate((__loop55_var1.Namespace).GetEnumerator()) //959:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //959:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //959:40
                select new { __loop55_var1 = __loop55_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //959:3
            int __loop55_iteration = 0;
            foreach (var __tmp18 in __loop55_results)
            {
                ++__loop55_iteration;
                var __loop55_var1 = __tmp18.__loop55_var1;
                var Namespace = __tmp18.Namespace;
                var Declarations = __tmp18.Declarations;
                var cls = __tmp18.cls;
                if (!cls.IsAbstract) //960:4
                {
                    __out.AppendLine(); //961:1
                    __out.Append("    /// <summary>"); //962:1
                    __out.AppendLine(); //962:18
                    string __tmp19Prefix = "    /// Creates a new instance of "; //963:1
                    string __tmp20Suffix = "."; //963:53
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
                            __out.AppendLine(); //963:54
                        }
                    }
                    __out.Append("    /// </summary>"); //964:1
                    __out.AppendLine(); //964:19
                    string __tmp22Prefix = "    public "; //965:1
                    string __tmp23Suffix = "(IEnumerable<ModelPropertyInitializer> initializers = null)"; //965:55
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
                    string __tmp25Line = " Create"; //965:30
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
                            __out.AppendLine(); //965:114
                        }
                    }
                    __out.Append("	{"); //966:1
                    __out.AppendLine(); //966:3
                    string __tmp27Prefix = "		"; //967:1
                    string __tmp28Suffix = "Impl();"; //967:57
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
                    string __tmp30Line = " result = new "; //967:21
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
                            __out.AppendLine(); //967:64
                        }
                    }
                    __out.Append("		if (initializers != null)"); //968:1
                    __out.AppendLine(); //968:28
                    __out.Append("		{"); //969:1
                    __out.AppendLine(); //969:4
                    __out.Append("			this.Init((ModelObject)result, initializers);"); //970:1
                    __out.AppendLine(); //970:49
                    __out.Append("		}"); //971:1
                    __out.AppendLine(); //971:4
                    __out.Append("		return result;"); //972:1
                    __out.AppendLine(); //972:17
                    __out.Append("	}"); //973:1
                    __out.AppendLine(); //973:3
                }
            }
            __out.Append("}"); //976:1
            __out.AppendLine(); //976:2
            __out.AppendLine(); //977:1
            return __out.ToString();
        }

    }
}

