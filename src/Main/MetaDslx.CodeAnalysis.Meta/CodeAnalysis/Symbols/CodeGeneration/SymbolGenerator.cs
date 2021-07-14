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
                var __tmp54 = __loop5_results[__loop5_iteration];
                var prop = __tmp54.prop;
                bool __tmp56_outputWritten = false;
                string __tmp57_line = "        private "; //93:1
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
                string __tmp59_line = " "; //93:28
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
                string __tmp61_line = ";"; //93:45
                if (!string.IsNullOrEmpty(__tmp61_line))
                {
                    __out.Write(__tmp61_line);
                    __tmp56_outputWritten = true;
                }
                if (__tmp56_outputWritten) __out.AppendLine(true);
                if (__tmp56_outputWritten)
                {
                    __out.AppendLine(false); //93:46
                }
            }
            if (!symbol.ExistingCompletionMemberNames.Contains(".ctor")) //95:10
            {
                __out.AppendLine(true); //96:1
                bool __tmp63_outputWritten = false;
                string __tmp64_line = "        public Completion"; //97:1
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
                string __tmp66_line = "(Symbol container"; //97:39
                if (!string.IsNullOrEmpty(__tmp66_line))
                {
                    __out.Write(__tmp66_line);
                    __tmp63_outputWritten = true;
                }
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //97:57
                {
                    string __tmp68_line = ", object? modelObject"; //97:114
                    if (!string.IsNullOrEmpty(__tmp68_line))
                    {
                        __out.Write(__tmp68_line);
                        __tmp63_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption == ParameterOption.Optional) //97:136
                    {
                        string __tmp70_line = " = null"; //97:193
                        if (!string.IsNullOrEmpty(__tmp70_line))
                        {
                            __out.Write(__tmp70_line);
                            __tmp63_outputWritten = true;
                        }
                    }
                }
                string __tmp73_line = ")"; //97:216
                if (!string.IsNullOrEmpty(__tmp73_line))
                {
                    __out.Write(__tmp73_line);
                    __tmp63_outputWritten = true;
                }
                if (__tmp63_outputWritten) __out.AppendLine(true);
                if (__tmp63_outputWritten)
                {
                    __out.AppendLine(false); //97:217
                }
                __out.Write("        {"); //98:1
                __out.AppendLine(false); //98:10
                __out.Write("            _container = container;"); //99:1
                __out.AppendLine(false); //99:36
                if (symbol.ModelObjectOption == ParameterOption.Required) //100:14
                {
                    __out.Write("            if (modelObject is null) throw new ArgumentNullException(nameof(modelObject));"); //101:1
                    __out.AppendLine(false); //101:91
                }
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //103:14
                {
                    __out.Write("            _modelObject = modelObject;"); //104:1
                    __out.AppendLine(false); //104:40
                }
                __out.Write("            _state = CompletionParts.CompletionGraph.CreateState();"); //106:1
                __out.AppendLine(false); //106:68
                __out.Write("        }"); //107:1
                __out.AppendLine(false); //107:10
            }
            if (!symbol.ExistingCompletionMemberNames.Contains("Language")) //109:10
            {
                __out.AppendLine(true); //110:1
                __out.Write("        public sealed override Language Language => ContainingModule.Language;"); //111:1
                __out.AppendLine(false); //111:79
            }
            if (!symbol.ExistingCompletionMemberNames.Contains("SymbolFactory")) //113:10
            {
                __out.AppendLine(true); //114:1
                __out.Write("        public SymbolFactory SymbolFactory => ContainingModule.SymbolFactory;"); //115:1
                __out.AppendLine(false); //115:78
            }
            if (symbol.ModelObjectOption != ParameterOption.Disabled) //117:10
            {
                if (!symbol.ExistingCompletionMemberNames.Contains("ModelObject")) //118:14
                {
                    __out.AppendLine(true); //119:1
                    __out.Write("        public object ModelObject => _modelObject;"); //120:1
                    __out.AppendLine(false); //120:51
                }
                if (!symbol.ExistingCompletionMemberNames.Contains("ModelObjectType")) //122:14
                {
                    __out.AppendLine(true); //123:1
                    __out.Write("        public Type ModelObjectType => _modelObject is not null ? Language.SymbolFacts.GetModelObjectType(_modelObject) : null;"); //124:1
                    __out.AppendLine(false); //124:128
                }
            }
            if (!symbol.ExistingCompletionMemberNames.Contains("ContainingSymbol")) //127:10
            {
                __out.AppendLine(true); //128:1
                __out.Write("        public sealed override Symbol ContainingSymbol => _container;"); //129:1
                __out.AppendLine(false); //129:70
            }
            if (!symbol.ExistingCompletionMemberNames.Contains("ChildSymbols")) //131:10
            {
                __out.AppendLine(true); //132:1
                __out.Write("        public sealed override ImmutableArray<Symbol> ChildSymbols "); //133:1
                __out.AppendLine(false); //133:68
                __out.Write("        {"); //134:1
                __out.AppendLine(false); //134:10
                __out.Write("            get"); //135:1
                __out.AppendLine(false); //135:16
                __out.Write("            {"); //136:1
                __out.AppendLine(false); //136:14
                __out.Write("                this.ForceComplete(CompletionGraph.FinishCreatingChildren, null, default);"); //137:1
                __out.AppendLine(false); //137:91
                __out.Write("                return _childSymbols;"); //138:1
                __out.AppendLine(false); //138:38
                __out.Write("            }"); //139:1
                __out.AppendLine(false); //139:14
                __out.Write("        }"); //140:1
                __out.AppendLine(false); //140:10
            }
            if (!symbol.ExistingCompletionMemberNames.Contains("Name")) //142:10
            {
                __out.AppendLine(true); //143:1
                __out.Write("        public override string Name "); //144:1
                __out.AppendLine(false); //144:37
                __out.Write("        {"); //145:1
                __out.AppendLine(false); //145:10
                __out.Write("            get"); //146:1
                __out.AppendLine(false); //146:16
                __out.Write("            {"); //147:1
                __out.AppendLine(false); //147:14
                __out.Write("                this.ForceComplete(CompletionGraph.FinishInitializing, null, default);"); //148:1
                __out.AppendLine(false); //148:87
                __out.Write("                return _name;"); //149:1
                __out.AppendLine(false); //149:30
                __out.Write("            }"); //150:1
                __out.AppendLine(false); //150:14
                __out.Write("        }"); //151:1
                __out.AppendLine(false); //151:10
            }
            var __loop6_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //153:16
                select new { prop = prop}
                ).ToList(); //153:10
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp74 = __loop6_results[__loop6_iteration];
                var prop = __tmp74.prop;
                if (!symbol.ExistingCompletionMemberNames.Contains(prop.Name)) //154:14
                {
                    __out.AppendLine(true); //155:1
                    bool __tmp76_outputWritten = false;
                    string __tmp77_line = "        public override "; //156:1
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
                    string __tmp79_line = " "; //156:36
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
                        __out.AppendLine(false); //156:48
                    }
                    __out.Write("        {"); //157:1
                    __out.AppendLine(false); //157:10
                    __out.Write("            get"); //158:1
                    __out.AppendLine(false); //158:16
                    __out.Write("            {"); //159:1
                    __out.AppendLine(false); //159:14
                    bool __tmp82_outputWritten = false;
                    string __tmp83_line = "                this.ForceComplete(CompletionParts."; //160:1
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
                    string __tmp85_line = ", null, default);"; //160:83
                    if (!string.IsNullOrEmpty(__tmp85_line))
                    {
                        __out.Write(__tmp85_line);
                        __tmp82_outputWritten = true;
                    }
                    if (__tmp82_outputWritten) __out.AppendLine(true);
                    if (__tmp82_outputWritten)
                    {
                        __out.AppendLine(false); //160:100
                    }
                    bool __tmp87_outputWritten = false;
                    string __tmp88_line = "                return "; //161:1
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
                    string __tmp90_line = ";"; //161:40
                    if (!string.IsNullOrEmpty(__tmp90_line))
                    {
                        __out.Write(__tmp90_line);
                        __tmp87_outputWritten = true;
                    }
                    if (__tmp87_outputWritten) __out.AppendLine(true);
                    if (__tmp87_outputWritten)
                    {
                        __out.AppendLine(false); //161:41
                    }
                    __out.Write("            }"); //162:1
                    __out.AppendLine(false); //162:14
                    __out.Write("        }"); //163:1
                    __out.AppendLine(false); //163:10
                }
            }
            __out.AppendLine(true); //166:1
            __out.Write("        #region Completion"); //167:1
            __out.AppendLine(false); //167:27
            __out.AppendLine(true); //168:1
            __out.Write("        public sealed override bool RequiresCompletion => true;"); //169:1
            __out.AppendLine(false); //169:64
            __out.AppendLine(true); //170:1
            __out.Write("        public sealed override bool HasComplete(CompletionPart part)"); //171:1
            __out.AppendLine(false); //171:69
            __out.Write("        {"); //172:1
            __out.AppendLine(false); //172:10
            __out.Write("            return _state.HasComplete(part);"); //173:1
            __out.AppendLine(false); //173:45
            __out.Write("        }"); //174:1
            __out.AppendLine(false); //174:10
            __out.AppendLine(true); //175:1
            __out.Write("        public override void ForceComplete(CompletionPart completionPart, SourceLocation locationOpt, CancellationToken cancellationToken)"); //176:1
            __out.AppendLine(false); //176:139
            __out.Write("        {"); //177:1
            __out.AppendLine(false); //177:10
            __out.Write("            if (completionPart != null && _state.HasComplete(completionPart)) return;"); //178:1
            __out.AppendLine(false); //178:86
            __out.Write("            if (completionPart != null && !CompletionParts.All.Contains(completionPart)) throw new ArgumentException(nameof(completionPart));"); //179:1
            __out.AppendLine(false); //179:142
            __out.Write("            while (true)"); //180:1
            __out.AppendLine(false); //180:25
            __out.Write("            {"); //181:1
            __out.AppendLine(false); //181:14
            __out.Write("                cancellationToken.ThrowIfCancellationRequested();"); //182:1
            __out.AppendLine(false); //182:66
            __out.Write("                var incompletePart = _state.NextIncompletePart;"); //183:1
            __out.AppendLine(false); //183:64
            __out.Write("                if (incompletePart == CompletionGraph.StartInitializing || incompletePart == CompletionGraph.FinishInitializing)"); //184:1
            __out.AppendLine(false); //184:129
            __out.Write("                {"); //185:1
            __out.AppendLine(false); //185:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartInitializing))"); //186:1
            __out.AppendLine(false); //186:84
            __out.Write("                    {"); //187:1
            __out.AppendLine(false); //187:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //188:1
            __out.AppendLine(false); //188:71
            __out.Write("                        _name = CompleteSymbolProperty_Name(diagnostics, cancellationToken);"); //189:1
            __out.AppendLine(false); //189:93
            __out.Write("                        CompleteInitializingSymbol(diagnostics, cancellationToken);"); //190:1
            __out.AppendLine(false); //190:84
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //191:1
            __out.AppendLine(false); //191:59
            __out.Write("                        diagnostics.Free();"); //192:1
            __out.AppendLine(false); //192:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishInitializing);"); //193:1
            __out.AppendLine(false); //193:85
            __out.Write("                    }"); //194:1
            __out.AppendLine(false); //194:22
            __out.Write("                }"); //195:1
            __out.AppendLine(false); //195:18
            __out.Write("                else if (incompletePart == CompletionGraph.StartCreatingChildren || incompletePart == CompletionGraph.FinishCreatingChildren)"); //196:1
            __out.AppendLine(false); //196:142
            __out.Write("                {"); //197:1
            __out.AppendLine(false); //197:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartCreatingChildren))"); //198:1
            __out.AppendLine(false); //198:88
            __out.Write("                    {"); //199:1
            __out.AppendLine(false); //199:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //200:1
            __out.AppendLine(false); //200:71
            __out.Write("                        _childSymbols = CompleteCreatingChildSymbols(diagnostics, cancellationToken);"); //201:1
            __out.AppendLine(false); //201:102
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //202:1
            __out.AppendLine(false); //202:59
            __out.Write("                        diagnostics.Free();"); //203:1
            __out.AppendLine(false); //203:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishCreatingChildren);"); //204:1
            __out.AppendLine(false); //204:89
            __out.Write("                    }"); //205:1
            __out.AppendLine(false); //205:22
            __out.Write("                }"); //206:1
            __out.AppendLine(false); //206:18
            var __loop7_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //207:24
                select new { part = part}
                ).ToList(); //207:18
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                var __tmp91 = __loop7_results[__loop7_iteration];
                var part = __tmp91.part;
                if (part.IsLocked) //208:22
                {
                    bool __tmp93_outputWritten = false;
                    string __tmp94_line = "                else if (incompletePart == CompletionParts."; //209:1
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
                    string __tmp96_line = " || incompletePart == CompletionParts."; //209:90
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
                    string __tmp98_line = ")"; //209:159
                    if (!string.IsNullOrEmpty(__tmp98_line))
                    {
                        __out.Write(__tmp98_line);
                        __tmp93_outputWritten = true;
                    }
                    if (__tmp93_outputWritten) __out.AppendLine(true);
                    if (__tmp93_outputWritten)
                    {
                        __out.AppendLine(false); //209:160
                    }
                    __out.Write("                {"); //210:1
                    __out.AppendLine(false); //210:18
                    bool __tmp100_outputWritten = false;
                    string __tmp101_line = "                    if (_state.NotePartComplete(CompletionParts."; //211:1
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
                    string __tmp103_line = "))"; //211:95
                    if (!string.IsNullOrEmpty(__tmp103_line))
                    {
                        __out.Write(__tmp103_line);
                        __tmp100_outputWritten = true;
                    }
                    if (__tmp100_outputWritten) __out.AppendLine(true);
                    if (__tmp100_outputWritten)
                    {
                        __out.AppendLine(false); //211:97
                    }
                    __out.Write("                    {"); //212:1
                    __out.AppendLine(false); //212:22
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //213:26
                    {
                        __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //214:1
                        __out.AppendLine(false); //214:71
                    }
                    bool __tmp105_outputWritten = false;
                    string __tmp104Prefix = "                        "; //216:1
                    if (part is SymbolPropertyGenerationInfo) //216:26
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
                        string __tmp108_line = " = "; //216:116
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
                    string __tmp111_line = "("; //216:152
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
                    string __tmp113_line = ");"; //216:181
                    if (!string.IsNullOrEmpty(__tmp113_line))
                    {
                        __out.Write(__tmp113_line);
                        __tmp105_outputWritten = true;
                    }
                    if (__tmp105_outputWritten) __out.AppendLine(true);
                    if (__tmp105_outputWritten)
                    {
                        __out.AppendLine(false); //216:183
                    }
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //217:26
                    {
                        __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //218:1
                        __out.AppendLine(false); //218:59
                        __out.Write("                        diagnostics.Free();"); //219:1
                        __out.AppendLine(false); //219:44
                    }
                    bool __tmp115_outputWritten = false;
                    string __tmp116_line = "                        _state.NotePartComplete(CompletionParts."; //221:1
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
                    string __tmp118_line = ");"; //221:96
                    if (!string.IsNullOrEmpty(__tmp118_line))
                    {
                        __out.Write(__tmp118_line);
                        __tmp115_outputWritten = true;
                    }
                    if (__tmp115_outputWritten) __out.AppendLine(true);
                    if (__tmp115_outputWritten)
                    {
                        __out.AppendLine(false); //221:98
                    }
                    __out.Write("                    }"); //222:1
                    __out.AppendLine(false); //222:22
                    __out.Write("                }"); //223:1
                    __out.AppendLine(false); //223:18
                }
                else //224:22
                {
                    bool __tmp120_outputWritten = false;
                    string __tmp121_line = "                else if (incompletePart == CompletionParts."; //225:1
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
                    string __tmp123_line = ")"; //225:85
                    if (!string.IsNullOrEmpty(__tmp123_line))
                    {
                        __out.Write(__tmp123_line);
                        __tmp120_outputWritten = true;
                    }
                    if (__tmp120_outputWritten) __out.AppendLine(true);
                    if (__tmp120_outputWritten)
                    {
                        __out.AppendLine(false); //225:86
                    }
                    __out.Write("                {"); //226:1
                    __out.AppendLine(false); //226:18
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //227:22
                    {
                        __out.Write("                    var diagnostics = DiagnosticBag.GetInstance();"); //228:1
                        __out.AppendLine(false); //228:67
                    }
                    bool __tmp125_outputWritten = false;
                    string __tmp124Prefix = "                    "; //230:1
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
                    string __tmp127_line = "("; //230:46
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
                    string __tmp129_line = ");"; //230:75
                    if (!string.IsNullOrEmpty(__tmp129_line))
                    {
                        __out.Write(__tmp129_line);
                        __tmp125_outputWritten = true;
                    }
                    if (__tmp125_outputWritten) __out.AppendLine(true);
                    if (__tmp125_outputWritten)
                    {
                        __out.AppendLine(false); //230:77
                    }
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //231:22
                    {
                        __out.Write("                    AddSymbolDiagnostics(diagnostics);"); //232:1
                        __out.AppendLine(false); //232:55
                        __out.Write("                    diagnostics.Free();"); //233:1
                        __out.AppendLine(false); //233:40
                    }
                    bool __tmp131_outputWritten = false;
                    string __tmp132_line = "                    _state.NotePartComplete(CompletionParts."; //235:1
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
                    string __tmp134_line = ");"; //235:86
                    if (!string.IsNullOrEmpty(__tmp134_line))
                    {
                        __out.Write(__tmp134_line);
                        __tmp131_outputWritten = true;
                    }
                    if (__tmp131_outputWritten) __out.AppendLine(true);
                    if (__tmp131_outputWritten)
                    {
                        __out.AppendLine(false); //235:88
                    }
                    __out.Write("                }"); //236:1
                    __out.AppendLine(false); //236:18
                }
            }
            __out.Write("                else if (incompletePart == CompletionGraph.StartComputingNonSymbolProperties || incompletePart == CompletionGraph.FinishComputingNonSymbolProperties)"); //239:1
            __out.AppendLine(false); //239:166
            __out.Write("                {"); //240:1
            __out.AppendLine(false); //240:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartComputingNonSymbolProperties))"); //241:1
            __out.AppendLine(false); //241:100
            __out.Write("                    {"); //242:1
            __out.AppendLine(false); //242:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //243:1
            __out.AppendLine(false); //243:71
            __out.Write("                        CompleteNonSymbolProperties(locationOpt, diagnostics, cancellationToken);"); //244:1
            __out.AppendLine(false); //244:98
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //245:1
            __out.AppendLine(false); //245:59
            __out.Write("                        diagnostics.Free();"); //246:1
            __out.AppendLine(false); //246:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishComputingNonSymbolProperties);"); //247:1
            __out.AppendLine(false); //247:101
            __out.Write("                    }"); //248:1
            __out.AppendLine(false); //248:22
            __out.Write("                }"); //249:1
            __out.AppendLine(false); //249:18
            __out.Write("                else if (incompletePart == CompletionGraph.ChildrenCompleted)"); //250:1
            __out.AppendLine(false); //250:78
            __out.Write("                {"); //251:1
            __out.AppendLine(false); //251:18
            __out.Write("                    var diagnostics = DiagnosticBag.GetInstance();"); //252:1
            __out.AppendLine(false); //252:67
            __out.Write("                    CompleteImports(locationOpt, diagnostics, cancellationToken);"); //253:1
            __out.AppendLine(false); //253:82
            __out.Write("                    AddSymbolDiagnostics(diagnostics);"); //254:1
            __out.AppendLine(false); //254:55
            __out.Write("                    diagnostics.Free();"); //255:1
            __out.AppendLine(false); //255:40
            __out.Write("                    bool allCompleted = true;"); //257:1
            __out.AppendLine(false); //257:46
            __out.Write("                    if (locationOpt == null)"); //258:1
            __out.AppendLine(false); //258:45
            __out.Write("                    {"); //259:1
            __out.AppendLine(false); //259:22
            __out.Write("                        foreach (var child in _childSymbols)"); //260:1
            __out.AppendLine(false); //260:61
            __out.Write("                        {"); //261:1
            __out.AppendLine(false); //261:26
            __out.Write("                            cancellationToken.ThrowIfCancellationRequested();"); //262:1
            __out.AppendLine(false); //262:78
            __out.Write("                            child.ForceComplete(null, locationOpt, cancellationToken);"); //263:1
            __out.AppendLine(false); //263:87
            __out.Write("                        }"); //264:1
            __out.AppendLine(false); //264:26
            __out.Write("                    }"); //265:1
            __out.AppendLine(false); //265:22
            __out.Write("                    else"); //266:1
            __out.AppendLine(false); //266:25
            __out.Write("                    {"); //267:1
            __out.AppendLine(false); //267:22
            __out.Write("                        foreach (var child in _childSymbols)"); //268:1
            __out.AppendLine(false); //268:61
            __out.Write("                        {"); //269:1
            __out.AppendLine(false); //269:26
            __out.Write("                            ForceCompleteChildByLocation(locationOpt, child, cancellationToken);"); //270:1
            __out.AppendLine(false); //270:97
            __out.Write("                            allCompleted = allCompleted && child.HasComplete(CompletionGraph.All);"); //271:1
            __out.AppendLine(false); //271:99
            __out.Write("                        }"); //272:1
            __out.AppendLine(false); //272:26
            __out.Write("                    }"); //273:1
            __out.AppendLine(false); //273:22
            __out.Write("                    if (!allCompleted)"); //275:1
            __out.AppendLine(false); //275:39
            __out.Write("                    {"); //276:1
            __out.AppendLine(false); //276:22
            __out.Write("                        // We did not complete all members, so just kick out now."); //277:1
            __out.AppendLine(false); //277:82
            __out.Write("                        var allParts = CompletionParts.AllWithLocation;"); //278:1
            __out.AppendLine(false); //278:72
            __out.Write("                        _state.SpinWaitComplete(allParts, cancellationToken);"); //279:1
            __out.AppendLine(false); //279:78
            __out.Write("                        return;"); //280:1
            __out.AppendLine(false); //280:32
            __out.Write("                    }"); //281:1
            __out.AppendLine(false); //281:22
            __out.Write("                    // We've completed all members, proceed to the next iteration."); //283:1
            __out.AppendLine(false); //283:83
            __out.Write("                    _state.NotePartComplete(CompletionGraph.ChildrenCompleted);"); //284:1
            __out.AppendLine(false); //284:80
            __out.Write("                }"); //285:1
            __out.AppendLine(false); //285:18
            __out.Write("                if (incompletePart == null)"); //286:1
            __out.AppendLine(false); //286:44
            __out.Write("                {"); //287:1
            __out.AppendLine(false); //287:18
            __out.Write("                    return;"); //288:1
            __out.AppendLine(false); //288:28
            __out.Write("                }"); //289:1
            __out.AppendLine(false); //289:18
            __out.Write("                else"); //290:1
            __out.AppendLine(false); //290:21
            __out.Write("                {"); //291:1
            __out.AppendLine(false); //291:18
            __out.Write("                    // This assert will trigger if we forgot to handle any of the completion parts"); //292:1
            __out.AppendLine(false); //292:99
            __out.Write("                    Debug.Assert(!CompletionParts.All.Contains(incompletePart));"); //293:1
            __out.AppendLine(false); //293:81
            __out.Write("                    // any other values are completion parts intended for other kinds of symbols"); //294:1
            __out.AppendLine(false); //294:97
            __out.Write("                    _state.NotePartComplete(incompletePart);"); //295:1
            __out.AppendLine(false); //295:61
            __out.Write("                }"); //296:1
            __out.AppendLine(false); //296:18
            __out.Write("                if (completionPart != null && _state.HasComplete(completionPart)) return;"); //297:1
            __out.AppendLine(false); //297:90
            __out.Write("                _state.SpinWaitComplete(incompletePart, cancellationToken);"); //298:1
            __out.AppendLine(false); //298:76
            __out.Write("            }"); //299:1
            __out.AppendLine(false); //299:14
            __out.Write("            throw ExceptionUtilities.Unreachable;"); //300:1
            __out.AppendLine(false); //300:50
            __out.Write("        }"); //301:1
            __out.AppendLine(false); //301:10
            __out.AppendLine(true); //302:1
            if (!symbol.ExistingCompletionMemberNames.Contains("CompleteSymbolProperty_Name")) //303:10
            {
                __out.Write("        protected abstract string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //304:1
                __out.AppendLine(false); //304:127
            }
            if (!symbol.ExistingCompletionMemberNames.Contains("CompleteInitializingSymbol")) //306:10
            {
                __out.Write("        protected abstract void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //307:1
                __out.AppendLine(false); //307:124
            }
            if (!symbol.ExistingCompletionMemberNames.Contains("CompleteCreatingChildSymbols")) //309:10
            {
                __out.Write("        protected abstract ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //310:1
                __out.AppendLine(false); //310:144
            }
            if (!symbol.ExistingCompletionMemberNames.Contains("CompleteImports")) //312:10
            {
                __out.Write("        protected abstract void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //313:1
                __out.AppendLine(false); //313:141
            }
            var __loop8_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //315:16
                where part.GenerateCompleteMethod //315:44
                select new { part = part}
                ).ToList(); //315:10
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp135 = __loop8_results[__loop8_iteration];
                var part = __tmp135.part;
                if (!symbol.ExistingCompletionMemberNames.Contains(part.CompleteMethodName)) //316:14
                {
                    bool __tmp137_outputWritten = false;
                    string __tmp138_line = "        protected abstract "; //317:1
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
                    string __tmp140_line = " "; //317:59
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
                    string __tmp142_line = "("; //317:85
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
                    string __tmp144_line = ");"; //317:116
                    if (!string.IsNullOrEmpty(__tmp144_line))
                    {
                        __out.Write(__tmp144_line);
                        __tmp137_outputWritten = true;
                    }
                    if (__tmp137_outputWritten) __out.AppendLine(true);
                    if (__tmp137_outputWritten)
                    {
                        __out.AppendLine(false); //317:118
                    }
                }
            }
            if (!symbol.ExistingCompletionMemberNames.Contains("CompleteNonSymbolProperties")) //320:10
            {
                __out.Write("        protected abstract void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //321:1
                __out.AppendLine(false); //321:153
            }
            __out.Write("        #endregion"); //323:1
            __out.AppendLine(false); //323:19
            __out.AppendLine(true); //324:1
            __out.Write("    }"); //325:1
            __out.AppendLine(false); //325:6
            __out.Write("}"); //326:1
            __out.AppendLine(false); //326:2
            return __out.ToStringAndFree();
        }

        public string GenerateMetadataSymbol(SymbolGenerationInfo symbol) //329:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //330:1
            __out.AppendLine(false); //330:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //331:1
            __out.AppendLine(false); //331:29
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //332:1
            __out.AppendLine(false); //332:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //333:1
            __out.AppendLine(false); //333:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //334:1
            __out.AppendLine(false); //334:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //335:1
            __out.AppendLine(false); //335:44
            __out.Write("using System;"); //336:1
            __out.AppendLine(false); //336:14
            __out.Write("using System.Collections.Generic;"); //337:1
            __out.AppendLine(false); //337:34
            __out.Write("using System.Collections.Immutable;"); //338:1
            __out.AppendLine(false); //338:36
            __out.Write("using System.Diagnostics;"); //339:1
            __out.AppendLine(false); //339:26
            __out.Write("using System.Text;"); //340:1
            __out.AppendLine(false); //340:19
            __out.Write("using System.Threading;"); //341:1
            __out.AppendLine(false); //341:24
            __out.AppendLine(true); //342:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //343:1
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
            string __tmp5_line = ".Metadata"; //343:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //343:42
            }
            __out.Write("{"); //344:1
            __out.AppendLine(false); //344:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Metadata"; //345:1
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
            if (symbol.ExistingMetadataBaseType == null) //345:45
            {
                string __tmp11_line = " : "; //345:90
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
                string __tmp13_line = ".Completion.Completion"; //345:115
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
                __out.AppendLine(false); //345:158
            }
            __out.Write("	{"); //346:1
            __out.AppendLine(false); //346:3
            if (!symbol.ExistingMetadataMemberNames.Contains(".ctor")) //347:10
            {
                bool __tmp17_outputWritten = false;
                string __tmp18_line = "        public Metadata"; //348:1
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
                string __tmp20_line = "(Symbol container"; //348:37
                if (!string.IsNullOrEmpty(__tmp20_line))
                {
                    __out.Write(__tmp20_line);
                    __tmp17_outputWritten = true;
                }
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //348:55
                {
                    string __tmp22_line = ", object modelObject"; //348:112
                    if (!string.IsNullOrEmpty(__tmp22_line))
                    {
                        __out.Write(__tmp22_line);
                        __tmp17_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption == ParameterOption.Optional) //348:133
                    {
                        string __tmp24_line = " = null"; //348:190
                        if (!string.IsNullOrEmpty(__tmp24_line))
                        {
                            __out.Write(__tmp24_line);
                            __tmp17_outputWritten = true;
                        }
                    }
                }
                string __tmp27_line = ")"; //348:213
                if (!string.IsNullOrEmpty(__tmp27_line))
                {
                    __out.Write(__tmp27_line);
                    __tmp17_outputWritten = true;
                }
                if (__tmp17_outputWritten) __out.AppendLine(true);
                if (__tmp17_outputWritten)
                {
                    __out.AppendLine(false); //348:214
                }
                __out.Write("            : base(container, modelObject)"); //349:1
                __out.AppendLine(false); //349:43
                __out.Write("        {"); //350:1
                __out.AppendLine(false); //350:10
                __out.Write("        }"); //351:1
                __out.AppendLine(false); //351:10
            }
            if (!symbol.ExistingMetadataMemberNames.Contains("Locations")) //353:10
            {
                __out.AppendLine(true); //354:1
                __out.Write("        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;"); //355:1
                __out.AppendLine(false); //355:95
            }
            if (!symbol.ExistingMetadataMemberNames.Contains("DeclaringSyntaxReferences")) //357:10
            {
                __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;"); //358:1
                __out.AppendLine(false); //358:124
            }
            if (!symbol.ExistingMetadataMemberNames.Contains("CompleteSymbolProperty_Name")) //360:10
            {
                __out.AppendLine(true); //361:1
                __out.Write("        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //362:1
                __out.AppendLine(false); //362:126
                __out.Write("        {"); //363:1
                __out.AppendLine(false); //363:10
                __out.Write("            return ModelSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //364:1
                __out.AppendLine(false); //364:132
                __out.Write("        }"); //365:1
                __out.AppendLine(false); //365:10
            }
            if (!symbol.ExistingMetadataMemberNames.Contains("CompleteInitializingSymbol")) //367:10
            {
                __out.AppendLine(true); //368:1
                __out.Write("        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //369:1
                __out.AppendLine(false); //369:123
                __out.Write("        {"); //370:1
                __out.AppendLine(false); //370:10
                __out.Write("        }"); //371:1
                __out.AppendLine(false); //371:10
            }
            if (!symbol.ExistingMetadataMemberNames.Contains("CompleteCreatingChildSymbols")) //373:10
            {
                __out.AppendLine(true); //374:1
                __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //375:1
                __out.AppendLine(false); //375:143
                __out.Write("        {"); //376:1
                __out.AppendLine(false); //376:10
                __out.Write("            return ModelSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //377:1
                __out.AppendLine(false); //377:123
                __out.Write("        }"); //378:1
                __out.AppendLine(false); //378:10
            }
            if (!symbol.ExistingMetadataMemberNames.Contains("CompleteImports")) //380:10
            {
                __out.AppendLine(true); //381:1
                __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //382:1
                __out.AppendLine(false); //382:140
                __out.Write("        {"); //383:1
                __out.AppendLine(false); //383:10
                __out.Write("        }"); //384:1
                __out.AppendLine(false); //384:10
            }
            var __loop9_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //386:16
                where part.GenerateCompleteMethod //386:44
                select new { part = part}
                ).ToList(); //386:10
            for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
            {
                var __tmp28 = __loop9_results[__loop9_iteration];
                var part = __tmp28.part;
                if (!symbol.ExistingMetadataMemberNames.Contains(part.CompleteMethodName)) //387:14
                {
                    __out.AppendLine(true); //388:1
                    bool __tmp30_outputWritten = false;
                    string __tmp31_line = "        protected override "; //389:1
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
                    string __tmp33_line = " "; //389:59
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
                    string __tmp35_line = "("; //389:85
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
                    string __tmp37_line = ")"; //389:116
                    if (!string.IsNullOrEmpty(__tmp37_line))
                    {
                        __out.Write(__tmp37_line);
                        __tmp30_outputWritten = true;
                    }
                    if (__tmp30_outputWritten) __out.AppendLine(true);
                    if (__tmp30_outputWritten)
                    {
                        __out.AppendLine(false); //389:117
                    }
                    __out.Write("        {"); //390:1
                    __out.AppendLine(false); //390:10
                    if (part is SymbolPropertyGenerationInfo) //391:14
                    {
                        var prop = (SymbolPropertyGenerationInfo)part; //392:18
                        if (prop.IsCollection) //393:18
                        {
                            bool __tmp39_outputWritten = false;
                            string __tmp40_line = "            return ModelSymbolImplementation.AssignSymbolPropertyValues<"; //394:1
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
                            string __tmp42_line = ">(this, nameof("; //394:88
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
                            string __tmp44_line = "), diagnostics, cancellationToken);"; //394:114
                            if (!string.IsNullOrEmpty(__tmp44_line))
                            {
                                __out.Write(__tmp44_line);
                                __tmp39_outputWritten = true;
                            }
                            if (__tmp39_outputWritten) __out.AppendLine(true);
                            if (__tmp39_outputWritten)
                            {
                                __out.AppendLine(false); //394:149
                            }
                        }
                        else //395:18
                        {
                            bool __tmp46_outputWritten = false;
                            string __tmp47_line = "            return ModelSymbolImplementation.AssignSymbolPropertyValue<"; //396:1
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
                            string __tmp49_line = ">(this, nameof("; //396:83
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
                            string __tmp51_line = "), diagnostics, cancellationToken);"; //396:109
                            if (!string.IsNullOrEmpty(__tmp51_line))
                            {
                                __out.Write(__tmp51_line);
                                __tmp46_outputWritten = true;
                            }
                            if (__tmp46_outputWritten) __out.AppendLine(true);
                            if (__tmp46_outputWritten)
                            {
                                __out.AppendLine(false); //396:144
                            }
                        }
                    }
                    __out.Write("        }"); //399:1
                    __out.AppendLine(false); //399:10
                }
            }
            if (!symbol.ExistingMetadataMemberNames.Contains("CompleteNonSymbolProperties")) //402:10
            {
                __out.AppendLine(true); //403:1
                __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //404:1
                __out.AppendLine(false); //404:152
                __out.Write("        {"); //405:1
                __out.AppendLine(false); //405:10
                __out.Write("        }"); //406:1
                __out.AppendLine(false); //406:10
            }
            __out.Write("    }"); //408:1
            __out.AppendLine(false); //408:6
            __out.Write("}"); //409:1
            __out.AppendLine(false); //409:2
            return __out.ToStringAndFree();
        }

        public string GenerateSourceSymbol(SymbolGenerationInfo symbol) //412:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //413:1
            __out.AppendLine(false); //413:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //414:1
            __out.AppendLine(false); //414:29
            __out.Write("using MetaDslx.CodeAnalysis.Binding;"); //415:1
            __out.AppendLine(false); //415:37
            __out.Write("using MetaDslx.CodeAnalysis.Binding.Binders;"); //416:1
            __out.AppendLine(false); //416:45
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //417:1
            __out.AppendLine(false); //417:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //418:1
            __out.AppendLine(false); //418:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //419:1
            __out.AppendLine(false); //419:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //420:1
            __out.AppendLine(false); //420:44
            __out.Write("using System;"); //421:1
            __out.AppendLine(false); //421:14
            __out.Write("using System.Collections.Generic;"); //422:1
            __out.AppendLine(false); //422:34
            __out.Write("using System.Collections.Immutable;"); //423:1
            __out.AppendLine(false); //423:36
            __out.Write("using System.Diagnostics;"); //424:1
            __out.AppendLine(false); //424:26
            __out.Write("using System.Linq;"); //425:1
            __out.AppendLine(false); //425:19
            __out.Write("using System.Text;"); //426:1
            __out.AppendLine(false); //426:19
            __out.Write("using System.Threading;"); //427:1
            __out.AppendLine(false); //427:24
            __out.AppendLine(true); //428:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //429:1
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
            string __tmp5_line = ".Source"; //429:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //429:40
            }
            __out.Write("{"); //430:1
            __out.AppendLine(false); //430:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Source"; //431:1
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
            if (symbol.ExistingSourceBaseType == null) //431:43
            {
                string __tmp11_line = " : "; //431:86
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
                string __tmp13_line = ".Completion.Completion"; //431:111
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
                string __tmp15_line = ", MetaDslx.CodeAnalysis.Symbols.Source.ISourceSymbol"; //431:146
                if (!string.IsNullOrEmpty(__tmp15_line))
                {
                    __out.Write(__tmp15_line);
                    __tmp7_outputWritten = true;
                }
            }
            if (__tmp7_outputWritten) __out.AppendLine(true);
            if (__tmp7_outputWritten)
            {
                __out.AppendLine(false); //431:206
            }
            __out.Write("	{"); //432:1
            __out.AppendLine(false); //432:3
            __out.Write("        private readonly MergedDeclaration _declaration;"); //433:1
            __out.AppendLine(false); //433:57
            if (!symbol.ExistingSourceMemberNames.Contains(".ctor")) //434:10
            {
                __out.AppendLine(true); //435:1
                bool __tmp18_outputWritten = false;
                string __tmp19_line = "		public Source"; //436:1
                if (!string.IsNullOrEmpty(__tmp19_line))
                {
                    __out.Write(__tmp19_line);
                    __tmp18_outputWritten = true;
                }
                var __tmp20 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp20.Write(symbol.Name);
                var __tmp20Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp20.ToStringAndFree());
                bool __tmp20_last = __tmp20Reader.EndOfStream;
                while(!__tmp20_last)
                {
                    ReadOnlySpan<char> __tmp20_line = __tmp20Reader.ReadLine();
                    __tmp20_last = __tmp20Reader.EndOfStream;
                    if (!__tmp20_last || !__tmp20_line.IsEmpty)
                    {
                        __out.Write(__tmp20_line);
                        __tmp18_outputWritten = true;
                    }
                    if (!__tmp20_last) __out.AppendLine(true);
                }
                string __tmp21_line = "(Symbol containingSymbol, "; //436:29
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Write(__tmp21_line);
                    __tmp18_outputWritten = true;
                }
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //436:56
                {
                    string __tmp23_line = "object modelObject"; //436:113
                    if (!string.IsNullOrEmpty(__tmp23_line))
                    {
                        __out.Write(__tmp23_line);
                        __tmp18_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption == ParameterOption.Optional) //436:132
                    {
                        string __tmp25_line = " = null"; //436:189
                        if (!string.IsNullOrEmpty(__tmp25_line))
                        {
                            __out.Write(__tmp25_line);
                            __tmp18_outputWritten = true;
                        }
                    }
                    string __tmp27_line = ", "; //436:204
                    if (!string.IsNullOrEmpty(__tmp27_line))
                    {
                        __out.Write(__tmp27_line);
                        __tmp18_outputWritten = true;
                    }
                }
                string __tmp29_line = "MergedDeclaration declaration)"; //436:214
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Write(__tmp29_line);
                    __tmp18_outputWritten = true;
                }
                if (__tmp18_outputWritten) __out.AppendLine(true);
                if (__tmp18_outputWritten)
                {
                    __out.AppendLine(false); //436:244
                }
                __out.Write("            : base(containingSymbol, modelObject)"); //437:1
                __out.AppendLine(false); //437:50
                __out.Write("        {"); //438:1
                __out.AppendLine(false); //438:10
                __out.Write("            if (declaration is null) throw new ArgumentNullException(nameof(declaration));"); //439:1
                __out.AppendLine(false); //439:91
                __out.Write("            _declaration = declaration;"); //440:1
                __out.AppendLine(false); //440:40
                __out.Write("		}"); //441:1
                __out.AppendLine(false); //441:4
            }
            if (!symbol.ExistingSourceMemberNames.Contains("MergedDeclaration")) //443:10
            {
                __out.AppendLine(true); //444:1
                __out.Write("        public MergedDeclaration MergedDeclaration => _declaration;"); //445:1
                __out.AppendLine(false); //445:68
            }
            if (!symbol.ExistingSourceMemberNames.Contains("Locations")) //447:10
            {
                __out.AppendLine(true); //448:1
                __out.Write("        public override ImmutableArray<Location> Locations => _declaration.NameLocations;"); //449:1
                __out.AppendLine(false); //449:90
            }
            if (!symbol.ExistingSourceMemberNames.Contains("DeclaringSyntaxReferences")) //451:10
            {
                __out.AppendLine(true); //452:1
                __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration.SyntaxReferences;"); //453:1
                __out.AppendLine(false); //453:116
            }
            if (!symbol.ExistingSourceMemberNames.Contains("GetBinder")) //455:10
            {
                __out.AppendLine(true); //456:1
                __out.Write("        public BinderPosition<SymbolBinder> GetBinder(SyntaxReference reference)"); //457:1
                __out.AppendLine(false); //457:81
                __out.Write("        {"); //458:1
                __out.AppendLine(false); //458:10
                __out.Write("            Debug.Assert(this.DeclaringSyntaxReferences.Contains(reference));"); //459:1
                __out.AppendLine(false); //459:78
                __out.Write("            return FindBinders.FindSymbolBinder(this, reference);"); //460:1
                __out.AppendLine(false); //460:66
                __out.Write("        }"); //461:1
                __out.AppendLine(false); //461:10
            }
            if (!symbol.ExistingSourceMemberNames.Contains("GetChildSymbol")) //463:10
            {
                __out.AppendLine(true); //464:1
                __out.Write("        public Symbol GetChildSymbol(SyntaxReference syntax)"); //465:1
                __out.AppendLine(false); //465:61
                __out.Write("        {"); //466:1
                __out.AppendLine(false); //466:10
                __out.Write("            foreach (var child in this.ChildSymbols)"); //467:1
                __out.AppendLine(false); //467:53
                __out.Write("            {"); //468:1
                __out.AppendLine(false); //468:14
                __out.Write("                if (child.DeclaringSyntaxReferences.Any(sr => sr.GetLocation() == syntax.GetLocation()))"); //469:1
                __out.AppendLine(false); //469:105
                __out.Write("                {"); //470:1
                __out.AppendLine(false); //470:18
                __out.Write("                    return child;"); //471:1
                __out.AppendLine(false); //471:34
                __out.Write("                }"); //472:1
                __out.AppendLine(false); //472:18
                __out.Write("            }"); //473:1
                __out.AppendLine(false); //473:14
                __out.Write("            return null;"); //474:1
                __out.AppendLine(false); //474:25
                __out.Write("        }"); //475:1
                __out.AppendLine(false); //475:10
            }
            if (!symbol.ExistingSourceMemberNames.Contains("CompleteInitializingSymbol")) //477:10
            {
                __out.AppendLine(true); //478:1
                __out.Write("        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //479:1
                __out.AppendLine(false); //479:123
                __out.Write("        {"); //480:1
                __out.AppendLine(false); //480:10
                __out.Write("        }"); //481:1
                __out.AppendLine(false); //481:10
            }
            if (!symbol.ExistingSourceMemberNames.Contains("CompleteCreatingChildSymbols")) //483:10
            {
                __out.AppendLine(true); //484:1
                __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //485:1
                __out.AppendLine(false); //485:143
                __out.Write("        {"); //486:1
                __out.AppendLine(false); //486:10
                __out.Write("            return SourceSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //487:1
                __out.AppendLine(false); //487:124
                __out.Write("        }"); //488:1
                __out.AppendLine(false); //488:10
            }
            if (!symbol.ExistingSourceMemberNames.Contains("CompleteImports")) //490:10
            {
                __out.AppendLine(true); //491:1
                __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //492:1
                __out.AppendLine(false); //492:140
                __out.Write("        {"); //493:1
                __out.AppendLine(false); //493:10
                __out.Write("            SourceSymbolImplementation.CompleteImports(this, locationOpt, diagnostics, cancellationToken);"); //494:1
                __out.AppendLine(false); //494:107
                __out.Write("        }"); //495:1
                __out.AppendLine(false); //495:10
                __out.AppendLine(true); //496:1
            }
            if (!symbol.ExistingSourceMemberNames.Contains("CompleteSymbolProperty_Name")) //498:10
            {
                __out.Write("        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //499:1
                __out.AppendLine(false); //499:126
                __out.Write("        {"); //500:1
                __out.AppendLine(false); //500:10
                __out.Write("            return SourceSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //501:1
                __out.AppendLine(false); //501:133
                __out.Write("        }"); //502:1
                __out.AppendLine(false); //502:10
            }
            __out.AppendLine(true); //504:1
            var __loop10_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //505:16
                where part.GenerateCompleteMethod //505:44
                select new { part = part}
                ).ToList(); //505:10
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                var __tmp30 = __loop10_results[__loop10_iteration];
                var part = __tmp30.part;
                if (!symbol.ExistingSourceMemberNames.Contains(part.CompleteMethodName)) //506:14
                {
                    bool __tmp32_outputWritten = false;
                    string __tmp33_line = "        protected override "; //507:1
                    if (!string.IsNullOrEmpty(__tmp33_line))
                    {
                        __out.Write(__tmp33_line);
                        __tmp32_outputWritten = true;
                    }
                    var __tmp34 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp34.Write(part.CompleteMethodReturnType);
                    var __tmp34Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp34.ToStringAndFree());
                    bool __tmp34_last = __tmp34Reader.EndOfStream;
                    while(!__tmp34_last)
                    {
                        ReadOnlySpan<char> __tmp34_line = __tmp34Reader.ReadLine();
                        __tmp34_last = __tmp34Reader.EndOfStream;
                        if (!__tmp34_last || !__tmp34_line.IsEmpty)
                        {
                            __out.Write(__tmp34_line);
                            __tmp32_outputWritten = true;
                        }
                        if (!__tmp34_last) __out.AppendLine(true);
                    }
                    string __tmp35_line = " "; //507:59
                    if (!string.IsNullOrEmpty(__tmp35_line))
                    {
                        __out.Write(__tmp35_line);
                        __tmp32_outputWritten = true;
                    }
                    var __tmp36 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp36.Write(part.CompleteMethodName);
                    var __tmp36Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp36.ToStringAndFree());
                    bool __tmp36_last = __tmp36Reader.EndOfStream;
                    while(!__tmp36_last)
                    {
                        ReadOnlySpan<char> __tmp36_line = __tmp36Reader.ReadLine();
                        __tmp36_last = __tmp36Reader.EndOfStream;
                        if (!__tmp36_last || !__tmp36_line.IsEmpty)
                        {
                            __out.Write(__tmp36_line);
                            __tmp32_outputWritten = true;
                        }
                        if (!__tmp36_last) __out.AppendLine(true);
                    }
                    string __tmp37_line = "("; //507:85
                    if (!string.IsNullOrEmpty(__tmp37_line))
                    {
                        __out.Write(__tmp37_line);
                        __tmp32_outputWritten = true;
                    }
                    var __tmp38 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp38.Write(part.CompleteMethodParamList);
                    var __tmp38Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp38.ToStringAndFree());
                    bool __tmp38_last = __tmp38Reader.EndOfStream;
                    while(!__tmp38_last)
                    {
                        ReadOnlySpan<char> __tmp38_line = __tmp38Reader.ReadLine();
                        __tmp38_last = __tmp38Reader.EndOfStream;
                        if (!__tmp38_last || !__tmp38_line.IsEmpty)
                        {
                            __out.Write(__tmp38_line);
                            __tmp32_outputWritten = true;
                        }
                        if (!__tmp38_last) __out.AppendLine(true);
                    }
                    string __tmp39_line = ")"; //507:116
                    if (!string.IsNullOrEmpty(__tmp39_line))
                    {
                        __out.Write(__tmp39_line);
                        __tmp32_outputWritten = true;
                    }
                    if (__tmp32_outputWritten) __out.AppendLine(true);
                    if (__tmp32_outputWritten)
                    {
                        __out.AppendLine(false); //507:117
                    }
                    __out.Write("        {"); //508:1
                    __out.AppendLine(false); //508:10
                    if (part is SymbolPropertyGenerationInfo) //509:14
                    {
                        var prop = (SymbolPropertyGenerationInfo)part; //510:18
                        if (prop.IsCollection) //511:18
                        {
                            bool __tmp41_outputWritten = false;
                            string __tmp42_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValues<"; //512:1
                            if (!string.IsNullOrEmpty(__tmp42_line))
                            {
                                __out.Write(__tmp42_line);
                                __tmp41_outputWritten = true;
                            }
                            var __tmp43 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp43.Write(prop.ItemType);
                            var __tmp43Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp43.ToStringAndFree());
                            bool __tmp43_last = __tmp43Reader.EndOfStream;
                            while(!__tmp43_last)
                            {
                                ReadOnlySpan<char> __tmp43_line = __tmp43Reader.ReadLine();
                                __tmp43_last = __tmp43Reader.EndOfStream;
                                if (!__tmp43_last || !__tmp43_line.IsEmpty)
                                {
                                    __out.Write(__tmp43_line);
                                    __tmp41_outputWritten = true;
                                }
                                if (!__tmp43_last) __out.AppendLine(true);
                            }
                            string __tmp44_line = ">(this, nameof("; //512:89
                            if (!string.IsNullOrEmpty(__tmp44_line))
                            {
                                __out.Write(__tmp44_line);
                                __tmp41_outputWritten = true;
                            }
                            var __tmp45 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp45.Write(prop.Name);
                            var __tmp45Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp45.ToStringAndFree());
                            bool __tmp45_last = __tmp45Reader.EndOfStream;
                            while(!__tmp45_last)
                            {
                                ReadOnlySpan<char> __tmp45_line = __tmp45Reader.ReadLine();
                                __tmp45_last = __tmp45Reader.EndOfStream;
                                if (!__tmp45_last || !__tmp45_line.IsEmpty)
                                {
                                    __out.Write(__tmp45_line);
                                    __tmp41_outputWritten = true;
                                }
                                if (!__tmp45_last) __out.AppendLine(true);
                            }
                            string __tmp46_line = "), diagnostics, cancellationToken);"; //512:115
                            if (!string.IsNullOrEmpty(__tmp46_line))
                            {
                                __out.Write(__tmp46_line);
                                __tmp41_outputWritten = true;
                            }
                            if (__tmp41_outputWritten) __out.AppendLine(true);
                            if (__tmp41_outputWritten)
                            {
                                __out.AppendLine(false); //512:150
                            }
                        }
                        else //513:18
                        {
                            bool __tmp48_outputWritten = false;
                            string __tmp49_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValue<"; //514:1
                            if (!string.IsNullOrEmpty(__tmp49_line))
                            {
                                __out.Write(__tmp49_line);
                                __tmp48_outputWritten = true;
                            }
                            var __tmp50 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp50.Write(prop.Type);
                            var __tmp50Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp50.ToStringAndFree());
                            bool __tmp50_last = __tmp50Reader.EndOfStream;
                            while(!__tmp50_last)
                            {
                                ReadOnlySpan<char> __tmp50_line = __tmp50Reader.ReadLine();
                                __tmp50_last = __tmp50Reader.EndOfStream;
                                if (!__tmp50_last || !__tmp50_line.IsEmpty)
                                {
                                    __out.Write(__tmp50_line);
                                    __tmp48_outputWritten = true;
                                }
                                if (!__tmp50_last) __out.AppendLine(true);
                            }
                            string __tmp51_line = ">(this, nameof("; //514:84
                            if (!string.IsNullOrEmpty(__tmp51_line))
                            {
                                __out.Write(__tmp51_line);
                                __tmp48_outputWritten = true;
                            }
                            var __tmp52 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp52.Write(prop.Name);
                            var __tmp52Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp52.ToStringAndFree());
                            bool __tmp52_last = __tmp52Reader.EndOfStream;
                            while(!__tmp52_last)
                            {
                                ReadOnlySpan<char> __tmp52_line = __tmp52Reader.ReadLine();
                                __tmp52_last = __tmp52Reader.EndOfStream;
                                if (!__tmp52_last || !__tmp52_line.IsEmpty)
                                {
                                    __out.Write(__tmp52_line);
                                    __tmp48_outputWritten = true;
                                }
                                if (!__tmp52_last) __out.AppendLine(true);
                            }
                            string __tmp53_line = "), diagnostics, cancellationToken);"; //514:110
                            if (!string.IsNullOrEmpty(__tmp53_line))
                            {
                                __out.Write(__tmp53_line);
                                __tmp48_outputWritten = true;
                            }
                            if (__tmp48_outputWritten) __out.AppendLine(true);
                            if (__tmp48_outputWritten)
                            {
                                __out.AppendLine(false); //514:145
                            }
                        }
                    }
                    __out.Write("        }"); //517:1
                    __out.AppendLine(false); //517:10
                }
            }
            if (!symbol.ExistingSourceMemberNames.Contains("CompleteNonSymbolProperties")) //520:10
            {
                __out.AppendLine(true); //521:1
                __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //522:1
                __out.AppendLine(false); //522:152
                __out.Write("        {"); //523:1
                __out.AppendLine(false); //523:10
                __out.Write("            SourceSymbolImplementation.AssignNonSymbolProperties(this, diagnostics, cancellationToken);"); //524:1
                __out.AppendLine(false); //524:104
                __out.Write("        }"); //525:1
                __out.AppendLine(false); //525:10
            }
            __out.AppendLine(true); //527:1
            __out.Write("	}"); //528:1
            __out.AppendLine(false); //528:3
            __out.Write("}"); //529:1
            __out.AppendLine(false); //529:2
            return __out.ToStringAndFree();
        }

        public string GenerateVisitor(string namespaceName, IEnumerable<SymbolGenerationInfo> symbols) //532:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //533:1
            __out.AppendLine(false); //533:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //534:1
            __out.AppendLine(false); //534:29
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //535:1
            __out.AppendLine(false); //535:37
            __out.Write("using System;"); //536:1
            __out.AppendLine(false); //536:14
            __out.Write("using System.Collections.Generic;"); //537:1
            __out.AppendLine(false); //537:34
            __out.Write("using System.Collections.Immutable;"); //538:1
            __out.AppendLine(false); //538:36
            __out.Write("using System.Diagnostics;"); //539:1
            __out.AppendLine(false); //539:26
            __out.Write("using System.Text;"); //540:1
            __out.AppendLine(false); //540:19
            __out.Write("using System.Threading;"); //541:1
            __out.AppendLine(false); //541:24
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //543:1
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
                __out.AppendLine(false); //543:26
            }
            __out.Write("{"); //544:1
            __out.AppendLine(false); //544:2
            __out.Write("	public interface ISymbolVisitor"); //545:1
            __out.AppendLine(false); //545:33
            __out.Write("	{"); //546:1
            __out.AppendLine(false); //546:3
            var __loop11_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //547:16
                select new { symbol = symbol}
                ).ToList(); //547:10
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp5 = __loop11_results[__loop11_iteration];
                var symbol = __tmp5.symbol;
                bool __tmp7_outputWritten = false;
                string __tmp8_line = "        void Visit("; //548:1
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
                string __tmp10_line = " symbol);"; //548:33
                if (!string.IsNullOrEmpty(__tmp10_line))
                {
                    __out.Write(__tmp10_line);
                    __tmp7_outputWritten = true;
                }
                if (__tmp7_outputWritten) __out.AppendLine(true);
                if (__tmp7_outputWritten)
                {
                    __out.AppendLine(false); //548:42
                }
            }
            __out.Write("	}"); //550:1
            __out.AppendLine(false); //550:3
            __out.AppendLine(true); //551:1
            __out.Write("	public interface ISymbolVisitor<TResult>"); //552:1
            __out.AppendLine(false); //552:42
            __out.Write("	{"); //553:1
            __out.AppendLine(false); //553:3
            var __loop12_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //554:16
                select new { symbol = symbol}
                ).ToList(); //554:10
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp11 = __loop12_results[__loop12_iteration];
                var symbol = __tmp11.symbol;
                bool __tmp13_outputWritten = false;
                string __tmp14_line = "        TResult Visit("; //555:1
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
                string __tmp16_line = " symbol);"; //555:36
                if (!string.IsNullOrEmpty(__tmp16_line))
                {
                    __out.Write(__tmp16_line);
                    __tmp13_outputWritten = true;
                }
                if (__tmp13_outputWritten) __out.AppendLine(true);
                if (__tmp13_outputWritten)
                {
                    __out.AppendLine(false); //555:45
                }
            }
            __out.Write("	}"); //557:1
            __out.AppendLine(false); //557:3
            __out.AppendLine(true); //558:1
            __out.Write("	public interface ISymbolVisitor<TArgument, TResult>"); //559:1
            __out.AppendLine(false); //559:53
            __out.Write("	{"); //560:1
            __out.AppendLine(false); //560:3
            var __loop13_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //561:16
                select new { symbol = symbol}
                ).ToList(); //561:10
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp17 = __loop13_results[__loop13_iteration];
                var symbol = __tmp17.symbol;
                bool __tmp19_outputWritten = false;
                string __tmp20_line = "        TResult Visit("; //562:1
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
                string __tmp22_line = " symbol, TArgument argument);"; //562:36
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Write(__tmp22_line);
                    __tmp19_outputWritten = true;
                }
                if (__tmp19_outputWritten) __out.AppendLine(true);
                if (__tmp19_outputWritten)
                {
                    __out.AppendLine(false); //562:65
                }
            }
            __out.Write("	}"); //564:1
            __out.AppendLine(false); //564:3
            __out.Write("}"); //565:1
            __out.AppendLine(false); //565:2
            return __out.ToStringAndFree();
        }

    }
}

