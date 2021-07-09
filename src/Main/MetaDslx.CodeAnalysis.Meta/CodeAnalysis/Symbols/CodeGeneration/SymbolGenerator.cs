// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeGeneration;

namespace MetaDslx.CodeAnalysis.Symbols.CodeGeneration //1:1
{

    public class SymbolGenerator //2:1
    {
        public SymbolGenerator() //2:1
        {
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
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //5:1
            __out.AppendLine(false); //5:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //6:1
            __out.AppendLine(false); //6:29
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //7:1
            __out.AppendLine(false); //7:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //8:1
            __out.AppendLine(false); //8:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //9:1
            __out.AppendLine(false); //9:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //10:1
            __out.AppendLine(false); //10:44
            __out.Write("using System;"); //11:1
            __out.AppendLine(false); //11:14
            __out.Write("using System.Collections.Generic;"); //12:1
            __out.AppendLine(false); //12:34
            __out.Write("using System.Collections.Immutable;"); //13:1
            __out.AppendLine(false); //13:36
            __out.Write("using System.Diagnostics;"); //14:1
            __out.AppendLine(false); //14:26
            __out.Write("using System.Text;"); //15:1
            __out.AppendLine(false); //15:19
            __out.Write("using System.Threading;"); //16:1
            __out.AppendLine(false); //16:24
            __out.AppendLine(true); //17:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //18:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Write(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp4.Write(symbol.NamespaceName);
            var __tmp4Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp4.ToStringAndFree());
            bool __tmp4_last = __tmp4Reader.EndOfStream;
            while(!__tmp4_last)
            {
                ReadOnlySpan<char> __tmp4_line = __tmp4Reader.ReadLine();
                __tmp4_last = __tmp4Reader.EndOfStream;
                if (!__tmp4_last || !__tmp4_line.IsEmpty)
                {
                    __out.Write(__tmp4_line);
                    __tmp2_outputWritten = true;
                }
                if (!__tmp4_last || __tmp2_outputWritten) __out.AppendLine(true);
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //18:33
            }
            __out.Write("{"); //19:1
            __out.AppendLine(false); //19:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	public abstract partial class "; //20:1
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp6_outputWritten = true;
            }
            var __tmp8 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp8.Write(symbol.Name);
            var __tmp8Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp8.ToStringAndFree());
            bool __tmp8_last = __tmp8Reader.EndOfStream;
            while(!__tmp8_last)
            {
                ReadOnlySpan<char> __tmp8_line = __tmp8Reader.ReadLine();
                __tmp8_last = __tmp8Reader.EndOfStream;
                if (!__tmp8_last || !__tmp8_line.IsEmpty)
                {
                    __out.Write(__tmp8_line);
                    __tmp6_outputWritten = true;
                }
                if (!__tmp8_last || __tmp6_outputWritten) __out.AppendLine(true);
            }
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //20:45
            }
            __out.Write("	{"); //21:1
            __out.AppendLine(false); //21:3
            if (symbol.SymbolKindType != null) //22:10
            {
                __out.Write("        /// <summary>"); //23:1
                __out.AppendLine(false); //23:22
                __out.Write("        /// Gets the kind of this symbol."); //24:1
                __out.AppendLine(false); //24:42
                __out.Write("        /// </summary>"); //25:1
                __out.AppendLine(false); //25:23
                bool __tmp10_outputWritten = false;
                string __tmp11_line = "        public sealed override "; //26:1
                if (!string.IsNullOrEmpty(__tmp11_line))
                {
                    __out.Write(__tmp11_line);
                    __tmp10_outputWritten = true;
                }
                var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp12.Write(symbol.SymbolKindType);
                var __tmp12Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp12.ToStringAndFree());
                bool __tmp12_last = __tmp12Reader.EndOfStream;
                while(!__tmp12_last)
                {
                    ReadOnlySpan<char> __tmp12_line = __tmp12Reader.ReadLine();
                    __tmp12_last = __tmp12Reader.EndOfStream;
                    if (!__tmp12_last || !__tmp12_line.IsEmpty)
                    {
                        __out.Write(__tmp12_line);
                        __tmp10_outputWritten = true;
                    }
                    if (!__tmp12_last) __out.AppendLine(true);
                }
                string __tmp13_line = " "; //26:55
                if (!string.IsNullOrEmpty(__tmp13_line))
                {
                    __out.Write(__tmp13_line);
                    __tmp10_outputWritten = true;
                }
                var __tmp14 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp14.Write(symbol.SymbolKindName);
                var __tmp14Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp14.ToStringAndFree());
                bool __tmp14_last = __tmp14Reader.EndOfStream;
                while(!__tmp14_last)
                {
                    ReadOnlySpan<char> __tmp14_line = __tmp14Reader.ReadLine();
                    __tmp14_last = __tmp14Reader.EndOfStream;
                    if (!__tmp14_last || !__tmp14_line.IsEmpty)
                    {
                        __out.Write(__tmp14_line);
                        __tmp10_outputWritten = true;
                    }
                    if (!__tmp14_last) __out.AppendLine(true);
                }
                string __tmp15_line = " => "; //26:79
                if (!string.IsNullOrEmpty(__tmp15_line))
                {
                    __out.Write(__tmp15_line);
                    __tmp10_outputWritten = true;
                }
                var __tmp16 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp16.Write(symbol.SymbolKindType);
                var __tmp16Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp16.ToStringAndFree());
                bool __tmp16_last = __tmp16Reader.EndOfStream;
                while(!__tmp16_last)
                {
                    ReadOnlySpan<char> __tmp16_line = __tmp16Reader.ReadLine();
                    __tmp16_last = __tmp16Reader.EndOfStream;
                    if (!__tmp16_last || !__tmp16_line.IsEmpty)
                    {
                        __out.Write(__tmp16_line);
                        __tmp10_outputWritten = true;
                    }
                    if (!__tmp16_last) __out.AppendLine(true);
                }
                string __tmp17_line = "."; //26:106
                if (!string.IsNullOrEmpty(__tmp17_line))
                {
                    __out.Write(__tmp17_line);
                    __tmp10_outputWritten = true;
                }
                var __tmp18 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp18.Write(symbol.SymbolKind);
                var __tmp18Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp18.ToStringAndFree());
                bool __tmp18_last = __tmp18Reader.EndOfStream;
                while(!__tmp18_last)
                {
                    ReadOnlySpan<char> __tmp18_line = __tmp18Reader.ReadLine();
                    __tmp18_last = __tmp18Reader.EndOfStream;
                    if (!__tmp18_last || !__tmp18_line.IsEmpty)
                    {
                        __out.Write(__tmp18_line);
                        __tmp10_outputWritten = true;
                    }
                    if (!__tmp18_last) __out.AppendLine(true);
                }
                string __tmp19_line = ";"; //26:126
                if (!string.IsNullOrEmpty(__tmp19_line))
                {
                    __out.Write(__tmp19_line);
                    __tmp10_outputWritten = true;
                }
                if (__tmp10_outputWritten) __out.AppendLine(true);
                if (__tmp10_outputWritten)
                {
                    __out.AppendLine(false); //26:127
                }
            }
            __out.AppendLine(true); //28:1
            if (symbol.SubSymbolKindType != null) //29:10
            {
                __out.Write("        /// <summary>"); //30:1
                __out.AppendLine(false); //30:22
                __out.Write("        /// Gets the kind of this symbol."); //31:1
                __out.AppendLine(false); //31:42
                __out.Write("        /// </summary>"); //32:1
                __out.AppendLine(false); //32:23
                bool __tmp21_outputWritten = false;
                string __tmp22_line = "        public virtual "; //33:1
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Write(__tmp22_line);
                    __tmp21_outputWritten = true;
                }
                var __tmp23 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp23.Write(symbol.SubSymbolKindType);
                var __tmp23Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp23.ToStringAndFree());
                bool __tmp23_last = __tmp23Reader.EndOfStream;
                while(!__tmp23_last)
                {
                    ReadOnlySpan<char> __tmp23_line = __tmp23Reader.ReadLine();
                    __tmp23_last = __tmp23Reader.EndOfStream;
                    if (!__tmp23_last || !__tmp23_line.IsEmpty)
                    {
                        __out.Write(__tmp23_line);
                        __tmp21_outputWritten = true;
                    }
                    if (!__tmp23_last) __out.AppendLine(true);
                }
                string __tmp24_line = " "; //33:50
                if (!string.IsNullOrEmpty(__tmp24_line))
                {
                    __out.Write(__tmp24_line);
                    __tmp21_outputWritten = true;
                }
                var __tmp25 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp25.Write(symbol.SubSymbolKindName);
                var __tmp25Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp25.ToStringAndFree());
                bool __tmp25_last = __tmp25Reader.EndOfStream;
                while(!__tmp25_last)
                {
                    ReadOnlySpan<char> __tmp25_line = __tmp25Reader.ReadLine();
                    __tmp25_last = __tmp25Reader.EndOfStream;
                    if (!__tmp25_last || !__tmp25_line.IsEmpty)
                    {
                        __out.Write(__tmp25_line);
                        __tmp21_outputWritten = true;
                    }
                    if (!__tmp25_last) __out.AppendLine(true);
                }
                string __tmp26_line = " => "; //33:77
                if (!string.IsNullOrEmpty(__tmp26_line))
                {
                    __out.Write(__tmp26_line);
                    __tmp21_outputWritten = true;
                }
                var __tmp27 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp27.Write(symbol.SubSymbolKindType);
                var __tmp27Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp27.ToStringAndFree());
                bool __tmp27_last = __tmp27Reader.EndOfStream;
                while(!__tmp27_last)
                {
                    ReadOnlySpan<char> __tmp27_line = __tmp27Reader.ReadLine();
                    __tmp27_last = __tmp27Reader.EndOfStream;
                    if (!__tmp27_last || !__tmp27_line.IsEmpty)
                    {
                        __out.Write(__tmp27_line);
                        __tmp21_outputWritten = true;
                    }
                    if (!__tmp27_last) __out.AppendLine(true);
                }
                string __tmp28_line = ".None;"; //33:107
                if (!string.IsNullOrEmpty(__tmp28_line))
                {
                    __out.Write(__tmp28_line);
                    __tmp21_outputWritten = true;
                }
                if (__tmp21_outputWritten) __out.AppendLine(true);
                if (__tmp21_outputWritten)
                {
                    __out.AppendLine(false); //33:113
                }
            }
            __out.AppendLine(true); //35:1
            __out.Write("        public "); //36:1
            if (symbol.IsSymbolClass) //36:17
            {
                __out.Write("virtual"); //36:43
            }
            else //36:51
            {
                __out.Write("override"); //36:56
            }
            __out.Write(" void Accept(MetaDslx.CodeAnalysis.Symbols.SymbolVisitor visitor)"); //36:72
            __out.AppendLine(false); //36:137
            __out.Write("        {"); //37:1
            __out.AppendLine(false); //37:10
            __out.Write("            if (visitor is ISymbolVisitor isv) isv.Visit(this);"); //38:1
            __out.AppendLine(false); //38:64
            __out.Write("        }"); //39:1
            __out.AppendLine(false); //39:10
            __out.AppendLine(true); //40:1
            __out.Write("        public "); //41:1
            if (symbol.IsSymbolClass) //41:17
            {
                __out.Write("virtual"); //41:43
            }
            else //41:51
            {
                __out.Write("override"); //41:56
            }
            __out.Write(" TResult Accept<TResult>(MetaDslx.CodeAnalysis.Symbols.SymbolVisitor<TResult> visitor)"); //41:72
            __out.AppendLine(false); //41:158
            __out.Write("        {"); //42:1
            __out.AppendLine(false); //42:10
            __out.Write("            if (visitor is ISymbolVisitor<TResult> isv) return isv.Visit(this);"); //43:1
            __out.AppendLine(false); //43:80
            __out.Write("            else return default(TResult);"); //44:1
            __out.AppendLine(false); //44:42
            __out.Write("        }"); //45:1
            __out.AppendLine(false); //45:10
            __out.AppendLine(true); //46:1
            __out.Write("        public "); //47:1
            if (symbol.IsSymbolClass) //47:17
            {
                __out.Write("virtual"); //47:43
            }
            else //47:51
            {
                __out.Write("override"); //47:56
            }
            __out.Write(" TResult Accept<TArgument, TResult>(MetaDslx.CodeAnalysis.Symbols.SymbolVisitor<TArgument, TResult> visitor, TArgument argument)"); //47:72
            __out.AppendLine(false); //47:200
            __out.Write("        {"); //48:1
            __out.AppendLine(false); //48:10
            __out.Write("            if (visitor is ISymbolVisitor<TArgument, TResult> isv) return isv.Visit(this, argument);"); //49:1
            __out.AppendLine(false); //49:101
            __out.Write("            else return default(TResult);"); //50:1
            __out.AppendLine(false); //50:42
            __out.Write("        }"); //51:1
            __out.AppendLine(false); //51:10
            __out.AppendLine(true); //52:1
            __out.Write("        protected "); //53:1
            if (symbol.IsSymbolClass) //53:20
            {
                __out.Write("virtual"); //53:46
            }
            else //53:54
            {
                __out.Write("override"); //53:59
            }
            __out.Write(" ISymbol CreateISymbol()"); //53:75
            __out.AppendLine(false); //53:99
            __out.Write("        {"); //54:1
            __out.AppendLine(false); //54:10
            __out.Write("            throw new NotImplementedException();"); //55:1
            __out.AppendLine(false); //55:49
            __out.Write("        }"); //56:1
            __out.AppendLine(false); //56:10
            __out.Write("	}"); //57:1
            __out.AppendLine(false); //57:3
            __out.Write("}"); //58:1
            __out.AppendLine(false); //58:2
            return __out.ToStringAndFree();
        }

        public string GenerateModelSymbol(SymbolGenerationInfo symbol) //61:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //62:1
            __out.AppendLine(false); //62:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //63:1
            __out.AppendLine(false); //63:29
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //64:1
            __out.AppendLine(false); //64:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //65:1
            __out.AppendLine(false); //65:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //66:1
            __out.AppendLine(false); //66:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //67:1
            __out.AppendLine(false); //67:44
            __out.Write("using System;"); //68:1
            __out.AppendLine(false); //68:14
            __out.Write("using System.Collections.Generic;"); //69:1
            __out.AppendLine(false); //69:34
            __out.Write("using System.Collections.Immutable;"); //70:1
            __out.AppendLine(false); //70:36
            __out.Write("using System.Diagnostics;"); //71:1
            __out.AppendLine(false); //71:26
            __out.Write("using System.Text;"); //72:1
            __out.AppendLine(false); //72:19
            __out.Write("using System.Threading;"); //73:1
            __out.AppendLine(false); //73:24
            __out.Write("using Roslyn.Utilities;"); //74:1
            __out.AppendLine(false); //74:24
            __out.AppendLine(true); //75:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //76:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Write(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp4.Write(symbol.NamespaceName);
            var __tmp4Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp4.ToStringAndFree());
            bool __tmp4_last = __tmp4Reader.EndOfStream;
            while(!__tmp4_last)
            {
                ReadOnlySpan<char> __tmp4_line = __tmp4Reader.ReadLine();
                __tmp4_last = __tmp4Reader.EndOfStream;
                if (!__tmp4_last || !__tmp4_line.IsEmpty)
                {
                    __out.Write(__tmp4_line);
                    __tmp2_outputWritten = true;
                }
                if (!__tmp4_last) __out.AppendLine(true);
            }
            string __tmp5_line = ".Model"; //76:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //76:39
            }
            __out.Write("{"); //77:1
            __out.AppendLine(false); //77:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public abstract partial class Model"; //78:1
            if (!string.IsNullOrEmpty(__tmp8_line))
            {
                __out.Write(__tmp8_line);
                __tmp7_outputWritten = true;
            }
            var __tmp9 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp9.Write(symbol.Name);
            var __tmp9Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp9.ToStringAndFree());
            bool __tmp9_last = __tmp9Reader.EndOfStream;
            while(!__tmp9_last)
            {
                ReadOnlySpan<char> __tmp9_line = __tmp9Reader.ReadLine();
                __tmp9_last = __tmp9Reader.EndOfStream;
                if (!__tmp9_last || !__tmp9_line.IsEmpty)
                {
                    __out.Write(__tmp9_line);
                    __tmp7_outputWritten = true;
                }
                if (!__tmp9_last) __out.AppendLine(true);
            }
            string __tmp10_line = " : "; //78:50
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Write(__tmp10_line);
                __tmp7_outputWritten = true;
            }
            var __tmp11 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp11.Write(symbol.NamespaceName);
            var __tmp11Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp11.ToStringAndFree());
            bool __tmp11_last = __tmp11Reader.EndOfStream;
            while(!__tmp11_last)
            {
                ReadOnlySpan<char> __tmp11_line = __tmp11Reader.ReadLine();
                __tmp11_last = __tmp11Reader.EndOfStream;
                if (!__tmp11_last || !__tmp11_line.IsEmpty)
                {
                    __out.Write(__tmp11_line);
                    __tmp7_outputWritten = true;
                }
                if (!__tmp11_last) __out.AppendLine(true);
            }
            string __tmp12_line = "."; //78:75
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Write(__tmp12_line);
                __tmp7_outputWritten = true;
            }
            var __tmp13 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp13.Write(symbol.Name);
            var __tmp13Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp13.ToStringAndFree());
            bool __tmp13_last = __tmp13Reader.EndOfStream;
            while(!__tmp13_last)
            {
                ReadOnlySpan<char> __tmp13_line = __tmp13Reader.ReadLine();
                __tmp13_last = __tmp13Reader.EndOfStream;
                if (!__tmp13_last || !__tmp13_line.IsEmpty)
                {
                    __out.Write(__tmp13_line);
                    __tmp7_outputWritten = true;
                }
                if (!__tmp13_last) __out.AppendLine(true);
            }
            string __tmp14_line = ", MetaDslx.CodeAnalysis.Symbols.Metadata.IModelSymbol"; //78:89
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp7_outputWritten = true;
            }
            if (__tmp7_outputWritten) __out.AppendLine(true);
            if (__tmp7_outputWritten)
            {
                __out.AppendLine(false); //78:142
            }
            __out.Write("	{"); //79:1
            __out.AppendLine(false); //79:3
            __out.Write("        public static class CompletionParts"); //80:1
            __out.AppendLine(false); //80:44
            __out.Write("        {"); //81:1
            __out.AppendLine(false); //81:10
            var __loop1_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //82:20
                select new { prop = prop}
                ).ToList(); //82:14
            for (int __loop1_iteration = 0; __loop1_iteration < __loop1_results.Count; ++__loop1_iteration)
            {
                var __tmp15 = __loop1_results[__loop1_iteration];
                var prop = __tmp15.prop;
                bool __tmp17_outputWritten = false;
                string __tmp18_line = "            public static readonly CompletionPart StartComputingProperty_"; //83:1
                if (!string.IsNullOrEmpty(__tmp18_line))
                {
                    __out.Write(__tmp18_line);
                    __tmp17_outputWritten = true;
                }
                var __tmp19 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp19.Write(prop.Name);
                var __tmp19Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp19.ToStringAndFree());
                bool __tmp19_last = __tmp19Reader.EndOfStream;
                while(!__tmp19_last)
                {
                    ReadOnlySpan<char> __tmp19_line = __tmp19Reader.ReadLine();
                    __tmp19_last = __tmp19Reader.EndOfStream;
                    if (!__tmp19_last || !__tmp19_line.IsEmpty)
                    {
                        __out.Write(__tmp19_line);
                        __tmp17_outputWritten = true;
                    }
                    if (!__tmp19_last) __out.AppendLine(true);
                }
                string __tmp20_line = " = new CompletionPart(nameof(StartComputingProperty_"; //83:85
                if (!string.IsNullOrEmpty(__tmp20_line))
                {
                    __out.Write(__tmp20_line);
                    __tmp17_outputWritten = true;
                }
                var __tmp21 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp21.Write(prop.Name);
                var __tmp21Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp21.ToStringAndFree());
                bool __tmp21_last = __tmp21Reader.EndOfStream;
                while(!__tmp21_last)
                {
                    ReadOnlySpan<char> __tmp21_line = __tmp21Reader.ReadLine();
                    __tmp21_last = __tmp21Reader.EndOfStream;
                    if (!__tmp21_last || !__tmp21_line.IsEmpty)
                    {
                        __out.Write(__tmp21_line);
                        __tmp17_outputWritten = true;
                    }
                    if (!__tmp21_last) __out.AppendLine(true);
                }
                string __tmp22_line = "));"; //83:148
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Write(__tmp22_line);
                    __tmp17_outputWritten = true;
                }
                if (__tmp17_outputWritten) __out.AppendLine(true);
                if (__tmp17_outputWritten)
                {
                    __out.AppendLine(false); //83:151
                }
                bool __tmp24_outputWritten = false;
                string __tmp25_line = "            public static readonly CompletionPart FinishComputingProperty_"; //84:1
                if (!string.IsNullOrEmpty(__tmp25_line))
                {
                    __out.Write(__tmp25_line);
                    __tmp24_outputWritten = true;
                }
                var __tmp26 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp26.Write(prop.Name);
                var __tmp26Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp26.ToStringAndFree());
                bool __tmp26_last = __tmp26Reader.EndOfStream;
                while(!__tmp26_last)
                {
                    ReadOnlySpan<char> __tmp26_line = __tmp26Reader.ReadLine();
                    __tmp26_last = __tmp26Reader.EndOfStream;
                    if (!__tmp26_last || !__tmp26_line.IsEmpty)
                    {
                        __out.Write(__tmp26_line);
                        __tmp24_outputWritten = true;
                    }
                    if (!__tmp26_last) __out.AppendLine(true);
                }
                string __tmp27_line = " = new CompletionPart(nameof(FinishComputingProperty_"; //84:86
                if (!string.IsNullOrEmpty(__tmp27_line))
                {
                    __out.Write(__tmp27_line);
                    __tmp24_outputWritten = true;
                }
                var __tmp28 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp28.Write(prop.Name);
                var __tmp28Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp28.ToStringAndFree());
                bool __tmp28_last = __tmp28Reader.EndOfStream;
                while(!__tmp28_last)
                {
                    ReadOnlySpan<char> __tmp28_line = __tmp28Reader.ReadLine();
                    __tmp28_last = __tmp28Reader.EndOfStream;
                    if (!__tmp28_last || !__tmp28_line.IsEmpty)
                    {
                        __out.Write(__tmp28_line);
                        __tmp24_outputWritten = true;
                    }
                    if (!__tmp28_last) __out.AppendLine(true);
                }
                string __tmp29_line = "));"; //84:150
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Write(__tmp29_line);
                    __tmp24_outputWritten = true;
                }
                if (__tmp24_outputWritten) __out.AppendLine(true);
                if (__tmp24_outputWritten)
                {
                    __out.AppendLine(false); //84:153
                }
            }
            bool __tmp31_outputWritten = false;
            string __tmp32_line = "            public static readonly ImmutableHashSet<CompletionPart> AllWithLocation = CompletionPart.Combine(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren"; //86:1
            if (!string.IsNullOrEmpty(__tmp32_line))
            {
                __out.Write(__tmp32_line);
                __tmp31_outputWritten = true;
            }
            var __loop2_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //86:265
                select new { prop = prop}
                ).ToList(); //86:259
            for (int __loop2_iteration = 0; __loop2_iteration < __loop2_results.Count; ++__loop2_iteration)
            {
                var __tmp34 = __loop2_results[__loop2_iteration];
                var prop = __tmp34.prop;
                string __tmp35_line = ", StartComputingProperty_"; //86:289
                if (!string.IsNullOrEmpty(__tmp35_line))
                {
                    __out.Write(__tmp35_line);
                    __tmp31_outputWritten = true;
                }
                var __tmp36 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp36.Write(prop.Name);
                var __tmp36Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp36.ToStringAndFree());
                bool __tmp36_last = __tmp36Reader.EndOfStream;
                while(!__tmp36_last)
                {
                    ReadOnlySpan<char> __tmp36_line = __tmp36Reader.ReadLine();
                    __tmp36_last = __tmp36Reader.EndOfStream;
                    if (!__tmp36_last || !__tmp36_line.IsEmpty)
                    {
                        __out.Write(__tmp36_line);
                        __tmp31_outputWritten = true;
                    }
                    if (!__tmp36_last) __out.AppendLine(true);
                }
                string __tmp37_line = ", FinishComputingProperty_"; //86:325
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Write(__tmp37_line);
                    __tmp31_outputWritten = true;
                }
                var __tmp38 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp38.Write(prop.Name);
                var __tmp38Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp38.ToStringAndFree());
                bool __tmp38_last = __tmp38Reader.EndOfStream;
                while(!__tmp38_last)
                {
                    ReadOnlySpan<char> __tmp38_line = __tmp38Reader.ReadLine();
                    __tmp38_last = __tmp38Reader.EndOfStream;
                    if (!__tmp38_last || !__tmp38_line.IsEmpty)
                    {
                        __out.Write(__tmp38_line);
                        __tmp31_outputWritten = true;
                    }
                    if (!__tmp38_last) __out.AppendLine(true);
                }
            }
            string __tmp40_line = ", CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties);"; //86:372
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Write(__tmp40_line);
                __tmp31_outputWritten = true;
            }
            if (__tmp31_outputWritten) __out.AppendLine(true);
            if (__tmp31_outputWritten)
            {
                __out.AppendLine(false); //86:477
            }
            bool __tmp42_outputWritten = false;
            string __tmp43_line = "            public static readonly ImmutableHashSet<CompletionPart> All = CompletionPart.Combine(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren"; //87:1
            if (!string.IsNullOrEmpty(__tmp43_line))
            {
                __out.Write(__tmp43_line);
                __tmp42_outputWritten = true;
            }
            var __loop3_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //87:253
                select new { prop = prop}
                ).ToList(); //87:247
            for (int __loop3_iteration = 0; __loop3_iteration < __loop3_results.Count; ++__loop3_iteration)
            {
                var __tmp45 = __loop3_results[__loop3_iteration];
                var prop = __tmp45.prop;
                string __tmp46_line = ", StartComputingProperty_"; //87:277
                if (!string.IsNullOrEmpty(__tmp46_line))
                {
                    __out.Write(__tmp46_line);
                    __tmp42_outputWritten = true;
                }
                var __tmp47 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp47.Write(prop.Name);
                var __tmp47Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp47.ToStringAndFree());
                bool __tmp47_last = __tmp47Reader.EndOfStream;
                while(!__tmp47_last)
                {
                    ReadOnlySpan<char> __tmp47_line = __tmp47Reader.ReadLine();
                    __tmp47_last = __tmp47Reader.EndOfStream;
                    if (!__tmp47_last || !__tmp47_line.IsEmpty)
                    {
                        __out.Write(__tmp47_line);
                        __tmp42_outputWritten = true;
                    }
                    if (!__tmp47_last) __out.AppendLine(true);
                }
                string __tmp48_line = ", FinishComputingProperty_"; //87:313
                if (!string.IsNullOrEmpty(__tmp48_line))
                {
                    __out.Write(__tmp48_line);
                    __tmp42_outputWritten = true;
                }
                var __tmp49 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp49.Write(prop.Name);
                var __tmp49Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp49.ToStringAndFree());
                bool __tmp49_last = __tmp49Reader.EndOfStream;
                while(!__tmp49_last)
                {
                    ReadOnlySpan<char> __tmp49_line = __tmp49Reader.ReadLine();
                    __tmp49_last = __tmp49Reader.EndOfStream;
                    if (!__tmp49_last || !__tmp49_line.IsEmpty)
                    {
                        __out.Write(__tmp49_line);
                        __tmp42_outputWritten = true;
                    }
                    if (!__tmp49_last) __out.AppendLine(true);
                }
            }
            string __tmp51_line = ", CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties, CompletionGraph.ChildrenCompleted);"; //87:360
            if (!string.IsNullOrEmpty(__tmp51_line))
            {
                __out.Write(__tmp51_line);
                __tmp42_outputWritten = true;
            }
            if (__tmp42_outputWritten) __out.AppendLine(true);
            if (__tmp42_outputWritten)
            {
                __out.AppendLine(false); //87:500
            }
            bool __tmp53_outputWritten = false;
            string __tmp54_line = "            public static readonly CompletionGraph CompletionGraph = CompletionGraph.FromCompletionParts(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren"; //88:1
            if (!string.IsNullOrEmpty(__tmp54_line))
            {
                __out.Write(__tmp54_line);
                __tmp53_outputWritten = true;
            }
            var __loop4_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //88:261
                select new { prop = prop}
                ).ToList(); //88:255
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                var __tmp56 = __loop4_results[__loop4_iteration];
                var prop = __tmp56.prop;
                string __tmp57_line = ", StartComputingProperty_"; //88:285
                if (!string.IsNullOrEmpty(__tmp57_line))
                {
                    __out.Write(__tmp57_line);
                    __tmp53_outputWritten = true;
                }
                var __tmp58 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp58.Write(prop.Name);
                var __tmp58Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp58.ToStringAndFree());
                bool __tmp58_last = __tmp58Reader.EndOfStream;
                while(!__tmp58_last)
                {
                    ReadOnlySpan<char> __tmp58_line = __tmp58Reader.ReadLine();
                    __tmp58_last = __tmp58Reader.EndOfStream;
                    if (!__tmp58_last || !__tmp58_line.IsEmpty)
                    {
                        __out.Write(__tmp58_line);
                        __tmp53_outputWritten = true;
                    }
                    if (!__tmp58_last) __out.AppendLine(true);
                }
                string __tmp59_line = ", FinishComputingProperty_"; //88:321
                if (!string.IsNullOrEmpty(__tmp59_line))
                {
                    __out.Write(__tmp59_line);
                    __tmp53_outputWritten = true;
                }
                var __tmp60 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp60.Write(prop.Name);
                var __tmp60Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp60.ToStringAndFree());
                bool __tmp60_last = __tmp60Reader.EndOfStream;
                while(!__tmp60_last)
                {
                    ReadOnlySpan<char> __tmp60_line = __tmp60Reader.ReadLine();
                    __tmp60_last = __tmp60Reader.EndOfStream;
                    if (!__tmp60_last || !__tmp60_line.IsEmpty)
                    {
                        __out.Write(__tmp60_line);
                        __tmp53_outputWritten = true;
                    }
                    if (!__tmp60_last) __out.AppendLine(true);
                }
            }
            string __tmp62_line = ", CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties, CompletionGraph.ChildrenCompleted);"; //88:368
            if (!string.IsNullOrEmpty(__tmp62_line))
            {
                __out.Write(__tmp62_line);
                __tmp53_outputWritten = true;
            }
            if (__tmp53_outputWritten) __out.AppendLine(true);
            if (__tmp53_outputWritten)
            {
                __out.AppendLine(false); //88:508
            }
            __out.Write("        }"); //89:1
            __out.AppendLine(false); //89:10
            __out.AppendLine(true); //90:1
            __out.Write("        private readonly Symbol _container;"); //91:1
            __out.AppendLine(false); //91:44
            __out.Write("        private readonly object _modelObject;"); //92:1
            __out.AppendLine(false); //92:46
            __out.Write("        private readonly CompletionState _state;"); //93:1
            __out.AppendLine(false); //93:49
            __out.Write("        private ImmutableArray<Symbol> _childSymbols;"); //94:1
            __out.AppendLine(false); //94:54
            var __loop5_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //95:16
                select new { prop = prop}
                ).ToList(); //95:10
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                var __tmp63 = __loop5_results[__loop5_iteration];
                var prop = __tmp63.prop;
                bool __tmp65_outputWritten = false;
                string __tmp66_line = "        private "; //96:1
                if (!string.IsNullOrEmpty(__tmp66_line))
                {
                    __out.Write(__tmp66_line);
                    __tmp65_outputWritten = true;
                }
                var __tmp67 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp67.Write(prop.Type);
                var __tmp67Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp67.ToStringAndFree());
                bool __tmp67_last = __tmp67Reader.EndOfStream;
                while(!__tmp67_last)
                {
                    ReadOnlySpan<char> __tmp67_line = __tmp67Reader.ReadLine();
                    __tmp67_last = __tmp67Reader.EndOfStream;
                    if (!__tmp67_last || !__tmp67_line.IsEmpty)
                    {
                        __out.Write(__tmp67_line);
                        __tmp65_outputWritten = true;
                    }
                    if (!__tmp67_last) __out.AppendLine(true);
                }
                string __tmp68_line = " "; //96:28
                if (!string.IsNullOrEmpty(__tmp68_line))
                {
                    __out.Write(__tmp68_line);
                    __tmp65_outputWritten = true;
                }
                var __tmp69 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp69.Write(prop.FieldName);
                var __tmp69Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp69.ToStringAndFree());
                bool __tmp69_last = __tmp69Reader.EndOfStream;
                while(!__tmp69_last)
                {
                    ReadOnlySpan<char> __tmp69_line = __tmp69Reader.ReadLine();
                    __tmp69_last = __tmp69Reader.EndOfStream;
                    if (!__tmp69_last || !__tmp69_line.IsEmpty)
                    {
                        __out.Write(__tmp69_line);
                        __tmp65_outputWritten = true;
                    }
                    if (!__tmp69_last) __out.AppendLine(true);
                }
                string __tmp70_line = ";"; //96:45
                if (!string.IsNullOrEmpty(__tmp70_line))
                {
                    __out.Write(__tmp70_line);
                    __tmp65_outputWritten = true;
                }
                if (__tmp65_outputWritten) __out.AppendLine(true);
                if (__tmp65_outputWritten)
                {
                    __out.AppendLine(false); //96:46
                }
            }
            __out.AppendLine(true); //98:1
            bool __tmp72_outputWritten = false;
            string __tmp73_line = "        public Model"; //99:1
            if (!string.IsNullOrEmpty(__tmp73_line))
            {
                __out.Write(__tmp73_line);
                __tmp72_outputWritten = true;
            }
            var __tmp74 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp74.Write(symbol.Name);
            var __tmp74Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp74.ToStringAndFree());
            bool __tmp74_last = __tmp74Reader.EndOfStream;
            while(!__tmp74_last)
            {
                ReadOnlySpan<char> __tmp74_line = __tmp74Reader.ReadLine();
                __tmp74_last = __tmp74Reader.EndOfStream;
                if (!__tmp74_last || !__tmp74_line.IsEmpty)
                {
                    __out.Write(__tmp74_line);
                    __tmp72_outputWritten = true;
                }
                if (!__tmp74_last) __out.AppendLine(true);
            }
            string __tmp75_line = "(Symbol container, object modelObject)"; //99:34
            if (!string.IsNullOrEmpty(__tmp75_line))
            {
                __out.Write(__tmp75_line);
                __tmp72_outputWritten = true;
            }
            if (__tmp72_outputWritten) __out.AppendLine(true);
            if (__tmp72_outputWritten)
            {
                __out.AppendLine(false); //99:72
            }
            __out.Write("        {"); //100:1
            __out.AppendLine(false); //100:10
            __out.Write("            Debug.Assert(container is IModelSymbol);"); //101:1
            __out.AppendLine(false); //101:53
            __out.Write("            if (modelObject == null) throw new ArgumentNullException(nameof(modelObject));"); //102:1
            __out.AppendLine(false); //102:91
            __out.Write("            _container = container;"); //103:1
            __out.AppendLine(false); //103:36
            __out.Write("            _modelObject = modelObject;"); //104:1
            __out.AppendLine(false); //104:40
            __out.Write("            _state = CompletionParts.CompletionGraph.CreateState();"); //105:1
            __out.AppendLine(false); //105:68
            __out.Write("        }"); //106:1
            __out.AppendLine(false); //106:10
            __out.AppendLine(true); //107:1
            __out.Write("        public sealed override Language Language => ContainingModule.Language;"); //108:1
            __out.AppendLine(false); //108:79
            __out.AppendLine(true); //109:1
            __out.Write("        public SymbolFactory SymbolFactory => ((IModelSymbol)_container).SymbolFactory;"); //110:1
            __out.AppendLine(false); //110:88
            __out.AppendLine(true); //111:1
            __out.Write("        public object ModelObject => _modelObject;"); //112:1
            __out.AppendLine(false); //112:51
            __out.AppendLine(true); //113:1
            __out.Write("        public Type ModelObjectType => _modelObject != null ? Language.SymbolFacts.GetModelObjectType(_modelObject) : null;"); //114:1
            __out.AppendLine(false); //114:124
            __out.AppendLine(true); //115:1
            __out.Write("        public sealed override string Name => _modelObject != null ? Language.SymbolFacts.GetName(_modelObject) : string.Empty;"); //116:1
            __out.AppendLine(false); //116:128
            __out.AppendLine(true); //117:1
            __out.Write("        public sealed override Symbol ContainingSymbol => _container;"); //118:1
            __out.AppendLine(false); //118:70
            __out.AppendLine(true); //119:1
            __out.Write("        public sealed override ImmutableArray<Symbol> ChildSymbols "); //120:1
            __out.AppendLine(false); //120:68
            __out.Write("        {"); //121:1
            __out.AppendLine(false); //121:10
            __out.Write("            get"); //122:1
            __out.AppendLine(false); //122:16
            __out.Write("            {"); //123:1
            __out.AppendLine(false); //123:14
            __out.Write("                this.ForceComplete(CompletionGraph.FinishCreatingChildren, null, default);"); //124:1
            __out.AppendLine(false); //124:91
            __out.Write("                return _childSymbols;"); //125:1
            __out.AppendLine(false); //125:38
            __out.Write("            }"); //126:1
            __out.AppendLine(false); //126:14
            __out.Write("        }"); //127:1
            __out.AppendLine(false); //127:10
            __out.AppendLine(true); //128:1
            var __loop6_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //129:16
                select new { prop = prop}
                ).ToList(); //129:10
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp76 = __loop6_results[__loop6_iteration];
                var prop = __tmp76.prop;
                bool __tmp78_outputWritten = false;
                string __tmp79_line = "        public override "; //130:1
                if (!string.IsNullOrEmpty(__tmp79_line))
                {
                    __out.Write(__tmp79_line);
                    __tmp78_outputWritten = true;
                }
                var __tmp80 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp80.Write(prop.Type);
                var __tmp80Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp80.ToStringAndFree());
                bool __tmp80_last = __tmp80Reader.EndOfStream;
                while(!__tmp80_last)
                {
                    ReadOnlySpan<char> __tmp80_line = __tmp80Reader.ReadLine();
                    __tmp80_last = __tmp80Reader.EndOfStream;
                    if (!__tmp80_last || !__tmp80_line.IsEmpty)
                    {
                        __out.Write(__tmp80_line);
                        __tmp78_outputWritten = true;
                    }
                    if (!__tmp80_last) __out.AppendLine(true);
                }
                string __tmp81_line = " "; //130:36
                if (!string.IsNullOrEmpty(__tmp81_line))
                {
                    __out.Write(__tmp81_line);
                    __tmp78_outputWritten = true;
                }
                var __tmp82 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp82.Write(prop.Name);
                var __tmp82Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp82.ToStringAndFree());
                bool __tmp82_last = __tmp82Reader.EndOfStream;
                while(!__tmp82_last)
                {
                    ReadOnlySpan<char> __tmp82_line = __tmp82Reader.ReadLine();
                    __tmp82_last = __tmp82Reader.EndOfStream;
                    if (!__tmp82_last || !__tmp82_line.IsEmpty)
                    {
                        __out.Write(__tmp82_line);
                        __tmp78_outputWritten = true;
                    }
                    if (!__tmp82_last || __tmp78_outputWritten) __out.AppendLine(true);
                }
                if (__tmp78_outputWritten)
                {
                    __out.AppendLine(false); //130:48
                }
                __out.Write("        {"); //131:1
                __out.AppendLine(false); //131:10
                __out.Write("            get"); //132:1
                __out.AppendLine(false); //132:16
                __out.Write("            {"); //133:1
                __out.AppendLine(false); //133:14
                bool __tmp84_outputWritten = false;
                string __tmp85_line = "                this.ForceComplete(CompletionParts.FinishComputingProperty_"; //134:1
                if (!string.IsNullOrEmpty(__tmp85_line))
                {
                    __out.Write(__tmp85_line);
                    __tmp84_outputWritten = true;
                }
                var __tmp86 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp86.Write(prop.Name);
                var __tmp86Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp86.ToStringAndFree());
                bool __tmp86_last = __tmp86Reader.EndOfStream;
                while(!__tmp86_last)
                {
                    ReadOnlySpan<char> __tmp86_line = __tmp86Reader.ReadLine();
                    __tmp86_last = __tmp86Reader.EndOfStream;
                    if (!__tmp86_last || !__tmp86_line.IsEmpty)
                    {
                        __out.Write(__tmp86_line);
                        __tmp84_outputWritten = true;
                    }
                    if (!__tmp86_last) __out.AppendLine(true);
                }
                string __tmp87_line = ", null, default);"; //134:87
                if (!string.IsNullOrEmpty(__tmp87_line))
                {
                    __out.Write(__tmp87_line);
                    __tmp84_outputWritten = true;
                }
                if (__tmp84_outputWritten) __out.AppendLine(true);
                if (__tmp84_outputWritten)
                {
                    __out.AppendLine(false); //134:104
                }
                bool __tmp89_outputWritten = false;
                string __tmp90_line = "                return "; //135:1
                if (!string.IsNullOrEmpty(__tmp90_line))
                {
                    __out.Write(__tmp90_line);
                    __tmp89_outputWritten = true;
                }
                var __tmp91 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp91.Write(prop.FieldName);
                var __tmp91Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp91.ToStringAndFree());
                bool __tmp91_last = __tmp91Reader.EndOfStream;
                while(!__tmp91_last)
                {
                    ReadOnlySpan<char> __tmp91_line = __tmp91Reader.ReadLine();
                    __tmp91_last = __tmp91Reader.EndOfStream;
                    if (!__tmp91_last || !__tmp91_line.IsEmpty)
                    {
                        __out.Write(__tmp91_line);
                        __tmp89_outputWritten = true;
                    }
                    if (!__tmp91_last) __out.AppendLine(true);
                }
                string __tmp92_line = ";"; //135:40
                if (!string.IsNullOrEmpty(__tmp92_line))
                {
                    __out.Write(__tmp92_line);
                    __tmp89_outputWritten = true;
                }
                if (__tmp89_outputWritten) __out.AppendLine(true);
                if (__tmp89_outputWritten)
                {
                    __out.AppendLine(false); //135:41
                }
                __out.Write("            }"); //136:1
                __out.AppendLine(false); //136:14
                __out.Write("        }"); //137:1
                __out.AppendLine(false); //137:10
            }
            __out.AppendLine(true); //139:1
            __out.Write("        #region Completion"); //140:1
            __out.AppendLine(false); //140:27
            __out.AppendLine(true); //141:1
            __out.Write("        public sealed override bool RequiresCompletion => true;"); //142:1
            __out.AppendLine(false); //142:64
            __out.AppendLine(true); //143:1
            __out.Write("        public sealed override bool HasComplete(CompletionPart part)"); //144:1
            __out.AppendLine(false); //144:69
            __out.Write("        {"); //145:1
            __out.AppendLine(false); //145:10
            __out.Write("            return _state.HasComplete(part);"); //146:1
            __out.AppendLine(false); //146:45
            __out.Write("        }"); //147:1
            __out.AppendLine(false); //147:10
            __out.AppendLine(true); //148:1
            __out.Write("        public override void ForceComplete(CompletionPart completionPart, SourceLocation locationOpt, CancellationToken cancellationToken)"); //149:1
            __out.AppendLine(false); //149:139
            __out.Write("        {"); //150:1
            __out.AppendLine(false); //150:10
            __out.Write("            if (completionPart != null && _state.HasComplete(completionPart)) return;"); //151:1
            __out.AppendLine(false); //151:86
            __out.Write("            if (completionPart != null && !CompletionParts.All.Contains(completionPart)) throw new ArgumentException(nameof(completionPart));"); //152:1
            __out.AppendLine(false); //152:142
            __out.Write("            while (true)"); //153:1
            __out.AppendLine(false); //153:25
            __out.Write("            {"); //154:1
            __out.AppendLine(false); //154:14
            __out.Write("                cancellationToken.ThrowIfCancellationRequested();"); //155:1
            __out.AppendLine(false); //155:66
            __out.Write("                var incompletePart = _state.NextIncompletePart;"); //156:1
            __out.AppendLine(false); //156:64
            __out.Write("                if (incompletePart == CompletionGraph.StartInitializing || incompletePart == CompletionGraph.FinishInitializing)"); //157:1
            __out.AppendLine(false); //157:129
            __out.Write("                {"); //158:1
            __out.AppendLine(false); //158:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartInitializing))"); //159:1
            __out.AppendLine(false); //159:84
            __out.Write("                    {"); //160:1
            __out.AppendLine(false); //160:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //161:1
            __out.AppendLine(false); //161:71
            __out.Write("                        CompleteInitializingSymbol(locationOpt, diagnostics, cancellationToken);"); //162:1
            __out.AppendLine(false); //162:97
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //163:1
            __out.AppendLine(false); //163:59
            __out.Write("                        diagnostics.Free();"); //164:1
            __out.AppendLine(false); //164:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishInitializing);"); //165:1
            __out.AppendLine(false); //165:85
            __out.Write("                    }"); //166:1
            __out.AppendLine(false); //166:22
            __out.Write("                }"); //167:1
            __out.AppendLine(false); //167:18
            __out.Write("                else if (incompletePart == CompletionGraph.StartCreatingChildren || incompletePart == CompletionGraph.FinishCreatingChildren)"); //168:1
            __out.AppendLine(false); //168:142
            __out.Write("                {"); //169:1
            __out.AppendLine(false); //169:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartCreatingChildren))"); //170:1
            __out.AppendLine(false); //170:88
            __out.Write("                    {"); //171:1
            __out.AppendLine(false); //171:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //172:1
            __out.AppendLine(false); //172:71
            __out.Write("                        _childSymbols = CompleteCreatingChildSymbols(locationOpt, diagnostics, cancellationToken);"); //173:1
            __out.AppendLine(false); //173:115
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //174:1
            __out.AppendLine(false); //174:59
            __out.Write("                        diagnostics.Free();"); //175:1
            __out.AppendLine(false); //175:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishCreatingChildren);"); //176:1
            __out.AppendLine(false); //176:89
            __out.Write("                    }"); //177:1
            __out.AppendLine(false); //177:22
            __out.Write("                }"); //178:1
            __out.AppendLine(false); //178:18
            var __loop7_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //179:24
                select new { prop = prop}
                ).ToList(); //179:18
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                var __tmp93 = __loop7_results[__loop7_iteration];
                var prop = __tmp93.prop;
                bool __tmp95_outputWritten = false;
                string __tmp96_line = "                else if (incompletePart == CompletionParts.StartComputingProperty_"; //180:1
                if (!string.IsNullOrEmpty(__tmp96_line))
                {
                    __out.Write(__tmp96_line);
                    __tmp95_outputWritten = true;
                }
                var __tmp97 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp97.Write(prop.Name);
                var __tmp97Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp97.ToStringAndFree());
                bool __tmp97_last = __tmp97Reader.EndOfStream;
                while(!__tmp97_last)
                {
                    ReadOnlySpan<char> __tmp97_line = __tmp97Reader.ReadLine();
                    __tmp97_last = __tmp97Reader.EndOfStream;
                    if (!__tmp97_last || !__tmp97_line.IsEmpty)
                    {
                        __out.Write(__tmp97_line);
                        __tmp95_outputWritten = true;
                    }
                    if (!__tmp97_last) __out.AppendLine(true);
                }
                string __tmp98_line = " || incompletePart == CompletionParts.FinishComputingProperty_"; //180:94
                if (!string.IsNullOrEmpty(__tmp98_line))
                {
                    __out.Write(__tmp98_line);
                    __tmp95_outputWritten = true;
                }
                var __tmp99 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp99.Write(prop.Name);
                var __tmp99Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp99.ToStringAndFree());
                bool __tmp99_last = __tmp99Reader.EndOfStream;
                while(!__tmp99_last)
                {
                    ReadOnlySpan<char> __tmp99_line = __tmp99Reader.ReadLine();
                    __tmp99_last = __tmp99Reader.EndOfStream;
                    if (!__tmp99_last || !__tmp99_line.IsEmpty)
                    {
                        __out.Write(__tmp99_line);
                        __tmp95_outputWritten = true;
                    }
                    if (!__tmp99_last) __out.AppendLine(true);
                }
                string __tmp100_line = ")"; //180:167
                if (!string.IsNullOrEmpty(__tmp100_line))
                {
                    __out.Write(__tmp100_line);
                    __tmp95_outputWritten = true;
                }
                if (__tmp95_outputWritten) __out.AppendLine(true);
                if (__tmp95_outputWritten)
                {
                    __out.AppendLine(false); //180:168
                }
                __out.Write("                {"); //181:1
                __out.AppendLine(false); //181:18
                bool __tmp102_outputWritten = false;
                string __tmp103_line = "                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_"; //182:1
                if (!string.IsNullOrEmpty(__tmp103_line))
                {
                    __out.Write(__tmp103_line);
                    __tmp102_outputWritten = true;
                }
                var __tmp104 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp104.Write(prop.Name);
                var __tmp104Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp104.ToStringAndFree());
                bool __tmp104_last = __tmp104Reader.EndOfStream;
                while(!__tmp104_last)
                {
                    ReadOnlySpan<char> __tmp104_line = __tmp104Reader.ReadLine();
                    __tmp104_last = __tmp104Reader.EndOfStream;
                    if (!__tmp104_last || !__tmp104_line.IsEmpty)
                    {
                        __out.Write(__tmp104_line);
                        __tmp102_outputWritten = true;
                    }
                    if (!__tmp104_last) __out.AppendLine(true);
                }
                string __tmp105_line = "))"; //182:99
                if (!string.IsNullOrEmpty(__tmp105_line))
                {
                    __out.Write(__tmp105_line);
                    __tmp102_outputWritten = true;
                }
                if (__tmp102_outputWritten) __out.AppendLine(true);
                if (__tmp102_outputWritten)
                {
                    __out.AppendLine(false); //182:101
                }
                __out.Write("                    {"); //183:1
                __out.AppendLine(false); //183:22
                __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //184:1
                __out.AppendLine(false); //184:71
                bool __tmp107_outputWritten = false;
                string __tmp106Prefix = "                        "; //185:1
                var __tmp108 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp108.Write(prop.FieldName);
                var __tmp108Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp108.ToStringAndFree());
                bool __tmp108_last = __tmp108Reader.EndOfStream;
                while(!__tmp108_last)
                {
                    ReadOnlySpan<char> __tmp108_line = __tmp108Reader.ReadLine();
                    __tmp108_last = __tmp108Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp106Prefix))
                    {
                        __out.Write(__tmp106Prefix);
                        __tmp107_outputWritten = true;
                    }
                    if (!__tmp108_last || !__tmp108_line.IsEmpty)
                    {
                        __out.Write(__tmp108_line);
                        __tmp107_outputWritten = true;
                    }
                    if (!__tmp108_last) __out.AppendLine(true);
                }
                string __tmp109_line = " = CompleteSymbolProperty_"; //185:41
                if (!string.IsNullOrEmpty(__tmp109_line))
                {
                    __out.Write(__tmp109_line);
                    __tmp107_outputWritten = true;
                }
                var __tmp110 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp110.Write(prop.Name);
                var __tmp110Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp110.ToStringAndFree());
                bool __tmp110_last = __tmp110Reader.EndOfStream;
                while(!__tmp110_last)
                {
                    ReadOnlySpan<char> __tmp110_line = __tmp110Reader.ReadLine();
                    __tmp110_last = __tmp110Reader.EndOfStream;
                    if (!__tmp110_last || !__tmp110_line.IsEmpty)
                    {
                        __out.Write(__tmp110_line);
                        __tmp107_outputWritten = true;
                    }
                    if (!__tmp110_last) __out.AppendLine(true);
                }
                string __tmp111_line = "(locationOpt, diagnostics, cancellationToken);"; //185:78
                if (!string.IsNullOrEmpty(__tmp111_line))
                {
                    __out.Write(__tmp111_line);
                    __tmp107_outputWritten = true;
                }
                if (__tmp107_outputWritten) __out.AppendLine(true);
                if (__tmp107_outputWritten)
                {
                    __out.AppendLine(false); //185:124
                }
                __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //186:1
                __out.AppendLine(false); //186:59
                __out.Write("                        diagnostics.Free();"); //187:1
                __out.AppendLine(false); //187:44
                bool __tmp113_outputWritten = false;
                string __tmp114_line = "                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_"; //188:1
                if (!string.IsNullOrEmpty(__tmp114_line))
                {
                    __out.Write(__tmp114_line);
                    __tmp113_outputWritten = true;
                }
                var __tmp115 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp115.Write(prop.Name);
                var __tmp115Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp115.ToStringAndFree());
                bool __tmp115_last = __tmp115Reader.EndOfStream;
                while(!__tmp115_last)
                {
                    ReadOnlySpan<char> __tmp115_line = __tmp115Reader.ReadLine();
                    __tmp115_last = __tmp115Reader.EndOfStream;
                    if (!__tmp115_last || !__tmp115_line.IsEmpty)
                    {
                        __out.Write(__tmp115_line);
                        __tmp113_outputWritten = true;
                    }
                    if (!__tmp115_last) __out.AppendLine(true);
                }
                string __tmp116_line = ");"; //188:100
                if (!string.IsNullOrEmpty(__tmp116_line))
                {
                    __out.Write(__tmp116_line);
                    __tmp113_outputWritten = true;
                }
                if (__tmp113_outputWritten) __out.AppendLine(true);
                if (__tmp113_outputWritten)
                {
                    __out.AppendLine(false); //188:102
                }
                __out.Write("                    }"); //189:1
                __out.AppendLine(false); //189:22
                __out.Write("                }"); //190:1
                __out.AppendLine(false); //190:18
            }
            __out.Write("                else if (incompletePart == CompletionGraph.StartComputingNonSymbolProperties || incompletePart == CompletionGraph.FinishComputingNonSymbolProperties)"); //192:1
            __out.AppendLine(false); //192:166
            __out.Write("                {"); //193:1
            __out.AppendLine(false); //193:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartComputingNonSymbolProperties))"); //194:1
            __out.AppendLine(false); //194:100
            __out.Write("                    {"); //195:1
            __out.AppendLine(false); //195:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //196:1
            __out.AppendLine(false); //196:71
            __out.Write("                        CompleteNonSymbolProperties(locationOpt, diagnostics, cancellationToken);"); //197:1
            __out.AppendLine(false); //197:98
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //198:1
            __out.AppendLine(false); //198:59
            __out.Write("                        diagnostics.Free();"); //199:1
            __out.AppendLine(false); //199:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishComputingNonSymbolProperties);"); //200:1
            __out.AppendLine(false); //200:101
            __out.Write("                    }"); //201:1
            __out.AppendLine(false); //201:22
            __out.Write("                }"); //202:1
            __out.AppendLine(false); //202:18
            __out.Write("                else if (incompletePart == CompletionGraph.ChildrenCompleted)"); //203:1
            __out.AppendLine(false); //203:78
            __out.Write("                {"); //204:1
            __out.AppendLine(false); //204:18
            __out.Write("                    var diagnostics = DiagnosticBag.GetInstance();"); //205:1
            __out.AppendLine(false); //205:67
            __out.Write("                    CompleteImports(locationOpt, diagnostics, cancellationToken);"); //206:1
            __out.AppendLine(false); //206:82
            __out.Write("                    AddSymbolDiagnostics(diagnostics);"); //207:1
            __out.AppendLine(false); //207:55
            __out.Write("                    diagnostics.Free();"); //208:1
            __out.AppendLine(false); //208:40
            __out.Write("                    bool allCompleted = true;"); //210:1
            __out.AppendLine(false); //210:46
            __out.Write("                    if (locationOpt == null)"); //211:1
            __out.AppendLine(false); //211:45
            __out.Write("                    {"); //212:1
            __out.AppendLine(false); //212:22
            __out.Write("                        foreach (var child in _childSymbols)"); //213:1
            __out.AppendLine(false); //213:61
            __out.Write("                        {"); //214:1
            __out.AppendLine(false); //214:26
            __out.Write("                            cancellationToken.ThrowIfCancellationRequested();"); //215:1
            __out.AppendLine(false); //215:78
            __out.Write("                            child.ForceComplete(null, locationOpt, cancellationToken);"); //216:1
            __out.AppendLine(false); //216:87
            __out.Write("                        }"); //217:1
            __out.AppendLine(false); //217:26
            __out.Write("                    }"); //218:1
            __out.AppendLine(false); //218:22
            __out.Write("                    else"); //219:1
            __out.AppendLine(false); //219:25
            __out.Write("                    {"); //220:1
            __out.AppendLine(false); //220:22
            __out.Write("                        foreach (var child in _childSymbols)"); //221:1
            __out.AppendLine(false); //221:61
            __out.Write("                        {"); //222:1
            __out.AppendLine(false); //222:26
            __out.Write("                            ForceCompleteChildByLocation(locationOpt, child, cancellationToken);"); //223:1
            __out.AppendLine(false); //223:97
            __out.Write("                            allCompleted = allCompleted && child.HasComplete(CompletionGraph.All);"); //224:1
            __out.AppendLine(false); //224:99
            __out.Write("                        }"); //225:1
            __out.AppendLine(false); //225:26
            __out.Write("                    }"); //226:1
            __out.AppendLine(false); //226:22
            __out.Write("                    if (!allCompleted)"); //228:1
            __out.AppendLine(false); //228:39
            __out.Write("                    {"); //229:1
            __out.AppendLine(false); //229:22
            __out.Write("                        // We did not complete all members, so just kick out now."); //230:1
            __out.AppendLine(false); //230:82
            __out.Write("                        var allParts = CompletionParts.AllWithLocation;"); //231:1
            __out.AppendLine(false); //231:72
            __out.Write("                        _state.SpinWaitComplete(allParts, cancellationToken);"); //232:1
            __out.AppendLine(false); //232:78
            __out.Write("                        return;"); //233:1
            __out.AppendLine(false); //233:32
            __out.Write("                    }"); //234:1
            __out.AppendLine(false); //234:22
            __out.Write("                    // We've completed all members, proceed to the next iteration."); //236:1
            __out.AppendLine(false); //236:83
            __out.Write("                    _state.NotePartComplete(CompletionGraph.ChildrenCompleted);"); //237:1
            __out.AppendLine(false); //237:80
            __out.Write("                }"); //238:1
            __out.AppendLine(false); //238:18
            __out.Write("                else if (incompletePart == null)"); //239:1
            __out.AppendLine(false); //239:49
            __out.Write("                {"); //240:1
            __out.AppendLine(false); //240:18
            __out.Write("                    return;"); //241:1
            __out.AppendLine(false); //241:28
            __out.Write("                }"); //242:1
            __out.AppendLine(false); //242:18
            __out.Write("                else"); //243:1
            __out.AppendLine(false); //243:21
            __out.Write("                {"); //244:1
            __out.AppendLine(false); //244:18
            __out.Write("                    // This assert will trigger if we forgot to handle any of the completion parts"); //245:1
            __out.AppendLine(false); //245:99
            __out.Write("                    Debug.Assert(!CompletionParts.All.Contains(incompletePart));"); //246:1
            __out.AppendLine(false); //246:81
            __out.Write("                    // any other values are completion parts intended for other kinds of symbols"); //247:1
            __out.AppendLine(false); //247:97
            __out.Write("                    _state.NotePartComplete(incompletePart);"); //248:1
            __out.AppendLine(false); //248:61
            __out.Write("                }"); //249:1
            __out.AppendLine(false); //249:18
            __out.Write("                if (completionPart != null && _state.HasComplete(completionPart)) return;"); //250:1
            __out.AppendLine(false); //250:90
            __out.Write("                _state.SpinWaitComplete(incompletePart, cancellationToken);"); //251:1
            __out.AppendLine(false); //251:76
            __out.Write("            }"); //252:1
            __out.AppendLine(false); //252:14
            __out.AppendLine(true); //253:1
            __out.Write("            throw ExceptionUtilities.Unreachable;"); //254:1
            __out.AppendLine(false); //254:50
            __out.Write("        }"); //255:1
            __out.AppendLine(false); //255:10
            __out.AppendLine(true); //256:1
            __out.Write("        protected abstract void CompleteInitializingSymbol(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //257:1
            __out.AppendLine(false); //257:152
            __out.Write("        protected abstract ImmutableArray<Symbol> CompleteCreatingChildSymbols(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //258:1
            __out.AppendLine(false); //258:172
            __out.Write("        protected abstract void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //259:1
            __out.AppendLine(false); //259:141
            var __loop8_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //260:16
                select new { prop = prop}
                ).ToList(); //260:10
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp117 = __loop8_results[__loop8_iteration];
                var prop = __tmp117.prop;
                bool __tmp119_outputWritten = false;
                string __tmp120_line = "        protected abstract "; //261:1
                if (!string.IsNullOrEmpty(__tmp120_line))
                {
                    __out.Write(__tmp120_line);
                    __tmp119_outputWritten = true;
                }
                var __tmp121 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp121.Write(prop.Type);
                var __tmp121Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp121.ToStringAndFree());
                bool __tmp121_last = __tmp121Reader.EndOfStream;
                while(!__tmp121_last)
                {
                    ReadOnlySpan<char> __tmp121_line = __tmp121Reader.ReadLine();
                    __tmp121_last = __tmp121Reader.EndOfStream;
                    if (!__tmp121_last || !__tmp121_line.IsEmpty)
                    {
                        __out.Write(__tmp121_line);
                        __tmp119_outputWritten = true;
                    }
                    if (!__tmp121_last) __out.AppendLine(true);
                }
                string __tmp122_line = " CompleteSymbolProperty_"; //261:39
                if (!string.IsNullOrEmpty(__tmp122_line))
                {
                    __out.Write(__tmp122_line);
                    __tmp119_outputWritten = true;
                }
                var __tmp123 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp123.Write(prop.Name);
                var __tmp123Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp123.ToStringAndFree());
                bool __tmp123_last = __tmp123Reader.EndOfStream;
                while(!__tmp123_last)
                {
                    ReadOnlySpan<char> __tmp123_line = __tmp123Reader.ReadLine();
                    __tmp123_last = __tmp123Reader.EndOfStream;
                    if (!__tmp123_last || !__tmp123_line.IsEmpty)
                    {
                        __out.Write(__tmp123_line);
                        __tmp119_outputWritten = true;
                    }
                    if (!__tmp123_last) __out.AppendLine(true);
                }
                string __tmp124_line = "(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"; //261:74
                if (!string.IsNullOrEmpty(__tmp124_line))
                {
                    __out.Write(__tmp124_line);
                    __tmp119_outputWritten = true;
                }
                if (__tmp119_outputWritten) __out.AppendLine(true);
                if (__tmp119_outputWritten)
                {
                    __out.AppendLine(false); //261:167
                }
            }
            __out.Write("        protected abstract void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //263:1
            __out.AppendLine(false); //263:153
            __out.Write("        #endregion"); //264:1
            __out.AppendLine(false); //264:19
            __out.AppendLine(true); //265:1
            __out.Write("    }"); //266:1
            __out.AppendLine(false); //266:6
            __out.Write("}"); //267:1
            __out.AppendLine(false); //267:2
            return __out.ToStringAndFree();
        }

        public string GenerateMetaSymbol(SymbolGenerationInfo symbol) //270:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //271:1
            __out.AppendLine(false); //271:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //272:1
            __out.AppendLine(false); //272:29
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //273:1
            __out.AppendLine(false); //273:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //274:1
            __out.AppendLine(false); //274:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //275:1
            __out.AppendLine(false); //275:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //276:1
            __out.AppendLine(false); //276:44
            __out.Write("using System;"); //277:1
            __out.AppendLine(false); //277:14
            __out.Write("using System.Collections.Generic;"); //278:1
            __out.AppendLine(false); //278:34
            __out.Write("using System.Collections.Immutable;"); //279:1
            __out.AppendLine(false); //279:36
            __out.Write("using System.Diagnostics;"); //280:1
            __out.AppendLine(false); //280:26
            __out.Write("using System.Text;"); //281:1
            __out.AppendLine(false); //281:19
            __out.Write("using System.Threading;"); //282:1
            __out.AppendLine(false); //282:24
            __out.AppendLine(true); //283:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //284:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Write(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp4.Write(symbol.NamespaceName);
            var __tmp4Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp4.ToStringAndFree());
            bool __tmp4_last = __tmp4Reader.EndOfStream;
            while(!__tmp4_last)
            {
                ReadOnlySpan<char> __tmp4_line = __tmp4Reader.ReadLine();
                __tmp4_last = __tmp4Reader.EndOfStream;
                if (!__tmp4_last || !__tmp4_line.IsEmpty)
                {
                    __out.Write(__tmp4_line);
                    __tmp2_outputWritten = true;
                }
                if (!__tmp4_last) __out.AppendLine(true);
            }
            string __tmp5_line = ".Metadata"; //284:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //284:42
            }
            __out.Write("{"); //285:1
            __out.AppendLine(false); //285:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Meta"; //286:1
            if (!string.IsNullOrEmpty(__tmp8_line))
            {
                __out.Write(__tmp8_line);
                __tmp7_outputWritten = true;
            }
            var __tmp9 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp9.Write(symbol.Name);
            var __tmp9Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp9.ToStringAndFree());
            bool __tmp9_last = __tmp9Reader.EndOfStream;
            while(!__tmp9_last)
            {
                ReadOnlySpan<char> __tmp9_line = __tmp9Reader.ReadLine();
                __tmp9_last = __tmp9Reader.EndOfStream;
                if (!__tmp9_last || !__tmp9_line.IsEmpty)
                {
                    __out.Write(__tmp9_line);
                    __tmp7_outputWritten = true;
                }
                if (!__tmp9_last) __out.AppendLine(true);
            }
            string __tmp10_line = " : "; //286:40
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Write(__tmp10_line);
                __tmp7_outputWritten = true;
            }
            var __tmp11 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp11.Write(symbol.NamespaceName);
            var __tmp11Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp11.ToStringAndFree());
            bool __tmp11_last = __tmp11Reader.EndOfStream;
            while(!__tmp11_last)
            {
                ReadOnlySpan<char> __tmp11_line = __tmp11Reader.ReadLine();
                __tmp11_last = __tmp11Reader.EndOfStream;
                if (!__tmp11_last || !__tmp11_line.IsEmpty)
                {
                    __out.Write(__tmp11_line);
                    __tmp7_outputWritten = true;
                }
                if (!__tmp11_last) __out.AppendLine(true);
            }
            string __tmp12_line = ".Model.Model"; //286:65
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Write(__tmp12_line);
                __tmp7_outputWritten = true;
            }
            var __tmp13 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp13.Write(symbol.Name);
            var __tmp13Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp13.ToStringAndFree());
            bool __tmp13_last = __tmp13Reader.EndOfStream;
            while(!__tmp13_last)
            {
                ReadOnlySpan<char> __tmp13_line = __tmp13Reader.ReadLine();
                __tmp13_last = __tmp13Reader.EndOfStream;
                if (!__tmp13_last || !__tmp13_line.IsEmpty)
                {
                    __out.Write(__tmp13_line);
                    __tmp7_outputWritten = true;
                }
                if (!__tmp13_last || __tmp7_outputWritten) __out.AppendLine(true);
            }
            if (__tmp7_outputWritten)
            {
                __out.AppendLine(false); //286:90
            }
            __out.Write("	{"); //287:1
            __out.AppendLine(false); //287:3
            bool __tmp15_outputWritten = false;
            string __tmp16_line = "        public Meta"; //288:1
            if (!string.IsNullOrEmpty(__tmp16_line))
            {
                __out.Write(__tmp16_line);
                __tmp15_outputWritten = true;
            }
            var __tmp17 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp17.Write(symbol.Name);
            var __tmp17Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp17.ToStringAndFree());
            bool __tmp17_last = __tmp17Reader.EndOfStream;
            while(!__tmp17_last)
            {
                ReadOnlySpan<char> __tmp17_line = __tmp17Reader.ReadLine();
                __tmp17_last = __tmp17Reader.EndOfStream;
                if (!__tmp17_last || !__tmp17_line.IsEmpty)
                {
                    __out.Write(__tmp17_line);
                    __tmp15_outputWritten = true;
                }
                if (!__tmp17_last) __out.AppendLine(true);
            }
            string __tmp18_line = "(Symbol container, object modelObject)"; //288:33
            if (!string.IsNullOrEmpty(__tmp18_line))
            {
                __out.Write(__tmp18_line);
                __tmp15_outputWritten = true;
            }
            if (__tmp15_outputWritten) __out.AppendLine(true);
            if (__tmp15_outputWritten)
            {
                __out.AppendLine(false); //288:71
            }
            __out.Write("            : base(container, modelObject)"); //289:1
            __out.AppendLine(false); //289:43
            __out.Write("        {"); //290:1
            __out.AppendLine(false); //290:10
            __out.Write("        }"); //291:1
            __out.AppendLine(false); //291:10
            __out.AppendLine(true); //292:1
            __out.Write("        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;"); //293:1
            __out.AppendLine(false); //293:95
            __out.AppendLine(true); //294:1
            __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;"); //295:1
            __out.AppendLine(false); //295:124
            __out.AppendLine(true); //296:1
            __out.Write("        protected override void CompleteInitializingSymbol(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //297:1
            __out.AppendLine(false); //297:151
            __out.Write("        {"); //298:1
            __out.AppendLine(false); //298:10
            __out.Write("            ModelSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //299:1
            __out.AppendLine(false); //299:125
            __out.Write("        }"); //300:1
            __out.AppendLine(false); //300:10
            __out.AppendLine(true); //301:1
            __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //302:1
            __out.AppendLine(false); //302:171
            __out.Write("        {"); //303:1
            __out.AppendLine(false); //303:10
            __out.Write("            return ModelSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //304:1
            __out.AppendLine(false); //304:123
            __out.Write("        }"); //305:1
            __out.AppendLine(false); //305:10
            __out.AppendLine(true); //306:1
            __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //307:1
            __out.AppendLine(false); //307:140
            __out.Write("        {"); //308:1
            __out.AppendLine(false); //308:10
            __out.Write("        }"); //309:1
            __out.AppendLine(false); //309:10
            __out.AppendLine(true); //310:1
            var __loop9_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //311:16
                select new { prop = prop}
                ).ToList(); //311:10
            for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
            {
                var __tmp19 = __loop9_results[__loop9_iteration];
                var prop = __tmp19.prop;
                bool __tmp21_outputWritten = false;
                string __tmp22_line = "        protected override "; //312:1
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Write(__tmp22_line);
                    __tmp21_outputWritten = true;
                }
                var __tmp23 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp23.Write(prop.Type);
                var __tmp23Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp23.ToStringAndFree());
                bool __tmp23_last = __tmp23Reader.EndOfStream;
                while(!__tmp23_last)
                {
                    ReadOnlySpan<char> __tmp23_line = __tmp23Reader.ReadLine();
                    __tmp23_last = __tmp23Reader.EndOfStream;
                    if (!__tmp23_last || !__tmp23_line.IsEmpty)
                    {
                        __out.Write(__tmp23_line);
                        __tmp21_outputWritten = true;
                    }
                    if (!__tmp23_last) __out.AppendLine(true);
                }
                string __tmp24_line = " CompleteSymbolProperty_"; //312:39
                if (!string.IsNullOrEmpty(__tmp24_line))
                {
                    __out.Write(__tmp24_line);
                    __tmp21_outputWritten = true;
                }
                var __tmp25 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp25.Write(prop.Name);
                var __tmp25Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp25.ToStringAndFree());
                bool __tmp25_last = __tmp25Reader.EndOfStream;
                while(!__tmp25_last)
                {
                    ReadOnlySpan<char> __tmp25_line = __tmp25Reader.ReadLine();
                    __tmp25_last = __tmp25Reader.EndOfStream;
                    if (!__tmp25_last || !__tmp25_line.IsEmpty)
                    {
                        __out.Write(__tmp25_line);
                        __tmp21_outputWritten = true;
                    }
                    if (!__tmp25_last) __out.AppendLine(true);
                }
                string __tmp26_line = "(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"; //312:74
                if (!string.IsNullOrEmpty(__tmp26_line))
                {
                    __out.Write(__tmp26_line);
                    __tmp21_outputWritten = true;
                }
                if (__tmp21_outputWritten) __out.AppendLine(true);
                if (__tmp21_outputWritten)
                {
                    __out.AppendLine(false); //312:166
                }
                __out.Write("        {"); //313:1
                __out.AppendLine(false); //313:10
                if (prop.IsCollection) //314:14
                {
                    bool __tmp28_outputWritten = false;
                    string __tmp29_line = "            return ModelSymbolImplementation.AssignSymbolPropertyValues<"; //315:1
                    if (!string.IsNullOrEmpty(__tmp29_line))
                    {
                        __out.Write(__tmp29_line);
                        __tmp28_outputWritten = true;
                    }
                    var __tmp30 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp30.Write(prop.ItemType);
                    var __tmp30Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp30.ToStringAndFree());
                    bool __tmp30_last = __tmp30Reader.EndOfStream;
                    while(!__tmp30_last)
                    {
                        ReadOnlySpan<char> __tmp30_line = __tmp30Reader.ReadLine();
                        __tmp30_last = __tmp30Reader.EndOfStream;
                        if (!__tmp30_last || !__tmp30_line.IsEmpty)
                        {
                            __out.Write(__tmp30_line);
                            __tmp28_outputWritten = true;
                        }
                        if (!__tmp30_last) __out.AppendLine(true);
                    }
                    string __tmp31_line = ">(this, nameof("; //315:88
                    if (!string.IsNullOrEmpty(__tmp31_line))
                    {
                        __out.Write(__tmp31_line);
                        __tmp28_outputWritten = true;
                    }
                    var __tmp32 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp32.Write(prop.Name);
                    var __tmp32Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp32.ToStringAndFree());
                    bool __tmp32_last = __tmp32Reader.EndOfStream;
                    while(!__tmp32_last)
                    {
                        ReadOnlySpan<char> __tmp32_line = __tmp32Reader.ReadLine();
                        __tmp32_last = __tmp32Reader.EndOfStream;
                        if (!__tmp32_last || !__tmp32_line.IsEmpty)
                        {
                            __out.Write(__tmp32_line);
                            __tmp28_outputWritten = true;
                        }
                        if (!__tmp32_last) __out.AppendLine(true);
                    }
                    string __tmp33_line = "), diagnostics, cancellationToken);"; //315:114
                    if (!string.IsNullOrEmpty(__tmp33_line))
                    {
                        __out.Write(__tmp33_line);
                        __tmp28_outputWritten = true;
                    }
                    if (__tmp28_outputWritten) __out.AppendLine(true);
                    if (__tmp28_outputWritten)
                    {
                        __out.AppendLine(false); //315:149
                    }
                }
                else //316:14
                {
                    bool __tmp35_outputWritten = false;
                    string __tmp36_line = "            return ModelSymbolImplementation.AssignSymbolPropertyValue<"; //317:1
                    if (!string.IsNullOrEmpty(__tmp36_line))
                    {
                        __out.Write(__tmp36_line);
                        __tmp35_outputWritten = true;
                    }
                    var __tmp37 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp37.Write(prop.Type);
                    var __tmp37Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp37.ToStringAndFree());
                    bool __tmp37_last = __tmp37Reader.EndOfStream;
                    while(!__tmp37_last)
                    {
                        ReadOnlySpan<char> __tmp37_line = __tmp37Reader.ReadLine();
                        __tmp37_last = __tmp37Reader.EndOfStream;
                        if (!__tmp37_last || !__tmp37_line.IsEmpty)
                        {
                            __out.Write(__tmp37_line);
                            __tmp35_outputWritten = true;
                        }
                        if (!__tmp37_last) __out.AppendLine(true);
                    }
                    string __tmp38_line = ">(this, nameof("; //317:83
                    if (!string.IsNullOrEmpty(__tmp38_line))
                    {
                        __out.Write(__tmp38_line);
                        __tmp35_outputWritten = true;
                    }
                    var __tmp39 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp39.Write(prop.Name);
                    var __tmp39Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp39.ToStringAndFree());
                    bool __tmp39_last = __tmp39Reader.EndOfStream;
                    while(!__tmp39_last)
                    {
                        ReadOnlySpan<char> __tmp39_line = __tmp39Reader.ReadLine();
                        __tmp39_last = __tmp39Reader.EndOfStream;
                        if (!__tmp39_last || !__tmp39_line.IsEmpty)
                        {
                            __out.Write(__tmp39_line);
                            __tmp35_outputWritten = true;
                        }
                        if (!__tmp39_last) __out.AppendLine(true);
                    }
                    string __tmp40_line = "), diagnostics, cancellationToken);"; //317:109
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Write(__tmp40_line);
                        __tmp35_outputWritten = true;
                    }
                    if (__tmp35_outputWritten) __out.AppendLine(true);
                    if (__tmp35_outputWritten)
                    {
                        __out.AppendLine(false); //317:144
                    }
                }
                __out.Write("        }"); //319:1
                __out.AppendLine(false); //319:10
            }
            __out.AppendLine(true); //321:1
            __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //322:1
            __out.AppendLine(false); //322:152
            __out.Write("        {"); //323:1
            __out.AppendLine(false); //323:10
            __out.Write("        }"); //324:1
            __out.AppendLine(false); //324:10
            __out.Write("    }"); //325:1
            __out.AppendLine(false); //325:6
            __out.Write("}"); //326:1
            __out.AppendLine(false); //326:2
            return __out.ToStringAndFree();
        }

        public string GenerateSourceSymbol(SymbolGenerationInfo symbol) //329:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //330:1
            __out.AppendLine(false); //330:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //331:1
            __out.AppendLine(false); //331:29
            __out.Write("using MetaDslx.CodeAnalysis.Binding;"); //332:1
            __out.AppendLine(false); //332:37
            __out.Write("using MetaDslx.CodeAnalysis.Binding.Binders;"); //333:1
            __out.AppendLine(false); //333:45
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //334:1
            __out.AppendLine(false); //334:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //335:1
            __out.AppendLine(false); //335:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //336:1
            __out.AppendLine(false); //336:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //337:1
            __out.AppendLine(false); //337:44
            __out.Write("using System;"); //338:1
            __out.AppendLine(false); //338:14
            __out.Write("using System.Collections.Generic;"); //339:1
            __out.AppendLine(false); //339:34
            __out.Write("using System.Collections.Immutable;"); //340:1
            __out.AppendLine(false); //340:36
            __out.Write("using System.Diagnostics;"); //341:1
            __out.AppendLine(false); //341:26
            __out.Write("using System.Linq;"); //342:1
            __out.AppendLine(false); //342:19
            __out.Write("using System.Text;"); //343:1
            __out.AppendLine(false); //343:19
            __out.Write("using System.Threading;"); //344:1
            __out.AppendLine(false); //344:24
            __out.AppendLine(true); //345:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //346:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Write(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp4.Write(symbol.NamespaceName);
            var __tmp4Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp4.ToStringAndFree());
            bool __tmp4_last = __tmp4Reader.EndOfStream;
            while(!__tmp4_last)
            {
                ReadOnlySpan<char> __tmp4_line = __tmp4Reader.ReadLine();
                __tmp4_last = __tmp4Reader.EndOfStream;
                if (!__tmp4_last || !__tmp4_line.IsEmpty)
                {
                    __out.Write(__tmp4_line);
                    __tmp2_outputWritten = true;
                }
                if (!__tmp4_last) __out.AppendLine(true);
            }
            string __tmp5_line = ".Source"; //346:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //346:40
            }
            __out.Write("{"); //347:1
            __out.AppendLine(false); //347:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Source"; //348:1
            if (!string.IsNullOrEmpty(__tmp8_line))
            {
                __out.Write(__tmp8_line);
                __tmp7_outputWritten = true;
            }
            var __tmp9 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp9.Write(symbol.Name);
            var __tmp9Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp9.ToStringAndFree());
            bool __tmp9_last = __tmp9Reader.EndOfStream;
            while(!__tmp9_last)
            {
                ReadOnlySpan<char> __tmp9_line = __tmp9Reader.ReadLine();
                __tmp9_last = __tmp9Reader.EndOfStream;
                if (!__tmp9_last || !__tmp9_line.IsEmpty)
                {
                    __out.Write(__tmp9_line);
                    __tmp7_outputWritten = true;
                }
                if (!__tmp9_last) __out.AppendLine(true);
            }
            string __tmp10_line = " : "; //348:42
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Write(__tmp10_line);
                __tmp7_outputWritten = true;
            }
            var __tmp11 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp11.Write(symbol.NamespaceName);
            var __tmp11Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp11.ToStringAndFree());
            bool __tmp11_last = __tmp11Reader.EndOfStream;
            while(!__tmp11_last)
            {
                ReadOnlySpan<char> __tmp11_line = __tmp11Reader.ReadLine();
                __tmp11_last = __tmp11Reader.EndOfStream;
                if (!__tmp11_last || !__tmp11_line.IsEmpty)
                {
                    __out.Write(__tmp11_line);
                    __tmp7_outputWritten = true;
                }
                if (!__tmp11_last) __out.AppendLine(true);
            }
            string __tmp12_line = ".Model.Model"; //348:67
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Write(__tmp12_line);
                __tmp7_outputWritten = true;
            }
            var __tmp13 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp13.Write(symbol.Name);
            var __tmp13Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp13.ToStringAndFree());
            bool __tmp13_last = __tmp13Reader.EndOfStream;
            while(!__tmp13_last)
            {
                ReadOnlySpan<char> __tmp13_line = __tmp13Reader.ReadLine();
                __tmp13_last = __tmp13Reader.EndOfStream;
                if (!__tmp13_last || !__tmp13_line.IsEmpty)
                {
                    __out.Write(__tmp13_line);
                    __tmp7_outputWritten = true;
                }
                if (!__tmp13_last) __out.AppendLine(true);
            }
            string __tmp14_line = ", MetaDslx.CodeAnalysis.Symbols.Source.ISourceSymbol"; //348:92
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp7_outputWritten = true;
            }
            if (__tmp7_outputWritten) __out.AppendLine(true);
            if (__tmp7_outputWritten)
            {
                __out.AppendLine(false); //348:144
            }
            __out.Write("	{"); //349:1
            __out.AppendLine(false); //349:3
            __out.Write("        private readonly MergedDeclaration _declaration;"); //350:1
            __out.AppendLine(false); //350:57
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "		public Source"; //352:1
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Write(__tmp17_line);
                __tmp16_outputWritten = true;
            }
            var __tmp18 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp18.Write(symbol.Name);
            var __tmp18Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp18.ToStringAndFree());
            bool __tmp18_last = __tmp18Reader.EndOfStream;
            while(!__tmp18_last)
            {
                ReadOnlySpan<char> __tmp18_line = __tmp18Reader.ReadLine();
                __tmp18_last = __tmp18Reader.EndOfStream;
                if (!__tmp18_last || !__tmp18_line.IsEmpty)
                {
                    __out.Write(__tmp18_line);
                    __tmp16_outputWritten = true;
                }
                if (!__tmp18_last) __out.AppendLine(true);
            }
            string __tmp19_line = "(Symbol containingSymbol, object modelObject, MergedDeclaration declaration)"; //352:29
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Write(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //352:105
            }
            __out.Write("            : base(containingSymbol, modelObject)"); //353:1
            __out.AppendLine(false); //353:50
            __out.Write("        {"); //354:1
            __out.AppendLine(false); //354:10
            __out.Write("            Debug.Assert(declaration != null);"); //355:1
            __out.AppendLine(false); //355:47
            __out.Write("            _declaration = declaration;"); //356:1
            __out.AppendLine(false); //356:40
            __out.Write("		}"); //357:1
            __out.AppendLine(false); //357:4
            __out.AppendLine(true); //358:1
            __out.Write("        public MergedDeclaration MergedDeclaration => _declaration;"); //359:1
            __out.AppendLine(false); //359:68
            __out.AppendLine(true); //360:1
            __out.Write("        public override ImmutableArray<Location> Locations => _declaration.NameLocations;"); //361:1
            __out.AppendLine(false); //361:90
            __out.AppendLine(true); //362:1
            __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration.SyntaxReferences;"); //363:1
            __out.AppendLine(false); //363:116
            __out.AppendLine(true); //364:1
            __out.Write("        public BinderPosition<SymbolBinder> GetBinder(SyntaxReference reference)"); //365:1
            __out.AppendLine(false); //365:81
            __out.Write("        {"); //366:1
            __out.AppendLine(false); //366:10
            __out.Write("            Debug.Assert(this.DeclaringSyntaxReferences.Contains(reference));"); //367:1
            __out.AppendLine(false); //367:78
            __out.Write("            return FindBinders.FindSymbolBinder(this, reference);"); //368:1
            __out.AppendLine(false); //368:66
            __out.Write("        }"); //369:1
            __out.AppendLine(false); //369:10
            __out.AppendLine(true); //370:1
            __out.Write("        public Symbol GetChildSymbol(SyntaxReference syntax)"); //371:1
            __out.AppendLine(false); //371:61
            __out.Write("        {"); //372:1
            __out.AppendLine(false); //372:10
            __out.Write("            foreach (var child in this.ChildSymbols)"); //373:1
            __out.AppendLine(false); //373:53
            __out.Write("            {"); //374:1
            __out.AppendLine(false); //374:14
            __out.Write("                if (child.DeclaringSyntaxReferences.Any(sr => sr.GetLocation() == syntax.GetLocation()))"); //375:1
            __out.AppendLine(false); //375:105
            __out.Write("                {"); //376:1
            __out.AppendLine(false); //376:18
            __out.Write("                    return child;"); //377:1
            __out.AppendLine(false); //377:34
            __out.Write("                }"); //378:1
            __out.AppendLine(false); //378:18
            __out.Write("            }"); //379:1
            __out.AppendLine(false); //379:14
            __out.Write("            return null;"); //380:1
            __out.AppendLine(false); //380:25
            __out.Write("        }"); //381:1
            __out.AppendLine(false); //381:10
            __out.AppendLine(true); //382:1
            __out.Write("        protected override void CompleteInitializingSymbol(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //383:1
            __out.AppendLine(false); //383:151
            __out.Write("        {"); //384:1
            __out.AppendLine(false); //384:10
            __out.Write("            SourceSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //385:1
            __out.AppendLine(false); //385:126
            __out.Write("        }"); //386:1
            __out.AppendLine(false); //386:10
            __out.AppendLine(true); //387:1
            __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //388:1
            __out.AppendLine(false); //388:171
            __out.Write("        {"); //389:1
            __out.AppendLine(false); //389:10
            __out.Write("            return SourceSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //390:1
            __out.AppendLine(false); //390:124
            __out.Write("        }"); //391:1
            __out.AppendLine(false); //391:10
            __out.AppendLine(true); //392:1
            __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //393:1
            __out.AppendLine(false); //393:140
            __out.Write("        {"); //394:1
            __out.AppendLine(false); //394:10
            __out.Write("            SourceSymbolImplementation.CompleteImports(this, locationOpt, diagnostics, cancellationToken);"); //395:1
            __out.AppendLine(false); //395:107
            __out.Write("        }"); //396:1
            __out.AppendLine(false); //396:10
            __out.AppendLine(true); //397:1
            var __loop10_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //398:16
                select new { prop = prop}
                ).ToList(); //398:10
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                var __tmp20 = __loop10_results[__loop10_iteration];
                var prop = __tmp20.prop;
                bool __tmp22_outputWritten = false;
                string __tmp23_line = "        protected override "; //399:1
                if (!string.IsNullOrEmpty(__tmp23_line))
                {
                    __out.Write(__tmp23_line);
                    __tmp22_outputWritten = true;
                }
                var __tmp24 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp24.Write(prop.Type);
                var __tmp24Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp24.ToStringAndFree());
                bool __tmp24_last = __tmp24Reader.EndOfStream;
                while(!__tmp24_last)
                {
                    ReadOnlySpan<char> __tmp24_line = __tmp24Reader.ReadLine();
                    __tmp24_last = __tmp24Reader.EndOfStream;
                    if (!__tmp24_last || !__tmp24_line.IsEmpty)
                    {
                        __out.Write(__tmp24_line);
                        __tmp22_outputWritten = true;
                    }
                    if (!__tmp24_last) __out.AppendLine(true);
                }
                string __tmp25_line = " CompleteSymbolProperty_"; //399:39
                if (!string.IsNullOrEmpty(__tmp25_line))
                {
                    __out.Write(__tmp25_line);
                    __tmp22_outputWritten = true;
                }
                var __tmp26 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp26.Write(prop.Name);
                var __tmp26Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp26.ToStringAndFree());
                bool __tmp26_last = __tmp26Reader.EndOfStream;
                while(!__tmp26_last)
                {
                    ReadOnlySpan<char> __tmp26_line = __tmp26Reader.ReadLine();
                    __tmp26_last = __tmp26Reader.EndOfStream;
                    if (!__tmp26_last || !__tmp26_line.IsEmpty)
                    {
                        __out.Write(__tmp26_line);
                        __tmp22_outputWritten = true;
                    }
                    if (!__tmp26_last) __out.AppendLine(true);
                }
                string __tmp27_line = "(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"; //399:74
                if (!string.IsNullOrEmpty(__tmp27_line))
                {
                    __out.Write(__tmp27_line);
                    __tmp22_outputWritten = true;
                }
                if (__tmp22_outputWritten) __out.AppendLine(true);
                if (__tmp22_outputWritten)
                {
                    __out.AppendLine(false); //399:166
                }
                __out.Write("        {"); //400:1
                __out.AppendLine(false); //400:10
                if (prop.IsCollection) //401:14
                {
                    bool __tmp29_outputWritten = false;
                    string __tmp30_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValues<"; //402:1
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Write(__tmp30_line);
                        __tmp29_outputWritten = true;
                    }
                    var __tmp31 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp31.Write(prop.ItemType);
                    var __tmp31Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp31.ToStringAndFree());
                    bool __tmp31_last = __tmp31Reader.EndOfStream;
                    while(!__tmp31_last)
                    {
                        ReadOnlySpan<char> __tmp31_line = __tmp31Reader.ReadLine();
                        __tmp31_last = __tmp31Reader.EndOfStream;
                        if (!__tmp31_last || !__tmp31_line.IsEmpty)
                        {
                            __out.Write(__tmp31_line);
                            __tmp29_outputWritten = true;
                        }
                        if (!__tmp31_last) __out.AppendLine(true);
                    }
                    string __tmp32_line = ">(this, nameof("; //402:89
                    if (!string.IsNullOrEmpty(__tmp32_line))
                    {
                        __out.Write(__tmp32_line);
                        __tmp29_outputWritten = true;
                    }
                    var __tmp33 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp33.Write(prop.Name);
                    var __tmp33Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp33.ToStringAndFree());
                    bool __tmp33_last = __tmp33Reader.EndOfStream;
                    while(!__tmp33_last)
                    {
                        ReadOnlySpan<char> __tmp33_line = __tmp33Reader.ReadLine();
                        __tmp33_last = __tmp33Reader.EndOfStream;
                        if (!__tmp33_last || !__tmp33_line.IsEmpty)
                        {
                            __out.Write(__tmp33_line);
                            __tmp29_outputWritten = true;
                        }
                        if (!__tmp33_last) __out.AppendLine(true);
                    }
                    string __tmp34_line = "), diagnostics, cancellationToken);"; //402:115
                    if (!string.IsNullOrEmpty(__tmp34_line))
                    {
                        __out.Write(__tmp34_line);
                        __tmp29_outputWritten = true;
                    }
                    if (__tmp29_outputWritten) __out.AppendLine(true);
                    if (__tmp29_outputWritten)
                    {
                        __out.AppendLine(false); //402:150
                    }
                }
                else //403:14
                {
                    bool __tmp36_outputWritten = false;
                    string __tmp37_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValue<"; //404:1
                    if (!string.IsNullOrEmpty(__tmp37_line))
                    {
                        __out.Write(__tmp37_line);
                        __tmp36_outputWritten = true;
                    }
                    var __tmp38 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp38.Write(prop.Type);
                    var __tmp38Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp38.ToStringAndFree());
                    bool __tmp38_last = __tmp38Reader.EndOfStream;
                    while(!__tmp38_last)
                    {
                        ReadOnlySpan<char> __tmp38_line = __tmp38Reader.ReadLine();
                        __tmp38_last = __tmp38Reader.EndOfStream;
                        if (!__tmp38_last || !__tmp38_line.IsEmpty)
                        {
                            __out.Write(__tmp38_line);
                            __tmp36_outputWritten = true;
                        }
                        if (!__tmp38_last) __out.AppendLine(true);
                    }
                    string __tmp39_line = ">(this, nameof("; //404:84
                    if (!string.IsNullOrEmpty(__tmp39_line))
                    {
                        __out.Write(__tmp39_line);
                        __tmp36_outputWritten = true;
                    }
                    var __tmp40 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp40.Write(prop.Name);
                    var __tmp40Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp40.ToStringAndFree());
                    bool __tmp40_last = __tmp40Reader.EndOfStream;
                    while(!__tmp40_last)
                    {
                        ReadOnlySpan<char> __tmp40_line = __tmp40Reader.ReadLine();
                        __tmp40_last = __tmp40Reader.EndOfStream;
                        if (!__tmp40_last || !__tmp40_line.IsEmpty)
                        {
                            __out.Write(__tmp40_line);
                            __tmp36_outputWritten = true;
                        }
                        if (!__tmp40_last) __out.AppendLine(true);
                    }
                    string __tmp41_line = "), diagnostics, cancellationToken);"; //404:110
                    if (!string.IsNullOrEmpty(__tmp41_line))
                    {
                        __out.Write(__tmp41_line);
                        __tmp36_outputWritten = true;
                    }
                    if (__tmp36_outputWritten) __out.AppendLine(true);
                    if (__tmp36_outputWritten)
                    {
                        __out.AppendLine(false); //404:145
                    }
                }
                __out.Write("        }"); //406:1
                __out.AppendLine(false); //406:10
            }
            __out.AppendLine(true); //408:1
            __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //409:1
            __out.AppendLine(false); //409:152
            __out.Write("        {"); //410:1
            __out.AppendLine(false); //410:10
            __out.Write("            SourceSymbolImplementation.AssignNonSymbolProperties(this, diagnostics, cancellationToken);"); //411:1
            __out.AppendLine(false); //411:104
            __out.Write("        }"); //412:1
            __out.AppendLine(false); //412:10
            __out.AppendLine(true); //413:1
            __out.Write("	}"); //414:1
            __out.AppendLine(false); //414:3
            __out.Write("}"); //415:1
            __out.AppendLine(false); //415:2
            return __out.ToStringAndFree();
        }

        public string GenerateVisitor(string namespaceName, IEnumerable<SymbolGenerationInfo> symbols) //418:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //419:1
            __out.AppendLine(false); //419:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //420:1
            __out.AppendLine(false); //420:29
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //421:1
            __out.AppendLine(false); //421:37
            __out.Write("using System;"); //422:1
            __out.AppendLine(false); //422:14
            __out.Write("using System.Collections.Generic;"); //423:1
            __out.AppendLine(false); //423:34
            __out.Write("using System.Collections.Immutable;"); //424:1
            __out.AppendLine(false); //424:36
            __out.Write("using System.Diagnostics;"); //425:1
            __out.AppendLine(false); //425:26
            __out.Write("using System.Text;"); //426:1
            __out.AppendLine(false); //426:19
            __out.Write("using System.Threading;"); //427:1
            __out.AppendLine(false); //427:24
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //429:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Write(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp4.Write(namespaceName);
            var __tmp4Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp4.ToStringAndFree());
            bool __tmp4_last = __tmp4Reader.EndOfStream;
            while(!__tmp4_last)
            {
                ReadOnlySpan<char> __tmp4_line = __tmp4Reader.ReadLine();
                __tmp4_last = __tmp4Reader.EndOfStream;
                if (!__tmp4_last || !__tmp4_line.IsEmpty)
                {
                    __out.Write(__tmp4_line);
                    __tmp2_outputWritten = true;
                }
                if (!__tmp4_last || __tmp2_outputWritten) __out.AppendLine(true);
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //429:26
            }
            __out.Write("{"); //430:1
            __out.AppendLine(false); //430:2
            __out.Write("	public interface ISymbolVisitor"); //431:1
            __out.AppendLine(false); //431:33
            __out.Write("	{"); //432:1
            __out.AppendLine(false); //432:3
            var __loop11_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //433:16
                select new { symbol = symbol}
                ).ToList(); //433:10
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp5 = __loop11_results[__loop11_iteration];
                var symbol = __tmp5.symbol;
                bool __tmp7_outputWritten = false;
                string __tmp8_line = "        void Visit("; //434:1
                if (!string.IsNullOrEmpty(__tmp8_line))
                {
                    __out.Write(__tmp8_line);
                    __tmp7_outputWritten = true;
                }
                var __tmp9 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp9.Write(symbol.Name);
                var __tmp9Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp9.ToStringAndFree());
                bool __tmp9_last = __tmp9Reader.EndOfStream;
                while(!__tmp9_last)
                {
                    ReadOnlySpan<char> __tmp9_line = __tmp9Reader.ReadLine();
                    __tmp9_last = __tmp9Reader.EndOfStream;
                    if (!__tmp9_last || !__tmp9_line.IsEmpty)
                    {
                        __out.Write(__tmp9_line);
                        __tmp7_outputWritten = true;
                    }
                    if (!__tmp9_last) __out.AppendLine(true);
                }
                string __tmp10_line = " symbol);"; //434:33
                if (!string.IsNullOrEmpty(__tmp10_line))
                {
                    __out.Write(__tmp10_line);
                    __tmp7_outputWritten = true;
                }
                if (__tmp7_outputWritten) __out.AppendLine(true);
                if (__tmp7_outputWritten)
                {
                    __out.AppendLine(false); //434:42
                }
            }
            __out.Write("	}"); //436:1
            __out.AppendLine(false); //436:3
            __out.AppendLine(true); //437:1
            __out.Write("	public interface ISymbolVisitor<TResult>"); //438:1
            __out.AppendLine(false); //438:42
            __out.Write("	{"); //439:1
            __out.AppendLine(false); //439:3
            var __loop12_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //440:16
                select new { symbol = symbol}
                ).ToList(); //440:10
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp11 = __loop12_results[__loop12_iteration];
                var symbol = __tmp11.symbol;
                bool __tmp13_outputWritten = false;
                string __tmp14_line = "        TResult Visit("; //441:1
                if (!string.IsNullOrEmpty(__tmp14_line))
                {
                    __out.Write(__tmp14_line);
                    __tmp13_outputWritten = true;
                }
                var __tmp15 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp15.Write(symbol.Name);
                var __tmp15Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp15.ToStringAndFree());
                bool __tmp15_last = __tmp15Reader.EndOfStream;
                while(!__tmp15_last)
                {
                    ReadOnlySpan<char> __tmp15_line = __tmp15Reader.ReadLine();
                    __tmp15_last = __tmp15Reader.EndOfStream;
                    if (!__tmp15_last || !__tmp15_line.IsEmpty)
                    {
                        __out.Write(__tmp15_line);
                        __tmp13_outputWritten = true;
                    }
                    if (!__tmp15_last) __out.AppendLine(true);
                }
                string __tmp16_line = " symbol);"; //441:36
                if (!string.IsNullOrEmpty(__tmp16_line))
                {
                    __out.Write(__tmp16_line);
                    __tmp13_outputWritten = true;
                }
                if (__tmp13_outputWritten) __out.AppendLine(true);
                if (__tmp13_outputWritten)
                {
                    __out.AppendLine(false); //441:45
                }
            }
            __out.Write("	}"); //443:1
            __out.AppendLine(false); //443:3
            __out.AppendLine(true); //444:1
            __out.Write("	public interface ISymbolVisitor<TArgument, TResult>"); //445:1
            __out.AppendLine(false); //445:53
            __out.Write("	{"); //446:1
            __out.AppendLine(false); //446:3
            var __loop13_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //447:16
                select new { symbol = symbol}
                ).ToList(); //447:10
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp17 = __loop13_results[__loop13_iteration];
                var symbol = __tmp17.symbol;
                bool __tmp19_outputWritten = false;
                string __tmp20_line = "        TResult Visit("; //448:1
                if (!string.IsNullOrEmpty(__tmp20_line))
                {
                    __out.Write(__tmp20_line);
                    __tmp19_outputWritten = true;
                }
                var __tmp21 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp21.Write(symbol.Name);
                var __tmp21Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp21.ToStringAndFree());
                bool __tmp21_last = __tmp21Reader.EndOfStream;
                while(!__tmp21_last)
                {
                    ReadOnlySpan<char> __tmp21_line = __tmp21Reader.ReadLine();
                    __tmp21_last = __tmp21Reader.EndOfStream;
                    if (!__tmp21_last || !__tmp21_line.IsEmpty)
                    {
                        __out.Write(__tmp21_line);
                        __tmp19_outputWritten = true;
                    }
                    if (!__tmp21_last) __out.AppendLine(true);
                }
                string __tmp22_line = " symbol, TArgument argument);"; //448:36
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Write(__tmp22_line);
                    __tmp19_outputWritten = true;
                }
                if (__tmp19_outputWritten) __out.AppendLine(true);
                if (__tmp19_outputWritten)
                {
                    __out.AppendLine(false); //448:65
                }
            }
            __out.Write("	}"); //450:1
            __out.AppendLine(false); //450:3
            __out.Write("}"); //451:1
            __out.AppendLine(false); //451:2
            return __out.ToStringAndFree();
        }

    }
}

