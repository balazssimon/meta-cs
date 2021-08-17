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
            __out.Write("        public "); //44:1
            if (symbol.IsSymbolClass) //44:17
            {
                __out.Write("virtual"); //44:43
            }
            else //44:51
            {
                __out.Write("override"); //44:56
            }
            __out.Write(" void Accept(MetaDslx.CodeAnalysis.Symbols.SymbolVisitor visitor)"); //44:72
            __out.AppendLine(false); //44:137
            __out.Write("        {"); //45:1
            __out.AppendLine(false); //45:10
            __out.Write("            if (visitor is ISymbolVisitor isv) isv.Visit(this);"); //46:1
            __out.AppendLine(false); //46:64
            __out.Write("        }"); //47:1
            __out.AppendLine(false); //47:10
            __out.AppendLine(true); //48:1
            __out.Write("        public "); //49:1
            if (symbol.IsSymbolClass) //49:17
            {
                __out.Write("virtual"); //49:43
            }
            else //49:51
            {
                __out.Write("override"); //49:56
            }
            __out.Write(" TResult Accept<TResult>(MetaDslx.CodeAnalysis.Symbols.SymbolVisitor<TResult> visitor)"); //49:72
            __out.AppendLine(false); //49:158
            __out.Write("        {"); //50:1
            __out.AppendLine(false); //50:10
            __out.Write("            if (visitor is ISymbolVisitor<TResult> isv) return isv.Visit(this);"); //51:1
            __out.AppendLine(false); //51:80
            __out.Write("            else return default(TResult);"); //52:1
            __out.AppendLine(false); //52:42
            __out.Write("        }"); //53:1
            __out.AppendLine(false); //53:10
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
            __out.Write(" TResult Accept<TArgument, TResult>(MetaDslx.CodeAnalysis.Symbols.SymbolVisitor<TArgument, TResult> visitor, TArgument argument)"); //55:72
            __out.AppendLine(false); //55:200
            __out.Write("        {"); //56:1
            __out.AppendLine(false); //56:10
            __out.Write("            if (visitor is ISymbolVisitor<TArgument, TResult> isv) return isv.Visit(this, argument);"); //57:1
            __out.AppendLine(false); //57:101
            __out.Write("            else return default(TResult);"); //58:1
            __out.AppendLine(false); //58:42
            __out.Write("        }"); //59:1
            __out.AppendLine(false); //59:10
            __out.Write("	}"); //60:1
            __out.AppendLine(false); //60:3
            __out.Write("}"); //61:1
            __out.AppendLine(false); //61:2
            return __out.ToStringAndFree();
        }

        public string GenerateCompletionSymbol(SymbolGenerationInfo symbol) //64:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //65:1
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
            string __tmp5_line = ".Completion"; //65:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //65:44
            }
            __out.Write("{"); //66:1
            __out.AppendLine(false); //66:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public abstract partial class Completion"; //67:1
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
            if (symbol.ExistingCompletionTypeInfo.BaseType == null) //67:56
            {
                string __tmp11_line = " : "; //67:112
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
                string __tmp13_line = "."; //67:137
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
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //67:152
                {
                    string __tmp16_line = ", MetaDslx.CodeAnalysis.Symbols.Metadata.IModelSymbol"; //67:209
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
                __out.AppendLine(false); //67:278
            }
            __out.Write("	{"); //68:1
            __out.AppendLine(false); //68:3
            __out.Write("        public static class CompletionParts"); //69:1
            __out.AppendLine(false); //69:44
            __out.Write("        {"); //70:1
            __out.AppendLine(false); //70:10
            var __loop1_results = 
                (from partName in __Enumerate((symbol.GetCompletionPartNames()).GetEnumerator()) //71:20
                select new { partName = partName}
                ).ToList(); //71:14
            for (int __loop1_iteration = 0; __loop1_iteration < __loop1_results.Count; ++__loop1_iteration)
            {
                var __tmp19 = __loop1_results[__loop1_iteration];
                var partName = __tmp19.partName;
                bool __tmp21_outputWritten = false;
                string __tmp22_line = "            public static readonly CompletionPart "; //72:1
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
                string __tmp24_line = " = new CompletionPart(nameof("; //72:61
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
                string __tmp26_line = "));"; //72:100
                if (!string.IsNullOrEmpty(__tmp26_line))
                {
                    __out.Write(__tmp26_line);
                    __tmp21_outputWritten = true;
                }
                if (__tmp21_outputWritten) __out.AppendLine(true);
                if (__tmp21_outputWritten)
                {
                    __out.AppendLine(false); //72:103
                }
            }
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "            public static readonly ImmutableHashSet<CompletionPart> AllWithLocation = CompletionPart.Combine("; //74:1
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Write(__tmp29_line);
                __tmp28_outputWritten = true;
            }
            var __loop2_results = 
                (from partName in __Enumerate((symbol.GetOrderedCompletionParts(true)).GetEnumerator()) //74:117
                select new { partName = partName}
                ).ToList(); //74:111
            for (int __loop2_iteration = 0; __loop2_iteration < __loop2_results.Count; ++__loop2_iteration)
            {
                string comma; //74:164
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
            string __tmp35_line = ");"; //74:217
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Write(__tmp35_line);
                __tmp28_outputWritten = true;
            }
            if (__tmp28_outputWritten) __out.AppendLine(true);
            if (__tmp28_outputWritten)
            {
                __out.AppendLine(false); //74:219
            }
            bool __tmp37_outputWritten = false;
            string __tmp38_line = "            public static readonly ImmutableHashSet<CompletionPart> All = CompletionPart.Combine("; //75:1
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Write(__tmp38_line);
                __tmp37_outputWritten = true;
            }
            var __loop3_results = 
                (from partName in __Enumerate((symbol.GetOrderedCompletionParts(false)).GetEnumerator()) //75:105
                select new { partName = partName}
                ).ToList(); //75:99
            for (int __loop3_iteration = 0; __loop3_iteration < __loop3_results.Count; ++__loop3_iteration)
            {
                string comma; //75:153
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
            string __tmp44_line = ");"; //75:206
            if (!string.IsNullOrEmpty(__tmp44_line))
            {
                __out.Write(__tmp44_line);
                __tmp37_outputWritten = true;
            }
            if (__tmp37_outputWritten) __out.AppendLine(true);
            if (__tmp37_outputWritten)
            {
                __out.AppendLine(false); //75:208
            }
            bool __tmp46_outputWritten = false;
            string __tmp47_line = "            public static readonly CompletionGraph CompletionGraph = CompletionGraph.FromCompletionParts("; //76:1
            if (!string.IsNullOrEmpty(__tmp47_line))
            {
                __out.Write(__tmp47_line);
                __tmp46_outputWritten = true;
            }
            var __loop4_results = 
                (from partName in __Enumerate((symbol.GetOrderedCompletionParts(false)).GetEnumerator()) //76:113
                select new { partName = partName}
                ).ToList(); //76:107
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                string comma; //76:161
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
            string __tmp53_line = ");"; //76:214
            if (!string.IsNullOrEmpty(__tmp53_line))
            {
                __out.Write(__tmp53_line);
                __tmp46_outputWritten = true;
            }
            if (__tmp46_outputWritten) __out.AppendLine(true);
            if (__tmp46_outputWritten)
            {
                __out.AppendLine(false); //76:216
            }
            __out.Write("        }"); //77:1
            __out.AppendLine(false); //77:10
            __out.AppendLine(true); //78:1
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //79:10
            {
                __out.Write("        private readonly Symbol _container;"); //80:1
                __out.AppendLine(false); //80:44
            }
            if (symbol.ModelObjectOption != ParameterOption.Disabled) //82:10
            {
                __out.Write("        private readonly object? _modelObject;"); //83:1
                __out.AppendLine(false); //83:47
            }
            __out.Write("        private readonly CompletionState _state;"); //85:1
            __out.AppendLine(false); //85:49
            __out.Write("        private ImmutableArray<Symbol> _childSymbols;"); //86:1
            __out.AppendLine(false); //86:54
            __out.Write("        private string _name;"); //87:1
            __out.AppendLine(false); //87:30
            var __loop5_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //88:16
                select new { prop = prop}
                ).ToList(); //88:10
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                var __tmp54 = __loop5_results[__loop5_iteration];
                var prop = __tmp54.prop;
                bool __tmp56_outputWritten = false;
                string __tmp57_line = "        private "; //89:1
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
                string __tmp59_line = " "; //89:28
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
                string __tmp61_line = ";"; //89:45
                if (!string.IsNullOrEmpty(__tmp61_line))
                {
                    __out.Write(__tmp61_line);
                    __tmp56_outputWritten = true;
                }
                if (__tmp56_outputWritten) __out.AppendLine(true);
                if (__tmp56_outputWritten)
                {
                    __out.AppendLine(false); //89:46
                }
            }
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //91:10
            {
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains(".ctor")) //92:10
                {
                    __out.AppendLine(true); //93:1
                    bool __tmp63_outputWritten = false;
                    string __tmp64_line = "        public Completion"; //94:1
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
                    string __tmp66_line = "(Symbol container"; //94:39
                    if (!string.IsNullOrEmpty(__tmp66_line))
                    {
                        __out.Write(__tmp66_line);
                        __tmp63_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //94:57
                    {
                        string __tmp68_line = ", object? modelObject"; //94:114
                        if (!string.IsNullOrEmpty(__tmp68_line))
                        {
                            __out.Write(__tmp68_line);
                            __tmp63_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //94:136
                        {
                            string __tmp70_line = " = null"; //94:193
                            if (!string.IsNullOrEmpty(__tmp70_line))
                            {
                                __out.Write(__tmp70_line);
                                __tmp63_outputWritten = true;
                            }
                        }
                    }
                    string __tmp73_line = ", bool isError = false)"; //94:216
                    if (!string.IsNullOrEmpty(__tmp73_line))
                    {
                        __out.Write(__tmp73_line);
                        __tmp63_outputWritten = true;
                    }
                    if (__tmp63_outputWritten) __out.AppendLine(true);
                    if (__tmp63_outputWritten)
                    {
                        __out.AppendLine(false); //94:239
                    }
                    __out.Write("        {"); //95:1
                    __out.AppendLine(false); //95:10
                    __out.Write("            _container = container;"); //96:1
                    __out.AppendLine(false); //96:36
                    if (symbol.ModelObjectOption == ParameterOption.Required) //97:14
                    {
                        __out.Write("            if (!isError && modelObject is null) throw new ArgumentNullException(nameof(modelObject));"); //98:1
                        __out.AppendLine(false); //98:103
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //100:14
                    {
                        __out.Write("            _modelObject = modelObject;"); //101:1
                        __out.AppendLine(false); //101:40
                    }
                    __out.Write("            _state = CompletionParts.CompletionGraph.CreateState();"); //103:1
                    __out.AppendLine(false); //103:68
                    __out.Write("        }"); //104:1
                    __out.AppendLine(false); //104:10
                }
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains("Language")) //106:10
                {
                    __out.AppendLine(true); //107:1
                    __out.Write("        public override Language Language => ContainingModule.Language;"); //108:1
                    __out.AppendLine(false); //108:72
                }
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains("SymbolFactory")) //110:10
                {
                    __out.AppendLine(true); //111:1
                    __out.Write("        public SymbolFactory SymbolFactory => ContainingModule.SymbolFactory;"); //112:1
                    __out.AppendLine(false); //112:78
                }
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //114:10
                {
                    if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ModelObject")) //115:14
                    {
                        __out.AppendLine(true); //116:1
                        __out.Write("        public object ModelObject => _modelObject;"); //117:1
                        __out.AppendLine(false); //117:51
                    }
                    if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ModelObjectType")) //119:14
                    {
                        __out.AppendLine(true); //120:1
                        __out.Write("        public Type ModelObjectType => _modelObject is not null ? Language.SymbolFacts.GetModelObjectType(_modelObject) : null;"); //121:1
                        __out.AppendLine(false); //121:128
                    }
                }
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ContainingSymbol")) //124:10
                {
                    __out.AppendLine(true); //125:1
                    __out.Write("        public override Symbol ContainingSymbol => _container;"); //126:1
                    __out.AppendLine(false); //126:63
                }
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ChildSymbols")) //129:10
            {
                __out.AppendLine(true); //130:1
                __out.Write("        public override ImmutableArray<Symbol> ChildSymbols "); //131:1
                __out.AppendLine(false); //131:61
                __out.Write("        {"); //132:1
                __out.AppendLine(false); //132:10
                __out.Write("            get"); //133:1
                __out.AppendLine(false); //133:16
                __out.Write("            {"); //134:1
                __out.AppendLine(false); //134:14
                __out.Write("                this.ForceComplete(CompletionGraph.FinishCreatingChildren, null, default);"); //135:1
                __out.AppendLine(false); //135:91
                __out.Write("                return _childSymbols;"); //136:1
                __out.AppendLine(false); //136:38
                __out.Write("            }"); //137:1
                __out.AppendLine(false); //137:14
                __out.Write("        }"); //138:1
                __out.AppendLine(false); //138:10
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("Name")) //140:10
            {
                __out.AppendLine(true); //141:1
                __out.Write("        public override string Name "); //142:1
                __out.AppendLine(false); //142:37
                __out.Write("        {"); //143:1
                __out.AppendLine(false); //143:10
                __out.Write("            get"); //144:1
                __out.AppendLine(false); //144:16
                __out.Write("            {"); //145:1
                __out.AppendLine(false); //145:14
                __out.Write("                this.ForceComplete(CompletionGraph.FinishInitializing, null, default);"); //146:1
                __out.AppendLine(false); //146:87
                __out.Write("                return _name;"); //147:1
                __out.AppendLine(false); //147:30
                __out.Write("            }"); //148:1
                __out.AppendLine(false); //148:14
                __out.Write("        }"); //149:1
                __out.AppendLine(false); //149:10
            }
            var __loop6_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //151:16
                select new { prop = prop}
                ).ToList(); //151:10
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp74 = __loop6_results[__loop6_iteration];
                var prop = __tmp74.prop;
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains(prop.Name)) //152:14
                {
                    __out.AppendLine(true); //153:1
                    bool __tmp76_outputWritten = false;
                    string __tmp77_line = "        public override "; //154:1
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
                    string __tmp79_line = " "; //154:36
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
                        __out.AppendLine(false); //154:48
                    }
                    __out.Write("        {"); //155:1
                    __out.AppendLine(false); //155:10
                    __out.Write("            get"); //156:1
                    __out.AppendLine(false); //156:16
                    __out.Write("            {"); //157:1
                    __out.AppendLine(false); //157:14
                    bool __tmp82_outputWritten = false;
                    string __tmp83_line = "                this.ForceComplete(CompletionParts."; //158:1
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
                    string __tmp85_line = ", null, default);"; //158:83
                    if (!string.IsNullOrEmpty(__tmp85_line))
                    {
                        __out.Write(__tmp85_line);
                        __tmp82_outputWritten = true;
                    }
                    if (__tmp82_outputWritten) __out.AppendLine(true);
                    if (__tmp82_outputWritten)
                    {
                        __out.AppendLine(false); //158:100
                    }
                    bool __tmp87_outputWritten = false;
                    string __tmp88_line = "                return "; //159:1
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
                    string __tmp90_line = ";"; //159:40
                    if (!string.IsNullOrEmpty(__tmp90_line))
                    {
                        __out.Write(__tmp90_line);
                        __tmp87_outputWritten = true;
                    }
                    if (__tmp87_outputWritten) __out.AppendLine(true);
                    if (__tmp87_outputWritten)
                    {
                        __out.AppendLine(false); //159:41
                    }
                    __out.Write("            }"); //160:1
                    __out.AppendLine(false); //160:14
                    __out.Write("        }"); //161:1
                    __out.AppendLine(false); //161:10
                }
            }
            __out.AppendLine(true); //164:1
            __out.Write("        #region Completion"); //165:1
            __out.AppendLine(false); //165:27
            __out.AppendLine(true); //166:1
            __out.Write("        public sealed override bool RequiresCompletion => true;"); //167:1
            __out.AppendLine(false); //167:64
            __out.AppendLine(true); //168:1
            __out.Write("        public sealed override bool HasComplete(CompletionPart part)"); //169:1
            __out.AppendLine(false); //169:69
            __out.Write("        {"); //170:1
            __out.AppendLine(false); //170:10
            __out.Write("            return _state.HasComplete(part);"); //171:1
            __out.AppendLine(false); //171:45
            __out.Write("        }"); //172:1
            __out.AppendLine(false); //172:10
            __out.AppendLine(true); //173:1
            __out.Write("        public override void ForceComplete(CompletionPart completionPart, SourceLocation locationOpt, CancellationToken cancellationToken)"); //174:1
            __out.AppendLine(false); //174:139
            __out.Write("        {"); //175:1
            __out.AppendLine(false); //175:10
            __out.Write("            if (completionPart != null && _state.HasComplete(completionPart)) return;"); //176:1
            __out.AppendLine(false); //176:86
            __out.Write("            if (completionPart != null && !CompletionParts.All.Contains(completionPart)) throw new ArgumentException(nameof(completionPart));"); //177:1
            __out.AppendLine(false); //177:142
            __out.Write("            while (true)"); //178:1
            __out.AppendLine(false); //178:25
            __out.Write("            {"); //179:1
            __out.AppendLine(false); //179:14
            __out.Write("                cancellationToken.ThrowIfCancellationRequested();"); //180:1
            __out.AppendLine(false); //180:66
            __out.Write("                var incompletePart = _state.NextIncompletePart;"); //181:1
            __out.AppendLine(false); //181:64
            __out.Write("                if (incompletePart == CompletionGraph.StartInitializing || incompletePart == CompletionGraph.FinishInitializing)"); //182:1
            __out.AppendLine(false); //182:129
            __out.Write("                {"); //183:1
            __out.AppendLine(false); //183:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartInitializing))"); //184:1
            __out.AppendLine(false); //184:84
            __out.Write("                    {"); //185:1
            __out.AppendLine(false); //185:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //186:1
            __out.AppendLine(false); //186:71
            __out.Write("                        _name = CompleteSymbolProperty_Name(diagnostics, cancellationToken);"); //187:1
            __out.AppendLine(false); //187:93
            __out.Write("                        CompleteInitializingSymbol(diagnostics, cancellationToken);"); //188:1
            __out.AppendLine(false); //188:84
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //189:1
            __out.AppendLine(false); //189:59
            __out.Write("                        diagnostics.Free();"); //190:1
            __out.AppendLine(false); //190:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishInitializing);"); //191:1
            __out.AppendLine(false); //191:85
            __out.Write("                    }"); //192:1
            __out.AppendLine(false); //192:22
            __out.Write("                }"); //193:1
            __out.AppendLine(false); //193:18
            __out.Write("                else if (incompletePart == CompletionGraph.StartCreatingChildren || incompletePart == CompletionGraph.FinishCreatingChildren)"); //194:1
            __out.AppendLine(false); //194:142
            __out.Write("                {"); //195:1
            __out.AppendLine(false); //195:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartCreatingChildren))"); //196:1
            __out.AppendLine(false); //196:88
            __out.Write("                    {"); //197:1
            __out.AppendLine(false); //197:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //198:1
            __out.AppendLine(false); //198:71
            __out.Write("                        _childSymbols = CompleteCreatingChildSymbols(diagnostics, cancellationToken);"); //199:1
            __out.AppendLine(false); //199:102
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //200:1
            __out.AppendLine(false); //200:59
            __out.Write("                        diagnostics.Free();"); //201:1
            __out.AppendLine(false); //201:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishCreatingChildren);"); //202:1
            __out.AppendLine(false); //202:89
            __out.Write("                    }"); //203:1
            __out.AppendLine(false); //203:22
            __out.Write("                }"); //204:1
            __out.AppendLine(false); //204:18
            var __loop7_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //205:24
                select new { part = part}
                ).ToList(); //205:18
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                var __tmp91 = __loop7_results[__loop7_iteration];
                var part = __tmp91.part;
                if (part.IsLocked) //206:22
                {
                    bool __tmp93_outputWritten = false;
                    string __tmp94_line = "                else if (incompletePart == CompletionParts."; //207:1
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
                    string __tmp96_line = " || incompletePart == CompletionParts."; //207:90
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
                    string __tmp98_line = ")"; //207:159
                    if (!string.IsNullOrEmpty(__tmp98_line))
                    {
                        __out.Write(__tmp98_line);
                        __tmp93_outputWritten = true;
                    }
                    if (__tmp93_outputWritten) __out.AppendLine(true);
                    if (__tmp93_outputWritten)
                    {
                        __out.AppendLine(false); //207:160
                    }
                    __out.Write("                {"); //208:1
                    __out.AppendLine(false); //208:18
                    bool __tmp100_outputWritten = false;
                    string __tmp101_line = "                    if (_state.NotePartComplete(CompletionParts."; //209:1
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
                    string __tmp103_line = "))"; //209:95
                    if (!string.IsNullOrEmpty(__tmp103_line))
                    {
                        __out.Write(__tmp103_line);
                        __tmp100_outputWritten = true;
                    }
                    if (__tmp100_outputWritten) __out.AppendLine(true);
                    if (__tmp100_outputWritten)
                    {
                        __out.AppendLine(false); //209:97
                    }
                    __out.Write("                    {"); //210:1
                    __out.AppendLine(false); //210:22
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //211:26
                    {
                        __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //212:1
                        __out.AppendLine(false); //212:71
                    }
                    bool __tmp105_outputWritten = false;
                    string __tmp104Prefix = "                        "; //214:1
                    if (part is SymbolPropertyGenerationInfo) //214:26
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
                        string __tmp108_line = " = "; //214:116
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
                    string __tmp111_line = "("; //214:152
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
                    string __tmp113_line = ");"; //214:181
                    if (!string.IsNullOrEmpty(__tmp113_line))
                    {
                        __out.Write(__tmp113_line);
                        __tmp105_outputWritten = true;
                    }
                    if (__tmp105_outputWritten) __out.AppendLine(true);
                    if (__tmp105_outputWritten)
                    {
                        __out.AppendLine(false); //214:183
                    }
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //215:26
                    {
                        __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //216:1
                        __out.AppendLine(false); //216:59
                        __out.Write("                        diagnostics.Free();"); //217:1
                        __out.AppendLine(false); //217:44
                    }
                    bool __tmp115_outputWritten = false;
                    string __tmp116_line = "                        _state.NotePartComplete(CompletionParts."; //219:1
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
                    string __tmp118_line = ");"; //219:96
                    if (!string.IsNullOrEmpty(__tmp118_line))
                    {
                        __out.Write(__tmp118_line);
                        __tmp115_outputWritten = true;
                    }
                    if (__tmp115_outputWritten) __out.AppendLine(true);
                    if (__tmp115_outputWritten)
                    {
                        __out.AppendLine(false); //219:98
                    }
                    __out.Write("                    }"); //220:1
                    __out.AppendLine(false); //220:22
                    __out.Write("                }"); //221:1
                    __out.AppendLine(false); //221:18
                }
                else //222:22
                {
                    bool __tmp120_outputWritten = false;
                    string __tmp121_line = "                else if (incompletePart == CompletionParts."; //223:1
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
                    string __tmp123_line = ")"; //223:85
                    if (!string.IsNullOrEmpty(__tmp123_line))
                    {
                        __out.Write(__tmp123_line);
                        __tmp120_outputWritten = true;
                    }
                    if (__tmp120_outputWritten) __out.AppendLine(true);
                    if (__tmp120_outputWritten)
                    {
                        __out.AppendLine(false); //223:86
                    }
                    __out.Write("                {"); //224:1
                    __out.AppendLine(false); //224:18
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //225:22
                    {
                        __out.Write("                    var diagnostics = DiagnosticBag.GetInstance();"); //226:1
                        __out.AppendLine(false); //226:67
                    }
                    bool __tmp125_outputWritten = false;
                    string __tmp124Prefix = "                    "; //228:1
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
                    string __tmp127_line = "("; //228:46
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
                    string __tmp129_line = ");"; //228:75
                    if (!string.IsNullOrEmpty(__tmp129_line))
                    {
                        __out.Write(__tmp129_line);
                        __tmp125_outputWritten = true;
                    }
                    if (__tmp125_outputWritten) __out.AppendLine(true);
                    if (__tmp125_outputWritten)
                    {
                        __out.AppendLine(false); //228:77
                    }
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //229:22
                    {
                        __out.Write("                    AddSymbolDiagnostics(diagnostics);"); //230:1
                        __out.AppendLine(false); //230:55
                        __out.Write("                    diagnostics.Free();"); //231:1
                        __out.AppendLine(false); //231:40
                    }
                    bool __tmp131_outputWritten = false;
                    string __tmp132_line = "                    _state.NotePartComplete(CompletionParts."; //233:1
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
                    string __tmp134_line = ");"; //233:86
                    if (!string.IsNullOrEmpty(__tmp134_line))
                    {
                        __out.Write(__tmp134_line);
                        __tmp131_outputWritten = true;
                    }
                    if (__tmp131_outputWritten) __out.AppendLine(true);
                    if (__tmp131_outputWritten)
                    {
                        __out.AppendLine(false); //233:88
                    }
                    __out.Write("                }"); //234:1
                    __out.AppendLine(false); //234:18
                }
            }
            __out.Write("                else if (incompletePart == CompletionGraph.StartComputingNonSymbolProperties || incompletePart == CompletionGraph.FinishComputingNonSymbolProperties)"); //237:1
            __out.AppendLine(false); //237:166
            __out.Write("                {"); //238:1
            __out.AppendLine(false); //238:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartComputingNonSymbolProperties))"); //239:1
            __out.AppendLine(false); //239:100
            __out.Write("                    {"); //240:1
            __out.AppendLine(false); //240:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //241:1
            __out.AppendLine(false); //241:71
            __out.Write("                        CompleteNonSymbolProperties(locationOpt, diagnostics, cancellationToken);"); //242:1
            __out.AppendLine(false); //242:98
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //243:1
            __out.AppendLine(false); //243:59
            __out.Write("                        diagnostics.Free();"); //244:1
            __out.AppendLine(false); //244:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishComputingNonSymbolProperties);"); //245:1
            __out.AppendLine(false); //245:101
            __out.Write("                    }"); //246:1
            __out.AppendLine(false); //246:22
            __out.Write("                }"); //247:1
            __out.AppendLine(false); //247:18
            __out.Write("                else if (incompletePart == CompletionGraph.ChildrenCompleted)"); //248:1
            __out.AppendLine(false); //248:78
            __out.Write("                {"); //249:1
            __out.AppendLine(false); //249:18
            __out.Write("                    var diagnostics = DiagnosticBag.GetInstance();"); //250:1
            __out.AppendLine(false); //250:67
            __out.Write("                    CompleteImports(locationOpt, diagnostics, cancellationToken);"); //251:1
            __out.AppendLine(false); //251:82
            __out.Write("                    AddSymbolDiagnostics(diagnostics);"); //252:1
            __out.AppendLine(false); //252:55
            __out.Write("                    diagnostics.Free();"); //253:1
            __out.AppendLine(false); //253:40
            __out.Write("                    bool allCompleted = true;"); //255:1
            __out.AppendLine(false); //255:46
            __out.Write("                    if (locationOpt == null)"); //256:1
            __out.AppendLine(false); //256:45
            __out.Write("                    {"); //257:1
            __out.AppendLine(false); //257:22
            __out.Write("                        foreach (var child in _childSymbols)"); //258:1
            __out.AppendLine(false); //258:61
            __out.Write("                        {"); //259:1
            __out.AppendLine(false); //259:26
            __out.Write("                            cancellationToken.ThrowIfCancellationRequested();"); //260:1
            __out.AppendLine(false); //260:78
            __out.Write("                            child.ForceComplete(null, locationOpt, cancellationToken);"); //261:1
            __out.AppendLine(false); //261:87
            __out.Write("                        }"); //262:1
            __out.AppendLine(false); //262:26
            __out.Write("                    }"); //263:1
            __out.AppendLine(false); //263:22
            __out.Write("                    else"); //264:1
            __out.AppendLine(false); //264:25
            __out.Write("                    {"); //265:1
            __out.AppendLine(false); //265:22
            __out.Write("                        foreach (var child in _childSymbols)"); //266:1
            __out.AppendLine(false); //266:61
            __out.Write("                        {"); //267:1
            __out.AppendLine(false); //267:26
            __out.Write("                            ForceCompleteChildByLocation(locationOpt, child, cancellationToken);"); //268:1
            __out.AppendLine(false); //268:97
            __out.Write("                            allCompleted = allCompleted && child.HasComplete(CompletionGraph.All);"); //269:1
            __out.AppendLine(false); //269:99
            __out.Write("                        }"); //270:1
            __out.AppendLine(false); //270:26
            __out.Write("                    }"); //271:1
            __out.AppendLine(false); //271:22
            __out.Write("                    if (!allCompleted)"); //273:1
            __out.AppendLine(false); //273:39
            __out.Write("                    {"); //274:1
            __out.AppendLine(false); //274:22
            __out.Write("                        // We did not complete all members, so just kick out now."); //275:1
            __out.AppendLine(false); //275:82
            __out.Write("                        var allParts = CompletionParts.AllWithLocation;"); //276:1
            __out.AppendLine(false); //276:72
            __out.Write("                        _state.SpinWaitComplete(allParts, cancellationToken);"); //277:1
            __out.AppendLine(false); //277:78
            __out.Write("                        return;"); //278:1
            __out.AppendLine(false); //278:32
            __out.Write("                    }"); //279:1
            __out.AppendLine(false); //279:22
            __out.Write("                    // We've completed all members, proceed to the next iteration."); //281:1
            __out.AppendLine(false); //281:83
            __out.Write("                    _state.NotePartComplete(CompletionGraph.ChildrenCompleted);"); //282:1
            __out.AppendLine(false); //282:80
            __out.Write("                }"); //283:1
            __out.AppendLine(false); //283:18
            __out.Write("                else if (incompletePart == null)"); //284:1
            __out.AppendLine(false); //284:49
            __out.Write("                {"); //285:1
            __out.AppendLine(false); //285:18
            __out.Write("                    return;"); //286:1
            __out.AppendLine(false); //286:28
            __out.Write("                }"); //287:1
            __out.AppendLine(false); //287:18
            __out.Write("                else"); //288:1
            __out.AppendLine(false); //288:21
            __out.Write("                {"); //289:1
            __out.AppendLine(false); //289:18
            __out.Write("                    // This assert will trigger if we forgot to handle any of the completion parts"); //290:1
            __out.AppendLine(false); //290:99
            __out.Write("                    Debug.Assert(!CompletionParts.All.Contains(incompletePart));"); //291:1
            __out.AppendLine(false); //291:81
            __out.Write("                    // any other values are completion parts intended for other kinds of symbols"); //292:1
            __out.AppendLine(false); //292:97
            __out.Write("                    _state.NotePartComplete(incompletePart);"); //293:1
            __out.AppendLine(false); //293:61
            __out.Write("                }"); //294:1
            __out.AppendLine(false); //294:18
            __out.Write("                if (completionPart != null && _state.HasComplete(completionPart)) return;"); //295:1
            __out.AppendLine(false); //295:90
            __out.Write("                _state.SpinWaitComplete(incompletePart, cancellationToken);"); //296:1
            __out.AppendLine(false); //296:76
            __out.Write("            }"); //297:1
            __out.AppendLine(false); //297:14
            __out.Write("            throw ExceptionUtilities.Unreachable;"); //298:1
            __out.AppendLine(false); //298:50
            __out.Write("        }"); //299:1
            __out.AppendLine(false); //299:10
            __out.AppendLine(true); //300:1
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteSymbolProperty_Name")) //301:10
            {
                __out.Write("        protected abstract string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //302:1
                __out.AppendLine(false); //302:127
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteInitializingSymbol")) //304:10
            {
                __out.Write("        protected abstract void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //305:1
                __out.AppendLine(false); //305:124
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteCreatingChildSymbols")) //307:10
            {
                __out.Write("        protected abstract ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //308:1
                __out.AppendLine(false); //308:144
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteImports")) //310:10
            {
                __out.Write("        protected abstract void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //311:1
                __out.AppendLine(false); //311:141
            }
            var __loop8_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //313:16
                where part.GenerateCompleteMethod //313:44
                select new { part = part}
                ).ToList(); //313:10
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp135 = __loop8_results[__loop8_iteration];
                var part = __tmp135.part;
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains(part.CompleteMethodName)) //314:14
                {
                    bool __tmp137_outputWritten = false;
                    string __tmp138_line = "        protected abstract "; //315:1
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
                    string __tmp140_line = " "; //315:59
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
                    string __tmp142_line = "("; //315:85
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
                    string __tmp144_line = ");"; //315:116
                    if (!string.IsNullOrEmpty(__tmp144_line))
                    {
                        __out.Write(__tmp144_line);
                        __tmp137_outputWritten = true;
                    }
                    if (__tmp137_outputWritten) __out.AppendLine(true);
                    if (__tmp137_outputWritten)
                    {
                        __out.AppendLine(false); //315:118
                    }
                }
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteNonSymbolProperties")) //318:10
            {
                __out.Write("        protected abstract void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //319:1
                __out.AppendLine(false); //319:153
            }
            __out.Write("        #endregion"); //321:1
            __out.AppendLine(false); //321:19
            __out.Write("    }"); //322:1
            __out.AppendLine(false); //322:6
            __out.Write("}"); //323:1
            __out.AppendLine(false); //323:2
            return __out.ToStringAndFree();
        }

        public string GenerateMetadataSymbol(SymbolGenerationInfo symbol) //326:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //327:1
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
            string __tmp5_line = ".Metadata"; //327:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //327:42
            }
            __out.Write("{"); //328:1
            __out.AppendLine(false); //328:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Metadata"; //329:1
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
            if (symbol.ExistingMetadataTypeInfo.BaseType == null) //329:45
            {
                string __tmp11_line = " : "; //329:99
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
                string __tmp13_line = ".Completion.Completion"; //329:124
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
                __out.AppendLine(false); //329:167
            }
            __out.Write("	{"); //330:1
            __out.AppendLine(false); //330:3
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //331:10
            {
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //332:10
                {
                    bool __tmp17_outputWritten = false;
                    string __tmp18_line = "        public Metadata"; //333:1
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
                    string __tmp20_line = "(Symbol container"; //333:37
                    if (!string.IsNullOrEmpty(__tmp20_line))
                    {
                        __out.Write(__tmp20_line);
                        __tmp17_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //333:55
                    {
                        string __tmp22_line = ", object? modelObject"; //333:112
                        if (!string.IsNullOrEmpty(__tmp22_line))
                        {
                            __out.Write(__tmp22_line);
                            __tmp17_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //333:134
                        {
                            string __tmp24_line = " = null"; //333:191
                            if (!string.IsNullOrEmpty(__tmp24_line))
                            {
                                __out.Write(__tmp24_line);
                                __tmp17_outputWritten = true;
                            }
                        }
                    }
                    string __tmp27_line = ", bool isError = false)"; //333:214
                    if (!string.IsNullOrEmpty(__tmp27_line))
                    {
                        __out.Write(__tmp27_line);
                        __tmp17_outputWritten = true;
                    }
                    if (__tmp17_outputWritten) __out.AppendLine(true);
                    if (__tmp17_outputWritten)
                    {
                        __out.AppendLine(false); //333:237
                    }
                    __out.Write("            : base(container"); //334:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //334:30
                    {
                        __out.Write(", modelObject"); //334:87
                    }
                    __out.Write(", isError)"); //334:108
                    __out.AppendLine(false); //334:118
                    __out.Write("        {"); //335:1
                    __out.AppendLine(false); //335:10
                    __out.Write("        }"); //336:1
                    __out.AppendLine(false); //336:10
                }
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains("Locations")) //338:10
                {
                    __out.AppendLine(true); //339:1
                    __out.Write("        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;"); //340:1
                    __out.AppendLine(false); //340:95
                }
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains("DeclaringSyntaxReferences")) //342:10
                {
                    __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;"); //343:1
                    __out.AppendLine(false); //343:124
                }
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteSymbolProperty_Name")) //346:10
            {
                __out.AppendLine(true); //347:1
                __out.Write("        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //348:1
                __out.AppendLine(false); //348:126
                __out.Write("        {"); //349:1
                __out.AppendLine(false); //349:10
                __out.Write("            return MetadataSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //350:1
                __out.AppendLine(false); //350:135
                __out.Write("        }"); //351:1
                __out.AppendLine(false); //351:10
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteInitializingSymbol")) //353:10
            {
                __out.AppendLine(true); //354:1
                __out.Write("        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //355:1
                __out.AppendLine(false); //355:123
                __out.Write("        {"); //356:1
                __out.AppendLine(false); //356:10
                __out.Write("        }"); //357:1
                __out.AppendLine(false); //357:10
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteCreatingChildSymbols")) //359:10
            {
                __out.AppendLine(true); //360:1
                __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //361:1
                __out.AppendLine(false); //361:143
                __out.Write("        {"); //362:1
                __out.AppendLine(false); //362:10
                __out.Write("            return MetadataSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //363:1
                __out.AppendLine(false); //363:126
                __out.Write("        }"); //364:1
                __out.AppendLine(false); //364:10
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteImports")) //366:10
            {
                __out.AppendLine(true); //367:1
                __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //368:1
                __out.AppendLine(false); //368:140
                __out.Write("        {"); //369:1
                __out.AppendLine(false); //369:10
                __out.Write("        }"); //370:1
                __out.AppendLine(false); //370:10
            }
            var __loop9_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //372:16
                where part.GenerateCompleteMethod //372:44
                select new { part = part}
                ).ToList(); //372:10
            for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
            {
                var __tmp28 = __loop9_results[__loop9_iteration];
                var part = __tmp28.part;
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains(part.CompleteMethodName)) //373:14
                {
                    __out.AppendLine(true); //374:1
                    bool __tmp30_outputWritten = false;
                    string __tmp31_line = "        protected override "; //375:1
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
                    string __tmp33_line = " "; //375:59
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
                    string __tmp35_line = "("; //375:85
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
                    string __tmp37_line = ")"; //375:116
                    if (!string.IsNullOrEmpty(__tmp37_line))
                    {
                        __out.Write(__tmp37_line);
                        __tmp30_outputWritten = true;
                    }
                    if (__tmp30_outputWritten) __out.AppendLine(true);
                    if (__tmp30_outputWritten)
                    {
                        __out.AppendLine(false); //375:117
                    }
                    __out.Write("        {"); //376:1
                    __out.AppendLine(false); //376:10
                    if (part is SymbolPropertyGenerationInfo) //377:14
                    {
                        var prop = (SymbolPropertyGenerationInfo)part; //378:18
                        if (prop.IsCollection) //379:18
                        {
                            bool __tmp39_outputWritten = false;
                            string __tmp40_line = "            return MetadataSymbolImplementation.AssignSymbolPropertyValues<"; //380:1
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
                            string __tmp42_line = ">(this, nameof("; //380:91
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
                            string __tmp44_line = "), diagnostics, cancellationToken);"; //380:117
                            if (!string.IsNullOrEmpty(__tmp44_line))
                            {
                                __out.Write(__tmp44_line);
                                __tmp39_outputWritten = true;
                            }
                            if (__tmp39_outputWritten) __out.AppendLine(true);
                            if (__tmp39_outputWritten)
                            {
                                __out.AppendLine(false); //380:152
                            }
                        }
                        else //381:18
                        {
                            bool __tmp46_outputWritten = false;
                            string __tmp47_line = "            return MetadataSymbolImplementation.AssignSymbolPropertyValue<"; //382:1
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
                            string __tmp49_line = ">(this, nameof("; //382:86
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
                            string __tmp51_line = "), diagnostics, cancellationToken);"; //382:112
                            if (!string.IsNullOrEmpty(__tmp51_line))
                            {
                                __out.Write(__tmp51_line);
                                __tmp46_outputWritten = true;
                            }
                            if (__tmp46_outputWritten) __out.AppendLine(true);
                            if (__tmp46_outputWritten)
                            {
                                __out.AppendLine(false); //382:147
                            }
                        }
                    }
                    __out.Write("        }"); //385:1
                    __out.AppendLine(false); //385:10
                }
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteNonSymbolProperties")) //388:10
            {
                __out.AppendLine(true); //389:1
                __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //390:1
                __out.AppendLine(false); //390:152
                __out.Write("        {"); //391:1
                __out.AppendLine(false); //391:10
                __out.Write("        }"); //392:1
                __out.AppendLine(false); //392:10
            }
            __out.AppendLine(true); //394:1
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //395:10
            {
                bool __tmp53_outputWritten = false;
                string __tmp54_line = "        public partial class Error : Metadata"; //396:1
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
                string __tmp56_line = ", MetaDslx.CodeAnalysis.Symbols.IErrorSymbol"; //396:59
                if (!string.IsNullOrEmpty(__tmp56_line))
                {
                    __out.Write(__tmp56_line);
                    __tmp53_outputWritten = true;
                }
                if (__tmp53_outputWritten) __out.AppendLine(true);
                if (__tmp53_outputWritten)
                {
                    __out.AppendLine(false); //396:103
                }
                __out.Write("        {"); //397:1
                __out.AppendLine(false); //397:10
                __out.Write("            private readonly string _name;"); //398:1
                __out.AppendLine(false); //398:43
                __out.Write("            private readonly string _metadataName;"); //399:1
                __out.AppendLine(false); //399:51
                __out.Write("            private DiagnosticInfo _errorInfo;"); //400:1
                __out.AppendLine(false); //400:47
                __out.Write("            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorKind _kind;"); //401:1
                __out.AppendLine(false); //401:76
                __out.Write("            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags _flags;"); //402:1
                __out.AppendLine(false); //402:84
                __out.Write("            private ImmutableArray<Symbol> _candidateSymbols;"); //403:1
                __out.AppendLine(false); //403:62
                __out.AppendLine(true); //404:1
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //405:14
                {
                    __out.Write("            private Error(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags"); //406:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //406:246
                    {
                        __out.Write(", object? modelObject"); //406:303
                    }
                    __out.Write(")"); //406:332
                    __out.AppendLine(false); //406:333
                    __out.Write("                : base(container"); //407:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //407:34
                    {
                        __out.Write(", modelObject"); //407:91
                    }
                    __out.Write(", true)"); //407:112
                    __out.AppendLine(false); //407:119
                    __out.Write("            {"); //408:1
                    __out.AppendLine(false); //408:14
                    __out.Write("                Debug.Assert(!flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported) || errorInfo != null);"); //409:1
                    __out.AppendLine(false); //409:126
                    __out.Write("                _name = name;"); //410:1
                    __out.AppendLine(false); //410:30
                    __out.Write("                _metadataName = metadataName;"); //411:1
                    __out.AppendLine(false); //411:46
                    __out.Write("                _kind = kind;"); //412:1
                    __out.AppendLine(false); //412:30
                    __out.Write("                _errorInfo = errorInfo;"); //413:1
                    __out.AppendLine(false); //413:40
                    __out.Write("                _candidateSymbols = candidateSymbols;"); //414:1
                    __out.AppendLine(false); //414:54
                    __out.Write("                _flags = flags;"); //415:1
                    __out.AppendLine(false); //415:32
                    __out.Write("            }"); //416:1
                    __out.AppendLine(false); //416:14
                    __out.Write("            public Error(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported"); //418:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //418:208
                    {
                        __out.Write(", object? modelObject"); //418:265
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //418:287
                        {
                            __out.Write(" = null"); //418:344
                        }
                    }
                    __out.Write(")"); //418:367
                    __out.AppendLine(false); //418:368
                    __out.Write("                : this(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.None"); //419:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //419:215
                    {
                        __out.Write(", modelObject"); //419:272
                    }
                    __out.Write(")"); //419:293
                    __out.AppendLine(false); //419:294
                    __out.Write("            {"); //420:1
                    __out.AppendLine(false); //420:14
                    __out.Write("            }"); //421:1
                    __out.AppendLine(false); //421:14
                    __out.Write("            public Error(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported"); //423:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //423:137
                    {
                        __out.Write(", object? modelObject"); //423:194
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //423:216
                        {
                            __out.Write(" = null"); //423:273
                        }
                    }
                    __out.Write(")"); //423:296
                    __out.AppendLine(false); //423:297
                    __out.Write("                : this(wrappedSymbol.ContainingSymbol, wrappedSymbol.Name, wrappedSymbol.MetadataName, kind, errorInfo, ImmutableArray.Create<Symbol>(wrappedSymbol), unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.UnreportedWrapped : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Wrapped"); //424:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //424:302
                    {
                        __out.Write(", modelObject is not null ? modelObject : (wrappedSymbol as IModelSymbol)?.ModelObject"); //424:359
                    }
                    __out.Write(")"); //424:453
                    __out.AppendLine(false); //424:454
                    __out.Write("            {"); //425:1
                    __out.AppendLine(false); //425:14
                    __out.Write("            }"); //426:1
                    __out.AppendLine(false); //426:14
                    __out.AppendLine(true); //427:1
                    __out.Write("            protected virtual Error Update(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags"); //428:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //428:263
                    {
                        __out.Write(", object? modelObject"); //428:320
                    }
                    __out.Write(")"); //428:349
                    __out.AppendLine(false); //428:350
                    __out.Write("            {"); //429:1
                    __out.AppendLine(false); //429:14
                    __out.Write("                return new Error(container, name, metadataName, kind, errorInfo, candidateSymbols, flags"); //430:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //430:106
                    {
                        __out.Write(", modelObject"); //430:163
                    }
                    __out.Write(");"); //430:184
                    __out.AppendLine(false); //430:186
                    __out.Write("            }"); //431:1
                    __out.AppendLine(false); //431:14
                }
                __out.AppendLine(true); //433:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsUnreported(DiagnosticInfo? errorInfo = null)"); //434:1
                __out.AppendLine(false); //434:103
                __out.Write("            {"); //435:1
                __out.AppendLine(false); //435:14
                __out.Write("                return this.IsUnreported ? this :"); //436:1
                __out.AppendLine(false); //436:50
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, _kind, errorInfo is null ? ErrorInfo : errorInfo, CandidateSymbols, _flags | MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported"); //437:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //437:208
                {
                    __out.Write(", this.ModelObject"); //437:265
                }
                __out.Write(");"); //437:291
                __out.AppendLine(false); //437:293
                __out.Write("            }"); //438:1
                __out.AppendLine(false); //438:14
                __out.AppendLine(true); //439:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsReported(DiagnosticInfo? errorInfo = null)"); //440:1
                __out.AppendLine(false); //440:101
                __out.Write("            {"); //441:1
                __out.AppendLine(false); //441:14
                __out.Write("                return this.IsUnreported ? this :"); //442:1
                __out.AppendLine(false); //442:50
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, _kind, errorInfo is null ? ErrorInfo : errorInfo, CandidateSymbols, _flags & ~MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported"); //443:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //443:209
                {
                    __out.Write(", this.ModelObject"); //443:266
                }
                __out.Write(");"); //443:292
                __out.AppendLine(false); //443:294
                __out.Write("            }"); //444:1
                __out.AppendLine(false); //444:14
                __out.AppendLine(true); //445:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind)"); //446:1
                __out.AppendLine(false); //446:109
                __out.Write("            {"); //447:1
                __out.AppendLine(false); //447:14
                __out.Write("                return _kind == kind ? this :"); //448:1
                __out.AppendLine(false); //448:46
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, kind, ErrorInfo, CandidateSymbols, _flags"); //449:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //449:115
                {
                    __out.Write(", this.ModelObject"); //449:172
                }
                __out.Write(");"); //449:198
                __out.AppendLine(false); //449:200
                __out.Write("            }"); //450:1
                __out.AppendLine(false); //450:14
                __out.AppendLine(true); //451:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, ImmutableArray<MetaDslx.CodeAnalysis.Symbols.Symbol> candidateSymbols)"); //452:1
                __out.AppendLine(false); //452:180
                __out.Write("            {"); //453:1
                __out.AppendLine(false); //453:14
                __out.Write("                return _kind == kind && CandidateSymbols == candidateSymbols ? this :"); //454:1
                __out.AppendLine(false); //454:86
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, kind, ErrorInfo, candidateSymbols, _flags"); //455:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //455:115
                {
                    __out.Write(", this.ModelObject"); //455:172
                }
                __out.Write(");"); //455:198
                __out.AppendLine(false); //455:200
                __out.Write("            }"); //456:1
                __out.AppendLine(false); //456:14
                __out.AppendLine(true); //457:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo errorInfo, ImmutableArray<MetaDslx.CodeAnalysis.Symbols.Symbol> candidateSymbols)"); //458:1
                __out.AppendLine(false); //458:206
                __out.Write("            {"); //459:1
                __out.AppendLine(false); //459:14
                __out.Write("                return _kind == kind && ErrorInfo == errorInfo && CandidateSymbols == candidateSymbols ? this :"); //460:1
                __out.AppendLine(false); //460:112
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, kind, errorInfo, candidateSymbols, _flags"); //461:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //461:115
                {
                    __out.Write(", this.ModelObject"); //461:172
                }
                __out.Write(");"); //461:198
                __out.AppendLine(false); //461:200
                __out.Write("            }"); //462:1
                __out.AppendLine(false); //462:14
                __out.AppendLine(true); //463:1
                __out.Write("            public override string Name => _name;"); //464:1
                __out.AppendLine(false); //464:50
                __out.AppendLine(true); //465:1
                __out.Write("            public override string MetadataName => _metadataName;"); //466:1
                __out.AppendLine(false); //466:66
                __out.AppendLine(true); //467:1
                __out.Write("            public sealed override bool IsError => true;"); //468:1
                __out.AppendLine(false); //468:57
                __out.AppendLine(true); //469:1
                __out.Write("            public bool IsUnreported => _flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported);"); //470:1
                __out.AppendLine(false); //470:115
                __out.AppendLine(true); //471:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.ErrorKind ErrorKind => _kind;"); //472:1
                __out.AppendLine(false); //472:79
                __out.AppendLine(true); //473:1
                __out.Write("            public ImmutableArray<Symbol> CandidateSymbols"); //474:1
                __out.AppendLine(false); //474:59
                __out.Write("            {"); //475:1
                __out.AppendLine(false); //475:14
                __out.Write("                get"); //476:1
                __out.AppendLine(false); //476:20
                __out.Write("                {"); //477:1
                __out.AppendLine(false); //477:18
                __out.Write("                    if (_candidateSymbols.IsDefault)"); //478:1
                __out.AppendLine(false); //478:53
                __out.Write("                    {"); //479:1
                __out.AppendLine(false); //479:22
                __out.Write("                        System.Collections.Immutable.ImmutableInterlocked.InterlockedInitialize(ref _candidateSymbols, MakeCandidateSymbols());"); //480:1
                __out.AppendLine(false); //480:144
                __out.Write("                    }"); //481:1
                __out.AppendLine(false); //481:22
                __out.Write("                    return _candidateSymbols;"); //482:1
                __out.AppendLine(false); //482:46
                __out.Write("                }"); //483:1
                __out.AppendLine(false); //483:18
                __out.Write("            }"); //484:1
                __out.AppendLine(false); //484:14
                __out.AppendLine(true); //485:1
                __out.Write("            public DiagnosticInfo? ErrorInfo"); //486:1
                __out.AppendLine(false); //486:45
                __out.Write("            {"); //487:1
                __out.AppendLine(false); //487:14
                __out.Write("                get"); //488:1
                __out.AppendLine(false); //488:20
                __out.Write("                {"); //489:1
                __out.AppendLine(false); //489:18
                __out.Write("                    if (_errorInfo is null)"); //490:1
                __out.AppendLine(false); //490:44
                __out.Write("                    {"); //491:1
                __out.AppendLine(false); //491:22
                __out.Write("                        System.Threading.Interlocked.CompareExchange(ref _errorInfo, MakeErrorInfo(), null);"); //492:1
                __out.AppendLine(false); //492:109
                __out.Write("                    }"); //493:1
                __out.AppendLine(false); //493:22
                __out.Write("                    return _errorInfo;"); //494:1
                __out.AppendLine(false); //494:39
                __out.Write("                }"); //495:1
                __out.AppendLine(false); //495:18
                __out.Write("            }"); //496:1
                __out.AppendLine(false); //496:14
                __out.AppendLine(true); //497:1
                __out.Write("            protected virtual DiagnosticInfo? MakeErrorInfo()"); //498:1
                __out.AppendLine(false); //498:62
                __out.Write("            {"); //499:1
                __out.AppendLine(false); //499:14
                __out.Write("                return ErrorSymbolImplementation.MakeErrorInfo(this);"); //500:1
                __out.AppendLine(false); //500:70
                __out.Write("            }"); //501:1
                __out.AppendLine(false); //501:14
                __out.AppendLine(true); //502:1
                __out.Write("            protected virtual ImmutableArray<Symbol> MakeCandidateSymbols()"); //503:1
                __out.AppendLine(false); //503:76
                __out.Write("            {"); //504:1
                __out.AppendLine(false); //504:14
                __out.Write("                return ErrorSymbolImplementation.MakeCandidateSymbols(this);"); //505:1
                __out.AppendLine(false); //505:77
                __out.Write("            }"); //506:1
                __out.AppendLine(false); //506:14
                __out.AppendLine(true); //507:1
                __out.Write("            protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //508:1
                __out.AppendLine(false); //508:130
                __out.Write("            {"); //509:1
                __out.AppendLine(false); //509:14
                __out.Write("                return _name;"); //510:1
                __out.AppendLine(false); //510:30
                __out.Write("            }"); //511:1
                __out.AppendLine(false); //511:14
                __out.Write("        }"); //512:1
                __out.AppendLine(false); //512:10
            }
            __out.Write("    }"); //514:1
            __out.AppendLine(false); //514:6
            __out.Write("}"); //515:1
            __out.AppendLine(false); //515:2
            return __out.ToStringAndFree();
        }

        public string GenerateSourceSymbol(SymbolGenerationInfo symbol) //518:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //519:1
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
            string __tmp5_line = ".Source"; //519:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //519:40
            }
            __out.Write("{"); //520:1
            __out.AppendLine(false); //520:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Source"; //521:1
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
            if (symbol.ExistingSourceTypeInfo.BaseType == null) //521:43
            {
                string __tmp11_line = " : "; //521:95
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
                string __tmp13_line = ".Completion.Completion"; //521:120
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
                if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //521:156
                {
                    string __tmp16_line = ", MetaDslx.CodeAnalysis.Symbols.Source.ISourceSymbol"; //521:226
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
                __out.AppendLine(false); //521:294
            }
            __out.Write("	{"); //522:1
            __out.AppendLine(false); //522:3
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //523:10
            {
                __out.Write("        private readonly MergedDeclaration _declaration;"); //524:1
                __out.AppendLine(false); //524:57
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetLexicalSortKey")) //525:10
                {
                    __out.Write("        private LexicalSortKey _lazyLexicalSortKey = LexicalSortKey.NotInitialized;"); //526:1
                    __out.AppendLine(false); //526:84
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //528:10
                {
                    __out.AppendLine(true); //529:1
                    bool __tmp20_outputWritten = false;
                    string __tmp21_line = "		public Source"; //530:1
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
                    string __tmp23_line = "(Symbol containingSymbol, MergedDeclaration declaration"; //530:29
                    if (!string.IsNullOrEmpty(__tmp23_line))
                    {
                        __out.Write(__tmp23_line);
                        __tmp20_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //530:85
                    {
                        string __tmp25_line = ", object? modelObject"; //530:142
                        if (!string.IsNullOrEmpty(__tmp25_line))
                        {
                            __out.Write(__tmp25_line);
                            __tmp20_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //530:164
                        {
                            string __tmp27_line = " = null"; //530:221
                            if (!string.IsNullOrEmpty(__tmp27_line))
                            {
                                __out.Write(__tmp27_line);
                                __tmp20_outputWritten = true;
                            }
                        }
                    }
                    string __tmp30_line = ", bool isError = false)"; //530:244
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Write(__tmp30_line);
                        __tmp20_outputWritten = true;
                    }
                    if (__tmp20_outputWritten) __out.AppendLine(true);
                    if (__tmp20_outputWritten)
                    {
                        __out.AppendLine(false); //530:267
                    }
                    __out.Write("            : base(containingSymbol"); //531:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //531:37
                    {
                        __out.Write(", modelObject"); //531:94
                    }
                    __out.Write(", isError)"); //531:115
                    __out.AppendLine(false); //531:125
                    __out.Write("        {"); //532:1
                    __out.AppendLine(false); //532:10
                    __out.Write("            if (declaration is null) throw new ArgumentNullException(nameof(declaration));"); //533:1
                    __out.AppendLine(false); //533:91
                    __out.Write("            _declaration = declaration;"); //534:1
                    __out.AppendLine(false); //534:40
                    __out.Write("		}"); //535:1
                    __out.AppendLine(false); //535:4
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("MergedDeclaration")) //537:10
                {
                    __out.AppendLine(true); //538:1
                    __out.Write("        public MergedDeclaration MergedDeclaration => _declaration;"); //539:1
                    __out.AppendLine(false); //539:68
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("Locations")) //541:10
                {
                    __out.AppendLine(true); //542:1
                    __out.Write("        public override ImmutableArray<Location> Locations => _declaration.NameLocations;"); //543:1
                    __out.AppendLine(false); //543:90
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("DeclaringSyntaxReferences")) //545:10
                {
                    __out.AppendLine(true); //546:1
                    __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration.SyntaxReferences;"); //547:1
                    __out.AppendLine(false); //547:116
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetBinder")) //549:10
                {
                    __out.AppendLine(true); //550:1
                    __out.Write("        public BinderPosition<SymbolBinder> GetBinder(SyntaxReference reference)"); //551:1
                    __out.AppendLine(false); //551:81
                    __out.Write("        {"); //552:1
                    __out.AppendLine(false); //552:10
                    __out.Write("            Debug.Assert(this.DeclaringSyntaxReferences.Contains(reference));"); //553:1
                    __out.AppendLine(false); //553:78
                    __out.Write("            return FindBinders.FindSymbolBinder(this, reference);"); //554:1
                    __out.AppendLine(false); //554:66
                    __out.Write("        }"); //555:1
                    __out.AppendLine(false); //555:10
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetChildSymbol")) //557:10
                {
                    __out.AppendLine(true); //558:1
                    __out.Write("        public Symbol GetChildSymbol(SyntaxReference syntax)"); //559:1
                    __out.AppendLine(false); //559:61
                    __out.Write("        {"); //560:1
                    __out.AppendLine(false); //560:10
                    __out.Write("            foreach (var child in this.ChildSymbols)"); //561:1
                    __out.AppendLine(false); //561:53
                    __out.Write("            {"); //562:1
                    __out.AppendLine(false); //562:14
                    __out.Write("                if (child.DeclaringSyntaxReferences.Any(sr => sr.GetLocation() == syntax.GetLocation()))"); //563:1
                    __out.AppendLine(false); //563:105
                    __out.Write("                {"); //564:1
                    __out.AppendLine(false); //564:18
                    __out.Write("                    return child;"); //565:1
                    __out.AppendLine(false); //565:34
                    __out.Write("                }"); //566:1
                    __out.AppendLine(false); //566:18
                    __out.Write("            }"); //567:1
                    __out.AppendLine(false); //567:14
                    __out.Write("            return null;"); //568:1
                    __out.AppendLine(false); //568:25
                    __out.Write("        }"); //569:1
                    __out.AppendLine(false); //569:10
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetLexicalSortKey")) //571:10
                {
                    __out.Write("        public override LexicalSortKey GetLexicalSortKey()"); //572:1
                    __out.AppendLine(false); //572:59
                    __out.Write("        {"); //573:1
                    __out.AppendLine(false); //573:10
                    __out.Write("            if (!_lazyLexicalSortKey.IsInitialized)"); //574:1
                    __out.AppendLine(false); //574:52
                    __out.Write("            {"); //575:1
                    __out.AppendLine(false); //575:14
                    __out.Write("                _lazyLexicalSortKey.SetFrom(this.MergedDeclaration.GetLexicalSortKey(this.DeclaringCompilation));"); //576:1
                    __out.AppendLine(false); //576:114
                    __out.Write("            }"); //577:1
                    __out.AppendLine(false); //577:14
                    __out.Write("            return _lazyLexicalSortKey;"); //578:1
                    __out.AppendLine(false); //578:40
                    __out.Write("        }"); //579:1
                    __out.AppendLine(false); //579:10
                }
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteInitializingSymbol")) //582:10
            {
                __out.AppendLine(true); //583:1
                __out.Write("        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //584:1
                __out.AppendLine(false); //584:123
                __out.Write("        {"); //585:1
                __out.AppendLine(false); //585:10
                __out.Write("        }"); //586:1
                __out.AppendLine(false); //586:10
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteCreatingChildSymbols")) //588:10
            {
                __out.AppendLine(true); //589:1
                __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //590:1
                __out.AppendLine(false); //590:143
                __out.Write("        {"); //591:1
                __out.AppendLine(false); //591:10
                __out.Write("            return SourceSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //592:1
                __out.AppendLine(false); //592:124
                __out.Write("        }"); //593:1
                __out.AppendLine(false); //593:10
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteImports")) //595:10
            {
                __out.AppendLine(true); //596:1
                __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //597:1
                __out.AppendLine(false); //597:140
                __out.Write("        {"); //598:1
                __out.AppendLine(false); //598:10
                __out.Write("            SourceSymbolImplementation.CompleteImports(this, locationOpt, diagnostics, cancellationToken);"); //599:1
                __out.AppendLine(false); //599:107
                __out.Write("        }"); //600:1
                __out.AppendLine(false); //600:10
                __out.AppendLine(true); //601:1
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteSymbolProperty_Name")) //603:10
            {
                __out.Write("        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //604:1
                __out.AppendLine(false); //604:126
                __out.Write("        {"); //605:1
                __out.AppendLine(false); //605:10
                __out.Write("            return SourceSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //606:1
                __out.AppendLine(false); //606:133
                __out.Write("        }"); //607:1
                __out.AppendLine(false); //607:10
            }
            __out.AppendLine(true); //609:1
            var __loop10_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //610:16
                where part.GenerateCompleteMethod //610:44
                select new { part = part}
                ).ToList(); //610:10
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                var __tmp31 = __loop10_results[__loop10_iteration];
                var part = __tmp31.part;
                if (!symbol.ExistingSourceTypeInfo.Members.Contains(part.CompleteMethodName)) //611:14
                {
                    bool __tmp33_outputWritten = false;
                    string __tmp34_line = "        protected override "; //612:1
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
                    string __tmp36_line = " "; //612:59
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
                    string __tmp38_line = "("; //612:85
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
                    string __tmp40_line = ")"; //612:116
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Write(__tmp40_line);
                        __tmp33_outputWritten = true;
                    }
                    if (__tmp33_outputWritten) __out.AppendLine(true);
                    if (__tmp33_outputWritten)
                    {
                        __out.AppendLine(false); //612:117
                    }
                    __out.Write("        {"); //613:1
                    __out.AppendLine(false); //613:10
                    if (part is SymbolPropertyGenerationInfo) //614:14
                    {
                        var prop = (SymbolPropertyGenerationInfo)part; //615:18
                        if (prop.IsCollection) //616:18
                        {
                            bool __tmp42_outputWritten = false;
                            string __tmp43_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValues<"; //617:1
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
                            string __tmp45_line = ">(this, nameof("; //617:89
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
                            string __tmp47_line = "), diagnostics, cancellationToken);"; //617:115
                            if (!string.IsNullOrEmpty(__tmp47_line))
                            {
                                __out.Write(__tmp47_line);
                                __tmp42_outputWritten = true;
                            }
                            if (__tmp42_outputWritten) __out.AppendLine(true);
                            if (__tmp42_outputWritten)
                            {
                                __out.AppendLine(false); //617:150
                            }
                        }
                        else //618:18
                        {
                            bool __tmp49_outputWritten = false;
                            string __tmp50_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValue<"; //619:1
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
                            string __tmp52_line = ">(this, nameof("; //619:84
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
                            string __tmp54_line = "), diagnostics, cancellationToken);"; //619:110
                            if (!string.IsNullOrEmpty(__tmp54_line))
                            {
                                __out.Write(__tmp54_line);
                                __tmp49_outputWritten = true;
                            }
                            if (__tmp49_outputWritten) __out.AppendLine(true);
                            if (__tmp49_outputWritten)
                            {
                                __out.AppendLine(false); //619:145
                            }
                        }
                    }
                    __out.Write("        }"); //622:1
                    __out.AppendLine(false); //622:10
                }
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteNonSymbolProperties")) //625:10
            {
                __out.AppendLine(true); //626:1
                __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //627:1
                __out.AppendLine(false); //627:152
                __out.Write("        {"); //628:1
                __out.AppendLine(false); //628:10
                __out.Write("            SourceSymbolImplementation.AssignNonSymbolProperties(this, diagnostics, cancellationToken);"); //629:1
                __out.AppendLine(false); //629:104
                __out.Write("        }"); //630:1
                __out.AppendLine(false); //630:10
            }
            __out.AppendLine(true); //632:1
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //633:10
            {
                bool __tmp56_outputWritten = false;
                string __tmp57_line = "        public partial class Error : Source"; //634:1
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
                string __tmp59_line = ", MetaDslx.CodeAnalysis.Symbols.IErrorSymbol"; //634:57
                if (!string.IsNullOrEmpty(__tmp59_line))
                {
                    __out.Write(__tmp59_line);
                    __tmp56_outputWritten = true;
                }
                if (__tmp56_outputWritten) __out.AppendLine(true);
                if (__tmp56_outputWritten)
                {
                    __out.AppendLine(false); //634:101
                }
                __out.Write("        {"); //635:1
                __out.AppendLine(false); //635:10
                __out.Write("            private readonly string _name;"); //636:1
                __out.AppendLine(false); //636:43
                __out.Write("            private readonly string _metadataName;"); //637:1
                __out.AppendLine(false); //637:51
                __out.Write("            private DiagnosticInfo _errorInfo;"); //638:1
                __out.AppendLine(false); //638:47
                __out.Write("            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorKind _kind;"); //639:1
                __out.AppendLine(false); //639:76
                __out.Write("            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags _flags;"); //640:1
                __out.AppendLine(false); //640:84
                __out.Write("            private ImmutableArray<Symbol> _candidateSymbols;"); //641:1
                __out.AppendLine(false); //641:62
                __out.AppendLine(true); //642:1
                if (!symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //643:14
                {
                    __out.Write("            private Error(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags"); //644:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //644:243
                    {
                        __out.Write(", object? modelObject"); //644:300
                    }
                    __out.Write(")"); //644:329
                    __out.AppendLine(false); //644:330
                    __out.Write("                : base(container, declaration"); //645:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //645:47
                    {
                        __out.Write(", modelObject"); //645:104
                    }
                    __out.Write(", true)"); //645:125
                    __out.AppendLine(false); //645:132
                    __out.Write("            {"); //646:1
                    __out.AppendLine(false); //646:14
                    __out.Write("                Debug.Assert(!flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported) || errorInfo != null);"); //647:1
                    __out.AppendLine(false); //647:126
                    __out.Write("                _name = declaration.Name;"); //648:1
                    __out.AppendLine(false); //648:42
                    __out.Write("                _metadataName = declaration.MetadataName;"); //649:1
                    __out.AppendLine(false); //649:58
                    __out.Write("                _kind = kind;"); //650:1
                    __out.AppendLine(false); //650:30
                    __out.Write("                _errorInfo = errorInfo;"); //651:1
                    __out.AppendLine(false); //651:40
                    __out.Write("                _candidateSymbols = candidateSymbols;"); //652:1
                    __out.AppendLine(false); //652:54
                    __out.Write("                _flags = flags;"); //653:1
                    __out.AppendLine(false); //653:32
                    __out.Write("            }"); //654:1
                    __out.AppendLine(false); //654:14
                    __out.Write("            public Error(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported"); //656:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //656:205
                    {
                        __out.Write(", object? modelObject"); //656:262
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //656:284
                        {
                            __out.Write(" = null"); //656:341
                        }
                    }
                    __out.Write(")"); //656:364
                    __out.AppendLine(false); //656:365
                    __out.Write("                : this(container, declaration, kind, errorInfo, candidateSymbols, unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.None"); //657:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //657:208
                    {
                        __out.Write(", modelObject"); //657:265
                    }
                    __out.Write(")"); //657:286
                    __out.AppendLine(false); //657:287
                    __out.Write("            {"); //658:1
                    __out.AppendLine(false); //658:14
                    __out.Write("            }"); //659:1
                    __out.AppendLine(false); //659:14
                    __out.Write("            public Error(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported"); //661:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //661:137
                    {
                        __out.Write(", object? modelObject"); //661:194
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //661:216
                        {
                            __out.Write(" = null"); //661:273
                        }
                    }
                    __out.Write(")"); //661:296
                    __out.AppendLine(false); //661:297
                    __out.Write("                : this(wrappedSymbol.ContainingSymbol, (wrappedSymbol as ISourceSymbol).MergedDeclaration, kind, errorInfo, ImmutableArray.Create<Symbol>(wrappedSymbol), unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.UnreportedWrapped : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Wrapped"); //662:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //662:306
                    {
                        __out.Write(", modelObject is not null ? modelObject :  (wrappedSymbol as IModelSymbol)?.ModelObject"); //662:363
                    }
                    __out.Write(")"); //662:458
                    __out.AppendLine(false); //662:459
                    __out.Write("            {"); //663:1
                    __out.AppendLine(false); //663:14
                    __out.Write("            }"); //664:1
                    __out.AppendLine(false); //664:14
                    __out.AppendLine(true); //665:1
                    __out.Write("            protected virtual Error Update(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags"); //666:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //666:260
                    {
                        __out.Write(", object? modelObject"); //666:317
                    }
                    __out.Write(")"); //666:346
                    __out.AppendLine(false); //666:347
                    __out.Write("            {"); //667:1
                    __out.AppendLine(false); //667:14
                    __out.Write("                return new Error(container, declaration, kind, errorInfo, candidateSymbols, flags"); //668:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //668:99
                    {
                        __out.Write(", modelObject"); //668:156
                    }
                    __out.Write(");"); //668:177
                    __out.AppendLine(false); //668:179
                    __out.Write("            }"); //669:1
                    __out.AppendLine(false); //669:14
                }
                __out.AppendLine(true); //671:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsReported(DiagnosticInfo? errorInfo = null)"); //672:1
                __out.AppendLine(false); //672:101
                __out.Write("            {"); //673:1
                __out.AppendLine(false); //673:14
                __out.Write("                return this.IsUnreported ? this :"); //674:1
                __out.AppendLine(false); //674:50
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, _kind, errorInfo is null ? ErrorInfo : errorInfo, CandidateSymbols, _flags & ~MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported"); //675:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //675:211
                {
                    __out.Write(", this.ModelObject"); //675:268
                }
                __out.Write(");"); //675:294
                __out.AppendLine(false); //675:296
                __out.Write("            }"); //676:1
                __out.AppendLine(false); //676:14
                __out.AppendLine(true); //677:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsUnreported(DiagnosticInfo? errorInfo = null)"); //678:1
                __out.AppendLine(false); //678:103
                __out.Write("            {"); //679:1
                __out.AppendLine(false); //679:14
                __out.Write("                return this.IsUnreported ? this :"); //680:1
                __out.AppendLine(false); //680:50
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, _kind, errorInfo is null ? ErrorInfo : errorInfo, CandidateSymbols, _flags | MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported"); //681:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //681:210
                {
                    __out.Write(", this.ModelObject"); //681:267
                }
                __out.Write(");"); //681:293
                __out.AppendLine(false); //681:295
                __out.Write("            }"); //682:1
                __out.AppendLine(false); //682:14
                __out.AppendLine(true); //683:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind)"); //684:1
                __out.AppendLine(false); //684:109
                __out.Write("            {"); //685:1
                __out.AppendLine(false); //685:14
                __out.Write("                return _kind == kind ? this :"); //686:1
                __out.AppendLine(false); //686:46
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, kind, ErrorInfo, CandidateSymbols, _flags"); //687:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //687:117
                {
                    __out.Write(", this.ModelObject"); //687:174
                }
                __out.Write(");"); //687:200
                __out.AppendLine(false); //687:202
                __out.Write("            }"); //688:1
                __out.AppendLine(false); //688:14
                __out.AppendLine(true); //689:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, ImmutableArray<MetaDslx.CodeAnalysis.Symbols.Symbol> candidateSymbols)"); //690:1
                __out.AppendLine(false); //690:180
                __out.Write("            {"); //691:1
                __out.AppendLine(false); //691:14
                __out.Write("                return _kind == kind && CandidateSymbols == candidateSymbols ? this :"); //692:1
                __out.AppendLine(false); //692:86
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, kind, ErrorInfo, candidateSymbols, _flags"); //693:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //693:117
                {
                    __out.Write(", this.ModelObject"); //693:174
                }
                __out.Write(");"); //693:200
                __out.AppendLine(false); //693:202
                __out.Write("            }"); //694:1
                __out.AppendLine(false); //694:14
                __out.AppendLine(true); //695:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo errorInfo, ImmutableArray<MetaDslx.CodeAnalysis.Symbols.Symbol> candidateSymbols)"); //696:1
                __out.AppendLine(false); //696:206
                __out.Write("            {"); //697:1
                __out.AppendLine(false); //697:14
                __out.Write("                return _kind == kind && ErrorInfo == errorInfo && CandidateSymbols == candidateSymbols ? this :"); //698:1
                __out.AppendLine(false); //698:112
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, kind, errorInfo, candidateSymbols, _flags"); //699:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //699:117
                {
                    __out.Write(", this.ModelObject"); //699:174
                }
                __out.Write(");"); //699:200
                __out.AppendLine(false); //699:202
                __out.Write("            }"); //700:1
                __out.AppendLine(false); //700:14
                __out.AppendLine(true); //701:1
                __out.Write("            public override string Name => _name;"); //702:1
                __out.AppendLine(false); //702:50
                __out.AppendLine(true); //703:1
                __out.Write("            public override string MetadataName => _metadataName;"); //704:1
                __out.AppendLine(false); //704:66
                __out.AppendLine(true); //705:1
                __out.Write("            public sealed override bool IsError => true;"); //706:1
                __out.AppendLine(false); //706:57
                __out.AppendLine(true); //707:1
                __out.Write("            public bool IsUnreported => _flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported);"); //708:1
                __out.AppendLine(false); //708:115
                __out.AppendLine(true); //709:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.ErrorKind ErrorKind => _kind;"); //710:1
                __out.AppendLine(false); //710:79
                __out.AppendLine(true); //711:1
                __out.Write("            public ImmutableArray<Symbol> CandidateSymbols"); //712:1
                __out.AppendLine(false); //712:59
                __out.Write("            {"); //713:1
                __out.AppendLine(false); //713:14
                __out.Write("                get"); //714:1
                __out.AppendLine(false); //714:20
                __out.Write("                {"); //715:1
                __out.AppendLine(false); //715:18
                __out.Write("                    if (_candidateSymbols.IsDefault)"); //716:1
                __out.AppendLine(false); //716:53
                __out.Write("                    {"); //717:1
                __out.AppendLine(false); //717:22
                __out.Write("                        System.Collections.Immutable.ImmutableInterlocked.InterlockedInitialize(ref _candidateSymbols, MakeCandidateSymbols());"); //718:1
                __out.AppendLine(false); //718:144
                __out.Write("                    }"); //719:1
                __out.AppendLine(false); //719:22
                __out.Write("                    return _candidateSymbols;"); //720:1
                __out.AppendLine(false); //720:46
                __out.Write("                }"); //721:1
                __out.AppendLine(false); //721:18
                __out.Write("            }"); //722:1
                __out.AppendLine(false); //722:14
                __out.AppendLine(true); //723:1
                __out.Write("            public DiagnosticInfo? ErrorInfo"); //724:1
                __out.AppendLine(false); //724:45
                __out.Write("            {"); //725:1
                __out.AppendLine(false); //725:14
                __out.Write("                get"); //726:1
                __out.AppendLine(false); //726:20
                __out.Write("                {"); //727:1
                __out.AppendLine(false); //727:18
                __out.Write("                    if (_errorInfo is null)"); //728:1
                __out.AppendLine(false); //728:44
                __out.Write("                    {"); //729:1
                __out.AppendLine(false); //729:22
                __out.Write("                        System.Threading.Interlocked.CompareExchange(ref _errorInfo, MakeErrorInfo(), null);"); //730:1
                __out.AppendLine(false); //730:109
                __out.Write("                    }"); //731:1
                __out.AppendLine(false); //731:22
                __out.Write("                    return _errorInfo;"); //732:1
                __out.AppendLine(false); //732:39
                __out.Write("                }"); //733:1
                __out.AppendLine(false); //733:18
                __out.Write("            }"); //734:1
                __out.AppendLine(false); //734:14
                __out.AppendLine(true); //735:1
                __out.Write("            public DiagnosticInfo? UseSiteDiagnosticInfo => IsUnreported ? ErrorInfo : null;"); //736:1
                __out.AppendLine(false); //736:93
                __out.AppendLine(true); //737:1
                __out.Write("            protected virtual DiagnosticInfo? MakeErrorInfo()"); //738:1
                __out.AppendLine(false); //738:62
                __out.Write("            {"); //739:1
                __out.AppendLine(false); //739:14
                __out.Write("                return null;"); //740:1
                __out.AppendLine(false); //740:29
                __out.Write("            }"); //741:1
                __out.AppendLine(false); //741:14
                __out.AppendLine(true); //742:1
                __out.Write("            protected virtual ImmutableArray<Symbol> MakeCandidateSymbols()"); //743:1
                __out.AppendLine(false); //743:76
                __out.Write("            {"); //744:1
                __out.AppendLine(false); //744:14
                __out.Write("                return ImmutableArray<Symbol>.Empty;"); //745:1
                __out.AppendLine(false); //745:53
                __out.Write("            }"); //746:1
                __out.AppendLine(false); //746:14
                __out.AppendLine(true); //747:1
                __out.Write("            protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //748:1
                __out.AppendLine(false); //748:130
                __out.Write("            {"); //749:1
                __out.AppendLine(false); //749:14
                __out.Write("                return _name;"); //750:1
                __out.AppendLine(false); //750:30
                __out.Write("            }"); //751:1
                __out.AppendLine(false); //751:14
                __out.Write("        }"); //752:1
                __out.AppendLine(false); //752:10
            }
            __out.Write("	}"); //754:1
            __out.AppendLine(false); //754:3
            __out.Write("}"); //755:1
            __out.AppendLine(false); //755:2
            return __out.ToStringAndFree();
        }

        public string GenerateWrappedSymbol(SymbolGenerationInfo symbol) //758:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //759:1
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
            string __tmp5_line = ".Wrapped"; //759:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //759:41
            }
            __out.Write("{"); //760:1
            __out.AppendLine(false); //760:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Wrapped"; //761:1
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
            string __tmp10_line = " : "; //761:43
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
            string __tmp12_line = ".Completion.Completion"; //761:68
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
                __out.AppendLine(false); //761:103
            }
            __out.Write("	{"); //762:1
            __out.AppendLine(false); //762:3
            bool __tmp15_outputWritten = false;
            string __tmp16_line = "        private readonly "; //763:1
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
            string __tmp18_line = "."; //763:48
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
            string __tmp20_line = " _wrappedSymbol;"; //763:62
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Write(__tmp20_line);
                __tmp15_outputWritten = true;
            }
            if (__tmp15_outputWritten) __out.AppendLine(true);
            if (__tmp15_outputWritten)
            {
                __out.AppendLine(false); //763:78
            }
            bool __tmp22_outputWritten = false;
            string __tmp23_line = "        public Wrapped"; //765:1
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
            string __tmp25_line = "("; //765:36
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
            string __tmp27_line = "."; //765:59
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
            string __tmp29_line = " wrappedSymbol)"; //765:73
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Write(__tmp29_line);
                __tmp22_outputWritten = true;
            }
            if (__tmp22_outputWritten) __out.AppendLine(true);
            if (__tmp22_outputWritten)
            {
                __out.AppendLine(false); //765:88
            }
            __out.Write("            : base(wrappedSymbol.ContainingSymbol"); //766:1
            if (symbol.ModelObjectOption != ParameterOption.Disabled) //766:51
            {
                __out.Write(", ((IModelSymbol)wrappedSymbol).ModelObject"); //766:108
            }
            __out.Write(", wrappedSymbol.IsError)"); //766:159
            __out.AppendLine(false); //766:183
            __out.Write("        {"); //767:1
            __out.AppendLine(false); //767:10
            __out.Write("            _wrappedSymbol = wrappedSymbol;"); //768:1
            __out.AppendLine(false); //768:44
            __out.Write("        }"); //769:1
            __out.AppendLine(false); //769:10
            __out.AppendLine(true); //770:1
            __out.Write("        public override ImmutableArray<Location> Locations => _wrappedSymbol.Locations;"); //771:1
            __out.AppendLine(false); //771:88
            __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _wrappedSymbol.DeclaringSyntaxReferences;"); //772:1
            __out.AppendLine(false); //772:127
            __out.AppendLine(true); //773:1
            __out.Write("        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //774:1
            __out.AppendLine(false); //774:126
            __out.Write("        {"); //775:1
            __out.AppendLine(false); //775:10
            __out.Write("            return _wrappedSymbol.Name;"); //776:1
            __out.AppendLine(false); //776:40
            __out.Write("        }"); //777:1
            __out.AppendLine(false); //777:10
            __out.AppendLine(true); //778:1
            __out.Write("        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //779:1
            __out.AppendLine(false); //779:123
            __out.Write("        {"); //780:1
            __out.AppendLine(false); //780:10
            __out.Write("            _wrappedSymbol.CompleteInitializingSymbol(diagnostics, cancellationToken);"); //781:1
            __out.AppendLine(false); //781:87
            __out.Write("        }"); //782:1
            __out.AppendLine(false); //782:10
            __out.AppendLine(true); //783:1
            __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //784:1
            __out.AppendLine(false); //784:143
            __out.Write("        {"); //785:1
            __out.AppendLine(false); //785:10
            __out.Write("            return _wrappedSymbol.CompleteCreatingChildSymbols(diagnostics, cancellationToken);"); //786:1
            __out.AppendLine(false); //786:96
            __out.Write("        }"); //787:1
            __out.AppendLine(false); //787:10
            __out.AppendLine(true); //788:1
            __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //789:1
            __out.AppendLine(false); //789:140
            __out.Write("        {"); //790:1
            __out.AppendLine(false); //790:10
            __out.Write("            _wrappedSymbol.CompleteImports(locationOpt, diagnostics, cancellationToken);"); //791:1
            __out.AppendLine(false); //791:89
            __out.Write("        }"); //792:1
            __out.AppendLine(false); //792:10
            var __loop11_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //793:16
                where part.GenerateCompleteMethod //793:44
                select new { part = part}
                ).ToList(); //793:10
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp30 = __loop11_results[__loop11_iteration];
                var part = __tmp30.part;
                __out.AppendLine(true); //794:1
                bool __tmp32_outputWritten = false;
                string __tmp33_line = "        protected override "; //795:1
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
                string __tmp35_line = " "; //795:59
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
                string __tmp37_line = "("; //795:85
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
                string __tmp39_line = ")"; //795:116
                if (!string.IsNullOrEmpty(__tmp39_line))
                {
                    __out.Write(__tmp39_line);
                    __tmp32_outputWritten = true;
                }
                if (__tmp32_outputWritten) __out.AppendLine(true);
                if (__tmp32_outputWritten)
                {
                    __out.AppendLine(false); //795:117
                }
                __out.Write("        {"); //796:1
                __out.AppendLine(false); //796:10
                bool __tmp41_outputWritten = false;
                string __tmp40Prefix = "            "; //797:1
                if (part.CompleteMethodReturnType != "void") //797:14
                {
                    if (!string.IsNullOrEmpty(__tmp40Prefix))
                    {
                        __out.Write(__tmp40Prefix);
                        __tmp41_outputWritten = true;
                    }
                    string __tmp43_line = "return "; //797:59
                    if (!string.IsNullOrEmpty(__tmp43_line))
                    {
                        __out.Write(__tmp43_line);
                        __tmp41_outputWritten = true;
                    }
                }
                string __tmp45_line = "_wrappedSymbol."; //797:74
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
                string __tmp47_line = "("; //797:114
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
                string __tmp49_line = ");"; //797:143
                if (!string.IsNullOrEmpty(__tmp49_line))
                {
                    __out.Write(__tmp49_line);
                    __tmp41_outputWritten = true;
                }
                if (__tmp41_outputWritten) __out.AppendLine(true);
                if (__tmp41_outputWritten)
                {
                    __out.AppendLine(false); //797:145
                }
                __out.Write("        }"); //798:1
                __out.AppendLine(false); //798:10
            }
            __out.AppendLine(true); //800:1
            __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //801:1
            __out.AppendLine(false); //801:152
            __out.Write("        {"); //802:1
            __out.AppendLine(false); //802:10
            __out.Write("            _wrappedSymbol.CompleteNonSymbolProperties(locationOpt, diagnostics, cancellationToken);"); //803:1
            __out.AppendLine(false); //803:101
            __out.Write("        }"); //804:1
            __out.AppendLine(false); //804:10
            __out.Write("    }"); //805:1
            __out.AppendLine(false); //805:6
            __out.Write("}"); //806:1
            __out.AppendLine(false); //806:2
            return __out.ToStringAndFree();
        }

        public string GenerateVisitor(string namespaceName, IEnumerable<SymbolGenerationInfo> symbols) //809:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //810:1
            __out.AppendLine(false); //810:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //811:1
            __out.AppendLine(false); //811:29
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //812:1
            __out.AppendLine(false); //812:37
            __out.Write("using System;"); //813:1
            __out.AppendLine(false); //813:14
            __out.Write("using System.Collections.Generic;"); //814:1
            __out.AppendLine(false); //814:34
            __out.Write("using System.Collections.Immutable;"); //815:1
            __out.AppendLine(false); //815:36
            __out.Write("using System.Diagnostics;"); //816:1
            __out.AppendLine(false); //816:26
            __out.Write("using System.Text;"); //817:1
            __out.AppendLine(false); //817:19
            __out.Write("using System.Threading;"); //818:1
            __out.AppendLine(false); //818:24
            __out.AppendLine(true); //819:1
            __out.Write("#nullable enable"); //820:1
            __out.AppendLine(false); //820:17
            __out.AppendLine(true); //821:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //822:1
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
                __out.AppendLine(false); //822:26
            }
            __out.Write("{"); //823:1
            __out.AppendLine(false); //823:2
            __out.Write("	public interface ISymbolVisitor"); //824:1
            __out.AppendLine(false); //824:33
            __out.Write("	{"); //825:1
            __out.AppendLine(false); //825:3
            var __loop12_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //826:16
                select new { symbol = symbol}
                ).ToList(); //826:10
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp5 = __loop12_results[__loop12_iteration];
                var symbol = __tmp5.symbol;
                bool __tmp7_outputWritten = false;
                string __tmp8_line = "        void Visit("; //827:1
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
                string __tmp10_line = " symbol);"; //827:33
                if (!string.IsNullOrEmpty(__tmp10_line))
                {
                    __out.Write(__tmp10_line);
                    __tmp7_outputWritten = true;
                }
                if (__tmp7_outputWritten) __out.AppendLine(true);
                if (__tmp7_outputWritten)
                {
                    __out.AppendLine(false); //827:42
                }
            }
            __out.Write("	}"); //829:1
            __out.AppendLine(false); //829:3
            __out.AppendLine(true); //830:1
            __out.Write("	public interface ISymbolVisitor<TResult>"); //831:1
            __out.AppendLine(false); //831:42
            __out.Write("	{"); //832:1
            __out.AppendLine(false); //832:3
            var __loop13_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //833:16
                select new { symbol = symbol}
                ).ToList(); //833:10
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp11 = __loop13_results[__loop13_iteration];
                var symbol = __tmp11.symbol;
                bool __tmp13_outputWritten = false;
                string __tmp14_line = "        TResult Visit("; //834:1
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
                string __tmp16_line = " symbol);"; //834:36
                if (!string.IsNullOrEmpty(__tmp16_line))
                {
                    __out.Write(__tmp16_line);
                    __tmp13_outputWritten = true;
                }
                if (__tmp13_outputWritten) __out.AppendLine(true);
                if (__tmp13_outputWritten)
                {
                    __out.AppendLine(false); //834:45
                }
            }
            __out.Write("	}"); //836:1
            __out.AppendLine(false); //836:3
            __out.AppendLine(true); //837:1
            __out.Write("	public interface ISymbolVisitor<TArgument, TResult>"); //838:1
            __out.AppendLine(false); //838:53
            __out.Write("	{"); //839:1
            __out.AppendLine(false); //839:3
            var __loop14_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //840:16
                select new { symbol = symbol}
                ).ToList(); //840:10
            for (int __loop14_iteration = 0; __loop14_iteration < __loop14_results.Count; ++__loop14_iteration)
            {
                var __tmp17 = __loop14_results[__loop14_iteration];
                var symbol = __tmp17.symbol;
                bool __tmp19_outputWritten = false;
                string __tmp20_line = "        TResult Visit("; //841:1
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
                string __tmp22_line = " symbol, TArgument argument);"; //841:36
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Write(__tmp22_line);
                    __tmp19_outputWritten = true;
                }
                if (__tmp19_outputWritten) __out.AppendLine(true);
                if (__tmp19_outputWritten)
                {
                    __out.AppendLine(false); //841:65
                }
            }
            __out.Write("	}"); //843:1
            __out.AppendLine(false); //843:3
            __out.Write("}"); //844:1
            __out.AppendLine(false); //844:2
            return __out.ToStringAndFree();
        }

        public string GenerateFactory(string namespaceName, IEnumerable<SymbolGenerationInfo> symbols) //847:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //848:1
            __out.AppendLine(false); //848:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //849:1
            __out.AppendLine(false); //849:29
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //850:1
            __out.AppendLine(false); //850:37
            __out.Write("using System;"); //851:1
            __out.AppendLine(false); //851:14
            __out.Write("using System.Collections.Generic;"); //852:1
            __out.AppendLine(false); //852:34
            __out.Write("using System.Collections.Immutable;"); //853:1
            __out.AppendLine(false); //853:36
            __out.Write("using System.Diagnostics;"); //854:1
            __out.AppendLine(false); //854:26
            __out.Write("using System.Text;"); //855:1
            __out.AppendLine(false); //855:19
            __out.Write("using System.Threading;"); //856:1
            __out.AppendLine(false); //856:24
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //857:1
            __out.AppendLine(false); //857:42
            __out.AppendLine(true); //858:1
            __out.Write("#nullable enable"); //859:1
            __out.AppendLine(false); //859:17
            __out.AppendLine(true); //860:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //861:1
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
            string __tmp5_line = ".Factory"; //861:26
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //861:34
            }
            __out.Write("{"); //862:1
            __out.AppendLine(false); //862:2
            var __loop15_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //863:12
                where symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol" && symbol.SymbolParts != SymbolParts.None //863:28
                select new { symbol = symbol}
                ).ToList(); //863:6
            for (int __loop15_iteration = 0; __loop15_iteration < __loop15_results.Count; ++__loop15_iteration)
            {
                var __tmp6 = __loop15_results[__loop15_iteration];
                var symbol = __tmp6.symbol;
                bool __tmp8_outputWritten = false;
                string __tmp9_line = "	public class "; //864:1
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
                string __tmp11_line = "Factory : IGeneratedSymbolFactory"; //864:28
                if (!string.IsNullOrEmpty(__tmp11_line))
                {
                    __out.Write(__tmp11_line);
                    __tmp8_outputWritten = true;
                }
                if (__tmp8_outputWritten) __out.AppendLine(true);
                if (__tmp8_outputWritten)
                {
                    __out.AppendLine(false); //864:61
                }
                __out.Write("	{"); //865:1
                __out.AppendLine(false); //865:3
                __out.Write("        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)"); //866:1
                __out.AppendLine(false); //866:83
                __out.Write("        {"); //867:1
                __out.AppendLine(false); //867:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Metadata)) //868:14
                {
                    bool __tmp13_outputWritten = false;
                    string __tmp14_line = "            throw new NotImplementedException(\"There is no Metadata"; //869:1
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
                    string __tmp16_line = " implemented.\");"; //869:81
                    if (!string.IsNullOrEmpty(__tmp16_line))
                    {
                        __out.Write(__tmp16_line);
                        __tmp13_outputWritten = true;
                    }
                    if (__tmp13_outputWritten) __out.AppendLine(true);
                    if (__tmp13_outputWritten)
                    {
                        __out.AppendLine(false); //869:97
                    }
                }
                else if (symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //870:14
                {
                    bool __tmp18_outputWritten = false;
                    string __tmp19_line = "            throw new NotImplementedException(\"CreateMetadataSymbol for Metadata"; //871:1
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
                    string __tmp21_line = " should be implemented in a custom SymbolFactory.\");"; //871:94
                    if (!string.IsNullOrEmpty(__tmp21_line))
                    {
                        __out.Write(__tmp21_line);
                        __tmp18_outputWritten = true;
                    }
                    if (__tmp18_outputWritten) __out.AppendLine(true);
                    if (__tmp18_outputWritten)
                    {
                        __out.AppendLine(false); //871:146
                    }
                }
                else //872:14
                {
                    bool __tmp23_outputWritten = false;
                    string __tmp24_line = "            return new Metadata.Metadata"; //873:1
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
                    string __tmp26_line = "(container"; //873:54
                    if (!string.IsNullOrEmpty(__tmp26_line))
                    {
                        __out.Write(__tmp26_line);
                        __tmp23_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //873:65
                    {
                        string __tmp28_line = ", modelObject"; //873:122
                        if (!string.IsNullOrEmpty(__tmp28_line))
                        {
                            __out.Write(__tmp28_line);
                            __tmp23_outputWritten = true;
                        }
                    }
                    string __tmp30_line = ");"; //873:143
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Write(__tmp30_line);
                        __tmp23_outputWritten = true;
                    }
                    if (__tmp23_outputWritten) __out.AppendLine(true);
                    if (__tmp23_outputWritten)
                    {
                        __out.AppendLine(false); //873:145
                    }
                }
                __out.Write("        }"); //875:1
                __out.AppendLine(false); //875:10
                __out.AppendLine(true); //876:1
                __out.Write("        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)"); //877:1
                __out.AppendLine(false); //877:253
                __out.Write("        {"); //878:1
                __out.AppendLine(false); //878:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Metadata)) //879:14
                {
                    bool __tmp32_outputWritten = false;
                    string __tmp33_line = "            throw new NotImplementedException(\"There is no Metadata"; //880:1
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
                    string __tmp35_line = " implemented.\");"; //880:81
                    if (!string.IsNullOrEmpty(__tmp35_line))
                    {
                        __out.Write(__tmp35_line);
                        __tmp32_outputWritten = true;
                    }
                    if (__tmp32_outputWritten) __out.AppendLine(true);
                    if (__tmp32_outputWritten)
                    {
                        __out.AppendLine(false); //880:97
                    }
                }
                else if (symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //881:14
                {
                    bool __tmp37_outputWritten = false;
                    string __tmp38_line = "            throw new NotImplementedException(\"CreateMetadataSymbol for Metadata"; //882:1
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
                    string __tmp40_line = " should be implemented in a custom SymbolFactory.\");"; //882:94
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Write(__tmp40_line);
                        __tmp37_outputWritten = true;
                    }
                    if (__tmp37_outputWritten) __out.AppendLine(true);
                    if (__tmp37_outputWritten)
                    {
                        __out.AppendLine(false); //882:146
                    }
                }
                else //883:14
                {
                    bool __tmp42_outputWritten = false;
                    string __tmp43_line = "            return new Metadata.Metadata"; //884:1
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
                    string __tmp45_line = ".Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported"; //884:54
                    if (!string.IsNullOrEmpty(__tmp45_line))
                    {
                        __out.Write(__tmp45_line);
                        __tmp42_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //884:138
                    {
                        string __tmp47_line = ", modelObject"; //884:195
                        if (!string.IsNullOrEmpty(__tmp47_line))
                        {
                            __out.Write(__tmp47_line);
                            __tmp42_outputWritten = true;
                        }
                    }
                    string __tmp49_line = ");"; //884:216
                    if (!string.IsNullOrEmpty(__tmp49_line))
                    {
                        __out.Write(__tmp49_line);
                        __tmp42_outputWritten = true;
                    }
                    if (__tmp42_outputWritten) __out.AppendLine(true);
                    if (__tmp42_outputWritten)
                    {
                        __out.AppendLine(false); //884:218
                    }
                }
                __out.Write("        }"); //886:1
                __out.AppendLine(false); //886:10
                __out.AppendLine(true); //887:1
                __out.Write("        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)"); //888:1
                __out.AppendLine(false); //888:182
                __out.Write("        {"); //889:1
                __out.AppendLine(false); //889:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Metadata)) //890:14
                {
                    bool __tmp51_outputWritten = false;
                    string __tmp52_line = "            throw new NotImplementedException(\"There is no Metadata"; //891:1
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
                    string __tmp54_line = " implemented.\");"; //891:81
                    if (!string.IsNullOrEmpty(__tmp54_line))
                    {
                        __out.Write(__tmp54_line);
                        __tmp51_outputWritten = true;
                    }
                    if (__tmp51_outputWritten) __out.AppendLine(true);
                    if (__tmp51_outputWritten)
                    {
                        __out.AppendLine(false); //891:97
                    }
                }
                else if (symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //892:14
                {
                    bool __tmp56_outputWritten = false;
                    string __tmp57_line = "            throw new NotImplementedException(\"CreateMetadataSymbol for Metadata"; //893:1
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
                    string __tmp59_line = " should be implemented in a custom SymbolFactory.\");"; //893:94
                    if (!string.IsNullOrEmpty(__tmp59_line))
                    {
                        __out.Write(__tmp59_line);
                        __tmp56_outputWritten = true;
                    }
                    if (__tmp56_outputWritten) __out.AppendLine(true);
                    if (__tmp56_outputWritten)
                    {
                        __out.AppendLine(false); //893:146
                    }
                }
                else //894:14
                {
                    bool __tmp61_outputWritten = false;
                    string __tmp62_line = "            return new Metadata.Metadata"; //895:1
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
                    string __tmp64_line = ".Error(wrappedSymbol, kind, errorInfo, unreported"; //895:54
                    if (!string.IsNullOrEmpty(__tmp64_line))
                    {
                        __out.Write(__tmp64_line);
                        __tmp61_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //895:104
                    {
                        string __tmp66_line = ", modelObject"; //895:161
                        if (!string.IsNullOrEmpty(__tmp66_line))
                        {
                            __out.Write(__tmp66_line);
                            __tmp61_outputWritten = true;
                        }
                    }
                    string __tmp68_line = ");"; //895:182
                    if (!string.IsNullOrEmpty(__tmp68_line))
                    {
                        __out.Write(__tmp68_line);
                        __tmp61_outputWritten = true;
                    }
                    if (__tmp61_outputWritten) __out.AppendLine(true);
                    if (__tmp61_outputWritten)
                    {
                        __out.AppendLine(false); //895:184
                    }
                }
                __out.Write("        }"); //897:1
                __out.AppendLine(false); //897:10
                __out.AppendLine(true); //898:1
                __out.Write("        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)"); //899:1
                __out.AppendLine(false); //899:112
                __out.Write("        {"); //900:1
                __out.AppendLine(false); //900:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Source)) //901:14
                {
                    bool __tmp70_outputWritten = false;
                    string __tmp71_line = "            throw new NotImplementedException(\"There is no Source"; //902:1
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
                    string __tmp73_line = " implemented.\");"; //902:79
                    if (!string.IsNullOrEmpty(__tmp73_line))
                    {
                        __out.Write(__tmp73_line);
                        __tmp70_outputWritten = true;
                    }
                    if (__tmp70_outputWritten) __out.AppendLine(true);
                    if (__tmp70_outputWritten)
                    {
                        __out.AppendLine(false); //902:95
                    }
                }
                else if (symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //903:14
                {
                    bool __tmp75_outputWritten = false;
                    string __tmp76_line = "            throw new NotImplementedException(\"CreateSourceSymbol for Source"; //904:1
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
                    string __tmp78_line = " should be implemented in a custom SymbolFactory.\");"; //904:90
                    if (!string.IsNullOrEmpty(__tmp78_line))
                    {
                        __out.Write(__tmp78_line);
                        __tmp75_outputWritten = true;
                    }
                    if (__tmp75_outputWritten) __out.AppendLine(true);
                    if (__tmp75_outputWritten)
                    {
                        __out.AppendLine(false); //904:142
                    }
                }
                else //905:14
                {
                    bool __tmp80_outputWritten = false;
                    string __tmp81_line = "            return new Source.Source"; //906:1
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
                    string __tmp83_line = "(container, declaration"; //906:50
                    if (!string.IsNullOrEmpty(__tmp83_line))
                    {
                        __out.Write(__tmp83_line);
                        __tmp80_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //906:74
                    {
                        string __tmp85_line = ", modelObject"; //906:131
                        if (!string.IsNullOrEmpty(__tmp85_line))
                        {
                            __out.Write(__tmp85_line);
                            __tmp80_outputWritten = true;
                        }
                    }
                    string __tmp87_line = ");"; //906:152
                    if (!string.IsNullOrEmpty(__tmp87_line))
                    {
                        __out.Write(__tmp87_line);
                        __tmp80_outputWritten = true;
                    }
                    if (__tmp80_outputWritten) __out.AppendLine(true);
                    if (__tmp80_outputWritten)
                    {
                        __out.AppendLine(false); //906:154
                    }
                }
                __out.Write("        }"); //908:1
                __out.AppendLine(false); //908:10
                __out.AppendLine(true); //909:1
                __out.Write("        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)"); //910:1
                __out.AppendLine(false); //910:248
                __out.Write("        {"); //911:1
                __out.AppendLine(false); //911:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Source)) //912:14
                {
                    bool __tmp89_outputWritten = false;
                    string __tmp90_line = "            throw new NotImplementedException(\"There is no Source"; //913:1
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
                    string __tmp92_line = " implemented.\");"; //913:79
                    if (!string.IsNullOrEmpty(__tmp92_line))
                    {
                        __out.Write(__tmp92_line);
                        __tmp89_outputWritten = true;
                    }
                    if (__tmp89_outputWritten) __out.AppendLine(true);
                    if (__tmp89_outputWritten)
                    {
                        __out.AppendLine(false); //913:95
                    }
                }
                else if (symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //914:14
                {
                    bool __tmp94_outputWritten = false;
                    string __tmp95_line = "            throw new NotImplementedException(\"CreateSourceSymbol for Source"; //915:1
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
                    string __tmp97_line = " should be implemented in a custom SymbolFactory.\");"; //915:90
                    if (!string.IsNullOrEmpty(__tmp97_line))
                    {
                        __out.Write(__tmp97_line);
                        __tmp94_outputWritten = true;
                    }
                    if (__tmp94_outputWritten) __out.AppendLine(true);
                    if (__tmp94_outputWritten)
                    {
                        __out.AppendLine(false); //915:142
                    }
                }
                else //916:14
                {
                    bool __tmp99_outputWritten = false;
                    string __tmp100_line = "            return new Source.Source"; //917:1
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
                    string __tmp102_line = ".Error(container, declaration, kind, errorInfo, candidateSymbols, unreported"; //917:50
                    if (!string.IsNullOrEmpty(__tmp102_line))
                    {
                        __out.Write(__tmp102_line);
                        __tmp99_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //917:127
                    {
                        string __tmp104_line = ", modelObject"; //917:184
                        if (!string.IsNullOrEmpty(__tmp104_line))
                        {
                            __out.Write(__tmp104_line);
                            __tmp99_outputWritten = true;
                        }
                    }
                    string __tmp106_line = ");"; //917:205
                    if (!string.IsNullOrEmpty(__tmp106_line))
                    {
                        __out.Write(__tmp106_line);
                        __tmp99_outputWritten = true;
                    }
                    if (__tmp99_outputWritten) __out.AppendLine(true);
                    if (__tmp99_outputWritten)
                    {
                        __out.AppendLine(false); //917:207
                    }
                }
                __out.Write("        }"); //919:1
                __out.AppendLine(false); //919:10
                __out.AppendLine(true); //920:1
                __out.Write("        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)"); //921:1
                __out.AppendLine(false); //921:180
                __out.Write("        {"); //922:1
                __out.AppendLine(false); //922:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Source)) //923:14
                {
                    bool __tmp108_outputWritten = false;
                    string __tmp109_line = "            throw new NotImplementedException(\"There is no Source"; //924:1
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
                    string __tmp111_line = " implemented.\");"; //924:79
                    if (!string.IsNullOrEmpty(__tmp111_line))
                    {
                        __out.Write(__tmp111_line);
                        __tmp108_outputWritten = true;
                    }
                    if (__tmp108_outputWritten) __out.AppendLine(true);
                    if (__tmp108_outputWritten)
                    {
                        __out.AppendLine(false); //924:95
                    }
                }
                else if (symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //925:14
                {
                    bool __tmp113_outputWritten = false;
                    string __tmp114_line = "            throw new NotImplementedException(\"CreateSourceSymbol for Source"; //926:1
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
                    string __tmp116_line = " should be implemented in a custom SymbolFactory.\");"; //926:90
                    if (!string.IsNullOrEmpty(__tmp116_line))
                    {
                        __out.Write(__tmp116_line);
                        __tmp113_outputWritten = true;
                    }
                    if (__tmp113_outputWritten) __out.AppendLine(true);
                    if (__tmp113_outputWritten)
                    {
                        __out.AppendLine(false); //926:142
                    }
                }
                else //927:14
                {
                    bool __tmp118_outputWritten = false;
                    string __tmp119_line = "            return new Source.Source"; //928:1
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
                    string __tmp121_line = ".Error(wrappedSymbol, kind, errorInfo, unreported"; //928:50
                    if (!string.IsNullOrEmpty(__tmp121_line))
                    {
                        __out.Write(__tmp121_line);
                        __tmp118_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //928:100
                    {
                        string __tmp123_line = ", modelObject"; //928:157
                        if (!string.IsNullOrEmpty(__tmp123_line))
                        {
                            __out.Write(__tmp123_line);
                            __tmp118_outputWritten = true;
                        }
                    }
                    string __tmp125_line = ");"; //928:178
                    if (!string.IsNullOrEmpty(__tmp125_line))
                    {
                        __out.Write(__tmp125_line);
                        __tmp118_outputWritten = true;
                    }
                    if (__tmp118_outputWritten) __out.AppendLine(true);
                    if (__tmp118_outputWritten)
                    {
                        __out.AppendLine(false); //928:180
                    }
                }
                __out.Write("        }"); //930:1
                __out.AppendLine(false); //930:10
                __out.Write("	}"); //931:1
                __out.AppendLine(false); //931:3
                __out.AppendLine(true); //932:1
            }
            __out.Write("}"); //934:1
            __out.AppendLine(false); //934:2
            return __out.ToStringAndFree();
        }

    }
}

