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

        public string GenerateCompletionSymbol(SymbolGenerationInfo symbol) //56:1
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
            string __tmp5_line = ".Completion"; //71:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //71:44
            }
            __out.Write("{"); //72:1
            __out.AppendLine(false); //72:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public abstract partial class Completion"; //73:1
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
            string __tmp10_line = " : "; //73:55
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
            string __tmp12_line = "."; //73:80
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
            if (symbol.ModelObjectOption != ParameterOption.Disabled) //73:95
            {
                string __tmp15_line = ", MetaDslx.CodeAnalysis.Symbols.Metadata.IModelSymbol"; //73:152
                if (!string.IsNullOrEmpty(__tmp15_line))
                {
                    __out.Write(__tmp15_line);
                    __tmp7_outputWritten = true;
                }
            }
            if (__tmp7_outputWritten) __out.AppendLine(true);
            if (__tmp7_outputWritten)
            {
                __out.AppendLine(false); //73:213
            }
            __out.Write("	{"); //74:1
            __out.AppendLine(false); //74:3
            __out.Write("        public static class CompletionParts"); //75:1
            __out.AppendLine(false); //75:44
            __out.Write("        {"); //76:1
            __out.AppendLine(false); //76:10
            var __loop1_results = 
                (from partName in __Enumerate((symbol.GetCompletionPartNames()).GetEnumerator()) //77:20
                select new { partName = partName}
                ).ToList(); //77:14
            for (int __loop1_iteration = 0; __loop1_iteration < __loop1_results.Count; ++__loop1_iteration)
            {
                var __tmp17 = __loop1_results[__loop1_iteration];
                var partName = __tmp17.partName;
                bool __tmp19_outputWritten = false;
                string __tmp20_line = "            public static readonly CompletionPart "; //78:1
                if (!string.IsNullOrEmpty(__tmp20_line))
                {
                    __out.Write(__tmp20_line);
                    __tmp19_outputWritten = true;
                }
                var __tmp21 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp21.Write(partName);
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
                string __tmp22_line = " = new CompletionPart(nameof("; //78:61
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Write(__tmp22_line);
                    __tmp19_outputWritten = true;
                }
                var __tmp23 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp23.Write(partName);
                var __tmp23Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp23.ToStringAndFree());
                bool __tmp23_last = __tmp23Reader.EndOfStream;
                while(!__tmp23_last)
                {
                    ReadOnlySpan<char> __tmp23_line = __tmp23Reader.ReadLine();
                    __tmp23_last = __tmp23Reader.EndOfStream;
                    if (!__tmp23_last || !__tmp23_line.IsEmpty)
                    {
                        __out.Write(__tmp23_line);
                        __tmp19_outputWritten = true;
                    }
                    if (!__tmp23_last) __out.AppendLine(true);
                }
                string __tmp24_line = "));"; //78:100
                if (!string.IsNullOrEmpty(__tmp24_line))
                {
                    __out.Write(__tmp24_line);
                    __tmp19_outputWritten = true;
                }
                if (__tmp19_outputWritten) __out.AppendLine(true);
                if (__tmp19_outputWritten)
                {
                    __out.AppendLine(false); //78:103
                }
            }
            bool __tmp26_outputWritten = false;
            string __tmp27_line = "            public static readonly ImmutableHashSet<CompletionPart> AllWithLocation = CompletionPart.Combine("; //80:1
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Write(__tmp27_line);
                __tmp26_outputWritten = true;
            }
            var __loop2_results = 
                (from partName in __Enumerate((symbol.GetOrderedCompletionParts(true)).GetEnumerator()) //80:117
                select new { partName = partName}
                ).ToList(); //80:111
            for (int __loop2_iteration = 0; __loop2_iteration < __loop2_results.Count; ++__loop2_iteration)
            {
                string comma; //80:164
                if (__loop2_iteration+1 < __loop2_results.Count) comma = ", ";
                else comma = string.Empty;
                var __tmp29 = __loop2_results[__loop2_iteration];
                var partName = __tmp29.partName;
                var __tmp30 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp30.Write(partName);
                var __tmp30Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp30.ToStringAndFree());
                bool __tmp30_last = __tmp30Reader.EndOfStream;
                while(!__tmp30_last)
                {
                    ReadOnlySpan<char> __tmp30_line = __tmp30Reader.ReadLine();
                    __tmp30_last = __tmp30Reader.EndOfStream;
                    if (!__tmp30_last || !__tmp30_line.IsEmpty)
                    {
                        __out.Write(__tmp30_line);
                        __tmp26_outputWritten = true;
                    }
                    if (!__tmp30_last) __out.AppendLine(true);
                }
                var __tmp31 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp31.Write(comma);
                var __tmp31Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp31.ToStringAndFree());
                bool __tmp31_last = __tmp31Reader.EndOfStream;
                while(!__tmp31_last)
                {
                    ReadOnlySpan<char> __tmp31_line = __tmp31Reader.ReadLine();
                    __tmp31_last = __tmp31Reader.EndOfStream;
                    if (!__tmp31_last || !__tmp31_line.IsEmpty)
                    {
                        __out.Write(__tmp31_line);
                        __tmp26_outputWritten = true;
                    }
                    if (!__tmp31_last) __out.AppendLine(true);
                }
            }
            string __tmp33_line = ");"; //80:217
            if (!string.IsNullOrEmpty(__tmp33_line))
            {
                __out.Write(__tmp33_line);
                __tmp26_outputWritten = true;
            }
            if (__tmp26_outputWritten) __out.AppendLine(true);
            if (__tmp26_outputWritten)
            {
                __out.AppendLine(false); //80:219
            }
            bool __tmp35_outputWritten = false;
            string __tmp36_line = "            public static readonly ImmutableHashSet<CompletionPart> All = CompletionPart.Combine("; //81:1
            if (!string.IsNullOrEmpty(__tmp36_line))
            {
                __out.Write(__tmp36_line);
                __tmp35_outputWritten = true;
            }
            var __loop3_results = 
                (from partName in __Enumerate((symbol.GetOrderedCompletionParts(false)).GetEnumerator()) //81:105
                select new { partName = partName}
                ).ToList(); //81:99
            for (int __loop3_iteration = 0; __loop3_iteration < __loop3_results.Count; ++__loop3_iteration)
            {
                string comma; //81:153
                if (__loop3_iteration+1 < __loop3_results.Count) comma = ", ";
                else comma = string.Empty;
                var __tmp38 = __loop3_results[__loop3_iteration];
                var partName = __tmp38.partName;
                var __tmp39 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp39.Write(partName);
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
                var __tmp40 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp40.Write(comma);
                var __tmp40Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp40.ToStringAndFree());
                bool __tmp40_last = __tmp40Reader.EndOfStream;
                while(!__tmp40_last)
                {
                    ReadOnlySpan<char> __tmp40_line = __tmp40Reader.ReadLine();
                    __tmp40_last = __tmp40Reader.EndOfStream;
                    if (!__tmp40_last || !__tmp40_line.IsEmpty)
                    {
                        __out.Write(__tmp40_line);
                        __tmp35_outputWritten = true;
                    }
                    if (!__tmp40_last) __out.AppendLine(true);
                }
            }
            string __tmp42_line = ");"; //81:206
            if (!string.IsNullOrEmpty(__tmp42_line))
            {
                __out.Write(__tmp42_line);
                __tmp35_outputWritten = true;
            }
            if (__tmp35_outputWritten) __out.AppendLine(true);
            if (__tmp35_outputWritten)
            {
                __out.AppendLine(false); //81:208
            }
            bool __tmp44_outputWritten = false;
            string __tmp45_line = "            public static readonly CompletionGraph CompletionGraph = CompletionGraph.FromCompletionParts("; //82:1
            if (!string.IsNullOrEmpty(__tmp45_line))
            {
                __out.Write(__tmp45_line);
                __tmp44_outputWritten = true;
            }
            var __loop4_results = 
                (from partName in __Enumerate((symbol.GetOrderedCompletionParts(false)).GetEnumerator()) //82:113
                select new { partName = partName}
                ).ToList(); //82:107
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                string comma; //82:161
                if (__loop4_iteration+1 < __loop4_results.Count) comma = ", ";
                else comma = string.Empty;
                var __tmp47 = __loop4_results[__loop4_iteration];
                var partName = __tmp47.partName;
                var __tmp48 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp48.Write(partName);
                var __tmp48Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp48.ToStringAndFree());
                bool __tmp48_last = __tmp48Reader.EndOfStream;
                while(!__tmp48_last)
                {
                    ReadOnlySpan<char> __tmp48_line = __tmp48Reader.ReadLine();
                    __tmp48_last = __tmp48Reader.EndOfStream;
                    if (!__tmp48_last || !__tmp48_line.IsEmpty)
                    {
                        __out.Write(__tmp48_line);
                        __tmp44_outputWritten = true;
                    }
                    if (!__tmp48_last) __out.AppendLine(true);
                }
                var __tmp49 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp49.Write(comma);
                var __tmp49Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp49.ToStringAndFree());
                bool __tmp49_last = __tmp49Reader.EndOfStream;
                while(!__tmp49_last)
                {
                    ReadOnlySpan<char> __tmp49_line = __tmp49Reader.ReadLine();
                    __tmp49_last = __tmp49Reader.EndOfStream;
                    if (!__tmp49_last || !__tmp49_line.IsEmpty)
                    {
                        __out.Write(__tmp49_line);
                        __tmp44_outputWritten = true;
                    }
                    if (!__tmp49_last) __out.AppendLine(true);
                }
            }
            string __tmp51_line = ");"; //82:214
            if (!string.IsNullOrEmpty(__tmp51_line))
            {
                __out.Write(__tmp51_line);
                __tmp44_outputWritten = true;
            }
            if (__tmp44_outputWritten) __out.AppendLine(true);
            if (__tmp44_outputWritten)
            {
                __out.AppendLine(false); //82:216
            }
            __out.Write("        }"); //83:1
            __out.AppendLine(false); //83:10
            __out.AppendLine(true); //84:1
            __out.Write("        private readonly Symbol _container;"); //85:1
            __out.AppendLine(false); //85:44
            if (symbol.ModelObjectOption != ParameterOption.Disabled) //86:10
            {
                __out.Write("        private readonly object? _modelObject;"); //87:1
                __out.AppendLine(false); //87:47
            }
            __out.Write("        private readonly CompletionState _state;"); //89:1
            __out.AppendLine(false); //89:49
            __out.Write("        private ImmutableArray<Symbol> _childSymbols;"); //90:1
            __out.AppendLine(false); //90:54
            __out.Write("        private string _name;"); //91:1
            __out.AppendLine(false); //91:30
            var __loop5_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //92:16
                select new { prop = prop}
                ).ToList(); //92:10
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                var __tmp52 = __loop5_results[__loop5_iteration];
                var prop = __tmp52.prop;
                bool __tmp54_outputWritten = false;
                string __tmp55_line = "        private "; //93:1
                if (!string.IsNullOrEmpty(__tmp55_line))
                {
                    __out.Write(__tmp55_line);
                    __tmp54_outputWritten = true;
                }
                var __tmp56 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp56.Write(prop.Type);
                var __tmp56Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp56.ToStringAndFree());
                bool __tmp56_last = __tmp56Reader.EndOfStream;
                while(!__tmp56_last)
                {
                    ReadOnlySpan<char> __tmp56_line = __tmp56Reader.ReadLine();
                    __tmp56_last = __tmp56Reader.EndOfStream;
                    if (!__tmp56_last || !__tmp56_line.IsEmpty)
                    {
                        __out.Write(__tmp56_line);
                        __tmp54_outputWritten = true;
                    }
                    if (!__tmp56_last) __out.AppendLine(true);
                }
                string __tmp57_line = " "; //93:28
                if (!string.IsNullOrEmpty(__tmp57_line))
                {
                    __out.Write(__tmp57_line);
                    __tmp54_outputWritten = true;
                }
                var __tmp58 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp58.Write(prop.FieldName);
                var __tmp58Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp58.ToStringAndFree());
                bool __tmp58_last = __tmp58Reader.EndOfStream;
                while(!__tmp58_last)
                {
                    ReadOnlySpan<char> __tmp58_line = __tmp58Reader.ReadLine();
                    __tmp58_last = __tmp58Reader.EndOfStream;
                    if (!__tmp58_last || !__tmp58_line.IsEmpty)
                    {
                        __out.Write(__tmp58_line);
                        __tmp54_outputWritten = true;
                    }
                    if (!__tmp58_last) __out.AppendLine(true);
                }
                string __tmp59_line = ";"; //93:45
                if (!string.IsNullOrEmpty(__tmp59_line))
                {
                    __out.Write(__tmp59_line);
                    __tmp54_outputWritten = true;
                }
                if (__tmp54_outputWritten) __out.AppendLine(true);
                if (__tmp54_outputWritten)
                {
                    __out.AppendLine(false); //93:46
                }
            }
            __out.AppendLine(true); //95:1
            bool __tmp61_outputWritten = false;
            string __tmp62_line = "        public Completion"; //96:1
            if (!string.IsNullOrEmpty(__tmp62_line))
            {
                __out.Write(__tmp62_line);
                __tmp61_outputWritten = true;
            }
            var __tmp63 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp63.Write(symbol.Name);
            var __tmp63Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp63.ToStringAndFree());
            bool __tmp63_last = __tmp63Reader.EndOfStream;
            while(!__tmp63_last)
            {
                ReadOnlySpan<char> __tmp63_line = __tmp63Reader.ReadLine();
                __tmp63_last = __tmp63Reader.EndOfStream;
                if (!__tmp63_last || !__tmp63_line.IsEmpty)
                {
                    __out.Write(__tmp63_line);
                    __tmp61_outputWritten = true;
                }
                if (!__tmp63_last) __out.AppendLine(true);
            }
            string __tmp64_line = "(Symbol container"; //96:39
            if (!string.IsNullOrEmpty(__tmp64_line))
            {
                __out.Write(__tmp64_line);
                __tmp61_outputWritten = true;
            }
            if (symbol.ModelObjectOption != ParameterOption.Disabled) //96:57
            {
                string __tmp66_line = ", object? modelObject"; //96:114
                if (!string.IsNullOrEmpty(__tmp66_line))
                {
                    __out.Write(__tmp66_line);
                    __tmp61_outputWritten = true;
                }
                if (symbol.ModelObjectOption == ParameterOption.Optional) //96:136
                {
                    string __tmp68_line = " = null"; //96:193
                    if (!string.IsNullOrEmpty(__tmp68_line))
                    {
                        __out.Write(__tmp68_line);
                        __tmp61_outputWritten = true;
                    }
                }
            }
            string __tmp71_line = ")"; //96:216
            if (!string.IsNullOrEmpty(__tmp71_line))
            {
                __out.Write(__tmp71_line);
                __tmp61_outputWritten = true;
            }
            if (__tmp61_outputWritten) __out.AppendLine(true);
            if (__tmp61_outputWritten)
            {
                __out.AppendLine(false); //96:217
            }
            __out.Write("        {"); //97:1
            __out.AppendLine(false); //97:10
            __out.Write("            _container = container;"); //98:1
            __out.AppendLine(false); //98:36
            if (symbol.ModelObjectOption == ParameterOption.Required) //99:14
            {
                __out.Write("            if (modelObject is null) throw new ArgumentNullException(nameof(modelObject));"); //100:1
                __out.AppendLine(false); //100:91
            }
            if (symbol.ModelObjectOption != ParameterOption.Disabled) //102:14
            {
                __out.Write("            _modelObject = modelObject;"); //103:1
                __out.AppendLine(false); //103:40
            }
            __out.Write("            _state = CompletionParts.CompletionGraph.CreateState();"); //105:1
            __out.AppendLine(false); //105:68
            __out.Write("        }"); //106:1
            __out.AppendLine(false); //106:10
            __out.AppendLine(true); //107:1
            __out.Write("        public sealed override Language Language => ContainingModule.Language;"); //108:1
            __out.AppendLine(false); //108:79
            __out.AppendLine(true); //109:1
            __out.Write("        public SymbolFactory SymbolFactory => ContainingModule.SymbolFactory;"); //110:1
            __out.AppendLine(false); //110:78
            if (symbol.ModelObjectOption != ParameterOption.Disabled) //111:10
            {
                __out.AppendLine(true); //112:1
                __out.Write("        public object ModelObject => _modelObject;"); //113:1
                __out.AppendLine(false); //113:51
                __out.AppendLine(true); //114:1
                __out.Write("        public Type ModelObjectType => _modelObject is not null ? Language.SymbolFacts.GetModelObjectType(_modelObject) : null;"); //115:1
                __out.AppendLine(false); //115:128
            }
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
            __out.Write("        public override string Name "); //129:1
            __out.AppendLine(false); //129:37
            __out.Write("        {"); //130:1
            __out.AppendLine(false); //130:10
            __out.Write("            get"); //131:1
            __out.AppendLine(false); //131:16
            __out.Write("            {"); //132:1
            __out.AppendLine(false); //132:14
            __out.Write("                this.ForceComplete(CompletionGraph.FinishInitializing, null, default);"); //133:1
            __out.AppendLine(false); //133:87
            __out.Write("                return _name;"); //134:1
            __out.AppendLine(false); //134:30
            __out.Write("            }"); //135:1
            __out.AppendLine(false); //135:14
            __out.Write("        }"); //136:1
            __out.AppendLine(false); //136:10
            __out.AppendLine(true); //137:1
            var __loop6_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //138:16
                select new { prop = prop}
                ).ToList(); //138:10
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp72 = __loop6_results[__loop6_iteration];
                var prop = __tmp72.prop;
                bool __tmp74_outputWritten = false;
                string __tmp75_line = "        public override "; //139:1
                if (!string.IsNullOrEmpty(__tmp75_line))
                {
                    __out.Write(__tmp75_line);
                    __tmp74_outputWritten = true;
                }
                var __tmp76 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp76.Write(prop.Type);
                var __tmp76Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp76.ToStringAndFree());
                bool __tmp76_last = __tmp76Reader.EndOfStream;
                while(!__tmp76_last)
                {
                    ReadOnlySpan<char> __tmp76_line = __tmp76Reader.ReadLine();
                    __tmp76_last = __tmp76Reader.EndOfStream;
                    if (!__tmp76_last || !__tmp76_line.IsEmpty)
                    {
                        __out.Write(__tmp76_line);
                        __tmp74_outputWritten = true;
                    }
                    if (!__tmp76_last) __out.AppendLine(true);
                }
                string __tmp77_line = " "; //139:36
                if (!string.IsNullOrEmpty(__tmp77_line))
                {
                    __out.Write(__tmp77_line);
                    __tmp74_outputWritten = true;
                }
                var __tmp78 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp78.Write(prop.Name);
                var __tmp78Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp78.ToStringAndFree());
                bool __tmp78_last = __tmp78Reader.EndOfStream;
                while(!__tmp78_last)
                {
                    ReadOnlySpan<char> __tmp78_line = __tmp78Reader.ReadLine();
                    __tmp78_last = __tmp78Reader.EndOfStream;
                    if (!__tmp78_last || !__tmp78_line.IsEmpty)
                    {
                        __out.Write(__tmp78_line);
                        __tmp74_outputWritten = true;
                    }
                    if (!__tmp78_last || __tmp74_outputWritten) __out.AppendLine(true);
                }
                if (__tmp74_outputWritten)
                {
                    __out.AppendLine(false); //139:48
                }
                __out.Write("        {"); //140:1
                __out.AppendLine(false); //140:10
                __out.Write("            get"); //141:1
                __out.AppendLine(false); //141:16
                __out.Write("            {"); //142:1
                __out.AppendLine(false); //142:14
                bool __tmp80_outputWritten = false;
                string __tmp81_line = "                this.ForceComplete(CompletionParts."; //143:1
                if (!string.IsNullOrEmpty(__tmp81_line))
                {
                    __out.Write(__tmp81_line);
                    __tmp80_outputWritten = true;
                }
                var __tmp82 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp82.Write(prop.FinishCompletionPartName);
                var __tmp82Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp82.ToStringAndFree());
                bool __tmp82_last = __tmp82Reader.EndOfStream;
                while(!__tmp82_last)
                {
                    ReadOnlySpan<char> __tmp82_line = __tmp82Reader.ReadLine();
                    __tmp82_last = __tmp82Reader.EndOfStream;
                    if (!__tmp82_last || !__tmp82_line.IsEmpty)
                    {
                        __out.Write(__tmp82_line);
                        __tmp80_outputWritten = true;
                    }
                    if (!__tmp82_last) __out.AppendLine(true);
                }
                string __tmp83_line = ", null, default);"; //143:83
                if (!string.IsNullOrEmpty(__tmp83_line))
                {
                    __out.Write(__tmp83_line);
                    __tmp80_outputWritten = true;
                }
                if (__tmp80_outputWritten) __out.AppendLine(true);
                if (__tmp80_outputWritten)
                {
                    __out.AppendLine(false); //143:100
                }
                bool __tmp85_outputWritten = false;
                string __tmp86_line = "                return "; //144:1
                if (!string.IsNullOrEmpty(__tmp86_line))
                {
                    __out.Write(__tmp86_line);
                    __tmp85_outputWritten = true;
                }
                var __tmp87 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp87.Write(prop.FieldName);
                var __tmp87Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp87.ToStringAndFree());
                bool __tmp87_last = __tmp87Reader.EndOfStream;
                while(!__tmp87_last)
                {
                    ReadOnlySpan<char> __tmp87_line = __tmp87Reader.ReadLine();
                    __tmp87_last = __tmp87Reader.EndOfStream;
                    if (!__tmp87_last || !__tmp87_line.IsEmpty)
                    {
                        __out.Write(__tmp87_line);
                        __tmp85_outputWritten = true;
                    }
                    if (!__tmp87_last) __out.AppendLine(true);
                }
                string __tmp88_line = ";"; //144:40
                if (!string.IsNullOrEmpty(__tmp88_line))
                {
                    __out.Write(__tmp88_line);
                    __tmp85_outputWritten = true;
                }
                if (__tmp85_outputWritten) __out.AppendLine(true);
                if (__tmp85_outputWritten)
                {
                    __out.AppendLine(false); //144:41
                }
                __out.Write("            }"); //145:1
                __out.AppendLine(false); //145:14
                __out.Write("        }"); //146:1
                __out.AppendLine(false); //146:10
            }
            __out.AppendLine(true); //148:1
            __out.Write("        #region Completion"); //149:1
            __out.AppendLine(false); //149:27
            __out.AppendLine(true); //150:1
            __out.Write("        public sealed override bool RequiresCompletion => true;"); //151:1
            __out.AppendLine(false); //151:64
            __out.AppendLine(true); //152:1
            __out.Write("        public sealed override bool HasComplete(CompletionPart part)"); //153:1
            __out.AppendLine(false); //153:69
            __out.Write("        {"); //154:1
            __out.AppendLine(false); //154:10
            __out.Write("            return _state.HasComplete(part);"); //155:1
            __out.AppendLine(false); //155:45
            __out.Write("        }"); //156:1
            __out.AppendLine(false); //156:10
            __out.AppendLine(true); //157:1
            __out.Write("        public override void ForceComplete(CompletionPart completionPart, SourceLocation locationOpt, CancellationToken cancellationToken)"); //158:1
            __out.AppendLine(false); //158:139
            __out.Write("        {"); //159:1
            __out.AppendLine(false); //159:10
            __out.Write("            if (completionPart != null && _state.HasComplete(completionPart)) return;"); //160:1
            __out.AppendLine(false); //160:86
            __out.Write("            if (completionPart != null && !CompletionParts.All.Contains(completionPart)) throw new ArgumentException(nameof(completionPart));"); //161:1
            __out.AppendLine(false); //161:142
            __out.Write("            while (true)"); //162:1
            __out.AppendLine(false); //162:25
            __out.Write("            {"); //163:1
            __out.AppendLine(false); //163:14
            __out.Write("                cancellationToken.ThrowIfCancellationRequested();"); //164:1
            __out.AppendLine(false); //164:66
            __out.Write("                var incompletePart = _state.NextIncompletePart;"); //165:1
            __out.AppendLine(false); //165:64
            __out.Write("                if (incompletePart == CompletionGraph.StartInitializing || incompletePart == CompletionGraph.FinishInitializing)"); //166:1
            __out.AppendLine(false); //166:129
            __out.Write("                {"); //167:1
            __out.AppendLine(false); //167:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartInitializing))"); //168:1
            __out.AppendLine(false); //168:84
            __out.Write("                    {"); //169:1
            __out.AppendLine(false); //169:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //170:1
            __out.AppendLine(false); //170:71
            __out.Write("                        _name = CompleteSymbolProperty_Name(diagnostics, cancellationToken);"); //171:1
            __out.AppendLine(false); //171:93
            __out.Write("                        CompleteInitializingSymbol(diagnostics, cancellationToken);"); //172:1
            __out.AppendLine(false); //172:84
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //173:1
            __out.AppendLine(false); //173:59
            __out.Write("                        diagnostics.Free();"); //174:1
            __out.AppendLine(false); //174:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishInitializing);"); //175:1
            __out.AppendLine(false); //175:85
            __out.Write("                    }"); //176:1
            __out.AppendLine(false); //176:22
            __out.Write("                }"); //177:1
            __out.AppendLine(false); //177:18
            __out.Write("                else if (incompletePart == CompletionGraph.StartCreatingChildren || incompletePart == CompletionGraph.FinishCreatingChildren)"); //178:1
            __out.AppendLine(false); //178:142
            __out.Write("                {"); //179:1
            __out.AppendLine(false); //179:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartCreatingChildren))"); //180:1
            __out.AppendLine(false); //180:88
            __out.Write("                    {"); //181:1
            __out.AppendLine(false); //181:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //182:1
            __out.AppendLine(false); //182:71
            __out.Write("                        _childSymbols = CompleteCreatingChildSymbols(diagnostics, cancellationToken);"); //183:1
            __out.AppendLine(false); //183:102
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //184:1
            __out.AppendLine(false); //184:59
            __out.Write("                        diagnostics.Free();"); //185:1
            __out.AppendLine(false); //185:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishCreatingChildren);"); //186:1
            __out.AppendLine(false); //186:89
            __out.Write("                    }"); //187:1
            __out.AppendLine(false); //187:22
            __out.Write("                }"); //188:1
            __out.AppendLine(false); //188:18
            var __loop7_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //189:24
                select new { part = part}
                ).ToList(); //189:18
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                var __tmp89 = __loop7_results[__loop7_iteration];
                var part = __tmp89.part;
                if (part.IsLocked) //190:22
                {
                    bool __tmp91_outputWritten = false;
                    string __tmp92_line = "                else if (incompletePart == CompletionParts."; //191:1
                    if (!string.IsNullOrEmpty(__tmp92_line))
                    {
                        __out.Write(__tmp92_line);
                        __tmp91_outputWritten = true;
                    }
                    var __tmp93 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp93.Write(part.StartCompletionPartName);
                    var __tmp93Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp93.ToStringAndFree());
                    bool __tmp93_last = __tmp93Reader.EndOfStream;
                    while(!__tmp93_last)
                    {
                        ReadOnlySpan<char> __tmp93_line = __tmp93Reader.ReadLine();
                        __tmp93_last = __tmp93Reader.EndOfStream;
                        if (!__tmp93_last || !__tmp93_line.IsEmpty)
                        {
                            __out.Write(__tmp93_line);
                            __tmp91_outputWritten = true;
                        }
                        if (!__tmp93_last) __out.AppendLine(true);
                    }
                    string __tmp94_line = " || incompletePart == CompletionParts."; //191:90
                    if (!string.IsNullOrEmpty(__tmp94_line))
                    {
                        __out.Write(__tmp94_line);
                        __tmp91_outputWritten = true;
                    }
                    var __tmp95 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp95.Write(part.FinishCompletionPartName);
                    var __tmp95Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp95.ToStringAndFree());
                    bool __tmp95_last = __tmp95Reader.EndOfStream;
                    while(!__tmp95_last)
                    {
                        ReadOnlySpan<char> __tmp95_line = __tmp95Reader.ReadLine();
                        __tmp95_last = __tmp95Reader.EndOfStream;
                        if (!__tmp95_last || !__tmp95_line.IsEmpty)
                        {
                            __out.Write(__tmp95_line);
                            __tmp91_outputWritten = true;
                        }
                        if (!__tmp95_last) __out.AppendLine(true);
                    }
                    string __tmp96_line = ")"; //191:159
                    if (!string.IsNullOrEmpty(__tmp96_line))
                    {
                        __out.Write(__tmp96_line);
                        __tmp91_outputWritten = true;
                    }
                    if (__tmp91_outputWritten) __out.AppendLine(true);
                    if (__tmp91_outputWritten)
                    {
                        __out.AppendLine(false); //191:160
                    }
                    __out.Write("                {"); //192:1
                    __out.AppendLine(false); //192:18
                    bool __tmp98_outputWritten = false;
                    string __tmp99_line = "                    if (_state.NotePartComplete(CompletionParts."; //193:1
                    if (!string.IsNullOrEmpty(__tmp99_line))
                    {
                        __out.Write(__tmp99_line);
                        __tmp98_outputWritten = true;
                    }
                    var __tmp100 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp100.Write(part.StartCompletionPartName);
                    var __tmp100Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp100.ToStringAndFree());
                    bool __tmp100_last = __tmp100Reader.EndOfStream;
                    while(!__tmp100_last)
                    {
                        ReadOnlySpan<char> __tmp100_line = __tmp100Reader.ReadLine();
                        __tmp100_last = __tmp100Reader.EndOfStream;
                        if (!__tmp100_last || !__tmp100_line.IsEmpty)
                        {
                            __out.Write(__tmp100_line);
                            __tmp98_outputWritten = true;
                        }
                        if (!__tmp100_last) __out.AppendLine(true);
                    }
                    string __tmp101_line = "))"; //193:95
                    if (!string.IsNullOrEmpty(__tmp101_line))
                    {
                        __out.Write(__tmp101_line);
                        __tmp98_outputWritten = true;
                    }
                    if (__tmp98_outputWritten) __out.AppendLine(true);
                    if (__tmp98_outputWritten)
                    {
                        __out.AppendLine(false); //193:97
                    }
                    __out.Write("                    {"); //194:1
                    __out.AppendLine(false); //194:22
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //195:26
                    {
                        __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //196:1
                        __out.AppendLine(false); //196:71
                    }
                    bool __tmp103_outputWritten = false;
                    string __tmp102Prefix = "                        "; //198:1
                    if (part is SymbolPropertyGenerationInfo) //198:26
                    {
                        if (!string.IsNullOrEmpty(__tmp102Prefix))
                        {
                            __out.Write(__tmp102Prefix);
                            __tmp103_outputWritten = true;
                        }
                        var __tmp105 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp105.Write(((SymbolPropertyGenerationInfo)part).FieldName);
                        var __tmp105Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp105.ToStringAndFree());
                        bool __tmp105_last = __tmp105Reader.EndOfStream;
                        while(!__tmp105_last)
                        {
                            ReadOnlySpan<char> __tmp105_line = __tmp105Reader.ReadLine();
                            __tmp105_last = __tmp105Reader.EndOfStream;
                            if (!__tmp105_last || !__tmp105_line.IsEmpty)
                            {
                                __out.Write(__tmp105_line);
                                __tmp103_outputWritten = true;
                            }
                            if (!__tmp105_last) __out.AppendLine(true);
                        }
                        string __tmp106_line = " = "; //198:116
                        if (!string.IsNullOrEmpty(__tmp106_line))
                        {
                            __out.Write(__tmp106_line);
                            __tmp103_outputWritten = true;
                        }
                    }
                    var __tmp108 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp108.Write(part.CompleteMethodName);
                    var __tmp108Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp108.ToStringAndFree());
                    bool __tmp108_last = __tmp108Reader.EndOfStream;
                    while(!__tmp108_last)
                    {
                        ReadOnlySpan<char> __tmp108_line = __tmp108Reader.ReadLine();
                        __tmp108_last = __tmp108Reader.EndOfStream;
                        if (!__tmp108_last || !__tmp108_line.IsEmpty)
                        {
                            __out.Write(__tmp108_line);
                            __tmp103_outputWritten = true;
                        }
                        if (!__tmp108_last) __out.AppendLine(true);
                    }
                    string __tmp109_line = "("; //198:152
                    if (!string.IsNullOrEmpty(__tmp109_line))
                    {
                        __out.Write(__tmp109_line);
                        __tmp103_outputWritten = true;
                    }
                    var __tmp110 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp110.Write(part.CompleteMethodArgList);
                    var __tmp110Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp110.ToStringAndFree());
                    bool __tmp110_last = __tmp110Reader.EndOfStream;
                    while(!__tmp110_last)
                    {
                        ReadOnlySpan<char> __tmp110_line = __tmp110Reader.ReadLine();
                        __tmp110_last = __tmp110Reader.EndOfStream;
                        if (!__tmp110_last || !__tmp110_line.IsEmpty)
                        {
                            __out.Write(__tmp110_line);
                            __tmp103_outputWritten = true;
                        }
                        if (!__tmp110_last) __out.AppendLine(true);
                    }
                    string __tmp111_line = ");"; //198:181
                    if (!string.IsNullOrEmpty(__tmp111_line))
                    {
                        __out.Write(__tmp111_line);
                        __tmp103_outputWritten = true;
                    }
                    if (__tmp103_outputWritten) __out.AppendLine(true);
                    if (__tmp103_outputWritten)
                    {
                        __out.AppendLine(false); //198:183
                    }
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //199:26
                    {
                        __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //200:1
                        __out.AppendLine(false); //200:59
                        __out.Write("                        diagnostics.Free();"); //201:1
                        __out.AppendLine(false); //201:44
                    }
                    bool __tmp113_outputWritten = false;
                    string __tmp114_line = "                        _state.NotePartComplete(CompletionParts."; //203:1
                    if (!string.IsNullOrEmpty(__tmp114_line))
                    {
                        __out.Write(__tmp114_line);
                        __tmp113_outputWritten = true;
                    }
                    var __tmp115 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp115.Write(part.FinishCompletionPartName);
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
                    string __tmp116_line = ");"; //203:96
                    if (!string.IsNullOrEmpty(__tmp116_line))
                    {
                        __out.Write(__tmp116_line);
                        __tmp113_outputWritten = true;
                    }
                    if (__tmp113_outputWritten) __out.AppendLine(true);
                    if (__tmp113_outputWritten)
                    {
                        __out.AppendLine(false); //203:98
                    }
                    __out.Write("                    }"); //204:1
                    __out.AppendLine(false); //204:22
                    __out.Write("                }"); //205:1
                    __out.AppendLine(false); //205:18
                }
                else //206:22
                {
                    bool __tmp118_outputWritten = false;
                    string __tmp119_line = "                else if (incompletePart == CompletionParts."; //207:1
                    if (!string.IsNullOrEmpty(__tmp119_line))
                    {
                        __out.Write(__tmp119_line);
                        __tmp118_outputWritten = true;
                    }
                    var __tmp120 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp120.Write(part.CompletionPartName);
                    var __tmp120Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp120.ToStringAndFree());
                    bool __tmp120_last = __tmp120Reader.EndOfStream;
                    while(!__tmp120_last)
                    {
                        ReadOnlySpan<char> __tmp120_line = __tmp120Reader.ReadLine();
                        __tmp120_last = __tmp120Reader.EndOfStream;
                        if (!__tmp120_last || !__tmp120_line.IsEmpty)
                        {
                            __out.Write(__tmp120_line);
                            __tmp118_outputWritten = true;
                        }
                        if (!__tmp120_last) __out.AppendLine(true);
                    }
                    string __tmp121_line = ")"; //207:85
                    if (!string.IsNullOrEmpty(__tmp121_line))
                    {
                        __out.Write(__tmp121_line);
                        __tmp118_outputWritten = true;
                    }
                    if (__tmp118_outputWritten) __out.AppendLine(true);
                    if (__tmp118_outputWritten)
                    {
                        __out.AppendLine(false); //207:86
                    }
                    __out.Write("                {"); //208:1
                    __out.AppendLine(false); //208:18
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //209:22
                    {
                        __out.Write("                    var diagnostics = DiagnosticBag.GetInstance();"); //210:1
                        __out.AppendLine(false); //210:67
                    }
                    bool __tmp123_outputWritten = false;
                    string __tmp122Prefix = "                    "; //212:1
                    var __tmp124 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp124.Write(part.CompleteMethodName);
                    var __tmp124Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp124.ToStringAndFree());
                    bool __tmp124_last = __tmp124Reader.EndOfStream;
                    while(!__tmp124_last)
                    {
                        ReadOnlySpan<char> __tmp124_line = __tmp124Reader.ReadLine();
                        __tmp124_last = __tmp124Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp122Prefix))
                        {
                            __out.Write(__tmp122Prefix);
                            __tmp123_outputWritten = true;
                        }
                        if (!__tmp124_last || !__tmp124_line.IsEmpty)
                        {
                            __out.Write(__tmp124_line);
                            __tmp123_outputWritten = true;
                        }
                        if (!__tmp124_last) __out.AppendLine(true);
                    }
                    string __tmp125_line = "("; //212:46
                    if (!string.IsNullOrEmpty(__tmp125_line))
                    {
                        __out.Write(__tmp125_line);
                        __tmp123_outputWritten = true;
                    }
                    var __tmp126 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp126.Write(part.CompleteMethodArgList);
                    var __tmp126Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp126.ToStringAndFree());
                    bool __tmp126_last = __tmp126Reader.EndOfStream;
                    while(!__tmp126_last)
                    {
                        ReadOnlySpan<char> __tmp126_line = __tmp126Reader.ReadLine();
                        __tmp126_last = __tmp126Reader.EndOfStream;
                        if (!__tmp126_last || !__tmp126_line.IsEmpty)
                        {
                            __out.Write(__tmp126_line);
                            __tmp123_outputWritten = true;
                        }
                        if (!__tmp126_last) __out.AppendLine(true);
                    }
                    string __tmp127_line = ");"; //212:75
                    if (!string.IsNullOrEmpty(__tmp127_line))
                    {
                        __out.Write(__tmp127_line);
                        __tmp123_outputWritten = true;
                    }
                    if (__tmp123_outputWritten) __out.AppendLine(true);
                    if (__tmp123_outputWritten)
                    {
                        __out.AppendLine(false); //212:77
                    }
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //213:22
                    {
                        __out.Write("                    AddSymbolDiagnostics(diagnostics);"); //214:1
                        __out.AppendLine(false); //214:55
                        __out.Write("                    diagnostics.Free();"); //215:1
                        __out.AppendLine(false); //215:40
                    }
                    bool __tmp129_outputWritten = false;
                    string __tmp130_line = "                    _state.NotePartComplete(CompletionParts."; //217:1
                    if (!string.IsNullOrEmpty(__tmp130_line))
                    {
                        __out.Write(__tmp130_line);
                        __tmp129_outputWritten = true;
                    }
                    var __tmp131 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp131.Write(part.CompletionPartName);
                    var __tmp131Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp131.ToStringAndFree());
                    bool __tmp131_last = __tmp131Reader.EndOfStream;
                    while(!__tmp131_last)
                    {
                        ReadOnlySpan<char> __tmp131_line = __tmp131Reader.ReadLine();
                        __tmp131_last = __tmp131Reader.EndOfStream;
                        if (!__tmp131_last || !__tmp131_line.IsEmpty)
                        {
                            __out.Write(__tmp131_line);
                            __tmp129_outputWritten = true;
                        }
                        if (!__tmp131_last) __out.AppendLine(true);
                    }
                    string __tmp132_line = ");"; //217:86
                    if (!string.IsNullOrEmpty(__tmp132_line))
                    {
                        __out.Write(__tmp132_line);
                        __tmp129_outputWritten = true;
                    }
                    if (__tmp129_outputWritten) __out.AppendLine(true);
                    if (__tmp129_outputWritten)
                    {
                        __out.AppendLine(false); //217:88
                    }
                    __out.Write("                }"); //218:1
                    __out.AppendLine(false); //218:18
                }
            }
            __out.Write("                else if (incompletePart == CompletionGraph.StartComputingNonSymbolProperties || incompletePart == CompletionGraph.FinishComputingNonSymbolProperties)"); //221:1
            __out.AppendLine(false); //221:166
            __out.Write("                {"); //222:1
            __out.AppendLine(false); //222:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartComputingNonSymbolProperties))"); //223:1
            __out.AppendLine(false); //223:100
            __out.Write("                    {"); //224:1
            __out.AppendLine(false); //224:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //225:1
            __out.AppendLine(false); //225:71
            __out.Write("                        CompleteNonSymbolProperties(locationOpt, diagnostics, cancellationToken);"); //226:1
            __out.AppendLine(false); //226:98
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //227:1
            __out.AppendLine(false); //227:59
            __out.Write("                        diagnostics.Free();"); //228:1
            __out.AppendLine(false); //228:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishComputingNonSymbolProperties);"); //229:1
            __out.AppendLine(false); //229:101
            __out.Write("                    }"); //230:1
            __out.AppendLine(false); //230:22
            __out.Write("                }"); //231:1
            __out.AppendLine(false); //231:18
            __out.Write("                else if (incompletePart == CompletionGraph.ChildrenCompleted)"); //232:1
            __out.AppendLine(false); //232:78
            __out.Write("                {"); //233:1
            __out.AppendLine(false); //233:18
            __out.Write("                    var diagnostics = DiagnosticBag.GetInstance();"); //234:1
            __out.AppendLine(false); //234:67
            __out.Write("                    CompleteImports(locationOpt, diagnostics, cancellationToken);"); //235:1
            __out.AppendLine(false); //235:82
            __out.Write("                    AddSymbolDiagnostics(diagnostics);"); //236:1
            __out.AppendLine(false); //236:55
            __out.Write("                    diagnostics.Free();"); //237:1
            __out.AppendLine(false); //237:40
            __out.Write("                    bool allCompleted = true;"); //239:1
            __out.AppendLine(false); //239:46
            __out.Write("                    if (locationOpt == null)"); //240:1
            __out.AppendLine(false); //240:45
            __out.Write("                    {"); //241:1
            __out.AppendLine(false); //241:22
            __out.Write("                        foreach (var child in _childSymbols)"); //242:1
            __out.AppendLine(false); //242:61
            __out.Write("                        {"); //243:1
            __out.AppendLine(false); //243:26
            __out.Write("                            cancellationToken.ThrowIfCancellationRequested();"); //244:1
            __out.AppendLine(false); //244:78
            __out.Write("                            child.ForceComplete(null, locationOpt, cancellationToken);"); //245:1
            __out.AppendLine(false); //245:87
            __out.Write("                        }"); //246:1
            __out.AppendLine(false); //246:26
            __out.Write("                    }"); //247:1
            __out.AppendLine(false); //247:22
            __out.Write("                    else"); //248:1
            __out.AppendLine(false); //248:25
            __out.Write("                    {"); //249:1
            __out.AppendLine(false); //249:22
            __out.Write("                        foreach (var child in _childSymbols)"); //250:1
            __out.AppendLine(false); //250:61
            __out.Write("                        {"); //251:1
            __out.AppendLine(false); //251:26
            __out.Write("                            ForceCompleteChildByLocation(locationOpt, child, cancellationToken);"); //252:1
            __out.AppendLine(false); //252:97
            __out.Write("                            allCompleted = allCompleted && child.HasComplete(CompletionGraph.All);"); //253:1
            __out.AppendLine(false); //253:99
            __out.Write("                        }"); //254:1
            __out.AppendLine(false); //254:26
            __out.Write("                    }"); //255:1
            __out.AppendLine(false); //255:22
            __out.Write("                    if (!allCompleted)"); //257:1
            __out.AppendLine(false); //257:39
            __out.Write("                    {"); //258:1
            __out.AppendLine(false); //258:22
            __out.Write("                        // We did not complete all members, so just kick out now."); //259:1
            __out.AppendLine(false); //259:82
            __out.Write("                        var allParts = CompletionParts.AllWithLocation;"); //260:1
            __out.AppendLine(false); //260:72
            __out.Write("                        _state.SpinWaitComplete(allParts, cancellationToken);"); //261:1
            __out.AppendLine(false); //261:78
            __out.Write("                        return;"); //262:1
            __out.AppendLine(false); //262:32
            __out.Write("                    }"); //263:1
            __out.AppendLine(false); //263:22
            __out.Write("                    // We've completed all members, proceed to the next iteration."); //265:1
            __out.AppendLine(false); //265:83
            __out.Write("                    _state.NotePartComplete(CompletionGraph.ChildrenCompleted);"); //266:1
            __out.AppendLine(false); //266:80
            __out.Write("                }"); //267:1
            __out.AppendLine(false); //267:18
            __out.Write("                if (incompletePart == null)"); //268:1
            __out.AppendLine(false); //268:44
            __out.Write("                {"); //269:1
            __out.AppendLine(false); //269:18
            __out.Write("                    return;"); //270:1
            __out.AppendLine(false); //270:28
            __out.Write("                }"); //271:1
            __out.AppendLine(false); //271:18
            __out.Write("                else"); //272:1
            __out.AppendLine(false); //272:21
            __out.Write("                {"); //273:1
            __out.AppendLine(false); //273:18
            __out.Write("                    // This assert will trigger if we forgot to handle any of the completion parts"); //274:1
            __out.AppendLine(false); //274:99
            __out.Write("                    Debug.Assert(!CompletionParts.All.Contains(incompletePart));"); //275:1
            __out.AppendLine(false); //275:81
            __out.Write("                    // any other values are completion parts intended for other kinds of symbols"); //276:1
            __out.AppendLine(false); //276:97
            __out.Write("                    _state.NotePartComplete(incompletePart);"); //277:1
            __out.AppendLine(false); //277:61
            __out.Write("                }"); //278:1
            __out.AppendLine(false); //278:18
            __out.Write("                if (completionPart != null && _state.HasComplete(completionPart)) return;"); //279:1
            __out.AppendLine(false); //279:90
            __out.Write("                _state.SpinWaitComplete(incompletePart, cancellationToken);"); //280:1
            __out.AppendLine(false); //280:76
            __out.Write("            }"); //281:1
            __out.AppendLine(false); //281:14
            __out.Write("            throw ExceptionUtilities.Unreachable;"); //282:1
            __out.AppendLine(false); //282:50
            __out.Write("        }"); //283:1
            __out.AppendLine(false); //283:10
            __out.AppendLine(true); //284:1
            __out.Write("        protected abstract string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //285:1
            __out.AppendLine(false); //285:127
            __out.Write("        protected abstract void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //286:1
            __out.AppendLine(false); //286:124
            __out.Write("        protected abstract ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //287:1
            __out.AppendLine(false); //287:144
            __out.Write("        protected abstract void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //288:1
            __out.AppendLine(false); //288:141
            var __loop8_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //289:16
                where part.GenerateCompleteMethod //289:44
                select new { part = part}
                ).ToList(); //289:10
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp133 = __loop8_results[__loop8_iteration];
                var part = __tmp133.part;
                bool __tmp135_outputWritten = false;
                string __tmp136_line = "        protected abstract "; //290:1
                if (!string.IsNullOrEmpty(__tmp136_line))
                {
                    __out.Write(__tmp136_line);
                    __tmp135_outputWritten = true;
                }
                var __tmp137 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp137.Write(part.CompleteMethodReturnType);
                var __tmp137Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp137.ToStringAndFree());
                bool __tmp137_last = __tmp137Reader.EndOfStream;
                while(!__tmp137_last)
                {
                    ReadOnlySpan<char> __tmp137_line = __tmp137Reader.ReadLine();
                    __tmp137_last = __tmp137Reader.EndOfStream;
                    if (!__tmp137_last || !__tmp137_line.IsEmpty)
                    {
                        __out.Write(__tmp137_line);
                        __tmp135_outputWritten = true;
                    }
                    if (!__tmp137_last) __out.AppendLine(true);
                }
                string __tmp138_line = " "; //290:59
                if (!string.IsNullOrEmpty(__tmp138_line))
                {
                    __out.Write(__tmp138_line);
                    __tmp135_outputWritten = true;
                }
                var __tmp139 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp139.Write(part.CompleteMethodName);
                var __tmp139Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp139.ToStringAndFree());
                bool __tmp139_last = __tmp139Reader.EndOfStream;
                while(!__tmp139_last)
                {
                    ReadOnlySpan<char> __tmp139_line = __tmp139Reader.ReadLine();
                    __tmp139_last = __tmp139Reader.EndOfStream;
                    if (!__tmp139_last || !__tmp139_line.IsEmpty)
                    {
                        __out.Write(__tmp139_line);
                        __tmp135_outputWritten = true;
                    }
                    if (!__tmp139_last) __out.AppendLine(true);
                }
                string __tmp140_line = "("; //290:85
                if (!string.IsNullOrEmpty(__tmp140_line))
                {
                    __out.Write(__tmp140_line);
                    __tmp135_outputWritten = true;
                }
                var __tmp141 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp141.Write(part.CompleteMethodParamList);
                var __tmp141Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp141.ToStringAndFree());
                bool __tmp141_last = __tmp141Reader.EndOfStream;
                while(!__tmp141_last)
                {
                    ReadOnlySpan<char> __tmp141_line = __tmp141Reader.ReadLine();
                    __tmp141_last = __tmp141Reader.EndOfStream;
                    if (!__tmp141_last || !__tmp141_line.IsEmpty)
                    {
                        __out.Write(__tmp141_line);
                        __tmp135_outputWritten = true;
                    }
                    if (!__tmp141_last) __out.AppendLine(true);
                }
                string __tmp142_line = ");"; //290:116
                if (!string.IsNullOrEmpty(__tmp142_line))
                {
                    __out.Write(__tmp142_line);
                    __tmp135_outputWritten = true;
                }
                if (__tmp135_outputWritten) __out.AppendLine(true);
                if (__tmp135_outputWritten)
                {
                    __out.AppendLine(false); //290:118
                }
            }
            __out.Write("        protected abstract void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //292:1
            __out.AppendLine(false); //292:153
            __out.Write("        #endregion"); //293:1
            __out.AppendLine(false); //293:19
            __out.AppendLine(true); //294:1
            __out.Write("    }"); //295:1
            __out.AppendLine(false); //295:6
            __out.Write("}"); //296:1
            __out.AppendLine(false); //296:2
            return __out.ToStringAndFree();
        }

        public string GenerateMetadataSymbol(SymbolGenerationInfo symbol) //299:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //300:1
            __out.AppendLine(false); //300:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //301:1
            __out.AppendLine(false); //301:29
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //302:1
            __out.AppendLine(false); //302:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //303:1
            __out.AppendLine(false); //303:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //304:1
            __out.AppendLine(false); //304:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //305:1
            __out.AppendLine(false); //305:44
            __out.Write("using System;"); //306:1
            __out.AppendLine(false); //306:14
            __out.Write("using System.Collections.Generic;"); //307:1
            __out.AppendLine(false); //307:34
            __out.Write("using System.Collections.Immutable;"); //308:1
            __out.AppendLine(false); //308:36
            __out.Write("using System.Diagnostics;"); //309:1
            __out.AppendLine(false); //309:26
            __out.Write("using System.Text;"); //310:1
            __out.AppendLine(false); //310:19
            __out.Write("using System.Threading;"); //311:1
            __out.AppendLine(false); //311:24
            __out.AppendLine(true); //312:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //313:1
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
            string __tmp5_line = ".Metadata"; //313:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //313:42
            }
            __out.Write("{"); //314:1
            __out.AppendLine(false); //314:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Metadata"; //315:1
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
            string __tmp10_line = " : "; //315:44
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
            string __tmp12_line = ".Completion.Completion"; //315:69
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
                __out.AppendLine(false); //315:104
            }
            __out.Write("	{"); //316:1
            __out.AppendLine(false); //316:3
            bool __tmp15_outputWritten = false;
            string __tmp16_line = "        public Metadata"; //317:1
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
            string __tmp18_line = "(Symbol container"; //317:37
            if (!string.IsNullOrEmpty(__tmp18_line))
            {
                __out.Write(__tmp18_line);
                __tmp15_outputWritten = true;
            }
            if (symbol.ModelObjectOption != ParameterOption.Disabled) //317:55
            {
                string __tmp20_line = ", object modelObject"; //317:112
                if (!string.IsNullOrEmpty(__tmp20_line))
                {
                    __out.Write(__tmp20_line);
                    __tmp15_outputWritten = true;
                }
                if (symbol.ModelObjectOption == ParameterOption.Optional) //317:133
                {
                    string __tmp22_line = " = null"; //317:190
                    if (!string.IsNullOrEmpty(__tmp22_line))
                    {
                        __out.Write(__tmp22_line);
                        __tmp15_outputWritten = true;
                    }
                }
            }
            string __tmp25_line = ")"; //317:213
            if (!string.IsNullOrEmpty(__tmp25_line))
            {
                __out.Write(__tmp25_line);
                __tmp15_outputWritten = true;
            }
            if (__tmp15_outputWritten) __out.AppendLine(true);
            if (__tmp15_outputWritten)
            {
                __out.AppendLine(false); //317:214
            }
            __out.Write("            : base(container, modelObject)"); //318:1
            __out.AppendLine(false); //318:43
            __out.Write("        {"); //319:1
            __out.AppendLine(false); //319:10
            __out.Write("        }"); //320:1
            __out.AppendLine(false); //320:10
            __out.AppendLine(true); //321:1
            __out.Write("        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;"); //322:1
            __out.AppendLine(false); //322:95
            __out.AppendLine(true); //323:1
            __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;"); //324:1
            __out.AppendLine(false); //324:124
            __out.AppendLine(true); //325:1
            __out.Write("        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //326:1
            __out.AppendLine(false); //326:126
            __out.Write("        {"); //327:1
            __out.AppendLine(false); //327:10
            __out.Write("            return ModelSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //328:1
            __out.AppendLine(false); //328:132
            __out.Write("        }"); //329:1
            __out.AppendLine(false); //329:10
            __out.AppendLine(true); //330:1
            __out.Write("        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //331:1
            __out.AppendLine(false); //331:123
            __out.Write("        {"); //332:1
            __out.AppendLine(false); //332:10
            __out.Write("        }"); //333:1
            __out.AppendLine(false); //333:10
            __out.AppendLine(true); //334:1
            __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //335:1
            __out.AppendLine(false); //335:143
            __out.Write("        {"); //336:1
            __out.AppendLine(false); //336:10
            __out.Write("            return ModelSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //337:1
            __out.AppendLine(false); //337:123
            __out.Write("        }"); //338:1
            __out.AppendLine(false); //338:10
            __out.AppendLine(true); //339:1
            __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //340:1
            __out.AppendLine(false); //340:140
            __out.Write("        {"); //341:1
            __out.AppendLine(false); //341:10
            __out.Write("        }"); //342:1
            __out.AppendLine(false); //342:10
            __out.AppendLine(true); //343:1
            var __loop9_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //344:16
                where part.GenerateCompleteMethod //344:44
                select new { part = part}
                ).ToList(); //344:10
            for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
            {
                var __tmp26 = __loop9_results[__loop9_iteration];
                var part = __tmp26.part;
                bool __tmp28_outputWritten = false;
                string __tmp29_line = "        protected override "; //345:1
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Write(__tmp29_line);
                    __tmp28_outputWritten = true;
                }
                var __tmp30 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp30.Write(part.CompleteMethodReturnType);
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
                string __tmp31_line = " "; //345:59
                if (!string.IsNullOrEmpty(__tmp31_line))
                {
                    __out.Write(__tmp31_line);
                    __tmp28_outputWritten = true;
                }
                var __tmp32 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp32.Write(part.CompleteMethodName);
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
                string __tmp33_line = "("; //345:85
                if (!string.IsNullOrEmpty(__tmp33_line))
                {
                    __out.Write(__tmp33_line);
                    __tmp28_outputWritten = true;
                }
                var __tmp34 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp34.Write(part.CompleteMethodParamList);
                var __tmp34Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp34.ToStringAndFree());
                bool __tmp34_last = __tmp34Reader.EndOfStream;
                while(!__tmp34_last)
                {
                    ReadOnlySpan<char> __tmp34_line = __tmp34Reader.ReadLine();
                    __tmp34_last = __tmp34Reader.EndOfStream;
                    if (!__tmp34_last || !__tmp34_line.IsEmpty)
                    {
                        __out.Write(__tmp34_line);
                        __tmp28_outputWritten = true;
                    }
                    if (!__tmp34_last) __out.AppendLine(true);
                }
                string __tmp35_line = ")"; //345:116
                if (!string.IsNullOrEmpty(__tmp35_line))
                {
                    __out.Write(__tmp35_line);
                    __tmp28_outputWritten = true;
                }
                if (__tmp28_outputWritten) __out.AppendLine(true);
                if (__tmp28_outputWritten)
                {
                    __out.AppendLine(false); //345:117
                }
                __out.Write("        {"); //346:1
                __out.AppendLine(false); //346:10
                if (part is SymbolPropertyGenerationInfo) //347:14
                {
                    var prop = (SymbolPropertyGenerationInfo)part; //348:18
                    if (prop.IsCollection) //349:18
                    {
                        bool __tmp37_outputWritten = false;
                        string __tmp38_line = "            return ModelSymbolImplementation.AssignSymbolPropertyValues<"; //350:1
                        if (!string.IsNullOrEmpty(__tmp38_line))
                        {
                            __out.Write(__tmp38_line);
                            __tmp37_outputWritten = true;
                        }
                        var __tmp39 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp39.Write(prop.ItemType);
                        var __tmp39Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp39.ToStringAndFree());
                        bool __tmp39_last = __tmp39Reader.EndOfStream;
                        while(!__tmp39_last)
                        {
                            ReadOnlySpan<char> __tmp39_line = __tmp39Reader.ReadLine();
                            __tmp39_last = __tmp39Reader.EndOfStream;
                            if (!__tmp39_last || !__tmp39_line.IsEmpty)
                            {
                                __out.Write(__tmp39_line);
                                __tmp37_outputWritten = true;
                            }
                            if (!__tmp39_last) __out.AppendLine(true);
                        }
                        string __tmp40_line = ">(this, nameof("; //350:88
                        if (!string.IsNullOrEmpty(__tmp40_line))
                        {
                            __out.Write(__tmp40_line);
                            __tmp37_outputWritten = true;
                        }
                        var __tmp41 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp41.Write(prop.Name);
                        var __tmp41Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp41.ToStringAndFree());
                        bool __tmp41_last = __tmp41Reader.EndOfStream;
                        while(!__tmp41_last)
                        {
                            ReadOnlySpan<char> __tmp41_line = __tmp41Reader.ReadLine();
                            __tmp41_last = __tmp41Reader.EndOfStream;
                            if (!__tmp41_last || !__tmp41_line.IsEmpty)
                            {
                                __out.Write(__tmp41_line);
                                __tmp37_outputWritten = true;
                            }
                            if (!__tmp41_last) __out.AppendLine(true);
                        }
                        string __tmp42_line = "), diagnostics, cancellationToken);"; //350:114
                        if (!string.IsNullOrEmpty(__tmp42_line))
                        {
                            __out.Write(__tmp42_line);
                            __tmp37_outputWritten = true;
                        }
                        if (__tmp37_outputWritten) __out.AppendLine(true);
                        if (__tmp37_outputWritten)
                        {
                            __out.AppendLine(false); //350:149
                        }
                    }
                    else //351:18
                    {
                        bool __tmp44_outputWritten = false;
                        string __tmp45_line = "            return ModelSymbolImplementation.AssignSymbolPropertyValue<"; //352:1
                        if (!string.IsNullOrEmpty(__tmp45_line))
                        {
                            __out.Write(__tmp45_line);
                            __tmp44_outputWritten = true;
                        }
                        var __tmp46 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp46.Write(prop.Type);
                        var __tmp46Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp46.ToStringAndFree());
                        bool __tmp46_last = __tmp46Reader.EndOfStream;
                        while(!__tmp46_last)
                        {
                            ReadOnlySpan<char> __tmp46_line = __tmp46Reader.ReadLine();
                            __tmp46_last = __tmp46Reader.EndOfStream;
                            if (!__tmp46_last || !__tmp46_line.IsEmpty)
                            {
                                __out.Write(__tmp46_line);
                                __tmp44_outputWritten = true;
                            }
                            if (!__tmp46_last) __out.AppendLine(true);
                        }
                        string __tmp47_line = ">(this, nameof("; //352:83
                        if (!string.IsNullOrEmpty(__tmp47_line))
                        {
                            __out.Write(__tmp47_line);
                            __tmp44_outputWritten = true;
                        }
                        var __tmp48 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp48.Write(prop.Name);
                        var __tmp48Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp48.ToStringAndFree());
                        bool __tmp48_last = __tmp48Reader.EndOfStream;
                        while(!__tmp48_last)
                        {
                            ReadOnlySpan<char> __tmp48_line = __tmp48Reader.ReadLine();
                            __tmp48_last = __tmp48Reader.EndOfStream;
                            if (!__tmp48_last || !__tmp48_line.IsEmpty)
                            {
                                __out.Write(__tmp48_line);
                                __tmp44_outputWritten = true;
                            }
                            if (!__tmp48_last) __out.AppendLine(true);
                        }
                        string __tmp49_line = "), diagnostics, cancellationToken);"; //352:109
                        if (!string.IsNullOrEmpty(__tmp49_line))
                        {
                            __out.Write(__tmp49_line);
                            __tmp44_outputWritten = true;
                        }
                        if (__tmp44_outputWritten) __out.AppendLine(true);
                        if (__tmp44_outputWritten)
                        {
                            __out.AppendLine(false); //352:144
                        }
                    }
                }
                __out.Write("        }"); //355:1
                __out.AppendLine(false); //355:10
            }
            __out.AppendLine(true); //357:1
            __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //358:1
            __out.AppendLine(false); //358:152
            __out.Write("        {"); //359:1
            __out.AppendLine(false); //359:10
            __out.Write("        }"); //360:1
            __out.AppendLine(false); //360:10
            __out.Write("    }"); //361:1
            __out.AppendLine(false); //361:6
            __out.Write("}"); //362:1
            __out.AppendLine(false); //362:2
            return __out.ToStringAndFree();
        }

        public string GenerateSourceSymbol(SymbolGenerationInfo symbol) //365:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //366:1
            __out.AppendLine(false); //366:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //367:1
            __out.AppendLine(false); //367:29
            __out.Write("using MetaDslx.CodeAnalysis.Binding;"); //368:1
            __out.AppendLine(false); //368:37
            __out.Write("using MetaDslx.CodeAnalysis.Binding.Binders;"); //369:1
            __out.AppendLine(false); //369:45
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //370:1
            __out.AppendLine(false); //370:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //371:1
            __out.AppendLine(false); //371:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //372:1
            __out.AppendLine(false); //372:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //373:1
            __out.AppendLine(false); //373:44
            __out.Write("using System;"); //374:1
            __out.AppendLine(false); //374:14
            __out.Write("using System.Collections.Generic;"); //375:1
            __out.AppendLine(false); //375:34
            __out.Write("using System.Collections.Immutable;"); //376:1
            __out.AppendLine(false); //376:36
            __out.Write("using System.Diagnostics;"); //377:1
            __out.AppendLine(false); //377:26
            __out.Write("using System.Linq;"); //378:1
            __out.AppendLine(false); //378:19
            __out.Write("using System.Text;"); //379:1
            __out.AppendLine(false); //379:19
            __out.Write("using System.Threading;"); //380:1
            __out.AppendLine(false); //380:24
            __out.AppendLine(true); //381:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //382:1
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
            string __tmp5_line = ".Source"; //382:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //382:40
            }
            __out.Write("{"); //383:1
            __out.AppendLine(false); //383:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Source"; //384:1
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
            string __tmp10_line = " : "; //384:42
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
            string __tmp12_line = ".Completion.Completion"; //384:67
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
            string __tmp14_line = ", MetaDslx.CodeAnalysis.Symbols.Source.ISourceSymbol"; //384:102
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp7_outputWritten = true;
            }
            if (__tmp7_outputWritten) __out.AppendLine(true);
            if (__tmp7_outputWritten)
            {
                __out.AppendLine(false); //384:154
            }
            __out.Write("	{"); //385:1
            __out.AppendLine(false); //385:3
            __out.Write("        private readonly MergedDeclaration _declaration;"); //386:1
            __out.AppendLine(false); //386:57
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "		public Source"; //388:1
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
            string __tmp19_line = "(Symbol containingSymbol, "; //388:29
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Write(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            if (symbol.ModelObjectOption != ParameterOption.Disabled) //388:56
            {
                string __tmp21_line = "object modelObject"; //388:113
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Write(__tmp21_line);
                    __tmp16_outputWritten = true;
                }
                if (symbol.ModelObjectOption == ParameterOption.Optional) //388:132
                {
                    string __tmp23_line = " = null"; //388:189
                    if (!string.IsNullOrEmpty(__tmp23_line))
                    {
                        __out.Write(__tmp23_line);
                        __tmp16_outputWritten = true;
                    }
                }
                string __tmp25_line = ", "; //388:204
                if (!string.IsNullOrEmpty(__tmp25_line))
                {
                    __out.Write(__tmp25_line);
                    __tmp16_outputWritten = true;
                }
            }
            string __tmp27_line = "MergedDeclaration declaration)"; //388:214
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Write(__tmp27_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //388:244
            }
            __out.Write("            : base(containingSymbol, modelObject)"); //389:1
            __out.AppendLine(false); //389:50
            __out.Write("        {"); //390:1
            __out.AppendLine(false); //390:10
            __out.Write("            if (declaration is null) throw new ArgumentNullException(nameof(declaration));"); //391:1
            __out.AppendLine(false); //391:91
            __out.Write("            _declaration = declaration;"); //392:1
            __out.AppendLine(false); //392:40
            __out.Write("		}"); //393:1
            __out.AppendLine(false); //393:4
            __out.AppendLine(true); //394:1
            __out.Write("        public MergedDeclaration MergedDeclaration => _declaration;"); //395:1
            __out.AppendLine(false); //395:68
            __out.AppendLine(true); //396:1
            __out.Write("        public override ImmutableArray<Location> Locations => _declaration.NameLocations;"); //397:1
            __out.AppendLine(false); //397:90
            __out.AppendLine(true); //398:1
            __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration.SyntaxReferences;"); //399:1
            __out.AppendLine(false); //399:116
            __out.AppendLine(true); //400:1
            __out.Write("        public BinderPosition<SymbolBinder> GetBinder(SyntaxReference reference)"); //401:1
            __out.AppendLine(false); //401:81
            __out.Write("        {"); //402:1
            __out.AppendLine(false); //402:10
            __out.Write("            Debug.Assert(this.DeclaringSyntaxReferences.Contains(reference));"); //403:1
            __out.AppendLine(false); //403:78
            __out.Write("            return FindBinders.FindSymbolBinder(this, reference);"); //404:1
            __out.AppendLine(false); //404:66
            __out.Write("        }"); //405:1
            __out.AppendLine(false); //405:10
            __out.AppendLine(true); //406:1
            __out.Write("        public Symbol GetChildSymbol(SyntaxReference syntax)"); //407:1
            __out.AppendLine(false); //407:61
            __out.Write("        {"); //408:1
            __out.AppendLine(false); //408:10
            __out.Write("            foreach (var child in this.ChildSymbols)"); //409:1
            __out.AppendLine(false); //409:53
            __out.Write("            {"); //410:1
            __out.AppendLine(false); //410:14
            __out.Write("                if (child.DeclaringSyntaxReferences.Any(sr => sr.GetLocation() == syntax.GetLocation()))"); //411:1
            __out.AppendLine(false); //411:105
            __out.Write("                {"); //412:1
            __out.AppendLine(false); //412:18
            __out.Write("                    return child;"); //413:1
            __out.AppendLine(false); //413:34
            __out.Write("                }"); //414:1
            __out.AppendLine(false); //414:18
            __out.Write("            }"); //415:1
            __out.AppendLine(false); //415:14
            __out.Write("            return null;"); //416:1
            __out.AppendLine(false); //416:25
            __out.Write("        }"); //417:1
            __out.AppendLine(false); //417:10
            __out.AppendLine(true); //418:1
            __out.Write("        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //419:1
            __out.AppendLine(false); //419:123
            __out.Write("        {"); //420:1
            __out.AppendLine(false); //420:10
            __out.Write("        }"); //421:1
            __out.AppendLine(false); //421:10
            __out.AppendLine(true); //422:1
            __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //423:1
            __out.AppendLine(false); //423:143
            __out.Write("        {"); //424:1
            __out.AppendLine(false); //424:10
            __out.Write("            return SourceSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //425:1
            __out.AppendLine(false); //425:124
            __out.Write("        }"); //426:1
            __out.AppendLine(false); //426:10
            __out.AppendLine(true); //427:1
            __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //428:1
            __out.AppendLine(false); //428:140
            __out.Write("        {"); //429:1
            __out.AppendLine(false); //429:10
            __out.Write("            SourceSymbolImplementation.CompleteImports(this, locationOpt, diagnostics, cancellationToken);"); //430:1
            __out.AppendLine(false); //430:107
            __out.Write("        }"); //431:1
            __out.AppendLine(false); //431:10
            __out.AppendLine(true); //432:1
            __out.Write("        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //433:1
            __out.AppendLine(false); //433:126
            __out.Write("        {"); //434:1
            __out.AppendLine(false); //434:10
            __out.Write("            return SourceSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //435:1
            __out.AppendLine(false); //435:133
            __out.Write("        }"); //436:1
            __out.AppendLine(false); //436:10
            __out.AppendLine(true); //437:1
            var __loop10_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //438:16
                where part.GenerateCompleteMethod //438:44
                select new { part = part}
                ).ToList(); //438:10
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                var __tmp28 = __loop10_results[__loop10_iteration];
                var part = __tmp28.part;
                bool __tmp30_outputWritten = false;
                string __tmp31_line = "        protected override "; //439:1
                if (!string.IsNullOrEmpty(__tmp31_line))
                {
                    __out.Write(__tmp31_line);
                    __tmp30_outputWritten = true;
                }
                var __tmp32 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp32.Write(part.CompleteMethodReturnType);
                var __tmp32Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp32.ToStringAndFree());
                bool __tmp32_last = __tmp32Reader.EndOfStream;
                while(!__tmp32_last)
                {
                    ReadOnlySpan<char> __tmp32_line = __tmp32Reader.ReadLine();
                    __tmp32_last = __tmp32Reader.EndOfStream;
                    if (!__tmp32_last || !__tmp32_line.IsEmpty)
                    {
                        __out.Write(__tmp32_line);
                        __tmp30_outputWritten = true;
                    }
                    if (!__tmp32_last) __out.AppendLine(true);
                }
                string __tmp33_line = " "; //439:59
                if (!string.IsNullOrEmpty(__tmp33_line))
                {
                    __out.Write(__tmp33_line);
                    __tmp30_outputWritten = true;
                }
                var __tmp34 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp34.Write(part.CompleteMethodName);
                var __tmp34Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp34.ToStringAndFree());
                bool __tmp34_last = __tmp34Reader.EndOfStream;
                while(!__tmp34_last)
                {
                    ReadOnlySpan<char> __tmp34_line = __tmp34Reader.ReadLine();
                    __tmp34_last = __tmp34Reader.EndOfStream;
                    if (!__tmp34_last || !__tmp34_line.IsEmpty)
                    {
                        __out.Write(__tmp34_line);
                        __tmp30_outputWritten = true;
                    }
                    if (!__tmp34_last) __out.AppendLine(true);
                }
                string __tmp35_line = "("; //439:85
                if (!string.IsNullOrEmpty(__tmp35_line))
                {
                    __out.Write(__tmp35_line);
                    __tmp30_outputWritten = true;
                }
                var __tmp36 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp36.Write(part.CompleteMethodParamList);
                var __tmp36Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp36.ToStringAndFree());
                bool __tmp36_last = __tmp36Reader.EndOfStream;
                while(!__tmp36_last)
                {
                    ReadOnlySpan<char> __tmp36_line = __tmp36Reader.ReadLine();
                    __tmp36_last = __tmp36Reader.EndOfStream;
                    if (!__tmp36_last || !__tmp36_line.IsEmpty)
                    {
                        __out.Write(__tmp36_line);
                        __tmp30_outputWritten = true;
                    }
                    if (!__tmp36_last) __out.AppendLine(true);
                }
                string __tmp37_line = ")"; //439:116
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Write(__tmp37_line);
                    __tmp30_outputWritten = true;
                }
                if (__tmp30_outputWritten) __out.AppendLine(true);
                if (__tmp30_outputWritten)
                {
                    __out.AppendLine(false); //439:117
                }
                __out.Write("        {"); //440:1
                __out.AppendLine(false); //440:10
                if (part is SymbolPropertyGenerationInfo) //441:14
                {
                    var prop = (SymbolPropertyGenerationInfo)part; //442:18
                    if (prop.IsCollection) //443:18
                    {
                        bool __tmp39_outputWritten = false;
                        string __tmp40_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValues<"; //444:1
                        if (!string.IsNullOrEmpty(__tmp40_line))
                        {
                            __out.Write(__tmp40_line);
                            __tmp39_outputWritten = true;
                        }
                        var __tmp41 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp41.Write(prop.ItemType);
                        var __tmp41Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp41.ToStringAndFree());
                        bool __tmp41_last = __tmp41Reader.EndOfStream;
                        while(!__tmp41_last)
                        {
                            ReadOnlySpan<char> __tmp41_line = __tmp41Reader.ReadLine();
                            __tmp41_last = __tmp41Reader.EndOfStream;
                            if (!__tmp41_last || !__tmp41_line.IsEmpty)
                            {
                                __out.Write(__tmp41_line);
                                __tmp39_outputWritten = true;
                            }
                            if (!__tmp41_last) __out.AppendLine(true);
                        }
                        string __tmp42_line = ">(this, nameof("; //444:89
                        if (!string.IsNullOrEmpty(__tmp42_line))
                        {
                            __out.Write(__tmp42_line);
                            __tmp39_outputWritten = true;
                        }
                        var __tmp43 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp43.Write(prop.Name);
                        var __tmp43Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp43.ToStringAndFree());
                        bool __tmp43_last = __tmp43Reader.EndOfStream;
                        while(!__tmp43_last)
                        {
                            ReadOnlySpan<char> __tmp43_line = __tmp43Reader.ReadLine();
                            __tmp43_last = __tmp43Reader.EndOfStream;
                            if (!__tmp43_last || !__tmp43_line.IsEmpty)
                            {
                                __out.Write(__tmp43_line);
                                __tmp39_outputWritten = true;
                            }
                            if (!__tmp43_last) __out.AppendLine(true);
                        }
                        string __tmp44_line = "), diagnostics, cancellationToken);"; //444:115
                        if (!string.IsNullOrEmpty(__tmp44_line))
                        {
                            __out.Write(__tmp44_line);
                            __tmp39_outputWritten = true;
                        }
                        if (__tmp39_outputWritten) __out.AppendLine(true);
                        if (__tmp39_outputWritten)
                        {
                            __out.AppendLine(false); //444:150
                        }
                    }
                    else //445:18
                    {
                        bool __tmp46_outputWritten = false;
                        string __tmp47_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValue<"; //446:1
                        if (!string.IsNullOrEmpty(__tmp47_line))
                        {
                            __out.Write(__tmp47_line);
                            __tmp46_outputWritten = true;
                        }
                        var __tmp48 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp48.Write(prop.Type);
                        var __tmp48Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp48.ToStringAndFree());
                        bool __tmp48_last = __tmp48Reader.EndOfStream;
                        while(!__tmp48_last)
                        {
                            ReadOnlySpan<char> __tmp48_line = __tmp48Reader.ReadLine();
                            __tmp48_last = __tmp48Reader.EndOfStream;
                            if (!__tmp48_last || !__tmp48_line.IsEmpty)
                            {
                                __out.Write(__tmp48_line);
                                __tmp46_outputWritten = true;
                            }
                            if (!__tmp48_last) __out.AppendLine(true);
                        }
                        string __tmp49_line = ">(this, nameof("; //446:84
                        if (!string.IsNullOrEmpty(__tmp49_line))
                        {
                            __out.Write(__tmp49_line);
                            __tmp46_outputWritten = true;
                        }
                        var __tmp50 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp50.Write(prop.Name);
                        var __tmp50Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp50.ToStringAndFree());
                        bool __tmp50_last = __tmp50Reader.EndOfStream;
                        while(!__tmp50_last)
                        {
                            ReadOnlySpan<char> __tmp50_line = __tmp50Reader.ReadLine();
                            __tmp50_last = __tmp50Reader.EndOfStream;
                            if (!__tmp50_last || !__tmp50_line.IsEmpty)
                            {
                                __out.Write(__tmp50_line);
                                __tmp46_outputWritten = true;
                            }
                            if (!__tmp50_last) __out.AppendLine(true);
                        }
                        string __tmp51_line = "), diagnostics, cancellationToken);"; //446:110
                        if (!string.IsNullOrEmpty(__tmp51_line))
                        {
                            __out.Write(__tmp51_line);
                            __tmp46_outputWritten = true;
                        }
                        if (__tmp46_outputWritten) __out.AppendLine(true);
                        if (__tmp46_outputWritten)
                        {
                            __out.AppendLine(false); //446:145
                        }
                    }
                }
                __out.Write("        }"); //449:1
                __out.AppendLine(false); //449:10
            }
            __out.AppendLine(true); //451:1
            __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //452:1
            __out.AppendLine(false); //452:152
            __out.Write("        {"); //453:1
            __out.AppendLine(false); //453:10
            __out.Write("            SourceSymbolImplementation.AssignNonSymbolProperties(this, diagnostics, cancellationToken);"); //454:1
            __out.AppendLine(false); //454:104
            __out.Write("        }"); //455:1
            __out.AppendLine(false); //455:10
            __out.AppendLine(true); //456:1
            __out.Write("	}"); //457:1
            __out.AppendLine(false); //457:3
            __out.Write("}"); //458:1
            __out.AppendLine(false); //458:2
            return __out.ToStringAndFree();
        }

        public string GenerateVisitor(string namespaceName, IEnumerable<SymbolGenerationInfo> symbols) //461:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //462:1
            __out.AppendLine(false); //462:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //463:1
            __out.AppendLine(false); //463:29
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //464:1
            __out.AppendLine(false); //464:37
            __out.Write("using System;"); //465:1
            __out.AppendLine(false); //465:14
            __out.Write("using System.Collections.Generic;"); //466:1
            __out.AppendLine(false); //466:34
            __out.Write("using System.Collections.Immutable;"); //467:1
            __out.AppendLine(false); //467:36
            __out.Write("using System.Diagnostics;"); //468:1
            __out.AppendLine(false); //468:26
            __out.Write("using System.Text;"); //469:1
            __out.AppendLine(false); //469:19
            __out.Write("using System.Threading;"); //470:1
            __out.AppendLine(false); //470:24
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //472:1
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
                __out.AppendLine(false); //472:26
            }
            __out.Write("{"); //473:1
            __out.AppendLine(false); //473:2
            __out.Write("	public interface ISymbolVisitor"); //474:1
            __out.AppendLine(false); //474:33
            __out.Write("	{"); //475:1
            __out.AppendLine(false); //475:3
            var __loop11_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //476:16
                select new { symbol = symbol}
                ).ToList(); //476:10
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp5 = __loop11_results[__loop11_iteration];
                var symbol = __tmp5.symbol;
                bool __tmp7_outputWritten = false;
                string __tmp8_line = "        void Visit("; //477:1
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
                string __tmp10_line = " symbol);"; //477:33
                if (!string.IsNullOrEmpty(__tmp10_line))
                {
                    __out.Write(__tmp10_line);
                    __tmp7_outputWritten = true;
                }
                if (__tmp7_outputWritten) __out.AppendLine(true);
                if (__tmp7_outputWritten)
                {
                    __out.AppendLine(false); //477:42
                }
            }
            __out.Write("	}"); //479:1
            __out.AppendLine(false); //479:3
            __out.AppendLine(true); //480:1
            __out.Write("	public interface ISymbolVisitor<TResult>"); //481:1
            __out.AppendLine(false); //481:42
            __out.Write("	{"); //482:1
            __out.AppendLine(false); //482:3
            var __loop12_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //483:16
                select new { symbol = symbol}
                ).ToList(); //483:10
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp11 = __loop12_results[__loop12_iteration];
                var symbol = __tmp11.symbol;
                bool __tmp13_outputWritten = false;
                string __tmp14_line = "        TResult Visit("; //484:1
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
                string __tmp16_line = " symbol);"; //484:36
                if (!string.IsNullOrEmpty(__tmp16_line))
                {
                    __out.Write(__tmp16_line);
                    __tmp13_outputWritten = true;
                }
                if (__tmp13_outputWritten) __out.AppendLine(true);
                if (__tmp13_outputWritten)
                {
                    __out.AppendLine(false); //484:45
                }
            }
            __out.Write("	}"); //486:1
            __out.AppendLine(false); //486:3
            __out.AppendLine(true); //487:1
            __out.Write("	public interface ISymbolVisitor<TArgument, TResult>"); //488:1
            __out.AppendLine(false); //488:53
            __out.Write("	{"); //489:1
            __out.AppendLine(false); //489:3
            var __loop13_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //490:16
                select new { symbol = symbol}
                ).ToList(); //490:10
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp17 = __loop13_results[__loop13_iteration];
                var symbol = __tmp17.symbol;
                bool __tmp19_outputWritten = false;
                string __tmp20_line = "        TResult Visit("; //491:1
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
                string __tmp22_line = " symbol, TArgument argument);"; //491:36
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Write(__tmp22_line);
                    __tmp19_outputWritten = true;
                }
                if (__tmp19_outputWritten) __out.AppendLine(true);
                if (__tmp19_outputWritten)
                {
                    __out.AppendLine(false); //491:65
                }
            }
            __out.Write("	}"); //493:1
            __out.AppendLine(false); //493:3
            __out.Write("}"); //494:1
            __out.AppendLine(false); //494:2
            return __out.ToStringAndFree();
        }

    }
}

