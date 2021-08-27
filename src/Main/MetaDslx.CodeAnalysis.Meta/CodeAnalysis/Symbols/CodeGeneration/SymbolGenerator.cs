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
            __out.Write("using MetaDslx.CodeAnalysis.Binding;"); //7:1
            __out.AppendLine(false); //7:37
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //8:1
            __out.AppendLine(false); //8:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //9:1
            __out.AppendLine(false); //9:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //10:1
            __out.AppendLine(false); //10:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //11:1
            __out.AppendLine(false); //11:44
            __out.Write("using System;"); //12:1
            __out.AppendLine(false); //12:14
            __out.Write("using System.Collections.Generic;"); //13:1
            __out.AppendLine(false); //13:34
            __out.Write("using System.Collections.Immutable;"); //14:1
            __out.AppendLine(false); //14:36
            __out.Write("using System.Diagnostics;"); //15:1
            __out.AppendLine(false); //15:26
            __out.Write("using System.Linq;"); //16:1
            __out.AppendLine(false); //16:19
            __out.Write("using System.Text;"); //17:1
            __out.AppendLine(false); //17:19
            __out.Write("using System.Threading;"); //18:1
            __out.AppendLine(false); //18:24
            __out.Write("using Roslyn.Utilities;"); //19:1
            __out.AppendLine(false); //19:24
            __out.AppendLine(true); //20:1
            __out.Write("#nullable enable"); //21:1
            __out.AppendLine(false); //21:17
            __out.AppendLine(true); //22:1
            bool __tmp2_outputWritten = false;
            var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp3.Write(GeneratePartialSymbol(symbol));
            var __tmp3Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp3.ToStringAndFree());
            bool __tmp3_last = __tmp3Reader.EndOfStream;
            while(!__tmp3_last)
            {
                ReadOnlySpan<char> __tmp3_line = __tmp3Reader.ReadLine();
                __tmp3_last = __tmp3Reader.EndOfStream;
                if (!__tmp3_last || !__tmp3_line.IsEmpty)
                {
                    __out.Write(__tmp3_line);
                    __tmp2_outputWritten = true;
                }
                if (!__tmp3_last || __tmp2_outputWritten) __out.AppendLine(true);
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //23:32
            }
            if (symbol.SymbolParts != SymbolParts.None) //24:2
            {
                __out.AppendLine(true); //25:1
                bool __tmp5_outputWritten = false;
                var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp6.Write(GenerateCompletionSymbol(symbol));
                var __tmp6Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp6.ToStringAndFree());
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(!__tmp6_last)
                {
                    ReadOnlySpan<char> __tmp6_line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if (!__tmp6_last || !__tmp6_line.IsEmpty)
                    {
                        __out.Write(__tmp6_line);
                        __tmp5_outputWritten = true;
                    }
                    if (!__tmp6_last || __tmp5_outputWritten) __out.AppendLine(true);
                }
                if (__tmp5_outputWritten)
                {
                    __out.AppendLine(false); //26:35
                }
                if (symbol.SymbolParts.HasFlag(SymbolParts.Metadata)) //27:2
                {
                    __out.AppendLine(true); //28:1
                    bool __tmp8_outputWritten = false;
                    var __tmp9 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp9.Write(GenerateMetadataSymbol(symbol));
                    var __tmp9Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp9.ToStringAndFree());
                    bool __tmp9_last = __tmp9Reader.EndOfStream;
                    while(!__tmp9_last)
                    {
                        ReadOnlySpan<char> __tmp9_line = __tmp9Reader.ReadLine();
                        __tmp9_last = __tmp9Reader.EndOfStream;
                        if (!__tmp9_last || !__tmp9_line.IsEmpty)
                        {
                            __out.Write(__tmp9_line);
                            __tmp8_outputWritten = true;
                        }
                        if (!__tmp9_last || __tmp8_outputWritten) __out.AppendLine(true);
                    }
                    if (__tmp8_outputWritten)
                    {
                        __out.AppendLine(false); //29:33
                    }
                }
                if (symbol.SymbolParts.HasFlag(SymbolParts.Source)) //31:2
                {
                    __out.AppendLine(true); //32:1
                    bool __tmp11_outputWritten = false;
                    var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp12.Write(GenerateSourceSymbol(symbol));
                    var __tmp12Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp12.ToStringAndFree());
                    bool __tmp12_last = __tmp12Reader.EndOfStream;
                    while(!__tmp12_last)
                    {
                        ReadOnlySpan<char> __tmp12_line = __tmp12Reader.ReadLine();
                        __tmp12_last = __tmp12Reader.EndOfStream;
                        if (!__tmp12_last || !__tmp12_line.IsEmpty)
                        {
                            __out.Write(__tmp12_line);
                            __tmp11_outputWritten = true;
                        }
                        if (!__tmp12_last || __tmp11_outputWritten) __out.AppendLine(true);
                    }
                    if (__tmp11_outputWritten)
                    {
                        __out.AppendLine(false); //33:31
                    }
                }
            }
            return __out.ToStringAndFree();
        }

        public string GeneratePartialSymbol(SymbolGenerationInfo symbol) //38:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //39:1
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
                __out.AppendLine(false); //39:33
            }
            __out.Write("{"); //40:1
            __out.AppendLine(false); //40:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	public "; //41:1
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp6_outputWritten = true;
            }
            if (!symbol.ExistingTypeInfo.IsSealed) //41:10
            {
                string __tmp9_line = "abstract "; //41:49
                if (!string.IsNullOrEmpty(__tmp9_line))
                {
                    __out.Write(__tmp9_line);
                    __tmp6_outputWritten = true;
                }
            }
            string __tmp11_line = "partial class "; //41:66
            if (!string.IsNullOrEmpty(__tmp11_line))
            {
                __out.Write(__tmp11_line);
                __tmp6_outputWritten = true;
            }
            var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp12.Write(symbol.Name);
            var __tmp12Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp12.ToStringAndFree());
            bool __tmp12_last = __tmp12Reader.EndOfStream;
            while(!__tmp12_last)
            {
                ReadOnlySpan<char> __tmp12_line = __tmp12Reader.ReadLine();
                __tmp12_last = __tmp12Reader.EndOfStream;
                if (!__tmp12_last || !__tmp12_line.IsEmpty)
                {
                    __out.Write(__tmp12_line);
                    __tmp6_outputWritten = true;
                }
                if (!__tmp12_last || __tmp6_outputWritten) __out.AppendLine(true);
            }
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //41:93
            }
            __out.Write("	{"); //42:1
            __out.AppendLine(false); //42:3
            __out.Write("        public static"); //43:1
            if (!symbol.IsSymbolClass) //43:23
            {
                __out.Write(" new"); //43:50
            }
            __out.Write(" class CompletionParts"); //43:62
            __out.AppendLine(false); //43:84
            __out.Write("        {"); //44:1
            __out.AppendLine(false); //44:10
            var __loop1_results = 
                (from partName in __Enumerate((symbol.GetCompletionPartNames()).GetEnumerator()) //45:20
                select new { partName = partName}
                ).ToList(); //45:14
            for (int __loop1_iteration = 0; __loop1_iteration < __loop1_results.Count; ++__loop1_iteration)
            {
                var __tmp13 = __loop1_results[__loop1_iteration];
                var partName = __tmp13.partName;
                bool __tmp15_outputWritten = false;
                string __tmp16_line = "            public static readonly CompletionPart "; //46:1
                if (!string.IsNullOrEmpty(__tmp16_line))
                {
                    __out.Write(__tmp16_line);
                    __tmp15_outputWritten = true;
                }
                var __tmp17 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp17.Write(partName);
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
                string __tmp18_line = " = "; //46:61
                if (!string.IsNullOrEmpty(__tmp18_line))
                {
                    __out.Write(__tmp18_line);
                    __tmp15_outputWritten = true;
                }
                var __tmp19 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp19.Write(symbol.GetCompletionPartValue(partName));
                var __tmp19Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp19.ToStringAndFree());
                bool __tmp19_last = __tmp19Reader.EndOfStream;
                while(!__tmp19_last)
                {
                    ReadOnlySpan<char> __tmp19_line = __tmp19Reader.ReadLine();
                    __tmp19_last = __tmp19Reader.EndOfStream;
                    if (!__tmp19_last || !__tmp19_line.IsEmpty)
                    {
                        __out.Write(__tmp19_line);
                        __tmp15_outputWritten = true;
                    }
                    if (!__tmp19_last) __out.AppendLine(true);
                }
                string __tmp20_line = ";"; //46:105
                if (!string.IsNullOrEmpty(__tmp20_line))
                {
                    __out.Write(__tmp20_line);
                    __tmp15_outputWritten = true;
                }
                if (__tmp15_outputWritten) __out.AppendLine(true);
                if (__tmp15_outputWritten)
                {
                    __out.AppendLine(false); //46:106
                }
            }
            bool __tmp22_outputWritten = false;
            string __tmp23_line = "            public static readonly ImmutableHashSet<CompletionPart> AllWithLocation = CompletionPart.Combine("; //48:1
            if (!string.IsNullOrEmpty(__tmp23_line))
            {
                __out.Write(__tmp23_line);
                __tmp22_outputWritten = true;
            }
            var __loop2_results = 
                (from partName in __Enumerate((symbol.GetOrderedCompletionParts(true)).GetEnumerator()) //48:117
                select new { partName = partName}
                ).ToList(); //48:111
            for (int __loop2_iteration = 0; __loop2_iteration < __loop2_results.Count; ++__loop2_iteration)
            {
                string comma; //48:164
                if (__loop2_iteration+1 < __loop2_results.Count) comma = ", ";
                else comma = string.Empty;
                var __tmp25 = __loop2_results[__loop2_iteration];
                var partName = __tmp25.partName;
                var __tmp26 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp26.Write(partName);
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
                var __tmp27 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp27.Write(comma);
                var __tmp27Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp27.ToStringAndFree());
                bool __tmp27_last = __tmp27Reader.EndOfStream;
                while(!__tmp27_last)
                {
                    ReadOnlySpan<char> __tmp27_line = __tmp27Reader.ReadLine();
                    __tmp27_last = __tmp27Reader.EndOfStream;
                    if (!__tmp27_last || !__tmp27_line.IsEmpty)
                    {
                        __out.Write(__tmp27_line);
                        __tmp22_outputWritten = true;
                    }
                    if (!__tmp27_last) __out.AppendLine(true);
                }
            }
            string __tmp29_line = ");"; //48:217
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Write(__tmp29_line);
                __tmp22_outputWritten = true;
            }
            if (__tmp22_outputWritten) __out.AppendLine(true);
            if (__tmp22_outputWritten)
            {
                __out.AppendLine(false); //48:219
            }
            bool __tmp31_outputWritten = false;
            string __tmp32_line = "            public static readonly ImmutableHashSet<CompletionPart> All = CompletionPart.Combine("; //49:1
            if (!string.IsNullOrEmpty(__tmp32_line))
            {
                __out.Write(__tmp32_line);
                __tmp31_outputWritten = true;
            }
            var __loop3_results = 
                (from partName in __Enumerate((symbol.GetOrderedCompletionParts(false)).GetEnumerator()) //49:105
                select new { partName = partName}
                ).ToList(); //49:99
            for (int __loop3_iteration = 0; __loop3_iteration < __loop3_results.Count; ++__loop3_iteration)
            {
                string comma; //49:153
                if (__loop3_iteration+1 < __loop3_results.Count) comma = ", ";
                else comma = string.Empty;
                var __tmp34 = __loop3_results[__loop3_iteration];
                var partName = __tmp34.partName;
                var __tmp35 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp35.Write(partName);
                var __tmp35Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp35.ToStringAndFree());
                bool __tmp35_last = __tmp35Reader.EndOfStream;
                while(!__tmp35_last)
                {
                    ReadOnlySpan<char> __tmp35_line = __tmp35Reader.ReadLine();
                    __tmp35_last = __tmp35Reader.EndOfStream;
                    if (!__tmp35_last || !__tmp35_line.IsEmpty)
                    {
                        __out.Write(__tmp35_line);
                        __tmp31_outputWritten = true;
                    }
                    if (!__tmp35_last) __out.AppendLine(true);
                }
                var __tmp36 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp36.Write(comma);
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
            }
            string __tmp38_line = ");"; //49:206
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Write(__tmp38_line);
                __tmp31_outputWritten = true;
            }
            if (__tmp31_outputWritten) __out.AppendLine(true);
            if (__tmp31_outputWritten)
            {
                __out.AppendLine(false); //49:208
            }
            bool __tmp40_outputWritten = false;
            string __tmp41_line = "            public static readonly CompletionGraph CompletionGraph = CompletionGraph.FromCompletionParts("; //50:1
            if (!string.IsNullOrEmpty(__tmp41_line))
            {
                __out.Write(__tmp41_line);
                __tmp40_outputWritten = true;
            }
            var __loop4_results = 
                (from partName in __Enumerate((symbol.GetOrderedCompletionParts(false)).GetEnumerator()) //50:113
                select new { partName = partName}
                ).ToList(); //50:107
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                string comma; //50:161
                if (__loop4_iteration+1 < __loop4_results.Count) comma = ", ";
                else comma = string.Empty;
                var __tmp43 = __loop4_results[__loop4_iteration];
                var partName = __tmp43.partName;
                var __tmp44 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp44.Write(partName);
                var __tmp44Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp44.ToStringAndFree());
                bool __tmp44_last = __tmp44Reader.EndOfStream;
                while(!__tmp44_last)
                {
                    ReadOnlySpan<char> __tmp44_line = __tmp44Reader.ReadLine();
                    __tmp44_last = __tmp44Reader.EndOfStream;
                    if (!__tmp44_last || !__tmp44_line.IsEmpty)
                    {
                        __out.Write(__tmp44_line);
                        __tmp40_outputWritten = true;
                    }
                    if (!__tmp44_last) __out.AppendLine(true);
                }
                var __tmp45 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp45.Write(comma);
                var __tmp45Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp45.ToStringAndFree());
                bool __tmp45_last = __tmp45Reader.EndOfStream;
                while(!__tmp45_last)
                {
                    ReadOnlySpan<char> __tmp45_line = __tmp45Reader.ReadLine();
                    __tmp45_last = __tmp45Reader.EndOfStream;
                    if (!__tmp45_last || !__tmp45_line.IsEmpty)
                    {
                        __out.Write(__tmp45_line);
                        __tmp40_outputWritten = true;
                    }
                    if (!__tmp45_last) __out.AppendLine(true);
                }
            }
            string __tmp47_line = ");"; //50:214
            if (!string.IsNullOrEmpty(__tmp47_line))
            {
                __out.Write(__tmp47_line);
                __tmp40_outputWritten = true;
            }
            if (__tmp40_outputWritten) __out.AppendLine(true);
            if (__tmp40_outputWritten)
            {
                __out.AppendLine(false); //50:216
            }
            __out.Write("        }"); //51:1
            __out.AppendLine(false); //51:10
            if (!symbol.IsAbstract) //52:10
            {
                __out.AppendLine(true); //53:1
                __out.Write("        public "); //54:1
                if (symbol.IsSymbolClass) //54:17
                {
                    __out.Write("virtual"); //54:43
                }
                else //54:51
                {
                    __out.Write("override"); //54:56
                }
                __out.Write(" void Accept(MetaDslx.CodeAnalysis.Symbols.SymbolVisitor visitor)"); //54:72
                __out.AppendLine(false); //54:137
                __out.Write("        {"); //55:1
                __out.AppendLine(false); //55:10
                __out.Write("            if (visitor is ISymbolVisitor isv) isv.Visit(this);"); //56:1
                __out.AppendLine(false); //56:64
                __out.Write("        }"); //57:1
                __out.AppendLine(false); //57:10
                __out.AppendLine(true); //58:1
                __out.Write("        public "); //59:1
                if (symbol.IsSymbolClass) //59:17
                {
                    __out.Write("virtual"); //59:43
                }
                else //59:51
                {
                    __out.Write("override"); //59:56
                }
                __out.Write(" TResult Accept<TResult>(MetaDslx.CodeAnalysis.Symbols.SymbolVisitor<TResult> visitor)"); //59:72
                __out.AppendLine(false); //59:158
                __out.Write("        {"); //60:1
                __out.AppendLine(false); //60:10
                __out.Write("            if (visitor is ISymbolVisitor<TResult> isv) return isv.Visit(this);"); //61:1
                __out.AppendLine(false); //61:80
                __out.Write("            else return default(TResult);"); //62:1
                __out.AppendLine(false); //62:42
                __out.Write("        }"); //63:1
                __out.AppendLine(false); //63:10
                __out.AppendLine(true); //64:1
                __out.Write("        public "); //65:1
                if (symbol.IsSymbolClass) //65:17
                {
                    __out.Write("virtual"); //65:43
                }
                else //65:51
                {
                    __out.Write("override"); //65:56
                }
                __out.Write(" TResult Accept<TArgument, TResult>(MetaDslx.CodeAnalysis.Symbols.SymbolVisitor<TArgument, TResult> visitor, TArgument argument)"); //65:72
                __out.AppendLine(false); //65:200
                __out.Write("        {"); //66:1
                __out.AppendLine(false); //66:10
                __out.Write("            if (visitor is ISymbolVisitor<TArgument, TResult> isv) return isv.Visit(this, argument);"); //67:1
                __out.AppendLine(false); //67:101
                __out.Write("            else return default(TResult);"); //68:1
                __out.AppendLine(false); //68:42
                __out.Write("        }"); //69:1
                __out.AppendLine(false); //69:10
            }
            __out.Write("	}"); //71:1
            __out.AppendLine(false); //71:3
            __out.Write("}"); //72:1
            __out.AppendLine(false); //72:2
            return __out.ToStringAndFree();
        }

        public string GenerateCompletionSymbol(SymbolGenerationInfo symbol) //75:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
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
            string __tmp5_line = ".Completion"; //76:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //76:44
            }
            __out.Write("{"); //77:1
            __out.AppendLine(false); //77:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public abstract partial class Completion"; //78:1
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
            if (symbol.ExistingCompletionTypeInfo.BaseType == null) //78:56
            {
                string __tmp11_line = " : "; //78:112
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
                string __tmp13_line = "."; //78:137
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
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //78:152
                {
                    string __tmp16_line = ", MetaDslx.CodeAnalysis.Symbols.Metadata.IModelSymbol"; //78:209
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
                __out.AppendLine(false); //78:278
            }
            __out.Write("	{"); //79:1
            __out.AppendLine(false); //79:3
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //80:10
            {
                __out.Write("        private readonly Symbol _container;"); //81:1
                __out.AppendLine(false); //81:44
            }
            if (symbol.ModelObjectOption != ParameterOption.Disabled) //83:10
            {
                __out.Write("        private readonly object? _modelObject;"); //84:1
                __out.AppendLine(false); //84:47
            }
            __out.Write("        private readonly CompletionState _state;"); //86:1
            __out.AppendLine(false); //86:49
            __out.Write("        private ImmutableArray<Symbol> _childSymbols;"); //87:1
            __out.AppendLine(false); //87:54
            __out.Write("        private string _name;"); //88:1
            __out.AppendLine(false); //88:30
            __out.Write("        private string _metadataName;"); //89:1
            __out.AppendLine(false); //89:38
            var __loop5_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //90:16
                select new { prop = prop}
                ).ToList(); //90:10
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                var __tmp19 = __loop5_results[__loop5_iteration];
                var prop = __tmp19.prop;
                bool __tmp21_outputWritten = false;
                string __tmp22_line = "        private "; //91:1
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
                string __tmp24_line = " "; //91:28
                if (!string.IsNullOrEmpty(__tmp24_line))
                {
                    __out.Write(__tmp24_line);
                    __tmp21_outputWritten = true;
                }
                var __tmp25 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp25.Write(prop.FieldName);
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
                string __tmp26_line = ";"; //91:45
                if (!string.IsNullOrEmpty(__tmp26_line))
                {
                    __out.Write(__tmp26_line);
                    __tmp21_outputWritten = true;
                }
                if (__tmp21_outputWritten) __out.AppendLine(true);
                if (__tmp21_outputWritten)
                {
                    __out.AppendLine(false); //91:46
                }
            }
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //93:10
            {
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains(".ctor")) //94:10
                {
                    __out.AppendLine(true); //95:1
                    bool __tmp28_outputWritten = false;
                    string __tmp29_line = "        public Completion"; //96:1
                    if (!string.IsNullOrEmpty(__tmp29_line))
                    {
                        __out.Write(__tmp29_line);
                        __tmp28_outputWritten = true;
                    }
                    var __tmp30 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp30.Write(symbol.Name);
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
                    string __tmp31_line = "(Symbol container"; //96:39
                    if (!string.IsNullOrEmpty(__tmp31_line))
                    {
                        __out.Write(__tmp31_line);
                        __tmp28_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //96:57
                    {
                        string __tmp33_line = ", object? modelObject"; //96:114
                        if (!string.IsNullOrEmpty(__tmp33_line))
                        {
                            __out.Write(__tmp33_line);
                            __tmp28_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //96:136
                        {
                            string __tmp35_line = " = null"; //96:193
                            if (!string.IsNullOrEmpty(__tmp35_line))
                            {
                                __out.Write(__tmp35_line);
                                __tmp28_outputWritten = true;
                            }
                        }
                    }
                    string __tmp38_line = ", bool isError = false)"; //96:216
                    if (!string.IsNullOrEmpty(__tmp38_line))
                    {
                        __out.Write(__tmp38_line);
                        __tmp28_outputWritten = true;
                    }
                    if (__tmp28_outputWritten) __out.AppendLine(true);
                    if (__tmp28_outputWritten)
                    {
                        __out.AppendLine(false); //96:239
                    }
                    __out.Write("        {"); //97:1
                    __out.AppendLine(false); //97:10
                    __out.Write("            _container = container;"); //98:1
                    __out.AppendLine(false); //98:36
                    if (symbol.ModelObjectOption == ParameterOption.Required) //99:14
                    {
                        __out.Write("            if (!isError && modelObject is null) throw new ArgumentNullException(nameof(modelObject));"); //100:1
                        __out.AppendLine(false); //100:103
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
                }
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains("Language")) //108:10
                {
                    __out.AppendLine(true); //109:1
                    __out.Write("        public override Language Language => ContainingModule?.Language ?? Language.None;"); //110:1
                    __out.AppendLine(false); //110:90
                }
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains("SymbolFactory")) //112:10
                {
                    __out.AppendLine(true); //113:1
                    __out.Write("        public SymbolFactory? SymbolFactory => ContainingModule?.SymbolFactory;"); //114:1
                    __out.AppendLine(false); //114:80
                }
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //116:10
                {
                    if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ModelObject")) //117:14
                    {
                        __out.AppendLine(true); //118:1
                        __out.Write("        public object ModelObject => _modelObject;"); //119:1
                        __out.AppendLine(false); //119:51
                    }
                    if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ModelObjectType")) //121:14
                    {
                        __out.AppendLine(true); //122:1
                        __out.Write("        public Type ModelObjectType => _modelObject is not null ? Language.SymbolFacts.GetModelObjectType(_modelObject) : null;"); //123:1
                        __out.AppendLine(false); //123:128
                    }
                }
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ContainingSymbol")) //126:10
                {
                    __out.AppendLine(true); //127:1
                    __out.Write("        public override Symbol ContainingSymbol => _container;"); //128:1
                    __out.AppendLine(false); //128:63
                }
            }
            __out.AppendLine(true); //131:1
            __out.Write("        protected abstract ISymbolImplementation SymbolImplementation { get; }"); //132:1
            __out.AppendLine(false); //132:79
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ChildSymbols")) //133:10
            {
                __out.AppendLine(true); //134:1
                __out.Write("        public override ImmutableArray<Symbol> ChildSymbols "); //135:1
                __out.AppendLine(false); //135:61
                __out.Write("        {"); //136:1
                __out.AppendLine(false); //136:10
                __out.Write("            get"); //137:1
                __out.AppendLine(false); //137:16
                __out.Write("            {"); //138:1
                __out.AppendLine(false); //138:14
                __out.Write("                this.ForceComplete(CompletionGraph.FinishCreatingChildren, null, default);"); //139:1
                __out.AppendLine(false); //139:91
                __out.Write("                return _childSymbols;"); //140:1
                __out.AppendLine(false); //140:38
                __out.Write("            }"); //141:1
                __out.AppendLine(false); //141:14
                __out.Write("        }"); //142:1
                __out.AppendLine(false); //142:10
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("Name")) //144:10
            {
                __out.AppendLine(true); //145:1
                __out.Write("        public override string Name "); //146:1
                __out.AppendLine(false); //146:37
                __out.Write("        {"); //147:1
                __out.AppendLine(false); //147:10
                __out.Write("            get"); //148:1
                __out.AppendLine(false); //148:16
                __out.Write("            {"); //149:1
                __out.AppendLine(false); //149:14
                __out.Write("                this.ForceComplete(CompletionGraph.FinishInitializing, null, default);"); //150:1
                __out.AppendLine(false); //150:87
                __out.Write("                return _name;"); //151:1
                __out.AppendLine(false); //151:30
                __out.Write("            }"); //152:1
                __out.AppendLine(false); //152:14
                __out.Write("        }"); //153:1
                __out.AppendLine(false); //153:10
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("MetadataName")) //155:10
            {
                __out.AppendLine(true); //156:1
                __out.Write("        public override string MetadataName "); //157:1
                __out.AppendLine(false); //157:45
                __out.Write("        {"); //158:1
                __out.AppendLine(false); //158:10
                __out.Write("            get"); //159:1
                __out.AppendLine(false); //159:16
                __out.Write("            {"); //160:1
                __out.AppendLine(false); //160:14
                __out.Write("                this.ForceComplete(CompletionGraph.FinishInitializing, null, default);"); //161:1
                __out.AppendLine(false); //161:87
                __out.Write("                return _metadataName;"); //162:1
                __out.AppendLine(false); //162:38
                __out.Write("            }"); //163:1
                __out.AppendLine(false); //163:14
                __out.Write("        }"); //164:1
                __out.AppendLine(false); //164:10
            }
            var __loop6_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //166:16
                select new { prop = prop}
                ).ToList(); //166:10
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp39 = __loop6_results[__loop6_iteration];
                var prop = __tmp39.prop;
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains(prop.Name)) //167:14
                {
                    __out.AppendLine(true); //168:1
                    bool __tmp41_outputWritten = false;
                    string __tmp42_line = "        public override "; //169:1
                    if (!string.IsNullOrEmpty(__tmp42_line))
                    {
                        __out.Write(__tmp42_line);
                        __tmp41_outputWritten = true;
                    }
                    var __tmp43 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp43.Write(prop.Type);
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
                    string __tmp44_line = " "; //169:36
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
                        if (!__tmp45_last || __tmp41_outputWritten) __out.AppendLine(true);
                    }
                    if (__tmp41_outputWritten)
                    {
                        __out.AppendLine(false); //169:48
                    }
                    __out.Write("        {"); //170:1
                    __out.AppendLine(false); //170:10
                    __out.Write("            get"); //171:1
                    __out.AppendLine(false); //171:16
                    __out.Write("            {"); //172:1
                    __out.AppendLine(false); //172:14
                    bool __tmp47_outputWritten = false;
                    string __tmp48_line = "                this.ForceComplete(CompletionParts."; //173:1
                    if (!string.IsNullOrEmpty(__tmp48_line))
                    {
                        __out.Write(__tmp48_line);
                        __tmp47_outputWritten = true;
                    }
                    var __tmp49 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp49.Write(prop.FinishCompletionPartName);
                    var __tmp49Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp49.ToStringAndFree());
                    bool __tmp49_last = __tmp49Reader.EndOfStream;
                    while(!__tmp49_last)
                    {
                        ReadOnlySpan<char> __tmp49_line = __tmp49Reader.ReadLine();
                        __tmp49_last = __tmp49Reader.EndOfStream;
                        if (!__tmp49_last || !__tmp49_line.IsEmpty)
                        {
                            __out.Write(__tmp49_line);
                            __tmp47_outputWritten = true;
                        }
                        if (!__tmp49_last) __out.AppendLine(true);
                    }
                    string __tmp50_line = ", null, default);"; //173:83
                    if (!string.IsNullOrEmpty(__tmp50_line))
                    {
                        __out.Write(__tmp50_line);
                        __tmp47_outputWritten = true;
                    }
                    if (__tmp47_outputWritten) __out.AppendLine(true);
                    if (__tmp47_outputWritten)
                    {
                        __out.AppendLine(false); //173:100
                    }
                    bool __tmp52_outputWritten = false;
                    string __tmp53_line = "                return "; //174:1
                    if (!string.IsNullOrEmpty(__tmp53_line))
                    {
                        __out.Write(__tmp53_line);
                        __tmp52_outputWritten = true;
                    }
                    var __tmp54 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp54.Write(prop.FieldName);
                    var __tmp54Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp54.ToStringAndFree());
                    bool __tmp54_last = __tmp54Reader.EndOfStream;
                    while(!__tmp54_last)
                    {
                        ReadOnlySpan<char> __tmp54_line = __tmp54Reader.ReadLine();
                        __tmp54_last = __tmp54Reader.EndOfStream;
                        if (!__tmp54_last || !__tmp54_line.IsEmpty)
                        {
                            __out.Write(__tmp54_line);
                            __tmp52_outputWritten = true;
                        }
                        if (!__tmp54_last) __out.AppendLine(true);
                    }
                    string __tmp55_line = ";"; //174:40
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Write(__tmp55_line);
                        __tmp52_outputWritten = true;
                    }
                    if (__tmp52_outputWritten) __out.AppendLine(true);
                    if (__tmp52_outputWritten)
                    {
                        __out.AppendLine(false); //174:41
                    }
                    __out.Write("            }"); //175:1
                    __out.AppendLine(false); //175:14
                    __out.Write("        }"); //176:1
                    __out.AppendLine(false); //176:10
                }
            }
            __out.AppendLine(true); //179:1
            __out.Write("        #region Completion"); //180:1
            __out.AppendLine(false); //180:27
            __out.AppendLine(true); //181:1
            __out.Write("        public sealed override bool RequiresCompletion => true;"); //182:1
            __out.AppendLine(false); //182:64
            __out.AppendLine(true); //183:1
            __out.Write("        public sealed override bool HasComplete(CompletionPart part)"); //184:1
            __out.AppendLine(false); //184:69
            __out.Write("        {"); //185:1
            __out.AppendLine(false); //185:10
            __out.Write("            return _state.HasComplete(part);"); //186:1
            __out.AppendLine(false); //186:45
            __out.Write("        }"); //187:1
            __out.AppendLine(false); //187:10
            __out.AppendLine(true); //188:1
            __out.Write("        public override void ForceComplete(CompletionPart completionPart, SourceLocation? locationOpt, CancellationToken cancellationToken)"); //189:1
            __out.AppendLine(false); //189:140
            __out.Write("        {"); //190:1
            __out.AppendLine(false); //190:10
            __out.Write("            if (completionPart != null && _state.HasComplete(completionPart)) return;"); //191:1
            __out.AppendLine(false); //191:86
            __out.Write("            if (completionPart != null && !CompletionParts.All.Contains(completionPart)) throw new ArgumentException(nameof(completionPart));"); //192:1
            __out.AppendLine(false); //192:142
            __out.Write("            while (true)"); //193:1
            __out.AppendLine(false); //193:25
            __out.Write("            {"); //194:1
            __out.AppendLine(false); //194:14
            __out.Write("                cancellationToken.ThrowIfCancellationRequested();"); //195:1
            __out.AppendLine(false); //195:66
            __out.Write("                var incompletePart = _state.NextIncompletePart;"); //196:1
            __out.AppendLine(false); //196:64
            __out.Write("                if (incompletePart == CompletionGraph.StartInitializing || incompletePart == CompletionGraph.FinishInitializing)"); //197:1
            __out.AppendLine(false); //197:129
            __out.Write("                {"); //198:1
            __out.AppendLine(false); //198:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartInitializing))"); //199:1
            __out.AppendLine(false); //199:84
            __out.Write("                    {"); //200:1
            __out.AppendLine(false); //200:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //201:1
            __out.AppendLine(false); //201:71
            __out.Write("                        _name = CompleteSymbolProperty_Name(diagnostics, cancellationToken);"); //202:1
            __out.AppendLine(false); //202:93
            __out.Write("                        _metadataName = CompleteSymbolProperty_MetadataName(diagnostics, cancellationToken);"); //203:1
            __out.AppendLine(false); //203:109
            __out.Write("                        CompleteInitializingSymbol(diagnostics, cancellationToken);"); //204:1
            __out.AppendLine(false); //204:84
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //205:1
            __out.AppendLine(false); //205:59
            __out.Write("                        diagnostics.Free();"); //206:1
            __out.AppendLine(false); //206:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishInitializing);"); //207:1
            __out.AppendLine(false); //207:85
            __out.Write("                    }"); //208:1
            __out.AppendLine(false); //208:22
            __out.Write("                }"); //209:1
            __out.AppendLine(false); //209:18
            __out.Write("                else if (incompletePart == CompletionGraph.StartCreatingChildren || incompletePart == CompletionGraph.FinishCreatingChildren)"); //210:1
            __out.AppendLine(false); //210:142
            __out.Write("                {"); //211:1
            __out.AppendLine(false); //211:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartCreatingChildren))"); //212:1
            __out.AppendLine(false); //212:88
            __out.Write("                    {"); //213:1
            __out.AppendLine(false); //213:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //214:1
            __out.AppendLine(false); //214:71
            __out.Write("                        _childSymbols = CompleteCreatingChildSymbols(diagnostics, cancellationToken);"); //215:1
            __out.AppendLine(false); //215:102
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //216:1
            __out.AppendLine(false); //216:59
            __out.Write("                        diagnostics.Free();"); //217:1
            __out.AppendLine(false); //217:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishCreatingChildren);"); //218:1
            __out.AppendLine(false); //218:89
            __out.Write("                    }"); //219:1
            __out.AppendLine(false); //219:22
            __out.Write("                }"); //220:1
            __out.AppendLine(false); //220:18
            var __loop7_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //221:24
                select new { part = part}
                ).ToList(); //221:18
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                var __tmp56 = __loop7_results[__loop7_iteration];
                var part = __tmp56.part;
                if (part.IsLocked) //222:22
                {
                    bool __tmp58_outputWritten = false;
                    string __tmp59_line = "                else if (incompletePart == CompletionParts."; //223:1
                    if (!string.IsNullOrEmpty(__tmp59_line))
                    {
                        __out.Write(__tmp59_line);
                        __tmp58_outputWritten = true;
                    }
                    var __tmp60 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp60.Write(part.StartCompletionPartName);
                    var __tmp60Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp60.ToStringAndFree());
                    bool __tmp60_last = __tmp60Reader.EndOfStream;
                    while(!__tmp60_last)
                    {
                        ReadOnlySpan<char> __tmp60_line = __tmp60Reader.ReadLine();
                        __tmp60_last = __tmp60Reader.EndOfStream;
                        if (!__tmp60_last || !__tmp60_line.IsEmpty)
                        {
                            __out.Write(__tmp60_line);
                            __tmp58_outputWritten = true;
                        }
                        if (!__tmp60_last) __out.AppendLine(true);
                    }
                    string __tmp61_line = " || incompletePart == CompletionParts."; //223:90
                    if (!string.IsNullOrEmpty(__tmp61_line))
                    {
                        __out.Write(__tmp61_line);
                        __tmp58_outputWritten = true;
                    }
                    var __tmp62 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp62.Write(part.FinishCompletionPartName);
                    var __tmp62Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp62.ToStringAndFree());
                    bool __tmp62_last = __tmp62Reader.EndOfStream;
                    while(!__tmp62_last)
                    {
                        ReadOnlySpan<char> __tmp62_line = __tmp62Reader.ReadLine();
                        __tmp62_last = __tmp62Reader.EndOfStream;
                        if (!__tmp62_last || !__tmp62_line.IsEmpty)
                        {
                            __out.Write(__tmp62_line);
                            __tmp58_outputWritten = true;
                        }
                        if (!__tmp62_last) __out.AppendLine(true);
                    }
                    string __tmp63_line = ")"; //223:159
                    if (!string.IsNullOrEmpty(__tmp63_line))
                    {
                        __out.Write(__tmp63_line);
                        __tmp58_outputWritten = true;
                    }
                    if (__tmp58_outputWritten) __out.AppendLine(true);
                    if (__tmp58_outputWritten)
                    {
                        __out.AppendLine(false); //223:160
                    }
                    __out.Write("                {"); //224:1
                    __out.AppendLine(false); //224:18
                    bool __tmp65_outputWritten = false;
                    string __tmp66_line = "                    if (_state.NotePartComplete(CompletionParts."; //225:1
                    if (!string.IsNullOrEmpty(__tmp66_line))
                    {
                        __out.Write(__tmp66_line);
                        __tmp65_outputWritten = true;
                    }
                    var __tmp67 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp67.Write(part.StartCompletionPartName);
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
                    string __tmp68_line = "))"; //225:95
                    if (!string.IsNullOrEmpty(__tmp68_line))
                    {
                        __out.Write(__tmp68_line);
                        __tmp65_outputWritten = true;
                    }
                    if (__tmp65_outputWritten) __out.AppendLine(true);
                    if (__tmp65_outputWritten)
                    {
                        __out.AppendLine(false); //225:97
                    }
                    __out.Write("                    {"); //226:1
                    __out.AppendLine(false); //226:22
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //227:26
                    {
                        __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //228:1
                        __out.AppendLine(false); //228:71
                    }
                    bool __tmp70_outputWritten = false;
                    string __tmp69Prefix = "                        "; //230:1
                    if (part is SymbolPropertyGenerationInfo) //230:26
                    {
                        if (!string.IsNullOrEmpty(__tmp69Prefix))
                        {
                            __out.Write(__tmp69Prefix);
                            __tmp70_outputWritten = true;
                        }
                        var __tmp72 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp72.Write(((SymbolPropertyGenerationInfo)part).FieldName);
                        var __tmp72Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp72.ToStringAndFree());
                        bool __tmp72_last = __tmp72Reader.EndOfStream;
                        while(!__tmp72_last)
                        {
                            ReadOnlySpan<char> __tmp72_line = __tmp72Reader.ReadLine();
                            __tmp72_last = __tmp72Reader.EndOfStream;
                            if (!__tmp72_last || !__tmp72_line.IsEmpty)
                            {
                                __out.Write(__tmp72_line);
                                __tmp70_outputWritten = true;
                            }
                            if (!__tmp72_last) __out.AppendLine(true);
                        }
                        string __tmp73_line = " = "; //230:116
                        if (!string.IsNullOrEmpty(__tmp73_line))
                        {
                            __out.Write(__tmp73_line);
                            __tmp70_outputWritten = true;
                        }
                    }
                    var __tmp75 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp75.Write(part.CompleteMethodName);
                    var __tmp75Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp75.ToStringAndFree());
                    bool __tmp75_last = __tmp75Reader.EndOfStream;
                    while(!__tmp75_last)
                    {
                        ReadOnlySpan<char> __tmp75_line = __tmp75Reader.ReadLine();
                        __tmp75_last = __tmp75Reader.EndOfStream;
                        if (!__tmp75_last || !__tmp75_line.IsEmpty)
                        {
                            __out.Write(__tmp75_line);
                            __tmp70_outputWritten = true;
                        }
                        if (!__tmp75_last) __out.AppendLine(true);
                    }
                    string __tmp76_line = "("; //230:152
                    if (!string.IsNullOrEmpty(__tmp76_line))
                    {
                        __out.Write(__tmp76_line);
                        __tmp70_outputWritten = true;
                    }
                    var __tmp77 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp77.Write(part.CompleteMethodArgList);
                    var __tmp77Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp77.ToStringAndFree());
                    bool __tmp77_last = __tmp77Reader.EndOfStream;
                    while(!__tmp77_last)
                    {
                        ReadOnlySpan<char> __tmp77_line = __tmp77Reader.ReadLine();
                        __tmp77_last = __tmp77Reader.EndOfStream;
                        if (!__tmp77_last || !__tmp77_line.IsEmpty)
                        {
                            __out.Write(__tmp77_line);
                            __tmp70_outputWritten = true;
                        }
                        if (!__tmp77_last) __out.AppendLine(true);
                    }
                    string __tmp78_line = ");"; //230:181
                    if (!string.IsNullOrEmpty(__tmp78_line))
                    {
                        __out.Write(__tmp78_line);
                        __tmp70_outputWritten = true;
                    }
                    if (__tmp70_outputWritten) __out.AppendLine(true);
                    if (__tmp70_outputWritten)
                    {
                        __out.AppendLine(false); //230:183
                    }
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //231:26
                    {
                        __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //232:1
                        __out.AppendLine(false); //232:59
                        __out.Write("                        diagnostics.Free();"); //233:1
                        __out.AppendLine(false); //233:44
                    }
                    bool __tmp80_outputWritten = false;
                    string __tmp81_line = "                        _state.NotePartComplete(CompletionParts."; //235:1
                    if (!string.IsNullOrEmpty(__tmp81_line))
                    {
                        __out.Write(__tmp81_line);
                        __tmp80_outputWritten = true;
                    }
                    var __tmp82 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp82.Write(part.FinishCompletionPartName);
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
                    string __tmp83_line = ");"; //235:96
                    if (!string.IsNullOrEmpty(__tmp83_line))
                    {
                        __out.Write(__tmp83_line);
                        __tmp80_outputWritten = true;
                    }
                    if (__tmp80_outputWritten) __out.AppendLine(true);
                    if (__tmp80_outputWritten)
                    {
                        __out.AppendLine(false); //235:98
                    }
                    __out.Write("                    }"); //236:1
                    __out.AppendLine(false); //236:22
                    __out.Write("                }"); //237:1
                    __out.AppendLine(false); //237:18
                }
                else //238:22
                {
                    bool __tmp85_outputWritten = false;
                    string __tmp86_line = "                else if (incompletePart == CompletionParts."; //239:1
                    if (!string.IsNullOrEmpty(__tmp86_line))
                    {
                        __out.Write(__tmp86_line);
                        __tmp85_outputWritten = true;
                    }
                    var __tmp87 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp87.Write(part.CompletionPartName);
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
                    string __tmp88_line = ")"; //239:85
                    if (!string.IsNullOrEmpty(__tmp88_line))
                    {
                        __out.Write(__tmp88_line);
                        __tmp85_outputWritten = true;
                    }
                    if (__tmp85_outputWritten) __out.AppendLine(true);
                    if (__tmp85_outputWritten)
                    {
                        __out.AppendLine(false); //239:86
                    }
                    __out.Write("                {"); //240:1
                    __out.AppendLine(false); //240:18
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //241:22
                    {
                        __out.Write("                    var diagnostics = DiagnosticBag.GetInstance();"); //242:1
                        __out.AppendLine(false); //242:67
                    }
                    bool __tmp90_outputWritten = false;
                    string __tmp89Prefix = "                    "; //244:1
                    var __tmp91 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp91.Write(part.CompleteMethodName);
                    var __tmp91Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp91.ToStringAndFree());
                    bool __tmp91_last = __tmp91Reader.EndOfStream;
                    while(!__tmp91_last)
                    {
                        ReadOnlySpan<char> __tmp91_line = __tmp91Reader.ReadLine();
                        __tmp91_last = __tmp91Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp89Prefix))
                        {
                            __out.Write(__tmp89Prefix);
                            __tmp90_outputWritten = true;
                        }
                        if (!__tmp91_last || !__tmp91_line.IsEmpty)
                        {
                            __out.Write(__tmp91_line);
                            __tmp90_outputWritten = true;
                        }
                        if (!__tmp91_last) __out.AppendLine(true);
                    }
                    string __tmp92_line = "("; //244:46
                    if (!string.IsNullOrEmpty(__tmp92_line))
                    {
                        __out.Write(__tmp92_line);
                        __tmp90_outputWritten = true;
                    }
                    var __tmp93 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp93.Write(part.CompleteMethodArgList);
                    var __tmp93Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp93.ToStringAndFree());
                    bool __tmp93_last = __tmp93Reader.EndOfStream;
                    while(!__tmp93_last)
                    {
                        ReadOnlySpan<char> __tmp93_line = __tmp93Reader.ReadLine();
                        __tmp93_last = __tmp93Reader.EndOfStream;
                        if (!__tmp93_last || !__tmp93_line.IsEmpty)
                        {
                            __out.Write(__tmp93_line);
                            __tmp90_outputWritten = true;
                        }
                        if (!__tmp93_last) __out.AppendLine(true);
                    }
                    string __tmp94_line = ");"; //244:75
                    if (!string.IsNullOrEmpty(__tmp94_line))
                    {
                        __out.Write(__tmp94_line);
                        __tmp90_outputWritten = true;
                    }
                    if (__tmp90_outputWritten) __out.AppendLine(true);
                    if (__tmp90_outputWritten)
                    {
                        __out.AppendLine(false); //244:77
                    }
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //245:22
                    {
                        __out.Write("                    AddSymbolDiagnostics(diagnostics);"); //246:1
                        __out.AppendLine(false); //246:55
                        __out.Write("                    diagnostics.Free();"); //247:1
                        __out.AppendLine(false); //247:40
                    }
                    bool __tmp96_outputWritten = false;
                    string __tmp97_line = "                    _state.NotePartComplete(CompletionParts."; //249:1
                    if (!string.IsNullOrEmpty(__tmp97_line))
                    {
                        __out.Write(__tmp97_line);
                        __tmp96_outputWritten = true;
                    }
                    var __tmp98 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp98.Write(part.CompletionPartName);
                    var __tmp98Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp98.ToStringAndFree());
                    bool __tmp98_last = __tmp98Reader.EndOfStream;
                    while(!__tmp98_last)
                    {
                        ReadOnlySpan<char> __tmp98_line = __tmp98Reader.ReadLine();
                        __tmp98_last = __tmp98Reader.EndOfStream;
                        if (!__tmp98_last || !__tmp98_line.IsEmpty)
                        {
                            __out.Write(__tmp98_line);
                            __tmp96_outputWritten = true;
                        }
                        if (!__tmp98_last) __out.AppendLine(true);
                    }
                    string __tmp99_line = ");"; //249:86
                    if (!string.IsNullOrEmpty(__tmp99_line))
                    {
                        __out.Write(__tmp99_line);
                        __tmp96_outputWritten = true;
                    }
                    if (__tmp96_outputWritten) __out.AppendLine(true);
                    if (__tmp96_outputWritten)
                    {
                        __out.AppendLine(false); //249:88
                    }
                    __out.Write("                }"); //250:1
                    __out.AppendLine(false); //250:18
                }
            }
            __out.Write("                else if (incompletePart == CompletionGraph.StartComputingNonSymbolProperties || incompletePart == CompletionGraph.FinishComputingNonSymbolProperties)"); //253:1
            __out.AppendLine(false); //253:166
            __out.Write("                {"); //254:1
            __out.AppendLine(false); //254:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartComputingNonSymbolProperties))"); //255:1
            __out.AppendLine(false); //255:100
            __out.Write("                    {"); //256:1
            __out.AppendLine(false); //256:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //257:1
            __out.AppendLine(false); //257:71
            __out.Write("                        CompleteNonSymbolProperties(locationOpt, diagnostics, cancellationToken);"); //258:1
            __out.AppendLine(false); //258:98
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //259:1
            __out.AppendLine(false); //259:59
            __out.Write("                        diagnostics.Free();"); //260:1
            __out.AppendLine(false); //260:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishComputingNonSymbolProperties);"); //261:1
            __out.AppendLine(false); //261:101
            __out.Write("                    }"); //262:1
            __out.AppendLine(false); //262:22
            __out.Write("                }"); //263:1
            __out.AppendLine(false); //263:18
            __out.Write("                else if (incompletePart == CompletionGraph.ChildrenCompleted)"); //264:1
            __out.AppendLine(false); //264:78
            __out.Write("                {"); //265:1
            __out.AppendLine(false); //265:18
            __out.Write("                    var diagnostics = DiagnosticBag.GetInstance();"); //266:1
            __out.AppendLine(false); //266:67
            __out.Write("                    CompleteImports(locationOpt, diagnostics, cancellationToken);"); //267:1
            __out.AppendLine(false); //267:82
            __out.Write("                    AddSymbolDiagnostics(diagnostics);"); //268:1
            __out.AppendLine(false); //268:55
            __out.Write("                    diagnostics.Free();"); //269:1
            __out.AppendLine(false); //269:40
            __out.Write("                    bool allCompleted = true;"); //271:1
            __out.AppendLine(false); //271:46
            __out.Write("                    if (locationOpt == null)"); //272:1
            __out.AppendLine(false); //272:45
            __out.Write("                    {"); //273:1
            __out.AppendLine(false); //273:22
            __out.Write("                        foreach (var child in _childSymbols)"); //274:1
            __out.AppendLine(false); //274:61
            __out.Write("                        {"); //275:1
            __out.AppendLine(false); //275:26
            __out.Write("                            cancellationToken.ThrowIfCancellationRequested();"); //276:1
            __out.AppendLine(false); //276:78
            __out.Write("                            child.ForceComplete(null, locationOpt, cancellationToken);"); //277:1
            __out.AppendLine(false); //277:87
            __out.Write("                        }"); //278:1
            __out.AppendLine(false); //278:26
            __out.Write("                    }"); //279:1
            __out.AppendLine(false); //279:22
            __out.Write("                    else"); //280:1
            __out.AppendLine(false); //280:25
            __out.Write("                    {"); //281:1
            __out.AppendLine(false); //281:22
            __out.Write("                        foreach (var child in _childSymbols)"); //282:1
            __out.AppendLine(false); //282:61
            __out.Write("                        {"); //283:1
            __out.AppendLine(false); //283:26
            __out.Write("                            ForceCompleteChildByLocation(locationOpt, child, cancellationToken);"); //284:1
            __out.AppendLine(false); //284:97
            __out.Write("                            allCompleted = allCompleted && child.HasComplete(CompletionGraph.All);"); //285:1
            __out.AppendLine(false); //285:99
            __out.Write("                        }"); //286:1
            __out.AppendLine(false); //286:26
            __out.Write("                    }"); //287:1
            __out.AppendLine(false); //287:22
            __out.Write("                    if (!allCompleted)"); //289:1
            __out.AppendLine(false); //289:39
            __out.Write("                    {"); //290:1
            __out.AppendLine(false); //290:22
            __out.Write("                        // We did not complete all members, so just kick out now."); //291:1
            __out.AppendLine(false); //291:82
            __out.Write("                        var allParts = CompletionParts.AllWithLocation;"); //292:1
            __out.AppendLine(false); //292:72
            __out.Write("                        _state.SpinWaitComplete(allParts, cancellationToken);"); //293:1
            __out.AppendLine(false); //293:78
            __out.Write("                        return;"); //294:1
            __out.AppendLine(false); //294:32
            __out.Write("                    }"); //295:1
            __out.AppendLine(false); //295:22
            __out.Write("                    // We've completed all members, proceed to the next iteration."); //297:1
            __out.AppendLine(false); //297:83
            __out.Write("                    _state.NotePartComplete(CompletionGraph.ChildrenCompleted);"); //298:1
            __out.AppendLine(false); //298:80
            __out.Write("                }"); //299:1
            __out.AppendLine(false); //299:18
            __out.Write("                else if (incompletePart == CompletionGraph.StartValidatingSymbol || incompletePart == CompletionGraph.FinishValidatingSymbol)"); //300:1
            __out.AppendLine(false); //300:142
            __out.Write("                {"); //301:1
            __out.AppendLine(false); //301:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartValidatingSymbol))"); //302:1
            __out.AppendLine(false); //302:88
            __out.Write("                    {"); //303:1
            __out.AppendLine(false); //303:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //304:1
            __out.AppendLine(false); //304:71
            __out.Write("                        CompleteValidatingSymbol(diagnostics, cancellationToken);"); //305:1
            __out.AppendLine(false); //305:82
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //306:1
            __out.AppendLine(false); //306:59
            __out.Write("                        diagnostics.Free();"); //307:1
            __out.AppendLine(false); //307:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishValidatingSymbol);"); //308:1
            __out.AppendLine(false); //308:89
            __out.Write("                    }"); //309:1
            __out.AppendLine(false); //309:22
            __out.Write("                }"); //310:1
            __out.AppendLine(false); //310:18
            __out.Write("                else if (incompletePart == null)"); //311:1
            __out.AppendLine(false); //311:49
            __out.Write("                {"); //312:1
            __out.AppendLine(false); //312:18
            __out.Write("                    return;"); //313:1
            __out.AppendLine(false); //313:28
            __out.Write("                }"); //314:1
            __out.AppendLine(false); //314:18
            __out.Write("                else"); //315:1
            __out.AppendLine(false); //315:21
            __out.Write("                {"); //316:1
            __out.AppendLine(false); //316:18
            __out.Write("                    // This assert will trigger if we forgot to handle any of the completion parts"); //317:1
            __out.AppendLine(false); //317:99
            __out.Write("                    Debug.Assert(!CompletionParts.All.Contains(incompletePart));"); //318:1
            __out.AppendLine(false); //318:81
            __out.Write("                    // any other values are completion parts intended for other kinds of symbols"); //319:1
            __out.AppendLine(false); //319:97
            __out.Write("                    _state.NotePartComplete(incompletePart);"); //320:1
            __out.AppendLine(false); //320:61
            __out.Write("                }"); //321:1
            __out.AppendLine(false); //321:18
            __out.Write("                if (completionPart != null && _state.HasComplete(completionPart)) return;"); //322:1
            __out.AppendLine(false); //322:90
            __out.Write("                _state.SpinWaitComplete(incompletePart, cancellationToken);"); //323:1
            __out.AppendLine(false); //323:76
            __out.Write("            }"); //324:1
            __out.AppendLine(false); //324:14
            __out.Write("            throw ExceptionUtilities.Unreachable;"); //325:1
            __out.AppendLine(false); //325:50
            __out.Write("        }"); //326:1
            __out.AppendLine(false); //326:10
            __out.AppendLine(true); //327:1
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteSymbolProperty_Name")) //328:10
            {
                __out.AppendLine(true); //329:1
                __out.Write("        protected virtual string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //330:1
                __out.AppendLine(false); //330:125
                __out.Write("        {"); //331:1
                __out.AppendLine(false); //331:10
                __out.Write("            return SymbolImplementation.AssignNameProperty(this, diagnostics);"); //332:1
                __out.AppendLine(false); //332:79
                __out.Write("        }"); //333:1
                __out.AppendLine(false); //333:10
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteSymbolProperty_MetadataName")) //335:10
            {
                __out.AppendLine(true); //336:1
                __out.Write("        protected virtual string CompleteSymbolProperty_MetadataName(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //337:1
                __out.AppendLine(false); //337:133
                __out.Write("        {"); //338:1
                __out.AppendLine(false); //338:10
                __out.Write("            return SymbolImplementation.AssignMetadataNameProperty(this, diagnostics);"); //339:1
                __out.AppendLine(false); //339:87
                __out.Write("        }"); //340:1
                __out.AppendLine(false); //340:10
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteInitializingSymbol")) //342:10
            {
                __out.AppendLine(true); //343:1
                __out.Write("        protected virtual void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //344:1
                __out.AppendLine(false); //344:122
                __out.Write("        {"); //345:1
                __out.AppendLine(false); //345:10
                __out.Write("        }"); //346:1
                __out.AppendLine(false); //346:10
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteCreatingChildSymbols")) //348:10
            {
                __out.AppendLine(true); //349:1
                __out.Write("        protected virtual ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //350:1
                __out.AppendLine(false); //350:142
                __out.Write("        {"); //351:1
                __out.AppendLine(false); //351:10
                __out.Write("            return SymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //352:1
                __out.AppendLine(false); //352:118
                __out.Write("        }"); //353:1
                __out.AppendLine(false); //353:10
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteImports")) //355:10
            {
                __out.AppendLine(true); //356:1
                __out.Write("        protected virtual void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //357:1
                __out.AppendLine(false); //357:139
                __out.Write("        {"); //358:1
                __out.AppendLine(false); //358:10
                __out.Write("            SymbolImplementation.CompleteImports(this, locationOpt, diagnostics, cancellationToken);"); //359:1
                __out.AppendLine(false); //359:101
                __out.Write("        }"); //360:1
                __out.AppendLine(false); //360:10
            }
            var __loop8_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //362:16
                where part.GenerateCompleteMethod //362:44
                select new { part = part}
                ).ToList(); //362:10
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp100 = __loop8_results[__loop8_iteration];
                var part = __tmp100.part;
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains(part.CompleteMethodName)) //363:14
                {
                    __out.AppendLine(true); //364:1
                    bool __tmp102_outputWritten = false;
                    string __tmp103_line = "        protected virtual "; //365:1
                    if (!string.IsNullOrEmpty(__tmp103_line))
                    {
                        __out.Write(__tmp103_line);
                        __tmp102_outputWritten = true;
                    }
                    var __tmp104 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp104.Write(part.CompleteMethodReturnType);
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
                    string __tmp105_line = " "; //365:58
                    if (!string.IsNullOrEmpty(__tmp105_line))
                    {
                        __out.Write(__tmp105_line);
                        __tmp102_outputWritten = true;
                    }
                    var __tmp106 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp106.Write(part.CompleteMethodName);
                    var __tmp106Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp106.ToStringAndFree());
                    bool __tmp106_last = __tmp106Reader.EndOfStream;
                    while(!__tmp106_last)
                    {
                        ReadOnlySpan<char> __tmp106_line = __tmp106Reader.ReadLine();
                        __tmp106_last = __tmp106Reader.EndOfStream;
                        if (!__tmp106_last || !__tmp106_line.IsEmpty)
                        {
                            __out.Write(__tmp106_line);
                            __tmp102_outputWritten = true;
                        }
                        if (!__tmp106_last) __out.AppendLine(true);
                    }
                    string __tmp107_line = "("; //365:84
                    if (!string.IsNullOrEmpty(__tmp107_line))
                    {
                        __out.Write(__tmp107_line);
                        __tmp102_outputWritten = true;
                    }
                    var __tmp108 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp108.Write(part.CompleteMethodParamList);
                    var __tmp108Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp108.ToStringAndFree());
                    bool __tmp108_last = __tmp108Reader.EndOfStream;
                    while(!__tmp108_last)
                    {
                        ReadOnlySpan<char> __tmp108_line = __tmp108Reader.ReadLine();
                        __tmp108_last = __tmp108Reader.EndOfStream;
                        if (!__tmp108_last || !__tmp108_line.IsEmpty)
                        {
                            __out.Write(__tmp108_line);
                            __tmp102_outputWritten = true;
                        }
                        if (!__tmp108_last) __out.AppendLine(true);
                    }
                    string __tmp109_line = ")"; //365:115
                    if (!string.IsNullOrEmpty(__tmp109_line))
                    {
                        __out.Write(__tmp109_line);
                        __tmp102_outputWritten = true;
                    }
                    if (__tmp102_outputWritten) __out.AppendLine(true);
                    if (__tmp102_outputWritten)
                    {
                        __out.AppendLine(false); //365:116
                    }
                    __out.Write("        {"); //366:1
                    __out.AppendLine(false); //366:10
                    if (part is SymbolPropertyGenerationInfo) //367:14
                    {
                        var prop = (SymbolPropertyGenerationInfo)part; //368:18
                        if (prop.IsCollection) //369:18
                        {
                            bool __tmp111_outputWritten = false;
                            string __tmp112_line = "            SymbolImplementation.AssignSymbolPropertyValues<"; //370:1
                            if (!string.IsNullOrEmpty(__tmp112_line))
                            {
                                __out.Write(__tmp112_line);
                                __tmp111_outputWritten = true;
                            }
                            var __tmp113 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp113.Write(prop.ItemType);
                            var __tmp113Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp113.ToStringAndFree());
                            bool __tmp113_last = __tmp113Reader.EndOfStream;
                            while(!__tmp113_last)
                            {
                                ReadOnlySpan<char> __tmp113_line = __tmp113Reader.ReadLine();
                                __tmp113_last = __tmp113Reader.EndOfStream;
                                if (!__tmp113_last || !__tmp113_line.IsEmpty)
                                {
                                    __out.Write(__tmp113_line);
                                    __tmp111_outputWritten = true;
                                }
                                if (!__tmp113_last) __out.AppendLine(true);
                            }
                            string __tmp114_line = ">(this, nameof("; //370:76
                            if (!string.IsNullOrEmpty(__tmp114_line))
                            {
                                __out.Write(__tmp114_line);
                                __tmp111_outputWritten = true;
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
                                    __tmp111_outputWritten = true;
                                }
                                if (!__tmp115_last) __out.AppendLine(true);
                            }
                            string __tmp116_line = "), diagnostics, cancellationToken, out var result);"; //370:102
                            if (!string.IsNullOrEmpty(__tmp116_line))
                            {
                                __out.Write(__tmp116_line);
                                __tmp111_outputWritten = true;
                            }
                            if (__tmp111_outputWritten) __out.AppendLine(true);
                            if (__tmp111_outputWritten)
                            {
                                __out.AppendLine(false); //370:153
                            }
                        }
                        else //371:18
                        {
                            bool __tmp118_outputWritten = false;
                            string __tmp119_line = "            SymbolImplementation.AssignSymbolPropertyValue<"; //372:1
                            if (!string.IsNullOrEmpty(__tmp119_line))
                            {
                                __out.Write(__tmp119_line);
                                __tmp118_outputWritten = true;
                            }
                            var __tmp120 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp120.Write(prop.Type);
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
                            string __tmp121_line = ">(this, nameof("; //372:71
                            if (!string.IsNullOrEmpty(__tmp121_line))
                            {
                                __out.Write(__tmp121_line);
                                __tmp118_outputWritten = true;
                            }
                            var __tmp122 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp122.Write(prop.Name);
                            var __tmp122Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp122.ToStringAndFree());
                            bool __tmp122_last = __tmp122Reader.EndOfStream;
                            while(!__tmp122_last)
                            {
                                ReadOnlySpan<char> __tmp122_line = __tmp122Reader.ReadLine();
                                __tmp122_last = __tmp122Reader.EndOfStream;
                                if (!__tmp122_last || !__tmp122_line.IsEmpty)
                                {
                                    __out.Write(__tmp122_line);
                                    __tmp118_outputWritten = true;
                                }
                                if (!__tmp122_last) __out.AppendLine(true);
                            }
                            string __tmp123_line = "), diagnostics, cancellationToken, out var result);"; //372:97
                            if (!string.IsNullOrEmpty(__tmp123_line))
                            {
                                __out.Write(__tmp123_line);
                                __tmp118_outputWritten = true;
                            }
                            if (__tmp118_outputWritten) __out.AppendLine(true);
                            if (__tmp118_outputWritten)
                            {
                                __out.AppendLine(false); //372:148
                            }
                        }
                    }
                    __out.Write("            return result;"); //375:1
                    __out.AppendLine(false); //375:27
                    __out.Write("        }"); //376:1
                    __out.AppendLine(false); //376:10
                }
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteNonSymbolProperties")) //379:10
            {
                __out.AppendLine(true); //380:1
                __out.Write("        protected virtual void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //381:1
                __out.AppendLine(false); //381:151
                __out.Write("        {"); //382:1
                __out.AppendLine(false); //382:10
                __out.Write("            SymbolImplementation.AssignNonSymbolProperties(this, diagnostics, cancellationToken);"); //383:1
                __out.AppendLine(false); //383:98
                __out.Write("        }"); //384:1
                __out.AppendLine(false); //384:10
            }
            __out.Write("        #endregion"); //386:1
            __out.AppendLine(false); //386:19
            __out.Write("    }"); //387:1
            __out.AppendLine(false); //387:6
            __out.Write("}"); //388:1
            __out.AppendLine(false); //388:2
            return __out.ToStringAndFree();
        }

        public string GenerateMetadataSymbol(SymbolGenerationInfo symbol) //391:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //392:1
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
            string __tmp5_line = ".Metadata"; //392:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //392:42
            }
            __out.Write("{"); //393:1
            __out.AppendLine(false); //393:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Metadata"; //394:1
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
            if (symbol.ExistingMetadataTypeInfo.BaseType == null) //394:45
            {
                string __tmp11_line = " : "; //394:99
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
                string __tmp13_line = ".Completion.Completion"; //394:124
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
                __out.AppendLine(false); //394:167
            }
            __out.Write("	{"); //395:1
            __out.AppendLine(false); //395:3
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //396:10
            {
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //397:10
                {
                    bool __tmp17_outputWritten = false;
                    string __tmp18_line = "        public Metadata"; //398:1
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
                    string __tmp20_line = "(Symbol container"; //398:37
                    if (!string.IsNullOrEmpty(__tmp20_line))
                    {
                        __out.Write(__tmp20_line);
                        __tmp17_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //398:55
                    {
                        string __tmp22_line = ", object? modelObject"; //398:112
                        if (!string.IsNullOrEmpty(__tmp22_line))
                        {
                            __out.Write(__tmp22_line);
                            __tmp17_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //398:134
                        {
                            string __tmp24_line = " = null"; //398:191
                            if (!string.IsNullOrEmpty(__tmp24_line))
                            {
                                __out.Write(__tmp24_line);
                                __tmp17_outputWritten = true;
                            }
                        }
                    }
                    string __tmp27_line = ", bool isError = false)"; //398:214
                    if (!string.IsNullOrEmpty(__tmp27_line))
                    {
                        __out.Write(__tmp27_line);
                        __tmp17_outputWritten = true;
                    }
                    if (__tmp17_outputWritten) __out.AppendLine(true);
                    if (__tmp17_outputWritten)
                    {
                        __out.AppendLine(false); //398:237
                    }
                    __out.Write("            : base(container"); //399:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //399:30
                    {
                        __out.Write(", modelObject"); //399:87
                    }
                    __out.Write(", isError)"); //399:108
                    __out.AppendLine(false); //399:118
                    __out.Write("        {"); //400:1
                    __out.AppendLine(false); //400:10
                    __out.Write("        }"); //401:1
                    __out.AppendLine(false); //401:10
                }
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains("Locations")) //403:10
                {
                    __out.AppendLine(true); //404:1
                    __out.Write("        public override ImmutableArray<Location> Locations => this.ContainingModule?.Locations ?? ImmutableArray<Location>.Empty;"); //405:1
                    __out.AppendLine(false); //405:130
                }
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains("DeclaringSyntaxReferences")) //407:10
                {
                    __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;"); //408:1
                    __out.AppendLine(false); //408:124
                }
            }
            __out.AppendLine(true); //411:1
            __out.Write("        protected override ISymbolImplementation SymbolImplementation => MetadataSymbolImplementation.Instance;"); //412:1
            __out.AppendLine(false); //412:112
            __out.AppendLine(true); //413:1
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //414:10
            {
                bool __tmp29_outputWritten = false;
                string __tmp30_line = "        public partial class Error : Metadata"; //415:1
                if (!string.IsNullOrEmpty(__tmp30_line))
                {
                    __out.Write(__tmp30_line);
                    __tmp29_outputWritten = true;
                }
                var __tmp31 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp31.Write(symbol.Name);
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
                string __tmp32_line = ", MetaDslx.CodeAnalysis.Symbols.IErrorSymbol"; //415:59
                if (!string.IsNullOrEmpty(__tmp32_line))
                {
                    __out.Write(__tmp32_line);
                    __tmp29_outputWritten = true;
                }
                if (__tmp29_outputWritten) __out.AppendLine(true);
                if (__tmp29_outputWritten)
                {
                    __out.AppendLine(false); //415:103
                }
                __out.Write("        {"); //416:1
                __out.AppendLine(false); //416:10
                __out.Write("            private readonly string _name;"); //417:1
                __out.AppendLine(false); //417:43
                __out.Write("            private readonly string _metadataName;"); //418:1
                __out.AppendLine(false); //418:51
                __out.Write("            private DiagnosticInfo _errorInfo;"); //419:1
                __out.AppendLine(false); //419:47
                __out.Write("            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorKind _kind;"); //420:1
                __out.AppendLine(false); //420:76
                __out.Write("            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags _flags;"); //421:1
                __out.AppendLine(false); //421:84
                __out.Write("            private ImmutableArray<Symbol> _candidateSymbols;"); //422:1
                __out.AppendLine(false); //422:62
                __out.AppendLine(true); //423:1
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //424:14
                {
                    __out.Write("            private Error(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags"); //425:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //425:246
                    {
                        __out.Write(", object? modelObject"); //425:303
                    }
                    __out.Write(")"); //425:332
                    __out.AppendLine(false); //425:333
                    __out.Write("                : base(container"); //426:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //426:34
                    {
                        __out.Write(", modelObject"); //426:91
                    }
                    __out.Write(", true)"); //426:112
                    __out.AppendLine(false); //426:119
                    __out.Write("            {"); //427:1
                    __out.AppendLine(false); //427:14
                    __out.Write("                Debug.Assert(!flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported) || errorInfo != null);"); //428:1
                    __out.AppendLine(false); //428:126
                    __out.Write("                _name = name ?? string.Empty;"); //429:1
                    __out.AppendLine(false); //429:46
                    __out.Write("                _metadataName = metadataName ?? _name;"); //430:1
                    __out.AppendLine(false); //430:55
                    __out.Write("                _kind = kind;"); //431:1
                    __out.AppendLine(false); //431:30
                    __out.Write("                _errorInfo = errorInfo;"); //432:1
                    __out.AppendLine(false); //432:40
                    __out.Write("                _candidateSymbols = candidateSymbols;"); //433:1
                    __out.AppendLine(false); //433:54
                    __out.Write("                _flags = flags;"); //434:1
                    __out.AppendLine(false); //434:32
                    __out.Write("            }"); //435:1
                    __out.AppendLine(false); //435:14
                    __out.Write("            public Error(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported"); //437:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //437:208
                    {
                        __out.Write(", object? modelObject"); //437:265
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //437:287
                        {
                            __out.Write(" = null"); //437:344
                        }
                    }
                    __out.Write(")"); //437:367
                    __out.AppendLine(false); //437:368
                    __out.Write("                : this(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.None"); //438:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //438:215
                    {
                        __out.Write(", modelObject"); //438:272
                    }
                    __out.Write(")"); //438:293
                    __out.AppendLine(false); //438:294
                    __out.Write("            {"); //439:1
                    __out.AppendLine(false); //439:14
                    __out.Write("            }"); //440:1
                    __out.AppendLine(false); //440:14
                    __out.Write("            public Error(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported"); //442:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //442:137
                    {
                        __out.Write(", object? modelObject"); //442:194
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //442:216
                        {
                            __out.Write(" = null"); //442:273
                        }
                    }
                    __out.Write(")"); //442:296
                    __out.AppendLine(false); //442:297
                    __out.Write("                : this(wrappedSymbol.ContainingSymbol, wrappedSymbol.Name, wrappedSymbol.MetadataName, kind, errorInfo, ImmutableArray.Create<Symbol>(wrappedSymbol), unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.UnreportedWrapped : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Wrapped"); //443:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //443:302
                    {
                        __out.Write(", modelObject is not null ? modelObject : (wrappedSymbol as IModelSymbol)?.ModelObject"); //443:359
                    }
                    __out.Write(")"); //443:453
                    __out.AppendLine(false); //443:454
                    __out.Write("            {"); //444:1
                    __out.AppendLine(false); //444:14
                    __out.Write("            }"); //445:1
                    __out.AppendLine(false); //445:14
                    __out.AppendLine(true); //446:1
                    __out.Write("            protected virtual Error Update(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags"); //447:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //447:263
                    {
                        __out.Write(", object? modelObject"); //447:320
                    }
                    __out.Write(")"); //447:349
                    __out.AppendLine(false); //447:350
                    __out.Write("            {"); //448:1
                    __out.AppendLine(false); //448:14
                    __out.Write("                return new Error(container, name, metadataName, kind, errorInfo, candidateSymbols, flags"); //449:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //449:106
                    {
                        __out.Write(", modelObject"); //449:163
                    }
                    __out.Write(");"); //449:184
                    __out.AppendLine(false); //449:186
                    __out.Write("            }"); //450:1
                    __out.AppendLine(false); //450:14
                }
                __out.AppendLine(true); //452:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsUnreported(DiagnosticInfo? errorInfo = null)"); //453:1
                __out.AppendLine(false); //453:103
                __out.Write("            {"); //454:1
                __out.AppendLine(false); //454:14
                __out.Write("                return this.IsUnreported ? this :"); //455:1
                __out.AppendLine(false); //455:50
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, _kind, errorInfo is null ? ErrorInfo : errorInfo, CandidateSymbols, _flags | MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported"); //456:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //456:208
                {
                    __out.Write(", this.ModelObject"); //456:265
                }
                __out.Write(");"); //456:291
                __out.AppendLine(false); //456:293
                __out.Write("            }"); //457:1
                __out.AppendLine(false); //457:14
                __out.AppendLine(true); //458:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsReported(DiagnosticInfo? errorInfo = null)"); //459:1
                __out.AppendLine(false); //459:101
                __out.Write("            {"); //460:1
                __out.AppendLine(false); //460:14
                __out.Write("                return this.IsUnreported ? this :"); //461:1
                __out.AppendLine(false); //461:50
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, _kind, errorInfo is null ? ErrorInfo : errorInfo, CandidateSymbols, _flags & ~MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported"); //462:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //462:209
                {
                    __out.Write(", this.ModelObject"); //462:266
                }
                __out.Write(");"); //462:292
                __out.AppendLine(false); //462:294
                __out.Write("            }"); //463:1
                __out.AppendLine(false); //463:14
                __out.AppendLine(true); //464:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind)"); //465:1
                __out.AppendLine(false); //465:109
                __out.Write("            {"); //466:1
                __out.AppendLine(false); //466:14
                __out.Write("                return _kind == kind ? this :"); //467:1
                __out.AppendLine(false); //467:46
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, kind, ErrorInfo, CandidateSymbols, _flags"); //468:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //468:115
                {
                    __out.Write(", this.ModelObject"); //468:172
                }
                __out.Write(");"); //468:198
                __out.AppendLine(false); //468:200
                __out.Write("            }"); //469:1
                __out.AppendLine(false); //469:14
                __out.AppendLine(true); //470:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, ImmutableArray<MetaDslx.CodeAnalysis.Symbols.Symbol> candidateSymbols)"); //471:1
                __out.AppendLine(false); //471:180
                __out.Write("            {"); //472:1
                __out.AppendLine(false); //472:14
                __out.Write("                return _kind == kind && CandidateSymbols == candidateSymbols ? this :"); //473:1
                __out.AppendLine(false); //473:86
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, kind, ErrorInfo, candidateSymbols, _flags"); //474:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //474:115
                {
                    __out.Write(", this.ModelObject"); //474:172
                }
                __out.Write(");"); //474:198
                __out.AppendLine(false); //474:200
                __out.Write("            }"); //475:1
                __out.AppendLine(false); //475:14
                __out.AppendLine(true); //476:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo errorInfo, ImmutableArray<MetaDslx.CodeAnalysis.Symbols.Symbol> candidateSymbols)"); //477:1
                __out.AppendLine(false); //477:206
                __out.Write("            {"); //478:1
                __out.AppendLine(false); //478:14
                __out.Write("                return _kind == kind && ErrorInfo == errorInfo && CandidateSymbols == candidateSymbols ? this :"); //479:1
                __out.AppendLine(false); //479:112
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, kind, errorInfo, candidateSymbols, _flags"); //480:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //480:115
                {
                    __out.Write(", this.ModelObject"); //480:172
                }
                __out.Write(");"); //480:198
                __out.AppendLine(false); //480:200
                __out.Write("            }"); //481:1
                __out.AppendLine(false); //481:14
                __out.AppendLine(true); //482:1
                __out.Write("            public override string Name => _name;"); //483:1
                __out.AppendLine(false); //483:50
                __out.AppendLine(true); //484:1
                __out.Write("            public override string MetadataName => _metadataName;"); //485:1
                __out.AppendLine(false); //485:66
                __out.AppendLine(true); //486:1
                __out.Write("            public sealed override bool IsError => true;"); //487:1
                __out.AppendLine(false); //487:57
                __out.AppendLine(true); //488:1
                __out.Write("            public bool IsUnreported => _flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported);"); //489:1
                __out.AppendLine(false); //489:115
                __out.AppendLine(true); //490:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.ErrorKind ErrorKind => _kind;"); //491:1
                __out.AppendLine(false); //491:79
                __out.AppendLine(true); //492:1
                __out.Write("            public ImmutableArray<Symbol> CandidateSymbols"); //493:1
                __out.AppendLine(false); //493:59
                __out.Write("            {"); //494:1
                __out.AppendLine(false); //494:14
                __out.Write("                get"); //495:1
                __out.AppendLine(false); //495:20
                __out.Write("                {"); //496:1
                __out.AppendLine(false); //496:18
                __out.Write("                    if (_candidateSymbols.IsDefault)"); //497:1
                __out.AppendLine(false); //497:53
                __out.Write("                    {"); //498:1
                __out.AppendLine(false); //498:22
                __out.Write("                        System.Collections.Immutable.ImmutableInterlocked.InterlockedInitialize(ref _candidateSymbols, MakeCandidateSymbols());"); //499:1
                __out.AppendLine(false); //499:144
                __out.Write("                    }"); //500:1
                __out.AppendLine(false); //500:22
                __out.Write("                    return _candidateSymbols;"); //501:1
                __out.AppendLine(false); //501:46
                __out.Write("                }"); //502:1
                __out.AppendLine(false); //502:18
                __out.Write("            }"); //503:1
                __out.AppendLine(false); //503:14
                __out.AppendLine(true); //504:1
                __out.Write("            public DiagnosticInfo? ErrorInfo"); //505:1
                __out.AppendLine(false); //505:45
                __out.Write("            {"); //506:1
                __out.AppendLine(false); //506:14
                __out.Write("                get"); //507:1
                __out.AppendLine(false); //507:20
                __out.Write("                {"); //508:1
                __out.AppendLine(false); //508:18
                __out.Write("                    if (_errorInfo is null)"); //509:1
                __out.AppendLine(false); //509:44
                __out.Write("                    {"); //510:1
                __out.AppendLine(false); //510:22
                __out.Write("                        System.Threading.Interlocked.CompareExchange(ref _errorInfo, MakeErrorInfo(), null);"); //511:1
                __out.AppendLine(false); //511:109
                __out.Write("                    }"); //512:1
                __out.AppendLine(false); //512:22
                __out.Write("                    return _errorInfo;"); //513:1
                __out.AppendLine(false); //513:39
                __out.Write("                }"); //514:1
                __out.AppendLine(false); //514:18
                __out.Write("            }"); //515:1
                __out.AppendLine(false); //515:14
                __out.AppendLine(true); //516:1
                __out.Write("            protected virtual DiagnosticInfo? MakeErrorInfo()"); //517:1
                __out.AppendLine(false); //517:62
                __out.Write("            {"); //518:1
                __out.AppendLine(false); //518:14
                __out.Write("                return ErrorSymbolImplementation.MakeErrorInfo(this);"); //519:1
                __out.AppendLine(false); //519:70
                __out.Write("            }"); //520:1
                __out.AppendLine(false); //520:14
                __out.AppendLine(true); //521:1
                __out.Write("            protected virtual ImmutableArray<Symbol> MakeCandidateSymbols()"); //522:1
                __out.AppendLine(false); //522:76
                __out.Write("            {"); //523:1
                __out.AppendLine(false); //523:14
                __out.Write("                return ErrorSymbolImplementation.MakeCandidateSymbols(this);"); //524:1
                __out.AppendLine(false); //524:77
                __out.Write("            }"); //525:1
                __out.AppendLine(false); //525:14
                __out.AppendLine(true); //526:1
                __out.Write("            protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //527:1
                __out.AppendLine(false); //527:130
                __out.Write("            {"); //528:1
                __out.AppendLine(false); //528:14
                __out.Write("                return _name;"); //529:1
                __out.AppendLine(false); //529:30
                __out.Write("            }"); //530:1
                __out.AppendLine(false); //530:14
                __out.AppendLine(true); //531:1
                __out.Write("            protected override string CompleteSymbolProperty_MetadataName(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //532:1
                __out.AppendLine(false); //532:138
                __out.Write("            {"); //533:1
                __out.AppendLine(false); //533:14
                __out.Write("                return _metadataName;"); //534:1
                __out.AppendLine(false); //534:38
                __out.Write("            }"); //535:1
                __out.AppendLine(false); //535:14
                __out.Write("        }"); //536:1
                __out.AppendLine(false); //536:10
            }
            __out.Write("    }"); //538:1
            __out.AppendLine(false); //538:6
            __out.Write("}"); //539:1
            __out.AppendLine(false); //539:2
            return __out.ToStringAndFree();
        }

        public string GenerateSourceSymbol(SymbolGenerationInfo symbol) //542:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //543:1
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
            string __tmp5_line = ".Source"; //543:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //543:40
            }
            __out.Write("{"); //544:1
            __out.AppendLine(false); //544:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Source"; //545:1
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
            if (symbol.ExistingSourceTypeInfo.BaseType == null) //545:43
            {
                string __tmp11_line = " : "; //545:95
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
                string __tmp13_line = ".Completion.Completion"; //545:120
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
                if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //545:156
                {
                    string __tmp16_line = ", MetaDslx.CodeAnalysis.Symbols.Source.ISourceSymbol"; //545:226
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
                __out.AppendLine(false); //545:294
            }
            __out.Write("	{"); //546:1
            __out.AppendLine(false); //546:3
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //547:10
            {
                __out.Write("        private readonly MergedDeclaration _declaration;"); //548:1
                __out.AppendLine(false); //548:57
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetLexicalSortKey")) //549:10
                {
                    __out.Write("        private LexicalSortKey _lazyLexicalSortKey = LexicalSortKey.NotInitialized;"); //550:1
                    __out.AppendLine(false); //550:84
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //552:10
                {
                    __out.AppendLine(true); //553:1
                    bool __tmp20_outputWritten = false;
                    string __tmp21_line = "		public Source"; //554:1
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
                    string __tmp23_line = "(Symbol containingSymbol, MergedDeclaration declaration"; //554:29
                    if (!string.IsNullOrEmpty(__tmp23_line))
                    {
                        __out.Write(__tmp23_line);
                        __tmp20_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //554:85
                    {
                        string __tmp25_line = ", object? modelObject"; //554:142
                        if (!string.IsNullOrEmpty(__tmp25_line))
                        {
                            __out.Write(__tmp25_line);
                            __tmp20_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //554:164
                        {
                            string __tmp27_line = " = null"; //554:221
                            if (!string.IsNullOrEmpty(__tmp27_line))
                            {
                                __out.Write(__tmp27_line);
                                __tmp20_outputWritten = true;
                            }
                        }
                    }
                    string __tmp30_line = ", bool isError = false)"; //554:244
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Write(__tmp30_line);
                        __tmp20_outputWritten = true;
                    }
                    if (__tmp20_outputWritten) __out.AppendLine(true);
                    if (__tmp20_outputWritten)
                    {
                        __out.AppendLine(false); //554:267
                    }
                    __out.Write("            : base(containingSymbol"); //555:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //555:37
                    {
                        __out.Write(", modelObject"); //555:94
                    }
                    __out.Write(", isError)"); //555:115
                    __out.AppendLine(false); //555:125
                    __out.Write("        {"); //556:1
                    __out.AppendLine(false); //556:10
                    __out.Write("            if (declaration is null) throw new ArgumentNullException(nameof(declaration));"); //557:1
                    __out.AppendLine(false); //557:91
                    __out.Write("            _declaration = declaration;"); //558:1
                    __out.AppendLine(false); //558:40
                    __out.Write("		}"); //559:1
                    __out.AppendLine(false); //559:4
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("MergedDeclaration")) //561:10
                {
                    __out.AppendLine(true); //562:1
                    __out.Write("        public MergedDeclaration MergedDeclaration => _declaration;"); //563:1
                    __out.AppendLine(false); //563:68
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("Locations")) //565:10
                {
                    __out.AppendLine(true); //566:1
                    __out.Write("        public override ImmutableArray<Location> Locations => _declaration.NameLocations;"); //567:1
                    __out.AppendLine(false); //567:90
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("DeclaringSyntaxReferences")) //569:10
                {
                    __out.AppendLine(true); //570:1
                    __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration.SyntaxReferences;"); //571:1
                    __out.AppendLine(false); //571:116
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetBinder")) //573:10
                {
                    __out.AppendLine(true); //574:1
                    __out.Write("        public BinderPosition<SymbolBinder> GetBinder(SyntaxReference reference)"); //575:1
                    __out.AppendLine(false); //575:81
                    __out.Write("        {"); //576:1
                    __out.AppendLine(false); //576:10
                    __out.Write("            Debug.Assert(this.DeclaringSyntaxReferences.Contains(reference));"); //577:1
                    __out.AppendLine(false); //577:78
                    __out.Write("            return FindBinders.FindSymbolBinder(this, reference);"); //578:1
                    __out.AppendLine(false); //578:66
                    __out.Write("        }"); //579:1
                    __out.AppendLine(false); //579:10
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetChildSymbol")) //581:10
                {
                    __out.AppendLine(true); //582:1
                    __out.Write("        public Symbol GetChildSymbol(SyntaxReference syntax)"); //583:1
                    __out.AppendLine(false); //583:61
                    __out.Write("        {"); //584:1
                    __out.AppendLine(false); //584:10
                    __out.Write("            foreach (var child in this.ChildSymbols)"); //585:1
                    __out.AppendLine(false); //585:53
                    __out.Write("            {"); //586:1
                    __out.AppendLine(false); //586:14
                    __out.Write("                if (child.DeclaringSyntaxReferences.Any(sr => sr.GetLocation() == syntax.GetLocation()))"); //587:1
                    __out.AppendLine(false); //587:105
                    __out.Write("                {"); //588:1
                    __out.AppendLine(false); //588:18
                    __out.Write("                    return child;"); //589:1
                    __out.AppendLine(false); //589:34
                    __out.Write("                }"); //590:1
                    __out.AppendLine(false); //590:18
                    __out.Write("            }"); //591:1
                    __out.AppendLine(false); //591:14
                    __out.Write("            return null;"); //592:1
                    __out.AppendLine(false); //592:25
                    __out.Write("        }"); //593:1
                    __out.AppendLine(false); //593:10
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetLexicalSortKey")) //595:10
                {
                    __out.Write("        public override LexicalSortKey GetLexicalSortKey()"); //596:1
                    __out.AppendLine(false); //596:59
                    __out.Write("        {"); //597:1
                    __out.AppendLine(false); //597:10
                    __out.Write("            if (!_lazyLexicalSortKey.IsInitialized)"); //598:1
                    __out.AppendLine(false); //598:52
                    __out.Write("            {"); //599:1
                    __out.AppendLine(false); //599:14
                    __out.Write("                _lazyLexicalSortKey.SetFrom(this.MergedDeclaration.GetLexicalSortKey(this.DeclaringCompilation));"); //600:1
                    __out.AppendLine(false); //600:114
                    __out.Write("            }"); //601:1
                    __out.AppendLine(false); //601:14
                    __out.Write("            return _lazyLexicalSortKey;"); //602:1
                    __out.AppendLine(false); //602:40
                    __out.Write("        }"); //603:1
                    __out.AppendLine(false); //603:10
                }
            }
            __out.AppendLine(true); //606:1
            __out.Write("        protected override ISymbolImplementation SymbolImplementation => SourceSymbolImplementation.Instance;"); //607:1
            __out.AppendLine(false); //607:110
            __out.AppendLine(true); //608:1
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //609:10
            {
                bool __tmp32_outputWritten = false;
                string __tmp33_line = "        public partial class Error : Source"; //610:1
                if (!string.IsNullOrEmpty(__tmp33_line))
                {
                    __out.Write(__tmp33_line);
                    __tmp32_outputWritten = true;
                }
                var __tmp34 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp34.Write(symbol.Name);
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
                string __tmp35_line = ", MetaDslx.CodeAnalysis.Symbols.IErrorSymbol"; //610:57
                if (!string.IsNullOrEmpty(__tmp35_line))
                {
                    __out.Write(__tmp35_line);
                    __tmp32_outputWritten = true;
                }
                if (__tmp32_outputWritten) __out.AppendLine(true);
                if (__tmp32_outputWritten)
                {
                    __out.AppendLine(false); //610:101
                }
                __out.Write("        {"); //611:1
                __out.AppendLine(false); //611:10
                __out.Write("            private readonly string _name;"); //612:1
                __out.AppendLine(false); //612:43
                __out.Write("            private readonly string _metadataName;"); //613:1
                __out.AppendLine(false); //613:51
                __out.Write("            private DiagnosticInfo _errorInfo;"); //614:1
                __out.AppendLine(false); //614:47
                __out.Write("            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorKind _kind;"); //615:1
                __out.AppendLine(false); //615:76
                __out.Write("            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags _flags;"); //616:1
                __out.AppendLine(false); //616:84
                __out.Write("            private ImmutableArray<Symbol> _candidateSymbols;"); //617:1
                __out.AppendLine(false); //617:62
                __out.AppendLine(true); //618:1
                if (!symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //619:14
                {
                    __out.Write("            private Error(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags"); //620:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //620:243
                    {
                        __out.Write(", object? modelObject"); //620:300
                    }
                    __out.Write(")"); //620:329
                    __out.AppendLine(false); //620:330
                    __out.Write("                : base(container, declaration"); //621:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //621:47
                    {
                        __out.Write(", modelObject"); //621:104
                    }
                    __out.Write(", true)"); //621:125
                    __out.AppendLine(false); //621:132
                    __out.Write("            {"); //622:1
                    __out.AppendLine(false); //622:14
                    __out.Write("                Debug.Assert(!flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported) || errorInfo != null);"); //623:1
                    __out.AppendLine(false); //623:126
                    __out.Write("                _name = declaration.Name ?? string.Empty;;"); //624:1
                    __out.AppendLine(false); //624:59
                    __out.Write("                _metadataName = declaration.MetadataName ?? _name;"); //625:1
                    __out.AppendLine(false); //625:67
                    __out.Write("                _kind = kind;"); //626:1
                    __out.AppendLine(false); //626:30
                    __out.Write("                _errorInfo = errorInfo;"); //627:1
                    __out.AppendLine(false); //627:40
                    __out.Write("                _candidateSymbols = candidateSymbols;"); //628:1
                    __out.AppendLine(false); //628:54
                    __out.Write("                _flags = flags;"); //629:1
                    __out.AppendLine(false); //629:32
                    __out.Write("            }"); //630:1
                    __out.AppendLine(false); //630:14
                    __out.Write("            public Error(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported"); //632:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //632:205
                    {
                        __out.Write(", object? modelObject"); //632:262
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //632:284
                        {
                            __out.Write(" = null"); //632:341
                        }
                    }
                    __out.Write(")"); //632:364
                    __out.AppendLine(false); //632:365
                    __out.Write("                : this(container, declaration, kind, errorInfo, candidateSymbols, unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.None"); //633:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //633:208
                    {
                        __out.Write(", modelObject"); //633:265
                    }
                    __out.Write(")"); //633:286
                    __out.AppendLine(false); //633:287
                    __out.Write("            {"); //634:1
                    __out.AppendLine(false); //634:14
                    __out.Write("            }"); //635:1
                    __out.AppendLine(false); //635:14
                    __out.Write("            public Error(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported"); //637:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //637:137
                    {
                        __out.Write(", object? modelObject"); //637:194
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //637:216
                        {
                            __out.Write(" = null"); //637:273
                        }
                    }
                    __out.Write(")"); //637:296
                    __out.AppendLine(false); //637:297
                    __out.Write("                : this(wrappedSymbol.ContainingSymbol, (wrappedSymbol as ISourceSymbol).MergedDeclaration, kind, errorInfo, ImmutableArray.Create<Symbol>(wrappedSymbol), unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.UnreportedWrapped : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Wrapped"); //638:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //638:306
                    {
                        __out.Write(", modelObject is not null ? modelObject :  (wrappedSymbol as IModelSymbol)?.ModelObject"); //638:363
                    }
                    __out.Write(")"); //638:458
                    __out.AppendLine(false); //638:459
                    __out.Write("            {"); //639:1
                    __out.AppendLine(false); //639:14
                    __out.Write("            }"); //640:1
                    __out.AppendLine(false); //640:14
                    __out.AppendLine(true); //641:1
                    __out.Write("            protected virtual Error Update(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags"); //642:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //642:260
                    {
                        __out.Write(", object? modelObject"); //642:317
                    }
                    __out.Write(")"); //642:346
                    __out.AppendLine(false); //642:347
                    __out.Write("            {"); //643:1
                    __out.AppendLine(false); //643:14
                    __out.Write("                return new Error(container, declaration, kind, errorInfo, candidateSymbols, flags"); //644:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //644:99
                    {
                        __out.Write(", modelObject"); //644:156
                    }
                    __out.Write(");"); //644:177
                    __out.AppendLine(false); //644:179
                    __out.Write("            }"); //645:1
                    __out.AppendLine(false); //645:14
                }
                __out.AppendLine(true); //647:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsReported(DiagnosticInfo? errorInfo = null)"); //648:1
                __out.AppendLine(false); //648:101
                __out.Write("            {"); //649:1
                __out.AppendLine(false); //649:14
                __out.Write("                return this.IsUnreported ? this :"); //650:1
                __out.AppendLine(false); //650:50
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, _kind, errorInfo is null ? ErrorInfo : errorInfo, CandidateSymbols, _flags & ~MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported"); //651:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //651:211
                {
                    __out.Write(", this.ModelObject"); //651:268
                }
                __out.Write(");"); //651:294
                __out.AppendLine(false); //651:296
                __out.Write("            }"); //652:1
                __out.AppendLine(false); //652:14
                __out.AppendLine(true); //653:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsUnreported(DiagnosticInfo? errorInfo = null)"); //654:1
                __out.AppendLine(false); //654:103
                __out.Write("            {"); //655:1
                __out.AppendLine(false); //655:14
                __out.Write("                return this.IsUnreported ? this :"); //656:1
                __out.AppendLine(false); //656:50
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, _kind, errorInfo is null ? ErrorInfo : errorInfo, CandidateSymbols, _flags | MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported"); //657:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //657:210
                {
                    __out.Write(", this.ModelObject"); //657:267
                }
                __out.Write(");"); //657:293
                __out.AppendLine(false); //657:295
                __out.Write("            }"); //658:1
                __out.AppendLine(false); //658:14
                __out.AppendLine(true); //659:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind)"); //660:1
                __out.AppendLine(false); //660:109
                __out.Write("            {"); //661:1
                __out.AppendLine(false); //661:14
                __out.Write("                return _kind == kind ? this :"); //662:1
                __out.AppendLine(false); //662:46
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, kind, ErrorInfo, CandidateSymbols, _flags"); //663:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //663:117
                {
                    __out.Write(", this.ModelObject"); //663:174
                }
                __out.Write(");"); //663:200
                __out.AppendLine(false); //663:202
                __out.Write("            }"); //664:1
                __out.AppendLine(false); //664:14
                __out.AppendLine(true); //665:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, ImmutableArray<MetaDslx.CodeAnalysis.Symbols.Symbol> candidateSymbols)"); //666:1
                __out.AppendLine(false); //666:180
                __out.Write("            {"); //667:1
                __out.AppendLine(false); //667:14
                __out.Write("                return _kind == kind && CandidateSymbols == candidateSymbols ? this :"); //668:1
                __out.AppendLine(false); //668:86
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, kind, ErrorInfo, candidateSymbols, _flags"); //669:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //669:117
                {
                    __out.Write(", this.ModelObject"); //669:174
                }
                __out.Write(");"); //669:200
                __out.AppendLine(false); //669:202
                __out.Write("            }"); //670:1
                __out.AppendLine(false); //670:14
                __out.AppendLine(true); //671:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo errorInfo, ImmutableArray<MetaDslx.CodeAnalysis.Symbols.Symbol> candidateSymbols)"); //672:1
                __out.AppendLine(false); //672:206
                __out.Write("            {"); //673:1
                __out.AppendLine(false); //673:14
                __out.Write("                return _kind == kind && ErrorInfo == errorInfo && CandidateSymbols == candidateSymbols ? this :"); //674:1
                __out.AppendLine(false); //674:112
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, kind, errorInfo, candidateSymbols, _flags"); //675:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //675:117
                {
                    __out.Write(", this.ModelObject"); //675:174
                }
                __out.Write(");"); //675:200
                __out.AppendLine(false); //675:202
                __out.Write("            }"); //676:1
                __out.AppendLine(false); //676:14
                __out.AppendLine(true); //677:1
                __out.Write("            public override string Name => _name;"); //678:1
                __out.AppendLine(false); //678:50
                __out.AppendLine(true); //679:1
                __out.Write("            public override string MetadataName => _metadataName;"); //680:1
                __out.AppendLine(false); //680:66
                __out.AppendLine(true); //681:1
                __out.Write("            public sealed override bool IsError => true;"); //682:1
                __out.AppendLine(false); //682:57
                __out.AppendLine(true); //683:1
                __out.Write("            public bool IsUnreported => _flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported);"); //684:1
                __out.AppendLine(false); //684:115
                __out.AppendLine(true); //685:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.ErrorKind ErrorKind => _kind;"); //686:1
                __out.AppendLine(false); //686:79
                __out.AppendLine(true); //687:1
                __out.Write("            public ImmutableArray<Symbol> CandidateSymbols"); //688:1
                __out.AppendLine(false); //688:59
                __out.Write("            {"); //689:1
                __out.AppendLine(false); //689:14
                __out.Write("                get"); //690:1
                __out.AppendLine(false); //690:20
                __out.Write("                {"); //691:1
                __out.AppendLine(false); //691:18
                __out.Write("                    if (_candidateSymbols.IsDefault)"); //692:1
                __out.AppendLine(false); //692:53
                __out.Write("                    {"); //693:1
                __out.AppendLine(false); //693:22
                __out.Write("                        System.Collections.Immutable.ImmutableInterlocked.InterlockedInitialize(ref _candidateSymbols, MakeCandidateSymbols());"); //694:1
                __out.AppendLine(false); //694:144
                __out.Write("                    }"); //695:1
                __out.AppendLine(false); //695:22
                __out.Write("                    return _candidateSymbols;"); //696:1
                __out.AppendLine(false); //696:46
                __out.Write("                }"); //697:1
                __out.AppendLine(false); //697:18
                __out.Write("            }"); //698:1
                __out.AppendLine(false); //698:14
                __out.AppendLine(true); //699:1
                __out.Write("            public DiagnosticInfo? ErrorInfo"); //700:1
                __out.AppendLine(false); //700:45
                __out.Write("            {"); //701:1
                __out.AppendLine(false); //701:14
                __out.Write("                get"); //702:1
                __out.AppendLine(false); //702:20
                __out.Write("                {"); //703:1
                __out.AppendLine(false); //703:18
                __out.Write("                    if (_errorInfo is null)"); //704:1
                __out.AppendLine(false); //704:44
                __out.Write("                    {"); //705:1
                __out.AppendLine(false); //705:22
                __out.Write("                        System.Threading.Interlocked.CompareExchange(ref _errorInfo, MakeErrorInfo(), null);"); //706:1
                __out.AppendLine(false); //706:109
                __out.Write("                    }"); //707:1
                __out.AppendLine(false); //707:22
                __out.Write("                    return _errorInfo;"); //708:1
                __out.AppendLine(false); //708:39
                __out.Write("                }"); //709:1
                __out.AppendLine(false); //709:18
                __out.Write("            }"); //710:1
                __out.AppendLine(false); //710:14
                __out.AppendLine(true); //711:1
                __out.Write("            public DiagnosticInfo? UseSiteDiagnosticInfo => IsUnreported ? ErrorInfo : null;"); //712:1
                __out.AppendLine(false); //712:93
                __out.AppendLine(true); //713:1
                __out.Write("            protected virtual DiagnosticInfo? MakeErrorInfo()"); //714:1
                __out.AppendLine(false); //714:62
                __out.Write("            {"); //715:1
                __out.AppendLine(false); //715:14
                __out.Write("                return null;"); //716:1
                __out.AppendLine(false); //716:29
                __out.Write("            }"); //717:1
                __out.AppendLine(false); //717:14
                __out.AppendLine(true); //718:1
                __out.Write("            protected virtual ImmutableArray<Symbol> MakeCandidateSymbols()"); //719:1
                __out.AppendLine(false); //719:76
                __out.Write("            {"); //720:1
                __out.AppendLine(false); //720:14
                __out.Write("                return ImmutableArray<Symbol>.Empty;"); //721:1
                __out.AppendLine(false); //721:53
                __out.Write("            }"); //722:1
                __out.AppendLine(false); //722:14
                __out.AppendLine(true); //723:1
                __out.Write("            protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //724:1
                __out.AppendLine(false); //724:130
                __out.Write("            {"); //725:1
                __out.AppendLine(false); //725:14
                __out.Write("                return _name;"); //726:1
                __out.AppendLine(false); //726:30
                __out.Write("            }"); //727:1
                __out.AppendLine(false); //727:14
                __out.AppendLine(true); //728:1
                __out.Write("            protected override string CompleteSymbolProperty_MetadataName(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //729:1
                __out.AppendLine(false); //729:138
                __out.Write("            {"); //730:1
                __out.AppendLine(false); //730:14
                __out.Write("                return _metadataName;"); //731:1
                __out.AppendLine(false); //731:38
                __out.Write("            }"); //732:1
                __out.AppendLine(false); //732:14
                __out.Write("        }"); //733:1
                __out.AppendLine(false); //733:10
            }
            __out.Write("	}"); //735:1
            __out.AppendLine(false); //735:3
            __out.Write("}"); //736:1
            __out.AppendLine(false); //736:2
            return __out.ToStringAndFree();
        }

        public string GenerateWrappedSymbol(SymbolGenerationInfo symbol) //739:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //740:1
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
            string __tmp5_line = ".Wrapped"; //740:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //740:41
            }
            __out.Write("{"); //741:1
            __out.AppendLine(false); //741:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Wrapped"; //742:1
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
            string __tmp10_line = " : "; //742:43
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
            string __tmp12_line = ".Completion.Completion"; //742:68
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
                __out.AppendLine(false); //742:103
            }
            __out.Write("	{"); //743:1
            __out.AppendLine(false); //743:3
            bool __tmp15_outputWritten = false;
            string __tmp16_line = "        private readonly "; //744:1
            if (!string.IsNullOrEmpty(__tmp16_line))
            {
                __out.Write(__tmp16_line);
                __tmp15_outputWritten = true;
            }
            var __tmp17 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp17.Write(symbol.NamespaceName);
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
            string __tmp18_line = "."; //744:48
            if (!string.IsNullOrEmpty(__tmp18_line))
            {
                __out.Write(__tmp18_line);
                __tmp15_outputWritten = true;
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
                    __tmp15_outputWritten = true;
                }
                if (!__tmp19_last) __out.AppendLine(true);
            }
            string __tmp20_line = " _wrappedSymbol;"; //744:62
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Write(__tmp20_line);
                __tmp15_outputWritten = true;
            }
            if (__tmp15_outputWritten) __out.AppendLine(true);
            if (__tmp15_outputWritten)
            {
                __out.AppendLine(false); //744:78
            }
            bool __tmp22_outputWritten = false;
            string __tmp23_line = "        public Wrapped"; //746:1
            if (!string.IsNullOrEmpty(__tmp23_line))
            {
                __out.Write(__tmp23_line);
                __tmp22_outputWritten = true;
            }
            var __tmp24 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp24.Write(symbol.Name);
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
            string __tmp25_line = "("; //746:36
            if (!string.IsNullOrEmpty(__tmp25_line))
            {
                __out.Write(__tmp25_line);
                __tmp22_outputWritten = true;
            }
            var __tmp26 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp26.Write(symbol.NamespaceName);
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
            string __tmp27_line = "."; //746:59
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Write(__tmp27_line);
                __tmp22_outputWritten = true;
            }
            var __tmp28 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp28.Write(symbol.Name);
            var __tmp28Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp28.ToStringAndFree());
            bool __tmp28_last = __tmp28Reader.EndOfStream;
            while(!__tmp28_last)
            {
                ReadOnlySpan<char> __tmp28_line = __tmp28Reader.ReadLine();
                __tmp28_last = __tmp28Reader.EndOfStream;
                if (!__tmp28_last || !__tmp28_line.IsEmpty)
                {
                    __out.Write(__tmp28_line);
                    __tmp22_outputWritten = true;
                }
                if (!__tmp28_last) __out.AppendLine(true);
            }
            string __tmp29_line = " wrappedSymbol)"; //746:73
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Write(__tmp29_line);
                __tmp22_outputWritten = true;
            }
            if (__tmp22_outputWritten) __out.AppendLine(true);
            if (__tmp22_outputWritten)
            {
                __out.AppendLine(false); //746:88
            }
            __out.Write("            : base(wrappedSymbol.ContainingSymbol"); //747:1
            if (symbol.ModelObjectOption != ParameterOption.Disabled) //747:51
            {
                __out.Write(", ((IModelSymbol)wrappedSymbol).ModelObject"); //747:108
            }
            __out.Write(", wrappedSymbol.IsError)"); //747:159
            __out.AppendLine(false); //747:183
            __out.Write("        {"); //748:1
            __out.AppendLine(false); //748:10
            __out.Write("            _wrappedSymbol = wrappedSymbol;"); //749:1
            __out.AppendLine(false); //749:44
            __out.Write("        }"); //750:1
            __out.AppendLine(false); //750:10
            __out.AppendLine(true); //751:1
            __out.Write("        public override ImmutableArray<Location> Locations => _wrappedSymbol.Locations;"); //752:1
            __out.AppendLine(false); //752:88
            __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _wrappedSymbol.DeclaringSyntaxReferences;"); //753:1
            __out.AppendLine(false); //753:127
            __out.AppendLine(true); //754:1
            __out.Write("        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //755:1
            __out.AppendLine(false); //755:126
            __out.Write("        {"); //756:1
            __out.AppendLine(false); //756:10
            __out.Write("            return _wrappedSymbol.Name;"); //757:1
            __out.AppendLine(false); //757:40
            __out.Write("        }"); //758:1
            __out.AppendLine(false); //758:10
            __out.AppendLine(true); //759:1
            __out.Write("        protected override string CompleteSymbolProperty_MetadataName(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //760:1
            __out.AppendLine(false); //760:134
            __out.Write("        {"); //761:1
            __out.AppendLine(false); //761:10
            __out.Write("            return _wrappedSymbol.MetadataName;"); //762:1
            __out.AppendLine(false); //762:48
            __out.Write("        }"); //763:1
            __out.AppendLine(false); //763:10
            __out.AppendLine(true); //764:1
            __out.Write("        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //765:1
            __out.AppendLine(false); //765:123
            __out.Write("        {"); //766:1
            __out.AppendLine(false); //766:10
            __out.Write("            _wrappedSymbol.CompleteInitializingSymbol(diagnostics, cancellationToken);"); //767:1
            __out.AppendLine(false); //767:87
            __out.Write("        }"); //768:1
            __out.AppendLine(false); //768:10
            __out.AppendLine(true); //769:1
            __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //770:1
            __out.AppendLine(false); //770:143
            __out.Write("        {"); //771:1
            __out.AppendLine(false); //771:10
            __out.Write("            return _wrappedSymbol.CompleteCreatingChildSymbols(diagnostics, cancellationToken);"); //772:1
            __out.AppendLine(false); //772:96
            __out.Write("        }"); //773:1
            __out.AppendLine(false); //773:10
            __out.AppendLine(true); //774:1
            __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //775:1
            __out.AppendLine(false); //775:140
            __out.Write("        {"); //776:1
            __out.AppendLine(false); //776:10
            __out.Write("            _wrappedSymbol.CompleteImports(locationOpt, diagnostics, cancellationToken);"); //777:1
            __out.AppendLine(false); //777:89
            __out.Write("        }"); //778:1
            __out.AppendLine(false); //778:10
            var __loop9_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //779:16
                where part.GenerateCompleteMethod //779:44
                select new { part = part}
                ).ToList(); //779:10
            for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
            {
                var __tmp30 = __loop9_results[__loop9_iteration];
                var part = __tmp30.part;
                __out.AppendLine(true); //780:1
                bool __tmp32_outputWritten = false;
                string __tmp33_line = "        protected override "; //781:1
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
                string __tmp35_line = " "; //781:59
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
                string __tmp37_line = "("; //781:85
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
                string __tmp39_line = ")"; //781:116
                if (!string.IsNullOrEmpty(__tmp39_line))
                {
                    __out.Write(__tmp39_line);
                    __tmp32_outputWritten = true;
                }
                if (__tmp32_outputWritten) __out.AppendLine(true);
                if (__tmp32_outputWritten)
                {
                    __out.AppendLine(false); //781:117
                }
                __out.Write("        {"); //782:1
                __out.AppendLine(false); //782:10
                bool __tmp41_outputWritten = false;
                string __tmp40Prefix = "            "; //783:1
                if (part.CompleteMethodReturnType != "void") //783:14
                {
                    if (!string.IsNullOrEmpty(__tmp40Prefix))
                    {
                        __out.Write(__tmp40Prefix);
                        __tmp41_outputWritten = true;
                    }
                    string __tmp43_line = "return "; //783:59
                    if (!string.IsNullOrEmpty(__tmp43_line))
                    {
                        __out.Write(__tmp43_line);
                        __tmp41_outputWritten = true;
                    }
                }
                string __tmp45_line = "_wrappedSymbol."; //783:74
                if (!string.IsNullOrEmpty(__tmp45_line))
                {
                    __out.Write(__tmp45_line);
                    __tmp41_outputWritten = true;
                }
                var __tmp46 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp46.Write(part.CompleteMethodName);
                var __tmp46Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp46.ToStringAndFree());
                bool __tmp46_last = __tmp46Reader.EndOfStream;
                while(!__tmp46_last)
                {
                    ReadOnlySpan<char> __tmp46_line = __tmp46Reader.ReadLine();
                    __tmp46_last = __tmp46Reader.EndOfStream;
                    if (!__tmp46_last || !__tmp46_line.IsEmpty)
                    {
                        __out.Write(__tmp46_line);
                        __tmp41_outputWritten = true;
                    }
                    if (!__tmp46_last) __out.AppendLine(true);
                }
                string __tmp47_line = "("; //783:114
                if (!string.IsNullOrEmpty(__tmp47_line))
                {
                    __out.Write(__tmp47_line);
                    __tmp41_outputWritten = true;
                }
                var __tmp48 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp48.Write(part.CompleteMethodArgList);
                var __tmp48Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp48.ToStringAndFree());
                bool __tmp48_last = __tmp48Reader.EndOfStream;
                while(!__tmp48_last)
                {
                    ReadOnlySpan<char> __tmp48_line = __tmp48Reader.ReadLine();
                    __tmp48_last = __tmp48Reader.EndOfStream;
                    if (!__tmp48_last || !__tmp48_line.IsEmpty)
                    {
                        __out.Write(__tmp48_line);
                        __tmp41_outputWritten = true;
                    }
                    if (!__tmp48_last) __out.AppendLine(true);
                }
                string __tmp49_line = ");"; //783:143
                if (!string.IsNullOrEmpty(__tmp49_line))
                {
                    __out.Write(__tmp49_line);
                    __tmp41_outputWritten = true;
                }
                if (__tmp41_outputWritten) __out.AppendLine(true);
                if (__tmp41_outputWritten)
                {
                    __out.AppendLine(false); //783:145
                }
                __out.Write("        }"); //784:1
                __out.AppendLine(false); //784:10
            }
            __out.AppendLine(true); //786:1
            __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //787:1
            __out.AppendLine(false); //787:152
            __out.Write("        {"); //788:1
            __out.AppendLine(false); //788:10
            __out.Write("            _wrappedSymbol.CompleteNonSymbolProperties(locationOpt, diagnostics, cancellationToken);"); //789:1
            __out.AppendLine(false); //789:101
            __out.Write("        }"); //790:1
            __out.AppendLine(false); //790:10
            __out.Write("    }"); //791:1
            __out.AppendLine(false); //791:6
            __out.Write("}"); //792:1
            __out.AppendLine(false); //792:2
            return __out.ToStringAndFree();
        }

        public string GenerateVisitor(string namespaceName, IEnumerable<SymbolGenerationInfo> symbols) //795:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //796:1
            __out.AppendLine(false); //796:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //797:1
            __out.AppendLine(false); //797:29
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //798:1
            __out.AppendLine(false); //798:37
            __out.Write("using System;"); //799:1
            __out.AppendLine(false); //799:14
            __out.Write("using System.Collections.Generic;"); //800:1
            __out.AppendLine(false); //800:34
            __out.Write("using System.Collections.Immutable;"); //801:1
            __out.AppendLine(false); //801:36
            __out.Write("using System.Diagnostics;"); //802:1
            __out.AppendLine(false); //802:26
            __out.Write("using System.Text;"); //803:1
            __out.AppendLine(false); //803:19
            __out.Write("using System.Threading;"); //804:1
            __out.AppendLine(false); //804:24
            __out.AppendLine(true); //805:1
            __out.Write("#nullable enable"); //806:1
            __out.AppendLine(false); //806:17
            __out.AppendLine(true); //807:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //808:1
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
                __out.AppendLine(false); //808:26
            }
            __out.Write("{"); //809:1
            __out.AppendLine(false); //809:2
            __out.Write("	public interface ISymbolVisitor"); //810:1
            __out.AppendLine(false); //810:33
            __out.Write("	{"); //811:1
            __out.AppendLine(false); //811:3
            var __loop10_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //812:16
                where !symbol.IsAbstract //812:32
                select new { symbol = symbol}
                ).ToList(); //812:10
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                var __tmp5 = __loop10_results[__loop10_iteration];
                var symbol = __tmp5.symbol;
                bool __tmp7_outputWritten = false;
                string __tmp8_line = "        void Visit("; //813:1
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
                string __tmp10_line = " symbol);"; //813:33
                if (!string.IsNullOrEmpty(__tmp10_line))
                {
                    __out.Write(__tmp10_line);
                    __tmp7_outputWritten = true;
                }
                if (__tmp7_outputWritten) __out.AppendLine(true);
                if (__tmp7_outputWritten)
                {
                    __out.AppendLine(false); //813:42
                }
            }
            __out.Write("	}"); //815:1
            __out.AppendLine(false); //815:3
            __out.AppendLine(true); //816:1
            __out.Write("	public interface ISymbolVisitor<TResult>"); //817:1
            __out.AppendLine(false); //817:42
            __out.Write("	{"); //818:1
            __out.AppendLine(false); //818:3
            var __loop11_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //819:16
                where !symbol.IsAbstract //819:32
                select new { symbol = symbol}
                ).ToList(); //819:10
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp11 = __loop11_results[__loop11_iteration];
                var symbol = __tmp11.symbol;
                bool __tmp13_outputWritten = false;
                string __tmp14_line = "        TResult Visit("; //820:1
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
                string __tmp16_line = " symbol);"; //820:36
                if (!string.IsNullOrEmpty(__tmp16_line))
                {
                    __out.Write(__tmp16_line);
                    __tmp13_outputWritten = true;
                }
                if (__tmp13_outputWritten) __out.AppendLine(true);
                if (__tmp13_outputWritten)
                {
                    __out.AppendLine(false); //820:45
                }
            }
            __out.Write("	}"); //822:1
            __out.AppendLine(false); //822:3
            __out.AppendLine(true); //823:1
            __out.Write("	public interface ISymbolVisitor<TArgument, TResult>"); //824:1
            __out.AppendLine(false); //824:53
            __out.Write("	{"); //825:1
            __out.AppendLine(false); //825:3
            var __loop12_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //826:16
                where !symbol.IsAbstract //826:32
                select new { symbol = symbol}
                ).ToList(); //826:10
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp17 = __loop12_results[__loop12_iteration];
                var symbol = __tmp17.symbol;
                bool __tmp19_outputWritten = false;
                string __tmp20_line = "        TResult Visit("; //827:1
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
                string __tmp22_line = " symbol, TArgument argument);"; //827:36
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Write(__tmp22_line);
                    __tmp19_outputWritten = true;
                }
                if (__tmp19_outputWritten) __out.AppendLine(true);
                if (__tmp19_outputWritten)
                {
                    __out.AppendLine(false); //827:65
                }
            }
            __out.Write("	}"); //829:1
            __out.AppendLine(false); //829:3
            __out.Write("}"); //830:1
            __out.AppendLine(false); //830:2
            return __out.ToStringAndFree();
        }

        public string GenerateFactory(string namespaceName, IEnumerable<SymbolGenerationInfo> symbols) //833:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //834:1
            __out.AppendLine(false); //834:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //835:1
            __out.AppendLine(false); //835:29
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //836:1
            __out.AppendLine(false); //836:37
            __out.Write("using System;"); //837:1
            __out.AppendLine(false); //837:14
            __out.Write("using System.Collections.Generic;"); //838:1
            __out.AppendLine(false); //838:34
            __out.Write("using System.Collections.Immutable;"); //839:1
            __out.AppendLine(false); //839:36
            __out.Write("using System.Diagnostics;"); //840:1
            __out.AppendLine(false); //840:26
            __out.Write("using System.Text;"); //841:1
            __out.AppendLine(false); //841:19
            __out.Write("using System.Threading;"); //842:1
            __out.AppendLine(false); //842:24
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //843:1
            __out.AppendLine(false); //843:42
            __out.AppendLine(true); //844:1
            __out.Write("#nullable enable"); //845:1
            __out.AppendLine(false); //845:17
            __out.AppendLine(true); //846:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //847:1
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
                if (!__tmp4_last) __out.AppendLine(true);
            }
            string __tmp5_line = ".Factory"; //847:26
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //847:34
            }
            __out.Write("{"); //848:1
            __out.AppendLine(false); //848:2
            var __loop13_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //849:12
                where !symbol.IsAbstract && symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol" && symbol.SymbolParts != SymbolParts.None //849:28
                select new { symbol = symbol}
                ).ToList(); //849:6
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp6 = __loop13_results[__loop13_iteration];
                var symbol = __tmp6.symbol;
                bool __tmp8_outputWritten = false;
                string __tmp9_line = "	public class "; //850:1
                if (!string.IsNullOrEmpty(__tmp9_line))
                {
                    __out.Write(__tmp9_line);
                    __tmp8_outputWritten = true;
                }
                var __tmp10 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp10.Write(symbol.Name);
                var __tmp10Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp10.ToStringAndFree());
                bool __tmp10_last = __tmp10Reader.EndOfStream;
                while(!__tmp10_last)
                {
                    ReadOnlySpan<char> __tmp10_line = __tmp10Reader.ReadLine();
                    __tmp10_last = __tmp10Reader.EndOfStream;
                    if (!__tmp10_last || !__tmp10_line.IsEmpty)
                    {
                        __out.Write(__tmp10_line);
                        __tmp8_outputWritten = true;
                    }
                    if (!__tmp10_last) __out.AppendLine(true);
                }
                string __tmp11_line = "Factory : IGeneratedSymbolFactory"; //850:28
                if (!string.IsNullOrEmpty(__tmp11_line))
                {
                    __out.Write(__tmp11_line);
                    __tmp8_outputWritten = true;
                }
                if (__tmp8_outputWritten) __out.AppendLine(true);
                if (__tmp8_outputWritten)
                {
                    __out.AppendLine(false); //850:61
                }
                __out.Write("	{"); //851:1
                __out.AppendLine(false); //851:3
                __out.Write("        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)"); //852:1
                __out.AppendLine(false); //852:83
                __out.Write("        {"); //853:1
                __out.AppendLine(false); //853:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Metadata)) //854:14
                {
                    bool __tmp13_outputWritten = false;
                    string __tmp14_line = "            throw new NotImplementedException(\"There is no Metadata"; //855:1
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
                    string __tmp16_line = " implemented.\");"; //855:81
                    if (!string.IsNullOrEmpty(__tmp16_line))
                    {
                        __out.Write(__tmp16_line);
                        __tmp13_outputWritten = true;
                    }
                    if (__tmp13_outputWritten) __out.AppendLine(true);
                    if (__tmp13_outputWritten)
                    {
                        __out.AppendLine(false); //855:97
                    }
                }
                else if (symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //856:14
                {
                    bool __tmp18_outputWritten = false;
                    string __tmp19_line = "            throw new NotImplementedException(\"CreateMetadataSymbol for Metadata"; //857:1
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
                    string __tmp21_line = " should be implemented in a custom SymbolFactory.\");"; //857:94
                    if (!string.IsNullOrEmpty(__tmp21_line))
                    {
                        __out.Write(__tmp21_line);
                        __tmp18_outputWritten = true;
                    }
                    if (__tmp18_outputWritten) __out.AppendLine(true);
                    if (__tmp18_outputWritten)
                    {
                        __out.AppendLine(false); //857:146
                    }
                }
                else //858:14
                {
                    bool __tmp23_outputWritten = false;
                    string __tmp24_line = "            return new Metadata.Metadata"; //859:1
                    if (!string.IsNullOrEmpty(__tmp24_line))
                    {
                        __out.Write(__tmp24_line);
                        __tmp23_outputWritten = true;
                    }
                    var __tmp25 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp25.Write(symbol.Name);
                    var __tmp25Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp25.ToStringAndFree());
                    bool __tmp25_last = __tmp25Reader.EndOfStream;
                    while(!__tmp25_last)
                    {
                        ReadOnlySpan<char> __tmp25_line = __tmp25Reader.ReadLine();
                        __tmp25_last = __tmp25Reader.EndOfStream;
                        if (!__tmp25_last || !__tmp25_line.IsEmpty)
                        {
                            __out.Write(__tmp25_line);
                            __tmp23_outputWritten = true;
                        }
                        if (!__tmp25_last) __out.AppendLine(true);
                    }
                    string __tmp26_line = "(container"; //859:54
                    if (!string.IsNullOrEmpty(__tmp26_line))
                    {
                        __out.Write(__tmp26_line);
                        __tmp23_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //859:65
                    {
                        string __tmp28_line = ", modelObject"; //859:122
                        if (!string.IsNullOrEmpty(__tmp28_line))
                        {
                            __out.Write(__tmp28_line);
                            __tmp23_outputWritten = true;
                        }
                    }
                    string __tmp30_line = ");"; //859:143
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Write(__tmp30_line);
                        __tmp23_outputWritten = true;
                    }
                    if (__tmp23_outputWritten) __out.AppendLine(true);
                    if (__tmp23_outputWritten)
                    {
                        __out.AppendLine(false); //859:145
                    }
                }
                __out.Write("        }"); //861:1
                __out.AppendLine(false); //861:10
                __out.AppendLine(true); //862:1
                __out.Write("        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)"); //863:1
                __out.AppendLine(false); //863:253
                __out.Write("        {"); //864:1
                __out.AppendLine(false); //864:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Metadata)) //865:14
                {
                    bool __tmp32_outputWritten = false;
                    string __tmp33_line = "            throw new NotImplementedException(\"There is no Metadata"; //866:1
                    if (!string.IsNullOrEmpty(__tmp33_line))
                    {
                        __out.Write(__tmp33_line);
                        __tmp32_outputWritten = true;
                    }
                    var __tmp34 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp34.Write(symbol.Name);
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
                    string __tmp35_line = " implemented.\");"; //866:81
                    if (!string.IsNullOrEmpty(__tmp35_line))
                    {
                        __out.Write(__tmp35_line);
                        __tmp32_outputWritten = true;
                    }
                    if (__tmp32_outputWritten) __out.AppendLine(true);
                    if (__tmp32_outputWritten)
                    {
                        __out.AppendLine(false); //866:97
                    }
                }
                else if (symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //867:14
                {
                    bool __tmp37_outputWritten = false;
                    string __tmp38_line = "            throw new NotImplementedException(\"CreateMetadataSymbol for Metadata"; //868:1
                    if (!string.IsNullOrEmpty(__tmp38_line))
                    {
                        __out.Write(__tmp38_line);
                        __tmp37_outputWritten = true;
                    }
                    var __tmp39 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp39.Write(symbol.Name);
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
                    string __tmp40_line = " should be implemented in a custom SymbolFactory.\");"; //868:94
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Write(__tmp40_line);
                        __tmp37_outputWritten = true;
                    }
                    if (__tmp37_outputWritten) __out.AppendLine(true);
                    if (__tmp37_outputWritten)
                    {
                        __out.AppendLine(false); //868:146
                    }
                }
                else //869:14
                {
                    bool __tmp42_outputWritten = false;
                    string __tmp43_line = "            return new Metadata.Metadata"; //870:1
                    if (!string.IsNullOrEmpty(__tmp43_line))
                    {
                        __out.Write(__tmp43_line);
                        __tmp42_outputWritten = true;
                    }
                    var __tmp44 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp44.Write(symbol.Name);
                    var __tmp44Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp44.ToStringAndFree());
                    bool __tmp44_last = __tmp44Reader.EndOfStream;
                    while(!__tmp44_last)
                    {
                        ReadOnlySpan<char> __tmp44_line = __tmp44Reader.ReadLine();
                        __tmp44_last = __tmp44Reader.EndOfStream;
                        if (!__tmp44_last || !__tmp44_line.IsEmpty)
                        {
                            __out.Write(__tmp44_line);
                            __tmp42_outputWritten = true;
                        }
                        if (!__tmp44_last) __out.AppendLine(true);
                    }
                    string __tmp45_line = ".Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported"; //870:54
                    if (!string.IsNullOrEmpty(__tmp45_line))
                    {
                        __out.Write(__tmp45_line);
                        __tmp42_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //870:138
                    {
                        string __tmp47_line = ", modelObject"; //870:195
                        if (!string.IsNullOrEmpty(__tmp47_line))
                        {
                            __out.Write(__tmp47_line);
                            __tmp42_outputWritten = true;
                        }
                    }
                    string __tmp49_line = ");"; //870:216
                    if (!string.IsNullOrEmpty(__tmp49_line))
                    {
                        __out.Write(__tmp49_line);
                        __tmp42_outputWritten = true;
                    }
                    if (__tmp42_outputWritten) __out.AppendLine(true);
                    if (__tmp42_outputWritten)
                    {
                        __out.AppendLine(false); //870:218
                    }
                }
                __out.Write("        }"); //872:1
                __out.AppendLine(false); //872:10
                __out.AppendLine(true); //873:1
                __out.Write("        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)"); //874:1
                __out.AppendLine(false); //874:182
                __out.Write("        {"); //875:1
                __out.AppendLine(false); //875:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Metadata)) //876:14
                {
                    bool __tmp51_outputWritten = false;
                    string __tmp52_line = "            throw new NotImplementedException(\"There is no Metadata"; //877:1
                    if (!string.IsNullOrEmpty(__tmp52_line))
                    {
                        __out.Write(__tmp52_line);
                        __tmp51_outputWritten = true;
                    }
                    var __tmp53 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp53.Write(symbol.Name);
                    var __tmp53Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp53.ToStringAndFree());
                    bool __tmp53_last = __tmp53Reader.EndOfStream;
                    while(!__tmp53_last)
                    {
                        ReadOnlySpan<char> __tmp53_line = __tmp53Reader.ReadLine();
                        __tmp53_last = __tmp53Reader.EndOfStream;
                        if (!__tmp53_last || !__tmp53_line.IsEmpty)
                        {
                            __out.Write(__tmp53_line);
                            __tmp51_outputWritten = true;
                        }
                        if (!__tmp53_last) __out.AppendLine(true);
                    }
                    string __tmp54_line = " implemented.\");"; //877:81
                    if (!string.IsNullOrEmpty(__tmp54_line))
                    {
                        __out.Write(__tmp54_line);
                        __tmp51_outputWritten = true;
                    }
                    if (__tmp51_outputWritten) __out.AppendLine(true);
                    if (__tmp51_outputWritten)
                    {
                        __out.AppendLine(false); //877:97
                    }
                }
                else if (symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //878:14
                {
                    bool __tmp56_outputWritten = false;
                    string __tmp57_line = "            throw new NotImplementedException(\"CreateMetadataSymbol for Metadata"; //879:1
                    if (!string.IsNullOrEmpty(__tmp57_line))
                    {
                        __out.Write(__tmp57_line);
                        __tmp56_outputWritten = true;
                    }
                    var __tmp58 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp58.Write(symbol.Name);
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
                    string __tmp59_line = " should be implemented in a custom SymbolFactory.\");"; //879:94
                    if (!string.IsNullOrEmpty(__tmp59_line))
                    {
                        __out.Write(__tmp59_line);
                        __tmp56_outputWritten = true;
                    }
                    if (__tmp56_outputWritten) __out.AppendLine(true);
                    if (__tmp56_outputWritten)
                    {
                        __out.AppendLine(false); //879:146
                    }
                }
                else //880:14
                {
                    bool __tmp61_outputWritten = false;
                    string __tmp62_line = "            return new Metadata.Metadata"; //881:1
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
                    string __tmp64_line = ".Error(wrappedSymbol, kind, errorInfo, unreported"; //881:54
                    if (!string.IsNullOrEmpty(__tmp64_line))
                    {
                        __out.Write(__tmp64_line);
                        __tmp61_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //881:104
                    {
                        string __tmp66_line = ", modelObject"; //881:161
                        if (!string.IsNullOrEmpty(__tmp66_line))
                        {
                            __out.Write(__tmp66_line);
                            __tmp61_outputWritten = true;
                        }
                    }
                    string __tmp68_line = ");"; //881:182
                    if (!string.IsNullOrEmpty(__tmp68_line))
                    {
                        __out.Write(__tmp68_line);
                        __tmp61_outputWritten = true;
                    }
                    if (__tmp61_outputWritten) __out.AppendLine(true);
                    if (__tmp61_outputWritten)
                    {
                        __out.AppendLine(false); //881:184
                    }
                }
                __out.Write("        }"); //883:1
                __out.AppendLine(false); //883:10
                __out.AppendLine(true); //884:1
                __out.Write("        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)"); //885:1
                __out.AppendLine(false); //885:112
                __out.Write("        {"); //886:1
                __out.AppendLine(false); //886:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Source)) //887:14
                {
                    bool __tmp70_outputWritten = false;
                    string __tmp71_line = "            throw new NotImplementedException(\"There is no Source"; //888:1
                    if (!string.IsNullOrEmpty(__tmp71_line))
                    {
                        __out.Write(__tmp71_line);
                        __tmp70_outputWritten = true;
                    }
                    var __tmp72 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp72.Write(symbol.Name);
                    var __tmp72Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp72.ToStringAndFree());
                    bool __tmp72_last = __tmp72Reader.EndOfStream;
                    while(!__tmp72_last)
                    {
                        ReadOnlySpan<char> __tmp72_line = __tmp72Reader.ReadLine();
                        __tmp72_last = __tmp72Reader.EndOfStream;
                        if (!__tmp72_last || !__tmp72_line.IsEmpty)
                        {
                            __out.Write(__tmp72_line);
                            __tmp70_outputWritten = true;
                        }
                        if (!__tmp72_last) __out.AppendLine(true);
                    }
                    string __tmp73_line = " implemented.\");"; //888:79
                    if (!string.IsNullOrEmpty(__tmp73_line))
                    {
                        __out.Write(__tmp73_line);
                        __tmp70_outputWritten = true;
                    }
                    if (__tmp70_outputWritten) __out.AppendLine(true);
                    if (__tmp70_outputWritten)
                    {
                        __out.AppendLine(false); //888:95
                    }
                }
                else if (symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //889:14
                {
                    bool __tmp75_outputWritten = false;
                    string __tmp76_line = "            throw new NotImplementedException(\"CreateSourceSymbol for Source"; //890:1
                    if (!string.IsNullOrEmpty(__tmp76_line))
                    {
                        __out.Write(__tmp76_line);
                        __tmp75_outputWritten = true;
                    }
                    var __tmp77 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp77.Write(symbol.Name);
                    var __tmp77Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp77.ToStringAndFree());
                    bool __tmp77_last = __tmp77Reader.EndOfStream;
                    while(!__tmp77_last)
                    {
                        ReadOnlySpan<char> __tmp77_line = __tmp77Reader.ReadLine();
                        __tmp77_last = __tmp77Reader.EndOfStream;
                        if (!__tmp77_last || !__tmp77_line.IsEmpty)
                        {
                            __out.Write(__tmp77_line);
                            __tmp75_outputWritten = true;
                        }
                        if (!__tmp77_last) __out.AppendLine(true);
                    }
                    string __tmp78_line = " should be implemented in a custom SymbolFactory.\");"; //890:90
                    if (!string.IsNullOrEmpty(__tmp78_line))
                    {
                        __out.Write(__tmp78_line);
                        __tmp75_outputWritten = true;
                    }
                    if (__tmp75_outputWritten) __out.AppendLine(true);
                    if (__tmp75_outputWritten)
                    {
                        __out.AppendLine(false); //890:142
                    }
                }
                else //891:14
                {
                    bool __tmp80_outputWritten = false;
                    string __tmp81_line = "            return new Source.Source"; //892:1
                    if (!string.IsNullOrEmpty(__tmp81_line))
                    {
                        __out.Write(__tmp81_line);
                        __tmp80_outputWritten = true;
                    }
                    var __tmp82 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp82.Write(symbol.Name);
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
                    string __tmp83_line = "(container, declaration"; //892:50
                    if (!string.IsNullOrEmpty(__tmp83_line))
                    {
                        __out.Write(__tmp83_line);
                        __tmp80_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //892:74
                    {
                        string __tmp85_line = ", modelObject"; //892:131
                        if (!string.IsNullOrEmpty(__tmp85_line))
                        {
                            __out.Write(__tmp85_line);
                            __tmp80_outputWritten = true;
                        }
                    }
                    string __tmp87_line = ");"; //892:152
                    if (!string.IsNullOrEmpty(__tmp87_line))
                    {
                        __out.Write(__tmp87_line);
                        __tmp80_outputWritten = true;
                    }
                    if (__tmp80_outputWritten) __out.AppendLine(true);
                    if (__tmp80_outputWritten)
                    {
                        __out.AppendLine(false); //892:154
                    }
                }
                __out.Write("        }"); //894:1
                __out.AppendLine(false); //894:10
                __out.AppendLine(true); //895:1
                __out.Write("        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)"); //896:1
                __out.AppendLine(false); //896:248
                __out.Write("        {"); //897:1
                __out.AppendLine(false); //897:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Source)) //898:14
                {
                    bool __tmp89_outputWritten = false;
                    string __tmp90_line = "            throw new NotImplementedException(\"There is no Source"; //899:1
                    if (!string.IsNullOrEmpty(__tmp90_line))
                    {
                        __out.Write(__tmp90_line);
                        __tmp89_outputWritten = true;
                    }
                    var __tmp91 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp91.Write(symbol.Name);
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
                    string __tmp92_line = " implemented.\");"; //899:79
                    if (!string.IsNullOrEmpty(__tmp92_line))
                    {
                        __out.Write(__tmp92_line);
                        __tmp89_outputWritten = true;
                    }
                    if (__tmp89_outputWritten) __out.AppendLine(true);
                    if (__tmp89_outputWritten)
                    {
                        __out.AppendLine(false); //899:95
                    }
                }
                else if (symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //900:14
                {
                    bool __tmp94_outputWritten = false;
                    string __tmp95_line = "            throw new NotImplementedException(\"CreateSourceSymbol for Source"; //901:1
                    if (!string.IsNullOrEmpty(__tmp95_line))
                    {
                        __out.Write(__tmp95_line);
                        __tmp94_outputWritten = true;
                    }
                    var __tmp96 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp96.Write(symbol.Name);
                    var __tmp96Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp96.ToStringAndFree());
                    bool __tmp96_last = __tmp96Reader.EndOfStream;
                    while(!__tmp96_last)
                    {
                        ReadOnlySpan<char> __tmp96_line = __tmp96Reader.ReadLine();
                        __tmp96_last = __tmp96Reader.EndOfStream;
                        if (!__tmp96_last || !__tmp96_line.IsEmpty)
                        {
                            __out.Write(__tmp96_line);
                            __tmp94_outputWritten = true;
                        }
                        if (!__tmp96_last) __out.AppendLine(true);
                    }
                    string __tmp97_line = " should be implemented in a custom SymbolFactory.\");"; //901:90
                    if (!string.IsNullOrEmpty(__tmp97_line))
                    {
                        __out.Write(__tmp97_line);
                        __tmp94_outputWritten = true;
                    }
                    if (__tmp94_outputWritten) __out.AppendLine(true);
                    if (__tmp94_outputWritten)
                    {
                        __out.AppendLine(false); //901:142
                    }
                }
                else //902:14
                {
                    bool __tmp99_outputWritten = false;
                    string __tmp100_line = "            return new Source.Source"; //903:1
                    if (!string.IsNullOrEmpty(__tmp100_line))
                    {
                        __out.Write(__tmp100_line);
                        __tmp99_outputWritten = true;
                    }
                    var __tmp101 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp101.Write(symbol.Name);
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
                    string __tmp102_line = ".Error(container, declaration, kind, errorInfo, candidateSymbols, unreported"; //903:50
                    if (!string.IsNullOrEmpty(__tmp102_line))
                    {
                        __out.Write(__tmp102_line);
                        __tmp99_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //903:127
                    {
                        string __tmp104_line = ", modelObject"; //903:184
                        if (!string.IsNullOrEmpty(__tmp104_line))
                        {
                            __out.Write(__tmp104_line);
                            __tmp99_outputWritten = true;
                        }
                    }
                    string __tmp106_line = ");"; //903:205
                    if (!string.IsNullOrEmpty(__tmp106_line))
                    {
                        __out.Write(__tmp106_line);
                        __tmp99_outputWritten = true;
                    }
                    if (__tmp99_outputWritten) __out.AppendLine(true);
                    if (__tmp99_outputWritten)
                    {
                        __out.AppendLine(false); //903:207
                    }
                }
                __out.Write("        }"); //905:1
                __out.AppendLine(false); //905:10
                __out.AppendLine(true); //906:1
                __out.Write("        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)"); //907:1
                __out.AppendLine(false); //907:180
                __out.Write("        {"); //908:1
                __out.AppendLine(false); //908:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Source)) //909:14
                {
                    bool __tmp108_outputWritten = false;
                    string __tmp109_line = "            throw new NotImplementedException(\"There is no Source"; //910:1
                    if (!string.IsNullOrEmpty(__tmp109_line))
                    {
                        __out.Write(__tmp109_line);
                        __tmp108_outputWritten = true;
                    }
                    var __tmp110 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp110.Write(symbol.Name);
                    var __tmp110Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp110.ToStringAndFree());
                    bool __tmp110_last = __tmp110Reader.EndOfStream;
                    while(!__tmp110_last)
                    {
                        ReadOnlySpan<char> __tmp110_line = __tmp110Reader.ReadLine();
                        __tmp110_last = __tmp110Reader.EndOfStream;
                        if (!__tmp110_last || !__tmp110_line.IsEmpty)
                        {
                            __out.Write(__tmp110_line);
                            __tmp108_outputWritten = true;
                        }
                        if (!__tmp110_last) __out.AppendLine(true);
                    }
                    string __tmp111_line = " implemented.\");"; //910:79
                    if (!string.IsNullOrEmpty(__tmp111_line))
                    {
                        __out.Write(__tmp111_line);
                        __tmp108_outputWritten = true;
                    }
                    if (__tmp108_outputWritten) __out.AppendLine(true);
                    if (__tmp108_outputWritten)
                    {
                        __out.AppendLine(false); //910:95
                    }
                }
                else if (symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //911:14
                {
                    bool __tmp113_outputWritten = false;
                    string __tmp114_line = "            throw new NotImplementedException(\"CreateSourceSymbol for Source"; //912:1
                    if (!string.IsNullOrEmpty(__tmp114_line))
                    {
                        __out.Write(__tmp114_line);
                        __tmp113_outputWritten = true;
                    }
                    var __tmp115 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp115.Write(symbol.Name);
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
                    string __tmp116_line = " should be implemented in a custom SymbolFactory.\");"; //912:90
                    if (!string.IsNullOrEmpty(__tmp116_line))
                    {
                        __out.Write(__tmp116_line);
                        __tmp113_outputWritten = true;
                    }
                    if (__tmp113_outputWritten) __out.AppendLine(true);
                    if (__tmp113_outputWritten)
                    {
                        __out.AppendLine(false); //912:142
                    }
                }
                else //913:14
                {
                    bool __tmp118_outputWritten = false;
                    string __tmp119_line = "            return new Source.Source"; //914:1
                    if (!string.IsNullOrEmpty(__tmp119_line))
                    {
                        __out.Write(__tmp119_line);
                        __tmp118_outputWritten = true;
                    }
                    var __tmp120 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp120.Write(symbol.Name);
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
                    string __tmp121_line = ".Error(wrappedSymbol, kind, errorInfo, unreported"; //914:50
                    if (!string.IsNullOrEmpty(__tmp121_line))
                    {
                        __out.Write(__tmp121_line);
                        __tmp118_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //914:100
                    {
                        string __tmp123_line = ", modelObject"; //914:157
                        if (!string.IsNullOrEmpty(__tmp123_line))
                        {
                            __out.Write(__tmp123_line);
                            __tmp118_outputWritten = true;
                        }
                    }
                    string __tmp125_line = ");"; //914:178
                    if (!string.IsNullOrEmpty(__tmp125_line))
                    {
                        __out.Write(__tmp125_line);
                        __tmp118_outputWritten = true;
                    }
                    if (__tmp118_outputWritten) __out.AppendLine(true);
                    if (__tmp118_outputWritten)
                    {
                        __out.AppendLine(false); //914:180
                    }
                }
                __out.Write("        }"); //916:1
                __out.AppendLine(false); //916:10
                __out.Write("	}"); //917:1
                __out.AppendLine(false); //917:3
                __out.AppendLine(true); //918:1
            }
            __out.Write("}"); //920:1
            __out.AppendLine(false); //920:2
            return __out.ToStringAndFree();
        }

    }
}

