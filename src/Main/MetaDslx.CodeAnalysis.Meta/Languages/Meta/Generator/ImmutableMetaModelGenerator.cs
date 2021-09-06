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

namespace MetaDslx.Languages.Meta.Generator //1:1
{

    internal interface IImmutableMetaModelGeneratorExtensions
    {
        string ToCamelCase(string identifier); //44:8
        string ToPascalCase(string identifier); //45:8
        string EscapeText(string text); //46:8
        bool IsMetaMetaModel(MetaModel mmodel); //47:8
        string GetEnumValueOf(MetaModel mmodel, Enum menum); //48:8
        string GetAttributeValueOf(MetaModel mmodel, MetaAttribute mattr); //49:8
        string GetAttributeName(MetaElement element, MetaAttribute mattr); //50:8
        string CSharpName(MetaNamespace mnamespace, NamespaceKind kind = NamespaceKind.Public, bool fullName = false); //51:8
        string CSharpName(MetaModel mmodel, ModelKind kind = ModelKind.None, bool fullName = false); //52:8
        string CSharpName(MetaType mtype, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false); //53:8
        string CSharpName(MetaProperty mproperty, MetaModel mmodel, PropertyKind kind = PropertyKind.None, bool fullName = false); //54:8
        string CSharpName(MetaConstant mconst, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false); //55:8
        ImmutableList<ImmutableObject> GetInstances(MetaModel mmodel); //56:8
        ImmutableDictionary<ImmutableObject,string> GetInstanceNames(MetaModel mmodel); //57:8
        string GetFieldName(MetaProperty mproperty, MetaClass mclass); //58:8
        bool IsReferenceType(MetaType mtype); //59:8
        string GetImmBldCallParameterNames(MetaModel mmodel, MetaOperation operation, ClassKind kind); //60:8
        string GetImmBldReturn(MetaModel mmodel, MetaOperation operation, ClassKind kind); //61:8
        MetaOperation GetFinalOperation(MetaClass cls, MetaOperation operation); //62:8
    }

    public class ImmutableMetaModelGenerator //2:1
    {
        // If you see an error at this line, create a class called ImmutableMetaModelGeneratorExtensions
        // which implements the interface IImmutableMetaModelGeneratorExtensions
        private IImmutableMetaModelGeneratorExtensions extensionFunctions;
        public readonly IEnumerable<ImmutableObject> Instances; //2:1

        public ImmutableMetaModelGenerator() //2:1
        {
            this.Properties = new __Properties();
            this.extensionFunctions = new ImmutableMetaModelGeneratorExtensions(this);
        }

        public ImmutableMetaModelGenerator(IEnumerable<ImmutableObject> instances) : this() //2:1
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

        public __Properties Properties { get; private set; } //8:1

        public class __Properties //8:1
        {
            internal __Properties()
            {
                this.CoreNs = "global::MetaDslx.Modeling"; //9:18
                this.MetaNs = "global::MetaDslx.Languages.Meta.Model"; //10:18
            }
            public string CoreNs { get; set; } //9:2
            public string MetaNs { get; set; } //10:2
        }

        public string Generate() //13:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using System;"); //14:1
            __out.AppendLine(false); //14:14
            __out.Write("using System.Collections.Generic;"); //15:1
            __out.AppendLine(false); //15:34
            __out.Write("using System.IO;"); //16:1
            __out.AppendLine(false); //16:17
            __out.Write("using System.Linq;"); //17:1
            __out.AppendLine(false); //17:19
            __out.Write("using System.Text;"); //18:1
            __out.AppendLine(false); //18:19
            __out.Write("using System.Threading;"); //19:1
            __out.AppendLine(false); //19:24
            __out.Write("using System.Threading.Tasks;"); //20:1
            __out.AppendLine(false); //20:30
            __out.Write("using System.Diagnostics;"); //21:1
            __out.AppendLine(false); //21:26
            __out.AppendLine(true); //22:1
            var __loop1_results = 
                (from __loop1_var1 in __Enumerate((Instances).GetEnumerator()) //23:7
                from mm in __Enumerate((__loop1_var1).GetEnumerator()).OfType<MetaModel>() //23:18
                select new { __loop1_var1 = __loop1_var1, mm = mm}
                ).ToList(); //23:2
            for (int __loop1_iteration = 0; __loop1_iteration < __loop1_results.Count; ++__loop1_iteration)
            {
                var __tmp1 = __loop1_results[__loop1_iteration];
                var __loop1_var1 = __tmp1.__loop1_var1;
                var mm = __tmp1.mm;
                bool __tmp3_outputWritten = false;
                var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp4.Write(GenerateMetamodel(mm));
                var __tmp4Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp4.ToStringAndFree());
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    ReadOnlySpan<char> __tmp4_line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (!__tmp4_last || !__tmp4_line.IsEmpty)
                    {
                        __out.Write(__tmp4_line);
                        __tmp3_outputWritten = true;
                    }
                    if (!__tmp4_last || __tmp3_outputWritten) __out.AppendLine(true);
                }
                if (__tmp3_outputWritten)
                {
                    __out.AppendLine(false); //24:24
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateImplementation() //29:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.Write("using System;"); //30:1
            __out.AppendLine(false); //30:14
            __out.Write("using System.Collections.Generic;"); //31:1
            __out.AppendLine(false); //31:34
            __out.Write("using System.IO;"); //32:1
            __out.AppendLine(false); //32:17
            __out.Write("using System.Linq;"); //33:1
            __out.AppendLine(false); //33:19
            __out.Write("using System.Text;"); //34:1
            __out.AppendLine(false); //34:19
            __out.Write("using System.Threading;"); //35:1
            __out.AppendLine(false); //35:24
            __out.Write("using System.Threading.Tasks;"); //36:1
            __out.AppendLine(false); //36:30
            __out.Write("using System.Diagnostics;"); //37:1
            __out.AppendLine(false); //37:26
            __out.AppendLine(true); //38:1
            var __loop2_results = 
                (from __loop2_var1 in __Enumerate((Instances).GetEnumerator()) //39:7
                from mm in __Enumerate((__loop2_var1).GetEnumerator()).OfType<MetaModel>() //39:18
                select new { __loop2_var1 = __loop2_var1, mm = mm}
                ).ToList(); //39:2
            for (int __loop2_iteration = 0; __loop2_iteration < __loop2_results.Count; ++__loop2_iteration)
            {
                var __tmp1 = __loop2_results[__loop2_iteration];
                var __loop2_var1 = __tmp1.__loop2_var1;
                var mm = __tmp1.mm;
                bool __tmp3_outputWritten = false;
                var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp4.Write(GenerateMetamodelImplementation(mm));
                var __tmp4Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp4.ToStringAndFree());
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    ReadOnlySpan<char> __tmp4_line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (!__tmp4_last || !__tmp4_line.IsEmpty)
                    {
                        __out.Write(__tmp4_line);
                        __tmp3_outputWritten = true;
                    }
                    if (!__tmp4_last || __tmp3_outputWritten) __out.AppendLine(true);
                }
                if (__tmp3_outputWritten)
                {
                    __out.AppendLine(false); //40:38
                }
            }
            return __out.ToStringAndFree();
        }

        internal string ToCamelCase(string identifier) //44:8
        {
            return this.extensionFunctions.ToCamelCase(identifier); //44:8
        }

        internal string ToPascalCase(string identifier) //45:8
        {
            return this.extensionFunctions.ToPascalCase(identifier); //45:8
        }

        internal string EscapeText(string text) //46:8
        {
            return this.extensionFunctions.EscapeText(text); //46:8
        }

        internal bool IsMetaMetaModel(MetaModel mmodel) //47:8
        {
            return this.extensionFunctions.IsMetaMetaModel(mmodel); //47:8
        }

        internal string GetEnumValueOf(MetaModel mmodel, Enum menum) //48:8
        {
            return this.extensionFunctions.GetEnumValueOf(mmodel, menum); //48:8
        }

        internal string GetAttributeValueOf(MetaModel mmodel, MetaAttribute mattr) //49:8
        {
            return this.extensionFunctions.GetAttributeValueOf(mmodel, mattr); //49:8
        }

        internal string GetAttributeName(MetaElement element, MetaAttribute mattr) //50:8
        {
            return this.extensionFunctions.GetAttributeName(element, mattr); //50:8
        }

        internal string CSharpName(MetaNamespace mnamespace, NamespaceKind kind = NamespaceKind.Public, bool fullName = false) //51:8
        {
            return this.extensionFunctions.CSharpName(mnamespace, kind, fullName); //51:8
        }

        internal string CSharpName(MetaModel mmodel, ModelKind kind = ModelKind.None, bool fullName = false) //52:8
        {
            return this.extensionFunctions.CSharpName(mmodel, kind, fullName); //52:8
        }

        internal string CSharpName(MetaType mtype, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false) //53:8
        {
            return this.extensionFunctions.CSharpName(mtype, mmodel, kind, fullName); //53:8
        }

        internal string CSharpName(MetaProperty mproperty, MetaModel mmodel, PropertyKind kind = PropertyKind.None, bool fullName = false) //54:8
        {
            return this.extensionFunctions.CSharpName(mproperty, mmodel, kind, fullName); //54:8
        }

        internal string CSharpName(MetaConstant mconst, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false) //55:8
        {
            return this.extensionFunctions.CSharpName(mconst, mmodel, kind, fullName); //55:8
        }

        internal ImmutableList<ImmutableObject> GetInstances(MetaModel mmodel) //56:8
        {
            return this.extensionFunctions.GetInstances(mmodel); //56:8
        }

        internal ImmutableDictionary<ImmutableObject,string> GetInstanceNames(MetaModel mmodel) //57:8
        {
            return this.extensionFunctions.GetInstanceNames(mmodel); //57:8
        }

        internal string GetFieldName(MetaProperty mproperty, MetaClass mclass) //58:8
        {
            return this.extensionFunctions.GetFieldName(mproperty, mclass); //58:8
        }

        internal bool IsReferenceType(MetaType mtype) //59:8
        {
            return this.extensionFunctions.IsReferenceType(mtype); //59:8
        }

        internal string GetImmBldCallParameterNames(MetaModel mmodel, MetaOperation operation, ClassKind kind) //60:8
        {
            return this.extensionFunctions.GetImmBldCallParameterNames(mmodel, operation, kind); //60:8
        }

        internal string GetImmBldReturn(MetaModel mmodel, MetaOperation operation, ClassKind kind) //61:8
        {
            return this.extensionFunctions.GetImmBldReturn(mmodel, operation, kind); //61:8
        }

        internal MetaOperation GetFinalOperation(MetaClass cls, MetaOperation operation) //62:8
        {
            return this.extensionFunctions.GetFinalOperation(cls, operation); //62:8
        }

        public string GenerateDocumentation(MetaDocumentedElement elem) //64:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            var lines = elem.GetDocumentationLines(); //65:2
            if (lines.Count > 0) //66:2
            {
                var __loop3_results = 
                    (from line in __Enumerate((lines).GetEnumerator()) //67:8
                    select new { line = line}
                    ).ToList(); //67:3
                for (int __loop3_iteration = 0; __loop3_iteration < __loop3_results.Count; ++__loop3_iteration)
                {
                    var __tmp1 = __loop3_results[__loop3_iteration];
                    var line = __tmp1.line;
                    bool __tmp3_outputWritten = false;
                    string __tmp4_line = "///"; //68:1
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
                        __out.AppendLine(false); //68:10
                    }
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateAttributes(MetaElement elem) //73:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            var __loop4_results = 
                (from __loop4_var1 in __Enumerate((elem).GetEnumerator()) //74:7
                from attr in __Enumerate((__loop4_var1.Attributes).GetEnumerator()) //74:13
                select new { __loop4_var1 = __loop4_var1, attr = attr}
                ).ToList(); //74:2
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                var __tmp1 = __loop4_results[__loop4_iteration];
                var __loop4_var1 = __tmp1.__loop4_var1;
                var attr = __tmp1.attr;
                bool __tmp3_outputWritten = false;
                var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp4.Write("[");
                var __tmp4Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp4.ToStringAndFree());
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    ReadOnlySpan<char> __tmp4_line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if (!__tmp4_last || !__tmp4_line.IsEmpty)
                    {
                        __out.Write(__tmp4_line);
                        __tmp3_outputWritten = true;
                    }
                    if (!__tmp4_last) __out.AppendLine(true);
                }
                var __tmp5 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp5.Write(GetAttributeName(elem, attr));
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
                    if (!__tmp5_last) __out.AppendLine(true);
                }
                var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp6.Write("]");
                var __tmp6Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp6.ToStringAndFree());
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(!__tmp6_last)
                {
                    ReadOnlySpan<char> __tmp6_line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if (!__tmp6_last || !__tmp6_line.IsEmpty)
                    {
                        __out.Write(__tmp6_line);
                        __tmp3_outputWritten = true;
                    }
                    if (!__tmp6_last || __tmp3_outputWritten) __out.AppendLine(true);
                }
                if (__tmp3_outputWritten)
                {
                    __out.AppendLine(false); //75:41
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateMetamodel(MetaModel model) //79:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //80:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Write(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp4.Write(CSharpName(model.Namespace, NamespaceKind.Public, true));
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
                __out.AppendLine(false); //80:67
            }
            __out.Write("{"); //81:1
            __out.AppendLine(false); //81:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	using global::"; //82:1
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp6_outputWritten = true;
            }
            var __tmp8 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp8.Write(CSharpName(model.Namespace, NamespaceKind.Internal, true));
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
            string __tmp9_line = ";"; //82:74
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Write(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //82:75
            }
            __out.AppendLine(true); //83:1
            bool __tmp11_outputWritten = false;
            string __tmp10Prefix = "	"; //84:1
            var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp12.Write(GenerateMetadata(model));
            var __tmp12Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp12.ToStringAndFree());
            bool __tmp12_last = __tmp12Reader.EndOfStream;
            while(!__tmp12_last)
            {
                ReadOnlySpan<char> __tmp12_line = __tmp12Reader.ReadLine();
                __tmp12_last = __tmp12Reader.EndOfStream;
                if (!string.IsNullOrEmpty(__tmp10Prefix))
                {
                    __out.Write(__tmp10Prefix);
                    __tmp11_outputWritten = true;
                }
                if (!__tmp12_last || !__tmp12_line.IsEmpty)
                {
                    __out.Write(__tmp12_line);
                    __tmp11_outputWritten = true;
                }
                if (!__tmp12_last || __tmp11_outputWritten) __out.AppendLine(true);
            }
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //84:27
            }
            __out.AppendLine(true); //85:1
            bool __tmp14_outputWritten = false;
            string __tmp13Prefix = "	"; //86:1
            var __tmp15 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp15.Write(GenerateMetaModelInstance(model));
            var __tmp15Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp15.ToStringAndFree());
            bool __tmp15_last = __tmp15Reader.EndOfStream;
            while(!__tmp15_last)
            {
                ReadOnlySpan<char> __tmp15_line = __tmp15Reader.ReadLine();
                __tmp15_last = __tmp15Reader.EndOfStream;
                if (!string.IsNullOrEmpty(__tmp13Prefix))
                {
                    __out.Write(__tmp13Prefix);
                    __tmp14_outputWritten = true;
                }
                if (!__tmp15_last || !__tmp15_line.IsEmpty)
                {
                    __out.Write(__tmp15_line);
                    __tmp14_outputWritten = true;
                }
                if (!__tmp15_last || __tmp14_outputWritten) __out.AppendLine(true);
            }
            if (__tmp14_outputWritten)
            {
                __out.AppendLine(false); //86:36
            }
            __out.AppendLine(true); //87:1
            bool __tmp17_outputWritten = false;
            string __tmp16Prefix = "	"; //88:1
            var __tmp18 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp18.Write(GenerateFactory(model));
            var __tmp18Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp18.ToStringAndFree());
            bool __tmp18_last = __tmp18Reader.EndOfStream;
            while(!__tmp18_last)
            {
                ReadOnlySpan<char> __tmp18_line = __tmp18Reader.ReadLine();
                __tmp18_last = __tmp18Reader.EndOfStream;
                if (!string.IsNullOrEmpty(__tmp16Prefix))
                {
                    __out.Write(__tmp16Prefix);
                    __tmp17_outputWritten = true;
                }
                if (!__tmp18_last || !__tmp18_line.IsEmpty)
                {
                    __out.Write(__tmp18_line);
                    __tmp17_outputWritten = true;
                }
                if (!__tmp18_last || __tmp17_outputWritten) __out.AppendLine(true);
            }
            if (__tmp17_outputWritten)
            {
                __out.AppendLine(false); //88:26
            }
            __out.AppendLine(true); //89:1
            var __loop5_results = 
                (from __loop5_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //90:8
                from enm in __Enumerate((__loop5_var1).GetEnumerator()).OfType<MetaEnum>() //90:38
                select new { __loop5_var1 = __loop5_var1, enm = enm}
                ).ToList(); //90:3
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                var __tmp19 = __loop5_results[__loop5_iteration];
                var __loop5_var1 = __tmp19.__loop5_var1;
                var enm = __tmp19.enm;
                bool __tmp21_outputWritten = false;
                string __tmp20Prefix = "	"; //91:1
                var __tmp22 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp22.Write(GenerateEnum(model, enm));
                var __tmp22Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp22.ToStringAndFree());
                bool __tmp22_last = __tmp22Reader.EndOfStream;
                while(!__tmp22_last)
                {
                    ReadOnlySpan<char> __tmp22_line = __tmp22Reader.ReadLine();
                    __tmp22_last = __tmp22Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp20Prefix))
                    {
                        __out.Write(__tmp20Prefix);
                        __tmp21_outputWritten = true;
                    }
                    if (!__tmp22_last || !__tmp22_line.IsEmpty)
                    {
                        __out.Write(__tmp22_line);
                        __tmp21_outputWritten = true;
                    }
                    if (!__tmp22_last || __tmp21_outputWritten) __out.AppendLine(true);
                }
                if (__tmp21_outputWritten)
                {
                    __out.AppendLine(false); //91:28
                }
            }
            var __loop6_results = 
                (from __loop6_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //93:8
                from cls in __Enumerate((__loop6_var1).GetEnumerator()).OfType<MetaClass>() //93:38
                select new { __loop6_var1 = __loop6_var1, cls = cls}
                ).ToList(); //93:3
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp23 = __loop6_results[__loop6_iteration];
                var __loop6_var1 = __tmp23.__loop6_var1;
                var cls = __tmp23.cls;
                bool __tmp25_outputWritten = false;
                string __tmp24Prefix = "	"; //94:1
                var __tmp26 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp26.Write(GenerateClass(model, cls));
                var __tmp26Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp26.ToStringAndFree());
                bool __tmp26_last = __tmp26Reader.EndOfStream;
                while(!__tmp26_last)
                {
                    ReadOnlySpan<char> __tmp26_line = __tmp26Reader.ReadLine();
                    __tmp26_last = __tmp26Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp24Prefix))
                    {
                        __out.Write(__tmp24Prefix);
                        __tmp25_outputWritten = true;
                    }
                    if (!__tmp26_last || !__tmp26_line.IsEmpty)
                    {
                        __out.Write(__tmp26_line);
                        __tmp25_outputWritten = true;
                    }
                    if (!__tmp26_last || __tmp25_outputWritten) __out.AppendLine(true);
                }
                if (__tmp25_outputWritten)
                {
                    __out.AppendLine(false); //94:29
                }
            }
            __out.AppendLine(true); //96:1
            bool __tmp28_outputWritten = false;
            string __tmp27Prefix = "	"; //97:1
            var __tmp29 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp29.Write(GenerateMetaModelDescriptor(model));
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
                __out.AppendLine(false); //97:38
            }
            __out.Write("}"); //98:1
            __out.AppendLine(false); //98:2
            __out.AppendLine(true); //99:1
            bool __tmp31_outputWritten = false;
            string __tmp32_line = "namespace "; //100:1
            if (!string.IsNullOrEmpty(__tmp32_line))
            {
                __out.Write(__tmp32_line);
                __tmp31_outputWritten = true;
            }
            var __tmp33 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp33.Write(CSharpName(model.Namespace, NamespaceKind.Internal, true));
            var __tmp33Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp33.ToStringAndFree());
            bool __tmp33_last = __tmp33Reader.EndOfStream;
            while(!__tmp33_last)
            {
                ReadOnlySpan<char> __tmp33_line = __tmp33Reader.ReadLine();
                __tmp33_last = __tmp33Reader.EndOfStream;
                if (!__tmp33_last || !__tmp33_line.IsEmpty)
                {
                    __out.Write(__tmp33_line);
                    __tmp31_outputWritten = true;
                }
                if (!__tmp33_last || __tmp31_outputWritten) __out.AppendLine(true);
            }
            if (__tmp31_outputWritten)
            {
                __out.AppendLine(false); //100:69
            }
            __out.Write("{"); //101:1
            __out.AppendLine(false); //101:2
            var __loop7_results = 
                (from __loop7_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //102:8
                from cls in __Enumerate((__loop7_var1).GetEnumerator()).OfType<MetaClass>() //102:38
                select new { __loop7_var1 = __loop7_var1, cls = cls}
                ).ToList(); //102:3
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                var __tmp34 = __loop7_results[__loop7_iteration];
                var __loop7_var1 = __tmp34.__loop7_var1;
                var cls = __tmp34.cls;
                bool __tmp36_outputWritten = false;
                string __tmp35Prefix = "	"; //103:1
                var __tmp37 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp37.Write(GenerateClassInternal(model, cls));
                var __tmp37Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp37.ToStringAndFree());
                bool __tmp37_last = __tmp37Reader.EndOfStream;
                while(!__tmp37_last)
                {
                    ReadOnlySpan<char> __tmp37_line = __tmp37Reader.ReadLine();
                    __tmp37_last = __tmp37Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp35Prefix))
                    {
                        __out.Write(__tmp35Prefix);
                        __tmp36_outputWritten = true;
                    }
                    if (!__tmp37_last || !__tmp37_line.IsEmpty)
                    {
                        __out.Write(__tmp37_line);
                        __tmp36_outputWritten = true;
                    }
                    if (!__tmp37_last || __tmp36_outputWritten) __out.AppendLine(true);
                }
                if (__tmp36_outputWritten)
                {
                    __out.AppendLine(false); //103:37
                }
            }
            __out.AppendLine(true); //105:1
            bool __tmp39_outputWritten = false;
            string __tmp38Prefix = "	"; //106:1
            var __tmp40 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp40.Write(GenerateMetaModelBuilderInstance(model));
            var __tmp40Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp40.ToStringAndFree());
            bool __tmp40_last = __tmp40Reader.EndOfStream;
            while(!__tmp40_last)
            {
                ReadOnlySpan<char> __tmp40_line = __tmp40Reader.ReadLine();
                __tmp40_last = __tmp40Reader.EndOfStream;
                if (!string.IsNullOrEmpty(__tmp38Prefix))
                {
                    __out.Write(__tmp38Prefix);
                    __tmp39_outputWritten = true;
                }
                if (!__tmp40_last || !__tmp40_line.IsEmpty)
                {
                    __out.Write(__tmp40_line);
                    __tmp39_outputWritten = true;
                }
                if (!__tmp40_last || __tmp39_outputWritten) __out.AppendLine(true);
            }
            if (__tmp39_outputWritten)
            {
                __out.AppendLine(false); //106:43
            }
            __out.AppendLine(true); //107:1
            bool __tmp42_outputWritten = false;
            string __tmp41Prefix = "	"; //108:1
            var __tmp43 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp43.Write(GenerateImplementationBase(model));
            var __tmp43Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp43.ToStringAndFree());
            bool __tmp43_last = __tmp43Reader.EndOfStream;
            while(!__tmp43_last)
            {
                ReadOnlySpan<char> __tmp43_line = __tmp43Reader.ReadLine();
                __tmp43_last = __tmp43Reader.EndOfStream;
                if (!string.IsNullOrEmpty(__tmp41Prefix))
                {
                    __out.Write(__tmp41Prefix);
                    __tmp42_outputWritten = true;
                }
                if (!__tmp43_last || !__tmp43_line.IsEmpty)
                {
                    __out.Write(__tmp43_line);
                    __tmp42_outputWritten = true;
                }
                if (!__tmp43_last || __tmp42_outputWritten) __out.AppendLine(true);
            }
            if (__tmp42_outputWritten)
            {
                __out.AppendLine(false); //108:37
            }
            __out.AppendLine(true); //109:1
            bool __tmp45_outputWritten = false;
            string __tmp44Prefix = "	"; //110:1
            var __tmp46 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp46.Write(GenerateImplementationProvider(model));
            var __tmp46Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp46.ToStringAndFree());
            bool __tmp46_last = __tmp46Reader.EndOfStream;
            while(!__tmp46_last)
            {
                ReadOnlySpan<char> __tmp46_line = __tmp46Reader.ReadLine();
                __tmp46_last = __tmp46Reader.EndOfStream;
                if (!string.IsNullOrEmpty(__tmp44Prefix))
                {
                    __out.Write(__tmp44Prefix);
                    __tmp45_outputWritten = true;
                }
                if (!__tmp46_last || !__tmp46_line.IsEmpty)
                {
                    __out.Write(__tmp46_line);
                    __tmp45_outputWritten = true;
                }
                if (!__tmp46_last || __tmp45_outputWritten) __out.AppendLine(true);
            }
            if (__tmp45_outputWritten)
            {
                __out.AppendLine(false); //110:41
            }
            __out.Write("}"); //111:1
            __out.AppendLine(false); //111:2
            return __out.ToStringAndFree();
        }

        public string GenerateMetamodelImplementation(MetaModel model) //114:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.AppendLine(true); //115:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //116:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Write(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp4.Write(CSharpName(model.Namespace, NamespaceKind.Internal, true));
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
                __out.AppendLine(false); //116:69
            }
            __out.Write("{"); //117:1
            __out.AppendLine(false); //117:2
            bool __tmp6_outputWritten = false;
            string __tmp5Prefix = "	"; //118:1
            var __tmp7 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp7.Write(GenerateImplementation(model));
            var __tmp7Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp7.ToStringAndFree());
            bool __tmp7_last = __tmp7Reader.EndOfStream;
            while(!__tmp7_last)
            {
                ReadOnlySpan<char> __tmp7_line = __tmp7Reader.ReadLine();
                __tmp7_last = __tmp7Reader.EndOfStream;
                if (!string.IsNullOrEmpty(__tmp5Prefix))
                {
                    __out.Write(__tmp5Prefix);
                    __tmp6_outputWritten = true;
                }
                if (!__tmp7_last || !__tmp7_line.IsEmpty)
                {
                    __out.Write(__tmp7_line);
                    __tmp6_outputWritten = true;
                }
                if (!__tmp7_last || __tmp6_outputWritten) __out.AppendLine(true);
            }
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //118:33
            }
            __out.Write("}"); //119:1
            __out.AppendLine(false); //119:2
            return __out.ToStringAndFree();
        }

        public string GenerateMetadata(MetaModel model) //122:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //123:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //124:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Write(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp4.Write(CSharpName(model, ModelKind.Metadata));
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
            string __tmp5_line = " : "; //124:52
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp6.Write(Properties.CoreNs);
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
            string __tmp7_line = ".ModelMetadata"; //124:74
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //124:88
            }
            __out.Write("{"); //125:1
            __out.AppendLine(false); //125:2
            bool __tmp9_outputWritten = false;
            string __tmp10_line = "	public "; //126:1
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Write(__tmp10_line);
                __tmp9_outputWritten = true;
            }
            var __tmp11 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp11.Write(CSharpName(model, ModelKind.Metadata));
            var __tmp11Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp11.ToStringAndFree());
            bool __tmp11_last = __tmp11Reader.EndOfStream;
            while(!__tmp11_last)
            {
                ReadOnlySpan<char> __tmp11_line = __tmp11Reader.ReadLine();
                __tmp11_last = __tmp11Reader.EndOfStream;
                if (!__tmp11_last || !__tmp11_line.IsEmpty)
                {
                    __out.Write(__tmp11_line);
                    __tmp9_outputWritten = true;
                }
                if (!__tmp11_last) __out.AppendLine(true);
            }
            string __tmp12_line = "(string name, "; //126:47
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Write(__tmp12_line);
                __tmp9_outputWritten = true;
            }
            var __tmp13 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp13.Write(Properties.CoreNs);
            var __tmp13Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp13.ToStringAndFree());
            bool __tmp13_last = __tmp13Reader.EndOfStream;
            while(!__tmp13_last)
            {
                ReadOnlySpan<char> __tmp13_line = __tmp13Reader.ReadLine();
                __tmp13_last = __tmp13Reader.EndOfStream;
                if (!__tmp13_last || !__tmp13_line.IsEmpty)
                {
                    __out.Write(__tmp13_line);
                    __tmp9_outputWritten = true;
                }
                if (!__tmp13_last) __out.AppendLine(true);
            }
            string __tmp14_line = ".ModelVersion version, string uri, string prefix, string namespaceName)"; //126:80
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp9_outputWritten = true;
            }
            if (__tmp9_outputWritten) __out.AppendLine(true);
            if (__tmp9_outputWritten)
            {
                __out.AppendLine(false); //126:151
            }
            __out.Write("		: base(name, version, uri, prefix, namespaceName)"); //127:1
            __out.AppendLine(false); //127:52
            __out.Write("	{"); //128:1
            __out.AppendLine(false); //128:3
            __out.Write("	}"); //129:1
            __out.AppendLine(false); //129:3
            __out.AppendLine(true); //130:1
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "    protected override "; //131:1
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Write(__tmp17_line);
                __tmp16_outputWritten = true;
            }
            var __tmp18 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp18.Write(Properties.CoreNs);
            var __tmp18Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp18.ToStringAndFree());
            bool __tmp18_last = __tmp18Reader.EndOfStream;
            while(!__tmp18_last)
            {
                ReadOnlySpan<char> __tmp18_line = __tmp18Reader.ReadLine();
                __tmp18_last = __tmp18Reader.EndOfStream;
                if (!__tmp18_last || !__tmp18_line.IsEmpty)
                {
                    __out.Write(__tmp18_line);
                    __tmp16_outputWritten = true;
                }
                if (!__tmp18_last) __out.AppendLine(true);
            }
            string __tmp19_line = ".ModelMetadata Create(string name, "; //131:43
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Write(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            var __tmp20 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp20.Write(Properties.CoreNs);
            var __tmp20Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp20.ToStringAndFree());
            bool __tmp20_last = __tmp20Reader.EndOfStream;
            while(!__tmp20_last)
            {
                ReadOnlySpan<char> __tmp20_line = __tmp20Reader.ReadLine();
                __tmp20_last = __tmp20Reader.EndOfStream;
                if (!__tmp20_last || !__tmp20_line.IsEmpty)
                {
                    __out.Write(__tmp20_line);
                    __tmp16_outputWritten = true;
                }
                if (!__tmp20_last) __out.AppendLine(true);
            }
            string __tmp21_line = ".ModelVersion version, string uri, string prefix, string namespaceName)"; //131:97
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //131:168
            }
            __out.Write("    {"); //132:1
            __out.AppendLine(false); //132:6
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "        return new "; //133:1
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Write(__tmp24_line);
                __tmp23_outputWritten = true;
            }
            var __tmp25 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp25.Write(CSharpName(model, ModelKind.Metadata));
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
            string __tmp26_line = "(name, version, uri, prefix, namespaceName);"; //133:58
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Write(__tmp26_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //133:102
            }
            __out.Write("    }"); //134:1
            __out.AppendLine(false); //134:6
            __out.AppendLine(true); //135:1
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "	public override "; //136:1
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Write(__tmp29_line);
                __tmp28_outputWritten = true;
            }
            var __tmp30 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp30.Write(Properties.CoreNs);
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
            string __tmp31_line = ".IModelFactory CreateFactory("; //136:37
            if (!string.IsNullOrEmpty(__tmp31_line))
            {
                __out.Write(__tmp31_line);
                __tmp28_outputWritten = true;
            }
            var __tmp32 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp32.Write(Properties.CoreNs);
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
            string __tmp33_line = ".MutableModel model, "; //136:85
            if (!string.IsNullOrEmpty(__tmp33_line))
            {
                __out.Write(__tmp33_line);
                __tmp28_outputWritten = true;
            }
            var __tmp34 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp34.Write(Properties.CoreNs);
            var __tmp34Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp34.ToStringAndFree());
            bool __tmp34_last = __tmp34Reader.EndOfStream;
            while(!__tmp34_last)
            {
                ReadOnlySpan<char> __tmp34_line = __tmp34Reader.ReadLine();
                __tmp34_last = __tmp34Reader.EndOfStream;
                if (!__tmp34_last || !__tmp34_line.IsEmpty)
                {
                    __out.Write(__tmp34_line);
                    __tmp28_outputWritten = true;
                }
                if (!__tmp34_last) __out.AppendLine(true);
            }
            string __tmp35_line = ".ModelFactoryFlags flags = "; //136:125
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Write(__tmp35_line);
                __tmp28_outputWritten = true;
            }
            var __tmp36 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp36.Write(Properties.CoreNs);
            var __tmp36Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp36.ToStringAndFree());
            bool __tmp36_last = __tmp36Reader.EndOfStream;
            while(!__tmp36_last)
            {
                ReadOnlySpan<char> __tmp36_line = __tmp36Reader.ReadLine();
                __tmp36_last = __tmp36Reader.EndOfStream;
                if (!__tmp36_last || !__tmp36_line.IsEmpty)
                {
                    __out.Write(__tmp36_line);
                    __tmp28_outputWritten = true;
                }
                if (!__tmp36_last) __out.AppendLine(true);
            }
            string __tmp37_line = ".ModelFactoryFlags.None)"; //136:171
            if (!string.IsNullOrEmpty(__tmp37_line))
            {
                __out.Write(__tmp37_line);
                __tmp28_outputWritten = true;
            }
            if (__tmp28_outputWritten) __out.AppendLine(true);
            if (__tmp28_outputWritten)
            {
                __out.AppendLine(false); //136:195
            }
            __out.Write("	{"); //137:1
            __out.AppendLine(false); //137:3
            bool __tmp39_outputWritten = false;
            string __tmp40_line = "		return new "; //138:1
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Write(__tmp40_line);
                __tmp39_outputWritten = true;
            }
            var __tmp41 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp41.Write(CSharpName(model, ModelKind.Factory));
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
            string __tmp42_line = "(model, flags);"; //138:51
            if (!string.IsNullOrEmpty(__tmp42_line))
            {
                __out.Write(__tmp42_line);
                __tmp39_outputWritten = true;
            }
            if (__tmp39_outputWritten) __out.AppendLine(true);
            if (__tmp39_outputWritten)
            {
                __out.AppendLine(false); //138:66
            }
            __out.Write("	}"); //139:1
            __out.AppendLine(false); //139:3
            __out.Write("}"); //140:1
            __out.AppendLine(false); //140:2
            return __out.ToStringAndFree();
        }

        public string GenerateMetaModelInstance(MetaModel model) //143:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //144:2
            bool metaMetaModel = IsMetaMetaModel(model); //145:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //146:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Write(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp4.Write(CSharpName(model, ModelKind.ImmutableInstance));
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
                __out.AppendLine(false); //146:61
            }
            __out.Write("{"); //147:1
            __out.AppendLine(false); //147:2
            __out.Write("	private static bool initialized;"); //148:1
            __out.AppendLine(false); //148:34
            __out.AppendLine(true); //149:1
            __out.Write("	public static bool IsInitialized"); //150:1
            __out.AppendLine(false); //150:34
            __out.Write("	{"); //151:1
            __out.AppendLine(false); //151:3
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "		get { return "; //152:1
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp6_outputWritten = true;
            }
            var __tmp8 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp8.Write(CSharpName(model, ModelKind.ImmutableInstance));
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
            string __tmp9_line = ".initialized; }"; //152:63
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Write(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //152:78
            }
            __out.Write("	}"); //153:1
            __out.AppendLine(false); //153:3
            __out.AppendLine(true); //154:1
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	public static readonly "; //155:1
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Write(__tmp12_line);
                __tmp11_outputWritten = true;
            }
            var __tmp13 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp13.Write(CSharpName(model, ModelKind.Metadata, true));
            var __tmp13Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp13.ToStringAndFree());
            bool __tmp13_last = __tmp13Reader.EndOfStream;
            while(!__tmp13_last)
            {
                ReadOnlySpan<char> __tmp13_line = __tmp13Reader.ReadLine();
                __tmp13_last = __tmp13Reader.EndOfStream;
                if (!__tmp13_last || !__tmp13_line.IsEmpty)
                {
                    __out.Write(__tmp13_line);
                    __tmp11_outputWritten = true;
                }
                if (!__tmp13_last) __out.AppendLine(true);
            }
            string __tmp14_line = " MMetadata;"; //155:69
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //155:80
            }
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "	public static readonly "; //156:1
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Write(__tmp17_line);
                __tmp16_outputWritten = true;
            }
            var __tmp18 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp18.Write(Properties.CoreNs);
            var __tmp18Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp18.ToStringAndFree());
            bool __tmp18_last = __tmp18Reader.EndOfStream;
            while(!__tmp18_last)
            {
                ReadOnlySpan<char> __tmp18_line = __tmp18Reader.ReadLine();
                __tmp18_last = __tmp18Reader.EndOfStream;
                if (!__tmp18_last || !__tmp18_line.IsEmpty)
                {
                    __out.Write(__tmp18_line);
                    __tmp16_outputWritten = true;
                }
                if (!__tmp18_last) __out.AppendLine(true);
            }
            string __tmp19_line = ".ImmutableModel MModel;"; //156:44
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Write(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //156:67
            }
            __out.AppendLine(true); //157:1
            var __loop8_results = 
                (from __loop8_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //158:8
                from cst in __Enumerate((__loop8_var1).GetEnumerator()).OfType<MetaConstant>() //158:38
                select new { __loop8_var1 = __loop8_var1, cst = cst}
                ).ToList(); //158:3
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp20 = __loop8_results[__loop8_iteration];
                var __loop8_var1 = __tmp20.__loop8_var1;
                var cst = __tmp20.cst;
                bool __tmp22_outputWritten = false;
                string __tmp21Prefix = "	"; //159:1
                var __tmp23 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp23.Write(GenerateDocumentation(cst));
                var __tmp23Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp23.ToStringAndFree());
                bool __tmp23_last = __tmp23Reader.EndOfStream;
                while(!__tmp23_last)
                {
                    ReadOnlySpan<char> __tmp23_line = __tmp23Reader.ReadLine();
                    __tmp23_last = __tmp23Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp21Prefix))
                    {
                        __out.Write(__tmp21Prefix);
                        __tmp22_outputWritten = true;
                    }
                    if (!__tmp23_last || !__tmp23_line.IsEmpty)
                    {
                        __out.Write(__tmp23_line);
                        __tmp22_outputWritten = true;
                    }
                    if (!__tmp23_last || __tmp22_outputWritten) __out.AppendLine(true);
                }
                if (__tmp22_outputWritten)
                {
                    __out.AppendLine(false); //159:30
                }
                if (metaMetaModel) //160:4
                {
                    bool __tmp25_outputWritten = false;
                    string __tmp26_line = "	public static readonly "; //161:1
                    if (!string.IsNullOrEmpty(__tmp26_line))
                    {
                        __out.Write(__tmp26_line);
                        __tmp25_outputWritten = true;
                    }
                    var __tmp27 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp27.Write(CSharpName(cst.Type, model, ClassKind.Immutable));
                    var __tmp27Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp27.ToStringAndFree());
                    bool __tmp27_last = __tmp27Reader.EndOfStream;
                    while(!__tmp27_last)
                    {
                        ReadOnlySpan<char> __tmp27_line = __tmp27Reader.ReadLine();
                        __tmp27_last = __tmp27Reader.EndOfStream;
                        if (!__tmp27_last || !__tmp27_line.IsEmpty)
                        {
                            __out.Write(__tmp27_line);
                            __tmp25_outputWritten = true;
                        }
                        if (!__tmp27_last) __out.AppendLine(true);
                    }
                    string __tmp28_line = " "; //161:74
                    if (!string.IsNullOrEmpty(__tmp28_line))
                    {
                        __out.Write(__tmp28_line);
                        __tmp25_outputWritten = true;
                    }
                    var __tmp29 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp29.Write(CSharpName(cst, model, ClassKind.ImmutableInstance));
                    var __tmp29Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp29.ToStringAndFree());
                    bool __tmp29_last = __tmp29Reader.EndOfStream;
                    while(!__tmp29_last)
                    {
                        ReadOnlySpan<char> __tmp29_line = __tmp29Reader.ReadLine();
                        __tmp29_last = __tmp29Reader.EndOfStream;
                        if (!__tmp29_last || !__tmp29_line.IsEmpty)
                        {
                            __out.Write(__tmp29_line);
                            __tmp25_outputWritten = true;
                        }
                        if (!__tmp29_last) __out.AppendLine(true);
                    }
                    string __tmp30_line = ";"; //161:127
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Write(__tmp30_line);
                        __tmp25_outputWritten = true;
                    }
                    if (__tmp25_outputWritten) __out.AppendLine(true);
                    if (__tmp25_outputWritten)
                    {
                        __out.AppendLine(false); //161:128
                    }
                }
                else //162:4
                {
                    bool __tmp32_outputWritten = false;
                    string __tmp33_line = "	public static readonly "; //163:1
                    if (!string.IsNullOrEmpty(__tmp33_line))
                    {
                        __out.Write(__tmp33_line);
                        __tmp32_outputWritten = true;
                    }
                    var __tmp34 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp34.Write(CSharpName(cst.Type, model, ClassKind.Immutable, true));
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
                    string __tmp35_line = " "; //163:80
                    if (!string.IsNullOrEmpty(__tmp35_line))
                    {
                        __out.Write(__tmp35_line);
                        __tmp32_outputWritten = true;
                    }
                    var __tmp36 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp36.Write(CSharpName(cst, model, ClassKind.ImmutableInstance));
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
                    string __tmp37_line = ";"; //163:133
                    if (!string.IsNullOrEmpty(__tmp37_line))
                    {
                        __out.Write(__tmp37_line);
                        __tmp32_outputWritten = true;
                    }
                    if (__tmp32_outputWritten) __out.AppendLine(true);
                    if (__tmp32_outputWritten)
                    {
                        __out.AppendLine(false); //163:134
                    }
                }
            }
            __out.AppendLine(true); //166:1
            var __loop9_results = 
                (from __loop9_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //167:8
                from cls in __Enumerate((__loop9_var1).GetEnumerator()).OfType<MetaClass>() //167:38
                select new { __loop9_var1 = __loop9_var1, cls = cls}
                ).ToList(); //167:3
            for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
            {
                var __tmp38 = __loop9_results[__loop9_iteration];
                var __loop9_var1 = __tmp38.__loop9_var1;
                var cls = __tmp38.cls;
                bool __tmp40_outputWritten = false;
                string __tmp39Prefix = "	"; //168:1
                var __tmp41 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp41.Write(GenerateDocumentation(cls));
                var __tmp41Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp41.ToStringAndFree());
                bool __tmp41_last = __tmp41Reader.EndOfStream;
                while(!__tmp41_last)
                {
                    ReadOnlySpan<char> __tmp41_line = __tmp41Reader.ReadLine();
                    __tmp41_last = __tmp41Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp39Prefix))
                    {
                        __out.Write(__tmp39Prefix);
                        __tmp40_outputWritten = true;
                    }
                    if (!__tmp41_last || !__tmp41_line.IsEmpty)
                    {
                        __out.Write(__tmp41_line);
                        __tmp40_outputWritten = true;
                    }
                    if (!__tmp41_last || __tmp40_outputWritten) __out.AppendLine(true);
                }
                if (__tmp40_outputWritten)
                {
                    __out.AppendLine(false); //168:30
                }
                bool __tmp43_outputWritten = false;
                string __tmp44_line = "	public static readonly "; //169:1
                if (!string.IsNullOrEmpty(__tmp44_line))
                {
                    __out.Write(__tmp44_line);
                    __tmp43_outputWritten = true;
                }
                var __tmp45 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp45.Write(metaNs);
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
                string __tmp46_line = "MetaClass "; //169:33
                if (!string.IsNullOrEmpty(__tmp46_line))
                {
                    __out.Write(__tmp46_line);
                    __tmp43_outputWritten = true;
                }
                var __tmp47 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp47.Write(CSharpName(cls, model, ClassKind.ImmutableInstance));
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
                string __tmp48_line = ";"; //169:95
                if (!string.IsNullOrEmpty(__tmp48_line))
                {
                    __out.Write(__tmp48_line);
                    __tmp43_outputWritten = true;
                }
                if (__tmp43_outputWritten) __out.AppendLine(true);
                if (__tmp43_outputWritten)
                {
                    __out.AppendLine(false); //169:96
                }
                var __loop10_results = 
                    (from __loop10_var1 in __Enumerate((cls).GetEnumerator()) //170:9
                    from prop in __Enumerate((__loop10_var1.Properties).GetEnumerator()) //170:14
                    select new { __loop10_var1 = __loop10_var1, prop = prop}
                    ).ToList(); //170:4
                for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
                {
                    var __tmp49 = __loop10_results[__loop10_iteration];
                    var __loop10_var1 = __tmp49.__loop10_var1;
                    var prop = __tmp49.prop;
                    bool __tmp51_outputWritten = false;
                    string __tmp50Prefix = "	"; //171:1
                    var __tmp52 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp52.Write(GenerateDocumentation(prop));
                    var __tmp52Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp52.ToStringAndFree());
                    bool __tmp52_last = __tmp52Reader.EndOfStream;
                    while(!__tmp52_last)
                    {
                        ReadOnlySpan<char> __tmp52_line = __tmp52Reader.ReadLine();
                        __tmp52_last = __tmp52Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp50Prefix))
                        {
                            __out.Write(__tmp50Prefix);
                            __tmp51_outputWritten = true;
                        }
                        if (!__tmp52_last || !__tmp52_line.IsEmpty)
                        {
                            __out.Write(__tmp52_line);
                            __tmp51_outputWritten = true;
                        }
                        if (!__tmp52_last || __tmp51_outputWritten) __out.AppendLine(true);
                    }
                    if (__tmp51_outputWritten)
                    {
                        __out.AppendLine(false); //171:31
                    }
                    bool __tmp54_outputWritten = false;
                    string __tmp55_line = "	public static readonly "; //172:1
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Write(__tmp55_line);
                        __tmp54_outputWritten = true;
                    }
                    var __tmp56 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp56.Write(metaNs);
                    var __tmp56Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp56.ToStringAndFree());
                    bool __tmp56_last = __tmp56Reader.EndOfStream;
                    while(!__tmp56_last)
                    {
                        ReadOnlySpan<char> __tmp56_line = __tmp56Reader.ReadLine();
                        __tmp56_last = __tmp56Reader.EndOfStream;
                        if (!__tmp56_last || !__tmp56_line.IsEmpty)
                        {
                            __out.Write(__tmp56_line);
                            __tmp54_outputWritten = true;
                        }
                        if (!__tmp56_last) __out.AppendLine(true);
                    }
                    string __tmp57_line = "MetaProperty "; //172:33
                    if (!string.IsNullOrEmpty(__tmp57_line))
                    {
                        __out.Write(__tmp57_line);
                        __tmp54_outputWritten = true;
                    }
                    var __tmp58 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp58.Write(CSharpName(prop, model, PropertyKind.ImmutableInstance));
                    var __tmp58Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp58.ToStringAndFree());
                    bool __tmp58_last = __tmp58Reader.EndOfStream;
                    while(!__tmp58_last)
                    {
                        ReadOnlySpan<char> __tmp58_line = __tmp58Reader.ReadLine();
                        __tmp58_last = __tmp58Reader.EndOfStream;
                        if (!__tmp58_last || !__tmp58_line.IsEmpty)
                        {
                            __out.Write(__tmp58_line);
                            __tmp54_outputWritten = true;
                        }
                        if (!__tmp58_last) __out.AppendLine(true);
                    }
                    string __tmp59_line = ";"; //172:102
                    if (!string.IsNullOrEmpty(__tmp59_line))
                    {
                        __out.Write(__tmp59_line);
                        __tmp54_outputWritten = true;
                    }
                    if (__tmp54_outputWritten) __out.AppendLine(true);
                    if (__tmp54_outputWritten)
                    {
                        __out.AppendLine(false); //172:103
                    }
                }
            }
            __out.AppendLine(true); //175:1
            bool __tmp61_outputWritten = false;
            string __tmp62_line = "	static "; //176:1
            if (!string.IsNullOrEmpty(__tmp62_line))
            {
                __out.Write(__tmp62_line);
                __tmp61_outputWritten = true;
            }
            var __tmp63 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp63.Write(CSharpName(model, ModelKind.ImmutableInstance));
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
            string __tmp64_line = "()"; //176:56
            if (!string.IsNullOrEmpty(__tmp64_line))
            {
                __out.Write(__tmp64_line);
                __tmp61_outputWritten = true;
            }
            if (__tmp61_outputWritten) __out.AppendLine(true);
            if (__tmp61_outputWritten)
            {
                __out.AppendLine(false); //176:58
            }
            __out.Write("	{"); //177:1
            __out.AppendLine(false); //177:3
            bool __tmp66_outputWritten = false;
            string __tmp65Prefix = "		"; //178:1
            var __tmp67 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp67.Write(CSharpName(model, ModelKind.BuilderInstance));
            var __tmp67Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp67.ToStringAndFree());
            bool __tmp67_last = __tmp67Reader.EndOfStream;
            while(!__tmp67_last)
            {
                ReadOnlySpan<char> __tmp67_line = __tmp67Reader.ReadLine();
                __tmp67_last = __tmp67Reader.EndOfStream;
                if (!string.IsNullOrEmpty(__tmp65Prefix))
                {
                    __out.Write(__tmp65Prefix);
                    __tmp66_outputWritten = true;
                }
                if (!__tmp67_last || !__tmp67_line.IsEmpty)
                {
                    __out.Write(__tmp67_line);
                    __tmp66_outputWritten = true;
                }
                if (!__tmp67_last) __out.AppendLine(true);
            }
            string __tmp68_line = ".instance.Create();"; //178:48
            if (!string.IsNullOrEmpty(__tmp68_line))
            {
                __out.Write(__tmp68_line);
                __tmp66_outputWritten = true;
            }
            if (__tmp66_outputWritten) __out.AppendLine(true);
            if (__tmp66_outputWritten)
            {
                __out.AppendLine(false); //178:67
            }
            bool __tmp70_outputWritten = false;
            string __tmp69Prefix = "		"; //179:1
            var __tmp71 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp71.Write(CSharpName(model, ModelKind.BuilderInstance));
            var __tmp71Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp71.ToStringAndFree());
            bool __tmp71_last = __tmp71Reader.EndOfStream;
            while(!__tmp71_last)
            {
                ReadOnlySpan<char> __tmp71_line = __tmp71Reader.ReadLine();
                __tmp71_last = __tmp71Reader.EndOfStream;
                if (!string.IsNullOrEmpty(__tmp69Prefix))
                {
                    __out.Write(__tmp69Prefix);
                    __tmp70_outputWritten = true;
                }
                if (!__tmp71_last || !__tmp71_line.IsEmpty)
                {
                    __out.Write(__tmp71_line);
                    __tmp70_outputWritten = true;
                }
                if (!__tmp71_last) __out.AppendLine(true);
            }
            string __tmp72_line = ".instance.EvaluateLazyValues();"; //179:48
            if (!string.IsNullOrEmpty(__tmp72_line))
            {
                __out.Write(__tmp72_line);
                __tmp70_outputWritten = true;
            }
            if (__tmp70_outputWritten) __out.AppendLine(true);
            if (__tmp70_outputWritten)
            {
                __out.AppendLine(false); //179:79
            }
            bool __tmp74_outputWritten = false;
            string __tmp75_line = "		MMetadata = "; //180:1
            if (!string.IsNullOrEmpty(__tmp75_line))
            {
                __out.Write(__tmp75_line);
                __tmp74_outputWritten = true;
            }
            var __tmp76 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp76.Write(CSharpName(model, ModelKind.BuilderInstance));
            var __tmp76Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp76.ToStringAndFree());
            bool __tmp76_last = __tmp76Reader.EndOfStream;
            while(!__tmp76_last)
            {
                ReadOnlySpan<char> __tmp76_line = __tmp76Reader.ReadLine();
                __tmp76_last = __tmp76Reader.EndOfStream;
                if (!__tmp76_last || !__tmp76_line.IsEmpty)
                {
                    __out.Write(__tmp76_line);
                    __tmp74_outputWritten = true;
                }
                if (!__tmp76_last) __out.AppendLine(true);
            }
            string __tmp77_line = ".instance.MMetadata;"; //180:60
            if (!string.IsNullOrEmpty(__tmp77_line))
            {
                __out.Write(__tmp77_line);
                __tmp74_outputWritten = true;
            }
            if (__tmp74_outputWritten) __out.AppendLine(true);
            if (__tmp74_outputWritten)
            {
                __out.AppendLine(false); //180:80
            }
            bool __tmp79_outputWritten = false;
            string __tmp80_line = "		MModel = "; //181:1
            if (!string.IsNullOrEmpty(__tmp80_line))
            {
                __out.Write(__tmp80_line);
                __tmp79_outputWritten = true;
            }
            var __tmp81 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp81.Write(CSharpName(model, ModelKind.BuilderInstance));
            var __tmp81Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp81.ToStringAndFree());
            bool __tmp81_last = __tmp81Reader.EndOfStream;
            while(!__tmp81_last)
            {
                ReadOnlySpan<char> __tmp81_line = __tmp81Reader.ReadLine();
                __tmp81_last = __tmp81Reader.EndOfStream;
                if (!__tmp81_last || !__tmp81_line.IsEmpty)
                {
                    __out.Write(__tmp81_line);
                    __tmp79_outputWritten = true;
                }
                if (!__tmp81_last) __out.AppendLine(true);
            }
            string __tmp82_line = ".instance.MModel.ToImmutable();"; //181:57
            if (!string.IsNullOrEmpty(__tmp82_line))
            {
                __out.Write(__tmp82_line);
                __tmp79_outputWritten = true;
            }
            if (__tmp79_outputWritten) __out.AppendLine(true);
            if (__tmp79_outputWritten)
            {
                __out.AppendLine(false); //181:88
            }
            __out.AppendLine(true); //182:1
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //183:9
                from cst in __Enumerate((__loop11_var1).GetEnumerator()).OfType<MetaConstant>() //183:39
                select new { __loop11_var1 = __loop11_var1, cst = cst}
                ).ToList(); //183:4
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp83 = __loop11_results[__loop11_iteration];
                var __loop11_var1 = __tmp83.__loop11_var1;
                var cst = __tmp83.cst;
                if (metaMetaModel) //184:5
                {
                    bool __tmp85_outputWritten = false;
                    string __tmp84Prefix = "		"; //185:1
                    var __tmp86 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp86.Write(CSharpName(cst, model, ClassKind.ImmutableInstance));
                    var __tmp86Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp86.ToStringAndFree());
                    bool __tmp86_last = __tmp86Reader.EndOfStream;
                    while(!__tmp86_last)
                    {
                        ReadOnlySpan<char> __tmp86_line = __tmp86Reader.ReadLine();
                        __tmp86_last = __tmp86Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp84Prefix))
                        {
                            __out.Write(__tmp84Prefix);
                            __tmp85_outputWritten = true;
                        }
                        if (!__tmp86_last || !__tmp86_line.IsEmpty)
                        {
                            __out.Write(__tmp86_line);
                            __tmp85_outputWritten = true;
                        }
                        if (!__tmp86_last) __out.AppendLine(true);
                    }
                    string __tmp87_line = " = "; //185:55
                    if (!string.IsNullOrEmpty(__tmp87_line))
                    {
                        __out.Write(__tmp87_line);
                        __tmp85_outputWritten = true;
                    }
                    var __tmp88 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp88.Write(CSharpName(cst, model, ClassKind.BuilderInstance, true));
                    var __tmp88Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp88.ToStringAndFree());
                    bool __tmp88_last = __tmp88Reader.EndOfStream;
                    while(!__tmp88_last)
                    {
                        ReadOnlySpan<char> __tmp88_line = __tmp88Reader.ReadLine();
                        __tmp88_last = __tmp88Reader.EndOfStream;
                        if (!__tmp88_last || !__tmp88_line.IsEmpty)
                        {
                            __out.Write(__tmp88_line);
                            __tmp85_outputWritten = true;
                        }
                        if (!__tmp88_last) __out.AppendLine(true);
                    }
                    string __tmp89_line = ".ToImmutable(MModel);"; //185:114
                    if (!string.IsNullOrEmpty(__tmp89_line))
                    {
                        __out.Write(__tmp89_line);
                        __tmp85_outputWritten = true;
                    }
                    if (__tmp85_outputWritten) __out.AppendLine(true);
                    if (__tmp85_outputWritten)
                    {
                        __out.AppendLine(false); //185:135
                    }
                }
                else //186:5
                {
                    bool __tmp91_outputWritten = false;
                    string __tmp90Prefix = "		"; //187:1
                    var __tmp92 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp92.Write(CSharpName(cst, model, ClassKind.ImmutableInstance));
                    var __tmp92Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp92.ToStringAndFree());
                    bool __tmp92_last = __tmp92Reader.EndOfStream;
                    while(!__tmp92_last)
                    {
                        ReadOnlySpan<char> __tmp92_line = __tmp92Reader.ReadLine();
                        __tmp92_last = __tmp92Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp90Prefix))
                        {
                            __out.Write(__tmp90Prefix);
                            __tmp91_outputWritten = true;
                        }
                        if (!__tmp92_last || !__tmp92_line.IsEmpty)
                        {
                            __out.Write(__tmp92_line);
                            __tmp91_outputWritten = true;
                        }
                        if (!__tmp92_last) __out.AppendLine(true);
                    }
                    string __tmp93_line = " = "; //187:55
                    if (!string.IsNullOrEmpty(__tmp93_line))
                    {
                        __out.Write(__tmp93_line);
                        __tmp91_outputWritten = true;
                    }
                    var __tmp94 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp94.Write(CSharpName(cst, model, ClassKind.BuilderInstance, true));
                    var __tmp94Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp94.ToStringAndFree());
                    bool __tmp94_last = __tmp94Reader.EndOfStream;
                    while(!__tmp94_last)
                    {
                        ReadOnlySpan<char> __tmp94_line = __tmp94Reader.ReadLine();
                        __tmp94_last = __tmp94Reader.EndOfStream;
                        if (!__tmp94_last || !__tmp94_line.IsEmpty)
                        {
                            __out.Write(__tmp94_line);
                            __tmp91_outputWritten = true;
                        }
                        if (!__tmp94_last) __out.AppendLine(true);
                    }
                    string __tmp95_line = ".ToImmutable(MModel);"; //187:114
                    if (!string.IsNullOrEmpty(__tmp95_line))
                    {
                        __out.Write(__tmp95_line);
                        __tmp91_outputWritten = true;
                    }
                    if (__tmp91_outputWritten) __out.AppendLine(true);
                    if (__tmp91_outputWritten)
                    {
                        __out.AppendLine(false); //187:135
                    }
                }
            }
            __out.AppendLine(true); //190:1
            var __loop12_results = 
                (from __loop12_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //191:9
                from cls in __Enumerate((__loop12_var1).GetEnumerator()).OfType<MetaClass>() //191:39
                select new { __loop12_var1 = __loop12_var1, cls = cls}
                ).ToList(); //191:4
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp96 = __loop12_results[__loop12_iteration];
                var __loop12_var1 = __tmp96.__loop12_var1;
                var cls = __tmp96.cls;
                bool __tmp98_outputWritten = false;
                string __tmp97Prefix = "		"; //192:1
                var __tmp99 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp99.Write(CSharpName(cls, model, ClassKind.ImmutableInstance));
                var __tmp99Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp99.ToStringAndFree());
                bool __tmp99_last = __tmp99Reader.EndOfStream;
                while(!__tmp99_last)
                {
                    ReadOnlySpan<char> __tmp99_line = __tmp99Reader.ReadLine();
                    __tmp99_last = __tmp99Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp97Prefix))
                    {
                        __out.Write(__tmp97Prefix);
                        __tmp98_outputWritten = true;
                    }
                    if (!__tmp99_last || !__tmp99_line.IsEmpty)
                    {
                        __out.Write(__tmp99_line);
                        __tmp98_outputWritten = true;
                    }
                    if (!__tmp99_last) __out.AppendLine(true);
                }
                string __tmp100_line = " = "; //192:55
                if (!string.IsNullOrEmpty(__tmp100_line))
                {
                    __out.Write(__tmp100_line);
                    __tmp98_outputWritten = true;
                }
                var __tmp101 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp101.Write(CSharpName(cls, model, ClassKind.BuilderInstance, true));
                var __tmp101Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp101.ToStringAndFree());
                bool __tmp101_last = __tmp101Reader.EndOfStream;
                while(!__tmp101_last)
                {
                    ReadOnlySpan<char> __tmp101_line = __tmp101Reader.ReadLine();
                    __tmp101_last = __tmp101Reader.EndOfStream;
                    if (!__tmp101_last || !__tmp101_line.IsEmpty)
                    {
                        __out.Write(__tmp101_line);
                        __tmp98_outputWritten = true;
                    }
                    if (!__tmp101_last) __out.AppendLine(true);
                }
                string __tmp102_line = ".ToImmutable(MModel);"; //192:114
                if (!string.IsNullOrEmpty(__tmp102_line))
                {
                    __out.Write(__tmp102_line);
                    __tmp98_outputWritten = true;
                }
                if (__tmp98_outputWritten) __out.AppendLine(true);
                if (__tmp98_outputWritten)
                {
                    __out.AppendLine(false); //192:135
                }
                var __loop13_results = 
                    (from __loop13_var1 in __Enumerate((cls).GetEnumerator()) //193:10
                    from prop in __Enumerate((__loop13_var1.Properties).GetEnumerator()) //193:15
                    select new { __loop13_var1 = __loop13_var1, prop = prop}
                    ).ToList(); //193:5
                for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
                {
                    var __tmp103 = __loop13_results[__loop13_iteration];
                    var __loop13_var1 = __tmp103.__loop13_var1;
                    var prop = __tmp103.prop;
                    bool __tmp105_outputWritten = false;
                    string __tmp104Prefix = "		"; //194:1
                    var __tmp106 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp106.Write(CSharpName(prop, model, PropertyKind.ImmutableInstance));
                    var __tmp106Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp106.ToStringAndFree());
                    bool __tmp106_last = __tmp106Reader.EndOfStream;
                    while(!__tmp106_last)
                    {
                        ReadOnlySpan<char> __tmp106_line = __tmp106Reader.ReadLine();
                        __tmp106_last = __tmp106Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp104Prefix))
                        {
                            __out.Write(__tmp104Prefix);
                            __tmp105_outputWritten = true;
                        }
                        if (!__tmp106_last || !__tmp106_line.IsEmpty)
                        {
                            __out.Write(__tmp106_line);
                            __tmp105_outputWritten = true;
                        }
                        if (!__tmp106_last) __out.AppendLine(true);
                    }
                    string __tmp107_line = " = "; //194:59
                    if (!string.IsNullOrEmpty(__tmp107_line))
                    {
                        __out.Write(__tmp107_line);
                        __tmp105_outputWritten = true;
                    }
                    var __tmp108 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp108.Write(CSharpName(prop, model, PropertyKind.BuilderInstance, true));
                    var __tmp108Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp108.ToStringAndFree());
                    bool __tmp108_last = __tmp108Reader.EndOfStream;
                    while(!__tmp108_last)
                    {
                        ReadOnlySpan<char> __tmp108_line = __tmp108Reader.ReadLine();
                        __tmp108_last = __tmp108Reader.EndOfStream;
                        if (!__tmp108_last || !__tmp108_line.IsEmpty)
                        {
                            __out.Write(__tmp108_line);
                            __tmp105_outputWritten = true;
                        }
                        if (!__tmp108_last) __out.AppendLine(true);
                    }
                    string __tmp109_line = ".ToImmutable(MModel);"; //194:122
                    if (!string.IsNullOrEmpty(__tmp109_line))
                    {
                        __out.Write(__tmp109_line);
                        __tmp105_outputWritten = true;
                    }
                    if (__tmp105_outputWritten) __out.AppendLine(true);
                    if (__tmp105_outputWritten)
                    {
                        __out.AppendLine(false); //194:143
                    }
                }
            }
            __out.AppendLine(true); //197:1
            bool __tmp111_outputWritten = false;
            string __tmp110Prefix = "		"; //198:1
            var __tmp112 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp112.Write(CSharpName(model, ModelKind.ImmutableInstance));
            var __tmp112Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp112.ToStringAndFree());
            bool __tmp112_last = __tmp112Reader.EndOfStream;
            while(!__tmp112_last)
            {
                ReadOnlySpan<char> __tmp112_line = __tmp112Reader.ReadLine();
                __tmp112_last = __tmp112Reader.EndOfStream;
                if (!string.IsNullOrEmpty(__tmp110Prefix))
                {
                    __out.Write(__tmp110Prefix);
                    __tmp111_outputWritten = true;
                }
                if (!__tmp112_last || !__tmp112_line.IsEmpty)
                {
                    __out.Write(__tmp112_line);
                    __tmp111_outputWritten = true;
                }
                if (!__tmp112_last) __out.AppendLine(true);
            }
            string __tmp113_line = ".initialized = true;"; //198:50
            if (!string.IsNullOrEmpty(__tmp113_line))
            {
                __out.Write(__tmp113_line);
                __tmp111_outputWritten = true;
            }
            if (__tmp111_outputWritten) __out.AppendLine(true);
            if (__tmp111_outputWritten)
            {
                __out.AppendLine(false); //198:70
            }
            __out.Write("	}"); //199:1
            __out.AppendLine(false); //199:3
            __out.Write("}"); //200:1
            __out.AppendLine(false); //200:2
            return __out.ToStringAndFree();
        }

        public string GenerateMetaModelBuilderInstance(MetaModel model) //203:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //204:2
            bool metaMetaModel = IsMetaMetaModel(model); //205:2
            ImmutableList<ImmutableObject> instances = GetInstances(model); //206:2
            ImmutableDictionary<ImmutableObject,string> instanceNames = GetInstanceNames(model); //207:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //208:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Write(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp4.Write(CSharpName(model, ModelKind.BuilderInstance));
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
                __out.AppendLine(false); //208:61
            }
            __out.Write("{"); //209:1
            __out.AppendLine(false); //209:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	internal static "; //210:1
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp6_outputWritten = true;
            }
            var __tmp8 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp8.Write(CSharpName(model, ModelKind.BuilderInstance));
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
            string __tmp9_line = " instance = new "; //210:63
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Write(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            var __tmp10 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp10.Write(CSharpName(model, ModelKind.BuilderInstance));
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
            string __tmp11_line = "();"; //210:124
            if (!string.IsNullOrEmpty(__tmp11_line))
            {
                __out.Write(__tmp11_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //210:127
            }
            __out.AppendLine(true); //211:1
            __out.Write("	private bool creating;"); //212:1
            __out.AppendLine(false); //212:24
            __out.Write("	private bool created;"); //213:1
            __out.AppendLine(false); //213:23
            bool __tmp13_outputWritten = false;
            string __tmp14_line = "	internal "; //214:1
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp13_outputWritten = true;
            }
            var __tmp15 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp15.Write(CSharpName(model, ModelKind.Metadata, true));
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
            string __tmp16_line = " MMetadata;"; //214:55
            if (!string.IsNullOrEmpty(__tmp16_line))
            {
                __out.Write(__tmp16_line);
                __tmp13_outputWritten = true;
            }
            if (__tmp13_outputWritten) __out.AppendLine(true);
            if (__tmp13_outputWritten)
            {
                __out.AppendLine(false); //214:66
            }
            bool __tmp18_outputWritten = false;
            string __tmp19_line = "	internal "; //215:1
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Write(__tmp19_line);
                __tmp18_outputWritten = true;
            }
            var __tmp20 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp20.Write(Properties.CoreNs);
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
            string __tmp21_line = ".MutableModel MModel;"; //215:30
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp18_outputWritten = true;
            }
            if (__tmp18_outputWritten) __out.AppendLine(true);
            if (__tmp18_outputWritten)
            {
                __out.AppendLine(false); //215:51
            }
            if (!metaMetaModel && model.MModel.ModelGroup != null) //216:3
            {
                bool __tmp23_outputWritten = false;
                string __tmp24_line = "	internal "; //217:1
                if (!string.IsNullOrEmpty(__tmp24_line))
                {
                    __out.Write(__tmp24_line);
                    __tmp23_outputWritten = true;
                }
                var __tmp25 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp25.Write(Properties.CoreNs);
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
                string __tmp26_line = ".MutableModelGroup MModelGroup;"; //217:30
                if (!string.IsNullOrEmpty(__tmp26_line))
                {
                    __out.Write(__tmp26_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //217:61
                }
            }
            __out.AppendLine(true); //219:1
            var __loop14_results = 
                (from __loop14_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //220:8
                from cst in __Enumerate((__loop14_var1).GetEnumerator()).OfType<MetaConstant>() //220:38
                select new { __loop14_var1 = __loop14_var1, cst = cst}
                ).ToList(); //220:3
            for (int __loop14_iteration = 0; __loop14_iteration < __loop14_results.Count; ++__loop14_iteration)
            {
                var __tmp27 = __loop14_results[__loop14_iteration];
                var __loop14_var1 = __tmp27.__loop14_var1;
                var cst = __tmp27.cst;
                bool __tmp29_outputWritten = false;
                string __tmp28Prefix = "	"; //221:1
                var __tmp30 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp30.Write(GenerateDocumentation(cst));
                var __tmp30Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp30.ToStringAndFree());
                bool __tmp30_last = __tmp30Reader.EndOfStream;
                while(!__tmp30_last)
                {
                    ReadOnlySpan<char> __tmp30_line = __tmp30Reader.ReadLine();
                    __tmp30_last = __tmp30Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp28Prefix))
                    {
                        __out.Write(__tmp28Prefix);
                        __tmp29_outputWritten = true;
                    }
                    if (!__tmp30_last || !__tmp30_line.IsEmpty)
                    {
                        __out.Write(__tmp30_line);
                        __tmp29_outputWritten = true;
                    }
                    if (!__tmp30_last || __tmp29_outputWritten) __out.AppendLine(true);
                }
                if (__tmp29_outputWritten)
                {
                    __out.AppendLine(false); //221:30
                }
                if (metaMetaModel) //222:4
                {
                    bool __tmp32_outputWritten = false;
                    string __tmp33_line = "	internal "; //223:1
                    if (!string.IsNullOrEmpty(__tmp33_line))
                    {
                        __out.Write(__tmp33_line);
                        __tmp32_outputWritten = true;
                    }
                    var __tmp34 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp34.Write(CSharpName(cst.Type, model, ClassKind.Builder));
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
                    string __tmp35_line = " "; //223:58
                    if (!string.IsNullOrEmpty(__tmp35_line))
                    {
                        __out.Write(__tmp35_line);
                        __tmp32_outputWritten = true;
                    }
                    var __tmp36 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp36.Write(CSharpName(cst, model, ClassKind.BuilderInstance));
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
                    string __tmp37_line = " = null;"; //223:109
                    if (!string.IsNullOrEmpty(__tmp37_line))
                    {
                        __out.Write(__tmp37_line);
                        __tmp32_outputWritten = true;
                    }
                    if (__tmp32_outputWritten) __out.AppendLine(true);
                    if (__tmp32_outputWritten)
                    {
                        __out.AppendLine(false); //223:117
                    }
                }
                else //224:4
                {
                    bool __tmp39_outputWritten = false;
                    string __tmp40_line = "	internal "; //225:1
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Write(__tmp40_line);
                        __tmp39_outputWritten = true;
                    }
                    var __tmp41 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp41.Write(CSharpName(cst.Type, model, ClassKind.Builder, true));
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
                    string __tmp42_line = " "; //225:64
                    if (!string.IsNullOrEmpty(__tmp42_line))
                    {
                        __out.Write(__tmp42_line);
                        __tmp39_outputWritten = true;
                    }
                    var __tmp43 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp43.Write(CSharpName(cst, model, ClassKind.BuilderInstance));
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
                    string __tmp44_line = " = null;"; //225:115
                    if (!string.IsNullOrEmpty(__tmp44_line))
                    {
                        __out.Write(__tmp44_line);
                        __tmp39_outputWritten = true;
                    }
                    if (__tmp39_outputWritten) __out.AppendLine(true);
                    if (__tmp39_outputWritten)
                    {
                        __out.AppendLine(false); //225:123
                    }
                }
            }
            __out.AppendLine(true); //228:1
            var __loop15_results = 
                (from obj in __Enumerate((instances).GetEnumerator()) //229:8
                select new { obj = obj}
                ).ToList(); //229:3
            for (int __loop15_iteration = 0; __loop15_iteration < __loop15_results.Count; ++__loop15_iteration)
            {
                var __tmp45 = __loop15_results[__loop15_iteration];
                var obj = __tmp45.obj;
                bool __tmp47_outputWritten = false;
                string __tmp46Prefix = "	"; //230:1
                var __tmp48 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp48.Write(GenerateInstanceDeclaration(model, metaMetaModel, obj, instanceNames));
                var __tmp48Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp48.ToStringAndFree());
                bool __tmp48_last = __tmp48Reader.EndOfStream;
                while(!__tmp48_last)
                {
                    ReadOnlySpan<char> __tmp48_line = __tmp48Reader.ReadLine();
                    __tmp48_last = __tmp48Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp46Prefix))
                    {
                        __out.Write(__tmp46Prefix);
                        __tmp47_outputWritten = true;
                    }
                    if (!__tmp48_last || !__tmp48_line.IsEmpty)
                    {
                        __out.Write(__tmp48_line);
                        __tmp47_outputWritten = true;
                    }
                    if (!__tmp48_last || __tmp47_outputWritten) __out.AppendLine(true);
                }
                if (__tmp47_outputWritten)
                {
                    __out.AppendLine(false); //230:73
                }
            }
            __out.AppendLine(true); //232:1
            bool __tmp50_outputWritten = false;
            string __tmp51_line = "	internal "; //233:1
            if (!string.IsNullOrEmpty(__tmp51_line))
            {
                __out.Write(__tmp51_line);
                __tmp50_outputWritten = true;
            }
            var __tmp52 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp52.Write(CSharpName(model, ModelKind.BuilderInstance));
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
            string __tmp53_line = "()"; //233:56
            if (!string.IsNullOrEmpty(__tmp53_line))
            {
                __out.Write(__tmp53_line);
                __tmp50_outputWritten = true;
            }
            if (__tmp50_outputWritten) __out.AppendLine(true);
            if (__tmp50_outputWritten)
            {
                __out.AppendLine(false); //233:58
            }
            __out.Write("	{"); //234:1
            __out.AppendLine(false); //234:3
            bool __tmp55_outputWritten = false;
            string __tmp56_line = "		this.MMetadata = new "; //235:1
            if (!string.IsNullOrEmpty(__tmp56_line))
            {
                __out.Write(__tmp56_line);
                __tmp55_outputWritten = true;
            }
            var __tmp57 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp57.Write(CSharpName(model, ModelKind.Metadata));
            var __tmp57Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp57.ToStringAndFree());
            bool __tmp57_last = __tmp57Reader.EndOfStream;
            while(!__tmp57_last)
            {
                ReadOnlySpan<char> __tmp57_line = __tmp57Reader.ReadLine();
                __tmp57_last = __tmp57Reader.EndOfStream;
                if (!__tmp57_last || !__tmp57_line.IsEmpty)
                {
                    __out.Write(__tmp57_line);
                    __tmp55_outputWritten = true;
                }
                if (!__tmp57_last) __out.AppendLine(true);
            }
            string __tmp58_line = "(name: \""; //235:62
            if (!string.IsNullOrEmpty(__tmp58_line))
            {
                __out.Write(__tmp58_line);
                __tmp55_outputWritten = true;
            }
            var __tmp59 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp59.Write(CSharpName(model));
            var __tmp59Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp59.ToStringAndFree());
            bool __tmp59_last = __tmp59Reader.EndOfStream;
            while(!__tmp59_last)
            {
                ReadOnlySpan<char> __tmp59_line = __tmp59Reader.ReadLine();
                __tmp59_last = __tmp59Reader.EndOfStream;
                if (!__tmp59_last || !__tmp59_line.IsEmpty)
                {
                    __out.Write(__tmp59_line);
                    __tmp55_outputWritten = true;
                }
                if (!__tmp59_last) __out.AppendLine(true);
            }
            string __tmp60_line = "\", version: new "; //235:90
            if (!string.IsNullOrEmpty(__tmp60_line))
            {
                __out.Write(__tmp60_line);
                __tmp55_outputWritten = true;
            }
            var __tmp61 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp61.Write(Properties.CoreNs);
            var __tmp61Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp61.ToStringAndFree());
            bool __tmp61_last = __tmp61Reader.EndOfStream;
            while(!__tmp61_last)
            {
                ReadOnlySpan<char> __tmp61_line = __tmp61Reader.ReadLine();
                __tmp61_last = __tmp61Reader.EndOfStream;
                if (!__tmp61_last || !__tmp61_line.IsEmpty)
                {
                    __out.Write(__tmp61_line);
                    __tmp55_outputWritten = true;
                }
                if (!__tmp61_last) __out.AppendLine(true);
            }
            string __tmp62_line = ".ModelVersion(0, 0), uri: \""; //235:125
            if (!string.IsNullOrEmpty(__tmp62_line))
            {
                __out.Write(__tmp62_line);
                __tmp55_outputWritten = true;
            }
            var __tmp63 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp63.Write(model.Uri);
            var __tmp63Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp63.ToStringAndFree());
            bool __tmp63_last = __tmp63Reader.EndOfStream;
            while(!__tmp63_last)
            {
                ReadOnlySpan<char> __tmp63_line = __tmp63Reader.ReadLine();
                __tmp63_last = __tmp63Reader.EndOfStream;
                if (!__tmp63_last || !__tmp63_line.IsEmpty)
                {
                    __out.Write(__tmp63_line);
                    __tmp55_outputWritten = true;
                }
                if (!__tmp63_last) __out.AppendLine(true);
            }
            string __tmp64_line = "\", prefix: \""; //235:163
            if (!string.IsNullOrEmpty(__tmp64_line))
            {
                __out.Write(__tmp64_line);
                __tmp55_outputWritten = true;
            }
            var __tmp65 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp65.Write(model.Prefix);
            var __tmp65Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp65.ToStringAndFree());
            bool __tmp65_last = __tmp65Reader.EndOfStream;
            while(!__tmp65_last)
            {
                ReadOnlySpan<char> __tmp65_line = __tmp65Reader.ReadLine();
                __tmp65_last = __tmp65Reader.EndOfStream;
                if (!__tmp65_last || !__tmp65_line.IsEmpty)
                {
                    __out.Write(__tmp65_line);
                    __tmp55_outputWritten = true;
                }
                if (!__tmp65_last) __out.AppendLine(true);
            }
            string __tmp66_line = "\", namespaceName: \""; //235:189
            if (!string.IsNullOrEmpty(__tmp66_line))
            {
                __out.Write(__tmp66_line);
                __tmp55_outputWritten = true;
            }
            var __tmp67 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp67.Write(CSharpName(model.Namespace, NamespaceKind.Public, true));
            var __tmp67Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp67.ToStringAndFree());
            bool __tmp67_last = __tmp67Reader.EndOfStream;
            while(!__tmp67_last)
            {
                ReadOnlySpan<char> __tmp67_line = __tmp67Reader.ReadLine();
                __tmp67_last = __tmp67Reader.EndOfStream;
                if (!__tmp67_last || !__tmp67_line.IsEmpty)
                {
                    __out.Write(__tmp67_line);
                    __tmp55_outputWritten = true;
                }
                if (!__tmp67_last) __out.AppendLine(true);
            }
            string __tmp68_line = "\");"; //235:264
            if (!string.IsNullOrEmpty(__tmp68_line))
            {
                __out.Write(__tmp68_line);
                __tmp55_outputWritten = true;
            }
            if (__tmp55_outputWritten) __out.AppendLine(true);
            if (__tmp55_outputWritten)
            {
                __out.AppendLine(false); //235:267
            }
            if (metaMetaModel) //236:4
            {
                bool __tmp70_outputWritten = false;
                string __tmp71_line = "		this.MModel = new "; //237:1
                if (!string.IsNullOrEmpty(__tmp71_line))
                {
                    __out.Write(__tmp71_line);
                    __tmp70_outputWritten = true;
                }
                var __tmp72 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp72.Write(Properties.CoreNs);
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
                string __tmp73_line = ".MutableModel(this.MMetadata);"; //237:40
                if (!string.IsNullOrEmpty(__tmp73_line))
                {
                    __out.Write(__tmp73_line);
                    __tmp70_outputWritten = true;
                }
                if (__tmp70_outputWritten) __out.AppendLine(true);
                if (__tmp70_outputWritten)
                {
                    __out.AppendLine(false); //237:70
                }
            }
            else if (model.MModel.ModelGroup != null) //238:4
            {
                bool __tmp75_outputWritten = false;
                string __tmp76_line = "		this.MModelGroup = new "; //239:1
                if (!string.IsNullOrEmpty(__tmp76_line))
                {
                    __out.Write(__tmp76_line);
                    __tmp75_outputWritten = true;
                }
                var __tmp77 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp77.Write(Properties.CoreNs);
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
                string __tmp78_line = ".MutableModelGroup();"; //239:45
                if (!string.IsNullOrEmpty(__tmp78_line))
                {
                    __out.Write(__tmp78_line);
                    __tmp75_outputWritten = true;
                }
                if (__tmp75_outputWritten) __out.AppendLine(true);
                if (__tmp75_outputWritten)
                {
                    __out.AppendLine(false); //239:66
                }
                var __loop16_results = 
                    (from refModel in __Enumerate((model.MModel.ModelGroup.References).GetEnumerator()) //240:11
                    select new { refModel = refModel}
                    ).ToList(); //240:5
                for (int __loop16_iteration = 0; __loop16_iteration < __loop16_results.Count; ++__loop16_iteration)
                {
                    var __tmp79 = __loop16_results[__loop16_iteration];
                    var refModel = __tmp79.refModel;
                    bool __tmp81_outputWritten = false;
                    string __tmp82_line = "		this.MModelGroup.AddReference("; //241:1
                    if (!string.IsNullOrEmpty(__tmp82_line))
                    {
                        __out.Write(__tmp82_line);
                        __tmp81_outputWritten = true;
                    }
                    var __tmp83 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp83.Write(refModel.Metadata.NamespaceName);
                    var __tmp83Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp83.ToStringAndFree());
                    bool __tmp83_last = __tmp83Reader.EndOfStream;
                    while(!__tmp83_last)
                    {
                        ReadOnlySpan<char> __tmp83_line = __tmp83Reader.ReadLine();
                        __tmp83_last = __tmp83Reader.EndOfStream;
                        if (!__tmp83_last || !__tmp83_line.IsEmpty)
                        {
                            __out.Write(__tmp83_line);
                            __tmp81_outputWritten = true;
                        }
                        if (!__tmp83_last) __out.AppendLine(true);
                    }
                    string __tmp84_line = "."; //241:66
                    if (!string.IsNullOrEmpty(__tmp84_line))
                    {
                        __out.Write(__tmp84_line);
                        __tmp81_outputWritten = true;
                    }
                    var __tmp85 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp85.Write(refModel.Metadata.Name);
                    var __tmp85Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp85.ToStringAndFree());
                    bool __tmp85_last = __tmp85Reader.EndOfStream;
                    while(!__tmp85_last)
                    {
                        ReadOnlySpan<char> __tmp85_line = __tmp85Reader.ReadLine();
                        __tmp85_last = __tmp85Reader.EndOfStream;
                        if (!__tmp85_last || !__tmp85_line.IsEmpty)
                        {
                            __out.Write(__tmp85_line);
                            __tmp81_outputWritten = true;
                        }
                        if (!__tmp85_last) __out.AppendLine(true);
                    }
                    string __tmp86_line = "Instance.MModel);"; //241:91
                    if (!string.IsNullOrEmpty(__tmp86_line))
                    {
                        __out.Write(__tmp86_line);
                        __tmp81_outputWritten = true;
                    }
                    if (__tmp81_outputWritten) __out.AppendLine(true);
                    if (__tmp81_outputWritten)
                    {
                        __out.AppendLine(false); //241:108
                    }
                }
                __out.Write("		this.MModel = this.MModelGroup.CreateModel(this.MMetadata);"); //243:1
                __out.AppendLine(false); //243:62
            }
            else //244:4
            {
                __out.Write("		this.MModel = this.MModelGroup.CreateModel(this.MMetadata);"); //245:1
                __out.AppendLine(false); //245:62
            }
            __out.Write("	}"); //247:1
            __out.AppendLine(false); //247:3
            __out.AppendLine(true); //248:1
            __out.Write("	internal void Create()"); //249:1
            __out.AppendLine(false); //249:24
            __out.Write("	{"); //250:1
            __out.AppendLine(false); //250:3
            __out.Write("		lock (this)"); //251:1
            __out.AppendLine(false); //251:14
            __out.Write("		{"); //252:1
            __out.AppendLine(false); //252:4
            __out.Write("			if (this.creating || this.created) return;"); //253:1
            __out.AppendLine(false); //253:46
            __out.Write("			this.creating = true;"); //254:1
            __out.AppendLine(false); //254:25
            __out.Write("		}"); //255:1
            __out.AppendLine(false); //255:4
            __out.Write("		this.CreateInstances();"); //256:1
            __out.AppendLine(false); //256:26
            bool __tmp88_outputWritten = false;
            string __tmp87Prefix = "		"; //257:1
            var __tmp89 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp89.Write(CSharpName(model, ModelKind.ImplementationProvider));
            var __tmp89Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp89.ToStringAndFree());
            bool __tmp89_last = __tmp89Reader.EndOfStream;
            while(!__tmp89_last)
            {
                ReadOnlySpan<char> __tmp89_line = __tmp89Reader.ReadLine();
                __tmp89_last = __tmp89Reader.EndOfStream;
                if (!string.IsNullOrEmpty(__tmp87Prefix))
                {
                    __out.Write(__tmp87Prefix);
                    __tmp88_outputWritten = true;
                }
                if (!__tmp89_last || !__tmp89_line.IsEmpty)
                {
                    __out.Write(__tmp89_line);
                    __tmp88_outputWritten = true;
                }
                if (!__tmp89_last) __out.AppendLine(true);
            }
            string __tmp90_line = ".Implementation."; //257:55
            if (!string.IsNullOrEmpty(__tmp90_line))
            {
                __out.Write(__tmp90_line);
                __tmp88_outputWritten = true;
            }
            var __tmp91 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp91.Write(CSharpName(model, ModelKind.BuilderInstance));
            var __tmp91Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp91.ToStringAndFree());
            bool __tmp91_last = __tmp91Reader.EndOfStream;
            while(!__tmp91_last)
            {
                ReadOnlySpan<char> __tmp91_line = __tmp91Reader.ReadLine();
                __tmp91_last = __tmp91Reader.EndOfStream;
                if (!__tmp91_last || !__tmp91_line.IsEmpty)
                {
                    __out.Write(__tmp91_line);
                    __tmp88_outputWritten = true;
                }
                if (!__tmp91_last) __out.AppendLine(true);
            }
            string __tmp92_line = "(this);"; //257:116
            if (!string.IsNullOrEmpty(__tmp92_line))
            {
                __out.Write(__tmp92_line);
                __tmp88_outputWritten = true;
            }
            if (__tmp88_outputWritten) __out.AppendLine(true);
            if (__tmp88_outputWritten)
            {
                __out.AppendLine(false); //257:123
            }
            __out.Write("        foreach (global::MetaDslx.Modeling.MutableObject obj in this.MModel.Objects)"); //258:1
            __out.AppendLine(false); //258:85
            __out.Write("        {"); //259:1
            __out.AppendLine(false); //259:10
            __out.Write("            obj.MMakeCreated();"); //260:1
            __out.AppendLine(false); //260:32
            __out.Write("        }"); //261:1
            __out.AppendLine(false); //261:10
            __out.Write("		lock (this)"); //262:1
            __out.AppendLine(false); //262:14
            __out.Write("		{"); //263:1
            __out.AppendLine(false); //263:4
            __out.Write("			this.created = true;"); //264:1
            __out.AppendLine(false); //264:24
            __out.Write("		}"); //265:1
            __out.AppendLine(false); //265:4
            __out.Write("	}"); //266:1
            __out.AppendLine(false); //266:3
            __out.AppendLine(true); //267:1
            __out.Write("	internal void EvaluateLazyValues()"); //268:1
            __out.AppendLine(false); //268:36
            __out.Write("	{"); //269:1
            __out.AppendLine(false); //269:3
            __out.Write("		if (!this.created) return;"); //270:1
            __out.AppendLine(false); //270:29
            __out.Write("		this.MModel.EvaluateLazyValues();"); //271:1
            __out.AppendLine(false); //271:36
            __out.Write("	}"); //272:1
            __out.AppendLine(false); //272:3
            __out.AppendLine(true); //273:1
            __out.Write("	private void CreateInstances()"); //274:1
            __out.AppendLine(false); //274:32
            __out.Write("	{"); //275:1
            __out.AppendLine(false); //275:3
            bool __tmp94_outputWritten = false;
            string __tmp93Prefix = "		"; //276:1
            var __tmp95 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp95.Write(Properties.MetaNs);
            var __tmp95Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp95.ToStringAndFree());
            bool __tmp95_last = __tmp95Reader.EndOfStream;
            while(!__tmp95_last)
            {
                ReadOnlySpan<char> __tmp95_line = __tmp95Reader.ReadLine();
                __tmp95_last = __tmp95Reader.EndOfStream;
                if (!string.IsNullOrEmpty(__tmp93Prefix))
                {
                    __out.Write(__tmp93Prefix);
                    __tmp94_outputWritten = true;
                }
                if (!__tmp95_last || !__tmp95_line.IsEmpty)
                {
                    __out.Write(__tmp95_line);
                    __tmp94_outputWritten = true;
                }
                if (!__tmp95_last) __out.AppendLine(true);
            }
            string __tmp96_line = ".MetaFactory factory = new "; //276:22
            if (!string.IsNullOrEmpty(__tmp96_line))
            {
                __out.Write(__tmp96_line);
                __tmp94_outputWritten = true;
            }
            var __tmp97 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp97.Write(Properties.MetaNs);
            var __tmp97Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp97.ToStringAndFree());
            bool __tmp97_last = __tmp97Reader.EndOfStream;
            while(!__tmp97_last)
            {
                ReadOnlySpan<char> __tmp97_line = __tmp97Reader.ReadLine();
                __tmp97_last = __tmp97Reader.EndOfStream;
                if (!__tmp97_last || !__tmp97_line.IsEmpty)
                {
                    __out.Write(__tmp97_line);
                    __tmp94_outputWritten = true;
                }
                if (!__tmp97_last) __out.AppendLine(true);
            }
            string __tmp98_line = ".MetaFactory(this.MModel, "; //276:68
            if (!string.IsNullOrEmpty(__tmp98_line))
            {
                __out.Write(__tmp98_line);
                __tmp94_outputWritten = true;
            }
            var __tmp99 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp99.Write(Properties.CoreNs);
            var __tmp99Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp99.ToStringAndFree());
            bool __tmp99_last = __tmp99Reader.EndOfStream;
            while(!__tmp99_last)
            {
                ReadOnlySpan<char> __tmp99_line = __tmp99Reader.ReadLine();
                __tmp99_last = __tmp99Reader.EndOfStream;
                if (!__tmp99_last || !__tmp99_line.IsEmpty)
                {
                    __out.Write(__tmp99_line);
                    __tmp94_outputWritten = true;
                }
                if (!__tmp99_last) __out.AppendLine(true);
            }
            string __tmp100_line = ".ModelFactoryFlags.DontMakeObjectsCreated);"; //276:113
            if (!string.IsNullOrEmpty(__tmp100_line))
            {
                __out.Write(__tmp100_line);
                __tmp94_outputWritten = true;
            }
            if (__tmp94_outputWritten) __out.AppendLine(true);
            if (__tmp94_outputWritten)
            {
                __out.AppendLine(false); //276:156
            }
            if (!metaMetaModel) //277:4
            {
                bool __tmp102_outputWritten = false;
                string __tmp101Prefix = "		"; //278:1
                var __tmp103 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp103.Write(CSharpName(model, ModelKind.Factory));
                var __tmp103Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp103.ToStringAndFree());
                bool __tmp103_last = __tmp103Reader.EndOfStream;
                while(!__tmp103_last)
                {
                    ReadOnlySpan<char> __tmp103_line = __tmp103Reader.ReadLine();
                    __tmp103_last = __tmp103Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp101Prefix))
                    {
                        __out.Write(__tmp101Prefix);
                        __tmp102_outputWritten = true;
                    }
                    if (!__tmp103_last || !__tmp103_line.IsEmpty)
                    {
                        __out.Write(__tmp103_line);
                        __tmp102_outputWritten = true;
                    }
                    if (!__tmp103_last) __out.AppendLine(true);
                }
                string __tmp104_line = " constantFactory = new "; //278:40
                if (!string.IsNullOrEmpty(__tmp104_line))
                {
                    __out.Write(__tmp104_line);
                    __tmp102_outputWritten = true;
                }
                var __tmp105 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp105.Write(CSharpName(model, ModelKind.Factory));
                var __tmp105Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp105.ToStringAndFree());
                bool __tmp105_last = __tmp105Reader.EndOfStream;
                while(!__tmp105_last)
                {
                    ReadOnlySpan<char> __tmp105_line = __tmp105Reader.ReadLine();
                    __tmp105_last = __tmp105Reader.EndOfStream;
                    if (!__tmp105_last || !__tmp105_line.IsEmpty)
                    {
                        __out.Write(__tmp105_line);
                        __tmp102_outputWritten = true;
                    }
                    if (!__tmp105_last) __out.AppendLine(true);
                }
                string __tmp106_line = "(this.MModel, global::MetaDslx.Modeling.ModelFactoryFlags.DontMakeObjectsCreated);"; //278:100
                if (!string.IsNullOrEmpty(__tmp106_line))
                {
                    __out.Write(__tmp106_line);
                    __tmp102_outputWritten = true;
                }
                if (__tmp102_outputWritten) __out.AppendLine(true);
                if (__tmp102_outputWritten)
                {
                    __out.AppendLine(false); //278:182
                }
            }
            __out.AppendLine(true); //280:1
            var __loop17_results = 
                (from __loop17_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //281:9
                from cst in __Enumerate((__loop17_var1).GetEnumerator()).OfType<MetaConstant>() //281:39
                select new { __loop17_var1 = __loop17_var1, cst = cst}
                ).ToList(); //281:4
            for (int __loop17_iteration = 0; __loop17_iteration < __loop17_results.Count; ++__loop17_iteration)
            {
                var __tmp107 = __loop17_results[__loop17_iteration];
                var __loop17_var1 = __tmp107.__loop17_var1;
                var cst = __tmp107.cst;
                if (metaMetaModel) //282:5
                {
                    bool __tmp109_outputWritten = false;
                    string __tmp108Prefix = "		"; //283:1
                    var __tmp110 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp110.Write(CSharpName(cst, model, ClassKind.BuilderInstance));
                    var __tmp110Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp110.ToStringAndFree());
                    bool __tmp110_last = __tmp110Reader.EndOfStream;
                    while(!__tmp110_last)
                    {
                        ReadOnlySpan<char> __tmp110_line = __tmp110Reader.ReadLine();
                        __tmp110_last = __tmp110Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp108Prefix))
                        {
                            __out.Write(__tmp108Prefix);
                            __tmp109_outputWritten = true;
                        }
                        if (!__tmp110_last || !__tmp110_line.IsEmpty)
                        {
                            __out.Write(__tmp110_line);
                            __tmp109_outputWritten = true;
                        }
                        if (!__tmp110_last) __out.AppendLine(true);
                    }
                    string __tmp111_line = " = factory."; //283:53
                    if (!string.IsNullOrEmpty(__tmp111_line))
                    {
                        __out.Write(__tmp111_line);
                        __tmp109_outputWritten = true;
                    }
                    var __tmp112 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp112.Write(CSharpName(cst.Type, model, ClassKind.Immutable));
                    var __tmp112Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp112.ToStringAndFree());
                    bool __tmp112_last = __tmp112Reader.EndOfStream;
                    while(!__tmp112_last)
                    {
                        ReadOnlySpan<char> __tmp112_line = __tmp112Reader.ReadLine();
                        __tmp112_last = __tmp112Reader.EndOfStream;
                        if (!__tmp112_last || !__tmp112_line.IsEmpty)
                        {
                            __out.Write(__tmp112_line);
                            __tmp109_outputWritten = true;
                        }
                        if (!__tmp112_last) __out.AppendLine(true);
                    }
                    string __tmp113_line = "();"; //283:113
                    if (!string.IsNullOrEmpty(__tmp113_line))
                    {
                        __out.Write(__tmp113_line);
                        __tmp109_outputWritten = true;
                    }
                    if (__tmp109_outputWritten) __out.AppendLine(true);
                    if (__tmp109_outputWritten)
                    {
                        __out.AppendLine(false); //283:116
                    }
                }
                else //284:5
                {
                    bool __tmp115_outputWritten = false;
                    string __tmp114Prefix = "		"; //285:1
                    var __tmp116 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp116.Write(CSharpName(cst, model, ClassKind.BuilderInstance));
                    var __tmp116Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp116.ToStringAndFree());
                    bool __tmp116_last = __tmp116Reader.EndOfStream;
                    while(!__tmp116_last)
                    {
                        ReadOnlySpan<char> __tmp116_line = __tmp116Reader.ReadLine();
                        __tmp116_last = __tmp116Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp114Prefix))
                        {
                            __out.Write(__tmp114Prefix);
                            __tmp115_outputWritten = true;
                        }
                        if (!__tmp116_last || !__tmp116_line.IsEmpty)
                        {
                            __out.Write(__tmp116_line);
                            __tmp115_outputWritten = true;
                        }
                        if (!__tmp116_last) __out.AppendLine(true);
                    }
                    string __tmp117_line = " = constantFactory."; //285:53
                    if (!string.IsNullOrEmpty(__tmp117_line))
                    {
                        __out.Write(__tmp117_line);
                        __tmp115_outputWritten = true;
                    }
                    var __tmp118 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp118.Write(CSharpName(cst.Type, model, ClassKind.Immutable));
                    var __tmp118Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp118.ToStringAndFree());
                    bool __tmp118_last = __tmp118Reader.EndOfStream;
                    while(!__tmp118_last)
                    {
                        ReadOnlySpan<char> __tmp118_line = __tmp118Reader.ReadLine();
                        __tmp118_last = __tmp118Reader.EndOfStream;
                        if (!__tmp118_last || !__tmp118_line.IsEmpty)
                        {
                            __out.Write(__tmp118_line);
                            __tmp115_outputWritten = true;
                        }
                        if (!__tmp118_last) __out.AppendLine(true);
                    }
                    string __tmp119_line = "();"; //285:121
                    if (!string.IsNullOrEmpty(__tmp119_line))
                    {
                        __out.Write(__tmp119_line);
                        __tmp115_outputWritten = true;
                    }
                    if (__tmp115_outputWritten) __out.AppendLine(true);
                    if (__tmp115_outputWritten)
                    {
                        __out.AppendLine(false); //285:124
                    }
                }
                if (cst.DotNetName != null) //287:5
                {
                    bool __tmp121_outputWritten = false;
                    string __tmp120Prefix = "		"; //288:1
                    var __tmp122 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp122.Write(CSharpName(cst, model, ClassKind.BuilderInstance));
                    var __tmp122Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp122.ToStringAndFree());
                    bool __tmp122_last = __tmp122Reader.EndOfStream;
                    while(!__tmp122_last)
                    {
                        ReadOnlySpan<char> __tmp122_line = __tmp122Reader.ReadLine();
                        __tmp122_last = __tmp122Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp120Prefix))
                        {
                            __out.Write(__tmp120Prefix);
                            __tmp121_outputWritten = true;
                        }
                        if (!__tmp122_last || !__tmp122_line.IsEmpty)
                        {
                            __out.Write(__tmp122_line);
                            __tmp121_outputWritten = true;
                        }
                        if (!__tmp122_last) __out.AppendLine(true);
                    }
                    string __tmp123_line = ".MName = \""; //288:53
                    if (!string.IsNullOrEmpty(__tmp123_line))
                    {
                        __out.Write(__tmp123_line);
                        __tmp121_outputWritten = true;
                    }
                    var __tmp124 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp124.Write(cst.Name);
                    var __tmp124Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp124.ToStringAndFree());
                    bool __tmp124_last = __tmp124Reader.EndOfStream;
                    while(!__tmp124_last)
                    {
                        ReadOnlySpan<char> __tmp124_line = __tmp124Reader.ReadLine();
                        __tmp124_last = __tmp124Reader.EndOfStream;
                        if (!__tmp124_last || !__tmp124_line.IsEmpty)
                        {
                            __out.Write(__tmp124_line);
                            __tmp121_outputWritten = true;
                        }
                        if (!__tmp124_last) __out.AppendLine(true);
                    }
                    string __tmp125_line = "\";"; //288:73
                    if (!string.IsNullOrEmpty(__tmp125_line))
                    {
                        __out.Write(__tmp125_line);
                        __tmp121_outputWritten = true;
                    }
                    if (__tmp121_outputWritten) __out.AppendLine(true);
                    if (__tmp121_outputWritten)
                    {
                        __out.AppendLine(false); //288:75
                    }
                    bool __tmp127_outputWritten = false;
                    string __tmp126Prefix = "		"; //289:1
                    var __tmp128 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp128.Write(CSharpName(cst, model, ClassKind.BuilderInstance));
                    var __tmp128Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp128.ToStringAndFree());
                    bool __tmp128_last = __tmp128Reader.EndOfStream;
                    while(!__tmp128_last)
                    {
                        ReadOnlySpan<char> __tmp128_line = __tmp128Reader.ReadLine();
                        __tmp128_last = __tmp128Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp126Prefix))
                        {
                            __out.Write(__tmp126Prefix);
                            __tmp127_outputWritten = true;
                        }
                        if (!__tmp128_last || !__tmp128_line.IsEmpty)
                        {
                            __out.Write(__tmp128_line);
                            __tmp127_outputWritten = true;
                        }
                        if (!__tmp128_last) __out.AppendLine(true);
                    }
                    string __tmp129_line = ".DotNetName = \""; //289:53
                    if (!string.IsNullOrEmpty(__tmp129_line))
                    {
                        __out.Write(__tmp129_line);
                        __tmp127_outputWritten = true;
                    }
                    var __tmp130 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp130.Write(cst.DotNetName);
                    var __tmp130Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp130.ToStringAndFree());
                    bool __tmp130_last = __tmp130Reader.EndOfStream;
                    while(!__tmp130_last)
                    {
                        ReadOnlySpan<char> __tmp130_line = __tmp130Reader.ReadLine();
                        __tmp130_last = __tmp130Reader.EndOfStream;
                        if (!__tmp130_last || !__tmp130_line.IsEmpty)
                        {
                            __out.Write(__tmp130_line);
                            __tmp127_outputWritten = true;
                        }
                        if (!__tmp130_last) __out.AppendLine(true);
                    }
                    string __tmp131_line = "\";"; //289:84
                    if (!string.IsNullOrEmpty(__tmp131_line))
                    {
                        __out.Write(__tmp131_line);
                        __tmp127_outputWritten = true;
                    }
                    if (__tmp127_outputWritten) __out.AppendLine(true);
                    if (__tmp127_outputWritten)
                    {
                        __out.AppendLine(false); //289:86
                    }
                }
            }
            __out.AppendLine(true); //292:1
            var __loop18_results = 
                (from obj in __Enumerate((instances).GetEnumerator()) //293:9
                select new { obj = obj}
                ).ToList(); //293:4
            for (int __loop18_iteration = 0; __loop18_iteration < __loop18_results.Count; ++__loop18_iteration)
            {
                var __tmp132 = __loop18_results[__loop18_iteration];
                var obj = __tmp132.obj;
                bool __tmp134_outputWritten = false;
                string __tmp133Prefix = "		"; //294:1
                var __tmp135 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp135.Write(GenerateInstance(model, metaMetaModel, obj, instanceNames));
                var __tmp135Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp135.ToStringAndFree());
                bool __tmp135_last = __tmp135Reader.EndOfStream;
                while(!__tmp135_last)
                {
                    ReadOnlySpan<char> __tmp135_line = __tmp135Reader.ReadLine();
                    __tmp135_last = __tmp135Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp133Prefix))
                    {
                        __out.Write(__tmp133Prefix);
                        __tmp134_outputWritten = true;
                    }
                    if (!__tmp135_last || !__tmp135_line.IsEmpty)
                    {
                        __out.Write(__tmp135_line);
                        __tmp134_outputWritten = true;
                    }
                    if (!__tmp135_last || __tmp134_outputWritten) __out.AppendLine(true);
                }
                if (__tmp134_outputWritten)
                {
                    __out.AppendLine(false); //294:63
                }
            }
            __out.AppendLine(true); //296:1
            var __loop19_results = 
                (from obj in __Enumerate((instances).GetEnumerator()) //297:9
                select new { obj = obj}
                ).ToList(); //297:4
            for (int __loop19_iteration = 0; __loop19_iteration < __loop19_results.Count; ++__loop19_iteration)
            {
                var __tmp136 = __loop19_results[__loop19_iteration];
                var obj = __tmp136.obj;
                bool __tmp138_outputWritten = false;
                string __tmp137Prefix = "		"; //298:1
                var __tmp139 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp139.Write(GenerateInstanceProperties(model, metaMetaModel, obj, instanceNames));
                var __tmp139Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp139.ToStringAndFree());
                bool __tmp139_last = __tmp139Reader.EndOfStream;
                while(!__tmp139_last)
                {
                    ReadOnlySpan<char> __tmp139_line = __tmp139Reader.ReadLine();
                    __tmp139_last = __tmp139Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp137Prefix))
                    {
                        __out.Write(__tmp137Prefix);
                        __tmp138_outputWritten = true;
                    }
                    if (!__tmp139_last || !__tmp139_line.IsEmpty)
                    {
                        __out.Write(__tmp139_line);
                        __tmp138_outputWritten = true;
                    }
                    if (!__tmp139_last || __tmp138_outputWritten) __out.AppendLine(true);
                }
                if (__tmp138_outputWritten)
                {
                    __out.AppendLine(false); //298:73
                }
            }
            __out.Write("	}"); //300:1
            __out.AppendLine(false); //300:3
            __out.Write("}"); //301:1
            __out.AppendLine(false); //301:2
            return __out.ToStringAndFree();
        }

        public string GenerateInstanceDeclaration(MetaModel model, bool metaMetaModel, ImmutableObject obj, ImmutableDictionary<ImmutableObject,string> instanceNames) //304:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            if (obj != null && obj.MMetaClass != null && instanceNames.ContainsKey(obj)) //305:2
            {
                string name = instanceNames[obj]; //306:3
                if (metaMetaModel) //307:3
                {
                    if (name.StartsWith("__")) //308:4
                    {
                        bool __tmp2_outputWritten = false;
                        string __tmp3_line = "private "; //309:1
                        if (!string.IsNullOrEmpty(__tmp3_line))
                        {
                            __out.Write(__tmp3_line);
                            __tmp2_outputWritten = true;
                        }
                        var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp4.Write(CSharpName(obj.MMetaClass, model, ClassKind.Builder));
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
                        string __tmp5_line = " "; //309:62
                        if (!string.IsNullOrEmpty(__tmp5_line))
                        {
                            __out.Write(__tmp5_line);
                            __tmp2_outputWritten = true;
                        }
                        var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp6.Write(name);
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
                        string __tmp7_line = ";"; //309:69
                        if (!string.IsNullOrEmpty(__tmp7_line))
                        {
                            __out.Write(__tmp7_line);
                            __tmp2_outputWritten = true;
                        }
                        if (__tmp2_outputWritten) __out.AppendLine(true);
                        if (__tmp2_outputWritten)
                        {
                            __out.AppendLine(false); //309:70
                        }
                    }
                    else //310:4
                    {
                        bool __tmp9_outputWritten = false;
                        string __tmp10_line = "internal "; //311:1
                        if (!string.IsNullOrEmpty(__tmp10_line))
                        {
                            __out.Write(__tmp10_line);
                            __tmp9_outputWritten = true;
                        }
                        var __tmp11 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp11.Write(CSharpName(obj.MMetaClass, model, ClassKind.Builder));
                        var __tmp11Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp11.ToStringAndFree());
                        bool __tmp11_last = __tmp11Reader.EndOfStream;
                        while(!__tmp11_last)
                        {
                            ReadOnlySpan<char> __tmp11_line = __tmp11Reader.ReadLine();
                            __tmp11_last = __tmp11Reader.EndOfStream;
                            if (!__tmp11_last || !__tmp11_line.IsEmpty)
                            {
                                __out.Write(__tmp11_line);
                                __tmp9_outputWritten = true;
                            }
                            if (!__tmp11_last) __out.AppendLine(true);
                        }
                        string __tmp12_line = " "; //311:63
                        if (!string.IsNullOrEmpty(__tmp12_line))
                        {
                            __out.Write(__tmp12_line);
                            __tmp9_outputWritten = true;
                        }
                        var __tmp13 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp13.Write(name);
                        var __tmp13Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp13.ToStringAndFree());
                        bool __tmp13_last = __tmp13Reader.EndOfStream;
                        while(!__tmp13_last)
                        {
                            ReadOnlySpan<char> __tmp13_line = __tmp13Reader.ReadLine();
                            __tmp13_last = __tmp13Reader.EndOfStream;
                            if (!__tmp13_last || !__tmp13_line.IsEmpty)
                            {
                                __out.Write(__tmp13_line);
                                __tmp9_outputWritten = true;
                            }
                            if (!__tmp13_last) __out.AppendLine(true);
                        }
                        string __tmp14_line = ";"; //311:70
                        if (!string.IsNullOrEmpty(__tmp14_line))
                        {
                            __out.Write(__tmp14_line);
                            __tmp9_outputWritten = true;
                        }
                        if (__tmp9_outputWritten) __out.AppendLine(true);
                        if (__tmp9_outputWritten)
                        {
                            __out.AppendLine(false); //311:71
                        }
                    }
                }
                else //313:3
                {
                    if (name.StartsWith("__")) //314:4
                    {
                        bool __tmp16_outputWritten = false;
                        string __tmp17_line = "private "; //315:1
                        if (!string.IsNullOrEmpty(__tmp17_line))
                        {
                            __out.Write(__tmp17_line);
                            __tmp16_outputWritten = true;
                        }
                        var __tmp18 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp18.Write(CSharpName(obj.MMetaClass, model, ClassKind.Builder, true));
                        var __tmp18Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp18.ToStringAndFree());
                        bool __tmp18_last = __tmp18Reader.EndOfStream;
                        while(!__tmp18_last)
                        {
                            ReadOnlySpan<char> __tmp18_line = __tmp18Reader.ReadLine();
                            __tmp18_last = __tmp18Reader.EndOfStream;
                            if (!__tmp18_last || !__tmp18_line.IsEmpty)
                            {
                                __out.Write(__tmp18_line);
                                __tmp16_outputWritten = true;
                            }
                            if (!__tmp18_last) __out.AppendLine(true);
                        }
                        string __tmp19_line = " "; //315:68
                        if (!string.IsNullOrEmpty(__tmp19_line))
                        {
                            __out.Write(__tmp19_line);
                            __tmp16_outputWritten = true;
                        }
                        var __tmp20 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp20.Write(name);
                        var __tmp20Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp20.ToStringAndFree());
                        bool __tmp20_last = __tmp20Reader.EndOfStream;
                        while(!__tmp20_last)
                        {
                            ReadOnlySpan<char> __tmp20_line = __tmp20Reader.ReadLine();
                            __tmp20_last = __tmp20Reader.EndOfStream;
                            if (!__tmp20_last || !__tmp20_line.IsEmpty)
                            {
                                __out.Write(__tmp20_line);
                                __tmp16_outputWritten = true;
                            }
                            if (!__tmp20_last) __out.AppendLine(true);
                        }
                        string __tmp21_line = ";"; //315:75
                        if (!string.IsNullOrEmpty(__tmp21_line))
                        {
                            __out.Write(__tmp21_line);
                            __tmp16_outputWritten = true;
                        }
                        if (__tmp16_outputWritten) __out.AppendLine(true);
                        if (__tmp16_outputWritten)
                        {
                            __out.AppendLine(false); //315:76
                        }
                    }
                    else //316:4
                    {
                        bool __tmp23_outputWritten = false;
                        string __tmp24_line = "internal "; //317:1
                        if (!string.IsNullOrEmpty(__tmp24_line))
                        {
                            __out.Write(__tmp24_line);
                            __tmp23_outputWritten = true;
                        }
                        var __tmp25 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp25.Write(CSharpName(obj.MMetaClass, model, ClassKind.Builder, true));
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
                        string __tmp26_line = " "; //317:69
                        if (!string.IsNullOrEmpty(__tmp26_line))
                        {
                            __out.Write(__tmp26_line);
                            __tmp23_outputWritten = true;
                        }
                        var __tmp27 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp27.Write(name);
                        var __tmp27Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp27.ToStringAndFree());
                        bool __tmp27_last = __tmp27Reader.EndOfStream;
                        while(!__tmp27_last)
                        {
                            ReadOnlySpan<char> __tmp27_line = __tmp27Reader.ReadLine();
                            __tmp27_last = __tmp27Reader.EndOfStream;
                            if (!__tmp27_last || !__tmp27_line.IsEmpty)
                            {
                                __out.Write(__tmp27_line);
                                __tmp23_outputWritten = true;
                            }
                            if (!__tmp27_last) __out.AppendLine(true);
                        }
                        string __tmp28_line = ";"; //317:76
                        if (!string.IsNullOrEmpty(__tmp28_line))
                        {
                            __out.Write(__tmp28_line);
                            __tmp23_outputWritten = true;
                        }
                        if (__tmp23_outputWritten) __out.AppendLine(true);
                        if (__tmp23_outputWritten)
                        {
                            __out.AppendLine(false); //317:77
                        }
                    }
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateInstance(MetaModel model, bool metaMetaModel, ImmutableObject obj, ImmutableDictionary<ImmutableObject,string> instanceNames) //323:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            if (obj != null && obj.MMetaClass != null && instanceNames.ContainsKey(obj)) //324:2
            {
                string name = instanceNames[obj]; //325:3
                bool __tmp2_outputWritten = false;
                var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp3.Write(name);
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
                    if (!__tmp3_last) __out.AppendLine(true);
                }
                string __tmp4_line = " = factory."; //326:7
                if (!string.IsNullOrEmpty(__tmp4_line))
                {
                    __out.Write(__tmp4_line);
                    __tmp2_outputWritten = true;
                }
                var __tmp5 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp5.Write(CSharpName(obj.MMetaClass, model, ClassKind.Immutable));
                var __tmp5Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp5.ToStringAndFree());
                bool __tmp5_last = __tmp5Reader.EndOfStream;
                while(!__tmp5_last)
                {
                    ReadOnlySpan<char> __tmp5_line = __tmp5Reader.ReadLine();
                    __tmp5_last = __tmp5Reader.EndOfStream;
                    if (!__tmp5_last || !__tmp5_line.IsEmpty)
                    {
                        __out.Write(__tmp5_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp5_last) __out.AppendLine(true);
                }
                string __tmp6_line = "();"; //326:73
                if (!string.IsNullOrEmpty(__tmp6_line))
                {
                    __out.Write(__tmp6_line);
                    __tmp2_outputWritten = true;
                }
                if (__tmp2_outputWritten) __out.AppendLine(true);
                if (__tmp2_outputWritten)
                {
                    __out.AppendLine(false); //326:76
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateInstanceProperties(MetaModel model, bool metaMetaModel, ImmutableObject obj, ImmutableDictionary<ImmutableObject,string> instanceNames) //330:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            if (obj != null && obj.MMetaClass != null && instanceNames.ContainsKey(obj)) //331:2
            {
                var __loop20_results = 
                    (from __loop20_var1 in __Enumerate((obj).GetEnumerator()) //332:8
                    from prop in __Enumerate((__loop20_var1.MProperties).GetEnumerator()) //332:13
                    where !prop.IsDerived && !prop.IsDerivedUnion //332:30
                    select new { __loop20_var1 = __loop20_var1, prop = prop}
                    ).ToList(); //332:3
                for (int __loop20_iteration = 0; __loop20_iteration < __loop20_results.Count; ++__loop20_iteration)
                {
                    var __tmp1 = __loop20_results[__loop20_iteration];
                    var __loop20_var1 = __tmp1.__loop20_var1;
                    var prop = __tmp1.prop;
                    if (obj is MetaConstant && prop.Name == "Value") //333:4
                    {
                        string name = instanceNames[obj]; //334:5
                        bool __tmp3_outputWritten = false;
                        var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp4.Write(name);
                        var __tmp4Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp4.ToStringAndFree());
                        bool __tmp4_last = __tmp4Reader.EndOfStream;
                        while(!__tmp4_last)
                        {
                            ReadOnlySpan<char> __tmp4_line = __tmp4Reader.ReadLine();
                            __tmp4_last = __tmp4Reader.EndOfStream;
                            if (!__tmp4_last || !__tmp4_line.IsEmpty)
                            {
                                __out.Write(__tmp4_line);
                                __tmp3_outputWritten = true;
                            }
                            if (!__tmp4_last) __out.AppendLine(true);
                        }
                        string __tmp5_line = ".SetValueLazy(() => "; //335:7
                        if (!string.IsNullOrEmpty(__tmp5_line))
                        {
                            __out.Write(__tmp5_line);
                            __tmp3_outputWritten = true;
                        }
                        var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp6.Write(CSharpName(((MetaConstant)obj), model, ClassKind.BuilderInstance));
                        var __tmp6Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp6.ToStringAndFree());
                        bool __tmp6_last = __tmp6Reader.EndOfStream;
                        while(!__tmp6_last)
                        {
                            ReadOnlySpan<char> __tmp6_line = __tmp6Reader.ReadLine();
                            __tmp6_last = __tmp6Reader.EndOfStream;
                            if (!__tmp6_last || !__tmp6_line.IsEmpty)
                            {
                                __out.Write(__tmp6_line);
                                __tmp3_outputWritten = true;
                            }
                            if (!__tmp6_last) __out.AppendLine(true);
                        }
                        string __tmp7_line = ");"; //335:93
                        if (!string.IsNullOrEmpty(__tmp7_line))
                        {
                            __out.Write(__tmp7_line);
                            __tmp3_outputWritten = true;
                        }
                        if (__tmp3_outputWritten) __out.AppendLine(true);
                        if (__tmp3_outputWritten)
                        {
                            __out.AppendLine(false); //335:95
                        }
                    }
                    else //336:4
                    {
                        object propValue = obj.MGet(prop); //337:5
                        bool __tmp9_outputWritten = false;
                        var __tmp10 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp10.Write(GenerateInstancePropertyValue(model, metaMetaModel, obj, prop, propValue, instanceNames));
                        var __tmp10Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp10.ToStringAndFree());
                        bool __tmp10_last = __tmp10Reader.EndOfStream;
                        while(!__tmp10_last)
                        {
                            ReadOnlySpan<char> __tmp10_line = __tmp10Reader.ReadLine();
                            __tmp10_last = __tmp10Reader.EndOfStream;
                            if (!__tmp10_last || !__tmp10_line.IsEmpty)
                            {
                                __out.Write(__tmp10_line);
                                __tmp9_outputWritten = true;
                            }
                            if (!__tmp10_last || __tmp9_outputWritten) __out.AppendLine(true);
                        }
                        if (__tmp9_outputWritten)
                        {
                            __out.AppendLine(false); //338:91
                        }
                    }
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateInstancePropertyValue(MetaModel model, bool metaMetaModel, ImmutableObject obj, ModelProperty prop, object value, ImmutableDictionary<ImmutableObject,string> instanceNames) //344:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string name = instanceNames[obj]; //345:2
            ImmutableObject valueObject = value as ImmutableObject; //346:2
            MetaDeclaration valueDecl = value as MetaDeclaration; //347:2
            IEnumerable<object> valueCollection = value as IEnumerable<object>; //348:2
            if (value == null) //349:2
            {
                if (prop.MutableType != null && prop.MutableType.IsClass) //350:3
                {
                    bool __tmp2_outputWritten = false;
                    var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp3.Write(name);
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
                        if (!__tmp3_last) __out.AppendLine(true);
                    }
                    string __tmp4_line = "."; //351:7
                    if (!string.IsNullOrEmpty(__tmp4_line))
                    {
                        __out.Write(__tmp4_line);
                        __tmp2_outputWritten = true;
                    }
                    var __tmp5 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp5.Write(prop.Name);
                    var __tmp5Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp5.ToStringAndFree());
                    bool __tmp5_last = __tmp5Reader.EndOfStream;
                    while(!__tmp5_last)
                    {
                        ReadOnlySpan<char> __tmp5_line = __tmp5Reader.ReadLine();
                        __tmp5_last = __tmp5Reader.EndOfStream;
                        if (!__tmp5_last || !__tmp5_line.IsEmpty)
                        {
                            __out.Write(__tmp5_line);
                            __tmp2_outputWritten = true;
                        }
                        if (!__tmp5_last) __out.AppendLine(true);
                    }
                    string __tmp6_line = " = null;"; //351:19
                    if (!string.IsNullOrEmpty(__tmp6_line))
                    {
                        __out.Write(__tmp6_line);
                        __tmp2_outputWritten = true;
                    }
                    if (__tmp2_outputWritten) __out.AppendLine(true);
                    if (__tmp2_outputWritten)
                    {
                        __out.AppendLine(false); //351:27
                    }
                }
                else //352:3
                {
                    bool __tmp8_outputWritten = false;
                    string __tmp9_line = "// "; //353:1
                    if (!string.IsNullOrEmpty(__tmp9_line))
                    {
                        __out.Write(__tmp9_line);
                        __tmp8_outputWritten = true;
                    }
                    var __tmp10 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp10.Write(name);
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
                    string __tmp11_line = "."; //353:10
                    if (!string.IsNullOrEmpty(__tmp11_line))
                    {
                        __out.Write(__tmp11_line);
                        __tmp8_outputWritten = true;
                    }
                    var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp12.Write(prop.Name);
                    var __tmp12Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp12.ToStringAndFree());
                    bool __tmp12_last = __tmp12Reader.EndOfStream;
                    while(!__tmp12_last)
                    {
                        ReadOnlySpan<char> __tmp12_line = __tmp12Reader.ReadLine();
                        __tmp12_last = __tmp12Reader.EndOfStream;
                        if (!__tmp12_last || !__tmp12_line.IsEmpty)
                        {
                            __out.Write(__tmp12_line);
                            __tmp8_outputWritten = true;
                        }
                        if (!__tmp12_last) __out.AppendLine(true);
                    }
                    string __tmp13_line = " = null;"; //353:22
                    if (!string.IsNullOrEmpty(__tmp13_line))
                    {
                        __out.Write(__tmp13_line);
                        __tmp8_outputWritten = true;
                    }
                    if (__tmp8_outputWritten) __out.AppendLine(true);
                    if (__tmp8_outputWritten)
                    {
                        __out.AppendLine(false); //353:30
                    }
                }
            }
            else if (value is string) //355:2
            {
                bool __tmp15_outputWritten = false;
                var __tmp16 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp16.Write(name);
                var __tmp16Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp16.ToStringAndFree());
                bool __tmp16_last = __tmp16Reader.EndOfStream;
                while(!__tmp16_last)
                {
                    ReadOnlySpan<char> __tmp16_line = __tmp16Reader.ReadLine();
                    __tmp16_last = __tmp16Reader.EndOfStream;
                    if (!__tmp16_last || !__tmp16_line.IsEmpty)
                    {
                        __out.Write(__tmp16_line);
                        __tmp15_outputWritten = true;
                    }
                    if (!__tmp16_last) __out.AppendLine(true);
                }
                string __tmp17_line = "."; //356:7
                if (!string.IsNullOrEmpty(__tmp17_line))
                {
                    __out.Write(__tmp17_line);
                    __tmp15_outputWritten = true;
                }
                var __tmp18 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp18.Write(prop.Name);
                var __tmp18Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp18.ToStringAndFree());
                bool __tmp18_last = __tmp18Reader.EndOfStream;
                while(!__tmp18_last)
                {
                    ReadOnlySpan<char> __tmp18_line = __tmp18Reader.ReadLine();
                    __tmp18_last = __tmp18Reader.EndOfStream;
                    if (!__tmp18_last || !__tmp18_line.IsEmpty)
                    {
                        __out.Write(__tmp18_line);
                        __tmp15_outputWritten = true;
                    }
                    if (!__tmp18_last) __out.AppendLine(true);
                }
                string __tmp19_line = " = \""; //356:19
                if (!string.IsNullOrEmpty(__tmp19_line))
                {
                    __out.Write(__tmp19_line);
                    __tmp15_outputWritten = true;
                }
                var __tmp20 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp20.Write(EscapeText((string)value));
                var __tmp20Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp20.ToStringAndFree());
                bool __tmp20_last = __tmp20Reader.EndOfStream;
                while(!__tmp20_last)
                {
                    ReadOnlySpan<char> __tmp20_line = __tmp20Reader.ReadLine();
                    __tmp20_last = __tmp20Reader.EndOfStream;
                    if (!__tmp20_last || !__tmp20_line.IsEmpty)
                    {
                        __out.Write(__tmp20_line);
                        __tmp15_outputWritten = true;
                    }
                    if (!__tmp20_last) __out.AppendLine(true);
                }
                string __tmp21_line = "\";"; //356:50
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Write(__tmp21_line);
                    __tmp15_outputWritten = true;
                }
                if (__tmp15_outputWritten) __out.AppendLine(true);
                if (__tmp15_outputWritten)
                {
                    __out.AppendLine(false); //356:52
                }
            }
            else if (value is bool) //357:2
            {
                bool __tmp23_outputWritten = false;
                var __tmp24 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp24.Write(name);
                var __tmp24Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp24.ToStringAndFree());
                bool __tmp24_last = __tmp24Reader.EndOfStream;
                while(!__tmp24_last)
                {
                    ReadOnlySpan<char> __tmp24_line = __tmp24Reader.ReadLine();
                    __tmp24_last = __tmp24Reader.EndOfStream;
                    if (!__tmp24_last || !__tmp24_line.IsEmpty)
                    {
                        __out.Write(__tmp24_line);
                        __tmp23_outputWritten = true;
                    }
                    if (!__tmp24_last) __out.AppendLine(true);
                }
                string __tmp25_line = "."; //358:7
                if (!string.IsNullOrEmpty(__tmp25_line))
                {
                    __out.Write(__tmp25_line);
                    __tmp23_outputWritten = true;
                }
                var __tmp26 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp26.Write(prop.Name);
                var __tmp26Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp26.ToStringAndFree());
                bool __tmp26_last = __tmp26Reader.EndOfStream;
                while(!__tmp26_last)
                {
                    ReadOnlySpan<char> __tmp26_line = __tmp26Reader.ReadLine();
                    __tmp26_last = __tmp26Reader.EndOfStream;
                    if (!__tmp26_last || !__tmp26_line.IsEmpty)
                    {
                        __out.Write(__tmp26_line);
                        __tmp23_outputWritten = true;
                    }
                    if (!__tmp26_last) __out.AppendLine(true);
                }
                string __tmp27_line = " = "; //358:19
                if (!string.IsNullOrEmpty(__tmp27_line))
                {
                    __out.Write(__tmp27_line);
                    __tmp23_outputWritten = true;
                }
                var __tmp28 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp28.Write(value.ToString().ToLower());
                var __tmp28Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp28.ToStringAndFree());
                bool __tmp28_last = __tmp28Reader.EndOfStream;
                while(!__tmp28_last)
                {
                    ReadOnlySpan<char> __tmp28_line = __tmp28Reader.ReadLine();
                    __tmp28_last = __tmp28Reader.EndOfStream;
                    if (!__tmp28_last || !__tmp28_line.IsEmpty)
                    {
                        __out.Write(__tmp28_line);
                        __tmp23_outputWritten = true;
                    }
                    if (!__tmp28_last) __out.AppendLine(true);
                }
                string __tmp29_line = ";"; //358:50
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Write(__tmp29_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //358:51
                }
            }
            else if (value.GetType().IsPrimitive) //359:2
            {
                bool __tmp31_outputWritten = false;
                var __tmp32 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp32.Write(name);
                var __tmp32Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp32.ToStringAndFree());
                bool __tmp32_last = __tmp32Reader.EndOfStream;
                while(!__tmp32_last)
                {
                    ReadOnlySpan<char> __tmp32_line = __tmp32Reader.ReadLine();
                    __tmp32_last = __tmp32Reader.EndOfStream;
                    if (!__tmp32_last || !__tmp32_line.IsEmpty)
                    {
                        __out.Write(__tmp32_line);
                        __tmp31_outputWritten = true;
                    }
                    if (!__tmp32_last) __out.AppendLine(true);
                }
                string __tmp33_line = "."; //360:7
                if (!string.IsNullOrEmpty(__tmp33_line))
                {
                    __out.Write(__tmp33_line);
                    __tmp31_outputWritten = true;
                }
                var __tmp34 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp34.Write(prop.Name);
                var __tmp34Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp34.ToStringAndFree());
                bool __tmp34_last = __tmp34Reader.EndOfStream;
                while(!__tmp34_last)
                {
                    ReadOnlySpan<char> __tmp34_line = __tmp34Reader.ReadLine();
                    __tmp34_last = __tmp34Reader.EndOfStream;
                    if (!__tmp34_last || !__tmp34_line.IsEmpty)
                    {
                        __out.Write(__tmp34_line);
                        __tmp31_outputWritten = true;
                    }
                    if (!__tmp34_last) __out.AppendLine(true);
                }
                string __tmp35_line = " = "; //360:19
                if (!string.IsNullOrEmpty(__tmp35_line))
                {
                    __out.Write(__tmp35_line);
                    __tmp31_outputWritten = true;
                }
                var __tmp36 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp36.Write(value.ToString());
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
                string __tmp37_line = ";"; //360:40
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Write(__tmp37_line);
                    __tmp31_outputWritten = true;
                }
                if (__tmp31_outputWritten) __out.AppendLine(true);
                if (__tmp31_outputWritten)
                {
                    __out.AppendLine(false); //360:41
                }
            }
            else if (value is MetaAttribute) //361:2
            {
                bool __tmp39_outputWritten = false;
                var __tmp40 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp40.Write(name);
                var __tmp40Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp40.ToStringAndFree());
                bool __tmp40_last = __tmp40Reader.EndOfStream;
                while(!__tmp40_last)
                {
                    ReadOnlySpan<char> __tmp40_line = __tmp40Reader.ReadLine();
                    __tmp40_last = __tmp40Reader.EndOfStream;
                    if (!__tmp40_last || !__tmp40_line.IsEmpty)
                    {
                        __out.Write(__tmp40_line);
                        __tmp39_outputWritten = true;
                    }
                    if (!__tmp40_last) __out.AppendLine(true);
                }
                string __tmp41_line = "."; //362:7
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Write(__tmp41_line);
                    __tmp39_outputWritten = true;
                }
                var __tmp42 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp42.Write(prop.Name);
                var __tmp42Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp42.ToStringAndFree());
                bool __tmp42_last = __tmp42Reader.EndOfStream;
                while(!__tmp42_last)
                {
                    ReadOnlySpan<char> __tmp42_line = __tmp42Reader.ReadLine();
                    __tmp42_last = __tmp42Reader.EndOfStream;
                    if (!__tmp42_last || !__tmp42_line.IsEmpty)
                    {
                        __out.Write(__tmp42_line);
                        __tmp39_outputWritten = true;
                    }
                    if (!__tmp42_last) __out.AppendLine(true);
                }
                string __tmp43_line = " = "; //362:19
                if (!string.IsNullOrEmpty(__tmp43_line))
                {
                    __out.Write(__tmp43_line);
                    __tmp39_outputWritten = true;
                }
                var __tmp44 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp44.Write(GetAttributeValueOf(model, (MetaAttribute)value));
                var __tmp44Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp44.ToStringAndFree());
                bool __tmp44_last = __tmp44Reader.EndOfStream;
                while(!__tmp44_last)
                {
                    ReadOnlySpan<char> __tmp44_line = __tmp44Reader.ReadLine();
                    __tmp44_last = __tmp44Reader.EndOfStream;
                    if (!__tmp44_last || !__tmp44_line.IsEmpty)
                    {
                        __out.Write(__tmp44_line);
                        __tmp39_outputWritten = true;
                    }
                    if (!__tmp44_last) __out.AppendLine(true);
                }
                string __tmp45_line = ";"; //362:72
                if (!string.IsNullOrEmpty(__tmp45_line))
                {
                    __out.Write(__tmp45_line);
                    __tmp39_outputWritten = true;
                }
                if (__tmp39_outputWritten) __out.AppendLine(true);
                if (__tmp39_outputWritten)
                {
                    __out.AppendLine(false); //362:73
                }
            }
            else if (value is Enum) //363:2
            {
                bool __tmp47_outputWritten = false;
                var __tmp48 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp48.Write(name);
                var __tmp48Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp48.ToStringAndFree());
                bool __tmp48_last = __tmp48Reader.EndOfStream;
                while(!__tmp48_last)
                {
                    ReadOnlySpan<char> __tmp48_line = __tmp48Reader.ReadLine();
                    __tmp48_last = __tmp48Reader.EndOfStream;
                    if (!__tmp48_last || !__tmp48_line.IsEmpty)
                    {
                        __out.Write(__tmp48_line);
                        __tmp47_outputWritten = true;
                    }
                    if (!__tmp48_last) __out.AppendLine(true);
                }
                string __tmp49_line = "."; //364:7
                if (!string.IsNullOrEmpty(__tmp49_line))
                {
                    __out.Write(__tmp49_line);
                    __tmp47_outputWritten = true;
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
                        __tmp47_outputWritten = true;
                    }
                    if (!__tmp50_last) __out.AppendLine(true);
                }
                string __tmp51_line = " = "; //364:19
                if (!string.IsNullOrEmpty(__tmp51_line))
                {
                    __out.Write(__tmp51_line);
                    __tmp47_outputWritten = true;
                }
                var __tmp52 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp52.Write(GetEnumValueOf(model, (Enum)value));
                var __tmp52Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp52.ToStringAndFree());
                bool __tmp52_last = __tmp52Reader.EndOfStream;
                while(!__tmp52_last)
                {
                    ReadOnlySpan<char> __tmp52_line = __tmp52Reader.ReadLine();
                    __tmp52_last = __tmp52Reader.EndOfStream;
                    if (!__tmp52_last || !__tmp52_line.IsEmpty)
                    {
                        __out.Write(__tmp52_line);
                        __tmp47_outputWritten = true;
                    }
                    if (!__tmp52_last) __out.AppendLine(true);
                }
                string __tmp53_line = ";"; //364:58
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Write(__tmp53_line);
                    __tmp47_outputWritten = true;
                }
                if (__tmp47_outputWritten) __out.AppendLine(true);
                if (__tmp47_outputWritten)
                {
                    __out.AppendLine(false); //364:59
                }
            }
            else if (value is Type) //365:2
            {
                bool __tmp55_outputWritten = false;
                var __tmp56 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp56.Write(name);
                var __tmp56Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp56.ToStringAndFree());
                bool __tmp56_last = __tmp56Reader.EndOfStream;
                while(!__tmp56_last)
                {
                    ReadOnlySpan<char> __tmp56_line = __tmp56Reader.ReadLine();
                    __tmp56_last = __tmp56Reader.EndOfStream;
                    if (!__tmp56_last || !__tmp56_line.IsEmpty)
                    {
                        __out.Write(__tmp56_line);
                        __tmp55_outputWritten = true;
                    }
                    if (!__tmp56_last) __out.AppendLine(true);
                }
                string __tmp57_line = "."; //366:7
                if (!string.IsNullOrEmpty(__tmp57_line))
                {
                    __out.Write(__tmp57_line);
                    __tmp55_outputWritten = true;
                }
                var __tmp58 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp58.Write(prop.Name);
                var __tmp58Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp58.ToStringAndFree());
                bool __tmp58_last = __tmp58Reader.EndOfStream;
                while(!__tmp58_last)
                {
                    ReadOnlySpan<char> __tmp58_line = __tmp58Reader.ReadLine();
                    __tmp58_last = __tmp58Reader.EndOfStream;
                    if (!__tmp58_last || !__tmp58_line.IsEmpty)
                    {
                        __out.Write(__tmp58_line);
                        __tmp55_outputWritten = true;
                    }
                    if (!__tmp58_last) __out.AppendLine(true);
                }
                string __tmp59_line = " = typeof("; //366:19
                if (!string.IsNullOrEmpty(__tmp59_line))
                {
                    __out.Write(__tmp59_line);
                    __tmp55_outputWritten = true;
                }
                var __tmp60 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp60.Write(((Type)value).FullName);
                var __tmp60Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp60.ToStringAndFree());
                bool __tmp60_last = __tmp60Reader.EndOfStream;
                while(!__tmp60_last)
                {
                    ReadOnlySpan<char> __tmp60_line = __tmp60Reader.ReadLine();
                    __tmp60_last = __tmp60Reader.EndOfStream;
                    if (!__tmp60_last || !__tmp60_line.IsEmpty)
                    {
                        __out.Write(__tmp60_line);
                        __tmp55_outputWritten = true;
                    }
                    if (!__tmp60_last) __out.AppendLine(true);
                }
                string __tmp61_line = ");"; //366:53
                if (!string.IsNullOrEmpty(__tmp61_line))
                {
                    __out.Write(__tmp61_line);
                    __tmp55_outputWritten = true;
                }
                if (__tmp55_outputWritten) __out.AppendLine(true);
                if (__tmp55_outputWritten)
                {
                    __out.AppendLine(false); //366:55
                }
            }
            else if (value is MetaExternalType) //367:2
            {
                bool __tmp63_outputWritten = false;
                var __tmp64 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp64.Write(name);
                var __tmp64Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp64.ToStringAndFree());
                bool __tmp64_last = __tmp64Reader.EndOfStream;
                while(!__tmp64_last)
                {
                    ReadOnlySpan<char> __tmp64_line = __tmp64Reader.ReadLine();
                    __tmp64_last = __tmp64Reader.EndOfStream;
                    if (!__tmp64_last || !__tmp64_line.IsEmpty)
                    {
                        __out.Write(__tmp64_line);
                        __tmp63_outputWritten = true;
                    }
                    if (!__tmp64_last) __out.AppendLine(true);
                }
                string __tmp65_line = ".Set"; //368:7
                if (!string.IsNullOrEmpty(__tmp65_line))
                {
                    __out.Write(__tmp65_line);
                    __tmp63_outputWritten = true;
                }
                var __tmp66 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp66.Write(prop.Name);
                var __tmp66Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp66.ToStringAndFree());
                bool __tmp66_last = __tmp66Reader.EndOfStream;
                while(!__tmp66_last)
                {
                    ReadOnlySpan<char> __tmp66_line = __tmp66Reader.ReadLine();
                    __tmp66_last = __tmp66Reader.EndOfStream;
                    if (!__tmp66_last || !__tmp66_line.IsEmpty)
                    {
                        __out.Write(__tmp66_line);
                        __tmp63_outputWritten = true;
                    }
                    if (!__tmp66_last) __out.AppendLine(true);
                }
                string __tmp67_line = "Lazy(() => "; //368:22
                if (!string.IsNullOrEmpty(__tmp67_line))
                {
                    __out.Write(__tmp67_line);
                    __tmp63_outputWritten = true;
                }
                var __tmp68 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp68.Write(ToPascalCase(((MetaExternalType)value).Name));
                var __tmp68Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp68.ToStringAndFree());
                bool __tmp68_last = __tmp68Reader.EndOfStream;
                while(!__tmp68_last)
                {
                    ReadOnlySpan<char> __tmp68_line = __tmp68Reader.ReadLine();
                    __tmp68_last = __tmp68Reader.EndOfStream;
                    if (!__tmp68_last || !__tmp68_line.IsEmpty)
                    {
                        __out.Write(__tmp68_line);
                        __tmp63_outputWritten = true;
                    }
                    if (!__tmp68_last) __out.AppendLine(true);
                }
                string __tmp69_line = ");"; //368:80
                if (!string.IsNullOrEmpty(__tmp69_line))
                {
                    __out.Write(__tmp69_line);
                    __tmp63_outputWritten = true;
                }
                if (__tmp63_outputWritten) __out.AppendLine(true);
                if (__tmp63_outputWritten)
                {
                    __out.AppendLine(false); //368:82
                }
            }
            else if (value is MetaPrimitiveType) //369:2
            {
                if (metaMetaModel) //370:3
                {
                    bool __tmp71_outputWritten = false;
                    var __tmp72 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp72.Write(name);
                    var __tmp72Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp72.ToStringAndFree());
                    bool __tmp72_last = __tmp72Reader.EndOfStream;
                    while(!__tmp72_last)
                    {
                        ReadOnlySpan<char> __tmp72_line = __tmp72Reader.ReadLine();
                        __tmp72_last = __tmp72Reader.EndOfStream;
                        if (!__tmp72_last || !__tmp72_line.IsEmpty)
                        {
                            __out.Write(__tmp72_line);
                            __tmp71_outputWritten = true;
                        }
                        if (!__tmp72_last) __out.AppendLine(true);
                    }
                    string __tmp73_line = ".Set"; //371:7
                    if (!string.IsNullOrEmpty(__tmp73_line))
                    {
                        __out.Write(__tmp73_line);
                        __tmp71_outputWritten = true;
                    }
                    var __tmp74 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp74.Write(prop.Name);
                    var __tmp74Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp74.ToStringAndFree());
                    bool __tmp74_last = __tmp74Reader.EndOfStream;
                    while(!__tmp74_last)
                    {
                        ReadOnlySpan<char> __tmp74_line = __tmp74Reader.ReadLine();
                        __tmp74_last = __tmp74Reader.EndOfStream;
                        if (!__tmp74_last || !__tmp74_line.IsEmpty)
                        {
                            __out.Write(__tmp74_line);
                            __tmp71_outputWritten = true;
                        }
                        if (!__tmp74_last) __out.AppendLine(true);
                    }
                    string __tmp75_line = "Lazy(() => "; //371:22
                    if (!string.IsNullOrEmpty(__tmp75_line))
                    {
                        __out.Write(__tmp75_line);
                        __tmp71_outputWritten = true;
                    }
                    var __tmp76 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp76.Write(CSharpName(((MetaPrimitiveType)value), model, ClassKind.ImmutableInstance, false));
                    var __tmp76Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp76.ToStringAndFree());
                    bool __tmp76_last = __tmp76Reader.EndOfStream;
                    while(!__tmp76_last)
                    {
                        ReadOnlySpan<char> __tmp76_line = __tmp76Reader.ReadLine();
                        __tmp76_last = __tmp76Reader.EndOfStream;
                        if (!__tmp76_last || !__tmp76_line.IsEmpty)
                        {
                            __out.Write(__tmp76_line);
                            __tmp71_outputWritten = true;
                        }
                        if (!__tmp76_last) __out.AppendLine(true);
                    }
                    string __tmp77_line = ");"; //371:115
                    if (!string.IsNullOrEmpty(__tmp77_line))
                    {
                        __out.Write(__tmp77_line);
                        __tmp71_outputWritten = true;
                    }
                    if (__tmp71_outputWritten) __out.AppendLine(true);
                    if (__tmp71_outputWritten)
                    {
                        __out.AppendLine(false); //371:117
                    }
                }
                else //372:3
                {
                    bool __tmp79_outputWritten = false;
                    var __tmp80 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp80.Write(name);
                    var __tmp80Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp80.ToStringAndFree());
                    bool __tmp80_last = __tmp80Reader.EndOfStream;
                    while(!__tmp80_last)
                    {
                        ReadOnlySpan<char> __tmp80_line = __tmp80Reader.ReadLine();
                        __tmp80_last = __tmp80Reader.EndOfStream;
                        if (!__tmp80_last || !__tmp80_line.IsEmpty)
                        {
                            __out.Write(__tmp80_line);
                            __tmp79_outputWritten = true;
                        }
                        if (!__tmp80_last) __out.AppendLine(true);
                    }
                    string __tmp81_line = ".Set"; //373:7
                    if (!string.IsNullOrEmpty(__tmp81_line))
                    {
                        __out.Write(__tmp81_line);
                        __tmp79_outputWritten = true;
                    }
                    var __tmp82 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp82.Write(prop.Name);
                    var __tmp82Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp82.ToStringAndFree());
                    bool __tmp82_last = __tmp82Reader.EndOfStream;
                    while(!__tmp82_last)
                    {
                        ReadOnlySpan<char> __tmp82_line = __tmp82Reader.ReadLine();
                        __tmp82_last = __tmp82Reader.EndOfStream;
                        if (!__tmp82_last || !__tmp82_line.IsEmpty)
                        {
                            __out.Write(__tmp82_line);
                            __tmp79_outputWritten = true;
                        }
                        if (!__tmp82_last) __out.AppendLine(true);
                    }
                    string __tmp83_line = "Lazy(() => "; //373:22
                    if (!string.IsNullOrEmpty(__tmp83_line))
                    {
                        __out.Write(__tmp83_line);
                        __tmp79_outputWritten = true;
                    }
                    var __tmp84 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp84.Write(CSharpName(((MetaPrimitiveType)value), model, ClassKind.ImmutableInstance, true));
                    var __tmp84Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp84.ToStringAndFree());
                    bool __tmp84_last = __tmp84Reader.EndOfStream;
                    while(!__tmp84_last)
                    {
                        ReadOnlySpan<char> __tmp84_line = __tmp84Reader.ReadLine();
                        __tmp84_last = __tmp84Reader.EndOfStream;
                        if (!__tmp84_last || !__tmp84_line.IsEmpty)
                        {
                            __out.Write(__tmp84_line);
                            __tmp79_outputWritten = true;
                        }
                        if (!__tmp84_last) __out.AppendLine(true);
                    }
                    string __tmp85_line = ".ToMutable());"; //373:114
                    if (!string.IsNullOrEmpty(__tmp85_line))
                    {
                        __out.Write(__tmp85_line);
                        __tmp79_outputWritten = true;
                    }
                    if (__tmp79_outputWritten) __out.AppendLine(true);
                    if (__tmp79_outputWritten)
                    {
                        __out.AppendLine(false); //373:128
                    }
                }
            }
            else if (valueObject != null && instanceNames.ContainsKey(valueObject)) //375:2
            {
                bool __tmp87_outputWritten = false;
                var __tmp88 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp88.Write(name);
                var __tmp88Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp88.ToStringAndFree());
                bool __tmp88_last = __tmp88Reader.EndOfStream;
                while(!__tmp88_last)
                {
                    ReadOnlySpan<char> __tmp88_line = __tmp88Reader.ReadLine();
                    __tmp88_last = __tmp88Reader.EndOfStream;
                    if (!__tmp88_last || !__tmp88_line.IsEmpty)
                    {
                        __out.Write(__tmp88_line);
                        __tmp87_outputWritten = true;
                    }
                    if (!__tmp88_last) __out.AppendLine(true);
                }
                string __tmp89_line = ".Set"; //376:7
                if (!string.IsNullOrEmpty(__tmp89_line))
                {
                    __out.Write(__tmp89_line);
                    __tmp87_outputWritten = true;
                }
                var __tmp90 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp90.Write(prop.Name);
                var __tmp90Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp90.ToStringAndFree());
                bool __tmp90_last = __tmp90Reader.EndOfStream;
                while(!__tmp90_last)
                {
                    ReadOnlySpan<char> __tmp90_line = __tmp90Reader.ReadLine();
                    __tmp90_last = __tmp90Reader.EndOfStream;
                    if (!__tmp90_last || !__tmp90_line.IsEmpty)
                    {
                        __out.Write(__tmp90_line);
                        __tmp87_outputWritten = true;
                    }
                    if (!__tmp90_last) __out.AppendLine(true);
                }
                string __tmp91_line = "Lazy(() => "; //376:22
                if (!string.IsNullOrEmpty(__tmp91_line))
                {
                    __out.Write(__tmp91_line);
                    __tmp87_outputWritten = true;
                }
                var __tmp92 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp92.Write(instanceNames[valueObject]);
                var __tmp92Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp92.ToStringAndFree());
                bool __tmp92_last = __tmp92Reader.EndOfStream;
                while(!__tmp92_last)
                {
                    ReadOnlySpan<char> __tmp92_line = __tmp92Reader.ReadLine();
                    __tmp92_last = __tmp92Reader.EndOfStream;
                    if (!__tmp92_last || !__tmp92_line.IsEmpty)
                    {
                        __out.Write(__tmp92_line);
                        __tmp87_outputWritten = true;
                    }
                    if (!__tmp92_last) __out.AppendLine(true);
                }
                string __tmp93_line = ");"; //376:61
                if (!string.IsNullOrEmpty(__tmp93_line))
                {
                    __out.Write(__tmp93_line);
                    __tmp87_outputWritten = true;
                }
                if (__tmp87_outputWritten) __out.AppendLine(true);
                if (__tmp87_outputWritten)
                {
                    __out.AppendLine(false); //376:63
                }
            }
            else if (valueDecl != null && valueDecl is MetaType) //377:2
            {
                bool __tmp95_outputWritten = false;
                var __tmp96 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp96.Write(name);
                var __tmp96Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp96.ToStringAndFree());
                bool __tmp96_last = __tmp96Reader.EndOfStream;
                while(!__tmp96_last)
                {
                    ReadOnlySpan<char> __tmp96_line = __tmp96Reader.ReadLine();
                    __tmp96_last = __tmp96Reader.EndOfStream;
                    if (!__tmp96_last || !__tmp96_line.IsEmpty)
                    {
                        __out.Write(__tmp96_line);
                        __tmp95_outputWritten = true;
                    }
                    if (!__tmp96_last) __out.AppendLine(true);
                }
                string __tmp97_line = ".Set"; //378:7
                if (!string.IsNullOrEmpty(__tmp97_line))
                {
                    __out.Write(__tmp97_line);
                    __tmp95_outputWritten = true;
                }
                var __tmp98 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp98.Write(prop.Name);
                var __tmp98Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp98.ToStringAndFree());
                bool __tmp98_last = __tmp98Reader.EndOfStream;
                while(!__tmp98_last)
                {
                    ReadOnlySpan<char> __tmp98_line = __tmp98Reader.ReadLine();
                    __tmp98_last = __tmp98Reader.EndOfStream;
                    if (!__tmp98_last || !__tmp98_line.IsEmpty)
                    {
                        __out.Write(__tmp98_line);
                        __tmp95_outputWritten = true;
                    }
                    if (!__tmp98_last) __out.AppendLine(true);
                }
                string __tmp99_line = "Lazy(() => "; //378:22
                if (!string.IsNullOrEmpty(__tmp99_line))
                {
                    __out.Write(__tmp99_line);
                    __tmp95_outputWritten = true;
                }
                var __tmp100 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp100.Write(CSharpName(((MetaType)valueDecl), model, ClassKind.ImmutableInstance, true));
                var __tmp100Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp100.ToStringAndFree());
                bool __tmp100_last = __tmp100Reader.EndOfStream;
                while(!__tmp100_last)
                {
                    ReadOnlySpan<char> __tmp100_line = __tmp100Reader.ReadLine();
                    __tmp100_last = __tmp100Reader.EndOfStream;
                    if (!__tmp100_last || !__tmp100_line.IsEmpty)
                    {
                        __out.Write(__tmp100_line);
                        __tmp95_outputWritten = true;
                    }
                    if (!__tmp100_last) __out.AppendLine(true);
                }
                string __tmp101_line = ");"; //378:109
                if (!string.IsNullOrEmpty(__tmp101_line))
                {
                    __out.Write(__tmp101_line);
                    __tmp95_outputWritten = true;
                }
                if (__tmp95_outputWritten) __out.AppendLine(true);
                if (__tmp95_outputWritten)
                {
                    __out.AppendLine(false); //378:111
                }
            }
            else if (valueDecl != null && valueDecl is MetaConstant) //379:2
            {
                bool __tmp103_outputWritten = false;
                var __tmp104 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp104.Write(name);
                var __tmp104Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp104.ToStringAndFree());
                bool __tmp104_last = __tmp104Reader.EndOfStream;
                while(!__tmp104_last)
                {
                    ReadOnlySpan<char> __tmp104_line = __tmp104Reader.ReadLine();
                    __tmp104_last = __tmp104Reader.EndOfStream;
                    if (!__tmp104_last || !__tmp104_line.IsEmpty)
                    {
                        __out.Write(__tmp104_line);
                        __tmp103_outputWritten = true;
                    }
                    if (!__tmp104_last) __out.AppendLine(true);
                }
                string __tmp105_line = ".Set"; //380:7
                if (!string.IsNullOrEmpty(__tmp105_line))
                {
                    __out.Write(__tmp105_line);
                    __tmp103_outputWritten = true;
                }
                var __tmp106 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp106.Write(prop.Name);
                var __tmp106Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp106.ToStringAndFree());
                bool __tmp106_last = __tmp106Reader.EndOfStream;
                while(!__tmp106_last)
                {
                    ReadOnlySpan<char> __tmp106_line = __tmp106Reader.ReadLine();
                    __tmp106_last = __tmp106Reader.EndOfStream;
                    if (!__tmp106_last || !__tmp106_line.IsEmpty)
                    {
                        __out.Write(__tmp106_line);
                        __tmp103_outputWritten = true;
                    }
                    if (!__tmp106_last) __out.AppendLine(true);
                }
                string __tmp107_line = "Lazy(() => "; //380:22
                if (!string.IsNullOrEmpty(__tmp107_line))
                {
                    __out.Write(__tmp107_line);
                    __tmp103_outputWritten = true;
                }
                var __tmp108 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp108.Write(CSharpName(((MetaConstant)valueDecl), model, ClassKind.ImmutableInstance, true));
                var __tmp108Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp108.ToStringAndFree());
                bool __tmp108_last = __tmp108Reader.EndOfStream;
                while(!__tmp108_last)
                {
                    ReadOnlySpan<char> __tmp108_line = __tmp108Reader.ReadLine();
                    __tmp108_last = __tmp108Reader.EndOfStream;
                    if (!__tmp108_last || !__tmp108_line.IsEmpty)
                    {
                        __out.Write(__tmp108_line);
                        __tmp103_outputWritten = true;
                    }
                    if (!__tmp108_last) __out.AppendLine(true);
                }
                string __tmp109_line = ");"; //380:113
                if (!string.IsNullOrEmpty(__tmp109_line))
                {
                    __out.Write(__tmp109_line);
                    __tmp103_outputWritten = true;
                }
                if (__tmp103_outputWritten) __out.AppendLine(true);
                if (__tmp103_outputWritten)
                {
                    __out.AppendLine(false); //380:115
                }
            }
            else if (valueCollection != null) //381:2
            {
                var __loop21_results = 
                    (from cvalue in __Enumerate((valueCollection).GetEnumerator()) //382:8
                    select new { cvalue = cvalue}
                    ).ToList(); //382:3
                for (int __loop21_iteration = 0; __loop21_iteration < __loop21_results.Count; ++__loop21_iteration)
                {
                    var __tmp110 = __loop21_results[__loop21_iteration];
                    var cvalue = __tmp110.cvalue;
                    bool __tmp112_outputWritten = false;
                    var __tmp113 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp113.Write(GenerateInstancePropertyCollectionValue(model, metaMetaModel, obj, prop, cvalue, instanceNames));
                    var __tmp113Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp113.ToStringAndFree());
                    bool __tmp113_last = __tmp113Reader.EndOfStream;
                    while(!__tmp113_last)
                    {
                        ReadOnlySpan<char> __tmp113_line = __tmp113Reader.ReadLine();
                        __tmp113_last = __tmp113Reader.EndOfStream;
                        if (!__tmp113_last || !__tmp113_line.IsEmpty)
                        {
                            __out.Write(__tmp113_line);
                            __tmp112_outputWritten = true;
                        }
                        if (!__tmp113_last || __tmp112_outputWritten) __out.AppendLine(true);
                    }
                    if (__tmp112_outputWritten)
                    {
                        __out.AppendLine(false); //383:98
                    }
                }
            }
            else //385:2
            {
                bool __tmp115_outputWritten = false;
                string __tmp116_line = "// TODO: "; //386:1
                if (!string.IsNullOrEmpty(__tmp116_line))
                {
                    __out.Write(__tmp116_line);
                    __tmp115_outputWritten = true;
                }
                var __tmp117 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp117.Write(name);
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
                string __tmp118_line = "."; //386:16
                if (!string.IsNullOrEmpty(__tmp118_line))
                {
                    __out.Write(__tmp118_line);
                    __tmp115_outputWritten = true;
                }
                var __tmp119 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp119.Write(prop.Name);
                var __tmp119Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp119.ToStringAndFree());
                bool __tmp119_last = __tmp119Reader.EndOfStream;
                while(!__tmp119_last)
                {
                    ReadOnlySpan<char> __tmp119_line = __tmp119Reader.ReadLine();
                    __tmp119_last = __tmp119Reader.EndOfStream;
                    if (!__tmp119_last || !__tmp119_line.IsEmpty)
                    {
                        __out.Write(__tmp119_line);
                        __tmp115_outputWritten = true;
                    }
                    if (!__tmp119_last || __tmp115_outputWritten) __out.AppendLine(true);
                }
                if (__tmp115_outputWritten)
                {
                    __out.AppendLine(false); //386:28
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateInstancePropertyCollectionValue(MetaModel model, bool metaMetaModel, ImmutableObject obj, ModelProperty prop, object value, ImmutableDictionary<ImmutableObject,string> instanceNames) //390:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string name = instanceNames[obj]; //391:2
            ImmutableObject valueObject = value as ImmutableObject; //392:2
            MetaDeclaration valueDecl = value as MetaDeclaration; //393:2
            IEnumerable<object> valueCollection = value as IEnumerable<object>; //394:2
            if (value == null) //395:2
            {
                if (prop.MutableType != null && prop.MutableType.IsClass) //396:3
                {
                    bool __tmp2_outputWritten = false;
                    var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp3.Write(name);
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
                        if (!__tmp3_last) __out.AppendLine(true);
                    }
                    string __tmp4_line = "."; //397:7
                    if (!string.IsNullOrEmpty(__tmp4_line))
                    {
                        __out.Write(__tmp4_line);
                        __tmp2_outputWritten = true;
                    }
                    var __tmp5 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp5.Write(prop.Name);
                    var __tmp5Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp5.ToStringAndFree());
                    bool __tmp5_last = __tmp5Reader.EndOfStream;
                    while(!__tmp5_last)
                    {
                        ReadOnlySpan<char> __tmp5_line = __tmp5Reader.ReadLine();
                        __tmp5_last = __tmp5Reader.EndOfStream;
                        if (!__tmp5_last || !__tmp5_line.IsEmpty)
                        {
                            __out.Write(__tmp5_line);
                            __tmp2_outputWritten = true;
                        }
                        if (!__tmp5_last) __out.AppendLine(true);
                    }
                    string __tmp6_line = ".Add(null);"; //397:19
                    if (!string.IsNullOrEmpty(__tmp6_line))
                    {
                        __out.Write(__tmp6_line);
                        __tmp2_outputWritten = true;
                    }
                    if (__tmp2_outputWritten) __out.AppendLine(true);
                    if (__tmp2_outputWritten)
                    {
                        __out.AppendLine(false); //397:30
                    }
                }
                else //398:3
                {
                    bool __tmp8_outputWritten = false;
                    string __tmp9_line = "// "; //399:1
                    if (!string.IsNullOrEmpty(__tmp9_line))
                    {
                        __out.Write(__tmp9_line);
                        __tmp8_outputWritten = true;
                    }
                    var __tmp10 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp10.Write(name);
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
                    string __tmp11_line = "."; //399:10
                    if (!string.IsNullOrEmpty(__tmp11_line))
                    {
                        __out.Write(__tmp11_line);
                        __tmp8_outputWritten = true;
                    }
                    var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp12.Write(prop.Name);
                    var __tmp12Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp12.ToStringAndFree());
                    bool __tmp12_last = __tmp12Reader.EndOfStream;
                    while(!__tmp12_last)
                    {
                        ReadOnlySpan<char> __tmp12_line = __tmp12Reader.ReadLine();
                        __tmp12_last = __tmp12Reader.EndOfStream;
                        if (!__tmp12_last || !__tmp12_line.IsEmpty)
                        {
                            __out.Write(__tmp12_line);
                            __tmp8_outputWritten = true;
                        }
                        if (!__tmp12_last) __out.AppendLine(true);
                    }
                    string __tmp13_line = ".Add(null);"; //399:22
                    if (!string.IsNullOrEmpty(__tmp13_line))
                    {
                        __out.Write(__tmp13_line);
                        __tmp8_outputWritten = true;
                    }
                    if (__tmp8_outputWritten) __out.AppendLine(true);
                    if (__tmp8_outputWritten)
                    {
                        __out.AppendLine(false); //399:33
                    }
                }
            }
            else if (value is string) //401:2
            {
                bool __tmp15_outputWritten = false;
                var __tmp16 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp16.Write(name);
                var __tmp16Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp16.ToStringAndFree());
                bool __tmp16_last = __tmp16Reader.EndOfStream;
                while(!__tmp16_last)
                {
                    ReadOnlySpan<char> __tmp16_line = __tmp16Reader.ReadLine();
                    __tmp16_last = __tmp16Reader.EndOfStream;
                    if (!__tmp16_last || !__tmp16_line.IsEmpty)
                    {
                        __out.Write(__tmp16_line);
                        __tmp15_outputWritten = true;
                    }
                    if (!__tmp16_last) __out.AppendLine(true);
                }
                string __tmp17_line = "."; //402:7
                if (!string.IsNullOrEmpty(__tmp17_line))
                {
                    __out.Write(__tmp17_line);
                    __tmp15_outputWritten = true;
                }
                var __tmp18 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp18.Write(prop.Name);
                var __tmp18Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp18.ToStringAndFree());
                bool __tmp18_last = __tmp18Reader.EndOfStream;
                while(!__tmp18_last)
                {
                    ReadOnlySpan<char> __tmp18_line = __tmp18Reader.ReadLine();
                    __tmp18_last = __tmp18Reader.EndOfStream;
                    if (!__tmp18_last || !__tmp18_line.IsEmpty)
                    {
                        __out.Write(__tmp18_line);
                        __tmp15_outputWritten = true;
                    }
                    if (!__tmp18_last) __out.AppendLine(true);
                }
                string __tmp19_line = ".Add(\""; //402:19
                if (!string.IsNullOrEmpty(__tmp19_line))
                {
                    __out.Write(__tmp19_line);
                    __tmp15_outputWritten = true;
                }
                var __tmp20 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp20.Write(EscapeText((string)value));
                var __tmp20Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp20.ToStringAndFree());
                bool __tmp20_last = __tmp20Reader.EndOfStream;
                while(!__tmp20_last)
                {
                    ReadOnlySpan<char> __tmp20_line = __tmp20Reader.ReadLine();
                    __tmp20_last = __tmp20Reader.EndOfStream;
                    if (!__tmp20_last || !__tmp20_line.IsEmpty)
                    {
                        __out.Write(__tmp20_line);
                        __tmp15_outputWritten = true;
                    }
                    if (!__tmp20_last) __out.AppendLine(true);
                }
                string __tmp21_line = "\");"; //402:52
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Write(__tmp21_line);
                    __tmp15_outputWritten = true;
                }
                if (__tmp15_outputWritten) __out.AppendLine(true);
                if (__tmp15_outputWritten)
                {
                    __out.AppendLine(false); //402:55
                }
            }
            else if (value is bool) //403:2
            {
                bool __tmp23_outputWritten = false;
                var __tmp24 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp24.Write(name);
                var __tmp24Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp24.ToStringAndFree());
                bool __tmp24_last = __tmp24Reader.EndOfStream;
                while(!__tmp24_last)
                {
                    ReadOnlySpan<char> __tmp24_line = __tmp24Reader.ReadLine();
                    __tmp24_last = __tmp24Reader.EndOfStream;
                    if (!__tmp24_last || !__tmp24_line.IsEmpty)
                    {
                        __out.Write(__tmp24_line);
                        __tmp23_outputWritten = true;
                    }
                    if (!__tmp24_last) __out.AppendLine(true);
                }
                string __tmp25_line = "."; //404:7
                if (!string.IsNullOrEmpty(__tmp25_line))
                {
                    __out.Write(__tmp25_line);
                    __tmp23_outputWritten = true;
                }
                var __tmp26 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp26.Write(prop.Name);
                var __tmp26Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp26.ToStringAndFree());
                bool __tmp26_last = __tmp26Reader.EndOfStream;
                while(!__tmp26_last)
                {
                    ReadOnlySpan<char> __tmp26_line = __tmp26Reader.ReadLine();
                    __tmp26_last = __tmp26Reader.EndOfStream;
                    if (!__tmp26_last || !__tmp26_line.IsEmpty)
                    {
                        __out.Write(__tmp26_line);
                        __tmp23_outputWritten = true;
                    }
                    if (!__tmp26_last) __out.AppendLine(true);
                }
                string __tmp27_line = ".Add("; //404:19
                if (!string.IsNullOrEmpty(__tmp27_line))
                {
                    __out.Write(__tmp27_line);
                    __tmp23_outputWritten = true;
                }
                var __tmp28 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp28.Write(value.ToString().ToLower());
                var __tmp28Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp28.ToStringAndFree());
                bool __tmp28_last = __tmp28Reader.EndOfStream;
                while(!__tmp28_last)
                {
                    ReadOnlySpan<char> __tmp28_line = __tmp28Reader.ReadLine();
                    __tmp28_last = __tmp28Reader.EndOfStream;
                    if (!__tmp28_last || !__tmp28_line.IsEmpty)
                    {
                        __out.Write(__tmp28_line);
                        __tmp23_outputWritten = true;
                    }
                    if (!__tmp28_last) __out.AppendLine(true);
                }
                string __tmp29_line = ");"; //404:52
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Write(__tmp29_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //404:54
                }
            }
            else if (value.GetType().IsPrimitive) //405:2
            {
                bool __tmp31_outputWritten = false;
                var __tmp32 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp32.Write(name);
                var __tmp32Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp32.ToStringAndFree());
                bool __tmp32_last = __tmp32Reader.EndOfStream;
                while(!__tmp32_last)
                {
                    ReadOnlySpan<char> __tmp32_line = __tmp32Reader.ReadLine();
                    __tmp32_last = __tmp32Reader.EndOfStream;
                    if (!__tmp32_last || !__tmp32_line.IsEmpty)
                    {
                        __out.Write(__tmp32_line);
                        __tmp31_outputWritten = true;
                    }
                    if (!__tmp32_last) __out.AppendLine(true);
                }
                string __tmp33_line = "."; //406:7
                if (!string.IsNullOrEmpty(__tmp33_line))
                {
                    __out.Write(__tmp33_line);
                    __tmp31_outputWritten = true;
                }
                var __tmp34 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp34.Write(prop.Name);
                var __tmp34Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp34.ToStringAndFree());
                bool __tmp34_last = __tmp34Reader.EndOfStream;
                while(!__tmp34_last)
                {
                    ReadOnlySpan<char> __tmp34_line = __tmp34Reader.ReadLine();
                    __tmp34_last = __tmp34Reader.EndOfStream;
                    if (!__tmp34_last || !__tmp34_line.IsEmpty)
                    {
                        __out.Write(__tmp34_line);
                        __tmp31_outputWritten = true;
                    }
                    if (!__tmp34_last) __out.AppendLine(true);
                }
                string __tmp35_line = ".Add("; //406:19
                if (!string.IsNullOrEmpty(__tmp35_line))
                {
                    __out.Write(__tmp35_line);
                    __tmp31_outputWritten = true;
                }
                var __tmp36 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp36.Write(value.ToString());
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
                string __tmp37_line = ");"; //406:42
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Write(__tmp37_line);
                    __tmp31_outputWritten = true;
                }
                if (__tmp31_outputWritten) __out.AppendLine(true);
                if (__tmp31_outputWritten)
                {
                    __out.AppendLine(false); //406:44
                }
            }
            else if (value is MetaAttribute) //407:2
            {
                bool __tmp39_outputWritten = false;
                var __tmp40 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp40.Write(name);
                var __tmp40Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp40.ToStringAndFree());
                bool __tmp40_last = __tmp40Reader.EndOfStream;
                while(!__tmp40_last)
                {
                    ReadOnlySpan<char> __tmp40_line = __tmp40Reader.ReadLine();
                    __tmp40_last = __tmp40Reader.EndOfStream;
                    if (!__tmp40_last || !__tmp40_line.IsEmpty)
                    {
                        __out.Write(__tmp40_line);
                        __tmp39_outputWritten = true;
                    }
                    if (!__tmp40_last) __out.AppendLine(true);
                }
                string __tmp41_line = "."; //408:7
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Write(__tmp41_line);
                    __tmp39_outputWritten = true;
                }
                var __tmp42 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp42.Write(prop.Name);
                var __tmp42Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp42.ToStringAndFree());
                bool __tmp42_last = __tmp42Reader.EndOfStream;
                while(!__tmp42_last)
                {
                    ReadOnlySpan<char> __tmp42_line = __tmp42Reader.ReadLine();
                    __tmp42_last = __tmp42Reader.EndOfStream;
                    if (!__tmp42_last || !__tmp42_line.IsEmpty)
                    {
                        __out.Write(__tmp42_line);
                        __tmp39_outputWritten = true;
                    }
                    if (!__tmp42_last) __out.AppendLine(true);
                }
                string __tmp43_line = ".Add("; //408:19
                if (!string.IsNullOrEmpty(__tmp43_line))
                {
                    __out.Write(__tmp43_line);
                    __tmp39_outputWritten = true;
                }
                var __tmp44 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp44.Write(GetAttributeValueOf(model, (MetaAttribute)value));
                var __tmp44Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp44.ToStringAndFree());
                bool __tmp44_last = __tmp44Reader.EndOfStream;
                while(!__tmp44_last)
                {
                    ReadOnlySpan<char> __tmp44_line = __tmp44Reader.ReadLine();
                    __tmp44_last = __tmp44Reader.EndOfStream;
                    if (!__tmp44_last || !__tmp44_line.IsEmpty)
                    {
                        __out.Write(__tmp44_line);
                        __tmp39_outputWritten = true;
                    }
                    if (!__tmp44_last) __out.AppendLine(true);
                }
                string __tmp45_line = ");"; //408:74
                if (!string.IsNullOrEmpty(__tmp45_line))
                {
                    __out.Write(__tmp45_line);
                    __tmp39_outputWritten = true;
                }
                if (__tmp39_outputWritten) __out.AppendLine(true);
                if (__tmp39_outputWritten)
                {
                    __out.AppendLine(false); //408:76
                }
            }
            else if (value is Enum) //409:2
            {
                bool __tmp47_outputWritten = false;
                var __tmp48 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp48.Write(name);
                var __tmp48Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp48.ToStringAndFree());
                bool __tmp48_last = __tmp48Reader.EndOfStream;
                while(!__tmp48_last)
                {
                    ReadOnlySpan<char> __tmp48_line = __tmp48Reader.ReadLine();
                    __tmp48_last = __tmp48Reader.EndOfStream;
                    if (!__tmp48_last || !__tmp48_line.IsEmpty)
                    {
                        __out.Write(__tmp48_line);
                        __tmp47_outputWritten = true;
                    }
                    if (!__tmp48_last) __out.AppendLine(true);
                }
                string __tmp49_line = "."; //410:7
                if (!string.IsNullOrEmpty(__tmp49_line))
                {
                    __out.Write(__tmp49_line);
                    __tmp47_outputWritten = true;
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
                        __tmp47_outputWritten = true;
                    }
                    if (!__tmp50_last) __out.AppendLine(true);
                }
                string __tmp51_line = ".Add("; //410:19
                if (!string.IsNullOrEmpty(__tmp51_line))
                {
                    __out.Write(__tmp51_line);
                    __tmp47_outputWritten = true;
                }
                var __tmp52 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp52.Write(GetEnumValueOf(model, (Enum)value));
                var __tmp52Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp52.ToStringAndFree());
                bool __tmp52_last = __tmp52Reader.EndOfStream;
                while(!__tmp52_last)
                {
                    ReadOnlySpan<char> __tmp52_line = __tmp52Reader.ReadLine();
                    __tmp52_last = __tmp52Reader.EndOfStream;
                    if (!__tmp52_last || !__tmp52_line.IsEmpty)
                    {
                        __out.Write(__tmp52_line);
                        __tmp47_outputWritten = true;
                    }
                    if (!__tmp52_last) __out.AppendLine(true);
                }
                string __tmp53_line = ");"; //410:60
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Write(__tmp53_line);
                    __tmp47_outputWritten = true;
                }
                if (__tmp47_outputWritten) __out.AppendLine(true);
                if (__tmp47_outputWritten)
                {
                    __out.AppendLine(false); //410:62
                }
            }
            else if (value is Type) //411:2
            {
                bool __tmp55_outputWritten = false;
                var __tmp56 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp56.Write(name);
                var __tmp56Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp56.ToStringAndFree());
                bool __tmp56_last = __tmp56Reader.EndOfStream;
                while(!__tmp56_last)
                {
                    ReadOnlySpan<char> __tmp56_line = __tmp56Reader.ReadLine();
                    __tmp56_last = __tmp56Reader.EndOfStream;
                    if (!__tmp56_last || !__tmp56_line.IsEmpty)
                    {
                        __out.Write(__tmp56_line);
                        __tmp55_outputWritten = true;
                    }
                    if (!__tmp56_last) __out.AppendLine(true);
                }
                string __tmp57_line = "."; //412:7
                if (!string.IsNullOrEmpty(__tmp57_line))
                {
                    __out.Write(__tmp57_line);
                    __tmp55_outputWritten = true;
                }
                var __tmp58 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp58.Write(prop.Name);
                var __tmp58Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp58.ToStringAndFree());
                bool __tmp58_last = __tmp58Reader.EndOfStream;
                while(!__tmp58_last)
                {
                    ReadOnlySpan<char> __tmp58_line = __tmp58Reader.ReadLine();
                    __tmp58_last = __tmp58Reader.EndOfStream;
                    if (!__tmp58_last || !__tmp58_line.IsEmpty)
                    {
                        __out.Write(__tmp58_line);
                        __tmp55_outputWritten = true;
                    }
                    if (!__tmp58_last) __out.AppendLine(true);
                }
                string __tmp59_line = " = typeof("; //412:19
                if (!string.IsNullOrEmpty(__tmp59_line))
                {
                    __out.Write(__tmp59_line);
                    __tmp55_outputWritten = true;
                }
                var __tmp60 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp60.Write(((Type)value).FullName);
                var __tmp60Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp60.ToStringAndFree());
                bool __tmp60_last = __tmp60Reader.EndOfStream;
                while(!__tmp60_last)
                {
                    ReadOnlySpan<char> __tmp60_line = __tmp60Reader.ReadLine();
                    __tmp60_last = __tmp60Reader.EndOfStream;
                    if (!__tmp60_last || !__tmp60_line.IsEmpty)
                    {
                        __out.Write(__tmp60_line);
                        __tmp55_outputWritten = true;
                    }
                    if (!__tmp60_last) __out.AppendLine(true);
                }
                string __tmp61_line = ");"; //412:53
                if (!string.IsNullOrEmpty(__tmp61_line))
                {
                    __out.Write(__tmp61_line);
                    __tmp55_outputWritten = true;
                }
                if (__tmp55_outputWritten) __out.AppendLine(true);
                if (__tmp55_outputWritten)
                {
                    __out.AppendLine(false); //412:55
                }
            }
            else if (value is MetaExternalType) //413:2
            {
                bool __tmp63_outputWritten = false;
                var __tmp64 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp64.Write(name);
                var __tmp64Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp64.ToStringAndFree());
                bool __tmp64_last = __tmp64Reader.EndOfStream;
                while(!__tmp64_last)
                {
                    ReadOnlySpan<char> __tmp64_line = __tmp64Reader.ReadLine();
                    __tmp64_last = __tmp64Reader.EndOfStream;
                    if (!__tmp64_last || !__tmp64_line.IsEmpty)
                    {
                        __out.Write(__tmp64_line);
                        __tmp63_outputWritten = true;
                    }
                    if (!__tmp64_last) __out.AppendLine(true);
                }
                string __tmp65_line = "."; //414:7
                if (!string.IsNullOrEmpty(__tmp65_line))
                {
                    __out.Write(__tmp65_line);
                    __tmp63_outputWritten = true;
                }
                var __tmp66 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp66.Write(prop.Name);
                var __tmp66Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp66.ToStringAndFree());
                bool __tmp66_last = __tmp66Reader.EndOfStream;
                while(!__tmp66_last)
                {
                    ReadOnlySpan<char> __tmp66_line = __tmp66Reader.ReadLine();
                    __tmp66_last = __tmp66Reader.EndOfStream;
                    if (!__tmp66_last || !__tmp66_line.IsEmpty)
                    {
                        __out.Write(__tmp66_line);
                        __tmp63_outputWritten = true;
                    }
                    if (!__tmp66_last) __out.AppendLine(true);
                }
                string __tmp67_line = ".AddLazy(() => "; //414:19
                if (!string.IsNullOrEmpty(__tmp67_line))
                {
                    __out.Write(__tmp67_line);
                    __tmp63_outputWritten = true;
                }
                var __tmp68 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp68.Write(ToPascalCase(((MetaExternalType)value).Name));
                var __tmp68Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp68.ToStringAndFree());
                bool __tmp68_last = __tmp68Reader.EndOfStream;
                while(!__tmp68_last)
                {
                    ReadOnlySpan<char> __tmp68_line = __tmp68Reader.ReadLine();
                    __tmp68_last = __tmp68Reader.EndOfStream;
                    if (!__tmp68_last || !__tmp68_line.IsEmpty)
                    {
                        __out.Write(__tmp68_line);
                        __tmp63_outputWritten = true;
                    }
                    if (!__tmp68_last) __out.AppendLine(true);
                }
                string __tmp69_line = ");"; //414:81
                if (!string.IsNullOrEmpty(__tmp69_line))
                {
                    __out.Write(__tmp69_line);
                    __tmp63_outputWritten = true;
                }
                if (__tmp63_outputWritten) __out.AppendLine(true);
                if (__tmp63_outputWritten)
                {
                    __out.AppendLine(false); //414:83
                }
            }
            else if (value is MetaPrimitiveType) //415:2
            {
                if (metaMetaModel) //416:3
                {
                    bool __tmp71_outputWritten = false;
                    var __tmp72 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp72.Write(name);
                    var __tmp72Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp72.ToStringAndFree());
                    bool __tmp72_last = __tmp72Reader.EndOfStream;
                    while(!__tmp72_last)
                    {
                        ReadOnlySpan<char> __tmp72_line = __tmp72Reader.ReadLine();
                        __tmp72_last = __tmp72Reader.EndOfStream;
                        if (!__tmp72_last || !__tmp72_line.IsEmpty)
                        {
                            __out.Write(__tmp72_line);
                            __tmp71_outputWritten = true;
                        }
                        if (!__tmp72_last) __out.AppendLine(true);
                    }
                    string __tmp73_line = "."; //417:7
                    if (!string.IsNullOrEmpty(__tmp73_line))
                    {
                        __out.Write(__tmp73_line);
                        __tmp71_outputWritten = true;
                    }
                    var __tmp74 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp74.Write(prop.Name);
                    var __tmp74Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp74.ToStringAndFree());
                    bool __tmp74_last = __tmp74Reader.EndOfStream;
                    while(!__tmp74_last)
                    {
                        ReadOnlySpan<char> __tmp74_line = __tmp74Reader.ReadLine();
                        __tmp74_last = __tmp74Reader.EndOfStream;
                        if (!__tmp74_last || !__tmp74_line.IsEmpty)
                        {
                            __out.Write(__tmp74_line);
                            __tmp71_outputWritten = true;
                        }
                        if (!__tmp74_last) __out.AppendLine(true);
                    }
                    string __tmp75_line = ".AddLazy(() => "; //417:19
                    if (!string.IsNullOrEmpty(__tmp75_line))
                    {
                        __out.Write(__tmp75_line);
                        __tmp71_outputWritten = true;
                    }
                    var __tmp76 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp76.Write(CSharpName(((MetaPrimitiveType)value), model, ClassKind.ImmutableInstance, false));
                    var __tmp76Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp76.ToStringAndFree());
                    bool __tmp76_last = __tmp76Reader.EndOfStream;
                    while(!__tmp76_last)
                    {
                        ReadOnlySpan<char> __tmp76_line = __tmp76Reader.ReadLine();
                        __tmp76_last = __tmp76Reader.EndOfStream;
                        if (!__tmp76_last || !__tmp76_line.IsEmpty)
                        {
                            __out.Write(__tmp76_line);
                            __tmp71_outputWritten = true;
                        }
                        if (!__tmp76_last) __out.AppendLine(true);
                    }
                    string __tmp77_line = ");"; //417:116
                    if (!string.IsNullOrEmpty(__tmp77_line))
                    {
                        __out.Write(__tmp77_line);
                        __tmp71_outputWritten = true;
                    }
                    if (__tmp71_outputWritten) __out.AppendLine(true);
                    if (__tmp71_outputWritten)
                    {
                        __out.AppendLine(false); //417:118
                    }
                }
                else //418:3
                {
                    bool __tmp79_outputWritten = false;
                    var __tmp80 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp80.Write(name);
                    var __tmp80Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp80.ToStringAndFree());
                    bool __tmp80_last = __tmp80Reader.EndOfStream;
                    while(!__tmp80_last)
                    {
                        ReadOnlySpan<char> __tmp80_line = __tmp80Reader.ReadLine();
                        __tmp80_last = __tmp80Reader.EndOfStream;
                        if (!__tmp80_last || !__tmp80_line.IsEmpty)
                        {
                            __out.Write(__tmp80_line);
                            __tmp79_outputWritten = true;
                        }
                        if (!__tmp80_last) __out.AppendLine(true);
                    }
                    string __tmp81_line = "."; //419:7
                    if (!string.IsNullOrEmpty(__tmp81_line))
                    {
                        __out.Write(__tmp81_line);
                        __tmp79_outputWritten = true;
                    }
                    var __tmp82 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp82.Write(prop.Name);
                    var __tmp82Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp82.ToStringAndFree());
                    bool __tmp82_last = __tmp82Reader.EndOfStream;
                    while(!__tmp82_last)
                    {
                        ReadOnlySpan<char> __tmp82_line = __tmp82Reader.ReadLine();
                        __tmp82_last = __tmp82Reader.EndOfStream;
                        if (!__tmp82_last || !__tmp82_line.IsEmpty)
                        {
                            __out.Write(__tmp82_line);
                            __tmp79_outputWritten = true;
                        }
                        if (!__tmp82_last) __out.AppendLine(true);
                    }
                    string __tmp83_line = ".AddLazy(() => "; //419:19
                    if (!string.IsNullOrEmpty(__tmp83_line))
                    {
                        __out.Write(__tmp83_line);
                        __tmp79_outputWritten = true;
                    }
                    var __tmp84 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp84.Write(CSharpName(((MetaPrimitiveType)value), model, ClassKind.ImmutableInstance, true));
                    var __tmp84Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp84.ToStringAndFree());
                    bool __tmp84_last = __tmp84Reader.EndOfStream;
                    while(!__tmp84_last)
                    {
                        ReadOnlySpan<char> __tmp84_line = __tmp84Reader.ReadLine();
                        __tmp84_last = __tmp84Reader.EndOfStream;
                        if (!__tmp84_last || !__tmp84_line.IsEmpty)
                        {
                            __out.Write(__tmp84_line);
                            __tmp79_outputWritten = true;
                        }
                        if (!__tmp84_last) __out.AppendLine(true);
                    }
                    string __tmp85_line = ".ToMutable());"; //419:115
                    if (!string.IsNullOrEmpty(__tmp85_line))
                    {
                        __out.Write(__tmp85_line);
                        __tmp79_outputWritten = true;
                    }
                    if (__tmp79_outputWritten) __out.AppendLine(true);
                    if (__tmp79_outputWritten)
                    {
                        __out.AppendLine(false); //419:129
                    }
                }
            }
            else if (valueObject != null && instanceNames.ContainsKey(valueObject)) //421:2
            {
                bool __tmp87_outputWritten = false;
                var __tmp88 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp88.Write(name);
                var __tmp88Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp88.ToStringAndFree());
                bool __tmp88_last = __tmp88Reader.EndOfStream;
                while(!__tmp88_last)
                {
                    ReadOnlySpan<char> __tmp88_line = __tmp88Reader.ReadLine();
                    __tmp88_last = __tmp88Reader.EndOfStream;
                    if (!__tmp88_last || !__tmp88_line.IsEmpty)
                    {
                        __out.Write(__tmp88_line);
                        __tmp87_outputWritten = true;
                    }
                    if (!__tmp88_last) __out.AppendLine(true);
                }
                string __tmp89_line = "."; //422:7
                if (!string.IsNullOrEmpty(__tmp89_line))
                {
                    __out.Write(__tmp89_line);
                    __tmp87_outputWritten = true;
                }
                var __tmp90 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp90.Write(prop.Name);
                var __tmp90Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp90.ToStringAndFree());
                bool __tmp90_last = __tmp90Reader.EndOfStream;
                while(!__tmp90_last)
                {
                    ReadOnlySpan<char> __tmp90_line = __tmp90Reader.ReadLine();
                    __tmp90_last = __tmp90Reader.EndOfStream;
                    if (!__tmp90_last || !__tmp90_line.IsEmpty)
                    {
                        __out.Write(__tmp90_line);
                        __tmp87_outputWritten = true;
                    }
                    if (!__tmp90_last) __out.AppendLine(true);
                }
                string __tmp91_line = ".AddLazy(() => "; //422:19
                if (!string.IsNullOrEmpty(__tmp91_line))
                {
                    __out.Write(__tmp91_line);
                    __tmp87_outputWritten = true;
                }
                var __tmp92 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp92.Write(instanceNames[valueObject]);
                var __tmp92Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp92.ToStringAndFree());
                bool __tmp92_last = __tmp92Reader.EndOfStream;
                while(!__tmp92_last)
                {
                    ReadOnlySpan<char> __tmp92_line = __tmp92Reader.ReadLine();
                    __tmp92_last = __tmp92Reader.EndOfStream;
                    if (!__tmp92_last || !__tmp92_line.IsEmpty)
                    {
                        __out.Write(__tmp92_line);
                        __tmp87_outputWritten = true;
                    }
                    if (!__tmp92_last) __out.AppendLine(true);
                }
                string __tmp93_line = ");"; //422:62
                if (!string.IsNullOrEmpty(__tmp93_line))
                {
                    __out.Write(__tmp93_line);
                    __tmp87_outputWritten = true;
                }
                if (__tmp87_outputWritten) __out.AppendLine(true);
                if (__tmp87_outputWritten)
                {
                    __out.AppendLine(false); //422:64
                }
            }
            else if (valueDecl != null && valueDecl is MetaType) //423:2
            {
                bool __tmp95_outputWritten = false;
                var __tmp96 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp96.Write(name);
                var __tmp96Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp96.ToStringAndFree());
                bool __tmp96_last = __tmp96Reader.EndOfStream;
                while(!__tmp96_last)
                {
                    ReadOnlySpan<char> __tmp96_line = __tmp96Reader.ReadLine();
                    __tmp96_last = __tmp96Reader.EndOfStream;
                    if (!__tmp96_last || !__tmp96_line.IsEmpty)
                    {
                        __out.Write(__tmp96_line);
                        __tmp95_outputWritten = true;
                    }
                    if (!__tmp96_last) __out.AppendLine(true);
                }
                string __tmp97_line = "."; //424:7
                if (!string.IsNullOrEmpty(__tmp97_line))
                {
                    __out.Write(__tmp97_line);
                    __tmp95_outputWritten = true;
                }
                var __tmp98 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp98.Write(prop.Name);
                var __tmp98Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp98.ToStringAndFree());
                bool __tmp98_last = __tmp98Reader.EndOfStream;
                while(!__tmp98_last)
                {
                    ReadOnlySpan<char> __tmp98_line = __tmp98Reader.ReadLine();
                    __tmp98_last = __tmp98Reader.EndOfStream;
                    if (!__tmp98_last || !__tmp98_line.IsEmpty)
                    {
                        __out.Write(__tmp98_line);
                        __tmp95_outputWritten = true;
                    }
                    if (!__tmp98_last) __out.AppendLine(true);
                }
                string __tmp99_line = ".AddLazy(() => "; //424:19
                if (!string.IsNullOrEmpty(__tmp99_line))
                {
                    __out.Write(__tmp99_line);
                    __tmp95_outputWritten = true;
                }
                var __tmp100 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp100.Write(CSharpName(((MetaType)valueDecl), model, ClassKind.ImmutableInstance, true));
                var __tmp100Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp100.ToStringAndFree());
                bool __tmp100_last = __tmp100Reader.EndOfStream;
                while(!__tmp100_last)
                {
                    ReadOnlySpan<char> __tmp100_line = __tmp100Reader.ReadLine();
                    __tmp100_last = __tmp100Reader.EndOfStream;
                    if (!__tmp100_last || !__tmp100_line.IsEmpty)
                    {
                        __out.Write(__tmp100_line);
                        __tmp95_outputWritten = true;
                    }
                    if (!__tmp100_last) __out.AppendLine(true);
                }
                string __tmp101_line = ");"; //424:110
                if (!string.IsNullOrEmpty(__tmp101_line))
                {
                    __out.Write(__tmp101_line);
                    __tmp95_outputWritten = true;
                }
                if (__tmp95_outputWritten) __out.AppendLine(true);
                if (__tmp95_outputWritten)
                {
                    __out.AppendLine(false); //424:112
                }
            }
            else if (valueDecl != null && valueDecl is MetaConstant) //425:2
            {
                bool __tmp103_outputWritten = false;
                var __tmp104 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp104.Write(name);
                var __tmp104Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp104.ToStringAndFree());
                bool __tmp104_last = __tmp104Reader.EndOfStream;
                while(!__tmp104_last)
                {
                    ReadOnlySpan<char> __tmp104_line = __tmp104Reader.ReadLine();
                    __tmp104_last = __tmp104Reader.EndOfStream;
                    if (!__tmp104_last || !__tmp104_line.IsEmpty)
                    {
                        __out.Write(__tmp104_line);
                        __tmp103_outputWritten = true;
                    }
                    if (!__tmp104_last) __out.AppendLine(true);
                }
                string __tmp105_line = "."; //426:7
                if (!string.IsNullOrEmpty(__tmp105_line))
                {
                    __out.Write(__tmp105_line);
                    __tmp103_outputWritten = true;
                }
                var __tmp106 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp106.Write(prop.Name);
                var __tmp106Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp106.ToStringAndFree());
                bool __tmp106_last = __tmp106Reader.EndOfStream;
                while(!__tmp106_last)
                {
                    ReadOnlySpan<char> __tmp106_line = __tmp106Reader.ReadLine();
                    __tmp106_last = __tmp106Reader.EndOfStream;
                    if (!__tmp106_last || !__tmp106_line.IsEmpty)
                    {
                        __out.Write(__tmp106_line);
                        __tmp103_outputWritten = true;
                    }
                    if (!__tmp106_last) __out.AppendLine(true);
                }
                string __tmp107_line = ".AddLazy(() => "; //426:19
                if (!string.IsNullOrEmpty(__tmp107_line))
                {
                    __out.Write(__tmp107_line);
                    __tmp103_outputWritten = true;
                }
                var __tmp108 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp108.Write(CSharpName(((MetaConstant)valueDecl), model, ClassKind.ImmutableInstance, true));
                var __tmp108Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp108.ToStringAndFree());
                bool __tmp108_last = __tmp108Reader.EndOfStream;
                while(!__tmp108_last)
                {
                    ReadOnlySpan<char> __tmp108_line = __tmp108Reader.ReadLine();
                    __tmp108_last = __tmp108Reader.EndOfStream;
                    if (!__tmp108_last || !__tmp108_line.IsEmpty)
                    {
                        __out.Write(__tmp108_line);
                        __tmp103_outputWritten = true;
                    }
                    if (!__tmp108_last) __out.AppendLine(true);
                }
                string __tmp109_line = ");"; //426:114
                if (!string.IsNullOrEmpty(__tmp109_line))
                {
                    __out.Write(__tmp109_line);
                    __tmp103_outputWritten = true;
                }
                if (__tmp103_outputWritten) __out.AppendLine(true);
                if (__tmp103_outputWritten)
                {
                    __out.AppendLine(false); //426:116
                }
            }
            else //427:2
            {
                bool __tmp111_outputWritten = false;
                string __tmp112_line = "// TODO: "; //428:1
                if (!string.IsNullOrEmpty(__tmp112_line))
                {
                    __out.Write(__tmp112_line);
                    __tmp111_outputWritten = true;
                }
                var __tmp113 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp113.Write(name);
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
                string __tmp114_line = "."; //428:16
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
                    if (!__tmp115_last || __tmp111_outputWritten) __out.AppendLine(true);
                }
                if (__tmp111_outputWritten)
                {
                    __out.AppendLine(false); //428:28
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateFactory(MetaModel model) //432:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //433:2
            bool metaMetaModel = IsMetaMetaModel(model); //434:2
            __out.Write("/// <summary>"); //435:1
            __out.AppendLine(false); //435:14
            __out.Write("/// Factory class for creating instances of model elements."); //436:1
            __out.AppendLine(false); //436:60
            __out.Write("/// </summary>"); //437:1
            __out.AppendLine(false); //437:15
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //438:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Write(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp4.Write(CSharpName(model, ModelKind.Factory));
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
            string __tmp5_line = " : "; //438:51
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp6.Write(Properties.CoreNs);
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
            string __tmp7_line = ".ModelFactoryBase"; //438:73
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //438:90
            }
            __out.Write("{"); //439:1
            __out.AppendLine(false); //439:2
            bool __tmp9_outputWritten = false;
            string __tmp10_line = "	public "; //440:1
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Write(__tmp10_line);
                __tmp9_outputWritten = true;
            }
            var __tmp11 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp11.Write(CSharpName(model, ModelKind.Factory));
            var __tmp11Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp11.ToStringAndFree());
            bool __tmp11_last = __tmp11Reader.EndOfStream;
            while(!__tmp11_last)
            {
                ReadOnlySpan<char> __tmp11_line = __tmp11Reader.ReadLine();
                __tmp11_last = __tmp11Reader.EndOfStream;
                if (!__tmp11_last || !__tmp11_line.IsEmpty)
                {
                    __out.Write(__tmp11_line);
                    __tmp9_outputWritten = true;
                }
                if (!__tmp11_last) __out.AppendLine(true);
            }
            string __tmp12_line = "("; //440:46
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Write(__tmp12_line);
                __tmp9_outputWritten = true;
            }
            var __tmp13 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp13.Write(Properties.CoreNs);
            var __tmp13Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp13.ToStringAndFree());
            bool __tmp13_last = __tmp13Reader.EndOfStream;
            while(!__tmp13_last)
            {
                ReadOnlySpan<char> __tmp13_line = __tmp13Reader.ReadLine();
                __tmp13_last = __tmp13Reader.EndOfStream;
                if (!__tmp13_last || !__tmp13_line.IsEmpty)
                {
                    __out.Write(__tmp13_line);
                    __tmp9_outputWritten = true;
                }
                if (!__tmp13_last) __out.AppendLine(true);
            }
            string __tmp14_line = ".MutableModel model, "; //440:66
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp9_outputWritten = true;
            }
            var __tmp15 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp15.Write(Properties.CoreNs);
            var __tmp15Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp15.ToStringAndFree());
            bool __tmp15_last = __tmp15Reader.EndOfStream;
            while(!__tmp15_last)
            {
                ReadOnlySpan<char> __tmp15_line = __tmp15Reader.ReadLine();
                __tmp15_last = __tmp15Reader.EndOfStream;
                if (!__tmp15_last || !__tmp15_line.IsEmpty)
                {
                    __out.Write(__tmp15_line);
                    __tmp9_outputWritten = true;
                }
                if (!__tmp15_last) __out.AppendLine(true);
            }
            string __tmp16_line = ".ModelFactoryFlags flags = "; //440:106
            if (!string.IsNullOrEmpty(__tmp16_line))
            {
                __out.Write(__tmp16_line);
                __tmp9_outputWritten = true;
            }
            var __tmp17 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp17.Write(Properties.CoreNs);
            var __tmp17Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp17.ToStringAndFree());
            bool __tmp17_last = __tmp17Reader.EndOfStream;
            while(!__tmp17_last)
            {
                ReadOnlySpan<char> __tmp17_line = __tmp17Reader.ReadLine();
                __tmp17_last = __tmp17Reader.EndOfStream;
                if (!__tmp17_last || !__tmp17_line.IsEmpty)
                {
                    __out.Write(__tmp17_line);
                    __tmp9_outputWritten = true;
                }
                if (!__tmp17_last) __out.AppendLine(true);
            }
            string __tmp18_line = ".ModelFactoryFlags.None)"; //440:152
            if (!string.IsNullOrEmpty(__tmp18_line))
            {
                __out.Write(__tmp18_line);
                __tmp9_outputWritten = true;
            }
            if (__tmp9_outputWritten) __out.AppendLine(true);
            if (__tmp9_outputWritten)
            {
                __out.AppendLine(false); //440:176
            }
            __out.Write("		: base(model, flags)"); //441:1
            __out.AppendLine(false); //441:23
            __out.Write("	{"); //442:1
            __out.AppendLine(false); //442:3
            bool __tmp20_outputWritten = false;
            string __tmp19Prefix = "		"; //443:1
            var __tmp21 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp21.Write(CSharpName(model, ModelKind.Descriptor));
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
                if (!__tmp21_last) __out.AppendLine(true);
            }
            string __tmp22_line = ".Initialize();"; //443:43
            if (!string.IsNullOrEmpty(__tmp22_line))
            {
                __out.Write(__tmp22_line);
                __tmp20_outputWritten = true;
            }
            if (__tmp20_outputWritten) __out.AppendLine(true);
            if (__tmp20_outputWritten)
            {
                __out.AppendLine(false); //443:57
            }
            __out.Write("	}"); //444:1
            __out.AppendLine(false); //444:3
            __out.AppendLine(true); //445:1
            bool __tmp24_outputWritten = false;
            string __tmp25_line = "	public override "; //446:1
            if (!string.IsNullOrEmpty(__tmp25_line))
            {
                __out.Write(__tmp25_line);
                __tmp24_outputWritten = true;
            }
            var __tmp26 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp26.Write(Properties.CoreNs);
            var __tmp26Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp26.ToStringAndFree());
            bool __tmp26_last = __tmp26Reader.EndOfStream;
            while(!__tmp26_last)
            {
                ReadOnlySpan<char> __tmp26_line = __tmp26Reader.ReadLine();
                __tmp26_last = __tmp26Reader.EndOfStream;
                if (!__tmp26_last || !__tmp26_line.IsEmpty)
                {
                    __out.Write(__tmp26_line);
                    __tmp24_outputWritten = true;
                }
                if (!__tmp26_last) __out.AppendLine(true);
            }
            string __tmp27_line = ".ModelMetadata MMetadata => "; //446:37
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Write(__tmp27_line);
                __tmp24_outputWritten = true;
            }
            var __tmp28 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp28.Write(CSharpName(model, ModelKind.ImmutableInstance, true));
            var __tmp28Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp28.ToStringAndFree());
            bool __tmp28_last = __tmp28Reader.EndOfStream;
            while(!__tmp28_last)
            {
                ReadOnlySpan<char> __tmp28_line = __tmp28Reader.ReadLine();
                __tmp28_last = __tmp28Reader.EndOfStream;
                if (!__tmp28_last || !__tmp28_line.IsEmpty)
                {
                    __out.Write(__tmp28_line);
                    __tmp24_outputWritten = true;
                }
                if (!__tmp28_last) __out.AppendLine(true);
            }
            string __tmp29_line = ".MMetadata;"; //446:118
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Write(__tmp29_line);
                __tmp24_outputWritten = true;
            }
            if (__tmp24_outputWritten) __out.AppendLine(true);
            if (__tmp24_outputWritten)
            {
                __out.AppendLine(false); //446:129
            }
            __out.AppendLine(true); //447:1
            bool __tmp31_outputWritten = false;
            string __tmp32_line = "	public override "; //448:1
            if (!string.IsNullOrEmpty(__tmp32_line))
            {
                __out.Write(__tmp32_line);
                __tmp31_outputWritten = true;
            }
            var __tmp33 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp33.Write(Properties.CoreNs);
            var __tmp33Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp33.ToStringAndFree());
            bool __tmp33_last = __tmp33Reader.EndOfStream;
            while(!__tmp33_last)
            {
                ReadOnlySpan<char> __tmp33_line = __tmp33Reader.ReadLine();
                __tmp33_last = __tmp33Reader.EndOfStream;
                if (!__tmp33_last || !__tmp33_line.IsEmpty)
                {
                    __out.Write(__tmp33_line);
                    __tmp31_outputWritten = true;
                }
                if (!__tmp33_last) __out.AppendLine(true);
            }
            string __tmp34_line = ".MutableObject Create(string type)"; //448:37
            if (!string.IsNullOrEmpty(__tmp34_line))
            {
                __out.Write(__tmp34_line);
                __tmp31_outputWritten = true;
            }
            if (__tmp31_outputWritten) __out.AppendLine(true);
            if (__tmp31_outputWritten)
            {
                __out.AppendLine(false); //448:71
            }
            __out.Write("	{"); //449:1
            __out.AppendLine(false); //449:3
            __out.Write("		switch (type)"); //450:1
            __out.AppendLine(false); //450:16
            __out.Write("		{"); //451:1
            __out.AppendLine(false); //451:4
            var __loop22_results = 
                (from __loop22_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //452:10
                from cls in __Enumerate((__loop22_var1).GetEnumerator()).OfType<MetaClass>() //452:40
                select new { __loop22_var1 = __loop22_var1, cls = cls}
                ).ToList(); //452:5
            for (int __loop22_iteration = 0; __loop22_iteration < __loop22_results.Count; ++__loop22_iteration)
            {
                var __tmp35 = __loop22_results[__loop22_iteration];
                var __loop22_var1 = __tmp35.__loop22_var1;
                var cls = __tmp35.cls;
                if (!cls.IsAbstract) //453:6
                {
                    bool __tmp37_outputWritten = false;
                    string __tmp38_line = "			case \""; //454:1
                    if (!string.IsNullOrEmpty(__tmp38_line))
                    {
                        __out.Write(__tmp38_line);
                        __tmp37_outputWritten = true;
                    }
                    var __tmp39 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp39.Write(CSharpName(cls, model));
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
                    string __tmp40_line = "\": return this."; //454:33
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Write(__tmp40_line);
                        __tmp37_outputWritten = true;
                    }
                    var __tmp41 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp41.Write(CSharpName(cls, model));
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
                    string __tmp42_line = "();"; //454:71
                    if (!string.IsNullOrEmpty(__tmp42_line))
                    {
                        __out.Write(__tmp42_line);
                        __tmp37_outputWritten = true;
                    }
                    if (__tmp37_outputWritten) __out.AppendLine(true);
                    if (__tmp37_outputWritten)
                    {
                        __out.AppendLine(false); //454:74
                    }
                }
            }
            __out.Write("			default:"); //457:1
            __out.AppendLine(false); //457:12
            bool __tmp44_outputWritten = false;
            string __tmp45_line = "				throw new "; //458:1
            if (!string.IsNullOrEmpty(__tmp45_line))
            {
                __out.Write(__tmp45_line);
                __tmp44_outputWritten = true;
            }
            var __tmp46 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp46.Write(Properties.CoreNs);
            var __tmp46Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp46.ToStringAndFree());
            bool __tmp46_last = __tmp46Reader.EndOfStream;
            while(!__tmp46_last)
            {
                ReadOnlySpan<char> __tmp46_line = __tmp46Reader.ReadLine();
                __tmp46_last = __tmp46Reader.EndOfStream;
                if (!__tmp46_last || !__tmp46_line.IsEmpty)
                {
                    __out.Write(__tmp46_line);
                    __tmp44_outputWritten = true;
                }
                if (!__tmp46_last) __out.AppendLine(true);
            }
            string __tmp47_line = ".ModelException("; //458:34
            if (!string.IsNullOrEmpty(__tmp47_line))
            {
                __out.Write(__tmp47_line);
                __tmp44_outputWritten = true;
            }
            var __tmp48 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp48.Write(Properties.CoreNs);
            var __tmp48Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp48.ToStringAndFree());
            bool __tmp48_last = __tmp48Reader.EndOfStream;
            while(!__tmp48_last)
            {
                ReadOnlySpan<char> __tmp48_line = __tmp48Reader.ReadLine();
                __tmp48_last = __tmp48Reader.EndOfStream;
                if (!__tmp48_last || !__tmp48_line.IsEmpty)
                {
                    __out.Write(__tmp48_line);
                    __tmp44_outputWritten = true;
                }
                if (!__tmp48_last) __out.AppendLine(true);
            }
            string __tmp49_line = ".ModelErrorCode.ERR_UnknownTypeName.ToDiagnosticWithNoLocation(type));"; //458:69
            if (!string.IsNullOrEmpty(__tmp49_line))
            {
                __out.Write(__tmp49_line);
                __tmp44_outputWritten = true;
            }
            if (__tmp44_outputWritten) __out.AppendLine(true);
            if (__tmp44_outputWritten)
            {
                __out.AppendLine(false); //458:139
            }
            __out.Write("		}"); //459:1
            __out.AppendLine(false); //459:4
            __out.Write("	}"); //460:1
            __out.AppendLine(false); //460:3
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //461:8
                from cls in __Enumerate((__loop23_var1).GetEnumerator()).OfType<MetaClass>() //461:38
                select new { __loop23_var1 = __loop23_var1, cls = cls}
                ).ToList(); //461:3
            for (int __loop23_iteration = 0; __loop23_iteration < __loop23_results.Count; ++__loop23_iteration)
            {
                var __tmp50 = __loop23_results[__loop23_iteration];
                var __loop23_var1 = __tmp50.__loop23_var1;
                var cls = __tmp50.cls;
                if (!cls.IsAbstract) //462:4
                {
                    __out.AppendLine(true); //463:1
                    __out.Write("	/// <summary>"); //464:1
                    __out.AppendLine(false); //464:15
                    bool __tmp52_outputWritten = false;
                    string __tmp53_line = "	/// Creates a new instance of "; //465:1
                    if (!string.IsNullOrEmpty(__tmp53_line))
                    {
                        __out.Write(__tmp53_line);
                        __tmp52_outputWritten = true;
                    }
                    var __tmp54 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp54.Write(CSharpName(cls, model));
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
                    string __tmp55_line = "."; //465:55
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Write(__tmp55_line);
                        __tmp52_outputWritten = true;
                    }
                    if (__tmp52_outputWritten) __out.AppendLine(true);
                    if (__tmp52_outputWritten)
                    {
                        __out.AppendLine(false); //465:56
                    }
                    __out.Write("	/// </summary>"); //466:1
                    __out.AppendLine(false); //466:16
                    bool __tmp57_outputWritten = false;
                    string __tmp58_line = "	public "; //467:1
                    if (!string.IsNullOrEmpty(__tmp58_line))
                    {
                        __out.Write(__tmp58_line);
                        __tmp57_outputWritten = true;
                    }
                    var __tmp59 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp59.Write(CSharpName(cls, model, ClassKind.Builder));
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
                        if (!__tmp59_last) __out.AppendLine(true);
                    }
                    string __tmp60_line = " "; //467:51
                    if (!string.IsNullOrEmpty(__tmp60_line))
                    {
                        __out.Write(__tmp60_line);
                        __tmp57_outputWritten = true;
                    }
                    var __tmp61 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp61.Write(CSharpName(cls, model, ClassKind.FactoryMethod));
                    var __tmp61Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp61.ToStringAndFree());
                    bool __tmp61_last = __tmp61Reader.EndOfStream;
                    while(!__tmp61_last)
                    {
                        ReadOnlySpan<char> __tmp61_line = __tmp61Reader.ReadLine();
                        __tmp61_last = __tmp61Reader.EndOfStream;
                        if (!__tmp61_last || !__tmp61_line.IsEmpty)
                        {
                            __out.Write(__tmp61_line);
                            __tmp57_outputWritten = true;
                        }
                        if (!__tmp61_last) __out.AppendLine(true);
                    }
                    string __tmp62_line = "()"; //467:100
                    if (!string.IsNullOrEmpty(__tmp62_line))
                    {
                        __out.Write(__tmp62_line);
                        __tmp57_outputWritten = true;
                    }
                    if (__tmp57_outputWritten) __out.AppendLine(true);
                    if (__tmp57_outputWritten)
                    {
                        __out.AppendLine(false); //467:102
                    }
                    __out.Write("	{"); //468:1
                    __out.AppendLine(false); //468:3
                    bool __tmp64_outputWritten = false;
                    string __tmp63Prefix = "		"; //469:1
                    var __tmp65 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp65.Write(Properties.CoreNs);
                    var __tmp65Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp65.ToStringAndFree());
                    bool __tmp65_last = __tmp65Reader.EndOfStream;
                    while(!__tmp65_last)
                    {
                        ReadOnlySpan<char> __tmp65_line = __tmp65Reader.ReadLine();
                        __tmp65_last = __tmp65Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp63Prefix))
                        {
                            __out.Write(__tmp63Prefix);
                            __tmp64_outputWritten = true;
                        }
                        if (!__tmp65_last || !__tmp65_line.IsEmpty)
                        {
                            __out.Write(__tmp65_line);
                            __tmp64_outputWritten = true;
                        }
                        if (!__tmp65_last) __out.AppendLine(true);
                    }
                    string __tmp66_line = ".MutableObject obj = this.CreateObject(new "; //469:22
                    if (!string.IsNullOrEmpty(__tmp66_line))
                    {
                        __out.Write(__tmp66_line);
                        __tmp64_outputWritten = true;
                    }
                    var __tmp67 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp67.Write(CSharpName(cls, model, ClassKind.Id));
                    var __tmp67Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp67.ToStringAndFree());
                    bool __tmp67_last = __tmp67Reader.EndOfStream;
                    while(!__tmp67_last)
                    {
                        ReadOnlySpan<char> __tmp67_line = __tmp67Reader.ReadLine();
                        __tmp67_last = __tmp67Reader.EndOfStream;
                        if (!__tmp67_last || !__tmp67_line.IsEmpty)
                        {
                            __out.Write(__tmp67_line);
                            __tmp64_outputWritten = true;
                        }
                        if (!__tmp67_last) __out.AppendLine(true);
                    }
                    string __tmp68_line = "());"; //469:102
                    if (!string.IsNullOrEmpty(__tmp68_line))
                    {
                        __out.Write(__tmp68_line);
                        __tmp64_outputWritten = true;
                    }
                    if (__tmp64_outputWritten) __out.AppendLine(true);
                    if (__tmp64_outputWritten)
                    {
                        __out.AppendLine(false); //469:106
                    }
                    bool __tmp70_outputWritten = false;
                    string __tmp71_line = "		return ("; //470:1
                    if (!string.IsNullOrEmpty(__tmp71_line))
                    {
                        __out.Write(__tmp71_line);
                        __tmp70_outputWritten = true;
                    }
                    var __tmp72 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp72.Write(CSharpName(cls, model, ClassKind.Builder));
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
                    string __tmp73_line = ")obj;"; //470:53
                    if (!string.IsNullOrEmpty(__tmp73_line))
                    {
                        __out.Write(__tmp73_line);
                        __tmp70_outputWritten = true;
                    }
                    if (__tmp70_outputWritten) __out.AppendLine(true);
                    if (__tmp70_outputWritten)
                    {
                        __out.AppendLine(false); //470:58
                    }
                    __out.Write("	}"); //471:1
                    __out.AppendLine(false); //471:3
                }
            }
            __out.Write("}"); //474:1
            __out.AppendLine(false); //474:2
            __out.AppendLine(true); //475:1
            return __out.ToStringAndFree();
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //478:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //479:2
            bool metaMetaModel = IsMetaMetaModel(model); //480:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public static class "; //481:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Write(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp4.Write(CSharpName(model, ModelKind.Descriptor));
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
                __out.AppendLine(false); //481:61
            }
            __out.Write("{"); //482:1
            __out.AppendLine(false); //482:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	private static global::System.Collections.Generic.List<"; //483:1
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp6_outputWritten = true;
            }
            var __tmp8 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp8.Write(Properties.CoreNs);
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
            string __tmp9_line = ".ModelProperty> properties;"; //483:76
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Write(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //483:103
            }
            __out.AppendLine(true); //484:1
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	static "; //485:1
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Write(__tmp12_line);
                __tmp11_outputWritten = true;
            }
            var __tmp13 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp13.Write(CSharpName(model, ModelKind.Descriptor));
            var __tmp13Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp13.ToStringAndFree());
            bool __tmp13_last = __tmp13Reader.EndOfStream;
            while(!__tmp13_last)
            {
                ReadOnlySpan<char> __tmp13_line = __tmp13Reader.ReadLine();
                __tmp13_last = __tmp13Reader.EndOfStream;
                if (!__tmp13_last || !__tmp13_line.IsEmpty)
                {
                    __out.Write(__tmp13_line);
                    __tmp11_outputWritten = true;
                }
                if (!__tmp13_last) __out.AppendLine(true);
            }
            string __tmp14_line = "()"; //485:49
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //485:51
            }
            __out.Write("	{"); //486:1
            __out.AppendLine(false); //486:3
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "		properties = new global::System.Collections.Generic.List<"; //487:1
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Write(__tmp17_line);
                __tmp16_outputWritten = true;
            }
            var __tmp18 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp18.Write(Properties.CoreNs);
            var __tmp18Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp18.ToStringAndFree());
            bool __tmp18_last = __tmp18Reader.EndOfStream;
            while(!__tmp18_last)
            {
                ReadOnlySpan<char> __tmp18_line = __tmp18Reader.ReadLine();
                __tmp18_last = __tmp18Reader.EndOfStream;
                if (!__tmp18_last || !__tmp18_line.IsEmpty)
                {
                    __out.Write(__tmp18_line);
                    __tmp16_outputWritten = true;
                }
                if (!__tmp18_last) __out.AppendLine(true);
            }
            string __tmp19_line = ".ModelProperty>();"; //487:79
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Write(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //487:97
            }
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //488:9
                from cls in __Enumerate((__loop24_var1).GetEnumerator()).OfType<MetaClass>() //488:39
                select new { __loop24_var1 = __loop24_var1, cls = cls}
                ).ToList(); //488:4
            for (int __loop24_iteration = 0; __loop24_iteration < __loop24_results.Count; ++__loop24_iteration)
            {
                var __tmp20 = __loop24_results[__loop24_iteration];
                var __loop24_var1 = __tmp20.__loop24_var1;
                var cls = __tmp20.cls;
                bool __tmp22_outputWritten = false;
                string __tmp21Prefix = "		"; //489:1
                var __tmp23 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp23.Write(CSharpName(cls, model, ClassKind.Descriptor));
                var __tmp23Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp23.ToStringAndFree());
                bool __tmp23_last = __tmp23Reader.EndOfStream;
                while(!__tmp23_last)
                {
                    ReadOnlySpan<char> __tmp23_line = __tmp23Reader.ReadLine();
                    __tmp23_last = __tmp23Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp21Prefix))
                    {
                        __out.Write(__tmp21Prefix);
                        __tmp22_outputWritten = true;
                    }
                    if (!__tmp23_last || !__tmp23_line.IsEmpty)
                    {
                        __out.Write(__tmp23_line);
                        __tmp22_outputWritten = true;
                    }
                    if (!__tmp23_last) __out.AppendLine(true);
                }
                string __tmp24_line = ".Initialize();"; //489:48
                if (!string.IsNullOrEmpty(__tmp24_line))
                {
                    __out.Write(__tmp24_line);
                    __tmp22_outputWritten = true;
                }
                if (__tmp22_outputWritten) __out.AppendLine(true);
                if (__tmp22_outputWritten)
                {
                    __out.AppendLine(false); //489:62
                }
            }
            var __loop25_results = 
                (from __loop25_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //491:9
                from cls in __Enumerate((__loop25_var1).GetEnumerator()).OfType<MetaClass>() //491:39
                from prop in __Enumerate((cls.Properties).GetEnumerator()) //491:62
                select new { __loop25_var1 = __loop25_var1, cls = cls, prop = prop}
                ).ToList(); //491:4
            for (int __loop25_iteration = 0; __loop25_iteration < __loop25_results.Count; ++__loop25_iteration)
            {
                var __tmp25 = __loop25_results[__loop25_iteration];
                var __loop25_var1 = __tmp25.__loop25_var1;
                var cls = __tmp25.cls;
                var prop = __tmp25.prop;
                bool __tmp27_outputWritten = false;
                string __tmp28_line = "		properties.Add("; //492:1
                if (!string.IsNullOrEmpty(__tmp28_line))
                {
                    __out.Write(__tmp28_line);
                    __tmp27_outputWritten = true;
                }
                var __tmp29 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp29.Write(CSharpName(prop, model, PropertyKind.Descriptor, true));
                var __tmp29Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp29.ToStringAndFree());
                bool __tmp29_last = __tmp29Reader.EndOfStream;
                while(!__tmp29_last)
                {
                    ReadOnlySpan<char> __tmp29_line = __tmp29Reader.ReadLine();
                    __tmp29_last = __tmp29Reader.EndOfStream;
                    if (!__tmp29_last || !__tmp29_line.IsEmpty)
                    {
                        __out.Write(__tmp29_line);
                        __tmp27_outputWritten = true;
                    }
                    if (!__tmp29_last) __out.AppendLine(true);
                }
                string __tmp30_line = ");"; //492:73
                if (!string.IsNullOrEmpty(__tmp30_line))
                {
                    __out.Write(__tmp30_line);
                    __tmp27_outputWritten = true;
                }
                if (__tmp27_outputWritten) __out.AppendLine(true);
                if (__tmp27_outputWritten)
                {
                    __out.AppendLine(false); //492:75
                }
            }
            __out.Write("	}"); //494:1
            __out.AppendLine(false); //494:3
            __out.AppendLine(true); //495:1
            __out.Write("	public static void Initialize()"); //496:1
            __out.AppendLine(false); //496:33
            __out.Write("	{"); //497:1
            __out.AppendLine(false); //497:3
            __out.Write("	}"); //498:1
            __out.AppendLine(false); //498:3
            __out.AppendLine(true); //499:1
            bool __tmp32_outputWritten = false;
            string __tmp33_line = "	public const string MUri = \""; //500:1
            if (!string.IsNullOrEmpty(__tmp33_line))
            {
                __out.Write(__tmp33_line);
                __tmp32_outputWritten = true;
            }
            var __tmp34 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp34.Write(model.Uri);
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
            string __tmp35_line = "\";"; //500:41
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Write(__tmp35_line);
                __tmp32_outputWritten = true;
            }
            if (__tmp32_outputWritten) __out.AppendLine(true);
            if (__tmp32_outputWritten)
            {
                __out.AppendLine(false); //500:43
            }
            bool __tmp37_outputWritten = false;
            string __tmp38_line = "	public const string MPrefix = \""; //501:1
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Write(__tmp38_line);
                __tmp37_outputWritten = true;
            }
            var __tmp39 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp39.Write(model.Prefix);
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
            string __tmp40_line = "\";"; //501:47
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Write(__tmp40_line);
                __tmp37_outputWritten = true;
            }
            if (__tmp37_outputWritten) __out.AppendLine(true);
            if (__tmp37_outputWritten)
            {
                __out.AppendLine(false); //501:49
            }
            var __loop26_results = 
                (from __loop26_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //502:8
                from cls in __Enumerate((__loop26_var1).GetEnumerator()).OfType<MetaClass>() //502:38
                select new { __loop26_var1 = __loop26_var1, cls = cls}
                ).ToList(); //502:3
            for (int __loop26_iteration = 0; __loop26_iteration < __loop26_results.Count; ++__loop26_iteration)
            {
                var __tmp41 = __loop26_results[__loop26_iteration];
                var __loop26_var1 = __tmp41.__loop26_var1;
                var cls = __tmp41.cls;
                __out.AppendLine(true); //503:1
                bool __tmp43_outputWritten = false;
                string __tmp42Prefix = "	"; //504:1
                var __tmp44 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp44.Write(GenerateDescriptorClass(model, cls));
                var __tmp44Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp44.ToStringAndFree());
                bool __tmp44_last = __tmp44Reader.EndOfStream;
                while(!__tmp44_last)
                {
                    ReadOnlySpan<char> __tmp44_line = __tmp44Reader.ReadLine();
                    __tmp44_last = __tmp44Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp42Prefix))
                    {
                        __out.Write(__tmp42Prefix);
                        __tmp43_outputWritten = true;
                    }
                    if (!__tmp44_last || !__tmp44_line.IsEmpty)
                    {
                        __out.Write(__tmp44_line);
                        __tmp43_outputWritten = true;
                    }
                    if (!__tmp44_last || __tmp43_outputWritten) __out.AppendLine(true);
                }
                if (__tmp43_outputWritten)
                {
                    __out.AppendLine(false); //504:39
                }
            }
            __out.Write("}"); //506:1
            __out.AppendLine(false); //506:2
            return __out.ToStringAndFree();
        }

        public string GenerateDescriptorClass(MetaModel model, MetaClass cls) //509:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp3.Write(GenerateDocumentation(cls));
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
                __out.AppendLine(false); //510:29
            }
            bool __tmp5_outputWritten = false;
            var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp6.Write(GenerateAttributes(cls));
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
                __out.AppendLine(false); //511:26
            }
            if (cls.SymbolType != null) //512:2
            {
                bool __tmp8_outputWritten = false;
                var __tmp9 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp9.Write("[");
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
                    if (!__tmp9_last) __out.AppendLine(true);
                }
                string __tmp10_line = "global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof("; //513:6
                if (!string.IsNullOrEmpty(__tmp10_line))
                {
                    __out.Write(__tmp10_line);
                    __tmp8_outputWritten = true;
                }
                var __tmp11 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp11.Write(cls.SymbolType.FullName);
                var __tmp11Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp11.ToStringAndFree());
                bool __tmp11_last = __tmp11Reader.EndOfStream;
                while(!__tmp11_last)
                {
                    ReadOnlySpan<char> __tmp11_line = __tmp11Reader.ReadLine();
                    __tmp11_last = __tmp11Reader.EndOfStream;
                    if (!__tmp11_last || !__tmp11_line.IsEmpty)
                    {
                        __out.Write(__tmp11_line);
                        __tmp8_outputWritten = true;
                    }
                    if (!__tmp11_last) __out.AppendLine(true);
                }
                string __tmp12_line = "))"; //513:103
                if (!string.IsNullOrEmpty(__tmp12_line))
                {
                    __out.Write(__tmp12_line);
                    __tmp8_outputWritten = true;
                }
                var __tmp13 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp13.Write("]");
                var __tmp13Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp13.ToStringAndFree());
                bool __tmp13_last = __tmp13Reader.EndOfStream;
                while(!__tmp13_last)
                {
                    ReadOnlySpan<char> __tmp13_line = __tmp13Reader.ReadLine();
                    __tmp13_last = __tmp13Reader.EndOfStream;
                    if (!__tmp13_last || !__tmp13_line.IsEmpty)
                    {
                        __out.Write(__tmp13_line);
                        __tmp8_outputWritten = true;
                    }
                    if (!__tmp13_last || __tmp8_outputWritten) __out.AppendLine(true);
                }
                if (__tmp8_outputWritten)
                {
                    __out.AppendLine(false); //513:110
                }
            }
            bool __tmp15_outputWritten = false;
            var __tmp16 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp16.Write("[" + Properties.CoreNs);
            var __tmp16Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp16.ToStringAndFree());
            bool __tmp16_last = __tmp16Reader.EndOfStream;
            while(!__tmp16_last)
            {
                ReadOnlySpan<char> __tmp16_line = __tmp16Reader.ReadLine();
                __tmp16_last = __tmp16Reader.EndOfStream;
                if (!__tmp16_last || !__tmp16_line.IsEmpty)
                {
                    __out.Write(__tmp16_line);
                    __tmp15_outputWritten = true;
                }
                if (!__tmp16_last) __out.AppendLine(true);
            }
            string __tmp17_line = ".ModelObjectDescriptorAttribute(typeof("; //515:24
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Write(__tmp17_line);
                __tmp15_outputWritten = true;
            }
            var __tmp18 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp18.Write(CSharpName(cls, null, ClassKind.Id, true));
            var __tmp18Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp18.ToStringAndFree());
            bool __tmp18_last = __tmp18Reader.EndOfStream;
            while(!__tmp18_last)
            {
                ReadOnlySpan<char> __tmp18_line = __tmp18Reader.ReadLine();
                __tmp18_last = __tmp18Reader.EndOfStream;
                if (!__tmp18_last || !__tmp18_line.IsEmpty)
                {
                    __out.Write(__tmp18_line);
                    __tmp15_outputWritten = true;
                }
                if (!__tmp18_last) __out.AppendLine(true);
            }
            string __tmp19_line = "), typeof("; //515:105
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Write(__tmp19_line);
                __tmp15_outputWritten = true;
            }
            var __tmp20 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp20.Write(CSharpName(cls, null, ClassKind.Immutable, true));
            var __tmp20Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp20.ToStringAndFree());
            bool __tmp20_last = __tmp20Reader.EndOfStream;
            while(!__tmp20_last)
            {
                ReadOnlySpan<char> __tmp20_line = __tmp20Reader.ReadLine();
                __tmp20_last = __tmp20Reader.EndOfStream;
                if (!__tmp20_last || !__tmp20_line.IsEmpty)
                {
                    __out.Write(__tmp20_line);
                    __tmp15_outputWritten = true;
                }
                if (!__tmp20_last) __out.AppendLine(true);
            }
            string __tmp21_line = "), typeof("; //515:164
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp15_outputWritten = true;
            }
            var __tmp22 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp22.Write(CSharpName(cls, null, ClassKind.Builder, true));
            var __tmp22Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp22.ToStringAndFree());
            bool __tmp22_last = __tmp22Reader.EndOfStream;
            while(!__tmp22_last)
            {
                ReadOnlySpan<char> __tmp22_line = __tmp22Reader.ReadLine();
                __tmp22_last = __tmp22Reader.EndOfStream;
                if (!__tmp22_last || !__tmp22_line.IsEmpty)
                {
                    __out.Write(__tmp22_line);
                    __tmp15_outputWritten = true;
                }
                if (!__tmp22_last) __out.AppendLine(true);
            }
            string __tmp23_line = ")"; //515:221
            if (!string.IsNullOrEmpty(__tmp23_line))
            {
                __out.Write(__tmp23_line);
                __tmp15_outputWritten = true;
            }
            var __tmp24 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp24.Write(GetDescriptorAncestors(model, cls));
            var __tmp24Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp24.ToStringAndFree());
            bool __tmp24_last = __tmp24Reader.EndOfStream;
            while(!__tmp24_last)
            {
                ReadOnlySpan<char> __tmp24_line = __tmp24Reader.ReadLine();
                __tmp24_last = __tmp24Reader.EndOfStream;
                if (!__tmp24_last || !__tmp24_line.IsEmpty)
                {
                    __out.Write(__tmp24_line);
                    __tmp15_outputWritten = true;
                }
                if (!__tmp24_last) __out.AppendLine(true);
            }
            string __tmp25_line = ")"; //515:258
            if (!string.IsNullOrEmpty(__tmp25_line))
            {
                __out.Write(__tmp25_line);
                __tmp15_outputWritten = true;
            }
            var __tmp26 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp26.Write("]");
            var __tmp26Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp26.ToStringAndFree());
            bool __tmp26_last = __tmp26Reader.EndOfStream;
            while(!__tmp26_last)
            {
                ReadOnlySpan<char> __tmp26_line = __tmp26Reader.ReadLine();
                __tmp26_last = __tmp26Reader.EndOfStream;
                if (!__tmp26_last || !__tmp26_line.IsEmpty)
                {
                    __out.Write(__tmp26_line);
                    __tmp15_outputWritten = true;
                }
                if (!__tmp26_last || __tmp15_outputWritten) __out.AppendLine(true);
            }
            if (__tmp15_outputWritten)
            {
                __out.AppendLine(false); //515:264
            }
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "public static class "; //516:1
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Write(__tmp29_line);
                __tmp28_outputWritten = true;
            }
            var __tmp30 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp30.Write(CSharpName(cls, model, ClassKind.Descriptor));
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
                if (!__tmp30_last || __tmp28_outputWritten) __out.AppendLine(true);
            }
            if (__tmp28_outputWritten)
            {
                __out.AppendLine(false); //516:66
            }
            __out.Write("{"); //517:1
            __out.AppendLine(false); //517:2
            bool __tmp32_outputWritten = false;
            string __tmp33_line = "	private static "; //518:1
            if (!string.IsNullOrEmpty(__tmp33_line))
            {
                __out.Write(__tmp33_line);
                __tmp32_outputWritten = true;
            }
            var __tmp34 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp34.Write(Properties.CoreNs);
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
            string __tmp35_line = ".ModelObjectDescriptor descriptor;"; //518:36
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Write(__tmp35_line);
                __tmp32_outputWritten = true;
            }
            if (__tmp32_outputWritten) __out.AppendLine(true);
            if (__tmp32_outputWritten)
            {
                __out.AppendLine(false); //518:70
            }
            __out.AppendLine(true); //519:1
            bool __tmp37_outputWritten = false;
            string __tmp38_line = "	static "; //520:1
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Write(__tmp38_line);
                __tmp37_outputWritten = true;
            }
            var __tmp39 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp39.Write(CSharpName(cls, model, ClassKind.Descriptor));
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
            string __tmp40_line = "()"; //520:54
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Write(__tmp40_line);
                __tmp37_outputWritten = true;
            }
            if (__tmp37_outputWritten) __out.AppendLine(true);
            if (__tmp37_outputWritten)
            {
                __out.AppendLine(false); //520:56
            }
            __out.Write("	{"); //521:1
            __out.AppendLine(false); //521:3
            bool __tmp42_outputWritten = false;
            string __tmp43_line = "		descriptor = "; //522:1
            if (!string.IsNullOrEmpty(__tmp43_line))
            {
                __out.Write(__tmp43_line);
                __tmp42_outputWritten = true;
            }
            var __tmp44 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp44.Write(Properties.CoreNs);
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
            string __tmp45_line = ".ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof("; //522:35
            if (!string.IsNullOrEmpty(__tmp45_line))
            {
                __out.Write(__tmp45_line);
                __tmp42_outputWritten = true;
            }
            var __tmp46 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp46.Write(CSharpName(cls, model, ClassKind.Descriptor));
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
            string __tmp47_line = "));"; //522:141
            if (!string.IsNullOrEmpty(__tmp47_line))
            {
                __out.Write(__tmp47_line);
                __tmp42_outputWritten = true;
            }
            if (__tmp42_outputWritten) __out.AppendLine(true);
            if (__tmp42_outputWritten)
            {
                __out.AppendLine(false); //522:144
            }
            __out.Write("	}"); //523:1
            __out.AppendLine(false); //523:3
            __out.AppendLine(true); //524:1
            __out.Write("	internal static void Initialize()"); //525:1
            __out.AppendLine(false); //525:35
            __out.Write("	{"); //526:1
            __out.AppendLine(false); //526:3
            __out.Write("	}"); //527:1
            __out.AppendLine(false); //527:3
            __out.AppendLine(true); //528:1
            bool __tmp49_outputWritten = false;
            string __tmp50_line = "	public static "; //529:1
            if (!string.IsNullOrEmpty(__tmp50_line))
            {
                __out.Write(__tmp50_line);
                __tmp49_outputWritten = true;
            }
            var __tmp51 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp51.Write(Properties.CoreNs);
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
            string __tmp52_line = ".ModelObjectDescriptor MDescriptor"; //529:35
            if (!string.IsNullOrEmpty(__tmp52_line))
            {
                __out.Write(__tmp52_line);
                __tmp49_outputWritten = true;
            }
            if (__tmp49_outputWritten) __out.AppendLine(true);
            if (__tmp49_outputWritten)
            {
                __out.AppendLine(false); //529:69
            }
            __out.Write("	{"); //530:1
            __out.AppendLine(false); //530:3
            __out.Write("		get { return descriptor; }"); //531:1
            __out.AppendLine(false); //531:29
            __out.Write("	}"); //532:1
            __out.AppendLine(false); //532:3
            __out.AppendLine(true); //533:1
            bool __tmp54_outputWritten = false;
            string __tmp55_line = "	public static "; //534:1
            if (!string.IsNullOrEmpty(__tmp55_line))
            {
                __out.Write(__tmp55_line);
                __tmp54_outputWritten = true;
            }
            var __tmp56 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp56.Write(Properties.MetaNs);
            var __tmp56Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp56.ToStringAndFree());
            bool __tmp56_last = __tmp56Reader.EndOfStream;
            while(!__tmp56_last)
            {
                ReadOnlySpan<char> __tmp56_line = __tmp56Reader.ReadLine();
                __tmp56_last = __tmp56Reader.EndOfStream;
                if (!__tmp56_last || !__tmp56_line.IsEmpty)
                {
                    __out.Write(__tmp56_line);
                    __tmp54_outputWritten = true;
                }
                if (!__tmp56_last) __out.AppendLine(true);
            }
            string __tmp57_line = ".MetaClass MMetaClass"; //534:35
            if (!string.IsNullOrEmpty(__tmp57_line))
            {
                __out.Write(__tmp57_line);
                __tmp54_outputWritten = true;
            }
            if (__tmp54_outputWritten) __out.AppendLine(true);
            if (__tmp54_outputWritten)
            {
                __out.AppendLine(false); //534:56
            }
            __out.Write("	{"); //535:1
            __out.AppendLine(false); //535:3
            bool __tmp59_outputWritten = false;
            string __tmp60_line = "		get { return "; //536:1
            if (!string.IsNullOrEmpty(__tmp60_line))
            {
                __out.Write(__tmp60_line);
                __tmp59_outputWritten = true;
            }
            var __tmp61 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp61.Write(CSharpName(cls, null, ClassKind.ImmutableInstance, true));
            var __tmp61Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp61.ToStringAndFree());
            bool __tmp61_last = __tmp61Reader.EndOfStream;
            while(!__tmp61_last)
            {
                ReadOnlySpan<char> __tmp61_line = __tmp61Reader.ReadLine();
                __tmp61_last = __tmp61Reader.EndOfStream;
                if (!__tmp61_last || !__tmp61_line.IsEmpty)
                {
                    __out.Write(__tmp61_line);
                    __tmp59_outputWritten = true;
                }
                if (!__tmp61_last) __out.AppendLine(true);
            }
            string __tmp62_line = "; }"; //536:73
            if (!string.IsNullOrEmpty(__tmp62_line))
            {
                __out.Write(__tmp62_line);
                __tmp59_outputWritten = true;
            }
            if (__tmp59_outputWritten) __out.AppendLine(true);
            if (__tmp59_outputWritten)
            {
                __out.AppendLine(false); //536:76
            }
            __out.Write("	}"); //537:1
            __out.AppendLine(false); //537:3
            var __loop27_results = 
                (from __loop27_var1 in __Enumerate((cls).GetEnumerator()) //538:8
                from prop in __Enumerate((__loop27_var1.Properties).GetEnumerator()) //538:13
                select new { __loop27_var1 = __loop27_var1, prop = prop}
                ).ToList(); //538:3
            for (int __loop27_iteration = 0; __loop27_iteration < __loop27_results.Count; ++__loop27_iteration)
            {
                var __tmp63 = __loop27_results[__loop27_iteration];
                var __loop27_var1 = __tmp63.__loop27_var1;
                var prop = __tmp63.prop;
                bool __tmp65_outputWritten = false;
                string __tmp64Prefix = "	"; //539:1
                var __tmp66 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp66.Write(GenerateDescriptorProperty(model, cls, prop));
                var __tmp66Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp66.ToStringAndFree());
                bool __tmp66_last = __tmp66Reader.EndOfStream;
                while(!__tmp66_last)
                {
                    ReadOnlySpan<char> __tmp66_line = __tmp66Reader.ReadLine();
                    __tmp66_last = __tmp66Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp64Prefix))
                    {
                        __out.Write(__tmp64Prefix);
                        __tmp65_outputWritten = true;
                    }
                    if (!__tmp66_last || !__tmp66_line.IsEmpty)
                    {
                        __out.Write(__tmp66_line);
                        __tmp65_outputWritten = true;
                    }
                    if (!__tmp66_last || __tmp65_outputWritten) __out.AppendLine(true);
                }
                if (__tmp65_outputWritten)
                {
                    __out.AppendLine(false); //539:48
                }
            }
            __out.Write("}"); //541:1
            __out.AppendLine(false); //541:2
            return __out.ToStringAndFree();
        }

        public string GetDescriptorAncestors(MetaModel model, MetaClass cls) //544:1
        {
            string result = ""; //545:2
            var __loop28_results = 
                (from __loop28_var1 in __Enumerate((cls).GetEnumerator()) //546:7
                from super in __Enumerate((__loop28_var1.SuperClasses).GetEnumerator()) //546:12
                select new { __loop28_var1 = __loop28_var1, super = super}
                ).ToList(); //546:2
            for (int __loop28_iteration = 0; __loop28_iteration < __loop28_results.Count; ++__loop28_iteration)
            {
                string delim; //546:30
                if (__loop28_iteration+1 < __loop28_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop28_results[__loop28_iteration];
                var __loop28_var1 = __tmp1.__loop28_var1;
                var super = __tmp1.super;
                result += "typeof(" + CSharpName(super, model, ClassKind.Descriptor, true) + ")" + delim; //547:3
            }
            if (result.Length > 0) //549:2
            {
                result = ", BaseDescriptors = new global::System.Type[] { " + result + " }"; //550:3
            }
            return result; //552:2
        }

        public string GenerateDescriptorProperty(MetaModel model, MetaClass cls, MetaProperty prop) //555:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.AppendLine(true); //556:1
            bool __tmp2_outputWritten = false;
            var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp3.Write(GenerateDocumentation(prop));
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
                __out.AppendLine(false); //557:30
            }
            bool __tmp5_outputWritten = false;
            var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp6.Write(GenerateAttributes(prop));
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
                __out.AppendLine(false); //558:27
            }
            if (prop.SymbolProperty != null) //559:2
            {
                bool __tmp8_outputWritten = false;
                var __tmp9 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp9.Write("[");
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
                    if (!__tmp9_last) __out.AppendLine(true);
                }
                string __tmp10_line = "global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute(\""; //560:6
                if (!string.IsNullOrEmpty(__tmp10_line))
                {
                    __out.Write(__tmp10_line);
                    __tmp8_outputWritten = true;
                }
                var __tmp11 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp11.Write(prop.SymbolProperty);
                var __tmp11Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp11.ToStringAndFree());
                bool __tmp11_last = __tmp11Reader.EndOfStream;
                while(!__tmp11_last)
                {
                    ReadOnlySpan<char> __tmp11_line = __tmp11Reader.ReadLine();
                    __tmp11_last = __tmp11Reader.EndOfStream;
                    if (!__tmp11_last || !__tmp11_line.IsEmpty)
                    {
                        __out.Write(__tmp11_line);
                        __tmp8_outputWritten = true;
                    }
                    if (!__tmp11_last) __out.AppendLine(true);
                }
                string __tmp12_line = "\")"; //560:101
                if (!string.IsNullOrEmpty(__tmp12_line))
                {
                    __out.Write(__tmp12_line);
                    __tmp8_outputWritten = true;
                }
                var __tmp13 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp13.Write("]");
                var __tmp13Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp13.ToStringAndFree());
                bool __tmp13_last = __tmp13Reader.EndOfStream;
                while(!__tmp13_last)
                {
                    ReadOnlySpan<char> __tmp13_line = __tmp13Reader.ReadLine();
                    __tmp13_last = __tmp13Reader.EndOfStream;
                    if (!__tmp13_last || !__tmp13_line.IsEmpty)
                    {
                        __out.Write(__tmp13_line);
                        __tmp8_outputWritten = true;
                    }
                    if (!__tmp13_last || __tmp8_outputWritten) __out.AppendLine(true);
                }
                if (__tmp8_outputWritten)
                {
                    __out.AppendLine(false); //560:108
                }
            }
            bool __tmp15_outputWritten = false;
            var __tmp16 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp16.Write(GenerateDescriptorPropertyAttributes(model, cls, prop));
            var __tmp16Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp16.ToStringAndFree());
            bool __tmp16_last = __tmp16Reader.EndOfStream;
            while(!__tmp16_last)
            {
                ReadOnlySpan<char> __tmp16_line = __tmp16Reader.ReadLine();
                __tmp16_last = __tmp16Reader.EndOfStream;
                if (!__tmp16_last || !__tmp16_line.IsEmpty)
                {
                    __out.Write(__tmp16_line);
                    __tmp15_outputWritten = true;
                }
                if (!__tmp16_last || __tmp15_outputWritten) __out.AppendLine(true);
            }
            if (__tmp15_outputWritten)
            {
                __out.AppendLine(false); //562:57
            }
            bool __tmp18_outputWritten = false;
            string __tmp19_line = "public static readonly "; //563:1
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Write(__tmp19_line);
                __tmp18_outputWritten = true;
            }
            var __tmp20 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp20.Write(Properties.CoreNs);
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
            string __tmp21_line = ".ModelProperty "; //563:43
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp18_outputWritten = true;
            }
            var __tmp22 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp22.Write(CSharpName(prop, model, PropertyKind.Descriptor));
            var __tmp22Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp22.ToStringAndFree());
            bool __tmp22_last = __tmp22Reader.EndOfStream;
            while(!__tmp22_last)
            {
                ReadOnlySpan<char> __tmp22_line = __tmp22Reader.ReadLine();
                __tmp22_last = __tmp22Reader.EndOfStream;
                if (!__tmp22_last || !__tmp22_line.IsEmpty)
                {
                    __out.Write(__tmp22_line);
                    __tmp18_outputWritten = true;
                }
                if (!__tmp22_last) __out.AppendLine(true);
            }
            string __tmp23_line = " ="; //563:107
            if (!string.IsNullOrEmpty(__tmp23_line))
            {
                __out.Write(__tmp23_line);
                __tmp18_outputWritten = true;
            }
            if (__tmp18_outputWritten) __out.AppendLine(true);
            if (__tmp18_outputWritten)
            {
                __out.AppendLine(false); //563:109
            }
            bool __tmp25_outputWritten = false;
            string __tmp24Prefix = "    "; //564:1
            var __tmp26 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp26.Write(Properties.CoreNs);
            var __tmp26Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp26.ToStringAndFree());
            bool __tmp26_last = __tmp26Reader.EndOfStream;
            while(!__tmp26_last)
            {
                ReadOnlySpan<char> __tmp26_line = __tmp26Reader.ReadLine();
                __tmp26_last = __tmp26Reader.EndOfStream;
                if (!string.IsNullOrEmpty(__tmp24Prefix))
                {
                    __out.Write(__tmp24Prefix);
                    __tmp25_outputWritten = true;
                }
                if (!__tmp26_last || !__tmp26_line.IsEmpty)
                {
                    __out.Write(__tmp26_line);
                    __tmp25_outputWritten = true;
                }
                if (!__tmp26_last) __out.AppendLine(true);
            }
            string __tmp27_line = ".ModelProperty.Register(declaringType: typeof("; //564:24
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Write(__tmp27_line);
                __tmp25_outputWritten = true;
            }
            var __tmp28 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp28.Write(CSharpName(cls, model, ClassKind.Descriptor));
            var __tmp28Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp28.ToStringAndFree());
            bool __tmp28_last = __tmp28Reader.EndOfStream;
            while(!__tmp28_last)
            {
                ReadOnlySpan<char> __tmp28_line = __tmp28Reader.ReadLine();
                __tmp28_last = __tmp28Reader.EndOfStream;
                if (!__tmp28_last || !__tmp28_line.IsEmpty)
                {
                    __out.Write(__tmp28_line);
                    __tmp25_outputWritten = true;
                }
                if (!__tmp28_last) __out.AppendLine(true);
            }
            string __tmp29_line = "), name: \""; //564:115
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Write(__tmp29_line);
                __tmp25_outputWritten = true;
            }
            var __tmp30 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp30.Write(CSharpName(prop, model));
            var __tmp30Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp30.ToStringAndFree());
            bool __tmp30_last = __tmp30Reader.EndOfStream;
            while(!__tmp30_last)
            {
                ReadOnlySpan<char> __tmp30_line = __tmp30Reader.ReadLine();
                __tmp30_last = __tmp30Reader.EndOfStream;
                if (!__tmp30_last || !__tmp30_line.IsEmpty)
                {
                    __out.Write(__tmp30_line);
                    __tmp25_outputWritten = true;
                }
                if (!__tmp30_last) __out.AppendLine(true);
            }
            string __tmp31_line = "\","; //564:149
            if (!string.IsNullOrEmpty(__tmp31_line))
            {
                __out.Write(__tmp31_line);
                __tmp25_outputWritten = true;
            }
            if (__tmp25_outputWritten) __out.AppendLine(true);
            if (__tmp25_outputWritten)
            {
                __out.AppendLine(false); //564:151
            }
            if (prop.Type is MetaCollectionType) //565:2
            {
                MetaCollectionType collType = (MetaCollectionType)prop.Type; //566:3
                bool __tmp33_outputWritten = false;
                string __tmp34_line = "        immutableType: typeof("; //567:1
                if (!string.IsNullOrEmpty(__tmp34_line))
                {
                    __out.Write(__tmp34_line);
                    __tmp33_outputWritten = true;
                }
                var __tmp35 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp35.Write(CSharpName(collType.InnerType, null, ClassKind.Immutable, true));
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
                string __tmp36_line = "),"; //567:95
                if (!string.IsNullOrEmpty(__tmp36_line))
                {
                    __out.Write(__tmp36_line);
                    __tmp33_outputWritten = true;
                }
                if (__tmp33_outputWritten) __out.AppendLine(true);
                if (__tmp33_outputWritten)
                {
                    __out.AppendLine(false); //567:97
                }
                bool __tmp38_outputWritten = false;
                string __tmp39_line = "        mutableType: typeof("; //568:1
                if (!string.IsNullOrEmpty(__tmp39_line))
                {
                    __out.Write(__tmp39_line);
                    __tmp38_outputWritten = true;
                }
                var __tmp40 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp40.Write(CSharpName(collType.InnerType, null, ClassKind.Builder, true));
                var __tmp40Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp40.ToStringAndFree());
                bool __tmp40_last = __tmp40Reader.EndOfStream;
                while(!__tmp40_last)
                {
                    ReadOnlySpan<char> __tmp40_line = __tmp40Reader.ReadLine();
                    __tmp40_last = __tmp40Reader.EndOfStream;
                    if (!__tmp40_last || !__tmp40_line.IsEmpty)
                    {
                        __out.Write(__tmp40_line);
                        __tmp38_outputWritten = true;
                    }
                    if (!__tmp40_last) __out.AppendLine(true);
                }
                string __tmp41_line = "),"; //568:91
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Write(__tmp41_line);
                    __tmp38_outputWritten = true;
                }
                if (__tmp38_outputWritten) __out.AppendLine(true);
                if (__tmp38_outputWritten)
                {
                    __out.AppendLine(false); //568:93
                }
            }
            else //569:2
            {
                bool __tmp43_outputWritten = false;
                string __tmp44_line = "        immutableType: typeof("; //570:1
                if (!string.IsNullOrEmpty(__tmp44_line))
                {
                    __out.Write(__tmp44_line);
                    __tmp43_outputWritten = true;
                }
                var __tmp45 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp45.Write(CSharpName(prop.Type, null, ClassKind.Immutable, true));
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
                string __tmp46_line = "),"; //570:86
                if (!string.IsNullOrEmpty(__tmp46_line))
                {
                    __out.Write(__tmp46_line);
                    __tmp43_outputWritten = true;
                }
                if (__tmp43_outputWritten) __out.AppendLine(true);
                if (__tmp43_outputWritten)
                {
                    __out.AppendLine(false); //570:88
                }
                bool __tmp48_outputWritten = false;
                string __tmp49_line = "        mutableType: typeof("; //571:1
                if (!string.IsNullOrEmpty(__tmp49_line))
                {
                    __out.Write(__tmp49_line);
                    __tmp48_outputWritten = true;
                }
                var __tmp50 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp50.Write(CSharpName(prop.Type, null, ClassKind.Builder, true));
                var __tmp50Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp50.ToStringAndFree());
                bool __tmp50_last = __tmp50Reader.EndOfStream;
                while(!__tmp50_last)
                {
                    ReadOnlySpan<char> __tmp50_line = __tmp50Reader.ReadLine();
                    __tmp50_last = __tmp50Reader.EndOfStream;
                    if (!__tmp50_last || !__tmp50_line.IsEmpty)
                    {
                        __out.Write(__tmp50_line);
                        __tmp48_outputWritten = true;
                    }
                    if (!__tmp50_last) __out.AppendLine(true);
                }
                string __tmp51_line = "),"; //571:82
                if (!string.IsNullOrEmpty(__tmp51_line))
                {
                    __out.Write(__tmp51_line);
                    __tmp48_outputWritten = true;
                }
                if (__tmp48_outputWritten) __out.AppendLine(true);
                if (__tmp48_outputWritten)
                {
                    __out.AppendLine(false); //571:84
                }
            }
            bool __tmp53_outputWritten = false;
            string __tmp54_line = "		metaProperty: () => "; //573:1
            if (!string.IsNullOrEmpty(__tmp54_line))
            {
                __out.Write(__tmp54_line);
                __tmp53_outputWritten = true;
            }
            var __tmp55 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp55.Write(CSharpName(prop, null, PropertyKind.ImmutableInstance, true));
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
            string __tmp56_line = ","; //573:84
            if (!string.IsNullOrEmpty(__tmp56_line))
            {
                __out.Write(__tmp56_line);
                __tmp53_outputWritten = true;
            }
            if (__tmp53_outputWritten) __out.AppendLine(true);
            if (__tmp53_outputWritten)
            {
                __out.AppendLine(false); //573:85
            }
            bool __tmp58_outputWritten = false;
            string __tmp59_line = "		defaultValue: "; //574:1
            if (!string.IsNullOrEmpty(__tmp59_line))
            {
                __out.Write(__tmp59_line);
                __tmp58_outputWritten = true;
            }
            var __tmp60 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp60.Write(prop.DefaultValue != null ? prop.DefaultValue : "null");
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
            string __tmp61_line = ");"; //574:73
            if (!string.IsNullOrEmpty(__tmp61_line))
            {
                __out.Write(__tmp61_line);
                __tmp58_outputWritten = true;
            }
            if (__tmp58_outputWritten) __out.AppendLine(true);
            if (__tmp58_outputWritten)
            {
                __out.AppendLine(false); //574:75
            }
            return __out.ToStringAndFree();
        }

        public string GenerateDescriptorPropertyAttributes(MetaModel model, MetaClass cls, MetaProperty prop) //577:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            if (prop.Type is MetaCollectionType) //578:2
            {
                bool __tmp2_outputWritten = false;
                var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp3.Write("[" + Properties.CoreNs + ".CollectionAttribute]");
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
                    __out.AppendLine(false); //579:48
                }
            }
            if (prop.Type is MetaCollectionType && (((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiSet || ((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiList)) //581:2
            {
                bool __tmp5_outputWritten = false;
                var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp6.Write("[" + Properties.CoreNs + ".NonUniqueAttribute]");
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
                    __out.AppendLine(false); //582:47
                }
            }
            if (prop.Type is MetaCollectionType && (((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.List || ((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiList)) //584:2
            {
                bool __tmp8_outputWritten = false;
                var __tmp9 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp9.Write("[" + Properties.CoreNs + ".OrderedAttribute]");
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
                    __out.AppendLine(false); //585:45
                }
            }
            if (prop.IsContainment) //587:2
            {
                bool __tmp11_outputWritten = false;
                var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp12.Write("[" + Properties.CoreNs + ".ContainmentAttribute]");
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
                    __out.AppendLine(false); //588:49
                }
            }
            if (prop.Kind != MetaPropertyKind.Normal) //590:2
            {
                bool __tmp14_outputWritten = false;
                var __tmp15 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp15.Write("[" + Properties.CoreNs + ".ReadonlyAttribute]");
                var __tmp15Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp15.ToStringAndFree());
                bool __tmp15_last = __tmp15Reader.EndOfStream;
                while(!__tmp15_last)
                {
                    ReadOnlySpan<char> __tmp15_line = __tmp15Reader.ReadLine();
                    __tmp15_last = __tmp15Reader.EndOfStream;
                    if (!__tmp15_last || !__tmp15_line.IsEmpty)
                    {
                        __out.Write(__tmp15_line);
                        __tmp14_outputWritten = true;
                    }
                    if (!__tmp15_last || __tmp14_outputWritten) __out.AppendLine(true);
                }
                if (__tmp14_outputWritten)
                {
                    __out.AppendLine(false); //591:46
                }
            }
            if (prop.Kind == MetaPropertyKind.Derived) //593:2
            {
                bool __tmp17_outputWritten = false;
                var __tmp18 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp18.Write("[" + Properties.CoreNs + ".DerivedAttribute]");
                var __tmp18Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp18.ToStringAndFree());
                bool __tmp18_last = __tmp18Reader.EndOfStream;
                while(!__tmp18_last)
                {
                    ReadOnlySpan<char> __tmp18_line = __tmp18Reader.ReadLine();
                    __tmp18_last = __tmp18Reader.EndOfStream;
                    if (!__tmp18_last || !__tmp18_line.IsEmpty)
                    {
                        __out.Write(__tmp18_line);
                        __tmp17_outputWritten = true;
                    }
                    if (!__tmp18_last || __tmp17_outputWritten) __out.AppendLine(true);
                }
                if (__tmp17_outputWritten)
                {
                    __out.AppendLine(false); //594:45
                }
            }
            if (prop.Kind == MetaPropertyKind.DerivedUnion) //596:2
            {
                bool __tmp20_outputWritten = false;
                var __tmp21 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp21.Write("[" + Properties.CoreNs + ".DerivedUnionAttribute]");
                var __tmp21Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp21.ToStringAndFree());
                bool __tmp21_last = __tmp21Reader.EndOfStream;
                while(!__tmp21_last)
                {
                    ReadOnlySpan<char> __tmp21_line = __tmp21Reader.ReadLine();
                    __tmp21_last = __tmp21Reader.EndOfStream;
                    if (!__tmp21_last || !__tmp21_line.IsEmpty)
                    {
                        __out.Write(__tmp21_line);
                        __tmp20_outputWritten = true;
                    }
                    if (!__tmp21_last || __tmp20_outputWritten) __out.AppendLine(true);
                }
                if (__tmp20_outputWritten)
                {
                    __out.AppendLine(false); //597:50
                }
            }
            var __loop29_results = 
                (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //599:7
                select new { p = p}
                ).ToList(); //599:2
            for (int __loop29_iteration = 0; __loop29_iteration < __loop29_results.Count; ++__loop29_iteration)
            {
                var __tmp22 = __loop29_results[__loop29_iteration];
                var p = __tmp22.p;
                bool __tmp24_outputWritten = false;
                var __tmp25 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp25.Write("[" + Properties.CoreNs + ".OppositeAttribute(typeof(");
                var __tmp25Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp25.ToStringAndFree());
                bool __tmp25_last = __tmp25Reader.EndOfStream;
                while(!__tmp25_last)
                {
                    ReadOnlySpan<char> __tmp25_line = __tmp25Reader.ReadLine();
                    __tmp25_last = __tmp25Reader.EndOfStream;
                    if (!__tmp25_last || !__tmp25_line.IsEmpty)
                    {
                        __out.Write(__tmp25_line);
                        __tmp24_outputWritten = true;
                    }
                    if (!__tmp25_last) __out.AppendLine(true);
                }
                var __tmp26 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp26.Write(CSharpName(p.Class, model, ClassKind.Descriptor, true));
                var __tmp26Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp26.ToStringAndFree());
                bool __tmp26_last = __tmp26Reader.EndOfStream;
                while(!__tmp26_last)
                {
                    ReadOnlySpan<char> __tmp26_line = __tmp26Reader.ReadLine();
                    __tmp26_last = __tmp26Reader.EndOfStream;
                    if (!__tmp26_last || !__tmp26_line.IsEmpty)
                    {
                        __out.Write(__tmp26_line);
                        __tmp24_outputWritten = true;
                    }
                    if (!__tmp26_last) __out.AppendLine(true);
                }
                var __tmp27 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp27.Write("), \"");
                var __tmp27Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp27.ToStringAndFree());
                bool __tmp27_last = __tmp27Reader.EndOfStream;
                while(!__tmp27_last)
                {
                    ReadOnlySpan<char> __tmp27_line = __tmp27Reader.ReadLine();
                    __tmp27_last = __tmp27Reader.EndOfStream;
                    if (!__tmp27_last || !__tmp27_line.IsEmpty)
                    {
                        __out.Write(__tmp27_line);
                        __tmp24_outputWritten = true;
                    }
                    if (!__tmp27_last) __out.AppendLine(true);
                }
                var __tmp28 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp28.Write(CSharpName(p, model));
                var __tmp28Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp28.ToStringAndFree());
                bool __tmp28_last = __tmp28Reader.EndOfStream;
                while(!__tmp28_last)
                {
                    ReadOnlySpan<char> __tmp28_line = __tmp28Reader.ReadLine();
                    __tmp28_last = __tmp28Reader.EndOfStream;
                    if (!__tmp28_last || !__tmp28_line.IsEmpty)
                    {
                        __out.Write(__tmp28_line);
                        __tmp24_outputWritten = true;
                    }
                    if (!__tmp28_last) __out.AppendLine(true);
                }
                var __tmp29 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp29.Write("\")]");
                var __tmp29Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp29.ToStringAndFree());
                bool __tmp29_last = __tmp29Reader.EndOfStream;
                while(!__tmp29_last)
                {
                    ReadOnlySpan<char> __tmp29_line = __tmp29Reader.ReadLine();
                    __tmp29_last = __tmp29Reader.EndOfStream;
                    if (!__tmp29_last || !__tmp29_line.IsEmpty)
                    {
                        __out.Write(__tmp29_line);
                        __tmp24_outputWritten = true;
                    }
                    if (!__tmp29_last || __tmp24_outputWritten) __out.AppendLine(true);
                }
                if (__tmp24_outputWritten)
                {
                    __out.AppendLine(false); //600:146
                }
            }
            var __loop30_results = 
                (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //602:7
                select new { p = p}
                ).ToList(); //602:2
            for (int __loop30_iteration = 0; __loop30_iteration < __loop30_results.Count; ++__loop30_iteration)
            {
                var __tmp30 = __loop30_results[__loop30_iteration];
                var p = __tmp30.p;
                if (cls.GetAllSuperClasses(true).Contains(p.Class)) //603:3
                {
                    bool __tmp32_outputWritten = false;
                    var __tmp33 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp33.Write("[" + Properties.CoreNs + ".SubsetsAttribute(typeof(");
                    var __tmp33Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp33.ToStringAndFree());
                    bool __tmp33_last = __tmp33Reader.EndOfStream;
                    while(!__tmp33_last)
                    {
                        ReadOnlySpan<char> __tmp33_line = __tmp33Reader.ReadLine();
                        __tmp33_last = __tmp33Reader.EndOfStream;
                        if (!__tmp33_last || !__tmp33_line.IsEmpty)
                        {
                            __out.Write(__tmp33_line);
                            __tmp32_outputWritten = true;
                        }
                        if (!__tmp33_last) __out.AppendLine(true);
                    }
                    var __tmp34 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp34.Write(CSharpName(p.Class, model, ClassKind.Descriptor, true));
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
                    var __tmp35 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp35.Write("), \"");
                    var __tmp35Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp35.ToStringAndFree());
                    bool __tmp35_last = __tmp35Reader.EndOfStream;
                    while(!__tmp35_last)
                    {
                        ReadOnlySpan<char> __tmp35_line = __tmp35Reader.ReadLine();
                        __tmp35_last = __tmp35Reader.EndOfStream;
                        if (!__tmp35_last || !__tmp35_line.IsEmpty)
                        {
                            __out.Write(__tmp35_line);
                            __tmp32_outputWritten = true;
                        }
                        if (!__tmp35_last) __out.AppendLine(true);
                    }
                    var __tmp36 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp36.Write(CSharpName(p, model));
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
                    var __tmp37 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp37.Write("\")]");
                    var __tmp37Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp37.ToStringAndFree());
                    bool __tmp37_last = __tmp37Reader.EndOfStream;
                    while(!__tmp37_last)
                    {
                        ReadOnlySpan<char> __tmp37_line = __tmp37Reader.ReadLine();
                        __tmp37_last = __tmp37Reader.EndOfStream;
                        if (!__tmp37_last || !__tmp37_line.IsEmpty)
                        {
                            __out.Write(__tmp37_line);
                            __tmp32_outputWritten = true;
                        }
                        if (!__tmp37_last || __tmp32_outputWritten) __out.AppendLine(true);
                    }
                    if (__tmp32_outputWritten)
                    {
                        __out.AppendLine(false); //604:145
                    }
                }
                else //605:3
                {
                    bool __tmp39_outputWritten = false;
                    string __tmp40_line = "// ERROR: subsetted property '"; //606:1
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Write(__tmp40_line);
                        __tmp39_outputWritten = true;
                    }
                    var __tmp41 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp41.Write(CSharpName(p, model, PropertyKind.Descriptor, true));
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
                    string __tmp42_line = "' must be a property of this class or an ancestor class"; //606:83
                    if (!string.IsNullOrEmpty(__tmp42_line))
                    {
                        __out.Write(__tmp42_line);
                        __tmp39_outputWritten = true;
                    }
                    if (__tmp39_outputWritten) __out.AppendLine(true);
                    if (__tmp39_outputWritten)
                    {
                        __out.AppendLine(false); //606:138
                    }
                }
            }
            var __loop31_results = 
                (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //609:7
                select new { p = p}
                ).ToList(); //609:2
            for (int __loop31_iteration = 0; __loop31_iteration < __loop31_results.Count; ++__loop31_iteration)
            {
                var __tmp43 = __loop31_results[__loop31_iteration];
                var p = __tmp43.p;
                if (cls.GetAllSuperClasses(true).Contains(p.Class)) //610:3
                {
                    bool __tmp45_outputWritten = false;
                    var __tmp46 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp46.Write("[" + Properties.CoreNs + ".RedefinesAttribute(typeof(");
                    var __tmp46Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp46.ToStringAndFree());
                    bool __tmp46_last = __tmp46Reader.EndOfStream;
                    while(!__tmp46_last)
                    {
                        ReadOnlySpan<char> __tmp46_line = __tmp46Reader.ReadLine();
                        __tmp46_last = __tmp46Reader.EndOfStream;
                        if (!__tmp46_last || !__tmp46_line.IsEmpty)
                        {
                            __out.Write(__tmp46_line);
                            __tmp45_outputWritten = true;
                        }
                        if (!__tmp46_last) __out.AppendLine(true);
                    }
                    var __tmp47 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp47.Write(CSharpName(p.Class, model, ClassKind.Descriptor, true));
                    var __tmp47Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp47.ToStringAndFree());
                    bool __tmp47_last = __tmp47Reader.EndOfStream;
                    while(!__tmp47_last)
                    {
                        ReadOnlySpan<char> __tmp47_line = __tmp47Reader.ReadLine();
                        __tmp47_last = __tmp47Reader.EndOfStream;
                        if (!__tmp47_last || !__tmp47_line.IsEmpty)
                        {
                            __out.Write(__tmp47_line);
                            __tmp45_outputWritten = true;
                        }
                        if (!__tmp47_last) __out.AppendLine(true);
                    }
                    var __tmp48 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp48.Write("), \"");
                    var __tmp48Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp48.ToStringAndFree());
                    bool __tmp48_last = __tmp48Reader.EndOfStream;
                    while(!__tmp48_last)
                    {
                        ReadOnlySpan<char> __tmp48_line = __tmp48Reader.ReadLine();
                        __tmp48_last = __tmp48Reader.EndOfStream;
                        if (!__tmp48_last || !__tmp48_line.IsEmpty)
                        {
                            __out.Write(__tmp48_line);
                            __tmp45_outputWritten = true;
                        }
                        if (!__tmp48_last) __out.AppendLine(true);
                    }
                    var __tmp49 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp49.Write(CSharpName(p, model));
                    var __tmp49Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp49.ToStringAndFree());
                    bool __tmp49_last = __tmp49Reader.EndOfStream;
                    while(!__tmp49_last)
                    {
                        ReadOnlySpan<char> __tmp49_line = __tmp49Reader.ReadLine();
                        __tmp49_last = __tmp49Reader.EndOfStream;
                        if (!__tmp49_last || !__tmp49_line.IsEmpty)
                        {
                            __out.Write(__tmp49_line);
                            __tmp45_outputWritten = true;
                        }
                        if (!__tmp49_last) __out.AppendLine(true);
                    }
                    var __tmp50 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp50.Write("\")]");
                    var __tmp50Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp50.ToStringAndFree());
                    bool __tmp50_last = __tmp50Reader.EndOfStream;
                    while(!__tmp50_last)
                    {
                        ReadOnlySpan<char> __tmp50_line = __tmp50Reader.ReadLine();
                        __tmp50_last = __tmp50Reader.EndOfStream;
                        if (!__tmp50_last || !__tmp50_line.IsEmpty)
                        {
                            __out.Write(__tmp50_line);
                            __tmp45_outputWritten = true;
                        }
                        if (!__tmp50_last || __tmp45_outputWritten) __out.AppendLine(true);
                    }
                    if (__tmp45_outputWritten)
                    {
                        __out.AppendLine(false); //611:147
                    }
                }
                else //612:3
                {
                    bool __tmp52_outputWritten = false;
                    string __tmp53_line = "// ERROR: redefined property '"; //613:1
                    if (!string.IsNullOrEmpty(__tmp53_line))
                    {
                        __out.Write(__tmp53_line);
                        __tmp52_outputWritten = true;
                    }
                    var __tmp54 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp54.Write(CSharpName(p, model, PropertyKind.Descriptor, true));
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
                    string __tmp55_line = "' must be a property of this class or an ancestor class"; //613:83
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Write(__tmp55_line);
                        __tmp52_outputWritten = true;
                    }
                    if (__tmp52_outputWritten) __out.AppendLine(true);
                    if (__tmp52_outputWritten)
                    {
                        __out.AppendLine(false); //613:138
                    }
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateImplementationProvider(MetaModel model) //618:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //619:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Write(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp4.Write(CSharpName(model, ModelKind.ImplementationProvider));
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
                __out.AppendLine(false); //619:68
            }
            __out.Write("{"); //620:1
            __out.AppendLine(false); //620:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	// If there is a compile error at this line, create a new class called "; //621:1
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp6_outputWritten = true;
            }
            var __tmp8 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp8.Write(CSharpName(model, ModelKind.Implementation));
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
                __out.AppendLine(false); //621:117
            }
            bool __tmp10_outputWritten = false;
            string __tmp11_line = "	// which is a subclass of "; //622:1
            if (!string.IsNullOrEmpty(__tmp11_line))
            {
                __out.Write(__tmp11_line);
                __tmp10_outputWritten = true;
            }
            var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp12.Write(CSharpName(model, ModelKind.ImplementationBase, true));
            var __tmp12Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp12.ToStringAndFree());
            bool __tmp12_last = __tmp12Reader.EndOfStream;
            while(!__tmp12_last)
            {
                ReadOnlySpan<char> __tmp12_line = __tmp12Reader.ReadLine();
                __tmp12_last = __tmp12Reader.EndOfStream;
                if (!__tmp12_last || !__tmp12_line.IsEmpty)
                {
                    __out.Write(__tmp12_line);
                    __tmp10_outputWritten = true;
                }
                if (!__tmp12_last) __out.AppendLine(true);
            }
            string __tmp13_line = ":"; //622:82
            if (!string.IsNullOrEmpty(__tmp13_line))
            {
                __out.Write(__tmp13_line);
                __tmp10_outputWritten = true;
            }
            if (__tmp10_outputWritten) __out.AppendLine(true);
            if (__tmp10_outputWritten)
            {
                __out.AppendLine(false); //622:83
            }
            bool __tmp15_outputWritten = false;
            string __tmp16_line = "	private static "; //623:1
            if (!string.IsNullOrEmpty(__tmp16_line))
            {
                __out.Write(__tmp16_line);
                __tmp15_outputWritten = true;
            }
            var __tmp17 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp17.Write(CSharpName(model, ModelKind.Implementation));
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
            string __tmp18_line = " implementation = new "; //623:61
            if (!string.IsNullOrEmpty(__tmp18_line))
            {
                __out.Write(__tmp18_line);
                __tmp15_outputWritten = true;
            }
            var __tmp19 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp19.Write(CSharpName(model, ModelKind.Implementation));
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
            string __tmp20_line = "();"; //623:127
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Write(__tmp20_line);
                __tmp15_outputWritten = true;
            }
            if (__tmp15_outputWritten) __out.AppendLine(true);
            if (__tmp15_outputWritten)
            {
                __out.AppendLine(false); //623:130
            }
            __out.AppendLine(true); //624:1
            bool __tmp22_outputWritten = false;
            string __tmp23_line = "	public static "; //625:1
            if (!string.IsNullOrEmpty(__tmp23_line))
            {
                __out.Write(__tmp23_line);
                __tmp22_outputWritten = true;
            }
            var __tmp24 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp24.Write(CSharpName(model, ModelKind.Implementation));
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
            string __tmp25_line = " Implementation"; //625:60
            if (!string.IsNullOrEmpty(__tmp25_line))
            {
                __out.Write(__tmp25_line);
                __tmp22_outputWritten = true;
            }
            if (__tmp22_outputWritten) __out.AppendLine(true);
            if (__tmp22_outputWritten)
            {
                __out.AppendLine(false); //625:75
            }
            __out.Write("	{"); //626:1
            __out.AppendLine(false); //626:3
            __out.Write("		get { return implementation; }"); //627:1
            __out.AppendLine(false); //627:33
            __out.Write("	}"); //628:1
            __out.AppendLine(false); //628:3
            __out.Write("}"); //629:1
            __out.AppendLine(false); //629:2
            return __out.ToStringAndFree();
        }

        public string GenerateImplementationBase(MetaModel model) //632:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //633:2
            bool metaMetaModel = IsMetaMetaModel(model); //634:2
            __out.Write("/// <summary>"); //635:1
            __out.AppendLine(false); //635:14
            __out.Write("/// Base class for implementing the behavior of the model elements."); //636:1
            __out.AppendLine(false); //636:68
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "/// This class has to be be overriden in "; //637:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Write(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp4.Write(CSharpName(model, ModelKind.Implementation, true));
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
            string __tmp5_line = " to provide custom"; //637:92
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //637:110
            }
            __out.Write("/// implementation for the constructors, operations and property values."); //638:1
            __out.AppendLine(false); //638:73
            __out.Write("/// </summary>"); //639:1
            __out.AppendLine(false); //639:15
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "internal abstract class "; //640:1
            if (!string.IsNullOrEmpty(__tmp8_line))
            {
                __out.Write(__tmp8_line);
                __tmp7_outputWritten = true;
            }
            var __tmp9 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp9.Write(CSharpName(model, ModelKind.ImplementationBase));
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
                if (!__tmp9_last || __tmp7_outputWritten) __out.AppendLine(true);
            }
            if (__tmp7_outputWritten)
            {
                __out.AppendLine(false); //640:73
            }
            __out.Write("{"); //641:1
            __out.AppendLine(false); //641:2
            __out.Write("	/// <summary>"); //642:1
            __out.AppendLine(false); //642:15
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	/// Implements the constructor: "; //643:1
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Write(__tmp12_line);
                __tmp11_outputWritten = true;
            }
            var __tmp13 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp13.Write(CSharpName(model, ModelKind.BuilderInstance));
            var __tmp13Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp13.ToStringAndFree());
            bool __tmp13_last = __tmp13Reader.EndOfStream;
            while(!__tmp13_last)
            {
                ReadOnlySpan<char> __tmp13_line = __tmp13Reader.ReadLine();
                __tmp13_last = __tmp13Reader.EndOfStream;
                if (!__tmp13_last || !__tmp13_line.IsEmpty)
                {
                    __out.Write(__tmp13_line);
                    __tmp11_outputWritten = true;
                }
                if (!__tmp13_last) __out.AppendLine(true);
            }
            string __tmp14_line = "()"; //643:79
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //643:81
            }
            __out.Write("	/// </summary>"); //644:1
            __out.AppendLine(false); //644:16
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "	internal virtual void "; //645:1
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Write(__tmp17_line);
                __tmp16_outputWritten = true;
            }
            var __tmp18 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp18.Write(CSharpName(model, ModelKind.BuilderInstance));
            var __tmp18Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp18.ToStringAndFree());
            bool __tmp18_last = __tmp18Reader.EndOfStream;
            while(!__tmp18_last)
            {
                ReadOnlySpan<char> __tmp18_line = __tmp18Reader.ReadLine();
                __tmp18_last = __tmp18Reader.EndOfStream;
                if (!__tmp18_last || !__tmp18_line.IsEmpty)
                {
                    __out.Write(__tmp18_line);
                    __tmp16_outputWritten = true;
                }
                if (!__tmp18_last) __out.AppendLine(true);
            }
            string __tmp19_line = "("; //645:69
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Write(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            var __tmp20 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp20.Write(CSharpName(model, ModelKind.BuilderInstance));
            var __tmp20Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp20.ToStringAndFree());
            bool __tmp20_last = __tmp20Reader.EndOfStream;
            while(!__tmp20_last)
            {
                ReadOnlySpan<char> __tmp20_line = __tmp20Reader.ReadLine();
                __tmp20_last = __tmp20Reader.EndOfStream;
                if (!__tmp20_last || !__tmp20_line.IsEmpty)
                {
                    __out.Write(__tmp20_line);
                    __tmp16_outputWritten = true;
                }
                if (!__tmp20_last) __out.AppendLine(true);
            }
            string __tmp21_line = " _this)"; //645:115
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //645:122
            }
            __out.Write("	{"); //646:1
            __out.AppendLine(false); //646:3
            __out.Write("	}"); //647:1
            __out.AppendLine(false); //647:3
            var __loop32_results = 
                (from __loop32_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //648:8
                from cls in __Enumerate((__loop32_var1).GetEnumerator()).OfType<MetaClass>() //648:38
                select new { __loop32_var1 = __loop32_var1, cls = cls}
                ).ToList(); //648:3
            for (int __loop32_iteration = 0; __loop32_iteration < __loop32_results.Count; ++__loop32_iteration)
            {
                var __tmp22 = __loop32_results[__loop32_iteration];
                var __loop32_var1 = __tmp22.__loop32_var1;
                var cls = __tmp22.cls;
                __out.AppendLine(true); //649:1
                __out.Write("	/// <summary>"); //650:1
                __out.AppendLine(false); //650:15
                bool __tmp24_outputWritten = false;
                string __tmp25_line = "	/// Implements the constructor: "; //651:1
                if (!string.IsNullOrEmpty(__tmp25_line))
                {
                    __out.Write(__tmp25_line);
                    __tmp24_outputWritten = true;
                }
                var __tmp26 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp26.Write(CSharpName(cls, model, ClassKind.Immutable));
                var __tmp26Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp26.ToStringAndFree());
                bool __tmp26_last = __tmp26Reader.EndOfStream;
                while(!__tmp26_last)
                {
                    ReadOnlySpan<char> __tmp26_line = __tmp26Reader.ReadLine();
                    __tmp26_last = __tmp26Reader.EndOfStream;
                    if (!__tmp26_last || !__tmp26_line.IsEmpty)
                    {
                        __out.Write(__tmp26_line);
                        __tmp24_outputWritten = true;
                    }
                    if (!__tmp26_last) __out.AppendLine(true);
                }
                string __tmp27_line = "()"; //651:78
                if (!string.IsNullOrEmpty(__tmp27_line))
                {
                    __out.Write(__tmp27_line);
                    __tmp24_outputWritten = true;
                }
                if (__tmp24_outputWritten) __out.AppendLine(true);
                if (__tmp24_outputWritten)
                {
                    __out.AppendLine(false); //651:80
                }
                __out.Write("	/// </summary>"); //652:1
                __out.AppendLine(false); //652:16
                if ((from __loop33_var1 in __Enumerate((cls).GetEnumerator()) //653:15
                from sup in __Enumerate((__loop33_var1.SuperClasses).GetEnumerator()) //653:20
                select new { __loop33_var1 = __loop33_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //653:3
                {
                    __out.Write("	/// Direct superclasses: "); //654:1
                    __out.AppendLine(false); //654:27
                    __out.Write("	/// <ul>"); //655:1
                    __out.AppendLine(false); //655:10
                    var __loop34_results = 
                        (from __loop34_var1 in __Enumerate((cls).GetEnumerator()) //656:8
                        from sup in __Enumerate((__loop34_var1.SuperClasses).GetEnumerator()) //656:13
                        select new { __loop34_var1 = __loop34_var1, sup = sup}
                        ).ToList(); //656:3
                    for (int __loop34_iteration = 0; __loop34_iteration < __loop34_results.Count; ++__loop34_iteration)
                    {
                        var __tmp28 = __loop34_results[__loop34_iteration];
                        var __loop34_var1 = __tmp28.__loop34_var1;
                        var sup = __tmp28.sup;
                        bool __tmp30_outputWritten = false;
                        string __tmp31_line = "	///     <li>"; //657:1
                        if (!string.IsNullOrEmpty(__tmp31_line))
                        {
                            __out.Write(__tmp31_line);
                            __tmp30_outputWritten = true;
                        }
                        var __tmp32 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp32.Write(CSharpName(sup, model, ClassKind.Immutable, true));
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
                        string __tmp33_line = "</li>"; //657:64
                        if (!string.IsNullOrEmpty(__tmp33_line))
                        {
                            __out.Write(__tmp33_line);
                            __tmp30_outputWritten = true;
                        }
                        if (__tmp30_outputWritten) __out.AppendLine(true);
                        if (__tmp30_outputWritten)
                        {
                            __out.AppendLine(false); //657:69
                        }
                    }
                    __out.Write("	/// </ul>"); //659:1
                    __out.AppendLine(false); //659:11
                    __out.Write("	/// All superclasses:"); //660:1
                    __out.AppendLine(false); //660:23
                    __out.Write("	/// <ul>"); //661:1
                    __out.AppendLine(false); //661:10
                    var __loop35_results = 
                        (from __loop35_var1 in __Enumerate((cls).GetEnumerator()) //662:8
                        from sup in __Enumerate((__loop35_var1.GetAllSuperClasses(false)).GetEnumerator()) //662:13
                        select new { __loop35_var1 = __loop35_var1, sup = sup}
                        ).ToList(); //662:3
                    for (int __loop35_iteration = 0; __loop35_iteration < __loop35_results.Count; ++__loop35_iteration)
                    {
                        var __tmp34 = __loop35_results[__loop35_iteration];
                        var __loop35_var1 = __tmp34.__loop35_var1;
                        var sup = __tmp34.sup;
                        bool __tmp36_outputWritten = false;
                        string __tmp37_line = "	///     <li>"; //663:1
                        if (!string.IsNullOrEmpty(__tmp37_line))
                        {
                            __out.Write(__tmp37_line);
                            __tmp36_outputWritten = true;
                        }
                        var __tmp38 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp38.Write(CSharpName(sup, model, ClassKind.Immutable, true));
                        var __tmp38Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp38.ToStringAndFree());
                        bool __tmp38_last = __tmp38Reader.EndOfStream;
                        while(!__tmp38_last)
                        {
                            ReadOnlySpan<char> __tmp38_line = __tmp38Reader.ReadLine();
                            __tmp38_last = __tmp38Reader.EndOfStream;
                            if (!__tmp38_last || !__tmp38_line.IsEmpty)
                            {
                                __out.Write(__tmp38_line);
                                __tmp36_outputWritten = true;
                            }
                            if (!__tmp38_last) __out.AppendLine(true);
                        }
                        string __tmp39_line = "</li>"; //663:64
                        if (!string.IsNullOrEmpty(__tmp39_line))
                        {
                            __out.Write(__tmp39_line);
                            __tmp36_outputWritten = true;
                        }
                        if (__tmp36_outputWritten) __out.AppendLine(true);
                        if (__tmp36_outputWritten)
                        {
                            __out.AppendLine(false); //663:69
                        }
                    }
                    __out.Write("	/// </ul>"); //665:1
                    __out.AppendLine(false); //665:11
                }
                if ((from __loop36_var1 in __Enumerate((cls).GetEnumerator()) //667:15
                from prop in __Enumerate((__loop36_var1.Properties).GetEnumerator()) //667:20
                where prop.Kind == MetaPropertyKind.Readonly //667:36
                select new { __loop36_var1 = __loop36_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //667:3
                {
                    __out.Write("	/// Initializes the following readonly properties:"); //668:1
                    __out.AppendLine(false); //668:52
                    __out.Write("	/// <ul>"); //669:1
                    __out.AppendLine(false); //669:10
                    var __loop37_results = 
                        (from __loop37_var1 in __Enumerate((cls).GetEnumerator()) //670:8
                        from prop in __Enumerate((__loop37_var1.Properties).GetEnumerator()) //670:13
                        where prop.Kind == MetaPropertyKind.Readonly //670:29
                        select new { __loop37_var1 = __loop37_var1, prop = prop}
                        ).ToList(); //670:3
                    for (int __loop37_iteration = 0; __loop37_iteration < __loop37_results.Count; ++__loop37_iteration)
                    {
                        var __tmp40 = __loop37_results[__loop37_iteration];
                        var __loop37_var1 = __tmp40.__loop37_var1;
                        var prop = __tmp40.prop;
                        bool __tmp42_outputWritten = false;
                        string __tmp43_line = "	///     <li>"; //671:1
                        if (!string.IsNullOrEmpty(__tmp43_line))
                        {
                            __out.Write(__tmp43_line);
                            __tmp42_outputWritten = true;
                        }
                        var __tmp44 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp44.Write(CSharpName(prop, model));
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
                        string __tmp45_line = "</li>"; //671:38
                        if (!string.IsNullOrEmpty(__tmp45_line))
                        {
                            __out.Write(__tmp45_line);
                            __tmp42_outputWritten = true;
                        }
                        if (__tmp42_outputWritten) __out.AppendLine(true);
                        if (__tmp42_outputWritten)
                        {
                            __out.AppendLine(false); //671:43
                        }
                    }
                    __out.Write("	/// </ul>"); //673:1
                    __out.AppendLine(false); //673:11
                }
                if ((from __loop38_var1 in __Enumerate((cls).GetEnumerator()) //675:15
                from prop in __Enumerate((__loop38_var1.Properties).GetEnumerator()) //675:20
                where prop.Kind == MetaPropertyKind.Lazy //675:36
                select new { __loop38_var1 = __loop38_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //675:3
                {
                    __out.Write("	/// Initializes the following lazy properties:"); //676:1
                    __out.AppendLine(false); //676:48
                    __out.Write("	/// <ul>"); //677:1
                    __out.AppendLine(false); //677:10
                    var __loop39_results = 
                        (from __loop39_var1 in __Enumerate((cls).GetEnumerator()) //678:8
                        from prop in __Enumerate((__loop39_var1.Properties).GetEnumerator()) //678:13
                        where prop.Kind == MetaPropertyKind.Lazy //678:29
                        select new { __loop39_var1 = __loop39_var1, prop = prop}
                        ).ToList(); //678:3
                    for (int __loop39_iteration = 0; __loop39_iteration < __loop39_results.Count; ++__loop39_iteration)
                    {
                        var __tmp46 = __loop39_results[__loop39_iteration];
                        var __loop39_var1 = __tmp46.__loop39_var1;
                        var prop = __tmp46.prop;
                        bool __tmp48_outputWritten = false;
                        string __tmp49_line = "	///     <li>"; //679:1
                        if (!string.IsNullOrEmpty(__tmp49_line))
                        {
                            __out.Write(__tmp49_line);
                            __tmp48_outputWritten = true;
                        }
                        var __tmp50 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp50.Write(CSharpName(prop, model));
                        var __tmp50Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp50.ToStringAndFree());
                        bool __tmp50_last = __tmp50Reader.EndOfStream;
                        while(!__tmp50_last)
                        {
                            ReadOnlySpan<char> __tmp50_line = __tmp50Reader.ReadLine();
                            __tmp50_last = __tmp50Reader.EndOfStream;
                            if (!__tmp50_last || !__tmp50_line.IsEmpty)
                            {
                                __out.Write(__tmp50_line);
                                __tmp48_outputWritten = true;
                            }
                            if (!__tmp50_last) __out.AppendLine(true);
                        }
                        string __tmp51_line = "</li>"; //679:38
                        if (!string.IsNullOrEmpty(__tmp51_line))
                        {
                            __out.Write(__tmp51_line);
                            __tmp48_outputWritten = true;
                        }
                        if (__tmp48_outputWritten) __out.AppendLine(true);
                        if (__tmp48_outputWritten)
                        {
                            __out.AppendLine(false); //679:43
                        }
                    }
                    __out.Write("	/// </ul>"); //681:1
                    __out.AppendLine(false); //681:11
                }
                if ((from __loop40_var1 in __Enumerate((cls).GetEnumerator()) //683:15
                from prop in __Enumerate((__loop40_var1.Properties).GetEnumerator()) //683:20
                where prop.Kind == MetaPropertyKind.Derived //683:36
                select new { __loop40_var1 = __loop40_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //683:3
                {
                    __out.Write("	/// Initializes the following derived properties:"); //684:1
                    __out.AppendLine(false); //684:51
                    __out.Write("	/// <ul>"); //685:1
                    __out.AppendLine(false); //685:10
                    var __loop41_results = 
                        (from __loop41_var1 in __Enumerate((cls).GetEnumerator()) //686:8
                        from prop in __Enumerate((__loop41_var1.Properties).GetEnumerator()) //686:13
                        where prop.Kind == MetaPropertyKind.Derived //686:29
                        select new { __loop41_var1 = __loop41_var1, prop = prop}
                        ).ToList(); //686:3
                    for (int __loop41_iteration = 0; __loop41_iteration < __loop41_results.Count; ++__loop41_iteration)
                    {
                        var __tmp52 = __loop41_results[__loop41_iteration];
                        var __loop41_var1 = __tmp52.__loop41_var1;
                        var prop = __tmp52.prop;
                        bool __tmp54_outputWritten = false;
                        string __tmp55_line = "	///     <li>"; //687:1
                        if (!string.IsNullOrEmpty(__tmp55_line))
                        {
                            __out.Write(__tmp55_line);
                            __tmp54_outputWritten = true;
                        }
                        var __tmp56 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp56.Write(CSharpName(prop, model));
                        var __tmp56Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp56.ToStringAndFree());
                        bool __tmp56_last = __tmp56Reader.EndOfStream;
                        while(!__tmp56_last)
                        {
                            ReadOnlySpan<char> __tmp56_line = __tmp56Reader.ReadLine();
                            __tmp56_last = __tmp56Reader.EndOfStream;
                            if (!__tmp56_last || !__tmp56_line.IsEmpty)
                            {
                                __out.Write(__tmp56_line);
                                __tmp54_outputWritten = true;
                            }
                            if (!__tmp56_last) __out.AppendLine(true);
                        }
                        string __tmp57_line = "</li>"; //687:38
                        if (!string.IsNullOrEmpty(__tmp57_line))
                        {
                            __out.Write(__tmp57_line);
                            __tmp54_outputWritten = true;
                        }
                        if (__tmp54_outputWritten) __out.AppendLine(true);
                        if (__tmp54_outputWritten)
                        {
                            __out.AppendLine(false); //687:43
                        }
                    }
                    __out.Write("	/// </ul>"); //689:1
                    __out.AppendLine(false); //689:11
                }
                bool __tmp59_outputWritten = false;
                string __tmp60_line = "	public virtual void "; //691:1
                if (!string.IsNullOrEmpty(__tmp60_line))
                {
                    __out.Write(__tmp60_line);
                    __tmp59_outputWritten = true;
                }
                var __tmp61 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp61.Write(CSharpName(cls, model, ClassKind.Immutable));
                var __tmp61Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp61.ToStringAndFree());
                bool __tmp61_last = __tmp61Reader.EndOfStream;
                while(!__tmp61_last)
                {
                    ReadOnlySpan<char> __tmp61_line = __tmp61Reader.ReadLine();
                    __tmp61_last = __tmp61Reader.EndOfStream;
                    if (!__tmp61_last || !__tmp61_line.IsEmpty)
                    {
                        __out.Write(__tmp61_line);
                        __tmp59_outputWritten = true;
                    }
                    if (!__tmp61_last) __out.AppendLine(true);
                }
                string __tmp62_line = "("; //691:66
                if (!string.IsNullOrEmpty(__tmp62_line))
                {
                    __out.Write(__tmp62_line);
                    __tmp59_outputWritten = true;
                }
                var __tmp63 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp63.Write(CSharpName(cls, model, ClassKind.Builder));
                var __tmp63Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp63.ToStringAndFree());
                bool __tmp63_last = __tmp63Reader.EndOfStream;
                while(!__tmp63_last)
                {
                    ReadOnlySpan<char> __tmp63_line = __tmp63Reader.ReadLine();
                    __tmp63_last = __tmp63Reader.EndOfStream;
                    if (!__tmp63_last || !__tmp63_line.IsEmpty)
                    {
                        __out.Write(__tmp63_line);
                        __tmp59_outputWritten = true;
                    }
                    if (!__tmp63_last) __out.AppendLine(true);
                }
                string __tmp64_line = " _this)"; //691:109
                if (!string.IsNullOrEmpty(__tmp64_line))
                {
                    __out.Write(__tmp64_line);
                    __tmp59_outputWritten = true;
                }
                if (__tmp59_outputWritten) __out.AppendLine(true);
                if (__tmp59_outputWritten)
                {
                    __out.AppendLine(false); //691:116
                }
                __out.Write("	{"); //692:1
                __out.AppendLine(false); //692:3
                bool __tmp66_outputWritten = false;
                string __tmp67_line = "		this.Call"; //693:1
                if (!string.IsNullOrEmpty(__tmp67_line))
                {
                    __out.Write(__tmp67_line);
                    __tmp66_outputWritten = true;
                }
                var __tmp68 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp68.Write(CSharpName(cls, model, ClassKind.Immutable));
                var __tmp68Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp68.ToStringAndFree());
                bool __tmp68_last = __tmp68Reader.EndOfStream;
                while(!__tmp68_last)
                {
                    ReadOnlySpan<char> __tmp68_line = __tmp68Reader.ReadLine();
                    __tmp68_last = __tmp68Reader.EndOfStream;
                    if (!__tmp68_last || !__tmp68_line.IsEmpty)
                    {
                        __out.Write(__tmp68_line);
                        __tmp66_outputWritten = true;
                    }
                    if (!__tmp68_last) __out.AppendLine(true);
                }
                string __tmp69_line = "SuperConstructors(_this);"; //693:56
                if (!string.IsNullOrEmpty(__tmp69_line))
                {
                    __out.Write(__tmp69_line);
                    __tmp66_outputWritten = true;
                }
                if (__tmp66_outputWritten) __out.AppendLine(true);
                if (__tmp66_outputWritten)
                {
                    __out.AppendLine(false); //693:81
                }
                var __loop42_results = 
                    (from __loop42_var1 in __Enumerate((cls).GetEnumerator()) //694:9
                    from prop in __Enumerate((__loop42_var1.GetAllFinalProperties()).GetEnumerator()) //694:14
                    select new { __loop42_var1 = __loop42_var1, prop = prop}
                    ).ToList(); //694:4
                for (int __loop42_iteration = 0; __loop42_iteration < __loop42_results.Count; ++__loop42_iteration)
                {
                    var __tmp70 = __loop42_results[__loop42_iteration];
                    var __loop42_var1 = __tmp70.__loop42_var1;
                    var prop = __tmp70.prop;
                    if (metaMetaModel && cls.Name == "MetaConstant" && prop.Name == "Value") //695:5
                    {
                    }
                    else if (prop.DefaultValue != null) //696:5
                    {
                        if (!(prop.Type is MetaCollectionType)) //697:6
                        {
                            bool __tmp72_outputWritten = false;
                            string __tmp73_line = "		_this.Set"; //698:1
                            if (!string.IsNullOrEmpty(__tmp73_line))
                            {
                                __out.Write(__tmp73_line);
                                __tmp72_outputWritten = true;
                            }
                            var __tmp74 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp74.Write(CSharpName(prop, model, PropertyKind.Builder));
                            var __tmp74Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp74.ToStringAndFree());
                            bool __tmp74_last = __tmp74Reader.EndOfStream;
                            while(!__tmp74_last)
                            {
                                ReadOnlySpan<char> __tmp74_line = __tmp74Reader.ReadLine();
                                __tmp74_last = __tmp74Reader.EndOfStream;
                                if (!__tmp74_last || !__tmp74_line.IsEmpty)
                                {
                                    __out.Write(__tmp74_line);
                                    __tmp72_outputWritten = true;
                                }
                                if (!__tmp74_last) __out.AppendLine(true);
                            }
                            string __tmp75_line = "Lazy(() => "; //698:58
                            if (!string.IsNullOrEmpty(__tmp75_line))
                            {
                                __out.Write(__tmp75_line);
                                __tmp72_outputWritten = true;
                            }
                            var __tmp76 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp76.Write(prop.DefaultValue);
                            var __tmp76Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp76.ToStringAndFree());
                            bool __tmp76_last = __tmp76Reader.EndOfStream;
                            while(!__tmp76_last)
                            {
                                ReadOnlySpan<char> __tmp76_line = __tmp76Reader.ReadLine();
                                __tmp76_last = __tmp76Reader.EndOfStream;
                                if (!__tmp76_last || !__tmp76_line.IsEmpty)
                                {
                                    __out.Write(__tmp76_line);
                                    __tmp72_outputWritten = true;
                                }
                                if (!__tmp76_last) __out.AppendLine(true);
                            }
                            string __tmp77_line = ");"; //698:88
                            if (!string.IsNullOrEmpty(__tmp77_line))
                            {
                                __out.Write(__tmp77_line);
                                __tmp72_outputWritten = true;
                            }
                            if (__tmp72_outputWritten) __out.AppendLine(true);
                            if (__tmp72_outputWritten)
                            {
                                __out.AppendLine(false); //698:90
                            }
                        }
                        else //699:6
                        {
                            __out.Write("		// ERROR: default value for collection"); //700:1
                            __out.AppendLine(false); //700:41
                            bool __tmp79_outputWritten = false;
                            string __tmp80_line = "		// _this."; //701:1
                            if (!string.IsNullOrEmpty(__tmp80_line))
                            {
                                __out.Write(__tmp80_line);
                                __tmp79_outputWritten = true;
                            }
                            var __tmp81 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp81.Write(CSharpName(prop, model, PropertyKind.Builder));
                            var __tmp81Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp81.ToStringAndFree());
                            bool __tmp81_last = __tmp81Reader.EndOfStream;
                            while(!__tmp81_last)
                            {
                                ReadOnlySpan<char> __tmp81_line = __tmp81Reader.ReadLine();
                                __tmp81_last = __tmp81Reader.EndOfStream;
                                if (!__tmp81_last || !__tmp81_line.IsEmpty)
                                {
                                    __out.Write(__tmp81_line);
                                    __tmp79_outputWritten = true;
                                }
                                if (!__tmp81_last) __out.AppendLine(true);
                            }
                            string __tmp82_line = " = "; //701:58
                            if (!string.IsNullOrEmpty(__tmp82_line))
                            {
                                __out.Write(__tmp82_line);
                                __tmp79_outputWritten = true;
                            }
                            var __tmp83 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp83.Write(prop.DefaultValue);
                            var __tmp83Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp83.ToStringAndFree());
                            bool __tmp83_last = __tmp83Reader.EndOfStream;
                            while(!__tmp83_last)
                            {
                                ReadOnlySpan<char> __tmp83_line = __tmp83Reader.ReadLine();
                                __tmp83_last = __tmp83Reader.EndOfStream;
                                if (!__tmp83_last || !__tmp83_line.IsEmpty)
                                {
                                    __out.Write(__tmp83_line);
                                    __tmp79_outputWritten = true;
                                }
                                if (!__tmp83_last) __out.AppendLine(true);
                            }
                            string __tmp84_line = ";"; //701:80
                            if (!string.IsNullOrEmpty(__tmp84_line))
                            {
                                __out.Write(__tmp84_line);
                                __tmp79_outputWritten = true;
                            }
                            if (__tmp79_outputWritten) __out.AppendLine(true);
                            if (__tmp79_outputWritten)
                            {
                                __out.AppendLine(false); //701:81
                            }
                        }
                    }
                    else if (prop.Kind == MetaPropertyKind.Lazy || prop.Kind == MetaPropertyKind.Derived) //703:5
                    {
                        if (!(prop.Type is MetaCollectionType)) //704:6
                        {
                            bool __tmp86_outputWritten = false;
                            string __tmp87_line = "		_this.Set"; //705:1
                            if (!string.IsNullOrEmpty(__tmp87_line))
                            {
                                __out.Write(__tmp87_line);
                                __tmp86_outputWritten = true;
                            }
                            var __tmp88 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp88.Write(CSharpName(prop, model, PropertyKind.Builder));
                            var __tmp88Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp88.ToStringAndFree());
                            bool __tmp88_last = __tmp88Reader.EndOfStream;
                            while(!__tmp88_last)
                            {
                                ReadOnlySpan<char> __tmp88_line = __tmp88Reader.ReadLine();
                                __tmp88_last = __tmp88Reader.EndOfStream;
                                if (!__tmp88_last || !__tmp88_line.IsEmpty)
                                {
                                    __out.Write(__tmp88_line);
                                    __tmp86_outputWritten = true;
                                }
                                if (!__tmp88_last) __out.AppendLine(true);
                            }
                            string __tmp89_line = "Lazy(this."; //705:58
                            if (!string.IsNullOrEmpty(__tmp89_line))
                            {
                                __out.Write(__tmp89_line);
                                __tmp86_outputWritten = true;
                            }
                            var __tmp90 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp90.Write(CSharpName(prop.Class, model, ClassKind.Immutable));
                            var __tmp90Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp90.ToStringAndFree());
                            bool __tmp90_last = __tmp90Reader.EndOfStream;
                            while(!__tmp90_last)
                            {
                                ReadOnlySpan<char> __tmp90_line = __tmp90Reader.ReadLine();
                                __tmp90_last = __tmp90Reader.EndOfStream;
                                if (!__tmp90_last || !__tmp90_line.IsEmpty)
                                {
                                    __out.Write(__tmp90_line);
                                    __tmp86_outputWritten = true;
                                }
                                if (!__tmp90_last) __out.AppendLine(true);
                            }
                            string __tmp91_line = "_ComputeProperty_"; //705:119
                            if (!string.IsNullOrEmpty(__tmp91_line))
                            {
                                __out.Write(__tmp91_line);
                                __tmp86_outputWritten = true;
                            }
                            var __tmp92 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp92.Write(CSharpName(prop, model));
                            var __tmp92Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp92.ToStringAndFree());
                            bool __tmp92_last = __tmp92Reader.EndOfStream;
                            while(!__tmp92_last)
                            {
                                ReadOnlySpan<char> __tmp92_line = __tmp92Reader.ReadLine();
                                __tmp92_last = __tmp92Reader.EndOfStream;
                                if (!__tmp92_last || !__tmp92_line.IsEmpty)
                                {
                                    __out.Write(__tmp92_line);
                                    __tmp86_outputWritten = true;
                                }
                                if (!__tmp92_last) __out.AppendLine(true);
                            }
                            string __tmp93_line = ");"; //705:160
                            if (!string.IsNullOrEmpty(__tmp93_line))
                            {
                                __out.Write(__tmp93_line);
                                __tmp86_outputWritten = true;
                            }
                            if (__tmp86_outputWritten) __out.AppendLine(true);
                            if (__tmp86_outputWritten)
                            {
                                __out.AppendLine(false); //705:162
                            }
                        }
                        else //706:6
                        {
                            bool __tmp95_outputWritten = false;
                            string __tmp96_line = "		_this."; //707:1
                            if (!string.IsNullOrEmpty(__tmp96_line))
                            {
                                __out.Write(__tmp96_line);
                                __tmp95_outputWritten = true;
                            }
                            var __tmp97 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp97.Write(CSharpName(prop, model, PropertyKind.Builder));
                            var __tmp97Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp97.ToStringAndFree());
                            bool __tmp97_last = __tmp97Reader.EndOfStream;
                            while(!__tmp97_last)
                            {
                                ReadOnlySpan<char> __tmp97_line = __tmp97Reader.ReadLine();
                                __tmp97_last = __tmp97Reader.EndOfStream;
                                if (!__tmp97_last || !__tmp97_line.IsEmpty)
                                {
                                    __out.Write(__tmp97_line);
                                    __tmp95_outputWritten = true;
                                }
                                if (!__tmp97_last) __out.AppendLine(true);
                            }
                            string __tmp98_line = ".AddRangeLazy<"; //707:55
                            if (!string.IsNullOrEmpty(__tmp98_line))
                            {
                                __out.Write(__tmp98_line);
                                __tmp95_outputWritten = true;
                            }
                            var __tmp99 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp99.Write(CSharpName(prop.Class, model, ClassKind.Builder));
                            var __tmp99Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp99.ToStringAndFree());
                            bool __tmp99_last = __tmp99Reader.EndOfStream;
                            while(!__tmp99_last)
                            {
                                ReadOnlySpan<char> __tmp99_line = __tmp99Reader.ReadLine();
                                __tmp99_last = __tmp99Reader.EndOfStream;
                                if (!__tmp99_last || !__tmp99_line.IsEmpty)
                                {
                                    __out.Write(__tmp99_line);
                                    __tmp95_outputWritten = true;
                                }
                                if (!__tmp99_last) __out.AppendLine(true);
                            }
                            string __tmp100_line = ">(this."; //707:118
                            if (!string.IsNullOrEmpty(__tmp100_line))
                            {
                                __out.Write(__tmp100_line);
                                __tmp95_outputWritten = true;
                            }
                            var __tmp101 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp101.Write(CSharpName(prop.Class, model, ClassKind.Immutable));
                            var __tmp101Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp101.ToStringAndFree());
                            bool __tmp101_last = __tmp101Reader.EndOfStream;
                            while(!__tmp101_last)
                            {
                                ReadOnlySpan<char> __tmp101_line = __tmp101Reader.ReadLine();
                                __tmp101_last = __tmp101Reader.EndOfStream;
                                if (!__tmp101_last || !__tmp101_line.IsEmpty)
                                {
                                    __out.Write(__tmp101_line);
                                    __tmp95_outputWritten = true;
                                }
                                if (!__tmp101_last) __out.AppendLine(true);
                            }
                            string __tmp102_line = "_ComputeProperty_"; //707:176
                            if (!string.IsNullOrEmpty(__tmp102_line))
                            {
                                __out.Write(__tmp102_line);
                                __tmp95_outputWritten = true;
                            }
                            var __tmp103 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp103.Write(CSharpName(prop, model));
                            var __tmp103Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp103.ToStringAndFree());
                            bool __tmp103_last = __tmp103Reader.EndOfStream;
                            while(!__tmp103_last)
                            {
                                ReadOnlySpan<char> __tmp103_line = __tmp103Reader.ReadLine();
                                __tmp103_last = __tmp103Reader.EndOfStream;
                                if (!__tmp103_last || !__tmp103_line.IsEmpty)
                                {
                                    __out.Write(__tmp103_line);
                                    __tmp95_outputWritten = true;
                                }
                                if (!__tmp103_last) __out.AppendLine(true);
                            }
                            string __tmp104_line = ");"; //707:217
                            if (!string.IsNullOrEmpty(__tmp104_line))
                            {
                                __out.Write(__tmp104_line);
                                __tmp95_outputWritten = true;
                            }
                            if (__tmp95_outputWritten) __out.AppendLine(true);
                            if (__tmp95_outputWritten)
                            {
                                __out.AppendLine(false); //707:219
                            }
                        }
                    }
                    else if (prop.Kind == MetaPropertyKind.Readonly) //709:5
                    {
                        if (!(prop.Type is MetaCollectionType)) //710:6
                        {
                            bool __tmp106_outputWritten = false;
                            string __tmp107_line = "		_this.Set"; //711:1
                            if (!string.IsNullOrEmpty(__tmp107_line))
                            {
                                __out.Write(__tmp107_line);
                                __tmp106_outputWritten = true;
                            }
                            var __tmp108 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp108.Write(CSharpName(prop, model, PropertyKind.Builder));
                            var __tmp108Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp108.ToStringAndFree());
                            bool __tmp108_last = __tmp108Reader.EndOfStream;
                            while(!__tmp108_last)
                            {
                                ReadOnlySpan<char> __tmp108_line = __tmp108Reader.ReadLine();
                                __tmp108_last = __tmp108Reader.EndOfStream;
                                if (!__tmp108_last || !__tmp108_line.IsEmpty)
                                {
                                    __out.Write(__tmp108_line);
                                    __tmp106_outputWritten = true;
                                }
                                if (!__tmp108_last) __out.AppendLine(true);
                            }
                            string __tmp109_line = "Lazy(this."; //711:58
                            if (!string.IsNullOrEmpty(__tmp109_line))
                            {
                                __out.Write(__tmp109_line);
                                __tmp106_outputWritten = true;
                            }
                            var __tmp110 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp110.Write(CSharpName(prop.Class, model, ClassKind.Immutable));
                            var __tmp110Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp110.ToStringAndFree());
                            bool __tmp110_last = __tmp110Reader.EndOfStream;
                            while(!__tmp110_last)
                            {
                                ReadOnlySpan<char> __tmp110_line = __tmp110Reader.ReadLine();
                                __tmp110_last = __tmp110Reader.EndOfStream;
                                if (!__tmp110_last || !__tmp110_line.IsEmpty)
                                {
                                    __out.Write(__tmp110_line);
                                    __tmp106_outputWritten = true;
                                }
                                if (!__tmp110_last) __out.AppendLine(true);
                            }
                            string __tmp111_line = "_ComputeProperty_"; //711:119
                            if (!string.IsNullOrEmpty(__tmp111_line))
                            {
                                __out.Write(__tmp111_line);
                                __tmp106_outputWritten = true;
                            }
                            var __tmp112 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp112.Write(CSharpName(prop, model));
                            var __tmp112Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp112.ToStringAndFree());
                            bool __tmp112_last = __tmp112Reader.EndOfStream;
                            while(!__tmp112_last)
                            {
                                ReadOnlySpan<char> __tmp112_line = __tmp112Reader.ReadLine();
                                __tmp112_last = __tmp112Reader.EndOfStream;
                                if (!__tmp112_last || !__tmp112_line.IsEmpty)
                                {
                                    __out.Write(__tmp112_line);
                                    __tmp106_outputWritten = true;
                                }
                                if (!__tmp112_last) __out.AppendLine(true);
                            }
                            string __tmp113_line = ");"; //711:160
                            if (!string.IsNullOrEmpty(__tmp113_line))
                            {
                                __out.Write(__tmp113_line);
                                __tmp106_outputWritten = true;
                            }
                            if (__tmp106_outputWritten) __out.AppendLine(true);
                            if (__tmp106_outputWritten)
                            {
                                __out.AppendLine(false); //711:162
                            }
                        }
                        else //712:6
                        {
                            bool __tmp115_outputWritten = false;
                            string __tmp116_line = "		_this."; //713:1
                            if (!string.IsNullOrEmpty(__tmp116_line))
                            {
                                __out.Write(__tmp116_line);
                                __tmp115_outputWritten = true;
                            }
                            var __tmp117 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp117.Write(CSharpName(prop, model, PropertyKind.Builder));
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
                            string __tmp118_line = ".AddRangeLazy("; //713:55
                            if (!string.IsNullOrEmpty(__tmp118_line))
                            {
                                __out.Write(__tmp118_line);
                                __tmp115_outputWritten = true;
                            }
                            var __tmp119 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp119.Write(CSharpName(prop.Class, model, ClassKind.Immutable));
                            var __tmp119Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp119.ToStringAndFree());
                            bool __tmp119_last = __tmp119Reader.EndOfStream;
                            while(!__tmp119_last)
                            {
                                ReadOnlySpan<char> __tmp119_line = __tmp119Reader.ReadLine();
                                __tmp119_last = __tmp119Reader.EndOfStream;
                                if (!__tmp119_last || !__tmp119_line.IsEmpty)
                                {
                                    __out.Write(__tmp119_line);
                                    __tmp115_outputWritten = true;
                                }
                                if (!__tmp119_last) __out.AppendLine(true);
                            }
                            string __tmp120_line = "_ComputeProperty_"; //713:120
                            if (!string.IsNullOrEmpty(__tmp120_line))
                            {
                                __out.Write(__tmp120_line);
                                __tmp115_outputWritten = true;
                            }
                            var __tmp121 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                            __tmp121.Write(CSharpName(prop, model));
                            var __tmp121Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp121.ToStringAndFree());
                            bool __tmp121_last = __tmp121Reader.EndOfStream;
                            while(!__tmp121_last)
                            {
                                ReadOnlySpan<char> __tmp121_line = __tmp121Reader.ReadLine();
                                __tmp121_last = __tmp121Reader.EndOfStream;
                                if (!__tmp121_last || !__tmp121_line.IsEmpty)
                                {
                                    __out.Write(__tmp121_line);
                                    __tmp115_outputWritten = true;
                                }
                                if (!__tmp121_last) __out.AppendLine(true);
                            }
                            string __tmp122_line = ");"; //713:161
                            if (!string.IsNullOrEmpty(__tmp122_line))
                            {
                                __out.Write(__tmp122_line);
                                __tmp115_outputWritten = true;
                            }
                            if (__tmp115_outputWritten) __out.AppendLine(true);
                            if (__tmp115_outputWritten)
                            {
                                __out.AppendLine(false); //713:163
                            }
                        }
                    }
                }
                __out.Write("	}"); //717:1
                __out.AppendLine(false); //717:3
                __out.AppendLine(true); //718:1
                __out.Write("	/// <summary>"); //719:1
                __out.AppendLine(false); //719:15
                bool __tmp124_outputWritten = false;
                string __tmp125_line = "	/// Calls the super constructors of "; //720:1
                if (!string.IsNullOrEmpty(__tmp125_line))
                {
                    __out.Write(__tmp125_line);
                    __tmp124_outputWritten = true;
                }
                var __tmp126 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp126.Write(CSharpName(cls, model, ClassKind.Immutable));
                var __tmp126Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp126.ToStringAndFree());
                bool __tmp126_last = __tmp126Reader.EndOfStream;
                while(!__tmp126_last)
                {
                    ReadOnlySpan<char> __tmp126_line = __tmp126Reader.ReadLine();
                    __tmp126_last = __tmp126Reader.EndOfStream;
                    if (!__tmp126_last || !__tmp126_line.IsEmpty)
                    {
                        __out.Write(__tmp126_line);
                        __tmp124_outputWritten = true;
                    }
                    if (!__tmp126_last || __tmp124_outputWritten) __out.AppendLine(true);
                }
                if (__tmp124_outputWritten)
                {
                    __out.AppendLine(false); //720:82
                }
                __out.Write("	/// </summary>"); //721:1
                __out.AppendLine(false); //721:16
                bool __tmp128_outputWritten = false;
                string __tmp129_line = "	protected virtual void Call"; //722:1
                if (!string.IsNullOrEmpty(__tmp129_line))
                {
                    __out.Write(__tmp129_line);
                    __tmp128_outputWritten = true;
                }
                var __tmp130 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp130.Write(CSharpName(cls, model, ClassKind.Immutable));
                var __tmp130Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp130.ToStringAndFree());
                bool __tmp130_last = __tmp130Reader.EndOfStream;
                while(!__tmp130_last)
                {
                    ReadOnlySpan<char> __tmp130_line = __tmp130Reader.ReadLine();
                    __tmp130_last = __tmp130Reader.EndOfStream;
                    if (!__tmp130_last || !__tmp130_line.IsEmpty)
                    {
                        __out.Write(__tmp130_line);
                        __tmp128_outputWritten = true;
                    }
                    if (!__tmp130_last) __out.AppendLine(true);
                }
                string __tmp131_line = "SuperConstructors("; //722:73
                if (!string.IsNullOrEmpty(__tmp131_line))
                {
                    __out.Write(__tmp131_line);
                    __tmp128_outputWritten = true;
                }
                var __tmp132 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp132.Write(CSharpName(cls, model, ClassKind.Builder));
                var __tmp132Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp132.ToStringAndFree());
                bool __tmp132_last = __tmp132Reader.EndOfStream;
                while(!__tmp132_last)
                {
                    ReadOnlySpan<char> __tmp132_line = __tmp132Reader.ReadLine();
                    __tmp132_last = __tmp132Reader.EndOfStream;
                    if (!__tmp132_last || !__tmp132_line.IsEmpty)
                    {
                        __out.Write(__tmp132_line);
                        __tmp128_outputWritten = true;
                    }
                    if (!__tmp132_last) __out.AppendLine(true);
                }
                string __tmp133_line = " _this)"; //722:133
                if (!string.IsNullOrEmpty(__tmp133_line))
                {
                    __out.Write(__tmp133_line);
                    __tmp128_outputWritten = true;
                }
                if (__tmp128_outputWritten) __out.AppendLine(true);
                if (__tmp128_outputWritten)
                {
                    __out.AppendLine(false); //722:140
                }
                __out.Write("	{"); //723:1
                __out.AppendLine(false); //723:3
                var __loop43_results = 
                    (from __loop43_var1 in __Enumerate((cls).GetEnumerator()) //724:8
                    from sup in __Enumerate((__loop43_var1.GetAllSuperClasses(false)).GetEnumerator()) //724:13
                    select new { __loop43_var1 = __loop43_var1, sup = sup}
                    ).ToList(); //724:3
                for (int __loop43_iteration = 0; __loop43_iteration < __loop43_results.Count; ++__loop43_iteration)
                {
                    var __tmp134 = __loop43_results[__loop43_iteration];
                    var __loop43_var1 = __tmp134.__loop43_var1;
                    var sup = __tmp134.sup;
                    if (model.Namespace.Declarations.Contains(sup)) //725:4
                    {
                        bool __tmp136_outputWritten = false;
                        string __tmp137_line = "		this."; //726:1
                        if (!string.IsNullOrEmpty(__tmp137_line))
                        {
                            __out.Write(__tmp137_line);
                            __tmp136_outputWritten = true;
                        }
                        var __tmp138 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp138.Write(CSharpName(sup, model, ClassKind.Immutable));
                        var __tmp138Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp138.ToStringAndFree());
                        bool __tmp138_last = __tmp138Reader.EndOfStream;
                        while(!__tmp138_last)
                        {
                            ReadOnlySpan<char> __tmp138_line = __tmp138Reader.ReadLine();
                            __tmp138_last = __tmp138Reader.EndOfStream;
                            if (!__tmp138_last || !__tmp138_line.IsEmpty)
                            {
                                __out.Write(__tmp138_line);
                                __tmp136_outputWritten = true;
                            }
                            if (!__tmp138_last) __out.AppendLine(true);
                        }
                        string __tmp139_line = "(_this);"; //726:52
                        if (!string.IsNullOrEmpty(__tmp139_line))
                        {
                            __out.Write(__tmp139_line);
                            __tmp136_outputWritten = true;
                        }
                        if (__tmp136_outputWritten) __out.AppendLine(true);
                        if (__tmp136_outputWritten)
                        {
                            __out.AppendLine(false); //726:60
                        }
                    }
                    else //727:4
                    {
                        bool __tmp141_outputWritten = false;
                        string __tmp140Prefix = "		"; //728:1
                        var __tmp142 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp142.Write(CSharpName(sup.MetaModel, ModelKind.ImplementationProvider, true));
                        var __tmp142Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp142.ToStringAndFree());
                        bool __tmp142_last = __tmp142Reader.EndOfStream;
                        while(!__tmp142_last)
                        {
                            ReadOnlySpan<char> __tmp142_line = __tmp142Reader.ReadLine();
                            __tmp142_last = __tmp142Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp140Prefix))
                            {
                                __out.Write(__tmp140Prefix);
                                __tmp141_outputWritten = true;
                            }
                            if (!__tmp142_last || !__tmp142_line.IsEmpty)
                            {
                                __out.Write(__tmp142_line);
                                __tmp141_outputWritten = true;
                            }
                            if (!__tmp142_last) __out.AppendLine(true);
                        }
                        string __tmp143_line = "."; //728:69
                        if (!string.IsNullOrEmpty(__tmp143_line))
                        {
                            __out.Write(__tmp143_line);
                            __tmp141_outputWritten = true;
                        }
                        var __tmp144 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp144.Write(CSharpName(sup, model, ClassKind.Immutable));
                        var __tmp144Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp144.ToStringAndFree());
                        bool __tmp144_last = __tmp144Reader.EndOfStream;
                        while(!__tmp144_last)
                        {
                            ReadOnlySpan<char> __tmp144_line = __tmp144Reader.ReadLine();
                            __tmp144_last = __tmp144Reader.EndOfStream;
                            if (!__tmp144_last || !__tmp144_line.IsEmpty)
                            {
                                __out.Write(__tmp144_line);
                                __tmp141_outputWritten = true;
                            }
                            if (!__tmp144_last) __out.AppendLine(true);
                        }
                        string __tmp145_line = "(_this);"; //728:114
                        if (!string.IsNullOrEmpty(__tmp145_line))
                        {
                            __out.Write(__tmp145_line);
                            __tmp141_outputWritten = true;
                        }
                        if (__tmp141_outputWritten) __out.AppendLine(true);
                        if (__tmp141_outputWritten)
                        {
                            __out.AppendLine(false); //728:122
                        }
                    }
                }
                __out.Write("	}"); //731:1
                __out.AppendLine(false); //731:3
                __out.AppendLine(true); //732:2
                var __loop44_results = 
                    (from __loop44_var1 in __Enumerate((cls).GetEnumerator()) //733:8
                    from prop in __Enumerate((__loop44_var1.Properties).GetEnumerator()) //733:13
                    where prop.Kind == MetaPropertyKind.Readonly || prop.Kind == MetaPropertyKind.Lazy || prop.Kind == MetaPropertyKind.Derived //733:29
                    select new { __loop44_var1 = __loop44_var1, prop = prop}
                    ).ToList(); //733:3
                for (int __loop44_iteration = 0; __loop44_iteration < __loop44_results.Count; ++__loop44_iteration)
                {
                    var __tmp146 = __loop44_results[__loop44_iteration];
                    var __loop44_var1 = __tmp146.__loop44_var1;
                    var prop = __tmp146.prop;
                    if (metaMetaModel && cls.Name == "MetaConstant" && prop.Name == "Value") //734:4
                    {
                    }
                    else //735:4
                    {
                        __out.Write("	/// <summary>"); //736:1
                        __out.AppendLine(false); //736:15
                        bool __tmp148_outputWritten = false;
                        string __tmp149_line = "	/// Computes the value of the property: "; //737:1
                        if (!string.IsNullOrEmpty(__tmp149_line))
                        {
                            __out.Write(__tmp149_line);
                            __tmp148_outputWritten = true;
                        }
                        var __tmp150 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp150.Write(CSharpName(cls, model, ClassKind.Immutable));
                        var __tmp150Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp150.ToStringAndFree());
                        bool __tmp150_last = __tmp150Reader.EndOfStream;
                        while(!__tmp150_last)
                        {
                            ReadOnlySpan<char> __tmp150_line = __tmp150Reader.ReadLine();
                            __tmp150_last = __tmp150Reader.EndOfStream;
                            if (!__tmp150_last || !__tmp150_line.IsEmpty)
                            {
                                __out.Write(__tmp150_line);
                                __tmp148_outputWritten = true;
                            }
                            if (!__tmp150_last) __out.AppendLine(true);
                        }
                        string __tmp151_line = "."; //737:86
                        if (!string.IsNullOrEmpty(__tmp151_line))
                        {
                            __out.Write(__tmp151_line);
                            __tmp148_outputWritten = true;
                        }
                        var __tmp152 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp152.Write(CSharpName(prop, model));
                        var __tmp152Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp152.ToStringAndFree());
                        bool __tmp152_last = __tmp152Reader.EndOfStream;
                        while(!__tmp152_last)
                        {
                            ReadOnlySpan<char> __tmp152_line = __tmp152Reader.ReadLine();
                            __tmp152_last = __tmp152Reader.EndOfStream;
                            if (!__tmp152_last || !__tmp152_line.IsEmpty)
                            {
                                __out.Write(__tmp152_line);
                                __tmp148_outputWritten = true;
                            }
                            if (!__tmp152_last || __tmp148_outputWritten) __out.AppendLine(true);
                        }
                        if (__tmp148_outputWritten)
                        {
                            __out.AppendLine(false); //737:111
                        }
                        __out.Write("	/// </summary	"); //738:1
                        __out.AppendLine(false); //738:16
                        bool __tmp154_outputWritten = false;
                        string __tmp155_line = "	public abstract "; //739:1
                        if (!string.IsNullOrEmpty(__tmp155_line))
                        {
                            __out.Write(__tmp155_line);
                            __tmp154_outputWritten = true;
                        }
                        var __tmp156 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp156.Write(CSharpName(prop.Type, model, ClassKind.BuilderOperation, true));
                        var __tmp156Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp156.ToStringAndFree());
                        bool __tmp156_last = __tmp156Reader.EndOfStream;
                        while(!__tmp156_last)
                        {
                            ReadOnlySpan<char> __tmp156_line = __tmp156Reader.ReadLine();
                            __tmp156_last = __tmp156Reader.EndOfStream;
                            if (!__tmp156_last || !__tmp156_line.IsEmpty)
                            {
                                __out.Write(__tmp156_line);
                                __tmp154_outputWritten = true;
                            }
                            if (!__tmp156_last) __out.AppendLine(true);
                        }
                        string __tmp157_line = " "; //739:81
                        if (!string.IsNullOrEmpty(__tmp157_line))
                        {
                            __out.Write(__tmp157_line);
                            __tmp154_outputWritten = true;
                        }
                        var __tmp158 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp158.Write(CSharpName(cls, model, ClassKind.Immutable));
                        var __tmp158Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp158.ToStringAndFree());
                        bool __tmp158_last = __tmp158Reader.EndOfStream;
                        while(!__tmp158_last)
                        {
                            ReadOnlySpan<char> __tmp158_line = __tmp158Reader.ReadLine();
                            __tmp158_last = __tmp158Reader.EndOfStream;
                            if (!__tmp158_last || !__tmp158_line.IsEmpty)
                            {
                                __out.Write(__tmp158_line);
                                __tmp154_outputWritten = true;
                            }
                            if (!__tmp158_last) __out.AppendLine(true);
                        }
                        string __tmp159_line = "_ComputeProperty_"; //739:126
                        if (!string.IsNullOrEmpty(__tmp159_line))
                        {
                            __out.Write(__tmp159_line);
                            __tmp154_outputWritten = true;
                        }
                        var __tmp160 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp160.Write(CSharpName(prop, model));
                        var __tmp160Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp160.ToStringAndFree());
                        bool __tmp160_last = __tmp160Reader.EndOfStream;
                        while(!__tmp160_last)
                        {
                            ReadOnlySpan<char> __tmp160_line = __tmp160Reader.ReadLine();
                            __tmp160_last = __tmp160Reader.EndOfStream;
                            if (!__tmp160_last || !__tmp160_line.IsEmpty)
                            {
                                __out.Write(__tmp160_line);
                                __tmp154_outputWritten = true;
                            }
                            if (!__tmp160_last) __out.AppendLine(true);
                        }
                        string __tmp161_line = "("; //739:167
                        if (!string.IsNullOrEmpty(__tmp161_line))
                        {
                            __out.Write(__tmp161_line);
                            __tmp154_outputWritten = true;
                        }
                        var __tmp162 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp162.Write(CSharpName(cls, model, ClassKind.Builder));
                        var __tmp162Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp162.ToStringAndFree());
                        bool __tmp162_last = __tmp162Reader.EndOfStream;
                        while(!__tmp162_last)
                        {
                            ReadOnlySpan<char> __tmp162_line = __tmp162Reader.ReadLine();
                            __tmp162_last = __tmp162Reader.EndOfStream;
                            if (!__tmp162_last || !__tmp162_line.IsEmpty)
                            {
                                __out.Write(__tmp162_line);
                                __tmp154_outputWritten = true;
                            }
                            if (!__tmp162_last) __out.AppendLine(true);
                        }
                        string __tmp163_line = " _this);"; //739:210
                        if (!string.IsNullOrEmpty(__tmp163_line))
                        {
                            __out.Write(__tmp163_line);
                            __tmp154_outputWritten = true;
                        }
                        if (__tmp154_outputWritten) __out.AppendLine(true);
                        if (__tmp154_outputWritten)
                        {
                            __out.AppendLine(false); //739:218
                        }
                    }
                }
                __out.AppendLine(true); //742:2
                var __loop45_results = 
                    (from __loop45_var1 in __Enumerate((cls).GetEnumerator()) //743:8
                    from op in __Enumerate((__loop45_var1.Operations).GetEnumerator()) //743:13
                    select new { __loop45_var1 = __loop45_var1, op = op}
                    ).ToList(); //743:3
                for (int __loop45_iteration = 0; __loop45_iteration < __loop45_results.Count; ++__loop45_iteration)
                {
                    var __tmp164 = __loop45_results[__loop45_iteration];
                    var __loop45_var1 = __tmp164.__loop45_var1;
                    var op = __tmp164.op;
                    if (!op.IsBuilder) //744:4
                    {
                        __out.AppendLine(true); //745:2
                        __out.Write("	/// <summary>"); //746:1
                        __out.AppendLine(false); //746:15
                        bool __tmp166_outputWritten = false;
                        string __tmp167_line = "	/// Implements the operation: "; //747:1
                        if (!string.IsNullOrEmpty(__tmp167_line))
                        {
                            __out.Write(__tmp167_line);
                            __tmp166_outputWritten = true;
                        }
                        var __tmp168 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp168.Write(CSharpName(cls, model, ClassKind.Immutable));
                        var __tmp168Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp168.ToStringAndFree());
                        bool __tmp168_last = __tmp168Reader.EndOfStream;
                        while(!__tmp168_last)
                        {
                            ReadOnlySpan<char> __tmp168_line = __tmp168Reader.ReadLine();
                            __tmp168_last = __tmp168Reader.EndOfStream;
                            if (!__tmp168_last || !__tmp168_line.IsEmpty)
                            {
                                __out.Write(__tmp168_line);
                                __tmp166_outputWritten = true;
                            }
                            if (!__tmp168_last) __out.AppendLine(true);
                        }
                        string __tmp169_line = "."; //747:76
                        if (!string.IsNullOrEmpty(__tmp169_line))
                        {
                            __out.Write(__tmp169_line);
                            __tmp166_outputWritten = true;
                        }
                        var __tmp170 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp170.Write(op.Name);
                        var __tmp170Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp170.ToStringAndFree());
                        bool __tmp170_last = __tmp170Reader.EndOfStream;
                        while(!__tmp170_last)
                        {
                            ReadOnlySpan<char> __tmp170_line = __tmp170Reader.ReadLine();
                            __tmp170_last = __tmp170Reader.EndOfStream;
                            if (!__tmp170_last || !__tmp170_line.IsEmpty)
                            {
                                __out.Write(__tmp170_line);
                                __tmp166_outputWritten = true;
                            }
                            if (!__tmp170_last) __out.AppendLine(true);
                        }
                        string __tmp171_line = "()"; //747:86
                        if (!string.IsNullOrEmpty(__tmp171_line))
                        {
                            __out.Write(__tmp171_line);
                            __tmp166_outputWritten = true;
                        }
                        if (__tmp166_outputWritten) __out.AppendLine(true);
                        if (__tmp166_outputWritten)
                        {
                            __out.AppendLine(false); //747:88
                        }
                        __out.Write("	/// </summary>"); //748:1
                        __out.AppendLine(false); //748:16
                        bool __tmp173_outputWritten = false;
                        string __tmp174_line = "	public virtual "; //749:1
                        if (!string.IsNullOrEmpty(__tmp174_line))
                        {
                            __out.Write(__tmp174_line);
                            __tmp173_outputWritten = true;
                        }
                        var __tmp175 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp175.Write(CSharpName(op.ReturnType, model, ClassKind.ImmutableOperation, true));
                        var __tmp175Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp175.ToStringAndFree());
                        bool __tmp175_last = __tmp175Reader.EndOfStream;
                        while(!__tmp175_last)
                        {
                            ReadOnlySpan<char> __tmp175_line = __tmp175Reader.ReadLine();
                            __tmp175_last = __tmp175Reader.EndOfStream;
                            if (!__tmp175_last || !__tmp175_line.IsEmpty)
                            {
                                __out.Write(__tmp175_line);
                                __tmp173_outputWritten = true;
                            }
                            if (!__tmp175_last) __out.AppendLine(true);
                        }
                        string __tmp176_line = " "; //749:86
                        if (!string.IsNullOrEmpty(__tmp176_line))
                        {
                            __out.Write(__tmp176_line);
                            __tmp173_outputWritten = true;
                        }
                        var __tmp177 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp177.Write(CSharpName(cls, model, ClassKind.Immutable));
                        var __tmp177Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp177.ToStringAndFree());
                        bool __tmp177_last = __tmp177Reader.EndOfStream;
                        while(!__tmp177_last)
                        {
                            ReadOnlySpan<char> __tmp177_line = __tmp177Reader.ReadLine();
                            __tmp177_last = __tmp177Reader.EndOfStream;
                            if (!__tmp177_last || !__tmp177_line.IsEmpty)
                            {
                                __out.Write(__tmp177_line);
                                __tmp173_outputWritten = true;
                            }
                            if (!__tmp177_last) __out.AppendLine(true);
                        }
                        string __tmp178_line = "_"; //749:131
                        if (!string.IsNullOrEmpty(__tmp178_line))
                        {
                            __out.Write(__tmp178_line);
                            __tmp173_outputWritten = true;
                        }
                        var __tmp179 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp179.Write(op.Name);
                        var __tmp179Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp179.ToStringAndFree());
                        bool __tmp179_last = __tmp179Reader.EndOfStream;
                        while(!__tmp179_last)
                        {
                            ReadOnlySpan<char> __tmp179_line = __tmp179Reader.ReadLine();
                            __tmp179_last = __tmp179Reader.EndOfStream;
                            if (!__tmp179_last || !__tmp179_line.IsEmpty)
                            {
                                __out.Write(__tmp179_line);
                                __tmp173_outputWritten = true;
                            }
                            if (!__tmp179_last) __out.AppendLine(true);
                        }
                        string __tmp180_line = "("; //749:141
                        if (!string.IsNullOrEmpty(__tmp180_line))
                        {
                            __out.Write(__tmp180_line);
                            __tmp173_outputWritten = true;
                        }
                        var __tmp181 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp181.Write(GetImplParameters(model, cls, op, ClassKind.ImmutableOperation));
                        var __tmp181Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp181.ToStringAndFree());
                        bool __tmp181_last = __tmp181Reader.EndOfStream;
                        while(!__tmp181_last)
                        {
                            ReadOnlySpan<char> __tmp181_line = __tmp181Reader.ReadLine();
                            __tmp181_last = __tmp181Reader.EndOfStream;
                            if (!__tmp181_last || !__tmp181_line.IsEmpty)
                            {
                                __out.Write(__tmp181_line);
                                __tmp173_outputWritten = true;
                            }
                            if (!__tmp181_last) __out.AppendLine(true);
                        }
                        string __tmp182_line = ")"; //749:207
                        if (!string.IsNullOrEmpty(__tmp182_line))
                        {
                            __out.Write(__tmp182_line);
                            __tmp173_outputWritten = true;
                        }
                        if (__tmp173_outputWritten) __out.AppendLine(true);
                        if (__tmp173_outputWritten)
                        {
                            __out.AppendLine(false); //749:208
                        }
                        __out.Write("	{"); //750:1
                        __out.AppendLine(false); //750:3
                        bool __tmp184_outputWritten = false;
                        string __tmp183Prefix = "		"; //751:1
                        var __tmp185 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp185.Write(GetReturn(CSharpName(op.ReturnType, model, ClassKind.ImmutableOperation, true)));
                        var __tmp185Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp185.ToStringAndFree());
                        bool __tmp185_last = __tmp185Reader.EndOfStream;
                        while(!__tmp185_last)
                        {
                            ReadOnlySpan<char> __tmp185_line = __tmp185Reader.ReadLine();
                            __tmp185_last = __tmp185Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp183Prefix))
                            {
                                __out.Write(__tmp183Prefix);
                                __tmp184_outputWritten = true;
                            }
                            if (!__tmp185_last || !__tmp185_line.IsEmpty)
                            {
                                __out.Write(__tmp185_line);
                                __tmp184_outputWritten = true;
                            }
                            if (!__tmp185_last) __out.AppendLine(true);
                        }
                        string __tmp186_line = "this."; //751:83
                        if (!string.IsNullOrEmpty(__tmp186_line))
                        {
                            __out.Write(__tmp186_line);
                            __tmp184_outputWritten = true;
                        }
                        var __tmp187 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp187.Write(CSharpName(op.Class, model, ClassKind.Immutable));
                        var __tmp187Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp187.ToStringAndFree());
                        bool __tmp187_last = __tmp187Reader.EndOfStream;
                        while(!__tmp187_last)
                        {
                            ReadOnlySpan<char> __tmp187_line = __tmp187Reader.ReadLine();
                            __tmp187_last = __tmp187Reader.EndOfStream;
                            if (!__tmp187_last || !__tmp187_line.IsEmpty)
                            {
                                __out.Write(__tmp187_line);
                                __tmp184_outputWritten = true;
                            }
                            if (!__tmp187_last) __out.AppendLine(true);
                        }
                        string __tmp188_line = "_"; //751:137
                        if (!string.IsNullOrEmpty(__tmp188_line))
                        {
                            __out.Write(__tmp188_line);
                            __tmp184_outputWritten = true;
                        }
                        var __tmp189 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp189.Write(op.Name);
                        var __tmp189Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp189.ToStringAndFree());
                        bool __tmp189_last = __tmp189Reader.EndOfStream;
                        while(!__tmp189_last)
                        {
                            ReadOnlySpan<char> __tmp189_line = __tmp189Reader.ReadLine();
                            __tmp189_last = __tmp189Reader.EndOfStream;
                            if (!__tmp189_last || !__tmp189_line.IsEmpty)
                            {
                                __out.Write(__tmp189_line);
                                __tmp184_outputWritten = true;
                            }
                            if (!__tmp189_last) __out.AppendLine(true);
                        }
                        string __tmp190_line = "("; //751:147
                        if (!string.IsNullOrEmpty(__tmp190_line))
                        {
                            __out.Write(__tmp190_line);
                            __tmp184_outputWritten = true;
                        }
                        var __tmp191 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp191.Write(GetImmBldCallParameterNames(model, op, ClassKind.BuilderOperation));
                        var __tmp191Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp191.ToStringAndFree());
                        bool __tmp191_last = __tmp191Reader.EndOfStream;
                        while(!__tmp191_last)
                        {
                            ReadOnlySpan<char> __tmp191_line = __tmp191Reader.ReadLine();
                            __tmp191_last = __tmp191Reader.EndOfStream;
                            if (!__tmp191_last || !__tmp191_line.IsEmpty)
                            {
                                __out.Write(__tmp191_line);
                                __tmp184_outputWritten = true;
                            }
                            if (!__tmp191_last) __out.AppendLine(true);
                        }
                        string __tmp192_line = ")"; //751:216
                        if (!string.IsNullOrEmpty(__tmp192_line))
                        {
                            __out.Write(__tmp192_line);
                            __tmp184_outputWritten = true;
                        }
                        var __tmp193 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp193.Write(GetImmBldReturn(model, op, ClassKind.ImmutableOperation));
                        var __tmp193Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp193.ToStringAndFree());
                        bool __tmp193_last = __tmp193Reader.EndOfStream;
                        while(!__tmp193_last)
                        {
                            ReadOnlySpan<char> __tmp193_line = __tmp193Reader.ReadLine();
                            __tmp193_last = __tmp193Reader.EndOfStream;
                            if (!__tmp193_last || !__tmp193_line.IsEmpty)
                            {
                                __out.Write(__tmp193_line);
                                __tmp184_outputWritten = true;
                            }
                            if (!__tmp193_last) __out.AppendLine(true);
                        }
                        string __tmp194_line = ";"; //751:275
                        if (!string.IsNullOrEmpty(__tmp194_line))
                        {
                            __out.Write(__tmp194_line);
                            __tmp184_outputWritten = true;
                        }
                        if (__tmp184_outputWritten) __out.AppendLine(true);
                        if (__tmp184_outputWritten)
                        {
                            __out.AppendLine(false); //751:276
                        }
                        __out.Write("	}"); //752:1
                        __out.AppendLine(false); //752:3
                    }
                    __out.AppendLine(true); //754:2
                    __out.Write("	/// <summary>"); //755:1
                    __out.AppendLine(false); //755:15
                    bool __tmp196_outputWritten = false;
                    string __tmp197_line = "	/// Implements the operation: "; //756:1
                    if (!string.IsNullOrEmpty(__tmp197_line))
                    {
                        __out.Write(__tmp197_line);
                        __tmp196_outputWritten = true;
                    }
                    var __tmp198 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp198.Write(CSharpName(cls, model, ClassKind.Builder));
                    var __tmp198Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp198.ToStringAndFree());
                    bool __tmp198_last = __tmp198Reader.EndOfStream;
                    while(!__tmp198_last)
                    {
                        ReadOnlySpan<char> __tmp198_line = __tmp198Reader.ReadLine();
                        __tmp198_last = __tmp198Reader.EndOfStream;
                        if (!__tmp198_last || !__tmp198_line.IsEmpty)
                        {
                            __out.Write(__tmp198_line);
                            __tmp196_outputWritten = true;
                        }
                        if (!__tmp198_last) __out.AppendLine(true);
                    }
                    string __tmp199_line = "."; //756:74
                    if (!string.IsNullOrEmpty(__tmp199_line))
                    {
                        __out.Write(__tmp199_line);
                        __tmp196_outputWritten = true;
                    }
                    var __tmp200 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp200.Write(op.Name);
                    var __tmp200Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp200.ToStringAndFree());
                    bool __tmp200_last = __tmp200Reader.EndOfStream;
                    while(!__tmp200_last)
                    {
                        ReadOnlySpan<char> __tmp200_line = __tmp200Reader.ReadLine();
                        __tmp200_last = __tmp200Reader.EndOfStream;
                        if (!__tmp200_last || !__tmp200_line.IsEmpty)
                        {
                            __out.Write(__tmp200_line);
                            __tmp196_outputWritten = true;
                        }
                        if (!__tmp200_last) __out.AppendLine(true);
                    }
                    string __tmp201_line = "()"; //756:84
                    if (!string.IsNullOrEmpty(__tmp201_line))
                    {
                        __out.Write(__tmp201_line);
                        __tmp196_outputWritten = true;
                    }
                    if (__tmp196_outputWritten) __out.AppendLine(true);
                    if (__tmp196_outputWritten)
                    {
                        __out.AppendLine(false); //756:86
                    }
                    __out.Write("	/// </summary>"); //757:1
                    __out.AppendLine(false); //757:16
                    bool __tmp203_outputWritten = false;
                    string __tmp204_line = "	public abstract "; //758:1
                    if (!string.IsNullOrEmpty(__tmp204_line))
                    {
                        __out.Write(__tmp204_line);
                        __tmp203_outputWritten = true;
                    }
                    var __tmp205 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp205.Write(CSharpName(op.ReturnType, model, ClassKind.BuilderOperation, true));
                    var __tmp205Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp205.ToStringAndFree());
                    bool __tmp205_last = __tmp205Reader.EndOfStream;
                    while(!__tmp205_last)
                    {
                        ReadOnlySpan<char> __tmp205_line = __tmp205Reader.ReadLine();
                        __tmp205_last = __tmp205Reader.EndOfStream;
                        if (!__tmp205_last || !__tmp205_line.IsEmpty)
                        {
                            __out.Write(__tmp205_line);
                            __tmp203_outputWritten = true;
                        }
                        if (!__tmp205_last) __out.AppendLine(true);
                    }
                    string __tmp206_line = " "; //758:85
                    if (!string.IsNullOrEmpty(__tmp206_line))
                    {
                        __out.Write(__tmp206_line);
                        __tmp203_outputWritten = true;
                    }
                    var __tmp207 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp207.Write(CSharpName(cls, model, ClassKind.Immutable));
                    var __tmp207Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp207.ToStringAndFree());
                    bool __tmp207_last = __tmp207Reader.EndOfStream;
                    while(!__tmp207_last)
                    {
                        ReadOnlySpan<char> __tmp207_line = __tmp207Reader.ReadLine();
                        __tmp207_last = __tmp207Reader.EndOfStream;
                        if (!__tmp207_last || !__tmp207_line.IsEmpty)
                        {
                            __out.Write(__tmp207_line);
                            __tmp203_outputWritten = true;
                        }
                        if (!__tmp207_last) __out.AppendLine(true);
                    }
                    string __tmp208_line = "_"; //758:130
                    if (!string.IsNullOrEmpty(__tmp208_line))
                    {
                        __out.Write(__tmp208_line);
                        __tmp203_outputWritten = true;
                    }
                    var __tmp209 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp209.Write(op.Name);
                    var __tmp209Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp209.ToStringAndFree());
                    bool __tmp209_last = __tmp209Reader.EndOfStream;
                    while(!__tmp209_last)
                    {
                        ReadOnlySpan<char> __tmp209_line = __tmp209Reader.ReadLine();
                        __tmp209_last = __tmp209Reader.EndOfStream;
                        if (!__tmp209_last || !__tmp209_line.IsEmpty)
                        {
                            __out.Write(__tmp209_line);
                            __tmp203_outputWritten = true;
                        }
                        if (!__tmp209_last) __out.AppendLine(true);
                    }
                    string __tmp210_line = "("; //758:140
                    if (!string.IsNullOrEmpty(__tmp210_line))
                    {
                        __out.Write(__tmp210_line);
                        __tmp203_outputWritten = true;
                    }
                    var __tmp211 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp211.Write(GetImplParameters(model, cls, op, ClassKind.BuilderOperation));
                    var __tmp211Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp211.ToStringAndFree());
                    bool __tmp211_last = __tmp211Reader.EndOfStream;
                    while(!__tmp211_last)
                    {
                        ReadOnlySpan<char> __tmp211_line = __tmp211Reader.ReadLine();
                        __tmp211_last = __tmp211Reader.EndOfStream;
                        if (!__tmp211_last || !__tmp211_line.IsEmpty)
                        {
                            __out.Write(__tmp211_line);
                            __tmp203_outputWritten = true;
                        }
                        if (!__tmp211_last) __out.AppendLine(true);
                    }
                    string __tmp212_line = ");"; //758:204
                    if (!string.IsNullOrEmpty(__tmp212_line))
                    {
                        __out.Write(__tmp212_line);
                        __tmp203_outputWritten = true;
                    }
                    if (__tmp203_outputWritten) __out.AppendLine(true);
                    if (__tmp203_outputWritten)
                    {
                        __out.AppendLine(false); //758:206
                    }
                }
                __out.AppendLine(true); //760:2
            }
            var __loop46_results = 
                (from __loop46_var1 in __Enumerate((model).GetEnumerator()) //762:8
                from Namespace in __Enumerate((__loop46_var1.Namespace).GetEnumerator()) //762:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //762:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //762:40
                select new { __loop46_var1 = __loop46_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //762:3
            for (int __loop46_iteration = 0; __loop46_iteration < __loop46_results.Count; ++__loop46_iteration)
            {
                var __tmp213 = __loop46_results[__loop46_iteration];
                var __loop46_var1 = __tmp213.__loop46_var1;
                var Namespace = __tmp213.Namespace;
                var Declarations = __tmp213.Declarations;
                var enm = __tmp213.enm;
                var __loop47_results = 
                    (from __loop47_var1 in __Enumerate((enm).GetEnumerator()) //763:8
                    from op in __Enumerate((__loop47_var1.Operations).GetEnumerator()) //763:13
                    select new { __loop47_var1 = __loop47_var1, op = op}
                    ).ToList(); //763:3
                for (int __loop47_iteration = 0; __loop47_iteration < __loop47_results.Count; ++__loop47_iteration)
                {
                    var __tmp214 = __loop47_results[__loop47_iteration];
                    var __loop47_var1 = __tmp214.__loop47_var1;
                    var op = __tmp214.op;
                    __out.AppendLine(true); //764:2
                    __out.Write("	/// <summary>"); //765:1
                    __out.AppendLine(false); //765:15
                    bool __tmp216_outputWritten = false;
                    string __tmp217_line = "	/// Implements the operation: "; //766:1
                    if (!string.IsNullOrEmpty(__tmp217_line))
                    {
                        __out.Write(__tmp217_line);
                        __tmp216_outputWritten = true;
                    }
                    var __tmp218 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp218.Write(CSharpName(enm, model, ClassKind.Immutable));
                    var __tmp218Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp218.ToStringAndFree());
                    bool __tmp218_last = __tmp218Reader.EndOfStream;
                    while(!__tmp218_last)
                    {
                        ReadOnlySpan<char> __tmp218_line = __tmp218Reader.ReadLine();
                        __tmp218_last = __tmp218Reader.EndOfStream;
                        if (!__tmp218_last || !__tmp218_line.IsEmpty)
                        {
                            __out.Write(__tmp218_line);
                            __tmp216_outputWritten = true;
                        }
                        if (!__tmp218_last) __out.AppendLine(true);
                    }
                    string __tmp219_line = "."; //766:76
                    if (!string.IsNullOrEmpty(__tmp219_line))
                    {
                        __out.Write(__tmp219_line);
                        __tmp216_outputWritten = true;
                    }
                    var __tmp220 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp220.Write(op.Name);
                    var __tmp220Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp220.ToStringAndFree());
                    bool __tmp220_last = __tmp220Reader.EndOfStream;
                    while(!__tmp220_last)
                    {
                        ReadOnlySpan<char> __tmp220_line = __tmp220Reader.ReadLine();
                        __tmp220_last = __tmp220Reader.EndOfStream;
                        if (!__tmp220_last || !__tmp220_line.IsEmpty)
                        {
                            __out.Write(__tmp220_line);
                            __tmp216_outputWritten = true;
                        }
                        if (!__tmp220_last || __tmp216_outputWritten) __out.AppendLine(true);
                    }
                    if (__tmp216_outputWritten)
                    {
                        __out.AppendLine(false); //766:86
                    }
                    __out.Write("	/// </summary>"); //767:1
                    __out.AppendLine(false); //767:16
                    bool __tmp222_outputWritten = false;
                    string __tmp223_line = "	public abstract "; //768:1
                    if (!string.IsNullOrEmpty(__tmp223_line))
                    {
                        __out.Write(__tmp223_line);
                        __tmp222_outputWritten = true;
                    }
                    var __tmp224 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp224.Write(CSharpName(op.ReturnType, model, ClassKind.ImmutableOperation, true));
                    var __tmp224Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp224.ToStringAndFree());
                    bool __tmp224_last = __tmp224Reader.EndOfStream;
                    while(!__tmp224_last)
                    {
                        ReadOnlySpan<char> __tmp224_line = __tmp224Reader.ReadLine();
                        __tmp224_last = __tmp224Reader.EndOfStream;
                        if (!__tmp224_last || !__tmp224_line.IsEmpty)
                        {
                            __out.Write(__tmp224_line);
                            __tmp222_outputWritten = true;
                        }
                        if (!__tmp224_last) __out.AppendLine(true);
                    }
                    string __tmp225_line = " "; //768:87
                    if (!string.IsNullOrEmpty(__tmp225_line))
                    {
                        __out.Write(__tmp225_line);
                        __tmp222_outputWritten = true;
                    }
                    var __tmp226 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp226.Write(CSharpName(enm, model, ClassKind.Immutable));
                    var __tmp226Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp226.ToStringAndFree());
                    bool __tmp226_last = __tmp226Reader.EndOfStream;
                    while(!__tmp226_last)
                    {
                        ReadOnlySpan<char> __tmp226_line = __tmp226Reader.ReadLine();
                        __tmp226_last = __tmp226Reader.EndOfStream;
                        if (!__tmp226_last || !__tmp226_line.IsEmpty)
                        {
                            __out.Write(__tmp226_line);
                            __tmp222_outputWritten = true;
                        }
                        if (!__tmp226_last) __out.AppendLine(true);
                    }
                    string __tmp227_line = "_"; //768:132
                    if (!string.IsNullOrEmpty(__tmp227_line))
                    {
                        __out.Write(__tmp227_line);
                        __tmp222_outputWritten = true;
                    }
                    var __tmp228 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp228.Write(op.Name);
                    var __tmp228Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp228.ToStringAndFree());
                    bool __tmp228_last = __tmp228Reader.EndOfStream;
                    while(!__tmp228_last)
                    {
                        ReadOnlySpan<char> __tmp228_line = __tmp228Reader.ReadLine();
                        __tmp228_last = __tmp228Reader.EndOfStream;
                        if (!__tmp228_last || !__tmp228_line.IsEmpty)
                        {
                            __out.Write(__tmp228_line);
                            __tmp222_outputWritten = true;
                        }
                        if (!__tmp228_last) __out.AppendLine(true);
                    }
                    string __tmp229_line = "("; //768:142
                    if (!string.IsNullOrEmpty(__tmp229_line))
                    {
                        __out.Write(__tmp229_line);
                        __tmp222_outputWritten = true;
                    }
                    var __tmp230 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp230.Write(GetImplParameters(model, enm, op, ClassKind.ImmutableOperation));
                    var __tmp230Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp230.ToStringAndFree());
                    bool __tmp230_last = __tmp230Reader.EndOfStream;
                    while(!__tmp230_last)
                    {
                        ReadOnlySpan<char> __tmp230_line = __tmp230Reader.ReadLine();
                        __tmp230_last = __tmp230Reader.EndOfStream;
                        if (!__tmp230_last || !__tmp230_line.IsEmpty)
                        {
                            __out.Write(__tmp230_line);
                            __tmp222_outputWritten = true;
                        }
                        if (!__tmp230_last) __out.AppendLine(true);
                    }
                    string __tmp231_line = ");"; //768:208
                    if (!string.IsNullOrEmpty(__tmp231_line))
                    {
                        __out.Write(__tmp231_line);
                        __tmp222_outputWritten = true;
                    }
                    if (__tmp222_outputWritten) __out.AppendLine(true);
                    if (__tmp222_outputWritten)
                    {
                        __out.AppendLine(false); //768:210
                    }
                }
                __out.AppendLine(true); //770:2
            }
            __out.Write("}"); //772:1
            __out.AppendLine(false); //772:2
            return __out.ToStringAndFree();
        }

        public string GenerateImplementation(MetaModel model) //775:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //776:2
            bool metaMetaModel = IsMetaMetaModel(model); //777:2
            __out.Write("/// <summary>"); //778:1
            __out.AppendLine(false); //778:14
            __out.Write("/// Class for implementing the behavior of the model elements."); //779:1
            __out.AppendLine(false); //779:63
            __out.Write("/// </summary>"); //780:1
            __out.AppendLine(false); //780:15
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //781:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Write(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp4.Write(CSharpName(model, ModelKind.Implementation));
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
            string __tmp5_line = " : "; //781:60
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp6.Write(CSharpName(model, ModelKind.ImplementationBase));
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
                if (!__tmp6_last || __tmp2_outputWritten) __out.AppendLine(true);
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //781:111
            }
            __out.Write("{"); //782:1
            __out.AppendLine(false); //782:2
            var __loop48_results = 
                (from __loop48_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //783:8
                from cls in __Enumerate((__loop48_var1).GetEnumerator()).OfType<MetaClass>() //783:38
                select new { __loop48_var1 = __loop48_var1, cls = cls}
                ).ToList(); //783:3
            for (int __loop48_iteration = 0; __loop48_iteration < __loop48_results.Count; ++__loop48_iteration)
            {
                var __tmp7 = __loop48_results[__loop48_iteration];
                var __loop48_var1 = __tmp7.__loop48_var1;
                var cls = __tmp7.cls;
                var __loop49_results = 
                    (from __loop49_var1 in __Enumerate((cls).GetEnumerator()) //784:8
                    from prop in __Enumerate((__loop49_var1.Properties).GetEnumerator()) //784:13
                    where prop.Kind == MetaPropertyKind.Readonly || prop.Kind == MetaPropertyKind.Lazy || prop.Kind == MetaPropertyKind.Derived //784:29
                    select new { __loop49_var1 = __loop49_var1, prop = prop}
                    ).ToList(); //784:3
                for (int __loop49_iteration = 0; __loop49_iteration < __loop49_results.Count; ++__loop49_iteration)
                {
                    var __tmp8 = __loop49_results[__loop49_iteration];
                    var __loop49_var1 = __tmp8.__loop49_var1;
                    var prop = __tmp8.prop;
                    if (metaMetaModel && cls.Name == "MetaConstant" && prop.Name == "Value") //785:4
                    {
                    }
                    else //786:4
                    {
                        __out.AppendLine(true); //787:2
                        __out.Write("	/// <summary>"); //788:1
                        __out.AppendLine(false); //788:15
                        bool __tmp10_outputWritten = false;
                        string __tmp11_line = "	/// Computes the value of the property: "; //789:1
                        if (!string.IsNullOrEmpty(__tmp11_line))
                        {
                            __out.Write(__tmp11_line);
                            __tmp10_outputWritten = true;
                        }
                        var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp12.Write(CSharpName(cls, model, ClassKind.Immutable));
                        var __tmp12Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp12.ToStringAndFree());
                        bool __tmp12_last = __tmp12Reader.EndOfStream;
                        while(!__tmp12_last)
                        {
                            ReadOnlySpan<char> __tmp12_line = __tmp12Reader.ReadLine();
                            __tmp12_last = __tmp12Reader.EndOfStream;
                            if (!__tmp12_last || !__tmp12_line.IsEmpty)
                            {
                                __out.Write(__tmp12_line);
                                __tmp10_outputWritten = true;
                            }
                            if (!__tmp12_last) __out.AppendLine(true);
                        }
                        string __tmp13_line = "."; //789:86
                        if (!string.IsNullOrEmpty(__tmp13_line))
                        {
                            __out.Write(__tmp13_line);
                            __tmp10_outputWritten = true;
                        }
                        var __tmp14 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp14.Write(CSharpName(prop, model));
                        var __tmp14Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp14.ToStringAndFree());
                        bool __tmp14_last = __tmp14Reader.EndOfStream;
                        while(!__tmp14_last)
                        {
                            ReadOnlySpan<char> __tmp14_line = __tmp14Reader.ReadLine();
                            __tmp14_last = __tmp14Reader.EndOfStream;
                            if (!__tmp14_last || !__tmp14_line.IsEmpty)
                            {
                                __out.Write(__tmp14_line);
                                __tmp10_outputWritten = true;
                            }
                            if (!__tmp14_last || __tmp10_outputWritten) __out.AppendLine(true);
                        }
                        if (__tmp10_outputWritten)
                        {
                            __out.AppendLine(false); //789:111
                        }
                        __out.Write("	/// </summary	"); //790:1
                        __out.AppendLine(false); //790:16
                        bool __tmp16_outputWritten = false;
                        string __tmp17_line = "	public override "; //791:1
                        if (!string.IsNullOrEmpty(__tmp17_line))
                        {
                            __out.Write(__tmp17_line);
                            __tmp16_outputWritten = true;
                        }
                        var __tmp18 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp18.Write(CSharpName(prop.Type, model, ClassKind.BuilderOperation, true));
                        var __tmp18Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp18.ToStringAndFree());
                        bool __tmp18_last = __tmp18Reader.EndOfStream;
                        while(!__tmp18_last)
                        {
                            ReadOnlySpan<char> __tmp18_line = __tmp18Reader.ReadLine();
                            __tmp18_last = __tmp18Reader.EndOfStream;
                            if (!__tmp18_last || !__tmp18_line.IsEmpty)
                            {
                                __out.Write(__tmp18_line);
                                __tmp16_outputWritten = true;
                            }
                            if (!__tmp18_last) __out.AppendLine(true);
                        }
                        string __tmp19_line = " "; //791:81
                        if (!string.IsNullOrEmpty(__tmp19_line))
                        {
                            __out.Write(__tmp19_line);
                            __tmp16_outputWritten = true;
                        }
                        var __tmp20 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp20.Write(CSharpName(cls, model, ClassKind.Immutable));
                        var __tmp20Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp20.ToStringAndFree());
                        bool __tmp20_last = __tmp20Reader.EndOfStream;
                        while(!__tmp20_last)
                        {
                            ReadOnlySpan<char> __tmp20_line = __tmp20Reader.ReadLine();
                            __tmp20_last = __tmp20Reader.EndOfStream;
                            if (!__tmp20_last || !__tmp20_line.IsEmpty)
                            {
                                __out.Write(__tmp20_line);
                                __tmp16_outputWritten = true;
                            }
                            if (!__tmp20_last) __out.AppendLine(true);
                        }
                        string __tmp21_line = "_ComputeProperty_"; //791:126
                        if (!string.IsNullOrEmpty(__tmp21_line))
                        {
                            __out.Write(__tmp21_line);
                            __tmp16_outputWritten = true;
                        }
                        var __tmp22 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp22.Write(CSharpName(prop, model));
                        var __tmp22Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp22.ToStringAndFree());
                        bool __tmp22_last = __tmp22Reader.EndOfStream;
                        while(!__tmp22_last)
                        {
                            ReadOnlySpan<char> __tmp22_line = __tmp22Reader.ReadLine();
                            __tmp22_last = __tmp22Reader.EndOfStream;
                            if (!__tmp22_last || !__tmp22_line.IsEmpty)
                            {
                                __out.Write(__tmp22_line);
                                __tmp16_outputWritten = true;
                            }
                            if (!__tmp22_last) __out.AppendLine(true);
                        }
                        string __tmp23_line = "("; //791:167
                        if (!string.IsNullOrEmpty(__tmp23_line))
                        {
                            __out.Write(__tmp23_line);
                            __tmp16_outputWritten = true;
                        }
                        var __tmp24 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp24.Write(CSharpName(cls, model, ClassKind.Builder));
                        var __tmp24Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp24.ToStringAndFree());
                        bool __tmp24_last = __tmp24Reader.EndOfStream;
                        while(!__tmp24_last)
                        {
                            ReadOnlySpan<char> __tmp24_line = __tmp24Reader.ReadLine();
                            __tmp24_last = __tmp24Reader.EndOfStream;
                            if (!__tmp24_last || !__tmp24_line.IsEmpty)
                            {
                                __out.Write(__tmp24_line);
                                __tmp16_outputWritten = true;
                            }
                            if (!__tmp24_last) __out.AppendLine(true);
                        }
                        string __tmp25_line = " _this)"; //791:210
                        if (!string.IsNullOrEmpty(__tmp25_line))
                        {
                            __out.Write(__tmp25_line);
                            __tmp16_outputWritten = true;
                        }
                        if (__tmp16_outputWritten) __out.AppendLine(true);
                        if (__tmp16_outputWritten)
                        {
                            __out.AppendLine(false); //791:217
                        }
                        __out.Write("	{"); //792:1
                        __out.AppendLine(false); //792:3
                        bool __tmp27_outputWritten = false;
                        string __tmp26Prefix = "		"; //793:1
                        var __tmp28 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp28.Write(GetDefaultReturn(CSharpName(prop.Type, model, ClassKind.BuilderOperation, true)));
                        var __tmp28Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp28.ToStringAndFree());
                        bool __tmp28_last = __tmp28Reader.EndOfStream;
                        while(!__tmp28_last)
                        {
                            ReadOnlySpan<char> __tmp28_line = __tmp28Reader.ReadLine();
                            __tmp28_last = __tmp28Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp26Prefix))
                            {
                                __out.Write(__tmp26Prefix);
                                __tmp27_outputWritten = true;
                            }
                            if (!__tmp28_last || !__tmp28_line.IsEmpty)
                            {
                                __out.Write(__tmp28_line);
                                __tmp27_outputWritten = true;
                            }
                            if (!__tmp28_last || __tmp27_outputWritten) __out.AppendLine(true);
                        }
                        if (__tmp27_outputWritten)
                        {
                            __out.AppendLine(false); //793:84
                        }
                        __out.Write("	}"); //794:1
                        __out.AppendLine(false); //794:3
                    }
                }
                var __loop50_results = 
                    (from __loop50_var1 in __Enumerate((cls).GetEnumerator()) //797:8
                    from op in __Enumerate((__loop50_var1.Operations).GetEnumerator()) //797:13
                    select new { __loop50_var1 = __loop50_var1, op = op}
                    ).ToList(); //797:3
                for (int __loop50_iteration = 0; __loop50_iteration < __loop50_results.Count; ++__loop50_iteration)
                {
                    var __tmp29 = __loop50_results[__loop50_iteration];
                    var __loop50_var1 = __tmp29.__loop50_var1;
                    var op = __tmp29.op;
                    __out.AppendLine(true); //798:2
                    __out.Write("	/// <summary>"); //799:1
                    __out.AppendLine(false); //799:15
                    bool __tmp31_outputWritten = false;
                    string __tmp32_line = "	/// Implements the operation: "; //800:1
                    if (!string.IsNullOrEmpty(__tmp32_line))
                    {
                        __out.Write(__tmp32_line);
                        __tmp31_outputWritten = true;
                    }
                    var __tmp33 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp33.Write(CSharpName(cls, model, ClassKind.Builder));
                    var __tmp33Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp33.ToStringAndFree());
                    bool __tmp33_last = __tmp33Reader.EndOfStream;
                    while(!__tmp33_last)
                    {
                        ReadOnlySpan<char> __tmp33_line = __tmp33Reader.ReadLine();
                        __tmp33_last = __tmp33Reader.EndOfStream;
                        if (!__tmp33_last || !__tmp33_line.IsEmpty)
                        {
                            __out.Write(__tmp33_line);
                            __tmp31_outputWritten = true;
                        }
                        if (!__tmp33_last) __out.AppendLine(true);
                    }
                    string __tmp34_line = "."; //800:74
                    if (!string.IsNullOrEmpty(__tmp34_line))
                    {
                        __out.Write(__tmp34_line);
                        __tmp31_outputWritten = true;
                    }
                    var __tmp35 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp35.Write(op.Name);
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
                    string __tmp36_line = "()"; //800:84
                    if (!string.IsNullOrEmpty(__tmp36_line))
                    {
                        __out.Write(__tmp36_line);
                        __tmp31_outputWritten = true;
                    }
                    if (__tmp31_outputWritten) __out.AppendLine(true);
                    if (__tmp31_outputWritten)
                    {
                        __out.AppendLine(false); //800:86
                    }
                    __out.Write("	/// </summary>"); //801:1
                    __out.AppendLine(false); //801:16
                    bool __tmp38_outputWritten = false;
                    string __tmp39_line = "	public override "; //802:1
                    if (!string.IsNullOrEmpty(__tmp39_line))
                    {
                        __out.Write(__tmp39_line);
                        __tmp38_outputWritten = true;
                    }
                    var __tmp40 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp40.Write(CSharpName(op.ReturnType, model, ClassKind.BuilderOperation, true));
                    var __tmp40Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp40.ToStringAndFree());
                    bool __tmp40_last = __tmp40Reader.EndOfStream;
                    while(!__tmp40_last)
                    {
                        ReadOnlySpan<char> __tmp40_line = __tmp40Reader.ReadLine();
                        __tmp40_last = __tmp40Reader.EndOfStream;
                        if (!__tmp40_last || !__tmp40_line.IsEmpty)
                        {
                            __out.Write(__tmp40_line);
                            __tmp38_outputWritten = true;
                        }
                        if (!__tmp40_last) __out.AppendLine(true);
                    }
                    string __tmp41_line = " "; //802:85
                    if (!string.IsNullOrEmpty(__tmp41_line))
                    {
                        __out.Write(__tmp41_line);
                        __tmp38_outputWritten = true;
                    }
                    var __tmp42 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp42.Write(CSharpName(cls, model, ClassKind.Immutable));
                    var __tmp42Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp42.ToStringAndFree());
                    bool __tmp42_last = __tmp42Reader.EndOfStream;
                    while(!__tmp42_last)
                    {
                        ReadOnlySpan<char> __tmp42_line = __tmp42Reader.ReadLine();
                        __tmp42_last = __tmp42Reader.EndOfStream;
                        if (!__tmp42_last || !__tmp42_line.IsEmpty)
                        {
                            __out.Write(__tmp42_line);
                            __tmp38_outputWritten = true;
                        }
                        if (!__tmp42_last) __out.AppendLine(true);
                    }
                    string __tmp43_line = "_"; //802:130
                    if (!string.IsNullOrEmpty(__tmp43_line))
                    {
                        __out.Write(__tmp43_line);
                        __tmp38_outputWritten = true;
                    }
                    var __tmp44 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp44.Write(op.Name);
                    var __tmp44Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp44.ToStringAndFree());
                    bool __tmp44_last = __tmp44Reader.EndOfStream;
                    while(!__tmp44_last)
                    {
                        ReadOnlySpan<char> __tmp44_line = __tmp44Reader.ReadLine();
                        __tmp44_last = __tmp44Reader.EndOfStream;
                        if (!__tmp44_last || !__tmp44_line.IsEmpty)
                        {
                            __out.Write(__tmp44_line);
                            __tmp38_outputWritten = true;
                        }
                        if (!__tmp44_last) __out.AppendLine(true);
                    }
                    string __tmp45_line = "("; //802:140
                    if (!string.IsNullOrEmpty(__tmp45_line))
                    {
                        __out.Write(__tmp45_line);
                        __tmp38_outputWritten = true;
                    }
                    var __tmp46 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp46.Write(GetImplParameters(model, cls, op, ClassKind.BuilderOperation));
                    var __tmp46Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp46.ToStringAndFree());
                    bool __tmp46_last = __tmp46Reader.EndOfStream;
                    while(!__tmp46_last)
                    {
                        ReadOnlySpan<char> __tmp46_line = __tmp46Reader.ReadLine();
                        __tmp46_last = __tmp46Reader.EndOfStream;
                        if (!__tmp46_last || !__tmp46_line.IsEmpty)
                        {
                            __out.Write(__tmp46_line);
                            __tmp38_outputWritten = true;
                        }
                        if (!__tmp46_last) __out.AppendLine(true);
                    }
                    string __tmp47_line = ")"; //802:204
                    if (!string.IsNullOrEmpty(__tmp47_line))
                    {
                        __out.Write(__tmp47_line);
                        __tmp38_outputWritten = true;
                    }
                    if (__tmp38_outputWritten) __out.AppendLine(true);
                    if (__tmp38_outputWritten)
                    {
                        __out.AppendLine(false); //802:205
                    }
                    __out.Write("	{"); //803:1
                    __out.AppendLine(false); //803:3
                    bool __tmp49_outputWritten = false;
                    string __tmp48Prefix = "		"; //804:1
                    var __tmp50 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp50.Write(GetDefaultReturn(CSharpName(op.ReturnType, model, ClassKind.BuilderOperation, true)));
                    var __tmp50Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp50.ToStringAndFree());
                    bool __tmp50_last = __tmp50Reader.EndOfStream;
                    while(!__tmp50_last)
                    {
                        ReadOnlySpan<char> __tmp50_line = __tmp50Reader.ReadLine();
                        __tmp50_last = __tmp50Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp48Prefix))
                        {
                            __out.Write(__tmp48Prefix);
                            __tmp49_outputWritten = true;
                        }
                        if (!__tmp50_last || !__tmp50_line.IsEmpty)
                        {
                            __out.Write(__tmp50_line);
                            __tmp49_outputWritten = true;
                        }
                        if (!__tmp50_last || __tmp49_outputWritten) __out.AppendLine(true);
                    }
                    if (__tmp49_outputWritten)
                    {
                        __out.AppendLine(false); //804:88
                    }
                    __out.Write("	}"); //805:1
                    __out.AppendLine(false); //805:3
                }
                __out.AppendLine(true); //807:2
            }
            var __loop51_results = 
                (from __loop51_var1 in __Enumerate((model).GetEnumerator()) //809:8
                from Namespace in __Enumerate((__loop51_var1.Namespace).GetEnumerator()) //809:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //809:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //809:40
                select new { __loop51_var1 = __loop51_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //809:3
            for (int __loop51_iteration = 0; __loop51_iteration < __loop51_results.Count; ++__loop51_iteration)
            {
                var __tmp51 = __loop51_results[__loop51_iteration];
                var __loop51_var1 = __tmp51.__loop51_var1;
                var Namespace = __tmp51.Namespace;
                var Declarations = __tmp51.Declarations;
                var enm = __tmp51.enm;
                var __loop52_results = 
                    (from __loop52_var1 in __Enumerate((enm).GetEnumerator()) //810:8
                    from op in __Enumerate((__loop52_var1.Operations).GetEnumerator()) //810:13
                    select new { __loop52_var1 = __loop52_var1, op = op}
                    ).ToList(); //810:3
                for (int __loop52_iteration = 0; __loop52_iteration < __loop52_results.Count; ++__loop52_iteration)
                {
                    var __tmp52 = __loop52_results[__loop52_iteration];
                    var __loop52_var1 = __tmp52.__loop52_var1;
                    var op = __tmp52.op;
                    __out.AppendLine(true); //811:2
                    __out.Write("	/// <summary>"); //812:1
                    __out.AppendLine(false); //812:15
                    bool __tmp54_outputWritten = false;
                    string __tmp55_line = "	/// Implements the operation: "; //813:1
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Write(__tmp55_line);
                        __tmp54_outputWritten = true;
                    }
                    var __tmp56 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp56.Write(CSharpName(enm, model, ClassKind.Immutable));
                    var __tmp56Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp56.ToStringAndFree());
                    bool __tmp56_last = __tmp56Reader.EndOfStream;
                    while(!__tmp56_last)
                    {
                        ReadOnlySpan<char> __tmp56_line = __tmp56Reader.ReadLine();
                        __tmp56_last = __tmp56Reader.EndOfStream;
                        if (!__tmp56_last || !__tmp56_line.IsEmpty)
                        {
                            __out.Write(__tmp56_line);
                            __tmp54_outputWritten = true;
                        }
                        if (!__tmp56_last) __out.AppendLine(true);
                    }
                    string __tmp57_line = "."; //813:76
                    if (!string.IsNullOrEmpty(__tmp57_line))
                    {
                        __out.Write(__tmp57_line);
                        __tmp54_outputWritten = true;
                    }
                    var __tmp58 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp58.Write(op.Name);
                    var __tmp58Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp58.ToStringAndFree());
                    bool __tmp58_last = __tmp58Reader.EndOfStream;
                    while(!__tmp58_last)
                    {
                        ReadOnlySpan<char> __tmp58_line = __tmp58Reader.ReadLine();
                        __tmp58_last = __tmp58Reader.EndOfStream;
                        if (!__tmp58_last || !__tmp58_line.IsEmpty)
                        {
                            __out.Write(__tmp58_line);
                            __tmp54_outputWritten = true;
                        }
                        if (!__tmp58_last || __tmp54_outputWritten) __out.AppendLine(true);
                    }
                    if (__tmp54_outputWritten)
                    {
                        __out.AppendLine(false); //813:86
                    }
                    __out.Write("	/// </summary>"); //814:1
                    __out.AppendLine(false); //814:16
                    bool __tmp60_outputWritten = false;
                    string __tmp61_line = "	public override "; //815:1
                    if (!string.IsNullOrEmpty(__tmp61_line))
                    {
                        __out.Write(__tmp61_line);
                        __tmp60_outputWritten = true;
                    }
                    var __tmp62 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp62.Write(CSharpName(op.ReturnType, model, ClassKind.ImmutableOperation, true));
                    var __tmp62Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp62.ToStringAndFree());
                    bool __tmp62_last = __tmp62Reader.EndOfStream;
                    while(!__tmp62_last)
                    {
                        ReadOnlySpan<char> __tmp62_line = __tmp62Reader.ReadLine();
                        __tmp62_last = __tmp62Reader.EndOfStream;
                        if (!__tmp62_last || !__tmp62_line.IsEmpty)
                        {
                            __out.Write(__tmp62_line);
                            __tmp60_outputWritten = true;
                        }
                        if (!__tmp62_last) __out.AppendLine(true);
                    }
                    string __tmp63_line = " "; //815:87
                    if (!string.IsNullOrEmpty(__tmp63_line))
                    {
                        __out.Write(__tmp63_line);
                        __tmp60_outputWritten = true;
                    }
                    var __tmp64 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp64.Write(CSharpName(enm, model, ClassKind.Immutable));
                    var __tmp64Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp64.ToStringAndFree());
                    bool __tmp64_last = __tmp64Reader.EndOfStream;
                    while(!__tmp64_last)
                    {
                        ReadOnlySpan<char> __tmp64_line = __tmp64Reader.ReadLine();
                        __tmp64_last = __tmp64Reader.EndOfStream;
                        if (!__tmp64_last || !__tmp64_line.IsEmpty)
                        {
                            __out.Write(__tmp64_line);
                            __tmp60_outputWritten = true;
                        }
                        if (!__tmp64_last) __out.AppendLine(true);
                    }
                    string __tmp65_line = "_"; //815:132
                    if (!string.IsNullOrEmpty(__tmp65_line))
                    {
                        __out.Write(__tmp65_line);
                        __tmp60_outputWritten = true;
                    }
                    var __tmp66 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp66.Write(op.Name);
                    var __tmp66Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp66.ToStringAndFree());
                    bool __tmp66_last = __tmp66Reader.EndOfStream;
                    while(!__tmp66_last)
                    {
                        ReadOnlySpan<char> __tmp66_line = __tmp66Reader.ReadLine();
                        __tmp66_last = __tmp66Reader.EndOfStream;
                        if (!__tmp66_last || !__tmp66_line.IsEmpty)
                        {
                            __out.Write(__tmp66_line);
                            __tmp60_outputWritten = true;
                        }
                        if (!__tmp66_last) __out.AppendLine(true);
                    }
                    string __tmp67_line = "("; //815:142
                    if (!string.IsNullOrEmpty(__tmp67_line))
                    {
                        __out.Write(__tmp67_line);
                        __tmp60_outputWritten = true;
                    }
                    var __tmp68 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp68.Write(GetImplParameters(model, enm, op, ClassKind.ImmutableOperation));
                    var __tmp68Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp68.ToStringAndFree());
                    bool __tmp68_last = __tmp68Reader.EndOfStream;
                    while(!__tmp68_last)
                    {
                        ReadOnlySpan<char> __tmp68_line = __tmp68Reader.ReadLine();
                        __tmp68_last = __tmp68Reader.EndOfStream;
                        if (!__tmp68_last || !__tmp68_line.IsEmpty)
                        {
                            __out.Write(__tmp68_line);
                            __tmp60_outputWritten = true;
                        }
                        if (!__tmp68_last) __out.AppendLine(true);
                    }
                    string __tmp69_line = ")"; //815:208
                    if (!string.IsNullOrEmpty(__tmp69_line))
                    {
                        __out.Write(__tmp69_line);
                        __tmp60_outputWritten = true;
                    }
                    if (__tmp60_outputWritten) __out.AppendLine(true);
                    if (__tmp60_outputWritten)
                    {
                        __out.AppendLine(false); //815:209
                    }
                    __out.Write("	{"); //816:1
                    __out.AppendLine(false); //816:3
                    bool __tmp71_outputWritten = false;
                    string __tmp70Prefix = "		"; //817:1
                    var __tmp72 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp72.Write(GetDefaultReturn(CSharpName(op.ReturnType, model, ClassKind.ImmutableOperation, true)));
                    var __tmp72Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp72.ToStringAndFree());
                    bool __tmp72_last = __tmp72Reader.EndOfStream;
                    while(!__tmp72_last)
                    {
                        ReadOnlySpan<char> __tmp72_line = __tmp72Reader.ReadLine();
                        __tmp72_last = __tmp72Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp70Prefix))
                        {
                            __out.Write(__tmp70Prefix);
                            __tmp71_outputWritten = true;
                        }
                        if (!__tmp72_last || !__tmp72_line.IsEmpty)
                        {
                            __out.Write(__tmp72_line);
                            __tmp71_outputWritten = true;
                        }
                        if (!__tmp72_last || __tmp71_outputWritten) __out.AppendLine(true);
                    }
                    if (__tmp71_outputWritten)
                    {
                        __out.AppendLine(false); //817:90
                    }
                    __out.Write("	}"); //818:1
                    __out.AppendLine(false); //818:3
                }
                __out.AppendLine(true); //820:2
            }
            __out.Write("}"); //822:1
            __out.AppendLine(false); //822:2
            return __out.ToStringAndFree();
        }

        public string GetImplParameters(MetaModel model, MetaClass cls, MetaOperation op, ClassKind kind) //825:1
        {
            string result = CSharpName(cls, model, kind) + " _this"; //826:2
            string delim = ", "; //827:2
            var __loop53_results = 
                (from __loop53_var1 in __Enumerate((op).GetEnumerator()) //828:7
                from param in __Enumerate((__loop53_var1.Parameters).GetEnumerator()) //828:11
                select new { __loop53_var1 = __loop53_var1, param = param}
                ).ToList(); //828:2
            for (int __loop53_iteration = 0; __loop53_iteration < __loop53_results.Count; ++__loop53_iteration)
            {
                var __tmp1 = __loop53_results[__loop53_iteration];
                var __loop53_var1 = __tmp1.__loop53_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, kind, true) + " " + param.Name; //829:3
            }
            return result; //831:2
        }

        public string GetImplParameters(MetaModel model, MetaEnum enm, MetaOperation op, ClassKind kind) //834:1
        {
            string result = CSharpName(enm, model, kind) + " _this"; //835:2
            string delim = ", "; //836:2
            var __loop54_results = 
                (from __loop54_var1 in __Enumerate((op).GetEnumerator()) //837:7
                from param in __Enumerate((__loop54_var1.Parameters).GetEnumerator()) //837:11
                select new { __loop54_var1 = __loop54_var1, param = param}
                ).ToList(); //837:2
            for (int __loop54_iteration = 0; __loop54_iteration < __loop54_results.Count; ++__loop54_iteration)
            {
                var __tmp1 = __loop54_results[__loop54_iteration];
                var __loop54_var1 = __tmp1.__loop54_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, kind, true) + " " + param.Name; //838:3
            }
            return result; //840:2
        }

        public string GenerateEnum(MetaModel model, MetaEnum enm) //844:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.AppendLine(true); //845:1
            bool __tmp2_outputWritten = false;
            var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp3.Write(GenerateDocumentation(enm));
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
                __out.AppendLine(false); //846:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public enum "; //847:1
            if (!string.IsNullOrEmpty(__tmp6_line))
            {
                __out.Write(__tmp6_line);
                __tmp5_outputWritten = true;
            }
            var __tmp7 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp7.Write(CSharpName(enm, model));
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
                __out.AppendLine(false); //847:36
            }
            __out.Write("{"); //848:1
            __out.AppendLine(false); //848:2
            var __loop55_results = 
                (from __loop55_var1 in __Enumerate((enm).GetEnumerator()) //849:8
                from value in __Enumerate((__loop55_var1.EnumLiterals).GetEnumerator()) //849:13
                select new { __loop55_var1 = __loop55_var1, value = value}
                ).ToList(); //849:3
            for (int __loop55_iteration = 0; __loop55_iteration < __loop55_results.Count; ++__loop55_iteration)
            {
                string delim; //849:31
                if (__loop55_iteration+1 < __loop55_results.Count) delim = ",";
                else delim = string.Empty;
                var __tmp8 = __loop55_results[__loop55_iteration];
                var __loop55_var1 = __tmp8.__loop55_var1;
                var value = __tmp8.value;
                bool __tmp10_outputWritten = false;
                string __tmp9Prefix = "	"; //850:1
                var __tmp11 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp11.Write(GenerateDocumentation(value));
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
                    __out.AppendLine(false); //850:32
                }
                bool __tmp13_outputWritten = false;
                string __tmp12Prefix = "	"; //851:1
                var __tmp14 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp14.Write(value.Name);
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
                __tmp15.Write(delim);
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
                    __out.AppendLine(false); //851:21
                }
            }
            __out.Write("}"); //853:1
            __out.AppendLine(false); //853:2
            __out.AppendLine(true); //854:1
            bool __tmp17_outputWritten = false;
            string __tmp18_line = "public static class "; //855:1
            if (!string.IsNullOrEmpty(__tmp18_line))
            {
                __out.Write(__tmp18_line);
                __tmp17_outputWritten = true;
            }
            var __tmp19 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp19.Write(enm.Name);
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
            string __tmp20_line = "Extensions"; //855:31
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Write(__tmp20_line);
                __tmp17_outputWritten = true;
            }
            if (__tmp17_outputWritten) __out.AppendLine(true);
            if (__tmp17_outputWritten)
            {
                __out.AppendLine(false); //855:41
            }
            __out.Write("{"); //856:1
            __out.AppendLine(false); //856:2
            var __loop56_results = 
                (from __loop56_var1 in __Enumerate((enm).GetEnumerator()) //857:8
                from op in __Enumerate((__loop56_var1.Operations).GetEnumerator()) //857:13
                select new { __loop56_var1 = __loop56_var1, op = op}
                ).ToList(); //857:3
            for (int __loop56_iteration = 0; __loop56_iteration < __loop56_results.Count; ++__loop56_iteration)
            {
                var __tmp21 = __loop56_results[__loop56_iteration];
                var __loop56_var1 = __tmp21.__loop56_var1;
                var op = __tmp21.op;
                bool __tmp23_outputWritten = false;
                string __tmp24_line = "	public static "; //858:1
                if (!string.IsNullOrEmpty(__tmp24_line))
                {
                    __out.Write(__tmp24_line);
                    __tmp23_outputWritten = true;
                }
                var __tmp25 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp25.Write(CSharpName(op.ReturnType, model, ClassKind.ImmutableOperation));
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
                string __tmp26_line = " "; //858:79
                if (!string.IsNullOrEmpty(__tmp26_line))
                {
                    __out.Write(__tmp26_line);
                    __tmp23_outputWritten = true;
                }
                var __tmp27 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp27.Write(op.Name);
                var __tmp27Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp27.ToStringAndFree());
                bool __tmp27_last = __tmp27Reader.EndOfStream;
                while(!__tmp27_last)
                {
                    ReadOnlySpan<char> __tmp27_line = __tmp27Reader.ReadLine();
                    __tmp27_last = __tmp27Reader.EndOfStream;
                    if (!__tmp27_last || !__tmp27_line.IsEmpty)
                    {
                        __out.Write(__tmp27_line);
                        __tmp23_outputWritten = true;
                    }
                    if (!__tmp27_last) __out.AppendLine(true);
                }
                string __tmp28_line = "("; //858:89
                if (!string.IsNullOrEmpty(__tmp28_line))
                {
                    __out.Write(__tmp28_line);
                    __tmp23_outputWritten = true;
                }
                var __tmp29 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp29.Write(GetEnumImplParameters(model, enm, op, ClassKind.ImmutableOperation));
                var __tmp29Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp29.ToStringAndFree());
                bool __tmp29_last = __tmp29Reader.EndOfStream;
                while(!__tmp29_last)
                {
                    ReadOnlySpan<char> __tmp29_line = __tmp29Reader.ReadLine();
                    __tmp29_last = __tmp29Reader.EndOfStream;
                    if (!__tmp29_last || !__tmp29_line.IsEmpty)
                    {
                        __out.Write(__tmp29_line);
                        __tmp23_outputWritten = true;
                    }
                    if (!__tmp29_last) __out.AppendLine(true);
                }
                string __tmp30_line = ")"; //858:159
                if (!string.IsNullOrEmpty(__tmp30_line))
                {
                    __out.Write(__tmp30_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //858:160
                }
                __out.Write("	{"); //859:1
                __out.AppendLine(false); //859:3
                bool __tmp32_outputWritten = false;
                string __tmp31Prefix = "		"; //860:1
                var __tmp33 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp33.Write(GetReturn(CSharpName(op.ReturnType, model, ClassKind.ImmutableOperation)));
                var __tmp33Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp33.ToStringAndFree());
                bool __tmp33_last = __tmp33Reader.EndOfStream;
                while(!__tmp33_last)
                {
                    ReadOnlySpan<char> __tmp33_line = __tmp33Reader.ReadLine();
                    __tmp33_last = __tmp33Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp31Prefix))
                    {
                        __out.Write(__tmp31Prefix);
                        __tmp32_outputWritten = true;
                    }
                    if (!__tmp33_last || !__tmp33_line.IsEmpty)
                    {
                        __out.Write(__tmp33_line);
                        __tmp32_outputWritten = true;
                    }
                    if (!__tmp33_last) __out.AppendLine(true);
                }
                var __tmp34 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp34.Write(CSharpName(model, ModelKind.ImplementationProvider));
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
                string __tmp35_line = ".Implementation."; //860:129
                if (!string.IsNullOrEmpty(__tmp35_line))
                {
                    __out.Write(__tmp35_line);
                    __tmp32_outputWritten = true;
                }
                var __tmp36 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp36.Write(CSharpName(op.Enum, model, ClassKind.Immutable));
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
                string __tmp37_line = "_"; //860:193
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Write(__tmp37_line);
                    __tmp32_outputWritten = true;
                }
                var __tmp38 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp38.Write(op.Name);
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
                string __tmp39_line = "("; //860:203
                if (!string.IsNullOrEmpty(__tmp39_line))
                {
                    __out.Write(__tmp39_line);
                    __tmp32_outputWritten = true;
                }
                var __tmp40 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp40.Write(GetEnumImplCallParameterNames(model, op, ClassKind.ImmutableOperation));
                var __tmp40Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp40.ToStringAndFree());
                bool __tmp40_last = __tmp40Reader.EndOfStream;
                while(!__tmp40_last)
                {
                    ReadOnlySpan<char> __tmp40_line = __tmp40Reader.ReadLine();
                    __tmp40_last = __tmp40Reader.EndOfStream;
                    if (!__tmp40_last || !__tmp40_line.IsEmpty)
                    {
                        __out.Write(__tmp40_line);
                        __tmp32_outputWritten = true;
                    }
                    if (!__tmp40_last) __out.AppendLine(true);
                }
                string __tmp41_line = ");"; //860:276
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Write(__tmp41_line);
                    __tmp32_outputWritten = true;
                }
                if (__tmp32_outputWritten) __out.AppendLine(true);
                if (__tmp32_outputWritten)
                {
                    __out.AppendLine(false); //860:278
                }
                __out.Write("	}"); //861:1
                __out.AppendLine(false); //861:3
            }
            __out.Write("}"); //863:1
            __out.AppendLine(false); //863:2
            return __out.ToStringAndFree();
        }

        public string GetEnumImplParameters(MetaModel model, MetaEnum enm, MetaOperation op, ClassKind kind) //866:1
        {
            string result = "this " + CSharpName(enm, model, kind) + " _this"; //867:2
            string delim = ", "; //868:2
            var __loop57_results = 
                (from __loop57_var1 in __Enumerate((op).GetEnumerator()) //869:7
                from param in __Enumerate((__loop57_var1.Parameters).GetEnumerator()) //869:11
                select new { __loop57_var1 = __loop57_var1, param = param}
                ).ToList(); //869:2
            for (int __loop57_iteration = 0; __loop57_iteration < __loop57_results.Count; ++__loop57_iteration)
            {
                var __tmp1 = __loop57_results[__loop57_iteration];
                var __loop57_var1 = __tmp1.__loop57_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, kind) + " " + param.Name; //870:3
            }
            return result; //872:2
        }

        public string GetEnumImplCallParameterNames(MetaModel model, MetaOperation op, ClassKind kind) //875:1
        {
            string result = "_this"; //876:2
            string delim = ", "; //877:2
            var __loop58_results = 
                (from __loop58_var1 in __Enumerate((op).GetEnumerator()) //878:7
                from param in __Enumerate((__loop58_var1.Parameters).GetEnumerator()) //878:11
                select new { __loop58_var1 = __loop58_var1, param = param}
                ).ToList(); //878:2
            for (int __loop58_iteration = 0; __loop58_iteration < __loop58_results.Count; ++__loop58_iteration)
            {
                var __tmp1 = __loop58_results[__loop58_iteration];
                var __loop58_var1 = __tmp1.__loop58_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //879:3
            }
            return result; //881:2
        }

        public string GetClassParameters(MetaModel model, MetaClass cls, MetaOperation op, ClassKind kind) //884:1
        {
            string result = ""; //885:2
            var __loop59_results = 
                (from __loop59_var1 in __Enumerate((op).GetEnumerator()) //886:7
                from param in __Enumerate((__loop59_var1.Parameters).GetEnumerator()) //886:11
                select new { __loop59_var1 = __loop59_var1, param = param}
                ).ToList(); //886:2
            for (int __loop59_iteration = 0; __loop59_iteration < __loop59_results.Count; ++__loop59_iteration)
            {
                string delim; //886:27
                if (__loop59_iteration+1 < __loop59_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop59_results[__loop59_iteration];
                var __loop59_var1 = __tmp1.__loop59_var1;
                var param = __tmp1.param;
                result += CSharpName(param.Type, model, kind, true) + " " + param.Name + delim; //887:3
            }
            return result; //889:2
        }

        public string GetClassImplCallParameterNames(MetaModel model, MetaOperation op, ClassKind kind) //892:1
        {
            string result = "this"; //893:2
            string delim = ", "; //894:2
            var __loop60_results = 
                (from __loop60_var1 in __Enumerate((op).GetEnumerator()) //895:7
                from param in __Enumerate((__loop60_var1.Parameters).GetEnumerator()) //895:11
                select new { __loop60_var1 = __loop60_var1, param = param}
                ).ToList(); //895:2
            for (int __loop60_iteration = 0; __loop60_iteration < __loop60_results.Count; ++__loop60_iteration)
            {
                var __tmp1 = __loop60_results[__loop60_iteration];
                var __loop60_var1 = __tmp1.__loop60_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //896:3
            }
            return result; //898:2
        }

        public string GetReturn(string returnType) //901:1
        {
            if (returnType == "void") //902:5
            {
                return ""; //903:3
            }
            else //904:2
            {
                return "return "; //905:3
            }
        }

        public string GetDefaultReturn(string returnType) //909:1
        {
            if (returnType == "void") //910:5
            {
                return ""; //911:3
            }
            else //912:2
            {
                return "return default(" + returnType + ");"; //913:3
            }
        }

        public string GenerateClass(MetaModel model, MetaClass cls) //917:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.AppendLine(true); //918:1
            bool __tmp2_outputWritten = false;
            var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp3.Write(GenerateImmutableClass(model, cls));
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
                __out.AppendLine(false); //919:37
            }
            __out.AppendLine(true); //920:1
            bool __tmp5_outputWritten = false;
            var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp6.Write(GenerateBuilderClass(model, cls));
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
                __out.AppendLine(false); //921:35
            }
            return __out.ToStringAndFree();
        }

        public string GenerateClassInternal(MetaModel model, MetaClass cls) //924:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.AppendLine(true); //925:1
            bool __tmp2_outputWritten = false;
            var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp3.Write(GenerateIdClass(model, cls));
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
                __out.AppendLine(false); //926:30
            }
            __out.AppendLine(true); //927:1
            bool __tmp5_outputWritten = false;
            var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp6.Write(GenerateImmutableImplClass(model, cls));
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
                __out.AppendLine(false); //928:41
            }
            __out.AppendLine(true); //929:1
            bool __tmp8_outputWritten = false;
            var __tmp9 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp9.Write(GenerateBuilderImplClass(model, cls));
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
                __out.AppendLine(false); //930:39
            }
            return __out.ToStringAndFree();
        }

        public string GenerateIdClass(MetaModel model, MetaClass cls) //933:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //934:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Write(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp4.Write(CSharpName(cls, model, ClassKind.Id));
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
            string __tmp5_line = " : "; //934:53
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp6.Write(Properties.CoreNs);
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
            string __tmp7_line = ".ObjectId"; //934:75
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //934:84
            }
            __out.Write("{"); //935:1
            __out.AppendLine(false); //935:2
            bool __tmp9_outputWritten = false;
            string __tmp10_line = "	public override "; //936:1
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Write(__tmp10_line);
                __tmp9_outputWritten = true;
            }
            var __tmp11 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp11.Write(Properties.CoreNs);
            var __tmp11Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp11.ToStringAndFree());
            bool __tmp11_last = __tmp11Reader.EndOfStream;
            while(!__tmp11_last)
            {
                ReadOnlySpan<char> __tmp11_line = __tmp11Reader.ReadLine();
                __tmp11_last = __tmp11Reader.EndOfStream;
                if (!__tmp11_last || !__tmp11_line.IsEmpty)
                {
                    __out.Write(__tmp11_line);
                    __tmp9_outputWritten = true;
                }
                if (!__tmp11_last) __out.AppendLine(true);
            }
            string __tmp12_line = ".ModelObjectDescriptor Descriptor { get { return "; //936:37
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Write(__tmp12_line);
                __tmp9_outputWritten = true;
            }
            var __tmp13 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp13.Write(CSharpName(cls, null, ClassKind.Descriptor, true));
            var __tmp13Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp13.ToStringAndFree());
            bool __tmp13_last = __tmp13Reader.EndOfStream;
            while(!__tmp13_last)
            {
                ReadOnlySpan<char> __tmp13_line = __tmp13Reader.ReadLine();
                __tmp13_last = __tmp13Reader.EndOfStream;
                if (!__tmp13_last || !__tmp13_line.IsEmpty)
                {
                    __out.Write(__tmp13_line);
                    __tmp9_outputWritten = true;
                }
                if (!__tmp13_last) __out.AppendLine(true);
            }
            string __tmp14_line = ".MDescriptor; } }"; //936:136
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp9_outputWritten = true;
            }
            if (__tmp9_outputWritten) __out.AppendLine(true);
            if (__tmp9_outputWritten)
            {
                __out.AppendLine(false); //936:153
            }
            __out.AppendLine(true); //937:1
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "	public override "; //938:1
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Write(__tmp17_line);
                __tmp16_outputWritten = true;
            }
            var __tmp18 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp18.Write(Properties.CoreNs);
            var __tmp18Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp18.ToStringAndFree());
            bool __tmp18_last = __tmp18Reader.EndOfStream;
            while(!__tmp18_last)
            {
                ReadOnlySpan<char> __tmp18_line = __tmp18Reader.ReadLine();
                __tmp18_last = __tmp18Reader.EndOfStream;
                if (!__tmp18_last || !__tmp18_line.IsEmpty)
                {
                    __out.Write(__tmp18_line);
                    __tmp16_outputWritten = true;
                }
                if (!__tmp18_last) __out.AppendLine(true);
            }
            string __tmp19_line = ".ImmutableObjectBase CreateImmutable("; //938:37
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Write(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            var __tmp20 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp20.Write(Properties.CoreNs);
            var __tmp20Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp20.ToStringAndFree());
            bool __tmp20_last = __tmp20Reader.EndOfStream;
            while(!__tmp20_last)
            {
                ReadOnlySpan<char> __tmp20_line = __tmp20Reader.ReadLine();
                __tmp20_last = __tmp20Reader.EndOfStream;
                if (!__tmp20_last || !__tmp20_line.IsEmpty)
                {
                    __out.Write(__tmp20_line);
                    __tmp16_outputWritten = true;
                }
                if (!__tmp20_last) __out.AppendLine(true);
            }
            string __tmp21_line = ".ImmutableModel model)"; //938:93
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //938:115
            }
            __out.Write("	{"); //939:1
            __out.AppendLine(false); //939:3
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "		return new "; //940:1
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Write(__tmp24_line);
                __tmp23_outputWritten = true;
            }
            var __tmp25 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp25.Write(CSharpName(cls, model, ClassKind.ImmutableImpl));
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
            string __tmp26_line = "(this, model);"; //940:62
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Write(__tmp26_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //940:76
            }
            __out.Write("	}"); //941:1
            __out.AppendLine(false); //941:3
            __out.AppendLine(true); //942:1
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "	public override "; //943:1
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Write(__tmp29_line);
                __tmp28_outputWritten = true;
            }
            var __tmp30 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp30.Write(Properties.CoreNs);
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
            string __tmp31_line = ".MutableObjectBase CreateMutable("; //943:37
            if (!string.IsNullOrEmpty(__tmp31_line))
            {
                __out.Write(__tmp31_line);
                __tmp28_outputWritten = true;
            }
            var __tmp32 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp32.Write(Properties.CoreNs);
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
            string __tmp33_line = ".MutableModel model, bool creating)"; //943:89
            if (!string.IsNullOrEmpty(__tmp33_line))
            {
                __out.Write(__tmp33_line);
                __tmp28_outputWritten = true;
            }
            if (__tmp28_outputWritten) __out.AppendLine(true);
            if (__tmp28_outputWritten)
            {
                __out.AppendLine(false); //943:124
            }
            __out.Write("	{"); //944:1
            __out.AppendLine(false); //944:3
            bool __tmp35_outputWritten = false;
            string __tmp36_line = "		return new "; //945:1
            if (!string.IsNullOrEmpty(__tmp36_line))
            {
                __out.Write(__tmp36_line);
                __tmp35_outputWritten = true;
            }
            var __tmp37 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp37.Write(CSharpName(cls, model, ClassKind.BuilderImpl));
            var __tmp37Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp37.ToStringAndFree());
            bool __tmp37_last = __tmp37Reader.EndOfStream;
            while(!__tmp37_last)
            {
                ReadOnlySpan<char> __tmp37_line = __tmp37Reader.ReadLine();
                __tmp37_last = __tmp37Reader.EndOfStream;
                if (!__tmp37_last || !__tmp37_line.IsEmpty)
                {
                    __out.Write(__tmp37_line);
                    __tmp35_outputWritten = true;
                }
                if (!__tmp37_last) __out.AppendLine(true);
            }
            string __tmp38_line = "(this, model, creating);"; //945:60
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Write(__tmp38_line);
                __tmp35_outputWritten = true;
            }
            if (__tmp35_outputWritten) __out.AppendLine(true);
            if (__tmp35_outputWritten)
            {
                __out.AppendLine(false); //945:84
            }
            __out.Write("	}"); //946:1
            __out.AppendLine(false); //946:3
            __out.Write("}"); //947:1
            __out.AppendLine(false); //947:2
            return __out.ToStringAndFree();
        }

        public string GenerateImmutableClass(MetaModel model, MetaClass cls) //950:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool metaMetaModel = IsMetaMetaModel(model); //951:2
            bool __tmp2_outputWritten = false;
            var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp3.Write(GenerateDocumentation(cls));
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
                __out.AppendLine(false); //952:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public interface "; //953:1
            if (!string.IsNullOrEmpty(__tmp6_line))
            {
                __out.Write(__tmp6_line);
                __tmp5_outputWritten = true;
            }
            var __tmp7 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp7.Write(CSharpName(cls, model, ClassKind.Immutable));
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
            __tmp8.Write(GetImmutableAncestors(model, cls));
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
                if (!__tmp8_last || __tmp5_outputWritten) __out.AppendLine(true);
            }
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //953:97
            }
            __out.Write("{"); //954:1
            __out.AppendLine(false); //954:2
            var __loop61_results = 
                (from __loop61_var1 in __Enumerate((cls).GetEnumerator()) //955:8
                from prop in __Enumerate((__loop61_var1.Properties).GetEnumerator()) //955:13
                select new { __loop61_var1 = __loop61_var1, prop = prop}
                ).ToList(); //955:3
            for (int __loop61_iteration = 0; __loop61_iteration < __loop61_results.Count; ++__loop61_iteration)
            {
                var __tmp9 = __loop61_results[__loop61_iteration];
                var __loop61_var1 = __tmp9.__loop61_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //956:1
                var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp12.Write(GenerateImmutableProperty(model, prop));
                var __tmp12Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp12.ToStringAndFree());
                bool __tmp12_last = __tmp12Reader.EndOfStream;
                while(!__tmp12_last)
                {
                    ReadOnlySpan<char> __tmp12_line = __tmp12Reader.ReadLine();
                    __tmp12_last = __tmp12Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp10Prefix))
                    {
                        __out.Write(__tmp10Prefix);
                        __tmp11_outputWritten = true;
                    }
                    if (!__tmp12_last || !__tmp12_line.IsEmpty)
                    {
                        __out.Write(__tmp12_line);
                        __tmp11_outputWritten = true;
                    }
                    if (!__tmp12_last || __tmp11_outputWritten) __out.AppendLine(true);
                }
                if (__tmp11_outputWritten)
                {
                    __out.AppendLine(false); //956:42
                }
            }
            __out.AppendLine(true); //958:1
            var __loop62_results = 
                (from __loop62_var1 in __Enumerate((cls).GetEnumerator()) //959:8
                from op in __Enumerate((__loop62_var1.Operations).GetEnumerator()) //959:13
                where !op.IsBuilder //959:27
                select new { __loop62_var1 = __loop62_var1, op = op}
                ).ToList(); //959:3
            for (int __loop62_iteration = 0; __loop62_iteration < __loop62_results.Count; ++__loop62_iteration)
            {
                var __tmp13 = __loop62_results[__loop62_iteration];
                var __loop62_var1 = __tmp13.__loop62_var1;
                var op = __tmp13.op;
                bool __tmp15_outputWritten = false;
                string __tmp14Prefix = "	"; //960:1
                var __tmp16 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp16.Write(GenerateImmutableOperation(model, op));
                var __tmp16Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp16.ToStringAndFree());
                bool __tmp16_last = __tmp16Reader.EndOfStream;
                while(!__tmp16_last)
                {
                    ReadOnlySpan<char> __tmp16_line = __tmp16Reader.ReadLine();
                    __tmp16_last = __tmp16Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp14Prefix))
                    {
                        __out.Write(__tmp14Prefix);
                        __tmp15_outputWritten = true;
                    }
                    if (!__tmp16_last || !__tmp16_line.IsEmpty)
                    {
                        __out.Write(__tmp16_line);
                        __tmp15_outputWritten = true;
                    }
                    if (!__tmp16_last || __tmp15_outputWritten) __out.AppendLine(true);
                }
                if (__tmp15_outputWritten)
                {
                    __out.AppendLine(false); //960:41
                }
            }
            __out.AppendLine(true); //962:1
            __out.Write("	/// <summary>"); //963:1
            __out.AppendLine(false); //963:15
            bool __tmp18_outputWritten = false;
            string __tmp19_line = "	/// Convert the <see cref=\""; //964:1
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Write(__tmp19_line);
                __tmp18_outputWritten = true;
            }
            var __tmp20 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp20.Write(CSharpName(cls, model, ClassKind.Immutable));
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
            string __tmp21_line = "\"/> object to a builder <see cref=\""; //964:73
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp18_outputWritten = true;
            }
            var __tmp22 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp22.Write(CSharpName(cls, model, ClassKind.Builder));
            var __tmp22Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp22.ToStringAndFree());
            bool __tmp22_last = __tmp22Reader.EndOfStream;
            while(!__tmp22_last)
            {
                ReadOnlySpan<char> __tmp22_line = __tmp22Reader.ReadLine();
                __tmp22_last = __tmp22Reader.EndOfStream;
                if (!__tmp22_last || !__tmp22_line.IsEmpty)
                {
                    __out.Write(__tmp22_line);
                    __tmp18_outputWritten = true;
                }
                if (!__tmp22_last) __out.AppendLine(true);
            }
            string __tmp23_line = "\"/> object."; //964:150
            if (!string.IsNullOrEmpty(__tmp23_line))
            {
                __out.Write(__tmp23_line);
                __tmp18_outputWritten = true;
            }
            if (__tmp18_outputWritten) __out.AppendLine(true);
            if (__tmp18_outputWritten)
            {
                __out.AppendLine(false); //964:161
            }
            __out.Write("	/// </summary>"); //965:1
            __out.AppendLine(false); //965:16
            bool __tmp25_outputWritten = false;
            string __tmp26_line = "	new "; //966:1
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Write(__tmp26_line);
                __tmp25_outputWritten = true;
            }
            var __tmp27 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp27.Write(CSharpName(cls, model, ClassKind.Builder, true));
            var __tmp27Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp27.ToStringAndFree());
            bool __tmp27_last = __tmp27Reader.EndOfStream;
            while(!__tmp27_last)
            {
                ReadOnlySpan<char> __tmp27_line = __tmp27Reader.ReadLine();
                __tmp27_last = __tmp27Reader.EndOfStream;
                if (!__tmp27_last || !__tmp27_line.IsEmpty)
                {
                    __out.Write(__tmp27_line);
                    __tmp25_outputWritten = true;
                }
                if (!__tmp27_last) __out.AppendLine(true);
            }
            string __tmp28_line = " ToMutable();"; //966:54
            if (!string.IsNullOrEmpty(__tmp28_line))
            {
                __out.Write(__tmp28_line);
                __tmp25_outputWritten = true;
            }
            if (__tmp25_outputWritten) __out.AppendLine(true);
            if (__tmp25_outputWritten)
            {
                __out.AppendLine(false); //966:67
            }
            __out.Write("	/// <summary>"); //967:1
            __out.AppendLine(false); //967:15
            bool __tmp30_outputWritten = false;
            string __tmp31_line = "	/// Convert the <see cref=\""; //968:1
            if (!string.IsNullOrEmpty(__tmp31_line))
            {
                __out.Write(__tmp31_line);
                __tmp30_outputWritten = true;
            }
            var __tmp32 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp32.Write(CSharpName(cls, model, ClassKind.Immutable));
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
            string __tmp33_line = "\"/> object to a builder <see cref=\""; //968:73
            if (!string.IsNullOrEmpty(__tmp33_line))
            {
                __out.Write(__tmp33_line);
                __tmp30_outputWritten = true;
            }
            var __tmp34 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp34.Write(CSharpName(cls, model, ClassKind.Builder));
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
            string __tmp35_line = "\"/> object"; //968:150
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Write(__tmp35_line);
                __tmp30_outputWritten = true;
            }
            if (__tmp30_outputWritten) __out.AppendLine(true);
            if (__tmp30_outputWritten)
            {
                __out.AppendLine(false); //968:160
            }
            __out.Write("	/// by taking the builder version from the given model."); //969:1
            __out.AppendLine(false); //969:57
            __out.Write("	/// </summary>"); //970:1
            __out.AppendLine(false); //970:16
            __out.Write("	/// <param name=\"model\">The mutable model from which the return value is taken from.</param>"); //971:1
            __out.AppendLine(false); //971:94
            bool __tmp37_outputWritten = false;
            string __tmp38_line = "	new "; //972:1
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Write(__tmp38_line);
                __tmp37_outputWritten = true;
            }
            var __tmp39 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp39.Write(CSharpName(cls, model, ClassKind.Builder, true));
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
            string __tmp40_line = " ToMutable("; //972:54
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Write(__tmp40_line);
                __tmp37_outputWritten = true;
            }
            var __tmp41 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp41.Write(Properties.CoreNs);
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
            string __tmp42_line = ".MutableModel model);"; //972:84
            if (!string.IsNullOrEmpty(__tmp42_line))
            {
                __out.Write(__tmp42_line);
                __tmp37_outputWritten = true;
            }
            if (__tmp37_outputWritten) __out.AppendLine(true);
            if (__tmp37_outputWritten)
            {
                __out.AppendLine(false); //972:105
            }
            __out.Write("}"); //973:1
            __out.AppendLine(false); //973:2
            return __out.ToStringAndFree();
        }

        public string GenerateImmutableProperty(MetaModel model, MetaProperty prop) //976:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp3.Write(GenerateDocumentation(prop));
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
                __out.AppendLine(false); //977:30
            }
            if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name) || (IsMetaMetaModel(model) && prop.Class.Name == "MetaModel")) //978:2
            {
                __out.Write("new "); //979:1
            }
            bool __tmp5_outputWritten = false;
            var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp6.Write(CSharpName(prop.Type, model, ClassKind.Immutable, true));
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
            string __tmp7_line = " "; //981:57
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp5_outputWritten = true;
            }
            var __tmp8 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp8.Write(CSharpName(prop, model, PropertyKind.Immutable));
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
            string __tmp9_line = " { get; }"; //981:106
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Write(__tmp9_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //981:115
            }
            return __out.ToStringAndFree();
        }

        public string GenerateImmutableOperation(MetaModel model, MetaOperation op) //984:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp3.Write(GenerateDocumentation(op));
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
                __out.AppendLine(false); //985:28
            }
            bool __tmp5_outputWritten = false;
            var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp6.Write(CSharpName(op.ReturnType, model, ClassKind.ImmutableOperation, true));
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
            string __tmp7_line = " "; //986:70
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp5_outputWritten = true;
            }
            var __tmp8 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp8.Write(op.Name);
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
            string __tmp9_line = "("; //986:80
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Write(__tmp9_line);
                __tmp5_outputWritten = true;
            }
            var __tmp10 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp10.Write(GetImmutableOperationParameters(model, op, ClassKind.ImmutableOperation));
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
            string __tmp11_line = ");"; //986:155
            if (!string.IsNullOrEmpty(__tmp11_line))
            {
                __out.Write(__tmp11_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //986:157
            }
            return __out.ToStringAndFree();
        }

        public string GetImmutableOperationParameters(MetaModel model, MetaOperation op, ClassKind kind) //989:1
        {
            string result = ""; //990:2
            var __loop63_results = 
                (from __loop63_var1 in __Enumerate((op).GetEnumerator()) //991:7
                from param in __Enumerate((__loop63_var1.Parameters).GetEnumerator()) //991:11
                select new { __loop63_var1 = __loop63_var1, param = param}
                ).ToList(); //991:2
            for (int __loop63_iteration = 0; __loop63_iteration < __loop63_results.Count; ++__loop63_iteration)
            {
                string delim; //991:27
                if (__loop63_iteration+1 < __loop63_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop63_results[__loop63_iteration];
                var __loop63_var1 = __tmp1.__loop63_var1;
                var param = __tmp1.param;
                result += CSharpName(param.Type, model, kind, true) + " " + param.Name + delim; //992:3
            }
            return result; //994:2
        }

        public string GetImmutableAncestors(MetaModel model, MetaClass cls) //997:1
        {
            string result = ""; //998:2
            var __loop64_results = 
                (from __loop64_var1 in __Enumerate((cls).GetEnumerator()) //999:7
                from super in __Enumerate((__loop64_var1.SuperClasses).GetEnumerator()) //999:12
                select new { __loop64_var1 = __loop64_var1, super = super}
                ).ToList(); //999:2
            for (int __loop64_iteration = 0; __loop64_iteration < __loop64_results.Count; ++__loop64_iteration)
            {
                string delim; //999:30
                if (__loop64_iteration+1 < __loop64_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop64_results[__loop64_iteration];
                var __loop64_var1 = __tmp1.__loop64_var1;
                var super = __tmp1.super;
                result += CSharpName(super, model, ClassKind.Immutable, true) + delim; //1000:3
            }
            if (result == "") //1002:2
            {
                result = Properties.CoreNs + ".ImmutableObject"; //1003:3
            }
            result = " : " + result; //1005:2
            return result; //1006:2
        }

        public string GenerateBuilderClass(MetaModel model, MetaClass cls) //1009:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool metaMetaModel = IsMetaMetaModel(model); //1010:2
            bool __tmp2_outputWritten = false;
            var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp3.Write(GenerateDocumentation(cls));
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
                __out.AppendLine(false); //1011:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public interface "; //1012:1
            if (!string.IsNullOrEmpty(__tmp6_line))
            {
                __out.Write(__tmp6_line);
                __tmp5_outputWritten = true;
            }
            var __tmp7 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp7.Write(CSharpName(cls, model, ClassKind.Builder));
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
            __tmp8.Write(GetBuilderAncestors(model, cls));
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
                if (!__tmp8_last || __tmp5_outputWritten) __out.AppendLine(true);
            }
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //1012:93
            }
            __out.Write("{"); //1013:1
            __out.AppendLine(false); //1013:2
            var __loop65_results = 
                (from __loop65_var1 in __Enumerate((cls).GetEnumerator()) //1014:8
                from prop in __Enumerate((__loop65_var1.Properties).GetEnumerator()) //1014:13
                select new { __loop65_var1 = __loop65_var1, prop = prop}
                ).ToList(); //1014:3
            for (int __loop65_iteration = 0; __loop65_iteration < __loop65_results.Count; ++__loop65_iteration)
            {
                var __tmp9 = __loop65_results[__loop65_iteration];
                var __loop65_var1 = __tmp9.__loop65_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //1015:1
                var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp12.Write(GenerateBuilderProperty(model, prop));
                var __tmp12Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp12.ToStringAndFree());
                bool __tmp12_last = __tmp12Reader.EndOfStream;
                while(!__tmp12_last)
                {
                    ReadOnlySpan<char> __tmp12_line = __tmp12Reader.ReadLine();
                    __tmp12_last = __tmp12Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp10Prefix))
                    {
                        __out.Write(__tmp10Prefix);
                        __tmp11_outputWritten = true;
                    }
                    if (!__tmp12_last || !__tmp12_line.IsEmpty)
                    {
                        __out.Write(__tmp12_line);
                        __tmp11_outputWritten = true;
                    }
                    if (!__tmp12_last || __tmp11_outputWritten) __out.AppendLine(true);
                }
                if (__tmp11_outputWritten)
                {
                    __out.AppendLine(false); //1015:40
                }
            }
            __out.AppendLine(true); //1017:1
            var __loop66_results = 
                (from __loop66_var1 in __Enumerate((cls).GetEnumerator()) //1018:8
                from op in __Enumerate((__loop66_var1.Operations).GetEnumerator()) //1018:13
                select new { __loop66_var1 = __loop66_var1, op = op}
                ).ToList(); //1018:3
            for (int __loop66_iteration = 0; __loop66_iteration < __loop66_results.Count; ++__loop66_iteration)
            {
                var __tmp13 = __loop66_results[__loop66_iteration];
                var __loop66_var1 = __tmp13.__loop66_var1;
                var op = __tmp13.op;
                bool __tmp15_outputWritten = false;
                string __tmp14Prefix = "	"; //1019:1
                var __tmp16 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp16.Write(GenerateBuilderOperation(model, op));
                var __tmp16Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp16.ToStringAndFree());
                bool __tmp16_last = __tmp16Reader.EndOfStream;
                while(!__tmp16_last)
                {
                    ReadOnlySpan<char> __tmp16_line = __tmp16Reader.ReadLine();
                    __tmp16_last = __tmp16Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp14Prefix))
                    {
                        __out.Write(__tmp14Prefix);
                        __tmp15_outputWritten = true;
                    }
                    if (!__tmp16_last || !__tmp16_line.IsEmpty)
                    {
                        __out.Write(__tmp16_line);
                        __tmp15_outputWritten = true;
                    }
                    if (!__tmp16_last || __tmp15_outputWritten) __out.AppendLine(true);
                }
                if (__tmp15_outputWritten)
                {
                    __out.AppendLine(false); //1019:39
                }
            }
            __out.AppendLine(true); //1021:1
            __out.Write("	/// <summary>"); //1022:1
            __out.AppendLine(false); //1022:15
            bool __tmp18_outputWritten = false;
            string __tmp19_line = "	/// Convert the <see cref=\""; //1023:1
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Write(__tmp19_line);
                __tmp18_outputWritten = true;
            }
            var __tmp20 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp20.Write(CSharpName(cls, model, ClassKind.Builder));
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
            string __tmp21_line = "\"/> object to an immutable <see cref=\""; //1023:71
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp18_outputWritten = true;
            }
            var __tmp22 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp22.Write(CSharpName(cls, model, ClassKind.Immutable));
            var __tmp22Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp22.ToStringAndFree());
            bool __tmp22_last = __tmp22Reader.EndOfStream;
            while(!__tmp22_last)
            {
                ReadOnlySpan<char> __tmp22_line = __tmp22Reader.ReadLine();
                __tmp22_last = __tmp22Reader.EndOfStream;
                if (!__tmp22_last || !__tmp22_line.IsEmpty)
                {
                    __out.Write(__tmp22_line);
                    __tmp18_outputWritten = true;
                }
                if (!__tmp22_last) __out.AppendLine(true);
            }
            string __tmp23_line = "\"/> object."; //1023:153
            if (!string.IsNullOrEmpty(__tmp23_line))
            {
                __out.Write(__tmp23_line);
                __tmp18_outputWritten = true;
            }
            if (__tmp18_outputWritten) __out.AppendLine(true);
            if (__tmp18_outputWritten)
            {
                __out.AppendLine(false); //1023:164
            }
            __out.Write("	/// </summary>"); //1024:1
            __out.AppendLine(false); //1024:16
            bool __tmp25_outputWritten = false;
            string __tmp26_line = "	new "; //1025:1
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Write(__tmp26_line);
                __tmp25_outputWritten = true;
            }
            var __tmp27 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp27.Write(CSharpName(cls, model, ClassKind.Immutable, true));
            var __tmp27Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp27.ToStringAndFree());
            bool __tmp27_last = __tmp27Reader.EndOfStream;
            while(!__tmp27_last)
            {
                ReadOnlySpan<char> __tmp27_line = __tmp27Reader.ReadLine();
                __tmp27_last = __tmp27Reader.EndOfStream;
                if (!__tmp27_last || !__tmp27_line.IsEmpty)
                {
                    __out.Write(__tmp27_line);
                    __tmp25_outputWritten = true;
                }
                if (!__tmp27_last) __out.AppendLine(true);
            }
            string __tmp28_line = " ToImmutable();"; //1025:56
            if (!string.IsNullOrEmpty(__tmp28_line))
            {
                __out.Write(__tmp28_line);
                __tmp25_outputWritten = true;
            }
            if (__tmp25_outputWritten) __out.AppendLine(true);
            if (__tmp25_outputWritten)
            {
                __out.AppendLine(false); //1025:71
            }
            __out.Write("	/// <summary>"); //1026:1
            __out.AppendLine(false); //1026:15
            bool __tmp30_outputWritten = false;
            string __tmp31_line = "	/// Convert the <see cref=\""; //1027:1
            if (!string.IsNullOrEmpty(__tmp31_line))
            {
                __out.Write(__tmp31_line);
                __tmp30_outputWritten = true;
            }
            var __tmp32 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp32.Write(CSharpName(cls, model, ClassKind.Builder));
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
            string __tmp33_line = "\"/> object to an immutable <see cref=\""; //1027:71
            if (!string.IsNullOrEmpty(__tmp33_line))
            {
                __out.Write(__tmp33_line);
                __tmp30_outputWritten = true;
            }
            var __tmp34 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp34.Write(CSharpName(cls, model, ClassKind.Immutable));
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
            string __tmp35_line = "\"/> object"; //1027:153
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Write(__tmp35_line);
                __tmp30_outputWritten = true;
            }
            if (__tmp30_outputWritten) __out.AppendLine(true);
            if (__tmp30_outputWritten)
            {
                __out.AppendLine(false); //1027:163
            }
            __out.Write("	/// by taking the immutable version from the given model."); //1028:1
            __out.AppendLine(false); //1028:59
            __out.Write("	/// </summary>"); //1029:1
            __out.AppendLine(false); //1029:16
            __out.Write("	/// <param name=\"model\">The immutable model from which the return value is taken from.</param>"); //1030:1
            __out.AppendLine(false); //1030:96
            bool __tmp37_outputWritten = false;
            string __tmp38_line = "	new "; //1031:1
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Write(__tmp38_line);
                __tmp37_outputWritten = true;
            }
            var __tmp39 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp39.Write(CSharpName(cls, model, ClassKind.Immutable, true));
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
            string __tmp40_line = " ToImmutable("; //1031:56
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Write(__tmp40_line);
                __tmp37_outputWritten = true;
            }
            var __tmp41 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp41.Write(Properties.CoreNs);
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
            string __tmp42_line = ".ImmutableModel model);"; //1031:88
            if (!string.IsNullOrEmpty(__tmp42_line))
            {
                __out.Write(__tmp42_line);
                __tmp37_outputWritten = true;
            }
            if (__tmp37_outputWritten) __out.AppendLine(true);
            if (__tmp37_outputWritten)
            {
                __out.AppendLine(false); //1031:111
            }
            __out.Write("}"); //1032:1
            __out.AppendLine(false); //1032:2
            return __out.ToStringAndFree();
        }

        public string GenerateBuilderProperty(MetaModel model, MetaProperty prop) //1035:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp3.Write(GenerateDocumentation(prop));
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
                __out.AppendLine(false); //1036:30
            }
            if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name) || (IsMetaMetaModel(model) && prop.Class.Name == "MetaModel")) //1037:3
            {
                __out.Write("new "); //1038:1
            }
            if ((prop.Kind == MetaPropertyKind.Normal) && !(prop.Type is MetaCollectionType)) //1040:3
            {
                bool __tmp5_outputWritten = false;
                var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp6.Write(CSharpName(prop.Type, model, ClassKind.Builder, true));
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
                string __tmp7_line = " "; //1041:55
                if (!string.IsNullOrEmpty(__tmp7_line))
                {
                    __out.Write(__tmp7_line);
                    __tmp5_outputWritten = true;
                }
                var __tmp8 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp8.Write(CSharpName(prop, model, PropertyKind.Builder));
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
                string __tmp9_line = " { get; set; }"; //1041:102
                if (!string.IsNullOrEmpty(__tmp9_line))
                {
                    __out.Write(__tmp9_line);
                    __tmp5_outputWritten = true;
                }
                if (__tmp5_outputWritten) __out.AppendLine(true);
                if (__tmp5_outputWritten)
                {
                    __out.AppendLine(false); //1041:116
                }
            }
            else //1042:3
            {
                bool __tmp11_outputWritten = false;
                var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp12.Write(CSharpName(prop.Type, model, ClassKind.Builder, true));
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
                    if (!__tmp12_last) __out.AppendLine(true);
                }
                string __tmp13_line = " "; //1043:55
                if (!string.IsNullOrEmpty(__tmp13_line))
                {
                    __out.Write(__tmp13_line);
                    __tmp11_outputWritten = true;
                }
                var __tmp14 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp14.Write(CSharpName(prop, model, PropertyKind.Builder));
                var __tmp14Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp14.ToStringAndFree());
                bool __tmp14_last = __tmp14Reader.EndOfStream;
                while(!__tmp14_last)
                {
                    ReadOnlySpan<char> __tmp14_line = __tmp14Reader.ReadLine();
                    __tmp14_last = __tmp14Reader.EndOfStream;
                    if (!__tmp14_last || !__tmp14_line.IsEmpty)
                    {
                        __out.Write(__tmp14_line);
                        __tmp11_outputWritten = true;
                    }
                    if (!__tmp14_last) __out.AppendLine(true);
                }
                string __tmp15_line = " { get; }"; //1043:102
                if (!string.IsNullOrEmpty(__tmp15_line))
                {
                    __out.Write(__tmp15_line);
                    __tmp11_outputWritten = true;
                }
                if (__tmp11_outputWritten) __out.AppendLine(true);
                if (__tmp11_outputWritten)
                {
                    __out.AppendLine(false); //1043:111
                }
            }
            if (!(prop.Type is MetaCollectionType)) //1045:3
            {
                bool __tmp17_outputWritten = false;
                var __tmp18 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp18.Write(GenerateDocumentation(prop));
                var __tmp18Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp18.ToStringAndFree());
                bool __tmp18_last = __tmp18Reader.EndOfStream;
                while(!__tmp18_last)
                {
                    ReadOnlySpan<char> __tmp18_line = __tmp18Reader.ReadLine();
                    __tmp18_last = __tmp18Reader.EndOfStream;
                    if (!__tmp18_last || !__tmp18_line.IsEmpty)
                    {
                        __out.Write(__tmp18_line);
                        __tmp17_outputWritten = true;
                    }
                    if (!__tmp18_last || __tmp17_outputWritten) __out.AppendLine(true);
                }
                if (__tmp17_outputWritten)
                {
                    __out.AppendLine(false); //1046:30
                }
                if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name)) //1047:4
                {
                    __out.Write("new "); //1048:1
                }
                bool __tmp20_outputWritten = false;
                string __tmp21_line = "void Set"; //1050:1
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Write(__tmp21_line);
                    __tmp20_outputWritten = true;
                }
                var __tmp22 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp22.Write(CSharpName(prop, model, PropertyKind.Builder));
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
                string __tmp23_line = "Lazy(global::System.Func<"; //1050:55
                if (!string.IsNullOrEmpty(__tmp23_line))
                {
                    __out.Write(__tmp23_line);
                    __tmp20_outputWritten = true;
                }
                var __tmp24 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp24.Write(CSharpName(prop.Type, model, ClassKind.Builder, true));
                var __tmp24Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp24.ToStringAndFree());
                bool __tmp24_last = __tmp24Reader.EndOfStream;
                while(!__tmp24_last)
                {
                    ReadOnlySpan<char> __tmp24_line = __tmp24Reader.ReadLine();
                    __tmp24_last = __tmp24Reader.EndOfStream;
                    if (!__tmp24_last || !__tmp24_line.IsEmpty)
                    {
                        __out.Write(__tmp24_line);
                        __tmp20_outputWritten = true;
                    }
                    if (!__tmp24_last) __out.AppendLine(true);
                }
                string __tmp25_line = "> lazy);"; //1050:134
                if (!string.IsNullOrEmpty(__tmp25_line))
                {
                    __out.Write(__tmp25_line);
                    __tmp20_outputWritten = true;
                }
                if (__tmp20_outputWritten) __out.AppendLine(true);
                if (__tmp20_outputWritten)
                {
                    __out.AppendLine(false); //1050:142
                }
                bool __tmp27_outputWritten = false;
                var __tmp28 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp28.Write(GenerateDocumentation(prop));
                var __tmp28Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp28.ToStringAndFree());
                bool __tmp28_last = __tmp28Reader.EndOfStream;
                while(!__tmp28_last)
                {
                    ReadOnlySpan<char> __tmp28_line = __tmp28Reader.ReadLine();
                    __tmp28_last = __tmp28Reader.EndOfStream;
                    if (!__tmp28_last || !__tmp28_line.IsEmpty)
                    {
                        __out.Write(__tmp28_line);
                        __tmp27_outputWritten = true;
                    }
                    if (!__tmp28_last || __tmp27_outputWritten) __out.AppendLine(true);
                }
                if (__tmp27_outputWritten)
                {
                    __out.AppendLine(false); //1051:30
                }
                if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name)) //1052:4
                {
                    __out.Write("new "); //1053:1
                }
                bool __tmp30_outputWritten = false;
                string __tmp31_line = "void Set"; //1055:1
                if (!string.IsNullOrEmpty(__tmp31_line))
                {
                    __out.Write(__tmp31_line);
                    __tmp30_outputWritten = true;
                }
                var __tmp32 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp32.Write(CSharpName(prop, model, PropertyKind.Builder));
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
                string __tmp33_line = "Lazy(global::System.Func<"; //1055:55
                if (!string.IsNullOrEmpty(__tmp33_line))
                {
                    __out.Write(__tmp33_line);
                    __tmp30_outputWritten = true;
                }
                var __tmp34 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp34.Write(CSharpName(prop.Class, model, ClassKind.Builder));
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
                string __tmp35_line = ", "; //1055:129
                if (!string.IsNullOrEmpty(__tmp35_line))
                {
                    __out.Write(__tmp35_line);
                    __tmp30_outputWritten = true;
                }
                var __tmp36 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp36.Write(CSharpName(prop.Type, model, ClassKind.Builder, true));
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
                string __tmp37_line = "> lazy);"; //1055:185
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Write(__tmp37_line);
                    __tmp30_outputWritten = true;
                }
                if (__tmp30_outputWritten) __out.AppendLine(true);
                if (__tmp30_outputWritten)
                {
                    __out.AppendLine(false); //1055:193
                }
                bool __tmp39_outputWritten = false;
                var __tmp40 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp40.Write(GenerateDocumentation(prop));
                var __tmp40Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp40.ToStringAndFree());
                bool __tmp40_last = __tmp40Reader.EndOfStream;
                while(!__tmp40_last)
                {
                    ReadOnlySpan<char> __tmp40_line = __tmp40Reader.ReadLine();
                    __tmp40_last = __tmp40Reader.EndOfStream;
                    if (!__tmp40_last || !__tmp40_line.IsEmpty)
                    {
                        __out.Write(__tmp40_line);
                        __tmp39_outputWritten = true;
                    }
                    if (!__tmp40_last || __tmp39_outputWritten) __out.AppendLine(true);
                }
                if (__tmp39_outputWritten)
                {
                    __out.AppendLine(false); //1056:30
                }
                if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name)) //1057:4
                {
                    __out.Write("new "); //1058:1
                }
                bool __tmp42_outputWritten = false;
                string __tmp43_line = "void Set"; //1060:1
                if (!string.IsNullOrEmpty(__tmp43_line))
                {
                    __out.Write(__tmp43_line);
                    __tmp42_outputWritten = true;
                }
                var __tmp44 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp44.Write(CSharpName(prop, model, PropertyKind.Builder));
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
                string __tmp45_line = "Lazy(global::System.Func<"; //1060:55
                if (!string.IsNullOrEmpty(__tmp45_line))
                {
                    __out.Write(__tmp45_line);
                    __tmp42_outputWritten = true;
                }
                var __tmp46 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp46.Write(CSharpName(prop.Class, model, ClassKind.Immutable));
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
                string __tmp47_line = ", "; //1060:131
                if (!string.IsNullOrEmpty(__tmp47_line))
                {
                    __out.Write(__tmp47_line);
                    __tmp42_outputWritten = true;
                }
                var __tmp48 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp48.Write(CSharpName(prop.Type, model, ClassKind.Immutable, true));
                var __tmp48Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp48.ToStringAndFree());
                bool __tmp48_last = __tmp48Reader.EndOfStream;
                while(!__tmp48_last)
                {
                    ReadOnlySpan<char> __tmp48_line = __tmp48Reader.ReadLine();
                    __tmp48_last = __tmp48Reader.EndOfStream;
                    if (!__tmp48_last || !__tmp48_line.IsEmpty)
                    {
                        __out.Write(__tmp48_line);
                        __tmp42_outputWritten = true;
                    }
                    if (!__tmp48_last) __out.AppendLine(true);
                }
                string __tmp49_line = "> immutableLazy, global::System.Func<"; //1060:189
                if (!string.IsNullOrEmpty(__tmp49_line))
                {
                    __out.Write(__tmp49_line);
                    __tmp42_outputWritten = true;
                }
                var __tmp50 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp50.Write(CSharpName(prop.Class, model, ClassKind.Builder));
                var __tmp50Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp50.ToStringAndFree());
                bool __tmp50_last = __tmp50Reader.EndOfStream;
                while(!__tmp50_last)
                {
                    ReadOnlySpan<char> __tmp50_line = __tmp50Reader.ReadLine();
                    __tmp50_last = __tmp50Reader.EndOfStream;
                    if (!__tmp50_last || !__tmp50_line.IsEmpty)
                    {
                        __out.Write(__tmp50_line);
                        __tmp42_outputWritten = true;
                    }
                    if (!__tmp50_last) __out.AppendLine(true);
                }
                string __tmp51_line = ", "; //1060:275
                if (!string.IsNullOrEmpty(__tmp51_line))
                {
                    __out.Write(__tmp51_line);
                    __tmp42_outputWritten = true;
                }
                var __tmp52 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp52.Write(CSharpName(prop.Type, model, ClassKind.Builder, true));
                var __tmp52Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp52.ToStringAndFree());
                bool __tmp52_last = __tmp52Reader.EndOfStream;
                while(!__tmp52_last)
                {
                    ReadOnlySpan<char> __tmp52_line = __tmp52Reader.ReadLine();
                    __tmp52_last = __tmp52Reader.EndOfStream;
                    if (!__tmp52_last || !__tmp52_line.IsEmpty)
                    {
                        __out.Write(__tmp52_line);
                        __tmp42_outputWritten = true;
                    }
                    if (!__tmp52_last) __out.AppendLine(true);
                }
                string __tmp53_line = "> mutableLazy);"; //1060:331
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Write(__tmp53_line);
                    __tmp42_outputWritten = true;
                }
                if (__tmp42_outputWritten) __out.AppendLine(true);
                if (__tmp42_outputWritten)
                {
                    __out.AppendLine(false); //1060:346
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateBuilderOperation(MetaModel model, MetaOperation op) //1064:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp3.Write(GenerateDocumentation(op));
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
                __out.AppendLine(false); //1065:28
            }
            bool __tmp5_outputWritten = false;
            var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp6.Write(CSharpName(op.ReturnType, model, ClassKind.BuilderOperation, true));
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
            string __tmp7_line = " "; //1066:68
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp5_outputWritten = true;
            }
            var __tmp8 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp8.Write(op.Name);
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
            string __tmp9_line = "("; //1066:78
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Write(__tmp9_line);
                __tmp5_outputWritten = true;
            }
            var __tmp10 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp10.Write(GetBuilderOperationParameters(model, op, ClassKind.BuilderOperation));
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
            string __tmp11_line = ");"; //1066:149
            if (!string.IsNullOrEmpty(__tmp11_line))
            {
                __out.Write(__tmp11_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //1066:151
            }
            return __out.ToStringAndFree();
        }

        public string GetBuilderOperationParameters(MetaModel model, MetaOperation op, ClassKind kind) //1069:1
        {
            string result = ""; //1070:2
            var __loop67_results = 
                (from __loop67_var1 in __Enumerate((op).GetEnumerator()) //1071:7
                from param in __Enumerate((__loop67_var1.Parameters).GetEnumerator()) //1071:11
                select new { __loop67_var1 = __loop67_var1, param = param}
                ).ToList(); //1071:2
            for (int __loop67_iteration = 0; __loop67_iteration < __loop67_results.Count; ++__loop67_iteration)
            {
                string delim; //1071:27
                if (__loop67_iteration+1 < __loop67_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop67_results[__loop67_iteration];
                var __loop67_var1 = __tmp1.__loop67_var1;
                var param = __tmp1.param;
                result += CSharpName(param.Type, model, kind, true) + " " + param.Name + delim; //1072:3
            }
            return result; //1074:2
        }

        public string GetBuilderAncestors(MetaModel model, MetaClass cls) //1077:1
        {
            string result = ""; //1078:2
            var __loop68_results = 
                (from __loop68_var1 in __Enumerate((cls).GetEnumerator()) //1079:7
                from super in __Enumerate((__loop68_var1.SuperClasses).GetEnumerator()) //1079:12
                select new { __loop68_var1 = __loop68_var1, super = super}
                ).ToList(); //1079:2
            for (int __loop68_iteration = 0; __loop68_iteration < __loop68_results.Count; ++__loop68_iteration)
            {
                string delim; //1079:30
                if (__loop68_iteration+1 < __loop68_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop68_results[__loop68_iteration];
                var __loop68_var1 = __tmp1.__loop68_var1;
                var super = __tmp1.super;
                result += CSharpName(super, model, ClassKind.Builder, true) + delim; //1080:3
            }
            if (result == "") //1082:2
            {
                result = Properties.CoreNs + ".MutableObject"; //1083:3
            }
            result = " : " + result; //1085:2
            return result; //1086:2
        }

        public string GenerateImmutableImplClass(MetaModel model, MetaClass cls) //1089:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool metaMetaModel = IsMetaMetaModel(model); //1090:2
            string metaNs = metaMetaModel ? "" : Properties.MetaNs + "."; //1091:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //1092:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Write(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp4.Write(CSharpName(cls, model, ClassKind.ImmutableImpl));
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
            string __tmp5_line = " : "; //1092:64
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp6.Write(Properties.CoreNs);
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
            string __tmp7_line = ".ImmutableObjectBase, "; //1092:86
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            var __tmp8 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp8.Write(CSharpName(cls, model, ClassKind.Immutable));
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
                if (!__tmp8_last || __tmp2_outputWritten) __out.AppendLine(true);
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //1092:152
            }
            __out.Write("{"); //1093:1
            __out.AppendLine(false); //1093:2
            var __loop69_results = 
                (from __loop69_var1 in __Enumerate((cls).GetEnumerator()) //1094:8
                from prop in __Enumerate((__loop69_var1.GetAllProperties()).GetEnumerator()) //1094:13
                select new { __loop69_var1 = __loop69_var1, prop = prop}
                ).ToList(); //1094:3
            for (int __loop69_iteration = 0; __loop69_iteration < __loop69_results.Count; ++__loop69_iteration)
            {
                var __tmp9 = __loop69_results[__loop69_iteration];
                var __loop69_var1 = __tmp9.__loop69_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //1095:1
                var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp12.Write(GenerateImmutableField(model, cls, prop));
                var __tmp12Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp12.ToStringAndFree());
                bool __tmp12_last = __tmp12Reader.EndOfStream;
                while(!__tmp12_last)
                {
                    ReadOnlySpan<char> __tmp12_line = __tmp12Reader.ReadLine();
                    __tmp12_last = __tmp12Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp10Prefix))
                    {
                        __out.Write(__tmp10Prefix);
                        __tmp11_outputWritten = true;
                    }
                    if (!__tmp12_last || !__tmp12_line.IsEmpty)
                    {
                        __out.Write(__tmp12_line);
                        __tmp11_outputWritten = true;
                    }
                    if (!__tmp12_last || __tmp11_outputWritten) __out.AppendLine(true);
                }
                if (__tmp11_outputWritten)
                {
                    __out.AppendLine(false); //1095:44
                }
            }
            __out.AppendLine(true); //1097:2
            bool __tmp14_outputWritten = false;
            string __tmp15_line = "	internal "; //1098:1
            if (!string.IsNullOrEmpty(__tmp15_line))
            {
                __out.Write(__tmp15_line);
                __tmp14_outputWritten = true;
            }
            var __tmp16 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp16.Write(CSharpName(cls, model, ClassKind.ImmutableImpl));
            var __tmp16Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp16.ToStringAndFree());
            bool __tmp16_last = __tmp16Reader.EndOfStream;
            while(!__tmp16_last)
            {
                ReadOnlySpan<char> __tmp16_line = __tmp16Reader.ReadLine();
                __tmp16_last = __tmp16Reader.EndOfStream;
                if (!__tmp16_last || !__tmp16_line.IsEmpty)
                {
                    __out.Write(__tmp16_line);
                    __tmp14_outputWritten = true;
                }
                if (!__tmp16_last) __out.AppendLine(true);
            }
            string __tmp17_line = "("; //1098:59
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Write(__tmp17_line);
                __tmp14_outputWritten = true;
            }
            var __tmp18 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp18.Write(Properties.CoreNs);
            var __tmp18Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp18.ToStringAndFree());
            bool __tmp18_last = __tmp18Reader.EndOfStream;
            while(!__tmp18_last)
            {
                ReadOnlySpan<char> __tmp18_line = __tmp18Reader.ReadLine();
                __tmp18_last = __tmp18Reader.EndOfStream;
                if (!__tmp18_last || !__tmp18_line.IsEmpty)
                {
                    __out.Write(__tmp18_line);
                    __tmp14_outputWritten = true;
                }
                if (!__tmp18_last) __out.AppendLine(true);
            }
            string __tmp19_line = ".ObjectId id, "; //1098:79
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Write(__tmp19_line);
                __tmp14_outputWritten = true;
            }
            var __tmp20 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp20.Write(Properties.CoreNs);
            var __tmp20Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp20.ToStringAndFree());
            bool __tmp20_last = __tmp20Reader.EndOfStream;
            while(!__tmp20_last)
            {
                ReadOnlySpan<char> __tmp20_line = __tmp20Reader.ReadLine();
                __tmp20_last = __tmp20Reader.EndOfStream;
                if (!__tmp20_last || !__tmp20_line.IsEmpty)
                {
                    __out.Write(__tmp20_line);
                    __tmp14_outputWritten = true;
                }
                if (!__tmp20_last) __out.AppendLine(true);
            }
            string __tmp21_line = ".ImmutableModel model)"; //1098:112
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp14_outputWritten = true;
            }
            if (__tmp14_outputWritten) __out.AppendLine(true);
            if (__tmp14_outputWritten)
            {
                __out.AppendLine(false); //1098:134
            }
            __out.Write("		: base(id, model)"); //1099:1
            __out.AppendLine(false); //1099:20
            __out.Write("	{"); //1100:1
            __out.AppendLine(false); //1100:3
            __out.Write("	}"); //1101:1
            __out.AppendLine(false); //1101:3
            __out.AppendLine(true); //1102:2
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "	public override "; //1103:1
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Write(__tmp24_line);
                __tmp23_outputWritten = true;
            }
            var __tmp25 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp25.Write(Properties.CoreNs);
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
            string __tmp26_line = ".ModelMetadata MMetadata => "; //1103:37
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Write(__tmp26_line);
                __tmp23_outputWritten = true;
            }
            var __tmp27 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp27.Write(CSharpName(model, ModelKind.ImmutableInstance, true));
            var __tmp27Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp27.ToStringAndFree());
            bool __tmp27_last = __tmp27Reader.EndOfStream;
            while(!__tmp27_last)
            {
                ReadOnlySpan<char> __tmp27_line = __tmp27Reader.ReadLine();
                __tmp27_last = __tmp27Reader.EndOfStream;
                if (!__tmp27_last || !__tmp27_line.IsEmpty)
                {
                    __out.Write(__tmp27_line);
                    __tmp23_outputWritten = true;
                }
                if (!__tmp27_last) __out.AppendLine(true);
            }
            string __tmp28_line = ".MMetadata;"; //1103:118
            if (!string.IsNullOrEmpty(__tmp28_line))
            {
                __out.Write(__tmp28_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //1103:129
            }
            __out.AppendLine(true); //1104:2
            bool __tmp30_outputWritten = false;
            string __tmp31_line = "	public override "; //1105:1
            if (!string.IsNullOrEmpty(__tmp31_line))
            {
                __out.Write(__tmp31_line);
                __tmp30_outputWritten = true;
            }
            var __tmp32 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp32.Write(metaNs);
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
            string __tmp33_line = "MetaClass MMetaClass => "; //1105:26
            if (!string.IsNullOrEmpty(__tmp33_line))
            {
                __out.Write(__tmp33_line);
                __tmp30_outputWritten = true;
            }
            var __tmp34 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp34.Write(CSharpName(cls, model, ClassKind.ImmutableInstance, true));
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
            string __tmp35_line = ";"; //1105:108
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Write(__tmp35_line);
                __tmp30_outputWritten = true;
            }
            if (__tmp30_outputWritten) __out.AppendLine(true);
            if (__tmp30_outputWritten)
            {
                __out.AppendLine(false); //1105:109
            }
            __out.AppendLine(true); //1106:2
            bool __tmp37_outputWritten = false;
            string __tmp38_line = "	public new "; //1107:1
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Write(__tmp38_line);
                __tmp37_outputWritten = true;
            }
            var __tmp39 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp39.Write(CSharpName(cls, model, ClassKind.Builder));
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
            string __tmp40_line = " ToMutable()"; //1107:55
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Write(__tmp40_line);
                __tmp37_outputWritten = true;
            }
            if (__tmp37_outputWritten) __out.AppendLine(true);
            if (__tmp37_outputWritten)
            {
                __out.AppendLine(false); //1107:67
            }
            __out.Write("	{"); //1108:1
            __out.AppendLine(false); //1108:3
            bool __tmp42_outputWritten = false;
            string __tmp43_line = "		return ("; //1109:1
            if (!string.IsNullOrEmpty(__tmp43_line))
            {
                __out.Write(__tmp43_line);
                __tmp42_outputWritten = true;
            }
            var __tmp44 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp44.Write(CSharpName(cls, model, ClassKind.Builder));
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
            string __tmp45_line = ")base.ToMutable();"; //1109:53
            if (!string.IsNullOrEmpty(__tmp45_line))
            {
                __out.Write(__tmp45_line);
                __tmp42_outputWritten = true;
            }
            if (__tmp42_outputWritten) __out.AppendLine(true);
            if (__tmp42_outputWritten)
            {
                __out.AppendLine(false); //1109:71
            }
            __out.Write("	}"); //1110:1
            __out.AppendLine(false); //1110:3
            __out.AppendLine(true); //1111:2
            bool __tmp47_outputWritten = false;
            string __tmp48_line = "	public new "; //1112:1
            if (!string.IsNullOrEmpty(__tmp48_line))
            {
                __out.Write(__tmp48_line);
                __tmp47_outputWritten = true;
            }
            var __tmp49 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp49.Write(CSharpName(cls, model, ClassKind.Builder));
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
            string __tmp50_line = " ToMutable("; //1112:55
            if (!string.IsNullOrEmpty(__tmp50_line))
            {
                __out.Write(__tmp50_line);
                __tmp47_outputWritten = true;
            }
            var __tmp51 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp51.Write(Properties.CoreNs);
            var __tmp51Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp51.ToStringAndFree());
            bool __tmp51_last = __tmp51Reader.EndOfStream;
            while(!__tmp51_last)
            {
                ReadOnlySpan<char> __tmp51_line = __tmp51Reader.ReadLine();
                __tmp51_last = __tmp51Reader.EndOfStream;
                if (!__tmp51_last || !__tmp51_line.IsEmpty)
                {
                    __out.Write(__tmp51_line);
                    __tmp47_outputWritten = true;
                }
                if (!__tmp51_last) __out.AppendLine(true);
            }
            string __tmp52_line = ".MutableModel model)"; //1112:85
            if (!string.IsNullOrEmpty(__tmp52_line))
            {
                __out.Write(__tmp52_line);
                __tmp47_outputWritten = true;
            }
            if (__tmp47_outputWritten) __out.AppendLine(true);
            if (__tmp47_outputWritten)
            {
                __out.AppendLine(false); //1112:105
            }
            __out.Write("	{"); //1113:1
            __out.AppendLine(false); //1113:3
            bool __tmp54_outputWritten = false;
            string __tmp55_line = "		return ("; //1114:1
            if (!string.IsNullOrEmpty(__tmp55_line))
            {
                __out.Write(__tmp55_line);
                __tmp54_outputWritten = true;
            }
            var __tmp56 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp56.Write(CSharpName(cls, model, ClassKind.Builder));
            var __tmp56Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp56.ToStringAndFree());
            bool __tmp56_last = __tmp56Reader.EndOfStream;
            while(!__tmp56_last)
            {
                ReadOnlySpan<char> __tmp56_line = __tmp56Reader.ReadLine();
                __tmp56_last = __tmp56Reader.EndOfStream;
                if (!__tmp56_last || !__tmp56_line.IsEmpty)
                {
                    __out.Write(__tmp56_line);
                    __tmp54_outputWritten = true;
                }
                if (!__tmp56_last) __out.AppendLine(true);
            }
            string __tmp57_line = ")base.ToMutable(model);"; //1114:53
            if (!string.IsNullOrEmpty(__tmp57_line))
            {
                __out.Write(__tmp57_line);
                __tmp54_outputWritten = true;
            }
            if (__tmp54_outputWritten) __out.AppendLine(true);
            if (__tmp54_outputWritten)
            {
                __out.AppendLine(false); //1114:76
            }
            __out.Write("	}"); //1115:1
            __out.AppendLine(false); //1115:3
            var __loop70_results = 
                (from __loop70_var1 in __Enumerate((cls).GetEnumerator()) //1116:8
                from sup in __Enumerate((__loop70_var1.GetAllSuperClasses(false)).GetEnumerator()) //1116:13
                select new { __loop70_var1 = __loop70_var1, sup = sup}
                ).ToList(); //1116:3
            for (int __loop70_iteration = 0; __loop70_iteration < __loop70_results.Count; ++__loop70_iteration)
            {
                var __tmp58 = __loop70_results[__loop70_iteration];
                var __loop70_var1 = __tmp58.__loop70_var1;
                var sup = __tmp58.sup;
                __out.AppendLine(true); //1117:2
                bool __tmp60_outputWritten = false;
                string __tmp59Prefix = "	"; //1118:1
                var __tmp61 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp61.Write(CSharpName(sup, model, ClassKind.Builder, true));
                var __tmp61Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp61.ToStringAndFree());
                bool __tmp61_last = __tmp61Reader.EndOfStream;
                while(!__tmp61_last)
                {
                    ReadOnlySpan<char> __tmp61_line = __tmp61Reader.ReadLine();
                    __tmp61_last = __tmp61Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp59Prefix))
                    {
                        __out.Write(__tmp59Prefix);
                        __tmp60_outputWritten = true;
                    }
                    if (!__tmp61_last || !__tmp61_line.IsEmpty)
                    {
                        __out.Write(__tmp61_line);
                        __tmp60_outputWritten = true;
                    }
                    if (!__tmp61_last) __out.AppendLine(true);
                }
                string __tmp62_line = " "; //1118:50
                if (!string.IsNullOrEmpty(__tmp62_line))
                {
                    __out.Write(__tmp62_line);
                    __tmp60_outputWritten = true;
                }
                var __tmp63 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp63.Write(CSharpName(sup, model, ClassKind.Immutable, true));
                var __tmp63Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp63.ToStringAndFree());
                bool __tmp63_last = __tmp63Reader.EndOfStream;
                while(!__tmp63_last)
                {
                    ReadOnlySpan<char> __tmp63_line = __tmp63Reader.ReadLine();
                    __tmp63_last = __tmp63Reader.EndOfStream;
                    if (!__tmp63_last || !__tmp63_line.IsEmpty)
                    {
                        __out.Write(__tmp63_line);
                        __tmp60_outputWritten = true;
                    }
                    if (!__tmp63_last) __out.AppendLine(true);
                }
                string __tmp64_line = ".ToMutable()"; //1118:101
                if (!string.IsNullOrEmpty(__tmp64_line))
                {
                    __out.Write(__tmp64_line);
                    __tmp60_outputWritten = true;
                }
                if (__tmp60_outputWritten) __out.AppendLine(true);
                if (__tmp60_outputWritten)
                {
                    __out.AppendLine(false); //1118:113
                }
                __out.Write("	{"); //1119:1
                __out.AppendLine(false); //1119:3
                __out.Write("		return this.ToMutable();"); //1120:1
                __out.AppendLine(false); //1120:27
                __out.Write("	}"); //1121:1
                __out.AppendLine(false); //1121:3
                __out.AppendLine(true); //1122:2
                bool __tmp66_outputWritten = false;
                string __tmp65Prefix = "	"; //1123:1
                var __tmp67 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp67.Write(CSharpName(sup, model, ClassKind.Builder, true));
                var __tmp67Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp67.ToStringAndFree());
                bool __tmp67_last = __tmp67Reader.EndOfStream;
                while(!__tmp67_last)
                {
                    ReadOnlySpan<char> __tmp67_line = __tmp67Reader.ReadLine();
                    __tmp67_last = __tmp67Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp65Prefix))
                    {
                        __out.Write(__tmp65Prefix);
                        __tmp66_outputWritten = true;
                    }
                    if (!__tmp67_last || !__tmp67_line.IsEmpty)
                    {
                        __out.Write(__tmp67_line);
                        __tmp66_outputWritten = true;
                    }
                    if (!__tmp67_last) __out.AppendLine(true);
                }
                string __tmp68_line = " "; //1123:50
                if (!string.IsNullOrEmpty(__tmp68_line))
                {
                    __out.Write(__tmp68_line);
                    __tmp66_outputWritten = true;
                }
                var __tmp69 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp69.Write(CSharpName(sup, model, ClassKind.Immutable, true));
                var __tmp69Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp69.ToStringAndFree());
                bool __tmp69_last = __tmp69Reader.EndOfStream;
                while(!__tmp69_last)
                {
                    ReadOnlySpan<char> __tmp69_line = __tmp69Reader.ReadLine();
                    __tmp69_last = __tmp69Reader.EndOfStream;
                    if (!__tmp69_last || !__tmp69_line.IsEmpty)
                    {
                        __out.Write(__tmp69_line);
                        __tmp66_outputWritten = true;
                    }
                    if (!__tmp69_last) __out.AppendLine(true);
                }
                string __tmp70_line = ".ToMutable("; //1123:101
                if (!string.IsNullOrEmpty(__tmp70_line))
                {
                    __out.Write(__tmp70_line);
                    __tmp66_outputWritten = true;
                }
                var __tmp71 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp71.Write(Properties.CoreNs);
                var __tmp71Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp71.ToStringAndFree());
                bool __tmp71_last = __tmp71Reader.EndOfStream;
                while(!__tmp71_last)
                {
                    ReadOnlySpan<char> __tmp71_line = __tmp71Reader.ReadLine();
                    __tmp71_last = __tmp71Reader.EndOfStream;
                    if (!__tmp71_last || !__tmp71_line.IsEmpty)
                    {
                        __out.Write(__tmp71_line);
                        __tmp66_outputWritten = true;
                    }
                    if (!__tmp71_last) __out.AppendLine(true);
                }
                string __tmp72_line = ".MutableModel model)"; //1123:131
                if (!string.IsNullOrEmpty(__tmp72_line))
                {
                    __out.Write(__tmp72_line);
                    __tmp66_outputWritten = true;
                }
                if (__tmp66_outputWritten) __out.AppendLine(true);
                if (__tmp66_outputWritten)
                {
                    __out.AppendLine(false); //1123:151
                }
                __out.Write("	{"); //1124:1
                __out.AppendLine(false); //1124:3
                __out.Write("		return this.ToMutable(model);"); //1125:1
                __out.AppendLine(false); //1125:32
                __out.Write("	}"); //1126:1
                __out.AppendLine(false); //1126:3
            }
            var __loop71_results = 
                (from __loop71_var1 in __Enumerate((cls).GetEnumerator()) //1128:8
                from prop in __Enumerate((__loop71_var1.GetAllProperties()).GetEnumerator()) //1128:13
                select new { __loop71_var1 = __loop71_var1, prop = prop}
                ).ToList(); //1128:3
            for (int __loop71_iteration = 0; __loop71_iteration < __loop71_results.Count; ++__loop71_iteration)
            {
                var __tmp73 = __loop71_results[__loop71_iteration];
                var __loop71_var1 = __tmp73.__loop71_var1;
                var prop = __tmp73.prop;
                __out.AppendLine(true); //1129:2
                bool __tmp75_outputWritten = false;
                string __tmp74Prefix = "	"; //1130:1
                var __tmp76 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp76.Write(GenerateImmutablePropertyImpl(model, cls, prop));
                var __tmp76Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp76.ToStringAndFree());
                bool __tmp76_last = __tmp76Reader.EndOfStream;
                while(!__tmp76_last)
                {
                    ReadOnlySpan<char> __tmp76_line = __tmp76Reader.ReadLine();
                    __tmp76_last = __tmp76Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp74Prefix))
                    {
                        __out.Write(__tmp74Prefix);
                        __tmp75_outputWritten = true;
                    }
                    if (!__tmp76_last || !__tmp76_line.IsEmpty)
                    {
                        __out.Write(__tmp76_line);
                        __tmp75_outputWritten = true;
                    }
                    if (!__tmp76_last || __tmp75_outputWritten) __out.AppendLine(true);
                }
                if (__tmp75_outputWritten)
                {
                    __out.AppendLine(false); //1130:51
                }
            }
            var __loop72_results = 
                (from __loop72_var1 in __Enumerate((cls).GetEnumerator()) //1132:8
                from op in __Enumerate((__loop72_var1.GetAllOperations()).GetEnumerator()) //1132:13
                where !op.IsBuilder //1132:35
                select new { __loop72_var1 = __loop72_var1, op = op}
                ).ToList(); //1132:3
            for (int __loop72_iteration = 0; __loop72_iteration < __loop72_results.Count; ++__loop72_iteration)
            {
                var __tmp77 = __loop72_results[__loop72_iteration];
                var __loop72_var1 = __tmp77.__loop72_var1;
                var op = __tmp77.op;
                __out.AppendLine(true); //1133:2
                bool __tmp79_outputWritten = false;
                string __tmp78Prefix = "	"; //1134:1
                var __tmp80 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp80.Write(GenerateImmutableOperationImpl(model, cls, op));
                var __tmp80Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp80.ToStringAndFree());
                bool __tmp80_last = __tmp80Reader.EndOfStream;
                while(!__tmp80_last)
                {
                    ReadOnlySpan<char> __tmp80_line = __tmp80Reader.ReadLine();
                    __tmp80_last = __tmp80Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp78Prefix))
                    {
                        __out.Write(__tmp78Prefix);
                        __tmp79_outputWritten = true;
                    }
                    if (!__tmp80_last || !__tmp80_line.IsEmpty)
                    {
                        __out.Write(__tmp80_line);
                        __tmp79_outputWritten = true;
                    }
                    if (!__tmp80_last || __tmp79_outputWritten) __out.AppendLine(true);
                }
                if (__tmp79_outputWritten)
                {
                    __out.AppendLine(false); //1134:50
                }
            }
            if (metaMetaModel && cls.Name == "MetaModel") //1137:3
            {
                bool __tmp82_outputWritten = false;
                string __tmp81Prefix = "	"; //1138:1
                var __tmp83 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp83.Write(Properties.CoreNs);
                var __tmp83Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp83.ToStringAndFree());
                bool __tmp83_last = __tmp83Reader.EndOfStream;
                while(!__tmp83_last)
                {
                    ReadOnlySpan<char> __tmp83_line = __tmp83Reader.ReadLine();
                    __tmp83_last = __tmp83Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp81Prefix))
                    {
                        __out.Write(__tmp81Prefix);
                        __tmp82_outputWritten = true;
                    }
                    if (!__tmp83_last || !__tmp83_line.IsEmpty)
                    {
                        __out.Write(__tmp83_line);
                        __tmp82_outputWritten = true;
                    }
                    if (!__tmp83_last) __out.AppendLine(true);
                }
                string __tmp84_line = ".ModelId "; //1138:21
                if (!string.IsNullOrEmpty(__tmp84_line))
                {
                    __out.Write(__tmp84_line);
                    __tmp82_outputWritten = true;
                }
                var __tmp85 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp85.Write(Properties.CoreNs);
                var __tmp85Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp85.ToStringAndFree());
                bool __tmp85_last = __tmp85Reader.EndOfStream;
                while(!__tmp85_last)
                {
                    ReadOnlySpan<char> __tmp85_line = __tmp85Reader.ReadLine();
                    __tmp85_last = __tmp85Reader.EndOfStream;
                    if (!__tmp85_last || !__tmp85_line.IsEmpty)
                    {
                        __out.Write(__tmp85_line);
                        __tmp82_outputWritten = true;
                    }
                    if (!__tmp85_last) __out.AppendLine(true);
                }
                string __tmp86_line = ".IModel.Id => MetaInstance.MModel.Id;"; //1138:49
                if (!string.IsNullOrEmpty(__tmp86_line))
                {
                    __out.Write(__tmp86_line);
                    __tmp82_outputWritten = true;
                }
                if (__tmp82_outputWritten) __out.AppendLine(true);
                if (__tmp82_outputWritten)
                {
                    __out.AppendLine(false); //1138:86
                }
                bool __tmp88_outputWritten = false;
                string __tmp87Prefix = "	"; //1139:1
                var __tmp89 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp89.Write(Properties.CoreNs);
                var __tmp89Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp89.ToStringAndFree());
                bool __tmp89_last = __tmp89Reader.EndOfStream;
                while(!__tmp89_last)
                {
                    ReadOnlySpan<char> __tmp89_line = __tmp89Reader.ReadLine();
                    __tmp89_last = __tmp89Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp87Prefix))
                    {
                        __out.Write(__tmp87Prefix);
                        __tmp88_outputWritten = true;
                    }
                    if (!__tmp89_last || !__tmp89_line.IsEmpty)
                    {
                        __out.Write(__tmp89_line);
                        __tmp88_outputWritten = true;
                    }
                    if (!__tmp89_last) __out.AppendLine(true);
                }
                string __tmp90_line = ".ModelMetadata "; //1139:21
                if (!string.IsNullOrEmpty(__tmp90_line))
                {
                    __out.Write(__tmp90_line);
                    __tmp88_outputWritten = true;
                }
                var __tmp91 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp91.Write(Properties.CoreNs);
                var __tmp91Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp91.ToStringAndFree());
                bool __tmp91_last = __tmp91Reader.EndOfStream;
                while(!__tmp91_last)
                {
                    ReadOnlySpan<char> __tmp91_line = __tmp91Reader.ReadLine();
                    __tmp91_last = __tmp91Reader.EndOfStream;
                    if (!__tmp91_last || !__tmp91_line.IsEmpty)
                    {
                        __out.Write(__tmp91_line);
                        __tmp88_outputWritten = true;
                    }
                    if (!__tmp91_last) __out.AppendLine(true);
                }
                string __tmp92_line = ".IModel.Metadata => "; //1139:55
                if (!string.IsNullOrEmpty(__tmp92_line))
                {
                    __out.Write(__tmp92_line);
                    __tmp88_outputWritten = true;
                }
                var __tmp93 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp93.Write(CSharpName(model, ModelKind.ImmutableInstance));
                var __tmp93Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp93.ToStringAndFree());
                bool __tmp93_last = __tmp93Reader.EndOfStream;
                while(!__tmp93_last)
                {
                    ReadOnlySpan<char> __tmp93_line = __tmp93Reader.ReadLine();
                    __tmp93_last = __tmp93Reader.EndOfStream;
                    if (!__tmp93_last || !__tmp93_line.IsEmpty)
                    {
                        __out.Write(__tmp93_line);
                        __tmp88_outputWritten = true;
                    }
                    if (!__tmp93_last) __out.AppendLine(true);
                }
                string __tmp94_line = ".MModel.Metadata;"; //1139:122
                if (!string.IsNullOrEmpty(__tmp94_line))
                {
                    __out.Write(__tmp94_line);
                    __tmp88_outputWritten = true;
                }
                if (__tmp88_outputWritten) __out.AppendLine(true);
                if (__tmp88_outputWritten)
                {
                    __out.AppendLine(false); //1139:139
                }
                bool __tmp96_outputWritten = false;
                string __tmp97_line = "	global::System.Collections.Generic.IEnumerable<global::MetaDslx.Modeling.IModelObject> "; //1140:1
                if (!string.IsNullOrEmpty(__tmp97_line))
                {
                    __out.Write(__tmp97_line);
                    __tmp96_outputWritten = true;
                }
                var __tmp98 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp98.Write(Properties.CoreNs);
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
                string __tmp99_line = ".IModel.Objects => "; //1140:108
                if (!string.IsNullOrEmpty(__tmp99_line))
                {
                    __out.Write(__tmp99_line);
                    __tmp96_outputWritten = true;
                }
                var __tmp100 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp100.Write(CSharpName(model, ModelKind.ImmutableInstance));
                var __tmp100Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp100.ToStringAndFree());
                bool __tmp100_last = __tmp100Reader.EndOfStream;
                while(!__tmp100_last)
                {
                    ReadOnlySpan<char> __tmp100_line = __tmp100Reader.ReadLine();
                    __tmp100_last = __tmp100Reader.EndOfStream;
                    if (!__tmp100_last || !__tmp100_line.IsEmpty)
                    {
                        __out.Write(__tmp100_line);
                        __tmp96_outputWritten = true;
                    }
                    if (!__tmp100_last) __out.AppendLine(true);
                }
                string __tmp101_line = ".MModel.Objects;"; //1140:174
                if (!string.IsNullOrEmpty(__tmp101_line))
                {
                    __out.Write(__tmp101_line);
                    __tmp96_outputWritten = true;
                }
                if (__tmp96_outputWritten) __out.AppendLine(true);
                if (__tmp96_outputWritten)
                {
                    __out.AppendLine(false); //1140:190
                }
                bool __tmp103_outputWritten = false;
                string __tmp102Prefix = "	"; //1141:1
                var __tmp104 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp104.Write(Properties.CoreNs);
                var __tmp104Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp104.ToStringAndFree());
                bool __tmp104_last = __tmp104Reader.EndOfStream;
                while(!__tmp104_last)
                {
                    ReadOnlySpan<char> __tmp104_line = __tmp104Reader.ReadLine();
                    __tmp104_last = __tmp104Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp102Prefix))
                    {
                        __out.Write(__tmp102Prefix);
                        __tmp103_outputWritten = true;
                    }
                    if (!__tmp104_last || !__tmp104_line.IsEmpty)
                    {
                        __out.Write(__tmp104_line);
                        __tmp103_outputWritten = true;
                    }
                    if (!__tmp104_last) __out.AppendLine(true);
                }
                string __tmp105_line = ".IModelGroup "; //1141:21
                if (!string.IsNullOrEmpty(__tmp105_line))
                {
                    __out.Write(__tmp105_line);
                    __tmp103_outputWritten = true;
                }
                var __tmp106 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp106.Write(Properties.CoreNs);
                var __tmp106Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp106.ToStringAndFree());
                bool __tmp106_last = __tmp106Reader.EndOfStream;
                while(!__tmp106_last)
                {
                    ReadOnlySpan<char> __tmp106_line = __tmp106Reader.ReadLine();
                    __tmp106_last = __tmp106Reader.EndOfStream;
                    if (!__tmp106_last || !__tmp106_line.IsEmpty)
                    {
                        __out.Write(__tmp106_line);
                        __tmp103_outputWritten = true;
                    }
                    if (!__tmp106_last) __out.AppendLine(true);
                }
                string __tmp107_line = ".IModel.ModelGroup => "; //1141:53
                if (!string.IsNullOrEmpty(__tmp107_line))
                {
                    __out.Write(__tmp107_line);
                    __tmp103_outputWritten = true;
                }
                var __tmp108 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp108.Write(CSharpName(model, ModelKind.ImmutableInstance));
                var __tmp108Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp108.ToStringAndFree());
                bool __tmp108_last = __tmp108Reader.EndOfStream;
                while(!__tmp108_last)
                {
                    ReadOnlySpan<char> __tmp108_line = __tmp108Reader.ReadLine();
                    __tmp108_last = __tmp108Reader.EndOfStream;
                    if (!__tmp108_last || !__tmp108_line.IsEmpty)
                    {
                        __out.Write(__tmp108_line);
                        __tmp103_outputWritten = true;
                    }
                    if (!__tmp108_last) __out.AppendLine(true);
                }
                string __tmp109_line = ".MModel.ModelGroup;"; //1141:122
                if (!string.IsNullOrEmpty(__tmp109_line))
                {
                    __out.Write(__tmp109_line);
                    __tmp103_outputWritten = true;
                }
                if (__tmp103_outputWritten) __out.AppendLine(true);
                if (__tmp103_outputWritten)
                {
                    __out.AppendLine(false); //1141:141
                }
                __out.AppendLine(true); //1142:1
                bool __tmp111_outputWritten = false;
                string __tmp112_line = "	public "; //1143:1
                if (!string.IsNullOrEmpty(__tmp112_line))
                {
                    __out.Write(__tmp112_line);
                    __tmp111_outputWritten = true;
                }
                var __tmp113 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp113.Write(Properties.CoreNs);
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
                string __tmp114_line = ".IModelFactory CreateFactory("; //1143:28
                if (!string.IsNullOrEmpty(__tmp114_line))
                {
                    __out.Write(__tmp114_line);
                    __tmp111_outputWritten = true;
                }
                var __tmp115 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp115.Write(Properties.CoreNs);
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
                string __tmp116_line = ".MutableModel model, "; //1143:76
                if (!string.IsNullOrEmpty(__tmp116_line))
                {
                    __out.Write(__tmp116_line);
                    __tmp111_outputWritten = true;
                }
                var __tmp117 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp117.Write(Properties.CoreNs);
                var __tmp117Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp117.ToStringAndFree());
                bool __tmp117_last = __tmp117Reader.EndOfStream;
                while(!__tmp117_last)
                {
                    ReadOnlySpan<char> __tmp117_line = __tmp117Reader.ReadLine();
                    __tmp117_last = __tmp117Reader.EndOfStream;
                    if (!__tmp117_last || !__tmp117_line.IsEmpty)
                    {
                        __out.Write(__tmp117_line);
                        __tmp111_outputWritten = true;
                    }
                    if (!__tmp117_last) __out.AppendLine(true);
                }
                string __tmp118_line = ".ModelFactoryFlags flags = "; //1143:116
                if (!string.IsNullOrEmpty(__tmp118_line))
                {
                    __out.Write(__tmp118_line);
                    __tmp111_outputWritten = true;
                }
                var __tmp119 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp119.Write(Properties.CoreNs);
                var __tmp119Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp119.ToStringAndFree());
                bool __tmp119_last = __tmp119Reader.EndOfStream;
                while(!__tmp119_last)
                {
                    ReadOnlySpan<char> __tmp119_line = __tmp119Reader.ReadLine();
                    __tmp119_last = __tmp119Reader.EndOfStream;
                    if (!__tmp119_last || !__tmp119_line.IsEmpty)
                    {
                        __out.Write(__tmp119_line);
                        __tmp111_outputWritten = true;
                    }
                    if (!__tmp119_last) __out.AppendLine(true);
                }
                string __tmp120_line = ".ModelFactoryFlags.None)"; //1143:162
                if (!string.IsNullOrEmpty(__tmp120_line))
                {
                    __out.Write(__tmp120_line);
                    __tmp111_outputWritten = true;
                }
                if (__tmp111_outputWritten) __out.AppendLine(true);
                if (__tmp111_outputWritten)
                {
                    __out.AppendLine(false); //1143:186
                }
                __out.Write("	{"); //1144:1
                __out.AppendLine(false); //1144:3
                bool __tmp122_outputWritten = false;
                string __tmp123_line = "		return new "; //1145:1
                if (!string.IsNullOrEmpty(__tmp123_line))
                {
                    __out.Write(__tmp123_line);
                    __tmp122_outputWritten = true;
                }
                var __tmp124 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp124.Write(CSharpName(model, ModelKind.Factory));
                var __tmp124Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp124.ToStringAndFree());
                bool __tmp124_last = __tmp124Reader.EndOfStream;
                while(!__tmp124_last)
                {
                    ReadOnlySpan<char> __tmp124_line = __tmp124Reader.ReadLine();
                    __tmp124_last = __tmp124Reader.EndOfStream;
                    if (!__tmp124_last || !__tmp124_line.IsEmpty)
                    {
                        __out.Write(__tmp124_line);
                        __tmp122_outputWritten = true;
                    }
                    if (!__tmp124_last) __out.AppendLine(true);
                }
                string __tmp125_line = "(model, flags);"; //1145:51
                if (!string.IsNullOrEmpty(__tmp125_line))
                {
                    __out.Write(__tmp125_line);
                    __tmp122_outputWritten = true;
                }
                if (__tmp122_outputWritten) __out.AppendLine(true);
                if (__tmp122_outputWritten)
                {
                    __out.AppendLine(false); //1145:66
                }
                __out.Write("	}"); //1146:1
                __out.AppendLine(false); //1146:3
            }
            __out.Write("}"); //1148:1
            __out.AppendLine(false); //1148:2
            return __out.ToStringAndFree();
        }

        public string GenerateImmutableField(MetaModel model, MetaClass cls, MetaProperty prop) //1151:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp3.Write("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
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
                __out.AppendLine(false); //1152:54
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "private "; //1153:1
            if (!string.IsNullOrEmpty(__tmp6_line))
            {
                __out.Write(__tmp6_line);
                __tmp5_outputWritten = true;
            }
            var __tmp7 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp7.Write(CSharpName(prop.Type, model, ClassKind.Immutable, true));
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
            string __tmp8_line = " "; //1153:65
            if (!string.IsNullOrEmpty(__tmp8_line))
            {
                __out.Write(__tmp8_line);
                __tmp5_outputWritten = true;
            }
            var __tmp9 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp9.Write(GetFieldName(prop, cls));
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
            string __tmp10_line = ";"; //1153:90
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Write(__tmp10_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //1153:91
            }
            return __out.ToStringAndFree();
        }

        public string GenerateImmutablePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //1156:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.AppendLine(true); //1157:1
            if (cls.GetAllFinalProperties().Contains(prop)) //1158:2
            {
                bool __tmp2_outputWritten = false;
                string __tmp3_line = "public "; //1159:1
                if (!string.IsNullOrEmpty(__tmp3_line))
                {
                    __out.Write(__tmp3_line);
                    __tmp2_outputWritten = true;
                }
                var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp4.Write(CSharpName(prop.Type, model, ClassKind.Immutable, true));
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
                string __tmp5_line = " "; //1159:64
                if (!string.IsNullOrEmpty(__tmp5_line))
                {
                    __out.Write(__tmp5_line);
                    __tmp2_outputWritten = true;
                }
                var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp6.Write(prop.Name);
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
                    if (!__tmp6_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
                if (__tmp2_outputWritten)
                {
                    __out.AppendLine(false); //1159:76
                }
            }
            else //1160:2
            {
                bool __tmp8_outputWritten = false;
                var __tmp9 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp9.Write("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
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
                    __out.AppendLine(false); //1161:54
                }
                bool __tmp11_outputWritten = false;
                var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp12.Write(CSharpName(prop.Type, model, ClassKind.Immutable, true));
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
                    if (!__tmp12_last) __out.AppendLine(true);
                }
                string __tmp13_line = " "; //1162:57
                if (!string.IsNullOrEmpty(__tmp13_line))
                {
                    __out.Write(__tmp13_line);
                    __tmp11_outputWritten = true;
                }
                var __tmp14 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp14.Write(CSharpName(prop.Class, model, ClassKind.Immutable, true));
                var __tmp14Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp14.ToStringAndFree());
                bool __tmp14_last = __tmp14Reader.EndOfStream;
                while(!__tmp14_last)
                {
                    ReadOnlySpan<char> __tmp14_line = __tmp14Reader.ReadLine();
                    __tmp14_last = __tmp14Reader.EndOfStream;
                    if (!__tmp14_last || !__tmp14_line.IsEmpty)
                    {
                        __out.Write(__tmp14_line);
                        __tmp11_outputWritten = true;
                    }
                    if (!__tmp14_last) __out.AppendLine(true);
                }
                string __tmp15_line = "."; //1162:115
                if (!string.IsNullOrEmpty(__tmp15_line))
                {
                    __out.Write(__tmp15_line);
                    __tmp11_outputWritten = true;
                }
                var __tmp16 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp16.Write(prop.Name);
                var __tmp16Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp16.ToStringAndFree());
                bool __tmp16_last = __tmp16Reader.EndOfStream;
                while(!__tmp16_last)
                {
                    ReadOnlySpan<char> __tmp16_line = __tmp16Reader.ReadLine();
                    __tmp16_last = __tmp16Reader.EndOfStream;
                    if (!__tmp16_last || !__tmp16_line.IsEmpty)
                    {
                        __out.Write(__tmp16_line);
                        __tmp11_outputWritten = true;
                    }
                    if (!__tmp16_last || __tmp11_outputWritten) __out.AppendLine(true);
                }
                if (__tmp11_outputWritten)
                {
                    __out.AppendLine(false); //1162:127
                }
            }
            __out.Write("{"); //1164:1
            __out.AppendLine(false); //1164:2
            if (prop.Type is MetaCollectionType) //1165:6
            {
                if (((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.Set || ((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiSet) //1166:4
                {
                    bool __tmp18_outputWritten = false;
                    string __tmp19_line = "    get { return this.GetSet<"; //1167:1
                    if (!string.IsNullOrEmpty(__tmp19_line))
                    {
                        __out.Write(__tmp19_line);
                        __tmp18_outputWritten = true;
                    }
                    var __tmp20 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp20.Write(CSharpName(((MetaCollectionType)prop.Type).InnerType, model, ClassKind.Immutable, true));
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
                    string __tmp21_line = ">("; //1167:118
                    if (!string.IsNullOrEmpty(__tmp21_line))
                    {
                        __out.Write(__tmp21_line);
                        __tmp18_outputWritten = true;
                    }
                    var __tmp22 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp22.Write(CSharpName(prop, null, PropertyKind.Descriptor, true));
                    var __tmp22Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp22.ToStringAndFree());
                    bool __tmp22_last = __tmp22Reader.EndOfStream;
                    while(!__tmp22_last)
                    {
                        ReadOnlySpan<char> __tmp22_line = __tmp22Reader.ReadLine();
                        __tmp22_last = __tmp22Reader.EndOfStream;
                        if (!__tmp22_last || !__tmp22_line.IsEmpty)
                        {
                            __out.Write(__tmp22_line);
                            __tmp18_outputWritten = true;
                        }
                        if (!__tmp22_last) __out.AppendLine(true);
                    }
                    string __tmp23_line = ", ref "; //1167:174
                    if (!string.IsNullOrEmpty(__tmp23_line))
                    {
                        __out.Write(__tmp23_line);
                        __tmp18_outputWritten = true;
                    }
                    var __tmp24 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp24.Write(GetFieldName(prop, cls));
                    var __tmp24Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp24.ToStringAndFree());
                    bool __tmp24_last = __tmp24Reader.EndOfStream;
                    while(!__tmp24_last)
                    {
                        ReadOnlySpan<char> __tmp24_line = __tmp24Reader.ReadLine();
                        __tmp24_last = __tmp24Reader.EndOfStream;
                        if (!__tmp24_last || !__tmp24_line.IsEmpty)
                        {
                            __out.Write(__tmp24_line);
                            __tmp18_outputWritten = true;
                        }
                        if (!__tmp24_last) __out.AppendLine(true);
                    }
                    string __tmp25_line = "); }"; //1167:204
                    if (!string.IsNullOrEmpty(__tmp25_line))
                    {
                        __out.Write(__tmp25_line);
                        __tmp18_outputWritten = true;
                    }
                    if (__tmp18_outputWritten) __out.AppendLine(true);
                    if (__tmp18_outputWritten)
                    {
                        __out.AppendLine(false); //1167:208
                    }
                }
                else //1168:4
                {
                    bool __tmp27_outputWritten = false;
                    string __tmp28_line = "    get { return this.GetList<"; //1169:1
                    if (!string.IsNullOrEmpty(__tmp28_line))
                    {
                        __out.Write(__tmp28_line);
                        __tmp27_outputWritten = true;
                    }
                    var __tmp29 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp29.Write(CSharpName(((MetaCollectionType)prop.Type).InnerType, model, ClassKind.Immutable, true));
                    var __tmp29Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp29.ToStringAndFree());
                    bool __tmp29_last = __tmp29Reader.EndOfStream;
                    while(!__tmp29_last)
                    {
                        ReadOnlySpan<char> __tmp29_line = __tmp29Reader.ReadLine();
                        __tmp29_last = __tmp29Reader.EndOfStream;
                        if (!__tmp29_last || !__tmp29_line.IsEmpty)
                        {
                            __out.Write(__tmp29_line);
                            __tmp27_outputWritten = true;
                        }
                        if (!__tmp29_last) __out.AppendLine(true);
                    }
                    string __tmp30_line = ">("; //1169:119
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Write(__tmp30_line);
                        __tmp27_outputWritten = true;
                    }
                    var __tmp31 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp31.Write(CSharpName(prop, null, PropertyKind.Descriptor, true));
                    var __tmp31Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp31.ToStringAndFree());
                    bool __tmp31_last = __tmp31Reader.EndOfStream;
                    while(!__tmp31_last)
                    {
                        ReadOnlySpan<char> __tmp31_line = __tmp31Reader.ReadLine();
                        __tmp31_last = __tmp31Reader.EndOfStream;
                        if (!__tmp31_last || !__tmp31_line.IsEmpty)
                        {
                            __out.Write(__tmp31_line);
                            __tmp27_outputWritten = true;
                        }
                        if (!__tmp31_last) __out.AppendLine(true);
                    }
                    string __tmp32_line = ", ref "; //1169:175
                    if (!string.IsNullOrEmpty(__tmp32_line))
                    {
                        __out.Write(__tmp32_line);
                        __tmp27_outputWritten = true;
                    }
                    var __tmp33 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp33.Write(GetFieldName(prop, cls));
                    var __tmp33Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp33.ToStringAndFree());
                    bool __tmp33_last = __tmp33Reader.EndOfStream;
                    while(!__tmp33_last)
                    {
                        ReadOnlySpan<char> __tmp33_line = __tmp33Reader.ReadLine();
                        __tmp33_last = __tmp33Reader.EndOfStream;
                        if (!__tmp33_last || !__tmp33_line.IsEmpty)
                        {
                            __out.Write(__tmp33_line);
                            __tmp27_outputWritten = true;
                        }
                        if (!__tmp33_last) __out.AppendLine(true);
                    }
                    string __tmp34_line = "); }"; //1169:205
                    if (!string.IsNullOrEmpty(__tmp34_line))
                    {
                        __out.Write(__tmp34_line);
                        __tmp27_outputWritten = true;
                    }
                    if (__tmp27_outputWritten) __out.AppendLine(true);
                    if (__tmp27_outputWritten)
                    {
                        __out.AppendLine(false); //1169:209
                    }
                }
            }
            else if (IsReferenceType(prop.Type)) //1171:3
            {
                bool __tmp36_outputWritten = false;
                string __tmp37_line = "    get { return this.GetReference<"; //1172:1
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Write(__tmp37_line);
                    __tmp36_outputWritten = true;
                }
                var __tmp38 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp38.Write(CSharpName(prop.Type, model, ClassKind.Immutable, true));
                var __tmp38Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp38.ToStringAndFree());
                bool __tmp38_last = __tmp38Reader.EndOfStream;
                while(!__tmp38_last)
                {
                    ReadOnlySpan<char> __tmp38_line = __tmp38Reader.ReadLine();
                    __tmp38_last = __tmp38Reader.EndOfStream;
                    if (!__tmp38_last || !__tmp38_line.IsEmpty)
                    {
                        __out.Write(__tmp38_line);
                        __tmp36_outputWritten = true;
                    }
                    if (!__tmp38_last) __out.AppendLine(true);
                }
                string __tmp39_line = ">("; //1172:92
                if (!string.IsNullOrEmpty(__tmp39_line))
                {
                    __out.Write(__tmp39_line);
                    __tmp36_outputWritten = true;
                }
                var __tmp40 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp40.Write(CSharpName(prop, null, PropertyKind.Descriptor, true));
                var __tmp40Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp40.ToStringAndFree());
                bool __tmp40_last = __tmp40Reader.EndOfStream;
                while(!__tmp40_last)
                {
                    ReadOnlySpan<char> __tmp40_line = __tmp40Reader.ReadLine();
                    __tmp40_last = __tmp40Reader.EndOfStream;
                    if (!__tmp40_last || !__tmp40_line.IsEmpty)
                    {
                        __out.Write(__tmp40_line);
                        __tmp36_outputWritten = true;
                    }
                    if (!__tmp40_last) __out.AppendLine(true);
                }
                string __tmp41_line = ", ref "; //1172:148
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Write(__tmp41_line);
                    __tmp36_outputWritten = true;
                }
                var __tmp42 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp42.Write(GetFieldName(prop, cls));
                var __tmp42Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp42.ToStringAndFree());
                bool __tmp42_last = __tmp42Reader.EndOfStream;
                while(!__tmp42_last)
                {
                    ReadOnlySpan<char> __tmp42_line = __tmp42Reader.ReadLine();
                    __tmp42_last = __tmp42Reader.EndOfStream;
                    if (!__tmp42_last || !__tmp42_line.IsEmpty)
                    {
                        __out.Write(__tmp42_line);
                        __tmp36_outputWritten = true;
                    }
                    if (!__tmp42_last) __out.AppendLine(true);
                }
                string __tmp43_line = "); }"; //1172:178
                if (!string.IsNullOrEmpty(__tmp43_line))
                {
                    __out.Write(__tmp43_line);
                    __tmp36_outputWritten = true;
                }
                if (__tmp36_outputWritten) __out.AppendLine(true);
                if (__tmp36_outputWritten)
                {
                    __out.AppendLine(false); //1172:182
                }
            }
            else //1173:3
            {
                bool __tmp45_outputWritten = false;
                string __tmp46_line = "    get { return this.GetValue<"; //1174:1
                if (!string.IsNullOrEmpty(__tmp46_line))
                {
                    __out.Write(__tmp46_line);
                    __tmp45_outputWritten = true;
                }
                var __tmp47 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp47.Write(CSharpName(prop.Type, model, ClassKind.Immutable, true));
                var __tmp47Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp47.ToStringAndFree());
                bool __tmp47_last = __tmp47Reader.EndOfStream;
                while(!__tmp47_last)
                {
                    ReadOnlySpan<char> __tmp47_line = __tmp47Reader.ReadLine();
                    __tmp47_last = __tmp47Reader.EndOfStream;
                    if (!__tmp47_last || !__tmp47_line.IsEmpty)
                    {
                        __out.Write(__tmp47_line);
                        __tmp45_outputWritten = true;
                    }
                    if (!__tmp47_last) __out.AppendLine(true);
                }
                string __tmp48_line = ">("; //1174:88
                if (!string.IsNullOrEmpty(__tmp48_line))
                {
                    __out.Write(__tmp48_line);
                    __tmp45_outputWritten = true;
                }
                var __tmp49 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp49.Write(CSharpName(prop, null, PropertyKind.Descriptor, true));
                var __tmp49Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp49.ToStringAndFree());
                bool __tmp49_last = __tmp49Reader.EndOfStream;
                while(!__tmp49_last)
                {
                    ReadOnlySpan<char> __tmp49_line = __tmp49Reader.ReadLine();
                    __tmp49_last = __tmp49Reader.EndOfStream;
                    if (!__tmp49_last || !__tmp49_line.IsEmpty)
                    {
                        __out.Write(__tmp49_line);
                        __tmp45_outputWritten = true;
                    }
                    if (!__tmp49_last) __out.AppendLine(true);
                }
                string __tmp50_line = ", ref "; //1174:144
                if (!string.IsNullOrEmpty(__tmp50_line))
                {
                    __out.Write(__tmp50_line);
                    __tmp45_outputWritten = true;
                }
                var __tmp51 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp51.Write(GetFieldName(prop, cls));
                var __tmp51Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp51.ToStringAndFree());
                bool __tmp51_last = __tmp51Reader.EndOfStream;
                while(!__tmp51_last)
                {
                    ReadOnlySpan<char> __tmp51_line = __tmp51Reader.ReadLine();
                    __tmp51_last = __tmp51Reader.EndOfStream;
                    if (!__tmp51_last || !__tmp51_line.IsEmpty)
                    {
                        __out.Write(__tmp51_line);
                        __tmp45_outputWritten = true;
                    }
                    if (!__tmp51_last) __out.AppendLine(true);
                }
                string __tmp52_line = "); }"; //1174:174
                if (!string.IsNullOrEmpty(__tmp52_line))
                {
                    __out.Write(__tmp52_line);
                    __tmp45_outputWritten = true;
                }
                if (__tmp45_outputWritten) __out.AppendLine(true);
                if (__tmp45_outputWritten)
                {
                    __out.AppendLine(false); //1174:178
                }
            }
            __out.Write("}"); //1176:1
            __out.AppendLine(false); //1176:2
            return __out.ToStringAndFree();
        }

        public string GenerateImmutableOperationImpl(MetaModel model, MetaClass cls, MetaOperation op) //1179:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.AppendLine(true); //1180:1
            bool __tmp2_outputWritten = false;
            var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp3.Write(CSharpName(op.ReturnType, model, ClassKind.ImmutableOperation, true));
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
                if (!__tmp3_last) __out.AppendLine(true);
            }
            string __tmp4_line = " "; //1181:70
            if (!string.IsNullOrEmpty(__tmp4_line))
            {
                __out.Write(__tmp4_line);
                __tmp2_outputWritten = true;
            }
            var __tmp5 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp5.Write(CSharpName(op.Class, model, ClassKind.Immutable, true));
            var __tmp5Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp5.ToStringAndFree());
            bool __tmp5_last = __tmp5Reader.EndOfStream;
            while(!__tmp5_last)
            {
                ReadOnlySpan<char> __tmp5_line = __tmp5Reader.ReadLine();
                __tmp5_last = __tmp5Reader.EndOfStream;
                if (!__tmp5_last || !__tmp5_line.IsEmpty)
                {
                    __out.Write(__tmp5_line);
                    __tmp2_outputWritten = true;
                }
                if (!__tmp5_last) __out.AppendLine(true);
            }
            string __tmp6_line = "."; //1181:126
            if (!string.IsNullOrEmpty(__tmp6_line))
            {
                __out.Write(__tmp6_line);
                __tmp2_outputWritten = true;
            }
            var __tmp7 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp7.Write(op.Name);
            var __tmp7Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp7.ToStringAndFree());
            bool __tmp7_last = __tmp7Reader.EndOfStream;
            while(!__tmp7_last)
            {
                ReadOnlySpan<char> __tmp7_line = __tmp7Reader.ReadLine();
                __tmp7_last = __tmp7Reader.EndOfStream;
                if (!__tmp7_last || !__tmp7_line.IsEmpty)
                {
                    __out.Write(__tmp7_line);
                    __tmp2_outputWritten = true;
                }
                if (!__tmp7_last) __out.AppendLine(true);
            }
            string __tmp8_line = "("; //1181:136
            if (!string.IsNullOrEmpty(__tmp8_line))
            {
                __out.Write(__tmp8_line);
                __tmp2_outputWritten = true;
            }
            var __tmp9 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp9.Write(GetClassParameters(model, op.Class, op, ClassKind.ImmutableOperation));
            var __tmp9Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp9.ToStringAndFree());
            bool __tmp9_last = __tmp9Reader.EndOfStream;
            while(!__tmp9_last)
            {
                ReadOnlySpan<char> __tmp9_line = __tmp9Reader.ReadLine();
                __tmp9_last = __tmp9Reader.EndOfStream;
                if (!__tmp9_last || !__tmp9_line.IsEmpty)
                {
                    __out.Write(__tmp9_line);
                    __tmp2_outputWritten = true;
                }
                if (!__tmp9_last) __out.AppendLine(true);
            }
            string __tmp10_line = ")"; //1181:208
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Write(__tmp10_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //1181:209
            }
            __out.Write("{"); //1182:1
            __out.AppendLine(false); //1182:2
            var finalOp = GetFinalOperation(cls, op); //1183:2
            bool __tmp12_outputWritten = false;
            string __tmp11Prefix = "    "; //1184:1
            var __tmp13 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp13.Write(GetReturn(CSharpName(finalOp.ReturnType, model, ClassKind.ImmutableOperation)));
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
                if (!__tmp13_last) __out.AppendLine(true);
            }
            var __tmp14 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp14.Write(CSharpName(model, ModelKind.ImplementationProvider));
            var __tmp14Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp14.ToStringAndFree());
            bool __tmp14_last = __tmp14Reader.EndOfStream;
            while(!__tmp14_last)
            {
                ReadOnlySpan<char> __tmp14_line = __tmp14Reader.ReadLine();
                __tmp14_last = __tmp14Reader.EndOfStream;
                if (!__tmp14_last || !__tmp14_line.IsEmpty)
                {
                    __out.Write(__tmp14_line);
                    __tmp12_outputWritten = true;
                }
                if (!__tmp14_last) __out.AppendLine(true);
            }
            string __tmp15_line = ".Implementation."; //1184:136
            if (!string.IsNullOrEmpty(__tmp15_line))
            {
                __out.Write(__tmp15_line);
                __tmp12_outputWritten = true;
            }
            var __tmp16 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp16.Write(CSharpName(finalOp.Class, model, ClassKind.Immutable));
            var __tmp16Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp16.ToStringAndFree());
            bool __tmp16_last = __tmp16Reader.EndOfStream;
            while(!__tmp16_last)
            {
                ReadOnlySpan<char> __tmp16_line = __tmp16Reader.ReadLine();
                __tmp16_last = __tmp16Reader.EndOfStream;
                if (!__tmp16_last || !__tmp16_line.IsEmpty)
                {
                    __out.Write(__tmp16_line);
                    __tmp12_outputWritten = true;
                }
                if (!__tmp16_last) __out.AppendLine(true);
            }
            string __tmp17_line = "_"; //1184:206
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Write(__tmp17_line);
                __tmp12_outputWritten = true;
            }
            var __tmp18 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp18.Write(finalOp.Name);
            var __tmp18Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp18.ToStringAndFree());
            bool __tmp18_last = __tmp18Reader.EndOfStream;
            while(!__tmp18_last)
            {
                ReadOnlySpan<char> __tmp18_line = __tmp18Reader.ReadLine();
                __tmp18_last = __tmp18Reader.EndOfStream;
                if (!__tmp18_last || !__tmp18_line.IsEmpty)
                {
                    __out.Write(__tmp18_line);
                    __tmp12_outputWritten = true;
                }
                if (!__tmp18_last) __out.AppendLine(true);
            }
            string __tmp19_line = "("; //1184:221
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Write(__tmp19_line);
                __tmp12_outputWritten = true;
            }
            var __tmp20 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp20.Write(GetClassImplCallParameterNames(model, finalOp, ClassKind.ImmutableOperation));
            var __tmp20Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp20.ToStringAndFree());
            bool __tmp20_last = __tmp20Reader.EndOfStream;
            while(!__tmp20_last)
            {
                ReadOnlySpan<char> __tmp20_line = __tmp20Reader.ReadLine();
                __tmp20_last = __tmp20Reader.EndOfStream;
                if (!__tmp20_last || !__tmp20_line.IsEmpty)
                {
                    __out.Write(__tmp20_line);
                    __tmp12_outputWritten = true;
                }
                if (!__tmp20_last) __out.AppendLine(true);
            }
            string __tmp21_line = ");"; //1184:300
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp12_outputWritten = true;
            }
            if (__tmp12_outputWritten) __out.AppendLine(true);
            if (__tmp12_outputWritten)
            {
                __out.AppendLine(false); //1184:302
            }
            __out.Write("}"); //1185:1
            __out.AppendLine(false); //1185:2
            return __out.ToStringAndFree();
        }

        public string GenerateBuilderImplClass(MetaModel model, MetaClass cls) //1188:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool metaMetaModel = IsMetaMetaModel(model); //1189:2
            string metaNs = metaMetaModel ? "" : Properties.MetaNs + "."; //1190:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //1191:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Write(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp4.Write(CSharpName(cls, model, ClassKind.BuilderImpl));
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
            string __tmp5_line = " : "; //1191:62
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp6.Write(Properties.CoreNs);
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
            string __tmp7_line = ".MutableObjectBase, "; //1191:84
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            var __tmp8 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp8.Write(CSharpName(cls, model, ClassKind.Builder));
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
                if (!__tmp8_last || __tmp2_outputWritten) __out.AppendLine(true);
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //1191:146
            }
            __out.Write("{"); //1192:1
            __out.AppendLine(false); //1192:2
            var __loop73_results = 
                (from __loop73_var1 in __Enumerate((cls).GetEnumerator()) //1193:8
                from prop in __Enumerate((__loop73_var1.GetAllProperties()).GetEnumerator()) //1193:13
                where prop.Type is MetaCollectionType //1193:37
                select new { __loop73_var1 = __loop73_var1, prop = prop}
                ).ToList(); //1193:3
            for (int __loop73_iteration = 0; __loop73_iteration < __loop73_results.Count; ++__loop73_iteration)
            {
                var __tmp9 = __loop73_results[__loop73_iteration];
                var __loop73_var1 = __tmp9.__loop73_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //1194:1
                var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp12.Write(GenerateBuilderField(model, cls, prop));
                var __tmp12Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp12.ToStringAndFree());
                bool __tmp12_last = __tmp12Reader.EndOfStream;
                while(!__tmp12_last)
                {
                    ReadOnlySpan<char> __tmp12_line = __tmp12Reader.ReadLine();
                    __tmp12_last = __tmp12Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp10Prefix))
                    {
                        __out.Write(__tmp10Prefix);
                        __tmp11_outputWritten = true;
                    }
                    if (!__tmp12_last || !__tmp12_line.IsEmpty)
                    {
                        __out.Write(__tmp12_line);
                        __tmp11_outputWritten = true;
                    }
                    if (!__tmp12_last || __tmp11_outputWritten) __out.AppendLine(true);
                }
                if (__tmp11_outputWritten)
                {
                    __out.AppendLine(false); //1194:42
                }
            }
            __out.AppendLine(true); //1196:2
            bool __tmp14_outputWritten = false;
            string __tmp15_line = "	internal "; //1197:1
            if (!string.IsNullOrEmpty(__tmp15_line))
            {
                __out.Write(__tmp15_line);
                __tmp14_outputWritten = true;
            }
            var __tmp16 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp16.Write(CSharpName(cls, model, ClassKind.BuilderImpl));
            var __tmp16Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp16.ToStringAndFree());
            bool __tmp16_last = __tmp16Reader.EndOfStream;
            while(!__tmp16_last)
            {
                ReadOnlySpan<char> __tmp16_line = __tmp16Reader.ReadLine();
                __tmp16_last = __tmp16Reader.EndOfStream;
                if (!__tmp16_last || !__tmp16_line.IsEmpty)
                {
                    __out.Write(__tmp16_line);
                    __tmp14_outputWritten = true;
                }
                if (!__tmp16_last) __out.AppendLine(true);
            }
            string __tmp17_line = "("; //1197:57
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Write(__tmp17_line);
                __tmp14_outputWritten = true;
            }
            var __tmp18 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp18.Write(Properties.CoreNs);
            var __tmp18Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp18.ToStringAndFree());
            bool __tmp18_last = __tmp18Reader.EndOfStream;
            while(!__tmp18_last)
            {
                ReadOnlySpan<char> __tmp18_line = __tmp18Reader.ReadLine();
                __tmp18_last = __tmp18Reader.EndOfStream;
                if (!__tmp18_last || !__tmp18_line.IsEmpty)
                {
                    __out.Write(__tmp18_line);
                    __tmp14_outputWritten = true;
                }
                if (!__tmp18_last) __out.AppendLine(true);
            }
            string __tmp19_line = ".ObjectId id, "; //1197:77
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Write(__tmp19_line);
                __tmp14_outputWritten = true;
            }
            var __tmp20 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp20.Write(Properties.CoreNs);
            var __tmp20Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp20.ToStringAndFree());
            bool __tmp20_last = __tmp20Reader.EndOfStream;
            while(!__tmp20_last)
            {
                ReadOnlySpan<char> __tmp20_line = __tmp20Reader.ReadLine();
                __tmp20_last = __tmp20Reader.EndOfStream;
                if (!__tmp20_last || !__tmp20_line.IsEmpty)
                {
                    __out.Write(__tmp20_line);
                    __tmp14_outputWritten = true;
                }
                if (!__tmp20_last) __out.AppendLine(true);
            }
            string __tmp21_line = ".MutableModel model, bool creating)"; //1197:110
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp14_outputWritten = true;
            }
            if (__tmp14_outputWritten) __out.AppendLine(true);
            if (__tmp14_outputWritten)
            {
                __out.AppendLine(false); //1197:145
            }
            __out.Write("		: base(id, model, creating)"); //1198:1
            __out.AppendLine(false); //1198:30
            __out.Write("	{"); //1199:1
            __out.AppendLine(false); //1199:3
            __out.Write("	}"); //1200:1
            __out.AppendLine(false); //1200:3
            __out.AppendLine(true); //1201:2
            __out.Write("	protected override void MInit()"); //1202:1
            __out.AppendLine(false); //1202:33
            __out.Write("	{"); //1203:1
            __out.AppendLine(false); //1203:3
            bool __tmp23_outputWritten = false;
            string __tmp22Prefix = "		"; //1204:1
            var __tmp24 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp24.Write(CSharpName(model, ModelKind.ImplementationProvider));
            var __tmp24Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp24.ToStringAndFree());
            bool __tmp24_last = __tmp24Reader.EndOfStream;
            while(!__tmp24_last)
            {
                ReadOnlySpan<char> __tmp24_line = __tmp24Reader.ReadLine();
                __tmp24_last = __tmp24Reader.EndOfStream;
                if (!string.IsNullOrEmpty(__tmp22Prefix))
                {
                    __out.Write(__tmp22Prefix);
                    __tmp23_outputWritten = true;
                }
                if (!__tmp24_last || !__tmp24_line.IsEmpty)
                {
                    __out.Write(__tmp24_line);
                    __tmp23_outputWritten = true;
                }
                if (!__tmp24_last) __out.AppendLine(true);
            }
            string __tmp25_line = ".Implementation."; //1204:55
            if (!string.IsNullOrEmpty(__tmp25_line))
            {
                __out.Write(__tmp25_line);
                __tmp23_outputWritten = true;
            }
            var __tmp26 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp26.Write(CSharpName(cls, model, ClassKind.Immutable));
            var __tmp26Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp26.ToStringAndFree());
            bool __tmp26_last = __tmp26Reader.EndOfStream;
            while(!__tmp26_last)
            {
                ReadOnlySpan<char> __tmp26_line = __tmp26Reader.ReadLine();
                __tmp26_last = __tmp26Reader.EndOfStream;
                if (!__tmp26_last || !__tmp26_line.IsEmpty)
                {
                    __out.Write(__tmp26_line);
                    __tmp23_outputWritten = true;
                }
                if (!__tmp26_last) __out.AppendLine(true);
            }
            string __tmp27_line = "(this);"; //1204:115
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Write(__tmp27_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //1204:122
            }
            __out.Write("	}"); //1205:1
            __out.AppendLine(false); //1205:3
            __out.AppendLine(true); //1206:2
            bool __tmp29_outputWritten = false;
            string __tmp30_line = "	public override "; //1207:1
            if (!string.IsNullOrEmpty(__tmp30_line))
            {
                __out.Write(__tmp30_line);
                __tmp29_outputWritten = true;
            }
            var __tmp31 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp31.Write(Properties.CoreNs);
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
            string __tmp32_line = ".ModelMetadata MMetadata => "; //1207:37
            if (!string.IsNullOrEmpty(__tmp32_line))
            {
                __out.Write(__tmp32_line);
                __tmp29_outputWritten = true;
            }
            var __tmp33 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp33.Write(CSharpName(model, ModelKind.ImmutableInstance, true));
            var __tmp33Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp33.ToStringAndFree());
            bool __tmp33_last = __tmp33Reader.EndOfStream;
            while(!__tmp33_last)
            {
                ReadOnlySpan<char> __tmp33_line = __tmp33Reader.ReadLine();
                __tmp33_last = __tmp33Reader.EndOfStream;
                if (!__tmp33_last || !__tmp33_line.IsEmpty)
                {
                    __out.Write(__tmp33_line);
                    __tmp29_outputWritten = true;
                }
                if (!__tmp33_last) __out.AppendLine(true);
            }
            string __tmp34_line = ".MMetadata;"; //1207:118
            if (!string.IsNullOrEmpty(__tmp34_line))
            {
                __out.Write(__tmp34_line);
                __tmp29_outputWritten = true;
            }
            if (__tmp29_outputWritten) __out.AppendLine(true);
            if (__tmp29_outputWritten)
            {
                __out.AppendLine(false); //1207:129
            }
            __out.AppendLine(true); //1208:2
            bool __tmp36_outputWritten = false;
            string __tmp37_line = "	public override "; //1209:1
            if (!string.IsNullOrEmpty(__tmp37_line))
            {
                __out.Write(__tmp37_line);
                __tmp36_outputWritten = true;
            }
            var __tmp38 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp38.Write(metaNs);
            var __tmp38Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp38.ToStringAndFree());
            bool __tmp38_last = __tmp38Reader.EndOfStream;
            while(!__tmp38_last)
            {
                ReadOnlySpan<char> __tmp38_line = __tmp38Reader.ReadLine();
                __tmp38_last = __tmp38Reader.EndOfStream;
                if (!__tmp38_last || !__tmp38_line.IsEmpty)
                {
                    __out.Write(__tmp38_line);
                    __tmp36_outputWritten = true;
                }
                if (!__tmp38_last) __out.AppendLine(true);
            }
            string __tmp39_line = "MetaClass MMetaClass => "; //1209:26
            if (!string.IsNullOrEmpty(__tmp39_line))
            {
                __out.Write(__tmp39_line);
                __tmp36_outputWritten = true;
            }
            var __tmp40 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp40.Write(CSharpName(cls, model, ClassKind.ImmutableInstance, true));
            var __tmp40Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp40.ToStringAndFree());
            bool __tmp40_last = __tmp40Reader.EndOfStream;
            while(!__tmp40_last)
            {
                ReadOnlySpan<char> __tmp40_line = __tmp40Reader.ReadLine();
                __tmp40_last = __tmp40Reader.EndOfStream;
                if (!__tmp40_last || !__tmp40_line.IsEmpty)
                {
                    __out.Write(__tmp40_line);
                    __tmp36_outputWritten = true;
                }
                if (!__tmp40_last) __out.AppendLine(true);
            }
            string __tmp41_line = ";"; //1209:108
            if (!string.IsNullOrEmpty(__tmp41_line))
            {
                __out.Write(__tmp41_line);
                __tmp36_outputWritten = true;
            }
            if (__tmp36_outputWritten) __out.AppendLine(true);
            if (__tmp36_outputWritten)
            {
                __out.AppendLine(false); //1209:109
            }
            __out.AppendLine(true); //1210:2
            bool __tmp43_outputWritten = false;
            string __tmp44_line = "	public new "; //1211:1
            if (!string.IsNullOrEmpty(__tmp44_line))
            {
                __out.Write(__tmp44_line);
                __tmp43_outputWritten = true;
            }
            var __tmp45 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp45.Write(CSharpName(cls, model, ClassKind.Immutable));
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
            string __tmp46_line = " ToImmutable()"; //1211:57
            if (!string.IsNullOrEmpty(__tmp46_line))
            {
                __out.Write(__tmp46_line);
                __tmp43_outputWritten = true;
            }
            if (__tmp43_outputWritten) __out.AppendLine(true);
            if (__tmp43_outputWritten)
            {
                __out.AppendLine(false); //1211:71
            }
            __out.Write("	{"); //1212:1
            __out.AppendLine(false); //1212:3
            bool __tmp48_outputWritten = false;
            string __tmp49_line = "		return ("; //1213:1
            if (!string.IsNullOrEmpty(__tmp49_line))
            {
                __out.Write(__tmp49_line);
                __tmp48_outputWritten = true;
            }
            var __tmp50 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp50.Write(CSharpName(cls, model, ClassKind.Immutable));
            var __tmp50Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp50.ToStringAndFree());
            bool __tmp50_last = __tmp50Reader.EndOfStream;
            while(!__tmp50_last)
            {
                ReadOnlySpan<char> __tmp50_line = __tmp50Reader.ReadLine();
                __tmp50_last = __tmp50Reader.EndOfStream;
                if (!__tmp50_last || !__tmp50_line.IsEmpty)
                {
                    __out.Write(__tmp50_line);
                    __tmp48_outputWritten = true;
                }
                if (!__tmp50_last) __out.AppendLine(true);
            }
            string __tmp51_line = ")base.ToImmutable();"; //1213:55
            if (!string.IsNullOrEmpty(__tmp51_line))
            {
                __out.Write(__tmp51_line);
                __tmp48_outputWritten = true;
            }
            if (__tmp48_outputWritten) __out.AppendLine(true);
            if (__tmp48_outputWritten)
            {
                __out.AppendLine(false); //1213:75
            }
            __out.Write("	}"); //1214:1
            __out.AppendLine(false); //1214:3
            __out.AppendLine(true); //1215:2
            bool __tmp53_outputWritten = false;
            string __tmp54_line = "	public new "; //1216:1
            if (!string.IsNullOrEmpty(__tmp54_line))
            {
                __out.Write(__tmp54_line);
                __tmp53_outputWritten = true;
            }
            var __tmp55 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp55.Write(CSharpName(cls, model, ClassKind.Immutable));
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
            string __tmp56_line = " ToImmutable("; //1216:57
            if (!string.IsNullOrEmpty(__tmp56_line))
            {
                __out.Write(__tmp56_line);
                __tmp53_outputWritten = true;
            }
            var __tmp57 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp57.Write(Properties.CoreNs);
            var __tmp57Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp57.ToStringAndFree());
            bool __tmp57_last = __tmp57Reader.EndOfStream;
            while(!__tmp57_last)
            {
                ReadOnlySpan<char> __tmp57_line = __tmp57Reader.ReadLine();
                __tmp57_last = __tmp57Reader.EndOfStream;
                if (!__tmp57_last || !__tmp57_line.IsEmpty)
                {
                    __out.Write(__tmp57_line);
                    __tmp53_outputWritten = true;
                }
                if (!__tmp57_last) __out.AppendLine(true);
            }
            string __tmp58_line = ".ImmutableModel model)"; //1216:89
            if (!string.IsNullOrEmpty(__tmp58_line))
            {
                __out.Write(__tmp58_line);
                __tmp53_outputWritten = true;
            }
            if (__tmp53_outputWritten) __out.AppendLine(true);
            if (__tmp53_outputWritten)
            {
                __out.AppendLine(false); //1216:111
            }
            __out.Write("	{"); //1217:1
            __out.AppendLine(false); //1217:3
            bool __tmp60_outputWritten = false;
            string __tmp61_line = "		return ("; //1218:1
            if (!string.IsNullOrEmpty(__tmp61_line))
            {
                __out.Write(__tmp61_line);
                __tmp60_outputWritten = true;
            }
            var __tmp62 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp62.Write(CSharpName(cls, model, ClassKind.Immutable));
            var __tmp62Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp62.ToStringAndFree());
            bool __tmp62_last = __tmp62Reader.EndOfStream;
            while(!__tmp62_last)
            {
                ReadOnlySpan<char> __tmp62_line = __tmp62Reader.ReadLine();
                __tmp62_last = __tmp62Reader.EndOfStream;
                if (!__tmp62_last || !__tmp62_line.IsEmpty)
                {
                    __out.Write(__tmp62_line);
                    __tmp60_outputWritten = true;
                }
                if (!__tmp62_last) __out.AppendLine(true);
            }
            string __tmp63_line = ")base.ToImmutable(model);"; //1218:55
            if (!string.IsNullOrEmpty(__tmp63_line))
            {
                __out.Write(__tmp63_line);
                __tmp60_outputWritten = true;
            }
            if (__tmp60_outputWritten) __out.AppendLine(true);
            if (__tmp60_outputWritten)
            {
                __out.AppendLine(false); //1218:80
            }
            __out.Write("	}"); //1219:1
            __out.AppendLine(false); //1219:3
            var __loop74_results = 
                (from __loop74_var1 in __Enumerate((cls).GetEnumerator()) //1220:8
                from sup in __Enumerate((__loop74_var1.GetAllSuperClasses(false)).GetEnumerator()) //1220:13
                select new { __loop74_var1 = __loop74_var1, sup = sup}
                ).ToList(); //1220:3
            for (int __loop74_iteration = 0; __loop74_iteration < __loop74_results.Count; ++__loop74_iteration)
            {
                var __tmp64 = __loop74_results[__loop74_iteration];
                var __loop74_var1 = __tmp64.__loop74_var1;
                var sup = __tmp64.sup;
                __out.AppendLine(true); //1221:2
                bool __tmp66_outputWritten = false;
                string __tmp65Prefix = "	"; //1222:1
                var __tmp67 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp67.Write(CSharpName(sup, model, ClassKind.Immutable, true));
                var __tmp67Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp67.ToStringAndFree());
                bool __tmp67_last = __tmp67Reader.EndOfStream;
                while(!__tmp67_last)
                {
                    ReadOnlySpan<char> __tmp67_line = __tmp67Reader.ReadLine();
                    __tmp67_last = __tmp67Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp65Prefix))
                    {
                        __out.Write(__tmp65Prefix);
                        __tmp66_outputWritten = true;
                    }
                    if (!__tmp67_last || !__tmp67_line.IsEmpty)
                    {
                        __out.Write(__tmp67_line);
                        __tmp66_outputWritten = true;
                    }
                    if (!__tmp67_last) __out.AppendLine(true);
                }
                string __tmp68_line = " "; //1222:52
                if (!string.IsNullOrEmpty(__tmp68_line))
                {
                    __out.Write(__tmp68_line);
                    __tmp66_outputWritten = true;
                }
                var __tmp69 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp69.Write(CSharpName(sup, model, ClassKind.Builder, true));
                var __tmp69Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp69.ToStringAndFree());
                bool __tmp69_last = __tmp69Reader.EndOfStream;
                while(!__tmp69_last)
                {
                    ReadOnlySpan<char> __tmp69_line = __tmp69Reader.ReadLine();
                    __tmp69_last = __tmp69Reader.EndOfStream;
                    if (!__tmp69_last || !__tmp69_line.IsEmpty)
                    {
                        __out.Write(__tmp69_line);
                        __tmp66_outputWritten = true;
                    }
                    if (!__tmp69_last) __out.AppendLine(true);
                }
                string __tmp70_line = ".ToImmutable()"; //1222:101
                if (!string.IsNullOrEmpty(__tmp70_line))
                {
                    __out.Write(__tmp70_line);
                    __tmp66_outputWritten = true;
                }
                if (__tmp66_outputWritten) __out.AppendLine(true);
                if (__tmp66_outputWritten)
                {
                    __out.AppendLine(false); //1222:115
                }
                __out.Write("	{"); //1223:1
                __out.AppendLine(false); //1223:3
                __out.Write("		return this.ToImmutable();"); //1224:1
                __out.AppendLine(false); //1224:29
                __out.Write("	}"); //1225:1
                __out.AppendLine(false); //1225:3
                __out.AppendLine(true); //1226:2
                bool __tmp72_outputWritten = false;
                string __tmp71Prefix = "	"; //1227:1
                var __tmp73 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp73.Write(CSharpName(sup, model, ClassKind.Immutable, true));
                var __tmp73Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp73.ToStringAndFree());
                bool __tmp73_last = __tmp73Reader.EndOfStream;
                while(!__tmp73_last)
                {
                    ReadOnlySpan<char> __tmp73_line = __tmp73Reader.ReadLine();
                    __tmp73_last = __tmp73Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp71Prefix))
                    {
                        __out.Write(__tmp71Prefix);
                        __tmp72_outputWritten = true;
                    }
                    if (!__tmp73_last || !__tmp73_line.IsEmpty)
                    {
                        __out.Write(__tmp73_line);
                        __tmp72_outputWritten = true;
                    }
                    if (!__tmp73_last) __out.AppendLine(true);
                }
                string __tmp74_line = " "; //1227:52
                if (!string.IsNullOrEmpty(__tmp74_line))
                {
                    __out.Write(__tmp74_line);
                    __tmp72_outputWritten = true;
                }
                var __tmp75 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp75.Write(CSharpName(sup, model, ClassKind.Builder, true));
                var __tmp75Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp75.ToStringAndFree());
                bool __tmp75_last = __tmp75Reader.EndOfStream;
                while(!__tmp75_last)
                {
                    ReadOnlySpan<char> __tmp75_line = __tmp75Reader.ReadLine();
                    __tmp75_last = __tmp75Reader.EndOfStream;
                    if (!__tmp75_last || !__tmp75_line.IsEmpty)
                    {
                        __out.Write(__tmp75_line);
                        __tmp72_outputWritten = true;
                    }
                    if (!__tmp75_last) __out.AppendLine(true);
                }
                string __tmp76_line = ".ToImmutable("; //1227:101
                if (!string.IsNullOrEmpty(__tmp76_line))
                {
                    __out.Write(__tmp76_line);
                    __tmp72_outputWritten = true;
                }
                var __tmp77 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp77.Write(Properties.CoreNs);
                var __tmp77Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp77.ToStringAndFree());
                bool __tmp77_last = __tmp77Reader.EndOfStream;
                while(!__tmp77_last)
                {
                    ReadOnlySpan<char> __tmp77_line = __tmp77Reader.ReadLine();
                    __tmp77_last = __tmp77Reader.EndOfStream;
                    if (!__tmp77_last || !__tmp77_line.IsEmpty)
                    {
                        __out.Write(__tmp77_line);
                        __tmp72_outputWritten = true;
                    }
                    if (!__tmp77_last) __out.AppendLine(true);
                }
                string __tmp78_line = ".ImmutableModel model)"; //1227:133
                if (!string.IsNullOrEmpty(__tmp78_line))
                {
                    __out.Write(__tmp78_line);
                    __tmp72_outputWritten = true;
                }
                if (__tmp72_outputWritten) __out.AppendLine(true);
                if (__tmp72_outputWritten)
                {
                    __out.AppendLine(false); //1227:155
                }
                __out.Write("	{"); //1228:1
                __out.AppendLine(false); //1228:3
                __out.Write("		return this.ToImmutable(model);"); //1229:1
                __out.AppendLine(false); //1229:34
                __out.Write("	}"); //1230:1
                __out.AppendLine(false); //1230:3
            }
            var __loop75_results = 
                (from __loop75_var1 in __Enumerate((cls).GetEnumerator()) //1232:8
                from prop in __Enumerate((__loop75_var1.GetAllProperties()).GetEnumerator()) //1232:13
                select new { __loop75_var1 = __loop75_var1, prop = prop}
                ).ToList(); //1232:3
            for (int __loop75_iteration = 0; __loop75_iteration < __loop75_results.Count; ++__loop75_iteration)
            {
                var __tmp79 = __loop75_results[__loop75_iteration];
                var __loop75_var1 = __tmp79.__loop75_var1;
                var prop = __tmp79.prop;
                __out.AppendLine(true); //1233:2
                bool __tmp81_outputWritten = false;
                string __tmp80Prefix = "	"; //1234:1
                var __tmp82 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp82.Write(GenerateBuilderPropertyImpl(model, cls, prop));
                var __tmp82Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp82.ToStringAndFree());
                bool __tmp82_last = __tmp82Reader.EndOfStream;
                while(!__tmp82_last)
                {
                    ReadOnlySpan<char> __tmp82_line = __tmp82Reader.ReadLine();
                    __tmp82_last = __tmp82Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp80Prefix))
                    {
                        __out.Write(__tmp80Prefix);
                        __tmp81_outputWritten = true;
                    }
                    if (!__tmp82_last || !__tmp82_line.IsEmpty)
                    {
                        __out.Write(__tmp82_line);
                        __tmp81_outputWritten = true;
                    }
                    if (!__tmp82_last || __tmp81_outputWritten) __out.AppendLine(true);
                }
                if (__tmp81_outputWritten)
                {
                    __out.AppendLine(false); //1234:49
                }
            }
            var __loop76_results = 
                (from __loop76_var1 in __Enumerate((cls).GetEnumerator()) //1236:8
                from op in __Enumerate((__loop76_var1.GetAllOperations()).GetEnumerator()) //1236:13
                select new { __loop76_var1 = __loop76_var1, op = op}
                ).ToList(); //1236:3
            for (int __loop76_iteration = 0; __loop76_iteration < __loop76_results.Count; ++__loop76_iteration)
            {
                var __tmp83 = __loop76_results[__loop76_iteration];
                var __loop76_var1 = __tmp83.__loop76_var1;
                var op = __tmp83.op;
                __out.AppendLine(true); //1237:2
                bool __tmp85_outputWritten = false;
                string __tmp84Prefix = "	"; //1238:1
                var __tmp86 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp86.Write(GenerateBuilderOperationImpl(model, cls, op));
                var __tmp86Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp86.ToStringAndFree());
                bool __tmp86_last = __tmp86Reader.EndOfStream;
                while(!__tmp86_last)
                {
                    ReadOnlySpan<char> __tmp86_line = __tmp86Reader.ReadLine();
                    __tmp86_last = __tmp86Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp84Prefix))
                    {
                        __out.Write(__tmp84Prefix);
                        __tmp85_outputWritten = true;
                    }
                    if (!__tmp86_last || !__tmp86_line.IsEmpty)
                    {
                        __out.Write(__tmp86_line);
                        __tmp85_outputWritten = true;
                    }
                    if (!__tmp86_last || __tmp85_outputWritten) __out.AppendLine(true);
                }
                if (__tmp85_outputWritten)
                {
                    __out.AppendLine(false); //1238:48
                }
            }
            if (metaMetaModel && cls.Name == "MetaModel") //1240:3
            {
                __out.AppendLine(true); //1241:1
                bool __tmp88_outputWritten = false;
                string __tmp87Prefix = "	"; //1242:1
                var __tmp89 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp89.Write(Properties.CoreNs);
                var __tmp89Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp89.ToStringAndFree());
                bool __tmp89_last = __tmp89Reader.EndOfStream;
                while(!__tmp89_last)
                {
                    ReadOnlySpan<char> __tmp89_line = __tmp89Reader.ReadLine();
                    __tmp89_last = __tmp89Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp87Prefix))
                    {
                        __out.Write(__tmp87Prefix);
                        __tmp88_outputWritten = true;
                    }
                    if (!__tmp89_last || !__tmp89_line.IsEmpty)
                    {
                        __out.Write(__tmp89_line);
                        __tmp88_outputWritten = true;
                    }
                    if (!__tmp89_last) __out.AppendLine(true);
                }
                string __tmp90_line = ".ModelId "; //1242:21
                if (!string.IsNullOrEmpty(__tmp90_line))
                {
                    __out.Write(__tmp90_line);
                    __tmp88_outputWritten = true;
                }
                var __tmp91 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp91.Write(Properties.CoreNs);
                var __tmp91Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp91.ToStringAndFree());
                bool __tmp91_last = __tmp91Reader.EndOfStream;
                while(!__tmp91_last)
                {
                    ReadOnlySpan<char> __tmp91_line = __tmp91Reader.ReadLine();
                    __tmp91_last = __tmp91Reader.EndOfStream;
                    if (!__tmp91_last || !__tmp91_line.IsEmpty)
                    {
                        __out.Write(__tmp91_line);
                        __tmp88_outputWritten = true;
                    }
                    if (!__tmp91_last) __out.AppendLine(true);
                }
                string __tmp92_line = ".IModel.Id => MetaInstance.MModel.Id;"; //1242:49
                if (!string.IsNullOrEmpty(__tmp92_line))
                {
                    __out.Write(__tmp92_line);
                    __tmp88_outputWritten = true;
                }
                if (__tmp88_outputWritten) __out.AppendLine(true);
                if (__tmp88_outputWritten)
                {
                    __out.AppendLine(false); //1242:86
                }
                bool __tmp94_outputWritten = false;
                string __tmp93Prefix = "	"; //1243:1
                var __tmp95 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp95.Write(Properties.CoreNs);
                var __tmp95Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp95.ToStringAndFree());
                bool __tmp95_last = __tmp95Reader.EndOfStream;
                while(!__tmp95_last)
                {
                    ReadOnlySpan<char> __tmp95_line = __tmp95Reader.ReadLine();
                    __tmp95_last = __tmp95Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp93Prefix))
                    {
                        __out.Write(__tmp93Prefix);
                        __tmp94_outputWritten = true;
                    }
                    if (!__tmp95_last || !__tmp95_line.IsEmpty)
                    {
                        __out.Write(__tmp95_line);
                        __tmp94_outputWritten = true;
                    }
                    if (!__tmp95_last) __out.AppendLine(true);
                }
                string __tmp96_line = ".ModelMetadata "; //1243:21
                if (!string.IsNullOrEmpty(__tmp96_line))
                {
                    __out.Write(__tmp96_line);
                    __tmp94_outputWritten = true;
                }
                var __tmp97 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp97.Write(Properties.CoreNs);
                var __tmp97Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp97.ToStringAndFree());
                bool __tmp97_last = __tmp97Reader.EndOfStream;
                while(!__tmp97_last)
                {
                    ReadOnlySpan<char> __tmp97_line = __tmp97Reader.ReadLine();
                    __tmp97_last = __tmp97Reader.EndOfStream;
                    if (!__tmp97_last || !__tmp97_line.IsEmpty)
                    {
                        __out.Write(__tmp97_line);
                        __tmp94_outputWritten = true;
                    }
                    if (!__tmp97_last) __out.AppendLine(true);
                }
                string __tmp98_line = ".IModel.Metadata => "; //1243:55
                if (!string.IsNullOrEmpty(__tmp98_line))
                {
                    __out.Write(__tmp98_line);
                    __tmp94_outputWritten = true;
                }
                var __tmp99 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp99.Write(CSharpName(model, ModelKind.ImmutableInstance));
                var __tmp99Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp99.ToStringAndFree());
                bool __tmp99_last = __tmp99Reader.EndOfStream;
                while(!__tmp99_last)
                {
                    ReadOnlySpan<char> __tmp99_line = __tmp99Reader.ReadLine();
                    __tmp99_last = __tmp99Reader.EndOfStream;
                    if (!__tmp99_last || !__tmp99_line.IsEmpty)
                    {
                        __out.Write(__tmp99_line);
                        __tmp94_outputWritten = true;
                    }
                    if (!__tmp99_last) __out.AppendLine(true);
                }
                string __tmp100_line = ".MModel.Metadata;"; //1243:122
                if (!string.IsNullOrEmpty(__tmp100_line))
                {
                    __out.Write(__tmp100_line);
                    __tmp94_outputWritten = true;
                }
                if (__tmp94_outputWritten) __out.AppendLine(true);
                if (__tmp94_outputWritten)
                {
                    __out.AppendLine(false); //1243:139
                }
                bool __tmp102_outputWritten = false;
                string __tmp103_line = "	global::System.Collections.Generic.IEnumerable<global::MetaDslx.Modeling.IModelObject> "; //1244:1
                if (!string.IsNullOrEmpty(__tmp103_line))
                {
                    __out.Write(__tmp103_line);
                    __tmp102_outputWritten = true;
                }
                var __tmp104 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp104.Write(Properties.CoreNs);
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
                string __tmp105_line = ".IModel.Objects => "; //1244:108
                if (!string.IsNullOrEmpty(__tmp105_line))
                {
                    __out.Write(__tmp105_line);
                    __tmp102_outputWritten = true;
                }
                var __tmp106 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp106.Write(CSharpName(model, ModelKind.ImmutableInstance));
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
                string __tmp107_line = ".MModel.Objects;"; //1244:174
                if (!string.IsNullOrEmpty(__tmp107_line))
                {
                    __out.Write(__tmp107_line);
                    __tmp102_outputWritten = true;
                }
                if (__tmp102_outputWritten) __out.AppendLine(true);
                if (__tmp102_outputWritten)
                {
                    __out.AppendLine(false); //1244:190
                }
                bool __tmp109_outputWritten = false;
                string __tmp108Prefix = "	"; //1245:1
                var __tmp110 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp110.Write(Properties.CoreNs);
                var __tmp110Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp110.ToStringAndFree());
                bool __tmp110_last = __tmp110Reader.EndOfStream;
                while(!__tmp110_last)
                {
                    ReadOnlySpan<char> __tmp110_line = __tmp110Reader.ReadLine();
                    __tmp110_last = __tmp110Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp108Prefix))
                    {
                        __out.Write(__tmp108Prefix);
                        __tmp109_outputWritten = true;
                    }
                    if (!__tmp110_last || !__tmp110_line.IsEmpty)
                    {
                        __out.Write(__tmp110_line);
                        __tmp109_outputWritten = true;
                    }
                    if (!__tmp110_last) __out.AppendLine(true);
                }
                string __tmp111_line = ".IModelGroup "; //1245:21
                if (!string.IsNullOrEmpty(__tmp111_line))
                {
                    __out.Write(__tmp111_line);
                    __tmp109_outputWritten = true;
                }
                var __tmp112 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp112.Write(Properties.CoreNs);
                var __tmp112Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp112.ToStringAndFree());
                bool __tmp112_last = __tmp112Reader.EndOfStream;
                while(!__tmp112_last)
                {
                    ReadOnlySpan<char> __tmp112_line = __tmp112Reader.ReadLine();
                    __tmp112_last = __tmp112Reader.EndOfStream;
                    if (!__tmp112_last || !__tmp112_line.IsEmpty)
                    {
                        __out.Write(__tmp112_line);
                        __tmp109_outputWritten = true;
                    }
                    if (!__tmp112_last) __out.AppendLine(true);
                }
                string __tmp113_line = ".IModel.ModelGroup => "; //1245:53
                if (!string.IsNullOrEmpty(__tmp113_line))
                {
                    __out.Write(__tmp113_line);
                    __tmp109_outputWritten = true;
                }
                var __tmp114 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp114.Write(CSharpName(model, ModelKind.ImmutableInstance));
                var __tmp114Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp114.ToStringAndFree());
                bool __tmp114_last = __tmp114Reader.EndOfStream;
                while(!__tmp114_last)
                {
                    ReadOnlySpan<char> __tmp114_line = __tmp114Reader.ReadLine();
                    __tmp114_last = __tmp114Reader.EndOfStream;
                    if (!__tmp114_last || !__tmp114_line.IsEmpty)
                    {
                        __out.Write(__tmp114_line);
                        __tmp109_outputWritten = true;
                    }
                    if (!__tmp114_last) __out.AppendLine(true);
                }
                string __tmp115_line = ".MModel.ModelGroup;"; //1245:122
                if (!string.IsNullOrEmpty(__tmp115_line))
                {
                    __out.Write(__tmp115_line);
                    __tmp109_outputWritten = true;
                }
                if (__tmp109_outputWritten) __out.AppendLine(true);
                if (__tmp109_outputWritten)
                {
                    __out.AppendLine(false); //1245:141
                }
                __out.AppendLine(true); //1246:1
                bool __tmp117_outputWritten = false;
                string __tmp118_line = "	public "; //1247:1
                if (!string.IsNullOrEmpty(__tmp118_line))
                {
                    __out.Write(__tmp118_line);
                    __tmp117_outputWritten = true;
                }
                var __tmp119 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp119.Write(Properties.CoreNs);
                var __tmp119Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp119.ToStringAndFree());
                bool __tmp119_last = __tmp119Reader.EndOfStream;
                while(!__tmp119_last)
                {
                    ReadOnlySpan<char> __tmp119_line = __tmp119Reader.ReadLine();
                    __tmp119_last = __tmp119Reader.EndOfStream;
                    if (!__tmp119_last || !__tmp119_line.IsEmpty)
                    {
                        __out.Write(__tmp119_line);
                        __tmp117_outputWritten = true;
                    }
                    if (!__tmp119_last) __out.AppendLine(true);
                }
                string __tmp120_line = ".IModelFactory CreateFactory("; //1247:28
                if (!string.IsNullOrEmpty(__tmp120_line))
                {
                    __out.Write(__tmp120_line);
                    __tmp117_outputWritten = true;
                }
                var __tmp121 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp121.Write(Properties.CoreNs);
                var __tmp121Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp121.ToStringAndFree());
                bool __tmp121_last = __tmp121Reader.EndOfStream;
                while(!__tmp121_last)
                {
                    ReadOnlySpan<char> __tmp121_line = __tmp121Reader.ReadLine();
                    __tmp121_last = __tmp121Reader.EndOfStream;
                    if (!__tmp121_last || !__tmp121_line.IsEmpty)
                    {
                        __out.Write(__tmp121_line);
                        __tmp117_outputWritten = true;
                    }
                    if (!__tmp121_last) __out.AppendLine(true);
                }
                string __tmp122_line = ".MutableModel model, "; //1247:76
                if (!string.IsNullOrEmpty(__tmp122_line))
                {
                    __out.Write(__tmp122_line);
                    __tmp117_outputWritten = true;
                }
                var __tmp123 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp123.Write(Properties.CoreNs);
                var __tmp123Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp123.ToStringAndFree());
                bool __tmp123_last = __tmp123Reader.EndOfStream;
                while(!__tmp123_last)
                {
                    ReadOnlySpan<char> __tmp123_line = __tmp123Reader.ReadLine();
                    __tmp123_last = __tmp123Reader.EndOfStream;
                    if (!__tmp123_last || !__tmp123_line.IsEmpty)
                    {
                        __out.Write(__tmp123_line);
                        __tmp117_outputWritten = true;
                    }
                    if (!__tmp123_last) __out.AppendLine(true);
                }
                string __tmp124_line = ".ModelFactoryFlags flags = "; //1247:116
                if (!string.IsNullOrEmpty(__tmp124_line))
                {
                    __out.Write(__tmp124_line);
                    __tmp117_outputWritten = true;
                }
                var __tmp125 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp125.Write(Properties.CoreNs);
                var __tmp125Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp125.ToStringAndFree());
                bool __tmp125_last = __tmp125Reader.EndOfStream;
                while(!__tmp125_last)
                {
                    ReadOnlySpan<char> __tmp125_line = __tmp125Reader.ReadLine();
                    __tmp125_last = __tmp125Reader.EndOfStream;
                    if (!__tmp125_last || !__tmp125_line.IsEmpty)
                    {
                        __out.Write(__tmp125_line);
                        __tmp117_outputWritten = true;
                    }
                    if (!__tmp125_last) __out.AppendLine(true);
                }
                string __tmp126_line = ".ModelFactoryFlags.None)"; //1247:162
                if (!string.IsNullOrEmpty(__tmp126_line))
                {
                    __out.Write(__tmp126_line);
                    __tmp117_outputWritten = true;
                }
                if (__tmp117_outputWritten) __out.AppendLine(true);
                if (__tmp117_outputWritten)
                {
                    __out.AppendLine(false); //1247:186
                }
                __out.Write("	{"); //1248:1
                __out.AppendLine(false); //1248:3
                bool __tmp128_outputWritten = false;
                string __tmp129_line = "		return new "; //1249:1
                if (!string.IsNullOrEmpty(__tmp129_line))
                {
                    __out.Write(__tmp129_line);
                    __tmp128_outputWritten = true;
                }
                var __tmp130 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp130.Write(CSharpName(model, ModelKind.Factory));
                var __tmp130Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp130.ToStringAndFree());
                bool __tmp130_last = __tmp130Reader.EndOfStream;
                while(!__tmp130_last)
                {
                    ReadOnlySpan<char> __tmp130_line = __tmp130Reader.ReadLine();
                    __tmp130_last = __tmp130Reader.EndOfStream;
                    if (!__tmp130_last || !__tmp130_line.IsEmpty)
                    {
                        __out.Write(__tmp130_line);
                        __tmp128_outputWritten = true;
                    }
                    if (!__tmp130_last) __out.AppendLine(true);
                }
                string __tmp131_line = "(model, flags);"; //1249:51
                if (!string.IsNullOrEmpty(__tmp131_line))
                {
                    __out.Write(__tmp131_line);
                    __tmp128_outputWritten = true;
                }
                if (__tmp128_outputWritten) __out.AppendLine(true);
                if (__tmp128_outputWritten)
                {
                    __out.AppendLine(false); //1249:66
                }
                __out.Write("	}"); //1250:1
                __out.AppendLine(false); //1250:3
            }
            __out.Write("}"); //1252:1
            __out.AppendLine(false); //1252:2
            return __out.ToStringAndFree();
        }

        public string GenerateBuilderField(MetaModel model, MetaClass cls, MetaProperty prop) //1255:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "private "; //1256:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Write(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp4.Write(CSharpName(prop.Type, model, ClassKind.Builder, true));
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
            string __tmp5_line = " "; //1256:63
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp6.Write(GetFieldName(prop, cls));
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
            string __tmp7_line = ";"; //1256:88
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //1256:89
            }
            return __out.ToStringAndFree();
        }

        public string GenerateBuilderPropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //1259:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.AppendLine(true); //1260:1
            if (cls.GetAllFinalProperties().Contains(prop)) //1261:2
            {
                bool __tmp2_outputWritten = false;
                string __tmp3_line = "public "; //1262:1
                if (!string.IsNullOrEmpty(__tmp3_line))
                {
                    __out.Write(__tmp3_line);
                    __tmp2_outputWritten = true;
                }
                var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp4.Write(CSharpName(prop.Type, model, ClassKind.Builder, true));
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
                string __tmp5_line = " "; //1262:62
                if (!string.IsNullOrEmpty(__tmp5_line))
                {
                    __out.Write(__tmp5_line);
                    __tmp2_outputWritten = true;
                }
                var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp6.Write(prop.Name);
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
                    if (!__tmp6_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
                if (__tmp2_outputWritten)
                {
                    __out.AppendLine(false); //1262:74
                }
            }
            else //1263:2
            {
                bool __tmp8_outputWritten = false;
                var __tmp9 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp9.Write("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
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
                    __out.AppendLine(false); //1264:54
                }
                bool __tmp11_outputWritten = false;
                var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp12.Write(CSharpName(prop.Type, model, ClassKind.Builder, true));
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
                    if (!__tmp12_last) __out.AppendLine(true);
                }
                string __tmp13_line = " "; //1265:55
                if (!string.IsNullOrEmpty(__tmp13_line))
                {
                    __out.Write(__tmp13_line);
                    __tmp11_outputWritten = true;
                }
                var __tmp14 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp14.Write(CSharpName(prop.Class, model, ClassKind.Builder, true));
                var __tmp14Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp14.ToStringAndFree());
                bool __tmp14_last = __tmp14Reader.EndOfStream;
                while(!__tmp14_last)
                {
                    ReadOnlySpan<char> __tmp14_line = __tmp14Reader.ReadLine();
                    __tmp14_last = __tmp14Reader.EndOfStream;
                    if (!__tmp14_last || !__tmp14_line.IsEmpty)
                    {
                        __out.Write(__tmp14_line);
                        __tmp11_outputWritten = true;
                    }
                    if (!__tmp14_last) __out.AppendLine(true);
                }
                string __tmp15_line = "."; //1265:111
                if (!string.IsNullOrEmpty(__tmp15_line))
                {
                    __out.Write(__tmp15_line);
                    __tmp11_outputWritten = true;
                }
                var __tmp16 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp16.Write(prop.Name);
                var __tmp16Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp16.ToStringAndFree());
                bool __tmp16_last = __tmp16Reader.EndOfStream;
                while(!__tmp16_last)
                {
                    ReadOnlySpan<char> __tmp16_line = __tmp16Reader.ReadLine();
                    __tmp16_last = __tmp16Reader.EndOfStream;
                    if (!__tmp16_last || !__tmp16_line.IsEmpty)
                    {
                        __out.Write(__tmp16_line);
                        __tmp11_outputWritten = true;
                    }
                    if (!__tmp16_last || __tmp11_outputWritten) __out.AppendLine(true);
                }
                if (__tmp11_outputWritten)
                {
                    __out.AppendLine(false); //1265:123
                }
            }
            __out.Write("{"); //1267:1
            __out.AppendLine(false); //1267:2
            if (prop.Type is MetaCollectionType) //1268:3
            {
                if (((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.Set || ((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiSet) //1269:4
                {
                    bool __tmp18_outputWritten = false;
                    string __tmp19_line = "	get { return this.GetSet<"; //1270:1
                    if (!string.IsNullOrEmpty(__tmp19_line))
                    {
                        __out.Write(__tmp19_line);
                        __tmp18_outputWritten = true;
                    }
                    var __tmp20 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp20.Write(CSharpName(((MetaCollectionType)prop.Type).InnerType, model, ClassKind.Builder, true));
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
                    string __tmp21_line = ">("; //1270:113
                    if (!string.IsNullOrEmpty(__tmp21_line))
                    {
                        __out.Write(__tmp21_line);
                        __tmp18_outputWritten = true;
                    }
                    var __tmp22 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp22.Write(CSharpName(prop, null, PropertyKind.Descriptor, true));
                    var __tmp22Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp22.ToStringAndFree());
                    bool __tmp22_last = __tmp22Reader.EndOfStream;
                    while(!__tmp22_last)
                    {
                        ReadOnlySpan<char> __tmp22_line = __tmp22Reader.ReadLine();
                        __tmp22_last = __tmp22Reader.EndOfStream;
                        if (!__tmp22_last || !__tmp22_line.IsEmpty)
                        {
                            __out.Write(__tmp22_line);
                            __tmp18_outputWritten = true;
                        }
                        if (!__tmp22_last) __out.AppendLine(true);
                    }
                    string __tmp23_line = ", ref "; //1270:169
                    if (!string.IsNullOrEmpty(__tmp23_line))
                    {
                        __out.Write(__tmp23_line);
                        __tmp18_outputWritten = true;
                    }
                    var __tmp24 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp24.Write(GetFieldName(prop, cls));
                    var __tmp24Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp24.ToStringAndFree());
                    bool __tmp24_last = __tmp24Reader.EndOfStream;
                    while(!__tmp24_last)
                    {
                        ReadOnlySpan<char> __tmp24_line = __tmp24Reader.ReadLine();
                        __tmp24_last = __tmp24Reader.EndOfStream;
                        if (!__tmp24_last || !__tmp24_line.IsEmpty)
                        {
                            __out.Write(__tmp24_line);
                            __tmp18_outputWritten = true;
                        }
                        if (!__tmp24_last) __out.AppendLine(true);
                    }
                    string __tmp25_line = "); }"; //1270:199
                    if (!string.IsNullOrEmpty(__tmp25_line))
                    {
                        __out.Write(__tmp25_line);
                        __tmp18_outputWritten = true;
                    }
                    if (__tmp18_outputWritten) __out.AppendLine(true);
                    if (__tmp18_outputWritten)
                    {
                        __out.AppendLine(false); //1270:203
                    }
                }
                else //1271:4
                {
                    bool __tmp27_outputWritten = false;
                    string __tmp28_line = "	get { return this.GetList<"; //1272:1
                    if (!string.IsNullOrEmpty(__tmp28_line))
                    {
                        __out.Write(__tmp28_line);
                        __tmp27_outputWritten = true;
                    }
                    var __tmp29 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp29.Write(CSharpName(((MetaCollectionType)prop.Type).InnerType, model, ClassKind.Builder, true));
                    var __tmp29Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp29.ToStringAndFree());
                    bool __tmp29_last = __tmp29Reader.EndOfStream;
                    while(!__tmp29_last)
                    {
                        ReadOnlySpan<char> __tmp29_line = __tmp29Reader.ReadLine();
                        __tmp29_last = __tmp29Reader.EndOfStream;
                        if (!__tmp29_last || !__tmp29_line.IsEmpty)
                        {
                            __out.Write(__tmp29_line);
                            __tmp27_outputWritten = true;
                        }
                        if (!__tmp29_last) __out.AppendLine(true);
                    }
                    string __tmp30_line = ">("; //1272:114
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Write(__tmp30_line);
                        __tmp27_outputWritten = true;
                    }
                    var __tmp31 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp31.Write(CSharpName(prop, null, PropertyKind.Descriptor, true));
                    var __tmp31Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp31.ToStringAndFree());
                    bool __tmp31_last = __tmp31Reader.EndOfStream;
                    while(!__tmp31_last)
                    {
                        ReadOnlySpan<char> __tmp31_line = __tmp31Reader.ReadLine();
                        __tmp31_last = __tmp31Reader.EndOfStream;
                        if (!__tmp31_last || !__tmp31_line.IsEmpty)
                        {
                            __out.Write(__tmp31_line);
                            __tmp27_outputWritten = true;
                        }
                        if (!__tmp31_last) __out.AppendLine(true);
                    }
                    string __tmp32_line = ", ref "; //1272:170
                    if (!string.IsNullOrEmpty(__tmp32_line))
                    {
                        __out.Write(__tmp32_line);
                        __tmp27_outputWritten = true;
                    }
                    var __tmp33 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp33.Write(GetFieldName(prop, cls));
                    var __tmp33Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp33.ToStringAndFree());
                    bool __tmp33_last = __tmp33Reader.EndOfStream;
                    while(!__tmp33_last)
                    {
                        ReadOnlySpan<char> __tmp33_line = __tmp33Reader.ReadLine();
                        __tmp33_last = __tmp33Reader.EndOfStream;
                        if (!__tmp33_last || !__tmp33_line.IsEmpty)
                        {
                            __out.Write(__tmp33_line);
                            __tmp27_outputWritten = true;
                        }
                        if (!__tmp33_last) __out.AppendLine(true);
                    }
                    string __tmp34_line = "); }"; //1272:200
                    if (!string.IsNullOrEmpty(__tmp34_line))
                    {
                        __out.Write(__tmp34_line);
                        __tmp27_outputWritten = true;
                    }
                    if (__tmp27_outputWritten) __out.AppendLine(true);
                    if (__tmp27_outputWritten)
                    {
                        __out.AppendLine(false); //1272:204
                    }
                }
            }
            else if (IsReferenceType(prop.Type)) //1274:3
            {
                bool __tmp36_outputWritten = false;
                string __tmp37_line = "	get { return this.GetReference<"; //1275:1
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Write(__tmp37_line);
                    __tmp36_outputWritten = true;
                }
                var __tmp38 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp38.Write(CSharpName(prop.Type, model, ClassKind.Builder, true));
                var __tmp38Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp38.ToStringAndFree());
                bool __tmp38_last = __tmp38Reader.EndOfStream;
                while(!__tmp38_last)
                {
                    ReadOnlySpan<char> __tmp38_line = __tmp38Reader.ReadLine();
                    __tmp38_last = __tmp38Reader.EndOfStream;
                    if (!__tmp38_last || !__tmp38_line.IsEmpty)
                    {
                        __out.Write(__tmp38_line);
                        __tmp36_outputWritten = true;
                    }
                    if (!__tmp38_last) __out.AppendLine(true);
                }
                string __tmp39_line = ">("; //1275:87
                if (!string.IsNullOrEmpty(__tmp39_line))
                {
                    __out.Write(__tmp39_line);
                    __tmp36_outputWritten = true;
                }
                var __tmp40 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp40.Write(CSharpName(prop, null, PropertyKind.Descriptor, true));
                var __tmp40Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp40.ToStringAndFree());
                bool __tmp40_last = __tmp40Reader.EndOfStream;
                while(!__tmp40_last)
                {
                    ReadOnlySpan<char> __tmp40_line = __tmp40Reader.ReadLine();
                    __tmp40_last = __tmp40Reader.EndOfStream;
                    if (!__tmp40_last || !__tmp40_line.IsEmpty)
                    {
                        __out.Write(__tmp40_line);
                        __tmp36_outputWritten = true;
                    }
                    if (!__tmp40_last) __out.AppendLine(true);
                }
                string __tmp41_line = "); }"; //1275:143
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Write(__tmp41_line);
                    __tmp36_outputWritten = true;
                }
                if (__tmp36_outputWritten) __out.AppendLine(true);
                if (__tmp36_outputWritten)
                {
                    __out.AppendLine(false); //1275:147
                }
            }
            else //1276:3
            {
                bool __tmp43_outputWritten = false;
                string __tmp44_line = "	get { return this.GetValue<"; //1277:1
                if (!string.IsNullOrEmpty(__tmp44_line))
                {
                    __out.Write(__tmp44_line);
                    __tmp43_outputWritten = true;
                }
                var __tmp45 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp45.Write(CSharpName(prop.Type, model, ClassKind.Builder, true));
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
                string __tmp46_line = ">("; //1277:83
                if (!string.IsNullOrEmpty(__tmp46_line))
                {
                    __out.Write(__tmp46_line);
                    __tmp43_outputWritten = true;
                }
                var __tmp47 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp47.Write(CSharpName(prop, null, PropertyKind.Descriptor, true));
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
                string __tmp48_line = "); }"; //1277:139
                if (!string.IsNullOrEmpty(__tmp48_line))
                {
                    __out.Write(__tmp48_line);
                    __tmp43_outputWritten = true;
                }
                if (__tmp43_outputWritten) __out.AppendLine(true);
                if (__tmp43_outputWritten)
                {
                    __out.AppendLine(false); //1277:143
                }
            }
            if ((prop.Kind == MetaPropertyKind.Normal) && !(prop.Type is MetaCollectionType)) //1279:3
            {
                if (IsReferenceType(prop.Type)) //1280:4
                {
                    bool __tmp50_outputWritten = false;
                    string __tmp51_line = "	set { this.SetReference<"; //1281:1
                    if (!string.IsNullOrEmpty(__tmp51_line))
                    {
                        __out.Write(__tmp51_line);
                        __tmp50_outputWritten = true;
                    }
                    var __tmp52 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp52.Write(CSharpName(prop.Type, model, ClassKind.Builder, true));
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
                    string __tmp53_line = ">("; //1281:80
                    if (!string.IsNullOrEmpty(__tmp53_line))
                    {
                        __out.Write(__tmp53_line);
                        __tmp50_outputWritten = true;
                    }
                    var __tmp54 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp54.Write(CSharpName(prop, null, PropertyKind.Descriptor, true));
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
                    string __tmp55_line = ", value); }"; //1281:136
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Write(__tmp55_line);
                        __tmp50_outputWritten = true;
                    }
                    if (__tmp50_outputWritten) __out.AppendLine(true);
                    if (__tmp50_outputWritten)
                    {
                        __out.AppendLine(false); //1281:147
                    }
                }
                else //1282:4
                {
                    bool __tmp57_outputWritten = false;
                    string __tmp58_line = "	set { this.SetValue<"; //1283:1
                    if (!string.IsNullOrEmpty(__tmp58_line))
                    {
                        __out.Write(__tmp58_line);
                        __tmp57_outputWritten = true;
                    }
                    var __tmp59 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp59.Write(CSharpName(prop.Type, model, ClassKind.Builder, true));
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
                        if (!__tmp59_last) __out.AppendLine(true);
                    }
                    string __tmp60_line = ">("; //1283:76
                    if (!string.IsNullOrEmpty(__tmp60_line))
                    {
                        __out.Write(__tmp60_line);
                        __tmp57_outputWritten = true;
                    }
                    var __tmp61 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp61.Write(CSharpName(prop, null, PropertyKind.Descriptor, true));
                    var __tmp61Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp61.ToStringAndFree());
                    bool __tmp61_last = __tmp61Reader.EndOfStream;
                    while(!__tmp61_last)
                    {
                        ReadOnlySpan<char> __tmp61_line = __tmp61Reader.ReadLine();
                        __tmp61_last = __tmp61Reader.EndOfStream;
                        if (!__tmp61_last || !__tmp61_line.IsEmpty)
                        {
                            __out.Write(__tmp61_line);
                            __tmp57_outputWritten = true;
                        }
                        if (!__tmp61_last) __out.AppendLine(true);
                    }
                    string __tmp62_line = ", value); }"; //1283:132
                    if (!string.IsNullOrEmpty(__tmp62_line))
                    {
                        __out.Write(__tmp62_line);
                        __tmp57_outputWritten = true;
                    }
                    if (__tmp57_outputWritten) __out.AppendLine(true);
                    if (__tmp57_outputWritten)
                    {
                        __out.AppendLine(false); //1283:143
                    }
                }
            }
            __out.Write("}"); //1286:1
            __out.AppendLine(false); //1286:2
            if (!(prop.Type is MetaCollectionType)) //1287:2
            {
                __out.AppendLine(true); //1288:1
                bool __tmp64_outputWritten = false;
                string __tmp65_line = "void "; //1289:1
                if (!string.IsNullOrEmpty(__tmp65_line))
                {
                    __out.Write(__tmp65_line);
                    __tmp64_outputWritten = true;
                }
                var __tmp66 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp66.Write(CSharpName(prop.Class, model, ClassKind.Builder, true));
                var __tmp66Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp66.ToStringAndFree());
                bool __tmp66_last = __tmp66Reader.EndOfStream;
                while(!__tmp66_last)
                {
                    ReadOnlySpan<char> __tmp66_line = __tmp66Reader.ReadLine();
                    __tmp66_last = __tmp66Reader.EndOfStream;
                    if (!__tmp66_last || !__tmp66_line.IsEmpty)
                    {
                        __out.Write(__tmp66_line);
                        __tmp64_outputWritten = true;
                    }
                    if (!__tmp66_last) __out.AppendLine(true);
                }
                string __tmp67_line = ".Set"; //1289:61
                if (!string.IsNullOrEmpty(__tmp67_line))
                {
                    __out.Write(__tmp67_line);
                    __tmp64_outputWritten = true;
                }
                var __tmp68 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp68.Write(prop.Name);
                var __tmp68Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp68.ToStringAndFree());
                bool __tmp68_last = __tmp68Reader.EndOfStream;
                while(!__tmp68_last)
                {
                    ReadOnlySpan<char> __tmp68_line = __tmp68Reader.ReadLine();
                    __tmp68_last = __tmp68Reader.EndOfStream;
                    if (!__tmp68_last || !__tmp68_line.IsEmpty)
                    {
                        __out.Write(__tmp68_line);
                        __tmp64_outputWritten = true;
                    }
                    if (!__tmp68_last) __out.AppendLine(true);
                }
                string __tmp69_line = "Lazy(global::System.Func<"; //1289:76
                if (!string.IsNullOrEmpty(__tmp69_line))
                {
                    __out.Write(__tmp69_line);
                    __tmp64_outputWritten = true;
                }
                var __tmp70 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp70.Write(CSharpName(prop.Type, model, ClassKind.Builder, true));
                var __tmp70Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp70.ToStringAndFree());
                bool __tmp70_last = __tmp70Reader.EndOfStream;
                while(!__tmp70_last)
                {
                    ReadOnlySpan<char> __tmp70_line = __tmp70Reader.ReadLine();
                    __tmp70_last = __tmp70Reader.EndOfStream;
                    if (!__tmp70_last || !__tmp70_line.IsEmpty)
                    {
                        __out.Write(__tmp70_line);
                        __tmp64_outputWritten = true;
                    }
                    if (!__tmp70_last) __out.AppendLine(true);
                }
                string __tmp71_line = "> lazy)"; //1289:155
                if (!string.IsNullOrEmpty(__tmp71_line))
                {
                    __out.Write(__tmp71_line);
                    __tmp64_outputWritten = true;
                }
                if (__tmp64_outputWritten) __out.AppendLine(true);
                if (__tmp64_outputWritten)
                {
                    __out.AppendLine(false); //1289:162
                }
                __out.Write("{"); //1290:1
                __out.AppendLine(false); //1290:2
                if (IsReferenceType(prop.Type)) //1291:3
                {
                    bool __tmp73_outputWritten = false;
                    string __tmp74_line = "	this.SetLazyReference("; //1292:1
                    if (!string.IsNullOrEmpty(__tmp74_line))
                    {
                        __out.Write(__tmp74_line);
                        __tmp73_outputWritten = true;
                    }
                    var __tmp75 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp75.Write(CSharpName(prop, model, PropertyKind.Descriptor, true));
                    var __tmp75Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp75.ToStringAndFree());
                    bool __tmp75_last = __tmp75Reader.EndOfStream;
                    while(!__tmp75_last)
                    {
                        ReadOnlySpan<char> __tmp75_line = __tmp75Reader.ReadLine();
                        __tmp75_last = __tmp75Reader.EndOfStream;
                        if (!__tmp75_last || !__tmp75_line.IsEmpty)
                        {
                            __out.Write(__tmp75_line);
                            __tmp73_outputWritten = true;
                        }
                        if (!__tmp75_last) __out.AppendLine(true);
                    }
                    string __tmp76_line = ", lazy);"; //1292:79
                    if (!string.IsNullOrEmpty(__tmp76_line))
                    {
                        __out.Write(__tmp76_line);
                        __tmp73_outputWritten = true;
                    }
                    if (__tmp73_outputWritten) __out.AppendLine(true);
                    if (__tmp73_outputWritten)
                    {
                        __out.AppendLine(false); //1292:87
                    }
                }
                else //1293:3
                {
                    bool __tmp78_outputWritten = false;
                    string __tmp79_line = "	this.SetLazyValue("; //1294:1
                    if (!string.IsNullOrEmpty(__tmp79_line))
                    {
                        __out.Write(__tmp79_line);
                        __tmp78_outputWritten = true;
                    }
                    var __tmp80 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp80.Write(CSharpName(prop, model, PropertyKind.Descriptor, true));
                    var __tmp80Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp80.ToStringAndFree());
                    bool __tmp80_last = __tmp80Reader.EndOfStream;
                    while(!__tmp80_last)
                    {
                        ReadOnlySpan<char> __tmp80_line = __tmp80Reader.ReadLine();
                        __tmp80_last = __tmp80Reader.EndOfStream;
                        if (!__tmp80_last || !__tmp80_line.IsEmpty)
                        {
                            __out.Write(__tmp80_line);
                            __tmp78_outputWritten = true;
                        }
                        if (!__tmp80_last) __out.AppendLine(true);
                    }
                    string __tmp81_line = ", lazy);"; //1294:75
                    if (!string.IsNullOrEmpty(__tmp81_line))
                    {
                        __out.Write(__tmp81_line);
                        __tmp78_outputWritten = true;
                    }
                    if (__tmp78_outputWritten) __out.AppendLine(true);
                    if (__tmp78_outputWritten)
                    {
                        __out.AppendLine(false); //1294:83
                    }
                }
                __out.Write("}"); //1296:1
                __out.AppendLine(false); //1296:2
                __out.AppendLine(true); //1297:1
                bool __tmp83_outputWritten = false;
                string __tmp84_line = "void "; //1298:1
                if (!string.IsNullOrEmpty(__tmp84_line))
                {
                    __out.Write(__tmp84_line);
                    __tmp83_outputWritten = true;
                }
                var __tmp85 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp85.Write(CSharpName(prop.Class, model, ClassKind.Builder, true));
                var __tmp85Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp85.ToStringAndFree());
                bool __tmp85_last = __tmp85Reader.EndOfStream;
                while(!__tmp85_last)
                {
                    ReadOnlySpan<char> __tmp85_line = __tmp85Reader.ReadLine();
                    __tmp85_last = __tmp85Reader.EndOfStream;
                    if (!__tmp85_last || !__tmp85_line.IsEmpty)
                    {
                        __out.Write(__tmp85_line);
                        __tmp83_outputWritten = true;
                    }
                    if (!__tmp85_last) __out.AppendLine(true);
                }
                string __tmp86_line = ".Set"; //1298:61
                if (!string.IsNullOrEmpty(__tmp86_line))
                {
                    __out.Write(__tmp86_line);
                    __tmp83_outputWritten = true;
                }
                var __tmp87 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp87.Write(prop.Name);
                var __tmp87Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp87.ToStringAndFree());
                bool __tmp87_last = __tmp87Reader.EndOfStream;
                while(!__tmp87_last)
                {
                    ReadOnlySpan<char> __tmp87_line = __tmp87Reader.ReadLine();
                    __tmp87_last = __tmp87Reader.EndOfStream;
                    if (!__tmp87_last || !__tmp87_line.IsEmpty)
                    {
                        __out.Write(__tmp87_line);
                        __tmp83_outputWritten = true;
                    }
                    if (!__tmp87_last) __out.AppendLine(true);
                }
                string __tmp88_line = "Lazy(global::System.Func<"; //1298:76
                if (!string.IsNullOrEmpty(__tmp88_line))
                {
                    __out.Write(__tmp88_line);
                    __tmp83_outputWritten = true;
                }
                var __tmp89 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp89.Write(CSharpName(prop.Class, model, ClassKind.Builder, true));
                var __tmp89Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp89.ToStringAndFree());
                bool __tmp89_last = __tmp89Reader.EndOfStream;
                while(!__tmp89_last)
                {
                    ReadOnlySpan<char> __tmp89_line = __tmp89Reader.ReadLine();
                    __tmp89_last = __tmp89Reader.EndOfStream;
                    if (!__tmp89_last || !__tmp89_line.IsEmpty)
                    {
                        __out.Write(__tmp89_line);
                        __tmp83_outputWritten = true;
                    }
                    if (!__tmp89_last) __out.AppendLine(true);
                }
                string __tmp90_line = ", "; //1298:156
                if (!string.IsNullOrEmpty(__tmp90_line))
                {
                    __out.Write(__tmp90_line);
                    __tmp83_outputWritten = true;
                }
                var __tmp91 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp91.Write(CSharpName(prop.Type, model, ClassKind.Builder, true));
                var __tmp91Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp91.ToStringAndFree());
                bool __tmp91_last = __tmp91Reader.EndOfStream;
                while(!__tmp91_last)
                {
                    ReadOnlySpan<char> __tmp91_line = __tmp91Reader.ReadLine();
                    __tmp91_last = __tmp91Reader.EndOfStream;
                    if (!__tmp91_last || !__tmp91_line.IsEmpty)
                    {
                        __out.Write(__tmp91_line);
                        __tmp83_outputWritten = true;
                    }
                    if (!__tmp91_last) __out.AppendLine(true);
                }
                string __tmp92_line = "> lazy)"; //1298:212
                if (!string.IsNullOrEmpty(__tmp92_line))
                {
                    __out.Write(__tmp92_line);
                    __tmp83_outputWritten = true;
                }
                if (__tmp83_outputWritten) __out.AppendLine(true);
                if (__tmp83_outputWritten)
                {
                    __out.AppendLine(false); //1298:219
                }
                __out.Write("{"); //1299:1
                __out.AppendLine(false); //1299:2
                if (IsReferenceType(prop.Type)) //1300:3
                {
                    bool __tmp94_outputWritten = false;
                    string __tmp95_line = "	this.SetLazyReference("; //1301:1
                    if (!string.IsNullOrEmpty(__tmp95_line))
                    {
                        __out.Write(__tmp95_line);
                        __tmp94_outputWritten = true;
                    }
                    var __tmp96 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp96.Write(CSharpName(prop, model, PropertyKind.Descriptor, true));
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
                    string __tmp97_line = ", lazy);"; //1301:79
                    if (!string.IsNullOrEmpty(__tmp97_line))
                    {
                        __out.Write(__tmp97_line);
                        __tmp94_outputWritten = true;
                    }
                    if (__tmp94_outputWritten) __out.AppendLine(true);
                    if (__tmp94_outputWritten)
                    {
                        __out.AppendLine(false); //1301:87
                    }
                }
                else //1302:3
                {
                    bool __tmp99_outputWritten = false;
                    string __tmp100_line = "	this.SetLazyValue("; //1303:1
                    if (!string.IsNullOrEmpty(__tmp100_line))
                    {
                        __out.Write(__tmp100_line);
                        __tmp99_outputWritten = true;
                    }
                    var __tmp101 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp101.Write(CSharpName(prop, model, PropertyKind.Descriptor, true));
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
                    string __tmp102_line = ", lazy);"; //1303:75
                    if (!string.IsNullOrEmpty(__tmp102_line))
                    {
                        __out.Write(__tmp102_line);
                        __tmp99_outputWritten = true;
                    }
                    if (__tmp99_outputWritten) __out.AppendLine(true);
                    if (__tmp99_outputWritten)
                    {
                        __out.AppendLine(false); //1303:83
                    }
                }
                __out.Write("}"); //1305:1
                __out.AppendLine(false); //1305:2
                __out.AppendLine(true); //1306:1
                bool __tmp104_outputWritten = false;
                string __tmp105_line = "void "; //1307:1
                if (!string.IsNullOrEmpty(__tmp105_line))
                {
                    __out.Write(__tmp105_line);
                    __tmp104_outputWritten = true;
                }
                var __tmp106 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp106.Write(CSharpName(prop.Class, model, ClassKind.Builder, true));
                var __tmp106Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp106.ToStringAndFree());
                bool __tmp106_last = __tmp106Reader.EndOfStream;
                while(!__tmp106_last)
                {
                    ReadOnlySpan<char> __tmp106_line = __tmp106Reader.ReadLine();
                    __tmp106_last = __tmp106Reader.EndOfStream;
                    if (!__tmp106_last || !__tmp106_line.IsEmpty)
                    {
                        __out.Write(__tmp106_line);
                        __tmp104_outputWritten = true;
                    }
                    if (!__tmp106_last) __out.AppendLine(true);
                }
                string __tmp107_line = ".Set"; //1307:61
                if (!string.IsNullOrEmpty(__tmp107_line))
                {
                    __out.Write(__tmp107_line);
                    __tmp104_outputWritten = true;
                }
                var __tmp108 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp108.Write(prop.Name);
                var __tmp108Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp108.ToStringAndFree());
                bool __tmp108_last = __tmp108Reader.EndOfStream;
                while(!__tmp108_last)
                {
                    ReadOnlySpan<char> __tmp108_line = __tmp108Reader.ReadLine();
                    __tmp108_last = __tmp108Reader.EndOfStream;
                    if (!__tmp108_last || !__tmp108_line.IsEmpty)
                    {
                        __out.Write(__tmp108_line);
                        __tmp104_outputWritten = true;
                    }
                    if (!__tmp108_last) __out.AppendLine(true);
                }
                string __tmp109_line = "Lazy(global::System.Func<"; //1307:76
                if (!string.IsNullOrEmpty(__tmp109_line))
                {
                    __out.Write(__tmp109_line);
                    __tmp104_outputWritten = true;
                }
                var __tmp110 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp110.Write(CSharpName(prop.Class, model, ClassKind.Immutable, true));
                var __tmp110Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp110.ToStringAndFree());
                bool __tmp110_last = __tmp110Reader.EndOfStream;
                while(!__tmp110_last)
                {
                    ReadOnlySpan<char> __tmp110_line = __tmp110Reader.ReadLine();
                    __tmp110_last = __tmp110Reader.EndOfStream;
                    if (!__tmp110_last || !__tmp110_line.IsEmpty)
                    {
                        __out.Write(__tmp110_line);
                        __tmp104_outputWritten = true;
                    }
                    if (!__tmp110_last) __out.AppendLine(true);
                }
                string __tmp111_line = ", "; //1307:158
                if (!string.IsNullOrEmpty(__tmp111_line))
                {
                    __out.Write(__tmp111_line);
                    __tmp104_outputWritten = true;
                }
                var __tmp112 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp112.Write(CSharpName(prop.Type, model, ClassKind.Immutable, true));
                var __tmp112Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp112.ToStringAndFree());
                bool __tmp112_last = __tmp112Reader.EndOfStream;
                while(!__tmp112_last)
                {
                    ReadOnlySpan<char> __tmp112_line = __tmp112Reader.ReadLine();
                    __tmp112_last = __tmp112Reader.EndOfStream;
                    if (!__tmp112_last || !__tmp112_line.IsEmpty)
                    {
                        __out.Write(__tmp112_line);
                        __tmp104_outputWritten = true;
                    }
                    if (!__tmp112_last) __out.AppendLine(true);
                }
                string __tmp113_line = "> immutableLazy, global::System.Func<"; //1307:216
                if (!string.IsNullOrEmpty(__tmp113_line))
                {
                    __out.Write(__tmp113_line);
                    __tmp104_outputWritten = true;
                }
                var __tmp114 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp114.Write(CSharpName(prop.Class, model, ClassKind.Builder, true));
                var __tmp114Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp114.ToStringAndFree());
                bool __tmp114_last = __tmp114Reader.EndOfStream;
                while(!__tmp114_last)
                {
                    ReadOnlySpan<char> __tmp114_line = __tmp114Reader.ReadLine();
                    __tmp114_last = __tmp114Reader.EndOfStream;
                    if (!__tmp114_last || !__tmp114_line.IsEmpty)
                    {
                        __out.Write(__tmp114_line);
                        __tmp104_outputWritten = true;
                    }
                    if (!__tmp114_last) __out.AppendLine(true);
                }
                string __tmp115_line = ", "; //1307:308
                if (!string.IsNullOrEmpty(__tmp115_line))
                {
                    __out.Write(__tmp115_line);
                    __tmp104_outputWritten = true;
                }
                var __tmp116 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp116.Write(CSharpName(prop.Type, model, ClassKind.Builder, true));
                var __tmp116Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp116.ToStringAndFree());
                bool __tmp116_last = __tmp116Reader.EndOfStream;
                while(!__tmp116_last)
                {
                    ReadOnlySpan<char> __tmp116_line = __tmp116Reader.ReadLine();
                    __tmp116_last = __tmp116Reader.EndOfStream;
                    if (!__tmp116_last || !__tmp116_line.IsEmpty)
                    {
                        __out.Write(__tmp116_line);
                        __tmp104_outputWritten = true;
                    }
                    if (!__tmp116_last) __out.AppendLine(true);
                }
                string __tmp117_line = "> mutableLazy)"; //1307:364
                if (!string.IsNullOrEmpty(__tmp117_line))
                {
                    __out.Write(__tmp117_line);
                    __tmp104_outputWritten = true;
                }
                if (__tmp104_outputWritten) __out.AppendLine(true);
                if (__tmp104_outputWritten)
                {
                    __out.AppendLine(false); //1307:378
                }
                __out.Write("{"); //1308:1
                __out.AppendLine(false); //1308:2
                if (IsReferenceType(prop.Type)) //1309:3
                {
                    bool __tmp119_outputWritten = false;
                    string __tmp120_line = "	this.SetLazyReference("; //1310:1
                    if (!string.IsNullOrEmpty(__tmp120_line))
                    {
                        __out.Write(__tmp120_line);
                        __tmp119_outputWritten = true;
                    }
                    var __tmp121 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp121.Write(CSharpName(prop, model, PropertyKind.Descriptor, true));
                    var __tmp121Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp121.ToStringAndFree());
                    bool __tmp121_last = __tmp121Reader.EndOfStream;
                    while(!__tmp121_last)
                    {
                        ReadOnlySpan<char> __tmp121_line = __tmp121Reader.ReadLine();
                        __tmp121_last = __tmp121Reader.EndOfStream;
                        if (!__tmp121_last || !__tmp121_line.IsEmpty)
                        {
                            __out.Write(__tmp121_line);
                            __tmp119_outputWritten = true;
                        }
                        if (!__tmp121_last) __out.AppendLine(true);
                    }
                    string __tmp122_line = ", immutableLazy, mutableLazy);"; //1310:79
                    if (!string.IsNullOrEmpty(__tmp122_line))
                    {
                        __out.Write(__tmp122_line);
                        __tmp119_outputWritten = true;
                    }
                    if (__tmp119_outputWritten) __out.AppendLine(true);
                    if (__tmp119_outputWritten)
                    {
                        __out.AppendLine(false); //1310:109
                    }
                }
                else //1311:3
                {
                    bool __tmp124_outputWritten = false;
                    string __tmp125_line = "	this.SetLazyValue("; //1312:1
                    if (!string.IsNullOrEmpty(__tmp125_line))
                    {
                        __out.Write(__tmp125_line);
                        __tmp124_outputWritten = true;
                    }
                    var __tmp126 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp126.Write(CSharpName(prop, model, PropertyKind.Descriptor, true));
                    var __tmp126Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp126.ToStringAndFree());
                    bool __tmp126_last = __tmp126Reader.EndOfStream;
                    while(!__tmp126_last)
                    {
                        ReadOnlySpan<char> __tmp126_line = __tmp126Reader.ReadLine();
                        __tmp126_last = __tmp126Reader.EndOfStream;
                        if (!__tmp126_last || !__tmp126_line.IsEmpty)
                        {
                            __out.Write(__tmp126_line);
                            __tmp124_outputWritten = true;
                        }
                        if (!__tmp126_last) __out.AppendLine(true);
                    }
                    string __tmp127_line = ", immutableLazy, mutableLazy);"; //1312:75
                    if (!string.IsNullOrEmpty(__tmp127_line))
                    {
                        __out.Write(__tmp127_line);
                        __tmp124_outputWritten = true;
                    }
                    if (__tmp124_outputWritten) __out.AppendLine(true);
                    if (__tmp124_outputWritten)
                    {
                        __out.AppendLine(false); //1312:105
                    }
                }
                __out.Write("}"); //1314:1
                __out.AppendLine(false); //1314:2
            }
            return __out.ToStringAndFree();
        }

        public string GenerateBuilderOperationImpl(MetaModel model, MetaClass cls, MetaOperation op) //1318:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.AppendLine(true); //1319:1
            bool __tmp2_outputWritten = false;
            var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp3.Write(CSharpName(op.ReturnType, model, ClassKind.BuilderOperation, true));
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
                if (!__tmp3_last) __out.AppendLine(true);
            }
            string __tmp4_line = " "; //1320:68
            if (!string.IsNullOrEmpty(__tmp4_line))
            {
                __out.Write(__tmp4_line);
                __tmp2_outputWritten = true;
            }
            var __tmp5 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp5.Write(CSharpName(op.Class, model, ClassKind.Builder, true));
            var __tmp5Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp5.ToStringAndFree());
            bool __tmp5_last = __tmp5Reader.EndOfStream;
            while(!__tmp5_last)
            {
                ReadOnlySpan<char> __tmp5_line = __tmp5Reader.ReadLine();
                __tmp5_last = __tmp5Reader.EndOfStream;
                if (!__tmp5_last || !__tmp5_line.IsEmpty)
                {
                    __out.Write(__tmp5_line);
                    __tmp2_outputWritten = true;
                }
                if (!__tmp5_last) __out.AppendLine(true);
            }
            string __tmp6_line = "."; //1320:122
            if (!string.IsNullOrEmpty(__tmp6_line))
            {
                __out.Write(__tmp6_line);
                __tmp2_outputWritten = true;
            }
            var __tmp7 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp7.Write(op.Name);
            var __tmp7Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp7.ToStringAndFree());
            bool __tmp7_last = __tmp7Reader.EndOfStream;
            while(!__tmp7_last)
            {
                ReadOnlySpan<char> __tmp7_line = __tmp7Reader.ReadLine();
                __tmp7_last = __tmp7Reader.EndOfStream;
                if (!__tmp7_last || !__tmp7_line.IsEmpty)
                {
                    __out.Write(__tmp7_line);
                    __tmp2_outputWritten = true;
                }
                if (!__tmp7_last) __out.AppendLine(true);
            }
            string __tmp8_line = "("; //1320:132
            if (!string.IsNullOrEmpty(__tmp8_line))
            {
                __out.Write(__tmp8_line);
                __tmp2_outputWritten = true;
            }
            var __tmp9 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp9.Write(GetClassParameters(model, op.Class, op, ClassKind.BuilderOperation));
            var __tmp9Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp9.ToStringAndFree());
            bool __tmp9_last = __tmp9Reader.EndOfStream;
            while(!__tmp9_last)
            {
                ReadOnlySpan<char> __tmp9_line = __tmp9Reader.ReadLine();
                __tmp9_last = __tmp9Reader.EndOfStream;
                if (!__tmp9_last || !__tmp9_line.IsEmpty)
                {
                    __out.Write(__tmp9_line);
                    __tmp2_outputWritten = true;
                }
                if (!__tmp9_last) __out.AppendLine(true);
            }
            string __tmp10_line = ")"; //1320:202
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Write(__tmp10_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //1320:203
            }
            __out.Write("{"); //1321:1
            __out.AppendLine(false); //1321:2
            var finalOp = GetFinalOperation(cls, op); //1322:2
            bool __tmp12_outputWritten = false;
            string __tmp11Prefix = "    "; //1323:1
            var __tmp13 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp13.Write(GetReturn(CSharpName(finalOp.ReturnType, model, ClassKind.BuilderOperation)));
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
                if (!__tmp13_last) __out.AppendLine(true);
            }
            var __tmp14 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp14.Write(CSharpName(model, ModelKind.ImplementationProvider));
            var __tmp14Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp14.ToStringAndFree());
            bool __tmp14_last = __tmp14Reader.EndOfStream;
            while(!__tmp14_last)
            {
                ReadOnlySpan<char> __tmp14_line = __tmp14Reader.ReadLine();
                __tmp14_last = __tmp14Reader.EndOfStream;
                if (!__tmp14_last || !__tmp14_line.IsEmpty)
                {
                    __out.Write(__tmp14_line);
                    __tmp12_outputWritten = true;
                }
                if (!__tmp14_last) __out.AppendLine(true);
            }
            string __tmp15_line = ".Implementation."; //1323:134
            if (!string.IsNullOrEmpty(__tmp15_line))
            {
                __out.Write(__tmp15_line);
                __tmp12_outputWritten = true;
            }
            var __tmp16 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp16.Write(CSharpName(finalOp.Class, model, ClassKind.Immutable));
            var __tmp16Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp16.ToStringAndFree());
            bool __tmp16_last = __tmp16Reader.EndOfStream;
            while(!__tmp16_last)
            {
                ReadOnlySpan<char> __tmp16_line = __tmp16Reader.ReadLine();
                __tmp16_last = __tmp16Reader.EndOfStream;
                if (!__tmp16_last || !__tmp16_line.IsEmpty)
                {
                    __out.Write(__tmp16_line);
                    __tmp12_outputWritten = true;
                }
                if (!__tmp16_last) __out.AppendLine(true);
            }
            string __tmp17_line = "_"; //1323:204
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Write(__tmp17_line);
                __tmp12_outputWritten = true;
            }
            var __tmp18 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp18.Write(finalOp.Name);
            var __tmp18Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp18.ToStringAndFree());
            bool __tmp18_last = __tmp18Reader.EndOfStream;
            while(!__tmp18_last)
            {
                ReadOnlySpan<char> __tmp18_line = __tmp18Reader.ReadLine();
                __tmp18_last = __tmp18Reader.EndOfStream;
                if (!__tmp18_last || !__tmp18_line.IsEmpty)
                {
                    __out.Write(__tmp18_line);
                    __tmp12_outputWritten = true;
                }
                if (!__tmp18_last) __out.AppendLine(true);
            }
            string __tmp19_line = "("; //1323:219
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Write(__tmp19_line);
                __tmp12_outputWritten = true;
            }
            var __tmp20 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp20.Write(GetClassImplCallParameterNames(model, finalOp, ClassKind.BuilderOperation));
            var __tmp20Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp20.ToStringAndFree());
            bool __tmp20_last = __tmp20Reader.EndOfStream;
            while(!__tmp20_last)
            {
                ReadOnlySpan<char> __tmp20_line = __tmp20Reader.ReadLine();
                __tmp20_last = __tmp20Reader.EndOfStream;
                if (!__tmp20_last || !__tmp20_line.IsEmpty)
                {
                    __out.Write(__tmp20_line);
                    __tmp12_outputWritten = true;
                }
                if (!__tmp20_last) __out.AppendLine(true);
            }
            string __tmp21_line = ");"; //1323:296
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp12_outputWritten = true;
            }
            if (__tmp12_outputWritten) __out.AppendLine(true);
            if (__tmp12_outputWritten)
            {
                __out.AppendLine(false); //1323:298
            }
            __out.Write("}"); //1324:1
            __out.AppendLine(false); //1324:2
            return __out.ToStringAndFree();
        }

    }
}

