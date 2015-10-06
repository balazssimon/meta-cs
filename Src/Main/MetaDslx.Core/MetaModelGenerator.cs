using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core //1:1
{
    using __Hidden_MetaModelGenerator_872755558;
    namespace __Hidden_MetaModelGenerator_872755558
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
            if (prop.Kind == MetaPropertyKind.Derived) //211:3
            {
                MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //212:4
                if (synInit == null) //213:4
                {
                    string __tmp8Prefix = "    get { return "; //214:1
                    string __tmp9Suffix = "(this); }"; //214:94
                    StringBuilder __tmp10 = new StringBuilder();
                    __tmp10.Append(model.CSharpFullImplementationName());
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
                    string __tmp11Line = "."; //214:56
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
                    string __tmp13Line = "_"; //214:82
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
                            __out.AppendLine(); //214:103
                        }
                    }
                }
                else //215:4
                {
                    string __tmp15Prefix = "    get { return "; //216:1
                    string __tmp16Suffix = "; }"; //216:53
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
                            __out.AppendLine(); //216:56
                        }
                    }
                }
            }
            else //218:3
            {
                __out.Append("    get "); //219:1
                __out.AppendLine(); //219:9
                __out.Append("    {"); //220:1
                __out.AppendLine(); //220:6
                string __tmp18Prefix = "        object result = this.MGet("; //221:1
                string __tmp19Suffix = "); "; //221:68
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(prop.CSharpFullDescriptorName());
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
                        __out.AppendLine(); //221:71
                    }
                }
                string __tmp21Prefix = "        if (result != null) return ("; //222:1
                string __tmp22Suffix = ")result;"; //222:71
                StringBuilder __tmp23 = new StringBuilder();
                __tmp23.Append(prop.Type.CSharpFullPublicName());
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
                        __out.AppendLine(); //222:79
                    }
                }
                string __tmp24Prefix = "        else return default("; //223:1
                string __tmp25Suffix = ");"; //223:63
                StringBuilder __tmp26 = new StringBuilder();
                __tmp26.Append(prop.Type.CSharpFullPublicName());
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
                        __out.AppendLine(); //223:65
                    }
                }
                __out.Append("    }"); //224:1
                __out.AppendLine(); //224:6
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //226:3
            {
                string __tmp27Prefix = "    set { this.MSet("; //227:1
                string __tmp28Suffix = ", value); }"; //227:54
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
                        __out.Append(__tmp28Suffix);
                        __out.AppendLine(); //227:65
                    }
                }
            }
            __out.Append("}"); //229:1
            __out.AppendLine(); //229:2
            return __out.ToString();
        }

        public string GetCollectionConstructorParams(MetaProperty prop) //232:1
        {
            MetaCollectionType mct = prop.Type as MetaCollectionType; //233:2
            if (mct != null && mct.InnerType is MetaClass) //234:2
            {
                return "this, " + prop.CSharpFullDescriptorName(); //235:3
            }
            else //236:2
            {
                return ""; //237:3
            }
        }

        public string GenerateExpression(MetaExpression expr) //242:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //243:10
            if (expr is MetaBracketExpression) //244:2
            {
                __out.Append("("); //244:33
                __out.Append(GenerateExpression(((MetaBracketExpression)expr).Expression));
                __out.Append(")"); //244:71
            }
            else if (expr is MetaThisExpression) //245:2
            {
                __out.Append("(("); //245:30
                __out.Append(((MetaType)ModelContext.Current.Compiler.ResolutionProvider.GetCurrentTypeScopeOf((ModelObject)((MetaThisExpression)expr))).CSharpName());
                __out.Append(")this)"); //245:148
            }
            else if (expr is MetaNullExpression) //246:2
            {
                __out.Append("null"); //246:30
            }
            else if (expr is MetaTypeAsExpression) //247:2
            {
                __out.Append(GenerateExpression(((MetaTypeAsExpression)expr).Expression));
                __out.Append(" as "); //247:69
                __out.Append(((MetaTypeAsExpression)expr).TypeReference.CSharpName());
            }
            else if (expr is MetaTypeCastExpression) //248:2
            {
                __out.Append("("); //248:34
                __out.Append(((MetaTypeCastExpression)expr).TypeReference.CSharpName());
                __out.Append(")"); //248:68
                __out.Append(GenerateExpression(((MetaTypeCastExpression)expr).Expression));
            }
            else if (expr is MetaTypeCheckExpression) //249:2
            {
                __out.Append(GenerateExpression(((MetaTypeCheckExpression)expr).Expression));
                __out.Append(" is "); //249:72
                __out.Append(((MetaTypeCheckExpression)expr).TypeReference.CSharpName());
            }
            else if (expr is MetaTypeOfExpression) //250:2
            {
                __out.Append(GenerateTypeOf(((MetaTypeOfExpression)expr)));
            }
            else if (expr is MetaConditionalExpression) //251:2
            {
                __out.Append(GenerateExpression(((MetaConditionalExpression)expr).Condition));
                __out.Append(" ? "); //251:73
                __out.Append(GenerateExpression(((MetaConditionalExpression)expr).Then));
                __out.Append(" : "); //251:107
                __out.Append(GenerateExpression(((MetaConditionalExpression)expr).Else));
            }
            else if (expr is MetaConstantExpression) //252:2
            {
                __out.Append(GetCSharpValue(((MetaConstantExpression)expr).Value));
            }
            else if (expr is MetaIdentifierExpression) //253:2
            {
                __out.Append(GenerateIdentifierExpression(((MetaIdentifierExpression)expr)));
            }
            else if (expr is MetaMemberAccessExpression) //254:2
            {
                __out.Append(GenerateExpression(((MetaMemberAccessExpression)expr).Expression));
                __out.Append("."); //254:75
                __out.Append(((MetaMemberAccessExpression)expr).Name);
            }
            else if (expr is MetaFunctionCallExpression) //255:2
            {
                __out.Append(GenerateFunctionCall(((MetaFunctionCallExpression)expr)));
            }
            else if (expr is MetaIndexerExpression) //256:2
            {
                __out.Append(GenerateIndexerCall(((MetaIndexerExpression)expr)));
            }
            else if (expr is MetaOperatorExpression) //257:2
            {
                __out.Append(GenerateOperator(((MetaOperatorExpression)expr)));
            }
            else if (expr is MetaNewExpression) //258:2
            {
                __out.Append(((MetaNewExpression)expr).TypeReference.CSharpFullFactoryMethodName());
                __out.Append("("); //258:79
                __out.Append(GenerateNewPropertyInitializers(((MetaNewExpression)expr)));
                __out.Append(")"); //258:119
            }
            else if (expr is MetaNewCollectionExpression) //259:2
            {
                __out.Append("new List<Lazy<object>>() { "); //259:39
                __out.Append(GenerateNewCollectionValues(((MetaNewCollectionExpression)expr)));
                __out.Append(" }"); //259:101
            }
            else //260:2
            {
                __out.Append("***unknown expression type***"); //260:11
                __out.AppendLine(); //260:40
            }//261:2
            return __out.ToString();
        }

        public string GenerateIdentifierExpression(MetaIdentifierExpression expr) //264:1
        {
            StringBuilder __out = new StringBuilder();
            if (expr.Definition is MetaProperty) //265:2
            {
                string __tmp1Prefix = "(("; //266:1
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
                string __tmp4Line = ")this)."; //266:119
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
            else //267:2
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

        public bool SameFunction(MetaGlobalFunction mfunc1, MetaGlobalFunction mfunc2) //272:1
        {
            return mfunc1.Name == mfunc2.Name && ModelContext.Current.Compiler.TypeProvider.Equals((ModelObject)mfunc1.Type, (ModelObject)mfunc2.Type); //273:2
        }

        public string GenerateFunctionCall(MetaFunctionCallExpression call) //276:1
        {
            StringBuilder __out = new StringBuilder();
            if (call.Definition is MetaGlobalFunction && SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.TypeOf)) //277:2
            {
                __out.Append(GenerateTypeOf(call.Arguments[0]));
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.GetValueType)) //278:2
            {
                __out.Append("ModelContext.Current.Compiler.TypeProvider.GetTypeOf("); //278:89
                __out.Append(GenerateCallArguments(call, ""));
                __out.Append(")"); //278:175
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.GetReturnType)) //279:2
            {
                __out.Append("ModelContext.Current.Compiler.TypeProvider.GetReturnTypeOf("); //279:90
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //279:195
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.CurrentType)) //280:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.GetCurrentTypeScopeOf("); //280:88
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //280:205
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.TypeCheck)) //281:2
            {
                __out.Append("ModelContext.Current.Compiler.TypeProvider.TypeCheck("); //281:86
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //281:185
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Balance)) //282:2
            {
                __out.Append("ModelContext.Current.Compiler.TypeProvider.Balance("); //282:84
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //282:181
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Resolve1)) //283:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //283:85
                __out.Append("[]");
                __out.Append(" { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.NameOrType, "); //283:163
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //283:303
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Resolve2)) //284:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //284:85
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //284:163
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, ResolveKind.NameOrType, "); //284:218
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //284:285
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveType1)) //285:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //285:89
                __out.Append("[]");
                __out.Append(" { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Type, "); //285:167
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //285:301
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveType2)) //286:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //286:89
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //286:167
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, ResolveKind.Type, "); //286:222
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //286:283
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveName1)) //287:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //287:89
                __out.Append("[]");
                __out.Append(" { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, "); //287:167
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //287:301
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveName2)) //288:2
            {
                __out.Append("ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject"); //288:89
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //288:167
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, ResolveKind.Name, "); //288:222
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //288:283
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind1)) //289:2
            {
                __out.Append("ModelContext.Current.Compiler.BindingProvider.Bind(this, new ModelObject"); //289:82
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //289:160
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, new BindingInfo())"); //289:215
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind2)) //290:2
            {
                __out.Append("ModelContext.Current.Compiler.BindingProvider.Bind(this, "); //290:82
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new BindingInfo())"); //290:178
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind3)) //291:2
            {
                __out.Append("ModelContext.Current.Compiler.BindingProvider.Bind((ModelObject)"); //291:82
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ModelObject"); //291:185
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //291:208
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(" }, new BindingInfo())"); //291:263
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind4)) //292:2
            {
                __out.Append("ModelContext.Current.Compiler.BindingProvider.Bind((ModelObject)"); //292:82
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", "); //292:185
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new BindingInfo())"); //292:226
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.SelectOfType1)) //293:2
            {
                __out.Append("new object"); //293:90
                __out.Append("[]");
                __out.Append(" { "); //293:106
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }.Where(e => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(e) is "); //293:148
                __out.Append(GetTypeName(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //293:253
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.SelectOfType2)) //294:2
            {
                __out.Append("("); //294:90
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(").Where(e => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(e) is "); //294:130
                __out.Append(GetTypeName(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //294:234
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.SelectOfName1)) //295:2
            {
                __out.Append("new object"); //295:90
                __out.Append("[]");
                __out.Append(" { "); //295:106
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }.Where(e => ModelContext.Current.Compiler.NameProvider.GetNameOf((ModelObject)e) == "); //295:148
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //295:273
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.SelectOfName2)) //296:2
            {
                __out.Append("("); //296:90
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(").Where(e => ModelContext.Current.Compiler.NameProvider.GetNameOf((ModelObject)e) == "); //296:130
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //296:254
            }
            else //297:2
            {
                __out.Append(GenerateExpression(call.Expression));
                __out.Append("("); //297:44
                __out.Append(GenerateCallArguments(call, ""));
                __out.Append(")"); //297:78
            }
            return __out.ToString();
        }

        public string GenerateIndexerCall(MetaIndexerExpression call) //301:1
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

        public string GenerateTypeOf(object expr) //305:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //306:9
            if (expr is MetaPrimitiveType) //307:2
            {
                var __tmp2 = ((MetaPrimitiveType)expr).Name; //308:10
                __out.Append("	"); //309:1
                if (__tmp2 == "*none*") //309:3
                {
                    __out.Append("MetaInstance.None"); //309:18
                    __out.Append("	"); //310:1
                }
                else if (__tmp2 == "*error*") //310:3
                {
                    __out.Append("MetaInstance.Error"); //310:19
                    __out.Append("	"); //311:1
                }
                else if (__tmp2 == "*any*") //311:3
                {
                    __out.Append("MetaInstance.Any"); //311:17
                    __out.Append("	"); //312:1
                }
                else if (__tmp2 == "object") //312:3
                {
                    __out.Append("MetaInstance.Object"); //312:18
                    __out.Append("	"); //313:1
                }
                else if (__tmp2 == "string") //313:3
                {
                    __out.Append("MetaInstance.String"); //313:18
                    __out.Append("	"); //314:1
                }
                else if (__tmp2 == "int") //314:3
                {
                    __out.Append("MetaInstance.Int"); //314:15
                    __out.Append("	"); //315:1
                }
                else if (__tmp2 == "long") //315:3
                {
                    __out.Append("MetaInstance.Long"); //315:16
                    __out.Append("	"); //316:1
                }
                else if (__tmp2 == "float") //316:3
                {
                    __out.Append("MetaInstance.Float"); //316:17
                    __out.Append("	"); //317:1
                }
                else if (__tmp2 == "double") //317:3
                {
                    __out.Append("MetaInstance.Double"); //317:18
                    __out.Append("	"); //318:1
                }
                else if (__tmp2 == "byte") //318:3
                {
                    __out.Append("MetaInstance.Byte"); //318:16
                    __out.Append("	"); //319:1
                }
                else if (__tmp2 == "bool") //319:3
                {
                    __out.Append("MetaInstance.Bool"); //319:16
                    __out.Append("	"); //320:1
                }
                else if (__tmp2 == "void") //320:3
                {
                    __out.Append("MetaInstance.Void"); //320:16
                    __out.Append("	"); //321:1
                }
                else if (__tmp2 == "ModelObject") //321:3
                {
                    __out.Append("MetaInstance.ModelObject"); //321:23
                    __out.Append("	"); //322:1
                }
                else if (__tmp2 == "ModelObjectList") //322:3
                {
                    __out.Append("MetaInstance.ModelObjectList"); //322:27
                }//323:3
            }
            else if (expr is MetaTypeOfExpression) //324:2
            {
                __out.Append(GenerateTypeOf(((MetaTypeOfExpression)expr).TypeReference));
            }
            else if (expr is MetaClass) //325:2
            {
                __out.Append(((MetaClass)expr).CSharpFullDescriptorName());
                __out.Append(".MetaClass"); //325:54
            }
            else if (expr is MetaCollectionType) //326:2
            {
                __out.Append(((MetaCollectionType)expr).CSharpFullName());
            }
            else //327:2
            {
                __out.Append("***error***"); //327:11
            }//328:2
            return __out.ToString();
        }

        public string GenerateCallArguments(MetaBoundExpression call, string prefix) //331:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop20_results = 
                (from __loop20_var1 in __Enumerate((call).GetEnumerator()) //332:7
                from arg in __Enumerate((__loop20_var1.Arguments).GetEnumerator()) //332:13
                select new { __loop20_var1 = __loop20_var1, arg = arg}
                ).ToList(); //332:2
            int __loop20_iteration = 0;
            string delim = ""; //332:28
            foreach (var __tmp1 in __loop20_results)
            {
                ++__loop20_iteration;
                if (__loop20_iteration >= 2) //332:47
                {
                    delim = ", "; //332:47
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

        public string GenerateOperator(MetaOperatorExpression expr) //337:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //338:10
            if (expr is MetaUnaryExpression) //339:2
            {
                if (((MetaUnaryExpression)expr) is MetaPostIncrementAssignExpression || ((MetaUnaryExpression)expr) is MetaPostDecrementAssignExpression) //340:3
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
                else //342:3
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
            else if (expr is MetaBinaryExpression) //345:2
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
            }//347:2
            return __out.ToString();
        }

        public string GenerateNewPropertyInitializers(MetaNewExpression expr) //350:1
        {
            StringBuilder __out = new StringBuilder();
            if ((from __loop21_var1 in __Enumerate((expr).GetEnumerator()) //351:14
            from pi in __Enumerate((__loop21_var1.PropertyInitializers).GetEnumerator()) //351:20
            select new { __loop21_var1 = __loop21_var1, pi = pi}
            ).GetEnumerator().MoveNext()) //351:2
            {
                __out.Append("new List<ModelPropertyInitializer>() {"); //352:1
                var __loop22_results = 
                    (from __loop22_var1 in __Enumerate((expr).GetEnumerator()) //353:7
                    from pi in __Enumerate((__loop22_var1.PropertyInitializers).GetEnumerator()) //353:13
                    select new { __loop22_var1 = __loop22_var1, pi = pi}
                    ).ToList(); //353:2
                int __loop22_iteration = 0;
                string delim = ""; //353:38
                foreach (var __tmp1 in __loop22_results)
                {
                    ++__loop22_iteration;
                    if (__loop22_iteration >= 2) //353:57
                    {
                        delim = ", "; //353:57
                    }
                    var __loop22_var1 = __tmp1.__loop22_var1;
                    var pi = __tmp1.pi;
                    string __tmp2Prefix = string.Empty; 
                    string __tmp3Suffix = "))"; //354:132
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
                    string __tmp5Line = "new ModelPropertyInitializer("; //354:8
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
                    string __tmp7Line = ", new Lazy<object>(() => "; //354:77
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
                __out.Append("}"); //356:1
            }
            return __out.ToString();
        }

        public string GenerateNewCollectionValues(MetaNewCollectionExpression expr) //360:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((expr).GetEnumerator()) //361:7
                from v in __Enumerate((__loop23_var1.Values).GetEnumerator()) //361:13
                select new { __loop23_var1 = __loop23_var1, v = v}
                ).ToList(); //361:2
            int __loop23_iteration = 0;
            string delim = ""; //361:23
            foreach (var __tmp1 in __loop23_results)
            {
                ++__loop23_iteration;
                if (__loop23_iteration >= 2) //361:42
                {
                    delim = ", \n"; //361:42
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

        public string GetCSharpValue(object value) //366:1
        {
            if (value == null) //367:2
            {
                return "null"; //367:21
            }
            else if (value is bool && ((bool)value) == true) //368:2
            {
                return "true"; //368:51
            }
            else if (value is bool && ((bool)value) == false) //369:2
            {
                return "false"; //369:52
            }
            else if (value is string) //370:2
            {
                return "\"" + value.ToString() + "\""; //370:28
            }
            else if (value is MetaExpression) //371:2
            {
                return GenerateExpression((MetaExpression)value); //371:36
            }
            else //372:2
            {
                return value.ToString(); //372:7
            }
        }

        public string GetCSharpIdentifier(object value) //376:1
        {
            if (value == null) //377:2
            {
                return null; //378:3
            }
            if (value is MetaConstantExpression && ((MetaConstantExpression)value).Value != null) //380:2
            {
                return ((MetaConstantExpression)value).Value.ToString(); //381:3
            }
            else if (value is string) //382:2
            {
                return value.ToString(); //383:3
            }
            else //384:2
            {
                return null; //385:3
            }
        }

        public string GetCSharpOperator(MetaOperatorExpression expr) //389:1
        {
            var __tmp1 = expr; //390:9
            if (expr is MetaUnaryPlusExpression) //391:3
            {
                return "+"; //391:36
            }
            else if (expr is MetaNegateExpression) //392:3
            {
                return "-"; //392:33
            }
            else if (expr is MetaOnesComplementExpression) //393:3
            {
                return "~"; //393:41
            }
            else if (expr is MetaNotExpression) //394:3
            {
                return "!"; //394:30
            }
            else if (expr is MetaPostIncrementAssignExpression) //395:3
            {
                return "++"; //395:46
            }
            else if (expr is MetaPostDecrementAssignExpression) //396:3
            {
                return "--"; //396:46
            }
            else if (expr is MetaPreIncrementAssignExpression) //397:3
            {
                return "++"; //397:45
            }
            else if (expr is MetaPreDecrementAssignExpression) //398:3
            {
                return "--"; //398:45
            }
            else if (expr is MetaMultiplyExpression) //399:3
            {
                return "*"; //399:35
            }
            else if (expr is MetaDivideExpression) //400:3
            {
                return "/"; //400:33
            }
            else if (expr is MetaModuloExpression) //401:3
            {
                return "%"; //401:33
            }
            else if (expr is MetaAddExpression) //402:3
            {
                return "+"; //402:30
            }
            else if (expr is MetaSubtractExpression) //403:3
            {
                return "-"; //403:35
            }
            else if (expr is MetaLeftShiftExpression) //404:3
            {
                return "<<"; //404:36
            }
            else if (expr is MetaRightShiftExpression) //405:3
            {
                return ">>"; //405:37
            }
            else if (expr is MetaLessThanExpression) //406:3
            {
                return "<"; //406:35
            }
            else if (expr is MetaLessThanOrEqualExpression) //407:3
            {
                return "<="; //407:42
            }
            else if (expr is MetaGreaterThanExpression) //408:3
            {
                return ">"; //408:38
            }
            else if (expr is MetaGreaterThanOrEqualExpression) //409:3
            {
                return ">="; //409:45
            }
            else if (expr is MetaEqualExpression) //410:3
            {
                return "=="; //410:32
            }
            else if (expr is MetaNotEqualExpression) //411:3
            {
                return "!="; //411:35
            }
            else if (expr is MetaAndExpression) //412:3
            {
                return "&"; //412:30
            }
            else if (expr is MetaOrExpression) //413:3
            {
                return "|"; //413:29
            }
            else if (expr is MetaExclusiveOrExpression) //414:3
            {
                return "^"; //414:38
            }
            else if (expr is MetaAndAlsoExpression) //415:3
            {
                return "&&"; //415:34
            }
            else if (expr is MetaOrElseExpression) //416:3
            {
                return "||"; //416:33
            }
            else if (expr is MetaNullCoalescingExpression) //417:3
            {
                return "??"; //417:41
            }
            else if (expr is MetaMultiplyAssignExpression) //418:3
            {
                return "*="; //418:41
            }
            else if (expr is MetaDivideAssignExpression) //419:3
            {
                return "/="; //419:39
            }
            else if (expr is MetaModuloAssignExpression) //420:3
            {
                return "%="; //420:39
            }
            else if (expr is MetaAddAssignExpression) //421:3
            {
                return "+="; //421:36
            }
            else if (expr is MetaSubtractAssignExpression) //422:3
            {
                return "-="; //422:41
            }
            else if (expr is MetaLeftShiftAssignExpression) //423:3
            {
                return "<<="; //423:42
            }
            else if (expr is MetaRightShiftAssignExpression) //424:3
            {
                return ">>="; //424:43
            }
            else if (expr is MetaAndAssignExpression) //425:3
            {
                return "&="; //425:36
            }
            else if (expr is MetaExclusiveOrAssignExpression) //426:3
            {
                return "^="; //426:44
            }
            else if (expr is MetaOrAssignExpression) //427:3
            {
                return "|="; //427:35
            }
            else //428:3
            {
                return ""; //428:12
            }//429:2
        }

        public string GetTypeName(MetaExpression expr) //432:1
        {
            if (expr is MetaTypeOfExpression) //433:2
            {
                return ((MetaTypeOfExpression)expr).TypeReference.CSharpFullName(); //433:36
            }
            else //434:2
            {
                return null; //434:7
            }
        }

        public MetaSynthetizedPropertyInitializer GetSynthetizedInitializerFor(MetaClass cls, MetaProperty prop) //438:1
        {
            MetaSynthetizedPropertyInitializer lastInit = null; //439:2
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((cls).GetEnumerator()) //440:7
                from sup in __Enumerate((__loop24_var1.GetAllSuperClasses(true)).GetEnumerator()) //440:12
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //440:42
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //440:55
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaSynthetizedPropertyInitializer>() //440:69
                select new { __loop24_var1 = __loop24_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //440:2
            int __loop24_iteration = 0;
            foreach (var __tmp1 in __loop24_results)
            {
                ++__loop24_iteration;
                var __loop24_var1 = __tmp1.__loop24_var1;
                var sup = __tmp1.sup;
                var Constructor = __tmp1.Constructor;
                var Initializers = __tmp1.Initializers;
                var init = __tmp1.init;
                if (init.Property == prop) //441:3
                {
                    lastInit = init; //442:4
                }
            }
            return lastInit; //445:2
        }

        public string GenerateConstructorImpl(MetaModel model, MetaClass cls) //448:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public "; //449:1
            string __tmp2Suffix = "() "; //449:30
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
                    __out.AppendLine(); //449:33
                }
            }
            __out.Append("{"); //450:1
            __out.AppendLine(); //450:2
            var __loop25_results = 
                (from __loop25_var1 in __Enumerate((cls).GetEnumerator()) //451:8
                from prop in __Enumerate((__loop25_var1.GetAllProperties()).GetEnumerator()) //451:13
                select new { __loop25_var1 = __loop25_var1, prop = prop}
                ).ToList(); //451:3
            int __loop25_iteration = 0;
            foreach (var __tmp4 in __loop25_results)
            {
                ++__loop25_iteration;
                var __loop25_var1 = __tmp4.__loop25_var1;
                var prop = __tmp4.prop;
                MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //452:4
                if (synInit != null) //453:4
                {
                    if (prop.Kind != MetaPropertyKind.Derived) //454:5
                    {
                        if (ModelContext.Current.Compiler.TypeProvider.GetTypeOf(synInit.Value) is MetaCollectionType) //455:6
                        {
                            string __tmp5Prefix = "    this.MLazySet("; //456:1
                            string __tmp6Suffix = "));"; //456:112
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
                            string __tmp8Line = ", new Lazy<object>(() => "; //456:52
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
                                    __out.AppendLine(); //456:115
                                }
                            }
                        }
                        else //457:6
                        {
                            string __tmp10Prefix = "    this.MLazySet("; //458:1
                            string __tmp11Suffix = "));"; //458:112
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
                            string __tmp13Line = ", new Lazy<object>(() => "; //458:52
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
                                    __out.AppendLine(); //458:115
                                }
                            }
                        }
                    }
                }
                else //461:4
                {
                    if (prop.Type is MetaCollectionType) //462:5
                    {
                        if (prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) //463:6
                        {
                            string __tmp15Prefix = "    this.MSet("; //464:1
                            string __tmp16Suffix = "));"; //464:117
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
                            string __tmp18Line = ", new "; //464:48
                            __out.Append(__tmp18Line);
                            StringBuilder __tmp19 = new StringBuilder();
                            __tmp19.Append(prop.Type.CSharpName());
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
                            string __tmp20Line = "("; //464:78
                            __out.Append(__tmp20Line);
                            StringBuilder __tmp21 = new StringBuilder();
                            __tmp21.Append(GetCollectionConstructorParams(prop));
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
                                    __out.AppendLine(); //464:120
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //465:6
                        {
                            string __tmp22Prefix = "    this.MLazySet("; //466:1
                            string __tmp23Suffix = "(this)));"; //466:164
                            StringBuilder __tmp24 = new StringBuilder();
                            __tmp24.Append(prop.CSharpFullDescriptorName());
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
                            string __tmp25Line = ", new Lazy<object>(() => "; //466:52
                            __out.Append(__tmp25Line);
                            StringBuilder __tmp26 = new StringBuilder();
                            __tmp26.Append(prop.Class.Model.CSharpFullImplementationName());
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
                            string __tmp27Line = "."; //466:126
                            __out.Append(__tmp27Line);
                            StringBuilder __tmp28 = new StringBuilder();
                            __tmp28.Append(prop.Class.CSharpName());
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
                            string __tmp29Line = "_"; //466:152
                            __out.Append(__tmp29Line);
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
                                    __out.Append(__tmp30Line);
                                    __out.Append(__tmp23Suffix);
                                    __out.AppendLine(); //466:173
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Readonly) //467:6
                        {
                            string __tmp31Prefix = "    // Init "; //468:1
                            string __tmp32Suffix = string.Empty; 
                            StringBuilder __tmp33 = new StringBuilder();
                            __tmp33.Append(prop.CSharpFullDescriptorName());
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
                            string __tmp34Line = " in "; //468:46
                            __out.Append(__tmp34Line);
                            StringBuilder __tmp35 = new StringBuilder();
                            __tmp35.Append(prop.Class.Model.CSharpFullImplementationName());
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
                            string __tmp36Line = "."; //468:99
                            __out.Append(__tmp36Line);
                            StringBuilder __tmp37 = new StringBuilder();
                            __tmp37.Append(cls.CSharpName());
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
                            string __tmp38Line = "_"; //468:118
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
                                    __out.Append(__tmp32Suffix);
                                    __out.AppendLine(); //468:137
                                }
                            }
                        }
                    }
                    else //470:5
                    {
                        if (prop.Kind == MetaPropertyKind.Lazy) //471:6
                        {
                            string __tmp40Prefix = "    this.MLazySet("; //472:1
                            string __tmp41Suffix = "(this)));"; //472:153
                            StringBuilder __tmp42 = new StringBuilder();
                            __tmp42.Append(prop.CSharpFullDescriptorName());
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
                                }
                            }
                            string __tmp43Line = ", new Lazy<object>(() => "; //472:52
                            __out.Append(__tmp43Line);
                            StringBuilder __tmp44 = new StringBuilder();
                            __tmp44.Append(model.CSharpFullImplementationName());
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
                            string __tmp45Line = "."; //472:115
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
                            string __tmp47Line = "_"; //472:141
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
                                    __out.Append(__tmp41Suffix);
                                    __out.AppendLine(); //472:162
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Readonly) //473:6
                        {
                            string __tmp49Prefix = "    // Init "; //474:1
                            string __tmp50Suffix = string.Empty; 
                            StringBuilder __tmp51 = new StringBuilder();
                            __tmp51.Append(prop.CSharpFullDescriptorName());
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
                                    __out.Append(__tmp49Prefix);
                                    __out.Append(__tmp51Line);
                                }
                            }
                            string __tmp52Line = " in "; //474:46
                            __out.Append(__tmp52Line);
                            StringBuilder __tmp53 = new StringBuilder();
                            __tmp53.Append(model.CSharpFullImplementationName());
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
                            string __tmp54Line = "."; //474:88
                            __out.Append(__tmp54Line);
                            StringBuilder __tmp55 = new StringBuilder();
                            __tmp55.Append(cls.CSharpName());
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
                            string __tmp56Line = "_"; //474:107
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
                                    __out.Append(__tmp50Suffix);
                                    __out.AppendLine(); //474:126
                                }
                            }
                        }
                    }
                }
            }
            var __loop26_results = 
                (from __loop26_var1 in __Enumerate((cls).GetEnumerator()) //479:8
                from sup in __Enumerate((__loop26_var1.GetAllSuperClasses(true)).GetEnumerator()) //479:13
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //479:43
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //479:56
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaInheritedPropertyInitializer>() //479:70
                select new { __loop26_var1 = __loop26_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //479:3
            int __loop26_iteration = 0;
            foreach (var __tmp58 in __loop26_results)
            {
                ++__loop26_iteration;
                var __loop26_var1 = __tmp58.__loop26_var1;
                var sup = __tmp58.sup;
                var Constructor = __tmp58.Constructor;
                var Initializers = __tmp58.Initializers;
                var init = __tmp58.init;
                if (init.Object != null && init.Property != null) //480:4
                {
                    string __tmp59Prefix = "    this.MLazySetChild("; //481:1
                    string __tmp60Suffix = "));"; //481:165
                    StringBuilder __tmp61 = new StringBuilder();
                    __tmp61.Append(init.Object.CSharpFullDescriptorName());
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
                            __out.Append(__tmp59Prefix);
                            __out.Append(__tmp61Line);
                        }
                    }
                    string __tmp62Line = ", "; //481:64
                    __out.Append(__tmp62Line);
                    StringBuilder __tmp63 = new StringBuilder();
                    __tmp63.Append(init.Property.CSharpFullDescriptorName());
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
                    string __tmp64Line = ", new Lazy<object>(() => "; //481:108
                    __out.Append(__tmp64Line);
                    StringBuilder __tmp65 = new StringBuilder();
                    __tmp65.Append(GenerateExpression(init.Value));
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
                            __out.Append(__tmp60Suffix);
                            __out.AppendLine(); //481:168
                        }
                    }
                }
            }
            string __tmp66Prefix = "    "; //484:1
            string __tmp67Suffix = "(this);"; //484:85
            StringBuilder __tmp68 = new StringBuilder();
            __tmp68.Append(cls.Model.CSharpFullImplementationName());
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
            string __tmp69Line = "."; //484:47
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
            string __tmp71Line = "_"; //484:66
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
                    __out.AppendLine(); //484:92
                }
            }
            var __loop27_results = 
                (from __loop27_var1 in __Enumerate((cls).GetEnumerator()) //485:11
                from prop in __Enumerate((__loop27_var1.GetAllProperties()).GetEnumerator()) //485:16
                select new { __loop27_var1 = __loop27_var1, prop = prop}
                ).ToList(); //485:6
            int __loop27_iteration = 0;
            foreach (var __tmp73 in __loop27_results)
            {
                ++__loop27_iteration;
                var __loop27_var1 = __tmp73.__loop27_var1;
                var prop = __tmp73.prop;
                if (prop.Kind == MetaPropertyKind.Readonly) //486:4
                {
                    string __tmp74Prefix = "    if (!this.MIsSet("; //487:1
                    string __tmp75Suffix = "().\");"; //487:221
                    StringBuilder __tmp76 = new StringBuilder();
                    __tmp76.Append(prop.CSharpFullDescriptorName());
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
                    string __tmp77Line = ")) throw new ModelException(\"Readonly property "; //487:55
                    __out.Append(__tmp77Line);
                    StringBuilder __tmp78 = new StringBuilder();
                    __tmp78.Append(model.CSharpName());
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
                    string __tmp79Line = "."; //487:122
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
                    string __tmp81Line = "."; //487:148
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
                    string __tmp83Line = "Property was not set in "; //487:160
                    __out.Append(__tmp83Line);
                    StringBuilder __tmp84 = new StringBuilder();
                    __tmp84.Append(cls.CSharpName());
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
                    string __tmp85Line = "_"; //487:202
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
                            __out.Append(__tmp75Suffix);
                            __out.AppendLine(); //487:227
                        }
                    }
                }
            }
            __out.Append("    this.MMakeDefault();"); //490:1
            __out.AppendLine(); //490:25
            __out.Append("}"); //491:1
            __out.AppendLine(); //491:2
            return __out.ToString();
        }

        public string GetReturn(MetaOperation op) //494:1
        {
            if (op.ReturnType.CSharpName() == "void") //495:5
            {
                return ""; //496:3
            }
            else //497:2
            {
                return "return "; //498:3
            }
        }

        public string GenerateOperationImpl(MetaModel model, MetaOperation op) //502:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //503:1
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = ")"; //504:105
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
            string __tmp4Line = " "; //504:39
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
            string __tmp6Line = "."; //504:68
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
            string __tmp8Line = "("; //504:78
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
                    __out.AppendLine(); //504:106
                }
            }
            __out.Append("{"); //505:1
            __out.AppendLine(); //505:2
            string __tmp10Prefix = "    "; //506:1
            string __tmp11Suffix = ");"; //506:125
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
            string __tmp14Line = "."; //506:58
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
            string __tmp16Line = "_"; //506:83
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
            string __tmp18Line = "("; //506:93
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
                    __out.AppendLine(); //506:127
                }
            }
            __out.Append("}"); //507:1
            __out.AppendLine(); //507:2
            return __out.ToString();
        }

        public string GetSuperClasses(MetaClass cls) //510:1
        {
            string result = ""; //511:2
            var __loop28_results = 
                (from __loop28_var1 in __Enumerate((cls).GetEnumerator()) //512:10
                from sup in __Enumerate((__loop28_var1.SuperClasses).GetEnumerator()) //512:15
                select new { __loop28_var1 = __loop28_var1, sup = sup}
                ).ToList(); //512:5
            int __loop28_iteration = 0;
            string delim = ""; //512:33
            foreach (var __tmp1 in __loop28_results)
            {
                ++__loop28_iteration;
                if (__loop28_iteration >= 2) //512:52
                {
                    delim = ", "; //512:52
                }
                var __loop28_var1 = __tmp1.__loop28_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpFullName(); //513:3
            }
            return result; //515:2
        }

        public string GetAllSuperClasses(MetaClass cls) //518:1
        {
            string result = ""; //519:2
            var __loop29_results = 
                (from __loop29_var1 in __Enumerate((cls).GetEnumerator()) //520:10
                from sup in __Enumerate((__loop29_var1.GetAllSuperClasses(false)).GetEnumerator()) //520:15
                select new { __loop29_var1 = __loop29_var1, sup = sup}
                ).ToList(); //520:5
            int __loop29_iteration = 0;
            string delim = ""; //520:46
            foreach (var __tmp1 in __loop29_results)
            {
                ++__loop29_iteration;
                if (__loop29_iteration >= 2) //520:65
                {
                    delim = ", "; //520:65
                }
                var __loop29_var1 = __tmp1.__loop29_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpFullName(); //521:3
            }
            return result; //523:2
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //526:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public static class "; //527:1
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
                    __out.AppendLine(); //527:51
                }
            }
            __out.Append("{"); //528:1
            __out.AppendLine(); //528:2
            string __tmp4Prefix = "    static "; //529:1
            string __tmp5Suffix = "Descriptor()"; //529:24
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
                    __out.AppendLine(); //529:36
                }
            }
            __out.Append("    {"); //530:1
            __out.AppendLine(); //530:6
            var __loop30_results = 
                (from __loop30_var1 in __Enumerate((model).GetEnumerator()) //531:11
                from Namespace in __Enumerate((__loop30_var1.Namespace).GetEnumerator()) //531:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //531:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //531:43
                select new { __loop30_var1 = __loop30_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //531:6
            int __loop30_iteration = 0;
            foreach (var __tmp7 in __loop30_results)
            {
                ++__loop30_iteration;
                var __loop30_var1 = __tmp7.__loop30_var1;
                var Namespace = __tmp7.Namespace;
                var Declarations = __tmp7.Declarations;
                var cls = __tmp7.cls;
                string __tmp8Prefix = "        "; //532:1
                string __tmp9Suffix = ".StaticInit();"; //532:27
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
                        __out.AppendLine(); //532:41
                    }
                }
            }
            __out.Append("    }"); //534:1
            __out.AppendLine(); //534:6
            __out.AppendLine(); //535:1
            __out.Append("    internal static void StaticInit()"); //536:1
            __out.AppendLine(); //536:38
            __out.Append("    {"); //537:1
            __out.AppendLine(); //537:6
            __out.Append("    }"); //538:1
            __out.AppendLine(); //538:6
            __out.AppendLine(); //539:1
            string __tmp11Prefix = "	public const string Uri = \""; //540:1
            string __tmp12Suffix = "\";"; //540:40
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
                    __out.AppendLine(); //540:42
                }
            }
            __out.AppendLine(); //541:1
            var __loop31_results = 
                (from __loop31_var1 in __Enumerate((model).GetEnumerator()) //542:11
                from Namespace in __Enumerate((__loop31_var1.Namespace).GetEnumerator()) //542:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //542:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //542:43
                select new { __loop31_var1 = __loop31_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //542:6
            int __loop31_iteration = 0;
            foreach (var __tmp14 in __loop31_results)
            {
                ++__loop31_iteration;
                var __loop31_var1 = __tmp14.__loop31_var1;
                var Namespace = __tmp14.Namespace;
                var Declarations = __tmp14.Declarations;
                var cls = __tmp14.cls;
                string __tmp15Prefix = "    "; //543:1
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
                        __out.AppendLine(); //543:34
                    }
                }
            }
            __out.Append("}"); //545:1
            __out.AppendLine(); //545:2
            __out.AppendLine(); //546:1
            return __out.ToString();
        }

        public string GenerateMetaModelClass(MetaClass cls) //550:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //551:1
            string __tmp1Prefix = "public static class "; //552:1
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
                    __out.AppendLine(); //552:39
                }
            }
            __out.Append("{"); //553:1
            __out.AppendLine(); //553:2
            __out.Append("    internal static void StaticInit()"); //554:1
            __out.AppendLine(); //554:38
            __out.Append("    {"); //555:1
            __out.AppendLine(); //555:6
            __out.Append("    }"); //556:1
            __out.AppendLine(); //556:6
            __out.AppendLine(); //557:1
            string __tmp4Prefix = "    static "; //558:1
            string __tmp5Suffix = "()"; //558:30
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
                    __out.AppendLine(); //558:32
                }
            }
            __out.Append("    {"); //559:1
            __out.AppendLine(); //559:6
            string __tmp7Prefix = "        "; //560:1
            string __tmp8Suffix = ".StaticInit();"; //560:47
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
                    __out.AppendLine(); //560:61
                }
            }
            __out.Append("    }"); //561:1
            __out.AppendLine(); //561:6
            __out.AppendLine(); //562:1
            if (cls.CSharpName() == "MetaClass") //563:2
            {
                __out.Append("    public static global::MetaDslx.Core.MetaClass _MetaClass"); //564:1
                __out.AppendLine(); //564:61
            }
            else //565:2
            {
                __out.Append("    public static global::MetaDslx.Core.MetaClass MetaClass"); //566:1
                __out.AppendLine(); //566:60
            }
            __out.Append("    {"); //568:1
            __out.AppendLine(); //568:6
            string __tmp10Prefix = "        get { return "; //569:1
            string __tmp11Suffix = "; }"; //569:52
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
                    __out.AppendLine(); //569:55
                }
            }
            __out.Append("    }"); //570:1
            __out.AppendLine(); //570:6
            __out.AppendLine(); //571:1
            var __loop32_results = 
                (from __loop32_var1 in __Enumerate((cls).GetEnumerator()) //572:11
                from prop in __Enumerate((__loop32_var1.Properties).GetEnumerator()) //572:16
                select new { __loop32_var1 = __loop32_var1, prop = prop}
                ).ToList(); //572:6
            int __loop32_iteration = 0;
            foreach (var __tmp13 in __loop32_results)
            {
                ++__loop32_iteration;
                var __loop32_var1 = __tmp13.__loop32_var1;
                var prop = __tmp13.prop;
                string __tmp14Prefix = "    "; //573:1
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
                        __out.AppendLine(); //573:56
                    }
                }
            }
            __out.Append("}"); //575:1
            __out.AppendLine(); //575:2
            return __out.ToString();
        }

        public string GenerateModelConstant(MetaModel model, MetaConstant mconst) //579:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public static readonly "; //580:1
            string __tmp2Suffix = ";"; //580:68
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
            string __tmp4Line = " "; //580:54
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
                    __out.AppendLine(); //580:69
                }
            }
            return __out.ToString();
        }

        public string GenerateModelFunction(MetaModel model, MetaGlobalFunction mfunc) //583:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public static readonly "; //584:1
            string __tmp2Suffix = ";"; //584:87
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
            string __tmp4Line = " "; //584:74
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
                    __out.AppendLine(); //584:88
                }
            }
            return __out.ToString();
        }

        public string GenerateModelConstantImpl(MetaModel model, MetaConstant mconst, Dictionary<ModelObject,string> mobjToTmp) //587:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = ";"; //588:51
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
            string __tmp4Line = " = "; //588:14
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
                    __out.AppendLine(); //588:52
                }
            }
            return __out.ToString();
        }

        public string GenerateModelFunctionImpl(MetaModel model, MetaGlobalFunction mfunc, Dictionary<ModelObject,string> mobjToTmp) //591:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = "();"; //592:131
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
            string __tmp4Line = " = "; //592:65
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
                    __out.AppendLine(); //592:134
                }
            }
            return __out.ToString();
        }

        public string GenerateMetaModelInstance(MetaModel model) //596:1
        {
            StringBuilder __out = new StringBuilder();
            Dictionary<ModelObject,string> mobjToTmp = new Dictionary<ModelObject,string>(); //597:2
            string __tmp1Prefix = "public static class "; //598:1
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
                    __out.AppendLine(); //598:50
                }
            }
            __out.Append("{"); //599:1
            __out.AppendLine(); //599:2
            __out.Append("    private static global::MetaDslx.Core.Model model;"); //600:1
            __out.AppendLine(); //600:54
            __out.AppendLine(); //601:1
            __out.Append("    public static global::MetaDslx.Core.Model Model"); //602:1
            __out.AppendLine(); //602:52
            __out.Append("    {"); //603:1
            __out.AppendLine(); //603:6
            string __tmp4Prefix = "        get { return "; //604:1
            string __tmp5Suffix = "Instance.model; }"; //604:34
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
                    __out.AppendLine(); //604:51
                }
            }
            __out.Append("    }"); //605:1
            __out.AppendLine(); //605:6
            __out.AppendLine(); //606:1
            __out.Append("    public static readonly global::MetaDslx.Core.MetaModel Meta;"); //607:1
            __out.AppendLine(); //607:65
            __out.AppendLine(); //608:1
            var __loop33_results = 
                (from __loop33_var1 in __Enumerate((model).GetEnumerator()) //609:11
                from Namespace in __Enumerate((__loop33_var1.Namespace).GetEnumerator()) //609:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //609:29
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //609:43
                select new { __loop33_var1 = __loop33_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //609:6
            int __loop33_iteration = 0;
            foreach (var __tmp7 in __loop33_results)
            {
                ++__loop33_iteration;
                var __loop33_var1 = __tmp7.__loop33_var1;
                var Namespace = __tmp7.Namespace;
                var Declarations = __tmp7.Declarations;
                var c = __tmp7.c;
                string __tmp8Prefix = "    "; //610:1
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
                        __out.AppendLine(); //610:38
                    }
                }
            }
            __out.AppendLine(); //612:1
            string __tmp11Prefix = "	"; //613:1
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
                    __out.AppendLine(); //613:94
                }
            }
            __out.AppendLine(); //614:1
            var __loop34_results = 
                (from __loop34_var1 in __Enumerate((model).GetEnumerator()) //615:8
                from Namespace in __Enumerate((__loop34_var1.Namespace).GetEnumerator()) //615:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //615:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //615:40
                from prop in __Enumerate((cls.Properties).GetEnumerator()) //615:63
                where !HasBuiltInName((ModelObject)prop) //615:79
                select new { __loop34_var1 = __loop34_var1, Namespace = Namespace, Declarations = Declarations, cls = cls, prop = prop}
                ).ToList(); //615:3
            int __loop34_iteration = 0;
            foreach (var __tmp14 in __loop34_results)
            {
                ++__loop34_iteration;
                var __loop34_var1 = __tmp14.__loop34_var1;
                var Namespace = __tmp14.Namespace;
                var Declarations = __tmp14.Declarations;
                var cls = __tmp14.cls;
                var prop = __tmp14.prop;
                string __tmp15Prefix = "	public static readonly global::MetaDslx.Core.MetaProperty "; //616:1
                string __tmp16Suffix = "Property;"; //616:90
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
                string __tmp18Line = "_"; //616:78
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
                        __out.AppendLine(); //616:99
                    }
                }
            }
            __out.AppendLine(); //618:1
            string __tmp20Prefix = "    static "; //619:1
            string __tmp21Suffix = "()"; //619:41
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
                    __out.AppendLine(); //619:43
                }
            }
            __out.Append("    {"); //620:1
            __out.AppendLine(); //620:6
            string __tmp23Prefix = "		"; //621:1
            string __tmp24Suffix = ".StaticInit();"; //621:33
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
                    __out.AppendLine(); //621:47
                }
            }
            string __tmp26Prefix = "		"; //622:1
            string __tmp27Suffix = ".model = new global::MetaDslx.Core.Model();"; //622:32
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
                    __out.AppendLine(); //622:75
                }
            }
            string __tmp29Prefix = "   		using (new ModelContextScope("; //623:1
            string __tmp30Suffix = ".model))"; //623:64
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
                    __out.AppendLine(); //623:72
                }
            }
            __out.Append("		{"); //624:1
            __out.AppendLine(); //624:4
            var __loop35_results = 
                (from __loop35_var1 in __Enumerate((model).GetEnumerator()) //625:13
                from Namespace in __Enumerate((__loop35_var1.Namespace).GetEnumerator()) //625:20
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //625:31
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //625:45
                select new { __loop35_var1 = __loop35_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //625:8
            int __loop35_iteration = 0;
            foreach (var __tmp32 in __loop35_results)
            {
                ++__loop35_iteration;
                var __loop35_var1 = __tmp32.__loop35_var1;
                var Namespace = __tmp32.Namespace;
                var Declarations = __tmp32.Declarations;
                var c = __tmp32.c;
                string __tmp33Prefix = "            "; //626:1
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
                        __out.AppendLine(); //626:61
                    }
                }
            }
            __out.AppendLine(); //628:1
            string __tmp36Prefix = "			"; //629:1
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
                    __out.AppendLine(); //629:85
                }
            }
            __out.AppendLine(); //630:1
            string __tmp39Prefix = "			"; //631:1
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
                    __out.AppendLine(); //631:96
                }
            }
            __out.AppendLine(); //632:1
            __out.Append("            foreach (var mo in ModelContext.Current.Model.Instances)"); //633:1
            __out.AppendLine(); //633:69
            __out.Append("            {"); //634:1
            __out.AppendLine(); //634:14
            __out.Append("                mo.MEvalLazyValues();"); //635:1
            __out.AppendLine(); //635:38
            __out.Append("            }"); //636:1
            __out.AppendLine(); //636:14
            __out.Append("		}"); //637:1
            __out.AppendLine(); //637:4
            __out.Append("    }"); //638:1
            __out.AppendLine(); //638:6
            __out.Append("}"); //639:1
            __out.AppendLine(); //639:2
            return __out.ToString();
        }

        public string RegisterModelObject(ModelObject mobj, Dictionary<ModelObject,string> mobjToTmp, string name) //642:1
        {
            if (!mobjToTmp.ContainsKey(mobj)) //643:2
            {
                string tmpName = name; //644:3
                mobjToTmp.Add(mobj, tmpName); //645:3
                return tmpName; //646:3
            }
            else //647:2
            {
                return mobjToTmp[mobj]; //648:3
            }
        }

        public bool HasBuiltInName(ModelObject mobj) //652:1
        {
            MetaAnnotatedElement mannot = mobj as MetaAnnotatedElement; //653:2
            if (mannot != null && !(mobj is MetaConstant)) //654:2
            {
                var __loop36_results = 
                    (from __loop36_var1 in __Enumerate((mannot).GetEnumerator()) //655:8
                    from a in __Enumerate((__loop36_var1.Annotations).GetEnumerator()) //655:16
                    from p in __Enumerate((a.Properties).GetEnumerator()) //655:31
                    where a.Name == "BuiltInName" && p.Name == "Name" //655:44
                    select new { __loop36_var1 = __loop36_var1, a = a, p = p}
                    ).ToList(); //655:3
                int __loop36_iteration = 0;
                foreach (var __tmp1 in __loop36_results)
                {
                    ++__loop36_iteration;
                    var __loop36_var1 = __tmp1.__loop36_var1;
                    var a = __tmp1.a;
                    var p = __tmp1.p;
                    return true; //656:4
                }
            }
            MetaDeclaration mdecl = mobj as MetaDeclaration; //659:2
            if (mdecl != null && !(mdecl is MetaOperation) && !(mdecl is MetaConstant)) //660:2
            {
                return true; //661:3
            }
            return false; //663:2
        }

        public string GetInstanceName(ModelObject mobj) //666:1
        {
            MetaAnnotatedElement mannot = mobj as MetaAnnotatedElement; //667:2
            if (mannot != null && !(mobj is MetaConstant)) //668:2
            {
                var __loop37_results = 
                    (from __loop37_var1 in __Enumerate((mannot).GetEnumerator()) //669:8
                    from a in __Enumerate((__loop37_var1.Annotations).GetEnumerator()) //669:16
                    from p in __Enumerate((a.Properties).GetEnumerator()) //669:31
                    where a.Name == "BuiltInName" && p.Name == "Name" //669:44
                    select new { __loop37_var1 = __loop37_var1, a = a, p = p}
                    ).ToList(); //669:3
                int __loop37_iteration = 0;
                foreach (var __tmp1 in __loop37_results)
                {
                    ++__loop37_iteration;
                    var __loop37_var1 = __tmp1.__loop37_var1;
                    var a = __tmp1.a;
                    var p = __tmp1.p;
                    return GetCSharpIdentifier(p.Value); //670:4
                }
            }
            MetaDeclaration mdecl = mobj as MetaDeclaration; //673:2
            if (mdecl != null && !(mdecl is MetaOperation) && !(mobj is MetaConstant)) //674:2
            {
                return mdecl.CSharpInstanceName(); //675:3
            }
            MetaProperty mprop = mobj as MetaProperty; //677:2
            if (mprop != null) //678:2
            {
                return mprop.CSharpInstanceName(); //679:3
            }
            return null; //681:2
        }

        public string RegisterModelObject(ModelObject mobj, Dictionary<ModelObject,string> mobjToTmp) //684:1
        {
            if (!mobjToTmp.ContainsKey(mobj)) //685:2
            {
                string name = GetInstanceName(mobj); //686:3
                if (name == null) //687:3
                {
                    name = "tmp" + NextCounter(); //688:4
                }
                mobjToTmp.Add(mobj, name); //690:3
                return name; //691:3
            }
            else //692:2
            {
                return null; //693:3
            }
        }

        public string GenerateModelObjectInstanceDeclaration(ModelObject mobj, Dictionary<ModelObject,string> mobjToTmp) //697:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //698:2
            {
                if (!Instances.Contains(mobj)) //699:3
                {
                }
                else //700:3
                {
                    if (HasBuiltInName(mobj)) //701:4
                    {
                        string tmpName = RegisterModelObject(mobj, mobjToTmp); //702:5
                        if (tmpName != null) //703:5
                        {
                            if (tmpName.StartsWith("tmp")) //704:6
                            {
                            }
                            else //705:6
                            {
                                string __tmp1Prefix = "public static readonly global::MetaDslx.Core."; //706:1
                                string __tmp2Suffix = ";"; //706:86
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
                                string __tmp4Line = " "; //706:76
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
                                        __out.AppendLine(); //706:87
                                    }
                                }
                            }
                        }
                    }
                    var __loop38_results = 
                        (from __loop38_var1 in __Enumerate((mobj).GetEnumerator()) //710:9
                        from child in __Enumerate((__loop38_var1.MChildren).GetEnumerator()) //710:15
                        select new { __loop38_var1 = __loop38_var1, child = child}
                        ).ToList(); //710:4
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
                                __out.AppendLine(); //711:59
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstance(ModelObject mobj, Dictionary<ModelObject,string> mobjToTmp) //717:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //718:2
            {
                if (!Instances.Contains(mobj)) //719:3
                {
                    string metaClassName = mobj.MMetaClass.Name; //720:4
                    if (mobj is MetaDeclaration || mobj is MetaProperty) //721:4
                    {
                        if (mobj is MetaProperty) //722:5
                        {
                            string tmpName = RegisterModelObject(mobj, mobjToTmp, ((MetaProperty)mobj).CSharpInstanceName()); //723:2
                        }
                        else //724:5
                        {
                            string tmpName = RegisterModelObject(mobj, mobjToTmp, ((MetaDeclaration)mobj).CSharpInstanceName()); //725:2
                        }
                    }
                    else //727:4
                    {
                        string __tmp1Prefix = "// OMITTED: "; //728:1
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
                                __out.AppendLine(); //728:28
                            }
                        }
                    }
                }
                else //730:3
                {
                    string tmpName = null; //731:4
                    if (mobjToTmp.ContainsKey(mobj)) //732:4
                    {
                        tmpName = mobjToTmp[mobj];
                    }
                    else //734:4
                    {
                        tmpName = RegisterModelObject(mobj, mobjToTmp);
                    }
                    if (tmpName != null) //737:4
                    {
                        if (tmpName.StartsWith("tmp")) //738:5
                        {
                            string __tmp4Prefix = "global::MetaDslx.Core."; //739:1
                            string __tmp5Suffix = "();"; //739:145
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
                            string __tmp7Line = " "; //739:53
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
                            string __tmp9Line = " = global::MetaDslx.Core.MetaFactory.Instance.Create"; //739:63
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
                                    __out.AppendLine(); //739:148
                                }
                            }
                        }
                        else //740:5
                        {
                            string __tmp11Prefix = string.Empty; 
                            string __tmp12Suffix = "();"; //741:92
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
                            string __tmp14Line = " = global::MetaDslx.Core.MetaFactory.Instance.Create"; //741:10
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
                                    __out.AppendLine(); //741:95
                                }
                            }
                        }
                        if (mobj is MetaModel) //743:5
                        {
                            string __tmp16Prefix = "Meta = "; //744:1
                            string __tmp17Suffix = ";"; //744:17
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
                                    __out.AppendLine(); //744:18
                                }
                            }
                        }
                        var __loop39_results = 
                            (from __loop39_var1 in __Enumerate((mobj).GetEnumerator()) //746:10
                            from child in __Enumerate((__loop39_var1.MChildren).GetEnumerator()) //746:16
                            select new { __loop39_var1 = __loop39_var1, child = child}
                            ).ToList(); //746:5
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
                                    __out.AppendLine(); //747:48
                                }
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceInitializer(ModelObject mobj, Dictionary<ModelObject,string> mobjToTmp) //754:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //755:2
            {
                if (!Instances.Contains(mobj)) //756:3
                {
                }
                else //757:3
                {
                    var __loop40_results = 
                        (from __loop40_var1 in __Enumerate((mobj).GetEnumerator()) //758:9
                        from prop in __Enumerate((__loop40_var1.MGetAllProperties()).GetEnumerator()) //758:15
                        select new { __loop40_var1 = __loop40_var1, prop = prop}
                        ).ToList(); //758:4
                    int __loop40_iteration = 0;
                    foreach (var __tmp1 in __loop40_results)
                    {
                        ++__loop40_iteration;
                        var __loop40_var1 = __tmp1.__loop40_var1;
                        var prop = __tmp1.prop;
                        if (prop.MetaProperty != null && prop.MetaProperty.Kind != MetaPropertyKind.Derived) //759:5
                        {
                            object propValue = mobj.MGet(prop); //760:6
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
                                    __out.AppendLine(); //761:69
                                }
                            }
                        }
                    }
                    var __loop41_results = 
                        (from __loop41_var1 in __Enumerate((mobj).GetEnumerator()) //764:9
                        from child in __Enumerate((__loop41_var1.MChildren).GetEnumerator()) //764:15
                        select new { __loop41_var1 = __loop41_var1, child = child}
                        ).ToList(); //764:4
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
                                __out.AppendLine(); //765:59
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectPropertyValue(ModelObject mobj, ModelProperty prop, object value, Dictionary<ModelObject,string> mobjToTmp) //771:1
        {
            StringBuilder __out = new StringBuilder();
            string tmpName = mobjToTmp[mobj]; //772:2
            string propDeclName = "global::" + prop.DeclaringType.FullName.Replace("+", ".") + "." + prop.DeclaredName; //773:2
            if (!prop.IsCollection) //774:2
            {
                string __tmp1Prefix = "((ModelObject)"; //775:1
                string __tmp2Suffix = ");"; //775:47
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
                string __tmp4Line = ").MUnSet("; //775:24
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
                        __out.AppendLine(); //775:49
                    }
                }
            }
            ModelObject moValue = value as ModelObject; //777:2
            if (value == null) //778:2
            {
                string __tmp6Prefix = "((ModelObject)"; //779:1
                string __tmp7Suffix = ", new Lazy<object>(() => null));"; //779:49
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
                string __tmp9Line = ").MLazyAdd("; //779:24
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
                        __out.AppendLine(); //779:81
                    }
                }
            }
            else if (value is string) //780:2
            {
                string __tmp11Prefix = "((ModelObject)"; //781:1
                string __tmp12Suffix = "\"));"; //781:82
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
                string __tmp14Line = ").MLazyAdd("; //781:24
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
                string __tmp16Line = ", new Lazy<object>(() => \""; //781:49
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
                        __out.AppendLine(); //781:86
                    }
                }
            }
            else if (value is bool) //782:2
            {
                string __tmp18Prefix = "((ModelObject)"; //783:1
                string __tmp19Suffix = "));"; //783:102
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
                string __tmp21Line = ").MLazyAdd("; //783:24
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
                string __tmp23Line = ", new Lazy<object>(() => "; //783:49
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
                        __out.AppendLine(); //783:105
                    }
                }
            }
            else if (value.GetType().IsPrimitive) //784:2
            {
                string __tmp25Prefix = "((ModelObject)"; //785:1
                string __tmp26Suffix = "));"; //785:92
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
                string __tmp28Line = ").MLazyAdd("; //785:24
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
                string __tmp30Line = ", new Lazy<object>(() => "; //785:49
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
                        __out.AppendLine(); //785:95
                    }
                }
            }
            else if (MetaBuiltInTypes.Types.Contains(value)) //786:2
            {
                string __tmp32Prefix = "((ModelObject)"; //787:1
                string __tmp33Suffix = "));"; //787:97
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
                string __tmp35Line = ").MLazyAdd("; //787:24
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
                string __tmp37Line = ", new Lazy<object>(() => "; //787:49
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
                        __out.AppendLine(); //787:100
                    }
                }
            }
            else if (value is MetaPrimitiveType) //788:2
            {
                string __tmp39Prefix = "((ModelObject)"; //789:1
                string __tmp40Suffix = "));"; //789:97
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
                string __tmp42Line = ").MLazyAdd("; //789:24
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
                string __tmp44Line = ", new Lazy<object>(() => "; //789:49
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
                        __out.AppendLine(); //789:100
                    }
                }
            }
            else if (value is Enum) //790:2
            {
                string __tmp46Prefix = "((ModelObject)"; //791:1
                string __tmp47Suffix = "));"; //791:97
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
                string __tmp49Line = ").MLazyAdd("; //791:24
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
                string __tmp51Line = ", new Lazy<object>(() => "; //791:49
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
                        __out.AppendLine(); //791:100
                    }
                }
            }
            else if (moValue != null) //792:2
            {
                if (mobjToTmp.ContainsKey(moValue)) //793:3
                {
                    string __tmp53Prefix = "((ModelObject)"; //794:1
                    string __tmp54Suffix = "));"; //794:94
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
                    string __tmp56Line = ").MLazyAdd("; //794:24
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
                    string __tmp58Line = ", new Lazy<object>(() => "; //794:49
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
                            __out.AppendLine(); //794:97
                        }
                    }
                }
                else //795:3
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
                            __out.AppendLine(); //796:50
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
                            __out.AppendLine(); //797:61
                        }
                    }
                    if (mobjToTmp.ContainsKey(moValue)) //798:4
                    {
                        string tmpValueName = mobjToTmp[moValue]; //799:5
                        string __tmp66Prefix = "((ModelObject)"; //800:1
                        string __tmp67Suffix = "));"; //800:88
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
                        string __tmp69Line = ").MLazyAdd("; //800:24
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
                        string __tmp71Line = ", new Lazy<object>(() => "; //800:49
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
                                __out.AppendLine(); //800:91
                            }
                        }
                    }
                    else //801:4
                    {
                        string __tmp73Prefix = "// NOT FOUND: "; //802:1
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
                    var __loop42_results = 
                        (from cvalue in __Enumerate((mc).GetEnumerator()) //808:9
                        select new { cvalue = cvalue}
                        ).ToList(); //808:4
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
                                __out.AppendLine(); //809:66
                            }
                        }
                    }
                }
                else //811:3
                {
                    string __tmp80Prefix = "// "; //812:1
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
                    string __tmp83Line = " = "; //812:18
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
                            __out.AppendLine(); //812:38
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GetEnumValueOf(object enm) //817:1
        {
            return "global::" + enm.GetType().FullName.Replace("+", ".") + "." + enm.ToString(); //818:2
        }

        public string GenerateClassMetaInstance(MetaClass cls) //821:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = " = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();"; //822:19
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
                    __out.AppendLine(); //822:83
                }
            }
            return __out.ToString();
        }

        public string GenerateClassMetaInstanceInitializer(MetaClass cls) //825:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = "\";"; //826:46
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
            string __tmp4Line = ".Name = \""; //826:19
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
                    __out.AppendLine(); //826:48
                }
            }
            if (cls.IsAbstract) //827:2
            {
                string __tmp6Prefix = string.Empty; 
                string __tmp7Suffix = ".IsAbstract = true;"; //828:19
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
                        __out.AppendLine(); //828:38
                    }
                }
            }
            var __loop43_results = 
                (from __loop43_var1 in __Enumerate((cls).GetEnumerator()) //830:7
                from sup in __Enumerate((__loop43_var1.SuperClasses).GetEnumerator()) //830:12
                select new { __loop43_var1 = __loop43_var1, sup = sup}
                ).ToList(); //830:2
            int __loop43_iteration = 0;
            foreach (var __tmp9 in __loop43_results)
            {
                ++__loop43_iteration;
                var __loop43_var1 = __tmp9.__loop43_var1;
                var sup = __tmp9.sup;
                string __tmp10Prefix = string.Empty; 
                string __tmp11Suffix = ");"; //831:67
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
                string __tmp13Line = ".SuperClasses.Add("; //831:19
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
                        __out.AppendLine(); //831:69
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //836:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "internal static class "; //837:1
            string __tmp2Suffix = "ImplementationProvider"; //837:35
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
                    __out.AppendLine(); //837:57
                }
            }
            __out.Append("{"); //838:1
            __out.AppendLine(); //838:2
            string __tmp4Prefix = "    // If there is a compile error at this line, create a new class called "; //839:1
            string __tmp5Suffix = "Implementation"; //839:88
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
                    __out.AppendLine(); //839:102
                }
            }
            string __tmp7Prefix = "	// which is a subclass of "; //840:1
            string __tmp8Suffix = "ImplementationBase:"; //840:40
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
                    __out.AppendLine(); //840:59
                }
            }
            string __tmp10Prefix = "    private static "; //841:1
            string __tmp11Suffix = "Implementation();"; //841:80
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
            string __tmp13Line = "Implementation implementation = new "; //841:32
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
                    __out.AppendLine(); //841:97
                }
            }
            __out.AppendLine(); //842:1
            string __tmp15Prefix = "    public static "; //843:1
            string __tmp16Suffix = "Implementation Implementation"; //843:31
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
                    __out.AppendLine(); //843:60
                }
            }
            __out.Append("    {"); //844:1
            __out.AppendLine(); //844:6
            string __tmp18Prefix = "        get { return "; //845:1
            string __tmp19Suffix = "ImplementationProvider.implementation; }"; //845:34
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
                    __out.AppendLine(); //845:74
                }
            }
            __out.Append("    }"); //846:1
            __out.AppendLine(); //846:6
            __out.Append("}"); //847:1
            __out.AppendLine(); //847:2
            var __loop44_results = 
                (from __loop44_var1 in __Enumerate((model).GetEnumerator()) //848:8
                from Namespace in __Enumerate((__loop44_var1.Namespace).GetEnumerator()) //848:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //848:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //848:40
                select new { __loop44_var1 = __loop44_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //848:3
            int __loop44_iteration = 0;
            foreach (var __tmp21 in __loop44_results)
            {
                ++__loop44_iteration;
                var __loop44_var1 = __tmp21.__loop44_var1;
                var Namespace = __tmp21.Namespace;
                var Declarations = __tmp21.Declarations;
                var enm = __tmp21.enm;
                __out.AppendLine(); //849:1
                string __tmp22Prefix = "public static class "; //850:1
                string __tmp23Suffix = "Extensions"; //850:31
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
                        __out.AppendLine(); //850:41
                    }
                }
                __out.Append("{"); //851:1
                __out.AppendLine(); //851:2
                var __loop45_results = 
                    (from __loop45_var1 in __Enumerate((enm).GetEnumerator()) //852:11
                    from op in __Enumerate((__loop45_var1.Operations).GetEnumerator()) //852:16
                    select new { __loop45_var1 = __loop45_var1, op = op}
                    ).ToList(); //852:6
                int __loop45_iteration = 0;
                foreach (var __tmp25 in __loop45_results)
                {
                    ++__loop45_iteration;
                    var __loop45_var1 = __tmp25.__loop45_var1;
                    var op = __tmp25.op;
                    string __tmp26Prefix = "    public static "; //853:1
                    string __tmp27Suffix = ")"; //853:100
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
                    string __tmp29Line = " "; //853:57
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
                    string __tmp31Line = "("; //853:67
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
                            __out.AppendLine(); //853:101
                        }
                    }
                    __out.Append("    {"); //854:1
                    __out.AppendLine(); //854:6
                    string __tmp33Prefix = "        "; //855:1
                    string __tmp34Suffix = ");"; //855:144
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
                    string __tmp37Line = "ImplementationProvider.Implementation."; //855:36
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
                    string __tmp39Line = "_"; //855:98
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
                    string __tmp41Line = "("; //855:108
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
                            __out.AppendLine(); //855:146
                        }
                    }
                    __out.Append("    }"); //856:1
                    __out.AppendLine(); //856:6
                }
                __out.Append("}"); //858:1
                __out.AppendLine(); //858:2
            }
            __out.AppendLine(); //860:1
            __out.Append("/// <summary>"); //861:1
            __out.AppendLine(); //861:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //862:1
            __out.AppendLine(); //862:68
            string __tmp43Prefix = "/// This class has to be be overriden in "; //863:1
            string __tmp44Suffix = "Implementation to provide custom"; //863:54
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
                    __out.AppendLine(); //863:86
                }
            }
            __out.Append("/// implementation for the constructors, operations and property values."); //864:1
            __out.AppendLine(); //864:73
            __out.Append("/// </summary>"); //865:1
            __out.AppendLine(); //865:15
            string __tmp46Prefix = "internal abstract class "; //866:1
            string __tmp47Suffix = "ImplementationBase"; //866:37
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
                    __out.AppendLine(); //866:55
                }
            }
            __out.Append("{"); //867:1
            __out.AppendLine(); //867:2
            var __loop46_results = 
                (from __loop46_var1 in __Enumerate((model).GetEnumerator()) //868:8
                from Namespace in __Enumerate((__loop46_var1.Namespace).GetEnumerator()) //868:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //868:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //868:40
                select new { __loop46_var1 = __loop46_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //868:3
            int __loop46_iteration = 0;
            foreach (var __tmp49 in __loop46_results)
            {
                ++__loop46_iteration;
                var __loop46_var1 = __tmp49.__loop46_var1;
                var Namespace = __tmp49.Namespace;
                var Declarations = __tmp49.Declarations;
                var cls = __tmp49.cls;
                __out.Append("    /// <summary>"); //869:1
                __out.AppendLine(); //869:18
                string __tmp50Prefix = "	/// Implements the constructor: "; //870:1
                string __tmp51Suffix = "()"; //870:52
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
                        __out.AppendLine(); //870:54
                    }
                }
                if ((from __loop47_var1 in __Enumerate((cls).GetEnumerator()) //871:15
                from sup in __Enumerate((__loop47_var1.SuperClasses).GetEnumerator()) //871:20
                select new { __loop47_var1 = __loop47_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //871:3
                {
                    string __tmp53Prefix = "	/// Direct superclasses: "; //872:1
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
                            __out.AppendLine(); //872:49
                        }
                    }
                    string __tmp56Prefix = "	/// All superclasses: "; //873:1
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
                            __out.AppendLine(); //873:49
                        }
                    }
                }
                if ((from __loop48_var1 in __Enumerate((cls).GetEnumerator()) //875:15
                from prop in __Enumerate((__loop48_var1.GetAllProperties()).GetEnumerator()) //875:20
                where prop.Kind == MetaPropertyKind.Readonly //875:44
                select new { __loop48_var1 = __loop48_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //875:3
                {
                    __out.Append("    /// Initializes the following readonly properties:"); //876:1
                    __out.AppendLine(); //876:55
                }
                var __loop49_results = 
                    (from __loop49_var1 in __Enumerate((cls).GetEnumerator()) //878:11
                    from prop in __Enumerate((__loop49_var1.GetAllProperties()).GetEnumerator()) //878:16
                    select new { __loop49_var1 = __loop49_var1, prop = prop}
                    ).ToList(); //878:6
                int __loop49_iteration = 0;
                foreach (var __tmp59 in __loop49_results)
                {
                    ++__loop49_iteration;
                    var __loop49_var1 = __tmp59.__loop49_var1;
                    var prop = __tmp59.prop;
                    if (prop.Kind == MetaPropertyKind.Readonly) //879:3
                    {
                        string __tmp60Prefix = "    ///    "; //880:1
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
                        string __tmp63Line = "."; //880:29
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
                                __out.AppendLine(); //880:41
                            }
                        }
                    }
                }
                __out.Append("    /// </summary>"); //883:1
                __out.AppendLine(); //883:19
                string __tmp65Prefix = "    public virtual void "; //884:1
                string __tmp66Suffix = " @this)"; //884:81
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
                string __tmp68Line = "_"; //884:43
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
                string __tmp70Line = "("; //884:62
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
                        __out.AppendLine(); //884:88
                    }
                }
                __out.Append("    {"); //885:1
                __out.AppendLine(); //885:6
                var __loop50_results = 
                    (from __loop50_var1 in __Enumerate((cls).GetEnumerator()) //886:9
                    from sup in __Enumerate((__loop50_var1.SuperClasses).GetEnumerator()) //886:14
                    select new { __loop50_var1 = __loop50_var1, sup = sup}
                    ).ToList(); //886:4
                int __loop50_iteration = 0;
                foreach (var __tmp72 in __loop50_results)
                {
                    ++__loop50_iteration;
                    var __loop50_var1 = __tmp72.__loop50_var1;
                    var sup = __tmp72.sup;
                    string __tmp73Prefix = "        this."; //887:1
                    string __tmp74Suffix = "(@this);"; //887:51
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
                    string __tmp76Line = "_"; //887:32
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
                            __out.AppendLine(); //887:59
                        }
                    }
                }
                __out.Append("    }"); //889:1
                __out.AppendLine(); //889:6
                var __loop51_results = 
                    (from __loop51_var1 in __Enumerate((cls).GetEnumerator()) //890:11
                    from prop in __Enumerate((__loop51_var1.Properties).GetEnumerator()) //890:16
                    select new { __loop51_var1 = __loop51_var1, prop = prop}
                    ).ToList(); //890:6
                int __loop51_iteration = 0;
                foreach (var __tmp78 in __loop51_results)
                {
                    ++__loop51_iteration;
                    var __loop51_var1 = __tmp78.__loop51_var1;
                    var prop = __tmp78.prop;
                    MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //891:4
                    if (synInit == null) //892:4
                    {
                        if (prop.Kind == MetaPropertyKind.Derived) //893:5
                        {
                            __out.AppendLine(); //894:1
                            __out.Append("    /// <summary>"); //895:1
                            __out.AppendLine(); //895:18
                            string __tmp79Prefix = "    /// Returns the value of the derived property: "; //896:1
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
                            string __tmp82Line = "."; //896:70
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
                                    __out.AppendLine(); //896:82
                                }
                            }
                            __out.Append("    /// </summary>"); //897:1
                            __out.AppendLine(); //897:19
                            string __tmp84Prefix = "    public virtual "; //898:1
                            string __tmp85Suffix = " @this)"; //898:104
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
                            string __tmp87Line = " "; //898:54
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
                            string __tmp89Line = "_"; //898:73
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
                            string __tmp91Line = "("; //898:85
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
                                    __out.AppendLine(); //898:111
                                }
                            }
                            __out.Append("    {"); //899:1
                            __out.AppendLine(); //899:6
                            __out.Append("        throw new NotImplementedException();"); //900:1
                            __out.AppendLine(); //900:45
                            __out.Append("    }"); //901:1
                            __out.AppendLine(); //901:6
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //902:5
                        {
                            __out.AppendLine(); //903:1
                            __out.Append("    /// <summary>"); //904:1
                            __out.AppendLine(); //904:18
                            string __tmp93Prefix = "    /// Returns the value of the lazy property: "; //905:1
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
                            string __tmp96Line = "."; //905:67
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
                                    __out.AppendLine(); //905:79
                                }
                            }
                            __out.Append("    /// </summary>"); //906:1
                            __out.AppendLine(); //906:19
                            string __tmp98Prefix = "    public virtual "; //907:1
                            string __tmp99Suffix = " @this)"; //907:104
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
                            string __tmp101Line = " "; //907:54
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
                            string __tmp103Line = "_"; //907:73
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
                            string __tmp105Line = "("; //907:85
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
                                    __out.AppendLine(); //907:111
                                }
                            }
                            __out.Append("    {"); //908:1
                            __out.AppendLine(); //908:6
                            __out.Append("        throw new NotImplementedException();"); //909:1
                            __out.AppendLine(); //909:45
                            __out.Append("    }"); //910:1
                            __out.AppendLine(); //910:6
                        }
                    }
                }
                var __loop52_results = 
                    (from __loop52_var1 in __Enumerate((cls).GetEnumerator()) //914:11
                    from op in __Enumerate((__loop52_var1.Operations).GetEnumerator()) //914:16
                    select new { __loop52_var1 = __loop52_var1, op = op}
                    ).ToList(); //914:6
                int __loop52_iteration = 0;
                foreach (var __tmp107 in __loop52_results)
                {
                    ++__loop52_iteration;
                    var __loop52_var1 = __tmp107.__loop52_var1;
                    var op = __tmp107.op;
                    __out.AppendLine(); //915:1
                    __out.Append("    /// <summary>"); //916:1
                    __out.AppendLine(); //916:18
                    string __tmp108Prefix = "    /// Implements the operation: "; //917:1
                    string __tmp109Suffix = "()"; //917:63
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
                    string __tmp111Line = "."; //917:53
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
                            __out.AppendLine(); //917:65
                        }
                    }
                    __out.Append("    /// </summary>"); //918:1
                    __out.AppendLine(); //918:19
                    string __tmp113Prefix = "    public virtual "; //919:1
                    string __tmp114Suffix = ")"; //919:116
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
                    string __tmp116Line = " "; //919:58
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
                    string __tmp118Line = "_"; //919:77
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
                    string __tmp120Line = "("; //919:87
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
                            __out.AppendLine(); //919:117
                        }
                    }
                    __out.Append("    {"); //920:1
                    __out.AppendLine(); //920:6
                    __out.Append("        throw new NotImplementedException();"); //921:1
                    __out.AppendLine(); //921:45
                    __out.Append("    }"); //922:1
                    __out.AppendLine(); //922:6
                }
                __out.AppendLine(); //924:1
            }
            var __loop53_results = 
                (from __loop53_var1 in __Enumerate((model).GetEnumerator()) //926:8
                from Namespace in __Enumerate((__loop53_var1.Namespace).GetEnumerator()) //926:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //926:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //926:40
                select new { __loop53_var1 = __loop53_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //926:3
            int __loop53_iteration = 0;
            foreach (var __tmp122 in __loop53_results)
            {
                ++__loop53_iteration;
                var __loop53_var1 = __tmp122.__loop53_var1;
                var Namespace = __tmp122.Namespace;
                var Declarations = __tmp122.Declarations;
                var enm = __tmp122.enm;
                var __loop54_results = 
                    (from __loop54_var1 in __Enumerate((enm).GetEnumerator()) //927:11
                    from op in __Enumerate((__loop54_var1.Operations).GetEnumerator()) //927:16
                    select new { __loop54_var1 = __loop54_var1, op = op}
                    ).ToList(); //927:6
                int __loop54_iteration = 0;
                foreach (var __tmp123 in __loop54_results)
                {
                    ++__loop54_iteration;
                    var __loop54_var1 = __tmp123.__loop54_var1;
                    var op = __tmp123.op;
                    __out.AppendLine(); //928:1
                    __out.Append("    /// <summary>"); //929:1
                    __out.AppendLine(); //929:18
                    string __tmp124Prefix = "    /// Implements the operation: "; //930:1
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
                    string __tmp127Line = "."; //930:53
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
                            __out.AppendLine(); //930:63
                        }
                    }
                    __out.Append("    /// </summary>"); //931:1
                    __out.AppendLine(); //931:19
                    string __tmp129Prefix = "    public virtual "; //932:1
                    string __tmp130Suffix = ")"; //932:116
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
                    string __tmp132Line = " "; //932:58
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
                    string __tmp134Line = "_"; //932:77
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
                    string __tmp136Line = "("; //932:87
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
                            __out.AppendLine(); //932:117
                        }
                    }
                    __out.Append("    {"); //933:1
                    __out.AppendLine(); //933:6
                    __out.Append("        throw new NotImplementedException();"); //934:1
                    __out.AppendLine(); //934:45
                    __out.Append("    }"); //935:1
                    __out.AppendLine(); //935:6
                }
                __out.AppendLine(); //937:1
            }
            __out.Append("}"); //939:1
            __out.AppendLine(); //939:2
            __out.AppendLine(); //940:1
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //943:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //944:1
            __out.AppendLine(); //944:14
            __out.Append("/// Factory class for creating instances of model elements."); //945:1
            __out.AppendLine(); //945:60
            __out.Append("/// </summary>"); //946:1
            __out.AppendLine(); //946:15
            string __tmp1Prefix = "public class "; //947:1
            string __tmp2Suffix = " : ModelFactory"; //947:41
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
                    __out.AppendLine(); //947:56
                }
            }
            __out.Append("{"); //948:1
            __out.AppendLine(); //948:2
            string __tmp4Prefix = "    private static "; //949:1
            string __tmp5Suffix = "();"; //949:90
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
            string __tmp7Line = " instance = new "; //949:47
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
                    __out.AppendLine(); //949:93
                }
            }
            __out.AppendLine(); //950:1
            string __tmp9Prefix = "	private "; //951:1
            string __tmp10Suffix = "()"; //951:37
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
                    __out.AppendLine(); //951:39
                }
            }
            __out.Append("	{"); //952:1
            __out.AppendLine(); //952:3
            __out.Append("	}"); //953:1
            __out.AppendLine(); //953:3
            __out.AppendLine(); //954:1
            __out.Append("    /// <summary>"); //955:1
            __out.AppendLine(); //955:18
            __out.Append("    /// The singleton instance of the factory."); //956:1
            __out.AppendLine(); //956:47
            __out.Append("    /// </summary>"); //957:1
            __out.AppendLine(); //957:19
            string __tmp12Prefix = "    public static "; //958:1
            string __tmp13Suffix = " Instance"; //958:46
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
                    __out.AppendLine(); //958:55
                }
            }
            __out.Append("    {"); //959:1
            __out.AppendLine(); //959:6
            string __tmp15Prefix = "        get { return "; //960:1
            string __tmp16Suffix = ".instance; }"; //960:49
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
                    __out.AppendLine(); //960:61
                }
            }
            __out.Append("    }"); //961:1
            __out.AppendLine(); //961:6
            var __loop55_results = 
                (from __loop55_var1 in __Enumerate((model).GetEnumerator()) //962:8
                from Namespace in __Enumerate((__loop55_var1.Namespace).GetEnumerator()) //962:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //962:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //962:40
                select new { __loop55_var1 = __loop55_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //962:3
            int __loop55_iteration = 0;
            foreach (var __tmp18 in __loop55_results)
            {
                ++__loop55_iteration;
                var __loop55_var1 = __tmp18.__loop55_var1;
                var Namespace = __tmp18.Namespace;
                var Declarations = __tmp18.Declarations;
                var cls = __tmp18.cls;
                if (!cls.IsAbstract) //963:4
                {
                    __out.AppendLine(); //964:1
                    __out.Append("    /// <summary>"); //965:1
                    __out.AppendLine(); //965:18
                    string __tmp19Prefix = "    /// Creates a new instance of "; //966:1
                    string __tmp20Suffix = "."; //966:53
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
                            __out.AppendLine(); //966:54
                        }
                    }
                    __out.Append("    /// </summary>"); //967:1
                    __out.AppendLine(); //967:19
                    string __tmp22Prefix = "    public "; //968:1
                    string __tmp23Suffix = "(IEnumerable<ModelPropertyInitializer> initializers = null)"; //968:55
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
                    string __tmp25Line = " Create"; //968:30
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
                            __out.AppendLine(); //968:114
                        }
                    }
                    __out.Append("	{"); //969:1
                    __out.AppendLine(); //969:3
                    string __tmp27Prefix = "		"; //970:1
                    string __tmp28Suffix = "Impl();"; //970:57
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
                    string __tmp30Line = " result = new "; //970:21
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
                            __out.AppendLine(); //970:64
                        }
                    }
                    __out.Append("		if (initializers != null)"); //971:1
                    __out.AppendLine(); //971:28
                    __out.Append("		{"); //972:1
                    __out.AppendLine(); //972:4
                    __out.Append("			this.Init((ModelObject)result, initializers);"); //973:1
                    __out.AppendLine(); //973:49
                    __out.Append("		}"); //974:1
                    __out.AppendLine(); //974:4
                    __out.Append("		return result;"); //975:1
                    __out.AppendLine(); //975:17
                    __out.Append("	}"); //976:1
                    __out.AppendLine(); //976:3
                }
            }
            __out.Append("}"); //979:1
            __out.AppendLine(); //979:2
            __out.AppendLine(); //980:1
            return __out.ToString();
        }

    }
}
