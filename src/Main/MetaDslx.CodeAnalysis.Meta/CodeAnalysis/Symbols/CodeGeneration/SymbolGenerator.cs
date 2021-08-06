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
                __out.Write("            private readonly ImmutableArray<DeclaredSymbol> _candidateSymbols;  // Best guess at what user meant, but was wrong."); //520:1
                __out.AppendLine(false); //520:129
                __out.AppendLine(true); //521:1
                if (!symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //522:14
                {
                    __out.Write("            public Error(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<DeclaredSymbol> candidateSymbols, bool unreported, "); //523:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //523:218
                    {
                        __out.Write(", object? modelObject"); //523:275
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //523:297
                        {
                            __out.Write(" = null"); //523:354
                        }
                    }
                    __out.Write(")"); //523:377
                    __out.AppendLine(false); //523:378
                    __out.Write("                : base(container"); //524:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //524:34
                    {
                        __out.Write(", modelObject"); //524:91
                    }
                    __out.Write(", true)"); //524:112
                    __out.AppendLine(false); //524:119
                    __out.Write("            {"); //525:1
                    __out.AppendLine(false); //525:14
                    __out.Write("                _name = name;"); //526:1
                    __out.AppendLine(false); //526:30
                    __out.Write("                _metadataName = metadataName;"); //527:1
                    __out.AppendLine(false); //527:46
                    __out.Write("                _kind = kind;"); //528:1
                    __out.AppendLine(false); //528:30
                    __out.Write("                _errorInfo = errorInfo;"); //529:1
                    __out.AppendLine(false); //529:40
                    __out.Write("                _candidateSymbols = candidateSymbols;"); //530:1
                    __out.AppendLine(false); //530:54
                    __out.Write("                _unreported = unreported;"); //531:1
                    __out.AppendLine(false); //531:42
                    __out.Write("            }"); //532:1
                    __out.AppendLine(false); //532:14
                }
                __out.AppendLine(true); //534:1
                __out.Write("            public override string Name => _name;"); //535:1
                __out.AppendLine(false); //535:50
                __out.AppendLine(true); //536:1
                __out.Write("            public override string MetadataName => _metadataName;"); //537:1
                __out.AppendLine(false); //537:66
                __out.AppendLine(true); //538:1
                __out.Write("            public sealed override bool IsError => true;"); //539:1
                __out.AppendLine(false); //539:57
                __out.AppendLine(true); //540:1
                __out.Write("            public bool IsUnreported => _unreported;"); //541:1
                __out.AppendLine(false); //541:53
                __out.AppendLine(true); //542:1
                __out.Write("            public MetaDslx.CodeAnalysis.Symbols.ErrorKind Kind => _kind;"); //543:1
                __out.AppendLine(false); //543:74
                __out.AppendLine(true); //544:1
                __out.Write("            public ImmutableArray<DeclaredSymbol> CandidateSymbols"); //545:1
                __out.AppendLine(false); //545:67
                __out.Write("            {"); //546:1
                __out.AppendLine(false); //546:14
                __out.Write("                get"); //547:1
                __out.AppendLine(false); //547:20
                __out.Write("                {"); //548:1
                __out.AppendLine(false); //548:18
                __out.Write("                    if (_candidateSymbols.IsDefault)"); //549:1
                __out.AppendLine(false); //549:53
                __out.Write("                    {"); //550:1
                __out.AppendLine(false); //550:22
                __out.Write("                        System.Collections.Immutable.ImmutableInterlocked.InterlockedInitialize(ref _candidateSymbols, MakeCandidateSymbols(), null);"); //551:1
                __out.AppendLine(false); //551:150
                __out.Write("                    }"); //552:1
                __out.AppendLine(false); //552:22
                __out.Write("                    return _candidateSymbols;"); //553:1
                __out.AppendLine(false); //553:46
                __out.Write("                }"); //554:1
                __out.AppendLine(false); //554:18
                __out.Write("            }"); //555:1
                __out.AppendLine(false); //555:14
                __out.AppendLine(true); //556:1
                __out.Write("            public DiagnosticInfo? ErrorInfo"); //557:1
                __out.AppendLine(false); //557:45
                __out.Write("            {"); //558:1
                __out.AppendLine(false); //558:14
                __out.Write("                get"); //559:1
                __out.AppendLine(false); //559:20
                __out.Write("                {"); //560:1
                __out.AppendLine(false); //560:18
                __out.Write("                    if (_errorInfo is null)"); //561:1
                __out.AppendLine(false); //561:44
                __out.Write("                    {"); //562:1
                __out.AppendLine(false); //562:22
                __out.Write("                        System.Threading.Interlocked.CompareExchange(ref _errorInfo, MakeErrorInfo(), null);"); //563:1
                __out.AppendLine(false); //563:109
                __out.Write("                    }"); //564:1
                __out.AppendLine(false); //564:22
                __out.Write("                    return _errorInfo;"); //565:1
                __out.AppendLine(false); //565:39
                __out.Write("                }"); //566:1
                __out.AppendLine(false); //566:18
                __out.Write("            }"); //567:1
                __out.AppendLine(false); //567:14
                __out.AppendLine(true); //568:1
                __out.Write("            protected virtual DiagnosticInfo? MakeErrorInfo()"); //569:1
                __out.AppendLine(false); //569:62
                __out.Write("            {"); //570:1
                __out.AppendLine(false); //570:14
                __out.Write("                return null;"); //571:1
                __out.AppendLine(false); //571:29
                __out.Write("            }"); //572:1
                __out.AppendLine(false); //572:14
                __out.AppendLine(true); //573:1
                __out.Write("            protected virtual ImmutableArray<DeclaredSymbol> MakeCandidateSymbols()"); //574:1
                __out.AppendLine(false); //574:84
                __out.Write("            {"); //575:1
                __out.AppendLine(false); //575:14
                __out.Write("                return ImmutableArray<DeclaredSymbol>.Empty;"); //576:1
                __out.AppendLine(false); //576:61
                __out.Write("            }"); //577:1
                __out.AppendLine(false); //577:14
                __out.AppendLine(true); //578:1
                __out.Write("            protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //579:1
                __out.AppendLine(false); //579:130
                __out.Write("            {"); //580:1
                __out.AppendLine(false); //580:14
                __out.Write("                return _name;"); //581:1
                __out.AppendLine(false); //581:30
                __out.Write("            }"); //582:1
                __out.AppendLine(false); //582:14
                __out.Write("        }"); //583:1
                __out.AppendLine(false); //583:10
            }
            __out.Write("    }"); //585:1
            __out.AppendLine(false); //585:6
            __out.Write("}"); //586:1
            __out.AppendLine(false); //586:2
            return __out.ToStringAndFree();
        }

        public string GenerateSourceSymbol(SymbolGenerationInfo symbol) //589:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //590:1
            __out.AppendLine(false); //590:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //591:1
            __out.AppendLine(false); //591:29
            __out.Write("using MetaDslx.CodeAnalysis.Binding;"); //592:1
            __out.AppendLine(false); //592:37
            __out.Write("using MetaDslx.CodeAnalysis.Binding.Binders;"); //593:1
            __out.AppendLine(false); //593:45
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //594:1
            __out.AppendLine(false); //594:42
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //595:1
            __out.AppendLine(false); //595:37
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Metadata;"); //596:1
            __out.AppendLine(false); //596:46
            __out.Write("using MetaDslx.CodeAnalysis.Symbols.Source;"); //597:1
            __out.AppendLine(false); //597:44
            __out.Write("using System;"); //598:1
            __out.AppendLine(false); //598:14
            __out.Write("using System.Collections.Generic;"); //599:1
            __out.AppendLine(false); //599:34
            __out.Write("using System.Collections.Immutable;"); //600:1
            __out.AppendLine(false); //600:36
            __out.Write("using System.Diagnostics;"); //601:1
            __out.AppendLine(false); //601:26
            __out.Write("using System.Linq;"); //602:1
            __out.AppendLine(false); //602:19
            __out.Write("using System.Text;"); //603:1
            __out.AppendLine(false); //603:19
            __out.Write("using System.Threading;"); //604:1
            __out.AppendLine(false); //604:24
            __out.AppendLine(true); //605:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //606:1
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
            string __tmp5_line = ".Source"; //606:33
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //606:40
            }
            __out.Write("{"); //607:1
            __out.AppendLine(false); //607:2
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "	public partial class Source"; //608:1
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
            if (symbol.ExistingSourceTypeInfo.BaseType == null) //608:43
            {
                string __tmp11_line = " : "; //608:95
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
                string __tmp13_line = ".Completion.Completion"; //608:120
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
                if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //608:156
                {
                    string __tmp16_line = ", MetaDslx.CodeAnalysis.Symbols.Source.ISourceSymbol"; //608:226
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
                __out.AppendLine(false); //608:294
            }
            __out.Write("	{"); //609:1
            __out.AppendLine(false); //609:3
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //610:10
            {
                __out.Write("        private readonly MergedDeclaration _declaration;"); //611:1
                __out.AppendLine(false); //611:57
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetLexicalSortKey")) //612:10
                {
                    __out.Write("        private LexicalSortKey _lazyLexicalSortKey = LexicalSortKey.NotInitialized;"); //613:1
                    __out.AppendLine(false); //613:84
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //615:10
                {
                    __out.AppendLine(true); //616:1
                    bool __tmp20_outputWritten = false;
                    string __tmp21_line = "		public Source"; //617:1
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
                    string __tmp23_line = "(Symbol containingSymbol, MergedDeclaration declaration"; //617:29
                    if (!string.IsNullOrEmpty(__tmp23_line))
                    {
                        __out.Write(__tmp23_line);
                        __tmp20_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //617:85
                    {
                        string __tmp25_line = ", object? modelObject"; //617:142
                        if (!string.IsNullOrEmpty(__tmp25_line))
                        {
                            __out.Write(__tmp25_line);
                            __tmp20_outputWritten = true;
                        }
                        if (symbol.ModelObjectOption == ParameterOption.Optional) //617:164
                        {
                            string __tmp27_line = " = null"; //617:221
                            if (!string.IsNullOrEmpty(__tmp27_line))
                            {
                                __out.Write(__tmp27_line);
                                __tmp20_outputWritten = true;
                            }
                        }
                    }
                    string __tmp30_line = ", bool isError = false)"; //617:244
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Write(__tmp30_line);
                        __tmp20_outputWritten = true;
                    }
                    if (__tmp20_outputWritten) __out.AppendLine(true);
                    if (__tmp20_outputWritten)
                    {
                        __out.AppendLine(false); //617:267
                    }
                    __out.Write("            : base(containingSymbol"); //618:1
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //618:37
                    {
                        __out.Write(", modelObject"); //618:94
                    }
                    __out.Write(", isError)"); //618:115
                    __out.AppendLine(false); //618:125
                    __out.Write("        {"); //619:1
                    __out.AppendLine(false); //619:10
                    __out.Write("            if (declaration is null) throw new ArgumentNullException(nameof(declaration));"); //620:1
                    __out.AppendLine(false); //620:91
                    __out.Write("            _declaration = declaration;"); //621:1
                    __out.AppendLine(false); //621:40
                    __out.Write("		}"); //622:1
                    __out.AppendLine(false); //622:4
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("MergedDeclaration")) //624:10
                {
                    __out.AppendLine(true); //625:1
                    __out.Write("        public MergedDeclaration MergedDeclaration => _declaration;"); //626:1
                    __out.AppendLine(false); //626:68
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("Locations")) //628:10
                {
                    __out.AppendLine(true); //629:1
                    __out.Write("        public override ImmutableArray<Location> Locations => _declaration.NameLocations;"); //630:1
                    __out.AppendLine(false); //630:90
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("DeclaringSyntaxReferences")) //632:10
                {
                    __out.AppendLine(true); //633:1
                    __out.Write("        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration.SyntaxReferences;"); //634:1
                    __out.AppendLine(false); //634:116
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetBinder")) //636:10
                {
                    __out.AppendLine(true); //637:1
                    __out.Write("        public BinderPosition<SymbolBinder> GetBinder(SyntaxReference reference)"); //638:1
                    __out.AppendLine(false); //638:81
                    __out.Write("        {"); //639:1
                    __out.AppendLine(false); //639:10
                    __out.Write("            Debug.Assert(this.DeclaringSyntaxReferences.Contains(reference));"); //640:1
                    __out.AppendLine(false); //640:78
                    __out.Write("            return FindBinders.FindSymbolBinder(this, reference);"); //641:1
                    __out.AppendLine(false); //641:66
                    __out.Write("        }"); //642:1
                    __out.AppendLine(false); //642:10
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetChildSymbol")) //644:10
                {
                    __out.AppendLine(true); //645:1
                    __out.Write("        public Symbol GetChildSymbol(SyntaxReference syntax)"); //646:1
                    __out.AppendLine(false); //646:61
                    __out.Write("        {"); //647:1
                    __out.AppendLine(false); //647:10
                    __out.Write("            foreach (var child in this.ChildSymbols)"); //648:1
                    __out.AppendLine(false); //648:53
                    __out.Write("            {"); //649:1
                    __out.AppendLine(false); //649:14
                    __out.Write("                if (child.DeclaringSyntaxReferences.Any(sr => sr.GetLocation() == syntax.GetLocation()))"); //650:1
                    __out.AppendLine(false); //650:105
                    __out.Write("                {"); //651:1
                    __out.AppendLine(false); //651:18
                    __out.Write("                    return child;"); //652:1
                    __out.AppendLine(false); //652:34
                    __out.Write("                }"); //653:1
                    __out.AppendLine(false); //653:18
                    __out.Write("            }"); //654:1
                    __out.AppendLine(false); //654:14
                    __out.Write("            return null;"); //655:1
                    __out.AppendLine(false); //655:25
                    __out.Write("        }"); //656:1
                    __out.AppendLine(false); //656:10
                }
                if (!symbol.ExistingSourceTypeInfo.Members.Contains("GetLexicalSortKey")) //658:10
                {
                    __out.Write("        public override LexicalSortKey GetLexicalSortKey()"); //659:1
                    __out.AppendLine(false); //659:59
                    __out.Write("        {"); //660:1
                    __out.AppendLine(false); //660:10
                    __out.Write("            if (!_lazyLexicalSortKey.IsInitialized)"); //661:1
                    __out.AppendLine(false); //661:52
                    __out.Write("            {"); //662:1
                    __out.AppendLine(false); //662:14
                    __out.Write("                _lazyLexicalSortKey.SetFrom(this.MergedDeclaration.GetLexicalSortKey(this.DeclaringCompilation));"); //663:1
                    __out.AppendLine(false); //663:114
                    __out.Write("            }"); //664:1
                    __out.AppendLine(false); //664:14
                    __out.Write("            return _lazyLexicalSortKey;"); //665:1
                    __out.AppendLine(false); //665:40
                    __out.Write("        }"); //666:1
                    __out.AppendLine(false); //666:10
                }
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteInitializingSymbol")) //669:10
            {
                __out.AppendLine(true); //670:1
                __out.Write("        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //671:1
                __out.AppendLine(false); //671:123
                __out.Write("        {"); //672:1
                __out.AppendLine(false); //672:10
                __out.Write("        }"); //673:1
                __out.AppendLine(false); //673:10
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteCreatingChildSymbols")) //675:10
            {
                __out.AppendLine(true); //676:1
                __out.Write("        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //677:1
                __out.AppendLine(false); //677:143
                __out.Write("        {"); //678:1
                __out.AppendLine(false); //678:10
                __out.Write("            return SourceSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);"); //679:1
                __out.AppendLine(false); //679:124
                __out.Write("        }"); //680:1
                __out.AppendLine(false); //680:10
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteImports")) //682:10
            {
                __out.AppendLine(true); //683:1
                __out.Write("        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //684:1
                __out.AppendLine(false); //684:140
                __out.Write("        {"); //685:1
                __out.AppendLine(false); //685:10
                __out.Write("            SourceSymbolImplementation.CompleteImports(this, locationOpt, diagnostics, cancellationToken);"); //686:1
                __out.AppendLine(false); //686:107
                __out.Write("        }"); //687:1
                __out.AppendLine(false); //687:10
                __out.AppendLine(true); //688:1
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteSymbolProperty_Name")) //690:10
            {
                __out.Write("        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //691:1
                __out.AppendLine(false); //691:126
                __out.Write("        {"); //692:1
                __out.AppendLine(false); //692:10
                __out.Write("            return SourceSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);"); //693:1
                __out.AppendLine(false); //693:133
                __out.Write("        }"); //694:1
                __out.AppendLine(false); //694:10
            }
            __out.AppendLine(true); //696:1
            var __loop11_results = 
                (from part in __Enumerate((symbol.CompletionParts).GetEnumerator()) //697:16
                where part.GenerateCompleteMethod //697:44
                select new { part = part}
                ).ToList(); //697:10
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp31 = __loop11_results[__loop11_iteration];
                var part = __tmp31.part;
                if (!symbol.ExistingSourceTypeInfo.Members.Contains(part.CompleteMethodName)) //698:14
                {
                    bool __tmp33_outputWritten = false;
                    string __tmp34_line = "        protected override "; //699:1
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
                    string __tmp36_line = " "; //699:59
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
                    string __tmp38_line = "("; //699:85
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
                    string __tmp40_line = ")"; //699:116
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Write(__tmp40_line);
                        __tmp33_outputWritten = true;
                    }
                    if (__tmp33_outputWritten) __out.AppendLine(true);
                    if (__tmp33_outputWritten)
                    {
                        __out.AppendLine(false); //699:117
                    }
                    __out.Write("        {"); //700:1
                    __out.AppendLine(false); //700:10
                    if (part is SymbolPropertyGenerationInfo) //701:14
                    {
                        var prop = (SymbolPropertyGenerationInfo)part; //702:18
                        if (prop.IsCollection) //703:18
                        {
                            bool __tmp42_outputWritten = false;
                            string __tmp43_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValues<"; //704:1
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
                            string __tmp45_line = ">(this, nameof("; //704:89
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
                            string __tmp47_line = "), diagnostics, cancellationToken);"; //704:115
                            if (!string.IsNullOrEmpty(__tmp47_line))
                            {
                                __out.Write(__tmp47_line);
                                __tmp42_outputWritten = true;
                            }
                            if (__tmp42_outputWritten) __out.AppendLine(true);
                            if (__tmp42_outputWritten)
                            {
                                __out.AppendLine(false); //704:150
                            }
                        }
                        else //705:18
                        {
                            bool __tmp49_outputWritten = false;
                            string __tmp50_line = "            return SourceSymbolImplementation.AssignSymbolPropertyValue<"; //706:1
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
                            string __tmp52_line = ">(this, nameof("; //706:84
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
                            string __tmp54_line = "), diagnostics, cancellationToken);"; //706:110
                            if (!string.IsNullOrEmpty(__tmp54_line))
                            {
                                __out.Write(__tmp54_line);
                                __tmp49_outputWritten = true;
                            }
                            if (__tmp49_outputWritten) __out.AppendLine(true);
                            if (__tmp49_outputWritten)
                            {
                                __out.AppendLine(false); //706:145
                            }
                        }
                    }
                    __out.Write("        }"); //709:1
                    __out.AppendLine(false); //709:10
                }
            }
            if (!symbol.ExistingSourceTypeInfo.Members.Contains("CompleteNonSymbolProperties")) //712:10
            {
                __out.AppendLine(true); //713:1
                __out.Write("        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //714:1
                __out.AppendLine(false); //714:152
                __out.Write("        {"); //715:1
                __out.AppendLine(false); //715:10
                __out.Write("            SourceSymbolImplementation.AssignNonSymbolProperties(this, diagnostics, cancellationToken);"); //716:1
                __out.AppendLine(false); //716:104
                __out.Write("        }"); //717:1
                __out.AppendLine(false); //717:10
            }
            __out.AppendLine(true); //719:1
            if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //720:10
            {
                if (symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol") //721:10
                {
                    bool __tmp56_outputWritten = false;
                    string __tmp57_line = "        public partial class Error : Source"; //722:1
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
                    string __tmp59_line = ", MetaDslx.CodeAnalysis.Symbols.IErrorSymbol"; //722:57
                    if (!string.IsNullOrEmpty(__tmp59_line))
                    {
                        __out.Write(__tmp59_line);
                        __tmp56_outputWritten = true;
                    }
                    if (__tmp56_outputWritten) __out.AppendLine(true);
                    if (__tmp56_outputWritten)
                    {
                        __out.AppendLine(false); //722:101
                    }
                    __out.Write("        {"); //723:1
                    __out.AppendLine(false); //723:10
                    __out.Write("            private readonly string _name;"); //724:1
                    __out.AppendLine(false); //724:43
                    __out.Write("            private readonly string _metadataName;"); //725:1
                    __out.AppendLine(false); //725:51
                    __out.Write("            private DiagnosticInfo _errorInfo;"); //726:1
                    __out.AppendLine(false); //726:47
                    __out.Write("            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorKind _kind;"); //727:1
                    __out.AppendLine(false); //727:76
                    __out.Write("            private readonly bool _unreported;"); //728:1
                    __out.AppendLine(false); //728:47
                    __out.Write("            private readonly ImmutableArray<DeclaredSymbol> _candidateSymbols;  // Best guess at what user meant, but was wrong."); //729:1
                    __out.AppendLine(false); //729:129
                    __out.AppendLine(true); //730:1
                    if (!symbol.ExistingMetadataTypeInfo.Members.Contains(".ctor")) //731:14
                    {
                        __out.Write("            public Error(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<DeclaredSymbol> candidateSymbols, bool unreported, "); //732:1
                        if (symbol.ModelObjectOption != ParameterOption.Disabled) //732:215
                        {
                            __out.Write(", object? modelObject"); //732:272
                            if (symbol.ModelObjectOption == ParameterOption.Optional) //732:294
                            {
                                __out.Write(" = null"); //732:351
                            }
                        }
                        __out.Write(")"); //732:374
                        __out.AppendLine(false); //732:375
                        __out.Write("                : base(container, declaration"); //733:1
                        if (symbol.ModelObjectOption != ParameterOption.Disabled) //733:47
                        {
                            __out.Write(", modelObject"); //733:104
                        }
                        __out.Write(", true)"); //733:125
                        __out.AppendLine(false); //733:132
                        __out.Write("            {"); //734:1
                        __out.AppendLine(false); //734:14
                        __out.Write("                _name = declaration.Name;"); //735:1
                        __out.AppendLine(false); //735:42
                        __out.Write("                _metadataName = declaration.MetadataName;"); //736:1
                        __out.AppendLine(false); //736:58
                        __out.Write("                _kind = kind;"); //737:1
                        __out.AppendLine(false); //737:30
                        __out.Write("                _errorInfo = errorInfo;"); //738:1
                        __out.AppendLine(false); //738:40
                        __out.Write("                _candidateSymbols = candidateSymbols;"); //739:1
                        __out.AppendLine(false); //739:54
                        __out.Write("                _unreported = unreported;"); //740:1
                        __out.AppendLine(false); //740:42
                        __out.Write("            }"); //741:1
                        __out.AppendLine(false); //741:14
                    }
                    __out.AppendLine(true); //743:1
                    __out.Write("            public override string Name => _name;"); //744:1
                    __out.AppendLine(false); //744:50
                    __out.AppendLine(true); //745:1
                    __out.Write("            public override string MetadataName => _metadataName;"); //746:1
                    __out.AppendLine(false); //746:66
                    __out.AppendLine(true); //747:1
                    __out.Write("            public sealed override bool IsError => true;"); //748:1
                    __out.AppendLine(false); //748:57
                    __out.AppendLine(true); //749:1
                    __out.Write("            public bool IsUnreported => _unreported;"); //750:1
                    __out.AppendLine(false); //750:53
                    __out.AppendLine(true); //751:1
                    __out.Write("            public MetaDslx.CodeAnalysis.Symbols.ErrorKind Kind => _kind;"); //752:1
                    __out.AppendLine(false); //752:74
                    __out.AppendLine(true); //753:1
                    __out.Write("            public ImmutableArray<DeclaredSymbol> CandidateSymbols"); //754:1
                    __out.AppendLine(false); //754:67
                    __out.Write("            {"); //755:1
                    __out.AppendLine(false); //755:14
                    __out.Write("                get"); //756:1
                    __out.AppendLine(false); //756:20
                    __out.Write("                {"); //757:1
                    __out.AppendLine(false); //757:18
                    __out.Write("                    if (_candidateSymbols.IsDefault)"); //758:1
                    __out.AppendLine(false); //758:53
                    __out.Write("                    {"); //759:1
                    __out.AppendLine(false); //759:22
                    __out.Write("                        System.Collections.Immutable.ImmutableInterlocked.InterlockedInitialize(ref _candidateSymbols, MakeCandidateSymbols(), null);"); //760:1
                    __out.AppendLine(false); //760:150
                    __out.Write("                    }"); //761:1
                    __out.AppendLine(false); //761:22
                    __out.Write("                    return _candidateSymbols;"); //762:1
                    __out.AppendLine(false); //762:46
                    __out.Write("                }"); //763:1
                    __out.AppendLine(false); //763:18
                    __out.Write("            }"); //764:1
                    __out.AppendLine(false); //764:14
                    __out.AppendLine(true); //765:1
                    __out.Write("            public DiagnosticInfo? ErrorInfo"); //766:1
                    __out.AppendLine(false); //766:45
                    __out.Write("            {"); //767:1
                    __out.AppendLine(false); //767:14
                    __out.Write("                get"); //768:1
                    __out.AppendLine(false); //768:20
                    __out.Write("                {"); //769:1
                    __out.AppendLine(false); //769:18
                    __out.Write("                    if (_errorInfo is null)"); //770:1
                    __out.AppendLine(false); //770:44
                    __out.Write("                    {"); //771:1
                    __out.AppendLine(false); //771:22
                    __out.Write("                        System.Threading.Interlocked.CompareExchange(ref _errorInfo, MakeErrorInfo(), null);"); //772:1
                    __out.AppendLine(false); //772:109
                    __out.Write("                    }"); //773:1
                    __out.AppendLine(false); //773:22
                    __out.Write("                    return _errorInfo;"); //774:1
                    __out.AppendLine(false); //774:39
                    __out.Write("                }"); //775:1
                    __out.AppendLine(false); //775:18
                    __out.Write("            }"); //776:1
                    __out.AppendLine(false); //776:14
                    __out.AppendLine(true); //777:1
                    __out.Write("            protected virtual DiagnosticInfo? MakeErrorInfo()"); //778:1
                    __out.AppendLine(false); //778:62
                    __out.Write("            {"); //779:1
                    __out.AppendLine(false); //779:14
                    __out.Write("                return null;"); //780:1
                    __out.AppendLine(false); //780:29
                    __out.Write("            }"); //781:1
                    __out.AppendLine(false); //781:14
                    __out.AppendLine(true); //782:1
                    __out.Write("            protected virtual ImmutableArray<DeclaredSymbol> MakeCandidateSymbols()"); //783:1
                    __out.AppendLine(false); //783:84
                    __out.Write("            {"); //784:1
                    __out.AppendLine(false); //784:14
                    __out.Write("                return ImmutableArray<DeclaredSymbol>.Empty;"); //785:1
                    __out.AppendLine(false); //785:61
                    __out.Write("            }"); //786:1
                    __out.AppendLine(false); //786:14
                    __out.AppendLine(true); //787:1
                    __out.Write("            protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)"); //788:1
                    __out.AppendLine(false); //788:130
                    __out.Write("            {"); //789:1
                    __out.AppendLine(false); //789:14
                    __out.Write("                return _name;"); //790:1
                    __out.AppendLine(false); //790:30
                    __out.Write("            }"); //791:1
                    __out.AppendLine(false); //791:14
                    __out.Write("        }"); //792:1
                    __out.AppendLine(false); //792:10
                }
            }
            __out.Write("	}"); //795:1
            __out.AppendLine(false); //795:3
            __out.Write("}"); //796:1
            __out.AppendLine(false); //796:2
            return __out.ToStringAndFree();
        }

        public string GenerateVisitor(string namespaceName, IEnumerable<SymbolGenerationInfo> symbols) //799:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //800:1
            __out.AppendLine(false); //800:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //801:1
            __out.AppendLine(false); //801:29
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //802:1
            __out.AppendLine(false); //802:37
            __out.Write("using System;"); //803:1
            __out.AppendLine(false); //803:14
            __out.Write("using System.Collections.Generic;"); //804:1
            __out.AppendLine(false); //804:34
            __out.Write("using System.Collections.Immutable;"); //805:1
            __out.AppendLine(false); //805:36
            __out.Write("using System.Diagnostics;"); //806:1
            __out.AppendLine(false); //806:26
            __out.Write("using System.Text;"); //807:1
            __out.AppendLine(false); //807:19
            __out.Write("using System.Threading;"); //808:1
            __out.AppendLine(false); //808:24
            __out.AppendLine(true); //809:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //810:1
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
                __out.AppendLine(false); //810:26
            }
            __out.Write("{"); //811:1
            __out.AppendLine(false); //811:2
            __out.Write("	public interface ISymbolVisitor"); //812:1
            __out.AppendLine(false); //812:33
            __out.Write("	{"); //813:1
            __out.AppendLine(false); //813:3
            var __loop12_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //814:16
                select new { symbol = symbol}
                ).ToList(); //814:10
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp5 = __loop12_results[__loop12_iteration];
                var symbol = __tmp5.symbol;
                bool __tmp7_outputWritten = false;
                string __tmp8_line = "        void Visit("; //815:1
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
                string __tmp10_line = " symbol);"; //815:33
                if (!string.IsNullOrEmpty(__tmp10_line))
                {
                    __out.Write(__tmp10_line);
                    __tmp7_outputWritten = true;
                }
                if (__tmp7_outputWritten) __out.AppendLine(true);
                if (__tmp7_outputWritten)
                {
                    __out.AppendLine(false); //815:42
                }
            }
            __out.Write("	}"); //817:1
            __out.AppendLine(false); //817:3
            __out.AppendLine(true); //818:1
            __out.Write("	public interface ISymbolVisitor<TResult>"); //819:1
            __out.AppendLine(false); //819:42
            __out.Write("	{"); //820:1
            __out.AppendLine(false); //820:3
            var __loop13_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //821:16
                select new { symbol = symbol}
                ).ToList(); //821:10
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp11 = __loop13_results[__loop13_iteration];
                var symbol = __tmp11.symbol;
                bool __tmp13_outputWritten = false;
                string __tmp14_line = "        TResult Visit("; //822:1
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
                string __tmp16_line = " symbol);"; //822:36
                if (!string.IsNullOrEmpty(__tmp16_line))
                {
                    __out.Write(__tmp16_line);
                    __tmp13_outputWritten = true;
                }
                if (__tmp13_outputWritten) __out.AppendLine(true);
                if (__tmp13_outputWritten)
                {
                    __out.AppendLine(false); //822:45
                }
            }
            __out.Write("	}"); //824:1
            __out.AppendLine(false); //824:3
            __out.AppendLine(true); //825:1
            __out.Write("	public interface ISymbolVisitor<TArgument, TResult>"); //826:1
            __out.AppendLine(false); //826:53
            __out.Write("	{"); //827:1
            __out.AppendLine(false); //827:3
            var __loop14_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //828:16
                select new { symbol = symbol}
                ).ToList(); //828:10
            for (int __loop14_iteration = 0; __loop14_iteration < __loop14_results.Count; ++__loop14_iteration)
            {
                var __tmp17 = __loop14_results[__loop14_iteration];
                var symbol = __tmp17.symbol;
                bool __tmp19_outputWritten = false;
                string __tmp20_line = "        TResult Visit("; //829:1
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
                string __tmp22_line = " symbol, TArgument argument);"; //829:36
                if (!string.IsNullOrEmpty(__tmp22_line))
                {
                    __out.Write(__tmp22_line);
                    __tmp19_outputWritten = true;
                }
                if (__tmp19_outputWritten) __out.AppendLine(true);
                if (__tmp19_outputWritten)
                {
                    __out.AppendLine(false); //829:65
                }
            }
            __out.Write("	}"); //831:1
            __out.AppendLine(false); //831:3
            __out.Write("}"); //832:1
            __out.AppendLine(false); //832:2
            return __out.ToStringAndFree();
        }

        public string GenerateFactory(string namespaceName, IEnumerable<SymbolGenerationInfo> symbols) //835:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using Microsoft.CodeAnalysis;"); //836:1
            __out.AppendLine(false); //836:30
            __out.Write("using MetaDslx.CodeAnalysis;"); //837:1
            __out.AppendLine(false); //837:29
            __out.Write("using MetaDslx.CodeAnalysis.Symbols;"); //838:1
            __out.AppendLine(false); //838:37
            __out.Write("using System;"); //839:1
            __out.AppendLine(false); //839:14
            __out.Write("using System.Collections.Generic;"); //840:1
            __out.AppendLine(false); //840:34
            __out.Write("using System.Collections.Immutable;"); //841:1
            __out.AppendLine(false); //841:36
            __out.Write("using System.Diagnostics;"); //842:1
            __out.AppendLine(false); //842:26
            __out.Write("using System.Text;"); //843:1
            __out.AppendLine(false); //843:19
            __out.Write("using System.Threading;"); //844:1
            __out.AppendLine(false); //844:24
            __out.Write("using MetaDslx.CodeAnalysis.Declarations;"); //845:1
            __out.AppendLine(false); //845:42
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
            var __loop15_results = 
                (from symbol in __Enumerate((symbols).GetEnumerator()) //849:12
                where symbol.Name != "AssemblySymbol" && symbol.Name != "ModuleSymbol" && symbol.SymbolParts != SymbolParts.None //849:28
                select new { symbol = symbol}
                ).ToList(); //849:6
            for (int __loop15_iteration = 0; __loop15_iteration < __loop15_results.Count; ++__loop15_iteration)
            {
                var __tmp6 = __loop15_results[__loop15_iteration];
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
                __out.Write("        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, object? modelObject, DiagnosticInfo errorInfo)"); //863:1
                __out.AppendLine(false); //863:148
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
                    string __tmp45_line = ".Error(container, name, metadataName, errorInfo"; //870:54
                    if (!string.IsNullOrEmpty(__tmp45_line))
                    {
                        __out.Write(__tmp45_line);
                        __tmp42_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //870:102
                    {
                        string __tmp47_line = ", modelObject"; //870:159
                        if (!string.IsNullOrEmpty(__tmp47_line))
                        {
                            __out.Write(__tmp47_line);
                            __tmp42_outputWritten = true;
                        }
                    }
                    string __tmp49_line = ");"; //870:180
                    if (!string.IsNullOrEmpty(__tmp49_line))
                    {
                        __out.Write(__tmp49_line);
                        __tmp42_outputWritten = true;
                    }
                    if (__tmp42_outputWritten) __out.AppendLine(true);
                    if (__tmp42_outputWritten)
                    {
                        __out.AppendLine(false); //870:182
                    }
                }
                __out.Write("        }"); //872:1
                __out.AppendLine(false); //872:10
                __out.AppendLine(true); //873:1
                __out.Write("        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)"); //874:1
                __out.AppendLine(false); //874:112
                __out.Write("        {"); //875:1
                __out.AppendLine(false); //875:10
                if (!symbol.SymbolParts.HasFlag(SymbolParts.Source)) //876:14
                {
                    bool __tmp51_outputWritten = false;
                    string __tmp52_line = "            throw new NotImplementedException(\"There is no Source"; //877:1
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
                    string __tmp54_line = " implemented.\");"; //877:79
                    if (!string.IsNullOrEmpty(__tmp54_line))
                    {
                        __out.Write(__tmp54_line);
                        __tmp51_outputWritten = true;
                    }
                    if (__tmp51_outputWritten) __out.AppendLine(true);
                    if (__tmp51_outputWritten)
                    {
                        __out.AppendLine(false); //877:95
                    }
                }
                else if (symbol.ExistingSourceTypeInfo.Members.Contains(".ctor")) //878:14
                {
                    bool __tmp56_outputWritten = false;
                    string __tmp57_line = "            throw new NotImplementedException(\"CreateSourceSymbol for Source"; //879:1
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
                    string __tmp59_line = " should be implemented in a custom SymbolFactory.\");"; //879:90
                    if (!string.IsNullOrEmpty(__tmp59_line))
                    {
                        __out.Write(__tmp59_line);
                        __tmp56_outputWritten = true;
                    }
                    if (__tmp56_outputWritten) __out.AppendLine(true);
                    if (__tmp56_outputWritten)
                    {
                        __out.AppendLine(false); //879:142
                    }
                }
                else //880:14
                {
                    bool __tmp61_outputWritten = false;
                    string __tmp62_line = "            return new Source.Source"; //881:1
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
                    string __tmp64_line = "(container, declaration"; //881:50
                    if (!string.IsNullOrEmpty(__tmp64_line))
                    {
                        __out.Write(__tmp64_line);
                        __tmp61_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //881:74
                    {
                        string __tmp66_line = ", modelObject"; //881:131
                        if (!string.IsNullOrEmpty(__tmp66_line))
                        {
                            __out.Write(__tmp66_line);
                            __tmp61_outputWritten = true;
                        }
                    }
                    string __tmp68_line = ");"; //881:152
                    if (!string.IsNullOrEmpty(__tmp68_line))
                    {
                        __out.Write(__tmp68_line);
                        __tmp61_outputWritten = true;
                    }
                    if (__tmp61_outputWritten) __out.AppendLine(true);
                    if (__tmp61_outputWritten)
                    {
                        __out.AppendLine(false); //881:154
                    }
                }
                __out.Write("        }"); //883:1
                __out.AppendLine(false); //883:10
                __out.AppendLine(true); //884:1
                __out.Write("        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)"); //885:1
                __out.AppendLine(false); //885:143
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
                    string __tmp83_line = ".Error(container, declaration, errorInfo"; //892:50
                    if (!string.IsNullOrEmpty(__tmp83_line))
                    {
                        __out.Write(__tmp83_line);
                        __tmp80_outputWritten = true;
                    }
                    if (symbol.ModelObjectOption != ParameterOption.Disabled) //892:91
                    {
                        string __tmp85_line = ", modelObject"; //892:148
                        if (!string.IsNullOrEmpty(__tmp85_line))
                        {
                            __out.Write(__tmp85_line);
                            __tmp80_outputWritten = true;
                        }
                    }
                    string __tmp87_line = ");"; //892:169
                    if (!string.IsNullOrEmpty(__tmp87_line))
                    {
                        __out.Write(__tmp87_line);
                        __tmp80_outputWritten = true;
                    }
                    if (__tmp80_outputWritten) __out.AppendLine(true);
                    if (__tmp80_outputWritten)
                    {
                        __out.AppendLine(false); //892:171
                    }
                }
                __out.Write("        }"); //894:1
                __out.AppendLine(false); //894:10
                __out.Write("	}"); //895:1
                __out.AppendLine(false); //895:3
            }
            __out.Write("}"); //897:1
            __out.AppendLine(false); //897:2
            return __out.ToStringAndFree();
        }

    }
}

