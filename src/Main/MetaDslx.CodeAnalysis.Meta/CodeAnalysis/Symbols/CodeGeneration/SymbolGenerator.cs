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
                string __tmp11_line = "        public override "; //26:1
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
                string __tmp13_line = " "; //26:48
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
                string __tmp15_line = " => "; //26:72
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
                string __tmp17_line = "."; //26:99
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
                string __tmp19_line = ";"; //26:119
                if (!string.IsNullOrEmpty(__tmp19_line))
                {
                    __out.Write(__tmp19_line);
                    __tmp10_outputWritten = true;
                }
                if (__tmp10_outputWritten) __out.AppendLine(true);
                if (__tmp10_outputWritten)
                {
                    __out.AppendLine(false); //26:120
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
            __out.Write("	}"); //52:1
            __out.AppendLine(false); //52:3
            __out.Write("}"); //53:1
            __out.AppendLine(false); //53:2
            return __out.ToStringAndFree();
        }

        public string GenerateModelSymbol(SymbolGenerationInfo symbol) //56:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //57:1
            __out.AppendLine(false); //57:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //58:1
            __out.AppendLine(false); //58:29
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //59:1
            __out.AppendLine(false); //59:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //60:1
            __out.AppendLine(false); //60:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //61:1
            __out.AppendLine(false); //61:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //62:1
            __out.AppendLine(false); //62:44
            __out.Write("using System;"); //63:1
            __out.AppendLine(false); //63:14
            __out.Write("using System.Collections.Generic;"); //64:1
            __out.AppendLine(false); //64:34
            __out.Write("using System.Collections.Immutable;"); //65:1
            __out.AppendLine(false); //65:36
            __out.Write("using System.Diagnostics;"); //66:1
            __out.AppendLine(false); //66:26
            __out.Write("using System.Text;"); //67:1
            __out.AppendLine(false); //67:19
            __out.Write("using System.Threading;"); //68:1
            __out.AppendLine(false); //68:24
            __out.Write("using Roslyn.Utilities;"); //69:1
            __out.AppendLine(false); //69:24
            __out.AppendLine(true); //70:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //71:1
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
            string __tmp5_line = ".Model"; //71:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //71:39
            }
            __out.Write("{"); //72:1
            __out.AppendLine(false); //72:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public abstract partial class Model"; //73:1
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
            string __tmp10_line = " : "; //73:50
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
            string __tmp12_line = "."; //73:75
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
            string __tmp14_line = ", MetaDslx.CodeAnalysis.Symbols.Metadata.IModelSymbol"; //73:89
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp7_outputWritten = true;
            }
            if (__tmp7_outputWritten) __out.AppendLine(true);
            if (__tmp7_outputWritten)
            {
                __out.AppendLine(false); //73:142
            }
            __out.Write("	{"); //74:1
            __out.AppendLine(false); //74:3
            __out.Write("        public static class CompletionParts"); //75:1
            __out.AppendLine(false); //75:44
            __out.Write("        {"); //76:1
            __out.AppendLine(false); //76:10
            var __loop1_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //77:20
                select new { prop = prop}
                ).ToList(); //77:14
            for (int __loop1_iteration = 0; __loop1_iteration < __loop1_results.Count; ++__loop1_iteration)
            {
                var __tmp15 = __loop1_results[__loop1_iteration];
                var prop = __tmp15.prop;
                bool __tmp17_outputWritten = false;
                string __tmp18_line = "            public static readonly CompletionPart StartComputingProperty_"; //78:1
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
                string __tmp20_line = " = new CompletionPart(nameof(StartComputingProperty_"; //78:85
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
                string __tmp22_line = "));"; //78:148
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Write(__tmp22_line);
                    __tmp17_outputWritten = true;
                }
                if (__tmp17_outputWritten) __out.AppendLine(true);
                if (__tmp17_outputWritten)
                {
                    __out.AppendLine(false); //78:151
                }
                bool __tmp24_outputWritten = false;
                string __tmp25_line = "            public static readonly CompletionPart FinishComputingProperty_"; //79:1
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
                string __tmp27_line = " = new CompletionPart(nameof(FinishComputingProperty_"; //79:86
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
                string __tmp29_line = "));"; //79:150
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Write(__tmp29_line);
                    __tmp24_outputWritten = true;
                }
                if (__tmp24_outputWritten) __out.AppendLine(true);
                if (__tmp24_outputWritten)
                {
                    __out.AppendLine(false); //79:153
                }
            }
            bool __tmp31_outputWritten = false;
            string __tmp32_line = "            public static readonly ImmutableHashSet<CompletionPart> AllWithLocation = CompletionPart.Combine(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren"; //81:1
            if (!string.IsNullOrEmpty(__tmp32_line))
            {
                __out.Write(__tmp32_line);
                __tmp31_outputWritten = true;
            }
            var __loop2_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //81:265
                select new { prop = prop}
                ).ToList(); //81:259
            for (int __loop2_iteration = 0; __loop2_iteration < __loop2_results.Count; ++__loop2_iteration)
            {
                var __tmp34 = __loop2_results[__loop2_iteration];
                var prop = __tmp34.prop;
                string __tmp35_line = ", StartComputingProperty_"; //81:289
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
                string __tmp37_line = ", FinishComputingProperty_"; //81:325
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
            string __tmp40_line = ", CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties);"; //81:372
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Write(__tmp40_line);
                __tmp31_outputWritten = true;
            }
            if (__tmp31_outputWritten) __out.AppendLine(true);
            if (__tmp31_outputWritten)
            {
                __out.AppendLine(false); //81:477
            }
            bool __tmp42_outputWritten = false;
            string __tmp43_line = "            public static readonly ImmutableHashSet<CompletionPart> All = CompletionPart.Combine(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren"; //82:1
            if (!string.IsNullOrEmpty(__tmp43_line))
            {
                __out.Write(__tmp43_line);
                __tmp42_outputWritten = true;
            }
            var __loop3_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //82:253
                select new { prop = prop}
                ).ToList(); //82:247
            for (int __loop3_iteration = 0; __loop3_iteration < __loop3_results.Count; ++__loop3_iteration)
            {
                var __tmp45 = __loop3_results[__loop3_iteration];
                var prop = __tmp45.prop;
                string __tmp46_line = ", StartComputingProperty_"; //82:277
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
                string __tmp48_line = ", FinishComputingProperty_"; //82:313
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
            string __tmp51_line = ", CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties, CompletionGraph.ChildrenCompleted);"; //82:360
            if (!string.IsNullOrEmpty(__tmp51_line))
            {
                __out.Write(__tmp51_line);
                __tmp42_outputWritten = true;
            }
            if (__tmp42_outputWritten) __out.AppendLine(true);
            if (__tmp42_outputWritten)
            {
                __out.AppendLine(false); //82:500
            }
            bool __tmp53_outputWritten = false;
            string __tmp54_line = "            public static readonly CompletionGraph CompletionGraph = CompletionGraph.FromCompletionParts(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren"; //83:1
            if (!string.IsNullOrEmpty(__tmp54_line))
            {
                __out.Write(__tmp54_line);
                __tmp53_outputWritten = true;
            }
            var __loop4_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //83:261
                select new { prop = prop}
                ).ToList(); //83:255
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                var __tmp56 = __loop4_results[__loop4_iteration];
                var prop = __tmp56.prop;
                string __tmp57_line = ", StartComputingProperty_"; //83:285
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
                string __tmp59_line = ", FinishComputingProperty_"; //83:321
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
            string __tmp62_line = ", CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties, CompletionGraph.ChildrenCompleted);"; //83:368
            if (!string.IsNullOrEmpty(__tmp62_line))
            {
                __out.Write(__tmp62_line);
                __tmp53_outputWritten = true;
            }
            if (__tmp53_outputWritten) __out.AppendLine(true);
            if (__tmp53_outputWritten)
            {
                __out.AppendLine(false); //83:508
            }
            __out.Write("        }"); //84:1
            __out.AppendLine(false); //84:10
            __out.AppendLine(true); //85:1
            __out.Write("        private readonly Symbol _container;"); //86:1
            __out.AppendLine(false); //86:44
            __out.Write("        private readonly object? _modelObject;"); //87:1
            __out.AppendLine(false); //87:47
            __out.Write("        private readonly CompletionState _state;"); //88:1
            __out.AppendLine(false); //88:49
            __out.Write("        private ImmutableArray<Symbol> _childSymbols;"); //89:1
            __out.AppendLine(false); //89:54
            __out.Write("        private string _name;"); //90:1
            __out.AppendLine(false); //90:30
            var __loop5_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //91:16
                select new { prop = prop}
                ).ToList(); //91:10
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                var __tmp63 = __loop5_results[__loop5_iteration];
                var prop = __tmp63.prop;
                bool __tmp65_outputWritten = false;
                string __tmp66_line = "        private "; //92:1
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
                string __tmp68_line = " "; //92:28
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
                string __tmp70_line = ";"; //92:45
                if (!string.IsNullOrEmpty(__tmp70_line))
                {
                    __out.Write(__tmp70_line);
                    __tmp65_outputWritten = true;
                }
                if (__tmp65_outputWritten) __out.AppendLine(true);
                if (__tmp65_outputWritten)
                {
                    __out.AppendLine(false); //92:46
                }
            }
            __out.AppendLine(true); //94:1
            bool __tmp72_outputWritten = false;
            string __tmp73_line = "        public Model"; //95:1
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
            string __tmp75_line = "(Symbol container, object? modelObject"; //95:34
            if (!string.IsNullOrEmpty(__tmp75_line))
            {
                __out.Write(__tmp75_line);
                __tmp72_outputWritten = true;
            }
            if (symbol.OptionalModelObject) //95:73
            {
                string __tmp77_line = " = null"; //95:104
                if (!string.IsNullOrEmpty(__tmp77_line))
                {
                    __out.Write(__tmp77_line);
                    __tmp72_outputWritten = true;
                }
            }
            string __tmp79_line = ")"; //95:119
            if (!string.IsNullOrEmpty(__tmp79_line))
            {
                __out.Write(__tmp79_line);
                __tmp72_outputWritten = true;
            }
            if (__tmp72_outputWritten) __out.AppendLine(true);
            if (__tmp72_outputWritten)
            {
                __out.AppendLine(false); //95:120
            }
            __out.Write("        {"); //96:1
            __out.AppendLine(false); //96:10
            __out.Write("            Debug.Assert(container is IModelSymbol);"); //97:1
            __out.AppendLine(false); //97:53
            if (!symbol.OptionalModelObject) //98:14
            {
                __out.Write("            if (modelObject is null) throw new ArgumentNullException(nameof(modelObject));"); //99:1
                __out.AppendLine(false); //99:91
            }
            __out.Write("            _container = container;"); //101:1
            __out.AppendLine(false); //101:36
            __out.Write("            _modelObject = modelObject;"); //102:1
            __out.AppendLine(false); //102:40
            __out.Write("            _state = CompletionParts.CompletionGraph.CreateState();"); //103:1
            __out.AppendLine(false); //103:68
            __out.Write("        }"); //104:1
            __out.AppendLine(false); //104:10
            __out.AppendLine(true); //105:1
            __out.Write("        public sealed override Language Language => ContainingModule.Language;"); //106:1
            __out.AppendLine(false); //106:79
            __out.AppendLine(true); //107:1
            __out.Write("        public SymbolFactory SymbolFactory => ((IModelSymbol)_container).SymbolFactory;"); //108:1
            __out.AppendLine(false); //108:88
            __out.AppendLine(true); //109:1
            __out.Write("        public object ModelObject => _modelObject;"); //110:1
            __out.AppendLine(false); //110:51
            __out.AppendLine(true); //111:1
            __out.Write("        public Type ModelObjectType => _modelObject is not null ? Language.SymbolFacts.GetModelObjectType(_modelObject) : null;"); //112:1
            __out.AppendLine(false); //112:128
            __out.AppendLine(true); //113:1
            __out.Write("        public sealed override Symbol ContainingSymbol => _container;"); //114:1
            __out.AppendLine(false); //114:70
            __out.AppendLine(true); //115:1
            __out.Write("        public sealed override ImmutableArray<Symbol> ChildSymbols "); //116:1
            __out.AppendLine(false); //116:68
            __out.Write("        {"); //117:1
            __out.AppendLine(false); //117:10
            __out.Write("            get"); //118:1
            __out.AppendLine(false); //118:16
            __out.Write("            {"); //119:1
            __out.AppendLine(false); //119:14
            __out.Write("                this.ForceComplete(CompletionGraph.FinishCreatingChildren, null, default);"); //120:1
            __out.AppendLine(false); //120:91
            __out.Write("                return _childSymbols;"); //121:1
            __out.AppendLine(false); //121:38
            __out.Write("            }"); //122:1
            __out.AppendLine(false); //122:14
            __out.Write("        }"); //123:1
            __out.AppendLine(false); //123:10
            __out.AppendLine(true); //124:1
            __out.Write("        public override string Name "); //125:1
            __out.AppendLine(false); //125:37
            __out.Write("        {"); //126:1
            __out.AppendLine(false); //126:10
            __out.Write("            get"); //127:1
            __out.AppendLine(false); //127:16
            __out.Write("            {"); //128:1
            __out.AppendLine(false); //128:14
            __out.Write("                this.ForceComplete(CompletionGraph.FinishInitializing, null, default);"); //129:1
            __out.AppendLine(false); //129:87
            __out.Write("                return _name;"); //130:1
            __out.AppendLine(false); //130:30
            __out.Write("            }"); //131:1
            __out.AppendLine(false); //131:14
            __out.Write("        }"); //132:1
            __out.AppendLine(false); //132:10
            __out.AppendLine(true); //133:1
            var __loop6_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //134:16
                select new { prop = prop}
                ).ToList(); //134:10
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp80 = __loop6_results[__loop6_iteration];
                var prop = __tmp80.prop;
                bool __tmp82_outputWritten = false;
                string __tmp83_line = "        public override "; //135:1
                if (!string.IsNullOrEmpty(__tmp83_line))
                {
                    __out.Write(__tmp83_line);
                    __tmp82_outputWritten = true;
                }
                var __tmp84 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp84.Write(prop.Type);
                var __tmp84Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp84.ToStringAndFree());
                bool __tmp84_last = __tmp84Reader.EndOfStream;
                while(!__tmp84_last)
                {
                    ReadOnlySpan<char> __tmp84_line = __tmp84Reader.ReadLine();
                    __tmp84_last = __tmp84Reader.EndOfStream;
                    if (!__tmp84_last || !__tmp84_line.IsEmpty)
                    {
                        __out.Write(__tmp84_line);
                        __tmp82_outputWritten = true;
                    }
                    if (!__tmp84_last) __out.AppendLine(true);
                }
                string __tmp85_line = " "; //135:36
                if (!string.IsNullOrEmpty(__tmp85_line))
                {
                    __out.Write(__tmp85_line);
                    __tmp82_outputWritten = true;
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
                        __tmp82_outputWritten = true;
                    }
                    if (!__tmp86_last || __tmp82_outputWritten) __out.AppendLine(true);
                }
                if (__tmp82_outputWritten)
                {
                    __out.AppendLine(false); //135:48
                }
                __out.Write("        {"); //136:1
                __out.AppendLine(false); //136:10
                __out.Write("            get"); //137:1
                __out.AppendLine(false); //137:16
                __out.Write("            {"); //138:1
                __out.AppendLine(false); //138:14
                bool __tmp88_outputWritten = false;
                string __tmp89_line = "                this.ForceComplete(CompletionParts.FinishComputingProperty_"; //139:1
                if (!string.IsNullOrEmpty(__tmp89_line))
                {
                    __out.Write(__tmp89_line);
                    __tmp88_outputWritten = true;
                }
                var __tmp90 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp90.Write(prop.Name);
                var __tmp90Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp90.ToStringAndFree());
                bool __tmp90_last = __tmp90Reader.EndOfStream;
                while(!__tmp90_last)
                {
                    ReadOnlySpan<char> __tmp90_line = __tmp90Reader.ReadLine();
                    __tmp90_last = __tmp90Reader.EndOfStream;
                    if (!__tmp90_last || !__tmp90_line.IsEmpty)
                    {
                        __out.Write(__tmp90_line);
                        __tmp88_outputWritten = true;
                    }
                    if (!__tmp90_last) __out.AppendLine(true);
                }
                string __tmp91_line = ", null, default);"; //139:87
                if (!string.IsNullOrEmpty(__tmp91_line))
                {
                    __out.Write(__tmp91_line);
                    __tmp88_outputWritten = true;
                }
                if (__tmp88_outputWritten) __out.AppendLine(true);
                if (__tmp88_outputWritten)
                {
                    __out.AppendLine(false); //139:104
                }
                bool __tmp93_outputWritten = false;
                string __tmp94_line = "                return "; //140:1
                if (!string.IsNullOrEmpty(__tmp94_line))
                {
                    __out.Write(__tmp94_line);
                    __tmp93_outputWritten = true;
                }
                var __tmp95 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp95.Write(prop.FieldName);
                var __tmp95Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp95.ToStringAndFree());
                bool __tmp95_last = __tmp95Reader.EndOfStream;
                while(!__tmp95_last)
                {
                    ReadOnlySpan<char> __tmp95_line = __tmp95Reader.ReadLine();
                    __tmp95_last = __tmp95Reader.EndOfStream;
                    if (!__tmp95_last || !__tmp95_line.IsEmpty)
                    {
                        __out.Write(__tmp95_line);
                        __tmp93_outputWritten = true;
                    }
                    if (!__tmp95_last) __out.AppendLine(true);
                }
                string __tmp96_line = ";"; //140:40
                if (!string.IsNullOrEmpty(__tmp96_line))
                {
                    __out.Write(__tmp96_line);
                    __tmp93_outputWritten = true;
                }
                if (__tmp93_outputWritten) __out.AppendLine(true);
                if (__tmp93_outputWritten)
                {
                    __out.AppendLine(false); //140:41
                }
                __out.Write("            }"); //141:1
                __out.AppendLine(false); //141:14
                __out.Write("        }"); //142:1
                __out.AppendLine(false); //142:10
            }
            __out.AppendLine(true); //144:1
            __out.Write("        #region Completion"); //145:1
            __out.AppendLine(false); //145:27
            __out.AppendLine(true); //146:1
            __out.Write("        public sealed override bool RequiresCompletion => true;"); //147:1
            __out.AppendLine(false); //147:64
            __out.AppendLine(true); //148:1
            __out.Write("        public sealed override bool HasComplete(CompletionPart part)"); //149:1
            __out.AppendLine(false); //149:69
            __out.Write("        {"); //150:1
            __out.AppendLine(false); //150:10
            __out.Write("            return _state.HasComplete(part);"); //151:1
            __out.AppendLine(false); //151:45
            __out.Write("        }"); //152:1
            __out.AppendLine(false); //152:10
            __out.AppendLine(true); //153:1
            __out.Write("        public override void ForceComplete(CompletionPart completionPart, SourceLocation locationOpt, CancellationToken cancellationToken)"); //154:1
            __out.AppendLine(false); //154:139
            __out.Write("        {"); //155:1
            __out.AppendLine(false); //155:10
            __out.Write("            if (completionPart != null && _state.HasComplete(completionPart)) return;"); //156:1
            __out.AppendLine(false); //156:86
            __out.Write("            if (completionPart != null && !CompletionParts.All.Contains(completionPart)) throw new ArgumentException(nameof(completionPart));"); //157:1
            __out.AppendLine(false); //157:142
            __out.Write("            while (true)"); //158:1
            __out.AppendLine(false); //158:25
            __out.Write("            {"); //159:1
            __out.AppendLine(false); //159:14
            __out.Write("                cancellationToken.ThrowIfCancellationRequested();"); //160:1
            __out.AppendLine(false); //160:66
            __out.Write("                var incompletePart = _state.NextIncompletePart;"); //161:1
            __out.AppendLine(false); //161:64
            __out.Write("                if (incompletePart == CompletionGraph.StartInitializing || incompletePart == CompletionGraph.FinishInitializing)"); //162:1
            __out.AppendLine(false); //162:129
            __out.Write("                {"); //163:1
            __out.AppendLine(false); //163:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartInitializing))"); //164:1
            __out.AppendLine(false); //164:84
            __out.Write("                    {"); //165:1
            __out.AppendLine(false); //165:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //166:1
            __out.AppendLine(false); //166:71
            __out.Write("                        _name = CompleteSymbolProperty_Name(locationOpt, diagnostics, cancellationToken);"); //167:1
            __out.AppendLine(false); //167:106
            __out.Write("                        CompleteInitializingSymbol(locationOpt, diagnostics, cancellationToken);"); //168:1
            __out.AppendLine(false); //168:97
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //169:1
            __out.AppendLine(false); //169:59
            __out.Write("                        diagnostics.Free();"); //170:1
            __out.AppendLine(false); //170:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishInitializing);"); //171:1
            __out.AppendLine(false); //171:85
            __out.Write("                    }"); //172:1
            __out.AppendLine(false); //172:22
            __out.Write("                }"); //173:1
            __out.AppendLine(false); //173:18
            __out.Write("                else if (incompletePart == CompletionGraph.StartCreatingChildren || incompletePart == CompletionGraph.FinishCreatingChildren)"); //174:1
            __out.AppendLine(false); //174:142
            __out.Write("                {"); //175:1
            __out.AppendLine(false); //175:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartCreatingChildren))"); //176:1
            __out.AppendLine(false); //176:88
            __out.Write("                    {"); //177:1
            __out.AppendLine(false); //177:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //178:1
            __out.AppendLine(false); //178:71
            __out.Write("                        _childSymbols = CompleteCreatingChildSymbols(locationOpt, diagnostics, cancellationToken);"); //179:1
            __out.AppendLine(false); //179:115
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //180:1
            __out.AppendLine(false); //180:59
            __out.Write("                        diagnostics.Free();"); //181:1
            __out.AppendLine(false); //181:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishCreatingChildren);"); //182:1
            __out.AppendLine(false); //182:89
            __out.Write("                    }"); //183:1
            __out.AppendLine(false); //183:22
            __out.Write("                }"); //184:1
            __out.AppendLine(false); //184:18
            var __loop7_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //185:24
                select new { prop = prop}
                ).ToList(); //185:18
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                var __tmp97 = __loop7_results[__loop7_iteration];
                var prop = __tmp97.prop;
                bool __tmp99_outputWritten = false;
                string __tmp100_line = "                else if (incompletePart == CompletionParts.StartComputingProperty_"; //186:1
                if (!string.IsNullOrEmpty(__tmp100_line))
                {
                    __out.Write(__tmp100_line);
                    __tmp99_outputWritten = true;
                }
                var __tmp101 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp101.Write(prop.Name);
                var __tmp101Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp101.ToStringAndFree());
                bool __tmp101_last = __tmp101Reader.EndOfStream;
                while(!__tmp101_last)
                {
                    ReadOnlySpan<char> __tmp101_line = __tmp101Reader.ReadLine();
                    __tmp101_last = __tmp101Reader.EndOfStream;
                    if (!__tmp101_last || !__tmp101_line.IsEmpty)
                    {
                        __out.Write(__tmp101_line);
                        __tmp99_outputWritten = true;
                    }
                    if (!__tmp101_last) __out.AppendLine(true);
                }
                string __tmp102_line = " || incompletePart == CompletionParts.FinishComputingProperty_"; //186:94
                if (!string.IsNullOrEmpty(__tmp102_line))
                {
                    __out.Write(__tmp102_line);
                    __tmp99_outputWritten = true;
                }
                var __tmp103 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp103.Write(prop.Name);
                var __tmp103Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp103.ToStringAndFree());
                bool __tmp103_last = __tmp103Reader.EndOfStream;
                while(!__tmp103_last)
                {
                    ReadOnlySpan<char> __tmp103_line = __tmp103Reader.ReadLine();
                    __tmp103_last = __tmp103Reader.EndOfStream;
                    if (!__tmp103_last || !__tmp103_line.IsEmpty)
                    {
                        __out.Write(__tmp103_line);
                        __tmp99_outputWritten = true;
                    }
                    if (!__tmp103_last) __out.AppendLine(true);
                }
                string __tmp104_line = ")"; //186:167
                if (!string.IsNullOrEmpty(__tmp104_line))
                {
                    __out.Write(__tmp104_line);
                    __tmp99_outputWritten = true;
                }
                if (__tmp99_outputWritten) __out.AppendLine(true);
                if (__tmp99_outputWritten)
                {
                    __out.AppendLine(false); //186:168
                }
                __out.Write("                {"); //187:1
                __out.AppendLine(false); //187:18
                bool __tmp106_outputWritten = false;
                string __tmp107_line = "                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_"; //188:1
                if (!string.IsNullOrEmpty(__tmp107_line))
                {
                    __out.Write(__tmp107_line);
                    __tmp106_outputWritten = true;
                }
                var __tmp108 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp108.Write(prop.Name);
                var __tmp108Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp108.ToStringAndFree());
                bool __tmp108_last = __tmp108Reader.EndOfStream;
                while(!__tmp108_last)
                {
                    ReadOnlySpan<char> __tmp108_line = __tmp108Reader.ReadLine();
                    __tmp108_last = __tmp108Reader.EndOfStream;
                    if (!__tmp108_last || !__tmp108_line.IsEmpty)
                    {
                        __out.Write(__tmp108_line);
                        __tmp106_outputWritten = true;
                    }
                    if (!__tmp108_last) __out.AppendLine(true);
                }
                string __tmp109_line = "))"; //188:99
                if (!string.IsNullOrEmpty(__tmp109_line))
                {
                    __out.Write(__tmp109_line);
                    __tmp106_outputWritten = true;
                }
                if (__tmp106_outputWritten) __out.AppendLine(true);
                if (__tmp106_outputWritten)
                {
                    __out.AppendLine(false); //188:101
                }
                __out.Write("                    {"); //189:1
                __out.AppendLine(false); //189:22
                __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //190:1
                __out.AppendLine(false); //190:71
                bool __tmp111_outputWritten = false;
                string __tmp110Prefix = "                        "; //191:1
                var __tmp112 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp112.Write(prop.FieldName);
                var __tmp112Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp112.ToStringAndFree());
                bool __tmp112_last = __tmp112Reader.EndOfStream;
                while(!__tmp112_last)
                {
                    ReadOnlySpan<char> __tmp112_line = __tmp112Reader.ReadLine();
                    __tmp112_last = __tmp112Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp110Prefix))
                    {
                        __out.Write(__tmp110Prefix);
                        __tmp111_outputWritten = true;
                    }
                    if (!__tmp112_last || !__tmp112_line.IsEmpty)
                    {
                        __out.Write(__tmp112_line);
                        __tmp111_outputWritten = true;
                    }
                    if (!__tmp112_last) __out.AppendLine(true);
                }
                string __tmp113_line = " = CompleteSymbolProperty_"; //191:41
                if (!string.IsNullOrEmpty(__tmp113_line))
                {
                    __out.Write(__tmp113_line);
                    __tmp111_outputWritten = true;
                }
                var __tmp114 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp114.Write(prop.Name);
                var __tmp114Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp114.ToStringAndFree());
                bool __tmp114_last = __tmp114Reader.EndOfStream;
                while(!__tmp114_last)
                {
                    ReadOnlySpan<char> __tmp114_line = __tmp114Reader.ReadLine();
                    __tmp114_last = __tmp114Reader.EndOfStream;
                    if (!__tmp114_last || !__tmp114_line.IsEmpty)
                    {
                        __out.Write(__tmp114_line);
                        __tmp111_outputWritten = true;
                    }
                    if (!__tmp114_last) __out.AppendLine(true);
                }
                string __tmp115_line = "(locationOpt, diagnostics, cancellationToken);"; //191:78
                if (!string.IsNullOrEmpty(__tmp115_line))
                {
                    __out.Write(__tmp115_line);
                    __tmp111_outputWritten = true;
                }
                if (__tmp111_outputWritten) __out.AppendLine(true);
                if (__tmp111_outputWritten)
                {
                    __out.AppendLine(false); //191:124
                }
                __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //192:1
                __out.AppendLine(false); //192:59
                __out.Write("                        diagnostics.Free();"); //193:1
                __out.AppendLine(false); //193:44
                bool __tmp117_outputWritten = false;
                string __tmp118_line = "                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_"; //194:1
                if (!string.IsNullOrEmpty(__tmp118_line))
                {
                    __out.Write(__tmp118_line);
                    __tmp117_outputWritten = true;
                }
                var __tmp119 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp119.Write(prop.Name);
                var __tmp119Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp119.ToStringAndFree());
                bool __tmp119_last = __tmp119Reader.EndOfStream;
                while(!__tmp119_last)
                {
                    ReadOnlySpan<char> __tmp119_line = __tmp119Reader.ReadLine();
                    __tmp119_last = __tmp119Reader.EndOfStream;
                    if (!__tmp119_last || !__tmp119_line.IsEmpty)
                    {
                        __out.Write(__tmp119_line);
                        __tmp117_outputWritten = true;
                    }
                    if (!__tmp119_last) __out.AppendLine(true);
                }
                string __tmp120_line = ");"; //194:100
                if (!string.IsNullOrEmpty(__tmp120_line))
                {
                    __out.Write(__tmp120_line);
                    __tmp117_outputWritten = true;
                }
                if (__tmp117_outputWritten) __out.AppendLine(true);
                if (__tmp117_outputWritten)
                {
                    __out.AppendLine(false); //194:102
                }
                __out.Write("                    }"); //195:1
                __out.AppendLine(false); //195:22
                __out.Write("                }"); //196:1
                __out.AppendLine(false); //196:18
            }
            __out.Write("                else if (incompletePart == CompletionGraph.StartComputingNonSymbolProperties || incompletePart == CompletionGraph.FinishComputingNonSymbolProperties)"); //198:1
            __out.AppendLine(false); //198:166
            __out.Write("                {"); //199:1
            __out.AppendLine(false); //199:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartComputingNonSymbolProperties))"); //200:1
            __out.AppendLine(false); //200:100
            __out.Write("                    {"); //201:1
            __out.AppendLine(false); //201:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //202:1
            __out.AppendLine(false); //202:71
            __out.Write("                        CompleteNonSymbolProperties(locationOpt, diagnostics, cancellationToken);"); //203:1
            __out.AppendLine(false); //203:98
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //204:1
            __out.AppendLine(false); //204:59
            __out.Write("                        diagnostics.Free();"); //205:1
            __out.AppendLine(false); //205:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishComputingNonSymbolProperties);"); //206:1
            __out.AppendLine(false); //206:101
            __out.Write("                    }"); //207:1
            __out.AppendLine(false); //207:22
            __out.Write("                }"); //208:1
            __out.AppendLine(false); //208:18
            __out.Write("                else if (incompletePart == CompletionGraph.ChildrenCompleted)"); //209:1
            __out.AppendLine(false); //209:78
            __out.Write("                {"); //210:1
            __out.AppendLine(false); //210:18
            __out.Write("                    var diagnostics = DiagnosticBag.GetInstance();"); //211:1
            __out.AppendLine(false); //211:67
            __out.Write("                    CompleteImports(locationOpt, diagnostics, cancellationToken);"); //212:1
            __out.AppendLine(false); //212:82
            __out.Write("                    AddSymbolDiagnostics(diagnostics);"); //213:1
            __out.AppendLine(false); //213:55
            __out.Write("                    diagnostics.Free();"); //214:1
            __out.AppendLine(false); //214:40
            __out.Write("                    bool allCompleted = true;"); //216:1
            __out.AppendLine(false); //216:46
            __out.Write("                    if (locationOpt == null)"); //217:1
            __out.AppendLine(false); //217:45
            __out.Write("                    {"); //218:1
            __out.AppendLine(false); //218:22
            __out.Write("                        foreach (var child in _childSymbols)"); //219:1
            __out.AppendLine(false); //219:61
            __out.Write("                        {"); //220:1
            __out.AppendLine(false); //220:26
            __out.Write("                            cancellationToken.ThrowIfCancellationRequested();"); //221:1
            __out.AppendLine(false); //221:78
            __out.Write("                            child.ForceComplete(null, locationOpt, cancellationToken);"); //222:1
            __out.AppendLine(false); //222:87
            __out.Write("                        }"); //223:1
            __out.AppendLine(false); //223:26
            __out.Write("                    }"); //224:1
            __out.AppendLine(false); //224:22
            __out.Write("                    else"); //225:1
            __out.AppendLine(false); //225:25
            __out.Write("                    {"); //226:1
            __out.AppendLine(false); //226:22
            __out.Write("                        foreach (var child in _childSymbols)"); //227:1
            __out.AppendLine(false); //227:61
            __out.Write("                        {"); //228:1
            __out.AppendLine(false); //228:26
            __out.Write("                            ForceCompleteChildByLocation(locationOpt, child, cancellationToken);"); //229:1
            __out.AppendLine(false); //229:97
            __out.Write("                            allCompleted = allCompleted && child.HasComplete(CompletionGraph.All);"); //230:1
            __out.AppendLine(false); //230:99
            __out.Write("                        }"); //231:1
            __out.AppendLine(false); //231:26
            __out.Write("                    }"); //232:1
            __out.AppendLine(false); //232:22
            __out.Write("                    if (!allCompleted)"); //234:1
            __out.AppendLine(false); //234:39
            __out.Write("                    {"); //235:1
            __out.AppendLine(false); //235:22
            __out.Write("                        // We did not complete all members, so just kick out now."); //236:1
            __out.AppendLine(false); //236:82
            __out.Write("                        var allParts = CompletionParts.AllWithLocation;"); //237:1
            __out.AppendLine(false); //237:72
            __out.Write("                        _state.SpinWaitComplete(allParts, cancellationToken);"); //238:1
            __out.AppendLine(false); //238:78
            __out.Write("                        return;"); //239:1
            __out.AppendLine(false); //239:32
            __out.Write("                    }"); //240:1
            __out.AppendLine(false); //240:22
            __out.Write("                    // We've completed all members, proceed to the next iteration."); //242:1
            __out.AppendLine(false); //242:83
            __out.Write("                    _state.NotePartComplete(CompletionGraph.ChildrenCompleted);"); //243:1
            __out.AppendLine(false); //243:80
            __out.Write("                }"); //244:1
            __out.AppendLine(false); //244:18
            __out.Write("                else if (incompletePart == null)"); //245:1
            __out.AppendLine(false); //245:49
            __out.Write("                {"); //246:1
            __out.AppendLine(false); //246:18
            __out.Write("                    return;"); //247:1
            __out.AppendLine(false); //247:28
            __out.Write("                }"); //248:1
            __out.AppendLine(false); //248:18
            __out.Write("                else"); //249:1
            __out.AppendLine(false); //249:21
            __out.Write("                {"); //250:1
            __out.AppendLine(false); //250:18
            __out.Write("                    // This assert will trigger if we forgot to handle any of the completion parts"); //251:1
            __out.AppendLine(false); //251:99
            __out.Write("                    Debug.Assert(!CompletionParts.All.Contains(incompletePart));"); //252:1
            __out.AppendLine(false); //252:81
            __out.Write("                    // any other values are completion parts intended for other kinds of symbols"); //253:1
            __out.AppendLine(false); //253:97
            __out.Write("                    _state.NotePartComplete(incompletePart);"); //254:1
            __out.AppendLine(false); //254:61
            __out.Write("                }"); //255:1
            __out.AppendLine(false); //255:18
            __out.Write("                if (completionPart != null && _state.HasComplete(completionPart)) return;"); //256:1
            __out.AppendLine(false); //256:90
            __out.Write("                _state.SpinWaitComplete(incompletePart, cancellationToken);"); //257:1
            __out.AppendLine(false); //257:76
            __out.Write("            }"); //258:1
            __out.AppendLine(false); //258:14
            __out.AppendLine(true); //259:1
            __out.Write("            throw ExceptionUtilities.Unreachable;"); //260:1
            __out.AppendLine(false); //260:50
            __out.Write("        }"); //261:1
            __out.AppendLine(false); //261:10
            __out.AppendLine(true); //262:1
            __out.Write("        protected abstract void CompleteInitializingSymbol(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //263:1
            __out.AppendLine(false); //263:152
            __out.Write("        protected abstract ImmutableArray<Symbol> CompleteCreatingChildSymbols(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //264:1
            __out.AppendLine(false); //264:172
            __out.Write("        protected abstract void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //265:1
            __out.AppendLine(false); //265:141
            __out.Write("        protected abstract string CompleteSymbolProperty_Name(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //266:1
            __out.AppendLine(false); //266:155
            var __loop8_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //267:16
                select new { prop = prop}
                ).ToList(); //267:10
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp121 = __loop8_results[__loop8_iteration];
                var prop = __tmp121.prop;
                bool __tmp123_outputWritten = false;
                string __tmp124_line = "        protected abstract "; //268:1
                if (!string.IsNullOrEmpty(__tmp124_line))
                {
                    __out.Write(__tmp124_line);
                    __tmp123_outputWritten = true;
                }
                var __tmp125 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp125.Write(prop.Type);
                var __tmp125Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp125.ToStringAndFree());
                bool __tmp125_last = __tmp125Reader.EndOfStream;
                while(!__tmp125_last)
                {
                    ReadOnlySpan<char> __tmp125_line = __tmp125Reader.ReadLine();
                    __tmp125_last = __tmp125Reader.EndOfStream;
                    if (!__tmp125_last || !__tmp125_line.IsEmpty)
                    {
                        __out.Write(__tmp125_line);
                        __tmp123_outputWritten = true;
                    }
                    if (!__tmp125_last) __out.AppendLine(true);
                }
                string __tmp126_line = " CompleteSymbolProperty_"; //268:39
                if (!string.IsNullOrEmpty(__tmp126_line))
                {
                    __out.Write(__tmp126_line);
                    __tmp123_outputWritten = true;
                }
                var __tmp127 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp127.Write(prop.Name);
                var __tmp127Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp127.ToStringAndFree());
                bool __tmp127_last = __tmp127Reader.EndOfStream;
                while(!__tmp127_last)
                {
                    ReadOnlySpan<char> __tmp127_line = __tmp127Reader.ReadLine();
                    __tmp127_last = __tmp127Reader.EndOfStream;
                    if (!__tmp127_last || !__tmp127_line.IsEmpty)
                    {
                        __out.Write(__tmp127_line);
                        __tmp123_outputWritten = true;
                    }
                    if (!__tmp127_last) __out.AppendLine(true);
                }
                string __tmp128_line = "(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"; //268:74
                if (!string.IsNullOrEmpty(__tmp128_line))
                {
                    __out.Write(__tmp128_line);
                    __tmp123_outputWritten = true;
                }
                if (__tmp123_outputWritten) __out.AppendLine(true);
                if (__tmp123_outputWritten)
                {
                    __out.AppendLine(false); //268:167
                }
            }
            __out.Write("        protected abstract void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //270:1
            __out.AppendLine(false); //270:153
            __out.Write("        #endregion"); //271:1
            __out.AppendLine(false); //271:19
            __out.AppendLine(true); //272:1
            __out.Write("    }"); //273:1
            __out.AppendLine(false); //273:6
            __out.Write("}"); //274:1
            __out.AppendLine(false); //274:2
            return __out.ToStringAndFree();
        }

        public string GenerateMetaSymbol(SymbolGenerationInfo symbol) //277:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //278:1
            __out.AppendLine(false); //278:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //279:1
            __out.AppendLine(false); //279:29
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //280:1
            __out.AppendLine(false); //280:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //281:1
            __out.AppendLine(false); //281:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //282:1
            __out.AppendLine(false); //282:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //283:1
            __out.AppendLine(false); //283:44
            __out.Write("using System;"); //284:1
            __out.AppendLine(false); //284:14
            __out.Write("using System.Collections.Generic;"); //285:1
            __out.AppendLine(false); //285:34
            __out.Write("using System.Collections.Immutable;"); //286:1
            __out.AppendLine(false); //286:36
            __out.Write("using System.Diagnostics;"); //287:1
            __out.AppendLine(false); //287:26
            __out.Write("using System.Text;"); //288:1
            __out.AppendLine(false); //288:19
            __out.Write("using System.Threading;"); //289:1
            __out.AppendLine(false); //289:24
            __out.AppendLine(true); //290:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //291:1
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
            string __tmp5_line = ".Metadata"; //291:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //291:42
            }
            __out.Write("{"); //292:1
            __out.AppendLine(false); //292:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Meta"; //293:1
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
            string __tmp10_line = " : "; //293:40
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
            string __tmp12_line = ".Model.Model"; //293:65
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
                __out.AppendLine(false); //293:90
            }
            __out.Write("	{"); //294:1
            __out.AppendLine(false); //294:3
            bool __tmp15_outputWritten = false;
            string __tmp16_line = "        public Meta"; //295:1
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
            string __tmp18_line = "(Symbol container, object modelObject)"; //295:33
            if (!string.IsNullOrEmpty(__tmp18_line))
            {
                __out.Write(__tmp18_line);
                __tmp15_outputWritten = true;
            }
            if (__tmp15_outputWritten) __out.AppendLine(true);
            if (__tmp15_outputWritten)
            {
                __out.AppendLine(false); //295:71
            }
            __out.Write("            : base(container, modelObject)"); //296:1
            __out.AppendLine(false); //296:43
            __out.Write("        {"); //297:1
            __out.AppendLine(false); //297:10
            if (symbol.OptionalModelObject) //298:14
            {
                __out.Write("            if (modelObject is null) throw new ArgumentNullException(nameof(modelObject));"); //299:1
                __out.AppendLine(false); //299:91
            }
            __out.Write("        }"); //301:1
            __out.AppendLine(false); //301:10
            __out.AppendLine(true); //302:1
            __out.Write("        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;"); //303:1
            __out.AppendLine(false); //303:95
            __out.AppendLine(true); //304:1
            __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;"); //305:1
            __out.AppendLine(false); //305:124
            __out.AppendLine(true); //306:1
            __out.Write("        protected override void CompleteInitializingSymbol(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //307:1
            __out.AppendLine(false); //307:151
            __out.Write("        {"); //308:1
            __out.AppendLine(false); //308:10
            __out.Write("        }"); //309:1
            __out.AppendLine(false); //309:10
            __out.AppendLine(true); //310:1
            __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //311:1
            __out.AppendLine(false); //311:171
            __out.Write("        {"); //312:1
            __out.AppendLine(false); //312:10
            __out.Write("            return ModelSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //313:1
            __out.AppendLine(false); //313:123
            __out.Write("        }"); //314:1
            __out.AppendLine(false); //314:10
            __out.AppendLine(true); //315:1
            __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //316:1
            __out.AppendLine(false); //316:140
            __out.Write("        {"); //317:1
            __out.AppendLine(false); //317:10
            __out.Write("        }"); //318:1
            __out.AppendLine(false); //318:10
            __out.AppendLine(true); //319:1
            __out.Write("        protected override string CompleteSymbolProperty_Name(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //320:1
            __out.AppendLine(false); //320:154
            __out.Write("        {"); //321:1
            __out.AppendLine(false); //321:10
            __out.Write("            return ModelSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //322:1
            __out.AppendLine(false); //322:132
            __out.Write("        }"); //323:1
            __out.AppendLine(false); //323:10
            __out.AppendLine(true); //324:1
            var __loop9_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //325:16
                select new { prop = prop}
                ).ToList(); //325:10
            for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
            {
                var __tmp19 = __loop9_results[__loop9_iteration];
                var prop = __tmp19.prop;
                bool __tmp21_outputWritten = false;
                string __tmp22_line = "        protected override "; //326:1
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
                string __tmp24_line = " CompleteSymbolProperty_"; //326:39
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
                string __tmp26_line = "(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"; //326:74
                if (!string.IsNullOrEmpty(__tmp26_line))
                {
                    __out.Write(__tmp26_line);
                    __tmp21_outputWritten = true;
                }
                if (__tmp21_outputWritten) __out.AppendLine(true);
                if (__tmp21_outputWritten)
                {
                    __out.AppendLine(false); //326:166
                }
                __out.Write("        {"); //327:1
                __out.AppendLine(false); //327:10
                if (prop.IsCollection) //328:14
                {
                    bool __tmp28_outputWritten = false;
                    string __tmp29_line = "            return ModelSymbolImplementation.AssignSymbolPropertyValues<"; //329:1
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
                    string __tmp31_line = ">(this, nameof("; //329:88
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
                    string __tmp33_line = "), diagnostics, cancellationToken);"; //329:114
                    if (!string.IsNullOrEmpty(__tmp33_line))
                    {
                        __out.Write(__tmp33_line);
                        __tmp28_outputWritten = true;
                    }
                    if (__tmp28_outputWritten) __out.AppendLine(true);
                    if (__tmp28_outputWritten)
                    {
                        __out.AppendLine(false); //329:149
                    }
                }
                else //330:14
                {
                    bool __tmp35_outputWritten = false;
                    string __tmp36_line = "            return ModelSymbolImplementation.AssignSymbolPropertyValue<"; //331:1
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
                    string __tmp38_line = ">(this, nameof("; //331:83
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
                    string __tmp40_line = "), diagnostics, cancellationToken);"; //331:109
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Write(__tmp40_line);
                        __tmp35_outputWritten = true;
                    }
                    if (__tmp35_outputWritten) __out.AppendLine(true);
                    if (__tmp35_outputWritten)
                    {
                        __out.AppendLine(false); //331:144
                    }
                }
                __out.Write("        }"); //333:1
                __out.AppendLine(false); //333:10
            }
            __out.AppendLine(true); //335:1
            __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //336:1
            __out.AppendLine(false); //336:152
            __out.Write("        {"); //337:1
            __out.AppendLine(false); //337:10
            __out.Write("        }"); //338:1
            __out.AppendLine(false); //338:10
            __out.Write("    }"); //339:1
            __out.AppendLine(false); //339:6
            __out.Write("}"); //340:1
            __out.AppendLine(false); //340:2
            return __out.ToStringAndFree();
        }

        public string GenerateSourceSymbol(SymbolGenerationInfo symbol) //343:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //344:1
            __out.AppendLine(false); //344:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //345:1
            __out.AppendLine(false); //345:29
            __out.Write("using MetaDslx.CodeAnalysis.Binding;"); //346:1
            __out.AppendLine(false); //346:37
            __out.Write("using MetaDslx.CodeAnalysis.Binding.Binders;"); //347:1
            __out.AppendLine(false); //347:45
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //348:1
            __out.AppendLine(false); //348:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //349:1
            __out.AppendLine(false); //349:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //350:1
            __out.AppendLine(false); //350:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //351:1
            __out.AppendLine(false); //351:44
            __out.Write("using System;"); //352:1
            __out.AppendLine(false); //352:14
            __out.Write("using System.Collections.Generic;"); //353:1
            __out.AppendLine(false); //353:34
            __out.Write("using System.Collections.Immutable;"); //354:1
            __out.AppendLine(false); //354:36
            __out.Write("using System.Diagnostics;"); //355:1
            __out.AppendLine(false); //355:26
            __out.Write("using System.Linq;"); //356:1
            __out.AppendLine(false); //356:19
            __out.Write("using System.Text;"); //357:1
            __out.AppendLine(false); //357:19
            __out.Write("using System.Threading;"); //358:1
            __out.AppendLine(false); //358:24
            __out.AppendLine(true); //359:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //360:1
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
            string __tmp5_line = ".Source"; //360:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //360:40
            }
            __out.Write("{"); //361:1
            __out.AppendLine(false); //361:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Source"; //362:1
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
            string __tmp10_line = " : "; //362:42
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
            string __tmp12_line = ".Model.Model"; //362:67
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
            string __tmp14_line = ", MetaDslx.CodeAnalysis.Symbols.Source.ISourceSymbol"; //362:92
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp7_outputWritten = true;
            }
            if (__tmp7_outputWritten) __out.AppendLine(true);
            if (__tmp7_outputWritten)
            {
                __out.AppendLine(false); //362:144
            }
            __out.Write("	{"); //363:1
            __out.AppendLine(false); //363:3
            __out.Write("        private readonly MergedDeclaration _declaration;"); //364:1
            __out.AppendLine(false); //364:57
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "		public Source"; //366:1
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
            string __tmp19_line = "(Symbol containingSymbol, object modelObject, MergedDeclaration declaration)"; //366:29
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Write(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //366:105
            }
            __out.Write("            : base(containingSymbol, modelObject)"); //367:1
            __out.AppendLine(false); //367:50
            __out.Write("        {"); //368:1
            __out.AppendLine(false); //368:10
            __out.Write("            Debug.Assert(declaration != null);"); //369:1
            __out.AppendLine(false); //369:47
            if (symbol.OptionalModelObject) //370:14
            {
                __out.Write("            if (modelObject is null) throw new ArgumentNullException(nameof(modelObject));"); //371:1
                __out.AppendLine(false); //371:91
            }
            __out.Write("            _declaration = declaration;"); //373:1
            __out.AppendLine(false); //373:40
            __out.Write("		}"); //374:1
            __out.AppendLine(false); //374:4
            __out.AppendLine(true); //375:1
            __out.Write("        public MergedDeclaration MergedDeclaration => _declaration;"); //376:1
            __out.AppendLine(false); //376:68
            __out.AppendLine(true); //377:1
            __out.Write("        public override ImmutableArray<Location> Locations => _declaration.NameLocations;"); //378:1
            __out.AppendLine(false); //378:90
            __out.AppendLine(true); //379:1
            __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration.SyntaxReferences;"); //380:1
            __out.AppendLine(false); //380:116
            __out.AppendLine(true); //381:1
            __out.Write("        public BinderPosition<SymbolBinder> GetBinder(SyntaxReference reference)"); //382:1
            __out.AppendLine(false); //382:81
            __out.Write("        {"); //383:1
            __out.AppendLine(false); //383:10
            __out.Write("            Debug.Assert(this.DeclaringSyntaxReferences.Contains(reference));"); //384:1
            __out.AppendLine(false); //384:78
            __out.Write("            return FindBinders.FindSymbolBinder(this, reference);"); //385:1
            __out.AppendLine(false); //385:66
            __out.Write("        }"); //386:1
            __out.AppendLine(false); //386:10
            __out.AppendLine(true); //387:1
            __out.Write("        public Symbol GetChildSymbol(SyntaxReference syntax)"); //388:1
            __out.AppendLine(false); //388:61
            __out.Write("        {"); //389:1
            __out.AppendLine(false); //389:10
            __out.Write("            foreach (var child in this.ChildSymbols)"); //390:1
            __out.AppendLine(false); //390:53
            __out.Write("            {"); //391:1
            __out.AppendLine(false); //391:14
            __out.Write("                if (child.DeclaringSyntaxReferences.Any(sr => sr.GetLocation() == syntax.GetLocation()))"); //392:1
            __out.AppendLine(false); //392:105
            __out.Write("                {"); //393:1
            __out.AppendLine(false); //393:18
            __out.Write("                    return child;"); //394:1
            __out.AppendLine(false); //394:34
            __out.Write("                }"); //395:1
            __out.AppendLine(false); //395:18
            __out.Write("            }"); //396:1
            __out.AppendLine(false); //396:14
            __out.Write("            return null;"); //397:1
            __out.AppendLine(false); //397:25
            __out.Write("        }"); //398:1
            __out.AppendLine(false); //398:10
            __out.AppendLine(true); //399:1
            __out.Write("        protected override void CompleteInitializingSymbol(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //400:1
            __out.AppendLine(false); //400:151
            __out.Write("        {"); //401:1
            __out.AppendLine(false); //401:10
            __out.Write("        }"); //402:1
            __out.AppendLine(false); //402:10
            __out.AppendLine(true); //403:1
            __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //404:1
            __out.AppendLine(false); //404:171
            __out.Write("        {"); //405:1
            __out.AppendLine(false); //405:10
            __out.Write("            return SourceSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //406:1
            __out.AppendLine(false); //406:124
            __out.Write("        }"); //407:1
            __out.AppendLine(false); //407:10
            __out.AppendLine(true); //408:1
            __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //409:1
            __out.AppendLine(false); //409:140
            __out.Write("        {"); //410:1
            __out.AppendLine(false); //410:10
            __out.Write("            SourceSymbolImplementation.CompleteImports(this, locationOpt, diagnostics, cancellationToken);"); //411:1
            __out.AppendLine(false); //411:107
            __out.Write("        }"); //412:1
            __out.AppendLine(false); //412:10
            __out.AppendLine(true); //413:1
            __out.Write("        protected override string CompleteSymbolProperty_Name(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //414:1
            __out.AppendLine(false); //414:154
            __out.Write("        {"); //415:1
            __out.AppendLine(false); //415:10
            __out.Write("            return SourceSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //416:1
            __out.AppendLine(false); //416:133
            __out.Write("        }"); //417:1
            __out.AppendLine(false); //417:10
            __out.AppendLine(true); //418:1
            var __loop10_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //419:16
                select new { prop = prop}
                ).ToList(); //419:10
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                var __tmp20 = __loop10_results[__loop10_iteration];
                var prop = __tmp20.prop;
                bool __tmp22_outputWritten = false;
                string __tmp23_line = "        protected override "; //420:1
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
                string __tmp25_line = " CompleteSymbolProperty_"; //420:39
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
                string __tmp27_line = "(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"; //420:74
                if (!string.IsNullOrEmpty(__tmp27_line))
                {
                    __out.Write(__tmp27_line);
                    __tmp22_outputWritten = true;
                }
                if (__tmp22_outputWritten) __out.AppendLine(true);
                if (__tmp22_outputWritten)
                {
                    __out.AppendLine(false); //420:166
                }
                __out.Write("        {"); //421:1
                __out.AppendLine(false); //421:10
                if (prop.IsCollection) //422:14
                {
                    bool __tmp29_outputWritten = false;
                    string __tmp30_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValues<"; //423:1
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
                    string __tmp32_line = ">(this, nameof("; //423:89
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
                    string __tmp34_line = "), diagnostics, cancellationToken);"; //423:115
                    if (!string.IsNullOrEmpty(__tmp34_line))
                    {
                        __out.Write(__tmp34_line);
                        __tmp29_outputWritten = true;
                    }
                    if (__tmp29_outputWritten) __out.AppendLine(true);
                    if (__tmp29_outputWritten)
                    {
                        __out.AppendLine(false); //423:150
                    }
                }
                else //424:14
                {
                    bool __tmp36_outputWritten = false;
                    string __tmp37_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValue<"; //425:1
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
                    string __tmp39_line = ">(this, nameof("; //425:84
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
                    string __tmp41_line = "), diagnostics, cancellationToken);"; //425:110
                    if (!string.IsNullOrEmpty(__tmp41_line))
                    {
                        __out.Write(__tmp41_line);
                        __tmp36_outputWritten = true;
                    }
                    if (__tmp36_outputWritten) __out.AppendLine(true);
                    if (__tmp36_outputWritten)
                    {
                        __out.AppendLine(false); //425:145
                    }
                }
                __out.Write("        }"); //427:1
                __out.AppendLine(false); //427:10
            }
            __out.AppendLine(true); //429:1
            __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //430:1
            __out.AppendLine(false); //430:152
            __out.Write("        {"); //431:1
            __out.AppendLine(false); //431:10
            __out.Write("            SourceSymbolImplementation.AssignNonSymbolProperties(this, diagnostics, cancellationToken);"); //432:1
            __out.AppendLine(false); //432:104
            __out.Write("        }"); //433:1
            __out.AppendLine(false); //433:10
            __out.AppendLine(true); //434:1
            __out.Write("	}"); //435:1
            __out.AppendLine(false); //435:3
            __out.Write("}"); //436:1
            __out.AppendLine(false); //436:2
            return __out.ToStringAndFree();
        }

        public string GenerateVisitor(string namespaceName, IEnumerable<SymbolGenerationInfo> symbols) //439:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //440:1
            __out.AppendLine(false); //440:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //441:1
            __out.AppendLine(false); //441:29
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //442:1
            __out.AppendLine(false); //442:37
            __out.Write("using System;"); //443:1
            __out.AppendLine(false); //443:14
            __out.Write("using System.Collections.Generic;"); //444:1
            __out.AppendLine(false); //444:34
            __out.Write("using System.Collections.Immutable;"); //445:1
            __out.AppendLine(false); //445:36
            __out.Write("using System.Diagnostics;"); //446:1
            __out.AppendLine(false); //446:26
            __out.Write("using System.Text;"); //447:1
            __out.AppendLine(false); //447:19
            __out.Write("using System.Threading;"); //448:1
            __out.AppendLine(false); //448:24
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //450:1
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
                __out.AppendLine(false); //450:26
            }
            __out.Write("{"); //451:1
            __out.AppendLine(false); //451:2
            __out.Write("	public interface ISymbolVisitor"); //452:1
            __out.AppendLine(false); //452:33
            __out.Write("	{"); //453:1
            __out.AppendLine(false); //453:3
            var __loop11_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //454:16
                select new { symbol = symbol}
                ).ToList(); //454:10
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp5 = __loop11_results[__loop11_iteration];
                var symbol = __tmp5.symbol;
                bool __tmp7_outputWritten = false;
                string __tmp8_line = "        void Visit("; //455:1
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
                string __tmp10_line = " symbol);"; //455:33
                if (!string.IsNullOrEmpty(__tmp10_line))
                {
                    __out.Write(__tmp10_line);
                    __tmp7_outputWritten = true;
                }
                if (__tmp7_outputWritten) __out.AppendLine(true);
                if (__tmp7_outputWritten)
                {
                    __out.AppendLine(false); //455:42
                }
            }
            __out.Write("	}"); //457:1
            __out.AppendLine(false); //457:3
            __out.AppendLine(true); //458:1
            __out.Write("	public interface ISymbolVisitor<TResult>"); //459:1
            __out.AppendLine(false); //459:42
            __out.Write("	{"); //460:1
            __out.AppendLine(false); //460:3
            var __loop12_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //461:16
                select new { symbol = symbol}
                ).ToList(); //461:10
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp11 = __loop12_results[__loop12_iteration];
                var symbol = __tmp11.symbol;
                bool __tmp13_outputWritten = false;
                string __tmp14_line = "        TResult Visit("; //462:1
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
                string __tmp16_line = " symbol);"; //462:36
                if (!string.IsNullOrEmpty(__tmp16_line))
                {
                    __out.Write(__tmp16_line);
                    __tmp13_outputWritten = true;
                }
                if (__tmp13_outputWritten) __out.AppendLine(true);
                if (__tmp13_outputWritten)
                {
                    __out.AppendLine(false); //462:45
                }
            }
            __out.Write("	}"); //464:1
            __out.AppendLine(false); //464:3
            __out.AppendLine(true); //465:1
            __out.Write("	public interface ISymbolVisitor<TArgument, TResult>"); //466:1
            __out.AppendLine(false); //466:53
            __out.Write("	{"); //467:1
            __out.AppendLine(false); //467:3
            var __loop13_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //468:16
                select new { symbol = symbol}
                ).ToList(); //468:10
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp17 = __loop13_results[__loop13_iteration];
                var symbol = __tmp17.symbol;
                bool __tmp19_outputWritten = false;
                string __tmp20_line = "        TResult Visit("; //469:1
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
                string __tmp22_line = " symbol, TArgument argument);"; //469:36
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Write(__tmp22_line);
                    __tmp19_outputWritten = true;
                }
                if (__tmp19_outputWritten) __out.AppendLine(true);
                if (__tmp19_outputWritten)
                {
                    __out.AppendLine(false); //469:65
                }
            }
            __out.Write("	}"); //471:1
            __out.AppendLine(false); //471:3
            __out.Write("}"); //472:1
            __out.AppendLine(false); //472:2
            return __out.ToStringAndFree();
        }

    }
}

