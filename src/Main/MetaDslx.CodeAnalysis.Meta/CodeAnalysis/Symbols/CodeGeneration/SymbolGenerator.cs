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
            if (symbol.ExistingCompletionBaseType == null) //59:56
            {
                string __tmp11_line = " : "; //59:103
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
                string __tmp13_line = "."; //59:128
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
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //59:143
                {
                    string __tmp16_line = ", MetaDslx.CodeAnalysis.Symbols.Metadata.IModelSymbol"; //59:200
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
                __out.AppendLine(false); //59:269
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
                if (!symbol.ExistingCompletionMemberNames.Contains(".ctor")) //84:10
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
                    string __tmp73_line = ")"; //86:216
                    if (!string.IsNullOrEmpty(__tmp73_line))
                    {
                        __out.Write(__tmp73_line);
                        __tmp63_outputWritten = true;
                    }
                    if (__tmp63_outputWritten) __out.AppendLine(true);
                    if (__tmp63_outputWritten)
                    {
                        __out.AppendLine(false); //86:217
                    }
                    __out.Write("        {"); //87:1
                    __out.AppendLine(false); //87:10
                    __out.Write("            _container = container;"); //88:1
                    __out.AppendLine(false); //88:36
                    if (symbol.ModelObjectOption == ParameterOption.Required) //89:14
                    {
                        __out.Write("            if (modelObject is null) throw new ArgumentNullException(nameof(modelObject));"); //90:1
                        __out.AppendLine(false); //90:91
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
                if (!symbol.ExistingCompletionMemberNames.Contains("Language")) //98:10
                {
                    __out.AppendLine(true); //99:1
                    __out.Write("        public sealed override Language Language => ContainingModule.Language;"); //100:1
                    __out.AppendLine(false); //100:79
                }
                if (!symbol.ExistingCompletionMemberNames.Contains("SymbolFactory")) //102:10
                {
                    __out.AppendLine(true); //103:1
                    __out.Write("        public SymbolFactory SymbolFactory => ContainingModule.SymbolFactory;"); //104:1
                    __out.AppendLine(false); //104:78
                }
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //106:10
                {
                    if (!symbol.ExistingCompletionMemberNames.Contains("ModelObject")) //107:14
                    {
                        __out.AppendLine(true); //108:1
                        __out.Write("        public object ModelObject => _modelObject;"); //109:1
                        __out.AppendLine(false); //109:51
                    }
                    if (!symbol.ExistingCompletionMemberNames.Contains("ModelObjectType")) //111:14
                    {
                        __out.AppendLine(true); //112:1
                        __out.Write("        public Type ModelObjectType => _modelObject is not null ? Language.SymbolFacts.GetModelObjectType(_modelObject) : null;"); //113:1
                        __out.AppendLine(false); //113:128
                    }
                }
                if (!symbol.ExistingCompletionMemberNames.Contains("ContainingSymbol")) //116:10
                {
                    __out.AppendLine(true); //117:1
                    __out.Write("        public sealed override Symbol ContainingSymbol => _container;"); //118:1
                    __out.AppendLine(false); //118:70
                }
            }
            if (!symbol.ExistingCompletionMemberNames.Contains("ChildSymbols")) //121:10
            {
                __out.AppendLine(true); //122:1
                __out.Write("        public sealed override ImmutableArray<Symbol> ChildSymbols "); //123:1
                __out.AppendLine(false); //123:68
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
            if (!symbol.ExistingCompletionMemberNames.Contains("Name")) //132:10
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
                if (!symbol.ExistingCompletionMemberNames.Contains(prop.Name)) //144:14
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
            if (!symbol.ExistingCompletionMemberNames.Contains("CompleteSymbolProperty_Name")) //293:10
            {
                __out.Write("        protected abstract string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //294:1
                __out.AppendLine(false); //294:127
            }
            if (!symbol.ExistingCompletionMemberNames.Contains("CompleteInitializingSymbol")) //296:10
            {
                __out.Write("        protected abstract void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //297:1
                __out.AppendLine(false); //297:124
            }
            if (!symbol.ExistingCompletionMemberNames.Contains("CompleteCreatingChildSymbols")) //299:10
            {
                __out.Write("        protected abstract ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //300:1
                __out.AppendLine(false); //300:144
            }
            if (!symbol.ExistingCompletionMemberNames.Contains("CompleteImports")) //302:10
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
                if (!symbol.ExistingCompletionMemberNames.Contains(part.CompleteMethodName)) //306:14
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
            if (!symbol.ExistingCompletionMemberNames.Contains("CompleteNonSymbolProperties")) //310:10
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
            if (symbol.ExistingMetadataBaseType == null) //334:45
            {
                string __tmp11_line = " : "; //334:90
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
                string __tmp13_line = ".Completion.Completion"; //334:115
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
                __out.AppendLine(false); //334:158
            }
            __out.Write("	{"); //335:1
            __out.AppendLine(false); //335:3
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //336:10
            {
                if (!symbol.ExistingMetadataMemberNames.Contains(".ctor")) //337:10
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
                        string __tmp22_line = ", object modelObject"; //338:112
                        if (!string.IsNullOrEmpty(__tmp22_line))
                        {
                            __out.Write(__tmp22_line);
                            __tmp17_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //338:133
                        {
                            string __tmp24_line = " = null"; //338:190
                            if (!string.IsNullOrEmpty(__tmp24_line))
                            {
                                __out.Write(__tmp24_line);
                                __tmp17_outputWritten = true;
                            }
                        }
                    }
                    string __tmp27_line = ")"; //338:213
                    if (!string.IsNullOrEmpty(__tmp27_line))
                    {
                        __out.Write(__tmp27_line);
                        __tmp17_outputWritten = true;
                    }
                    if (__tmp17_outputWritten) __out.AppendLine(true);
                    if (__tmp17_outputWritten)
                    {
                        __out.AppendLine(false); //338:214
                    }
                    __out.Write("            : base(container"); //339:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //339:30
                    {
                        __out.Write(", modelObject"); //339:87
                    }
                    __out.Write(")"); //339:108
                    __out.AppendLine(false); //339:109
                    __out.Write("        {"); //340:1
                    __out.AppendLine(false); //340:10
                    __out.Write("        }"); //341:1
                    __out.AppendLine(false); //341:10
                }
                if (!symbol.ExistingMetadataMemberNames.Contains("Locations")) //343:10
                {
                    __out.AppendLine(true); //344:1
                    __out.Write("        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;"); //345:1
                    __out.AppendLine(false); //345:95
                }
                if (!symbol.ExistingMetadataMemberNames.Contains("DeclaringSyntaxReferences")) //347:10
                {
                    __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;"); //348:1
                    __out.AppendLine(false); //348:124
                }
            }
            if (!symbol.ExistingMetadataMemberNames.Contains("CompleteSymbolProperty_Name")) //351:10
            {
                __out.AppendLine(true); //352:1
                __out.Write("        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //353:1
                __out.AppendLine(false); //353:126
                __out.Write("        {"); //354:1
                __out.AppendLine(false); //354:10
                __out.Write("            return ModelSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //355:1
                __out.AppendLine(false); //355:132
                __out.Write("        }"); //356:1
                __out.AppendLine(false); //356:10
            }
            if (!symbol.ExistingMetadataMemberNames.Contains("CompleteInitializingSymbol")) //358:10
            {
                __out.AppendLine(true); //359:1
                __out.Write("        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //360:1
                __out.AppendLine(false); //360:123
                __out.Write("        {"); //361:1
                __out.AppendLine(false); //361:10
                __out.Write("        }"); //362:1
                __out.AppendLine(false); //362:10
            }
            if (!symbol.ExistingMetadataMemberNames.Contains("CompleteCreatingChildSymbols")) //364:10
            {
                __out.AppendLine(true); //365:1
                __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //366:1
                __out.AppendLine(false); //366:143
                __out.Write("        {"); //367:1
                __out.AppendLine(false); //367:10
                __out.Write("            return ModelSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //368:1
                __out.AppendLine(false); //368:123
                __out.Write("        }"); //369:1
                __out.AppendLine(false); //369:10
            }
            if (!symbol.ExistingMetadataMemberNames.Contains("CompleteImports")) //371:10
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
                if (!symbol.ExistingMetadataMemberNames.Contains(part.CompleteMethodName)) //378:14
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
                            string __tmp40_line = "            return ModelSymbolImplementation.AssignSymbolPropertyValues<"; //385:1
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
                            string __tmp42_line = ">(this, nameof("; //385:88
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
                            string __tmp44_line = "), diagnostics, cancellationToken);"; //385:114
                            if (!string.IsNullOrEmpty(__tmp44_line))
                            {
                                __out.Write(__tmp44_line);
                                __tmp39_outputWritten = true;
                            }
                            if (__tmp39_outputWritten) __out.AppendLine(true);
                            if (__tmp39_outputWritten)
                            {
                                __out.AppendLine(false); //385:149
                            }
                        }
                        else //386:18
                        {
                            bool __tmp46_outputWritten = false;
                            string __tmp47_line = "            return ModelSymbolImplementation.AssignSymbolPropertyValue<"; //387:1
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
                            string __tmp49_line = ">(this, nameof("; //387:83
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
                            string __tmp51_line = "), diagnostics, cancellationToken);"; //387:109
                            if (!string.IsNullOrEmpty(__tmp51_line))
                            {
                                __out.Write(__tmp51_line);
                                __tmp46_outputWritten = true;
                            }
                            if (__tmp46_outputWritten) __out.AppendLine(true);
                            if (__tmp46_outputWritten)
                            {
                                __out.AppendLine(false); //387:144
                            }
                        }
                    }
                    __out.Write("        }"); //390:1
                    __out.AppendLine(false); //390:10
                }
            }
            if (!symbol.ExistingMetadataMemberNames.Contains("CompleteNonSymbolProperties")) //393:10
            {
                __out.AppendLine(true); //394:1
                __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //395:1
                __out.AppendLine(false); //395:152
                __out.Write("        {"); //396:1
                __out.AppendLine(false); //396:10
                __out.Write("        }"); //397:1
                __out.AppendLine(false); //397:10
            }
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //399:10
            {
                __out.AppendLine(true); //400:1
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
                    if (!__tmp55_last || __tmp53_outputWritten) __out.AppendLine(true);
                }
                if (__tmp53_outputWritten)
                {
                    __out.AppendLine(false); //401:59
                }
                __out.Write("        {"); //402:1
                __out.AppendLine(false); //402:10
                __out.Write("            public Error(Symbol container"); //403:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //403:43
                {
                    __out.Write(", object modelObject = null"); //403:100
                }
                __out.Write(")"); //403:135
                __out.AppendLine(false); //403:136
                __out.Write("                : base(container"); //404:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //404:34
                {
                    __out.Write(", modelObject"); //404:91
                }
                __out.Write(")"); //404:112
                __out.AppendLine(false); //404:113
                __out.Write("            {"); //405:1
                __out.AppendLine(false); //405:14
                __out.Write("            }"); //406:1
                __out.AppendLine(false); //406:14
                __out.AppendLine(true); //407:1
                __out.Write("            public sealed override bool IsError => true;"); //408:1
                __out.AppendLine(false); //408:57
                __out.Write("        }"); //409:1
                __out.AppendLine(false); //409:10
            }
            __out.Write("    }"); //411:1
            __out.AppendLine(false); //411:6
            __out.Write("}"); //412:1
            __out.AppendLine(false); //412:2
            return __out.ToStringAndFree();
        }

        public string GenerateSourceSymbol(SymbolGenerationInfo symbol) //415:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //416:1
            __out.AppendLine(false); //416:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //417:1
            __out.AppendLine(false); //417:29
            __out.Write("using MetaDslx.CodeAnalysis.Binding;"); //418:1
            __out.AppendLine(false); //418:37
            __out.Write("using MetaDslx.CodeAnalysis.Binding.Binders;"); //419:1
            __out.AppendLine(false); //419:45
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //420:1
            __out.AppendLine(false); //420:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //421:1
            __out.AppendLine(false); //421:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //422:1
            __out.AppendLine(false); //422:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //423:1
            __out.AppendLine(false); //423:44
            __out.Write("using System;"); //424:1
            __out.AppendLine(false); //424:14
            __out.Write("using System.Collections.Generic;"); //425:1
            __out.AppendLine(false); //425:34
            __out.Write("using System.Collections.Immutable;"); //426:1
            __out.AppendLine(false); //426:36
            __out.Write("using System.Diagnostics;"); //427:1
            __out.AppendLine(false); //427:26
            __out.Write("using System.Linq;"); //428:1
            __out.AppendLine(false); //428:19
            __out.Write("using System.Text;"); //429:1
            __out.AppendLine(false); //429:19
            __out.Write("using System.Threading;"); //430:1
            __out.AppendLine(false); //430:24
            __out.AppendLine(true); //431:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //432:1
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
            string __tmp5_line = ".Source"; //432:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //432:40
            }
            __out.Write("{"); //433:1
            __out.AppendLine(false); //433:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Source"; //434:1
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
            if (symbol.ExistingSourceBaseType == null) //434:43
            {
                string __tmp11_line = " : "; //434:86
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
                string __tmp13_line = ".Completion.Completion"; //434:111
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
                if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //434:147
                {
                    string __tmp16_line = ", MetaDslx.CodeAnalysis.Symbols.Source.ISourceSymbol"; //434:217
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
                __out.AppendLine(false); //434:285
            }
            __out.Write("	{"); //435:1
            __out.AppendLine(false); //435:3
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //436:10
            {
                __out.Write("        private readonly MergedDeclaration _declaration;"); //437:1
                __out.AppendLine(false); //437:57
                if (!symbol.ExistingSourceMemberNames.Contains(".ctor")) //438:10
                {
                    __out.AppendLine(true); //439:1
                    bool __tmp20_outputWritten = false;
                    string __tmp21_line = "		public Source"; //440:1
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
                    string __tmp23_line = "(Symbol containingSymbol, "; //440:29
                    if (!string.IsNullOrEmpty(__tmp23_line))
                    {
                        __out.Write(__tmp23_line);
                        __tmp20_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //440:56
                    {
                        string __tmp25_line = "object modelObject"; //440:113
                        if (!string.IsNullOrEmpty(__tmp25_line))
                        {
                            __out.Write(__tmp25_line);
                            __tmp20_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //440:132
                        {
                            string __tmp27_line = " = null"; //440:189
                            if (!string.IsNullOrEmpty(__tmp27_line))
                            {
                                __out.Write(__tmp27_line);
                                __tmp20_outputWritten = true;
                            }
                        }
                        string __tmp29_line = ", "; //440:204
                        if (!string.IsNullOrEmpty(__tmp29_line))
                        {
                            __out.Write(__tmp29_line);
                            __tmp20_outputWritten = true;
                        }
                    }
                    string __tmp31_line = "MergedDeclaration declaration)"; //440:214
                    if (!string.IsNullOrEmpty(__tmp31_line))
                    {
                        __out.Write(__tmp31_line);
                        __tmp20_outputWritten = true;
                    }
                    if (__tmp20_outputWritten) __out.AppendLine(true);
                    if (__tmp20_outputWritten)
                    {
                        __out.AppendLine(false); //440:244
                    }
                    __out.Write("            : base(containingSymbol"); //441:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //441:37
                    {
                        __out.Write(", modelObject"); //441:94
                    }
                    __out.Write(")"); //441:115
                    __out.AppendLine(false); //441:116
                    __out.Write("        {"); //442:1
                    __out.AppendLine(false); //442:10
                    __out.Write("            if (declaration is null) throw new ArgumentNullException(nameof(declaration));"); //443:1
                    __out.AppendLine(false); //443:91
                    __out.Write("            _declaration = declaration;"); //444:1
                    __out.AppendLine(false); //444:40
                    __out.Write("		}"); //445:1
                    __out.AppendLine(false); //445:4
                }
                if (!symbol.ExistingSourceMemberNames.Contains("MergedDeclaration")) //447:10
                {
                    __out.AppendLine(true); //448:1
                    __out.Write("        public MergedDeclaration MergedDeclaration => _declaration;"); //449:1
                    __out.AppendLine(false); //449:68
                }
                if (!symbol.ExistingSourceMemberNames.Contains("Locations")) //451:10
                {
                    __out.AppendLine(true); //452:1
                    __out.Write("        public override ImmutableArray<Location> Locations => _declaration.NameLocations;"); //453:1
                    __out.AppendLine(false); //453:90
                }
                if (!symbol.ExistingSourceMemberNames.Contains("DeclaringSyntaxReferences")) //455:10
                {
                    __out.AppendLine(true); //456:1
                    __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration.SyntaxReferences;"); //457:1
                    __out.AppendLine(false); //457:116
                }
                if (!symbol.ExistingSourceMemberNames.Contains("GetBinder")) //459:10
                {
                    __out.AppendLine(true); //460:1
                    __out.Write("        public BinderPosition<SymbolBinder> GetBinder(SyntaxReference reference)"); //461:1
                    __out.AppendLine(false); //461:81
                    __out.Write("        {"); //462:1
                    __out.AppendLine(false); //462:10
                    __out.Write("            Debug.Assert(this.DeclaringSyntaxReferences.Contains(reference));"); //463:1
                    __out.AppendLine(false); //463:78
                    __out.Write("            return FindBinders.FindSymbolBinder(this, reference);"); //464:1
                    __out.AppendLine(false); //464:66
                    __out.Write("        }"); //465:1
                    __out.AppendLine(false); //465:10
                }
                if (!symbol.ExistingSourceMemberNames.Contains("GetChildSymbol")) //467:10
                {
                    __out.AppendLine(true); //468:1
                    __out.Write("        public Symbol GetChildSymbol(SyntaxReference syntax)"); //469:1
                    __out.AppendLine(false); //469:61
                    __out.Write("        {"); //470:1
                    __out.AppendLine(false); //470:10
                    __out.Write("            foreach (var child in this.ChildSymbols)"); //471:1
                    __out.AppendLine(false); //471:53
                    __out.Write("            {"); //472:1
                    __out.AppendLine(false); //472:14
                    __out.Write("                if (child.DeclaringSyntaxReferences.Any(sr => sr.GetLocation() == syntax.GetLocation()))"); //473:1
                    __out.AppendLine(false); //473:105
                    __out.Write("                {"); //474:1
                    __out.AppendLine(false); //474:18
                    __out.Write("                    return child;"); //475:1
                    __out.AppendLine(false); //475:34
                    __out.Write("                }"); //476:1
                    __out.AppendLine(false); //476:18
                    __out.Write("            }"); //477:1
                    __out.AppendLine(false); //477:14
                    __out.Write("            return null;"); //478:1
                    __out.AppendLine(false); //478:25
                    __out.Write("        }"); //479:1
                    __out.AppendLine(false); //479:10
                }
            }
            if (!symbol.ExistingSourceMemberNames.Contains("CompleteInitializingSymbol")) //482:10
            {
                __out.AppendLine(true); //483:1
                __out.Write("        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //484:1
                __out.AppendLine(false); //484:123
                __out.Write("        {"); //485:1
                __out.AppendLine(false); //485:10
                __out.Write("        }"); //486:1
                __out.AppendLine(false); //486:10
            }
            if (!symbol.ExistingSourceMemberNames.Contains("CompleteCreatingChildSymbols")) //488:10
            {
                __out.AppendLine(true); //489:1
                __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //490:1
                __out.AppendLine(false); //490:143
                __out.Write("        {"); //491:1
                __out.AppendLine(false); //491:10
                __out.Write("            return SourceSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //492:1
                __out.AppendLine(false); //492:124
                __out.Write("        }"); //493:1
                __out.AppendLine(false); //493:10
            }
            if (!symbol.ExistingSourceMemberNames.Contains("CompleteImports")) //495:10
            {
                __out.AppendLine(true); //496:1
                __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //497:1
                __out.AppendLine(false); //497:140
                __out.Write("        {"); //498:1
                __out.AppendLine(false); //498:10
                __out.Write("            SourceSymbolImplementation.CompleteImports(this, locationOpt, diagnostics, cancellationToken);"); //499:1
                __out.AppendLine(false); //499:107
                __out.Write("        }"); //500:1
                __out.AppendLine(false); //500:10
                __out.AppendLine(true); //501:1
            }
            if (!symbol.ExistingSourceMemberNames.Contains("CompleteSymbolProperty_Name")) //503:10
            {
                __out.Write("        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //504:1
                __out.AppendLine(false); //504:126
                __out.Write("        {"); //505:1
                __out.AppendLine(false); //505:10
                __out.Write("            return SourceSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //506:1
                __out.AppendLine(false); //506:133
                __out.Write("        }"); //507:1
                __out.AppendLine(false); //507:10
            }
            __out.AppendLine(true); //509:1
            var __loop10_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //510:16
                where part.GenerateCompleteMethod //510:44
                select new { part = part}
                ).ToList(); //510:10
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                var __tmp32 = __loop10_results[__loop10_iteration];
                var part = __tmp32.part;
                if (!symbol.ExistingSourceMemberNames.Contains(part.CompleteMethodName)) //511:14
                {
                    bool __tmp34_outputWritten = false;
                    string __tmp35_line = "        protected override "; //512:1
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
                    string __tmp37_line = " "; //512:59
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
                    string __tmp39_line = "("; //512:85
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
                    string __tmp41_line = ")"; //512:116
                    if (!string.IsNullOrEmpty(__tmp41_line))
                    {
                        __out.Write(__tmp41_line);
                        __tmp34_outputWritten = true;
                    }
                    if (__tmp34_outputWritten) __out.AppendLine(true);
                    if (__tmp34_outputWritten)
                    {
                        __out.AppendLine(false); //512:117
                    }
                    __out.Write("        {"); //513:1
                    __out.AppendLine(false); //513:10
                    if (part is SymbolPropertyGenerationInfo) //514:14
                    {
                        var prop = (SymbolPropertyGenerationInfo)part; //515:18
                        if (prop.IsCollection) //516:18
                        {
                            bool __tmp43_outputWritten = false;
                            string __tmp44_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValues<"; //517:1
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
                            string __tmp46_line = ">(this, nameof("; //517:89
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
                            string __tmp48_line = "), diagnostics, cancellationToken);"; //517:115
                            if (!string.IsNullOrEmpty(__tmp48_line))
                            {
                                __out.Write(__tmp48_line);
                                __tmp43_outputWritten = true;
                            }
                            if (__tmp43_outputWritten) __out.AppendLine(true);
                            if (__tmp43_outputWritten)
                            {
                                __out.AppendLine(false); //517:150
                            }
                        }
                        else //518:18
                        {
                            bool __tmp50_outputWritten = false;
                            string __tmp51_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValue<"; //519:1
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
                            string __tmp53_line = ">(this, nameof("; //519:84
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
                            string __tmp55_line = "), diagnostics, cancellationToken);"; //519:110
                            if (!string.IsNullOrEmpty(__tmp55_line))
                            {
                                __out.Write(__tmp55_line);
                                __tmp50_outputWritten = true;
                            }
                            if (__tmp50_outputWritten) __out.AppendLine(true);
                            if (__tmp50_outputWritten)
                            {
                                __out.AppendLine(false); //519:145
                            }
                        }
                    }
                    __out.Write("        }"); //522:1
                    __out.AppendLine(false); //522:10
                }
            }
            if (!symbol.ExistingSourceMemberNames.Contains("CompleteNonSymbolProperties")) //525:10
            {
                __out.AppendLine(true); //526:1
                __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //527:1
                __out.AppendLine(false); //527:152
                __out.Write("        {"); //528:1
                __out.AppendLine(false); //528:10
                __out.Write("            SourceSymbolImplementation.AssignNonSymbolProperties(this, diagnostics, cancellationToken);"); //529:1
                __out.AppendLine(false); //529:104
                __out.Write("        }"); //530:1
                __out.AppendLine(false); //530:10
            }
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //532:10
            {
                __out.AppendLine(true); //533:1
                bool __tmp57_outputWritten = false;
                string __tmp58_line = "        public partial class Error : Source"; //534:1
                if (!string.IsNullOrEmpty(__tmp58_line))
                {
                    __out.Write(__tmp58_line);
                    __tmp57_outputWritten = true;
                }
                var __tmp59 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp59.Write(symbol.Name);
                var __tmp59Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp59.ToStringAndFree());
                bool __tmp59_last = __tmp59Reader.EndOfStream;
                while(!__tmp59_last)
                {
                    ReadOnlySpan<char> __tmp59_line = __tmp59Reader.ReadLine();
                    __tmp59_last = __tmp59Reader.EndOfStream;
                    if (!__tmp59_last || !__tmp59_line.IsEmpty)
                    {
                        __out.Write(__tmp59_line);
                        __tmp57_outputWritten = true;
                    }
                    if (!__tmp59_last || __tmp57_outputWritten) __out.AppendLine(true);
                }
                if (__tmp57_outputWritten)
                {
                    __out.AppendLine(false); //534:57
                }
                __out.Write("        {"); //535:1
                __out.AppendLine(false); //535:10
                __out.Write("            public Error(Symbol container"); //536:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //536:43
                {
                    __out.Write(", object modelObject = null"); //536:100
                }
                __out.Write(", MergedDeclaration declaration)"); //536:135
                __out.AppendLine(false); //536:167
                __out.Write("                : base(container"); //537:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //537:34
                {
                    __out.Write(", modelObject"); //537:91
                }
                __out.Write(", declaration)"); //537:112
                __out.AppendLine(false); //537:126
                __out.Write("            {"); //538:1
                __out.AppendLine(false); //538:14
                __out.Write("            }"); //539:1
                __out.AppendLine(false); //539:14
                __out.AppendLine(true); //540:1
                __out.Write("            public sealed override bool IsError => true;"); //541:1
                __out.AppendLine(false); //541:57
                __out.Write("        }"); //542:1
                __out.AppendLine(false); //542:10
            }
            __out.Write("	}"); //544:1
            __out.AppendLine(false); //544:3
            __out.Write("}"); //545:1
            __out.AppendLine(false); //545:2
            return __out.ToStringAndFree();
        }

        public string GenerateVisitor(string namespaceName, IEnumerable<SymbolGenerationInfo> symbols) //548:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //549:1
            __out.AppendLine(false); //549:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //550:1
            __out.AppendLine(false); //550:29
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //551:1
            __out.AppendLine(false); //551:37
            __out.Write("using System;"); //552:1
            __out.AppendLine(false); //552:14
            __out.Write("using System.Collections.Generic;"); //553:1
            __out.AppendLine(false); //553:34
            __out.Write("using System.Collections.Immutable;"); //554:1
            __out.AppendLine(false); //554:36
            __out.Write("using System.Diagnostics;"); //555:1
            __out.AppendLine(false); //555:26
            __out.Write("using System.Text;"); //556:1
            __out.AppendLine(false); //556:19
            __out.Write("using System.Threading;"); //557:1
            __out.AppendLine(false); //557:24
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //559:1
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
                __out.AppendLine(false); //559:26
            }
            __out.Write("{"); //560:1
            __out.AppendLine(false); //560:2
            __out.Write("	public interface ISymbolVisitor"); //561:1
            __out.AppendLine(false); //561:33
            __out.Write("	{"); //562:1
            __out.AppendLine(false); //562:3
            var __loop11_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //563:16
                select new { symbol = symbol}
                ).ToList(); //563:10
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp5 = __loop11_results[__loop11_iteration];
                var symbol = __tmp5.symbol;
                bool __tmp7_outputWritten = false;
                string __tmp8_line = "        void Visit("; //564:1
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
                string __tmp10_line = " symbol);"; //564:33
                if (!string.IsNullOrEmpty(__tmp10_line))
                {
                    __out.Write(__tmp10_line);
                    __tmp7_outputWritten = true;
                }
                if (__tmp7_outputWritten) __out.AppendLine(true);
                if (__tmp7_outputWritten)
                {
                    __out.AppendLine(false); //564:42
                }
            }
            __out.Write("	}"); //566:1
            __out.AppendLine(false); //566:3
            __out.AppendLine(true); //567:1
            __out.Write("	public interface ISymbolVisitor<TResult>"); //568:1
            __out.AppendLine(false); //568:42
            __out.Write("	{"); //569:1
            __out.AppendLine(false); //569:3
            var __loop12_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //570:16
                select new { symbol = symbol}
                ).ToList(); //570:10
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp11 = __loop12_results[__loop12_iteration];
                var symbol = __tmp11.symbol;
                bool __tmp13_outputWritten = false;
                string __tmp14_line = "        TResult Visit("; //571:1
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
                string __tmp16_line = " symbol);"; //571:36
                if (!string.IsNullOrEmpty(__tmp16_line))
                {
                    __out.Write(__tmp16_line);
                    __tmp13_outputWritten = true;
                }
                if (__tmp13_outputWritten) __out.AppendLine(true);
                if (__tmp13_outputWritten)
                {
                    __out.AppendLine(false); //571:45
                }
            }
            __out.Write("	}"); //573:1
            __out.AppendLine(false); //573:3
            __out.AppendLine(true); //574:1
            __out.Write("	public interface ISymbolVisitor<TArgument, TResult>"); //575:1
            __out.AppendLine(false); //575:53
            __out.Write("	{"); //576:1
            __out.AppendLine(false); //576:3
            var __loop13_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //577:16
                select new { symbol = symbol}
                ).ToList(); //577:10
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp17 = __loop13_results[__loop13_iteration];
                var symbol = __tmp17.symbol;
                bool __tmp19_outputWritten = false;
                string __tmp20_line = "        TResult Visit("; //578:1
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
                string __tmp22_line = " symbol, TArgument argument);"; //578:36
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Write(__tmp22_line);
                    __tmp19_outputWritten = true;
                }
                if (__tmp19_outputWritten) __out.AppendLine(true);
                if (__tmp19_outputWritten)
                {
                    __out.AppendLine(false); //578:65
                }
            }
            __out.Write("	}"); //580:1
            __out.AppendLine(false); //580:3
            __out.Write("}"); //581:1
            __out.AppendLine(false); //581:2
            return __out.ToStringAndFree();
        }

    }
}

