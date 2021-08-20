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
            __out.AppendLine(true); //132:1
            __out.Write("        protected abstract ISymbolImplementation SymbolImplementation { get; }"); //133:1
            __out.AppendLine(false); //133:79
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ChildSymbols")) //134:10
            {
                __out.AppendLine(true); //135:1
                __out.Write("        public override ImmutableArray<Symbol> ChildSymbols "); //136:1
                __out.AppendLine(false); //136:61
                __out.Write("        {"); //137:1
                __out.AppendLine(false); //137:10
                __out.Write("            get"); //138:1
                __out.AppendLine(false); //138:16
                __out.Write("            {"); //139:1
                __out.AppendLine(false); //139:14
                __out.Write("                this.ForceComplete(CompletionGraph.FinishCreatingChildren, null, default);"); //140:1
                __out.AppendLine(false); //140:91
                __out.Write("                return _childSymbols;"); //141:1
                __out.AppendLine(false); //141:38
                __out.Write("            }"); //142:1
                __out.AppendLine(false); //142:14
                __out.Write("        }"); //143:1
                __out.AppendLine(false); //143:10
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("Name")) //145:10
            {
                __out.AppendLine(true); //146:1
                __out.Write("        public override string Name "); //147:1
                __out.AppendLine(false); //147:37
                __out.Write("        {"); //148:1
                __out.AppendLine(false); //148:10
                __out.Write("            get"); //149:1
                __out.AppendLine(false); //149:16
                __out.Write("            {"); //150:1
                __out.AppendLine(false); //150:14
                __out.Write("                this.ForceComplete(CompletionGraph.FinishInitializing, null, default);"); //151:1
                __out.AppendLine(false); //151:87
                __out.Write("                return _name;"); //152:1
                __out.AppendLine(false); //152:30
                __out.Write("            }"); //153:1
                __out.AppendLine(false); //153:14
                __out.Write("        }"); //154:1
                __out.AppendLine(false); //154:10
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("MetadataName")) //156:10
            {
                __out.AppendLine(true); //157:1
                __out.Write("        public override string MetadataName "); //158:1
                __out.AppendLine(false); //158:45
                __out.Write("        {"); //159:1
                __out.AppendLine(false); //159:10
                __out.Write("            get"); //160:1
                __out.AppendLine(false); //160:16
                __out.Write("            {"); //161:1
                __out.AppendLine(false); //161:14
                __out.Write("                this.ForceComplete(CompletionGraph.FinishInitializing, null, default);"); //162:1
                __out.AppendLine(false); //162:87
                __out.Write("                return _metadataName;"); //163:1
                __out.AppendLine(false); //163:38
                __out.Write("            }"); //164:1
                __out.AppendLine(false); //164:14
                __out.Write("        }"); //165:1
                __out.AppendLine(false); //165:10
            }
            var __loop6_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //167:16
                select new { prop = prop}
                ).ToList(); //167:10
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp39 = __loop6_results[__loop6_iteration];
                var prop = __tmp39.prop;
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains(prop.Name)) //168:14
                {
                    __out.AppendLine(true); //169:1
                    bool __tmp41_outputWritten = false;
                    string __tmp42_line = "        public override "; //170:1
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
                    string __tmp44_line = " "; //170:36
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
                        __out.AppendLine(false); //170:48
                    }
                    __out.Write("        {"); //171:1
                    __out.AppendLine(false); //171:10
                    __out.Write("            get"); //172:1
                    __out.AppendLine(false); //172:16
                    __out.Write("            {"); //173:1
                    __out.AppendLine(false); //173:14
                    bool __tmp47_outputWritten = false;
                    string __tmp48_line = "                this.ForceComplete(CompletionParts."; //174:1
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
                    string __tmp50_line = ", null, default);"; //174:83
                    if (!string.IsNullOrEmpty(__tmp50_line))
                    {
                        __out.Write(__tmp50_line);
                        __tmp47_outputWritten = true;
                    }
                    if (__tmp47_outputWritten) __out.AppendLine(true);
                    if (__tmp47_outputWritten)
                    {
                        __out.AppendLine(false); //174:100
                    }
                    bool __tmp52_outputWritten = false;
                    string __tmp53_line = "                return "; //175:1
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
                    string __tmp55_line = ";"; //175:40
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Write(__tmp55_line);
                        __tmp52_outputWritten = true;
                    }
                    if (__tmp52_outputWritten) __out.AppendLine(true);
                    if (__tmp52_outputWritten)
                    {
                        __out.AppendLine(false); //175:41
                    }
                    __out.Write("            }"); //176:1
                    __out.AppendLine(false); //176:14
                    __out.Write("        }"); //177:1
                    __out.AppendLine(false); //177:10
                }
            }
            __out.AppendLine(true); //180:1
            __out.Write("        #region Completion"); //181:1
            __out.AppendLine(false); //181:27
            __out.AppendLine(true); //182:1
            __out.Write("        public sealed override bool RequiresCompletion => true;"); //183:1
            __out.AppendLine(false); //183:64
            __out.AppendLine(true); //184:1
            __out.Write("        public sealed override bool HasComplete(CompletionPart part)"); //185:1
            __out.AppendLine(false); //185:69
            __out.Write("        {"); //186:1
            __out.AppendLine(false); //186:10
            __out.Write("            return _state.HasComplete(part);"); //187:1
            __out.AppendLine(false); //187:45
            __out.Write("        }"); //188:1
            __out.AppendLine(false); //188:10
            __out.AppendLine(true); //189:1
            __out.Write("        public override void ForceComplete(CompletionPart completionPart, SourceLocation? locationOpt, CancellationToken cancellationToken)"); //190:1
            __out.AppendLine(false); //190:140
            __out.Write("        {"); //191:1
            __out.AppendLine(false); //191:10
            __out.Write("            if (completionPart != null && _state.HasComplete(completionPart)) return;"); //192:1
            __out.AppendLine(false); //192:86
            __out.Write("            if (completionPart != null && !CompletionParts.All.Contains(completionPart)) throw new ArgumentException(nameof(completionPart));"); //193:1
            __out.AppendLine(false); //193:142
            __out.Write("            while (true)"); //194:1
            __out.AppendLine(false); //194:25
            __out.Write("            {"); //195:1
            __out.AppendLine(false); //195:14
            __out.Write("                cancellationToken.ThrowIfCancellationRequested();"); //196:1
            __out.AppendLine(false); //196:66
            __out.Write("                var incompletePart = _state.NextIncompletePart;"); //197:1
            __out.AppendLine(false); //197:64
            __out.Write("                if (incompletePart == CompletionGraph.StartInitializing || incompletePart == CompletionGraph.FinishInitializing)"); //198:1
            __out.AppendLine(false); //198:129
            __out.Write("                {"); //199:1
            __out.AppendLine(false); //199:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartInitializing))"); //200:1
            __out.AppendLine(false); //200:84
            __out.Write("                    {"); //201:1
            __out.AppendLine(false); //201:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //202:1
            __out.AppendLine(false); //202:71
            __out.Write("                        _name = CompleteSymbolProperty_Name(diagnostics, cancellationToken);"); //203:1
            __out.AppendLine(false); //203:93
            __out.Write("                        _metadataName = CompleteSymbolProperty_MetadataName(diagnostics, cancellationToken);"); //204:1
            __out.AppendLine(false); //204:109
            __out.Write("                        CompleteInitializingSymbol(diagnostics, cancellationToken);"); //205:1
            __out.AppendLine(false); //205:84
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //206:1
            __out.AppendLine(false); //206:59
            __out.Write("                        diagnostics.Free();"); //207:1
            __out.AppendLine(false); //207:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishInitializing);"); //208:1
            __out.AppendLine(false); //208:85
            __out.Write("                    }"); //209:1
            __out.AppendLine(false); //209:22
            __out.Write("                }"); //210:1
            __out.AppendLine(false); //210:18
            __out.Write("                else if (incompletePart == CompletionGraph.StartCreatingChildren || incompletePart == CompletionGraph.FinishCreatingChildren)"); //211:1
            __out.AppendLine(false); //211:142
            __out.Write("                {"); //212:1
            __out.AppendLine(false); //212:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartCreatingChildren))"); //213:1
            __out.AppendLine(false); //213:88
            __out.Write("                    {"); //214:1
            __out.AppendLine(false); //214:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //215:1
            __out.AppendLine(false); //215:71
            __out.Write("                        _childSymbols = CompleteCreatingChildSymbols(diagnostics, cancellationToken);"); //216:1
            __out.AppendLine(false); //216:102
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //217:1
            __out.AppendLine(false); //217:59
            __out.Write("                        diagnostics.Free();"); //218:1
            __out.AppendLine(false); //218:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishCreatingChildren);"); //219:1
            __out.AppendLine(false); //219:89
            __out.Write("                    }"); //220:1
            __out.AppendLine(false); //220:22
            __out.Write("                }"); //221:1
            __out.AppendLine(false); //221:18
            var __loop7_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //222:24
                select new { part = part}
                ).ToList(); //222:18
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                var __tmp56 = __loop7_results[__loop7_iteration];
                var part = __tmp56.part;
                if (part.IsLocked) //223:22
                {
                    bool __tmp58_outputWritten = false;
                    string __tmp59_line = "                else if (incompletePart == CompletionParts."; //224:1
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
                    string __tmp61_line = " || incompletePart == CompletionParts."; //224:90
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
                    string __tmp63_line = ")"; //224:159
                    if (!string.IsNullOrEmpty(__tmp63_line))
                    {
                        __out.Write(__tmp63_line);
                        __tmp58_outputWritten = true;
                    }
                    if (__tmp58_outputWritten) __out.AppendLine(true);
                    if (__tmp58_outputWritten)
                    {
                        __out.AppendLine(false); //224:160
                    }
                    __out.Write("                {"); //225:1
                    __out.AppendLine(false); //225:18
                    bool __tmp65_outputWritten = false;
                    string __tmp66_line = "                    if (_state.NotePartComplete(CompletionParts."; //226:1
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
                    string __tmp68_line = "))"; //226:95
                    if (!string.IsNullOrEmpty(__tmp68_line))
                    {
                        __out.Write(__tmp68_line);
                        __tmp65_outputWritten = true;
                    }
                    if (__tmp65_outputWritten) __out.AppendLine(true);
                    if (__tmp65_outputWritten)
                    {
                        __out.AppendLine(false); //226:97
                    }
                    __out.Write("                    {"); //227:1
                    __out.AppendLine(false); //227:22
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //228:26
                    {
                        __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //229:1
                        __out.AppendLine(false); //229:71
                    }
                    bool __tmp70_outputWritten = false;
                    string __tmp69Prefix = "                        "; //231:1
                    if (part is SymbolPropertyGenerationInfo) //231:26
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
                        string __tmp73_line = " = "; //231:116
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
                    string __tmp76_line = "("; //231:152
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
                    string __tmp78_line = ");"; //231:181
                    if (!string.IsNullOrEmpty(__tmp78_line))
                    {
                        __out.Write(__tmp78_line);
                        __tmp70_outputWritten = true;
                    }
                    if (__tmp70_outputWritten) __out.AppendLine(true);
                    if (__tmp70_outputWritten)
                    {
                        __out.AppendLine(false); //231:183
                    }
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //232:26
                    {
                        __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //233:1
                        __out.AppendLine(false); //233:59
                        __out.Write("                        diagnostics.Free();"); //234:1
                        __out.AppendLine(false); //234:44
                    }
                    bool __tmp80_outputWritten = false;
                    string __tmp81_line = "                        _state.NotePartComplete(CompletionParts."; //236:1
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
                    string __tmp83_line = ");"; //236:96
                    if (!string.IsNullOrEmpty(__tmp83_line))
                    {
                        __out.Write(__tmp83_line);
                        __tmp80_outputWritten = true;
                    }
                    if (__tmp80_outputWritten) __out.AppendLine(true);
                    if (__tmp80_outputWritten)
                    {
                        __out.AppendLine(false); //236:98
                    }
                    __out.Write("                    }"); //237:1
                    __out.AppendLine(false); //237:22
                    __out.Write("                }"); //238:1
                    __out.AppendLine(false); //238:18
                }
                else //239:22
                {
                    bool __tmp85_outputWritten = false;
                    string __tmp86_line = "                else if (incompletePart == CompletionParts."; //240:1
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
                    string __tmp88_line = ")"; //240:85
                    if (!string.IsNullOrEmpty(__tmp88_line))
                    {
                        __out.Write(__tmp88_line);
                        __tmp85_outputWritten = true;
                    }
                    if (__tmp85_outputWritten) __out.AppendLine(true);
                    if (__tmp85_outputWritten)
                    {
                        __out.AppendLine(false); //240:86
                    }
                    __out.Write("                {"); //241:1
                    __out.AppendLine(false); //241:18
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //242:22
                    {
                        __out.Write("                    var diagnostics = DiagnosticBag.GetInstance();"); //243:1
                        __out.AppendLine(false); //243:67
                    }
                    bool __tmp90_outputWritten = false;
                    string __tmp89Prefix = "                    "; //245:1
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
                    string __tmp92_line = "("; //245:46
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
                    string __tmp94_line = ");"; //245:75
                    if (!string.IsNullOrEmpty(__tmp94_line))
                    {
                        __out.Write(__tmp94_line);
                        __tmp90_outputWritten = true;
                    }
                    if (__tmp90_outputWritten) __out.AppendLine(true);
                    if (__tmp90_outputWritten)
                    {
                        __out.AppendLine(false); //245:77
                    }
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //246:22
                    {
                        __out.Write("                    AddSymbolDiagnostics(diagnostics);"); //247:1
                        __out.AppendLine(false); //247:55
                        __out.Write("                    diagnostics.Free();"); //248:1
                        __out.AppendLine(false); //248:40
                    }
                    bool __tmp96_outputWritten = false;
                    string __tmp97_line = "                    _state.NotePartComplete(CompletionParts."; //250:1
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
                    string __tmp99_line = ");"; //250:86
                    if (!string.IsNullOrEmpty(__tmp99_line))
                    {
                        __out.Write(__tmp99_line);
                        __tmp96_outputWritten = true;
                    }
                    if (__tmp96_outputWritten) __out.AppendLine(true);
                    if (__tmp96_outputWritten)
                    {
                        __out.AppendLine(false); //250:88
                    }
                    __out.Write("                }"); //251:1
                    __out.AppendLine(false); //251:18
                }
            }
            __out.Write("                else if (incompletePart == CompletionGraph.StartComputingNonSymbolProperties || incompletePart == CompletionGraph.FinishComputingNonSymbolProperties)"); //254:1
            __out.AppendLine(false); //254:166
            __out.Write("                {"); //255:1
            __out.AppendLine(false); //255:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartComputingNonSymbolProperties))"); //256:1
            __out.AppendLine(false); //256:100
            __out.Write("                    {"); //257:1
            __out.AppendLine(false); //257:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //258:1
            __out.AppendLine(false); //258:71
            __out.Write("                        CompleteNonSymbolProperties(locationOpt, diagnostics, cancellationToken);"); //259:1
            __out.AppendLine(false); //259:98
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //260:1
            __out.AppendLine(false); //260:59
            __out.Write("                        diagnostics.Free();"); //261:1
            __out.AppendLine(false); //261:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishComputingNonSymbolProperties);"); //262:1
            __out.AppendLine(false); //262:101
            __out.Write("                    }"); //263:1
            __out.AppendLine(false); //263:22
            __out.Write("                }"); //264:1
            __out.AppendLine(false); //264:18
            __out.Write("                else if (incompletePart == CompletionGraph.ChildrenCompleted)"); //265:1
            __out.AppendLine(false); //265:78
            __out.Write("                {"); //266:1
            __out.AppendLine(false); //266:18
            __out.Write("                    var diagnostics = DiagnosticBag.GetInstance();"); //267:1
            __out.AppendLine(false); //267:67
            __out.Write("                    CompleteImports(locationOpt, diagnostics, cancellationToken);"); //268:1
            __out.AppendLine(false); //268:82
            __out.Write("                    AddSymbolDiagnostics(diagnostics);"); //269:1
            __out.AppendLine(false); //269:55
            __out.Write("                    diagnostics.Free();"); //270:1
            __out.AppendLine(false); //270:40
            __out.Write("                    bool allCompleted = true;"); //272:1
            __out.AppendLine(false); //272:46
            __out.Write("                    if (locationOpt == null)"); //273:1
            __out.AppendLine(false); //273:45
            __out.Write("                    {"); //274:1
            __out.AppendLine(false); //274:22
            __out.Write("                        foreach (var child in _childSymbols)"); //275:1
            __out.AppendLine(false); //275:61
            __out.Write("                        {"); //276:1
            __out.AppendLine(false); //276:26
            __out.Write("                            cancellationToken.ThrowIfCancellationRequested();"); //277:1
            __out.AppendLine(false); //277:78
            __out.Write("                            child.ForceComplete(null, locationOpt, cancellationToken);"); //278:1
            __out.AppendLine(false); //278:87
            __out.Write("                        }"); //279:1
            __out.AppendLine(false); //279:26
            __out.Write("                    }"); //280:1
            __out.AppendLine(false); //280:22
            __out.Write("                    else"); //281:1
            __out.AppendLine(false); //281:25
            __out.Write("                    {"); //282:1
            __out.AppendLine(false); //282:22
            __out.Write("                        foreach (var child in _childSymbols)"); //283:1
            __out.AppendLine(false); //283:61
            __out.Write("                        {"); //284:1
            __out.AppendLine(false); //284:26
            __out.Write("                            ForceCompleteChildByLocation(locationOpt, child, cancellationToken);"); //285:1
            __out.AppendLine(false); //285:97
            __out.Write("                            allCompleted = allCompleted && child.HasComplete(CompletionGraph.All);"); //286:1
            __out.AppendLine(false); //286:99
            __out.Write("                        }"); //287:1
            __out.AppendLine(false); //287:26
            __out.Write("                    }"); //288:1
            __out.AppendLine(false); //288:22
            __out.Write("                    if (!allCompleted)"); //290:1
            __out.AppendLine(false); //290:39
            __out.Write("                    {"); //291:1
            __out.AppendLine(false); //291:22
            __out.Write("                        // We did not complete all members, so just kick out now."); //292:1
            __out.AppendLine(false); //292:82
            __out.Write("                        var allParts = CompletionParts.AllWithLocation;"); //293:1
            __out.AppendLine(false); //293:72
            __out.Write("                        _state.SpinWaitComplete(allParts, cancellationToken);"); //294:1
            __out.AppendLine(false); //294:78
            __out.Write("                        return;"); //295:1
            __out.AppendLine(false); //295:32
            __out.Write("                    }"); //296:1
            __out.AppendLine(false); //296:22
            __out.Write("                    // We've completed all members, proceed to the next iteration."); //298:1
            __out.AppendLine(false); //298:83
            __out.Write("                    _state.NotePartComplete(CompletionGraph.ChildrenCompleted);"); //299:1
            __out.AppendLine(false); //299:80
            __out.Write("                }"); //300:1
            __out.AppendLine(false); //300:18
            __out.Write("                else if (incompletePart == CompletionGraph.StartValidatingSymbol || incompletePart == CompletionGraph.FinishValidatingSymbol)"); //301:1
            __out.AppendLine(false); //301:142
            __out.Write("                {"); //302:1
            __out.AppendLine(false); //302:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartValidatingSymbol))"); //303:1
            __out.AppendLine(false); //303:88
            __out.Write("                    {"); //304:1
            __out.AppendLine(false); //304:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //305:1
            __out.AppendLine(false); //305:71
            __out.Write("                        CompleteValidatingSymbol(diagnostics, cancellationToken);"); //306:1
            __out.AppendLine(false); //306:82
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //307:1
            __out.AppendLine(false); //307:59
            __out.Write("                        diagnostics.Free();"); //308:1
            __out.AppendLine(false); //308:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishValidatingSymbol);"); //309:1
            __out.AppendLine(false); //309:89
            __out.Write("                    }"); //310:1
            __out.AppendLine(false); //310:22
            __out.Write("                }"); //311:1
            __out.AppendLine(false); //311:18
            __out.Write("                else if (incompletePart == null)"); //312:1
            __out.AppendLine(false); //312:49
            __out.Write("                {"); //313:1
            __out.AppendLine(false); //313:18
            __out.Write("                    return;"); //314:1
            __out.AppendLine(false); //314:28
            __out.Write("                }"); //315:1
            __out.AppendLine(false); //315:18
            __out.Write("                else"); //316:1
            __out.AppendLine(false); //316:21
            __out.Write("                {"); //317:1
            __out.AppendLine(false); //317:18
            __out.Write("                    // This assert will trigger if we forgot to handle any of the completion parts"); //318:1
            __out.AppendLine(false); //318:99
            __out.Write("                    Debug.Assert(!CompletionParts.All.Contains(incompletePart));"); //319:1
            __out.AppendLine(false); //319:81
            __out.Write("                    // any other values are completion parts intended for other kinds of symbols"); //320:1
            __out.AppendLine(false); //320:97
            __out.Write("                    _state.NotePartComplete(incompletePart);"); //321:1
            __out.AppendLine(false); //321:61
            __out.Write("                }"); //322:1
            __out.AppendLine(false); //322:18
            __out.Write("                if (completionPart != null && _state.HasComplete(completionPart)) return;"); //323:1
            __out.AppendLine(false); //323:90
            __out.Write("                _state.SpinWaitComplete(incompletePart, cancellationToken);"); //324:1
            __out.AppendLine(false); //324:76
            __out.Write("            }"); //325:1
            __out.AppendLine(false); //325:14
            __out.Write("            throw ExceptionUtilities.Unreachable;"); //326:1
            __out.AppendLine(false); //326:50
            __out.Write("        }"); //327:1
            __out.AppendLine(false); //327:10
            __out.AppendLine(true); //328:1
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteSymbolProperty_Name")) //329:10
            {
                __out.AppendLine(true); //330:1
                __out.Write("        protected virtual string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //331:1
                __out.AppendLine(false); //331:125
                __out.Write("        {"); //332:1
                __out.AppendLine(false); //332:10
                __out.Write("            return SymbolImplementation.AssignNameProperty(this, diagnostics);"); //333:1
                __out.AppendLine(false); //333:79
                __out.Write("        }"); //334:1
                __out.AppendLine(false); //334:10
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteSymbolProperty_MetadataName")) //336:10
            {
                __out.AppendLine(true); //337:1
                __out.Write("        protected virtual string CompleteSymbolProperty_MetadataName(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //338:1
                __out.AppendLine(false); //338:133
                __out.Write("        {"); //339:1
                __out.AppendLine(false); //339:10
                __out.Write("            return SymbolImplementation.AssignMetadataNameProperty(this, diagnostics);"); //340:1
                __out.AppendLine(false); //340:87
                __out.Write("        }"); //341:1
                __out.AppendLine(false); //341:10
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteInitializingSymbol")) //343:10
            {
                __out.AppendLine(true); //344:1
                __out.Write("        protected virtual void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //345:1
                __out.AppendLine(false); //345:122
                __out.Write("        {"); //346:1
                __out.AppendLine(false); //346:10
                __out.Write("        }"); //347:1
                __out.AppendLine(false); //347:10
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteCreatingChildSymbols")) //349:10
            {
                __out.AppendLine(true); //350:1
                __out.Write("        protected virtual ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //351:1
                __out.AppendLine(false); //351:142
                __out.Write("        {"); //352:1
                __out.AppendLine(false); //352:10
                __out.Write("            return SymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //353:1
                __out.AppendLine(false); //353:118
                __out.Write("        }"); //354:1
                __out.AppendLine(false); //354:10
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteImports")) //356:10
            {
                __out.AppendLine(true); //357:1
                __out.Write("        protected virtual void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //358:1
                __out.AppendLine(false); //358:139
                __out.Write("        {"); //359:1
                __out.AppendLine(false); //359:10
                __out.Write("            SymbolImplementation.CompleteImports(this, locationOpt, diagnostics, cancellationToken);"); //360:1
                __out.AppendLine(false); //360:101
                __out.Write("        }"); //361:1
                __out.AppendLine(false); //361:10
            }
            var __loop8_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //363:16
                where part.GenerateCompleteMethod //363:44
                select new { part = part}
                ).ToList(); //363:10
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp100 = __loop8_results[__loop8_iteration];
                var part = __tmp100.part;
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains(part.CompleteMethodName)) //364:14
                {
                    __out.AppendLine(true); //365:1
                    bool __tmp102_outputWritten = false;
                    string __tmp103_line = "        protected virtual "; //366:1
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
                    string __tmp105_line = " "; //366:58
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
                    string __tmp107_line = "("; //366:84
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
                    string __tmp109_line = ")"; //366:115
                    if (!string.IsNullOrEmpty(__tmp109_line))
                    {
                        __out.Write(__tmp109_line);
                        __tmp102_outputWritten = true;
                    }
                    if (__tmp102_outputWritten) __out.AppendLine(true);
                    if (__tmp102_outputWritten)
                    {
                        __out.AppendLine(false); //366:116
                    }
                    __out.Write("        {"); //367:1
                    __out.AppendLine(false); //367:10
                    if (part is SymbolPropertyGenerationInfo) //368:14
                    {
                        var prop = (SymbolPropertyGenerationInfo)part; //369:18
                        if (prop.IsCollection) //370:18
                        {
                            bool __tmp111_outputWritten = false;
                            string __tmp112_line = "            SymbolImplementation.AssignSymbolPropertyValues<"; //371:1
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
                            string __tmp114_line = ">(this, nameof("; //371:76
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
                            string __tmp116_line = "), diagnostics, cancellationToken, out var result);"; //371:102
                            if (!string.IsNullOrEmpty(__tmp116_line))
                            {
                                __out.Write(__tmp116_line);
                                __tmp111_outputWritten = true;
                            }
                            if (__tmp111_outputWritten) __out.AppendLine(true);
                            if (__tmp111_outputWritten)
                            {
                                __out.AppendLine(false); //371:153
                            }
                        }
                        else //372:18
                        {
                            bool __tmp118_outputWritten = false;
                            string __tmp119_line = "            SymbolImplementation.AssignSymbolPropertyValue<"; //373:1
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
                            string __tmp121_line = ">(this, nameof("; //373:71
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
                            string __tmp123_line = "), diagnostics, cancellationToken, out var result);"; //373:97
                            if (!string.IsNullOrEmpty(__tmp123_line))
                            {
                                __out.Write(__tmp123_line);
                                __tmp118_outputWritten = true;
                            }
                            if (__tmp118_outputWritten) __out.AppendLine(true);
                            if (__tmp118_outputWritten)
                            {
                                __out.AppendLine(false); //373:148
                            }
                        }
                    }
                    __out.Write("            return result;"); //376:1
                    __out.AppendLine(false); //376:27
                    __out.Write("        }"); //377:1
                    __out.AppendLine(false); //377:10
                }
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteNonSymbolProperties")) //380:10
            {
                __out.AppendLine(true); //381:1
                __out.Write("        protected virtual void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //382:1
                __out.AppendLine(false); //382:151
                __out.Write("        {"); //383:1
                __out.AppendLine(false); //383:10
                __out.Write("            SymbolImplementation.AssignNonSymbolProperties(this, diagnostics, cancellationToken);"); //384:1
                __out.AppendLine(false); //384:98
                __out.Write("        }"); //385:1
                __out.AppendLine(false); //385:10
            }
            __out.Write("        #endregion"); //387:1
            __out.AppendLine(false); //387:19
            __out.Write("    }"); //388:1
            __out.AppendLine(false); //388:6
            __out.Write("}"); //389:1
            __out.AppendLine(false); //389:2
            return __out.ToStringAndFree();
        }

        public string GenerateMetadataSymbol(SymbolGenerationInfo symbol) //392:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //393:1
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
            string __tmp5_line = ".Metadata"; //393:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //393:42
            }
            __out.Write("{"); //394:1
            __out.AppendLine(false); //394:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Metadata"; //395:1
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
            if (symbol.ExistingMetadataTypeInfo.BaseType == null) //395:45
            {
                string __tmp11_line = " : "; //395:99
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
                string __tmp13_line = ".Completion.Completion"; //395:124
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
                __out.AppendLine(false); //395:167
            }
            __out.Write("	{"); //396:1
            __out.AppendLine(false); //396:3
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //397:10
            {
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //398:10
                {
                    bool __tmp17_outputWritten = false;
                    string __tmp18_line = "        public Metadata"; //399:1
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
                    string __tmp20_line = "(Symbol container"; //399:37
                    if (!string.IsNullOrEmpty(__tmp20_line))
                    {
                        __out.Write(__tmp20_line);
                        __tmp17_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //399:55
                    {
                        string __tmp22_line = ", object? modelObject"; //399:112
                        if (!string.IsNullOrEmpty(__tmp22_line))
                        {
                            __out.Write(__tmp22_line);
                            __tmp17_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //399:134
                        {
                            string __tmp24_line = " = null"; //399:191
                            if (!string.IsNullOrEmpty(__tmp24_line))
                            {
                                __out.Write(__tmp24_line);
                                __tmp17_outputWritten = true;
                            }
                        }
                    }
                    string __tmp27_line = ", bool isError = false)"; //399:214
                    if (!string.IsNullOrEmpty(__tmp27_line))
                    {
                        __out.Write(__tmp27_line);
                        __tmp17_outputWritten = true;
                    }
                    if (__tmp17_outputWritten) __out.AppendLine(true);
                    if (__tmp17_outputWritten)
                    {
                        __out.AppendLine(false); //399:237
                    }
                    __out.Write("            : base(container"); //400:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //400:30
                    {
                        __out.Write(", modelObject"); //400:87
                    }
                    __out.Write(", isError)"); //400:108
                    __out.AppendLine(false); //400:118
                    __out.Write("        {"); //401:1
                    __out.AppendLine(false); //401:10
                    __out.Write("        }"); //402:1
                    __out.AppendLine(false); //402:10
                }
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains("Locations")) //404:10
                {
                    __out.AppendLine(true); //405:1
                    __out.Write("        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;"); //406:1
                    __out.AppendLine(false); //406:95
                }
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains("DeclaringSyntaxReferences")) //408:10
                {
                    __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;"); //409:1
                    __out.AppendLine(false); //409:124
                }
            }
            __out.AppendLine(true); //412:1
            __out.Write("        protected override ISymbolImplementation SymbolImplementation => MetadataSymbolImplementation.Instance;"); //413:1
            __out.AppendLine(false); //413:112
            __out.AppendLine(true); //414:1
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //415:10
            {
                bool __tmp29_outputWritten = false;
                string __tmp30_line = "        public partial class Error : Metadata"; //416:1
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
                string __tmp32_line = ", MetaDslx.CodeAnalysis.Symbols.IErrorSymbol"; //416:59
                if (!string.IsNullOrEmpty(__tmp32_line))
                {
                    __out.Write(__tmp32_line);
                    __tmp29_outputWritten = true;
                }
                if (__tmp29_outputWritten) __out.AppendLine(true);
                if (__tmp29_outputWritten)
                {
                    __out.AppendLine(false); //416:103
                }
                __out.Write("        {"); //417:1
                __out.AppendLine(false); //417:10
                __out.Write("            private readonly string _name;"); //418:1
                __out.AppendLine(false); //418:43
                __out.Write("            private readonly string _metadataName;"); //419:1
                __out.AppendLine(false); //419:51
                __out.Write("            private DiagnosticInfo _errorInfo;"); //420:1
                __out.AppendLine(false); //420:47
                __out.Write("            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorKind _kind;"); //421:1
                __out.AppendLine(false); //421:76
                __out.Write("            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags _flags;"); //422:1
                __out.AppendLine(false); //422:84
                __out.Write("            private ImmutableArray<Symbol> _candidateSymbols;"); //423:1
                __out.AppendLine(false); //423:62
                __out.AppendLine(true); //424:1
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //425:14
                {
                    __out.Write("            private Error(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags"); //426:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //426:246
                    {
                        __out.Write(", object? modelObject"); //426:303
                    }
                    __out.Write(")"); //426:332
                    __out.AppendLine(false); //426:333
                    __out.Write("                : base(container"); //427:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //427:34
                    {
                        __out.Write(", modelObject"); //427:91
                    }
                    __out.Write(", true)"); //427:112
                    __out.AppendLine(false); //427:119
                    __out.Write("            {"); //428:1
                    __out.AppendLine(false); //428:14
                    __out.Write("                Debug.Assert(!flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported) || errorInfo != null);"); //429:1
                    __out.AppendLine(false); //429:126
                    __out.Write("                _name = name;"); //430:1
                    __out.AppendLine(false); //430:30
                    __out.Write("                _metadataName = metadataName;"); //431:1
                    __out.AppendLine(false); //431:46
                    __out.Write("                _kind = kind;"); //432:1
                    __out.AppendLine(false); //432:30
                    __out.Write("                _errorInfo = errorInfo;"); //433:1
                    __out.AppendLine(false); //433:40
                    __out.Write("                _candidateSymbols = candidateSymbols;"); //434:1
                    __out.AppendLine(false); //434:54
                    __out.Write("                _flags = flags;"); //435:1
                    __out.AppendLine(false); //435:32
                    __out.Write("            }"); //436:1
                    __out.AppendLine(false); //436:14
                    __out.Write("            public Error(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported"); //438:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //438:208
                    {
                        __out.Write(", object? modelObject"); //438:265
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //438:287
                        {
                            __out.Write(" = null"); //438:344
                        }
                    }
                    __out.Write(")"); //438:367
                    __out.AppendLine(false); //438:368
                    __out.Write("                : this(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.None"); //439:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //439:215
                    {
                        __out.Write(", modelObject"); //439:272
                    }
                    __out.Write(")"); //439:293
                    __out.AppendLine(false); //439:294
                    __out.Write("            {"); //440:1
                    __out.AppendLine(false); //440:14
                    __out.Write("            }"); //441:1
                    __out.AppendLine(false); //441:14
                    __out.Write("            public Error(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported"); //443:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //443:137
                    {
                        __out.Write(", object? modelObject"); //443:194
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //443:216
                        {
                            __out.Write(" = null"); //443:273
                        }
                    }
                    __out.Write(")"); //443:296
                    __out.AppendLine(false); //443:297
                    __out.Write("                : this(wrappedSymbol.ContainingSymbol, wrappedSymbol.Name, wrappedSymbol.MetadataName, kind, errorInfo, ImmutableArray.Create<Symbol>(wrappedSymbol), unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.UnreportedWrapped : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Wrapped"); //444:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //444:302
                    {
                        __out.Write(", modelObject is not null ? modelObject : (wrappedSymbol as IModelSymbol)?.ModelObject"); //444:359
                    }
                    __out.Write(")"); //444:453
                    __out.AppendLine(false); //444:454
                    __out.Write("            {"); //445:1
                    __out.AppendLine(false); //445:14
                    __out.Write("            }"); //446:1
                    __out.AppendLine(false); //446:14
                    __out.AppendLine(true); //447:1
                    __out.Write("            protected virtual Error Update(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags"); //448:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //448:263
                    {
                        __out.Write(", object? modelObject"); //448:320
                    }
                    __out.Write(")"); //448:349
                    __out.AppendLine(false); //448:350
                    __out.Write("            {"); //449:1
                    __out.AppendLine(false); //449:14
                    __out.Write("                return new Error(container, name, metadataName, kind, errorInfo, candidateSymbols, flags"); //450:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //450:106
                    {
                        __out.Write(", modelObject"); //450:163
                    }
                    __out.Write(");"); //450:184
                    __out.AppendLine(false); //450:186
                    __out.Write("            }"); //451:1
                    __out.AppendLine(false); //451:14
                }
                __out.AppendLine(true); //453:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsUnreported(DiagnosticInfo? errorInfo = null)"); //454:1
                __out.AppendLine(false); //454:103
                __out.Write("            {"); //455:1
                __out.AppendLine(false); //455:14
                __out.Write("                return this.IsUnreported ? this :"); //456:1
                __out.AppendLine(false); //456:50
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, _kind, errorInfo is null ? ErrorInfo : errorInfo, CandidateSymbols, _flags | MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported"); //457:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //457:208
                {
                    __out.Write(", this.ModelObject"); //457:265
                }
                __out.Write(");"); //457:291
                __out.AppendLine(false); //457:293
                __out.Write("            }"); //458:1
                __out.AppendLine(false); //458:14
                __out.AppendLine(true); //459:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsReported(DiagnosticInfo? errorInfo = null)"); //460:1
                __out.AppendLine(false); //460:101
                __out.Write("            {"); //461:1
                __out.AppendLine(false); //461:14
                __out.Write("                return this.IsUnreported ? this :"); //462:1
                __out.AppendLine(false); //462:50
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, _kind, errorInfo is null ? ErrorInfo : errorInfo, CandidateSymbols, _flags & ~MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported"); //463:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //463:209
                {
                    __out.Write(", this.ModelObject"); //463:266
                }
                __out.Write(");"); //463:292
                __out.AppendLine(false); //463:294
                __out.Write("            }"); //464:1
                __out.AppendLine(false); //464:14
                __out.AppendLine(true); //465:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind)"); //466:1
                __out.AppendLine(false); //466:109
                __out.Write("            {"); //467:1
                __out.AppendLine(false); //467:14
                __out.Write("                return _kind == kind ? this :"); //468:1
                __out.AppendLine(false); //468:46
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, kind, ErrorInfo, CandidateSymbols, _flags"); //469:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //469:115
                {
                    __out.Write(", this.ModelObject"); //469:172
                }
                __out.Write(");"); //469:198
                __out.AppendLine(false); //469:200
                __out.Write("            }"); //470:1
                __out.AppendLine(false); //470:14
                __out.AppendLine(true); //471:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, ImmutableArray<MetaDslx.CodeAnalysis.Symbols.Symbol> candidateSymbols)"); //472:1
                __out.AppendLine(false); //472:180
                __out.Write("            {"); //473:1
                __out.AppendLine(false); //473:14
                __out.Write("                return _kind == kind && CandidateSymbols == candidateSymbols ? this :"); //474:1
                __out.AppendLine(false); //474:86
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, kind, ErrorInfo, candidateSymbols, _flags"); //475:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //475:115
                {
                    __out.Write(", this.ModelObject"); //475:172
                }
                __out.Write(");"); //475:198
                __out.AppendLine(false); //475:200
                __out.Write("            }"); //476:1
                __out.AppendLine(false); //476:14
                __out.AppendLine(true); //477:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo errorInfo, ImmutableArray<MetaDslx.CodeAnalysis.Symbols.Symbol> candidateSymbols)"); //478:1
                __out.AppendLine(false); //478:206
                __out.Write("            {"); //479:1
                __out.AppendLine(false); //479:14
                __out.Write("                return _kind == kind && ErrorInfo == errorInfo && CandidateSymbols == candidateSymbols ? this :"); //480:1
                __out.AppendLine(false); //480:112
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, kind, errorInfo, candidateSymbols, _flags"); //481:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //481:115
                {
                    __out.Write(", this.ModelObject"); //481:172
                }
                __out.Write(");"); //481:198
                __out.AppendLine(false); //481:200
                __out.Write("            }"); //482:1
                __out.AppendLine(false); //482:14
                __out.AppendLine(true); //483:1
                __out.Write("            public override string Name => _name;"); //484:1
                __out.AppendLine(false); //484:50
                __out.AppendLine(true); //485:1
                __out.Write("            public override string MetadataName => _metadataName;"); //486:1
                __out.AppendLine(false); //486:66
                __out.AppendLine(true); //487:1
                __out.Write("            public sealed override bool IsError => true;"); //488:1
                __out.AppendLine(false); //488:57
                __out.AppendLine(true); //489:1
                __out.Write("            public bool IsUnreported => _flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported);"); //490:1
                __out.AppendLine(false); //490:115
                __out.AppendLine(true); //491:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.ErrorKind ErrorKind => _kind;"); //492:1
                __out.AppendLine(false); //492:79
                __out.AppendLine(true); //493:1
                __out.Write("            public ImmutableArray<Symbol> CandidateSymbols"); //494:1
                __out.AppendLine(false); //494:59
                __out.Write("            {"); //495:1
                __out.AppendLine(false); //495:14
                __out.Write("                get"); //496:1
                __out.AppendLine(false); //496:20
                __out.Write("                {"); //497:1
                __out.AppendLine(false); //497:18
                __out.Write("                    if (_candidateSymbols.IsDefault)"); //498:1
                __out.AppendLine(false); //498:53
                __out.Write("                    {"); //499:1
                __out.AppendLine(false); //499:22
                __out.Write("                        System.Collections.Immutable.ImmutableInterlocked.InterlockedInitialize(ref _candidateSymbols, MakeCandidateSymbols());"); //500:1
                __out.AppendLine(false); //500:144
                __out.Write("                    }"); //501:1
                __out.AppendLine(false); //501:22
                __out.Write("                    return _candidateSymbols;"); //502:1
                __out.AppendLine(false); //502:46
                __out.Write("                }"); //503:1
                __out.AppendLine(false); //503:18
                __out.Write("            }"); //504:1
                __out.AppendLine(false); //504:14
                __out.AppendLine(true); //505:1
                __out.Write("            public DiagnosticInfo? ErrorInfo"); //506:1
                __out.AppendLine(false); //506:45
                __out.Write("            {"); //507:1
                __out.AppendLine(false); //507:14
                __out.Write("                get"); //508:1
                __out.AppendLine(false); //508:20
                __out.Write("                {"); //509:1
                __out.AppendLine(false); //509:18
                __out.Write("                    if (_errorInfo is null)"); //510:1
                __out.AppendLine(false); //510:44
                __out.Write("                    {"); //511:1
                __out.AppendLine(false); //511:22
                __out.Write("                        System.Threading.Interlocked.CompareExchange(ref _errorInfo, MakeErrorInfo(), null);"); //512:1
                __out.AppendLine(false); //512:109
                __out.Write("                    }"); //513:1
                __out.AppendLine(false); //513:22
                __out.Write("                    return _errorInfo;"); //514:1
                __out.AppendLine(false); //514:39
                __out.Write("                }"); //515:1
                __out.AppendLine(false); //515:18
                __out.Write("            }"); //516:1
                __out.AppendLine(false); //516:14
                __out.AppendLine(true); //517:1
                __out.Write("            protected virtual DiagnosticInfo? MakeErrorInfo()"); //518:1
                __out.AppendLine(false); //518:62
                __out.Write("            {"); //519:1
                __out.AppendLine(false); //519:14
                __out.Write("                return ErrorSymbolImplementation.MakeErrorInfo(this);"); //520:1
                __out.AppendLine(false); //520:70
                __out.Write("            }"); //521:1
                __out.AppendLine(false); //521:14
                __out.AppendLine(true); //522:1
                __out.Write("            protected virtual ImmutableArray<Symbol> MakeCandidateSymbols()"); //523:1
                __out.AppendLine(false); //523:76
                __out.Write("            {"); //524:1
                __out.AppendLine(false); //524:14
                __out.Write("                return ErrorSymbolImplementation.MakeCandidateSymbols(this);"); //525:1
                __out.AppendLine(false); //525:77
                __out.Write("            }"); //526:1
                __out.AppendLine(false); //526:14
                __out.AppendLine(true); //527:1
                __out.Write("            protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //528:1
                __out.AppendLine(false); //528:130
                __out.Write("            {"); //529:1
                __out.AppendLine(false); //529:14
                __out.Write("                return _name;"); //530:1
                __out.AppendLine(false); //530:30
                __out.Write("            }"); //531:1
                __out.AppendLine(false); //531:14
                __out.AppendLine(true); //532:1
                __out.Write("            protected override string CompleteSymbolProperty_MetadataName(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //533:1
                __out.AppendLine(false); //533:138
                __out.Write("            {"); //534:1
                __out.AppendLine(false); //534:14
                __out.Write("                return _metadataName;"); //535:1
                __out.AppendLine(false); //535:38
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
            __out.AppendLine(true); //607:1
            __out.Write("        protected override ISymbolImplementation SymbolImplementation => SourceSymbolImplementation.Instance;"); //608:1
            __out.AppendLine(false); //608:110
            __out.AppendLine(true); //609:1
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //610:10
            {
                bool __tmp32_outputWritten = false;
                string __tmp33_line = "        public partial class Error : Source"; //611:1
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
                string __tmp35_line = ", MetaDslx.CodeAnalysis.Symbols.IErrorSymbol"; //611:57
                if (!string.IsNullOrEmpty(__tmp35_line))
                {
                    __out.Write(__tmp35_line);
                    __tmp32_outputWritten = true;
                }
                if (__tmp32_outputWritten) __out.AppendLine(true);
                if (__tmp32_outputWritten)
                {
                    __out.AppendLine(false); //611:101
                }
                __out.Write("        {"); //612:1
                __out.AppendLine(false); //612:10
                __out.Write("            private readonly string _name;"); //613:1
                __out.AppendLine(false); //613:43
                __out.Write("            private readonly string _metadataName;"); //614:1
                __out.AppendLine(false); //614:51
                __out.Write("            private DiagnosticInfo _errorInfo;"); //615:1
                __out.AppendLine(false); //615:47
                __out.Write("            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorKind _kind;"); //616:1
                __out.AppendLine(false); //616:76
                __out.Write("            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags _flags;"); //617:1
                __out.AppendLine(false); //617:84
                __out.Write("            private ImmutableArray<Symbol> _candidateSymbols;"); //618:1
                __out.AppendLine(false); //618:62
                __out.AppendLine(true); //619:1
                if (!symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //620:14
                {
                    __out.Write("            private Error(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags"); //621:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //621:243
                    {
                        __out.Write(", object? modelObject"); //621:300
                    }
                    __out.Write(")"); //621:329
                    __out.AppendLine(false); //621:330
                    __out.Write("                : base(container, declaration"); //622:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //622:47
                    {
                        __out.Write(", modelObject"); //622:104
                    }
                    __out.Write(", true)"); //622:125
                    __out.AppendLine(false); //622:132
                    __out.Write("            {"); //623:1
                    __out.AppendLine(false); //623:14
                    __out.Write("                Debug.Assert(!flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported) || errorInfo != null);"); //624:1
                    __out.AppendLine(false); //624:126
                    __out.Write("                _name = declaration.Name;"); //625:1
                    __out.AppendLine(false); //625:42
                    __out.Write("                _metadataName = declaration.MetadataName;"); //626:1
                    __out.AppendLine(false); //626:58
                    __out.Write("                _kind = kind;"); //627:1
                    __out.AppendLine(false); //627:30
                    __out.Write("                _errorInfo = errorInfo;"); //628:1
                    __out.AppendLine(false); //628:40
                    __out.Write("                _candidateSymbols = candidateSymbols;"); //629:1
                    __out.AppendLine(false); //629:54
                    __out.Write("                _flags = flags;"); //630:1
                    __out.AppendLine(false); //630:32
                    __out.Write("            }"); //631:1
                    __out.AppendLine(false); //631:14
                    __out.Write("            public Error(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported"); //633:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //633:205
                    {
                        __out.Write(", object? modelObject"); //633:262
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //633:284
                        {
                            __out.Write(" = null"); //633:341
                        }
                    }
                    __out.Write(")"); //633:364
                    __out.AppendLine(false); //633:365
                    __out.Write("                : this(container, declaration, kind, errorInfo, candidateSymbols, unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.None"); //634:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //634:208
                    {
                        __out.Write(", modelObject"); //634:265
                    }
                    __out.Write(")"); //634:286
                    __out.AppendLine(false); //634:287
                    __out.Write("            {"); //635:1
                    __out.AppendLine(false); //635:14
                    __out.Write("            }"); //636:1
                    __out.AppendLine(false); //636:14
                    __out.Write("            public Error(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported"); //638:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //638:137
                    {
                        __out.Write(", object? modelObject"); //638:194
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //638:216
                        {
                            __out.Write(" = null"); //638:273
                        }
                    }
                    __out.Write(")"); //638:296
                    __out.AppendLine(false); //638:297
                    __out.Write("                : this(wrappedSymbol.ContainingSymbol, (wrappedSymbol as ISourceSymbol).MergedDeclaration, kind, errorInfo, ImmutableArray.Create<Symbol>(wrappedSymbol), unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.UnreportedWrapped : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Wrapped"); //639:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //639:306
                    {
                        __out.Write(", modelObject is not null ? modelObject :  (wrappedSymbol as IModelSymbol)?.ModelObject"); //639:363
                    }
                    __out.Write(")"); //639:458
                    __out.AppendLine(false); //639:459
                    __out.Write("            {"); //640:1
                    __out.AppendLine(false); //640:14
                    __out.Write("            }"); //641:1
                    __out.AppendLine(false); //641:14
                    __out.AppendLine(true); //642:1
                    __out.Write("            protected virtual Error Update(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags"); //643:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //643:260
                    {
                        __out.Write(", object? modelObject"); //643:317
                    }
                    __out.Write(")"); //643:346
                    __out.AppendLine(false); //643:347
                    __out.Write("            {"); //644:1
                    __out.AppendLine(false); //644:14
                    __out.Write("                return new Error(container, declaration, kind, errorInfo, candidateSymbols, flags"); //645:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //645:99
                    {
                        __out.Write(", modelObject"); //645:156
                    }
                    __out.Write(");"); //645:177
                    __out.AppendLine(false); //645:179
                    __out.Write("            }"); //646:1
                    __out.AppendLine(false); //646:14
                }
                __out.AppendLine(true); //648:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsReported(DiagnosticInfo? errorInfo = null)"); //649:1
                __out.AppendLine(false); //649:101
                __out.Write("            {"); //650:1
                __out.AppendLine(false); //650:14
                __out.Write("                return this.IsUnreported ? this :"); //651:1
                __out.AppendLine(false); //651:50
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, _kind, errorInfo is null ? ErrorInfo : errorInfo, CandidateSymbols, _flags & ~MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported"); //652:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //652:211
                {
                    __out.Write(", this.ModelObject"); //652:268
                }
                __out.Write(");"); //652:294
                __out.AppendLine(false); //652:296
                __out.Write("            }"); //653:1
                __out.AppendLine(false); //653:14
                __out.AppendLine(true); //654:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsUnreported(DiagnosticInfo? errorInfo = null)"); //655:1
                __out.AppendLine(false); //655:103
                __out.Write("            {"); //656:1
                __out.AppendLine(false); //656:14
                __out.Write("                return this.IsUnreported ? this :"); //657:1
                __out.AppendLine(false); //657:50
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, _kind, errorInfo is null ? ErrorInfo : errorInfo, CandidateSymbols, _flags | MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported"); //658:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //658:210
                {
                    __out.Write(", this.ModelObject"); //658:267
                }
                __out.Write(");"); //658:293
                __out.AppendLine(false); //658:295
                __out.Write("            }"); //659:1
                __out.AppendLine(false); //659:14
                __out.AppendLine(true); //660:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind)"); //661:1
                __out.AppendLine(false); //661:109
                __out.Write("            {"); //662:1
                __out.AppendLine(false); //662:14
                __out.Write("                return _kind == kind ? this :"); //663:1
                __out.AppendLine(false); //663:46
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, kind, ErrorInfo, CandidateSymbols, _flags"); //664:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //664:117
                {
                    __out.Write(", this.ModelObject"); //664:174
                }
                __out.Write(");"); //664:200
                __out.AppendLine(false); //664:202
                __out.Write("            }"); //665:1
                __out.AppendLine(false); //665:14
                __out.AppendLine(true); //666:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, ImmutableArray<MetaDslx.CodeAnalysis.Symbols.Symbol> candidateSymbols)"); //667:1
                __out.AppendLine(false); //667:180
                __out.Write("            {"); //668:1
                __out.AppendLine(false); //668:14
                __out.Write("                return _kind == kind && CandidateSymbols == candidateSymbols ? this :"); //669:1
                __out.AppendLine(false); //669:86
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, kind, ErrorInfo, candidateSymbols, _flags"); //670:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //670:117
                {
                    __out.Write(", this.ModelObject"); //670:174
                }
                __out.Write(");"); //670:200
                __out.AppendLine(false); //670:202
                __out.Write("            }"); //671:1
                __out.AppendLine(false); //671:14
                __out.AppendLine(true); //672:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo errorInfo, ImmutableArray<MetaDslx.CodeAnalysis.Symbols.Symbol> candidateSymbols)"); //673:1
                __out.AppendLine(false); //673:206
                __out.Write("            {"); //674:1
                __out.AppendLine(false); //674:14
                __out.Write("                return _kind == kind && ErrorInfo == errorInfo && CandidateSymbols == candidateSymbols ? this :"); //675:1
                __out.AppendLine(false); //675:112
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, kind, errorInfo, candidateSymbols, _flags"); //676:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //676:117
                {
                    __out.Write(", this.ModelObject"); //676:174
                }
                __out.Write(");"); //676:200
                __out.AppendLine(false); //676:202
                __out.Write("            }"); //677:1
                __out.AppendLine(false); //677:14
                __out.AppendLine(true); //678:1
                __out.Write("            public override string Name => _name;"); //679:1
                __out.AppendLine(false); //679:50
                __out.AppendLine(true); //680:1
                __out.Write("            public override string MetadataName => _metadataName;"); //681:1
                __out.AppendLine(false); //681:66
                __out.AppendLine(true); //682:1
                __out.Write("            public sealed override bool IsError => true;"); //683:1
                __out.AppendLine(false); //683:57
                __out.AppendLine(true); //684:1
                __out.Write("            public bool IsUnreported => _flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported);"); //685:1
                __out.AppendLine(false); //685:115
                __out.AppendLine(true); //686:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.ErrorKind ErrorKind => _kind;"); //687:1
                __out.AppendLine(false); //687:79
                __out.AppendLine(true); //688:1
                __out.Write("            public ImmutableArray<Symbol> CandidateSymbols"); //689:1
                __out.AppendLine(false); //689:59
                __out.Write("            {"); //690:1
                __out.AppendLine(false); //690:14
                __out.Write("                get"); //691:1
                __out.AppendLine(false); //691:20
                __out.Write("                {"); //692:1
                __out.AppendLine(false); //692:18
                __out.Write("                    if (_candidateSymbols.IsDefault)"); //693:1
                __out.AppendLine(false); //693:53
                __out.Write("                    {"); //694:1
                __out.AppendLine(false); //694:22
                __out.Write("                        System.Collections.Immutable.ImmutableInterlocked.InterlockedInitialize(ref _candidateSymbols, MakeCandidateSymbols());"); //695:1
                __out.AppendLine(false); //695:144
                __out.Write("                    }"); //696:1
                __out.AppendLine(false); //696:22
                __out.Write("                    return _candidateSymbols;"); //697:1
                __out.AppendLine(false); //697:46
                __out.Write("                }"); //698:1
                __out.AppendLine(false); //698:18
                __out.Write("            }"); //699:1
                __out.AppendLine(false); //699:14
                __out.AppendLine(true); //700:1
                __out.Write("            public DiagnosticInfo? ErrorInfo"); //701:1
                __out.AppendLine(false); //701:45
                __out.Write("            {"); //702:1
                __out.AppendLine(false); //702:14
                __out.Write("                get"); //703:1
                __out.AppendLine(false); //703:20
                __out.Write("                {"); //704:1
                __out.AppendLine(false); //704:18
                __out.Write("                    if (_errorInfo is null)"); //705:1
                __out.AppendLine(false); //705:44
                __out.Write("                    {"); //706:1
                __out.AppendLine(false); //706:22
                __out.Write("                        System.Threading.Interlocked.CompareExchange(ref _errorInfo, MakeErrorInfo(), null);"); //707:1
                __out.AppendLine(false); //707:109
                __out.Write("                    }"); //708:1
                __out.AppendLine(false); //708:22
                __out.Write("                    return _errorInfo;"); //709:1
                __out.AppendLine(false); //709:39
                __out.Write("                }"); //710:1
                __out.AppendLine(false); //710:18
                __out.Write("            }"); //711:1
                __out.AppendLine(false); //711:14
                __out.AppendLine(true); //712:1
                __out.Write("            public DiagnosticInfo? UseSiteDiagnosticInfo => IsUnreported ? ErrorInfo : null;"); //713:1
                __out.AppendLine(false); //713:93
                __out.AppendLine(true); //714:1
                __out.Write("            protected virtual DiagnosticInfo? MakeErrorInfo()"); //715:1
                __out.AppendLine(false); //715:62
                __out.Write("            {"); //716:1
                __out.AppendLine(false); //716:14
                __out.Write("                return null;"); //717:1
                __out.AppendLine(false); //717:29
                __out.Write("            }"); //718:1
                __out.AppendLine(false); //718:14
                __out.AppendLine(true); //719:1
                __out.Write("            protected virtual ImmutableArray<Symbol> MakeCandidateSymbols()"); //720:1
                __out.AppendLine(false); //720:76
                __out.Write("            {"); //721:1
                __out.AppendLine(false); //721:14
                __out.Write("                return ImmutableArray<Symbol>.Empty;"); //722:1
                __out.AppendLine(false); //722:53
                __out.Write("            }"); //723:1
                __out.AppendLine(false); //723:14
                __out.AppendLine(true); //724:1
                __out.Write("            protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //725:1
                __out.AppendLine(false); //725:130
                __out.Write("            {"); //726:1
                __out.AppendLine(false); //726:14
                __out.Write("                return _name;"); //727:1
                __out.AppendLine(false); //727:30
                __out.Write("            }"); //728:1
                __out.AppendLine(false); //728:14
                __out.AppendLine(true); //729:1
                __out.Write("            protected override string CompleteSymbolProperty_MetadataName(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //730:1
                __out.AppendLine(false); //730:138
                __out.Write("            {"); //731:1
                __out.AppendLine(false); //731:14
                __out.Write("                return _metadataName;"); //732:1
                __out.AppendLine(false); //732:38
                __out.Write("            }"); //733:1
                __out.AppendLine(false); //733:14
                __out.Write("        }"); //734:1
                __out.AppendLine(false); //734:10
            }
            __out.Write("	}"); //736:1
            __out.AppendLine(false); //736:3
            __out.Write("}"); //737:1
            __out.AppendLine(false); //737:2
            return __out.ToStringAndFree();
        }

        public string GenerateWrappedSymbol(SymbolGenerationInfo symbol) //740:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //741:1
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
            string __tmp5_line = ".Wrapped"; //741:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //741:41
            }
            __out.Write("{"); //742:1
            __out.AppendLine(false); //742:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Wrapped"; //743:1
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
            string __tmp10_line = " : "; //743:43
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
            string __tmp12_line = ".Completion.Completion"; //743:68
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
                __out.AppendLine(false); //743:103
            }
            __out.Write("	{"); //744:1
            __out.AppendLine(false); //744:3
            bool __tmp15_outputWritten = false;
            string __tmp16_line = "        private readonly "; //745:1
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
            string __tmp18_line = "."; //745:48
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
            string __tmp20_line = " _wrappedSymbol;"; //745:62
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Write(__tmp20_line);
                __tmp15_outputWritten = true;
            }
            if (__tmp15_outputWritten) __out.AppendLine(true);
            if (__tmp15_outputWritten)
            {
                __out.AppendLine(false); //745:78
            }
            bool __tmp22_outputWritten = false;
            string __tmp23_line = "        public Wrapped"; //747:1
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
            string __tmp25_line = "("; //747:36
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
            string __tmp27_line = "."; //747:59
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
            string __tmp29_line = " wrappedSymbol)"; //747:73
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Write(__tmp29_line);
                __tmp22_outputWritten = true;
            }
            if (__tmp22_outputWritten) __out.AppendLine(true);
            if (__tmp22_outputWritten)
            {
                __out.AppendLine(false); //747:88
            }
            __out.Write("            : base(wrappedSymbol.ContainingSymbol"); //748:1
            if (symbol.ModelObjectOption != ParameterOption.Disabled) //748:51
            {
                __out.Write(", ((IModelSymbol)wrappedSymbol).ModelObject"); //748:108
            }
            __out.Write(", wrappedSymbol.IsError)"); //748:159
            __out.AppendLine(false); //748:183
            __out.Write("        {"); //749:1
            __out.AppendLine(false); //749:10
            __out.Write("            _wrappedSymbol = wrappedSymbol;"); //750:1
            __out.AppendLine(false); //750:44
            __out.Write("        }"); //751:1
            __out.AppendLine(false); //751:10
            __out.AppendLine(true); //752:1
            __out.Write("        public override ImmutableArray<Location> Locations => _wrappedSymbol.Locations;"); //753:1
            __out.AppendLine(false); //753:88
            __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _wrappedSymbol.DeclaringSyntaxReferences;"); //754:1
            __out.AppendLine(false); //754:127
            __out.AppendLine(true); //755:1
            __out.Write("        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //756:1
            __out.AppendLine(false); //756:126
            __out.Write("        {"); //757:1
            __out.AppendLine(false); //757:10
            __out.Write("            return _wrappedSymbol.Name;"); //758:1
            __out.AppendLine(false); //758:40
            __out.Write("        }"); //759:1
            __out.AppendLine(false); //759:10
            __out.AppendLine(true); //760:1
            __out.Write("        protected override string CompleteSymbolProperty_MetadataName(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //761:1
            __out.AppendLine(false); //761:134
            __out.Write("        {"); //762:1
            __out.AppendLine(false); //762:10
            __out.Write("            return _wrappedSymbol.MetadataName;"); //763:1
            __out.AppendLine(false); //763:48
            __out.Write("        }"); //764:1
            __out.AppendLine(false); //764:10
            __out.AppendLine(true); //765:1
            __out.Write("        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //766:1
            __out.AppendLine(false); //766:123
            __out.Write("        {"); //767:1
            __out.AppendLine(false); //767:10
            __out.Write("            _wrappedSymbol.CompleteInitializingSymbol(diagnostics, cancellationToken);"); //768:1
            __out.AppendLine(false); //768:87
            __out.Write("        }"); //769:1
            __out.AppendLine(false); //769:10
            __out.AppendLine(true); //770:1
            __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //771:1
            __out.AppendLine(false); //771:143
            __out.Write("        {"); //772:1
            __out.AppendLine(false); //772:10
            __out.Write("            return _wrappedSymbol.CompleteCreatingChildSymbols(diagnostics, cancellationToken);"); //773:1
            __out.AppendLine(false); //773:96
            __out.Write("        }"); //774:1
            __out.AppendLine(false); //774:10
            __out.AppendLine(true); //775:1
            __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //776:1
            __out.AppendLine(false); //776:140
            __out.Write("        {"); //777:1
            __out.AppendLine(false); //777:10
            __out.Write("            _wrappedSymbol.CompleteImports(locationOpt, diagnostics, cancellationToken);"); //778:1
            __out.AppendLine(false); //778:89
            __out.Write("        }"); //779:1
            __out.AppendLine(false); //779:10
            var __loop9_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //780:16
                where part.GenerateCompleteMethod //780:44
                select new { part = part}
                ).ToList(); //780:10
            for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
            {
                var __tmp30 = __loop9_results[__loop9_iteration];
                var part = __tmp30.part;
                __out.AppendLine(true); //781:1
                bool __tmp32_outputWritten = false;
                string __tmp33_line = "        protected override "; //782:1
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
                string __tmp35_line = " "; //782:59
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
                string __tmp37_line = "("; //782:85
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
                string __tmp39_line = ")"; //782:116
                if (!string.IsNullOrEmpty(__tmp39_line))
                {
                    __out.Write(__tmp39_line);
                    __tmp32_outputWritten = true;
                }
                if (__tmp32_outputWritten) __out.AppendLine(true);
                if (__tmp32_outputWritten)
                {
                    __out.AppendLine(false); //782:117
                }
                __out.Write("        {"); //783:1
                __out.AppendLine(false); //783:10
                bool __tmp41_outputWritten = false;
                string __tmp40Prefix = "            "; //784:1
                if (part.CompleteMethodReturnType != "void") //784:14
                {
                    if (!string.IsNullOrEmpty(__tmp40Prefix))
                    {
                        __out.Write(__tmp40Prefix);
                        __tmp41_outputWritten = true;
                    }
                    string __tmp43_line = "return "; //784:59
                    if (!string.IsNullOrEmpty(__tmp43_line))
                    {
                        __out.Write(__tmp43_line);
                        __tmp41_outputWritten = true;
                    }
                }
                string __tmp45_line = "_wrappedSymbol."; //784:74
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
                string __tmp47_line = "("; //784:114
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
                string __tmp49_line = ");"; //784:143
                if (!string.IsNullOrEmpty(__tmp49_line))
                {
                    __out.Write(__tmp49_line);
                    __tmp41_outputWritten = true;
                }
                if (__tmp41_outputWritten) __out.AppendLine(true);
                if (__tmp41_outputWritten)
                {
                    __out.AppendLine(false); //784:145
                }
                __out.Write("        }"); //785:1
                __out.AppendLine(false); //785:10
            }
            __out.AppendLine(true); //787:1
            __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //788:1
            __out.AppendLine(false); //788:152
            __out.Write("        {"); //789:1
            __out.AppendLine(false); //789:10
            __out.Write("            _wrappedSymbol.CompleteNonSymbolProperties(locationOpt, diagnostics, cancellationToken);"); //790:1
            __out.AppendLine(false); //790:101
            __out.Write("        }"); //791:1
            __out.AppendLine(false); //791:10
            __out.Write("    }"); //792:1
            __out.AppendLine(false); //792:6
            __out.Write("}"); //793:1
            __out.AppendLine(false); //793:2
            return __out.ToStringAndFree();
        }

        public string GenerateVisitor(string namespaceName, IEnumerable<SymbolGenerationInfo> symbols) //796:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //797:1
            __out.AppendLine(false); //797:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //798:1
            __out.AppendLine(false); //798:29
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //799:1
            __out.AppendLine(false); //799:37
            __out.Write("using System;"); //800:1
            __out.AppendLine(false); //800:14
            __out.Write("using System.Collections.Generic;"); //801:1
            __out.AppendLine(false); //801:34
            __out.Write("using System.Collections.Immutable;"); //802:1
            __out.AppendLine(false); //802:36
            __out.Write("using System.Diagnostics;"); //803:1
            __out.AppendLine(false); //803:26
            __out.Write("using System.Text;"); //804:1
            __out.AppendLine(false); //804:19
            __out.Write("using System.Threading;"); //805:1
            __out.AppendLine(false); //805:24
            __out.AppendLine(true); //806:1
            __out.Write("#nullable enable"); //807:1
            __out.AppendLine(false); //807:17
            __out.AppendLine(true); //808:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //809:1
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
                __out.AppendLine(false); //809:26
            }
            __out.Write("{"); //810:1
            __out.AppendLine(false); //810:2
            __out.Write("	public interface ISymbolVisitor"); //811:1
            __out.AppendLine(false); //811:33
            __out.Write("	{"); //812:1
            __out.AppendLine(false); //812:3
            var __loop10_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //813:16
                where !symbol.IsAbstract //813:32
                select new { symbol = symbol}
                ).ToList(); //813:10
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                var __tmp5 = __loop10_results[__loop10_iteration];
                var symbol = __tmp5.symbol;
                bool __tmp7_outputWritten = false;
                string __tmp8_line = "        void Visit("; //814:1
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
                string __tmp10_line = " symbol);"; //814:33
                if (!string.IsNullOrEmpty(__tmp10_line))
                {
                    __out.Write(__tmp10_line);
                    __tmp7_outputWritten = true;
                }
                if (__tmp7_outputWritten) __out.AppendLine(true);
                if (__tmp7_outputWritten)
                {
                    __out.AppendLine(false); //814:42
                }
            }
            __out.Write("	}"); //816:1
            __out.AppendLine(false); //816:3
            __out.AppendLine(true); //817:1
            __out.Write("	public interface ISymbolVisitor<TResult>"); //818:1
            __out.AppendLine(false); //818:42
            __out.Write("	{"); //819:1
            __out.AppendLine(false); //819:3
            var __loop11_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //820:16
                where !symbol.IsAbstract //820:32
                select new { symbol = symbol}
                ).ToList(); //820:10
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp11 = __loop11_results[__loop11_iteration];
                var symbol = __tmp11.symbol;
                bool __tmp13_outputWritten = false;
                string __tmp14_line = "        TResult Visit("; //821:1
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
                string __tmp16_line = " symbol);"; //821:36
                if (!string.IsNullOrEmpty(__tmp16_line))
                {
                    __out.Write(__tmp16_line);
                    __tmp13_outputWritten = true;
                }
                if (__tmp13_outputWritten) __out.AppendLine(true);
                if (__tmp13_outputWritten)
                {
                    __out.AppendLine(false); //821:45
                }
            }
            __out.Write("	}"); //823:1
            __out.AppendLine(false); //823:3
            __out.AppendLine(true); //824:1
            __out.Write("	public interface ISymbolVisitor<TArgument, TResult>"); //825:1
            __out.AppendLine(false); //825:53
            __out.Write("	{"); //826:1
            __out.AppendLine(false); //826:3
            var __loop12_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //827:16
                where !symbol.IsAbstract //827:32
                select new { symbol = symbol}
                ).ToList(); //827:10
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp17 = __loop12_results[__loop12_iteration];
                var symbol = __tmp17.symbol;
                bool __tmp19_outputWritten = false;
                string __tmp20_line = "        TResult Visit("; //828:1
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
                string __tmp22_line = " symbol, TArgument argument);"; //828:36
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Write(__tmp22_line);
                    __tmp19_outputWritten = true;
                }
                if (__tmp19_outputWritten) __out.AppendLine(true);
                if (__tmp19_outputWritten)
                {
                    __out.AppendLine(false); //828:65
                }
            }
            __out.Write("	}"); //830:1
            __out.AppendLine(false); //830:3
            __out.Write("}"); //831:1
            __out.AppendLine(false); //831:2
            return __out.ToStringAndFree();
        }

        public string GenerateFactory(string namespaceName, IEnumerable<SymbolGenerationInfo> symbols) //834:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //835:1
            __out.AppendLine(false); //835:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //836:1
            __out.AppendLine(false); //836:29
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //837:1
            __out.AppendLine(false); //837:37
            __out.Write("using System;"); //838:1
            __out.AppendLine(false); //838:14
            __out.Write("using System.Collections.Generic;"); //839:1
            __out.AppendLine(false); //839:34
            __out.Write("using System.Collections.Immutable;"); //840:1
            __out.AppendLine(false); //840:36
            __out.Write("using System.Diagnostics;"); //841:1
            __out.AppendLine(false); //841:26
            __out.Write("using System.Text;"); //842:1
            __out.AppendLine(false); //842:19
            __out.Write("using System.Threading;"); //843:1
            __out.AppendLine(false); //843:24
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //844:1
            __out.AppendLine(false); //844:42
            __out.AppendLine(true); //845:1
            __out.Write("#nullable enable"); //846:1
            __out.AppendLine(false); //846:17
            __out.AppendLine(true); //847:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //848:1
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
            string __tmp5_line = ".Factory"; //848:26
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //848:34
            }
            __out.Write("{"); //849:1
            __out.AppendLine(false); //849:2
            var __loop13_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //850:12
                where !symbol.IsAbstract && symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol" && symbol.SymbolParts != SymbolParts.None //850:28
                select new { symbol = symbol}
                ).ToList(); //850:6
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp6 = __loop13_results[__loop13_iteration];
                var symbol = __tmp6.symbol;
                bool __tmp8_outputWritten = false;
                string __tmp9_line = "	public class "; //851:1
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
                string __tmp11_line = "Factory : IGeneratedSymbolFactory"; //851:28
                if (!string.IsNullOrEmpty(__tmp11_line))
                {
                    __out.Write(__tmp11_line);
                    __tmp8_outputWritten = true;
                }
                if (__tmp8_outputWritten) __out.AppendLine(true);
                if (__tmp8_outputWritten)
                {
                    __out.AppendLine(false); //851:61
                }
                __out.Write("	{"); //852:1
                __out.AppendLine(false); //852:3
                __out.Write("        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)"); //853:1
                __out.AppendLine(false); //853:83
                __out.Write("        {"); //854:1
                __out.AppendLine(false); //854:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Metadata)) //855:14
                {
                    bool __tmp13_outputWritten = false;
                    string __tmp14_line = "            throw new NotImplementedException(\"There is no Metadata"; //856:1
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
                    string __tmp16_line = " implemented.\");"; //856:81
                    if (!string.IsNullOrEmpty(__tmp16_line))
                    {
                        __out.Write(__tmp16_line);
                        __tmp13_outputWritten = true;
                    }
                    if (__tmp13_outputWritten) __out.AppendLine(true);
                    if (__tmp13_outputWritten)
                    {
                        __out.AppendLine(false); //856:97
                    }
                }
                else if (symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //857:14
                {
                    bool __tmp18_outputWritten = false;
                    string __tmp19_line = "            throw new NotImplementedException(\"CreateMetadataSymbol for Metadata"; //858:1
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
                    string __tmp21_line = " should be implemented in a custom SymbolFactory.\");"; //858:94
                    if (!string.IsNullOrEmpty(__tmp21_line))
                    {
                        __out.Write(__tmp21_line);
                        __tmp18_outputWritten = true;
                    }
                    if (__tmp18_outputWritten) __out.AppendLine(true);
                    if (__tmp18_outputWritten)
                    {
                        __out.AppendLine(false); //858:146
                    }
                }
                else //859:14
                {
                    bool __tmp23_outputWritten = false;
                    string __tmp24_line = "            return new Metadata.Metadata"; //860:1
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
                    string __tmp26_line = "(container"; //860:54
                    if (!string.IsNullOrEmpty(__tmp26_line))
                    {
                        __out.Write(__tmp26_line);
                        __tmp23_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //860:65
                    {
                        string __tmp28_line = ", modelObject"; //860:122
                        if (!string.IsNullOrEmpty(__tmp28_line))
                        {
                            __out.Write(__tmp28_line);
                            __tmp23_outputWritten = true;
                        }
                    }
                    string __tmp30_line = ");"; //860:143
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Write(__tmp30_line);
                        __tmp23_outputWritten = true;
                    }
                    if (__tmp23_outputWritten) __out.AppendLine(true);
                    if (__tmp23_outputWritten)
                    {
                        __out.AppendLine(false); //860:145
                    }
                }
                __out.Write("        }"); //862:1
                __out.AppendLine(false); //862:10
                __out.AppendLine(true); //863:1
                __out.Write("        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)"); //864:1
                __out.AppendLine(false); //864:253
                __out.Write("        {"); //865:1
                __out.AppendLine(false); //865:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Metadata)) //866:14
                {
                    bool __tmp32_outputWritten = false;
                    string __tmp33_line = "            throw new NotImplementedException(\"There is no Metadata"; //867:1
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
                    string __tmp35_line = " implemented.\");"; //867:81
                    if (!string.IsNullOrEmpty(__tmp35_line))
                    {
                        __out.Write(__tmp35_line);
                        __tmp32_outputWritten = true;
                    }
                    if (__tmp32_outputWritten) __out.AppendLine(true);
                    if (__tmp32_outputWritten)
                    {
                        __out.AppendLine(false); //867:97
                    }
                }
                else if (symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //868:14
                {
                    bool __tmp37_outputWritten = false;
                    string __tmp38_line = "            throw new NotImplementedException(\"CreateMetadataSymbol for Metadata"; //869:1
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
                    string __tmp40_line = " should be implemented in a custom SymbolFactory.\");"; //869:94
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Write(__tmp40_line);
                        __tmp37_outputWritten = true;
                    }
                    if (__tmp37_outputWritten) __out.AppendLine(true);
                    if (__tmp37_outputWritten)
                    {
                        __out.AppendLine(false); //869:146
                    }
                }
                else //870:14
                {
                    bool __tmp42_outputWritten = false;
                    string __tmp43_line = "            return new Metadata.Metadata"; //871:1
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
                    string __tmp45_line = ".Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported"; //871:54
                    if (!string.IsNullOrEmpty(__tmp45_line))
                    {
                        __out.Write(__tmp45_line);
                        __tmp42_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //871:138
                    {
                        string __tmp47_line = ", modelObject"; //871:195
                        if (!string.IsNullOrEmpty(__tmp47_line))
                        {
                            __out.Write(__tmp47_line);
                            __tmp42_outputWritten = true;
                        }
                    }
                    string __tmp49_line = ");"; //871:216
                    if (!string.IsNullOrEmpty(__tmp49_line))
                    {
                        __out.Write(__tmp49_line);
                        __tmp42_outputWritten = true;
                    }
                    if (__tmp42_outputWritten) __out.AppendLine(true);
                    if (__tmp42_outputWritten)
                    {
                        __out.AppendLine(false); //871:218
                    }
                }
                __out.Write("        }"); //873:1
                __out.AppendLine(false); //873:10
                __out.AppendLine(true); //874:1
                __out.Write("        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)"); //875:1
                __out.AppendLine(false); //875:182
                __out.Write("        {"); //876:1
                __out.AppendLine(false); //876:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Metadata)) //877:14
                {
                    bool __tmp51_outputWritten = false;
                    string __tmp52_line = "            throw new NotImplementedException(\"There is no Metadata"; //878:1
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
                    string __tmp54_line = " implemented.\");"; //878:81
                    if (!string.IsNullOrEmpty(__tmp54_line))
                    {
                        __out.Write(__tmp54_line);
                        __tmp51_outputWritten = true;
                    }
                    if (__tmp51_outputWritten) __out.AppendLine(true);
                    if (__tmp51_outputWritten)
                    {
                        __out.AppendLine(false); //878:97
                    }
                }
                else if (symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //879:14
                {
                    bool __tmp56_outputWritten = false;
                    string __tmp57_line = "            throw new NotImplementedException(\"CreateMetadataSymbol for Metadata"; //880:1
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
                    string __tmp59_line = " should be implemented in a custom SymbolFactory.\");"; //880:94
                    if (!string.IsNullOrEmpty(__tmp59_line))
                    {
                        __out.Write(__tmp59_line);
                        __tmp56_outputWritten = true;
                    }
                    if (__tmp56_outputWritten) __out.AppendLine(true);
                    if (__tmp56_outputWritten)
                    {
                        __out.AppendLine(false); //880:146
                    }
                }
                else //881:14
                {
                    bool __tmp61_outputWritten = false;
                    string __tmp62_line = "            return new Metadata.Metadata"; //882:1
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
                    string __tmp64_line = ".Error(wrappedSymbol, kind, errorInfo, unreported"; //882:54
                    if (!string.IsNullOrEmpty(__tmp64_line))
                    {
                        __out.Write(__tmp64_line);
                        __tmp61_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //882:104
                    {
                        string __tmp66_line = ", modelObject"; //882:161
                        if (!string.IsNullOrEmpty(__tmp66_line))
                        {
                            __out.Write(__tmp66_line);
                            __tmp61_outputWritten = true;
                        }
                    }
                    string __tmp68_line = ");"; //882:182
                    if (!string.IsNullOrEmpty(__tmp68_line))
                    {
                        __out.Write(__tmp68_line);
                        __tmp61_outputWritten = true;
                    }
                    if (__tmp61_outputWritten) __out.AppendLine(true);
                    if (__tmp61_outputWritten)
                    {
                        __out.AppendLine(false); //882:184
                    }
                }
                __out.Write("        }"); //884:1
                __out.AppendLine(false); //884:10
                __out.AppendLine(true); //885:1
                __out.Write("        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)"); //886:1
                __out.AppendLine(false); //886:112
                __out.Write("        {"); //887:1
                __out.AppendLine(false); //887:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Source)) //888:14
                {
                    bool __tmp70_outputWritten = false;
                    string __tmp71_line = "            throw new NotImplementedException(\"There is no Source"; //889:1
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
                    string __tmp73_line = " implemented.\");"; //889:79
                    if (!string.IsNullOrEmpty(__tmp73_line))
                    {
                        __out.Write(__tmp73_line);
                        __tmp70_outputWritten = true;
                    }
                    if (__tmp70_outputWritten) __out.AppendLine(true);
                    if (__tmp70_outputWritten)
                    {
                        __out.AppendLine(false); //889:95
                    }
                }
                else if (symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //890:14
                {
                    bool __tmp75_outputWritten = false;
                    string __tmp76_line = "            throw new NotImplementedException(\"CreateSourceSymbol for Source"; //891:1
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
                    string __tmp78_line = " should be implemented in a custom SymbolFactory.\");"; //891:90
                    if (!string.IsNullOrEmpty(__tmp78_line))
                    {
                        __out.Write(__tmp78_line);
                        __tmp75_outputWritten = true;
                    }
                    if (__tmp75_outputWritten) __out.AppendLine(true);
                    if (__tmp75_outputWritten)
                    {
                        __out.AppendLine(false); //891:142
                    }
                }
                else //892:14
                {
                    bool __tmp80_outputWritten = false;
                    string __tmp81_line = "            return new Source.Source"; //893:1
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
                    string __tmp83_line = "(container, declaration"; //893:50
                    if (!string.IsNullOrEmpty(__tmp83_line))
                    {
                        __out.Write(__tmp83_line);
                        __tmp80_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //893:74
                    {
                        string __tmp85_line = ", modelObject"; //893:131
                        if (!string.IsNullOrEmpty(__tmp85_line))
                        {
                            __out.Write(__tmp85_line);
                            __tmp80_outputWritten = true;
                        }
                    }
                    string __tmp87_line = ");"; //893:152
                    if (!string.IsNullOrEmpty(__tmp87_line))
                    {
                        __out.Write(__tmp87_line);
                        __tmp80_outputWritten = true;
                    }
                    if (__tmp80_outputWritten) __out.AppendLine(true);
                    if (__tmp80_outputWritten)
                    {
                        __out.AppendLine(false); //893:154
                    }
                }
                __out.Write("        }"); //895:1
                __out.AppendLine(false); //895:10
                __out.AppendLine(true); //896:1
                __out.Write("        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)"); //897:1
                __out.AppendLine(false); //897:248
                __out.Write("        {"); //898:1
                __out.AppendLine(false); //898:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Source)) //899:14
                {
                    bool __tmp89_outputWritten = false;
                    string __tmp90_line = "            throw new NotImplementedException(\"There is no Source"; //900:1
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
                    string __tmp92_line = " implemented.\");"; //900:79
                    if (!string.IsNullOrEmpty(__tmp92_line))
                    {
                        __out.Write(__tmp92_line);
                        __tmp89_outputWritten = true;
                    }
                    if (__tmp89_outputWritten) __out.AppendLine(true);
                    if (__tmp89_outputWritten)
                    {
                        __out.AppendLine(false); //900:95
                    }
                }
                else if (symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //901:14
                {
                    bool __tmp94_outputWritten = false;
                    string __tmp95_line = "            throw new NotImplementedException(\"CreateSourceSymbol for Source"; //902:1
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
                    string __tmp97_line = " should be implemented in a custom SymbolFactory.\");"; //902:90
                    if (!string.IsNullOrEmpty(__tmp97_line))
                    {
                        __out.Write(__tmp97_line);
                        __tmp94_outputWritten = true;
                    }
                    if (__tmp94_outputWritten) __out.AppendLine(true);
                    if (__tmp94_outputWritten)
                    {
                        __out.AppendLine(false); //902:142
                    }
                }
                else //903:14
                {
                    bool __tmp99_outputWritten = false;
                    string __tmp100_line = "            return new Source.Source"; //904:1
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
                    string __tmp102_line = ".Error(container, declaration, kind, errorInfo, candidateSymbols, unreported"; //904:50
                    if (!string.IsNullOrEmpty(__tmp102_line))
                    {
                        __out.Write(__tmp102_line);
                        __tmp99_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //904:127
                    {
                        string __tmp104_line = ", modelObject"; //904:184
                        if (!string.IsNullOrEmpty(__tmp104_line))
                        {
                            __out.Write(__tmp104_line);
                            __tmp99_outputWritten = true;
                        }
                    }
                    string __tmp106_line = ");"; //904:205
                    if (!string.IsNullOrEmpty(__tmp106_line))
                    {
                        __out.Write(__tmp106_line);
                        __tmp99_outputWritten = true;
                    }
                    if (__tmp99_outputWritten) __out.AppendLine(true);
                    if (__tmp99_outputWritten)
                    {
                        __out.AppendLine(false); //904:207
                    }
                }
                __out.Write("        }"); //906:1
                __out.AppendLine(false); //906:10
                __out.AppendLine(true); //907:1
                __out.Write("        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)"); //908:1
                __out.AppendLine(false); //908:180
                __out.Write("        {"); //909:1
                __out.AppendLine(false); //909:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Source)) //910:14
                {
                    bool __tmp108_outputWritten = false;
                    string __tmp109_line = "            throw new NotImplementedException(\"There is no Source"; //911:1
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
                    string __tmp111_line = " implemented.\");"; //911:79
                    if (!string.IsNullOrEmpty(__tmp111_line))
                    {
                        __out.Write(__tmp111_line);
                        __tmp108_outputWritten = true;
                    }
                    if (__tmp108_outputWritten) __out.AppendLine(true);
                    if (__tmp108_outputWritten)
                    {
                        __out.AppendLine(false); //911:95
                    }
                }
                else if (symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //912:14
                {
                    bool __tmp113_outputWritten = false;
                    string __tmp114_line = "            throw new NotImplementedException(\"CreateSourceSymbol for Source"; //913:1
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
                    string __tmp116_line = " should be implemented in a custom SymbolFactory.\");"; //913:90
                    if (!string.IsNullOrEmpty(__tmp116_line))
                    {
                        __out.Write(__tmp116_line);
                        __tmp113_outputWritten = true;
                    }
                    if (__tmp113_outputWritten) __out.AppendLine(true);
                    if (__tmp113_outputWritten)
                    {
                        __out.AppendLine(false); //913:142
                    }
                }
                else //914:14
                {
                    bool __tmp118_outputWritten = false;
                    string __tmp119_line = "            return new Source.Source"; //915:1
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
                    string __tmp121_line = ".Error(wrappedSymbol, kind, errorInfo, unreported"; //915:50
                    if (!string.IsNullOrEmpty(__tmp121_line))
                    {
                        __out.Write(__tmp121_line);
                        __tmp118_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //915:100
                    {
                        string __tmp123_line = ", modelObject"; //915:157
                        if (!string.IsNullOrEmpty(__tmp123_line))
                        {
                            __out.Write(__tmp123_line);
                            __tmp118_outputWritten = true;
                        }
                    }
                    string __tmp125_line = ");"; //915:178
                    if (!string.IsNullOrEmpty(__tmp125_line))
                    {
                        __out.Write(__tmp125_line);
                        __tmp118_outputWritten = true;
                    }
                    if (__tmp118_outputWritten) __out.AppendLine(true);
                    if (__tmp118_outputWritten)
                    {
                        __out.AppendLine(false); //915:180
                    }
                }
                __out.Write("        }"); //917:1
                __out.AppendLine(false); //917:10
                __out.Write("	}"); //918:1
                __out.AppendLine(false); //918:3
                __out.AppendLine(true); //919:1
            }
            __out.Write("}"); //921:1
            __out.AppendLine(false); //921:2
            return __out.ToStringAndFree();
        }

    }
}

