using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core //1:1
{
    using __Hidden_ImmutableMetaModelGeneratorOld_1432998234;
    namespace __Hidden_ImmutableMetaModelGeneratorOld_1432998234
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

    public class ImmutableMetaModelGeneratorOld //2:1
    {
        private IEnumerable<ModelObject> Instances; //2:1

        public ImmutableMetaModelGeneratorOld() //2:1
        {
        }

        public ImmutableMetaModelGeneratorOld(IEnumerable<ModelObject> instances) : this() //2:1
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
            __out.Append("using System.Diagnostics;"); //13:1
            __out.AppendLine(false); //13:26
            __out.AppendLine(true); //14:1
            var __loop1_results = 
                (from __loop1_var1 in __Enumerate((Instances).GetEnumerator()) //15:8
                from mm in __Enumerate((__loop1_var1).GetEnumerator()).OfType<MetaModel>() //15:19
                select new { __loop1_var1 = __loop1_var1, mm = mm}
                ).ToList(); //15:3
            for (int __loop1_iteration = 0; __loop1_iteration < __loop1_results.Count; ++__loop1_iteration)
            {
                var __tmp1 = __loop1_results[__loop1_iteration];
                var __loop1_var1 = __tmp1.__loop1_var1;
                var mm = __tmp1.mm;
                bool __tmp3OutputWritten = false;
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append(GenerateMetamodel(mm));
                using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                {
                    bool __tmp4_last = __tmp4Reader.EndOfStream;
                    while(!__tmp4_last)
                    {
                        string __tmp4Line = __tmp4Reader.ReadLine();
                        __tmp4_last = __tmp4Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp4Line))
                        {
                            __out.Append(__tmp4Line);
                            __tmp3OutputWritten = true;
                        }
                        if (__tmp3OutputWritten)
                        {
                            __out.AppendLine(false); //16:24
                        }
                    }
                }
                if (__tmp3OutputWritten)
                {
                    __out.AppendLine(false); //16:24
                }
            }
            return __out.ToString();
        }

        public string GenerateMetamodel(MetaModel model) //20:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2OutputWritten = false;
            string __tmp3Line = "namespace "; //21:1
            if (!string.IsNullOrEmpty(__tmp3Line))
            {
                __out.Append(__tmp3Line);
                __tmp2OutputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(model.Namespace.CSharpName(ClassKind.Immutable));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4Line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp4Line))
                    {
                        __out.Append(__tmp4Line);
                        __tmp2OutputWritten = true;
                    }
                    if (__tmp2OutputWritten)
                    {
                        __out.AppendLine(false); //21:60
                    }
                }
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //21:60
            }
            __out.Append("{"); //22:1
            __out.AppendLine(false); //22:2
            bool __tmp6OutputWritten = false;
            string __tmp5Prefix = "    "; //23:1
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(GenerateMetaModelDescriptor(model));
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(!__tmp7_last)
                {
                    string __tmp7Line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp5Prefix))
                    {
                        __out.Append(__tmp5Prefix);
                        __tmp6OutputWritten = true;
                    }
                    if (!string.IsNullOrEmpty(__tmp7Line))
                    {
                        __out.Append(__tmp7Line);
                        __tmp6OutputWritten = true;
                    }
                    if (__tmp6OutputWritten)
                    {
                        __out.AppendLine(false); //23:41
                    }
                }
            }
            if (__tmp6OutputWritten)
            {
                __out.AppendLine(false); //23:41
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
                bool __tmp10OutputWritten = false;
                string __tmp9Prefix = "    "; //25:1
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(GenerateEnum(enm));
                using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                {
                    bool __tmp11_last = __tmp11Reader.EndOfStream;
                    while(!__tmp11_last)
                    {
                        string __tmp11Line = __tmp11Reader.ReadLine();
                        __tmp11_last = __tmp11Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp9Prefix))
                        {
                            __out.Append(__tmp9Prefix);
                            __tmp10OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp11Line))
                        {
                            __out.Append(__tmp11Line);
                            __tmp10OutputWritten = true;
                        }
                        if (__tmp10OutputWritten)
                        {
                            __out.AppendLine(false); //25:24
                        }
                    }
                }
                if (__tmp10OutputWritten)
                {
                    __out.AppendLine(false); //25:24
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
                var __tmp12 = __loop3_results[__loop3_iteration];
                var __loop3_var1 = __tmp12.__loop3_var1;
                var Namespace = __tmp12.Namespace;
                var Declarations = __tmp12.Declarations;
                var cls = __tmp12.cls;
                bool __tmp14OutputWritten = false;
                string __tmp13Prefix = "    "; //28:1
                StringBuilder __tmp15 = new StringBuilder();
                __tmp15.Append(GenerateImmutableInterface(cls));
                using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
                {
                    bool __tmp15_last = __tmp15Reader.EndOfStream;
                    while(!__tmp15_last)
                    {
                        string __tmp15Line = __tmp15Reader.ReadLine();
                        __tmp15_last = __tmp15Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp13Prefix))
                        {
                            __out.Append(__tmp13Prefix);
                            __tmp14OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp15Line))
                        {
                            __out.Append(__tmp15Line);
                            __tmp14OutputWritten = true;
                        }
                        if (__tmp14OutputWritten)
                        {
                            __out.AppendLine(false); //28:38
                        }
                    }
                }
                if (__tmp14OutputWritten)
                {
                    __out.AppendLine(false); //28:38
                }
            }
            var __loop4_results = 
                (from __loop4_var1 in __Enumerate((model).GetEnumerator()) //30:8
                from Namespace in __Enumerate((__loop4_var1.Namespace).GetEnumerator()) //30:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //30:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //30:40
                select new { __loop4_var1 = __loop4_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //30:3
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                var __tmp16 = __loop4_results[__loop4_iteration];
                var __loop4_var1 = __tmp16.__loop4_var1;
                var Namespace = __tmp16.Namespace;
                var Declarations = __tmp16.Declarations;
                var cls = __tmp16.cls;
                bool __tmp18OutputWritten = false;
                string __tmp17Prefix = "    "; //31:1
                StringBuilder __tmp19 = new StringBuilder();
                __tmp19.Append(GenerateBuilderInterface(cls));
                using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
                {
                    bool __tmp19_last = __tmp19Reader.EndOfStream;
                    while(!__tmp19_last)
                    {
                        string __tmp19Line = __tmp19Reader.ReadLine();
                        __tmp19_last = __tmp19Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp17Prefix))
                        {
                            __out.Append(__tmp17Prefix);
                            __tmp18OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp19Line))
                        {
                            __out.Append(__tmp19Line);
                            __tmp18OutputWritten = true;
                        }
                        if (__tmp18OutputWritten)
                        {
                            __out.AppendLine(false); //31:36
                        }
                    }
                }
                if (__tmp18OutputWritten)
                {
                    __out.AppendLine(false); //31:36
                }
            }
            var __loop5_results = 
                (from __loop5_var1 in __Enumerate((model).GetEnumerator()) //33:8
                from Namespace in __Enumerate((__loop5_var1.Namespace).GetEnumerator()) //33:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //33:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //33:40
                select new { __loop5_var1 = __loop5_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //33:3
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                var __tmp20 = __loop5_results[__loop5_iteration];
                var __loop5_var1 = __tmp20.__loop5_var1;
                var Namespace = __tmp20.Namespace;
                var Declarations = __tmp20.Declarations;
                var cls = __tmp20.cls;
                bool __tmp22OutputWritten = false;
                string __tmp21Prefix = "    "; //34:1
                StringBuilder __tmp23 = new StringBuilder();
                __tmp23.Append(GenerateImmutableInterfaceImpl(model, cls));
                using(StreamReader __tmp23Reader = new StreamReader(this.__ToStream(__tmp23.ToString())))
                {
                    bool __tmp23_last = __tmp23Reader.EndOfStream;
                    while(!__tmp23_last)
                    {
                        string __tmp23Line = __tmp23Reader.ReadLine();
                        __tmp23_last = __tmp23Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp21Prefix))
                        {
                            __out.Append(__tmp21Prefix);
                            __tmp22OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp23Line))
                        {
                            __out.Append(__tmp23Line);
                            __tmp22OutputWritten = true;
                        }
                        if (__tmp22OutputWritten)
                        {
                            __out.AppendLine(false); //34:49
                        }
                    }
                }
                if (__tmp22OutputWritten)
                {
                    __out.AppendLine(false); //34:49
                }
            }
            var __loop6_results = 
                (from __loop6_var1 in __Enumerate((model).GetEnumerator()) //36:8
                from Namespace in __Enumerate((__loop6_var1.Namespace).GetEnumerator()) //36:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //36:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //36:40
                select new { __loop6_var1 = __loop6_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //36:3
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp24 = __loop6_results[__loop6_iteration];
                var __loop6_var1 = __tmp24.__loop6_var1;
                var Namespace = __tmp24.Namespace;
                var Declarations = __tmp24.Declarations;
                var cls = __tmp24.cls;
                bool __tmp26OutputWritten = false;
                string __tmp25Prefix = "    "; //37:1
                StringBuilder __tmp27 = new StringBuilder();
                __tmp27.Append(GenerateBuilderInterfaceImpl(model, cls));
                using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
                {
                    bool __tmp27_last = __tmp27Reader.EndOfStream;
                    while(!__tmp27_last)
                    {
                        string __tmp27Line = __tmp27Reader.ReadLine();
                        __tmp27_last = __tmp27Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp25Prefix))
                        {
                            __out.Append(__tmp25Prefix);
                            __tmp26OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp27Line))
                        {
                            __out.Append(__tmp27Line);
                            __tmp26OutputWritten = true;
                        }
                        if (__tmp26OutputWritten)
                        {
                            __out.AppendLine(false); //37:47
                        }
                    }
                }
                if (__tmp26OutputWritten)
                {
                    __out.AppendLine(false); //37:47
                }
            }
            bool __tmp29OutputWritten = false;
            string __tmp28Prefix = "	"; //39:1
            StringBuilder __tmp30 = new StringBuilder();
            __tmp30.Append(GenerateMetaModelInstance(model));
            using(StreamReader __tmp30Reader = new StreamReader(this.__ToStream(__tmp30.ToString())))
            {
                bool __tmp30_last = __tmp30Reader.EndOfStream;
                while(!__tmp30_last)
                {
                    string __tmp30Line = __tmp30Reader.ReadLine();
                    __tmp30_last = __tmp30Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp28Prefix))
                    {
                        __out.Append(__tmp28Prefix);
                        __tmp29OutputWritten = true;
                    }
                    if (!string.IsNullOrEmpty(__tmp30Line))
                    {
                        __out.Append(__tmp30Line);
                        __tmp29OutputWritten = true;
                    }
                    if (__tmp29OutputWritten)
                    {
                        __out.AppendLine(false); //39:36
                    }
                }
            }
            if (__tmp29OutputWritten)
            {
                __out.AppendLine(false); //39:36
            }
            bool __tmp32OutputWritten = false;
            string __tmp31Prefix = "    "; //40:1
            StringBuilder __tmp33 = new StringBuilder();
            __tmp33.Append(GenerateFactory(model));
            using(StreamReader __tmp33Reader = new StreamReader(this.__ToStream(__tmp33.ToString())))
            {
                bool __tmp33_last = __tmp33Reader.EndOfStream;
                while(!__tmp33_last)
                {
                    string __tmp33Line = __tmp33Reader.ReadLine();
                    __tmp33_last = __tmp33Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp31Prefix))
                    {
                        __out.Append(__tmp31Prefix);
                        __tmp32OutputWritten = true;
                    }
                    if (!string.IsNullOrEmpty(__tmp33Line))
                    {
                        __out.Append(__tmp33Line);
                        __tmp32OutputWritten = true;
                    }
                    if (__tmp32OutputWritten)
                    {
                        __out.AppendLine(false); //40:29
                    }
                }
            }
            if (__tmp32OutputWritten)
            {
                __out.AppendLine(false); //40:29
            }
            bool __tmp35OutputWritten = false;
            string __tmp34Prefix = "    "; //41:1
            StringBuilder __tmp36 = new StringBuilder();
            __tmp36.Append(GenerateImplementationProvider(model));
            using(StreamReader __tmp36Reader = new StreamReader(this.__ToStream(__tmp36.ToString())))
            {
                bool __tmp36_last = __tmp36Reader.EndOfStream;
                while(!__tmp36_last)
                {
                    string __tmp36Line = __tmp36Reader.ReadLine();
                    __tmp36_last = __tmp36Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp34Prefix))
                    {
                        __out.Append(__tmp34Prefix);
                        __tmp35OutputWritten = true;
                    }
                    if (!string.IsNullOrEmpty(__tmp36Line))
                    {
                        __out.Append(__tmp36Line);
                        __tmp35OutputWritten = true;
                    }
                    if (__tmp35OutputWritten)
                    {
                        __out.AppendLine(false); //41:44
                    }
                }
            }
            if (__tmp35OutputWritten)
            {
                __out.AppendLine(false); //41:44
            }
            __out.Append("}"); //42:1
            __out.AppendLine(false); //42:2
            return __out.ToString();
        }

        public string GenerateDocumentation(MetaDocumentedElement elem) //45:1
        {
            StringBuilder __out = new StringBuilder();
            IList<string> lines = elem.GetDocumentationLines(); //46:2
            if (lines.Count > 0) //47:2
            {
                __out.Append("/**"); //48:1
                __out.AppendLine(false); //48:4
                __out.Append(" * <summary>"); //49:1
                __out.AppendLine(false); //49:13
                var __loop7_results = 
                    (from line in __Enumerate((lines).GetEnumerator()) //50:8
                    select new { line = line}
                    ).ToList(); //50:3
                for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
                {
                    var __tmp1 = __loop7_results[__loop7_iteration];
                    var line = __tmp1.line;
                    bool __tmp3OutputWritten = false;
                    string __tmp4Line = " * "; //51:1
                    if (!string.IsNullOrEmpty(__tmp4Line))
                    {
                        __out.Append(__tmp4Line);
                        __tmp3OutputWritten = true;
                    }
                    StringBuilder __tmp5 = new StringBuilder();
                    __tmp5.Append(line);
                    using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                    {
                        bool __tmp5_last = __tmp5Reader.EndOfStream;
                        while(!__tmp5_last)
                        {
                            string __tmp5Line = __tmp5Reader.ReadLine();
                            __tmp5_last = __tmp5Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp5Line))
                            {
                                __out.Append(__tmp5Line);
                                __tmp3OutputWritten = true;
                            }
                            if (__tmp3OutputWritten)
                            {
                                __out.AppendLine(false); //51:10
                            }
                        }
                    }
                    if (__tmp3OutputWritten)
                    {
                        __out.AppendLine(false); //51:10
                    }
                }
                __out.Append(" * </summary>"); //53:1
                __out.AppendLine(false); //53:14
                __out.Append(" */"); //54:1
                __out.AppendLine(false); //54:4
            }
            return __out.ToString();
        }

        public string GenerateAnnotations(MetaAnnotatedElement elem) //58:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop8_results = 
                (from __loop8_var1 in __Enumerate((elem).GetEnumerator()) //59:7
                from annot in __Enumerate((__loop8_var1.Annotations).GetEnumerator()) //59:13
                select new { __loop8_var1 = __loop8_var1, annot = annot}
                ).ToList(); //59:2
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp1 = __loop8_results[__loop8_iteration];
                var __loop8_var1 = __tmp1.__loop8_var1;
                var annot = __tmp1.annot;
                bool __tmp3OutputWritten = false;
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append("[");
                using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                {
                    bool __tmp4_last = __tmp4Reader.EndOfStream;
                    while(!__tmp4_last)
                    {
                        string __tmp4Line = __tmp4Reader.ReadLine();
                        __tmp4_last = __tmp4Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp4Line))
                        {
                            __out.Append(__tmp4Line);
                            __tmp3OutputWritten = true;
                        }
                        if (!__tmp4_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(annot.Name);
                using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                {
                    bool __tmp5_last = __tmp5Reader.EndOfStream;
                    while(!__tmp5_last)
                    {
                        string __tmp5Line = __tmp5Reader.ReadLine();
                        __tmp5_last = __tmp5Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp5Line))
                        {
                            __out.Append(__tmp5Line);
                            __tmp3OutputWritten = true;
                        }
                        if (!__tmp5_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp6 = new StringBuilder();
                __tmp6.Append("]");
                using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
                {
                    bool __tmp6_last = __tmp6Reader.EndOfStream;
                    while(!__tmp6_last)
                    {
                        string __tmp6Line = __tmp6Reader.ReadLine();
                        __tmp6_last = __tmp6Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp6Line))
                        {
                            __out.Append(__tmp6Line);
                            __tmp3OutputWritten = true;
                        }
                        if (__tmp3OutputWritten)
                        {
                            __out.AppendLine(false); //60:23
                        }
                    }
                }
                if (__tmp3OutputWritten)
                {
                    __out.AppendLine(false); //60:23
                }
            }
            return __out.ToString();
        }

        public string GenerateEnum(MetaEnum enm) //64:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2OutputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateAnnotations(enm));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(!__tmp3_last)
                {
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp3Line))
                    {
                        __out.Append(__tmp3Line);
                        __tmp2OutputWritten = true;
                    }
                    if (__tmp2OutputWritten)
                    {
                        __out.AppendLine(false); //65:27
                    }
                }
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //65:27
            }
            bool __tmp5OutputWritten = false;
            string __tmp6Line = "public enum "; //66:1
            if (!string.IsNullOrEmpty(__tmp6Line))
            {
                __out.Append(__tmp6Line);
                __tmp5OutputWritten = true;
            }
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(enm.CSharpName());
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(!__tmp7_last)
                {
                    string __tmp7Line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp7Line))
                    {
                        __out.Append(__tmp7Line);
                        __tmp5OutputWritten = true;
                    }
                    if (__tmp5OutputWritten)
                    {
                        __out.AppendLine(false); //66:31
                    }
                }
            }
            if (__tmp5OutputWritten)
            {
                __out.AppendLine(false); //66:31
            }
            __out.Append("{"); //67:1
            __out.AppendLine(false); //67:2
            var __loop9_results = 
                (from __loop9_var1 in __Enumerate((enm).GetEnumerator()) //68:11
                from value in __Enumerate((__loop9_var1.EnumLiterals).GetEnumerator()) //68:16
                select new { __loop9_var1 = __loop9_var1, value = value}
                ).ToList(); //68:6
            for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
            {
                var __tmp8 = __loop9_results[__loop9_iteration];
                var __loop9_var1 = __tmp8.__loop9_var1;
                var value = __tmp8.value;
                bool __tmp10OutputWritten = false;
                string __tmp9Prefix = "    "; //69:1
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(value.Name);
                using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                {
                    bool __tmp11_last = __tmp11Reader.EndOfStream;
                    while(!__tmp11_last)
                    {
                        string __tmp11Line = __tmp11Reader.ReadLine();
                        __tmp11_last = __tmp11Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp9Prefix))
                        {
                            __out.Append(__tmp9Prefix);
                            __tmp10OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp11Line))
                        {
                            __out.Append(__tmp11Line);
                            __tmp10OutputWritten = true;
                        }
                        if (!__tmp11_last) __out.AppendLine(true);
                    }
                }
                string __tmp12Line = ","; //69:17
                if (!string.IsNullOrEmpty(__tmp12Line))
                {
                    __out.Append(__tmp12Line);
                    __tmp10OutputWritten = true;
                }
                if (__tmp10OutputWritten)
                {
                    __out.AppendLine(false); //69:18
                }
                if (__tmp10OutputWritten)
                {
                    __out.AppendLine(false); //69:18
                }
            }
            __out.Append("}"); //71:1
            __out.AppendLine(false); //71:2
            __out.AppendLine(true); //72:1
            return __out.ToString();
        }

        public string GetAncestors(MetaClass cls, ClassKind classKind) //75:1
        {
            string result = ""; //76:2
            var __loop10_results = 
                (from __loop10_var1 in __Enumerate((cls).GetEnumerator()) //77:7
                from super in __Enumerate((__loop10_var1.SuperClasses).GetEnumerator()) //77:12
                select new { __loop10_var1 = __loop10_var1, super = super}
                ).ToList(); //77:2
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                string delim; //77:30
                if (__loop10_iteration+1 < __loop10_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop10_results[__loop10_iteration];
                var __loop10_var1 = __tmp1.__loop10_var1;
                var super = __tmp1.super;
                result += super.CSharpFullName(classKind) + delim; //78:3
            }
            if (result == "" && classKind == ClassKind.Immutable) //80:2
            {
                result = "global::MetaDslx.Core.Immutable.ImmutableSymbol"; //81:3
            }
            if (result == "" && classKind == ClassKind.Builder) //83:2
            {
                result = "global::MetaDslx.Core.Immutable.MutableSymbol"; //84:3
            }
            if (result != "") //86:2
            {
                result = " : " + result; //87:3
            }
            return result; //89:2
        }

        public string GetDescriptorAncestors(MetaClass cls) //92:1
        {
            string result = ""; //93:2
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((cls).GetEnumerator()) //94:7
                from super in __Enumerate((__loop11_var1.SuperClasses).GetEnumerator()) //94:12
                select new { __loop11_var1 = __loop11_var1, super = super}
                ).ToList(); //94:2
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                string delim; //94:30
                if (__loop11_iteration+1 < __loop11_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop11_results[__loop11_iteration];
                var __loop11_var1 = __tmp1.__loop11_var1;
                var super = __tmp1.super;
                result += "typeof(" + super.CSharpFullDescriptorName(ClassKind.Immutable) + ")" + delim; //95:3
            }
            return result; //97:2
        }

        public string GenerateImmutableInterface(MetaClass cls) //100:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2OutputWritten = false;
            string __tmp3Line = "internal class "; //101:1
            if (!string.IsNullOrEmpty(__tmp3Line))
            {
                __out.Append(__tmp3Line);
                __tmp2OutputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(cls.CSharpName(ClassKind.Immutable));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4Line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp4Line))
                    {
                        __out.Append(__tmp4Line);
                        __tmp2OutputWritten = true;
                    }
                    if (!__tmp4_last) __out.AppendLine(true);
                }
            }
            string __tmp5Line = "Id : global::MetaDslx.Core.Immutable.SymbolId"; //101:53
            if (!string.IsNullOrEmpty(__tmp5Line))
            {
                __out.Append(__tmp5Line);
                __tmp2OutputWritten = true;
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //101:98
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //101:98
            }
            __out.Append("{"); //102:1
            __out.AppendLine(false); //102:2
            bool __tmp7OutputWritten = false;
            string __tmp8Line = "	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return "; //103:1
            if (!string.IsNullOrEmpty(__tmp8Line))
            {
                __out.Append(__tmp8Line);
                __tmp7OutputWritten = true;
            }
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(cls.Model.CSharpDescriptorName());
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_last = __tmp9Reader.EndOfStream;
                while(!__tmp9_last)
                {
                    string __tmp9Line = __tmp9Reader.ReadLine();
                    __tmp9_last = __tmp9Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp9Line))
                    {
                        __out.Append(__tmp9Line);
                        __tmp7OutputWritten = true;
                    }
                    if (!__tmp9_last) __out.AppendLine(true);
                }
            }
            string __tmp10Line = "."; //103:131
            if (!string.IsNullOrEmpty(__tmp10Line))
            {
                __out.Append(__tmp10Line);
                __tmp7OutputWritten = true;
            }
            StringBuilder __tmp11 = new StringBuilder();
            __tmp11.Append(cls.CSharpName());
            using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
            {
                bool __tmp11_last = __tmp11Reader.EndOfStream;
                while(!__tmp11_last)
                {
                    string __tmp11Line = __tmp11Reader.ReadLine();
                    __tmp11_last = __tmp11Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp11Line))
                    {
                        __out.Append(__tmp11Line);
                        __tmp7OutputWritten = true;
                    }
                    if (!__tmp11_last) __out.AppendLine(true);
                }
            }
            string __tmp12Line = ".ModelSymbolInfo; } }"; //103:150
            if (!string.IsNullOrEmpty(__tmp12Line))
            {
                __out.Append(__tmp12Line);
                __tmp7OutputWritten = true;
            }
            if (__tmp7OutputWritten)
            {
                __out.AppendLine(false); //103:171
            }
            if (__tmp7OutputWritten)
            {
                __out.AppendLine(false); //103:171
            }
            bool __tmp14OutputWritten = false;
            string __tmp15Line = "    public override global::System.Type ImmutableType { get { return typeof("; //104:1
            if (!string.IsNullOrEmpty(__tmp15Line))
            {
                __out.Append(__tmp15Line);
                __tmp14OutputWritten = true;
            }
            StringBuilder __tmp16 = new StringBuilder();
            __tmp16.Append(cls.CSharpName(ClassKind.Immutable));
            using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
            {
                bool __tmp16_last = __tmp16Reader.EndOfStream;
                while(!__tmp16_last)
                {
                    string __tmp16Line = __tmp16Reader.ReadLine();
                    __tmp16_last = __tmp16Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp16Line))
                    {
                        __out.Append(__tmp16Line);
                        __tmp14OutputWritten = true;
                    }
                    if (!__tmp16_last) __out.AppendLine(true);
                }
            }
            string __tmp17Line = "); } }"; //104:114
            if (!string.IsNullOrEmpty(__tmp17Line))
            {
                __out.Append(__tmp17Line);
                __tmp14OutputWritten = true;
            }
            if (__tmp14OutputWritten)
            {
                __out.AppendLine(false); //104:120
            }
            if (__tmp14OutputWritten)
            {
                __out.AppendLine(false); //104:120
            }
            bool __tmp19OutputWritten = false;
            string __tmp20Line = "    public override global::System.Type MutableType { get { return typeof("; //105:1
            if (!string.IsNullOrEmpty(__tmp20Line))
            {
                __out.Append(__tmp20Line);
                __tmp19OutputWritten = true;
            }
            StringBuilder __tmp21 = new StringBuilder();
            __tmp21.Append(cls.CSharpName(ClassKind.Builder));
            using(StreamReader __tmp21Reader = new StreamReader(this.__ToStream(__tmp21.ToString())))
            {
                bool __tmp21_last = __tmp21Reader.EndOfStream;
                while(!__tmp21_last)
                {
                    string __tmp21Line = __tmp21Reader.ReadLine();
                    __tmp21_last = __tmp21Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp21Line))
                    {
                        __out.Append(__tmp21Line);
                        __tmp19OutputWritten = true;
                    }
                    if (!__tmp21_last) __out.AppendLine(true);
                }
            }
            string __tmp22Line = "); } }"; //105:110
            if (!string.IsNullOrEmpty(__tmp22Line))
            {
                __out.Append(__tmp22Line);
                __tmp19OutputWritten = true;
            }
            if (__tmp19OutputWritten)
            {
                __out.AppendLine(false); //105:116
            }
            if (__tmp19OutputWritten)
            {
                __out.AppendLine(false); //105:116
            }
            __out.AppendLine(true); //106:1
            __out.Append("    public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)"); //107:1
            __out.AppendLine(false); //107:142
            __out.Append("    {"); //108:1
            __out.AppendLine(false); //108:6
            bool __tmp24OutputWritten = false;
            string __tmp25Line = "        return new "; //109:1
            if (!string.IsNullOrEmpty(__tmp25Line))
            {
                __out.Append(__tmp25Line);
                __tmp24OutputWritten = true;
            }
            StringBuilder __tmp26 = new StringBuilder();
            __tmp26.Append(cls.CSharpImplName(ClassKind.Immutable));
            using(StreamReader __tmp26Reader = new StreamReader(this.__ToStream(__tmp26.ToString())))
            {
                bool __tmp26_last = __tmp26Reader.EndOfStream;
                while(!__tmp26_last)
                {
                    string __tmp26Line = __tmp26Reader.ReadLine();
                    __tmp26_last = __tmp26Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp26Line))
                    {
                        __out.Append(__tmp26Line);
                        __tmp24OutputWritten = true;
                    }
                    if (!__tmp26_last) __out.AppendLine(true);
                }
            }
            string __tmp27Line = "(this, model);"; //109:61
            if (!string.IsNullOrEmpty(__tmp27Line))
            {
                __out.Append(__tmp27Line);
                __tmp24OutputWritten = true;
            }
            if (__tmp24OutputWritten)
            {
                __out.AppendLine(false); //109:75
            }
            if (__tmp24OutputWritten)
            {
                __out.AppendLine(false); //109:75
            }
            __out.Append("    }"); //110:1
            __out.AppendLine(false); //110:6
            __out.AppendLine(true); //111:1
            __out.Append("    public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)"); //112:1
            __out.AppendLine(false); //112:151
            __out.Append("    {"); //113:1
            __out.AppendLine(false); //113:6
            bool __tmp29OutputWritten = false;
            string __tmp30Line = "        return new "; //114:1
            if (!string.IsNullOrEmpty(__tmp30Line))
            {
                __out.Append(__tmp30Line);
                __tmp29OutputWritten = true;
            }
            StringBuilder __tmp31 = new StringBuilder();
            __tmp31.Append(cls.CSharpImplName(ClassKind.Builder));
            using(StreamReader __tmp31Reader = new StreamReader(this.__ToStream(__tmp31.ToString())))
            {
                bool __tmp31_last = __tmp31Reader.EndOfStream;
                while(!__tmp31_last)
                {
                    string __tmp31Line = __tmp31Reader.ReadLine();
                    __tmp31_last = __tmp31Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp31Line))
                    {
                        __out.Append(__tmp31Line);
                        __tmp29OutputWritten = true;
                    }
                    if (!__tmp31_last) __out.AppendLine(true);
                }
            }
            string __tmp32Line = "(this, model, creating);"; //114:59
            if (!string.IsNullOrEmpty(__tmp32Line))
            {
                __out.Append(__tmp32Line);
                __tmp29OutputWritten = true;
            }
            if (__tmp29OutputWritten)
            {
                __out.AppendLine(false); //114:83
            }
            if (__tmp29OutputWritten)
            {
                __out.AppendLine(false); //114:83
            }
            __out.Append("    }"); //115:1
            __out.AppendLine(false); //115:6
            __out.Append("}"); //116:1
            __out.AppendLine(false); //116:2
            __out.AppendLine(true); //117:1
            bool __tmp34OutputWritten = false;
            StringBuilder __tmp35 = new StringBuilder();
            __tmp35.Append(GenerateAnnotations(cls));
            using(StreamReader __tmp35Reader = new StreamReader(this.__ToStream(__tmp35.ToString())))
            {
                bool __tmp35_last = __tmp35Reader.EndOfStream;
                while(!__tmp35_last)
                {
                    string __tmp35Line = __tmp35Reader.ReadLine();
                    __tmp35_last = __tmp35Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp35Line))
                    {
                        __out.Append(__tmp35Line);
                        __tmp34OutputWritten = true;
                    }
                    if (__tmp34OutputWritten)
                    {
                        __out.AppendLine(false); //118:27
                    }
                }
            }
            if (__tmp34OutputWritten)
            {
                __out.AppendLine(false); //118:27
            }
            bool __tmp37OutputWritten = false;
            string __tmp38Line = "public interface "; //119:1
            if (!string.IsNullOrEmpty(__tmp38Line))
            {
                __out.Append(__tmp38Line);
                __tmp37OutputWritten = true;
            }
            StringBuilder __tmp39 = new StringBuilder();
            __tmp39.Append(cls.CSharpName(ClassKind.Immutable));
            using(StreamReader __tmp39Reader = new StreamReader(this.__ToStream(__tmp39.ToString())))
            {
                bool __tmp39_last = __tmp39Reader.EndOfStream;
                while(!__tmp39_last)
                {
                    string __tmp39Line = __tmp39Reader.ReadLine();
                    __tmp39_last = __tmp39Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp39Line))
                    {
                        __out.Append(__tmp39Line);
                        __tmp37OutputWritten = true;
                    }
                    if (!__tmp39_last) __out.AppendLine(true);
                }
            }
            StringBuilder __tmp40 = new StringBuilder();
            __tmp40.Append(GetAncestors(cls, ClassKind.Immutable));
            using(StreamReader __tmp40Reader = new StreamReader(this.__ToStream(__tmp40.ToString())))
            {
                bool __tmp40_last = __tmp40Reader.EndOfStream;
                while(!__tmp40_last)
                {
                    string __tmp40Line = __tmp40Reader.ReadLine();
                    __tmp40_last = __tmp40Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp40Line))
                    {
                        __out.Append(__tmp40Line);
                        __tmp37OutputWritten = true;
                    }
                    if (__tmp37OutputWritten)
                    {
                        __out.AppendLine(false); //119:95
                    }
                }
            }
            if (__tmp37OutputWritten)
            {
                __out.AppendLine(false); //119:95
            }
            __out.Append("{"); //120:1
            __out.AppendLine(false); //120:2
            var __loop12_results = 
                (from __loop12_var1 in __Enumerate((cls).GetEnumerator()) //121:11
                from prop in __Enumerate((__loop12_var1.Properties).GetEnumerator()) //121:16
                select new { __loop12_var1 = __loop12_var1, prop = prop}
                ).ToList(); //121:6
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp41 = __loop12_results[__loop12_iteration];
                var __loop12_var1 = __tmp41.__loop12_var1;
                var prop = __tmp41.prop;
                bool __tmp43OutputWritten = false;
                string __tmp42Prefix = "    "; //122:1
                StringBuilder __tmp44 = new StringBuilder();
                __tmp44.Append(GenerateImmutableProperty(prop));
                using(StreamReader __tmp44Reader = new StreamReader(this.__ToStream(__tmp44.ToString())))
                {
                    bool __tmp44_last = __tmp44Reader.EndOfStream;
                    while(!__tmp44_last)
                    {
                        string __tmp44Line = __tmp44Reader.ReadLine();
                        __tmp44_last = __tmp44Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp42Prefix))
                        {
                            __out.Append(__tmp42Prefix);
                            __tmp43OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp44Line))
                        {
                            __out.Append(__tmp44Line);
                            __tmp43OutputWritten = true;
                        }
                        if (__tmp43OutputWritten)
                        {
                            __out.AppendLine(false); //122:38
                        }
                    }
                }
                if (__tmp43OutputWritten)
                {
                    __out.AppendLine(false); //122:38
                }
            }
            __out.AppendLine(true); //124:1
            var __loop13_results = 
                (from __loop13_var1 in __Enumerate((cls).GetEnumerator()) //125:11
                from op in __Enumerate((__loop13_var1.Operations).GetEnumerator()) //125:16
                select new { __loop13_var1 = __loop13_var1, op = op}
                ).ToList(); //125:6
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp45 = __loop13_results[__loop13_iteration];
                var __loop13_var1 = __tmp45.__loop13_var1;
                var op = __tmp45.op;
                bool __tmp47OutputWritten = false;
                string __tmp46Prefix = "    "; //126:1
                StringBuilder __tmp48 = new StringBuilder();
                __tmp48.Append(GenerateOperation(op));
                using(StreamReader __tmp48Reader = new StreamReader(this.__ToStream(__tmp48.ToString())))
                {
                    bool __tmp48_last = __tmp48Reader.EndOfStream;
                    while(!__tmp48_last)
                    {
                        string __tmp48Line = __tmp48Reader.ReadLine();
                        __tmp48_last = __tmp48Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp46Prefix))
                        {
                            __out.Append(__tmp46Prefix);
                            __tmp47OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp48Line))
                        {
                            __out.Append(__tmp48Line);
                            __tmp47OutputWritten = true;
                        }
                        if (__tmp47OutputWritten)
                        {
                            __out.AppendLine(false); //126:28
                        }
                    }
                }
                if (__tmp47OutputWritten)
                {
                    __out.AppendLine(false); //126:28
                }
            }
            __out.AppendLine(true); //128:1
            bool __tmp50OutputWritten = false;
            string __tmp51Line = "	new "; //129:1
            if (!string.IsNullOrEmpty(__tmp51Line))
            {
                __out.Append(__tmp51Line);
                __tmp50OutputWritten = true;
            }
            StringBuilder __tmp52 = new StringBuilder();
            __tmp52.Append(cls.CSharpName(ClassKind.Builder));
            using(StreamReader __tmp52Reader = new StreamReader(this.__ToStream(__tmp52.ToString())))
            {
                bool __tmp52_last = __tmp52Reader.EndOfStream;
                while(!__tmp52_last)
                {
                    string __tmp52Line = __tmp52Reader.ReadLine();
                    __tmp52_last = __tmp52Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp52Line))
                    {
                        __out.Append(__tmp52Line);
                        __tmp50OutputWritten = true;
                    }
                    if (!__tmp52_last) __out.AppendLine(true);
                }
            }
            string __tmp53Line = " ToMutable();"; //129:41
            if (!string.IsNullOrEmpty(__tmp53Line))
            {
                __out.Append(__tmp53Line);
                __tmp50OutputWritten = true;
            }
            if (__tmp50OutputWritten)
            {
                __out.AppendLine(false); //129:54
            }
            if (__tmp50OutputWritten)
            {
                __out.AppendLine(false); //129:54
            }
            bool __tmp55OutputWritten = false;
            string __tmp56Line = "	new "; //130:1
            if (!string.IsNullOrEmpty(__tmp56Line))
            {
                __out.Append(__tmp56Line);
                __tmp55OutputWritten = true;
            }
            StringBuilder __tmp57 = new StringBuilder();
            __tmp57.Append(cls.CSharpName(ClassKind.Builder));
            using(StreamReader __tmp57Reader = new StreamReader(this.__ToStream(__tmp57.ToString())))
            {
                bool __tmp57_last = __tmp57Reader.EndOfStream;
                while(!__tmp57_last)
                {
                    string __tmp57Line = __tmp57Reader.ReadLine();
                    __tmp57_last = __tmp57Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp57Line))
                    {
                        __out.Append(__tmp57Line);
                        __tmp55OutputWritten = true;
                    }
                    if (!__tmp57_last) __out.AppendLine(true);
                }
            }
            string __tmp58Line = " ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);"; //130:41
            if (!string.IsNullOrEmpty(__tmp58Line))
            {
                __out.Append(__tmp58Line);
                __tmp55OutputWritten = true;
            }
            if (__tmp55OutputWritten)
            {
                __out.AppendLine(false); //130:104
            }
            if (__tmp55OutputWritten)
            {
                __out.AppendLine(false); //130:104
            }
            __out.Append("}"); //131:1
            __out.AppendLine(false); //131:2
            __out.AppendLine(true); //132:1
            return __out.ToString();
        }

        public string GenerateBuilderInterface(MetaClass cls) //135:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2OutputWritten = false;
            string __tmp3Line = "public interface "; //136:1
            if (!string.IsNullOrEmpty(__tmp3Line))
            {
                __out.Append(__tmp3Line);
                __tmp2OutputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(cls.CSharpName(ClassKind.Builder));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4Line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp4Line))
                    {
                        __out.Append(__tmp4Line);
                        __tmp2OutputWritten = true;
                    }
                    if (!__tmp4_last) __out.AppendLine(true);
                }
            }
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(GetAncestors(cls, ClassKind.Builder));
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_last = __tmp5Reader.EndOfStream;
                while(!__tmp5_last)
                {
                    string __tmp5Line = __tmp5Reader.ReadLine();
                    __tmp5_last = __tmp5Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp5Line))
                    {
                        __out.Append(__tmp5Line);
                        __tmp2OutputWritten = true;
                    }
                    if (__tmp2OutputWritten)
                    {
                        __out.AppendLine(false); //136:91
                    }
                }
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //136:91
            }
            __out.Append("{"); //137:1
            __out.AppendLine(false); //137:2
            var __loop14_results = 
                (from __loop14_var1 in __Enumerate((cls).GetEnumerator()) //138:11
                from prop in __Enumerate((__loop14_var1.Properties).GetEnumerator()) //138:16
                select new { __loop14_var1 = __loop14_var1, prop = prop}
                ).ToList(); //138:6
            for (int __loop14_iteration = 0; __loop14_iteration < __loop14_results.Count; ++__loop14_iteration)
            {
                var __tmp6 = __loop14_results[__loop14_iteration];
                var __loop14_var1 = __tmp6.__loop14_var1;
                var prop = __tmp6.prop;
                bool __tmp8OutputWritten = false;
                string __tmp7Prefix = "    "; //139:1
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append(GenerateBuilderProperty(prop));
                using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                {
                    bool __tmp9_last = __tmp9Reader.EndOfStream;
                    while(!__tmp9_last)
                    {
                        string __tmp9Line = __tmp9Reader.ReadLine();
                        __tmp9_last = __tmp9Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp7Prefix))
                        {
                            __out.Append(__tmp7Prefix);
                            __tmp8OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp9Line))
                        {
                            __out.Append(__tmp9Line);
                            __tmp8OutputWritten = true;
                        }
                        if (__tmp8OutputWritten)
                        {
                            __out.AppendLine(false); //139:36
                        }
                    }
                }
                if (__tmp8OutputWritten)
                {
                    __out.AppendLine(false); //139:36
                }
            }
            __out.AppendLine(true); //141:1
            bool __tmp11OutputWritten = false;
            string __tmp12Line = "	new "; //142:1
            if (!string.IsNullOrEmpty(__tmp12Line))
            {
                __out.Append(__tmp12Line);
                __tmp11OutputWritten = true;
            }
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(cls.CSharpName(ClassKind.Immutable));
            using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
            {
                bool __tmp13_last = __tmp13Reader.EndOfStream;
                while(!__tmp13_last)
                {
                    string __tmp13Line = __tmp13Reader.ReadLine();
                    __tmp13_last = __tmp13Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp13Line))
                    {
                        __out.Append(__tmp13Line);
                        __tmp11OutputWritten = true;
                    }
                    if (!__tmp13_last) __out.AppendLine(true);
                }
            }
            string __tmp14Line = " ToImmutable();"; //142:43
            if (!string.IsNullOrEmpty(__tmp14Line))
            {
                __out.Append(__tmp14Line);
                __tmp11OutputWritten = true;
            }
            if (__tmp11OutputWritten)
            {
                __out.AppendLine(false); //142:58
            }
            if (__tmp11OutputWritten)
            {
                __out.AppendLine(false); //142:58
            }
            bool __tmp16OutputWritten = false;
            string __tmp17Line = "	new "; //143:1
            if (!string.IsNullOrEmpty(__tmp17Line))
            {
                __out.Append(__tmp17Line);
                __tmp16OutputWritten = true;
            }
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append(cls.CSharpName(ClassKind.Immutable));
            using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
            {
                bool __tmp18_last = __tmp18Reader.EndOfStream;
                while(!__tmp18_last)
                {
                    string __tmp18Line = __tmp18Reader.ReadLine();
                    __tmp18_last = __tmp18Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp18Line))
                    {
                        __out.Append(__tmp18Line);
                        __tmp16OutputWritten = true;
                    }
                    if (!__tmp18_last) __out.AppendLine(true);
                }
            }
            string __tmp19Line = " ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);"; //143:43
            if (!string.IsNullOrEmpty(__tmp19Line))
            {
                __out.Append(__tmp19Line);
                __tmp16OutputWritten = true;
            }
            if (__tmp16OutputWritten)
            {
                __out.AppendLine(false); //143:110
            }
            if (__tmp16OutputWritten)
            {
                __out.AppendLine(false); //143:110
            }
            __out.Append("}"); //144:1
            __out.AppendLine(false); //144:2
            __out.AppendLine(true); //145:1
            return __out.ToString();
        }

        public string GenerateImmutableProperty(MetaProperty prop) //148:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //149:2
            {
                __out.Append("new "); //150:1
            }
            bool __tmp2OutputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(prop.Type.CSharpFullPublicName(ClassKind.Immutable));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(!__tmp3_last)
                {
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp3Line))
                    {
                        __out.Append(__tmp3Line);
                        __tmp2OutputWritten = true;
                    }
                    if (!__tmp3_last) __out.AppendLine(true);
                }
            }
            string __tmp4Line = " "; //152:54
            if (!string.IsNullOrEmpty(__tmp4Line))
            {
                __out.Append(__tmp4Line);
                __tmp2OutputWritten = true;
            }
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(prop.Name);
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_last = __tmp5Reader.EndOfStream;
                while(!__tmp5_last)
                {
                    string __tmp5Line = __tmp5Reader.ReadLine();
                    __tmp5_last = __tmp5Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp5Line))
                    {
                        __out.Append(__tmp5Line);
                        __tmp2OutputWritten = true;
                    }
                    if (!__tmp5_last) __out.AppendLine(true);
                }
            }
            string __tmp6Line = " { get; }"; //152:66
            if (!string.IsNullOrEmpty(__tmp6Line))
            {
                __out.Append(__tmp6Line);
                __tmp2OutputWritten = true;
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //152:75
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //152:75
            }
            return __out.ToString();
        }

        public string GenerateImmutableField(MetaClass cls, MetaProperty prop) //155:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2OutputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(!__tmp3_last)
                {
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp3Line))
                    {
                        __out.Append(__tmp3Line);
                        __tmp2OutputWritten = true;
                    }
                    if (__tmp2OutputWritten)
                    {
                        __out.AppendLine(false); //156:54
                    }
                }
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //156:54
            }
            bool __tmp5OutputWritten = false;
            string __tmp6Line = "private "; //157:1
            if (!string.IsNullOrEmpty(__tmp6Line))
            {
                __out.Append(__tmp6Line);
                __tmp5OutputWritten = true;
            }
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(prop.Type.CSharpFullPublicName(ClassKind.Immutable));
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(!__tmp7_last)
                {
                    string __tmp7Line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp7Line))
                    {
                        __out.Append(__tmp7Line);
                        __tmp5OutputWritten = true;
                    }
                    if (!__tmp7_last) __out.AppendLine(true);
                }
            }
            string __tmp8Line = " "; //157:62
            if (!string.IsNullOrEmpty(__tmp8Line))
            {
                __out.Append(__tmp8Line);
                __tmp5OutputWritten = true;
            }
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(prop.GetFieldName(cls));
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_last = __tmp9Reader.EndOfStream;
                while(!__tmp9_last)
                {
                    string __tmp9Line = __tmp9Reader.ReadLine();
                    __tmp9_last = __tmp9Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp9Line))
                    {
                        __out.Append(__tmp9Line);
                        __tmp5OutputWritten = true;
                    }
                    if (!__tmp9_last) __out.AppendLine(true);
                }
            }
            string __tmp10Line = ";"; //157:87
            if (!string.IsNullOrEmpty(__tmp10Line))
            {
                __out.Append(__tmp10Line);
                __tmp5OutputWritten = true;
            }
            if (__tmp5OutputWritten)
            {
                __out.AppendLine(false); //157:88
            }
            if (__tmp5OutputWritten)
            {
                __out.AppendLine(false); //157:88
            }
            return __out.ToString();
        }

        public string GenerateBuilderProperty(MetaProperty prop) //160:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //161:2
            {
                __out.Append("new "); //162:1
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //164:3
            {
                bool __tmp2OutputWritten = false;
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_last = __tmp3Reader.EndOfStream;
                    while(!__tmp3_last)
                    {
                        string __tmp3Line = __tmp3Reader.ReadLine();
                        __tmp3_last = __tmp3Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp3Line))
                        {
                            __out.Append(__tmp3Line);
                            __tmp2OutputWritten = true;
                        }
                        if (!__tmp3_last) __out.AppendLine(true);
                    }
                }
                string __tmp4Line = " "; //165:52
                if (!string.IsNullOrEmpty(__tmp4Line))
                {
                    __out.Append(__tmp4Line);
                    __tmp2OutputWritten = true;
                }
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(prop.Name);
                using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                {
                    bool __tmp5_last = __tmp5Reader.EndOfStream;
                    while(!__tmp5_last)
                    {
                        string __tmp5Line = __tmp5Reader.ReadLine();
                        __tmp5_last = __tmp5Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp5Line))
                        {
                            __out.Append(__tmp5Line);
                            __tmp2OutputWritten = true;
                        }
                        if (!__tmp5_last) __out.AppendLine(true);
                    }
                }
                string __tmp6Line = " { get; set; }"; //165:64
                if (!string.IsNullOrEmpty(__tmp6Line))
                {
                    __out.Append(__tmp6Line);
                    __tmp2OutputWritten = true;
                }
                if (__tmp2OutputWritten)
                {
                    __out.AppendLine(false); //165:78
                }
                if (__tmp2OutputWritten)
                {
                    __out.AppendLine(false); //165:78
                }
            }
            else //166:3
            {
                bool __tmp8OutputWritten = false;
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                {
                    bool __tmp9_last = __tmp9Reader.EndOfStream;
                    while(!__tmp9_last)
                    {
                        string __tmp9Line = __tmp9Reader.ReadLine();
                        __tmp9_last = __tmp9Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp9Line))
                        {
                            __out.Append(__tmp9Line);
                            __tmp8OutputWritten = true;
                        }
                        if (!__tmp9_last) __out.AppendLine(true);
                    }
                }
                string __tmp10Line = " "; //167:52
                if (!string.IsNullOrEmpty(__tmp10Line))
                {
                    __out.Append(__tmp10Line);
                    __tmp8OutputWritten = true;
                }
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(prop.Name);
                using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                {
                    bool __tmp11_last = __tmp11Reader.EndOfStream;
                    while(!__tmp11_last)
                    {
                        string __tmp11Line = __tmp11Reader.ReadLine();
                        __tmp11_last = __tmp11Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp11Line))
                        {
                            __out.Append(__tmp11Line);
                            __tmp8OutputWritten = true;
                        }
                        if (!__tmp11_last) __out.AppendLine(true);
                    }
                }
                string __tmp12Line = " { get; }"; //167:64
                if (!string.IsNullOrEmpty(__tmp12Line))
                {
                    __out.Append(__tmp12Line);
                    __tmp8OutputWritten = true;
                }
                if (__tmp8OutputWritten)
                {
                    __out.AppendLine(false); //167:73
                }
                if (__tmp8OutputWritten)
                {
                    __out.AppendLine(false); //167:73
                }
            }
            if (!(prop.Type is MetaCollectionType)) //169:2
            {
                if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //170:3
                {
                    __out.Append("new "); //171:1
                }
                bool __tmp14OutputWritten = false;
                string __tmp15Line = "Func<"; //173:1
                if (!string.IsNullOrEmpty(__tmp15Line))
                {
                    __out.Append(__tmp15Line);
                    __tmp14OutputWritten = true;
                }
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
                {
                    bool __tmp16_last = __tmp16Reader.EndOfStream;
                    while(!__tmp16_last)
                    {
                        string __tmp16Line = __tmp16Reader.ReadLine();
                        __tmp16_last = __tmp16Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp16Line))
                        {
                            __out.Append(__tmp16Line);
                            __tmp14OutputWritten = true;
                        }
                        if (!__tmp16_last) __out.AppendLine(true);
                    }
                }
                string __tmp17Line = "> "; //173:57
                if (!string.IsNullOrEmpty(__tmp17Line))
                {
                    __out.Append(__tmp17Line);
                    __tmp14OutputWritten = true;
                }
                StringBuilder __tmp18 = new StringBuilder();
                __tmp18.Append(prop.Name);
                using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
                {
                    bool __tmp18_last = __tmp18Reader.EndOfStream;
                    while(!__tmp18_last)
                    {
                        string __tmp18Line = __tmp18Reader.ReadLine();
                        __tmp18_last = __tmp18Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp18Line))
                        {
                            __out.Append(__tmp18Line);
                            __tmp14OutputWritten = true;
                        }
                        if (!__tmp18_last) __out.AppendLine(true);
                    }
                }
                string __tmp19Line = "Lazy { get; set; }"; //173:70
                if (!string.IsNullOrEmpty(__tmp19Line))
                {
                    __out.Append(__tmp19Line);
                    __tmp14OutputWritten = true;
                }
                if (__tmp14OutputWritten)
                {
                    __out.AppendLine(false); //173:88
                }
                if (__tmp14OutputWritten)
                {
                    __out.AppendLine(false); //173:88
                }
            }
            if (prop.Kind == MetaPropertyKind.Containment && (((prop.Type is MetaCollectionType) && (((MetaCollectionType)prop.Type).InnerType is MetaClass)) || (!(prop.Type is MetaCollectionType) && prop.Type is MetaClass))) //175:2
            {
                if (prop.Class.GetAllSuperPropertyNames().Contains(prop.Name)) //176:3
                {
                    __out.Append("new "); //177:1
                }
            }
            return __out.ToString();
        }

        public string GenerateBuilderField(MetaClass cls, MetaProperty prop) //182:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2OutputWritten = false;
            string __tmp3Line = "private "; //183:1
            if (!string.IsNullOrEmpty(__tmp3Line))
            {
                __out.Append(__tmp3Line);
                __tmp2OutputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4Line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp4Line))
                    {
                        __out.Append(__tmp4Line);
                        __tmp2OutputWritten = true;
                    }
                    if (!__tmp4_last) __out.AppendLine(true);
                }
            }
            string __tmp5Line = " "; //183:60
            if (!string.IsNullOrEmpty(__tmp5Line))
            {
                __out.Append(__tmp5Line);
                __tmp2OutputWritten = true;
            }
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(prop.GetFieldName(cls));
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(!__tmp6_last)
                {
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp6Line))
                    {
                        __out.Append(__tmp6Line);
                        __tmp2OutputWritten = true;
                    }
                    if (!__tmp6_last) __out.AppendLine(true);
                }
            }
            string __tmp7Line = ";"; //183:85
            if (!string.IsNullOrEmpty(__tmp7Line))
            {
                __out.Append(__tmp7Line);
                __tmp2OutputWritten = true;
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //183:86
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //183:86
            }
            return __out.ToString();
        }

        public string GetParameters(MetaFunction op, ClassKind classKind) //186:1
        {
            string result = ""; //187:2
            var __loop15_results = 
                (from __loop15_var1 in __Enumerate((op).GetEnumerator()) //188:7
                from param in __Enumerate((__loop15_var1.Parameters).GetEnumerator()) //188:11
                select new { __loop15_var1 = __loop15_var1, param = param}
                ).ToList(); //188:2
            for (int __loop15_iteration = 0; __loop15_iteration < __loop15_results.Count; ++__loop15_iteration)
            {
                string delim; //188:27
                if (__loop15_iteration+1 < __loop15_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop15_results[__loop15_iteration];
                var __loop15_var1 = __tmp1.__loop15_var1;
                var param = __tmp1.param;
                result += param.Type.CSharpFullPublicName(classKind) + " " + param.Name + delim; //189:3
            }
            return result; //191:2
        }

        public string GetImplParameters(MetaClass cls, MetaOperation op) //194:1
        {
            string result = cls.CSharpFullName(ClassKind.Immutable) + " _this"; //195:2
            string delim = ", "; //196:2
            var __loop16_results = 
                (from __loop16_var1 in __Enumerate((op).GetEnumerator()) //197:7
                from param in __Enumerate((__loop16_var1.Parameters).GetEnumerator()) //197:11
                select new { __loop16_var1 = __loop16_var1, param = param}
                ).ToList(); //197:2
            for (int __loop16_iteration = 0; __loop16_iteration < __loop16_results.Count; ++__loop16_iteration)
            {
                var __tmp1 = __loop16_results[__loop16_iteration];
                var __loop16_var1 = __tmp1.__loop16_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(ClassKind.Immutable) + " " + param.Name; //198:3
            }
            return result; //200:2
        }

        public string GetImplParameters(MetaEnum enm, MetaOperation op) //203:1
        {
            string result = enm.CSharpFullName(ClassKind.Immutable) + " _this"; //204:2
            string delim = ", "; //205:2
            var __loop17_results = 
                (from __loop17_var1 in __Enumerate((op).GetEnumerator()) //206:7
                from param in __Enumerate((__loop17_var1.Parameters).GetEnumerator()) //206:11
                select new { __loop17_var1 = __loop17_var1, param = param}
                ).ToList(); //206:2
            for (int __loop17_iteration = 0; __loop17_iteration < __loop17_results.Count; ++__loop17_iteration)
            {
                var __tmp1 = __loop17_results[__loop17_iteration];
                var __loop17_var1 = __tmp1.__loop17_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(ClassKind.Immutable) + " " + param.Name; //207:3
            }
            return result; //209:2
        }

        public string GetEnumImplParameters(MetaEnum enm, MetaOperation op) //212:1
        {
            string result = "this " + enm.CSharpFullName(ClassKind.Immutable) + " _this"; //213:2
            string delim = ", "; //214:2
            var __loop18_results = 
                (from __loop18_var1 in __Enumerate((op).GetEnumerator()) //215:7
                from param in __Enumerate((__loop18_var1.Parameters).GetEnumerator()) //215:11
                select new { __loop18_var1 = __loop18_var1, param = param}
                ).ToList(); //215:2
            for (int __loop18_iteration = 0; __loop18_iteration < __loop18_results.Count; ++__loop18_iteration)
            {
                var __tmp1 = __loop18_results[__loop18_iteration];
                var __loop18_var1 = __tmp1.__loop18_var1;
                var param = __tmp1.param;
                result += delim + param.Type.CSharpFullPublicName(ClassKind.Immutable) + " " + param.Name; //216:3
            }
            return result; //218:2
        }

        public string GetEnumImplCallParameterNames(MetaOperation op) //221:1
        {
            string result = "_this"; //222:2
            string delim = ", "; //223:2
            var __loop19_results = 
                (from __loop19_var1 in __Enumerate((op).GetEnumerator()) //224:7
                from param in __Enumerate((__loop19_var1.Parameters).GetEnumerator()) //224:11
                select new { __loop19_var1 = __loop19_var1, param = param}
                ).ToList(); //224:2
            for (int __loop19_iteration = 0; __loop19_iteration < __loop19_results.Count; ++__loop19_iteration)
            {
                var __tmp1 = __loop19_results[__loop19_iteration];
                var __loop19_var1 = __tmp1.__loop19_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //225:3
            }
            return result; //227:2
        }

        public string GetImplCallParameterNames(MetaOperation op) //230:1
        {
            string result = "this"; //231:2
            string delim = ", "; //232:2
            var __loop20_results = 
                (from __loop20_var1 in __Enumerate((op).GetEnumerator()) //233:7
                from param in __Enumerate((__loop20_var1.Parameters).GetEnumerator()) //233:11
                select new { __loop20_var1 = __loop20_var1, param = param}
                ).ToList(); //233:2
            for (int __loop20_iteration = 0; __loop20_iteration < __loop20_results.Count; ++__loop20_iteration)
            {
                var __tmp1 = __loop20_results[__loop20_iteration];
                var __loop20_var1 = __tmp1.__loop20_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //234:3
            }
            return result; //236:2
        }

        public string GenerateOperation(MetaOperation op) //239:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2OutputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(op.ReturnType.CSharpFullPublicName(ClassKind.Immutable));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(!__tmp3_last)
                {
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp3Line))
                    {
                        __out.Append(__tmp3Line);
                        __tmp2OutputWritten = true;
                    }
                    if (!__tmp3_last) __out.AppendLine(true);
                }
            }
            string __tmp4Line = " "; //240:58
            if (!string.IsNullOrEmpty(__tmp4Line))
            {
                __out.Append(__tmp4Line);
                __tmp2OutputWritten = true;
            }
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(op.Name);
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_last = __tmp5Reader.EndOfStream;
                while(!__tmp5_last)
                {
                    string __tmp5Line = __tmp5Reader.ReadLine();
                    __tmp5_last = __tmp5Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp5Line))
                    {
                        __out.Append(__tmp5Line);
                        __tmp2OutputWritten = true;
                    }
                    if (!__tmp5_last) __out.AppendLine(true);
                }
            }
            string __tmp6Line = "("; //240:68
            if (!string.IsNullOrEmpty(__tmp6Line))
            {
                __out.Append(__tmp6Line);
                __tmp2OutputWritten = true;
            }
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(GetParameters(op, ClassKind.Immutable));
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(!__tmp7_last)
                {
                    string __tmp7Line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp7Line))
                    {
                        __out.Append(__tmp7Line);
                        __tmp2OutputWritten = true;
                    }
                    if (!__tmp7_last) __out.AppendLine(true);
                }
            }
            string __tmp8Line = ");"; //240:109
            if (!string.IsNullOrEmpty(__tmp8Line))
            {
                __out.Append(__tmp8Line);
                __tmp2OutputWritten = true;
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //240:111
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //240:111
            }
            return __out.ToString();
        }

        public string GenerateImmutableInterfaceImpl(MetaModel model, MetaClass cls) //243:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2OutputWritten = false;
            string __tmp3Line = "internal class "; //244:1
            if (!string.IsNullOrEmpty(__tmp3Line))
            {
                __out.Append(__tmp3Line);
                __tmp2OutputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(cls.CSharpImplName(ClassKind.Immutable));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4Line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp4Line))
                    {
                        __out.Append(__tmp4Line);
                        __tmp2OutputWritten = true;
                    }
                    if (!__tmp4_last) __out.AppendLine(true);
                }
            }
            string __tmp5Line = " : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, "; //244:57
            if (!string.IsNullOrEmpty(__tmp5Line))
            {
                __out.Append(__tmp5Line);
                __tmp2OutputWritten = true;
            }
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(cls.CSharpFullName(ClassKind.Immutable));
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(!__tmp6_last)
                {
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp6Line))
                    {
                        __out.Append(__tmp6Line);
                        __tmp2OutputWritten = true;
                    }
                    if (__tmp2OutputWritten)
                    {
                        __out.AppendLine(false); //244:154
                    }
                }
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //244:154
            }
            __out.Append("{"); //245:1
            __out.AppendLine(false); //245:2
            var __loop21_results = 
                (from __loop21_var1 in __Enumerate((cls).GetEnumerator()) //246:11
                from prop in __Enumerate((__loop21_var1.GetAllProperties()).GetEnumerator()) //246:16
                select new { __loop21_var1 = __loop21_var1, prop = prop}
                ).ToList(); //246:6
            for (int __loop21_iteration = 0; __loop21_iteration < __loop21_results.Count; ++__loop21_iteration)
            {
                var __tmp7 = __loop21_results[__loop21_iteration];
                var __loop21_var1 = __tmp7.__loop21_var1;
                var prop = __tmp7.prop;
                bool __tmp9OutputWritten = false;
                string __tmp8Prefix = "    "; //247:1
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(GenerateImmutableField(cls, prop));
                using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
                {
                    bool __tmp10_last = __tmp10Reader.EndOfStream;
                    while(!__tmp10_last)
                    {
                        string __tmp10Line = __tmp10Reader.ReadLine();
                        __tmp10_last = __tmp10Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp8Prefix))
                        {
                            __out.Append(__tmp8Prefix);
                            __tmp9OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp10Line))
                        {
                            __out.Append(__tmp10Line);
                            __tmp9OutputWritten = true;
                        }
                        if (__tmp9OutputWritten)
                        {
                            __out.AppendLine(false); //247:40
                        }
                    }
                }
                if (__tmp9OutputWritten)
                {
                    __out.AppendLine(false); //247:40
                }
            }
            __out.AppendLine(true); //249:1
            bool __tmp12OutputWritten = false;
            string __tmp13Line = "    internal "; //250:1
            if (!string.IsNullOrEmpty(__tmp13Line))
            {
                __out.Append(__tmp13Line);
                __tmp12OutputWritten = true;
            }
            StringBuilder __tmp14 = new StringBuilder();
            __tmp14.Append(cls.CSharpImplName());
            using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
            {
                bool __tmp14_last = __tmp14Reader.EndOfStream;
                while(!__tmp14_last)
                {
                    string __tmp14Line = __tmp14Reader.ReadLine();
                    __tmp14_last = __tmp14Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp14Line))
                    {
                        __out.Append(__tmp14Line);
                        __tmp12OutputWritten = true;
                    }
                    if (!__tmp14_last) __out.AppendLine(true);
                }
            }
            string __tmp15Line = "(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)"; //250:36
            if (!string.IsNullOrEmpty(__tmp15Line))
            {
                __out.Append(__tmp15Line);
                __tmp12OutputWritten = true;
            }
            if (__tmp12OutputWritten)
            {
                __out.AppendLine(false); //250:135
            }
            if (__tmp12OutputWritten)
            {
                __out.AppendLine(false); //250:135
            }
            __out.Append("		: base(id, model)"); //251:1
            __out.AppendLine(false); //251:20
            __out.Append("    {"); //252:1
            __out.AppendLine(false); //252:6
            __out.Append("    }"); //253:1
            __out.AppendLine(false); //253:6
            __out.AppendLine(true); //254:1
            __out.Append("    public override MetaModel MMetaModel"); //255:1
            __out.AppendLine(false); //255:41
            __out.Append("    {"); //256:1
            __out.AppendLine(false); //256:6
            bool __tmp17OutputWritten = false;
            string __tmp18Line = "        get { return "; //257:1
            if (!string.IsNullOrEmpty(__tmp18Line))
            {
                __out.Append(__tmp18Line);
                __tmp17OutputWritten = true;
            }
            StringBuilder __tmp19 = new StringBuilder();
            __tmp19.Append(cls.Model.CSharpFullInstanceName(ClassKind.Immutable));
            using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
            {
                bool __tmp19_last = __tmp19Reader.EndOfStream;
                while(!__tmp19_last)
                {
                    string __tmp19Line = __tmp19Reader.ReadLine();
                    __tmp19_last = __tmp19Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp19Line))
                    {
                        __out.Append(__tmp19Line);
                        __tmp17OutputWritten = true;
                    }
                    if (!__tmp19_last) __out.AppendLine(true);
                }
            }
            string __tmp20Line = "; }"; //257:77
            if (!string.IsNullOrEmpty(__tmp20Line))
            {
                __out.Append(__tmp20Line);
                __tmp17OutputWritten = true;
            }
            if (__tmp17OutputWritten)
            {
                __out.AppendLine(false); //257:80
            }
            if (__tmp17OutputWritten)
            {
                __out.AppendLine(false); //257:80
            }
            __out.Append("    }"); //258:1
            __out.AppendLine(false); //258:6
            __out.AppendLine(true); //259:1
            __out.Append("    public override MetaClass MMetaClass"); //260:1
            __out.AppendLine(false); //260:41
            __out.Append("    {"); //261:1
            __out.AppendLine(false); //261:6
            bool __tmp22OutputWritten = false;
            string __tmp23Line = "        get { return "; //262:1
            if (!string.IsNullOrEmpty(__tmp23Line))
            {
                __out.Append(__tmp23Line);
                __tmp22OutputWritten = true;
            }
            StringBuilder __tmp24 = new StringBuilder();
            __tmp24.Append(cls.CSharpFullInstanceName(ClassKind.Immutable));
            using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
            {
                bool __tmp24_last = __tmp24Reader.EndOfStream;
                while(!__tmp24_last)
                {
                    string __tmp24Line = __tmp24Reader.ReadLine();
                    __tmp24_last = __tmp24Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp24Line))
                    {
                        __out.Append(__tmp24Line);
                        __tmp22OutputWritten = true;
                    }
                    if (!__tmp24_last) __out.AppendLine(true);
                }
            }
            string __tmp25Line = "; }"; //262:71
            if (!string.IsNullOrEmpty(__tmp25Line))
            {
                __out.Append(__tmp25Line);
                __tmp22OutputWritten = true;
            }
            if (__tmp22OutputWritten)
            {
                __out.AppendLine(false); //262:74
            }
            if (__tmp22OutputWritten)
            {
                __out.AppendLine(false); //262:74
            }
            __out.Append("    }"); //263:1
            __out.AppendLine(false); //263:6
            __out.AppendLine(true); //264:1
            bool __tmp27OutputWritten = false;
            string __tmp28Line = "    public new "; //265:1
            if (!string.IsNullOrEmpty(__tmp28Line))
            {
                __out.Append(__tmp28Line);
                __tmp27OutputWritten = true;
            }
            StringBuilder __tmp29 = new StringBuilder();
            __tmp29.Append(cls.CSharpFullName(ClassKind.Builder));
            using(StreamReader __tmp29Reader = new StreamReader(this.__ToStream(__tmp29.ToString())))
            {
                bool __tmp29_last = __tmp29Reader.EndOfStream;
                while(!__tmp29_last)
                {
                    string __tmp29Line = __tmp29Reader.ReadLine();
                    __tmp29_last = __tmp29Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp29Line))
                    {
                        __out.Append(__tmp29Line);
                        __tmp27OutputWritten = true;
                    }
                    if (!__tmp29_last) __out.AppendLine(true);
                }
            }
            string __tmp30Line = " ToMutable()"; //265:55
            if (!string.IsNullOrEmpty(__tmp30Line))
            {
                __out.Append(__tmp30Line);
                __tmp27OutputWritten = true;
            }
            if (__tmp27OutputWritten)
            {
                __out.AppendLine(false); //265:67
            }
            if (__tmp27OutputWritten)
            {
                __out.AppendLine(false); //265:67
            }
            __out.Append("	{"); //266:1
            __out.AppendLine(false); //266:3
            bool __tmp32OutputWritten = false;
            string __tmp33Line = "		return ("; //267:1
            if (!string.IsNullOrEmpty(__tmp33Line))
            {
                __out.Append(__tmp33Line);
                __tmp32OutputWritten = true;
            }
            StringBuilder __tmp34 = new StringBuilder();
            __tmp34.Append(cls.CSharpFullName(ClassKind.Builder));
            using(StreamReader __tmp34Reader = new StreamReader(this.__ToStream(__tmp34.ToString())))
            {
                bool __tmp34_last = __tmp34Reader.EndOfStream;
                while(!__tmp34_last)
                {
                    string __tmp34Line = __tmp34Reader.ReadLine();
                    __tmp34_last = __tmp34Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp34Line))
                    {
                        __out.Append(__tmp34Line);
                        __tmp32OutputWritten = true;
                    }
                    if (!__tmp34_last) __out.AppendLine(true);
                }
            }
            string __tmp35Line = ")base.ToMutable();"; //267:50
            if (!string.IsNullOrEmpty(__tmp35Line))
            {
                __out.Append(__tmp35Line);
                __tmp32OutputWritten = true;
            }
            if (__tmp32OutputWritten)
            {
                __out.AppendLine(false); //267:68
            }
            if (__tmp32OutputWritten)
            {
                __out.AppendLine(false); //267:68
            }
            __out.Append("	}"); //268:1
            __out.AppendLine(false); //268:3
            __out.AppendLine(true); //269:1
            bool __tmp37OutputWritten = false;
            string __tmp38Line = "    public new "; //270:1
            if (!string.IsNullOrEmpty(__tmp38Line))
            {
                __out.Append(__tmp38Line);
                __tmp37OutputWritten = true;
            }
            StringBuilder __tmp39 = new StringBuilder();
            __tmp39.Append(cls.CSharpFullName(ClassKind.Builder));
            using(StreamReader __tmp39Reader = new StreamReader(this.__ToStream(__tmp39.ToString())))
            {
                bool __tmp39_last = __tmp39Reader.EndOfStream;
                while(!__tmp39_last)
                {
                    string __tmp39Line = __tmp39Reader.ReadLine();
                    __tmp39_last = __tmp39Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp39Line))
                    {
                        __out.Append(__tmp39Line);
                        __tmp37OutputWritten = true;
                    }
                    if (!__tmp39_last) __out.AppendLine(true);
                }
            }
            string __tmp40Line = " ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)"; //270:55
            if (!string.IsNullOrEmpty(__tmp40Line))
            {
                __out.Append(__tmp40Line);
                __tmp37OutputWritten = true;
            }
            if (__tmp37OutputWritten)
            {
                __out.AppendLine(false); //270:117
            }
            if (__tmp37OutputWritten)
            {
                __out.AppendLine(false); //270:117
            }
            __out.Append("	{"); //271:1
            __out.AppendLine(false); //271:3
            bool __tmp42OutputWritten = false;
            string __tmp43Line = "		return ("; //272:1
            if (!string.IsNullOrEmpty(__tmp43Line))
            {
                __out.Append(__tmp43Line);
                __tmp42OutputWritten = true;
            }
            StringBuilder __tmp44 = new StringBuilder();
            __tmp44.Append(cls.CSharpFullName(ClassKind.Builder));
            using(StreamReader __tmp44Reader = new StreamReader(this.__ToStream(__tmp44.ToString())))
            {
                bool __tmp44_last = __tmp44Reader.EndOfStream;
                while(!__tmp44_last)
                {
                    string __tmp44Line = __tmp44Reader.ReadLine();
                    __tmp44_last = __tmp44Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp44Line))
                    {
                        __out.Append(__tmp44Line);
                        __tmp42OutputWritten = true;
                    }
                    if (!__tmp44_last) __out.AppendLine(true);
                }
            }
            string __tmp45Line = ")base.ToMutable(model);"; //272:50
            if (!string.IsNullOrEmpty(__tmp45Line))
            {
                __out.Append(__tmp45Line);
                __tmp42OutputWritten = true;
            }
            if (__tmp42OutputWritten)
            {
                __out.AppendLine(false); //272:73
            }
            if (__tmp42OutputWritten)
            {
                __out.AppendLine(false); //272:73
            }
            __out.Append("	}"); //273:1
            __out.AppendLine(false); //273:3
            var __loop22_results = 
                (from __loop22_var1 in __Enumerate((cls).GetEnumerator()) //274:8
                from sup in __Enumerate((__loop22_var1.GetAllSuperClasses()).GetEnumerator()) //274:13
                select new { __loop22_var1 = __loop22_var1, sup = sup}
                ).ToList(); //274:3
            for (int __loop22_iteration = 0; __loop22_iteration < __loop22_results.Count; ++__loop22_iteration)
            {
                var __tmp46 = __loop22_results[__loop22_iteration];
                var __loop22_var1 = __tmp46.__loop22_var1;
                var sup = __tmp46.sup;
                __out.AppendLine(true); //275:1
                bool __tmp48OutputWritten = false;
                string __tmp47Prefix = "    "; //276:1
                StringBuilder __tmp49 = new StringBuilder();
                __tmp49.Append(sup.CSharpFullName(ClassKind.Builder));
                using(StreamReader __tmp49Reader = new StreamReader(this.__ToStream(__tmp49.ToString())))
                {
                    bool __tmp49_last = __tmp49Reader.EndOfStream;
                    while(!__tmp49_last)
                    {
                        string __tmp49Line = __tmp49Reader.ReadLine();
                        __tmp49_last = __tmp49Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp47Prefix))
                        {
                            __out.Append(__tmp47Prefix);
                            __tmp48OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp49Line))
                        {
                            __out.Append(__tmp49Line);
                            __tmp48OutputWritten = true;
                        }
                        if (!__tmp49_last) __out.AppendLine(true);
                    }
                }
                string __tmp50Line = " "; //276:44
                if (!string.IsNullOrEmpty(__tmp50Line))
                {
                    __out.Append(__tmp50Line);
                    __tmp48OutputWritten = true;
                }
                StringBuilder __tmp51 = new StringBuilder();
                __tmp51.Append(sup.CSharpFullName(ClassKind.Immutable));
                using(StreamReader __tmp51Reader = new StreamReader(this.__ToStream(__tmp51.ToString())))
                {
                    bool __tmp51_last = __tmp51Reader.EndOfStream;
                    while(!__tmp51_last)
                    {
                        string __tmp51Line = __tmp51Reader.ReadLine();
                        __tmp51_last = __tmp51Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp51Line))
                        {
                            __out.Append(__tmp51Line);
                            __tmp48OutputWritten = true;
                        }
                        if (!__tmp51_last) __out.AppendLine(true);
                    }
                }
                string __tmp52Line = ".ToMutable()"; //276:86
                if (!string.IsNullOrEmpty(__tmp52Line))
                {
                    __out.Append(__tmp52Line);
                    __tmp48OutputWritten = true;
                }
                if (__tmp48OutputWritten)
                {
                    __out.AppendLine(false); //276:98
                }
                if (__tmp48OutputWritten)
                {
                    __out.AppendLine(false); //276:98
                }
                __out.Append("	{"); //277:1
                __out.AppendLine(false); //277:3
                __out.Append("		return this.ToMutable();"); //278:1
                __out.AppendLine(false); //278:27
                __out.Append("	}"); //279:1
                __out.AppendLine(false); //279:3
                __out.AppendLine(true); //280:1
                bool __tmp54OutputWritten = false;
                string __tmp53Prefix = "    "; //281:1
                StringBuilder __tmp55 = new StringBuilder();
                __tmp55.Append(sup.CSharpFullName(ClassKind.Builder));
                using(StreamReader __tmp55Reader = new StreamReader(this.__ToStream(__tmp55.ToString())))
                {
                    bool __tmp55_last = __tmp55Reader.EndOfStream;
                    while(!__tmp55_last)
                    {
                        string __tmp55Line = __tmp55Reader.ReadLine();
                        __tmp55_last = __tmp55Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp53Prefix))
                        {
                            __out.Append(__tmp53Prefix);
                            __tmp54OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp55Line))
                        {
                            __out.Append(__tmp55Line);
                            __tmp54OutputWritten = true;
                        }
                        if (!__tmp55_last) __out.AppendLine(true);
                    }
                }
                string __tmp56Line = " "; //281:44
                if (!string.IsNullOrEmpty(__tmp56Line))
                {
                    __out.Append(__tmp56Line);
                    __tmp54OutputWritten = true;
                }
                StringBuilder __tmp57 = new StringBuilder();
                __tmp57.Append(sup.CSharpFullName(ClassKind.Immutable));
                using(StreamReader __tmp57Reader = new StreamReader(this.__ToStream(__tmp57.ToString())))
                {
                    bool __tmp57_last = __tmp57Reader.EndOfStream;
                    while(!__tmp57_last)
                    {
                        string __tmp57Line = __tmp57Reader.ReadLine();
                        __tmp57_last = __tmp57Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp57Line))
                        {
                            __out.Append(__tmp57Line);
                            __tmp54OutputWritten = true;
                        }
                        if (!__tmp57_last) __out.AppendLine(true);
                    }
                }
                string __tmp58Line = ".ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)"; //281:86
                if (!string.IsNullOrEmpty(__tmp58Line))
                {
                    __out.Append(__tmp58Line);
                    __tmp54OutputWritten = true;
                }
                if (__tmp54OutputWritten)
                {
                    __out.AppendLine(false); //281:148
                }
                if (__tmp54OutputWritten)
                {
                    __out.AppendLine(false); //281:148
                }
                __out.Append("	{"); //282:1
                __out.AppendLine(false); //282:3
                __out.Append("		return this.ToMutable(model);"); //283:1
                __out.AppendLine(false); //283:32
                __out.Append("	}"); //284:1
                __out.AppendLine(false); //284:3
            }
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((cls).GetEnumerator()) //286:11
                from prop in __Enumerate((__loop23_var1.GetAllProperties()).GetEnumerator()) //286:16
                select new { __loop23_var1 = __loop23_var1, prop = prop}
                ).ToList(); //286:6
            for (int __loop23_iteration = 0; __loop23_iteration < __loop23_results.Count; ++__loop23_iteration)
            {
                var __tmp59 = __loop23_results[__loop23_iteration];
                var __loop23_var1 = __tmp59.__loop23_var1;
                var prop = __tmp59.prop;
                __out.AppendLine(true); //287:1
                bool __tmp61OutputWritten = false;
                string __tmp60Prefix = "    "; //288:1
                StringBuilder __tmp62 = new StringBuilder();
                __tmp62.Append(GenerateImmutablePropertyImpl(model, cls, prop));
                using(StreamReader __tmp62Reader = new StreamReader(this.__ToStream(__tmp62.ToString())))
                {
                    bool __tmp62_last = __tmp62Reader.EndOfStream;
                    while(!__tmp62_last)
                    {
                        string __tmp62Line = __tmp62Reader.ReadLine();
                        __tmp62_last = __tmp62Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp60Prefix))
                        {
                            __out.Append(__tmp60Prefix);
                            __tmp61OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp62Line))
                        {
                            __out.Append(__tmp62Line);
                            __tmp61OutputWritten = true;
                        }
                        if (__tmp61OutputWritten)
                        {
                            __out.AppendLine(false); //288:54
                        }
                    }
                }
                if (__tmp61OutputWritten)
                {
                    __out.AppendLine(false); //288:54
                }
            }
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((cls).GetEnumerator()) //290:11
                from op in __Enumerate((__loop24_var1.GetAllOperations()).GetEnumerator()) //290:16
                select new { __loop24_var1 = __loop24_var1, op = op}
                ).ToList(); //290:6
            for (int __loop24_iteration = 0; __loop24_iteration < __loop24_results.Count; ++__loop24_iteration)
            {
                var __tmp63 = __loop24_results[__loop24_iteration];
                var __loop24_var1 = __tmp63.__loop24_var1;
                var op = __tmp63.op;
                __out.AppendLine(true); //291:1
                bool __tmp65OutputWritten = false;
                string __tmp64Prefix = "    "; //292:1
                StringBuilder __tmp66 = new StringBuilder();
                __tmp66.Append(GenerateOperationImpl(model, op));
                using(StreamReader __tmp66Reader = new StreamReader(this.__ToStream(__tmp66.ToString())))
                {
                    bool __tmp66_last = __tmp66Reader.EndOfStream;
                    while(!__tmp66_last)
                    {
                        string __tmp66Line = __tmp66Reader.ReadLine();
                        __tmp66_last = __tmp66Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp64Prefix))
                        {
                            __out.Append(__tmp64Prefix);
                            __tmp65OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp66Line))
                        {
                            __out.Append(__tmp66Line);
                            __tmp65OutputWritten = true;
                        }
                        if (__tmp65OutputWritten)
                        {
                            __out.AppendLine(false); //292:39
                        }
                    }
                }
                if (__tmp65OutputWritten)
                {
                    __out.AppendLine(false); //292:39
                }
            }
            __out.Append("}"); //294:1
            __out.AppendLine(false); //294:2
            __out.AppendLine(true); //295:1
            return __out.ToString();
        }

        public string GenerateBuilderInterfaceImpl(MetaModel model, MetaClass cls) //298:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2OutputWritten = false;
            string __tmp3Line = "internal class "; //299:1
            if (!string.IsNullOrEmpty(__tmp3Line))
            {
                __out.Append(__tmp3Line);
                __tmp2OutputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(cls.CSharpImplName(ClassKind.Builder));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4Line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp4Line))
                    {
                        __out.Append(__tmp4Line);
                        __tmp2OutputWritten = true;
                    }
                    if (!__tmp4_last) __out.AppendLine(true);
                }
            }
            string __tmp5Line = " : global::MetaDslx.Core.Immutable.MutableSymbolBase, "; //299:55
            if (!string.IsNullOrEmpty(__tmp5Line))
            {
                __out.Append(__tmp5Line);
                __tmp2OutputWritten = true;
            }
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(cls.CSharpFullName(ClassKind.Builder));
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(!__tmp6_last)
                {
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp6Line))
                    {
                        __out.Append(__tmp6Line);
                        __tmp2OutputWritten = true;
                    }
                    if (__tmp2OutputWritten)
                    {
                        __out.AppendLine(false); //299:148
                    }
                }
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //299:148
            }
            __out.Append("{"); //300:1
            __out.AppendLine(false); //300:2
            var __loop25_results = 
                (from __loop25_var1 in __Enumerate((cls).GetEnumerator()) //301:11
                from prop in __Enumerate((__loop25_var1.GetAllProperties()).GetEnumerator()) //301:16
                where prop.Type is MetaCollectionType //301:40
                select new { __loop25_var1 = __loop25_var1, prop = prop}
                ).ToList(); //301:6
            for (int __loop25_iteration = 0; __loop25_iteration < __loop25_results.Count; ++__loop25_iteration)
            {
                var __tmp7 = __loop25_results[__loop25_iteration];
                var __loop25_var1 = __tmp7.__loop25_var1;
                var prop = __tmp7.prop;
                bool __tmp9OutputWritten = false;
                string __tmp8Prefix = "    "; //302:1
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(GenerateBuilderField(cls, prop));
                using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
                {
                    bool __tmp10_last = __tmp10Reader.EndOfStream;
                    while(!__tmp10_last)
                    {
                        string __tmp10Line = __tmp10Reader.ReadLine();
                        __tmp10_last = __tmp10Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp8Prefix))
                        {
                            __out.Append(__tmp8Prefix);
                            __tmp9OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp10Line))
                        {
                            __out.Append(__tmp10Line);
                            __tmp9OutputWritten = true;
                        }
                        if (__tmp9OutputWritten)
                        {
                            __out.AppendLine(false); //302:38
                        }
                    }
                }
                if (__tmp9OutputWritten)
                {
                    __out.AppendLine(false); //302:38
                }
            }
            __out.AppendLine(true); //304:1
            bool __tmp12OutputWritten = false;
            string __tmp13Line = "    internal "; //305:1
            if (!string.IsNullOrEmpty(__tmp13Line))
            {
                __out.Append(__tmp13Line);
                __tmp12OutputWritten = true;
            }
            StringBuilder __tmp14 = new StringBuilder();
            __tmp14.Append(cls.CSharpImplName(ClassKind.Builder));
            using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
            {
                bool __tmp14_last = __tmp14Reader.EndOfStream;
                while(!__tmp14_last)
                {
                    string __tmp14Line = __tmp14Reader.ReadLine();
                    __tmp14_last = __tmp14Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp14Line))
                    {
                        __out.Append(__tmp14Line);
                        __tmp12OutputWritten = true;
                    }
                    if (!__tmp14_last) __out.AppendLine(true);
                }
            }
            string __tmp15Line = "(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)"; //305:53
            if (!string.IsNullOrEmpty(__tmp15Line))
            {
                __out.Append(__tmp15Line);
                __tmp12OutputWritten = true;
            }
            if (__tmp12OutputWritten)
            {
                __out.AppendLine(false); //305:165
            }
            if (__tmp12OutputWritten)
            {
                __out.AppendLine(false); //305:165
            }
            __out.Append("		: base(id, model, creating)"); //306:1
            __out.AppendLine(false); //306:30
            __out.Append("    {"); //307:1
            __out.AppendLine(false); //307:6
            __out.Append("    }"); //308:1
            __out.AppendLine(false); //308:6
            __out.AppendLine(true); //309:1
            __out.Append("    internal protected override void MInit()"); //310:1
            __out.AppendLine(false); //310:45
            __out.Append("    {"); //311:1
            __out.AppendLine(false); //311:6
            var __loop26_results = 
                (from __loop26_var1 in __Enumerate((cls).GetEnumerator()) //312:9
                from sup in __Enumerate((__loop26_var1.GetAllSuperClasses(false)).GetEnumerator()) //312:14
                select new { __loop26_var1 = __loop26_var1, sup = sup}
                ).ToList(); //312:4
            for (int __loop26_iteration = 0; __loop26_iteration < __loop26_results.Count; ++__loop26_iteration)
            {
                var __tmp16 = __loop26_results[__loop26_iteration];
                var __loop26_var1 = __tmp16.__loop26_var1;
                var sup = __tmp16.sup;
                bool __tmp18OutputWritten = false;
                string __tmp17Prefix = "		"; //313:1
                StringBuilder __tmp19 = new StringBuilder();
                __tmp19.Append(sup.Model.Name);
                using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
                {
                    bool __tmp19_last = __tmp19Reader.EndOfStream;
                    while(!__tmp19_last)
                    {
                        string __tmp19Line = __tmp19Reader.ReadLine();
                        __tmp19_last = __tmp19Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp17Prefix))
                        {
                            __out.Append(__tmp17Prefix);
                            __tmp18OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp19Line))
                        {
                            __out.Append(__tmp19Line);
                            __tmp18OutputWritten = true;
                        }
                        if (!__tmp19_last) __out.AppendLine(true);
                    }
                }
                string __tmp20Line = "ImplementationProvider.Implementation."; //313:19
                if (!string.IsNullOrEmpty(__tmp20Line))
                {
                    __out.Append(__tmp20Line);
                    __tmp18OutputWritten = true;
                }
                StringBuilder __tmp21 = new StringBuilder();
                __tmp21.Append(sup.CSharpName());
                using(StreamReader __tmp21Reader = new StreamReader(this.__ToStream(__tmp21.ToString())))
                {
                    bool __tmp21_last = __tmp21Reader.EndOfStream;
                    while(!__tmp21_last)
                    {
                        string __tmp21Line = __tmp21Reader.ReadLine();
                        __tmp21_last = __tmp21Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp21Line))
                        {
                            __out.Append(__tmp21Line);
                            __tmp18OutputWritten = true;
                        }
                        if (!__tmp21_last) __out.AppendLine(true);
                    }
                }
                string __tmp22Line = "(this);"; //313:75
                if (!string.IsNullOrEmpty(__tmp22Line))
                {
                    __out.Append(__tmp22Line);
                    __tmp18OutputWritten = true;
                }
                if (__tmp18OutputWritten)
                {
                    __out.AppendLine(false); //313:82
                }
                if (__tmp18OutputWritten)
                {
                    __out.AppendLine(false); //313:82
                }
            }
            bool __tmp24OutputWritten = false;
            string __tmp23Prefix = "		"; //315:1
            StringBuilder __tmp25 = new StringBuilder();
            __tmp25.Append(model.Name);
            using(StreamReader __tmp25Reader = new StreamReader(this.__ToStream(__tmp25.ToString())))
            {
                bool __tmp25_last = __tmp25Reader.EndOfStream;
                while(!__tmp25_last)
                {
                    string __tmp25Line = __tmp25Reader.ReadLine();
                    __tmp25_last = __tmp25Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp23Prefix))
                    {
                        __out.Append(__tmp23Prefix);
                        __tmp24OutputWritten = true;
                    }
                    if (!string.IsNullOrEmpty(__tmp25Line))
                    {
                        __out.Append(__tmp25Line);
                        __tmp24OutputWritten = true;
                    }
                    if (!__tmp25_last) __out.AppendLine(true);
                }
            }
            string __tmp26Line = "ImplementationProvider.Implementation."; //315:15
            if (!string.IsNullOrEmpty(__tmp26Line))
            {
                __out.Append(__tmp26Line);
                __tmp24OutputWritten = true;
            }
            StringBuilder __tmp27 = new StringBuilder();
            __tmp27.Append(cls.CSharpName());
            using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
            {
                bool __tmp27_last = __tmp27Reader.EndOfStream;
                while(!__tmp27_last)
                {
                    string __tmp27Line = __tmp27Reader.ReadLine();
                    __tmp27_last = __tmp27Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp27Line))
                    {
                        __out.Append(__tmp27Line);
                        __tmp24OutputWritten = true;
                    }
                    if (!__tmp27_last) __out.AppendLine(true);
                }
            }
            string __tmp28Line = "(this);"; //315:71
            if (!string.IsNullOrEmpty(__tmp28Line))
            {
                __out.Append(__tmp28Line);
                __tmp24OutputWritten = true;
            }
            if (__tmp24OutputWritten)
            {
                __out.AppendLine(false); //315:78
            }
            if (__tmp24OutputWritten)
            {
                __out.AppendLine(false); //315:78
            }
            __out.Append("    }"); //316:1
            __out.AppendLine(false); //316:6
            __out.AppendLine(true); //317:1
            __out.Append("    public override MetaModel MMetaModel"); //318:1
            __out.AppendLine(false); //318:41
            __out.Append("    {"); //319:1
            __out.AppendLine(false); //319:6
            bool __tmp30OutputWritten = false;
            string __tmp31Line = "        get { return "; //320:1
            if (!string.IsNullOrEmpty(__tmp31Line))
            {
                __out.Append(__tmp31Line);
                __tmp30OutputWritten = true;
            }
            StringBuilder __tmp32 = new StringBuilder();
            __tmp32.Append(cls.Model.CSharpFullInstanceName(ClassKind.Immutable));
            using(StreamReader __tmp32Reader = new StreamReader(this.__ToStream(__tmp32.ToString())))
            {
                bool __tmp32_last = __tmp32Reader.EndOfStream;
                while(!__tmp32_last)
                {
                    string __tmp32Line = __tmp32Reader.ReadLine();
                    __tmp32_last = __tmp32Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp32Line))
                    {
                        __out.Append(__tmp32Line);
                        __tmp30OutputWritten = true;
                    }
                    if (!__tmp32_last) __out.AppendLine(true);
                }
            }
            string __tmp33Line = "; }"; //320:77
            if (!string.IsNullOrEmpty(__tmp33Line))
            {
                __out.Append(__tmp33Line);
                __tmp30OutputWritten = true;
            }
            if (__tmp30OutputWritten)
            {
                __out.AppendLine(false); //320:80
            }
            if (__tmp30OutputWritten)
            {
                __out.AppendLine(false); //320:80
            }
            __out.Append("    }"); //321:1
            __out.AppendLine(false); //321:6
            __out.AppendLine(true); //322:1
            __out.Append("    public override MetaClass MMetaClass"); //323:1
            __out.AppendLine(false); //323:41
            __out.Append("    {"); //324:1
            __out.AppendLine(false); //324:6
            bool __tmp35OutputWritten = false;
            string __tmp36Line = "        get { return "; //325:1
            if (!string.IsNullOrEmpty(__tmp36Line))
            {
                __out.Append(__tmp36Line);
                __tmp35OutputWritten = true;
            }
            StringBuilder __tmp37 = new StringBuilder();
            __tmp37.Append(cls.CSharpFullInstanceName(ClassKind.Immutable));
            using(StreamReader __tmp37Reader = new StreamReader(this.__ToStream(__tmp37.ToString())))
            {
                bool __tmp37_last = __tmp37Reader.EndOfStream;
                while(!__tmp37_last)
                {
                    string __tmp37Line = __tmp37Reader.ReadLine();
                    __tmp37_last = __tmp37Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp37Line))
                    {
                        __out.Append(__tmp37Line);
                        __tmp35OutputWritten = true;
                    }
                    if (!__tmp37_last) __out.AppendLine(true);
                }
            }
            string __tmp38Line = "; }"; //325:71
            if (!string.IsNullOrEmpty(__tmp38Line))
            {
                __out.Append(__tmp38Line);
                __tmp35OutputWritten = true;
            }
            if (__tmp35OutputWritten)
            {
                __out.AppendLine(false); //325:74
            }
            if (__tmp35OutputWritten)
            {
                __out.AppendLine(false); //325:74
            }
            __out.Append("    }"); //326:1
            __out.AppendLine(false); //326:6
            __out.AppendLine(true); //327:1
            bool __tmp40OutputWritten = false;
            string __tmp41Line = "    public new "; //328:1
            if (!string.IsNullOrEmpty(__tmp41Line))
            {
                __out.Append(__tmp41Line);
                __tmp40OutputWritten = true;
            }
            StringBuilder __tmp42 = new StringBuilder();
            __tmp42.Append(cls.CSharpFullName(ClassKind.Immutable));
            using(StreamReader __tmp42Reader = new StreamReader(this.__ToStream(__tmp42.ToString())))
            {
                bool __tmp42_last = __tmp42Reader.EndOfStream;
                while(!__tmp42_last)
                {
                    string __tmp42Line = __tmp42Reader.ReadLine();
                    __tmp42_last = __tmp42Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp42Line))
                    {
                        __out.Append(__tmp42Line);
                        __tmp40OutputWritten = true;
                    }
                    if (!__tmp42_last) __out.AppendLine(true);
                }
            }
            string __tmp43Line = " ToImmutable()"; //328:57
            if (!string.IsNullOrEmpty(__tmp43Line))
            {
                __out.Append(__tmp43Line);
                __tmp40OutputWritten = true;
            }
            if (__tmp40OutputWritten)
            {
                __out.AppendLine(false); //328:71
            }
            if (__tmp40OutputWritten)
            {
                __out.AppendLine(false); //328:71
            }
            __out.Append("	{"); //329:1
            __out.AppendLine(false); //329:3
            bool __tmp45OutputWritten = false;
            string __tmp46Line = "		return ("; //330:1
            if (!string.IsNullOrEmpty(__tmp46Line))
            {
                __out.Append(__tmp46Line);
                __tmp45OutputWritten = true;
            }
            StringBuilder __tmp47 = new StringBuilder();
            __tmp47.Append(cls.CSharpFullName(ClassKind.Immutable));
            using(StreamReader __tmp47Reader = new StreamReader(this.__ToStream(__tmp47.ToString())))
            {
                bool __tmp47_last = __tmp47Reader.EndOfStream;
                while(!__tmp47_last)
                {
                    string __tmp47Line = __tmp47Reader.ReadLine();
                    __tmp47_last = __tmp47Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp47Line))
                    {
                        __out.Append(__tmp47Line);
                        __tmp45OutputWritten = true;
                    }
                    if (!__tmp47_last) __out.AppendLine(true);
                }
            }
            string __tmp48Line = ")base.ToImmutable();"; //330:52
            if (!string.IsNullOrEmpty(__tmp48Line))
            {
                __out.Append(__tmp48Line);
                __tmp45OutputWritten = true;
            }
            if (__tmp45OutputWritten)
            {
                __out.AppendLine(false); //330:72
            }
            if (__tmp45OutputWritten)
            {
                __out.AppendLine(false); //330:72
            }
            __out.Append("	}"); //331:1
            __out.AppendLine(false); //331:3
            __out.AppendLine(true); //332:1
            bool __tmp50OutputWritten = false;
            string __tmp51Line = "    public new "; //333:1
            if (!string.IsNullOrEmpty(__tmp51Line))
            {
                __out.Append(__tmp51Line);
                __tmp50OutputWritten = true;
            }
            StringBuilder __tmp52 = new StringBuilder();
            __tmp52.Append(cls.CSharpFullName(ClassKind.Immutable));
            using(StreamReader __tmp52Reader = new StreamReader(this.__ToStream(__tmp52.ToString())))
            {
                bool __tmp52_last = __tmp52Reader.EndOfStream;
                while(!__tmp52_last)
                {
                    string __tmp52Line = __tmp52Reader.ReadLine();
                    __tmp52_last = __tmp52Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp52Line))
                    {
                        __out.Append(__tmp52Line);
                        __tmp50OutputWritten = true;
                    }
                    if (!__tmp52_last) __out.AppendLine(true);
                }
            }
            string __tmp53Line = " ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)"; //333:57
            if (!string.IsNullOrEmpty(__tmp53Line))
            {
                __out.Append(__tmp53Line);
                __tmp50OutputWritten = true;
            }
            if (__tmp50OutputWritten)
            {
                __out.AppendLine(false); //333:123
            }
            if (__tmp50OutputWritten)
            {
                __out.AppendLine(false); //333:123
            }
            __out.Append("	{"); //334:1
            __out.AppendLine(false); //334:3
            bool __tmp55OutputWritten = false;
            string __tmp56Line = "		return ("; //335:1
            if (!string.IsNullOrEmpty(__tmp56Line))
            {
                __out.Append(__tmp56Line);
                __tmp55OutputWritten = true;
            }
            StringBuilder __tmp57 = new StringBuilder();
            __tmp57.Append(cls.CSharpFullName(ClassKind.Immutable));
            using(StreamReader __tmp57Reader = new StreamReader(this.__ToStream(__tmp57.ToString())))
            {
                bool __tmp57_last = __tmp57Reader.EndOfStream;
                while(!__tmp57_last)
                {
                    string __tmp57Line = __tmp57Reader.ReadLine();
                    __tmp57_last = __tmp57Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp57Line))
                    {
                        __out.Append(__tmp57Line);
                        __tmp55OutputWritten = true;
                    }
                    if (!__tmp57_last) __out.AppendLine(true);
                }
            }
            string __tmp58Line = ")base.ToImmutable(model);"; //335:52
            if (!string.IsNullOrEmpty(__tmp58Line))
            {
                __out.Append(__tmp58Line);
                __tmp55OutputWritten = true;
            }
            if (__tmp55OutputWritten)
            {
                __out.AppendLine(false); //335:77
            }
            if (__tmp55OutputWritten)
            {
                __out.AppendLine(false); //335:77
            }
            __out.Append("	}"); //336:1
            __out.AppendLine(false); //336:3
            var __loop27_results = 
                (from __loop27_var1 in __Enumerate((cls).GetEnumerator()) //337:8
                from sup in __Enumerate((__loop27_var1.GetAllSuperClasses()).GetEnumerator()) //337:13
                select new { __loop27_var1 = __loop27_var1, sup = sup}
                ).ToList(); //337:3
            for (int __loop27_iteration = 0; __loop27_iteration < __loop27_results.Count; ++__loop27_iteration)
            {
                var __tmp59 = __loop27_results[__loop27_iteration];
                var __loop27_var1 = __tmp59.__loop27_var1;
                var sup = __tmp59.sup;
                __out.AppendLine(true); //338:1
                bool __tmp61OutputWritten = false;
                string __tmp60Prefix = "    "; //339:1
                StringBuilder __tmp62 = new StringBuilder();
                __tmp62.Append(sup.CSharpFullName(ClassKind.Immutable));
                using(StreamReader __tmp62Reader = new StreamReader(this.__ToStream(__tmp62.ToString())))
                {
                    bool __tmp62_last = __tmp62Reader.EndOfStream;
                    while(!__tmp62_last)
                    {
                        string __tmp62Line = __tmp62Reader.ReadLine();
                        __tmp62_last = __tmp62Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp60Prefix))
                        {
                            __out.Append(__tmp60Prefix);
                            __tmp61OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp62Line))
                        {
                            __out.Append(__tmp62Line);
                            __tmp61OutputWritten = true;
                        }
                        if (!__tmp62_last) __out.AppendLine(true);
                    }
                }
                string __tmp63Line = " "; //339:46
                if (!string.IsNullOrEmpty(__tmp63Line))
                {
                    __out.Append(__tmp63Line);
                    __tmp61OutputWritten = true;
                }
                StringBuilder __tmp64 = new StringBuilder();
                __tmp64.Append(sup.CSharpFullName(ClassKind.Builder));
                using(StreamReader __tmp64Reader = new StreamReader(this.__ToStream(__tmp64.ToString())))
                {
                    bool __tmp64_last = __tmp64Reader.EndOfStream;
                    while(!__tmp64_last)
                    {
                        string __tmp64Line = __tmp64Reader.ReadLine();
                        __tmp64_last = __tmp64Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp64Line))
                        {
                            __out.Append(__tmp64Line);
                            __tmp61OutputWritten = true;
                        }
                        if (!__tmp64_last) __out.AppendLine(true);
                    }
                }
                string __tmp65Line = ".ToImmutable()"; //339:86
                if (!string.IsNullOrEmpty(__tmp65Line))
                {
                    __out.Append(__tmp65Line);
                    __tmp61OutputWritten = true;
                }
                if (__tmp61OutputWritten)
                {
                    __out.AppendLine(false); //339:100
                }
                if (__tmp61OutputWritten)
                {
                    __out.AppendLine(false); //339:100
                }
                __out.Append("	{"); //340:1
                __out.AppendLine(false); //340:3
                __out.Append("		return this.ToImmutable();"); //341:1
                __out.AppendLine(false); //341:29
                __out.Append("	}"); //342:1
                __out.AppendLine(false); //342:3
                __out.AppendLine(true); //343:1
                bool __tmp67OutputWritten = false;
                string __tmp66Prefix = "    "; //344:1
                StringBuilder __tmp68 = new StringBuilder();
                __tmp68.Append(sup.CSharpFullName(ClassKind.Immutable));
                using(StreamReader __tmp68Reader = new StreamReader(this.__ToStream(__tmp68.ToString())))
                {
                    bool __tmp68_last = __tmp68Reader.EndOfStream;
                    while(!__tmp68_last)
                    {
                        string __tmp68Line = __tmp68Reader.ReadLine();
                        __tmp68_last = __tmp68Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp66Prefix))
                        {
                            __out.Append(__tmp66Prefix);
                            __tmp67OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp68Line))
                        {
                            __out.Append(__tmp68Line);
                            __tmp67OutputWritten = true;
                        }
                        if (!__tmp68_last) __out.AppendLine(true);
                    }
                }
                string __tmp69Line = " "; //344:46
                if (!string.IsNullOrEmpty(__tmp69Line))
                {
                    __out.Append(__tmp69Line);
                    __tmp67OutputWritten = true;
                }
                StringBuilder __tmp70 = new StringBuilder();
                __tmp70.Append(sup.CSharpFullName(ClassKind.Builder));
                using(StreamReader __tmp70Reader = new StreamReader(this.__ToStream(__tmp70.ToString())))
                {
                    bool __tmp70_last = __tmp70Reader.EndOfStream;
                    while(!__tmp70_last)
                    {
                        string __tmp70Line = __tmp70Reader.ReadLine();
                        __tmp70_last = __tmp70Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp70Line))
                        {
                            __out.Append(__tmp70Line);
                            __tmp67OutputWritten = true;
                        }
                        if (!__tmp70_last) __out.AppendLine(true);
                    }
                }
                string __tmp71Line = ".ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)"; //344:86
                if (!string.IsNullOrEmpty(__tmp71Line))
                {
                    __out.Append(__tmp71Line);
                    __tmp67OutputWritten = true;
                }
                if (__tmp67OutputWritten)
                {
                    __out.AppendLine(false); //344:152
                }
                if (__tmp67OutputWritten)
                {
                    __out.AppendLine(false); //344:152
                }
                __out.Append("	{"); //345:1
                __out.AppendLine(false); //345:3
                __out.Append("		return this.ToImmutable(model);"); //346:1
                __out.AppendLine(false); //346:34
                __out.Append("	}"); //347:1
                __out.AppendLine(false); //347:3
            }
            var __loop28_results = 
                (from __loop28_var1 in __Enumerate((cls).GetEnumerator()) //349:11
                from prop in __Enumerate((__loop28_var1.GetAllProperties()).GetEnumerator()) //349:16
                select new { __loop28_var1 = __loop28_var1, prop = prop}
                ).ToList(); //349:6
            for (int __loop28_iteration = 0; __loop28_iteration < __loop28_results.Count; ++__loop28_iteration)
            {
                var __tmp72 = __loop28_results[__loop28_iteration];
                var __loop28_var1 = __tmp72.__loop28_var1;
                var prop = __tmp72.prop;
                __out.AppendLine(true); //350:1
                bool __tmp74OutputWritten = false;
                string __tmp73Prefix = "    "; //351:1
                StringBuilder __tmp75 = new StringBuilder();
                __tmp75.Append(GenerateBuilderPropertyImpl(model, cls, prop));
                using(StreamReader __tmp75Reader = new StreamReader(this.__ToStream(__tmp75.ToString())))
                {
                    bool __tmp75_last = __tmp75Reader.EndOfStream;
                    while(!__tmp75_last)
                    {
                        string __tmp75Line = __tmp75Reader.ReadLine();
                        __tmp75_last = __tmp75Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp73Prefix))
                        {
                            __out.Append(__tmp73Prefix);
                            __tmp74OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp75Line))
                        {
                            __out.Append(__tmp75Line);
                            __tmp74OutputWritten = true;
                        }
                        if (__tmp74OutputWritten)
                        {
                            __out.AppendLine(false); //351:52
                        }
                    }
                }
                if (__tmp74OutputWritten)
                {
                    __out.AppendLine(false); //351:52
                }
            }
            __out.Append("}"); //353:1
            __out.AppendLine(false); //353:2
            __out.AppendLine(true); //354:1
            return __out.ToString();
        }

        public string GeneratePropertyDeclaration(MetaModel model, MetaClass cls, MetaProperty prop) //357:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class == cls) //358:2
            {
                bool __tmp2OutputWritten = false;
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(GenerateAnnotations(prop));
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_last = __tmp3Reader.EndOfStream;
                    while(!__tmp3_last)
                    {
                        string __tmp3Line = __tmp3Reader.ReadLine();
                        __tmp3_last = __tmp3Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp3Line))
                        {
                            __out.Append(__tmp3Line);
                            __tmp2OutputWritten = true;
                        }
                        if (__tmp2OutputWritten)
                        {
                            __out.AppendLine(false); //359:28
                        }
                    }
                }
                if (__tmp2OutputWritten)
                {
                    __out.AppendLine(false); //359:28
                }
                if (prop.Kind == MetaPropertyKind.Containment) //360:2
                {
                    bool __tmp5OutputWritten = false;
                    StringBuilder __tmp6 = new StringBuilder();
                    __tmp6.Append("[ContainmentAttribute]");
                    using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
                    {
                        bool __tmp6_last = __tmp6Reader.EndOfStream;
                        while(!__tmp6_last)
                        {
                            string __tmp6Line = __tmp6Reader.ReadLine();
                            __tmp6_last = __tmp6Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp6Line))
                            {
                                __out.Append(__tmp6Line);
                                __tmp5OutputWritten = true;
                            }
                            if (__tmp5OutputWritten)
                            {
                                __out.AppendLine(false); //361:27
                            }
                        }
                    }
                    if (__tmp5OutputWritten)
                    {
                        __out.AppendLine(false); //361:27
                    }
                }
                if (prop.Kind != MetaPropertyKind.Normal && prop.Kind != MetaPropertyKind.Containment) //363:2
                {
                    bool __tmp8OutputWritten = false;
                    StringBuilder __tmp9 = new StringBuilder();
                    __tmp9.Append("[ReadonlyAttribute]");
                    using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                    {
                        bool __tmp9_last = __tmp9Reader.EndOfStream;
                        while(!__tmp9_last)
                        {
                            string __tmp9Line = __tmp9Reader.ReadLine();
                            __tmp9_last = __tmp9Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp9Line))
                            {
                                __out.Append(__tmp9Line);
                                __tmp8OutputWritten = true;
                            }
                            if (__tmp8OutputWritten)
                            {
                                __out.AppendLine(false); //364:24
                            }
                        }
                    }
                    if (__tmp8OutputWritten)
                    {
                        __out.AppendLine(false); //364:24
                    }
                }
                var __loop29_results = 
                    (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //366:7
                    select new { p = p}
                    ).ToList(); //366:2
                for (int __loop29_iteration = 0; __loop29_iteration < __loop29_results.Count; ++__loop29_iteration)
                {
                    var __tmp10 = __loop29_results[__loop29_iteration];
                    var p = __tmp10.p;
                    bool __tmp12OutputWritten = false;
                    StringBuilder __tmp13 = new StringBuilder();
                    __tmp13.Append("[OppositeAttribute(typeof(");
                    using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                    {
                        bool __tmp13_last = __tmp13Reader.EndOfStream;
                        while(!__tmp13_last)
                        {
                            string __tmp13Line = __tmp13Reader.ReadLine();
                            __tmp13_last = __tmp13Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp13Line))
                            {
                                __out.Append(__tmp13Line);
                                __tmp12OutputWritten = true;
                            }
                            if (!__tmp13_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp14 = new StringBuilder();
                    __tmp14.Append(p.Class.CSharpFullDescriptorName(ClassKind.Immutable));
                    using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
                    {
                        bool __tmp14_last = __tmp14Reader.EndOfStream;
                        while(!__tmp14_last)
                        {
                            string __tmp14Line = __tmp14Reader.ReadLine();
                            __tmp14_last = __tmp14Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp14Line))
                            {
                                __out.Append(__tmp14Line);
                                __tmp12OutputWritten = true;
                            }
                            if (!__tmp14_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp15 = new StringBuilder();
                    __tmp15.Append("), \"");
                    using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
                    {
                        bool __tmp15_last = __tmp15Reader.EndOfStream;
                        while(!__tmp15_last)
                        {
                            string __tmp15Line = __tmp15Reader.ReadLine();
                            __tmp15_last = __tmp15Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp15Line))
                            {
                                __out.Append(__tmp15Line);
                                __tmp12OutputWritten = true;
                            }
                            if (!__tmp15_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp16 = new StringBuilder();
                    __tmp16.Append(p.Name);
                    using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
                    {
                        bool __tmp16_last = __tmp16Reader.EndOfStream;
                        while(!__tmp16_last)
                        {
                            string __tmp16Line = __tmp16Reader.ReadLine();
                            __tmp16_last = __tmp16Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp16Line))
                            {
                                __out.Append(__tmp16Line);
                                __tmp12OutputWritten = true;
                            }
                            if (!__tmp16_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp17 = new StringBuilder();
                    __tmp17.Append("\")]");
                    using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
                    {
                        bool __tmp17_last = __tmp17Reader.EndOfStream;
                        while(!__tmp17_last)
                        {
                            string __tmp17Line = __tmp17Reader.ReadLine();
                            __tmp17_last = __tmp17Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp17Line))
                            {
                                __out.Append(__tmp17Line);
                                __tmp12OutputWritten = true;
                            }
                            if (__tmp12OutputWritten)
                            {
                                __out.AppendLine(false); //367:111
                            }
                        }
                    }
                    if (__tmp12OutputWritten)
                    {
                        __out.AppendLine(false); //367:111
                    }
                }
                var __loop30_results = 
                    (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //369:7
                    select new { p = p}
                    ).ToList(); //369:2
                for (int __loop30_iteration = 0; __loop30_iteration < __loop30_results.Count; ++__loop30_iteration)
                {
                    var __tmp18 = __loop30_results[__loop30_iteration];
                    var p = __tmp18.p;
                    if (cls.GetAllSuperClasses(true).Contains(p.Class)) //370:3
                    {
                        bool __tmp20OutputWritten = false;
                        StringBuilder __tmp21 = new StringBuilder();
                        __tmp21.Append("[SubsetsAttribute(typeof(");
                        using(StreamReader __tmp21Reader = new StreamReader(this.__ToStream(__tmp21.ToString())))
                        {
                            bool __tmp21_last = __tmp21Reader.EndOfStream;
                            while(!__tmp21_last)
                            {
                                string __tmp21Line = __tmp21Reader.ReadLine();
                                __tmp21_last = __tmp21Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp21Line))
                                {
                                    __out.Append(__tmp21Line);
                                    __tmp20OutputWritten = true;
                                }
                                if (!__tmp21_last) __out.AppendLine(true);
                            }
                        }
                        StringBuilder __tmp22 = new StringBuilder();
                        __tmp22.Append(p.Class.CSharpFullDescriptorName(ClassKind.Immutable));
                        using(StreamReader __tmp22Reader = new StreamReader(this.__ToStream(__tmp22.ToString())))
                        {
                            bool __tmp22_last = __tmp22Reader.EndOfStream;
                            while(!__tmp22_last)
                            {
                                string __tmp22Line = __tmp22Reader.ReadLine();
                                __tmp22_last = __tmp22Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp22Line))
                                {
                                    __out.Append(__tmp22Line);
                                    __tmp20OutputWritten = true;
                                }
                                if (!__tmp22_last) __out.AppendLine(true);
                            }
                        }
                        StringBuilder __tmp23 = new StringBuilder();
                        __tmp23.Append("), \"");
                        using(StreamReader __tmp23Reader = new StreamReader(this.__ToStream(__tmp23.ToString())))
                        {
                            bool __tmp23_last = __tmp23Reader.EndOfStream;
                            while(!__tmp23_last)
                            {
                                string __tmp23Line = __tmp23Reader.ReadLine();
                                __tmp23_last = __tmp23Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp23Line))
                                {
                                    __out.Append(__tmp23Line);
                                    __tmp20OutputWritten = true;
                                }
                                if (!__tmp23_last) __out.AppendLine(true);
                            }
                        }
                        StringBuilder __tmp24 = new StringBuilder();
                        __tmp24.Append(p.Name);
                        using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
                        {
                            bool __tmp24_last = __tmp24Reader.EndOfStream;
                            while(!__tmp24_last)
                            {
                                string __tmp24Line = __tmp24Reader.ReadLine();
                                __tmp24_last = __tmp24Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp24Line))
                                {
                                    __out.Append(__tmp24Line);
                                    __tmp20OutputWritten = true;
                                }
                                if (!__tmp24_last) __out.AppendLine(true);
                            }
                        }
                        StringBuilder __tmp25 = new StringBuilder();
                        __tmp25.Append("\")]");
                        using(StreamReader __tmp25Reader = new StreamReader(this.__ToStream(__tmp25.ToString())))
                        {
                            bool __tmp25_last = __tmp25Reader.EndOfStream;
                            while(!__tmp25_last)
                            {
                                string __tmp25Line = __tmp25Reader.ReadLine();
                                __tmp25_last = __tmp25Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp25Line))
                                {
                                    __out.Append(__tmp25Line);
                                    __tmp20OutputWritten = true;
                                }
                                if (__tmp20OutputWritten)
                                {
                                    __out.AppendLine(false); //371:110
                                }
                            }
                        }
                        if (__tmp20OutputWritten)
                        {
                            __out.AppendLine(false); //371:110
                        }
                    }
                    else //372:3
                    {
                        bool __tmp27OutputWritten = false;
                        string __tmp28Line = "// ERROR: subsetted property '"; //373:1
                        if (!string.IsNullOrEmpty(__tmp28Line))
                        {
                            __out.Append(__tmp28Line);
                            __tmp27OutputWritten = true;
                        }
                        StringBuilder __tmp29 = new StringBuilder();
                        __tmp29.Append(p.CSharpFullDescriptorName(ClassKind.Immutable));
                        using(StreamReader __tmp29Reader = new StreamReader(this.__ToStream(__tmp29.ToString())))
                        {
                            bool __tmp29_last = __tmp29Reader.EndOfStream;
                            while(!__tmp29_last)
                            {
                                string __tmp29Line = __tmp29Reader.ReadLine();
                                __tmp29_last = __tmp29Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp29Line))
                                {
                                    __out.Append(__tmp29Line);
                                    __tmp27OutputWritten = true;
                                }
                                if (!__tmp29_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp30Line = "' must be a property of an ancestor class"; //373:80
                        if (!string.IsNullOrEmpty(__tmp30Line))
                        {
                            __out.Append(__tmp30Line);
                            __tmp27OutputWritten = true;
                        }
                        if (__tmp27OutputWritten)
                        {
                            __out.AppendLine(false); //373:121
                        }
                        if (__tmp27OutputWritten)
                        {
                            __out.AppendLine(false); //373:121
                        }
                    }
                }
                var __loop31_results = 
                    (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //376:7
                    select new { p = p}
                    ).ToList(); //376:2
                for (int __loop31_iteration = 0; __loop31_iteration < __loop31_results.Count; ++__loop31_iteration)
                {
                    var __tmp31 = __loop31_results[__loop31_iteration];
                    var p = __tmp31.p;
                    if (cls.GetAllSuperClasses(true).Contains(p.Class)) //377:3
                    {
                        bool __tmp33OutputWritten = false;
                        StringBuilder __tmp34 = new StringBuilder();
                        __tmp34.Append("[RedefinesAttribute(typeof(");
                        using(StreamReader __tmp34Reader = new StreamReader(this.__ToStream(__tmp34.ToString())))
                        {
                            bool __tmp34_last = __tmp34Reader.EndOfStream;
                            while(!__tmp34_last)
                            {
                                string __tmp34Line = __tmp34Reader.ReadLine();
                                __tmp34_last = __tmp34Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp34Line))
                                {
                                    __out.Append(__tmp34Line);
                                    __tmp33OutputWritten = true;
                                }
                                if (!__tmp34_last) __out.AppendLine(true);
                            }
                        }
                        StringBuilder __tmp35 = new StringBuilder();
                        __tmp35.Append(p.Class.CSharpFullDescriptorName(ClassKind.Immutable));
                        using(StreamReader __tmp35Reader = new StreamReader(this.__ToStream(__tmp35.ToString())))
                        {
                            bool __tmp35_last = __tmp35Reader.EndOfStream;
                            while(!__tmp35_last)
                            {
                                string __tmp35Line = __tmp35Reader.ReadLine();
                                __tmp35_last = __tmp35Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp35Line))
                                {
                                    __out.Append(__tmp35Line);
                                    __tmp33OutputWritten = true;
                                }
                                if (!__tmp35_last) __out.AppendLine(true);
                            }
                        }
                        StringBuilder __tmp36 = new StringBuilder();
                        __tmp36.Append("), \"");
                        using(StreamReader __tmp36Reader = new StreamReader(this.__ToStream(__tmp36.ToString())))
                        {
                            bool __tmp36_last = __tmp36Reader.EndOfStream;
                            while(!__tmp36_last)
                            {
                                string __tmp36Line = __tmp36Reader.ReadLine();
                                __tmp36_last = __tmp36Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp36Line))
                                {
                                    __out.Append(__tmp36Line);
                                    __tmp33OutputWritten = true;
                                }
                                if (!__tmp36_last) __out.AppendLine(true);
                            }
                        }
                        StringBuilder __tmp37 = new StringBuilder();
                        __tmp37.Append(p.Name);
                        using(StreamReader __tmp37Reader = new StreamReader(this.__ToStream(__tmp37.ToString())))
                        {
                            bool __tmp37_last = __tmp37Reader.EndOfStream;
                            while(!__tmp37_last)
                            {
                                string __tmp37Line = __tmp37Reader.ReadLine();
                                __tmp37_last = __tmp37Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp37Line))
                                {
                                    __out.Append(__tmp37Line);
                                    __tmp33OutputWritten = true;
                                }
                                if (!__tmp37_last) __out.AppendLine(true);
                            }
                        }
                        StringBuilder __tmp38 = new StringBuilder();
                        __tmp38.Append("\")]");
                        using(StreamReader __tmp38Reader = new StreamReader(this.__ToStream(__tmp38.ToString())))
                        {
                            bool __tmp38_last = __tmp38Reader.EndOfStream;
                            while(!__tmp38_last)
                            {
                                string __tmp38Line = __tmp38Reader.ReadLine();
                                __tmp38_last = __tmp38Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp38Line))
                                {
                                    __out.Append(__tmp38Line);
                                    __tmp33OutputWritten = true;
                                }
                                if (__tmp33OutputWritten)
                                {
                                    __out.AppendLine(false); //378:112
                                }
                            }
                        }
                        if (__tmp33OutputWritten)
                        {
                            __out.AppendLine(false); //378:112
                        }
                    }
                    else //379:3
                    {
                        bool __tmp40OutputWritten = false;
                        string __tmp41Line = "// ERROR: redefined property '"; //380:1
                        if (!string.IsNullOrEmpty(__tmp41Line))
                        {
                            __out.Append(__tmp41Line);
                            __tmp40OutputWritten = true;
                        }
                        StringBuilder __tmp42 = new StringBuilder();
                        __tmp42.Append(p.CSharpFullDescriptorName(ClassKind.Immutable));
                        using(StreamReader __tmp42Reader = new StreamReader(this.__ToStream(__tmp42.ToString())))
                        {
                            bool __tmp42_last = __tmp42Reader.EndOfStream;
                            while(!__tmp42_last)
                            {
                                string __tmp42Line = __tmp42Reader.ReadLine();
                                __tmp42_last = __tmp42Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp42Line))
                                {
                                    __out.Append(__tmp42Line);
                                    __tmp40OutputWritten = true;
                                }
                                if (!__tmp42_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp43Line = "' must be a property of an ancestor class"; //380:80
                        if (!string.IsNullOrEmpty(__tmp43Line))
                        {
                            __out.Append(__tmp43Line);
                            __tmp40OutputWritten = true;
                        }
                        if (__tmp40OutputWritten)
                        {
                            __out.AppendLine(false); //380:121
                        }
                        if (__tmp40OutputWritten)
                        {
                            __out.AppendLine(false); //380:121
                        }
                    }
                }
                if (prop.Type is MetaCollectionType) //383:2
                {
                    MetaCollectionType collType = (MetaCollectionType)prop.Type; //384:3
                    bool __tmp45OutputWritten = false;
                    string __tmp46Line = "public static readonly global::MetaDslx.Core.Immutable.ModelProperty "; //385:1
                    if (!string.IsNullOrEmpty(__tmp46Line))
                    {
                        __out.Append(__tmp46Line);
                        __tmp45OutputWritten = true;
                    }
                    StringBuilder __tmp47 = new StringBuilder();
                    __tmp47.Append(prop.Name);
                    using(StreamReader __tmp47Reader = new StreamReader(this.__ToStream(__tmp47.ToString())))
                    {
                        bool __tmp47_last = __tmp47Reader.EndOfStream;
                        while(!__tmp47_last)
                        {
                            string __tmp47Line = __tmp47Reader.ReadLine();
                            __tmp47_last = __tmp47Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp47Line))
                            {
                                __out.Append(__tmp47Line);
                                __tmp45OutputWritten = true;
                            }
                            if (!__tmp47_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp48Line = "Property ="; //385:81
                    if (!string.IsNullOrEmpty(__tmp48Line))
                    {
                        __out.Append(__tmp48Line);
                        __tmp45OutputWritten = true;
                    }
                    if (__tmp45OutputWritten)
                    {
                        __out.AppendLine(false); //385:91
                    }
                    if (__tmp45OutputWritten)
                    {
                        __out.AppendLine(false); //385:91
                    }
                    bool __tmp50OutputWritten = false;
                    string __tmp51Line = "    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof("; //386:1
                    if (!string.IsNullOrEmpty(__tmp51Line))
                    {
                        __out.Append(__tmp51Line);
                        __tmp50OutputWritten = true;
                    }
                    StringBuilder __tmp52 = new StringBuilder();
                    __tmp52.Append(prop.Class.Model.CSharpDescriptorName());
                    using(StreamReader __tmp52Reader = new StreamReader(this.__ToStream(__tmp52.ToString())))
                    {
                        bool __tmp52_last = __tmp52Reader.EndOfStream;
                        while(!__tmp52_last)
                        {
                            string __tmp52Line = __tmp52Reader.ReadLine();
                            __tmp52_last = __tmp52Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp52Line))
                            {
                                __out.Append(__tmp52Line);
                                __tmp50OutputWritten = true;
                            }
                            if (!__tmp52_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp53Line = "."; //386:108
                    if (!string.IsNullOrEmpty(__tmp53Line))
                    {
                        __out.Append(__tmp53Line);
                        __tmp50OutputWritten = true;
                    }
                    StringBuilder __tmp54 = new StringBuilder();
                    __tmp54.Append(prop.Class.CSharpName());
                    using(StreamReader __tmp54Reader = new StreamReader(this.__ToStream(__tmp54.ToString())))
                    {
                        bool __tmp54_last = __tmp54Reader.EndOfStream;
                        while(!__tmp54_last)
                        {
                            string __tmp54Line = __tmp54Reader.ReadLine();
                            __tmp54_last = __tmp54Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp54Line))
                            {
                                __out.Append(__tmp54Line);
                                __tmp50OutputWritten = true;
                            }
                            if (!__tmp54_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp55Line = "), \""; //386:134
                    if (!string.IsNullOrEmpty(__tmp55Line))
                    {
                        __out.Append(__tmp55Line);
                        __tmp50OutputWritten = true;
                    }
                    StringBuilder __tmp56 = new StringBuilder();
                    __tmp56.Append(prop.Name);
                    using(StreamReader __tmp56Reader = new StreamReader(this.__ToStream(__tmp56.ToString())))
                    {
                        bool __tmp56_last = __tmp56Reader.EndOfStream;
                        while(!__tmp56_last)
                        {
                            string __tmp56Line = __tmp56Reader.ReadLine();
                            __tmp56_last = __tmp56Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp56Line))
                            {
                                __out.Append(__tmp56Line);
                                __tmp50OutputWritten = true;
                            }
                            if (!__tmp56_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp57Line = "\","; //386:149
                    if (!string.IsNullOrEmpty(__tmp57Line))
                    {
                        __out.Append(__tmp57Line);
                        __tmp50OutputWritten = true;
                    }
                    if (__tmp50OutputWritten)
                    {
                        __out.AppendLine(false); //386:151
                    }
                    if (__tmp50OutputWritten)
                    {
                        __out.AppendLine(false); //386:151
                    }
                    bool __tmp59OutputWritten = false;
                    string __tmp60Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //387:1
                    if (!string.IsNullOrEmpty(__tmp60Line))
                    {
                        __out.Append(__tmp60Line);
                        __tmp59OutputWritten = true;
                    }
                    StringBuilder __tmp61 = new StringBuilder();
                    __tmp61.Append(collType.InnerType.CSharpFullPublicName(ClassKind.Immutable));
                    using(StreamReader __tmp61Reader = new StreamReader(this.__ToStream(__tmp61.ToString())))
                    {
                        bool __tmp61_last = __tmp61Reader.EndOfStream;
                        while(!__tmp61_last)
                        {
                            string __tmp61Line = __tmp61Reader.ReadLine();
                            __tmp61_last = __tmp61Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp61Line))
                            {
                                __out.Append(__tmp61Line);
                                __tmp59OutputWritten = true;
                            }
                            if (!__tmp61_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp62Line = "), typeof("; //387:136
                    if (!string.IsNullOrEmpty(__tmp62Line))
                    {
                        __out.Append(__tmp62Line);
                        __tmp59OutputWritten = true;
                    }
                    StringBuilder __tmp63 = new StringBuilder();
                    __tmp63.Append(prop.Type.CSharpFullPublicName(ClassKind.Immutable));
                    using(StreamReader __tmp63Reader = new StreamReader(this.__ToStream(__tmp63.ToString())))
                    {
                        bool __tmp63_last = __tmp63Reader.EndOfStream;
                        while(!__tmp63_last)
                        {
                            string __tmp63Line = __tmp63Reader.ReadLine();
                            __tmp63_last = __tmp63Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp63Line))
                            {
                                __out.Append(__tmp63Line);
                                __tmp59OutputWritten = true;
                            }
                            if (!__tmp63_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp64Line = ")),"; //387:199
                    if (!string.IsNullOrEmpty(__tmp64Line))
                    {
                        __out.Append(__tmp64Line);
                        __tmp59OutputWritten = true;
                    }
                    if (__tmp59OutputWritten)
                    {
                        __out.AppendLine(false); //387:202
                    }
                    if (__tmp59OutputWritten)
                    {
                        __out.AppendLine(false); //387:202
                    }
                    bool __tmp66OutputWritten = false;
                    string __tmp67Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //388:1
                    if (!string.IsNullOrEmpty(__tmp67Line))
                    {
                        __out.Append(__tmp67Line);
                        __tmp66OutputWritten = true;
                    }
                    StringBuilder __tmp68 = new StringBuilder();
                    __tmp68.Append(collType.InnerType.CSharpFullPublicName(ClassKind.Builder));
                    using(StreamReader __tmp68Reader = new StreamReader(this.__ToStream(__tmp68.ToString())))
                    {
                        bool __tmp68_last = __tmp68Reader.EndOfStream;
                        while(!__tmp68_last)
                        {
                            string __tmp68Line = __tmp68Reader.ReadLine();
                            __tmp68_last = __tmp68Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp68Line))
                            {
                                __out.Append(__tmp68Line);
                                __tmp66OutputWritten = true;
                            }
                            if (!__tmp68_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp69Line = "), typeof("; //388:134
                    if (!string.IsNullOrEmpty(__tmp69Line))
                    {
                        __out.Append(__tmp69Line);
                        __tmp66OutputWritten = true;
                    }
                    StringBuilder __tmp70 = new StringBuilder();
                    __tmp70.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                    using(StreamReader __tmp70Reader = new StreamReader(this.__ToStream(__tmp70.ToString())))
                    {
                        bool __tmp70_last = __tmp70Reader.EndOfStream;
                        while(!__tmp70_last)
                        {
                            string __tmp70Line = __tmp70Reader.ReadLine();
                            __tmp70_last = __tmp70Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp70Line))
                            {
                                __out.Append(__tmp70Line);
                                __tmp66OutputWritten = true;
                            }
                            if (!__tmp70_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp71Line = ")),"; //388:195
                    if (!string.IsNullOrEmpty(__tmp71Line))
                    {
                        __out.Append(__tmp71Line);
                        __tmp66OutputWritten = true;
                    }
                    if (__tmp66OutputWritten)
                    {
                        __out.AppendLine(false); //388:198
                    }
                    if (__tmp66OutputWritten)
                    {
                        __out.AppendLine(false); //388:198
                    }
                    bool __tmp73OutputWritten = false;
                    string __tmp74Line = "		() => "; //389:1
                    if (!string.IsNullOrEmpty(__tmp74Line))
                    {
                        __out.Append(__tmp74Line);
                        __tmp73OutputWritten = true;
                    }
                    StringBuilder __tmp75 = new StringBuilder();
                    __tmp75.Append(prop.CSharpFullInstanceName(ClassKind.Immutable));
                    using(StreamReader __tmp75Reader = new StreamReader(this.__ToStream(__tmp75.ToString())))
                    {
                        bool __tmp75_last = __tmp75Reader.EndOfStream;
                        while(!__tmp75_last)
                        {
                            string __tmp75Line = __tmp75Reader.ReadLine();
                            __tmp75_last = __tmp75Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp75Line))
                            {
                                __out.Append(__tmp75Line);
                                __tmp73OutputWritten = true;
                            }
                            if (!__tmp75_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp76Line = ");"; //389:59
                    if (!string.IsNullOrEmpty(__tmp76Line))
                    {
                        __out.Append(__tmp76Line);
                        __tmp73OutputWritten = true;
                    }
                    if (__tmp73OutputWritten)
                    {
                        __out.AppendLine(false); //389:61
                    }
                    if (__tmp73OutputWritten)
                    {
                        __out.AppendLine(false); //389:61
                    }
                }
                else //390:2
                {
                    bool __tmp78OutputWritten = false;
                    string __tmp79Line = "public static readonly global::MetaDslx.Core.Immutable.ModelProperty "; //391:1
                    if (!string.IsNullOrEmpty(__tmp79Line))
                    {
                        __out.Append(__tmp79Line);
                        __tmp78OutputWritten = true;
                    }
                    StringBuilder __tmp80 = new StringBuilder();
                    __tmp80.Append(prop.Name);
                    using(StreamReader __tmp80Reader = new StreamReader(this.__ToStream(__tmp80.ToString())))
                    {
                        bool __tmp80_last = __tmp80Reader.EndOfStream;
                        while(!__tmp80_last)
                        {
                            string __tmp80Line = __tmp80Reader.ReadLine();
                            __tmp80_last = __tmp80Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp80Line))
                            {
                                __out.Append(__tmp80Line);
                                __tmp78OutputWritten = true;
                            }
                            if (!__tmp80_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp81Line = "Property ="; //391:81
                    if (!string.IsNullOrEmpty(__tmp81Line))
                    {
                        __out.Append(__tmp81Line);
                        __tmp78OutputWritten = true;
                    }
                    if (__tmp78OutputWritten)
                    {
                        __out.AppendLine(false); //391:91
                    }
                    if (__tmp78OutputWritten)
                    {
                        __out.AppendLine(false); //391:91
                    }
                    bool __tmp83OutputWritten = false;
                    string __tmp84Line = "    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof("; //392:1
                    if (!string.IsNullOrEmpty(__tmp84Line))
                    {
                        __out.Append(__tmp84Line);
                        __tmp83OutputWritten = true;
                    }
                    StringBuilder __tmp85 = new StringBuilder();
                    __tmp85.Append(prop.Class.Model.CSharpDescriptorName());
                    using(StreamReader __tmp85Reader = new StreamReader(this.__ToStream(__tmp85.ToString())))
                    {
                        bool __tmp85_last = __tmp85Reader.EndOfStream;
                        while(!__tmp85_last)
                        {
                            string __tmp85Line = __tmp85Reader.ReadLine();
                            __tmp85_last = __tmp85Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp85Line))
                            {
                                __out.Append(__tmp85Line);
                                __tmp83OutputWritten = true;
                            }
                            if (!__tmp85_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp86Line = "."; //392:108
                    if (!string.IsNullOrEmpty(__tmp86Line))
                    {
                        __out.Append(__tmp86Line);
                        __tmp83OutputWritten = true;
                    }
                    StringBuilder __tmp87 = new StringBuilder();
                    __tmp87.Append(prop.Class.CSharpName());
                    using(StreamReader __tmp87Reader = new StreamReader(this.__ToStream(__tmp87.ToString())))
                    {
                        bool __tmp87_last = __tmp87Reader.EndOfStream;
                        while(!__tmp87_last)
                        {
                            string __tmp87Line = __tmp87Reader.ReadLine();
                            __tmp87_last = __tmp87Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp87Line))
                            {
                                __out.Append(__tmp87Line);
                                __tmp83OutputWritten = true;
                            }
                            if (!__tmp87_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp88Line = "), \""; //392:134
                    if (!string.IsNullOrEmpty(__tmp88Line))
                    {
                        __out.Append(__tmp88Line);
                        __tmp83OutputWritten = true;
                    }
                    StringBuilder __tmp89 = new StringBuilder();
                    __tmp89.Append(prop.Name);
                    using(StreamReader __tmp89Reader = new StreamReader(this.__ToStream(__tmp89.ToString())))
                    {
                        bool __tmp89_last = __tmp89Reader.EndOfStream;
                        while(!__tmp89_last)
                        {
                            string __tmp89Line = __tmp89Reader.ReadLine();
                            __tmp89_last = __tmp89Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp89Line))
                            {
                                __out.Append(__tmp89Line);
                                __tmp83OutputWritten = true;
                            }
                            if (!__tmp89_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp90Line = "\","; //392:149
                    if (!string.IsNullOrEmpty(__tmp90Line))
                    {
                        __out.Append(__tmp90Line);
                        __tmp83OutputWritten = true;
                    }
                    if (__tmp83OutputWritten)
                    {
                        __out.AppendLine(false); //392:151
                    }
                    if (__tmp83OutputWritten)
                    {
                        __out.AppendLine(false); //392:151
                    }
                    bool __tmp92OutputWritten = false;
                    string __tmp93Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //393:1
                    if (!string.IsNullOrEmpty(__tmp93Line))
                    {
                        __out.Append(__tmp93Line);
                        __tmp92OutputWritten = true;
                    }
                    StringBuilder __tmp94 = new StringBuilder();
                    __tmp94.Append(prop.Type.CSharpFullPublicName(ClassKind.Immutable));
                    using(StreamReader __tmp94Reader = new StreamReader(this.__ToStream(__tmp94.ToString())))
                    {
                        bool __tmp94_last = __tmp94Reader.EndOfStream;
                        while(!__tmp94_last)
                        {
                            string __tmp94Line = __tmp94Reader.ReadLine();
                            __tmp94_last = __tmp94Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp94Line))
                            {
                                __out.Append(__tmp94Line);
                                __tmp92OutputWritten = true;
                            }
                            if (!__tmp94_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp95Line = "), null),"; //393:127
                    if (!string.IsNullOrEmpty(__tmp95Line))
                    {
                        __out.Append(__tmp95Line);
                        __tmp92OutputWritten = true;
                    }
                    if (__tmp92OutputWritten)
                    {
                        __out.AppendLine(false); //393:136
                    }
                    if (__tmp92OutputWritten)
                    {
                        __out.AppendLine(false); //393:136
                    }
                    bool __tmp97OutputWritten = false;
                    string __tmp98Line = "        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof("; //394:1
                    if (!string.IsNullOrEmpty(__tmp98Line))
                    {
                        __out.Append(__tmp98Line);
                        __tmp97OutputWritten = true;
                    }
                    StringBuilder __tmp99 = new StringBuilder();
                    __tmp99.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                    using(StreamReader __tmp99Reader = new StreamReader(this.__ToStream(__tmp99.ToString())))
                    {
                        bool __tmp99_last = __tmp99Reader.EndOfStream;
                        while(!__tmp99_last)
                        {
                            string __tmp99Line = __tmp99Reader.ReadLine();
                            __tmp99_last = __tmp99Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp99Line))
                            {
                                __out.Append(__tmp99Line);
                                __tmp97OutputWritten = true;
                            }
                            if (!__tmp99_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp100Line = "), null),"; //394:125
                    if (!string.IsNullOrEmpty(__tmp100Line))
                    {
                        __out.Append(__tmp100Line);
                        __tmp97OutputWritten = true;
                    }
                    if (__tmp97OutputWritten)
                    {
                        __out.AppendLine(false); //394:134
                    }
                    if (__tmp97OutputWritten)
                    {
                        __out.AppendLine(false); //394:134
                    }
                    bool __tmp102OutputWritten = false;
                    string __tmp103Line = "		() => "; //395:1
                    if (!string.IsNullOrEmpty(__tmp103Line))
                    {
                        __out.Append(__tmp103Line);
                        __tmp102OutputWritten = true;
                    }
                    StringBuilder __tmp104 = new StringBuilder();
                    __tmp104.Append(prop.CSharpFullInstanceName(ClassKind.Immutable));
                    using(StreamReader __tmp104Reader = new StreamReader(this.__ToStream(__tmp104.ToString())))
                    {
                        bool __tmp104_last = __tmp104Reader.EndOfStream;
                        while(!__tmp104_last)
                        {
                            string __tmp104Line = __tmp104Reader.ReadLine();
                            __tmp104_last = __tmp104Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp104Line))
                            {
                                __out.Append(__tmp104Line);
                                __tmp102OutputWritten = true;
                            }
                            if (!__tmp104_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp105Line = ");"; //395:59
                    if (!string.IsNullOrEmpty(__tmp105Line))
                    {
                        __out.Append(__tmp105Line);
                        __tmp102OutputWritten = true;
                    }
                    if (__tmp102OutputWritten)
                    {
                        __out.AppendLine(false); //395:61
                    }
                    if (__tmp102OutputWritten)
                    {
                        __out.AppendLine(false); //395:61
                    }
                }
            }
            __out.AppendLine(true); //398:1
            return __out.ToString();
        }

        public string GenerateImmutablePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //401:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //402:1
            if (cls.GetAllFinalProperties().Contains(prop)) //403:2
            {
                bool __tmp2OutputWritten = false;
                string __tmp3Line = "public "; //404:1
                if (!string.IsNullOrEmpty(__tmp3Line))
                {
                    __out.Append(__tmp3Line);
                    __tmp2OutputWritten = true;
                }
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append(prop.Type.CSharpFullPublicName(ClassKind.Immutable));
                using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                {
                    bool __tmp4_last = __tmp4Reader.EndOfStream;
                    while(!__tmp4_last)
                    {
                        string __tmp4Line = __tmp4Reader.ReadLine();
                        __tmp4_last = __tmp4Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp4Line))
                        {
                            __out.Append(__tmp4Line);
                            __tmp2OutputWritten = true;
                        }
                        if (!__tmp4_last) __out.AppendLine(true);
                    }
                }
                string __tmp5Line = " "; //404:61
                if (!string.IsNullOrEmpty(__tmp5Line))
                {
                    __out.Append(__tmp5Line);
                    __tmp2OutputWritten = true;
                }
                StringBuilder __tmp6 = new StringBuilder();
                __tmp6.Append(prop.Name);
                using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
                {
                    bool __tmp6_last = __tmp6Reader.EndOfStream;
                    while(!__tmp6_last)
                    {
                        string __tmp6Line = __tmp6Reader.ReadLine();
                        __tmp6_last = __tmp6Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp6Line))
                        {
                            __out.Append(__tmp6Line);
                            __tmp2OutputWritten = true;
                        }
                        if (__tmp2OutputWritten)
                        {
                            __out.AppendLine(false); //404:73
                        }
                    }
                }
                if (__tmp2OutputWritten)
                {
                    __out.AppendLine(false); //404:73
                }
            }
            else //405:2
            {
                bool __tmp8OutputWritten = false;
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
                using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                {
                    bool __tmp9_last = __tmp9Reader.EndOfStream;
                    while(!__tmp9_last)
                    {
                        string __tmp9Line = __tmp9Reader.ReadLine();
                        __tmp9_last = __tmp9Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp9Line))
                        {
                            __out.Append(__tmp9Line);
                            __tmp8OutputWritten = true;
                        }
                        if (__tmp8OutputWritten)
                        {
                            __out.AppendLine(false); //406:54
                        }
                    }
                }
                if (__tmp8OutputWritten)
                {
                    __out.AppendLine(false); //406:54
                }
                bool __tmp11OutputWritten = false;
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(prop.Type.CSharpFullPublicName(ClassKind.Immutable));
                using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
                {
                    bool __tmp12_last = __tmp12Reader.EndOfStream;
                    while(!__tmp12_last)
                    {
                        string __tmp12Line = __tmp12Reader.ReadLine();
                        __tmp12_last = __tmp12Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp12Line))
                        {
                            __out.Append(__tmp12Line);
                            __tmp11OutputWritten = true;
                        }
                        if (!__tmp12_last) __out.AppendLine(true);
                    }
                }
                string __tmp13Line = " "; //407:54
                if (!string.IsNullOrEmpty(__tmp13Line))
                {
                    __out.Append(__tmp13Line);
                    __tmp11OutputWritten = true;
                }
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(prop.Class.CSharpFullName(ClassKind.Immutable));
                using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
                {
                    bool __tmp14_last = __tmp14Reader.EndOfStream;
                    while(!__tmp14_last)
                    {
                        string __tmp14Line = __tmp14Reader.ReadLine();
                        __tmp14_last = __tmp14Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp14Line))
                        {
                            __out.Append(__tmp14Line);
                            __tmp11OutputWritten = true;
                        }
                        if (!__tmp14_last) __out.AppendLine(true);
                    }
                }
                string __tmp15Line = "."; //407:103
                if (!string.IsNullOrEmpty(__tmp15Line))
                {
                    __out.Append(__tmp15Line);
                    __tmp11OutputWritten = true;
                }
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(prop.Name);
                using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
                {
                    bool __tmp16_last = __tmp16Reader.EndOfStream;
                    while(!__tmp16_last)
                    {
                        string __tmp16Line = __tmp16Reader.ReadLine();
                        __tmp16_last = __tmp16Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp16Line))
                        {
                            __out.Append(__tmp16Line);
                            __tmp11OutputWritten = true;
                        }
                        if (__tmp11OutputWritten)
                        {
                            __out.AppendLine(false); //407:115
                        }
                    }
                }
                if (__tmp11OutputWritten)
                {
                    __out.AppendLine(false); //407:115
                }
            }
            __out.Append("{"); //409:1
            __out.AppendLine(false); //409:2
            if (prop.Type is MetaCollectionType) //410:6
            {
                bool __tmp18OutputWritten = false;
                string __tmp19Line = "    get { return this.GetList<"; //411:1
                if (!string.IsNullOrEmpty(__tmp19Line))
                {
                    __out.Append(__tmp19Line);
                    __tmp18OutputWritten = true;
                }
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(((MetaCollectionType)prop.Type).InnerType.CSharpFullPublicName(ClassKind.Immutable));
                using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
                {
                    bool __tmp20_last = __tmp20Reader.EndOfStream;
                    while(!__tmp20_last)
                    {
                        string __tmp20Line = __tmp20Reader.ReadLine();
                        __tmp20_last = __tmp20Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp20Line))
                        {
                            __out.Append(__tmp20Line);
                            __tmp18OutputWritten = true;
                        }
                        if (!__tmp20_last) __out.AppendLine(true);
                    }
                }
                string __tmp21Line = ">("; //411:116
                if (!string.IsNullOrEmpty(__tmp21Line))
                {
                    __out.Append(__tmp21Line);
                    __tmp18OutputWritten = true;
                }
                StringBuilder __tmp22 = new StringBuilder();
                __tmp22.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                using(StreamReader __tmp22Reader = new StreamReader(this.__ToStream(__tmp22.ToString())))
                {
                    bool __tmp22_last = __tmp22Reader.EndOfStream;
                    while(!__tmp22_last)
                    {
                        string __tmp22Line = __tmp22Reader.ReadLine();
                        __tmp22_last = __tmp22Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp22Line))
                        {
                            __out.Append(__tmp22Line);
                            __tmp18OutputWritten = true;
                        }
                        if (!__tmp22_last) __out.AppendLine(true);
                    }
                }
                string __tmp23Line = ", ref "; //411:170
                if (!string.IsNullOrEmpty(__tmp23Line))
                {
                    __out.Append(__tmp23Line);
                    __tmp18OutputWritten = true;
                }
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(prop.GetFieldName(cls));
                using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
                {
                    bool __tmp24_last = __tmp24Reader.EndOfStream;
                    while(!__tmp24_last)
                    {
                        string __tmp24Line = __tmp24Reader.ReadLine();
                        __tmp24_last = __tmp24Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp24Line))
                        {
                            __out.Append(__tmp24Line);
                            __tmp18OutputWritten = true;
                        }
                        if (!__tmp24_last) __out.AppendLine(true);
                    }
                }
                string __tmp25Line = "); }"; //411:200
                if (!string.IsNullOrEmpty(__tmp25Line))
                {
                    __out.Append(__tmp25Line);
                    __tmp18OutputWritten = true;
                }
                if (__tmp18OutputWritten)
                {
                    __out.AppendLine(false); //411:204
                }
                if (__tmp18OutputWritten)
                {
                    __out.AppendLine(false); //411:204
                }
            }
            else if (prop.Type.IsReferenceType()) //412:3
            {
                bool __tmp27OutputWritten = false;
                string __tmp28Line = "    get { return this.GetReference<"; //413:1
                if (!string.IsNullOrEmpty(__tmp28Line))
                {
                    __out.Append(__tmp28Line);
                    __tmp27OutputWritten = true;
                }
                StringBuilder __tmp29 = new StringBuilder();
                __tmp29.Append(prop.Type.CSharpFullPublicName(ClassKind.Immutable));
                using(StreamReader __tmp29Reader = new StreamReader(this.__ToStream(__tmp29.ToString())))
                {
                    bool __tmp29_last = __tmp29Reader.EndOfStream;
                    while(!__tmp29_last)
                    {
                        string __tmp29Line = __tmp29Reader.ReadLine();
                        __tmp29_last = __tmp29Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp29Line))
                        {
                            __out.Append(__tmp29Line);
                            __tmp27OutputWritten = true;
                        }
                        if (!__tmp29_last) __out.AppendLine(true);
                    }
                }
                string __tmp30Line = ">("; //413:89
                if (!string.IsNullOrEmpty(__tmp30Line))
                {
                    __out.Append(__tmp30Line);
                    __tmp27OutputWritten = true;
                }
                StringBuilder __tmp31 = new StringBuilder();
                __tmp31.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                using(StreamReader __tmp31Reader = new StreamReader(this.__ToStream(__tmp31.ToString())))
                {
                    bool __tmp31_last = __tmp31Reader.EndOfStream;
                    while(!__tmp31_last)
                    {
                        string __tmp31Line = __tmp31Reader.ReadLine();
                        __tmp31_last = __tmp31Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp31Line))
                        {
                            __out.Append(__tmp31Line);
                            __tmp27OutputWritten = true;
                        }
                        if (!__tmp31_last) __out.AppendLine(true);
                    }
                }
                string __tmp32Line = ", ref "; //413:143
                if (!string.IsNullOrEmpty(__tmp32Line))
                {
                    __out.Append(__tmp32Line);
                    __tmp27OutputWritten = true;
                }
                StringBuilder __tmp33 = new StringBuilder();
                __tmp33.Append(prop.GetFieldName(cls));
                using(StreamReader __tmp33Reader = new StreamReader(this.__ToStream(__tmp33.ToString())))
                {
                    bool __tmp33_last = __tmp33Reader.EndOfStream;
                    while(!__tmp33_last)
                    {
                        string __tmp33Line = __tmp33Reader.ReadLine();
                        __tmp33_last = __tmp33Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp33Line))
                        {
                            __out.Append(__tmp33Line);
                            __tmp27OutputWritten = true;
                        }
                        if (!__tmp33_last) __out.AppendLine(true);
                    }
                }
                string __tmp34Line = "); }"; //413:173
                if (!string.IsNullOrEmpty(__tmp34Line))
                {
                    __out.Append(__tmp34Line);
                    __tmp27OutputWritten = true;
                }
                if (__tmp27OutputWritten)
                {
                    __out.AppendLine(false); //413:177
                }
                if (__tmp27OutputWritten)
                {
                    __out.AppendLine(false); //413:177
                }
            }
            else //414:3
            {
                bool __tmp36OutputWritten = false;
                string __tmp37Line = "    get { return this.GetValue<"; //415:1
                if (!string.IsNullOrEmpty(__tmp37Line))
                {
                    __out.Append(__tmp37Line);
                    __tmp36OutputWritten = true;
                }
                StringBuilder __tmp38 = new StringBuilder();
                __tmp38.Append(prop.Type.CSharpFullPublicName(ClassKind.Immutable));
                using(StreamReader __tmp38Reader = new StreamReader(this.__ToStream(__tmp38.ToString())))
                {
                    bool __tmp38_last = __tmp38Reader.EndOfStream;
                    while(!__tmp38_last)
                    {
                        string __tmp38Line = __tmp38Reader.ReadLine();
                        __tmp38_last = __tmp38Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp38Line))
                        {
                            __out.Append(__tmp38Line);
                            __tmp36OutputWritten = true;
                        }
                        if (!__tmp38_last) __out.AppendLine(true);
                    }
                }
                string __tmp39Line = ">("; //415:85
                if (!string.IsNullOrEmpty(__tmp39Line))
                {
                    __out.Append(__tmp39Line);
                    __tmp36OutputWritten = true;
                }
                StringBuilder __tmp40 = new StringBuilder();
                __tmp40.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                using(StreamReader __tmp40Reader = new StreamReader(this.__ToStream(__tmp40.ToString())))
                {
                    bool __tmp40_last = __tmp40Reader.EndOfStream;
                    while(!__tmp40_last)
                    {
                        string __tmp40Line = __tmp40Reader.ReadLine();
                        __tmp40_last = __tmp40Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp40Line))
                        {
                            __out.Append(__tmp40Line);
                            __tmp36OutputWritten = true;
                        }
                        if (!__tmp40_last) __out.AppendLine(true);
                    }
                }
                string __tmp41Line = ", ref "; //415:139
                if (!string.IsNullOrEmpty(__tmp41Line))
                {
                    __out.Append(__tmp41Line);
                    __tmp36OutputWritten = true;
                }
                StringBuilder __tmp42 = new StringBuilder();
                __tmp42.Append(prop.GetFieldName(cls));
                using(StreamReader __tmp42Reader = new StreamReader(this.__ToStream(__tmp42.ToString())))
                {
                    bool __tmp42_last = __tmp42Reader.EndOfStream;
                    while(!__tmp42_last)
                    {
                        string __tmp42Line = __tmp42Reader.ReadLine();
                        __tmp42_last = __tmp42Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp42Line))
                        {
                            __out.Append(__tmp42Line);
                            __tmp36OutputWritten = true;
                        }
                        if (!__tmp42_last) __out.AppendLine(true);
                    }
                }
                string __tmp43Line = "); }"; //415:169
                if (!string.IsNullOrEmpty(__tmp43Line))
                {
                    __out.Append(__tmp43Line);
                    __tmp36OutputWritten = true;
                }
                if (__tmp36OutputWritten)
                {
                    __out.AppendLine(false); //415:173
                }
                if (__tmp36OutputWritten)
                {
                    __out.AppendLine(false); //415:173
                }
            }
            __out.Append("}"); //417:1
            __out.AppendLine(false); //417:2
            return __out.ToString();
        }

        public string GenerateBuilderPropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //420:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //421:1
            if (cls.GetAllFinalProperties().Contains(prop)) //422:2
            {
                bool __tmp2OutputWritten = false;
                string __tmp3Line = "public "; //423:1
                if (!string.IsNullOrEmpty(__tmp3Line))
                {
                    __out.Append(__tmp3Line);
                    __tmp2OutputWritten = true;
                }
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                {
                    bool __tmp4_last = __tmp4Reader.EndOfStream;
                    while(!__tmp4_last)
                    {
                        string __tmp4Line = __tmp4Reader.ReadLine();
                        __tmp4_last = __tmp4Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp4Line))
                        {
                            __out.Append(__tmp4Line);
                            __tmp2OutputWritten = true;
                        }
                        if (!__tmp4_last) __out.AppendLine(true);
                    }
                }
                string __tmp5Line = " "; //423:59
                if (!string.IsNullOrEmpty(__tmp5Line))
                {
                    __out.Append(__tmp5Line);
                    __tmp2OutputWritten = true;
                }
                StringBuilder __tmp6 = new StringBuilder();
                __tmp6.Append(prop.Name);
                using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
                {
                    bool __tmp6_last = __tmp6Reader.EndOfStream;
                    while(!__tmp6_last)
                    {
                        string __tmp6Line = __tmp6Reader.ReadLine();
                        __tmp6_last = __tmp6Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp6Line))
                        {
                            __out.Append(__tmp6Line);
                            __tmp2OutputWritten = true;
                        }
                        if (__tmp2OutputWritten)
                        {
                            __out.AppendLine(false); //423:71
                        }
                    }
                }
                if (__tmp2OutputWritten)
                {
                    __out.AppendLine(false); //423:71
                }
            }
            else //424:2
            {
                bool __tmp8OutputWritten = false;
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
                using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                {
                    bool __tmp9_last = __tmp9Reader.EndOfStream;
                    while(!__tmp9_last)
                    {
                        string __tmp9Line = __tmp9Reader.ReadLine();
                        __tmp9_last = __tmp9Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp9Line))
                        {
                            __out.Append(__tmp9Line);
                            __tmp8OutputWritten = true;
                        }
                        if (__tmp8OutputWritten)
                        {
                            __out.AppendLine(false); //425:54
                        }
                    }
                }
                if (__tmp8OutputWritten)
                {
                    __out.AppendLine(false); //425:54
                }
                bool __tmp11OutputWritten = false;
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
                {
                    bool __tmp12_last = __tmp12Reader.EndOfStream;
                    while(!__tmp12_last)
                    {
                        string __tmp12Line = __tmp12Reader.ReadLine();
                        __tmp12_last = __tmp12Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp12Line))
                        {
                            __out.Append(__tmp12Line);
                            __tmp11OutputWritten = true;
                        }
                        if (!__tmp12_last) __out.AppendLine(true);
                    }
                }
                string __tmp13Line = " "; //426:52
                if (!string.IsNullOrEmpty(__tmp13Line))
                {
                    __out.Append(__tmp13Line);
                    __tmp11OutputWritten = true;
                }
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(prop.Class.CSharpFullName(ClassKind.Builder));
                using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
                {
                    bool __tmp14_last = __tmp14Reader.EndOfStream;
                    while(!__tmp14_last)
                    {
                        string __tmp14Line = __tmp14Reader.ReadLine();
                        __tmp14_last = __tmp14Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp14Line))
                        {
                            __out.Append(__tmp14Line);
                            __tmp11OutputWritten = true;
                        }
                        if (!__tmp14_last) __out.AppendLine(true);
                    }
                }
                string __tmp15Line = "."; //426:99
                if (!string.IsNullOrEmpty(__tmp15Line))
                {
                    __out.Append(__tmp15Line);
                    __tmp11OutputWritten = true;
                }
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(prop.Name);
                using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
                {
                    bool __tmp16_last = __tmp16Reader.EndOfStream;
                    while(!__tmp16_last)
                    {
                        string __tmp16Line = __tmp16Reader.ReadLine();
                        __tmp16_last = __tmp16Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp16Line))
                        {
                            __out.Append(__tmp16Line);
                            __tmp11OutputWritten = true;
                        }
                        if (__tmp11OutputWritten)
                        {
                            __out.AppendLine(false); //426:111
                        }
                    }
                }
                if (__tmp11OutputWritten)
                {
                    __out.AppendLine(false); //426:111
                }
            }
            __out.Append("{"); //428:1
            __out.AppendLine(false); //428:2
            if (prop.Type is MetaCollectionType) //429:6
            {
                bool __tmp18OutputWritten = false;
                string __tmp19Line = "    get { return this.GetList<"; //430:1
                if (!string.IsNullOrEmpty(__tmp19Line))
                {
                    __out.Append(__tmp19Line);
                    __tmp18OutputWritten = true;
                }
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(((MetaCollectionType)prop.Type).InnerType.CSharpFullPublicName(ClassKind.Builder));
                using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
                {
                    bool __tmp20_last = __tmp20Reader.EndOfStream;
                    while(!__tmp20_last)
                    {
                        string __tmp20Line = __tmp20Reader.ReadLine();
                        __tmp20_last = __tmp20Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp20Line))
                        {
                            __out.Append(__tmp20Line);
                            __tmp18OutputWritten = true;
                        }
                        if (!__tmp20_last) __out.AppendLine(true);
                    }
                }
                string __tmp21Line = ">("; //430:114
                if (!string.IsNullOrEmpty(__tmp21Line))
                {
                    __out.Append(__tmp21Line);
                    __tmp18OutputWritten = true;
                }
                StringBuilder __tmp22 = new StringBuilder();
                __tmp22.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                using(StreamReader __tmp22Reader = new StreamReader(this.__ToStream(__tmp22.ToString())))
                {
                    bool __tmp22_last = __tmp22Reader.EndOfStream;
                    while(!__tmp22_last)
                    {
                        string __tmp22Line = __tmp22Reader.ReadLine();
                        __tmp22_last = __tmp22Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp22Line))
                        {
                            __out.Append(__tmp22Line);
                            __tmp18OutputWritten = true;
                        }
                        if (!__tmp22_last) __out.AppendLine(true);
                    }
                }
                string __tmp23Line = ", ref "; //430:168
                if (!string.IsNullOrEmpty(__tmp23Line))
                {
                    __out.Append(__tmp23Line);
                    __tmp18OutputWritten = true;
                }
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(prop.GetFieldName(cls));
                using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
                {
                    bool __tmp24_last = __tmp24Reader.EndOfStream;
                    while(!__tmp24_last)
                    {
                        string __tmp24Line = __tmp24Reader.ReadLine();
                        __tmp24_last = __tmp24Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp24Line))
                        {
                            __out.Append(__tmp24Line);
                            __tmp18OutputWritten = true;
                        }
                        if (!__tmp24_last) __out.AppendLine(true);
                    }
                }
                string __tmp25Line = "); }"; //430:198
                if (!string.IsNullOrEmpty(__tmp25Line))
                {
                    __out.Append(__tmp25Line);
                    __tmp18OutputWritten = true;
                }
                if (__tmp18OutputWritten)
                {
                    __out.AppendLine(false); //430:202
                }
                if (__tmp18OutputWritten)
                {
                    __out.AppendLine(false); //430:202
                }
            }
            else if (prop.Type.IsReferenceType()) //431:3
            {
                bool __tmp27OutputWritten = false;
                string __tmp28Line = "    get { return this.GetReference<"; //432:1
                if (!string.IsNullOrEmpty(__tmp28Line))
                {
                    __out.Append(__tmp28Line);
                    __tmp27OutputWritten = true;
                }
                StringBuilder __tmp29 = new StringBuilder();
                __tmp29.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                using(StreamReader __tmp29Reader = new StreamReader(this.__ToStream(__tmp29.ToString())))
                {
                    bool __tmp29_last = __tmp29Reader.EndOfStream;
                    while(!__tmp29_last)
                    {
                        string __tmp29Line = __tmp29Reader.ReadLine();
                        __tmp29_last = __tmp29Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp29Line))
                        {
                            __out.Append(__tmp29Line);
                            __tmp27OutputWritten = true;
                        }
                        if (!__tmp29_last) __out.AppendLine(true);
                    }
                }
                string __tmp30Line = ">("; //432:87
                if (!string.IsNullOrEmpty(__tmp30Line))
                {
                    __out.Append(__tmp30Line);
                    __tmp27OutputWritten = true;
                }
                StringBuilder __tmp31 = new StringBuilder();
                __tmp31.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                using(StreamReader __tmp31Reader = new StreamReader(this.__ToStream(__tmp31.ToString())))
                {
                    bool __tmp31_last = __tmp31Reader.EndOfStream;
                    while(!__tmp31_last)
                    {
                        string __tmp31Line = __tmp31Reader.ReadLine();
                        __tmp31_last = __tmp31Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp31Line))
                        {
                            __out.Append(__tmp31Line);
                            __tmp27OutputWritten = true;
                        }
                        if (!__tmp31_last) __out.AppendLine(true);
                    }
                }
                string __tmp32Line = "); }"; //432:141
                if (!string.IsNullOrEmpty(__tmp32Line))
                {
                    __out.Append(__tmp32Line);
                    __tmp27OutputWritten = true;
                }
                if (__tmp27OutputWritten)
                {
                    __out.AppendLine(false); //432:145
                }
                if (__tmp27OutputWritten)
                {
                    __out.AppendLine(false); //432:145
                }
            }
            else //433:3
            {
                bool __tmp34OutputWritten = false;
                string __tmp35Line = "    get { return this.GetValue<"; //434:1
                if (!string.IsNullOrEmpty(__tmp35Line))
                {
                    __out.Append(__tmp35Line);
                    __tmp34OutputWritten = true;
                }
                StringBuilder __tmp36 = new StringBuilder();
                __tmp36.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                using(StreamReader __tmp36Reader = new StreamReader(this.__ToStream(__tmp36.ToString())))
                {
                    bool __tmp36_last = __tmp36Reader.EndOfStream;
                    while(!__tmp36_last)
                    {
                        string __tmp36Line = __tmp36Reader.ReadLine();
                        __tmp36_last = __tmp36Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp36Line))
                        {
                            __out.Append(__tmp36Line);
                            __tmp34OutputWritten = true;
                        }
                        if (!__tmp36_last) __out.AppendLine(true);
                    }
                }
                string __tmp37Line = ">("; //434:83
                if (!string.IsNullOrEmpty(__tmp37Line))
                {
                    __out.Append(__tmp37Line);
                    __tmp34OutputWritten = true;
                }
                StringBuilder __tmp38 = new StringBuilder();
                __tmp38.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                using(StreamReader __tmp38Reader = new StreamReader(this.__ToStream(__tmp38.ToString())))
                {
                    bool __tmp38_last = __tmp38Reader.EndOfStream;
                    while(!__tmp38_last)
                    {
                        string __tmp38Line = __tmp38Reader.ReadLine();
                        __tmp38_last = __tmp38Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp38Line))
                        {
                            __out.Append(__tmp38Line);
                            __tmp34OutputWritten = true;
                        }
                        if (!__tmp38_last) __out.AppendLine(true);
                    }
                }
                string __tmp39Line = "); }"; //434:137
                if (!string.IsNullOrEmpty(__tmp39Line))
                {
                    __out.Append(__tmp39Line);
                    __tmp34OutputWritten = true;
                }
                if (__tmp34OutputWritten)
                {
                    __out.AppendLine(false); //434:141
                }
                if (__tmp34OutputWritten)
                {
                    __out.AppendLine(false); //434:141
                }
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //436:3
            {
                if (prop.Type.IsReferenceType()) //437:4
                {
                    bool __tmp41OutputWritten = false;
                    string __tmp42Line = "    set { this.SetReference<"; //438:1
                    if (!string.IsNullOrEmpty(__tmp42Line))
                    {
                        __out.Append(__tmp42Line);
                        __tmp41OutputWritten = true;
                    }
                    StringBuilder __tmp43 = new StringBuilder();
                    __tmp43.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                    using(StreamReader __tmp43Reader = new StreamReader(this.__ToStream(__tmp43.ToString())))
                    {
                        bool __tmp43_last = __tmp43Reader.EndOfStream;
                        while(!__tmp43_last)
                        {
                            string __tmp43Line = __tmp43Reader.ReadLine();
                            __tmp43_last = __tmp43Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp43Line))
                            {
                                __out.Append(__tmp43Line);
                                __tmp41OutputWritten = true;
                            }
                            if (!__tmp43_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp44Line = ">("; //438:80
                    if (!string.IsNullOrEmpty(__tmp44Line))
                    {
                        __out.Append(__tmp44Line);
                        __tmp41OutputWritten = true;
                    }
                    StringBuilder __tmp45 = new StringBuilder();
                    __tmp45.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                    using(StreamReader __tmp45Reader = new StreamReader(this.__ToStream(__tmp45.ToString())))
                    {
                        bool __tmp45_last = __tmp45Reader.EndOfStream;
                        while(!__tmp45_last)
                        {
                            string __tmp45Line = __tmp45Reader.ReadLine();
                            __tmp45_last = __tmp45Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp45Line))
                            {
                                __out.Append(__tmp45Line);
                                __tmp41OutputWritten = true;
                            }
                            if (!__tmp45_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp46Line = ", value); }"; //438:134
                    if (!string.IsNullOrEmpty(__tmp46Line))
                    {
                        __out.Append(__tmp46Line);
                        __tmp41OutputWritten = true;
                    }
                    if (__tmp41OutputWritten)
                    {
                        __out.AppendLine(false); //438:145
                    }
                    if (__tmp41OutputWritten)
                    {
                        __out.AppendLine(false); //438:145
                    }
                }
                else //439:4
                {
                    bool __tmp48OutputWritten = false;
                    string __tmp49Line = "    set { this.SetValue<"; //440:1
                    if (!string.IsNullOrEmpty(__tmp49Line))
                    {
                        __out.Append(__tmp49Line);
                        __tmp48OutputWritten = true;
                    }
                    StringBuilder __tmp50 = new StringBuilder();
                    __tmp50.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                    using(StreamReader __tmp50Reader = new StreamReader(this.__ToStream(__tmp50.ToString())))
                    {
                        bool __tmp50_last = __tmp50Reader.EndOfStream;
                        while(!__tmp50_last)
                        {
                            string __tmp50Line = __tmp50Reader.ReadLine();
                            __tmp50_last = __tmp50Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp50Line))
                            {
                                __out.Append(__tmp50Line);
                                __tmp48OutputWritten = true;
                            }
                            if (!__tmp50_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp51Line = ">("; //440:76
                    if (!string.IsNullOrEmpty(__tmp51Line))
                    {
                        __out.Append(__tmp51Line);
                        __tmp48OutputWritten = true;
                    }
                    StringBuilder __tmp52 = new StringBuilder();
                    __tmp52.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                    using(StreamReader __tmp52Reader = new StreamReader(this.__ToStream(__tmp52.ToString())))
                    {
                        bool __tmp52_last = __tmp52Reader.EndOfStream;
                        while(!__tmp52_last)
                        {
                            string __tmp52Line = __tmp52Reader.ReadLine();
                            __tmp52_last = __tmp52Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp52Line))
                            {
                                __out.Append(__tmp52Line);
                                __tmp48OutputWritten = true;
                            }
                            if (!__tmp52_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp53Line = ", value); }"; //440:130
                    if (!string.IsNullOrEmpty(__tmp53Line))
                    {
                        __out.Append(__tmp53Line);
                        __tmp48OutputWritten = true;
                    }
                    if (__tmp48OutputWritten)
                    {
                        __out.AppendLine(false); //440:141
                    }
                    if (__tmp48OutputWritten)
                    {
                        __out.AppendLine(false); //440:141
                    }
                }
            }
            __out.Append("}"); //443:1
            __out.AppendLine(false); //443:2
            if (!(prop.Type is MetaCollectionType)) //444:2
            {
                __out.AppendLine(true); //445:1
                if (cls.GetAllFinalProperties().Contains(prop)) //446:3
                {
                    bool __tmp55OutputWritten = false;
                    string __tmp56Line = "public Func<"; //447:1
                    if (!string.IsNullOrEmpty(__tmp56Line))
                    {
                        __out.Append(__tmp56Line);
                        __tmp55OutputWritten = true;
                    }
                    StringBuilder __tmp57 = new StringBuilder();
                    __tmp57.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                    using(StreamReader __tmp57Reader = new StreamReader(this.__ToStream(__tmp57.ToString())))
                    {
                        bool __tmp57_last = __tmp57Reader.EndOfStream;
                        while(!__tmp57_last)
                        {
                            string __tmp57Line = __tmp57Reader.ReadLine();
                            __tmp57_last = __tmp57Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp57Line))
                            {
                                __out.Append(__tmp57Line);
                                __tmp55OutputWritten = true;
                            }
                            if (!__tmp57_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp58Line = "> "; //447:64
                    if (!string.IsNullOrEmpty(__tmp58Line))
                    {
                        __out.Append(__tmp58Line);
                        __tmp55OutputWritten = true;
                    }
                    StringBuilder __tmp59 = new StringBuilder();
                    __tmp59.Append(prop.Name);
                    using(StreamReader __tmp59Reader = new StreamReader(this.__ToStream(__tmp59.ToString())))
                    {
                        bool __tmp59_last = __tmp59Reader.EndOfStream;
                        while(!__tmp59_last)
                        {
                            string __tmp59Line = __tmp59Reader.ReadLine();
                            __tmp59_last = __tmp59Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp59Line))
                            {
                                __out.Append(__tmp59Line);
                                __tmp55OutputWritten = true;
                            }
                            if (!__tmp59_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp60Line = "Lazy"; //447:77
                    if (!string.IsNullOrEmpty(__tmp60Line))
                    {
                        __out.Append(__tmp60Line);
                        __tmp55OutputWritten = true;
                    }
                    if (__tmp55OutputWritten)
                    {
                        __out.AppendLine(false); //447:81
                    }
                    if (__tmp55OutputWritten)
                    {
                        __out.AppendLine(false); //447:81
                    }
                }
                else //448:3
                {
                    bool __tmp62OutputWritten = false;
                    StringBuilder __tmp63 = new StringBuilder();
                    __tmp63.Append("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
                    using(StreamReader __tmp63Reader = new StreamReader(this.__ToStream(__tmp63.ToString())))
                    {
                        bool __tmp63_last = __tmp63Reader.EndOfStream;
                        while(!__tmp63_last)
                        {
                            string __tmp63Line = __tmp63Reader.ReadLine();
                            __tmp63_last = __tmp63Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp63Line))
                            {
                                __out.Append(__tmp63Line);
                                __tmp62OutputWritten = true;
                            }
                            if (__tmp62OutputWritten)
                            {
                                __out.AppendLine(false); //449:54
                            }
                        }
                    }
                    if (__tmp62OutputWritten)
                    {
                        __out.AppendLine(false); //449:54
                    }
                    bool __tmp65OutputWritten = false;
                    string __tmp66Line = "Func<"; //450:1
                    if (!string.IsNullOrEmpty(__tmp66Line))
                    {
                        __out.Append(__tmp66Line);
                        __tmp65OutputWritten = true;
                    }
                    StringBuilder __tmp67 = new StringBuilder();
                    __tmp67.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                    using(StreamReader __tmp67Reader = new StreamReader(this.__ToStream(__tmp67.ToString())))
                    {
                        bool __tmp67_last = __tmp67Reader.EndOfStream;
                        while(!__tmp67_last)
                        {
                            string __tmp67Line = __tmp67Reader.ReadLine();
                            __tmp67_last = __tmp67Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp67Line))
                            {
                                __out.Append(__tmp67Line);
                                __tmp65OutputWritten = true;
                            }
                            if (!__tmp67_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp68Line = "> "; //450:57
                    if (!string.IsNullOrEmpty(__tmp68Line))
                    {
                        __out.Append(__tmp68Line);
                        __tmp65OutputWritten = true;
                    }
                    StringBuilder __tmp69 = new StringBuilder();
                    __tmp69.Append(prop.Class.CSharpFullName(ClassKind.Builder));
                    using(StreamReader __tmp69Reader = new StreamReader(this.__ToStream(__tmp69.ToString())))
                    {
                        bool __tmp69_last = __tmp69Reader.EndOfStream;
                        while(!__tmp69_last)
                        {
                            string __tmp69Line = __tmp69Reader.ReadLine();
                            __tmp69_last = __tmp69Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp69Line))
                            {
                                __out.Append(__tmp69Line);
                                __tmp65OutputWritten = true;
                            }
                            if (!__tmp69_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp70Line = "."; //450:105
                    if (!string.IsNullOrEmpty(__tmp70Line))
                    {
                        __out.Append(__tmp70Line);
                        __tmp65OutputWritten = true;
                    }
                    StringBuilder __tmp71 = new StringBuilder();
                    __tmp71.Append(prop.Name);
                    using(StreamReader __tmp71Reader = new StreamReader(this.__ToStream(__tmp71.ToString())))
                    {
                        bool __tmp71_last = __tmp71Reader.EndOfStream;
                        while(!__tmp71_last)
                        {
                            string __tmp71Line = __tmp71Reader.ReadLine();
                            __tmp71_last = __tmp71Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp71Line))
                            {
                                __out.Append(__tmp71Line);
                                __tmp65OutputWritten = true;
                            }
                            if (!__tmp71_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp72Line = "Lazy"; //450:117
                    if (!string.IsNullOrEmpty(__tmp72Line))
                    {
                        __out.Append(__tmp72Line);
                        __tmp65OutputWritten = true;
                    }
                    if (__tmp65OutputWritten)
                    {
                        __out.AppendLine(false); //450:121
                    }
                    if (__tmp65OutputWritten)
                    {
                        __out.AppendLine(false); //450:121
                    }
                }
                __out.Append("{"); //452:1
                __out.AppendLine(false); //452:2
                if (prop.Type.IsReferenceType()) //453:4
                {
                    bool __tmp74OutputWritten = false;
                    string __tmp75Line = "    get { return this.GetLazyReference<"; //454:1
                    if (!string.IsNullOrEmpty(__tmp75Line))
                    {
                        __out.Append(__tmp75Line);
                        __tmp74OutputWritten = true;
                    }
                    StringBuilder __tmp76 = new StringBuilder();
                    __tmp76.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                    using(StreamReader __tmp76Reader = new StreamReader(this.__ToStream(__tmp76.ToString())))
                    {
                        bool __tmp76_last = __tmp76Reader.EndOfStream;
                        while(!__tmp76_last)
                        {
                            string __tmp76Line = __tmp76Reader.ReadLine();
                            __tmp76_last = __tmp76Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp76Line))
                            {
                                __out.Append(__tmp76Line);
                                __tmp74OutputWritten = true;
                            }
                            if (!__tmp76_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp77Line = ">("; //454:91
                    if (!string.IsNullOrEmpty(__tmp77Line))
                    {
                        __out.Append(__tmp77Line);
                        __tmp74OutputWritten = true;
                    }
                    StringBuilder __tmp78 = new StringBuilder();
                    __tmp78.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                    using(StreamReader __tmp78Reader = new StreamReader(this.__ToStream(__tmp78.ToString())))
                    {
                        bool __tmp78_last = __tmp78Reader.EndOfStream;
                        while(!__tmp78_last)
                        {
                            string __tmp78Line = __tmp78Reader.ReadLine();
                            __tmp78_last = __tmp78Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp78Line))
                            {
                                __out.Append(__tmp78Line);
                                __tmp74OutputWritten = true;
                            }
                            if (!__tmp78_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp79Line = "); }"; //454:145
                    if (!string.IsNullOrEmpty(__tmp79Line))
                    {
                        __out.Append(__tmp79Line);
                        __tmp74OutputWritten = true;
                    }
                    if (__tmp74OutputWritten)
                    {
                        __out.AppendLine(false); //454:149
                    }
                    if (__tmp74OutputWritten)
                    {
                        __out.AppendLine(false); //454:149
                    }
                    bool __tmp81OutputWritten = false;
                    string __tmp82Line = "    set { this.SetLazyReference("; //455:1
                    if (!string.IsNullOrEmpty(__tmp82Line))
                    {
                        __out.Append(__tmp82Line);
                        __tmp81OutputWritten = true;
                    }
                    StringBuilder __tmp83 = new StringBuilder();
                    __tmp83.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                    using(StreamReader __tmp83Reader = new StreamReader(this.__ToStream(__tmp83.ToString())))
                    {
                        bool __tmp83_last = __tmp83Reader.EndOfStream;
                        while(!__tmp83_last)
                        {
                            string __tmp83Line = __tmp83Reader.ReadLine();
                            __tmp83_last = __tmp83Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp83Line))
                            {
                                __out.Append(__tmp83Line);
                                __tmp81OutputWritten = true;
                            }
                            if (!__tmp83_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp84Line = ", value); }"; //455:85
                    if (!string.IsNullOrEmpty(__tmp84Line))
                    {
                        __out.Append(__tmp84Line);
                        __tmp81OutputWritten = true;
                    }
                    if (__tmp81OutputWritten)
                    {
                        __out.AppendLine(false); //455:96
                    }
                    if (__tmp81OutputWritten)
                    {
                        __out.AppendLine(false); //455:96
                    }
                }
                else //456:4
                {
                    bool __tmp86OutputWritten = false;
                    string __tmp87Line = "    get { return this.GetLazyValue<"; //457:1
                    if (!string.IsNullOrEmpty(__tmp87Line))
                    {
                        __out.Append(__tmp87Line);
                        __tmp86OutputWritten = true;
                    }
                    StringBuilder __tmp88 = new StringBuilder();
                    __tmp88.Append(prop.Type.CSharpFullPublicName(ClassKind.Builder));
                    using(StreamReader __tmp88Reader = new StreamReader(this.__ToStream(__tmp88.ToString())))
                    {
                        bool __tmp88_last = __tmp88Reader.EndOfStream;
                        while(!__tmp88_last)
                        {
                            string __tmp88Line = __tmp88Reader.ReadLine();
                            __tmp88_last = __tmp88Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp88Line))
                            {
                                __out.Append(__tmp88Line);
                                __tmp86OutputWritten = true;
                            }
                            if (!__tmp88_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp89Line = ">("; //457:87
                    if (!string.IsNullOrEmpty(__tmp89Line))
                    {
                        __out.Append(__tmp89Line);
                        __tmp86OutputWritten = true;
                    }
                    StringBuilder __tmp90 = new StringBuilder();
                    __tmp90.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                    using(StreamReader __tmp90Reader = new StreamReader(this.__ToStream(__tmp90.ToString())))
                    {
                        bool __tmp90_last = __tmp90Reader.EndOfStream;
                        while(!__tmp90_last)
                        {
                            string __tmp90Line = __tmp90Reader.ReadLine();
                            __tmp90_last = __tmp90Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp90Line))
                            {
                                __out.Append(__tmp90Line);
                                __tmp86OutputWritten = true;
                            }
                            if (!__tmp90_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp91Line = "); }"; //457:141
                    if (!string.IsNullOrEmpty(__tmp91Line))
                    {
                        __out.Append(__tmp91Line);
                        __tmp86OutputWritten = true;
                    }
                    if (__tmp86OutputWritten)
                    {
                        __out.AppendLine(false); //457:145
                    }
                    if (__tmp86OutputWritten)
                    {
                        __out.AppendLine(false); //457:145
                    }
                    bool __tmp93OutputWritten = false;
                    string __tmp94Line = "    set { this.SetLazyValue("; //458:1
                    if (!string.IsNullOrEmpty(__tmp94Line))
                    {
                        __out.Append(__tmp94Line);
                        __tmp93OutputWritten = true;
                    }
                    StringBuilder __tmp95 = new StringBuilder();
                    __tmp95.Append(prop.CSharpFullDescriptorName(ClassKind.Immutable));
                    using(StreamReader __tmp95Reader = new StreamReader(this.__ToStream(__tmp95.ToString())))
                    {
                        bool __tmp95_last = __tmp95Reader.EndOfStream;
                        while(!__tmp95_last)
                        {
                            string __tmp95Line = __tmp95Reader.ReadLine();
                            __tmp95_last = __tmp95Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp95Line))
                            {
                                __out.Append(__tmp95Line);
                                __tmp93OutputWritten = true;
                            }
                            if (!__tmp95_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp96Line = ", value); }"; //458:81
                    if (!string.IsNullOrEmpty(__tmp96Line))
                    {
                        __out.Append(__tmp96Line);
                        __tmp93OutputWritten = true;
                    }
                    if (__tmp93OutputWritten)
                    {
                        __out.AppendLine(false); //458:92
                    }
                    if (__tmp93OutputWritten)
                    {
                        __out.AppendLine(false); //458:92
                    }
                }
                __out.Append("}"); //460:1
                __out.AppendLine(false); //460:2
            }
            return __out.ToString();
        }

        public string GetReturn(MetaOperation op) //464:1
        {
            if (op.ReturnType.CSharpName() == "void") //465:5
            {
                return ""; //466:3
            }
            else //467:2
            {
                return "return "; //468:3
            }
        }

        public string GenerateOperationImpl(MetaModel model, MetaOperation op) //472:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //473:1
            bool __tmp2OutputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(op.ReturnType.CSharpFullPublicName(ClassKind.Immutable));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(!__tmp3_last)
                {
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp3Line))
                    {
                        __out.Append(__tmp3Line);
                        __tmp2OutputWritten = true;
                    }
                    if (!__tmp3_last) __out.AppendLine(true);
                }
            }
            string __tmp4Line = " "; //474:58
            if (!string.IsNullOrEmpty(__tmp4Line))
            {
                __out.Append(__tmp4Line);
                __tmp2OutputWritten = true;
            }
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(op.Parent.CSharpFullName(ClassKind.Immutable));
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_last = __tmp5Reader.EndOfStream;
                while(!__tmp5_last)
                {
                    string __tmp5Line = __tmp5Reader.ReadLine();
                    __tmp5_last = __tmp5Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp5Line))
                    {
                        __out.Append(__tmp5Line);
                        __tmp2OutputWritten = true;
                    }
                    if (!__tmp5_last) __out.AppendLine(true);
                }
            }
            string __tmp6Line = "."; //474:106
            if (!string.IsNullOrEmpty(__tmp6Line))
            {
                __out.Append(__tmp6Line);
                __tmp2OutputWritten = true;
            }
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(op.Name);
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(!__tmp7_last)
                {
                    string __tmp7Line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp7Line))
                    {
                        __out.Append(__tmp7Line);
                        __tmp2OutputWritten = true;
                    }
                    if (!__tmp7_last) __out.AppendLine(true);
                }
            }
            string __tmp8Line = "("; //474:116
            if (!string.IsNullOrEmpty(__tmp8Line))
            {
                __out.Append(__tmp8Line);
                __tmp2OutputWritten = true;
            }
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(GetParameters(op, ClassKind.Immutable));
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_last = __tmp9Reader.EndOfStream;
                while(!__tmp9_last)
                {
                    string __tmp9Line = __tmp9Reader.ReadLine();
                    __tmp9_last = __tmp9Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp9Line))
                    {
                        __out.Append(__tmp9Line);
                        __tmp2OutputWritten = true;
                    }
                    if (!__tmp9_last) __out.AppendLine(true);
                }
            }
            string __tmp10Line = ")"; //474:157
            if (!string.IsNullOrEmpty(__tmp10Line))
            {
                __out.Append(__tmp10Line);
                __tmp2OutputWritten = true;
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //474:158
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //474:158
            }
            __out.Append("{"); //475:1
            __out.AppendLine(false); //475:2
            bool __tmp12OutputWritten = false;
            string __tmp11Prefix = "    "; //476:1
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(GetReturn(op));
            using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
            {
                bool __tmp13_last = __tmp13Reader.EndOfStream;
                while(!__tmp13_last)
                {
                    string __tmp13Line = __tmp13Reader.ReadLine();
                    __tmp13_last = __tmp13Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp11Prefix))
                    {
                        __out.Append(__tmp11Prefix);
                        __tmp12OutputWritten = true;
                    }
                    if (!string.IsNullOrEmpty(__tmp13Line))
                    {
                        __out.Append(__tmp13Line);
                        __tmp12OutputWritten = true;
                    }
                    if (!__tmp13_last) __out.AppendLine(true);
                }
            }
            StringBuilder __tmp14 = new StringBuilder();
            __tmp14.Append(model.CSharpFullImplementationName(ClassKind.Immutable));
            using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
            {
                bool __tmp14_last = __tmp14Reader.EndOfStream;
                while(!__tmp14_last)
                {
                    string __tmp14Line = __tmp14Reader.ReadLine();
                    __tmp14_last = __tmp14Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp14Line))
                    {
                        __out.Append(__tmp14Line);
                        __tmp12OutputWritten = true;
                    }
                    if (!__tmp14_last) __out.AppendLine(true);
                }
            }
            string __tmp15Line = "."; //476:77
            if (!string.IsNullOrEmpty(__tmp15Line))
            {
                __out.Append(__tmp15Line);
                __tmp12OutputWritten = true;
            }
            StringBuilder __tmp16 = new StringBuilder();
            __tmp16.Append(op.Parent.CSharpName());
            using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
            {
                bool __tmp16_last = __tmp16Reader.EndOfStream;
                while(!__tmp16_last)
                {
                    string __tmp16Line = __tmp16Reader.ReadLine();
                    __tmp16_last = __tmp16Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp16Line))
                    {
                        __out.Append(__tmp16Line);
                        __tmp12OutputWritten = true;
                    }
                    if (!__tmp16_last) __out.AppendLine(true);
                }
            }
            string __tmp17Line = "_"; //476:102
            if (!string.IsNullOrEmpty(__tmp17Line))
            {
                __out.Append(__tmp17Line);
                __tmp12OutputWritten = true;
            }
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append(op.Name);
            using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
            {
                bool __tmp18_last = __tmp18Reader.EndOfStream;
                while(!__tmp18_last)
                {
                    string __tmp18Line = __tmp18Reader.ReadLine();
                    __tmp18_last = __tmp18Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp18Line))
                    {
                        __out.Append(__tmp18Line);
                        __tmp12OutputWritten = true;
                    }
                    if (!__tmp18_last) __out.AppendLine(true);
                }
            }
            string __tmp19Line = "("; //476:112
            if (!string.IsNullOrEmpty(__tmp19Line))
            {
                __out.Append(__tmp19Line);
                __tmp12OutputWritten = true;
            }
            StringBuilder __tmp20 = new StringBuilder();
            __tmp20.Append(GetImplCallParameterNames(op));
            using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
            {
                bool __tmp20_last = __tmp20Reader.EndOfStream;
                while(!__tmp20_last)
                {
                    string __tmp20Line = __tmp20Reader.ReadLine();
                    __tmp20_last = __tmp20Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp20Line))
                    {
                        __out.Append(__tmp20Line);
                        __tmp12OutputWritten = true;
                    }
                    if (!__tmp20_last) __out.AppendLine(true);
                }
            }
            string __tmp21Line = ");"; //476:144
            if (!string.IsNullOrEmpty(__tmp21Line))
            {
                __out.Append(__tmp21Line);
                __tmp12OutputWritten = true;
            }
            if (__tmp12OutputWritten)
            {
                __out.AppendLine(false); //476:146
            }
            if (__tmp12OutputWritten)
            {
                __out.AppendLine(false); //476:146
            }
            __out.Append("}"); //477:1
            __out.AppendLine(false); //477:2
            return __out.ToString();
        }

        public string GetSuperClasses(MetaClass cls) //480:1
        {
            string result = ""; //481:2
            var __loop32_results = 
                (from __loop32_var1 in __Enumerate((cls).GetEnumerator()) //482:10
                from sup in __Enumerate((__loop32_var1.SuperClasses).GetEnumerator()) //482:15
                select new { __loop32_var1 = __loop32_var1, sup = sup}
                ).ToList(); //482:5
            for (int __loop32_iteration = 0; __loop32_iteration < __loop32_results.Count; ++__loop32_iteration)
            {
                string delim; //482:31
                if (__loop32_iteration+1 < __loop32_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop32_results[__loop32_iteration];
                var __loop32_var1 = __tmp1.__loop32_var1;
                var sup = __tmp1.sup;
                result += sup.CSharpFullName() + delim; //483:3
            }
            return result; //485:2
        }

        public string GetAllSuperClasses(MetaClass cls) //488:1
        {
            string result = ""; //489:2
            var __loop33_results = 
                (from __loop33_var1 in __Enumerate((cls).GetEnumerator()) //490:10
                from sup in __Enumerate((__loop33_var1.GetAllSuperClasses(false)).GetEnumerator()) //490:15
                select new { __loop33_var1 = __loop33_var1, sup = sup}
                ).ToList(); //490:5
            for (int __loop33_iteration = 0; __loop33_iteration < __loop33_results.Count; ++__loop33_iteration)
            {
                string delim; //490:44
                if (__loop33_iteration+1 < __loop33_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop33_results[__loop33_iteration];
                var __loop33_var1 = __tmp1.__loop33_var1;
                var sup = __tmp1.sup;
                result += sup.CSharpFullName() + delim; //491:3
            }
            return result; //493:2
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //496:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2OutputWritten = false;
            string __tmp3Line = "public static class "; //497:1
            if (!string.IsNullOrEmpty(__tmp3Line))
            {
                __out.Append(__tmp3Line);
                __tmp2OutputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(model.CSharpDescriptorName());
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4Line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp4Line))
                    {
                        __out.Append(__tmp4Line);
                        __tmp2OutputWritten = true;
                    }
                    if (__tmp2OutputWritten)
                    {
                        __out.AppendLine(false); //497:51
                    }
                }
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //497:51
            }
            __out.Append("{"); //498:1
            __out.AppendLine(false); //498:2
            __out.Append("    private static global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty> properties;"); //499:1
            __out.AppendLine(false); //499:118
            __out.AppendLine(true); //500:1
            bool __tmp6OutputWritten = false;
            string __tmp7Line = "    static "; //501:1
            if (!string.IsNullOrEmpty(__tmp7Line))
            {
                __out.Append(__tmp7Line);
                __tmp6OutputWritten = true;
            }
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(model.CSharpDescriptorName());
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(!__tmp8_last)
                {
                    string __tmp8Line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp8Line))
                    {
                        __out.Append(__tmp8Line);
                        __tmp6OutputWritten = true;
                    }
                    if (!__tmp8_last) __out.AppendLine(true);
                }
            }
            string __tmp9Line = "()"; //501:42
            if (!string.IsNullOrEmpty(__tmp9Line))
            {
                __out.Append(__tmp9Line);
                __tmp6OutputWritten = true;
            }
            if (__tmp6OutputWritten)
            {
                __out.AppendLine(false); //501:44
            }
            if (__tmp6OutputWritten)
            {
                __out.AppendLine(false); //501:44
            }
            __out.Append("    {"); //502:1
            __out.AppendLine(false); //502:6
            __out.Append("        MetaDescriptor.properties = new global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty>();"); //503:1
            __out.AppendLine(false); //503:130
            __out.Append("		global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty> properties = new global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty>();"); //504:1
            __out.AppendLine(false); //504:196
            var __loop34_results = 
                (from __loop34_var1 in __Enumerate((model).GetEnumerator()) //505:11
                from Namespace in __Enumerate((__loop34_var1.Namespace).GetEnumerator()) //505:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //505:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //505:43
                from prop in __Enumerate((cls.Properties).GetEnumerator()) //505:66
                select new { __loop34_var1 = __loop34_var1, Namespace = Namespace, Declarations = Declarations, cls = cls, prop = prop}
                ).ToList(); //505:6
            for (int __loop34_iteration = 0; __loop34_iteration < __loop34_results.Count; ++__loop34_iteration)
            {
                var __tmp10 = __loop34_results[__loop34_iteration];
                var __loop34_var1 = __tmp10.__loop34_var1;
                var Namespace = __tmp10.Namespace;
                var Declarations = __tmp10.Declarations;
                var cls = __tmp10.cls;
                var prop = __tmp10.prop;
                bool __tmp12OutputWritten = false;
                string __tmp13Line = "        properties.Add("; //506:1
                if (!string.IsNullOrEmpty(__tmp13Line))
                {
                    __out.Append(__tmp13Line);
                    __tmp12OutputWritten = true;
                }
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(cls.CSharpName());
                using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
                {
                    bool __tmp14_last = __tmp14Reader.EndOfStream;
                    while(!__tmp14_last)
                    {
                        string __tmp14Line = __tmp14Reader.ReadLine();
                        __tmp14_last = __tmp14Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp14Line))
                        {
                            __out.Append(__tmp14Line);
                            __tmp12OutputWritten = true;
                        }
                        if (!__tmp14_last) __out.AppendLine(true);
                    }
                }
                string __tmp15Line = "."; //506:42
                if (!string.IsNullOrEmpty(__tmp15Line))
                {
                    __out.Append(__tmp15Line);
                    __tmp12OutputWritten = true;
                }
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(prop.Name);
                using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
                {
                    bool __tmp16_last = __tmp16Reader.EndOfStream;
                    while(!__tmp16_last)
                    {
                        string __tmp16Line = __tmp16Reader.ReadLine();
                        __tmp16_last = __tmp16Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp16Line))
                        {
                            __out.Append(__tmp16Line);
                            __tmp12OutputWritten = true;
                        }
                        if (!__tmp16_last) __out.AppendLine(true);
                    }
                }
                string __tmp17Line = "Property);"; //506:54
                if (!string.IsNullOrEmpty(__tmp17Line))
                {
                    __out.Append(__tmp17Line);
                    __tmp12OutputWritten = true;
                }
                if (__tmp12OutputWritten)
                {
                    __out.AppendLine(false); //506:64
                }
                if (__tmp12OutputWritten)
                {
                    __out.AppendLine(false); //506:64
                }
            }
            __out.Append("    }"); //508:1
            __out.AppendLine(false); //508:6
            __out.AppendLine(true); //509:1
            __out.Append("    public static void Initialize()"); //510:1
            __out.AppendLine(false); //510:36
            __out.Append("    {"); //511:1
            __out.AppendLine(false); //511:6
            __out.Append("    }"); //513:1
            __out.AppendLine(false); //513:6
            __out.AppendLine(true); //514:1
            bool __tmp19OutputWritten = false;
            string __tmp20Line = "	public const string Uri = \""; //515:1
            if (!string.IsNullOrEmpty(__tmp20Line))
            {
                __out.Append(__tmp20Line);
                __tmp19OutputWritten = true;
            }
            StringBuilder __tmp21 = new StringBuilder();
            __tmp21.Append(model.Uri);
            using(StreamReader __tmp21Reader = new StreamReader(this.__ToStream(__tmp21.ToString())))
            {
                bool __tmp21_last = __tmp21Reader.EndOfStream;
                while(!__tmp21_last)
                {
                    string __tmp21Line = __tmp21Reader.ReadLine();
                    __tmp21_last = __tmp21Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp21Line))
                    {
                        __out.Append(__tmp21Line);
                        __tmp19OutputWritten = true;
                    }
                    if (!__tmp21_last) __out.AppendLine(true);
                }
            }
            string __tmp22Line = "\";"; //515:40
            if (!string.IsNullOrEmpty(__tmp22Line))
            {
                __out.Append(__tmp22Line);
                __tmp19OutputWritten = true;
            }
            if (__tmp19OutputWritten)
            {
                __out.AppendLine(false); //515:42
            }
            if (__tmp19OutputWritten)
            {
                __out.AppendLine(false); //515:42
            }
            __out.AppendLine(true); //516:1
            var __loop35_results = 
                (from __loop35_var1 in __Enumerate((model).GetEnumerator()) //517:11
                from Namespace in __Enumerate((__loop35_var1.Namespace).GetEnumerator()) //517:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //517:29
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //517:43
                select new { __loop35_var1 = __loop35_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //517:6
            for (int __loop35_iteration = 0; __loop35_iteration < __loop35_results.Count; ++__loop35_iteration)
            {
                var __tmp23 = __loop35_results[__loop35_iteration];
                var __loop35_var1 = __tmp23.__loop35_var1;
                var Namespace = __tmp23.Namespace;
                var Declarations = __tmp23.Declarations;
                var cls = __tmp23.cls;
                bool __tmp25OutputWritten = false;
                string __tmp24Prefix = "    "; //518:1
                StringBuilder __tmp26 = new StringBuilder();
                __tmp26.Append(GenerateMetaModelClass(cls));
                using(StreamReader __tmp26Reader = new StreamReader(this.__ToStream(__tmp26.ToString())))
                {
                    bool __tmp26_last = __tmp26Reader.EndOfStream;
                    while(!__tmp26_last)
                    {
                        string __tmp26Line = __tmp26Reader.ReadLine();
                        __tmp26_last = __tmp26Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp24Prefix))
                        {
                            __out.Append(__tmp24Prefix);
                            __tmp25OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp26Line))
                        {
                            __out.Append(__tmp26Line);
                            __tmp25OutputWritten = true;
                        }
                        if (__tmp25OutputWritten)
                        {
                            __out.AppendLine(false); //518:34
                        }
                    }
                }
                if (__tmp25OutputWritten)
                {
                    __out.AppendLine(false); //518:34
                }
            }
            __out.Append("}"); //520:1
            __out.AppendLine(false); //520:2
            __out.AppendLine(true); //521:1
            return __out.ToString();
        }

        public string GenerateMetaModelClass(MetaClass cls) //525:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //526:1
            if (cls.SuperClasses.Count > 0) //527:2
            {
                bool __tmp2OutputWritten = false;
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append("[ModelSymbolDecriptor(");
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_last = __tmp3Reader.EndOfStream;
                    while(!__tmp3_last)
                    {
                        string __tmp3Line = __tmp3Reader.ReadLine();
                        __tmp3_last = __tmp3Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp3Line))
                        {
                            __out.Append(__tmp3Line);
                            __tmp2OutputWritten = true;
                        }
                        if (!__tmp3_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append(GetDescriptorAncestors(cls));
                using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                {
                    bool __tmp4_last = __tmp4Reader.EndOfStream;
                    while(!__tmp4_last)
                    {
                        string __tmp4Line = __tmp4Reader.ReadLine();
                        __tmp4_last = __tmp4Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp4Line))
                        {
                            __out.Append(__tmp4Line);
                            __tmp2OutputWritten = true;
                        }
                        if (!__tmp4_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(")]");
                using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                {
                    bool __tmp5_last = __tmp5Reader.EndOfStream;
                    while(!__tmp5_last)
                    {
                        string __tmp5Line = __tmp5Reader.ReadLine();
                        __tmp5_last = __tmp5Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp5Line))
                        {
                            __out.Append(__tmp5Line);
                            __tmp2OutputWritten = true;
                        }
                        if (__tmp2OutputWritten)
                        {
                            __out.AppendLine(false); //528:62
                        }
                    }
                }
                if (__tmp2OutputWritten)
                {
                    __out.AppendLine(false); //528:62
                }
            }
            else //529:2
            {
                bool __tmp7OutputWritten = false;
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append("[ModelSymbolDecriptor]");
                using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                {
                    bool __tmp8_last = __tmp8Reader.EndOfStream;
                    while(!__tmp8_last)
                    {
                        string __tmp8Line = __tmp8Reader.ReadLine();
                        __tmp8_last = __tmp8Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp8Line))
                        {
                            __out.Append(__tmp8Line);
                            __tmp7OutputWritten = true;
                        }
                        if (__tmp7OutputWritten)
                        {
                            __out.AppendLine(false); //530:27
                        }
                    }
                }
                if (__tmp7OutputWritten)
                {
                    __out.AppendLine(false); //530:27
                }
            }
            bool __tmp10OutputWritten = false;
            string __tmp11Line = "public static class "; //532:1
            if (!string.IsNullOrEmpty(__tmp11Line))
            {
                __out.Append(__tmp11Line);
                __tmp10OutputWritten = true;
            }
            StringBuilder __tmp12 = new StringBuilder();
            __tmp12.Append(cls.CSharpName());
            using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
            {
                bool __tmp12_last = __tmp12Reader.EndOfStream;
                while(!__tmp12_last)
                {
                    string __tmp12Line = __tmp12Reader.ReadLine();
                    __tmp12_last = __tmp12Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp12Line))
                    {
                        __out.Append(__tmp12Line);
                        __tmp10OutputWritten = true;
                    }
                    if (__tmp10OutputWritten)
                    {
                        __out.AppendLine(false); //532:39
                    }
                }
            }
            if (__tmp10OutputWritten)
            {
                __out.AppendLine(false); //532:39
            }
            __out.Append("{"); //533:1
            __out.AppendLine(false); //533:2
            bool __tmp14OutputWritten = false;
            string __tmp15Line = "    static "; //534:1
            if (!string.IsNullOrEmpty(__tmp15Line))
            {
                __out.Append(__tmp15Line);
                __tmp14OutputWritten = true;
            }
            StringBuilder __tmp16 = new StringBuilder();
            __tmp16.Append(cls.CSharpName());
            using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
            {
                bool __tmp16_last = __tmp16Reader.EndOfStream;
                while(!__tmp16_last)
                {
                    string __tmp16Line = __tmp16Reader.ReadLine();
                    __tmp16_last = __tmp16Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp16Line))
                    {
                        __out.Append(__tmp16Line);
                        __tmp14OutputWritten = true;
                    }
                    if (!__tmp16_last) __out.AppendLine(true);
                }
            }
            string __tmp17Line = "()"; //534:30
            if (!string.IsNullOrEmpty(__tmp17Line))
            {
                __out.Append(__tmp17Line);
                __tmp14OutputWritten = true;
            }
            if (__tmp14OutputWritten)
            {
                __out.AppendLine(false); //534:32
            }
            if (__tmp14OutputWritten)
            {
                __out.AppendLine(false); //534:32
            }
            __out.Append("    {"); //535:1
            __out.AppendLine(false); //535:6
            bool __tmp19OutputWritten = false;
            string __tmp18Prefix = "        "; //536:1
            StringBuilder __tmp20 = new StringBuilder();
            __tmp20.Append(cls.CSharpName());
            using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
            {
                bool __tmp20_last = __tmp20Reader.EndOfStream;
                while(!__tmp20_last)
                {
                    string __tmp20Line = __tmp20Reader.ReadLine();
                    __tmp20_last = __tmp20Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp18Prefix))
                    {
                        __out.Append(__tmp18Prefix);
                        __tmp19OutputWritten = true;
                    }
                    if (!string.IsNullOrEmpty(__tmp20Line))
                    {
                        __out.Append(__tmp20Line);
                        __tmp19OutputWritten = true;
                    }
                    if (!__tmp20_last) __out.AppendLine(true);
                }
            }
            string __tmp21Line = ".ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof("; //536:27
            if (!string.IsNullOrEmpty(__tmp21Line))
            {
                __out.Append(__tmp21Line);
                __tmp19OutputWritten = true;
            }
            StringBuilder __tmp22 = new StringBuilder();
            __tmp22.Append(cls.CSharpName());
            using(StreamReader __tmp22Reader = new StreamReader(this.__ToStream(__tmp22.ToString())))
            {
                bool __tmp22_last = __tmp22Reader.EndOfStream;
                while(!__tmp22_last)
                {
                    string __tmp22Line = __tmp22Reader.ReadLine();
                    __tmp22_last = __tmp22Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp22Line))
                    {
                        __out.Append(__tmp22Line);
                        __tmp19OutputWritten = true;
                    }
                    if (!__tmp22_last) __out.AppendLine(true);
                }
            }
            string __tmp23Line = "));"; //536:133
            if (!string.IsNullOrEmpty(__tmp23Line))
            {
                __out.Append(__tmp23Line);
                __tmp19OutputWritten = true;
            }
            if (__tmp19OutputWritten)
            {
                __out.AppendLine(false); //536:136
            }
            if (__tmp19OutputWritten)
            {
                __out.AppendLine(false); //536:136
            }
            __out.Append("    }"); //537:1
            __out.AppendLine(false); //537:6
            __out.AppendLine(true); //538:1
            __out.Append("    public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }"); //539:1
            __out.AppendLine(false); //539:91
            __out.AppendLine(true); //540:1
            if (cls.CSharpName() == "MetaClass") //541:2
            {
                __out.Append("    public static global::MetaDslx.Core.Immutable.MetaClass _MetaClass"); //542:1
                __out.AppendLine(false); //542:71
            }
            else //543:2
            {
                __out.Append("    public static global::MetaDslx.Core.Immutable.MetaClass MetaClass"); //544:1
                __out.AppendLine(false); //544:70
            }
            __out.Append("    {"); //546:1
            __out.AppendLine(false); //546:6
            bool __tmp25OutputWritten = false;
            string __tmp26Line = "        get { return null;/*"; //547:1
            if (!string.IsNullOrEmpty(__tmp26Line))
            {
                __out.Append(__tmp26Line);
                __tmp25OutputWritten = true;
            }
            StringBuilder __tmp27 = new StringBuilder();
            __tmp27.Append(cls.CSharpFullInstanceName());
            using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
            {
                bool __tmp27_last = __tmp27Reader.EndOfStream;
                while(!__tmp27_last)
                {
                    string __tmp27Line = __tmp27Reader.ReadLine();
                    __tmp27_last = __tmp27Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp27Line))
                    {
                        __out.Append(__tmp27Line);
                        __tmp25OutputWritten = true;
                    }
                    if (!__tmp27_last) __out.AppendLine(true);
                }
            }
            string __tmp28Line = ";*/ }"; //547:59
            if (!string.IsNullOrEmpty(__tmp28Line))
            {
                __out.Append(__tmp28Line);
                __tmp25OutputWritten = true;
            }
            if (__tmp25OutputWritten)
            {
                __out.AppendLine(false); //547:64
            }
            if (__tmp25OutputWritten)
            {
                __out.AppendLine(false); //547:64
            }
            __out.Append("    }"); //548:1
            __out.AppendLine(false); //548:6
            __out.AppendLine(true); //549:1
            var __loop36_results = 
                (from __loop36_var1 in __Enumerate((cls).GetEnumerator()) //550:11
                from prop in __Enumerate((__loop36_var1.Properties).GetEnumerator()) //550:16
                select new { __loop36_var1 = __loop36_var1, prop = prop}
                ).ToList(); //550:6
            for (int __loop36_iteration = 0; __loop36_iteration < __loop36_results.Count; ++__loop36_iteration)
            {
                var __tmp29 = __loop36_results[__loop36_iteration];
                var __loop36_var1 = __tmp29.__loop36_var1;
                var prop = __tmp29.prop;
                bool __tmp31OutputWritten = false;
                string __tmp30Prefix = "    "; //551:1
                StringBuilder __tmp32 = new StringBuilder();
                __tmp32.Append(GeneratePropertyDeclaration(cls.Model, cls, prop));
                using(StreamReader __tmp32Reader = new StreamReader(this.__ToStream(__tmp32.ToString())))
                {
                    bool __tmp32_last = __tmp32Reader.EndOfStream;
                    while(!__tmp32_last)
                    {
                        string __tmp32Line = __tmp32Reader.ReadLine();
                        __tmp32_last = __tmp32Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp30Prefix))
                        {
                            __out.Append(__tmp30Prefix);
                            __tmp31OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp32Line))
                        {
                            __out.Append(__tmp32Line);
                            __tmp31OutputWritten = true;
                        }
                        if (__tmp31OutputWritten)
                        {
                            __out.AppendLine(false); //551:56
                        }
                    }
                }
                if (__tmp31OutputWritten)
                {
                    __out.AppendLine(false); //551:56
                }
            }
            __out.Append("}"); //553:1
            __out.AppendLine(false); //553:2
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //556:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2OutputWritten = false;
            string __tmp3Line = "internal static class "; //557:1
            if (!string.IsNullOrEmpty(__tmp3Line))
            {
                __out.Append(__tmp3Line);
                __tmp2OutputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(model.Name);
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4Line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp4Line))
                    {
                        __out.Append(__tmp4Line);
                        __tmp2OutputWritten = true;
                    }
                    if (!__tmp4_last) __out.AppendLine(true);
                }
            }
            string __tmp5Line = "ImplementationProvider"; //557:35
            if (!string.IsNullOrEmpty(__tmp5Line))
            {
                __out.Append(__tmp5Line);
                __tmp2OutputWritten = true;
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //557:57
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //557:57
            }
            __out.Append("{"); //558:1
            __out.AppendLine(false); //558:2
            bool __tmp7OutputWritten = false;
            string __tmp8Line = "    // If there is a compile error at this line, create a new class called "; //559:1
            if (!string.IsNullOrEmpty(__tmp8Line))
            {
                __out.Append(__tmp8Line);
                __tmp7OutputWritten = true;
            }
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(model.Name);
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_last = __tmp9Reader.EndOfStream;
                while(!__tmp9_last)
                {
                    string __tmp9Line = __tmp9Reader.ReadLine();
                    __tmp9_last = __tmp9Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp9Line))
                    {
                        __out.Append(__tmp9Line);
                        __tmp7OutputWritten = true;
                    }
                    if (!__tmp9_last) __out.AppendLine(true);
                }
            }
            string __tmp10Line = "Implementation"; //559:88
            if (!string.IsNullOrEmpty(__tmp10Line))
            {
                __out.Append(__tmp10Line);
                __tmp7OutputWritten = true;
            }
            if (__tmp7OutputWritten)
            {
                __out.AppendLine(false); //559:102
            }
            if (__tmp7OutputWritten)
            {
                __out.AppendLine(false); //559:102
            }
            bool __tmp12OutputWritten = false;
            string __tmp13Line = "	// which is a subclass of "; //560:1
            if (!string.IsNullOrEmpty(__tmp13Line))
            {
                __out.Append(__tmp13Line);
                __tmp12OutputWritten = true;
            }
            StringBuilder __tmp14 = new StringBuilder();
            __tmp14.Append(model.Name);
            using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
            {
                bool __tmp14_last = __tmp14Reader.EndOfStream;
                while(!__tmp14_last)
                {
                    string __tmp14Line = __tmp14Reader.ReadLine();
                    __tmp14_last = __tmp14Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp14Line))
                    {
                        __out.Append(__tmp14Line);
                        __tmp12OutputWritten = true;
                    }
                    if (!__tmp14_last) __out.AppendLine(true);
                }
            }
            string __tmp15Line = "ImplementationBase:"; //560:40
            if (!string.IsNullOrEmpty(__tmp15Line))
            {
                __out.Append(__tmp15Line);
                __tmp12OutputWritten = true;
            }
            if (__tmp12OutputWritten)
            {
                __out.AppendLine(false); //560:59
            }
            if (__tmp12OutputWritten)
            {
                __out.AppendLine(false); //560:59
            }
            bool __tmp17OutputWritten = false;
            string __tmp18Line = "    private static "; //561:1
            if (!string.IsNullOrEmpty(__tmp18Line))
            {
                __out.Append(__tmp18Line);
                __tmp17OutputWritten = true;
            }
            StringBuilder __tmp19 = new StringBuilder();
            __tmp19.Append(model.Name);
            using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
            {
                bool __tmp19_last = __tmp19Reader.EndOfStream;
                while(!__tmp19_last)
                {
                    string __tmp19Line = __tmp19Reader.ReadLine();
                    __tmp19_last = __tmp19Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp19Line))
                    {
                        __out.Append(__tmp19Line);
                        __tmp17OutputWritten = true;
                    }
                    if (!__tmp19_last) __out.AppendLine(true);
                }
            }
            string __tmp20Line = "Implementation implementation = new "; //561:32
            if (!string.IsNullOrEmpty(__tmp20Line))
            {
                __out.Append(__tmp20Line);
                __tmp17OutputWritten = true;
            }
            StringBuilder __tmp21 = new StringBuilder();
            __tmp21.Append(model.Name);
            using(StreamReader __tmp21Reader = new StreamReader(this.__ToStream(__tmp21.ToString())))
            {
                bool __tmp21_last = __tmp21Reader.EndOfStream;
                while(!__tmp21_last)
                {
                    string __tmp21Line = __tmp21Reader.ReadLine();
                    __tmp21_last = __tmp21Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp21Line))
                    {
                        __out.Append(__tmp21Line);
                        __tmp17OutputWritten = true;
                    }
                    if (!__tmp21_last) __out.AppendLine(true);
                }
            }
            string __tmp22Line = "Implementation();"; //561:80
            if (!string.IsNullOrEmpty(__tmp22Line))
            {
                __out.Append(__tmp22Line);
                __tmp17OutputWritten = true;
            }
            if (__tmp17OutputWritten)
            {
                __out.AppendLine(false); //561:97
            }
            if (__tmp17OutputWritten)
            {
                __out.AppendLine(false); //561:97
            }
            __out.AppendLine(true); //562:1
            bool __tmp24OutputWritten = false;
            string __tmp25Line = "    public static "; //563:1
            if (!string.IsNullOrEmpty(__tmp25Line))
            {
                __out.Append(__tmp25Line);
                __tmp24OutputWritten = true;
            }
            StringBuilder __tmp26 = new StringBuilder();
            __tmp26.Append(model.Name);
            using(StreamReader __tmp26Reader = new StreamReader(this.__ToStream(__tmp26.ToString())))
            {
                bool __tmp26_last = __tmp26Reader.EndOfStream;
                while(!__tmp26_last)
                {
                    string __tmp26Line = __tmp26Reader.ReadLine();
                    __tmp26_last = __tmp26Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp26Line))
                    {
                        __out.Append(__tmp26Line);
                        __tmp24OutputWritten = true;
                    }
                    if (!__tmp26_last) __out.AppendLine(true);
                }
            }
            string __tmp27Line = "Implementation Implementation"; //563:31
            if (!string.IsNullOrEmpty(__tmp27Line))
            {
                __out.Append(__tmp27Line);
                __tmp24OutputWritten = true;
            }
            if (__tmp24OutputWritten)
            {
                __out.AppendLine(false); //563:60
            }
            if (__tmp24OutputWritten)
            {
                __out.AppendLine(false); //563:60
            }
            __out.Append("    {"); //564:1
            __out.AppendLine(false); //564:6
            bool __tmp29OutputWritten = false;
            string __tmp30Line = "        get { return "; //565:1
            if (!string.IsNullOrEmpty(__tmp30Line))
            {
                __out.Append(__tmp30Line);
                __tmp29OutputWritten = true;
            }
            StringBuilder __tmp31 = new StringBuilder();
            __tmp31.Append(model.Name);
            using(StreamReader __tmp31Reader = new StreamReader(this.__ToStream(__tmp31.ToString())))
            {
                bool __tmp31_last = __tmp31Reader.EndOfStream;
                while(!__tmp31_last)
                {
                    string __tmp31Line = __tmp31Reader.ReadLine();
                    __tmp31_last = __tmp31Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp31Line))
                    {
                        __out.Append(__tmp31Line);
                        __tmp29OutputWritten = true;
                    }
                    if (!__tmp31_last) __out.AppendLine(true);
                }
            }
            string __tmp32Line = "ImplementationProvider.implementation; }"; //565:34
            if (!string.IsNullOrEmpty(__tmp32Line))
            {
                __out.Append(__tmp32Line);
                __tmp29OutputWritten = true;
            }
            if (__tmp29OutputWritten)
            {
                __out.AppendLine(false); //565:74
            }
            if (__tmp29OutputWritten)
            {
                __out.AppendLine(false); //565:74
            }
            __out.Append("    }"); //566:1
            __out.AppendLine(false); //566:6
            __out.Append("}"); //567:1
            __out.AppendLine(false); //567:2
            var __loop37_results = 
                (from __loop37_var1 in __Enumerate((model).GetEnumerator()) //568:8
                from Namespace in __Enumerate((__loop37_var1.Namespace).GetEnumerator()) //568:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //568:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //568:40
                select new { __loop37_var1 = __loop37_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //568:3
            for (int __loop37_iteration = 0; __loop37_iteration < __loop37_results.Count; ++__loop37_iteration)
            {
                var __tmp33 = __loop37_results[__loop37_iteration];
                var __loop37_var1 = __tmp33.__loop37_var1;
                var Namespace = __tmp33.Namespace;
                var Declarations = __tmp33.Declarations;
                var enm = __tmp33.enm;
                __out.AppendLine(true); //569:1
                bool __tmp35OutputWritten = false;
                string __tmp36Line = "public static class "; //570:1
                if (!string.IsNullOrEmpty(__tmp36Line))
                {
                    __out.Append(__tmp36Line);
                    __tmp35OutputWritten = true;
                }
                StringBuilder __tmp37 = new StringBuilder();
                __tmp37.Append(enm.Name);
                using(StreamReader __tmp37Reader = new StreamReader(this.__ToStream(__tmp37.ToString())))
                {
                    bool __tmp37_last = __tmp37Reader.EndOfStream;
                    while(!__tmp37_last)
                    {
                        string __tmp37Line = __tmp37Reader.ReadLine();
                        __tmp37_last = __tmp37Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp37Line))
                        {
                            __out.Append(__tmp37Line);
                            __tmp35OutputWritten = true;
                        }
                        if (!__tmp37_last) __out.AppendLine(true);
                    }
                }
                string __tmp38Line = "Extensions"; //570:31
                if (!string.IsNullOrEmpty(__tmp38Line))
                {
                    __out.Append(__tmp38Line);
                    __tmp35OutputWritten = true;
                }
                if (__tmp35OutputWritten)
                {
                    __out.AppendLine(false); //570:41
                }
                if (__tmp35OutputWritten)
                {
                    __out.AppendLine(false); //570:41
                }
                __out.Append("{"); //571:1
                __out.AppendLine(false); //571:2
                var __loop38_results = 
                    (from __loop38_var1 in __Enumerate((enm).GetEnumerator()) //572:11
                    from op in __Enumerate((__loop38_var1.Operations).GetEnumerator()) //572:16
                    select new { __loop38_var1 = __loop38_var1, op = op}
                    ).ToList(); //572:6
                for (int __loop38_iteration = 0; __loop38_iteration < __loop38_results.Count; ++__loop38_iteration)
                {
                    var __tmp39 = __loop38_results[__loop38_iteration];
                    var __loop38_var1 = __tmp39.__loop38_var1;
                    var op = __tmp39.op;
                    bool __tmp41OutputWritten = false;
                    string __tmp42Line = "    public static "; //573:1
                    if (!string.IsNullOrEmpty(__tmp42Line))
                    {
                        __out.Append(__tmp42Line);
                        __tmp41OutputWritten = true;
                    }
                    StringBuilder __tmp43 = new StringBuilder();
                    __tmp43.Append(op.ReturnType.CSharpFullPublicName(ClassKind.Immutable));
                    using(StreamReader __tmp43Reader = new StreamReader(this.__ToStream(__tmp43.ToString())))
                    {
                        bool __tmp43_last = __tmp43Reader.EndOfStream;
                        while(!__tmp43_last)
                        {
                            string __tmp43Line = __tmp43Reader.ReadLine();
                            __tmp43_last = __tmp43Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp43Line))
                            {
                                __out.Append(__tmp43Line);
                                __tmp41OutputWritten = true;
                            }
                            if (!__tmp43_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp44Line = " "; //573:76
                    if (!string.IsNullOrEmpty(__tmp44Line))
                    {
                        __out.Append(__tmp44Line);
                        __tmp41OutputWritten = true;
                    }
                    StringBuilder __tmp45 = new StringBuilder();
                    __tmp45.Append(op.Name);
                    using(StreamReader __tmp45Reader = new StreamReader(this.__ToStream(__tmp45.ToString())))
                    {
                        bool __tmp45_last = __tmp45Reader.EndOfStream;
                        while(!__tmp45_last)
                        {
                            string __tmp45Line = __tmp45Reader.ReadLine();
                            __tmp45_last = __tmp45Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp45Line))
                            {
                                __out.Append(__tmp45Line);
                                __tmp41OutputWritten = true;
                            }
                            if (!__tmp45_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp46Line = "("; //573:86
                    if (!string.IsNullOrEmpty(__tmp46Line))
                    {
                        __out.Append(__tmp46Line);
                        __tmp41OutputWritten = true;
                    }
                    StringBuilder __tmp47 = new StringBuilder();
                    __tmp47.Append(GetEnumImplParameters(enm, op));
                    using(StreamReader __tmp47Reader = new StreamReader(this.__ToStream(__tmp47.ToString())))
                    {
                        bool __tmp47_last = __tmp47Reader.EndOfStream;
                        while(!__tmp47_last)
                        {
                            string __tmp47Line = __tmp47Reader.ReadLine();
                            __tmp47_last = __tmp47Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp47Line))
                            {
                                __out.Append(__tmp47Line);
                                __tmp41OutputWritten = true;
                            }
                            if (!__tmp47_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp48Line = ")"; //573:119
                    if (!string.IsNullOrEmpty(__tmp48Line))
                    {
                        __out.Append(__tmp48Line);
                        __tmp41OutputWritten = true;
                    }
                    if (__tmp41OutputWritten)
                    {
                        __out.AppendLine(false); //573:120
                    }
                    if (__tmp41OutputWritten)
                    {
                        __out.AppendLine(false); //573:120
                    }
                    __out.Append("    {"); //574:1
                    __out.AppendLine(false); //574:6
                    bool __tmp50OutputWritten = false;
                    string __tmp49Prefix = "        "; //575:1
                    StringBuilder __tmp51 = new StringBuilder();
                    __tmp51.Append(GetReturn(op));
                    using(StreamReader __tmp51Reader = new StreamReader(this.__ToStream(__tmp51.ToString())))
                    {
                        bool __tmp51_last = __tmp51Reader.EndOfStream;
                        while(!__tmp51_last)
                        {
                            string __tmp51Line = __tmp51Reader.ReadLine();
                            __tmp51_last = __tmp51Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp49Prefix))
                            {
                                __out.Append(__tmp49Prefix);
                                __tmp50OutputWritten = true;
                            }
                            if (!string.IsNullOrEmpty(__tmp51Line))
                            {
                                __out.Append(__tmp51Line);
                                __tmp50OutputWritten = true;
                            }
                            if (!__tmp51_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp52 = new StringBuilder();
                    __tmp52.Append(model.Name);
                    using(StreamReader __tmp52Reader = new StreamReader(this.__ToStream(__tmp52.ToString())))
                    {
                        bool __tmp52_last = __tmp52Reader.EndOfStream;
                        while(!__tmp52_last)
                        {
                            string __tmp52Line = __tmp52Reader.ReadLine();
                            __tmp52_last = __tmp52Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp52Line))
                            {
                                __out.Append(__tmp52Line);
                                __tmp50OutputWritten = true;
                            }
                            if (!__tmp52_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp53Line = "ImplementationProvider.Implementation."; //575:36
                    if (!string.IsNullOrEmpty(__tmp53Line))
                    {
                        __out.Append(__tmp53Line);
                        __tmp50OutputWritten = true;
                    }
                    StringBuilder __tmp54 = new StringBuilder();
                    __tmp54.Append(op.Parent.CSharpName());
                    using(StreamReader __tmp54Reader = new StreamReader(this.__ToStream(__tmp54.ToString())))
                    {
                        bool __tmp54_last = __tmp54Reader.EndOfStream;
                        while(!__tmp54_last)
                        {
                            string __tmp54Line = __tmp54Reader.ReadLine();
                            __tmp54_last = __tmp54Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp54Line))
                            {
                                __out.Append(__tmp54Line);
                                __tmp50OutputWritten = true;
                            }
                            if (!__tmp54_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp55Line = "_"; //575:98
                    if (!string.IsNullOrEmpty(__tmp55Line))
                    {
                        __out.Append(__tmp55Line);
                        __tmp50OutputWritten = true;
                    }
                    StringBuilder __tmp56 = new StringBuilder();
                    __tmp56.Append(op.Name);
                    using(StreamReader __tmp56Reader = new StreamReader(this.__ToStream(__tmp56.ToString())))
                    {
                        bool __tmp56_last = __tmp56Reader.EndOfStream;
                        while(!__tmp56_last)
                        {
                            string __tmp56Line = __tmp56Reader.ReadLine();
                            __tmp56_last = __tmp56Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp56Line))
                            {
                                __out.Append(__tmp56Line);
                                __tmp50OutputWritten = true;
                            }
                            if (!__tmp56_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp57Line = "("; //575:108
                    if (!string.IsNullOrEmpty(__tmp57Line))
                    {
                        __out.Append(__tmp57Line);
                        __tmp50OutputWritten = true;
                    }
                    StringBuilder __tmp58 = new StringBuilder();
                    __tmp58.Append(GetEnumImplCallParameterNames(op));
                    using(StreamReader __tmp58Reader = new StreamReader(this.__ToStream(__tmp58.ToString())))
                    {
                        bool __tmp58_last = __tmp58Reader.EndOfStream;
                        while(!__tmp58_last)
                        {
                            string __tmp58Line = __tmp58Reader.ReadLine();
                            __tmp58_last = __tmp58Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp58Line))
                            {
                                __out.Append(__tmp58Line);
                                __tmp50OutputWritten = true;
                            }
                            if (!__tmp58_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp59Line = ");"; //575:144
                    if (!string.IsNullOrEmpty(__tmp59Line))
                    {
                        __out.Append(__tmp59Line);
                        __tmp50OutputWritten = true;
                    }
                    if (__tmp50OutputWritten)
                    {
                        __out.AppendLine(false); //575:146
                    }
                    if (__tmp50OutputWritten)
                    {
                        __out.AppendLine(false); //575:146
                    }
                    __out.Append("    }"); //576:1
                    __out.AppendLine(false); //576:6
                }
                __out.Append("}"); //578:1
                __out.AppendLine(false); //578:2
            }
            __out.AppendLine(true); //580:1
            __out.Append("/// <summary>"); //581:1
            __out.AppendLine(false); //581:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //582:1
            __out.AppendLine(false); //582:68
            bool __tmp61OutputWritten = false;
            string __tmp62Line = "/// This class has to be be overriden in "; //583:1
            if (!string.IsNullOrEmpty(__tmp62Line))
            {
                __out.Append(__tmp62Line);
                __tmp61OutputWritten = true;
            }
            StringBuilder __tmp63 = new StringBuilder();
            __tmp63.Append(model.Name);
            using(StreamReader __tmp63Reader = new StreamReader(this.__ToStream(__tmp63.ToString())))
            {
                bool __tmp63_last = __tmp63Reader.EndOfStream;
                while(!__tmp63_last)
                {
                    string __tmp63Line = __tmp63Reader.ReadLine();
                    __tmp63_last = __tmp63Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp63Line))
                    {
                        __out.Append(__tmp63Line);
                        __tmp61OutputWritten = true;
                    }
                    if (!__tmp63_last) __out.AppendLine(true);
                }
            }
            string __tmp64Line = "Implementation to provide custom"; //583:54
            if (!string.IsNullOrEmpty(__tmp64Line))
            {
                __out.Append(__tmp64Line);
                __tmp61OutputWritten = true;
            }
            if (__tmp61OutputWritten)
            {
                __out.AppendLine(false); //583:86
            }
            if (__tmp61OutputWritten)
            {
                __out.AppendLine(false); //583:86
            }
            __out.Append("/// implementation for the constructors, operations and property values."); //584:1
            __out.AppendLine(false); //584:73
            __out.Append("/// </summary>"); //585:1
            __out.AppendLine(false); //585:15
            bool __tmp66OutputWritten = false;
            string __tmp67Line = "internal abstract class "; //586:1
            if (!string.IsNullOrEmpty(__tmp67Line))
            {
                __out.Append(__tmp67Line);
                __tmp66OutputWritten = true;
            }
            StringBuilder __tmp68 = new StringBuilder();
            __tmp68.Append(model.Name);
            using(StreamReader __tmp68Reader = new StreamReader(this.__ToStream(__tmp68.ToString())))
            {
                bool __tmp68_last = __tmp68Reader.EndOfStream;
                while(!__tmp68_last)
                {
                    string __tmp68Line = __tmp68Reader.ReadLine();
                    __tmp68_last = __tmp68Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp68Line))
                    {
                        __out.Append(__tmp68Line);
                        __tmp66OutputWritten = true;
                    }
                    if (!__tmp68_last) __out.AppendLine(true);
                }
            }
            string __tmp69Line = "ImplementationBase"; //586:37
            if (!string.IsNullOrEmpty(__tmp69Line))
            {
                __out.Append(__tmp69Line);
                __tmp66OutputWritten = true;
            }
            if (__tmp66OutputWritten)
            {
                __out.AppendLine(false); //586:55
            }
            if (__tmp66OutputWritten)
            {
                __out.AppendLine(false); //586:55
            }
            __out.Append("{"); //587:1
            __out.AppendLine(false); //587:2
            bool __tmp71OutputWritten = false;
            string __tmp72Line = "	public virtual void "; //588:1
            if (!string.IsNullOrEmpty(__tmp72Line))
            {
                __out.Append(__tmp72Line);
                __tmp71OutputWritten = true;
            }
            StringBuilder __tmp73 = new StringBuilder();
            __tmp73.Append(model.CSharpInstancesName(ClassKind.Builder));
            using(StreamReader __tmp73Reader = new StreamReader(this.__ToStream(__tmp73.ToString())))
            {
                bool __tmp73_last = __tmp73Reader.EndOfStream;
                while(!__tmp73_last)
                {
                    string __tmp73Line = __tmp73Reader.ReadLine();
                    __tmp73_last = __tmp73Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp73Line))
                    {
                        __out.Append(__tmp73Line);
                        __tmp71OutputWritten = true;
                    }
                    if (!__tmp73_last) __out.AppendLine(true);
                }
            }
            string __tmp74Line = "("; //588:68
            if (!string.IsNullOrEmpty(__tmp74Line))
            {
                __out.Append(__tmp74Line);
                __tmp71OutputWritten = true;
            }
            StringBuilder __tmp75 = new StringBuilder();
            __tmp75.Append(model.CSharpInstancesName(ClassKind.Builder));
            using(StreamReader __tmp75Reader = new StreamReader(this.__ToStream(__tmp75.ToString())))
            {
                bool __tmp75_last = __tmp75Reader.EndOfStream;
                while(!__tmp75_last)
                {
                    string __tmp75Line = __tmp75Reader.ReadLine();
                    __tmp75_last = __tmp75Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp75Line))
                    {
                        __out.Append(__tmp75Line);
                        __tmp71OutputWritten = true;
                    }
                    if (!__tmp75_last) __out.AppendLine(true);
                }
            }
            string __tmp76Line = " _this)"; //588:115
            if (!string.IsNullOrEmpty(__tmp76Line))
            {
                __out.Append(__tmp76Line);
                __tmp71OutputWritten = true;
            }
            if (__tmp71OutputWritten)
            {
                __out.AppendLine(false); //588:122
            }
            if (__tmp71OutputWritten)
            {
                __out.AppendLine(false); //588:122
            }
            __out.Append("	{"); //589:1
            __out.AppendLine(false); //589:3
            __out.Append("	}"); //590:1
            __out.AppendLine(false); //590:3
            var __loop39_results = 
                (from __loop39_var1 in __Enumerate((model).GetEnumerator()) //591:8
                from Namespace in __Enumerate((__loop39_var1.Namespace).GetEnumerator()) //591:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //591:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //591:40
                select new { __loop39_var1 = __loop39_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //591:3
            for (int __loop39_iteration = 0; __loop39_iteration < __loop39_results.Count; ++__loop39_iteration)
            {
                var __tmp77 = __loop39_results[__loop39_iteration];
                var __loop39_var1 = __tmp77.__loop39_var1;
                var Namespace = __tmp77.Namespace;
                var Declarations = __tmp77.Declarations;
                var cls = __tmp77.cls;
                __out.Append("    /// <summary>"); //592:1
                __out.AppendLine(false); //592:18
                bool __tmp79OutputWritten = false;
                string __tmp80Line = "	/// Implements the constructor: "; //593:1
                if (!string.IsNullOrEmpty(__tmp80Line))
                {
                    __out.Append(__tmp80Line);
                    __tmp79OutputWritten = true;
                }
                StringBuilder __tmp81 = new StringBuilder();
                __tmp81.Append(cls.CSharpName());
                using(StreamReader __tmp81Reader = new StreamReader(this.__ToStream(__tmp81.ToString())))
                {
                    bool __tmp81_last = __tmp81Reader.EndOfStream;
                    while(!__tmp81_last)
                    {
                        string __tmp81Line = __tmp81Reader.ReadLine();
                        __tmp81_last = __tmp81Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp81Line))
                        {
                            __out.Append(__tmp81Line);
                            __tmp79OutputWritten = true;
                        }
                        if (!__tmp81_last) __out.AppendLine(true);
                    }
                }
                string __tmp82Line = "()"; //593:52
                if (!string.IsNullOrEmpty(__tmp82Line))
                {
                    __out.Append(__tmp82Line);
                    __tmp79OutputWritten = true;
                }
                if (__tmp79OutputWritten)
                {
                    __out.AppendLine(false); //593:54
                }
                if (__tmp79OutputWritten)
                {
                    __out.AppendLine(false); //593:54
                }
                __out.Append("    /// </summary>"); //594:1
                __out.AppendLine(false); //594:19
                if ((from __loop40_var1 in __Enumerate((cls).GetEnumerator()) //595:15
                from sup in __Enumerate((__loop40_var1.SuperClasses).GetEnumerator()) //595:20
                select new { __loop40_var1 = __loop40_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //595:3
                {
                    bool __tmp84OutputWritten = false;
                    string __tmp85Line = "	/// Direct superclasses: "; //596:1
                    if (!string.IsNullOrEmpty(__tmp85Line))
                    {
                        __out.Append(__tmp85Line);
                        __tmp84OutputWritten = true;
                    }
                    StringBuilder __tmp86 = new StringBuilder();
                    __tmp86.Append(GetSuperClasses(cls));
                    using(StreamReader __tmp86Reader = new StreamReader(this.__ToStream(__tmp86.ToString())))
                    {
                        bool __tmp86_last = __tmp86Reader.EndOfStream;
                        while(!__tmp86_last)
                        {
                            string __tmp86Line = __tmp86Reader.ReadLine();
                            __tmp86_last = __tmp86Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp86Line))
                            {
                                __out.Append(__tmp86Line);
                                __tmp84OutputWritten = true;
                            }
                            if (__tmp84OutputWritten)
                            {
                                __out.AppendLine(false); //596:49
                            }
                        }
                    }
                    if (__tmp84OutputWritten)
                    {
                        __out.AppendLine(false); //596:49
                    }
                    bool __tmp88OutputWritten = false;
                    string __tmp89Line = "	/// All superclasses: "; //597:1
                    if (!string.IsNullOrEmpty(__tmp89Line))
                    {
                        __out.Append(__tmp89Line);
                        __tmp88OutputWritten = true;
                    }
                    StringBuilder __tmp90 = new StringBuilder();
                    __tmp90.Append(GetAllSuperClasses(cls));
                    using(StreamReader __tmp90Reader = new StreamReader(this.__ToStream(__tmp90.ToString())))
                    {
                        bool __tmp90_last = __tmp90Reader.EndOfStream;
                        while(!__tmp90_last)
                        {
                            string __tmp90Line = __tmp90Reader.ReadLine();
                            __tmp90_last = __tmp90Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp90Line))
                            {
                                __out.Append(__tmp90Line);
                                __tmp88OutputWritten = true;
                            }
                            if (__tmp88OutputWritten)
                            {
                                __out.AppendLine(false); //597:49
                            }
                        }
                    }
                    if (__tmp88OutputWritten)
                    {
                        __out.AppendLine(false); //597:49
                    }
                }
                if ((from __loop41_var1 in __Enumerate((cls).GetEnumerator()) //599:15
                from prop in __Enumerate((__loop41_var1.Properties).GetEnumerator()) //599:20
                where prop.Kind == MetaPropertyKind.Readonly //599:36
                select new { __loop41_var1 = __loop41_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //599:3
                {
                    __out.Append("    /// Initializes the following readonly properties:"); //600:1
                    __out.AppendLine(false); //600:55
                    __out.Append("	/// <ul>"); //601:1
                    __out.AppendLine(false); //601:10
                    var __loop42_results = 
                        (from __loop42_var1 in __Enumerate((cls).GetEnumerator()) //602:11
                        from prop in __Enumerate((__loop42_var1.Properties).GetEnumerator()) //602:16
                        where prop.Kind == MetaPropertyKind.Readonly //602:32
                        select new { __loop42_var1 = __loop42_var1, prop = prop}
                        ).ToList(); //602:6
                    for (int __loop42_iteration = 0; __loop42_iteration < __loop42_results.Count; ++__loop42_iteration)
                    {
                        var __tmp91 = __loop42_results[__loop42_iteration];
                        var __loop42_var1 = __tmp91.__loop42_var1;
                        var prop = __tmp91.prop;
                        bool __tmp93OutputWritten = false;
                        string __tmp94Line = "    ///     <li>"; //603:1
                        if (!string.IsNullOrEmpty(__tmp94Line))
                        {
                            __out.Append(__tmp94Line);
                            __tmp93OutputWritten = true;
                        }
                        StringBuilder __tmp95 = new StringBuilder();
                        __tmp95.Append(prop.Name);
                        using(StreamReader __tmp95Reader = new StreamReader(this.__ToStream(__tmp95.ToString())))
                        {
                            bool __tmp95_last = __tmp95Reader.EndOfStream;
                            while(!__tmp95_last)
                            {
                                string __tmp95Line = __tmp95Reader.ReadLine();
                                __tmp95_last = __tmp95Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp95Line))
                                {
                                    __out.Append(__tmp95Line);
                                    __tmp93OutputWritten = true;
                                }
                                if (!__tmp95_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp96Line = "</li>"; //603:28
                        if (!string.IsNullOrEmpty(__tmp96Line))
                        {
                            __out.Append(__tmp96Line);
                            __tmp93OutputWritten = true;
                        }
                        if (__tmp93OutputWritten)
                        {
                            __out.AppendLine(false); //603:33
                        }
                        if (__tmp93OutputWritten)
                        {
                            __out.AppendLine(false); //603:33
                        }
                    }
                    __out.Append("	/// </ul>"); //605:1
                    __out.AppendLine(false); //605:11
                }
                if ((from __loop43_var1 in __Enumerate((cls).GetEnumerator()) //607:15
                from prop in __Enumerate((__loop43_var1.Properties).GetEnumerator()) //607:20
                where prop.Kind == MetaPropertyKind.Lazy //607:36
                select new { __loop43_var1 = __loop43_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //607:3
                {
                    __out.Append("    /// Initializes the following lazy properties:"); //608:1
                    __out.AppendLine(false); //608:51
                    __out.Append("	/// <ul>"); //609:1
                    __out.AppendLine(false); //609:10
                    var __loop44_results = 
                        (from __loop44_var1 in __Enumerate((cls).GetEnumerator()) //610:11
                        from prop in __Enumerate((__loop44_var1.Properties).GetEnumerator()) //610:16
                        where prop.Kind == MetaPropertyKind.Lazy //610:32
                        select new { __loop44_var1 = __loop44_var1, prop = prop}
                        ).ToList(); //610:6
                    for (int __loop44_iteration = 0; __loop44_iteration < __loop44_results.Count; ++__loop44_iteration)
                    {
                        var __tmp97 = __loop44_results[__loop44_iteration];
                        var __loop44_var1 = __tmp97.__loop44_var1;
                        var prop = __tmp97.prop;
                        bool __tmp99OutputWritten = false;
                        string __tmp100Line = "    ///     <li>"; //611:1
                        if (!string.IsNullOrEmpty(__tmp100Line))
                        {
                            __out.Append(__tmp100Line);
                            __tmp99OutputWritten = true;
                        }
                        StringBuilder __tmp101 = new StringBuilder();
                        __tmp101.Append(prop.Name);
                        using(StreamReader __tmp101Reader = new StreamReader(this.__ToStream(__tmp101.ToString())))
                        {
                            bool __tmp101_last = __tmp101Reader.EndOfStream;
                            while(!__tmp101_last)
                            {
                                string __tmp101Line = __tmp101Reader.ReadLine();
                                __tmp101_last = __tmp101Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp101Line))
                                {
                                    __out.Append(__tmp101Line);
                                    __tmp99OutputWritten = true;
                                }
                                if (!__tmp101_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp102Line = "</li>"; //611:28
                        if (!string.IsNullOrEmpty(__tmp102Line))
                        {
                            __out.Append(__tmp102Line);
                            __tmp99OutputWritten = true;
                        }
                        if (__tmp99OutputWritten)
                        {
                            __out.AppendLine(false); //611:33
                        }
                        if (__tmp99OutputWritten)
                        {
                            __out.AppendLine(false); //611:33
                        }
                    }
                    __out.Append("	/// </ul>"); //613:1
                    __out.AppendLine(false); //613:11
                }
                if ((from __loop45_var1 in __Enumerate((cls).GetEnumerator()) //615:15
                from prop in __Enumerate((__loop45_var1.Properties).GetEnumerator()) //615:20
                where prop.Kind == MetaPropertyKind.Derived //615:36
                select new { __loop45_var1 = __loop45_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //615:3
                {
                    __out.Append("    /// Initializes the following derived properties:"); //616:1
                    __out.AppendLine(false); //616:54
                    __out.Append("	/// <ul>"); //617:1
                    __out.AppendLine(false); //617:10
                    var __loop46_results = 
                        (from __loop46_var1 in __Enumerate((cls).GetEnumerator()) //618:11
                        from prop in __Enumerate((__loop46_var1.Properties).GetEnumerator()) //618:16
                        where prop.Kind == MetaPropertyKind.Derived //618:32
                        select new { __loop46_var1 = __loop46_var1, prop = prop}
                        ).ToList(); //618:6
                    for (int __loop46_iteration = 0; __loop46_iteration < __loop46_results.Count; ++__loop46_iteration)
                    {
                        var __tmp103 = __loop46_results[__loop46_iteration];
                        var __loop46_var1 = __tmp103.__loop46_var1;
                        var prop = __tmp103.prop;
                        bool __tmp105OutputWritten = false;
                        string __tmp106Line = "    ///     <li>"; //619:1
                        if (!string.IsNullOrEmpty(__tmp106Line))
                        {
                            __out.Append(__tmp106Line);
                            __tmp105OutputWritten = true;
                        }
                        StringBuilder __tmp107 = new StringBuilder();
                        __tmp107.Append(prop.Name);
                        using(StreamReader __tmp107Reader = new StreamReader(this.__ToStream(__tmp107.ToString())))
                        {
                            bool __tmp107_last = __tmp107Reader.EndOfStream;
                            while(!__tmp107_last)
                            {
                                string __tmp107Line = __tmp107Reader.ReadLine();
                                __tmp107_last = __tmp107Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp107Line))
                                {
                                    __out.Append(__tmp107Line);
                                    __tmp105OutputWritten = true;
                                }
                                if (!__tmp107_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp108Line = "</li>"; //619:28
                        if (!string.IsNullOrEmpty(__tmp108Line))
                        {
                            __out.Append(__tmp108Line);
                            __tmp105OutputWritten = true;
                        }
                        if (__tmp105OutputWritten)
                        {
                            __out.AppendLine(false); //619:33
                        }
                        if (__tmp105OutputWritten)
                        {
                            __out.AppendLine(false); //619:33
                        }
                    }
                    __out.Append("	/// </ul>"); //621:1
                    __out.AppendLine(false); //621:11
                }
                bool __tmp110OutputWritten = false;
                string __tmp111Line = "    public virtual void "; //623:1
                if (!string.IsNullOrEmpty(__tmp111Line))
                {
                    __out.Append(__tmp111Line);
                    __tmp110OutputWritten = true;
                }
                StringBuilder __tmp112 = new StringBuilder();
                __tmp112.Append(cls.CSharpName());
                using(StreamReader __tmp112Reader = new StreamReader(this.__ToStream(__tmp112.ToString())))
                {
                    bool __tmp112_last = __tmp112Reader.EndOfStream;
                    while(!__tmp112_last)
                    {
                        string __tmp112Line = __tmp112Reader.ReadLine();
                        __tmp112_last = __tmp112Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp112Line))
                        {
                            __out.Append(__tmp112Line);
                            __tmp110OutputWritten = true;
                        }
                        if (!__tmp112_last) __out.AppendLine(true);
                    }
                }
                string __tmp113Line = "("; //623:43
                if (!string.IsNullOrEmpty(__tmp113Line))
                {
                    __out.Append(__tmp113Line);
                    __tmp110OutputWritten = true;
                }
                StringBuilder __tmp114 = new StringBuilder();
                __tmp114.Append(cls.CSharpName(ClassKind.Builder));
                using(StreamReader __tmp114Reader = new StreamReader(this.__ToStream(__tmp114.ToString())))
                {
                    bool __tmp114_last = __tmp114Reader.EndOfStream;
                    while(!__tmp114_last)
                    {
                        string __tmp114Line = __tmp114Reader.ReadLine();
                        __tmp114_last = __tmp114Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp114Line))
                        {
                            __out.Append(__tmp114Line);
                            __tmp110OutputWritten = true;
                        }
                        if (!__tmp114_last) __out.AppendLine(true);
                    }
                }
                string __tmp115Line = " _this)"; //623:79
                if (!string.IsNullOrEmpty(__tmp115Line))
                {
                    __out.Append(__tmp115Line);
                    __tmp110OutputWritten = true;
                }
                if (__tmp110OutputWritten)
                {
                    __out.AppendLine(false); //623:86
                }
                if (__tmp110OutputWritten)
                {
                    __out.AppendLine(false); //623:86
                }
                __out.Append("    {"); //624:1
                __out.AppendLine(false); //624:6
                __out.Append("    }"); //625:1
                __out.AppendLine(false); //625:6
                var __loop47_results = 
                    (from __loop47_var1 in __Enumerate((cls).GetEnumerator()) //626:11
                    from op in __Enumerate((__loop47_var1.Operations).GetEnumerator()) //626:16
                    select new { __loop47_var1 = __loop47_var1, op = op}
                    ).ToList(); //626:6
                for (int __loop47_iteration = 0; __loop47_iteration < __loop47_results.Count; ++__loop47_iteration)
                {
                    var __tmp116 = __loop47_results[__loop47_iteration];
                    var __loop47_var1 = __tmp116.__loop47_var1;
                    var op = __tmp116.op;
                    __out.AppendLine(true); //627:1
                    __out.Append("    /// <summary>"); //628:1
                    __out.AppendLine(false); //628:18
                    bool __tmp118OutputWritten = false;
                    string __tmp119Line = "    /// Implements the operation: "; //629:1
                    if (!string.IsNullOrEmpty(__tmp119Line))
                    {
                        __out.Append(__tmp119Line);
                        __tmp118OutputWritten = true;
                    }
                    StringBuilder __tmp120 = new StringBuilder();
                    __tmp120.Append(cls.CSharpName());
                    using(StreamReader __tmp120Reader = new StreamReader(this.__ToStream(__tmp120.ToString())))
                    {
                        bool __tmp120_last = __tmp120Reader.EndOfStream;
                        while(!__tmp120_last)
                        {
                            string __tmp120Line = __tmp120Reader.ReadLine();
                            __tmp120_last = __tmp120Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp120Line))
                            {
                                __out.Append(__tmp120Line);
                                __tmp118OutputWritten = true;
                            }
                            if (!__tmp120_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp121Line = "."; //629:53
                    if (!string.IsNullOrEmpty(__tmp121Line))
                    {
                        __out.Append(__tmp121Line);
                        __tmp118OutputWritten = true;
                    }
                    StringBuilder __tmp122 = new StringBuilder();
                    __tmp122.Append(op.Name);
                    using(StreamReader __tmp122Reader = new StreamReader(this.__ToStream(__tmp122.ToString())))
                    {
                        bool __tmp122_last = __tmp122Reader.EndOfStream;
                        while(!__tmp122_last)
                        {
                            string __tmp122Line = __tmp122Reader.ReadLine();
                            __tmp122_last = __tmp122Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp122Line))
                            {
                                __out.Append(__tmp122Line);
                                __tmp118OutputWritten = true;
                            }
                            if (!__tmp122_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp123Line = "()"; //629:63
                    if (!string.IsNullOrEmpty(__tmp123Line))
                    {
                        __out.Append(__tmp123Line);
                        __tmp118OutputWritten = true;
                    }
                    if (__tmp118OutputWritten)
                    {
                        __out.AppendLine(false); //629:65
                    }
                    if (__tmp118OutputWritten)
                    {
                        __out.AppendLine(false); //629:65
                    }
                    __out.Append("    /// </summary>"); //630:1
                    __out.AppendLine(false); //630:19
                    bool __tmp125OutputWritten = false;
                    string __tmp126Line = "    public virtual "; //631:1
                    if (!string.IsNullOrEmpty(__tmp126Line))
                    {
                        __out.Append(__tmp126Line);
                        __tmp125OutputWritten = true;
                    }
                    StringBuilder __tmp127 = new StringBuilder();
                    __tmp127.Append(op.ReturnType.CSharpFullPublicName(ClassKind.Immutable));
                    using(StreamReader __tmp127Reader = new StreamReader(this.__ToStream(__tmp127.ToString())))
                    {
                        bool __tmp127_last = __tmp127Reader.EndOfStream;
                        while(!__tmp127_last)
                        {
                            string __tmp127Line = __tmp127Reader.ReadLine();
                            __tmp127_last = __tmp127Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp127Line))
                            {
                                __out.Append(__tmp127Line);
                                __tmp125OutputWritten = true;
                            }
                            if (!__tmp127_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp128Line = " "; //631:77
                    if (!string.IsNullOrEmpty(__tmp128Line))
                    {
                        __out.Append(__tmp128Line);
                        __tmp125OutputWritten = true;
                    }
                    StringBuilder __tmp129 = new StringBuilder();
                    __tmp129.Append(cls.CSharpName());
                    using(StreamReader __tmp129Reader = new StreamReader(this.__ToStream(__tmp129.ToString())))
                    {
                        bool __tmp129_last = __tmp129Reader.EndOfStream;
                        while(!__tmp129_last)
                        {
                            string __tmp129Line = __tmp129Reader.ReadLine();
                            __tmp129_last = __tmp129Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp129Line))
                            {
                                __out.Append(__tmp129Line);
                                __tmp125OutputWritten = true;
                            }
                            if (!__tmp129_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp130Line = "_"; //631:96
                    if (!string.IsNullOrEmpty(__tmp130Line))
                    {
                        __out.Append(__tmp130Line);
                        __tmp125OutputWritten = true;
                    }
                    StringBuilder __tmp131 = new StringBuilder();
                    __tmp131.Append(op.Name);
                    using(StreamReader __tmp131Reader = new StreamReader(this.__ToStream(__tmp131.ToString())))
                    {
                        bool __tmp131_last = __tmp131Reader.EndOfStream;
                        while(!__tmp131_last)
                        {
                            string __tmp131Line = __tmp131Reader.ReadLine();
                            __tmp131_last = __tmp131Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp131Line))
                            {
                                __out.Append(__tmp131Line);
                                __tmp125OutputWritten = true;
                            }
                            if (!__tmp131_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp132Line = "("; //631:106
                    if (!string.IsNullOrEmpty(__tmp132Line))
                    {
                        __out.Append(__tmp132Line);
                        __tmp125OutputWritten = true;
                    }
                    StringBuilder __tmp133 = new StringBuilder();
                    __tmp133.Append(GetImplParameters(cls, op));
                    using(StreamReader __tmp133Reader = new StreamReader(this.__ToStream(__tmp133.ToString())))
                    {
                        bool __tmp133_last = __tmp133Reader.EndOfStream;
                        while(!__tmp133_last)
                        {
                            string __tmp133Line = __tmp133Reader.ReadLine();
                            __tmp133_last = __tmp133Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp133Line))
                            {
                                __out.Append(__tmp133Line);
                                __tmp125OutputWritten = true;
                            }
                            if (!__tmp133_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp134Line = ")"; //631:135
                    if (!string.IsNullOrEmpty(__tmp134Line))
                    {
                        __out.Append(__tmp134Line);
                        __tmp125OutputWritten = true;
                    }
                    if (__tmp125OutputWritten)
                    {
                        __out.AppendLine(false); //631:136
                    }
                    if (__tmp125OutputWritten)
                    {
                        __out.AppendLine(false); //631:136
                    }
                    __out.Append("    {"); //632:1
                    __out.AppendLine(false); //632:6
                    __out.Append("        throw new NotImplementedException();"); //633:1
                    __out.AppendLine(false); //633:45
                    __out.Append("    }"); //634:1
                    __out.AppendLine(false); //634:6
                }
                __out.AppendLine(true); //636:1
            }
            var __loop48_results = 
                (from __loop48_var1 in __Enumerate((model).GetEnumerator()) //638:8
                from Namespace in __Enumerate((__loop48_var1.Namespace).GetEnumerator()) //638:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //638:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //638:40
                select new { __loop48_var1 = __loop48_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //638:3
            for (int __loop48_iteration = 0; __loop48_iteration < __loop48_results.Count; ++__loop48_iteration)
            {
                var __tmp135 = __loop48_results[__loop48_iteration];
                var __loop48_var1 = __tmp135.__loop48_var1;
                var Namespace = __tmp135.Namespace;
                var Declarations = __tmp135.Declarations;
                var enm = __tmp135.enm;
                var __loop49_results = 
                    (from __loop49_var1 in __Enumerate((enm).GetEnumerator()) //639:11
                    from op in __Enumerate((__loop49_var1.Operations).GetEnumerator()) //639:16
                    select new { __loop49_var1 = __loop49_var1, op = op}
                    ).ToList(); //639:6
                for (int __loop49_iteration = 0; __loop49_iteration < __loop49_results.Count; ++__loop49_iteration)
                {
                    var __tmp136 = __loop49_results[__loop49_iteration];
                    var __loop49_var1 = __tmp136.__loop49_var1;
                    var op = __tmp136.op;
                    __out.AppendLine(true); //640:1
                    __out.Append("    /// <summary>"); //641:1
                    __out.AppendLine(false); //641:18
                    bool __tmp138OutputWritten = false;
                    string __tmp139Line = "    /// Implements the operation: "; //642:1
                    if (!string.IsNullOrEmpty(__tmp139Line))
                    {
                        __out.Append(__tmp139Line);
                        __tmp138OutputWritten = true;
                    }
                    StringBuilder __tmp140 = new StringBuilder();
                    __tmp140.Append(enm.CSharpName());
                    using(StreamReader __tmp140Reader = new StreamReader(this.__ToStream(__tmp140.ToString())))
                    {
                        bool __tmp140_last = __tmp140Reader.EndOfStream;
                        while(!__tmp140_last)
                        {
                            string __tmp140Line = __tmp140Reader.ReadLine();
                            __tmp140_last = __tmp140Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp140Line))
                            {
                                __out.Append(__tmp140Line);
                                __tmp138OutputWritten = true;
                            }
                            if (!__tmp140_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp141Line = "."; //642:53
                    if (!string.IsNullOrEmpty(__tmp141Line))
                    {
                        __out.Append(__tmp141Line);
                        __tmp138OutputWritten = true;
                    }
                    StringBuilder __tmp142 = new StringBuilder();
                    __tmp142.Append(op.Name);
                    using(StreamReader __tmp142Reader = new StreamReader(this.__ToStream(__tmp142.ToString())))
                    {
                        bool __tmp142_last = __tmp142Reader.EndOfStream;
                        while(!__tmp142_last)
                        {
                            string __tmp142Line = __tmp142Reader.ReadLine();
                            __tmp142_last = __tmp142Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp142Line))
                            {
                                __out.Append(__tmp142Line);
                                __tmp138OutputWritten = true;
                            }
                            if (__tmp138OutputWritten)
                            {
                                __out.AppendLine(false); //642:63
                            }
                        }
                    }
                    if (__tmp138OutputWritten)
                    {
                        __out.AppendLine(false); //642:63
                    }
                    __out.Append("    /// </summary>"); //643:1
                    __out.AppendLine(false); //643:19
                    bool __tmp144OutputWritten = false;
                    string __tmp145Line = "    public virtual "; //644:1
                    if (!string.IsNullOrEmpty(__tmp145Line))
                    {
                        __out.Append(__tmp145Line);
                        __tmp144OutputWritten = true;
                    }
                    StringBuilder __tmp146 = new StringBuilder();
                    __tmp146.Append(op.ReturnType.CSharpFullPublicName(ClassKind.Immutable));
                    using(StreamReader __tmp146Reader = new StreamReader(this.__ToStream(__tmp146.ToString())))
                    {
                        bool __tmp146_last = __tmp146Reader.EndOfStream;
                        while(!__tmp146_last)
                        {
                            string __tmp146Line = __tmp146Reader.ReadLine();
                            __tmp146_last = __tmp146Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp146Line))
                            {
                                __out.Append(__tmp146Line);
                                __tmp144OutputWritten = true;
                            }
                            if (!__tmp146_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp147Line = " "; //644:77
                    if (!string.IsNullOrEmpty(__tmp147Line))
                    {
                        __out.Append(__tmp147Line);
                        __tmp144OutputWritten = true;
                    }
                    StringBuilder __tmp148 = new StringBuilder();
                    __tmp148.Append(enm.CSharpName());
                    using(StreamReader __tmp148Reader = new StreamReader(this.__ToStream(__tmp148.ToString())))
                    {
                        bool __tmp148_last = __tmp148Reader.EndOfStream;
                        while(!__tmp148_last)
                        {
                            string __tmp148Line = __tmp148Reader.ReadLine();
                            __tmp148_last = __tmp148Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp148Line))
                            {
                                __out.Append(__tmp148Line);
                                __tmp144OutputWritten = true;
                            }
                            if (!__tmp148_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp149Line = "_"; //644:96
                    if (!string.IsNullOrEmpty(__tmp149Line))
                    {
                        __out.Append(__tmp149Line);
                        __tmp144OutputWritten = true;
                    }
                    StringBuilder __tmp150 = new StringBuilder();
                    __tmp150.Append(op.Name);
                    using(StreamReader __tmp150Reader = new StreamReader(this.__ToStream(__tmp150.ToString())))
                    {
                        bool __tmp150_last = __tmp150Reader.EndOfStream;
                        while(!__tmp150_last)
                        {
                            string __tmp150Line = __tmp150Reader.ReadLine();
                            __tmp150_last = __tmp150Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp150Line))
                            {
                                __out.Append(__tmp150Line);
                                __tmp144OutputWritten = true;
                            }
                            if (!__tmp150_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp151Line = "("; //644:106
                    if (!string.IsNullOrEmpty(__tmp151Line))
                    {
                        __out.Append(__tmp151Line);
                        __tmp144OutputWritten = true;
                    }
                    StringBuilder __tmp152 = new StringBuilder();
                    __tmp152.Append(GetImplParameters(enm, op));
                    using(StreamReader __tmp152Reader = new StreamReader(this.__ToStream(__tmp152.ToString())))
                    {
                        bool __tmp152_last = __tmp152Reader.EndOfStream;
                        while(!__tmp152_last)
                        {
                            string __tmp152Line = __tmp152Reader.ReadLine();
                            __tmp152_last = __tmp152Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp152Line))
                            {
                                __out.Append(__tmp152Line);
                                __tmp144OutputWritten = true;
                            }
                            if (!__tmp152_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp153Line = ")"; //644:135
                    if (!string.IsNullOrEmpty(__tmp153Line))
                    {
                        __out.Append(__tmp153Line);
                        __tmp144OutputWritten = true;
                    }
                    if (__tmp144OutputWritten)
                    {
                        __out.AppendLine(false); //644:136
                    }
                    if (__tmp144OutputWritten)
                    {
                        __out.AppendLine(false); //644:136
                    }
                    __out.Append("    {"); //645:1
                    __out.AppendLine(false); //645:6
                    __out.Append("        throw new NotImplementedException();"); //646:1
                    __out.AppendLine(false); //646:45
                    __out.Append("    }"); //647:1
                    __out.AppendLine(false); //647:6
                }
                __out.AppendLine(true); //649:1
            }
            __out.Append("}"); //651:1
            __out.AppendLine(false); //651:2
            __out.AppendLine(true); //652:1
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //655:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //656:1
            __out.AppendLine(false); //656:14
            __out.Append("/// Factory class for creating instances of model elements."); //657:1
            __out.AppendLine(false); //657:60
            __out.Append("/// </summary>"); //658:1
            __out.AppendLine(false); //658:15
            bool __tmp2OutputWritten = false;
            string __tmp3Line = "public class "; //659:1
            if (!string.IsNullOrEmpty(__tmp3Line))
            {
                __out.Append(__tmp3Line);
                __tmp2OutputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(model.CSharpFactoryName());
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4Line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp4Line))
                    {
                        __out.Append(__tmp4Line);
                        __tmp2OutputWritten = true;
                    }
                    if (!__tmp4_last) __out.AppendLine(true);
                }
            }
            string __tmp5Line = " : global::MetaDslx.Core.Immutable.ModelFactory"; //659:41
            if (!string.IsNullOrEmpty(__tmp5Line))
            {
                __out.Append(__tmp5Line);
                __tmp2OutputWritten = true;
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //659:88
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //659:88
            }
            __out.Append("{"); //660:1
            __out.AppendLine(false); //660:2
            bool __tmp7OutputWritten = false;
            string __tmp8Line = "    public "; //661:1
            if (!string.IsNullOrEmpty(__tmp8Line))
            {
                __out.Append(__tmp8Line);
                __tmp7OutputWritten = true;
            }
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(model.CSharpFactoryName());
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_last = __tmp9Reader.EndOfStream;
                while(!__tmp9_last)
                {
                    string __tmp9Line = __tmp9Reader.ReadLine();
                    __tmp9_last = __tmp9Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp9Line))
                    {
                        __out.Append(__tmp9Line);
                        __tmp7OutputWritten = true;
                    }
                    if (!__tmp9_last) __out.AppendLine(true);
                }
            }
            string __tmp10Line = "(MutableModel model, ModelFactoryFlags flags = ModelFactoryFlags.None)"; //661:39
            if (!string.IsNullOrEmpty(__tmp10Line))
            {
                __out.Append(__tmp10Line);
                __tmp7OutputWritten = true;
            }
            if (__tmp7OutputWritten)
            {
                __out.AppendLine(false); //661:109
            }
            if (__tmp7OutputWritten)
            {
                __out.AppendLine(false); //661:109
            }
            __out.Append("        : base(model, flags)"); //662:1
            __out.AppendLine(false); //662:29
            __out.Append("    {"); //663:1
            __out.AppendLine(false); //663:6
            bool __tmp12OutputWritten = false;
            string __tmp11Prefix = "		"; //664:1
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(model.CSharpFullDescriptorName(ClassKind.Immutable));
            using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
            {
                bool __tmp13_last = __tmp13Reader.EndOfStream;
                while(!__tmp13_last)
                {
                    string __tmp13Line = __tmp13Reader.ReadLine();
                    __tmp13_last = __tmp13Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp11Prefix))
                    {
                        __out.Append(__tmp11Prefix);
                        __tmp12OutputWritten = true;
                    }
                    if (!string.IsNullOrEmpty(__tmp13Line))
                    {
                        __out.Append(__tmp13Line);
                        __tmp12OutputWritten = true;
                    }
                    if (!__tmp13_last) __out.AppendLine(true);
                }
            }
            string __tmp14Line = ".Initialize();"; //664:56
            if (!string.IsNullOrEmpty(__tmp14Line))
            {
                __out.Append(__tmp14Line);
                __tmp12OutputWritten = true;
            }
            if (__tmp12OutputWritten)
            {
                __out.AppendLine(false); //664:70
            }
            if (__tmp12OutputWritten)
            {
                __out.AppendLine(false); //664:70
            }
            __out.Append("    }"); //665:1
            __out.AppendLine(false); //665:6
            __out.AppendLine(true); //666:1
            __out.Append("    public override global::MetaDslx.Core.Immutable.MutableSymbolBase Create(string type)"); //667:1
            __out.AppendLine(false); //667:90
            __out.Append("    {"); //668:1
            __out.AppendLine(false); //668:6
            __out.Append("        switch (type)"); //669:1
            __out.AppendLine(false); //669:22
            __out.Append("        {"); //670:1
            __out.AppendLine(false); //670:10
            var __loop50_results = 
                (from __loop50_var1 in __Enumerate((model).GetEnumerator()) //671:10
                from Namespace in __Enumerate((__loop50_var1.Namespace).GetEnumerator()) //671:17
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //671:28
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //671:42
                select new { __loop50_var1 = __loop50_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //671:5
            for (int __loop50_iteration = 0; __loop50_iteration < __loop50_results.Count; ++__loop50_iteration)
            {
                var __tmp15 = __loop50_results[__loop50_iteration];
                var __loop50_var1 = __tmp15.__loop50_var1;
                var Namespace = __tmp15.Namespace;
                var Declarations = __tmp15.Declarations;
                var cls = __tmp15.cls;
                if (!cls.IsAbstract) //672:6
                {
                    bool __tmp17OutputWritten = false;
                    string __tmp18Line = "            case \""; //673:1
                    if (!string.IsNullOrEmpty(__tmp18Line))
                    {
                        __out.Append(__tmp18Line);
                        __tmp17OutputWritten = true;
                    }
                    StringBuilder __tmp19 = new StringBuilder();
                    __tmp19.Append(cls.CSharpName());
                    using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
                    {
                        bool __tmp19_last = __tmp19Reader.EndOfStream;
                        while(!__tmp19_last)
                        {
                            string __tmp19Line = __tmp19Reader.ReadLine();
                            __tmp19_last = __tmp19Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp19Line))
                            {
                                __out.Append(__tmp19Line);
                                __tmp17OutputWritten = true;
                            }
                            if (!__tmp19_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp20Line = "\": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this."; //673:37
                    if (!string.IsNullOrEmpty(__tmp20Line))
                    {
                        __out.Append(__tmp20Line);
                        __tmp17OutputWritten = true;
                    }
                    StringBuilder __tmp21 = new StringBuilder();
                    __tmp21.Append(cls.CSharpName());
                    using(StreamReader __tmp21Reader = new StreamReader(this.__ToStream(__tmp21.ToString())))
                    {
                        bool __tmp21_last = __tmp21Reader.EndOfStream;
                        while(!__tmp21_last)
                        {
                            string __tmp21Line = __tmp21Reader.ReadLine();
                            __tmp21_last = __tmp21Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp21Line))
                            {
                                __out.Append(__tmp21Line);
                                __tmp17OutputWritten = true;
                            }
                            if (!__tmp21_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp22Line = "();"; //673:121
                    if (!string.IsNullOrEmpty(__tmp22Line))
                    {
                        __out.Append(__tmp22Line);
                        __tmp17OutputWritten = true;
                    }
                    if (__tmp17OutputWritten)
                    {
                        __out.AppendLine(false); //673:124
                    }
                    if (__tmp17OutputWritten)
                    {
                        __out.AppendLine(false); //673:124
                    }
                }
            }
            __out.Append("            default:"); //676:1
            __out.AppendLine(false); //676:21
            __out.Append("                throw new ModelException(\"Unknown type name: \" + type);"); //677:1
            __out.AppendLine(false); //677:72
            __out.Append("        }"); //678:1
            __out.AppendLine(false); //678:10
            __out.Append("    }"); //679:1
            __out.AppendLine(false); //679:6
            var __loop51_results = 
                (from __loop51_var1 in __Enumerate((model).GetEnumerator()) //680:8
                from Namespace in __Enumerate((__loop51_var1.Namespace).GetEnumerator()) //680:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //680:26
                from cls in __Enumerate((Declarations).GetEnumerator()).OfType<MetaClass>() //680:40
                select new { __loop51_var1 = __loop51_var1, Namespace = Namespace, Declarations = Declarations, cls = cls}
                ).ToList(); //680:3
            for (int __loop51_iteration = 0; __loop51_iteration < __loop51_results.Count; ++__loop51_iteration)
            {
                var __tmp23 = __loop51_results[__loop51_iteration];
                var __loop51_var1 = __tmp23.__loop51_var1;
                var Namespace = __tmp23.Namespace;
                var Declarations = __tmp23.Declarations;
                var cls = __tmp23.cls;
                if (!cls.IsAbstract) //681:4
                {
                    __out.AppendLine(true); //682:1
                    __out.Append("    /// <summary>"); //683:1
                    __out.AppendLine(false); //683:18
                    bool __tmp25OutputWritten = false;
                    string __tmp26Line = "    /// Creates a new instance of "; //684:1
                    if (!string.IsNullOrEmpty(__tmp26Line))
                    {
                        __out.Append(__tmp26Line);
                        __tmp25OutputWritten = true;
                    }
                    StringBuilder __tmp27 = new StringBuilder();
                    __tmp27.Append(cls.CSharpName());
                    using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
                    {
                        bool __tmp27_last = __tmp27Reader.EndOfStream;
                        while(!__tmp27_last)
                        {
                            string __tmp27Line = __tmp27Reader.ReadLine();
                            __tmp27_last = __tmp27Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp27Line))
                            {
                                __out.Append(__tmp27Line);
                                __tmp25OutputWritten = true;
                            }
                            if (!__tmp27_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp28Line = "."; //684:53
                    if (!string.IsNullOrEmpty(__tmp28Line))
                    {
                        __out.Append(__tmp28Line);
                        __tmp25OutputWritten = true;
                    }
                    if (__tmp25OutputWritten)
                    {
                        __out.AppendLine(false); //684:54
                    }
                    if (__tmp25OutputWritten)
                    {
                        __out.AppendLine(false); //684:54
                    }
                    __out.Append("    /// </summary>"); //685:1
                    __out.AppendLine(false); //685:19
                    bool __tmp30OutputWritten = false;
                    string __tmp31Line = "    public "; //686:1
                    if (!string.IsNullOrEmpty(__tmp31Line))
                    {
                        __out.Append(__tmp31Line);
                        __tmp30OutputWritten = true;
                    }
                    StringBuilder __tmp32 = new StringBuilder();
                    __tmp32.Append(cls.CSharpName(ClassKind.Builder));
                    using(StreamReader __tmp32Reader = new StreamReader(this.__ToStream(__tmp32.ToString())))
                    {
                        bool __tmp32_last = __tmp32Reader.EndOfStream;
                        while(!__tmp32_last)
                        {
                            string __tmp32Line = __tmp32Reader.ReadLine();
                            __tmp32_last = __tmp32Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp32Line))
                            {
                                __out.Append(__tmp32Line);
                                __tmp30OutputWritten = true;
                            }
                            if (!__tmp32_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp33Line = " "; //686:47
                    if (!string.IsNullOrEmpty(__tmp33Line))
                    {
                        __out.Append(__tmp33Line);
                        __tmp30OutputWritten = true;
                    }
                    StringBuilder __tmp34 = new StringBuilder();
                    __tmp34.Append(cls.CSharpName());
                    using(StreamReader __tmp34Reader = new StreamReader(this.__ToStream(__tmp34.ToString())))
                    {
                        bool __tmp34_last = __tmp34Reader.EndOfStream;
                        while(!__tmp34_last)
                        {
                            string __tmp34Line = __tmp34Reader.ReadLine();
                            __tmp34_last = __tmp34Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp34Line))
                            {
                                __out.Append(__tmp34Line);
                                __tmp30OutputWritten = true;
                            }
                            if (!__tmp34_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp35Line = "()"; //686:66
                    if (!string.IsNullOrEmpty(__tmp35Line))
                    {
                        __out.Append(__tmp35Line);
                        __tmp30OutputWritten = true;
                    }
                    if (__tmp30OutputWritten)
                    {
                        __out.AppendLine(false); //686:68
                    }
                    if (__tmp30OutputWritten)
                    {
                        __out.AppendLine(false); //686:68
                    }
                    __out.Append("	{"); //687:1
                    __out.AppendLine(false); //687:3
                    bool __tmp37OutputWritten = false;
                    string __tmp38Line = "		global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new "; //688:1
                    if (!string.IsNullOrEmpty(__tmp38Line))
                    {
                        __out.Append(__tmp38Line);
                        __tmp37OutputWritten = true;
                    }
                    StringBuilder __tmp39 = new StringBuilder();
                    __tmp39.Append(cls.CSharpName(ClassKind.Id));
                    using(StreamReader __tmp39Reader = new StreamReader(this.__ToStream(__tmp39.ToString())))
                    {
                        bool __tmp39_last = __tmp39Reader.EndOfStream;
                        while(!__tmp39_last)
                        {
                            string __tmp39Line = __tmp39Reader.ReadLine();
                            __tmp39_last = __tmp39Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp39Line))
                            {
                                __out.Append(__tmp39Line);
                                __tmp37OutputWritten = true;
                            }
                            if (!__tmp39_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp40Line = "());"; //688:114
                    if (!string.IsNullOrEmpty(__tmp40Line))
                    {
                        __out.Append(__tmp40Line);
                        __tmp37OutputWritten = true;
                    }
                    if (__tmp37OutputWritten)
                    {
                        __out.AppendLine(false); //688:118
                    }
                    if (__tmp37OutputWritten)
                    {
                        __out.AppendLine(false); //688:118
                    }
                    bool __tmp42OutputWritten = false;
                    string __tmp43Line = "		return ("; //689:1
                    if (!string.IsNullOrEmpty(__tmp43Line))
                    {
                        __out.Append(__tmp43Line);
                        __tmp42OutputWritten = true;
                    }
                    StringBuilder __tmp44 = new StringBuilder();
                    __tmp44.Append(cls.CSharpName(ClassKind.Builder));
                    using(StreamReader __tmp44Reader = new StreamReader(this.__ToStream(__tmp44.ToString())))
                    {
                        bool __tmp44_last = __tmp44Reader.EndOfStream;
                        while(!__tmp44_last)
                        {
                            string __tmp44Line = __tmp44Reader.ReadLine();
                            __tmp44_last = __tmp44Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp44Line))
                            {
                                __out.Append(__tmp44Line);
                                __tmp42OutputWritten = true;
                            }
                            if (!__tmp44_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp45Line = ")symbol;"; //689:46
                    if (!string.IsNullOrEmpty(__tmp45Line))
                    {
                        __out.Append(__tmp45Line);
                        __tmp42OutputWritten = true;
                    }
                    if (__tmp42OutputWritten)
                    {
                        __out.AppendLine(false); //689:54
                    }
                    if (__tmp42OutputWritten)
                    {
                        __out.AppendLine(false); //689:54
                    }
                    __out.Append("	}"); //690:1
                    __out.AppendLine(false); //690:3
                }
            }
            __out.Append("}"); //693:1
            __out.AppendLine(false); //693:2
            __out.AppendLine(true); //694:1
            return __out.ToString();
        }

        public string GenerateMetaModelInstance(MetaModel model) //698:1
        {
            StringBuilder __out = new StringBuilder();
            Dictionary<ModelObject,string> mobjToName = model.GetNamedModelObjects(); //699:2
            bool coreModel = model.CSharpFullName(ClassKind.Immutable) == "global::MetaDslx.Core.Immutable.Meta"; //700:2
            bool __tmp2OutputWritten = false;
            string __tmp3Line = "internal class "; //701:1
            if (!string.IsNullOrEmpty(__tmp3Line))
            {
                __out.Append(__tmp3Line);
                __tmp2OutputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(model.CSharpInstancesName(ClassKind.Builder));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4Line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp4Line))
                    {
                        __out.Append(__tmp4Line);
                        __tmp2OutputWritten = true;
                    }
                    if (__tmp2OutputWritten)
                    {
                        __out.AppendLine(false); //701:62
                    }
                }
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //701:62
            }
            __out.Append("{"); //702:1
            __out.AppendLine(false); //702:2
            bool __tmp6OutputWritten = false;
            string __tmp7Line = "	internal static "; //703:1
            if (!string.IsNullOrEmpty(__tmp7Line))
            {
                __out.Append(__tmp7Line);
                __tmp6OutputWritten = true;
            }
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(model.CSharpInstancesName(ClassKind.Builder));
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(!__tmp8_last)
                {
                    string __tmp8Line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp8Line))
                    {
                        __out.Append(__tmp8Line);
                        __tmp6OutputWritten = true;
                    }
                    if (!__tmp8_last) __out.AppendLine(true);
                }
            }
            string __tmp9Line = " instance = new "; //703:64
            if (!string.IsNullOrEmpty(__tmp9Line))
            {
                __out.Append(__tmp9Line);
                __tmp6OutputWritten = true;
            }
            StringBuilder __tmp10 = new StringBuilder();
            __tmp10.Append(model.CSharpInstancesName(ClassKind.Builder));
            using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
            {
                bool __tmp10_last = __tmp10Reader.EndOfStream;
                while(!__tmp10_last)
                {
                    string __tmp10Line = __tmp10Reader.ReadLine();
                    __tmp10_last = __tmp10Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp10Line))
                    {
                        __out.Append(__tmp10Line);
                        __tmp6OutputWritten = true;
                    }
                    if (!__tmp10_last) __out.AppendLine(true);
                }
            }
            string __tmp11Line = "();"; //703:126
            if (!string.IsNullOrEmpty(__tmp11Line))
            {
                __out.Append(__tmp11Line);
                __tmp6OutputWritten = true;
            }
            if (__tmp6OutputWritten)
            {
                __out.AppendLine(false); //703:129
            }
            if (__tmp6OutputWritten)
            {
                __out.AppendLine(false); //703:129
            }
            __out.AppendLine(true); //704:1
            if (coreModel) //705:3
            {
                __out.Append("	internal readonly global::MetaDslx.Core.Immutable.MetaModelBuilder _MetaModel;"); //706:1
                __out.AppendLine(false); //706:80
            }
            else //707:3
            {
                __out.Append("	internal readonly global::MetaDslx.Core.Immutable.MetaModelBuilder MetaModel;"); //708:1
                __out.AppendLine(false); //708:79
            }
            __out.Append("	internal readonly global::MetaDslx.Core.Immutable.MutableModel Model;"); //710:1
            __out.AppendLine(false); //710:71
            __out.AppendLine(true); //711:1
            var __loop52_results = 
                (from __loop52_var1 in __Enumerate((model).GetEnumerator()) //712:11
                from Namespace in __Enumerate((__loop52_var1.Namespace).GetEnumerator()) //712:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //712:29
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //712:43
                select new { __loop52_var1 = __loop52_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //712:6
            for (int __loop52_iteration = 0; __loop52_iteration < __loop52_results.Count; ++__loop52_iteration)
            {
                var __tmp12 = __loop52_results[__loop52_iteration];
                var __loop52_var1 = __tmp12.__loop52_var1;
                var Namespace = __tmp12.Namespace;
                var Declarations = __tmp12.Declarations;
                var c = __tmp12.c;
                bool __tmp14OutputWritten = false;
                string __tmp13Prefix = "    "; //713:1
                StringBuilder __tmp15 = new StringBuilder();
                __tmp15.Append(GenerateModelConstant(model, c));
                using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
                {
                    bool __tmp15_last = __tmp15Reader.EndOfStream;
                    while(!__tmp15_last)
                    {
                        string __tmp15Line = __tmp15Reader.ReadLine();
                        __tmp15_last = __tmp15Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp13Prefix))
                        {
                            __out.Append(__tmp13Prefix);
                            __tmp14OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp15Line))
                        {
                            __out.Append(__tmp15Line);
                            __tmp14OutputWritten = true;
                        }
                        if (__tmp14OutputWritten)
                        {
                            __out.AppendLine(false); //713:38
                        }
                    }
                }
                if (__tmp14OutputWritten)
                {
                    __out.AppendLine(false); //713:38
                }
            }
            __out.AppendLine(true); //715:1
            var __loop53_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //716:11
                select new { mobj = mobj}
                ).ToList(); //716:6
            for (int __loop53_iteration = 0; __loop53_iteration < __loop53_results.Count; ++__loop53_iteration)
            {
                var __tmp16 = __loop53_results[__loop53_iteration];
                var mobj = __tmp16.mobj;
                bool __tmp18OutputWritten = false;
                string __tmp17Prefix = "	"; //717:1
                StringBuilder __tmp19 = new StringBuilder();
                __tmp19.Append(GenerateModelObjectInstanceDeclaration(mobj, mobjToName));
                using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
                {
                    bool __tmp19_last = __tmp19Reader.EndOfStream;
                    while(!__tmp19_last)
                    {
                        string __tmp19Line = __tmp19Reader.ReadLine();
                        __tmp19_last = __tmp19Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp17Prefix))
                        {
                            __out.Append(__tmp17Prefix);
                            __tmp18OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp19Line))
                        {
                            __out.Append(__tmp19Line);
                            __tmp18OutputWritten = true;
                        }
                        if (__tmp18OutputWritten)
                        {
                            __out.AppendLine(false); //717:60
                        }
                    }
                }
                if (__tmp18OutputWritten)
                {
                    __out.AppendLine(false); //717:60
                }
            }
            __out.AppendLine(true); //719:1
            bool __tmp21OutputWritten = false;
            string __tmp22Line = "    private "; //720:1
            if (!string.IsNullOrEmpty(__tmp22Line))
            {
                __out.Append(__tmp22Line);
                __tmp21OutputWritten = true;
            }
            StringBuilder __tmp23 = new StringBuilder();
            __tmp23.Append(model.CSharpInstancesName(ClassKind.Builder));
            using(StreamReader __tmp23Reader = new StreamReader(this.__ToStream(__tmp23.ToString())))
            {
                bool __tmp23_last = __tmp23Reader.EndOfStream;
                while(!__tmp23_last)
                {
                    string __tmp23Line = __tmp23Reader.ReadLine();
                    __tmp23_last = __tmp23Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp23Line))
                    {
                        __out.Append(__tmp23Line);
                        __tmp21OutputWritten = true;
                    }
                    if (!__tmp23_last) __out.AppendLine(true);
                }
            }
            string __tmp24Line = "()"; //720:59
            if (!string.IsNullOrEmpty(__tmp24Line))
            {
                __out.Append(__tmp24Line);
                __tmp21OutputWritten = true;
            }
            if (__tmp21OutputWritten)
            {
                __out.AppendLine(false); //720:61
            }
            if (__tmp21OutputWritten)
            {
                __out.AppendLine(false); //720:61
            }
            __out.Append("    {"); //721:1
            __out.AppendLine(false); //721:6
            __out.Append("		this.Model = new global::MetaDslx.Core.Immutable.MutableModel();"); //722:1
            __out.AppendLine(false); //722:67
            bool __tmp26OutputWritten = false;
            string __tmp25Prefix = "		"; //723:1
            StringBuilder __tmp27 = new StringBuilder();
            __tmp27.Append(model.CSharpFullFactoryName(ClassKind.Immutable));
            using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
            {
                bool __tmp27_last = __tmp27Reader.EndOfStream;
                while(!__tmp27_last)
                {
                    string __tmp27Line = __tmp27Reader.ReadLine();
                    __tmp27_last = __tmp27Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp25Prefix))
                    {
                        __out.Append(__tmp25Prefix);
                        __tmp26OutputWritten = true;
                    }
                    if (!string.IsNullOrEmpty(__tmp27Line))
                    {
                        __out.Append(__tmp27Line);
                        __tmp26OutputWritten = true;
                    }
                    if (!__tmp27_last) __out.AppendLine(true);
                }
            }
            string __tmp28Line = " factory = new "; //723:53
            if (!string.IsNullOrEmpty(__tmp28Line))
            {
                __out.Append(__tmp28Line);
                __tmp26OutputWritten = true;
            }
            StringBuilder __tmp29 = new StringBuilder();
            __tmp29.Append(model.CSharpFullFactoryName(ClassKind.Immutable));
            using(StreamReader __tmp29Reader = new StreamReader(this.__ToStream(__tmp29.ToString())))
            {
                bool __tmp29_last = __tmp29Reader.EndOfStream;
                while(!__tmp29_last)
                {
                    string __tmp29Line = __tmp29Reader.ReadLine();
                    __tmp29_last = __tmp29Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp29Line))
                    {
                        __out.Append(__tmp29Line);
                        __tmp26OutputWritten = true;
                    }
                    if (!__tmp29_last) __out.AppendLine(true);
                }
            }
            string __tmp30Line = "(this.Model, global::MetaDslx.Core.Immutable.ModelFactoryFlags.DontMakeSymbolsCreated);"; //723:118
            if (!string.IsNullOrEmpty(__tmp30Line))
            {
                __out.Append(__tmp30Line);
                __tmp26OutputWritten = true;
            }
            if (__tmp26OutputWritten)
            {
                __out.AppendLine(false); //723:205
            }
            if (__tmp26OutputWritten)
            {
                __out.AppendLine(false); //723:205
            }
            bool __tmp32OutputWritten = false;
            string __tmp31Prefix = "		"; //724:1
            StringBuilder __tmp33 = new StringBuilder();
            __tmp33.Append(model.Name);
            using(StreamReader __tmp33Reader = new StreamReader(this.__ToStream(__tmp33.ToString())))
            {
                bool __tmp33_last = __tmp33Reader.EndOfStream;
                while(!__tmp33_last)
                {
                    string __tmp33Line = __tmp33Reader.ReadLine();
                    __tmp33_last = __tmp33Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp31Prefix))
                    {
                        __out.Append(__tmp31Prefix);
                        __tmp32OutputWritten = true;
                    }
                    if (!string.IsNullOrEmpty(__tmp33Line))
                    {
                        __out.Append(__tmp33Line);
                        __tmp32OutputWritten = true;
                    }
                    if (!__tmp33_last) __out.AppendLine(true);
                }
            }
            string __tmp34Line = "ImplementationProvider.Implementation."; //724:15
            if (!string.IsNullOrEmpty(__tmp34Line))
            {
                __out.Append(__tmp34Line);
                __tmp32OutputWritten = true;
            }
            StringBuilder __tmp35 = new StringBuilder();
            __tmp35.Append(model.CSharpInstancesName(ClassKind.Builder));
            using(StreamReader __tmp35Reader = new StreamReader(this.__ToStream(__tmp35.ToString())))
            {
                bool __tmp35_last = __tmp35Reader.EndOfStream;
                while(!__tmp35_last)
                {
                    string __tmp35Line = __tmp35Reader.ReadLine();
                    __tmp35_last = __tmp35Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp35Line))
                    {
                        __out.Append(__tmp35Line);
                        __tmp32OutputWritten = true;
                    }
                    if (!__tmp35_last) __out.AppendLine(true);
                }
            }
            string __tmp36Line = "(this);"; //724:99
            if (!string.IsNullOrEmpty(__tmp36Line))
            {
                __out.Append(__tmp36Line);
                __tmp32OutputWritten = true;
            }
            if (__tmp32OutputWritten)
            {
                __out.AppendLine(false); //724:106
            }
            if (__tmp32OutputWritten)
            {
                __out.AppendLine(false); //724:106
            }
            __out.AppendLine(true); //725:1
            var __loop54_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //726:9
                select new { mobj = mobj}
                ).ToList(); //726:4
            for (int __loop54_iteration = 0; __loop54_iteration < __loop54_results.Count; ++__loop54_iteration)
            {
                var __tmp37 = __loop54_results[__loop54_iteration];
                var mobj = __tmp37.mobj;
                bool __tmp39OutputWritten = false;
                string __tmp38Prefix = "		"; //727:1
                StringBuilder __tmp40 = new StringBuilder();
                __tmp40.Append(GenerateModelObjectInstance(coreModel, mobj, mobjToName));
                using(StreamReader __tmp40Reader = new StreamReader(this.__ToStream(__tmp40.ToString())))
                {
                    bool __tmp40_last = __tmp40Reader.EndOfStream;
                    while(!__tmp40_last)
                    {
                        string __tmp40Line = __tmp40Reader.ReadLine();
                        __tmp40_last = __tmp40Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp38Prefix))
                        {
                            __out.Append(__tmp38Prefix);
                            __tmp39OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp40Line))
                        {
                            __out.Append(__tmp40Line);
                            __tmp39OutputWritten = true;
                        }
                        if (__tmp39OutputWritten)
                        {
                            __out.AppendLine(false); //727:61
                        }
                    }
                }
                if (__tmp39OutputWritten)
                {
                    __out.AppendLine(false); //727:61
                }
            }
            __out.AppendLine(true); //729:1
            var __loop55_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //730:9
                select new { mobj = mobj}
                ).ToList(); //730:4
            for (int __loop55_iteration = 0; __loop55_iteration < __loop55_results.Count; ++__loop55_iteration)
            {
                var __tmp41 = __loop55_results[__loop55_iteration];
                var mobj = __tmp41.mobj;
                bool __tmp43OutputWritten = false;
                string __tmp42Prefix = "		"; //731:1
                StringBuilder __tmp44 = new StringBuilder();
                __tmp44.Append(GenerateModelObjectInstanceInitializer(coreModel, mobj, mobjToName));
                using(StreamReader __tmp44Reader = new StreamReader(this.__ToStream(__tmp44.ToString())))
                {
                    bool __tmp44_last = __tmp44Reader.EndOfStream;
                    while(!__tmp44_last)
                    {
                        string __tmp44Line = __tmp44Reader.ReadLine();
                        __tmp44_last = __tmp44Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp42Prefix))
                        {
                            __out.Append(__tmp42Prefix);
                            __tmp43OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp44Line))
                        {
                            __out.Append(__tmp44Line);
                            __tmp43OutputWritten = true;
                        }
                        if (__tmp43OutputWritten)
                        {
                            __out.AppendLine(false); //731:72
                        }
                    }
                }
                if (__tmp43OutputWritten)
                {
                    __out.AppendLine(false); //731:72
                }
            }
            __out.AppendLine(true); //733:1
            var __loop56_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //734:9
                select new { mobj = mobj}
                ).ToList(); //734:4
            for (int __loop56_iteration = 0; __loop56_iteration < __loop56_results.Count; ++__loop56_iteration)
            {
                var __tmp45 = __loop56_results[__loop56_iteration];
                var mobj = __tmp45.mobj;
                bool __tmp47OutputWritten = false;
                string __tmp46Prefix = "		"; //735:1
                StringBuilder __tmp48 = new StringBuilder();
                __tmp48.Append(GenerateModelObjectInstanceFinalizer(mobj, mobjToName));
                using(StreamReader __tmp48Reader = new StreamReader(this.__ToStream(__tmp48.ToString())))
                {
                    bool __tmp48_last = __tmp48Reader.EndOfStream;
                    while(!__tmp48_last)
                    {
                        string __tmp48Line = __tmp48Reader.ReadLine();
                        __tmp48_last = __tmp48Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp46Prefix))
                        {
                            __out.Append(__tmp46Prefix);
                            __tmp47OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp48Line))
                        {
                            __out.Append(__tmp48Line);
                            __tmp47OutputWritten = true;
                        }
                        if (__tmp47OutputWritten)
                        {
                            __out.AppendLine(false); //735:59
                        }
                    }
                }
                if (__tmp47OutputWritten)
                {
                    __out.AppendLine(false); //735:59
                }
            }
            __out.AppendLine(true); //737:1
            __out.Append("        this.Model.EvaluateLazyValues();"); //738:1
            __out.AppendLine(false); //738:41
            __out.Append("    }"); //739:1
            __out.AppendLine(false); //739:6
            __out.Append("}"); //740:1
            __out.AppendLine(false); //740:2
            __out.AppendLine(true); //741:1
            bool __tmp50OutputWritten = false;
            string __tmp51Line = "public class "; //742:1
            if (!string.IsNullOrEmpty(__tmp51Line))
            {
                __out.Append(__tmp51Line);
                __tmp50OutputWritten = true;
            }
            StringBuilder __tmp52 = new StringBuilder();
            __tmp52.Append(model.CSharpInstancesName(ClassKind.Immutable));
            using(StreamReader __tmp52Reader = new StreamReader(this.__ToStream(__tmp52.ToString())))
            {
                bool __tmp52_last = __tmp52Reader.EndOfStream;
                while(!__tmp52_last)
                {
                    string __tmp52Line = __tmp52Reader.ReadLine();
                    __tmp52_last = __tmp52Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp52Line))
                    {
                        __out.Append(__tmp52Line);
                        __tmp50OutputWritten = true;
                    }
                    if (__tmp50OutputWritten)
                    {
                        __out.AppendLine(false); //742:62
                    }
                }
            }
            if (__tmp50OutputWritten)
            {
                __out.AppendLine(false); //742:62
            }
            __out.Append("{"); //743:1
            __out.AppendLine(false); //743:2
            __out.AppendLine(true); //744:1
            __out.Append("	private static bool initialized;"); //745:1
            __out.AppendLine(false); //745:34
            __out.AppendLine(true); //746:1
            __out.Append("	public static bool IsInitialized"); //747:1
            __out.AppendLine(false); //747:34
            __out.Append("	{"); //748:1
            __out.AppendLine(false); //748:3
            bool __tmp54OutputWritten = false;
            string __tmp55Line = "		get { return "; //749:1
            if (!string.IsNullOrEmpty(__tmp55Line))
            {
                __out.Append(__tmp55Line);
                __tmp54OutputWritten = true;
            }
            StringBuilder __tmp56 = new StringBuilder();
            __tmp56.Append(model.CSharpInstancesName(ClassKind.Immutable));
            using(StreamReader __tmp56Reader = new StreamReader(this.__ToStream(__tmp56.ToString())))
            {
                bool __tmp56_last = __tmp56Reader.EndOfStream;
                while(!__tmp56_last)
                {
                    string __tmp56Line = __tmp56Reader.ReadLine();
                    __tmp56_last = __tmp56Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp56Line))
                    {
                        __out.Append(__tmp56Line);
                        __tmp54OutputWritten = true;
                    }
                    if (!__tmp56_last) __out.AppendLine(true);
                }
            }
            string __tmp57Line = ".initialized; }"; //749:64
            if (!string.IsNullOrEmpty(__tmp57Line))
            {
                __out.Append(__tmp57Line);
                __tmp54OutputWritten = true;
            }
            if (__tmp54OutputWritten)
            {
                __out.AppendLine(false); //749:79
            }
            if (__tmp54OutputWritten)
            {
                __out.AppendLine(false); //749:79
            }
            __out.Append("	}"); //750:1
            __out.AppendLine(false); //750:3
            __out.AppendLine(true); //751:1
            if (coreModel) //752:3
            {
                __out.Append("	public static readonly global::MetaDslx.Core.Immutable.MetaModel _MetaModel;"); //753:1
                __out.AppendLine(false); //753:78
            }
            else //754:3
            {
                __out.Append("	public static readonly global::MetaDslx.Core.Immutable.MetaModel MetaModel;"); //755:1
                __out.AppendLine(false); //755:77
            }
            __out.Append("	public static readonly global::MetaDslx.Core.Immutable.ImmutableModel Model;"); //757:1
            __out.AppendLine(false); //757:78
            __out.AppendLine(true); //758:1
            var __loop57_results = 
                (from __loop57_var1 in __Enumerate((model).GetEnumerator()) //759:11
                from Namespace in __Enumerate((__loop57_var1.Namespace).GetEnumerator()) //759:18
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //759:29
                from c in __Enumerate((Declarations).GetEnumerator()).OfType<MetaConstant>() //759:43
                select new { __loop57_var1 = __loop57_var1, Namespace = Namespace, Declarations = Declarations, c = c}
                ).ToList(); //759:6
            for (int __loop57_iteration = 0; __loop57_iteration < __loop57_results.Count; ++__loop57_iteration)
            {
                var __tmp58 = __loop57_results[__loop57_iteration];
                var __loop57_var1 = __tmp58.__loop57_var1;
                var Namespace = __tmp58.Namespace;
                var Declarations = __tmp58.Declarations;
                var c = __tmp58.c;
                bool __tmp60OutputWritten = false;
                string __tmp59Prefix = "    "; //760:1
                StringBuilder __tmp61 = new StringBuilder();
                __tmp61.Append(GenerateImmutableModelConstant(model, c));
                using(StreamReader __tmp61Reader = new StreamReader(this.__ToStream(__tmp61.ToString())))
                {
                    bool __tmp61_last = __tmp61Reader.EndOfStream;
                    while(!__tmp61_last)
                    {
                        string __tmp61Line = __tmp61Reader.ReadLine();
                        __tmp61_last = __tmp61Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp59Prefix))
                        {
                            __out.Append(__tmp59Prefix);
                            __tmp60OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp61Line))
                        {
                            __out.Append(__tmp61Line);
                            __tmp60OutputWritten = true;
                        }
                        if (__tmp60OutputWritten)
                        {
                            __out.AppendLine(false); //760:47
                        }
                    }
                }
                if (__tmp60OutputWritten)
                {
                    __out.AppendLine(false); //760:47
                }
            }
            __out.AppendLine(true); //762:1
            var __loop58_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //763:11
                where mobjToName.ContainsKey(mobj) && !mobjToName[mobj].StartsWith("__") //763:26
                select new { mobj = mobj}
                ).ToList(); //763:6
            for (int __loop58_iteration = 0; __loop58_iteration < __loop58_results.Count; ++__loop58_iteration)
            {
                var __tmp62 = __loop58_results[__loop58_iteration];
                var mobj = __tmp62.mobj;
                bool __tmp64OutputWritten = false;
                string __tmp63Prefix = "	"; //764:1
                StringBuilder __tmp65 = new StringBuilder();
                __tmp65.Append(GenerateImmutableModelObjectInstanceDeclaration(model, mobj, mobjToName));
                using(StreamReader __tmp65Reader = new StreamReader(this.__ToStream(__tmp65.ToString())))
                {
                    bool __tmp65_last = __tmp65Reader.EndOfStream;
                    while(!__tmp65_last)
                    {
                        string __tmp65Line = __tmp65Reader.ReadLine();
                        __tmp65_last = __tmp65Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp63Prefix))
                        {
                            __out.Append(__tmp63Prefix);
                            __tmp64OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp65Line))
                        {
                            __out.Append(__tmp65Line);
                            __tmp64OutputWritten = true;
                        }
                        if (__tmp64OutputWritten)
                        {
                            __out.AppendLine(false); //764:76
                        }
                    }
                }
                if (__tmp64OutputWritten)
                {
                    __out.AppendLine(false); //764:76
                }
            }
            __out.AppendLine(true); //766:1
            bool __tmp67OutputWritten = false;
            string __tmp68Line = "	static "; //767:1
            if (!string.IsNullOrEmpty(__tmp68Line))
            {
                __out.Append(__tmp68Line);
                __tmp67OutputWritten = true;
            }
            StringBuilder __tmp69 = new StringBuilder();
            __tmp69.Append(model.CSharpInstancesName(ClassKind.Immutable));
            using(StreamReader __tmp69Reader = new StreamReader(this.__ToStream(__tmp69.ToString())))
            {
                bool __tmp69_last = __tmp69Reader.EndOfStream;
                while(!__tmp69_last)
                {
                    string __tmp69Line = __tmp69Reader.ReadLine();
                    __tmp69_last = __tmp69Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp69Line))
                    {
                        __out.Append(__tmp69Line);
                        __tmp67OutputWritten = true;
                    }
                    if (!__tmp69_last) __out.AppendLine(true);
                }
            }
            string __tmp70Line = "()"; //767:57
            if (!string.IsNullOrEmpty(__tmp70Line))
            {
                __out.Append(__tmp70Line);
                __tmp67OutputWritten = true;
            }
            if (__tmp67OutputWritten)
            {
                __out.AppendLine(false); //767:59
            }
            if (__tmp67OutputWritten)
            {
                __out.AppendLine(false); //767:59
            }
            __out.Append("	{"); //768:1
            __out.AppendLine(false); //768:3
            bool __tmp72OutputWritten = false;
            string __tmp71Prefix = "		"; //769:1
            StringBuilder __tmp73 = new StringBuilder();
            __tmp73.Append(model.CSharpInstancesName(ClassKind.Immutable));
            using(StreamReader __tmp73Reader = new StreamReader(this.__ToStream(__tmp73.ToString())))
            {
                bool __tmp73_last = __tmp73Reader.EndOfStream;
                while(!__tmp73_last)
                {
                    string __tmp73Line = __tmp73Reader.ReadLine();
                    __tmp73_last = __tmp73Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp71Prefix))
                    {
                        __out.Append(__tmp71Prefix);
                        __tmp72OutputWritten = true;
                    }
                    if (!string.IsNullOrEmpty(__tmp73Line))
                    {
                        __out.Append(__tmp73Line);
                        __tmp72OutputWritten = true;
                    }
                    if (!__tmp73_last) __out.AppendLine(true);
                }
            }
            string __tmp74Line = ".Model = "; //769:51
            if (!string.IsNullOrEmpty(__tmp74Line))
            {
                __out.Append(__tmp74Line);
                __tmp72OutputWritten = true;
            }
            StringBuilder __tmp75 = new StringBuilder();
            __tmp75.Append(model.CSharpInstancesName(ClassKind.Builder));
            using(StreamReader __tmp75Reader = new StreamReader(this.__ToStream(__tmp75.ToString())))
            {
                bool __tmp75_last = __tmp75Reader.EndOfStream;
                while(!__tmp75_last)
                {
                    string __tmp75Line = __tmp75Reader.ReadLine();
                    __tmp75_last = __tmp75Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp75Line))
                    {
                        __out.Append(__tmp75Line);
                        __tmp72OutputWritten = true;
                    }
                    if (!__tmp75_last) __out.AppendLine(true);
                }
            }
            string __tmp76Line = ".instance.Model.ToImmutable();"; //769:106
            if (!string.IsNullOrEmpty(__tmp76Line))
            {
                __out.Append(__tmp76Line);
                __tmp72OutputWritten = true;
            }
            if (__tmp72OutputWritten)
            {
                __out.AppendLine(false); //769:136
            }
            if (__tmp72OutputWritten)
            {
                __out.AppendLine(false); //769:136
            }
            bool __tmp78OutputWritten = false;
            string __tmp79Line = "		global::MetaDslx.Core.Immutable.ImmutableModel model = "; //770:1
            if (!string.IsNullOrEmpty(__tmp79Line))
            {
                __out.Append(__tmp79Line);
                __tmp78OutputWritten = true;
            }
            StringBuilder __tmp80 = new StringBuilder();
            __tmp80.Append(model.CSharpInstancesName(ClassKind.Immutable));
            using(StreamReader __tmp80Reader = new StreamReader(this.__ToStream(__tmp80.ToString())))
            {
                bool __tmp80_last = __tmp80Reader.EndOfStream;
                while(!__tmp80_last)
                {
                    string __tmp80Line = __tmp80Reader.ReadLine();
                    __tmp80_last = __tmp80Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp80Line))
                    {
                        __out.Append(__tmp80Line);
                        __tmp78OutputWritten = true;
                    }
                    if (!__tmp80_last) __out.AppendLine(true);
                }
            }
            string __tmp81Line = ".Model;"; //770:106
            if (!string.IsNullOrEmpty(__tmp81Line))
            {
                __out.Append(__tmp81Line);
                __tmp78OutputWritten = true;
            }
            if (__tmp78OutputWritten)
            {
                __out.AppendLine(false); //770:113
            }
            if (__tmp78OutputWritten)
            {
                __out.AppendLine(false); //770:113
            }
            if (coreModel) //771:4
            {
                bool __tmp83OutputWritten = false;
                string __tmp82Prefix = "		"; //772:1
                StringBuilder __tmp84 = new StringBuilder();
                __tmp84.Append(model.CSharpInstancesName(ClassKind.Immutable));
                using(StreamReader __tmp84Reader = new StreamReader(this.__ToStream(__tmp84.ToString())))
                {
                    bool __tmp84_last = __tmp84Reader.EndOfStream;
                    while(!__tmp84_last)
                    {
                        string __tmp84Line = __tmp84Reader.ReadLine();
                        __tmp84_last = __tmp84Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp82Prefix))
                        {
                            __out.Append(__tmp82Prefix);
                            __tmp83OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp84Line))
                        {
                            __out.Append(__tmp84Line);
                            __tmp83OutputWritten = true;
                        }
                        if (!__tmp84_last) __out.AppendLine(true);
                    }
                }
                string __tmp85Line = "._MetaModel = "; //772:51
                if (!string.IsNullOrEmpty(__tmp85Line))
                {
                    __out.Append(__tmp85Line);
                    __tmp83OutputWritten = true;
                }
                StringBuilder __tmp86 = new StringBuilder();
                __tmp86.Append(model.CSharpInstancesName(ClassKind.Builder));
                using(StreamReader __tmp86Reader = new StreamReader(this.__ToStream(__tmp86.ToString())))
                {
                    bool __tmp86_last = __tmp86Reader.EndOfStream;
                    while(!__tmp86_last)
                    {
                        string __tmp86Line = __tmp86Reader.ReadLine();
                        __tmp86_last = __tmp86Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp86Line))
                        {
                            __out.Append(__tmp86Line);
                            __tmp83OutputWritten = true;
                        }
                        if (!__tmp86_last) __out.AppendLine(true);
                    }
                }
                string __tmp87Line = ".instance._MetaModel.ToImmutable(model);"; //772:111
                if (!string.IsNullOrEmpty(__tmp87Line))
                {
                    __out.Append(__tmp87Line);
                    __tmp83OutputWritten = true;
                }
                if (__tmp83OutputWritten)
                {
                    __out.AppendLine(false); //772:151
                }
                if (__tmp83OutputWritten)
                {
                    __out.AppendLine(false); //772:151
                }
            }
            else //773:4
            {
                bool __tmp89OutputWritten = false;
                string __tmp88Prefix = "		"; //774:1
                StringBuilder __tmp90 = new StringBuilder();
                __tmp90.Append(model.CSharpInstancesName(ClassKind.Immutable));
                using(StreamReader __tmp90Reader = new StreamReader(this.__ToStream(__tmp90.ToString())))
                {
                    bool __tmp90_last = __tmp90Reader.EndOfStream;
                    while(!__tmp90_last)
                    {
                        string __tmp90Line = __tmp90Reader.ReadLine();
                        __tmp90_last = __tmp90Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp88Prefix))
                        {
                            __out.Append(__tmp88Prefix);
                            __tmp89OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp90Line))
                        {
                            __out.Append(__tmp90Line);
                            __tmp89OutputWritten = true;
                        }
                        if (!__tmp90_last) __out.AppendLine(true);
                    }
                }
                string __tmp91Line = ".MetaModel = "; //774:51
                if (!string.IsNullOrEmpty(__tmp91Line))
                {
                    __out.Append(__tmp91Line);
                    __tmp89OutputWritten = true;
                }
                StringBuilder __tmp92 = new StringBuilder();
                __tmp92.Append(model.CSharpInstancesName(ClassKind.Builder));
                using(StreamReader __tmp92Reader = new StreamReader(this.__ToStream(__tmp92.ToString())))
                {
                    bool __tmp92_last = __tmp92Reader.EndOfStream;
                    while(!__tmp92_last)
                    {
                        string __tmp92Line = __tmp92Reader.ReadLine();
                        __tmp92_last = __tmp92Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp92Line))
                        {
                            __out.Append(__tmp92Line);
                            __tmp89OutputWritten = true;
                        }
                        if (!__tmp92_last) __out.AppendLine(true);
                    }
                }
                string __tmp93Line = ".instance.MetaModel.ToImmutable(model);"; //774:110
                if (!string.IsNullOrEmpty(__tmp93Line))
                {
                    __out.Append(__tmp93Line);
                    __tmp89OutputWritten = true;
                }
                if (__tmp89OutputWritten)
                {
                    __out.AppendLine(false); //774:149
                }
                if (__tmp89OutputWritten)
                {
                    __out.AppendLine(false); //774:149
                }
            }
            __out.AppendLine(true); //776:1
            var __loop59_results = 
                (from mobj in __Enumerate((Instances).GetEnumerator()) //777:9
                where mobjToName.ContainsKey(mobj) && !mobjToName[mobj].StartsWith("__") //777:24
                select new { mobj = mobj}
                ).ToList(); //777:4
            for (int __loop59_iteration = 0; __loop59_iteration < __loop59_results.Count; ++__loop59_iteration)
            {
                var __tmp94 = __loop59_results[__loop59_iteration];
                var mobj = __tmp94.mobj;
                bool __tmp96OutputWritten = false;
                string __tmp95Prefix = "		"; //778:1
                StringBuilder __tmp97 = new StringBuilder();
                __tmp97.Append(GenerateImmutableModelObjectInstanceDeclarationInitializer(model, mobj, mobjToName));
                using(StreamReader __tmp97Reader = new StreamReader(this.__ToStream(__tmp97.ToString())))
                {
                    bool __tmp97_last = __tmp97Reader.EndOfStream;
                    while(!__tmp97_last)
                    {
                        string __tmp97Line = __tmp97Reader.ReadLine();
                        __tmp97_last = __tmp97Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp95Prefix))
                        {
                            __out.Append(__tmp95Prefix);
                            __tmp96OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp97Line))
                        {
                            __out.Append(__tmp97Line);
                            __tmp96OutputWritten = true;
                        }
                        if (__tmp96OutputWritten)
                        {
                            __out.AppendLine(false); //778:88
                        }
                    }
                }
                if (__tmp96OutputWritten)
                {
                    __out.AppendLine(false); //778:88
                }
            }
            __out.AppendLine(true); //780:1
            bool __tmp99OutputWritten = false;
            string __tmp98Prefix = "		"; //781:1
            StringBuilder __tmp100 = new StringBuilder();
            __tmp100.Append(model.CSharpInstancesName(ClassKind.Immutable));
            using(StreamReader __tmp100Reader = new StreamReader(this.__ToStream(__tmp100.ToString())))
            {
                bool __tmp100_last = __tmp100Reader.EndOfStream;
                while(!__tmp100_last)
                {
                    string __tmp100Line = __tmp100Reader.ReadLine();
                    __tmp100_last = __tmp100Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp98Prefix))
                    {
                        __out.Append(__tmp98Prefix);
                        __tmp99OutputWritten = true;
                    }
                    if (!string.IsNullOrEmpty(__tmp100Line))
                    {
                        __out.Append(__tmp100Line);
                        __tmp99OutputWritten = true;
                    }
                    if (!__tmp100_last) __out.AppendLine(true);
                }
            }
            string __tmp101Line = ".initialized = true;"; //781:51
            if (!string.IsNullOrEmpty(__tmp101Line))
            {
                __out.Append(__tmp101Line);
                __tmp99OutputWritten = true;
            }
            if (__tmp99OutputWritten)
            {
                __out.AppendLine(false); //781:71
            }
            if (__tmp99OutputWritten)
            {
                __out.AppendLine(false); //781:71
            }
            __out.Append("	}"); //782:1
            __out.AppendLine(false); //782:3
            __out.Append("}"); //783:1
            __out.AppendLine(false); //783:2
            return __out.ToString();
        }

        public string GenerateImmutableModelConstant(MetaModel model, MetaConstant mconst) //786:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2OutputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateDocumentation(mconst));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(!__tmp3_last)
                {
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp3Line))
                    {
                        __out.Append(__tmp3Line);
                        __tmp2OutputWritten = true;
                    }
                    if (__tmp2OutputWritten)
                    {
                        __out.AppendLine(false); //787:32
                    }
                }
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //787:32
            }
            bool __tmp5OutputWritten = false;
            string __tmp6Line = "public static readonly "; //788:1
            if (!string.IsNullOrEmpty(__tmp6Line))
            {
                __out.Append(__tmp6Line);
                __tmp5OutputWritten = true;
            }
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(mconst.Type.CSharpFullName(ClassKind.Immutable));
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(!__tmp7_last)
                {
                    string __tmp7Line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp7Line))
                    {
                        __out.Append(__tmp7Line);
                        __tmp5OutputWritten = true;
                    }
                    if (!__tmp7_last) __out.AppendLine(true);
                }
            }
            string __tmp8Line = " "; //788:73
            if (!string.IsNullOrEmpty(__tmp8Line))
            {
                __out.Append(__tmp8Line);
                __tmp5OutputWritten = true;
            }
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(mconst.Name);
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_last = __tmp9Reader.EndOfStream;
                while(!__tmp9_last)
                {
                    string __tmp9Line = __tmp9Reader.ReadLine();
                    __tmp9_last = __tmp9Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp9Line))
                    {
                        __out.Append(__tmp9Line);
                        __tmp5OutputWritten = true;
                    }
                    if (!__tmp9_last) __out.AppendLine(true);
                }
            }
            string __tmp10Line = " = "; //788:87
            if (!string.IsNullOrEmpty(__tmp10Line))
            {
                __out.Append(__tmp10Line);
                __tmp5OutputWritten = true;
            }
            StringBuilder __tmp11 = new StringBuilder();
            __tmp11.Append(model.CSharpInstancesName(ClassKind.Builder));
            using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
            {
                bool __tmp11_last = __tmp11Reader.EndOfStream;
                while(!__tmp11_last)
                {
                    string __tmp11Line = __tmp11Reader.ReadLine();
                    __tmp11_last = __tmp11Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp11Line))
                    {
                        __out.Append(__tmp11Line);
                        __tmp5OutputWritten = true;
                    }
                    if (!__tmp11_last) __out.AppendLine(true);
                }
            }
            string __tmp12Line = ".instance."; //788:136
            if (!string.IsNullOrEmpty(__tmp12Line))
            {
                __out.Append(__tmp12Line);
                __tmp5OutputWritten = true;
            }
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(mconst.Name);
            using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
            {
                bool __tmp13_last = __tmp13Reader.EndOfStream;
                while(!__tmp13_last)
                {
                    string __tmp13Line = __tmp13Reader.ReadLine();
                    __tmp13_last = __tmp13Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp13Line))
                    {
                        __out.Append(__tmp13Line);
                        __tmp5OutputWritten = true;
                    }
                    if (!__tmp13_last) __out.AppendLine(true);
                }
            }
            string __tmp14Line = ".ToImmutable();"; //788:159
            if (!string.IsNullOrEmpty(__tmp14Line))
            {
                __out.Append(__tmp14Line);
                __tmp5OutputWritten = true;
            }
            if (__tmp5OutputWritten)
            {
                __out.AppendLine(false); //788:174
            }
            if (__tmp5OutputWritten)
            {
                __out.AppendLine(false); //788:174
            }
            return __out.ToString();
        }

        public string GenerateModelConstant(MetaModel model, MetaConstant mconst) //791:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2OutputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateDocumentation(mconst));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(!__tmp3_last)
                {
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp3Line))
                    {
                        __out.Append(__tmp3Line);
                        __tmp2OutputWritten = true;
                    }
                    if (__tmp2OutputWritten)
                    {
                        __out.AppendLine(false); //792:32
                    }
                }
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //792:32
            }
            bool __tmp5OutputWritten = false;
            string __tmp6Line = "internal "; //793:1
            if (!string.IsNullOrEmpty(__tmp6Line))
            {
                __out.Append(__tmp6Line);
                __tmp5OutputWritten = true;
            }
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(mconst.Type.CSharpFullName(ClassKind.Builder));
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(!__tmp7_last)
                {
                    string __tmp7Line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp7Line))
                    {
                        __out.Append(__tmp7Line);
                        __tmp5OutputWritten = true;
                    }
                    if (!__tmp7_last) __out.AppendLine(true);
                }
            }
            string __tmp8Line = " "; //793:57
            if (!string.IsNullOrEmpty(__tmp8Line))
            {
                __out.Append(__tmp8Line);
                __tmp5OutputWritten = true;
            }
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(mconst.Name);
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_last = __tmp9Reader.EndOfStream;
                while(!__tmp9_last)
                {
                    string __tmp9Line = __tmp9Reader.ReadLine();
                    __tmp9_last = __tmp9Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp9Line))
                    {
                        __out.Append(__tmp9Line);
                        __tmp5OutputWritten = true;
                    }
                    if (!__tmp9_last) __out.AppendLine(true);
                }
            }
            string __tmp10Line = " = null;"; //793:71
            if (!string.IsNullOrEmpty(__tmp10Line))
            {
                __out.Append(__tmp10Line);
                __tmp5OutputWritten = true;
            }
            if (__tmp5OutputWritten)
            {
                __out.AppendLine(false); //793:79
            }
            if (__tmp5OutputWritten)
            {
                __out.AppendLine(false); //793:79
            }
            return __out.ToString();
        }

        public string GenerateImmutableModelObjectInstanceDeclaration(MetaModel model, ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //796:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //797:2
            {
                if (mobjToName.ContainsKey(mobj)) //798:3
                {
                    if (!mobjToName[mobj].StartsWith("__")) //799:4
                    {
                        string name = mobjToName[mobj]; //800:2
                        if (mobj is MetaDocumentedElement) //801:5
                        {
                            bool __tmp2OutputWritten = false;
                            StringBuilder __tmp3 = new StringBuilder();
                            __tmp3.Append(GenerateDocumentation(((MetaDocumentedElement)mobj)));
                            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                            {
                                bool __tmp3_last = __tmp3Reader.EndOfStream;
                                while(!__tmp3_last)
                                {
                                    string __tmp3Line = __tmp3Reader.ReadLine();
                                    __tmp3_last = __tmp3Reader.EndOfStream;
                                    if (!string.IsNullOrEmpty(__tmp3Line))
                                    {
                                        __out.Append(__tmp3Line);
                                        __tmp2OutputWritten = true;
                                    }
                                    if (__tmp2OutputWritten)
                                    {
                                        __out.AppendLine(false); //802:55
                                    }
                                }
                            }
                            if (__tmp2OutputWritten)
                            {
                                __out.AppendLine(false); //802:55
                            }
                        }
                        bool __tmp5OutputWritten = false;
                        string __tmp6Line = "public static readonly global::MetaDslx.Core.Immutable."; //804:1
                        if (!string.IsNullOrEmpty(__tmp6Line))
                        {
                            __out.Append(__tmp6Line);
                            __tmp5OutputWritten = true;
                        }
                        StringBuilder __tmp7 = new StringBuilder();
                        __tmp7.Append(mobj.MMetaClass.CSharpName(ClassKind.Immutable));
                        using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
                        {
                            bool __tmp7_last = __tmp7Reader.EndOfStream;
                            while(!__tmp7_last)
                            {
                                string __tmp7Line = __tmp7Reader.ReadLine();
                                __tmp7_last = __tmp7Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp7Line))
                                {
                                    __out.Append(__tmp7Line);
                                    __tmp5OutputWritten = true;
                                }
                                if (!__tmp7_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp8Line = " "; //804:105
                        if (!string.IsNullOrEmpty(__tmp8Line))
                        {
                            __out.Append(__tmp8Line);
                            __tmp5OutputWritten = true;
                        }
                        StringBuilder __tmp9 = new StringBuilder();
                        __tmp9.Append(name);
                        using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                        {
                            bool __tmp9_last = __tmp9Reader.EndOfStream;
                            while(!__tmp9_last)
                            {
                                string __tmp9Line = __tmp9Reader.ReadLine();
                                __tmp9_last = __tmp9Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp9Line))
                                {
                                    __out.Append(__tmp9Line);
                                    __tmp5OutputWritten = true;
                                }
                                if (!__tmp9_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp10Line = ";"; //804:112
                        if (!string.IsNullOrEmpty(__tmp10Line))
                        {
                            __out.Append(__tmp10Line);
                            __tmp5OutputWritten = true;
                        }
                        if (__tmp5OutputWritten)
                        {
                            __out.AppendLine(false); //804:113
                        }
                        if (__tmp5OutputWritten)
                        {
                            __out.AppendLine(false); //804:113
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateImmutableModelObjectInstanceDeclarationInitializer(MetaModel model, ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //810:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //811:2
            {
                if (mobjToName.ContainsKey(mobj)) //812:3
                {
                    if (!mobjToName[mobj].StartsWith("__")) //813:4
                    {
                        string name = mobjToName[mobj]; //814:2
                        bool __tmp2OutputWritten = false;
                        StringBuilder __tmp3 = new StringBuilder();
                        __tmp3.Append(model.CSharpInstancesName(ClassKind.Immutable));
                        using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                        {
                            bool __tmp3_last = __tmp3Reader.EndOfStream;
                            while(!__tmp3_last)
                            {
                                string __tmp3Line = __tmp3Reader.ReadLine();
                                __tmp3_last = __tmp3Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp3Line))
                                {
                                    __out.Append(__tmp3Line);
                                    __tmp2OutputWritten = true;
                                }
                                if (!__tmp3_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp4Line = "."; //815:49
                        if (!string.IsNullOrEmpty(__tmp4Line))
                        {
                            __out.Append(__tmp4Line);
                            __tmp2OutputWritten = true;
                        }
                        StringBuilder __tmp5 = new StringBuilder();
                        __tmp5.Append(name);
                        using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                        {
                            bool __tmp5_last = __tmp5Reader.EndOfStream;
                            while(!__tmp5_last)
                            {
                                string __tmp5Line = __tmp5Reader.ReadLine();
                                __tmp5_last = __tmp5Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp5Line))
                                {
                                    __out.Append(__tmp5Line);
                                    __tmp2OutputWritten = true;
                                }
                                if (!__tmp5_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp6Line = " = "; //815:56
                        if (!string.IsNullOrEmpty(__tmp6Line))
                        {
                            __out.Append(__tmp6Line);
                            __tmp2OutputWritten = true;
                        }
                        StringBuilder __tmp7 = new StringBuilder();
                        __tmp7.Append(model.CSharpInstancesName(ClassKind.Builder));
                        using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
                        {
                            bool __tmp7_last = __tmp7Reader.EndOfStream;
                            while(!__tmp7_last)
                            {
                                string __tmp7Line = __tmp7Reader.ReadLine();
                                __tmp7_last = __tmp7Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp7Line))
                                {
                                    __out.Append(__tmp7Line);
                                    __tmp2OutputWritten = true;
                                }
                                if (!__tmp7_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp8Line = ".instance."; //815:105
                        if (!string.IsNullOrEmpty(__tmp8Line))
                        {
                            __out.Append(__tmp8Line);
                            __tmp2OutputWritten = true;
                        }
                        StringBuilder __tmp9 = new StringBuilder();
                        __tmp9.Append(name);
                        using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                        {
                            bool __tmp9_last = __tmp9Reader.EndOfStream;
                            while(!__tmp9_last)
                            {
                                string __tmp9Line = __tmp9Reader.ReadLine();
                                __tmp9_last = __tmp9Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp9Line))
                                {
                                    __out.Append(__tmp9Line);
                                    __tmp2OutputWritten = true;
                                }
                                if (!__tmp9_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp10Line = ".ToImmutable(model);"; //815:121
                        if (!string.IsNullOrEmpty(__tmp10Line))
                        {
                            __out.Append(__tmp10Line);
                            __tmp2OutputWritten = true;
                        }
                        if (__tmp2OutputWritten)
                        {
                            __out.AppendLine(false); //815:141
                        }
                        if (__tmp2OutputWritten)
                        {
                            __out.AppendLine(false); //815:141
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceDeclaration(ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //821:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //822:2
            {
                if (mobjToName.ContainsKey(mobj)) //823:3
                {
                    string name = mobjToName[mobj]; //824:4
                    if (name.StartsWith("__")) //825:4
                    {
                        bool __tmp2OutputWritten = false;
                        string __tmp3Line = "private readonly global::MetaDslx.Core.Immutable."; //826:1
                        if (!string.IsNullOrEmpty(__tmp3Line))
                        {
                            __out.Append(__tmp3Line);
                            __tmp2OutputWritten = true;
                        }
                        StringBuilder __tmp4 = new StringBuilder();
                        __tmp4.Append(mobj.MMetaClass.CSharpName(ClassKind.Builder));
                        using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                        {
                            bool __tmp4_last = __tmp4Reader.EndOfStream;
                            while(!__tmp4_last)
                            {
                                string __tmp4Line = __tmp4Reader.ReadLine();
                                __tmp4_last = __tmp4Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp4Line))
                                {
                                    __out.Append(__tmp4Line);
                                    __tmp2OutputWritten = true;
                                }
                                if (!__tmp4_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp5Line = " "; //826:97
                        if (!string.IsNullOrEmpty(__tmp5Line))
                        {
                            __out.Append(__tmp5Line);
                            __tmp2OutputWritten = true;
                        }
                        StringBuilder __tmp6 = new StringBuilder();
                        __tmp6.Append(name);
                        using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
                        {
                            bool __tmp6_last = __tmp6Reader.EndOfStream;
                            while(!__tmp6_last)
                            {
                                string __tmp6Line = __tmp6Reader.ReadLine();
                                __tmp6_last = __tmp6Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp6Line))
                                {
                                    __out.Append(__tmp6Line);
                                    __tmp2OutputWritten = true;
                                }
                                if (!__tmp6_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp7Line = ";"; //826:104
                        if (!string.IsNullOrEmpty(__tmp7Line))
                        {
                            __out.Append(__tmp7Line);
                            __tmp2OutputWritten = true;
                        }
                        if (__tmp2OutputWritten)
                        {
                            __out.AppendLine(false); //826:105
                        }
                        if (__tmp2OutputWritten)
                        {
                            __out.AppendLine(false); //826:105
                        }
                    }
                    else //827:4
                    {
                        bool __tmp9OutputWritten = false;
                        string __tmp10Line = "internal readonly global::MetaDslx.Core.Immutable."; //828:1
                        if (!string.IsNullOrEmpty(__tmp10Line))
                        {
                            __out.Append(__tmp10Line);
                            __tmp9OutputWritten = true;
                        }
                        StringBuilder __tmp11 = new StringBuilder();
                        __tmp11.Append(mobj.MMetaClass.CSharpName(ClassKind.Builder));
                        using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                        {
                            bool __tmp11_last = __tmp11Reader.EndOfStream;
                            while(!__tmp11_last)
                            {
                                string __tmp11Line = __tmp11Reader.ReadLine();
                                __tmp11_last = __tmp11Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp11Line))
                                {
                                    __out.Append(__tmp11Line);
                                    __tmp9OutputWritten = true;
                                }
                                if (!__tmp11_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp12Line = " "; //828:98
                        if (!string.IsNullOrEmpty(__tmp12Line))
                        {
                            __out.Append(__tmp12Line);
                            __tmp9OutputWritten = true;
                        }
                        StringBuilder __tmp13 = new StringBuilder();
                        __tmp13.Append(name);
                        using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                        {
                            bool __tmp13_last = __tmp13Reader.EndOfStream;
                            while(!__tmp13_last)
                            {
                                string __tmp13Line = __tmp13Reader.ReadLine();
                                __tmp13_last = __tmp13Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp13Line))
                                {
                                    __out.Append(__tmp13Line);
                                    __tmp9OutputWritten = true;
                                }
                                if (!__tmp13_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp14Line = ";"; //828:105
                        if (!string.IsNullOrEmpty(__tmp14Line))
                        {
                            __out.Append(__tmp14Line);
                            __tmp9OutputWritten = true;
                        }
                        if (__tmp9OutputWritten)
                        {
                            __out.AppendLine(false); //828:106
                        }
                        if (__tmp9OutputWritten)
                        {
                            __out.AppendLine(false); //828:106
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstance(bool coreModel, ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //834:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //835:2
            {
                if (mobjToName.ContainsKey(mobj)) //836:3
                {
                    string name = mobjToName[mobj]; //837:4
                    bool __tmp2OutputWritten = false;
                    StringBuilder __tmp3 = new StringBuilder();
                    __tmp3.Append(name);
                    using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                    {
                        bool __tmp3_last = __tmp3Reader.EndOfStream;
                        while(!__tmp3_last)
                        {
                            string __tmp3Line = __tmp3Reader.ReadLine();
                            __tmp3_last = __tmp3Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp3Line))
                            {
                                __out.Append(__tmp3Line);
                                __tmp2OutputWritten = true;
                            }
                            if (!__tmp3_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp4Line = " = factory."; //838:7
                    if (!string.IsNullOrEmpty(__tmp4Line))
                    {
                        __out.Append(__tmp4Line);
                        __tmp2OutputWritten = true;
                    }
                    StringBuilder __tmp5 = new StringBuilder();
                    __tmp5.Append(mobj.MMetaClass.CSharpName());
                    using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                    {
                        bool __tmp5_last = __tmp5Reader.EndOfStream;
                        while(!__tmp5_last)
                        {
                            string __tmp5Line = __tmp5Reader.ReadLine();
                            __tmp5_last = __tmp5Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp5Line))
                            {
                                __out.Append(__tmp5Line);
                                __tmp2OutputWritten = true;
                            }
                            if (!__tmp5_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp6Line = "();"; //838:48
                    if (!string.IsNullOrEmpty(__tmp6Line))
                    {
                        __out.Append(__tmp6Line);
                        __tmp2OutputWritten = true;
                    }
                    if (__tmp2OutputWritten)
                    {
                        __out.AppendLine(false); //838:51
                    }
                    if (__tmp2OutputWritten)
                    {
                        __out.AppendLine(false); //838:51
                    }
                    if (mobj is MetaModel) //839:4
                    {
                        if (coreModel) //840:5
                        {
                            bool __tmp8OutputWritten = false;
                            string __tmp9Line = "_MetaModel = "; //841:1
                            if (!string.IsNullOrEmpty(__tmp9Line))
                            {
                                __out.Append(__tmp9Line);
                                __tmp8OutputWritten = true;
                            }
                            StringBuilder __tmp10 = new StringBuilder();
                            __tmp10.Append(name);
                            using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
                            {
                                bool __tmp10_last = __tmp10Reader.EndOfStream;
                                while(!__tmp10_last)
                                {
                                    string __tmp10Line = __tmp10Reader.ReadLine();
                                    __tmp10_last = __tmp10Reader.EndOfStream;
                                    if (!string.IsNullOrEmpty(__tmp10Line))
                                    {
                                        __out.Append(__tmp10Line);
                                        __tmp8OutputWritten = true;
                                    }
                                    if (!__tmp10_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp11Line = ";"; //841:20
                            if (!string.IsNullOrEmpty(__tmp11Line))
                            {
                                __out.Append(__tmp11Line);
                                __tmp8OutputWritten = true;
                            }
                            if (__tmp8OutputWritten)
                            {
                                __out.AppendLine(false); //841:21
                            }
                            if (__tmp8OutputWritten)
                            {
                                __out.AppendLine(false); //841:21
                            }
                        }
                        else //842:5
                        {
                            bool __tmp13OutputWritten = false;
                            string __tmp14Line = "MetaModel = "; //843:1
                            if (!string.IsNullOrEmpty(__tmp14Line))
                            {
                                __out.Append(__tmp14Line);
                                __tmp13OutputWritten = true;
                            }
                            StringBuilder __tmp15 = new StringBuilder();
                            __tmp15.Append(name);
                            using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
                            {
                                bool __tmp15_last = __tmp15Reader.EndOfStream;
                                while(!__tmp15_last)
                                {
                                    string __tmp15Line = __tmp15Reader.ReadLine();
                                    __tmp15_last = __tmp15Reader.EndOfStream;
                                    if (!string.IsNullOrEmpty(__tmp15Line))
                                    {
                                        __out.Append(__tmp15Line);
                                        __tmp13OutputWritten = true;
                                    }
                                    if (!__tmp15_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp16Line = ";"; //843:19
                            if (!string.IsNullOrEmpty(__tmp16Line))
                            {
                                __out.Append(__tmp16Line);
                                __tmp13OutputWritten = true;
                            }
                            if (__tmp13OutputWritten)
                            {
                                __out.AppendLine(false); //843:20
                            }
                            if (__tmp13OutputWritten)
                            {
                                __out.AppendLine(false); //843:20
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceInitializer(bool coreModel, ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //850:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //851:2
            {
                if (mobjToName.ContainsKey(mobj)) //852:3
                {
                    var __loop60_results = 
                        (from __loop60_var1 in __Enumerate((mobj).GetEnumerator()) //853:9
                        from prop in __Enumerate((__loop60_var1.MGetProperties()).GetEnumerator()) //853:15
                        where !prop.IsReadonly //853:37
                        select new { __loop60_var1 = __loop60_var1, prop = prop}
                        ).ToList(); //853:4
                    for (int __loop60_iteration = 0; __loop60_iteration < __loop60_results.Count; ++__loop60_iteration)
                    {
                        var __tmp1 = __loop60_results[__loop60_iteration];
                        var __loop60_var1 = __tmp1.__loop60_var1;
                        var prop = __tmp1.prop;
                        if (prop.MetaProperty != null && prop.MetaProperty.Kind != MetaPropertyKind.Derived) //854:5
                        {
                            object propValue = mobj.MGet(prop); //855:6
                            bool __tmp3OutputWritten = false;
                            StringBuilder __tmp4 = new StringBuilder();
                            __tmp4.Append(GenerateModelObjectPropertyValue(coreModel, mobj, prop, propValue, mobjToName));
                            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                            {
                                bool __tmp4_last = __tmp4Reader.EndOfStream;
                                while(!__tmp4_last)
                                {
                                    string __tmp4Line = __tmp4Reader.ReadLine();
                                    __tmp4_last = __tmp4Reader.EndOfStream;
                                    if (!string.IsNullOrEmpty(__tmp4Line))
                                    {
                                        __out.Append(__tmp4Line);
                                        __tmp3OutputWritten = true;
                                    }
                                    if (__tmp3OutputWritten)
                                    {
                                        __out.AppendLine(false); //856:81
                                    }
                                }
                            }
                            if (__tmp3OutputWritten)
                            {
                                __out.AppendLine(false); //856:81
                            }
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectInstanceFinalizer(ModelObject mobj, Dictionary<ModelObject,string> mobjToName) //863:1
        {
            StringBuilder __out = new StringBuilder();
            if (mobj != null && mobj.MMetaClass != null) //864:2
            {
                if (mobjToName.ContainsKey(mobj)) //865:3
                {
                    string name = mobjToName[mobj]; //866:4
                    bool __tmp2OutputWritten = false;
                    string __tmp3Line = "((global::MetaDslx.Core.Immutable.MutableSymbolBase)"; //867:1
                    if (!string.IsNullOrEmpty(__tmp3Line))
                    {
                        __out.Append(__tmp3Line);
                        __tmp2OutputWritten = true;
                    }
                    StringBuilder __tmp4 = new StringBuilder();
                    __tmp4.Append(name);
                    using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                    {
                        bool __tmp4_last = __tmp4Reader.EndOfStream;
                        while(!__tmp4_last)
                        {
                            string __tmp4Line = __tmp4Reader.ReadLine();
                            __tmp4_last = __tmp4Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp4Line))
                            {
                                __out.Append(__tmp4Line);
                                __tmp2OutputWritten = true;
                            }
                            if (!__tmp4_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp5Line = ").MMakeCreated();"; //867:59
                    if (!string.IsNullOrEmpty(__tmp5Line))
                    {
                        __out.Append(__tmp5Line);
                        __tmp2OutputWritten = true;
                    }
                    if (__tmp2OutputWritten)
                    {
                        __out.AppendLine(false); //867:76
                    }
                    if (__tmp2OutputWritten)
                    {
                        __out.AppendLine(false); //867:76
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectPropertyValue(bool coreModel, ModelObject mobj, ModelProperty prop, object value, Dictionary<ModelObject,string> mobjToName) //872:1
        {
            StringBuilder __out = new StringBuilder();
            string name = mobjToName[mobj]; //873:2
            ModelObject moValue = value as ModelObject; //874:2
            if (value == null) //875:2
            {
                if (prop.Type != null && prop.Type.IsClass) //876:3
                {
                    bool __tmp2OutputWritten = false;
                    StringBuilder __tmp3 = new StringBuilder();
                    __tmp3.Append(name);
                    using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                    {
                        bool __tmp3_last = __tmp3Reader.EndOfStream;
                        while(!__tmp3_last)
                        {
                            string __tmp3Line = __tmp3Reader.ReadLine();
                            __tmp3_last = __tmp3Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp3Line))
                            {
                                __out.Append(__tmp3Line);
                                __tmp2OutputWritten = true;
                            }
                            if (!__tmp3_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp4Line = "."; //877:7
                    if (!string.IsNullOrEmpty(__tmp4Line))
                    {
                        __out.Append(__tmp4Line);
                        __tmp2OutputWritten = true;
                    }
                    StringBuilder __tmp5 = new StringBuilder();
                    __tmp5.Append(prop.Name);
                    using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                    {
                        bool __tmp5_last = __tmp5Reader.EndOfStream;
                        while(!__tmp5_last)
                        {
                            string __tmp5Line = __tmp5Reader.ReadLine();
                            __tmp5_last = __tmp5Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp5Line))
                            {
                                __out.Append(__tmp5Line);
                                __tmp2OutputWritten = true;
                            }
                            if (!__tmp5_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp6Line = " = null;"; //877:19
                    if (!string.IsNullOrEmpty(__tmp6Line))
                    {
                        __out.Append(__tmp6Line);
                        __tmp2OutputWritten = true;
                    }
                    if (__tmp2OutputWritten)
                    {
                        __out.AppendLine(false); //877:27
                    }
                    if (__tmp2OutputWritten)
                    {
                        __out.AppendLine(false); //877:27
                    }
                }
                else //878:3
                {
                    bool __tmp8OutputWritten = false;
                    string __tmp9Line = "// "; //879:1
                    if (!string.IsNullOrEmpty(__tmp9Line))
                    {
                        __out.Append(__tmp9Line);
                        __tmp8OutputWritten = true;
                    }
                    StringBuilder __tmp10 = new StringBuilder();
                    __tmp10.Append(name);
                    using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
                    {
                        bool __tmp10_last = __tmp10Reader.EndOfStream;
                        while(!__tmp10_last)
                        {
                            string __tmp10Line = __tmp10Reader.ReadLine();
                            __tmp10_last = __tmp10Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp10Line))
                            {
                                __out.Append(__tmp10Line);
                                __tmp8OutputWritten = true;
                            }
                            if (!__tmp10_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp11Line = "."; //879:10
                    if (!string.IsNullOrEmpty(__tmp11Line))
                    {
                        __out.Append(__tmp11Line);
                        __tmp8OutputWritten = true;
                    }
                    StringBuilder __tmp12 = new StringBuilder();
                    __tmp12.Append(prop.Name);
                    using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
                    {
                        bool __tmp12_last = __tmp12Reader.EndOfStream;
                        while(!__tmp12_last)
                        {
                            string __tmp12Line = __tmp12Reader.ReadLine();
                            __tmp12_last = __tmp12Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp12Line))
                            {
                                __out.Append(__tmp12Line);
                                __tmp8OutputWritten = true;
                            }
                            if (!__tmp12_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp13Line = " = null;"; //879:22
                    if (!string.IsNullOrEmpty(__tmp13Line))
                    {
                        __out.Append(__tmp13Line);
                        __tmp8OutputWritten = true;
                    }
                    if (__tmp8OutputWritten)
                    {
                        __out.AppendLine(false); //879:30
                    }
                    if (__tmp8OutputWritten)
                    {
                        __out.AppendLine(false); //879:30
                    }
                }
            }
            else if (value is string) //881:2
            {
                bool __tmp15OutputWritten = false;
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(name);
                using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
                {
                    bool __tmp16_last = __tmp16Reader.EndOfStream;
                    while(!__tmp16_last)
                    {
                        string __tmp16Line = __tmp16Reader.ReadLine();
                        __tmp16_last = __tmp16Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp16Line))
                        {
                            __out.Append(__tmp16Line);
                            __tmp15OutputWritten = true;
                        }
                        if (!__tmp16_last) __out.AppendLine(true);
                    }
                }
                string __tmp17Line = "."; //882:7
                if (!string.IsNullOrEmpty(__tmp17Line))
                {
                    __out.Append(__tmp17Line);
                    __tmp15OutputWritten = true;
                }
                StringBuilder __tmp18 = new StringBuilder();
                __tmp18.Append(prop.Name);
                using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
                {
                    bool __tmp18_last = __tmp18Reader.EndOfStream;
                    while(!__tmp18_last)
                    {
                        string __tmp18Line = __tmp18Reader.ReadLine();
                        __tmp18_last = __tmp18Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp18Line))
                        {
                            __out.Append(__tmp18Line);
                            __tmp15OutputWritten = true;
                        }
                        if (!__tmp18_last) __out.AppendLine(true);
                    }
                }
                string __tmp19Line = " = \""; //882:19
                if (!string.IsNullOrEmpty(__tmp19Line))
                {
                    __out.Append(__tmp19Line);
                    __tmp15OutputWritten = true;
                }
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(value);
                using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
                {
                    bool __tmp20_last = __tmp20Reader.EndOfStream;
                    while(!__tmp20_last)
                    {
                        string __tmp20Line = __tmp20Reader.ReadLine();
                        __tmp20_last = __tmp20Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp20Line))
                        {
                            __out.Append(__tmp20Line);
                            __tmp15OutputWritten = true;
                        }
                        if (!__tmp20_last) __out.AppendLine(true);
                    }
                }
                string __tmp21Line = "\";"; //882:30
                if (!string.IsNullOrEmpty(__tmp21Line))
                {
                    __out.Append(__tmp21Line);
                    __tmp15OutputWritten = true;
                }
                if (__tmp15OutputWritten)
                {
                    __out.AppendLine(false); //882:32
                }
                if (__tmp15OutputWritten)
                {
                    __out.AppendLine(false); //882:32
                }
            }
            else if (value is bool) //883:2
            {
                bool __tmp23OutputWritten = false;
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(name);
                using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
                {
                    bool __tmp24_last = __tmp24Reader.EndOfStream;
                    while(!__tmp24_last)
                    {
                        string __tmp24Line = __tmp24Reader.ReadLine();
                        __tmp24_last = __tmp24Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp24Line))
                        {
                            __out.Append(__tmp24Line);
                            __tmp23OutputWritten = true;
                        }
                        if (!__tmp24_last) __out.AppendLine(true);
                    }
                }
                string __tmp25Line = "."; //884:7
                if (!string.IsNullOrEmpty(__tmp25Line))
                {
                    __out.Append(__tmp25Line);
                    __tmp23OutputWritten = true;
                }
                StringBuilder __tmp26 = new StringBuilder();
                __tmp26.Append(prop.Name);
                using(StreamReader __tmp26Reader = new StreamReader(this.__ToStream(__tmp26.ToString())))
                {
                    bool __tmp26_last = __tmp26Reader.EndOfStream;
                    while(!__tmp26_last)
                    {
                        string __tmp26Line = __tmp26Reader.ReadLine();
                        __tmp26_last = __tmp26Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp26Line))
                        {
                            __out.Append(__tmp26Line);
                            __tmp23OutputWritten = true;
                        }
                        if (!__tmp26_last) __out.AppendLine(true);
                    }
                }
                string __tmp27Line = " = "; //884:19
                if (!string.IsNullOrEmpty(__tmp27Line))
                {
                    __out.Append(__tmp27Line);
                    __tmp23OutputWritten = true;
                }
                StringBuilder __tmp28 = new StringBuilder();
                __tmp28.Append(value.ToString().ToLower());
                using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
                {
                    bool __tmp28_last = __tmp28Reader.EndOfStream;
                    while(!__tmp28_last)
                    {
                        string __tmp28Line = __tmp28Reader.ReadLine();
                        __tmp28_last = __tmp28Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp28Line))
                        {
                            __out.Append(__tmp28Line);
                            __tmp23OutputWritten = true;
                        }
                        if (!__tmp28_last) __out.AppendLine(true);
                    }
                }
                string __tmp29Line = ";"; //884:50
                if (!string.IsNullOrEmpty(__tmp29Line))
                {
                    __out.Append(__tmp29Line);
                    __tmp23OutputWritten = true;
                }
                if (__tmp23OutputWritten)
                {
                    __out.AppendLine(false); //884:51
                }
                if (__tmp23OutputWritten)
                {
                    __out.AppendLine(false); //884:51
                }
            }
            else if (value.GetType().IsPrimitive) //885:2
            {
                bool __tmp31OutputWritten = false;
                StringBuilder __tmp32 = new StringBuilder();
                __tmp32.Append(name);
                using(StreamReader __tmp32Reader = new StreamReader(this.__ToStream(__tmp32.ToString())))
                {
                    bool __tmp32_last = __tmp32Reader.EndOfStream;
                    while(!__tmp32_last)
                    {
                        string __tmp32Line = __tmp32Reader.ReadLine();
                        __tmp32_last = __tmp32Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp32Line))
                        {
                            __out.Append(__tmp32Line);
                            __tmp31OutputWritten = true;
                        }
                        if (!__tmp32_last) __out.AppendLine(true);
                    }
                }
                string __tmp33Line = "."; //886:7
                if (!string.IsNullOrEmpty(__tmp33Line))
                {
                    __out.Append(__tmp33Line);
                    __tmp31OutputWritten = true;
                }
                StringBuilder __tmp34 = new StringBuilder();
                __tmp34.Append(prop.Name);
                using(StreamReader __tmp34Reader = new StreamReader(this.__ToStream(__tmp34.ToString())))
                {
                    bool __tmp34_last = __tmp34Reader.EndOfStream;
                    while(!__tmp34_last)
                    {
                        string __tmp34Line = __tmp34Reader.ReadLine();
                        __tmp34_last = __tmp34Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp34Line))
                        {
                            __out.Append(__tmp34Line);
                            __tmp31OutputWritten = true;
                        }
                        if (!__tmp34_last) __out.AppendLine(true);
                    }
                }
                string __tmp35Line = " = "; //886:19
                if (!string.IsNullOrEmpty(__tmp35Line))
                {
                    __out.Append(__tmp35Line);
                    __tmp31OutputWritten = true;
                }
                StringBuilder __tmp36 = new StringBuilder();
                __tmp36.Append(value.ToString());
                using(StreamReader __tmp36Reader = new StreamReader(this.__ToStream(__tmp36.ToString())))
                {
                    bool __tmp36_last = __tmp36Reader.EndOfStream;
                    while(!__tmp36_last)
                    {
                        string __tmp36Line = __tmp36Reader.ReadLine();
                        __tmp36_last = __tmp36Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp36Line))
                        {
                            __out.Append(__tmp36Line);
                            __tmp31OutputWritten = true;
                        }
                        if (!__tmp36_last) __out.AppendLine(true);
                    }
                }
                string __tmp37Line = ";"; //886:40
                if (!string.IsNullOrEmpty(__tmp37Line))
                {
                    __out.Append(__tmp37Line);
                    __tmp31OutputWritten = true;
                }
                if (__tmp31OutputWritten)
                {
                    __out.AppendLine(false); //886:41
                }
                if (__tmp31OutputWritten)
                {
                    __out.AppendLine(false); //886:41
                }
            }
            else if (MetaBuiltInTypes.Types.Contains(value)) //887:2
            {
                if (coreModel) //888:3
                {
                    if (mobjToName.ContainsKey(moValue)) //889:4
                    {
                        bool __tmp39OutputWritten = false;
                        StringBuilder __tmp40 = new StringBuilder();
                        __tmp40.Append(name);
                        using(StreamReader __tmp40Reader = new StreamReader(this.__ToStream(__tmp40.ToString())))
                        {
                            bool __tmp40_last = __tmp40Reader.EndOfStream;
                            while(!__tmp40_last)
                            {
                                string __tmp40Line = __tmp40Reader.ReadLine();
                                __tmp40_last = __tmp40Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp40Line))
                                {
                                    __out.Append(__tmp40Line);
                                    __tmp39OutputWritten = true;
                                }
                                if (!__tmp40_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp41Line = "."; //890:7
                        if (!string.IsNullOrEmpty(__tmp41Line))
                        {
                            __out.Append(__tmp41Line);
                            __tmp39OutputWritten = true;
                        }
                        StringBuilder __tmp42 = new StringBuilder();
                        __tmp42.Append(prop.Name);
                        using(StreamReader __tmp42Reader = new StreamReader(this.__ToStream(__tmp42.ToString())))
                        {
                            bool __tmp42_last = __tmp42Reader.EndOfStream;
                            while(!__tmp42_last)
                            {
                                string __tmp42Line = __tmp42Reader.ReadLine();
                                __tmp42_last = __tmp42Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp42Line))
                                {
                                    __out.Append(__tmp42Line);
                                    __tmp39OutputWritten = true;
                                }
                                if (!__tmp42_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp43Line = "Lazy = () => "; //890:19
                        if (!string.IsNullOrEmpty(__tmp43Line))
                        {
                            __out.Append(__tmp43Line);
                            __tmp39OutputWritten = true;
                        }
                        StringBuilder __tmp44 = new StringBuilder();
                        __tmp44.Append(mobjToName[moValue]);
                        using(StreamReader __tmp44Reader = new StreamReader(this.__ToStream(__tmp44.ToString())))
                        {
                            bool __tmp44_last = __tmp44Reader.EndOfStream;
                            while(!__tmp44_last)
                            {
                                string __tmp44Line = __tmp44Reader.ReadLine();
                                __tmp44_last = __tmp44Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp44Line))
                                {
                                    __out.Append(__tmp44Line);
                                    __tmp39OutputWritten = true;
                                }
                                if (!__tmp44_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp45Line = ";"; //890:53
                        if (!string.IsNullOrEmpty(__tmp45Line))
                        {
                            __out.Append(__tmp45Line);
                            __tmp39OutputWritten = true;
                        }
                        if (__tmp39OutputWritten)
                        {
                            __out.AppendLine(false); //890:54
                        }
                        if (__tmp39OutputWritten)
                        {
                            __out.AppendLine(false); //890:54
                        }
                    }
                    else //891:4
                    {
                        bool __tmp47OutputWritten = false;
                        StringBuilder __tmp48 = new StringBuilder();
                        __tmp48.Append(name);
                        using(StreamReader __tmp48Reader = new StreamReader(this.__ToStream(__tmp48.ToString())))
                        {
                            bool __tmp48_last = __tmp48Reader.EndOfStream;
                            while(!__tmp48_last)
                            {
                                string __tmp48Line = __tmp48Reader.ReadLine();
                                __tmp48_last = __tmp48Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp48Line))
                                {
                                    __out.Append(__tmp48Line);
                                    __tmp47OutputWritten = true;
                                }
                                if (!__tmp48_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp49Line = "."; //892:7
                        if (!string.IsNullOrEmpty(__tmp49Line))
                        {
                            __out.Append(__tmp49Line);
                            __tmp47OutputWritten = true;
                        }
                        StringBuilder __tmp50 = new StringBuilder();
                        __tmp50.Append(prop.Name);
                        using(StreamReader __tmp50Reader = new StreamReader(this.__ToStream(__tmp50.ToString())))
                        {
                            bool __tmp50_last = __tmp50Reader.EndOfStream;
                            while(!__tmp50_last)
                            {
                                string __tmp50Line = __tmp50Reader.ReadLine();
                                __tmp50_last = __tmp50Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp50Line))
                                {
                                    __out.Append(__tmp50Line);
                                    __tmp47OutputWritten = true;
                                }
                                if (!__tmp50_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp51Line = "Lazy = () => this."; //892:19
                        if (!string.IsNullOrEmpty(__tmp51Line))
                        {
                            __out.Append(__tmp51Line);
                            __tmp47OutputWritten = true;
                        }
                        StringBuilder __tmp52 = new StringBuilder();
                        __tmp52.Append(((MetaPrimitiveType)moValue).Name.ToPascalCase());
                        using(StreamReader __tmp52Reader = new StreamReader(this.__ToStream(__tmp52.ToString())))
                        {
                            bool __tmp52_last = __tmp52Reader.EndOfStream;
                            while(!__tmp52_last)
                            {
                                string __tmp52Line = __tmp52Reader.ReadLine();
                                __tmp52_last = __tmp52Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp52Line))
                                {
                                    __out.Append(__tmp52Line);
                                    __tmp47OutputWritten = true;
                                }
                                if (!__tmp52_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp53Line = ";"; //892:87
                        if (!string.IsNullOrEmpty(__tmp53Line))
                        {
                            __out.Append(__tmp53Line);
                            __tmp47OutputWritten = true;
                        }
                        if (__tmp47OutputWritten)
                        {
                            __out.AppendLine(false); //892:88
                        }
                        if (__tmp47OutputWritten)
                        {
                            __out.AppendLine(false); //892:88
                        }
                    }
                }
                else //894:3
                {
                    bool __tmp55OutputWritten = false;
                    StringBuilder __tmp56 = new StringBuilder();
                    __tmp56.Append(name);
                    using(StreamReader __tmp56Reader = new StreamReader(this.__ToStream(__tmp56.ToString())))
                    {
                        bool __tmp56_last = __tmp56Reader.EndOfStream;
                        while(!__tmp56_last)
                        {
                            string __tmp56Line = __tmp56Reader.ReadLine();
                            __tmp56_last = __tmp56Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp56Line))
                            {
                                __out.Append(__tmp56Line);
                                __tmp55OutputWritten = true;
                            }
                            if (!__tmp56_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp57Line = "."; //895:7
                    if (!string.IsNullOrEmpty(__tmp57Line))
                    {
                        __out.Append(__tmp57Line);
                        __tmp55OutputWritten = true;
                    }
                    StringBuilder __tmp58 = new StringBuilder();
                    __tmp58.Append(prop.Name);
                    using(StreamReader __tmp58Reader = new StreamReader(this.__ToStream(__tmp58.ToString())))
                    {
                        bool __tmp58_last = __tmp58Reader.EndOfStream;
                        while(!__tmp58_last)
                        {
                            string __tmp58Line = __tmp58Reader.ReadLine();
                            __tmp58_last = __tmp58Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp58Line))
                            {
                                __out.Append(__tmp58Line);
                                __tmp55OutputWritten = true;
                            }
                            if (!__tmp58_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp59Line = " = "; //895:19
                    if (!string.IsNullOrEmpty(__tmp59Line))
                    {
                        __out.Append(__tmp59Line);
                        __tmp55OutputWritten = true;
                    }
                    StringBuilder __tmp60 = new StringBuilder();
                    __tmp60.Append(GenerateTypeOf(value));
                    using(StreamReader __tmp60Reader = new StreamReader(this.__ToStream(__tmp60.ToString())))
                    {
                        bool __tmp60_last = __tmp60Reader.EndOfStream;
                        while(!__tmp60_last)
                        {
                            string __tmp60Line = __tmp60Reader.ReadLine();
                            __tmp60_last = __tmp60Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp60Line))
                            {
                                __out.Append(__tmp60Line);
                                __tmp55OutputWritten = true;
                            }
                            if (!__tmp60_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp61Line = ";"; //895:45
                    if (!string.IsNullOrEmpty(__tmp61Line))
                    {
                        __out.Append(__tmp61Line);
                        __tmp55OutputWritten = true;
                    }
                    if (__tmp55OutputWritten)
                    {
                        __out.AppendLine(false); //895:46
                    }
                    if (__tmp55OutputWritten)
                    {
                        __out.AppendLine(false); //895:46
                    }
                }
            }
            else if (value is MetaPrimitiveType) //897:2
            {
                if (coreModel) //898:3
                {
                    bool __tmp63OutputWritten = false;
                    StringBuilder __tmp64 = new StringBuilder();
                    __tmp64.Append(name);
                    using(StreamReader __tmp64Reader = new StreamReader(this.__ToStream(__tmp64.ToString())))
                    {
                        bool __tmp64_last = __tmp64Reader.EndOfStream;
                        while(!__tmp64_last)
                        {
                            string __tmp64Line = __tmp64Reader.ReadLine();
                            __tmp64_last = __tmp64Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp64Line))
                            {
                                __out.Append(__tmp64Line);
                                __tmp63OutputWritten = true;
                            }
                            if (!__tmp64_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp65Line = "."; //899:7
                    if (!string.IsNullOrEmpty(__tmp65Line))
                    {
                        __out.Append(__tmp65Line);
                        __tmp63OutputWritten = true;
                    }
                    StringBuilder __tmp66 = new StringBuilder();
                    __tmp66.Append(prop.Name);
                    using(StreamReader __tmp66Reader = new StreamReader(this.__ToStream(__tmp66.ToString())))
                    {
                        bool __tmp66_last = __tmp66Reader.EndOfStream;
                        while(!__tmp66_last)
                        {
                            string __tmp66Line = __tmp66Reader.ReadLine();
                            __tmp66_last = __tmp66Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp66Line))
                            {
                                __out.Append(__tmp66Line);
                                __tmp63OutputWritten = true;
                            }
                            if (!__tmp66_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp67Line = "Lazy = () => "; //899:19
                    if (!string.IsNullOrEmpty(__tmp67Line))
                    {
                        __out.Append(__tmp67Line);
                        __tmp63OutputWritten = true;
                    }
                    StringBuilder __tmp68 = new StringBuilder();
                    __tmp68.Append(mobjToName[moValue]);
                    using(StreamReader __tmp68Reader = new StreamReader(this.__ToStream(__tmp68.ToString())))
                    {
                        bool __tmp68_last = __tmp68Reader.EndOfStream;
                        while(!__tmp68_last)
                        {
                            string __tmp68Line = __tmp68Reader.ReadLine();
                            __tmp68_last = __tmp68Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp68Line))
                            {
                                __out.Append(__tmp68Line);
                                __tmp63OutputWritten = true;
                            }
                            if (!__tmp68_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp69Line = ";"; //899:53
                    if (!string.IsNullOrEmpty(__tmp69Line))
                    {
                        __out.Append(__tmp69Line);
                        __tmp63OutputWritten = true;
                    }
                    if (__tmp63OutputWritten)
                    {
                        __out.AppendLine(false); //899:54
                    }
                    if (__tmp63OutputWritten)
                    {
                        __out.AppendLine(false); //899:54
                    }
                }
                else //900:3
                {
                    bool __tmp71OutputWritten = false;
                    StringBuilder __tmp72 = new StringBuilder();
                    __tmp72.Append(name);
                    using(StreamReader __tmp72Reader = new StreamReader(this.__ToStream(__tmp72.ToString())))
                    {
                        bool __tmp72_last = __tmp72Reader.EndOfStream;
                        while(!__tmp72_last)
                        {
                            string __tmp72Line = __tmp72Reader.ReadLine();
                            __tmp72_last = __tmp72Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp72Line))
                            {
                                __out.Append(__tmp72Line);
                                __tmp71OutputWritten = true;
                            }
                            if (!__tmp72_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp73Line = "."; //901:7
                    if (!string.IsNullOrEmpty(__tmp73Line))
                    {
                        __out.Append(__tmp73Line);
                        __tmp71OutputWritten = true;
                    }
                    StringBuilder __tmp74 = new StringBuilder();
                    __tmp74.Append(prop.Name);
                    using(StreamReader __tmp74Reader = new StreamReader(this.__ToStream(__tmp74.ToString())))
                    {
                        bool __tmp74_last = __tmp74Reader.EndOfStream;
                        while(!__tmp74_last)
                        {
                            string __tmp74Line = __tmp74Reader.ReadLine();
                            __tmp74_last = __tmp74Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp74Line))
                            {
                                __out.Append(__tmp74Line);
                                __tmp71OutputWritten = true;
                            }
                            if (!__tmp74_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp75Line = " = "; //901:19
                    if (!string.IsNullOrEmpty(__tmp75Line))
                    {
                        __out.Append(__tmp75Line);
                        __tmp71OutputWritten = true;
                    }
                    StringBuilder __tmp76 = new StringBuilder();
                    __tmp76.Append(GenerateTypeOf(value));
                    using(StreamReader __tmp76Reader = new StreamReader(this.__ToStream(__tmp76.ToString())))
                    {
                        bool __tmp76_last = __tmp76Reader.EndOfStream;
                        while(!__tmp76_last)
                        {
                            string __tmp76Line = __tmp76Reader.ReadLine();
                            __tmp76_last = __tmp76Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp76Line))
                            {
                                __out.Append(__tmp76Line);
                                __tmp71OutputWritten = true;
                            }
                            if (!__tmp76_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp77Line = ";"; //901:45
                    if (!string.IsNullOrEmpty(__tmp77Line))
                    {
                        __out.Append(__tmp77Line);
                        __tmp71OutputWritten = true;
                    }
                    if (__tmp71OutputWritten)
                    {
                        __out.AppendLine(false); //901:46
                    }
                    if (__tmp71OutputWritten)
                    {
                        __out.AppendLine(false); //901:46
                    }
                }
            }
            else if (value is Enum) //903:2
            {
                bool __tmp79OutputWritten = false;
                StringBuilder __tmp80 = new StringBuilder();
                __tmp80.Append(name);
                using(StreamReader __tmp80Reader = new StreamReader(this.__ToStream(__tmp80.ToString())))
                {
                    bool __tmp80_last = __tmp80Reader.EndOfStream;
                    while(!__tmp80_last)
                    {
                        string __tmp80Line = __tmp80Reader.ReadLine();
                        __tmp80_last = __tmp80Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp80Line))
                        {
                            __out.Append(__tmp80Line);
                            __tmp79OutputWritten = true;
                        }
                        if (!__tmp80_last) __out.AppendLine(true);
                    }
                }
                string __tmp81Line = "."; //904:7
                if (!string.IsNullOrEmpty(__tmp81Line))
                {
                    __out.Append(__tmp81Line);
                    __tmp79OutputWritten = true;
                }
                StringBuilder __tmp82 = new StringBuilder();
                __tmp82.Append(prop.Name);
                using(StreamReader __tmp82Reader = new StreamReader(this.__ToStream(__tmp82.ToString())))
                {
                    bool __tmp82_last = __tmp82Reader.EndOfStream;
                    while(!__tmp82_last)
                    {
                        string __tmp82Line = __tmp82Reader.ReadLine();
                        __tmp82_last = __tmp82Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp82Line))
                        {
                            __out.Append(__tmp82Line);
                            __tmp79OutputWritten = true;
                        }
                        if (!__tmp82_last) __out.AppendLine(true);
                    }
                }
                string __tmp83Line = " = "; //904:19
                if (!string.IsNullOrEmpty(__tmp83Line))
                {
                    __out.Append(__tmp83Line);
                    __tmp79OutputWritten = true;
                }
                StringBuilder __tmp84 = new StringBuilder();
                __tmp84.Append(GetEnumValueOf(value));
                using(StreamReader __tmp84Reader = new StreamReader(this.__ToStream(__tmp84.ToString())))
                {
                    bool __tmp84_last = __tmp84Reader.EndOfStream;
                    while(!__tmp84_last)
                    {
                        string __tmp84Line = __tmp84Reader.ReadLine();
                        __tmp84_last = __tmp84Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp84Line))
                        {
                            __out.Append(__tmp84Line);
                            __tmp79OutputWritten = true;
                        }
                        if (!__tmp84_last) __out.AppendLine(true);
                    }
                }
                string __tmp85Line = ";"; //904:45
                if (!string.IsNullOrEmpty(__tmp85Line))
                {
                    __out.Append(__tmp85Line);
                    __tmp79OutputWritten = true;
                }
                if (__tmp79OutputWritten)
                {
                    __out.AppendLine(false); //904:46
                }
                if (__tmp79OutputWritten)
                {
                    __out.AppendLine(false); //904:46
                }
            }
            else if (moValue != null) //905:2
            {
                if (mobjToName.ContainsKey(moValue)) //906:3
                {
                    bool __tmp87OutputWritten = false;
                    StringBuilder __tmp88 = new StringBuilder();
                    __tmp88.Append(name);
                    using(StreamReader __tmp88Reader = new StreamReader(this.__ToStream(__tmp88.ToString())))
                    {
                        bool __tmp88_last = __tmp88Reader.EndOfStream;
                        while(!__tmp88_last)
                        {
                            string __tmp88Line = __tmp88Reader.ReadLine();
                            __tmp88_last = __tmp88Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp88Line))
                            {
                                __out.Append(__tmp88Line);
                                __tmp87OutputWritten = true;
                            }
                            if (!__tmp88_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp89Line = "."; //907:7
                    if (!string.IsNullOrEmpty(__tmp89Line))
                    {
                        __out.Append(__tmp89Line);
                        __tmp87OutputWritten = true;
                    }
                    StringBuilder __tmp90 = new StringBuilder();
                    __tmp90.Append(prop.Name);
                    using(StreamReader __tmp90Reader = new StreamReader(this.__ToStream(__tmp90.ToString())))
                    {
                        bool __tmp90_last = __tmp90Reader.EndOfStream;
                        while(!__tmp90_last)
                        {
                            string __tmp90Line = __tmp90Reader.ReadLine();
                            __tmp90_last = __tmp90Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp90Line))
                            {
                                __out.Append(__tmp90Line);
                                __tmp87OutputWritten = true;
                            }
                            if (!__tmp90_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp91Line = "Lazy = () => "; //907:19
                    if (!string.IsNullOrEmpty(__tmp91Line))
                    {
                        __out.Append(__tmp91Line);
                        __tmp87OutputWritten = true;
                    }
                    StringBuilder __tmp92 = new StringBuilder();
                    __tmp92.Append(mobjToName[moValue]);
                    using(StreamReader __tmp92Reader = new StreamReader(this.__ToStream(__tmp92.ToString())))
                    {
                        bool __tmp92_last = __tmp92Reader.EndOfStream;
                        while(!__tmp92_last)
                        {
                            string __tmp92Line = __tmp92Reader.ReadLine();
                            __tmp92_last = __tmp92Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp92Line))
                            {
                                __out.Append(__tmp92Line);
                                __tmp87OutputWritten = true;
                            }
                            if (!__tmp92_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp93Line = ";"; //907:53
                    if (!string.IsNullOrEmpty(__tmp93Line))
                    {
                        __out.Append(__tmp93Line);
                        __tmp87OutputWritten = true;
                    }
                    if (__tmp87OutputWritten)
                    {
                        __out.AppendLine(false); //907:54
                    }
                    if (__tmp87OutputWritten)
                    {
                        __out.AppendLine(false); //907:54
                    }
                }
                else //908:3
                {
                    bool __tmp95OutputWritten = false;
                    string __tmp96Line = "// Omitted since not part of the model: "; //909:1
                    if (!string.IsNullOrEmpty(__tmp96Line))
                    {
                        __out.Append(__tmp96Line);
                        __tmp95OutputWritten = true;
                    }
                    StringBuilder __tmp97 = new StringBuilder();
                    __tmp97.Append(name);
                    using(StreamReader __tmp97Reader = new StreamReader(this.__ToStream(__tmp97.ToString())))
                    {
                        bool __tmp97_last = __tmp97Reader.EndOfStream;
                        while(!__tmp97_last)
                        {
                            string __tmp97Line = __tmp97Reader.ReadLine();
                            __tmp97_last = __tmp97Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp97Line))
                            {
                                __out.Append(__tmp97Line);
                                __tmp95OutputWritten = true;
                            }
                            if (!__tmp97_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp98Line = "."; //909:47
                    if (!string.IsNullOrEmpty(__tmp98Line))
                    {
                        __out.Append(__tmp98Line);
                        __tmp95OutputWritten = true;
                    }
                    StringBuilder __tmp99 = new StringBuilder();
                    __tmp99.Append(prop.Name);
                    using(StreamReader __tmp99Reader = new StreamReader(this.__ToStream(__tmp99.ToString())))
                    {
                        bool __tmp99_last = __tmp99Reader.EndOfStream;
                        while(!__tmp99_last)
                        {
                            string __tmp99Line = __tmp99Reader.ReadLine();
                            __tmp99_last = __tmp99Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp99Line))
                            {
                                __out.Append(__tmp99Line);
                                __tmp95OutputWritten = true;
                            }
                            if (!__tmp99_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp100Line = " = "; //909:59
                    if (!string.IsNullOrEmpty(__tmp100Line))
                    {
                        __out.Append(__tmp100Line);
                        __tmp95OutputWritten = true;
                    }
                    StringBuilder __tmp101 = new StringBuilder();
                    __tmp101.Append(moValue);
                    using(StreamReader __tmp101Reader = new StreamReader(this.__ToStream(__tmp101.ToString())))
                    {
                        bool __tmp101_last = __tmp101Reader.EndOfStream;
                        while(!__tmp101_last)
                        {
                            string __tmp101Line = __tmp101Reader.ReadLine();
                            __tmp101_last = __tmp101Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp101Line))
                            {
                                __out.Append(__tmp101Line);
                                __tmp95OutputWritten = true;
                            }
                            if (__tmp95OutputWritten)
                            {
                                __out.AppendLine(false); //909:71
                            }
                        }
                    }
                    if (__tmp95OutputWritten)
                    {
                        __out.AppendLine(false); //909:71
                    }
                }
            }
            else //911:2
            {
                IEnumerable<object> mc = (value as ModelCollection) as IEnumerable<object>; //912:3
                if (mc != null) //913:3
                {
                    var __loop61_results = 
                        (from cvalue in __Enumerate((mc).GetEnumerator()) //914:9
                        select new { cvalue = cvalue}
                        ).ToList(); //914:4
                    for (int __loop61_iteration = 0; __loop61_iteration < __loop61_results.Count; ++__loop61_iteration)
                    {
                        var __tmp102 = __loop61_results[__loop61_iteration];
                        var cvalue = __tmp102.cvalue;
                        bool __tmp104OutputWritten = false;
                        StringBuilder __tmp105 = new StringBuilder();
                        __tmp105.Append(GenerateModelObjectPropertyCollectionValue(coreModel, mobj, prop, cvalue, mobjToName));
                        using(StreamReader __tmp105Reader = new StreamReader(this.__ToStream(__tmp105.ToString())))
                        {
                            bool __tmp105_last = __tmp105Reader.EndOfStream;
                            while(!__tmp105_last)
                            {
                                string __tmp105Line = __tmp105Reader.ReadLine();
                                __tmp105_last = __tmp105Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp105Line))
                                {
                                    __out.Append(__tmp105Line);
                                    __tmp104OutputWritten = true;
                                }
                                if (__tmp104OutputWritten)
                                {
                                    __out.AppendLine(false); //915:88
                                }
                            }
                        }
                        if (__tmp104OutputWritten)
                        {
                            __out.AppendLine(false); //915:88
                        }
                    }
                }
                else //917:3
                {
                    bool __tmp107OutputWritten = false;
                    string __tmp108Line = "// Invalid property value type: "; //918:1
                    if (!string.IsNullOrEmpty(__tmp108Line))
                    {
                        __out.Append(__tmp108Line);
                        __tmp107OutputWritten = true;
                    }
                    StringBuilder __tmp109 = new StringBuilder();
                    __tmp109.Append(name);
                    using(StreamReader __tmp109Reader = new StreamReader(this.__ToStream(__tmp109.ToString())))
                    {
                        bool __tmp109_last = __tmp109Reader.EndOfStream;
                        while(!__tmp109_last)
                        {
                            string __tmp109Line = __tmp109Reader.ReadLine();
                            __tmp109_last = __tmp109Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp109Line))
                            {
                                __out.Append(__tmp109Line);
                                __tmp107OutputWritten = true;
                            }
                            if (!__tmp109_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp110Line = "."; //918:39
                    if (!string.IsNullOrEmpty(__tmp110Line))
                    {
                        __out.Append(__tmp110Line);
                        __tmp107OutputWritten = true;
                    }
                    StringBuilder __tmp111 = new StringBuilder();
                    __tmp111.Append(prop.Name);
                    using(StreamReader __tmp111Reader = new StreamReader(this.__ToStream(__tmp111.ToString())))
                    {
                        bool __tmp111_last = __tmp111Reader.EndOfStream;
                        while(!__tmp111_last)
                        {
                            string __tmp111Line = __tmp111Reader.ReadLine();
                            __tmp111_last = __tmp111Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp111Line))
                            {
                                __out.Append(__tmp111Line);
                                __tmp107OutputWritten = true;
                            }
                            if (!__tmp111_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp112Line = " = "; //918:51
                    if (!string.IsNullOrEmpty(__tmp112Line))
                    {
                        __out.Append(__tmp112Line);
                        __tmp107OutputWritten = true;
                    }
                    StringBuilder __tmp113 = new StringBuilder();
                    __tmp113.Append(value.GetType());
                    using(StreamReader __tmp113Reader = new StreamReader(this.__ToStream(__tmp113.ToString())))
                    {
                        bool __tmp113_last = __tmp113Reader.EndOfStream;
                        while(!__tmp113_last)
                        {
                            string __tmp113Line = __tmp113Reader.ReadLine();
                            __tmp113_last = __tmp113Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp113Line))
                            {
                                __out.Append(__tmp113Line);
                                __tmp107OutputWritten = true;
                            }
                            if (__tmp107OutputWritten)
                            {
                                __out.AppendLine(false); //918:71
                            }
                        }
                    }
                    if (__tmp107OutputWritten)
                    {
                        __out.AppendLine(false); //918:71
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateModelObjectPropertyCollectionValue(bool coreModel, ModelObject mobj, ModelProperty prop, object value, Dictionary<ModelObject,string> mobjToName) //923:1
        {
            StringBuilder __out = new StringBuilder();
            string name = mobjToName[mobj]; //924:2
            ModelObject moValue = value as ModelObject; //925:2
            if (value == null) //926:2
            {
                bool __tmp2OutputWritten = false;
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(name);
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_last = __tmp3Reader.EndOfStream;
                    while(!__tmp3_last)
                    {
                        string __tmp3Line = __tmp3Reader.ReadLine();
                        __tmp3_last = __tmp3Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp3Line))
                        {
                            __out.Append(__tmp3Line);
                            __tmp2OutputWritten = true;
                        }
                        if (!__tmp3_last) __out.AppendLine(true);
                    }
                }
                string __tmp4Line = "."; //927:7
                if (!string.IsNullOrEmpty(__tmp4Line))
                {
                    __out.Append(__tmp4Line);
                    __tmp2OutputWritten = true;
                }
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(prop.Name);
                using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                {
                    bool __tmp5_last = __tmp5Reader.EndOfStream;
                    while(!__tmp5_last)
                    {
                        string __tmp5Line = __tmp5Reader.ReadLine();
                        __tmp5_last = __tmp5Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp5Line))
                        {
                            __out.Append(__tmp5Line);
                            __tmp2OutputWritten = true;
                        }
                        if (!__tmp5_last) __out.AppendLine(true);
                    }
                }
                string __tmp6Line = ".Add(null);"; //927:19
                if (!string.IsNullOrEmpty(__tmp6Line))
                {
                    __out.Append(__tmp6Line);
                    __tmp2OutputWritten = true;
                }
                if (__tmp2OutputWritten)
                {
                    __out.AppendLine(false); //927:30
                }
                if (__tmp2OutputWritten)
                {
                    __out.AppendLine(false); //927:30
                }
            }
            else if (value is string) //928:2
            {
                bool __tmp8OutputWritten = false;
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append(name);
                using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                {
                    bool __tmp9_last = __tmp9Reader.EndOfStream;
                    while(!__tmp9_last)
                    {
                        string __tmp9Line = __tmp9Reader.ReadLine();
                        __tmp9_last = __tmp9Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp9Line))
                        {
                            __out.Append(__tmp9Line);
                            __tmp8OutputWritten = true;
                        }
                        if (!__tmp9_last) __out.AppendLine(true);
                    }
                }
                string __tmp10Line = "."; //929:7
                if (!string.IsNullOrEmpty(__tmp10Line))
                {
                    __out.Append(__tmp10Line);
                    __tmp8OutputWritten = true;
                }
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(prop.Name);
                using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                {
                    bool __tmp11_last = __tmp11Reader.EndOfStream;
                    while(!__tmp11_last)
                    {
                        string __tmp11Line = __tmp11Reader.ReadLine();
                        __tmp11_last = __tmp11Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp11Line))
                        {
                            __out.Append(__tmp11Line);
                            __tmp8OutputWritten = true;
                        }
                        if (!__tmp11_last) __out.AppendLine(true);
                    }
                }
                string __tmp12Line = ".Add(\""; //929:19
                if (!string.IsNullOrEmpty(__tmp12Line))
                {
                    __out.Append(__tmp12Line);
                    __tmp8OutputWritten = true;
                }
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(value);
                using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                {
                    bool __tmp13_last = __tmp13Reader.EndOfStream;
                    while(!__tmp13_last)
                    {
                        string __tmp13Line = __tmp13Reader.ReadLine();
                        __tmp13_last = __tmp13Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp13Line))
                        {
                            __out.Append(__tmp13Line);
                            __tmp8OutputWritten = true;
                        }
                        if (!__tmp13_last) __out.AppendLine(true);
                    }
                }
                string __tmp14Line = "\");"; //929:32
                if (!string.IsNullOrEmpty(__tmp14Line))
                {
                    __out.Append(__tmp14Line);
                    __tmp8OutputWritten = true;
                }
                if (__tmp8OutputWritten)
                {
                    __out.AppendLine(false); //929:35
                }
                if (__tmp8OutputWritten)
                {
                    __out.AppendLine(false); //929:35
                }
            }
            else if (value is bool) //930:2
            {
                bool __tmp16OutputWritten = false;
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(name);
                using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
                {
                    bool __tmp17_last = __tmp17Reader.EndOfStream;
                    while(!__tmp17_last)
                    {
                        string __tmp17Line = __tmp17Reader.ReadLine();
                        __tmp17_last = __tmp17Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp17Line))
                        {
                            __out.Append(__tmp17Line);
                            __tmp16OutputWritten = true;
                        }
                        if (!__tmp17_last) __out.AppendLine(true);
                    }
                }
                string __tmp18Line = "."; //931:7
                if (!string.IsNullOrEmpty(__tmp18Line))
                {
                    __out.Append(__tmp18Line);
                    __tmp16OutputWritten = true;
                }
                StringBuilder __tmp19 = new StringBuilder();
                __tmp19.Append(prop.Name);
                using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
                {
                    bool __tmp19_last = __tmp19Reader.EndOfStream;
                    while(!__tmp19_last)
                    {
                        string __tmp19Line = __tmp19Reader.ReadLine();
                        __tmp19_last = __tmp19Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp19Line))
                        {
                            __out.Append(__tmp19Line);
                            __tmp16OutputWritten = true;
                        }
                        if (!__tmp19_last) __out.AppendLine(true);
                    }
                }
                string __tmp20Line = ".Add("; //931:19
                if (!string.IsNullOrEmpty(__tmp20Line))
                {
                    __out.Append(__tmp20Line);
                    __tmp16OutputWritten = true;
                }
                StringBuilder __tmp21 = new StringBuilder();
                __tmp21.Append(value.ToString().ToLower());
                using(StreamReader __tmp21Reader = new StreamReader(this.__ToStream(__tmp21.ToString())))
                {
                    bool __tmp21_last = __tmp21Reader.EndOfStream;
                    while(!__tmp21_last)
                    {
                        string __tmp21Line = __tmp21Reader.ReadLine();
                        __tmp21_last = __tmp21Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp21Line))
                        {
                            __out.Append(__tmp21Line);
                            __tmp16OutputWritten = true;
                        }
                        if (!__tmp21_last) __out.AppendLine(true);
                    }
                }
                string __tmp22Line = ");"; //931:52
                if (!string.IsNullOrEmpty(__tmp22Line))
                {
                    __out.Append(__tmp22Line);
                    __tmp16OutputWritten = true;
                }
                if (__tmp16OutputWritten)
                {
                    __out.AppendLine(false); //931:54
                }
                if (__tmp16OutputWritten)
                {
                    __out.AppendLine(false); //931:54
                }
            }
            else if (value.GetType().IsPrimitive) //932:2
            {
                bool __tmp24OutputWritten = false;
                StringBuilder __tmp25 = new StringBuilder();
                __tmp25.Append(name);
                using(StreamReader __tmp25Reader = new StreamReader(this.__ToStream(__tmp25.ToString())))
                {
                    bool __tmp25_last = __tmp25Reader.EndOfStream;
                    while(!__tmp25_last)
                    {
                        string __tmp25Line = __tmp25Reader.ReadLine();
                        __tmp25_last = __tmp25Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp25Line))
                        {
                            __out.Append(__tmp25Line);
                            __tmp24OutputWritten = true;
                        }
                        if (!__tmp25_last) __out.AppendLine(true);
                    }
                }
                string __tmp26Line = "."; //933:7
                if (!string.IsNullOrEmpty(__tmp26Line))
                {
                    __out.Append(__tmp26Line);
                    __tmp24OutputWritten = true;
                }
                StringBuilder __tmp27 = new StringBuilder();
                __tmp27.Append(prop.Name);
                using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
                {
                    bool __tmp27_last = __tmp27Reader.EndOfStream;
                    while(!__tmp27_last)
                    {
                        string __tmp27Line = __tmp27Reader.ReadLine();
                        __tmp27_last = __tmp27Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp27Line))
                        {
                            __out.Append(__tmp27Line);
                            __tmp24OutputWritten = true;
                        }
                        if (!__tmp27_last) __out.AppendLine(true);
                    }
                }
                string __tmp28Line = ".Add("; //933:19
                if (!string.IsNullOrEmpty(__tmp28Line))
                {
                    __out.Append(__tmp28Line);
                    __tmp24OutputWritten = true;
                }
                StringBuilder __tmp29 = new StringBuilder();
                __tmp29.Append(value.ToString());
                using(StreamReader __tmp29Reader = new StreamReader(this.__ToStream(__tmp29.ToString())))
                {
                    bool __tmp29_last = __tmp29Reader.EndOfStream;
                    while(!__tmp29_last)
                    {
                        string __tmp29Line = __tmp29Reader.ReadLine();
                        __tmp29_last = __tmp29Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp29Line))
                        {
                            __out.Append(__tmp29Line);
                            __tmp24OutputWritten = true;
                        }
                        if (!__tmp29_last) __out.AppendLine(true);
                    }
                }
                string __tmp30Line = ");"; //933:42
                if (!string.IsNullOrEmpty(__tmp30Line))
                {
                    __out.Append(__tmp30Line);
                    __tmp24OutputWritten = true;
                }
                if (__tmp24OutputWritten)
                {
                    __out.AppendLine(false); //933:44
                }
                if (__tmp24OutputWritten)
                {
                    __out.AppendLine(false); //933:44
                }
            }
            else if (MetaBuiltInTypes.Types.Contains(value)) //934:2
            {
                if (coreModel) //935:3
                {
                    if (mobjToName.ContainsKey(moValue)) //936:4
                    {
                        bool __tmp32OutputWritten = false;
                        StringBuilder __tmp33 = new StringBuilder();
                        __tmp33.Append(name);
                        using(StreamReader __tmp33Reader = new StreamReader(this.__ToStream(__tmp33.ToString())))
                        {
                            bool __tmp33_last = __tmp33Reader.EndOfStream;
                            while(!__tmp33_last)
                            {
                                string __tmp33Line = __tmp33Reader.ReadLine();
                                __tmp33_last = __tmp33Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp33Line))
                                {
                                    __out.Append(__tmp33Line);
                                    __tmp32OutputWritten = true;
                                }
                                if (!__tmp33_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp34Line = "."; //937:7
                        if (!string.IsNullOrEmpty(__tmp34Line))
                        {
                            __out.Append(__tmp34Line);
                            __tmp32OutputWritten = true;
                        }
                        StringBuilder __tmp35 = new StringBuilder();
                        __tmp35.Append(prop.Name);
                        using(StreamReader __tmp35Reader = new StreamReader(this.__ToStream(__tmp35.ToString())))
                        {
                            bool __tmp35_last = __tmp35Reader.EndOfStream;
                            while(!__tmp35_last)
                            {
                                string __tmp35Line = __tmp35Reader.ReadLine();
                                __tmp35_last = __tmp35Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp35Line))
                                {
                                    __out.Append(__tmp35Line);
                                    __tmp32OutputWritten = true;
                                }
                                if (!__tmp35_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp36Line = ".AddLazy(() => "; //937:19
                        if (!string.IsNullOrEmpty(__tmp36Line))
                        {
                            __out.Append(__tmp36Line);
                            __tmp32OutputWritten = true;
                        }
                        StringBuilder __tmp37 = new StringBuilder();
                        __tmp37.Append(mobjToName[moValue]);
                        using(StreamReader __tmp37Reader = new StreamReader(this.__ToStream(__tmp37.ToString())))
                        {
                            bool __tmp37_last = __tmp37Reader.EndOfStream;
                            while(!__tmp37_last)
                            {
                                string __tmp37Line = __tmp37Reader.ReadLine();
                                __tmp37_last = __tmp37Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp37Line))
                                {
                                    __out.Append(__tmp37Line);
                                    __tmp32OutputWritten = true;
                                }
                                if (!__tmp37_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp38Line = ");"; //937:55
                        if (!string.IsNullOrEmpty(__tmp38Line))
                        {
                            __out.Append(__tmp38Line);
                            __tmp32OutputWritten = true;
                        }
                        if (__tmp32OutputWritten)
                        {
                            __out.AppendLine(false); //937:57
                        }
                        if (__tmp32OutputWritten)
                        {
                            __out.AppendLine(false); //937:57
                        }
                    }
                    else //938:4
                    {
                        bool __tmp40OutputWritten = false;
                        StringBuilder __tmp41 = new StringBuilder();
                        __tmp41.Append(name);
                        using(StreamReader __tmp41Reader = new StreamReader(this.__ToStream(__tmp41.ToString())))
                        {
                            bool __tmp41_last = __tmp41Reader.EndOfStream;
                            while(!__tmp41_last)
                            {
                                string __tmp41Line = __tmp41Reader.ReadLine();
                                __tmp41_last = __tmp41Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp41Line))
                                {
                                    __out.Append(__tmp41Line);
                                    __tmp40OutputWritten = true;
                                }
                                if (!__tmp41_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp42Line = "."; //939:7
                        if (!string.IsNullOrEmpty(__tmp42Line))
                        {
                            __out.Append(__tmp42Line);
                            __tmp40OutputWritten = true;
                        }
                        StringBuilder __tmp43 = new StringBuilder();
                        __tmp43.Append(prop.Name);
                        using(StreamReader __tmp43Reader = new StreamReader(this.__ToStream(__tmp43.ToString())))
                        {
                            bool __tmp43_last = __tmp43Reader.EndOfStream;
                            while(!__tmp43_last)
                            {
                                string __tmp43Line = __tmp43Reader.ReadLine();
                                __tmp43_last = __tmp43Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp43Line))
                                {
                                    __out.Append(__tmp43Line);
                                    __tmp40OutputWritten = true;
                                }
                                if (!__tmp43_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp44Line = ".AddLazy(() => this."; //939:19
                        if (!string.IsNullOrEmpty(__tmp44Line))
                        {
                            __out.Append(__tmp44Line);
                            __tmp40OutputWritten = true;
                        }
                        StringBuilder __tmp45 = new StringBuilder();
                        __tmp45.Append(((MetaPrimitiveType)value).Name.ToPascalCase());
                        using(StreamReader __tmp45Reader = new StreamReader(this.__ToStream(__tmp45.ToString())))
                        {
                            bool __tmp45_last = __tmp45Reader.EndOfStream;
                            while(!__tmp45_last)
                            {
                                string __tmp45Line = __tmp45Reader.ReadLine();
                                __tmp45_last = __tmp45Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp45Line))
                                {
                                    __out.Append(__tmp45Line);
                                    __tmp40OutputWritten = true;
                                }
                                if (!__tmp45_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp46Line = ");"; //939:87
                        if (!string.IsNullOrEmpty(__tmp46Line))
                        {
                            __out.Append(__tmp46Line);
                            __tmp40OutputWritten = true;
                        }
                        if (__tmp40OutputWritten)
                        {
                            __out.AppendLine(false); //939:89
                        }
                        if (__tmp40OutputWritten)
                        {
                            __out.AppendLine(false); //939:89
                        }
                    }
                }
                else //941:3
                {
                    bool __tmp48OutputWritten = false;
                    StringBuilder __tmp49 = new StringBuilder();
                    __tmp49.Append(name);
                    using(StreamReader __tmp49Reader = new StreamReader(this.__ToStream(__tmp49.ToString())))
                    {
                        bool __tmp49_last = __tmp49Reader.EndOfStream;
                        while(!__tmp49_last)
                        {
                            string __tmp49Line = __tmp49Reader.ReadLine();
                            __tmp49_last = __tmp49Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp49Line))
                            {
                                __out.Append(__tmp49Line);
                                __tmp48OutputWritten = true;
                            }
                            if (!__tmp49_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp50Line = "."; //942:7
                    if (!string.IsNullOrEmpty(__tmp50Line))
                    {
                        __out.Append(__tmp50Line);
                        __tmp48OutputWritten = true;
                    }
                    StringBuilder __tmp51 = new StringBuilder();
                    __tmp51.Append(prop.Name);
                    using(StreamReader __tmp51Reader = new StreamReader(this.__ToStream(__tmp51.ToString())))
                    {
                        bool __tmp51_last = __tmp51Reader.EndOfStream;
                        while(!__tmp51_last)
                        {
                            string __tmp51Line = __tmp51Reader.ReadLine();
                            __tmp51_last = __tmp51Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp51Line))
                            {
                                __out.Append(__tmp51Line);
                                __tmp48OutputWritten = true;
                            }
                            if (!__tmp51_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp52Line = ".Add("; //942:19
                    if (!string.IsNullOrEmpty(__tmp52Line))
                    {
                        __out.Append(__tmp52Line);
                        __tmp48OutputWritten = true;
                    }
                    StringBuilder __tmp53 = new StringBuilder();
                    __tmp53.Append(GenerateTypeOf(value));
                    using(StreamReader __tmp53Reader = new StreamReader(this.__ToStream(__tmp53.ToString())))
                    {
                        bool __tmp53_last = __tmp53Reader.EndOfStream;
                        while(!__tmp53_last)
                        {
                            string __tmp53Line = __tmp53Reader.ReadLine();
                            __tmp53_last = __tmp53Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp53Line))
                            {
                                __out.Append(__tmp53Line);
                                __tmp48OutputWritten = true;
                            }
                            if (!__tmp53_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp54Line = ");"; //942:47
                    if (!string.IsNullOrEmpty(__tmp54Line))
                    {
                        __out.Append(__tmp54Line);
                        __tmp48OutputWritten = true;
                    }
                    if (__tmp48OutputWritten)
                    {
                        __out.AppendLine(false); //942:49
                    }
                    if (__tmp48OutputWritten)
                    {
                        __out.AppendLine(false); //942:49
                    }
                }
            }
            else if (value is MetaPrimitiveType) //944:2
            {
                if (coreModel) //945:3
                {
                    if (mobjToName.ContainsKey(moValue)) //946:4
                    {
                        bool __tmp56OutputWritten = false;
                        StringBuilder __tmp57 = new StringBuilder();
                        __tmp57.Append(name);
                        using(StreamReader __tmp57Reader = new StreamReader(this.__ToStream(__tmp57.ToString())))
                        {
                            bool __tmp57_last = __tmp57Reader.EndOfStream;
                            while(!__tmp57_last)
                            {
                                string __tmp57Line = __tmp57Reader.ReadLine();
                                __tmp57_last = __tmp57Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp57Line))
                                {
                                    __out.Append(__tmp57Line);
                                    __tmp56OutputWritten = true;
                                }
                                if (!__tmp57_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp58Line = "."; //947:7
                        if (!string.IsNullOrEmpty(__tmp58Line))
                        {
                            __out.Append(__tmp58Line);
                            __tmp56OutputWritten = true;
                        }
                        StringBuilder __tmp59 = new StringBuilder();
                        __tmp59.Append(prop.Name);
                        using(StreamReader __tmp59Reader = new StreamReader(this.__ToStream(__tmp59.ToString())))
                        {
                            bool __tmp59_last = __tmp59Reader.EndOfStream;
                            while(!__tmp59_last)
                            {
                                string __tmp59Line = __tmp59Reader.ReadLine();
                                __tmp59_last = __tmp59Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp59Line))
                                {
                                    __out.Append(__tmp59Line);
                                    __tmp56OutputWritten = true;
                                }
                                if (!__tmp59_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp60Line = ".AddLazy(() => "; //947:19
                        if (!string.IsNullOrEmpty(__tmp60Line))
                        {
                            __out.Append(__tmp60Line);
                            __tmp56OutputWritten = true;
                        }
                        StringBuilder __tmp61 = new StringBuilder();
                        __tmp61.Append(mobjToName[moValue]);
                        using(StreamReader __tmp61Reader = new StreamReader(this.__ToStream(__tmp61.ToString())))
                        {
                            bool __tmp61_last = __tmp61Reader.EndOfStream;
                            while(!__tmp61_last)
                            {
                                string __tmp61Line = __tmp61Reader.ReadLine();
                                __tmp61_last = __tmp61Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp61Line))
                                {
                                    __out.Append(__tmp61Line);
                                    __tmp56OutputWritten = true;
                                }
                                if (!__tmp61_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp62Line = ");"; //947:55
                        if (!string.IsNullOrEmpty(__tmp62Line))
                        {
                            __out.Append(__tmp62Line);
                            __tmp56OutputWritten = true;
                        }
                        if (__tmp56OutputWritten)
                        {
                            __out.AppendLine(false); //947:57
                        }
                        if (__tmp56OutputWritten)
                        {
                            __out.AppendLine(false); //947:57
                        }
                    }
                    else //948:4
                    {
                        bool __tmp64OutputWritten = false;
                        StringBuilder __tmp65 = new StringBuilder();
                        __tmp65.Append(name);
                        using(StreamReader __tmp65Reader = new StreamReader(this.__ToStream(__tmp65.ToString())))
                        {
                            bool __tmp65_last = __tmp65Reader.EndOfStream;
                            while(!__tmp65_last)
                            {
                                string __tmp65Line = __tmp65Reader.ReadLine();
                                __tmp65_last = __tmp65Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp65Line))
                                {
                                    __out.Append(__tmp65Line);
                                    __tmp64OutputWritten = true;
                                }
                                if (!__tmp65_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp66Line = "."; //949:7
                        if (!string.IsNullOrEmpty(__tmp66Line))
                        {
                            __out.Append(__tmp66Line);
                            __tmp64OutputWritten = true;
                        }
                        StringBuilder __tmp67 = new StringBuilder();
                        __tmp67.Append(prop.Name);
                        using(StreamReader __tmp67Reader = new StreamReader(this.__ToStream(__tmp67.ToString())))
                        {
                            bool __tmp67_last = __tmp67Reader.EndOfStream;
                            while(!__tmp67_last)
                            {
                                string __tmp67Line = __tmp67Reader.ReadLine();
                                __tmp67_last = __tmp67Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp67Line))
                                {
                                    __out.Append(__tmp67Line);
                                    __tmp64OutputWritten = true;
                                }
                                if (!__tmp67_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp68Line = ".AddLazy(() => this."; //949:19
                        if (!string.IsNullOrEmpty(__tmp68Line))
                        {
                            __out.Append(__tmp68Line);
                            __tmp64OutputWritten = true;
                        }
                        StringBuilder __tmp69 = new StringBuilder();
                        __tmp69.Append(((MetaPrimitiveType)value).Name.ToPascalCase());
                        using(StreamReader __tmp69Reader = new StreamReader(this.__ToStream(__tmp69.ToString())))
                        {
                            bool __tmp69_last = __tmp69Reader.EndOfStream;
                            while(!__tmp69_last)
                            {
                                string __tmp69Line = __tmp69Reader.ReadLine();
                                __tmp69_last = __tmp69Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp69Line))
                                {
                                    __out.Append(__tmp69Line);
                                    __tmp64OutputWritten = true;
                                }
                                if (!__tmp69_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp70Line = ");"; //949:87
                        if (!string.IsNullOrEmpty(__tmp70Line))
                        {
                            __out.Append(__tmp70Line);
                            __tmp64OutputWritten = true;
                        }
                        if (__tmp64OutputWritten)
                        {
                            __out.AppendLine(false); //949:89
                        }
                        if (__tmp64OutputWritten)
                        {
                            __out.AppendLine(false); //949:89
                        }
                    }
                }
                else //951:3
                {
                    bool __tmp72OutputWritten = false;
                    StringBuilder __tmp73 = new StringBuilder();
                    __tmp73.Append(name);
                    using(StreamReader __tmp73Reader = new StreamReader(this.__ToStream(__tmp73.ToString())))
                    {
                        bool __tmp73_last = __tmp73Reader.EndOfStream;
                        while(!__tmp73_last)
                        {
                            string __tmp73Line = __tmp73Reader.ReadLine();
                            __tmp73_last = __tmp73Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp73Line))
                            {
                                __out.Append(__tmp73Line);
                                __tmp72OutputWritten = true;
                            }
                            if (!__tmp73_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp74Line = "."; //952:7
                    if (!string.IsNullOrEmpty(__tmp74Line))
                    {
                        __out.Append(__tmp74Line);
                        __tmp72OutputWritten = true;
                    }
                    StringBuilder __tmp75 = new StringBuilder();
                    __tmp75.Append(prop.Name);
                    using(StreamReader __tmp75Reader = new StreamReader(this.__ToStream(__tmp75.ToString())))
                    {
                        bool __tmp75_last = __tmp75Reader.EndOfStream;
                        while(!__tmp75_last)
                        {
                            string __tmp75Line = __tmp75Reader.ReadLine();
                            __tmp75_last = __tmp75Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp75Line))
                            {
                                __out.Append(__tmp75Line);
                                __tmp72OutputWritten = true;
                            }
                            if (!__tmp75_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp76Line = ".Add("; //952:19
                    if (!string.IsNullOrEmpty(__tmp76Line))
                    {
                        __out.Append(__tmp76Line);
                        __tmp72OutputWritten = true;
                    }
                    StringBuilder __tmp77 = new StringBuilder();
                    __tmp77.Append(GenerateTypeOf(value));
                    using(StreamReader __tmp77Reader = new StreamReader(this.__ToStream(__tmp77.ToString())))
                    {
                        bool __tmp77_last = __tmp77Reader.EndOfStream;
                        while(!__tmp77_last)
                        {
                            string __tmp77Line = __tmp77Reader.ReadLine();
                            __tmp77_last = __tmp77Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp77Line))
                            {
                                __out.Append(__tmp77Line);
                                __tmp72OutputWritten = true;
                            }
                            if (!__tmp77_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp78Line = ");"; //952:47
                    if (!string.IsNullOrEmpty(__tmp78Line))
                    {
                        __out.Append(__tmp78Line);
                        __tmp72OutputWritten = true;
                    }
                    if (__tmp72OutputWritten)
                    {
                        __out.AppendLine(false); //952:49
                    }
                    if (__tmp72OutputWritten)
                    {
                        __out.AppendLine(false); //952:49
                    }
                }
            }
            else if (value is Enum) //954:2
            {
                bool __tmp80OutputWritten = false;
                StringBuilder __tmp81 = new StringBuilder();
                __tmp81.Append(name);
                using(StreamReader __tmp81Reader = new StreamReader(this.__ToStream(__tmp81.ToString())))
                {
                    bool __tmp81_last = __tmp81Reader.EndOfStream;
                    while(!__tmp81_last)
                    {
                        string __tmp81Line = __tmp81Reader.ReadLine();
                        __tmp81_last = __tmp81Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp81Line))
                        {
                            __out.Append(__tmp81Line);
                            __tmp80OutputWritten = true;
                        }
                        if (!__tmp81_last) __out.AppendLine(true);
                    }
                }
                string __tmp82Line = "."; //955:7
                if (!string.IsNullOrEmpty(__tmp82Line))
                {
                    __out.Append(__tmp82Line);
                    __tmp80OutputWritten = true;
                }
                StringBuilder __tmp83 = new StringBuilder();
                __tmp83.Append(prop.Name);
                using(StreamReader __tmp83Reader = new StreamReader(this.__ToStream(__tmp83.ToString())))
                {
                    bool __tmp83_last = __tmp83Reader.EndOfStream;
                    while(!__tmp83_last)
                    {
                        string __tmp83Line = __tmp83Reader.ReadLine();
                        __tmp83_last = __tmp83Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp83Line))
                        {
                            __out.Append(__tmp83Line);
                            __tmp80OutputWritten = true;
                        }
                        if (!__tmp83_last) __out.AppendLine(true);
                    }
                }
                string __tmp84Line = ".Add("; //955:19
                if (!string.IsNullOrEmpty(__tmp84Line))
                {
                    __out.Append(__tmp84Line);
                    __tmp80OutputWritten = true;
                }
                StringBuilder __tmp85 = new StringBuilder();
                __tmp85.Append(GetEnumValueOf(value));
                using(StreamReader __tmp85Reader = new StreamReader(this.__ToStream(__tmp85.ToString())))
                {
                    bool __tmp85_last = __tmp85Reader.EndOfStream;
                    while(!__tmp85_last)
                    {
                        string __tmp85Line = __tmp85Reader.ReadLine();
                        __tmp85_last = __tmp85Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp85Line))
                        {
                            __out.Append(__tmp85Line);
                            __tmp80OutputWritten = true;
                        }
                        if (!__tmp85_last) __out.AppendLine(true);
                    }
                }
                string __tmp86Line = ");"; //955:47
                if (!string.IsNullOrEmpty(__tmp86Line))
                {
                    __out.Append(__tmp86Line);
                    __tmp80OutputWritten = true;
                }
                if (__tmp80OutputWritten)
                {
                    __out.AppendLine(false); //955:49
                }
                if (__tmp80OutputWritten)
                {
                    __out.AppendLine(false); //955:49
                }
            }
            else if (moValue != null) //956:2
            {
                if (mobjToName.ContainsKey(moValue)) //957:3
                {
                    bool __tmp88OutputWritten = false;
                    StringBuilder __tmp89 = new StringBuilder();
                    __tmp89.Append(name);
                    using(StreamReader __tmp89Reader = new StreamReader(this.__ToStream(__tmp89.ToString())))
                    {
                        bool __tmp89_last = __tmp89Reader.EndOfStream;
                        while(!__tmp89_last)
                        {
                            string __tmp89Line = __tmp89Reader.ReadLine();
                            __tmp89_last = __tmp89Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp89Line))
                            {
                                __out.Append(__tmp89Line);
                                __tmp88OutputWritten = true;
                            }
                            if (!__tmp89_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp90Line = "."; //958:7
                    if (!string.IsNullOrEmpty(__tmp90Line))
                    {
                        __out.Append(__tmp90Line);
                        __tmp88OutputWritten = true;
                    }
                    StringBuilder __tmp91 = new StringBuilder();
                    __tmp91.Append(prop.Name);
                    using(StreamReader __tmp91Reader = new StreamReader(this.__ToStream(__tmp91.ToString())))
                    {
                        bool __tmp91_last = __tmp91Reader.EndOfStream;
                        while(!__tmp91_last)
                        {
                            string __tmp91Line = __tmp91Reader.ReadLine();
                            __tmp91_last = __tmp91Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp91Line))
                            {
                                __out.Append(__tmp91Line);
                                __tmp88OutputWritten = true;
                            }
                            if (!__tmp91_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp92Line = ".AddLazy(() => "; //958:19
                    if (!string.IsNullOrEmpty(__tmp92Line))
                    {
                        __out.Append(__tmp92Line);
                        __tmp88OutputWritten = true;
                    }
                    StringBuilder __tmp93 = new StringBuilder();
                    __tmp93.Append(mobjToName[moValue]);
                    using(StreamReader __tmp93Reader = new StreamReader(this.__ToStream(__tmp93.ToString())))
                    {
                        bool __tmp93_last = __tmp93Reader.EndOfStream;
                        while(!__tmp93_last)
                        {
                            string __tmp93Line = __tmp93Reader.ReadLine();
                            __tmp93_last = __tmp93Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp93Line))
                            {
                                __out.Append(__tmp93Line);
                                __tmp88OutputWritten = true;
                            }
                            if (!__tmp93_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp94Line = ");"; //958:55
                    if (!string.IsNullOrEmpty(__tmp94Line))
                    {
                        __out.Append(__tmp94Line);
                        __tmp88OutputWritten = true;
                    }
                    if (__tmp88OutputWritten)
                    {
                        __out.AppendLine(false); //958:57
                    }
                    if (__tmp88OutputWritten)
                    {
                        __out.AppendLine(false); //958:57
                    }
                }
                else //959:3
                {
                    bool __tmp96OutputWritten = false;
                    string __tmp97Line = "// Omitted since not part of the model: "; //960:1
                    if (!string.IsNullOrEmpty(__tmp97Line))
                    {
                        __out.Append(__tmp97Line);
                        __tmp96OutputWritten = true;
                    }
                    StringBuilder __tmp98 = new StringBuilder();
                    __tmp98.Append(name);
                    using(StreamReader __tmp98Reader = new StreamReader(this.__ToStream(__tmp98.ToString())))
                    {
                        bool __tmp98_last = __tmp98Reader.EndOfStream;
                        while(!__tmp98_last)
                        {
                            string __tmp98Line = __tmp98Reader.ReadLine();
                            __tmp98_last = __tmp98Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp98Line))
                            {
                                __out.Append(__tmp98Line);
                                __tmp96OutputWritten = true;
                            }
                            if (!__tmp98_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp99Line = "."; //960:47
                    if (!string.IsNullOrEmpty(__tmp99Line))
                    {
                        __out.Append(__tmp99Line);
                        __tmp96OutputWritten = true;
                    }
                    StringBuilder __tmp100 = new StringBuilder();
                    __tmp100.Append(prop.Name);
                    using(StreamReader __tmp100Reader = new StreamReader(this.__ToStream(__tmp100.ToString())))
                    {
                        bool __tmp100_last = __tmp100Reader.EndOfStream;
                        while(!__tmp100_last)
                        {
                            string __tmp100Line = __tmp100Reader.ReadLine();
                            __tmp100_last = __tmp100Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp100Line))
                            {
                                __out.Append(__tmp100Line);
                                __tmp96OutputWritten = true;
                            }
                            if (!__tmp100_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp101Line = " = "; //960:59
                    if (!string.IsNullOrEmpty(__tmp101Line))
                    {
                        __out.Append(__tmp101Line);
                        __tmp96OutputWritten = true;
                    }
                    StringBuilder __tmp102 = new StringBuilder();
                    __tmp102.Append(moValue);
                    using(StreamReader __tmp102Reader = new StreamReader(this.__ToStream(__tmp102.ToString())))
                    {
                        bool __tmp102_last = __tmp102Reader.EndOfStream;
                        while(!__tmp102_last)
                        {
                            string __tmp102Line = __tmp102Reader.ReadLine();
                            __tmp102_last = __tmp102Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp102Line))
                            {
                                __out.Append(__tmp102Line);
                                __tmp96OutputWritten = true;
                            }
                            if (__tmp96OutputWritten)
                            {
                                __out.AppendLine(false); //960:71
                            }
                        }
                    }
                    if (__tmp96OutputWritten)
                    {
                        __out.AppendLine(false); //960:71
                    }
                }
            }
            else //962:2
            {
                IEnumerable<object> mc = (value as ModelCollection) as IEnumerable<object>; //963:3
                if (mc != null) //964:3
                {
                    var __loop62_results = 
                        (from cvalue in __Enumerate((mc).GetEnumerator()) //965:9
                        select new { cvalue = cvalue}
                        ).ToList(); //965:4
                    for (int __loop62_iteration = 0; __loop62_iteration < __loop62_results.Count; ++__loop62_iteration)
                    {
                        var __tmp103 = __loop62_results[__loop62_iteration];
                        var cvalue = __tmp103.cvalue;
                        bool __tmp105OutputWritten = false;
                        StringBuilder __tmp106 = new StringBuilder();
                        __tmp106.Append(GenerateModelObjectPropertyCollectionValue(coreModel, mobj, prop, cvalue, mobjToName));
                        using(StreamReader __tmp106Reader = new StreamReader(this.__ToStream(__tmp106.ToString())))
                        {
                            bool __tmp106_last = __tmp106Reader.EndOfStream;
                            while(!__tmp106_last)
                            {
                                string __tmp106Line = __tmp106Reader.ReadLine();
                                __tmp106_last = __tmp106Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp106Line))
                                {
                                    __out.Append(__tmp106Line);
                                    __tmp105OutputWritten = true;
                                }
                                if (__tmp105OutputWritten)
                                {
                                    __out.AppendLine(false); //966:88
                                }
                            }
                        }
                        if (__tmp105OutputWritten)
                        {
                            __out.AppendLine(false); //966:88
                        }
                    }
                }
                else //968:3
                {
                    bool __tmp108OutputWritten = false;
                    string __tmp109Line = "// Invalid property value type: "; //969:1
                    if (!string.IsNullOrEmpty(__tmp109Line))
                    {
                        __out.Append(__tmp109Line);
                        __tmp108OutputWritten = true;
                    }
                    StringBuilder __tmp110 = new StringBuilder();
                    __tmp110.Append(name);
                    using(StreamReader __tmp110Reader = new StreamReader(this.__ToStream(__tmp110.ToString())))
                    {
                        bool __tmp110_last = __tmp110Reader.EndOfStream;
                        while(!__tmp110_last)
                        {
                            string __tmp110Line = __tmp110Reader.ReadLine();
                            __tmp110_last = __tmp110Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp110Line))
                            {
                                __out.Append(__tmp110Line);
                                __tmp108OutputWritten = true;
                            }
                            if (!__tmp110_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp111Line = "."; //969:39
                    if (!string.IsNullOrEmpty(__tmp111Line))
                    {
                        __out.Append(__tmp111Line);
                        __tmp108OutputWritten = true;
                    }
                    StringBuilder __tmp112 = new StringBuilder();
                    __tmp112.Append(prop.Name);
                    using(StreamReader __tmp112Reader = new StreamReader(this.__ToStream(__tmp112.ToString())))
                    {
                        bool __tmp112_last = __tmp112Reader.EndOfStream;
                        while(!__tmp112_last)
                        {
                            string __tmp112Line = __tmp112Reader.ReadLine();
                            __tmp112_last = __tmp112Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp112Line))
                            {
                                __out.Append(__tmp112Line);
                                __tmp108OutputWritten = true;
                            }
                            if (!__tmp112_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp113Line = " = "; //969:51
                    if (!string.IsNullOrEmpty(__tmp113Line))
                    {
                        __out.Append(__tmp113Line);
                        __tmp108OutputWritten = true;
                    }
                    StringBuilder __tmp114 = new StringBuilder();
                    __tmp114.Append(value.GetType());
                    using(StreamReader __tmp114Reader = new StreamReader(this.__ToStream(__tmp114.ToString())))
                    {
                        bool __tmp114_last = __tmp114Reader.EndOfStream;
                        while(!__tmp114_last)
                        {
                            string __tmp114Line = __tmp114Reader.ReadLine();
                            __tmp114_last = __tmp114Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp114Line))
                            {
                                __out.Append(__tmp114Line);
                                __tmp108OutputWritten = true;
                            }
                            if (__tmp108OutputWritten)
                            {
                                __out.AppendLine(false); //969:71
                            }
                        }
                    }
                    if (__tmp108OutputWritten)
                    {
                        __out.AppendLine(false); //969:71
                    }
                }
            }
            return __out.ToString();
        }

        public string GetEnumValueOf(object enm) //974:1
        {
            string result = "global::" + enm.GetType().FullName.Replace("+", ".") + "." + enm.ToString(); //975:2
            if (!result.StartsWith("global::MetaDslx.Core.Immutable.") && result.StartsWith("global::MetaDslx.Core.")) //976:2
            {
                result = result.Replace("global::MetaDslx.Core.", "global::MetaDslx.Core.Immutable."); //977:3
            }
            return result; //979:2
        }

        public string GenerateTypeOf(object expr) //982:1
        {
            StringBuilder __out = new StringBuilder();
            var __tmp1 = expr; //983:9
            if (expr is MetaPrimitiveType) //984:2
            {
                var __tmp2 = ((MetaPrimitiveType)expr).Name; //985:9
                if (__tmp2 == "*none*") //986:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.None.ToMutable() : null"); //986:17
                }
                else if (__tmp2 == "*error*") //987:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Error.ToMutable() : null"); //987:18
                }
                else if (__tmp2 == "*any*") //988:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Any.ToMutable() : null"); //988:16
                }
                else if (__tmp2 == "object") //989:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Object.ToMutable() : null"); //989:17
                }
                else if (__tmp2 == "string") //990:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.String.ToMutable() : null"); //990:17
                }
                else if (__tmp2 == "int") //991:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Int.ToMutable() : null"); //991:14
                }
                else if (__tmp2 == "long") //992:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Long.ToMutable() : null"); //992:15
                }
                else if (__tmp2 == "float") //993:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Float.ToMutable() : null"); //993:16
                }
                else if (__tmp2 == "double") //994:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Double.ToMutable() : null"); //994:17
                }
                else if (__tmp2 == "byte") //995:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Byte.ToMutable() : null"); //995:15
                }
                else if (__tmp2 == "bool") //996:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Bool.ToMutable() : null"); //996:15
                }
                else if (__tmp2 == "void") //997:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.Void.ToMutable() : null"); //997:15
                }
                else if (__tmp2 == "ModelObject") //998:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.ModelObject.ToMutable() : null"); //998:22
                }
                else if (__tmp2 == "ModelObjectList") //999:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.ModelObjectList.ToMutable() : null"); //999:26
                }
                else if (__tmp2 == "DefinitionList") //1000:2
                {
                    __out.Append("global::MetaDslx.Core.Immutable.MetaInstance.IsInitialized ? global::MetaDslx.Core.Immutable.MetaInstance.DefinitionList.ToMutable() : null"); //1000:25
                }//1001:2
            }
            else if (expr is MetaClass) //1002:2
            {
                StringBuilder __tmp6 = new StringBuilder();
                __tmp6.Append(((MetaClass)expr).CSharpFullDescriptorName(ClassKind.Immutable));
                using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
                {
                    bool __tmp6_last = __tmp6Reader.EndOfStream;
                    while(!__tmp6_last)
                    {
                        string __tmp6Line = __tmp6Reader.ReadLine();
                        __tmp6_last = __tmp6Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp6Line))
                        {
                            __out.Append(__tmp6Line);
                        }
                        if (!__tmp6_last) __out.AppendLine(true);
                    }
                }
                string __tmp7Line = ".MetaClass"; //1002:73
                if (!string.IsNullOrEmpty(__tmp7Line))
                {
                    __out.Append(__tmp7Line);
                }
            }
            else if (expr is MetaCollectionType) //1003:2
            {
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(((MetaCollectionType)expr).CSharpFullName(ClassKind.Immutable));
                using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                {
                    bool __tmp11_last = __tmp11Reader.EndOfStream;
                    while(!__tmp11_last)
                    {
                        string __tmp11Line = __tmp11Reader.ReadLine();
                        __tmp11_last = __tmp11Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp11Line))
                        {
                            __out.Append(__tmp11Line);
                        }
                    }
                }
            }
            else //1004:2
            {
                __out.Append("***error***"); //1004:11
            }//1005:2
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

