using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable //1:1
{
    using __Hidden_ImmutableMetaModelGenerator_56029506;
    namespace __Hidden_ImmutableMetaModelGenerator_56029506
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

    public class ImmutableMetaModelGenerator //2:1
    {
        private IEnumerable<ImmutableSymbol> Instances; //2:1

        public ImmutableMetaModelGenerator() //2:1
        {
        }

        public ImmutableMetaModelGenerator(IEnumerable<ImmutableSymbol> instances) : this() //2:1
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
            __out.Append("using System.Diagnostics;"); //12:1
            __out.AppendLine(false); //12:26
            __out.Append("using MetaDslx.Core.Immutable;"); //13:1
            __out.AppendLine(false); //13:31
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
            __tmp4.Append(model.Namespace.Name);
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
                        __out.AppendLine(false); //21:33
                    }
                }
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //21:33
            }
            __out.Append("{"); //22:1
            __out.AppendLine(false); //22:2
            bool __tmp6OutputWritten = false;
            string __tmp5Prefix = "	"; //23:1
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
                        __out.AppendLine(false); //23:38
                    }
                }
            }
            if (__tmp6OutputWritten)
            {
                __out.AppendLine(false); //23:38
            }
            bool __tmp9OutputWritten = false;
            string __tmp8Prefix = "	"; //24:1
            StringBuilder __tmp10 = new StringBuilder();
            __tmp10.Append(GenerateMetaModelInstance(model));
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
                        __out.AppendLine(false); //24:36
                    }
                }
            }
            if (__tmp9OutputWritten)
            {
                __out.AppendLine(false); //24:36
            }
            bool __tmp12OutputWritten = false;
            string __tmp11Prefix = "    "; //25:1
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(GenerateFactory(model));
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
                    if (__tmp12OutputWritten)
                    {
                        __out.AppendLine(false); //25:29
                    }
                }
            }
            if (__tmp12OutputWritten)
            {
                __out.AppendLine(false); //25:29
            }
            bool __tmp15OutputWritten = false;
            string __tmp14Prefix = "    "; //26:1
            StringBuilder __tmp16 = new StringBuilder();
            __tmp16.Append(GenerateImplementationProvider(model));
            using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
            {
                bool __tmp16_last = __tmp16Reader.EndOfStream;
                while(!__tmp16_last)
                {
                    string __tmp16Line = __tmp16Reader.ReadLine();
                    __tmp16_last = __tmp16Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp14Prefix))
                    {
                        __out.Append(__tmp14Prefix);
                        __tmp15OutputWritten = true;
                    }
                    if (!string.IsNullOrEmpty(__tmp16Line))
                    {
                        __out.Append(__tmp16Line);
                        __tmp15OutputWritten = true;
                    }
                    if (__tmp15OutputWritten)
                    {
                        __out.AppendLine(false); //26:44
                    }
                }
            }
            if (__tmp15OutputWritten)
            {
                __out.AppendLine(false); //26:44
            }
            var __loop2_results = 
                (from __loop2_var1 in __Enumerate((model).GetEnumerator()) //27:8
                from Namespace in __Enumerate((__loop2_var1.Namespace).GetEnumerator()) //27:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //27:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //27:40
                select new { __loop2_var1 = __loop2_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //27:3
            for (int __loop2_iteration = 0; __loop2_iteration < __loop2_results.Count; ++__loop2_iteration)
            {
                var __tmp17 = __loop2_results[__loop2_iteration];
                var __loop2_var1 = __tmp17.__loop2_var1;
                var Namespace = __tmp17.Namespace;
                var Declarations = __tmp17.Declarations;
                var enm = __tmp17.enm;
                bool __tmp19OutputWritten = false;
                string __tmp18Prefix = "    "; //28:1
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(GenerateEnum(enm));
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
                        if (__tmp19OutputWritten)
                        {
                            __out.AppendLine(false); //28:24
                        }
                    }
                }
                if (__tmp19OutputWritten)
                {
                    __out.AppendLine(false); //28:24
                }
            }
            __out.Append("}"); //30:1
            __out.AppendLine(false); //30:2
            return __out.ToString();
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //33:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateMetaModelInstance(MetaModel model) //37:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //41:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //45:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateDocumentation(MetaDocumentedElement elem) //49:1
        {
            StringBuilder __out = new StringBuilder();
            ImmutableModelList<string> lines = elem.GetDocumentationLines(); //50:2
            if (lines.Count > 0) //51:2
            {
                __out.Append("/**"); //52:1
                __out.AppendLine(false); //52:4
                __out.Append(" * <summary>"); //53:1
                __out.AppendLine(false); //53:13
                var __loop3_results = 
                    (from line in __Enumerate((lines).GetEnumerator()) //54:8
                    select new { line = line}
                    ).ToList(); //54:3
                for (int __loop3_iteration = 0; __loop3_iteration < __loop3_results.Count; ++__loop3_iteration)
                {
                    var __tmp1 = __loop3_results[__loop3_iteration];
                    var line = __tmp1.line;
                    bool __tmp3OutputWritten = false;
                    string __tmp4Line = " * "; //55:1
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
                                __out.AppendLine(false); //55:10
                            }
                        }
                    }
                    if (__tmp3OutputWritten)
                    {
                        __out.AppendLine(false); //55:10
                    }
                }
                __out.Append(" * </summary>"); //57:1
                __out.AppendLine(false); //57:14
                __out.Append(" */"); //58:1
                __out.AppendLine(false); //58:4
            }
            return __out.ToString();
        }

        public string GenerateEnum(MetaEnum enm) //62:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2OutputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateDocumentation(enm));
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
                        __out.AppendLine(false); //63:29
                    }
                }
            }
            if (__tmp2OutputWritten)
            {
                __out.AppendLine(false); //63:29
            }
            bool __tmp5OutputWritten = false;
            string __tmp6Line = "public enum "; //64:1
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
                        __out.AppendLine(false); //64:31
                    }
                }
            }
            if (__tmp5OutputWritten)
            {
                __out.AppendLine(false); //64:31
            }
            __out.Append("{"); //65:1
            __out.AppendLine(false); //65:2
            var __loop4_results = 
                (from __loop4_var1 in __Enumerate((enm).GetEnumerator()) //66:11
                from value in __Enumerate((__loop4_var1.EnumLiterals).GetEnumerator()) //66:16
                select new { __loop4_var1 = __loop4_var1, value = value}
                ).ToList(); //66:6
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                string delim; //66:34
                if (__loop4_iteration+1 < __loop4_results.Count) delim = ",";
                else delim = string.Empty;
                var __tmp8 = __loop4_results[__loop4_iteration];
                var __loop4_var1 = __tmp8.__loop4_var1;
                var value = __tmp8.value;
                bool __tmp10OutputWritten = false;
                string __tmp9Prefix = "	"; //67:1
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(GenerateDocumentation(value));
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
                            __out.AppendLine(false); //67:32
                        }
                    }
                }
                if (__tmp10OutputWritten)
                {
                    __out.AppendLine(false); //67:32
                }
                bool __tmp13OutputWritten = false;
                string __tmp12Prefix = "	"; //68:1
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(value.Name);
                using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
                {
                    bool __tmp14_last = __tmp14Reader.EndOfStream;
                    while(!__tmp14_last)
                    {
                        string __tmp14Line = __tmp14Reader.ReadLine();
                        __tmp14_last = __tmp14Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp12Prefix))
                        {
                            __out.Append(__tmp12Prefix);
                            __tmp13OutputWritten = true;
                        }
                        if (!string.IsNullOrEmpty(__tmp14Line))
                        {
                            __out.Append(__tmp14Line);
                            __tmp13OutputWritten = true;
                        }
                        if (!__tmp14_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp15 = new StringBuilder();
                __tmp15.Append(delim);
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
                        if (__tmp13OutputWritten)
                        {
                            __out.AppendLine(false); //68:21
                        }
                    }
                }
                if (__tmp13OutputWritten)
                {
                    __out.AppendLine(false); //68:21
                }
            }
            __out.Append("}"); //70:1
            __out.AppendLine(false); //70:2
            __out.AppendLine(true); //71:1
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
