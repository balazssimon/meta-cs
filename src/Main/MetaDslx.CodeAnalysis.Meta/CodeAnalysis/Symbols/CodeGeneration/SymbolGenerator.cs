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
            __out.Write("            public static readonly CompletionPart StartInitializing = new CompletionPart(nameof(StartInitializing));"); //76:1
            __out.AppendLine(false); //76:117
            __out.Write("            public static readonly CompletionPart FinishInitializing = new CompletionPart(nameof(FinishInitializing));"); //77:1
            __out.AppendLine(false); //77:119
            __out.Write("            public static readonly CompletionPart StartCreatingChildren = new CompletionPart(nameof(StartCreatingChildren));"); //78:1
            __out.AppendLine(false); //78:125
            __out.Write("            public static readonly CompletionPart FinishCreatingChildren = new CompletionPart(nameof(FinishCreatingChildren));"); //79:1
            __out.AppendLine(false); //79:127
            __out.Write("            public static readonly CompletionPart ChildrenCompleted = new CompletionPart(nameof(ChildrenCompleted));"); //80:1
            __out.AppendLine(false); //80:117
            var __loop1_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //81:20
                select new { prop = prop}
                ).ToList(); //81:14
            for (int __loop1_iteration = 0; __loop1_iteration < __loop1_results.Count; ++__loop1_iteration)
            {
                var __tmp15 = __loop1_results[__loop1_iteration];
                var prop = __tmp15.prop;
                bool __tmp17_outputWritten = false;
                string __tmp18_line = "            public static readonly CompletionPart StartComputingProperty_"; //82:1
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
                string __tmp20_line = " = new CompletionPart(nameof(StartComputingProperty_"; //82:85
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
                string __tmp22_line = "));"; //82:148
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Write(__tmp22_line);
                    __tmp17_outputWritten = true;
                }
                if (__tmp17_outputWritten) __out.AppendLine(true);
                if (__tmp17_outputWritten)
                {
                    __out.AppendLine(false); //82:151
                }
                bool __tmp24_outputWritten = false;
                string __tmp25_line = "            public static readonly CompletionPart FinishComputingProperty_"; //83:1
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
                string __tmp27_line = " = new CompletionPart(nameof(FinishComputingProperty_"; //83:86
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
                string __tmp29_line = "));"; //83:150
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Write(__tmp29_line);
                    __tmp24_outputWritten = true;
                }
                if (__tmp24_outputWritten) __out.AppendLine(true);
                if (__tmp24_outputWritten)
                {
                    __out.AppendLine(false); //83:153
                }
            }
            bool __tmp31_outputWritten = false;
            string __tmp32_line = "            public static readonly ImmutableHashSet<CompletionPart> All = CompletionPart.Combine(StartInitializing, FinishInitializing, StartCreatingChildren, FinishCreatingChildren, ChildrenCompleted"; //85:1
            if (!string.IsNullOrEmpty(__tmp32_line))
            {
                __out.Write(__tmp32_line);
                __tmp31_outputWritten = true;
            }
            var __loop2_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //85:208
                select new { prop = prop}
                ).ToList(); //85:202
            for (int __loop2_iteration = 0; __loop2_iteration < __loop2_results.Count; ++__loop2_iteration)
            {
                var __tmp34 = __loop2_results[__loop2_iteration];
                var prop = __tmp34.prop;
                string __tmp35_line = ", StartComputingProperty_"; //85:232
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
                string __tmp37_line = ", FinishComputingProperty_"; //85:268
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
            string __tmp40_line = ");"; //85:315
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Write(__tmp40_line);
                __tmp31_outputWritten = true;
            }
            if (__tmp31_outputWritten) __out.AppendLine(true);
            if (__tmp31_outputWritten)
            {
                __out.AppendLine(false); //85:317
            }
            bool __tmp42_outputWritten = false;
            string __tmp43_line = "            public static readonly ImmutableHashSet<CompletionPart> AllWithLocation = CompletionPart.Combine(StartInitializing, FinishInitializing, StartCreatingChildren, FinishCreatingChildren"; //86:1
            if (!string.IsNullOrEmpty(__tmp43_line))
            {
                __out.Write(__tmp43_line);
                __tmp42_outputWritten = true;
            }
            var __loop3_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //86:201
                select new { prop = prop}
                ).ToList(); //86:195
            for (int __loop3_iteration = 0; __loop3_iteration < __loop3_results.Count; ++__loop3_iteration)
            {
                var __tmp45 = __loop3_results[__loop3_iteration];
                var prop = __tmp45.prop;
                string __tmp46_line = ", StartComputingProperty_"; //86:225
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
                string __tmp48_line = ", FinishComputingProperty_"; //86:261
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
            string __tmp51_line = ");"; //86:308
            if (!string.IsNullOrEmpty(__tmp51_line))
            {
                __out.Write(__tmp51_line);
                __tmp42_outputWritten = true;
            }
            if (__tmp42_outputWritten) __out.AppendLine(true);
            if (__tmp42_outputWritten)
            {
                __out.AppendLine(false); //86:310
            }
            bool __tmp53_outputWritten = false;
            string __tmp54_line = "            public static readonly CompletionGraph CompletionGraph = CompletionGraph.FromCompletionParts(StartInitializing, FinishInitializing, StartCreatingChildren, FinishCreatingChildren"; //87:1
            if (!string.IsNullOrEmpty(__tmp54_line))
            {
                __out.Write(__tmp54_line);
                __tmp53_outputWritten = true;
            }
            var __loop4_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //87:197
                select new { prop = prop}
                ).ToList(); //87:191
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                var __tmp56 = __loop4_results[__loop4_iteration];
                var prop = __tmp56.prop;
                string __tmp57_line = ", StartComputingProperty_"; //87:221
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
                string __tmp59_line = ", FinishComputingProperty_"; //87:257
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
            string __tmp62_line = ", ChildrenCompleted);"; //87:304
            if (!string.IsNullOrEmpty(__tmp62_line))
            {
                __out.Write(__tmp62_line);
                __tmp53_outputWritten = true;
            }
            if (__tmp53_outputWritten) __out.AppendLine(true);
            if (__tmp53_outputWritten)
            {
                __out.AppendLine(false); //87:325
            }
            __out.Write("        }"); //88:1
            __out.AppendLine(false); //88:10
            __out.AppendLine(true); //89:1
            __out.Write("        private readonly Symbol _container;"); //90:1
            __out.AppendLine(false); //90:44
            __out.Write("        private readonly object _modelObject;"); //91:1
            __out.AppendLine(false); //91:46
            __out.Write("        private readonly CompletionState _state;"); //92:1
            __out.AppendLine(false); //92:49
            __out.Write("        private ImmutableArray<Symbol> _childSymbols;"); //93:1
            __out.AppendLine(false); //93:54
            var __loop5_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //94:16
                select new { prop = prop}
                ).ToList(); //94:10
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                var __tmp63 = __loop5_results[__loop5_iteration];
                var prop = __tmp63.prop;
                bool __tmp65_outputWritten = false;
                string __tmp66_line = "        private "; //95:1
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
                string __tmp68_line = " "; //95:28
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
                string __tmp70_line = ";"; //95:45
                if (!string.IsNullOrEmpty(__tmp70_line))
                {
                    __out.Write(__tmp70_line);
                    __tmp65_outputWritten = true;
                }
                if (__tmp65_outputWritten) __out.AppendLine(true);
                if (__tmp65_outputWritten)
                {
                    __out.AppendLine(false); //95:46
                }
            }
            __out.AppendLine(true); //97:1
            bool __tmp72_outputWritten = false;
            string __tmp73_line = "        public Model"; //98:1
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
            string __tmp75_line = "(Symbol container, object modelObject)"; //98:34
            if (!string.IsNullOrEmpty(__tmp75_line))
            {
                __out.Write(__tmp75_line);
                __tmp72_outputWritten = true;
            }
            if (__tmp72_outputWritten) __out.AppendLine(true);
            if (__tmp72_outputWritten)
            {
                __out.AppendLine(false); //98:72
            }
            __out.Write("        {"); //99:1
            __out.AppendLine(false); //99:10
            __out.Write("            Debug.Assert(container is IModelSymbol);"); //100:1
            __out.AppendLine(false); //100:53
            __out.Write("            if (modelObject == null) throw new ArgumentNullException(nameof(modelObject));"); //101:1
            __out.AppendLine(false); //101:91
            __out.Write("            _container = container;"); //102:1
            __out.AppendLine(false); //102:36
            __out.Write("            _modelObject = modelObject;"); //103:1
            __out.AppendLine(false); //103:40
            __out.Write("            _state = CompletionParts.CompletionGraph.CreateState();"); //104:1
            __out.AppendLine(false); //104:68
            __out.Write("        }"); //105:1
            __out.AppendLine(false); //105:10
            __out.AppendLine(true); //106:1
            __out.Write("        public sealed override Language Language => ContainingModule.Language;"); //107:1
            __out.AppendLine(false); //107:79
            __out.AppendLine(true); //108:1
            __out.Write("        public SymbolFactory SymbolFactory => ((IModelSymbol)_container).SymbolFactory;"); //109:1
            __out.AppendLine(false); //109:88
            __out.AppendLine(true); //110:1
            __out.Write("        public object ModelObject => _modelObject;"); //111:1
            __out.AppendLine(false); //111:51
            __out.AppendLine(true); //112:1
            __out.Write("        public Type ModelObjectType => _modelObject != null ? Language.SymbolFacts.GetModelObjectType(_modelObject) : null;"); //113:1
            __out.AppendLine(false); //113:124
            __out.AppendLine(true); //114:1
            __out.Write("        public sealed override string Name => _modelObject != null ? Language.SymbolFacts.GetName(_modelObject) : string.Empty;"); //115:1
            __out.AppendLine(false); //115:128
            __out.AppendLine(true); //116:1
            __out.Write("        public sealed override Symbol ContainingSymbol => _container;"); //117:1
            __out.AppendLine(false); //117:70
            __out.AppendLine(true); //118:1
            __out.Write("        public sealed override ImmutableArray<Symbol> ChildSymbols "); //119:1
            __out.AppendLine(false); //119:68
            __out.Write("        {"); //120:1
            __out.AppendLine(false); //120:10
            __out.Write("            get"); //121:1
            __out.AppendLine(false); //121:16
            __out.Write("            {"); //122:1
            __out.AppendLine(false); //122:14
            __out.Write("                this.ForceComplete(CompletionParts.FinishCreatingChildren, null, default);"); //123:1
            __out.AppendLine(false); //123:91
            __out.Write("                return _childSymbols;"); //124:1
            __out.AppendLine(false); //124:38
            __out.Write("            }"); //125:1
            __out.AppendLine(false); //125:14
            __out.Write("        }"); //126:1
            __out.AppendLine(false); //126:10
            __out.AppendLine(true); //127:1
            var __loop6_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //128:16
                select new { prop = prop}
                ).ToList(); //128:10
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp76 = __loop6_results[__loop6_iteration];
                var prop = __tmp76.prop;
                bool __tmp78_outputWritten = false;
                string __tmp79_line = "        public override "; //129:1
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
                string __tmp81_line = " "; //129:36
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
                    __out.AppendLine(false); //129:48
                }
                __out.Write("        {"); //130:1
                __out.AppendLine(false); //130:10
                __out.Write("            get"); //131:1
                __out.AppendLine(false); //131:16
                __out.Write("            {"); //132:1
                __out.AppendLine(false); //132:14
                bool __tmp84_outputWritten = false;
                string __tmp85_line = "                this.ForceComplete(CompletionParts.FinishComputingProperty_"; //133:1
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
                string __tmp87_line = ", null, default);"; //133:87
                if (!string.IsNullOrEmpty(__tmp87_line))
                {
                    __out.Write(__tmp87_line);
                    __tmp84_outputWritten = true;
                }
                if (__tmp84_outputWritten) __out.AppendLine(true);
                if (__tmp84_outputWritten)
                {
                    __out.AppendLine(false); //133:104
                }
                bool __tmp89_outputWritten = false;
                string __tmp90_line = "                return "; //134:1
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
                string __tmp92_line = ";"; //134:40
                if (!string.IsNullOrEmpty(__tmp92_line))
                {
                    __out.Write(__tmp92_line);
                    __tmp89_outputWritten = true;
                }
                if (__tmp89_outputWritten) __out.AppendLine(true);
                if (__tmp89_outputWritten)
                {
                    __out.AppendLine(false); //134:41
                }
                __out.Write("            }"); //135:1
                __out.AppendLine(false); //135:14
                __out.Write("        }"); //136:1
                __out.AppendLine(false); //136:10
            }
            __out.AppendLine(true); //138:1
            __out.Write("        #region Completion"); //139:1
            __out.AppendLine(false); //139:27
            __out.AppendLine(true); //140:1
            __out.Write("        public sealed override bool RequiresCompletion => true;"); //141:1
            __out.AppendLine(false); //141:64
            __out.AppendLine(true); //142:1
            __out.Write("        public sealed override bool HasComplete(CompletionPart part)"); //143:1
            __out.AppendLine(false); //143:69
            __out.Write("        {"); //144:1
            __out.AppendLine(false); //144:10
            __out.Write("            return _state.HasComplete(part);"); //145:1
            __out.AppendLine(false); //145:45
            __out.Write("        }"); //146:1
            __out.AppendLine(false); //146:10
            __out.AppendLine(true); //147:1
            __out.Write("        public override void ForceComplete(CompletionPart completionPart, SourceLocation locationOpt, CancellationToken cancellationToken)"); //148:1
            __out.AppendLine(false); //148:139
            __out.Write("        {"); //149:1
            __out.AppendLine(false); //149:10
            __out.Write("            if (completionPart != null && _state.HasComplete(completionPart)) return;"); //150:1
            __out.AppendLine(false); //150:86
            __out.Write("            if (completionPart != null && !CompletionParts.All.Contains(completionPart)) throw new ArgumentException(nameof(completionPart));"); //151:1
            __out.AppendLine(false); //151:142
            __out.Write("            while (true)"); //152:1
            __out.AppendLine(false); //152:25
            __out.Write("            {"); //153:1
            __out.AppendLine(false); //153:14
            __out.Write("                cancellationToken.ThrowIfCancellationRequested();"); //154:1
            __out.AppendLine(false); //154:66
            __out.Write("                var incompletePart = _state.NextIncompletePart;"); //155:1
            __out.AppendLine(false); //155:64
            __out.Write("                if (incompletePart == CompletionParts.StartInitializing || incompletePart == CompletionParts.FinishInitializing)"); //156:1
            __out.AppendLine(false); //156:129
            __out.Write("                {"); //157:1
            __out.AppendLine(false); //157:18
            __out.Write("                    if (_state.NotePartComplete(CompletionParts.StartInitializing))"); //158:1
            __out.AppendLine(false); //158:84
            __out.Write("                    {"); //159:1
            __out.AppendLine(false); //159:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //160:1
            __out.AppendLine(false); //160:71
            __out.Write("                        CompleteInitializingSymbol(locationOpt, diagnostics, cancellationToken);"); //161:1
            __out.AppendLine(false); //161:97
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //162:1
            __out.AppendLine(false); //162:59
            __out.Write("                        diagnostics.Free();"); //163:1
            __out.AppendLine(false); //163:44
            __out.Write("                        _state.NotePartComplete(CompletionParts.FinishInitializing);"); //164:1
            __out.AppendLine(false); //164:85
            __out.Write("                    }"); //165:1
            __out.AppendLine(false); //165:22
            __out.Write("                }"); //166:1
            __out.AppendLine(false); //166:18
            __out.Write("                else if (incompletePart == CompletionParts.StartCreatingChildren || incompletePart == CompletionParts.FinishCreatingChildren)"); //167:1
            __out.AppendLine(false); //167:142
            __out.Write("                {"); //168:1
            __out.AppendLine(false); //168:18
            __out.Write("                    if (_state.NotePartComplete(CompletionParts.StartCreatingChildren))"); //169:1
            __out.AppendLine(false); //169:88
            __out.Write("                    {"); //170:1
            __out.AppendLine(false); //170:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //171:1
            __out.AppendLine(false); //171:71
            __out.Write("                        _childSymbols = CompleteCreatingChildSymbols(locationOpt, diagnostics, cancellationToken);"); //172:1
            __out.AppendLine(false); //172:115
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //173:1
            __out.AppendLine(false); //173:59
            __out.Write("                        diagnostics.Free();"); //174:1
            __out.AppendLine(false); //174:44
            __out.Write("                        _state.NotePartComplete(CompletionParts.FinishCreatingChildren);"); //175:1
            __out.AppendLine(false); //175:89
            __out.Write("                    }"); //176:1
            __out.AppendLine(false); //176:22
            __out.Write("                }"); //177:1
            __out.AppendLine(false); //177:18
            var __loop7_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //178:24
                select new { prop = prop}
                ).ToList(); //178:18
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                var __tmp93 = __loop7_results[__loop7_iteration];
                var prop = __tmp93.prop;
                bool __tmp95_outputWritten = false;
                string __tmp96_line = "                else if (incompletePart == CompletionParts.StartComputingProperty_"; //179:1
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
                string __tmp98_line = " || incompletePart == CompletionParts.FinishComputingProperty_"; //179:94
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
                string __tmp100_line = ")"; //179:167
                if (!string.IsNullOrEmpty(__tmp100_line))
                {
                    __out.Write(__tmp100_line);
                    __tmp95_outputWritten = true;
                }
                if (__tmp95_outputWritten) __out.AppendLine(true);
                if (__tmp95_outputWritten)
                {
                    __out.AppendLine(false); //179:168
                }
                __out.Write("                {"); //180:1
                __out.AppendLine(false); //180:18
                bool __tmp102_outputWritten = false;
                string __tmp103_line = "                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_"; //181:1
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
                string __tmp105_line = "))"; //181:99
                if (!string.IsNullOrEmpty(__tmp105_line))
                {
                    __out.Write(__tmp105_line);
                    __tmp102_outputWritten = true;
                }
                if (__tmp102_outputWritten) __out.AppendLine(true);
                if (__tmp102_outputWritten)
                {
                    __out.AppendLine(false); //181:101
                }
                __out.Write("                    {"); //182:1
                __out.AppendLine(false); //182:22
                __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //183:1
                __out.AppendLine(false); //183:71
                bool __tmp107_outputWritten = false;
                string __tmp106Prefix = "                        "; //184:1
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
                string __tmp109_line = " = CompleteSymbolProperty_"; //184:41
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
                string __tmp111_line = "(locationOpt, diagnostics, cancellationToken);"; //184:78
                if (!string.IsNullOrEmpty(__tmp111_line))
                {
                    __out.Write(__tmp111_line);
                    __tmp107_outputWritten = true;
                }
                if (__tmp107_outputWritten) __out.AppendLine(true);
                if (__tmp107_outputWritten)
                {
                    __out.AppendLine(false); //184:124
                }
                __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //185:1
                __out.AppendLine(false); //185:59
                __out.Write("                        diagnostics.Free();"); //186:1
                __out.AppendLine(false); //186:44
                bool __tmp113_outputWritten = false;
                string __tmp114_line = "                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_"; //187:1
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
                string __tmp116_line = ");"; //187:100
                if (!string.IsNullOrEmpty(__tmp116_line))
                {
                    __out.Write(__tmp116_line);
                    __tmp113_outputWritten = true;
                }
                if (__tmp113_outputWritten) __out.AppendLine(true);
                if (__tmp113_outputWritten)
                {
                    __out.AppendLine(false); //187:102
                }
                __out.Write("                    }"); //188:1
                __out.AppendLine(false); //188:22
                __out.Write("                }"); //189:1
                __out.AppendLine(false); //189:18
            }
            __out.Write("                else if (incompletePart == CompletionParts.ChildrenCompleted)"); //191:1
            __out.AppendLine(false); //191:78
            __out.Write("                {"); //192:1
            __out.AppendLine(false); //192:18
            __out.Write("                    var diagnostics = DiagnosticBag.GetInstance();"); //193:1
            __out.AppendLine(false); //193:67
            __out.Write("                    CompleteImports(locationOpt, diagnostics, cancellationToken);"); //194:1
            __out.AppendLine(false); //194:82
            __out.Write("                    AddSymbolDiagnostics(diagnostics);"); //195:1
            __out.AppendLine(false); //195:55
            __out.Write("                    diagnostics.Free();"); //196:1
            __out.AppendLine(false); //196:40
            __out.Write("                    bool allCompleted = true;"); //198:1
            __out.AppendLine(false); //198:46
            __out.Write("                    if (locationOpt == null)"); //199:1
            __out.AppendLine(false); //199:45
            __out.Write("                    {"); //200:1
            __out.AppendLine(false); //200:22
            __out.Write("                        foreach (var child in _childSymbols)"); //201:1
            __out.AppendLine(false); //201:61
            __out.Write("                        {"); //202:1
            __out.AppendLine(false); //202:26
            __out.Write("                            cancellationToken.ThrowIfCancellationRequested();"); //203:1
            __out.AppendLine(false); //203:78
            __out.Write("                            child.ForceComplete(null, locationOpt, cancellationToken);"); //204:1
            __out.AppendLine(false); //204:87
            __out.Write("                        }"); //205:1
            __out.AppendLine(false); //205:26
            __out.Write("                    }"); //206:1
            __out.AppendLine(false); //206:22
            __out.Write("                    else"); //207:1
            __out.AppendLine(false); //207:25
            __out.Write("                    {"); //208:1
            __out.AppendLine(false); //208:22
            __out.Write("                        foreach (var child in _childSymbols)"); //209:1
            __out.AppendLine(false); //209:61
            __out.Write("                        {"); //210:1
            __out.AppendLine(false); //210:26
            __out.Write("                            ForceCompleteChildByLocation(locationOpt, child, cancellationToken);"); //211:1
            __out.AppendLine(false); //211:97
            __out.Write("                            allCompleted = allCompleted && child.HasComplete(CompletionGraph.All);"); //212:1
            __out.AppendLine(false); //212:99
            __out.Write("                        }"); //213:1
            __out.AppendLine(false); //213:26
            __out.Write("                    }"); //214:1
            __out.AppendLine(false); //214:22
            __out.Write("                    if (!allCompleted)"); //216:1
            __out.AppendLine(false); //216:39
            __out.Write("                    {"); //217:1
            __out.AppendLine(false); //217:22
            __out.Write("                        // We did not complete all members, so just kick out now."); //218:1
            __out.AppendLine(false); //218:82
            __out.Write("                        var allParts = CompletionParts.AllWithLocation;"); //219:1
            __out.AppendLine(false); //219:72
            __out.Write("                        _state.SpinWaitComplete(allParts, cancellationToken);"); //220:1
            __out.AppendLine(false); //220:78
            __out.Write("                        return;"); //221:1
            __out.AppendLine(false); //221:32
            __out.Write("                    }"); //222:1
            __out.AppendLine(false); //222:22
            __out.Write("                    // We've completed all members, proceed to the next iteration."); //224:1
            __out.AppendLine(false); //224:83
            __out.Write("                    _state.NotePartComplete(CompletionParts.ChildrenCompleted);"); //225:1
            __out.AppendLine(false); //225:80
            __out.Write("                }"); //226:1
            __out.AppendLine(false); //226:18
            __out.Write("                else if (incompletePart == null)"); //227:1
            __out.AppendLine(false); //227:49
            __out.Write("                {"); //228:1
            __out.AppendLine(false); //228:18
            __out.Write("                    return;"); //229:1
            __out.AppendLine(false); //229:28
            __out.Write("                }"); //230:1
            __out.AppendLine(false); //230:18
            __out.Write("                else"); //231:1
            __out.AppendLine(false); //231:21
            __out.Write("                {"); //232:1
            __out.AppendLine(false); //232:18
            __out.Write("                    // This assert will trigger if we forgot to handle any of the completion parts"); //233:1
            __out.AppendLine(false); //233:99
            __out.Write("                    Debug.Assert(!CompletionParts.All.Contains(incompletePart));"); //234:1
            __out.AppendLine(false); //234:81
            __out.Write("                    // any other values are completion parts intended for other kinds of symbols"); //235:1
            __out.AppendLine(false); //235:97
            __out.Write("                    _state.NotePartComplete(incompletePart);"); //236:1
            __out.AppendLine(false); //236:61
            __out.Write("                }"); //237:1
            __out.AppendLine(false); //237:18
            __out.Write("                if (completionPart != null && _state.HasComplete(completionPart)) return;"); //238:1
            __out.AppendLine(false); //238:90
            __out.Write("                _state.SpinWaitComplete(incompletePart, cancellationToken);"); //239:1
            __out.AppendLine(false); //239:76
            __out.Write("            }"); //240:1
            __out.AppendLine(false); //240:14
            __out.AppendLine(true); //241:1
            __out.Write("            throw ExceptionUtilities.Unreachable;"); //242:1
            __out.AppendLine(false); //242:50
            __out.Write("        }"); //243:1
            __out.AppendLine(false); //243:10
            __out.AppendLine(true); //244:1
            __out.Write("        protected abstract void CompleteInitializingSymbol(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //245:1
            __out.AppendLine(false); //245:152
            __out.Write("        protected abstract ImmutableArray<Symbol> CompleteCreatingChildSymbols(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //246:1
            __out.AppendLine(false); //246:172
            __out.Write("        protected abstract void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //247:1
            __out.AppendLine(false); //247:141
            var __loop8_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //248:16
                select new { prop = prop}
                ).ToList(); //248:10
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp117 = __loop8_results[__loop8_iteration];
                var prop = __tmp117.prop;
                bool __tmp119_outputWritten = false;
                string __tmp120_line = "        protected abstract "; //249:1
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
                string __tmp122_line = " CompleteSymbolProperty_"; //249:39
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
                string __tmp124_line = "(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"; //249:74
                if (!string.IsNullOrEmpty(__tmp124_line))
                {
                    __out.Write(__tmp124_line);
                    __tmp119_outputWritten = true;
                }
                if (__tmp119_outputWritten) __out.AppendLine(true);
                if (__tmp119_outputWritten)
                {
                    __out.AppendLine(false); //249:167
                }
            }
            __out.Write("        #endregion"); //251:1
            __out.AppendLine(false); //251:19
            __out.AppendLine(true); //252:1
            __out.Write("    }"); //253:1
            __out.AppendLine(false); //253:6
            __out.Write("}"); //254:1
            __out.AppendLine(false); //254:2
            return __out.ToStringAndFree();
        }

        public string GenerateMetaSymbol(SymbolGenerationInfo symbol) //257:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //258:1
            __out.AppendLine(false); //258:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //259:1
            __out.AppendLine(false); //259:29
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //260:1
            __out.AppendLine(false); //260:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //261:1
            __out.AppendLine(false); //261:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //262:1
            __out.AppendLine(false); //262:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //263:1
            __out.AppendLine(false); //263:44
            __out.Write("using System;"); //264:1
            __out.AppendLine(false); //264:14
            __out.Write("using System.Collections.Generic;"); //265:1
            __out.AppendLine(false); //265:34
            __out.Write("using System.Collections.Immutable;"); //266:1
            __out.AppendLine(false); //266:36
            __out.Write("using System.Diagnostics;"); //267:1
            __out.AppendLine(false); //267:26
            __out.Write("using System.Text;"); //268:1
            __out.AppendLine(false); //268:19
            __out.Write("using System.Threading;"); //269:1
            __out.AppendLine(false); //269:24
            __out.AppendLine(true); //270:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //271:1
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
            string __tmp5_line = ".Metadata"; //271:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //271:42
            }
            __out.Write("{"); //272:1
            __out.AppendLine(false); //272:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Meta"; //273:1
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
            string __tmp10_line = " : "; //273:40
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
            string __tmp12_line = ".Model.Model"; //273:65
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
                __out.AppendLine(false); //273:90
            }
            __out.Write("	{"); //274:1
            __out.AppendLine(false); //274:3
            bool __tmp15_outputWritten = false;
            string __tmp16_line = "        public Meta"; //275:1
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
            string __tmp18_line = "(Symbol container, object modelObject)"; //275:33
            if (!string.IsNullOrEmpty(__tmp18_line))
            {
                __out.Write(__tmp18_line);
                __tmp15_outputWritten = true;
            }
            if (__tmp15_outputWritten) __out.AppendLine(true);
            if (__tmp15_outputWritten)
            {
                __out.AppendLine(false); //275:71
            }
            __out.Write("            : base(container, modelObject)"); //276:1
            __out.AppendLine(false); //276:43
            __out.Write("        {"); //277:1
            __out.AppendLine(false); //277:10
            __out.Write("        }"); //278:1
            __out.AppendLine(false); //278:10
            __out.AppendLine(true); //279:1
            __out.Write("        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;"); //280:1
            __out.AppendLine(false); //280:95
            __out.AppendLine(true); //281:1
            __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;"); //282:1
            __out.AppendLine(false); //282:124
            __out.AppendLine(true); //283:1
            __out.Write("        protected override void CompleteInitializingSymbol(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //284:1
            __out.AppendLine(false); //284:151
            __out.Write("        {"); //285:1
            __out.AppendLine(false); //285:10
            __out.Write("        }"); //286:1
            __out.AppendLine(false); //286:10
            __out.AppendLine(true); //287:1
            __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //288:1
            __out.AppendLine(false); //288:171
            __out.Write("        {"); //289:1
            __out.AppendLine(false); //289:10
            __out.Write("            return SymbolFactory.GetChildSymbols(this.ModelObject);"); //290:1
            __out.AppendLine(false); //290:68
            __out.Write("        }"); //291:1
            __out.AppendLine(false); //291:10
            __out.AppendLine(true); //292:1
            __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //293:1
            __out.AppendLine(false); //293:140
            __out.Write("        {"); //294:1
            __out.AppendLine(false); //294:10
            __out.Write("        }"); //295:1
            __out.AppendLine(false); //295:10
            __out.AppendLine(true); //296:1
            var __loop9_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //297:16
                select new { prop = prop}
                ).ToList(); //297:10
            for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
            {
                var __tmp19 = __loop9_results[__loop9_iteration];
                var prop = __tmp19.prop;
                bool __tmp21_outputWritten = false;
                string __tmp22_line = "        protected override "; //298:1
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
                string __tmp24_line = " CompleteSymbolProperty_"; //298:39
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
                string __tmp26_line = "(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"; //298:74
                if (!string.IsNullOrEmpty(__tmp26_line))
                {
                    __out.Write(__tmp26_line);
                    __tmp21_outputWritten = true;
                }
                if (__tmp21_outputWritten) __out.AppendLine(true);
                if (__tmp21_outputWritten)
                {
                    __out.AppendLine(false); //298:166
                }
                __out.Write("        {"); //299:1
                __out.AppendLine(false); //299:10
                if (prop.IsCollection) //300:14
                {
                    bool __tmp28_outputWritten = false;
                    string __tmp29_line = "            return SymbolFactory.GetSymbolPropertyValues<"; //301:1
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
                    string __tmp31_line = ">(this, nameof("; //301:73
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
                    string __tmp33_line = "), this.ModelObject);"; //301:99
                    if (!string.IsNullOrEmpty(__tmp33_line))
                    {
                        __out.Write(__tmp33_line);
                        __tmp28_outputWritten = true;
                    }
                    if (__tmp28_outputWritten) __out.AppendLine(true);
                    if (__tmp28_outputWritten)
                    {
                        __out.AppendLine(false); //301:120
                    }
                }
                else //302:14
                {
                    bool __tmp35_outputWritten = false;
                    string __tmp36_line = "            return SymbolFactory.GetSymbolPropertyValue<"; //303:1
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
                    string __tmp38_line = ">(this, nameof("; //303:68
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
                    string __tmp40_line = "), this.ModelObject);"; //303:94
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Write(__tmp40_line);
                        __tmp35_outputWritten = true;
                    }
                    if (__tmp35_outputWritten) __out.AppendLine(true);
                    if (__tmp35_outputWritten)
                    {
                        __out.AppendLine(false); //303:115
                    }
                }
                __out.Write("        }"); //305:1
                __out.AppendLine(false); //305:10
            }
            __out.Write("    }"); //307:1
            __out.AppendLine(false); //307:6
            __out.Write("}"); //308:1
            __out.AppendLine(false); //308:2
            return __out.ToStringAndFree();
        }

        public string GenerateSourceSymbol(SymbolGenerationInfo symbol) //311:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //312:1
            __out.AppendLine(false); //312:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //313:1
            __out.AppendLine(false); //313:29
            __out.Write("using MetaDslx.CodeAnalysis.Binding;"); //314:1
            __out.AppendLine(false); //314:37
            __out.Write("using MetaDslx.CodeAnalysis.Binding.Binders;"); //315:1
            __out.AppendLine(false); //315:45
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //316:1
            __out.AppendLine(false); //316:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //317:1
            __out.AppendLine(false); //317:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //318:1
            __out.AppendLine(false); //318:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //319:1
            __out.AppendLine(false); //319:44
            __out.Write("using System;"); //320:1
            __out.AppendLine(false); //320:14
            __out.Write("using System.Collections.Generic;"); //321:1
            __out.AppendLine(false); //321:34
            __out.Write("using System.Collections.Immutable;"); //322:1
            __out.AppendLine(false); //322:36
            __out.Write("using System.Diagnostics;"); //323:1
            __out.AppendLine(false); //323:26
            __out.Write("using System.Linq;"); //324:1
            __out.AppendLine(false); //324:19
            __out.Write("using System.Text;"); //325:1
            __out.AppendLine(false); //325:19
            __out.Write("using System.Threading;"); //326:1
            __out.AppendLine(false); //326:24
            __out.AppendLine(true); //327:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //328:1
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
            string __tmp5_line = ".Source"; //328:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //328:40
            }
            __out.Write("{"); //329:1
            __out.AppendLine(false); //329:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Source"; //330:1
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
            string __tmp10_line = " : "; //330:42
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
            string __tmp12_line = ".Model.Model"; //330:67
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
            string __tmp14_line = ", MetaDslx.CodeAnalysis.Symbols.Source.ISourceSymbol"; //330:92
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp7_outputWritten = true;
            }
            if (__tmp7_outputWritten) __out.AppendLine(true);
            if (__tmp7_outputWritten)
            {
                __out.AppendLine(false); //330:144
            }
            __out.Write("	{"); //331:1
            __out.AppendLine(false); //331:3
            __out.Write("        private readonly MergedDeclaration _declaration;"); //332:1
            __out.AppendLine(false); //332:57
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "		public Source"; //334:1
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
            string __tmp19_line = "(Symbol containingSymbol, object modelObject, MergedDeclaration declaration)"; //334:29
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Write(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //334:105
            }
            __out.Write("            : base(containingSymbol, modelObject)"); //335:1
            __out.AppendLine(false); //335:50
            __out.Write("        {"); //336:1
            __out.AppendLine(false); //336:10
            __out.Write("            Debug.Assert(declaration != null);"); //337:1
            __out.AppendLine(false); //337:47
            __out.Write("            _declaration = declaration;"); //338:1
            __out.AppendLine(false); //338:40
            __out.Write("		}"); //339:1
            __out.AppendLine(false); //339:4
            __out.AppendLine(true); //340:1
            __out.Write("        public MergedDeclaration MergedDeclaration => _declaration;"); //341:1
            __out.AppendLine(false); //341:68
            __out.AppendLine(true); //342:1
            __out.Write("        public override ImmutableArray<Location> Locations => _declaration.NameLocations;"); //343:1
            __out.AppendLine(false); //343:90
            __out.AppendLine(true); //344:1
            __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration.SyntaxReferences;"); //345:1
            __out.AppendLine(false); //345:116
            __out.AppendLine(true); //346:1
            __out.Write("        public BinderPosition<SymbolBinder> GetBinder(SyntaxReference reference)"); //347:1
            __out.AppendLine(false); //347:81
            __out.Write("        {"); //348:1
            __out.AppendLine(false); //348:10
            __out.Write("            Debug.Assert(this.DeclaringSyntaxReferences.Contains(reference));"); //349:1
            __out.AppendLine(false); //349:78
            __out.Write("            return FindBinders.FindSymbolBinder(this, reference);"); //350:1
            __out.AppendLine(false); //350:66
            __out.Write("        }"); //351:1
            __out.AppendLine(false); //351:10
            __out.AppendLine(true); //352:1
            __out.Write("        public Symbol GetChildSymbol(SyntaxReference syntax)"); //353:1
            __out.AppendLine(false); //353:61
            __out.Write("        {"); //354:1
            __out.AppendLine(false); //354:10
            __out.Write("            foreach (var child in this.ChildSymbols)"); //355:1
            __out.AppendLine(false); //355:53
            __out.Write("            {"); //356:1
            __out.AppendLine(false); //356:14
            __out.Write("                if (child.DeclaringSyntaxReferences.Any(sr => sr.GetLocation() == syntax.GetLocation()))"); //357:1
            __out.AppendLine(false); //357:105
            __out.Write("                {"); //358:1
            __out.AppendLine(false); //358:18
            __out.Write("                    return child;"); //359:1
            __out.AppendLine(false); //359:34
            __out.Write("                }"); //360:1
            __out.AppendLine(false); //360:18
            __out.Write("            }"); //361:1
            __out.AppendLine(false); //361:14
            __out.Write("            return null;"); //362:1
            __out.AppendLine(false); //362:25
            __out.Write("        }"); //363:1
            __out.AppendLine(false); //363:10
            __out.AppendLine(true); //364:1
            __out.Write("        protected override void CompleteInitializingSymbol(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //365:1
            __out.AppendLine(false); //365:151
            __out.Write("        {"); //366:1
            __out.AppendLine(false); //366:10
            __out.Write("        }"); //367:1
            __out.AppendLine(false); //367:10
            __out.AppendLine(true); //368:1
            __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //369:1
            __out.AppendLine(false); //369:171
            __out.Write("        {"); //370:1
            __out.AppendLine(false); //370:10
            __out.Write("            return default;"); //371:1
            __out.AppendLine(false); //371:28
            __out.Write("        }"); //372:1
            __out.AppendLine(false); //372:10
            __out.AppendLine(true); //373:1
            __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //374:1
            __out.AppendLine(false); //374:140
            __out.Write("        {"); //375:1
            __out.AppendLine(false); //375:10
            __out.Write("        }"); //376:1
            __out.AppendLine(false); //376:10
            __out.AppendLine(true); //377:1
            var __loop10_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //378:16
                select new { prop = prop}
                ).ToList(); //378:10
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                var __tmp20 = __loop10_results[__loop10_iteration];
                var prop = __tmp20.prop;
                bool __tmp22_outputWritten = false;
                string __tmp23_line = "        protected override "; //379:1
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
                string __tmp25_line = " CompleteSymbolProperty_"; //379:39
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
                string __tmp27_line = "(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"; //379:74
                if (!string.IsNullOrEmpty(__tmp27_line))
                {
                    __out.Write(__tmp27_line);
                    __tmp22_outputWritten = true;
                }
                if (__tmp22_outputWritten) __out.AppendLine(true);
                if (__tmp22_outputWritten)
                {
                    __out.AppendLine(false); //379:166
                }
                __out.Write("        {"); //380:1
                __out.AppendLine(false); //380:10
                __out.Write("            return default;"); //381:1
                __out.AppendLine(false); //381:28
                __out.Write("        }"); //382:1
                __out.AppendLine(false); //382:10
            }
            __out.AppendLine(true); //384:1
            __out.Write("	}"); //385:1
            __out.AppendLine(false); //385:3
            __out.Write("}"); //386:1
            __out.AppendLine(false); //386:2
            return __out.ToStringAndFree();
        }

        public string GenerateVisitor(string namespaceName, IEnumerable<SymbolGenerationInfo> symbols) //389:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //390:1
            __out.AppendLine(false); //390:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //391:1
            __out.AppendLine(false); //391:29
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //392:1
            __out.AppendLine(false); //392:37
            __out.Write("using System;"); //393:1
            __out.AppendLine(false); //393:14
            __out.Write("using System.Collections.Generic;"); //394:1
            __out.AppendLine(false); //394:34
            __out.Write("using System.Collections.Immutable;"); //395:1
            __out.AppendLine(false); //395:36
            __out.Write("using System.Diagnostics;"); //396:1
            __out.AppendLine(false); //396:26
            __out.Write("using System.Text;"); //397:1
            __out.AppendLine(false); //397:19
            __out.Write("using System.Threading;"); //398:1
            __out.AppendLine(false); //398:24
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //400:1
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
                __out.AppendLine(false); //400:26
            }
            __out.Write("{"); //401:1
            __out.AppendLine(false); //401:2
            __out.Write("	public interface ISymbolVisitor"); //402:1
            __out.AppendLine(false); //402:33
            __out.Write("	{"); //403:1
            __out.AppendLine(false); //403:3
            var __loop11_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //404:16
                select new { symbol = symbol}
                ).ToList(); //404:10
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp5 = __loop11_results[__loop11_iteration];
                var symbol = __tmp5.symbol;
                bool __tmp7_outputWritten = false;
                string __tmp8_line = "        void Visit("; //405:1
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
                string __tmp10_line = " symbol);"; //405:33
                if (!string.IsNullOrEmpty(__tmp10_line))
                {
                    __out.Write(__tmp10_line);
                    __tmp7_outputWritten = true;
                }
                if (__tmp7_outputWritten) __out.AppendLine(true);
                if (__tmp7_outputWritten)
                {
                    __out.AppendLine(false); //405:42
                }
            }
            __out.Write("	}"); //407:1
            __out.AppendLine(false); //407:3
            __out.AppendLine(true); //408:1
            __out.Write("	public interface ISymbolVisitor<TResult>"); //409:1
            __out.AppendLine(false); //409:42
            __out.Write("	{"); //410:1
            __out.AppendLine(false); //410:3
            var __loop12_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //411:16
                select new { symbol = symbol}
                ).ToList(); //411:10
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp11 = __loop12_results[__loop12_iteration];
                var symbol = __tmp11.symbol;
                bool __tmp13_outputWritten = false;
                string __tmp14_line = "        TResult Visit("; //412:1
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
                string __tmp16_line = " symbol);"; //412:36
                if (!string.IsNullOrEmpty(__tmp16_line))
                {
                    __out.Write(__tmp16_line);
                    __tmp13_outputWritten = true;
                }
                if (__tmp13_outputWritten) __out.AppendLine(true);
                if (__tmp13_outputWritten)
                {
                    __out.AppendLine(false); //412:45
                }
            }
            __out.Write("	}"); //414:1
            __out.AppendLine(false); //414:3
            __out.AppendLine(true); //415:1
            __out.Write("	public interface ISymbolVisitor<TArgument, TResult>"); //416:1
            __out.AppendLine(false); //416:53
            __out.Write("	{"); //417:1
            __out.AppendLine(false); //417:3
            var __loop13_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //418:16
                select new { symbol = symbol}
                ).ToList(); //418:10
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp17 = __loop13_results[__loop13_iteration];
                var symbol = __tmp17.symbol;
                bool __tmp19_outputWritten = false;
                string __tmp20_line = "        TResult Visit("; //419:1
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
                string __tmp22_line = " symbol, TArgument argument);"; //419:36
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Write(__tmp22_line);
                    __tmp19_outputWritten = true;
                }
                if (__tmp19_outputWritten) __out.AppendLine(true);
                if (__tmp19_outputWritten)
                {
                    __out.AppendLine(false); //419:65
                }
            }
            __out.Write("	}"); //421:1
            __out.AppendLine(false); //421:3
            __out.Write("}"); //422:1
            __out.AppendLine(false); //422:2
            return __out.ToStringAndFree();
        }

    }
}

