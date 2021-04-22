// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.CodeAnalysis.Symbols.CodeGeneration //1:1
{
    using __Hidden_SymbolGenerator;
    namespace __Hidden_SymbolGenerator
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


    public class SymbolGenerator //2:1
    {
        public SymbolGenerator() //2:1
        {
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

        public string GenerateSymbol(SymbolGenerationInfo symbol) //4:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("using MetaDslx.CodeAnalysis;"); //5:1
            __out.AppendLine(false); //5:29
            __out.Append("using MetaDslx.CodeAnalysis.Declarations;"); //6:1
            __out.AppendLine(false); //6:42
            __out.Append("using MetaDslx.CodeAnalysis.Symbols;"); //7:1
            __out.AppendLine(false); //7:37
            __out.Append("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //8:1
            __out.AppendLine(false); //8:46
            __out.Append("using MetaDslx.CodeAnalysis.Symbols.Source;"); //9:1
            __out.AppendLine(false); //9:44
            __out.Append("using System;"); //10:1
            __out.AppendLine(false); //10:14
            __out.Append("using System.Collections.Generic;"); //11:1
            __out.AppendLine(false); //11:34
            __out.Append("using System.Collections.Immutable;"); //12:1
            __out.AppendLine(false); //12:36
            __out.Append("using System.Diagnostics;"); //13:1
            __out.AppendLine(false); //13:26
            __out.Append("using System.Text;"); //14:1
            __out.AppendLine(false); //14:19
            __out.Append("using System.Threading;"); //15:1
            __out.AppendLine(false); //15:24
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //17:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Append(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(symbol.NamespaceName);
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4_line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if ((__tmp4_last && !string.IsNullOrEmpty(__tmp4_line)) || (!__tmp4_last && __tmp4_line != null))
                    {
                        __out.Append(__tmp4_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp4_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //17:33
            }
            __out.Append("{"); //18:1
            __out.AppendLine(false); //18:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	public partial class "; //19:1
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp6_outputWritten = true;
            }
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(symbol.Name);
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(!__tmp8_last)
                {
                    string __tmp8_line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if ((__tmp8_last && !string.IsNullOrEmpty(__tmp8_line)) || (!__tmp8_last && __tmp8_line != null))
                    {
                        __out.Append(__tmp8_line);
                        __tmp6_outputWritten = true;
                    }
                    if (!__tmp8_last || __tmp6_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //19:36
            }
            __out.Append("	{"); //20:1
            __out.AppendLine(false); //20:3
            if (symbol.ParentSymbol != null && symbol.ParentSymbol.SubSymbolKind != null) //21:10
            {
                bool __tmp10_outputWritten = false;
                string __tmp11_line = "        public sealed override "; //22:1
                if (!string.IsNullOrEmpty(__tmp11_line))
                {
                    __out.Append(__tmp11_line);
                    __tmp10_outputWritten = true;
                }
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(symbol.ParentSymbol.SubSymbolKind);
                using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
                {
                    bool __tmp12_last = __tmp12Reader.EndOfStream;
                    while(!__tmp12_last)
                    {
                        string __tmp12_line = __tmp12Reader.ReadLine();
                        __tmp12_last = __tmp12Reader.EndOfStream;
                        if ((__tmp12_last && !string.IsNullOrEmpty(__tmp12_line)) || (!__tmp12_last && __tmp12_line != null))
                        {
                            __out.Append(__tmp12_line);
                            __tmp10_outputWritten = true;
                        }
                        if (!__tmp12_last) __out.AppendLine(true);
                    }
                }
                string __tmp13_line = " "; //22:67
                if (!string.IsNullOrEmpty(__tmp13_line))
                {
                    __out.Append(__tmp13_line);
                    __tmp10_outputWritten = true;
                }
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(symbol.ParentSymbol.SubSymbolKindName);
                using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
                {
                    bool __tmp14_last = __tmp14Reader.EndOfStream;
                    while(!__tmp14_last)
                    {
                        string __tmp14_line = __tmp14Reader.ReadLine();
                        __tmp14_last = __tmp14Reader.EndOfStream;
                        if ((__tmp14_last && !string.IsNullOrEmpty(__tmp14_line)) || (!__tmp14_last && __tmp14_line != null))
                        {
                            __out.Append(__tmp14_line);
                            __tmp10_outputWritten = true;
                        }
                        if (!__tmp14_last) __out.AppendLine(true);
                    }
                }
                string __tmp15_line = " => "; //22:107
                if (!string.IsNullOrEmpty(__tmp15_line))
                {
                    __out.Append(__tmp15_line);
                    __tmp10_outputWritten = true;
                }
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(symbol.ParentSymbol.SubSymbolKind);
                using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
                {
                    bool __tmp16_last = __tmp16Reader.EndOfStream;
                    while(!__tmp16_last)
                    {
                        string __tmp16_line = __tmp16Reader.ReadLine();
                        __tmp16_last = __tmp16Reader.EndOfStream;
                        if ((__tmp16_last && !string.IsNullOrEmpty(__tmp16_line)) || (!__tmp16_last && __tmp16_line != null))
                        {
                            __out.Append(__tmp16_line);
                            __tmp10_outputWritten = true;
                        }
                        if (!__tmp16_last) __out.AppendLine(true);
                    }
                }
                string __tmp17_line = "."; //22:146
                if (!string.IsNullOrEmpty(__tmp17_line))
                {
                    __out.Append(__tmp17_line);
                    __tmp10_outputWritten = true;
                }
                StringBuilder __tmp18 = new StringBuilder();
                __tmp18.Append(symbol.SymbolKind);
                using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
                {
                    bool __tmp18_last = __tmp18Reader.EndOfStream;
                    while(!__tmp18_last)
                    {
                        string __tmp18_line = __tmp18Reader.ReadLine();
                        __tmp18_last = __tmp18Reader.EndOfStream;
                        if ((__tmp18_last && !string.IsNullOrEmpty(__tmp18_line)) || (!__tmp18_last && __tmp18_line != null))
                        {
                            __out.Append(__tmp18_line);
                            __tmp10_outputWritten = true;
                        }
                        if (!__tmp18_last) __out.AppendLine(true);
                    }
                }
                string __tmp19_line = ";"; //22:166
                if (!string.IsNullOrEmpty(__tmp19_line))
                {
                    __out.Append(__tmp19_line);
                    __tmp10_outputWritten = true;
                }
                if (__tmp10_outputWritten) __out.AppendLine(true);
                if (__tmp10_outputWritten)
                {
                    __out.AppendLine(false); //22:167
                }
            }
            __out.AppendLine(true); //24:1
            if (symbol.SubSymbolKind != null) //25:10
            {
                bool __tmp21_outputWritten = false;
                string __tmp22_line = "        public virtual "; //26:1
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Append(__tmp22_line);
                    __tmp21_outputWritten = true;
                }
                StringBuilder __tmp23 = new StringBuilder();
                __tmp23.Append(symbol.SubSymbolKind);
                using(StreamReader __tmp23Reader = new StreamReader(this.__ToStream(__tmp23.ToString())))
                {
                    bool __tmp23_last = __tmp23Reader.EndOfStream;
                    while(!__tmp23_last)
                    {
                        string __tmp23_line = __tmp23Reader.ReadLine();
                        __tmp23_last = __tmp23Reader.EndOfStream;
                        if ((__tmp23_last && !string.IsNullOrEmpty(__tmp23_line)) || (!__tmp23_last && __tmp23_line != null))
                        {
                            __out.Append(__tmp23_line);
                            __tmp21_outputWritten = true;
                        }
                        if (!__tmp23_last) __out.AppendLine(true);
                    }
                }
                string __tmp24_line = " "; //26:46
                if (!string.IsNullOrEmpty(__tmp24_line))
                {
                    __out.Append(__tmp24_line);
                    __tmp21_outputWritten = true;
                }
                StringBuilder __tmp25 = new StringBuilder();
                __tmp25.Append(symbol.SubSymbolKindName);
                using(StreamReader __tmp25Reader = new StreamReader(this.__ToStream(__tmp25.ToString())))
                {
                    bool __tmp25_last = __tmp25Reader.EndOfStream;
                    while(!__tmp25_last)
                    {
                        string __tmp25_line = __tmp25Reader.ReadLine();
                        __tmp25_last = __tmp25Reader.EndOfStream;
                        if ((__tmp25_last && !string.IsNullOrEmpty(__tmp25_line)) || (!__tmp25_last && __tmp25_line != null))
                        {
                            __out.Append(__tmp25_line);
                            __tmp21_outputWritten = true;
                        }
                        if (!__tmp25_last) __out.AppendLine(true);
                    }
                }
                string __tmp26_line = " => "; //26:73
                if (!string.IsNullOrEmpty(__tmp26_line))
                {
                    __out.Append(__tmp26_line);
                    __tmp21_outputWritten = true;
                }
                StringBuilder __tmp27 = new StringBuilder();
                __tmp27.Append(symbol.SubSymbolKind);
                using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
                {
                    bool __tmp27_last = __tmp27Reader.EndOfStream;
                    while(!__tmp27_last)
                    {
                        string __tmp27_line = __tmp27Reader.ReadLine();
                        __tmp27_last = __tmp27Reader.EndOfStream;
                        if ((__tmp27_last && !string.IsNullOrEmpty(__tmp27_line)) || (!__tmp27_last && __tmp27_line != null))
                        {
                            __out.Append(__tmp27_line);
                            __tmp21_outputWritten = true;
                        }
                        if (!__tmp27_last) __out.AppendLine(true);
                    }
                }
                string __tmp28_line = ".None;"; //26:99
                if (!string.IsNullOrEmpty(__tmp28_line))
                {
                    __out.Append(__tmp28_line);
                    __tmp21_outputWritten = true;
                }
                if (__tmp21_outputWritten) __out.AppendLine(true);
                if (__tmp21_outputWritten)
                {
                    __out.AppendLine(false); //26:105
                }
            }
            __out.AppendLine(true); //28:1
            __out.Append("        public "); //29:1
            if (symbol.IsSymbolClass) //29:17
            {
                __out.Append("virtual"); //29:43
            }
            else //29:51
            {
                __out.Append("override"); //29:56
            }
            __out.Append(" void Accept(SymbolVisitor visitor)"); //29:72
            __out.AppendLine(false); //29:107
            __out.Append("        {"); //30:1
            __out.AppendLine(false); //30:10
            __out.Append("            visitor.Accept(this);"); //31:1
            __out.AppendLine(false); //31:34
            __out.Append("        }"); //32:1
            __out.AppendLine(false); //32:10
            __out.Append("        public "); //34:1
            if (symbol.IsSymbolClass) //34:17
            {
                __out.Append("virtual"); //34:43
            }
            else //34:51
            {
                __out.Append("override"); //34:56
            }
            __out.Append(" TResult Accept<TResult>(SymbolVisitor<TResult> visitor)"); //34:72
            __out.AppendLine(false); //34:128
            __out.Append("        {"); //35:1
            __out.AppendLine(false); //35:10
            __out.Append("            return visitor.Accept(this);"); //36:1
            __out.AppendLine(false); //36:41
            __out.Append("        }"); //37:1
            __out.AppendLine(false); //37:10
            __out.Append("        public "); //39:1
            if (symbol.IsSymbolClass) //39:17
            {
                __out.Append("virtual"); //39:43
            }
            else //39:51
            {
                __out.Append("override"); //39:56
            }
            __out.Append(" TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)"); //39:72
            __out.AppendLine(false); //39:170
            __out.Append("        {"); //40:1
            __out.AppendLine(false); //40:10
            __out.Append("            return visitor.Accept(this, argument);"); //41:1
            __out.AppendLine(false); //41:51
            __out.Append("        }"); //42:1
            __out.AppendLine(false); //42:10
            __out.Append("	}"); //44:1
            __out.AppendLine(false); //44:3
            __out.Append("    public abstract partial class SymbolVisitor"); //46:1
            __out.AppendLine(false); //46:48
            __out.Append("    {"); //47:1
            __out.AppendLine(false); //47:6
            bool __tmp30_outputWritten = false;
            string __tmp31_line = "        public virtual void Visit"; //48:1
            if (!string.IsNullOrEmpty(__tmp31_line))
            {
                __out.Append(__tmp31_line);
                __tmp30_outputWritten = true;
            }
            StringBuilder __tmp32 = new StringBuilder();
            __tmp32.Append(symbol.SymbolKind);
            using(StreamReader __tmp32Reader = new StreamReader(this.__ToStream(__tmp32.ToString())))
            {
                bool __tmp32_last = __tmp32Reader.EndOfStream;
                while(!__tmp32_last)
                {
                    string __tmp32_line = __tmp32Reader.ReadLine();
                    __tmp32_last = __tmp32Reader.EndOfStream;
                    if ((__tmp32_last && !string.IsNullOrEmpty(__tmp32_line)) || (!__tmp32_last && __tmp32_line != null))
                    {
                        __out.Append(__tmp32_line);
                        __tmp30_outputWritten = true;
                    }
                    if (!__tmp32_last) __out.AppendLine(true);
                }
            }
            string __tmp33_line = "("; //48:53
            if (!string.IsNullOrEmpty(__tmp33_line))
            {
                __out.Append(__tmp33_line);
                __tmp30_outputWritten = true;
            }
            StringBuilder __tmp34 = new StringBuilder();
            __tmp34.Append(symbol.Name);
            using(StreamReader __tmp34Reader = new StreamReader(this.__ToStream(__tmp34.ToString())))
            {
                bool __tmp34_last = __tmp34Reader.EndOfStream;
                while(!__tmp34_last)
                {
                    string __tmp34_line = __tmp34Reader.ReadLine();
                    __tmp34_last = __tmp34Reader.EndOfStream;
                    if ((__tmp34_last && !string.IsNullOrEmpty(__tmp34_line)) || (!__tmp34_last && __tmp34_line != null))
                    {
                        __out.Append(__tmp34_line);
                        __tmp30_outputWritten = true;
                    }
                    if (!__tmp34_last) __out.AppendLine(true);
                }
            }
            string __tmp35_line = " symbol)"; //48:67
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Append(__tmp35_line);
                __tmp30_outputWritten = true;
            }
            if (__tmp30_outputWritten) __out.AppendLine(true);
            if (__tmp30_outputWritten)
            {
                __out.AppendLine(false); //48:75
            }
            __out.Append("        {"); //49:1
            __out.AppendLine(false); //49:10
            __out.Append("            DefaultVisit(symbol);"); //50:1
            __out.AppendLine(false); //50:34
            __out.Append("        }        "); //51:1
            __out.AppendLine(false); //51:18
            __out.Append("    }"); //52:1
            __out.AppendLine(false); //52:6
            __out.Append("    public abstract partial class SymbolVisitor<TResult>"); //54:1
            __out.AppendLine(false); //54:57
            __out.Append("    {"); //55:1
            __out.AppendLine(false); //55:6
            bool __tmp37_outputWritten = false;
            string __tmp38_line = "        public virtual TResult Visit"; //56:1
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Append(__tmp38_line);
                __tmp37_outputWritten = true;
            }
            StringBuilder __tmp39 = new StringBuilder();
            __tmp39.Append(symbol.SymbolKind);
            using(StreamReader __tmp39Reader = new StreamReader(this.__ToStream(__tmp39.ToString())))
            {
                bool __tmp39_last = __tmp39Reader.EndOfStream;
                while(!__tmp39_last)
                {
                    string __tmp39_line = __tmp39Reader.ReadLine();
                    __tmp39_last = __tmp39Reader.EndOfStream;
                    if ((__tmp39_last && !string.IsNullOrEmpty(__tmp39_line)) || (!__tmp39_last && __tmp39_line != null))
                    {
                        __out.Append(__tmp39_line);
                        __tmp37_outputWritten = true;
                    }
                    if (!__tmp39_last) __out.AppendLine(true);
                }
            }
            string __tmp40_line = "("; //56:56
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Append(__tmp40_line);
                __tmp37_outputWritten = true;
            }
            StringBuilder __tmp41 = new StringBuilder();
            __tmp41.Append(symbol.Name);
            using(StreamReader __tmp41Reader = new StreamReader(this.__ToStream(__tmp41.ToString())))
            {
                bool __tmp41_last = __tmp41Reader.EndOfStream;
                while(!__tmp41_last)
                {
                    string __tmp41_line = __tmp41Reader.ReadLine();
                    __tmp41_last = __tmp41Reader.EndOfStream;
                    if ((__tmp41_last && !string.IsNullOrEmpty(__tmp41_line)) || (!__tmp41_last && __tmp41_line != null))
                    {
                        __out.Append(__tmp41_line);
                        __tmp37_outputWritten = true;
                    }
                    if (!__tmp41_last) __out.AppendLine(true);
                }
            }
            string __tmp42_line = " symbol)"; //56:70
            if (!string.IsNullOrEmpty(__tmp42_line))
            {
                __out.Append(__tmp42_line);
                __tmp37_outputWritten = true;
            }
            if (__tmp37_outputWritten) __out.AppendLine(true);
            if (__tmp37_outputWritten)
            {
                __out.AppendLine(false); //56:78
            }
            __out.Append("        {"); //57:1
            __out.AppendLine(false); //57:10
            __out.Append("            return DefaultVisit(symbol);"); //58:1
            __out.AppendLine(false); //58:41
            __out.Append("        }       "); //59:1
            __out.AppendLine(false); //59:17
            __out.Append("    }"); //60:1
            __out.AppendLine(false); //60:6
            __out.Append("    public abstract partial class SymbolVisitor<TArgument, TResult>"); //62:1
            __out.AppendLine(false); //62:68
            __out.Append("    {"); //63:1
            __out.AppendLine(false); //63:6
            bool __tmp44_outputWritten = false;
            string __tmp45_line = "        public virtual TResult Visit"; //64:1
            if (!string.IsNullOrEmpty(__tmp45_line))
            {
                __out.Append(__tmp45_line);
                __tmp44_outputWritten = true;
            }
            StringBuilder __tmp46 = new StringBuilder();
            __tmp46.Append(symbol.SymbolKind);
            using(StreamReader __tmp46Reader = new StreamReader(this.__ToStream(__tmp46.ToString())))
            {
                bool __tmp46_last = __tmp46Reader.EndOfStream;
                while(!__tmp46_last)
                {
                    string __tmp46_line = __tmp46Reader.ReadLine();
                    __tmp46_last = __tmp46Reader.EndOfStream;
                    if ((__tmp46_last && !string.IsNullOrEmpty(__tmp46_line)) || (!__tmp46_last && __tmp46_line != null))
                    {
                        __out.Append(__tmp46_line);
                        __tmp44_outputWritten = true;
                    }
                    if (!__tmp46_last) __out.AppendLine(true);
                }
            }
            string __tmp47_line = "("; //64:56
            if (!string.IsNullOrEmpty(__tmp47_line))
            {
                __out.Append(__tmp47_line);
                __tmp44_outputWritten = true;
            }
            StringBuilder __tmp48 = new StringBuilder();
            __tmp48.Append(symbol.Name);
            using(StreamReader __tmp48Reader = new StreamReader(this.__ToStream(__tmp48.ToString())))
            {
                bool __tmp48_last = __tmp48Reader.EndOfStream;
                while(!__tmp48_last)
                {
                    string __tmp48_line = __tmp48Reader.ReadLine();
                    __tmp48_last = __tmp48Reader.EndOfStream;
                    if ((__tmp48_last && !string.IsNullOrEmpty(__tmp48_line)) || (!__tmp48_last && __tmp48_line != null))
                    {
                        __out.Append(__tmp48_line);
                        __tmp44_outputWritten = true;
                    }
                    if (!__tmp48_last) __out.AppendLine(true);
                }
            }
            string __tmp49_line = "Symbol symbol, TArgument argument)"; //64:70
            if (!string.IsNullOrEmpty(__tmp49_line))
            {
                __out.Append(__tmp49_line);
                __tmp44_outputWritten = true;
            }
            if (__tmp44_outputWritten) __out.AppendLine(true);
            if (__tmp44_outputWritten)
            {
                __out.AppendLine(false); //64:104
            }
            __out.Append("        {"); //65:1
            __out.AppendLine(false); //65:10
            __out.Append("            return DefaultVisit(symbol, argument);"); //66:1
            __out.AppendLine(false); //66:51
            __out.Append("        }      "); //67:1
            __out.AppendLine(false); //67:16
            __out.Append("    }"); //68:1
            __out.AppendLine(false); //68:6
            __out.Append("}"); //69:1
            __out.AppendLine(false); //69:2
            return __out.ToString();
        }

        public string GenerateSourceSymbol(string namespaceName, string className) //72:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("using MetaDslx.CodeAnalysis;"); //73:1
            __out.AppendLine(false); //73:29
            __out.Append("using MetaDslx.CodeAnalysis.Declarations;"); //74:1
            __out.AppendLine(false); //74:42
            __out.Append("using MetaDslx.CodeAnalysis.Symbols;"); //75:1
            __out.AppendLine(false); //75:37
            __out.Append("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //76:1
            __out.AppendLine(false); //76:46
            __out.Append("using MetaDslx.CodeAnalysis.Symbols.Source;"); //77:1
            __out.AppendLine(false); //77:44
            __out.Append("using System;"); //78:1
            __out.AppendLine(false); //78:14
            __out.Append("using System.Collections.Generic;"); //79:1
            __out.AppendLine(false); //79:34
            __out.Append("using System.Collections.Immutable;"); //80:1
            __out.AppendLine(false); //80:36
            __out.Append("using System.Diagnostics;"); //81:1
            __out.AppendLine(false); //81:26
            __out.Append("using System.Text;"); //82:1
            __out.AppendLine(false); //82:19
            __out.Append("using System.Threading;"); //83:1
            __out.AppendLine(false); //83:24
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //85:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Append(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(namespaceName);
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4_line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if ((__tmp4_last && !string.IsNullOrEmpty(__tmp4_line)) || (!__tmp4_last && __tmp4_line != null))
                    {
                        __out.Append(__tmp4_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp4_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //85:26
            }
            __out.Append("{"); //86:1
            __out.AppendLine(false); //86:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	public partial class "; //87:1
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp6_outputWritten = true;
            }
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(className);
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(!__tmp8_last)
                {
                    string __tmp8_line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if ((__tmp8_last && !string.IsNullOrEmpty(__tmp8_line)) || (!__tmp8_last && __tmp8_line != null))
                    {
                        __out.Append(__tmp8_line);
                        __tmp6_outputWritten = true;
                    }
                    if (!__tmp8_last || __tmp6_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //87:34
            }
            __out.Append("	{"); //88:1
            __out.AppendLine(false); //88:3
            __out.Append("        private readonly Symbol _containingSymbol;"); //89:1
            __out.AppendLine(false); //89:51
            __out.Append("        private readonly MergedDeclaration _declaration;"); //90:1
            __out.AppendLine(false); //90:57
            __out.Append("        private readonly CompletionState _state;"); //91:1
            __out.AppendLine(false); //91:49
            __out.Append("        private DiagnosticBag _diagnostics;"); //92:1
            __out.AppendLine(false); //92:44
            bool __tmp10_outputWritten = false;
            string __tmp11_line = "		public "; //94:1
            if (!string.IsNullOrEmpty(__tmp11_line))
            {
                __out.Append(__tmp11_line);
                __tmp10_outputWritten = true;
            }
            StringBuilder __tmp12 = new StringBuilder();
            __tmp12.Append(className);
            using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
            {
                bool __tmp12_last = __tmp12Reader.EndOfStream;
                while(!__tmp12_last)
                {
                    string __tmp12_line = __tmp12Reader.ReadLine();
                    __tmp12_last = __tmp12Reader.EndOfStream;
                    if ((__tmp12_last && !string.IsNullOrEmpty(__tmp12_line)) || (!__tmp12_last && __tmp12_line != null))
                    {
                        __out.Append(__tmp12_line);
                        __tmp10_outputWritten = true;
                    }
                    if (!__tmp12_last) __out.AppendLine(true);
                }
            }
            string __tmp13_line = "(Symbol containingSymbol, MergedDeclaration declaration)"; //94:21
            if (!string.IsNullOrEmpty(__tmp13_line))
            {
                __out.Append(__tmp13_line);
                __tmp10_outputWritten = true;
            }
            if (__tmp10_outputWritten) __out.AppendLine(true);
            if (__tmp10_outputWritten)
            {
                __out.AppendLine(false); //94:77
            }
            __out.Append("		{"); //95:1
            __out.AppendLine(false); //95:4
            __out.Append("            Debug.Assert(declaration != null);"); //96:1
            __out.AppendLine(false); //96:47
            __out.Append("            _containingSymbol = containingSymbol;"); //97:1
            __out.AppendLine(false); //97:50
            __out.Append("            _declaration = declaration;"); //98:1
            __out.AppendLine(false); //98:40
            __out.Append("            _state = CompletionState.Create(Language);"); //99:1
            __out.AppendLine(false); //99:55
            __out.Append("		}"); //100:1
            __out.AppendLine(false); //100:4
            __out.Append("        public override Symbol ContainingSymbol => _containingSymbol;"); //102:1
            __out.AppendLine(false); //102:70
            __out.Append("        public override ImmutableArray<Symbol> ChildSymbols => ImmutableArray<Symbol>.Empty;"); //104:1
            __out.AppendLine(false); //104:93
            __out.Append("        public MergedDeclaration MergedDeclaration => _declaration;"); //106:1
            __out.AppendLine(false); //106:68
            __out.Append("        public override ImmutableArray<Location> Locations => _declaration.NameLocations;"); //108:1
            __out.AppendLine(false); //108:90
            __out.Append("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration.SyntaxReferences;"); //110:1
            __out.AppendLine(false); //110:116
            __out.Append("        public ImmutableArray<Diagnostic> Diagnostics => _diagnostics != null ? _diagnostics.ToReadOnly() : ImmutableArray<Diagnostic>.Empty;"); //112:1
            __out.AppendLine(false); //112:142
            __out.Append("        private void AddSymbolDiagnostics(DiagnosticBag diagnostics)"); //114:1
            __out.AppendLine(false); //114:69
            __out.Append("        {"); //115:1
            __out.AppendLine(false); //115:10
            __out.Append("            if (!diagnostics.IsEmptyWithoutResolution)"); //116:1
            __out.AppendLine(false); //116:55
            __out.Append("            {"); //117:1
            __out.AppendLine(false); //117:14
            __out.Append("                LanguageCompilation compilation = this.DeclaringCompilation;"); //118:1
            __out.AppendLine(false); //118:77
            __out.Append("                Debug.Assert(compilation != null);"); //119:1
            __out.AppendLine(false); //119:51
            __out.Append("                if (_diagnostics == null) _diagnostics = new DiagnosticBag();"); //120:1
            __out.AppendLine(false); //120:78
            __out.Append("                _diagnostics.AddRange(diagnostics);"); //121:1
            __out.AppendLine(false); //121:52
            __out.Append("            }"); //122:1
            __out.AppendLine(false); //122:14
            __out.Append("        }"); //123:1
            __out.AppendLine(false); //123:10
            __out.Append("        public override void Accept(CodeAnalysis.SymbolVisitor visitor)"); //125:1
            __out.AppendLine(false); //125:72
            __out.Append("        {"); //126:1
            __out.AppendLine(false); //126:10
            __out.Append("            throw new NotImplementedException();"); //127:1
            __out.AppendLine(false); //127:49
            __out.Append("        }"); //128:1
            __out.AppendLine(false); //128:10
            __out.Append("        public override TResult Accept<TResult>(CodeAnalysis.SymbolVisitor<TResult> visitor)"); //130:1
            __out.AppendLine(false); //130:93
            __out.Append("        {"); //131:1
            __out.AppendLine(false); //131:10
            __out.Append("            throw new NotImplementedException();"); //132:1
            __out.AppendLine(false); //132:49
            __out.Append("        }"); //133:1
            __out.AppendLine(false); //133:10
            __out.Append("        public override void Accept(CodeAnalysis.Symbols.SymbolVisitor visitor)"); //135:1
            __out.AppendLine(false); //135:80
            __out.Append("        {"); //136:1
            __out.AppendLine(false); //136:10
            __out.Append("            throw new NotImplementedException();"); //137:1
            __out.AppendLine(false); //137:49
            __out.Append("        }"); //138:1
            __out.AppendLine(false); //138:10
            __out.Append("        public override TResult Accept<TResult>(CodeAnalysis.Symbols.SymbolVisitor<TResult> visitor)"); //140:1
            __out.AppendLine(false); //140:101
            __out.Append("        {"); //141:1
            __out.AppendLine(false); //141:10
            __out.Append("            throw new NotImplementedException();"); //142:1
            __out.AppendLine(false); //142:49
            __out.Append("        }"); //143:1
            __out.AppendLine(false); //143:10
            __out.Append("        public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)"); //145:1
            __out.AppendLine(false); //145:122
            __out.Append("        {"); //146:1
            __out.AppendLine(false); //146:10
            __out.Append("            throw new NotImplementedException();"); //147:1
            __out.AppendLine(false); //147:49
            __out.Append("        }"); //148:1
            __out.AppendLine(false); //148:10
            __out.Append("	}"); //150:1
            __out.AppendLine(false); //150:3
            __out.Append("}"); //151:1
            __out.AppendLine(false); //151:2
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

