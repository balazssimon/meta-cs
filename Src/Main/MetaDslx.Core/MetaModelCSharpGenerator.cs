using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core //1:1
{
    using __Hidden_MetaModelCSharpGenerator_1945799187;
    namespace __Hidden_MetaModelCSharpGenerator_1945799187
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
            __out.AppendLine(false); //5:14
            __out.Append("using System.Collections.Generic;"); //6:1
            __out.AppendLine(false); //6:34
            __out.Append("using System.IO;"); //7:1
            __out.AppendLine(false); //7:17
            __out.Append("using System.Linq;"); //8:1
            __out.AppendLine(false); //8:19
            __out.Append("using System.Text;"); //9:1
            __out.AppendLine(false); //9:19
            __out.Append("using System.Threading;"); //10:1
            __out.AppendLine(false); //10:24
            __out.Append("using System.Threading.Tasks;"); //11:1
            __out.AppendLine(false); //11:30
            __out.Append("using MetaDslx.Core;"); //12:1
            __out.AppendLine(false); //12:21
            __out.AppendLine(true); //13:1
            var __loop1_results = 
                (from __loop1_var1 in __Enumerate((Instances).GetEnumerator()) //14:8
                from mm in __Enumerate((__loop1_var1).GetEnumerator()).OfType<MetaModel>() //14:19
                select new { __loop1_var1 = __loop1_var1, mm = mm}
                ).ToList(); //14:3
            for (int __loop1_iteration = 0; __loop1_iteration < __loop1_results.Count; ++__loop1_iteration)
            {
                var __tmp1 = __loop1_results[__loop1_iteration];
                var __loop1_var1 = __tmp1.__loop1_var1;
                var mm = __tmp1.mm;
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(GenerateMetamodel(mm));
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_first = true;
                    bool __tmp3_last = __tmp3Reader.EndOfStream;
                    while(__tmp3_first || !__tmp3_last)
                    {
                        __tmp3_first = false;
                        string __tmp3Line = __tmp3Reader.ReadLine();
                        __tmp3_last = __tmp3Reader.EndOfStream;
                        if (__tmp3Line != null) __out.Append(__tmp3Line);
                        if (!__tmp3_last) __out.AppendLine(true);
                        __out.AppendLine(false); //15:24
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateMetamodel(MetaModel model) //19:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "namespace "; //20:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.Namespace.CSharpName());
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(__tmp3_first || !__tmp3_last)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    if (!__tmp3_last) __out.AppendLine(true);
                    __out.AppendLine(false); //20:41
                }
            }
            __out.Append("{"); //21:1
            __out.AppendLine(false); //21:2
            string __tmp4Prefix = "    "; //22:1
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(GenerateMetaModelDescriptor(model));
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_first = true;
                bool __tmp5_last = __tmp5Reader.EndOfStream;
                while(__tmp5_first || !__tmp5_last)
                {
                    __tmp5_first = false;
                    string __tmp5Line = __tmp5Reader.ReadLine();
                    __tmp5_last = __tmp5Reader.EndOfStream;
                    __out.Append(__tmp4Prefix);
                    if (__tmp5Line != null) __out.Append(__tmp5Line);
                    if (!__tmp5_last) __out.AppendLine(true);
                    __out.AppendLine(false); //22:41
                }
            }
            string __tmp6Prefix = "	"; //23:1
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(GenerateMetaModelInstance(model));
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_first = true;
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(__tmp7_first || !__tmp7_last)
                {
                    __tmp7_first = false;
                    string __tmp7Line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    __out.Append(__tmp6Prefix);
                    if (__tmp7Line != null) __out.Append(__tmp7Line);
                    if (!__tmp7_last) __out.AppendLine(true);
                    __out.AppendLine(false); //23:36
                }
            }
            var __loop2_results = 
                (from __loop2_var1 in __Enumerate((model).GetEnumerator()) //24:8
                from Namespace in __Enumerate((__loop2_var1.Namespace).GetEnumerator()) //24:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //24:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //24:40
                select new { __loop2_var1 = __loop2_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //24:3
            for (int __loop2_iteration = 0; __loop2_iteration < __loop2_results.Count; ++__loop2_iteration)
            {
                var __tmp8 = __loop2_results[__loop2_iteration];
                var __loop2_var1 = __tmp8.__loop2_var1;
                var Namespace = __tmp8.Namespace;
                var Declarations = __tmp8.Declarations;
                var enm = __tmp8.enm;
                string __tmp9Prefix = "    "; //25:1
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(GenerateEnum(enm));
                using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
                {
                    bool __tmp10_first = true;
                    bool __tmp10_last = __tmp10Reader.EndOfStream;
                    while(__tmp10_first || !__tmp10_last)
                    {
                        __tmp10_first = false;
                        string __tmp10Line = __tmp10Reader.ReadLine();
                        __tmp10_last = __tmp10Reader.EndOfStream;
                        __out.Append(__tmp9Prefix);
                        if (__tmp10Line != null) __out.Append(__tmp10Line);
                        if (!__tmp10_last) __out.AppendLine(true);
                        __out.AppendLine(false); //25:24
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
            for (int __loop3_iteration = 0; __loop3_iteration < __loop3_results.Count; ++__loop3_iteration)
            {
                var __tmp11 = __loop3_results[__loop3_iteration];
                var __loop3_var1 = __tmp11.__loop3_var1;
                var Namespace = __tmp11.Namespace;
                var Declarations = __tmp11.Declarations;
                var cls = __tmp11.cls;
                string __tmp12Prefix = "    "; //28:1
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(GenerateInterface(cls));
                using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                {
                    bool __tmp13_first = true;
                    bool __tmp13_last = __tmp13Reader.EndOfStream;
                    while(__tmp13_first || !__tmp13_last)
                    {
                        __tmp13_first = false;
                        string __tmp13Line = __tmp13Reader.ReadLine();
                        __tmp13_last = __tmp13Reader.EndOfStream;
                        __out.Append(__tmp12Prefix);
                        if (__tmp13Line != null) __out.Append(__tmp13Line);
                        if (!__tmp13_last) __out.AppendLine(true);
                        __out.AppendLine(false); //28:29
                    }
                }
                string __tmp14Prefix = "    "; //29:1
                StringBuilder __tmp15 = new StringBuilder();
                __tmp15.Append(GenerateInterfaceImpl(model, cls));
                using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
                {
                    bool __tmp15_first = true;
                    bool __tmp15_last = __tmp15Reader.EndOfStream;
                    while(__tmp15_first || !__tmp15_last)
                    {
                        __tmp15_first = false;
                        string __tmp15Line = __tmp15Reader.ReadLine();
                        __tmp15_last = __tmp15Reader.EndOfStream;
                        __out.Append(__tmp14Prefix);
                        if (__tmp15Line != null) __out.Append(__tmp15Line);
                        if (!__tmp15_last) __out.AppendLine(true);
                        __out.AppendLine(false); //29:40
                    }
                }
            }
            string __tmp16Prefix = "    "; //31:1
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(GenerateFactory(model));
            using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
            {
                bool __tmp17_first = true;
                bool __tmp17_last = __tmp17Reader.EndOfStream;
                while(__tmp17_first || !__tmp17_last)
                {
                    __tmp17_first = false;
                    string __tmp17Line = __tmp17Reader.ReadLine();
                    __tmp17_last = __tmp17Reader.EndOfStream;
                    __out.Append(__tmp16Prefix);
                    if (__tmp17Line != null) __out.Append(__tmp17Line);
                    if (!__tmp17_last) __out.AppendLine(true);
                    __out.AppendLine(false); //31:29
                }
            }
            string __tmp18Prefix = "    "; //32:1
            StringBuilder __tmp19 = new StringBuilder();
            __tmp19.Append(GenerateImplementationProvider(model));
            using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
            {
                bool __tmp19_first = true;
                bool __tmp19_last = __tmp19Reader.EndOfStream;
                while(__tmp19_first || !__tmp19_last)
                {
                    __tmp19_first = false;
                    string __tmp19Line = __tmp19Reader.ReadLine();
                    __tmp19_last = __tmp19Reader.EndOfStream;
                    __out.Append(__tmp18Prefix);
                    if (__tmp19Line != null) __out.Append(__tmp19Line);
                    if (!__tmp19_last) __out.AppendLine(true);
                    __out.AppendLine(false); //32:44
                }
            }
            __out.Append("}"); //33:1
            __out.AppendLine(false); //33:2
            return __out.ToString();
        }

        public string GenerateDocumentation(MetaDocumentedElement elem) //36:1
        {
            StringBuilder __out = new StringBuilder();
            IList<string> lines = elem.GetDocumentationLines(); //37:2
            if (lines.Count > 0) //38:2
            {
                __out.Append("/**"); //39:1
                __out.AppendLine(false); //39:4
                __out.Append(" * <summary>"); //40:1
                __out.AppendLine(false); //40:13
                var __loop4_results = 
                    (from line in __Enumerate((lines).GetEnumerator()) //41:8
                    select new { line = line}
                    ).ToList(); //41:3
                for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
                {
                    var __tmp1 = __loop4_results[__loop4_iteration];
                    var line = __tmp1.line;
                    string __tmp3Line = " * "; //42:1
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    StringBuilder __tmp4 = new StringBuilder();
                    __tmp4.Append(line);
                    using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                    {
                        bool __tmp4_first = true;
                        bool __tmp4_last = __tmp4Reader.EndOfStream;
                        while(__tmp4_first || !__tmp4_last)
                        {
                            __tmp4_first = false;
                            string __tmp4Line = __tmp4Reader.ReadLine();
                            __tmp4_last = __tmp4Reader.EndOfStream;
                            if (__tmp4Line != null) __out.Append(__tmp4Line);
                            if (!__tmp4_last) __out.AppendLine(true);
                            __out.AppendLine(false); //42:10
                        }
                    }
                }
                __out.Append(" * </summary>"); //44:1
                __out.AppendLine(false); //44:14
                __out.Append(" */"); //45:1
                __out.AppendLine(false); //45:4
            }
            return __out.ToString();
        }

        public string GenerateAnnotations(MetaAnnotatedElement elem) //49:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop5_results = 
                (from __loop5_var1 in __Enumerate((elem).GetEnumerator()) //50:7
                from annot in __Enumerate((__loop5_var1.Annotations).GetEnumerator()) //50:13
                select new { __loop5_var1 = __loop5_var1, annot = annot}
                ).ToList(); //50:2
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                var __tmp1 = __loop5_results[__loop5_iteration];
                var __loop5_var1 = __tmp1.__loop5_var1;
                var annot = __tmp1.annot;
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append("[");
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_first = true;
                    bool __tmp3_last = __tmp3Reader.EndOfStream;
                    while(__tmp3_first || !__tmp3_last)
                    {
                        __tmp3_first = false;
                        string __tmp3Line = __tmp3Reader.ReadLine();
                        __tmp3_last = __tmp3Reader.EndOfStream;
                        if (__tmp3Line != null) __out.Append(__tmp3Line);
                        if (!__tmp3_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append(annot.Name);
                using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                {
                    bool __tmp4_first = true;
                    bool __tmp4_last = __tmp4Reader.EndOfStream;
                    while(__tmp4_first || !__tmp4_last)
                    {
                        __tmp4_first = false;
                        string __tmp4Line = __tmp4Reader.ReadLine();
                        __tmp4_last = __tmp4Reader.EndOfStream;
                        if (__tmp4Line != null) __out.Append(__tmp4Line);
                        if (!__tmp4_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append("]");
                using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                {
                    bool __tmp5_first = true;
                    bool __tmp5_last = __tmp5Reader.EndOfStream;
                    while(__tmp5_first || !__tmp5_last)
                    {
                        __tmp5_first = false;
                        string __tmp5Line = __tmp5Reader.ReadLine();
                        __tmp5_last = __tmp5Reader.EndOfStream;
                        if (__tmp5Line != null) __out.Append(__tmp5Line);
                        if (!__tmp5_last) __out.AppendLine(true);
                        __out.AppendLine(false); //51:23
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateEnum(MetaEnum enm) //55:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(GenerateDocumentation(enm));
            using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
            {
                bool __tmp2_first = true;
                bool __tmp2_last = __tmp2Reader.EndOfStream;
                while(__tmp2_first || !__tmp2_last)
                {
                    __tmp2_first = false;
                    string __tmp2Line = __tmp2Reader.ReadLine();
                    __tmp2_last = __tmp2Reader.EndOfStream;
                    if (__tmp2Line != null) __out.Append(__tmp2Line);
                    if (!__tmp2_last) __out.AppendLine(true);
                    __out.AppendLine(false); //56:29
                }
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(GenerateAnnotations(enm));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_first = true;
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(__tmp4_first || !__tmp4_last)
                {
                    __tmp4_first = false;
                    string __tmp4Line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (__tmp4Line != null) __out.Append(__tmp4Line);
                    if (!__tmp4_last) __out.AppendLine(true);
                    __out.AppendLine(false); //57:27
                }
            }
            string __tmp6Line = "public enum "; //58:1
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(enm.CSharpName());
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_first = true;
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(__tmp7_first || !__tmp7_last)
                {
                    __tmp7_first = false;
                    string __tmp7Line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    if (__tmp7Line != null) __out.Append(__tmp7Line);
                    if (!__tmp7_last) __out.AppendLine(true);
                    __out.AppendLine(false); //58:31
                }
            }
            __out.Append("{"); //59:1
            __out.AppendLine(false); //59:2
            var __loop6_results = 
                (from __loop6_var1 in __Enumerate((enm).GetEnumerator()) //60:11
                from value in __Enumerate((__loop6_var1.EnumLiterals).GetEnumerator()) //60:16
                select new { __loop6_var1 = __loop6_var1, value = value}
                ).ToList(); //60:6
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp8 = __loop6_results[__loop6_iteration];
                var __loop6_var1 = __tmp8.__loop6_var1;
                var value = __tmp8.value;
                string __tmp9Prefix = "    "; //61:1
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(value.Name);
                using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
                {
                    bool __tmp10_first = true;
                    bool __tmp10_last = __tmp10Reader.EndOfStream;
                    while(__tmp10_first || !__tmp10_last)
                    {
                        __tmp10_first = false;
                        string __tmp10Line = __tmp10Reader.ReadLine();
                        __tmp10_last = __tmp10Reader.EndOfStream;
                        __out.Append(__tmp9Prefix);
                        if (__tmp10Line != null) __out.Append(__tmp10Line);
                        if (!__tmp10_last) __out.AppendLine(true);
                    }
                }
                string __tmp11Line = ","; //61:17
                if (__tmp11Line != null) __out.Append(__tmp11Line);
                __out.AppendLine(false); //61:18
            }
            __out.Append("}"); //63:1
            __out.AppendLine(false); //63:2
            __out.AppendLine(true); //64:1
            return __out.ToString();
        }

        public string GetAncestors(MetaClass cls) //67:1
        {
            string result = ""; //68:2
            var __loop7_results = 
                (from __loop7_var1 in __Enumerate((cls).GetEnumerator()) //69:7
                from super in __Enumerate((__loop7_var1.SuperClasses).GetEnumerator()) //69:12
                select new { __loop7_var1 = __loop7_var1, super = super}
                ).ToList(); //69:2
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                string delim; //69:30
                if (__loop7_iteration+1 < __loop7_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop7_results[__loop7_iteration];
                var __loop7_var1 = __tmp1.__loop7_var1;
                var super = __tmp1.super;
                result += super.CSharpFullName() + delim; //70:3
            }
            if (result == "") //72:2
            {
                result = "global::MetaDslx.Core.IModelObject"; //73:3
            }
            if (result != "") //75:2
            {
                result = " : " + result; //76:3
            }
            return result; //78:2
        }

        public string GenerateInterface(MetaClass cls) //81:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(GenerateDocumentation(cls));
            using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
            {
                bool __tmp2_first = true;
                bool __tmp2_last = __tmp2Reader.EndOfStream;
                while(__tmp2_first || !__tmp2_last)
                {
                    __tmp2_first = false;
                    string __tmp2Line = __tmp2Reader.ReadLine();
                    __tmp2_last = __tmp2Reader.EndOfStream;
                    if (__tmp2Line != null) __out.Append(__tmp2Line);
                    if (!__tmp2_last) __out.AppendLine(true);
                    __out.AppendLine(false); //82:29
                }
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(GenerateAnnotations(cls));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_first = true;
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(__tmp4_first || !__tmp4_last)
                {
                    __tmp4_first = false;
                    string __tmp4Line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (__tmp4Line != null) __out.Append(__tmp4Line);
                    if (!__tmp4_last) __out.AppendLine(true);
                    __out.AppendLine(false); //83:27
                }
            }
            string __tmp6Line = "public interface "; //84:1
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(cls.CSharpName());
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_first = true;
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(__tmp7_first || !__tmp7_last)
                {
                    __tmp7_first = false;
                    string __tmp7Line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    if (__tmp7Line != null) __out.Append(__tmp7Line);
                    if (!__tmp7_last) __out.AppendLine(true);
                }
            }
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(GetAncestors(cls));
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_first = true;
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(__tmp8_first || !__tmp8_last)
                {
                    __tmp8_first = false;
                    string __tmp8Line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if (__tmp8Line != null) __out.Append(__tmp8Line);
                    if (!__tmp8_last) __out.AppendLine(true);
                    __out.AppendLine(false); //84:55
                }
            }
            __out.Append("{"); //85:1
            __out.AppendLine(false); //85:2
            var __loop8_results = 
                (from __loop8_var1 in __Enumerate((cls).GetEnumerator()) //86:11
                from prop in __Enumerate((__loop8_var1.Properties).GetEnumerator()) //86:16
                select new { __loop8_var1 = __loop8_var1, prop = prop}
                ).ToList(); //86:6
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp9 = __loop8_results[__loop8_iteration];
                var __loop8_var1 = __tmp9.__loop8_var1;
                var prop = __tmp9.prop;
                string __tmp10Prefix = "    "; //87:1
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(GenerateProperty(prop));
                using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                {
                    bool __tmp11_first = true;
                    bool __tmp11_last = __tmp11Reader.EndOfStream;
                    while(__tmp11_first || !__tmp11_last)
                    {
                        __tmp11_first = false;
                        string __tmp11Line = __tmp11Reader.ReadLine();
                        __tmp11_last = __tmp11Reader.EndOfStream;
                        __out.Append(__tmp10Prefix);
                        if (__tmp11Line != null) __out.Append(__tmp11Line);
                        if (!__tmp11_last) __out.AppendLine(true);
                        __out.AppendLine(false); //87:29
                    }
                }
            }
            __out.AppendLine(true); //89:1
            var __loop9_results = 
                (from __loop9_var1 in __Enumerate((cls).GetEnumerator()) //90:11
                from op in __Enumerate((__loop9_var1.Operations).GetEnumerator()) //90:16
                select new { __loop9_var1 = __loop9_var1, op = op}
                ).ToList(); //90:6
            for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
            {
                var __tmp12 = __loop9_results[__loop9_iteration];
                var __loop9_var1 = __tmp12.__loop9_var1;
                var op = __tmp12.op;
                string __tmp13Prefix = "    "; //91:1
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(GenerateOperation(op));
                using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
                {
                    bool __tmp14_first = true;
                    bool __tmp14_last = __tmp14Reader.EndOfStream;
                    while(__tmp14_first || !__tmp14_last)
                    {
                        __tmp14_first = false;
                        string __tmp14Line = __tmp14Reader.ReadLine();
                        __tmp14_last = __tmp14Reader.EndOfStream;
                        __out.Append(__tmp13Prefix);
                        if (__tmp14Line != null) __out.Append(__tmp14Line);
                        if (!__tmp14_last) __out.AppendLine(true);
                        __out.AppendLine(false); //91:28
                    }
                }
            }
            __out.Append("}"); //93:1
            __out.AppendLine(false); //93:2
            __out.AppendLine(true); //94:1
            return __out.ToString();
        }

        public string GenerateProperty(MetaProperty prop) //97:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(GenerateDocumentation(prop));
            using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
            {
                bool __tmp2_first = true;
                bool __tmp2_last = __tmp2Reader.EndOfStream;
                while(__tmp2_first || !__tmp2_last)
                {
                    __tmp2_first = false;
                    string __tmp2Line = __tmp2Reader.ReadLine();
                    __tmp2_last = __tmp2Reader.EndOfStream;
                    if (__tmp2Line != null) __out.Append(__tmp2Line);
                    if (!__tmp2_last) __out.AppendLine(true);
                    __out.AppendLine(false); //98:30
                }
            }
            if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //99:2
            {
                __out.Append("new "); //100:1
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //102:3
            {
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append(prop.Type.CSharpFullPublicName());
                using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                {
                    bool __tmp4_first = true;
                    bool __tmp4_last = __tmp4Reader.EndOfStream;
                    while(__tmp4_first || !__tmp4_last)
                    {
                        __tmp4_first = false;
                        string __tmp4Line = __tmp4Reader.ReadLine();
                        __tmp4_last = __tmp4Reader.EndOfStream;
                        if (__tmp4Line != null) __out.Append(__tmp4Line);
                        if (!__tmp4_last) __out.AppendLine(true);
                    }
                }
                string __tmp5Line = " "; //103:35
                if (__tmp5Line != null) __out.Append(__tmp5Line);
                StringBuilder __tmp6 = new StringBuilder();
                __tmp6.Append(prop.Name);
                using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
                {
                    bool __tmp6_first = true;
                    bool __tmp6_last = __tmp6Reader.EndOfStream;
                    while(__tmp6_first || !__tmp6_last)
                    {
                        __tmp6_first = false;
                        string __tmp6Line = __tmp6Reader.ReadLine();
                        __tmp6_last = __tmp6Reader.EndOfStream;
                        if (__tmp6Line != null) __out.Append(__tmp6Line);
                        if (!__tmp6_last) __out.AppendLine(true);
                    }
                }
                string __tmp7Line = " { get; set; }"; //103:47
                if (__tmp7Line != null) __out.Append(__tmp7Line);
                __out.AppendLine(false); //103:61
            }
            else //104:3
            {
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append(prop.Type.CSharpFullPublicName());
                using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                {
                    bool __tmp9_first = true;
                    bool __tmp9_last = __tmp9Reader.EndOfStream;
                    while(__tmp9_first || !__tmp9_last)
                    {
                        __tmp9_first = false;
                        string __tmp9Line = __tmp9Reader.ReadLine();
                        __tmp9_last = __tmp9Reader.EndOfStream;
                        if (__tmp9Line != null) __out.Append(__tmp9Line);
                        if (!__tmp9_last) __out.AppendLine(true);
                    }
                }
                string __tmp10Line = " "; //105:35
                if (__tmp10Line != null) __out.Append(__tmp10Line);
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(prop.Name);
                using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                {
                    bool __tmp11_first = true;
                    bool __tmp11_last = __tmp11Reader.EndOfStream;
                    while(__tmp11_first || !__tmp11_last)
                    {
                        __tmp11_first = false;
                        string __tmp11Line = __tmp11Reader.ReadLine();
                        __tmp11_last = __tmp11Reader.EndOfStream;
                        if (__tmp11Line != null) __out.Append(__tmp11Line);
                        if (!__tmp11_last) __out.AppendLine(true);
                    }
                }
                string __tmp12Line = " { get; }"; //105:47
                if (__tmp12Line != null) __out.Append(__tmp12Line);
                __out.AppendLine(false); //105:56
            }
            return __out.ToString();
        }

        public string GetParameters(MetaOperation op, bool defaultValues) //109:1
        {
            string result = ""; //110:2
            var __loop10_results = 
                (from __loop10_var1 in __Enumerate((op).GetEnumerator()) //111:7
                from param in __Enumerate((__loop10_var1.Parameters).GetEnumerator()) //111:11
                select new { __loop10_var1 = __loop10_var1, param = param}
                ).ToList(); //111:2
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                string delim; //111:27
                if (__loop10_iteration+1 < __loop10_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop10_results[__loop10_iteration];
                var __loop10_var1 = __tmp1.__loop10_var1;
                var param = __tmp1.param;
                result += param.Type.CSharpFullPublicName() + " " + param.Name + delim; //112:3
            }
            return result; //117:2
        }

        public string GetImplParameters(MetaClass cls, MetaOperation op) //120:1
        {
            string result = cls.CSharpFullName() + " @this"; //121:2
            string delim = ", "; //122:2
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((op).GetEnumerator()) //123:7
                from param in __Enumerate((__loop11_var1.Parameters).GetEnumerator()) //123:11
                select new { __loop11_var1 = __loop11_var1, param = param}
                ).ToList(); //123:2
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp1 = __loop11_results[__loop11_iteration];
                var __loop11_var1 = __tmp1.__loop11_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName() + " " + param.Name; //124:3
            }
            return result; //126:2
        }

        public string GetImplParameters(MetaEnum enm, MetaOperation op) //129:1
        {
            string result = enm.CSharpFullName() + " @this"; //130:2
            string delim = ", "; //131:2
            var __loop12_results = 
                (from __loop12_var1 in __Enumerate((op).GetEnumerator()) //132:7
                from param in __Enumerate((__loop12_var1.Parameters).GetEnumerator()) //132:11
                select new { __loop12_var1 = __loop12_var1, param = param}
                ).ToList(); //132:2
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp1 = __loop12_results[__loop12_iteration];
                var __loop12_var1 = __tmp1.__loop12_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName() + " " + param.Name; //133:3
            }
            return result; //135:2
        }

        public string GetEnumImplParameters(MetaEnum enm, MetaOperation op) //138:1
        {
            string result = "this " + enm.CSharpFullName() + " @this"; //139:2
            string delim = ", "; //140:2
            var __loop13_results = 
                (from __loop13_var1 in __Enumerate((op).GetEnumerator()) //141:7
                from param in __Enumerate((__loop13_var1.Parameters).GetEnumerator()) //141:11
                select new { __loop13_var1 = __loop13_var1, param = param}
                ).ToList(); //141:2
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp1 = __loop13_results[__loop13_iteration];
                var __loop13_var1 = __tmp1.__loop13_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName() + " " + param.Name; //142:3
            }
            return result; //144:2
        }

        public string GetEnumImplCallParameterNames(MetaOperation op) //147:1
        {
            string result = "@this"; //148:2
            string delim = ", "; //149:2
            var __loop14_results = 
                (from __loop14_var1 in __Enumerate((op).GetEnumerator()) //150:7
                from param in __Enumerate((__loop14_var1.Parameters).GetEnumerator()) //150:11
                select new { __loop14_var1 = __loop14_var1, param = param}
                ).ToList(); //150:2
            for (int __loop14_iteration = 0; __loop14_iteration < __loop14_results.Count; ++__loop14_iteration)
            {
                var __tmp1 = __loop14_results[__loop14_iteration];
                var __loop14_var1 = __tmp1.__loop14_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //151:3
            }
            return result; //153:2
        }

        public string GetImplCallParameterNames(MetaOperation op) //156:1
        {
            string result = "this"; //157:2
            string delim = ", "; //158:2
            var __loop15_results = 
                (from __loop15_var1 in __Enumerate((op).GetEnumerator()) //159:7
                from param in __Enumerate((__loop15_var1.Parameters).GetEnumerator()) //159:11
                select new { __loop15_var1 = __loop15_var1, param = param}
                ).ToList(); //159:2
            for (int __loop15_iteration = 0; __loop15_iteration < __loop15_results.Count; ++__loop15_iteration)
            {
                var __tmp1 = __loop15_results[__loop15_iteration];
                var __loop15_var1 = __tmp1.__loop15_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //160:3
            }
            return result; //162:2
        }

        public string GenerateOperation(MetaOperation op) //165:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(GenerateDocumentation(op));
            using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
            {
                bool __tmp2_first = true;
                bool __tmp2_last = __tmp2Reader.EndOfStream;
                while(__tmp2_first || !__tmp2_last)
                {
                    __tmp2_first = false;
                    string __tmp2Line = __tmp2Reader.ReadLine();
                    __tmp2_last = __tmp2Reader.EndOfStream;
                    if (__tmp2Line != null) __out.Append(__tmp2Line);
                    if (!__tmp2_last) __out.AppendLine(true);
                    __out.AppendLine(false); //166:28
                }
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(op.ReturnType.CSharpFullPublicName());
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_first = true;
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(__tmp4_first || !__tmp4_last)
                {
                    __tmp4_first = false;
                    string __tmp4Line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (__tmp4Line != null) __out.Append(__tmp4Line);
                    if (!__tmp4_last) __out.AppendLine(true);
                }
            }
            string __tmp5Line = " "; //167:39
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(op.Name);
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(__tmp6_first || !__tmp6_last)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if (__tmp6Line != null) __out.Append(__tmp6Line);
                    if (!__tmp6_last) __out.AppendLine(true);
                }
            }
            string __tmp7Line = "("; //167:49
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(GetParameters(op, true));
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_first = true;
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(__tmp8_first || !__tmp8_last)
                {
                    __tmp8_first = false;
                    string __tmp8Line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if (__tmp8Line != null) __out.Append(__tmp8Line);
                    if (!__tmp8_last) __out.AppendLine(true);
                }
            }
            string __tmp9Line = ");"; //167:75
            if (__tmp9Line != null) __out.Append(__tmp9Line);
            __out.AppendLine(false); //167:77
            return __out.ToString();
        }

        public string GenerateInterfaceImpl(MetaModel model, MetaClass cls) //170:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal class "; //171:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.CSharpImplName());
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(__tmp3_first || !__tmp3_last)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    if (!__tmp3_last) __out.AppendLine(true);
                }
            }
            string __tmp4Line = " : ModelObject, "; //171:38
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(cls.CSharpFullName());
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_first = true;
                bool __tmp5_last = __tmp5Reader.EndOfStream;
                while(__tmp5_first || !__tmp5_last)
                {
                    __tmp5_first = false;
                    string __tmp5Line = __tmp5Reader.ReadLine();
                    __tmp5_last = __tmp5Reader.EndOfStream;
                    if (__tmp5Line != null) __out.Append(__tmp5Line);
                    if (!__tmp5_last) __out.AppendLine(true);
                    __out.AppendLine(false); //171:76
                }
            }
            __out.Append("{"); //172:1
            __out.AppendLine(false); //172:2
            string __tmp7Line = "    static "; //173:1
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(cls.CSharpImplName());
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_first = true;
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(__tmp8_first || !__tmp8_last)
                {
                    __tmp8_first = false;
                    string __tmp8Line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if (__tmp8Line != null) __out.Append(__tmp8Line);
                    if (!__tmp8_last) __out.AppendLine(true);
                }
            }
            string __tmp9Line = "()"; //173:34
            if (__tmp9Line != null) __out.Append(__tmp9Line);
            __out.AppendLine(false); //173:36
            __out.Append("    {"); //174:1
            __out.AppendLine(false); //174:6
            string __tmp10Prefix = "        "; //175:1
            StringBuilder __tmp11 = new StringBuilder();
            __tmp11.Append(cls.Model.CSharpFullDescriptorName());
            using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
            {
                bool __tmp11_first = true;
                bool __tmp11_last = __tmp11Reader.EndOfStream;
                while(__tmp11_first || !__tmp11_last)
                {
                    __tmp11_first = false;
                    string __tmp11Line = __tmp11Reader.ReadLine();
                    __tmp11_last = __tmp11Reader.EndOfStream;
                    __out.Append(__tmp10Prefix);
                    if (__tmp11Line != null) __out.Append(__tmp11Line);
                    if (!__tmp11_last) __out.AppendLine(true);
                }
            }
            string __tmp12Line = ".StaticInit();"; //175:47
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //175:61
            __out.Append("    }"); //176:1
            __out.AppendLine(false); //176:6
            __out.AppendLine(true); //177:1
            __out.Append("    public override global::MetaDslx.Core.MetaModel MMetaModel"); //178:1
            __out.AppendLine(false); //178:63
            __out.Append("    {"); //179:1
            __out.AppendLine(false); //179:6
            string __tmp14Line = "        get { return "; //180:1
            if (__tmp14Line != null) __out.Append(__tmp14Line);
            StringBuilder __tmp15 = new StringBuilder();
            __tmp15.Append(cls.Model.CSharpFullInstanceName());
            using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
            {
                bool __tmp15_first = true;
                bool __tmp15_last = __tmp15Reader.EndOfStream;
                while(__tmp15_first || !__tmp15_last)
                {
                    __tmp15_first = false;
                    string __tmp15Line = __tmp15Reader.ReadLine();
                    __tmp15_last = __tmp15Reader.EndOfStream;
                    if (__tmp15Line != null) __out.Append(__tmp15Line);
                    if (!__tmp15_last) __out.AppendLine(true);
                }
            }
            string __tmp16Line = "; }"; //180:58
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            __out.AppendLine(false); //180:61
            __out.Append("    }"); //181:1
            __out.AppendLine(false); //181:6
            __out.AppendLine(true); //182:1
            __out.Append("    public override global::MetaDslx.Core.MetaClass MMetaClass"); //183:1
            __out.AppendLine(false); //183:63
            __out.Append("    {"); //184:1
            __out.AppendLine(false); //184:6
            string __tmp18Line = "        get { return "; //185:1
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            StringBuilder __tmp19 = new StringBuilder();
            __tmp19.Append(cls.CSharpFullInstanceName());
            using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
            {
                bool __tmp19_first = true;
                bool __tmp19_last = __tmp19Reader.EndOfStream;
                while(__tmp19_first || !__tmp19_last)
                {
                    __tmp19_first = false;
                    string __tmp19Line = __tmp19Reader.ReadLine();
                    __tmp19_last = __tmp19Reader.EndOfStream;
                    if (__tmp19Line != null) __out.Append(__tmp19Line);
                    if (!__tmp19_last) __out.AppendLine(true);
                }
            }
            string __tmp20Line = "; }"; //185:52
            if (__tmp20Line != null) __out.Append(__tmp20Line);
            __out.AppendLine(false); //185:55
            __out.Append("    }"); //186:1
            __out.AppendLine(false); //186:6
            __out.AppendLine(true); //187:1
            string __tmp21Prefix = "    "; //188:1
            StringBuilder __tmp22 = new StringBuilder();
            __tmp22.Append(GenerateConstructorImpl(model, cls));
            using(StreamReader __tmp22Reader = new StreamReader(this.__ToStream(__tmp22.ToString())))
            {
                bool __tmp22_first = true;
                bool __tmp22_last = __tmp22Reader.EndOfStream;
                while(__tmp22_first || !__tmp22_last)
                {
                    __tmp22_first = false;
                    string __tmp22Line = __tmp22Reader.ReadLine();
                    __tmp22_last = __tmp22Reader.EndOfStream;
                    __out.Append(__tmp21Prefix);
                    if (__tmp22Line != null) __out.Append(__tmp22Line);
                    if (!__tmp22_last) __out.AppendLine(true);
                    __out.AppendLine(false); //188:42
                }
            }
            var __loop16_results = 
                (from __loop16_var1 in __Enumerate((cls).GetEnumerator()) //189:11
                from prop in __Enumerate((__loop16_var1.GetAllProperties()).GetEnumerator()) //189:16
                select new { __loop16_var1 = __loop16_var1, prop = prop}
                ).ToList(); //189:6
            for (int __loop16_iteration = 0; __loop16_iteration < __loop16_results.Count; ++__loop16_iteration)
            {
                var __tmp23 = __loop16_results[__loop16_iteration];
                var __loop16_var1 = __tmp23.__loop16_var1;
                var prop = __tmp23.prop;
                string __tmp24Prefix = "    "; //190:1
                StringBuilder __tmp25 = new StringBuilder();
                __tmp25.Append(GeneratePropertyImpl(model, cls, prop));
                using(StreamReader __tmp25Reader = new StreamReader(this.__ToStream(__tmp25.ToString())))
                {
                    bool __tmp25_first = true;
                    bool __tmp25_last = __tmp25Reader.EndOfStream;
                    while(__tmp25_first || !__tmp25_last)
                    {
                        __tmp25_first = false;
                        string __tmp25Line = __tmp25Reader.ReadLine();
                        __tmp25_last = __tmp25Reader.EndOfStream;
                        __out.Append(__tmp24Prefix);
                        if (__tmp25Line != null) __out.Append(__tmp25Line);
                        if (!__tmp25_last) __out.AppendLine(true);
                        __out.AppendLine(false); //190:45
                    }
                }
            }
            var __loop17_results = 
                (from __loop17_var1 in __Enumerate((cls).GetEnumerator()) //192:11
                from op in __Enumerate((__loop17_var1.GetAllOperations()).GetEnumerator()) //192:16
                select new { __loop17_var1 = __loop17_var1, op = op}
                ).ToList(); //192:6
            for (int __loop17_iteration = 0; __loop17_iteration < __loop17_results.Count; ++__loop17_iteration)
            {
                var __tmp26 = __loop17_results[__loop17_iteration];
                var __loop17_var1 = __tmp26.__loop17_var1;
                var op = __tmp26.op;
                string __tmp27Prefix = "    "; //193:1
                StringBuilder __tmp28 = new StringBuilder();
                __tmp28.Append(GenerateOperationImpl(model, op));
                using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
                {
                    bool __tmp28_first = true;
                    bool __tmp28_last = __tmp28Reader.EndOfStream;
                    while(__tmp28_first || !__tmp28_last)
                    {
                        __tmp28_first = false;
                        string __tmp28Line = __tmp28Reader.ReadLine();
                        __tmp28_last = __tmp28Reader.EndOfStream;
                        __out.Append(__tmp27Prefix);
                        if (__tmp28Line != null) __out.Append(__tmp28Line);
                        if (!__tmp28_last) __out.AppendLine(true);
                        __out.AppendLine(false); //193:39
                    }
                }
            }
            __out.Append("}"); //195:1
            __out.AppendLine(false); //195:2
            __out.AppendLine(true); //196:1
            return __out.ToString();
        }

        public string GeneratePropertyDeclaration(MetaModel model, MetaClass cls, MetaProperty prop) //199:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class == cls) //200:2
            {
                StringBuilder __tmp2 = new StringBuilder();
                __tmp2.Append(GenerateAnnotations(prop));
                using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
                {
                    bool __tmp2_first = true;
                    bool __tmp2_last = __tmp2Reader.EndOfStream;
                    while(__tmp2_first || !__tmp2_last)
                    {
                        __tmp2_first = false;
                        string __tmp2Line = __tmp2Reader.ReadLine();
                        __tmp2_last = __tmp2Reader.EndOfStream;
                        if (__tmp2Line != null) __out.Append(__tmp2Line);
                        if (!__tmp2_last) __out.AppendLine(true);
                        __out.AppendLine(false); //201:28
                    }
                }
                if (prop.Kind == MetaPropertyKind.Containment) //202:2
                {
                    StringBuilder __tmp4 = new StringBuilder();
                    __tmp4.Append("[ContainmentAttribute]");
                    using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                    {
                        bool __tmp4_first = true;
                        bool __tmp4_last = __tmp4Reader.EndOfStream;
                        while(__tmp4_first || !__tmp4_last)
                        {
                            __tmp4_first = false;
                            string __tmp4Line = __tmp4Reader.ReadLine();
                            __tmp4_last = __tmp4Reader.EndOfStream;
                            if (__tmp4Line != null) __out.Append(__tmp4Line);
                            if (!__tmp4_last) __out.AppendLine(true);
                            __out.AppendLine(false); //203:27
                        }
                    }
                }
                if (prop.Kind != MetaPropertyKind.Normal && prop.Kind != MetaPropertyKind.Containment) //205:2
                {
                    StringBuilder __tmp6 = new StringBuilder();
                    __tmp6.Append("[ReadonlyAttribute]");
                    using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
                    {
                        bool __tmp6_first = true;
                        bool __tmp6_last = __tmp6Reader.EndOfStream;
                        while(__tmp6_first || !__tmp6_last)
                        {
                            __tmp6_first = false;
                            string __tmp6Line = __tmp6Reader.ReadLine();
                            __tmp6_last = __tmp6Reader.EndOfStream;
                            if (__tmp6Line != null) __out.Append(__tmp6Line);
                            if (!__tmp6_last) __out.AppendLine(true);
                            __out.AppendLine(false); //206:24
                        }
                    }
                }
                var __loop18_results = 
                    (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //208:7
                    select new { p = p}
                    ).ToList(); //208:2
                for (int __loop18_iteration = 0; __loop18_iteration < __loop18_results.Count; ++__loop18_iteration)
                {
                    var __tmp7 = __loop18_results[__loop18_iteration];
                    var p = __tmp7.p;
                    StringBuilder __tmp9 = new StringBuilder();
                    __tmp9.Append("[OppositeAttribute(typeof(");
                    using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                    {
                        bool __tmp9_first = true;
                        bool __tmp9_last = __tmp9Reader.EndOfStream;
                        while(__tmp9_first || !__tmp9_last)
                        {
                            __tmp9_first = false;
                            string __tmp9Line = __tmp9Reader.ReadLine();
                            __tmp9_last = __tmp9Reader.EndOfStream;
                            if (__tmp9Line != null) __out.Append(__tmp9Line);
                            if (!__tmp9_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp10 = new StringBuilder();
                    __tmp10.Append(p.Class.CSharpFullDescriptorName());
                    using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
                    {
                        bool __tmp10_first = true;
                        bool __tmp10_last = __tmp10Reader.EndOfStream;
                        while(__tmp10_first || !__tmp10_last)
                        {
                            __tmp10_first = false;
                            string __tmp10Line = __tmp10Reader.ReadLine();
                            __tmp10_last = __tmp10Reader.EndOfStream;
                            if (__tmp10Line != null) __out.Append(__tmp10Line);
                            if (!__tmp10_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp11 = new StringBuilder();
                    __tmp11.Append("), \"");
                    using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                    {
                        bool __tmp11_first = true;
                        bool __tmp11_last = __tmp11Reader.EndOfStream;
                        while(__tmp11_first || !__tmp11_last)
                        {
                            __tmp11_first = false;
                            string __tmp11Line = __tmp11Reader.ReadLine();
                            __tmp11_last = __tmp11Reader.EndOfStream;
                            if (__tmp11Line != null) __out.Append(__tmp11Line);
                            if (!__tmp11_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp12 = new StringBuilder();
                    __tmp12.Append(p.Name);
                    using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
                    {
                        bool __tmp12_first = true;
                        bool __tmp12_last = __tmp12Reader.EndOfStream;
                        while(__tmp12_first || !__tmp12_last)
                        {
                            __tmp12_first = false;
                            string __tmp12Line = __tmp12Reader.ReadLine();
                            __tmp12_last = __tmp12Reader.EndOfStream;
                            if (__tmp12Line != null) __out.Append(__tmp12Line);
                            if (!__tmp12_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp13 = new StringBuilder();
                    __tmp13.Append("\")]");
                    using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                    {
                        bool __tmp13_first = true;
                        bool __tmp13_last = __tmp13Reader.EndOfStream;
                        while(__tmp13_first || !__tmp13_last)
                        {
                            __tmp13_first = false;
                            string __tmp13Line = __tmp13Reader.ReadLine();
                            __tmp13_last = __tmp13Reader.EndOfStream;
                            if (__tmp13Line != null) __out.Append(__tmp13Line);
                            if (!__tmp13_last) __out.AppendLine(true);
                            __out.AppendLine(false); //209:92
                        }
                    }
                }
                var __loop19_results = 
                    (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //211:7
                    select new { p = p}
                    ).ToList(); //211:2
                for (int __loop19_iteration = 0; __loop19_iteration < __loop19_results.Count; ++__loop19_iteration)
                {
                    var __tmp14 = __loop19_results[__loop19_iteration];
                    var p = __tmp14.p;
                    if (cls.GetAllSuperClasses(true).Contains(p.Class)) //212:3
                    {
                        StringBuilder __tmp16 = new StringBuilder();
                        __tmp16.Append("[SubsetsAttribute(typeof(");
                        using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
                        {
                            bool __tmp16_first = true;
                            bool __tmp16_last = __tmp16Reader.EndOfStream;
                            while(__tmp16_first || !__tmp16_last)
                            {
                                __tmp16_first = false;
                                string __tmp16Line = __tmp16Reader.ReadLine();
                                __tmp16_last = __tmp16Reader.EndOfStream;
                                if (__tmp16Line != null) __out.Append(__tmp16Line);
                                if (!__tmp16_last) __out.AppendLine(true);
                            }
                        }
                        StringBuilder __tmp17 = new StringBuilder();
                        __tmp17.Append(p.Class.CSharpFullDescriptorName());
                        using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
                        {
                            bool __tmp17_first = true;
                            bool __tmp17_last = __tmp17Reader.EndOfStream;
                            while(__tmp17_first || !__tmp17_last)
                            {
                                __tmp17_first = false;
                                string __tmp17Line = __tmp17Reader.ReadLine();
                                __tmp17_last = __tmp17Reader.EndOfStream;
                                if (__tmp17Line != null) __out.Append(__tmp17Line);
                                if (!__tmp17_last) __out.AppendLine(true);
                            }
                        }
                        StringBuilder __tmp18 = new StringBuilder();
                        __tmp18.Append("), \"");
                        using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
                        {
                            bool __tmp18_first = true;
                            bool __tmp18_last = __tmp18Reader.EndOfStream;
                            while(__tmp18_first || !__tmp18_last)
                            {
                                __tmp18_first = false;
                                string __tmp18Line = __tmp18Reader.ReadLine();
                                __tmp18_last = __tmp18Reader.EndOfStream;
                                if (__tmp18Line != null) __out.Append(__tmp18Line);
                                if (!__tmp18_last) __out.AppendLine(true);
                            }
                        }
                        StringBuilder __tmp19 = new StringBuilder();
                        __tmp19.Append(p.Name);
                        using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
                        {
                            bool __tmp19_first = true;
                            bool __tmp19_last = __tmp19Reader.EndOfStream;
                            while(__tmp19_first || !__tmp19_last)
                            {
                                __tmp19_first = false;
                                string __tmp19Line = __tmp19Reader.ReadLine();
                                __tmp19_last = __tmp19Reader.EndOfStream;
                                if (__tmp19Line != null) __out.Append(__tmp19Line);
                                if (!__tmp19_last) __out.AppendLine(true);
                            }
                        }
                        StringBuilder __tmp20 = new StringBuilder();
                        __tmp20.Append("\")]");
                        using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
                        {
                            bool __tmp20_first = true;
                            bool __tmp20_last = __tmp20Reader.EndOfStream;
                            while(__tmp20_first || !__tmp20_last)
                            {
                                __tmp20_first = false;
                                string __tmp20Line = __tmp20Reader.ReadLine();
                                __tmp20_last = __tmp20Reader.EndOfStream;
                                if (__tmp20Line != null) __out.Append(__tmp20Line);
                                if (!__tmp20_last) __out.AppendLine(true);
                                __out.AppendLine(false); //213:91
                            }
                        }
                    }
                    else //214:3
                    {
                        string __tmp22Line = "// ERROR: subsetted property '"; //215:1
                        if (__tmp22Line != null) __out.Append(__tmp22Line);
                        StringBuilder __tmp23 = new StringBuilder();
                        __tmp23.Append(p.CSharpFullDescriptorName());
                        using(StreamReader __tmp23Reader = new StreamReader(this.__ToStream(__tmp23.ToString())))
                        {
                            bool __tmp23_first = true;
                            bool __tmp23_last = __tmp23Reader.EndOfStream;
                            while(__tmp23_first || !__tmp23_last)
                            {
                                __tmp23_first = false;
                                string __tmp23Line = __tmp23Reader.ReadLine();
                                __tmp23_last = __tmp23Reader.EndOfStream;
                                if (__tmp23Line != null) __out.Append(__tmp23Line);
                                if (!__tmp23_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp24Line = "' must be a property of an ancestor class"; //215:61
                        if (__tmp24Line != null) __out.Append(__tmp24Line);
                        __out.AppendLine(false); //215:102
                    }
                }
                var __loop20_results = 
                    (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //218:7
                    select new { p = p}
                    ).ToList(); //218:2
                for (int __loop20_iteration = 0; __loop20_iteration < __loop20_results.Count; ++__loop20_iteration)
                {
                    var __tmp25 = __loop20_results[__loop20_iteration];
                    var p = __tmp25.p;
                    if (cls.GetAllSuperClasses(true).Contains(p.Class)) //219:3
                    {
                        StringBuilder __tmp27 = new StringBuilder();
                        __tmp27.Append("[RedefinesAttribute(typeof(");
                        using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
                        {
                            bool __tmp27_first = true;
                            bool __tmp27_last = __tmp27Reader.EndOfStream;
                            while(__tmp27_first || !__tmp27_last)
                            {
                                __tmp27_first = false;
                                string __tmp27Line = __tmp27Reader.ReadLine();
                                __tmp27_last = __tmp27Reader.EndOfStream;
                                if (__tmp27Line != null) __out.Append(__tmp27Line);
                                if (!__tmp27_last) __out.AppendLine(true);
                            }
                        }
                        StringBuilder __tmp28 = new StringBuilder();
                        __tmp28.Append(p.Class.CSharpFullDescriptorName());
                        using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
                        {
                            bool __tmp28_first = true;
                            bool __tmp28_last = __tmp28Reader.EndOfStream;
                            while(__tmp28_first || !__tmp28_last)
                            {
                                __tmp28_first = false;
                                string __tmp28Line = __tmp28Reader.ReadLine();
                                __tmp28_last = __tmp28Reader.EndOfStream;
                                if (__tmp28Line != null) __out.Append(__tmp28Line);
                                if (!__tmp28_last) __out.AppendLine(true);
                            }
                        }
                        StringBuilder __tmp29 = new StringBuilder();
                        __tmp29.Append("), \"");
                        using(StreamReader __tmp29Reader = new StreamReader(this.__ToStream(__tmp29.ToString())))
                        {
                            bool __tmp29_first = true;
                            bool __tmp29_last = __tmp29Reader.EndOfStream;
                            while(__tmp29_first || !__tmp29_last)
                            {
                                __tmp29_first = false;
                                string __tmp29Line = __tmp29Reader.ReadLine();
                                __tmp29_last = __tmp29Reader.EndOfStream;
                                if (__tmp29Line != null) __out.Append(__tmp29Line);
                                if (!__tmp29_last) __out.AppendLine(true);
                            }
                        }
                        StringBuilder __tmp30 = new StringBuilder();
                        __tmp30.Append(p.Name);
                        using(StreamReader __tmp30Reader = new StreamReader(this.__ToStream(__tmp30.ToString())))
                        {
                            bool __tmp30_first = true;
                            bool __tmp30_last = __tmp30Reader.EndOfStream;
                            while(__tmp30_first || !__tmp30_last)
                            {
                                __tmp30_first = false;
                                string __tmp30Line = __tmp30Reader.ReadLine();
                                __tmp30_last = __tmp30Reader.EndOfStream;
                                if (__tmp30Line != null) __out.Append(__tmp30Line);
                                if (!__tmp30_last) __out.AppendLine(true);
                            }
                        }
                        StringBuilder __tmp31 = new StringBuilder();
                        __tmp31.Append("\")]");
                        using(StreamReader __tmp31Reader = new StreamReader(this.__ToStream(__tmp31.ToString())))
                        {
                            bool __tmp31_first = true;
                            bool __tmp31_last = __tmp31Reader.EndOfStream;
                            while(__tmp31_first || !__tmp31_last)
                            {
                                __tmp31_first = false;
                                string __tmp31Line = __tmp31Reader.ReadLine();
                                __tmp31_last = __tmp31Reader.EndOfStream;
                                if (__tmp31Line != null) __out.Append(__tmp31Line);
                                if (!__tmp31_last) __out.AppendLine(true);
                                __out.AppendLine(false); //220:93
                            }
                        }
                    }
                    else //221:3
                    {
                        string __tmp33Line = "// ERROR: redefined property '"; //222:1
                        if (__tmp33Line != null) __out.Append(__tmp33Line);
                        StringBuilder __tmp34 = new StringBuilder();
                        __tmp34.Append(p.CSharpFullDescriptorName());
                        using(StreamReader __tmp34Reader = new StreamReader(this.__ToStream(__tmp34.ToString())))
                        {
                            bool __tmp34_first = true;
                            bool __tmp34_last = __tmp34Reader.EndOfStream;
                            while(__tmp34_first || !__tmp34_last)
                            {
                                __tmp34_first = false;
                                string __tmp34Line = __tmp34Reader.ReadLine();
                                __tmp34_last = __tmp34Reader.EndOfStream;
                                if (__tmp34Line != null) __out.Append(__tmp34Line);
                                if (!__tmp34_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp35Line = "' must be a property of an ancestor class"; //222:61
                        if (__tmp35Line != null) __out.Append(__tmp35Line);
                        __out.AppendLine(false); //222:102
                    }
                }
                string __tmp37Line = "public static readonly ModelProperty "; //225:1
                if (__tmp37Line != null) __out.Append(__tmp37Line);
                StringBuilder __tmp38 = new StringBuilder();
                __tmp38.Append(prop.Name);
                using(StreamReader __tmp38Reader = new StreamReader(this.__ToStream(__tmp38.ToString())))
                {
                    bool __tmp38_first = true;
                    bool __tmp38_last = __tmp38Reader.EndOfStream;
                    while(__tmp38_first || !__tmp38_last)
                    {
                        __tmp38_first = false;
                        string __tmp38Line = __tmp38Reader.ReadLine();
                        __tmp38_last = __tmp38Reader.EndOfStream;
                        if (__tmp38Line != null) __out.Append(__tmp38Line);
                        if (!__tmp38_last) __out.AppendLine(true);
                    }
                }
                string __tmp39Line = "Property ="; //225:49
                if (__tmp39Line != null) __out.Append(__tmp39Line);
                __out.AppendLine(false); //225:59
                string __tmp41Line = "    ModelProperty.Register(\""; //226:1
                if (__tmp41Line != null) __out.Append(__tmp41Line);
                StringBuilder __tmp42 = new StringBuilder();
                __tmp42.Append(prop.Name);
                using(StreamReader __tmp42Reader = new StreamReader(this.__ToStream(__tmp42.ToString())))
                {
                    bool __tmp42_first = true;
                    bool __tmp42_last = __tmp42Reader.EndOfStream;
                    while(__tmp42_first || !__tmp42_last)
                    {
                        __tmp42_first = false;
                        string __tmp42Line = __tmp42Reader.ReadLine();
                        __tmp42_last = __tmp42Reader.EndOfStream;
                        if (__tmp42Line != null) __out.Append(__tmp42Line);
                        if (!__tmp42_last) __out.AppendLine(true);
                    }
                }
                string __tmp43Line = "\", typeof("; //226:40
                if (__tmp43Line != null) __out.Append(__tmp43Line);
                StringBuilder __tmp44 = new StringBuilder();
                __tmp44.Append(prop.Type.CSharpFullPublicName());
                using(StreamReader __tmp44Reader = new StreamReader(this.__ToStream(__tmp44.ToString())))
                {
                    bool __tmp44_first = true;
                    bool __tmp44_last = __tmp44Reader.EndOfStream;
                    while(__tmp44_first || !__tmp44_last)
                    {
                        __tmp44_first = false;
                        string __tmp44Line = __tmp44Reader.ReadLine();
                        __tmp44_last = __tmp44Reader.EndOfStream;
                        if (__tmp44Line != null) __out.Append(__tmp44Line);
                        if (!__tmp44_last) __out.AppendLine(true);
                    }
                }
                string __tmp45Line = "), typeof("; //226:84
                if (__tmp45Line != null) __out.Append(__tmp45Line);
                StringBuilder __tmp46 = new StringBuilder();
                __tmp46.Append(prop.Class.CSharpFullName());
                using(StreamReader __tmp46Reader = new StreamReader(this.__ToStream(__tmp46.ToString())))
                {
                    bool __tmp46_first = true;
                    bool __tmp46_last = __tmp46Reader.EndOfStream;
                    while(__tmp46_first || !__tmp46_last)
                    {
                        __tmp46_first = false;
                        string __tmp46Line = __tmp46Reader.ReadLine();
                        __tmp46_last = __tmp46Reader.EndOfStream;
                        if (__tmp46Line != null) __out.Append(__tmp46Line);
                        if (!__tmp46_last) __out.AppendLine(true);
                    }
                }
                string __tmp47Line = "), typeof("; //226:123
                if (__tmp47Line != null) __out.Append(__tmp47Line);
                StringBuilder __tmp48 = new StringBuilder();
                __tmp48.Append(prop.Class.Model.CSharpFullName());
                using(StreamReader __tmp48Reader = new StreamReader(this.__ToStream(__tmp48.ToString())))
                {
                    bool __tmp48_first = true;
                    bool __tmp48_last = __tmp48Reader.EndOfStream;
                    while(__tmp48_first || !__tmp48_last)
                    {
                        __tmp48_first = false;
                        string __tmp48Line = __tmp48Reader.ReadLine();
                        __tmp48_last = __tmp48Reader.EndOfStream;
                        if (__tmp48Line != null) __out.Append(__tmp48Line);
                        if (!__tmp48_last) __out.AppendLine(true);
                    }
                }
                string __tmp49Line = "Descriptor."; //226:168
                if (__tmp49Line != null) __out.Append(__tmp49Line);
                StringBuilder __tmp50 = new StringBuilder();
                __tmp50.Append(prop.Class.CSharpName());
                using(StreamReader __tmp50Reader = new StreamReader(this.__ToStream(__tmp50.ToString())))
                {
                    bool __tmp50_first = true;
                    bool __tmp50_last = __tmp50Reader.EndOfStream;
                    while(__tmp50_first || !__tmp50_last)
                    {
                        __tmp50_first = false;
                        string __tmp50Line = __tmp50Reader.ReadLine();
                        __tmp50_last = __tmp50Reader.EndOfStream;
                        if (__tmp50Line != null) __out.Append(__tmp50Line);
                        if (!__tmp50_last) __out.AppendLine(true);
                    }
                }
                string __tmp51Line = "), new Lazy<global::MetaDslx.Core.MetaProperty>(() => "; //226:204
                if (__tmp51Line != null) __out.Append(__tmp51Line);
                StringBuilder __tmp52 = new StringBuilder();
                __tmp52.Append(prop.Class.Model.CSharpFullName());
                using(StreamReader __tmp52Reader = new StreamReader(this.__ToStream(__tmp52.ToString())))
                {
                    bool __tmp52_first = true;
                    bool __tmp52_last = __tmp52Reader.EndOfStream;
                    while(__tmp52_first || !__tmp52_last)
                    {
                        __tmp52_first = false;
                        string __tmp52Line = __tmp52Reader.ReadLine();
                        __tmp52_last = __tmp52Reader.EndOfStream;
                        if (__tmp52Line != null) __out.Append(__tmp52Line);
                        if (!__tmp52_last) __out.AppendLine(true);
                    }
                }
                string __tmp53Line = "Instance."; //226:293
                if (__tmp53Line != null) __out.Append(__tmp53Line);
                StringBuilder __tmp54 = new StringBuilder();
                __tmp54.Append(prop.Class.CSharpName());
                using(StreamReader __tmp54Reader = new StreamReader(this.__ToStream(__tmp54.ToString())))
                {
                    bool __tmp54_first = true;
                    bool __tmp54_last = __tmp54Reader.EndOfStream;
                    while(__tmp54_first || !__tmp54_last)
                    {
                        __tmp54_first = false;
                        string __tmp54Line = __tmp54Reader.ReadLine();
                        __tmp54_last = __tmp54Reader.EndOfStream;
                        if (__tmp54Line != null) __out.Append(__tmp54Line);
                        if (!__tmp54_last) __out.AppendLine(true);
                    }
                }
                string __tmp55Line = "_"; //226:327
                if (__tmp55Line != null) __out.Append(__tmp55Line);
                StringBuilder __tmp56 = new StringBuilder();
                __tmp56.Append(prop.Name);
                using(StreamReader __tmp56Reader = new StreamReader(this.__ToStream(__tmp56.ToString())))
                {
                    bool __tmp56_first = true;
                    bool __tmp56_last = __tmp56Reader.EndOfStream;
                    while(__tmp56_first || !__tmp56_last)
                    {
                        __tmp56_first = false;
                        string __tmp56Line = __tmp56Reader.ReadLine();
                        __tmp56_last = __tmp56Reader.EndOfStream;
                        if (__tmp56Line != null) __out.Append(__tmp56Line);
                        if (!__tmp56_last) __out.AppendLine(true);
                    }
                }
                string __tmp57Line = "Property, LazyThreadSafetyMode.ExecutionAndPublication));"; //226:339
                if (__tmp57Line != null) __out.Append(__tmp57Line);
                __out.AppendLine(false); //226:396
            }
            __out.AppendLine(true); //228:1
            return __out.ToString();
        }

        public string GeneratePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //231:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //232:1
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(prop.Type.CSharpFullPublicName());
            using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
            {
                bool __tmp2_first = true;
                bool __tmp2_last = __tmp2Reader.EndOfStream;
                while(__tmp2_first || !__tmp2_last)
                {
                    __tmp2_first = false;
                    string __tmp2Line = __tmp2Reader.ReadLine();
                    __tmp2_last = __tmp2Reader.EndOfStream;
                    if (__tmp2Line != null) __out.Append(__tmp2Line);
                    if (!__tmp2_last) __out.AppendLine(true);
                }
            }
            string __tmp3Line = " "; //233:35
            if (__tmp3Line != null) __out.Append(__tmp3Line);
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(prop.Class.CSharpFullName());
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_first = true;
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(__tmp4_first || !__tmp4_last)
                {
                    __tmp4_first = false;
                    string __tmp4Line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (__tmp4Line != null) __out.Append(__tmp4Line);
                    if (!__tmp4_last) __out.AppendLine(true);
                }
            }
            string __tmp5Line = "."; //233:65
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(prop.Name);
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(__tmp6_first || !__tmp6_last)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if (__tmp6Line != null) __out.Append(__tmp6Line);
                    if (!__tmp6_last) __out.AppendLine(true);
                    __out.AppendLine(false); //233:77
                }
            }
            __out.Append("{"); //234:1
            __out.AppendLine(false); //234:2
            __out.Append("    get "); //235:1
            __out.AppendLine(false); //235:9
            __out.Append("    {"); //236:1
            __out.AppendLine(false); //236:6
            string __tmp8Line = "        object result = this.MGet("; //237:1
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(prop.CSharpFullDescriptorName());
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_first = true;
                bool __tmp9_last = __tmp9Reader.EndOfStream;
                while(__tmp9_first || !__tmp9_last)
                {
                    __tmp9_first = false;
                    string __tmp9Line = __tmp9Reader.ReadLine();
                    __tmp9_last = __tmp9Reader.EndOfStream;
                    if (__tmp9Line != null) __out.Append(__tmp9Line);
                    if (!__tmp9_last) __out.AppendLine(true);
                }
            }
            string __tmp10Line = "); "; //237:68
            if (__tmp10Line != null) __out.Append(__tmp10Line);
            __out.AppendLine(false); //237:71
            string __tmp12Line = "        if (result != null) return ("; //238:1
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(prop.Type.CSharpFullPublicName());
            using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
            {
                bool __tmp13_first = true;
                bool __tmp13_last = __tmp13Reader.EndOfStream;
                while(__tmp13_first || !__tmp13_last)
                {
                    __tmp13_first = false;
                    string __tmp13Line = __tmp13Reader.ReadLine();
                    __tmp13_last = __tmp13Reader.EndOfStream;
                    if (__tmp13Line != null) __out.Append(__tmp13Line);
                    if (!__tmp13_last) __out.AppendLine(true);
                }
            }
            string __tmp14Line = ")result;"; //238:71
            if (__tmp14Line != null) __out.Append(__tmp14Line);
            __out.AppendLine(false); //238:79
            string __tmp16Line = "        else return default("; //239:1
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(prop.Type.CSharpFullPublicName());
            using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
            {
                bool __tmp17_first = true;
                bool __tmp17_last = __tmp17Reader.EndOfStream;
                while(__tmp17_first || !__tmp17_last)
                {
                    __tmp17_first = false;
                    string __tmp17Line = __tmp17Reader.ReadLine();
                    __tmp17_last = __tmp17Reader.EndOfStream;
                    if (__tmp17Line != null) __out.Append(__tmp17Line);
                    if (!__tmp17_last) __out.AppendLine(true);
                }
            }
            string __tmp18Line = ");"; //239:63
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //239:65
            __out.Append("    }"); //240:1
            __out.AppendLine(false); //240:6
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //241:3
            {
                string __tmp20Line = "    set { this.MSet("; //242:1
                if (__tmp20Line != null) __out.Append(__tmp20Line);
                StringBuilder __tmp21 = new StringBuilder();
                __tmp21.Append(prop.CSharpFullDescriptorName());
                using(StreamReader __tmp21Reader = new StreamReader(this.__ToStream(__tmp21.ToString())))
                {
                    bool __tmp21_first = true;
                    bool __tmp21_last = __tmp21Reader.EndOfStream;
                    while(__tmp21_first || !__tmp21_last)
                    {
                        __tmp21_first = false;
                        string __tmp21Line = __tmp21Reader.ReadLine();
                        __tmp21_last = __tmp21Reader.EndOfStream;
                        if (__tmp21Line != null) __out.Append(__tmp21Line);
                        if (!__tmp21_last) __out.AppendLine(true);
                    }
                }
                string __tmp22Line = ", value); }"; //242:54
                if (__tmp22Line != null) __out.Append(__tmp22Line);
                __out.AppendLine(false); //242:65
            }
            __out.Append("}"); //244:1
            __out.AppendLine(false); //244:2
            return __out.ToString();
        }

        public string GetCollectionConstructorParams(MetaProperty prop) //247:1
        {
            MetaCollectionType mct = prop.Type as MetaCollectionType; //248:2
            if (mct != null && mct.InnerType is MetaClass) //249:2
            {
                return "this, " + prop.CSharpFullDescriptorName(); //250:3
            }
            else //251:2
            {
                return ""; //252:3
            }
        }

        public string GenerateExpression(MetaExpression expr) //257:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //258:10
            if (expr is MetaBracketExpression) //259:2
            {
                string __tmp4Line = "("; //259:33
                if (__tmp4Line != null) __out.Append(__tmp4Line);
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(GenerateExpression(((MetaBracketExpression)expr).Expression));
                using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                {
                    bool __tmp5_first = true;
                    bool __tmp5_last = __tmp5Reader.EndOfStream;
                    while(__tmp5_first || !__tmp5_last)
                    {
                        __tmp5_first = false;
                        string __tmp5Line = __tmp5Reader.ReadLine();
                        __tmp5_last = __tmp5Reader.EndOfStream;
                        if (__tmp5Line != null) __out.Append(__tmp5Line);
                        if (!__tmp5_last) __out.AppendLine(true);
                    }
                }
                string __tmp6Line = ")"; //259:71
                if (__tmp6Line != null) __out.Append(__tmp6Line);
            }
            else if (expr is MetaThisExpression) //260:2
            {
                string __tmp9Line = "(("; //260:30
                if (__tmp9Line != null) __out.Append(__tmp9Line);
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(((MetaType)ModelCompilerContext.Current.ResolutionProvider.GetCurrentTypeScopeOf((ModelObject)((MetaThisExpression)expr))).CSharpName());
                using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
                {
                    bool __tmp10_first = true;
                    bool __tmp10_last = __tmp10Reader.EndOfStream;
                    while(__tmp10_first || !__tmp10_last)
                    {
                        __tmp10_first = false;
                        string __tmp10Line = __tmp10Reader.ReadLine();
                        __tmp10_last = __tmp10Reader.EndOfStream;
                        if (__tmp10Line != null) __out.Append(__tmp10Line);
                        if (!__tmp10_last) __out.AppendLine(true);
                    }
                }
                string __tmp11Line = ")this)"; //260:147
                if (__tmp11Line != null) __out.Append(__tmp11Line);
            }
            else if (expr is MetaNullExpression) //261:2
            {
                __out.Append("null"); //261:30
            }
            else if (expr is MetaTypeAsExpression) //262:2
            {
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(GenerateExpression(((MetaTypeAsExpression)expr).Expression));
                using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
                {
                    bool __tmp14_first = true;
                    bool __tmp14_last = __tmp14Reader.EndOfStream;
                    while(__tmp14_first || !__tmp14_last)
                    {
                        __tmp14_first = false;
                        string __tmp14Line = __tmp14Reader.ReadLine();
                        __tmp14_last = __tmp14Reader.EndOfStream;
                        if (__tmp14Line != null) __out.Append(__tmp14Line);
                        if (!__tmp14_last) __out.AppendLine(true);
                    }
                }
                string __tmp15Line = " as "; //262:69
                if (__tmp15Line != null) __out.Append(__tmp15Line);
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(((MetaTypeAsExpression)expr).TypeReference.CSharpName());
                using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
                {
                    bool __tmp16_first = true;
                    bool __tmp16_last = __tmp16Reader.EndOfStream;
                    while(__tmp16_first || !__tmp16_last)
                    {
                        __tmp16_first = false;
                        string __tmp16Line = __tmp16Reader.ReadLine();
                        __tmp16_last = __tmp16Reader.EndOfStream;
                        if (__tmp16Line != null) __out.Append(__tmp16Line);
                        if (!__tmp16_last) __out.AppendLine(true);
                    }
                }
            }
            else if (expr is MetaTypeCastExpression) //263:2
            {
                string __tmp19Line = "("; //263:34
                if (__tmp19Line != null) __out.Append(__tmp19Line);
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(((MetaTypeCastExpression)expr).TypeReference.CSharpName());
                using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
                {
                    bool __tmp20_first = true;
                    bool __tmp20_last = __tmp20Reader.EndOfStream;
                    while(__tmp20_first || !__tmp20_last)
                    {
                        __tmp20_first = false;
                        string __tmp20Line = __tmp20Reader.ReadLine();
                        __tmp20_last = __tmp20Reader.EndOfStream;
                        if (__tmp20Line != null) __out.Append(__tmp20Line);
                        if (!__tmp20_last) __out.AppendLine(true);
                    }
                }
                string __tmp21Line = ")"; //263:68
                if (__tmp21Line != null) __out.Append(__tmp21Line);
                StringBuilder __tmp22 = new StringBuilder();
                __tmp22.Append(GenerateExpression(((MetaTypeCastExpression)expr).Expression));
                using(StreamReader __tmp22Reader = new StreamReader(this.__ToStream(__tmp22.ToString())))
                {
                    bool __tmp22_first = true;
                    bool __tmp22_last = __tmp22Reader.EndOfStream;
                    while(__tmp22_first || !__tmp22_last)
                    {
                        __tmp22_first = false;
                        string __tmp22Line = __tmp22Reader.ReadLine();
                        __tmp22_last = __tmp22Reader.EndOfStream;
                        if (__tmp22Line != null) __out.Append(__tmp22Line);
                        if (!__tmp22_last) __out.AppendLine(true);
                    }
                }
            }
            else if (expr is MetaTypeCheckExpression) //264:2
            {
                StringBuilder __tmp25 = new StringBuilder();
                __tmp25.Append(GenerateExpression(((MetaTypeCheckExpression)expr).Expression));
                using(StreamReader __tmp25Reader = new StreamReader(this.__ToStream(__tmp25.ToString())))
                {
                    bool __tmp25_first = true;
                    bool __tmp25_last = __tmp25Reader.EndOfStream;
                    while(__tmp25_first || !__tmp25_last)
                    {
                        __tmp25_first = false;
                        string __tmp25Line = __tmp25Reader.ReadLine();
                        __tmp25_last = __tmp25Reader.EndOfStream;
                        if (__tmp25Line != null) __out.Append(__tmp25Line);
                        if (!__tmp25_last) __out.AppendLine(true);
                    }
                }
                string __tmp26Line = " is "; //264:72
                if (__tmp26Line != null) __out.Append(__tmp26Line);
                StringBuilder __tmp27 = new StringBuilder();
                __tmp27.Append(((MetaTypeCheckExpression)expr).TypeReference.CSharpName());
                using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
                {
                    bool __tmp27_first = true;
                    bool __tmp27_last = __tmp27Reader.EndOfStream;
                    while(__tmp27_first || !__tmp27_last)
                    {
                        __tmp27_first = false;
                        string __tmp27Line = __tmp27Reader.ReadLine();
                        __tmp27_last = __tmp27Reader.EndOfStream;
                        if (__tmp27Line != null) __out.Append(__tmp27Line);
                        if (!__tmp27_last) __out.AppendLine(true);
                    }
                }
            }
            else if (expr is MetaTypeOfExpression) //265:2
            {
                StringBuilder __tmp30 = new StringBuilder();
                __tmp30.Append(GenerateTypeOf(((MetaTypeOfExpression)expr)));
                using(StreamReader __tmp30Reader = new StreamReader(this.__ToStream(__tmp30.ToString())))
                {
                    bool __tmp30_first = true;
                    bool __tmp30_last = __tmp30Reader.EndOfStream;
                    while(__tmp30_first || !__tmp30_last)
                    {
                        __tmp30_first = false;
                        string __tmp30Line = __tmp30Reader.ReadLine();
                        __tmp30_last = __tmp30Reader.EndOfStream;
                        if (__tmp30Line != null) __out.Append(__tmp30Line);
                        if (!__tmp30_last) __out.AppendLine(true);
                    }
                }
            }
            else if (expr is MetaConditionalExpression) //266:2
            {
                StringBuilder __tmp33 = new StringBuilder();
                __tmp33.Append(GenerateExpression(((MetaConditionalExpression)expr).Condition));
                using(StreamReader __tmp33Reader = new StreamReader(this.__ToStream(__tmp33.ToString())))
                {
                    bool __tmp33_first = true;
                    bool __tmp33_last = __tmp33Reader.EndOfStream;
                    while(__tmp33_first || !__tmp33_last)
                    {
                        __tmp33_first = false;
                        string __tmp33Line = __tmp33Reader.ReadLine();
                        __tmp33_last = __tmp33Reader.EndOfStream;
                        if (__tmp33Line != null) __out.Append(__tmp33Line);
                        if (!__tmp33_last) __out.AppendLine(true);
                    }
                }
                string __tmp34Line = " ? "; //266:73
                if (__tmp34Line != null) __out.Append(__tmp34Line);
                StringBuilder __tmp35 = new StringBuilder();
                __tmp35.Append(GenerateExpression(((MetaConditionalExpression)expr).Then));
                using(StreamReader __tmp35Reader = new StreamReader(this.__ToStream(__tmp35.ToString())))
                {
                    bool __tmp35_first = true;
                    bool __tmp35_last = __tmp35Reader.EndOfStream;
                    while(__tmp35_first || !__tmp35_last)
                    {
                        __tmp35_first = false;
                        string __tmp35Line = __tmp35Reader.ReadLine();
                        __tmp35_last = __tmp35Reader.EndOfStream;
                        if (__tmp35Line != null) __out.Append(__tmp35Line);
                        if (!__tmp35_last) __out.AppendLine(true);
                    }
                }
                string __tmp36Line = " : "; //266:107
                if (__tmp36Line != null) __out.Append(__tmp36Line);
                StringBuilder __tmp37 = new StringBuilder();
                __tmp37.Append(GenerateExpression(((MetaConditionalExpression)expr).Else));
                using(StreamReader __tmp37Reader = new StreamReader(this.__ToStream(__tmp37.ToString())))
                {
                    bool __tmp37_first = true;
                    bool __tmp37_last = __tmp37Reader.EndOfStream;
                    while(__tmp37_first || !__tmp37_last)
                    {
                        __tmp37_first = false;
                        string __tmp37Line = __tmp37Reader.ReadLine();
                        __tmp37_last = __tmp37Reader.EndOfStream;
                        if (__tmp37Line != null) __out.Append(__tmp37Line);
                        if (!__tmp37_last) __out.AppendLine(true);
                    }
                }
            }
            else if (expr is MetaConstantExpression) //267:2
            {
                StringBuilder __tmp40 = new StringBuilder();
                __tmp40.Append(GetCSharpValue(((MetaConstantExpression)expr).Value));
                using(StreamReader __tmp40Reader = new StreamReader(this.__ToStream(__tmp40.ToString())))
                {
                    bool __tmp40_first = true;
                    bool __tmp40_last = __tmp40Reader.EndOfStream;
                    while(__tmp40_first || !__tmp40_last)
                    {
                        __tmp40_first = false;
                        string __tmp40Line = __tmp40Reader.ReadLine();
                        __tmp40_last = __tmp40Reader.EndOfStream;
                        if (__tmp40Line != null) __out.Append(__tmp40Line);
                        if (!__tmp40_last) __out.AppendLine(true);
                    }
                }
            }
            else if (expr is MetaIdentifierExpression) //268:2
            {
                StringBuilder __tmp43 = new StringBuilder();
                __tmp43.Append(GenerateIdentifierExpression(((MetaIdentifierExpression)expr)));
                using(StreamReader __tmp43Reader = new StreamReader(this.__ToStream(__tmp43.ToString())))
                {
                    bool __tmp43_first = true;
                    bool __tmp43_last = __tmp43Reader.EndOfStream;
                    while(__tmp43_first || !__tmp43_last)
                    {
                        __tmp43_first = false;
                        string __tmp43Line = __tmp43Reader.ReadLine();
                        __tmp43_last = __tmp43Reader.EndOfStream;
                        if (__tmp43Line != null) __out.Append(__tmp43Line);
                        if (!__tmp43_last) __out.AppendLine(true);
                    }
                }
            }
            else if (expr is MetaMemberAccessExpression) //269:2
            {
                StringBuilder __tmp46 = new StringBuilder();
                __tmp46.Append(GenerateExpression(((MetaMemberAccessExpression)expr).Expression));
                using(StreamReader __tmp46Reader = new StreamReader(this.__ToStream(__tmp46.ToString())))
                {
                    bool __tmp46_first = true;
                    bool __tmp46_last = __tmp46Reader.EndOfStream;
                    while(__tmp46_first || !__tmp46_last)
                    {
                        __tmp46_first = false;
                        string __tmp46Line = __tmp46Reader.ReadLine();
                        __tmp46_last = __tmp46Reader.EndOfStream;
                        if (__tmp46Line != null) __out.Append(__tmp46Line);
                        if (!__tmp46_last) __out.AppendLine(true);
                    }
                }
                string __tmp47Line = "."; //269:75
                if (__tmp47Line != null) __out.Append(__tmp47Line);
                StringBuilder __tmp48 = new StringBuilder();
                __tmp48.Append(((MetaMemberAccessExpression)expr).Name);
                using(StreamReader __tmp48Reader = new StreamReader(this.__ToStream(__tmp48.ToString())))
                {
                    bool __tmp48_first = true;
                    bool __tmp48_last = __tmp48Reader.EndOfStream;
                    while(__tmp48_first || !__tmp48_last)
                    {
                        __tmp48_first = false;
                        string __tmp48Line = __tmp48Reader.ReadLine();
                        __tmp48_last = __tmp48Reader.EndOfStream;
                        if (__tmp48Line != null) __out.Append(__tmp48Line);
                        if (!__tmp48_last) __out.AppendLine(true);
                    }
                }
            }
            else if (expr is MetaFunctionCallExpression) //270:2
            {
                StringBuilder __tmp51 = new StringBuilder();
                __tmp51.Append(GenerateFunctionCall(((MetaFunctionCallExpression)expr)));
                using(StreamReader __tmp51Reader = new StreamReader(this.__ToStream(__tmp51.ToString())))
                {
                    bool __tmp51_first = true;
                    bool __tmp51_last = __tmp51Reader.EndOfStream;
                    while(__tmp51_first || !__tmp51_last)
                    {
                        __tmp51_first = false;
                        string __tmp51Line = __tmp51Reader.ReadLine();
                        __tmp51_last = __tmp51Reader.EndOfStream;
                        if (__tmp51Line != null) __out.Append(__tmp51Line);
                        if (!__tmp51_last) __out.AppendLine(true);
                    }
                }
            }
            else if (expr is MetaIndexerExpression) //271:2
            {
                StringBuilder __tmp54 = new StringBuilder();
                __tmp54.Append(GenerateIndexerCall(((MetaIndexerExpression)expr)));
                using(StreamReader __tmp54Reader = new StreamReader(this.__ToStream(__tmp54.ToString())))
                {
                    bool __tmp54_first = true;
                    bool __tmp54_last = __tmp54Reader.EndOfStream;
                    while(__tmp54_first || !__tmp54_last)
                    {
                        __tmp54_first = false;
                        string __tmp54Line = __tmp54Reader.ReadLine();
                        __tmp54_last = __tmp54Reader.EndOfStream;
                        if (__tmp54Line != null) __out.Append(__tmp54Line);
                        if (!__tmp54_last) __out.AppendLine(true);
                    }
                }
            }
            else if (expr is MetaOperatorExpression) //272:2
            {
                StringBuilder __tmp57 = new StringBuilder();
                __tmp57.Append(GenerateOperator(((MetaOperatorExpression)expr)));
                using(StreamReader __tmp57Reader = new StreamReader(this.__ToStream(__tmp57.ToString())))
                {
                    bool __tmp57_first = true;
                    bool __tmp57_last = __tmp57Reader.EndOfStream;
                    while(__tmp57_first || !__tmp57_last)
                    {
                        __tmp57_first = false;
                        string __tmp57Line = __tmp57Reader.ReadLine();
                        __tmp57_last = __tmp57Reader.EndOfStream;
                        if (__tmp57Line != null) __out.Append(__tmp57Line);
                        if (!__tmp57_last) __out.AppendLine(true);
                    }
                }
            }
            else if (expr is MetaNewExpression) //273:2
            {
                StringBuilder __tmp60 = new StringBuilder();
                __tmp60.Append(((MetaNewExpression)expr).TypeReference.CSharpFullFactoryMethodName());
                using(StreamReader __tmp60Reader = new StreamReader(this.__ToStream(__tmp60.ToString())))
                {
                    bool __tmp60_first = true;
                    bool __tmp60_last = __tmp60Reader.EndOfStream;
                    while(__tmp60_first || !__tmp60_last)
                    {
                        __tmp60_first = false;
                        string __tmp60Line = __tmp60Reader.ReadLine();
                        __tmp60_last = __tmp60Reader.EndOfStream;
                        if (__tmp60Line != null) __out.Append(__tmp60Line);
                        if (!__tmp60_last) __out.AppendLine(true);
                    }
                }
                string __tmp61Line = "("; //273:79
                if (__tmp61Line != null) __out.Append(__tmp61Line);
                StringBuilder __tmp62 = new StringBuilder();
                __tmp62.Append(GenerateNewPropertyInitializers(((MetaNewExpression)expr)));
                using(StreamReader __tmp62Reader = new StreamReader(this.__ToStream(__tmp62.ToString())))
                {
                    bool __tmp62_first = true;
                    bool __tmp62_last = __tmp62Reader.EndOfStream;
                    while(__tmp62_first || !__tmp62_last)
                    {
                        __tmp62_first = false;
                        string __tmp62Line = __tmp62Reader.ReadLine();
                        __tmp62_last = __tmp62Reader.EndOfStream;
                        if (__tmp62Line != null) __out.Append(__tmp62Line);
                        if (!__tmp62_last) __out.AppendLine(true);
                    }
                }
                string __tmp63Line = ")"; //273:119
                if (__tmp63Line != null) __out.Append(__tmp63Line);
            }
            else if (expr is MetaNewCollectionExpression) //274:2
            {
                string __tmp66Line = "new List<Lazy<object>>() { "; //274:39
                if (__tmp66Line != null) __out.Append(__tmp66Line);
                StringBuilder __tmp67 = new StringBuilder();
                __tmp67.Append(GenerateNewCollectionValues(((MetaNewCollectionExpression)expr)));
                using(StreamReader __tmp67Reader = new StreamReader(this.__ToStream(__tmp67.ToString())))
                {
                    bool __tmp67_first = true;
                    bool __tmp67_last = __tmp67Reader.EndOfStream;
                    while(__tmp67_first || !__tmp67_last)
                    {
                        __tmp67_first = false;
                        string __tmp67Line = __tmp67Reader.ReadLine();
                        __tmp67_last = __tmp67Reader.EndOfStream;
                        if (__tmp67Line != null) __out.Append(__tmp67Line);
                        if (!__tmp67_last) __out.AppendLine(true);
                    }
                }
                string __tmp68Line = " }"; //274:101
                if (__tmp68Line != null) __out.Append(__tmp68Line);
            }
            else //275:2
            {
                __out.Append("***unknown expression type***"); //275:11
                __out.AppendLine(false); //275:40
            }//276:2
            return __out.ToString();
        }

        public string GenerateIdentifierExpression(MetaIdentifierExpression expr) //279:1
        {
            StringBuilder __out = new StringBuilder();
            if (expr.Definition is MetaProperty) //280:2
            {
                string __tmp2Line = "(("; //281:1
                if (__tmp2Line != null) __out.Append(__tmp2Line);
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(((MetaType)ModelCompilerContext.Current.ResolutionProvider.GetCurrentTypeScopeOf((ModelObject)expr)).CSharpName());
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_first = true;
                    bool __tmp3_last = __tmp3Reader.EndOfStream;
                    while(__tmp3_first || !__tmp3_last)
                    {
                        __tmp3_first = false;
                        string __tmp3Line = __tmp3Reader.ReadLine();
                        __tmp3_last = __tmp3Reader.EndOfStream;
                        if (__tmp3Line != null) __out.Append(__tmp3Line);
                        if (!__tmp3_last) __out.AppendLine(true);
                    }
                }
                string __tmp4Line = ")this)."; //281:118
                if (__tmp4Line != null) __out.Append(__tmp4Line);
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(expr.Name);
                using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                {
                    bool __tmp5_first = true;
                    bool __tmp5_last = __tmp5Reader.EndOfStream;
                    while(__tmp5_first || !__tmp5_last)
                    {
                        __tmp5_first = false;
                        string __tmp5Line = __tmp5Reader.ReadLine();
                        __tmp5_last = __tmp5Reader.EndOfStream;
                        if (__tmp5Line != null) __out.Append(__tmp5Line);
                        if (!__tmp5_last) __out.AppendLine(true);
                    }
                }
            }
            else //282:2
            {
                StringBuilder __tmp7 = new StringBuilder();
                __tmp7.Append(expr.Name);
                using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
                {
                    bool __tmp7_first = true;
                    bool __tmp7_last = __tmp7Reader.EndOfStream;
                    while(__tmp7_first || !__tmp7_last)
                    {
                        __tmp7_first = false;
                        string __tmp7Line = __tmp7Reader.ReadLine();
                        __tmp7_last = __tmp7Reader.EndOfStream;
                        if (__tmp7Line != null) __out.Append(__tmp7Line);
                        if (!__tmp7_last) __out.AppendLine(true);
                    }
                }
            }
            return __out.ToString();
        }

        public bool SameFunction(MetaGlobalFunction mfunc1, MetaGlobalFunction mfunc2) //287:1
        {
            return mfunc1.Name == mfunc2.Name && ModelCompilerContext.Current.TypeProvider.Equals((ModelObject)mfunc1.Type, (ModelObject)mfunc2.Type); //288:2
        }

        public string GenerateFunctionCall(MetaFunctionCallExpression call) //291:1
        {
            StringBuilder __out = new StringBuilder();
            if (call.Definition is MetaGlobalFunction && SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.TypeOf)) //292:2
            {
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(GenerateTypeOf(call.Arguments[0]));
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_first = true;
                    bool __tmp3_last = __tmp3Reader.EndOfStream;
                    while(__tmp3_first || !__tmp3_last)
                    {
                        __tmp3_first = false;
                        string __tmp3Line = __tmp3Reader.ReadLine();
                        __tmp3_last = __tmp3Reader.EndOfStream;
                        if (__tmp3Line != null) __out.Append(__tmp3Line);
                        if (!__tmp3_last) __out.AppendLine(true);
                    }
                }
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.GetValueType)) //293:2
            {
                string __tmp6Line = "ModelCompilerContext.Current.TypeProvider.GetTypeOf("; //293:89
                if (__tmp6Line != null) __out.Append(__tmp6Line);
                StringBuilder __tmp7 = new StringBuilder();
                __tmp7.Append(GenerateCallArguments(call, ""));
                using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
                {
                    bool __tmp7_first = true;
                    bool __tmp7_last = __tmp7Reader.EndOfStream;
                    while(__tmp7_first || !__tmp7_last)
                    {
                        __tmp7_first = false;
                        string __tmp7Line = __tmp7Reader.ReadLine();
                        __tmp7_last = __tmp7Reader.EndOfStream;
                        if (__tmp7Line != null) __out.Append(__tmp7Line);
                        if (!__tmp7_last) __out.AppendLine(true);
                    }
                }
                string __tmp8Line = ")"; //293:174
                if (__tmp8Line != null) __out.Append(__tmp8Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.GetReturnType)) //294:2
            {
                string __tmp11Line = "ModelCompilerContext.Current.TypeProvider.GetReturnTypeOf("; //294:90
                if (__tmp11Line != null) __out.Append(__tmp11Line);
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(GenerateCallArguments(call, "(ModelObject)"));
                using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
                {
                    bool __tmp12_first = true;
                    bool __tmp12_last = __tmp12Reader.EndOfStream;
                    while(__tmp12_first || !__tmp12_last)
                    {
                        __tmp12_first = false;
                        string __tmp12Line = __tmp12Reader.ReadLine();
                        __tmp12_last = __tmp12Reader.EndOfStream;
                        if (__tmp12Line != null) __out.Append(__tmp12Line);
                        if (!__tmp12_last) __out.AppendLine(true);
                    }
                }
                string __tmp13Line = ")"; //294:194
                if (__tmp13Line != null) __out.Append(__tmp13Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.CurrentType)) //295:2
            {
                string __tmp16Line = "ModelCompilerContext.Current.ResolutionProvider.GetCurrentTypeScopeOf("; //295:88
                if (__tmp16Line != null) __out.Append(__tmp16Line);
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(GenerateCallArguments(call, "(ModelObject)"));
                using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
                {
                    bool __tmp17_first = true;
                    bool __tmp17_last = __tmp17Reader.EndOfStream;
                    while(__tmp17_first || !__tmp17_last)
                    {
                        __tmp17_first = false;
                        string __tmp17Line = __tmp17Reader.ReadLine();
                        __tmp17_last = __tmp17Reader.EndOfStream;
                        if (__tmp17Line != null) __out.Append(__tmp17Line);
                        if (!__tmp17_last) __out.AppendLine(true);
                    }
                }
                string __tmp18Line = ")"; //295:204
                if (__tmp18Line != null) __out.Append(__tmp18Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.TypeCheck)) //296:2
            {
                string __tmp21Line = "ModelCompilerContext.Current.TypeProvider.TypeCheck("; //296:86
                if (__tmp21Line != null) __out.Append(__tmp21Line);
                StringBuilder __tmp22 = new StringBuilder();
                __tmp22.Append(GenerateCallArguments(call, "(ModelObject)"));
                using(StreamReader __tmp22Reader = new StreamReader(this.__ToStream(__tmp22.ToString())))
                {
                    bool __tmp22_first = true;
                    bool __tmp22_last = __tmp22Reader.EndOfStream;
                    while(__tmp22_first || !__tmp22_last)
                    {
                        __tmp22_first = false;
                        string __tmp22Line = __tmp22Reader.ReadLine();
                        __tmp22_last = __tmp22Reader.EndOfStream;
                        if (__tmp22Line != null) __out.Append(__tmp22Line);
                        if (!__tmp22_last) __out.AppendLine(true);
                    }
                }
                string __tmp23Line = ")"; //296:184
                if (__tmp23Line != null) __out.Append(__tmp23Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Balance)) //297:2
            {
                string __tmp26Line = "ModelCompilerContext.Current.TypeProvider.Balance("; //297:84
                if (__tmp26Line != null) __out.Append(__tmp26Line);
                StringBuilder __tmp27 = new StringBuilder();
                __tmp27.Append(GenerateCallArguments(call, "(ModelObject)"));
                using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
                {
                    bool __tmp27_first = true;
                    bool __tmp27_last = __tmp27Reader.EndOfStream;
                    while(__tmp27_first || !__tmp27_last)
                    {
                        __tmp27_first = false;
                        string __tmp27Line = __tmp27Reader.ReadLine();
                        __tmp27_last = __tmp27Reader.EndOfStream;
                        if (__tmp27Line != null) __out.Append(__tmp27Line);
                        if (!__tmp27_last) __out.AppendLine(true);
                    }
                }
                string __tmp28Line = ")"; //297:180
                if (__tmp28Line != null) __out.Append(__tmp28Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Resolve1)) //298:2
            {
                string __tmp31Line = "ModelCompilerContext.Current.ResolutionProvider.Resolve(new MetaDslx.Core.ResolutionInfo(ModelCompilerContext.Current.ResolutionProvider.GetCurrentScope(this), ResolveKind.NameOrType, "; //298:85
                if (__tmp31Line != null) __out.Append(__tmp31Line);
                StringBuilder __tmp32 = new StringBuilder();
                __tmp32.Append(GenerateExpression(call.Arguments[0]));
                using(StreamReader __tmp32Reader = new StreamReader(this.__ToStream(__tmp32.ToString())))
                {
                    bool __tmp32_first = true;
                    bool __tmp32_last = __tmp32Reader.EndOfStream;
                    while(__tmp32_first || !__tmp32_last)
                    {
                        __tmp32_first = false;
                        string __tmp32Line = __tmp32Reader.ReadLine();
                        __tmp32_last = __tmp32Reader.EndOfStream;
                        if (__tmp32Line != null) __out.Append(__tmp32Line);
                        if (!__tmp32_last) __out.AppendLine(true);
                    }
                }
                string __tmp33Line = "))"; //298:308
                if (__tmp33Line != null) __out.Append(__tmp33Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Resolve2)) //299:2
            {
                string __tmp36Line = "ModelCompilerContext.Current.ResolutionProvider.Resolve(new MetaDslx.Core.ResolutionInfo((ModelObject)"; //299:85
                if (__tmp36Line != null) __out.Append(__tmp36Line);
                StringBuilder __tmp37 = new StringBuilder();
                __tmp37.Append(GenerateExpression(call.Arguments[0]));
                using(StreamReader __tmp37Reader = new StreamReader(this.__ToStream(__tmp37.ToString())))
                {
                    bool __tmp37_first = true;
                    bool __tmp37_last = __tmp37Reader.EndOfStream;
                    while(__tmp37_first || !__tmp37_last)
                    {
                        __tmp37_first = false;
                        string __tmp37Line = __tmp37Reader.ReadLine();
                        __tmp37_last = __tmp37Reader.EndOfStream;
                        if (__tmp37Line != null) __out.Append(__tmp37Line);
                        if (!__tmp37_last) __out.AppendLine(true);
                    }
                }
                string __tmp38Line = ", ResolveKind.NameOrType, "; //299:226
                if (__tmp38Line != null) __out.Append(__tmp38Line);
                StringBuilder __tmp39 = new StringBuilder();
                __tmp39.Append(GenerateExpression(call.Arguments[1]));
                using(StreamReader __tmp39Reader = new StreamReader(this.__ToStream(__tmp39.ToString())))
                {
                    bool __tmp39_first = true;
                    bool __tmp39_last = __tmp39Reader.EndOfStream;
                    while(__tmp39_first || !__tmp39_last)
                    {
                        __tmp39_first = false;
                        string __tmp39Line = __tmp39Reader.ReadLine();
                        __tmp39_last = __tmp39Reader.EndOfStream;
                        if (__tmp39Line != null) __out.Append(__tmp39Line);
                        if (!__tmp39_last) __out.AppendLine(true);
                    }
                }
                string __tmp40Line = "))"; //299:291
                if (__tmp40Line != null) __out.Append(__tmp40Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveType1)) //300:2
            {
                string __tmp43Line = "ModelCompilerContext.Current.ResolutionProvider.Resolve(new MetaDslx.Core.ResolutionInfo(ModelCompilerContext.Current.ResolutionProvider.GetCurrentScope(this), ResolveKind.Type, "; //300:89
                if (__tmp43Line != null) __out.Append(__tmp43Line);
                StringBuilder __tmp44 = new StringBuilder();
                __tmp44.Append(GenerateExpression(call.Arguments[0]));
                using(StreamReader __tmp44Reader = new StreamReader(this.__ToStream(__tmp44.ToString())))
                {
                    bool __tmp44_first = true;
                    bool __tmp44_last = __tmp44Reader.EndOfStream;
                    while(__tmp44_first || !__tmp44_last)
                    {
                        __tmp44_first = false;
                        string __tmp44Line = __tmp44Reader.ReadLine();
                        __tmp44_last = __tmp44Reader.EndOfStream;
                        if (__tmp44Line != null) __out.Append(__tmp44Line);
                        if (!__tmp44_last) __out.AppendLine(true);
                    }
                }
                string __tmp45Line = "))"; //300:306
                if (__tmp45Line != null) __out.Append(__tmp45Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveType2)) //301:2
            {
                string __tmp48Line = "ModelCompilerContext.Current.ResolutionProvider.Resolve(new MetaDslx.Core.ResolutionInfo((ModelObject)"; //301:89
                if (__tmp48Line != null) __out.Append(__tmp48Line);
                StringBuilder __tmp49 = new StringBuilder();
                __tmp49.Append(GenerateExpression(call.Arguments[0]));
                using(StreamReader __tmp49Reader = new StreamReader(this.__ToStream(__tmp49.ToString())))
                {
                    bool __tmp49_first = true;
                    bool __tmp49_last = __tmp49Reader.EndOfStream;
                    while(__tmp49_first || !__tmp49_last)
                    {
                        __tmp49_first = false;
                        string __tmp49Line = __tmp49Reader.ReadLine();
                        __tmp49_last = __tmp49Reader.EndOfStream;
                        if (__tmp49Line != null) __out.Append(__tmp49Line);
                        if (!__tmp49_last) __out.AppendLine(true);
                    }
                }
                string __tmp50Line = ", ResolveKind.Type, "; //301:230
                if (__tmp50Line != null) __out.Append(__tmp50Line);
                StringBuilder __tmp51 = new StringBuilder();
                __tmp51.Append(GenerateExpression(call.Arguments[1]));
                using(StreamReader __tmp51Reader = new StreamReader(this.__ToStream(__tmp51.ToString())))
                {
                    bool __tmp51_first = true;
                    bool __tmp51_last = __tmp51Reader.EndOfStream;
                    while(__tmp51_first || !__tmp51_last)
                    {
                        __tmp51_first = false;
                        string __tmp51Line = __tmp51Reader.ReadLine();
                        __tmp51_last = __tmp51Reader.EndOfStream;
                        if (__tmp51Line != null) __out.Append(__tmp51Line);
                        if (!__tmp51_last) __out.AppendLine(true);
                    }
                }
                string __tmp52Line = "))"; //301:289
                if (__tmp52Line != null) __out.Append(__tmp52Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveName1)) //302:2
            {
                string __tmp55Line = "ModelCompilerContext.Current.ResolutionProvider.Resolve(new MetaDslx.Core.ResolutionInfo(ModelCompilerContext.Current.ResolutionProvider.GetCurrentScope(this), ResolveKind.Name, "; //302:89
                if (__tmp55Line != null) __out.Append(__tmp55Line);
                StringBuilder __tmp56 = new StringBuilder();
                __tmp56.Append(GenerateExpression(call.Arguments[0]));
                using(StreamReader __tmp56Reader = new StreamReader(this.__ToStream(__tmp56.ToString())))
                {
                    bool __tmp56_first = true;
                    bool __tmp56_last = __tmp56Reader.EndOfStream;
                    while(__tmp56_first || !__tmp56_last)
                    {
                        __tmp56_first = false;
                        string __tmp56Line = __tmp56Reader.ReadLine();
                        __tmp56_last = __tmp56Reader.EndOfStream;
                        if (__tmp56Line != null) __out.Append(__tmp56Line);
                        if (!__tmp56_last) __out.AppendLine(true);
                    }
                }
                string __tmp57Line = "))"; //302:306
                if (__tmp57Line != null) __out.Append(__tmp57Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ResolveName2)) //303:2
            {
                string __tmp60Line = "ModelCompilerContext.Current.ResolutionProvider.Resolve(new MetaDslx.Core.ResolutionInfo((ModelObject)"; //303:89
                if (__tmp60Line != null) __out.Append(__tmp60Line);
                StringBuilder __tmp61 = new StringBuilder();
                __tmp61.Append(GenerateExpression(call.Arguments[0]));
                using(StreamReader __tmp61Reader = new StreamReader(this.__ToStream(__tmp61.ToString())))
                {
                    bool __tmp61_first = true;
                    bool __tmp61_last = __tmp61Reader.EndOfStream;
                    while(__tmp61_first || !__tmp61_last)
                    {
                        __tmp61_first = false;
                        string __tmp61Line = __tmp61Reader.ReadLine();
                        __tmp61_last = __tmp61Reader.EndOfStream;
                        if (__tmp61Line != null) __out.Append(__tmp61Line);
                        if (!__tmp61_last) __out.AppendLine(true);
                    }
                }
                string __tmp62Line = ", ResolveKind.Name, "; //303:230
                if (__tmp62Line != null) __out.Append(__tmp62Line);
                StringBuilder __tmp63 = new StringBuilder();
                __tmp63.Append(GenerateExpression(call.Arguments[1]));
                using(StreamReader __tmp63Reader = new StreamReader(this.__ToStream(__tmp63.ToString())))
                {
                    bool __tmp63_first = true;
                    bool __tmp63_last = __tmp63Reader.EndOfStream;
                    while(__tmp63_first || !__tmp63_last)
                    {
                        __tmp63_first = false;
                        string __tmp63Line = __tmp63Reader.ReadLine();
                        __tmp63_last = __tmp63Reader.EndOfStream;
                        if (__tmp63Line != null) __out.Append(__tmp63Line);
                        if (!__tmp63_last) __out.AppendLine(true);
                    }
                }
                string __tmp64Line = "))"; //303:289
                if (__tmp64Line != null) __out.Append(__tmp64Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.ToDefinitionList)) //304:2
            {
                string __tmp67Line = "MetaDslx.Core.BindingInfo.CreateFromDefinitions((ModelObject)"; //304:93
                if (__tmp67Line != null) __out.Append(__tmp67Line);
                StringBuilder __tmp68 = new StringBuilder();
                __tmp68.Append(GenerateExpression(call.Arguments[0]));
                using(StreamReader __tmp68Reader = new StreamReader(this.__ToStream(__tmp68.ToString())))
                {
                    bool __tmp68_first = true;
                    bool __tmp68_last = __tmp68Reader.EndOfStream;
                    while(__tmp68_first || !__tmp68_last)
                    {
                        __tmp68_first = false;
                        string __tmp68Line = __tmp68Reader.ReadLine();
                        __tmp68_last = __tmp68Reader.EndOfStream;
                        if (__tmp68Line != null) __out.Append(__tmp68Line);
                        if (!__tmp68_last) __out.AppendLine(true);
                    }
                }
                string __tmp69Line = ")"; //304:193
                if (__tmp69Line != null) __out.Append(__tmp69Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind1)) //305:2
            {
                string __tmp72Line = "ModelCompilerContext.Current.BindingProvider.Bind(null, "; //305:82
                if (__tmp72Line != null) __out.Append(__tmp72Line);
                StringBuilder __tmp73 = new StringBuilder();
                __tmp73.Append(GenerateExpression(call.Arguments[0]));
                using(StreamReader __tmp73Reader = new StreamReader(this.__ToStream(__tmp73.ToString())))
                {
                    bool __tmp73_first = true;
                    bool __tmp73_last = __tmp73Reader.EndOfStream;
                    while(__tmp73_first || !__tmp73_last)
                    {
                        __tmp73_first = false;
                        string __tmp73Line = __tmp73Reader.ReadLine();
                        __tmp73_last = __tmp73Reader.EndOfStream;
                        if (__tmp73Line != null) __out.Append(__tmp73Line);
                        if (!__tmp73_last) __out.AppendLine(true);
                    }
                }
                string __tmp74Line = ")"; //305:177
                if (__tmp74Line != null) __out.Append(__tmp74Line);
            }
            else if (SameFunction((MetaGlobalFunction)call.Definition, MetaInstance.Bind2)) //306:2
            {
                string __tmp77Line = "ModelCompilerContext.Current.BindingProvider.Bind((ModelObject)"; //306:82
                if (__tmp77Line != null) __out.Append(__tmp77Line);
                StringBuilder __tmp78 = new StringBuilder();
                __tmp78.Append(GenerateExpression(call.Arguments[0]));
                using(StreamReader __tmp78Reader = new StreamReader(this.__ToStream(__tmp78.ToString())))
                {
                    bool __tmp78_first = true;
                    bool __tmp78_last = __tmp78Reader.EndOfStream;
                    while(__tmp78_first || !__tmp78_last)
                    {
                        __tmp78_first = false;
                        string __tmp78Line = __tmp78Reader.ReadLine();
                        __tmp78_last = __tmp78Reader.EndOfStream;
                        if (__tmp78Line != null) __out.Append(__tmp78Line);
                        if (!__tmp78_last) __out.AppendLine(true);
                    }
                }
                string __tmp79Line = ", "; //306:184
                if (__tmp79Line != null) __out.Append(__tmp79Line);
                StringBuilder __tmp80 = new StringBuilder();
                __tmp80.Append(GenerateExpression(call.Arguments[1]));
                using(StreamReader __tmp80Reader = new StreamReader(this.__ToStream(__tmp80.ToString())))
                {
                    bool __tmp80_first = true;
                    bool __tmp80_last = __tmp80Reader.EndOfStream;
                    while(__tmp80_first || !__tmp80_last)
                    {
                        __tmp80_first = false;
                        string __tmp80Line = __tmp80Reader.ReadLine();
                        __tmp80_last = __tmp80Reader.EndOfStream;
                        if (__tmp80Line != null) __out.Append(__tmp80Line);
                        if (!__tmp80_last) __out.AppendLine(true);
                    }
                }
                string __tmp81Line = ")"; //306:225
                if (__tmp81Line != null) __out.Append(__tmp81Line);
            }
            else //307:2
            {
                StringBuilder __tmp84 = new StringBuilder();
                __tmp84.Append(GenerateExpression(call.Expression));
                using(StreamReader __tmp84Reader = new StreamReader(this.__ToStream(__tmp84.ToString())))
                {
                    bool __tmp84_first = true;
                    bool __tmp84_last = __tmp84Reader.EndOfStream;
                    while(__tmp84_first || !__tmp84_last)
                    {
                        __tmp84_first = false;
                        string __tmp84Line = __tmp84Reader.ReadLine();
                        __tmp84_last = __tmp84Reader.EndOfStream;
                        if (__tmp84Line != null) __out.Append(__tmp84Line);
                        if (!__tmp84_last) __out.AppendLine(true);
                    }
                }
                string __tmp85Line = "("; //307:44
                if (__tmp85Line != null) __out.Append(__tmp85Line);
                StringBuilder __tmp86 = new StringBuilder();
                __tmp86.Append(GenerateCallArguments(call, ""));
                using(StreamReader __tmp86Reader = new StreamReader(this.__ToStream(__tmp86.ToString())))
                {
                    bool __tmp86_first = true;
                    bool __tmp86_last = __tmp86Reader.EndOfStream;
                    while(__tmp86_first || !__tmp86_last)
                    {
                        __tmp86_first = false;
                        string __tmp86Line = __tmp86Reader.ReadLine();
                        __tmp86_last = __tmp86Reader.EndOfStream;
                        if (__tmp86Line != null) __out.Append(__tmp86Line);
                        if (!__tmp86_last) __out.AppendLine(true);
                    }
                }
                string __tmp87Line = ")"; //307:78
                if (__tmp87Line != null) __out.Append(__tmp87Line);
            }
            return __out.ToString();
        }

        public string GenerateIndexerCall(MetaIndexerExpression call) //311:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(GenerateExpression(call.Expression));
            using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
            {
                bool __tmp2_first = true;
                bool __tmp2_last = __tmp2Reader.EndOfStream;
                while(__tmp2_first || !__tmp2_last)
                {
                    __tmp2_first = false;
                    string __tmp2Line = __tmp2Reader.ReadLine();
                    __tmp2_last = __tmp2Reader.EndOfStream;
                    if (__tmp2Line != null) __out.Append(__tmp2Line);
                    if (!__tmp2_last) __out.AppendLine(true);
                }
            }
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append("[");
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(__tmp3_first || !__tmp3_last)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    if (!__tmp3_last) __out.AppendLine(true);
                }
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(GenerateCallArguments(call, ""));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_first = true;
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(__tmp4_first || !__tmp4_last)
                {
                    __tmp4_first = false;
                    string __tmp4Line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (__tmp4Line != null) __out.Append(__tmp4Line);
                    if (!__tmp4_last) __out.AppendLine(true);
                }
            }
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append("]");
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_first = true;
                bool __tmp5_last = __tmp5Reader.EndOfStream;
                while(__tmp5_first || !__tmp5_last)
                {
                    __tmp5_first = false;
                    string __tmp5Line = __tmp5Reader.ReadLine();
                    __tmp5_last = __tmp5Reader.EndOfStream;
                    if (__tmp5Line != null) __out.Append(__tmp5Line);
                    if (!__tmp5_last) __out.AppendLine(true);
                }
            }
            return __out.ToString();
        }

        public string GenerateTypeOf(object expr) //315:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //316:9
            if (expr is MetaPrimitiveType) //317:2
            {
                var __tmp2 = ((MetaPrimitiveType)expr).Name; //318:10
                __out.Append("	"); //319:1
                if (__tmp2 == "*none*") //319:3
                {
                    __out.Append("MetaInstance.None"); //319:18
                    __out.Append("	"); //320:1
                }
                else if (__tmp2 == "*error*") //320:3
                {
                    __out.Append("MetaInstance.Error"); //320:19
                    __out.Append("	"); //321:1
                }
                else if (__tmp2 == "*any*") //321:3
                {
                    __out.Append("MetaInstance.Any"); //321:17
                    __out.Append("	"); //322:1
                }
                else if (__tmp2 == "object") //322:3
                {
                    __out.Append("MetaInstance.Object"); //322:18
                    __out.Append("	"); //323:1
                }
                else if (__tmp2 == "string") //323:3
                {
                    __out.Append("MetaInstance.String"); //323:18
                    __out.Append("	"); //324:1
                }
                else if (__tmp2 == "int") //324:3
                {
                    __out.Append("MetaInstance.Int"); //324:15
                    __out.Append("	"); //325:1
                }
                else if (__tmp2 == "long") //325:3
                {
                    __out.Append("MetaInstance.Long"); //325:16
                    __out.Append("	"); //326:1
                }
                else if (__tmp2 == "float") //326:3
                {
                    __out.Append("MetaInstance.Float"); //326:17
                    __out.Append("	"); //327:1
                }
                else if (__tmp2 == "double") //327:3
                {
                    __out.Append("MetaInstance.Double"); //327:18
                    __out.Append("	"); //328:1
                }
                else if (__tmp2 == "byte") //328:3
                {
                    __out.Append("MetaInstance.Byte"); //328:16
                    __out.Append("	"); //329:1
                }
                else if (__tmp2 == "bool") //329:3
                {
                    __out.Append("MetaInstance.Bool"); //329:16
                    __out.Append("	"); //330:1
                }
                else if (__tmp2 == "void") //330:3
                {
                    __out.Append("MetaInstance.Void"); //330:16
                    __out.Append("	"); //331:1
                }
                else if (__tmp2 == "ModelObject") //331:3
                {
                    __out.Append("MetaInstance.ModelObject"); //331:23
                    __out.Append("	"); //332:1
                }
                else if (__tmp2 == "DefinitionList") //332:3
                {
                    __out.Append("MetaInstance.DefinitionList"); //332:26
                    __out.Append("	"); //333:1
                }
                else if (__tmp2 == "ModelObjectList") //333:3
                {
                    __out.Append("MetaInstance.ModelObjectList"); //333:27
                    __out.Append("	"); //334:1
                }
                else //334:3
                {
                    __out.Append("***error***"); //334:12
                }//335:3
            }
            else if (expr is MetaTypeOfExpression) //336:2
            {
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(GenerateTypeOf(((MetaTypeOfExpression)expr).TypeReference));
                using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                {
                    bool __tmp5_first = true;
                    bool __tmp5_last = __tmp5Reader.EndOfStream;
                    while(__tmp5_first || !__tmp5_last)
                    {
                        __tmp5_first = false;
                        string __tmp5Line = __tmp5Reader.ReadLine();
                        __tmp5_last = __tmp5Reader.EndOfStream;
                        if (__tmp5Line != null) __out.Append(__tmp5Line);
                        if (!__tmp5_last) __out.AppendLine(true);
                    }
                }
            }
            else if (expr is MetaClass) //337:2
            {
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(((MetaClass)expr).CSharpFullDescriptorName());
                using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                {
                    bool __tmp8_first = true;
                    bool __tmp8_last = __tmp8Reader.EndOfStream;
                    while(__tmp8_first || !__tmp8_last)
                    {
                        __tmp8_first = false;
                        string __tmp8Line = __tmp8Reader.ReadLine();
                        __tmp8_last = __tmp8Reader.EndOfStream;
                        if (__tmp8Line != null) __out.Append(__tmp8Line);
                        if (!__tmp8_last) __out.AppendLine(true);
                    }
                }
                string __tmp9Line = ".MetaClass"; //337:54
                if (__tmp9Line != null) __out.Append(__tmp9Line);
            }
            else if (expr is MetaCollectionType) //338:2
            {
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(((MetaCollectionType)expr).CSharpFullName());
                using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
                {
                    bool __tmp12_first = true;
                    bool __tmp12_last = __tmp12Reader.EndOfStream;
                    while(__tmp12_first || !__tmp12_last)
                    {
                        __tmp12_first = false;
                        string __tmp12Line = __tmp12Reader.ReadLine();
                        __tmp12_last = __tmp12Reader.EndOfStream;
                        if (__tmp12Line != null) __out.Append(__tmp12Line);
                        if (!__tmp12_last) __out.AppendLine(true);
                    }
                }
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
            var __loop21_results = 
                (from __loop21_var1 in __Enumerate((call).GetEnumerator()) //344:7
                from arg in __Enumerate((__loop21_var1.Arguments).GetEnumerator()) //344:13
                select new { __loop21_var1 = __loop21_var1, arg = arg}
                ).ToList(); //344:2
            for (int __loop21_iteration = 0; __loop21_iteration < __loop21_results.Count; ++__loop21_iteration)
            {
                string delim; //344:26
                if (__loop21_iteration+1 < __loop21_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop21_results[__loop21_iteration];
                var __loop21_var1 = __tmp1.__loop21_var1;
                var arg = __tmp1.arg;
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(prefix);
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_first = true;
                    bool __tmp3_last = __tmp3Reader.EndOfStream;
                    while(__tmp3_first || !__tmp3_last)
                    {
                        __tmp3_first = false;
                        string __tmp3Line = __tmp3Reader.ReadLine();
                        __tmp3_last = __tmp3Reader.EndOfStream;
                        if (__tmp3Line != null) __out.Append(__tmp3Line);
                        if (!__tmp3_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append(GenerateExpression(arg));
                using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                {
                    bool __tmp4_first = true;
                    bool __tmp4_last = __tmp4Reader.EndOfStream;
                    while(__tmp4_first || !__tmp4_last)
                    {
                        __tmp4_first = false;
                        string __tmp4Line = __tmp4Reader.ReadLine();
                        __tmp4_last = __tmp4Reader.EndOfStream;
                        if (__tmp4Line != null) __out.Append(__tmp4Line);
                        if (!__tmp4_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(delim);
                using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                {
                    bool __tmp5_first = true;
                    bool __tmp5_last = __tmp5Reader.EndOfStream;
                    while(__tmp5_first || !__tmp5_last)
                    {
                        __tmp5_first = false;
                        string __tmp5Line = __tmp5Reader.ReadLine();
                        __tmp5_last = __tmp5Reader.EndOfStream;
                        if (__tmp5Line != null) __out.Append(__tmp5Line);
                        if (!__tmp5_last) __out.AppendLine(true);
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
                    StringBuilder __tmp3 = new StringBuilder();
                    __tmp3.Append(GenerateExpression(((MetaUnaryExpression)expr).Expression));
                    using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                    {
                        bool __tmp3_first = true;
                        bool __tmp3_last = __tmp3Reader.EndOfStream;
                        while(__tmp3_first || !__tmp3_last)
                        {
                            __tmp3_first = false;
                            string __tmp3Line = __tmp3Reader.ReadLine();
                            __tmp3_last = __tmp3Reader.EndOfStream;
                            if (__tmp3Line != null) __out.Append(__tmp3Line);
                            if (!__tmp3_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp4 = new StringBuilder();
                    __tmp4.Append(GetCSharpOperator(((MetaUnaryExpression)expr)));
                    using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                    {
                        bool __tmp4_first = true;
                        bool __tmp4_last = __tmp4Reader.EndOfStream;
                        while(__tmp4_first || !__tmp4_last)
                        {
                            __tmp4_first = false;
                            string __tmp4Line = __tmp4Reader.ReadLine();
                            __tmp4_last = __tmp4Reader.EndOfStream;
                            if (__tmp4Line != null) __out.Append(__tmp4Line);
                            if (!__tmp4_last) __out.AppendLine(true);
                        }
                    }
                }
                else //354:3
                {
                    StringBuilder __tmp6 = new StringBuilder();
                    __tmp6.Append(GetCSharpOperator(((MetaUnaryExpression)expr)));
                    using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
                    {
                        bool __tmp6_first = true;
                        bool __tmp6_last = __tmp6Reader.EndOfStream;
                        while(__tmp6_first || !__tmp6_last)
                        {
                            __tmp6_first = false;
                            string __tmp6Line = __tmp6Reader.ReadLine();
                            __tmp6_last = __tmp6Reader.EndOfStream;
                            if (__tmp6Line != null) __out.Append(__tmp6Line);
                            if (!__tmp6_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp7 = new StringBuilder();
                    __tmp7.Append(GenerateExpression(((MetaUnaryExpression)expr).Expression));
                    using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
                    {
                        bool __tmp7_first = true;
                        bool __tmp7_last = __tmp7Reader.EndOfStream;
                        while(__tmp7_first || !__tmp7_last)
                        {
                            __tmp7_first = false;
                            string __tmp7Line = __tmp7Reader.ReadLine();
                            __tmp7_last = __tmp7Reader.EndOfStream;
                            if (__tmp7Line != null) __out.Append(__tmp7Line);
                            if (!__tmp7_last) __out.AppendLine(true);
                        }
                    }
                }
            }
            else if (expr is MetaBinaryExpression) //357:2
            {
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append(GenerateExpression(((MetaBinaryExpression)expr).Left));
                using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                {
                    bool __tmp9_first = true;
                    bool __tmp9_last = __tmp9Reader.EndOfStream;
                    while(__tmp9_first || !__tmp9_last)
                    {
                        __tmp9_first = false;
                        string __tmp9Line = __tmp9Reader.ReadLine();
                        __tmp9_last = __tmp9Reader.EndOfStream;
                        if (__tmp9Line != null) __out.Append(__tmp9Line);
                        if (!__tmp9_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(GetCSharpOperator(((MetaBinaryExpression)expr)));
                using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
                {
                    bool __tmp10_first = true;
                    bool __tmp10_last = __tmp10Reader.EndOfStream;
                    while(__tmp10_first || !__tmp10_last)
                    {
                        __tmp10_first = false;
                        string __tmp10Line = __tmp10Reader.ReadLine();
                        __tmp10_last = __tmp10Reader.EndOfStream;
                        if (__tmp10Line != null) __out.Append(__tmp10Line);
                        if (!__tmp10_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(GenerateExpression(((MetaBinaryExpression)expr).Right));
                using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                {
                    bool __tmp11_first = true;
                    bool __tmp11_last = __tmp11Reader.EndOfStream;
                    while(__tmp11_first || !__tmp11_last)
                    {
                        __tmp11_first = false;
                        string __tmp11Line = __tmp11Reader.ReadLine();
                        __tmp11_last = __tmp11Reader.EndOfStream;
                        if (__tmp11Line != null) __out.Append(__tmp11Line);
                        if (!__tmp11_last) __out.AppendLine(true);
                    }
                }
            }//359:2
            return __out.ToString();
        }

        public string GenerateNewPropertyInitializers(MetaNewExpression expr) //362:1
        {
            StringBuilder __out = new StringBuilder();
            if ((from __loop22_var1 in __Enumerate((expr).GetEnumerator()) //363:14
            from pi in __Enumerate((__loop22_var1.PropertyInitializers).GetEnumerator()) //363:20
            select new { __loop22_var1 = __loop22_var1, pi = pi}
            ).GetEnumerator().MoveNext()) //363:2
            {
                __out.Append("new List<ModelPropertyInitializer>() {"); //364:1
                var __loop23_results = 
                    (from __loop23_var1 in __Enumerate((expr).GetEnumerator()) //365:7
                    from pi in __Enumerate((__loop23_var1.PropertyInitializers).GetEnumerator()) //365:13
                    select new { __loop23_var1 = __loop23_var1, pi = pi}
                    ).ToList(); //365:2
                for (int __loop23_iteration = 0; __loop23_iteration < __loop23_results.Count; ++__loop23_iteration)
                {
                    string delim; //365:36
                    if (__loop23_iteration+1 < __loop23_results.Count) delim = ", ";
                    else delim = string.Empty;
                    var __tmp1 = __loop23_results[__loop23_iteration];
                    var __loop23_var1 = __tmp1.__loop23_var1;
                    var pi = __tmp1.pi;
                    string __tmp3Line = "new ModelPropertyInitializer("; //366:1
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    StringBuilder __tmp4 = new StringBuilder();
                    __tmp4.Append(pi.Property.CSharpFullDescriptorName());
                    using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                    {
                        bool __tmp4_first = true;
                        bool __tmp4_last = __tmp4Reader.EndOfStream;
                        while(__tmp4_first || !__tmp4_last)
                        {
                            __tmp4_first = false;
                            string __tmp4Line = __tmp4Reader.ReadLine();
                            __tmp4_last = __tmp4Reader.EndOfStream;
                            if (__tmp4Line != null) __out.Append(__tmp4Line);
                            if (!__tmp4_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp5Line = ", new Lazy<object>(() => "; //366:70
                    if (__tmp5Line != null) __out.Append(__tmp5Line);
                    StringBuilder __tmp6 = new StringBuilder();
                    __tmp6.Append(GenerateExpression(pi.Value));
                    using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
                    {
                        bool __tmp6_first = true;
                        bool __tmp6_last = __tmp6Reader.EndOfStream;
                        while(__tmp6_first || !__tmp6_last)
                        {
                            __tmp6_first = false;
                            string __tmp6Line = __tmp6Reader.ReadLine();
                            __tmp6_last = __tmp6Reader.EndOfStream;
                            if (__tmp6Line != null) __out.Append(__tmp6Line);
                            if (!__tmp6_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp7Line = ", LazyThreadSafetyMode.ExecutionAndPublication))"; //366:125
                    if (__tmp7Line != null) __out.Append(__tmp7Line);
                    StringBuilder __tmp8 = new StringBuilder();
                    __tmp8.Append(delim);
                    using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                    {
                        bool __tmp8_first = true;
                        bool __tmp8_last = __tmp8Reader.EndOfStream;
                        while(__tmp8_first || !__tmp8_last)
                        {
                            __tmp8_first = false;
                            string __tmp8Line = __tmp8Reader.ReadLine();
                            __tmp8_last = __tmp8Reader.EndOfStream;
                            if (__tmp8Line != null) __out.Append(__tmp8Line);
                            if (!__tmp8_last) __out.AppendLine(true);
                        }
                    }
                }
                __out.Append("}"); //368:1
            }
            return __out.ToString();
        }

        public string GenerateNewCollectionValues(MetaNewCollectionExpression expr) //372:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((expr).GetEnumerator()) //373:7
                from v in __Enumerate((__loop24_var1.Values).GetEnumerator()) //373:13
                select new { __loop24_var1 = __loop24_var1, v = v}
                ).ToList(); //373:2
            for (int __loop24_iteration = 0; __loop24_iteration < __loop24_results.Count; ++__loop24_iteration)
            {
                string delim; //373:21
                if (__loop24_iteration+1 < __loop24_results.Count) delim = ", \n";
                else delim = string.Empty;
                var __tmp1 = __loop24_results[__loop24_iteration];
                var __loop24_var1 = __tmp1.__loop24_var1;
                var v = __tmp1.v;
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(GenerateExpression(v));
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_first = true;
                    bool __tmp3_last = __tmp3Reader.EndOfStream;
                    while(__tmp3_first || !__tmp3_last)
                    {
                        __tmp3_first = false;
                        string __tmp3Line = __tmp3Reader.ReadLine();
                        __tmp3_last = __tmp3Reader.EndOfStream;
                        if (__tmp3Line != null) __out.Append(__tmp3Line);
                        if (!__tmp3_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append(delim);
                using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                {
                    bool __tmp4_first = true;
                    bool __tmp4_last = __tmp4Reader.EndOfStream;
                    while(__tmp4_first || !__tmp4_last)
                    {
                        __tmp4_first = false;
                        string __tmp4Line = __tmp4Reader.ReadLine();
                        __tmp4_last = __tmp4Reader.EndOfStream;
                        if (__tmp4Line != null) __out.Append(__tmp4Line);
                        if (!__tmp4_last) __out.AppendLine(true);
                        __out.AppendLine(false); //374:31
                    }
                }
            }
            return __out.ToString();
        }

        public string GetCSharpValue(object value) //378:1
        {
            if (value == null) //379:2
            {
                return "null"; //379:21
            }
            else if (value is bool && ((bool)value) == true) //380:2
            {
                return "true"; //380:51
            }
            else if (value is bool && ((bool)value) == false) //381:2
            {
                return "false"; //381:52
            }
            else if (value is string) //382:2
            {
                return "\"" + value.ToString() + "\""; //382:28
            }
            else if (value is MetaExpression) //383:2
            {
                return GenerateExpression((MetaExpression)value); //383:36
            }
            else //384:2
            {
                return value.ToString(); //384:7
            }
        }

        public string GetCSharpIdentifier(object value) //388:1
        {
            if (value == null) //389:2
            {
                return null; //390:3
            }
            if (value is MetaConstantExpression && ((MetaConstantExpression)value).Value != null) //392:2
            {
                return ((MetaConstantExpression)value).Value.ToString(); //393:3
            }
            else if (value is string) //394:2
            {
                return value.ToString(); //395:3
            }
            else //396:2
            {
                return null; //397:3
            }
        }

        public string GetCSharpOperator(MetaOperatorExpression expr) //401:1
        {
            var __tmp1 = expr; //402:9
            if (expr is MetaUnaryPlusExpression) //403:3
            {
                return "+"; //403:36
            }
            else if (expr is MetaNegateExpression) //404:3
            {
                return "-"; //404:33
            }
            else if (expr is MetaOnesComplementExpression) //405:3
            {
                return "~"; //405:41
            }
            else if (expr is MetaNotExpression) //406:3
            {
                return "!"; //406:30
            }
            else if (expr is MetaPostIncrementAssignExpression) //407:3
            {
                return "++"; //407:46
            }
            else if (expr is MetaPostDecrementAssignExpression) //408:3
            {
                return "--"; //408:46
            }
            else if (expr is MetaPreIncrementAssignExpression) //409:3
            {
                return "++"; //409:45
            }
            else if (expr is MetaPreDecrementAssignExpression) //410:3
            {
                return "--"; //410:45
            }
            else if (expr is MetaMultiplyExpression) //411:3
            {
                return "*"; //411:35
            }
            else if (expr is MetaDivideExpression) //412:3
            {
                return "/"; //412:33
            }
            else if (expr is MetaModuloExpression) //413:3
            {
                return "%"; //413:33
            }
            else if (expr is MetaAddExpression) //414:3
            {
                return "+"; //414:30
            }
            else if (expr is MetaSubtractExpression) //415:3
            {
                return "-"; //415:35
            }
            else if (expr is MetaLeftShiftExpression) //416:3
            {
                return "<<"; //416:36
            }
            else if (expr is MetaRightShiftExpression) //417:3
            {
                return ">>"; //417:37
            }
            else if (expr is MetaLessThanExpression) //418:3
            {
                return "<"; //418:35
            }
            else if (expr is MetaLessThanOrEqualExpression) //419:3
            {
                return "<="; //419:42
            }
            else if (expr is MetaGreaterThanExpression) //420:3
            {
                return ">"; //420:38
            }
            else if (expr is MetaGreaterThanOrEqualExpression) //421:3
            {
                return ">="; //421:45
            }
            else if (expr is MetaEqualExpression) //422:3
            {
                return "=="; //422:32
            }
            else if (expr is MetaNotEqualExpression) //423:3
            {
                return "!="; //423:35
            }
            else if (expr is MetaAndExpression) //424:3
            {
                return "&"; //424:30
            }
            else if (expr is MetaOrExpression) //425:3
            {
                return "|"; //425:29
            }
            else if (expr is MetaExclusiveOrExpression) //426:3
            {
                return "^"; //426:38
            }
            else if (expr is MetaAndAlsoExpression) //427:3
            {
                return "&&"; //427:34
            }
            else if (expr is MetaOrElseExpression) //428:3
            {
                return "||"; //428:33
            }
            else if (expr is MetaNullCoalescingExpression) //429:3
            {
                return "??"; //429:41
            }
            else if (expr is MetaMultiplyAssignExpression) //430:3
            {
                return "*="; //430:41
            }
            else if (expr is MetaDivideAssignExpression) //431:3
            {
                return "/="; //431:39
            }
            else if (expr is MetaModuloAssignExpression) //432:3
            {
                return "%="; //432:39
            }
            else if (expr is MetaAddAssignExpression) //433:3
            {
                return "+="; //433:36
            }
            else if (expr is MetaSubtractAssignExpression) //434:3
            {
                return "-="; //434:41
            }
            else if (expr is MetaLeftShiftAssignExpression) //435:3
            {
                return "<<="; //435:42
            }
            else if (expr is MetaRightShiftAssignExpression) //436:3
            {
                return ">>="; //436:43
            }
            else if (expr is MetaAndAssignExpression) //437:3
            {
                return "&="; //437:36
            }
            else if (expr is MetaExclusiveOrAssignExpression) //438:3
            {
                return "^="; //438:44
            }
            else if (expr is MetaOrAssignExpression) //439:3
            {
                return "|="; //439:35
            }
            else //440:3
            {
                return ""; //440:12
            }//441:2
        }

        public string GetTypeName(MetaExpression expr) //444:1
        {
            if (expr is MetaTypeOfExpression) //445:2
            {
                return ((MetaTypeOfExpression)expr).TypeReference.CSharpFullName(); //445:36
            }
            else //446:2
            {
                return null; //446:7
            }
        }

        public MetaSynthetizedPropertyInitializer GetSynthetizedInitializerFor(MetaClass cls, MetaProperty prop) //450:1
        {
            MetaSynthetizedPropertyInitializer lastInit = null; //451:2
            var __loop25_results = 
                (from __loop25_var1 in __Enumerate((cls).GetEnumerator()) //452:7
                from sup in __Enumerate((__loop25_var1.GetAllSuperClasses(true)).GetEnumerator()) //452:12
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //452:42
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //452:55
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaSynthetizedPropertyInitializer>() //452:69
                select new { __loop25_var1 = __loop25_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //452:2
            for (int __loop25_iteration = 0; __loop25_iteration < __loop25_results.Count; ++__loop25_iteration)
            {
                var __tmp1 = __loop25_results[__loop25_iteration];
                var __loop25_var1 = __tmp1.__loop25_var1;
                var sup = __tmp1.sup;
                var Constructor = __tmp1.Constructor;
                var Initializers = __tmp1.Initializers;
                var init = __tmp1.init;
                if (init.Property == prop) //453:3
                {
                    lastInit = init; //454:4
                }
            }
            return lastInit; //457:2
        }

        public string GenerateConstructorImpl(MetaModel model, MetaClass cls) //460:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "public "; //461:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(cls.CSharpImplName());
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(__tmp3_first || !__tmp3_last)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    if (!__tmp3_last) __out.AppendLine(true);
                }
            }
            string __tmp4Line = "() "; //461:30
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //461:33
            __out.Append("{"); //462:1
            __out.AppendLine(false); //462:2
            var __loop26_results = 
                (from __loop26_var1 in __Enumerate((cls).GetEnumerator()) //463:8
                from prop in __Enumerate((__loop26_var1.GetAllProperties()).GetEnumerator()) //463:13
                select new { __loop26_var1 = __loop26_var1, prop = prop}
                ).ToList(); //463:3
            for (int __loop26_iteration = 0; __loop26_iteration < __loop26_results.Count; ++__loop26_iteration)
            {
                var __tmp5 = __loop26_results[__loop26_iteration];
                var __loop26_var1 = __tmp5.__loop26_var1;
                var prop = __tmp5.prop;
                MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //464:4
                if (synInit != null) //465:4
                {
                    if (prop.Kind != MetaPropertyKind.Derived) //466:5
                    {
                        if (ModelCompilerContext.Current.TypeProvider.GetTypeOf(synInit.Value) is MetaCollectionType) //467:6
                        {
                            string __tmp7Line = "    this.MLazySet("; //468:1
                            if (__tmp7Line != null) __out.Append(__tmp7Line);
                            StringBuilder __tmp8 = new StringBuilder();
                            __tmp8.Append(prop.CSharpFullDescriptorName());
                            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                            {
                                bool __tmp8_first = true;
                                bool __tmp8_last = __tmp8Reader.EndOfStream;
                                while(__tmp8_first || !__tmp8_last)
                                {
                                    __tmp8_first = false;
                                    string __tmp8Line = __tmp8Reader.ReadLine();
                                    __tmp8_last = __tmp8Reader.EndOfStream;
                                    if (__tmp8Line != null) __out.Append(__tmp8Line);
                                    if (!__tmp8_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp9Line = ", new Lazy<object>(() => "; //468:52
                            if (__tmp9Line != null) __out.Append(__tmp9Line);
                            StringBuilder __tmp10 = new StringBuilder();
                            __tmp10.Append(GenerateExpression(synInit.Value));
                            using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
                            {
                                bool __tmp10_first = true;
                                bool __tmp10_last = __tmp10Reader.EndOfStream;
                                while(__tmp10_first || !__tmp10_last)
                                {
                                    __tmp10_first = false;
                                    string __tmp10Line = __tmp10Reader.ReadLine();
                                    __tmp10_last = __tmp10Reader.EndOfStream;
                                    if (__tmp10Line != null) __out.Append(__tmp10Line);
                                    if (!__tmp10_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp11Line = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //468:112
                            if (__tmp11Line != null) __out.Append(__tmp11Line);
                            __out.AppendLine(false); //468:161
                        }
                        else //469:6
                        {
                            string __tmp13Line = "    this.MLazySet("; //470:1
                            if (__tmp13Line != null) __out.Append(__tmp13Line);
                            StringBuilder __tmp14 = new StringBuilder();
                            __tmp14.Append(prop.CSharpFullDescriptorName());
                            using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
                            {
                                bool __tmp14_first = true;
                                bool __tmp14_last = __tmp14Reader.EndOfStream;
                                while(__tmp14_first || !__tmp14_last)
                                {
                                    __tmp14_first = false;
                                    string __tmp14Line = __tmp14Reader.ReadLine();
                                    __tmp14_last = __tmp14Reader.EndOfStream;
                                    if (__tmp14Line != null) __out.Append(__tmp14Line);
                                    if (!__tmp14_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp15Line = ", new Lazy<object>(() => "; //470:52
                            if (__tmp15Line != null) __out.Append(__tmp15Line);
                            StringBuilder __tmp16 = new StringBuilder();
                            __tmp16.Append(GenerateExpression(synInit.Value));
                            using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
                            {
                                bool __tmp16_first = true;
                                bool __tmp16_last = __tmp16Reader.EndOfStream;
                                while(__tmp16_first || !__tmp16_last)
                                {
                                    __tmp16_first = false;
                                    string __tmp16Line = __tmp16Reader.ReadLine();
                                    __tmp16_last = __tmp16Reader.EndOfStream;
                                    if (__tmp16Line != null) __out.Append(__tmp16Line);
                                    if (!__tmp16_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp17Line = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //470:112
                            if (__tmp17Line != null) __out.Append(__tmp17Line);
                            __out.AppendLine(false); //470:161
                        }
                    }
                    else //472:5
                    {
                        string __tmp19Line = "    this.MDerivedSet("; //473:1
                        if (__tmp19Line != null) __out.Append(__tmp19Line);
                        StringBuilder __tmp20 = new StringBuilder();
                        __tmp20.Append(prop.CSharpFullDescriptorName());
                        using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
                        {
                            bool __tmp20_first = true;
                            bool __tmp20_last = __tmp20Reader.EndOfStream;
                            while(__tmp20_first || !__tmp20_last)
                            {
                                __tmp20_first = false;
                                string __tmp20Line = __tmp20Reader.ReadLine();
                                __tmp20_last = __tmp20Reader.EndOfStream;
                                if (__tmp20Line != null) __out.Append(__tmp20Line);
                                if (!__tmp20_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp21Line = ", () => "; //473:55
                        if (__tmp21Line != null) __out.Append(__tmp21Line);
                        StringBuilder __tmp22 = new StringBuilder();
                        __tmp22.Append(GenerateExpression(synInit.Value));
                        using(StreamReader __tmp22Reader = new StreamReader(this.__ToStream(__tmp22.ToString())))
                        {
                            bool __tmp22_first = true;
                            bool __tmp22_last = __tmp22Reader.EndOfStream;
                            while(__tmp22_first || !__tmp22_last)
                            {
                                __tmp22_first = false;
                                string __tmp22Line = __tmp22Reader.ReadLine();
                                __tmp22_last = __tmp22Reader.EndOfStream;
                                if (__tmp22Line != null) __out.Append(__tmp22Line);
                                if (!__tmp22_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp23Line = ");"; //473:98
                        if (__tmp23Line != null) __out.Append(__tmp23Line);
                        __out.AppendLine(false); //473:100
                    }
                }
                else //475:4
                {
                    if (prop.Type is MetaCollectionType) //476:5
                    {
                        if (prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) //477:6
                        {
                            string __tmp25Line = "    this.MSet("; //478:1
                            if (__tmp25Line != null) __out.Append(__tmp25Line);
                            StringBuilder __tmp26 = new StringBuilder();
                            __tmp26.Append(prop.CSharpFullDescriptorName());
                            using(StreamReader __tmp26Reader = new StreamReader(this.__ToStream(__tmp26.ToString())))
                            {
                                bool __tmp26_first = true;
                                bool __tmp26_last = __tmp26Reader.EndOfStream;
                                while(__tmp26_first || !__tmp26_last)
                                {
                                    __tmp26_first = false;
                                    string __tmp26Line = __tmp26Reader.ReadLine();
                                    __tmp26_last = __tmp26Reader.EndOfStream;
                                    if (__tmp26Line != null) __out.Append(__tmp26Line);
                                    if (!__tmp26_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp27Line = ", new "; //478:48
                            if (__tmp27Line != null) __out.Append(__tmp27Line);
                            StringBuilder __tmp28 = new StringBuilder();
                            __tmp28.Append(prop.Type.CSharpName());
                            using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
                            {
                                bool __tmp28_first = true;
                                bool __tmp28_last = __tmp28Reader.EndOfStream;
                                while(__tmp28_first || !__tmp28_last)
                                {
                                    __tmp28_first = false;
                                    string __tmp28Line = __tmp28Reader.ReadLine();
                                    __tmp28_last = __tmp28Reader.EndOfStream;
                                    if (__tmp28Line != null) __out.Append(__tmp28Line);
                                    if (!__tmp28_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp29Line = "("; //478:78
                            if (__tmp29Line != null) __out.Append(__tmp29Line);
                            StringBuilder __tmp30 = new StringBuilder();
                            __tmp30.Append(GetCollectionConstructorParams(prop));
                            using(StreamReader __tmp30Reader = new StreamReader(this.__ToStream(__tmp30.ToString())))
                            {
                                bool __tmp30_first = true;
                                bool __tmp30_last = __tmp30Reader.EndOfStream;
                                while(__tmp30_first || !__tmp30_last)
                                {
                                    __tmp30_first = false;
                                    string __tmp30Line = __tmp30Reader.ReadLine();
                                    __tmp30_last = __tmp30Reader.EndOfStream;
                                    if (__tmp30Line != null) __out.Append(__tmp30Line);
                                    if (!__tmp30_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp31Line = "));"; //478:117
                            if (__tmp31Line != null) __out.Append(__tmp31Line);
                            __out.AppendLine(false); //478:120
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //479:6
                        {
                            string __tmp33Line = "    this.MLazySet("; //480:1
                            if (__tmp33Line != null) __out.Append(__tmp33Line);
                            StringBuilder __tmp34 = new StringBuilder();
                            __tmp34.Append(prop.CSharpFullDescriptorName());
                            using(StreamReader __tmp34Reader = new StreamReader(this.__ToStream(__tmp34.ToString())))
                            {
                                bool __tmp34_first = true;
                                bool __tmp34_last = __tmp34Reader.EndOfStream;
                                while(__tmp34_first || !__tmp34_last)
                                {
                                    __tmp34_first = false;
                                    string __tmp34Line = __tmp34Reader.ReadLine();
                                    __tmp34_last = __tmp34Reader.EndOfStream;
                                    if (__tmp34Line != null) __out.Append(__tmp34Line);
                                    if (!__tmp34_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp35Line = ", new Lazy<object>(() => "; //480:52
                            if (__tmp35Line != null) __out.Append(__tmp35Line);
                            StringBuilder __tmp36 = new StringBuilder();
                            __tmp36.Append(prop.Class.Model.CSharpFullImplementationName());
                            using(StreamReader __tmp36Reader = new StreamReader(this.__ToStream(__tmp36.ToString())))
                            {
                                bool __tmp36_first = true;
                                bool __tmp36_last = __tmp36Reader.EndOfStream;
                                while(__tmp36_first || !__tmp36_last)
                                {
                                    __tmp36_first = false;
                                    string __tmp36Line = __tmp36Reader.ReadLine();
                                    __tmp36_last = __tmp36Reader.EndOfStream;
                                    if (__tmp36Line != null) __out.Append(__tmp36Line);
                                    if (!__tmp36_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp37Line = "."; //480:126
                            if (__tmp37Line != null) __out.Append(__tmp37Line);
                            StringBuilder __tmp38 = new StringBuilder();
                            __tmp38.Append(prop.Class.CSharpName());
                            using(StreamReader __tmp38Reader = new StreamReader(this.__ToStream(__tmp38.ToString())))
                            {
                                bool __tmp38_first = true;
                                bool __tmp38_last = __tmp38Reader.EndOfStream;
                                while(__tmp38_first || !__tmp38_last)
                                {
                                    __tmp38_first = false;
                                    string __tmp38Line = __tmp38Reader.ReadLine();
                                    __tmp38_last = __tmp38Reader.EndOfStream;
                                    if (__tmp38Line != null) __out.Append(__tmp38Line);
                                    if (!__tmp38_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp39Line = "_"; //480:152
                            if (__tmp39Line != null) __out.Append(__tmp39Line);
                            StringBuilder __tmp40 = new StringBuilder();
                            __tmp40.Append(prop.Name);
                            using(StreamReader __tmp40Reader = new StreamReader(this.__ToStream(__tmp40.ToString())))
                            {
                                bool __tmp40_first = true;
                                bool __tmp40_last = __tmp40Reader.EndOfStream;
                                while(__tmp40_first || !__tmp40_last)
                                {
                                    __tmp40_first = false;
                                    string __tmp40Line = __tmp40Reader.ReadLine();
                                    __tmp40_last = __tmp40Reader.EndOfStream;
                                    if (__tmp40Line != null) __out.Append(__tmp40Line);
                                    if (!__tmp40_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp41Line = "(this), LazyThreadSafetyMode.ExecutionAndPublication));"; //480:164
                            if (__tmp41Line != null) __out.Append(__tmp41Line);
                            __out.AppendLine(false); //480:219
                        }
                        else if (prop.Kind == MetaPropertyKind.Derived) //481:6
                        {
                            string __tmp43Line = "    this.MDerivedSet("; //482:1
                            if (__tmp43Line != null) __out.Append(__tmp43Line);
                            StringBuilder __tmp44 = new StringBuilder();
                            __tmp44.Append(prop.CSharpFullDescriptorName());
                            using(StreamReader __tmp44Reader = new StreamReader(this.__ToStream(__tmp44.ToString())))
                            {
                                bool __tmp44_first = true;
                                bool __tmp44_last = __tmp44Reader.EndOfStream;
                                while(__tmp44_first || !__tmp44_last)
                                {
                                    __tmp44_first = false;
                                    string __tmp44Line = __tmp44Reader.ReadLine();
                                    __tmp44_last = __tmp44Reader.EndOfStream;
                                    if (__tmp44Line != null) __out.Append(__tmp44Line);
                                    if (!__tmp44_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp45Line = ", () => "; //482:55
                            if (__tmp45Line != null) __out.Append(__tmp45Line);
                            StringBuilder __tmp46 = new StringBuilder();
                            __tmp46.Append(prop.Class.Model.CSharpFullImplementationName());
                            using(StreamReader __tmp46Reader = new StreamReader(this.__ToStream(__tmp46.ToString())))
                            {
                                bool __tmp46_first = true;
                                bool __tmp46_last = __tmp46Reader.EndOfStream;
                                while(__tmp46_first || !__tmp46_last)
                                {
                                    __tmp46_first = false;
                                    string __tmp46Line = __tmp46Reader.ReadLine();
                                    __tmp46_last = __tmp46Reader.EndOfStream;
                                    if (__tmp46Line != null) __out.Append(__tmp46Line);
                                    if (!__tmp46_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp47Line = "."; //482:112
                            if (__tmp47Line != null) __out.Append(__tmp47Line);
                            StringBuilder __tmp48 = new StringBuilder();
                            __tmp48.Append(prop.Class.CSharpName());
                            using(StreamReader __tmp48Reader = new StreamReader(this.__ToStream(__tmp48.ToString())))
                            {
                                bool __tmp48_first = true;
                                bool __tmp48_last = __tmp48Reader.EndOfStream;
                                while(__tmp48_first || !__tmp48_last)
                                {
                                    __tmp48_first = false;
                                    string __tmp48Line = __tmp48Reader.ReadLine();
                                    __tmp48_last = __tmp48Reader.EndOfStream;
                                    if (__tmp48Line != null) __out.Append(__tmp48Line);
                                    if (!__tmp48_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp49Line = "_"; //482:138
                            if (__tmp49Line != null) __out.Append(__tmp49Line);
                            StringBuilder __tmp50 = new StringBuilder();
                            __tmp50.Append(prop.Name);
                            using(StreamReader __tmp50Reader = new StreamReader(this.__ToStream(__tmp50.ToString())))
                            {
                                bool __tmp50_first = true;
                                bool __tmp50_last = __tmp50Reader.EndOfStream;
                                while(__tmp50_first || !__tmp50_last)
                                {
                                    __tmp50_first = false;
                                    string __tmp50Line = __tmp50Reader.ReadLine();
                                    __tmp50_last = __tmp50Reader.EndOfStream;
                                    if (__tmp50Line != null) __out.Append(__tmp50Line);
                                    if (!__tmp50_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp51Line = "(this));"; //482:150
                            if (__tmp51Line != null) __out.Append(__tmp51Line);
                            __out.AppendLine(false); //482:158
                        }
                        else if (prop.Kind == MetaPropertyKind.Readonly) //483:6
                        {
                            string __tmp53Line = "    // Init "; //484:1
                            if (__tmp53Line != null) __out.Append(__tmp53Line);
                            StringBuilder __tmp54 = new StringBuilder();
                            __tmp54.Append(prop.CSharpFullDescriptorName());
                            using(StreamReader __tmp54Reader = new StreamReader(this.__ToStream(__tmp54.ToString())))
                            {
                                bool __tmp54_first = true;
                                bool __tmp54_last = __tmp54Reader.EndOfStream;
                                while(__tmp54_first || !__tmp54_last)
                                {
                                    __tmp54_first = false;
                                    string __tmp54Line = __tmp54Reader.ReadLine();
                                    __tmp54_last = __tmp54Reader.EndOfStream;
                                    if (__tmp54Line != null) __out.Append(__tmp54Line);
                                    if (!__tmp54_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp55Line = " in "; //484:46
                            if (__tmp55Line != null) __out.Append(__tmp55Line);
                            StringBuilder __tmp56 = new StringBuilder();
                            __tmp56.Append(prop.Class.Model.CSharpFullImplementationName());
                            using(StreamReader __tmp56Reader = new StreamReader(this.__ToStream(__tmp56.ToString())))
                            {
                                bool __tmp56_first = true;
                                bool __tmp56_last = __tmp56Reader.EndOfStream;
                                while(__tmp56_first || !__tmp56_last)
                                {
                                    __tmp56_first = false;
                                    string __tmp56Line = __tmp56Reader.ReadLine();
                                    __tmp56_last = __tmp56Reader.EndOfStream;
                                    if (__tmp56Line != null) __out.Append(__tmp56Line);
                                    if (!__tmp56_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp57Line = "."; //484:99
                            if (__tmp57Line != null) __out.Append(__tmp57Line);
                            StringBuilder __tmp58 = new StringBuilder();
                            __tmp58.Append(cls.CSharpName());
                            using(StreamReader __tmp58Reader = new StreamReader(this.__ToStream(__tmp58.ToString())))
                            {
                                bool __tmp58_first = true;
                                bool __tmp58_last = __tmp58Reader.EndOfStream;
                                while(__tmp58_first || !__tmp58_last)
                                {
                                    __tmp58_first = false;
                                    string __tmp58Line = __tmp58Reader.ReadLine();
                                    __tmp58_last = __tmp58Reader.EndOfStream;
                                    if (__tmp58Line != null) __out.Append(__tmp58Line);
                                    if (!__tmp58_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp59Line = "_"; //484:118
                            if (__tmp59Line != null) __out.Append(__tmp59Line);
                            StringBuilder __tmp60 = new StringBuilder();
                            __tmp60.Append(cls.CSharpName());
                            using(StreamReader __tmp60Reader = new StreamReader(this.__ToStream(__tmp60.ToString())))
                            {
                                bool __tmp60_first = true;
                                bool __tmp60_last = __tmp60Reader.EndOfStream;
                                while(__tmp60_first || !__tmp60_last)
                                {
                                    __tmp60_first = false;
                                    string __tmp60Line = __tmp60Reader.ReadLine();
                                    __tmp60_last = __tmp60Reader.EndOfStream;
                                    if (__tmp60Line != null) __out.Append(__tmp60Line);
                                    if (!__tmp60_last) __out.AppendLine(true);
                                    __out.AppendLine(false); //484:137
                                }
                            }
                        }
                    }
                    else //486:5
                    {
                        if (prop.Kind == MetaPropertyKind.Lazy) //487:6
                        {
                            string __tmp62Line = "    this.MLazySet("; //488:1
                            if (__tmp62Line != null) __out.Append(__tmp62Line);
                            StringBuilder __tmp63 = new StringBuilder();
                            __tmp63.Append(prop.CSharpFullDescriptorName());
                            using(StreamReader __tmp63Reader = new StreamReader(this.__ToStream(__tmp63.ToString())))
                            {
                                bool __tmp63_first = true;
                                bool __tmp63_last = __tmp63Reader.EndOfStream;
                                while(__tmp63_first || !__tmp63_last)
                                {
                                    __tmp63_first = false;
                                    string __tmp63Line = __tmp63Reader.ReadLine();
                                    __tmp63_last = __tmp63Reader.EndOfStream;
                                    if (__tmp63Line != null) __out.Append(__tmp63Line);
                                    if (!__tmp63_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp64Line = ", new Lazy<object>(() => "; //488:52
                            if (__tmp64Line != null) __out.Append(__tmp64Line);
                            StringBuilder __tmp65 = new StringBuilder();
                            __tmp65.Append(model.CSharpFullImplementationName());
                            using(StreamReader __tmp65Reader = new StreamReader(this.__ToStream(__tmp65.ToString())))
                            {
                                bool __tmp65_first = true;
                                bool __tmp65_last = __tmp65Reader.EndOfStream;
                                while(__tmp65_first || !__tmp65_last)
                                {
                                    __tmp65_first = false;
                                    string __tmp65Line = __tmp65Reader.ReadLine();
                                    __tmp65_last = __tmp65Reader.EndOfStream;
                                    if (__tmp65Line != null) __out.Append(__tmp65Line);
                                    if (!__tmp65_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp66Line = "."; //488:115
                            if (__tmp66Line != null) __out.Append(__tmp66Line);
                            StringBuilder __tmp67 = new StringBuilder();
                            __tmp67.Append(prop.Class.CSharpName());
                            using(StreamReader __tmp67Reader = new StreamReader(this.__ToStream(__tmp67.ToString())))
                            {
                                bool __tmp67_first = true;
                                bool __tmp67_last = __tmp67Reader.EndOfStream;
                                while(__tmp67_first || !__tmp67_last)
                                {
                                    __tmp67_first = false;
                                    string __tmp67Line = __tmp67Reader.ReadLine();
                                    __tmp67_last = __tmp67Reader.EndOfStream;
                                    if (__tmp67Line != null) __out.Append(__tmp67Line);
                                    if (!__tmp67_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp68Line = "_"; //488:141
                            if (__tmp68Line != null) __out.Append(__tmp68Line);
                            StringBuilder __tmp69 = new StringBuilder();
                            __tmp69.Append(prop.Name);
                            using(StreamReader __tmp69Reader = new StreamReader(this.__ToStream(__tmp69.ToString())))
                            {
                                bool __tmp69_first = true;
                                bool __tmp69_last = __tmp69Reader.EndOfStream;
                                while(__tmp69_first || !__tmp69_last)
                                {
                                    __tmp69_first = false;
                                    string __tmp69Line = __tmp69Reader.ReadLine();
                                    __tmp69_last = __tmp69Reader.EndOfStream;
                                    if (__tmp69Line != null) __out.Append(__tmp69Line);
                                    if (!__tmp69_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp70Line = "(this), LazyThreadSafetyMode.ExecutionAndPublication));"; //488:153
                            if (__tmp70Line != null) __out.Append(__tmp70Line);
                            __out.AppendLine(false); //488:208
                        }
                        else if (prop.Kind == MetaPropertyKind.Derived) //489:6
                        {
                            string __tmp72Line = "    this.MDerivedSet("; //490:1
                            if (__tmp72Line != null) __out.Append(__tmp72Line);
                            StringBuilder __tmp73 = new StringBuilder();
                            __tmp73.Append(prop.CSharpFullDescriptorName());
                            using(StreamReader __tmp73Reader = new StreamReader(this.__ToStream(__tmp73.ToString())))
                            {
                                bool __tmp73_first = true;
                                bool __tmp73_last = __tmp73Reader.EndOfStream;
                                while(__tmp73_first || !__tmp73_last)
                                {
                                    __tmp73_first = false;
                                    string __tmp73Line = __tmp73Reader.ReadLine();
                                    __tmp73_last = __tmp73Reader.EndOfStream;
                                    if (__tmp73Line != null) __out.Append(__tmp73Line);
                                    if (!__tmp73_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp74Line = ", () => "; //490:55
                            if (__tmp74Line != null) __out.Append(__tmp74Line);
                            StringBuilder __tmp75 = new StringBuilder();
                            __tmp75.Append(model.CSharpFullImplementationName());
                            using(StreamReader __tmp75Reader = new StreamReader(this.__ToStream(__tmp75.ToString())))
                            {
                                bool __tmp75_first = true;
                                bool __tmp75_last = __tmp75Reader.EndOfStream;
                                while(__tmp75_first || !__tmp75_last)
                                {
                                    __tmp75_first = false;
                                    string __tmp75Line = __tmp75Reader.ReadLine();
                                    __tmp75_last = __tmp75Reader.EndOfStream;
                                    if (__tmp75Line != null) __out.Append(__tmp75Line);
                                    if (!__tmp75_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp76Line = "."; //490:101
                            if (__tmp76Line != null) __out.Append(__tmp76Line);
                            StringBuilder __tmp77 = new StringBuilder();
                            __tmp77.Append(prop.Class.CSharpName());
                            using(StreamReader __tmp77Reader = new StreamReader(this.__ToStream(__tmp77.ToString())))
                            {
                                bool __tmp77_first = true;
                                bool __tmp77_last = __tmp77Reader.EndOfStream;
                                while(__tmp77_first || !__tmp77_last)
                                {
                                    __tmp77_first = false;
                                    string __tmp77Line = __tmp77Reader.ReadLine();
                                    __tmp77_last = __tmp77Reader.EndOfStream;
                                    if (__tmp77Line != null) __out.Append(__tmp77Line);
                                    if (!__tmp77_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp78Line = "_"; //490:127
                            if (__tmp78Line != null) __out.Append(__tmp78Line);
                            StringBuilder __tmp79 = new StringBuilder();
                            __tmp79.Append(prop.Name);
                            using(StreamReader __tmp79Reader = new StreamReader(this.__ToStream(__tmp79.ToString())))
                            {
                                bool __tmp79_first = true;
                                bool __tmp79_last = __tmp79Reader.EndOfStream;
                                while(__tmp79_first || !__tmp79_last)
                                {
                                    __tmp79_first = false;
                                    string __tmp79Line = __tmp79Reader.ReadLine();
                                    __tmp79_last = __tmp79Reader.EndOfStream;
                                    if (__tmp79Line != null) __out.Append(__tmp79Line);
                                    if (!__tmp79_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp80Line = "(this));"; //490:139
                            if (__tmp80Line != null) __out.Append(__tmp80Line);
                            __out.AppendLine(false); //490:147
                        }
                        else if (prop.Kind == MetaPropertyKind.Readonly) //491:6
                        {
                            string __tmp82Line = "    // Init "; //492:1
                            if (__tmp82Line != null) __out.Append(__tmp82Line);
                            StringBuilder __tmp83 = new StringBuilder();
                            __tmp83.Append(prop.CSharpFullDescriptorName());
                            using(StreamReader __tmp83Reader = new StreamReader(this.__ToStream(__tmp83.ToString())))
                            {
                                bool __tmp83_first = true;
                                bool __tmp83_last = __tmp83Reader.EndOfStream;
                                while(__tmp83_first || !__tmp83_last)
                                {
                                    __tmp83_first = false;
                                    string __tmp83Line = __tmp83Reader.ReadLine();
                                    __tmp83_last = __tmp83Reader.EndOfStream;
                                    if (__tmp83Line != null) __out.Append(__tmp83Line);
                                    if (!__tmp83_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp84Line = " in "; //492:46
                            if (__tmp84Line != null) __out.Append(__tmp84Line);
                            StringBuilder __tmp85 = new StringBuilder();
                            __tmp85.Append(model.CSharpFullImplementationName());
                            using(StreamReader __tmp85Reader = new StreamReader(this.__ToStream(__tmp85.ToString())))
                            {
                                bool __tmp85_first = true;
                                bool __tmp85_last = __tmp85Reader.EndOfStream;
                                while(__tmp85_first || !__tmp85_last)
                                {
                                    __tmp85_first = false;
                                    string __tmp85Line = __tmp85Reader.ReadLine();
                                    __tmp85_last = __tmp85Reader.EndOfStream;
                                    if (__tmp85Line != null) __out.Append(__tmp85Line);
                                    if (!__tmp85_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp86Line = "."; //492:88
                            if (__tmp86Line != null) __out.Append(__tmp86Line);
                            StringBuilder __tmp87 = new StringBuilder();
                            __tmp87.Append(cls.CSharpName());
                            using(StreamReader __tmp87Reader = new StreamReader(this.__ToStream(__tmp87.ToString())))
                            {
                                bool __tmp87_first = true;
                                bool __tmp87_last = __tmp87Reader.EndOfStream;
                                while(__tmp87_first || !__tmp87_last)
                                {
                                    __tmp87_first = false;
                                    string __tmp87Line = __tmp87Reader.ReadLine();
                                    __tmp87_last = __tmp87Reader.EndOfStream;
                                    if (__tmp87Line != null) __out.Append(__tmp87Line);
                                    if (!__tmp87_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp88Line = "_"; //492:107
                            if (__tmp88Line != null) __out.Append(__tmp88Line);
                            StringBuilder __tmp89 = new StringBuilder();
                            __tmp89.Append(cls.CSharpName());
                            using(StreamReader __tmp89Reader = new StreamReader(this.__ToStream(__tmp89.ToString())))
                            {
                                bool __tmp89_first = true;
                                bool __tmp89_last = __tmp89Reader.EndOfStream;
                                while(__tmp89_first || !__tmp89_last)
                                {
                                    __tmp89_first = false;
                                    string __tmp89Line = __tmp89Reader.ReadLine();
                                    __tmp89_last = __tmp89Reader.EndOfStream;
                                    if (__tmp89Line != null) __out.Append(__tmp89Line);
                                    if (!__tmp89_last) __out.AppendLine(true);
                                    __out.AppendLine(false); //492:126
                                }
                            }
                        }
                    }
                }
            }
            var __loop27_results = 
                (from __loop27_var1 in __Enumerate((cls).GetEnumerator()) //497:8
                from sup in __Enumerate((__loop27_var1.GetAllSuperClasses(true)).GetEnumerator()) //497:13
                from Constructor in __Enumerate((sup.Constructor).GetEnumerator()) //497:43
                from Initializers in __Enumerate((Constructor.Initializers).GetEnumerator()) //497:56
                from init in __Enumerate((Initializers).GetEnumerator()).OfType<MetaInheritedPropertyInitializer>() //497:70
                select new { __loop27_var1 = __loop27_var1, sup = sup, Constructor = Constructor, Initializers = Initializers, init = init}
                ).ToList(); //497:3
            for (int __loop27_iteration = 0; __loop27_iteration < __loop27_results.Count; ++__loop27_iteration)
            {
                var __tmp90 = __loop27_results[__loop27_iteration];
                var __loop27_var1 = __tmp90.__loop27_var1;
                var sup = __tmp90.sup;
                var Constructor = __tmp90.Constructor;
                var Initializers = __tmp90.Initializers;
                var init = __tmp90.init;
                if (init.Object != null && init.Property != null) //498:4
                {
                    string __tmp92Line = "    this.MLazySetChild("; //499:1
                    if (__tmp92Line != null) __out.Append(__tmp92Line);
                    StringBuilder __tmp93 = new StringBuilder();
                    __tmp93.Append(init.Object.CSharpFullDescriptorName());
                    using(StreamReader __tmp93Reader = new StreamReader(this.__ToStream(__tmp93.ToString())))
                    {
                        bool __tmp93_first = true;
                        bool __tmp93_last = __tmp93Reader.EndOfStream;
                        while(__tmp93_first || !__tmp93_last)
                        {
                            __tmp93_first = false;
                            string __tmp93Line = __tmp93Reader.ReadLine();
                            __tmp93_last = __tmp93Reader.EndOfStream;
                            if (__tmp93Line != null) __out.Append(__tmp93Line);
                            if (!__tmp93_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp94Line = ", "; //499:64
                    if (__tmp94Line != null) __out.Append(__tmp94Line);
                    StringBuilder __tmp95 = new StringBuilder();
                    __tmp95.Append(init.Property.CSharpFullDescriptorName());
                    using(StreamReader __tmp95Reader = new StreamReader(this.__ToStream(__tmp95.ToString())))
                    {
                        bool __tmp95_first = true;
                        bool __tmp95_last = __tmp95Reader.EndOfStream;
                        while(__tmp95_first || !__tmp95_last)
                        {
                            __tmp95_first = false;
                            string __tmp95Line = __tmp95Reader.ReadLine();
                            __tmp95_last = __tmp95Reader.EndOfStream;
                            if (__tmp95Line != null) __out.Append(__tmp95Line);
                            if (!__tmp95_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp96Line = ", new Lazy<object>(() => "; //499:108
                    if (__tmp96Line != null) __out.Append(__tmp96Line);
                    StringBuilder __tmp97 = new StringBuilder();
                    __tmp97.Append(GenerateExpression(init.Value));
                    using(StreamReader __tmp97Reader = new StreamReader(this.__ToStream(__tmp97.ToString())))
                    {
                        bool __tmp97_first = true;
                        bool __tmp97_last = __tmp97Reader.EndOfStream;
                        while(__tmp97_first || !__tmp97_last)
                        {
                            __tmp97_first = false;
                            string __tmp97Line = __tmp97Reader.ReadLine();
                            __tmp97_last = __tmp97Reader.EndOfStream;
                            if (__tmp97Line != null) __out.Append(__tmp97Line);
                            if (!__tmp97_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp98Line = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //499:165
                    if (__tmp98Line != null) __out.Append(__tmp98Line);
                    __out.AppendLine(false); //499:214
                }
            }
            string __tmp99Prefix = "    "; //502:1
            StringBuilder __tmp100 = new StringBuilder();
            __tmp100.Append(cls.Model.CSharpFullImplementationName());
            using(StreamReader __tmp100Reader = new StreamReader(this.__ToStream(__tmp100.ToString())))
            {
                bool __tmp100_first = true;
                bool __tmp100_last = __tmp100Reader.EndOfStream;
                while(__tmp100_first || !__tmp100_last)
                {
                    __tmp100_first = false;
                    string __tmp100Line = __tmp100Reader.ReadLine();
                    __tmp100_last = __tmp100Reader.EndOfStream;
                    __out.Append(__tmp99Prefix);
                    if (__tmp100Line != null) __out.Append(__tmp100Line);
                    if (!__tmp100_last) __out.AppendLine(true);
                }
            }
            string __tmp101Line = "."; //502:47
            if (__tmp101Line != null) __out.Append(__tmp101Line);
            StringBuilder __tmp102 = new StringBuilder();
            __tmp102.Append(cls.CSharpName());
            using(StreamReader __tmp102Reader = new StreamReader(this.__ToStream(__tmp102.ToString())))
            {
                bool __tmp102_first = true;
                bool __tmp102_last = __tmp102Reader.EndOfStream;
                while(__tmp102_first || !__tmp102_last)
                {
                    __tmp102_first = false;
                    string __tmp102Line = __tmp102Reader.ReadLine();
                    __tmp102_last = __tmp102Reader.EndOfStream;
                    if (__tmp102Line != null) __out.Append(__tmp102Line);
                    if (!__tmp102_last) __out.AppendLine(true);
                }
            }
            string __tmp103Line = "(this);"; //502:66
            if (__tmp103Line != null) __out.Append(__tmp103Line);
            __out.AppendLine(false); //502:73
            var __loop28_results = 
                (from __loop28_var1 in __Enumerate((cls).GetEnumerator()) //503:11
                from prop in __Enumerate((__loop28_var1.GetAllProperties()).GetEnumerator()) //503:16
                select new { __loop28_var1 = __loop28_var1, prop = prop}
                ).ToList(); //503:6
            for (int __loop28_iteration = 0; __loop28_iteration < __loop28_results.Count; ++__loop28_iteration)
            {
                var __tmp104 = __loop28_results[__loop28_iteration];
                var __loop28_var1 = __tmp104.__loop28_var1;
                var prop = __tmp104.prop;
                if (prop.Kind == MetaPropertyKind.Readonly) //504:4
                {
                    string __tmp106Line = "    if (!this.MIsSet("; //505:1
                    if (__tmp106Line != null) __out.Append(__tmp106Line);
                    StringBuilder __tmp107 = new StringBuilder();
                    __tmp107.Append(prop.CSharpFullDescriptorName());
                    using(StreamReader __tmp107Reader = new StreamReader(this.__ToStream(__tmp107.ToString())))
                    {
                        bool __tmp107_first = true;
                        bool __tmp107_last = __tmp107Reader.EndOfStream;
                        while(__tmp107_first || !__tmp107_last)
                        {
                            __tmp107_first = false;
                            string __tmp107Line = __tmp107Reader.ReadLine();
                            __tmp107_last = __tmp107Reader.EndOfStream;
                            if (__tmp107Line != null) __out.Append(__tmp107Line);
                            if (!__tmp107_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp108Line = ")) throw new ModelException(\"Readonly property "; //505:55
                    if (__tmp108Line != null) __out.Append(__tmp108Line);
                    StringBuilder __tmp109 = new StringBuilder();
                    __tmp109.Append(model.CSharpName());
                    using(StreamReader __tmp109Reader = new StreamReader(this.__ToStream(__tmp109.ToString())))
                    {
                        bool __tmp109_first = true;
                        bool __tmp109_last = __tmp109Reader.EndOfStream;
                        while(__tmp109_first || !__tmp109_last)
                        {
                            __tmp109_first = false;
                            string __tmp109Line = __tmp109Reader.ReadLine();
                            __tmp109_last = __tmp109Reader.EndOfStream;
                            if (__tmp109Line != null) __out.Append(__tmp109Line);
                            if (!__tmp109_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp110Line = "."; //505:122
                    if (__tmp110Line != null) __out.Append(__tmp110Line);
                    StringBuilder __tmp111 = new StringBuilder();
                    __tmp111.Append(prop.Class.CSharpName());
                    using(StreamReader __tmp111Reader = new StreamReader(this.__ToStream(__tmp111.ToString())))
                    {
                        bool __tmp111_first = true;
                        bool __tmp111_last = __tmp111Reader.EndOfStream;
                        while(__tmp111_first || !__tmp111_last)
                        {
                            __tmp111_first = false;
                            string __tmp111Line = __tmp111Reader.ReadLine();
                            __tmp111_last = __tmp111Reader.EndOfStream;
                            if (__tmp111Line != null) __out.Append(__tmp111Line);
                            if (!__tmp111_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp112Line = "."; //505:148
                    if (__tmp112Line != null) __out.Append(__tmp112Line);
                    StringBuilder __tmp113 = new StringBuilder();
                    __tmp113.Append(prop.Name);
                    using(StreamReader __tmp113Reader = new StreamReader(this.__ToStream(__tmp113.ToString())))
                    {
                        bool __tmp113_first = true;
                        bool __tmp113_last = __tmp113Reader.EndOfStream;
                        while(__tmp113_first || !__tmp113_last)
                        {
                            __tmp113_first = false;
                            string __tmp113Line = __tmp113Reader.ReadLine();
                            __tmp113_last = __tmp113Reader.EndOfStream;
                            if (__tmp113Line != null) __out.Append(__tmp113Line);
                            if (!__tmp113_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp114Line = "Property was not set in "; //505:160
                    if (__tmp114Line != null) __out.Append(__tmp114Line);
                    StringBuilder __tmp115 = new StringBuilder();
                    __tmp115.Append(cls.CSharpName());
                    using(StreamReader __tmp115Reader = new StreamReader(this.__ToStream(__tmp115.ToString())))
                    {
                        bool __tmp115_first = true;
                        bool __tmp115_last = __tmp115Reader.EndOfStream;
                        while(__tmp115_first || !__tmp115_last)
                        {
                            __tmp115_first = false;
                            string __tmp115Line = __tmp115Reader.ReadLine();
                            __tmp115_last = __tmp115Reader.EndOfStream;
                            if (__tmp115Line != null) __out.Append(__tmp115Line);
                            if (!__tmp115_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp116Line = "_"; //505:202
                    if (__tmp116Line != null) __out.Append(__tmp116Line);
                    StringBuilder __tmp117 = new StringBuilder();
                    __tmp117.Append(cls.CSharpName());
                    using(StreamReader __tmp117Reader = new StreamReader(this.__ToStream(__tmp117.ToString())))
                    {
                        bool __tmp117_first = true;
                        bool __tmp117_last = __tmp117Reader.EndOfStream;
                        while(__tmp117_first || !__tmp117_last)
                        {
                            __tmp117_first = false;
                            string __tmp117Line = __tmp117Reader.ReadLine();
                            __tmp117_last = __tmp117Reader.EndOfStream;
                            if (__tmp117Line != null) __out.Append(__tmp117Line);
                            if (!__tmp117_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp118Line = "().\");"; //505:221
                    if (__tmp118Line != null) __out.Append(__tmp118Line);
                    __out.AppendLine(false); //505:227
                }
            }
            __out.Append("    this.MMakeDefault();"); //508:1
            __out.AppendLine(false); //508:25
            __out.Append("}"); //509:1
            __out.AppendLine(false); //509:2
            return __out.ToString();
        }

        public string GetReturn(MetaOperation op) //512:1
        {
            if (op.ReturnType.CSharpName() == "void") //513:5
            {
                return ""; //514:3
            }
            else //515:2
            {
                return "return "; //516:3
            }
        }

        public string GenerateOperationImpl(MetaModel model, MetaOperation op) //520:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //521:1
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(op.ReturnType.CSharpFullPublicName());
            using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
            {
                bool __tmp2_first = true;
                bool __tmp2_last = __tmp2Reader.EndOfStream;
                while(__tmp2_first || !__tmp2_last)
                {
                    __tmp2_first = false;
                    string __tmp2Line = __tmp2Reader.ReadLine();
                    __tmp2_last = __tmp2Reader.EndOfStream;
                    if (__tmp2Line != null) __out.Append(__tmp2Line);
                    if (!__tmp2_last) __out.AppendLine(true);
                }
            }
            string __tmp3Line = " "; //522:39
            if (__tmp3Line != null) __out.Append(__tmp3Line);
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(op.Parent.CSharpFullName());
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_first = true;
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(__tmp4_first || !__tmp4_last)
                {
                    __tmp4_first = false;
                    string __tmp4Line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (__tmp4Line != null) __out.Append(__tmp4Line);
                    if (!__tmp4_last) __out.AppendLine(true);
                }
            }
            string __tmp5Line = "."; //522:68
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(op.Name);
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(__tmp6_first || !__tmp6_last)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if (__tmp6Line != null) __out.Append(__tmp6Line);
                    if (!__tmp6_last) __out.AppendLine(true);
                }
            }
            string __tmp7Line = "("; //522:78
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(GetParameters(op, false));
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_first = true;
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(__tmp8_first || !__tmp8_last)
                {
                    __tmp8_first = false;
                    string __tmp8Line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if (__tmp8Line != null) __out.Append(__tmp8Line);
                    if (!__tmp8_last) __out.AppendLine(true);
                }
            }
            string __tmp9Line = ")"; //522:105
            if (__tmp9Line != null) __out.Append(__tmp9Line);
            __out.AppendLine(false); //522:106
            __out.Append("{"); //523:1
            __out.AppendLine(false); //523:2
            string __tmp10Prefix = "    "; //524:1
            StringBuilder __tmp11 = new StringBuilder();
            __tmp11.Append(GetReturn(op));
            using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
            {
                bool __tmp11_first = true;
                bool __tmp11_last = __tmp11Reader.EndOfStream;
                while(__tmp11_first || !__tmp11_last)
                {
                    __tmp11_first = false;
                    string __tmp11Line = __tmp11Reader.ReadLine();
                    __tmp11_last = __tmp11Reader.EndOfStream;
                    __out.Append(__tmp10Prefix);
                    if (__tmp11Line != null) __out.Append(__tmp11Line);
                    if (!__tmp11_last) __out.AppendLine(true);
                }
            }
            StringBuilder __tmp12 = new StringBuilder();
            __tmp12.Append(model.CSharpFullImplementationName());
            using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
            {
                bool __tmp12_first = true;
                bool __tmp12_last = __tmp12Reader.EndOfStream;
                while(__tmp12_first || !__tmp12_last)
                {
                    __tmp12_first = false;
                    string __tmp12Line = __tmp12Reader.ReadLine();
                    __tmp12_last = __tmp12Reader.EndOfStream;
                    if (__tmp12Line != null) __out.Append(__tmp12Line);
                    if (!__tmp12_last) __out.AppendLine(true);
                }
            }
            string __tmp13Line = "."; //524:58
            if (__tmp13Line != null) __out.Append(__tmp13Line);
            StringBuilder __tmp14 = new StringBuilder();
            __tmp14.Append(op.Parent.CSharpName());
            using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
            {
                bool __tmp14_first = true;
                bool __tmp14_last = __tmp14Reader.EndOfStream;
                while(__tmp14_first || !__tmp14_last)
                {
                    __tmp14_first = false;
                    string __tmp14Line = __tmp14Reader.ReadLine();
                    __tmp14_last = __tmp14Reader.EndOfStream;
                    if (__tmp14Line != null) __out.Append(__tmp14Line);
                    if (!__tmp14_last) __out.AppendLine(true);
                }
            }
            string __tmp15Line = "_"; //524:83
            if (__tmp15Line != null) __out.Append(__tmp15Line);
            StringBuilder __tmp16 = new StringBuilder();
            __tmp16.Append(op.Name);
            using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
            {
                bool __tmp16_first = true;
                bool __tmp16_last = __tmp16Reader.EndOfStream;
                while(__tmp16_first || !__tmp16_last)
                {
                    __tmp16_first = false;
                    string __tmp16Line = __tmp16Reader.ReadLine();
                    __tmp16_last = __tmp16Reader.EndOfStream;
                    if (__tmp16Line != null) __out.Append(__tmp16Line);
                    if (!__tmp16_last) __out.AppendLine(true);
                }
            }
            string __tmp17Line = "("; //524:93
            if (__tmp17Line != null) __out.Append(__tmp17Line);
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append(GetImplCallParameterNames(op));
            using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
            {
                bool __tmp18_first = true;
                bool __tmp18_last = __tmp18Reader.EndOfStream;
                while(__tmp18_first || !__tmp18_last)
                {
                    __tmp18_first = false;
                    string __tmp18Line = __tmp18Reader.ReadLine();
                    __tmp18_last = __tmp18Reader.EndOfStream;
                    if (__tmp18Line != null) __out.Append(__tmp18Line);
                    if (!__tmp18_last) __out.AppendLine(true);
                }
            }
            string __tmp19Line = ");"; //524:125
            if (__tmp19Line != null) __out.Append(__tmp19Line);
            __out.AppendLine(false); //524:127
            __out.Append("}"); //525:1
            __out.AppendLine(false); //525:2
            return __out.ToString();
        }

        public string GetSuperClasses(MetaClass cls) //528:1
        {
            string result = ""; //529:2
            var __loop29_results = 
                (from __loop29_var1 in __Enumerate((cls).GetEnumerator()) //530:10
                from sup in __Enumerate((__loop29_var1.SuperClasses).GetEnumerator()) //530:15
                select new { __loop29_var1 = __loop29_var1, sup = sup}
                ).ToList(); //530:5
            for (int __loop29_iteration = 0; __loop29_iteration < __loop29_results.Count; ++__loop29_iteration)
            {
                string delim; //530:31
                if (__loop29_iteration+1 < __loop29_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop29_results[__loop29_iteration];
                var __loop29_var1 = __tmp1.__loop29_var1;
                var sup = __tmp1.sup;
                result += sup.CSharpFullName() + delim; //531:3
            }
            return result; //533:2
        }

        public string GetAllSuperClasses(MetaClass cls) //536:1
        {
            string result = ""; //537:2
            var __loop30_results = 
                (from __loop30_var1 in __Enumerate((cls).GetEnumerator()) //538:10
                from sup in __Enumerate((__loop30_var1.GetAllSuperClasses(false)).GetEnumerator()) //538:15
                select new { __loop30_var1 = __loop30_var1, sup = sup}
                ).ToList(); //538:5
            for (int __loop30_iteration = 0; __loop30_iteration < __loop30_results.Count; ++__loop30_iteration)
            {
                string delim; //538:44
                if (__loop30_iteration+1 < __loop30_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop30_results[__loop30_iteration];
                var __loop30_var1 = __tmp1.__loop30_var1;
                var sup = __tmp1.sup;
                result += sup.CSharpFullName() + delim; //539:3
            }
            return result; //541:2
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //544:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "public static class "; //545:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.CSharpDescriptorName());
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(__tmp3_first || !__tmp3_last)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    if (!__tmp3_last) __out.AppendLine(true);
                    __out.AppendLine(false); //545:51
                }
            }
            __out.Append("{"); //546:1
            __out.AppendLine(false); //546:2
            string __tmp5Line = "    static "; //547:1
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(model.Name);
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(__tmp6_first || !__tmp6_last)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if (__tmp6Line != null) __out.Append(__tmp6Line);
                    if (!__tmp6_last) __out.AppendLine(true);
                }
            }
            string __tmp7Line = "Descriptor()"; //547:24
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //547:36
            __out.Append("    {"); //548:1
            __out.AppendLine(false); //548:6
            var __loop31_results = 
                (from __loop31_var1 in __Enumerate((model).GetEnumerator()) //549:11
                from Namespace in __Enumerate((__loop31_var1.Namespace).GetEnumerator()) //549:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //549:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //549:43
                select new { __loop31_var1 = __loop31_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //549:6
            for (int __loop31_iteration = 0; __loop31_iteration < __loop31_results.Count; ++__loop31_iteration)
            {
                var __tmp8 = __loop31_results[__loop31_iteration];
                var __loop31_var1 = __tmp8.__loop31_var1;
                var Namespace = __tmp8.Namespace;
                var Declarations = __tmp8.Declarations;
                var cls = __tmp8.cls;
                string __tmp9Prefix = "        "; //550:1
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(cls.CSharpName());
                using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
                {
                    bool __tmp10_first = true;
                    bool __tmp10_last = __tmp10Reader.EndOfStream;
                    while(__tmp10_first || !__tmp10_last)
                    {
                        __tmp10_first = false;
                        string __tmp10Line = __tmp10Reader.ReadLine();
                        __tmp10_last = __tmp10Reader.EndOfStream;
                        __out.Append(__tmp9Prefix);
                        if (__tmp10Line != null) __out.Append(__tmp10Line);
                        if (!__tmp10_last) __out.AppendLine(true);
                    }
                }
                string __tmp11Line = ".StaticInit();"; //550:27
                if (__tmp11Line != null) __out.Append(__tmp11Line);
                __out.AppendLine(false); //550:41
            }
            __out.Append("    }"); //552:1
            __out.AppendLine(false); //552:6
            __out.AppendLine(true); //553:1
            __out.Append("    internal static void StaticInit()"); //554:1
            __out.AppendLine(false); //554:38
            __out.Append("    {"); //555:1
            __out.AppendLine(false); //555:6
            __out.Append("    }"); //556:1
            __out.AppendLine(false); //556:6
            __out.AppendLine(true); //557:1
            string __tmp13Line = "	public const string Uri = \""; //558:1
            if (__tmp13Line != null) __out.Append(__tmp13Line);
            StringBuilder __tmp14 = new StringBuilder();
            __tmp14.Append(model.Uri);
            using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
            {
                bool __tmp14_first = true;
                bool __tmp14_last = __tmp14Reader.EndOfStream;
                while(__tmp14_first || !__tmp14_last)
                {
                    __tmp14_first = false;
                    string __tmp14Line = __tmp14Reader.ReadLine();
                    __tmp14_last = __tmp14Reader.EndOfStream;
                    if (__tmp14Line != null) __out.Append(__tmp14Line);
                    if (!__tmp14_last) __out.AppendLine(true);
                }
            }
            string __tmp15Line = "\";"; //558:40
            if (__tmp15Line != null) __out.Append(__tmp15Line);
            __out.AppendLine(false); //558:42
            __out.AppendLine(true); //559:1
            var __loop32_results = 
                (from __loop32_var1 in __Enumerate((model).GetEnumerator()) //560:11
                from Namespace in __Enumerate((__loop32_var1.Namespace).GetEnumerator()) //560:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //560:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //560:43
                select new { __loop32_var1 = __loop32_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //560:6
            for (int __loop32_iteration = 0; __loop32_iteration < __loop32_results.Count; ++__loop32_iteration)
            {
                var __tmp16 = __loop32_results[__loop32_iteration];
                var __loop32_var1 = __tmp16.__loop32_var1;
                var Namespace = __tmp16.Namespace;
                var Declarations = __tmp16.Declarations;
                var cls = __tmp16.cls;
                string __tmp17Prefix = "    "; //561:1
                StringBuilder __tmp18 = new StringBuilder();
                __tmp18.Append(GenerateMetaModelClass(cls));
                using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
                {
                    bool __tmp18_first = true;
                    bool __tmp18_last = __tmp18Reader.EndOfStream;
                    while(__tmp18_first || !__tmp18_last)
                    {
                        __tmp18_first = false;
                        string __tmp18Line = __tmp18Reader.ReadLine();
                        __tmp18_last = __tmp18Reader.EndOfStream;
                        __out.Append(__tmp17Prefix);
                        if (__tmp18Line != null) __out.Append(__tmp18Line);
                        if (!__tmp18_last) __out.AppendLine(true);
                        __out.AppendLine(false); //561:34
                    }
                }
            }
            __out.Append("}"); //563:1
            __out.AppendLine(false); //563:2
            __out.AppendLine(true); //564:1
            return __out.ToString();
        }

        public string GenerateMetaModelClass(MetaClass cls) //568:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //569:1
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(GenerateDocumentation(cls));
            using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
            {
                bool __tmp2_first = true;
                bool __tmp2_last = __tmp2Reader.EndOfStream;
                while(__tmp2_first || !__tmp2_last)
                {
                    __tmp2_first = false;
                    string __tmp2Line = __tmp2Reader.ReadLine();
                    __tmp2_last = __tmp2Reader.EndOfStream;
                    if (__tmp2Line != null) __out.Append(__tmp2Line);
                    if (!__tmp2_last) __out.AppendLine(true);
                    __out.AppendLine(false); //570:29
                }
            }
            string __tmp4Line = "public static class "; //571:1
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(cls.CSharpName());
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_first = true;
                bool __tmp5_last = __tmp5Reader.EndOfStream;
                while(__tmp5_first || !__tmp5_last)
                {
                    __tmp5_first = false;
                    string __tmp5Line = __tmp5Reader.ReadLine();
                    __tmp5_last = __tmp5Reader.EndOfStream;
                    if (__tmp5Line != null) __out.Append(__tmp5Line);
                    if (!__tmp5_last) __out.AppendLine(true);
                    __out.AppendLine(false); //571:39
                }
            }
            __out.Append("{"); //572:1
            __out.AppendLine(false); //572:2
            __out.Append("    internal static void StaticInit()"); //573:1
            __out.AppendLine(false); //573:38
            __out.Append("    {"); //574:1
            __out.AppendLine(false); //574:6
            __out.Append("    }"); //575:1
            __out.AppendLine(false); //575:6
            __out.AppendLine(true); //576:1
            string __tmp7Line = "    static "; //577:1
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(cls.CSharpName());
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_first = true;
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(__tmp8_first || !__tmp8_last)
                {
                    __tmp8_first = false;
                    string __tmp8Line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if (__tmp8Line != null) __out.Append(__tmp8Line);
                    if (!__tmp8_last) __out.AppendLine(true);
                }
            }
            string __tmp9Line = "()"; //577:30
            if (__tmp9Line != null) __out.Append(__tmp9Line);
            __out.AppendLine(false); //577:32
            __out.Append("    {"); //578:1
            __out.AppendLine(false); //578:6
            string __tmp10Prefix = "        "; //579:1
            StringBuilder __tmp11 = new StringBuilder();
            __tmp11.Append(cls.Model.CSharpFullDescriptorName());
            using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
            {
                bool __tmp11_first = true;
                bool __tmp11_last = __tmp11Reader.EndOfStream;
                while(__tmp11_first || !__tmp11_last)
                {
                    __tmp11_first = false;
                    string __tmp11Line = __tmp11Reader.ReadLine();
                    __tmp11_last = __tmp11Reader.EndOfStream;
                    __out.Append(__tmp10Prefix);
                    if (__tmp11Line != null) __out.Append(__tmp11Line);
                    if (!__tmp11_last) __out.AppendLine(true);
                }
            }
            string __tmp12Line = ".StaticInit();"; //579:47
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //579:61
            __out.Append("    }"); //580:1
            __out.AppendLine(false); //580:6
            __out.AppendLine(true); //581:1
            if (cls.CSharpName() == "MetaClass") //582:2
            {
                __out.Append("    public static global::MetaDslx.Core.MetaClass _MetaClass"); //583:1
                __out.AppendLine(false); //583:61
            }
            else //584:2
            {
                __out.Append("    public static global::MetaDslx.Core.MetaClass MetaClass"); //585:1
                __out.AppendLine(false); //585:60
            }
            __out.Append("    {"); //587:1
            __out.AppendLine(false); //587:6
            string __tmp14Line = "        get { return "; //588:1
            if (__tmp14Line != null) __out.Append(__tmp14Line);
            StringBuilder __tmp15 = new StringBuilder();
            __tmp15.Append(cls.CSharpFullInstanceName());
            using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
            {
                bool __tmp15_first = true;
                bool __tmp15_last = __tmp15Reader.EndOfStream;
                while(__tmp15_first || !__tmp15_last)
                {
                    __tmp15_first = false;
                    string __tmp15Line = __tmp15Reader.ReadLine();
                    __tmp15_last = __tmp15Reader.EndOfStream;
                    if (__tmp15Line != null) __out.Append(__tmp15Line);
                    if (!__tmp15_last) __out.AppendLine(true);
                }
            }
            string __tmp16Line = "; }"; //588:52
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            __out.AppendLine(false); //588:55
            __out.Append("    }"); //589:1
            __out.AppendLine(false); //589:6
            __out.AppendLine(true); //590:1
            var __loop33_results = 
                (from __loop33_var1 in __Enumerate((cls).GetEnumerator()) //591:11
                from prop in __Enumerate((__loop33_var1.Properties).GetEnumerator()) //591:16
                select new { __loop33_var1 = __loop33_var1, prop = prop}
                ).ToList(); //591:6
            for (int __loop33_iteration = 0; __loop33_iteration < __loop33_results.Count; ++__loop33_iteration)
            {
                var __tmp17 = __loop33_results[__loop33_iteration];
                var __loop33_var1 = __tmp17.__loop33_var1;
                var prop = __tmp17.prop;
                string __tmp18Prefix = "	"; //592:1
                StringBuilder __tmp19 = new StringBuilder();
                __tmp19.Append(GenerateDocumentation(prop));
                using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
                {
                    bool __tmp19_first = true;
                    bool __tmp19_last = __tmp19Reader.EndOfStream;
                    while(__tmp19_first || !__tmp19_last)
                    {
                        __tmp19_first = false;
                        string __tmp19Line = __tmp19Reader.ReadLine();
                        __tmp19_last = __tmp19Reader.EndOfStream;
                        __out.Append(__tmp18Prefix);
                        if (__tmp19Line != null) __out.Append(__tmp19Line);
                        if (!__tmp19_last) __out.AppendLine(true);
                        __out.AppendLine(false); //592:31
                    }
                }
                string __tmp20Prefix = "    "; //593:1
                StringBuilder __tmp21 = new StringBuilder();
                __tmp21.Append(GeneratePropertyDeclaration(cls.Model, cls, prop));
                using(StreamReader __tmp21Reader = new StreamReader(this.__ToStream(__tmp21.ToString())))
                {
                    bool __tmp21_first = true;
                    bool __tmp21_last = __tmp21Reader.EndOfStream;
                    while(__tmp21_first || !__tmp21_last)
                    {
                        __tmp21_first = false;
                        string __tmp21Line = __tmp21Reader.ReadLine();
                        __tmp21_last = __tmp21Reader.EndOfStream;
                        __out.Append(__tmp20Prefix);
                        if (__tmp21Line != null) __out.Append(__tmp21Line);
                        if (!__tmp21_last) __out.AppendLine(true);
                        __out.AppendLine(false); //593:56
                    }
                }
            }
            __out.Append("}"); //595:1
            __out.AppendLine(false); //595:2
            return __out.ToString();
        }

        public string GenerateModelConstant(MetaModel model, MetaConstant mconst) //599:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(GenerateDocumentation(mconst));
            using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
            {
                bool __tmp2_first = true;
                bool __tmp2_last = __tmp2Reader.EndOfStream;
                while(__tmp2_first || !__tmp2_last)
                {
                    __tmp2_first = false;
                    string __tmp2Line = __tmp2Reader.ReadLine();
                    __tmp2_last = __tmp2Reader.EndOfStream;
                    if (__tmp2Line != null) __out.Append(__tmp2Line);
                    if (!__tmp2_last) __out.AppendLine(true);
                    __out.AppendLine(false); //600:32
                }
            }
            string __tmp4Line = "public static readonly "; //601:1
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(mconst.Type.CSharpFullName());
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_first = true;
                bool __tmp5_last = __tmp5Reader.EndOfStream;
                while(__tmp5_first || !__tmp5_last)
                {
                    __tmp5_first = false;
                    string __tmp5Line = __tmp5Reader.ReadLine();
                    __tmp5_last = __tmp5Reader.EndOfStream;
                    if (__tmp5Line != null) __out.Append(__tmp5Line);
                    if (!__tmp5_last) __out.AppendLine(true);
                }
            }
            string __tmp6Line = " "; //601:54
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(mconst.Name);
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_first = true;
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(__tmp7_first || !__tmp7_last)
                {
                    __tmp7_first = false;
                    string __tmp7Line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    if (__tmp7Line != null) __out.Append(__tmp7Line);
                    if (!__tmp7_last) __out.AppendLine(true);
                }
            }
            string __tmp8Line = ";"; //601:68
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //601:69
            return __out.ToString();
        }

        public string GenerateModelConstantImpl(MetaModel model, MetaConstant mconst, Dictionary<ModelObject,string> mobjToTmp) //604:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(mconst.Name);
            using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
            {
                bool __tmp2_first = true;
                bool __tmp2_last = __tmp2Reader.EndOfStream;
                while(__tmp2_first || !__tmp2_last)
                {
                    __tmp2_first = false;
                    string __tmp2Line = __tmp2Reader.ReadLine();
                    __tmp2_last = __tmp2Reader.EndOfStream;
                    if (__tmp2Line != null) __out.Append(__tmp2Line);
                    if (!__tmp2_last) __out.AppendLine(true);
                }
            }
            string __tmp3Line = " = "; //605:14
            if (__tmp3Line != null) __out.Append(__tmp3Line);
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(GenerateExpression(mconst.Value));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_first = true;
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(__tmp4_first || !__tmp4_last)
                {
                    __tmp4_first = false;
                    string __tmp4Line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (__tmp4Line != null) __out.Append(__tmp4Line);
                    if (!__tmp4_last) __out.AppendLine(true);
                }
            }
            string __tmp5Line = ";"; //605:51
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            __out.AppendLine(false); //605:52
            return __out.ToString();
        }

        public string GenerateMetaModelInstance(MetaModel model) //609:1
        {
            StringBuilder __out = new StringBuilder();
            Dictionary<ModelObject,string> mobjToName = model.GetNamedModelObjects(); //610:2
            string __tmp2Line = "public static class "; //611:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.CSharpInstancesName());
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(__tmp3_first || !__tmp3_last)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    if (!__tmp3_last) __out.AppendLine(true);
                    __out.AppendLine(false); //611:50
                }
            }
            __out.Append("{"); //612:1
            __out.AppendLine(false); //612:2
            __out.Append("    private static global::MetaDslx.Core.Model model;"); //613:1
            __out.AppendLine(false); //613:54
            __out.AppendLine(true); //614:1
            __out.Append("    public static global::MetaDslx.Core.Model Model"); //615:1
            __out.AppendLine(false); //615:52
            __out.Append("    {"); //616:1
            __out.AppendLine(false); //616:6
            string __tmp5Line = "        get { return "; //617:1
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(model.Name);
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(__tmp6_first || !__tmp6_last)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if (__tmp6Line != null) __out.Append(__tmp6Line);
                    if (!__tmp6_last) __out.AppendLine(true);
                }
            }
            string __tmp7Line = "Instance.model; }"; //617:34
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //617:51
            __out.Append("    }"); //618:1
            __out.AppendLine(false); //618:6
            __out.AppendLine(true); //619:1
            __out.Append("    public static readonly global::MetaDslx.Core.MetaModel Meta;"); //620:1
            __out.AppendLine(false); //620:65
            __out.AppendLine(true); //621:1
            var __loop34_results = 
                (from __loop34_var1 in __Enumerate((model).GetEnumerator()) //622:11
                from Namespace in __Enumerate((__loop34_var1.Namespace).GetEnumerator()) //622:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //622:29
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //622:43
                select new { __loop34_var1 = __loop34_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //622:6
            for (int __loop34_iteration = 0; __loop34_iteration < __loop34_results.Count; ++__loop34_iteration)
            {
                var __tmp8 = __loop34_results[__loop34_iteration];
                var __loop34_var1 = __tmp8.__loop34_var1;
                var Namespace = __tmp8.Namespace;
                var Declarations = __tmp8.Declarations;
                var c = __tmp8.c;
                string __tmp9Prefix = "    "; //623:1
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(GenerateModelConstant(model, c));
                using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
                {
                    bool __tmp10_first = true;
                    bool __tmp10_last = __tmp10Reader.EndOfStream;
                    while(__tmp10_first || !__tmp10_last)
                    {
                        __tmp10_first = false;
                        string __tmp10Line = __tmp10Reader.ReadLine();
                        __tmp10_last = __tmp10Reader.EndOfStream;
                        __out.Append(__tmp9Prefix);
                        if (__tmp10Line != null) __out.Append(__tmp10Line);
                        if (!__tmp10_last) __out.AppendLine(true);
                        __out.AppendLine(false); //623:38
                    }
                }
            }
            __out.AppendLine(true); //625:1
            var __loop35_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //626:11
                select new { mobj = mobj}
                ).ToList(); //626:6
            for (int __loop35_iteration = 0; __loop35_iteration < __loop35_results.Count; ++__loop35_iteration)
            {
                var __tmp11 = __loop35_results[__loop35_iteration];
                var mobj = __tmp11.mobj;
                string __tmp12Prefix = "	"; //627:1
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(GenerateModelObjectInstanceDeclaration(mobj, mobjToName));
                using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                {
                    bool __tmp13_first = true;
                    bool __tmp13_last = __tmp13Reader.EndOfStream;
                    while(__tmp13_first || !__tmp13_last)
                    {
                        __tmp13_first = false;
                        string __tmp13Line = __tmp13Reader.ReadLine();
                        __tmp13_last = __tmp13Reader.EndOfStream;
                        __out.Append(__tmp12Prefix);
                        if (__tmp13Line != null) __out.Append(__tmp13Line);
                        if (!__tmp13_last) __out.AppendLine(true);
                        __out.AppendLine(false); //627:60
                    }
                }
            }
            __out.AppendLine(true); //629:1
            string __tmp15Line = "    static "; //630:1
            if (__tmp15Line != null) __out.Append(__tmp15Line);
            StringBuilder __tmp16 = new StringBuilder();
            __tmp16.Append(model.CSharpInstancesName());
            using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
            {
                bool __tmp16_first = true;
                bool __tmp16_last = __tmp16Reader.EndOfStream;
                while(__tmp16_first || !__tmp16_last)
                {
                    __tmp16_first = false;
                    string __tmp16Line = __tmp16Reader.ReadLine();
                    __tmp16_last = __tmp16Reader.EndOfStream;
                    if (__tmp16Line != null) __out.Append(__tmp16Line);
                    if (!__tmp16_last) __out.AppendLine(true);
                }
            }
            string __tmp17Line = "()"; //630:41
            if (__tmp17Line != null) __out.Append(__tmp17Line);
            __out.AppendLine(false); //630:43
            __out.Append("    {"); //631:1
            __out.AppendLine(false); //631:6
            string __tmp18Prefix = "		"; //632:1
            StringBuilder __tmp19 = new StringBuilder();
            __tmp19.Append(model.CSharpDescriptorName());
            using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
            {
                bool __tmp19_first = true;
                bool __tmp19_last = __tmp19Reader.EndOfStream;
                while(__tmp19_first || !__tmp19_last)
                {
                    __tmp19_first = false;
                    string __tmp19Line = __tmp19Reader.ReadLine();
                    __tmp19_last = __tmp19Reader.EndOfStream;
                    __out.Append(__tmp18Prefix);
                    if (__tmp19Line != null) __out.Append(__tmp19Line);
                    if (!__tmp19_last) __out.AppendLine(true);
                }
            }
            string __tmp20Line = ".StaticInit();"; //632:33
            if (__tmp20Line != null) __out.Append(__tmp20Line);
            __out.AppendLine(false); //632:47
            string __tmp21Prefix = "		"; //633:1
            StringBuilder __tmp22 = new StringBuilder();
            __tmp22.Append(model.CSharpInstancesName());
            using(StreamReader __tmp22Reader = new StreamReader(this.__ToStream(__tmp22.ToString())))
            {
                bool __tmp22_first = true;
                bool __tmp22_last = __tmp22Reader.EndOfStream;
                while(__tmp22_first || !__tmp22_last)
                {
                    __tmp22_first = false;
                    string __tmp22Line = __tmp22Reader.ReadLine();
                    __tmp22_last = __tmp22Reader.EndOfStream;
                    __out.Append(__tmp21Prefix);
                    if (__tmp22Line != null) __out.Append(__tmp22Line);
                    if (!__tmp22_last) __out.AppendLine(true);
                }
            }
            string __tmp23Line = ".model = new global::MetaDslx.Core.Model();"; //633:32
            if (__tmp23Line != null) __out.Append(__tmp23Line);
            __out.AppendLine(false); //633:75
            string __tmp25Line = "   		using (new ModelContextScope("; //634:1
            if (__tmp25Line != null) __out.Append(__tmp25Line);
            StringBuilder __tmp26 = new StringBuilder();
            __tmp26.Append(model.CSharpInstancesName());
            using(StreamReader __tmp26Reader = new StreamReader(this.__ToStream(__tmp26.ToString())))
            {
                bool __tmp26_first = true;
                bool __tmp26_last = __tmp26Reader.EndOfStream;
                while(__tmp26_first || !__tmp26_last)
                {
                    __tmp26_first = false;
                    string __tmp26Line = __tmp26Reader.ReadLine();
                    __tmp26_last = __tmp26Reader.EndOfStream;
                    if (__tmp26Line != null) __out.Append(__tmp26Line);
                    if (!__tmp26_last) __out.AppendLine(true);
                }
            }
            string __tmp27Line = ".model))"; //634:64
            if (__tmp27Line != null) __out.Append(__tmp27Line);
            __out.AppendLine(false); //634:72
            __out.Append("		{"); //635:1
            __out.AppendLine(false); //635:4
            var __loop36_results = 
                (from __loop36_var1 in __Enumerate((model).GetEnumerator()) //636:13
                from Namespace in __Enumerate((__loop36_var1.Namespace).GetEnumerator()) //636:20
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //636:31
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //636:45
                select new { __loop36_var1 = __loop36_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //636:8
            for (int __loop36_iteration = 0; __loop36_iteration < __loop36_results.Count; ++__loop36_iteration)
            {
                var __tmp28 = __loop36_results[__loop36_iteration];
                var __loop36_var1 = __tmp28.__loop36_var1;
                var Namespace = __tmp28.Namespace;
                var Declarations = __tmp28.Declarations;
                var c = __tmp28.c;
                string __tmp29Prefix = "            "; //637:1
                StringBuilder __tmp30 = new StringBuilder();
                __tmp30.Append(GenerateModelConstantImpl(model, c, mobjToName));
                using(StreamReader __tmp30Reader = new StreamReader(this.__ToStream(__tmp30.ToString())))
                {
                    bool __tmp30_first = true;
                    bool __tmp30_last = __tmp30Reader.EndOfStream;
                    while(__tmp30_first || !__tmp30_last)
                    {
                        __tmp30_first = false;
                        string __tmp30Line = __tmp30Reader.ReadLine();
                        __tmp30_last = __tmp30Reader.EndOfStream;
                        __out.Append(__tmp29Prefix);
                        if (__tmp30Line != null) __out.Append(__tmp30Line);
                        if (!__tmp30_last) __out.AppendLine(true);
                        __out.AppendLine(false); //637:62
                    }
                }
            }
            __out.AppendLine(true); //639:1
            var __loop37_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //640:10
                select new { mobj = mobj}
                ).ToList(); //640:5
            for (int __loop37_iteration = 0; __loop37_iteration < __loop37_results.Count; ++__loop37_iteration)
            {
                var __tmp31 = __loop37_results[__loop37_iteration];
                var mobj = __tmp31.mobj;
                string __tmp32Prefix = "			"; //641:1
                StringBuilder __tmp33 = new StringBuilder();
                __tmp33.Append(GenerateModelObjectInstance(mobj, mobjToName));
                using(StreamReader __tmp33Reader = new StreamReader(this.__ToStream(__tmp33.ToString())))
                {
                    bool __tmp33_first = true;
                    bool __tmp33_last = __tmp33Reader.EndOfStream;
                    while(__tmp33_first || !__tmp33_last)
                    {
                        __tmp33_first = false;
                        string __tmp33Line = __tmp33Reader.ReadLine();
                        __tmp33_last = __tmp33Reader.EndOfStream;
                        __out.Append(__tmp32Prefix);
                        if (__tmp33Line != null) __out.Append(__tmp33Line);
                        if (!__tmp33_last) __out.AppendLine(true);
                        __out.AppendLine(false); //641:51
                    }
                }
            }
            __out.AppendLine(true); //643:1
            var __loop38_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //644:10
                select new { mobj = mobj}
                ).ToList(); //644:5
            for (int __loop38_iteration = 0; __loop38_iteration < __loop38_results.Count; ++__loop38_iteration)
            {
                var __tmp34 = __loop38_results[__loop38_iteration];
                var mobj = __tmp34.mobj;
                string __tmp35Prefix = "			"; //645:1
                StringBuilder __tmp36 = new StringBuilder();
                __tmp36.Append(GenerateModelObjectInstanceInitializer(mobj, mobjToName));
                using(StreamReader __tmp36Reader = new StreamReader(this.__ToStream(__tmp36.ToString())))
                {
                    bool __tmp36_first = true;
                    bool __tmp36_last = __tmp36Reader.EndOfStream;
                    while(__tmp36_first || !__tmp36_last)
                    {
                        __tmp36_first = false;
                        string __tmp36Line = __tmp36Reader.ReadLine();
                        __tmp36_last = __tmp36Reader.EndOfStream;
                        __out.Append(__tmp35Prefix);
                        if (__tmp36Line != null) __out.Append(__tmp36Line);
                        if (!__tmp36_last) __out.AppendLine(true);
                        __out.AppendLine(false); //645:62
                    }
                }
            }
            __out.AppendLine(true); //647:1
            string __tmp37Prefix = "            "; //648:1
            StringBuilder __tmp38 = new StringBuilder();
            __tmp38.Append(model.CSharpInstancesName());
            using(StreamReader __tmp38Reader = new StreamReader(this.__ToStream(__tmp38.ToString())))
            {
                bool __tmp38_first = true;
                bool __tmp38_last = __tmp38Reader.EndOfStream;
                while(__tmp38_first || !__tmp38_last)
                {
                    __tmp38_first = false;
                    string __tmp38Line = __tmp38Reader.ReadLine();
                    __tmp38_last = __tmp38Reader.EndOfStream;
                    __out.Append(__tmp37Prefix);
                    if (__tmp38Line != null) __out.Append(__tmp38Line);
                    if (!__tmp38_last) __out.AppendLine(true);
                }
            }
            string __tmp39Line = ".model.EvalLazyValues();"; //648:42
            if (__tmp39Line != null) __out.Append(__tmp39Line);
            __out.AppendLine(false); //648:66
            __out.Append("		}"); //649:1
            __out.AppendLine(false); //649:4
            __out.Append("    }"); //650:1
            __out.AppendLine(false); //650:6
            __out.Append("}"); //651:1
            __out.AppendLine(false); //651:2
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceDeclaration(ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //655:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //656:2
            {
                if (mobjToName.ContainsKey(mobj)) //657:3
                {
                    string name = mobjToName[mobj]; //658:4
                    if (name.StartsWith("__")) //659:4
                    {
                        string __tmp2Line = "private static readonly global::MetaDslx.Core."; //660:1
                        if (__tmp2Line != null) __out.Append(__tmp2Line);
                        StringBuilder __tmp3 = new StringBuilder();
                        __tmp3.Append(mobj.MMetaClass.CSharpName());
                        using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                        {
                            bool __tmp3_first = true;
                            bool __tmp3_last = __tmp3Reader.EndOfStream;
                            while(__tmp3_first || !__tmp3_last)
                            {
                                __tmp3_first = false;
                                string __tmp3Line = __tmp3Reader.ReadLine();
                                __tmp3_last = __tmp3Reader.EndOfStream;
                                if (__tmp3Line != null) __out.Append(__tmp3Line);
                                if (!__tmp3_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp4Line = " "; //660:77
                        if (__tmp4Line != null) __out.Append(__tmp4Line);
                        StringBuilder __tmp5 = new StringBuilder();
                        __tmp5.Append(name);
                        using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                        {
                            bool __tmp5_first = true;
                            bool __tmp5_last = __tmp5Reader.EndOfStream;
                            while(__tmp5_first || !__tmp5_last)
                            {
                                __tmp5_first = false;
                                string __tmp5Line = __tmp5Reader.ReadLine();
                                __tmp5_last = __tmp5Reader.EndOfStream;
                                if (__tmp5Line != null) __out.Append(__tmp5Line);
                                if (!__tmp5_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp6Line = ";"; //660:84
                        if (__tmp6Line != null) __out.Append(__tmp6Line);
                        __out.AppendLine(false); //660:85
                    }
                    else //661:4
                    {
                        if (mobj is MetaDocumentedElement) //662:5
                        {
                            StringBuilder __tmp8 = new StringBuilder();
                            __tmp8.Append(GenerateDocumentation(((MetaDocumentedElement)mobj)));
                            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                            {
                                bool __tmp8_first = true;
                                bool __tmp8_last = __tmp8Reader.EndOfStream;
                                while(__tmp8_first || !__tmp8_last)
                                {
                                    __tmp8_first = false;
                                    string __tmp8Line = __tmp8Reader.ReadLine();
                                    __tmp8_last = __tmp8Reader.EndOfStream;
                                    if (__tmp8Line != null) __out.Append(__tmp8Line);
                                    if (!__tmp8_last) __out.AppendLine(true);
                                    __out.AppendLine(false); //663:55
                                }
                            }
                        }
                        string __tmp10Line = "public static readonly global::MetaDslx.Core."; //665:1
                        if (__tmp10Line != null) __out.Append(__tmp10Line);
                        StringBuilder __tmp11 = new StringBuilder();
                        __tmp11.Append(mobj.MMetaClass.CSharpName());
                        using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                        {
                            bool __tmp11_first = true;
                            bool __tmp11_last = __tmp11Reader.EndOfStream;
                            while(__tmp11_first || !__tmp11_last)
                            {
                                __tmp11_first = false;
                                string __tmp11Line = __tmp11Reader.ReadLine();
                                __tmp11_last = __tmp11Reader.EndOfStream;
                                if (__tmp11Line != null) __out.Append(__tmp11Line);
                                if (!__tmp11_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp12Line = " "; //665:76
                        if (__tmp12Line != null) __out.Append(__tmp12Line);
                        StringBuilder __tmp13 = new StringBuilder();
                        __tmp13.Append(name);
                        using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                        {
                            bool __tmp13_first = true;
                            bool __tmp13_last = __tmp13Reader.EndOfStream;
                            while(__tmp13_first || !__tmp13_last)
                            {
                                __tmp13_first = false;
                                string __tmp13Line = __tmp13Reader.ReadLine();
                                __tmp13_last = __tmp13Reader.EndOfStream;
                                if (__tmp13Line != null) __out.Append(__tmp13Line);
                                if (!__tmp13_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp14Line = ";"; //665:83
                        if (__tmp14Line != null) __out.Append(__tmp14Line);
                        __out.AppendLine(false); //665:84
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstance(ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //672:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //673:2
            {
                if (mobjToName.ContainsKey(mobj)) //674:3
                {
                    string name = mobjToName[mobj]; //675:4
                    StringBuilder __tmp2 = new StringBuilder();
                    __tmp2.Append(name);
                    using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
                    {
                        bool __tmp2_first = true;
                        bool __tmp2_last = __tmp2Reader.EndOfStream;
                        while(__tmp2_first || !__tmp2_last)
                        {
                            __tmp2_first = false;
                            string __tmp2Line = __tmp2Reader.ReadLine();
                            __tmp2_last = __tmp2Reader.EndOfStream;
                            if (__tmp2Line != null) __out.Append(__tmp2Line);
                            if (!__tmp2_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp3Line = " = global::MetaDslx.Core.MetaFactory.Instance.Create"; //676:7
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    StringBuilder __tmp4 = new StringBuilder();
                    __tmp4.Append(mobj.MMetaClass.CSharpName());
                    using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                    {
                        bool __tmp4_first = true;
                        bool __tmp4_last = __tmp4Reader.EndOfStream;
                        while(__tmp4_first || !__tmp4_last)
                        {
                            __tmp4_first = false;
                            string __tmp4Line = __tmp4Reader.ReadLine();
                            __tmp4_last = __tmp4Reader.EndOfStream;
                            if (__tmp4Line != null) __out.Append(__tmp4Line);
                            if (!__tmp4_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp5Line = "();"; //676:89
                    if (__tmp5Line != null) __out.Append(__tmp5Line);
                    __out.AppendLine(false); //676:92
                    if (mobj is MetaModel) //677:4
                    {
                        string __tmp7Line = "Meta = "; //678:1
                        if (__tmp7Line != null) __out.Append(__tmp7Line);
                        StringBuilder __tmp8 = new StringBuilder();
                        __tmp8.Append(name);
                        using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                        {
                            bool __tmp8_first = true;
                            bool __tmp8_last = __tmp8Reader.EndOfStream;
                            while(__tmp8_first || !__tmp8_last)
                            {
                                __tmp8_first = false;
                                string __tmp8Line = __tmp8Reader.ReadLine();
                                __tmp8_last = __tmp8Reader.EndOfStream;
                                if (__tmp8Line != null) __out.Append(__tmp8Line);
                                if (!__tmp8_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp9Line = ";"; //678:14
                        if (__tmp9Line != null) __out.Append(__tmp9Line);
                        __out.AppendLine(false); //678:15
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceInitializer(ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //685:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //686:2
            {
                if (mobjToName.ContainsKey(mobj)) //687:3
                {
                    var __loop39_results = 
                        (from __loop39_var1 in __Enumerate((mobj).GetEnumerator()) //688:9
                        from prop in __Enumerate((__loop39_var1.MGetAllProperties()).GetEnumerator()) //688:15
                        select new { __loop39_var1 = __loop39_var1, prop = prop}
                        ).ToList(); //688:4
                    for (int __loop39_iteration = 0; __loop39_iteration < __loop39_results.Count; ++__loop39_iteration)
                    {
                        var __tmp1 = __loop39_results[__loop39_iteration];
                        var __loop39_var1 = __tmp1.__loop39_var1;
                        var prop = __tmp1.prop;
                        if (prop.MetaProperty != null && prop.MetaProperty.Kind != MetaPropertyKind.Derived) //689:5
                        {
                            object propValue = mobj.MGet(prop); //690:6
                            StringBuilder __tmp3 = new StringBuilder();
                            __tmp3.Append(GenerateModelObjectPropertyValue(mobj, prop, propValue, mobjToName));
                            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                            {
                                bool __tmp3_first = true;
                                bool __tmp3_last = __tmp3Reader.EndOfStream;
                                while(__tmp3_first || !__tmp3_last)
                                {
                                    __tmp3_first = false;
                                    string __tmp3Line = __tmp3Reader.ReadLine();
                                    __tmp3_last = __tmp3Reader.EndOfStream;
                                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                                    if (!__tmp3_last) __out.AppendLine(true);
                                    __out.AppendLine(false); //691:70
                                }
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectPropertyValue(ModelObject mobj, ModelProperty prop, object value, Dictionary<ModelObject,string> mobjToName) //699:1
        {
            StringBuilder __out = new StringBuilder();
            string name = mobjToName[mobj]; //700:2
            string propDeclName = "global::" + prop.DeclaringType.FullName.Replace("+", ".") + "." + prop.DeclaredName; //701:2
            if (!prop.IsCollection) //702:2
            {
                string __tmp2Line = "((ModelObject)"; //703:1
                if (__tmp2Line != null) __out.Append(__tmp2Line);
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(name);
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_first = true;
                    bool __tmp3_last = __tmp3Reader.EndOfStream;
                    while(__tmp3_first || !__tmp3_last)
                    {
                        __tmp3_first = false;
                        string __tmp3Line = __tmp3Reader.ReadLine();
                        __tmp3_last = __tmp3Reader.EndOfStream;
                        if (__tmp3Line != null) __out.Append(__tmp3Line);
                        if (!__tmp3_last) __out.AppendLine(true);
                    }
                }
                string __tmp4Line = ").MUnSet("; //703:21
                if (__tmp4Line != null) __out.Append(__tmp4Line);
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(propDeclName);
                using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                {
                    bool __tmp5_first = true;
                    bool __tmp5_last = __tmp5Reader.EndOfStream;
                    while(__tmp5_first || !__tmp5_last)
                    {
                        __tmp5_first = false;
                        string __tmp5Line = __tmp5Reader.ReadLine();
                        __tmp5_last = __tmp5Reader.EndOfStream;
                        if (__tmp5Line != null) __out.Append(__tmp5Line);
                        if (!__tmp5_last) __out.AppendLine(true);
                    }
                }
                string __tmp6Line = ");"; //703:44
                if (__tmp6Line != null) __out.Append(__tmp6Line);
                __out.AppendLine(false); //703:46
            }
            ModelObject moValue = value as ModelObject; //705:2
            if (value == null) //706:2
            {
                string __tmp8Line = "((ModelObject)"; //707:1
                if (__tmp8Line != null) __out.Append(__tmp8Line);
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append(name);
                using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                {
                    bool __tmp9_first = true;
                    bool __tmp9_last = __tmp9Reader.EndOfStream;
                    while(__tmp9_first || !__tmp9_last)
                    {
                        __tmp9_first = false;
                        string __tmp9Line = __tmp9Reader.ReadLine();
                        __tmp9_last = __tmp9Reader.EndOfStream;
                        if (__tmp9Line != null) __out.Append(__tmp9Line);
                        if (!__tmp9_last) __out.AppendLine(true);
                    }
                }
                string __tmp10Line = ").MLazyAdd("; //707:21
                if (__tmp10Line != null) __out.Append(__tmp10Line);
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(propDeclName);
                using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                {
                    bool __tmp11_first = true;
                    bool __tmp11_last = __tmp11Reader.EndOfStream;
                    while(__tmp11_first || !__tmp11_last)
                    {
                        __tmp11_first = false;
                        string __tmp11Line = __tmp11Reader.ReadLine();
                        __tmp11_last = __tmp11Reader.EndOfStream;
                        if (__tmp11Line != null) __out.Append(__tmp11Line);
                        if (!__tmp11_last) __out.AppendLine(true);
                    }
                }
                string __tmp12Line = ", new Lazy<object>(() => null, LazyThreadSafetyMode.ExecutionAndPublication));"; //707:46
                if (__tmp12Line != null) __out.Append(__tmp12Line);
                __out.AppendLine(false); //707:124
            }
            else if (value is string) //708:2
            {
                string __tmp14Line = "((ModelObject)"; //709:1
                if (__tmp14Line != null) __out.Append(__tmp14Line);
                StringBuilder __tmp15 = new StringBuilder();
                __tmp15.Append(name);
                using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
                {
                    bool __tmp15_first = true;
                    bool __tmp15_last = __tmp15Reader.EndOfStream;
                    while(__tmp15_first || !__tmp15_last)
                    {
                        __tmp15_first = false;
                        string __tmp15Line = __tmp15Reader.ReadLine();
                        __tmp15_last = __tmp15Reader.EndOfStream;
                        if (__tmp15Line != null) __out.Append(__tmp15Line);
                        if (!__tmp15_last) __out.AppendLine(true);
                    }
                }
                string __tmp16Line = ").MLazyAdd("; //709:21
                if (__tmp16Line != null) __out.Append(__tmp16Line);
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(propDeclName);
                using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
                {
                    bool __tmp17_first = true;
                    bool __tmp17_last = __tmp17Reader.EndOfStream;
                    while(__tmp17_first || !__tmp17_last)
                    {
                        __tmp17_first = false;
                        string __tmp17Line = __tmp17Reader.ReadLine();
                        __tmp17_last = __tmp17Reader.EndOfStream;
                        if (__tmp17Line != null) __out.Append(__tmp17Line);
                        if (!__tmp17_last) __out.AppendLine(true);
                    }
                }
                string __tmp18Line = ", new Lazy<object>(() => \""; //709:46
                if (__tmp18Line != null) __out.Append(__tmp18Line);
                StringBuilder __tmp19 = new StringBuilder();
                __tmp19.Append(value);
                using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
                {
                    bool __tmp19_first = true;
                    bool __tmp19_last = __tmp19Reader.EndOfStream;
                    while(__tmp19_first || !__tmp19_last)
                    {
                        __tmp19_first = false;
                        string __tmp19Line = __tmp19Reader.ReadLine();
                        __tmp19_last = __tmp19Reader.EndOfStream;
                        if (__tmp19Line != null) __out.Append(__tmp19Line);
                        if (!__tmp19_last) __out.AppendLine(true);
                    }
                }
                string __tmp20Line = "\", LazyThreadSafetyMode.ExecutionAndPublication));"; //709:79
                if (__tmp20Line != null) __out.Append(__tmp20Line);
                __out.AppendLine(false); //709:129
            }
            else if (value is bool) //710:2
            {
                string __tmp22Line = "((ModelObject)"; //711:1
                if (__tmp22Line != null) __out.Append(__tmp22Line);
                StringBuilder __tmp23 = new StringBuilder();
                __tmp23.Append(name);
                using(StreamReader __tmp23Reader = new StreamReader(this.__ToStream(__tmp23.ToString())))
                {
                    bool __tmp23_first = true;
                    bool __tmp23_last = __tmp23Reader.EndOfStream;
                    while(__tmp23_first || !__tmp23_last)
                    {
                        __tmp23_first = false;
                        string __tmp23Line = __tmp23Reader.ReadLine();
                        __tmp23_last = __tmp23Reader.EndOfStream;
                        if (__tmp23Line != null) __out.Append(__tmp23Line);
                        if (!__tmp23_last) __out.AppendLine(true);
                    }
                }
                string __tmp24Line = ").MLazyAdd("; //711:21
                if (__tmp24Line != null) __out.Append(__tmp24Line);
                StringBuilder __tmp25 = new StringBuilder();
                __tmp25.Append(propDeclName);
                using(StreamReader __tmp25Reader = new StreamReader(this.__ToStream(__tmp25.ToString())))
                {
                    bool __tmp25_first = true;
                    bool __tmp25_last = __tmp25Reader.EndOfStream;
                    while(__tmp25_first || !__tmp25_last)
                    {
                        __tmp25_first = false;
                        string __tmp25Line = __tmp25Reader.ReadLine();
                        __tmp25_last = __tmp25Reader.EndOfStream;
                        if (__tmp25Line != null) __out.Append(__tmp25Line);
                        if (!__tmp25_last) __out.AppendLine(true);
                    }
                }
                string __tmp26Line = ", new Lazy<object>(() => "; //711:46
                if (__tmp26Line != null) __out.Append(__tmp26Line);
                StringBuilder __tmp27 = new StringBuilder();
                __tmp27.Append(value.ToString().ToLower());
                using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
                {
                    bool __tmp27_first = true;
                    bool __tmp27_last = __tmp27Reader.EndOfStream;
                    while(__tmp27_first || !__tmp27_last)
                    {
                        __tmp27_first = false;
                        string __tmp27Line = __tmp27Reader.ReadLine();
                        __tmp27_last = __tmp27Reader.EndOfStream;
                        if (__tmp27Line != null) __out.Append(__tmp27Line);
                        if (!__tmp27_last) __out.AppendLine(true);
                    }
                }
                string __tmp28Line = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //711:99
                if (__tmp28Line != null) __out.Append(__tmp28Line);
                __out.AppendLine(false); //711:148
            }
            else if (value.GetType().IsPrimitive) //712:2
            {
                string __tmp30Line = "((ModelObject)"; //713:1
                if (__tmp30Line != null) __out.Append(__tmp30Line);
                StringBuilder __tmp31 = new StringBuilder();
                __tmp31.Append(name);
                using(StreamReader __tmp31Reader = new StreamReader(this.__ToStream(__tmp31.ToString())))
                {
                    bool __tmp31_first = true;
                    bool __tmp31_last = __tmp31Reader.EndOfStream;
                    while(__tmp31_first || !__tmp31_last)
                    {
                        __tmp31_first = false;
                        string __tmp31Line = __tmp31Reader.ReadLine();
                        __tmp31_last = __tmp31Reader.EndOfStream;
                        if (__tmp31Line != null) __out.Append(__tmp31Line);
                        if (!__tmp31_last) __out.AppendLine(true);
                    }
                }
                string __tmp32Line = ").MLazyAdd("; //713:21
                if (__tmp32Line != null) __out.Append(__tmp32Line);
                StringBuilder __tmp33 = new StringBuilder();
                __tmp33.Append(propDeclName);
                using(StreamReader __tmp33Reader = new StreamReader(this.__ToStream(__tmp33.ToString())))
                {
                    bool __tmp33_first = true;
                    bool __tmp33_last = __tmp33Reader.EndOfStream;
                    while(__tmp33_first || !__tmp33_last)
                    {
                        __tmp33_first = false;
                        string __tmp33Line = __tmp33Reader.ReadLine();
                        __tmp33_last = __tmp33Reader.EndOfStream;
                        if (__tmp33Line != null) __out.Append(__tmp33Line);
                        if (!__tmp33_last) __out.AppendLine(true);
                    }
                }
                string __tmp34Line = ", new Lazy<object>(() => "; //713:46
                if (__tmp34Line != null) __out.Append(__tmp34Line);
                StringBuilder __tmp35 = new StringBuilder();
                __tmp35.Append(value.ToString());
                using(StreamReader __tmp35Reader = new StreamReader(this.__ToStream(__tmp35.ToString())))
                {
                    bool __tmp35_first = true;
                    bool __tmp35_last = __tmp35Reader.EndOfStream;
                    while(__tmp35_first || !__tmp35_last)
                    {
                        __tmp35_first = false;
                        string __tmp35Line = __tmp35Reader.ReadLine();
                        __tmp35_last = __tmp35Reader.EndOfStream;
                        if (__tmp35Line != null) __out.Append(__tmp35Line);
                        if (!__tmp35_last) __out.AppendLine(true);
                    }
                }
                string __tmp36Line = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //713:89
                if (__tmp36Line != null) __out.Append(__tmp36Line);
                __out.AppendLine(false); //713:138
            }
            else if (MetaBuiltInTypes.Types.Contains(value)) //714:2
            {
                string __tmp38Line = "((ModelObject)"; //715:1
                if (__tmp38Line != null) __out.Append(__tmp38Line);
                StringBuilder __tmp39 = new StringBuilder();
                __tmp39.Append(name);
                using(StreamReader __tmp39Reader = new StreamReader(this.__ToStream(__tmp39.ToString())))
                {
                    bool __tmp39_first = true;
                    bool __tmp39_last = __tmp39Reader.EndOfStream;
                    while(__tmp39_first || !__tmp39_last)
                    {
                        __tmp39_first = false;
                        string __tmp39Line = __tmp39Reader.ReadLine();
                        __tmp39_last = __tmp39Reader.EndOfStream;
                        if (__tmp39Line != null) __out.Append(__tmp39Line);
                        if (!__tmp39_last) __out.AppendLine(true);
                    }
                }
                string __tmp40Line = ").MLazyAdd("; //715:21
                if (__tmp40Line != null) __out.Append(__tmp40Line);
                StringBuilder __tmp41 = new StringBuilder();
                __tmp41.Append(propDeclName);
                using(StreamReader __tmp41Reader = new StreamReader(this.__ToStream(__tmp41.ToString())))
                {
                    bool __tmp41_first = true;
                    bool __tmp41_last = __tmp41Reader.EndOfStream;
                    while(__tmp41_first || !__tmp41_last)
                    {
                        __tmp41_first = false;
                        string __tmp41Line = __tmp41Reader.ReadLine();
                        __tmp41_last = __tmp41Reader.EndOfStream;
                        if (__tmp41Line != null) __out.Append(__tmp41Line);
                        if (!__tmp41_last) __out.AppendLine(true);
                    }
                }
                string __tmp42Line = ", new Lazy<object>(() => "; //715:46
                if (__tmp42Line != null) __out.Append(__tmp42Line);
                StringBuilder __tmp43 = new StringBuilder();
                __tmp43.Append(GenerateTypeOf(value));
                using(StreamReader __tmp43Reader = new StreamReader(this.__ToStream(__tmp43.ToString())))
                {
                    bool __tmp43_first = true;
                    bool __tmp43_last = __tmp43Reader.EndOfStream;
                    while(__tmp43_first || !__tmp43_last)
                    {
                        __tmp43_first = false;
                        string __tmp43Line = __tmp43Reader.ReadLine();
                        __tmp43_last = __tmp43Reader.EndOfStream;
                        if (__tmp43Line != null) __out.Append(__tmp43Line);
                        if (!__tmp43_last) __out.AppendLine(true);
                    }
                }
                string __tmp44Line = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //715:94
                if (__tmp44Line != null) __out.Append(__tmp44Line);
                __out.AppendLine(false); //715:143
            }
            else if (value is MetaPrimitiveType) //716:2
            {
                string __tmp46Line = "((ModelObject)"; //717:1
                if (__tmp46Line != null) __out.Append(__tmp46Line);
                StringBuilder __tmp47 = new StringBuilder();
                __tmp47.Append(name);
                using(StreamReader __tmp47Reader = new StreamReader(this.__ToStream(__tmp47.ToString())))
                {
                    bool __tmp47_first = true;
                    bool __tmp47_last = __tmp47Reader.EndOfStream;
                    while(__tmp47_first || !__tmp47_last)
                    {
                        __tmp47_first = false;
                        string __tmp47Line = __tmp47Reader.ReadLine();
                        __tmp47_last = __tmp47Reader.EndOfStream;
                        if (__tmp47Line != null) __out.Append(__tmp47Line);
                        if (!__tmp47_last) __out.AppendLine(true);
                    }
                }
                string __tmp48Line = ").MLazyAdd("; //717:21
                if (__tmp48Line != null) __out.Append(__tmp48Line);
                StringBuilder __tmp49 = new StringBuilder();
                __tmp49.Append(propDeclName);
                using(StreamReader __tmp49Reader = new StreamReader(this.__ToStream(__tmp49.ToString())))
                {
                    bool __tmp49_first = true;
                    bool __tmp49_last = __tmp49Reader.EndOfStream;
                    while(__tmp49_first || !__tmp49_last)
                    {
                        __tmp49_first = false;
                        string __tmp49Line = __tmp49Reader.ReadLine();
                        __tmp49_last = __tmp49Reader.EndOfStream;
                        if (__tmp49Line != null) __out.Append(__tmp49Line);
                        if (!__tmp49_last) __out.AppendLine(true);
                    }
                }
                string __tmp50Line = ", new Lazy<object>(() => "; //717:46
                if (__tmp50Line != null) __out.Append(__tmp50Line);
                StringBuilder __tmp51 = new StringBuilder();
                __tmp51.Append(GenerateTypeOf(value));
                using(StreamReader __tmp51Reader = new StreamReader(this.__ToStream(__tmp51.ToString())))
                {
                    bool __tmp51_first = true;
                    bool __tmp51_last = __tmp51Reader.EndOfStream;
                    while(__tmp51_first || !__tmp51_last)
                    {
                        __tmp51_first = false;
                        string __tmp51Line = __tmp51Reader.ReadLine();
                        __tmp51_last = __tmp51Reader.EndOfStream;
                        if (__tmp51Line != null) __out.Append(__tmp51Line);
                        if (!__tmp51_last) __out.AppendLine(true);
                    }
                }
                string __tmp52Line = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //717:94
                if (__tmp52Line != null) __out.Append(__tmp52Line);
                __out.AppendLine(false); //717:143
            }
            else if (value is Enum) //718:2
            {
                string __tmp54Line = "((ModelObject)"; //719:1
                if (__tmp54Line != null) __out.Append(__tmp54Line);
                StringBuilder __tmp55 = new StringBuilder();
                __tmp55.Append(name);
                using(StreamReader __tmp55Reader = new StreamReader(this.__ToStream(__tmp55.ToString())))
                {
                    bool __tmp55_first = true;
                    bool __tmp55_last = __tmp55Reader.EndOfStream;
                    while(__tmp55_first || !__tmp55_last)
                    {
                        __tmp55_first = false;
                        string __tmp55Line = __tmp55Reader.ReadLine();
                        __tmp55_last = __tmp55Reader.EndOfStream;
                        if (__tmp55Line != null) __out.Append(__tmp55Line);
                        if (!__tmp55_last) __out.AppendLine(true);
                    }
                }
                string __tmp56Line = ").MLazyAdd("; //719:21
                if (__tmp56Line != null) __out.Append(__tmp56Line);
                StringBuilder __tmp57 = new StringBuilder();
                __tmp57.Append(propDeclName);
                using(StreamReader __tmp57Reader = new StreamReader(this.__ToStream(__tmp57.ToString())))
                {
                    bool __tmp57_first = true;
                    bool __tmp57_last = __tmp57Reader.EndOfStream;
                    while(__tmp57_first || !__tmp57_last)
                    {
                        __tmp57_first = false;
                        string __tmp57Line = __tmp57Reader.ReadLine();
                        __tmp57_last = __tmp57Reader.EndOfStream;
                        if (__tmp57Line != null) __out.Append(__tmp57Line);
                        if (!__tmp57_last) __out.AppendLine(true);
                    }
                }
                string __tmp58Line = ", new Lazy<object>(() => "; //719:46
                if (__tmp58Line != null) __out.Append(__tmp58Line);
                StringBuilder __tmp59 = new StringBuilder();
                __tmp59.Append(GetEnumValueOf(value));
                using(StreamReader __tmp59Reader = new StreamReader(this.__ToStream(__tmp59.ToString())))
                {
                    bool __tmp59_first = true;
                    bool __tmp59_last = __tmp59Reader.EndOfStream;
                    while(__tmp59_first || !__tmp59_last)
                    {
                        __tmp59_first = false;
                        string __tmp59Line = __tmp59Reader.ReadLine();
                        __tmp59_last = __tmp59Reader.EndOfStream;
                        if (__tmp59Line != null) __out.Append(__tmp59Line);
                        if (!__tmp59_last) __out.AppendLine(true);
                    }
                }
                string __tmp60Line = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //719:94
                if (__tmp60Line != null) __out.Append(__tmp60Line);
                __out.AppendLine(false); //719:143
            }
            else if (moValue != null) //720:2
            {
                if (mobjToName.ContainsKey(moValue)) //721:3
                {
                    string __tmp62Line = "((ModelObject)"; //722:1
                    if (__tmp62Line != null) __out.Append(__tmp62Line);
                    StringBuilder __tmp63 = new StringBuilder();
                    __tmp63.Append(name);
                    using(StreamReader __tmp63Reader = new StreamReader(this.__ToStream(__tmp63.ToString())))
                    {
                        bool __tmp63_first = true;
                        bool __tmp63_last = __tmp63Reader.EndOfStream;
                        while(__tmp63_first || !__tmp63_last)
                        {
                            __tmp63_first = false;
                            string __tmp63Line = __tmp63Reader.ReadLine();
                            __tmp63_last = __tmp63Reader.EndOfStream;
                            if (__tmp63Line != null) __out.Append(__tmp63Line);
                            if (!__tmp63_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp64Line = ").MLazyAdd("; //722:21
                    if (__tmp64Line != null) __out.Append(__tmp64Line);
                    StringBuilder __tmp65 = new StringBuilder();
                    __tmp65.Append(propDeclName);
                    using(StreamReader __tmp65Reader = new StreamReader(this.__ToStream(__tmp65.ToString())))
                    {
                        bool __tmp65_first = true;
                        bool __tmp65_last = __tmp65Reader.EndOfStream;
                        while(__tmp65_first || !__tmp65_last)
                        {
                            __tmp65_first = false;
                            string __tmp65Line = __tmp65Reader.ReadLine();
                            __tmp65_last = __tmp65Reader.EndOfStream;
                            if (__tmp65Line != null) __out.Append(__tmp65Line);
                            if (!__tmp65_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp66Line = ", new Lazy<object>(() => "; //722:46
                    if (__tmp66Line != null) __out.Append(__tmp66Line);
                    StringBuilder __tmp67 = new StringBuilder();
                    __tmp67.Append(mobjToName[moValue]);
                    using(StreamReader __tmp67Reader = new StreamReader(this.__ToStream(__tmp67.ToString())))
                    {
                        bool __tmp67_first = true;
                        bool __tmp67_last = __tmp67Reader.EndOfStream;
                        while(__tmp67_first || !__tmp67_last)
                        {
                            __tmp67_first = false;
                            string __tmp67Line = __tmp67Reader.ReadLine();
                            __tmp67_last = __tmp67Reader.EndOfStream;
                            if (__tmp67Line != null) __out.Append(__tmp67Line);
                            if (!__tmp67_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp68Line = ", LazyThreadSafetyMode.ExecutionAndPublication));"; //722:92
                    if (__tmp68Line != null) __out.Append(__tmp68Line);
                    __out.AppendLine(false); //722:141
                }
                else //723:3
                {
                    string __tmp70Line = "// Omitted since not part of the model: "; //724:1
                    if (__tmp70Line != null) __out.Append(__tmp70Line);
                    StringBuilder __tmp71 = new StringBuilder();
                    __tmp71.Append(name);
                    using(StreamReader __tmp71Reader = new StreamReader(this.__ToStream(__tmp71.ToString())))
                    {
                        bool __tmp71_first = true;
                        bool __tmp71_last = __tmp71Reader.EndOfStream;
                        while(__tmp71_first || !__tmp71_last)
                        {
                            __tmp71_first = false;
                            string __tmp71Line = __tmp71Reader.ReadLine();
                            __tmp71_last = __tmp71Reader.EndOfStream;
                            if (__tmp71Line != null) __out.Append(__tmp71Line);
                            if (!__tmp71_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp72Line = "."; //724:47
                    if (__tmp72Line != null) __out.Append(__tmp72Line);
                    StringBuilder __tmp73 = new StringBuilder();
                    __tmp73.Append(propDeclName);
                    using(StreamReader __tmp73Reader = new StreamReader(this.__ToStream(__tmp73.ToString())))
                    {
                        bool __tmp73_first = true;
                        bool __tmp73_last = __tmp73Reader.EndOfStream;
                        while(__tmp73_first || !__tmp73_last)
                        {
                            __tmp73_first = false;
                            string __tmp73Line = __tmp73Reader.ReadLine();
                            __tmp73_last = __tmp73Reader.EndOfStream;
                            if (__tmp73Line != null) __out.Append(__tmp73Line);
                            if (!__tmp73_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp74Line = " = "; //724:62
                    if (__tmp74Line != null) __out.Append(__tmp74Line);
                    StringBuilder __tmp75 = new StringBuilder();
                    __tmp75.Append(moValue);
                    using(StreamReader __tmp75Reader = new StreamReader(this.__ToStream(__tmp75.ToString())))
                    {
                        bool __tmp75_first = true;
                        bool __tmp75_last = __tmp75Reader.EndOfStream;
                        while(__tmp75_first || !__tmp75_last)
                        {
                            __tmp75_first = false;
                            string __tmp75Line = __tmp75Reader.ReadLine();
                            __tmp75_last = __tmp75Reader.EndOfStream;
                            if (__tmp75Line != null) __out.Append(__tmp75Line);
                            if (!__tmp75_last) __out.AppendLine(true);
                            __out.AppendLine(false); //724:74
                        }
                    }
                }
            }
            else //726:2
            {
                IEnumerable<object> mc = (value as ModelCollection) as IEnumerable<object>; //727:3
                if (mc != null) //728:3
                {
                    var __loop40_results = 
                        (from cvalue in __Enumerate((mc).GetEnumerator()) //729:9
                        select new { cvalue = cvalue}
                        ).ToList(); //729:4
                    for (int __loop40_iteration = 0; __loop40_iteration < __loop40_results.Count; ++__loop40_iteration)
                    {
                        var __tmp76 = __loop40_results[__loop40_iteration];
                        var cvalue = __tmp76.cvalue;
                        StringBuilder __tmp78 = new StringBuilder();
                        __tmp78.Append(GenerateModelObjectPropertyValue(mobj, prop, cvalue, mobjToName));
                        using(StreamReader __tmp78Reader = new StreamReader(this.__ToStream(__tmp78.ToString())))
                        {
                            bool __tmp78_first = true;
                            bool __tmp78_last = __tmp78Reader.EndOfStream;
                            while(__tmp78_first || !__tmp78_last)
                            {
                                __tmp78_first = false;
                                string __tmp78Line = __tmp78Reader.ReadLine();
                                __tmp78_last = __tmp78Reader.EndOfStream;
                                if (__tmp78Line != null) __out.Append(__tmp78Line);
                                if (!__tmp78_last) __out.AppendLine(true);
                                __out.AppendLine(false); //730:67
                            }
                        }
                    }
                }
                else //732:3
                {
                    string __tmp80Line = "// Invalid property value type: "; //733:1
                    if (__tmp80Line != null) __out.Append(__tmp80Line);
                    StringBuilder __tmp81 = new StringBuilder();
                    __tmp81.Append(name);
                    using(StreamReader __tmp81Reader = new StreamReader(this.__ToStream(__tmp81.ToString())))
                    {
                        bool __tmp81_first = true;
                        bool __tmp81_last = __tmp81Reader.EndOfStream;
                        while(__tmp81_first || !__tmp81_last)
                        {
                            __tmp81_first = false;
                            string __tmp81Line = __tmp81Reader.ReadLine();
                            __tmp81_last = __tmp81Reader.EndOfStream;
                            if (__tmp81Line != null) __out.Append(__tmp81Line);
                            if (!__tmp81_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp82Line = "."; //733:39
                    if (__tmp82Line != null) __out.Append(__tmp82Line);
                    StringBuilder __tmp83 = new StringBuilder();
                    __tmp83.Append(propDeclName);
                    using(StreamReader __tmp83Reader = new StreamReader(this.__ToStream(__tmp83.ToString())))
                    {
                        bool __tmp83_first = true;
                        bool __tmp83_last = __tmp83Reader.EndOfStream;
                        while(__tmp83_first || !__tmp83_last)
                        {
                            __tmp83_first = false;
                            string __tmp83Line = __tmp83Reader.ReadLine();
                            __tmp83_last = __tmp83Reader.EndOfStream;
                            if (__tmp83Line != null) __out.Append(__tmp83Line);
                            if (!__tmp83_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp84Line = " = "; //733:54
                    if (__tmp84Line != null) __out.Append(__tmp84Line);
                    StringBuilder __tmp85 = new StringBuilder();
                    __tmp85.Append(value.GetType());
                    using(StreamReader __tmp85Reader = new StreamReader(this.__ToStream(__tmp85.ToString())))
                    {
                        bool __tmp85_first = true;
                        bool __tmp85_last = __tmp85Reader.EndOfStream;
                        while(__tmp85_first || !__tmp85_last)
                        {
                            __tmp85_first = false;
                            string __tmp85Line = __tmp85Reader.ReadLine();
                            __tmp85_last = __tmp85Reader.EndOfStream;
                            if (__tmp85Line != null) __out.Append(__tmp85Line);
                            if (!__tmp85_last) __out.AppendLine(true);
                            __out.AppendLine(false); //733:74
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GetInstanceName(ModelObject mobj) //739:1
        {
            MetaAnnotatedElement mannot = mobj as MetaAnnotatedElement; //740:2
            if (mannot != null && !(mobj is MetaConstant)) //741:2
            {
                var __loop41_results = 
                    (from __loop41_var1 in __Enumerate((mannot).GetEnumerator()) //742:8
                    from a in __Enumerate((__loop41_var1.Annotations).GetEnumerator()) //742:16
                    from p in __Enumerate((a.Properties).GetEnumerator()) //742:31
                    where a.Name == "BuiltInName" && p.Name == "Name" //742:44
                    select new { __loop41_var1 = __loop41_var1, a = a, p = p}
                    ).ToList(); //742:3
                for (int __loop41_iteration = 0; __loop41_iteration < __loop41_results.Count; ++__loop41_iteration)
                {
                    var __tmp1 = __loop41_results[__loop41_iteration];
                    var __loop41_var1 = __tmp1.__loop41_var1;
                    var a = __tmp1.a;
                    var p = __tmp1.p;
                    return GetCSharpIdentifier(p.Value); //743:4
                }
            }
            MetaDeclaration mdecl = mobj as MetaDeclaration; //746:2
            if (mdecl != null && !(mdecl is MetaOperation) && !(mobj is MetaConstant)) //747:2
            {
                return mdecl.CSharpInstanceName(); //748:3
            }
            MetaProperty mprop = mobj as MetaProperty; //750:2
            if (mprop != null) //751:2
            {
                return mprop.CSharpInstanceName(); //752:3
            }
            return null; //754:2
        }

        public string GetEnumValueOf(object enm) //759:1
        {
            return "global::" + enm.GetType().FullName.Replace("+", ".") + "." + enm.ToString(); //760:2
        }

        public string GenerateClassMetaInstance(MetaClass cls) //763:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(cls.CSharpName());
            using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
            {
                bool __tmp2_first = true;
                bool __tmp2_last = __tmp2Reader.EndOfStream;
                while(__tmp2_first || !__tmp2_last)
                {
                    __tmp2_first = false;
                    string __tmp2Line = __tmp2Reader.ReadLine();
                    __tmp2_last = __tmp2Reader.EndOfStream;
                    if (__tmp2Line != null) __out.Append(__tmp2Line);
                    if (!__tmp2_last) __out.AppendLine(true);
                }
            }
            string __tmp3Line = " = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();"; //764:19
            if (__tmp3Line != null) __out.Append(__tmp3Line);
            __out.AppendLine(false); //764:83
            return __out.ToString();
        }

        public string GenerateClassMetaInstanceInitializer(MetaClass cls) //767:1
        {
            StringBuilder __out = new StringBuilder();
            StringBuilder __tmp2 = new StringBuilder();
            __tmp2.Append(cls.CSharpName());
            using(StreamReader __tmp2Reader = new StreamReader(this.__ToStream(__tmp2.ToString())))
            {
                bool __tmp2_first = true;
                bool __tmp2_last = __tmp2Reader.EndOfStream;
                while(__tmp2_first || !__tmp2_last)
                {
                    __tmp2_first = false;
                    string __tmp2Line = __tmp2Reader.ReadLine();
                    __tmp2_last = __tmp2Reader.EndOfStream;
                    if (__tmp2Line != null) __out.Append(__tmp2Line);
                    if (!__tmp2_last) __out.AppendLine(true);
                }
            }
            string __tmp3Line = ".Name = \""; //768:19
            if (__tmp3Line != null) __out.Append(__tmp3Line);
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(cls.CSharpName());
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_first = true;
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(__tmp4_first || !__tmp4_last)
                {
                    __tmp4_first = false;
                    string __tmp4Line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (__tmp4Line != null) __out.Append(__tmp4Line);
                    if (!__tmp4_last) __out.AppendLine(true);
                }
            }
            string __tmp5Line = "\";"; //768:46
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            __out.AppendLine(false); //768:48
            if (cls.IsAbstract) //769:2
            {
                StringBuilder __tmp7 = new StringBuilder();
                __tmp7.Append(cls.CSharpName());
                using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
                {
                    bool __tmp7_first = true;
                    bool __tmp7_last = __tmp7Reader.EndOfStream;
                    while(__tmp7_first || !__tmp7_last)
                    {
                        __tmp7_first = false;
                        string __tmp7Line = __tmp7Reader.ReadLine();
                        __tmp7_last = __tmp7Reader.EndOfStream;
                        if (__tmp7Line != null) __out.Append(__tmp7Line);
                        if (!__tmp7_last) __out.AppendLine(true);
                    }
                }
                string __tmp8Line = ".IsAbstract = true;"; //770:19
                if (__tmp8Line != null) __out.Append(__tmp8Line);
                __out.AppendLine(false); //770:38
            }
            var __loop42_results = 
                (from __loop42_var1 in __Enumerate((cls).GetEnumerator()) //772:7
                from sup in __Enumerate((__loop42_var1.SuperClasses).GetEnumerator()) //772:12
                select new { __loop42_var1 = __loop42_var1, sup = sup}
                ).ToList(); //772:2
            for (int __loop42_iteration = 0; __loop42_iteration < __loop42_results.Count; ++__loop42_iteration)
            {
                var __tmp9 = __loop42_results[__loop42_iteration];
                var __loop42_var1 = __tmp9.__loop42_var1;
                var sup = __tmp9.sup;
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(cls.CSharpName());
                using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                {
                    bool __tmp11_first = true;
                    bool __tmp11_last = __tmp11Reader.EndOfStream;
                    while(__tmp11_first || !__tmp11_last)
                    {
                        __tmp11_first = false;
                        string __tmp11Line = __tmp11Reader.ReadLine();
                        __tmp11_last = __tmp11Reader.EndOfStream;
                        if (__tmp11Line != null) __out.Append(__tmp11Line);
                        if (!__tmp11_last) __out.AppendLine(true);
                    }
                }
                string __tmp12Line = ".SuperClasses.Add("; //773:19
                if (__tmp12Line != null) __out.Append(__tmp12Line);
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(sup.CSharpFullInstanceName());
                using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                {
                    bool __tmp13_first = true;
                    bool __tmp13_last = __tmp13Reader.EndOfStream;
                    while(__tmp13_first || !__tmp13_last)
                    {
                        __tmp13_first = false;
                        string __tmp13Line = __tmp13Reader.ReadLine();
                        __tmp13_last = __tmp13Reader.EndOfStream;
                        if (__tmp13Line != null) __out.Append(__tmp13Line);
                        if (!__tmp13_last) __out.AppendLine(true);
                    }
                }
                string __tmp14Line = ");"; //773:67
                if (__tmp14Line != null) __out.Append(__tmp14Line);
                __out.AppendLine(false); //773:69
            }
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //778:1
        {
            StringBuilder __out = new StringBuilder();
            string __tmp2Line = "internal static class "; //779:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.Name);
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(__tmp3_first || !__tmp3_last)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    if (!__tmp3_last) __out.AppendLine(true);
                }
            }
            string __tmp4Line = "ImplementationProvider"; //779:35
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //779:57
            __out.Append("{"); //780:1
            __out.AppendLine(false); //780:2
            string __tmp6Line = "    // If there is a compile error at this line, create a new class called "; //781:1
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(model.Name);
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_first = true;
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(__tmp7_first || !__tmp7_last)
                {
                    __tmp7_first = false;
                    string __tmp7Line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    if (__tmp7Line != null) __out.Append(__tmp7Line);
                    if (!__tmp7_last) __out.AppendLine(true);
                }
            }
            string __tmp8Line = "Implementation"; //781:88
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            __out.AppendLine(false); //781:102
            string __tmp10Line = "	// which is a subclass of "; //782:1
            if (__tmp10Line != null) __out.Append(__tmp10Line);
            StringBuilder __tmp11 = new StringBuilder();
            __tmp11.Append(model.Name);
            using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
            {
                bool __tmp11_first = true;
                bool __tmp11_last = __tmp11Reader.EndOfStream;
                while(__tmp11_first || !__tmp11_last)
                {
                    __tmp11_first = false;
                    string __tmp11Line = __tmp11Reader.ReadLine();
                    __tmp11_last = __tmp11Reader.EndOfStream;
                    if (__tmp11Line != null) __out.Append(__tmp11Line);
                    if (!__tmp11_last) __out.AppendLine(true);
                }
            }
            string __tmp12Line = "ImplementationBase:"; //782:40
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            __out.AppendLine(false); //782:59
            string __tmp14Line = "    private static "; //783:1
            if (__tmp14Line != null) __out.Append(__tmp14Line);
            StringBuilder __tmp15 = new StringBuilder();
            __tmp15.Append(model.Name);
            using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
            {
                bool __tmp15_first = true;
                bool __tmp15_last = __tmp15Reader.EndOfStream;
                while(__tmp15_first || !__tmp15_last)
                {
                    __tmp15_first = false;
                    string __tmp15Line = __tmp15Reader.ReadLine();
                    __tmp15_last = __tmp15Reader.EndOfStream;
                    if (__tmp15Line != null) __out.Append(__tmp15Line);
                    if (!__tmp15_last) __out.AppendLine(true);
                }
            }
            string __tmp16Line = "Implementation implementation = new "; //783:32
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(model.Name);
            using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
            {
                bool __tmp17_first = true;
                bool __tmp17_last = __tmp17Reader.EndOfStream;
                while(__tmp17_first || !__tmp17_last)
                {
                    __tmp17_first = false;
                    string __tmp17Line = __tmp17Reader.ReadLine();
                    __tmp17_last = __tmp17Reader.EndOfStream;
                    if (__tmp17Line != null) __out.Append(__tmp17Line);
                    if (!__tmp17_last) __out.AppendLine(true);
                }
            }
            string __tmp18Line = "Implementation();"; //783:80
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //783:97
            __out.AppendLine(true); //784:1
            string __tmp20Line = "    public static "; //785:1
            if (__tmp20Line != null) __out.Append(__tmp20Line);
            StringBuilder __tmp21 = new StringBuilder();
            __tmp21.Append(model.Name);
            using(StreamReader __tmp21Reader = new StreamReader(this.__ToStream(__tmp21.ToString())))
            {
                bool __tmp21_first = true;
                bool __tmp21_last = __tmp21Reader.EndOfStream;
                while(__tmp21_first || !__tmp21_last)
                {
                    __tmp21_first = false;
                    string __tmp21Line = __tmp21Reader.ReadLine();
                    __tmp21_last = __tmp21Reader.EndOfStream;
                    if (__tmp21Line != null) __out.Append(__tmp21Line);
                    if (!__tmp21_last) __out.AppendLine(true);
                }
            }
            string __tmp22Line = "Implementation Implementation"; //785:31
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            __out.AppendLine(false); //785:60
            __out.Append("    {"); //786:1
            __out.AppendLine(false); //786:6
            string __tmp24Line = "        get { return "; //787:1
            if (__tmp24Line != null) __out.Append(__tmp24Line);
            StringBuilder __tmp25 = new StringBuilder();
            __tmp25.Append(model.Name);
            using(StreamReader __tmp25Reader = new StreamReader(this.__ToStream(__tmp25.ToString())))
            {
                bool __tmp25_first = true;
                bool __tmp25_last = __tmp25Reader.EndOfStream;
                while(__tmp25_first || !__tmp25_last)
                {
                    __tmp25_first = false;
                    string __tmp25Line = __tmp25Reader.ReadLine();
                    __tmp25_last = __tmp25Reader.EndOfStream;
                    if (__tmp25Line != null) __out.Append(__tmp25Line);
                    if (!__tmp25_last) __out.AppendLine(true);
                }
            }
            string __tmp26Line = "ImplementationProvider.implementation; }"; //787:34
            if (__tmp26Line != null) __out.Append(__tmp26Line);
            __out.AppendLine(false); //787:74
            __out.Append("    }"); //788:1
            __out.AppendLine(false); //788:6
            __out.Append("}"); //789:1
            __out.AppendLine(false); //789:2
            var __loop43_results = 
                (from __loop43_var1 in __Enumerate((model).GetEnumerator()) //790:8
                from Namespace in __Enumerate((__loop43_var1.Namespace).GetEnumerator()) //790:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //790:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //790:40
                select new { __loop43_var1 = __loop43_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //790:3
            for (int __loop43_iteration = 0; __loop43_iteration < __loop43_results.Count; ++__loop43_iteration)
            {
                var __tmp27 = __loop43_results[__loop43_iteration];
                var __loop43_var1 = __tmp27.__loop43_var1;
                var Namespace = __tmp27.Namespace;
                var Declarations = __tmp27.Declarations;
                var enm = __tmp27.enm;
                __out.AppendLine(true); //791:1
                string __tmp29Line = "public static class "; //792:1
                if (__tmp29Line != null) __out.Append(__tmp29Line);
                StringBuilder __tmp30 = new StringBuilder();
                __tmp30.Append(enm.Name);
                using(StreamReader __tmp30Reader = new StreamReader(this.__ToStream(__tmp30.ToString())))
                {
                    bool __tmp30_first = true;
                    bool __tmp30_last = __tmp30Reader.EndOfStream;
                    while(__tmp30_first || !__tmp30_last)
                    {
                        __tmp30_first = false;
                        string __tmp30Line = __tmp30Reader.ReadLine();
                        __tmp30_last = __tmp30Reader.EndOfStream;
                        if (__tmp30Line != null) __out.Append(__tmp30Line);
                        if (!__tmp30_last) __out.AppendLine(true);
                    }
                }
                string __tmp31Line = "Extensions"; //792:31
                if (__tmp31Line != null) __out.Append(__tmp31Line);
                __out.AppendLine(false); //792:41
                __out.Append("{"); //793:1
                __out.AppendLine(false); //793:2
                var __loop44_results = 
                    (from __loop44_var1 in __Enumerate((enm).GetEnumerator()) //794:11
                    from op in __Enumerate((__loop44_var1.Operations).GetEnumerator()) //794:16
                    select new { __loop44_var1 = __loop44_var1, op = op}
                    ).ToList(); //794:6
                for (int __loop44_iteration = 0; __loop44_iteration < __loop44_results.Count; ++__loop44_iteration)
                {
                    var __tmp32 = __loop44_results[__loop44_iteration];
                    var __loop44_var1 = __tmp32.__loop44_var1;
                    var op = __tmp32.op;
                    string __tmp34Line = "    public static "; //795:1
                    if (__tmp34Line != null) __out.Append(__tmp34Line);
                    StringBuilder __tmp35 = new StringBuilder();
                    __tmp35.Append(op.ReturnType.CSharpFullPublicName());
                    using(StreamReader __tmp35Reader = new StreamReader(this.__ToStream(__tmp35.ToString())))
                    {
                        bool __tmp35_first = true;
                        bool __tmp35_last = __tmp35Reader.EndOfStream;
                        while(__tmp35_first || !__tmp35_last)
                        {
                            __tmp35_first = false;
                            string __tmp35Line = __tmp35Reader.ReadLine();
                            __tmp35_last = __tmp35Reader.EndOfStream;
                            if (__tmp35Line != null) __out.Append(__tmp35Line);
                            if (!__tmp35_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp36Line = " "; //795:57
                    if (__tmp36Line != null) __out.Append(__tmp36Line);
                    StringBuilder __tmp37 = new StringBuilder();
                    __tmp37.Append(op.Name);
                    using(StreamReader __tmp37Reader = new StreamReader(this.__ToStream(__tmp37.ToString())))
                    {
                        bool __tmp37_first = true;
                        bool __tmp37_last = __tmp37Reader.EndOfStream;
                        while(__tmp37_first || !__tmp37_last)
                        {
                            __tmp37_first = false;
                            string __tmp37Line = __tmp37Reader.ReadLine();
                            __tmp37_last = __tmp37Reader.EndOfStream;
                            if (__tmp37Line != null) __out.Append(__tmp37Line);
                            if (!__tmp37_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp38Line = "("; //795:67
                    if (__tmp38Line != null) __out.Append(__tmp38Line);
                    StringBuilder __tmp39 = new StringBuilder();
                    __tmp39.Append(GetEnumImplParameters(enm, op));
                    using(StreamReader __tmp39Reader = new StreamReader(this.__ToStream(__tmp39.ToString())))
                    {
                        bool __tmp39_first = true;
                        bool __tmp39_last = __tmp39Reader.EndOfStream;
                        while(__tmp39_first || !__tmp39_last)
                        {
                            __tmp39_first = false;
                            string __tmp39Line = __tmp39Reader.ReadLine();
                            __tmp39_last = __tmp39Reader.EndOfStream;
                            if (__tmp39Line != null) __out.Append(__tmp39Line);
                            if (!__tmp39_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp40Line = ")"; //795:100
                    if (__tmp40Line != null) __out.Append(__tmp40Line);
                    __out.AppendLine(false); //795:101
                    __out.Append("    {"); //796:1
                    __out.AppendLine(false); //796:6
                    string __tmp41Prefix = "        "; //797:1
                    StringBuilder __tmp42 = new StringBuilder();
                    __tmp42.Append(GetReturn(op));
                    using(StreamReader __tmp42Reader = new StreamReader(this.__ToStream(__tmp42.ToString())))
                    {
                        bool __tmp42_first = true;
                        bool __tmp42_last = __tmp42Reader.EndOfStream;
                        while(__tmp42_first || !__tmp42_last)
                        {
                            __tmp42_first = false;
                            string __tmp42Line = __tmp42Reader.ReadLine();
                            __tmp42_last = __tmp42Reader.EndOfStream;
                            __out.Append(__tmp41Prefix);
                            if (__tmp42Line != null) __out.Append(__tmp42Line);
                            if (!__tmp42_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp43 = new StringBuilder();
                    __tmp43.Append(model.Name);
                    using(StreamReader __tmp43Reader = new StreamReader(this.__ToStream(__tmp43.ToString())))
                    {
                        bool __tmp43_first = true;
                        bool __tmp43_last = __tmp43Reader.EndOfStream;
                        while(__tmp43_first || !__tmp43_last)
                        {
                            __tmp43_first = false;
                            string __tmp43Line = __tmp43Reader.ReadLine();
                            __tmp43_last = __tmp43Reader.EndOfStream;
                            if (__tmp43Line != null) __out.Append(__tmp43Line);
                            if (!__tmp43_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp44Line = "ImplementationProvider.Implementation."; //797:36
                    if (__tmp44Line != null) __out.Append(__tmp44Line);
                    StringBuilder __tmp45 = new StringBuilder();
                    __tmp45.Append(op.Parent.CSharpName());
                    using(StreamReader __tmp45Reader = new StreamReader(this.__ToStream(__tmp45.ToString())))
                    {
                        bool __tmp45_first = true;
                        bool __tmp45_last = __tmp45Reader.EndOfStream;
                        while(__tmp45_first || !__tmp45_last)
                        {
                            __tmp45_first = false;
                            string __tmp45Line = __tmp45Reader.ReadLine();
                            __tmp45_last = __tmp45Reader.EndOfStream;
                            if (__tmp45Line != null) __out.Append(__tmp45Line);
                            if (!__tmp45_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp46Line = "_"; //797:98
                    if (__tmp46Line != null) __out.Append(__tmp46Line);
                    StringBuilder __tmp47 = new StringBuilder();
                    __tmp47.Append(op.Name);
                    using(StreamReader __tmp47Reader = new StreamReader(this.__ToStream(__tmp47.ToString())))
                    {
                        bool __tmp47_first = true;
                        bool __tmp47_last = __tmp47Reader.EndOfStream;
                        while(__tmp47_first || !__tmp47_last)
                        {
                            __tmp47_first = false;
                            string __tmp47Line = __tmp47Reader.ReadLine();
                            __tmp47_last = __tmp47Reader.EndOfStream;
                            if (__tmp47Line != null) __out.Append(__tmp47Line);
                            if (!__tmp47_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp48Line = "("; //797:108
                    if (__tmp48Line != null) __out.Append(__tmp48Line);
                    StringBuilder __tmp49 = new StringBuilder();
                    __tmp49.Append(GetEnumImplCallParameterNames(op));
                    using(StreamReader __tmp49Reader = new StreamReader(this.__ToStream(__tmp49.ToString())))
                    {
                        bool __tmp49_first = true;
                        bool __tmp49_last = __tmp49Reader.EndOfStream;
                        while(__tmp49_first || !__tmp49_last)
                        {
                            __tmp49_first = false;
                            string __tmp49Line = __tmp49Reader.ReadLine();
                            __tmp49_last = __tmp49Reader.EndOfStream;
                            if (__tmp49Line != null) __out.Append(__tmp49Line);
                            if (!__tmp49_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp50Line = ");"; //797:144
                    if (__tmp50Line != null) __out.Append(__tmp50Line);
                    __out.AppendLine(false); //797:146
                    __out.Append("    }"); //798:1
                    __out.AppendLine(false); //798:6
                }
                __out.Append("}"); //800:1
                __out.AppendLine(false); //800:2
            }
            __out.AppendLine(true); //802:1
            __out.Append("/// <summary>"); //803:1
            __out.AppendLine(false); //803:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //804:1
            __out.AppendLine(false); //804:68
            string __tmp52Line = "/// This class has to be be overriden in "; //805:1
            if (__tmp52Line != null) __out.Append(__tmp52Line);
            StringBuilder __tmp53 = new StringBuilder();
            __tmp53.Append(model.Name);
            using(StreamReader __tmp53Reader = new StreamReader(this.__ToStream(__tmp53.ToString())))
            {
                bool __tmp53_first = true;
                bool __tmp53_last = __tmp53Reader.EndOfStream;
                while(__tmp53_first || !__tmp53_last)
                {
                    __tmp53_first = false;
                    string __tmp53Line = __tmp53Reader.ReadLine();
                    __tmp53_last = __tmp53Reader.EndOfStream;
                    if (__tmp53Line != null) __out.Append(__tmp53Line);
                    if (!__tmp53_last) __out.AppendLine(true);
                }
            }
            string __tmp54Line = "Implementation to provide custom"; //805:54
            if (__tmp54Line != null) __out.Append(__tmp54Line);
            __out.AppendLine(false); //805:86
            __out.Append("/// implementation for the constructors, operations and property values."); //806:1
            __out.AppendLine(false); //806:73
            __out.Append("/// </summary>"); //807:1
            __out.AppendLine(false); //807:15
            string __tmp56Line = "internal abstract class "; //808:1
            if (__tmp56Line != null) __out.Append(__tmp56Line);
            StringBuilder __tmp57 = new StringBuilder();
            __tmp57.Append(model.Name);
            using(StreamReader __tmp57Reader = new StreamReader(this.__ToStream(__tmp57.ToString())))
            {
                bool __tmp57_first = true;
                bool __tmp57_last = __tmp57Reader.EndOfStream;
                while(__tmp57_first || !__tmp57_last)
                {
                    __tmp57_first = false;
                    string __tmp57Line = __tmp57Reader.ReadLine();
                    __tmp57_last = __tmp57Reader.EndOfStream;
                    if (__tmp57Line != null) __out.Append(__tmp57Line);
                    if (!__tmp57_last) __out.AppendLine(true);
                }
            }
            string __tmp58Line = "ImplementationBase"; //808:37
            if (__tmp58Line != null) __out.Append(__tmp58Line);
            __out.AppendLine(false); //808:55
            __out.Append("{"); //809:1
            __out.AppendLine(false); //809:2
            var __loop45_results = 
                (from __loop45_var1 in __Enumerate((model).GetEnumerator()) //810:8
                from Namespace in __Enumerate((__loop45_var1.Namespace).GetEnumerator()) //810:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //810:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //810:40
                select new { __loop45_var1 = __loop45_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //810:3
            for (int __loop45_iteration = 0; __loop45_iteration < __loop45_results.Count; ++__loop45_iteration)
            {
                var __tmp59 = __loop45_results[__loop45_iteration];
                var __loop45_var1 = __tmp59.__loop45_var1;
                var Namespace = __tmp59.Namespace;
                var Declarations = __tmp59.Declarations;
                var cls = __tmp59.cls;
                __out.Append("    /// <summary>"); //811:1
                __out.AppendLine(false); //811:18
                string __tmp61Line = "	/// Implements the constructor: "; //812:1
                if (__tmp61Line != null) __out.Append(__tmp61Line);
                StringBuilder __tmp62 = new StringBuilder();
                __tmp62.Append(cls.CSharpName());
                using(StreamReader __tmp62Reader = new StreamReader(this.__ToStream(__tmp62.ToString())))
                {
                    bool __tmp62_first = true;
                    bool __tmp62_last = __tmp62Reader.EndOfStream;
                    while(__tmp62_first || !__tmp62_last)
                    {
                        __tmp62_first = false;
                        string __tmp62Line = __tmp62Reader.ReadLine();
                        __tmp62_last = __tmp62Reader.EndOfStream;
                        if (__tmp62Line != null) __out.Append(__tmp62Line);
                        if (!__tmp62_last) __out.AppendLine(true);
                    }
                }
                string __tmp63Line = "()"; //812:52
                if (__tmp63Line != null) __out.Append(__tmp63Line);
                __out.AppendLine(false); //812:54
                if ((from __loop46_var1 in __Enumerate((cls).GetEnumerator()) //813:15
                from sup in __Enumerate((__loop46_var1.SuperClasses).GetEnumerator()) //813:20
                select new { __loop46_var1 = __loop46_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //813:3
                {
                    string __tmp65Line = "	/// Direct superclasses: "; //814:1
                    if (__tmp65Line != null) __out.Append(__tmp65Line);
                    StringBuilder __tmp66 = new StringBuilder();
                    __tmp66.Append(GetSuperClasses(cls));
                    using(StreamReader __tmp66Reader = new StreamReader(this.__ToStream(__tmp66.ToString())))
                    {
                        bool __tmp66_first = true;
                        bool __tmp66_last = __tmp66Reader.EndOfStream;
                        while(__tmp66_first || !__tmp66_last)
                        {
                            __tmp66_first = false;
                            string __tmp66Line = __tmp66Reader.ReadLine();
                            __tmp66_last = __tmp66Reader.EndOfStream;
                            if (__tmp66Line != null) __out.Append(__tmp66Line);
                            if (!__tmp66_last) __out.AppendLine(true);
                            __out.AppendLine(false); //814:49
                        }
                    }
                    string __tmp68Line = "	/// All superclasses: "; //815:1
                    if (__tmp68Line != null) __out.Append(__tmp68Line);
                    StringBuilder __tmp69 = new StringBuilder();
                    __tmp69.Append(GetAllSuperClasses(cls));
                    using(StreamReader __tmp69Reader = new StreamReader(this.__ToStream(__tmp69.ToString())))
                    {
                        bool __tmp69_first = true;
                        bool __tmp69_last = __tmp69Reader.EndOfStream;
                        while(__tmp69_first || !__tmp69_last)
                        {
                            __tmp69_first = false;
                            string __tmp69Line = __tmp69Reader.ReadLine();
                            __tmp69_last = __tmp69Reader.EndOfStream;
                            if (__tmp69Line != null) __out.Append(__tmp69Line);
                            if (!__tmp69_last) __out.AppendLine(true);
                            __out.AppendLine(false); //815:49
                        }
                    }
                }
                if ((from __loop47_var1 in __Enumerate((cls).GetEnumerator()) //817:15
                from prop in __Enumerate((__loop47_var1.GetAllProperties()).GetEnumerator()) //817:20
                where prop.Kind == MetaPropertyKind.Readonly //817:44
                select new { __loop47_var1 = __loop47_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //817:3
                {
                    __out.Append("    /// Initializes the following readonly properties:"); //818:1
                    __out.AppendLine(false); //818:55
                }
                var __loop48_results = 
                    (from __loop48_var1 in __Enumerate((cls).GetEnumerator()) //820:11
                    from prop in __Enumerate((__loop48_var1.GetAllProperties()).GetEnumerator()) //820:16
                    select new { __loop48_var1 = __loop48_var1, prop = prop}
                    ).ToList(); //820:6
                for (int __loop48_iteration = 0; __loop48_iteration < __loop48_results.Count; ++__loop48_iteration)
                {
                    var __tmp70 = __loop48_results[__loop48_iteration];
                    var __loop48_var1 = __tmp70.__loop48_var1;
                    var prop = __tmp70.prop;
                    if (prop.Kind == MetaPropertyKind.Readonly) //821:3
                    {
                        string __tmp72Line = "    ///    "; //822:1
                        if (__tmp72Line != null) __out.Append(__tmp72Line);
                        StringBuilder __tmp73 = new StringBuilder();
                        __tmp73.Append(prop.Class.Name);
                        using(StreamReader __tmp73Reader = new StreamReader(this.__ToStream(__tmp73.ToString())))
                        {
                            bool __tmp73_first = true;
                            bool __tmp73_last = __tmp73Reader.EndOfStream;
                            while(__tmp73_first || !__tmp73_last)
                            {
                                __tmp73_first = false;
                                string __tmp73Line = __tmp73Reader.ReadLine();
                                __tmp73_last = __tmp73Reader.EndOfStream;
                                if (__tmp73Line != null) __out.Append(__tmp73Line);
                                if (!__tmp73_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp74Line = "."; //822:29
                        if (__tmp74Line != null) __out.Append(__tmp74Line);
                        StringBuilder __tmp75 = new StringBuilder();
                        __tmp75.Append(prop.Name);
                        using(StreamReader __tmp75Reader = new StreamReader(this.__ToStream(__tmp75.ToString())))
                        {
                            bool __tmp75_first = true;
                            bool __tmp75_last = __tmp75Reader.EndOfStream;
                            while(__tmp75_first || !__tmp75_last)
                            {
                                __tmp75_first = false;
                                string __tmp75Line = __tmp75Reader.ReadLine();
                                __tmp75_last = __tmp75Reader.EndOfStream;
                                if (__tmp75Line != null) __out.Append(__tmp75Line);
                                if (!__tmp75_last) __out.AppendLine(true);
                                __out.AppendLine(false); //822:41
                            }
                        }
                    }
                }
                __out.Append("    /// </summary>"); //825:1
                __out.AppendLine(false); //825:19
                string __tmp77Line = "    public virtual void "; //826:1
                if (__tmp77Line != null) __out.Append(__tmp77Line);
                StringBuilder __tmp78 = new StringBuilder();
                __tmp78.Append(cls.CSharpName());
                using(StreamReader __tmp78Reader = new StreamReader(this.__ToStream(__tmp78.ToString())))
                {
                    bool __tmp78_first = true;
                    bool __tmp78_last = __tmp78Reader.EndOfStream;
                    while(__tmp78_first || !__tmp78_last)
                    {
                        __tmp78_first = false;
                        string __tmp78Line = __tmp78Reader.ReadLine();
                        __tmp78_last = __tmp78Reader.EndOfStream;
                        if (__tmp78Line != null) __out.Append(__tmp78Line);
                        if (!__tmp78_last) __out.AppendLine(true);
                    }
                }
                string __tmp79Line = "("; //826:43
                if (__tmp79Line != null) __out.Append(__tmp79Line);
                StringBuilder __tmp80 = new StringBuilder();
                __tmp80.Append(cls.CSharpName());
                using(StreamReader __tmp80Reader = new StreamReader(this.__ToStream(__tmp80.ToString())))
                {
                    bool __tmp80_first = true;
                    bool __tmp80_last = __tmp80Reader.EndOfStream;
                    while(__tmp80_first || !__tmp80_last)
                    {
                        __tmp80_first = false;
                        string __tmp80Line = __tmp80Reader.ReadLine();
                        __tmp80_last = __tmp80Reader.EndOfStream;
                        if (__tmp80Line != null) __out.Append(__tmp80Line);
                        if (!__tmp80_last) __out.AppendLine(true);
                    }
                }
                string __tmp81Line = " @this)"; //826:62
                if (__tmp81Line != null) __out.Append(__tmp81Line);
                __out.AppendLine(false); //826:69
                __out.Append("    {"); //827:1
                __out.AppendLine(false); //827:6
                var __loop49_results = 
                    (from __loop49_var1 in __Enumerate((cls).GetEnumerator()) //828:9
                    from sup in __Enumerate((__loop49_var1.SuperClasses).GetEnumerator()) //828:14
                    select new { __loop49_var1 = __loop49_var1, sup = sup}
                    ).ToList(); //828:4
                for (int __loop49_iteration = 0; __loop49_iteration < __loop49_results.Count; ++__loop49_iteration)
                {
                    var __tmp82 = __loop49_results[__loop49_iteration];
                    var __loop49_var1 = __tmp82.__loop49_var1;
                    var sup = __tmp82.sup;
                    string __tmp84Line = "        this."; //829:1
                    if (__tmp84Line != null) __out.Append(__tmp84Line);
                    StringBuilder __tmp85 = new StringBuilder();
                    __tmp85.Append(sup.CSharpName());
                    using(StreamReader __tmp85Reader = new StreamReader(this.__ToStream(__tmp85.ToString())))
                    {
                        bool __tmp85_first = true;
                        bool __tmp85_last = __tmp85Reader.EndOfStream;
                        while(__tmp85_first || !__tmp85_last)
                        {
                            __tmp85_first = false;
                            string __tmp85Line = __tmp85Reader.ReadLine();
                            __tmp85_last = __tmp85Reader.EndOfStream;
                            if (__tmp85Line != null) __out.Append(__tmp85Line);
                            if (!__tmp85_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp86Line = "(@this);"; //829:32
                    if (__tmp86Line != null) __out.Append(__tmp86Line);
                    __out.AppendLine(false); //829:40
                }
                __out.Append("    }"); //831:1
                __out.AppendLine(false); //831:6
                var __loop50_results = 
                    (from __loop50_var1 in __Enumerate((cls).GetEnumerator()) //832:11
                    from prop in __Enumerate((__loop50_var1.Properties).GetEnumerator()) //832:16
                    select new { __loop50_var1 = __loop50_var1, prop = prop}
                    ).ToList(); //832:6
                for (int __loop50_iteration = 0; __loop50_iteration < __loop50_results.Count; ++__loop50_iteration)
                {
                    var __tmp87 = __loop50_results[__loop50_iteration];
                    var __loop50_var1 = __tmp87.__loop50_var1;
                    var prop = __tmp87.prop;
                    MetaSynthetizedPropertyInitializer synInit = GetSynthetizedInitializerFor(cls, prop); //833:4
                    if (synInit == null) //834:4
                    {
                        if (prop.Kind == MetaPropertyKind.Derived) //835:5
                        {
                            __out.AppendLine(true); //836:1
                            __out.Append("    /// <summary>"); //837:1
                            __out.AppendLine(false); //837:18
                            string __tmp89Line = "    /// Returns the value of the derived property: "; //838:1
                            if (__tmp89Line != null) __out.Append(__tmp89Line);
                            StringBuilder __tmp90 = new StringBuilder();
                            __tmp90.Append(cls.CSharpName());
                            using(StreamReader __tmp90Reader = new StreamReader(this.__ToStream(__tmp90.ToString())))
                            {
                                bool __tmp90_first = true;
                                bool __tmp90_last = __tmp90Reader.EndOfStream;
                                while(__tmp90_first || !__tmp90_last)
                                {
                                    __tmp90_first = false;
                                    string __tmp90Line = __tmp90Reader.ReadLine();
                                    __tmp90_last = __tmp90Reader.EndOfStream;
                                    if (__tmp90Line != null) __out.Append(__tmp90Line);
                                    if (!__tmp90_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp91Line = "."; //838:70
                            if (__tmp91Line != null) __out.Append(__tmp91Line);
                            StringBuilder __tmp92 = new StringBuilder();
                            __tmp92.Append(prop.Name);
                            using(StreamReader __tmp92Reader = new StreamReader(this.__ToStream(__tmp92.ToString())))
                            {
                                bool __tmp92_first = true;
                                bool __tmp92_last = __tmp92Reader.EndOfStream;
                                while(__tmp92_first || !__tmp92_last)
                                {
                                    __tmp92_first = false;
                                    string __tmp92Line = __tmp92Reader.ReadLine();
                                    __tmp92_last = __tmp92Reader.EndOfStream;
                                    if (__tmp92Line != null) __out.Append(__tmp92Line);
                                    if (!__tmp92_last) __out.AppendLine(true);
                                    __out.AppendLine(false); //838:82
                                }
                            }
                            __out.Append("    /// </summary>"); //839:1
                            __out.AppendLine(false); //839:19
                            string __tmp94Line = "    public virtual "; //840:1
                            if (__tmp94Line != null) __out.Append(__tmp94Line);
                            StringBuilder __tmp95 = new StringBuilder();
                            __tmp95.Append(prop.Type.CSharpFullPublicName());
                            using(StreamReader __tmp95Reader = new StreamReader(this.__ToStream(__tmp95.ToString())))
                            {
                                bool __tmp95_first = true;
                                bool __tmp95_last = __tmp95Reader.EndOfStream;
                                while(__tmp95_first || !__tmp95_last)
                                {
                                    __tmp95_first = false;
                                    string __tmp95Line = __tmp95Reader.ReadLine();
                                    __tmp95_last = __tmp95Reader.EndOfStream;
                                    if (__tmp95Line != null) __out.Append(__tmp95Line);
                                    if (!__tmp95_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp96Line = " "; //840:54
                            if (__tmp96Line != null) __out.Append(__tmp96Line);
                            StringBuilder __tmp97 = new StringBuilder();
                            __tmp97.Append(cls.CSharpName());
                            using(StreamReader __tmp97Reader = new StreamReader(this.__ToStream(__tmp97.ToString())))
                            {
                                bool __tmp97_first = true;
                                bool __tmp97_last = __tmp97Reader.EndOfStream;
                                while(__tmp97_first || !__tmp97_last)
                                {
                                    __tmp97_first = false;
                                    string __tmp97Line = __tmp97Reader.ReadLine();
                                    __tmp97_last = __tmp97Reader.EndOfStream;
                                    if (__tmp97Line != null) __out.Append(__tmp97Line);
                                    if (!__tmp97_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp98Line = "_"; //840:73
                            if (__tmp98Line != null) __out.Append(__tmp98Line);
                            StringBuilder __tmp99 = new StringBuilder();
                            __tmp99.Append(prop.Name);
                            using(StreamReader __tmp99Reader = new StreamReader(this.__ToStream(__tmp99.ToString())))
                            {
                                bool __tmp99_first = true;
                                bool __tmp99_last = __tmp99Reader.EndOfStream;
                                while(__tmp99_first || !__tmp99_last)
                                {
                                    __tmp99_first = false;
                                    string __tmp99Line = __tmp99Reader.ReadLine();
                                    __tmp99_last = __tmp99Reader.EndOfStream;
                                    if (__tmp99Line != null) __out.Append(__tmp99Line);
                                    if (!__tmp99_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp100Line = "("; //840:85
                            if (__tmp100Line != null) __out.Append(__tmp100Line);
                            StringBuilder __tmp101 = new StringBuilder();
                            __tmp101.Append(cls.CSharpName());
                            using(StreamReader __tmp101Reader = new StreamReader(this.__ToStream(__tmp101.ToString())))
                            {
                                bool __tmp101_first = true;
                                bool __tmp101_last = __tmp101Reader.EndOfStream;
                                while(__tmp101_first || !__tmp101_last)
                                {
                                    __tmp101_first = false;
                                    string __tmp101Line = __tmp101Reader.ReadLine();
                                    __tmp101_last = __tmp101Reader.EndOfStream;
                                    if (__tmp101Line != null) __out.Append(__tmp101Line);
                                    if (!__tmp101_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp102Line = " @this)"; //840:104
                            if (__tmp102Line != null) __out.Append(__tmp102Line);
                            __out.AppendLine(false); //840:111
                            __out.Append("    {"); //841:1
                            __out.AppendLine(false); //841:6
                            __out.Append("        throw new NotImplementedException();"); //842:1
                            __out.AppendLine(false); //842:45
                            __out.Append("    }"); //843:1
                            __out.AppendLine(false); //843:6
                        }
                        else if (prop.Kind == MetaPropertyKind.Lazy) //844:5
                        {
                            __out.AppendLine(true); //845:1
                            __out.Append("    /// <summary>"); //846:1
                            __out.AppendLine(false); //846:18
                            string __tmp104Line = "    /// Returns the value of the lazy property: "; //847:1
                            if (__tmp104Line != null) __out.Append(__tmp104Line);
                            StringBuilder __tmp105 = new StringBuilder();
                            __tmp105.Append(cls.CSharpName());
                            using(StreamReader __tmp105Reader = new StreamReader(this.__ToStream(__tmp105.ToString())))
                            {
                                bool __tmp105_first = true;
                                bool __tmp105_last = __tmp105Reader.EndOfStream;
                                while(__tmp105_first || !__tmp105_last)
                                {
                                    __tmp105_first = false;
                                    string __tmp105Line = __tmp105Reader.ReadLine();
                                    __tmp105_last = __tmp105Reader.EndOfStream;
                                    if (__tmp105Line != null) __out.Append(__tmp105Line);
                                    if (!__tmp105_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp106Line = "."; //847:67
                            if (__tmp106Line != null) __out.Append(__tmp106Line);
                            StringBuilder __tmp107 = new StringBuilder();
                            __tmp107.Append(prop.Name);
                            using(StreamReader __tmp107Reader = new StreamReader(this.__ToStream(__tmp107.ToString())))
                            {
                                bool __tmp107_first = true;
                                bool __tmp107_last = __tmp107Reader.EndOfStream;
                                while(__tmp107_first || !__tmp107_last)
                                {
                                    __tmp107_first = false;
                                    string __tmp107Line = __tmp107Reader.ReadLine();
                                    __tmp107_last = __tmp107Reader.EndOfStream;
                                    if (__tmp107Line != null) __out.Append(__tmp107Line);
                                    if (!__tmp107_last) __out.AppendLine(true);
                                    __out.AppendLine(false); //847:79
                                }
                            }
                            __out.Append("    /// </summary>"); //848:1
                            __out.AppendLine(false); //848:19
                            string __tmp109Line = "    public virtual "; //849:1
                            if (__tmp109Line != null) __out.Append(__tmp109Line);
                            StringBuilder __tmp110 = new StringBuilder();
                            __tmp110.Append(prop.Type.CSharpFullPublicName());
                            using(StreamReader __tmp110Reader = new StreamReader(this.__ToStream(__tmp110.ToString())))
                            {
                                bool __tmp110_first = true;
                                bool __tmp110_last = __tmp110Reader.EndOfStream;
                                while(__tmp110_first || !__tmp110_last)
                                {
                                    __tmp110_first = false;
                                    string __tmp110Line = __tmp110Reader.ReadLine();
                                    __tmp110_last = __tmp110Reader.EndOfStream;
                                    if (__tmp110Line != null) __out.Append(__tmp110Line);
                                    if (!__tmp110_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp111Line = " "; //849:54
                            if (__tmp111Line != null) __out.Append(__tmp111Line);
                            StringBuilder __tmp112 = new StringBuilder();
                            __tmp112.Append(cls.CSharpName());
                            using(StreamReader __tmp112Reader = new StreamReader(this.__ToStream(__tmp112.ToString())))
                            {
                                bool __tmp112_first = true;
                                bool __tmp112_last = __tmp112Reader.EndOfStream;
                                while(__tmp112_first || !__tmp112_last)
                                {
                                    __tmp112_first = false;
                                    string __tmp112Line = __tmp112Reader.ReadLine();
                                    __tmp112_last = __tmp112Reader.EndOfStream;
                                    if (__tmp112Line != null) __out.Append(__tmp112Line);
                                    if (!__tmp112_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp113Line = "_"; //849:73
                            if (__tmp113Line != null) __out.Append(__tmp113Line);
                            StringBuilder __tmp114 = new StringBuilder();
                            __tmp114.Append(prop.Name);
                            using(StreamReader __tmp114Reader = new StreamReader(this.__ToStream(__tmp114.ToString())))
                            {
                                bool __tmp114_first = true;
                                bool __tmp114_last = __tmp114Reader.EndOfStream;
                                while(__tmp114_first || !__tmp114_last)
                                {
                                    __tmp114_first = false;
                                    string __tmp114Line = __tmp114Reader.ReadLine();
                                    __tmp114_last = __tmp114Reader.EndOfStream;
                                    if (__tmp114Line != null) __out.Append(__tmp114Line);
                                    if (!__tmp114_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp115Line = "("; //849:85
                            if (__tmp115Line != null) __out.Append(__tmp115Line);
                            StringBuilder __tmp116 = new StringBuilder();
                            __tmp116.Append(cls.CSharpName());
                            using(StreamReader __tmp116Reader = new StreamReader(this.__ToStream(__tmp116.ToString())))
                            {
                                bool __tmp116_first = true;
                                bool __tmp116_last = __tmp116Reader.EndOfStream;
                                while(__tmp116_first || !__tmp116_last)
                                {
                                    __tmp116_first = false;
                                    string __tmp116Line = __tmp116Reader.ReadLine();
                                    __tmp116_last = __tmp116Reader.EndOfStream;
                                    if (__tmp116Line != null) __out.Append(__tmp116Line);
                                    if (!__tmp116_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp117Line = " @this)"; //849:104
                            if (__tmp117Line != null) __out.Append(__tmp117Line);
                            __out.AppendLine(false); //849:111
                            __out.Append("    {"); //850:1
                            __out.AppendLine(false); //850:6
                            __out.Append("        throw new NotImplementedException();"); //851:1
                            __out.AppendLine(false); //851:45
                            __out.Append("    }"); //852:1
                            __out.AppendLine(false); //852:6
                        }
                    }
                }
                var __loop51_results = 
                    (from __loop51_var1 in __Enumerate((cls).GetEnumerator()) //856:11
                    from op in __Enumerate((__loop51_var1.Operations).GetEnumerator()) //856:16
                    select new { __loop51_var1 = __loop51_var1, op = op}
                    ).ToList(); //856:6
                for (int __loop51_iteration = 0; __loop51_iteration < __loop51_results.Count; ++__loop51_iteration)
                {
                    var __tmp118 = __loop51_results[__loop51_iteration];
                    var __loop51_var1 = __tmp118.__loop51_var1;
                    var op = __tmp118.op;
                    __out.AppendLine(true); //857:1
                    __out.Append("    /// <summary>"); //858:1
                    __out.AppendLine(false); //858:18
                    string __tmp120Line = "    /// Implements the operation: "; //859:1
                    if (__tmp120Line != null) __out.Append(__tmp120Line);
                    StringBuilder __tmp121 = new StringBuilder();
                    __tmp121.Append(cls.CSharpName());
                    using(StreamReader __tmp121Reader = new StreamReader(this.__ToStream(__tmp121.ToString())))
                    {
                        bool __tmp121_first = true;
                        bool __tmp121_last = __tmp121Reader.EndOfStream;
                        while(__tmp121_first || !__tmp121_last)
                        {
                            __tmp121_first = false;
                            string __tmp121Line = __tmp121Reader.ReadLine();
                            __tmp121_last = __tmp121Reader.EndOfStream;
                            if (__tmp121Line != null) __out.Append(__tmp121Line);
                            if (!__tmp121_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp122Line = "."; //859:53
                    if (__tmp122Line != null) __out.Append(__tmp122Line);
                    StringBuilder __tmp123 = new StringBuilder();
                    __tmp123.Append(op.Name);
                    using(StreamReader __tmp123Reader = new StreamReader(this.__ToStream(__tmp123.ToString())))
                    {
                        bool __tmp123_first = true;
                        bool __tmp123_last = __tmp123Reader.EndOfStream;
                        while(__tmp123_first || !__tmp123_last)
                        {
                            __tmp123_first = false;
                            string __tmp123Line = __tmp123Reader.ReadLine();
                            __tmp123_last = __tmp123Reader.EndOfStream;
                            if (__tmp123Line != null) __out.Append(__tmp123Line);
                            if (!__tmp123_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp124Line = "()"; //859:63
                    if (__tmp124Line != null) __out.Append(__tmp124Line);
                    __out.AppendLine(false); //859:65
                    __out.Append("    /// </summary>"); //860:1
                    __out.AppendLine(false); //860:19
                    string __tmp126Line = "    public virtual "; //861:1
                    if (__tmp126Line != null) __out.Append(__tmp126Line);
                    StringBuilder __tmp127 = new StringBuilder();
                    __tmp127.Append(op.ReturnType.CSharpFullPublicName());
                    using(StreamReader __tmp127Reader = new StreamReader(this.__ToStream(__tmp127.ToString())))
                    {
                        bool __tmp127_first = true;
                        bool __tmp127_last = __tmp127Reader.EndOfStream;
                        while(__tmp127_first || !__tmp127_last)
                        {
                            __tmp127_first = false;
                            string __tmp127Line = __tmp127Reader.ReadLine();
                            __tmp127_last = __tmp127Reader.EndOfStream;
                            if (__tmp127Line != null) __out.Append(__tmp127Line);
                            if (!__tmp127_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp128Line = " "; //861:58
                    if (__tmp128Line != null) __out.Append(__tmp128Line);
                    StringBuilder __tmp129 = new StringBuilder();
                    __tmp129.Append(cls.CSharpName());
                    using(StreamReader __tmp129Reader = new StreamReader(this.__ToStream(__tmp129.ToString())))
                    {
                        bool __tmp129_first = true;
                        bool __tmp129_last = __tmp129Reader.EndOfStream;
                        while(__tmp129_first || !__tmp129_last)
                        {
                            __tmp129_first = false;
                            string __tmp129Line = __tmp129Reader.ReadLine();
                            __tmp129_last = __tmp129Reader.EndOfStream;
                            if (__tmp129Line != null) __out.Append(__tmp129Line);
                            if (!__tmp129_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp130Line = "_"; //861:77
                    if (__tmp130Line != null) __out.Append(__tmp130Line);
                    StringBuilder __tmp131 = new StringBuilder();
                    __tmp131.Append(op.Name);
                    using(StreamReader __tmp131Reader = new StreamReader(this.__ToStream(__tmp131.ToString())))
                    {
                        bool __tmp131_first = true;
                        bool __tmp131_last = __tmp131Reader.EndOfStream;
                        while(__tmp131_first || !__tmp131_last)
                        {
                            __tmp131_first = false;
                            string __tmp131Line = __tmp131Reader.ReadLine();
                            __tmp131_last = __tmp131Reader.EndOfStream;
                            if (__tmp131Line != null) __out.Append(__tmp131Line);
                            if (!__tmp131_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp132Line = "("; //861:87
                    if (__tmp132Line != null) __out.Append(__tmp132Line);
                    StringBuilder __tmp133 = new StringBuilder();
                    __tmp133.Append(GetImplParameters(cls, op));
                    using(StreamReader __tmp133Reader = new StreamReader(this.__ToStream(__tmp133.ToString())))
                    {
                        bool __tmp133_first = true;
                        bool __tmp133_last = __tmp133Reader.EndOfStream;
                        while(__tmp133_first || !__tmp133_last)
                        {
                            __tmp133_first = false;
                            string __tmp133Line = __tmp133Reader.ReadLine();
                            __tmp133_last = __tmp133Reader.EndOfStream;
                            if (__tmp133Line != null) __out.Append(__tmp133Line);
                            if (!__tmp133_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp134Line = ")"; //861:116
                    if (__tmp134Line != null) __out.Append(__tmp134Line);
                    __out.AppendLine(false); //861:117
                    __out.Append("    {"); //862:1
                    __out.AppendLine(false); //862:6
                    __out.Append("        throw new NotImplementedException();"); //863:1
                    __out.AppendLine(false); //863:45
                    __out.Append("    }"); //864:1
                    __out.AppendLine(false); //864:6
                }
                __out.AppendLine(true); //866:1
            }
            var __loop52_results = 
                (from __loop52_var1 in __Enumerate((model).GetEnumerator()) //868:8
                from Namespace in __Enumerate((__loop52_var1.Namespace).GetEnumerator()) //868:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //868:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //868:40
                select new { __loop52_var1 = __loop52_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //868:3
            for (int __loop52_iteration = 0; __loop52_iteration < __loop52_results.Count; ++__loop52_iteration)
            {
                var __tmp135 = __loop52_results[__loop52_iteration];
                var __loop52_var1 = __tmp135.__loop52_var1;
                var Namespace = __tmp135.Namespace;
                var Declarations = __tmp135.Declarations;
                var enm = __tmp135.enm;
                var __loop53_results = 
                    (from __loop53_var1 in __Enumerate((enm).GetEnumerator()) //869:11
                    from op in __Enumerate((__loop53_var1.Operations).GetEnumerator()) //869:16
                    select new { __loop53_var1 = __loop53_var1, op = op}
                    ).ToList(); //869:6
                for (int __loop53_iteration = 0; __loop53_iteration < __loop53_results.Count; ++__loop53_iteration)
                {
                    var __tmp136 = __loop53_results[__loop53_iteration];
                    var __loop53_var1 = __tmp136.__loop53_var1;
                    var op = __tmp136.op;
                    __out.AppendLine(true); //870:1
                    __out.Append("    /// <summary>"); //871:1
                    __out.AppendLine(false); //871:18
                    string __tmp138Line = "    /// Implements the operation: "; //872:1
                    if (__tmp138Line != null) __out.Append(__tmp138Line);
                    StringBuilder __tmp139 = new StringBuilder();
                    __tmp139.Append(enm.CSharpName());
                    using(StreamReader __tmp139Reader = new StreamReader(this.__ToStream(__tmp139.ToString())))
                    {
                        bool __tmp139_first = true;
                        bool __tmp139_last = __tmp139Reader.EndOfStream;
                        while(__tmp139_first || !__tmp139_last)
                        {
                            __tmp139_first = false;
                            string __tmp139Line = __tmp139Reader.ReadLine();
                            __tmp139_last = __tmp139Reader.EndOfStream;
                            if (__tmp139Line != null) __out.Append(__tmp139Line);
                            if (!__tmp139_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp140Line = "."; //872:53
                    if (__tmp140Line != null) __out.Append(__tmp140Line);
                    StringBuilder __tmp141 = new StringBuilder();
                    __tmp141.Append(op.Name);
                    using(StreamReader __tmp141Reader = new StreamReader(this.__ToStream(__tmp141.ToString())))
                    {
                        bool __tmp141_first = true;
                        bool __tmp141_last = __tmp141Reader.EndOfStream;
                        while(__tmp141_first || !__tmp141_last)
                        {
                            __tmp141_first = false;
                            string __tmp141Line = __tmp141Reader.ReadLine();
                            __tmp141_last = __tmp141Reader.EndOfStream;
                            if (__tmp141Line != null) __out.Append(__tmp141Line);
                            if (!__tmp141_last) __out.AppendLine(true);
                            __out.AppendLine(false); //872:63
                        }
                    }
                    __out.Append("    /// </summary>"); //873:1
                    __out.AppendLine(false); //873:19
                    string __tmp143Line = "    public virtual "; //874:1
                    if (__tmp143Line != null) __out.Append(__tmp143Line);
                    StringBuilder __tmp144 = new StringBuilder();
                    __tmp144.Append(op.ReturnType.CSharpFullPublicName());
                    using(StreamReader __tmp144Reader = new StreamReader(this.__ToStream(__tmp144.ToString())))
                    {
                        bool __tmp144_first = true;
                        bool __tmp144_last = __tmp144Reader.EndOfStream;
                        while(__tmp144_first || !__tmp144_last)
                        {
                            __tmp144_first = false;
                            string __tmp144Line = __tmp144Reader.ReadLine();
                            __tmp144_last = __tmp144Reader.EndOfStream;
                            if (__tmp144Line != null) __out.Append(__tmp144Line);
                            if (!__tmp144_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp145Line = " "; //874:58
                    if (__tmp145Line != null) __out.Append(__tmp145Line);
                    StringBuilder __tmp146 = new StringBuilder();
                    __tmp146.Append(enm.CSharpName());
                    using(StreamReader __tmp146Reader = new StreamReader(this.__ToStream(__tmp146.ToString())))
                    {
                        bool __tmp146_first = true;
                        bool __tmp146_last = __tmp146Reader.EndOfStream;
                        while(__tmp146_first || !__tmp146_last)
                        {
                            __tmp146_first = false;
                            string __tmp146Line = __tmp146Reader.ReadLine();
                            __tmp146_last = __tmp146Reader.EndOfStream;
                            if (__tmp146Line != null) __out.Append(__tmp146Line);
                            if (!__tmp146_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp147Line = "_"; //874:77
                    if (__tmp147Line != null) __out.Append(__tmp147Line);
                    StringBuilder __tmp148 = new StringBuilder();
                    __tmp148.Append(op.Name);
                    using(StreamReader __tmp148Reader = new StreamReader(this.__ToStream(__tmp148.ToString())))
                    {
                        bool __tmp148_first = true;
                        bool __tmp148_last = __tmp148Reader.EndOfStream;
                        while(__tmp148_first || !__tmp148_last)
                        {
                            __tmp148_first = false;
                            string __tmp148Line = __tmp148Reader.ReadLine();
                            __tmp148_last = __tmp148Reader.EndOfStream;
                            if (__tmp148Line != null) __out.Append(__tmp148Line);
                            if (!__tmp148_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp149Line = "("; //874:87
                    if (__tmp149Line != null) __out.Append(__tmp149Line);
                    StringBuilder __tmp150 = new StringBuilder();
                    __tmp150.Append(GetImplParameters(enm, op));
                    using(StreamReader __tmp150Reader = new StreamReader(this.__ToStream(__tmp150.ToString())))
                    {
                        bool __tmp150_first = true;
                        bool __tmp150_last = __tmp150Reader.EndOfStream;
                        while(__tmp150_first || !__tmp150_last)
                        {
                            __tmp150_first = false;
                            string __tmp150Line = __tmp150Reader.ReadLine();
                            __tmp150_last = __tmp150Reader.EndOfStream;
                            if (__tmp150Line != null) __out.Append(__tmp150Line);
                            if (!__tmp150_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp151Line = ")"; //874:116
                    if (__tmp151Line != null) __out.Append(__tmp151Line);
                    __out.AppendLine(false); //874:117
                    __out.Append("    {"); //875:1
                    __out.AppendLine(false); //875:6
                    __out.Append("        throw new NotImplementedException();"); //876:1
                    __out.AppendLine(false); //876:45
                    __out.Append("    }"); //877:1
                    __out.AppendLine(false); //877:6
                }
                __out.AppendLine(true); //879:1
            }
            __out.Append("}"); //881:1
            __out.AppendLine(false); //881:2
            __out.AppendLine(true); //882:1
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //885:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //886:1
            __out.AppendLine(false); //886:14
            __out.Append("/// Factory class for creating instances of model elements."); //887:1
            __out.AppendLine(false); //887:60
            __out.Append("/// </summary>"); //888:1
            __out.AppendLine(false); //888:15
            string __tmp2Line = "public class "; //889:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(model.CSharpFactoryName());
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(__tmp3_first || !__tmp3_last)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    if (!__tmp3_last) __out.AppendLine(true);
                }
            }
            string __tmp4Line = " : ModelFactory"; //889:41
            if (__tmp4Line != null) __out.Append(__tmp4Line);
            __out.AppendLine(false); //889:56
            __out.Append("{"); //890:1
            __out.AppendLine(false); //890:2
            string __tmp6Line = "    private static "; //891:1
            if (__tmp6Line != null) __out.Append(__tmp6Line);
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(model.CSharpFactoryName());
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_first = true;
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(__tmp7_first || !__tmp7_last)
                {
                    __tmp7_first = false;
                    string __tmp7Line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    if (__tmp7Line != null) __out.Append(__tmp7Line);
                    if (!__tmp7_last) __out.AppendLine(true);
                }
            }
            string __tmp8Line = " instance = new "; //891:47
            if (__tmp8Line != null) __out.Append(__tmp8Line);
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(model.CSharpFactoryName());
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_first = true;
                bool __tmp9_last = __tmp9Reader.EndOfStream;
                while(__tmp9_first || !__tmp9_last)
                {
                    __tmp9_first = false;
                    string __tmp9Line = __tmp9Reader.ReadLine();
                    __tmp9_last = __tmp9Reader.EndOfStream;
                    if (__tmp9Line != null) __out.Append(__tmp9Line);
                    if (!__tmp9_last) __out.AppendLine(true);
                }
            }
            string __tmp10Line = "();"; //891:90
            if (__tmp10Line != null) __out.Append(__tmp10Line);
            __out.AppendLine(false); //891:93
            __out.AppendLine(true); //892:1
            string __tmp12Line = "	private "; //893:1
            if (__tmp12Line != null) __out.Append(__tmp12Line);
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(model.CSharpFactoryName());
            using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
            {
                bool __tmp13_first = true;
                bool __tmp13_last = __tmp13Reader.EndOfStream;
                while(__tmp13_first || !__tmp13_last)
                {
                    __tmp13_first = false;
                    string __tmp13Line = __tmp13Reader.ReadLine();
                    __tmp13_last = __tmp13Reader.EndOfStream;
                    if (__tmp13Line != null) __out.Append(__tmp13Line);
                    if (!__tmp13_last) __out.AppendLine(true);
                }
            }
            string __tmp14Line = "()"; //893:37
            if (__tmp14Line != null) __out.Append(__tmp14Line);
            __out.AppendLine(false); //893:39
            __out.Append("	{"); //894:1
            __out.AppendLine(false); //894:3
            __out.Append("	}"); //895:1
            __out.AppendLine(false); //895:3
            __out.AppendLine(true); //896:1
            __out.Append("    /// <summary>"); //897:1
            __out.AppendLine(false); //897:18
            __out.Append("    /// The singleton instance of the factory."); //898:1
            __out.AppendLine(false); //898:47
            __out.Append("    /// </summary>"); //899:1
            __out.AppendLine(false); //899:19
            string __tmp16Line = "    public static "; //900:1
            if (__tmp16Line != null) __out.Append(__tmp16Line);
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(model.CSharpFactoryName());
            using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
            {
                bool __tmp17_first = true;
                bool __tmp17_last = __tmp17Reader.EndOfStream;
                while(__tmp17_first || !__tmp17_last)
                {
                    __tmp17_first = false;
                    string __tmp17Line = __tmp17Reader.ReadLine();
                    __tmp17_last = __tmp17Reader.EndOfStream;
                    if (__tmp17Line != null) __out.Append(__tmp17Line);
                    if (!__tmp17_last) __out.AppendLine(true);
                }
            }
            string __tmp18Line = " Instance"; //900:46
            if (__tmp18Line != null) __out.Append(__tmp18Line);
            __out.AppendLine(false); //900:55
            __out.Append("    {"); //901:1
            __out.AppendLine(false); //901:6
            string __tmp20Line = "        get { return "; //902:1
            if (__tmp20Line != null) __out.Append(__tmp20Line);
            StringBuilder __tmp21 = new StringBuilder();
            __tmp21.Append(model.CSharpFactoryName());
            using(StreamReader __tmp21Reader = new StreamReader(this.__ToStream(__tmp21.ToString())))
            {
                bool __tmp21_first = true;
                bool __tmp21_last = __tmp21Reader.EndOfStream;
                while(__tmp21_first || !__tmp21_last)
                {
                    __tmp21_first = false;
                    string __tmp21Line = __tmp21Reader.ReadLine();
                    __tmp21_last = __tmp21Reader.EndOfStream;
                    if (__tmp21Line != null) __out.Append(__tmp21Line);
                    if (!__tmp21_last) __out.AppendLine(true);
                }
            }
            string __tmp22Line = ".instance; }"; //902:49
            if (__tmp22Line != null) __out.Append(__tmp22Line);
            __out.AppendLine(false); //902:61
            __out.Append("    }"); //903:1
            __out.AppendLine(false); //903:6
            var __loop54_results = 
                (from __loop54_var1 in __Enumerate((model).GetEnumerator()) //904:8
                from Namespace in __Enumerate((__loop54_var1.Namespace).GetEnumerator()) //904:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //904:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //904:40
                select new { __loop54_var1 = __loop54_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //904:3
            for (int __loop54_iteration = 0; __loop54_iteration < __loop54_results.Count; ++__loop54_iteration)
            {
                var __tmp23 = __loop54_results[__loop54_iteration];
                var __loop54_var1 = __tmp23.__loop54_var1;
                var Namespace = __tmp23.Namespace;
                var Declarations = __tmp23.Declarations;
                var cls = __tmp23.cls;
                if (!cls.IsAbstract) //905:4
                {
                    __out.AppendLine(true); //906:1
                    __out.Append("    /// <summary>"); //907:1
                    __out.AppendLine(false); //907:18
                    string __tmp25Line = "    /// Creates a new instance of "; //908:1
                    if (__tmp25Line != null) __out.Append(__tmp25Line);
                    StringBuilder __tmp26 = new StringBuilder();
                    __tmp26.Append(cls.CSharpName());
                    using(StreamReader __tmp26Reader = new StreamReader(this.__ToStream(__tmp26.ToString())))
                    {
                        bool __tmp26_first = true;
                        bool __tmp26_last = __tmp26Reader.EndOfStream;
                        while(__tmp26_first || !__tmp26_last)
                        {
                            __tmp26_first = false;
                            string __tmp26Line = __tmp26Reader.ReadLine();
                            __tmp26_last = __tmp26Reader.EndOfStream;
                            if (__tmp26Line != null) __out.Append(__tmp26Line);
                            if (!__tmp26_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp27Line = "."; //908:53
                    if (__tmp27Line != null) __out.Append(__tmp27Line);
                    __out.AppendLine(false); //908:54
                    __out.Append("    /// </summary>"); //909:1
                    __out.AppendLine(false); //909:19
                    string __tmp29Line = "    public "; //910:1
                    if (__tmp29Line != null) __out.Append(__tmp29Line);
                    StringBuilder __tmp30 = new StringBuilder();
                    __tmp30.Append(cls.CSharpName());
                    using(StreamReader __tmp30Reader = new StreamReader(this.__ToStream(__tmp30.ToString())))
                    {
                        bool __tmp30_first = true;
                        bool __tmp30_last = __tmp30Reader.EndOfStream;
                        while(__tmp30_first || !__tmp30_last)
                        {
                            __tmp30_first = false;
                            string __tmp30Line = __tmp30Reader.ReadLine();
                            __tmp30_last = __tmp30Reader.EndOfStream;
                            if (__tmp30Line != null) __out.Append(__tmp30Line);
                            if (!__tmp30_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp31Line = " Create"; //910:30
                    if (__tmp31Line != null) __out.Append(__tmp31Line);
                    StringBuilder __tmp32 = new StringBuilder();
                    __tmp32.Append(cls.CSharpName());
                    using(StreamReader __tmp32Reader = new StreamReader(this.__ToStream(__tmp32.ToString())))
                    {
                        bool __tmp32_first = true;
                        bool __tmp32_last = __tmp32Reader.EndOfStream;
                        while(__tmp32_first || !__tmp32_last)
                        {
                            __tmp32_first = false;
                            string __tmp32Line = __tmp32Reader.ReadLine();
                            __tmp32_last = __tmp32Reader.EndOfStream;
                            if (__tmp32Line != null) __out.Append(__tmp32Line);
                            if (!__tmp32_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp33Line = "(IEnumerable<ModelPropertyInitializer> initializers = null)"; //910:55
                    if (__tmp33Line != null) __out.Append(__tmp33Line);
                    __out.AppendLine(false); //910:114
                    __out.Append("	{"); //911:1
                    __out.AppendLine(false); //911:3
                    string __tmp34Prefix = "		"; //912:1
                    StringBuilder __tmp35 = new StringBuilder();
                    __tmp35.Append(cls.CSharpName());
                    using(StreamReader __tmp35Reader = new StreamReader(this.__ToStream(__tmp35.ToString())))
                    {
                        bool __tmp35_first = true;
                        bool __tmp35_last = __tmp35Reader.EndOfStream;
                        while(__tmp35_first || !__tmp35_last)
                        {
                            __tmp35_first = false;
                            string __tmp35Line = __tmp35Reader.ReadLine();
                            __tmp35_last = __tmp35Reader.EndOfStream;
                            __out.Append(__tmp34Prefix);
                            if (__tmp35Line != null) __out.Append(__tmp35Line);
                            if (!__tmp35_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp36Line = " result = new "; //912:21
                    if (__tmp36Line != null) __out.Append(__tmp36Line);
                    StringBuilder __tmp37 = new StringBuilder();
                    __tmp37.Append(cls.CSharpFullName());
                    using(StreamReader __tmp37Reader = new StreamReader(this.__ToStream(__tmp37.ToString())))
                    {
                        bool __tmp37_first = true;
                        bool __tmp37_last = __tmp37Reader.EndOfStream;
                        while(__tmp37_first || !__tmp37_last)
                        {
                            __tmp37_first = false;
                            string __tmp37Line = __tmp37Reader.ReadLine();
                            __tmp37_last = __tmp37Reader.EndOfStream;
                            if (__tmp37Line != null) __out.Append(__tmp37Line);
                            if (!__tmp37_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp38Line = "Impl();"; //912:57
                    if (__tmp38Line != null) __out.Append(__tmp38Line);
                    __out.AppendLine(false); //912:64
                    __out.Append("		if (initializers != null)"); //913:1
                    __out.AppendLine(false); //913:28
                    __out.Append("		{"); //914:1
                    __out.AppendLine(false); //914:4
                    __out.Append("			this.Init((ModelObject)result, initializers);"); //915:1
                    __out.AppendLine(false); //915:49
                    __out.Append("		}"); //916:1
                    __out.AppendLine(false); //916:4
                    __out.Append("		return result;"); //917:1
                    __out.AppendLine(false); //917:17
                    __out.Append("	}"); //918:1
                    __out.AppendLine(false); //918:3
                }
            }
            __out.Append("}"); //921:1
            __out.AppendLine(false); //921:2
            __out.AppendLine(true); //922:1
            return __out.ToString();
        }

        private class StringBuilder
        {
            private bool newLine;
            private System.Text.StringBuilder builder = new System.Text.StringBuilder();
            
            public StringBuilder()
            {
                this.newLine = true;
            }
            
            public void Append(string str)
            {
                if (str == null) return;
                if (!string.IsNullOrEmpty(str))
                {
                    this.newLine = false;
                }
                builder.Append(str);
            }
            
            public void Append(object obj)
            {
                if (obj == null) return;
                string text = obj.ToString();
                this.Append(text);
            }
            
            public void AppendLine(bool force = false)
            {
                if (force || !this.newLine)
                {
                    builder.AppendLine();
                    this.newLine = true;
                }
            }
            
            public override string ToString()
            {
                return builder.ToString();
            }
        }
    }
}
