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
            string __tmp7_line = "	public "; //20:1
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp6_outputWritten = true;
            }
            if (!symbol.ExistingTypeInfo.IsSealed) //20:10
            {
                string __tmp9_line = "abstract "; //20:49
                if (!string.IsNullOrEmpty(__tmp9_line))
                {
                    __out.Write(__tmp9_line);
                    __tmp6_outputWritten = true;
                }
            }
            string __tmp11_line = "partial class "; //20:66
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
                __out.AppendLine(false); //20:93
            }
            __out.Write("	{"); //21:1
            __out.AppendLine(false); //21:3
            __out.Write("        public "); //22:1
            if (symbol.IsSymbolClass) //22:17
            {
                __out.Write("virtual"); //22:43
            }
            else //22:51
            {
                __out.Write("override"); //22:56
            }
            __out.Write(" void Accept(MetaDslx.CodeAnalysis.Symbols.SymbolVisitor visitor)"); //22:72
            __out.AppendLine(false); //22:137
            __out.Write("        {"); //23:1
            __out.AppendLine(false); //23:10
            __out.Write("            if (visitor is ISymbolVisitor isv) isv.Visit(this);"); //24:1
            __out.AppendLine(false); //24:64
            __out.Write("        }"); //25:1
            __out.AppendLine(false); //25:10
            __out.AppendLine(true); //26:1
            __out.Write("        public "); //27:1
            if (symbol.IsSymbolClass) //27:17
            {
                __out.Write("virtual"); //27:43
            }
            else //27:51
            {
                __out.Write("override"); //27:56
            }
            __out.Write(" TResult Accept<TResult>(MetaDslx.CodeAnalysis.Symbols.SymbolVisitor<TResult> visitor)"); //27:72
            __out.AppendLine(false); //27:158
            __out.Write("        {"); //28:1
            __out.AppendLine(false); //28:10
            __out.Write("            if (visitor is ISymbolVisitor<TResult> isv) return isv.Visit(this);"); //29:1
            __out.AppendLine(false); //29:80
            __out.Write("            else return default(TResult);"); //30:1
            __out.AppendLine(false); //30:42
            __out.Write("        }"); //31:1
            __out.AppendLine(false); //31:10
            __out.AppendLine(true); //32:1
            __out.Write("        public "); //33:1
            if (symbol.IsSymbolClass) //33:17
            {
                __out.Write("virtual"); //33:43
            }
            else //33:51
            {
                __out.Write("override"); //33:56
            }
            __out.Write(" TResult Accept<TArgument, TResult>(MetaDslx.CodeAnalysis.Symbols.SymbolVisitor<TArgument, TResult> visitor, TArgument argument)"); //33:72
            __out.AppendLine(false); //33:200
            __out.Write("        {"); //34:1
            __out.AppendLine(false); //34:10
            __out.Write("            if (visitor is ISymbolVisitor<TArgument, TResult> isv) return isv.Visit(this, argument);"); //35:1
            __out.AppendLine(false); //35:101
            __out.Write("            else return default(TResult);"); //36:1
            __out.AppendLine(false); //36:42
            __out.Write("        }"); //37:1
            __out.AppendLine(false); //37:10
            __out.Write("	}"); //38:1
            __out.AppendLine(false); //38:3
            __out.Write("}"); //39:1
            __out.AppendLine(false); //39:2
            return __out.ToStringAndFree();
        }

        public string GenerateCompletionSymbol(SymbolGenerationInfo symbol) //42:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //43:1
            __out.AppendLine(false); //43:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //44:1
            __out.AppendLine(false); //44:29
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //45:1
            __out.AppendLine(false); //45:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //46:1
            __out.AppendLine(false); //46:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //47:1
            __out.AppendLine(false); //47:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //48:1
            __out.AppendLine(false); //48:44
            __out.Write("using System;"); //49:1
            __out.AppendLine(false); //49:14
            __out.Write("using System.Collections.Generic;"); //50:1
            __out.AppendLine(false); //50:34
            __out.Write("using System.Collections.Immutable;"); //51:1
            __out.AppendLine(false); //51:36
            __out.Write("using System.Diagnostics;"); //52:1
            __out.AppendLine(false); //52:26
            __out.Write("using System.Text;"); //53:1
            __out.AppendLine(false); //53:19
            __out.Write("using System.Threading;"); //54:1
            __out.AppendLine(false); //54:24
            __out.Write("using Roslyn.Utilities;"); //55:1
            __out.AppendLine(false); //55:24
            __out.AppendLine(true); //56:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //57:1
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
            string __tmp5_line = ".Completion"; //57:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //57:44
            }
            __out.Write("{"); //58:1
            __out.AppendLine(false); //58:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public abstract partial class Completion"; //59:1
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
            if (symbol.ExistingCompletionTypeInfo.BaseType == null) //59:56
            {
                string __tmp11_line = " : "; //59:112
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
                string __tmp13_line = "."; //59:137
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
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //59:152
                {
                    string __tmp16_line = ", MetaDslx.CodeAnalysis.Symbols.Metadata.IModelSymbol"; //59:209
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
                __out.AppendLine(false); //59:278
            }
            __out.Write("	{"); //60:1
            __out.AppendLine(false); //60:3
            __out.Write("        public static class CompletionParts"); //61:1
            __out.AppendLine(false); //61:44
            __out.Write("        {"); //62:1
            __out.AppendLine(false); //62:10
            var __loop1_results = 
                (from partName in __Enumerate((symbol.GetCompletionPartNames()).GetEnumerator()) //63:20
                select new { partName = partName}
                ).ToList(); //63:14
            for (int __loop1_iteration = 0; __loop1_iteration < __loop1_results.Count; ++__loop1_iteration)
            {
                var __tmp19 = __loop1_results[__loop1_iteration];
                var partName = __tmp19.partName;
                bool __tmp21_outputWritten = false;
                string __tmp22_line = "            public static readonly CompletionPart "; //64:1
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
                string __tmp24_line = " = new CompletionPart(nameof("; //64:61
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
                string __tmp26_line = "));"; //64:100
                if (!string.IsNullOrEmpty(__tmp26_line))
                {
                    __out.Write(__tmp26_line);
                    __tmp21_outputWritten = true;
                }
                if (__tmp21_outputWritten) __out.AppendLine(true);
                if (__tmp21_outputWritten)
                {
                    __out.AppendLine(false); //64:103
                }
            }
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "            public static readonly ImmutableHashSet<CompletionPart> AllWithLocation = CompletionPart.Combine("; //66:1
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Write(__tmp29_line);
                __tmp28_outputWritten = true;
            }
            var __loop2_results = 
                (from partName in __Enumerate((symbol.GetOrderedCompletionParts(true)).GetEnumerator()) //66:117
                select new { partName = partName}
                ).ToList(); //66:111
            for (int __loop2_iteration = 0; __loop2_iteration < __loop2_results.Count; ++__loop2_iteration)
            {
                string comma; //66:164
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
            string __tmp35_line = ");"; //66:217
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Write(__tmp35_line);
                __tmp28_outputWritten = true;
            }
            if (__tmp28_outputWritten) __out.AppendLine(true);
            if (__tmp28_outputWritten)
            {
                __out.AppendLine(false); //66:219
            }
            bool __tmp37_outputWritten = false;
            string __tmp38_line = "            public static readonly ImmutableHashSet<CompletionPart> All = CompletionPart.Combine("; //67:1
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Write(__tmp38_line);
                __tmp37_outputWritten = true;
            }
            var __loop3_results = 
                (from partName in __Enumerate((symbol.GetOrderedCompletionParts(false)).GetEnumerator()) //67:105
                select new { partName = partName}
                ).ToList(); //67:99
            for (int __loop3_iteration = 0; __loop3_iteration < __loop3_results.Count; ++__loop3_iteration)
            {
                string comma; //67:153
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
            string __tmp44_line = ");"; //67:206
            if (!string.IsNullOrEmpty(__tmp44_line))
            {
                __out.Write(__tmp44_line);
                __tmp37_outputWritten = true;
            }
            if (__tmp37_outputWritten) __out.AppendLine(true);
            if (__tmp37_outputWritten)
            {
                __out.AppendLine(false); //67:208
            }
            bool __tmp46_outputWritten = false;
            string __tmp47_line = "            public static readonly CompletionGraph CompletionGraph = CompletionGraph.FromCompletionParts("; //68:1
            if (!string.IsNullOrEmpty(__tmp47_line))
            {
                __out.Write(__tmp47_line);
                __tmp46_outputWritten = true;
            }
            var __loop4_results = 
                (from partName in __Enumerate((symbol.GetOrderedCompletionParts(false)).GetEnumerator()) //68:113
                select new { partName = partName}
                ).ToList(); //68:107
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                string comma; //68:161
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
            string __tmp53_line = ");"; //68:214
            if (!string.IsNullOrEmpty(__tmp53_line))
            {
                __out.Write(__tmp53_line);
                __tmp46_outputWritten = true;
            }
            if (__tmp46_outputWritten) __out.AppendLine(true);
            if (__tmp46_outputWritten)
            {
                __out.AppendLine(false); //68:216
            }
            __out.Write("        }"); //69:1
            __out.AppendLine(false); //69:10
            __out.AppendLine(true); //70:1
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //71:10
            {
                __out.Write("        private readonly Symbol _container;"); //72:1
                __out.AppendLine(false); //72:44
            }
            if (symbol.ModelObjectOption != ParameterOption.Disabled) //74:10
            {
                __out.Write("        private readonly object? _modelObject;"); //75:1
                __out.AppendLine(false); //75:47
            }
            __out.Write("        private readonly CompletionState _state;"); //77:1
            __out.AppendLine(false); //77:49
            __out.Write("        private ImmutableArray<Symbol> _childSymbols;"); //78:1
            __out.AppendLine(false); //78:54
            __out.Write("        private string _name;"); //79:1
            __out.AppendLine(false); //79:30
            var __loop5_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //80:16
                select new { prop = prop}
                ).ToList(); //80:10
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                var __tmp54 = __loop5_results[__loop5_iteration];
                var prop = __tmp54.prop;
                bool __tmp56_outputWritten = false;
                string __tmp57_line = "        private "; //81:1
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
                string __tmp59_line = " "; //81:28
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
                string __tmp61_line = ";"; //81:45
                if (!string.IsNullOrEmpty(__tmp61_line))
                {
                    __out.Write(__tmp61_line);
                    __tmp56_outputWritten = true;
                }
                if (__tmp56_outputWritten) __out.AppendLine(true);
                if (__tmp56_outputWritten)
                {
                    __out.AppendLine(false); //81:46
                }
            }
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //83:10
            {
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains(".ctor")) //84:10
                {
                    __out.AppendLine(true); //85:1
                    bool __tmp63_outputWritten = false;
                    string __tmp64_line = "        public Completion"; //86:1
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
                    string __tmp66_line = "(Symbol container"; //86:39
                    if (!string.IsNullOrEmpty(__tmp66_line))
                    {
                        __out.Write(__tmp66_line);
                        __tmp63_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //86:57
                    {
                        string __tmp68_line = ", object? modelObject"; //86:114
                        if (!string.IsNullOrEmpty(__tmp68_line))
                        {
                            __out.Write(__tmp68_line);
                            __tmp63_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //86:136
                        {
                            string __tmp70_line = " = null"; //86:193
                            if (!string.IsNullOrEmpty(__tmp70_line))
                            {
                                __out.Write(__tmp70_line);
                                __tmp63_outputWritten = true;
                            }
                        }
                    }
                    string __tmp73_line = ", bool isError = false)"; //86:216
                    if (!string.IsNullOrEmpty(__tmp73_line))
                    {
                        __out.Write(__tmp73_line);
                        __tmp63_outputWritten = true;
                    }
                    if (__tmp63_outputWritten) __out.AppendLine(true);
                    if (__tmp63_outputWritten)
                    {
                        __out.AppendLine(false); //86:239
                    }
                    __out.Write("        {"); //87:1
                    __out.AppendLine(false); //87:10
                    __out.Write("            _container = container;"); //88:1
                    __out.AppendLine(false); //88:36
                    if (symbol.ModelObjectOption == ParameterOption.Required) //89:14
                    {
                        __out.Write("            if (!isError && modelObject is null) throw new ArgumentNullException(nameof(modelObject));"); //90:1
                        __out.AppendLine(false); //90:103
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //92:14
                    {
                        __out.Write("            _modelObject = modelObject;"); //93:1
                        __out.AppendLine(false); //93:40
                    }
                    __out.Write("            _state = CompletionParts.CompletionGraph.CreateState();"); //95:1
                    __out.AppendLine(false); //95:68
                    __out.Write("        }"); //96:1
                    __out.AppendLine(false); //96:10
                }
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains("Language")) //98:10
                {
                    __out.AppendLine(true); //99:1
                    __out.Write("        public override Language Language => ContainingModule.Language;"); //100:1
                    __out.AppendLine(false); //100:72
                }
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains("SymbolFactory")) //102:10
                {
                    __out.AppendLine(true); //103:1
                    __out.Write("        public SymbolFactory SymbolFactory => ContainingModule.SymbolFactory;"); //104:1
                    __out.AppendLine(false); //104:78
                }
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //106:10
                {
                    if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ModelObject")) //107:14
                    {
                        __out.AppendLine(true); //108:1
                        __out.Write("        public object ModelObject => _modelObject;"); //109:1
                        __out.AppendLine(false); //109:51
                    }
                    if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ModelObjectType")) //111:14
                    {
                        __out.AppendLine(true); //112:1
                        __out.Write("        public Type ModelObjectType => _modelObject is not null ? Language.SymbolFacts.GetModelObjectType(_modelObject) : null;"); //113:1
                        __out.AppendLine(false); //113:128
                    }
                }
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ContainingSymbol")) //116:10
                {
                    __out.AppendLine(true); //117:1
                    __out.Write("        public override Symbol ContainingSymbol => _container;"); //118:1
                    __out.AppendLine(false); //118:63
                }
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ChildSymbols")) //121:10
            {
                __out.AppendLine(true); //122:1
                __out.Write("        public override ImmutableArray<Symbol> ChildSymbols "); //123:1
                __out.AppendLine(false); //123:61
                __out.Write("        {"); //124:1
                __out.AppendLine(false); //124:10
                __out.Write("            get"); //125:1
                __out.AppendLine(false); //125:16
                __out.Write("            {"); //126:1
                __out.AppendLine(false); //126:14
                __out.Write("                this.ForceComplete(CompletionGraph.FinishCreatingChildren, null, default);"); //127:1
                __out.AppendLine(false); //127:91
                __out.Write("                return _childSymbols;"); //128:1
                __out.AppendLine(false); //128:38
                __out.Write("            }"); //129:1
                __out.AppendLine(false); //129:14
                __out.Write("        }"); //130:1
                __out.AppendLine(false); //130:10
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("Name")) //132:10
            {
                __out.AppendLine(true); //133:1
                __out.Write("        public override string Name "); //134:1
                __out.AppendLine(false); //134:37
                __out.Write("        {"); //135:1
                __out.AppendLine(false); //135:10
                __out.Write("            get"); //136:1
                __out.AppendLine(false); //136:16
                __out.Write("            {"); //137:1
                __out.AppendLine(false); //137:14
                __out.Write("                this.ForceComplete(CompletionGraph.FinishInitializing, null, default);"); //138:1
                __out.AppendLine(false); //138:87
                __out.Write("                return _name;"); //139:1
                __out.AppendLine(false); //139:30
                __out.Write("            }"); //140:1
                __out.AppendLine(false); //140:14
                __out.Write("        }"); //141:1
                __out.AppendLine(false); //141:10
            }
            var __loop6_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //143:16
                select new { prop = prop}
                ).ToList(); //143:10
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp74 = __loop6_results[__loop6_iteration];
                var prop = __tmp74.prop;
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains(prop.Name)) //144:14
                {
                    __out.AppendLine(true); //145:1
                    bool __tmp76_outputWritten = false;
                    string __tmp77_line = "        public override "; //146:1
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
                    string __tmp79_line = " "; //146:36
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
                        __out.AppendLine(false); //146:48
                    }
                    __out.Write("        {"); //147:1
                    __out.AppendLine(false); //147:10
                    __out.Write("            get"); //148:1
                    __out.AppendLine(false); //148:16
                    __out.Write("            {"); //149:1
                    __out.AppendLine(false); //149:14
                    bool __tmp82_outputWritten = false;
                    string __tmp83_line = "                this.ForceComplete(CompletionParts."; //150:1
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
                    string __tmp85_line = ", null, default);"; //150:83
                    if (!string.IsNullOrEmpty(__tmp85_line))
                    {
                        __out.Write(__tmp85_line);
                        __tmp82_outputWritten = true;
                    }
                    if (__tmp82_outputWritten) __out.AppendLine(true);
                    if (__tmp82_outputWritten)
                    {
                        __out.AppendLine(false); //150:100
                    }
                    bool __tmp87_outputWritten = false;
                    string __tmp88_line = "                return "; //151:1
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
                    string __tmp90_line = ";"; //151:40
                    if (!string.IsNullOrEmpty(__tmp90_line))
                    {
                        __out.Write(__tmp90_line);
                        __tmp87_outputWritten = true;
                    }
                    if (__tmp87_outputWritten) __out.AppendLine(true);
                    if (__tmp87_outputWritten)
                    {
                        __out.AppendLine(false); //151:41
                    }
                    __out.Write("            }"); //152:1
                    __out.AppendLine(false); //152:14
                    __out.Write("        }"); //153:1
                    __out.AppendLine(false); //153:10
                }
            }
            __out.AppendLine(true); //156:1
            __out.Write("        #region Completion"); //157:1
            __out.AppendLine(false); //157:27
            __out.AppendLine(true); //158:1
            __out.Write("        public sealed override bool RequiresCompletion => true;"); //159:1
            __out.AppendLine(false); //159:64
            __out.AppendLine(true); //160:1
            __out.Write("        public sealed override bool HasComplete(CompletionPart part)"); //161:1
            __out.AppendLine(false); //161:69
            __out.Write("        {"); //162:1
            __out.AppendLine(false); //162:10
            __out.Write("            return _state.HasComplete(part);"); //163:1
            __out.AppendLine(false); //163:45
            __out.Write("        }"); //164:1
            __out.AppendLine(false); //164:10
            __out.AppendLine(true); //165:1
            __out.Write("        public override void ForceComplete(CompletionPart completionPart, SourceLocation locationOpt, CancellationToken cancellationToken)"); //166:1
            __out.AppendLine(false); //166:139
            __out.Write("        {"); //167:1
            __out.AppendLine(false); //167:10
            __out.Write("            if (completionPart != null && _state.HasComplete(completionPart)) return;"); //168:1
            __out.AppendLine(false); //168:86
            __out.Write("            if (completionPart != null && !CompletionParts.All.Contains(completionPart)) throw new ArgumentException(nameof(completionPart));"); //169:1
            __out.AppendLine(false); //169:142
            __out.Write("            while (true)"); //170:1
            __out.AppendLine(false); //170:25
            __out.Write("            {"); //171:1
            __out.AppendLine(false); //171:14
            __out.Write("                cancellationToken.ThrowIfCancellationRequested();"); //172:1
            __out.AppendLine(false); //172:66
            __out.Write("                var incompletePart = _state.NextIncompletePart;"); //173:1
            __out.AppendLine(false); //173:64
            __out.Write("                if (incompletePart == CompletionGraph.StartInitializing || incompletePart == CompletionGraph.FinishInitializing)"); //174:1
            __out.AppendLine(false); //174:129
            __out.Write("                {"); //175:1
            __out.AppendLine(false); //175:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartInitializing))"); //176:1
            __out.AppendLine(false); //176:84
            __out.Write("                    {"); //177:1
            __out.AppendLine(false); //177:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //178:1
            __out.AppendLine(false); //178:71
            __out.Write("                        _name = CompleteSymbolProperty_Name(diagnostics, cancellationToken);"); //179:1
            __out.AppendLine(false); //179:93
            __out.Write("                        CompleteInitializingSymbol(diagnostics, cancellationToken);"); //180:1
            __out.AppendLine(false); //180:84
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //181:1
            __out.AppendLine(false); //181:59
            __out.Write("                        diagnostics.Free();"); //182:1
            __out.AppendLine(false); //182:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishInitializing);"); //183:1
            __out.AppendLine(false); //183:85
            __out.Write("                    }"); //184:1
            __out.AppendLine(false); //184:22
            __out.Write("                }"); //185:1
            __out.AppendLine(false); //185:18
            __out.Write("                else if (incompletePart == CompletionGraph.StartCreatingChildren || incompletePart == CompletionGraph.FinishCreatingChildren)"); //186:1
            __out.AppendLine(false); //186:142
            __out.Write("                {"); //187:1
            __out.AppendLine(false); //187:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartCreatingChildren))"); //188:1
            __out.AppendLine(false); //188:88
            __out.Write("                    {"); //189:1
            __out.AppendLine(false); //189:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //190:1
            __out.AppendLine(false); //190:71
            __out.Write("                        _childSymbols = CompleteCreatingChildSymbols(diagnostics, cancellationToken);"); //191:1
            __out.AppendLine(false); //191:102
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //192:1
            __out.AppendLine(false); //192:59
            __out.Write("                        diagnostics.Free();"); //193:1
            __out.AppendLine(false); //193:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishCreatingChildren);"); //194:1
            __out.AppendLine(false); //194:89
            __out.Write("                    }"); //195:1
            __out.AppendLine(false); //195:22
            __out.Write("                }"); //196:1
            __out.AppendLine(false); //196:18
            var __loop7_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //197:24
                select new { part = part}
                ).ToList(); //197:18
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                var __tmp91 = __loop7_results[__loop7_iteration];
                var part = __tmp91.part;
                if (part.IsLocked) //198:22
                {
                    bool __tmp93_outputWritten = false;
                    string __tmp94_line = "                else if (incompletePart == CompletionParts."; //199:1
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
                    string __tmp96_line = " || incompletePart == CompletionParts."; //199:90
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
                    string __tmp98_line = ")"; //199:159
                    if (!string.IsNullOrEmpty(__tmp98_line))
                    {
                        __out.Write(__tmp98_line);
                        __tmp93_outputWritten = true;
                    }
                    if (__tmp93_outputWritten) __out.AppendLine(true);
                    if (__tmp93_outputWritten)
                    {
                        __out.AppendLine(false); //199:160
                    }
                    __out.Write("                {"); //200:1
                    __out.AppendLine(false); //200:18
                    bool __tmp100_outputWritten = false;
                    string __tmp101_line = "                    if (_state.NotePartComplete(CompletionParts."; //201:1
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
                    string __tmp103_line = "))"; //201:95
                    if (!string.IsNullOrEmpty(__tmp103_line))
                    {
                        __out.Write(__tmp103_line);
                        __tmp100_outputWritten = true;
                    }
                    if (__tmp100_outputWritten) __out.AppendLine(true);
                    if (__tmp100_outputWritten)
                    {
                        __out.AppendLine(false); //201:97
                    }
                    __out.Write("                    {"); //202:1
                    __out.AppendLine(false); //202:22
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //203:26
                    {
                        __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //204:1
                        __out.AppendLine(false); //204:71
                    }
                    bool __tmp105_outputWritten = false;
                    string __tmp104Prefix = "                        "; //206:1
                    if (part is SymbolPropertyGenerationInfo) //206:26
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
                        string __tmp108_line = " = "; //206:116
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
                    string __tmp111_line = "("; //206:152
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
                    string __tmp113_line = ");"; //206:181
                    if (!string.IsNullOrEmpty(__tmp113_line))
                    {
                        __out.Write(__tmp113_line);
                        __tmp105_outputWritten = true;
                    }
                    if (__tmp105_outputWritten) __out.AppendLine(true);
                    if (__tmp105_outputWritten)
                    {
                        __out.AppendLine(false); //206:183
                    }
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //207:26
                    {
                        __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //208:1
                        __out.AppendLine(false); //208:59
                        __out.Write("                        diagnostics.Free();"); //209:1
                        __out.AppendLine(false); //209:44
                    }
                    bool __tmp115_outputWritten = false;
                    string __tmp116_line = "                        _state.NotePartComplete(CompletionParts."; //211:1
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
                    string __tmp118_line = ");"; //211:96
                    if (!string.IsNullOrEmpty(__tmp118_line))
                    {
                        __out.Write(__tmp118_line);
                        __tmp115_outputWritten = true;
                    }
                    if (__tmp115_outputWritten) __out.AppendLine(true);
                    if (__tmp115_outputWritten)
                    {
                        __out.AppendLine(false); //211:98
                    }
                    __out.Write("                    }"); //212:1
                    __out.AppendLine(false); //212:22
                    __out.Write("                }"); //213:1
                    __out.AppendLine(false); //213:18
                }
                else //214:22
                {
                    bool __tmp120_outputWritten = false;
                    string __tmp121_line = "                else if (incompletePart == CompletionParts."; //215:1
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
                    string __tmp123_line = ")"; //215:85
                    if (!string.IsNullOrEmpty(__tmp123_line))
                    {
                        __out.Write(__tmp123_line);
                        __tmp120_outputWritten = true;
                    }
                    if (__tmp120_outputWritten) __out.AppendLine(true);
                    if (__tmp120_outputWritten)
                    {
                        __out.AppendLine(false); //215:86
                    }
                    __out.Write("                {"); //216:1
                    __out.AppendLine(false); //216:18
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //217:22
                    {
                        __out.Write("                    var diagnostics = DiagnosticBag.GetInstance();"); //218:1
                        __out.AppendLine(false); //218:67
                    }
                    bool __tmp125_outputWritten = false;
                    string __tmp124Prefix = "                    "; //220:1
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
                    string __tmp127_line = "("; //220:46
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
                    string __tmp129_line = ");"; //220:75
                    if (!string.IsNullOrEmpty(__tmp129_line))
                    {
                        __out.Write(__tmp129_line);
                        __tmp125_outputWritten = true;
                    }
                    if (__tmp125_outputWritten) __out.AppendLine(true);
                    if (__tmp125_outputWritten)
                    {
                        __out.AppendLine(false); //220:77
                    }
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //221:22
                    {
                        __out.Write("                    AddSymbolDiagnostics(diagnostics);"); //222:1
                        __out.AppendLine(false); //222:55
                        __out.Write("                    diagnostics.Free();"); //223:1
                        __out.AppendLine(false); //223:40
                    }
                    bool __tmp131_outputWritten = false;
                    string __tmp132_line = "                    _state.NotePartComplete(CompletionParts."; //225:1
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
                    string __tmp134_line = ");"; //225:86
                    if (!string.IsNullOrEmpty(__tmp134_line))
                    {
                        __out.Write(__tmp134_line);
                        __tmp131_outputWritten = true;
                    }
                    if (__tmp131_outputWritten) __out.AppendLine(true);
                    if (__tmp131_outputWritten)
                    {
                        __out.AppendLine(false); //225:88
                    }
                    __out.Write("                }"); //226:1
                    __out.AppendLine(false); //226:18
                }
            }
            __out.Write("                else if (incompletePart == CompletionGraph.StartComputingNonSymbolProperties || incompletePart == CompletionGraph.FinishComputingNonSymbolProperties)"); //229:1
            __out.AppendLine(false); //229:166
            __out.Write("                {"); //230:1
            __out.AppendLine(false); //230:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartComputingNonSymbolProperties))"); //231:1
            __out.AppendLine(false); //231:100
            __out.Write("                    {"); //232:1
            __out.AppendLine(false); //232:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //233:1
            __out.AppendLine(false); //233:71
            __out.Write("                        CompleteNonSymbolProperties(locationOpt, diagnostics, cancellationToken);"); //234:1
            __out.AppendLine(false); //234:98
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //235:1
            __out.AppendLine(false); //235:59
            __out.Write("                        diagnostics.Free();"); //236:1
            __out.AppendLine(false); //236:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishComputingNonSymbolProperties);"); //237:1
            __out.AppendLine(false); //237:101
            __out.Write("                    }"); //238:1
            __out.AppendLine(false); //238:22
            __out.Write("                }"); //239:1
            __out.AppendLine(false); //239:18
            __out.Write("                else if (incompletePart == CompletionGraph.ChildrenCompleted)"); //240:1
            __out.AppendLine(false); //240:78
            __out.Write("                {"); //241:1
            __out.AppendLine(false); //241:18
            __out.Write("                    var diagnostics = DiagnosticBag.GetInstance();"); //242:1
            __out.AppendLine(false); //242:67
            __out.Write("                    CompleteImports(locationOpt, diagnostics, cancellationToken);"); //243:1
            __out.AppendLine(false); //243:82
            __out.Write("                    AddSymbolDiagnostics(diagnostics);"); //244:1
            __out.AppendLine(false); //244:55
            __out.Write("                    diagnostics.Free();"); //245:1
            __out.AppendLine(false); //245:40
            __out.Write("                    bool allCompleted = true;"); //247:1
            __out.AppendLine(false); //247:46
            __out.Write("                    if (locationOpt == null)"); //248:1
            __out.AppendLine(false); //248:45
            __out.Write("                    {"); //249:1
            __out.AppendLine(false); //249:22
            __out.Write("                        foreach (var child in _childSymbols)"); //250:1
            __out.AppendLine(false); //250:61
            __out.Write("                        {"); //251:1
            __out.AppendLine(false); //251:26
            __out.Write("                            cancellationToken.ThrowIfCancellationRequested();"); //252:1
            __out.AppendLine(false); //252:78
            __out.Write("                            child.ForceComplete(null, locationOpt, cancellationToken);"); //253:1
            __out.AppendLine(false); //253:87
            __out.Write("                        }"); //254:1
            __out.AppendLine(false); //254:26
            __out.Write("                    }"); //255:1
            __out.AppendLine(false); //255:22
            __out.Write("                    else"); //256:1
            __out.AppendLine(false); //256:25
            __out.Write("                    {"); //257:1
            __out.AppendLine(false); //257:22
            __out.Write("                        foreach (var child in _childSymbols)"); //258:1
            __out.AppendLine(false); //258:61
            __out.Write("                        {"); //259:1
            __out.AppendLine(false); //259:26
            __out.Write("                            ForceCompleteChildByLocation(locationOpt, child, cancellationToken);"); //260:1
            __out.AppendLine(false); //260:97
            __out.Write("                            allCompleted = allCompleted && child.HasComplete(CompletionGraph.All);"); //261:1
            __out.AppendLine(false); //261:99
            __out.Write("                        }"); //262:1
            __out.AppendLine(false); //262:26
            __out.Write("                    }"); //263:1
            __out.AppendLine(false); //263:22
            __out.Write("                    if (!allCompleted)"); //265:1
            __out.AppendLine(false); //265:39
            __out.Write("                    {"); //266:1
            __out.AppendLine(false); //266:22
            __out.Write("                        // We did not complete all members, so just kick out now."); //267:1
            __out.AppendLine(false); //267:82
            __out.Write("                        var allParts = CompletionParts.AllWithLocation;"); //268:1
            __out.AppendLine(false); //268:72
            __out.Write("                        _state.SpinWaitComplete(allParts, cancellationToken);"); //269:1
            __out.AppendLine(false); //269:78
            __out.Write("                        return;"); //270:1
            __out.AppendLine(false); //270:32
            __out.Write("                    }"); //271:1
            __out.AppendLine(false); //271:22
            __out.Write("                    // We've completed all members, proceed to the next iteration."); //273:1
            __out.AppendLine(false); //273:83
            __out.Write("                    _state.NotePartComplete(CompletionGraph.ChildrenCompleted);"); //274:1
            __out.AppendLine(false); //274:80
            __out.Write("                }"); //275:1
            __out.AppendLine(false); //275:18
            __out.Write("                else if (incompletePart == null)"); //276:1
            __out.AppendLine(false); //276:49
            __out.Write("                {"); //277:1
            __out.AppendLine(false); //277:18
            __out.Write("                    return;"); //278:1
            __out.AppendLine(false); //278:28
            __out.Write("                }"); //279:1
            __out.AppendLine(false); //279:18
            __out.Write("                else"); //280:1
            __out.AppendLine(false); //280:21
            __out.Write("                {"); //281:1
            __out.AppendLine(false); //281:18
            __out.Write("                    // This assert will trigger if we forgot to handle any of the completion parts"); //282:1
            __out.AppendLine(false); //282:99
            __out.Write("                    Debug.Assert(!CompletionParts.All.Contains(incompletePart));"); //283:1
            __out.AppendLine(false); //283:81
            __out.Write("                    // any other values are completion parts intended for other kinds of symbols"); //284:1
            __out.AppendLine(false); //284:97
            __out.Write("                    _state.NotePartComplete(incompletePart);"); //285:1
            __out.AppendLine(false); //285:61
            __out.Write("                }"); //286:1
            __out.AppendLine(false); //286:18
            __out.Write("                if (completionPart != null && _state.HasComplete(completionPart)) return;"); //287:1
            __out.AppendLine(false); //287:90
            __out.Write("                _state.SpinWaitComplete(incompletePart, cancellationToken);"); //288:1
            __out.AppendLine(false); //288:76
            __out.Write("            }"); //289:1
            __out.AppendLine(false); //289:14
            __out.Write("            throw ExceptionUtilities.Unreachable;"); //290:1
            __out.AppendLine(false); //290:50
            __out.Write("        }"); //291:1
            __out.AppendLine(false); //291:10
            __out.AppendLine(true); //292:1
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteSymbolProperty_Name")) //293:10
            {
                __out.Write("        protected abstract string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //294:1
                __out.AppendLine(false); //294:127
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteInitializingSymbol")) //296:10
            {
                __out.Write("        protected abstract void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //297:1
                __out.AppendLine(false); //297:124
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteCreatingChildSymbols")) //299:10
            {
                __out.Write("        protected abstract ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //300:1
                __out.AppendLine(false); //300:144
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteImports")) //302:10
            {
                __out.Write("        protected abstract void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //303:1
                __out.AppendLine(false); //303:141
            }
            var __loop8_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //305:16
                where part.GenerateCompleteMethod //305:44
                select new { part = part}
                ).ToList(); //305:10
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp135 = __loop8_results[__loop8_iteration];
                var part = __tmp135.part;
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains(part.CompleteMethodName)) //306:14
                {
                    bool __tmp137_outputWritten = false;
                    string __tmp138_line = "        protected abstract "; //307:1
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
                    string __tmp140_line = " "; //307:59
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
                    string __tmp142_line = "("; //307:85
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
                    string __tmp144_line = ");"; //307:116
                    if (!string.IsNullOrEmpty(__tmp144_line))
                    {
                        __out.Write(__tmp144_line);
                        __tmp137_outputWritten = true;
                    }
                    if (__tmp137_outputWritten) __out.AppendLine(true);
                    if (__tmp137_outputWritten)
                    {
                        __out.AppendLine(false); //307:118
                    }
                }
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteNonSymbolProperties")) //310:10
            {
                __out.Write("        protected abstract void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //311:1
                __out.AppendLine(false); //311:153
            }
            __out.Write("        #endregion"); //313:1
            __out.AppendLine(false); //313:19
            __out.Write("    }"); //314:1
            __out.AppendLine(false); //314:6
            __out.Write("}"); //315:1
            __out.AppendLine(false); //315:2
            return __out.ToStringAndFree();
        }

        public string GenerateMetadataSymbol(SymbolGenerationInfo symbol) //318:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //319:1
            __out.AppendLine(false); //319:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //320:1
            __out.AppendLine(false); //320:29
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //321:1
            __out.AppendLine(false); //321:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //322:1
            __out.AppendLine(false); //322:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //323:1
            __out.AppendLine(false); //323:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //324:1
            __out.AppendLine(false); //324:44
            __out.Write("using System;"); //325:1
            __out.AppendLine(false); //325:14
            __out.Write("using System.Collections.Generic;"); //326:1
            __out.AppendLine(false); //326:34
            __out.Write("using System.Collections.Immutable;"); //327:1
            __out.AppendLine(false); //327:36
            __out.Write("using System.Diagnostics;"); //328:1
            __out.AppendLine(false); //328:26
            __out.Write("using System.Text;"); //329:1
            __out.AppendLine(false); //329:19
            __out.Write("using System.Threading;"); //330:1
            __out.AppendLine(false); //330:24
            __out.AppendLine(true); //331:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //332:1
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
            string __tmp5_line = ".Metadata"; //332:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //332:42
            }
            __out.Write("{"); //333:1
            __out.AppendLine(false); //333:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Metadata"; //334:1
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
            if (symbol.ExistingMetadataTypeInfo.BaseType == null) //334:45
            {
                string __tmp11_line = " : "; //334:99
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
                string __tmp13_line = ".Completion.Completion"; //334:124
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
                __out.AppendLine(false); //334:167
            }
            __out.Write("	{"); //335:1
            __out.AppendLine(false); //335:3
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //336:10
            {
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //337:10
                {
                    bool __tmp17_outputWritten = false;
                    string __tmp18_line = "        public Metadata"; //338:1
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
                    string __tmp20_line = "(Symbol container"; //338:37
                    if (!string.IsNullOrEmpty(__tmp20_line))
                    {
                        __out.Write(__tmp20_line);
                        __tmp17_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //338:55
                    {
                        string __tmp22_line = ", object? modelObject"; //338:112
                        if (!string.IsNullOrEmpty(__tmp22_line))
                        {
                            __out.Write(__tmp22_line);
                            __tmp17_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //338:134
                        {
                            string __tmp24_line = " = null"; //338:191
                            if (!string.IsNullOrEmpty(__tmp24_line))
                            {
                                __out.Write(__tmp24_line);
                                __tmp17_outputWritten = true;
                            }
                        }
                    }
                    string __tmp27_line = ", bool isError = false)"; //338:214
                    if (!string.IsNullOrEmpty(__tmp27_line))
                    {
                        __out.Write(__tmp27_line);
                        __tmp17_outputWritten = true;
                    }
                    if (__tmp17_outputWritten) __out.AppendLine(true);
                    if (__tmp17_outputWritten)
                    {
                        __out.AppendLine(false); //338:237
                    }
                    __out.Write("            : base(container"); //339:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //339:30
                    {
                        __out.Write(", modelObject"); //339:87
                    }
                    __out.Write(", isError)"); //339:108
                    __out.AppendLine(false); //339:118
                    __out.Write("        {"); //340:1
                    __out.AppendLine(false); //340:10
                    __out.Write("        }"); //341:1
                    __out.AppendLine(false); //341:10
                }
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains("Locations")) //343:10
                {
                    __out.AppendLine(true); //344:1
                    __out.Write("        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;"); //345:1
                    __out.AppendLine(false); //345:95
                }
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains("DeclaringSyntaxReferences")) //347:10
                {
                    __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;"); //348:1
                    __out.AppendLine(false); //348:124
                }
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteSymbolProperty_Name")) //351:10
            {
                __out.AppendLine(true); //352:1
                __out.Write("        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //353:1
                __out.AppendLine(false); //353:126
                __out.Write("        {"); //354:1
                __out.AppendLine(false); //354:10
                __out.Write("            return MetadataSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //355:1
                __out.AppendLine(false); //355:135
                __out.Write("        }"); //356:1
                __out.AppendLine(false); //356:10
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteInitializingSymbol")) //358:10
            {
                __out.AppendLine(true); //359:1
                __out.Write("        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //360:1
                __out.AppendLine(false); //360:123
                __out.Write("        {"); //361:1
                __out.AppendLine(false); //361:10
                __out.Write("        }"); //362:1
                __out.AppendLine(false); //362:10
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteCreatingChildSymbols")) //364:10
            {
                __out.AppendLine(true); //365:1
                __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //366:1
                __out.AppendLine(false); //366:143
                __out.Write("        {"); //367:1
                __out.AppendLine(false); //367:10
                __out.Write("            return MetadataSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //368:1
                __out.AppendLine(false); //368:126
                __out.Write("        }"); //369:1
                __out.AppendLine(false); //369:10
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteImports")) //371:10
            {
                __out.AppendLine(true); //372:1
                __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //373:1
                __out.AppendLine(false); //373:140
                __out.Write("        {"); //374:1
                __out.AppendLine(false); //374:10
                __out.Write("        }"); //375:1
                __out.AppendLine(false); //375:10
            }
            var __loop9_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //377:16
                where part.GenerateCompleteMethod //377:44
                select new { part = part}
                ).ToList(); //377:10
            for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
            {
                var __tmp28 = __loop9_results[__loop9_iteration];
                var part = __tmp28.part;
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains(part.CompleteMethodName)) //378:14
                {
                    __out.AppendLine(true); //379:1
                    bool __tmp30_outputWritten = false;
                    string __tmp31_line = "        protected override "; //380:1
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
                    string __tmp33_line = " "; //380:59
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
                    string __tmp35_line = "("; //380:85
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
                    string __tmp37_line = ")"; //380:116
                    if (!string.IsNullOrEmpty(__tmp37_line))
                    {
                        __out.Write(__tmp37_line);
                        __tmp30_outputWritten = true;
                    }
                    if (__tmp30_outputWritten) __out.AppendLine(true);
                    if (__tmp30_outputWritten)
                    {
                        __out.AppendLine(false); //380:117
                    }
                    __out.Write("        {"); //381:1
                    __out.AppendLine(false); //381:10
                    if (part is SymbolPropertyGenerationInfo) //382:14
                    {
                        var prop = (SymbolPropertyGenerationInfo)part; //383:18
                        if (prop.IsCollection) //384:18
                        {
                            bool __tmp39_outputWritten = false;
                            string __tmp40_line = "            return MetadataSymbolImplementation.AssignSymbolPropertyValues<"; //385:1
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
                            string __tmp42_line = ">(this, nameof("; //385:91
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
                            string __tmp44_line = "), diagnostics, cancellationToken);"; //385:117
                            if (!string.IsNullOrEmpty(__tmp44_line))
                            {
                                __out.Write(__tmp44_line);
                                __tmp39_outputWritten = true;
                            }
                            if (__tmp39_outputWritten) __out.AppendLine(true);
                            if (__tmp39_outputWritten)
                            {
                                __out.AppendLine(false); //385:152
                            }
                        }
                        else //386:18
                        {
                            bool __tmp46_outputWritten = false;
                            string __tmp47_line = "            return MetadataSymbolImplementation.AssignSymbolPropertyValue<"; //387:1
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
                            string __tmp49_line = ">(this, nameof("; //387:86
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
                            string __tmp51_line = "), diagnostics, cancellationToken);"; //387:112
                            if (!string.IsNullOrEmpty(__tmp51_line))
                            {
                                __out.Write(__tmp51_line);
                                __tmp46_outputWritten = true;
                            }
                            if (__tmp46_outputWritten) __out.AppendLine(true);
                            if (__tmp46_outputWritten)
                            {
                                __out.AppendLine(false); //387:147
                            }
                        }
                    }
                    __out.Write("        }"); //390:1
                    __out.AppendLine(false); //390:10
                }
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteNonSymbolProperties")) //393:10
            {
                __out.AppendLine(true); //394:1
                __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //395:1
                __out.AppendLine(false); //395:152
                __out.Write("        {"); //396:1
                __out.AppendLine(false); //396:10
                __out.Write("        }"); //397:1
                __out.AppendLine(false); //397:10
            }
            __out.AppendLine(true); //399:1
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //400:10
            {
                bool __tmp53_outputWritten = false;
                string __tmp54_line = "        public partial class Error : Metadata"; //401:1
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
                string __tmp56_line = ", MetaDslx.CodeAnalysis.Symbols.IErrorSymbol"; //401:59
                if (!string.IsNullOrEmpty(__tmp56_line))
                {
                    __out.Write(__tmp56_line);
                    __tmp53_outputWritten = true;
                }
                if (__tmp53_outputWritten) __out.AppendLine(true);
                if (__tmp53_outputWritten)
                {
                    __out.AppendLine(false); //401:103
                }
                __out.Write("        {"); //402:1
                __out.AppendLine(false); //402:10
                __out.Write("            private readonly string _name;"); //403:1
                __out.AppendLine(false); //403:43
                __out.Write("            private readonly string _metadataName;"); //404:1
                __out.AppendLine(false); //404:51
                __out.Write("            private DiagnosticInfo _errorInfo;"); //405:1
                __out.AppendLine(false); //405:47
                __out.Write("            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorKind _kind;"); //406:1
                __out.AppendLine(false); //406:76
                __out.Write("            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags _flags;"); //407:1
                __out.AppendLine(false); //407:84
                __out.Write("            private ImmutableArray<Symbol> _candidateSymbols;"); //408:1
                __out.AppendLine(false); //408:62
                __out.AppendLine(true); //409:1
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //410:14
                {
                    __out.Write("            private Error(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags"); //411:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //411:246
                    {
                        __out.Write(", object? modelObject"); //411:303
                    }
                    __out.Write(")"); //411:332
                    __out.AppendLine(false); //411:333
                    __out.Write("                : base(container"); //412:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //412:34
                    {
                        __out.Write(", modelObject"); //412:91
                    }
                    __out.Write(", true)"); //412:112
                    __out.AppendLine(false); //412:119
                    __out.Write("            {"); //413:1
                    __out.AppendLine(false); //413:14
                    __out.Write("                Debug.Assert(!flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported) || errorInfo != null);"); //414:1
                    __out.AppendLine(false); //414:126
                    __out.Write("                _name = name;"); //415:1
                    __out.AppendLine(false); //415:30
                    __out.Write("                _metadataName = metadataName;"); //416:1
                    __out.AppendLine(false); //416:46
                    __out.Write("                _kind = kind;"); //417:1
                    __out.AppendLine(false); //417:30
                    __out.Write("                _errorInfo = errorInfo;"); //418:1
                    __out.AppendLine(false); //418:40
                    __out.Write("                _candidateSymbols = candidateSymbols;"); //419:1
                    __out.AppendLine(false); //419:54
                    __out.Write("                _flags = flags;"); //420:1
                    __out.AppendLine(false); //420:32
                    __out.Write("            }"); //421:1
                    __out.AppendLine(false); //421:14
                    __out.Write("            public Error(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported"); //423:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //423:208
                    {
                        __out.Write(", object? modelObject"); //423:265
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //423:287
                        {
                            __out.Write(" = null"); //423:344
                        }
                    }
                    __out.Write(")"); //423:367
                    __out.AppendLine(false); //423:368
                    __out.Write("                : this(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.None"); //424:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //424:215
                    {
                        __out.Write(", modelObject"); //424:272
                    }
                    __out.Write(")"); //424:293
                    __out.AppendLine(false); //424:294
                    __out.Write("            {"); //425:1
                    __out.AppendLine(false); //425:14
                    __out.Write("            }"); //426:1
                    __out.AppendLine(false); //426:14
                    __out.Write("            public Error(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported"); //428:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //428:137
                    {
                        __out.Write(", object? modelObject"); //428:194
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //428:216
                        {
                            __out.Write(" = null"); //428:273
                        }
                    }
                    __out.Write(")"); //428:296
                    __out.AppendLine(false); //428:297
                    __out.Write("                : this(wrappedSymbol.ContainingSymbol, wrappedSymbol.Name, wrappedSymbol.MetadataName, kind, errorInfo, ImmutableArray.Create<Symbol>(wrappedSymbol), unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.UnreportedWrapped : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Wrapped"); //429:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //429:302
                    {
                        __out.Write(", modelObject is not null ? modelObject : (wrappedSymbol as IModelSymbol)?.ModelObject"); //429:359
                    }
                    __out.Write(")"); //429:453
                    __out.AppendLine(false); //429:454
                    __out.Write("            {"); //430:1
                    __out.AppendLine(false); //430:14
                    __out.Write("            }"); //431:1
                    __out.AppendLine(false); //431:14
                    __out.AppendLine(true); //432:1
                    __out.Write("            protected virtual Error Update(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags"); //433:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //433:263
                    {
                        __out.Write(", object? modelObject"); //433:320
                    }
                    __out.Write(")"); //433:349
                    __out.AppendLine(false); //433:350
                    __out.Write("            {"); //434:1
                    __out.AppendLine(false); //434:14
                    __out.Write("                return new Error(container, name, metadataName, kind, errorInfo, candidateSymbols, flags"); //435:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //435:106
                    {
                        __out.Write(", modelObject"); //435:163
                    }
                    __out.Write(");"); //435:184
                    __out.AppendLine(false); //435:186
                    __out.Write("            }"); //436:1
                    __out.AppendLine(false); //436:14
                }
                __out.AppendLine(true); //438:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsUnreported(DiagnosticInfo? errorInfo = null)"); //439:1
                __out.AppendLine(false); //439:103
                __out.Write("            {"); //440:1
                __out.AppendLine(false); //440:14
                __out.Write("                return this.IsUnreported ? this :"); //441:1
                __out.AppendLine(false); //441:50
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, _kind, errorInfo is null ? ErrorInfo : errorInfo, CandidateSymbols, _flags | MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported"); //442:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //442:208
                {
                    __out.Write(", this.ModelObject"); //442:265
                }
                __out.Write(");"); //442:291
                __out.AppendLine(false); //442:293
                __out.Write("            }"); //443:1
                __out.AppendLine(false); //443:14
                __out.AppendLine(true); //444:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsReported(DiagnosticInfo? errorInfo = null)"); //445:1
                __out.AppendLine(false); //445:101
                __out.Write("            {"); //446:1
                __out.AppendLine(false); //446:14
                __out.Write("                return this.IsUnreported ? this :"); //447:1
                __out.AppendLine(false); //447:50
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, _kind, errorInfo is null ? ErrorInfo : errorInfo, CandidateSymbols, _flags & ~MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported"); //448:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //448:209
                {
                    __out.Write(", this.ModelObject"); //448:266
                }
                __out.Write(");"); //448:292
                __out.AppendLine(false); //448:294
                __out.Write("            }"); //449:1
                __out.AppendLine(false); //449:14
                __out.AppendLine(true); //450:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind)"); //451:1
                __out.AppendLine(false); //451:109
                __out.Write("            {"); //452:1
                __out.AppendLine(false); //452:14
                __out.Write("                return _kind == kind ? this :"); //453:1
                __out.AppendLine(false); //453:46
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, kind, ErrorInfo, CandidateSymbols, _flags"); //454:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //454:115
                {
                    __out.Write(", this.ModelObject"); //454:172
                }
                __out.Write(");"); //454:198
                __out.AppendLine(false); //454:200
                __out.Write("            }"); //455:1
                __out.AppendLine(false); //455:14
                __out.AppendLine(true); //456:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, ImmutableArray<MetaDslx.CodeAnalysis.Symbols.Symbol> candidateSymbols)"); //457:1
                __out.AppendLine(false); //457:180
                __out.Write("            {"); //458:1
                __out.AppendLine(false); //458:14
                __out.Write("                return _kind == kind && CandidateSymbols == candidateSymbols ? this :"); //459:1
                __out.AppendLine(false); //459:86
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, kind, ErrorInfo, candidateSymbols, _flags"); //460:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //460:115
                {
                    __out.Write(", this.ModelObject"); //460:172
                }
                __out.Write(");"); //460:198
                __out.AppendLine(false); //460:200
                __out.Write("            }"); //461:1
                __out.AppendLine(false); //461:14
                __out.AppendLine(true); //462:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo errorInfo, ImmutableArray<MetaDslx.CodeAnalysis.Symbols.Symbol> candidateSymbols)"); //463:1
                __out.AppendLine(false); //463:206
                __out.Write("            {"); //464:1
                __out.AppendLine(false); //464:14
                __out.Write("                return _kind == kind && ErrorInfo == errorInfo && CandidateSymbols == candidateSymbols ? this :"); //465:1
                __out.AppendLine(false); //465:112
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, kind, errorInfo, candidateSymbols, _flags"); //466:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //466:115
                {
                    __out.Write(", this.ModelObject"); //466:172
                }
                __out.Write(");"); //466:198
                __out.AppendLine(false); //466:200
                __out.Write("            }"); //467:1
                __out.AppendLine(false); //467:14
                __out.AppendLine(true); //468:1
                __out.Write("            public override string Name => _name;"); //469:1
                __out.AppendLine(false); //469:50
                __out.AppendLine(true); //470:1
                __out.Write("            public override string MetadataName => _metadataName;"); //471:1
                __out.AppendLine(false); //471:66
                __out.AppendLine(true); //472:1
                __out.Write("            public sealed override bool IsError => true;"); //473:1
                __out.AppendLine(false); //473:57
                __out.AppendLine(true); //474:1
                __out.Write("            public bool IsUnreported => _flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported);"); //475:1
                __out.AppendLine(false); //475:115
                __out.AppendLine(true); //476:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.ErrorKind ErrorKind => _kind;"); //477:1
                __out.AppendLine(false); //477:79
                __out.AppendLine(true); //478:1
                __out.Write("            public ImmutableArray<Symbol> CandidateSymbols"); //479:1
                __out.AppendLine(false); //479:59
                __out.Write("            {"); //480:1
                __out.AppendLine(false); //480:14
                __out.Write("                get"); //481:1
                __out.AppendLine(false); //481:20
                __out.Write("                {"); //482:1
                __out.AppendLine(false); //482:18
                __out.Write("                    if (_candidateSymbols.IsDefault)"); //483:1
                __out.AppendLine(false); //483:53
                __out.Write("                    {"); //484:1
                __out.AppendLine(false); //484:22
                __out.Write("                        System.Collections.Immutable.ImmutableInterlocked.InterlockedInitialize(ref _candidateSymbols, MakeCandidateSymbols());"); //485:1
                __out.AppendLine(false); //485:144
                __out.Write("                    }"); //486:1
                __out.AppendLine(false); //486:22
                __out.Write("                    return _candidateSymbols;"); //487:1
                __out.AppendLine(false); //487:46
                __out.Write("                }"); //488:1
                __out.AppendLine(false); //488:18
                __out.Write("            }"); //489:1
                __out.AppendLine(false); //489:14
                __out.AppendLine(true); //490:1
                __out.Write("            public DiagnosticInfo? ErrorInfo"); //491:1
                __out.AppendLine(false); //491:45
                __out.Write("            {"); //492:1
                __out.AppendLine(false); //492:14
                __out.Write("                get"); //493:1
                __out.AppendLine(false); //493:20
                __out.Write("                {"); //494:1
                __out.AppendLine(false); //494:18
                __out.Write("                    if (_errorInfo is null)"); //495:1
                __out.AppendLine(false); //495:44
                __out.Write("                    {"); //496:1
                __out.AppendLine(false); //496:22
                __out.Write("                        System.Threading.Interlocked.CompareExchange(ref _errorInfo, MakeErrorInfo(), null);"); //497:1
                __out.AppendLine(false); //497:109
                __out.Write("                    }"); //498:1
                __out.AppendLine(false); //498:22
                __out.Write("                    return _errorInfo;"); //499:1
                __out.AppendLine(false); //499:39
                __out.Write("                }"); //500:1
                __out.AppendLine(false); //500:18
                __out.Write("            }"); //501:1
                __out.AppendLine(false); //501:14
                __out.AppendLine(true); //502:1
                __out.Write("            protected virtual DiagnosticInfo? MakeErrorInfo()"); //503:1
                __out.AppendLine(false); //503:62
                __out.Write("            {"); //504:1
                __out.AppendLine(false); //504:14
                __out.Write("                return ErrorSymbolImplementation.MakeErrorInfo(this);"); //505:1
                __out.AppendLine(false); //505:70
                __out.Write("            }"); //506:1
                __out.AppendLine(false); //506:14
                __out.AppendLine(true); //507:1
                __out.Write("            protected virtual ImmutableArray<Symbol> MakeCandidateSymbols()"); //508:1
                __out.AppendLine(false); //508:76
                __out.Write("            {"); //509:1
                __out.AppendLine(false); //509:14
                __out.Write("                return ErrorSymbolImplementation.MakeCandidateSymbols(this);"); //510:1
                __out.AppendLine(false); //510:77
                __out.Write("            }"); //511:1
                __out.AppendLine(false); //511:14
                __out.AppendLine(true); //512:1
                __out.Write("            protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //513:1
                __out.AppendLine(false); //513:130
                __out.Write("            {"); //514:1
                __out.AppendLine(false); //514:14
                __out.Write("                return _name;"); //515:1
                __out.AppendLine(false); //515:30
                __out.Write("            }"); //516:1
                __out.AppendLine(false); //516:14
                __out.Write("        }"); //517:1
                __out.AppendLine(false); //517:10
            }
            __out.Write("    }"); //519:1
            __out.AppendLine(false); //519:6
            __out.Write("}"); //520:1
            __out.AppendLine(false); //520:2
            return __out.ToStringAndFree();
        }

        public string GenerateSourceSymbol(SymbolGenerationInfo symbol) //523:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //524:1
            __out.AppendLine(false); //524:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //525:1
            __out.AppendLine(false); //525:29
            __out.Write("using MetaDslx.CodeAnalysis.Binding;"); //526:1
            __out.AppendLine(false); //526:37
            __out.Write("using MetaDslx.CodeAnalysis.Binding.Binders;"); //527:1
            __out.AppendLine(false); //527:45
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //528:1
            __out.AppendLine(false); //528:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //529:1
            __out.AppendLine(false); //529:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //530:1
            __out.AppendLine(false); //530:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //531:1
            __out.AppendLine(false); //531:44
            __out.Write("using System;"); //532:1
            __out.AppendLine(false); //532:14
            __out.Write("using System.Collections.Generic;"); //533:1
            __out.AppendLine(false); //533:34
            __out.Write("using System.Collections.Immutable;"); //534:1
            __out.AppendLine(false); //534:36
            __out.Write("using System.Diagnostics;"); //535:1
            __out.AppendLine(false); //535:26
            __out.Write("using System.Linq;"); //536:1
            __out.AppendLine(false); //536:19
            __out.Write("using System.Text;"); //537:1
            __out.AppendLine(false); //537:19
            __out.Write("using System.Threading;"); //538:1
            __out.AppendLine(false); //538:24
            __out.AppendLine(true); //539:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //540:1
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
            string __tmp5_line = ".Source"; //540:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //540:40
            }
            __out.Write("{"); //541:1
            __out.AppendLine(false); //541:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Source"; //542:1
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
            if (symbol.ExistingSourceTypeInfo.BaseType == null) //542:43
            {
                string __tmp11_line = " : "; //542:95
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
                string __tmp13_line = ".Completion.Completion"; //542:120
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
                if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //542:156
                {
                    string __tmp16_line = ", MetaDslx.CodeAnalysis.Symbols.Source.ISourceSymbol"; //542:226
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
                __out.AppendLine(false); //542:294
            }
            __out.Write("	{"); //543:1
            __out.AppendLine(false); //543:3
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //544:10
            {
                __out.Write("        private readonly MergedDeclaration _declaration;"); //545:1
                __out.AppendLine(false); //545:57
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetLexicalSortKey")) //546:10
                {
                    __out.Write("        private LexicalSortKey _lazyLexicalSortKey = LexicalSortKey.NotInitialized;"); //547:1
                    __out.AppendLine(false); //547:84
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //549:10
                {
                    __out.AppendLine(true); //550:1
                    bool __tmp20_outputWritten = false;
                    string __tmp21_line = "		public Source"; //551:1
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
                    string __tmp23_line = "(Symbol containingSymbol, MergedDeclaration declaration"; //551:29
                    if (!string.IsNullOrEmpty(__tmp23_line))
                    {
                        __out.Write(__tmp23_line);
                        __tmp20_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //551:85
                    {
                        string __tmp25_line = ", object? modelObject"; //551:142
                        if (!string.IsNullOrEmpty(__tmp25_line))
                        {
                            __out.Write(__tmp25_line);
                            __tmp20_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //551:164
                        {
                            string __tmp27_line = " = null"; //551:221
                            if (!string.IsNullOrEmpty(__tmp27_line))
                            {
                                __out.Write(__tmp27_line);
                                __tmp20_outputWritten = true;
                            }
                        }
                    }
                    string __tmp30_line = ", bool isError = false)"; //551:244
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Write(__tmp30_line);
                        __tmp20_outputWritten = true;
                    }
                    if (__tmp20_outputWritten) __out.AppendLine(true);
                    if (__tmp20_outputWritten)
                    {
                        __out.AppendLine(false); //551:267
                    }
                    __out.Write("            : base(containingSymbol"); //552:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //552:37
                    {
                        __out.Write(", modelObject"); //552:94
                    }
                    __out.Write(", isError)"); //552:115
                    __out.AppendLine(false); //552:125
                    __out.Write("        {"); //553:1
                    __out.AppendLine(false); //553:10
                    __out.Write("            if (declaration is null) throw new ArgumentNullException(nameof(declaration));"); //554:1
                    __out.AppendLine(false); //554:91
                    __out.Write("            _declaration = declaration;"); //555:1
                    __out.AppendLine(false); //555:40
                    __out.Write("		}"); //556:1
                    __out.AppendLine(false); //556:4
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("MergedDeclaration")) //558:10
                {
                    __out.AppendLine(true); //559:1
                    __out.Write("        public MergedDeclaration MergedDeclaration => _declaration;"); //560:1
                    __out.AppendLine(false); //560:68
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("Locations")) //562:10
                {
                    __out.AppendLine(true); //563:1
                    __out.Write("        public override ImmutableArray<Location> Locations => _declaration.NameLocations;"); //564:1
                    __out.AppendLine(false); //564:90
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("DeclaringSyntaxReferences")) //566:10
                {
                    __out.AppendLine(true); //567:1
                    __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration.SyntaxReferences;"); //568:1
                    __out.AppendLine(false); //568:116
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetBinder")) //570:10
                {
                    __out.AppendLine(true); //571:1
                    __out.Write("        public BinderPosition<SymbolBinder> GetBinder(SyntaxReference reference)"); //572:1
                    __out.AppendLine(false); //572:81
                    __out.Write("        {"); //573:1
                    __out.AppendLine(false); //573:10
                    __out.Write("            Debug.Assert(this.DeclaringSyntaxReferences.Contains(reference));"); //574:1
                    __out.AppendLine(false); //574:78
                    __out.Write("            return FindBinders.FindSymbolBinder(this, reference);"); //575:1
                    __out.AppendLine(false); //575:66
                    __out.Write("        }"); //576:1
                    __out.AppendLine(false); //576:10
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetChildSymbol")) //578:10
                {
                    __out.AppendLine(true); //579:1
                    __out.Write("        public Symbol GetChildSymbol(SyntaxReference syntax)"); //580:1
                    __out.AppendLine(false); //580:61
                    __out.Write("        {"); //581:1
                    __out.AppendLine(false); //581:10
                    __out.Write("            foreach (var child in this.ChildSymbols)"); //582:1
                    __out.AppendLine(false); //582:53
                    __out.Write("            {"); //583:1
                    __out.AppendLine(false); //583:14
                    __out.Write("                if (child.DeclaringSyntaxReferences.Any(sr => sr.GetLocation() == syntax.GetLocation()))"); //584:1
                    __out.AppendLine(false); //584:105
                    __out.Write("                {"); //585:1
                    __out.AppendLine(false); //585:18
                    __out.Write("                    return child;"); //586:1
                    __out.AppendLine(false); //586:34
                    __out.Write("                }"); //587:1
                    __out.AppendLine(false); //587:18
                    __out.Write("            }"); //588:1
                    __out.AppendLine(false); //588:14
                    __out.Write("            return null;"); //589:1
                    __out.AppendLine(false); //589:25
                    __out.Write("        }"); //590:1
                    __out.AppendLine(false); //590:10
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetLexicalSortKey")) //592:10
                {
                    __out.Write("        public override LexicalSortKey GetLexicalSortKey()"); //593:1
                    __out.AppendLine(false); //593:59
                    __out.Write("        {"); //594:1
                    __out.AppendLine(false); //594:10
                    __out.Write("            if (!_lazyLexicalSortKey.IsInitialized)"); //595:1
                    __out.AppendLine(false); //595:52
                    __out.Write("            {"); //596:1
                    __out.AppendLine(false); //596:14
                    __out.Write("                _lazyLexicalSortKey.SetFrom(this.MergedDeclaration.GetLexicalSortKey(this.DeclaringCompilation));"); //597:1
                    __out.AppendLine(false); //597:114
                    __out.Write("            }"); //598:1
                    __out.AppendLine(false); //598:14
                    __out.Write("            return _lazyLexicalSortKey;"); //599:1
                    __out.AppendLine(false); //599:40
                    __out.Write("        }"); //600:1
                    __out.AppendLine(false); //600:10
                }
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteInitializingSymbol")) //603:10
            {
                __out.AppendLine(true); //604:1
                __out.Write("        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //605:1
                __out.AppendLine(false); //605:123
                __out.Write("        {"); //606:1
                __out.AppendLine(false); //606:10
                __out.Write("        }"); //607:1
                __out.AppendLine(false); //607:10
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteCreatingChildSymbols")) //609:10
            {
                __out.AppendLine(true); //610:1
                __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //611:1
                __out.AppendLine(false); //611:143
                __out.Write("        {"); //612:1
                __out.AppendLine(false); //612:10
                __out.Write("            return SourceSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //613:1
                __out.AppendLine(false); //613:124
                __out.Write("        }"); //614:1
                __out.AppendLine(false); //614:10
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteImports")) //616:10
            {
                __out.AppendLine(true); //617:1
                __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //618:1
                __out.AppendLine(false); //618:140
                __out.Write("        {"); //619:1
                __out.AppendLine(false); //619:10
                __out.Write("            SourceSymbolImplementation.CompleteImports(this, locationOpt, diagnostics, cancellationToken);"); //620:1
                __out.AppendLine(false); //620:107
                __out.Write("        }"); //621:1
                __out.AppendLine(false); //621:10
                __out.AppendLine(true); //622:1
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteSymbolProperty_Name")) //624:10
            {
                __out.Write("        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //625:1
                __out.AppendLine(false); //625:126
                __out.Write("        {"); //626:1
                __out.AppendLine(false); //626:10
                __out.Write("            return SourceSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //627:1
                __out.AppendLine(false); //627:133
                __out.Write("        }"); //628:1
                __out.AppendLine(false); //628:10
            }
            __out.AppendLine(true); //630:1
            var __loop10_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //631:16
                where part.GenerateCompleteMethod //631:44
                select new { part = part}
                ).ToList(); //631:10
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                var __tmp31 = __loop10_results[__loop10_iteration];
                var part = __tmp31.part;
                if (!symbol.ExistingSourceTypeInfo.Members.Contains(part.CompleteMethodName)) //632:14
                {
                    bool __tmp33_outputWritten = false;
                    string __tmp34_line = "        protected override "; //633:1
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
                    string __tmp36_line = " "; //633:59
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
                    string __tmp38_line = "("; //633:85
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
                    string __tmp40_line = ")"; //633:116
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Write(__tmp40_line);
                        __tmp33_outputWritten = true;
                    }
                    if (__tmp33_outputWritten) __out.AppendLine(true);
                    if (__tmp33_outputWritten)
                    {
                        __out.AppendLine(false); //633:117
                    }
                    __out.Write("        {"); //634:1
                    __out.AppendLine(false); //634:10
                    if (part is SymbolPropertyGenerationInfo) //635:14
                    {
                        var prop = (SymbolPropertyGenerationInfo)part; //636:18
                        if (prop.IsCollection) //637:18
                        {
                            bool __tmp42_outputWritten = false;
                            string __tmp43_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValues<"; //638:1
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
                            string __tmp45_line = ">(this, nameof("; //638:89
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
                            string __tmp47_line = "), diagnostics, cancellationToken);"; //638:115
                            if (!string.IsNullOrEmpty(__tmp47_line))
                            {
                                __out.Write(__tmp47_line);
                                __tmp42_outputWritten = true;
                            }
                            if (__tmp42_outputWritten) __out.AppendLine(true);
                            if (__tmp42_outputWritten)
                            {
                                __out.AppendLine(false); //638:150
                            }
                        }
                        else //639:18
                        {
                            bool __tmp49_outputWritten = false;
                            string __tmp50_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValue<"; //640:1
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
                            string __tmp52_line = ">(this, nameof("; //640:84
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
                            string __tmp54_line = "), diagnostics, cancellationToken);"; //640:110
                            if (!string.IsNullOrEmpty(__tmp54_line))
                            {
                                __out.Write(__tmp54_line);
                                __tmp49_outputWritten = true;
                            }
                            if (__tmp49_outputWritten) __out.AppendLine(true);
                            if (__tmp49_outputWritten)
                            {
                                __out.AppendLine(false); //640:145
                            }
                        }
                    }
                    __out.Write("        }"); //643:1
                    __out.AppendLine(false); //643:10
                }
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteNonSymbolProperties")) //646:10
            {
                __out.AppendLine(true); //647:1
                __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //648:1
                __out.AppendLine(false); //648:152
                __out.Write("        {"); //649:1
                __out.AppendLine(false); //649:10
                __out.Write("            SourceSymbolImplementation.AssignNonSymbolProperties(this, diagnostics, cancellationToken);"); //650:1
                __out.AppendLine(false); //650:104
                __out.Write("        }"); //651:1
                __out.AppendLine(false); //651:10
            }
            __out.AppendLine(true); //653:1
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //654:10
            {
                bool __tmp56_outputWritten = false;
                string __tmp57_line = "        public partial class Error : Source"; //655:1
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
                string __tmp59_line = ", MetaDslx.CodeAnalysis.Symbols.IErrorSymbol"; //655:57
                if (!string.IsNullOrEmpty(__tmp59_line))
                {
                    __out.Write(__tmp59_line);
                    __tmp56_outputWritten = true;
                }
                if (__tmp56_outputWritten) __out.AppendLine(true);
                if (__tmp56_outputWritten)
                {
                    __out.AppendLine(false); //655:101
                }
                __out.Write("        {"); //656:1
                __out.AppendLine(false); //656:10
                __out.Write("            private readonly string _name;"); //657:1
                __out.AppendLine(false); //657:43
                __out.Write("            private readonly string _metadataName;"); //658:1
                __out.AppendLine(false); //658:51
                __out.Write("            private DiagnosticInfo _errorInfo;"); //659:1
                __out.AppendLine(false); //659:47
                __out.Write("            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorKind _kind;"); //660:1
                __out.AppendLine(false); //660:76
                __out.Write("            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags _flags;"); //661:1
                __out.AppendLine(false); //661:84
                __out.Write("            private ImmutableArray<Symbol> _candidateSymbols;"); //662:1
                __out.AppendLine(false); //662:62
                __out.AppendLine(true); //663:1
                if (!symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //664:14
                {
                    __out.Write("            private Error(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags"); //665:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //665:243
                    {
                        __out.Write(", object? modelObject"); //665:300
                    }
                    __out.Write(")"); //665:329
                    __out.AppendLine(false); //665:330
                    __out.Write("                : base(container, declaration"); //666:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //666:47
                    {
                        __out.Write(", modelObject"); //666:104
                    }
                    __out.Write(", true)"); //666:125
                    __out.AppendLine(false); //666:132
                    __out.Write("            {"); //667:1
                    __out.AppendLine(false); //667:14
                    __out.Write("                Debug.Assert(!flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported) || errorInfo != null);"); //668:1
                    __out.AppendLine(false); //668:126
                    __out.Write("                _name = declaration.Name;"); //669:1
                    __out.AppendLine(false); //669:42
                    __out.Write("                _metadataName = declaration.MetadataName;"); //670:1
                    __out.AppendLine(false); //670:58
                    __out.Write("                _kind = kind;"); //671:1
                    __out.AppendLine(false); //671:30
                    __out.Write("                _errorInfo = errorInfo;"); //672:1
                    __out.AppendLine(false); //672:40
                    __out.Write("                _candidateSymbols = candidateSymbols;"); //673:1
                    __out.AppendLine(false); //673:54
                    __out.Write("                _flags = flags;"); //674:1
                    __out.AppendLine(false); //674:32
                    __out.Write("            }"); //675:1
                    __out.AppendLine(false); //675:14
                    __out.Write("            public Error(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported"); //677:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //677:205
                    {
                        __out.Write(", object? modelObject"); //677:262
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //677:284
                        {
                            __out.Write(" = null"); //677:341
                        }
                    }
                    __out.Write(")"); //677:364
                    __out.AppendLine(false); //677:365
                    __out.Write("                : this(container, declaration, kind, errorInfo, candidateSymbols, unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.None"); //678:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //678:208
                    {
                        __out.Write(", modelObject"); //678:265
                    }
                    __out.Write(")"); //678:286
                    __out.AppendLine(false); //678:287
                    __out.Write("            {"); //679:1
                    __out.AppendLine(false); //679:14
                    __out.Write("            }"); //680:1
                    __out.AppendLine(false); //680:14
                    __out.Write("            public Error(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported"); //682:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //682:137
                    {
                        __out.Write(", object? modelObject"); //682:194
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //682:216
                        {
                            __out.Write(" = null"); //682:273
                        }
                    }
                    __out.Write(")"); //682:296
                    __out.AppendLine(false); //682:297
                    __out.Write("                : this(wrappedSymbol.ContainingSymbol, (wrappedSymbol as ISourceSymbol).MergedDeclaration, kind, errorInfo, ImmutableArray.Create<Symbol>(wrappedSymbol), unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.UnreportedWrapped : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Wrapped"); //683:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //683:306
                    {
                        __out.Write(", modelObject is not null ? modelObject :  (wrappedSymbol as IModelSymbol)?.ModelObject"); //683:363
                    }
                    __out.Write(")"); //683:458
                    __out.AppendLine(false); //683:459
                    __out.Write("            {"); //684:1
                    __out.AppendLine(false); //684:14
                    __out.Write("            }"); //685:1
                    __out.AppendLine(false); //685:14
                    __out.AppendLine(true); //686:1
                    __out.Write("            protected virtual Error Update(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags"); //687:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //687:260
                    {
                        __out.Write(", object? modelObject"); //687:317
                    }
                    __out.Write(")"); //687:346
                    __out.AppendLine(false); //687:347
                    __out.Write("            {"); //688:1
                    __out.AppendLine(false); //688:14
                    __out.Write("                return new Error(container, declaration, kind, errorInfo, candidateSymbols, flags"); //689:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //689:99
                    {
                        __out.Write(", modelObject"); //689:156
                    }
                    __out.Write(");"); //689:177
                    __out.AppendLine(false); //689:179
                    __out.Write("            }"); //690:1
                    __out.AppendLine(false); //690:14
                }
                __out.AppendLine(true); //692:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsReported(DiagnosticInfo? errorInfo = null)"); //693:1
                __out.AppendLine(false); //693:101
                __out.Write("            {"); //694:1
                __out.AppendLine(false); //694:14
                __out.Write("                return this.IsUnreported ? this :"); //695:1
                __out.AppendLine(false); //695:50
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, _kind, errorInfo is null ? ErrorInfo : errorInfo, CandidateSymbols, _flags & ~MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported"); //696:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //696:211
                {
                    __out.Write(", this.ModelObject"); //696:268
                }
                __out.Write(");"); //696:294
                __out.AppendLine(false); //696:296
                __out.Write("            }"); //697:1
                __out.AppendLine(false); //697:14
                __out.AppendLine(true); //698:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsUnreported(DiagnosticInfo? errorInfo = null)"); //699:1
                __out.AppendLine(false); //699:103
                __out.Write("            {"); //700:1
                __out.AppendLine(false); //700:14
                __out.Write("                return this.IsUnreported ? this :"); //701:1
                __out.AppendLine(false); //701:50
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, _kind, errorInfo is null ? ErrorInfo : errorInfo, CandidateSymbols, _flags | MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported"); //702:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //702:210
                {
                    __out.Write(", this.ModelObject"); //702:267
                }
                __out.Write(");"); //702:293
                __out.AppendLine(false); //702:295
                __out.Write("            }"); //703:1
                __out.AppendLine(false); //703:14
                __out.AppendLine(true); //704:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind)"); //705:1
                __out.AppendLine(false); //705:109
                __out.Write("            {"); //706:1
                __out.AppendLine(false); //706:14
                __out.Write("                return _kind == kind ? this :"); //707:1
                __out.AppendLine(false); //707:46
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, kind, ErrorInfo, CandidateSymbols, _flags"); //708:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //708:117
                {
                    __out.Write(", this.ModelObject"); //708:174
                }
                __out.Write(");"); //708:200
                __out.AppendLine(false); //708:202
                __out.Write("            }"); //709:1
                __out.AppendLine(false); //709:14
                __out.AppendLine(true); //710:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, ImmutableArray<MetaDslx.CodeAnalysis.Symbols.Symbol> candidateSymbols)"); //711:1
                __out.AppendLine(false); //711:180
                __out.Write("            {"); //712:1
                __out.AppendLine(false); //712:14
                __out.Write("                return _kind == kind && CandidateSymbols == candidateSymbols ? this :"); //713:1
                __out.AppendLine(false); //713:86
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, kind, ErrorInfo, candidateSymbols, _flags"); //714:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //714:117
                {
                    __out.Write(", this.ModelObject"); //714:174
                }
                __out.Write(");"); //714:200
                __out.AppendLine(false); //714:202
                __out.Write("            }"); //715:1
                __out.AppendLine(false); //715:14
                __out.AppendLine(true); //716:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo errorInfo, ImmutableArray<MetaDslx.CodeAnalysis.Symbols.Symbol> candidateSymbols)"); //717:1
                __out.AppendLine(false); //717:206
                __out.Write("            {"); //718:1
                __out.AppendLine(false); //718:14
                __out.Write("                return _kind == kind && ErrorInfo == errorInfo && CandidateSymbols == candidateSymbols ? this :"); //719:1
                __out.AppendLine(false); //719:112
                __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, kind, errorInfo, candidateSymbols, _flags"); //720:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //720:117
                {
                    __out.Write(", this.ModelObject"); //720:174
                }
                __out.Write(");"); //720:200
                __out.AppendLine(false); //720:202
                __out.Write("            }"); //721:1
                __out.AppendLine(false); //721:14
                __out.AppendLine(true); //722:1
                __out.Write("            public override string Name => _name;"); //723:1
                __out.AppendLine(false); //723:50
                __out.AppendLine(true); //724:1
                __out.Write("            public override string MetadataName => _metadataName;"); //725:1
                __out.AppendLine(false); //725:66
                __out.AppendLine(true); //726:1
                __out.Write("            public sealed override bool IsError => true;"); //727:1
                __out.AppendLine(false); //727:57
                __out.AppendLine(true); //728:1
                __out.Write("            public bool IsUnreported => _flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported);"); //729:1
                __out.AppendLine(false); //729:115
                __out.AppendLine(true); //730:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.ErrorKind ErrorKind => _kind;"); //731:1
                __out.AppendLine(false); //731:79
                __out.AppendLine(true); //732:1
                __out.Write("            public ImmutableArray<Symbol> CandidateSymbols"); //733:1
                __out.AppendLine(false); //733:59
                __out.Write("            {"); //734:1
                __out.AppendLine(false); //734:14
                __out.Write("                get"); //735:1
                __out.AppendLine(false); //735:20
                __out.Write("                {"); //736:1
                __out.AppendLine(false); //736:18
                __out.Write("                    if (_candidateSymbols.IsDefault)"); //737:1
                __out.AppendLine(false); //737:53
                __out.Write("                    {"); //738:1
                __out.AppendLine(false); //738:22
                __out.Write("                        System.Collections.Immutable.ImmutableInterlocked.InterlockedInitialize(ref _candidateSymbols, MakeCandidateSymbols());"); //739:1
                __out.AppendLine(false); //739:144
                __out.Write("                    }"); //740:1
                __out.AppendLine(false); //740:22
                __out.Write("                    return _candidateSymbols;"); //741:1
                __out.AppendLine(false); //741:46
                __out.Write("                }"); //742:1
                __out.AppendLine(false); //742:18
                __out.Write("            }"); //743:1
                __out.AppendLine(false); //743:14
                __out.AppendLine(true); //744:1
                __out.Write("            public DiagnosticInfo? ErrorInfo"); //745:1
                __out.AppendLine(false); //745:45
                __out.Write("            {"); //746:1
                __out.AppendLine(false); //746:14
                __out.Write("                get"); //747:1
                __out.AppendLine(false); //747:20
                __out.Write("                {"); //748:1
                __out.AppendLine(false); //748:18
                __out.Write("                    if (_errorInfo is null)"); //749:1
                __out.AppendLine(false); //749:44
                __out.Write("                    {"); //750:1
                __out.AppendLine(false); //750:22
                __out.Write("                        System.Threading.Interlocked.CompareExchange(ref _errorInfo, MakeErrorInfo(), null);"); //751:1
                __out.AppendLine(false); //751:109
                __out.Write("                    }"); //752:1
                __out.AppendLine(false); //752:22
                __out.Write("                    return _errorInfo;"); //753:1
                __out.AppendLine(false); //753:39
                __out.Write("                }"); //754:1
                __out.AppendLine(false); //754:18
                __out.Write("            }"); //755:1
                __out.AppendLine(false); //755:14
                __out.AppendLine(true); //756:1
                __out.Write("            public DiagnosticInfo? UseSiteDiagnosticInfo => IsUnreported ? ErrorInfo : null;"); //757:1
                __out.AppendLine(false); //757:93
                __out.AppendLine(true); //758:1
                __out.Write("            protected virtual DiagnosticInfo? MakeErrorInfo()"); //759:1
                __out.AppendLine(false); //759:62
                __out.Write("            {"); //760:1
                __out.AppendLine(false); //760:14
                __out.Write("                return null;"); //761:1
                __out.AppendLine(false); //761:29
                __out.Write("            }"); //762:1
                __out.AppendLine(false); //762:14
                __out.AppendLine(true); //763:1
                __out.Write("            protected virtual ImmutableArray<Symbol> MakeCandidateSymbols()"); //764:1
                __out.AppendLine(false); //764:76
                __out.Write("            {"); //765:1
                __out.AppendLine(false); //765:14
                __out.Write("                return ImmutableArray<Symbol>.Empty;"); //766:1
                __out.AppendLine(false); //766:53
                __out.Write("            }"); //767:1
                __out.AppendLine(false); //767:14
                __out.AppendLine(true); //768:1
                __out.Write("            protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //769:1
                __out.AppendLine(false); //769:130
                __out.Write("            {"); //770:1
                __out.AppendLine(false); //770:14
                __out.Write("                return _name;"); //771:1
                __out.AppendLine(false); //771:30
                __out.Write("            }"); //772:1
                __out.AppendLine(false); //772:14
                __out.Write("        }"); //773:1
                __out.AppendLine(false); //773:10
            }
            __out.Write("	}"); //775:1
            __out.AppendLine(false); //775:3
            __out.Write("}"); //776:1
            __out.AppendLine(false); //776:2
            return __out.ToStringAndFree();
        }

        public string GenerateVisitor(string namespaceName, IEnumerable<SymbolGenerationInfo> symbols) //779:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //780:1
            __out.AppendLine(false); //780:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //781:1
            __out.AppendLine(false); //781:29
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //782:1
            __out.AppendLine(false); //782:37
            __out.Write("using System;"); //783:1
            __out.AppendLine(false); //783:14
            __out.Write("using System.Collections.Generic;"); //784:1
            __out.AppendLine(false); //784:34
            __out.Write("using System.Collections.Immutable;"); //785:1
            __out.AppendLine(false); //785:36
            __out.Write("using System.Diagnostics;"); //786:1
            __out.AppendLine(false); //786:26
            __out.Write("using System.Text;"); //787:1
            __out.AppendLine(false); //787:19
            __out.Write("using System.Threading;"); //788:1
            __out.AppendLine(false); //788:24
            __out.AppendLine(true); //789:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //790:1
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
                __out.AppendLine(false); //790:26
            }
            __out.Write("{"); //791:1
            __out.AppendLine(false); //791:2
            __out.Write("	public interface ISymbolVisitor"); //792:1
            __out.AppendLine(false); //792:33
            __out.Write("	{"); //793:1
            __out.AppendLine(false); //793:3
            var __loop11_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //794:16
                select new { symbol = symbol}
                ).ToList(); //794:10
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp5 = __loop11_results[__loop11_iteration];
                var symbol = __tmp5.symbol;
                bool __tmp7_outputWritten = false;
                string __tmp8_line = "        void Visit("; //795:1
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
                string __tmp10_line = " symbol);"; //795:33
                if (!string.IsNullOrEmpty(__tmp10_line))
                {
                    __out.Write(__tmp10_line);
                    __tmp7_outputWritten = true;
                }
                if (__tmp7_outputWritten) __out.AppendLine(true);
                if (__tmp7_outputWritten)
                {
                    __out.AppendLine(false); //795:42
                }
            }
            __out.Write("	}"); //797:1
            __out.AppendLine(false); //797:3
            __out.AppendLine(true); //798:1
            __out.Write("	public interface ISymbolVisitor<TResult>"); //799:1
            __out.AppendLine(false); //799:42
            __out.Write("	{"); //800:1
            __out.AppendLine(false); //800:3
            var __loop12_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //801:16
                select new { symbol = symbol}
                ).ToList(); //801:10
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp11 = __loop12_results[__loop12_iteration];
                var symbol = __tmp11.symbol;
                bool __tmp13_outputWritten = false;
                string __tmp14_line = "        TResult Visit("; //802:1
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
                string __tmp16_line = " symbol);"; //802:36
                if (!string.IsNullOrEmpty(__tmp16_line))
                {
                    __out.Write(__tmp16_line);
                    __tmp13_outputWritten = true;
                }
                if (__tmp13_outputWritten) __out.AppendLine(true);
                if (__tmp13_outputWritten)
                {
                    __out.AppendLine(false); //802:45
                }
            }
            __out.Write("	}"); //804:1
            __out.AppendLine(false); //804:3
            __out.AppendLine(true); //805:1
            __out.Write("	public interface ISymbolVisitor<TArgument, TResult>"); //806:1
            __out.AppendLine(false); //806:53
            __out.Write("	{"); //807:1
            __out.AppendLine(false); //807:3
            var __loop13_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //808:16
                select new { symbol = symbol}
                ).ToList(); //808:10
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp17 = __loop13_results[__loop13_iteration];
                var symbol = __tmp17.symbol;
                bool __tmp19_outputWritten = false;
                string __tmp20_line = "        TResult Visit("; //809:1
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
                string __tmp22_line = " symbol, TArgument argument);"; //809:36
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Write(__tmp22_line);
                    __tmp19_outputWritten = true;
                }
                if (__tmp19_outputWritten) __out.AppendLine(true);
                if (__tmp19_outputWritten)
                {
                    __out.AppendLine(false); //809:65
                }
            }
            __out.Write("	}"); //811:1
            __out.AppendLine(false); //811:3
            __out.Write("}"); //812:1
            __out.AppendLine(false); //812:2
            return __out.ToStringAndFree();
        }

        public string GenerateFactory(string namespaceName, IEnumerable<SymbolGenerationInfo> symbols) //815:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //816:1
            __out.AppendLine(false); //816:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //817:1
            __out.AppendLine(false); //817:29
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //818:1
            __out.AppendLine(false); //818:37
            __out.Write("using System;"); //819:1
            __out.AppendLine(false); //819:14
            __out.Write("using System.Collections.Generic;"); //820:1
            __out.AppendLine(false); //820:34
            __out.Write("using System.Collections.Immutable;"); //821:1
            __out.AppendLine(false); //821:36
            __out.Write("using System.Diagnostics;"); //822:1
            __out.AppendLine(false); //822:26
            __out.Write("using System.Text;"); //823:1
            __out.AppendLine(false); //823:19
            __out.Write("using System.Threading;"); //824:1
            __out.AppendLine(false); //824:24
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //825:1
            __out.AppendLine(false); //825:42
            __out.AppendLine(true); //826:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //827:1
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
            string __tmp5_line = ".Factory"; //827:26
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //827:34
            }
            __out.Write("{"); //828:1
            __out.AppendLine(false); //828:2
            var __loop14_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //829:12
                where symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol" && symbol.SymbolParts != SymbolParts.None //829:28
                select new { symbol = symbol}
                ).ToList(); //829:6
            for (int __loop14_iteration = 0; __loop14_iteration < __loop14_results.Count; ++__loop14_iteration)
            {
                var __tmp6 = __loop14_results[__loop14_iteration];
                var symbol = __tmp6.symbol;
                bool __tmp8_outputWritten = false;
                string __tmp9_line = "	public class "; //830:1
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
                string __tmp11_line = "Factory : IGeneratedSymbolFactory"; //830:28
                if (!string.IsNullOrEmpty(__tmp11_line))
                {
                    __out.Write(__tmp11_line);
                    __tmp8_outputWritten = true;
                }
                if (__tmp8_outputWritten) __out.AppendLine(true);
                if (__tmp8_outputWritten)
                {
                    __out.AppendLine(false); //830:61
                }
                __out.Write("	{"); //831:1
                __out.AppendLine(false); //831:3
                __out.Write("        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)"); //832:1
                __out.AppendLine(false); //832:83
                __out.Write("        {"); //833:1
                __out.AppendLine(false); //833:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Metadata)) //834:14
                {
                    bool __tmp13_outputWritten = false;
                    string __tmp14_line = "            throw new NotImplementedException(\"There is no Metadata"; //835:1
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
                    string __tmp16_line = " implemented.\");"; //835:81
                    if (!string.IsNullOrEmpty(__tmp16_line))
                    {
                        __out.Write(__tmp16_line);
                        __tmp13_outputWritten = true;
                    }
                    if (__tmp13_outputWritten) __out.AppendLine(true);
                    if (__tmp13_outputWritten)
                    {
                        __out.AppendLine(false); //835:97
                    }
                }
                else if (symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //836:14
                {
                    bool __tmp18_outputWritten = false;
                    string __tmp19_line = "            throw new NotImplementedException(\"CreateMetadataSymbol for Metadata"; //837:1
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
                    string __tmp21_line = " should be implemented in a custom SymbolFactory.\");"; //837:94
                    if (!string.IsNullOrEmpty(__tmp21_line))
                    {
                        __out.Write(__tmp21_line);
                        __tmp18_outputWritten = true;
                    }
                    if (__tmp18_outputWritten) __out.AppendLine(true);
                    if (__tmp18_outputWritten)
                    {
                        __out.AppendLine(false); //837:146
                    }
                }
                else //838:14
                {
                    bool __tmp23_outputWritten = false;
                    string __tmp24_line = "            return new Metadata.Metadata"; //839:1
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
                    string __tmp26_line = "(container"; //839:54
                    if (!string.IsNullOrEmpty(__tmp26_line))
                    {
                        __out.Write(__tmp26_line);
                        __tmp23_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //839:65
                    {
                        string __tmp28_line = ", modelObject"; //839:122
                        if (!string.IsNullOrEmpty(__tmp28_line))
                        {
                            __out.Write(__tmp28_line);
                            __tmp23_outputWritten = true;
                        }
                    }
                    string __tmp30_line = ");"; //839:143
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Write(__tmp30_line);
                        __tmp23_outputWritten = true;
                    }
                    if (__tmp23_outputWritten) __out.AppendLine(true);
                    if (__tmp23_outputWritten)
                    {
                        __out.AppendLine(false); //839:145
                    }
                }
                __out.Write("        }"); //841:1
                __out.AppendLine(false); //841:10
                __out.AppendLine(true); //842:1
                __out.Write("        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)"); //843:1
                __out.AppendLine(false); //843:253
                __out.Write("        {"); //844:1
                __out.AppendLine(false); //844:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Metadata)) //845:14
                {
                    bool __tmp32_outputWritten = false;
                    string __tmp33_line = "            throw new NotImplementedException(\"There is no Metadata"; //846:1
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
                    string __tmp35_line = " implemented.\");"; //846:81
                    if (!string.IsNullOrEmpty(__tmp35_line))
                    {
                        __out.Write(__tmp35_line);
                        __tmp32_outputWritten = true;
                    }
                    if (__tmp32_outputWritten) __out.AppendLine(true);
                    if (__tmp32_outputWritten)
                    {
                        __out.AppendLine(false); //846:97
                    }
                }
                else if (symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //847:14
                {
                    bool __tmp37_outputWritten = false;
                    string __tmp38_line = "            throw new NotImplementedException(\"CreateMetadataSymbol for Metadata"; //848:1
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
                    string __tmp40_line = " should be implemented in a custom SymbolFactory.\");"; //848:94
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Write(__tmp40_line);
                        __tmp37_outputWritten = true;
                    }
                    if (__tmp37_outputWritten) __out.AppendLine(true);
                    if (__tmp37_outputWritten)
                    {
                        __out.AppendLine(false); //848:146
                    }
                }
                else //849:14
                {
                    bool __tmp42_outputWritten = false;
                    string __tmp43_line = "            return new Metadata.Metadata"; //850:1
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
                    string __tmp45_line = ".Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported"; //850:54
                    if (!string.IsNullOrEmpty(__tmp45_line))
                    {
                        __out.Write(__tmp45_line);
                        __tmp42_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //850:138
                    {
                        string __tmp47_line = ", modelObject"; //850:195
                        if (!string.IsNullOrEmpty(__tmp47_line))
                        {
                            __out.Write(__tmp47_line);
                            __tmp42_outputWritten = true;
                        }
                    }
                    string __tmp49_line = ");"; //850:216
                    if (!string.IsNullOrEmpty(__tmp49_line))
                    {
                        __out.Write(__tmp49_line);
                        __tmp42_outputWritten = true;
                    }
                    if (__tmp42_outputWritten) __out.AppendLine(true);
                    if (__tmp42_outputWritten)
                    {
                        __out.AppendLine(false); //850:218
                    }
                }
                __out.Write("        }"); //852:1
                __out.AppendLine(false); //852:10
                __out.AppendLine(true); //853:1
                __out.Write("        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)"); //854:1
                __out.AppendLine(false); //854:182
                __out.Write("        {"); //855:1
                __out.AppendLine(false); //855:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Metadata)) //856:14
                {
                    bool __tmp51_outputWritten = false;
                    string __tmp52_line = "            throw new NotImplementedException(\"There is no Metadata"; //857:1
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
                    string __tmp54_line = " implemented.\");"; //857:81
                    if (!string.IsNullOrEmpty(__tmp54_line))
                    {
                        __out.Write(__tmp54_line);
                        __tmp51_outputWritten = true;
                    }
                    if (__tmp51_outputWritten) __out.AppendLine(true);
                    if (__tmp51_outputWritten)
                    {
                        __out.AppendLine(false); //857:97
                    }
                }
                else if (symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //858:14
                {
                    bool __tmp56_outputWritten = false;
                    string __tmp57_line = "            throw new NotImplementedException(\"CreateMetadataSymbol for Metadata"; //859:1
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
                    string __tmp59_line = " should be implemented in a custom SymbolFactory.\");"; //859:94
                    if (!string.IsNullOrEmpty(__tmp59_line))
                    {
                        __out.Write(__tmp59_line);
                        __tmp56_outputWritten = true;
                    }
                    if (__tmp56_outputWritten) __out.AppendLine(true);
                    if (__tmp56_outputWritten)
                    {
                        __out.AppendLine(false); //859:146
                    }
                }
                else //860:14
                {
                    bool __tmp61_outputWritten = false;
                    string __tmp62_line = "            return new Metadata.Metadata"; //861:1
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
                    string __tmp64_line = ".Error(wrappedSymbol, kind, errorInfo, unreported"; //861:54
                    if (!string.IsNullOrEmpty(__tmp64_line))
                    {
                        __out.Write(__tmp64_line);
                        __tmp61_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //861:104
                    {
                        string __tmp66_line = ", modelObject"; //861:161
                        if (!string.IsNullOrEmpty(__tmp66_line))
                        {
                            __out.Write(__tmp66_line);
                            __tmp61_outputWritten = true;
                        }
                    }
                    string __tmp68_line = ");"; //861:182
                    if (!string.IsNullOrEmpty(__tmp68_line))
                    {
                        __out.Write(__tmp68_line);
                        __tmp61_outputWritten = true;
                    }
                    if (__tmp61_outputWritten) __out.AppendLine(true);
                    if (__tmp61_outputWritten)
                    {
                        __out.AppendLine(false); //861:184
                    }
                }
                __out.Write("        }"); //863:1
                __out.AppendLine(false); //863:10
                __out.AppendLine(true); //864:1
                __out.Write("        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)"); //865:1
                __out.AppendLine(false); //865:112
                __out.Write("        {"); //866:1
                __out.AppendLine(false); //866:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Source)) //867:14
                {
                    bool __tmp70_outputWritten = false;
                    string __tmp71_line = "            throw new NotImplementedException(\"There is no Source"; //868:1
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
                    string __tmp73_line = " implemented.\");"; //868:79
                    if (!string.IsNullOrEmpty(__tmp73_line))
                    {
                        __out.Write(__tmp73_line);
                        __tmp70_outputWritten = true;
                    }
                    if (__tmp70_outputWritten) __out.AppendLine(true);
                    if (__tmp70_outputWritten)
                    {
                        __out.AppendLine(false); //868:95
                    }
                }
                else if (symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //869:14
                {
                    bool __tmp75_outputWritten = false;
                    string __tmp76_line = "            throw new NotImplementedException(\"CreateSourceSymbol for Source"; //870:1
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
                    string __tmp78_line = " should be implemented in a custom SymbolFactory.\");"; //870:90
                    if (!string.IsNullOrEmpty(__tmp78_line))
                    {
                        __out.Write(__tmp78_line);
                        __tmp75_outputWritten = true;
                    }
                    if (__tmp75_outputWritten) __out.AppendLine(true);
                    if (__tmp75_outputWritten)
                    {
                        __out.AppendLine(false); //870:142
                    }
                }
                else //871:14
                {
                    bool __tmp80_outputWritten = false;
                    string __tmp81_line = "            return new Source.Source"; //872:1
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
                    string __tmp83_line = "(container, declaration"; //872:50
                    if (!string.IsNullOrEmpty(__tmp83_line))
                    {
                        __out.Write(__tmp83_line);
                        __tmp80_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //872:74
                    {
                        string __tmp85_line = ", modelObject"; //872:131
                        if (!string.IsNullOrEmpty(__tmp85_line))
                        {
                            __out.Write(__tmp85_line);
                            __tmp80_outputWritten = true;
                        }
                    }
                    string __tmp87_line = ");"; //872:152
                    if (!string.IsNullOrEmpty(__tmp87_line))
                    {
                        __out.Write(__tmp87_line);
                        __tmp80_outputWritten = true;
                    }
                    if (__tmp80_outputWritten) __out.AppendLine(true);
                    if (__tmp80_outputWritten)
                    {
                        __out.AppendLine(false); //872:154
                    }
                }
                __out.Write("        }"); //874:1
                __out.AppendLine(false); //874:10
                __out.AppendLine(true); //875:1
                __out.Write("        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)"); //876:1
                __out.AppendLine(false); //876:248
                __out.Write("        {"); //877:1
                __out.AppendLine(false); //877:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Source)) //878:14
                {
                    bool __tmp89_outputWritten = false;
                    string __tmp90_line = "            throw new NotImplementedException(\"There is no Source"; //879:1
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
                    string __tmp92_line = " implemented.\");"; //879:79
                    if (!string.IsNullOrEmpty(__tmp92_line))
                    {
                        __out.Write(__tmp92_line);
                        __tmp89_outputWritten = true;
                    }
                    if (__tmp89_outputWritten) __out.AppendLine(true);
                    if (__tmp89_outputWritten)
                    {
                        __out.AppendLine(false); //879:95
                    }
                }
                else if (symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //880:14
                {
                    bool __tmp94_outputWritten = false;
                    string __tmp95_line = "            throw new NotImplementedException(\"CreateSourceSymbol for Source"; //881:1
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
                    string __tmp97_line = " should be implemented in a custom SymbolFactory.\");"; //881:90
                    if (!string.IsNullOrEmpty(__tmp97_line))
                    {
                        __out.Write(__tmp97_line);
                        __tmp94_outputWritten = true;
                    }
                    if (__tmp94_outputWritten) __out.AppendLine(true);
                    if (__tmp94_outputWritten)
                    {
                        __out.AppendLine(false); //881:142
                    }
                }
                else //882:14
                {
                    bool __tmp99_outputWritten = false;
                    string __tmp100_line = "            return new Source.Source"; //883:1
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
                    string __tmp102_line = ".Error(container, declaration, kind, errorInfo, candidateSymbols, unreported"; //883:50
                    if (!string.IsNullOrEmpty(__tmp102_line))
                    {
                        __out.Write(__tmp102_line);
                        __tmp99_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //883:127
                    {
                        string __tmp104_line = ", modelObject"; //883:184
                        if (!string.IsNullOrEmpty(__tmp104_line))
                        {
                            __out.Write(__tmp104_line);
                            __tmp99_outputWritten = true;
                        }
                    }
                    string __tmp106_line = ");"; //883:205
                    if (!string.IsNullOrEmpty(__tmp106_line))
                    {
                        __out.Write(__tmp106_line);
                        __tmp99_outputWritten = true;
                    }
                    if (__tmp99_outputWritten) __out.AppendLine(true);
                    if (__tmp99_outputWritten)
                    {
                        __out.AppendLine(false); //883:207
                    }
                }
                __out.Write("        }"); //885:1
                __out.AppendLine(false); //885:10
                __out.AppendLine(true); //886:1
                __out.Write("        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)"); //887:1
                __out.AppendLine(false); //887:180
                __out.Write("        {"); //888:1
                __out.AppendLine(false); //888:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Source)) //889:14
                {
                    bool __tmp108_outputWritten = false;
                    string __tmp109_line = "            throw new NotImplementedException(\"There is no Source"; //890:1
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
                    string __tmp111_line = " implemented.\");"; //890:79
                    if (!string.IsNullOrEmpty(__tmp111_line))
                    {
                        __out.Write(__tmp111_line);
                        __tmp108_outputWritten = true;
                    }
                    if (__tmp108_outputWritten) __out.AppendLine(true);
                    if (__tmp108_outputWritten)
                    {
                        __out.AppendLine(false); //890:95
                    }
                }
                else if (symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //891:14
                {
                    bool __tmp113_outputWritten = false;
                    string __tmp114_line = "            throw new NotImplementedException(\"CreateSourceSymbol for Source"; //892:1
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
                    string __tmp116_line = " should be implemented in a custom SymbolFactory.\");"; //892:90
                    if (!string.IsNullOrEmpty(__tmp116_line))
                    {
                        __out.Write(__tmp116_line);
                        __tmp113_outputWritten = true;
                    }
                    if (__tmp113_outputWritten) __out.AppendLine(true);
                    if (__tmp113_outputWritten)
                    {
                        __out.AppendLine(false); //892:142
                    }
                }
                else //893:14
                {
                    bool __tmp118_outputWritten = false;
                    string __tmp119_line = "            return new Source.Source"; //894:1
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
                    string __tmp121_line = ".Error(wrappedSymbol, kind, errorInfo, unreported"; //894:50
                    if (!string.IsNullOrEmpty(__tmp121_line))
                    {
                        __out.Write(__tmp121_line);
                        __tmp118_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //894:100
                    {
                        string __tmp123_line = ", modelObject"; //894:157
                        if (!string.IsNullOrEmpty(__tmp123_line))
                        {
                            __out.Write(__tmp123_line);
                            __tmp118_outputWritten = true;
                        }
                    }
                    string __tmp125_line = ");"; //894:178
                    if (!string.IsNullOrEmpty(__tmp125_line))
                    {
                        __out.Write(__tmp125_line);
                        __tmp118_outputWritten = true;
                    }
                    if (__tmp118_outputWritten) __out.AppendLine(true);
                    if (__tmp118_outputWritten)
                    {
                        __out.AppendLine(false); //894:180
                    }
                }
                __out.Write("        }"); //896:1
                __out.AppendLine(false); //896:10
                __out.Write("	}"); //897:1
                __out.AppendLine(false); //897:3
            }
            __out.Write("}"); //899:1
            __out.AppendLine(false); //899:2
            return __out.ToStringAndFree();
        }

    }
}

