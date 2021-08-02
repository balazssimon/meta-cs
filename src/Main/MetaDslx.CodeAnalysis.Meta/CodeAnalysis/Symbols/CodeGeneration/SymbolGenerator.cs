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

        public string GenerateErrorSymbol(SymbolGenerationInfo symbol) //42:1
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
            string __tmp5_line = ".Error"; //57:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //57:39
            }
            __out.Write("{"); //58:1
            __out.AppendLine(false); //58:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Error"; //59:1
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
            if (symbol.ExistingErrorTypeInfo.BaseType == null) //59:42
            {
                string __tmp11_line = " : "; //59:93
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
                string __tmp13_line = "."; //59:118
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
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //59:133
                {
                    string __tmp16_line = ", MetaDslx.CodeAnalysis.Symbols.Metadata.IModelSymbol"; //59:190
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
                __out.AppendLine(false); //59:259
            }
            __out.Write("	{"); //60:1
            __out.AppendLine(false); //60:3
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //61:10
            {
                __out.Write("        private readonly Symbol _container;"); //62:1
                __out.AppendLine(false); //62:44
            }
            if (symbol.ModelObjectOption != ParameterOption.Disabled) //64:10
            {
                __out.Write("        private readonly object? _modelObject;"); //65:1
                __out.AppendLine(false); //65:47
            }
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //67:10
            {
                if (!symbol.ExistingErrorTypeInfo.Members.Contains(".ctor")) //68:10
                {
                    __out.AppendLine(true); //69:1
                    bool __tmp20_outputWritten = false;
                    string __tmp21_line = "        public Error"; //70:1
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
                    string __tmp23_line = "(Symbol container"; //70:34
                    if (!string.IsNullOrEmpty(__tmp23_line))
                    {
                        __out.Write(__tmp23_line);
                        __tmp20_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //70:52
                    {
                        string __tmp25_line = ", object? modelObject"; //70:109
                        if (!string.IsNullOrEmpty(__tmp25_line))
                        {
                            __out.Write(__tmp25_line);
                            __tmp20_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //70:131
                        {
                            string __tmp27_line = " = null"; //70:188
                            if (!string.IsNullOrEmpty(__tmp27_line))
                            {
                                __out.Write(__tmp27_line);
                                __tmp20_outputWritten = true;
                            }
                        }
                    }
                    string __tmp30_line = ")"; //70:211
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Write(__tmp30_line);
                        __tmp20_outputWritten = true;
                    }
                    if (__tmp20_outputWritten) __out.AppendLine(true);
                    if (__tmp20_outputWritten)
                    {
                        __out.AppendLine(false); //70:212
                    }
                    __out.Write("        {"); //71:1
                    __out.AppendLine(false); //71:10
                    __out.Write("            if (container is null) throw new ArgumentNullException(nameof(container));"); //72:1
                    __out.AppendLine(false); //72:87
                    if (symbol.ModelObjectOption == ParameterOption.Required) //73:14
                    {
                        __out.Write("            if (modelObject is null) throw new ArgumentNullException(nameof(modelObject));"); //74:1
                        __out.AppendLine(false); //74:91
                    }
                    __out.Write("            _container = container;"); //76:1
                    __out.AppendLine(false); //76:36
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //77:14
                    {
                        __out.Write("            _modelObject = modelObject;"); //78:1
                        __out.AppendLine(false); //78:40
                    }
                    __out.Write("        }"); //80:1
                    __out.AppendLine(false); //80:10
                }
                if (!symbol.ExistingErrorTypeInfo.Members.Contains("Language")) //82:10
                {
                    __out.AppendLine(true); //83:1
                    __out.Write("        public sealed override Language Language => ContainingModule.Language;"); //84:1
                    __out.AppendLine(false); //84:79
                }
                if (!symbol.ExistingErrorTypeInfo.Members.Contains("SymbolFactory")) //86:10
                {
                    __out.AppendLine(true); //87:1
                    __out.Write("        public SymbolFactory SymbolFactory => ContainingModule.SymbolFactory;"); //88:1
                    __out.AppendLine(false); //88:78
                }
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //90:10
                {
                    if (!symbol.ExistingErrorTypeInfo.Members.Contains("ModelObject")) //91:14
                    {
                        __out.AppendLine(true); //92:1
                        __out.Write("        public object ModelObject => _modelObject;"); //93:1
                        __out.AppendLine(false); //93:51
                    }
                    if (!symbol.ExistingErrorTypeInfo.Members.Contains("ModelObjectType")) //95:14
                    {
                        __out.AppendLine(true); //96:1
                        __out.Write("        public Type ModelObjectType => _modelObject is not null ? Language.SymbolFacts.GetModelObjectType(_modelObject) : null;"); //97:1
                        __out.AppendLine(false); //97:128
                    }
                }
                if (!symbol.ExistingErrorTypeInfo.Members.Contains("ContainingSymbol")) //100:10
                {
                    __out.AppendLine(true); //101:1
                    __out.Write("        public sealed override Symbol ContainingSymbol => _container;"); //102:1
                    __out.AppendLine(false); //102:70
                }
            }
            if (!symbol.ExistingErrorTypeInfo.Members.Contains("ChildSymbols")) //105:10
            {
                __out.AppendLine(true); //106:1
                __out.Write("        public sealed override ImmutableArray<Symbol> ChildSymbols => ImmutableArray<Symbol>.Empty;"); //107:1
                __out.AppendLine(false); //107:100
            }
            if (!symbol.ExistingErrorTypeInfo.Members.Contains("Name")) //109:10
            {
                __out.AppendLine(true); //110:1
                __out.Write("        public sealed override string Name => string.Empty;"); //111:1
                __out.AppendLine(false); //111:60
            }
            var __loop1_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //113:16
                select new { prop = prop}
                ).ToList(); //113:10
            for (int __loop1_iteration = 0; __loop1_iteration < __loop1_results.Count; ++__loop1_iteration)
            {
                var __tmp31 = __loop1_results[__loop1_iteration];
                var prop = __tmp31.prop;
                if (!symbol.ExistingErrorTypeInfo.Members.Contains(prop.Name)) //114:14
                {
                    __out.AppendLine(true); //115:1
                    bool __tmp33_outputWritten = false;
                    string __tmp34_line = "        public override "; //116:1
                    if (!string.IsNullOrEmpty(__tmp34_line))
                    {
                        __out.Write(__tmp34_line);
                        __tmp33_outputWritten = true;
                    }
                    var __tmp35 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp35.Write(prop.Type);
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
                    string __tmp36_line = " "; //116:36
                    if (!string.IsNullOrEmpty(__tmp36_line))
                    {
                        __out.Write(__tmp36_line);
                        __tmp33_outputWritten = true;
                    }
                    var __tmp37 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp37.Write(prop.Name);
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
                    string __tmp38_line = " => default;"; //116:48
                    if (!string.IsNullOrEmpty(__tmp38_line))
                    {
                        __out.Write(__tmp38_line);
                        __tmp33_outputWritten = true;
                    }
                    if (__tmp33_outputWritten) __out.AppendLine(true);
                    if (__tmp33_outputWritten)
                    {
                        __out.AppendLine(false); //116:60
                    }
                }
            }
            __out.AppendLine(true); //119:1
            __out.Write("    }"); //120:1
            __out.AppendLine(false); //120:6
            __out.Write("}"); //121:1
            __out.AppendLine(false); //121:2
            return __out.ToStringAndFree();
        }

        public string GenerateCompletionSymbol(SymbolGenerationInfo symbol) //124:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //125:1
            __out.AppendLine(false); //125:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //126:1
            __out.AppendLine(false); //126:29
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //127:1
            __out.AppendLine(false); //127:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //128:1
            __out.AppendLine(false); //128:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //129:1
            __out.AppendLine(false); //129:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //130:1
            __out.AppendLine(false); //130:44
            __out.Write("using System;"); //131:1
            __out.AppendLine(false); //131:14
            __out.Write("using System.Collections.Generic;"); //132:1
            __out.AppendLine(false); //132:34
            __out.Write("using System.Collections.Immutable;"); //133:1
            __out.AppendLine(false); //133:36
            __out.Write("using System.Diagnostics;"); //134:1
            __out.AppendLine(false); //134:26
            __out.Write("using System.Text;"); //135:1
            __out.AppendLine(false); //135:19
            __out.Write("using System.Threading;"); //136:1
            __out.AppendLine(false); //136:24
            __out.Write("using Roslyn.Utilities;"); //137:1
            __out.AppendLine(false); //137:24
            __out.AppendLine(true); //138:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //139:1
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
            string __tmp5_line = ".Completion"; //139:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //139:44
            }
            __out.Write("{"); //140:1
            __out.AppendLine(false); //140:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public abstract partial class Completion"; //141:1
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
            if (symbol.ExistingCompletionTypeInfo.BaseType == null) //141:56
            {
                string __tmp11_line = " : "; //141:112
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
                string __tmp13_line = "."; //141:137
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
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //141:152
                {
                    string __tmp16_line = ", MetaDslx.CodeAnalysis.Symbols.Metadata.IModelSymbol"; //141:209
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
                __out.AppendLine(false); //141:278
            }
            __out.Write("	{"); //142:1
            __out.AppendLine(false); //142:3
            __out.Write("        public static class CompletionParts"); //143:1
            __out.AppendLine(false); //143:44
            __out.Write("        {"); //144:1
            __out.AppendLine(false); //144:10
            var __loop2_results = 
                (from partName in __Enumerate((symbol.GetCompletionPartNames()).GetEnumerator()) //145:20
                select new { partName = partName}
                ).ToList(); //145:14
            for (int __loop2_iteration = 0; __loop2_iteration < __loop2_results.Count; ++__loop2_iteration)
            {
                var __tmp19 = __loop2_results[__loop2_iteration];
                var partName = __tmp19.partName;
                bool __tmp21_outputWritten = false;
                string __tmp22_line = "            public static readonly CompletionPart "; //146:1
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
                string __tmp24_line = " = new CompletionPart(nameof("; //146:61
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
                string __tmp26_line = "));"; //146:100
                if (!string.IsNullOrEmpty(__tmp26_line))
                {
                    __out.Write(__tmp26_line);
                    __tmp21_outputWritten = true;
                }
                if (__tmp21_outputWritten) __out.AppendLine(true);
                if (__tmp21_outputWritten)
                {
                    __out.AppendLine(false); //146:103
                }
            }
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "            public static readonly ImmutableHashSet<CompletionPart> AllWithLocation = CompletionPart.Combine("; //148:1
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Write(__tmp29_line);
                __tmp28_outputWritten = true;
            }
            var __loop3_results = 
                (from partName in __Enumerate((symbol.GetOrderedCompletionParts(true)).GetEnumerator()) //148:117
                select new { partName = partName}
                ).ToList(); //148:111
            for (int __loop3_iteration = 0; __loop3_iteration < __loop3_results.Count; ++__loop3_iteration)
            {
                string comma; //148:164
                if (__loop3_iteration+1 < __loop3_results.Count) comma = ", ";
                else comma = string.Empty;
                var __tmp31 = __loop3_results[__loop3_iteration];
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
            string __tmp35_line = ");"; //148:217
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Write(__tmp35_line);
                __tmp28_outputWritten = true;
            }
            if (__tmp28_outputWritten) __out.AppendLine(true);
            if (__tmp28_outputWritten)
            {
                __out.AppendLine(false); //148:219
            }
            bool __tmp37_outputWritten = false;
            string __tmp38_line = "            public static readonly ImmutableHashSet<CompletionPart> All = CompletionPart.Combine("; //149:1
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Write(__tmp38_line);
                __tmp37_outputWritten = true;
            }
            var __loop4_results = 
                (from partName in __Enumerate((symbol.GetOrderedCompletionParts(false)).GetEnumerator()) //149:105
                select new { partName = partName}
                ).ToList(); //149:99
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                string comma; //149:153
                if (__loop4_iteration+1 < __loop4_results.Count) comma = ", ";
                else comma = string.Empty;
                var __tmp40 = __loop4_results[__loop4_iteration];
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
            string __tmp44_line = ");"; //149:206
            if (!string.IsNullOrEmpty(__tmp44_line))
            {
                __out.Write(__tmp44_line);
                __tmp37_outputWritten = true;
            }
            if (__tmp37_outputWritten) __out.AppendLine(true);
            if (__tmp37_outputWritten)
            {
                __out.AppendLine(false); //149:208
            }
            bool __tmp46_outputWritten = false;
            string __tmp47_line = "            public static readonly CompletionGraph CompletionGraph = CompletionGraph.FromCompletionParts("; //150:1
            if (!string.IsNullOrEmpty(__tmp47_line))
            {
                __out.Write(__tmp47_line);
                __tmp46_outputWritten = true;
            }
            var __loop5_results = 
                (from partName in __Enumerate((symbol.GetOrderedCompletionParts(false)).GetEnumerator()) //150:113
                select new { partName = partName}
                ).ToList(); //150:107
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                string comma; //150:161
                if (__loop5_iteration+1 < __loop5_results.Count) comma = ", ";
                else comma = string.Empty;
                var __tmp49 = __loop5_results[__loop5_iteration];
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
            string __tmp53_line = ");"; //150:214
            if (!string.IsNullOrEmpty(__tmp53_line))
            {
                __out.Write(__tmp53_line);
                __tmp46_outputWritten = true;
            }
            if (__tmp46_outputWritten) __out.AppendLine(true);
            if (__tmp46_outputWritten)
            {
                __out.AppendLine(false); //150:216
            }
            __out.Write("        }"); //151:1
            __out.AppendLine(false); //151:10
            __out.AppendLine(true); //152:1
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //153:10
            {
                __out.Write("        private readonly Symbol _container;"); //154:1
                __out.AppendLine(false); //154:44
            }
            if (symbol.ModelObjectOption != ParameterOption.Disabled) //156:10
            {
                __out.Write("        private readonly object? _modelObject;"); //157:1
                __out.AppendLine(false); //157:47
            }
            __out.Write("        private readonly CompletionState _state;"); //159:1
            __out.AppendLine(false); //159:49
            __out.Write("        private ImmutableArray<Symbol> _childSymbols;"); //160:1
            __out.AppendLine(false); //160:54
            __out.Write("        private string _name;"); //161:1
            __out.AppendLine(false); //161:30
            var __loop6_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //162:16
                select new { prop = prop}
                ).ToList(); //162:10
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp54 = __loop6_results[__loop6_iteration];
                var prop = __tmp54.prop;
                bool __tmp56_outputWritten = false;
                string __tmp57_line = "        private "; //163:1
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
                string __tmp59_line = " "; //163:28
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
                string __tmp61_line = ";"; //163:45
                if (!string.IsNullOrEmpty(__tmp61_line))
                {
                    __out.Write(__tmp61_line);
                    __tmp56_outputWritten = true;
                }
                if (__tmp56_outputWritten) __out.AppendLine(true);
                if (__tmp56_outputWritten)
                {
                    __out.AppendLine(false); //163:46
                }
            }
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //165:10
            {
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains(".ctor")) //166:10
                {
                    __out.AppendLine(true); //167:1
                    bool __tmp63_outputWritten = false;
                    string __tmp64_line = "        public Completion"; //168:1
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
                    string __tmp66_line = "(Symbol container"; //168:39
                    if (!string.IsNullOrEmpty(__tmp66_line))
                    {
                        __out.Write(__tmp66_line);
                        __tmp63_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //168:57
                    {
                        string __tmp68_line = ", object? modelObject"; //168:114
                        if (!string.IsNullOrEmpty(__tmp68_line))
                        {
                            __out.Write(__tmp68_line);
                            __tmp63_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //168:136
                        {
                            string __tmp70_line = " = null"; //168:193
                            if (!string.IsNullOrEmpty(__tmp70_line))
                            {
                                __out.Write(__tmp70_line);
                                __tmp63_outputWritten = true;
                            }
                        }
                    }
                    string __tmp73_line = ")"; //168:216
                    if (!string.IsNullOrEmpty(__tmp73_line))
                    {
                        __out.Write(__tmp73_line);
                        __tmp63_outputWritten = true;
                    }
                    if (__tmp63_outputWritten) __out.AppendLine(true);
                    if (__tmp63_outputWritten)
                    {
                        __out.AppendLine(false); //168:217
                    }
                    __out.Write("        {"); //169:1
                    __out.AppendLine(false); //169:10
                    __out.Write("            _container = container;"); //170:1
                    __out.AppendLine(false); //170:36
                    if (symbol.ModelObjectOption == ParameterOption.Required) //171:14
                    {
                        __out.Write("            if (modelObject is null) throw new ArgumentNullException(nameof(modelObject));"); //172:1
                        __out.AppendLine(false); //172:91
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //174:14
                    {
                        __out.Write("            _modelObject = modelObject;"); //175:1
                        __out.AppendLine(false); //175:40
                    }
                    __out.Write("            _state = CompletionParts.CompletionGraph.CreateState();"); //177:1
                    __out.AppendLine(false); //177:68
                    __out.Write("        }"); //178:1
                    __out.AppendLine(false); //178:10
                }
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains("Language")) //180:10
                {
                    __out.AppendLine(true); //181:1
                    __out.Write("        public sealed override Language Language => ContainingModule.Language;"); //182:1
                    __out.AppendLine(false); //182:79
                }
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains("SymbolFactory")) //184:10
                {
                    __out.AppendLine(true); //185:1
                    __out.Write("        public SymbolFactory SymbolFactory => ContainingModule.SymbolFactory;"); //186:1
                    __out.AppendLine(false); //186:78
                }
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //188:10
                {
                    if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ModelObject")) //189:14
                    {
                        __out.AppendLine(true); //190:1
                        __out.Write("        public object ModelObject => _modelObject;"); //191:1
                        __out.AppendLine(false); //191:51
                    }
                    if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ModelObjectType")) //193:14
                    {
                        __out.AppendLine(true); //194:1
                        __out.Write("        public Type ModelObjectType => _modelObject is not null ? Language.SymbolFacts.GetModelObjectType(_modelObject) : null;"); //195:1
                        __out.AppendLine(false); //195:128
                    }
                }
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ContainingSymbol")) //198:10
                {
                    __out.AppendLine(true); //199:1
                    __out.Write("        public sealed override Symbol ContainingSymbol => _container;"); //200:1
                    __out.AppendLine(false); //200:70
                }
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ChildSymbols")) //203:10
            {
                __out.AppendLine(true); //204:1
                __out.Write("        public sealed override ImmutableArray<Symbol> ChildSymbols "); //205:1
                __out.AppendLine(false); //205:68
                __out.Write("        {"); //206:1
                __out.AppendLine(false); //206:10
                __out.Write("            get"); //207:1
                __out.AppendLine(false); //207:16
                __out.Write("            {"); //208:1
                __out.AppendLine(false); //208:14
                __out.Write("                this.ForceComplete(CompletionGraph.FinishCreatingChildren, null, default);"); //209:1
                __out.AppendLine(false); //209:91
                __out.Write("                return _childSymbols;"); //210:1
                __out.AppendLine(false); //210:38
                __out.Write("            }"); //211:1
                __out.AppendLine(false); //211:14
                __out.Write("        }"); //212:1
                __out.AppendLine(false); //212:10
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("Name")) //214:10
            {
                __out.AppendLine(true); //215:1
                __out.Write("        public override string Name "); //216:1
                __out.AppendLine(false); //216:37
                __out.Write("        {"); //217:1
                __out.AppendLine(false); //217:10
                __out.Write("            get"); //218:1
                __out.AppendLine(false); //218:16
                __out.Write("            {"); //219:1
                __out.AppendLine(false); //219:14
                __out.Write("                this.ForceComplete(CompletionGraph.FinishInitializing, null, default);"); //220:1
                __out.AppendLine(false); //220:87
                __out.Write("                return _name;"); //221:1
                __out.AppendLine(false); //221:30
                __out.Write("            }"); //222:1
                __out.AppendLine(false); //222:14
                __out.Write("        }"); //223:1
                __out.AppendLine(false); //223:10
            }
            var __loop7_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //225:16
                select new { prop = prop}
                ).ToList(); //225:10
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                var __tmp74 = __loop7_results[__loop7_iteration];
                var prop = __tmp74.prop;
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains(prop.Name)) //226:14
                {
                    __out.AppendLine(true); //227:1
                    bool __tmp76_outputWritten = false;
                    string __tmp77_line = "        public override "; //228:1
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
                    string __tmp79_line = " "; //228:36
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
                        __out.AppendLine(false); //228:48
                    }
                    __out.Write("        {"); //229:1
                    __out.AppendLine(false); //229:10
                    __out.Write("            get"); //230:1
                    __out.AppendLine(false); //230:16
                    __out.Write("            {"); //231:1
                    __out.AppendLine(false); //231:14
                    bool __tmp82_outputWritten = false;
                    string __tmp83_line = "                this.ForceComplete(CompletionParts."; //232:1
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
                    string __tmp85_line = ", null, default);"; //232:83
                    if (!string.IsNullOrEmpty(__tmp85_line))
                    {
                        __out.Write(__tmp85_line);
                        __tmp82_outputWritten = true;
                    }
                    if (__tmp82_outputWritten) __out.AppendLine(true);
                    if (__tmp82_outputWritten)
                    {
                        __out.AppendLine(false); //232:100
                    }
                    bool __tmp87_outputWritten = false;
                    string __tmp88_line = "                return "; //233:1
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
                    string __tmp90_line = ";"; //233:40
                    if (!string.IsNullOrEmpty(__tmp90_line))
                    {
                        __out.Write(__tmp90_line);
                        __tmp87_outputWritten = true;
                    }
                    if (__tmp87_outputWritten) __out.AppendLine(true);
                    if (__tmp87_outputWritten)
                    {
                        __out.AppendLine(false); //233:41
                    }
                    __out.Write("            }"); //234:1
                    __out.AppendLine(false); //234:14
                    __out.Write("        }"); //235:1
                    __out.AppendLine(false); //235:10
                }
            }
            __out.AppendLine(true); //238:1
            __out.Write("        #region Completion"); //239:1
            __out.AppendLine(false); //239:27
            __out.AppendLine(true); //240:1
            __out.Write("        public sealed override bool RequiresCompletion => true;"); //241:1
            __out.AppendLine(false); //241:64
            __out.AppendLine(true); //242:1
            __out.Write("        public sealed override bool HasComplete(CompletionPart part)"); //243:1
            __out.AppendLine(false); //243:69
            __out.Write("        {"); //244:1
            __out.AppendLine(false); //244:10
            __out.Write("            return _state.HasComplete(part);"); //245:1
            __out.AppendLine(false); //245:45
            __out.Write("        }"); //246:1
            __out.AppendLine(false); //246:10
            __out.AppendLine(true); //247:1
            __out.Write("        public override void ForceComplete(CompletionPart completionPart, SourceLocation locationOpt, CancellationToken cancellationToken)"); //248:1
            __out.AppendLine(false); //248:139
            __out.Write("        {"); //249:1
            __out.AppendLine(false); //249:10
            __out.Write("            if (completionPart != null && _state.HasComplete(completionPart)) return;"); //250:1
            __out.AppendLine(false); //250:86
            __out.Write("            if (completionPart != null && !CompletionParts.All.Contains(completionPart)) throw new ArgumentException(nameof(completionPart));"); //251:1
            __out.AppendLine(false); //251:142
            __out.Write("            while (true)"); //252:1
            __out.AppendLine(false); //252:25
            __out.Write("            {"); //253:1
            __out.AppendLine(false); //253:14
            __out.Write("                cancellationToken.ThrowIfCancellationRequested();"); //254:1
            __out.AppendLine(false); //254:66
            __out.Write("                var incompletePart = _state.NextIncompletePart;"); //255:1
            __out.AppendLine(false); //255:64
            __out.Write("                if (incompletePart == CompletionGraph.StartInitializing || incompletePart == CompletionGraph.FinishInitializing)"); //256:1
            __out.AppendLine(false); //256:129
            __out.Write("                {"); //257:1
            __out.AppendLine(false); //257:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartInitializing))"); //258:1
            __out.AppendLine(false); //258:84
            __out.Write("                    {"); //259:1
            __out.AppendLine(false); //259:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //260:1
            __out.AppendLine(false); //260:71
            __out.Write("                        _name = CompleteSymbolProperty_Name(diagnostics, cancellationToken);"); //261:1
            __out.AppendLine(false); //261:93
            __out.Write("                        CompleteInitializingSymbol(diagnostics, cancellationToken);"); //262:1
            __out.AppendLine(false); //262:84
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //263:1
            __out.AppendLine(false); //263:59
            __out.Write("                        diagnostics.Free();"); //264:1
            __out.AppendLine(false); //264:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishInitializing);"); //265:1
            __out.AppendLine(false); //265:85
            __out.Write("                    }"); //266:1
            __out.AppendLine(false); //266:22
            __out.Write("                }"); //267:1
            __out.AppendLine(false); //267:18
            __out.Write("                else if (incompletePart == CompletionGraph.StartCreatingChildren || incompletePart == CompletionGraph.FinishCreatingChildren)"); //268:1
            __out.AppendLine(false); //268:142
            __out.Write("                {"); //269:1
            __out.AppendLine(false); //269:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartCreatingChildren))"); //270:1
            __out.AppendLine(false); //270:88
            __out.Write("                    {"); //271:1
            __out.AppendLine(false); //271:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //272:1
            __out.AppendLine(false); //272:71
            __out.Write("                        _childSymbols = CompleteCreatingChildSymbols(diagnostics, cancellationToken);"); //273:1
            __out.AppendLine(false); //273:102
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //274:1
            __out.AppendLine(false); //274:59
            __out.Write("                        diagnostics.Free();"); //275:1
            __out.AppendLine(false); //275:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishCreatingChildren);"); //276:1
            __out.AppendLine(false); //276:89
            __out.Write("                    }"); //277:1
            __out.AppendLine(false); //277:22
            __out.Write("                }"); //278:1
            __out.AppendLine(false); //278:18
            var __loop8_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //279:24
                select new { part = part}
                ).ToList(); //279:18
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp91 = __loop8_results[__loop8_iteration];
                var part = __tmp91.part;
                if (part.IsLocked) //280:22
                {
                    bool __tmp93_outputWritten = false;
                    string __tmp94_line = "                else if (incompletePart == CompletionParts."; //281:1
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
                    string __tmp96_line = " || incompletePart == CompletionParts."; //281:90
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
                    string __tmp98_line = ")"; //281:159
                    if (!string.IsNullOrEmpty(__tmp98_line))
                    {
                        __out.Write(__tmp98_line);
                        __tmp93_outputWritten = true;
                    }
                    if (__tmp93_outputWritten) __out.AppendLine(true);
                    if (__tmp93_outputWritten)
                    {
                        __out.AppendLine(false); //281:160
                    }
                    __out.Write("                {"); //282:1
                    __out.AppendLine(false); //282:18
                    bool __tmp100_outputWritten = false;
                    string __tmp101_line = "                    if (_state.NotePartComplete(CompletionParts."; //283:1
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
                    string __tmp103_line = "))"; //283:95
                    if (!string.IsNullOrEmpty(__tmp103_line))
                    {
                        __out.Write(__tmp103_line);
                        __tmp100_outputWritten = true;
                    }
                    if (__tmp100_outputWritten) __out.AppendLine(true);
                    if (__tmp100_outputWritten)
                    {
                        __out.AppendLine(false); //283:97
                    }
                    __out.Write("                    {"); //284:1
                    __out.AppendLine(false); //284:22
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //285:26
                    {
                        __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //286:1
                        __out.AppendLine(false); //286:71
                    }
                    bool __tmp105_outputWritten = false;
                    string __tmp104Prefix = "                        "; //288:1
                    if (part is SymbolPropertyGenerationInfo) //288:26
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
                        string __tmp108_line = " = "; //288:116
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
                    string __tmp111_line = "("; //288:152
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
                    string __tmp113_line = ");"; //288:181
                    if (!string.IsNullOrEmpty(__tmp113_line))
                    {
                        __out.Write(__tmp113_line);
                        __tmp105_outputWritten = true;
                    }
                    if (__tmp105_outputWritten) __out.AppendLine(true);
                    if (__tmp105_outputWritten)
                    {
                        __out.AppendLine(false); //288:183
                    }
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //289:26
                    {
                        __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //290:1
                        __out.AppendLine(false); //290:59
                        __out.Write("                        diagnostics.Free();"); //291:1
                        __out.AppendLine(false); //291:44
                    }
                    bool __tmp115_outputWritten = false;
                    string __tmp116_line = "                        _state.NotePartComplete(CompletionParts."; //293:1
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
                    string __tmp118_line = ");"; //293:96
                    if (!string.IsNullOrEmpty(__tmp118_line))
                    {
                        __out.Write(__tmp118_line);
                        __tmp115_outputWritten = true;
                    }
                    if (__tmp115_outputWritten) __out.AppendLine(true);
                    if (__tmp115_outputWritten)
                    {
                        __out.AppendLine(false); //293:98
                    }
                    __out.Write("                    }"); //294:1
                    __out.AppendLine(false); //294:22
                    __out.Write("                }"); //295:1
                    __out.AppendLine(false); //295:18
                }
                else //296:22
                {
                    bool __tmp120_outputWritten = false;
                    string __tmp121_line = "                else if (incompletePart == CompletionParts."; //297:1
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
                    string __tmp123_line = ")"; //297:85
                    if (!string.IsNullOrEmpty(__tmp123_line))
                    {
                        __out.Write(__tmp123_line);
                        __tmp120_outputWritten = true;
                    }
                    if (__tmp120_outputWritten) __out.AppendLine(true);
                    if (__tmp120_outputWritten)
                    {
                        __out.AppendLine(false); //297:86
                    }
                    __out.Write("                {"); //298:1
                    __out.AppendLine(false); //298:18
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //299:22
                    {
                        __out.Write("                    var diagnostics = DiagnosticBag.GetInstance();"); //300:1
                        __out.AppendLine(false); //300:67
                    }
                    bool __tmp125_outputWritten = false;
                    string __tmp124Prefix = "                    "; //302:1
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
                    string __tmp127_line = "("; //302:46
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
                    string __tmp129_line = ");"; //302:75
                    if (!string.IsNullOrEmpty(__tmp129_line))
                    {
                        __out.Write(__tmp129_line);
                        __tmp125_outputWritten = true;
                    }
                    if (__tmp125_outputWritten) __out.AppendLine(true);
                    if (__tmp125_outputWritten)
                    {
                        __out.AppendLine(false); //302:77
                    }
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //303:22
                    {
                        __out.Write("                    AddSymbolDiagnostics(diagnostics);"); //304:1
                        __out.AppendLine(false); //304:55
                        __out.Write("                    diagnostics.Free();"); //305:1
                        __out.AppendLine(false); //305:40
                    }
                    bool __tmp131_outputWritten = false;
                    string __tmp132_line = "                    _state.NotePartComplete(CompletionParts."; //307:1
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
                    string __tmp134_line = ");"; //307:86
                    if (!string.IsNullOrEmpty(__tmp134_line))
                    {
                        __out.Write(__tmp134_line);
                        __tmp131_outputWritten = true;
                    }
                    if (__tmp131_outputWritten) __out.AppendLine(true);
                    if (__tmp131_outputWritten)
                    {
                        __out.AppendLine(false); //307:88
                    }
                    __out.Write("                }"); //308:1
                    __out.AppendLine(false); //308:18
                }
            }
            __out.Write("                else if (incompletePart == CompletionGraph.StartComputingNonSymbolProperties || incompletePart == CompletionGraph.FinishComputingNonSymbolProperties)"); //311:1
            __out.AppendLine(false); //311:166
            __out.Write("                {"); //312:1
            __out.AppendLine(false); //312:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartComputingNonSymbolProperties))"); //313:1
            __out.AppendLine(false); //313:100
            __out.Write("                    {"); //314:1
            __out.AppendLine(false); //314:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //315:1
            __out.AppendLine(false); //315:71
            __out.Write("                        CompleteNonSymbolProperties(locationOpt, diagnostics, cancellationToken);"); //316:1
            __out.AppendLine(false); //316:98
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //317:1
            __out.AppendLine(false); //317:59
            __out.Write("                        diagnostics.Free();"); //318:1
            __out.AppendLine(false); //318:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishComputingNonSymbolProperties);"); //319:1
            __out.AppendLine(false); //319:101
            __out.Write("                    }"); //320:1
            __out.AppendLine(false); //320:22
            __out.Write("                }"); //321:1
            __out.AppendLine(false); //321:18
            __out.Write("                else if (incompletePart == CompletionGraph.ChildrenCompleted)"); //322:1
            __out.AppendLine(false); //322:78
            __out.Write("                {"); //323:1
            __out.AppendLine(false); //323:18
            __out.Write("                    var diagnostics = DiagnosticBag.GetInstance();"); //324:1
            __out.AppendLine(false); //324:67
            __out.Write("                    CompleteImports(locationOpt, diagnostics, cancellationToken);"); //325:1
            __out.AppendLine(false); //325:82
            __out.Write("                    AddSymbolDiagnostics(diagnostics);"); //326:1
            __out.AppendLine(false); //326:55
            __out.Write("                    diagnostics.Free();"); //327:1
            __out.AppendLine(false); //327:40
            __out.Write("                    bool allCompleted = true;"); //329:1
            __out.AppendLine(false); //329:46
            __out.Write("                    if (locationOpt == null)"); //330:1
            __out.AppendLine(false); //330:45
            __out.Write("                    {"); //331:1
            __out.AppendLine(false); //331:22
            __out.Write("                        foreach (var child in _childSymbols)"); //332:1
            __out.AppendLine(false); //332:61
            __out.Write("                        {"); //333:1
            __out.AppendLine(false); //333:26
            __out.Write("                            cancellationToken.ThrowIfCancellationRequested();"); //334:1
            __out.AppendLine(false); //334:78
            __out.Write("                            child.ForceComplete(null, locationOpt, cancellationToken);"); //335:1
            __out.AppendLine(false); //335:87
            __out.Write("                        }"); //336:1
            __out.AppendLine(false); //336:26
            __out.Write("                    }"); //337:1
            __out.AppendLine(false); //337:22
            __out.Write("                    else"); //338:1
            __out.AppendLine(false); //338:25
            __out.Write("                    {"); //339:1
            __out.AppendLine(false); //339:22
            __out.Write("                        foreach (var child in _childSymbols)"); //340:1
            __out.AppendLine(false); //340:61
            __out.Write("                        {"); //341:1
            __out.AppendLine(false); //341:26
            __out.Write("                            ForceCompleteChildByLocation(locationOpt, child, cancellationToken);"); //342:1
            __out.AppendLine(false); //342:97
            __out.Write("                            allCompleted = allCompleted && child.HasComplete(CompletionGraph.All);"); //343:1
            __out.AppendLine(false); //343:99
            __out.Write("                        }"); //344:1
            __out.AppendLine(false); //344:26
            __out.Write("                    }"); //345:1
            __out.AppendLine(false); //345:22
            __out.Write("                    if (!allCompleted)"); //347:1
            __out.AppendLine(false); //347:39
            __out.Write("                    {"); //348:1
            __out.AppendLine(false); //348:22
            __out.Write("                        // We did not complete all members, so just kick out now."); //349:1
            __out.AppendLine(false); //349:82
            __out.Write("                        var allParts = CompletionParts.AllWithLocation;"); //350:1
            __out.AppendLine(false); //350:72
            __out.Write("                        _state.SpinWaitComplete(allParts, cancellationToken);"); //351:1
            __out.AppendLine(false); //351:78
            __out.Write("                        return;"); //352:1
            __out.AppendLine(false); //352:32
            __out.Write("                    }"); //353:1
            __out.AppendLine(false); //353:22
            __out.Write("                    // We've completed all members, proceed to the next iteration."); //355:1
            __out.AppendLine(false); //355:83
            __out.Write("                    _state.NotePartComplete(CompletionGraph.ChildrenCompleted);"); //356:1
            __out.AppendLine(false); //356:80
            __out.Write("                }"); //357:1
            __out.AppendLine(false); //357:18
            __out.Write("                else if (incompletePart == null)"); //358:1
            __out.AppendLine(false); //358:49
            __out.Write("                {"); //359:1
            __out.AppendLine(false); //359:18
            __out.Write("                    return;"); //360:1
            __out.AppendLine(false); //360:28
            __out.Write("                }"); //361:1
            __out.AppendLine(false); //361:18
            __out.Write("                else"); //362:1
            __out.AppendLine(false); //362:21
            __out.Write("                {"); //363:1
            __out.AppendLine(false); //363:18
            __out.Write("                    // This assert will trigger if we forgot to handle any of the completion parts"); //364:1
            __out.AppendLine(false); //364:99
            __out.Write("                    Debug.Assert(!CompletionParts.All.Contains(incompletePart));"); //365:1
            __out.AppendLine(false); //365:81
            __out.Write("                    // any other values are completion parts intended for other kinds of symbols"); //366:1
            __out.AppendLine(false); //366:97
            __out.Write("                    _state.NotePartComplete(incompletePart);"); //367:1
            __out.AppendLine(false); //367:61
            __out.Write("                }"); //368:1
            __out.AppendLine(false); //368:18
            __out.Write("                if (completionPart != null && _state.HasComplete(completionPart)) return;"); //369:1
            __out.AppendLine(false); //369:90
            __out.Write("                _state.SpinWaitComplete(incompletePart, cancellationToken);"); //370:1
            __out.AppendLine(false); //370:76
            __out.Write("            }"); //371:1
            __out.AppendLine(false); //371:14
            __out.Write("            throw ExceptionUtilities.Unreachable;"); //372:1
            __out.AppendLine(false); //372:50
            __out.Write("        }"); //373:1
            __out.AppendLine(false); //373:10
            __out.AppendLine(true); //374:1
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteSymbolProperty_Name")) //375:10
            {
                __out.Write("        protected abstract string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //376:1
                __out.AppendLine(false); //376:127
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteInitializingSymbol")) //378:10
            {
                __out.Write("        protected abstract void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //379:1
                __out.AppendLine(false); //379:124
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteCreatingChildSymbols")) //381:10
            {
                __out.Write("        protected abstract ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //382:1
                __out.AppendLine(false); //382:144
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteImports")) //384:10
            {
                __out.Write("        protected abstract void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //385:1
                __out.AppendLine(false); //385:141
            }
            var __loop9_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //387:16
                where part.GenerateCompleteMethod //387:44
                select new { part = part}
                ).ToList(); //387:10
            for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
            {
                var __tmp135 = __loop9_results[__loop9_iteration];
                var part = __tmp135.part;
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains(part.CompleteMethodName)) //388:14
                {
                    bool __tmp137_outputWritten = false;
                    string __tmp138_line = "        protected abstract "; //389:1
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
                    string __tmp140_line = " "; //389:59
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
                    string __tmp142_line = "("; //389:85
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
                    string __tmp144_line = ");"; //389:116
                    if (!string.IsNullOrEmpty(__tmp144_line))
                    {
                        __out.Write(__tmp144_line);
                        __tmp137_outputWritten = true;
                    }
                    if (__tmp137_outputWritten) __out.AppendLine(true);
                    if (__tmp137_outputWritten)
                    {
                        __out.AppendLine(false); //389:118
                    }
                }
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteNonSymbolProperties")) //392:10
            {
                __out.Write("        protected abstract void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //393:1
                __out.AppendLine(false); //393:153
            }
            __out.Write("        #endregion"); //395:1
            __out.AppendLine(false); //395:19
            __out.Write("    }"); //396:1
            __out.AppendLine(false); //396:6
            __out.Write("}"); //397:1
            __out.AppendLine(false); //397:2
            return __out.ToStringAndFree();
        }

        public string GenerateMetadataSymbol(SymbolGenerationInfo symbol) //400:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //401:1
            __out.AppendLine(false); //401:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //402:1
            __out.AppendLine(false); //402:29
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //403:1
            __out.AppendLine(false); //403:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //404:1
            __out.AppendLine(false); //404:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //405:1
            __out.AppendLine(false); //405:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //406:1
            __out.AppendLine(false); //406:44
            __out.Write("using System;"); //407:1
            __out.AppendLine(false); //407:14
            __out.Write("using System.Collections.Generic;"); //408:1
            __out.AppendLine(false); //408:34
            __out.Write("using System.Collections.Immutable;"); //409:1
            __out.AppendLine(false); //409:36
            __out.Write("using System.Diagnostics;"); //410:1
            __out.AppendLine(false); //410:26
            __out.Write("using System.Text;"); //411:1
            __out.AppendLine(false); //411:19
            __out.Write("using System.Threading;"); //412:1
            __out.AppendLine(false); //412:24
            __out.AppendLine(true); //413:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //414:1
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
            string __tmp5_line = ".Metadata"; //414:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //414:42
            }
            __out.Write("{"); //415:1
            __out.AppendLine(false); //415:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Metadata"; //416:1
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
            if (symbol.ExistingMetadataTypeInfo.BaseType == null) //416:45
            {
                string __tmp11_line = " : "; //416:99
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
                string __tmp13_line = ".Completion.Completion"; //416:124
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
                __out.AppendLine(false); //416:167
            }
            __out.Write("	{"); //417:1
            __out.AppendLine(false); //417:3
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //418:10
            {
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //419:10
                {
                    bool __tmp17_outputWritten = false;
                    string __tmp18_line = "        public Metadata"; //420:1
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
                    string __tmp20_line = "(Symbol container"; //420:37
                    if (!string.IsNullOrEmpty(__tmp20_line))
                    {
                        __out.Write(__tmp20_line);
                        __tmp17_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //420:55
                    {
                        string __tmp22_line = ", object modelObject"; //420:112
                        if (!string.IsNullOrEmpty(__tmp22_line))
                        {
                            __out.Write(__tmp22_line);
                            __tmp17_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //420:133
                        {
                            string __tmp24_line = " = null"; //420:190
                            if (!string.IsNullOrEmpty(__tmp24_line))
                            {
                                __out.Write(__tmp24_line);
                                __tmp17_outputWritten = true;
                            }
                        }
                    }
                    string __tmp27_line = ")"; //420:213
                    if (!string.IsNullOrEmpty(__tmp27_line))
                    {
                        __out.Write(__tmp27_line);
                        __tmp17_outputWritten = true;
                    }
                    if (__tmp17_outputWritten) __out.AppendLine(true);
                    if (__tmp17_outputWritten)
                    {
                        __out.AppendLine(false); //420:214
                    }
                    __out.Write("            : base(container"); //421:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //421:30
                    {
                        __out.Write(", modelObject"); //421:87
                    }
                    __out.Write(")"); //421:108
                    __out.AppendLine(false); //421:109
                    __out.Write("        {"); //422:1
                    __out.AppendLine(false); //422:10
                    __out.Write("        }"); //423:1
                    __out.AppendLine(false); //423:10
                }
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains("Locations")) //425:10
                {
                    __out.AppendLine(true); //426:1
                    __out.Write("        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;"); //427:1
                    __out.AppendLine(false); //427:95
                }
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains("DeclaringSyntaxReferences")) //429:10
                {
                    __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;"); //430:1
                    __out.AppendLine(false); //430:124
                }
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteSymbolProperty_Name")) //433:10
            {
                __out.AppendLine(true); //434:1
                __out.Write("        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //435:1
                __out.AppendLine(false); //435:126
                __out.Write("        {"); //436:1
                __out.AppendLine(false); //436:10
                __out.Write("            return ModelSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //437:1
                __out.AppendLine(false); //437:132
                __out.Write("        }"); //438:1
                __out.AppendLine(false); //438:10
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteInitializingSymbol")) //440:10
            {
                __out.AppendLine(true); //441:1
                __out.Write("        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //442:1
                __out.AppendLine(false); //442:123
                __out.Write("        {"); //443:1
                __out.AppendLine(false); //443:10
                __out.Write("        }"); //444:1
                __out.AppendLine(false); //444:10
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteCreatingChildSymbols")) //446:10
            {
                __out.AppendLine(true); //447:1
                __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //448:1
                __out.AppendLine(false); //448:143
                __out.Write("        {"); //449:1
                __out.AppendLine(false); //449:10
                __out.Write("            return ModelSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //450:1
                __out.AppendLine(false); //450:123
                __out.Write("        }"); //451:1
                __out.AppendLine(false); //451:10
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteImports")) //453:10
            {
                __out.AppendLine(true); //454:1
                __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //455:1
                __out.AppendLine(false); //455:140
                __out.Write("        {"); //456:1
                __out.AppendLine(false); //456:10
                __out.Write("        }"); //457:1
                __out.AppendLine(false); //457:10
            }
            var __loop10_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //459:16
                where part.GenerateCompleteMethod //459:44
                select new { part = part}
                ).ToList(); //459:10
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                var __tmp28 = __loop10_results[__loop10_iteration];
                var part = __tmp28.part;
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains(part.CompleteMethodName)) //460:14
                {
                    __out.AppendLine(true); //461:1
                    bool __tmp30_outputWritten = false;
                    string __tmp31_line = "        protected override "; //462:1
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
                    string __tmp33_line = " "; //462:59
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
                    string __tmp35_line = "("; //462:85
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
                    string __tmp37_line = ")"; //462:116
                    if (!string.IsNullOrEmpty(__tmp37_line))
                    {
                        __out.Write(__tmp37_line);
                        __tmp30_outputWritten = true;
                    }
                    if (__tmp30_outputWritten) __out.AppendLine(true);
                    if (__tmp30_outputWritten)
                    {
                        __out.AppendLine(false); //462:117
                    }
                    __out.Write("        {"); //463:1
                    __out.AppendLine(false); //463:10
                    if (part is SymbolPropertyGenerationInfo) //464:14
                    {
                        var prop = (SymbolPropertyGenerationInfo)part; //465:18
                        if (prop.IsCollection) //466:18
                        {
                            bool __tmp39_outputWritten = false;
                            string __tmp40_line = "            return ModelSymbolImplementation.AssignSymbolPropertyValues<"; //467:1
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
                            string __tmp42_line = ">(this, nameof("; //467:88
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
                            string __tmp44_line = "), diagnostics, cancellationToken);"; //467:114
                            if (!string.IsNullOrEmpty(__tmp44_line))
                            {
                                __out.Write(__tmp44_line);
                                __tmp39_outputWritten = true;
                            }
                            if (__tmp39_outputWritten) __out.AppendLine(true);
                            if (__tmp39_outputWritten)
                            {
                                __out.AppendLine(false); //467:149
                            }
                        }
                        else //468:18
                        {
                            bool __tmp46_outputWritten = false;
                            string __tmp47_line = "            return ModelSymbolImplementation.AssignSymbolPropertyValue<"; //469:1
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
                            string __tmp49_line = ">(this, nameof("; //469:83
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
                            string __tmp51_line = "), diagnostics, cancellationToken);"; //469:109
                            if (!string.IsNullOrEmpty(__tmp51_line))
                            {
                                __out.Write(__tmp51_line);
                                __tmp46_outputWritten = true;
                            }
                            if (__tmp46_outputWritten) __out.AppendLine(true);
                            if (__tmp46_outputWritten)
                            {
                                __out.AppendLine(false); //469:144
                            }
                        }
                    }
                    __out.Write("        }"); //472:1
                    __out.AppendLine(false); //472:10
                }
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteNonSymbolProperties")) //475:10
            {
                __out.AppendLine(true); //476:1
                __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //477:1
                __out.AppendLine(false); //477:152
                __out.Write("        {"); //478:1
                __out.AppendLine(false); //478:10
                __out.Write("        }"); //479:1
                __out.AppendLine(false); //479:10
            }
            __out.Write("    }"); //481:1
            __out.AppendLine(false); //481:6
            __out.Write("}"); //482:1
            __out.AppendLine(false); //482:2
            return __out.ToStringAndFree();
        }

        public string GenerateSourceSymbol(SymbolGenerationInfo symbol) //485:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //486:1
            __out.AppendLine(false); //486:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //487:1
            __out.AppendLine(false); //487:29
            __out.Write("using MetaDslx.CodeAnalysis.Binding;"); //488:1
            __out.AppendLine(false); //488:37
            __out.Write("using MetaDslx.CodeAnalysis.Binding.Binders;"); //489:1
            __out.AppendLine(false); //489:45
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //490:1
            __out.AppendLine(false); //490:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //491:1
            __out.AppendLine(false); //491:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //492:1
            __out.AppendLine(false); //492:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //493:1
            __out.AppendLine(false); //493:44
            __out.Write("using System;"); //494:1
            __out.AppendLine(false); //494:14
            __out.Write("using System.Collections.Generic;"); //495:1
            __out.AppendLine(false); //495:34
            __out.Write("using System.Collections.Immutable;"); //496:1
            __out.AppendLine(false); //496:36
            __out.Write("using System.Diagnostics;"); //497:1
            __out.AppendLine(false); //497:26
            __out.Write("using System.Linq;"); //498:1
            __out.AppendLine(false); //498:19
            __out.Write("using System.Text;"); //499:1
            __out.AppendLine(false); //499:19
            __out.Write("using System.Threading;"); //500:1
            __out.AppendLine(false); //500:24
            __out.AppendLine(true); //501:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //502:1
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
            string __tmp5_line = ".Source"; //502:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //502:40
            }
            __out.Write("{"); //503:1
            __out.AppendLine(false); //503:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Source"; //504:1
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
            if (symbol.ExistingSourceTypeInfo.BaseType == null) //504:43
            {
                string __tmp11_line = " : "; //504:95
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
                string __tmp13_line = ".Completion.Completion"; //504:120
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
                if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //504:156
                {
                    string __tmp16_line = ", MetaDslx.CodeAnalysis.Symbols.Source.ISourceSymbol"; //504:226
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
                __out.AppendLine(false); //504:294
            }
            __out.Write("	{"); //505:1
            __out.AppendLine(false); //505:3
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //506:10
            {
                __out.Write("        private readonly MergedDeclaration _declaration;"); //507:1
                __out.AppendLine(false); //507:57
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetLexicalSortKey")) //508:10
                {
                    __out.Write("        private LexicalSortKey _lazyLexicalSortKey = LexicalSortKey.NotInitialized;"); //509:1
                    __out.AppendLine(false); //509:84
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //511:10
                {
                    __out.AppendLine(true); //512:1
                    bool __tmp20_outputWritten = false;
                    string __tmp21_line = "		public Source"; //513:1
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
                    string __tmp23_line = "(Symbol containingSymbol, "; //513:29
                    if (!string.IsNullOrEmpty(__tmp23_line))
                    {
                        __out.Write(__tmp23_line);
                        __tmp20_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //513:56
                    {
                        string __tmp25_line = "object modelObject"; //513:113
                        if (!string.IsNullOrEmpty(__tmp25_line))
                        {
                            __out.Write(__tmp25_line);
                            __tmp20_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //513:132
                        {
                            string __tmp27_line = " = null"; //513:189
                            if (!string.IsNullOrEmpty(__tmp27_line))
                            {
                                __out.Write(__tmp27_line);
                                __tmp20_outputWritten = true;
                            }
                        }
                        string __tmp29_line = ", "; //513:204
                        if (!string.IsNullOrEmpty(__tmp29_line))
                        {
                            __out.Write(__tmp29_line);
                            __tmp20_outputWritten = true;
                        }
                    }
                    string __tmp31_line = "MergedDeclaration declaration)"; //513:214
                    if (!string.IsNullOrEmpty(__tmp31_line))
                    {
                        __out.Write(__tmp31_line);
                        __tmp20_outputWritten = true;
                    }
                    if (__tmp20_outputWritten) __out.AppendLine(true);
                    if (__tmp20_outputWritten)
                    {
                        __out.AppendLine(false); //513:244
                    }
                    __out.Write("            : base(containingSymbol"); //514:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //514:37
                    {
                        __out.Write(", modelObject"); //514:94
                    }
                    __out.Write(")"); //514:115
                    __out.AppendLine(false); //514:116
                    __out.Write("        {"); //515:1
                    __out.AppendLine(false); //515:10
                    __out.Write("            if (declaration is null) throw new ArgumentNullException(nameof(declaration));"); //516:1
                    __out.AppendLine(false); //516:91
                    __out.Write("            _declaration = declaration;"); //517:1
                    __out.AppendLine(false); //517:40
                    __out.Write("		}"); //518:1
                    __out.AppendLine(false); //518:4
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("MergedDeclaration")) //520:10
                {
                    __out.AppendLine(true); //521:1
                    __out.Write("        public MergedDeclaration MergedDeclaration => _declaration;"); //522:1
                    __out.AppendLine(false); //522:68
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("Locations")) //524:10
                {
                    __out.AppendLine(true); //525:1
                    __out.Write("        public override ImmutableArray<Location> Locations => _declaration.NameLocations;"); //526:1
                    __out.AppendLine(false); //526:90
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("DeclaringSyntaxReferences")) //528:10
                {
                    __out.AppendLine(true); //529:1
                    __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration.SyntaxReferences;"); //530:1
                    __out.AppendLine(false); //530:116
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetBinder")) //532:10
                {
                    __out.AppendLine(true); //533:1
                    __out.Write("        public BinderPosition<SymbolBinder> GetBinder(SyntaxReference reference)"); //534:1
                    __out.AppendLine(false); //534:81
                    __out.Write("        {"); //535:1
                    __out.AppendLine(false); //535:10
                    __out.Write("            Debug.Assert(this.DeclaringSyntaxReferences.Contains(reference));"); //536:1
                    __out.AppendLine(false); //536:78
                    __out.Write("            return FindBinders.FindSymbolBinder(this, reference);"); //537:1
                    __out.AppendLine(false); //537:66
                    __out.Write("        }"); //538:1
                    __out.AppendLine(false); //538:10
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetChildSymbol")) //540:10
                {
                    __out.AppendLine(true); //541:1
                    __out.Write("        public Symbol GetChildSymbol(SyntaxReference syntax)"); //542:1
                    __out.AppendLine(false); //542:61
                    __out.Write("        {"); //543:1
                    __out.AppendLine(false); //543:10
                    __out.Write("            foreach (var child in this.ChildSymbols)"); //544:1
                    __out.AppendLine(false); //544:53
                    __out.Write("            {"); //545:1
                    __out.AppendLine(false); //545:14
                    __out.Write("                if (child.DeclaringSyntaxReferences.Any(sr => sr.GetLocation() == syntax.GetLocation()))"); //546:1
                    __out.AppendLine(false); //546:105
                    __out.Write("                {"); //547:1
                    __out.AppendLine(false); //547:18
                    __out.Write("                    return child;"); //548:1
                    __out.AppendLine(false); //548:34
                    __out.Write("                }"); //549:1
                    __out.AppendLine(false); //549:18
                    __out.Write("            }"); //550:1
                    __out.AppendLine(false); //550:14
                    __out.Write("            return null;"); //551:1
                    __out.AppendLine(false); //551:25
                    __out.Write("        }"); //552:1
                    __out.AppendLine(false); //552:10
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetLexicalSortKey")) //554:10
                {
                    __out.Write("        public override LexicalSortKey GetLexicalSortKey()"); //555:1
                    __out.AppendLine(false); //555:59
                    __out.Write("        {"); //556:1
                    __out.AppendLine(false); //556:10
                    __out.Write("            if (!_lazyLexicalSortKey.IsInitialized)"); //557:1
                    __out.AppendLine(false); //557:52
                    __out.Write("            {"); //558:1
                    __out.AppendLine(false); //558:14
                    __out.Write("                _lazyLexicalSortKey.SetFrom(this.MergedDeclaration.GetLexicalSortKey(this.DeclaringCompilation));"); //559:1
                    __out.AppendLine(false); //559:114
                    __out.Write("            }"); //560:1
                    __out.AppendLine(false); //560:14
                    __out.Write("            return _lazyLexicalSortKey;"); //561:1
                    __out.AppendLine(false); //561:40
                    __out.Write("        }"); //562:1
                    __out.AppendLine(false); //562:10
                }
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteInitializingSymbol")) //565:10
            {
                __out.AppendLine(true); //566:1
                __out.Write("        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //567:1
                __out.AppendLine(false); //567:123
                __out.Write("        {"); //568:1
                __out.AppendLine(false); //568:10
                __out.Write("        }"); //569:1
                __out.AppendLine(false); //569:10
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteCreatingChildSymbols")) //571:10
            {
                __out.AppendLine(true); //572:1
                __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //573:1
                __out.AppendLine(false); //573:143
                __out.Write("        {"); //574:1
                __out.AppendLine(false); //574:10
                __out.Write("            return SourceSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //575:1
                __out.AppendLine(false); //575:124
                __out.Write("        }"); //576:1
                __out.AppendLine(false); //576:10
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteImports")) //578:10
            {
                __out.AppendLine(true); //579:1
                __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //580:1
                __out.AppendLine(false); //580:140
                __out.Write("        {"); //581:1
                __out.AppendLine(false); //581:10
                __out.Write("            SourceSymbolImplementation.CompleteImports(this, locationOpt, diagnostics, cancellationToken);"); //582:1
                __out.AppendLine(false); //582:107
                __out.Write("        }"); //583:1
                __out.AppendLine(false); //583:10
                __out.AppendLine(true); //584:1
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteSymbolProperty_Name")) //586:10
            {
                __out.Write("        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //587:1
                __out.AppendLine(false); //587:126
                __out.Write("        {"); //588:1
                __out.AppendLine(false); //588:10
                __out.Write("            return SourceSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //589:1
                __out.AppendLine(false); //589:133
                __out.Write("        }"); //590:1
                __out.AppendLine(false); //590:10
            }
            __out.AppendLine(true); //592:1
            var __loop11_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //593:16
                where part.GenerateCompleteMethod //593:44
                select new { part = part}
                ).ToList(); //593:10
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp32 = __loop11_results[__loop11_iteration];
                var part = __tmp32.part;
                if (!symbol.ExistingSourceTypeInfo.Members.Contains(part.CompleteMethodName)) //594:14
                {
                    bool __tmp34_outputWritten = false;
                    string __tmp35_line = "        protected override "; //595:1
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
                    string __tmp37_line = " "; //595:59
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
                    string __tmp39_line = "("; //595:85
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
                    string __tmp41_line = ")"; //595:116
                    if (!string.IsNullOrEmpty(__tmp41_line))
                    {
                        __out.Write(__tmp41_line);
                        __tmp34_outputWritten = true;
                    }
                    if (__tmp34_outputWritten) __out.AppendLine(true);
                    if (__tmp34_outputWritten)
                    {
                        __out.AppendLine(false); //595:117
                    }
                    __out.Write("        {"); //596:1
                    __out.AppendLine(false); //596:10
                    if (part is SymbolPropertyGenerationInfo) //597:14
                    {
                        var prop = (SymbolPropertyGenerationInfo)part; //598:18
                        if (prop.IsCollection) //599:18
                        {
                            bool __tmp43_outputWritten = false;
                            string __tmp44_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValues<"; //600:1
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
                            string __tmp46_line = ">(this, nameof("; //600:89
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
                            string __tmp48_line = "), diagnostics, cancellationToken);"; //600:115
                            if (!string.IsNullOrEmpty(__tmp48_line))
                            {
                                __out.Write(__tmp48_line);
                                __tmp43_outputWritten = true;
                            }
                            if (__tmp43_outputWritten) __out.AppendLine(true);
                            if (__tmp43_outputWritten)
                            {
                                __out.AppendLine(false); //600:150
                            }
                        }
                        else //601:18
                        {
                            bool __tmp50_outputWritten = false;
                            string __tmp51_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValue<"; //602:1
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
                            string __tmp53_line = ">(this, nameof("; //602:84
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
                            string __tmp55_line = "), diagnostics, cancellationToken);"; //602:110
                            if (!string.IsNullOrEmpty(__tmp55_line))
                            {
                                __out.Write(__tmp55_line);
                                __tmp50_outputWritten = true;
                            }
                            if (__tmp50_outputWritten) __out.AppendLine(true);
                            if (__tmp50_outputWritten)
                            {
                                __out.AppendLine(false); //602:145
                            }
                        }
                    }
                    __out.Write("        }"); //605:1
                    __out.AppendLine(false); //605:10
                }
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteNonSymbolProperties")) //608:10
            {
                __out.AppendLine(true); //609:1
                __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //610:1
                __out.AppendLine(false); //610:152
                __out.Write("        {"); //611:1
                __out.AppendLine(false); //611:10
                __out.Write("            SourceSymbolImplementation.AssignNonSymbolProperties(this, diagnostics, cancellationToken);"); //612:1
                __out.AppendLine(false); //612:104
                __out.Write("        }"); //613:1
                __out.AppendLine(false); //613:10
            }
            __out.Write("	}"); //615:1
            __out.AppendLine(false); //615:3
            __out.Write("}"); //616:1
            __out.AppendLine(false); //616:2
            return __out.ToStringAndFree();
        }

        public string GenerateVisitor(string namespaceName, IEnumerable<SymbolGenerationInfo> symbols) //619:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //620:1
            __out.AppendLine(false); //620:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //621:1
            __out.AppendLine(false); //621:29
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //622:1
            __out.AppendLine(false); //622:37
            __out.Write("using System;"); //623:1
            __out.AppendLine(false); //623:14
            __out.Write("using System.Collections.Generic;"); //624:1
            __out.AppendLine(false); //624:34
            __out.Write("using System.Collections.Immutable;"); //625:1
            __out.AppendLine(false); //625:36
            __out.Write("using System.Diagnostics;"); //626:1
            __out.AppendLine(false); //626:26
            __out.Write("using System.Text;"); //627:1
            __out.AppendLine(false); //627:19
            __out.Write("using System.Threading;"); //628:1
            __out.AppendLine(false); //628:24
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //630:1
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
                __out.AppendLine(false); //630:26
            }
            __out.Write("{"); //631:1
            __out.AppendLine(false); //631:2
            __out.Write("	public interface ISymbolVisitor"); //632:1
            __out.AppendLine(false); //632:33
            __out.Write("	{"); //633:1
            __out.AppendLine(false); //633:3
            var __loop12_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //634:16
                select new { symbol = symbol}
                ).ToList(); //634:10
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp5 = __loop12_results[__loop12_iteration];
                var symbol = __tmp5.symbol;
                bool __tmp7_outputWritten = false;
                string __tmp8_line = "        void Visit("; //635:1
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
                string __tmp10_line = " symbol);"; //635:33
                if (!string.IsNullOrEmpty(__tmp10_line))
                {
                    __out.Write(__tmp10_line);
                    __tmp7_outputWritten = true;
                }
                if (__tmp7_outputWritten) __out.AppendLine(true);
                if (__tmp7_outputWritten)
                {
                    __out.AppendLine(false); //635:42
                }
            }
            __out.Write("	}"); //637:1
            __out.AppendLine(false); //637:3
            __out.AppendLine(true); //638:1
            __out.Write("	public interface ISymbolVisitor<TResult>"); //639:1
            __out.AppendLine(false); //639:42
            __out.Write("	{"); //640:1
            __out.AppendLine(false); //640:3
            var __loop13_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //641:16
                select new { symbol = symbol}
                ).ToList(); //641:10
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp11 = __loop13_results[__loop13_iteration];
                var symbol = __tmp11.symbol;
                bool __tmp13_outputWritten = false;
                string __tmp14_line = "        TResult Visit("; //642:1
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
                string __tmp16_line = " symbol);"; //642:36
                if (!string.IsNullOrEmpty(__tmp16_line))
                {
                    __out.Write(__tmp16_line);
                    __tmp13_outputWritten = true;
                }
                if (__tmp13_outputWritten) __out.AppendLine(true);
                if (__tmp13_outputWritten)
                {
                    __out.AppendLine(false); //642:45
                }
            }
            __out.Write("	}"); //644:1
            __out.AppendLine(false); //644:3
            __out.AppendLine(true); //645:1
            __out.Write("	public interface ISymbolVisitor<TArgument, TResult>"); //646:1
            __out.AppendLine(false); //646:53
            __out.Write("	{"); //647:1
            __out.AppendLine(false); //647:3
            var __loop14_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //648:16
                select new { symbol = symbol}
                ).ToList(); //648:10
            for (int __loop14_iteration = 0; __loop14_iteration < __loop14_results.Count; ++__loop14_iteration)
            {
                var __tmp17 = __loop14_results[__loop14_iteration];
                var symbol = __tmp17.symbol;
                bool __tmp19_outputWritten = false;
                string __tmp20_line = "        TResult Visit("; //649:1
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
                string __tmp22_line = " symbol, TArgument argument);"; //649:36
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Write(__tmp22_line);
                    __tmp19_outputWritten = true;
                }
                if (__tmp19_outputWritten) __out.AppendLine(true);
                if (__tmp19_outputWritten)
                {
                    __out.AppendLine(false); //649:65
                }
            }
            __out.Write("	}"); //651:1
            __out.AppendLine(false); //651:3
            __out.Write("}"); //652:1
            __out.AppendLine(false); //652:2
            return __out.ToStringAndFree();
        }

    }
}

