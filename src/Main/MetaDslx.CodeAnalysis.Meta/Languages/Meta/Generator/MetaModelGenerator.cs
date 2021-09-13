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
using MetaDslx.Modeling; //4:1
using MetaDslx.Languages.Meta.Model; //5:1
using System.Collections.Immutable; //6:1
using Roslyn.Utilities; //7:1

namespace MetaDslx.Languages.Meta.Generator //1:1
{

    internal interface IMetaModelGeneratorExtensions
    {
        string EscapeName(string name); //9:8
        string ToCSharpAlias(string name); //10:8
        string GenerateDefaultValue(MetaProperty property); //11:8
        IEnumerable<ValueTuple<MetaProperty,MetaProperty>> GetAssociations(IEnumerable<ImmutableObject> objects); //12:8
        MetaElement GetType(MetaTypedElement melem); //13:8
        MetaElement GetReturnType(MetaOperation mop); //14:8
    }

    public class MetaModelGenerator //2:1
    {
        // If you see an error at this line, create a class called MetaModelGeneratorExtensions
        // which implements the interface IMetaModelGeneratorExtensions
        private IMetaModelGeneratorExtensions extensionFunctions;
        public readonly IEnumerable<ImmutableObject> Instances; //2:1

        public MetaModelGenerator() //2:1
        {
            this.extensionFunctions = new MetaModelGeneratorExtensions(this);
        }

        public MetaModelGenerator(IEnumerable<ImmutableObject> instances) : this() //2:1
        {
            this.Instances = instances;
        }


        private static IEnumerable<T> __Enumerate<T>(IEnumerator<T> items)
        {
            while (items.MoveNext())
            {
                yield return items.Current;
            }
        }

        internal string EscapeName(string name) //9:8
        {
            return this.extensionFunctions.EscapeName(name); //9:8
        }

        internal string ToCSharpAlias(string name) //10:8
        {
            return this.extensionFunctions.ToCSharpAlias(name); //10:8
        }

        internal string GenerateDefaultValue(MetaProperty property) //11:8
        {
            return this.extensionFunctions.GenerateDefaultValue(property); //11:8
        }

        internal IEnumerable<ValueTuple<MetaProperty,MetaProperty>> GetAssociations(IEnumerable<ImmutableObject> objects) //12:8
        {
            return this.extensionFunctions.GetAssociations(objects); //12:8
        }

        internal MetaElement GetType(MetaTypedElement melem) //13:8
        {
            return this.extensionFunctions.GetType(melem); //13:8
        }

        internal MetaElement GetReturnType(MetaOperation mop) //14:8
        {
            return this.extensionFunctions.GetReturnType(mop); //14:8
        }

        public string Generate(MetaModel metaModel) //16:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //17:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Write(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp4.Write(metaModel.Namespace.FullName);
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
                __out.AppendLine(false); //17:41
            }
            __out.Write("{"); //18:1
            __out.AppendLine(false); //18:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "    metamodel "; //19:1
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp6_outputWritten = true;
            }
            var __tmp8 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp8.Write(EscapeName(metaModel.Name));
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
                if (!__tmp8_last) __out.AppendLine(true);
            }
            string __tmp9_line = "(Uri=\""; //19:44
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Write(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            var __tmp10 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp10.Write(metaModel.Uri);
            var __tmp10Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp10.ToStringAndFree());
            bool __tmp10_last = __tmp10Reader.EndOfStream;
            while(!__tmp10_last)
            {
                ReadOnlySpan<char> __tmp10_line = __tmp10Reader.ReadLine();
                __tmp10_last = __tmp10Reader.EndOfStream;
                if (!__tmp10_last || !__tmp10_line.IsEmpty)
                {
                    __out.Write(__tmp10_line);
                    __tmp6_outputWritten = true;
                }
                if (!__tmp10_last) __out.AppendLine(true);
            }
            string __tmp11_line = "\",Prefix=\""; //19:65
            if (!string.IsNullOrEmpty(__tmp11_line))
            {
                __out.Write(__tmp11_line);
                __tmp6_outputWritten = true;
            }
            var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp12.Write(metaModel.Prefix);
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
                if (!__tmp12_last) __out.AppendLine(true);
            }
            string __tmp13_line = "\"); "; //19:93
            if (!string.IsNullOrEmpty(__tmp13_line))
            {
                __out.Write(__tmp13_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //19:97
            }
            __out.AppendLine(true); //20:1
            var __loop1_results = 
                (from __loop1_var1 in __Enumerate((Instances).GetEnumerator()) //21:8
                from cst in __Enumerate((__loop1_var1).GetEnumerator()).OfType<MetaConstant>() //21:19
                select new { __loop1_var1 = __loop1_var1, cst = cst}
                ).ToList(); //21:3
            for (int __loop1_iteration = 0; __loop1_iteration < __loop1_results.Count; ++__loop1_iteration)
            {
                var __tmp14 = __loop1_results[__loop1_iteration];
                var __loop1_var1 = __tmp14.__loop1_var1;
                var cst = __tmp14.cst;
                bool __tmp16_outputWritten = false;
                string __tmp15Prefix = "    "; //22:1
                var __tmp17 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp17.Write(GenerateConstant(cst));
                var __tmp17Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp17.ToStringAndFree());
                bool __tmp17_last = __tmp17Reader.EndOfStream;
                while(!__tmp17_last)
                {
                    ReadOnlySpan<char> __tmp17_line = __tmp17Reader.ReadLine();
                    __tmp17_last = __tmp17Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp15Prefix))
                    {
                        __out.Write(__tmp15Prefix);
                        __tmp16_outputWritten = true;
                    }
                    if (!__tmp17_last || !__tmp17_line.IsEmpty)
                    {
                        __out.Write(__tmp17_line);
                        __tmp16_outputWritten = true;
                    }
                    if (!__tmp17_last || __tmp16_outputWritten) __out.AppendLine(true);
                }
                if (__tmp16_outputWritten)
                {
                    __out.AppendLine(false); //22:28
                }
            }
            var __loop2_results = 
                (from __loop2_var1 in __Enumerate((Instances).GetEnumerator()) //24:8
                from enm in __Enumerate((__loop2_var1).GetEnumerator()).OfType<MetaEnum>() //24:19
                select new { __loop2_var1 = __loop2_var1, enm = enm}
                ).ToList(); //24:3
            for (int __loop2_iteration = 0; __loop2_iteration < __loop2_results.Count; ++__loop2_iteration)
            {
                var __tmp18 = __loop2_results[__loop2_iteration];
                var __loop2_var1 = __tmp18.__loop2_var1;
                var enm = __tmp18.enm;
                __out.AppendLine(true); //25:1
                bool __tmp20_outputWritten = false;
                string __tmp19Prefix = "    "; //26:1
                var __tmp21 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp21.Write(GenerateEnum(enm));
                var __tmp21Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp21.ToStringAndFree());
                bool __tmp21_last = __tmp21Reader.EndOfStream;
                while(!__tmp21_last)
                {
                    ReadOnlySpan<char> __tmp21_line = __tmp21Reader.ReadLine();
                    __tmp21_last = __tmp21Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp19Prefix))
                    {
                        __out.Write(__tmp19Prefix);
                        __tmp20_outputWritten = true;
                    }
                    if (!__tmp21_last || !__tmp21_line.IsEmpty)
                    {
                        __out.Write(__tmp21_line);
                        __tmp20_outputWritten = true;
                    }
                    if (!__tmp21_last || __tmp20_outputWritten) __out.AppendLine(true);
                }
                if (__tmp20_outputWritten)
                {
                    __out.AppendLine(false); //26:24
                }
            }
            var __loop3_results = 
                (from __loop3_var1 in __Enumerate((Instances).GetEnumerator()) //28:8
                from cls in __Enumerate((__loop3_var1).GetEnumerator()).OfType<MetaClass>() //28:19
                select new { __loop3_var1 = __loop3_var1, cls = cls}
                ).ToList(); //28:3
            for (int __loop3_iteration = 0; __loop3_iteration < __loop3_results.Count; ++__loop3_iteration)
            {
                var __tmp22 = __loop3_results[__loop3_iteration];
                var __loop3_var1 = __tmp22.__loop3_var1;
                var cls = __tmp22.cls;
                __out.AppendLine(true); //29:1
                bool __tmp24_outputWritten = false;
                string __tmp23Prefix = "    "; //30:1
                var __tmp25 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp25.Write(GenerateClass(cls));
                var __tmp25Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp25.ToStringAndFree());
                bool __tmp25_last = __tmp25Reader.EndOfStream;
                while(!__tmp25_last)
                {
                    ReadOnlySpan<char> __tmp25_line = __tmp25Reader.ReadLine();
                    __tmp25_last = __tmp25Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp23Prefix))
                    {
                        __out.Write(__tmp23Prefix);
                        __tmp24_outputWritten = true;
                    }
                    if (!__tmp25_last || !__tmp25_line.IsEmpty)
                    {
                        __out.Write(__tmp25_line);
                        __tmp24_outputWritten = true;
                    }
                    if (!__tmp25_last || __tmp24_outputWritten) __out.AppendLine(true);
                }
                if (__tmp24_outputWritten)
                {
                    __out.AppendLine(false); //30:25
                }
            }
            __out.AppendLine(true); //32:1
            var __loop4_results = 
                (from assoc in __Enumerate((GetAssociations(Instances)).GetEnumerator()) //33:8
                select new { assoc = assoc}
                ).ToList(); //33:3
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                var __tmp26 = __loop4_results[__loop4_iteration];
                var assoc = __tmp26.assoc;
                bool __tmp28_outputWritten = false;
                string __tmp27Prefix = "    "; //34:1
                var __tmp29 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp29.Write(GenerateAssociation(assoc));
                var __tmp29Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp29.ToStringAndFree());
                bool __tmp29_last = __tmp29Reader.EndOfStream;
                while(!__tmp29_last)
                {
                    ReadOnlySpan<char> __tmp29_line = __tmp29Reader.ReadLine();
                    __tmp29_last = __tmp29Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp27Prefix))
                    {
                        __out.Write(__tmp27Prefix);
                        __tmp28_outputWritten = true;
                    }
                    if (!__tmp29_last || !__tmp29_line.IsEmpty)
                    {
                        __out.Write(__tmp29_line);
                        __tmp28_outputWritten = true;
                    }
                    if (!__tmp29_last || __tmp28_outputWritten) __out.AppendLine(true);
                }
                if (__tmp28_outputWritten)
                {
                    __out.AppendLine(false); //34:33
                }
            }
            __out.Write("}"); //36:1
            __out.AppendLine(false); //36:2
            return __out.ToStringAndFree();
        }

        public string GenerateConstant(MetaConstant cst) //39:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp3.Write(GenerateComment(cst));
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
                __out.AppendLine(false); //40:23
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "const "; //41:1
            if (!string.IsNullOrEmpty(__tmp6_line))
            {
                __out.Write(__tmp6_line);
                __tmp5_outputWritten = true;
            }
            var __tmp7 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp7.Write(GenerateType(GetType(cst)));
            var __tmp7Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp7.ToStringAndFree());
            bool __tmp7_last = __tmp7Reader.EndOfStream;
            while(!__tmp7_last)
            {
                ReadOnlySpan<char> __tmp7_line = __tmp7Reader.ReadLine();
                __tmp7_last = __tmp7Reader.EndOfStream;
                if (!__tmp7_last || !__tmp7_line.IsEmpty)
                {
                    __out.Write(__tmp7_line);
                    __tmp5_outputWritten = true;
                }
                if (!__tmp7_last) __out.AppendLine(true);
            }
            string __tmp8_line = " "; //41:35
            if (!string.IsNullOrEmpty(__tmp8_line))
            {
                __out.Write(__tmp8_line);
                __tmp5_outputWritten = true;
            }
            var __tmp9 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp9.Write(EscapeName(cst.Name));
            var __tmp9Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp9.ToStringAndFree());
            bool __tmp9_last = __tmp9Reader.EndOfStream;
            while(!__tmp9_last)
            {
                ReadOnlySpan<char> __tmp9_line = __tmp9Reader.ReadLine();
                __tmp9_last = __tmp9Reader.EndOfStream;
                if (!__tmp9_last || !__tmp9_line.IsEmpty)
                {
                    __out.Write(__tmp9_line);
                    __tmp5_outputWritten = true;
                }
                if (!__tmp9_last) __out.AppendLine(true);
            }
            string __tmp10_line = ";"; //41:59
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Write(__tmp10_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //41:60
            }
            return __out.ToStringAndFree();
        }

        public string GenerateEnum(MetaEnum enm) //44:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp3.Write(GenerateComment(enm));
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
                __out.AppendLine(false); //45:23
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "enum "; //46:1
            if (!string.IsNullOrEmpty(__tmp6_line))
            {
                __out.Write(__tmp6_line);
                __tmp5_outputWritten = true;
            }
            var __tmp7 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp7.Write(EscapeName(enm.Name));
            var __tmp7Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp7.ToStringAndFree());
            bool __tmp7_last = __tmp7Reader.EndOfStream;
            while(!__tmp7_last)
            {
                ReadOnlySpan<char> __tmp7_line = __tmp7Reader.ReadLine();
                __tmp7_last = __tmp7Reader.EndOfStream;
                if (!__tmp7_last || !__tmp7_line.IsEmpty)
                {
                    __out.Write(__tmp7_line);
                    __tmp5_outputWritten = true;
                }
                if (!__tmp7_last || __tmp5_outputWritten) __out.AppendLine(true);
            }
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //46:29
            }
            __out.Write("{"); //47:1
            __out.AppendLine(false); //47:2
            var __loop5_results = 
                (from __loop5_var1 in __Enumerate((enm).GetEnumerator()) //48:8
                from lit in __Enumerate((__loop5_var1.EnumLiterals).GetEnumerator()) //48:13
                select new { __loop5_var1 = __loop5_var1, lit = lit}
                ).ToList(); //48:3
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                string sep; //48:29
                if (__loop5_iteration+1 < __loop5_results.Count) sep = ",";
                else sep = string.Empty;
                var __tmp8 = __loop5_results[__loop5_iteration];
                var __loop5_var1 = __tmp8.__loop5_var1;
                var lit = __tmp8.lit;
                bool __tmp10_outputWritten = false;
                string __tmp9Prefix = "    "; //49:1
                var __tmp11 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp11.Write(GenerateComment(lit));
                var __tmp11Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp11.ToStringAndFree());
                bool __tmp11_last = __tmp11Reader.EndOfStream;
                while(!__tmp11_last)
                {
                    ReadOnlySpan<char> __tmp11_line = __tmp11Reader.ReadLine();
                    __tmp11_last = __tmp11Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp9Prefix))
                    {
                        __out.Write(__tmp9Prefix);
                        __tmp10_outputWritten = true;
                    }
                    if (!__tmp11_last || !__tmp11_line.IsEmpty)
                    {
                        __out.Write(__tmp11_line);
                        __tmp10_outputWritten = true;
                    }
                    if (!__tmp11_last || __tmp10_outputWritten) __out.AppendLine(true);
                }
                if (__tmp10_outputWritten)
                {
                    __out.AppendLine(false); //49:27
                }
                bool __tmp13_outputWritten = false;
                string __tmp12Prefix = "    "; //50:1
                var __tmp14 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp14.Write(EscapeName(lit.Name));
                var __tmp14Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp14.ToStringAndFree());
                bool __tmp14_last = __tmp14Reader.EndOfStream;
                while(!__tmp14_last)
                {
                    ReadOnlySpan<char> __tmp14_line = __tmp14Reader.ReadLine();
                    __tmp14_last = __tmp14Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp12Prefix))
                    {
                        __out.Write(__tmp12Prefix);
                        __tmp13_outputWritten = true;
                    }
                    if (!__tmp14_last || !__tmp14_line.IsEmpty)
                    {
                        __out.Write(__tmp14_line);
                        __tmp13_outputWritten = true;
                    }
                    if (!__tmp14_last) __out.AppendLine(true);
                }
                var __tmp15 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp15.Write(sep);
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
                    if (!__tmp15_last || __tmp13_outputWritten) __out.AppendLine(true);
                }
                if (__tmp13_outputWritten)
                {
                    __out.AppendLine(false); //50:33
                }
            }
            __out.Write("}"); //52:1
            __out.AppendLine(false); //52:2
            return __out.ToStringAndFree();
        }

        public string GenerateClass(MetaClass cls) //55:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp3.Write(GenerateComment(cls));
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
                __out.AppendLine(false); //56:23
            }
            bool __tmp5_outputWritten = false;
            var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp6.Write(cls.IsAbstract ? "abstract " : "");
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
                if (!__tmp6_last) __out.AppendLine(true);
            }
            string __tmp7_line = "class "; //57:36
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp5_outputWritten = true;
            }
            var __tmp8 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp8.Write(EscapeName(cls.Name));
            var __tmp8Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp8.ToStringAndFree());
            bool __tmp8_last = __tmp8Reader.EndOfStream;
            while(!__tmp8_last)
            {
                ReadOnlySpan<char> __tmp8_line = __tmp8Reader.ReadLine();
                __tmp8_last = __tmp8Reader.EndOfStream;
                if (!__tmp8_last || !__tmp8_line.IsEmpty)
                {
                    __out.Write(__tmp8_line);
                    __tmp5_outputWritten = true;
                }
                if (!__tmp8_last) __out.AppendLine(true);
            }
            var __tmp9 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp9.Write(GenerateBaseClasses(cls));
            var __tmp9Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp9.ToStringAndFree());
            bool __tmp9_last = __tmp9Reader.EndOfStream;
            while(!__tmp9_last)
            {
                ReadOnlySpan<char> __tmp9_line = __tmp9Reader.ReadLine();
                __tmp9_last = __tmp9Reader.EndOfStream;
                if (!__tmp9_last || !__tmp9_line.IsEmpty)
                {
                    __out.Write(__tmp9_line);
                    __tmp5_outputWritten = true;
                }
                if (!__tmp9_last || __tmp5_outputWritten) __out.AppendLine(true);
            }
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //57:91
            }
            __out.Write("{"); //58:1
            __out.AppendLine(false); //58:2
            var __loop6_results = 
                (from __loop6_var1 in __Enumerate((cls).GetEnumerator()) //59:8
                from prop in __Enumerate((__loop6_var1.Properties).GetEnumerator()) //59:13
                select new { __loop6_var1 = __loop6_var1, prop = prop}
                ).ToList(); //59:3
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp10 = __loop6_results[__loop6_iteration];
                var __loop6_var1 = __tmp10.__loop6_var1;
                var prop = __tmp10.prop;
                bool __tmp12_outputWritten = false;
                string __tmp11Prefix = "	"; //60:1
                var __tmp13 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp13.Write(GenerateProperty(prop));
                var __tmp13Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp13.ToStringAndFree());
                bool __tmp13_last = __tmp13Reader.EndOfStream;
                while(!__tmp13_last)
                {
                    ReadOnlySpan<char> __tmp13_line = __tmp13Reader.ReadLine();
                    __tmp13_last = __tmp13Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp11Prefix))
                    {
                        __out.Write(__tmp11Prefix);
                        __tmp12_outputWritten = true;
                    }
                    if (!__tmp13_last || !__tmp13_line.IsEmpty)
                    {
                        __out.Write(__tmp13_line);
                        __tmp12_outputWritten = true;
                    }
                    if (!__tmp13_last || __tmp12_outputWritten) __out.AppendLine(true);
                }
                if (__tmp12_outputWritten)
                {
                    __out.AppendLine(false); //60:26
                }
            }
            var __loop7_results = 
                (from __loop7_var1 in __Enumerate((cls).GetEnumerator()) //62:8
                from op in __Enumerate((__loop7_var1.Operations).GetEnumerator()) //62:13
                select new { __loop7_var1 = __loop7_var1, op = op}
                ).ToList(); //62:3
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                var __tmp14 = __loop7_results[__loop7_iteration];
                var __loop7_var1 = __tmp14.__loop7_var1;
                var op = __tmp14.op;
                bool __tmp16_outputWritten = false;
                string __tmp15Prefix = "	"; //63:1
                var __tmp17 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp17.Write(GenerateOperation(op));
                var __tmp17Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp17.ToStringAndFree());
                bool __tmp17_last = __tmp17Reader.EndOfStream;
                while(!__tmp17_last)
                {
                    ReadOnlySpan<char> __tmp17_line = __tmp17Reader.ReadLine();
                    __tmp17_last = __tmp17Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp15Prefix))
                    {
                        __out.Write(__tmp15Prefix);
                        __tmp16_outputWritten = true;
                    }
                    if (!__tmp17_last || !__tmp17_line.IsEmpty)
                    {
                        __out.Write(__tmp17_line);
                        __tmp16_outputWritten = true;
                    }
                    if (!__tmp17_last || __tmp16_outputWritten) __out.AppendLine(true);
                }
                if (__tmp16_outputWritten)
                {
                    __out.AppendLine(false); //63:25
                }
            }
            __out.Write("}"); //65:1
            __out.AppendLine(false); //65:2
            return __out.ToStringAndFree();
        }

        public string GenerateBaseClasses(MetaClass cls) //68:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string sep = " : "; //69:2
            var __loop8_results = 
                (from __loop8_var1 in __Enumerate((cls).GetEnumerator()) //70:7
                from gen in __Enumerate((__loop8_var1.SuperClasses).GetEnumerator()) //70:12
                select new { __loop8_var1 = __loop8_var1, gen = gen}
                ).ToList(); //70:2
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp1 = __loop8_results[__loop8_iteration];
                var __loop8_var1 = __tmp1.__loop8_var1;
                var gen = __tmp1.gen;
                var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp4.Write(sep);
                var __tmp4Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp4.ToStringAndFree());
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    ReadOnlySpan<char> __tmp4_line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (!__tmp4_last || !__tmp4_line.IsEmpty)
                    {
                        __out.Write(__tmp4_line);
                    }
                    if (!__tmp4_last) __out.AppendLine(true);
                }
                var __tmp5 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp5.Write(EscapeName(gen.Name));
                var __tmp5Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp5.ToStringAndFree());
                bool __tmp5_last = __tmp5Reader.EndOfStream;
                while(!__tmp5_last)
                {
                    ReadOnlySpan<char> __tmp5_line = __tmp5Reader.ReadLine();
                    __tmp5_last = __tmp5Reader.EndOfStream;
                    if (!__tmp5_last || !__tmp5_line.IsEmpty)
                    {
                        __out.Write(__tmp5_line);
                    }
                }
                sep = ", ";
            }
            return __out.ToStringAndFree();
        }

        public string GenerateProperty(MetaProperty prop) //76:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp3.Write(GenerateComment(prop));
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
                __out.AppendLine(false); //77:24
            }
            bool __tmp5_outputWritten = false;
            var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp6.Write(GenerateContainment(prop));
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
                if (!__tmp6_last) __out.AppendLine(true);
            }
            var __tmp7 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp7.Write(GenerateModifiers(prop));
            var __tmp7Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp7.ToStringAndFree());
            bool __tmp7_last = __tmp7Reader.EndOfStream;
            while(!__tmp7_last)
            {
                ReadOnlySpan<char> __tmp7_line = __tmp7Reader.ReadLine();
                __tmp7_last = __tmp7Reader.EndOfStream;
                if (!__tmp7_last || !__tmp7_line.IsEmpty)
                {
                    __out.Write(__tmp7_line);
                    __tmp5_outputWritten = true;
                }
                if (!__tmp7_last) __out.AppendLine(true);
            }
            var __tmp8 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp8.Write(GenerateType(GetType(prop)));
            var __tmp8Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp8.ToStringAndFree());
            bool __tmp8_last = __tmp8Reader.EndOfStream;
            while(!__tmp8_last)
            {
                ReadOnlySpan<char> __tmp8_line = __tmp8Reader.ReadLine();
                __tmp8_last = __tmp8Reader.EndOfStream;
                if (!__tmp8_last || !__tmp8_line.IsEmpty)
                {
                    __out.Write(__tmp8_line);
                    __tmp5_outputWritten = true;
                }
                if (!__tmp8_last) __out.AppendLine(true);
            }
            string __tmp9_line = " "; //78:82
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Write(__tmp9_line);
                __tmp5_outputWritten = true;
            }
            var __tmp10 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp10.Write(EscapeName(prop.Name));
            var __tmp10Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp10.ToStringAndFree());
            bool __tmp10_last = __tmp10Reader.EndOfStream;
            while(!__tmp10_last)
            {
                ReadOnlySpan<char> __tmp10_line = __tmp10Reader.ReadLine();
                __tmp10_last = __tmp10Reader.EndOfStream;
                if (!__tmp10_last || !__tmp10_line.IsEmpty)
                {
                    __out.Write(__tmp10_line);
                    __tmp5_outputWritten = true;
                }
                if (!__tmp10_last) __out.AppendLine(true);
            }
            var __tmp11 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp11.Write(GenerateDefaultValue(prop));
            var __tmp11Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp11.ToStringAndFree());
            bool __tmp11_last = __tmp11Reader.EndOfStream;
            while(!__tmp11_last)
            {
                ReadOnlySpan<char> __tmp11_line = __tmp11Reader.ReadLine();
                __tmp11_last = __tmp11Reader.EndOfStream;
                if (!__tmp11_last || !__tmp11_line.IsEmpty)
                {
                    __out.Write(__tmp11_line);
                    __tmp5_outputWritten = true;
                }
                if (!__tmp11_last) __out.AppendLine(true);
            }
            var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp12.Write(GenerateRedefines(prop));
            var __tmp12Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp12.ToStringAndFree());
            bool __tmp12_last = __tmp12Reader.EndOfStream;
            while(!__tmp12_last)
            {
                ReadOnlySpan<char> __tmp12_line = __tmp12Reader.ReadLine();
                __tmp12_last = __tmp12Reader.EndOfStream;
                if (!__tmp12_last || !__tmp12_line.IsEmpty)
                {
                    __out.Write(__tmp12_line);
                    __tmp5_outputWritten = true;
                }
                if (!__tmp12_last) __out.AppendLine(true);
            }
            var __tmp13 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp13.Write(GenerateSubsets(prop));
            var __tmp13Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp13.ToStringAndFree());
            bool __tmp13_last = __tmp13Reader.EndOfStream;
            while(!__tmp13_last)
            {
                ReadOnlySpan<char> __tmp13_line = __tmp13Reader.ReadLine();
                __tmp13_last = __tmp13Reader.EndOfStream;
                if (!__tmp13_last || !__tmp13_line.IsEmpty)
                {
                    __out.Write(__tmp13_line);
                    __tmp5_outputWritten = true;
                }
                if (!__tmp13_last) __out.AppendLine(true);
            }
            string __tmp14_line = ";"; //78:184
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //78:185
            }
            return __out.ToStringAndFree();
        }

        public string GenerateContainment(MetaProperty prop) //81:1
        {
            return prop.IsContainment ? "containment " : ""; //82:2
        }

        public string GenerateModifiers(MetaProperty prop) //85:1
        {
            var __tmp1 = prop.Kind; //86:10
            if (__tmp1 == MetaPropertyKind.Readonly) //87:2
            {
                return "readonly "; //87:34
            }
            else if (__tmp1 == MetaPropertyKind.Lazy) //88:2
            {
                return "lazy "; //88:30
            }
            else if (__tmp1 == MetaPropertyKind.Derived) //89:2
            {
                return "derived "; //89:33
            }
            else if (__tmp1 == MetaPropertyKind.DerivedUnion) //90:2
            {
                return "union "; //90:38
            }//91:2
            return ""; //92:2
        }

        public string GenerateType(MetaElement t) //95:1
        {
            if (t is MetaCollectionType) //96:2
            {
                string typeName = GenerateType(((MetaCollectionType)t).InnerType); //97:3
                var __tmp1 = ((MetaCollectionType)t).Kind; //98:11
                if (__tmp1 == MetaCollectionKind.Enumerable) //99:3
                {
                    return "enumerable<" + typeName + ">"; //99:39
                }
                else if (__tmp1 == MetaCollectionKind.Set) //100:3
                {
                    return "set<" + typeName + ">"; //100:32
                }
                else if (__tmp1 == MetaCollectionKind.List) //101:3
                {
                    return "list<" + typeName + ">"; //101:33
                }
                else if (__tmp1 == MetaCollectionKind.MultiSet) //102:3
                {
                    return "multi_set<" + typeName + ">"; //102:37
                }
                else if (__tmp1 == MetaCollectionKind.MultiList) //103:3
                {
                    return "multi_list<" + typeName + ">"; //103:38
                }
                else //104:3
                {
                    return typeName; //104:12
                }//105:3
            }
            else if (t is MetaNullableType) //106:2
            {
                return GenerateNullableType((MetaNullableType)t); //107:3
            }
            else if (t is MetaPrimitiveType) //108:2
            {
                return GeneratePrimitiveType((MetaPrimitiveType)t); //109:3
            }
            else if (t is MetaClass) //110:2
            {
                return EscapeName(((MetaClass)t).Name); //111:3
            }
            else if (t is MetaEnum) //112:2
            {
                return EscapeName(((MetaEnum)t).Name); //113:3
            }
            else if (t is MetaConstant) //114:2
            {
                return EscapeName(((MetaConstant)t).Name); //115:3
            }
            else //116:2
            {
                return "ERROR"; //117:3
            }
        }

        public string GenerateNullableType(MetaNullableType t) //121:1
        {
            return GenerateType((MetaNullableType)t) + "?"; //122:2
        }

        public string GeneratePrimitiveType(MetaPrimitiveType t) //125:1
        {
            return ToCSharpAlias(t.DotNetName); //126:2
        }

        public string GenerateRedefines(MetaProperty prop) //129:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string sep = " redefines "; //130:2
            var __loop9_results = 
                (from __loop9_var1 in __Enumerate((prop).GetEnumerator()) //131:7
                from rprop in __Enumerate((__loop9_var1.RedefinedProperties).GetEnumerator()) //131:13
                select new { __loop9_var1 = __loop9_var1, rprop = rprop}
                ).ToList(); //131:2
            for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
            {
                var __tmp1 = __loop9_results[__loop9_iteration];
                var __loop9_var1 = __tmp1.__loop9_var1;
                var rprop = __tmp1.rprop;
                if (rprop.Class != null) //132:3
                {
                    var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp4.Write(sep);
                    var __tmp4Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp4.ToStringAndFree());
                    bool __tmp4_last = __tmp4Reader.EndOfStream;
                    while(!__tmp4_last)
                    {
                        ReadOnlySpan<char> __tmp4_line = __tmp4Reader.ReadLine();
                        __tmp4_last = __tmp4Reader.EndOfStream;
                        if (!__tmp4_last || !__tmp4_line.IsEmpty)
                        {
                            __out.Write(__tmp4_line);
                        }
                        if (!__tmp4_last) __out.AppendLine(true);
                    }
                    var __tmp5 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp5.Write(EscapeName(rprop.Class.Name));
                    var __tmp5Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp5.ToStringAndFree());
                    bool __tmp5_last = __tmp5Reader.EndOfStream;
                    while(!__tmp5_last)
                    {
                        ReadOnlySpan<char> __tmp5_line = __tmp5Reader.ReadLine();
                        __tmp5_last = __tmp5Reader.EndOfStream;
                        if (!__tmp5_last || !__tmp5_line.IsEmpty)
                        {
                            __out.Write(__tmp5_line);
                        }
                        if (!__tmp5_last) __out.AppendLine(true);
                    }
                    string __tmp6_line = "."; //133:37
                    if (!string.IsNullOrEmpty(__tmp6_line))
                    {
                        __out.Write(__tmp6_line);
                    }
                    var __tmp7 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp7.Write(EscapeName(rprop.Name));
                    var __tmp7Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp7.ToStringAndFree());
                    bool __tmp7_last = __tmp7Reader.EndOfStream;
                    while(!__tmp7_last)
                    {
                        ReadOnlySpan<char> __tmp7_line = __tmp7Reader.ReadLine();
                        __tmp7_last = __tmp7Reader.EndOfStream;
                        if (!__tmp7_last || !__tmp7_line.IsEmpty)
                        {
                            __out.Write(__tmp7_line);
                        }
                    }
                    sep = ", ";
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateSubsets(MetaProperty prop) //139:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string sep = " subsets "; //140:2
            var __loop10_results = 
                (from __loop10_var1 in __Enumerate((prop).GetEnumerator()) //141:7
                from sprop in __Enumerate((__loop10_var1.SubsettedProperties).GetEnumerator()) //141:13
                select new { __loop10_var1 = __loop10_var1, sprop = sprop}
                ).ToList(); //141:2
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                var __tmp1 = __loop10_results[__loop10_iteration];
                var __loop10_var1 = __tmp1.__loop10_var1;
                var sprop = __tmp1.sprop;
                if (sprop.Class != null) //142:3
                {
                    var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp4.Write(sep);
                    var __tmp4Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp4.ToStringAndFree());
                    bool __tmp4_last = __tmp4Reader.EndOfStream;
                    while(!__tmp4_last)
                    {
                        ReadOnlySpan<char> __tmp4_line = __tmp4Reader.ReadLine();
                        __tmp4_last = __tmp4Reader.EndOfStream;
                        if (!__tmp4_last || !__tmp4_line.IsEmpty)
                        {
                            __out.Write(__tmp4_line);
                        }
                        if (!__tmp4_last) __out.AppendLine(true);
                    }
                    var __tmp5 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp5.Write(EscapeName(sprop.Class.Name));
                    var __tmp5Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp5.ToStringAndFree());
                    bool __tmp5_last = __tmp5Reader.EndOfStream;
                    while(!__tmp5_last)
                    {
                        ReadOnlySpan<char> __tmp5_line = __tmp5Reader.ReadLine();
                        __tmp5_last = __tmp5Reader.EndOfStream;
                        if (!__tmp5_last || !__tmp5_line.IsEmpty)
                        {
                            __out.Write(__tmp5_line);
                        }
                        if (!__tmp5_last) __out.AppendLine(true);
                    }
                    string __tmp6_line = "."; //143:37
                    if (!string.IsNullOrEmpty(__tmp6_line))
                    {
                        __out.Write(__tmp6_line);
                    }
                    var __tmp7 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp7.Write(EscapeName(sprop.Name));
                    var __tmp7Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp7.ToStringAndFree());
                    bool __tmp7_last = __tmp7Reader.EndOfStream;
                    while(!__tmp7_last)
                    {
                        ReadOnlySpan<char> __tmp7_line = __tmp7Reader.ReadLine();
                        __tmp7_last = __tmp7Reader.EndOfStream;
                        if (!__tmp7_last || !__tmp7_line.IsEmpty)
                        {
                            __out.Write(__tmp7_line);
                        }
                    }
                    sep = ", ";
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateOperation(MetaOperation op) //149:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp3.Write(GenerateComment(op));
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
                __out.AppendLine(false); //150:22
            }
            bool __tmp5_outputWritten = false;
            var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp6.Write(GenerateReturnType(op));
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
                if (!__tmp6_last) __out.AppendLine(true);
            }
            string __tmp7_line = " "; //151:25
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp5_outputWritten = true;
            }
            var __tmp8 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp8.Write(EscapeName(op.Name));
            var __tmp8Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp8.ToStringAndFree());
            bool __tmp8_last = __tmp8Reader.EndOfStream;
            while(!__tmp8_last)
            {
                ReadOnlySpan<char> __tmp8_line = __tmp8Reader.ReadLine();
                __tmp8_last = __tmp8Reader.EndOfStream;
                if (!__tmp8_last || !__tmp8_line.IsEmpty)
                {
                    __out.Write(__tmp8_line);
                    __tmp5_outputWritten = true;
                }
                if (!__tmp8_last) __out.AppendLine(true);
            }
            string __tmp9_line = "("; //151:48
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Write(__tmp9_line);
                __tmp5_outputWritten = true;
            }
            var __tmp10 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp10.Write(GenerateParams(op));
            var __tmp10Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp10.ToStringAndFree());
            bool __tmp10_last = __tmp10Reader.EndOfStream;
            while(!__tmp10_last)
            {
                ReadOnlySpan<char> __tmp10_line = __tmp10Reader.ReadLine();
                __tmp10_last = __tmp10Reader.EndOfStream;
                if (!__tmp10_last || !__tmp10_line.IsEmpty)
                {
                    __out.Write(__tmp10_line);
                    __tmp5_outputWritten = true;
                }
                if (!__tmp10_last) __out.AppendLine(true);
            }
            string __tmp11_line = ");"; //151:69
            if (!string.IsNullOrEmpty(__tmp11_line))
            {
                __out.Write(__tmp11_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //151:71
            }
            return __out.ToStringAndFree();
        }

        public string GenerateReturnType(MetaOperation op) //154:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            var returnType = GetReturnType(op); //155:2
            if (op.IsReadonly) //156:2
            {
                __out.Write("readonly "); //157:1
            }
            if (op.IsBuilder) //159:2
            {
                __out.Write("builder "); //160:1
            }
            if (returnType == null) //162:2
            {
                __out.Write("void"); //163:1
                __out.AppendLine(false); //163:5
            }
            else //164:2
            {
                bool __tmp2_outputWritten = false;
                var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp3.Write(GenerateType(returnType));
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
                    __out.AppendLine(false); //165:27
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateParams(MetaOperation op) //169:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((op).GetEnumerator()) //170:7
                from param in __Enumerate((__loop11_var1.Parameters).GetEnumerator()) //170:11
                select new { __loop11_var1 = __loop11_var1, param = param}
                ).ToList(); //170:2
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                string sep; //170:27
                if (__loop11_iteration+1 < __loop11_results.Count) sep = ", ";
                else sep = string.Empty;
                var __tmp1 = __loop11_results[__loop11_iteration];
                var __loop11_var1 = __tmp1.__loop11_var1;
                var param = __tmp1.param;
                var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp4.Write(GenerateType(GetType(param)));
                var __tmp4Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp4.ToStringAndFree());
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    ReadOnlySpan<char> __tmp4_line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (!__tmp4_last || !__tmp4_line.IsEmpty)
                    {
                        __out.Write(__tmp4_line);
                    }
                    if (!__tmp4_last) __out.AppendLine(true);
                }
                string __tmp5_line = " "; //171:31
                if (!string.IsNullOrEmpty(__tmp5_line))
                {
                    __out.Write(__tmp5_line);
                }
                var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp6.Write(EscapeName(param.Name));
                var __tmp6Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp6.ToStringAndFree());
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(!__tmp6_last)
                {
                    ReadOnlySpan<char> __tmp6_line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if (!__tmp6_last || !__tmp6_line.IsEmpty)
                    {
                        __out.Write(__tmp6_line);
                    }
                    if (!__tmp6_last) __out.AppendLine(true);
                }
                var __tmp7 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp7.Write(sep);
                var __tmp7Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp7.ToStringAndFree());
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(!__tmp7_last)
                {
                    ReadOnlySpan<char> __tmp7_line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    if (!__tmp7_last || !__tmp7_line.IsEmpty)
                    {
                        __out.Write(__tmp7_line);
                    }
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateAssociation(ValueTuple<MetaProperty,MetaProperty> assoc) //175:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            MetaProperty first = assoc.Item1; //176:2
            MetaProperty second = assoc.Item2; //177:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "association "; //178:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Write(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp4.Write(EscapeName(first.Class.Name));
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
            string __tmp5_line = "."; //178:44
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp6.Write(EscapeName(first.Name));
            var __tmp6Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp6.ToStringAndFree());
            bool __tmp6_last = __tmp6Reader.EndOfStream;
            while(!__tmp6_last)
            {
                ReadOnlySpan<char> __tmp6_line = __tmp6Reader.ReadLine();
                __tmp6_last = __tmp6Reader.EndOfStream;
                if (!__tmp6_last || !__tmp6_line.IsEmpty)
                {
                    __out.Write(__tmp6_line);
                    __tmp2_outputWritten = true;
                }
                if (!__tmp6_last) __out.AppendLine(true);
            }
            string __tmp7_line = " with "; //178:70
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            var __tmp8 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp8.Write(EscapeName(second.Class.Name));
            var __tmp8Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp8.ToStringAndFree());
            bool __tmp8_last = __tmp8Reader.EndOfStream;
            while(!__tmp8_last)
            {
                ReadOnlySpan<char> __tmp8_line = __tmp8Reader.ReadLine();
                __tmp8_last = __tmp8Reader.EndOfStream;
                if (!__tmp8_last || !__tmp8_line.IsEmpty)
                {
                    __out.Write(__tmp8_line);
                    __tmp2_outputWritten = true;
                }
                if (!__tmp8_last) __out.AppendLine(true);
            }
            string __tmp9_line = "."; //178:108
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Write(__tmp9_line);
                __tmp2_outputWritten = true;
            }
            var __tmp10 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp10.Write(EscapeName(second.Name));
            var __tmp10Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp10.ToStringAndFree());
            bool __tmp10_last = __tmp10Reader.EndOfStream;
            while(!__tmp10_last)
            {
                ReadOnlySpan<char> __tmp10_line = __tmp10Reader.ReadLine();
                __tmp10_last = __tmp10Reader.EndOfStream;
                if (!__tmp10_last || !__tmp10_line.IsEmpty)
                {
                    __out.Write(__tmp10_line);
                    __tmp2_outputWritten = true;
                }
                if (!__tmp10_last) __out.AppendLine(true);
            }
            string __tmp11_line = ";"; //178:135
            if (!string.IsNullOrEmpty(__tmp11_line))
            {
                __out.Write(__tmp11_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //178:136
            }
            return __out.ToStringAndFree();
        }

        public string GenerateComment(MetaDocumentedElement elem) //181:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            var __loop12_results = 
                (from __loop12_var1 in __Enumerate((elem).GetEnumerator()) //182:8
                from line in __Enumerate((__loop12_var1.GetDocumentationLines()).GetEnumerator()) //182:14
                select new { __loop12_var1 = __loop12_var1, line = line}
                ).ToList(); //182:2
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp1 = __loop12_results[__loop12_iteration];
                var __loop12_var1 = __tmp1.__loop12_var1;
                var line = __tmp1.line;
                bool __tmp3_outputWritten = false;
                string __tmp4_line = "/// "; //183:1
                if (!string.IsNullOrEmpty(__tmp4_line))
                {
                    __out.Write(__tmp4_line);
                    __tmp3_outputWritten = true;
                }
                var __tmp5 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp5.Write(line);
                var __tmp5Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp5.ToStringAndFree());
                bool __tmp5_last = __tmp5Reader.EndOfStream;
                while(!__tmp5_last)
                {
                    ReadOnlySpan<char> __tmp5_line = __tmp5Reader.ReadLine();
                    __tmp5_last = __tmp5Reader.EndOfStream;
                    if (!__tmp5_last || !__tmp5_line.IsEmpty)
                    {
                        __out.Write(__tmp5_line);
                        __tmp3_outputWritten = true;
                    }
                    if (!__tmp5_last || __tmp3_outputWritten) __out.AppendLine(true);
                }
                if (__tmp3_outputWritten)
                {
                    __out.AppendLine(false); //183:11
                }
            }
            return __out.ToStringAndFree();
        }

    }
}

