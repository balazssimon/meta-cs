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
                if (symbol.SymbolParts.HasFlag(SymbolParts.Source)) //59:252
                {
                    string __tmp19_line = ", MetaDslx.CodeAnalysis.Symbols.Source.ISourceSymbol"; //59:304
                    if (!string.IsNullOrEmpty(__tmp19_line))
                    {
                        __out.Write(__tmp19_line);
                        __tmp7_outputWritten = true;
                    }
                }
            }
            if (__tmp7_outputWritten) __out.AppendLine(true);
            if (__tmp7_outputWritten)
            {
                __out.AppendLine(false); //59:372
            }
            __out.Write("	{"); //60:1
            __out.AppendLine(false); //60:3
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //61:10
            {
                __out.Write("        private readonly Symbol _container;"); //62:1
                __out.AppendLine(false); //62:44
                if (symbol.SymbolParts.HasFlag(SymbolParts.Source)) //63:10
                {
                    __out.Write("        private readonly MergedDeclaration? _declaration;"); //64:1
                    __out.AppendLine(false); //64:58
                }
            }
            if (symbol.ModelObjectOption != ParameterOption.Disabled) //67:10
            {
                __out.Write("        private readonly object? _modelObject;"); //68:1
                __out.AppendLine(false); //68:47
            }
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //70:10
            {
                if (!symbol.ExistingErrorTypeInfo.Members.Contains(".ctor")) //71:10
                {
                    __out.AppendLine(true); //72:1
                    bool __tmp23_outputWritten = false;
                    string __tmp24_line = "        public Error"; //73:1
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
                    string __tmp26_line = "(Symbol container"; //73:34
                    if (!string.IsNullOrEmpty(__tmp26_line))
                    {
                        __out.Write(__tmp26_line);
                        __tmp23_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //73:52
                    {
                        string __tmp28_line = ", object? modelObject = null"; //73:109
                        if (!string.IsNullOrEmpty(__tmp28_line))
                        {
                            __out.Write(__tmp28_line);
                            __tmp23_outputWritten = true;
                        }
                    }
                    string __tmp30_line = ", MergedDeclaration? declaration = null)"; //73:145
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Write(__tmp30_line);
                        __tmp23_outputWritten = true;
                    }
                    if (__tmp23_outputWritten) __out.AppendLine(true);
                    if (__tmp23_outputWritten)
                    {
                        __out.AppendLine(false); //73:185
                    }
                    __out.Write("        {"); //74:1
                    __out.AppendLine(false); //74:10
                    __out.Write("            if (container is null) throw new ArgumentNullException(nameof(container));"); //75:1
                    __out.AppendLine(false); //75:87
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
                    if (!symbol.ExistingErrorTypeInfo.Members.Contains("SpecialSymbol")) //99:14
                    {
                        __out.AppendLine(true); //100:1
                        __out.Write("        public override object? SpecialSymbol => _modelObject is not null ? Language.SymbolFacts.GetSpecialSymbol(_modelObject) : null;"); //101:1
                        __out.AppendLine(false); //101:136
                    }
                }
                if (symbol.SymbolParts.HasFlag(SymbolParts.Source)) //104:10
                {
                    __out.AppendLine(true); //105:1
                    if (!symbol.ExistingSourceTypeInfo.Members.Contains("MergedDeclaration")) //106:10
                    {
                        __out.Write("        public MergedDeclaration MergedDeclaration => _declaration;"); //107:1
                        __out.AppendLine(false); //107:68
                    }
                    if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetBinder")) //109:10
                    {
                        __out.Write("        public MetaDslx.CodeAnalysis.Binding.BinderPosition<MetaDslx.CodeAnalysis.Binding.Binders.SymbolBinder> GetBinder(SyntaxReference syntax) => default;"); //110:1
                        __out.AppendLine(false); //110:158
                    }
                    if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetChildSymbol")) //112:10
                    {
                        __out.Write("        public Symbol GetChildSymbol(SyntaxReference syntax) => null;"); //113:1
                        __out.AppendLine(false); //113:70
                    }
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("Locations")) //116:10
                {
                    __out.AppendLine(true); //117:1
                    __out.Write("        public override ImmutableArray<Location> Locations => "); //118:1
                    if (symbol.SymbolParts.HasFlag(SymbolParts.Source)) //118:64
                    {
                        __out.Write("_declaration?.NameLocations ?? ImmutableArray<Location>.Empty;"); //118:116
                    }
                    else //118:179
                    {
                        __out.Write("ImmutableArray<Location>.Empty;"); //118:184
                    }
                    __out.AppendLine(false); //118:223
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("DeclaringSyntaxReferences")) //120:10
                {
                    __out.AppendLine(true); //121:1
                    __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => "); //122:1
                    if (symbol.SymbolParts.HasFlag(SymbolParts.Source)) //122:87
                    {
                        __out.Write("_declaration?.SyntaxReferences ?? ImmutableArray<SyntaxReference>.Empty;"); //122:139
                    }
                    else //122:212
                    {
                        __out.Write("ImmutableArray<SyntaxReference>.Empty;"); //122:217
                    }
                    __out.AppendLine(false); //122:263
                }
                if (!symbol.ExistingErrorTypeInfo.Members.Contains("ContainingSymbol")) //124:10
                {
                    __out.AppendLine(true); //125:1
                    __out.Write("        public override Symbol ContainingSymbol => _container;"); //126:1
                    __out.AppendLine(false); //126:63
                }
            }
            __out.AppendLine(true); //129:1
            __out.Write("        public sealed override bool IsError => true;"); //130:1
            __out.AppendLine(false); //130:53
            if (!symbol.ExistingErrorTypeInfo.Members.Contains("ChildSymbols")) //131:10
            {
                __out.AppendLine(true); //132:1
                __out.Write("        public override ImmutableArray<Symbol> ChildSymbols => ImmutableArray<Symbol>.Empty;"); //133:1
                __out.AppendLine(false); //133:93
            }
            if (!symbol.ExistingErrorTypeInfo.Members.Contains("Name")) //135:10
            {
                __out.AppendLine(true); //136:1
                __out.Write("        public override string Name => "); //137:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //137:41
                {
                    __out.Write("_modelObject is not null ? Language.SymbolFacts.GetName(_modelObject) : string.Empty;"); //137:99
                }
                else //137:185
                {
                    __out.Write("string.Empty;"); //137:190
                }
                __out.AppendLine(false); //137:211
            }
            if (!symbol.ExistingErrorTypeInfo.Members.Contains("ErrorInfo")) //139:10
            {
                __out.AppendLine(true); //140:1
                __out.Write("        public virtual DiagnosticInfo ErrorInfo { get; }"); //141:1
                __out.AppendLine(false); //141:57
            }
            var __loop1_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //143:16
                select new { prop = prop}
                ).ToList(); //143:10
            for (int __loop1_iteration = 0; __loop1_iteration < __loop1_results.Count; ++__loop1_iteration)
            {
                var __tmp31 = __loop1_results[__loop1_iteration];
                var prop = __tmp31.prop;
                if (!symbol.ExistingErrorTypeInfo.Members.Contains(prop.Name)) //144:14
                {
                    __out.AppendLine(true); //145:1
                    bool __tmp33_outputWritten = false;
                    string __tmp34_line = "        public override "; //146:1
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
                    string __tmp36_line = " "; //146:36
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
                    string __tmp38_line = " => default;"; //146:48
                    if (!string.IsNullOrEmpty(__tmp38_line))
                    {
                        __out.Write(__tmp38_line);
                        __tmp33_outputWritten = true;
                    }
                    if (__tmp33_outputWritten) __out.AppendLine(true);
                    if (__tmp33_outputWritten)
                    {
                        __out.AppendLine(false); //146:60
                    }
                }
            }
            __out.AppendLine(true); //149:1
            __out.Write("    }"); //150:1
            __out.AppendLine(false); //150:6
            __out.Write("}"); //151:1
            __out.AppendLine(false); //151:2
            return __out.ToStringAndFree();
        }

        public string GenerateCompletionSymbol(SymbolGenerationInfo symbol) //154:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //155:1
            __out.AppendLine(false); //155:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //156:1
            __out.AppendLine(false); //156:29
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //157:1
            __out.AppendLine(false); //157:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //158:1
            __out.AppendLine(false); //158:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //159:1
            __out.AppendLine(false); //159:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //160:1
            __out.AppendLine(false); //160:44
            __out.Write("using System;"); //161:1
            __out.AppendLine(false); //161:14
            __out.Write("using System.Collections.Generic;"); //162:1
            __out.AppendLine(false); //162:34
            __out.Write("using System.Collections.Immutable;"); //163:1
            __out.AppendLine(false); //163:36
            __out.Write("using System.Diagnostics;"); //164:1
            __out.AppendLine(false); //164:26
            __out.Write("using System.Text;"); //165:1
            __out.AppendLine(false); //165:19
            __out.Write("using System.Threading;"); //166:1
            __out.AppendLine(false); //166:24
            __out.Write("using Roslyn.Utilities;"); //167:1
            __out.AppendLine(false); //167:24
            __out.AppendLine(true); //168:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //169:1
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
            string __tmp5_line = ".Completion"; //169:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //169:44
            }
            __out.Write("{"); //170:1
            __out.AppendLine(false); //170:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public abstract partial class Completion"; //171:1
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
            if (symbol.ExistingCompletionTypeInfo.BaseType == null) //171:56
            {
                string __tmp11_line = " : "; //171:112
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
                string __tmp13_line = "."; //171:137
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
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //171:152
                {
                    string __tmp16_line = ", MetaDslx.CodeAnalysis.Symbols.Metadata.IModelSymbol"; //171:209
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
                __out.AppendLine(false); //171:278
            }
            __out.Write("	{"); //172:1
            __out.AppendLine(false); //172:3
            __out.Write("        public static class CompletionParts"); //173:1
            __out.AppendLine(false); //173:44
            __out.Write("        {"); //174:1
            __out.AppendLine(false); //174:10
            var __loop2_results = 
                (from partName in __Enumerate((symbol.GetCompletionPartNames()).GetEnumerator()) //175:20
                select new { partName = partName}
                ).ToList(); //175:14
            for (int __loop2_iteration = 0; __loop2_iteration < __loop2_results.Count; ++__loop2_iteration)
            {
                var __tmp19 = __loop2_results[__loop2_iteration];
                var partName = __tmp19.partName;
                bool __tmp21_outputWritten = false;
                string __tmp22_line = "            public static readonly CompletionPart "; //176:1
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
                string __tmp24_line = " = new CompletionPart(nameof("; //176:61
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
                string __tmp26_line = "));"; //176:100
                if (!string.IsNullOrEmpty(__tmp26_line))
                {
                    __out.Write(__tmp26_line);
                    __tmp21_outputWritten = true;
                }
                if (__tmp21_outputWritten) __out.AppendLine(true);
                if (__tmp21_outputWritten)
                {
                    __out.AppendLine(false); //176:103
                }
            }
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "            public static readonly ImmutableHashSet<CompletionPart> AllWithLocation = CompletionPart.Combine("; //178:1
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Write(__tmp29_line);
                __tmp28_outputWritten = true;
            }
            var __loop3_results = 
                (from partName in __Enumerate((symbol.GetOrderedCompletionParts(true)).GetEnumerator()) //178:117
                select new { partName = partName}
                ).ToList(); //178:111
            for (int __loop3_iteration = 0; __loop3_iteration < __loop3_results.Count; ++__loop3_iteration)
            {
                string comma; //178:164
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
            string __tmp35_line = ");"; //178:217
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Write(__tmp35_line);
                __tmp28_outputWritten = true;
            }
            if (__tmp28_outputWritten) __out.AppendLine(true);
            if (__tmp28_outputWritten)
            {
                __out.AppendLine(false); //178:219
            }
            bool __tmp37_outputWritten = false;
            string __tmp38_line = "            public static readonly ImmutableHashSet<CompletionPart> All = CompletionPart.Combine("; //179:1
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Write(__tmp38_line);
                __tmp37_outputWritten = true;
            }
            var __loop4_results = 
                (from partName in __Enumerate((symbol.GetOrderedCompletionParts(false)).GetEnumerator()) //179:105
                select new { partName = partName}
                ).ToList(); //179:99
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                string comma; //179:153
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
            string __tmp44_line = ");"; //179:206
            if (!string.IsNullOrEmpty(__tmp44_line))
            {
                __out.Write(__tmp44_line);
                __tmp37_outputWritten = true;
            }
            if (__tmp37_outputWritten) __out.AppendLine(true);
            if (__tmp37_outputWritten)
            {
                __out.AppendLine(false); //179:208
            }
            bool __tmp46_outputWritten = false;
            string __tmp47_line = "            public static readonly CompletionGraph CompletionGraph = CompletionGraph.FromCompletionParts("; //180:1
            if (!string.IsNullOrEmpty(__tmp47_line))
            {
                __out.Write(__tmp47_line);
                __tmp46_outputWritten = true;
            }
            var __loop5_results = 
                (from partName in __Enumerate((symbol.GetOrderedCompletionParts(false)).GetEnumerator()) //180:113
                select new { partName = partName}
                ).ToList(); //180:107
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                string comma; //180:161
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
            string __tmp53_line = ");"; //180:214
            if (!string.IsNullOrEmpty(__tmp53_line))
            {
                __out.Write(__tmp53_line);
                __tmp46_outputWritten = true;
            }
            if (__tmp46_outputWritten) __out.AppendLine(true);
            if (__tmp46_outputWritten)
            {
                __out.AppendLine(false); //180:216
            }
            __out.Write("        }"); //181:1
            __out.AppendLine(false); //181:10
            __out.AppendLine(true); //182:1
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //183:10
            {
                __out.Write("        private readonly Symbol _container;"); //184:1
                __out.AppendLine(false); //184:44
            }
            if (symbol.ModelObjectOption != ParameterOption.Disabled) //186:10
            {
                __out.Write("        private readonly object? _modelObject;"); //187:1
                __out.AppendLine(false); //187:47
            }
            __out.Write("        private readonly CompletionState _state;"); //189:1
            __out.AppendLine(false); //189:49
            __out.Write("        private ImmutableArray<Symbol> _childSymbols;"); //190:1
            __out.AppendLine(false); //190:54
            __out.Write("        private string _name;"); //191:1
            __out.AppendLine(false); //191:30
            var __loop6_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //192:16
                select new { prop = prop}
                ).ToList(); //192:10
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp54 = __loop6_results[__loop6_iteration];
                var prop = __tmp54.prop;
                bool __tmp56_outputWritten = false;
                string __tmp57_line = "        private "; //193:1
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
                string __tmp59_line = " "; //193:28
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
                string __tmp61_line = ";"; //193:45
                if (!string.IsNullOrEmpty(__tmp61_line))
                {
                    __out.Write(__tmp61_line);
                    __tmp56_outputWritten = true;
                }
                if (__tmp56_outputWritten) __out.AppendLine(true);
                if (__tmp56_outputWritten)
                {
                    __out.AppendLine(false); //193:46
                }
            }
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //195:10
            {
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains(".ctor")) //196:10
                {
                    __out.AppendLine(true); //197:1
                    bool __tmp63_outputWritten = false;
                    string __tmp64_line = "        public Completion"; //198:1
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
                    string __tmp66_line = "(Symbol container"; //198:39
                    if (!string.IsNullOrEmpty(__tmp66_line))
                    {
                        __out.Write(__tmp66_line);
                        __tmp63_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //198:57
                    {
                        string __tmp68_line = ", object? modelObject"; //198:114
                        if (!string.IsNullOrEmpty(__tmp68_line))
                        {
                            __out.Write(__tmp68_line);
                            __tmp63_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //198:136
                        {
                            string __tmp70_line = " = null"; //198:193
                            if (!string.IsNullOrEmpty(__tmp70_line))
                            {
                                __out.Write(__tmp70_line);
                                __tmp63_outputWritten = true;
                            }
                        }
                    }
                    string __tmp73_line = ", bool isError = false)"; //198:216
                    if (!string.IsNullOrEmpty(__tmp73_line))
                    {
                        __out.Write(__tmp73_line);
                        __tmp63_outputWritten = true;
                    }
                    if (__tmp63_outputWritten) __out.AppendLine(true);
                    if (__tmp63_outputWritten)
                    {
                        __out.AppendLine(false); //198:239
                    }
                    __out.Write("        {"); //199:1
                    __out.AppendLine(false); //199:10
                    __out.Write("            _container = container;"); //200:1
                    __out.AppendLine(false); //200:36
                    if (symbol.ModelObjectOption == ParameterOption.Required) //201:14
                    {
                        __out.Write("            if (!isError && modelObject is null) throw new ArgumentNullException(nameof(modelObject));"); //202:1
                        __out.AppendLine(false); //202:103
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //204:14
                    {
                        __out.Write("            _modelObject = modelObject;"); //205:1
                        __out.AppendLine(false); //205:40
                    }
                    __out.Write("            _state = CompletionParts.CompletionGraph.CreateState();"); //207:1
                    __out.AppendLine(false); //207:68
                    __out.Write("        }"); //208:1
                    __out.AppendLine(false); //208:10
                }
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains("Language")) //210:10
                {
                    __out.AppendLine(true); //211:1
                    __out.Write("        public override Language Language => ContainingModule.Language;"); //212:1
                    __out.AppendLine(false); //212:72
                }
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains("SymbolFactory")) //214:10
                {
                    __out.AppendLine(true); //215:1
                    __out.Write("        public SymbolFactory SymbolFactory => ContainingModule.SymbolFactory;"); //216:1
                    __out.AppendLine(false); //216:78
                }
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //218:10
                {
                    if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ModelObject")) //219:14
                    {
                        __out.AppendLine(true); //220:1
                        __out.Write("        public object ModelObject => _modelObject;"); //221:1
                        __out.AppendLine(false); //221:51
                    }
                    if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ModelObjectType")) //223:14
                    {
                        __out.AppendLine(true); //224:1
                        __out.Write("        public Type ModelObjectType => _modelObject is not null ? Language.SymbolFacts.GetModelObjectType(_modelObject) : null;"); //225:1
                        __out.AppendLine(false); //225:128
                    }
                }
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ContainingSymbol")) //228:10
                {
                    __out.AppendLine(true); //229:1
                    __out.Write("        public override Symbol ContainingSymbol => _container;"); //230:1
                    __out.AppendLine(false); //230:63
                }
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("ChildSymbols")) //233:10
            {
                __out.AppendLine(true); //234:1
                __out.Write("        public override ImmutableArray<Symbol> ChildSymbols "); //235:1
                __out.AppendLine(false); //235:61
                __out.Write("        {"); //236:1
                __out.AppendLine(false); //236:10
                __out.Write("            get"); //237:1
                __out.AppendLine(false); //237:16
                __out.Write("            {"); //238:1
                __out.AppendLine(false); //238:14
                __out.Write("                this.ForceComplete(CompletionGraph.FinishCreatingChildren, null, default);"); //239:1
                __out.AppendLine(false); //239:91
                __out.Write("                return _childSymbols;"); //240:1
                __out.AppendLine(false); //240:38
                __out.Write("            }"); //241:1
                __out.AppendLine(false); //241:14
                __out.Write("        }"); //242:1
                __out.AppendLine(false); //242:10
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("Name")) //244:10
            {
                __out.AppendLine(true); //245:1
                __out.Write("        public override string Name "); //246:1
                __out.AppendLine(false); //246:37
                __out.Write("        {"); //247:1
                __out.AppendLine(false); //247:10
                __out.Write("            get"); //248:1
                __out.AppendLine(false); //248:16
                __out.Write("            {"); //249:1
                __out.AppendLine(false); //249:14
                __out.Write("                this.ForceComplete(CompletionGraph.FinishInitializing, null, default);"); //250:1
                __out.AppendLine(false); //250:87
                __out.Write("                return _name;"); //251:1
                __out.AppendLine(false); //251:30
                __out.Write("            }"); //252:1
                __out.AppendLine(false); //252:14
                __out.Write("        }"); //253:1
                __out.AppendLine(false); //253:10
            }
            var __loop7_results = 
                (from prop in __Enumerate((symbol.Properties).GetEnumerator()) //255:16
                select new { prop = prop}
                ).ToList(); //255:10
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                var __tmp74 = __loop7_results[__loop7_iteration];
                var prop = __tmp74.prop;
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains(prop.Name)) //256:14
                {
                    __out.AppendLine(true); //257:1
                    bool __tmp76_outputWritten = false;
                    string __tmp77_line = "        public override "; //258:1
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
                    string __tmp79_line = " "; //258:36
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
                        __out.AppendLine(false); //258:48
                    }
                    __out.Write("        {"); //259:1
                    __out.AppendLine(false); //259:10
                    __out.Write("            get"); //260:1
                    __out.AppendLine(false); //260:16
                    __out.Write("            {"); //261:1
                    __out.AppendLine(false); //261:14
                    bool __tmp82_outputWritten = false;
                    string __tmp83_line = "                this.ForceComplete(CompletionParts."; //262:1
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
                    string __tmp85_line = ", null, default);"; //262:83
                    if (!string.IsNullOrEmpty(__tmp85_line))
                    {
                        __out.Write(__tmp85_line);
                        __tmp82_outputWritten = true;
                    }
                    if (__tmp82_outputWritten) __out.AppendLine(true);
                    if (__tmp82_outputWritten)
                    {
                        __out.AppendLine(false); //262:100
                    }
                    bool __tmp87_outputWritten = false;
                    string __tmp88_line = "                return "; //263:1
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
                    string __tmp90_line = ";"; //263:40
                    if (!string.IsNullOrEmpty(__tmp90_line))
                    {
                        __out.Write(__tmp90_line);
                        __tmp87_outputWritten = true;
                    }
                    if (__tmp87_outputWritten) __out.AppendLine(true);
                    if (__tmp87_outputWritten)
                    {
                        __out.AppendLine(false); //263:41
                    }
                    __out.Write("            }"); //264:1
                    __out.AppendLine(false); //264:14
                    __out.Write("        }"); //265:1
                    __out.AppendLine(false); //265:10
                }
            }
            __out.AppendLine(true); //268:1
            __out.Write("        #region Completion"); //269:1
            __out.AppendLine(false); //269:27
            __out.AppendLine(true); //270:1
            __out.Write("        public sealed override bool RequiresCompletion => true;"); //271:1
            __out.AppendLine(false); //271:64
            __out.AppendLine(true); //272:1
            __out.Write("        public sealed override bool HasComplete(CompletionPart part)"); //273:1
            __out.AppendLine(false); //273:69
            __out.Write("        {"); //274:1
            __out.AppendLine(false); //274:10
            __out.Write("            return _state.HasComplete(part);"); //275:1
            __out.AppendLine(false); //275:45
            __out.Write("        }"); //276:1
            __out.AppendLine(false); //276:10
            __out.AppendLine(true); //277:1
            __out.Write("        public override void ForceComplete(CompletionPart completionPart, SourceLocation locationOpt, CancellationToken cancellationToken)"); //278:1
            __out.AppendLine(false); //278:139
            __out.Write("        {"); //279:1
            __out.AppendLine(false); //279:10
            __out.Write("            if (completionPart != null && _state.HasComplete(completionPart)) return;"); //280:1
            __out.AppendLine(false); //280:86
            __out.Write("            if (completionPart != null && !CompletionParts.All.Contains(completionPart)) throw new ArgumentException(nameof(completionPart));"); //281:1
            __out.AppendLine(false); //281:142
            __out.Write("            while (true)"); //282:1
            __out.AppendLine(false); //282:25
            __out.Write("            {"); //283:1
            __out.AppendLine(false); //283:14
            __out.Write("                cancellationToken.ThrowIfCancellationRequested();"); //284:1
            __out.AppendLine(false); //284:66
            __out.Write("                var incompletePart = _state.NextIncompletePart;"); //285:1
            __out.AppendLine(false); //285:64
            __out.Write("                if (incompletePart == CompletionGraph.StartInitializing || incompletePart == CompletionGraph.FinishInitializing)"); //286:1
            __out.AppendLine(false); //286:129
            __out.Write("                {"); //287:1
            __out.AppendLine(false); //287:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartInitializing))"); //288:1
            __out.AppendLine(false); //288:84
            __out.Write("                    {"); //289:1
            __out.AppendLine(false); //289:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //290:1
            __out.AppendLine(false); //290:71
            __out.Write("                        _name = CompleteSymbolProperty_Name(diagnostics, cancellationToken);"); //291:1
            __out.AppendLine(false); //291:93
            __out.Write("                        CompleteInitializingSymbol(diagnostics, cancellationToken);"); //292:1
            __out.AppendLine(false); //292:84
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //293:1
            __out.AppendLine(false); //293:59
            __out.Write("                        diagnostics.Free();"); //294:1
            __out.AppendLine(false); //294:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishInitializing);"); //295:1
            __out.AppendLine(false); //295:85
            __out.Write("                    }"); //296:1
            __out.AppendLine(false); //296:22
            __out.Write("                }"); //297:1
            __out.AppendLine(false); //297:18
            __out.Write("                else if (incompletePart == CompletionGraph.StartCreatingChildren || incompletePart == CompletionGraph.FinishCreatingChildren)"); //298:1
            __out.AppendLine(false); //298:142
            __out.Write("                {"); //299:1
            __out.AppendLine(false); //299:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartCreatingChildren))"); //300:1
            __out.AppendLine(false); //300:88
            __out.Write("                    {"); //301:1
            __out.AppendLine(false); //301:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //302:1
            __out.AppendLine(false); //302:71
            __out.Write("                        _childSymbols = CompleteCreatingChildSymbols(diagnostics, cancellationToken);"); //303:1
            __out.AppendLine(false); //303:102
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //304:1
            __out.AppendLine(false); //304:59
            __out.Write("                        diagnostics.Free();"); //305:1
            __out.AppendLine(false); //305:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishCreatingChildren);"); //306:1
            __out.AppendLine(false); //306:89
            __out.Write("                    }"); //307:1
            __out.AppendLine(false); //307:22
            __out.Write("                }"); //308:1
            __out.AppendLine(false); //308:18
            var __loop8_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //309:24
                select new { part = part}
                ).ToList(); //309:18
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp91 = __loop8_results[__loop8_iteration];
                var part = __tmp91.part;
                if (part.IsLocked) //310:22
                {
                    bool __tmp93_outputWritten = false;
                    string __tmp94_line = "                else if (incompletePart == CompletionParts."; //311:1
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
                    string __tmp96_line = " || incompletePart == CompletionParts."; //311:90
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
                    string __tmp98_line = ")"; //311:159
                    if (!string.IsNullOrEmpty(__tmp98_line))
                    {
                        __out.Write(__tmp98_line);
                        __tmp93_outputWritten = true;
                    }
                    if (__tmp93_outputWritten) __out.AppendLine(true);
                    if (__tmp93_outputWritten)
                    {
                        __out.AppendLine(false); //311:160
                    }
                    __out.Write("                {"); //312:1
                    __out.AppendLine(false); //312:18
                    bool __tmp100_outputWritten = false;
                    string __tmp101_line = "                    if (_state.NotePartComplete(CompletionParts."; //313:1
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
                    string __tmp103_line = "))"; //313:95
                    if (!string.IsNullOrEmpty(__tmp103_line))
                    {
                        __out.Write(__tmp103_line);
                        __tmp100_outputWritten = true;
                    }
                    if (__tmp100_outputWritten) __out.AppendLine(true);
                    if (__tmp100_outputWritten)
                    {
                        __out.AppendLine(false); //313:97
                    }
                    __out.Write("                    {"); //314:1
                    __out.AppendLine(false); //314:22
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //315:26
                    {
                        __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //316:1
                        __out.AppendLine(false); //316:71
                    }
                    bool __tmp105_outputWritten = false;
                    string __tmp104Prefix = "                        "; //318:1
                    if (part is SymbolPropertyGenerationInfo) //318:26
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
                        string __tmp108_line = " = "; //318:116
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
                    string __tmp111_line = "("; //318:152
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
                    string __tmp113_line = ");"; //318:181
                    if (!string.IsNullOrEmpty(__tmp113_line))
                    {
                        __out.Write(__tmp113_line);
                        __tmp105_outputWritten = true;
                    }
                    if (__tmp105_outputWritten) __out.AppendLine(true);
                    if (__tmp105_outputWritten)
                    {
                        __out.AppendLine(false); //318:183
                    }
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //319:26
                    {
                        __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //320:1
                        __out.AppendLine(false); //320:59
                        __out.Write("                        diagnostics.Free();"); //321:1
                        __out.AppendLine(false); //321:44
                    }
                    bool __tmp115_outputWritten = false;
                    string __tmp116_line = "                        _state.NotePartComplete(CompletionParts."; //323:1
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
                    string __tmp118_line = ");"; //323:96
                    if (!string.IsNullOrEmpty(__tmp118_line))
                    {
                        __out.Write(__tmp118_line);
                        __tmp115_outputWritten = true;
                    }
                    if (__tmp115_outputWritten) __out.AppendLine(true);
                    if (__tmp115_outputWritten)
                    {
                        __out.AppendLine(false); //323:98
                    }
                    __out.Write("                    }"); //324:1
                    __out.AppendLine(false); //324:22
                    __out.Write("                }"); //325:1
                    __out.AppendLine(false); //325:18
                }
                else //326:22
                {
                    bool __tmp120_outputWritten = false;
                    string __tmp121_line = "                else if (incompletePart == CompletionParts."; //327:1
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
                    string __tmp123_line = ")"; //327:85
                    if (!string.IsNullOrEmpty(__tmp123_line))
                    {
                        __out.Write(__tmp123_line);
                        __tmp120_outputWritten = true;
                    }
                    if (__tmp120_outputWritten) __out.AppendLine(true);
                    if (__tmp120_outputWritten)
                    {
                        __out.AppendLine(false); //327:86
                    }
                    __out.Write("                {"); //328:1
                    __out.AppendLine(false); //328:18
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //329:22
                    {
                        __out.Write("                    var diagnostics = DiagnosticBag.GetInstance();"); //330:1
                        __out.AppendLine(false); //330:67
                    }
                    bool __tmp125_outputWritten = false;
                    string __tmp124Prefix = "                    "; //332:1
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
                    string __tmp127_line = "("; //332:46
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
                    string __tmp129_line = ");"; //332:75
                    if (!string.IsNullOrEmpty(__tmp129_line))
                    {
                        __out.Write(__tmp129_line);
                        __tmp125_outputWritten = true;
                    }
                    if (__tmp125_outputWritten) __out.AppendLine(true);
                    if (__tmp125_outputWritten)
                    {
                        __out.AppendLine(false); //332:77
                    }
                    if (part.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics)) //333:22
                    {
                        __out.Write("                    AddSymbolDiagnostics(diagnostics);"); //334:1
                        __out.AppendLine(false); //334:55
                        __out.Write("                    diagnostics.Free();"); //335:1
                        __out.AppendLine(false); //335:40
                    }
                    bool __tmp131_outputWritten = false;
                    string __tmp132_line = "                    _state.NotePartComplete(CompletionParts."; //337:1
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
                    string __tmp134_line = ");"; //337:86
                    if (!string.IsNullOrEmpty(__tmp134_line))
                    {
                        __out.Write(__tmp134_line);
                        __tmp131_outputWritten = true;
                    }
                    if (__tmp131_outputWritten) __out.AppendLine(true);
                    if (__tmp131_outputWritten)
                    {
                        __out.AppendLine(false); //337:88
                    }
                    __out.Write("                }"); //338:1
                    __out.AppendLine(false); //338:18
                }
            }
            __out.Write("                else if (incompletePart == CompletionGraph.StartComputingNonSymbolProperties || incompletePart == CompletionGraph.FinishComputingNonSymbolProperties)"); //341:1
            __out.AppendLine(false); //341:166
            __out.Write("                {"); //342:1
            __out.AppendLine(false); //342:18
            __out.Write("                    if (_state.NotePartComplete(CompletionGraph.StartComputingNonSymbolProperties))"); //343:1
            __out.AppendLine(false); //343:100
            __out.Write("                    {"); //344:1
            __out.AppendLine(false); //344:22
            __out.Write("                        var diagnostics = DiagnosticBag.GetInstance();"); //345:1
            __out.AppendLine(false); //345:71
            __out.Write("                        CompleteNonSymbolProperties(locationOpt, diagnostics, cancellationToken);"); //346:1
            __out.AppendLine(false); //346:98
            __out.Write("                        AddSymbolDiagnostics(diagnostics);"); //347:1
            __out.AppendLine(false); //347:59
            __out.Write("                        diagnostics.Free();"); //348:1
            __out.AppendLine(false); //348:44
            __out.Write("                        _state.NotePartComplete(CompletionGraph.FinishComputingNonSymbolProperties);"); //349:1
            __out.AppendLine(false); //349:101
            __out.Write("                    }"); //350:1
            __out.AppendLine(false); //350:22
            __out.Write("                }"); //351:1
            __out.AppendLine(false); //351:18
            __out.Write("                else if (incompletePart == CompletionGraph.ChildrenCompleted)"); //352:1
            __out.AppendLine(false); //352:78
            __out.Write("                {"); //353:1
            __out.AppendLine(false); //353:18
            __out.Write("                    var diagnostics = DiagnosticBag.GetInstance();"); //354:1
            __out.AppendLine(false); //354:67
            __out.Write("                    CompleteImports(locationOpt, diagnostics, cancellationToken);"); //355:1
            __out.AppendLine(false); //355:82
            __out.Write("                    AddSymbolDiagnostics(diagnostics);"); //356:1
            __out.AppendLine(false); //356:55
            __out.Write("                    diagnostics.Free();"); //357:1
            __out.AppendLine(false); //357:40
            __out.Write("                    bool allCompleted = true;"); //359:1
            __out.AppendLine(false); //359:46
            __out.Write("                    if (locationOpt == null)"); //360:1
            __out.AppendLine(false); //360:45
            __out.Write("                    {"); //361:1
            __out.AppendLine(false); //361:22
            __out.Write("                        foreach (var child in _childSymbols)"); //362:1
            __out.AppendLine(false); //362:61
            __out.Write("                        {"); //363:1
            __out.AppendLine(false); //363:26
            __out.Write("                            cancellationToken.ThrowIfCancellationRequested();"); //364:1
            __out.AppendLine(false); //364:78
            __out.Write("                            child.ForceComplete(null, locationOpt, cancellationToken);"); //365:1
            __out.AppendLine(false); //365:87
            __out.Write("                        }"); //366:1
            __out.AppendLine(false); //366:26
            __out.Write("                    }"); //367:1
            __out.AppendLine(false); //367:22
            __out.Write("                    else"); //368:1
            __out.AppendLine(false); //368:25
            __out.Write("                    {"); //369:1
            __out.AppendLine(false); //369:22
            __out.Write("                        foreach (var child in _childSymbols)"); //370:1
            __out.AppendLine(false); //370:61
            __out.Write("                        {"); //371:1
            __out.AppendLine(false); //371:26
            __out.Write("                            ForceCompleteChildByLocation(locationOpt, child, cancellationToken);"); //372:1
            __out.AppendLine(false); //372:97
            __out.Write("                            allCompleted = allCompleted && child.HasComplete(CompletionGraph.All);"); //373:1
            __out.AppendLine(false); //373:99
            __out.Write("                        }"); //374:1
            __out.AppendLine(false); //374:26
            __out.Write("                    }"); //375:1
            __out.AppendLine(false); //375:22
            __out.Write("                    if (!allCompleted)"); //377:1
            __out.AppendLine(false); //377:39
            __out.Write("                    {"); //378:1
            __out.AppendLine(false); //378:22
            __out.Write("                        // We did not complete all members, so just kick out now."); //379:1
            __out.AppendLine(false); //379:82
            __out.Write("                        var allParts = CompletionParts.AllWithLocation;"); //380:1
            __out.AppendLine(false); //380:72
            __out.Write("                        _state.SpinWaitComplete(allParts, cancellationToken);"); //381:1
            __out.AppendLine(false); //381:78
            __out.Write("                        return;"); //382:1
            __out.AppendLine(false); //382:32
            __out.Write("                    }"); //383:1
            __out.AppendLine(false); //383:22
            __out.Write("                    // We've completed all members, proceed to the next iteration."); //385:1
            __out.AppendLine(false); //385:83
            __out.Write("                    _state.NotePartComplete(CompletionGraph.ChildrenCompleted);"); //386:1
            __out.AppendLine(false); //386:80
            __out.Write("                }"); //387:1
            __out.AppendLine(false); //387:18
            __out.Write("                else if (incompletePart == null)"); //388:1
            __out.AppendLine(false); //388:49
            __out.Write("                {"); //389:1
            __out.AppendLine(false); //389:18
            __out.Write("                    return;"); //390:1
            __out.AppendLine(false); //390:28
            __out.Write("                }"); //391:1
            __out.AppendLine(false); //391:18
            __out.Write("                else"); //392:1
            __out.AppendLine(false); //392:21
            __out.Write("                {"); //393:1
            __out.AppendLine(false); //393:18
            __out.Write("                    // This assert will trigger if we forgot to handle any of the completion parts"); //394:1
            __out.AppendLine(false); //394:99
            __out.Write("                    Debug.Assert(!CompletionParts.All.Contains(incompletePart));"); //395:1
            __out.AppendLine(false); //395:81
            __out.Write("                    // any other values are completion parts intended for other kinds of symbols"); //396:1
            __out.AppendLine(false); //396:97
            __out.Write("                    _state.NotePartComplete(incompletePart);"); //397:1
            __out.AppendLine(false); //397:61
            __out.Write("                }"); //398:1
            __out.AppendLine(false); //398:18
            __out.Write("                if (completionPart != null && _state.HasComplete(completionPart)) return;"); //399:1
            __out.AppendLine(false); //399:90
            __out.Write("                _state.SpinWaitComplete(incompletePart, cancellationToken);"); //400:1
            __out.AppendLine(false); //400:76
            __out.Write("            }"); //401:1
            __out.AppendLine(false); //401:14
            __out.Write("            throw ExceptionUtilities.Unreachable;"); //402:1
            __out.AppendLine(false); //402:50
            __out.Write("        }"); //403:1
            __out.AppendLine(false); //403:10
            __out.AppendLine(true); //404:1
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteSymbolProperty_Name")) //405:10
            {
                __out.Write("        protected abstract string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //406:1
                __out.AppendLine(false); //406:127
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteInitializingSymbol")) //408:10
            {
                __out.Write("        protected abstract void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //409:1
                __out.AppendLine(false); //409:124
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteCreatingChildSymbols")) //411:10
            {
                __out.Write("        protected abstract ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //412:1
                __out.AppendLine(false); //412:144
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteImports")) //414:10
            {
                __out.Write("        protected abstract void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //415:1
                __out.AppendLine(false); //415:141
            }
            var __loop9_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //417:16
                where part.GenerateCompleteMethod //417:44
                select new { part = part}
                ).ToList(); //417:10
            for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
            {
                var __tmp135 = __loop9_results[__loop9_iteration];
                var part = __tmp135.part;
                if (!symbol.ExistingCompletionTypeInfo.Members.Contains(part.CompleteMethodName)) //418:14
                {
                    bool __tmp137_outputWritten = false;
                    string __tmp138_line = "        protected abstract "; //419:1
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
                    string __tmp140_line = " "; //419:59
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
                    string __tmp142_line = "("; //419:85
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
                    string __tmp144_line = ");"; //419:116
                    if (!string.IsNullOrEmpty(__tmp144_line))
                    {
                        __out.Write(__tmp144_line);
                        __tmp137_outputWritten = true;
                    }
                    if (__tmp137_outputWritten) __out.AppendLine(true);
                    if (__tmp137_outputWritten)
                    {
                        __out.AppendLine(false); //419:118
                    }
                }
            }
            if (!symbol.ExistingCompletionTypeInfo.Members.Contains("CompleteNonSymbolProperties")) //422:10
            {
                __out.Write("        protected abstract void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);"); //423:1
                __out.AppendLine(false); //423:153
            }
            __out.Write("        #endregion"); //425:1
            __out.AppendLine(false); //425:19
            __out.Write("    }"); //426:1
            __out.AppendLine(false); //426:6
            __out.Write("}"); //427:1
            __out.AppendLine(false); //427:2
            return __out.ToStringAndFree();
        }

        public string GenerateMetadataSymbol(SymbolGenerationInfo symbol) //430:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //431:1
            __out.AppendLine(false); //431:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //432:1
            __out.AppendLine(false); //432:29
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //433:1
            __out.AppendLine(false); //433:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //434:1
            __out.AppendLine(false); //434:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //435:1
            __out.AppendLine(false); //435:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //436:1
            __out.AppendLine(false); //436:44
            __out.Write("using System;"); //437:1
            __out.AppendLine(false); //437:14
            __out.Write("using System.Collections.Generic;"); //438:1
            __out.AppendLine(false); //438:34
            __out.Write("using System.Collections.Immutable;"); //439:1
            __out.AppendLine(false); //439:36
            __out.Write("using System.Diagnostics;"); //440:1
            __out.AppendLine(false); //440:26
            __out.Write("using System.Text;"); //441:1
            __out.AppendLine(false); //441:19
            __out.Write("using System.Threading;"); //442:1
            __out.AppendLine(false); //442:24
            __out.AppendLine(true); //443:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //444:1
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
            string __tmp5_line = ".Metadata"; //444:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //444:42
            }
            __out.Write("{"); //445:1
            __out.AppendLine(false); //445:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Metadata"; //446:1
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
            if (symbol.ExistingMetadataTypeInfo.BaseType == null) //446:45
            {
                string __tmp11_line = " : "; //446:99
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
                string __tmp13_line = ".Completion.Completion"; //446:124
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
                __out.AppendLine(false); //446:167
            }
            __out.Write("	{"); //447:1
            __out.AppendLine(false); //447:3
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //448:10
            {
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //449:10
                {
                    bool __tmp17_outputWritten = false;
                    string __tmp18_line = "        public Metadata"; //450:1
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
                    string __tmp20_line = "(Symbol container"; //450:37
                    if (!string.IsNullOrEmpty(__tmp20_line))
                    {
                        __out.Write(__tmp20_line);
                        __tmp17_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //450:55
                    {
                        string __tmp22_line = ", object? modelObject"; //450:112
                        if (!string.IsNullOrEmpty(__tmp22_line))
                        {
                            __out.Write(__tmp22_line);
                            __tmp17_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //450:134
                        {
                            string __tmp24_line = " = null"; //450:191
                            if (!string.IsNullOrEmpty(__tmp24_line))
                            {
                                __out.Write(__tmp24_line);
                                __tmp17_outputWritten = true;
                            }
                        }
                    }
                    string __tmp27_line = ", bool isError = false)"; //450:214
                    if (!string.IsNullOrEmpty(__tmp27_line))
                    {
                        __out.Write(__tmp27_line);
                        __tmp17_outputWritten = true;
                    }
                    if (__tmp17_outputWritten) __out.AppendLine(true);
                    if (__tmp17_outputWritten)
                    {
                        __out.AppendLine(false); //450:237
                    }
                    __out.Write("            : base(container"); //451:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //451:30
                    {
                        __out.Write(", modelObject"); //451:87
                    }
                    __out.Write(", isError)"); //451:108
                    __out.AppendLine(false); //451:118
                    __out.Write("        {"); //452:1
                    __out.AppendLine(false); //452:10
                    __out.Write("        }"); //453:1
                    __out.AppendLine(false); //453:10
                }
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains("Locations")) //455:10
                {
                    __out.AppendLine(true); //456:1
                    __out.Write("        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;"); //457:1
                    __out.AppendLine(false); //457:95
                }
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains("DeclaringSyntaxReferences")) //459:10
                {
                    __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;"); //460:1
                    __out.AppendLine(false); //460:124
                }
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteSymbolProperty_Name")) //463:10
            {
                __out.AppendLine(true); //464:1
                __out.Write("        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //465:1
                __out.AppendLine(false); //465:126
                __out.Write("        {"); //466:1
                __out.AppendLine(false); //466:10
                __out.Write("            return ModelSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //467:1
                __out.AppendLine(false); //467:132
                __out.Write("        }"); //468:1
                __out.AppendLine(false); //468:10
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteInitializingSymbol")) //470:10
            {
                __out.AppendLine(true); //471:1
                __out.Write("        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //472:1
                __out.AppendLine(false); //472:123
                __out.Write("        {"); //473:1
                __out.AppendLine(false); //473:10
                __out.Write("        }"); //474:1
                __out.AppendLine(false); //474:10
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteCreatingChildSymbols")) //476:10
            {
                __out.AppendLine(true); //477:1
                __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //478:1
                __out.AppendLine(false); //478:143
                __out.Write("        {"); //479:1
                __out.AppendLine(false); //479:10
                __out.Write("            return ModelSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //480:1
                __out.AppendLine(false); //480:123
                __out.Write("        }"); //481:1
                __out.AppendLine(false); //481:10
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteImports")) //483:10
            {
                __out.AppendLine(true); //484:1
                __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //485:1
                __out.AppendLine(false); //485:140
                __out.Write("        {"); //486:1
                __out.AppendLine(false); //486:10
                __out.Write("        }"); //487:1
                __out.AppendLine(false); //487:10
            }
            var __loop10_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //489:16
                where part.GenerateCompleteMethod //489:44
                select new { part = part}
                ).ToList(); //489:10
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                var __tmp28 = __loop10_results[__loop10_iteration];
                var part = __tmp28.part;
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains(part.CompleteMethodName)) //490:14
                {
                    __out.AppendLine(true); //491:1
                    bool __tmp30_outputWritten = false;
                    string __tmp31_line = "        protected override "; //492:1
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
                    string __tmp33_line = " "; //492:59
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
                    string __tmp35_line = "("; //492:85
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
                    string __tmp37_line = ")"; //492:116
                    if (!string.IsNullOrEmpty(__tmp37_line))
                    {
                        __out.Write(__tmp37_line);
                        __tmp30_outputWritten = true;
                    }
                    if (__tmp30_outputWritten) __out.AppendLine(true);
                    if (__tmp30_outputWritten)
                    {
                        __out.AppendLine(false); //492:117
                    }
                    __out.Write("        {"); //493:1
                    __out.AppendLine(false); //493:10
                    if (part is SymbolPropertyGenerationInfo) //494:14
                    {
                        var prop = (SymbolPropertyGenerationInfo)part; //495:18
                        if (prop.IsCollection) //496:18
                        {
                            bool __tmp39_outputWritten = false;
                            string __tmp40_line = "            return ModelSymbolImplementation.AssignSymbolPropertyValues<"; //497:1
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
                            string __tmp42_line = ">(this, nameof("; //497:88
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
                            string __tmp44_line = "), diagnostics, cancellationToken);"; //497:114
                            if (!string.IsNullOrEmpty(__tmp44_line))
                            {
                                __out.Write(__tmp44_line);
                                __tmp39_outputWritten = true;
                            }
                            if (__tmp39_outputWritten) __out.AppendLine(true);
                            if (__tmp39_outputWritten)
                            {
                                __out.AppendLine(false); //497:149
                            }
                        }
                        else //498:18
                        {
                            bool __tmp46_outputWritten = false;
                            string __tmp47_line = "            return ModelSymbolImplementation.AssignSymbolPropertyValue<"; //499:1
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
                            string __tmp49_line = ">(this, nameof("; //499:83
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
                            string __tmp51_line = "), diagnostics, cancellationToken);"; //499:109
                            if (!string.IsNullOrEmpty(__tmp51_line))
                            {
                                __out.Write(__tmp51_line);
                                __tmp46_outputWritten = true;
                            }
                            if (__tmp46_outputWritten) __out.AppendLine(true);
                            if (__tmp46_outputWritten)
                            {
                                __out.AppendLine(false); //499:144
                            }
                        }
                    }
                    __out.Write("        }"); //502:1
                    __out.AppendLine(false); //502:10
                }
            }
            if (!symbol.ExistingMetadataTypeInfo.Members.Contains("CompleteNonSymbolProperties")) //505:10
            {
                __out.AppendLine(true); //506:1
                __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //507:1
                __out.AppendLine(false); //507:152
                __out.Write("        {"); //508:1
                __out.AppendLine(false); //508:10
                __out.Write("        }"); //509:1
                __out.AppendLine(false); //509:10
            }
            __out.AppendLine(true); //511:1
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //512:10
            {
                bool __tmp53_outputWritten = false;
                string __tmp54_line = "        public partial class Error : Metadata"; //513:1
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
                string __tmp56_line = ", MetaDslx.CodeAnalysis.Symbols.IErrorSymbol"; //513:59
                if (!string.IsNullOrEmpty(__tmp56_line))
                {
                    __out.Write(__tmp56_line);
                    __tmp53_outputWritten = true;
                }
                if (__tmp53_outputWritten) __out.AppendLine(true);
                if (__tmp53_outputWritten)
                {
                    __out.AppendLine(false); //513:103
                }
                __out.Write("        {"); //514:1
                __out.AppendLine(false); //514:10
                __out.Write("            private readonly string _name;"); //515:1
                __out.AppendLine(false); //515:43
                __out.Write("            private readonly string _metadataName;"); //516:1
                __out.AppendLine(false); //516:51
                __out.Write("            private DiagnosticInfo _errorInfo;"); //517:1
                __out.AppendLine(false); //517:47
                __out.Write("            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorKind _kind;"); //518:1
                __out.AppendLine(false); //518:76
                __out.Write("            private readonly bool _unreported;"); //519:1
                __out.AppendLine(false); //519:47
                __out.Write("            private ImmutableArray<Symbol> _candidateSymbols;  // Best guess at what user meant, but was wrong."); //520:1
                __out.AppendLine(false); //520:112
                __out.AppendLine(true); //521:1
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //522:14
                {
                    __out.Write("            public Error(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported"); //523:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //523:208
                    {
                        __out.Write(", object? modelObject"); //523:265
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //523:287
                        {
                            __out.Write(" = null"); //523:344
                        }
                    }
                    __out.Write(")"); //523:367
                    __out.AppendLine(false); //523:368
                    __out.Write("                : base(container"); //524:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //524:34
                    {
                        __out.Write(", modelObject"); //524:91
                    }
                    __out.Write(", true)"); //524:112
                    __out.AppendLine(false); //524:119
                    __out.Write("            {"); //525:1
                    __out.AppendLine(false); //525:14
                    __out.Write("                Debug.Assert(unreported == false || errorInfo != null);"); //526:1
                    __out.AppendLine(false); //526:72
                    __out.Write("                _name = name;"); //527:1
                    __out.AppendLine(false); //527:30
                    __out.Write("                _metadataName = metadataName;"); //528:1
                    __out.AppendLine(false); //528:46
                    __out.Write("                _kind = kind;"); //529:1
                    __out.AppendLine(false); //529:30
                    __out.Write("                _errorInfo = errorInfo;"); //530:1
                    __out.AppendLine(false); //530:40
                    __out.Write("                _candidateSymbols = candidateSymbols;"); //531:1
                    __out.AppendLine(false); //531:54
                    __out.Write("                _unreported = unreported;"); //532:1
                    __out.AppendLine(false); //532:42
                    __out.Write("            }"); //533:1
                    __out.AppendLine(false); //533:14
                    __out.AppendLine(true); //534:1
                    __out.Write("            protected virtual Error Update(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported"); //535:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //535:226
                    {
                        __out.Write(", object? modelObject"); //535:283
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //535:305
                        {
                            __out.Write(" = null"); //535:362
                        }
                    }
                    __out.Write(")"); //535:385
                    __out.AppendLine(false); //535:386
                    __out.Write("            {"); //536:1
                    __out.AppendLine(false); //536:14
                    __out.Write("                return new Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported"); //537:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //537:111
                    {
                        __out.Write(", modelObject"); //537:168
                    }
                    __out.Write(");"); //537:189
                    __out.AppendLine(false); //537:191
                    __out.Write("            }"); //538:1
                    __out.AppendLine(false); //538:14
                }
                __out.AppendLine(true); //540:1
                __out.Write("            public Error AsUnreported()"); //541:1
                __out.AppendLine(false); //541:40
                __out.Write("            {"); //542:1
                __out.AppendLine(false); //542:14
                __out.Write("                return this.IsUnreported ? this :"); //543:1
                __out.AppendLine(false); //543:50
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, _kind, ErrorInfo, CandidateSymbols, true"); //544:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //544:114
                {
                    __out.Write(", this.ModelObject"); //544:171
                }
                __out.Write(");"); //544:197
                __out.AppendLine(false); //544:199
                __out.Write("            }"); //545:1
                __out.AppendLine(false); //545:14
                __out.AppendLine(true); //546:1
                __out.Write("            public Error AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind)"); //547:1
                __out.AppendLine(false); //547:78
                __out.Write("            {"); //548:1
                __out.AppendLine(false); //548:14
                __out.Write("                return _kind == kind ? this :"); //549:1
                __out.AppendLine(false); //549:46
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, kind, ErrorInfo, CandidateSymbols, _unreported"); //550:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //550:120
                {
                    __out.Write(", this.ModelObject"); //550:177
                }
                __out.Write(");"); //550:203
                __out.AppendLine(false); //550:205
                __out.Write("            }"); //551:1
                __out.AppendLine(false); //551:14
                __out.AppendLine(true); //552:1
                __out.Write("            public Error AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, ImmutableArray<Symbol> candidateSymbols)"); //553:1
                __out.AppendLine(false); //553:119
                __out.Write("            {"); //554:1
                __out.AppendLine(false); //554:14
                __out.Write("                return _kind == kind && CandidateSymbols == candidateSymbols ? this :"); //555:1
                __out.AppendLine(false); //555:86
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, kind, ErrorInfo, candidateSymbols, _unreported"); //556:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //556:120
                {
                    __out.Write(", this.ModelObject"); //556:177
                }
                __out.Write(");"); //556:203
                __out.AppendLine(false); //556:205
                __out.Write("            }"); //557:1
                __out.AppendLine(false); //557:14
                __out.AppendLine(true); //558:1
                __out.Write("            public Error AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo errorInfo, ImmutableArray<Symbol> candidateSymbols)"); //559:1
                __out.AppendLine(false); //559:145
                __out.Write("            {"); //560:1
                __out.AppendLine(false); //560:14
                __out.Write("                return _kind == kind && ErrorInfo == errorInfo && CandidateSymbols == candidateSymbols ? this :"); //561:1
                __out.AppendLine(false); //561:112
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, kind, errorInfo, candidateSymbols, _unreported"); //562:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //562:120
                {
                    __out.Write(", this.ModelObject"); //562:177
                }
                __out.Write(");"); //562:203
                __out.AppendLine(false); //562:205
                __out.Write("            }"); //563:1
                __out.AppendLine(false); //563:14
                __out.AppendLine(true); //564:1
                __out.Write("            public Error WithErrorInfo(DiagnosticInfo errorInfo)"); //565:1
                __out.AppendLine(false); //565:65
                __out.Write("            {"); //566:1
                __out.AppendLine(false); //566:14
                __out.Write("                return ErrorInfo == errorInfo ? this :"); //567:1
                __out.AppendLine(false); //567:55
                __out.Write("                    Update(this.ContainingSymbol, _name, _metadataName, _kind, errorInfo, CandidateSymbols, _unreported"); //568:1
                if (symbol.ModelObjectOption != ParameterOption.Disabled) //568:121
                {
                    __out.Write(", this.ModelObject"); //568:178
                }
                __out.Write(");"); //568:204
                __out.AppendLine(false); //568:206
                __out.Write("            }"); //569:1
                __out.AppendLine(false); //569:14
                __out.AppendLine(true); //570:1
                __out.Write("            public override string Name => _name;"); //571:1
                __out.AppendLine(false); //571:50
                __out.AppendLine(true); //572:1
                __out.Write("            public override string MetadataName => _metadataName;"); //573:1
                __out.AppendLine(false); //573:66
                __out.AppendLine(true); //574:1
                __out.Write("            public sealed override bool IsError => true;"); //575:1
                __out.AppendLine(false); //575:57
                __out.AppendLine(true); //576:1
                __out.Write("            public bool IsUnreported => _unreported;"); //577:1
                __out.AppendLine(false); //577:53
                __out.AppendLine(true); //578:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.ErrorKind ErrorKind => _kind;"); //579:1
                __out.AppendLine(false); //579:79
                __out.AppendLine(true); //580:1
                __out.Write("            public ImmutableArray<Symbol> CandidateSymbols"); //581:1
                __out.AppendLine(false); //581:59
                __out.Write("            {"); //582:1
                __out.AppendLine(false); //582:14
                __out.Write("                get"); //583:1
                __out.AppendLine(false); //583:20
                __out.Write("                {"); //584:1
                __out.AppendLine(false); //584:18
                __out.Write("                    if (_candidateSymbols.IsDefault)"); //585:1
                __out.AppendLine(false); //585:53
                __out.Write("                    {"); //586:1
                __out.AppendLine(false); //586:22
                __out.Write("                        System.Collections.Immutable.ImmutableInterlocked.InterlockedInitialize(ref _candidateSymbols, MakeCandidateSymbols());"); //587:1
                __out.AppendLine(false); //587:144
                __out.Write("                    }"); //588:1
                __out.AppendLine(false); //588:22
                __out.Write("                    return _candidateSymbols;"); //589:1
                __out.AppendLine(false); //589:46
                __out.Write("                }"); //590:1
                __out.AppendLine(false); //590:18
                __out.Write("            }"); //591:1
                __out.AppendLine(false); //591:14
                __out.AppendLine(true); //592:1
                __out.Write("            public DiagnosticInfo? ErrorInfo"); //593:1
                __out.AppendLine(false); //593:45
                __out.Write("            {"); //594:1
                __out.AppendLine(false); //594:14
                __out.Write("                get"); //595:1
                __out.AppendLine(false); //595:20
                __out.Write("                {"); //596:1
                __out.AppendLine(false); //596:18
                __out.Write("                    if (_errorInfo is null)"); //597:1
                __out.AppendLine(false); //597:44
                __out.Write("                    {"); //598:1
                __out.AppendLine(false); //598:22
                __out.Write("                        System.Threading.Interlocked.CompareExchange(ref _errorInfo, MakeErrorInfo(), null);"); //599:1
                __out.AppendLine(false); //599:109
                __out.Write("                    }"); //600:1
                __out.AppendLine(false); //600:22
                __out.Write("                    return _errorInfo;"); //601:1
                __out.AppendLine(false); //601:39
                __out.Write("                }"); //602:1
                __out.AppendLine(false); //602:18
                __out.Write("            }"); //603:1
                __out.AppendLine(false); //603:14
                __out.AppendLine(true); //604:1
                __out.Write("            protected virtual DiagnosticInfo? MakeErrorInfo()"); //605:1
                __out.AppendLine(false); //605:62
                __out.Write("            {"); //606:1
                __out.AppendLine(false); //606:14
                __out.Write("                return null;"); //607:1
                __out.AppendLine(false); //607:29
                __out.Write("            }"); //608:1
                __out.AppendLine(false); //608:14
                __out.AppendLine(true); //609:1
                __out.Write("            protected virtual ImmutableArray<Symbol> MakeCandidateSymbols()"); //610:1
                __out.AppendLine(false); //610:76
                __out.Write("            {"); //611:1
                __out.AppendLine(false); //611:14
                __out.Write("                return ImmutableArray<Symbol>.Empty;"); //612:1
                __out.AppendLine(false); //612:53
                __out.Write("            }"); //613:1
                __out.AppendLine(false); //613:14
                __out.AppendLine(true); //614:1
                __out.Write("            protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //615:1
                __out.AppendLine(false); //615:130
                __out.Write("            {"); //616:1
                __out.AppendLine(false); //616:14
                __out.Write("                return _name;"); //617:1
                __out.AppendLine(false); //617:30
                __out.Write("            }"); //618:1
                __out.AppendLine(false); //618:14
                __out.Write("        }"); //619:1
                __out.AppendLine(false); //619:10
            }
            __out.Write("    }"); //621:1
            __out.AppendLine(false); //621:6
            __out.Write("}"); //622:1
            __out.AppendLine(false); //622:2
            return __out.ToStringAndFree();
        }

        public string GenerateSourceSymbol(SymbolGenerationInfo symbol) //625:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //626:1
            __out.AppendLine(false); //626:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //627:1
            __out.AppendLine(false); //627:29
            __out.Write("using MetaDslx.CodeAnalysis.Binding;"); //628:1
            __out.AppendLine(false); //628:37
            __out.Write("using MetaDslx.CodeAnalysis.Binding.Binders;"); //629:1
            __out.AppendLine(false); //629:45
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //630:1
            __out.AppendLine(false); //630:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //631:1
            __out.AppendLine(false); //631:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //632:1
            __out.AppendLine(false); //632:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //633:1
            __out.AppendLine(false); //633:44
            __out.Write("using System;"); //634:1
            __out.AppendLine(false); //634:14
            __out.Write("using System.Collections.Generic;"); //635:1
            __out.AppendLine(false); //635:34
            __out.Write("using System.Collections.Immutable;"); //636:1
            __out.AppendLine(false); //636:36
            __out.Write("using System.Diagnostics;"); //637:1
            __out.AppendLine(false); //637:26
            __out.Write("using System.Linq;"); //638:1
            __out.AppendLine(false); //638:19
            __out.Write("using System.Text;"); //639:1
            __out.AppendLine(false); //639:19
            __out.Write("using System.Threading;"); //640:1
            __out.AppendLine(false); //640:24
            __out.AppendLine(true); //641:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //642:1
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
            string __tmp5_line = ".Source"; //642:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //642:40
            }
            __out.Write("{"); //643:1
            __out.AppendLine(false); //643:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Source"; //644:1
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
            if (symbol.ExistingSourceTypeInfo.BaseType == null) //644:43
            {
                string __tmp11_line = " : "; //644:95
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
                string __tmp13_line = ".Completion.Completion"; //644:120
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
                if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //644:156
                {
                    string __tmp16_line = ", MetaDslx.CodeAnalysis.Symbols.Source.ISourceSymbol"; //644:226
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
                __out.AppendLine(false); //644:294
            }
            __out.Write("	{"); //645:1
            __out.AppendLine(false); //645:3
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //646:10
            {
                __out.Write("        private readonly MergedDeclaration _declaration;"); //647:1
                __out.AppendLine(false); //647:57
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetLexicalSortKey")) //648:10
                {
                    __out.Write("        private LexicalSortKey _lazyLexicalSortKey = LexicalSortKey.NotInitialized;"); //649:1
                    __out.AppendLine(false); //649:84
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //651:10
                {
                    __out.AppendLine(true); //652:1
                    bool __tmp20_outputWritten = false;
                    string __tmp21_line = "		public Source"; //653:1
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
                    string __tmp23_line = "(Symbol containingSymbol, MergedDeclaration declaration"; //653:29
                    if (!string.IsNullOrEmpty(__tmp23_line))
                    {
                        __out.Write(__tmp23_line);
                        __tmp20_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //653:85
                    {
                        string __tmp25_line = ", object? modelObject"; //653:142
                        if (!string.IsNullOrEmpty(__tmp25_line))
                        {
                            __out.Write(__tmp25_line);
                            __tmp20_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //653:164
                        {
                            string __tmp27_line = " = null"; //653:221
                            if (!string.IsNullOrEmpty(__tmp27_line))
                            {
                                __out.Write(__tmp27_line);
                                __tmp20_outputWritten = true;
                            }
                        }
                    }
                    string __tmp30_line = ", bool isError = false)"; //653:244
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Write(__tmp30_line);
                        __tmp20_outputWritten = true;
                    }
                    if (__tmp20_outputWritten) __out.AppendLine(true);
                    if (__tmp20_outputWritten)
                    {
                        __out.AppendLine(false); //653:267
                    }
                    __out.Write("            : base(containingSymbol"); //654:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //654:37
                    {
                        __out.Write(", modelObject"); //654:94
                    }
                    __out.Write(", isError)"); //654:115
                    __out.AppendLine(false); //654:125
                    __out.Write("        {"); //655:1
                    __out.AppendLine(false); //655:10
                    __out.Write("            if (declaration is null) throw new ArgumentNullException(nameof(declaration));"); //656:1
                    __out.AppendLine(false); //656:91
                    __out.Write("            _declaration = declaration;"); //657:1
                    __out.AppendLine(false); //657:40
                    __out.Write("		}"); //658:1
                    __out.AppendLine(false); //658:4
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("MergedDeclaration")) //660:10
                {
                    __out.AppendLine(true); //661:1
                    __out.Write("        public MergedDeclaration MergedDeclaration => _declaration;"); //662:1
                    __out.AppendLine(false); //662:68
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("Locations")) //664:10
                {
                    __out.AppendLine(true); //665:1
                    __out.Write("        public override ImmutableArray<Location> Locations => _declaration.NameLocations;"); //666:1
                    __out.AppendLine(false); //666:90
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("DeclaringSyntaxReferences")) //668:10
                {
                    __out.AppendLine(true); //669:1
                    __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration.SyntaxReferences;"); //670:1
                    __out.AppendLine(false); //670:116
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetBinder")) //672:10
                {
                    __out.AppendLine(true); //673:1
                    __out.Write("        public BinderPosition<SymbolBinder> GetBinder(SyntaxReference reference)"); //674:1
                    __out.AppendLine(false); //674:81
                    __out.Write("        {"); //675:1
                    __out.AppendLine(false); //675:10
                    __out.Write("            Debug.Assert(this.DeclaringSyntaxReferences.Contains(reference));"); //676:1
                    __out.AppendLine(false); //676:78
                    __out.Write("            return FindBinders.FindSymbolBinder(this, reference);"); //677:1
                    __out.AppendLine(false); //677:66
                    __out.Write("        }"); //678:1
                    __out.AppendLine(false); //678:10
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetChildSymbol")) //680:10
                {
                    __out.AppendLine(true); //681:1
                    __out.Write("        public Symbol GetChildSymbol(SyntaxReference syntax)"); //682:1
                    __out.AppendLine(false); //682:61
                    __out.Write("        {"); //683:1
                    __out.AppendLine(false); //683:10
                    __out.Write("            foreach (var child in this.ChildSymbols)"); //684:1
                    __out.AppendLine(false); //684:53
                    __out.Write("            {"); //685:1
                    __out.AppendLine(false); //685:14
                    __out.Write("                if (child.DeclaringSyntaxReferences.Any(sr => sr.GetLocation() == syntax.GetLocation()))"); //686:1
                    __out.AppendLine(false); //686:105
                    __out.Write("                {"); //687:1
                    __out.AppendLine(false); //687:18
                    __out.Write("                    return child;"); //688:1
                    __out.AppendLine(false); //688:34
                    __out.Write("                }"); //689:1
                    __out.AppendLine(false); //689:18
                    __out.Write("            }"); //690:1
                    __out.AppendLine(false); //690:14
                    __out.Write("            return null;"); //691:1
                    __out.AppendLine(false); //691:25
                    __out.Write("        }"); //692:1
                    __out.AppendLine(false); //692:10
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetLexicalSortKey")) //694:10
                {
                    __out.Write("        public override LexicalSortKey GetLexicalSortKey()"); //695:1
                    __out.AppendLine(false); //695:59
                    __out.Write("        {"); //696:1
                    __out.AppendLine(false); //696:10
                    __out.Write("            if (!_lazyLexicalSortKey.IsInitialized)"); //697:1
                    __out.AppendLine(false); //697:52
                    __out.Write("            {"); //698:1
                    __out.AppendLine(false); //698:14
                    __out.Write("                _lazyLexicalSortKey.SetFrom(this.MergedDeclaration.GetLexicalSortKey(this.DeclaringCompilation));"); //699:1
                    __out.AppendLine(false); //699:114
                    __out.Write("            }"); //700:1
                    __out.AppendLine(false); //700:14
                    __out.Write("            return _lazyLexicalSortKey;"); //701:1
                    __out.AppendLine(false); //701:40
                    __out.Write("        }"); //702:1
                    __out.AppendLine(false); //702:10
                }
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteInitializingSymbol")) //705:10
            {
                __out.AppendLine(true); //706:1
                __out.Write("        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //707:1
                __out.AppendLine(false); //707:123
                __out.Write("        {"); //708:1
                __out.AppendLine(false); //708:10
                __out.Write("        }"); //709:1
                __out.AppendLine(false); //709:10
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteCreatingChildSymbols")) //711:10
            {
                __out.AppendLine(true); //712:1
                __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //713:1
                __out.AppendLine(false); //713:143
                __out.Write("        {"); //714:1
                __out.AppendLine(false); //714:10
                __out.Write("            return SourceSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //715:1
                __out.AppendLine(false); //715:124
                __out.Write("        }"); //716:1
                __out.AppendLine(false); //716:10
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteImports")) //718:10
            {
                __out.AppendLine(true); //719:1
                __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //720:1
                __out.AppendLine(false); //720:140
                __out.Write("        {"); //721:1
                __out.AppendLine(false); //721:10
                __out.Write("            SourceSymbolImplementation.CompleteImports(this, locationOpt, diagnostics, cancellationToken);"); //722:1
                __out.AppendLine(false); //722:107
                __out.Write("        }"); //723:1
                __out.AppendLine(false); //723:10
                __out.AppendLine(true); //724:1
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteSymbolProperty_Name")) //726:10
            {
                __out.Write("        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //727:1
                __out.AppendLine(false); //727:126
                __out.Write("        {"); //728:1
                __out.AppendLine(false); //728:10
                __out.Write("            return SourceSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //729:1
                __out.AppendLine(false); //729:133
                __out.Write("        }"); //730:1
                __out.AppendLine(false); //730:10
            }
            __out.AppendLine(true); //732:1
            var __loop11_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //733:16
                where part.GenerateCompleteMethod //733:44
                select new { part = part}
                ).ToList(); //733:10
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp31 = __loop11_results[__loop11_iteration];
                var part = __tmp31.part;
                if (!symbol.ExistingSourceTypeInfo.Members.Contains(part.CompleteMethodName)) //734:14
                {
                    bool __tmp33_outputWritten = false;
                    string __tmp34_line = "        protected override "; //735:1
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
                    string __tmp36_line = " "; //735:59
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
                    string __tmp38_line = "("; //735:85
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
                    string __tmp40_line = ")"; //735:116
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Write(__tmp40_line);
                        __tmp33_outputWritten = true;
                    }
                    if (__tmp33_outputWritten) __out.AppendLine(true);
                    if (__tmp33_outputWritten)
                    {
                        __out.AppendLine(false); //735:117
                    }
                    __out.Write("        {"); //736:1
                    __out.AppendLine(false); //736:10
                    if (part is SymbolPropertyGenerationInfo) //737:14
                    {
                        var prop = (SymbolPropertyGenerationInfo)part; //738:18
                        if (prop.IsCollection) //739:18
                        {
                            bool __tmp42_outputWritten = false;
                            string __tmp43_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValues<"; //740:1
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
                            string __tmp45_line = ">(this, nameof("; //740:89
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
                            string __tmp47_line = "), diagnostics, cancellationToken);"; //740:115
                            if (!string.IsNullOrEmpty(__tmp47_line))
                            {
                                __out.Write(__tmp47_line);
                                __tmp42_outputWritten = true;
                            }
                            if (__tmp42_outputWritten) __out.AppendLine(true);
                            if (__tmp42_outputWritten)
                            {
                                __out.AppendLine(false); //740:150
                            }
                        }
                        else //741:18
                        {
                            bool __tmp49_outputWritten = false;
                            string __tmp50_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValue<"; //742:1
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
                            string __tmp52_line = ">(this, nameof("; //742:84
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
                            string __tmp54_line = "), diagnostics, cancellationToken);"; //742:110
                            if (!string.IsNullOrEmpty(__tmp54_line))
                            {
                                __out.Write(__tmp54_line);
                                __tmp49_outputWritten = true;
                            }
                            if (__tmp49_outputWritten) __out.AppendLine(true);
                            if (__tmp49_outputWritten)
                            {
                                __out.AppendLine(false); //742:145
                            }
                        }
                    }
                    __out.Write("        }"); //745:1
                    __out.AppendLine(false); //745:10
                }
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteNonSymbolProperties")) //748:10
            {
                __out.AppendLine(true); //749:1
                __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //750:1
                __out.AppendLine(false); //750:152
                __out.Write("        {"); //751:1
                __out.AppendLine(false); //751:10
                __out.Write("            SourceSymbolImplementation.AssignNonSymbolProperties(this, diagnostics, cancellationToken);"); //752:1
                __out.AppendLine(false); //752:104
                __out.Write("        }"); //753:1
                __out.AppendLine(false); //753:10
            }
            __out.AppendLine(true); //755:1
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //756:10
            {
                if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //757:10
                {
                    bool __tmp56_outputWritten = false;
                    string __tmp57_line = "        public partial class Error : Source"; //758:1
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
                    string __tmp59_line = ", MetaDslx.CodeAnalysis.Symbols.IErrorSymbol"; //758:57
                    if (!string.IsNullOrEmpty(__tmp59_line))
                    {
                        __out.Write(__tmp59_line);
                        __tmp56_outputWritten = true;
                    }
                    if (__tmp56_outputWritten) __out.AppendLine(true);
                    if (__tmp56_outputWritten)
                    {
                        __out.AppendLine(false); //758:101
                    }
                    __out.Write("        {"); //759:1
                    __out.AppendLine(false); //759:10
                    __out.Write("            private readonly string _name;"); //760:1
                    __out.AppendLine(false); //760:43
                    __out.Write("            private readonly string _metadataName;"); //761:1
                    __out.AppendLine(false); //761:51
                    __out.Write("            private DiagnosticInfo _errorInfo;"); //762:1
                    __out.AppendLine(false); //762:47
                    __out.Write("            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorKind _kind;"); //763:1
                    __out.AppendLine(false); //763:76
                    __out.Write("            private readonly bool _unreported;"); //764:1
                    __out.AppendLine(false); //764:47
                    __out.Write("            private ImmutableArray<Symbol> _candidateSymbols;  // Best guess at what user meant, but was wrong."); //765:1
                    __out.AppendLine(false); //765:112
                    __out.AppendLine(true); //766:1
                    if (!symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //767:14
                    {
                        __out.Write("            public Error(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported"); //768:1
                        if (symbol.ModelObjectOption != ParameterOption.Disabled) //768:205
                        {
                            __out.Write(", object? modelObject"); //768:262
                            if (symbol.ModelObjectOption == ParameterOption.Optional) //768:284
                            {
                                __out.Write(" = null"); //768:341
                            }
                        }
                        __out.Write(")"); //768:364
                        __out.AppendLine(false); //768:365
                        __out.Write("                : base(container, declaration"); //769:1
                        if (symbol.ModelObjectOption != ParameterOption.Disabled) //769:47
                        {
                            __out.Write(", modelObject"); //769:104
                        }
                        __out.Write(", true)"); //769:125
                        __out.AppendLine(false); //769:132
                        __out.Write("            {"); //770:1
                        __out.AppendLine(false); //770:14
                        __out.Write("                Debug.Assert(unreported == false || errorInfo != null);"); //771:1
                        __out.AppendLine(false); //771:72
                        __out.Write("                _name = declaration.Name;"); //772:1
                        __out.AppendLine(false); //772:42
                        __out.Write("                _metadataName = declaration.MetadataName;"); //773:1
                        __out.AppendLine(false); //773:58
                        __out.Write("                _kind = kind;"); //774:1
                        __out.AppendLine(false); //774:30
                        __out.Write("                _errorInfo = errorInfo;"); //775:1
                        __out.AppendLine(false); //775:40
                        __out.Write("                _candidateSymbols = candidateSymbols;"); //776:1
                        __out.AppendLine(false); //776:54
                        __out.Write("                _unreported = unreported;"); //777:1
                        __out.AppendLine(false); //777:42
                        __out.Write("            }"); //778:1
                        __out.AppendLine(false); //778:14
                        __out.AppendLine(true); //779:1
                        __out.Write("            protected virtual Error Update(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported"); //780:1
                        if (symbol.ModelObjectOption != ParameterOption.Disabled) //780:223
                        {
                            __out.Write(", object? modelObject"); //780:280
                            if (symbol.ModelObjectOption == ParameterOption.Optional) //780:302
                            {
                                __out.Write(" = null"); //780:359
                            }
                        }
                        __out.Write(")"); //780:382
                        __out.AppendLine(false); //780:383
                        __out.Write("            {"); //781:1
                        __out.AppendLine(false); //781:14
                        __out.Write("                return new Error(container, declaration, kind, errorInfo, candidateSymbols, unreported"); //782:1
                        if (symbol.ModelObjectOption != ParameterOption.Disabled) //782:104
                        {
                            __out.Write(", modelObject"); //782:161
                        }
                        __out.Write(");"); //782:182
                        __out.AppendLine(false); //782:184
                        __out.Write("            }"); //783:1
                        __out.AppendLine(false); //783:14
                    }
                    __out.AppendLine(true); //785:1
                    __out.Write("            public Error AsUnreported()"); //786:1
                    __out.AppendLine(false); //786:40
                    __out.Write("            {"); //787:1
                    __out.AppendLine(false); //787:14
                    __out.Write("                return this.IsUnreported ? this :"); //788:1
                    __out.AppendLine(false); //788:50
                    __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, _kind, ErrorInfo, CandidateSymbols, true"); //789:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //789:116
                    {
                        __out.Write(", this.ModelObject"); //789:173
                    }
                    __out.Write(");"); //789:199
                    __out.AppendLine(false); //789:201
                    __out.Write("            }"); //790:1
                    __out.AppendLine(false); //790:14
                    __out.AppendLine(true); //791:1
                    __out.Write("            public Error AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind)"); //792:1
                    __out.AppendLine(false); //792:78
                    __out.Write("            {"); //793:1
                    __out.AppendLine(false); //793:14
                    __out.Write("                return _kind == kind ? this :"); //794:1
                    __out.AppendLine(false); //794:46
                    __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, kind, ErrorInfo, CandidateSymbols, _unreported"); //795:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //795:122
                    {
                        __out.Write(", this.ModelObject"); //795:179
                    }
                    __out.Write(");"); //795:205
                    __out.AppendLine(false); //795:207
                    __out.Write("            }"); //796:1
                    __out.AppendLine(false); //796:14
                    __out.AppendLine(true); //797:1
                    __out.Write("            public Error AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, ImmutableArray<Symbol> candidateSymbols)"); //798:1
                    __out.AppendLine(false); //798:119
                    __out.Write("            {"); //799:1
                    __out.AppendLine(false); //799:14
                    __out.Write("                return _kind == kind && CandidateSymbols == candidateSymbols ? this :"); //800:1
                    __out.AppendLine(false); //800:86
                    __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, kind, ErrorInfo, candidateSymbols, _unreported"); //801:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //801:122
                    {
                        __out.Write(", this.ModelObject"); //801:179
                    }
                    __out.Write(");"); //801:205
                    __out.AppendLine(false); //801:207
                    __out.Write("            }"); //802:1
                    __out.AppendLine(false); //802:14
                    __out.AppendLine(true); //803:1
                    __out.Write("            public Error AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo errorInfo, ImmutableArray<Symbol> candidateSymbols)"); //804:1
                    __out.AppendLine(false); //804:145
                    __out.Write("            {"); //805:1
                    __out.AppendLine(false); //805:14
                    __out.Write("                return _kind == kind && ErrorInfo == errorInfo && CandidateSymbols == candidateSymbols ? this :"); //806:1
                    __out.AppendLine(false); //806:112
                    __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, kind, errorInfo, candidateSymbols, _unreported"); //807:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //807:122
                    {
                        __out.Write(", this.ModelObject"); //807:179
                    }
                    __out.Write(");"); //807:205
                    __out.AppendLine(false); //807:207
                    __out.Write("            }"); //808:1
                    __out.AppendLine(false); //808:14
                    __out.AppendLine(true); //809:1
                    __out.Write("            public Error WithErrorInfo(DiagnosticInfo errorInfo)"); //810:1
                    __out.AppendLine(false); //810:65
                    __out.Write("            {"); //811:1
                    __out.AppendLine(false); //811:14
                    __out.Write("                return ErrorInfo == errorInfo ? this :"); //812:1
                    __out.AppendLine(false); //812:55
                    __out.Write("                    Update(this.ContainingSymbol, this.MergedDeclaration, _kind, errorInfo, CandidateSymbols, _unreported"); //813:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //813:123
                    {
                        __out.Write(", this.ModelObject"); //813:180
                    }
                    __out.Write(");"); //813:206
                    __out.AppendLine(false); //813:208
                    __out.Write("            }"); //814:1
                    __out.AppendLine(false); //814:14
                    __out.AppendLine(true); //815:1
                    __out.Write("            public override string Name => _name;"); //816:1
                    __out.AppendLine(false); //816:50
                    __out.AppendLine(true); //817:1
                    __out.Write("            public override string MetadataName => _metadataName;"); //818:1
                    __out.AppendLine(false); //818:66
                    __out.AppendLine(true); //819:1
                    __out.Write("            public sealed override bool IsError => true;"); //820:1
                    __out.AppendLine(false); //820:57
                    __out.AppendLine(true); //821:1
                    __out.Write("            public bool IsUnreported => _unreported;"); //822:1
                    __out.AppendLine(false); //822:53
                    __out.AppendLine(true); //823:1
                    __out.Write("            public MetaDslx.CodeAnalysis.Symbols.ErrorKind ErrorKind => _kind;"); //824:1
                    __out.AppendLine(false); //824:79
                    __out.AppendLine(true); //825:1
                    __out.Write("            public ImmutableArray<Symbol> CandidateSymbols"); //826:1
                    __out.AppendLine(false); //826:59
                    __out.Write("            {"); //827:1
                    __out.AppendLine(false); //827:14
                    __out.Write("                get"); //828:1
                    __out.AppendLine(false); //828:20
                    __out.Write("                {"); //829:1
                    __out.AppendLine(false); //829:18
                    __out.Write("                    if (_candidateSymbols.IsDefault)"); //830:1
                    __out.AppendLine(false); //830:53
                    __out.Write("                    {"); //831:1
                    __out.AppendLine(false); //831:22
                    __out.Write("                        System.Collections.Immutable.ImmutableInterlocked.InterlockedInitialize(ref _candidateSymbols, MakeCandidateSymbols());"); //832:1
                    __out.AppendLine(false); //832:144
                    __out.Write("                    }"); //833:1
                    __out.AppendLine(false); //833:22
                    __out.Write("                    return _candidateSymbols;"); //834:1
                    __out.AppendLine(false); //834:46
                    __out.Write("                }"); //835:1
                    __out.AppendLine(false); //835:18
                    __out.Write("            }"); //836:1
                    __out.AppendLine(false); //836:14
                    __out.AppendLine(true); //837:1
                    __out.Write("            public DiagnosticInfo? ErrorInfo"); //838:1
                    __out.AppendLine(false); //838:45
                    __out.Write("            {"); //839:1
                    __out.AppendLine(false); //839:14
                    __out.Write("                get"); //840:1
                    __out.AppendLine(false); //840:20
                    __out.Write("                {"); //841:1
                    __out.AppendLine(false); //841:18
                    __out.Write("                    if (_errorInfo is null)"); //842:1
                    __out.AppendLine(false); //842:44
                    __out.Write("                    {"); //843:1
                    __out.AppendLine(false); //843:22
                    __out.Write("                        System.Threading.Interlocked.CompareExchange(ref _errorInfo, MakeErrorInfo(), null);"); //844:1
                    __out.AppendLine(false); //844:109
                    __out.Write("                    }"); //845:1
                    __out.AppendLine(false); //845:22
                    __out.Write("                    return _errorInfo;"); //846:1
                    __out.AppendLine(false); //846:39
                    __out.Write("                }"); //847:1
                    __out.AppendLine(false); //847:18
                    __out.Write("            }"); //848:1
                    __out.AppendLine(false); //848:14
                    __out.AppendLine(true); //849:1
                    __out.Write("            public DiagnosticInfo? UseSiteDiagnosticInfo => _unreported ? ErrorInfo : null;"); //850:1
                    __out.AppendLine(false); //850:92
                    __out.AppendLine(true); //851:1
                    __out.Write("            protected virtual DiagnosticInfo? MakeErrorInfo()"); //852:1
                    __out.AppendLine(false); //852:62
                    __out.Write("            {"); //853:1
                    __out.AppendLine(false); //853:14
                    __out.Write("                return null;"); //854:1
                    __out.AppendLine(false); //854:29
                    __out.Write("            }"); //855:1
                    __out.AppendLine(false); //855:14
                    __out.AppendLine(true); //856:1
                    __out.Write("            protected virtual ImmutableArray<Symbol> MakeCandidateSymbols()"); //857:1
                    __out.AppendLine(false); //857:76
                    __out.Write("            {"); //858:1
                    __out.AppendLine(false); //858:14
                    __out.Write("                return ImmutableArray<Symbol>.Empty;"); //859:1
                    __out.AppendLine(false); //859:53
                    __out.Write("            }"); //860:1
                    __out.AppendLine(false); //860:14
                    __out.AppendLine(true); //861:1
                    __out.Write("            protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //862:1
                    __out.AppendLine(false); //862:130
                    __out.Write("            {"); //863:1
                    __out.AppendLine(false); //863:14
                    __out.Write("                return _name;"); //864:1
                    __out.AppendLine(false); //864:30
                    __out.Write("            }"); //865:1
                    __out.AppendLine(false); //865:14
                    __out.Write("        }"); //866:1
                    __out.AppendLine(false); //866:10
                }
            }
            __out.Write("	}"); //869:1
            __out.AppendLine(false); //869:3
            __out.Write("}"); //870:1
            __out.AppendLine(false); //870:2
            return __out.ToStringAndFree();
        }

        public string GenerateVisitor(string namespaceName, IEnumerable<SymbolGenerationInfo> symbols) //873:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //874:1
            __out.AppendLine(false); //874:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //875:1
            __out.AppendLine(false); //875:29
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //876:1
            __out.AppendLine(false); //876:37
            __out.Write("using System;"); //877:1
            __out.AppendLine(false); //877:14
            __out.Write("using System.Collections.Generic;"); //878:1
            __out.AppendLine(false); //878:34
            __out.Write("using System.Collections.Immutable;"); //879:1
            __out.AppendLine(false); //879:36
            __out.Write("using System.Diagnostics;"); //880:1
            __out.AppendLine(false); //880:26
            __out.Write("using System.Text;"); //881:1
            __out.AppendLine(false); //881:19
            __out.Write("using System.Threading;"); //882:1
            __out.AppendLine(false); //882:24
            __out.AppendLine(true); //883:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //884:1
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
                __out.AppendLine(false); //884:26
            }
            __out.Write("{"); //885:1
            __out.AppendLine(false); //885:2
            __out.Write("	public interface ISymbolVisitor"); //886:1
            __out.AppendLine(false); //886:33
            __out.Write("	{"); //887:1
            __out.AppendLine(false); //887:3
            var __loop12_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //888:16
                select new { symbol = symbol}
                ).ToList(); //888:10
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp5 = __loop12_results[__loop12_iteration];
                var symbol = __tmp5.symbol;
                bool __tmp7_outputWritten = false;
                string __tmp8_line = "        void Visit("; //889:1
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
                string __tmp10_line = " symbol);"; //889:33
                if (!string.IsNullOrEmpty(__tmp10_line))
                {
                    __out.Write(__tmp10_line);
                    __tmp7_outputWritten = true;
                }
                if (__tmp7_outputWritten) __out.AppendLine(true);
                if (__tmp7_outputWritten)
                {
                    __out.AppendLine(false); //889:42
                }
            }
            __out.Write("	}"); //891:1
            __out.AppendLine(false); //891:3
            __out.AppendLine(true); //892:1
            __out.Write("	public interface ISymbolVisitor<TResult>"); //893:1
            __out.AppendLine(false); //893:42
            __out.Write("	{"); //894:1
            __out.AppendLine(false); //894:3
            var __loop13_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //895:16
                select new { symbol = symbol}
                ).ToList(); //895:10
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp11 = __loop13_results[__loop13_iteration];
                var symbol = __tmp11.symbol;
                bool __tmp13_outputWritten = false;
                string __tmp14_line = "        TResult Visit("; //896:1
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
                string __tmp16_line = " symbol);"; //896:36
                if (!string.IsNullOrEmpty(__tmp16_line))
                {
                    __out.Write(__tmp16_line);
                    __tmp13_outputWritten = true;
                }
                if (__tmp13_outputWritten) __out.AppendLine(true);
                if (__tmp13_outputWritten)
                {
                    __out.AppendLine(false); //896:45
                }
            }
            __out.Write("	}"); //898:1
            __out.AppendLine(false); //898:3
            __out.AppendLine(true); //899:1
            __out.Write("	public interface ISymbolVisitor<TArgument, TResult>"); //900:1
            __out.AppendLine(false); //900:53
            __out.Write("	{"); //901:1
            __out.AppendLine(false); //901:3
            var __loop14_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //902:16
                select new { symbol = symbol}
                ).ToList(); //902:10
            for (int __loop14_iteration = 0; __loop14_iteration < __loop14_results.Count; ++__loop14_iteration)
            {
                var __tmp17 = __loop14_results[__loop14_iteration];
                var symbol = __tmp17.symbol;
                bool __tmp19_outputWritten = false;
                string __tmp20_line = "        TResult Visit("; //903:1
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
                string __tmp22_line = " symbol, TArgument argument);"; //903:36
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Write(__tmp22_line);
                    __tmp19_outputWritten = true;
                }
                if (__tmp19_outputWritten) __out.AppendLine(true);
                if (__tmp19_outputWritten)
                {
                    __out.AppendLine(false); //903:65
                }
            }
            __out.Write("	}"); //905:1
            __out.AppendLine(false); //905:3
            __out.Write("}"); //906:1
            __out.AppendLine(false); //906:2
            return __out.ToStringAndFree();
        }

        public string GenerateFactory(string namespaceName, IEnumerable<SymbolGenerationInfo> symbols) //909:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //910:1
            __out.AppendLine(false); //910:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //911:1
            __out.AppendLine(false); //911:29
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //912:1
            __out.AppendLine(false); //912:37
            __out.Write("using System;"); //913:1
            __out.AppendLine(false); //913:14
            __out.Write("using System.Collections.Generic;"); //914:1
            __out.AppendLine(false); //914:34
            __out.Write("using System.Collections.Immutable;"); //915:1
            __out.AppendLine(false); //915:36
            __out.Write("using System.Diagnostics;"); //916:1
            __out.AppendLine(false); //916:26
            __out.Write("using System.Text;"); //917:1
            __out.AppendLine(false); //917:19
            __out.Write("using System.Threading;"); //918:1
            __out.AppendLine(false); //918:24
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //919:1
            __out.AppendLine(false); //919:42
            __out.AppendLine(true); //920:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //921:1
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
            string __tmp5_line = ".Factory"; //921:26
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //921:34
            }
            __out.Write("{"); //922:1
            __out.AppendLine(false); //922:2
            var __loop15_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //923:12
                where symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol" && symbol.SymbolParts != SymbolParts.None //923:28
                select new { symbol = symbol}
                ).ToList(); //923:6
            for (int __loop15_iteration = 0; __loop15_iteration < __loop15_results.Count; ++__loop15_iteration)
            {
                var __tmp6 = __loop15_results[__loop15_iteration];
                var symbol = __tmp6.symbol;
                bool __tmp8_outputWritten = false;
                string __tmp9_line = "	public class "; //924:1
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
                string __tmp11_line = "Factory : IGeneratedSymbolFactory"; //924:28
                if (!string.IsNullOrEmpty(__tmp11_line))
                {
                    __out.Write(__tmp11_line);
                    __tmp8_outputWritten = true;
                }
                if (__tmp8_outputWritten) __out.AppendLine(true);
                if (__tmp8_outputWritten)
                {
                    __out.AppendLine(false); //924:61
                }
                __out.Write("	{"); //925:1
                __out.AppendLine(false); //925:3
                __out.Write("        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)"); //926:1
                __out.AppendLine(false); //926:83
                __out.Write("        {"); //927:1
                __out.AppendLine(false); //927:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Metadata)) //928:14
                {
                    bool __tmp13_outputWritten = false;
                    string __tmp14_line = "            throw new NotImplementedException(\"There is no Metadata"; //929:1
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
                    string __tmp16_line = " implemented.\");"; //929:81
                    if (!string.IsNullOrEmpty(__tmp16_line))
                    {
                        __out.Write(__tmp16_line);
                        __tmp13_outputWritten = true;
                    }
                    if (__tmp13_outputWritten) __out.AppendLine(true);
                    if (__tmp13_outputWritten)
                    {
                        __out.AppendLine(false); //929:97
                    }
                }
                else if (symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //930:14
                {
                    bool __tmp18_outputWritten = false;
                    string __tmp19_line = "            throw new NotImplementedException(\"CreateMetadataSymbol for Metadata"; //931:1
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
                    string __tmp21_line = " should be implemented in a custom SymbolFactory.\");"; //931:94
                    if (!string.IsNullOrEmpty(__tmp21_line))
                    {
                        __out.Write(__tmp21_line);
                        __tmp18_outputWritten = true;
                    }
                    if (__tmp18_outputWritten) __out.AppendLine(true);
                    if (__tmp18_outputWritten)
                    {
                        __out.AppendLine(false); //931:146
                    }
                }
                else //932:14
                {
                    bool __tmp23_outputWritten = false;
                    string __tmp24_line = "            return new Metadata.Metadata"; //933:1
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
                    string __tmp26_line = "(container"; //933:54
                    if (!string.IsNullOrEmpty(__tmp26_line))
                    {
                        __out.Write(__tmp26_line);
                        __tmp23_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //933:65
                    {
                        string __tmp28_line = ", modelObject"; //933:122
                        if (!string.IsNullOrEmpty(__tmp28_line))
                        {
                            __out.Write(__tmp28_line);
                            __tmp23_outputWritten = true;
                        }
                    }
                    string __tmp30_line = ");"; //933:143
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Write(__tmp30_line);
                        __tmp23_outputWritten = true;
                    }
                    if (__tmp23_outputWritten) __out.AppendLine(true);
                    if (__tmp23_outputWritten)
                    {
                        __out.AppendLine(false); //933:145
                    }
                }
                __out.Write("        }"); //935:1
                __out.AppendLine(false); //935:10
                __out.AppendLine(true); //936:1
                __out.Write("        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)"); //937:1
                __out.AppendLine(false); //937:253
                __out.Write("        {"); //938:1
                __out.AppendLine(false); //938:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Metadata)) //939:14
                {
                    bool __tmp32_outputWritten = false;
                    string __tmp33_line = "            throw new NotImplementedException(\"There is no Metadata"; //940:1
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
                    string __tmp35_line = " implemented.\");"; //940:81
                    if (!string.IsNullOrEmpty(__tmp35_line))
                    {
                        __out.Write(__tmp35_line);
                        __tmp32_outputWritten = true;
                    }
                    if (__tmp32_outputWritten) __out.AppendLine(true);
                    if (__tmp32_outputWritten)
                    {
                        __out.AppendLine(false); //940:97
                    }
                }
                else if (symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //941:14
                {
                    bool __tmp37_outputWritten = false;
                    string __tmp38_line = "            throw new NotImplementedException(\"CreateMetadataSymbol for Metadata"; //942:1
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
                    string __tmp40_line = " should be implemented in a custom SymbolFactory.\");"; //942:94
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Write(__tmp40_line);
                        __tmp37_outputWritten = true;
                    }
                    if (__tmp37_outputWritten) __out.AppendLine(true);
                    if (__tmp37_outputWritten)
                    {
                        __out.AppendLine(false); //942:146
                    }
                }
                else //943:14
                {
                    bool __tmp42_outputWritten = false;
                    string __tmp43_line = "            return new Metadata.Metadata"; //944:1
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
                    string __tmp45_line = ".Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported"; //944:54
                    if (!string.IsNullOrEmpty(__tmp45_line))
                    {
                        __out.Write(__tmp45_line);
                        __tmp42_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //944:138
                    {
                        string __tmp47_line = ", modelObject"; //944:195
                        if (!string.IsNullOrEmpty(__tmp47_line))
                        {
                            __out.Write(__tmp47_line);
                            __tmp42_outputWritten = true;
                        }
                    }
                    string __tmp49_line = ");"; //944:216
                    if (!string.IsNullOrEmpty(__tmp49_line))
                    {
                        __out.Write(__tmp49_line);
                        __tmp42_outputWritten = true;
                    }
                    if (__tmp42_outputWritten) __out.AppendLine(true);
                    if (__tmp42_outputWritten)
                    {
                        __out.AppendLine(false); //944:218
                    }
                }
                __out.Write("        }"); //946:1
                __out.AppendLine(false); //946:10
                __out.AppendLine(true); //947:1
                __out.Write("        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)"); //948:1
                __out.AppendLine(false); //948:112
                __out.Write("        {"); //949:1
                __out.AppendLine(false); //949:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Source)) //950:14
                {
                    bool __tmp51_outputWritten = false;
                    string __tmp52_line = "            throw new NotImplementedException(\"There is no Source"; //951:1
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
                    string __tmp54_line = " implemented.\");"; //951:79
                    if (!string.IsNullOrEmpty(__tmp54_line))
                    {
                        __out.Write(__tmp54_line);
                        __tmp51_outputWritten = true;
                    }
                    if (__tmp51_outputWritten) __out.AppendLine(true);
                    if (__tmp51_outputWritten)
                    {
                        __out.AppendLine(false); //951:95
                    }
                }
                else if (symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //952:14
                {
                    bool __tmp56_outputWritten = false;
                    string __tmp57_line = "            throw new NotImplementedException(\"CreateSourceSymbol for Source"; //953:1
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
                    string __tmp59_line = " should be implemented in a custom SymbolFactory.\");"; //953:90
                    if (!string.IsNullOrEmpty(__tmp59_line))
                    {
                        __out.Write(__tmp59_line);
                        __tmp56_outputWritten = true;
                    }
                    if (__tmp56_outputWritten) __out.AppendLine(true);
                    if (__tmp56_outputWritten)
                    {
                        __out.AppendLine(false); //953:142
                    }
                }
                else //954:14
                {
                    bool __tmp61_outputWritten = false;
                    string __tmp62_line = "            return new Source.Source"; //955:1
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
                    string __tmp64_line = "(container, declaration"; //955:50
                    if (!string.IsNullOrEmpty(__tmp64_line))
                    {
                        __out.Write(__tmp64_line);
                        __tmp61_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //955:74
                    {
                        string __tmp66_line = ", modelObject"; //955:131
                        if (!string.IsNullOrEmpty(__tmp66_line))
                        {
                            __out.Write(__tmp66_line);
                            __tmp61_outputWritten = true;
                        }
                    }
                    string __tmp68_line = ");"; //955:152
                    if (!string.IsNullOrEmpty(__tmp68_line))
                    {
                        __out.Write(__tmp68_line);
                        __tmp61_outputWritten = true;
                    }
                    if (__tmp61_outputWritten) __out.AppendLine(true);
                    if (__tmp61_outputWritten)
                    {
                        __out.AppendLine(false); //955:154
                    }
                }
                __out.Write("        }"); //957:1
                __out.AppendLine(false); //957:10
                __out.AppendLine(true); //958:1
                __out.Write("        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)"); //959:1
                __out.AppendLine(false); //959:248
                __out.Write("        {"); //960:1
                __out.AppendLine(false); //960:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Source)) //961:14
                {
                    bool __tmp70_outputWritten = false;
                    string __tmp71_line = "            throw new NotImplementedException(\"There is no Source"; //962:1
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
                    string __tmp73_line = " implemented.\");"; //962:79
                    if (!string.IsNullOrEmpty(__tmp73_line))
                    {
                        __out.Write(__tmp73_line);
                        __tmp70_outputWritten = true;
                    }
                    if (__tmp70_outputWritten) __out.AppendLine(true);
                    if (__tmp70_outputWritten)
                    {
                        __out.AppendLine(false); //962:95
                    }
                }
                else if (symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //963:14
                {
                    bool __tmp75_outputWritten = false;
                    string __tmp76_line = "            throw new NotImplementedException(\"CreateSourceSymbol for Source"; //964:1
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
                    string __tmp78_line = " should be implemented in a custom SymbolFactory.\");"; //964:90
                    if (!string.IsNullOrEmpty(__tmp78_line))
                    {
                        __out.Write(__tmp78_line);
                        __tmp75_outputWritten = true;
                    }
                    if (__tmp75_outputWritten) __out.AppendLine(true);
                    if (__tmp75_outputWritten)
                    {
                        __out.AppendLine(false); //964:142
                    }
                }
                else //965:14
                {
                    bool __tmp80_outputWritten = false;
                    string __tmp81_line = "            return new Source.Source"; //966:1
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
                    string __tmp83_line = ".Error(container, declaration, kind, errorInfo, candidateSymbols, unreported"; //966:50
                    if (!string.IsNullOrEmpty(__tmp83_line))
                    {
                        __out.Write(__tmp83_line);
                        __tmp80_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //966:127
                    {
                        string __tmp85_line = ", modelObject"; //966:184
                        if (!string.IsNullOrEmpty(__tmp85_line))
                        {
                            __out.Write(__tmp85_line);
                            __tmp80_outputWritten = true;
                        }
                    }
                    string __tmp87_line = ");"; //966:205
                    if (!string.IsNullOrEmpty(__tmp87_line))
                    {
                        __out.Write(__tmp87_line);
                        __tmp80_outputWritten = true;
                    }
                    if (__tmp80_outputWritten) __out.AppendLine(true);
                    if (__tmp80_outputWritten)
                    {
                        __out.AppendLine(false); //966:207
                    }
                }
                __out.Write("        }"); //968:1
                __out.AppendLine(false); //968:10
                __out.Write("	}"); //969:1
                __out.AppendLine(false); //969:3
            }
            __out.Write("}"); //971:1
            __out.AppendLine(false); //971:2
            return __out.ToStringAndFree();
        }

    }
}

