using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core //1:1
{
    using __Hidden_MetaModelCSharpGenerator_1445279605;
    namespace __Hidden_MetaModelCSharpGenerator_1445279605
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
                            if (string.IsNullOrEmpty(__tmp2Prefix) && string.IsNullOrEmpty(__tmp3Suffix)) break;
                            else __tmp4Line = "";
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp3Line = "";
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
                        if (string.IsNullOrEmpty(__tmp4Prefix) && string.IsNullOrEmpty(__tmp5Suffix)) break;
                        else __tmp6Line = "";
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
                        if (string.IsNullOrEmpty(__tmp7Prefix) && string.IsNullOrEmpty(__tmp8Suffix)) break;
                        else __tmp9Line = "";
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
                            if (string.IsNullOrEmpty(__tmp11Prefix) && string.IsNullOrEmpty(__tmp12Suffix)) break;
                            else __tmp13Line = "";
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
                            if (string.IsNullOrEmpty(__tmp15Prefix) && string.IsNullOrEmpty(__tmp16Suffix)) break;
                            else __tmp17Line = "";
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
                            if (string.IsNullOrEmpty(__tmp18Prefix) && string.IsNullOrEmpty(__tmp19Suffix)) break;
                            else __tmp20Line = "";
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
                        if (string.IsNullOrEmpty(__tmp21Prefix) && string.IsNullOrEmpty(__tmp22Suffix)) break;
                        else __tmp23Line = "";
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
                        if (string.IsNullOrEmpty(__tmp24Prefix) && string.IsNullOrEmpty(__tmp25Suffix)) break;
                        else __tmp26Line = "";
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

        public string GenerateDocumentation(MetaDocumentedElement elem) //36:1
        {
            StringBuilder __out = new StringBuilder();
            IList<string> lines = elem.GetDocumentationLines(); //37:2
            if (lines.Count > 0) //38:2
            {
                __out.Append("/**"); //39:1
                __out.AppendLine(); //39:4
                var __loop4_results = 
                    (from line in __Enumerate((lines).GetEnumerator()) //40:8
                    select new { line = line}
                    ).ToList(); //40:3
                int __loop4_iteration = 0;
                foreach (var __tmp1 in __loop4_results)
                {
                    ++__loop4_iteration;
                    var line = __tmp1.line;
                    string __tmp2Prefix = " * "; //41:1
                    string __tmp3Suffix = string.Empty; 
                    StringBuilder __tmp4 = new StringBuilder();
                    __tmp4.Append(line);
                    using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                    {
                        bool __tmp4_first = true;
                        while(__tmp4_first || !__tmp4Reader.EndOfStream)
                        {
                            __tmp4_first = false;
                            string __tmp4Line = __tmp4Reader.ReadLine();
                            if (__tmp4Line == null)
                            {
                                if (string.IsNullOrEmpty(__tmp2Prefix) && string.IsNullOrEmpty(__tmp3Suffix)) break;
                                else __tmp4Line = "";
                            }
                            __out.Append(__tmp2Prefix);
                            __out.Append(__tmp4Line);
                            __out.Append(__tmp3Suffix);
                            __out.AppendLine(); //41:10
                        }
                    }
                }
                __out.Append(" */"); //43:1
                __out.AppendLine(); //43:4
            }
            return __out.ToString();
        }

        public string GenerateAnnotations(MetaAnnotatedElement elem) //47:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop5_results = 
                (from __loop5_var1 in __Enumerate((elem).GetEnumerator()) //48:7
                from annot in __Enumerate((__loop5_var1.Annotations).GetEnumerator()) //48:13
                select new { __loop5_var1 = __loop5_var1, annot = annot}
                ).ToList(); //48:2
            int __loop5_iteration = 0;
            foreach (var __tmp1 in __loop5_results)
            {
                ++__loop5_iteration;
                var __loop5_var1 = __tmp1.__loop5_var1;
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
                            if (string.IsNullOrEmpty(__tmp2Prefix) && string.IsNullOrEmpty(__tmp3Suffix)) break;
                            else __tmp4Line = "";
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
                            if (string.IsNullOrEmpty(__tmp2Prefix) && string.IsNullOrEmpty(__tmp3Suffix)) break;
                            else __tmp5Line = "";
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
                            if (string.IsNullOrEmpty(__tmp2Prefix) && string.IsNullOrEmpty(__tmp3Suffix)) break;
                            else __tmp6Line = "";
                        }
                        __out.Append(__tmp6Line);
                        __out.Append(__tmp3Suffix);
                        __out.AppendLine(); //49:23
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateEnum(MetaEnum enm) //53:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty;
            string __tmp2Suffix = string.Empty;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateDocumentation(enm));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //54:29
                }
            }
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
                        if (string.IsNullOrEmpty(__tmp4Prefix) && string.IsNullOrEmpty(__tmp5Suffix)) break;
                        else __tmp6Line = "";
                    }
                    __out.Append(__tmp4Prefix);
                    __out.Append(__tmp6Line);
                    __out.Append(__tmp5Suffix);
                    __out.AppendLine(); //55:27
                }
            }
            string __tmp7Prefix = "public enum "; //56:1
            string __tmp8Suffix = string.Empty; 
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(enm.CSharpName());
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_first = true;
                while(__tmp9_first || !__tmp9Reader.EndOfStream)
                {
                    __tmp9_first = false;
                    string __tmp9Line = __tmp9Reader.ReadLine();
                    if (__tmp9Line == null)
                    {
                        if (string.IsNullOrEmpty(__tmp7Prefix) && string.IsNullOrEmpty(__tmp8Suffix)) break;
                        else __tmp9Line = "";
                    }
                    __out.Append(__tmp7Prefix);
                    __out.Append(__tmp9Line);
                    __out.Append(__tmp8Suffix);
                    __out.AppendLine(); //56:31
                }
            }
            __out.Append("{"); //57:1
            __out.AppendLine(); //57:2
            var __loop6_results = 
                (from __loop6_var1 in __Enumerate((enm).GetEnumerator()) //58:11
                from value in __Enumerate((__loop6_var1.EnumLiterals).GetEnumerator()) //58:16
                select new { __loop6_var1 = __loop6_var1, value = value}
                ).ToList(); //58:6
            int __loop6_iteration = 0;
            foreach (var __tmp10 in __loop6_results)
            {
                ++__loop6_iteration;
                var __loop6_var1 = __tmp10.__loop6_var1;
                var value = __tmp10.value;
                string __tmp11Prefix = "    "; //59:1
                string __tmp12Suffix = ","; //59:17
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(value.Name);
                using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                {
                    bool __tmp13_first = true;
                    while(__tmp13_first || !__tmp13Reader.EndOfStream)
                    {
                        __tmp13_first = false;
                        string __tmp13Line = __tmp13Reader.ReadLine();
                        if (__tmp13Line == null)
                        {
                            if (string.IsNullOrEmpty(__tmp11Prefix) && string.IsNullOrEmpty(__tmp12Suffix)) break;
                            else __tmp13Line = "";
                        }
                        __out.Append(__tmp11Prefix);
                        __out.Append(__tmp13Line);
                        __out.Append(__tmp12Suffix);
                        __out.AppendLine(); //59:18
                    }
                }
            }
            __out.Append("}"); //61:1
            __out.AppendLine(); //61:2
            __out.AppendLine(); //62:1
            return __out.ToString();
        }

        public string GetAncestors(MetaClass cls) //65:1
        {
            string result = ""; //66:2
            var __loop7_results = 
                (from __loop7_var1 in __Enumerate((cls).GetEnumerator()) //67:7
                from super in __Enumerate((__loop7_var1.SuperClasses).GetEnumerator()) //67:12
                select new { __loop7_var1 = __loop7_var1, super = super}
                ).ToList(); //67:2
            int __loop7_iteration = 0;
            string delim = " : "; //67:32
            foreach (var __tmp1 in __loop7_results)
            {
                ++__loop7_iteration;
                if (__loop7_iteration >= 2) //67:54
                {
                    delim = ", "; //67:54
                }
                var __loop7_var1 = __tmp1.__loop7_var1;
                var super = __tmp1.super;
                result += delim + super.CSharpFullName(); //68:3
            }
            return result; //70:2
        }

        public string GenerateInterface(MetaClass cls) //73:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty;
            string __tmp2Suffix = string.Empty;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateDocumentation(cls));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //74:29
                }
            }
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
                        if (string.IsNullOrEmpty(__tmp4Prefix) && string.IsNullOrEmpty(__tmp5Suffix)) break;
                        else __tmp6Line = "";
                    }
                    __out.Append(__tmp4Prefix);
                    __out.Append(__tmp6Line);
                    __out.Append(__tmp5Suffix);
                    __out.AppendLine(); //75:27
                }
            }
            string __tmp7Prefix = "public interface "; //76:1
            string __tmp8Suffix = string.Empty; 
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(cls.CSharpName());
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_first = true;
                while(__tmp9_first || !__tmp9Reader.EndOfStream)
                {
                    __tmp9_first = false;
                    string __tmp9Line = __tmp9Reader.ReadLine();
                    if (__tmp9Line == null)
                    {
                        if (string.IsNullOrEmpty(__tmp7Prefix) && string.IsNullOrEmpty(__tmp8Suffix)) break;
                        else __tmp9Line = "";
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
                        if (string.IsNullOrEmpty(__tmp7Prefix) && string.IsNullOrEmpty(__tmp8Suffix)) break;
                        else __tmp10Line = "";
                    }
                    __out.Append(__tmp10Line);
                    __out.Append(__tmp8Suffix);
                    __out.AppendLine(); //76:55
                }
            }
            __out.Append("{"); //77:1
            __out.AppendLine(); //77:2
            var __loop8_results = 
                (from __loop8_var1 in __Enumerate((cls).GetEnumerator()) //78:11
                from prop in __Enumerate((__loop8_var1.Properties).GetEnumerator()) //78:16
                select new { __loop8_var1 = __loop8_var1, prop = prop}
                ).ToList(); //78:6
            int __loop8_iteration = 0;
            foreach (var __tmp11 in __loop8_results)
            {
                ++__loop8_iteration;
                var __loop8_var1 = __tmp11.__loop8_var1;
                var prop = __tmp11.prop;
                string __tmp12Prefix = "    "; //79:1
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
                            if (string.IsNullOrEmpty(__tmp12Prefix) && string.IsNullOrEmpty(__tmp13Suffix)) break;
                            else __tmp14Line = "";
                        }
                        __out.Append(__tmp12Prefix);
                        __out.Append(__tmp14Line);
                        __out.Append(__tmp13Suffix);
                        __out.AppendLine(); //79:29
                    }
                }
            }
            __out.AppendLine(); //81:1
            var __loop9_results = 
                (from __loop9_var1 in __Enumerate((cls).GetEnumerator()) //82:11
                from op in __Enumerate((__loop9_var1.Operations).GetEnumerator()) //82:16
                select new { __loop9_var1 = __loop9_var1, op = op}
                ).ToList(); //82:6
            int __loop9_iteration = 0;
            foreach (var __tmp15 in __loop9_results)
            {
                ++__loop9_iteration;
                var __loop9_var1 = __tmp15.__loop9_var1;
                var op = __tmp15.op;
                string __tmp16Prefix = "    "; //83:1
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
                            if (string.IsNullOrEmpty(__tmp16Prefix) && string.IsNullOrEmpty(__tmp17Suffix)) break;
                            else __tmp18Line = "";
                        }
                        __out.Append(__tmp16Prefix);
                        __out.Append(__tmp18Line);
                        __out.Append(__tmp17Suffix);
                        __out.AppendLine(); //83:28
                    }
                }
            }
            __out.Append("}"); //85:1
            __out.AppendLine(); //85:2
            __out.AppendLine(); //86:1
            return __out.ToString();
        }

        public string GenerateProperty(MetaProperty prop) //89:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty;
            string __tmp2Suffix = string.Empty;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateDocumentation(prop));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //90:30
                }
            }
            if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //91:2
            {
                __out.Append("new "); //92:1
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //94:3
            {
                string __tmp4Prefix = string.Empty; 
                string __tmp5Suffix = " { get; set; }"; //95:47
                StringBuilder __tmp6 = new StringBuilder();
                __tmp6.Append(prop.Type.CSharpFullPublicName());
                using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
                {
                    bool __tmp6_first = true;
                    while(__tmp6_first || !__tmp6Reader.EndOfStream)
                    {
                        __tmp6_first = false;
                        string __tmp6Line = __tmp6Reader.ReadLine();
                        if (__tmp6Line == null)
                        {
                            if (string.IsNullOrEmpty(__tmp4Prefix) && string.IsNullOrEmpty(__tmp5Suffix)) break;
                            else __tmp6Line = "";
                        }
                        __out.Append(__tmp4Prefix);
                        __out.Append(__tmp6Line);
                    }
                }
                string __tmp7Line = " "; //95:35
                __out.Append(__tmp7Line);
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(prop.Name);
                using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                {
                    bool __tmp8_first = true;
                    while(__tmp8_first || !__tmp8Reader.EndOfStream)
                    {
                        __tmp8_first = false;
                        string __tmp8Line = __tmp8Reader.ReadLine();
                        if (__tmp8Line == null)
                        {
                            if (string.IsNullOrEmpty(__tmp4Prefix) && string.IsNullOrEmpty(__tmp5Suffix)) break;
                            else __tmp8Line = "";
                        }
                        __out.Append(__tmp8Line);
                        __out.Append(__tmp5Suffix);
                        __out.AppendLine(); //95:61
                    }
                }
            }
            else //96:3
            {
                string __tmp9Prefix = string.Empty; 
                string __tmp10Suffix = " { get; }"; //97:47
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(prop.Type.CSharpFullPublicName());
                using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                {
                    bool __tmp11_first = true;
                    while(__tmp11_first || !__tmp11Reader.EndOfStream)
                    {
                        __tmp11_first = false;
                        string __tmp11Line = __tmp11Reader.ReadLine();
                        if (__tmp11Line == null)
                        {
                            if (string.IsNullOrEmpty(__tmp9Prefix) && string.IsNullOrEmpty(__tmp10Suffix)) break;
                            else __tmp11Line = "";
                        }
                        __out.Append(__tmp9Prefix);
                        __out.Append(__tmp11Line);
                    }
                }
                string __tmp12Line = " "; //97:35
                __out.Append(__tmp12Line);
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(prop.Name);
                using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                {
                    bool __tmp13_first = true;
                    while(__tmp13_first || !__tmp13Reader.EndOfStream)
                    {
                        __tmp13_first = false;
                        string __tmp13Line = __tmp13Reader.ReadLine();
                        if (__tmp13Line == null)
                        {
                            if (string.IsNullOrEmpty(__tmp9Prefix) && string.IsNullOrEmpty(__tmp10Suffix)) break;
                            else __tmp13Line = "";
                        }
                        __out.Append(__tmp13Line);
                        __out.Append(__tmp10Suffix);
                        __out.AppendLine(); //97:56
                    }
                }
            }
            return __out.ToString();
        }

        public string GetParameters(MetaOperation op, bool defaultValues) //101:1
        {
            string result = ""; //102:2
            var __loop10_results = 
                (from __loop10_var1 in __Enumerate((op).GetEnumerator()) //103:7
                from param in __Enumerate((__loop10_var1.Parameters).GetEnumerator()) //103:11
                select new { __loop10_var1 = __loop10_var1, param = param}
                ).ToList(); //103:2
            int __loop10_iteration = 0;
            string delim = ""; //103:29
            foreach (var __tmp1 in __loop10_results)
            {
                ++__loop10_iteration;
                if (__loop10_iteration >= 2) //103:48
                {
                    delim = ", "; //103:48
                }
                var __loop10_var1 = __tmp1.__loop10_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName() + " " + param.Name; //104:3
            }
            return result; //109:2
        }

        public string GetImplParameters(MetaClass cls, MetaOperation op) //112:1
        {
            string result = cls.CSharpFullName() + " @this"; //113:2
            string delim = ", "; //114:2
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((op).GetEnumerator()) //115:7
                from param in __Enumerate((__loop11_var1.Parameters).GetEnumerator()) //115:11
                select new { __loop11_var1 = __loop11_var1, param = param}
                ).ToList(); //115:2
            int __loop11_iteration = 0;
            foreach (var __tmp1 in __loop11_results)
            {
                ++__loop11_iteration;
                var __loop11_var1 = __tmp1.__loop11_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName() + " " + param.Name; //116:3
            }
            return result; //118:2
        }

        public string GetImplParameters(MetaEnum enm, MetaOperation op) //121:1
        {
            string result = enm.CSharpFullName() + " @this"; //122:2
            string delim = ", "; //123:2
            var __loop12_results = 
                (from __loop12_var1 in __Enumerate((op).GetEnumerator()) //124:7
                from param in __Enumerate((__loop12_var1.Parameters).GetEnumerator()) //124:11
                select new { __loop12_var1 = __loop12_var1, param = param}
                ).ToList(); //124:2
            int __loop12_iteration = 0;
            foreach (var __tmp1 in __loop12_results)
            {
                ++__loop12_iteration;
                var __loop12_var1 = __tmp1.__loop12_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName() + " " + param.Name; //125:3
            }
            return result; //127:2
        }

        public string GetEnumImplParameters(MetaEnum enm, MetaOperation op) //130:1
        {
            string result = "this " + enm.CSharpFullName() + " @this"; //131:2
            string delim = ", "; //132:2
            var __loop13_results = 
                (from __loop13_var1 in __Enumerate((op).GetEnumerator()) //133:7
                from param in __Enumerate((__loop13_var1.Parameters).GetEnumerator()) //133:11
                select new { __loop13_var1 = __loop13_var1, param = param}
                ).ToList(); //133:2
            int __loop13_iteration = 0;
            foreach (var __tmp1 in __loop13_results)
            {
                ++__loop13_iteration;
                var __loop13_var1 = __tmp1.__loop13_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName() + " " + param.Name; //134:3
            }
            return result; //136:2
        }

        public string GetEnumImplCallParameterNames(MetaOperation op) //139:1
        {
            string result = "@this"; //140:2
            string delim = ", "; //141:2
            var __loop14_results = 
                (from __loop14_var1 in __Enumerate((op).GetEnumerator()) //142:7
                from param in __Enumerate((__loop14_var1.Parameters).GetEnumerator()) //142:11
                select new { __loop14_var1 = __loop14_var1, param = param}
                ).ToList(); //142:2
            int __loop14_iteration = 0;
            foreach (var __tmp1 in __loop14_results)
            {
                ++__loop14_iteration;
                var __loop14_var1 = __tmp1.__loop14_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //143:3
            }
            return result; //145:2
        }

        public string GetImplCallParameterNames(MetaOperation op) //148:1
        {
            string result = "this"; //149:2
            string delim = ", "; //150:2
            var __loop15_results = 
                (from __loop15_var1 in __Enumerate((op).GetEnumerator()) //151:7
                from param in __Enumerate((__loop15_var1.Parameters).GetEnumerator()) //151:11
                select new { __loop15_var1 = __loop15_var1, param = param}
                ).ToList(); //151:2
            int __loop15_iteration = 0;
            foreach (var __tmp1 in __loop15_results)
            {
                ++__loop15_iteration;
                var __loop15_var1 = __tmp1.__loop15_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //152:3
            }
            return result; //154:2
        }

        public string GenerateOperation(MetaOperation op) //157:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty;
            string __tmp2Suffix = string.Empty;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateDocumentation(op));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //158:28
                }
            }
            string __tmp4Prefix = string.Empty; 
            string __tmp5Suffix = ");"; //159:75
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(op.ReturnType.CSharpFullPublicName());
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                while(__tmp6_first || !__tmp6Reader.EndOfStream)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    if (__tmp6Line == null)
                    {
                        if (string.IsNullOrEmpty(__tmp4Prefix) && string.IsNullOrEmpty(__tmp5Suffix)) break;
                        else __tmp6Line = "";
                    }
                    __out.Append(__tmp4Prefix);
                    __out.Append(__tmp6Line);
                }
            }
            string __tmp7Line = " "; //159:39
            __out.Append(__tmp7Line);
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(op.Name);
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_first = true;
                while(__tmp8_first || !__tmp8Reader.EndOfStream)
                {
                    __tmp8_first = false;
                    string __tmp8Line = __tmp8Reader.ReadLine();
                    if (__tmp8Line == null)
                    {
                        if (string.IsNullOrEmpty(__tmp4Prefix) && string.IsNullOrEmpty(__tmp5Suffix)) break;
                        else __tmp8Line = "";
                    }
                    __out.Append(__tmp8Line);
                }
            }
            string __tmp9Line = "("; //159:49
            __out.Append(__tmp9Line);
            StringBuilder __tmp10 = new StringBuilder();
            __tmp10.Append(GetParameters(op, true));
            using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
            {
                bool __tmp10_first = true;
                while(__tmp10_first || !__tmp10Reader.EndOfStream)
                {
                    __tmp10_first = false;
                    string __tmp10Line = __tmp10Reader.ReadLine();
                    if (__tmp10Line == null)
                    {
                        if (string.IsNullOrEmpty(__tmp4Prefix) && string.IsNullOrEmpty(__tmp5Suffix)) break;
                        else __tmp10Line = "";
                    }
                    __out.Append(__tmp10Line);
                    __out.Append(__tmp5Suffix);
                    __out.AppendLine(); //159:77
                }
            }
            return __out.ToString();
        }

        public string GenerateInterfaceImpl(MetaModel model, MetaClass cls) //162:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "internal class "; //163:1
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                }
            }
            string __tmp4Line = " : ModelObject, "; //163:38
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp5Line = "";
                    }
                    __out.Append(__tmp5Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //163:76
                }
            }
            __out.Append("{"); //164:1
            __out.AppendLine(); //164:2
            string __tmp6Prefix = "    static "; //165:1
            string __tmp7Suffix = "()"; //165:34
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
                        if (string.IsNullOrEmpty(__tmp6Prefix) && string.IsNullOrEmpty(__tmp7Suffix)) break;
                        else __tmp8Line = "";
                    }
                    __out.Append(__tmp6Prefix);
                    __out.Append(__tmp8Line);
                    __out.Append(__tmp7Suffix);
                    __out.AppendLine(); //165:36
                }
            }
            __out.Append("    {"); //166:1
            __out.AppendLine(); //166:6
            string __tmp9Prefix = "        "; //167:1
            string __tmp10Suffix = ".StaticInit();"; //167:47
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
                        if (string.IsNullOrEmpty(__tmp9Prefix) && string.IsNullOrEmpty(__tmp10Suffix)) break;
                        else __tmp11Line = "";
                    }
                    __out.Append(__tmp9Prefix);
                    __out.Append(__tmp11Line);
                    __out.Append(__tmp10Suffix);
                    __out.AppendLine(); //167:61
                }
            }
            __out.Append("    }"); //168:1
            __out.AppendLine(); //168:6
            __out.AppendLine(); //169:1
            __out.Append("    public override global::MetaDslx.Core.MetaModel MMetaModel"); //170:1
            __out.AppendLine(); //170:63
            __out.Append("    {"); //171:1
            __out.AppendLine(); //171:6
            string __tmp12Prefix = "        get { return "; //172:1
            string __tmp13Suffix = "; }"; //172:58
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
                        if (string.IsNullOrEmpty(__tmp12Prefix) && string.IsNullOrEmpty(__tmp13Suffix)) break;
                        else __tmp14Line = "";
                    }
                    __out.Append(__tmp12Prefix);
                    __out.Append(__tmp14Line);
                    __out.Append(__tmp13Suffix);
                    __out.AppendLine(); //172:61
                }
            }
            __out.Append("    }"); //173:1
            __out.AppendLine(); //173:6
            __out.AppendLine(); //174:1
            __out.Append("    public override global::MetaDslx.Core.MetaClass MMetaClass"); //175:1
            __out.AppendLine(); //175:63
            __out.Append("    {"); //176:1
            __out.AppendLine(); //176:6
            string __tmp15Prefix = "        get { return "; //177:1
            string __tmp16Suffix = "; }"; //177:52
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
                        if (string.IsNullOrEmpty(__tmp15Prefix) && string.IsNullOrEmpty(__tmp16Suffix)) break;
                        else __tmp17Line = "";
                    }
                    __out.Append(__tmp15Prefix);
                    __out.Append(__tmp17Line);
                    __out.Append(__tmp16Suffix);
                    __out.AppendLine(); //177:55
                }
            }
            __out.Append("    }"); //178:1
            __out.AppendLine(); //178:6
            __out.AppendLine(); //179:1
            string __tmp18Prefix = "    "; //180:1
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
                        if (string.IsNullOrEmpty(__tmp18Prefix) && string.IsNullOrEmpty(__tmp19Suffix)) break;
                        else __tmp20Line = "";
                    }
                    __out.Append(__tmp18Prefix);
                    __out.Append(__tmp20Line);
                    __out.Append(__tmp19Suffix);
                    __out.AppendLine(); //180:42
                }
            }
            var __loop16_results = 
                (from __loop16_var1 in __Enumerate((cls).GetEnumerator()) //181:11
                from prop in __Enumerate((__loop16_var1.GetAllProperties()).GetEnumerator()) //181:16
                select new { __loop16_var1 = __loop16_var1, prop = prop}
                ).ToList(); //181:6
            int __loop16_iteration = 0;
            foreach (var __tmp21 in __loop16_results)
            {
                ++__loop16_iteration;
                var __loop16_var1 = __tmp21.__loop16_var1;
                var prop = __tmp21.prop;
                string __tmp22Prefix = "    "; //182:1
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
                            if (string.IsNullOrEmpty(__tmp22Prefix) && string.IsNullOrEmpty(__tmp23Suffix)) break;
                            else __tmp24Line = "";
                        }
                        __out.Append(__tmp22Prefix);
                        __out.Append(__tmp24Line);
                        __out.Append(__tmp23Suffix);
                        __out.AppendLine(); //182:45
                    }
                }
            }
            var __loop17_results = 
                (from __loop17_var1 in __Enumerate((cls).GetEnumerator()) //184:11
                from op in __Enumerate((__loop17_var1.GetAllOperations()).GetEnumerator()) //184:16
                select new { __loop17_var1 = __loop17_var1, op = op}
                ).ToList(); //184:6
            int __loop17_iteration = 0;
            foreach (var __tmp25 in __loop17_results)
            {
                ++__loop17_iteration;
                var __loop17_var1 = __tmp25.__loop17_var1;
                var op = __tmp25.op;
                string __tmp26Prefix = "    "; //185:1
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
                            if (string.IsNullOrEmpty(__tmp26Prefix) && string.IsNullOrEmpty(__tmp27Suffix)) break;
                            else __tmp28Line = "";
                        }
                        __out.Append(__tmp26Prefix);
                        __out.Append(__tmp28Line);
                        __out.Append(__tmp27Suffix);
                        __out.AppendLine(); //185:39
                    }
                }
            }
            __out.Append("}"); //187:1
            __out.AppendLine(); //187:2
            __out.AppendLine(); //188:1
            return __out.ToString();
        }

        public string GeneratePropertyDeclaration(MetaModel model, MetaClass cls, MetaProperty prop) //191:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class == cls) //192:2
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
                            if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                            else __tmp3Line = "";
                        }
                        __out.Append(__tmp1Prefix);
                        __out.Append(__tmp3Line);
                        __out.Append(__tmp2Suffix);
                        __out.AppendLine(); //193:28
                    }
                }
                if (prop.Kind == MetaPropertyKind.Containment) //194:2
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
                                if (string.IsNullOrEmpty(__tmp4Prefix) && string.IsNullOrEmpty(__tmp5Suffix)) break;
                                else __tmp6Line = "";
                            }
                            __out.Append(__tmp4Prefix);
                            __out.Append(__tmp6Line);
                            __out.Append(__tmp5Suffix);
                            __out.AppendLine(); //195:27
                        }
                    }
                }
                if (prop.Kind != MetaPropertyKind.Normal && prop.Kind != MetaPropertyKind.Containment) //197:2
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
                                if (string.IsNullOrEmpty(__tmp7Prefix) && string.IsNullOrEmpty(__tmp8Suffix)) break;
                                else __tmp9Line = "";
                            }
                            __out.Append(__tmp7Prefix);
                            __out.Append(__tmp9Line);
                            __out.Append(__tmp8Suffix);
                            __out.AppendLine(); //198:24
                        }
                    }
                }
                var __loop18_results = 
                    (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //200:7
                    select new { p = p}
                    ).ToList(); //200:2
                int __loop18_iteration = 0;
                foreach (var __tmp10 in __loop18_results)
                {
                    ++__loop18_iteration;
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
                                if (string.IsNullOrEmpty(__tmp11Prefix) && string.IsNullOrEmpty(__tmp12Suffix)) break;
                                else __tmp13Line = "";
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
                                if (string.IsNullOrEmpty(__tmp11Prefix) && string.IsNullOrEmpty(__tmp12Suffix)) break;
                                else __tmp14Line = "";
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
                                if (string.IsNullOrEmpty(__tmp11Prefix) && string.IsNullOrEmpty(__tmp12Suffix)) break;
                                else __tmp15Line = "";
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
                                if (string.IsNullOrEmpty(__tmp11Prefix) && string.IsNullOrEmpty(__tmp12Suffix)) break;
                                else __tmp16Line = "";
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
                                if (string.IsNullOrEmpty(__tmp11Prefix) && string.IsNullOrEmpty(__tmp12Suffix)) break;
                                else __tmp17Line = "";
                            }
                            __out.Append(__tmp17Line);
                            __out.Append(__tmp12Suffix);
                            __out.AppendLine(); //201:92
                        }
                    }
                }
                var __loop19_results = 
                    (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //203:7
                    select new { p = p}
                    ).ToList(); //203:2
                int __loop19_iteration = 0;
                foreach (var __tmp18 in __loop19_results)
                {
                    ++__loop19_iteration;
                    var p = __tmp18.p;
                    if (cls.GetAllSuperClasses(false).Contains(p.Class)) //204:3
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
                                    if (string.IsNullOrEmpty(__tmp19Prefix) && string.IsNullOrEmpty(__tmp20Suffix)) break;
                                    else __tmp21Line = "";
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
                                    if (string.IsNullOrEmpty(__tmp19Prefix) && string.IsNullOrEmpty(__tmp20Suffix)) break;
                                    else __tmp22Line = "";
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
                                    if (string.IsNullOrEmpty(__tmp19Prefix) && string.IsNullOrEmpty(__tmp20Suffix)) break;
                                    else __tmp23Line = "";
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
                                    if (string.IsNullOrEmpty(__tmp19Prefix) && string.IsNullOrEmpty(__tmp20Suffix)) break;
                                    else __tmp24Line = "";
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
                                    if (string.IsNullOrEmpty(__tmp19Prefix) && string.IsNullOrEmpty(__tmp20Suffix)) break;
                                    else __tmp25Line = "";
                                }
                                __out.Append(__tmp25Line);
                                __out.Append(__tmp20Suffix);
                                __out.AppendLine(); //205:91
                            }
                        }
                    }
                    else //206:3
                    {
                        string __tmp26Prefix = "// ERROR: subsetted property '"; //207:1
                        string __tmp27Suffix = "' must be a property of an ancestor class"; //207:61
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
                                    if (string.IsNullOrEmpty(__tmp26Prefix) && string.IsNullOrEmpty(__tmp27Suffix)) break;
                                    else __tmp28Line = "";
                                }
                                __out.Append(__tmp26Prefix);
                                __out.Append(__tmp28Line);
                                __out.Append(__tmp27Suffix);
                                __out.AppendLine(); //207:102
                            }
                        }
                    }
                }
                var __loop20_results = 
                    (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //210:7
                    select new { p = p}
                    ).ToList(); //210:2
                int __loop20_iteration = 0;
                foreach (var __tmp29 in __loop20_results)
                {
                    ++__loop20_iteration;
                    var p = __tmp29.p;
                    if (cls.GetAllSuperClasses(false).Contains(p.Class)) //211:3
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
                                    if (string.IsNullOrEmpty(__tmp30Prefix) && string.IsNullOrEmpty(__tmp31Suffix)) break;
                                    else __tmp32Line = "";
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
                                    if (string.IsNullOrEmpty(__tmp30Prefix) && string.IsNullOrEmpty(__tmp31Suffix)) break;
                                    else __tmp33Line = "";
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
                                    if (string.IsNullOrEmpty(__tmp30Prefix) && string.IsNullOrEmpty(__tmp31Suffix)) break;
                                    else __tmp34Line = "";
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
                                    if (string.IsNullOrEmpty(__tmp30Prefix) && string.IsNullOrEmpty(__tmp31Suffix)) break;
                                    else __tmp35Line = "";
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
                                    if (string.IsNullOrEmpty(__tmp30Prefix) && string.IsNullOrEmpty(__tmp31Suffix)) break;
                                    else __tmp36Line = "";
                                }
                                __out.Append(__tmp36Line);
                                __out.Append(__tmp31Suffix);
                                __out.AppendLine(); //212:93
                            }
                        }
                    }
                    else //213:3
                    {
                        string __tmp37Prefix = "// ERROR: redefined property '"; //214:1
                        string __tmp38Suffix = "' must be a property of an ancestor class"; //214:61
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
                                    if (string.IsNullOrEmpty(__tmp37Prefix) && string.IsNullOrEmpty(__tmp38Suffix)) break;
                                    else __tmp39Line = "";
                                }
                                __out.Append(__tmp37Prefix);
                                __out.Append(__tmp39Line);
                                __out.Append(__tmp38Suffix);
                                __out.AppendLine(); //214:102
                            }
                        }
                    }
                }
                string __tmp40Prefix = "public static readonly ModelProperty "; //217:1
                string __tmp41Suffix = "Property ="; //217:49
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
                            if (string.IsNullOrEmpty(__tmp40Prefix) && string.IsNullOrEmpty(__tmp41Suffix)) break;
                            else __tmp42Line = "";
                        }
                        __out.Append(__tmp40Prefix);
                        __out.Append(__tmp42Line);
                        __out.Append(__tmp41Suffix);
                        __out.AppendLine(); //217:59
                    }
                }
                string __tmp43Prefix = "    ModelProperty.Register(\""; //218:1
                string __tmp44Suffix = "Property, LazyThreadSafetyMode.ExecutionAndPublication));"; //218:339
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
                            if (string.IsNullOrEmpty(__tmp43Prefix) && string.IsNullOrEmpty(__tmp44Suffix)) break;
                            else __tmp45Line = "";
                        }
                        __out.Append(__tmp43Prefix);
                        __out.Append(__tmp45Line);
                    }
                }
                string __tmp46Line = "\", typeof("; //218:40
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
                            if (string.IsNullOrEmpty(__tmp43Prefix) && string.IsNullOrEmpty(__tmp44Suffix)) break;
                            else __tmp47Line = "";
                        }
                        __out.Append(__tmp47Line);
                    }
                }
                string __tmp48Line = "), typeof("; //218:84
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
                            if (string.IsNullOrEmpty(__tmp43Prefix) && string.IsNullOrEmpty(__tmp44Suffix)) break;
                            else __tmp49Line = "";
                        }
                        __out.Append(__tmp49Line);
                    }
                }
                string __tmp50Line = "), typeof("; //218:123
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
                            if (string.IsNullOrEmpty(__tmp43Prefix) && string.IsNullOrEmpty(__tmp44Suffix)) break;
                            else __tmp51Line = "";
                        }
                        __out.Append(__tmp51Line);
                    }
                }
                string __tmp52Line = "Descriptor."; //218:168
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
                            if (string.IsNullOrEmpty(__tmp43Prefix) && string.IsNullOrEmpty(__tmp44Suffix)) break;
                            else __tmp53Line = "";
                        }
                        __out.Append(__tmp53Line);
                    }
                }
                string __tmp54Line = "), new Lazy<global::MetaDslx.Core.MetaProperty>(() => "; //218:204
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
                            if (string.IsNullOrEmpty(__tmp43Prefix) && string.IsNullOrEmpty(__tmp44Suffix)) break;
                            else __tmp55Line = "";
                        }
                        __out.Append(__tmp55Line);
                    }
                }
                string __tmp56Line = "Instance."; //218:293
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
                            if (string.IsNullOrEmpty(__tmp43Prefix) && string.IsNullOrEmpty(__tmp44Suffix)) break;
                            else __tmp57Line = "";
                        }
                        __out.Append(__tmp57Line);
                    }
                }
                string __tmp58Line = "_"; //218:327
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
                            if (string.IsNullOrEmpty(__tmp43Prefix) && string.IsNullOrEmpty(__tmp44Suffix)) break;
                            else __tmp59Line = "";
                        }
                        __out.Append(__tmp59Line);
                        __out.Append(__tmp44Suffix);
                        __out.AppendLine(); //218:396
                    }
                }
            }
            __out.AppendLine(); //220:1
            return __out.ToString();
        }

        public string GeneratePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //223:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //224:1
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                }
            }
            string __tmp4Line = " "; //225:35
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp5Line = "";
                    }
                    __out.Append(__tmp5Line);
                }
            }
            string __tmp6Line = "."; //225:65
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp7Line = "";
                    }
                    __out.Append(__tmp7Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //225:77
                }
            }
            __out.Append("{"); //226:1
            __out.AppendLine(); //226:2
            __out.Append("    get "); //227:1
            __out.AppendLine(); //227:9
            __out.Append("    {"); //228:1
            __out.AppendLine(); //228:6
            string __tmp8Prefix = "        object result = this.MGet("; //229:1
            string __tmp9Suffix = "); "; //229:68
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
                        if (string.IsNullOrEmpty(__tmp8Prefix) && string.IsNullOrEmpty(__tmp9Suffix)) break;
                        else __tmp10Line = "";
                    }
                    __out.Append(__tmp8Prefix);
                    __out.Append(__tmp10Line);
                    __out.Append(__tmp9Suffix);
                    __out.AppendLine(); //229:71
                }
            }
            string __tmp11Prefix = "        if (result != null) return ("; //230:1
            string __tmp12Suffix = ")result;"; //230:71
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
                        if (string.IsNullOrEmpty(__tmp11Prefix) && string.IsNullOrEmpty(__tmp12Suffix)) break;
                        else __tmp13Line = "";
                    }
                    __out.Append(__tmp11Prefix);
                    __out.Append(__tmp13Line);
                    __out.Append(__tmp12Suffix);
                    __out.AppendLine(); //230:79
                }
            }
            string __tmp14Prefix = "        else return default("; //231:1
            string __tmp15Suffix = ");"; //231:63
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
                        if (string.IsNullOrEmpty(__tmp14Prefix) && string.IsNullOrEmpty(__tmp15Suffix)) break;
                        else __tmp16Line = "";
                    }
                    __out.Append(__tmp14Prefix);
                    __out.Append(__tmp16Line);
                    __out.Append(__tmp15Suffix);
                    __out.AppendLine(); //231:65
                }
            }
            __out.Append("    }"); //232:1
            __out.AppendLine(); //232:6
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //233:3
            {
                string __tmp17Prefix = "    set { this.MSet("; //234:1
                string __tmp18Suffix = ", value); }"; //234:54
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
                            if (string.IsNullOrEmpty(__tmp17Prefix) && string.IsNullOrEmpty(__tmp18Suffix)) break;
                            else __tmp19Line = "";
                        }
                        __out.Append(__tmp17Prefix);
                        __out.Append(__tmp19Line);
                        __out.Append(__tmp18Suffix);
                        __out.AppendLine(); //234:65
                    }
                }
            }
            __out.Append("}"); //236:1
            __out.AppendLine(); //236:2
            return __out.ToString();
        }

        public string GetCollectionConstructorParams(MetaProperty prop) //239:1
        {
            MetaCollectionType mct = prop.Type as MetaCollectionType; //240:2
            if (mct != null && mct.InnerType is MetaClass) //241:2
            {
                return "this, " + prop.CSharpFullDescriptorName(); //242:3
            }
            else //243:2
            {
                return ""; //244:3
            }
        }

        public string GenerateExpression(MetaExpression expr) //249:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //250:10
            if (expr is MetaBracketExpression) //251:2
            {
                __out.Append("("); //251:33
                __out.Append(GenerateExpression(((MetaBracketExpression)expr).Expression));
                __out.Append(")"); //251:71
            }
            else if (expr is MetaThisExpression) //252:2
            {
                __out.Append("(("); //252:30
                __out.Append(((MetaType)ModelCompilerContext.Current.ResolutionProvider.GetCurrentTypeScopeOf((ModelObject)((MetaThisExpression)expr))).CSharpName());
                __out.Append(")this)"); //252:147
            }
            else if (expr is MetaNullExpression) //253:2
            {
                __out.Append("null"); //253:30
            }
            else if (expr is MetaTypeAsExpression) //254:2
            {
                __out.Append(GenerateExpression(((MetaTypeAsExpression)expr).Expression));
                __out.Append(" as "); //254:69
                __out.Append(((MetaTypeAsExpression)expr).TypeReference.CSharpName());
            }
            else if (expr is MetaTypeCastExpression) //255:2
            {
                __out.Append("("); //255:34
                __out.Append(((MetaTypeCastExpression)expr).TypeReference.CSharpName());
                __out.Append(")"); //255:68
                __out.Append(GenerateExpression(((MetaTypeCastExpression)expr).Expression));
            }
            else if (expr is MetaTypeCheckExpression) //256:2
            {
                __out.Append(GenerateExpression(((MetaTypeCheckExpression)expr).Expression));
                __out.Append(" is "); //256:72
                __out.Append(((MetaTypeCheckExpression)expr).TypeReference.CSharpName());
            }
            else if (expr is MetaTypeOfExpression) //257:2
            {
                __out.Append(GenerateTypeOf(((MetaTypeOfExpression)expr)));
            }
            else if (expr is MetaConditionalExpression) //258:2
            {
                __out.Append(GenerateExpression(((MetaConditionalExpression)expr).Condition));
                __out.Append(" ? "); //258:73
                __out.Append(GenerateExpression(((MetaConditionalExpression)expr).Then));
                __out.Append(" : "); //258:107
                __out.Append(GenerateExpression(((MetaConditionalExpression)expr).Else));
            }
            else if (expr is MetaConstantExpression) //259:2
            {
                __out.Append(GetCSharpValue(((MetaConstantExpression)expr).Value));
            }
            else if (expr is MetaIdentifierExpression) //260:2
            {
                __out.Append(GenerateIdentifierExpression(((MetaIdentifierExpression)expr)));
            }
            else if (expr is MetaMemberAccessExpression) //261:2
            {
                __out.Append(GenerateExpression(((MetaMemberAccessExpression)expr).Expression));
                __out.Append("."); //261:75
                __out.Append(((MetaMemberAccessExpression)expr).Name);
            }
            else if (expr is MetaFunctionCallExpression) //262:2
            {
                __out.Append(GenerateFunctionCall(((MetaFunctionCallExpression)expr)));
            }
            else if (expr is MetaIndexerExpression) //263:2
            {
                __out.Append(GenerateIndexerCall(((MetaIndexerExpression)expr)));
            }
            else if (expr is MetaOperatorExpression) //264:2
            {
                __out.Append(GenerateOperator(((MetaOperatorExpression)expr)));
            }
            else if (expr is MetaNewExpression) //265:2
            {
                __out.Append(((MetaNewExpression)expr).TypeReference.CSharpFullFactoryMethodName());
                __out.Append("("); //265:79
                __out.Append(GenerateNewPropertyInitializers(((MetaNewExpression)expr)));
                __out.Append(")"); //265:119
            }
            else if (expr is MetaNewCollectionExpression) //266:2
            {
                __out.Append("new List<Lazy<object>>() { "); //266:39
                __out.Append(GenerateNewCollectionValues(((MetaNewCollectionExpression)expr)));
                __out.Append(" }"); //266:101
            }
            else //267:2
            {
                __out.Append("***unknown expression type***"); //267:11
                __out.AppendLine(); //267:40
            }//268:2
            return __out.ToString();
        }

        public string GenerateIdentifierExpression(MetaIdentifierExpression expr) //271:1
        {
            StringBuilder __out = new StringBuilder();
            if (expr.Definition is MetaProperty) //272:2
            {
                string __tmp1Prefix = "(("; //273:1
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
                            if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                            else __tmp3Line = "";
                        }
                        __out.Append(__tmp1Prefix);
                        __out.Append(__tmp3Line);
                    }
                }
                string __tmp4Line = ")this)."; //273:118
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
                            if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                            else __tmp5Line = "";
                        }
                        __out.Append(__tmp5Line);
                        __out.Append(__tmp2Suffix);
                    }
                }
            }
            else //274:2
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
                            if (string.IsNullOrEmpty(__tmp6Prefix) && string.IsNullOrEmpty(__tmp7Suffix)) break;
                            else __tmp8Line = "";
                        }
                        __out.Append(__tmp6Prefix);
                        __out.Append(__tmp8Line);
                        __out.Append(__tmp7Suffix);
                    }
                }
            }
            return __out.ToString();
        }

        public bool SameFunction(MetaGlobalFunction mfunc1, MetaGlobalFunction mfunc2) //279:1
        {
            return mfunc1.Name == mfunc2.Name && ModelCompilerContext.Current.TypeProvider.Equals((ModelObject)mfunc1.Type, (ModelObject)mfunc2.Type); //280:2
        }

        public string GenerateFunctionCall(MetaFunctionCallExpression call) //283:1
        {
            StringBuilder __out = new StringBuilder();
            if (call.Definition is MetaGlobalFunction && SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.TypeOf)) //284:2
            {
                __out.Append(GenerateTypeOf(call.Arguments[0]));
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.GetValueType)) //285:2
            {
                __out.Append("ModelCompilerContext.Current.TypeProvider.GetTypeOf("); //285:89
                __out.Append(GenerateCallArguments(call, ""));
                __out.Append(")"); //285:174
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.GetReturnType)) //286:2
            {
                __out.Append("ModelCompilerContext.Current.TypeProvider.GetReturnTypeOf("); //286:90
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //286:194
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.CurrentType)) //287:2
            {
                __out.Append("ModelCompilerContext.Current.ResolutionProvider.GetCurrentTypeScopeOf("); //287:88
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //287:204
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.TypeCheck)) //288:2
            {
                __out.Append("ModelCompilerContext.Current.TypeProvider.TypeCheck("); //288:86
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //288:184
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Balance)) //289:2
            {
                __out.Append("ModelCompilerContext.Current.TypeProvider.Balance("); //289:84
                __out.Append(GenerateCallArguments(call, "(ModelObject)"));
                __out.Append(")"); //289:180
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Resolve1)) //290:2
            {
                __out.Append("ModelCompilerContext.Current.ResolutionProvider.Resolve(new ModelObject"); //290:85
                __out.Append("[]");
                __out.Append(" { ModelCompilerContext.Current.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.NameOrType, "); //290:162
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //290:301
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Resolve2)) //291:2
            {
                __out.Append("ModelCompilerContext.Current.ResolutionProvider.Resolve(new ModelObject"); //291:85
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //291:162
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, ResolveKind.NameOrType, "); //291:217
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //291:284
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveType1)) //292:2
            {
                __out.Append("ModelCompilerContext.Current.ResolutionProvider.Resolve(new ModelObject"); //292:89
                __out.Append("[]");
                __out.Append(" { ModelCompilerContext.Current.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Type, "); //292:166
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //292:299
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveType2)) //293:2
            {
                __out.Append("ModelCompilerContext.Current.ResolutionProvider.Resolve(new ModelObject"); //293:89
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //293:166
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, ResolveKind.Type, "); //293:221
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //293:282
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveName1)) //294:2
            {
                __out.Append("ModelCompilerContext.Current.ResolutionProvider.Resolve(new ModelObject"); //294:89
                __out.Append("[]");
                __out.Append(" { ModelCompilerContext.Current.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, "); //294:166
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //294:299
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveName2)) //295:2
            {
                __out.Append("ModelCompilerContext.Current.ResolutionProvider.Resolve(new ModelObject"); //295:89
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //295:166
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, ResolveKind.Name, "); //295:221
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new ResolutionInfo(), ResolveFlags.All)"); //295:282
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind1)) //296:2
            {
                __out.Append("ModelCompilerContext.Current.BindingProvider.Bind(this, new ModelObject"); //296:82
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //296:159
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }, new BindingInfo())"); //296:214
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind2)) //297:2
            {
                __out.Append("ModelCompilerContext.Current.BindingProvider.Bind(this, "); //297:82
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new BindingInfo())"); //297:177
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind3)) //298:2
            {
                __out.Append("ModelCompilerContext.Current.BindingProvider.Bind((ModelObject)"); //298:82
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", new ModelObject"); //298:184
                __out.Append("[]");
                __out.Append(" { (ModelObject)"); //298:207
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(" }, new BindingInfo())"); //298:262
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind4)) //299:2
            {
                __out.Append("ModelCompilerContext.Current.BindingProvider.Bind((ModelObject)"); //299:82
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(", "); //299:184
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(", new BindingInfo())"); //299:225
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.SelectOfType1)) //300:2
            {
                __out.Append("new object"); //300:90
                __out.Append("[]");
                __out.Append(" { "); //300:106
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }.Where(e => ModelCompilerContext.Current.TypeProvider.GetTypeOf(e) is "); //300:148
                __out.Append(GetTypeName(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //300:252
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.SelectOfType2)) //301:2
            {
                __out.Append("("); //301:90
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(").Where(e => ModelCompilerContext.Current.TypeProvider.GetTypeOf(e) is "); //301:130
                __out.Append(GetTypeName(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //301:233
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.SelectOfName1)) //302:2
            {
                __out.Append("new object"); //302:90
                __out.Append("[]");
                __out.Append(" { "); //302:106
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(" }.Where(e => ModelCompilerContext.Current.NameProvider.GetNameOf((ModelObject)e) == "); //302:148
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //302:272
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.SelectOfName2)) //303:2
            {
                __out.Append("("); //303:90
                __out.Append(GenerateExpression(call.Arguments[0]));
                __out.Append(").Where(e => ModelCompilerContext.Current.NameProvider.GetNameOf((ModelObject)e) == "); //303:130
                __out.Append(GenerateExpression(call.Arguments[1]));
                __out.Append(").OfType<ModelObject>().ToList()"); //303:253
            }
            else //304:2
            {
                __out.Append(GenerateExpression(call.Expression));
                __out.Append("("); //304:44
                __out.Append(GenerateCallArguments(call, ""));
                __out.Append(")"); //304:78
            }
            return __out.ToString();
        }

        public string GenerateIndexerCall(MetaIndexerExpression call) //308:1
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp3Line = "";
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp4Line = "";
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp5Line = "";
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp6Line = "";
                    }
                    __out.Append(__tmp6Line);
                    __out.Append(__tmp2Suffix);
                }
            }
            return __out.ToString();
        }

        public string GenerateTypeOf(object expr) //312:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //313:9
            if (expr is MetaPrimitiveType) //314:2
            {
                var __tmp2 = ((MetaPrimitiveType)expr).Name; //315:10
                __out.Append("	"); //316:1
                if (__tmp2 == "*none*") //316:3
                {
                    __out.Append("MetaInstance.None"); //316:18
                    __out.Append("	"); //317:1
                }
                else if (__tmp2 == "*error*") //317:3
                {
                    __out.Append("MetaInstance.Error"); //317:19
                    __out.Append("	"); //318:1
                }
                else if (__tmp2 == "*any*") //318:3
                {
                    __out.Append("MetaInstance.Any"); //318:17
                    __out.Append("	"); //319:1
                }
                else if (__tmp2 == "object") //319:3
                {
                    __out.Append("MetaInstance.Object"); //319:18
                    __out.Append("	"); //320:1
                }
                else if (__tmp2 == "string") //320:3
                {
                    __out.Append("MetaInstance.String"); //320:18
                    __out.Append("	"); //321:1
                }
                else if (__tmp2 == "int") //321:3
                {
                    __out.Append("MetaInstance.Int"); //321:15
                    __out.Append("	"); //322:1
                }
                else if (__tmp2 == "long") //322:3
                {
                    __out.Append("MetaInstance.Long"); //322:16
                    __out.Append("	"); //323:1
                }
                else if (__tmp2 == "float") //323:3
                {
                    __out.Append("MetaInstance.Float"); //323:17
                    __out.Append("	"); //324:1
                }
                else if (__tmp2 == "double") //324:3
                {
                    __out.Append("MetaInstance.Double"); //324:18
                    __out.Append("	"); //325:1
                }
                else if (__tmp2 == "byte") //325:3
                {
                    __out.Append("MetaInstance.Byte"); //325:16
                    __out.Append("	"); //326:1
                }
                else if (__tmp2 == "bool") //326:3
                {
                    __out.Append("MetaInstance.Bool"); //326:16
                    __out.Append("	"); //327:1
                }
                else if (__tmp2 == "void") //327:3
                {
                    __out.Append("MetaInstance.Void"); //327:16
                    __out.Append("	"); //328:1
                }
                else if (__tmp2 == "ModelObject") //328:3
                {
                    __out.Append("MetaInstance.ModelObject"); //328:23
                    __out.Append("	"); //329:1
                }
                else if (__tmp2 == "ModelObjectList") //329:3
                {
                    __out.Append("MetaInstance.ModelObjectList"); //329:27
                }//330:3
            }
            else if (expr is MetaTypeOfExpression) //331:2
            {
                __out.Append(GenerateTypeOf(((MetaTypeOfExpression)expr).TypeReference));
            }
            else if (expr is MetaClass) //332:2
            {
                __out.Append(((MetaClass)expr).CSharpFullDescriptorName());
                __out.Append(".MetaClass"); //332:54
            }
            else if (expr is MetaCollectionType) //333:2
            {
                __out.Append(((MetaCollectionType)expr).CSharpFullName());
            }
            else //334:2
            {
                __out.Append("***error***"); //334:11
            }//335:2
            return __out.ToString();
        }

        public string GenerateCallArguments(MetaBoundExpression call, string prefix) //338:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop21_results = 
                (from __loop21_var1 in __Enumerate((call).GetEnumerator()) //339:7
                from arg in __Enumerate((__loop21_var1.Arguments).GetEnumerator()) //339:13
                select new { __loop21_var1 = __loop21_var1, arg = arg}
                ).ToList(); //339:2
            int __loop21_iteration = 0;
            string delim = ""; //339:28
            foreach (var __tmp1 in __loop21_results)
            {
                ++__loop21_iteration;
                if (__loop21_iteration >= 2) //339:47
                {
                    delim = ", "; //339:47
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
                            if (string.IsNullOrEmpty(__tmp2Prefix) && string.IsNullOrEmpty(__tmp3Suffix)) break;
                            else __tmp4Line = "";
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
                            if (string.IsNullOrEmpty(__tmp2Prefix) && string.IsNullOrEmpty(__tmp3Suffix)) break;
                            else __tmp5Line = "";
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
                            if (string.IsNullOrEmpty(__tmp2Prefix) && string.IsNullOrEmpty(__tmp3Suffix)) break;
                            else __tmp6Line = "";
                        }
                        __out.Append(__tmp6Line);
                        __out.Append(__tmp3Suffix);
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateOperator(MetaOperatorExpression expr) //344:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //345:10
            if (expr is MetaUnaryExpression) //346:2
            {
                if (((MetaUnaryExpression)expr) is MetaPostIncrementAssignExpression || ((MetaUnaryExpression)expr) is MetaPostDecrementAssignExpression) //347:3
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
                                if (string.IsNullOrEmpty(__tmp2Prefix) && string.IsNullOrEmpty(__tmp3Suffix)) break;
                                else __tmp4Line = "";
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
                                if (string.IsNullOrEmpty(__tmp2Prefix) && string.IsNullOrEmpty(__tmp3Suffix)) break;
                                else __tmp5Line = "";
                            }
                            __out.Append(__tmp5Line);
                            __out.Append(__tmp3Suffix);
                        }
                    }
                }
                else //349:3
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
                                if (string.IsNullOrEmpty(__tmp6Prefix) && string.IsNullOrEmpty(__tmp7Suffix)) break;
                                else __tmp8Line = "";
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
                                if (string.IsNullOrEmpty(__tmp6Prefix) && string.IsNullOrEmpty(__tmp7Suffix)) break;
                                else __tmp9Line = "";
                            }
                            __out.Append(__tmp9Line);
                            __out.Append(__tmp7Suffix);
                        }
                    }
                }
            }
            else if (expr is MetaBinaryExpression) //352:2
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
                            if (string.IsNullOrEmpty(__tmp10Prefix) && string.IsNullOrEmpty(__tmp11Suffix)) break;
                            else __tmp12Line = "";
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
                            if (string.IsNullOrEmpty(__tmp10Prefix) && string.IsNullOrEmpty(__tmp11Suffix)) break;
                            else __tmp13Line = "";
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
                            if (string.IsNullOrEmpty(__tmp10Prefix) && string.IsNullOrEmpty(__tmp11Suffix)) break;
                            else __tmp14Line = "";
                        }
                        __out.Append(__tmp14Line);
                        __out.Append(__tmp11Suffix);
                    }
                }
            }//354:2
            return __out.ToString();
        }

        public string GenerateNewPropertyInitializers(MetaNewExpression expr) //357:1
        {
            StringBuilder __out = new StringBuilder();
            if ((from __loop22_var1 in __Enumerate((expr).GetEnumerator()) //358:14
            from pi in __Enumerate((__loop22_var1.PropertyInitializers).GetEnumerator()) //358:20
            select new { __loop22_var1 = __loop22_var1, pi = pi}
            ).GetEnumerator().MoveNext()) //358:2
            {
                __out.Append("new List<ModelPropertyInitializer>() {"); //359:1
                var __loop23_results = 
                    (from __loop23_var1 in __Enumerate((expr).GetEnumerator()) //360:7
                    from pi in __Enumerate((__loop23_var1.PropertyInitializers).GetEnumerator()) //360:13
                    select new { __loop23_var1 = __loop23_var1, pi = pi}
                    ).ToList(); //360:2
                int __loop23_iteration = 0;
                string delim = ""; //360:38
                foreach (var __tmp1 in __loop23_results)
                {
                    ++__loop23_iteration;
                    if (__loop23_iteration >= 2) //360:57
                    {
                        delim = ", "; //360:57
                    }
                    var __loop23_var1 = __tmp1.__loop23_var1;
                    var pi = __tmp1.pi;
                    string __tmp2Prefix = string.Empty; 
                    string __tmp3Suffix = ", LazyThreadSafetyMode.ExecutionAndPublication))"; //361:132
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
                                if (string.IsNullOrEmpty(__tmp2Prefix) && string.IsNullOrEmpty(__tmp3Suffix)) break;
                                else __tmp4Line = "";
                            }
                            __out.Append(__tmp2Prefix);
                            __out.Append(__tmp4Line);
                        }
                    }
                    string __tmp5Line = "new ModelPropertyInitializer("; //361:8
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
                                if (string.IsNullOrEmpty(__tmp2Prefix) && string.IsNullOrEmpty(__tmp3Suffix)) break;
                                else __tmp6Line = "";
                            }
                            __out.Append(__tmp6Line);
                        }
                    }
                    string __tmp7Line = ", new Lazy<object>(() => "; //361:77
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
                                if (string.IsNullOrEmpty(__tmp2Prefix) && string.IsNullOrEmpty(__tmp3Suffix)) break;
                                else __tmp8Line = "";
                            }
                            __out.Append(__tmp8Line);
                            __out.Append(__tmp3Suffix);
                        }
                    }
                }
                __out.Append("}"); //363:1
            }
            return __out.ToString();
        }

        public string GenerateNewCollectionValues(MetaNewCollectionExpression expr) //367:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((expr).GetEnumerator()) //368:7
                from v in __Enumerate((__loop24_var1.Values).GetEnumerator()) //368:13
                select new { __loop24_var1 = __loop24_var1, v = v}
                ).ToList(); //368:2
            int __loop24_iteration = 0;
            string delim = ""; //368:23
            foreach (var __tmp1 in __loop24_results)
            {
                ++__loop24_iteration;
                if (__loop24_iteration >= 2) //368:42
                {
                    delim = ", \n"; //368:42
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
                            if (string.IsNullOrEmpty(__tmp2Prefix) && string.IsNullOrEmpty(__tmp3Suffix)) break;
                            else __tmp4Line = "";
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
                            if (string.IsNullOrEmpty(__tmp2Prefix) && string.IsNullOrEmpty(__tmp3Suffix)) break;
                            else __tmp5Line = "";
                        }
                        __out.Append(__tmp5Line);
                        __out.Append(__tmp3Suffix);
                    }
                }
            }
            return __out.ToString();
        }

        public string GetCSharpValue(object value) //373:1
        {
            if (value == null) //374:2
            {
                return "null"; //374:21
            }
            else if (value is bool && ((bool)value) == true) //375:2
            {
                return "true"; //375:51
            }
            else if (value is bool && ((bool)value) == false) //376:2
            {
                return "false"; //376:52
            }
            else if (value is string) //377:2
            {
                return "\"" + value.ToString() + "\""; //377:28
            }
            else if (value is MetaExpression) //378:2
            {
                return GenerateExpression((MetaExpression)value); //378:36
            }
            else //379:2
            {
                return value.ToString(); //379:7
            }
        }

        public string GetCSharpIdentifier(object value) //383:1
        {
            if (value == null) //384:2
            {
                return null; //385:3
            }
            if (value is MetaConstantExpression && ((MetaConstantExpression)value).Value != null) //387:2
            {
                return ((MetaConstantExpression)value).Value.ToString(); //388:3
            }
            else if (value is string) //389:2
            {
                return value.ToString(); //390:3
            }
            else //391:2
            {
                return null; //392:3
            }
        }

        public string GetCSharpOperator(MetaOperatorExpression expr) //396:1
        {
            var __tmp1 = expr; //397:9
            if (expr is MetaUnaryPlusExpression) //398:3
            {
                return "+"; //398:36
            }
            else if (expr is MetaNegateExpression) //399:3
            {
                return "-"; //399:33
            }
            else if (expr is MetaOnesComplementExpression) //400:3
            {
                return "~"; //400:41
            }
            else if (expr is MetaNotExpression) //401:3
            {
                return "!"; //401:30
            }
            else if (expr is MetaPostIncrementAssignExpression) //402:3
            {
                return "++"; //402:46
            }
            else if (expr is MetaPostDecrementAssignExpression) //403:3
            {
                return "--"; //403:46
            }
            else if (expr is MetaPreIncrementAssignExpression) //404:3
            {
                return "++"; //404:45
            }
            else if (expr is MetaPreDecrementAssignExpression) //405:3
            {
                return "--"; //405:45
            }
            else if (expr is MetaMultiplyExpression) //406:3
            {
                return "*"; //406:35
            }
            else if (expr is MetaDivideExpression) //407:3
            {
                return "/"; //407:33
            }
            else if (expr is MetaModuloExpression) //408:3
            {
                return "%"; //408:33
            }
            else if (expr is MetaAddExpression) //409:3
            {
                return "+"; //409:30
            }
            else if (expr is MetaSubtractExpression) //410:3
            {
                return "-"; //410:35
            }
            else if (expr is MetaLeftShiftExpression) //411:3
            {
                return "<<"; //411:36
            }
            else if (expr is MetaRightShiftExpression) //412:3
            {
                return ">>"; //412:37
            }
            else if (expr is MetaLessThanExpression) //413:3
            {
                return "<"; //413:35
            }
            else if (expr is MetaLessThanOrEqualExpression) //414:3
            {
                return "<="; //414:42
            }
            else if (expr is MetaGreaterThanExpression) //415:3
            {
                return ">"; //415:38
            }
            else if (expr is MetaGreaterThanOrEqualExpression) //416:3
            {
                return ">="; //416:45
            }
            else if (expr is MetaEqualExpression) //417:3
            {
                return "=="; //417:32
            }
            else if (expr is MetaNotEqualExpression) //418:3
            {
                return "!="; //418:35
            }
            else if (expr is MetaAndExpression) //419:3
            {
                return "&"; //419:30
            }
            else if (expr is MetaOrExpression) //420:3
            {
                return "|"; //420:29
            }
            else if (expr is MetaExclusiveOrExpression) //421:3
            {
                return "^"; //421:38
            }
            else if (expr is MetaAndAlsoExpression) //422:3
            {
                return "&&"; //422:34
            }
            else if (expr is MetaOrElseExpression) //423:3
            {
                return "||"; //423:33
            }
            else if (expr is MetaNullCoalescingExpression) //424:3
            {
                return "??"; //424:41
            }
            else if (expr is MetaMultiplyAssignExpression) //425:3
            {
                return "*="; //425:41
            }
            else if (expr is MetaDivideAssignExpression) //426:3
            {
                return "/="; //426:39
            }
            else if (expr is MetaModuloAssignExpression) //427:3
            {
                return "%="; //427:39
            }
            else if (expr is MetaAddAssignExpression) //428:3
            {
                return "+="; //428:36
            }
            else if (expr is MetaSubtractAssignExpression) //429:3
            {
                return "-="; //429:41
            }
            else if (expr is MetaLeftShiftAssignExpression) //430:3
            {
                return "<<="; //430:42
            }
            else if (expr is MetaRightShiftAssignExpression) //431:3
            {
                return ">>="; //431:43
            }
            else if (expr is MetaAndAssignExpression) //432:3
            {
                return "&="; //432:36
            }
            else if (expr is MetaExclusiveOrAssignExpression) //433:3
            {
                return "^="; //433:44
            }
            else if (expr is MetaOrAssignExpression) //434:3
            {
                return "|="; //434:35
            }
            else //435:3
            {
                return ""; //435:12
            }//436:2
        }

        public string GetTypeName(MetaExpression expr) //439:1
        {
            if (expr is MetaTypeOfExpression) //440:2
            {
                return ((MetaTypeOfExpression)expr).TypeReference.CSharpFullName(); //440:36
            }
            else //441:2
            {
                return null; //441:7
            }
        }

        public MetaSynthetizedPropertyInitializer GetSynthetizedInitializerFor(MetaClass cls, MetaProperty prop) //445:1
        {
            MetaSynthetizedPropertyInitializer lastInit = null; //446:2
            var __loop25_results = 
                (from __loop25_var1 in __Enumerate((cls).GetEnumerator()) //447:7
                from sup in __Enumerate((__loop25_var1.GetAllSuperClasses(true)).GetEnumerator()) //447:12
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //447:42
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //447:55
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaSynthetizedPropertyInitializer>() //447:69
                select new { __loop25_var1 = __loop25_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //447:2
            int __loop25_iteration = 0;
            foreach (var __tmp1 in __loop25_results)
            {
                ++__loop25_iteration;
                var __loop25_var1 = __tmp1.__loop25_var1;
                var sup = __tmp1.sup;
                var Constructor = __tmp1.Constructor;
                var Initializers = __tmp1.Initializers;
                var init = __tmp1.init;
                if (init.Property == prop) //448:3
                {
                    lastInit = init; //449:4
                }
            }
            return lastInit; //452:2
        }

        public string GenerateConstructorImpl(MetaModel model, MetaClass cls) //455:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public "; //456:1
            string __tmp2Suffix = "() "; //456:30
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //456:33
                }
            }
            __out.Append("{"); //457:1
            __out.AppendLine(); //457:2
            var __loop26_results = 
                (from __loop26_var1 in __Enumerate((cls).GetEnumerator()) //458:8
                from prop in __Enumerate((__loop26_var1.GetAllProperties()).GetEnumerator()) //458:13
                select new { __loop26_var1 = __loop26_var1, prop = prop}
                ).ToList(); //458:3
            int __loop26_iteration = 0;
            foreach (var __tmp4 in __loop26_results)
            {
                ++__loop26_iteration;
                var __loop26_var1 = __tmp4.__loop26_var1;
                var prop = __tmp4.prop;
                MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //459:4
                if (synInit != null) //460:4
                {
                    if (prop.Kind != MetaPropertyKind.Derived) //461:5
                    {
                        if (ModelCompilerContext.Current.TypeProvider.GetTypeOf(synInit.Value) is MetaCollectionType) //462:6
                        {
                            string __tmp5Prefix = "    this.MLazySet("; //463:1
                            string __tmp6Suffix = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //463:112
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
                                        if (string.IsNullOrEmpty(__tmp5Prefix) && string.IsNullOrEmpty(__tmp6Suffix)) break;
                                        else __tmp7Line = "";
                                    }
                                    __out.Append(__tmp5Prefix);
                                    __out.Append(__tmp7Line);
                                }
                            }
                            string __tmp8Line = ", new Lazy<object>(() => "; //463:52
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
                                        if (string.IsNullOrEmpty(__tmp5Prefix) && string.IsNullOrEmpty(__tmp6Suffix)) break;
                                        else __tmp9Line = "";
                                    }
                                    __out.Append(__tmp9Line);
                                    __out.Append(__tmp6Suffix);
                                    __out.AppendLine(); //463:161
                                }
                            }
                        }
                        else //464:6
                        {
                            string __tmp10Prefix = "    this.MLazySet("; //465:1
                            string __tmp11Suffix = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //465:112
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
                                        if (string.IsNullOrEmpty(__tmp10Prefix) && string.IsNullOrEmpty(__tmp11Suffix)) break;
                                        else __tmp12Line = "";
                                    }
                                    __out.Append(__tmp10Prefix);
                                    __out.Append(__tmp12Line);
                                }
                            }
                            string __tmp13Line = ", new Lazy<object>(() => "; //465:52
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
                                        if (string.IsNullOrEmpty(__tmp10Prefix) && string.IsNullOrEmpty(__tmp11Suffix)) break;
                                        else __tmp14Line = "";
                                    }
                                    __out.Append(__tmp14Line);
                                    __out.Append(__tmp11Suffix);
                                    __out.AppendLine(); //465:161
                                }
                            }
                        }
                    }
                    else //467:5
                    {
                        string __tmp15Prefix = "    this.MDerivedSet("; //468:1
                        string __tmp16Suffix = ");"; //468:98
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
                                    if (string.IsNullOrEmpty(__tmp15Prefix) && string.IsNullOrEmpty(__tmp16Suffix)) break;
                                    else __tmp17Line = "";
                                }
                                __out.Append(__tmp15Prefix);
                                __out.Append(__tmp17Line);
                            }
                        }
                        string __tmp18Line = ", () => "; //468:55
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
                                    if (string.IsNullOrEmpty(__tmp15Prefix) && string.IsNullOrEmpty(__tmp16Suffix)) break;
                                    else __tmp19Line = "";
                                }
                                __out.Append(__tmp19Line);
                                __out.Append(__tmp16Suffix);
                                __out.AppendLine(); //468:100
                            }
                        }
                    }
                }
                else //470:4
                {
                    if (prop.Type is MetaCollectionType) //471:5
                    {
                        if (prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) //472:6
                        {
                            string __tmp20Prefix = "    this.MSet("; //473:1
                            string __tmp21Suffix = "));"; //473:117
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
                                        if (string.IsNullOrEmpty(__tmp20Prefix) && string.IsNullOrEmpty(__tmp21Suffix)) break;
                                        else __tmp22Line = "";
                                    }
                                    __out.Append(__tmp20Prefix);
                                    __out.Append(__tmp22Line);
                                }
                            }
                            string __tmp23Line = ", new "; //473:48
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
                                        if (string.IsNullOrEmpty(__tmp20Prefix) && string.IsNullOrEmpty(__tmp21Suffix)) break;
                                        else __tmp24Line = "";
                                    }
                                    __out.Append(__tmp24Line);
                                }
                            }
                            string __tmp25Line = "("; //473:78
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
                                        if (string.IsNullOrEmpty(__tmp20Prefix) && string.IsNullOrEmpty(__tmp21Suffix)) break;
                                        else __tmp26Line = "";
                                    }
                                    __out.Append(__tmp26Line);
                                    __out.Append(__tmp21Suffix);
                                    __out.AppendLine(); //473:120
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //474:6
                        {
                            string __tmp27Prefix = "    this.MLazySet("; //475:1
                            string __tmp28Suffix = "(this), LazyThreadSafetyMode.ExecutionAndPublication));"; //475:164
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
                                        if (string.IsNullOrEmpty(__tmp27Prefix) && string.IsNullOrEmpty(__tmp28Suffix)) break;
                                        else __tmp29Line = "";
                                    }
                                    __out.Append(__tmp27Prefix);
                                    __out.Append(__tmp29Line);
                                }
                            }
                            string __tmp30Line = ", new Lazy<object>(() => "; //475:52
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
                                        if (string.IsNullOrEmpty(__tmp27Prefix) && string.IsNullOrEmpty(__tmp28Suffix)) break;
                                        else __tmp31Line = "";
                                    }
                                    __out.Append(__tmp31Line);
                                }
                            }
                            string __tmp32Line = "."; //475:126
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
                                        if (string.IsNullOrEmpty(__tmp27Prefix) && string.IsNullOrEmpty(__tmp28Suffix)) break;
                                        else __tmp33Line = "";
                                    }
                                    __out.Append(__tmp33Line);
                                }
                            }
                            string __tmp34Line = "_"; //475:152
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
                                        if (string.IsNullOrEmpty(__tmp27Prefix) && string.IsNullOrEmpty(__tmp28Suffix)) break;
                                        else __tmp35Line = "";
                                    }
                                    __out.Append(__tmp35Line);
                                    __out.Append(__tmp28Suffix);
                                    __out.AppendLine(); //475:219
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Derived) //476:6
                        {
                            string __tmp36Prefix = "    this.MDerivedSet("; //477:1
                            string __tmp37Suffix = "(this));"; //477:150
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
                                        if (string.IsNullOrEmpty(__tmp36Prefix) && string.IsNullOrEmpty(__tmp37Suffix)) break;
                                        else __tmp38Line = "";
                                    }
                                    __out.Append(__tmp36Prefix);
                                    __out.Append(__tmp38Line);
                                }
                            }
                            string __tmp39Line = ", () => "; //477:55
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
                                        if (string.IsNullOrEmpty(__tmp36Prefix) && string.IsNullOrEmpty(__tmp37Suffix)) break;
                                        else __tmp40Line = "";
                                    }
                                    __out.Append(__tmp40Line);
                                }
                            }
                            string __tmp41Line = "."; //477:112
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
                                        if (string.IsNullOrEmpty(__tmp36Prefix) && string.IsNullOrEmpty(__tmp37Suffix)) break;
                                        else __tmp42Line = "";
                                    }
                                    __out.Append(__tmp42Line);
                                }
                            }
                            string __tmp43Line = "_"; //477:138
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
                                        if (string.IsNullOrEmpty(__tmp36Prefix) && string.IsNullOrEmpty(__tmp37Suffix)) break;
                                        else __tmp44Line = "";
                                    }
                                    __out.Append(__tmp44Line);
                                    __out.Append(__tmp37Suffix);
                                    __out.AppendLine(); //477:158
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Readonly) //478:6
                        {
                            string __tmp45Prefix = "    // Init "; //479:1
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
                                        if (string.IsNullOrEmpty(__tmp45Prefix) && string.IsNullOrEmpty(__tmp46Suffix)) break;
                                        else __tmp47Line = "";
                                    }
                                    __out.Append(__tmp45Prefix);
                                    __out.Append(__tmp47Line);
                                }
                            }
                            string __tmp48Line = " in "; //479:46
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
                                        if (string.IsNullOrEmpty(__tmp45Prefix) && string.IsNullOrEmpty(__tmp46Suffix)) break;
                                        else __tmp49Line = "";
                                    }
                                    __out.Append(__tmp49Line);
                                }
                            }
                            string __tmp50Line = "."; //479:99
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
                                        if (string.IsNullOrEmpty(__tmp45Prefix) && string.IsNullOrEmpty(__tmp46Suffix)) break;
                                        else __tmp51Line = "";
                                    }
                                    __out.Append(__tmp51Line);
                                }
                            }
                            string __tmp52Line = "_"; //479:118
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
                                        if (string.IsNullOrEmpty(__tmp45Prefix) && string.IsNullOrEmpty(__tmp46Suffix)) break;
                                        else __tmp53Line = "";
                                    }
                                    __out.Append(__tmp53Line);
                                    __out.Append(__tmp46Suffix);
                                    __out.AppendLine(); //479:137
                                }
                            }
                        }
                    }
                    else //481:5
                    {
                        if (prop.Kind == MetaPropertyKind.Lazy) //482:6
                        {
                            string __tmp54Prefix = "    this.MLazySet("; //483:1
                            string __tmp55Suffix = "(this), LazyThreadSafetyMode.ExecutionAndPublication));"; //483:153
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
                                        if (string.IsNullOrEmpty(__tmp54Prefix) && string.IsNullOrEmpty(__tmp55Suffix)) break;
                                        else __tmp56Line = "";
                                    }
                                    __out.Append(__tmp54Prefix);
                                    __out.Append(__tmp56Line);
                                }
                            }
                            string __tmp57Line = ", new Lazy<object>(() => "; //483:52
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
                                        if (string.IsNullOrEmpty(__tmp54Prefix) && string.IsNullOrEmpty(__tmp55Suffix)) break;
                                        else __tmp58Line = "";
                                    }
                                    __out.Append(__tmp58Line);
                                }
                            }
                            string __tmp59Line = "."; //483:115
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
                                        if (string.IsNullOrEmpty(__tmp54Prefix) && string.IsNullOrEmpty(__tmp55Suffix)) break;
                                        else __tmp60Line = "";
                                    }
                                    __out.Append(__tmp60Line);
                                }
                            }
                            string __tmp61Line = "_"; //483:141
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
                                        if (string.IsNullOrEmpty(__tmp54Prefix) && string.IsNullOrEmpty(__tmp55Suffix)) break;
                                        else __tmp62Line = "";
                                    }
                                    __out.Append(__tmp62Line);
                                    __out.Append(__tmp55Suffix);
                                    __out.AppendLine(); //483:208
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Derived) //484:6
                        {
                            string __tmp63Prefix = "    this.MDerivedSet("; //485:1
                            string __tmp64Suffix = "(this));"; //485:139
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
                                        if (string.IsNullOrEmpty(__tmp63Prefix) && string.IsNullOrEmpty(__tmp64Suffix)) break;
                                        else __tmp65Line = "";
                                    }
                                    __out.Append(__tmp63Prefix);
                                    __out.Append(__tmp65Line);
                                }
                            }
                            string __tmp66Line = ", () => "; //485:55
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
                                        if (string.IsNullOrEmpty(__tmp63Prefix) && string.IsNullOrEmpty(__tmp64Suffix)) break;
                                        else __tmp67Line = "";
                                    }
                                    __out.Append(__tmp67Line);
                                }
                            }
                            string __tmp68Line = "."; //485:101
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
                                        if (string.IsNullOrEmpty(__tmp63Prefix) && string.IsNullOrEmpty(__tmp64Suffix)) break;
                                        else __tmp69Line = "";
                                    }
                                    __out.Append(__tmp69Line);
                                }
                            }
                            string __tmp70Line = "_"; //485:127
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
                                        if (string.IsNullOrEmpty(__tmp63Prefix) && string.IsNullOrEmpty(__tmp64Suffix)) break;
                                        else __tmp71Line = "";
                                    }
                                    __out.Append(__tmp71Line);
                                    __out.Append(__tmp64Suffix);
                                    __out.AppendLine(); //485:147
                                }
                            }
                        }
                        else if (prop.Kind == MetaPropertyKind.Readonly) //486:6
                        {
                            string __tmp72Prefix = "    // Init "; //487:1
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
                                        if (string.IsNullOrEmpty(__tmp72Prefix) && string.IsNullOrEmpty(__tmp73Suffix)) break;
                                        else __tmp74Line = "";
                                    }
                                    __out.Append(__tmp72Prefix);
                                    __out.Append(__tmp74Line);
                                }
                            }
                            string __tmp75Line = " in "; //487:46
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
                                        if (string.IsNullOrEmpty(__tmp72Prefix) && string.IsNullOrEmpty(__tmp73Suffix)) break;
                                        else __tmp76Line = "";
                                    }
                                    __out.Append(__tmp76Line);
                                }
                            }
                            string __tmp77Line = "."; //487:88
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
                                        if (string.IsNullOrEmpty(__tmp72Prefix) && string.IsNullOrEmpty(__tmp73Suffix)) break;
                                        else __tmp78Line = "";
                                    }
                                    __out.Append(__tmp78Line);
                                }
                            }
                            string __tmp79Line = "_"; //487:107
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
                                        if (string.IsNullOrEmpty(__tmp72Prefix) && string.IsNullOrEmpty(__tmp73Suffix)) break;
                                        else __tmp80Line = "";
                                    }
                                    __out.Append(__tmp80Line);
                                    __out.Append(__tmp73Suffix);
                                    __out.AppendLine(); //487:126
                                }
                            }
                        }
                    }
                }
            }
            var __loop27_results = 
                (from __loop27_var1 in __Enumerate((cls).GetEnumerator()) //492:8
                from sup in __Enumerate((__loop27_var1.GetAllSuperClasses(true)).GetEnumerator()) //492:13
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //492:43
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //492:56
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaInheritedPropertyInitializer>() //492:70
                select new { __loop27_var1 = __loop27_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //492:3
            int __loop27_iteration = 0;
            foreach (var __tmp81 in __loop27_results)
            {
                ++__loop27_iteration;
                var __loop27_var1 = __tmp81.__loop27_var1;
                var sup = __tmp81.sup;
                var Constructor = __tmp81.Constructor;
                var Initializers = __tmp81.Initializers;
                var init = __tmp81.init;
                if (init.Object != null && init.Property != null) //493:4
                {
                    string __tmp82Prefix = "    this.MLazySetChild("; //494:1
                    string __tmp83Suffix = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //494:165
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
                                if (string.IsNullOrEmpty(__tmp82Prefix) && string.IsNullOrEmpty(__tmp83Suffix)) break;
                                else __tmp84Line = "";
                            }
                            __out.Append(__tmp82Prefix);
                            __out.Append(__tmp84Line);
                        }
                    }
                    string __tmp85Line = ", "; //494:64
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
                                if (string.IsNullOrEmpty(__tmp82Prefix) && string.IsNullOrEmpty(__tmp83Suffix)) break;
                                else __tmp86Line = "";
                            }
                            __out.Append(__tmp86Line);
                        }
                    }
                    string __tmp87Line = ", new Lazy<object>(() => "; //494:108
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
                                if (string.IsNullOrEmpty(__tmp82Prefix) && string.IsNullOrEmpty(__tmp83Suffix)) break;
                                else __tmp88Line = "";
                            }
                            __out.Append(__tmp88Line);
                            __out.Append(__tmp83Suffix);
                            __out.AppendLine(); //494:214
                        }
                    }
                }
            }
            string __tmp89Prefix = "    "; //497:1
            string __tmp90Suffix = "(this);"; //497:66
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
                        if (string.IsNullOrEmpty(__tmp89Prefix) && string.IsNullOrEmpty(__tmp90Suffix)) break;
                        else __tmp91Line = "";
                    }
                    __out.Append(__tmp89Prefix);
                    __out.Append(__tmp91Line);
                }
            }
            string __tmp92Line = "."; //497:47
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
                        if (string.IsNullOrEmpty(__tmp89Prefix) && string.IsNullOrEmpty(__tmp90Suffix)) break;
                        else __tmp93Line = "";
                    }
                    __out.Append(__tmp93Line);
                    __out.Append(__tmp90Suffix);
                    __out.AppendLine(); //497:73
                }
            }
            var __loop28_results = 
                (from __loop28_var1 in __Enumerate((cls).GetEnumerator()) //498:11
                from prop in __Enumerate((__loop28_var1.GetAllProperties()).GetEnumerator()) //498:16
                select new { __loop28_var1 = __loop28_var1, prop = prop}
                ).ToList(); //498:6
            int __loop28_iteration = 0;
            foreach (var __tmp94 in __loop28_results)
            {
                ++__loop28_iteration;
                var __loop28_var1 = __tmp94.__loop28_var1;
                var prop = __tmp94.prop;
                if (prop.Kind == MetaPropertyKind.Readonly) //499:4
                {
                    string __tmp95Prefix = "    if (!this.MIsSet("; //500:1
                    string __tmp96Suffix = "().\");"; //500:221
                    StringBuilder __tmp97 = new StringBuilder();
                    __tmp97.Append(prop.CSharpFullDescriptorName());
                    using(StreamReader __tmp97Reader = new StreamReader(this.__ToStream(__tmp97.ToString())))
                    {
                        bool __tmp97_first = true;
                        while(__tmp97_first || !__tmp97Reader.EndOfStream)
                        {
                            __tmp97_first = false;
                            string __tmp97Line = __tmp97Reader.ReadLine();
                            if (__tmp97Line == null)
                            {
                                if (string.IsNullOrEmpty(__tmp95Prefix) && string.IsNullOrEmpty(__tmp96Suffix)) break;
                                else __tmp97Line = "";
                            }
                            __out.Append(__tmp95Prefix);
                            __out.Append(__tmp97Line);
                        }
                    }
                    string __tmp98Line = ")) throw new ModelException(\"Readonly property "; //500:55
                    __out.Append(__tmp98Line);
                    StringBuilder __tmp99 = new StringBuilder();
                    __tmp99.Append(model.CSharpName());
                    using(StreamReader __tmp99Reader = new StreamReader(this.__ToStream(__tmp99.ToString())))
                    {
                        bool __tmp99_first = true;
                        while(__tmp99_first || !__tmp99Reader.EndOfStream)
                        {
                            __tmp99_first = false;
                            string __tmp99Line = __tmp99Reader.ReadLine();
                            if (__tmp99Line == null)
                            {
                                if (string.IsNullOrEmpty(__tmp95Prefix) && string.IsNullOrEmpty(__tmp96Suffix)) break;
                                else __tmp99Line = "";
                            }
                            __out.Append(__tmp99Line);
                        }
                    }
                    string __tmp100Line = "."; //500:122
                    __out.Append(__tmp100Line);
                    StringBuilder __tmp101 = new StringBuilder();
                    __tmp101.Append(prop.Class.CSharpName());
                    using(StreamReader __tmp101Reader = new StreamReader(this.__ToStream(__tmp101.ToString())))
                    {
                        bool __tmp101_first = true;
                        while(__tmp101_first || !__tmp101Reader.EndOfStream)
                        {
                            __tmp101_first = false;
                            string __tmp101Line = __tmp101Reader.ReadLine();
                            if (__tmp101Line == null)
                            {
                                if (string.IsNullOrEmpty(__tmp95Prefix) && string.IsNullOrEmpty(__tmp96Suffix)) break;
                                else __tmp101Line = "";
                            }
                            __out.Append(__tmp101Line);
                        }
                    }
                    string __tmp102Line = "."; //500:148
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
                                if (string.IsNullOrEmpty(__tmp95Prefix) && string.IsNullOrEmpty(__tmp96Suffix)) break;
                                else __tmp103Line = "";
                            }
                            __out.Append(__tmp103Line);
                        }
                    }
                    string __tmp104Line = "Property was not set in "; //500:160
                    __out.Append(__tmp104Line);
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
                                if (string.IsNullOrEmpty(__tmp95Prefix) && string.IsNullOrEmpty(__tmp96Suffix)) break;
                                else __tmp105Line = "";
                            }
                            __out.Append(__tmp105Line);
                        }
                    }
                    string __tmp106Line = "_"; //500:202
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
                                if (string.IsNullOrEmpty(__tmp95Prefix) && string.IsNullOrEmpty(__tmp96Suffix)) break;
                                else __tmp107Line = "";
                            }
                            __out.Append(__tmp107Line);
                            __out.Append(__tmp96Suffix);
                            __out.AppendLine(); //500:227
                        }
                    }
                }
            }
            __out.Append("    this.MMakeDefault();"); //503:1
            __out.AppendLine(); //503:25
            __out.Append("}"); //504:1
            __out.AppendLine(); //504:2
            return __out.ToString();
        }

        public string GetReturn(MetaOperation op) //507:1
        {
            if (op.ReturnType.CSharpName() == "void") //508:5
            {
                return ""; //509:3
            }
            else //510:2
            {
                return "return "; //511:3
            }
        }

        public string GenerateOperationImpl(MetaModel model, MetaOperation op) //515:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //516:1
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = ")"; //517:105
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                }
            }
            string __tmp4Line = " "; //517:39
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp5Line = "";
                    }
                    __out.Append(__tmp5Line);
                }
            }
            string __tmp6Line = "."; //517:68
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp7Line = "";
                    }
                    __out.Append(__tmp7Line);
                }
            }
            string __tmp8Line = "("; //517:78
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp9Line = "";
                    }
                    __out.Append(__tmp9Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //517:106
                }
            }
            __out.Append("{"); //518:1
            __out.AppendLine(); //518:2
            string __tmp10Prefix = "    "; //519:1
            string __tmp11Suffix = ");"; //519:125
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
                        if (string.IsNullOrEmpty(__tmp10Prefix) && string.IsNullOrEmpty(__tmp11Suffix)) break;
                        else __tmp12Line = "";
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
                        if (string.IsNullOrEmpty(__tmp10Prefix) && string.IsNullOrEmpty(__tmp11Suffix)) break;
                        else __tmp13Line = "";
                    }
                    __out.Append(__tmp13Line);
                }
            }
            string __tmp14Line = "."; //519:58
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
                        if (string.IsNullOrEmpty(__tmp10Prefix) && string.IsNullOrEmpty(__tmp11Suffix)) break;
                        else __tmp15Line = "";
                    }
                    __out.Append(__tmp15Line);
                }
            }
            string __tmp16Line = "_"; //519:83
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
                        if (string.IsNullOrEmpty(__tmp10Prefix) && string.IsNullOrEmpty(__tmp11Suffix)) break;
                        else __tmp17Line = "";
                    }
                    __out.Append(__tmp17Line);
                }
            }
            string __tmp18Line = "("; //519:93
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
                        if (string.IsNullOrEmpty(__tmp10Prefix) && string.IsNullOrEmpty(__tmp11Suffix)) break;
                        else __tmp19Line = "";
                    }
                    __out.Append(__tmp19Line);
                    __out.Append(__tmp11Suffix);
                    __out.AppendLine(); //519:127
                }
            }
            __out.Append("}"); //520:1
            __out.AppendLine(); //520:2
            return __out.ToString();
        }

        public string GetSuperClasses(MetaClass cls) //523:1
        {
            string result = ""; //524:2
            var __loop29_results = 
                (from __loop29_var1 in __Enumerate((cls).GetEnumerator()) //525:10
                from sup in __Enumerate((__loop29_var1.SuperClasses).GetEnumerator()) //525:15
                select new { __loop29_var1 = __loop29_var1, sup = sup}
                ).ToList(); //525:5
            int __loop29_iteration = 0;
            string delim = ""; //525:33
            foreach (var __tmp1 in __loop29_results)
            {
                ++__loop29_iteration;
                if (__loop29_iteration >= 2) //525:52
                {
                    delim = ", "; //525:52
                }
                var __loop29_var1 = __tmp1.__loop29_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpFullName(); //526:3
            }
            return result; //528:2
        }

        public string GetAllSuperClasses(MetaClass cls) //531:1
        {
            string result = ""; //532:2
            var __loop30_results = 
                (from __loop30_var1 in __Enumerate((cls).GetEnumerator()) //533:10
                from sup in __Enumerate((__loop30_var1.GetAllSuperClasses(false)).GetEnumerator()) //533:15
                select new { __loop30_var1 = __loop30_var1, sup = sup}
                ).ToList(); //533:5
            int __loop30_iteration = 0;
            string delim = ""; //533:46
            foreach (var __tmp1 in __loop30_results)
            {
                ++__loop30_iteration;
                if (__loop30_iteration >= 2) //533:65
                {
                    delim = ", "; //533:65
                }
                var __loop30_var1 = __tmp1.__loop30_var1;
                var sup = __tmp1.sup;
                result += delim + sup.CSharpFullName(); //534:3
            }
            return result; //536:2
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //539:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "public static class "; //540:1
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //540:51
                }
            }
            __out.Append("{"); //541:1
            __out.AppendLine(); //541:2
            string __tmp4Prefix = "    static "; //542:1
            string __tmp5Suffix = "Descriptor()"; //542:24
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
                        if (string.IsNullOrEmpty(__tmp4Prefix) && string.IsNullOrEmpty(__tmp5Suffix)) break;
                        else __tmp6Line = "";
                    }
                    __out.Append(__tmp4Prefix);
                    __out.Append(__tmp6Line);
                    __out.Append(__tmp5Suffix);
                    __out.AppendLine(); //542:36
                }
            }
            __out.Append("    {"); //543:1
            __out.AppendLine(); //543:6
            var __loop31_results = 
                (from __loop31_var1 in __Enumerate((model).GetEnumerator()) //544:11
                from Namespace in __Enumerate((__loop31_var1.Namespace).GetEnumerator()) //544:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //544:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //544:43
                select new { __loop31_var1 = __loop31_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //544:6
            int __loop31_iteration = 0;
            foreach (var __tmp7 in __loop31_results)
            {
                ++__loop31_iteration;
                var __loop31_var1 = __tmp7.__loop31_var1;
                var Namespace = __tmp7.Namespace;
                var Declarations = __tmp7.Declarations;
                var cls = __tmp7.cls;
                string __tmp8Prefix = "        "; //545:1
                string __tmp9Suffix = ".StaticInit();"; //545:27
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
                            if (string.IsNullOrEmpty(__tmp8Prefix) && string.IsNullOrEmpty(__tmp9Suffix)) break;
                            else __tmp10Line = "";
                        }
                        __out.Append(__tmp8Prefix);
                        __out.Append(__tmp10Line);
                        __out.Append(__tmp9Suffix);
                        __out.AppendLine(); //545:41
                    }
                }
            }
            __out.Append("    }"); //547:1
            __out.AppendLine(); //547:6
            __out.AppendLine(); //548:1
            __out.Append("    internal static void StaticInit()"); //549:1
            __out.AppendLine(); //549:38
            __out.Append("    {"); //550:1
            __out.AppendLine(); //550:6
            __out.Append("    }"); //551:1
            __out.AppendLine(); //551:6
            __out.AppendLine(); //552:1
            string __tmp11Prefix = "	public const string Uri = \""; //553:1
            string __tmp12Suffix = "\";"; //553:40
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
                        if (string.IsNullOrEmpty(__tmp11Prefix) && string.IsNullOrEmpty(__tmp12Suffix)) break;
                        else __tmp13Line = "";
                    }
                    __out.Append(__tmp11Prefix);
                    __out.Append(__tmp13Line);
                    __out.Append(__tmp12Suffix);
                    __out.AppendLine(); //553:42
                }
            }
            __out.AppendLine(); //554:1
            var __loop32_results = 
                (from __loop32_var1 in __Enumerate((model).GetEnumerator()) //555:11
                from Namespace in __Enumerate((__loop32_var1.Namespace).GetEnumerator()) //555:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //555:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //555:43
                select new { __loop32_var1 = __loop32_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //555:6
            int __loop32_iteration = 0;
            foreach (var __tmp14 in __loop32_results)
            {
                ++__loop32_iteration;
                var __loop32_var1 = __tmp14.__loop32_var1;
                var Namespace = __tmp14.Namespace;
                var Declarations = __tmp14.Declarations;
                var cls = __tmp14.cls;
                string __tmp15Prefix = "    "; //556:1
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
                            if (string.IsNullOrEmpty(__tmp15Prefix) && string.IsNullOrEmpty(__tmp16Suffix)) break;
                            else __tmp17Line = "";
                        }
                        __out.Append(__tmp15Prefix);
                        __out.Append(__tmp17Line);
                        __out.Append(__tmp16Suffix);
                        __out.AppendLine(); //556:34
                    }
                }
            }
            __out.Append("}"); //558:1
            __out.AppendLine(); //558:2
            __out.AppendLine(); //559:1
            return __out.ToString();
        }

        public string GenerateMetaModelClass(MetaClass cls) //563:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(); //564:1
            string __tmp1Prefix = "public static class "; //565:1
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //565:39
                }
            }
            __out.Append("{"); //566:1
            __out.AppendLine(); //566:2
            __out.Append("    internal static void StaticInit()"); //567:1
            __out.AppendLine(); //567:38
            __out.Append("    {"); //568:1
            __out.AppendLine(); //568:6
            __out.Append("    }"); //569:1
            __out.AppendLine(); //569:6
            __out.AppendLine(); //570:1
            string __tmp4Prefix = "    static "; //571:1
            string __tmp5Suffix = "()"; //571:30
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
                        if (string.IsNullOrEmpty(__tmp4Prefix) && string.IsNullOrEmpty(__tmp5Suffix)) break;
                        else __tmp6Line = "";
                    }
                    __out.Append(__tmp4Prefix);
                    __out.Append(__tmp6Line);
                    __out.Append(__tmp5Suffix);
                    __out.AppendLine(); //571:32
                }
            }
            __out.Append("    {"); //572:1
            __out.AppendLine(); //572:6
            string __tmp7Prefix = "        "; //573:1
            string __tmp8Suffix = ".StaticInit();"; //573:47
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
                        if (string.IsNullOrEmpty(__tmp7Prefix) && string.IsNullOrEmpty(__tmp8Suffix)) break;
                        else __tmp9Line = "";
                    }
                    __out.Append(__tmp7Prefix);
                    __out.Append(__tmp9Line);
                    __out.Append(__tmp8Suffix);
                    __out.AppendLine(); //573:61
                }
            }
            __out.Append("    }"); //574:1
            __out.AppendLine(); //574:6
            __out.AppendLine(); //575:1
            string __tmp10Prefix = "	"; //576:1
            string __tmp11Suffix = string.Empty; 
            StringBuilder __tmp12 = new StringBuilder();
            __tmp12.Append(GenerateDocumentation(cls));
            using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
            {
                bool __tmp12_first = true;
                while(__tmp12_first || !__tmp12Reader.EndOfStream)
                {
                    __tmp12_first = false;
                    string __tmp12Line = __tmp12Reader.ReadLine();
                    if (__tmp12Line == null)
                    {
                        if (string.IsNullOrEmpty(__tmp10Prefix) && string.IsNullOrEmpty(__tmp11Suffix)) break;
                        else __tmp12Line = "";
                    }
                    __out.Append(__tmp10Prefix);
                    __out.Append(__tmp12Line);
                    __out.Append(__tmp11Suffix);
                    __out.AppendLine(); //576:30
                }
            }
            if (cls.CSharpName() == "MetaClass") //577:2
            {
                __out.Append("    public static global::MetaDslx.Core.MetaClass _MetaClass"); //578:1
                __out.AppendLine(); //578:61
            }
            else //579:2
            {
                __out.Append("    public static global::MetaDslx.Core.MetaClass MetaClass"); //580:1
                __out.AppendLine(); //580:60
            }
            __out.Append("    {"); //582:1
            __out.AppendLine(); //582:6
            string __tmp13Prefix = "        get { return "; //583:1
            string __tmp14Suffix = "; }"; //583:52
            StringBuilder __tmp15 = new StringBuilder();
            __tmp15.Append(cls.CSharpFullInstanceName());
            using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
            {
                bool __tmp15_first = true;
                while(__tmp15_first || !__tmp15Reader.EndOfStream)
                {
                    __tmp15_first = false;
                    string __tmp15Line = __tmp15Reader.ReadLine();
                    if (__tmp15Line == null)
                    {
                        if (string.IsNullOrEmpty(__tmp13Prefix) && string.IsNullOrEmpty(__tmp14Suffix)) break;
                        else __tmp15Line = "";
                    }
                    __out.Append(__tmp13Prefix);
                    __out.Append(__tmp15Line);
                    __out.Append(__tmp14Suffix);
                    __out.AppendLine(); //583:55
                }
            }
            __out.Append("    }"); //584:1
            __out.AppendLine(); //584:6
            __out.AppendLine(); //585:1
            var __loop33_results = 
                (from __loop33_var1 in __Enumerate((cls).GetEnumerator()) //586:11
                from prop in __Enumerate((__loop33_var1.Properties).GetEnumerator()) //586:16
                select new { __loop33_var1 = __loop33_var1, prop = prop}
                ).ToList(); //586:6
            int __loop33_iteration = 0;
            foreach (var __tmp16 in __loop33_results)
            {
                ++__loop33_iteration;
                var __loop33_var1 = __tmp16.__loop33_var1;
                var prop = __tmp16.prop;
                string __tmp17Prefix = "	"; //587:1
                string __tmp18Suffix = string.Empty; 
                StringBuilder __tmp19 = new StringBuilder();
                __tmp19.Append(GenerateDocumentation(prop));
                using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
                {
                    bool __tmp19_first = true;
                    while(__tmp19_first || !__tmp19Reader.EndOfStream)
                    {
                        __tmp19_first = false;
                        string __tmp19Line = __tmp19Reader.ReadLine();
                        if (__tmp19Line == null)
                        {
                            if (string.IsNullOrEmpty(__tmp17Prefix) && string.IsNullOrEmpty(__tmp18Suffix)) break;
                            else __tmp19Line = "";
                        }
                        __out.Append(__tmp17Prefix);
                        __out.Append(__tmp19Line);
                        __out.Append(__tmp18Suffix);
                        __out.AppendLine(); //587:31
                    }
                }
                string __tmp20Prefix = "    "; //588:1
                string __tmp21Suffix = string.Empty; 
                StringBuilder __tmp22 = new StringBuilder();
                __tmp22.Append(GeneratePropertyDeclaration(cls.Model, cls, prop));
                using(StreamReader __tmp22Reader = new StreamReader(this.__ToStream(__tmp22.ToString())))
                {
                    bool __tmp22_first = true;
                    while(__tmp22_first || !__tmp22Reader.EndOfStream)
                    {
                        __tmp22_first = false;
                        string __tmp22Line = __tmp22Reader.ReadLine();
                        if (__tmp22Line == null)
                        {
                            if (string.IsNullOrEmpty(__tmp20Prefix) && string.IsNullOrEmpty(__tmp21Suffix)) break;
                            else __tmp22Line = "";
                        }
                        __out.Append(__tmp20Prefix);
                        __out.Append(__tmp22Line);
                        __out.Append(__tmp21Suffix);
                        __out.AppendLine(); //588:56
                    }
                }
            }
            __out.Append("}"); //590:1
            __out.AppendLine(); //590:2
            return __out.ToString();
        }

        public string GenerateModelConstant(MetaModel model, MetaConstant mconst) //594:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty;
            string __tmp2Suffix = string.Empty;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateDocumentation(mconst));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //595:32
                }
            }
            string __tmp4Prefix = "public static readonly "; //596:1
            string __tmp5Suffix = ";"; //596:68
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(mconst.Type.CSharpFullName());
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                while(__tmp6_first || !__tmp6Reader.EndOfStream)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    if (__tmp6Line == null)
                    {
                        if (string.IsNullOrEmpty(__tmp4Prefix) && string.IsNullOrEmpty(__tmp5Suffix)) break;
                        else __tmp6Line = "";
                    }
                    __out.Append(__tmp4Prefix);
                    __out.Append(__tmp6Line);
                }
            }
            string __tmp7Line = " "; //596:54
            __out.Append(__tmp7Line);
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(mconst.Name);
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_first = true;
                while(__tmp8_first || !__tmp8Reader.EndOfStream)
                {
                    __tmp8_first = false;
                    string __tmp8Line = __tmp8Reader.ReadLine();
                    if (__tmp8Line == null)
                    {
                        if (string.IsNullOrEmpty(__tmp4Prefix) && string.IsNullOrEmpty(__tmp5Suffix)) break;
                        else __tmp8Line = "";
                    }
                    __out.Append(__tmp8Line);
                    __out.Append(__tmp5Suffix);
                    __out.AppendLine(); //596:69
                }
            }
            return __out.ToString();
        }

        public string GenerateModelConstantImpl(MetaModel model, MetaConstant mconst, Dictionary<ModelObject,string> mobjToTmp) //599:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = ";"; //600:51
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                }
            }
            string __tmp4Line = " = "; //600:14
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp5Line = "";
                    }
                    __out.Append(__tmp5Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //600:52
                }
            }
            return __out.ToString();
        }

        public string GenerateMetaModelInstance(MetaModel model) //604:1
        {
            StringBuilder __out = new StringBuilder();
            Dictionary<ModelObject,string> mobjToName = model.GetNamedModelObjects(); //605:2
            string __tmp1Prefix = "public static class "; //606:1
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //606:50
                }
            }
            __out.Append("{"); //607:1
            __out.AppendLine(); //607:2
            __out.Append("    private static global::MetaDslx.Core.Model model;"); //608:1
            __out.AppendLine(); //608:54
            __out.AppendLine(); //609:1
            __out.Append("    public static global::MetaDslx.Core.Model Model"); //610:1
            __out.AppendLine(); //610:52
            __out.Append("    {"); //611:1
            __out.AppendLine(); //611:6
            string __tmp4Prefix = "        get { return "; //612:1
            string __tmp5Suffix = "Instance.model; }"; //612:34
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
                        if (string.IsNullOrEmpty(__tmp4Prefix) && string.IsNullOrEmpty(__tmp5Suffix)) break;
                        else __tmp6Line = "";
                    }
                    __out.Append(__tmp4Prefix);
                    __out.Append(__tmp6Line);
                    __out.Append(__tmp5Suffix);
                    __out.AppendLine(); //612:51
                }
            }
            __out.Append("    }"); //613:1
            __out.AppendLine(); //613:6
            __out.AppendLine(); //614:1
            __out.Append("    public static readonly global::MetaDslx.Core.MetaModel Meta;"); //615:1
            __out.AppendLine(); //615:65
            __out.AppendLine(); //616:1
            var __loop34_results = 
                (from __loop34_var1 in __Enumerate((model).GetEnumerator()) //617:11
                from Namespace in __Enumerate((__loop34_var1.Namespace).GetEnumerator()) //617:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //617:29
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //617:43
                select new { __loop34_var1 = __loop34_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //617:6
            int __loop34_iteration = 0;
            foreach (var __tmp7 in __loop34_results)
            {
                ++__loop34_iteration;
                var __loop34_var1 = __tmp7.__loop34_var1;
                var Namespace = __tmp7.Namespace;
                var Declarations = __tmp7.Declarations;
                var c = __tmp7.c;
                string __tmp8Prefix = "    "; //618:1
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
                            if (string.IsNullOrEmpty(__tmp8Prefix) && string.IsNullOrEmpty(__tmp9Suffix)) break;
                            else __tmp10Line = "";
                        }
                        __out.Append(__tmp8Prefix);
                        __out.Append(__tmp10Line);
                        __out.Append(__tmp9Suffix);
                        __out.AppendLine(); //618:38
                    }
                }
            }
            __out.AppendLine(); //620:1
            var __loop35_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //621:11
                select new { mobj = mobj}
                ).ToList(); //621:6
            int __loop35_iteration = 0;
            foreach (var __tmp11 in __loop35_results)
            {
                ++__loop35_iteration;
                var mobj = __tmp11.mobj;
                string __tmp12Prefix = "	"; //622:1
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
                            if (string.IsNullOrEmpty(__tmp12Prefix) && string.IsNullOrEmpty(__tmp13Suffix)) break;
                            else __tmp14Line = "";
                        }
                        __out.Append(__tmp12Prefix);
                        __out.Append(__tmp14Line);
                        __out.Append(__tmp13Suffix);
                        __out.AppendLine(); //622:60
                    }
                }
            }
            __out.AppendLine(); //624:1
            string __tmp15Prefix = "    static "; //625:1
            string __tmp16Suffix = "()"; //625:41
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
                        if (string.IsNullOrEmpty(__tmp15Prefix) && string.IsNullOrEmpty(__tmp16Suffix)) break;
                        else __tmp17Line = "";
                    }
                    __out.Append(__tmp15Prefix);
                    __out.Append(__tmp17Line);
                    __out.Append(__tmp16Suffix);
                    __out.AppendLine(); //625:43
                }
            }
            __out.Append("    {"); //626:1
            __out.AppendLine(); //626:6
            string __tmp18Prefix = "		"; //627:1
            string __tmp19Suffix = ".StaticInit();"; //627:33
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
                        if (string.IsNullOrEmpty(__tmp18Prefix) && string.IsNullOrEmpty(__tmp19Suffix)) break;
                        else __tmp20Line = "";
                    }
                    __out.Append(__tmp18Prefix);
                    __out.Append(__tmp20Line);
                    __out.Append(__tmp19Suffix);
                    __out.AppendLine(); //627:47
                }
            }
            string __tmp21Prefix = "		"; //628:1
            string __tmp22Suffix = ".model = new global::MetaDslx.Core.Model();"; //628:32
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
                        if (string.IsNullOrEmpty(__tmp21Prefix) && string.IsNullOrEmpty(__tmp22Suffix)) break;
                        else __tmp23Line = "";
                    }
                    __out.Append(__tmp21Prefix);
                    __out.Append(__tmp23Line);
                    __out.Append(__tmp22Suffix);
                    __out.AppendLine(); //628:75
                }
            }
            string __tmp24Prefix = "   		using (new ModelContextScope("; //629:1
            string __tmp25Suffix = ".model))"; //629:64
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
                        if (string.IsNullOrEmpty(__tmp24Prefix) && string.IsNullOrEmpty(__tmp25Suffix)) break;
                        else __tmp26Line = "";
                    }
                    __out.Append(__tmp24Prefix);
                    __out.Append(__tmp26Line);
                    __out.Append(__tmp25Suffix);
                    __out.AppendLine(); //629:72
                }
            }
            __out.Append("		{"); //630:1
            __out.AppendLine(); //630:4
            var __loop36_results = 
                (from __loop36_var1 in __Enumerate((model).GetEnumerator()) //631:13
                from Namespace in __Enumerate((__loop36_var1.Namespace).GetEnumerator()) //631:20
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //631:31
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //631:45
                select new { __loop36_var1 = __loop36_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //631:8
            int __loop36_iteration = 0;
            foreach (var __tmp27 in __loop36_results)
            {
                ++__loop36_iteration;
                var __loop36_var1 = __tmp27.__loop36_var1;
                var Namespace = __tmp27.Namespace;
                var Declarations = __tmp27.Declarations;
                var c = __tmp27.c;
                string __tmp28Prefix = "            "; //632:1
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
                            if (string.IsNullOrEmpty(__tmp28Prefix) && string.IsNullOrEmpty(__tmp29Suffix)) break;
                            else __tmp30Line = "";
                        }
                        __out.Append(__tmp28Prefix);
                        __out.Append(__tmp30Line);
                        __out.Append(__tmp29Suffix);
                        __out.AppendLine(); //632:62
                    }
                }
            }
            __out.AppendLine(); //634:1
            var __loop37_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //635:10
                select new { mobj = mobj}
                ).ToList(); //635:5
            int __loop37_iteration = 0;
            foreach (var __tmp31 in __loop37_results)
            {
                ++__loop37_iteration;
                var mobj = __tmp31.mobj;
                string __tmp32Prefix = "			"; //636:1
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
                            if (string.IsNullOrEmpty(__tmp32Prefix) && string.IsNullOrEmpty(__tmp33Suffix)) break;
                            else __tmp34Line = "";
                        }
                        __out.Append(__tmp32Prefix);
                        __out.Append(__tmp34Line);
                        __out.Append(__tmp33Suffix);
                        __out.AppendLine(); //636:51
                    }
                }
            }
            __out.AppendLine(); //638:1
            var __loop38_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //639:10
                select new { mobj = mobj}
                ).ToList(); //639:5
            int __loop38_iteration = 0;
            foreach (var __tmp35 in __loop38_results)
            {
                ++__loop38_iteration;
                var mobj = __tmp35.mobj;
                string __tmp36Prefix = "			"; //640:1
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
                            if (string.IsNullOrEmpty(__tmp36Prefix) && string.IsNullOrEmpty(__tmp37Suffix)) break;
                            else __tmp38Line = "";
                        }
                        __out.Append(__tmp36Prefix);
                        __out.Append(__tmp38Line);
                        __out.Append(__tmp37Suffix);
                        __out.AppendLine(); //640:62
                    }
                }
            }
            __out.AppendLine(); //642:1
            string __tmp39Prefix = "            "; //643:1
            string __tmp40Suffix = ".model.EvalLazyValues();"; //643:42
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
                        if (string.IsNullOrEmpty(__tmp39Prefix) && string.IsNullOrEmpty(__tmp40Suffix)) break;
                        else __tmp41Line = "";
                    }
                    __out.Append(__tmp39Prefix);
                    __out.Append(__tmp41Line);
                    __out.Append(__tmp40Suffix);
                    __out.AppendLine(); //643:66
                }
            }
            __out.Append("		}"); //644:1
            __out.AppendLine(); //644:4
            __out.Append("    }"); //645:1
            __out.AppendLine(); //645:6
            __out.Append("}"); //646:1
            __out.AppendLine(); //646:2
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceDeclaration(ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //650:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //651:2
            {
                if (mobjToName.ContainsKey(mobj)) //652:3
                {
                    string name = mobjToName[mobj]; //653:4
                    if (name.StartsWith("__")) //654:4
                    {
                        string __tmp1Prefix = "private static readonly global::MetaDslx.Core."; //655:1
                        string __tmp2Suffix = ";"; //655:84
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
                                    if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                                    else __tmp3Line = "";
                                }
                                __out.Append(__tmp1Prefix);
                                __out.Append(__tmp3Line);
                            }
                        }
                        string __tmp4Line = " "; //655:77
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
                                    if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                                    else __tmp5Line = "";
                                }
                                __out.Append(__tmp5Line);
                                __out.Append(__tmp2Suffix);
                                __out.AppendLine(); //655:85
                            }
                        }
                    }
                    else //656:4
                    {
                        if (mobj is MetaDocumentedElement) //657:5
                        {
                            string __tmp6Prefix = string.Empty;
                            string __tmp7Suffix = string.Empty;
                            StringBuilder __tmp8 = new StringBuilder();
                            __tmp8.Append(GenerateDocumentation(((MetaDocumentedElement)mobj)));
                            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                            {
                                bool __tmp8_first = true;
                                while(__tmp8_first || !__tmp8Reader.EndOfStream)
                                {
                                    __tmp8_first = false;
                                    string __tmp8Line = __tmp8Reader.ReadLine();
                                    if (__tmp8Line == null)
                                    {
                                        if (string.IsNullOrEmpty(__tmp6Prefix) && string.IsNullOrEmpty(__tmp7Suffix)) break;
                                        else __tmp8Line = "";
                                    }
                                    __out.Append(__tmp6Prefix);
                                    __out.Append(__tmp8Line);
                                    __out.Append(__tmp7Suffix);
                                    __out.AppendLine(); //658:55
                                }
                            }
                        }
                        string __tmp9Prefix = "public static readonly global::MetaDslx.Core."; //660:1
                        string __tmp10Suffix = ";"; //660:83
                        StringBuilder __tmp11 = new StringBuilder();
                        __tmp11.Append(mobj.MMetaClass.CSharpName());
                        using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                        {
                            bool __tmp11_first = true;
                            while(__tmp11_first || !__tmp11Reader.EndOfStream)
                            {
                                __tmp11_first = false;
                                string __tmp11Line = __tmp11Reader.ReadLine();
                                if (__tmp11Line == null)
                                {
                                    if (string.IsNullOrEmpty(__tmp9Prefix) && string.IsNullOrEmpty(__tmp10Suffix)) break;
                                    else __tmp11Line = "";
                                }
                                __out.Append(__tmp9Prefix);
                                __out.Append(__tmp11Line);
                            }
                        }
                        string __tmp12Line = " "; //660:76
                        __out.Append(__tmp12Line);
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
                                    if (string.IsNullOrEmpty(__tmp9Prefix) && string.IsNullOrEmpty(__tmp10Suffix)) break;
                                    else __tmp13Line = "";
                                }
                                __out.Append(__tmp13Line);
                                __out.Append(__tmp10Suffix);
                                __out.AppendLine(); //660:84
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstance(ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //667:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //668:2
            {
                if (mobjToName.ContainsKey(mobj)) //669:3
                {
                    string name = mobjToName[mobj]; //670:4
                    string __tmp1Prefix = string.Empty; 
                    string __tmp2Suffix = "();"; //671:89
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
                                if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                                else __tmp3Line = "";
                            }
                            __out.Append(__tmp1Prefix);
                            __out.Append(__tmp3Line);
                        }
                    }
                    string __tmp4Line = " = global::MetaDslx.Core.MetaFactory.Instance.Create"; //671:7
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
                                if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                                else __tmp5Line = "";
                            }
                            __out.Append(__tmp5Line);
                            __out.Append(__tmp2Suffix);
                            __out.AppendLine(); //671:92
                        }
                    }
                    if (mobj is MetaModel) //672:4
                    {
                        string __tmp6Prefix = "Meta = "; //673:1
                        string __tmp7Suffix = ";"; //673:14
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
                                    if (string.IsNullOrEmpty(__tmp6Prefix) && string.IsNullOrEmpty(__tmp7Suffix)) break;
                                    else __tmp8Line = "";
                                }
                                __out.Append(__tmp6Prefix);
                                __out.Append(__tmp8Line);
                                __out.Append(__tmp7Suffix);
                                __out.AppendLine(); //673:15
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceInitializer(ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //680:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //681:2
            {
                if (mobjToName.ContainsKey(mobj)) //682:3
                {
                    var __loop39_results = 
                        (from __loop39_var1 in __Enumerate((mobj).GetEnumerator()) //683:9
                        from prop in __Enumerate((__loop39_var1.MGetAllProperties()).GetEnumerator()) //683:15
                        select new { __loop39_var1 = __loop39_var1, prop = prop}
                        ).ToList(); //683:4
                    int __loop39_iteration = 0;
                    foreach (var __tmp1 in __loop39_results)
                    {
                        ++__loop39_iteration;
                        var __loop39_var1 = __tmp1.__loop39_var1;
                        var prop = __tmp1.prop;
                        if (prop.MetaProperty != null && prop.MetaProperty.Kind != MetaPropertyKind.Derived) //684:5
                        {
                            object propValue = mobj.MGet(prop); //685:6
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
                                        if (string.IsNullOrEmpty(__tmp2Prefix) && string.IsNullOrEmpty(__tmp3Suffix)) break;
                                        else __tmp4Line = "";
                                    }
                                    __out.Append(__tmp2Prefix);
                                    __out.Append(__tmp4Line);
                                    __out.Append(__tmp3Suffix);
                                    __out.AppendLine(); //686:70
                                }
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectPropertyValue(ModelObject mobj, ModelProperty prop, object value, Dictionary<ModelObject,string> mobjToName) //694:1
        {
            StringBuilder __out = new StringBuilder();
            string name = mobjToName[mobj]; //695:2
            string propDeclName = "global::" + prop.DeclaringType.FullName.Replace("+", ".") + "." + prop.DeclaredName; //696:2
            if (!prop.IsCollection) //697:2
            {
                string __tmp1Prefix = "((ModelObject)"; //698:1
                string __tmp2Suffix = ");"; //698:44
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
                            if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                            else __tmp3Line = "";
                        }
                        __out.Append(__tmp1Prefix);
                        __out.Append(__tmp3Line);
                    }
                }
                string __tmp4Line = ").MUnSet("; //698:21
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
                            if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                            else __tmp5Line = "";
                        }
                        __out.Append(__tmp5Line);
                        __out.Append(__tmp2Suffix);
                        __out.AppendLine(); //698:46
                    }
                }
            }
            ModelObject moValue = value as ModelObject; //700:2
            if (value == null) //701:2
            {
                string __tmp6Prefix = "((ModelObject)"; //702:1
                string __tmp7Suffix = ", new Lazy<object>(() => null, LazyThreadSafetyMode.ExecutionAndPublication));"; //702:46
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
                            if (string.IsNullOrEmpty(__tmp6Prefix) && string.IsNullOrEmpty(__tmp7Suffix)) break;
                            else __tmp8Line = "";
                        }
                        __out.Append(__tmp6Prefix);
                        __out.Append(__tmp8Line);
                    }
                }
                string __tmp9Line = ").MLazyAdd("; //702:21
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
                            if (string.IsNullOrEmpty(__tmp6Prefix) && string.IsNullOrEmpty(__tmp7Suffix)) break;
                            else __tmp10Line = "";
                        }
                        __out.Append(__tmp10Line);
                        __out.Append(__tmp7Suffix);
                        __out.AppendLine(); //702:124
                    }
                }
            }
            else if (value is string) //703:2
            {
                string __tmp11Prefix = "((ModelObject)"; //704:1
                string __tmp12Suffix = "\", LazyThreadSafetyMode.ExecutionAndPublication));"; //704:79
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
                            if (string.IsNullOrEmpty(__tmp11Prefix) && string.IsNullOrEmpty(__tmp12Suffix)) break;
                            else __tmp13Line = "";
                        }
                        __out.Append(__tmp11Prefix);
                        __out.Append(__tmp13Line);
                    }
                }
                string __tmp14Line = ").MLazyAdd("; //704:21
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
                            if (string.IsNullOrEmpty(__tmp11Prefix) && string.IsNullOrEmpty(__tmp12Suffix)) break;
                            else __tmp15Line = "";
                        }
                        __out.Append(__tmp15Line);
                    }
                }
                string __tmp16Line = ", new Lazy<object>(() => \""; //704:46
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
                            if (string.IsNullOrEmpty(__tmp11Prefix) && string.IsNullOrEmpty(__tmp12Suffix)) break;
                            else __tmp17Line = "";
                        }
                        __out.Append(__tmp17Line);
                        __out.Append(__tmp12Suffix);
                        __out.AppendLine(); //704:129
                    }
                }
            }
            else if (value is bool) //705:2
            {
                string __tmp18Prefix = "((ModelObject)"; //706:1
                string __tmp19Suffix = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //706:99
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
                            if (string.IsNullOrEmpty(__tmp18Prefix) && string.IsNullOrEmpty(__tmp19Suffix)) break;
                            else __tmp20Line = "";
                        }
                        __out.Append(__tmp18Prefix);
                        __out.Append(__tmp20Line);
                    }
                }
                string __tmp21Line = ").MLazyAdd("; //706:21
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
                            if (string.IsNullOrEmpty(__tmp18Prefix) && string.IsNullOrEmpty(__tmp19Suffix)) break;
                            else __tmp22Line = "";
                        }
                        __out.Append(__tmp22Line);
                    }
                }
                string __tmp23Line = ", new Lazy<object>(() => "; //706:46
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
                            if (string.IsNullOrEmpty(__tmp18Prefix) && string.IsNullOrEmpty(__tmp19Suffix)) break;
                            else __tmp24Line = "";
                        }
                        __out.Append(__tmp24Line);
                        __out.Append(__tmp19Suffix);
                        __out.AppendLine(); //706:148
                    }
                }
            }
            else if (value.GetType().IsPrimitive) //707:2
            {
                string __tmp25Prefix = "((ModelObject)"; //708:1
                string __tmp26Suffix = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //708:89
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
                            if (string.IsNullOrEmpty(__tmp25Prefix) && string.IsNullOrEmpty(__tmp26Suffix)) break;
                            else __tmp27Line = "";
                        }
                        __out.Append(__tmp25Prefix);
                        __out.Append(__tmp27Line);
                    }
                }
                string __tmp28Line = ").MLazyAdd("; //708:21
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
                            if (string.IsNullOrEmpty(__tmp25Prefix) && string.IsNullOrEmpty(__tmp26Suffix)) break;
                            else __tmp29Line = "";
                        }
                        __out.Append(__tmp29Line);
                    }
                }
                string __tmp30Line = ", new Lazy<object>(() => "; //708:46
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
                            if (string.IsNullOrEmpty(__tmp25Prefix) && string.IsNullOrEmpty(__tmp26Suffix)) break;
                            else __tmp31Line = "";
                        }
                        __out.Append(__tmp31Line);
                        __out.Append(__tmp26Suffix);
                        __out.AppendLine(); //708:138
                    }
                }
            }
            else if (MetaBuiltInTypes.Types.Contains(value)) //709:2
            {
                string __tmp32Prefix = "((ModelObject)"; //710:1
                string __tmp33Suffix = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //710:94
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
                            if (string.IsNullOrEmpty(__tmp32Prefix) && string.IsNullOrEmpty(__tmp33Suffix)) break;
                            else __tmp34Line = "";
                        }
                        __out.Append(__tmp32Prefix);
                        __out.Append(__tmp34Line);
                    }
                }
                string __tmp35Line = ").MLazyAdd("; //710:21
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
                            if (string.IsNullOrEmpty(__tmp32Prefix) && string.IsNullOrEmpty(__tmp33Suffix)) break;
                            else __tmp36Line = "";
                        }
                        __out.Append(__tmp36Line);
                    }
                }
                string __tmp37Line = ", new Lazy<object>(() => "; //710:46
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
                            if (string.IsNullOrEmpty(__tmp32Prefix) && string.IsNullOrEmpty(__tmp33Suffix)) break;
                            else __tmp38Line = "";
                        }
                        __out.Append(__tmp38Line);
                        __out.Append(__tmp33Suffix);
                        __out.AppendLine(); //710:143
                    }
                }
            }
            else if (value is MetaPrimitiveType) //711:2
            {
                string __tmp39Prefix = "((ModelObject)"; //712:1
                string __tmp40Suffix = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //712:94
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
                            if (string.IsNullOrEmpty(__tmp39Prefix) && string.IsNullOrEmpty(__tmp40Suffix)) break;
                            else __tmp41Line = "";
                        }
                        __out.Append(__tmp39Prefix);
                        __out.Append(__tmp41Line);
                    }
                }
                string __tmp42Line = ").MLazyAdd("; //712:21
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
                            if (string.IsNullOrEmpty(__tmp39Prefix) && string.IsNullOrEmpty(__tmp40Suffix)) break;
                            else __tmp43Line = "";
                        }
                        __out.Append(__tmp43Line);
                    }
                }
                string __tmp44Line = ", new Lazy<object>(() => "; //712:46
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
                            if (string.IsNullOrEmpty(__tmp39Prefix) && string.IsNullOrEmpty(__tmp40Suffix)) break;
                            else __tmp45Line = "";
                        }
                        __out.Append(__tmp45Line);
                        __out.Append(__tmp40Suffix);
                        __out.AppendLine(); //712:143
                    }
                }
            }
            else if (value is Enum) //713:2
            {
                string __tmp46Prefix = "((ModelObject)"; //714:1
                string __tmp47Suffix = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //714:94
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
                            if (string.IsNullOrEmpty(__tmp46Prefix) && string.IsNullOrEmpty(__tmp47Suffix)) break;
                            else __tmp48Line = "";
                        }
                        __out.Append(__tmp46Prefix);
                        __out.Append(__tmp48Line);
                    }
                }
                string __tmp49Line = ").MLazyAdd("; //714:21
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
                            if (string.IsNullOrEmpty(__tmp46Prefix) && string.IsNullOrEmpty(__tmp47Suffix)) break;
                            else __tmp50Line = "";
                        }
                        __out.Append(__tmp50Line);
                    }
                }
                string __tmp51Line = ", new Lazy<object>(() => "; //714:46
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
                            if (string.IsNullOrEmpty(__tmp46Prefix) && string.IsNullOrEmpty(__tmp47Suffix)) break;
                            else __tmp52Line = "";
                        }
                        __out.Append(__tmp52Line);
                        __out.Append(__tmp47Suffix);
                        __out.AppendLine(); //714:143
                    }
                }
            }
            else if (moValue != null) //715:2
            {
                if (mobjToName.ContainsKey(moValue)) //716:3
                {
                    string __tmp53Prefix = "((ModelObject)"; //717:1
                    string __tmp54Suffix = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //717:92
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
                                if (string.IsNullOrEmpty(__tmp53Prefix) && string.IsNullOrEmpty(__tmp54Suffix)) break;
                                else __tmp55Line = "";
                            }
                            __out.Append(__tmp53Prefix);
                            __out.Append(__tmp55Line);
                        }
                    }
                    string __tmp56Line = ").MLazyAdd("; //717:21
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
                                if (string.IsNullOrEmpty(__tmp53Prefix) && string.IsNullOrEmpty(__tmp54Suffix)) break;
                                else __tmp57Line = "";
                            }
                            __out.Append(__tmp57Line);
                        }
                    }
                    string __tmp58Line = ", new Lazy<object>(() => "; //717:46
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
                                if (string.IsNullOrEmpty(__tmp53Prefix) && string.IsNullOrEmpty(__tmp54Suffix)) break;
                                else __tmp59Line = "";
                            }
                            __out.Append(__tmp59Line);
                            __out.Append(__tmp54Suffix);
                            __out.AppendLine(); //717:141
                        }
                    }
                }
                else //718:3
                {
                    string __tmp60Prefix = "// Omitted since not part of the model: "; //719:1
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
                                if (string.IsNullOrEmpty(__tmp60Prefix) && string.IsNullOrEmpty(__tmp61Suffix)) break;
                                else __tmp62Line = "";
                            }
                            __out.Append(__tmp60Prefix);
                            __out.Append(__tmp62Line);
                        }
                    }
                    string __tmp63Line = "."; //719:47
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
                                if (string.IsNullOrEmpty(__tmp60Prefix) && string.IsNullOrEmpty(__tmp61Suffix)) break;
                                else __tmp64Line = "";
                            }
                            __out.Append(__tmp64Line);
                        }
                    }
                    string __tmp65Line = " = "; //719:62
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
                                if (string.IsNullOrEmpty(__tmp60Prefix) && string.IsNullOrEmpty(__tmp61Suffix)) break;
                                else __tmp66Line = "";
                            }
                            __out.Append(__tmp66Line);
                            __out.Append(__tmp61Suffix);
                            __out.AppendLine(); //719:74
                        }
                    }
                }
            }
            else //721:2
            {
                IEnumerable<object> mc = (value as ModelCollection) as IEnumerable<object>; //722:3
                if (mc != null) //723:3
                {
                    var __loop40_results = 
                        (from cvalue in __Enumerate((mc).GetEnumerator()) //724:9
                        select new { cvalue = cvalue}
                        ).ToList(); //724:4
                    int __loop40_iteration = 0;
                    foreach (var __tmp67 in __loop40_results)
                    {
                        ++__loop40_iteration;
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
                                    if (string.IsNullOrEmpty(__tmp68Prefix) && string.IsNullOrEmpty(__tmp69Suffix)) break;
                                    else __tmp70Line = "";
                                }
                                __out.Append(__tmp68Prefix);
                                __out.Append(__tmp70Line);
                                __out.Append(__tmp69Suffix);
                                __out.AppendLine(); //725:67
                            }
                        }
                    }
                }
                else //727:3
                {
                    string __tmp71Prefix = "// Invalid property value type: "; //728:1
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
                                if (string.IsNullOrEmpty(__tmp71Prefix) && string.IsNullOrEmpty(__tmp72Suffix)) break;
                                else __tmp73Line = "";
                            }
                            __out.Append(__tmp71Prefix);
                            __out.Append(__tmp73Line);
                        }
                    }
                    string __tmp74Line = "."; //728:39
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
                                if (string.IsNullOrEmpty(__tmp71Prefix) && string.IsNullOrEmpty(__tmp72Suffix)) break;
                                else __tmp75Line = "";
                            }
                            __out.Append(__tmp75Line);
                        }
                    }
                    string __tmp76Line = " = "; //728:54
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
                                if (string.IsNullOrEmpty(__tmp71Prefix) && string.IsNullOrEmpty(__tmp72Suffix)) break;
                                else __tmp77Line = "";
                            }
                            __out.Append(__tmp77Line);
                            __out.Append(__tmp72Suffix);
                            __out.AppendLine(); //728:74
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GetInstanceName(ModelObject mobj) //734:1
        {
            MetaAnnotatedElement mannot = mobj as MetaAnnotatedElement; //735:2
            if (mannot != null && !(mobj is MetaConstant)) //736:2
            {
                var __loop41_results = 
                    (from __loop41_var1 in __Enumerate((mannot).GetEnumerator()) //737:8
                    from a in __Enumerate((__loop41_var1.Annotations).GetEnumerator()) //737:16
                    from p in __Enumerate((a.Properties).GetEnumerator()) //737:31
                    where a.Name == "BuiltInName" && p.Name == "Name" //737:44
                    select new { __loop41_var1 = __loop41_var1, a = a, p = p}
                    ).ToList(); //737:3
                int __loop41_iteration = 0;
                foreach (var __tmp1 in __loop41_results)
                {
                    ++__loop41_iteration;
                    var __loop41_var1 = __tmp1.__loop41_var1;
                    var a = __tmp1.a;
                    var p = __tmp1.p;
                    return GetCSharpIdentifier(p.Value); //738:4
                }
            }
            MetaDeclaration mdecl = mobj as MetaDeclaration; //741:2
            if (mdecl != null && !(mdecl is MetaOperation) && !(mobj is MetaConstant)) //742:2
            {
                return mdecl.CSharpInstanceName(); //743:3
            }
            MetaProperty mprop = mobj as MetaProperty; //745:2
            if (mprop != null) //746:2
            {
                return mprop.CSharpInstanceName(); //747:3
            }
            return null; //749:2
        }

        public string GetEnumValueOf(object enm) //754:1
        {
            return "global::" + enm.GetType().FullName.Replace("+", ".") + "." + enm.ToString(); //755:2
        }

        public string GenerateClassMetaInstance(MetaClass cls) //758:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = " = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();"; //759:19
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //759:83
                }
            }
            return __out.ToString();
        }

        public string GenerateClassMetaInstanceInitializer(MetaClass cls) //762:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = string.Empty; 
            string __tmp2Suffix = "\";"; //763:46
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                }
            }
            string __tmp4Line = ".Name = \""; //763:19
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp5Line = "";
                    }
                    __out.Append(__tmp5Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //763:48
                }
            }
            if (cls.IsAbstract) //764:2
            {
                string __tmp6Prefix = string.Empty; 
                string __tmp7Suffix = ".IsAbstract = true;"; //765:19
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
                            if (string.IsNullOrEmpty(__tmp6Prefix) && string.IsNullOrEmpty(__tmp7Suffix)) break;
                            else __tmp8Line = "";
                        }
                        __out.Append(__tmp6Prefix);
                        __out.Append(__tmp8Line);
                        __out.Append(__tmp7Suffix);
                        __out.AppendLine(); //765:38
                    }
                }
            }
            var __loop42_results = 
                (from __loop42_var1 in __Enumerate((cls).GetEnumerator()) //767:7
                from sup in __Enumerate((__loop42_var1.SuperClasses).GetEnumerator()) //767:12
                select new { __loop42_var1 = __loop42_var1, sup = sup}
                ).ToList(); //767:2
            int __loop42_iteration = 0;
            foreach (var __tmp9 in __loop42_results)
            {
                ++__loop42_iteration;
                var __loop42_var1 = __tmp9.__loop42_var1;
                var sup = __tmp9.sup;
                string __tmp10Prefix = string.Empty; 
                string __tmp11Suffix = ");"; //768:67
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
                            if (string.IsNullOrEmpty(__tmp10Prefix) && string.IsNullOrEmpty(__tmp11Suffix)) break;
                            else __tmp12Line = "";
                        }
                        __out.Append(__tmp10Prefix);
                        __out.Append(__tmp12Line);
                    }
                }
                string __tmp13Line = ".SuperClasses.Add("; //768:19
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
                            if (string.IsNullOrEmpty(__tmp10Prefix) && string.IsNullOrEmpty(__tmp11Suffix)) break;
                            else __tmp14Line = "";
                        }
                        __out.Append(__tmp14Line);
                        __out.Append(__tmp11Suffix);
                        __out.AppendLine(); //768:69
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //773:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp1Prefix = "internal static class "; //774:1
            string __tmp2Suffix = "ImplementationProvider"; //774:35
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //774:57
                }
            }
            __out.Append("{"); //775:1
            __out.AppendLine(); //775:2
            string __tmp4Prefix = "    // If there is a compile error at this line, create a new class called "; //776:1
            string __tmp5Suffix = "Implementation"; //776:88
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
                        if (string.IsNullOrEmpty(__tmp4Prefix) && string.IsNullOrEmpty(__tmp5Suffix)) break;
                        else __tmp6Line = "";
                    }
                    __out.Append(__tmp4Prefix);
                    __out.Append(__tmp6Line);
                    __out.Append(__tmp5Suffix);
                    __out.AppendLine(); //776:102
                }
            }
            string __tmp7Prefix = "	// which is a subclass of "; //777:1
            string __tmp8Suffix = "ImplementationBase:"; //777:40
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
                        if (string.IsNullOrEmpty(__tmp7Prefix) && string.IsNullOrEmpty(__tmp8Suffix)) break;
                        else __tmp9Line = "";
                    }
                    __out.Append(__tmp7Prefix);
                    __out.Append(__tmp9Line);
                    __out.Append(__tmp8Suffix);
                    __out.AppendLine(); //777:59
                }
            }
            string __tmp10Prefix = "    private static "; //778:1
            string __tmp11Suffix = "Implementation();"; //778:80
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
                        if (string.IsNullOrEmpty(__tmp10Prefix) && string.IsNullOrEmpty(__tmp11Suffix)) break;
                        else __tmp12Line = "";
                    }
                    __out.Append(__tmp10Prefix);
                    __out.Append(__tmp12Line);
                }
            }
            string __tmp13Line = "Implementation implementation = new "; //778:32
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
                        if (string.IsNullOrEmpty(__tmp10Prefix) && string.IsNullOrEmpty(__tmp11Suffix)) break;
                        else __tmp14Line = "";
                    }
                    __out.Append(__tmp14Line);
                    __out.Append(__tmp11Suffix);
                    __out.AppendLine(); //778:97
                }
            }
            __out.AppendLine(); //779:1
            string __tmp15Prefix = "    public static "; //780:1
            string __tmp16Suffix = "Implementation Implementation"; //780:31
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
                        if (string.IsNullOrEmpty(__tmp15Prefix) && string.IsNullOrEmpty(__tmp16Suffix)) break;
                        else __tmp17Line = "";
                    }
                    __out.Append(__tmp15Prefix);
                    __out.Append(__tmp17Line);
                    __out.Append(__tmp16Suffix);
                    __out.AppendLine(); //780:60
                }
            }
            __out.Append("    {"); //781:1
            __out.AppendLine(); //781:6
            string __tmp18Prefix = "        get { return "; //782:1
            string __tmp19Suffix = "ImplementationProvider.implementation; }"; //782:34
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
                        if (string.IsNullOrEmpty(__tmp18Prefix) && string.IsNullOrEmpty(__tmp19Suffix)) break;
                        else __tmp20Line = "";
                    }
                    __out.Append(__tmp18Prefix);
                    __out.Append(__tmp20Line);
                    __out.Append(__tmp19Suffix);
                    __out.AppendLine(); //782:74
                }
            }
            __out.Append("    }"); //783:1
            __out.AppendLine(); //783:6
            __out.Append("}"); //784:1
            __out.AppendLine(); //784:2
            var __loop43_results = 
                (from __loop43_var1 in __Enumerate((model).GetEnumerator()) //785:8
                from Namespace in __Enumerate((__loop43_var1.Namespace).GetEnumerator()) //785:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //785:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //785:40
                select new { __loop43_var1 = __loop43_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //785:3
            int __loop43_iteration = 0;
            foreach (var __tmp21 in __loop43_results)
            {
                ++__loop43_iteration;
                var __loop43_var1 = __tmp21.__loop43_var1;
                var Namespace = __tmp21.Namespace;
                var Declarations = __tmp21.Declarations;
                var enm = __tmp21.enm;
                __out.AppendLine(); //786:1
                string __tmp22Prefix = "public static class "; //787:1
                string __tmp23Suffix = "Extensions"; //787:31
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
                            if (string.IsNullOrEmpty(__tmp22Prefix) && string.IsNullOrEmpty(__tmp23Suffix)) break;
                            else __tmp24Line = "";
                        }
                        __out.Append(__tmp22Prefix);
                        __out.Append(__tmp24Line);
                        __out.Append(__tmp23Suffix);
                        __out.AppendLine(); //787:41
                    }
                }
                __out.Append("{"); //788:1
                __out.AppendLine(); //788:2
                var __loop44_results = 
                    (from __loop44_var1 in __Enumerate((enm).GetEnumerator()) //789:11
                    from op in __Enumerate((__loop44_var1.Operations).GetEnumerator()) //789:16
                    select new { __loop44_var1 = __loop44_var1, op = op}
                    ).ToList(); //789:6
                int __loop44_iteration = 0;
                foreach (var __tmp25 in __loop44_results)
                {
                    ++__loop44_iteration;
                    var __loop44_var1 = __tmp25.__loop44_var1;
                    var op = __tmp25.op;
                    string __tmp26Prefix = "    public static "; //790:1
                    string __tmp27Suffix = ")"; //790:100
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
                                if (string.IsNullOrEmpty(__tmp26Prefix) && string.IsNullOrEmpty(__tmp27Suffix)) break;
                                else __tmp28Line = "";
                            }
                            __out.Append(__tmp26Prefix);
                            __out.Append(__tmp28Line);
                        }
                    }
                    string __tmp29Line = " "; //790:57
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
                                if (string.IsNullOrEmpty(__tmp26Prefix) && string.IsNullOrEmpty(__tmp27Suffix)) break;
                                else __tmp30Line = "";
                            }
                            __out.Append(__tmp30Line);
                        }
                    }
                    string __tmp31Line = "("; //790:67
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
                                if (string.IsNullOrEmpty(__tmp26Prefix) && string.IsNullOrEmpty(__tmp27Suffix)) break;
                                else __tmp32Line = "";
                            }
                            __out.Append(__tmp32Line);
                            __out.Append(__tmp27Suffix);
                            __out.AppendLine(); //790:101
                        }
                    }
                    __out.Append("    {"); //791:1
                    __out.AppendLine(); //791:6
                    string __tmp33Prefix = "        "; //792:1
                    string __tmp34Suffix = ");"; //792:144
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
                                if (string.IsNullOrEmpty(__tmp33Prefix) && string.IsNullOrEmpty(__tmp34Suffix)) break;
                                else __tmp35Line = "";
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
                                if (string.IsNullOrEmpty(__tmp33Prefix) && string.IsNullOrEmpty(__tmp34Suffix)) break;
                                else __tmp36Line = "";
                            }
                            __out.Append(__tmp36Line);
                        }
                    }
                    string __tmp37Line = "ImplementationProvider.Implementation."; //792:36
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
                                if (string.IsNullOrEmpty(__tmp33Prefix) && string.IsNullOrEmpty(__tmp34Suffix)) break;
                                else __tmp38Line = "";
                            }
                            __out.Append(__tmp38Line);
                        }
                    }
                    string __tmp39Line = "_"; //792:98
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
                                if (string.IsNullOrEmpty(__tmp33Prefix) && string.IsNullOrEmpty(__tmp34Suffix)) break;
                                else __tmp40Line = "";
                            }
                            __out.Append(__tmp40Line);
                        }
                    }
                    string __tmp41Line = "("; //792:108
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
                                if (string.IsNullOrEmpty(__tmp33Prefix) && string.IsNullOrEmpty(__tmp34Suffix)) break;
                                else __tmp42Line = "";
                            }
                            __out.Append(__tmp42Line);
                            __out.Append(__tmp34Suffix);
                            __out.AppendLine(); //792:146
                        }
                    }
                    __out.Append("    }"); //793:1
                    __out.AppendLine(); //793:6
                }
                __out.Append("}"); //795:1
                __out.AppendLine(); //795:2
            }
            __out.AppendLine(); //797:1
            __out.Append("/// <summary>"); //798:1
            __out.AppendLine(); //798:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //799:1
            __out.AppendLine(); //799:68
            string __tmp43Prefix = "/// This class has to be be overriden in "; //800:1
            string __tmp44Suffix = "Implementation to provide custom"; //800:54
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
                        if (string.IsNullOrEmpty(__tmp43Prefix) && string.IsNullOrEmpty(__tmp44Suffix)) break;
                        else __tmp45Line = "";
                    }
                    __out.Append(__tmp43Prefix);
                    __out.Append(__tmp45Line);
                    __out.Append(__tmp44Suffix);
                    __out.AppendLine(); //800:86
                }
            }
            __out.Append("/// implementation for the constructors, operations and property values."); //801:1
            __out.AppendLine(); //801:73
            __out.Append("/// </summary>"); //802:1
            __out.AppendLine(); //802:15
            string __tmp46Prefix = "internal abstract class "; //803:1
            string __tmp47Suffix = "ImplementationBase"; //803:37
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
                        if (string.IsNullOrEmpty(__tmp46Prefix) && string.IsNullOrEmpty(__tmp47Suffix)) break;
                        else __tmp48Line = "";
                    }
                    __out.Append(__tmp46Prefix);
                    __out.Append(__tmp48Line);
                    __out.Append(__tmp47Suffix);
                    __out.AppendLine(); //803:55
                }
            }
            __out.Append("{"); //804:1
            __out.AppendLine(); //804:2
            var __loop45_results = 
                (from __loop45_var1 in __Enumerate((model).GetEnumerator()) //805:8
                from Namespace in __Enumerate((__loop45_var1.Namespace).GetEnumerator()) //805:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //805:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //805:40
                select new { __loop45_var1 = __loop45_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //805:3
            int __loop45_iteration = 0;
            foreach (var __tmp49 in __loop45_results)
            {
                ++__loop45_iteration;
                var __loop45_var1 = __tmp49.__loop45_var1;
                var Namespace = __tmp49.Namespace;
                var Declarations = __tmp49.Declarations;
                var cls = __tmp49.cls;
                __out.Append("    /// <summary>"); //806:1
                __out.AppendLine(); //806:18
                string __tmp50Prefix = "	/// Implements the constructor: "; //807:1
                string __tmp51Suffix = "()"; //807:52
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
                            if (string.IsNullOrEmpty(__tmp50Prefix) && string.IsNullOrEmpty(__tmp51Suffix)) break;
                            else __tmp52Line = "";
                        }
                        __out.Append(__tmp50Prefix);
                        __out.Append(__tmp52Line);
                        __out.Append(__tmp51Suffix);
                        __out.AppendLine(); //807:54
                    }
                }
                if ((from __loop46_var1 in __Enumerate((cls).GetEnumerator()) //808:15
                from sup in __Enumerate((__loop46_var1.SuperClasses).GetEnumerator()) //808:20
                select new { __loop46_var1 = __loop46_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //808:3
                {
                    string __tmp53Prefix = "	/// Direct superclasses: "; //809:1
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
                                if (string.IsNullOrEmpty(__tmp53Prefix) && string.IsNullOrEmpty(__tmp54Suffix)) break;
                                else __tmp55Line = "";
                            }
                            __out.Append(__tmp53Prefix);
                            __out.Append(__tmp55Line);
                            __out.Append(__tmp54Suffix);
                            __out.AppendLine(); //809:49
                        }
                    }
                    string __tmp56Prefix = "	/// All superclasses: "; //810:1
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
                                if (string.IsNullOrEmpty(__tmp56Prefix) && string.IsNullOrEmpty(__tmp57Suffix)) break;
                                else __tmp58Line = "";
                            }
                            __out.Append(__tmp56Prefix);
                            __out.Append(__tmp58Line);
                            __out.Append(__tmp57Suffix);
                            __out.AppendLine(); //810:49
                        }
                    }
                }
                if ((from __loop47_var1 in __Enumerate((cls).GetEnumerator()) //812:15
                from prop in __Enumerate((__loop47_var1.GetAllProperties()).GetEnumerator()) //812:20
                where prop.Kind == MetaPropertyKind.Readonly //812:44
                select new { __loop47_var1 = __loop47_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //812:3
                {
                    __out.Append("    /// Initializes the following readonly properties:"); //813:1
                    __out.AppendLine(); //813:55
                }
                var __loop48_results = 
                    (from __loop48_var1 in __Enumerate((cls).GetEnumerator()) //815:11
                    from prop in __Enumerate((__loop48_var1.GetAllProperties()).GetEnumerator()) //815:16
                    select new { __loop48_var1 = __loop48_var1, prop = prop}
                    ).ToList(); //815:6
                int __loop48_iteration = 0;
                foreach (var __tmp59 in __loop48_results)
                {
                    ++__loop48_iteration;
                    var __loop48_var1 = __tmp59.__loop48_var1;
                    var prop = __tmp59.prop;
                    if (prop.Kind == MetaPropertyKind.Readonly) //816:3
                    {
                        string __tmp60Prefix = "    ///    "; //817:1
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
                                    if (string.IsNullOrEmpty(__tmp60Prefix) && string.IsNullOrEmpty(__tmp61Suffix)) break;
                                    else __tmp62Line = "";
                                }
                                __out.Append(__tmp60Prefix);
                                __out.Append(__tmp62Line);
                            }
                        }
                        string __tmp63Line = "."; //817:29
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
                                    if (string.IsNullOrEmpty(__tmp60Prefix) && string.IsNullOrEmpty(__tmp61Suffix)) break;
                                    else __tmp64Line = "";
                                }
                                __out.Append(__tmp64Line);
                                __out.Append(__tmp61Suffix);
                                __out.AppendLine(); //817:41
                            }
                        }
                    }
                }
                __out.Append("    /// </summary>"); //820:1
                __out.AppendLine(); //820:19
                string __tmp65Prefix = "    public virtual void "; //821:1
                string __tmp66Suffix = " @this)"; //821:62
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
                            if (string.IsNullOrEmpty(__tmp65Prefix) && string.IsNullOrEmpty(__tmp66Suffix)) break;
                            else __tmp67Line = "";
                        }
                        __out.Append(__tmp65Prefix);
                        __out.Append(__tmp67Line);
                    }
                }
                string __tmp68Line = "("; //821:43
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
                            if (string.IsNullOrEmpty(__tmp65Prefix) && string.IsNullOrEmpty(__tmp66Suffix)) break;
                            else __tmp69Line = "";
                        }
                        __out.Append(__tmp69Line);
                        __out.Append(__tmp66Suffix);
                        __out.AppendLine(); //821:69
                    }
                }
                __out.Append("    {"); //822:1
                __out.AppendLine(); //822:6
                var __loop49_results = 
                    (from __loop49_var1 in __Enumerate((cls).GetEnumerator()) //823:9
                    from sup in __Enumerate((__loop49_var1.SuperClasses).GetEnumerator()) //823:14
                    select new { __loop49_var1 = __loop49_var1, sup = sup}
                    ).ToList(); //823:4
                int __loop49_iteration = 0;
                foreach (var __tmp70 in __loop49_results)
                {
                    ++__loop49_iteration;
                    var __loop49_var1 = __tmp70.__loop49_var1;
                    var sup = __tmp70.sup;
                    string __tmp71Prefix = "        this."; //824:1
                    string __tmp72Suffix = "(@this);"; //824:32
                    StringBuilder __tmp73 = new StringBuilder();
                    __tmp73.Append(sup.CSharpName());
                    using(StreamReader __tmp73Reader = new StreamReader(this.__ToStream(__tmp73.ToString())))
                    {
                        bool __tmp73_first = true;
                        while(__tmp73_first || !__tmp73Reader.EndOfStream)
                        {
                            __tmp73_first = false;
                            string __tmp73Line = __tmp73Reader.ReadLine();
                            if (__tmp73Line == null)
                            {
                                if (string.IsNullOrEmpty(__tmp71Prefix) && string.IsNullOrEmpty(__tmp72Suffix)) break;
                                else __tmp73Line = "";
                            }
                            __out.Append(__tmp71Prefix);
                            __out.Append(__tmp73Line);
                            __out.Append(__tmp72Suffix);
                            __out.AppendLine(); //824:40
                        }
                    }
                }
                __out.Append("    }"); //826:1
                __out.AppendLine(); //826:6
                var __loop50_results = 
                    (from __loop50_var1 in __Enumerate((cls).GetEnumerator()) //827:11
                    from prop in __Enumerate((__loop50_var1.Properties).GetEnumerator()) //827:16
                    select new { __loop50_var1 = __loop50_var1, prop = prop}
                    ).ToList(); //827:6
                int __loop50_iteration = 0;
                foreach (var __tmp74 in __loop50_results)
                {
                    ++__loop50_iteration;
                    var __loop50_var1 = __tmp74.__loop50_var1;
                    var prop = __tmp74.prop;
                    MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //828:4
                    if (synInit == null) //829:4
                    {
                        if (prop.Kind == MetaPropertyKind.Derived) //830:5
                        {
                            __out.AppendLine(); //831:1
                            __out.Append("    /// <summary>"); //832:1
                            __out.AppendLine(); //832:18
                            string __tmp75Prefix = "    /// Returns the value of the derived property: "; //833:1
                            string __tmp76Suffix = string.Empty; 
                            StringBuilder __tmp77 = new StringBuilder();
                            __tmp77.Append(cls.CSharpName());
                            using(StreamReader __tmp77Reader = new StreamReader(this.__ToStream(__tmp77.ToString())))
                            {
                                bool __tmp77_first = true;
                                while(__tmp77_first || !__tmp77Reader.EndOfStream)
                                {
                                    __tmp77_first = false;
                                    string __tmp77Line = __tmp77Reader.ReadLine();
                                    if (__tmp77Line == null)
                                    {
                                        if (string.IsNullOrEmpty(__tmp75Prefix) && string.IsNullOrEmpty(__tmp76Suffix)) break;
                                        else __tmp77Line = "";
                                    }
                                    __out.Append(__tmp75Prefix);
                                    __out.Append(__tmp77Line);
                                }
                            }
                            string __tmp78Line = "."; //833:70
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
                                        if (string.IsNullOrEmpty(__tmp75Prefix) && string.IsNullOrEmpty(__tmp76Suffix)) break;
                                        else __tmp79Line = "";
                                    }
                                    __out.Append(__tmp79Line);
                                    __out.Append(__tmp76Suffix);
                                    __out.AppendLine(); //833:82
                                }
                            }
                            __out.Append("    /// </summary>"); //834:1
                            __out.AppendLine(); //834:19
                            string __tmp80Prefix = "    public virtual "; //835:1
                            string __tmp81Suffix = " @this)"; //835:104
                            StringBuilder __tmp82 = new StringBuilder();
                            __tmp82.Append(prop.Type.CSharpFullPublicName());
                            using(StreamReader __tmp82Reader = new StreamReader(this.__ToStream(__tmp82.ToString())))
                            {
                                bool __tmp82_first = true;
                                while(__tmp82_first || !__tmp82Reader.EndOfStream)
                                {
                                    __tmp82_first = false;
                                    string __tmp82Line = __tmp82Reader.ReadLine();
                                    if (__tmp82Line == null)
                                    {
                                        if (string.IsNullOrEmpty(__tmp80Prefix) && string.IsNullOrEmpty(__tmp81Suffix)) break;
                                        else __tmp82Line = "";
                                    }
                                    __out.Append(__tmp80Prefix);
                                    __out.Append(__tmp82Line);
                                }
                            }
                            string __tmp83Line = " "; //835:54
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
                                        if (string.IsNullOrEmpty(__tmp80Prefix) && string.IsNullOrEmpty(__tmp81Suffix)) break;
                                        else __tmp84Line = "";
                                    }
                                    __out.Append(__tmp84Line);
                                }
                            }
                            string __tmp85Line = "_"; //835:73
                            __out.Append(__tmp85Line);
                            StringBuilder __tmp86 = new StringBuilder();
                            __tmp86.Append(prop.Name);
                            using(StreamReader __tmp86Reader = new StreamReader(this.__ToStream(__tmp86.ToString())))
                            {
                                bool __tmp86_first = true;
                                while(__tmp86_first || !__tmp86Reader.EndOfStream)
                                {
                                    __tmp86_first = false;
                                    string __tmp86Line = __tmp86Reader.ReadLine();
                                    if (__tmp86Line == null)
                                    {
                                        if (string.IsNullOrEmpty(__tmp80Prefix) && string.IsNullOrEmpty(__tmp81Suffix)) break;
                                        else __tmp86Line = "";
                                    }
                                    __out.Append(__tmp86Line);
                                }
                            }
                            string __tmp87Line = "("; //835:85
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
                                        if (string.IsNullOrEmpty(__tmp80Prefix) && string.IsNullOrEmpty(__tmp81Suffix)) break;
                                        else __tmp88Line = "";
                                    }
                                    __out.Append(__tmp88Line);
                                    __out.Append(__tmp81Suffix);
                                    __out.AppendLine(); //835:111
                                }
                            }
                            __out.Append("    {"); //836:1
                            __out.AppendLine(); //836:6
                            __out.Append("        throw new NotImplementedException();"); //837:1
                            __out.AppendLine(); //837:45
                            __out.Append("    }"); //838:1
                            __out.AppendLine(); //838:6
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //839:5
                        {
                            __out.AppendLine(); //840:1
                            __out.Append("    /// <summary>"); //841:1
                            __out.AppendLine(); //841:18
                            string __tmp89Prefix = "    /// Returns the value of the lazy property: "; //842:1
                            string __tmp90Suffix = string.Empty; 
                            StringBuilder __tmp91 = new StringBuilder();
                            __tmp91.Append(cls.CSharpName());
                            using(StreamReader __tmp91Reader = new StreamReader(this.__ToStream(__tmp91.ToString())))
                            {
                                bool __tmp91_first = true;
                                while(__tmp91_first || !__tmp91Reader.EndOfStream)
                                {
                                    __tmp91_first = false;
                                    string __tmp91Line = __tmp91Reader.ReadLine();
                                    if (__tmp91Line == null)
                                    {
                                        if (string.IsNullOrEmpty(__tmp89Prefix) && string.IsNullOrEmpty(__tmp90Suffix)) break;
                                        else __tmp91Line = "";
                                    }
                                    __out.Append(__tmp89Prefix);
                                    __out.Append(__tmp91Line);
                                }
                            }
                            string __tmp92Line = "."; //842:67
                            __out.Append(__tmp92Line);
                            StringBuilder __tmp93 = new StringBuilder();
                            __tmp93.Append(prop.Name);
                            using(StreamReader __tmp93Reader = new StreamReader(this.__ToStream(__tmp93.ToString())))
                            {
                                bool __tmp93_first = true;
                                while(__tmp93_first || !__tmp93Reader.EndOfStream)
                                {
                                    __tmp93_first = false;
                                    string __tmp93Line = __tmp93Reader.ReadLine();
                                    if (__tmp93Line == null)
                                    {
                                        if (string.IsNullOrEmpty(__tmp89Prefix) && string.IsNullOrEmpty(__tmp90Suffix)) break;
                                        else __tmp93Line = "";
                                    }
                                    __out.Append(__tmp93Line);
                                    __out.Append(__tmp90Suffix);
                                    __out.AppendLine(); //842:79
                                }
                            }
                            __out.Append("    /// </summary>"); //843:1
                            __out.AppendLine(); //843:19
                            string __tmp94Prefix = "    public virtual "; //844:1
                            string __tmp95Suffix = " @this)"; //844:104
                            StringBuilder __tmp96 = new StringBuilder();
                            __tmp96.Append(prop.Type.CSharpFullPublicName());
                            using(StreamReader __tmp96Reader = new StreamReader(this.__ToStream(__tmp96.ToString())))
                            {
                                bool __tmp96_first = true;
                                while(__tmp96_first || !__tmp96Reader.EndOfStream)
                                {
                                    __tmp96_first = false;
                                    string __tmp96Line = __tmp96Reader.ReadLine();
                                    if (__tmp96Line == null)
                                    {
                                        if (string.IsNullOrEmpty(__tmp94Prefix) && string.IsNullOrEmpty(__tmp95Suffix)) break;
                                        else __tmp96Line = "";
                                    }
                                    __out.Append(__tmp94Prefix);
                                    __out.Append(__tmp96Line);
                                }
                            }
                            string __tmp97Line = " "; //844:54
                            __out.Append(__tmp97Line);
                            StringBuilder __tmp98 = new StringBuilder();
                            __tmp98.Append(cls.CSharpName());
                            using(StreamReader __tmp98Reader = new StreamReader(this.__ToStream(__tmp98.ToString())))
                            {
                                bool __tmp98_first = true;
                                while(__tmp98_first || !__tmp98Reader.EndOfStream)
                                {
                                    __tmp98_first = false;
                                    string __tmp98Line = __tmp98Reader.ReadLine();
                                    if (__tmp98Line == null)
                                    {
                                        if (string.IsNullOrEmpty(__tmp94Prefix) && string.IsNullOrEmpty(__tmp95Suffix)) break;
                                        else __tmp98Line = "";
                                    }
                                    __out.Append(__tmp98Line);
                                }
                            }
                            string __tmp99Line = "_"; //844:73
                            __out.Append(__tmp99Line);
                            StringBuilder __tmp100 = new StringBuilder();
                            __tmp100.Append(prop.Name);
                            using(StreamReader __tmp100Reader = new StreamReader(this.__ToStream(__tmp100.ToString())))
                            {
                                bool __tmp100_first = true;
                                while(__tmp100_first || !__tmp100Reader.EndOfStream)
                                {
                                    __tmp100_first = false;
                                    string __tmp100Line = __tmp100Reader.ReadLine();
                                    if (__tmp100Line == null)
                                    {
                                        if (string.IsNullOrEmpty(__tmp94Prefix) && string.IsNullOrEmpty(__tmp95Suffix)) break;
                                        else __tmp100Line = "";
                                    }
                                    __out.Append(__tmp100Line);
                                }
                            }
                            string __tmp101Line = "("; //844:85
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
                                        if (string.IsNullOrEmpty(__tmp94Prefix) && string.IsNullOrEmpty(__tmp95Suffix)) break;
                                        else __tmp102Line = "";
                                    }
                                    __out.Append(__tmp102Line);
                                    __out.Append(__tmp95Suffix);
                                    __out.AppendLine(); //844:111
                                }
                            }
                            __out.Append("    {"); //845:1
                            __out.AppendLine(); //845:6
                            __out.Append("        throw new NotImplementedException();"); //846:1
                            __out.AppendLine(); //846:45
                            __out.Append("    }"); //847:1
                            __out.AppendLine(); //847:6
                        }
                    }
                }
                var __loop51_results = 
                    (from __loop51_var1 in __Enumerate((cls).GetEnumerator()) //851:11
                    from op in __Enumerate((__loop51_var1.Operations).GetEnumerator()) //851:16
                    select new { __loop51_var1 = __loop51_var1, op = op}
                    ).ToList(); //851:6
                int __loop51_iteration = 0;
                foreach (var __tmp103 in __loop51_results)
                {
                    ++__loop51_iteration;
                    var __loop51_var1 = __tmp103.__loop51_var1;
                    var op = __tmp103.op;
                    __out.AppendLine(); //852:1
                    __out.Append("    /// <summary>"); //853:1
                    __out.AppendLine(); //853:18
                    string __tmp104Prefix = "    /// Implements the operation: "; //854:1
                    string __tmp105Suffix = "()"; //854:63
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
                                if (string.IsNullOrEmpty(__tmp104Prefix) && string.IsNullOrEmpty(__tmp105Suffix)) break;
                                else __tmp106Line = "";
                            }
                            __out.Append(__tmp104Prefix);
                            __out.Append(__tmp106Line);
                        }
                    }
                    string __tmp107Line = "."; //854:53
                    __out.Append(__tmp107Line);
                    StringBuilder __tmp108 = new StringBuilder();
                    __tmp108.Append(op.Name);
                    using(StreamReader __tmp108Reader = new StreamReader(this.__ToStream(__tmp108.ToString())))
                    {
                        bool __tmp108_first = true;
                        while(__tmp108_first || !__tmp108Reader.EndOfStream)
                        {
                            __tmp108_first = false;
                            string __tmp108Line = __tmp108Reader.ReadLine();
                            if (__tmp108Line == null)
                            {
                                if (string.IsNullOrEmpty(__tmp104Prefix) && string.IsNullOrEmpty(__tmp105Suffix)) break;
                                else __tmp108Line = "";
                            }
                            __out.Append(__tmp108Line);
                            __out.Append(__tmp105Suffix);
                            __out.AppendLine(); //854:65
                        }
                    }
                    __out.Append("    /// </summary>"); //855:1
                    __out.AppendLine(); //855:19
                    string __tmp109Prefix = "    public virtual "; //856:1
                    string __tmp110Suffix = ")"; //856:116
                    StringBuilder __tmp111 = new StringBuilder();
                    __tmp111.Append(op.ReturnType.CSharpFullPublicName());
                    using(StreamReader __tmp111Reader = new StreamReader(this.__ToStream(__tmp111.ToString())))
                    {
                        bool __tmp111_first = true;
                        while(__tmp111_first || !__tmp111Reader.EndOfStream)
                        {
                            __tmp111_first = false;
                            string __tmp111Line = __tmp111Reader.ReadLine();
                            if (__tmp111Line == null)
                            {
                                if (string.IsNullOrEmpty(__tmp109Prefix) && string.IsNullOrEmpty(__tmp110Suffix)) break;
                                else __tmp111Line = "";
                            }
                            __out.Append(__tmp109Prefix);
                            __out.Append(__tmp111Line);
                        }
                    }
                    string __tmp112Line = " "; //856:58
                    __out.Append(__tmp112Line);
                    StringBuilder __tmp113 = new StringBuilder();
                    __tmp113.Append(cls.CSharpName());
                    using(StreamReader __tmp113Reader = new StreamReader(this.__ToStream(__tmp113.ToString())))
                    {
                        bool __tmp113_first = true;
                        while(__tmp113_first || !__tmp113Reader.EndOfStream)
                        {
                            __tmp113_first = false;
                            string __tmp113Line = __tmp113Reader.ReadLine();
                            if (__tmp113Line == null)
                            {
                                if (string.IsNullOrEmpty(__tmp109Prefix) && string.IsNullOrEmpty(__tmp110Suffix)) break;
                                else __tmp113Line = "";
                            }
                            __out.Append(__tmp113Line);
                        }
                    }
                    string __tmp114Line = "_"; //856:77
                    __out.Append(__tmp114Line);
                    StringBuilder __tmp115 = new StringBuilder();
                    __tmp115.Append(op.Name);
                    using(StreamReader __tmp115Reader = new StreamReader(this.__ToStream(__tmp115.ToString())))
                    {
                        bool __tmp115_first = true;
                        while(__tmp115_first || !__tmp115Reader.EndOfStream)
                        {
                            __tmp115_first = false;
                            string __tmp115Line = __tmp115Reader.ReadLine();
                            if (__tmp115Line == null)
                            {
                                if (string.IsNullOrEmpty(__tmp109Prefix) && string.IsNullOrEmpty(__tmp110Suffix)) break;
                                else __tmp115Line = "";
                            }
                            __out.Append(__tmp115Line);
                        }
                    }
                    string __tmp116Line = "("; //856:87
                    __out.Append(__tmp116Line);
                    StringBuilder __tmp117 = new StringBuilder();
                    __tmp117.Append(GetImplParameters(cls, op));
                    using(StreamReader __tmp117Reader = new StreamReader(this.__ToStream(__tmp117.ToString())))
                    {
                        bool __tmp117_first = true;
                        while(__tmp117_first || !__tmp117Reader.EndOfStream)
                        {
                            __tmp117_first = false;
                            string __tmp117Line = __tmp117Reader.ReadLine();
                            if (__tmp117Line == null)
                            {
                                if (string.IsNullOrEmpty(__tmp109Prefix) && string.IsNullOrEmpty(__tmp110Suffix)) break;
                                else __tmp117Line = "";
                            }
                            __out.Append(__tmp117Line);
                            __out.Append(__tmp110Suffix);
                            __out.AppendLine(); //856:117
                        }
                    }
                    __out.Append("    {"); //857:1
                    __out.AppendLine(); //857:6
                    __out.Append("        throw new NotImplementedException();"); //858:1
                    __out.AppendLine(); //858:45
                    __out.Append("    }"); //859:1
                    __out.AppendLine(); //859:6
                }
                __out.AppendLine(); //861:1
            }
            var __loop52_results = 
                (from __loop52_var1 in __Enumerate((model).GetEnumerator()) //863:8
                from Namespace in __Enumerate((__loop52_var1.Namespace).GetEnumerator()) //863:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //863:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //863:40
                select new { __loop52_var1 = __loop52_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //863:3
            int __loop52_iteration = 0;
            foreach (var __tmp118 in __loop52_results)
            {
                ++__loop52_iteration;
                var __loop52_var1 = __tmp118.__loop52_var1;
                var Namespace = __tmp118.Namespace;
                var Declarations = __tmp118.Declarations;
                var enm = __tmp118.enm;
                var __loop53_results = 
                    (from __loop53_var1 in __Enumerate((enm).GetEnumerator()) //864:11
                    from op in __Enumerate((__loop53_var1.Operations).GetEnumerator()) //864:16
                    select new { __loop53_var1 = __loop53_var1, op = op}
                    ).ToList(); //864:6
                int __loop53_iteration = 0;
                foreach (var __tmp119 in __loop53_results)
                {
                    ++__loop53_iteration;
                    var __loop53_var1 = __tmp119.__loop53_var1;
                    var op = __tmp119.op;
                    __out.AppendLine(); //865:1
                    __out.Append("    /// <summary>"); //866:1
                    __out.AppendLine(); //866:18
                    string __tmp120Prefix = "    /// Implements the operation: "; //867:1
                    string __tmp121Suffix = string.Empty; 
                    StringBuilder __tmp122 = new StringBuilder();
                    __tmp122.Append(enm.CSharpName());
                    using(StreamReader __tmp122Reader = new StreamReader(this.__ToStream(__tmp122.ToString())))
                    {
                        bool __tmp122_first = true;
                        while(__tmp122_first || !__tmp122Reader.EndOfStream)
                        {
                            __tmp122_first = false;
                            string __tmp122Line = __tmp122Reader.ReadLine();
                            if (__tmp122Line == null)
                            {
                                if (string.IsNullOrEmpty(__tmp120Prefix) && string.IsNullOrEmpty(__tmp121Suffix)) break;
                                else __tmp122Line = "";
                            }
                            __out.Append(__tmp120Prefix);
                            __out.Append(__tmp122Line);
                        }
                    }
                    string __tmp123Line = "."; //867:53
                    __out.Append(__tmp123Line);
                    StringBuilder __tmp124 = new StringBuilder();
                    __tmp124.Append(op.Name);
                    using(StreamReader __tmp124Reader = new StreamReader(this.__ToStream(__tmp124.ToString())))
                    {
                        bool __tmp124_first = true;
                        while(__tmp124_first || !__tmp124Reader.EndOfStream)
                        {
                            __tmp124_first = false;
                            string __tmp124Line = __tmp124Reader.ReadLine();
                            if (__tmp124Line == null)
                            {
                                if (string.IsNullOrEmpty(__tmp120Prefix) && string.IsNullOrEmpty(__tmp121Suffix)) break;
                                else __tmp124Line = "";
                            }
                            __out.Append(__tmp124Line);
                            __out.Append(__tmp121Suffix);
                            __out.AppendLine(); //867:63
                        }
                    }
                    __out.Append("    /// </summary>"); //868:1
                    __out.AppendLine(); //868:19
                    string __tmp125Prefix = "    public virtual "; //869:1
                    string __tmp126Suffix = ")"; //869:116
                    StringBuilder __tmp127 = new StringBuilder();
                    __tmp127.Append(op.ReturnType.CSharpFullPublicName());
                    using(StreamReader __tmp127Reader = new StreamReader(this.__ToStream(__tmp127.ToString())))
                    {
                        bool __tmp127_first = true;
                        while(__tmp127_first || !__tmp127Reader.EndOfStream)
                        {
                            __tmp127_first = false;
                            string __tmp127Line = __tmp127Reader.ReadLine();
                            if (__tmp127Line == null)
                            {
                                if (string.IsNullOrEmpty(__tmp125Prefix) && string.IsNullOrEmpty(__tmp126Suffix)) break;
                                else __tmp127Line = "";
                            }
                            __out.Append(__tmp125Prefix);
                            __out.Append(__tmp127Line);
                        }
                    }
                    string __tmp128Line = " "; //869:58
                    __out.Append(__tmp128Line);
                    StringBuilder __tmp129 = new StringBuilder();
                    __tmp129.Append(enm.CSharpName());
                    using(StreamReader __tmp129Reader = new StreamReader(this.__ToStream(__tmp129.ToString())))
                    {
                        bool __tmp129_first = true;
                        while(__tmp129_first || !__tmp129Reader.EndOfStream)
                        {
                            __tmp129_first = false;
                            string __tmp129Line = __tmp129Reader.ReadLine();
                            if (__tmp129Line == null)
                            {
                                if (string.IsNullOrEmpty(__tmp125Prefix) && string.IsNullOrEmpty(__tmp126Suffix)) break;
                                else __tmp129Line = "";
                            }
                            __out.Append(__tmp129Line);
                        }
                    }
                    string __tmp130Line = "_"; //869:77
                    __out.Append(__tmp130Line);
                    StringBuilder __tmp131 = new StringBuilder();
                    __tmp131.Append(op.Name);
                    using(StreamReader __tmp131Reader = new StreamReader(this.__ToStream(__tmp131.ToString())))
                    {
                        bool __tmp131_first = true;
                        while(__tmp131_first || !__tmp131Reader.EndOfStream)
                        {
                            __tmp131_first = false;
                            string __tmp131Line = __tmp131Reader.ReadLine();
                            if (__tmp131Line == null)
                            {
                                if (string.IsNullOrEmpty(__tmp125Prefix) && string.IsNullOrEmpty(__tmp126Suffix)) break;
                                else __tmp131Line = "";
                            }
                            __out.Append(__tmp131Line);
                        }
                    }
                    string __tmp132Line = "("; //869:87
                    __out.Append(__tmp132Line);
                    StringBuilder __tmp133 = new StringBuilder();
                    __tmp133.Append(GetImplParameters(enm, op));
                    using(StreamReader __tmp133Reader = new StreamReader(this.__ToStream(__tmp133.ToString())))
                    {
                        bool __tmp133_first = true;
                        while(__tmp133_first || !__tmp133Reader.EndOfStream)
                        {
                            __tmp133_first = false;
                            string __tmp133Line = __tmp133Reader.ReadLine();
                            if (__tmp133Line == null)
                            {
                                if (string.IsNullOrEmpty(__tmp125Prefix) && string.IsNullOrEmpty(__tmp126Suffix)) break;
                                else __tmp133Line = "";
                            }
                            __out.Append(__tmp133Line);
                            __out.Append(__tmp126Suffix);
                            __out.AppendLine(); //869:117
                        }
                    }
                    __out.Append("    {"); //870:1
                    __out.AppendLine(); //870:6
                    __out.Append("        throw new NotImplementedException();"); //871:1
                    __out.AppendLine(); //871:45
                    __out.Append("    }"); //872:1
                    __out.AppendLine(); //872:6
                }
                __out.AppendLine(); //874:1
            }
            __out.Append("}"); //876:1
            __out.AppendLine(); //876:2
            __out.AppendLine(); //877:1
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //880:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //881:1
            __out.AppendLine(); //881:14
            __out.Append("/// Factory class for creating instances of model elements."); //882:1
            __out.AppendLine(); //882:60
            __out.Append("/// </summary>"); //883:1
            __out.AppendLine(); //883:15
            string __tmp1Prefix = "public class "; //884:1
            string __tmp2Suffix = " : ModelFactory"; //884:41
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
                        if (string.IsNullOrEmpty(__tmp1Prefix) && string.IsNullOrEmpty(__tmp2Suffix)) break;
                        else __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //884:56
                }
            }
            __out.Append("{"); //885:1
            __out.AppendLine(); //885:2
            string __tmp4Prefix = "    private static "; //886:1
            string __tmp5Suffix = "();"; //886:90
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
                        if (string.IsNullOrEmpty(__tmp4Prefix) && string.IsNullOrEmpty(__tmp5Suffix)) break;
                        else __tmp6Line = "";
                    }
                    __out.Append(__tmp4Prefix);
                    __out.Append(__tmp6Line);
                }
            }
            string __tmp7Line = " instance = new "; //886:47
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
                        if (string.IsNullOrEmpty(__tmp4Prefix) && string.IsNullOrEmpty(__tmp5Suffix)) break;
                        else __tmp8Line = "";
                    }
                    __out.Append(__tmp8Line);
                    __out.Append(__tmp5Suffix);
                    __out.AppendLine(); //886:93
                }
            }
            __out.AppendLine(); //887:1
            string __tmp9Prefix = "	private "; //888:1
            string __tmp10Suffix = "()"; //888:37
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
                        if (string.IsNullOrEmpty(__tmp9Prefix) && string.IsNullOrEmpty(__tmp10Suffix)) break;
                        else __tmp11Line = "";
                    }
                    __out.Append(__tmp9Prefix);
                    __out.Append(__tmp11Line);
                    __out.Append(__tmp10Suffix);
                    __out.AppendLine(); //888:39
                }
            }
            __out.Append("	{"); //889:1
            __out.AppendLine(); //889:3
            __out.Append("	}"); //890:1
            __out.AppendLine(); //890:3
            __out.AppendLine(); //891:1
            __out.Append("    /// <summary>"); //892:1
            __out.AppendLine(); //892:18
            __out.Append("    /// The singleton instance of the factory."); //893:1
            __out.AppendLine(); //893:47
            __out.Append("    /// </summary>"); //894:1
            __out.AppendLine(); //894:19
            string __tmp12Prefix = "    public static "; //895:1
            string __tmp13Suffix = " Instance"; //895:46
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
                        if (string.IsNullOrEmpty(__tmp12Prefix) && string.IsNullOrEmpty(__tmp13Suffix)) break;
                        else __tmp14Line = "";
                    }
                    __out.Append(__tmp12Prefix);
                    __out.Append(__tmp14Line);
                    __out.Append(__tmp13Suffix);
                    __out.AppendLine(); //895:55
                }
            }
            __out.Append("    {"); //896:1
            __out.AppendLine(); //896:6
            string __tmp15Prefix = "        get { return "; //897:1
            string __tmp16Suffix = ".instance; }"; //897:49
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
                        if (string.IsNullOrEmpty(__tmp15Prefix) && string.IsNullOrEmpty(__tmp16Suffix)) break;
                        else __tmp17Line = "";
                    }
                    __out.Append(__tmp15Prefix);
                    __out.Append(__tmp17Line);
                    __out.Append(__tmp16Suffix);
                    __out.AppendLine(); //897:61
                }
            }
            __out.Append("    }"); //898:1
            __out.AppendLine(); //898:6
            var __loop54_results = 
                (from __loop54_var1 in __Enumerate((model).GetEnumerator()) //899:8
                from Namespace in __Enumerate((__loop54_var1.Namespace).GetEnumerator()) //899:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //899:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //899:40
                select new { __loop54_var1 = __loop54_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //899:3
            int __loop54_iteration = 0;
            foreach (var __tmp18 in __loop54_results)
            {
                ++__loop54_iteration;
                var __loop54_var1 = __tmp18.__loop54_var1;
                var Namespace = __tmp18.Namespace;
                var Declarations = __tmp18.Declarations;
                var cls = __tmp18.cls;
                if (!cls.IsAbstract) //900:4
                {
                    __out.AppendLine(); //901:1
                    __out.Append("    /// <summary>"); //902:1
                    __out.AppendLine(); //902:18
                    string __tmp19Prefix = "    /// Creates a new instance of "; //903:1
                    string __tmp20Suffix = "."; //903:53
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
                                if (string.IsNullOrEmpty(__tmp19Prefix) && string.IsNullOrEmpty(__tmp20Suffix)) break;
                                else __tmp21Line = "";
                            }
                            __out.Append(__tmp19Prefix);
                            __out.Append(__tmp21Line);
                            __out.Append(__tmp20Suffix);
                            __out.AppendLine(); //903:54
                        }
                    }
                    __out.Append("    /// </summary>"); //904:1
                    __out.AppendLine(); //904:19
                    string __tmp22Prefix = "    public "; //905:1
                    string __tmp23Suffix = "(IEnumerable<ModelPropertyInitializer> initializers = null)"; //905:55
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
                                if (string.IsNullOrEmpty(__tmp22Prefix) && string.IsNullOrEmpty(__tmp23Suffix)) break;
                                else __tmp24Line = "";
                            }
                            __out.Append(__tmp22Prefix);
                            __out.Append(__tmp24Line);
                        }
                    }
                    string __tmp25Line = " Create"; //905:30
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
                                if (string.IsNullOrEmpty(__tmp22Prefix) && string.IsNullOrEmpty(__tmp23Suffix)) break;
                                else __tmp26Line = "";
                            }
                            __out.Append(__tmp26Line);
                            __out.Append(__tmp23Suffix);
                            __out.AppendLine(); //905:114
                        }
                    }
                    __out.Append("	{"); //906:1
                    __out.AppendLine(); //906:3
                    string __tmp27Prefix = "		"; //907:1
                    string __tmp28Suffix = "Impl();"; //907:57
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
                                if (string.IsNullOrEmpty(__tmp27Prefix) && string.IsNullOrEmpty(__tmp28Suffix)) break;
                                else __tmp29Line = "";
                            }
                            __out.Append(__tmp27Prefix);
                            __out.Append(__tmp29Line);
                        }
                    }
                    string __tmp30Line = " result = new "; //907:21
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
                                if (string.IsNullOrEmpty(__tmp27Prefix) && string.IsNullOrEmpty(__tmp28Suffix)) break;
                                else __tmp31Line = "";
                            }
                            __out.Append(__tmp31Line);
                            __out.Append(__tmp28Suffix);
                            __out.AppendLine(); //907:64
                        }
                    }
                    __out.Append("		if (initializers != null)"); //908:1
                    __out.AppendLine(); //908:28
                    __out.Append("		{"); //909:1
                    __out.AppendLine(); //909:4
                    __out.Append("			this.Init((ModelObject)result, initializers);"); //910:1
                    __out.AppendLine(); //910:49
                    __out.Append("		}"); //911:1
                    __out.AppendLine(); //911:4
                    __out.Append("		return result;"); //912:1
                    __out.AppendLine(); //912:17
                    __out.Append("	}"); //913:1
                    __out.AppendLine(); //913:3
                }
            }
            __out.Append("}"); //916:1
            __out.AppendLine(); //916:2
            __out.AppendLine(); //917:1
            return __out.ToString();
        }

    }
}
