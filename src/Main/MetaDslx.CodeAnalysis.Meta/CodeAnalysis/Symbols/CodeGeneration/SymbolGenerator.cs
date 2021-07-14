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
            if (symbol.ExistingCompletionBaseType == null) //73:56
            {
                string __tmp11_line = " : "; //73:103
                if (!string.IsNullOrEmpty(__tmp11_line))
                {
                    __out.Write(__tmp11_line);
                    __tmp7_outputWritten = true;
                }
                var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp12.Write(symbol.NamespaceName);
                var __tmp12Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp12.ToStringAndFree());
                bool __tmp12_last = __tmp12Reader.EndOfStream;
                while(!__tmp12_last)
                {
                    ReadOnlySpan<char> __tmp12_line = __tmp12Reader.ReadLine();
                    __tmp12_last = __tmp12Reader.EndOfStream;
                    if (!__tmp12_last || !__tmp12_line.IsEmpty)
                    {
                        __out.Write(__tmp12_line);
                        __tmp7_outputWritten = true;
                    }
                    if (!__tmp12_last) __out.AppendLine(true);
                }
                string __tmp13_line = "."; //73:128
                if (!string.IsNullOrEmpty(__tmp13_line))
                {
                    __out.Write(__tmp13_line);
                    __tmp7_outputWritten = true;
                }
                var __tmp14 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp14.Write(symbol.Name);
                var __tmp14Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp14.ToStringAndFree());
                bool __tmp14_last = __tmp14Reader.EndOfStream;
                while(!__tmp14_last)
                {
                    ReadOnlySpan<char> __tmp14_line = __tmp14Reader.ReadLine();
                    __tmp14_last = __tmp14Reader.EndOfStream;
                    if (!__tmp14_last || !__tmp14_line.IsEmpty)
                    {
                        __out.Write(__tmp14_line);
                        __tmp7_outputWritten = true;
                    }
                    if (!__tmp14_last) __out.AppendLine(true);
                }
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //73:143
                {
                    string __tmp16_line = ", MetaDslx.CodeAnalysis.Symbols.Metadata.IModelSymbol"; //73:200
                    if (!string.IsNullOrEmpty(__tmp16_line))
                    {
                        __out.Write(__tmp16_line);
                        __tmp7_outputWritten = true;
                    }
                }
            }
            if (__tmp7_outputWritten) __out.AppendLine(true);
            if (__tmp7_outputWritten)
            {
                __out.AppendLine(false); //73:269
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
                var __tmp19 = __loop1_results[__loop1_iteration];
                var partName = __tmp19.partName;
                bool __tmp21_outputWritten = false;
                string __tmp22_line = "            public static readonly CompletionPart "; //78:1
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Write(__tmp22_line);
                    __tmp21_outputWritten = true;
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
                        __tmp21_outputWritten = true;
                    }
                    if (!__tmp23_last) __out.AppendLine(true);
                }
                string __tmp24_line = " = new CompletionPart(nameof("; //78:61
                if (!string.IsNullOrEmpty(__tmp24_line))
                {
                    __out.Write(__tmp24_line);
                    __tmp21_outputWritten = true;
                }
                var __tmp25 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp25.Write(partName);
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
                string __tmp26_line = "));"; //78:100
                if (!string.IsNullOrEmpty(__tmp26_line))
                {
                    __out.Write(__tmp26_line);
                    __tmp21_outputWritten = true;
                }
                if (__tmp21_outputWritten) __out.AppendLine(true);
                if (__tmp21_outputWritten)
                {
                    __out.AppendLine(false); //78:103
                }
            }
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "            public static readonly ImmutableHashSet<CompletionPart> AllWithLocation = CompletionPart.Combine("; //80:1
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Write(__tmp29_line);
                __tmp28_outputWritten = true;
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
                var __tmp31 = __loop2_results[__loop2_iteration];
                var partName = __tmp31.partName;
                var __tmp32 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp32.Write(partName);
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
                var __tmp33 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp33.Write(comma);
                var __tmp33Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp33.ToStringAndFree());
                bool __tmp33_last = __tmp33Reader.EndOfStream;
                while(!__tmp33_last)
                {
                    ReadOnlySpan<char> __tmp33_line = __tmp33Reader.ReadLine();
                    __tmp33_last = __tmp33Reader.EndOfStream;
                    if (!__tmp33_last || !__tmp33_line.IsEmpty)
                    {
                        __out.Write(__tmp33_line);
                        __tmp28_outputWritten = true;
                    }
                    if (!__tmp33_last) __out.AppendLine(true);
                }
            }
            string __tmp35_line = ");"; //80:217
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Write(__tmp35_line);
                __tmp28_outputWritten = true;
            }
            if (__tmp28_outputWritten) __out.AppendLine(true);
            if (__tmp28_outputWritten)
            {
                __out.AppendLine(false); //80:219
            }
            bool __tmp37_outputWritten = false;
            string __tmp38_line = "            public static readonly ImmutableHashSet<CompletionPart> All = CompletionPart.Combine("; //81:1
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Write(__tmp38_line);
                __tmp37_outputWritten = true;
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
                var __tmp40 = __loop3_results[__loop3_iteration];
                var partName = __tmp40.partName;
                var __tmp41 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp41.Write(partName);
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
                var __tmp42 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp42.Write(comma);
                var __tmp42Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp42.ToStringAndFree());
                bool __tmp42_last = __tmp42Reader.EndOfStream;
                while(!__tmp42_last)
                {
                    ReadOnlySpan<char> __tmp42_line = __tmp42Reader.ReadLine();
                    __tmp42_last = __tmp42Reader.EndOfStream;
                    if (!__tmp42_last || !__tmp42_line.IsEmpty)
                    {
                        __out.Write(__tmp42_line);
                        __tmp37_outputWritten = true;
                    }
                    if (!__tmp42_last) __out.AppendLine(true);
                }
            }
            string __tmp44_line = ");"; //81:206
            if (!string.IsNullOrEmpty(__tmp44_line))
            {
                __out.Write(__tmp44_line);
                __tmp37_outputWritten = true;
            }
            if (__tmp37_outputWritten) __out.AppendLine(true);
            if (__tmp37_outputWritten)
            {
                __out.AppendLine(false); //81:208
            }
            bool __tmp46_outputWritten = false;
            string __tmp47_line = "            public static readonly CompletionGraph CompletionGraph = CompletionGraph.FromCompletionParts("; //82:1
            if (!string.IsNullOrEmpty(__tmp47_line))
            {
                __out.Write(__tmp47_line);
                __tmp46_outputWritten = true;
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
                var __tmp49 = __loop4_results[__loop4_iteration];
                var partName = __tmp49.partName;
                var __tmp50 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp50.Write(partName);
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
                var __tmp51 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp51.Write(comma);
                var __tmp51Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp51.ToStringAndFree());
                bool __tmp51_last = __tmp51Reader.EndOfStream;
                while(!__tmp51_last)
                {
                    ReadOnlySpan<char> __tmp51_line = __tmp51Reader.ReadLine();
                    __tmp51_last = __tmp51Reader.EndOfStream;
                    if (!__tmp51_last || !__tmp51_line.IsEmpty)
                    {
                        __out.Write(__tmp51_line);
                        __tmp46_outputWritten = true;
                    }
                    if (!__tmp51_last) __out.AppendLine(true);
                }
            }
            string __tmp53_line = ");"; //82:214
            if (!string.IsNullOrEmpty(__tmp53_line))
            {
                __out.Write(__tmp53_line);
                __tmp46_outputWritten = true;
            }
            if (__tmp46_outputWritten) __out.AppendLine(true);
            if (__tmp46_outputWritten)
            {
                __out.AppendLine(false); //82:216
            }
            __out.Write("        }"); //83:1
            __out.AppendLine(false); //83:10
            __out.AppendLine(true); //84:1
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //85:10
            {
                __out.Write("        private readonly Symbol _container;"); //86:1
                __out.AppendLine(false); //86:44
            }
            if (symbol.ModelObjectOption != ParameterOption.Disabled) //88:10
            {
                __out.Write("        private readonly object? _modelObject;"); //89:1
                __out.AppendLine(false); //89:47
            }
            __out.Write("        private readonly CompletionState _state;"); //91:1
            __out.AppendLine(false); //91:49
            __out.Write("        private ImmutableArray<Symbol> _childSymbols;"); //92:1
            __out.AppendLine(false); //92:54
            __out.Write("        private string _name;"); //93:1
            __out.AppendLine(false); //93:30
            var __loop5_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //94:16
                select new { prop = prop}
                ).ToList(); //94:10
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                var __tmp54 = __loop5_results[__loop5_iteration];
                var prop = __tmp54.prop;
                bool __tmp56_outputWritten = false;
                string __tmp57_line = "        private "; //95:1
                if (!string.IsNullOrEmpty(__tmp57_line))
                {
                    __out.Write(__tmp57_line);
                    __tmp56_outputWritten = true;
                }
                var __tmp58 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp58.Write(prop.Type);
                var __tmp58Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp58.ToStringAndFree());
                bool __tmp58_last = __tmp58Reader.EndOfStream;
                while(!__tmp58_last)
                {
                    ReadOnlySpan<char> __tmp58_line = __tmp58Reader.ReadLine();
                    __tmp58_last = __tmp58Reader.EndOfStream;
                    if (!__tmp58_last || !__tmp58_line.IsEmpty)
                    {
                        __out.Write(__tmp58_line);
                        __tmp56_outputWritten = true;
                    }
                    if (!__tmp58_last) __out.AppendLine(true);
                }
                string __tmp59_line = " "; //95:28
                if (!string.IsNullOrEmpty(__tmp59_line))
                {
                    __out.Write(__tmp59_line);
                    __tmp56_outputWritten = true;
                }
                var __tmp60 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp60.Write(prop.FieldName);
                var __tmp60Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp60.ToStringAndFree());
                bool __tmp60_last = __tmp60Reader.EndOfStream;
                while(!__tmp60_last)
                {
                    ReadOnlySpan<char> __tmp60_line = __tmp60Reader.ReadLine();
                    __tmp60_last = __tmp60Reader.EndOfStream;
                    if (!__tmp60_last || !__tmp60_line.IsEmpty)
                    {
                        __out.Write(__tmp60_line);
                        __tmp56_outputWritten = true;
                    }
                    if (!__tmp60_last) __out.AppendLine(true);
                }
                string __tmp61_line = ";"; //95:45
                if (!string.IsNullOrEmpty(__tmp61_line))
                {
                    __out.Write(__tmp61_line);
                    __tmp56_outputWritten = true;
                }
                if (__tmp56_outputWritten) __out.AppendLine(true);
                if (__tmp56_outputWritten)
                {
                    __out.AppendLine(false); //95:46
                }
            }
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //97:10
            {
                if (!symbol.ExistingCompletionMemberNames.Contains(".ctor")) //98:10
                {
                    __out.AppendLine(true); //99:1
                    bool __tmp63_outputWritten = false;
                    string __tmp64_line = "        public Completion"; //100:1
                    if (!string.IsNullOrEmpty(__tmp64_line))
                    {
                        __out.Write(__tmp64_line);
                        __tmp63_outputWritten = true;
                    }
                    var __tmp65 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp65.Write(symbol.Name);
                    var __tmp65Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp65.ToStringAndFree());
                    bool __tmp65_last = __tmp65Reader.EndOfStream;
                    while(!__tmp65_last)
                    {
                        ReadOnlySpan<char> __tmp65_line = __tmp65Reader.ReadLine();
                        __tmp65_last = __tmp65Reader.EndOfStream;
                        if (!__tmp65_last || !__tmp65_line.IsEmpty)
                        {
                            __out.Write(__tmp65_line);
                            __tmp63_outputWritten = true;
                        }
                        if (!__tmp65_last) __out.AppendLine(true);
                    }
                    string __tmp66_line = "(Symbol container"; //100:39
                    if (!string.IsNullOrEmpty(__tmp66_line))
                    {
                        __out.Write(__tmp66_line);
                        __tmp63_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //100:57
                    {
                        string __tmp68_line = ", object? modelObject"; //100:114
                        if (!string.IsNullOrEmpty(__tmp68_line))
                        {
                            __out.Write(__tmp68_line);
                            __tmp63_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //100:136
                        {
                            string __tmp70_line = " = null"; //100:193
                            if (!string.IsNullOrEmpty(__tmp70_line))
                            {
                                __out.Write(__tmp70_line);
                                __tmp63_outputWritten = true;
                            }
                        }
                    }
                    string __tmp73_line = ")"; //100:216
                    if (!string.IsNullOrEmpty(__tmp73_line))
                    {
                        __out.Write(__tmp73_line);
                        __tmp63_outputWritten = true;
                    }
                    if (__tmp63_outputWritten) __out.AppendLine(true);
                    if (__tmp63_outputWritten)
                    {
                        __out.AppendLine(false); //100:217
                    }
                    __out.Write("        {"); //101:1
                    __out.AppendLine(false); //101:10
                    __out.Write("            _container = container;"); //102:1
                    __out.AppendLine(false); //102:36
                    if (symbol.ModelObjectOption == ParameterOption.Required) //103:14
                    {
                        __out.Write("            if (modelObject is null) throw new ArgumentNullException(nameof(modelObject));"); //104:1
                        __out.AppendLine(false); //104:91
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //106:14
                    {
                        __out.Write("            _modelObject = modelObject;"); //107:1
                        __out.AppendLine(false); //107:40
                    }
                    __out.Write("            _state = CompletionParts.CompletionGraph.CreateState();"); //109:1
                    __out.AppendLine(false); //109:68
                    __out.Write("        }"); //110:1
                    __out.AppendLine(false); //110:10
                }
                if (!symbol.ExistingCompletionMemberNames.Contains("Language")) //112:10
                {
                    __out.AppendLine(true); //113:1
                    __out.Write("        public sealed override Language Language => ContainingModule.Language;"); //114:1
                    __out.AppendLine(false); //114:79
                }
                if (!symbol.ExistingCompletionMemberNames.Contains("SymbolFactory")) //116:10
                {
                    __out.AppendLine(true); //117:1
                    __out.Write("        public SymbolFactory SymbolFactory => ContainingModule.SymbolFactory;"); //118:1
                    __out.AppendLine(false); //118:78
                }
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //120:10
                {
                    if (!symbol.ExistingCompletionMemberNames.Contains("ModelObject")) //121:14
                    {
                        __out.AppendLine(true); //122:1
                        __out.Write("        public object ModelObject => _modelObject;"); //123:1
                        __out.AppendLine(false); //123:51
                    }
                    if (!symbol.ExistingCompletionMemberNames.Contains("ModelObjectType")) //125:14
                    {
                        __out.AppendLine(true); //126:1
                        __out.Write("        public Type ModelObjectType => _modelObject is not null ? Language.SymbolFacts.GetModelObjectType(_modelObject) : null;"); //127:1
                        __out.AppendLine(false); //127:128
                    }
                }
                if (!symbol.ExistingCompletionMemberNames.Contains("ContainingSymbol")) //130:10
                {
                    __out.AppendLine(true); //131:1
                    __out.Write("        public sealed override Symbol ContainingSymbol => _container;"); //132:1
                    __out.AppendLine(false); //132:70
                }
            }
            if (!symbol.ExistingCompletionMemberNames.Contains("ChildSymbols")) //135:10
            {
                __out.AppendLine(true); //136:1
                __out.Write("        public sealed override ImmutableArray<Symbol> ChildSymbols "); //137:1
                __out.AppendLine(false); //137:68
                __out.Write("        {"); //138:1
                __out.AppendLine(false); //138:10
                __out.Write("            get"); //139:1
                __out.AppendLine(false); //139:16
                __out.Write("            {"); //140:1
                __out.AppendLine(false); //140:14
                __out.Write("                this.ForceComplete(CompletionGraph.FinishCreatingChildren, null, default);"); //141:1
                __out.AppendLine(false); //141:91
                __out.Write("                return _childSymbols;"); //142:1
                __out.AppendLine(false); //142:38
                __out.Write("            }"); //143:1
                __out.AppendLine(false); //143:14
                __out.Write("        }"); //144:1
                __out.AppendLine(false); //144:10
            }
            if (!symbol.ExistingCompletionMemberNames.Contains("Name")) //146:10
            {
                __out.AppendLine(true); //147:1
                __out.Write("        public override string Name "); //148:1
                __out.AppendLine(false); //148:37
                __out.Write("        {"); //149:1
                __out.AppendLine(false); //149:10
                __out.Write("            get"); //150:1
                __out.AppendLine(false); //150:16
                __out.Write("            {"); //151:1
                __out.AppendLine(false); //151:14
                __out.Write("                this.ForceComplete(CompletionGraph.FinishInitializing, null, default);"); //152:1
                __out.AppendLine(false); //152:87
                __out.Write("                return _name;"); //153:1
                __out.AppendLine(false); //153:30
                __out.Write("            }"); //154:1
                __out.AppendLine(false); //154:14
                __out.Write("        }"); //155:1
                __out.AppendLine(false); //155:10
            }
            var __loop6_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //157:16
                select new { prop = prop}
                ).ToList(); //157:10
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp74 = __loop6_results[__loop6_iteration];
                var prop = __tmp74.prop;
                if (!symbol.ExistingCompletionMemberNames.Contains(prop.Name)) //158:14
                {
                    __out.AppendLine(true); //159:1
                    bool __tmp76_outputWritten = false;
                    string __tmp77_line = "        public override "; //160:1
                    if (!string.IsNullOrEmpty(__tmp77_line))
                    {
                        __out.Write(__tmp77_line);
                        __tmp76_outputWritten = true;
                    }
                    var __tmp78 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp78.Write(prop.Type);
                    var __tmp78Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp78.ToStringAndFree());
                    bool __tmp78_last = __tmp78Reader.EndOfStream;
                    while(!__tmp78_last)
                    {
                        ReadOnlySpan<char> __tmp78_line = __tmp78Reader.ReadLine();
                        __tmp78_last = __tmp78Reader.EndOfStream;
                        if (!__tmp78_last || !__tmp78_line.IsEmpty)
                        {
                            __out.Write(__tmp78_line);
                            __tmp76_outputWritten = true;
                        }
                        if (!__tmp78_last) __out.AppendLine(true);
                    }
                    string __tmp79_line = " "; //160:36
                    if (!string.IsNullOrEmpty(__tmp79_line))
                    {
                        __out.Write(__tmp79_line);
                        __tmp76_outputWritten = true;
                    }
                    var __tmp80 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp80.Write(prop.Name);
                    var __tmp80Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp80.ToStringAndFree());
                    bool __tmp80_last = __tmp80Reader.EndOfStream;
                    while(!__tmp80_last)
                    {
                        ReadOnlySpan<char> __tmp80_line = __tmp80Reader.ReadLine();
                        __tmp80_last = __tmp80Reader.EndOfStream;
                        if (!__tmp80_last || !__tmp80_line.IsEmpty)
                        {
                            __out.Write(__tmp80_line);
                            __tmp76_outputWritten = true;
                        }
                        if (!__tmp80_last || __tmp76_outputWritten) __out.AppendLine(true);
                    }
                    if (__tmp76_outputWritten)
                    {
                        __out.AppendLine(false); //160:48
                    }
                    __out.Write("        {"); //161:1
                    __out.AppendLine(false); //161:10
                    __out.Write("            get"); //162:1
                    __out.AppendLine(false); //162:16
                    __out.Write("            {"); //163:1
                    __out.AppendLine(false); //163:14
                    bool __tmp82_outputWritten = false;
                    string __tmp83_line = "                this.ForceComplete(CompletionParts."; //164:1
                    if (!string.IsNullOrEmpty(__tmp83_line))
                    {
                        __out.Write(__tmp83_line);
                        __tmp82_outputWritten = true;
                    }
                    var __tmp84 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp84.Write(prop.FinishCompletionPartName);
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
                    string __tmp85_line = ", null, default);"; //164:83
                    if (!string.IsNullOrEmpty(__tmp85_line))
                    {
                        __out.Write(__tmp85_line);
                        __tmp82_outputWritten = true;
                    }
                    if (__tmp82_outputWritten) __out.AppendLine(true);
                    if (__tmp82_outputWritten)
                    {
                        __out.AppendLine(false); //164:100
                    }
                    bool __tmp87_outputWritten = false;
                    string __tmp88_line = "                return "; //165:1
                    if (!string.IsNullOrEmpty(__tmp88_line))
                    {
                        __out.Write(__tmp88_line);
                        __tmp87_outputWritten = true;
                    }
                    var __tmp89 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp89.Write(prop.FieldName);
                    var __tmp89Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp89.ToStringAndFree());
                    bool __tmp89_last = __tmp89Reader.EndOfStream;
                    while(!__tmp89_last)
                    {
                        ReadOnlySpan<char> __tmp89_line = __tmp89Reader.ReadLine();
                        __tmp89_last = __tmp89Reader.EndOfStream;
                        if (!__tmp89_last || !__tmp89_line.IsEmpty)
                        {
                            __out.Write(__tmp89_line);
                            __tmp87_outputWritten = true;
                        }
                        if (!__tmp89_last) __out.AppendLine(true);
                    }
                    string __tmp90_line = ";"; //165:40
                    if (!string.IsNullOrEmpty(__tmp90_line))
                    {
                        __out.Write(__tmp90_line);
                        __tmp87_outputWritten = true;
                    }
                    if (__tmp87_outputWritten) __out.AppendLine(true);
                    if (__tmp87_outputWritten)
                    {
                        __out.AppendLine(false); //165:41
                    }
                    __out.Write("            }"); //166:1
                    __out.AppendLine(false); //166:14
                    __out.Write("        }"); //167:1
                    __out.AppendLine(false); //167:10
                }
            }
            __out.AppendLine(true); //170:1
            __out.Write("        #region Completion"); //171:1
            __out.AppendLine(false); //171:27
            __out.AppendLine(true); //172:1
            __out.Write("        public sealed override bool RequiresCompletion => true;"); //173:1
            __out.AppendLine(false); //173:64
            __out.AppendLine(true); //174:1
            __out.Write("        public sealed override bool HasComplete(CompletionPart part)"); //175:1
            __out.AppendLine(false); //175:69
            __out.Write("        {"); //176:1
            __out.AppendLine(false); //176:10
            __out.Write("            return _state.HasComplete(part);"); //177:1
            __out.AppendLine(false); //177:45
            __out.Write("        }"); //178:1
            __out.AppendLine(false); //178:10
            __out.AppendLine(true); //179:1
            __out.Write("        public override void ForceComplete(CompletionPart completionPart, SourceLocation locationOpt, CancellationToken cancellationToken)"); //180:1
            __out.AppendLine(false); //180:139
            __out.Write("        {"); //181:1
            __out.AppendLine(false); //181:10
            __out.Write("            if (completionPart != null && _state.HasComplete(completionPart)) return;"); //182:1
            __out.AppendLine(false); //182:86
            __out.Write("            if (completionPart != null && !CompletionParts.All.Contains(completionPart)) throw new ArgumentException(nameof(completionPart));"); //183:1
            __out.AppendLine(false); //183:142
            __out.Write("            while (true)"); //184:1
            __out.AppendLine(false); //184:25
            __out.Write("            {"); //185:1
            __out.AppendLine(false); //185:14
            __out.Write("                cancellationToken.ThrowIfCancellationRequested();"); //186:1
            __out.AppendLine(false); //186:66
            __out.Write("                var incompletePart = _state.NextIncompletePart;"); //187:1
            __out.AppendLine(false); //187:64
            __out.Write("                if (incompletePart == CompletionGraph.StartInitializing || incompletePart == CompletionGraph.FinishInitializing)"); //188:1
            __out.AppendLine(false); //188:129
            __out.Write("                {"); //189:1
            __out.AppendLine(false); //189:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartInitializing))"); //190:1
            __out.AppendLine(false); //190:84
            __out.Write("                    {"); //191:1
            __out.AppendLine(false); //191:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //192:1
            __out.AppendLine(false); //192:71
            __out.Write("                        _name = CompleteSymbolProperty_Name(diagnostics, cancellationToken);"); //193:1
            __out.AppendLine(false); //193:93
            __out.Write("                        CompleteInitializingSymbol(diagnostics, cancellationToken);"); //194:1
            __out.AppendLine(false); //194:84
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //195:1
            __out.AppendLine(false); //195:59
            __out.Write("                        diagnostics.Free();"); //196:1
            __out.AppendLine(false); //196:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishInitializing);"); //197:1
            __out.AppendLine(false); //197:85
            __out.Write("                    }"); //198:1
            __out.AppendLine(false); //198:22
            __out.Write("                }"); //199:1
            __out.AppendLine(false); //199:18
            __out.Write("                else if (incompletePart == CompletionGraph.StartCreatingChildren || incompletePart == CompletionGraph.FinishCreatingChildren)"); //200:1
            __out.AppendLine(false); //200:142
            __out.Write("                {"); //201:1
            __out.AppendLine(false); //201:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartCreatingChildren))"); //202:1
            __out.AppendLine(false); //202:88
            __out.Write("                    {"); //203:1
            __out.AppendLine(false); //203:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //204:1
            __out.AppendLine(false); //204:71
            __out.Write("                        _childSymbols = CompleteCreatingChildSymbols(diagnostics, cancellationToken);"); //205:1
            __out.AppendLine(false); //205:102
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //206:1
            __out.AppendLine(false); //206:59
            __out.Write("                        diagnostics.Free();"); //207:1
            __out.AppendLine(false); //207:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishCreatingChildren);"); //208:1
            __out.AppendLine(false); //208:89
            __out.Write("                    }"); //209:1
            __out.AppendLine(false); //209:22
            __out.Write("                }"); //210:1
            __out.AppendLine(false); //210:18
            var __loop7_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //211:24
                select new { part = part}
                ).ToList(); //211:18
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                var __tmp91 = __loop7_results[__loop7_iteration];
                var part = __tmp91.part;
                if (part.IsLocked) //212:22
                {
                    bool __tmp93_outputWritten = false;
                    string __tmp94_line = "                else if (incompletePart == CompletionParts."; //213:1
                    if (!string.IsNullOrEmpty(__tmp94_line))
                    {
                        __out.Write(__tmp94_line);
                        __tmp93_outputWritten = true;
                    }
                    var __tmp95 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp95.Write(part.StartCompletionPartName);
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
                    string __tmp96_line = " || incompletePart == CompletionParts."; //213:90
                    if (!string.IsNullOrEmpty(__tmp96_line))
                    {
                        __out.Write(__tmp96_line);
                        __tmp93_outputWritten = true;
                    }
                    var __tmp97 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp97.Write(part.FinishCompletionPartName);
                    var __tmp97Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp97.ToStringAndFree());
                    bool __tmp97_last = __tmp97Reader.EndOfStream;
                    while(!__tmp97_last)
                    {
                        ReadOnlySpan<char> __tmp97_line = __tmp97Reader.ReadLine();
                        __tmp97_last = __tmp97Reader.EndOfStream;
                        if (!__tmp97_last || !__tmp97_line.IsEmpty)
                        {
                            __out.Write(__tmp97_line);
                            __tmp93_outputWritten = true;
                        }
                        if (!__tmp97_last) __out.AppendLine(true);
                    }
                    string __tmp98_line = ")"; //213:159
                    if (!string.IsNullOrEmpty(__tmp98_line))
                    {
                        __out.Write(__tmp98_line);
                        __tmp93_outputWritten = true;
                    }
                    if (__tmp93_outputWritten) __out.AppendLine(true);
                    if (__tmp93_outputWritten)
                    {
                        __out.AppendLine(false); //213:160
                    }
                    __out.Write("                {"); //214:1
                    __out.AppendLine(false); //214:18
                    bool __tmp100_outputWritten = false;
                    string __tmp101_line = "                    if (_state.NotePartComplete(CompletionParts."; //215:1
                    if (!string.IsNullOrEmpty(__tmp101_line))
                    {
                        __out.Write(__tmp101_line);
                        __tmp100_outputWritten = true;
                    }
                    var __tmp102 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp102.Write(part.StartCompletionPartName);
                    var __tmp102Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp102.ToStringAndFree());
                    bool __tmp102_last = __tmp102Reader.EndOfStream;
                    while(!__tmp102_last)
                    {
                        ReadOnlySpan<char> __tmp102_line = __tmp102Reader.ReadLine();
                        __tmp102_last = __tmp102Reader.EndOfStream;
                        if (!__tmp102_last || !__tmp102_line.IsEmpty)
                        {
                            __out.Write(__tmp102_line);
                            __tmp100_outputWritten = true;
                        }
                        if (!__tmp102_last) __out.AppendLine(true);
                    }
                    string __tmp103_line = "))"; //215:95
                    if (!string.IsNullOrEmpty(__tmp103_line))
                    {
                        __out.Write(__tmp103_line);
                        __tmp100_outputWritten = true;
                    }
                    if (__tmp100_outputWritten) __out.AppendLine(true);
                    if (__tmp100_outputWritten)
                    {
                        __out.AppendLine(false); //215:97
                    }
                    __out.Write("                    {"); //216:1
                    __out.AppendLine(false); //216:22
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //217:26
                    {
                        __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //218:1
                        __out.AppendLine(false); //218:71
                    }
                    bool __tmp105_outputWritten = false;
                    string __tmp104Prefix = "                        "; //220:1
                    if (part is SymbolPropertyGenerationInfo) //220:26
                    {
                        if (!string.IsNullOrEmpty(__tmp104Prefix))
                        {
                            __out.Write(__tmp104Prefix);
                            __tmp105_outputWritten = true;
                        }
                        var __tmp107 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp107.Write(((SymbolPropertyGenerationInfo)part).FieldName);
                        var __tmp107Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp107.ToStringAndFree());
                        bool __tmp107_last = __tmp107Reader.EndOfStream;
                        while(!__tmp107_last)
                        {
                            ReadOnlySpan<char> __tmp107_line = __tmp107Reader.ReadLine();
                            __tmp107_last = __tmp107Reader.EndOfStream;
                            if (!__tmp107_last || !__tmp107_line.IsEmpty)
                            {
                                __out.Write(__tmp107_line);
                                __tmp105_outputWritten = true;
                            }
                            if (!__tmp107_last) __out.AppendLine(true);
                        }
                        string __tmp108_line = " = "; //220:116
                        if (!string.IsNullOrEmpty(__tmp108_line))
                        {
                            __out.Write(__tmp108_line);
                            __tmp105_outputWritten = true;
                        }
                    }
                    var __tmp110 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp110.Write(part.CompleteMethodName);
                    var __tmp110Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp110.ToStringAndFree());
                    bool __tmp110_last = __tmp110Reader.EndOfStream;
                    while(!__tmp110_last)
                    {
                        ReadOnlySpan<char> __tmp110_line = __tmp110Reader.ReadLine();
                        __tmp110_last = __tmp110Reader.EndOfStream;
                        if (!__tmp110_last || !__tmp110_line.IsEmpty)
                        {
                            __out.Write(__tmp110_line);
                            __tmp105_outputWritten = true;
                        }
                        if (!__tmp110_last) __out.AppendLine(true);
                    }
                    string __tmp111_line = "("; //220:152
                    if (!string.IsNullOrEmpty(__tmp111_line))
                    {
                        __out.Write(__tmp111_line);
                        __tmp105_outputWritten = true;
                    }
                    var __tmp112 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp112.Write(part.CompleteMethodArgList);
                    var __tmp112Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp112.ToStringAndFree());
                    bool __tmp112_last = __tmp112Reader.EndOfStream;
                    while(!__tmp112_last)
                    {
                        ReadOnlySpan<char> __tmp112_line = __tmp112Reader.ReadLine();
                        __tmp112_last = __tmp112Reader.EndOfStream;
                        if (!__tmp112_last || !__tmp112_line.IsEmpty)
                        {
                            __out.Write(__tmp112_line);
                            __tmp105_outputWritten = true;
                        }
                        if (!__tmp112_last) __out.AppendLine(true);
                    }
                    string __tmp113_line = ");"; //220:181
                    if (!string.IsNullOrEmpty(__tmp113_line))
                    {
                        __out.Write(__tmp113_line);
                        __tmp105_outputWritten = true;
                    }
                    if (__tmp105_outputWritten) __out.AppendLine(true);
                    if (__tmp105_outputWritten)
                    {
                        __out.AppendLine(false); //220:183
                    }
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //221:26
                    {
                        __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //222:1
                        __out.AppendLine(false); //222:59
                        __out.Write("                        diagnostics.Free();"); //223:1
                        __out.AppendLine(false); //223:44
                    }
                    bool __tmp115_outputWritten = false;
                    string __tmp116_line = "                        _state.NotePartComplete(CompletionParts."; //225:1
                    if (!string.IsNullOrEmpty(__tmp116_line))
                    {
                        __out.Write(__tmp116_line);
                        __tmp115_outputWritten = true;
                    }
                    var __tmp117 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp117.Write(part.FinishCompletionPartName);
                    var __tmp117Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp117.ToStringAndFree());
                    bool __tmp117_last = __tmp117Reader.EndOfStream;
                    while(!__tmp117_last)
                    {
                        ReadOnlySpan<char> __tmp117_line = __tmp117Reader.ReadLine();
                        __tmp117_last = __tmp117Reader.EndOfStream;
                        if (!__tmp117_last || !__tmp117_line.IsEmpty)
                        {
                            __out.Write(__tmp117_line);
                            __tmp115_outputWritten = true;
                        }
                        if (!__tmp117_last) __out.AppendLine(true);
                    }
                    string __tmp118_line = ");"; //225:96
                    if (!string.IsNullOrEmpty(__tmp118_line))
                    {
                        __out.Write(__tmp118_line);
                        __tmp115_outputWritten = true;
                    }
                    if (__tmp115_outputWritten) __out.AppendLine(true);
                    if (__tmp115_outputWritten)
                    {
                        __out.AppendLine(false); //225:98
                    }
                    __out.Write("                    }"); //226:1
                    __out.AppendLine(false); //226:22
                    __out.Write("                }"); //227:1
                    __out.AppendLine(false); //227:18
                }
                else //228:22
                {
                    bool __tmp120_outputWritten = false;
                    string __tmp121_line = "                else if (incompletePart == CompletionParts."; //229:1
                    if (!string.IsNullOrEmpty(__tmp121_line))
                    {
                        __out.Write(__tmp121_line);
                        __tmp120_outputWritten = true;
                    }
                    var __tmp122 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp122.Write(part.CompletionPartName);
                    var __tmp122Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp122.ToStringAndFree());
                    bool __tmp122_last = __tmp122Reader.EndOfStream;
                    while(!__tmp122_last)
                    {
                        ReadOnlySpan<char> __tmp122_line = __tmp122Reader.ReadLine();
                        __tmp122_last = __tmp122Reader.EndOfStream;
                        if (!__tmp122_last || !__tmp122_line.IsEmpty)
                        {
                            __out.Write(__tmp122_line);
                            __tmp120_outputWritten = true;
                        }
                        if (!__tmp122_last) __out.AppendLine(true);
                    }
                    string __tmp123_line = ")"; //229:85
                    if (!string.IsNullOrEmpty(__tmp123_line))
                    {
                        __out.Write(__tmp123_line);
                        __tmp120_outputWritten = true;
                    }
                    if (__tmp120_outputWritten) __out.AppendLine(true);
                    if (__tmp120_outputWritten)
                    {
                        __out.AppendLine(false); //229:86
                    }
                    __out.Write("                {"); //230:1
                    __out.AppendLine(false); //230:18
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //231:22
                    {
                        __out.Write("                    var diagnostics = DiagnosticBag.GetInstance();"); //232:1
                        __out.AppendLine(false); //232:67
                    }
                    bool __tmp125_outputWritten = false;
                    string __tmp124Prefix = "                    "; //234:1
                    var __tmp126 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp126.Write(part.CompleteMethodName);
                    var __tmp126Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp126.ToStringAndFree());
                    bool __tmp126_last = __tmp126Reader.EndOfStream;
                    while(!__tmp126_last)
                    {
                        ReadOnlySpan<char> __tmp126_line = __tmp126Reader.ReadLine();
                        __tmp126_last = __tmp126Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp124Prefix))
                        {
                            __out.Write(__tmp124Prefix);
                            __tmp125_outputWritten = true;
                        }
                        if (!__tmp126_last || !__tmp126_line.IsEmpty)
                        {
                            __out.Write(__tmp126_line);
                            __tmp125_outputWritten = true;
                        }
                        if (!__tmp126_last) __out.AppendLine(true);
                    }
                    string __tmp127_line = "("; //234:46
                    if (!string.IsNullOrEmpty(__tmp127_line))
                    {
                        __out.Write(__tmp127_line);
                        __tmp125_outputWritten = true;
                    }
                    var __tmp128 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp128.Write(part.CompleteMethodArgList);
                    var __tmp128Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp128.ToStringAndFree());
                    bool __tmp128_last = __tmp128Reader.EndOfStream;
                    while(!__tmp128_last)
                    {
                        ReadOnlySpan<char> __tmp128_line = __tmp128Reader.ReadLine();
                        __tmp128_last = __tmp128Reader.EndOfStream;
                        if (!__tmp128_last || !__tmp128_line.IsEmpty)
                        {
                            __out.Write(__tmp128_line);
                            __tmp125_outputWritten = true;
                        }
                        if (!__tmp128_last) __out.AppendLine(true);
                    }
                    string __tmp129_line = ");"; //234:75
                    if (!string.IsNullOrEmpty(__tmp129_line))
                    {
                        __out.Write(__tmp129_line);
                        __tmp125_outputWritten = true;
                    }
                    if (__tmp125_outputWritten) __out.AppendLine(true);
                    if (__tmp125_outputWritten)
                    {
                        __out.AppendLine(false); //234:77
                    }
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //235:22
                    {
                        __out.Write("                    AddSymbolDiagnostics(diagnostics);"); //236:1
                        __out.AppendLine(false); //236:55
                        __out.Write("                    diagnostics.Free();"); //237:1
                        __out.AppendLine(false); //237:40
                    }
                    bool __tmp131_outputWritten = false;
                    string __tmp132_line = "                    _state.NotePartComplete(CompletionParts."; //239:1
                    if (!string.IsNullOrEmpty(__tmp132_line))
                    {
                        __out.Write(__tmp132_line);
                        __tmp131_outputWritten = true;
                    }
                    var __tmp133 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp133.Write(part.CompletionPartName);
                    var __tmp133Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp133.ToStringAndFree());
                    bool __tmp133_last = __tmp133Reader.EndOfStream;
                    while(!__tmp133_last)
                    {
                        ReadOnlySpan<char> __tmp133_line = __tmp133Reader.ReadLine();
                        __tmp133_last = __tmp133Reader.EndOfStream;
                        if (!__tmp133_last || !__tmp133_line.IsEmpty)
                        {
                            __out.Write(__tmp133_line);
                            __tmp131_outputWritten = true;
                        }
                        if (!__tmp133_last) __out.AppendLine(true);
                    }
                    string __tmp134_line = ");"; //239:86
                    if (!string.IsNullOrEmpty(__tmp134_line))
                    {
                        __out.Write(__tmp134_line);
                        __tmp131_outputWritten = true;
                    }
                    if (__tmp131_outputWritten) __out.AppendLine(true);
                    if (__tmp131_outputWritten)
                    {
                        __out.AppendLine(false); //239:88
                    }
                    __out.Write("                }"); //240:1
                    __out.AppendLine(false); //240:18
                }
            }
            __out.Write("                else if (incompletePart == CompletionGraph.StartComputingNonSymbolProperties || incompletePart == CompletionGraph.FinishComputingNonSymbolProperties)"); //243:1
            __out.AppendLine(false); //243:166
            __out.Write("                {"); //244:1
            __out.AppendLine(false); //244:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartComputingNonSymbolProperties))"); //245:1
            __out.AppendLine(false); //245:100
            __out.Write("                    {"); //246:1
            __out.AppendLine(false); //246:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //247:1
            __out.AppendLine(false); //247:71
            __out.Write("                        CompleteNonSymbolProperties(locationOpt, diagnostics, cancellationToken);"); //248:1
            __out.AppendLine(false); //248:98
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //249:1
            __out.AppendLine(false); //249:59
            __out.Write("                        diagnostics.Free();"); //250:1
            __out.AppendLine(false); //250:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishComputingNonSymbolProperties);"); //251:1
            __out.AppendLine(false); //251:101
            __out.Write("                    }"); //252:1
            __out.AppendLine(false); //252:22
            __out.Write("                }"); //253:1
            __out.AppendLine(false); //253:18
            __out.Write("                else if (incompletePart == CompletionGraph.ChildrenCompleted)"); //254:1
            __out.AppendLine(false); //254:78
            __out.Write("                {"); //255:1
            __out.AppendLine(false); //255:18
            __out.Write("                    var diagnostics = DiagnosticBag.GetInstance();"); //256:1
            __out.AppendLine(false); //256:67
            __out.Write("                    CompleteImports(locationOpt, diagnostics, cancellationToken);"); //257:1
            __out.AppendLine(false); //257:82
            __out.Write("                    AddSymbolDiagnostics(diagnostics);"); //258:1
            __out.AppendLine(false); //258:55
            __out.Write("                    diagnostics.Free();"); //259:1
            __out.AppendLine(false); //259:40
            __out.Write("                    bool allCompleted = true;"); //261:1
            __out.AppendLine(false); //261:46
            __out.Write("                    if (locationOpt == null)"); //262:1
            __out.AppendLine(false); //262:45
            __out.Write("                    {"); //263:1
            __out.AppendLine(false); //263:22
            __out.Write("                        foreach (var child in _childSymbols)"); //264:1
            __out.AppendLine(false); //264:61
            __out.Write("                        {"); //265:1
            __out.AppendLine(false); //265:26
            __out.Write("                            cancellationToken.ThrowIfCancellationRequested();"); //266:1
            __out.AppendLine(false); //266:78
            __out.Write("                            child.ForceComplete(null, locationOpt, cancellationToken);"); //267:1
            __out.AppendLine(false); //267:87
            __out.Write("                        }"); //268:1
            __out.AppendLine(false); //268:26
            __out.Write("                    }"); //269:1
            __out.AppendLine(false); //269:22
            __out.Write("                    else"); //270:1
            __out.AppendLine(false); //270:25
            __out.Write("                    {"); //271:1
            __out.AppendLine(false); //271:22
            __out.Write("                        foreach (var child in _childSymbols)"); //272:1
            __out.AppendLine(false); //272:61
            __out.Write("                        {"); //273:1
            __out.AppendLine(false); //273:26
            __out.Write("                            ForceCompleteChildByLocation(locationOpt, child, cancellationToken);"); //274:1
            __out.AppendLine(false); //274:97
            __out.Write("                            allCompleted = allCompleted && child.HasComplete(CompletionGraph.All);"); //275:1
            __out.AppendLine(false); //275:99
            __out.Write("                        }"); //276:1
            __out.AppendLine(false); //276:26
            __out.Write("                    }"); //277:1
            __out.AppendLine(false); //277:22
            __out.Write("                    if (!allCompleted)"); //279:1
            __out.AppendLine(false); //279:39
            __out.Write("                    {"); //280:1
            __out.AppendLine(false); //280:22
            __out.Write("                        // We did not complete all members, so just kick out now."); //281:1
            __out.AppendLine(false); //281:82
            __out.Write("                        var allParts = CompletionParts.AllWithLocation;"); //282:1
            __out.AppendLine(false); //282:72
            __out.Write("                        _state.SpinWaitComplete(allParts, cancellationToken);"); //283:1
            __out.AppendLine(false); //283:78
            __out.Write("                        return;"); //284:1
            __out.AppendLine(false); //284:32
            __out.Write("                    }"); //285:1
            __out.AppendLine(false); //285:22
            __out.Write("                    // We've completed all members, proceed to the next iteration."); //287:1
            __out.AppendLine(false); //287:83
            __out.Write("                    _state.NotePartComplete(CompletionGraph.ChildrenCompleted);"); //288:1
            __out.AppendLine(false); //288:80
            __out.Write("                }"); //289:1
            __out.AppendLine(false); //289:18
            __out.Write("                else if (incompletePart == null)"); //290:1
            __out.AppendLine(false); //290:49
            __out.Write("                {"); //291:1
            __out.AppendLine(false); //291:18
            __out.Write("                    return;"); //292:1
            __out.AppendLine(false); //292:28
            __out.Write("                }"); //293:1
            __out.AppendLine(false); //293:18
            __out.Write("                else"); //294:1
            __out.AppendLine(false); //294:21
            __out.Write("                {"); //295:1
            __out.AppendLine(false); //295:18
            __out.Write("                    // This assert will trigger if we forgot to handle any of the completion parts"); //296:1
            __out.AppendLine(false); //296:99
            __out.Write("                    Debug.Assert(!CompletionParts.All.Contains(incompletePart));"); //297:1
            __out.AppendLine(false); //297:81
            __out.Write("                    // any other values are completion parts intended for other kinds of symbols"); //298:1
            __out.AppendLine(false); //298:97
            __out.Write("                    _state.NotePartComplete(incompletePart);"); //299:1
            __out.AppendLine(false); //299:61
            __out.Write("                }"); //300:1
            __out.AppendLine(false); //300:18
            __out.Write("                if (completionPart != null && _state.HasComplete(completionPart)) return;"); //301:1
            __out.AppendLine(false); //301:90
            __out.Write("                _state.SpinWaitComplete(incompletePart, cancellationToken);"); //302:1
            __out.AppendLine(false); //302:76
            __out.Write("            }"); //303:1
            __out.AppendLine(false); //303:14
            __out.Write("            throw ExceptionUtilities.Unreachable;"); //304:1
            __out.AppendLine(false); //304:50
            __out.Write("        }"); //305:1
            __out.AppendLine(false); //305:10
            __out.AppendLine(true); //306:1
            if (!symbol.ExistingCompletionMemberNames.Contains("CompleteSymbolProperty_Name")) //307:10
            {
                __out.Write("        protected abstract string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //308:1
                __out.AppendLine(false); //308:127
            }
            if (!symbol.ExistingCompletionMemberNames.Contains("CompleteInitializingSymbol")) //310:10
            {
                __out.Write("        protected abstract void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //311:1
                __out.AppendLine(false); //311:124
            }
            if (!symbol.ExistingCompletionMemberNames.Contains("CompleteCreatingChildSymbols")) //313:10
            {
                __out.Write("        protected abstract ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //314:1
                __out.AppendLine(false); //314:144
            }
            if (!symbol.ExistingCompletionMemberNames.Contains("CompleteImports")) //316:10
            {
                __out.Write("        protected abstract void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //317:1
                __out.AppendLine(false); //317:141
            }
            var __loop8_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //319:16
                where part.GenerateCompleteMethod //319:44
                select new { part = part}
                ).ToList(); //319:10
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp135 = __loop8_results[__loop8_iteration];
                var part = __tmp135.part;
                if (!symbol.ExistingCompletionMemberNames.Contains(part.CompleteMethodName)) //320:14
                {
                    bool __tmp137_outputWritten = false;
                    string __tmp138_line = "        protected abstract "; //321:1
                    if (!string.IsNullOrEmpty(__tmp138_line))
                    {
                        __out.Write(__tmp138_line);
                        __tmp137_outputWritten = true;
                    }
                    var __tmp139 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp139.Write(part.CompleteMethodReturnType);
                    var __tmp139Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp139.ToStringAndFree());
                    bool __tmp139_last = __tmp139Reader.EndOfStream;
                    while(!__tmp139_last)
                    {
                        ReadOnlySpan<char> __tmp139_line = __tmp139Reader.ReadLine();
                        __tmp139_last = __tmp139Reader.EndOfStream;
                        if (!__tmp139_last || !__tmp139_line.IsEmpty)
                        {
                            __out.Write(__tmp139_line);
                            __tmp137_outputWritten = true;
                        }
                        if (!__tmp139_last) __out.AppendLine(true);
                    }
                    string __tmp140_line = " "; //321:59
                    if (!string.IsNullOrEmpty(__tmp140_line))
                    {
                        __out.Write(__tmp140_line);
                        __tmp137_outputWritten = true;
                    }
                    var __tmp141 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp141.Write(part.CompleteMethodName);
                    var __tmp141Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp141.ToStringAndFree());
                    bool __tmp141_last = __tmp141Reader.EndOfStream;
                    while(!__tmp141_last)
                    {
                        ReadOnlySpan<char> __tmp141_line = __tmp141Reader.ReadLine();
                        __tmp141_last = __tmp141Reader.EndOfStream;
                        if (!__tmp141_last || !__tmp141_line.IsEmpty)
                        {
                            __out.Write(__tmp141_line);
                            __tmp137_outputWritten = true;
                        }
                        if (!__tmp141_last) __out.AppendLine(true);
                    }
                    string __tmp142_line = "("; //321:85
                    if (!string.IsNullOrEmpty(__tmp142_line))
                    {
                        __out.Write(__tmp142_line);
                        __tmp137_outputWritten = true;
                    }
                    var __tmp143 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp143.Write(part.CompleteMethodParamList);
                    var __tmp143Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp143.ToStringAndFree());
                    bool __tmp143_last = __tmp143Reader.EndOfStream;
                    while(!__tmp143_last)
                    {
                        ReadOnlySpan<char> __tmp143_line = __tmp143Reader.ReadLine();
                        __tmp143_last = __tmp143Reader.EndOfStream;
                        if (!__tmp143_last || !__tmp143_line.IsEmpty)
                        {
                            __out.Write(__tmp143_line);
                            __tmp137_outputWritten = true;
                        }
                        if (!__tmp143_last) __out.AppendLine(true);
                    }
                    string __tmp144_line = ");"; //321:116
                    if (!string.IsNullOrEmpty(__tmp144_line))
                    {
                        __out.Write(__tmp144_line);
                        __tmp137_outputWritten = true;
                    }
                    if (__tmp137_outputWritten) __out.AppendLine(true);
                    if (__tmp137_outputWritten)
                    {
                        __out.AppendLine(false); //321:118
                    }
                }
            }
            if (!symbol.ExistingCompletionMemberNames.Contains("CompleteNonSymbolProperties")) //324:10
            {
                __out.Write("        protected abstract void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //325:1
                __out.AppendLine(false); //325:153
            }
            __out.Write("        #endregion"); //327:1
            __out.AppendLine(false); //327:19
            __out.AppendLine(true); //328:1
            __out.Write("    }"); //329:1
            __out.AppendLine(false); //329:6
            __out.Write("}"); //330:1
            __out.AppendLine(false); //330:2
            return __out.ToStringAndFree();
        }

        public string GenerateMetadataSymbol(SymbolGenerationInfo symbol) //333:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //334:1
            __out.AppendLine(false); //334:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //335:1
            __out.AppendLine(false); //335:29
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //336:1
            __out.AppendLine(false); //336:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //337:1
            __out.AppendLine(false); //337:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //338:1
            __out.AppendLine(false); //338:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //339:1
            __out.AppendLine(false); //339:44
            __out.Write("using System;"); //340:1
            __out.AppendLine(false); //340:14
            __out.Write("using System.Collections.Generic;"); //341:1
            __out.AppendLine(false); //341:34
            __out.Write("using System.Collections.Immutable;"); //342:1
            __out.AppendLine(false); //342:36
            __out.Write("using System.Diagnostics;"); //343:1
            __out.AppendLine(false); //343:26
            __out.Write("using System.Text;"); //344:1
            __out.AppendLine(false); //344:19
            __out.Write("using System.Threading;"); //345:1
            __out.AppendLine(false); //345:24
            __out.AppendLine(true); //346:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //347:1
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
            string __tmp5_line = ".Metadata"; //347:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //347:42
            }
            __out.Write("{"); //348:1
            __out.AppendLine(false); //348:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Metadata"; //349:1
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
            if (symbol.ExistingMetadataBaseType == null) //349:45
            {
                string __tmp11_line = " : "; //349:90
                if (!string.IsNullOrEmpty(__tmp11_line))
                {
                    __out.Write(__tmp11_line);
                    __tmp7_outputWritten = true;
                }
                var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp12.Write(symbol.NamespaceName);
                var __tmp12Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp12.ToStringAndFree());
                bool __tmp12_last = __tmp12Reader.EndOfStream;
                while(!__tmp12_last)
                {
                    ReadOnlySpan<char> __tmp12_line = __tmp12Reader.ReadLine();
                    __tmp12_last = __tmp12Reader.EndOfStream;
                    if (!__tmp12_last || !__tmp12_line.IsEmpty)
                    {
                        __out.Write(__tmp12_line);
                        __tmp7_outputWritten = true;
                    }
                    if (!__tmp12_last) __out.AppendLine(true);
                }
                string __tmp13_line = ".Completion.Completion"; //349:115
                if (!string.IsNullOrEmpty(__tmp13_line))
                {
                    __out.Write(__tmp13_line);
                    __tmp7_outputWritten = true;
                }
                var __tmp14 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp14.Write(symbol.Name);
                var __tmp14Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp14.ToStringAndFree());
                bool __tmp14_last = __tmp14Reader.EndOfStream;
                while(!__tmp14_last)
                {
                    ReadOnlySpan<char> __tmp14_line = __tmp14Reader.ReadLine();
                    __tmp14_last = __tmp14Reader.EndOfStream;
                    if (!__tmp14_last || !__tmp14_line.IsEmpty)
                    {
                        __out.Write(__tmp14_line);
                        __tmp7_outputWritten = true;
                    }
                    if (!__tmp14_last) __out.AppendLine(true);
                }
            }
            if (__tmp7_outputWritten) __out.AppendLine(true);
            if (__tmp7_outputWritten)
            {
                __out.AppendLine(false); //349:158
            }
            __out.Write("	{"); //350:1
            __out.AppendLine(false); //350:3
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //351:10
            {
                if (!symbol.ExistingMetadataMemberNames.Contains(".ctor")) //352:10
                {
                    bool __tmp17_outputWritten = false;
                    string __tmp18_line = "        public Metadata"; //353:1
                    if (!string.IsNullOrEmpty(__tmp18_line))
                    {
                        __out.Write(__tmp18_line);
                        __tmp17_outputWritten = true;
                    }
                    var __tmp19 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp19.Write(symbol.Name);
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
                    string __tmp20_line = "(Symbol container"; //353:37
                    if (!string.IsNullOrEmpty(__tmp20_line))
                    {
                        __out.Write(__tmp20_line);
                        __tmp17_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //353:55
                    {
                        string __tmp22_line = ", object modelObject"; //353:112
                        if (!string.IsNullOrEmpty(__tmp22_line))
                        {
                            __out.Write(__tmp22_line);
                            __tmp17_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //353:133
                        {
                            string __tmp24_line = " = null"; //353:190
                            if (!string.IsNullOrEmpty(__tmp24_line))
                            {
                                __out.Write(__tmp24_line);
                                __tmp17_outputWritten = true;
                            }
                        }
                    }
                    string __tmp27_line = ")"; //353:213
                    if (!string.IsNullOrEmpty(__tmp27_line))
                    {
                        __out.Write(__tmp27_line);
                        __tmp17_outputWritten = true;
                    }
                    if (__tmp17_outputWritten) __out.AppendLine(true);
                    if (__tmp17_outputWritten)
                    {
                        __out.AppendLine(false); //353:214
                    }
                    __out.Write("            : base(container"); //354:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //354:30
                    {
                        __out.Write(", modelObject"); //354:87
                    }
                    __out.Write(")"); //354:108
                    __out.AppendLine(false); //354:109
                    __out.Write("        {"); //355:1
                    __out.AppendLine(false); //355:10
                    __out.Write("        }"); //356:1
                    __out.AppendLine(false); //356:10
                }
                if (!symbol.ExistingMetadataMemberNames.Contains("Locations")) //358:10
                {
                    __out.AppendLine(true); //359:1
                    __out.Write("        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;"); //360:1
                    __out.AppendLine(false); //360:95
                }
                if (!symbol.ExistingMetadataMemberNames.Contains("DeclaringSyntaxReferences")) //362:10
                {
                    __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;"); //363:1
                    __out.AppendLine(false); //363:124
                }
            }
            if (!symbol.ExistingMetadataMemberNames.Contains("CompleteSymbolProperty_Name")) //366:10
            {
                __out.AppendLine(true); //367:1
                __out.Write("        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //368:1
                __out.AppendLine(false); //368:126
                __out.Write("        {"); //369:1
                __out.AppendLine(false); //369:10
                __out.Write("            return ModelSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //370:1
                __out.AppendLine(false); //370:132
                __out.Write("        }"); //371:1
                __out.AppendLine(false); //371:10
            }
            if (!symbol.ExistingMetadataMemberNames.Contains("CompleteInitializingSymbol")) //373:10
            {
                __out.AppendLine(true); //374:1
                __out.Write("        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //375:1
                __out.AppendLine(false); //375:123
                __out.Write("        {"); //376:1
                __out.AppendLine(false); //376:10
                __out.Write("        }"); //377:1
                __out.AppendLine(false); //377:10
            }
            if (!symbol.ExistingMetadataMemberNames.Contains("CompleteCreatingChildSymbols")) //379:10
            {
                __out.AppendLine(true); //380:1
                __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //381:1
                __out.AppendLine(false); //381:143
                __out.Write("        {"); //382:1
                __out.AppendLine(false); //382:10
                __out.Write("            return ModelSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //383:1
                __out.AppendLine(false); //383:123
                __out.Write("        }"); //384:1
                __out.AppendLine(false); //384:10
            }
            if (!symbol.ExistingMetadataMemberNames.Contains("CompleteImports")) //386:10
            {
                __out.AppendLine(true); //387:1
                __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //388:1
                __out.AppendLine(false); //388:140
                __out.Write("        {"); //389:1
                __out.AppendLine(false); //389:10
                __out.Write("        }"); //390:1
                __out.AppendLine(false); //390:10
            }
            var __loop9_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //392:16
                where part.GenerateCompleteMethod //392:44
                select new { part = part}
                ).ToList(); //392:10
            for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
            {
                var __tmp28 = __loop9_results[__loop9_iteration];
                var part = __tmp28.part;
                if (!symbol.ExistingMetadataMemberNames.Contains(part.CompleteMethodName)) //393:14
                {
                    __out.AppendLine(true); //394:1
                    bool __tmp30_outputWritten = false;
                    string __tmp31_line = "        protected override "; //395:1
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
                    string __tmp33_line = " "; //395:59
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
                    string __tmp35_line = "("; //395:85
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
                    string __tmp37_line = ")"; //395:116
                    if (!string.IsNullOrEmpty(__tmp37_line))
                    {
                        __out.Write(__tmp37_line);
                        __tmp30_outputWritten = true;
                    }
                    if (__tmp30_outputWritten) __out.AppendLine(true);
                    if (__tmp30_outputWritten)
                    {
                        __out.AppendLine(false); //395:117
                    }
                    __out.Write("        {"); //396:1
                    __out.AppendLine(false); //396:10
                    if (part is SymbolPropertyGenerationInfo) //397:14
                    {
                        var prop = (SymbolPropertyGenerationInfo)part; //398:18
                        if (prop.IsCollection) //399:18
                        {
                            bool __tmp39_outputWritten = false;
                            string __tmp40_line = "            return ModelSymbolImplementation.AssignSymbolPropertyValues<"; //400:1
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
                            string __tmp42_line = ">(this, nameof("; //400:88
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
                            string __tmp44_line = "), diagnostics, cancellationToken);"; //400:114
                            if (!string.IsNullOrEmpty(__tmp44_line))
                            {
                                __out.Write(__tmp44_line);
                                __tmp39_outputWritten = true;
                            }
                            if (__tmp39_outputWritten) __out.AppendLine(true);
                            if (__tmp39_outputWritten)
                            {
                                __out.AppendLine(false); //400:149
                            }
                        }
                        else //401:18
                        {
                            bool __tmp46_outputWritten = false;
                            string __tmp47_line = "            return ModelSymbolImplementation.AssignSymbolPropertyValue<"; //402:1
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
                            string __tmp49_line = ">(this, nameof("; //402:83
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
                            string __tmp51_line = "), diagnostics, cancellationToken);"; //402:109
                            if (!string.IsNullOrEmpty(__tmp51_line))
                            {
                                __out.Write(__tmp51_line);
                                __tmp46_outputWritten = true;
                            }
                            if (__tmp46_outputWritten) __out.AppendLine(true);
                            if (__tmp46_outputWritten)
                            {
                                __out.AppendLine(false); //402:144
                            }
                        }
                    }
                    __out.Write("        }"); //405:1
                    __out.AppendLine(false); //405:10
                }
            }
            if (!symbol.ExistingMetadataMemberNames.Contains("CompleteNonSymbolProperties")) //408:10
            {
                __out.AppendLine(true); //409:1
                __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //410:1
                __out.AppendLine(false); //410:152
                __out.Write("        {"); //411:1
                __out.AppendLine(false); //411:10
                __out.Write("        }"); //412:1
                __out.AppendLine(false); //412:10
            }
            __out.Write("    }"); //414:1
            __out.AppendLine(false); //414:6
            __out.Write("}"); //415:1
            __out.AppendLine(false); //415:2
            return __out.ToStringAndFree();
        }

        public string GenerateSourceSymbol(SymbolGenerationInfo symbol) //418:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //419:1
            __out.AppendLine(false); //419:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //420:1
            __out.AppendLine(false); //420:29
            __out.Write("using MetaDslx.CodeAnalysis.Binding;"); //421:1
            __out.AppendLine(false); //421:37
            __out.Write("using MetaDslx.CodeAnalysis.Binding.Binders;"); //422:1
            __out.AppendLine(false); //422:45
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //423:1
            __out.AppendLine(false); //423:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //424:1
            __out.AppendLine(false); //424:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //425:1
            __out.AppendLine(false); //425:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //426:1
            __out.AppendLine(false); //426:44
            __out.Write("using System;"); //427:1
            __out.AppendLine(false); //427:14
            __out.Write("using System.Collections.Generic;"); //428:1
            __out.AppendLine(false); //428:34
            __out.Write("using System.Collections.Immutable;"); //429:1
            __out.AppendLine(false); //429:36
            __out.Write("using System.Diagnostics;"); //430:1
            __out.AppendLine(false); //430:26
            __out.Write("using System.Linq;"); //431:1
            __out.AppendLine(false); //431:19
            __out.Write("using System.Text;"); //432:1
            __out.AppendLine(false); //432:19
            __out.Write("using System.Threading;"); //433:1
            __out.AppendLine(false); //433:24
            __out.AppendLine(true); //434:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //435:1
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
            string __tmp5_line = ".Source"; //435:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //435:40
            }
            __out.Write("{"); //436:1
            __out.AppendLine(false); //436:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Source"; //437:1
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
            if (symbol.ExistingSourceBaseType == null) //437:43
            {
                string __tmp11_line = " : "; //437:86
                if (!string.IsNullOrEmpty(__tmp11_line))
                {
                    __out.Write(__tmp11_line);
                    __tmp7_outputWritten = true;
                }
                var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp12.Write(symbol.NamespaceName);
                var __tmp12Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp12.ToStringAndFree());
                bool __tmp12_last = __tmp12Reader.EndOfStream;
                while(!__tmp12_last)
                {
                    ReadOnlySpan<char> __tmp12_line = __tmp12Reader.ReadLine();
                    __tmp12_last = __tmp12Reader.EndOfStream;
                    if (!__tmp12_last || !__tmp12_line.IsEmpty)
                    {
                        __out.Write(__tmp12_line);
                        __tmp7_outputWritten = true;
                    }
                    if (!__tmp12_last) __out.AppendLine(true);
                }
                string __tmp13_line = ".Completion.Completion"; //437:111
                if (!string.IsNullOrEmpty(__tmp13_line))
                {
                    __out.Write(__tmp13_line);
                    __tmp7_outputWritten = true;
                }
                var __tmp14 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp14.Write(symbol.Name);
                var __tmp14Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp14.ToStringAndFree());
                bool __tmp14_last = __tmp14Reader.EndOfStream;
                while(!__tmp14_last)
                {
                    ReadOnlySpan<char> __tmp14_line = __tmp14Reader.ReadLine();
                    __tmp14_last = __tmp14Reader.EndOfStream;
                    if (!__tmp14_last || !__tmp14_line.IsEmpty)
                    {
                        __out.Write(__tmp14_line);
                        __tmp7_outputWritten = true;
                    }
                    if (!__tmp14_last) __out.AppendLine(true);
                }
                if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //437:147
                {
                    string __tmp16_line = ", MetaDslx.CodeAnalysis.Symbols.Source.ISourceSymbol"; //437:217
                    if (!string.IsNullOrEmpty(__tmp16_line))
                    {
                        __out.Write(__tmp16_line);
                        __tmp7_outputWritten = true;
                    }
                }
            }
            if (__tmp7_outputWritten) __out.AppendLine(true);
            if (__tmp7_outputWritten)
            {
                __out.AppendLine(false); //437:285
            }
            __out.Write("	{"); //438:1
            __out.AppendLine(false); //438:3
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //439:10
            {
                __out.Write("        private readonly MergedDeclaration _declaration;"); //440:1
                __out.AppendLine(false); //440:57
                if (!symbol.ExistingSourceMemberNames.Contains(".ctor")) //441:10
                {
                    __out.AppendLine(true); //442:1
                    bool __tmp20_outputWritten = false;
                    string __tmp21_line = "		public Source"; //443:1
                    if (!string.IsNullOrEmpty(__tmp21_line))
                    {
                        __out.Write(__tmp21_line);
                        __tmp20_outputWritten = true;
                    }
                    var __tmp22 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp22.Write(symbol.Name);
                    var __tmp22Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp22.ToStringAndFree());
                    bool __tmp22_last = __tmp22Reader.EndOfStream;
                    while(!__tmp22_last)
                    {
                        ReadOnlySpan<char> __tmp22_line = __tmp22Reader.ReadLine();
                        __tmp22_last = __tmp22Reader.EndOfStream;
                        if (!__tmp22_last || !__tmp22_line.IsEmpty)
                        {
                            __out.Write(__tmp22_line);
                            __tmp20_outputWritten = true;
                        }
                        if (!__tmp22_last) __out.AppendLine(true);
                    }
                    string __tmp23_line = "(Symbol containingSymbol, "; //443:29
                    if (!string.IsNullOrEmpty(__tmp23_line))
                    {
                        __out.Write(__tmp23_line);
                        __tmp20_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //443:56
                    {
                        string __tmp25_line = "object modelObject"; //443:113
                        if (!string.IsNullOrEmpty(__tmp25_line))
                        {
                            __out.Write(__tmp25_line);
                            __tmp20_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //443:132
                        {
                            string __tmp27_line = " = null"; //443:189
                            if (!string.IsNullOrEmpty(__tmp27_line))
                            {
                                __out.Write(__tmp27_line);
                                __tmp20_outputWritten = true;
                            }
                        }
                        string __tmp29_line = ", "; //443:204
                        if (!string.IsNullOrEmpty(__tmp29_line))
                        {
                            __out.Write(__tmp29_line);
                            __tmp20_outputWritten = true;
                        }
                    }
                    string __tmp31_line = "MergedDeclaration declaration)"; //443:214
                    if (!string.IsNullOrEmpty(__tmp31_line))
                    {
                        __out.Write(__tmp31_line);
                        __tmp20_outputWritten = true;
                    }
                    if (__tmp20_outputWritten) __out.AppendLine(true);
                    if (__tmp20_outputWritten)
                    {
                        __out.AppendLine(false); //443:244
                    }
                    __out.Write("            : base(containingSymbol"); //444:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //444:37
                    {
                        __out.Write(", modelObject"); //444:94
                    }
                    __out.Write(")"); //444:115
                    __out.AppendLine(false); //444:116
                    __out.Write("        {"); //445:1
                    __out.AppendLine(false); //445:10
                    __out.Write("            if (declaration is null) throw new ArgumentNullException(nameof(declaration));"); //446:1
                    __out.AppendLine(false); //446:91
                    __out.Write("            _declaration = declaration;"); //447:1
                    __out.AppendLine(false); //447:40
                    __out.Write("		}"); //448:1
                    __out.AppendLine(false); //448:4
                }
                if (!symbol.ExistingSourceMemberNames.Contains("MergedDeclaration")) //450:10
                {
                    __out.AppendLine(true); //451:1
                    __out.Write("        public MergedDeclaration MergedDeclaration => _declaration;"); //452:1
                    __out.AppendLine(false); //452:68
                }
                if (!symbol.ExistingSourceMemberNames.Contains("Locations")) //454:10
                {
                    __out.AppendLine(true); //455:1
                    __out.Write("        public override ImmutableArray<Location> Locations => _declaration.NameLocations;"); //456:1
                    __out.AppendLine(false); //456:90
                }
                if (!symbol.ExistingSourceMemberNames.Contains("DeclaringSyntaxReferences")) //458:10
                {
                    __out.AppendLine(true); //459:1
                    __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration.SyntaxReferences;"); //460:1
                    __out.AppendLine(false); //460:116
                }
                if (!symbol.ExistingSourceMemberNames.Contains("GetBinder")) //462:10
                {
                    __out.AppendLine(true); //463:1
                    __out.Write("        public BinderPosition<SymbolBinder> GetBinder(SyntaxReference reference)"); //464:1
                    __out.AppendLine(false); //464:81
                    __out.Write("        {"); //465:1
                    __out.AppendLine(false); //465:10
                    __out.Write("            Debug.Assert(this.DeclaringSyntaxReferences.Contains(reference));"); //466:1
                    __out.AppendLine(false); //466:78
                    __out.Write("            return FindBinders.FindSymbolBinder(this, reference);"); //467:1
                    __out.AppendLine(false); //467:66
                    __out.Write("        }"); //468:1
                    __out.AppendLine(false); //468:10
                }
                if (!symbol.ExistingSourceMemberNames.Contains("GetChildSymbol")) //470:10
                {
                    __out.AppendLine(true); //471:1
                    __out.Write("        public Symbol GetChildSymbol(SyntaxReference syntax)"); //472:1
                    __out.AppendLine(false); //472:61
                    __out.Write("        {"); //473:1
                    __out.AppendLine(false); //473:10
                    __out.Write("            foreach (var child in this.ChildSymbols)"); //474:1
                    __out.AppendLine(false); //474:53
                    __out.Write("            {"); //475:1
                    __out.AppendLine(false); //475:14
                    __out.Write("                if (child.DeclaringSyntaxReferences.Any(sr => sr.GetLocation() == syntax.GetLocation()))"); //476:1
                    __out.AppendLine(false); //476:105
                    __out.Write("                {"); //477:1
                    __out.AppendLine(false); //477:18
                    __out.Write("                    return child;"); //478:1
                    __out.AppendLine(false); //478:34
                    __out.Write("                }"); //479:1
                    __out.AppendLine(false); //479:18
                    __out.Write("            }"); //480:1
                    __out.AppendLine(false); //480:14
                    __out.Write("            return null;"); //481:1
                    __out.AppendLine(false); //481:25
                    __out.Write("        }"); //482:1
                    __out.AppendLine(false); //482:10
                }
            }
            if (!symbol.ExistingSourceMemberNames.Contains("CompleteInitializingSymbol")) //485:10
            {
                __out.AppendLine(true); //486:1
                __out.Write("        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //487:1
                __out.AppendLine(false); //487:123
                __out.Write("        {"); //488:1
                __out.AppendLine(false); //488:10
                __out.Write("        }"); //489:1
                __out.AppendLine(false); //489:10
            }
            if (!symbol.ExistingSourceMemberNames.Contains("CompleteCreatingChildSymbols")) //491:10
            {
                __out.AppendLine(true); //492:1
                __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //493:1
                __out.AppendLine(false); //493:143
                __out.Write("        {"); //494:1
                __out.AppendLine(false); //494:10
                __out.Write("            return SourceSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //495:1
                __out.AppendLine(false); //495:124
                __out.Write("        }"); //496:1
                __out.AppendLine(false); //496:10
            }
            if (!symbol.ExistingSourceMemberNames.Contains("CompleteImports")) //498:10
            {
                __out.AppendLine(true); //499:1
                __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //500:1
                __out.AppendLine(false); //500:140
                __out.Write("        {"); //501:1
                __out.AppendLine(false); //501:10
                __out.Write("            SourceSymbolImplementation.CompleteImports(this, locationOpt, diagnostics, cancellationToken);"); //502:1
                __out.AppendLine(false); //502:107
                __out.Write("        }"); //503:1
                __out.AppendLine(false); //503:10
                __out.AppendLine(true); //504:1
            }
            if (!symbol.ExistingSourceMemberNames.Contains("CompleteSymbolProperty_Name")) //506:10
            {
                __out.Write("        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //507:1
                __out.AppendLine(false); //507:126
                __out.Write("        {"); //508:1
                __out.AppendLine(false); //508:10
                __out.Write("            return SourceSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //509:1
                __out.AppendLine(false); //509:133
                __out.Write("        }"); //510:1
                __out.AppendLine(false); //510:10
            }
            __out.AppendLine(true); //512:1
            var __loop10_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //513:16
                where part.GenerateCompleteMethod //513:44
                select new { part = part}
                ).ToList(); //513:10
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                var __tmp32 = __loop10_results[__loop10_iteration];
                var part = __tmp32.part;
                if (!symbol.ExistingSourceMemberNames.Contains(part.CompleteMethodName)) //514:14
                {
                    bool __tmp34_outputWritten = false;
                    string __tmp35_line = "        protected override "; //515:1
                    if (!string.IsNullOrEmpty(__tmp35_line))
                    {
                        __out.Write(__tmp35_line);
                        __tmp34_outputWritten = true;
                    }
                    var __tmp36 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp36.Write(part.CompleteMethodReturnType);
                    var __tmp36Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp36.ToStringAndFree());
                    bool __tmp36_last = __tmp36Reader.EndOfStream;
                    while(!__tmp36_last)
                    {
                        ReadOnlySpan<char> __tmp36_line = __tmp36Reader.ReadLine();
                        __tmp36_last = __tmp36Reader.EndOfStream;
                        if (!__tmp36_last || !__tmp36_line.IsEmpty)
                        {
                            __out.Write(__tmp36_line);
                            __tmp34_outputWritten = true;
                        }
                        if (!__tmp36_last) __out.AppendLine(true);
                    }
                    string __tmp37_line = " "; //515:59
                    if (!string.IsNullOrEmpty(__tmp37_line))
                    {
                        __out.Write(__tmp37_line);
                        __tmp34_outputWritten = true;
                    }
                    var __tmp38 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp38.Write(part.CompleteMethodName);
                    var __tmp38Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp38.ToStringAndFree());
                    bool __tmp38_last = __tmp38Reader.EndOfStream;
                    while(!__tmp38_last)
                    {
                        ReadOnlySpan<char> __tmp38_line = __tmp38Reader.ReadLine();
                        __tmp38_last = __tmp38Reader.EndOfStream;
                        if (!__tmp38_last || !__tmp38_line.IsEmpty)
                        {
                            __out.Write(__tmp38_line);
                            __tmp34_outputWritten = true;
                        }
                        if (!__tmp38_last) __out.AppendLine(true);
                    }
                    string __tmp39_line = "("; //515:85
                    if (!string.IsNullOrEmpty(__tmp39_line))
                    {
                        __out.Write(__tmp39_line);
                        __tmp34_outputWritten = true;
                    }
                    var __tmp40 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp40.Write(part.CompleteMethodParamList);
                    var __tmp40Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp40.ToStringAndFree());
                    bool __tmp40_last = __tmp40Reader.EndOfStream;
                    while(!__tmp40_last)
                    {
                        ReadOnlySpan<char> __tmp40_line = __tmp40Reader.ReadLine();
                        __tmp40_last = __tmp40Reader.EndOfStream;
                        if (!__tmp40_last || !__tmp40_line.IsEmpty)
                        {
                            __out.Write(__tmp40_line);
                            __tmp34_outputWritten = true;
                        }
                        if (!__tmp40_last) __out.AppendLine(true);
                    }
                    string __tmp41_line = ")"; //515:116
                    if (!string.IsNullOrEmpty(__tmp41_line))
                    {
                        __out.Write(__tmp41_line);
                        __tmp34_outputWritten = true;
                    }
                    if (__tmp34_outputWritten) __out.AppendLine(true);
                    if (__tmp34_outputWritten)
                    {
                        __out.AppendLine(false); //515:117
                    }
                    __out.Write("        {"); //516:1
                    __out.AppendLine(false); //516:10
                    if (part is SymbolPropertyGenerationInfo) //517:14
                    {
                        var prop = (SymbolPropertyGenerationInfo)part; //518:18
                        if (prop.IsCollection) //519:18
                        {
                            bool __tmp43_outputWritten = false;
                            string __tmp44_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValues<"; //520:1
                            if (!string.IsNullOrEmpty(__tmp44_line))
                            {
                                __out.Write(__tmp44_line);
                                __tmp43_outputWritten = true;
                            }
                            var __tmp45 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp45.Write(prop.ItemType);
                            var __tmp45Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp45.ToStringAndFree());
                            bool __tmp45_last = __tmp45Reader.EndOfStream;
                            while(!__tmp45_last)
                            {
                                ReadOnlySpan<char> __tmp45_line = __tmp45Reader.ReadLine();
                                __tmp45_last = __tmp45Reader.EndOfStream;
                                if (!__tmp45_last || !__tmp45_line.IsEmpty)
                                {
                                    __out.Write(__tmp45_line);
                                    __tmp43_outputWritten = true;
                                }
                                if (!__tmp45_last) __out.AppendLine(true);
                            }
                            string __tmp46_line = ">(this, nameof("; //520:89
                            if (!string.IsNullOrEmpty(__tmp46_line))
                            {
                                __out.Write(__tmp46_line);
                                __tmp43_outputWritten = true;
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
                                    __tmp43_outputWritten = true;
                                }
                                if (!__tmp47_last) __out.AppendLine(true);
                            }
                            string __tmp48_line = "), diagnostics, cancellationToken);"; //520:115
                            if (!string.IsNullOrEmpty(__tmp48_line))
                            {
                                __out.Write(__tmp48_line);
                                __tmp43_outputWritten = true;
                            }
                            if (__tmp43_outputWritten) __out.AppendLine(true);
                            if (__tmp43_outputWritten)
                            {
                                __out.AppendLine(false); //520:150
                            }
                        }
                        else //521:18
                        {
                            bool __tmp50_outputWritten = false;
                            string __tmp51_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValue<"; //522:1
                            if (!string.IsNullOrEmpty(__tmp51_line))
                            {
                                __out.Write(__tmp51_line);
                                __tmp50_outputWritten = true;
                            }
                            var __tmp52 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp52.Write(prop.Type);
                            var __tmp52Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp52.ToStringAndFree());
                            bool __tmp52_last = __tmp52Reader.EndOfStream;
                            while(!__tmp52_last)
                            {
                                ReadOnlySpan<char> __tmp52_line = __tmp52Reader.ReadLine();
                                __tmp52_last = __tmp52Reader.EndOfStream;
                                if (!__tmp52_last || !__tmp52_line.IsEmpty)
                                {
                                    __out.Write(__tmp52_line);
                                    __tmp50_outputWritten = true;
                                }
                                if (!__tmp52_last) __out.AppendLine(true);
                            }
                            string __tmp53_line = ">(this, nameof("; //522:84
                            if (!string.IsNullOrEmpty(__tmp53_line))
                            {
                                __out.Write(__tmp53_line);
                                __tmp50_outputWritten = true;
                            }
                            var __tmp54 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp54.Write(prop.Name);
                            var __tmp54Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp54.ToStringAndFree());
                            bool __tmp54_last = __tmp54Reader.EndOfStream;
                            while(!__tmp54_last)
                            {
                                ReadOnlySpan<char> __tmp54_line = __tmp54Reader.ReadLine();
                                __tmp54_last = __tmp54Reader.EndOfStream;
                                if (!__tmp54_last || !__tmp54_line.IsEmpty)
                                {
                                    __out.Write(__tmp54_line);
                                    __tmp50_outputWritten = true;
                                }
                                if (!__tmp54_last) __out.AppendLine(true);
                            }
                            string __tmp55_line = "), diagnostics, cancellationToken);"; //522:110
                            if (!string.IsNullOrEmpty(__tmp55_line))
                            {
                                __out.Write(__tmp55_line);
                                __tmp50_outputWritten = true;
                            }
                            if (__tmp50_outputWritten) __out.AppendLine(true);
                            if (__tmp50_outputWritten)
                            {
                                __out.AppendLine(false); //522:145
                            }
                        }
                    }
                    __out.Write("        }"); //525:1
                    __out.AppendLine(false); //525:10
                }
            }
            if (!symbol.ExistingSourceMemberNames.Contains("CompleteNonSymbolProperties")) //528:10
            {
                __out.AppendLine(true); //529:1
                __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //530:1
                __out.AppendLine(false); //530:152
                __out.Write("        {"); //531:1
                __out.AppendLine(false); //531:10
                __out.Write("            SourceSymbolImplementation.AssignNonSymbolProperties(this, diagnostics, cancellationToken);"); //532:1
                __out.AppendLine(false); //532:104
                __out.Write("        }"); //533:1
                __out.AppendLine(false); //533:10
            }
            __out.AppendLine(true); //535:1
            __out.Write("	}"); //536:1
            __out.AppendLine(false); //536:3
            __out.Write("}"); //537:1
            __out.AppendLine(false); //537:2
            return __out.ToStringAndFree();
        }

        public string GenerateVisitor(string namespaceName, IEnumerable<SymbolGenerationInfo> symbols) //540:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //541:1
            __out.AppendLine(false); //541:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //542:1
            __out.AppendLine(false); //542:29
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //543:1
            __out.AppendLine(false); //543:37
            __out.Write("using System;"); //544:1
            __out.AppendLine(false); //544:14
            __out.Write("using System.Collections.Generic;"); //545:1
            __out.AppendLine(false); //545:34
            __out.Write("using System.Collections.Immutable;"); //546:1
            __out.AppendLine(false); //546:36
            __out.Write("using System.Diagnostics;"); //547:1
            __out.AppendLine(false); //547:26
            __out.Write("using System.Text;"); //548:1
            __out.AppendLine(false); //548:19
            __out.Write("using System.Threading;"); //549:1
            __out.AppendLine(false); //549:24
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //551:1
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
                __out.AppendLine(false); //551:26
            }
            __out.Write("{"); //552:1
            __out.AppendLine(false); //552:2
            __out.Write("	public interface ISymbolVisitor"); //553:1
            __out.AppendLine(false); //553:33
            __out.Write("	{"); //554:1
            __out.AppendLine(false); //554:3
            var __loop11_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //555:16
                select new { symbol = symbol}
                ).ToList(); //555:10
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp5 = __loop11_results[__loop11_iteration];
                var symbol = __tmp5.symbol;
                bool __tmp7_outputWritten = false;
                string __tmp8_line = "        void Visit("; //556:1
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
                string __tmp10_line = " symbol);"; //556:33
                if (!string.IsNullOrEmpty(__tmp10_line))
                {
                    __out.Write(__tmp10_line);
                    __tmp7_outputWritten = true;
                }
                if (__tmp7_outputWritten) __out.AppendLine(true);
                if (__tmp7_outputWritten)
                {
                    __out.AppendLine(false); //556:42
                }
            }
            __out.Write("	}"); //558:1
            __out.AppendLine(false); //558:3
            __out.AppendLine(true); //559:1
            __out.Write("	public interface ISymbolVisitor<TResult>"); //560:1
            __out.AppendLine(false); //560:42
            __out.Write("	{"); //561:1
            __out.AppendLine(false); //561:3
            var __loop12_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //562:16
                select new { symbol = symbol}
                ).ToList(); //562:10
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp11 = __loop12_results[__loop12_iteration];
                var symbol = __tmp11.symbol;
                bool __tmp13_outputWritten = false;
                string __tmp14_line = "        TResult Visit("; //563:1
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
                string __tmp16_line = " symbol);"; //563:36
                if (!string.IsNullOrEmpty(__tmp16_line))
                {
                    __out.Write(__tmp16_line);
                    __tmp13_outputWritten = true;
                }
                if (__tmp13_outputWritten) __out.AppendLine(true);
                if (__tmp13_outputWritten)
                {
                    __out.AppendLine(false); //563:45
                }
            }
            __out.Write("	}"); //565:1
            __out.AppendLine(false); //565:3
            __out.AppendLine(true); //566:1
            __out.Write("	public interface ISymbolVisitor<TArgument, TResult>"); //567:1
            __out.AppendLine(false); //567:53
            __out.Write("	{"); //568:1
            __out.AppendLine(false); //568:3
            var __loop13_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //569:16
                select new { symbol = symbol}
                ).ToList(); //569:10
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp17 = __loop13_results[__loop13_iteration];
                var symbol = __tmp17.symbol;
                bool __tmp19_outputWritten = false;
                string __tmp20_line = "        TResult Visit("; //570:1
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
                string __tmp22_line = " symbol, TArgument argument);"; //570:36
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Write(__tmp22_line);
                    __tmp19_outputWritten = true;
                }
                if (__tmp19_outputWritten) __out.AppendLine(true);
                if (__tmp19_outputWritten)
                {
                    __out.AppendLine(false); //570:65
                }
            }
            __out.Write("	}"); //572:1
            __out.AppendLine(false); //572:3
            __out.Write("}"); //573:1
            __out.AppendLine(false); //573:2
            return __out.ToStringAndFree();
        }

    }
}

