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
                bool __tmp10_outputWritten = false;
                string __tmp11_line = "        public sealed override "; //23:1
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
                string __tmp13_line = " "; //23:55
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
                string __tmp15_line = " => "; //23:79
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
                string __tmp17_line = "."; //23:106
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
                string __tmp19_line = ";"; //23:126
                if (!string.IsNullOrEmpty(__tmp19_line))
                {
                    __out.Write(__tmp19_line);
                    __tmp10_outputWritten = true;
                }
                if (__tmp10_outputWritten) __out.AppendLine(true);
                if (__tmp10_outputWritten)
                {
                    __out.AppendLine(false); //23:127
                }
            }
            __out.AppendLine(true); //25:1
            if (symbol.SubSymbolKindType != null) //26:10
            {
                bool __tmp21_outputWritten = false;
                string __tmp22_line = "        public virtual "; //27:1
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
                string __tmp24_line = " "; //27:50
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
                string __tmp26_line = " => "; //27:77
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
                string __tmp28_line = ".None;"; //27:107
                if (!string.IsNullOrEmpty(__tmp28_line))
                {
                    __out.Write(__tmp28_line);
                    __tmp21_outputWritten = true;
                }
                if (__tmp21_outputWritten) __out.AppendLine(true);
                if (__tmp21_outputWritten)
                {
                    __out.AppendLine(false); //27:113
                }
            }
            __out.AppendLine(true); //29:1
            __out.Write("        public "); //30:1
            if (symbol.IsSymbolClass) //30:17
            {
                __out.Write("virtual"); //30:43
            }
            else //30:51
            {
                __out.Write("override"); //30:56
            }
            __out.Write(" void Accept(MetaDslx.CodeAnalysis.Symbols.SymbolVisitor visitor)"); //30:72
            __out.AppendLine(false); //30:137
            __out.Write("        {"); //31:1
            __out.AppendLine(false); //31:10
            __out.Write("            if (visitor is ISymbolVisitor isv) isv.Visit(this);"); //32:1
            __out.AppendLine(false); //32:64
            __out.Write("        }"); //33:1
            __out.AppendLine(false); //33:10
            __out.AppendLine(true); //34:1
            __out.Write("        public "); //35:1
            if (symbol.IsSymbolClass) //35:17
            {
                __out.Write("virtual"); //35:43
            }
            else //35:51
            {
                __out.Write("override"); //35:56
            }
            __out.Write(" TResult Accept<TResult>(MetaDslx.CodeAnalysis.Symbols.SymbolVisitor<TResult> visitor)"); //35:72
            __out.AppendLine(false); //35:158
            __out.Write("        {"); //36:1
            __out.AppendLine(false); //36:10
            __out.Write("            if (visitor is ISymbolVisitor<TResult> isv) return isv.Visit(this);"); //37:1
            __out.AppendLine(false); //37:80
            __out.Write("            else return default(TResult);"); //38:1
            __out.AppendLine(false); //38:42
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
            __out.Write(" TResult Accept<TArgument, TResult>(MetaDslx.CodeAnalysis.Symbols.SymbolVisitor<TArgument, TResult> visitor, TArgument argument)"); //41:72
            __out.AppendLine(false); //41:200
            __out.Write("        {"); //42:1
            __out.AppendLine(false); //42:10
            __out.Write("            if (visitor is ISymbolVisitor<TArgument, TResult> isv) return isv.Visit(this, argument);"); //43:1
            __out.AppendLine(false); //43:101
            __out.Write("            else return default(TResult);"); //44:1
            __out.AppendLine(false); //44:42
            __out.Write("        }"); //45:1
            __out.AppendLine(false); //45:10
            __out.AppendLine(true); //46:1
            __out.Write("        protected override ISymbol CreateISymbol()"); //47:1
            __out.AppendLine(false); //47:51
            __out.Write("        {"); //48:1
            __out.AppendLine(false); //48:10
            __out.Write("            throw new NotImplementedException();"); //49:1
            __out.AppendLine(false); //49:49
            __out.Write("        }"); //50:1
            __out.AppendLine(false); //50:10
            __out.Write("	}"); //51:1
            __out.AppendLine(false); //51:3
            __out.Write("}"); //52:1
            __out.AppendLine(false); //52:2
            return __out.ToStringAndFree();
        }

        public string GenerateModelSymbol(SymbolGenerationInfo symbol) //55:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //56:1
            __out.AppendLine(false); //56:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //57:1
            __out.AppendLine(false); //57:29
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //58:1
            __out.AppendLine(false); //58:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //59:1
            __out.AppendLine(false); //59:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //60:1
            __out.AppendLine(false); //60:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //61:1
            __out.AppendLine(false); //61:44
            __out.Write("using System;"); //62:1
            __out.AppendLine(false); //62:14
            __out.Write("using System.Collections.Generic;"); //63:1
            __out.AppendLine(false); //63:34
            __out.Write("using System.Collections.Immutable;"); //64:1
            __out.AppendLine(false); //64:36
            __out.Write("using System.Diagnostics;"); //65:1
            __out.AppendLine(false); //65:26
            __out.Write("using System.Text;"); //66:1
            __out.AppendLine(false); //66:19
            __out.Write("using System.Threading;"); //67:1
            __out.AppendLine(false); //67:24
            __out.Write("using Roslyn.Utilities;"); //68:1
            __out.AppendLine(false); //68:24
            __out.AppendLine(true); //69:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //70:1
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
            string __tmp5_line = ".Model"; //70:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //70:39
            }
            __out.Write("{"); //71:1
            __out.AppendLine(false); //71:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public abstract partial class Model"; //72:1
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
            string __tmp10_line = " : "; //72:50
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
            string __tmp12_line = "."; //72:75
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
            string __tmp14_line = ", MetaDslx.CodeAnalysis.Symbols.Metadata.IModelSymbol"; //72:89
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp7_outputWritten = true;
            }
            if (__tmp7_outputWritten) __out.AppendLine(true);
            if (__tmp7_outputWritten)
            {
                __out.AppendLine(false); //72:142
            }
            __out.Write("	{"); //73:1
            __out.AppendLine(false); //73:3
            __out.Write("        public static class CompletionParts"); //74:1
            __out.AppendLine(false); //74:44
            __out.Write("        {"); //75:1
            __out.AppendLine(false); //75:10
            var __loop1_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //76:20
                select new { prop = prop}
                ).ToList(); //76:14
            for (int __loop1_iteration = 0; __loop1_iteration < __loop1_results.Count; ++__loop1_iteration)
            {
                var __tmp15 = __loop1_results[__loop1_iteration];
                var prop = __tmp15.prop;
                bool __tmp17_outputWritten = false;
                string __tmp18_line = "            public static readonly CompletionPart StartComputingProperty_"; //77:1
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
                string __tmp20_line = " = new CompletionPart(nameof(StartComputingProperty_"; //77:85
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
                string __tmp22_line = "));"; //77:148
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Write(__tmp22_line);
                    __tmp17_outputWritten = true;
                }
                if (__tmp17_outputWritten) __out.AppendLine(true);
                if (__tmp17_outputWritten)
                {
                    __out.AppendLine(false); //77:151
                }
                bool __tmp24_outputWritten = false;
                string __tmp25_line = "            public static readonly CompletionPart FinishComputingProperty_"; //78:1
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
                string __tmp27_line = " = new CompletionPart(nameof(FinishComputingProperty_"; //78:86
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
                string __tmp29_line = "));"; //78:150
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Write(__tmp29_line);
                    __tmp24_outputWritten = true;
                }
                if (__tmp24_outputWritten) __out.AppendLine(true);
                if (__tmp24_outputWritten)
                {
                    __out.AppendLine(false); //78:153
                }
            }
            bool __tmp31_outputWritten = false;
            string __tmp32_line = "            public static readonly ImmutableHashSet<CompletionPart> AllWithLocation = CompletionPart.Combine(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren"; //80:1
            if (!string.IsNullOrEmpty(__tmp32_line))
            {
                __out.Write(__tmp32_line);
                __tmp31_outputWritten = true;
            }
            var __loop2_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //80:265
                select new { prop = prop}
                ).ToList(); //80:259
            for (int __loop2_iteration = 0; __loop2_iteration < __loop2_results.Count; ++__loop2_iteration)
            {
                var __tmp34 = __loop2_results[__loop2_iteration];
                var prop = __tmp34.prop;
                string __tmp35_line = ", StartComputingProperty_"; //80:289
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
                string __tmp37_line = ", FinishComputingProperty_"; //80:325
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
            string __tmp40_line = ", CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties);"; //80:372
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Write(__tmp40_line);
                __tmp31_outputWritten = true;
            }
            if (__tmp31_outputWritten) __out.AppendLine(true);
            if (__tmp31_outputWritten)
            {
                __out.AppendLine(false); //80:477
            }
            bool __tmp42_outputWritten = false;
            string __tmp43_line = "            public static readonly ImmutableHashSet<CompletionPart> All = CompletionPart.Combine(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren"; //81:1
            if (!string.IsNullOrEmpty(__tmp43_line))
            {
                __out.Write(__tmp43_line);
                __tmp42_outputWritten = true;
            }
            var __loop3_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //81:253
                select new { prop = prop}
                ).ToList(); //81:247
            for (int __loop3_iteration = 0; __loop3_iteration < __loop3_results.Count; ++__loop3_iteration)
            {
                var __tmp45 = __loop3_results[__loop3_iteration];
                var prop = __tmp45.prop;
                string __tmp46_line = ", StartComputingProperty_"; //81:277
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
                string __tmp48_line = ", FinishComputingProperty_"; //81:313
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
            string __tmp51_line = ", CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties, CompletionGraph.ChildrenCompleted);"; //81:360
            if (!string.IsNullOrEmpty(__tmp51_line))
            {
                __out.Write(__tmp51_line);
                __tmp42_outputWritten = true;
            }
            if (__tmp42_outputWritten) __out.AppendLine(true);
            if (__tmp42_outputWritten)
            {
                __out.AppendLine(false); //81:500
            }
            bool __tmp53_outputWritten = false;
            string __tmp54_line = "            public static readonly CompletionGraph CompletionGraph = CompletionGraph.FromCompletionParts(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren"; //82:1
            if (!string.IsNullOrEmpty(__tmp54_line))
            {
                __out.Write(__tmp54_line);
                __tmp53_outputWritten = true;
            }
            var __loop4_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //82:261
                select new { prop = prop}
                ).ToList(); //82:255
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                var __tmp56 = __loop4_results[__loop4_iteration];
                var prop = __tmp56.prop;
                string __tmp57_line = ", StartComputingProperty_"; //82:285
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
                string __tmp59_line = ", FinishComputingProperty_"; //82:321
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
            string __tmp62_line = ", CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties, CompletionGraph.ChildrenCompleted);"; //82:368
            if (!string.IsNullOrEmpty(__tmp62_line))
            {
                __out.Write(__tmp62_line);
                __tmp53_outputWritten = true;
            }
            if (__tmp53_outputWritten) __out.AppendLine(true);
            if (__tmp53_outputWritten)
            {
                __out.AppendLine(false); //82:508
            }
            __out.Write("        }"); //83:1
            __out.AppendLine(false); //83:10
            __out.AppendLine(true); //84:1
            __out.Write("        private readonly Symbol _container;"); //85:1
            __out.AppendLine(false); //85:44
            __out.Write("        private readonly object _modelObject;"); //86:1
            __out.AppendLine(false); //86:46
            __out.Write("        private readonly CompletionState _state;"); //87:1
            __out.AppendLine(false); //87:49
            __out.Write("        private ImmutableArray<Symbol> _childSymbols;"); //88:1
            __out.AppendLine(false); //88:54
            var __loop5_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //89:16
                select new { prop = prop}
                ).ToList(); //89:10
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                var __tmp63 = __loop5_results[__loop5_iteration];
                var prop = __tmp63.prop;
                bool __tmp65_outputWritten = false;
                string __tmp66_line = "        private "; //90:1
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
                string __tmp68_line = " "; //90:28
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
                string __tmp70_line = ";"; //90:45
                if (!string.IsNullOrEmpty(__tmp70_line))
                {
                    __out.Write(__tmp70_line);
                    __tmp65_outputWritten = true;
                }
                if (__tmp65_outputWritten) __out.AppendLine(true);
                if (__tmp65_outputWritten)
                {
                    __out.AppendLine(false); //90:46
                }
            }
            __out.AppendLine(true); //92:1
            bool __tmp72_outputWritten = false;
            string __tmp73_line = "        public Model"; //93:1
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
            string __tmp75_line = "(Symbol container, object modelObject)"; //93:34
            if (!string.IsNullOrEmpty(__tmp75_line))
            {
                __out.Write(__tmp75_line);
                __tmp72_outputWritten = true;
            }
            if (__tmp72_outputWritten) __out.AppendLine(true);
            if (__tmp72_outputWritten)
            {
                __out.AppendLine(false); //93:72
            }
            __out.Write("        {"); //94:1
            __out.AppendLine(false); //94:10
            __out.Write("            Debug.Assert(container is IModelSymbol);"); //95:1
            __out.AppendLine(false); //95:53
            __out.Write("            if (modelObject == null) throw new ArgumentNullException(nameof(modelObject));"); //96:1
            __out.AppendLine(false); //96:91
            __out.Write("            _container = container;"); //97:1
            __out.AppendLine(false); //97:36
            __out.Write("            _modelObject = modelObject;"); //98:1
            __out.AppendLine(false); //98:40
            __out.Write("            _state = CompletionParts.CompletionGraph.CreateState();"); //99:1
            __out.AppendLine(false); //99:68
            __out.Write("        }"); //100:1
            __out.AppendLine(false); //100:10
            __out.AppendLine(true); //101:1
            __out.Write("        public sealed override Language Language => ContainingModule.Language;"); //102:1
            __out.AppendLine(false); //102:79
            __out.AppendLine(true); //103:1
            __out.Write("        public SymbolFactory SymbolFactory => ((IModelSymbol)_container).SymbolFactory;"); //104:1
            __out.AppendLine(false); //104:88
            __out.AppendLine(true); //105:1
            __out.Write("        public object ModelObject => _modelObject;"); //106:1
            __out.AppendLine(false); //106:51
            __out.AppendLine(true); //107:1
            __out.Write("        public Type ModelObjectType => _modelObject != null ? Language.SymbolFacts.GetModelObjectType(_modelObject) : null;"); //108:1
            __out.AppendLine(false); //108:124
            __out.AppendLine(true); //109:1
            __out.Write("        public sealed override string Name => _modelObject != null ? Language.SymbolFacts.GetName(_modelObject) : string.Empty;"); //110:1
            __out.AppendLine(false); //110:128
            __out.AppendLine(true); //111:1
            __out.Write("        public sealed override Symbol ContainingSymbol => _container;"); //112:1
            __out.AppendLine(false); //112:70
            __out.AppendLine(true); //113:1
            __out.Write("        public sealed override ImmutableArray<Symbol> ChildSymbols "); //114:1
            __out.AppendLine(false); //114:68
            __out.Write("        {"); //115:1
            __out.AppendLine(false); //115:10
            __out.Write("            get"); //116:1
            __out.AppendLine(false); //116:16
            __out.Write("            {"); //117:1
            __out.AppendLine(false); //117:14
            __out.Write("                this.ForceComplete(CompletionGraph.FinishCreatingChildren, null, default);"); //118:1
            __out.AppendLine(false); //118:91
            __out.Write("                return _childSymbols;"); //119:1
            __out.AppendLine(false); //119:38
            __out.Write("            }"); //120:1
            __out.AppendLine(false); //120:14
            __out.Write("        }"); //121:1
            __out.AppendLine(false); //121:10
            __out.AppendLine(true); //122:1
            var __loop6_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //123:16
                select new { prop = prop}
                ).ToList(); //123:10
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp76 = __loop6_results[__loop6_iteration];
                var prop = __tmp76.prop;
                bool __tmp78_outputWritten = false;
                string __tmp79_line = "        public override "; //124:1
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
                string __tmp81_line = " "; //124:36
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
                    __out.AppendLine(false); //124:48
                }
                __out.Write("        {"); //125:1
                __out.AppendLine(false); //125:10
                __out.Write("            get"); //126:1
                __out.AppendLine(false); //126:16
                __out.Write("            {"); //127:1
                __out.AppendLine(false); //127:14
                bool __tmp84_outputWritten = false;
                string __tmp85_line = "                this.ForceComplete(CompletionParts.FinishComputingProperty_"; //128:1
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
                string __tmp87_line = ", null, default);"; //128:87
                if (!string.IsNullOrEmpty(__tmp87_line))
                {
                    __out.Write(__tmp87_line);
                    __tmp84_outputWritten = true;
                }
                if (__tmp84_outputWritten) __out.AppendLine(true);
                if (__tmp84_outputWritten)
                {
                    __out.AppendLine(false); //128:104
                }
                bool __tmp89_outputWritten = false;
                string __tmp90_line = "                return "; //129:1
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
                string __tmp92_line = ";"; //129:40
                if (!string.IsNullOrEmpty(__tmp92_line))
                {
                    __out.Write(__tmp92_line);
                    __tmp89_outputWritten = true;
                }
                if (__tmp89_outputWritten) __out.AppendLine(true);
                if (__tmp89_outputWritten)
                {
                    __out.AppendLine(false); //129:41
                }
                __out.Write("            }"); //130:1
                __out.AppendLine(false); //130:14
                __out.Write("        }"); //131:1
                __out.AppendLine(false); //131:10
            }
            __out.AppendLine(true); //133:1
            __out.Write("        #region Completion"); //134:1
            __out.AppendLine(false); //134:27
            __out.AppendLine(true); //135:1
            __out.Write("        public sealed override bool RequiresCompletion => true;"); //136:1
            __out.AppendLine(false); //136:64
            __out.AppendLine(true); //137:1
            __out.Write("        public sealed override bool HasComplete(CompletionPart part)"); //138:1
            __out.AppendLine(false); //138:69
            __out.Write("        {"); //139:1
            __out.AppendLine(false); //139:10
            __out.Write("            return _state.HasComplete(part);"); //140:1
            __out.AppendLine(false); //140:45
            __out.Write("        }"); //141:1
            __out.AppendLine(false); //141:10
            __out.AppendLine(true); //142:1
            __out.Write("        public override void ForceComplete(CompletionPart completionPart, SourceLocation locationOpt, CancellationToken cancellationToken)"); //143:1
            __out.AppendLine(false); //143:139
            __out.Write("        {"); //144:1
            __out.AppendLine(false); //144:10
            __out.Write("            if (completionPart != null && _state.HasComplete(completionPart)) return;"); //145:1
            __out.AppendLine(false); //145:86
            __out.Write("            if (completionPart != null && !CompletionParts.All.Contains(completionPart)) throw new ArgumentException(nameof(completionPart));"); //146:1
            __out.AppendLine(false); //146:142
            __out.Write("            while (true)"); //147:1
            __out.AppendLine(false); //147:25
            __out.Write("            {"); //148:1
            __out.AppendLine(false); //148:14
            __out.Write("                cancellationToken.ThrowIfCancellationRequested();"); //149:1
            __out.AppendLine(false); //149:66
            __out.Write("                var incompletePart = _state.NextIncompletePart;"); //150:1
            __out.AppendLine(false); //150:64
            __out.Write("                if (incompletePart == CompletionGraph.StartInitializing || incompletePart == CompletionGraph.FinishInitializing)"); //151:1
            __out.AppendLine(false); //151:129
            __out.Write("                {"); //152:1
            __out.AppendLine(false); //152:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartInitializing))"); //153:1
            __out.AppendLine(false); //153:84
            __out.Write("                    {"); //154:1
            __out.AppendLine(false); //154:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //155:1
            __out.AppendLine(false); //155:71
            __out.Write("                        CompleteInitializingSymbol(locationOpt, diagnostics, cancellationToken);"); //156:1
            __out.AppendLine(false); //156:97
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //157:1
            __out.AppendLine(false); //157:59
            __out.Write("                        diagnostics.Free();"); //158:1
            __out.AppendLine(false); //158:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishInitializing);"); //159:1
            __out.AppendLine(false); //159:85
            __out.Write("                    }"); //160:1
            __out.AppendLine(false); //160:22
            __out.Write("                }"); //161:1
            __out.AppendLine(false); //161:18
            __out.Write("                else if (incompletePart == CompletionGraph.StartCreatingChildren || incompletePart == CompletionGraph.FinishCreatingChildren)"); //162:1
            __out.AppendLine(false); //162:142
            __out.Write("                {"); //163:1
            __out.AppendLine(false); //163:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartCreatingChildren))"); //164:1
            __out.AppendLine(false); //164:88
            __out.Write("                    {"); //165:1
            __out.AppendLine(false); //165:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //166:1
            __out.AppendLine(false); //166:71
            __out.Write("                        _childSymbols = CompleteCreatingChildSymbols(locationOpt, diagnostics, cancellationToken);"); //167:1
            __out.AppendLine(false); //167:115
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //168:1
            __out.AppendLine(false); //168:59
            __out.Write("                        diagnostics.Free();"); //169:1
            __out.AppendLine(false); //169:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishCreatingChildren);"); //170:1
            __out.AppendLine(false); //170:89
            __out.Write("                    }"); //171:1
            __out.AppendLine(false); //171:22
            __out.Write("                }"); //172:1
            __out.AppendLine(false); //172:18
            var __loop7_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //173:24
                select new { prop = prop}
                ).ToList(); //173:18
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                var __tmp93 = __loop7_results[__loop7_iteration];
                var prop = __tmp93.prop;
                bool __tmp95_outputWritten = false;
                string __tmp96_line = "                else if (incompletePart == CompletionParts.StartComputingProperty_"; //174:1
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
                string __tmp98_line = " || incompletePart == CompletionParts.FinishComputingProperty_"; //174:94
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
                string __tmp100_line = ")"; //174:167
                if (!string.IsNullOrEmpty(__tmp100_line))
                {
                    __out.Write(__tmp100_line);
                    __tmp95_outputWritten = true;
                }
                if (__tmp95_outputWritten) __out.AppendLine(true);
                if (__tmp95_outputWritten)
                {
                    __out.AppendLine(false); //174:168
                }
                __out.Write("                {"); //175:1
                __out.AppendLine(false); //175:18
                bool __tmp102_outputWritten = false;
                string __tmp103_line = "                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_"; //176:1
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
                string __tmp105_line = "))"; //176:99
                if (!string.IsNullOrEmpty(__tmp105_line))
                {
                    __out.Write(__tmp105_line);
                    __tmp102_outputWritten = true;
                }
                if (__tmp102_outputWritten) __out.AppendLine(true);
                if (__tmp102_outputWritten)
                {
                    __out.AppendLine(false); //176:101
                }
                __out.Write("                    {"); //177:1
                __out.AppendLine(false); //177:22
                __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //178:1
                __out.AppendLine(false); //178:71
                bool __tmp107_outputWritten = false;
                string __tmp106Prefix = "                        "; //179:1
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
                string __tmp109_line = " = CompleteSymbolProperty_"; //179:41
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
                string __tmp111_line = "(locationOpt, diagnostics, cancellationToken);"; //179:78
                if (!string.IsNullOrEmpty(__tmp111_line))
                {
                    __out.Write(__tmp111_line);
                    __tmp107_outputWritten = true;
                }
                if (__tmp107_outputWritten) __out.AppendLine(true);
                if (__tmp107_outputWritten)
                {
                    __out.AppendLine(false); //179:124
                }
                __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //180:1
                __out.AppendLine(false); //180:59
                __out.Write("                        diagnostics.Free();"); //181:1
                __out.AppendLine(false); //181:44
                bool __tmp113_outputWritten = false;
                string __tmp114_line = "                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_"; //182:1
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
                string __tmp116_line = ");"; //182:100
                if (!string.IsNullOrEmpty(__tmp116_line))
                {
                    __out.Write(__tmp116_line);
                    __tmp113_outputWritten = true;
                }
                if (__tmp113_outputWritten) __out.AppendLine(true);
                if (__tmp113_outputWritten)
                {
                    __out.AppendLine(false); //182:102
                }
                __out.Write("                    }"); //183:1
                __out.AppendLine(false); //183:22
                __out.Write("                }"); //184:1
                __out.AppendLine(false); //184:18
            }
            __out.Write("                else if (incompletePart == CompletionGraph.StartComputingNonSymbolProperties || incompletePart == CompletionGraph.FinishComputingNonSymbolProperties)"); //186:1
            __out.AppendLine(false); //186:166
            __out.Write("                {"); //187:1
            __out.AppendLine(false); //187:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartComputingNonSymbolProperties))"); //188:1
            __out.AppendLine(false); //188:100
            __out.Write("                    {"); //189:1
            __out.AppendLine(false); //189:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //190:1
            __out.AppendLine(false); //190:71
            __out.Write("                        CompleteNonSymbolProperties(locationOpt, diagnostics, cancellationToken);"); //191:1
            __out.AppendLine(false); //191:98
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //192:1
            __out.AppendLine(false); //192:59
            __out.Write("                        diagnostics.Free();"); //193:1
            __out.AppendLine(false); //193:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishComputingNonSymbolProperties);"); //194:1
            __out.AppendLine(false); //194:101
            __out.Write("                    }"); //195:1
            __out.AppendLine(false); //195:22
            __out.Write("                }"); //196:1
            __out.AppendLine(false); //196:18
            __out.Write("                else if (incompletePart == CompletionGraph.ChildrenCompleted)"); //197:1
            __out.AppendLine(false); //197:78
            __out.Write("                {"); //198:1
            __out.AppendLine(false); //198:18
            __out.Write("                    var diagnostics = DiagnosticBag.GetInstance();"); //199:1
            __out.AppendLine(false); //199:67
            __out.Write("                    CompleteImports(locationOpt, diagnostics, cancellationToken);"); //200:1
            __out.AppendLine(false); //200:82
            __out.Write("                    AddSymbolDiagnostics(diagnostics);"); //201:1
            __out.AppendLine(false); //201:55
            __out.Write("                    diagnostics.Free();"); //202:1
            __out.AppendLine(false); //202:40
            __out.Write("                    bool allCompleted = true;"); //204:1
            __out.AppendLine(false); //204:46
            __out.Write("                    if (locationOpt == null)"); //205:1
            __out.AppendLine(false); //205:45
            __out.Write("                    {"); //206:1
            __out.AppendLine(false); //206:22
            __out.Write("                        foreach (var child in _childSymbols)"); //207:1
            __out.AppendLine(false); //207:61
            __out.Write("                        {"); //208:1
            __out.AppendLine(false); //208:26
            __out.Write("                            cancellationToken.ThrowIfCancellationRequested();"); //209:1
            __out.AppendLine(false); //209:78
            __out.Write("                            child.ForceComplete(null, locationOpt, cancellationToken);"); //210:1
            __out.AppendLine(false); //210:87
            __out.Write("                        }"); //211:1
            __out.AppendLine(false); //211:26
            __out.Write("                    }"); //212:1
            __out.AppendLine(false); //212:22
            __out.Write("                    else"); //213:1
            __out.AppendLine(false); //213:25
            __out.Write("                    {"); //214:1
            __out.AppendLine(false); //214:22
            __out.Write("                        foreach (var child in _childSymbols)"); //215:1
            __out.AppendLine(false); //215:61
            __out.Write("                        {"); //216:1
            __out.AppendLine(false); //216:26
            __out.Write("                            ForceCompleteChildByLocation(locationOpt, child, cancellationToken);"); //217:1
            __out.AppendLine(false); //217:97
            __out.Write("                            allCompleted = allCompleted && child.HasComplete(CompletionGraph.All);"); //218:1
            __out.AppendLine(false); //218:99
            __out.Write("                        }"); //219:1
            __out.AppendLine(false); //219:26
            __out.Write("                    }"); //220:1
            __out.AppendLine(false); //220:22
            __out.Write("                    if (!allCompleted)"); //222:1
            __out.AppendLine(false); //222:39
            __out.Write("                    {"); //223:1
            __out.AppendLine(false); //223:22
            __out.Write("                        // We did not complete all members, so just kick out now."); //224:1
            __out.AppendLine(false); //224:82
            __out.Write("                        var allParts = CompletionParts.AllWithLocation;"); //225:1
            __out.AppendLine(false); //225:72
            __out.Write("                        _state.SpinWaitComplete(allParts, cancellationToken);"); //226:1
            __out.AppendLine(false); //226:78
            __out.Write("                        return;"); //227:1
            __out.AppendLine(false); //227:32
            __out.Write("                    }"); //228:1
            __out.AppendLine(false); //228:22
            __out.Write("                    // We've completed all members, proceed to the next iteration."); //230:1
            __out.AppendLine(false); //230:83
            __out.Write("                    _state.NotePartComplete(CompletionGraph.ChildrenCompleted);"); //231:1
            __out.AppendLine(false); //231:80
            __out.Write("                }"); //232:1
            __out.AppendLine(false); //232:18
            __out.Write("                else if (incompletePart == null)"); //233:1
            __out.AppendLine(false); //233:49
            __out.Write("                {"); //234:1
            __out.AppendLine(false); //234:18
            __out.Write("                    return;"); //235:1
            __out.AppendLine(false); //235:28
            __out.Write("                }"); //236:1
            __out.AppendLine(false); //236:18
            __out.Write("                else"); //237:1
            __out.AppendLine(false); //237:21
            __out.Write("                {"); //238:1
            __out.AppendLine(false); //238:18
            __out.Write("                    // This assert will trigger if we forgot to handle any of the completion parts"); //239:1
            __out.AppendLine(false); //239:99
            __out.Write("                    Debug.Assert(!CompletionParts.All.Contains(incompletePart));"); //240:1
            __out.AppendLine(false); //240:81
            __out.Write("                    // any other values are completion parts intended for other kinds of symbols"); //241:1
            __out.AppendLine(false); //241:97
            __out.Write("                    _state.NotePartComplete(incompletePart);"); //242:1
            __out.AppendLine(false); //242:61
            __out.Write("                }"); //243:1
            __out.AppendLine(false); //243:18
            __out.Write("                if (completionPart != null && _state.HasComplete(completionPart)) return;"); //244:1
            __out.AppendLine(false); //244:90
            __out.Write("                _state.SpinWaitComplete(incompletePart, cancellationToken);"); //245:1
            __out.AppendLine(false); //245:76
            __out.Write("            }"); //246:1
            __out.AppendLine(false); //246:14
            __out.AppendLine(true); //247:1
            __out.Write("            throw ExceptionUtilities.Unreachable;"); //248:1
            __out.AppendLine(false); //248:50
            __out.Write("        }"); //249:1
            __out.AppendLine(false); //249:10
            __out.AppendLine(true); //250:1
            __out.Write("        protected abstract void CompleteInitializingSymbol(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //251:1
            __out.AppendLine(false); //251:152
            __out.Write("        protected abstract ImmutableArray<Symbol> CompleteCreatingChildSymbols(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //252:1
            __out.AppendLine(false); //252:172
            __out.Write("        protected abstract void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //253:1
            __out.AppendLine(false); //253:141
            var __loop8_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //254:16
                select new { prop = prop}
                ).ToList(); //254:10
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp117 = __loop8_results[__loop8_iteration];
                var prop = __tmp117.prop;
                bool __tmp119_outputWritten = false;
                string __tmp120_line = "        protected abstract "; //255:1
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
                string __tmp122_line = " CompleteSymbolProperty_"; //255:39
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
                string __tmp124_line = "(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"; //255:74
                if (!string.IsNullOrEmpty(__tmp124_line))
                {
                    __out.Write(__tmp124_line);
                    __tmp119_outputWritten = true;
                }
                if (__tmp119_outputWritten) __out.AppendLine(true);
                if (__tmp119_outputWritten)
                {
                    __out.AppendLine(false); //255:167
                }
            }
            __out.Write("        protected abstract void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //257:1
            __out.AppendLine(false); //257:153
            __out.Write("        #endregion"); //258:1
            __out.AppendLine(false); //258:19
            __out.AppendLine(true); //259:1
            __out.Write("    }"); //260:1
            __out.AppendLine(false); //260:6
            __out.Write("}"); //261:1
            __out.AppendLine(false); //261:2
            return __out.ToStringAndFree();
        }

        public string GenerateMetaSymbol(SymbolGenerationInfo symbol) //264:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //265:1
            __out.AppendLine(false); //265:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //266:1
            __out.AppendLine(false); //266:29
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //267:1
            __out.AppendLine(false); //267:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //268:1
            __out.AppendLine(false); //268:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //269:1
            __out.AppendLine(false); //269:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //270:1
            __out.AppendLine(false); //270:44
            __out.Write("using System;"); //271:1
            __out.AppendLine(false); //271:14
            __out.Write("using System.Collections.Generic;"); //272:1
            __out.AppendLine(false); //272:34
            __out.Write("using System.Collections.Immutable;"); //273:1
            __out.AppendLine(false); //273:36
            __out.Write("using System.Diagnostics;"); //274:1
            __out.AppendLine(false); //274:26
            __out.Write("using System.Text;"); //275:1
            __out.AppendLine(false); //275:19
            __out.Write("using System.Threading;"); //276:1
            __out.AppendLine(false); //276:24
            __out.AppendLine(true); //277:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //278:1
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
            string __tmp5_line = ".Metadata"; //278:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //278:42
            }
            __out.Write("{"); //279:1
            __out.AppendLine(false); //279:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Meta"; //280:1
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
            string __tmp10_line = " : "; //280:40
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
            string __tmp12_line = ".Model.Model"; //280:65
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
                __out.AppendLine(false); //280:90
            }
            __out.Write("	{"); //281:1
            __out.AppendLine(false); //281:3
            bool __tmp15_outputWritten = false;
            string __tmp16_line = "        public Meta"; //282:1
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
            string __tmp18_line = "(Symbol container, object modelObject)"; //282:33
            if (!string.IsNullOrEmpty(__tmp18_line))
            {
                __out.Write(__tmp18_line);
                __tmp15_outputWritten = true;
            }
            if (__tmp15_outputWritten) __out.AppendLine(true);
            if (__tmp15_outputWritten)
            {
                __out.AppendLine(false); //282:71
            }
            __out.Write("            : base(container, modelObject)"); //283:1
            __out.AppendLine(false); //283:43
            __out.Write("        {"); //284:1
            __out.AppendLine(false); //284:10
            __out.Write("        }"); //285:1
            __out.AppendLine(false); //285:10
            __out.AppendLine(true); //286:1
            __out.Write("        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;"); //287:1
            __out.AppendLine(false); //287:95
            __out.AppendLine(true); //288:1
            __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;"); //289:1
            __out.AppendLine(false); //289:124
            __out.AppendLine(true); //290:1
            __out.Write("        protected override void CompleteInitializingSymbol(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //291:1
            __out.AppendLine(false); //291:151
            __out.Write("        {"); //292:1
            __out.AppendLine(false); //292:10
            __out.Write("            ModelSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //293:1
            __out.AppendLine(false); //293:125
            __out.Write("        }"); //294:1
            __out.AppendLine(false); //294:10
            __out.AppendLine(true); //295:1
            __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //296:1
            __out.AppendLine(false); //296:171
            __out.Write("        {"); //297:1
            __out.AppendLine(false); //297:10
            __out.Write("            return ModelSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //298:1
            __out.AppendLine(false); //298:123
            __out.Write("        }"); //299:1
            __out.AppendLine(false); //299:10
            __out.AppendLine(true); //300:1
            __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //301:1
            __out.AppendLine(false); //301:140
            __out.Write("        {"); //302:1
            __out.AppendLine(false); //302:10
            __out.Write("        }"); //303:1
            __out.AppendLine(false); //303:10
            __out.AppendLine(true); //304:1
            var __loop9_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //305:16
                select new { prop = prop}
                ).ToList(); //305:10
            for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
            {
                var __tmp19 = __loop9_results[__loop9_iteration];
                var prop = __tmp19.prop;
                bool __tmp21_outputWritten = false;
                string __tmp22_line = "        protected override "; //306:1
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
                string __tmp24_line = " CompleteSymbolProperty_"; //306:39
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
                string __tmp26_line = "(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"; //306:74
                if (!string.IsNullOrEmpty(__tmp26_line))
                {
                    __out.Write(__tmp26_line);
                    __tmp21_outputWritten = true;
                }
                if (__tmp21_outputWritten) __out.AppendLine(true);
                if (__tmp21_outputWritten)
                {
                    __out.AppendLine(false); //306:166
                }
                __out.Write("        {"); //307:1
                __out.AppendLine(false); //307:10
                if (prop.IsCollection) //308:14
                {
                    bool __tmp28_outputWritten = false;
                    string __tmp29_line = "            return ModelSymbolImplementation.AssignSymbolPropertyValues<"; //309:1
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
                    string __tmp31_line = ">(this, nameof("; //309:88
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
                    string __tmp33_line = "), diagnostics, cancellationToken);"; //309:114
                    if (!string.IsNullOrEmpty(__tmp33_line))
                    {
                        __out.Write(__tmp33_line);
                        __tmp28_outputWritten = true;
                    }
                    if (__tmp28_outputWritten) __out.AppendLine(true);
                    if (__tmp28_outputWritten)
                    {
                        __out.AppendLine(false); //309:149
                    }
                }
                else //310:14
                {
                    bool __tmp35_outputWritten = false;
                    string __tmp36_line = "            return ModelSymbolImplementation.AssignSymbolPropertyValue<"; //311:1
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
                    string __tmp38_line = ">(this, nameof("; //311:83
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
                    string __tmp40_line = "), diagnostics, cancellationToken);"; //311:109
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Write(__tmp40_line);
                        __tmp35_outputWritten = true;
                    }
                    if (__tmp35_outputWritten) __out.AppendLine(true);
                    if (__tmp35_outputWritten)
                    {
                        __out.AppendLine(false); //311:144
                    }
                }
                __out.Write("        }"); //313:1
                __out.AppendLine(false); //313:10
            }
            __out.AppendLine(true); //315:1
            __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //316:1
            __out.AppendLine(false); //316:152
            __out.Write("        {"); //317:1
            __out.AppendLine(false); //317:10
            __out.Write("        }"); //318:1
            __out.AppendLine(false); //318:10
            __out.Write("    }"); //319:1
            __out.AppendLine(false); //319:6
            __out.Write("}"); //320:1
            __out.AppendLine(false); //320:2
            return __out.ToStringAndFree();
        }

        public string GenerateSourceSymbol(SymbolGenerationInfo symbol) //323:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //324:1
            __out.AppendLine(false); //324:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //325:1
            __out.AppendLine(false); //325:29
            __out.Write("using MetaDslx.CodeAnalysis.Binding;"); //326:1
            __out.AppendLine(false); //326:37
            __out.Write("using MetaDslx.CodeAnalysis.Binding.Binders;"); //327:1
            __out.AppendLine(false); //327:45
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //328:1
            __out.AppendLine(false); //328:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //329:1
            __out.AppendLine(false); //329:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //330:1
            __out.AppendLine(false); //330:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //331:1
            __out.AppendLine(false); //331:44
            __out.Write("using System;"); //332:1
            __out.AppendLine(false); //332:14
            __out.Write("using System.Collections.Generic;"); //333:1
            __out.AppendLine(false); //333:34
            __out.Write("using System.Collections.Immutable;"); //334:1
            __out.AppendLine(false); //334:36
            __out.Write("using System.Diagnostics;"); //335:1
            __out.AppendLine(false); //335:26
            __out.Write("using System.Linq;"); //336:1
            __out.AppendLine(false); //336:19
            __out.Write("using System.Text;"); //337:1
            __out.AppendLine(false); //337:19
            __out.Write("using System.Threading;"); //338:1
            __out.AppendLine(false); //338:24
            __out.AppendLine(true); //339:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //340:1
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
            string __tmp5_line = ".Source"; //340:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //340:40
            }
            __out.Write("{"); //341:1
            __out.AppendLine(false); //341:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Source"; //342:1
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
            string __tmp10_line = " : "; //342:42
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
            string __tmp12_line = ".Model.Model"; //342:67
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
            string __tmp14_line = ", MetaDslx.CodeAnalysis.Symbols.Source.ISourceSymbol"; //342:92
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp7_outputWritten = true;
            }
            if (__tmp7_outputWritten) __out.AppendLine(true);
            if (__tmp7_outputWritten)
            {
                __out.AppendLine(false); //342:144
            }
            __out.Write("	{"); //343:1
            __out.AppendLine(false); //343:3
            __out.Write("        private readonly MergedDeclaration _declaration;"); //344:1
            __out.AppendLine(false); //344:57
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "		public Source"; //346:1
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
            string __tmp19_line = "(Symbol containingSymbol, object modelObject, MergedDeclaration declaration)"; //346:29
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Write(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //346:105
            }
            __out.Write("            : base(containingSymbol, modelObject)"); //347:1
            __out.AppendLine(false); //347:50
            __out.Write("        {"); //348:1
            __out.AppendLine(false); //348:10
            __out.Write("            Debug.Assert(declaration != null);"); //349:1
            __out.AppendLine(false); //349:47
            __out.Write("            _declaration = declaration;"); //350:1
            __out.AppendLine(false); //350:40
            __out.Write("		}"); //351:1
            __out.AppendLine(false); //351:4
            __out.AppendLine(true); //352:1
            __out.Write("        public MergedDeclaration MergedDeclaration => _declaration;"); //353:1
            __out.AppendLine(false); //353:68
            __out.AppendLine(true); //354:1
            __out.Write("        public override ImmutableArray<Location> Locations => _declaration.NameLocations;"); //355:1
            __out.AppendLine(false); //355:90
            __out.AppendLine(true); //356:1
            __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration.SyntaxReferences;"); //357:1
            __out.AppendLine(false); //357:116
            __out.AppendLine(true); //358:1
            __out.Write("        public BinderPosition<SymbolBinder> GetBinder(SyntaxReference reference)"); //359:1
            __out.AppendLine(false); //359:81
            __out.Write("        {"); //360:1
            __out.AppendLine(false); //360:10
            __out.Write("            Debug.Assert(this.DeclaringSyntaxReferences.Contains(reference));"); //361:1
            __out.AppendLine(false); //361:78
            __out.Write("            return FindBinders.FindSymbolBinder(this, reference);"); //362:1
            __out.AppendLine(false); //362:66
            __out.Write("        }"); //363:1
            __out.AppendLine(false); //363:10
            __out.AppendLine(true); //364:1
            __out.Write("        public Symbol GetChildSymbol(SyntaxReference syntax)"); //365:1
            __out.AppendLine(false); //365:61
            __out.Write("        {"); //366:1
            __out.AppendLine(false); //366:10
            __out.Write("            foreach (var child in this.ChildSymbols)"); //367:1
            __out.AppendLine(false); //367:53
            __out.Write("            {"); //368:1
            __out.AppendLine(false); //368:14
            __out.Write("                if (child.DeclaringSyntaxReferences.Any(sr => sr.GetLocation() == syntax.GetLocation()))"); //369:1
            __out.AppendLine(false); //369:105
            __out.Write("                {"); //370:1
            __out.AppendLine(false); //370:18
            __out.Write("                    return child;"); //371:1
            __out.AppendLine(false); //371:34
            __out.Write("                }"); //372:1
            __out.AppendLine(false); //372:18
            __out.Write("            }"); //373:1
            __out.AppendLine(false); //373:14
            __out.Write("            return null;"); //374:1
            __out.AppendLine(false); //374:25
            __out.Write("        }"); //375:1
            __out.AppendLine(false); //375:10
            __out.AppendLine(true); //376:1
            __out.Write("        protected override void CompleteInitializingSymbol(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //377:1
            __out.AppendLine(false); //377:151
            __out.Write("        {"); //378:1
            __out.AppendLine(false); //378:10
            __out.Write("            SourceSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //379:1
            __out.AppendLine(false); //379:126
            __out.Write("        }"); //380:1
            __out.AppendLine(false); //380:10
            __out.AppendLine(true); //381:1
            __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //382:1
            __out.AppendLine(false); //382:171
            __out.Write("        {"); //383:1
            __out.AppendLine(false); //383:10
            __out.Write("            return SourceSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //384:1
            __out.AppendLine(false); //384:124
            __out.Write("        }"); //385:1
            __out.AppendLine(false); //385:10
            __out.AppendLine(true); //386:1
            __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //387:1
            __out.AppendLine(false); //387:140
            __out.Write("        {"); //388:1
            __out.AppendLine(false); //388:10
            __out.Write("            SourceSymbolImplementation.CompleteImports(this, locationOpt, diagnostics, cancellationToken);"); //389:1
            __out.AppendLine(false); //389:107
            __out.Write("        }"); //390:1
            __out.AppendLine(false); //390:10
            __out.AppendLine(true); //391:1
            var __loop10_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //392:16
                select new { prop = prop}
                ).ToList(); //392:10
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                var __tmp20 = __loop10_results[__loop10_iteration];
                var prop = __tmp20.prop;
                bool __tmp22_outputWritten = false;
                string __tmp23_line = "        protected override "; //393:1
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
                string __tmp25_line = " CompleteSymbolProperty_"; //393:39
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
                string __tmp27_line = "(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"; //393:74
                if (!string.IsNullOrEmpty(__tmp27_line))
                {
                    __out.Write(__tmp27_line);
                    __tmp22_outputWritten = true;
                }
                if (__tmp22_outputWritten) __out.AppendLine(true);
                if (__tmp22_outputWritten)
                {
                    __out.AppendLine(false); //393:166
                }
                __out.Write("        {"); //394:1
                __out.AppendLine(false); //394:10
                if (prop.IsCollection) //395:14
                {
                    bool __tmp29_outputWritten = false;
                    string __tmp30_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValues<"; //396:1
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
                    string __tmp32_line = ">(this, nameof("; //396:89
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
                    string __tmp34_line = "), diagnostics, cancellationToken);"; //396:115
                    if (!string.IsNullOrEmpty(__tmp34_line))
                    {
                        __out.Write(__tmp34_line);
                        __tmp29_outputWritten = true;
                    }
                    if (__tmp29_outputWritten) __out.AppendLine(true);
                    if (__tmp29_outputWritten)
                    {
                        __out.AppendLine(false); //396:150
                    }
                }
                else //397:14
                {
                    bool __tmp36_outputWritten = false;
                    string __tmp37_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValue<"; //398:1
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
                    string __tmp39_line = ">(this, nameof("; //398:84
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
                    string __tmp41_line = "), diagnostics, cancellationToken);"; //398:110
                    if (!string.IsNullOrEmpty(__tmp41_line))
                    {
                        __out.Write(__tmp41_line);
                        __tmp36_outputWritten = true;
                    }
                    if (__tmp36_outputWritten) __out.AppendLine(true);
                    if (__tmp36_outputWritten)
                    {
                        __out.AppendLine(false); //398:145
                    }
                }
                __out.Write("        }"); //400:1
                __out.AppendLine(false); //400:10
            }
            __out.AppendLine(true); //402:1
            __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //403:1
            __out.AppendLine(false); //403:152
            __out.Write("        {"); //404:1
            __out.AppendLine(false); //404:10
            __out.Write("            SourceSymbolImplementation.AssignNonSymbolProperties(this, diagnostics, cancellationToken);"); //405:1
            __out.AppendLine(false); //405:104
            __out.Write("        }"); //406:1
            __out.AppendLine(false); //406:10
            __out.AppendLine(true); //407:1
            __out.Write("	}"); //408:1
            __out.AppendLine(false); //408:3
            __out.Write("}"); //409:1
            __out.AppendLine(false); //409:2
            return __out.ToStringAndFree();
        }

        public string GenerateVisitor(string namespaceName, IEnumerable<SymbolGenerationInfo> symbols) //412:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //413:1
            __out.AppendLine(false); //413:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //414:1
            __out.AppendLine(false); //414:29
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //415:1
            __out.AppendLine(false); //415:37
            __out.Write("using System;"); //416:1
            __out.AppendLine(false); //416:14
            __out.Write("using System.Collections.Generic;"); //417:1
            __out.AppendLine(false); //417:34
            __out.Write("using System.Collections.Immutable;"); //418:1
            __out.AppendLine(false); //418:36
            __out.Write("using System.Diagnostics;"); //419:1
            __out.AppendLine(false); //419:26
            __out.Write("using System.Text;"); //420:1
            __out.AppendLine(false); //420:19
            __out.Write("using System.Threading;"); //421:1
            __out.AppendLine(false); //421:24
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //423:1
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
                __out.AppendLine(false); //423:26
            }
            __out.Write("{"); //424:1
            __out.AppendLine(false); //424:2
            __out.Write("	public interface ISymbolVisitor"); //425:1
            __out.AppendLine(false); //425:33
            __out.Write("	{"); //426:1
            __out.AppendLine(false); //426:3
            var __loop11_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //427:16
                select new { symbol = symbol}
                ).ToList(); //427:10
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp5 = __loop11_results[__loop11_iteration];
                var symbol = __tmp5.symbol;
                bool __tmp7_outputWritten = false;
                string __tmp8_line = "        void Visit("; //428:1
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
                string __tmp10_line = " symbol);"; //428:33
                if (!string.IsNullOrEmpty(__tmp10_line))
                {
                    __out.Write(__tmp10_line);
                    __tmp7_outputWritten = true;
                }
                if (__tmp7_outputWritten) __out.AppendLine(true);
                if (__tmp7_outputWritten)
                {
                    __out.AppendLine(false); //428:42
                }
            }
            __out.Write("	}"); //430:1
            __out.AppendLine(false); //430:3
            __out.AppendLine(true); //431:1
            __out.Write("	public interface ISymbolVisitor<TResult>"); //432:1
            __out.AppendLine(false); //432:42
            __out.Write("	{"); //433:1
            __out.AppendLine(false); //433:3
            var __loop12_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //434:16
                select new { symbol = symbol}
                ).ToList(); //434:10
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp11 = __loop12_results[__loop12_iteration];
                var symbol = __tmp11.symbol;
                bool __tmp13_outputWritten = false;
                string __tmp14_line = "        TResult Visit("; //435:1
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
                string __tmp16_line = " symbol);"; //435:36
                if (!string.IsNullOrEmpty(__tmp16_line))
                {
                    __out.Write(__tmp16_line);
                    __tmp13_outputWritten = true;
                }
                if (__tmp13_outputWritten) __out.AppendLine(true);
                if (__tmp13_outputWritten)
                {
                    __out.AppendLine(false); //435:45
                }
            }
            __out.Write("	}"); //437:1
            __out.AppendLine(false); //437:3
            __out.AppendLine(true); //438:1
            __out.Write("	public interface ISymbolVisitor<TArgument, TResult>"); //439:1
            __out.AppendLine(false); //439:53
            __out.Write("	{"); //440:1
            __out.AppendLine(false); //440:3
            var __loop13_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //441:16
                select new { symbol = symbol}
                ).ToList(); //441:10
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp17 = __loop13_results[__loop13_iteration];
                var symbol = __tmp17.symbol;
                bool __tmp19_outputWritten = false;
                string __tmp20_line = "        TResult Visit("; //442:1
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
                string __tmp22_line = " symbol, TArgument argument);"; //442:36
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Write(__tmp22_line);
                    __tmp19_outputWritten = true;
                }
                if (__tmp19_outputWritten) __out.AppendLine(true);
                if (__tmp19_outputWritten)
                {
                    __out.AppendLine(false); //442:65
                }
            }
            __out.Write("	}"); //444:1
            __out.AppendLine(false); //444:3
            __out.Write("}"); //445:1
            __out.AppendLine(false); //445:2
            return __out.ToStringAndFree();
        }

    }
}

