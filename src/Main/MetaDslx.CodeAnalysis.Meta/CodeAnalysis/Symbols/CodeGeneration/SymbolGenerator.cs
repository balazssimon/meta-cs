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
            __out.Write("using MetaDslx.CodeAnalysis.Binding.Binders;"); //8:1
            __out.AppendLine(false); //8:45
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //9:1
            __out.AppendLine(false); //9:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //10:1
            __out.AppendLine(false); //10:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //11:1
            __out.AppendLine(false); //11:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //12:1
            __out.AppendLine(false); //12:44
            __out.Write("using System;"); //13:1
            __out.AppendLine(false); //13:14
            __out.Write("using System.Collections.Generic;"); //14:1
            __out.AppendLine(false); //14:34
            __out.Write("using System.Collections.Immutable;"); //15:1
            __out.AppendLine(false); //15:36
            __out.Write("using System.Diagnostics;"); //16:1
            __out.AppendLine(false); //16:26
            __out.Write("using System.Linq;"); //17:1
            __out.AppendLine(false); //17:19
            __out.Write("using System.Text;"); //18:1
            __out.AppendLine(false); //18:19
            __out.Write("using System.Threading;"); //19:1
            __out.AppendLine(false); //19:24
            __out.Write("using Roslyn.Utilities;"); //20:1
            __out.AppendLine(false); //20:24
            __out.AppendLine(true); //21:1
            __out.Write("#nullable enable"); //22:1
            __out.AppendLine(false); //22:17
            __out.AppendLine(true); //23:1
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
                __out.AppendLine(false); //24:32
            }
            if (symbol.SymbolParts != SymbolParts.None) //25:2
            {
                __out.AppendLine(true); //26:1
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
                    __out.AppendLine(false); //27:35
                }
                if (symbol.SymbolParts.HasFlag(SymbolParts.Metadata)) //28:2
                {
                    __out.AppendLine(true); //29:1
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
                        __out.AppendLine(false); //30:33
                    }
                }
                if (symbol.SymbolParts.HasFlag(SymbolParts.Source)) //32:2
                {
                    __out.AppendLine(true); //33:1
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
                        __out.AppendLine(false); //34:31
                    }
                }
            }
            return __out.ToStringAndFree();
        }

        public string GeneratePartialSymbol(SymbolGenerationInfo symbol) //39:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //40:1
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
                __out.AppendLine(false); //40:33
            }
            __out.Write("{"); //41:1
            __out.AppendLine(false); //41:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	public "; //42:1
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp6_outputWritten = true;
            }
            if (!symbol.ExistingTypeInfo.IsSealed) //42:10
            {
                string __tmp9_line = "abstract "; //42:49
                if (!string.IsNullOrEmpty(__tmp9_line))
                {
                    __out.Write(__tmp9_line);
                    __tmp6_outputWritten = true;
                }
            }
            string __tmp11_line = "partial class "; //42:66
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
                __out.AppendLine(false); //42:93
            }
            __out.Write("	{"); //43:1
            __out.AppendLine(false); //43:3
            __out.Write("        public static"); //44:1
            if (!symbol.IsSymbolClass) //44:23
            {
                __out.Write(" new"); //44:50
            }
            __out.Write(" class CompletionParts"); //44:62
            __out.AppendLine(false); //44:84
            __out.Write("        {"); //45:1
            __out.AppendLine(false); //45:10
            var __loop1_results = 
                (from partName in __Enumerate((symbol.GetCompletionPartNames()).GetEnumerator()) //46:20
                select new { partName = partName}
                ).ToList(); //46:14
            for (int __loop1_iteration = 0; __loop1_iteration < __loop1_results.Count; ++__loop1_iteration)
            {
                var __tmp13 = __loop1_results[__loop1_iteration];
                var partName = __tmp13.partName;
                bool __tmp15_outputWritten = false;
                string __tmp16_line = "            public static readonly CompletionPart "; //47:1
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
                string __tmp18_line = " = "; //47:61
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
                string __tmp20_line = ";"; //47:105
                if (!string.IsNullOrEmpty(__tmp20_line))
                {
                    __out.Write(__tmp20_line);
                    __tmp15_outputWritten = true;
                }
                if (__tmp15_outputWritten) __out.AppendLine(true);
                if (__tmp15_outputWritten)
                {
                    __out.AppendLine(false); //47:106
                }
            }
            bool __tmp22_outputWritten = false;
            string __tmp23_line = "            public static readonly ImmutableHashSet<CompletionPart> AllWithLocation = CompletionPart.Combine("; //49:1
            if (!string.IsNullOrEmpty(__tmp23_line))
            {
                __out.Write(__tmp23_line);
                __tmp22_outputWritten = true;
            }
            var __loop2_results = 
                (from partName in __Enumerate((symbol.GetOrderedCompletionParts(true)).GetEnumerator()) //49:117
                select new { partName = partName}
                ).ToList(); //49:111
            for (int __loop2_iteration = 0; __loop2_iteration < __loop2_results.Count; ++__loop2_iteration)
            {
                string comma; //49:164
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
            string __tmp29_line = ");"; //49:217
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Write(__tmp29_line);
                __tmp22_outputWritten = true;
            }
            if (__tmp22_outputWritten) __out.AppendLine(true);
            if (__tmp22_outputWritten)
            {
                __out.AppendLine(false); //49:219
            }
            bool __tmp31_outputWritten = false;
            string __tmp32_line = "            public static readonly ImmutableHashSet<CompletionPart> All = CompletionPart.Combine("; //50:1
            if (!string.IsNullOrEmpty(__tmp32_line))
            {
                __out.Write(__tmp32_line);
                __tmp31_outputWritten = true;
            }
            var __loop3_results = 
                (from partName in __Enumerate((symbol.GetOrderedCompletionParts(false)).GetEnumerator()) //50:105
                select new { partName = partName}
                ).ToList(); //50:99
            for (int __loop3_iteration = 0; __loop3_iteration < __loop3_results.Count; ++__loop3_iteration)
            {
                string comma; //50:153
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
            string __tmp38_line = ");"; //50:206
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Write(__tmp38_line);
                __tmp31_outputWritten = true;
            }
            if (__tmp31_outputWritten) __out.AppendLine(true);
            if (__tmp31_outputWritten)
            {
                __out.AppendLine(false); //50:208
            }
            bool __tmp40_outputWritten = false;
            string __tmp41_line = "            public static readonly CompletionGraph CompletionGraph = CompletionGraph.FromCompletionParts("; //51:1
            if (!string.IsNullOrEmpty(__tmp41_line))
            {
                __out.Write(__tmp41_line);
                __tmp40_outputWritten = true;
            }
            var __loop4_results = 
                (from partName in __Enumerate((symbol.GetOrderedCompletionParts(false)).GetEnumerator()) //51:113
                select new { partName = partName}
                ).ToList(); //51:107
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                string comma; //51:161
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
            string __tmp47_line = ");"; //51:214
            if (!string.IsNullOrEmpty(__tmp47_line))
            {
                __out.Write(__tmp47_line);
                __tmp40_outputWritten = true;
            }
            if (__tmp40_outputWritten) __out.AppendLine(true);
            if (__tmp40_outputWritten)
            {
                __out.AppendLine(false); //51:216
            }
            __out.Write("        }"); //52:1
            __out.AppendLine(false); //52:10
            if (!symbol.IsAbstract) //53:10
            {
                __out.AppendLine(true); //54:1
                __out.Write("        public "); //55:1
                if (symbol.IsSymbolClass) //55:17
                {
                    __out.Write("virtual"); //55:43
                }
                else //55:51
                {
                    __out.Write("override"); //55:56
                }
                __out.Write(" void Accept(MetaDslx.CodeAnalysis.Symbols.SymbolVisitor visitor)"); //55:72
                __out.AppendLine(false); //55:137
                __out.Write("        {"); //56:1
                __out.AppendLine(false); //56:10
                __out.Write("            if (visitor is ISymbolVisitor isv) isv.Visit(this);"); //57:1
                __out.AppendLine(false); //57:64
                __out.Write("        }"); //58:1
                __out.AppendLine(false); //58:10
                __out.AppendLine(true); //59:1
                __out.Write("        public "); //60:1
                if (symbol.IsSymbolClass) //60:17
                {
                    __out.Write("virtual"); //60:43
                }
                else //60:51
                {
                    __out.Write("override"); //60:56
                }
                __out.Write(" TResult Accept<TResult>(MetaDslx.CodeAnalysis.Symbols.SymbolVisitor<TResult> visitor)"); //60:72
                __out.AppendLine(false); //60:158
                __out.Write("        {"); //61:1
                __out.AppendLine(false); //61:10
                __out.Write("            if (visitor is ISymbolVisitor<TResult> isv) return isv.Visit(this);"); //62:1
                __out.AppendLine(false); //62:80
                __out.Write("            else return default(TResult);"); //63:1
                __out.AppendLine(false); //63:42
                __out.Write("        }"); //64:1
                __out.AppendLine(false); //64:10
                __out.AppendLine(true); //65:1
                __out.Write("        public "); //66:1
                if (symbol.IsSymbolClass) //66:17
                {
                    __out.Write("virtual"); //66:43
                }
                else //66:51
                {
                    __out.Write("override"); //66:56
                }
                __out.Write(" TResult Accept<TArgument, TResult>(MetaDslx.CodeAnalysis.Symbols.SymbolVisitor<TArgument, TResult> visitor, TArgument argument)"); //66:72
                __out.AppendLine(false); //66:200
                __out.Write("        {"); //67:1
                __out.AppendLine(false); //67:10
                __out.Write("            if (visitor is ISymbolVisitor<TArgument, TResult> isv) return isv.Visit(this, argument);"); //68:1
                __out.AppendLine(false); //68:101
                __out.Write("            else return default(TResult);"); //69:1
                __out.AppendLine(false); //69:42
                __out.Write("        }"); //70:1
                __out.AppendLine(false); //70:10
            }
            __out.Write("	}"); //72:1
            __out.AppendLine(false); //72:3
            __out.Write("}"); //73:1
            __out.AppendLine(false); //73:2
            return __out.ToStringAndFree();
        }

        public string GenerateCompletionSymbol(SymbolGenerationInfo symbol) //76:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //77:1
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
            string __tmp5_line = ".Completion"; //77:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //77:44
            }
            __out.Write("{"); //78:1
            __out.AppendLine(false); //78:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public abstract partial class Completion"; //79:1
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
            if (symbol.ExistingCompletionTypeInfo.BaseType == null) //79:56
            {
                string __tmp11_line = " : "; //79:112
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
                string __tmp13_line = "."; //79:137
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
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //79:152
                {
                    string __tmp16_line = ", MetaDslx.CodeAnalysis.Symbols.Metadata.IModelSymbol"; //79:209
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
                __out.AppendLine(false); //79:278
            }
            __out.Write("	{"); //80:1
            __out.AppendLine(false); //80:3
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //81:10
            {
                __out.Write("        private readonly Symbol _container;"); //82:1
                __out.AppendLine(false); //82:44
            }
            if (symbol.ModelObjectOption != ParameterOption.Disabled) //84:10
            {
                __out.Write("        private readonly object? _modelObject;"); //85:1
                __out.AppendLine(false); //85:47
            }
            __out.Write("        private readonly CompletionState _state;"); //87:1
            __out.AppendLine(false); //87:49
            __out.Write("        private ImmutableArray<Symbol> _childSymbols;"); //88:1
            __out.AppendLine(false); //88:54
            __out.Write("        private string _name;"); //89:1
            __out.AppendLine(false); //89:30
            __out.Write("        private string _metadataName;"); //90:1
            __out.AppendLine(false); //90:38
            var __loop5_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //91:16
                select new { prop = prop}
                ).ToList(); //91:10
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                var __tmp19 = __loop5_results[__loop5_iteration];
                var prop = __tmp19.prop;
                bool __tmp21_outputWritten = false;
                string __tmp22_line = "        private "; //92:1
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
                string __tmp24_line = " "; //92:28
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
                string __tmp26_line = ";"; //92:45
                if (!string.IsNullOrEmpty(__tmp26_line))
                {
                    __out.Write(__tmp26_line);
                    __tmp21_outputWritten = true;
                }
                if (__tmp21_outputWritten) __out.AppendLine(true);
                if (__tmp21_outputWritten)
                {
                    __out.AppendLine(false); //92:46
                }
            }
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //94:10
            {
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains(".ctor")) //95:10
                {
                    __out.AppendLine(true); //96:1
                    bool __tmp28_outputWritten = false;
                    string __tmp29_line = "        public Completion"; //97:1
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
                    string __tmp31_line = "(Symbol container"; //97:39
                    if (!string.IsNullOrEmpty(__tmp31_line))
                    {
                        __out.Write(__tmp31_line);
                        __tmp28_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //97:57
                    {
                        string __tmp33_line = ", object? modelObject"; //97:114
                        if (!string.IsNullOrEmpty(__tmp33_line))
                        {
                            __out.Write(__tmp33_line);
                            __tmp28_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //97:136
                        {
                            string __tmp35_line = " = null"; //97:193
                            if (!string.IsNullOrEmpty(__tmp35_line))
                            {
                                __out.Write(__tmp35_line);
                                __tmp28_outputWritten = true;
                            }
                        }
                    }
                    string __tmp38_line = ", bool isError = false)"; //97:216
                    if (!string.IsNullOrEmpty(__tmp38_line))
                    {
                        __out.Write(__tmp38_line);
                        __tmp28_outputWritten = true;
                    }
                    if (__tmp28_outputWritten) __out.AppendLine(true);
                    if (__tmp28_outputWritten)
                    {
                        __out.AppendLine(false); //97:239
                    }
                    __out.Write("        {"); //98:1
                    __out.AppendLine(false); //98:10
                    __out.Write("            _container = container;"); //99:1
                    __out.AppendLine(false); //99:36
                    if (symbol.ModelObjectOption == ParameterOption.Required) //100:14
                    {
                        __out.Write("            if (!isError && modelObject is null) throw new ArgumentNullException(nameof(modelObject));"); //101:1
                        __out.AppendLine(false); //101:103
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
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains("Language")) //109:10
                {
                    __out.AppendLine(true); //110:1
                    __out.Write("        public override Language Language => ContainingModule.Language;"); //111:1
                    __out.AppendLine(false); //111:72
                }
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains("SymbolFactory")) //113:10
                {
                    __out.AppendLine(true); //114:1
                    __out.Write("        public SymbolFactory SymbolFactory => ContainingModule.SymbolFactory;"); //115:1
                    __out.AppendLine(false); //115:78
                }
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //117:10
                {
                    if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ModelObject")) //118:14
                    {
                        __out.AppendLine(true); //119:1
                        __out.Write("        public object ModelObject => _modelObject;"); //120:1
                        __out.AppendLine(false); //120:51
                    }
                    if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ModelObjectType")) //122:14
                    {
                        __out.AppendLine(true); //123:1
                        __out.Write("        public Type ModelObjectType => _modelObject is not null ? Language.SymbolFacts.GetModelObjectType(_modelObject) : null;"); //124:1
                        __out.AppendLine(false); //124:128
                    }
                }
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ContainingSymbol")) //127:10
                {
                    __out.AppendLine(true); //128:1
                    __out.Write("        public override Symbol ContainingSymbol => _container;"); //129:1
                    __out.AppendLine(false); //129:63
                }
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ChildSymbols")) //132:10
            {
                __out.AppendLine(true); //133:1
                __out.Write("        public override ImmutableArray<Symbol> ChildSymbols "); //134:1
                __out.AppendLine(false); //134:61
                __out.Write("        {"); //135:1
                __out.AppendLine(false); //135:10
                __out.Write("            get"); //136:1
                __out.AppendLine(false); //136:16
                __out.Write("            {"); //137:1
                __out.AppendLine(false); //137:14
                __out.Write("                this.ForceComplete(CompletionGraph.FinishCreatingChildren, null, default);"); //138:1
                __out.AppendLine(false); //138:91
                __out.Write("                return _childSymbols;"); //139:1
                __out.AppendLine(false); //139:38
                __out.Write("            }"); //140:1
                __out.AppendLine(false); //140:14
                __out.Write("        }"); //141:1
                __out.AppendLine(false); //141:10
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("Name")) //143:10
            {
                __out.AppendLine(true); //144:1
                __out.Write("        public override string Name "); //145:1
                __out.AppendLine(false); //145:37
                __out.Write("        {"); //146:1
                __out.AppendLine(false); //146:10
                __out.Write("            get"); //147:1
                __out.AppendLine(false); //147:16
                __out.Write("            {"); //148:1
                __out.AppendLine(false); //148:14
                __out.Write("                this.ForceComplete(CompletionGraph.FinishInitializing, null, default);"); //149:1
                __out.AppendLine(false); //149:87
                __out.Write("                return _name;"); //150:1
                __out.AppendLine(false); //150:30
                __out.Write("            }"); //151:1
                __out.AppendLine(false); //151:14
                __out.Write("        }"); //152:1
                __out.AppendLine(false); //152:10
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("MetadataName")) //154:10
            {
                __out.AppendLine(true); //155:1
                __out.Write("        public override string MetadataName "); //156:1
                __out.AppendLine(false); //156:45
                __out.Write("        {"); //157:1
                __out.AppendLine(false); //157:10
                __out.Write("            get"); //158:1
                __out.AppendLine(false); //158:16
                __out.Write("            {"); //159:1
                __out.AppendLine(false); //159:14
                __out.Write("                this.ForceComplete(CompletionGraph.FinishInitializing, null, default);"); //160:1
                __out.AppendLine(false); //160:87
                __out.Write("                return _metadataName;"); //161:1
                __out.AppendLine(false); //161:38
                __out.Write("            }"); //162:1
                __out.AppendLine(false); //162:14
                __out.Write("        }"); //163:1
                __out.AppendLine(false); //163:10
            }
            var __loop6_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //165:16
                select new { prop = prop}
                ).ToList(); //165:10
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp39 = __loop6_results[__loop6_iteration];
                var prop = __tmp39.prop;
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains(prop.Name)) //166:14
                {
                    __out.AppendLine(true); //167:1
                    bool __tmp41_outputWritten = false;
                    string __tmp42_line = "        public override "; //168:1
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
                    string __tmp44_line = " "; //168:36
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
                        __out.AppendLine(false); //168:48
                    }
                    __out.Write("        {"); //169:1
                    __out.AppendLine(false); //169:10
                    __out.Write("            get"); //170:1
                    __out.AppendLine(false); //170:16
                    __out.Write("            {"); //171:1
                    __out.AppendLine(false); //171:14
                    bool __tmp47_outputWritten = false;
                    string __tmp48_line = "                this.ForceComplete(CompletionParts."; //172:1
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
                    string __tmp50_line = ", null, default);"; //172:83
                    if (!string.IsNullOrEmpty(__tmp50_line))
                    {
                        __out.Write(__tmp50_line);
                        __tmp47_outputWritten = true;
                    }
                    if (__tmp47_outputWritten) __out.AppendLine(true);
                    if (__tmp47_outputWritten)
                    {
                        __out.AppendLine(false); //172:100
                    }
                    bool __tmp52_outputWritten = false;
                    string __tmp53_line = "                return "; //173:1
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
                    string __tmp55_line = ";"; //173:40
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Write(__tmp55_line);
                        __tmp52_outputWritten = true;
                    }
                    if (__tmp52_outputWritten) __out.AppendLine(true);
                    if (__tmp52_outputWritten)
                    {
                        __out.AppendLine(false); //173:41
                    }
                    __out.Write("            }"); //174:1
                    __out.AppendLine(false); //174:14
                    __out.Write("        }"); //175:1
                    __out.AppendLine(false); //175:10
                }
            }
            __out.AppendLine(true); //178:1
            __out.Write("        #region Completion"); //179:1
            __out.AppendLine(false); //179:27
            __out.AppendLine(true); //180:1
            __out.Write("        public sealed override bool RequiresCompletion => true;"); //181:1
            __out.AppendLine(false); //181:64
            __out.AppendLine(true); //182:1
            __out.Write("        public sealed override bool HasComplete(CompletionPart part)"); //183:1
            __out.AppendLine(false); //183:69
            __out.Write("        {"); //184:1
            __out.AppendLine(false); //184:10
            __out.Write("            return _state.HasComplete(part);"); //185:1
            __out.AppendLine(false); //185:45
            __out.Write("        }"); //186:1
            __out.AppendLine(false); //186:10
            __out.AppendLine(true); //187:1
            __out.Write("        public override void ForceComplete(CompletionPart completionPart, SourceLocation locationOpt, CancellationToken cancellationToken)"); //188:1
            __out.AppendLine(false); //188:139
            __out.Write("        {"); //189:1
            __out.AppendLine(false); //189:10
            __out.Write("            if (completionPart != null && _state.HasComplete(completionPart)) return;"); //190:1
            __out.AppendLine(false); //190:86
            __out.Write("            if (completionPart != null && !CompletionParts.All.Contains(completionPart)) throw new ArgumentException(nameof(completionPart));"); //191:1
            __out.AppendLine(false); //191:142
            __out.Write("            while (true)"); //192:1
            __out.AppendLine(false); //192:25
            __out.Write("            {"); //193:1
            __out.AppendLine(false); //193:14
            __out.Write("                cancellationToken.ThrowIfCancellationRequested();"); //194:1
            __out.AppendLine(false); //194:66
            __out.Write("                var incompletePart = _state.NextIncompletePart;"); //195:1
            __out.AppendLine(false); //195:64
            __out.Write("                if (incompletePart == CompletionGraph.StartInitializing || incompletePart == CompletionGraph.FinishInitializing)"); //196:1
            __out.AppendLine(false); //196:129
            __out.Write("                {"); //197:1
            __out.AppendLine(false); //197:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartInitializing))"); //198:1
            __out.AppendLine(false); //198:84
            __out.Write("                    {"); //199:1
            __out.AppendLine(false); //199:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //200:1
            __out.AppendLine(false); //200:71
            __out.Write("                        _name = CompleteSymbolProperty_Name(diagnostics, cancellationToken);"); //201:1
            __out.AppendLine(false); //201:93
            __out.Write("                        _metadataName = CompleteSymbolProperty_MetadataName(diagnostics, cancellationToken);"); //202:1
            __out.AppendLine(false); //202:109
            __out.Write("                        CompleteInitializingSymbol(diagnostics, cancellationToken);"); //203:1
            __out.AppendLine(false); //203:84
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //204:1
            __out.AppendLine(false); //204:59
            __out.Write("                        diagnostics.Free();"); //205:1
            __out.AppendLine(false); //205:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishInitializing);"); //206:1
            __out.AppendLine(false); //206:85
            __out.Write("                    }"); //207:1
            __out.AppendLine(false); //207:22
            __out.Write("                }"); //208:1
            __out.AppendLine(false); //208:18
            __out.Write("                else if (incompletePart == CompletionGraph.StartCreatingChildren || incompletePart == CompletionGraph.FinishCreatingChildren)"); //209:1
            __out.AppendLine(false); //209:142
            __out.Write("                {"); //210:1
            __out.AppendLine(false); //210:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartCreatingChildren))"); //211:1
            __out.AppendLine(false); //211:88
            __out.Write("                    {"); //212:1
            __out.AppendLine(false); //212:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //213:1
            __out.AppendLine(false); //213:71
            __out.Write("                        _childSymbols = CompleteCreatingChildSymbols(diagnostics, cancellationToken);"); //214:1
            __out.AppendLine(false); //214:102
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //215:1
            __out.AppendLine(false); //215:59
            __out.Write("                        diagnostics.Free();"); //216:1
            __out.AppendLine(false); //216:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishCreatingChildren);"); //217:1
            __out.AppendLine(false); //217:89
            __out.Write("                    }"); //218:1
            __out.AppendLine(false); //218:22
            __out.Write("                }"); //219:1
            __out.AppendLine(false); //219:18
            var __loop7_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //220:24
                select new { part = part}
                ).ToList(); //220:18
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                var __tmp56 = __loop7_results[__loop7_iteration];
                var part = __tmp56.part;
                if (part.IsLocked) //221:22
                {
                    bool __tmp58_outputWritten = false;
                    string __tmp59_line = "                else if (incompletePart == CompletionParts."; //222:1
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
                    string __tmp61_line = " || incompletePart == CompletionParts."; //222:90
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
                    string __tmp63_line = ")"; //222:159
                    if (!string.IsNullOrEmpty(__tmp63_line))
                    {
                        __out.Write(__tmp63_line);
                        __tmp58_outputWritten = true;
                    }
                    if (__tmp58_outputWritten) __out.AppendLine(true);
                    if (__tmp58_outputWritten)
                    {
                        __out.AppendLine(false); //222:160
                    }
                    __out.Write("                {"); //223:1
                    __out.AppendLine(false); //223:18
                    bool __tmp65_outputWritten = false;
                    string __tmp66_line = "                    if (_state.NotePartComplete(CompletionParts."; //224:1
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
                    string __tmp68_line = "))"; //224:95
                    if (!string.IsNullOrEmpty(__tmp68_line))
                    {
                        __out.Write(__tmp68_line);
                        __tmp65_outputWritten = true;
                    }
                    if (__tmp65_outputWritten) __out.AppendLine(true);
                    if (__tmp65_outputWritten)
                    {
                        __out.AppendLine(false); //224:97
                    }
                    __out.Write("                    {"); //225:1
                    __out.AppendLine(false); //225:22
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //226:26
                    {
                        __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //227:1
                        __out.AppendLine(false); //227:71
                    }
                    bool __tmp70_outputWritten = false;
                    string __tmp69Prefix = "                        "; //229:1
                    if (part is SymbolPropertyGenerationInfo) //229:26
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
                        string __tmp73_line = " = "; //229:116
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
                    string __tmp76_line = "("; //229:152
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
                    string __tmp78_line = ");"; //229:181
                    if (!string.IsNullOrEmpty(__tmp78_line))
                    {
                        __out.Write(__tmp78_line);
                        __tmp70_outputWritten = true;
                    }
                    if (__tmp70_outputWritten) __out.AppendLine(true);
                    if (__tmp70_outputWritten)
                    {
                        __out.AppendLine(false); //229:183
                    }
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //230:26
                    {
                        __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //231:1
                        __out.AppendLine(false); //231:59
                        __out.Write("                        diagnostics.Free();"); //232:1
                        __out.AppendLine(false); //232:44
                    }
                    bool __tmp80_outputWritten = false;
                    string __tmp81_line = "                        _state.NotePartComplete(CompletionParts."; //234:1
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
                    string __tmp83_line = ");"; //234:96
                    if (!string.IsNullOrEmpty(__tmp83_line))
                    {
                        __out.Write(__tmp83_line);
                        __tmp80_outputWritten = true;
                    }
                    if (__tmp80_outputWritten) __out.AppendLine(true);
                    if (__tmp80_outputWritten)
                    {
                        __out.AppendLine(false); //234:98
                    }
                    __out.Write("                    }"); //235:1
                    __out.AppendLine(false); //235:22
                    __out.Write("                }"); //236:1
                    __out.AppendLine(false); //236:18
                }
                else //237:22
                {
                    bool __tmp85_outputWritten = false;
                    string __tmp86_line = "                else if (incompletePart == CompletionParts."; //238:1
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
                    string __tmp88_line = ")"; //238:85
                    if (!string.IsNullOrEmpty(__tmp88_line))
                    {
                        __out.Write(__tmp88_line);
                        __tmp85_outputWritten = true;
                    }
                    if (__tmp85_outputWritten) __out.AppendLine(true);
                    if (__tmp85_outputWritten)
                    {
                        __out.AppendLine(false); //238:86
                    }
                    __out.Write("                {"); //239:1
                    __out.AppendLine(false); //239:18
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //240:22
                    {
                        __out.Write("                    var diagnostics = DiagnosticBag.GetInstance();"); //241:1
                        __out.AppendLine(false); //241:67
                    }
                    bool __tmp90_outputWritten = false;
                    string __tmp89Prefix = "                    "; //243:1
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
                    string __tmp92_line = "("; //243:46
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
                    string __tmp94_line = ");"; //243:75
                    if (!string.IsNullOrEmpty(__tmp94_line))
                    {
                        __out.Write(__tmp94_line);
                        __tmp90_outputWritten = true;
                    }
                    if (__tmp90_outputWritten) __out.AppendLine(true);
                    if (__tmp90_outputWritten)
                    {
                        __out.AppendLine(false); //243:77
                    }
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //244:22
                    {
                        __out.Write("                    AddSymbolDiagnostics(diagnostics);"); //245:1
                        __out.AppendLine(false); //245:55
                        __out.Write("                    diagnostics.Free();"); //246:1
                        __out.AppendLine(false); //246:40
                    }
                    bool __tmp96_outputWritten = false;
                    string __tmp97_line = "                    _state.NotePartComplete(CompletionParts."; //248:1
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
                    string __tmp99_line = ");"; //248:86
                    if (!string.IsNullOrEmpty(__tmp99_line))
                    {
                        __out.Write(__tmp99_line);
                        __tmp96_outputWritten = true;
                    }
                    if (__tmp96_outputWritten) __out.AppendLine(true);
                    if (__tmp96_outputWritten)
                    {
                        __out.AppendLine(false); //248:88
                    }
                    __out.Write("                }"); //249:1
                    __out.AppendLine(false); //249:18
                }
            }
            __out.Write("                else if (incompletePart == CompletionGraph.StartComputingNonSymbolProperties || incompletePart == CompletionGraph.FinishComputingNonSymbolProperties)"); //252:1
            __out.AppendLine(false); //252:166
            __out.Write("                {"); //253:1
            __out.AppendLine(false); //253:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartComputingNonSymbolProperties))"); //254:1
            __out.AppendLine(false); //254:100
            __out.Write("                    {"); //255:1
            __out.AppendLine(false); //255:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //256:1
            __out.AppendLine(false); //256:71
            __out.Write("                        CompleteNonSymbolProperties(locationOpt, diagnostics, cancellationToken);"); //257:1
            __out.AppendLine(false); //257:98
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //258:1
            __out.AppendLine(false); //258:59
            __out.Write("                        diagnostics.Free();"); //259:1
            __out.AppendLine(false); //259:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishComputingNonSymbolProperties);"); //260:1
            __out.AppendLine(false); //260:101
            __out.Write("                    }"); //261:1
            __out.AppendLine(false); //261:22
            __out.Write("                }"); //262:1
            __out.AppendLine(false); //262:18
            __out.Write("                else if (incompletePart == CompletionGraph.ChildrenCompleted)"); //263:1
            __out.AppendLine(false); //263:78
            __out.Write("                {"); //264:1
            __out.AppendLine(false); //264:18
            __out.Write("                    var diagnostics = DiagnosticBag.GetInstance();"); //265:1
            __out.AppendLine(false); //265:67
            __out.Write("                    CompleteImports(locationOpt, diagnostics, cancellationToken);"); //266:1
            __out.AppendLine(false); //266:82
            __out.Write("                    AddSymbolDiagnostics(diagnostics);"); //267:1
            __out.AppendLine(false); //267:55
            __out.Write("                    diagnostics.Free();"); //268:1
            __out.AppendLine(false); //268:40
            __out.Write("                    bool allCompleted = true;"); //270:1
            __out.AppendLine(false); //270:46
            __out.Write("                    if (locationOpt == null)"); //271:1
            __out.AppendLine(false); //271:45
            __out.Write("                    {"); //272:1
            __out.AppendLine(false); //272:22
            __out.Write("                        foreach (var child in _childSymbols)"); //273:1
            __out.AppendLine(false); //273:61
            __out.Write("                        {"); //274:1
            __out.AppendLine(false); //274:26
            __out.Write("                            cancellationToken.ThrowIfCancellationRequested();"); //275:1
            __out.AppendLine(false); //275:78
            __out.Write("                            child.ForceComplete(null, locationOpt, cancellationToken);"); //276:1
            __out.AppendLine(false); //276:87
            __out.Write("                        }"); //277:1
            __out.AppendLine(false); //277:26
            __out.Write("                    }"); //278:1
            __out.AppendLine(false); //278:22
            __out.Write("                    else"); //279:1
            __out.AppendLine(false); //279:25
            __out.Write("                    {"); //280:1
            __out.AppendLine(false); //280:22
            __out.Write("                        foreach (var child in _childSymbols)"); //281:1
            __out.AppendLine(false); //281:61
            __out.Write("                        {"); //282:1
            __out.AppendLine(false); //282:26
            __out.Write("                            ForceCompleteChildByLocation(locationOpt, child, cancellationToken);"); //283:1
            __out.AppendLine(false); //283:97
            __out.Write("                            allCompleted = allCompleted && child.HasComplete(CompletionGraph.All);"); //284:1
            __out.AppendLine(false); //284:99
            __out.Write("                        }"); //285:1
            __out.AppendLine(false); //285:26
            __out.Write("                    }"); //286:1
            __out.AppendLine(false); //286:22
            __out.Write("                    if (!allCompleted)"); //288:1
            __out.AppendLine(false); //288:39
            __out.Write("                    {"); //289:1
            __out.AppendLine(false); //289:22
            __out.Write("                        // We did not complete all members, so just kick out now."); //290:1
            __out.AppendLine(false); //290:82
            __out.Write("                        var allParts = CompletionParts.AllWithLocation;"); //291:1
            __out.AppendLine(false); //291:72
            __out.Write("                        _state.SpinWaitComplete(allParts, cancellationToken);"); //292:1
            __out.AppendLine(false); //292:78
            __out.Write("                        return;"); //293:1
            __out.AppendLine(false); //293:32
            __out.Write("                    }"); //294:1
            __out.AppendLine(false); //294:22
            __out.Write("                    // We've completed all members, proceed to the next iteration."); //296:1
            __out.AppendLine(false); //296:83
            __out.Write("                    _state.NotePartComplete(CompletionGraph.ChildrenCompleted);"); //297:1
            __out.AppendLine(false); //297:80
            __out.Write("                }"); //298:1
            __out.AppendLine(false); //298:18
            __out.Write("                else if (incompletePart == null)"); //299:1
            __out.AppendLine(false); //299:49
            __out.Write("                {"); //300:1
            __out.AppendLine(false); //300:18
            __out.Write("                    return;"); //301:1
            __out.AppendLine(false); //301:28
            __out.Write("                }"); //302:1
            __out.AppendLine(false); //302:18
            __out.Write("                else"); //303:1
            __out.AppendLine(false); //303:21
            __out.Write("                {"); //304:1
            __out.AppendLine(false); //304:18
            __out.Write("                    // This assert will trigger if we forgot to handle any of the completion parts"); //305:1
            __out.AppendLine(false); //305:99
            __out.Write("                    Debug.Assert(!CompletionParts.All.Contains(incompletePart));"); //306:1
            __out.AppendLine(false); //306:81
            __out.Write("                    // any other values are completion parts intended for other kinds of symbols"); //307:1
            __out.AppendLine(false); //307:97
            __out.Write("                    _state.NotePartComplete(incompletePart);"); //308:1
            __out.AppendLine(false); //308:61
            __out.Write("                }"); //309:1
            __out.AppendLine(false); //309:18
            __out.Write("                if (completionPart != null && _state.HasComplete(completionPart)) return;"); //310:1
            __out.AppendLine(false); //310:90
            __out.Write("                _state.SpinWaitComplete(incompletePart, cancellationToken);"); //311:1
            __out.AppendLine(false); //311:76
            __out.Write("            }"); //312:1
            __out.AppendLine(false); //312:14
            __out.Write("            throw ExceptionUtilities.Unreachable;"); //313:1
            __out.AppendLine(false); //313:50
            __out.Write("        }"); //314:1
            __out.AppendLine(false); //314:10
            __out.AppendLine(true); //315:1
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteSymbolProperty_Name")) //316:10
            {
                __out.Write("        protected abstract string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //317:1
                __out.AppendLine(false); //317:127
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteSymbolProperty_MetadataName")) //319:10
            {
                __out.Write("        protected abstract string CompleteSymbolProperty_MetadataName(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //320:1
                __out.AppendLine(false); //320:135
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteInitializingSymbol")) //322:10
            {
                __out.Write("        protected abstract void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //323:1
                __out.AppendLine(false); //323:124
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteCreatingChildSymbols")) //325:10
            {
                __out.Write("        protected abstract ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //326:1
                __out.AppendLine(false); //326:144
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteImports")) //328:10
            {
                __out.Write("        protected abstract void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //329:1
                __out.AppendLine(false); //329:141
            }
            var __loop8_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //331:16
                where part.GenerateCompleteMethod //331:44
                select new { part = part}
                ).ToList(); //331:10
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp100 = __loop8_results[__loop8_iteration];
                var part = __tmp100.part;
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains(part.CompleteMethodName)) //332:14
                {
                    bool __tmp102_outputWritten = false;
                    string __tmp103_line = "        protected abstract "; //333:1
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
                    string __tmp105_line = " "; //333:59
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
                    string __tmp107_line = "("; //333:85
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
                    string __tmp109_line = ");"; //333:116
                    if (!string.IsNullOrEmpty(__tmp109_line))
                    {
                        __out.Write(__tmp109_line);
                        __tmp102_outputWritten = true;
                    }
                    if (__tmp102_outputWritten) __out.AppendLine(true);
                    if (__tmp102_outputWritten)
                    {
                        __out.AppendLine(false); //333:118
                    }
                }
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteNonSymbolProperties")) //336:10
            {
                __out.Write("        protected abstract void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //337:1
                __out.AppendLine(false); //337:153
            }
            __out.Write("        #endregion"); //339:1
            __out.AppendLine(false); //339:19
            __out.Write("    }"); //340:1
            __out.AppendLine(false); //340:6
            __out.Write("}"); //341:1
            __out.AppendLine(false); //341:2
            return __out.ToStringAndFree();
        }

        public string GenerateMetadataSymbol(SymbolGenerationInfo symbol) //344:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //345:1
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
            string __tmp5_line = ".Metadata"; //345:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //345:42
            }
            __out.Write("{"); //346:1
            __out.AppendLine(false); //346:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Metadata"; //347:1
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
            if (symbol.ExistingMetadataTypeInfo.BaseType == null) //347:45
            {
                string __tmp11_line = " : "; //347:99
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
                string __tmp13_line = ".Completion.Completion"; //347:124
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
                __out.AppendLine(false); //347:167
            }
            __out.Write("	{"); //348:1
            __out.AppendLine(false); //348:3
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //349:10
            {
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //350:10
                {
                    bool __tmp17_outputWritten = false;
                    string __tmp18_line = "        public Metadata"; //351:1
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
                    string __tmp20_line = "(Symbol container"; //351:37
                    if (!string.IsNullOrEmpty(__tmp20_line))
                    {
                        __out.Write(__tmp20_line);
                        __tmp17_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //351:55
                    {
                        string __tmp22_line = ", object? modelObject"; //351:112
                        if (!string.IsNullOrEmpty(__tmp22_line))
                        {
                            __out.Write(__tmp22_line);
                            __tmp17_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //351:134
                        {
                            string __tmp24_line = " = null"; //351:191
                            if (!string.IsNullOrEmpty(__tmp24_line))
                            {
                                __out.Write(__tmp24_line);
                                __tmp17_outputWritten = true;
                            }
                        }
                    }
                    string __tmp27_line = ", bool isError = false)"; //351:214
                    if (!string.IsNullOrEmpty(__tmp27_line))
                    {
                        __out.Write(__tmp27_line);
                        __tmp17_outputWritten = true;
                    }
                    if (__tmp17_outputWritten) __out.AppendLine(true);
                    if (__tmp17_outputWritten)
                    {
                        __out.AppendLine(false); //351:237
                    }
                    __out.Write("            : base(container"); //352:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //352:30
                    {
                        __out.Write(", modelObject"); //352:87
                    }
                    __out.Write(", isError)"); //352:108
                    __out.AppendLine(false); //352:118
                    __out.Write("        {"); //353:1
                    __out.AppendLine(false); //353:10
                    __out.Write("        }"); //354:1
                    __out.AppendLine(false); //354:10
                }
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains("Locations")) //356:10
                {
                    __out.AppendLine(true); //357:1
                    __out.Write("        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;"); //358:1
                    __out.AppendLine(false); //358:95
                }
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains("DeclaringSyntaxReferences")) //360:10
                {
                    __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;"); //361:1
                    __out.AppendLine(false); //361:124
                }
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteSymbolProperty_Name")) //364:10
            {
                __out.AppendLine(true); //365:1
                __out.Write("        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //366:1
                __out.AppendLine(false); //366:126
                __out.Write("        {"); //367:1
                __out.AppendLine(false); //367:10
                __out.Write("            return MetadataSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //368:1
                __out.AppendLine(false); //368:135
                __out.Write("        }"); //369:1
                __out.AppendLine(false); //369:10
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteSymbolProperty_MetadataName")) //371:10
            {
                __out.AppendLine(true); //372:1
                __out.Write("        protected override string CompleteSymbolProperty_MetadataName(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //373:1
                __out.AppendLine(false); //373:134
                __out.Write("        {"); //374:1
                __out.AppendLine(false); //374:10
                __out.Write("            return MetadataSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(MetadataName), diagnostics, cancellationToken);"); //375:1
                __out.AppendLine(false); //375:143
                __out.Write("        }"); //376:1
                __out.AppendLine(false); //376:10
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteInitializingSymbol")) //378:10
            {
                __out.AppendLine(true); //379:1
                __out.Write("        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //380:1
                __out.AppendLine(false); //380:123
                __out.Write("        {"); //381:1
                __out.AppendLine(false); //381:10
                __out.Write("        }"); //382:1
                __out.AppendLine(false); //382:10
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteCreatingChildSymbols")) //384:10
            {
                __out.AppendLine(true); //385:1
                __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //386:1
                __out.AppendLine(false); //386:143
                __out.Write("        {"); //387:1
                __out.AppendLine(false); //387:10
                __out.Write("            return MetadataSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //388:1
                __out.AppendLine(false); //388:126
                __out.Write("        }"); //389:1
                __out.AppendLine(false); //389:10
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteImports")) //391:10
            {
                __out.AppendLine(true); //392:1
                __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //393:1
                __out.AppendLine(false); //393:140
                __out.Write("        {"); //394:1
                __out.AppendLine(false); //394:10
                __out.Write("        }"); //395:1
                __out.AppendLine(false); //395:10
            }
            var __loop9_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //397:16
                where part.GenerateCompleteMethod //397:44
                select new { part = part}
                ).ToList(); //397:10
            for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
            {
                var __tmp28 = __loop9_results[__loop9_iteration];
                var part = __tmp28.part;
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains(part.CompleteMethodName)) //398:14
                {
                    __out.AppendLine(true); //399:1
                    bool __tmp30_outputWritten = false;
                    string __tmp31_line = "        protected override "; //400:1
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
                    string __tmp33_line = " "; //400:59
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
                    string __tmp35_line = "("; //400:85
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
                    string __tmp37_line = ")"; //400:116
                    if (!string.IsNullOrEmpty(__tmp37_line))
                    {
                        __out.Write(__tmp37_line);
                        __tmp30_outputWritten = true;
                    }
                    if (__tmp30_outputWritten) __out.AppendLine(true);
                    if (__tmp30_outputWritten)
                    {
                        __out.AppendLine(false); //400:117
                    }
                    __out.Write("        {"); //401:1
                    __out.AppendLine(false); //401:10
                    if (part is SymbolPropertyGenerationInfo) //402:14
                    {
                        var prop = (SymbolPropertyGenerationInfo)part; //403:18
                        if (prop.IsCollection) //404:18
                        {
                            bool __tmp39_outputWritten = false;
                            string __tmp40_line = "            return MetadataSymbolImplementation.AssignSymbolPropertyValues<"; //405:1
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
                            string __tmp42_line = ">(this, nameof("; //405:91
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
                            string __tmp44_line = "), diagnostics, cancellationToken);"; //405:117
                            if (!string.IsNullOrEmpty(__tmp44_line))
                            {
                                __out.Write(__tmp44_line);
                                __tmp39_outputWritten = true;
                            }
                            if (__tmp39_outputWritten) __out.AppendLine(true);
                            if (__tmp39_outputWritten)
                            {
                                __out.AppendLine(false); //405:152
                            }
                        }
                        else //406:18
                        {
                            bool __tmp46_outputWritten = false;
                            string __tmp47_line = "            return MetadataSymbolImplementation.AssignSymbolPropertyValue<"; //407:1
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
                            string __tmp49_line = ">(this, nameof("; //407:86
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
                            string __tmp51_line = "), diagnostics, cancellationToken);"; //407:112
                            if (!string.IsNullOrEmpty(__tmp51_line))
                            {
                                __out.Write(__tmp51_line);
                                __tmp46_outputWritten = true;
                            }
                            if (__tmp46_outputWritten) __out.AppendLine(true);
                            if (__tmp46_outputWritten)
                            {
                                __out.AppendLine(false); //407:147
                            }
                        }
                    }
                    __out.Write("        }"); //410:1
                    __out.AppendLine(false); //410:10
                }
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteNonSymbolProperties")) //413:10
            {
                __out.AppendLine(true); //414:1
                __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //415:1
                __out.AppendLine(false); //415:152
                __out.Write("        {"); //416:1
                __out.AppendLine(false); //416:10
                __out.Write("        }"); //417:1
                __out.AppendLine(false); //417:10
            }
            __out.AppendLine(true); //419:1
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //420:10
            {
                bool __tmp53_outputWritten = false;
                string __tmp54_line = "        public partial class Error : Metadata"; //421:1
                if (!string.IsNullOrEmpty(__tmp54_line))
                {
                    __out.Write(__tmp54_line);
                    __tmp53_outputWritten = true;
                }
                var __tmp55 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp55.Write(symbol.Name);
                var __tmp55Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp55.ToStringAndFree());
                bool __tmp55_last = __tmp55Reader.EndOfStream;
                while(!__tmp55_last)
                {
                    ReadOnlySpan<char> __tmp55_line = __tmp55Reader.ReadLine();
                    __tmp55_last = __tmp55Reader.EndOfStream;
                    if (!__tmp55_last || !__tmp55_line.IsEmpty)
                    {
                        __out.Write(__tmp55_line);
                        __tmp53_outputWritten = true;
                    }
                    if (!__tmp55_last) __out.AppendLine(true);
                }
                string __tmp56_line = ", MetaDslx.CodeAnalysis.Symbols.IErrorSymbol"; //421:59
                if (!string.IsNullOrEmpty(__tmp56_line))
                {
                    __out.Write(__tmp56_line);
                    __tmp53_outputWritten = true;
                }
                if (__tmp53_outputWritten) __out.AppendLine(true);
                if (__tmp53_outputWritten)
                {
                    __out.AppendLine(false); //421:103
                }
                __out.Write("        {"); //422:1
                __out.AppendLine(false); //422:10
                __out.Write("            private readonly string _name;"); //423:1
                __out.AppendLine(false); //423:43
                __out.Write("            private readonly string _metadataName;"); //424:1
                __out.AppendLine(false); //424:51
                __out.Write("            private DiagnosticInfo _errorInfo;"); //425:1
                __out.AppendLine(false); //425:47
                __out.Write("            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorKind _kind;"); //426:1
                __out.AppendLine(false); //426:76
                __out.Write("            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags _flags;"); //427:1
                __out.AppendLine(false); //427:84
                __out.Write("            private ImmutableArray<Symbol> _candidateSymbols;"); //428:1
                __out.AppendLine(false); //428:62
                __out.AppendLine(true); //429:1
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //430:14
                {
                    __out.Write("            private Error(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags"); //431:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //431:246
                    {
                        __out.Write(", object? modelObject"); //431:303
                    }
                    __out.Write(")"); //431:332
                    __out.AppendLine(false); //431:333
                    __out.Write("                : base(container"); //432:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //432:34
                    {
                        __out.Write(", modelObject"); //432:91
                    }
                    __out.Write(", true)"); //432:112
                    __out.AppendLine(false); //432:119
                    __out.Write("            {"); //433:1
                    __out.AppendLine(false); //433:14
                    __out.Write("                Debug.Assert(!flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported) || errorInfo != null);"); //434:1
                    __out.AppendLine(false); //434:126
                    __out.Write("                _name = name;"); //435:1
                    __out.AppendLine(false); //435:30
                    __out.Write("                _metadataName = metadataName;"); //436:1
                    __out.AppendLine(false); //436:46
                    __out.Write("                _kind = kind;"); //437:1
                    __out.AppendLine(false); //437:30
                    __out.Write("                _errorInfo = errorInfo;"); //438:1
                    __out.AppendLine(false); //438:40
                    __out.Write("                _candidateSymbols = candidateSymbols;"); //439:1
                    __out.AppendLine(false); //439:54
                    __out.Write("                _flags = flags;"); //440:1
                    __out.AppendLine(false); //440:32
                    __out.Write("            }"); //441:1
                    __out.AppendLine(false); //441:14
                    __out.Write("            public Error(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported"); //443:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //443:208
                    {
                        __out.Write(", object? modelObject"); //443:265
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //443:287
                        {
                            __out.Write(" = null"); //443:344
                        }
                    }
                    __out.Write(")"); //443:367
                    __out.AppendLine(false); //443:368
                    __out.Write("                : this(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.None"); //444:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //444:215
                    {
                        __out.Write(", modelObject"); //444:272
                    }
                    __out.Write(")"); //444:293
                    __out.AppendLine(false); //444:294
                    __out.Write("            {"); //445:1
                    __out.AppendLine(false); //445:14
                    __out.Write("            }"); //446:1
                    __out.AppendLine(false); //446:14
                    __out.Write("            public Error(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported"); //448:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //448:137
                    {
                        __out.Write(", object? modelObject"); //448:194
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //448:216
                        {
                            __out.Write(" = null"); //448:273
                        }
                    }
                    __out.Write(")"); //448:296
                    __out.AppendLine(false); //448:297
                    __out.Write("                : this(wrappedSymbol.ContainingSymbol, wrappedSymbol.Name, wrappedSymbol.MetadataName, kind, errorInfo, ImmutableArray.Create<Symbol>(wrappedSymbol), unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.UnreportedWrapped : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Wrapped"); //449:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //449:302
                    {
                        __out.Write(", modelObject is not null ? modelObject : (wrappedSymbol as IModelSymbol)?.ModelObject"); //449:359
                    }
                    __out.Write(")"); //449:453
                    __out.AppendLine(false); //449:454
                    __out.Write("            {"); //450:1
                    __out.AppendLine(false); //450:14
                    __out.Write("            }"); //451:1
                    __out.AppendLine(false); //451:14
                    __out.AppendLine(true); //452:1
                    __out.Write("            protected virtual Error Update(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags"); //453:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //453:263
                    {
                        __out.Write(", object? modelObject"); //453:320
                    }
                    __out.Write(")"); //453:349
                    __out.AppendLine(false); //453:350
                    __out.Write("            {"); //454:1
                    __out.AppendLine(false); //454:14
                    __out.Write("                return new Error(container, name, metadataName, kind, errorInfo, candidateSymbols, flags"); //455:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //455:106
                    {
                        __out.Write(", modelObject"); //455:163
                    }
                    __out.Write(");"); //455:184
                    __out.AppendLine(false); //455:186
                    __out.Write("            }"); //456:1
                    __out.AppendLine(false); //456:14
                }
                __out.AppendLine(true); //458:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsUnreported(DiagnosticInfo? errorInfo = null)"); //459:1
                __out.AppendLine(false); //459:103
                __out.Write("            {"); //460:1
                __out.AppendLine(false); //460:14
                __out.Write("                return this.IsUnreported ? this :"); //461:1
                __out.AppendLine(false); //461:50
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, _kind, errorInfo is null ? ErrorInfo : errorInfo, CandidateSymbols, _flags | MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported"); //462:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //462:208
                {
                    __out.Write(", this.ModelObject"); //462:265
                }
                __out.Write(");"); //462:291
                __out.AppendLine(false); //462:293
                __out.Write("            }"); //463:1
                __out.AppendLine(false); //463:14
                __out.AppendLine(true); //464:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsReported(DiagnosticInfo? errorInfo = null)"); //465:1
                __out.AppendLine(false); //465:101
                __out.Write("            {"); //466:1
                __out.AppendLine(false); //466:14
                __out.Write("                return this.IsUnreported ? this :"); //467:1
                __out.AppendLine(false); //467:50
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, _kind, errorInfo is null ? ErrorInfo : errorInfo, CandidateSymbols, _flags & ~MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported"); //468:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //468:209
                {
                    __out.Write(", this.ModelObject"); //468:266
                }
                __out.Write(");"); //468:292
                __out.AppendLine(false); //468:294
                __out.Write("            }"); //469:1
                __out.AppendLine(false); //469:14
                __out.AppendLine(true); //470:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind)"); //471:1
                __out.AppendLine(false); //471:109
                __out.Write("            {"); //472:1
                __out.AppendLine(false); //472:14
                __out.Write("                return _kind == kind ? this :"); //473:1
                __out.AppendLine(false); //473:46
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, kind, ErrorInfo, CandidateSymbols, _flags"); //474:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //474:115
                {
                    __out.Write(", this.ModelObject"); //474:172
                }
                __out.Write(");"); //474:198
                __out.AppendLine(false); //474:200
                __out.Write("            }"); //475:1
                __out.AppendLine(false); //475:14
                __out.AppendLine(true); //476:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, ImmutableArray<MetaDslx.CodeAnalysis.Symbols.Symbol> candidateSymbols)"); //477:1
                __out.AppendLine(false); //477:180
                __out.Write("            {"); //478:1
                __out.AppendLine(false); //478:14
                __out.Write("                return _kind == kind && CandidateSymbols == candidateSymbols ? this :"); //479:1
                __out.AppendLine(false); //479:86
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, kind, ErrorInfo, candidateSymbols, _flags"); //480:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //480:115
                {
                    __out.Write(", this.ModelObject"); //480:172
                }
                __out.Write(");"); //480:198
                __out.AppendLine(false); //480:200
                __out.Write("            }"); //481:1
                __out.AppendLine(false); //481:14
                __out.AppendLine(true); //482:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo errorInfo, ImmutableArray<MetaDslx.CodeAnalysis.Symbols.Symbol> candidateSymbols)"); //483:1
                __out.AppendLine(false); //483:206
                __out.Write("            {"); //484:1
                __out.AppendLine(false); //484:14
                __out.Write("                return _kind == kind && ErrorInfo == errorInfo && CandidateSymbols == candidateSymbols ? this :"); //485:1
                __out.AppendLine(false); //485:112
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, kind, errorInfo, candidateSymbols, _flags"); //486:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //486:115
                {
                    __out.Write(", this.ModelObject"); //486:172
                }
                __out.Write(");"); //486:198
                __out.AppendLine(false); //486:200
                __out.Write("            }"); //487:1
                __out.AppendLine(false); //487:14
                __out.AppendLine(true); //488:1
                __out.Write("            public override string Name => _name;"); //489:1
                __out.AppendLine(false); //489:50
                __out.AppendLine(true); //490:1
                __out.Write("            public override string MetadataName => _metadataName;"); //491:1
                __out.AppendLine(false); //491:66
                __out.AppendLine(true); //492:1
                __out.Write("            public sealed override bool IsError => true;"); //493:1
                __out.AppendLine(false); //493:57
                __out.AppendLine(true); //494:1
                __out.Write("            public bool IsUnreported => _flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported);"); //495:1
                __out.AppendLine(false); //495:115
                __out.AppendLine(true); //496:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.ErrorKind ErrorKind => _kind;"); //497:1
                __out.AppendLine(false); //497:79
                __out.AppendLine(true); //498:1
                __out.Write("            public ImmutableArray<Symbol> CandidateSymbols"); //499:1
                __out.AppendLine(false); //499:59
                __out.Write("            {"); //500:1
                __out.AppendLine(false); //500:14
                __out.Write("                get"); //501:1
                __out.AppendLine(false); //501:20
                __out.Write("                {"); //502:1
                __out.AppendLine(false); //502:18
                __out.Write("                    if (_candidateSymbols.IsDefault)"); //503:1
                __out.AppendLine(false); //503:53
                __out.Write("                    {"); //504:1
                __out.AppendLine(false); //504:22
                __out.Write("                        System.Collections.Immutable.ImmutableInterlocked.InterlockedInitialize(ref _candidateSymbols, MakeCandidateSymbols());"); //505:1
                __out.AppendLine(false); //505:144
                __out.Write("                    }"); //506:1
                __out.AppendLine(false); //506:22
                __out.Write("                    return _candidateSymbols;"); //507:1
                __out.AppendLine(false); //507:46
                __out.Write("                }"); //508:1
                __out.AppendLine(false); //508:18
                __out.Write("            }"); //509:1
                __out.AppendLine(false); //509:14
                __out.AppendLine(true); //510:1
                __out.Write("            public DiagnosticInfo? ErrorInfo"); //511:1
                __out.AppendLine(false); //511:45
                __out.Write("            {"); //512:1
                __out.AppendLine(false); //512:14
                __out.Write("                get"); //513:1
                __out.AppendLine(false); //513:20
                __out.Write("                {"); //514:1
                __out.AppendLine(false); //514:18
                __out.Write("                    if (_errorInfo is null)"); //515:1
                __out.AppendLine(false); //515:44
                __out.Write("                    {"); //516:1
                __out.AppendLine(false); //516:22
                __out.Write("                        System.Threading.Interlocked.CompareExchange(ref _errorInfo, MakeErrorInfo(), null);"); //517:1
                __out.AppendLine(false); //517:109
                __out.Write("                    }"); //518:1
                __out.AppendLine(false); //518:22
                __out.Write("                    return _errorInfo;"); //519:1
                __out.AppendLine(false); //519:39
                __out.Write("                }"); //520:1
                __out.AppendLine(false); //520:18
                __out.Write("            }"); //521:1
                __out.AppendLine(false); //521:14
                __out.AppendLine(true); //522:1
                __out.Write("            protected virtual DiagnosticInfo? MakeErrorInfo()"); //523:1
                __out.AppendLine(false); //523:62
                __out.Write("            {"); //524:1
                __out.AppendLine(false); //524:14
                __out.Write("                return ErrorSymbolImplementation.MakeErrorInfo(this);"); //525:1
                __out.AppendLine(false); //525:70
                __out.Write("            }"); //526:1
                __out.AppendLine(false); //526:14
                __out.AppendLine(true); //527:1
                __out.Write("            protected virtual ImmutableArray<Symbol> MakeCandidateSymbols()"); //528:1
                __out.AppendLine(false); //528:76
                __out.Write("            {"); //529:1
                __out.AppendLine(false); //529:14
                __out.Write("                return ErrorSymbolImplementation.MakeCandidateSymbols(this);"); //530:1
                __out.AppendLine(false); //530:77
                __out.Write("            }"); //531:1
                __out.AppendLine(false); //531:14
                __out.AppendLine(true); //532:1
                __out.Write("            protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //533:1
                __out.AppendLine(false); //533:130
                __out.Write("            {"); //534:1
                __out.AppendLine(false); //534:14
                __out.Write("                return _name;"); //535:1
                __out.AppendLine(false); //535:30
                __out.Write("            }"); //536:1
                __out.AppendLine(false); //536:14
                __out.Write("        }"); //537:1
                __out.AppendLine(false); //537:10
            }
            __out.Write("    }"); //539:1
            __out.AppendLine(false); //539:6
            __out.Write("}"); //540:1
            __out.AppendLine(false); //540:2
            return __out.ToStringAndFree();
        }

        public string GenerateSourceSymbol(SymbolGenerationInfo symbol) //543:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //544:1
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
            string __tmp5_line = ".Source"; //544:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //544:40
            }
            __out.Write("{"); //545:1
            __out.AppendLine(false); //545:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Source"; //546:1
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
            if (symbol.ExistingSourceTypeInfo.BaseType == null) //546:43
            {
                string __tmp11_line = " : "; //546:95
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
                string __tmp13_line = ".Completion.Completion"; //546:120
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
                if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //546:156
                {
                    string __tmp16_line = ", MetaDslx.CodeAnalysis.Symbols.Source.ISourceSymbol"; //546:226
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
                __out.AppendLine(false); //546:294
            }
            __out.Write("	{"); //547:1
            __out.AppendLine(false); //547:3
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //548:10
            {
                __out.Write("        private readonly MergedDeclaration _declaration;"); //549:1
                __out.AppendLine(false); //549:57
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetLexicalSortKey")) //550:10
                {
                    __out.Write("        private LexicalSortKey _lazyLexicalSortKey = LexicalSortKey.NotInitialized;"); //551:1
                    __out.AppendLine(false); //551:84
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //553:10
                {
                    __out.AppendLine(true); //554:1
                    bool __tmp20_outputWritten = false;
                    string __tmp21_line = "		public Source"; //555:1
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
                    string __tmp23_line = "(Symbol containingSymbol, MergedDeclaration declaration"; //555:29
                    if (!string.IsNullOrEmpty(__tmp23_line))
                    {
                        __out.Write(__tmp23_line);
                        __tmp20_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //555:85
                    {
                        string __tmp25_line = ", object? modelObject"; //555:142
                        if (!string.IsNullOrEmpty(__tmp25_line))
                        {
                            __out.Write(__tmp25_line);
                            __tmp20_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //555:164
                        {
                            string __tmp27_line = " = null"; //555:221
                            if (!string.IsNullOrEmpty(__tmp27_line))
                            {
                                __out.Write(__tmp27_line);
                                __tmp20_outputWritten = true;
                            }
                        }
                    }
                    string __tmp30_line = ", bool isError = false)"; //555:244
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Write(__tmp30_line);
                        __tmp20_outputWritten = true;
                    }
                    if (__tmp20_outputWritten) __out.AppendLine(true);
                    if (__tmp20_outputWritten)
                    {
                        __out.AppendLine(false); //555:267
                    }
                    __out.Write("            : base(containingSymbol"); //556:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //556:37
                    {
                        __out.Write(", modelObject"); //556:94
                    }
                    __out.Write(", isError)"); //556:115
                    __out.AppendLine(false); //556:125
                    __out.Write("        {"); //557:1
                    __out.AppendLine(false); //557:10
                    __out.Write("            if (declaration is null) throw new ArgumentNullException(nameof(declaration));"); //558:1
                    __out.AppendLine(false); //558:91
                    __out.Write("            _declaration = declaration;"); //559:1
                    __out.AppendLine(false); //559:40
                    __out.Write("		}"); //560:1
                    __out.AppendLine(false); //560:4
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("MergedDeclaration")) //562:10
                {
                    __out.AppendLine(true); //563:1
                    __out.Write("        public MergedDeclaration MergedDeclaration => _declaration;"); //564:1
                    __out.AppendLine(false); //564:68
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("Locations")) //566:10
                {
                    __out.AppendLine(true); //567:1
                    __out.Write("        public override ImmutableArray<Location> Locations => _declaration.NameLocations;"); //568:1
                    __out.AppendLine(false); //568:90
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("DeclaringSyntaxReferences")) //570:10
                {
                    __out.AppendLine(true); //571:1
                    __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration.SyntaxReferences;"); //572:1
                    __out.AppendLine(false); //572:116
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetBinder")) //574:10
                {
                    __out.AppendLine(true); //575:1
                    __out.Write("        public BinderPosition<SymbolBinder> GetBinder(SyntaxReference reference)"); //576:1
                    __out.AppendLine(false); //576:81
                    __out.Write("        {"); //577:1
                    __out.AppendLine(false); //577:10
                    __out.Write("            Debug.Assert(this.DeclaringSyntaxReferences.Contains(reference));"); //578:1
                    __out.AppendLine(false); //578:78
                    __out.Write("            return FindBinders.FindSymbolBinder(this, reference);"); //579:1
                    __out.AppendLine(false); //579:66
                    __out.Write("        }"); //580:1
                    __out.AppendLine(false); //580:10
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetChildSymbol")) //582:10
                {
                    __out.AppendLine(true); //583:1
                    __out.Write("        public Symbol GetChildSymbol(SyntaxReference syntax)"); //584:1
                    __out.AppendLine(false); //584:61
                    __out.Write("        {"); //585:1
                    __out.AppendLine(false); //585:10
                    __out.Write("            foreach (var child in this.ChildSymbols)"); //586:1
                    __out.AppendLine(false); //586:53
                    __out.Write("            {"); //587:1
                    __out.AppendLine(false); //587:14
                    __out.Write("                if (child.DeclaringSyntaxReferences.Any(sr => sr.GetLocation() == syntax.GetLocation()))"); //588:1
                    __out.AppendLine(false); //588:105
                    __out.Write("                {"); //589:1
                    __out.AppendLine(false); //589:18
                    __out.Write("                    return child;"); //590:1
                    __out.AppendLine(false); //590:34
                    __out.Write("                }"); //591:1
                    __out.AppendLine(false); //591:18
                    __out.Write("            }"); //592:1
                    __out.AppendLine(false); //592:14
                    __out.Write("            return null;"); //593:1
                    __out.AppendLine(false); //593:25
                    __out.Write("        }"); //594:1
                    __out.AppendLine(false); //594:10
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetLexicalSortKey")) //596:10
                {
                    __out.Write("        public override LexicalSortKey GetLexicalSortKey()"); //597:1
                    __out.AppendLine(false); //597:59
                    __out.Write("        {"); //598:1
                    __out.AppendLine(false); //598:10
                    __out.Write("            if (!_lazyLexicalSortKey.IsInitialized)"); //599:1
                    __out.AppendLine(false); //599:52
                    __out.Write("            {"); //600:1
                    __out.AppendLine(false); //600:14
                    __out.Write("                _lazyLexicalSortKey.SetFrom(this.MergedDeclaration.GetLexicalSortKey(this.DeclaringCompilation));"); //601:1
                    __out.AppendLine(false); //601:114
                    __out.Write("            }"); //602:1
                    __out.AppendLine(false); //602:14
                    __out.Write("            return _lazyLexicalSortKey;"); //603:1
                    __out.AppendLine(false); //603:40
                    __out.Write("        }"); //604:1
                    __out.AppendLine(false); //604:10
                }
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteInitializingSymbol")) //607:10
            {
                __out.AppendLine(true); //608:1
                __out.Write("        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //609:1
                __out.AppendLine(false); //609:123
                __out.Write("        {"); //610:1
                __out.AppendLine(false); //610:10
                __out.Write("        }"); //611:1
                __out.AppendLine(false); //611:10
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteCreatingChildSymbols")) //613:10
            {
                __out.AppendLine(true); //614:1
                __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //615:1
                __out.AppendLine(false); //615:143
                __out.Write("        {"); //616:1
                __out.AppendLine(false); //616:10
                __out.Write("            return SourceSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //617:1
                __out.AppendLine(false); //617:124
                __out.Write("        }"); //618:1
                __out.AppendLine(false); //618:10
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteImports")) //620:10
            {
                __out.AppendLine(true); //621:1
                __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //622:1
                __out.AppendLine(false); //622:140
                __out.Write("        {"); //623:1
                __out.AppendLine(false); //623:10
                __out.Write("            SourceSymbolImplementation.CompleteImports(this, locationOpt, diagnostics, cancellationToken);"); //624:1
                __out.AppendLine(false); //624:107
                __out.Write("        }"); //625:1
                __out.AppendLine(false); //625:10
                __out.AppendLine(true); //626:1
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteSymbolProperty_Name")) //628:10
            {
                __out.Write("        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //629:1
                __out.AppendLine(false); //629:126
                __out.Write("        {"); //630:1
                __out.AppendLine(false); //630:10
                __out.Write("            return SourceSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //631:1
                __out.AppendLine(false); //631:133
                __out.Write("        }"); //632:1
                __out.AppendLine(false); //632:10
                __out.AppendLine(true); //633:1
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteSymbolProperty_MetadataName")) //635:10
            {
                __out.Write("        protected override string CompleteSymbolProperty_MetadataName(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //636:1
                __out.AppendLine(false); //636:134
                __out.Write("        {"); //637:1
                __out.AppendLine(false); //637:10
                __out.Write("            return SourceSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(MetadataName), diagnostics, cancellationToken);"); //638:1
                __out.AppendLine(false); //638:141
                __out.Write("        }"); //639:1
                __out.AppendLine(false); //639:10
                __out.AppendLine(true); //640:1
            }
            var __loop10_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //642:16
                where part.GenerateCompleteMethod //642:44
                select new { part = part}
                ).ToList(); //642:10
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                var __tmp31 = __loop10_results[__loop10_iteration];
                var part = __tmp31.part;
                if (!symbol.ExistingSourceTypeInfo.Members.Contains(part.CompleteMethodName)) //643:14
                {
                    bool __tmp33_outputWritten = false;
                    string __tmp34_line = "        protected override "; //644:1
                    if (!string.IsNullOrEmpty(__tmp34_line))
                    {
                        __out.Write(__tmp34_line);
                        __tmp33_outputWritten = true;
                    }
                    var __tmp35 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp35.Write(part.CompleteMethodReturnType);
                    var __tmp35Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp35.ToStringAndFree());
                    bool __tmp35_last = __tmp35Reader.EndOfStream;
                    while(!__tmp35_last)
                    {
                        ReadOnlySpan<char> __tmp35_line = __tmp35Reader.ReadLine();
                        __tmp35_last = __tmp35Reader.EndOfStream;
                        if (!__tmp35_last || !__tmp35_line.IsEmpty)
                        {
                            __out.Write(__tmp35_line);
                            __tmp33_outputWritten = true;
                        }
                        if (!__tmp35_last) __out.AppendLine(true);
                    }
                    string __tmp36_line = " "; //644:59
                    if (!string.IsNullOrEmpty(__tmp36_line))
                    {
                        __out.Write(__tmp36_line);
                        __tmp33_outputWritten = true;
                    }
                    var __tmp37 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp37.Write(part.CompleteMethodName);
                    var __tmp37Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp37.ToStringAndFree());
                    bool __tmp37_last = __tmp37Reader.EndOfStream;
                    while(!__tmp37_last)
                    {
                        ReadOnlySpan<char> __tmp37_line = __tmp37Reader.ReadLine();
                        __tmp37_last = __tmp37Reader.EndOfStream;
                        if (!__tmp37_last || !__tmp37_line.IsEmpty)
                        {
                            __out.Write(__tmp37_line);
                            __tmp33_outputWritten = true;
                        }
                        if (!__tmp37_last) __out.AppendLine(true);
                    }
                    string __tmp38_line = "("; //644:85
                    if (!string.IsNullOrEmpty(__tmp38_line))
                    {
                        __out.Write(__tmp38_line);
                        __tmp33_outputWritten = true;
                    }
                    var __tmp39 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp39.Write(part.CompleteMethodParamList);
                    var __tmp39Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp39.ToStringAndFree());
                    bool __tmp39_last = __tmp39Reader.EndOfStream;
                    while(!__tmp39_last)
                    {
                        ReadOnlySpan<char> __tmp39_line = __tmp39Reader.ReadLine();
                        __tmp39_last = __tmp39Reader.EndOfStream;
                        if (!__tmp39_last || !__tmp39_line.IsEmpty)
                        {
                            __out.Write(__tmp39_line);
                            __tmp33_outputWritten = true;
                        }
                        if (!__tmp39_last) __out.AppendLine(true);
                    }
                    string __tmp40_line = ")"; //644:116
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Write(__tmp40_line);
                        __tmp33_outputWritten = true;
                    }
                    if (__tmp33_outputWritten) __out.AppendLine(true);
                    if (__tmp33_outputWritten)
                    {
                        __out.AppendLine(false); //644:117
                    }
                    __out.Write("        {"); //645:1
                    __out.AppendLine(false); //645:10
                    if (part is SymbolPropertyGenerationInfo) //646:14
                    {
                        var prop = (SymbolPropertyGenerationInfo)part; //647:18
                        if (prop.IsCollection) //648:18
                        {
                            bool __tmp42_outputWritten = false;
                            string __tmp43_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValues<"; //649:1
                            if (!string.IsNullOrEmpty(__tmp43_line))
                            {
                                __out.Write(__tmp43_line);
                                __tmp42_outputWritten = true;
                            }
                            var __tmp44 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp44.Write(prop.ItemType);
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
                            string __tmp45_line = ">(this, nameof("; //649:89
                            if (!string.IsNullOrEmpty(__tmp45_line))
                            {
                                __out.Write(__tmp45_line);
                                __tmp42_outputWritten = true;
                            }
                            var __tmp46 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp46.Write(prop.Name);
                            var __tmp46Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp46.ToStringAndFree());
                            bool __tmp46_last = __tmp46Reader.EndOfStream;
                            while(!__tmp46_last)
                            {
                                ReadOnlySpan<char> __tmp46_line = __tmp46Reader.ReadLine();
                                __tmp46_last = __tmp46Reader.EndOfStream;
                                if (!__tmp46_last || !__tmp46_line.IsEmpty)
                                {
                                    __out.Write(__tmp46_line);
                                    __tmp42_outputWritten = true;
                                }
                                if (!__tmp46_last) __out.AppendLine(true);
                            }
                            string __tmp47_line = "), diagnostics, cancellationToken);"; //649:115
                            if (!string.IsNullOrEmpty(__tmp47_line))
                            {
                                __out.Write(__tmp47_line);
                                __tmp42_outputWritten = true;
                            }
                            if (__tmp42_outputWritten) __out.AppendLine(true);
                            if (__tmp42_outputWritten)
                            {
                                __out.AppendLine(false); //649:150
                            }
                        }
                        else //650:18
                        {
                            bool __tmp49_outputWritten = false;
                            string __tmp50_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValue<"; //651:1
                            if (!string.IsNullOrEmpty(__tmp50_line))
                            {
                                __out.Write(__tmp50_line);
                                __tmp49_outputWritten = true;
                            }
                            var __tmp51 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp51.Write(prop.Type);
                            var __tmp51Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp51.ToStringAndFree());
                            bool __tmp51_last = __tmp51Reader.EndOfStream;
                            while(!__tmp51_last)
                            {
                                ReadOnlySpan<char> __tmp51_line = __tmp51Reader.ReadLine();
                                __tmp51_last = __tmp51Reader.EndOfStream;
                                if (!__tmp51_last || !__tmp51_line.IsEmpty)
                                {
                                    __out.Write(__tmp51_line);
                                    __tmp49_outputWritten = true;
                                }
                                if (!__tmp51_last) __out.AppendLine(true);
                            }
                            string __tmp52_line = ">(this, nameof("; //651:84
                            if (!string.IsNullOrEmpty(__tmp52_line))
                            {
                                __out.Write(__tmp52_line);
                                __tmp49_outputWritten = true;
                            }
                            var __tmp53 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp53.Write(prop.Name);
                            var __tmp53Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp53.ToStringAndFree());
                            bool __tmp53_last = __tmp53Reader.EndOfStream;
                            while(!__tmp53_last)
                            {
                                ReadOnlySpan<char> __tmp53_line = __tmp53Reader.ReadLine();
                                __tmp53_last = __tmp53Reader.EndOfStream;
                                if (!__tmp53_last || !__tmp53_line.IsEmpty)
                                {
                                    __out.Write(__tmp53_line);
                                    __tmp49_outputWritten = true;
                                }
                                if (!__tmp53_last) __out.AppendLine(true);
                            }
                            string __tmp54_line = "), diagnostics, cancellationToken);"; //651:110
                            if (!string.IsNullOrEmpty(__tmp54_line))
                            {
                                __out.Write(__tmp54_line);
                                __tmp49_outputWritten = true;
                            }
                            if (__tmp49_outputWritten) __out.AppendLine(true);
                            if (__tmp49_outputWritten)
                            {
                                __out.AppendLine(false); //651:145
                            }
                        }
                    }
                    __out.Write("        }"); //654:1
                    __out.AppendLine(false); //654:10
                }
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteNonSymbolProperties")) //657:10
            {
                __out.AppendLine(true); //658:1
                __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //659:1
                __out.AppendLine(false); //659:152
                __out.Write("        {"); //660:1
                __out.AppendLine(false); //660:10
                __out.Write("            SourceSymbolImplementation.AssignNonSymbolProperties(this, diagnostics, cancellationToken);"); //661:1
                __out.AppendLine(false); //661:104
                __out.Write("        }"); //662:1
                __out.AppendLine(false); //662:10
            }
            __out.AppendLine(true); //664:1
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //665:10
            {
                bool __tmp56_outputWritten = false;
                string __tmp57_line = "        public partial class Error : Source"; //666:1
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
                string __tmp59_line = ", MetaDslx.CodeAnalysis.Symbols.IErrorSymbol"; //666:57
                if (!string.IsNullOrEmpty(__tmp59_line))
                {
                    __out.Write(__tmp59_line);
                    __tmp56_outputWritten = true;
                }
                if (__tmp56_outputWritten) __out.AppendLine(true);
                if (__tmp56_outputWritten)
                {
                    __out.AppendLine(false); //666:101
                }
                __out.Write("        {"); //667:1
                __out.AppendLine(false); //667:10
                __out.Write("            private readonly string _name;"); //668:1
                __out.AppendLine(false); //668:43
                __out.Write("            private readonly string _metadataName;"); //669:1
                __out.AppendLine(false); //669:51
                __out.Write("            private DiagnosticInfo _errorInfo;"); //670:1
                __out.AppendLine(false); //670:47
                __out.Write("            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorKind _kind;"); //671:1
                __out.AppendLine(false); //671:76
                __out.Write("            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags _flags;"); //672:1
                __out.AppendLine(false); //672:84
                __out.Write("            private ImmutableArray<Symbol> _candidateSymbols;"); //673:1
                __out.AppendLine(false); //673:62
                __out.AppendLine(true); //674:1
                if (!symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //675:14
                {
                    __out.Write("            private Error(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags"); //676:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //676:243
                    {
                        __out.Write(", object? modelObject"); //676:300
                    }
                    __out.Write(")"); //676:329
                    __out.AppendLine(false); //676:330
                    __out.Write("                : base(container, declaration"); //677:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //677:47
                    {
                        __out.Write(", modelObject"); //677:104
                    }
                    __out.Write(", true)"); //677:125
                    __out.AppendLine(false); //677:132
                    __out.Write("            {"); //678:1
                    __out.AppendLine(false); //678:14
                    __out.Write("                Debug.Assert(!flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported) || errorInfo != null);"); //679:1
                    __out.AppendLine(false); //679:126
                    __out.Write("                _name = declaration.Name;"); //680:1
                    __out.AppendLine(false); //680:42
                    __out.Write("                _metadataName = declaration.MetadataName;"); //681:1
                    __out.AppendLine(false); //681:58
                    __out.Write("                _kind = kind;"); //682:1
                    __out.AppendLine(false); //682:30
                    __out.Write("                _errorInfo = errorInfo;"); //683:1
                    __out.AppendLine(false); //683:40
                    __out.Write("                _candidateSymbols = candidateSymbols;"); //684:1
                    __out.AppendLine(false); //684:54
                    __out.Write("                _flags = flags;"); //685:1
                    __out.AppendLine(false); //685:32
                    __out.Write("            }"); //686:1
                    __out.AppendLine(false); //686:14
                    __out.Write("            public Error(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported"); //688:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //688:205
                    {
                        __out.Write(", object? modelObject"); //688:262
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //688:284
                        {
                            __out.Write(" = null"); //688:341
                        }
                    }
                    __out.Write(")"); //688:364
                    __out.AppendLine(false); //688:365
                    __out.Write("                : this(container, declaration, kind, errorInfo, candidateSymbols, unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.None"); //689:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //689:208
                    {
                        __out.Write(", modelObject"); //689:265
                    }
                    __out.Write(")"); //689:286
                    __out.AppendLine(false); //689:287
                    __out.Write("            {"); //690:1
                    __out.AppendLine(false); //690:14
                    __out.Write("            }"); //691:1
                    __out.AppendLine(false); //691:14
                    __out.Write("            public Error(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported"); //693:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //693:137
                    {
                        __out.Write(", object? modelObject"); //693:194
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //693:216
                        {
                            __out.Write(" = null"); //693:273
                        }
                    }
                    __out.Write(")"); //693:296
                    __out.AppendLine(false); //693:297
                    __out.Write("                : this(wrappedSymbol.ContainingSymbol, (wrappedSymbol as ISourceSymbol).MergedDeclaration, kind, errorInfo, ImmutableArray.Create<Symbol>(wrappedSymbol), unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.UnreportedWrapped : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Wrapped"); //694:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //694:306
                    {
                        __out.Write(", modelObject is not null ? modelObject :  (wrappedSymbol as IModelSymbol)?.ModelObject"); //694:363
                    }
                    __out.Write(")"); //694:458
                    __out.AppendLine(false); //694:459
                    __out.Write("            {"); //695:1
                    __out.AppendLine(false); //695:14
                    __out.Write("            }"); //696:1
                    __out.AppendLine(false); //696:14
                    __out.AppendLine(true); //697:1
                    __out.Write("            protected virtual Error Update(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags"); //698:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //698:260
                    {
                        __out.Write(", object? modelObject"); //698:317
                    }
                    __out.Write(")"); //698:346
                    __out.AppendLine(false); //698:347
                    __out.Write("            {"); //699:1
                    __out.AppendLine(false); //699:14
                    __out.Write("                return new Error(container, declaration, kind, errorInfo, candidateSymbols, flags"); //700:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //700:99
                    {
                        __out.Write(", modelObject"); //700:156
                    }
                    __out.Write(");"); //700:177
                    __out.AppendLine(false); //700:179
                    __out.Write("            }"); //701:1
                    __out.AppendLine(false); //701:14
                }
                __out.AppendLine(true); //703:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsReported(DiagnosticInfo? errorInfo = null)"); //704:1
                __out.AppendLine(false); //704:101
                __out.Write("            {"); //705:1
                __out.AppendLine(false); //705:14
                __out.Write("                return this.IsUnreported ? this :"); //706:1
                __out.AppendLine(false); //706:50
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, _kind, errorInfo is null ? ErrorInfo : errorInfo, CandidateSymbols, _flags & ~MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported"); //707:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //707:211
                {
                    __out.Write(", this.ModelObject"); //707:268
                }
                __out.Write(");"); //707:294
                __out.AppendLine(false); //707:296
                __out.Write("            }"); //708:1
                __out.AppendLine(false); //708:14
                __out.AppendLine(true); //709:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsUnreported(DiagnosticInfo? errorInfo = null)"); //710:1
                __out.AppendLine(false); //710:103
                __out.Write("            {"); //711:1
                __out.AppendLine(false); //711:14
                __out.Write("                return this.IsUnreported ? this :"); //712:1
                __out.AppendLine(false); //712:50
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, _kind, errorInfo is null ? ErrorInfo : errorInfo, CandidateSymbols, _flags | MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported"); //713:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //713:210
                {
                    __out.Write(", this.ModelObject"); //713:267
                }
                __out.Write(");"); //713:293
                __out.AppendLine(false); //713:295
                __out.Write("            }"); //714:1
                __out.AppendLine(false); //714:14
                __out.AppendLine(true); //715:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind)"); //716:1
                __out.AppendLine(false); //716:109
                __out.Write("            {"); //717:1
                __out.AppendLine(false); //717:14
                __out.Write("                return _kind == kind ? this :"); //718:1
                __out.AppendLine(false); //718:46
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, kind, ErrorInfo, CandidateSymbols, _flags"); //719:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //719:117
                {
                    __out.Write(", this.ModelObject"); //719:174
                }
                __out.Write(");"); //719:200
                __out.AppendLine(false); //719:202
                __out.Write("            }"); //720:1
                __out.AppendLine(false); //720:14
                __out.AppendLine(true); //721:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, ImmutableArray<MetaDslx.CodeAnalysis.Symbols.Symbol> candidateSymbols)"); //722:1
                __out.AppendLine(false); //722:180
                __out.Write("            {"); //723:1
                __out.AppendLine(false); //723:14
                __out.Write("                return _kind == kind && CandidateSymbols == candidateSymbols ? this :"); //724:1
                __out.AppendLine(false); //724:86
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, kind, ErrorInfo, candidateSymbols, _flags"); //725:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //725:117
                {
                    __out.Write(", this.ModelObject"); //725:174
                }
                __out.Write(");"); //725:200
                __out.AppendLine(false); //725:202
                __out.Write("            }"); //726:1
                __out.AppendLine(false); //726:14
                __out.AppendLine(true); //727:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo errorInfo, ImmutableArray<MetaDslx.CodeAnalysis.Symbols.Symbol> candidateSymbols)"); //728:1
                __out.AppendLine(false); //728:206
                __out.Write("            {"); //729:1
                __out.AppendLine(false); //729:14
                __out.Write("                return _kind == kind && ErrorInfo == errorInfo && CandidateSymbols == candidateSymbols ? this :"); //730:1
                __out.AppendLine(false); //730:112
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, kind, errorInfo, candidateSymbols, _flags"); //731:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //731:117
                {
                    __out.Write(", this.ModelObject"); //731:174
                }
                __out.Write(");"); //731:200
                __out.AppendLine(false); //731:202
                __out.Write("            }"); //732:1
                __out.AppendLine(false); //732:14
                __out.AppendLine(true); //733:1
                __out.Write("            public override string Name => _name;"); //734:1
                __out.AppendLine(false); //734:50
                __out.AppendLine(true); //735:1
                __out.Write("            public override string MetadataName => _metadataName;"); //736:1
                __out.AppendLine(false); //736:66
                __out.AppendLine(true); //737:1
                __out.Write("            public sealed override bool IsError => true;"); //738:1
                __out.AppendLine(false); //738:57
                __out.AppendLine(true); //739:1
                __out.Write("            public bool IsUnreported => _flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported);"); //740:1
                __out.AppendLine(false); //740:115
                __out.AppendLine(true); //741:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.ErrorKind ErrorKind => _kind;"); //742:1
                __out.AppendLine(false); //742:79
                __out.AppendLine(true); //743:1
                __out.Write("            public ImmutableArray<Symbol> CandidateSymbols"); //744:1
                __out.AppendLine(false); //744:59
                __out.Write("            {"); //745:1
                __out.AppendLine(false); //745:14
                __out.Write("                get"); //746:1
                __out.AppendLine(false); //746:20
                __out.Write("                {"); //747:1
                __out.AppendLine(false); //747:18
                __out.Write("                    if (_candidateSymbols.IsDefault)"); //748:1
                __out.AppendLine(false); //748:53
                __out.Write("                    {"); //749:1
                __out.AppendLine(false); //749:22
                __out.Write("                        System.Collections.Immutable.ImmutableInterlocked.InterlockedInitialize(ref _candidateSymbols, MakeCandidateSymbols());"); //750:1
                __out.AppendLine(false); //750:144
                __out.Write("                    }"); //751:1
                __out.AppendLine(false); //751:22
                __out.Write("                    return _candidateSymbols;"); //752:1
                __out.AppendLine(false); //752:46
                __out.Write("                }"); //753:1
                __out.AppendLine(false); //753:18
                __out.Write("            }"); //754:1
                __out.AppendLine(false); //754:14
                __out.AppendLine(true); //755:1
                __out.Write("            public DiagnosticInfo? ErrorInfo"); //756:1
                __out.AppendLine(false); //756:45
                __out.Write("            {"); //757:1
                __out.AppendLine(false); //757:14
                __out.Write("                get"); //758:1
                __out.AppendLine(false); //758:20
                __out.Write("                {"); //759:1
                __out.AppendLine(false); //759:18
                __out.Write("                    if (_errorInfo is null)"); //760:1
                __out.AppendLine(false); //760:44
                __out.Write("                    {"); //761:1
                __out.AppendLine(false); //761:22
                __out.Write("                        System.Threading.Interlocked.CompareExchange(ref _errorInfo, MakeErrorInfo(), null);"); //762:1
                __out.AppendLine(false); //762:109
                __out.Write("                    }"); //763:1
                __out.AppendLine(false); //763:22
                __out.Write("                    return _errorInfo;"); //764:1
                __out.AppendLine(false); //764:39
                __out.Write("                }"); //765:1
                __out.AppendLine(false); //765:18
                __out.Write("            }"); //766:1
                __out.AppendLine(false); //766:14
                __out.AppendLine(true); //767:1
                __out.Write("            public DiagnosticInfo? UseSiteDiagnosticInfo => IsUnreported ? ErrorInfo : null;"); //768:1
                __out.AppendLine(false); //768:93
                __out.AppendLine(true); //769:1
                __out.Write("            protected virtual DiagnosticInfo? MakeErrorInfo()"); //770:1
                __out.AppendLine(false); //770:62
                __out.Write("            {"); //771:1
                __out.AppendLine(false); //771:14
                __out.Write("                return null;"); //772:1
                __out.AppendLine(false); //772:29
                __out.Write("            }"); //773:1
                __out.AppendLine(false); //773:14
                __out.AppendLine(true); //774:1
                __out.Write("            protected virtual ImmutableArray<Symbol> MakeCandidateSymbols()"); //775:1
                __out.AppendLine(false); //775:76
                __out.Write("            {"); //776:1
                __out.AppendLine(false); //776:14
                __out.Write("                return ImmutableArray<Symbol>.Empty;"); //777:1
                __out.AppendLine(false); //777:53
                __out.Write("            }"); //778:1
                __out.AppendLine(false); //778:14
                __out.AppendLine(true); //779:1
                __out.Write("            protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //780:1
                __out.AppendLine(false); //780:130
                __out.Write("            {"); //781:1
                __out.AppendLine(false); //781:14
                __out.Write("                return _name;"); //782:1
                __out.AppendLine(false); //782:30
                __out.Write("            }"); //783:1
                __out.AppendLine(false); //783:14
                __out.Write("        }"); //784:1
                __out.AppendLine(false); //784:10
            }
            __out.Write("	}"); //786:1
            __out.AppendLine(false); //786:3
            __out.Write("}"); //787:1
            __out.AppendLine(false); //787:2
            return __out.ToStringAndFree();
        }

        public string GenerateWrappedSymbol(SymbolGenerationInfo symbol) //790:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //791:1
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
            string __tmp5_line = ".Wrapped"; //791:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //791:41
            }
            __out.Write("{"); //792:1
            __out.AppendLine(false); //792:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Wrapped"; //793:1
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
            string __tmp10_line = " : "; //793:43
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
            string __tmp12_line = ".Completion.Completion"; //793:68
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
                __out.AppendLine(false); //793:103
            }
            __out.Write("	{"); //794:1
            __out.AppendLine(false); //794:3
            bool __tmp15_outputWritten = false;
            string __tmp16_line = "        private readonly "; //795:1
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
            string __tmp18_line = "."; //795:48
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
            string __tmp20_line = " _wrappedSymbol;"; //795:62
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Write(__tmp20_line);
                __tmp15_outputWritten = true;
            }
            if (__tmp15_outputWritten) __out.AppendLine(true);
            if (__tmp15_outputWritten)
            {
                __out.AppendLine(false); //795:78
            }
            bool __tmp22_outputWritten = false;
            string __tmp23_line = "        public Wrapped"; //797:1
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
            string __tmp25_line = "("; //797:36
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
            string __tmp27_line = "."; //797:59
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
            string __tmp29_line = " wrappedSymbol)"; //797:73
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Write(__tmp29_line);
                __tmp22_outputWritten = true;
            }
            if (__tmp22_outputWritten) __out.AppendLine(true);
            if (__tmp22_outputWritten)
            {
                __out.AppendLine(false); //797:88
            }
            __out.Write("            : base(wrappedSymbol.ContainingSymbol"); //798:1
            if (symbol.ModelObjectOption != ParameterOption.Disabled) //798:51
            {
                __out.Write(", ((IModelSymbol)wrappedSymbol).ModelObject"); //798:108
            }
            __out.Write(", wrappedSymbol.IsError)"); //798:159
            __out.AppendLine(false); //798:183
            __out.Write("        {"); //799:1
            __out.AppendLine(false); //799:10
            __out.Write("            _wrappedSymbol = wrappedSymbol;"); //800:1
            __out.AppendLine(false); //800:44
            __out.Write("        }"); //801:1
            __out.AppendLine(false); //801:10
            __out.AppendLine(true); //802:1
            __out.Write("        public override ImmutableArray<Location> Locations => _wrappedSymbol.Locations;"); //803:1
            __out.AppendLine(false); //803:88
            __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _wrappedSymbol.DeclaringSyntaxReferences;"); //804:1
            __out.AppendLine(false); //804:127
            __out.AppendLine(true); //805:1
            __out.Write("        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //806:1
            __out.AppendLine(false); //806:126
            __out.Write("        {"); //807:1
            __out.AppendLine(false); //807:10
            __out.Write("            return _wrappedSymbol.Name;"); //808:1
            __out.AppendLine(false); //808:40
            __out.Write("        }"); //809:1
            __out.AppendLine(false); //809:10
            __out.AppendLine(true); //810:1
            __out.Write("        protected override string CompleteSymbolProperty_MetadataName(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //811:1
            __out.AppendLine(false); //811:134
            __out.Write("        {"); //812:1
            __out.AppendLine(false); //812:10
            __out.Write("            return _wrappedSymbol.MetadataName;"); //813:1
            __out.AppendLine(false); //813:48
            __out.Write("        }"); //814:1
            __out.AppendLine(false); //814:10
            __out.AppendLine(true); //815:1
            __out.Write("        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //816:1
            __out.AppendLine(false); //816:123
            __out.Write("        {"); //817:1
            __out.AppendLine(false); //817:10
            __out.Write("            _wrappedSymbol.CompleteInitializingSymbol(diagnostics, cancellationToken);"); //818:1
            __out.AppendLine(false); //818:87
            __out.Write("        }"); //819:1
            __out.AppendLine(false); //819:10
            __out.AppendLine(true); //820:1
            __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //821:1
            __out.AppendLine(false); //821:143
            __out.Write("        {"); //822:1
            __out.AppendLine(false); //822:10
            __out.Write("            return _wrappedSymbol.CompleteCreatingChildSymbols(diagnostics, cancellationToken);"); //823:1
            __out.AppendLine(false); //823:96
            __out.Write("        }"); //824:1
            __out.AppendLine(false); //824:10
            __out.AppendLine(true); //825:1
            __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //826:1
            __out.AppendLine(false); //826:140
            __out.Write("        {"); //827:1
            __out.AppendLine(false); //827:10
            __out.Write("            _wrappedSymbol.CompleteImports(locationOpt, diagnostics, cancellationToken);"); //828:1
            __out.AppendLine(false); //828:89
            __out.Write("        }"); //829:1
            __out.AppendLine(false); //829:10
            var __loop11_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //830:16
                where part.GenerateCompleteMethod //830:44
                select new { part = part}
                ).ToList(); //830:10
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp30 = __loop11_results[__loop11_iteration];
                var part = __tmp30.part;
                __out.AppendLine(true); //831:1
                bool __tmp32_outputWritten = false;
                string __tmp33_line = "        protected override "; //832:1
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
                string __tmp35_line = " "; //832:59
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
                string __tmp37_line = "("; //832:85
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
                string __tmp39_line = ")"; //832:116
                if (!string.IsNullOrEmpty(__tmp39_line))
                {
                    __out.Write(__tmp39_line);
                    __tmp32_outputWritten = true;
                }
                if (__tmp32_outputWritten) __out.AppendLine(true);
                if (__tmp32_outputWritten)
                {
                    __out.AppendLine(false); //832:117
                }
                __out.Write("        {"); //833:1
                __out.AppendLine(false); //833:10
                bool __tmp41_outputWritten = false;
                string __tmp40Prefix = "            "; //834:1
                if (part.CompleteMethodReturnType != "void") //834:14
                {
                    if (!string.IsNullOrEmpty(__tmp40Prefix))
                    {
                        __out.Write(__tmp40Prefix);
                        __tmp41_outputWritten = true;
                    }
                    string __tmp43_line = "return "; //834:59
                    if (!string.IsNullOrEmpty(__tmp43_line))
                    {
                        __out.Write(__tmp43_line);
                        __tmp41_outputWritten = true;
                    }
                }
                string __tmp45_line = "_wrappedSymbol."; //834:74
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
                string __tmp47_line = "("; //834:114
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
                string __tmp49_line = ");"; //834:143
                if (!string.IsNullOrEmpty(__tmp49_line))
                {
                    __out.Write(__tmp49_line);
                    __tmp41_outputWritten = true;
                }
                if (__tmp41_outputWritten) __out.AppendLine(true);
                if (__tmp41_outputWritten)
                {
                    __out.AppendLine(false); //834:145
                }
                __out.Write("        }"); //835:1
                __out.AppendLine(false); //835:10
            }
            __out.AppendLine(true); //837:1
            __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //838:1
            __out.AppendLine(false); //838:152
            __out.Write("        {"); //839:1
            __out.AppendLine(false); //839:10
            __out.Write("            _wrappedSymbol.CompleteNonSymbolProperties(locationOpt, diagnostics, cancellationToken);"); //840:1
            __out.AppendLine(false); //840:101
            __out.Write("        }"); //841:1
            __out.AppendLine(false); //841:10
            __out.Write("    }"); //842:1
            __out.AppendLine(false); //842:6
            __out.Write("}"); //843:1
            __out.AppendLine(false); //843:2
            return __out.ToStringAndFree();
        }

        public string GenerateVisitor(string namespaceName, IEnumerable<SymbolGenerationInfo> symbols) //846:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //847:1
            __out.AppendLine(false); //847:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //848:1
            __out.AppendLine(false); //848:29
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //849:1
            __out.AppendLine(false); //849:37
            __out.Write("using System;"); //850:1
            __out.AppendLine(false); //850:14
            __out.Write("using System.Collections.Generic;"); //851:1
            __out.AppendLine(false); //851:34
            __out.Write("using System.Collections.Immutable;"); //852:1
            __out.AppendLine(false); //852:36
            __out.Write("using System.Diagnostics;"); //853:1
            __out.AppendLine(false); //853:26
            __out.Write("using System.Text;"); //854:1
            __out.AppendLine(false); //854:19
            __out.Write("using System.Threading;"); //855:1
            __out.AppendLine(false); //855:24
            __out.AppendLine(true); //856:1
            __out.Write("#nullable enable"); //857:1
            __out.AppendLine(false); //857:17
            __out.AppendLine(true); //858:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //859:1
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
                __out.AppendLine(false); //859:26
            }
            __out.Write("{"); //860:1
            __out.AppendLine(false); //860:2
            __out.Write("	public interface ISymbolVisitor"); //861:1
            __out.AppendLine(false); //861:33
            __out.Write("	{"); //862:1
            __out.AppendLine(false); //862:3
            var __loop12_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //863:16
                where !symbol.IsAbstract //863:32
                select new { symbol = symbol}
                ).ToList(); //863:10
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp5 = __loop12_results[__loop12_iteration];
                var symbol = __tmp5.symbol;
                bool __tmp7_outputWritten = false;
                string __tmp8_line = "        void Visit("; //864:1
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
                string __tmp10_line = " symbol);"; //864:33
                if (!string.IsNullOrEmpty(__tmp10_line))
                {
                    __out.Write(__tmp10_line);
                    __tmp7_outputWritten = true;
                }
                if (__tmp7_outputWritten) __out.AppendLine(true);
                if (__tmp7_outputWritten)
                {
                    __out.AppendLine(false); //864:42
                }
            }
            __out.Write("	}"); //866:1
            __out.AppendLine(false); //866:3
            __out.AppendLine(true); //867:1
            __out.Write("	public interface ISymbolVisitor<TResult>"); //868:1
            __out.AppendLine(false); //868:42
            __out.Write("	{"); //869:1
            __out.AppendLine(false); //869:3
            var __loop13_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //870:16
                where !symbol.IsAbstract //870:32
                select new { symbol = symbol}
                ).ToList(); //870:10
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp11 = __loop13_results[__loop13_iteration];
                var symbol = __tmp11.symbol;
                bool __tmp13_outputWritten = false;
                string __tmp14_line = "        TResult Visit("; //871:1
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
                string __tmp16_line = " symbol);"; //871:36
                if (!string.IsNullOrEmpty(__tmp16_line))
                {
                    __out.Write(__tmp16_line);
                    __tmp13_outputWritten = true;
                }
                if (__tmp13_outputWritten) __out.AppendLine(true);
                if (__tmp13_outputWritten)
                {
                    __out.AppendLine(false); //871:45
                }
            }
            __out.Write("	}"); //873:1
            __out.AppendLine(false); //873:3
            __out.AppendLine(true); //874:1
            __out.Write("	public interface ISymbolVisitor<TArgument, TResult>"); //875:1
            __out.AppendLine(false); //875:53
            __out.Write("	{"); //876:1
            __out.AppendLine(false); //876:3
            var __loop14_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //877:16
                where !symbol.IsAbstract //877:32
                select new { symbol = symbol}
                ).ToList(); //877:10
            for (int __loop14_iteration = 0; __loop14_iteration < __loop14_results.Count; ++__loop14_iteration)
            {
                var __tmp17 = __loop14_results[__loop14_iteration];
                var symbol = __tmp17.symbol;
                bool __tmp19_outputWritten = false;
                string __tmp20_line = "        TResult Visit("; //878:1
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
                string __tmp22_line = " symbol, TArgument argument);"; //878:36
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Write(__tmp22_line);
                    __tmp19_outputWritten = true;
                }
                if (__tmp19_outputWritten) __out.AppendLine(true);
                if (__tmp19_outputWritten)
                {
                    __out.AppendLine(false); //878:65
                }
            }
            __out.Write("	}"); //880:1
            __out.AppendLine(false); //880:3
            __out.Write("}"); //881:1
            __out.AppendLine(false); //881:2
            return __out.ToStringAndFree();
        }

        public string GenerateFactory(string namespaceName, IEnumerable<SymbolGenerationInfo> symbols) //884:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //885:1
            __out.AppendLine(false); //885:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //886:1
            __out.AppendLine(false); //886:29
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //887:1
            __out.AppendLine(false); //887:37
            __out.Write("using System;"); //888:1
            __out.AppendLine(false); //888:14
            __out.Write("using System.Collections.Generic;"); //889:1
            __out.AppendLine(false); //889:34
            __out.Write("using System.Collections.Immutable;"); //890:1
            __out.AppendLine(false); //890:36
            __out.Write("using System.Diagnostics;"); //891:1
            __out.AppendLine(false); //891:26
            __out.Write("using System.Text;"); //892:1
            __out.AppendLine(false); //892:19
            __out.Write("using System.Threading;"); //893:1
            __out.AppendLine(false); //893:24
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //894:1
            __out.AppendLine(false); //894:42
            __out.AppendLine(true); //895:1
            __out.Write("#nullable enable"); //896:1
            __out.AppendLine(false); //896:17
            __out.AppendLine(true); //897:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //898:1
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
            string __tmp5_line = ".Factory"; //898:26
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //898:34
            }
            __out.Write("{"); //899:1
            __out.AppendLine(false); //899:2
            var __loop15_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //900:12
                where !symbol.IsAbstract && symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol" && symbol.SymbolParts != SymbolParts.None //900:28
                select new { symbol = symbol}
                ).ToList(); //900:6
            for (int __loop15_iteration = 0; __loop15_iteration < __loop15_results.Count; ++__loop15_iteration)
            {
                var __tmp6 = __loop15_results[__loop15_iteration];
                var symbol = __tmp6.symbol;
                bool __tmp8_outputWritten = false;
                string __tmp9_line = "	public class "; //901:1
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
                string __tmp11_line = "Factory : IGeneratedSymbolFactory"; //901:28
                if (!string.IsNullOrEmpty(__tmp11_line))
                {
                    __out.Write(__tmp11_line);
                    __tmp8_outputWritten = true;
                }
                if (__tmp8_outputWritten) __out.AppendLine(true);
                if (__tmp8_outputWritten)
                {
                    __out.AppendLine(false); //901:61
                }
                __out.Write("	{"); //902:1
                __out.AppendLine(false); //902:3
                __out.Write("        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)"); //903:1
                __out.AppendLine(false); //903:83
                __out.Write("        {"); //904:1
                __out.AppendLine(false); //904:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Metadata)) //905:14
                {
                    bool __tmp13_outputWritten = false;
                    string __tmp14_line = "            throw new NotImplementedException(\"There is no Metadata"; //906:1
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
                    string __tmp16_line = " implemented.\");"; //906:81
                    if (!string.IsNullOrEmpty(__tmp16_line))
                    {
                        __out.Write(__tmp16_line);
                        __tmp13_outputWritten = true;
                    }
                    if (__tmp13_outputWritten) __out.AppendLine(true);
                    if (__tmp13_outputWritten)
                    {
                        __out.AppendLine(false); //906:97
                    }
                }
                else if (symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //907:14
                {
                    bool __tmp18_outputWritten = false;
                    string __tmp19_line = "            throw new NotImplementedException(\"CreateMetadataSymbol for Metadata"; //908:1
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
                    string __tmp21_line = " should be implemented in a custom SymbolFactory.\");"; //908:94
                    if (!string.IsNullOrEmpty(__tmp21_line))
                    {
                        __out.Write(__tmp21_line);
                        __tmp18_outputWritten = true;
                    }
                    if (__tmp18_outputWritten) __out.AppendLine(true);
                    if (__tmp18_outputWritten)
                    {
                        __out.AppendLine(false); //908:146
                    }
                }
                else //909:14
                {
                    bool __tmp23_outputWritten = false;
                    string __tmp24_line = "            return new Metadata.Metadata"; //910:1
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
                    string __tmp26_line = "(container"; //910:54
                    if (!string.IsNullOrEmpty(__tmp26_line))
                    {
                        __out.Write(__tmp26_line);
                        __tmp23_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //910:65
                    {
                        string __tmp28_line = ", modelObject"; //910:122
                        if (!string.IsNullOrEmpty(__tmp28_line))
                        {
                            __out.Write(__tmp28_line);
                            __tmp23_outputWritten = true;
                        }
                    }
                    string __tmp30_line = ");"; //910:143
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Write(__tmp30_line);
                        __tmp23_outputWritten = true;
                    }
                    if (__tmp23_outputWritten) __out.AppendLine(true);
                    if (__tmp23_outputWritten)
                    {
                        __out.AppendLine(false); //910:145
                    }
                }
                __out.Write("        }"); //912:1
                __out.AppendLine(false); //912:10
                __out.AppendLine(true); //913:1
                __out.Write("        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)"); //914:1
                __out.AppendLine(false); //914:253
                __out.Write("        {"); //915:1
                __out.AppendLine(false); //915:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Metadata)) //916:14
                {
                    bool __tmp32_outputWritten = false;
                    string __tmp33_line = "            throw new NotImplementedException(\"There is no Metadata"; //917:1
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
                    string __tmp35_line = " implemented.\");"; //917:81
                    if (!string.IsNullOrEmpty(__tmp35_line))
                    {
                        __out.Write(__tmp35_line);
                        __tmp32_outputWritten = true;
                    }
                    if (__tmp32_outputWritten) __out.AppendLine(true);
                    if (__tmp32_outputWritten)
                    {
                        __out.AppendLine(false); //917:97
                    }
                }
                else if (symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //918:14
                {
                    bool __tmp37_outputWritten = false;
                    string __tmp38_line = "            throw new NotImplementedException(\"CreateMetadataSymbol for Metadata"; //919:1
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
                    string __tmp40_line = " should be implemented in a custom SymbolFactory.\");"; //919:94
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Write(__tmp40_line);
                        __tmp37_outputWritten = true;
                    }
                    if (__tmp37_outputWritten) __out.AppendLine(true);
                    if (__tmp37_outputWritten)
                    {
                        __out.AppendLine(false); //919:146
                    }
                }
                else //920:14
                {
                    bool __tmp42_outputWritten = false;
                    string __tmp43_line = "            return new Metadata.Metadata"; //921:1
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
                    string __tmp45_line = ".Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported"; //921:54
                    if (!string.IsNullOrEmpty(__tmp45_line))
                    {
                        __out.Write(__tmp45_line);
                        __tmp42_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //921:138
                    {
                        string __tmp47_line = ", modelObject"; //921:195
                        if (!string.IsNullOrEmpty(__tmp47_line))
                        {
                            __out.Write(__tmp47_line);
                            __tmp42_outputWritten = true;
                        }
                    }
                    string __tmp49_line = ");"; //921:216
                    if (!string.IsNullOrEmpty(__tmp49_line))
                    {
                        __out.Write(__tmp49_line);
                        __tmp42_outputWritten = true;
                    }
                    if (__tmp42_outputWritten) __out.AppendLine(true);
                    if (__tmp42_outputWritten)
                    {
                        __out.AppendLine(false); //921:218
                    }
                }
                __out.Write("        }"); //923:1
                __out.AppendLine(false); //923:10
                __out.AppendLine(true); //924:1
                __out.Write("        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)"); //925:1
                __out.AppendLine(false); //925:182
                __out.Write("        {"); //926:1
                __out.AppendLine(false); //926:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Metadata)) //927:14
                {
                    bool __tmp51_outputWritten = false;
                    string __tmp52_line = "            throw new NotImplementedException(\"There is no Metadata"; //928:1
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
                    string __tmp54_line = " implemented.\");"; //928:81
                    if (!string.IsNullOrEmpty(__tmp54_line))
                    {
                        __out.Write(__tmp54_line);
                        __tmp51_outputWritten = true;
                    }
                    if (__tmp51_outputWritten) __out.AppendLine(true);
                    if (__tmp51_outputWritten)
                    {
                        __out.AppendLine(false); //928:97
                    }
                }
                else if (symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //929:14
                {
                    bool __tmp56_outputWritten = false;
                    string __tmp57_line = "            throw new NotImplementedException(\"CreateMetadataSymbol for Metadata"; //930:1
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
                    string __tmp59_line = " should be implemented in a custom SymbolFactory.\");"; //930:94
                    if (!string.IsNullOrEmpty(__tmp59_line))
                    {
                        __out.Write(__tmp59_line);
                        __tmp56_outputWritten = true;
                    }
                    if (__tmp56_outputWritten) __out.AppendLine(true);
                    if (__tmp56_outputWritten)
                    {
                        __out.AppendLine(false); //930:146
                    }
                }
                else //931:14
                {
                    bool __tmp61_outputWritten = false;
                    string __tmp62_line = "            return new Metadata.Metadata"; //932:1
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
                    string __tmp64_line = ".Error(wrappedSymbol, kind, errorInfo, unreported"; //932:54
                    if (!string.IsNullOrEmpty(__tmp64_line))
                    {
                        __out.Write(__tmp64_line);
                        __tmp61_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //932:104
                    {
                        string __tmp66_line = ", modelObject"; //932:161
                        if (!string.IsNullOrEmpty(__tmp66_line))
                        {
                            __out.Write(__tmp66_line);
                            __tmp61_outputWritten = true;
                        }
                    }
                    string __tmp68_line = ");"; //932:182
                    if (!string.IsNullOrEmpty(__tmp68_line))
                    {
                        __out.Write(__tmp68_line);
                        __tmp61_outputWritten = true;
                    }
                    if (__tmp61_outputWritten) __out.AppendLine(true);
                    if (__tmp61_outputWritten)
                    {
                        __out.AppendLine(false); //932:184
                    }
                }
                __out.Write("        }"); //934:1
                __out.AppendLine(false); //934:10
                __out.AppendLine(true); //935:1
                __out.Write("        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)"); //936:1
                __out.AppendLine(false); //936:112
                __out.Write("        {"); //937:1
                __out.AppendLine(false); //937:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Source)) //938:14
                {
                    bool __tmp70_outputWritten = false;
                    string __tmp71_line = "            throw new NotImplementedException(\"There is no Source"; //939:1
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
                    string __tmp73_line = " implemented.\");"; //939:79
                    if (!string.IsNullOrEmpty(__tmp73_line))
                    {
                        __out.Write(__tmp73_line);
                        __tmp70_outputWritten = true;
                    }
                    if (__tmp70_outputWritten) __out.AppendLine(true);
                    if (__tmp70_outputWritten)
                    {
                        __out.AppendLine(false); //939:95
                    }
                }
                else if (symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //940:14
                {
                    bool __tmp75_outputWritten = false;
                    string __tmp76_line = "            throw new NotImplementedException(\"CreateSourceSymbol for Source"; //941:1
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
                    string __tmp78_line = " should be implemented in a custom SymbolFactory.\");"; //941:90
                    if (!string.IsNullOrEmpty(__tmp78_line))
                    {
                        __out.Write(__tmp78_line);
                        __tmp75_outputWritten = true;
                    }
                    if (__tmp75_outputWritten) __out.AppendLine(true);
                    if (__tmp75_outputWritten)
                    {
                        __out.AppendLine(false); //941:142
                    }
                }
                else //942:14
                {
                    bool __tmp80_outputWritten = false;
                    string __tmp81_line = "            return new Source.Source"; //943:1
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
                    string __tmp83_line = "(container, declaration"; //943:50
                    if (!string.IsNullOrEmpty(__tmp83_line))
                    {
                        __out.Write(__tmp83_line);
                        __tmp80_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //943:74
                    {
                        string __tmp85_line = ", modelObject"; //943:131
                        if (!string.IsNullOrEmpty(__tmp85_line))
                        {
                            __out.Write(__tmp85_line);
                            __tmp80_outputWritten = true;
                        }
                    }
                    string __tmp87_line = ");"; //943:152
                    if (!string.IsNullOrEmpty(__tmp87_line))
                    {
                        __out.Write(__tmp87_line);
                        __tmp80_outputWritten = true;
                    }
                    if (__tmp80_outputWritten) __out.AppendLine(true);
                    if (__tmp80_outputWritten)
                    {
                        __out.AppendLine(false); //943:154
                    }
                }
                __out.Write("        }"); //945:1
                __out.AppendLine(false); //945:10
                __out.AppendLine(true); //946:1
                __out.Write("        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)"); //947:1
                __out.AppendLine(false); //947:248
                __out.Write("        {"); //948:1
                __out.AppendLine(false); //948:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Source)) //949:14
                {
                    bool __tmp89_outputWritten = false;
                    string __tmp90_line = "            throw new NotImplementedException(\"There is no Source"; //950:1
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
                    string __tmp92_line = " implemented.\");"; //950:79
                    if (!string.IsNullOrEmpty(__tmp92_line))
                    {
                        __out.Write(__tmp92_line);
                        __tmp89_outputWritten = true;
                    }
                    if (__tmp89_outputWritten) __out.AppendLine(true);
                    if (__tmp89_outputWritten)
                    {
                        __out.AppendLine(false); //950:95
                    }
                }
                else if (symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //951:14
                {
                    bool __tmp94_outputWritten = false;
                    string __tmp95_line = "            throw new NotImplementedException(\"CreateSourceSymbol for Source"; //952:1
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
                    string __tmp97_line = " should be implemented in a custom SymbolFactory.\");"; //952:90
                    if (!string.IsNullOrEmpty(__tmp97_line))
                    {
                        __out.Write(__tmp97_line);
                        __tmp94_outputWritten = true;
                    }
                    if (__tmp94_outputWritten) __out.AppendLine(true);
                    if (__tmp94_outputWritten)
                    {
                        __out.AppendLine(false); //952:142
                    }
                }
                else //953:14
                {
                    bool __tmp99_outputWritten = false;
                    string __tmp100_line = "            return new Source.Source"; //954:1
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
                    string __tmp102_line = ".Error(container, declaration, kind, errorInfo, candidateSymbols, unreported"; //954:50
                    if (!string.IsNullOrEmpty(__tmp102_line))
                    {
                        __out.Write(__tmp102_line);
                        __tmp99_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //954:127
                    {
                        string __tmp104_line = ", modelObject"; //954:184
                        if (!string.IsNullOrEmpty(__tmp104_line))
                        {
                            __out.Write(__tmp104_line);
                            __tmp99_outputWritten = true;
                        }
                    }
                    string __tmp106_line = ");"; //954:205
                    if (!string.IsNullOrEmpty(__tmp106_line))
                    {
                        __out.Write(__tmp106_line);
                        __tmp99_outputWritten = true;
                    }
                    if (__tmp99_outputWritten) __out.AppendLine(true);
                    if (__tmp99_outputWritten)
                    {
                        __out.AppendLine(false); //954:207
                    }
                }
                __out.Write("        }"); //956:1
                __out.AppendLine(false); //956:10
                __out.AppendLine(true); //957:1
                __out.Write("        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)"); //958:1
                __out.AppendLine(false); //958:180
                __out.Write("        {"); //959:1
                __out.AppendLine(false); //959:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Source)) //960:14
                {
                    bool __tmp108_outputWritten = false;
                    string __tmp109_line = "            throw new NotImplementedException(\"There is no Source"; //961:1
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
                    string __tmp111_line = " implemented.\");"; //961:79
                    if (!string.IsNullOrEmpty(__tmp111_line))
                    {
                        __out.Write(__tmp111_line);
                        __tmp108_outputWritten = true;
                    }
                    if (__tmp108_outputWritten) __out.AppendLine(true);
                    if (__tmp108_outputWritten)
                    {
                        __out.AppendLine(false); //961:95
                    }
                }
                else if (symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //962:14
                {
                    bool __tmp113_outputWritten = false;
                    string __tmp114_line = "            throw new NotImplementedException(\"CreateSourceSymbol for Source"; //963:1
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
                    string __tmp116_line = " should be implemented in a custom SymbolFactory.\");"; //963:90
                    if (!string.IsNullOrEmpty(__tmp116_line))
                    {
                        __out.Write(__tmp116_line);
                        __tmp113_outputWritten = true;
                    }
                    if (__tmp113_outputWritten) __out.AppendLine(true);
                    if (__tmp113_outputWritten)
                    {
                        __out.AppendLine(false); //963:142
                    }
                }
                else //964:14
                {
                    bool __tmp118_outputWritten = false;
                    string __tmp119_line = "            return new Source.Source"; //965:1
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
                    string __tmp121_line = ".Error(wrappedSymbol, kind, errorInfo, unreported"; //965:50
                    if (!string.IsNullOrEmpty(__tmp121_line))
                    {
                        __out.Write(__tmp121_line);
                        __tmp118_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //965:100
                    {
                        string __tmp123_line = ", modelObject"; //965:157
                        if (!string.IsNullOrEmpty(__tmp123_line))
                        {
                            __out.Write(__tmp123_line);
                            __tmp118_outputWritten = true;
                        }
                    }
                    string __tmp125_line = ");"; //965:178
                    if (!string.IsNullOrEmpty(__tmp125_line))
                    {
                        __out.Write(__tmp125_line);
                        __tmp118_outputWritten = true;
                    }
                    if (__tmp118_outputWritten) __out.AppendLine(true);
                    if (__tmp118_outputWritten)
                    {
                        __out.AppendLine(false); //965:180
                    }
                }
                __out.Write("        }"); //967:1
                __out.AppendLine(false); //967:10
                __out.Write("	}"); //968:1
                __out.AppendLine(false); //968:3
                __out.AppendLine(true); //969:1
            }
            __out.Write("}"); //971:1
            __out.AppendLine(false); //971:2
            return __out.ToStringAndFree();
        }

    }
}

