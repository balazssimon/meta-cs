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
        string CSharpName(IMetaModel mmodel, ModelKind kind = ModelKind.None, bool fullName = false); //52:8
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

        internal string CSharpName(IMetaModel mmodel, ModelKind kind = ModelKind.None, bool fullName = false) //52:8
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
            __tmp12.Write(GenerateMetaModel(model));
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
                __out.AppendLine(false); //84:28
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

        public string GenerateMetaModel(MetaModel model) //122:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //123:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //124:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Write(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp4.Write(CSharpName(model, ModelKind.MetaModel));
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
            string __tmp5_line = " : "; //124:55
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
            string __tmp7_line = ".IMetaModel"; //124:77
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
            string __tmp10_line = "	internal "; //126:1
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Write(__tmp10_line);
                __tmp9_outputWritten = true;
            }
            var __tmp11 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp11.Write(CSharpName(model, ModelKind.MetaModel));
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
            string __tmp12_line = "()"; //126:50
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Write(__tmp12_line);
                __tmp9_outputWritten = true;
            }
            if (__tmp9_outputWritten) __out.AppendLine(true);
            if (__tmp9_outputWritten)
            {
                __out.AppendLine(false); //126:52
            }
            __out.Write("	{"); //127:1
            __out.AppendLine(false); //127:3
            __out.Write("	}"); //128:1
            __out.AppendLine(false); //128:3
            __out.AppendLine(true); //129:1
            bool __tmp14_outputWritten = false;
            string __tmp15_line = "	public "; //130:1
            if (!string.IsNullOrEmpty(__tmp15_line))
            {
                __out.Write(__tmp15_line);
                __tmp14_outputWritten = true;
            }
            var __tmp16 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp16.Write(Properties.CoreNs);
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
            string __tmp17_line = ".ModelId Id => "; //130:28
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Write(__tmp17_line);
                __tmp14_outputWritten = true;
            }
            var __tmp18 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp18.Write(CSharpName(model, ModelKind.ImmutableInstance));
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
            string __tmp19_line = ".MModel.Id;"; //130:90
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Write(__tmp19_line);
                __tmp14_outputWritten = true;
            }
            if (__tmp14_outputWritten) __out.AppendLine(true);
            if (__tmp14_outputWritten)
            {
                __out.AppendLine(false); //130:101
            }
            bool __tmp21_outputWritten = false;
            string __tmp22_line = "	public string Name => \""; //131:1
            if (!string.IsNullOrEmpty(__tmp22_line))
            {
                __out.Write(__tmp22_line);
                __tmp21_outputWritten = true;
            }
            var __tmp23 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp23.Write(model.Name);
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
            string __tmp24_line = "\";"; //131:37
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Write(__tmp24_line);
                __tmp21_outputWritten = true;
            }
            if (__tmp21_outputWritten) __out.AppendLine(true);
            if (__tmp21_outputWritten)
            {
                __out.AppendLine(false); //131:39
            }
            bool __tmp26_outputWritten = false;
            string __tmp27_line = "	public "; //132:1
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Write(__tmp27_line);
                __tmp26_outputWritten = true;
            }
            var __tmp28 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp28.Write(Properties.CoreNs);
            var __tmp28Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp28.ToStringAndFree());
            bool __tmp28_last = __tmp28Reader.EndOfStream;
            while(!__tmp28_last)
            {
                ReadOnlySpan<char> __tmp28_line = __tmp28Reader.ReadLine();
                __tmp28_last = __tmp28Reader.EndOfStream;
                if (!__tmp28_last || !__tmp28_line.IsEmpty)
                {
                    __out.Write(__tmp28_line);
                    __tmp26_outputWritten = true;
                }
                if (!__tmp28_last) __out.AppendLine(true);
            }
            string __tmp29_line = ".ModelVersion Version => "; //132:28
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Write(__tmp29_line);
                __tmp26_outputWritten = true;
            }
            var __tmp30 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp30.Write(CSharpName(model, ModelKind.ImmutableInstance));
            var __tmp30Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp30.ToStringAndFree());
            bool __tmp30_last = __tmp30Reader.EndOfStream;
            while(!__tmp30_last)
            {
                ReadOnlySpan<char> __tmp30_line = __tmp30Reader.ReadLine();
                __tmp30_last = __tmp30Reader.EndOfStream;
                if (!__tmp30_last || !__tmp30_line.IsEmpty)
                {
                    __out.Write(__tmp30_line);
                    __tmp26_outputWritten = true;
                }
                if (!__tmp30_last) __out.AppendLine(true);
            }
            string __tmp31_line = ".MModel.Version;"; //132:100
            if (!string.IsNullOrEmpty(__tmp31_line))
            {
                __out.Write(__tmp31_line);
                __tmp26_outputWritten = true;
            }
            if (__tmp26_outputWritten) __out.AppendLine(true);
            if (__tmp26_outputWritten)
            {
                __out.AppendLine(false); //132:116
            }
            bool __tmp33_outputWritten = false;
            string __tmp34_line = "	public global::System.Collections.Generic.IEnumerable<global::MetaDslx.Modeling.IModelObject> Objects => "; //133:1
            if (!string.IsNullOrEmpty(__tmp34_line))
            {
                __out.Write(__tmp34_line);
                __tmp33_outputWritten = true;
            }
            var __tmp35 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp35.Write(CSharpName(model, ModelKind.ImmutableInstance));
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
            string __tmp36_line = ".MModel.Objects;"; //133:154
            if (!string.IsNullOrEmpty(__tmp36_line))
            {
                __out.Write(__tmp36_line);
                __tmp33_outputWritten = true;
            }
            if (__tmp33_outputWritten) __out.AppendLine(true);
            if (__tmp33_outputWritten)
            {
                __out.AppendLine(false); //133:170
            }
            bool __tmp38_outputWritten = false;
            string __tmp39_line = "	public string Uri => \""; //134:1
            if (!string.IsNullOrEmpty(__tmp39_line))
            {
                __out.Write(__tmp39_line);
                __tmp38_outputWritten = true;
            }
            var __tmp40 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp40.Write(model.Uri);
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
            string __tmp41_line = "\";"; //134:35
            if (!string.IsNullOrEmpty(__tmp41_line))
            {
                __out.Write(__tmp41_line);
                __tmp38_outputWritten = true;
            }
            if (__tmp38_outputWritten) __out.AppendLine(true);
            if (__tmp38_outputWritten)
            {
                __out.AppendLine(false); //134:37
            }
            bool __tmp43_outputWritten = false;
            string __tmp44_line = "	public string Prefix => \""; //135:1
            if (!string.IsNullOrEmpty(__tmp44_line))
            {
                __out.Write(__tmp44_line);
                __tmp43_outputWritten = true;
            }
            var __tmp45 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp45.Write(model.Prefix);
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
            string __tmp46_line = "\";"; //135:41
            if (!string.IsNullOrEmpty(__tmp46_line))
            {
                __out.Write(__tmp46_line);
                __tmp43_outputWritten = true;
            }
            if (__tmp43_outputWritten) __out.AppendLine(true);
            if (__tmp43_outputWritten)
            {
                __out.AppendLine(false); //135:43
            }
            bool __tmp48_outputWritten = false;
            string __tmp49_line = "	public "; //136:1
            if (!string.IsNullOrEmpty(__tmp49_line))
            {
                __out.Write(__tmp49_line);
                __tmp48_outputWritten = true;
            }
            var __tmp50 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp50.Write(Properties.CoreNs);
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
            string __tmp51_line = ".IModelGroup ModelGroup => "; //136:28
            if (!string.IsNullOrEmpty(__tmp51_line))
            {
                __out.Write(__tmp51_line);
                __tmp48_outputWritten = true;
            }
            var __tmp52 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp52.Write(CSharpName(model, ModelKind.ImmutableInstance));
            var __tmp52Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp52.ToStringAndFree());
            bool __tmp52_last = __tmp52Reader.EndOfStream;
            while(!__tmp52_last)
            {
                ReadOnlySpan<char> __tmp52_line = __tmp52Reader.ReadLine();
                __tmp52_last = __tmp52Reader.EndOfStream;
                if (!__tmp52_last || !__tmp52_line.IsEmpty)
                {
                    __out.Write(__tmp52_line);
                    __tmp48_outputWritten = true;
                }
                if (!__tmp52_last) __out.AppendLine(true);
            }
            string __tmp53_line = ".MModel.ModelGroup;"; //136:102
            if (!string.IsNullOrEmpty(__tmp53_line))
            {
                __out.Write(__tmp53_line);
                __tmp48_outputWritten = true;
            }
            if (__tmp48_outputWritten) __out.AppendLine(true);
            if (__tmp48_outputWritten)
            {
                __out.AppendLine(false); //136:121
            }
            bool __tmp55_outputWritten = false;
            string __tmp56_line = "	public string Namespace => \""; //137:1
            if (!string.IsNullOrEmpty(__tmp56_line))
            {
                __out.Write(__tmp56_line);
                __tmp55_outputWritten = true;
            }
            var __tmp57 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp57.Write(CSharpName(model.Namespace, NamespaceKind.Public, true));
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
            string __tmp58_line = "\";"; //137:86
            if (!string.IsNullOrEmpty(__tmp58_line))
            {
                __out.Write(__tmp58_line);
                __tmp55_outputWritten = true;
            }
            if (__tmp55_outputWritten) __out.AppendLine(true);
            if (__tmp55_outputWritten)
            {
                __out.AppendLine(false); //137:88
            }
            __out.AppendLine(true); //138:1
            bool __tmp60_outputWritten = false;
            string __tmp61_line = "	public "; //139:1
            if (!string.IsNullOrEmpty(__tmp61_line))
            {
                __out.Write(__tmp61_line);
                __tmp60_outputWritten = true;
            }
            var __tmp62 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp62.Write(Properties.CoreNs);
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
            string __tmp63_line = ".IModelFactory CreateFactory("; //139:28
            if (!string.IsNullOrEmpty(__tmp63_line))
            {
                __out.Write(__tmp63_line);
                __tmp60_outputWritten = true;
            }
            var __tmp64 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp64.Write(Properties.CoreNs);
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
            string __tmp65_line = ".MutableModel model, "; //139:76
            if (!string.IsNullOrEmpty(__tmp65_line))
            {
                __out.Write(__tmp65_line);
                __tmp60_outputWritten = true;
            }
            var __tmp66 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp66.Write(Properties.CoreNs);
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
            string __tmp67_line = ".ModelFactoryFlags flags = "; //139:116
            if (!string.IsNullOrEmpty(__tmp67_line))
            {
                __out.Write(__tmp67_line);
                __tmp60_outputWritten = true;
            }
            var __tmp68 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp68.Write(Properties.CoreNs);
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
            string __tmp69_line = ".ModelFactoryFlags.None)"; //139:162
            if (!string.IsNullOrEmpty(__tmp69_line))
            {
                __out.Write(__tmp69_line);
                __tmp60_outputWritten = true;
            }
            if (__tmp60_outputWritten) __out.AppendLine(true);
            if (__tmp60_outputWritten)
            {
                __out.AppendLine(false); //139:186
            }
            __out.Write("	{"); //140:1
            __out.AppendLine(false); //140:3
            bool __tmp71_outputWritten = false;
            string __tmp72_line = "		return new "; //141:1
            if (!string.IsNullOrEmpty(__tmp72_line))
            {
                __out.Write(__tmp72_line);
                __tmp71_outputWritten = true;
            }
            var __tmp73 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp73.Write(CSharpName(model, ModelKind.Factory));
            var __tmp73Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp73.ToStringAndFree());
            bool __tmp73_last = __tmp73Reader.EndOfStream;
            while(!__tmp73_last)
            {
                ReadOnlySpan<char> __tmp73_line = __tmp73Reader.ReadLine();
                __tmp73_last = __tmp73Reader.EndOfStream;
                if (!__tmp73_last || !__tmp73_line.IsEmpty)
                {
                    __out.Write(__tmp73_line);
                    __tmp71_outputWritten = true;
                }
                if (!__tmp73_last) __out.AppendLine(true);
            }
            string __tmp74_line = "(model, flags);"; //141:51
            if (!string.IsNullOrEmpty(__tmp74_line))
            {
                __out.Write(__tmp74_line);
                __tmp71_outputWritten = true;
            }
            if (__tmp71_outputWritten) __out.AppendLine(true);
            if (__tmp71_outputWritten)
            {
                __out.AppendLine(false); //141:66
            }
            __out.Write("	}"); //142:1
            __out.AppendLine(false); //142:3
            __out.AppendLine(true); //143:1
            __out.Write("    public override string ToString()"); //144:1
            __out.AppendLine(false); //144:38
            __out.Write("    {"); //145:1
            __out.AppendLine(false); //145:6
            __out.Write("        return $\"{Name} ({Version})\";"); //146:1
            __out.AppendLine(false); //146:38
            __out.Write("    }"); //147:1
            __out.AppendLine(false); //147:6
            __out.Write("}"); //148:1
            __out.AppendLine(false); //148:2
            return __out.ToStringAndFree();
        }

        public string GenerateMetaModelInstance(MetaModel model) //151:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //152:2
            bool metaMetaModel = IsMetaMetaModel(model); //153:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //154:1
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
                __out.AppendLine(false); //154:61
            }
            __out.Write("{"); //155:1
            __out.AppendLine(false); //155:2
            __out.Write("	private static bool initialized;"); //156:1
            __out.AppendLine(false); //156:34
            __out.AppendLine(true); //157:1
            __out.Write("	public static bool IsInitialized"); //158:1
            __out.AppendLine(false); //158:34
            __out.Write("	{"); //159:1
            __out.AppendLine(false); //159:3
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "		get { return "; //160:1
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
            string __tmp9_line = ".initialized; }"; //160:63
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Write(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //160:78
            }
            __out.Write("	}"); //161:1
            __out.AppendLine(false); //161:3
            __out.AppendLine(true); //162:1
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	public static readonly "; //163:1
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Write(__tmp12_line);
                __tmp11_outputWritten = true;
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
                    __tmp11_outputWritten = true;
                }
                if (!__tmp13_last) __out.AppendLine(true);
            }
            string __tmp14_line = ".IMetaModel MMetaModel;"; //163:44
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //163:67
            }
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "	public static readonly "; //164:1
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
            string __tmp19_line = ".ImmutableModel MModel;"; //164:44
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Write(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //164:67
            }
            __out.AppendLine(true); //165:1
            var __loop8_results = 
                (from __loop8_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //166:8
                from cst in __Enumerate((__loop8_var1).GetEnumerator()).OfType<MetaConstant>() //166:38
                select new { __loop8_var1 = __loop8_var1, cst = cst}
                ).ToList(); //166:3
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp20 = __loop8_results[__loop8_iteration];
                var __loop8_var1 = __tmp20.__loop8_var1;
                var cst = __tmp20.cst;
                bool __tmp22_outputWritten = false;
                string __tmp21Prefix = "	"; //167:1
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
                    __out.AppendLine(false); //167:30
                }
                if (metaMetaModel) //168:4
                {
                    bool __tmp25_outputWritten = false;
                    string __tmp26_line = "	public static readonly "; //169:1
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
                    string __tmp28_line = " "; //169:74
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
                    string __tmp30_line = ";"; //169:127
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Write(__tmp30_line);
                        __tmp25_outputWritten = true;
                    }
                    if (__tmp25_outputWritten) __out.AppendLine(true);
                    if (__tmp25_outputWritten)
                    {
                        __out.AppendLine(false); //169:128
                    }
                }
                else //170:4
                {
                    bool __tmp32_outputWritten = false;
                    string __tmp33_line = "	public static readonly "; //171:1
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
                    string __tmp35_line = " "; //171:80
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
                    string __tmp37_line = ";"; //171:133
                    if (!string.IsNullOrEmpty(__tmp37_line))
                    {
                        __out.Write(__tmp37_line);
                        __tmp32_outputWritten = true;
                    }
                    if (__tmp32_outputWritten) __out.AppendLine(true);
                    if (__tmp32_outputWritten)
                    {
                        __out.AppendLine(false); //171:134
                    }
                }
            }
            __out.AppendLine(true); //174:1
            var __loop9_results = 
                (from __loop9_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //175:8
                from cls in __Enumerate((__loop9_var1).GetEnumerator()).OfType<MetaClass>() //175:38
                select new { __loop9_var1 = __loop9_var1, cls = cls}
                ).ToList(); //175:3
            for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
            {
                var __tmp38 = __loop9_results[__loop9_iteration];
                var __loop9_var1 = __tmp38.__loop9_var1;
                var cls = __tmp38.cls;
                bool __tmp40_outputWritten = false;
                string __tmp39Prefix = "	"; //176:1
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
                    __out.AppendLine(false); //176:30
                }
                bool __tmp43_outputWritten = false;
                string __tmp44_line = "	public static readonly "; //177:1
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
                string __tmp46_line = "MetaClass "; //177:33
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
                string __tmp48_line = ";"; //177:95
                if (!string.IsNullOrEmpty(__tmp48_line))
                {
                    __out.Write(__tmp48_line);
                    __tmp43_outputWritten = true;
                }
                if (__tmp43_outputWritten) __out.AppendLine(true);
                if (__tmp43_outputWritten)
                {
                    __out.AppendLine(false); //177:96
                }
                var __loop10_results = 
                    (from __loop10_var1 in __Enumerate((cls).GetEnumerator()) //178:9
                    from prop in __Enumerate((__loop10_var1.Properties).GetEnumerator()) //178:14
                    select new { __loop10_var1 = __loop10_var1, prop = prop}
                    ).ToList(); //178:4
                for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
                {
                    var __tmp49 = __loop10_results[__loop10_iteration];
                    var __loop10_var1 = __tmp49.__loop10_var1;
                    var prop = __tmp49.prop;
                    bool __tmp51_outputWritten = false;
                    string __tmp50Prefix = "	"; //179:1
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
                        __out.AppendLine(false); //179:31
                    }
                    bool __tmp54_outputWritten = false;
                    string __tmp55_line = "	public static readonly "; //180:1
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
                    string __tmp57_line = "MetaProperty "; //180:33
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
                    string __tmp59_line = ";"; //180:102
                    if (!string.IsNullOrEmpty(__tmp59_line))
                    {
                        __out.Write(__tmp59_line);
                        __tmp54_outputWritten = true;
                    }
                    if (__tmp54_outputWritten) __out.AppendLine(true);
                    if (__tmp54_outputWritten)
                    {
                        __out.AppendLine(false); //180:103
                    }
                }
            }
            __out.AppendLine(true); //183:1
            bool __tmp61_outputWritten = false;
            string __tmp62_line = "	static "; //184:1
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
            string __tmp64_line = "()"; //184:56
            if (!string.IsNullOrEmpty(__tmp64_line))
            {
                __out.Write(__tmp64_line);
                __tmp61_outputWritten = true;
            }
            if (__tmp61_outputWritten) __out.AppendLine(true);
            if (__tmp61_outputWritten)
            {
                __out.AppendLine(false); //184:58
            }
            __out.Write("	{"); //185:1
            __out.AppendLine(false); //185:3
            bool __tmp66_outputWritten = false;
            string __tmp65Prefix = "		"; //186:1
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
            string __tmp68_line = ".instance.Create();"; //186:48
            if (!string.IsNullOrEmpty(__tmp68_line))
            {
                __out.Write(__tmp68_line);
                __tmp66_outputWritten = true;
            }
            if (__tmp66_outputWritten) __out.AppendLine(true);
            if (__tmp66_outputWritten)
            {
                __out.AppendLine(false); //186:67
            }
            bool __tmp70_outputWritten = false;
            string __tmp69Prefix = "		"; //187:1
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
            string __tmp72_line = ".instance.EvaluateLazyValues();"; //187:48
            if (!string.IsNullOrEmpty(__tmp72_line))
            {
                __out.Write(__tmp72_line);
                __tmp70_outputWritten = true;
            }
            if (__tmp70_outputWritten) __out.AppendLine(true);
            if (__tmp70_outputWritten)
            {
                __out.AppendLine(false); //187:79
            }
            bool __tmp74_outputWritten = false;
            string __tmp75_line = "		MMetaModel = new "; //188:1
            if (!string.IsNullOrEmpty(__tmp75_line))
            {
                __out.Write(__tmp75_line);
                __tmp74_outputWritten = true;
            }
            var __tmp76 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp76.Write(CSharpName(model, ModelKind.MetaModel));
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
            string __tmp77_line = "();"; //188:59
            if (!string.IsNullOrEmpty(__tmp77_line))
            {
                __out.Write(__tmp77_line);
                __tmp74_outputWritten = true;
            }
            if (__tmp74_outputWritten) __out.AppendLine(true);
            if (__tmp74_outputWritten)
            {
                __out.AppendLine(false); //188:62
            }
            bool __tmp79_outputWritten = false;
            string __tmp80_line = "		MModel = "; //189:1
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
            string __tmp82_line = ".instance.MModel.ToImmutable();"; //189:57
            if (!string.IsNullOrEmpty(__tmp82_line))
            {
                __out.Write(__tmp82_line);
                __tmp79_outputWritten = true;
            }
            if (__tmp79_outputWritten) __out.AppendLine(true);
            if (__tmp79_outputWritten)
            {
                __out.AppendLine(false); //189:88
            }
            __out.AppendLine(true); //190:1
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //191:9
                from cst in __Enumerate((__loop11_var1).GetEnumerator()).OfType<MetaConstant>() //191:39
                select new { __loop11_var1 = __loop11_var1, cst = cst}
                ).ToList(); //191:4
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp83 = __loop11_results[__loop11_iteration];
                var __loop11_var1 = __tmp83.__loop11_var1;
                var cst = __tmp83.cst;
                if (metaMetaModel) //192:5
                {
                    bool __tmp85_outputWritten = false;
                    string __tmp84Prefix = "		"; //193:1
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
                    string __tmp87_line = " = "; //193:55
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
                    string __tmp89_line = ".ToImmutable(MModel);"; //193:114
                    if (!string.IsNullOrEmpty(__tmp89_line))
                    {
                        __out.Write(__tmp89_line);
                        __tmp85_outputWritten = true;
                    }
                    if (__tmp85_outputWritten) __out.AppendLine(true);
                    if (__tmp85_outputWritten)
                    {
                        __out.AppendLine(false); //193:135
                    }
                }
                else //194:5
                {
                    bool __tmp91_outputWritten = false;
                    string __tmp90Prefix = "		"; //195:1
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
                    string __tmp93_line = " = "; //195:55
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
                    string __tmp95_line = ".ToImmutable(MModel);"; //195:114
                    if (!string.IsNullOrEmpty(__tmp95_line))
                    {
                        __out.Write(__tmp95_line);
                        __tmp91_outputWritten = true;
                    }
                    if (__tmp91_outputWritten) __out.AppendLine(true);
                    if (__tmp91_outputWritten)
                    {
                        __out.AppendLine(false); //195:135
                    }
                }
            }
            __out.AppendLine(true); //198:1
            var __loop12_results = 
                (from __loop12_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //199:9
                from cls in __Enumerate((__loop12_var1).GetEnumerator()).OfType<MetaClass>() //199:39
                select new { __loop12_var1 = __loop12_var1, cls = cls}
                ).ToList(); //199:4
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp96 = __loop12_results[__loop12_iteration];
                var __loop12_var1 = __tmp96.__loop12_var1;
                var cls = __tmp96.cls;
                bool __tmp98_outputWritten = false;
                string __tmp97Prefix = "		"; //200:1
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
                string __tmp100_line = " = "; //200:55
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
                string __tmp102_line = ".ToImmutable(MModel);"; //200:114
                if (!string.IsNullOrEmpty(__tmp102_line))
                {
                    __out.Write(__tmp102_line);
                    __tmp98_outputWritten = true;
                }
                if (__tmp98_outputWritten) __out.AppendLine(true);
                if (__tmp98_outputWritten)
                {
                    __out.AppendLine(false); //200:135
                }
                var __loop13_results = 
                    (from __loop13_var1 in __Enumerate((cls).GetEnumerator()) //201:10
                    from prop in __Enumerate((__loop13_var1.Properties).GetEnumerator()) //201:15
                    select new { __loop13_var1 = __loop13_var1, prop = prop}
                    ).ToList(); //201:5
                for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
                {
                    var __tmp103 = __loop13_results[__loop13_iteration];
                    var __loop13_var1 = __tmp103.__loop13_var1;
                    var prop = __tmp103.prop;
                    bool __tmp105_outputWritten = false;
                    string __tmp104Prefix = "		"; //202:1
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
                    string __tmp107_line = " = "; //202:59
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
                    string __tmp109_line = ".ToImmutable(MModel);"; //202:122
                    if (!string.IsNullOrEmpty(__tmp109_line))
                    {
                        __out.Write(__tmp109_line);
                        __tmp105_outputWritten = true;
                    }
                    if (__tmp105_outputWritten) __out.AppendLine(true);
                    if (__tmp105_outputWritten)
                    {
                        __out.AppendLine(false); //202:143
                    }
                }
            }
            __out.AppendLine(true); //205:1
            bool __tmp111_outputWritten = false;
            string __tmp110Prefix = "		"; //206:1
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
            string __tmp113_line = ".initialized = true;"; //206:50
            if (!string.IsNullOrEmpty(__tmp113_line))
            {
                __out.Write(__tmp113_line);
                __tmp111_outputWritten = true;
            }
            if (__tmp111_outputWritten) __out.AppendLine(true);
            if (__tmp111_outputWritten)
            {
                __out.AppendLine(false); //206:70
            }
            __out.Write("	}"); //207:1
            __out.AppendLine(false); //207:3
            __out.Write("}"); //208:1
            __out.AppendLine(false); //208:2
            return __out.ToStringAndFree();
        }

        public string GenerateMetaModelBuilderInstance(MetaModel model) //211:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //212:2
            bool metaMetaModel = IsMetaMetaModel(model); //213:2
            ImmutableList<ImmutableObject> instances = GetInstances(model); //214:2
            ImmutableDictionary<ImmutableObject,string> instanceNames = GetInstanceNames(model); //215:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //216:1
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
                __out.AppendLine(false); //216:61
            }
            __out.Write("{"); //217:1
            __out.AppendLine(false); //217:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	internal static "; //218:1
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
            string __tmp9_line = " instance = new "; //218:63
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
            string __tmp11_line = "();"; //218:124
            if (!string.IsNullOrEmpty(__tmp11_line))
            {
                __out.Write(__tmp11_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //218:127
            }
            __out.AppendLine(true); //219:1
            __out.Write("	private bool creating;"); //220:1
            __out.AppendLine(false); //220:24
            __out.Write("	private bool created;"); //221:1
            __out.AppendLine(false); //221:23
            bool __tmp13_outputWritten = false;
            string __tmp14_line = "	internal "; //222:1
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp13_outputWritten = true;
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
                    __tmp13_outputWritten = true;
                }
                if (!__tmp15_last) __out.AppendLine(true);
            }
            string __tmp16_line = ".MutableModel MModel;"; //222:30
            if (!string.IsNullOrEmpty(__tmp16_line))
            {
                __out.Write(__tmp16_line);
                __tmp13_outputWritten = true;
            }
            if (__tmp13_outputWritten) __out.AppendLine(true);
            if (__tmp13_outputWritten)
            {
                __out.AppendLine(false); //222:51
            }
            if (!metaMetaModel) //223:3
            {
                bool __tmp18_outputWritten = false;
                string __tmp19_line = "	internal "; //224:1
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
                string __tmp21_line = ".MutableModelGroup MModelGroup;"; //224:30
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Write(__tmp21_line);
                    __tmp18_outputWritten = true;
                }
                if (__tmp18_outputWritten) __out.AppendLine(true);
                if (__tmp18_outputWritten)
                {
                    __out.AppendLine(false); //224:61
                }
            }
            __out.AppendLine(true); //226:1
            var __loop14_results = 
                (from __loop14_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //227:8
                from cst in __Enumerate((__loop14_var1).GetEnumerator()).OfType<MetaConstant>() //227:38
                select new { __loop14_var1 = __loop14_var1, cst = cst}
                ).ToList(); //227:3
            for (int __loop14_iteration = 0; __loop14_iteration < __loop14_results.Count; ++__loop14_iteration)
            {
                var __tmp22 = __loop14_results[__loop14_iteration];
                var __loop14_var1 = __tmp22.__loop14_var1;
                var cst = __tmp22.cst;
                bool __tmp24_outputWritten = false;
                string __tmp23Prefix = "	"; //228:1
                var __tmp25 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp25.Write(GenerateDocumentation(cst));
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
                    __out.AppendLine(false); //228:30
                }
                if (metaMetaModel) //229:4
                {
                    bool __tmp27_outputWritten = false;
                    string __tmp28_line = "	internal "; //230:1
                    if (!string.IsNullOrEmpty(__tmp28_line))
                    {
                        __out.Write(__tmp28_line);
                        __tmp27_outputWritten = true;
                    }
                    var __tmp29 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp29.Write(CSharpName(cst.Type, model, ClassKind.Builder));
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
                    string __tmp30_line = " "; //230:58
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Write(__tmp30_line);
                        __tmp27_outputWritten = true;
                    }
                    var __tmp31 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp31.Write(CSharpName(cst, model, ClassKind.BuilderInstance));
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
                    string __tmp32_line = " = null;"; //230:109
                    if (!string.IsNullOrEmpty(__tmp32_line))
                    {
                        __out.Write(__tmp32_line);
                        __tmp27_outputWritten = true;
                    }
                    if (__tmp27_outputWritten) __out.AppendLine(true);
                    if (__tmp27_outputWritten)
                    {
                        __out.AppendLine(false); //230:117
                    }
                }
                else //231:4
                {
                    bool __tmp34_outputWritten = false;
                    string __tmp35_line = "	internal "; //232:1
                    if (!string.IsNullOrEmpty(__tmp35_line))
                    {
                        __out.Write(__tmp35_line);
                        __tmp34_outputWritten = true;
                    }
                    var __tmp36 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp36.Write(CSharpName(cst.Type, model, ClassKind.Builder, true));
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
                    string __tmp37_line = " "; //232:64
                    if (!string.IsNullOrEmpty(__tmp37_line))
                    {
                        __out.Write(__tmp37_line);
                        __tmp34_outputWritten = true;
                    }
                    var __tmp38 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp38.Write(CSharpName(cst, model, ClassKind.BuilderInstance));
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
                    string __tmp39_line = " = null;"; //232:115
                    if (!string.IsNullOrEmpty(__tmp39_line))
                    {
                        __out.Write(__tmp39_line);
                        __tmp34_outputWritten = true;
                    }
                    if (__tmp34_outputWritten) __out.AppendLine(true);
                    if (__tmp34_outputWritten)
                    {
                        __out.AppendLine(false); //232:123
                    }
                }
            }
            __out.AppendLine(true); //235:1
            var __loop15_results = 
                (from obj in __Enumerate((instances).GetEnumerator()) //236:8
                select new { obj = obj}
                ).ToList(); //236:3
            for (int __loop15_iteration = 0; __loop15_iteration < __loop15_results.Count; ++__loop15_iteration)
            {
                var __tmp40 = __loop15_results[__loop15_iteration];
                var obj = __tmp40.obj;
                bool __tmp42_outputWritten = false;
                string __tmp41Prefix = "	"; //237:1
                var __tmp43 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp43.Write(GenerateInstanceDeclaration(model, metaMetaModel, obj, instanceNames));
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
                    __out.AppendLine(false); //237:73
                }
            }
            __out.AppendLine(true); //239:1
            bool __tmp45_outputWritten = false;
            string __tmp46_line = "	internal "; //240:1
            if (!string.IsNullOrEmpty(__tmp46_line))
            {
                __out.Write(__tmp46_line);
                __tmp45_outputWritten = true;
            }
            var __tmp47 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp47.Write(CSharpName(model, ModelKind.BuilderInstance));
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
            string __tmp48_line = "()"; //240:56
            if (!string.IsNullOrEmpty(__tmp48_line))
            {
                __out.Write(__tmp48_line);
                __tmp45_outputWritten = true;
            }
            if (__tmp45_outputWritten) __out.AppendLine(true);
            if (__tmp45_outputWritten)
            {
                __out.AppendLine(false); //240:58
            }
            __out.Write("	{"); //241:1
            __out.AppendLine(false); //241:3
            if (metaMetaModel) //242:4
            {
                bool __tmp50_outputWritten = false;
                string __tmp51_line = "		this.MModel = new "; //243:1
                if (!string.IsNullOrEmpty(__tmp51_line))
                {
                    __out.Write(__tmp51_line);
                    __tmp50_outputWritten = true;
                }
                var __tmp52 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp52.Write(Properties.CoreNs);
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
                string __tmp53_line = ".MutableModel(\""; //243:40
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Write(__tmp53_line);
                    __tmp50_outputWritten = true;
                }
                var __tmp54 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp54.Write(model.Name);
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
                string __tmp55_line = "\");"; //243:67
                if (!string.IsNullOrEmpty(__tmp55_line))
                {
                    __out.Write(__tmp55_line);
                    __tmp50_outputWritten = true;
                }
                if (__tmp50_outputWritten) __out.AppendLine(true);
                if (__tmp50_outputWritten)
                {
                    __out.AppendLine(false); //243:70
                }
            }
            else //244:4
            {
                bool __tmp57_outputWritten = false;
                string __tmp58_line = "		this.MModelGroup = new "; //245:1
                if (!string.IsNullOrEmpty(__tmp58_line))
                {
                    __out.Write(__tmp58_line);
                    __tmp57_outputWritten = true;
                }
                var __tmp59 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp59.Write(Properties.CoreNs);
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
                string __tmp60_line = ".MutableModelGroup();"; //245:45
                if (!string.IsNullOrEmpty(__tmp60_line))
                {
                    __out.Write(__tmp60_line);
                    __tmp57_outputWritten = true;
                }
                if (__tmp57_outputWritten) __out.AppendLine(true);
                if (__tmp57_outputWritten)
                {
                    __out.AppendLine(false); //245:66
                }
                bool __tmp62_outputWritten = false;
                string __tmp63_line = "		this.MModelGroup.AddReference("; //246:1
                if (!string.IsNullOrEmpty(__tmp63_line))
                {
                    __out.Write(__tmp63_line);
                    __tmp62_outputWritten = true;
                }
                var __tmp64 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp64.Write(Properties.MetaNs);
                var __tmp64Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp64.ToStringAndFree());
                bool __tmp64_last = __tmp64Reader.EndOfStream;
                while(!__tmp64_last)
                {
                    ReadOnlySpan<char> __tmp64_line = __tmp64Reader.ReadLine();
                    __tmp64_last = __tmp64Reader.EndOfStream;
                    if (!__tmp64_last || !__tmp64_line.IsEmpty)
                    {
                        __out.Write(__tmp64_line);
                        __tmp62_outputWritten = true;
                    }
                    if (!__tmp64_last) __out.AppendLine(true);
                }
                string __tmp65_line = ".MetaInstance.MModel.ToMutable(true));"; //246:52
                if (!string.IsNullOrEmpty(__tmp65_line))
                {
                    __out.Write(__tmp65_line);
                    __tmp62_outputWritten = true;
                }
                if (__tmp62_outputWritten) __out.AppendLine(true);
                if (__tmp62_outputWritten)
                {
                    __out.AppendLine(false); //246:90
                }
                bool __tmp67_outputWritten = false;
                string __tmp68_line = "		this.MModel = this.MModelGroup.CreateModel(\""; //247:1
                if (!string.IsNullOrEmpty(__tmp68_line))
                {
                    __out.Write(__tmp68_line);
                    __tmp67_outputWritten = true;
                }
                var __tmp69 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp69.Write(CSharpName(model));
                var __tmp69Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp69.ToStringAndFree());
                bool __tmp69_last = __tmp69Reader.EndOfStream;
                while(!__tmp69_last)
                {
                    ReadOnlySpan<char> __tmp69_line = __tmp69Reader.ReadLine();
                    __tmp69_last = __tmp69Reader.EndOfStream;
                    if (!__tmp69_last || !__tmp69_line.IsEmpty)
                    {
                        __out.Write(__tmp69_line);
                        __tmp67_outputWritten = true;
                    }
                    if (!__tmp69_last) __out.AppendLine(true);
                }
                string __tmp70_line = "\");"; //247:67
                if (!string.IsNullOrEmpty(__tmp70_line))
                {
                    __out.Write(__tmp70_line);
                    __tmp67_outputWritten = true;
                }
                if (__tmp67_outputWritten) __out.AppendLine(true);
                if (__tmp67_outputWritten)
                {
                    __out.AppendLine(false); //247:70
                }
            }
            __out.Write("	}"); //249:1
            __out.AppendLine(false); //249:3
            __out.AppendLine(true); //250:1
            __out.Write("	internal void Create()"); //251:1
            __out.AppendLine(false); //251:24
            __out.Write("	{"); //252:1
            __out.AppendLine(false); //252:3
            __out.Write("		lock (this)"); //253:1
            __out.AppendLine(false); //253:14
            __out.Write("		{"); //254:1
            __out.AppendLine(false); //254:4
            __out.Write("			if (this.creating || this.created) return;"); //255:1
            __out.AppendLine(false); //255:46
            __out.Write("			this.creating = true;"); //256:1
            __out.AppendLine(false); //256:25
            __out.Write("		}"); //257:1
            __out.AppendLine(false); //257:4
            __out.Write("		this.CreateInstances();"); //258:1
            __out.AppendLine(false); //258:26
            bool __tmp72_outputWritten = false;
            string __tmp71Prefix = "		"; //259:1
            var __tmp73 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp73.Write(CSharpName(model, ModelKind.ImplementationProvider));
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
            string __tmp74_line = ".Implementation."; //259:55
            if (!string.IsNullOrEmpty(__tmp74_line))
            {
                __out.Write(__tmp74_line);
                __tmp72_outputWritten = true;
            }
            var __tmp75 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp75.Write(CSharpName(model, ModelKind.BuilderInstance));
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
            string __tmp76_line = "(this);"; //259:116
            if (!string.IsNullOrEmpty(__tmp76_line))
            {
                __out.Write(__tmp76_line);
                __tmp72_outputWritten = true;
            }
            if (__tmp72_outputWritten) __out.AppendLine(true);
            if (__tmp72_outputWritten)
            {
                __out.AppendLine(false); //259:123
            }
            __out.Write("        foreach (global::MetaDslx.Modeling.MutableObject obj in this.MModel.Objects)"); //260:1
            __out.AppendLine(false); //260:85
            __out.Write("        {"); //261:1
            __out.AppendLine(false); //261:10
            __out.Write("            obj.MMakeCreated();"); //262:1
            __out.AppendLine(false); //262:32
            __out.Write("        }"); //263:1
            __out.AppendLine(false); //263:10
            __out.Write("		lock (this)"); //264:1
            __out.AppendLine(false); //264:14
            __out.Write("		{"); //265:1
            __out.AppendLine(false); //265:4
            __out.Write("			this.created = true;"); //266:1
            __out.AppendLine(false); //266:24
            __out.Write("		}"); //267:1
            __out.AppendLine(false); //267:4
            __out.Write("	}"); //268:1
            __out.AppendLine(false); //268:3
            __out.AppendLine(true); //269:1
            __out.Write("	internal void EvaluateLazyValues()"); //270:1
            __out.AppendLine(false); //270:36
            __out.Write("	{"); //271:1
            __out.AppendLine(false); //271:3
            __out.Write("		if (!this.created) return;"); //272:1
            __out.AppendLine(false); //272:29
            __out.Write("		this.MModel.EvaluateLazyValues();"); //273:1
            __out.AppendLine(false); //273:36
            __out.Write("	}"); //274:1
            __out.AppendLine(false); //274:3
            __out.AppendLine(true); //275:1
            __out.Write("	private void CreateInstances()"); //276:1
            __out.AppendLine(false); //276:32
            __out.Write("	{"); //277:1
            __out.AppendLine(false); //277:3
            bool __tmp78_outputWritten = false;
            string __tmp77Prefix = "		"; //278:1
            var __tmp79 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp79.Write(Properties.MetaNs);
            var __tmp79Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp79.ToStringAndFree());
            bool __tmp79_last = __tmp79Reader.EndOfStream;
            while(!__tmp79_last)
            {
                ReadOnlySpan<char> __tmp79_line = __tmp79Reader.ReadLine();
                __tmp79_last = __tmp79Reader.EndOfStream;
                if (!string.IsNullOrEmpty(__tmp77Prefix))
                {
                    __out.Write(__tmp77Prefix);
                    __tmp78_outputWritten = true;
                }
                if (!__tmp79_last || !__tmp79_line.IsEmpty)
                {
                    __out.Write(__tmp79_line);
                    __tmp78_outputWritten = true;
                }
                if (!__tmp79_last) __out.AppendLine(true);
            }
            string __tmp80_line = ".MetaFactory factory = new "; //278:22
            if (!string.IsNullOrEmpty(__tmp80_line))
            {
                __out.Write(__tmp80_line);
                __tmp78_outputWritten = true;
            }
            var __tmp81 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp81.Write(Properties.MetaNs);
            var __tmp81Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp81.ToStringAndFree());
            bool __tmp81_last = __tmp81Reader.EndOfStream;
            while(!__tmp81_last)
            {
                ReadOnlySpan<char> __tmp81_line = __tmp81Reader.ReadLine();
                __tmp81_last = __tmp81Reader.EndOfStream;
                if (!__tmp81_last || !__tmp81_line.IsEmpty)
                {
                    __out.Write(__tmp81_line);
                    __tmp78_outputWritten = true;
                }
                if (!__tmp81_last) __out.AppendLine(true);
            }
            string __tmp82_line = ".MetaFactory(this.MModel, "; //278:68
            if (!string.IsNullOrEmpty(__tmp82_line))
            {
                __out.Write(__tmp82_line);
                __tmp78_outputWritten = true;
            }
            var __tmp83 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp83.Write(Properties.CoreNs);
            var __tmp83Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp83.ToStringAndFree());
            bool __tmp83_last = __tmp83Reader.EndOfStream;
            while(!__tmp83_last)
            {
                ReadOnlySpan<char> __tmp83_line = __tmp83Reader.ReadLine();
                __tmp83_last = __tmp83Reader.EndOfStream;
                if (!__tmp83_last || !__tmp83_line.IsEmpty)
                {
                    __out.Write(__tmp83_line);
                    __tmp78_outputWritten = true;
                }
                if (!__tmp83_last) __out.AppendLine(true);
            }
            string __tmp84_line = ".ModelFactoryFlags.DontMakeObjectsCreated);"; //278:113
            if (!string.IsNullOrEmpty(__tmp84_line))
            {
                __out.Write(__tmp84_line);
                __tmp78_outputWritten = true;
            }
            if (__tmp78_outputWritten) __out.AppendLine(true);
            if (__tmp78_outputWritten)
            {
                __out.AppendLine(false); //278:156
            }
            if (!metaMetaModel) //279:4
            {
                bool __tmp86_outputWritten = false;
                string __tmp85Prefix = "		"; //280:1
                var __tmp87 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp87.Write(CSharpName(model, ModelKind.Factory));
                var __tmp87Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp87.ToStringAndFree());
                bool __tmp87_last = __tmp87Reader.EndOfStream;
                while(!__tmp87_last)
                {
                    ReadOnlySpan<char> __tmp87_line = __tmp87Reader.ReadLine();
                    __tmp87_last = __tmp87Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp85Prefix))
                    {
                        __out.Write(__tmp85Prefix);
                        __tmp86_outputWritten = true;
                    }
                    if (!__tmp87_last || !__tmp87_line.IsEmpty)
                    {
                        __out.Write(__tmp87_line);
                        __tmp86_outputWritten = true;
                    }
                    if (!__tmp87_last) __out.AppendLine(true);
                }
                string __tmp88_line = " constantFactory = new "; //280:40
                if (!string.IsNullOrEmpty(__tmp88_line))
                {
                    __out.Write(__tmp88_line);
                    __tmp86_outputWritten = true;
                }
                var __tmp89 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp89.Write(CSharpName(model, ModelKind.Factory));
                var __tmp89Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp89.ToStringAndFree());
                bool __tmp89_last = __tmp89Reader.EndOfStream;
                while(!__tmp89_last)
                {
                    ReadOnlySpan<char> __tmp89_line = __tmp89Reader.ReadLine();
                    __tmp89_last = __tmp89Reader.EndOfStream;
                    if (!__tmp89_last || !__tmp89_line.IsEmpty)
                    {
                        __out.Write(__tmp89_line);
                        __tmp86_outputWritten = true;
                    }
                    if (!__tmp89_last) __out.AppendLine(true);
                }
                string __tmp90_line = "(this.MModel, global::MetaDslx.Modeling.ModelFactoryFlags.DontMakeObjectsCreated);"; //280:100
                if (!string.IsNullOrEmpty(__tmp90_line))
                {
                    __out.Write(__tmp90_line);
                    __tmp86_outputWritten = true;
                }
                if (__tmp86_outputWritten) __out.AppendLine(true);
                if (__tmp86_outputWritten)
                {
                    __out.AppendLine(false); //280:182
                }
            }
            __out.AppendLine(true); //282:1
            var __loop16_results = 
                (from __loop16_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //283:9
                from cst in __Enumerate((__loop16_var1).GetEnumerator()).OfType<MetaConstant>() //283:39
                select new { __loop16_var1 = __loop16_var1, cst = cst}
                ).ToList(); //283:4
            for (int __loop16_iteration = 0; __loop16_iteration < __loop16_results.Count; ++__loop16_iteration)
            {
                var __tmp91 = __loop16_results[__loop16_iteration];
                var __loop16_var1 = __tmp91.__loop16_var1;
                var cst = __tmp91.cst;
                if (metaMetaModel) //284:5
                {
                    bool __tmp93_outputWritten = false;
                    string __tmp92Prefix = "		"; //285:1
                    var __tmp94 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp94.Write(CSharpName(cst, model, ClassKind.BuilderInstance));
                    var __tmp94Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp94.ToStringAndFree());
                    bool __tmp94_last = __tmp94Reader.EndOfStream;
                    while(!__tmp94_last)
                    {
                        ReadOnlySpan<char> __tmp94_line = __tmp94Reader.ReadLine();
                        __tmp94_last = __tmp94Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp92Prefix))
                        {
                            __out.Write(__tmp92Prefix);
                            __tmp93_outputWritten = true;
                        }
                        if (!__tmp94_last || !__tmp94_line.IsEmpty)
                        {
                            __out.Write(__tmp94_line);
                            __tmp93_outputWritten = true;
                        }
                        if (!__tmp94_last) __out.AppendLine(true);
                    }
                    string __tmp95_line = " = factory."; //285:53
                    if (!string.IsNullOrEmpty(__tmp95_line))
                    {
                        __out.Write(__tmp95_line);
                        __tmp93_outputWritten = true;
                    }
                    var __tmp96 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp96.Write(CSharpName(cst.Type, model, ClassKind.Immutable));
                    var __tmp96Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp96.ToStringAndFree());
                    bool __tmp96_last = __tmp96Reader.EndOfStream;
                    while(!__tmp96_last)
                    {
                        ReadOnlySpan<char> __tmp96_line = __tmp96Reader.ReadLine();
                        __tmp96_last = __tmp96Reader.EndOfStream;
                        if (!__tmp96_last || !__tmp96_line.IsEmpty)
                        {
                            __out.Write(__tmp96_line);
                            __tmp93_outputWritten = true;
                        }
                        if (!__tmp96_last) __out.AppendLine(true);
                    }
                    string __tmp97_line = "();"; //285:113
                    if (!string.IsNullOrEmpty(__tmp97_line))
                    {
                        __out.Write(__tmp97_line);
                        __tmp93_outputWritten = true;
                    }
                    if (__tmp93_outputWritten) __out.AppendLine(true);
                    if (__tmp93_outputWritten)
                    {
                        __out.AppendLine(false); //285:116
                    }
                }
                else //286:5
                {
                    bool __tmp99_outputWritten = false;
                    string __tmp98Prefix = "		"; //287:1
                    var __tmp100 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp100.Write(CSharpName(cst, model, ClassKind.BuilderInstance));
                    var __tmp100Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp100.ToStringAndFree());
                    bool __tmp100_last = __tmp100Reader.EndOfStream;
                    while(!__tmp100_last)
                    {
                        ReadOnlySpan<char> __tmp100_line = __tmp100Reader.ReadLine();
                        __tmp100_last = __tmp100Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp98Prefix))
                        {
                            __out.Write(__tmp98Prefix);
                            __tmp99_outputWritten = true;
                        }
                        if (!__tmp100_last || !__tmp100_line.IsEmpty)
                        {
                            __out.Write(__tmp100_line);
                            __tmp99_outputWritten = true;
                        }
                        if (!__tmp100_last) __out.AppendLine(true);
                    }
                    string __tmp101_line = " = constantFactory."; //287:53
                    if (!string.IsNullOrEmpty(__tmp101_line))
                    {
                        __out.Write(__tmp101_line);
                        __tmp99_outputWritten = true;
                    }
                    var __tmp102 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp102.Write(CSharpName(cst.Type, model, ClassKind.Immutable));
                    var __tmp102Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp102.ToStringAndFree());
                    bool __tmp102_last = __tmp102Reader.EndOfStream;
                    while(!__tmp102_last)
                    {
                        ReadOnlySpan<char> __tmp102_line = __tmp102Reader.ReadLine();
                        __tmp102_last = __tmp102Reader.EndOfStream;
                        if (!__tmp102_last || !__tmp102_line.IsEmpty)
                        {
                            __out.Write(__tmp102_line);
                            __tmp99_outputWritten = true;
                        }
                        if (!__tmp102_last) __out.AppendLine(true);
                    }
                    string __tmp103_line = "();"; //287:121
                    if (!string.IsNullOrEmpty(__tmp103_line))
                    {
                        __out.Write(__tmp103_line);
                        __tmp99_outputWritten = true;
                    }
                    if (__tmp99_outputWritten) __out.AppendLine(true);
                    if (__tmp99_outputWritten)
                    {
                        __out.AppendLine(false); //287:124
                    }
                }
                if (cst.DotNetName != null) //289:5
                {
                    bool __tmp105_outputWritten = false;
                    string __tmp104Prefix = "		"; //290:1
                    var __tmp106 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp106.Write(CSharpName(cst, model, ClassKind.BuilderInstance));
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
                    string __tmp107_line = ".MName = \""; //290:53
                    if (!string.IsNullOrEmpty(__tmp107_line))
                    {
                        __out.Write(__tmp107_line);
                        __tmp105_outputWritten = true;
                    }
                    var __tmp108 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp108.Write(cst.Name);
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
                    string __tmp109_line = "\";"; //290:73
                    if (!string.IsNullOrEmpty(__tmp109_line))
                    {
                        __out.Write(__tmp109_line);
                        __tmp105_outputWritten = true;
                    }
                    if (__tmp105_outputWritten) __out.AppendLine(true);
                    if (__tmp105_outputWritten)
                    {
                        __out.AppendLine(false); //290:75
                    }
                    bool __tmp111_outputWritten = false;
                    string __tmp110Prefix = "		"; //291:1
                    var __tmp112 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp112.Write(CSharpName(cst, model, ClassKind.BuilderInstance));
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
                    string __tmp113_line = ".DotNetName = \""; //291:53
                    if (!string.IsNullOrEmpty(__tmp113_line))
                    {
                        __out.Write(__tmp113_line);
                        __tmp111_outputWritten = true;
                    }
                    var __tmp114 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp114.Write(cst.DotNetName);
                    var __tmp114Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp114.ToStringAndFree());
                    bool __tmp114_last = __tmp114Reader.EndOfStream;
                    while(!__tmp114_last)
                    {
                        ReadOnlySpan<char> __tmp114_line = __tmp114Reader.ReadLine();
                        __tmp114_last = __tmp114Reader.EndOfStream;
                        if (!__tmp114_last || !__tmp114_line.IsEmpty)
                        {
                            __out.Write(__tmp114_line);
                            __tmp111_outputWritten = true;
                        }
                        if (!__tmp114_last) __out.AppendLine(true);
                    }
                    string __tmp115_line = "\";"; //291:84
                    if (!string.IsNullOrEmpty(__tmp115_line))
                    {
                        __out.Write(__tmp115_line);
                        __tmp111_outputWritten = true;
                    }
                    if (__tmp111_outputWritten) __out.AppendLine(true);
                    if (__tmp111_outputWritten)
                    {
                        __out.AppendLine(false); //291:86
                    }
                }
            }
            __out.AppendLine(true); //294:1
            var __loop17_results = 
                (from obj in __Enumerate((instances).GetEnumerator()) //295:9
                select new { obj = obj}
                ).ToList(); //295:4
            for (int __loop17_iteration = 0; __loop17_iteration < __loop17_results.Count; ++__loop17_iteration)
            {
                var __tmp116 = __loop17_results[__loop17_iteration];
                var obj = __tmp116.obj;
                bool __tmp118_outputWritten = false;
                string __tmp117Prefix = "		"; //296:1
                var __tmp119 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp119.Write(GenerateInstance(model, metaMetaModel, obj, instanceNames));
                var __tmp119Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp119.ToStringAndFree());
                bool __tmp119_last = __tmp119Reader.EndOfStream;
                while(!__tmp119_last)
                {
                    ReadOnlySpan<char> __tmp119_line = __tmp119Reader.ReadLine();
                    __tmp119_last = __tmp119Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp117Prefix))
                    {
                        __out.Write(__tmp117Prefix);
                        __tmp118_outputWritten = true;
                    }
                    if (!__tmp119_last || !__tmp119_line.IsEmpty)
                    {
                        __out.Write(__tmp119_line);
                        __tmp118_outputWritten = true;
                    }
                    if (!__tmp119_last || __tmp118_outputWritten) __out.AppendLine(true);
                }
                if (__tmp118_outputWritten)
                {
                    __out.AppendLine(false); //296:63
                }
            }
            __out.AppendLine(true); //298:1
            var __loop18_results = 
                (from obj in __Enumerate((instances).GetEnumerator()) //299:9
                select new { obj = obj}
                ).ToList(); //299:4
            for (int __loop18_iteration = 0; __loop18_iteration < __loop18_results.Count; ++__loop18_iteration)
            {
                var __tmp120 = __loop18_results[__loop18_iteration];
                var obj = __tmp120.obj;
                bool __tmp122_outputWritten = false;
                string __tmp121Prefix = "		"; //300:1
                var __tmp123 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp123.Write(GenerateInstanceProperties(model, metaMetaModel, obj, instanceNames));
                var __tmp123Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp123.ToStringAndFree());
                bool __tmp123_last = __tmp123Reader.EndOfStream;
                while(!__tmp123_last)
                {
                    ReadOnlySpan<char> __tmp123_line = __tmp123Reader.ReadLine();
                    __tmp123_last = __tmp123Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp121Prefix))
                    {
                        __out.Write(__tmp121Prefix);
                        __tmp122_outputWritten = true;
                    }
                    if (!__tmp123_last || !__tmp123_line.IsEmpty)
                    {
                        __out.Write(__tmp123_line);
                        __tmp122_outputWritten = true;
                    }
                    if (!__tmp123_last || __tmp122_outputWritten) __out.AppendLine(true);
                }
                if (__tmp122_outputWritten)
                {
                    __out.AppendLine(false); //300:73
                }
            }
            __out.Write("	}"); //302:1
            __out.AppendLine(false); //302:3
            __out.Write("}"); //303:1
            __out.AppendLine(false); //303:2
            return __out.ToStringAndFree();
        }

        public string GenerateInstanceDeclaration(MetaModel model, bool metaMetaModel, ImmutableObject obj, ImmutableDictionary<ImmutableObject,string> instanceNames) //306:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            if (obj != null && obj.MMetaClass != null && instanceNames.ContainsKey(obj)) //307:2
            {
                string name = instanceNames[obj]; //308:3
                if (metaMetaModel) //309:3
                {
                    if (name.StartsWith("__")) //310:4
                    {
                        bool __tmp2_outputWritten = false;
                        string __tmp3_line = "private "; //311:1
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
                        string __tmp5_line = " "; //311:62
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
                        string __tmp7_line = ";"; //311:69
                        if (!string.IsNullOrEmpty(__tmp7_line))
                        {
                            __out.Write(__tmp7_line);
                            __tmp2_outputWritten = true;
                        }
                        if (__tmp2_outputWritten) __out.AppendLine(true);
                        if (__tmp2_outputWritten)
                        {
                            __out.AppendLine(false); //311:70
                        }
                    }
                    else //312:4
                    {
                        bool __tmp9_outputWritten = false;
                        string __tmp10_line = "internal "; //313:1
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
                        string __tmp12_line = " "; //313:63
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
                        string __tmp14_line = ";"; //313:70
                        if (!string.IsNullOrEmpty(__tmp14_line))
                        {
                            __out.Write(__tmp14_line);
                            __tmp9_outputWritten = true;
                        }
                        if (__tmp9_outputWritten) __out.AppendLine(true);
                        if (__tmp9_outputWritten)
                        {
                            __out.AppendLine(false); //313:71
                        }
                    }
                }
                else //315:3
                {
                    if (name.StartsWith("__")) //316:4
                    {
                        bool __tmp16_outputWritten = false;
                        string __tmp17_line = "private "; //317:1
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
                        string __tmp19_line = " "; //317:68
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
                        string __tmp21_line = ";"; //317:75
                        if (!string.IsNullOrEmpty(__tmp21_line))
                        {
                            __out.Write(__tmp21_line);
                            __tmp16_outputWritten = true;
                        }
                        if (__tmp16_outputWritten) __out.AppendLine(true);
                        if (__tmp16_outputWritten)
                        {
                            __out.AppendLine(false); //317:76
                        }
                    }
                    else //318:4
                    {
                        bool __tmp23_outputWritten = false;
                        string __tmp24_line = "internal "; //319:1
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
                        string __tmp26_line = " "; //319:69
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
                        string __tmp28_line = ";"; //319:76
                        if (!string.IsNullOrEmpty(__tmp28_line))
                        {
                            __out.Write(__tmp28_line);
                            __tmp23_outputWritten = true;
                        }
                        if (__tmp23_outputWritten) __out.AppendLine(true);
                        if (__tmp23_outputWritten)
                        {
                            __out.AppendLine(false); //319:77
                        }
                    }
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateInstance(MetaModel model, bool metaMetaModel, ImmutableObject obj, ImmutableDictionary<ImmutableObject,string> instanceNames) //325:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            if (obj != null && obj.MMetaClass != null && instanceNames.ContainsKey(obj)) //326:2
            {
                string name = instanceNames[obj]; //327:3
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
                string __tmp4_line = " = factory."; //328:7
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
                string __tmp6_line = "();"; //328:73
                if (!string.IsNullOrEmpty(__tmp6_line))
                {
                    __out.Write(__tmp6_line);
                    __tmp2_outputWritten = true;
                }
                if (__tmp2_outputWritten) __out.AppendLine(true);
                if (__tmp2_outputWritten)
                {
                    __out.AppendLine(false); //328:76
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateInstanceProperties(MetaModel model, bool metaMetaModel, ImmutableObject obj, ImmutableDictionary<ImmutableObject,string> instanceNames) //332:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            if (obj != null && obj.MMetaClass != null && instanceNames.ContainsKey(obj)) //333:2
            {
                var __loop19_results = 
                    (from __loop19_var1 in __Enumerate((obj).GetEnumerator()) //334:8
                    from prop in __Enumerate((__loop19_var1.MProperties).GetEnumerator()) //334:13
                    where !prop.IsDerived && !prop.IsDerivedUnion //334:30
                    select new { __loop19_var1 = __loop19_var1, prop = prop}
                    ).ToList(); //334:3
                for (int __loop19_iteration = 0; __loop19_iteration < __loop19_results.Count; ++__loop19_iteration)
                {
                    var __tmp1 = __loop19_results[__loop19_iteration];
                    var __loop19_var1 = __tmp1.__loop19_var1;
                    var prop = __tmp1.prop;
                    if (obj is MetaConstant && prop.Name == "Value") //335:4
                    {
                        string name = instanceNames[obj]; //336:5
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
                        string __tmp5_line = ".SetValueLazy(() => "; //337:7
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
                        string __tmp7_line = ");"; //337:93
                        if (!string.IsNullOrEmpty(__tmp7_line))
                        {
                            __out.Write(__tmp7_line);
                            __tmp3_outputWritten = true;
                        }
                        if (__tmp3_outputWritten) __out.AppendLine(true);
                        if (__tmp3_outputWritten)
                        {
                            __out.AppendLine(false); //337:95
                        }
                    }
                    else //338:4
                    {
                        object propValue = obj.MGet(prop); //339:5
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
                            __out.AppendLine(false); //340:91
                        }
                    }
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateInstancePropertyValue(MetaModel model, bool metaMetaModel, ImmutableObject obj, ModelProperty prop, object value, ImmutableDictionary<ImmutableObject,string> instanceNames) //346:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string name = instanceNames[obj]; //347:2
            ImmutableObject valueObject = value as ImmutableObject; //348:2
            MetaDeclaration valueDecl = value as MetaDeclaration; //349:2
            IEnumerable<object> valueCollection = value as IEnumerable<object>; //350:2
            if (value == null) //351:2
            {
                if (prop.MutableType != null && prop.MutableType.IsClass) //352:3
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
                    string __tmp4_line = "."; //353:7
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
                    string __tmp6_line = " = null;"; //353:19
                    if (!string.IsNullOrEmpty(__tmp6_line))
                    {
                        __out.Write(__tmp6_line);
                        __tmp2_outputWritten = true;
                    }
                    if (__tmp2_outputWritten) __out.AppendLine(true);
                    if (__tmp2_outputWritten)
                    {
                        __out.AppendLine(false); //353:27
                    }
                }
                else //354:3
                {
                    bool __tmp8_outputWritten = false;
                    string __tmp9_line = "// "; //355:1
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
                    string __tmp11_line = "."; //355:10
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
                    string __tmp13_line = " = null;"; //355:22
                    if (!string.IsNullOrEmpty(__tmp13_line))
                    {
                        __out.Write(__tmp13_line);
                        __tmp8_outputWritten = true;
                    }
                    if (__tmp8_outputWritten) __out.AppendLine(true);
                    if (__tmp8_outputWritten)
                    {
                        __out.AppendLine(false); //355:30
                    }
                }
            }
            else if (value is string) //357:2
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
                string __tmp17_line = "."; //358:7
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
                string __tmp19_line = " = \""; //358:19
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
                string __tmp21_line = "\";"; //358:50
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Write(__tmp21_line);
                    __tmp15_outputWritten = true;
                }
                if (__tmp15_outputWritten) __out.AppendLine(true);
                if (__tmp15_outputWritten)
                {
                    __out.AppendLine(false); //358:52
                }
            }
            else if (value is bool) //359:2
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
                string __tmp25_line = "."; //360:7
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
                string __tmp27_line = " = "; //360:19
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
                string __tmp29_line = ";"; //360:50
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Write(__tmp29_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //360:51
                }
            }
            else if (value.GetType().IsPrimitive) //361:2
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
                string __tmp33_line = "."; //362:7
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
                string __tmp35_line = " = "; //362:19
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
                string __tmp37_line = ";"; //362:40
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Write(__tmp37_line);
                    __tmp31_outputWritten = true;
                }
                if (__tmp31_outputWritten) __out.AppendLine(true);
                if (__tmp31_outputWritten)
                {
                    __out.AppendLine(false); //362:41
                }
            }
            else if (value is MetaAttribute) //363:2
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
                string __tmp41_line = "."; //364:7
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
                string __tmp43_line = " = "; //364:19
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
                string __tmp45_line = ";"; //364:72
                if (!string.IsNullOrEmpty(__tmp45_line))
                {
                    __out.Write(__tmp45_line);
                    __tmp39_outputWritten = true;
                }
                if (__tmp39_outputWritten) __out.AppendLine(true);
                if (__tmp39_outputWritten)
                {
                    __out.AppendLine(false); //364:73
                }
            }
            else if (value is Enum) //365:2
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
                string __tmp49_line = "."; //366:7
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
                string __tmp51_line = " = "; //366:19
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
                string __tmp53_line = ";"; //366:58
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Write(__tmp53_line);
                    __tmp47_outputWritten = true;
                }
                if (__tmp47_outputWritten) __out.AppendLine(true);
                if (__tmp47_outputWritten)
                {
                    __out.AppendLine(false); //366:59
                }
            }
            else if (value is Type) //367:2
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
                string __tmp57_line = "."; //368:7
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
                string __tmp59_line = " = typeof("; //368:19
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
                string __tmp61_line = ");"; //368:53
                if (!string.IsNullOrEmpty(__tmp61_line))
                {
                    __out.Write(__tmp61_line);
                    __tmp55_outputWritten = true;
                }
                if (__tmp55_outputWritten) __out.AppendLine(true);
                if (__tmp55_outputWritten)
                {
                    __out.AppendLine(false); //368:55
                }
            }
            else if (value is MetaExternalType) //369:2
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
                string __tmp65_line = ".Set"; //370:7
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
                string __tmp67_line = "Lazy(() => "; //370:22
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
                string __tmp69_line = ");"; //370:80
                if (!string.IsNullOrEmpty(__tmp69_line))
                {
                    __out.Write(__tmp69_line);
                    __tmp63_outputWritten = true;
                }
                if (__tmp63_outputWritten) __out.AppendLine(true);
                if (__tmp63_outputWritten)
                {
                    __out.AppendLine(false); //370:82
                }
            }
            else if (value is MetaPrimitiveType) //371:2
            {
                if (metaMetaModel) //372:3
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
                    string __tmp73_line = ".Set"; //373:7
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
                    string __tmp75_line = "Lazy(() => "; //373:22
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
                    string __tmp77_line = ");"; //373:115
                    if (!string.IsNullOrEmpty(__tmp77_line))
                    {
                        __out.Write(__tmp77_line);
                        __tmp71_outputWritten = true;
                    }
                    if (__tmp71_outputWritten) __out.AppendLine(true);
                    if (__tmp71_outputWritten)
                    {
                        __out.AppendLine(false); //373:117
                    }
                }
                else //374:3
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
                    string __tmp81_line = ".Set"; //375:7
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
                    string __tmp83_line = "Lazy(() => "; //375:22
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
                    string __tmp85_line = ".ToMutable());"; //375:114
                    if (!string.IsNullOrEmpty(__tmp85_line))
                    {
                        __out.Write(__tmp85_line);
                        __tmp79_outputWritten = true;
                    }
                    if (__tmp79_outputWritten) __out.AppendLine(true);
                    if (__tmp79_outputWritten)
                    {
                        __out.AppendLine(false); //375:128
                    }
                }
            }
            else if (valueObject != null && instanceNames.ContainsKey(valueObject)) //377:2
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
                string __tmp89_line = ".Set"; //378:7
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
                string __tmp91_line = "Lazy(() => "; //378:22
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
                string __tmp93_line = ");"; //378:61
                if (!string.IsNullOrEmpty(__tmp93_line))
                {
                    __out.Write(__tmp93_line);
                    __tmp87_outputWritten = true;
                }
                if (__tmp87_outputWritten) __out.AppendLine(true);
                if (__tmp87_outputWritten)
                {
                    __out.AppendLine(false); //378:63
                }
            }
            else if (valueDecl != null && valueDecl is MetaType) //379:2
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
                string __tmp97_line = ".Set"; //380:7
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
                string __tmp99_line = "Lazy(() => "; //380:22
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
                string __tmp101_line = ");"; //380:109
                if (!string.IsNullOrEmpty(__tmp101_line))
                {
                    __out.Write(__tmp101_line);
                    __tmp95_outputWritten = true;
                }
                if (__tmp95_outputWritten) __out.AppendLine(true);
                if (__tmp95_outputWritten)
                {
                    __out.AppendLine(false); //380:111
                }
            }
            else if (valueDecl != null && valueDecl is MetaConstant) //381:2
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
                string __tmp105_line = ".Set"; //382:7
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
                string __tmp107_line = "Lazy(() => "; //382:22
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
                string __tmp109_line = ");"; //382:113
                if (!string.IsNullOrEmpty(__tmp109_line))
                {
                    __out.Write(__tmp109_line);
                    __tmp103_outputWritten = true;
                }
                if (__tmp103_outputWritten) __out.AppendLine(true);
                if (__tmp103_outputWritten)
                {
                    __out.AppendLine(false); //382:115
                }
            }
            else if (valueCollection != null) //383:2
            {
                var __loop20_results = 
                    (from cvalue in __Enumerate((valueCollection).GetEnumerator()) //384:8
                    select new { cvalue = cvalue}
                    ).ToList(); //384:3
                for (int __loop20_iteration = 0; __loop20_iteration < __loop20_results.Count; ++__loop20_iteration)
                {
                    var __tmp110 = __loop20_results[__loop20_iteration];
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
                        __out.AppendLine(false); //385:98
                    }
                }
            }
            else //387:2
            {
                bool __tmp115_outputWritten = false;
                string __tmp116_line = "// TODO: "; //388:1
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
                string __tmp118_line = "."; //388:16
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
                    __out.AppendLine(false); //388:28
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateInstancePropertyCollectionValue(MetaModel model, bool metaMetaModel, ImmutableObject obj, ModelProperty prop, object value, ImmutableDictionary<ImmutableObject,string> instanceNames) //392:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string name = instanceNames[obj]; //393:2
            ImmutableObject valueObject = value as ImmutableObject; //394:2
            MetaDeclaration valueDecl = value as MetaDeclaration; //395:2
            IEnumerable<object> valueCollection = value as IEnumerable<object>; //396:2
            if (value == null) //397:2
            {
                if (prop.MutableType != null && prop.MutableType.IsClass) //398:3
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
                    string __tmp4_line = "."; //399:7
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
                    string __tmp6_line = ".Add(null);"; //399:19
                    if (!string.IsNullOrEmpty(__tmp6_line))
                    {
                        __out.Write(__tmp6_line);
                        __tmp2_outputWritten = true;
                    }
                    if (__tmp2_outputWritten) __out.AppendLine(true);
                    if (__tmp2_outputWritten)
                    {
                        __out.AppendLine(false); //399:30
                    }
                }
                else //400:3
                {
                    bool __tmp8_outputWritten = false;
                    string __tmp9_line = "// "; //401:1
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
                    string __tmp11_line = "."; //401:10
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
                    string __tmp13_line = ".Add(null);"; //401:22
                    if (!string.IsNullOrEmpty(__tmp13_line))
                    {
                        __out.Write(__tmp13_line);
                        __tmp8_outputWritten = true;
                    }
                    if (__tmp8_outputWritten) __out.AppendLine(true);
                    if (__tmp8_outputWritten)
                    {
                        __out.AppendLine(false); //401:33
                    }
                }
            }
            else if (value is string) //403:2
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
                string __tmp17_line = "."; //404:7
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
                string __tmp19_line = ".Add(\""; //404:19
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
                string __tmp21_line = "\");"; //404:52
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Write(__tmp21_line);
                    __tmp15_outputWritten = true;
                }
                if (__tmp15_outputWritten) __out.AppendLine(true);
                if (__tmp15_outputWritten)
                {
                    __out.AppendLine(false); //404:55
                }
            }
            else if (value is bool) //405:2
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
                string __tmp25_line = "."; //406:7
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
                string __tmp27_line = ".Add("; //406:19
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
                string __tmp29_line = ");"; //406:52
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Write(__tmp29_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //406:54
                }
            }
            else if (value.GetType().IsPrimitive) //407:2
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
                string __tmp33_line = "."; //408:7
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
                string __tmp35_line = ".Add("; //408:19
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
                string __tmp37_line = ");"; //408:42
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Write(__tmp37_line);
                    __tmp31_outputWritten = true;
                }
                if (__tmp31_outputWritten) __out.AppendLine(true);
                if (__tmp31_outputWritten)
                {
                    __out.AppendLine(false); //408:44
                }
            }
            else if (value is MetaAttribute) //409:2
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
                string __tmp41_line = "."; //410:7
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
                string __tmp43_line = ".Add("; //410:19
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
                string __tmp45_line = ");"; //410:74
                if (!string.IsNullOrEmpty(__tmp45_line))
                {
                    __out.Write(__tmp45_line);
                    __tmp39_outputWritten = true;
                }
                if (__tmp39_outputWritten) __out.AppendLine(true);
                if (__tmp39_outputWritten)
                {
                    __out.AppendLine(false); //410:76
                }
            }
            else if (value is Enum) //411:2
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
                string __tmp49_line = "."; //412:7
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
                string __tmp51_line = ".Add("; //412:19
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
                string __tmp53_line = ");"; //412:60
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Write(__tmp53_line);
                    __tmp47_outputWritten = true;
                }
                if (__tmp47_outputWritten) __out.AppendLine(true);
                if (__tmp47_outputWritten)
                {
                    __out.AppendLine(false); //412:62
                }
            }
            else if (value is Type) //413:2
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
                string __tmp57_line = "."; //414:7
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
                string __tmp59_line = " = typeof("; //414:19
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
                string __tmp61_line = ");"; //414:53
                if (!string.IsNullOrEmpty(__tmp61_line))
                {
                    __out.Write(__tmp61_line);
                    __tmp55_outputWritten = true;
                }
                if (__tmp55_outputWritten) __out.AppendLine(true);
                if (__tmp55_outputWritten)
                {
                    __out.AppendLine(false); //414:55
                }
            }
            else if (value is MetaExternalType) //415:2
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
                string __tmp65_line = "."; //416:7
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
                string __tmp67_line = ".AddLazy(() => "; //416:19
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
                string __tmp69_line = ");"; //416:81
                if (!string.IsNullOrEmpty(__tmp69_line))
                {
                    __out.Write(__tmp69_line);
                    __tmp63_outputWritten = true;
                }
                if (__tmp63_outputWritten) __out.AppendLine(true);
                if (__tmp63_outputWritten)
                {
                    __out.AppendLine(false); //416:83
                }
            }
            else if (value is MetaPrimitiveType) //417:2
            {
                if (metaMetaModel) //418:3
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
                    string __tmp73_line = "."; //419:7
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
                    string __tmp75_line = ".AddLazy(() => "; //419:19
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
                    string __tmp77_line = ");"; //419:116
                    if (!string.IsNullOrEmpty(__tmp77_line))
                    {
                        __out.Write(__tmp77_line);
                        __tmp71_outputWritten = true;
                    }
                    if (__tmp71_outputWritten) __out.AppendLine(true);
                    if (__tmp71_outputWritten)
                    {
                        __out.AppendLine(false); //419:118
                    }
                }
                else //420:3
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
                    string __tmp81_line = "."; //421:7
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
                    string __tmp83_line = ".AddLazy(() => "; //421:19
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
                    string __tmp85_line = ".ToMutable());"; //421:115
                    if (!string.IsNullOrEmpty(__tmp85_line))
                    {
                        __out.Write(__tmp85_line);
                        __tmp79_outputWritten = true;
                    }
                    if (__tmp79_outputWritten) __out.AppendLine(true);
                    if (__tmp79_outputWritten)
                    {
                        __out.AppendLine(false); //421:129
                    }
                }
            }
            else if (valueObject != null && instanceNames.ContainsKey(valueObject)) //423:2
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
                string __tmp89_line = "."; //424:7
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
                string __tmp91_line = ".AddLazy(() => "; //424:19
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
                string __tmp93_line = ");"; //424:62
                if (!string.IsNullOrEmpty(__tmp93_line))
                {
                    __out.Write(__tmp93_line);
                    __tmp87_outputWritten = true;
                }
                if (__tmp87_outputWritten) __out.AppendLine(true);
                if (__tmp87_outputWritten)
                {
                    __out.AppendLine(false); //424:64
                }
            }
            else if (valueDecl != null && valueDecl is MetaType) //425:2
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
                string __tmp97_line = "."; //426:7
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
                string __tmp99_line = ".AddLazy(() => "; //426:19
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
                string __tmp101_line = ");"; //426:110
                if (!string.IsNullOrEmpty(__tmp101_line))
                {
                    __out.Write(__tmp101_line);
                    __tmp95_outputWritten = true;
                }
                if (__tmp95_outputWritten) __out.AppendLine(true);
                if (__tmp95_outputWritten)
                {
                    __out.AppendLine(false); //426:112
                }
            }
            else if (valueDecl != null && valueDecl is MetaConstant) //427:2
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
                string __tmp105_line = "."; //428:7
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
                string __tmp107_line = ".AddLazy(() => "; //428:19
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
                string __tmp109_line = ");"; //428:114
                if (!string.IsNullOrEmpty(__tmp109_line))
                {
                    __out.Write(__tmp109_line);
                    __tmp103_outputWritten = true;
                }
                if (__tmp103_outputWritten) __out.AppendLine(true);
                if (__tmp103_outputWritten)
                {
                    __out.AppendLine(false); //428:116
                }
            }
            else //429:2
            {
                bool __tmp111_outputWritten = false;
                string __tmp112_line = "// TODO: "; //430:1
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
                string __tmp114_line = "."; //430:16
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
                    __out.AppendLine(false); //430:28
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateFactory(MetaModel model) //434:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //435:2
            bool metaMetaModel = IsMetaMetaModel(model); //436:2
            __out.Write("/// <summary>"); //437:1
            __out.AppendLine(false); //437:14
            __out.Write("/// Factory class for creating instances of model elements."); //438:1
            __out.AppendLine(false); //438:60
            __out.Write("/// </summary>"); //439:1
            __out.AppendLine(false); //439:15
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //440:1
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
            string __tmp5_line = " : "; //440:51
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
            string __tmp7_line = ".ModelFactoryBase"; //440:73
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //440:90
            }
            __out.Write("{"); //441:1
            __out.AppendLine(false); //441:2
            bool __tmp9_outputWritten = false;
            string __tmp10_line = "	public "; //442:1
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
            string __tmp12_line = "("; //442:46
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
            string __tmp14_line = ".MutableModel model, "; //442:66
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
            string __tmp16_line = ".ModelFactoryFlags flags = "; //442:106
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
            string __tmp18_line = ".ModelFactoryFlags.None)"; //442:152
            if (!string.IsNullOrEmpty(__tmp18_line))
            {
                __out.Write(__tmp18_line);
                __tmp9_outputWritten = true;
            }
            if (__tmp9_outputWritten) __out.AppendLine(true);
            if (__tmp9_outputWritten)
            {
                __out.AppendLine(false); //442:176
            }
            __out.Write("		: base(model, flags)"); //443:1
            __out.AppendLine(false); //443:23
            __out.Write("	{"); //444:1
            __out.AppendLine(false); //444:3
            bool __tmp20_outputWritten = false;
            string __tmp19Prefix = "		"; //445:1
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
            string __tmp22_line = ".Initialize();"; //445:43
            if (!string.IsNullOrEmpty(__tmp22_line))
            {
                __out.Write(__tmp22_line);
                __tmp20_outputWritten = true;
            }
            if (__tmp20_outputWritten) __out.AppendLine(true);
            if (__tmp20_outputWritten)
            {
                __out.AppendLine(false); //445:57
            }
            __out.Write("	}"); //446:1
            __out.AppendLine(false); //446:3
            __out.AppendLine(true); //447:1
            bool __tmp24_outputWritten = false;
            string __tmp25_line = "	public override "; //448:1
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
            string __tmp27_line = ".IMetaModel MMetaModel => "; //448:37
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
            string __tmp29_line = ".MMetaModel;"; //448:116
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Write(__tmp29_line);
                __tmp24_outputWritten = true;
            }
            if (__tmp24_outputWritten) __out.AppendLine(true);
            if (__tmp24_outputWritten)
            {
                __out.AppendLine(false); //448:128
            }
            __out.AppendLine(true); //449:1
            bool __tmp31_outputWritten = false;
            string __tmp32_line = "	public override "; //450:1
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
            string __tmp34_line = ".MutableObject Create(string type)"; //450:37
            if (!string.IsNullOrEmpty(__tmp34_line))
            {
                __out.Write(__tmp34_line);
                __tmp31_outputWritten = true;
            }
            if (__tmp31_outputWritten) __out.AppendLine(true);
            if (__tmp31_outputWritten)
            {
                __out.AppendLine(false); //450:71
            }
            __out.Write("	{"); //451:1
            __out.AppendLine(false); //451:3
            __out.Write("		switch (type)"); //452:1
            __out.AppendLine(false); //452:16
            __out.Write("		{"); //453:1
            __out.AppendLine(false); //453:4
            var __loop21_results = 
                (from __loop21_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //454:10
                from cls in __Enumerate((__loop21_var1).GetEnumerator()).OfType<MetaClass>() //454:40
                select new { __loop21_var1 = __loop21_var1, cls = cls}
                ).ToList(); //454:5
            for (int __loop21_iteration = 0; __loop21_iteration < __loop21_results.Count; ++__loop21_iteration)
            {
                var __tmp35 = __loop21_results[__loop21_iteration];
                var __loop21_var1 = __tmp35.__loop21_var1;
                var cls = __tmp35.cls;
                if (!cls.IsAbstract) //455:6
                {
                    bool __tmp37_outputWritten = false;
                    string __tmp38_line = "			case \""; //456:1
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
                    string __tmp40_line = "\": return this."; //456:33
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
                    string __tmp42_line = "();"; //456:71
                    if (!string.IsNullOrEmpty(__tmp42_line))
                    {
                        __out.Write(__tmp42_line);
                        __tmp37_outputWritten = true;
                    }
                    if (__tmp37_outputWritten) __out.AppendLine(true);
                    if (__tmp37_outputWritten)
                    {
                        __out.AppendLine(false); //456:74
                    }
                }
            }
            __out.Write("			default:"); //459:1
            __out.AppendLine(false); //459:12
            bool __tmp44_outputWritten = false;
            string __tmp45_line = "				throw new "; //460:1
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
            string __tmp47_line = ".ModelException("; //460:34
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
            string __tmp49_line = ".ModelErrorCode.ERR_UnknownTypeName.ToDiagnosticWithNoLocation(type));"; //460:69
            if (!string.IsNullOrEmpty(__tmp49_line))
            {
                __out.Write(__tmp49_line);
                __tmp44_outputWritten = true;
            }
            if (__tmp44_outputWritten) __out.AppendLine(true);
            if (__tmp44_outputWritten)
            {
                __out.AppendLine(false); //460:139
            }
            __out.Write("		}"); //461:1
            __out.AppendLine(false); //461:4
            __out.Write("	}"); //462:1
            __out.AppendLine(false); //462:3
            var __loop22_results = 
                (from __loop22_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //463:8
                from cls in __Enumerate((__loop22_var1).GetEnumerator()).OfType<MetaClass>() //463:38
                select new { __loop22_var1 = __loop22_var1, cls = cls}
                ).ToList(); //463:3
            for (int __loop22_iteration = 0; __loop22_iteration < __loop22_results.Count; ++__loop22_iteration)
            {
                var __tmp50 = __loop22_results[__loop22_iteration];
                var __loop22_var1 = __tmp50.__loop22_var1;
                var cls = __tmp50.cls;
                if (!cls.IsAbstract) //464:4
                {
                    __out.AppendLine(true); //465:1
                    __out.Write("	/// <summary>"); //466:1
                    __out.AppendLine(false); //466:15
                    bool __tmp52_outputWritten = false;
                    string __tmp53_line = "	/// Creates a new instance of "; //467:1
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
                    string __tmp55_line = "."; //467:55
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Write(__tmp55_line);
                        __tmp52_outputWritten = true;
                    }
                    if (__tmp52_outputWritten) __out.AppendLine(true);
                    if (__tmp52_outputWritten)
                    {
                        __out.AppendLine(false); //467:56
                    }
                    __out.Write("	/// </summary>"); //468:1
                    __out.AppendLine(false); //468:16
                    bool __tmp57_outputWritten = false;
                    string __tmp58_line = "	public "; //469:1
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
                    string __tmp60_line = " "; //469:51
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
                    string __tmp62_line = "()"; //469:100
                    if (!string.IsNullOrEmpty(__tmp62_line))
                    {
                        __out.Write(__tmp62_line);
                        __tmp57_outputWritten = true;
                    }
                    if (__tmp57_outputWritten) __out.AppendLine(true);
                    if (__tmp57_outputWritten)
                    {
                        __out.AppendLine(false); //469:102
                    }
                    __out.Write("	{"); //470:1
                    __out.AppendLine(false); //470:3
                    bool __tmp64_outputWritten = false;
                    string __tmp63Prefix = "		"; //471:1
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
                    string __tmp66_line = ".MutableObject obj = this.CreateObject(new "; //471:22
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
                    string __tmp68_line = "());"; //471:102
                    if (!string.IsNullOrEmpty(__tmp68_line))
                    {
                        __out.Write(__tmp68_line);
                        __tmp64_outputWritten = true;
                    }
                    if (__tmp64_outputWritten) __out.AppendLine(true);
                    if (__tmp64_outputWritten)
                    {
                        __out.AppendLine(false); //471:106
                    }
                    bool __tmp70_outputWritten = false;
                    string __tmp71_line = "		return ("; //472:1
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
                    string __tmp73_line = ")obj;"; //472:53
                    if (!string.IsNullOrEmpty(__tmp73_line))
                    {
                        __out.Write(__tmp73_line);
                        __tmp70_outputWritten = true;
                    }
                    if (__tmp70_outputWritten) __out.AppendLine(true);
                    if (__tmp70_outputWritten)
                    {
                        __out.AppendLine(false); //472:58
                    }
                    __out.Write("	}"); //473:1
                    __out.AppendLine(false); //473:3
                }
            }
            __out.Write("}"); //476:1
            __out.AppendLine(false); //476:2
            __out.AppendLine(true); //477:1
            return __out.ToStringAndFree();
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //480:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //481:2
            bool metaMetaModel = IsMetaMetaModel(model); //482:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public static class "; //483:1
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
                __out.AppendLine(false); //483:61
            }
            __out.Write("{"); //484:1
            __out.AppendLine(false); //484:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	private static global::System.Collections.Generic.List<"; //485:1
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
            string __tmp9_line = ".ModelProperty> properties;"; //485:76
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Write(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //485:103
            }
            __out.AppendLine(true); //486:1
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	static "; //487:1
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
            string __tmp14_line = "()"; //487:49
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //487:51
            }
            __out.Write("	{"); //488:1
            __out.AppendLine(false); //488:3
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "		properties = new global::System.Collections.Generic.List<"; //489:1
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
            string __tmp19_line = ".ModelProperty>();"; //489:79
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Write(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //489:97
            }
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //490:9
                from cls in __Enumerate((__loop23_var1).GetEnumerator()).OfType<MetaClass>() //490:39
                select new { __loop23_var1 = __loop23_var1, cls = cls}
                ).ToList(); //490:4
            for (int __loop23_iteration = 0; __loop23_iteration < __loop23_results.Count; ++__loop23_iteration)
            {
                var __tmp20 = __loop23_results[__loop23_iteration];
                var __loop23_var1 = __tmp20.__loop23_var1;
                var cls = __tmp20.cls;
                bool __tmp22_outputWritten = false;
                string __tmp21Prefix = "		"; //491:1
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
                string __tmp24_line = ".Initialize();"; //491:48
                if (!string.IsNullOrEmpty(__tmp24_line))
                {
                    __out.Write(__tmp24_line);
                    __tmp22_outputWritten = true;
                }
                if (__tmp22_outputWritten) __out.AppendLine(true);
                if (__tmp22_outputWritten)
                {
                    __out.AppendLine(false); //491:62
                }
            }
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //493:9
                from cls in __Enumerate((__loop24_var1).GetEnumerator()).OfType<MetaClass>() //493:39
                from prop in __Enumerate((cls.Properties).GetEnumerator()) //493:62
                select new { __loop24_var1 = __loop24_var1, cls = cls, prop = prop}
                ).ToList(); //493:4
            for (int __loop24_iteration = 0; __loop24_iteration < __loop24_results.Count; ++__loop24_iteration)
            {
                var __tmp25 = __loop24_results[__loop24_iteration];
                var __loop24_var1 = __tmp25.__loop24_var1;
                var cls = __tmp25.cls;
                var prop = __tmp25.prop;
                bool __tmp27_outputWritten = false;
                string __tmp28_line = "		properties.Add("; //494:1
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
                string __tmp30_line = ");"; //494:73
                if (!string.IsNullOrEmpty(__tmp30_line))
                {
                    __out.Write(__tmp30_line);
                    __tmp27_outputWritten = true;
                }
                if (__tmp27_outputWritten) __out.AppendLine(true);
                if (__tmp27_outputWritten)
                {
                    __out.AppendLine(false); //494:75
                }
            }
            __out.Write("	}"); //496:1
            __out.AppendLine(false); //496:3
            __out.AppendLine(true); //497:1
            __out.Write("	public static void Initialize()"); //498:1
            __out.AppendLine(false); //498:33
            __out.Write("	{"); //499:1
            __out.AppendLine(false); //499:3
            __out.Write("	}"); //500:1
            __out.AppendLine(false); //500:3
            __out.AppendLine(true); //501:1
            bool __tmp32_outputWritten = false;
            string __tmp33_line = "	public const string MUri = \""; //502:1
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
            string __tmp35_line = "\";"; //502:41
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Write(__tmp35_line);
                __tmp32_outputWritten = true;
            }
            if (__tmp32_outputWritten) __out.AppendLine(true);
            if (__tmp32_outputWritten)
            {
                __out.AppendLine(false); //502:43
            }
            bool __tmp37_outputWritten = false;
            string __tmp38_line = "	public const string MPrefix = \""; //503:1
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
            string __tmp40_line = "\";"; //503:47
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Write(__tmp40_line);
                __tmp37_outputWritten = true;
            }
            if (__tmp37_outputWritten) __out.AppendLine(true);
            if (__tmp37_outputWritten)
            {
                __out.AppendLine(false); //503:49
            }
            var __loop25_results = 
                (from __loop25_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //504:8
                from cls in __Enumerate((__loop25_var1).GetEnumerator()).OfType<MetaClass>() //504:38
                select new { __loop25_var1 = __loop25_var1, cls = cls}
                ).ToList(); //504:3
            for (int __loop25_iteration = 0; __loop25_iteration < __loop25_results.Count; ++__loop25_iteration)
            {
                var __tmp41 = __loop25_results[__loop25_iteration];
                var __loop25_var1 = __tmp41.__loop25_var1;
                var cls = __tmp41.cls;
                __out.AppendLine(true); //505:1
                bool __tmp43_outputWritten = false;
                string __tmp42Prefix = "	"; //506:1
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
                    __out.AppendLine(false); //506:39
                }
            }
            __out.Write("}"); //508:1
            __out.AppendLine(false); //508:2
            return __out.ToStringAndFree();
        }

        public string GenerateDescriptorClass(MetaModel model, MetaClass cls) //511:1
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
                __out.AppendLine(false); //512:29
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
                __out.AppendLine(false); //513:26
            }
            if (cls.SymbolType != null) //514:2
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
                string __tmp10_line = "global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof("; //515:6
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
                string __tmp12_line = "))"; //515:103
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
                    __out.AppendLine(false); //515:110
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
            string __tmp17_line = ".ModelObjectDescriptorAttribute(typeof("; //517:24
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
            string __tmp19_line = "), typeof("; //517:105
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
            string __tmp21_line = "), typeof("; //517:164
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
            string __tmp23_line = ")"; //517:221
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
            string __tmp25_line = ")"; //517:258
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
                __out.AppendLine(false); //517:264
            }
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "public static class "; //518:1
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
                __out.AppendLine(false); //518:66
            }
            __out.Write("{"); //519:1
            __out.AppendLine(false); //519:2
            bool __tmp32_outputWritten = false;
            string __tmp33_line = "	private static "; //520:1
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
            string __tmp35_line = ".ModelObjectDescriptor descriptor;"; //520:36
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Write(__tmp35_line);
                __tmp32_outputWritten = true;
            }
            if (__tmp32_outputWritten) __out.AppendLine(true);
            if (__tmp32_outputWritten)
            {
                __out.AppendLine(false); //520:70
            }
            __out.AppendLine(true); //521:1
            bool __tmp37_outputWritten = false;
            string __tmp38_line = "	static "; //522:1
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
            string __tmp40_line = "()"; //522:54
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Write(__tmp40_line);
                __tmp37_outputWritten = true;
            }
            if (__tmp37_outputWritten) __out.AppendLine(true);
            if (__tmp37_outputWritten)
            {
                __out.AppendLine(false); //522:56
            }
            __out.Write("	{"); //523:1
            __out.AppendLine(false); //523:3
            bool __tmp42_outputWritten = false;
            string __tmp43_line = "		descriptor = "; //524:1
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
            string __tmp45_line = ".ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof("; //524:35
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
            string __tmp47_line = "));"; //524:141
            if (!string.IsNullOrEmpty(__tmp47_line))
            {
                __out.Write(__tmp47_line);
                __tmp42_outputWritten = true;
            }
            if (__tmp42_outputWritten) __out.AppendLine(true);
            if (__tmp42_outputWritten)
            {
                __out.AppendLine(false); //524:144
            }
            __out.Write("	}"); //525:1
            __out.AppendLine(false); //525:3
            __out.AppendLine(true); //526:1
            __out.Write("	internal static void Initialize()"); //527:1
            __out.AppendLine(false); //527:35
            __out.Write("	{"); //528:1
            __out.AppendLine(false); //528:3
            __out.Write("	}"); //529:1
            __out.AppendLine(false); //529:3
            __out.AppendLine(true); //530:1
            bool __tmp49_outputWritten = false;
            string __tmp50_line = "	public static "; //531:1
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
            string __tmp52_line = ".ModelObjectDescriptor MDescriptor"; //531:35
            if (!string.IsNullOrEmpty(__tmp52_line))
            {
                __out.Write(__tmp52_line);
                __tmp49_outputWritten = true;
            }
            if (__tmp49_outputWritten) __out.AppendLine(true);
            if (__tmp49_outputWritten)
            {
                __out.AppendLine(false); //531:69
            }
            __out.Write("	{"); //532:1
            __out.AppendLine(false); //532:3
            __out.Write("		get { return descriptor; }"); //533:1
            __out.AppendLine(false); //533:29
            __out.Write("	}"); //534:1
            __out.AppendLine(false); //534:3
            __out.AppendLine(true); //535:1
            bool __tmp54_outputWritten = false;
            string __tmp55_line = "	public static "; //536:1
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
            string __tmp57_line = ".MetaClass MMetaClass"; //536:35
            if (!string.IsNullOrEmpty(__tmp57_line))
            {
                __out.Write(__tmp57_line);
                __tmp54_outputWritten = true;
            }
            if (__tmp54_outputWritten) __out.AppendLine(true);
            if (__tmp54_outputWritten)
            {
                __out.AppendLine(false); //536:56
            }
            __out.Write("	{"); //537:1
            __out.AppendLine(false); //537:3
            bool __tmp59_outputWritten = false;
            string __tmp60_line = "		get { return "; //538:1
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
            string __tmp62_line = "; }"; //538:73
            if (!string.IsNullOrEmpty(__tmp62_line))
            {
                __out.Write(__tmp62_line);
                __tmp59_outputWritten = true;
            }
            if (__tmp59_outputWritten) __out.AppendLine(true);
            if (__tmp59_outputWritten)
            {
                __out.AppendLine(false); //538:76
            }
            __out.Write("	}"); //539:1
            __out.AppendLine(false); //539:3
            var __loop26_results = 
                (from __loop26_var1 in __Enumerate((cls).GetEnumerator()) //540:8
                from prop in __Enumerate((__loop26_var1.Properties).GetEnumerator()) //540:13
                select new { __loop26_var1 = __loop26_var1, prop = prop}
                ).ToList(); //540:3
            for (int __loop26_iteration = 0; __loop26_iteration < __loop26_results.Count; ++__loop26_iteration)
            {
                var __tmp63 = __loop26_results[__loop26_iteration];
                var __loop26_var1 = __tmp63.__loop26_var1;
                var prop = __tmp63.prop;
                bool __tmp65_outputWritten = false;
                string __tmp64Prefix = "	"; //541:1
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
                    __out.AppendLine(false); //541:48
                }
            }
            __out.Write("}"); //543:1
            __out.AppendLine(false); //543:2
            return __out.ToStringAndFree();
        }

        public string GetDescriptorAncestors(MetaModel model, MetaClass cls) //546:1
        {
            string result = ""; //547:2
            var __loop27_results = 
                (from __loop27_var1 in __Enumerate((cls).GetEnumerator()) //548:7
                from super in __Enumerate((__loop27_var1.SuperClasses).GetEnumerator()) //548:12
                select new { __loop27_var1 = __loop27_var1, super = super}
                ).ToList(); //548:2
            for (int __loop27_iteration = 0; __loop27_iteration < __loop27_results.Count; ++__loop27_iteration)
            {
                string delim; //548:30
                if (__loop27_iteration+1 < __loop27_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop27_results[__loop27_iteration];
                var __loop27_var1 = __tmp1.__loop27_var1;
                var super = __tmp1.super;
                result += "typeof(" + CSharpName(super, model, ClassKind.Descriptor, true) + ")" + delim; //549:3
            }
            if (result.Length > 0) //551:2
            {
                result = ", BaseDescriptors = new global::System.Type[] { " + result + " }"; //552:3
            }
            return result; //554:2
        }

        public string GenerateDescriptorProperty(MetaModel model, MetaClass cls, MetaProperty prop) //557:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.AppendLine(true); //558:1
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
                __out.AppendLine(false); //559:30
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
                __out.AppendLine(false); //560:27
            }
            if (prop.SymbolProperty != null) //561:2
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
                string __tmp10_line = "global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute(\""; //562:6
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
                string __tmp12_line = "\")"; //562:101
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
                    __out.AppendLine(false); //562:108
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
                __out.AppendLine(false); //564:57
            }
            bool __tmp18_outputWritten = false;
            string __tmp19_line = "public static readonly "; //565:1
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
            string __tmp21_line = ".ModelProperty "; //565:43
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
            string __tmp23_line = " ="; //565:107
            if (!string.IsNullOrEmpty(__tmp23_line))
            {
                __out.Write(__tmp23_line);
                __tmp18_outputWritten = true;
            }
            if (__tmp18_outputWritten) __out.AppendLine(true);
            if (__tmp18_outputWritten)
            {
                __out.AppendLine(false); //565:109
            }
            bool __tmp25_outputWritten = false;
            string __tmp24Prefix = "    "; //566:1
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
            string __tmp27_line = ".ModelProperty.Register(declaringType: typeof("; //566:24
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
            string __tmp29_line = "), name: \""; //566:115
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
            string __tmp31_line = "\","; //566:149
            if (!string.IsNullOrEmpty(__tmp31_line))
            {
                __out.Write(__tmp31_line);
                __tmp25_outputWritten = true;
            }
            if (__tmp25_outputWritten) __out.AppendLine(true);
            if (__tmp25_outputWritten)
            {
                __out.AppendLine(false); //566:151
            }
            if (prop.Type is MetaCollectionType) //567:2
            {
                MetaCollectionType collType = (MetaCollectionType)prop.Type; //568:3
                bool __tmp33_outputWritten = false;
                string __tmp34_line = "        immutableType: typeof("; //569:1
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
                string __tmp36_line = "),"; //569:95
                if (!string.IsNullOrEmpty(__tmp36_line))
                {
                    __out.Write(__tmp36_line);
                    __tmp33_outputWritten = true;
                }
                if (__tmp33_outputWritten) __out.AppendLine(true);
                if (__tmp33_outputWritten)
                {
                    __out.AppendLine(false); //569:97
                }
                bool __tmp38_outputWritten = false;
                string __tmp39_line = "        mutableType: typeof("; //570:1
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
                string __tmp41_line = "),"; //570:91
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Write(__tmp41_line);
                    __tmp38_outputWritten = true;
                }
                if (__tmp38_outputWritten) __out.AppendLine(true);
                if (__tmp38_outputWritten)
                {
                    __out.AppendLine(false); //570:93
                }
            }
            else //571:2
            {
                bool __tmp43_outputWritten = false;
                string __tmp44_line = "        immutableType: typeof("; //572:1
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
                string __tmp46_line = "),"; //572:86
                if (!string.IsNullOrEmpty(__tmp46_line))
                {
                    __out.Write(__tmp46_line);
                    __tmp43_outputWritten = true;
                }
                if (__tmp43_outputWritten) __out.AppendLine(true);
                if (__tmp43_outputWritten)
                {
                    __out.AppendLine(false); //572:88
                }
                bool __tmp48_outputWritten = false;
                string __tmp49_line = "        mutableType: typeof("; //573:1
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
                string __tmp51_line = "),"; //573:82
                if (!string.IsNullOrEmpty(__tmp51_line))
                {
                    __out.Write(__tmp51_line);
                    __tmp48_outputWritten = true;
                }
                if (__tmp48_outputWritten) __out.AppendLine(true);
                if (__tmp48_outputWritten)
                {
                    __out.AppendLine(false); //573:84
                }
            }
            bool __tmp53_outputWritten = false;
            string __tmp54_line = "		metaProperty: () => "; //575:1
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
            string __tmp56_line = ","; //575:84
            if (!string.IsNullOrEmpty(__tmp56_line))
            {
                __out.Write(__tmp56_line);
                __tmp53_outputWritten = true;
            }
            if (__tmp53_outputWritten) __out.AppendLine(true);
            if (__tmp53_outputWritten)
            {
                __out.AppendLine(false); //575:85
            }
            bool __tmp58_outputWritten = false;
            string __tmp59_line = "		defaultValue: "; //576:1
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
            string __tmp61_line = ");"; //576:73
            if (!string.IsNullOrEmpty(__tmp61_line))
            {
                __out.Write(__tmp61_line);
                __tmp58_outputWritten = true;
            }
            if (__tmp58_outputWritten) __out.AppendLine(true);
            if (__tmp58_outputWritten)
            {
                __out.AppendLine(false); //576:75
            }
            return __out.ToStringAndFree();
        }

        public string GenerateDescriptorPropertyAttributes(MetaModel model, MetaClass cls, MetaProperty prop) //579:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            if (prop.Type is MetaCollectionType) //580:2
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
                    __out.AppendLine(false); //581:48
                }
            }
            if (prop.Type is MetaCollectionType && (((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiSet || ((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiList)) //583:2
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
                    __out.AppendLine(false); //584:47
                }
            }
            if (prop.Type is MetaCollectionType && (((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.List || ((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiList)) //586:2
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
                    __out.AppendLine(false); //587:45
                }
            }
            if (prop.IsContainment) //589:2
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
                    __out.AppendLine(false); //590:49
                }
            }
            if (prop.Kind != MetaPropertyKind.Normal) //592:2
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
                    __out.AppendLine(false); //593:46
                }
            }
            if (prop.Kind == MetaPropertyKind.Derived) //595:2
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
                    __out.AppendLine(false); //596:45
                }
            }
            if (prop.Kind == MetaPropertyKind.DerivedUnion) //598:2
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
                    __out.AppendLine(false); //599:50
                }
            }
            var __loop28_results = 
                (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //601:7
                select new { p = p}
                ).ToList(); //601:2
            for (int __loop28_iteration = 0; __loop28_iteration < __loop28_results.Count; ++__loop28_iteration)
            {
                var __tmp22 = __loop28_results[__loop28_iteration];
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
                    __out.AppendLine(false); //602:146
                }
            }
            var __loop29_results = 
                (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //604:7
                select new { p = p}
                ).ToList(); //604:2
            for (int __loop29_iteration = 0; __loop29_iteration < __loop29_results.Count; ++__loop29_iteration)
            {
                var __tmp30 = __loop29_results[__loop29_iteration];
                var p = __tmp30.p;
                if (cls.GetAllSuperClasses(true).Contains(p.Class)) //605:3
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
                        __out.AppendLine(false); //606:145
                    }
                }
                else //607:3
                {
                    bool __tmp39_outputWritten = false;
                    string __tmp40_line = "// ERROR: subsetted property '"; //608:1
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
                    string __tmp42_line = "' must be a property of this class or an ancestor class"; //608:83
                    if (!string.IsNullOrEmpty(__tmp42_line))
                    {
                        __out.Write(__tmp42_line);
                        __tmp39_outputWritten = true;
                    }
                    if (__tmp39_outputWritten) __out.AppendLine(true);
                    if (__tmp39_outputWritten)
                    {
                        __out.AppendLine(false); //608:138
                    }
                }
            }
            var __loop30_results = 
                (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //611:7
                select new { p = p}
                ).ToList(); //611:2
            for (int __loop30_iteration = 0; __loop30_iteration < __loop30_results.Count; ++__loop30_iteration)
            {
                var __tmp43 = __loop30_results[__loop30_iteration];
                var p = __tmp43.p;
                if (cls.GetAllSuperClasses(true).Contains(p.Class)) //612:3
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
                        __out.AppendLine(false); //613:147
                    }
                }
                else //614:3
                {
                    bool __tmp52_outputWritten = false;
                    string __tmp53_line = "// ERROR: redefined property '"; //615:1
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
                    string __tmp55_line = "' must be a property of this class or an ancestor class"; //615:83
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Write(__tmp55_line);
                        __tmp52_outputWritten = true;
                    }
                    if (__tmp52_outputWritten) __out.AppendLine(true);
                    if (__tmp52_outputWritten)
                    {
                        __out.AppendLine(false); //615:138
                    }
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateImplementationProvider(MetaModel model) //620:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //621:1
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
                __out.AppendLine(false); //621:68
            }
            __out.Write("{"); //622:1
            __out.AppendLine(false); //622:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	// If there is a compile error at this line, create a new class called "; //623:1
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
                __out.AppendLine(false); //623:117
            }
            bool __tmp10_outputWritten = false;
            string __tmp11_line = "	// which is a subclass of "; //624:1
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
            string __tmp13_line = ":"; //624:82
            if (!string.IsNullOrEmpty(__tmp13_line))
            {
                __out.Write(__tmp13_line);
                __tmp10_outputWritten = true;
            }
            if (__tmp10_outputWritten) __out.AppendLine(true);
            if (__tmp10_outputWritten)
            {
                __out.AppendLine(false); //624:83
            }
            bool __tmp15_outputWritten = false;
            string __tmp16_line = "	private static "; //625:1
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
            string __tmp18_line = " implementation = new "; //625:61
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
            string __tmp20_line = "();"; //625:127
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Write(__tmp20_line);
                __tmp15_outputWritten = true;
            }
            if (__tmp15_outputWritten) __out.AppendLine(true);
            if (__tmp15_outputWritten)
            {
                __out.AppendLine(false); //625:130
            }
            __out.AppendLine(true); //626:1
            bool __tmp22_outputWritten = false;
            string __tmp23_line = "	public static "; //627:1
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
            string __tmp25_line = " Implementation"; //627:60
            if (!string.IsNullOrEmpty(__tmp25_line))
            {
                __out.Write(__tmp25_line);
                __tmp22_outputWritten = true;
            }
            if (__tmp22_outputWritten) __out.AppendLine(true);
            if (__tmp22_outputWritten)
            {
                __out.AppendLine(false); //627:75
            }
            __out.Write("	{"); //628:1
            __out.AppendLine(false); //628:3
            __out.Write("		get { return implementation; }"); //629:1
            __out.AppendLine(false); //629:33
            __out.Write("	}"); //630:1
            __out.AppendLine(false); //630:3
            __out.Write("}"); //631:1
            __out.AppendLine(false); //631:2
            return __out.ToStringAndFree();
        }

        public string GenerateImplementationBase(MetaModel model) //634:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //635:2
            bool metaMetaModel = IsMetaMetaModel(model); //636:2
            __out.Write("/// <summary>"); //637:1
            __out.AppendLine(false); //637:14
            __out.Write("/// Base class for implementing the behavior of the model elements."); //638:1
            __out.AppendLine(false); //638:68
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "/// This class has to be be overriden in "; //639:1
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
            string __tmp5_line = " to provide custom"; //639:92
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //639:110
            }
            __out.Write("/// implementation for the constructors, operations and property values."); //640:1
            __out.AppendLine(false); //640:73
            __out.Write("/// </summary>"); //641:1
            __out.AppendLine(false); //641:15
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "internal abstract class "; //642:1
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
                __out.AppendLine(false); //642:73
            }
            __out.Write("{"); //643:1
            __out.AppendLine(false); //643:2
            __out.Write("	/// <summary>"); //644:1
            __out.AppendLine(false); //644:15
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	/// Implements the constructor: "; //645:1
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
            string __tmp14_line = "()"; //645:79
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //645:81
            }
            __out.Write("	/// </summary>"); //646:1
            __out.AppendLine(false); //646:16
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "	internal virtual void "; //647:1
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
            string __tmp19_line = "("; //647:69
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
            string __tmp21_line = " _this)"; //647:115
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //647:122
            }
            __out.Write("	{"); //648:1
            __out.AppendLine(false); //648:3
            __out.Write("	}"); //649:1
            __out.AppendLine(false); //649:3
            var __loop31_results = 
                (from __loop31_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //650:8
                from cls in __Enumerate((__loop31_var1).GetEnumerator()).OfType<MetaClass>() //650:38
                select new { __loop31_var1 = __loop31_var1, cls = cls}
                ).ToList(); //650:3
            for (int __loop31_iteration = 0; __loop31_iteration < __loop31_results.Count; ++__loop31_iteration)
            {
                var __tmp22 = __loop31_results[__loop31_iteration];
                var __loop31_var1 = __tmp22.__loop31_var1;
                var cls = __tmp22.cls;
                __out.AppendLine(true); //651:1
                __out.Write("	/// <summary>"); //652:1
                __out.AppendLine(false); //652:15
                bool __tmp24_outputWritten = false;
                string __tmp25_line = "	/// Implements the constructor: "; //653:1
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
                string __tmp27_line = "()"; //653:78
                if (!string.IsNullOrEmpty(__tmp27_line))
                {
                    __out.Write(__tmp27_line);
                    __tmp24_outputWritten = true;
                }
                if (__tmp24_outputWritten) __out.AppendLine(true);
                if (__tmp24_outputWritten)
                {
                    __out.AppendLine(false); //653:80
                }
                __out.Write("	/// </summary>"); //654:1
                __out.AppendLine(false); //654:16
                if ((from __loop32_var1 in __Enumerate((cls).GetEnumerator()) //655:15
                from sup in __Enumerate((__loop32_var1.SuperClasses).GetEnumerator()) //655:20
                select new { __loop32_var1 = __loop32_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //655:3
                {
                    __out.Write("	/// Direct superclasses: "); //656:1
                    __out.AppendLine(false); //656:27
                    __out.Write("	/// <ul>"); //657:1
                    __out.AppendLine(false); //657:10
                    var __loop33_results = 
                        (from __loop33_var1 in __Enumerate((cls).GetEnumerator()) //658:8
                        from sup in __Enumerate((__loop33_var1.SuperClasses).GetEnumerator()) //658:13
                        select new { __loop33_var1 = __loop33_var1, sup = sup}
                        ).ToList(); //658:3
                    for (int __loop33_iteration = 0; __loop33_iteration < __loop33_results.Count; ++__loop33_iteration)
                    {
                        var __tmp28 = __loop33_results[__loop33_iteration];
                        var __loop33_var1 = __tmp28.__loop33_var1;
                        var sup = __tmp28.sup;
                        bool __tmp30_outputWritten = false;
                        string __tmp31_line = "	///     <li>"; //659:1
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
                        string __tmp33_line = "</li>"; //659:64
                        if (!string.IsNullOrEmpty(__tmp33_line))
                        {
                            __out.Write(__tmp33_line);
                            __tmp30_outputWritten = true;
                        }
                        if (__tmp30_outputWritten) __out.AppendLine(true);
                        if (__tmp30_outputWritten)
                        {
                            __out.AppendLine(false); //659:69
                        }
                    }
                    __out.Write("	/// </ul>"); //661:1
                    __out.AppendLine(false); //661:11
                    __out.Write("	/// All superclasses:"); //662:1
                    __out.AppendLine(false); //662:23
                    __out.Write("	/// <ul>"); //663:1
                    __out.AppendLine(false); //663:10
                    var __loop34_results = 
                        (from __loop34_var1 in __Enumerate((cls).GetEnumerator()) //664:8
                        from sup in __Enumerate((__loop34_var1.GetAllSuperClasses(false)).GetEnumerator()) //664:13
                        select new { __loop34_var1 = __loop34_var1, sup = sup}
                        ).ToList(); //664:3
                    for (int __loop34_iteration = 0; __loop34_iteration < __loop34_results.Count; ++__loop34_iteration)
                    {
                        var __tmp34 = __loop34_results[__loop34_iteration];
                        var __loop34_var1 = __tmp34.__loop34_var1;
                        var sup = __tmp34.sup;
                        bool __tmp36_outputWritten = false;
                        string __tmp37_line = "	///     <li>"; //665:1
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
                        string __tmp39_line = "</li>"; //665:64
                        if (!string.IsNullOrEmpty(__tmp39_line))
                        {
                            __out.Write(__tmp39_line);
                            __tmp36_outputWritten = true;
                        }
                        if (__tmp36_outputWritten) __out.AppendLine(true);
                        if (__tmp36_outputWritten)
                        {
                            __out.AppendLine(false); //665:69
                        }
                    }
                    __out.Write("	/// </ul>"); //667:1
                    __out.AppendLine(false); //667:11
                }
                if ((from __loop35_var1 in __Enumerate((cls).GetEnumerator()) //669:15
                from prop in __Enumerate((__loop35_var1.Properties).GetEnumerator()) //669:20
                where prop.Kind == MetaPropertyKind.Readonly //669:36
                select new { __loop35_var1 = __loop35_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //669:3
                {
                    __out.Write("	/// Initializes the following readonly properties:"); //670:1
                    __out.AppendLine(false); //670:52
                    __out.Write("	/// <ul>"); //671:1
                    __out.AppendLine(false); //671:10
                    var __loop36_results = 
                        (from __loop36_var1 in __Enumerate((cls).GetEnumerator()) //672:8
                        from prop in __Enumerate((__loop36_var1.Properties).GetEnumerator()) //672:13
                        where prop.Kind == MetaPropertyKind.Readonly //672:29
                        select new { __loop36_var1 = __loop36_var1, prop = prop}
                        ).ToList(); //672:3
                    for (int __loop36_iteration = 0; __loop36_iteration < __loop36_results.Count; ++__loop36_iteration)
                    {
                        var __tmp40 = __loop36_results[__loop36_iteration];
                        var __loop36_var1 = __tmp40.__loop36_var1;
                        var prop = __tmp40.prop;
                        bool __tmp42_outputWritten = false;
                        string __tmp43_line = "	///     <li>"; //673:1
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
                        string __tmp45_line = "</li>"; //673:38
                        if (!string.IsNullOrEmpty(__tmp45_line))
                        {
                            __out.Write(__tmp45_line);
                            __tmp42_outputWritten = true;
                        }
                        if (__tmp42_outputWritten) __out.AppendLine(true);
                        if (__tmp42_outputWritten)
                        {
                            __out.AppendLine(false); //673:43
                        }
                    }
                    __out.Write("	/// </ul>"); //675:1
                    __out.AppendLine(false); //675:11
                }
                if ((from __loop37_var1 in __Enumerate((cls).GetEnumerator()) //677:15
                from prop in __Enumerate((__loop37_var1.Properties).GetEnumerator()) //677:20
                where prop.Kind == MetaPropertyKind.Lazy //677:36
                select new { __loop37_var1 = __loop37_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //677:3
                {
                    __out.Write("	/// Initializes the following lazy properties:"); //678:1
                    __out.AppendLine(false); //678:48
                    __out.Write("	/// <ul>"); //679:1
                    __out.AppendLine(false); //679:10
                    var __loop38_results = 
                        (from __loop38_var1 in __Enumerate((cls).GetEnumerator()) //680:8
                        from prop in __Enumerate((__loop38_var1.Properties).GetEnumerator()) //680:13
                        where prop.Kind == MetaPropertyKind.Lazy //680:29
                        select new { __loop38_var1 = __loop38_var1, prop = prop}
                        ).ToList(); //680:3
                    for (int __loop38_iteration = 0; __loop38_iteration < __loop38_results.Count; ++__loop38_iteration)
                    {
                        var __tmp46 = __loop38_results[__loop38_iteration];
                        var __loop38_var1 = __tmp46.__loop38_var1;
                        var prop = __tmp46.prop;
                        bool __tmp48_outputWritten = false;
                        string __tmp49_line = "	///     <li>"; //681:1
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
                        string __tmp51_line = "</li>"; //681:38
                        if (!string.IsNullOrEmpty(__tmp51_line))
                        {
                            __out.Write(__tmp51_line);
                            __tmp48_outputWritten = true;
                        }
                        if (__tmp48_outputWritten) __out.AppendLine(true);
                        if (__tmp48_outputWritten)
                        {
                            __out.AppendLine(false); //681:43
                        }
                    }
                    __out.Write("	/// </ul>"); //683:1
                    __out.AppendLine(false); //683:11
                }
                if ((from __loop39_var1 in __Enumerate((cls).GetEnumerator()) //685:15
                from prop in __Enumerate((__loop39_var1.Properties).GetEnumerator()) //685:20
                where prop.Kind == MetaPropertyKind.Derived //685:36
                select new { __loop39_var1 = __loop39_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //685:3
                {
                    __out.Write("	/// Initializes the following derived properties:"); //686:1
                    __out.AppendLine(false); //686:51
                    __out.Write("	/// <ul>"); //687:1
                    __out.AppendLine(false); //687:10
                    var __loop40_results = 
                        (from __loop40_var1 in __Enumerate((cls).GetEnumerator()) //688:8
                        from prop in __Enumerate((__loop40_var1.Properties).GetEnumerator()) //688:13
                        where prop.Kind == MetaPropertyKind.Derived //688:29
                        select new { __loop40_var1 = __loop40_var1, prop = prop}
                        ).ToList(); //688:3
                    for (int __loop40_iteration = 0; __loop40_iteration < __loop40_results.Count; ++__loop40_iteration)
                    {
                        var __tmp52 = __loop40_results[__loop40_iteration];
                        var __loop40_var1 = __tmp52.__loop40_var1;
                        var prop = __tmp52.prop;
                        bool __tmp54_outputWritten = false;
                        string __tmp55_line = "	///     <li>"; //689:1
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
                        string __tmp57_line = "</li>"; //689:38
                        if (!string.IsNullOrEmpty(__tmp57_line))
                        {
                            __out.Write(__tmp57_line);
                            __tmp54_outputWritten = true;
                        }
                        if (__tmp54_outputWritten) __out.AppendLine(true);
                        if (__tmp54_outputWritten)
                        {
                            __out.AppendLine(false); //689:43
                        }
                    }
                    __out.Write("	/// </ul>"); //691:1
                    __out.AppendLine(false); //691:11
                }
                bool __tmp59_outputWritten = false;
                string __tmp60_line = "	public virtual void "; //693:1
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
                string __tmp62_line = "("; //693:66
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
                string __tmp64_line = " _this)"; //693:109
                if (!string.IsNullOrEmpty(__tmp64_line))
                {
                    __out.Write(__tmp64_line);
                    __tmp59_outputWritten = true;
                }
                if (__tmp59_outputWritten) __out.AppendLine(true);
                if (__tmp59_outputWritten)
                {
                    __out.AppendLine(false); //693:116
                }
                __out.Write("	{"); //694:1
                __out.AppendLine(false); //694:3
                bool __tmp66_outputWritten = false;
                string __tmp67_line = "		this.Call"; //695:1
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
                string __tmp69_line = "SuperConstructors(_this);"; //695:56
                if (!string.IsNullOrEmpty(__tmp69_line))
                {
                    __out.Write(__tmp69_line);
                    __tmp66_outputWritten = true;
                }
                if (__tmp66_outputWritten) __out.AppendLine(true);
                if (__tmp66_outputWritten)
                {
                    __out.AppendLine(false); //695:81
                }
                var __loop41_results = 
                    (from __loop41_var1 in __Enumerate((cls).GetEnumerator()) //696:9
                    from prop in __Enumerate((__loop41_var1.GetAllFinalProperties()).GetEnumerator()) //696:14
                    select new { __loop41_var1 = __loop41_var1, prop = prop}
                    ).ToList(); //696:4
                for (int __loop41_iteration = 0; __loop41_iteration < __loop41_results.Count; ++__loop41_iteration)
                {
                    var __tmp70 = __loop41_results[__loop41_iteration];
                    var __loop41_var1 = __tmp70.__loop41_var1;
                    var prop = __tmp70.prop;
                    if (metaMetaModel && cls.Name == "MetaConstant" && prop.Name == "Value") //697:5
                    {
                    }
                    else if (prop.DefaultValue != null) //698:5
                    {
                        if (!(prop.Type is MetaCollectionType)) //699:6
                        {
                            bool __tmp72_outputWritten = false;
                            string __tmp73_line = "		_this.Set"; //700:1
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
                            string __tmp75_line = "Lazy(() => "; //700:58
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
                            string __tmp77_line = ");"; //700:88
                            if (!string.IsNullOrEmpty(__tmp77_line))
                            {
                                __out.Write(__tmp77_line);
                                __tmp72_outputWritten = true;
                            }
                            if (__tmp72_outputWritten) __out.AppendLine(true);
                            if (__tmp72_outputWritten)
                            {
                                __out.AppendLine(false); //700:90
                            }
                        }
                        else //701:6
                        {
                            __out.Write("		// ERROR: default value for collection"); //702:1
                            __out.AppendLine(false); //702:41
                            bool __tmp79_outputWritten = false;
                            string __tmp80_line = "		// _this."; //703:1
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
                            string __tmp82_line = " = "; //703:58
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
                            string __tmp84_line = ";"; //703:80
                            if (!string.IsNullOrEmpty(__tmp84_line))
                            {
                                __out.Write(__tmp84_line);
                                __tmp79_outputWritten = true;
                            }
                            if (__tmp79_outputWritten) __out.AppendLine(true);
                            if (__tmp79_outputWritten)
                            {
                                __out.AppendLine(false); //703:81
                            }
                        }
                    }
                    else if (prop.Kind == MetaPropertyKind.Lazy || prop.Kind == MetaPropertyKind.Derived) //705:5
                    {
                        if (!(prop.Type is MetaCollectionType)) //706:6
                        {
                            bool __tmp86_outputWritten = false;
                            string __tmp87_line = "		_this.Set"; //707:1
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
                            string __tmp89_line = "Lazy(this."; //707:58
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
                            string __tmp91_line = "_ComputeProperty_"; //707:119
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
                            string __tmp93_line = ");"; //707:160
                            if (!string.IsNullOrEmpty(__tmp93_line))
                            {
                                __out.Write(__tmp93_line);
                                __tmp86_outputWritten = true;
                            }
                            if (__tmp86_outputWritten) __out.AppendLine(true);
                            if (__tmp86_outputWritten)
                            {
                                __out.AppendLine(false); //707:162
                            }
                        }
                        else //708:6
                        {
                            bool __tmp95_outputWritten = false;
                            string __tmp96_line = "		_this."; //709:1
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
                            string __tmp98_line = ".AddRangeLazy<"; //709:55
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
                            string __tmp100_line = ">(this."; //709:118
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
                            string __tmp102_line = "_ComputeProperty_"; //709:176
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
                            string __tmp104_line = ");"; //709:217
                            if (!string.IsNullOrEmpty(__tmp104_line))
                            {
                                __out.Write(__tmp104_line);
                                __tmp95_outputWritten = true;
                            }
                            if (__tmp95_outputWritten) __out.AppendLine(true);
                            if (__tmp95_outputWritten)
                            {
                                __out.AppendLine(false); //709:219
                            }
                        }
                    }
                    else if (prop.Kind == MetaPropertyKind.Readonly) //711:5
                    {
                        if (!(prop.Type is MetaCollectionType)) //712:6
                        {
                            bool __tmp106_outputWritten = false;
                            string __tmp107_line = "		_this.Set"; //713:1
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
                            string __tmp109_line = "Lazy(this."; //713:58
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
                            string __tmp111_line = "_ComputeProperty_"; //713:119
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
                            string __tmp113_line = ");"; //713:160
                            if (!string.IsNullOrEmpty(__tmp113_line))
                            {
                                __out.Write(__tmp113_line);
                                __tmp106_outputWritten = true;
                            }
                            if (__tmp106_outputWritten) __out.AppendLine(true);
                            if (__tmp106_outputWritten)
                            {
                                __out.AppendLine(false); //713:162
                            }
                        }
                        else //714:6
                        {
                            bool __tmp115_outputWritten = false;
                            string __tmp116_line = "		_this."; //715:1
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
                            string __tmp118_line = ".AddRangeLazy("; //715:55
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
                            string __tmp120_line = "_ComputeProperty_"; //715:120
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
                            string __tmp122_line = ");"; //715:161
                            if (!string.IsNullOrEmpty(__tmp122_line))
                            {
                                __out.Write(__tmp122_line);
                                __tmp115_outputWritten = true;
                            }
                            if (__tmp115_outputWritten) __out.AppendLine(true);
                            if (__tmp115_outputWritten)
                            {
                                __out.AppendLine(false); //715:163
                            }
                        }
                    }
                }
                __out.Write("	}"); //719:1
                __out.AppendLine(false); //719:3
                __out.AppendLine(true); //720:1
                __out.Write("	/// <summary>"); //721:1
                __out.AppendLine(false); //721:15
                bool __tmp124_outputWritten = false;
                string __tmp125_line = "	/// Calls the super constructors of "; //722:1
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
                    __out.AppendLine(false); //722:82
                }
                __out.Write("	/// </summary>"); //723:1
                __out.AppendLine(false); //723:16
                bool __tmp128_outputWritten = false;
                string __tmp129_line = "	protected virtual void Call"; //724:1
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
                string __tmp131_line = "SuperConstructors("; //724:73
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
                string __tmp133_line = " _this)"; //724:133
                if (!string.IsNullOrEmpty(__tmp133_line))
                {
                    __out.Write(__tmp133_line);
                    __tmp128_outputWritten = true;
                }
                if (__tmp128_outputWritten) __out.AppendLine(true);
                if (__tmp128_outputWritten)
                {
                    __out.AppendLine(false); //724:140
                }
                __out.Write("	{"); //725:1
                __out.AppendLine(false); //725:3
                var __loop42_results = 
                    (from __loop42_var1 in __Enumerate((cls).GetEnumerator()) //726:8
                    from sup in __Enumerate((__loop42_var1.GetAllSuperClasses(false)).GetEnumerator()) //726:13
                    select new { __loop42_var1 = __loop42_var1, sup = sup}
                    ).ToList(); //726:3
                for (int __loop42_iteration = 0; __loop42_iteration < __loop42_results.Count; ++__loop42_iteration)
                {
                    var __tmp134 = __loop42_results[__loop42_iteration];
                    var __loop42_var1 = __tmp134.__loop42_var1;
                    var sup = __tmp134.sup;
                    if (model.Namespace.Declarations.Contains(sup)) //727:4
                    {
                        bool __tmp136_outputWritten = false;
                        string __tmp137_line = "		this."; //728:1
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
                        string __tmp139_line = "(_this);"; //728:52
                        if (!string.IsNullOrEmpty(__tmp139_line))
                        {
                            __out.Write(__tmp139_line);
                            __tmp136_outputWritten = true;
                        }
                        if (__tmp136_outputWritten) __out.AppendLine(true);
                        if (__tmp136_outputWritten)
                        {
                            __out.AppendLine(false); //728:60
                        }
                    }
                    else //729:4
                    {
                        bool __tmp141_outputWritten = false;
                        string __tmp140Prefix = "		"; //730:1
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
                        string __tmp143_line = "."; //730:69
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
                        string __tmp145_line = "(_this);"; //730:114
                        if (!string.IsNullOrEmpty(__tmp145_line))
                        {
                            __out.Write(__tmp145_line);
                            __tmp141_outputWritten = true;
                        }
                        if (__tmp141_outputWritten) __out.AppendLine(true);
                        if (__tmp141_outputWritten)
                        {
                            __out.AppendLine(false); //730:122
                        }
                    }
                }
                __out.Write("	}"); //733:1
                __out.AppendLine(false); //733:3
                __out.AppendLine(true); //734:2
                var __loop43_results = 
                    (from __loop43_var1 in __Enumerate((cls).GetEnumerator()) //735:8
                    from prop in __Enumerate((__loop43_var1.Properties).GetEnumerator()) //735:13
                    where prop.Kind == MetaPropertyKind.Readonly || prop.Kind == MetaPropertyKind.Lazy || prop.Kind == MetaPropertyKind.Derived //735:29
                    select new { __loop43_var1 = __loop43_var1, prop = prop}
                    ).ToList(); //735:3
                for (int __loop43_iteration = 0; __loop43_iteration < __loop43_results.Count; ++__loop43_iteration)
                {
                    var __tmp146 = __loop43_results[__loop43_iteration];
                    var __loop43_var1 = __tmp146.__loop43_var1;
                    var prop = __tmp146.prop;
                    if (metaMetaModel && cls.Name == "MetaConstant" && prop.Name == "Value") //736:4
                    {
                    }
                    else //737:4
                    {
                        __out.Write("	/// <summary>"); //738:1
                        __out.AppendLine(false); //738:15
                        bool __tmp148_outputWritten = false;
                        string __tmp149_line = "	/// Computes the value of the property: "; //739:1
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
                        string __tmp151_line = "."; //739:86
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
                            __out.AppendLine(false); //739:111
                        }
                        __out.Write("	/// </summary	"); //740:1
                        __out.AppendLine(false); //740:16
                        bool __tmp154_outputWritten = false;
                        string __tmp155_line = "	public abstract "; //741:1
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
                        string __tmp157_line = " "; //741:81
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
                        string __tmp159_line = "_ComputeProperty_"; //741:126
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
                        string __tmp161_line = "("; //741:167
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
                        string __tmp163_line = " _this);"; //741:210
                        if (!string.IsNullOrEmpty(__tmp163_line))
                        {
                            __out.Write(__tmp163_line);
                            __tmp154_outputWritten = true;
                        }
                        if (__tmp154_outputWritten) __out.AppendLine(true);
                        if (__tmp154_outputWritten)
                        {
                            __out.AppendLine(false); //741:218
                        }
                    }
                }
                __out.AppendLine(true); //744:2
                var __loop44_results = 
                    (from __loop44_var1 in __Enumerate((cls).GetEnumerator()) //745:8
                    from op in __Enumerate((__loop44_var1.Operations).GetEnumerator()) //745:13
                    select new { __loop44_var1 = __loop44_var1, op = op}
                    ).ToList(); //745:3
                for (int __loop44_iteration = 0; __loop44_iteration < __loop44_results.Count; ++__loop44_iteration)
                {
                    var __tmp164 = __loop44_results[__loop44_iteration];
                    var __loop44_var1 = __tmp164.__loop44_var1;
                    var op = __tmp164.op;
                    if (!op.IsBuilder) //746:4
                    {
                        __out.AppendLine(true); //747:2
                        __out.Write("	/// <summary>"); //748:1
                        __out.AppendLine(false); //748:15
                        bool __tmp166_outputWritten = false;
                        string __tmp167_line = "	/// Implements the operation: "; //749:1
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
                        string __tmp169_line = "."; //749:76
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
                        string __tmp171_line = "()"; //749:86
                        if (!string.IsNullOrEmpty(__tmp171_line))
                        {
                            __out.Write(__tmp171_line);
                            __tmp166_outputWritten = true;
                        }
                        if (__tmp166_outputWritten) __out.AppendLine(true);
                        if (__tmp166_outputWritten)
                        {
                            __out.AppendLine(false); //749:88
                        }
                        __out.Write("	/// </summary>"); //750:1
                        __out.AppendLine(false); //750:16
                        bool __tmp173_outputWritten = false;
                        string __tmp174_line = "	public virtual "; //751:1
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
                        string __tmp176_line = " "; //751:86
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
                        string __tmp178_line = "_"; //751:131
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
                        string __tmp180_line = "("; //751:141
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
                        string __tmp182_line = ")"; //751:207
                        if (!string.IsNullOrEmpty(__tmp182_line))
                        {
                            __out.Write(__tmp182_line);
                            __tmp173_outputWritten = true;
                        }
                        if (__tmp173_outputWritten) __out.AppendLine(true);
                        if (__tmp173_outputWritten)
                        {
                            __out.AppendLine(false); //751:208
                        }
                        __out.Write("	{"); //752:1
                        __out.AppendLine(false); //752:3
                        bool __tmp184_outputWritten = false;
                        string __tmp183Prefix = "		"; //753:1
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
                        string __tmp186_line = "this."; //753:83
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
                        string __tmp188_line = "_"; //753:137
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
                        string __tmp190_line = "("; //753:147
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
                        string __tmp192_line = ")"; //753:216
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
                        string __tmp194_line = ";"; //753:275
                        if (!string.IsNullOrEmpty(__tmp194_line))
                        {
                            __out.Write(__tmp194_line);
                            __tmp184_outputWritten = true;
                        }
                        if (__tmp184_outputWritten) __out.AppendLine(true);
                        if (__tmp184_outputWritten)
                        {
                            __out.AppendLine(false); //753:276
                        }
                        __out.Write("	}"); //754:1
                        __out.AppendLine(false); //754:3
                    }
                    __out.AppendLine(true); //756:2
                    __out.Write("	/// <summary>"); //757:1
                    __out.AppendLine(false); //757:15
                    bool __tmp196_outputWritten = false;
                    string __tmp197_line = "	/// Implements the operation: "; //758:1
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
                    string __tmp199_line = "."; //758:74
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
                    string __tmp201_line = "()"; //758:84
                    if (!string.IsNullOrEmpty(__tmp201_line))
                    {
                        __out.Write(__tmp201_line);
                        __tmp196_outputWritten = true;
                    }
                    if (__tmp196_outputWritten) __out.AppendLine(true);
                    if (__tmp196_outputWritten)
                    {
                        __out.AppendLine(false); //758:86
                    }
                    __out.Write("	/// </summary>"); //759:1
                    __out.AppendLine(false); //759:16
                    bool __tmp203_outputWritten = false;
                    string __tmp204_line = "	public abstract "; //760:1
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
                    string __tmp206_line = " "; //760:85
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
                    string __tmp208_line = "_"; //760:130
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
                    string __tmp210_line = "("; //760:140
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
                    string __tmp212_line = ");"; //760:204
                    if (!string.IsNullOrEmpty(__tmp212_line))
                    {
                        __out.Write(__tmp212_line);
                        __tmp203_outputWritten = true;
                    }
                    if (__tmp203_outputWritten) __out.AppendLine(true);
                    if (__tmp203_outputWritten)
                    {
                        __out.AppendLine(false); //760:206
                    }
                }
                __out.AppendLine(true); //762:2
            }
            var __loop45_results = 
                (from __loop45_var1 in __Enumerate((model).GetEnumerator()) //764:8
                from Namespace in __Enumerate((__loop45_var1.Namespace).GetEnumerator()) //764:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //764:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //764:40
                select new { __loop45_var1 = __loop45_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //764:3
            for (int __loop45_iteration = 0; __loop45_iteration < __loop45_results.Count; ++__loop45_iteration)
            {
                var __tmp213 = __loop45_results[__loop45_iteration];
                var __loop45_var1 = __tmp213.__loop45_var1;
                var Namespace = __tmp213.Namespace;
                var Declarations = __tmp213.Declarations;
                var enm = __tmp213.enm;
                var __loop46_results = 
                    (from __loop46_var1 in __Enumerate((enm).GetEnumerator()) //765:8
                    from op in __Enumerate((__loop46_var1.Operations).GetEnumerator()) //765:13
                    select new { __loop46_var1 = __loop46_var1, op = op}
                    ).ToList(); //765:3
                for (int __loop46_iteration = 0; __loop46_iteration < __loop46_results.Count; ++__loop46_iteration)
                {
                    var __tmp214 = __loop46_results[__loop46_iteration];
                    var __loop46_var1 = __tmp214.__loop46_var1;
                    var op = __tmp214.op;
                    __out.AppendLine(true); //766:2
                    __out.Write("	/// <summary>"); //767:1
                    __out.AppendLine(false); //767:15
                    bool __tmp216_outputWritten = false;
                    string __tmp217_line = "	/// Implements the operation: "; //768:1
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
                    string __tmp219_line = "."; //768:76
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
                        __out.AppendLine(false); //768:86
                    }
                    __out.Write("	/// </summary>"); //769:1
                    __out.AppendLine(false); //769:16
                    bool __tmp222_outputWritten = false;
                    string __tmp223_line = "	public abstract "; //770:1
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
                    string __tmp225_line = " "; //770:87
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
                    string __tmp227_line = "_"; //770:132
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
                    string __tmp229_line = "("; //770:142
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
                    string __tmp231_line = ");"; //770:208
                    if (!string.IsNullOrEmpty(__tmp231_line))
                    {
                        __out.Write(__tmp231_line);
                        __tmp222_outputWritten = true;
                    }
                    if (__tmp222_outputWritten) __out.AppendLine(true);
                    if (__tmp222_outputWritten)
                    {
                        __out.AppendLine(false); //770:210
                    }
                }
                __out.AppendLine(true); //772:2
            }
            __out.Write("}"); //774:1
            __out.AppendLine(false); //774:2
            return __out.ToStringAndFree();
        }

        public string GenerateImplementation(MetaModel model) //777:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //778:2
            bool metaMetaModel = IsMetaMetaModel(model); //779:2
            __out.Write("/// <summary>"); //780:1
            __out.AppendLine(false); //780:14
            __out.Write("/// Class for implementing the behavior of the model elements."); //781:1
            __out.AppendLine(false); //781:63
            __out.Write("/// </summary>"); //782:1
            __out.AppendLine(false); //782:15
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //783:1
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
            string __tmp5_line = " : "; //783:60
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
                __out.AppendLine(false); //783:111
            }
            __out.Write("{"); //784:1
            __out.AppendLine(false); //784:2
            var __loop47_results = 
                (from __loop47_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //785:8
                from cls in __Enumerate((__loop47_var1).GetEnumerator()).OfType<MetaClass>() //785:38
                select new { __loop47_var1 = __loop47_var1, cls = cls}
                ).ToList(); //785:3
            for (int __loop47_iteration = 0; __loop47_iteration < __loop47_results.Count; ++__loop47_iteration)
            {
                var __tmp7 = __loop47_results[__loop47_iteration];
                var __loop47_var1 = __tmp7.__loop47_var1;
                var cls = __tmp7.cls;
                var __loop48_results = 
                    (from __loop48_var1 in __Enumerate((cls).GetEnumerator()) //786:8
                    from prop in __Enumerate((__loop48_var1.Properties).GetEnumerator()) //786:13
                    where prop.Kind == MetaPropertyKind.Readonly || prop.Kind == MetaPropertyKind.Lazy || prop.Kind == MetaPropertyKind.Derived //786:29
                    select new { __loop48_var1 = __loop48_var1, prop = prop}
                    ).ToList(); //786:3
                for (int __loop48_iteration = 0; __loop48_iteration < __loop48_results.Count; ++__loop48_iteration)
                {
                    var __tmp8 = __loop48_results[__loop48_iteration];
                    var __loop48_var1 = __tmp8.__loop48_var1;
                    var prop = __tmp8.prop;
                    if (metaMetaModel && cls.Name == "MetaConstant" && prop.Name == "Value") //787:4
                    {
                    }
                    else //788:4
                    {
                        __out.AppendLine(true); //789:2
                        __out.Write("	/// <summary>"); //790:1
                        __out.AppendLine(false); //790:15
                        bool __tmp10_outputWritten = false;
                        string __tmp11_line = "	/// Computes the value of the property: "; //791:1
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
                        string __tmp13_line = "."; //791:86
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
                            __out.AppendLine(false); //791:111
                        }
                        __out.Write("	/// </summary	"); //792:1
                        __out.AppendLine(false); //792:16
                        bool __tmp16_outputWritten = false;
                        string __tmp17_line = "	public override "; //793:1
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
                        string __tmp19_line = " "; //793:81
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
                        string __tmp21_line = "_ComputeProperty_"; //793:126
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
                        string __tmp23_line = "("; //793:167
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
                        string __tmp25_line = " _this)"; //793:210
                        if (!string.IsNullOrEmpty(__tmp25_line))
                        {
                            __out.Write(__tmp25_line);
                            __tmp16_outputWritten = true;
                        }
                        if (__tmp16_outputWritten) __out.AppendLine(true);
                        if (__tmp16_outputWritten)
                        {
                            __out.AppendLine(false); //793:217
                        }
                        __out.Write("	{"); //794:1
                        __out.AppendLine(false); //794:3
                        bool __tmp27_outputWritten = false;
                        string __tmp26Prefix = "		"; //795:1
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
                            __out.AppendLine(false); //795:84
                        }
                        __out.Write("	}"); //796:1
                        __out.AppendLine(false); //796:3
                    }
                }
                var __loop49_results = 
                    (from __loop49_var1 in __Enumerate((cls).GetEnumerator()) //799:8
                    from op in __Enumerate((__loop49_var1.Operations).GetEnumerator()) //799:13
                    select new { __loop49_var1 = __loop49_var1, op = op}
                    ).ToList(); //799:3
                for (int __loop49_iteration = 0; __loop49_iteration < __loop49_results.Count; ++__loop49_iteration)
                {
                    var __tmp29 = __loop49_results[__loop49_iteration];
                    var __loop49_var1 = __tmp29.__loop49_var1;
                    var op = __tmp29.op;
                    __out.AppendLine(true); //800:2
                    __out.Write("	/// <summary>"); //801:1
                    __out.AppendLine(false); //801:15
                    bool __tmp31_outputWritten = false;
                    string __tmp32_line = "	/// Implements the operation: "; //802:1
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
                    string __tmp34_line = "."; //802:74
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
                    string __tmp36_line = "()"; //802:84
                    if (!string.IsNullOrEmpty(__tmp36_line))
                    {
                        __out.Write(__tmp36_line);
                        __tmp31_outputWritten = true;
                    }
                    if (__tmp31_outputWritten) __out.AppendLine(true);
                    if (__tmp31_outputWritten)
                    {
                        __out.AppendLine(false); //802:86
                    }
                    __out.Write("	/// </summary>"); //803:1
                    __out.AppendLine(false); //803:16
                    bool __tmp38_outputWritten = false;
                    string __tmp39_line = "	public override "; //804:1
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
                    string __tmp41_line = " "; //804:85
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
                    string __tmp43_line = "_"; //804:130
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
                    string __tmp45_line = "("; //804:140
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
                    string __tmp47_line = ")"; //804:204
                    if (!string.IsNullOrEmpty(__tmp47_line))
                    {
                        __out.Write(__tmp47_line);
                        __tmp38_outputWritten = true;
                    }
                    if (__tmp38_outputWritten) __out.AppendLine(true);
                    if (__tmp38_outputWritten)
                    {
                        __out.AppendLine(false); //804:205
                    }
                    __out.Write("	{"); //805:1
                    __out.AppendLine(false); //805:3
                    bool __tmp49_outputWritten = false;
                    string __tmp48Prefix = "		"; //806:1
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
                        __out.AppendLine(false); //806:88
                    }
                    __out.Write("	}"); //807:1
                    __out.AppendLine(false); //807:3
                }
                __out.AppendLine(true); //809:2
            }
            var __loop50_results = 
                (from __loop50_var1 in __Enumerate((model).GetEnumerator()) //811:8
                from Namespace in __Enumerate((__loop50_var1.Namespace).GetEnumerator()) //811:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //811:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //811:40
                select new { __loop50_var1 = __loop50_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //811:3
            for (int __loop50_iteration = 0; __loop50_iteration < __loop50_results.Count; ++__loop50_iteration)
            {
                var __tmp51 = __loop50_results[__loop50_iteration];
                var __loop50_var1 = __tmp51.__loop50_var1;
                var Namespace = __tmp51.Namespace;
                var Declarations = __tmp51.Declarations;
                var enm = __tmp51.enm;
                var __loop51_results = 
                    (from __loop51_var1 in __Enumerate((enm).GetEnumerator()) //812:8
                    from op in __Enumerate((__loop51_var1.Operations).GetEnumerator()) //812:13
                    select new { __loop51_var1 = __loop51_var1, op = op}
                    ).ToList(); //812:3
                for (int __loop51_iteration = 0; __loop51_iteration < __loop51_results.Count; ++__loop51_iteration)
                {
                    var __tmp52 = __loop51_results[__loop51_iteration];
                    var __loop51_var1 = __tmp52.__loop51_var1;
                    var op = __tmp52.op;
                    __out.AppendLine(true); //813:2
                    __out.Write("	/// <summary>"); //814:1
                    __out.AppendLine(false); //814:15
                    bool __tmp54_outputWritten = false;
                    string __tmp55_line = "	/// Implements the operation: "; //815:1
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
                    string __tmp57_line = "."; //815:76
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
                        __out.AppendLine(false); //815:86
                    }
                    __out.Write("	/// </summary>"); //816:1
                    __out.AppendLine(false); //816:16
                    bool __tmp60_outputWritten = false;
                    string __tmp61_line = "	public override "; //817:1
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
                    string __tmp63_line = " "; //817:87
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
                    string __tmp65_line = "_"; //817:132
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
                    string __tmp67_line = "("; //817:142
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
                    string __tmp69_line = ")"; //817:208
                    if (!string.IsNullOrEmpty(__tmp69_line))
                    {
                        __out.Write(__tmp69_line);
                        __tmp60_outputWritten = true;
                    }
                    if (__tmp60_outputWritten) __out.AppendLine(true);
                    if (__tmp60_outputWritten)
                    {
                        __out.AppendLine(false); //817:209
                    }
                    __out.Write("	{"); //818:1
                    __out.AppendLine(false); //818:3
                    bool __tmp71_outputWritten = false;
                    string __tmp70Prefix = "		"; //819:1
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
                        __out.AppendLine(false); //819:90
                    }
                    __out.Write("	}"); //820:1
                    __out.AppendLine(false); //820:3
                }
                __out.AppendLine(true); //822:2
            }
            __out.Write("}"); //824:1
            __out.AppendLine(false); //824:2
            return __out.ToStringAndFree();
        }

        public string GetImplParameters(MetaModel model, MetaClass cls, MetaOperation op, ClassKind kind) //827:1
        {
            string result = CSharpName(cls, model, kind) + " _this"; //828:2
            string delim = ", "; //829:2
            var __loop52_results = 
                (from __loop52_var1 in __Enumerate((op).GetEnumerator()) //830:7
                from param in __Enumerate((__loop52_var1.Parameters).GetEnumerator()) //830:11
                select new { __loop52_var1 = __loop52_var1, param = param}
                ).ToList(); //830:2
            for (int __loop52_iteration = 0; __loop52_iteration < __loop52_results.Count; ++__loop52_iteration)
            {
                var __tmp1 = __loop52_results[__loop52_iteration];
                var __loop52_var1 = __tmp1.__loop52_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, kind, true) + " " + param.Name; //831:3
            }
            return result; //833:2
        }

        public string GetImplParameters(MetaModel model, MetaEnum enm, MetaOperation op, ClassKind kind) //836:1
        {
            string result = CSharpName(enm, model, kind) + " _this"; //837:2
            string delim = ", "; //838:2
            var __loop53_results = 
                (from __loop53_var1 in __Enumerate((op).GetEnumerator()) //839:7
                from param in __Enumerate((__loop53_var1.Parameters).GetEnumerator()) //839:11
                select new { __loop53_var1 = __loop53_var1, param = param}
                ).ToList(); //839:2
            for (int __loop53_iteration = 0; __loop53_iteration < __loop53_results.Count; ++__loop53_iteration)
            {
                var __tmp1 = __loop53_results[__loop53_iteration];
                var __loop53_var1 = __tmp1.__loop53_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, kind, true) + " " + param.Name; //840:3
            }
            return result; //842:2
        }

        public string GenerateEnum(MetaModel model, MetaEnum enm) //846:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.AppendLine(true); //847:1
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
                __out.AppendLine(false); //848:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public enum "; //849:1
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
                __out.AppendLine(false); //849:36
            }
            __out.Write("{"); //850:1
            __out.AppendLine(false); //850:2
            var __loop54_results = 
                (from __loop54_var1 in __Enumerate((enm).GetEnumerator()) //851:8
                from value in __Enumerate((__loop54_var1.EnumLiterals).GetEnumerator()) //851:13
                select new { __loop54_var1 = __loop54_var1, value = value}
                ).ToList(); //851:3
            for (int __loop54_iteration = 0; __loop54_iteration < __loop54_results.Count; ++__loop54_iteration)
            {
                string delim; //851:31
                if (__loop54_iteration+1 < __loop54_results.Count) delim = ",";
                else delim = string.Empty;
                var __tmp8 = __loop54_results[__loop54_iteration];
                var __loop54_var1 = __tmp8.__loop54_var1;
                var value = __tmp8.value;
                bool __tmp10_outputWritten = false;
                string __tmp9Prefix = "	"; //852:1
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
                    __out.AppendLine(false); //852:32
                }
                bool __tmp13_outputWritten = false;
                string __tmp12Prefix = "	"; //853:1
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
                    __out.AppendLine(false); //853:21
                }
            }
            __out.Write("}"); //855:1
            __out.AppendLine(false); //855:2
            __out.AppendLine(true); //856:1
            bool __tmp17_outputWritten = false;
            string __tmp18_line = "public static class "; //857:1
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
            string __tmp20_line = "Extensions"; //857:31
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Write(__tmp20_line);
                __tmp17_outputWritten = true;
            }
            if (__tmp17_outputWritten) __out.AppendLine(true);
            if (__tmp17_outputWritten)
            {
                __out.AppendLine(false); //857:41
            }
            __out.Write("{"); //858:1
            __out.AppendLine(false); //858:2
            var __loop55_results = 
                (from __loop55_var1 in __Enumerate((enm).GetEnumerator()) //859:8
                from op in __Enumerate((__loop55_var1.Operations).GetEnumerator()) //859:13
                select new { __loop55_var1 = __loop55_var1, op = op}
                ).ToList(); //859:3
            for (int __loop55_iteration = 0; __loop55_iteration < __loop55_results.Count; ++__loop55_iteration)
            {
                var __tmp21 = __loop55_results[__loop55_iteration];
                var __loop55_var1 = __tmp21.__loop55_var1;
                var op = __tmp21.op;
                bool __tmp23_outputWritten = false;
                string __tmp24_line = "	public static "; //860:1
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
                string __tmp26_line = " "; //860:79
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
                string __tmp28_line = "("; //860:89
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
                string __tmp30_line = ")"; //860:159
                if (!string.IsNullOrEmpty(__tmp30_line))
                {
                    __out.Write(__tmp30_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //860:160
                }
                __out.Write("	{"); //861:1
                __out.AppendLine(false); //861:3
                bool __tmp32_outputWritten = false;
                string __tmp31Prefix = "		"; //862:1
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
                string __tmp35_line = ".Implementation."; //862:129
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
                string __tmp37_line = "_"; //862:193
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
                string __tmp39_line = "("; //862:203
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
                string __tmp41_line = ");"; //862:276
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Write(__tmp41_line);
                    __tmp32_outputWritten = true;
                }
                if (__tmp32_outputWritten) __out.AppendLine(true);
                if (__tmp32_outputWritten)
                {
                    __out.AppendLine(false); //862:278
                }
                __out.Write("	}"); //863:1
                __out.AppendLine(false); //863:3
            }
            __out.Write("}"); //865:1
            __out.AppendLine(false); //865:2
            return __out.ToStringAndFree();
        }

        public string GetEnumImplParameters(MetaModel model, MetaEnum enm, MetaOperation op, ClassKind kind) //868:1
        {
            string result = "this " + CSharpName(enm, model, kind) + " _this"; //869:2
            string delim = ", "; //870:2
            var __loop56_results = 
                (from __loop56_var1 in __Enumerate((op).GetEnumerator()) //871:7
                from param in __Enumerate((__loop56_var1.Parameters).GetEnumerator()) //871:11
                select new { __loop56_var1 = __loop56_var1, param = param}
                ).ToList(); //871:2
            for (int __loop56_iteration = 0; __loop56_iteration < __loop56_results.Count; ++__loop56_iteration)
            {
                var __tmp1 = __loop56_results[__loop56_iteration];
                var __loop56_var1 = __tmp1.__loop56_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, kind) + " " + param.Name; //872:3
            }
            return result; //874:2
        }

        public string GetEnumImplCallParameterNames(MetaModel model, MetaOperation op, ClassKind kind) //877:1
        {
            string result = "_this"; //878:2
            string delim = ", "; //879:2
            var __loop57_results = 
                (from __loop57_var1 in __Enumerate((op).GetEnumerator()) //880:7
                from param in __Enumerate((__loop57_var1.Parameters).GetEnumerator()) //880:11
                select new { __loop57_var1 = __loop57_var1, param = param}
                ).ToList(); //880:2
            for (int __loop57_iteration = 0; __loop57_iteration < __loop57_results.Count; ++__loop57_iteration)
            {
                var __tmp1 = __loop57_results[__loop57_iteration];
                var __loop57_var1 = __tmp1.__loop57_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //881:3
            }
            return result; //883:2
        }

        public string GetClassParameters(MetaModel model, MetaClass cls, MetaOperation op, ClassKind kind) //886:1
        {
            string result = ""; //887:2
            var __loop58_results = 
                (from __loop58_var1 in __Enumerate((op).GetEnumerator()) //888:7
                from param in __Enumerate((__loop58_var1.Parameters).GetEnumerator()) //888:11
                select new { __loop58_var1 = __loop58_var1, param = param}
                ).ToList(); //888:2
            for (int __loop58_iteration = 0; __loop58_iteration < __loop58_results.Count; ++__loop58_iteration)
            {
                string delim; //888:27
                if (__loop58_iteration+1 < __loop58_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop58_results[__loop58_iteration];
                var __loop58_var1 = __tmp1.__loop58_var1;
                var param = __tmp1.param;
                result += CSharpName(param.Type, model, kind, true) + " " + param.Name + delim; //889:3
            }
            return result; //891:2
        }

        public string GetClassImplCallParameterNames(MetaModel model, MetaOperation op, ClassKind kind) //894:1
        {
            string result = "this"; //895:2
            string delim = ", "; //896:2
            var __loop59_results = 
                (from __loop59_var1 in __Enumerate((op).GetEnumerator()) //897:7
                from param in __Enumerate((__loop59_var1.Parameters).GetEnumerator()) //897:11
                select new { __loop59_var1 = __loop59_var1, param = param}
                ).ToList(); //897:2
            for (int __loop59_iteration = 0; __loop59_iteration < __loop59_results.Count; ++__loop59_iteration)
            {
                var __tmp1 = __loop59_results[__loop59_iteration];
                var __loop59_var1 = __tmp1.__loop59_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //898:3
            }
            return result; //900:2
        }

        public string GetReturn(string returnType) //903:1
        {
            if (returnType == "void") //904:5
            {
                return ""; //905:3
            }
            else //906:2
            {
                return "return "; //907:3
            }
        }

        public string GetDefaultReturn(string returnType) //911:1
        {
            if (returnType == "void") //912:5
            {
                return ""; //913:3
            }
            else //914:2
            {
                return "return default(" + returnType + ");"; //915:3
            }
        }

        public string GenerateClass(MetaModel model, MetaClass cls) //919:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.AppendLine(true); //920:1
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
                __out.AppendLine(false); //921:37
            }
            __out.AppendLine(true); //922:1
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
                __out.AppendLine(false); //923:35
            }
            return __out.ToStringAndFree();
        }

        public string GenerateClassInternal(MetaModel model, MetaClass cls) //926:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.AppendLine(true); //927:1
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
                __out.AppendLine(false); //928:30
            }
            __out.AppendLine(true); //929:1
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
                __out.AppendLine(false); //930:41
            }
            __out.AppendLine(true); //931:1
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
                __out.AppendLine(false); //932:39
            }
            return __out.ToStringAndFree();
        }

        public string GenerateIdClass(MetaModel model, MetaClass cls) //935:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //936:1
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
            string __tmp5_line = " : "; //936:53
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
            string __tmp7_line = ".ObjectId"; //936:75
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //936:84
            }
            __out.Write("{"); //937:1
            __out.AppendLine(false); //937:2
            bool __tmp9_outputWritten = false;
            string __tmp10_line = "	public override "; //938:1
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
            string __tmp12_line = ".ModelObjectDescriptor Descriptor { get { return "; //938:37
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
            string __tmp14_line = ".MDescriptor; } }"; //938:136
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp9_outputWritten = true;
            }
            if (__tmp9_outputWritten) __out.AppendLine(true);
            if (__tmp9_outputWritten)
            {
                __out.AppendLine(false); //938:153
            }
            __out.AppendLine(true); //939:1
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "	public override "; //940:1
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
            string __tmp19_line = ".ImmutableObjectBase CreateImmutable("; //940:37
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
            string __tmp21_line = ".ImmutableModel model)"; //940:93
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //940:115
            }
            __out.Write("	{"); //941:1
            __out.AppendLine(false); //941:3
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "		return new "; //942:1
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
            string __tmp26_line = "(this, model);"; //942:62
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Write(__tmp26_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //942:76
            }
            __out.Write("	}"); //943:1
            __out.AppendLine(false); //943:3
            __out.AppendLine(true); //944:1
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "	public override "; //945:1
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
            string __tmp31_line = ".MutableObjectBase CreateMutable("; //945:37
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
            string __tmp33_line = ".MutableModel model, bool creating)"; //945:89
            if (!string.IsNullOrEmpty(__tmp33_line))
            {
                __out.Write(__tmp33_line);
                __tmp28_outputWritten = true;
            }
            if (__tmp28_outputWritten) __out.AppendLine(true);
            if (__tmp28_outputWritten)
            {
                __out.AppendLine(false); //945:124
            }
            __out.Write("	{"); //946:1
            __out.AppendLine(false); //946:3
            bool __tmp35_outputWritten = false;
            string __tmp36_line = "		return new "; //947:1
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
            string __tmp38_line = "(this, model, creating);"; //947:60
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Write(__tmp38_line);
                __tmp35_outputWritten = true;
            }
            if (__tmp35_outputWritten) __out.AppendLine(true);
            if (__tmp35_outputWritten)
            {
                __out.AppendLine(false); //947:84
            }
            __out.Write("	}"); //948:1
            __out.AppendLine(false); //948:3
            __out.Write("}"); //949:1
            __out.AppendLine(false); //949:2
            return __out.ToStringAndFree();
        }

        public string GenerateImmutableClass(MetaModel model, MetaClass cls) //952:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool metaMetaModel = IsMetaMetaModel(model); //953:2
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
                __out.AppendLine(false); //954:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public interface "; //955:1
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
                if (!__tmp8_last) __out.AppendLine(true);
            }
            var __tmp9 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp9.Write(metaMetaModel && cls.Name == "MetaModel" ? ", " + Properties.CoreNs + ".IMetaModel" : "");
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
                __out.AppendLine(false); //955:183
            }
            __out.Write("{"); //956:1
            __out.AppendLine(false); //956:2
            if (metaMetaModel && cls.Name == "MetaModel") //957:3
            {
                __out.Write("	/// <summary>"); //958:1
                __out.AppendLine(false); //958:15
                __out.Write("	/// The name of the metamodel."); //959:1
                __out.AppendLine(false); //959:32
                __out.Write("	/// </summary>"); //960:1
                __out.AppendLine(false); //960:16
                __out.Write("	new string Name { get; }"); //961:1
                __out.AppendLine(false); //961:26
            }
            var __loop60_results = 
                (from __loop60_var1 in __Enumerate((cls).GetEnumerator()) //963:8
                from prop in __Enumerate((__loop60_var1.Properties).GetEnumerator()) //963:13
                select new { __loop60_var1 = __loop60_var1, prop = prop}
                ).ToList(); //963:3
            for (int __loop60_iteration = 0; __loop60_iteration < __loop60_results.Count; ++__loop60_iteration)
            {
                var __tmp10 = __loop60_results[__loop60_iteration];
                var __loop60_var1 = __tmp10.__loop60_var1;
                var prop = __tmp10.prop;
                bool __tmp12_outputWritten = false;
                string __tmp11Prefix = "	"; //964:1
                var __tmp13 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp13.Write(GenerateImmutableProperty(model, prop));
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
                    __out.AppendLine(false); //964:42
                }
            }
            __out.AppendLine(true); //966:1
            var __loop61_results = 
                (from __loop61_var1 in __Enumerate((cls).GetEnumerator()) //967:8
                from op in __Enumerate((__loop61_var1.Operations).GetEnumerator()) //967:13
                where !op.IsBuilder //967:27
                select new { __loop61_var1 = __loop61_var1, op = op}
                ).ToList(); //967:3
            for (int __loop61_iteration = 0; __loop61_iteration < __loop61_results.Count; ++__loop61_iteration)
            {
                var __tmp14 = __loop61_results[__loop61_iteration];
                var __loop61_var1 = __tmp14.__loop61_var1;
                var op = __tmp14.op;
                bool __tmp16_outputWritten = false;
                string __tmp15Prefix = "	"; //968:1
                var __tmp17 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp17.Write(GenerateImmutableOperation(model, op));
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
                    __out.AppendLine(false); //968:41
                }
            }
            __out.AppendLine(true); //970:1
            __out.Write("	/// <summary>"); //971:1
            __out.AppendLine(false); //971:15
            bool __tmp19_outputWritten = false;
            string __tmp20_line = "	/// Convert the <see cref=\""; //972:1
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Write(__tmp20_line);
                __tmp19_outputWritten = true;
            }
            var __tmp21 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp21.Write(CSharpName(cls, model, ClassKind.Immutable));
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
            string __tmp22_line = "\"/> object to a builder <see cref=\""; //972:73
            if (!string.IsNullOrEmpty(__tmp22_line))
            {
                __out.Write(__tmp22_line);
                __tmp19_outputWritten = true;
            }
            var __tmp23 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp23.Write(CSharpName(cls, model, ClassKind.Builder));
            var __tmp23Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp23.ToStringAndFree());
            bool __tmp23_last = __tmp23Reader.EndOfStream;
            while(!__tmp23_last)
            {
                ReadOnlySpan<char> __tmp23_line = __tmp23Reader.ReadLine();
                __tmp23_last = __tmp23Reader.EndOfStream;
                if (!__tmp23_last || !__tmp23_line.IsEmpty)
                {
                    __out.Write(__tmp23_line);
                    __tmp19_outputWritten = true;
                }
                if (!__tmp23_last) __out.AppendLine(true);
            }
            string __tmp24_line = "\"/> object."; //972:150
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Write(__tmp24_line);
                __tmp19_outputWritten = true;
            }
            if (__tmp19_outputWritten) __out.AppendLine(true);
            if (__tmp19_outputWritten)
            {
                __out.AppendLine(false); //972:161
            }
            __out.Write("	/// </summary>"); //973:1
            __out.AppendLine(false); //973:16
            bool __tmp26_outputWritten = false;
            string __tmp27_line = "	new "; //974:1
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Write(__tmp27_line);
                __tmp26_outputWritten = true;
            }
            var __tmp28 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp28.Write(CSharpName(cls, model, ClassKind.Builder, true));
            var __tmp28Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp28.ToStringAndFree());
            bool __tmp28_last = __tmp28Reader.EndOfStream;
            while(!__tmp28_last)
            {
                ReadOnlySpan<char> __tmp28_line = __tmp28Reader.ReadLine();
                __tmp28_last = __tmp28Reader.EndOfStream;
                if (!__tmp28_last || !__tmp28_line.IsEmpty)
                {
                    __out.Write(__tmp28_line);
                    __tmp26_outputWritten = true;
                }
                if (!__tmp28_last) __out.AppendLine(true);
            }
            string __tmp29_line = " ToMutable();"; //974:54
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Write(__tmp29_line);
                __tmp26_outputWritten = true;
            }
            if (__tmp26_outputWritten) __out.AppendLine(true);
            if (__tmp26_outputWritten)
            {
                __out.AppendLine(false); //974:67
            }
            __out.Write("	/// <summary>"); //975:1
            __out.AppendLine(false); //975:15
            bool __tmp31_outputWritten = false;
            string __tmp32_line = "	/// Convert the <see cref=\""; //976:1
            if (!string.IsNullOrEmpty(__tmp32_line))
            {
                __out.Write(__tmp32_line);
                __tmp31_outputWritten = true;
            }
            var __tmp33 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp33.Write(CSharpName(cls, model, ClassKind.Immutable));
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
            string __tmp34_line = "\"/> object to a builder <see cref=\""; //976:73
            if (!string.IsNullOrEmpty(__tmp34_line))
            {
                __out.Write(__tmp34_line);
                __tmp31_outputWritten = true;
            }
            var __tmp35 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp35.Write(CSharpName(cls, model, ClassKind.Builder));
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
            string __tmp36_line = "\"/> object"; //976:150
            if (!string.IsNullOrEmpty(__tmp36_line))
            {
                __out.Write(__tmp36_line);
                __tmp31_outputWritten = true;
            }
            if (__tmp31_outputWritten) __out.AppendLine(true);
            if (__tmp31_outputWritten)
            {
                __out.AppendLine(false); //976:160
            }
            __out.Write("	/// by taking the builder version from the given model."); //977:1
            __out.AppendLine(false); //977:57
            __out.Write("	/// </summary>"); //978:1
            __out.AppendLine(false); //978:16
            __out.Write("	/// <param name=\"model\">The mutable model from which the return value is taken from.</param>"); //979:1
            __out.AppendLine(false); //979:94
            bool __tmp38_outputWritten = false;
            string __tmp39_line = "	new "; //980:1
            if (!string.IsNullOrEmpty(__tmp39_line))
            {
                __out.Write(__tmp39_line);
                __tmp38_outputWritten = true;
            }
            var __tmp40 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp40.Write(CSharpName(cls, model, ClassKind.Builder, true));
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
            string __tmp41_line = " ToMutable("; //980:54
            if (!string.IsNullOrEmpty(__tmp41_line))
            {
                __out.Write(__tmp41_line);
                __tmp38_outputWritten = true;
            }
            var __tmp42 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp42.Write(Properties.CoreNs);
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
            string __tmp43_line = ".MutableModel model);"; //980:84
            if (!string.IsNullOrEmpty(__tmp43_line))
            {
                __out.Write(__tmp43_line);
                __tmp38_outputWritten = true;
            }
            if (__tmp38_outputWritten) __out.AppendLine(true);
            if (__tmp38_outputWritten)
            {
                __out.AppendLine(false); //980:105
            }
            __out.Write("}"); //981:1
            __out.AppendLine(false); //981:2
            return __out.ToStringAndFree();
        }

        public string GenerateImmutableProperty(MetaModel model, MetaProperty prop) //984:1
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
                __out.AppendLine(false); //985:30
            }
            if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name) || (IsMetaMetaModel(model) && prop.Class.Name == "MetaModel")) //986:2
            {
                __out.Write("new "); //987:1
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
            string __tmp7_line = " "; //989:57
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
            string __tmp9_line = " { get; }"; //989:106
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Write(__tmp9_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //989:115
            }
            return __out.ToStringAndFree();
        }

        public string GenerateImmutableOperation(MetaModel model, MetaOperation op) //992:1
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
                __out.AppendLine(false); //993:28
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
            string __tmp7_line = " "; //994:70
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
            string __tmp9_line = "("; //994:80
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
            string __tmp11_line = ");"; //994:155
            if (!string.IsNullOrEmpty(__tmp11_line))
            {
                __out.Write(__tmp11_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //994:157
            }
            return __out.ToStringAndFree();
        }

        public string GetImmutableOperationParameters(MetaModel model, MetaOperation op, ClassKind kind) //997:1
        {
            string result = ""; //998:2
            var __loop62_results = 
                (from __loop62_var1 in __Enumerate((op).GetEnumerator()) //999:7
                from param in __Enumerate((__loop62_var1.Parameters).GetEnumerator()) //999:11
                select new { __loop62_var1 = __loop62_var1, param = param}
                ).ToList(); //999:2
            for (int __loop62_iteration = 0; __loop62_iteration < __loop62_results.Count; ++__loop62_iteration)
            {
                string delim; //999:27
                if (__loop62_iteration+1 < __loop62_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop62_results[__loop62_iteration];
                var __loop62_var1 = __tmp1.__loop62_var1;
                var param = __tmp1.param;
                result += CSharpName(param.Type, model, kind, true) + " " + param.Name + delim; //1000:3
            }
            return result; //1002:2
        }

        public string GetImmutableAncestors(MetaModel model, MetaClass cls) //1005:1
        {
            string result = ""; //1006:2
            var __loop63_results = 
                (from __loop63_var1 in __Enumerate((cls).GetEnumerator()) //1007:7
                from super in __Enumerate((__loop63_var1.SuperClasses).GetEnumerator()) //1007:12
                select new { __loop63_var1 = __loop63_var1, super = super}
                ).ToList(); //1007:2
            for (int __loop63_iteration = 0; __loop63_iteration < __loop63_results.Count; ++__loop63_iteration)
            {
                string delim; //1007:30
                if (__loop63_iteration+1 < __loop63_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop63_results[__loop63_iteration];
                var __loop63_var1 = __tmp1.__loop63_var1;
                var super = __tmp1.super;
                result += CSharpName(super, model, ClassKind.Immutable, true) + delim; //1008:3
            }
            if (result == "") //1010:2
            {
                result = Properties.CoreNs + ".ImmutableObject"; //1011:3
            }
            result = " : " + result; //1013:2
            return result; //1014:2
        }

        public string GenerateBuilderClass(MetaModel model, MetaClass cls) //1017:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool metaMetaModel = IsMetaMetaModel(model); //1018:2
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
                __out.AppendLine(false); //1019:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public interface "; //1020:1
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
                if (!__tmp8_last) __out.AppendLine(true);
            }
            var __tmp9 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp9.Write(metaMetaModel && cls.Name == "MetaModel" ? ", " + Properties.CoreNs + ".IMetaModel" : "");
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
                __out.AppendLine(false); //1020:179
            }
            __out.Write("{"); //1021:1
            __out.AppendLine(false); //1021:2
            if (metaMetaModel && cls.Name == "MetaModel") //1022:3
            {
                __out.Write("	/// <summary>"); //1023:1
                __out.AppendLine(false); //1023:15
                __out.Write("	/// The name of the metamodel."); //1024:1
                __out.AppendLine(false); //1024:32
                __out.Write("	/// </summary>"); //1025:1
                __out.AppendLine(false); //1025:16
                __out.Write("	new string Name { get; set; }"); //1026:1
                __out.AppendLine(false); //1026:31
            }
            var __loop64_results = 
                (from __loop64_var1 in __Enumerate((cls).GetEnumerator()) //1028:8
                from prop in __Enumerate((__loop64_var1.Properties).GetEnumerator()) //1028:13
                select new { __loop64_var1 = __loop64_var1, prop = prop}
                ).ToList(); //1028:3
            for (int __loop64_iteration = 0; __loop64_iteration < __loop64_results.Count; ++__loop64_iteration)
            {
                var __tmp10 = __loop64_results[__loop64_iteration];
                var __loop64_var1 = __tmp10.__loop64_var1;
                var prop = __tmp10.prop;
                bool __tmp12_outputWritten = false;
                string __tmp11Prefix = "	"; //1029:1
                var __tmp13 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp13.Write(GenerateBuilderProperty(model, prop));
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
                    __out.AppendLine(false); //1029:40
                }
            }
            __out.AppendLine(true); //1031:1
            var __loop65_results = 
                (from __loop65_var1 in __Enumerate((cls).GetEnumerator()) //1032:8
                from op in __Enumerate((__loop65_var1.Operations).GetEnumerator()) //1032:13
                select new { __loop65_var1 = __loop65_var1, op = op}
                ).ToList(); //1032:3
            for (int __loop65_iteration = 0; __loop65_iteration < __loop65_results.Count; ++__loop65_iteration)
            {
                var __tmp14 = __loop65_results[__loop65_iteration];
                var __loop65_var1 = __tmp14.__loop65_var1;
                var op = __tmp14.op;
                bool __tmp16_outputWritten = false;
                string __tmp15Prefix = "	"; //1033:1
                var __tmp17 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp17.Write(GenerateBuilderOperation(model, op));
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
                    __out.AppendLine(false); //1033:39
                }
            }
            __out.AppendLine(true); //1035:1
            __out.Write("	/// <summary>"); //1036:1
            __out.AppendLine(false); //1036:15
            bool __tmp19_outputWritten = false;
            string __tmp20_line = "	/// Convert the <see cref=\""; //1037:1
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Write(__tmp20_line);
                __tmp19_outputWritten = true;
            }
            var __tmp21 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp21.Write(CSharpName(cls, model, ClassKind.Builder));
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
            string __tmp22_line = "\"/> object to an immutable <see cref=\""; //1037:71
            if (!string.IsNullOrEmpty(__tmp22_line))
            {
                __out.Write(__tmp22_line);
                __tmp19_outputWritten = true;
            }
            var __tmp23 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp23.Write(CSharpName(cls, model, ClassKind.Immutable));
            var __tmp23Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp23.ToStringAndFree());
            bool __tmp23_last = __tmp23Reader.EndOfStream;
            while(!__tmp23_last)
            {
                ReadOnlySpan<char> __tmp23_line = __tmp23Reader.ReadLine();
                __tmp23_last = __tmp23Reader.EndOfStream;
                if (!__tmp23_last || !__tmp23_line.IsEmpty)
                {
                    __out.Write(__tmp23_line);
                    __tmp19_outputWritten = true;
                }
                if (!__tmp23_last) __out.AppendLine(true);
            }
            string __tmp24_line = "\"/> object."; //1037:153
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Write(__tmp24_line);
                __tmp19_outputWritten = true;
            }
            if (__tmp19_outputWritten) __out.AppendLine(true);
            if (__tmp19_outputWritten)
            {
                __out.AppendLine(false); //1037:164
            }
            __out.Write("	/// </summary>"); //1038:1
            __out.AppendLine(false); //1038:16
            bool __tmp26_outputWritten = false;
            string __tmp27_line = "	new "; //1039:1
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Write(__tmp27_line);
                __tmp26_outputWritten = true;
            }
            var __tmp28 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp28.Write(CSharpName(cls, model, ClassKind.Immutable, true));
            var __tmp28Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp28.ToStringAndFree());
            bool __tmp28_last = __tmp28Reader.EndOfStream;
            while(!__tmp28_last)
            {
                ReadOnlySpan<char> __tmp28_line = __tmp28Reader.ReadLine();
                __tmp28_last = __tmp28Reader.EndOfStream;
                if (!__tmp28_last || !__tmp28_line.IsEmpty)
                {
                    __out.Write(__tmp28_line);
                    __tmp26_outputWritten = true;
                }
                if (!__tmp28_last) __out.AppendLine(true);
            }
            string __tmp29_line = " ToImmutable();"; //1039:56
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Write(__tmp29_line);
                __tmp26_outputWritten = true;
            }
            if (__tmp26_outputWritten) __out.AppendLine(true);
            if (__tmp26_outputWritten)
            {
                __out.AppendLine(false); //1039:71
            }
            __out.Write("	/// <summary>"); //1040:1
            __out.AppendLine(false); //1040:15
            bool __tmp31_outputWritten = false;
            string __tmp32_line = "	/// Convert the <see cref=\""; //1041:1
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
            string __tmp34_line = "\"/> object to an immutable <see cref=\""; //1041:71
            if (!string.IsNullOrEmpty(__tmp34_line))
            {
                __out.Write(__tmp34_line);
                __tmp31_outputWritten = true;
            }
            var __tmp35 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp35.Write(CSharpName(cls, model, ClassKind.Immutable));
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
            string __tmp36_line = "\"/> object"; //1041:153
            if (!string.IsNullOrEmpty(__tmp36_line))
            {
                __out.Write(__tmp36_line);
                __tmp31_outputWritten = true;
            }
            if (__tmp31_outputWritten) __out.AppendLine(true);
            if (__tmp31_outputWritten)
            {
                __out.AppendLine(false); //1041:163
            }
            __out.Write("	/// by taking the immutable version from the given model."); //1042:1
            __out.AppendLine(false); //1042:59
            __out.Write("	/// </summary>"); //1043:1
            __out.AppendLine(false); //1043:16
            __out.Write("	/// <param name=\"model\">The immutable model from which the return value is taken from.</param>"); //1044:1
            __out.AppendLine(false); //1044:96
            bool __tmp38_outputWritten = false;
            string __tmp39_line = "	new "; //1045:1
            if (!string.IsNullOrEmpty(__tmp39_line))
            {
                __out.Write(__tmp39_line);
                __tmp38_outputWritten = true;
            }
            var __tmp40 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp40.Write(CSharpName(cls, model, ClassKind.Immutable, true));
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
            string __tmp41_line = " ToImmutable("; //1045:56
            if (!string.IsNullOrEmpty(__tmp41_line))
            {
                __out.Write(__tmp41_line);
                __tmp38_outputWritten = true;
            }
            var __tmp42 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp42.Write(Properties.CoreNs);
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
            string __tmp43_line = ".ImmutableModel model);"; //1045:88
            if (!string.IsNullOrEmpty(__tmp43_line))
            {
                __out.Write(__tmp43_line);
                __tmp38_outputWritten = true;
            }
            if (__tmp38_outputWritten) __out.AppendLine(true);
            if (__tmp38_outputWritten)
            {
                __out.AppendLine(false); //1045:111
            }
            __out.Write("}"); //1046:1
            __out.AppendLine(false); //1046:2
            return __out.ToStringAndFree();
        }

        public string GenerateBuilderProperty(MetaModel model, MetaProperty prop) //1049:1
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
                __out.AppendLine(false); //1050:30
            }
            if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name) || (IsMetaMetaModel(model) && prop.Class.Name == "MetaModel")) //1051:3
            {
                __out.Write("new "); //1052:1
            }
            if ((prop.Kind == MetaPropertyKind.Normal) && !(prop.Type is MetaCollectionType)) //1054:3
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
                string __tmp7_line = " "; //1055:55
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
                string __tmp9_line = " { get; set; }"; //1055:102
                if (!string.IsNullOrEmpty(__tmp9_line))
                {
                    __out.Write(__tmp9_line);
                    __tmp5_outputWritten = true;
                }
                if (__tmp5_outputWritten) __out.AppendLine(true);
                if (__tmp5_outputWritten)
                {
                    __out.AppendLine(false); //1055:116
                }
            }
            else //1056:3
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
                string __tmp13_line = " "; //1057:55
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
                string __tmp15_line = " { get; }"; //1057:102
                if (!string.IsNullOrEmpty(__tmp15_line))
                {
                    __out.Write(__tmp15_line);
                    __tmp11_outputWritten = true;
                }
                if (__tmp11_outputWritten) __out.AppendLine(true);
                if (__tmp11_outputWritten)
                {
                    __out.AppendLine(false); //1057:111
                }
            }
            if (!(prop.Type is MetaCollectionType)) //1059:3
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
                    __out.AppendLine(false); //1060:30
                }
                if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name)) //1061:4
                {
                    __out.Write("new "); //1062:1
                }
                bool __tmp20_outputWritten = false;
                string __tmp21_line = "void Set"; //1064:1
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
                string __tmp23_line = "Lazy(global::System.Func<"; //1064:55
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
                string __tmp25_line = "> lazy);"; //1064:134
                if (!string.IsNullOrEmpty(__tmp25_line))
                {
                    __out.Write(__tmp25_line);
                    __tmp20_outputWritten = true;
                }
                if (__tmp20_outputWritten) __out.AppendLine(true);
                if (__tmp20_outputWritten)
                {
                    __out.AppendLine(false); //1064:142
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
                    __out.AppendLine(false); //1065:30
                }
                if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name)) //1066:4
                {
                    __out.Write("new "); //1067:1
                }
                bool __tmp30_outputWritten = false;
                string __tmp31_line = "void Set"; //1069:1
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
                string __tmp33_line = "Lazy(global::System.Func<"; //1069:55
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
                string __tmp35_line = ", "; //1069:129
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
                string __tmp37_line = "> lazy);"; //1069:185
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Write(__tmp37_line);
                    __tmp30_outputWritten = true;
                }
                if (__tmp30_outputWritten) __out.AppendLine(true);
                if (__tmp30_outputWritten)
                {
                    __out.AppendLine(false); //1069:193
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
                    __out.AppendLine(false); //1070:30
                }
                if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name)) //1071:4
                {
                    __out.Write("new "); //1072:1
                }
                bool __tmp42_outputWritten = false;
                string __tmp43_line = "void Set"; //1074:1
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
                string __tmp45_line = "Lazy(global::System.Func<"; //1074:55
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
                string __tmp47_line = ", "; //1074:131
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
                string __tmp49_line = "> immutableLazy, global::System.Func<"; //1074:189
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
                string __tmp51_line = ", "; //1074:275
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
                string __tmp53_line = "> mutableLazy);"; //1074:331
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Write(__tmp53_line);
                    __tmp42_outputWritten = true;
                }
                if (__tmp42_outputWritten) __out.AppendLine(true);
                if (__tmp42_outputWritten)
                {
                    __out.AppendLine(false); //1074:346
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateBuilderOperation(MetaModel model, MetaOperation op) //1078:1
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
                __out.AppendLine(false); //1079:28
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
            string __tmp7_line = " "; //1080:68
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
            string __tmp9_line = "("; //1080:78
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
            string __tmp11_line = ");"; //1080:149
            if (!string.IsNullOrEmpty(__tmp11_line))
            {
                __out.Write(__tmp11_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //1080:151
            }
            return __out.ToStringAndFree();
        }

        public string GetBuilderOperationParameters(MetaModel model, MetaOperation op, ClassKind kind) //1083:1
        {
            string result = ""; //1084:2
            var __loop66_results = 
                (from __loop66_var1 in __Enumerate((op).GetEnumerator()) //1085:7
                from param in __Enumerate((__loop66_var1.Parameters).GetEnumerator()) //1085:11
                select new { __loop66_var1 = __loop66_var1, param = param}
                ).ToList(); //1085:2
            for (int __loop66_iteration = 0; __loop66_iteration < __loop66_results.Count; ++__loop66_iteration)
            {
                string delim; //1085:27
                if (__loop66_iteration+1 < __loop66_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop66_results[__loop66_iteration];
                var __loop66_var1 = __tmp1.__loop66_var1;
                var param = __tmp1.param;
                result += CSharpName(param.Type, model, kind, true) + " " + param.Name + delim; //1086:3
            }
            return result; //1088:2
        }

        public string GetBuilderAncestors(MetaModel model, MetaClass cls) //1091:1
        {
            string result = ""; //1092:2
            var __loop67_results = 
                (from __loop67_var1 in __Enumerate((cls).GetEnumerator()) //1093:7
                from super in __Enumerate((__loop67_var1.SuperClasses).GetEnumerator()) //1093:12
                select new { __loop67_var1 = __loop67_var1, super = super}
                ).ToList(); //1093:2
            for (int __loop67_iteration = 0; __loop67_iteration < __loop67_results.Count; ++__loop67_iteration)
            {
                string delim; //1093:30
                if (__loop67_iteration+1 < __loop67_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop67_results[__loop67_iteration];
                var __loop67_var1 = __tmp1.__loop67_var1;
                var super = __tmp1.super;
                result += CSharpName(super, model, ClassKind.Builder, true) + delim; //1094:3
            }
            if (result == "") //1096:2
            {
                result = Properties.CoreNs + ".MutableObject"; //1097:3
            }
            result = " : " + result; //1099:2
            return result; //1100:2
        }

        public string GenerateImmutableImplClass(MetaModel model, MetaClass cls) //1103:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool metaMetaModel = IsMetaMetaModel(model); //1104:2
            string metaNs = metaMetaModel ? "" : Properties.MetaNs + "."; //1105:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //1106:1
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
            string __tmp5_line = " : "; //1106:64
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
            string __tmp7_line = ".ImmutableObjectBase, "; //1106:86
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
                __out.AppendLine(false); //1106:152
            }
            __out.Write("{"); //1107:1
            __out.AppendLine(false); //1107:2
            var __loop68_results = 
                (from __loop68_var1 in __Enumerate((cls).GetEnumerator()) //1108:8
                from prop in __Enumerate((__loop68_var1.GetAllProperties()).GetEnumerator()) //1108:13
                select new { __loop68_var1 = __loop68_var1, prop = prop}
                ).ToList(); //1108:3
            for (int __loop68_iteration = 0; __loop68_iteration < __loop68_results.Count; ++__loop68_iteration)
            {
                var __tmp9 = __loop68_results[__loop68_iteration];
                var __loop68_var1 = __tmp9.__loop68_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //1109:1
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
                    __out.AppendLine(false); //1109:44
                }
            }
            __out.AppendLine(true); //1111:2
            bool __tmp14_outputWritten = false;
            string __tmp15_line = "	internal "; //1112:1
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
            string __tmp17_line = "("; //1112:59
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
            string __tmp19_line = ".ObjectId id, "; //1112:79
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
            string __tmp21_line = ".ImmutableModel model)"; //1112:112
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp14_outputWritten = true;
            }
            if (__tmp14_outputWritten) __out.AppendLine(true);
            if (__tmp14_outputWritten)
            {
                __out.AppendLine(false); //1112:134
            }
            __out.Write("		: base(id, model)"); //1113:1
            __out.AppendLine(false); //1113:20
            __out.Write("	{"); //1114:1
            __out.AppendLine(false); //1114:3
            __out.Write("	}"); //1115:1
            __out.AppendLine(false); //1115:3
            __out.AppendLine(true); //1116:2
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "	public override "; //1117:1
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
            string __tmp26_line = ".IMetaModel MMetaModel"; //1117:37
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Write(__tmp26_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //1117:59
            }
            __out.Write("	{"); //1118:1
            __out.AppendLine(false); //1118:3
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "		get { return "; //1119:1
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Write(__tmp29_line);
                __tmp28_outputWritten = true;
            }
            var __tmp30 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp30.Write(CSharpName(cls.MetaModel, ModelKind.ImmutableInstance, true));
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
            string __tmp31_line = ".MMetaModel; }"; //1119:77
            if (!string.IsNullOrEmpty(__tmp31_line))
            {
                __out.Write(__tmp31_line);
                __tmp28_outputWritten = true;
            }
            if (__tmp28_outputWritten) __out.AppendLine(true);
            if (__tmp28_outputWritten)
            {
                __out.AppendLine(false); //1119:91
            }
            __out.Write("	}"); //1120:1
            __out.AppendLine(false); //1120:3
            __out.AppendLine(true); //1121:2
            bool __tmp33_outputWritten = false;
            string __tmp34_line = "	public override "; //1122:1
            if (!string.IsNullOrEmpty(__tmp34_line))
            {
                __out.Write(__tmp34_line);
                __tmp33_outputWritten = true;
            }
            var __tmp35 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp35.Write(metaNs);
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
            string __tmp36_line = "MetaClass MMetaClass"; //1122:26
            if (!string.IsNullOrEmpty(__tmp36_line))
            {
                __out.Write(__tmp36_line);
                __tmp33_outputWritten = true;
            }
            if (__tmp33_outputWritten) __out.AppendLine(true);
            if (__tmp33_outputWritten)
            {
                __out.AppendLine(false); //1122:46
            }
            __out.Write("	{"); //1123:1
            __out.AppendLine(false); //1123:3
            bool __tmp38_outputWritten = false;
            string __tmp39_line = "		get { return "; //1124:1
            if (!string.IsNullOrEmpty(__tmp39_line))
            {
                __out.Write(__tmp39_line);
                __tmp38_outputWritten = true;
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
                    __tmp38_outputWritten = true;
                }
                if (!__tmp40_last) __out.AppendLine(true);
            }
            string __tmp41_line = "; }"; //1124:74
            if (!string.IsNullOrEmpty(__tmp41_line))
            {
                __out.Write(__tmp41_line);
                __tmp38_outputWritten = true;
            }
            if (__tmp38_outputWritten) __out.AppendLine(true);
            if (__tmp38_outputWritten)
            {
                __out.AppendLine(false); //1124:77
            }
            __out.Write("	}"); //1125:1
            __out.AppendLine(false); //1125:3
            __out.AppendLine(true); //1126:2
            bool __tmp43_outputWritten = false;
            string __tmp44_line = "	public new "; //1127:1
            if (!string.IsNullOrEmpty(__tmp44_line))
            {
                __out.Write(__tmp44_line);
                __tmp43_outputWritten = true;
            }
            var __tmp45 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp45.Write(CSharpName(cls, model, ClassKind.Builder));
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
            string __tmp46_line = " ToMutable()"; //1127:55
            if (!string.IsNullOrEmpty(__tmp46_line))
            {
                __out.Write(__tmp46_line);
                __tmp43_outputWritten = true;
            }
            if (__tmp43_outputWritten) __out.AppendLine(true);
            if (__tmp43_outputWritten)
            {
                __out.AppendLine(false); //1127:67
            }
            __out.Write("	{"); //1128:1
            __out.AppendLine(false); //1128:3
            bool __tmp48_outputWritten = false;
            string __tmp49_line = "		return ("; //1129:1
            if (!string.IsNullOrEmpty(__tmp49_line))
            {
                __out.Write(__tmp49_line);
                __tmp48_outputWritten = true;
            }
            var __tmp50 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp50.Write(CSharpName(cls, model, ClassKind.Builder));
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
            string __tmp51_line = ")base.ToMutable();"; //1129:53
            if (!string.IsNullOrEmpty(__tmp51_line))
            {
                __out.Write(__tmp51_line);
                __tmp48_outputWritten = true;
            }
            if (__tmp48_outputWritten) __out.AppendLine(true);
            if (__tmp48_outputWritten)
            {
                __out.AppendLine(false); //1129:71
            }
            __out.Write("	}"); //1130:1
            __out.AppendLine(false); //1130:3
            __out.AppendLine(true); //1131:2
            bool __tmp53_outputWritten = false;
            string __tmp54_line = "	public new "; //1132:1
            if (!string.IsNullOrEmpty(__tmp54_line))
            {
                __out.Write(__tmp54_line);
                __tmp53_outputWritten = true;
            }
            var __tmp55 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp55.Write(CSharpName(cls, model, ClassKind.Builder));
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
            string __tmp56_line = " ToMutable("; //1132:55
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
            string __tmp58_line = ".MutableModel model)"; //1132:85
            if (!string.IsNullOrEmpty(__tmp58_line))
            {
                __out.Write(__tmp58_line);
                __tmp53_outputWritten = true;
            }
            if (__tmp53_outputWritten) __out.AppendLine(true);
            if (__tmp53_outputWritten)
            {
                __out.AppendLine(false); //1132:105
            }
            __out.Write("	{"); //1133:1
            __out.AppendLine(false); //1133:3
            bool __tmp60_outputWritten = false;
            string __tmp61_line = "		return ("; //1134:1
            if (!string.IsNullOrEmpty(__tmp61_line))
            {
                __out.Write(__tmp61_line);
                __tmp60_outputWritten = true;
            }
            var __tmp62 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp62.Write(CSharpName(cls, model, ClassKind.Builder));
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
            string __tmp63_line = ")base.ToMutable(model);"; //1134:53
            if (!string.IsNullOrEmpty(__tmp63_line))
            {
                __out.Write(__tmp63_line);
                __tmp60_outputWritten = true;
            }
            if (__tmp60_outputWritten) __out.AppendLine(true);
            if (__tmp60_outputWritten)
            {
                __out.AppendLine(false); //1134:76
            }
            __out.Write("	}"); //1135:1
            __out.AppendLine(false); //1135:3
            var __loop69_results = 
                (from __loop69_var1 in __Enumerate((cls).GetEnumerator()) //1136:8
                from sup in __Enumerate((__loop69_var1.GetAllSuperClasses(false)).GetEnumerator()) //1136:13
                select new { __loop69_var1 = __loop69_var1, sup = sup}
                ).ToList(); //1136:3
            for (int __loop69_iteration = 0; __loop69_iteration < __loop69_results.Count; ++__loop69_iteration)
            {
                var __tmp64 = __loop69_results[__loop69_iteration];
                var __loop69_var1 = __tmp64.__loop69_var1;
                var sup = __tmp64.sup;
                __out.AppendLine(true); //1137:2
                bool __tmp66_outputWritten = false;
                string __tmp65Prefix = "	"; //1138:1
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
                string __tmp68_line = " "; //1138:50
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
                string __tmp70_line = ".ToMutable()"; //1138:101
                if (!string.IsNullOrEmpty(__tmp70_line))
                {
                    __out.Write(__tmp70_line);
                    __tmp66_outputWritten = true;
                }
                if (__tmp66_outputWritten) __out.AppendLine(true);
                if (__tmp66_outputWritten)
                {
                    __out.AppendLine(false); //1138:113
                }
                __out.Write("	{"); //1139:1
                __out.AppendLine(false); //1139:3
                __out.Write("		return this.ToMutable();"); //1140:1
                __out.AppendLine(false); //1140:27
                __out.Write("	}"); //1141:1
                __out.AppendLine(false); //1141:3
                __out.AppendLine(true); //1142:2
                bool __tmp72_outputWritten = false;
                string __tmp71Prefix = "	"; //1143:1
                var __tmp73 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp73.Write(CSharpName(sup, model, ClassKind.Builder, true));
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
                string __tmp74_line = " "; //1143:50
                if (!string.IsNullOrEmpty(__tmp74_line))
                {
                    __out.Write(__tmp74_line);
                    __tmp72_outputWritten = true;
                }
                var __tmp75 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp75.Write(CSharpName(sup, model, ClassKind.Immutable, true));
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
                string __tmp76_line = ".ToMutable("; //1143:101
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
                string __tmp78_line = ".MutableModel model)"; //1143:131
                if (!string.IsNullOrEmpty(__tmp78_line))
                {
                    __out.Write(__tmp78_line);
                    __tmp72_outputWritten = true;
                }
                if (__tmp72_outputWritten) __out.AppendLine(true);
                if (__tmp72_outputWritten)
                {
                    __out.AppendLine(false); //1143:151
                }
                __out.Write("	{"); //1144:1
                __out.AppendLine(false); //1144:3
                __out.Write("		return this.ToMutable(model);"); //1145:1
                __out.AppendLine(false); //1145:32
                __out.Write("	}"); //1146:1
                __out.AppendLine(false); //1146:3
            }
            var __loop70_results = 
                (from __loop70_var1 in __Enumerate((cls).GetEnumerator()) //1148:8
                from prop in __Enumerate((__loop70_var1.GetAllProperties()).GetEnumerator()) //1148:13
                select new { __loop70_var1 = __loop70_var1, prop = prop}
                ).ToList(); //1148:3
            for (int __loop70_iteration = 0; __loop70_iteration < __loop70_results.Count; ++__loop70_iteration)
            {
                var __tmp79 = __loop70_results[__loop70_iteration];
                var __loop70_var1 = __tmp79.__loop70_var1;
                var prop = __tmp79.prop;
                __out.AppendLine(true); //1149:2
                bool __tmp81_outputWritten = false;
                string __tmp80Prefix = "	"; //1150:1
                var __tmp82 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp82.Write(GenerateImmutablePropertyImpl(model, cls, prop));
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
                    __out.AppendLine(false); //1150:51
                }
            }
            var __loop71_results = 
                (from __loop71_var1 in __Enumerate((cls).GetEnumerator()) //1152:8
                from op in __Enumerate((__loop71_var1.GetAllOperations()).GetEnumerator()) //1152:13
                where !op.IsBuilder //1152:35
                select new { __loop71_var1 = __loop71_var1, op = op}
                ).ToList(); //1152:3
            for (int __loop71_iteration = 0; __loop71_iteration < __loop71_results.Count; ++__loop71_iteration)
            {
                var __tmp83 = __loop71_results[__loop71_iteration];
                var __loop71_var1 = __tmp83.__loop71_var1;
                var op = __tmp83.op;
                __out.AppendLine(true); //1153:2
                bool __tmp85_outputWritten = false;
                string __tmp84Prefix = "	"; //1154:1
                var __tmp86 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp86.Write(GenerateImmutableOperationImpl(model, cls, op));
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
                    __out.AppendLine(false); //1154:50
                }
            }
            if (metaMetaModel && cls.Name == "MetaModel") //1157:3
            {
                bool __tmp88_outputWritten = false;
                string __tmp87Prefix = "	"; //1158:1
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
                string __tmp90_line = ".ModelId "; //1158:21
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
                string __tmp92_line = ".IModel.Id => "; //1158:49
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
                string __tmp94_line = ".MModel.Id;"; //1158:110
                if (!string.IsNullOrEmpty(__tmp94_line))
                {
                    __out.Write(__tmp94_line);
                    __tmp88_outputWritten = true;
                }
                if (__tmp88_outputWritten) __out.AppendLine(true);
                if (__tmp88_outputWritten)
                {
                    __out.AppendLine(false); //1158:121
                }
                bool __tmp96_outputWritten = false;
                string __tmp97_line = "	string "; //1159:1
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
                string __tmp99_line = ".IModel.Name => this.Name;"; //1159:28
                if (!string.IsNullOrEmpty(__tmp99_line))
                {
                    __out.Write(__tmp99_line);
                    __tmp96_outputWritten = true;
                }
                if (__tmp96_outputWritten) __out.AppendLine(true);
                if (__tmp96_outputWritten)
                {
                    __out.AppendLine(false); //1159:54
                }
                bool __tmp101_outputWritten = false;
                string __tmp100Prefix = "	"; //1160:1
                var __tmp102 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp102.Write(Properties.CoreNs);
                var __tmp102Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp102.ToStringAndFree());
                bool __tmp102_last = __tmp102Reader.EndOfStream;
                while(!__tmp102_last)
                {
                    ReadOnlySpan<char> __tmp102_line = __tmp102Reader.ReadLine();
                    __tmp102_last = __tmp102Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp100Prefix))
                    {
                        __out.Write(__tmp100Prefix);
                        __tmp101_outputWritten = true;
                    }
                    if (!__tmp102_last || !__tmp102_line.IsEmpty)
                    {
                        __out.Write(__tmp102_line);
                        __tmp101_outputWritten = true;
                    }
                    if (!__tmp102_last) __out.AppendLine(true);
                }
                string __tmp103_line = ".ModelVersion "; //1160:21
                if (!string.IsNullOrEmpty(__tmp103_line))
                {
                    __out.Write(__tmp103_line);
                    __tmp101_outputWritten = true;
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
                        __tmp101_outputWritten = true;
                    }
                    if (!__tmp104_last) __out.AppendLine(true);
                }
                string __tmp105_line = ".IModel.Version => "; //1160:54
                if (!string.IsNullOrEmpty(__tmp105_line))
                {
                    __out.Write(__tmp105_line);
                    __tmp101_outputWritten = true;
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
                        __tmp101_outputWritten = true;
                    }
                    if (!__tmp106_last) __out.AppendLine(true);
                }
                string __tmp107_line = ".MModel.Version;"; //1160:120
                if (!string.IsNullOrEmpty(__tmp107_line))
                {
                    __out.Write(__tmp107_line);
                    __tmp101_outputWritten = true;
                }
                if (__tmp101_outputWritten) __out.AppendLine(true);
                if (__tmp101_outputWritten)
                {
                    __out.AppendLine(false); //1160:136
                }
                bool __tmp109_outputWritten = false;
                string __tmp110_line = "	global::System.Collections.Generic.IEnumerable<global::MetaDslx.Modeling.IModelObject> "; //1161:1
                if (!string.IsNullOrEmpty(__tmp110_line))
                {
                    __out.Write(__tmp110_line);
                    __tmp109_outputWritten = true;
                }
                var __tmp111 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp111.Write(Properties.CoreNs);
                var __tmp111Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp111.ToStringAndFree());
                bool __tmp111_last = __tmp111Reader.EndOfStream;
                while(!__tmp111_last)
                {
                    ReadOnlySpan<char> __tmp111_line = __tmp111Reader.ReadLine();
                    __tmp111_last = __tmp111Reader.EndOfStream;
                    if (!__tmp111_last || !__tmp111_line.IsEmpty)
                    {
                        __out.Write(__tmp111_line);
                        __tmp109_outputWritten = true;
                    }
                    if (!__tmp111_last) __out.AppendLine(true);
                }
                string __tmp112_line = ".IModel.Objects => "; //1161:108
                if (!string.IsNullOrEmpty(__tmp112_line))
                {
                    __out.Write(__tmp112_line);
                    __tmp109_outputWritten = true;
                }
                var __tmp113 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp113.Write(CSharpName(model, ModelKind.ImmutableInstance));
                var __tmp113Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp113.ToStringAndFree());
                bool __tmp113_last = __tmp113Reader.EndOfStream;
                while(!__tmp113_last)
                {
                    ReadOnlySpan<char> __tmp113_line = __tmp113Reader.ReadLine();
                    __tmp113_last = __tmp113Reader.EndOfStream;
                    if (!__tmp113_last || !__tmp113_line.IsEmpty)
                    {
                        __out.Write(__tmp113_line);
                        __tmp109_outputWritten = true;
                    }
                    if (!__tmp113_last) __out.AppendLine(true);
                }
                string __tmp114_line = ".MModel.Objects;"; //1161:174
                if (!string.IsNullOrEmpty(__tmp114_line))
                {
                    __out.Write(__tmp114_line);
                    __tmp109_outputWritten = true;
                }
                if (__tmp109_outputWritten) __out.AppendLine(true);
                if (__tmp109_outputWritten)
                {
                    __out.AppendLine(false); //1161:190
                }
                bool __tmp116_outputWritten = false;
                string __tmp117_line = "	string "; //1162:1
                if (!string.IsNullOrEmpty(__tmp117_line))
                {
                    __out.Write(__tmp117_line);
                    __tmp116_outputWritten = true;
                }
                var __tmp118 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp118.Write(Properties.CoreNs);
                var __tmp118Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp118.ToStringAndFree());
                bool __tmp118_last = __tmp118Reader.EndOfStream;
                while(!__tmp118_last)
                {
                    ReadOnlySpan<char> __tmp118_line = __tmp118Reader.ReadLine();
                    __tmp118_last = __tmp118Reader.EndOfStream;
                    if (!__tmp118_last || !__tmp118_line.IsEmpty)
                    {
                        __out.Write(__tmp118_line);
                        __tmp116_outputWritten = true;
                    }
                    if (!__tmp118_last) __out.AppendLine(true);
                }
                string __tmp119_line = ".IMetaModel.Uri => this.Uri;"; //1162:28
                if (!string.IsNullOrEmpty(__tmp119_line))
                {
                    __out.Write(__tmp119_line);
                    __tmp116_outputWritten = true;
                }
                if (__tmp116_outputWritten) __out.AppendLine(true);
                if (__tmp116_outputWritten)
                {
                    __out.AppendLine(false); //1162:56
                }
                bool __tmp121_outputWritten = false;
                string __tmp122_line = "	string "; //1163:1
                if (!string.IsNullOrEmpty(__tmp122_line))
                {
                    __out.Write(__tmp122_line);
                    __tmp121_outputWritten = true;
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
                        __tmp121_outputWritten = true;
                    }
                    if (!__tmp123_last) __out.AppendLine(true);
                }
                string __tmp124_line = ".IMetaModel.Prefix => this.Prefix;"; //1163:28
                if (!string.IsNullOrEmpty(__tmp124_line))
                {
                    __out.Write(__tmp124_line);
                    __tmp121_outputWritten = true;
                }
                if (__tmp121_outputWritten) __out.AppendLine(true);
                if (__tmp121_outputWritten)
                {
                    __out.AppendLine(false); //1163:62
                }
                bool __tmp126_outputWritten = false;
                string __tmp125Prefix = "	"; //1164:1
                var __tmp127 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp127.Write(Properties.CoreNs);
                var __tmp127Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp127.ToStringAndFree());
                bool __tmp127_last = __tmp127Reader.EndOfStream;
                while(!__tmp127_last)
                {
                    ReadOnlySpan<char> __tmp127_line = __tmp127Reader.ReadLine();
                    __tmp127_last = __tmp127Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp125Prefix))
                    {
                        __out.Write(__tmp125Prefix);
                        __tmp126_outputWritten = true;
                    }
                    if (!__tmp127_last || !__tmp127_line.IsEmpty)
                    {
                        __out.Write(__tmp127_line);
                        __tmp126_outputWritten = true;
                    }
                    if (!__tmp127_last) __out.AppendLine(true);
                }
                string __tmp128_line = ".IModelGroup "; //1164:21
                if (!string.IsNullOrEmpty(__tmp128_line))
                {
                    __out.Write(__tmp128_line);
                    __tmp126_outputWritten = true;
                }
                var __tmp129 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp129.Write(Properties.CoreNs);
                var __tmp129Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp129.ToStringAndFree());
                bool __tmp129_last = __tmp129Reader.EndOfStream;
                while(!__tmp129_last)
                {
                    ReadOnlySpan<char> __tmp129_line = __tmp129Reader.ReadLine();
                    __tmp129_last = __tmp129Reader.EndOfStream;
                    if (!__tmp129_last || !__tmp129_line.IsEmpty)
                    {
                        __out.Write(__tmp129_line);
                        __tmp126_outputWritten = true;
                    }
                    if (!__tmp129_last) __out.AppendLine(true);
                }
                string __tmp130_line = ".IModel.ModelGroup => "; //1164:53
                if (!string.IsNullOrEmpty(__tmp130_line))
                {
                    __out.Write(__tmp130_line);
                    __tmp126_outputWritten = true;
                }
                var __tmp131 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp131.Write(CSharpName(model, ModelKind.ImmutableInstance));
                var __tmp131Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp131.ToStringAndFree());
                bool __tmp131_last = __tmp131Reader.EndOfStream;
                while(!__tmp131_last)
                {
                    ReadOnlySpan<char> __tmp131_line = __tmp131Reader.ReadLine();
                    __tmp131_last = __tmp131Reader.EndOfStream;
                    if (!__tmp131_last || !__tmp131_line.IsEmpty)
                    {
                        __out.Write(__tmp131_line);
                        __tmp126_outputWritten = true;
                    }
                    if (!__tmp131_last) __out.AppendLine(true);
                }
                string __tmp132_line = ".MModel.ModelGroup;"; //1164:122
                if (!string.IsNullOrEmpty(__tmp132_line))
                {
                    __out.Write(__tmp132_line);
                    __tmp126_outputWritten = true;
                }
                if (__tmp126_outputWritten) __out.AppendLine(true);
                if (__tmp126_outputWritten)
                {
                    __out.AppendLine(false); //1164:141
                }
                bool __tmp134_outputWritten = false;
                string __tmp135_line = "	string "; //1165:1
                if (!string.IsNullOrEmpty(__tmp135_line))
                {
                    __out.Write(__tmp135_line);
                    __tmp134_outputWritten = true;
                }
                var __tmp136 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp136.Write(Properties.CoreNs);
                var __tmp136Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp136.ToStringAndFree());
                bool __tmp136_last = __tmp136Reader.EndOfStream;
                while(!__tmp136_last)
                {
                    ReadOnlySpan<char> __tmp136_line = __tmp136Reader.ReadLine();
                    __tmp136_last = __tmp136Reader.EndOfStream;
                    if (!__tmp136_last || !__tmp136_line.IsEmpty)
                    {
                        __out.Write(__tmp136_line);
                        __tmp134_outputWritten = true;
                    }
                    if (!__tmp136_last) __out.AppendLine(true);
                }
                string __tmp137_line = ".IMetaModel.Namespace => this.Namespace.FullName;"; //1165:28
                if (!string.IsNullOrEmpty(__tmp137_line))
                {
                    __out.Write(__tmp137_line);
                    __tmp134_outputWritten = true;
                }
                if (__tmp134_outputWritten) __out.AppendLine(true);
                if (__tmp134_outputWritten)
                {
                    __out.AppendLine(false); //1165:77
                }
                __out.AppendLine(true); //1166:1
                bool __tmp139_outputWritten = false;
                string __tmp140_line = "	public "; //1167:1
                if (!string.IsNullOrEmpty(__tmp140_line))
                {
                    __out.Write(__tmp140_line);
                    __tmp139_outputWritten = true;
                }
                var __tmp141 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp141.Write(Properties.CoreNs);
                var __tmp141Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp141.ToStringAndFree());
                bool __tmp141_last = __tmp141Reader.EndOfStream;
                while(!__tmp141_last)
                {
                    ReadOnlySpan<char> __tmp141_line = __tmp141Reader.ReadLine();
                    __tmp141_last = __tmp141Reader.EndOfStream;
                    if (!__tmp141_last || !__tmp141_line.IsEmpty)
                    {
                        __out.Write(__tmp141_line);
                        __tmp139_outputWritten = true;
                    }
                    if (!__tmp141_last) __out.AppendLine(true);
                }
                string __tmp142_line = ".IModelFactory CreateFactory("; //1167:28
                if (!string.IsNullOrEmpty(__tmp142_line))
                {
                    __out.Write(__tmp142_line);
                    __tmp139_outputWritten = true;
                }
                var __tmp143 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp143.Write(Properties.CoreNs);
                var __tmp143Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp143.ToStringAndFree());
                bool __tmp143_last = __tmp143Reader.EndOfStream;
                while(!__tmp143_last)
                {
                    ReadOnlySpan<char> __tmp143_line = __tmp143Reader.ReadLine();
                    __tmp143_last = __tmp143Reader.EndOfStream;
                    if (!__tmp143_last || !__tmp143_line.IsEmpty)
                    {
                        __out.Write(__tmp143_line);
                        __tmp139_outputWritten = true;
                    }
                    if (!__tmp143_last) __out.AppendLine(true);
                }
                string __tmp144_line = ".MutableModel model, "; //1167:76
                if (!string.IsNullOrEmpty(__tmp144_line))
                {
                    __out.Write(__tmp144_line);
                    __tmp139_outputWritten = true;
                }
                var __tmp145 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp145.Write(Properties.CoreNs);
                var __tmp145Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp145.ToStringAndFree());
                bool __tmp145_last = __tmp145Reader.EndOfStream;
                while(!__tmp145_last)
                {
                    ReadOnlySpan<char> __tmp145_line = __tmp145Reader.ReadLine();
                    __tmp145_last = __tmp145Reader.EndOfStream;
                    if (!__tmp145_last || !__tmp145_line.IsEmpty)
                    {
                        __out.Write(__tmp145_line);
                        __tmp139_outputWritten = true;
                    }
                    if (!__tmp145_last) __out.AppendLine(true);
                }
                string __tmp146_line = ".ModelFactoryFlags flags = "; //1167:116
                if (!string.IsNullOrEmpty(__tmp146_line))
                {
                    __out.Write(__tmp146_line);
                    __tmp139_outputWritten = true;
                }
                var __tmp147 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp147.Write(Properties.CoreNs);
                var __tmp147Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp147.ToStringAndFree());
                bool __tmp147_last = __tmp147Reader.EndOfStream;
                while(!__tmp147_last)
                {
                    ReadOnlySpan<char> __tmp147_line = __tmp147Reader.ReadLine();
                    __tmp147_last = __tmp147Reader.EndOfStream;
                    if (!__tmp147_last || !__tmp147_line.IsEmpty)
                    {
                        __out.Write(__tmp147_line);
                        __tmp139_outputWritten = true;
                    }
                    if (!__tmp147_last) __out.AppendLine(true);
                }
                string __tmp148_line = ".ModelFactoryFlags.None)"; //1167:162
                if (!string.IsNullOrEmpty(__tmp148_line))
                {
                    __out.Write(__tmp148_line);
                    __tmp139_outputWritten = true;
                }
                if (__tmp139_outputWritten) __out.AppendLine(true);
                if (__tmp139_outputWritten)
                {
                    __out.AppendLine(false); //1167:186
                }
                __out.Write("	{"); //1168:1
                __out.AppendLine(false); //1168:3
                bool __tmp150_outputWritten = false;
                string __tmp151_line = "		return new "; //1169:1
                if (!string.IsNullOrEmpty(__tmp151_line))
                {
                    __out.Write(__tmp151_line);
                    __tmp150_outputWritten = true;
                }
                var __tmp152 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp152.Write(CSharpName(model, ModelKind.Factory));
                var __tmp152Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp152.ToStringAndFree());
                bool __tmp152_last = __tmp152Reader.EndOfStream;
                while(!__tmp152_last)
                {
                    ReadOnlySpan<char> __tmp152_line = __tmp152Reader.ReadLine();
                    __tmp152_last = __tmp152Reader.EndOfStream;
                    if (!__tmp152_last || !__tmp152_line.IsEmpty)
                    {
                        __out.Write(__tmp152_line);
                        __tmp150_outputWritten = true;
                    }
                    if (!__tmp152_last) __out.AppendLine(true);
                }
                string __tmp153_line = "(model, flags);"; //1169:51
                if (!string.IsNullOrEmpty(__tmp153_line))
                {
                    __out.Write(__tmp153_line);
                    __tmp150_outputWritten = true;
                }
                if (__tmp150_outputWritten) __out.AppendLine(true);
                if (__tmp150_outputWritten)
                {
                    __out.AppendLine(false); //1169:66
                }
                __out.Write("	}"); //1170:1
                __out.AppendLine(false); //1170:3
            }
            __out.Write("}"); //1172:1
            __out.AppendLine(false); //1172:2
            return __out.ToStringAndFree();
        }

        public string GenerateImmutableField(MetaModel model, MetaClass cls, MetaProperty prop) //1175:1
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
                __out.AppendLine(false); //1176:54
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "private "; //1177:1
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
            string __tmp8_line = " "; //1177:65
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
            string __tmp10_line = ";"; //1177:90
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Write(__tmp10_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //1177:91
            }
            return __out.ToStringAndFree();
        }

        public string GenerateImmutablePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //1180:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.AppendLine(true); //1181:1
            if (cls.GetAllFinalProperties().Contains(prop)) //1182:2
            {
                bool __tmp2_outputWritten = false;
                string __tmp3_line = "public "; //1183:1
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
                string __tmp5_line = " "; //1183:64
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
                    __out.AppendLine(false); //1183:76
                }
            }
            else //1184:2
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
                    __out.AppendLine(false); //1185:54
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
                string __tmp13_line = " "; //1186:57
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
                string __tmp15_line = "."; //1186:115
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
                    __out.AppendLine(false); //1186:127
                }
            }
            __out.Write("{"); //1188:1
            __out.AppendLine(false); //1188:2
            if (prop.Type is MetaCollectionType) //1189:6
            {
                if (((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.Set || ((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiSet) //1190:4
                {
                    bool __tmp18_outputWritten = false;
                    string __tmp19_line = "    get { return this.GetSet<"; //1191:1
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
                    string __tmp21_line = ">("; //1191:118
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
                    string __tmp23_line = ", ref "; //1191:174
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
                    string __tmp25_line = "); }"; //1191:204
                    if (!string.IsNullOrEmpty(__tmp25_line))
                    {
                        __out.Write(__tmp25_line);
                        __tmp18_outputWritten = true;
                    }
                    if (__tmp18_outputWritten) __out.AppendLine(true);
                    if (__tmp18_outputWritten)
                    {
                        __out.AppendLine(false); //1191:208
                    }
                }
                else //1192:4
                {
                    bool __tmp27_outputWritten = false;
                    string __tmp28_line = "    get { return this.GetList<"; //1193:1
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
                    string __tmp30_line = ">("; //1193:119
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
                    string __tmp32_line = ", ref "; //1193:175
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
                    string __tmp34_line = "); }"; //1193:205
                    if (!string.IsNullOrEmpty(__tmp34_line))
                    {
                        __out.Write(__tmp34_line);
                        __tmp27_outputWritten = true;
                    }
                    if (__tmp27_outputWritten) __out.AppendLine(true);
                    if (__tmp27_outputWritten)
                    {
                        __out.AppendLine(false); //1193:209
                    }
                }
            }
            else if (IsReferenceType(prop.Type)) //1195:3
            {
                bool __tmp36_outputWritten = false;
                string __tmp37_line = "    get { return this.GetReference<"; //1196:1
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
                string __tmp39_line = ">("; //1196:92
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
                string __tmp41_line = ", ref "; //1196:148
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
                string __tmp43_line = "); }"; //1196:178
                if (!string.IsNullOrEmpty(__tmp43_line))
                {
                    __out.Write(__tmp43_line);
                    __tmp36_outputWritten = true;
                }
                if (__tmp36_outputWritten) __out.AppendLine(true);
                if (__tmp36_outputWritten)
                {
                    __out.AppendLine(false); //1196:182
                }
            }
            else //1197:3
            {
                bool __tmp45_outputWritten = false;
                string __tmp46_line = "    get { return this.GetValue<"; //1198:1
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
                string __tmp48_line = ">("; //1198:88
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
                string __tmp50_line = ", ref "; //1198:144
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
                string __tmp52_line = "); }"; //1198:174
                if (!string.IsNullOrEmpty(__tmp52_line))
                {
                    __out.Write(__tmp52_line);
                    __tmp45_outputWritten = true;
                }
                if (__tmp45_outputWritten) __out.AppendLine(true);
                if (__tmp45_outputWritten)
                {
                    __out.AppendLine(false); //1198:178
                }
            }
            __out.Write("}"); //1200:1
            __out.AppendLine(false); //1200:2
            return __out.ToStringAndFree();
        }

        public string GenerateImmutableOperationImpl(MetaModel model, MetaClass cls, MetaOperation op) //1203:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.AppendLine(true); //1204:1
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
            string __tmp4_line = " "; //1205:70
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
            string __tmp6_line = "."; //1205:126
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
            string __tmp8_line = "("; //1205:136
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
            string __tmp10_line = ")"; //1205:208
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Write(__tmp10_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //1205:209
            }
            __out.Write("{"); //1206:1
            __out.AppendLine(false); //1206:2
            var finalOp = GetFinalOperation(cls, op); //1207:2
            bool __tmp12_outputWritten = false;
            string __tmp11Prefix = "    "; //1208:1
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
            string __tmp15_line = ".Implementation."; //1208:136
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
            string __tmp17_line = "_"; //1208:206
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
            string __tmp19_line = "("; //1208:221
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
            string __tmp21_line = ");"; //1208:300
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp12_outputWritten = true;
            }
            if (__tmp12_outputWritten) __out.AppendLine(true);
            if (__tmp12_outputWritten)
            {
                __out.AppendLine(false); //1208:302
            }
            __out.Write("}"); //1209:1
            __out.AppendLine(false); //1209:2
            return __out.ToStringAndFree();
        }

        public string GenerateBuilderImplClass(MetaModel model, MetaClass cls) //1212:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool metaMetaModel = IsMetaMetaModel(model); //1213:2
            string metaNs = metaMetaModel ? "" : Properties.MetaNs + "."; //1214:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //1215:1
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
            string __tmp5_line = " : "; //1215:62
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
            string __tmp7_line = ".MutableObjectBase, "; //1215:84
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
                __out.AppendLine(false); //1215:146
            }
            __out.Write("{"); //1216:1
            __out.AppendLine(false); //1216:2
            var __loop72_results = 
                (from __loop72_var1 in __Enumerate((cls).GetEnumerator()) //1217:8
                from prop in __Enumerate((__loop72_var1.GetAllProperties()).GetEnumerator()) //1217:13
                where prop.Type is MetaCollectionType //1217:37
                select new { __loop72_var1 = __loop72_var1, prop = prop}
                ).ToList(); //1217:3
            for (int __loop72_iteration = 0; __loop72_iteration < __loop72_results.Count; ++__loop72_iteration)
            {
                var __tmp9 = __loop72_results[__loop72_iteration];
                var __loop72_var1 = __tmp9.__loop72_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //1218:1
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
                    __out.AppendLine(false); //1218:42
                }
            }
            __out.AppendLine(true); //1220:2
            bool __tmp14_outputWritten = false;
            string __tmp15_line = "	internal "; //1221:1
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
            string __tmp17_line = "("; //1221:57
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
            string __tmp19_line = ".ObjectId id, "; //1221:77
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
            string __tmp21_line = ".MutableModel model, bool creating)"; //1221:110
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp14_outputWritten = true;
            }
            if (__tmp14_outputWritten) __out.AppendLine(true);
            if (__tmp14_outputWritten)
            {
                __out.AppendLine(false); //1221:145
            }
            __out.Write("		: base(id, model, creating)"); //1222:1
            __out.AppendLine(false); //1222:30
            __out.Write("	{"); //1223:1
            __out.AppendLine(false); //1223:3
            __out.Write("	}"); //1224:1
            __out.AppendLine(false); //1224:3
            __out.AppendLine(true); //1225:2
            __out.Write("	protected override void MInit()"); //1226:1
            __out.AppendLine(false); //1226:33
            __out.Write("	{"); //1227:1
            __out.AppendLine(false); //1227:3
            bool __tmp23_outputWritten = false;
            string __tmp22Prefix = "		"; //1228:1
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
            string __tmp25_line = ".Implementation."; //1228:55
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
            string __tmp27_line = "(this);"; //1228:115
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Write(__tmp27_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //1228:122
            }
            __out.Write("	}"); //1229:1
            __out.AppendLine(false); //1229:3
            __out.AppendLine(true); //1230:2
            bool __tmp29_outputWritten = false;
            string __tmp30_line = "	public override "; //1231:1
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
            string __tmp32_line = ".IMetaModel MMetaModel"; //1231:37
            if (!string.IsNullOrEmpty(__tmp32_line))
            {
                __out.Write(__tmp32_line);
                __tmp29_outputWritten = true;
            }
            if (__tmp29_outputWritten) __out.AppendLine(true);
            if (__tmp29_outputWritten)
            {
                __out.AppendLine(false); //1231:59
            }
            __out.Write("	{"); //1232:1
            __out.AppendLine(false); //1232:3
            bool __tmp34_outputWritten = false;
            string __tmp35_line = "		get { return "; //1233:1
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Write(__tmp35_line);
                __tmp34_outputWritten = true;
            }
            var __tmp36 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp36.Write(CSharpName(cls.MetaModel, ModelKind.ImmutableInstance, true));
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
            string __tmp37_line = ".MMetaModel; }"; //1233:77
            if (!string.IsNullOrEmpty(__tmp37_line))
            {
                __out.Write(__tmp37_line);
                __tmp34_outputWritten = true;
            }
            if (__tmp34_outputWritten) __out.AppendLine(true);
            if (__tmp34_outputWritten)
            {
                __out.AppendLine(false); //1233:91
            }
            __out.Write("	}"); //1234:1
            __out.AppendLine(false); //1234:3
            __out.AppendLine(true); //1235:2
            bool __tmp39_outputWritten = false;
            string __tmp40_line = "	public override "; //1236:1
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Write(__tmp40_line);
                __tmp39_outputWritten = true;
            }
            var __tmp41 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp41.Write(metaNs);
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
            string __tmp42_line = "MetaClass MMetaClass"; //1236:26
            if (!string.IsNullOrEmpty(__tmp42_line))
            {
                __out.Write(__tmp42_line);
                __tmp39_outputWritten = true;
            }
            if (__tmp39_outputWritten) __out.AppendLine(true);
            if (__tmp39_outputWritten)
            {
                __out.AppendLine(false); //1236:46
            }
            __out.Write("	{"); //1237:1
            __out.AppendLine(false); //1237:3
            bool __tmp44_outputWritten = false;
            string __tmp45_line = "		get { return "; //1238:1
            if (!string.IsNullOrEmpty(__tmp45_line))
            {
                __out.Write(__tmp45_line);
                __tmp44_outputWritten = true;
            }
            var __tmp46 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp46.Write(CSharpName(cls, model, ClassKind.ImmutableInstance, true));
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
            string __tmp47_line = "; }"; //1238:74
            if (!string.IsNullOrEmpty(__tmp47_line))
            {
                __out.Write(__tmp47_line);
                __tmp44_outputWritten = true;
            }
            if (__tmp44_outputWritten) __out.AppendLine(true);
            if (__tmp44_outputWritten)
            {
                __out.AppendLine(false); //1238:77
            }
            __out.Write("	}"); //1239:1
            __out.AppendLine(false); //1239:3
            __out.AppendLine(true); //1240:2
            bool __tmp49_outputWritten = false;
            string __tmp50_line = "	public new "; //1241:1
            if (!string.IsNullOrEmpty(__tmp50_line))
            {
                __out.Write(__tmp50_line);
                __tmp49_outputWritten = true;
            }
            var __tmp51 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp51.Write(CSharpName(cls, model, ClassKind.Immutable));
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
            string __tmp52_line = " ToImmutable()"; //1241:57
            if (!string.IsNullOrEmpty(__tmp52_line))
            {
                __out.Write(__tmp52_line);
                __tmp49_outputWritten = true;
            }
            if (__tmp49_outputWritten) __out.AppendLine(true);
            if (__tmp49_outputWritten)
            {
                __out.AppendLine(false); //1241:71
            }
            __out.Write("	{"); //1242:1
            __out.AppendLine(false); //1242:3
            bool __tmp54_outputWritten = false;
            string __tmp55_line = "		return ("; //1243:1
            if (!string.IsNullOrEmpty(__tmp55_line))
            {
                __out.Write(__tmp55_line);
                __tmp54_outputWritten = true;
            }
            var __tmp56 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp56.Write(CSharpName(cls, model, ClassKind.Immutable));
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
            string __tmp57_line = ")base.ToImmutable();"; //1243:55
            if (!string.IsNullOrEmpty(__tmp57_line))
            {
                __out.Write(__tmp57_line);
                __tmp54_outputWritten = true;
            }
            if (__tmp54_outputWritten) __out.AppendLine(true);
            if (__tmp54_outputWritten)
            {
                __out.AppendLine(false); //1243:75
            }
            __out.Write("	}"); //1244:1
            __out.AppendLine(false); //1244:3
            __out.AppendLine(true); //1245:2
            bool __tmp59_outputWritten = false;
            string __tmp60_line = "	public new "; //1246:1
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
            string __tmp62_line = " ToImmutable("; //1246:57
            if (!string.IsNullOrEmpty(__tmp62_line))
            {
                __out.Write(__tmp62_line);
                __tmp59_outputWritten = true;
            }
            var __tmp63 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp63.Write(Properties.CoreNs);
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
            string __tmp64_line = ".ImmutableModel model)"; //1246:89
            if (!string.IsNullOrEmpty(__tmp64_line))
            {
                __out.Write(__tmp64_line);
                __tmp59_outputWritten = true;
            }
            if (__tmp59_outputWritten) __out.AppendLine(true);
            if (__tmp59_outputWritten)
            {
                __out.AppendLine(false); //1246:111
            }
            __out.Write("	{"); //1247:1
            __out.AppendLine(false); //1247:3
            bool __tmp66_outputWritten = false;
            string __tmp67_line = "		return ("; //1248:1
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
            string __tmp69_line = ")base.ToImmutable(model);"; //1248:55
            if (!string.IsNullOrEmpty(__tmp69_line))
            {
                __out.Write(__tmp69_line);
                __tmp66_outputWritten = true;
            }
            if (__tmp66_outputWritten) __out.AppendLine(true);
            if (__tmp66_outputWritten)
            {
                __out.AppendLine(false); //1248:80
            }
            __out.Write("	}"); //1249:1
            __out.AppendLine(false); //1249:3
            var __loop73_results = 
                (from __loop73_var1 in __Enumerate((cls).GetEnumerator()) //1250:8
                from sup in __Enumerate((__loop73_var1.GetAllSuperClasses(false)).GetEnumerator()) //1250:13
                select new { __loop73_var1 = __loop73_var1, sup = sup}
                ).ToList(); //1250:3
            for (int __loop73_iteration = 0; __loop73_iteration < __loop73_results.Count; ++__loop73_iteration)
            {
                var __tmp70 = __loop73_results[__loop73_iteration];
                var __loop73_var1 = __tmp70.__loop73_var1;
                var sup = __tmp70.sup;
                __out.AppendLine(true); //1251:2
                bool __tmp72_outputWritten = false;
                string __tmp71Prefix = "	"; //1252:1
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
                string __tmp74_line = " "; //1252:52
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
                string __tmp76_line = ".ToImmutable()"; //1252:101
                if (!string.IsNullOrEmpty(__tmp76_line))
                {
                    __out.Write(__tmp76_line);
                    __tmp72_outputWritten = true;
                }
                if (__tmp72_outputWritten) __out.AppendLine(true);
                if (__tmp72_outputWritten)
                {
                    __out.AppendLine(false); //1252:115
                }
                __out.Write("	{"); //1253:1
                __out.AppendLine(false); //1253:3
                __out.Write("		return this.ToImmutable();"); //1254:1
                __out.AppendLine(false); //1254:29
                __out.Write("	}"); //1255:1
                __out.AppendLine(false); //1255:3
                __out.AppendLine(true); //1256:2
                bool __tmp78_outputWritten = false;
                string __tmp77Prefix = "	"; //1257:1
                var __tmp79 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp79.Write(CSharpName(sup, model, ClassKind.Immutable, true));
                var __tmp79Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp79.ToStringAndFree());
                bool __tmp79_last = __tmp79Reader.EndOfStream;
                while(!__tmp79_last)
                {
                    ReadOnlySpan<char> __tmp79_line = __tmp79Reader.ReadLine();
                    __tmp79_last = __tmp79Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp77Prefix))
                    {
                        __out.Write(__tmp77Prefix);
                        __tmp78_outputWritten = true;
                    }
                    if (!__tmp79_last || !__tmp79_line.IsEmpty)
                    {
                        __out.Write(__tmp79_line);
                        __tmp78_outputWritten = true;
                    }
                    if (!__tmp79_last) __out.AppendLine(true);
                }
                string __tmp80_line = " "; //1257:52
                if (!string.IsNullOrEmpty(__tmp80_line))
                {
                    __out.Write(__tmp80_line);
                    __tmp78_outputWritten = true;
                }
                var __tmp81 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp81.Write(CSharpName(sup, model, ClassKind.Builder, true));
                var __tmp81Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp81.ToStringAndFree());
                bool __tmp81_last = __tmp81Reader.EndOfStream;
                while(!__tmp81_last)
                {
                    ReadOnlySpan<char> __tmp81_line = __tmp81Reader.ReadLine();
                    __tmp81_last = __tmp81Reader.EndOfStream;
                    if (!__tmp81_last || !__tmp81_line.IsEmpty)
                    {
                        __out.Write(__tmp81_line);
                        __tmp78_outputWritten = true;
                    }
                    if (!__tmp81_last) __out.AppendLine(true);
                }
                string __tmp82_line = ".ToImmutable("; //1257:101
                if (!string.IsNullOrEmpty(__tmp82_line))
                {
                    __out.Write(__tmp82_line);
                    __tmp78_outputWritten = true;
                }
                var __tmp83 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp83.Write(Properties.CoreNs);
                var __tmp83Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp83.ToStringAndFree());
                bool __tmp83_last = __tmp83Reader.EndOfStream;
                while(!__tmp83_last)
                {
                    ReadOnlySpan<char> __tmp83_line = __tmp83Reader.ReadLine();
                    __tmp83_last = __tmp83Reader.EndOfStream;
                    if (!__tmp83_last || !__tmp83_line.IsEmpty)
                    {
                        __out.Write(__tmp83_line);
                        __tmp78_outputWritten = true;
                    }
                    if (!__tmp83_last) __out.AppendLine(true);
                }
                string __tmp84_line = ".ImmutableModel model)"; //1257:133
                if (!string.IsNullOrEmpty(__tmp84_line))
                {
                    __out.Write(__tmp84_line);
                    __tmp78_outputWritten = true;
                }
                if (__tmp78_outputWritten) __out.AppendLine(true);
                if (__tmp78_outputWritten)
                {
                    __out.AppendLine(false); //1257:155
                }
                __out.Write("	{"); //1258:1
                __out.AppendLine(false); //1258:3
                __out.Write("		return this.ToImmutable(model);"); //1259:1
                __out.AppendLine(false); //1259:34
                __out.Write("	}"); //1260:1
                __out.AppendLine(false); //1260:3
            }
            var __loop74_results = 
                (from __loop74_var1 in __Enumerate((cls).GetEnumerator()) //1262:8
                from prop in __Enumerate((__loop74_var1.GetAllProperties()).GetEnumerator()) //1262:13
                select new { __loop74_var1 = __loop74_var1, prop = prop}
                ).ToList(); //1262:3
            for (int __loop74_iteration = 0; __loop74_iteration < __loop74_results.Count; ++__loop74_iteration)
            {
                var __tmp85 = __loop74_results[__loop74_iteration];
                var __loop74_var1 = __tmp85.__loop74_var1;
                var prop = __tmp85.prop;
                __out.AppendLine(true); //1263:2
                bool __tmp87_outputWritten = false;
                string __tmp86Prefix = "	"; //1264:1
                var __tmp88 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp88.Write(GenerateBuilderPropertyImpl(model, cls, prop));
                var __tmp88Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp88.ToStringAndFree());
                bool __tmp88_last = __tmp88Reader.EndOfStream;
                while(!__tmp88_last)
                {
                    ReadOnlySpan<char> __tmp88_line = __tmp88Reader.ReadLine();
                    __tmp88_last = __tmp88Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp86Prefix))
                    {
                        __out.Write(__tmp86Prefix);
                        __tmp87_outputWritten = true;
                    }
                    if (!__tmp88_last || !__tmp88_line.IsEmpty)
                    {
                        __out.Write(__tmp88_line);
                        __tmp87_outputWritten = true;
                    }
                    if (!__tmp88_last || __tmp87_outputWritten) __out.AppendLine(true);
                }
                if (__tmp87_outputWritten)
                {
                    __out.AppendLine(false); //1264:49
                }
            }
            var __loop75_results = 
                (from __loop75_var1 in __Enumerate((cls).GetEnumerator()) //1266:8
                from op in __Enumerate((__loop75_var1.GetAllOperations()).GetEnumerator()) //1266:13
                select new { __loop75_var1 = __loop75_var1, op = op}
                ).ToList(); //1266:3
            for (int __loop75_iteration = 0; __loop75_iteration < __loop75_results.Count; ++__loop75_iteration)
            {
                var __tmp89 = __loop75_results[__loop75_iteration];
                var __loop75_var1 = __tmp89.__loop75_var1;
                var op = __tmp89.op;
                __out.AppendLine(true); //1267:2
                bool __tmp91_outputWritten = false;
                string __tmp90Prefix = "	"; //1268:1
                var __tmp92 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp92.Write(GenerateBuilderOperationImpl(model, cls, op));
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
                    if (!__tmp92_last || __tmp91_outputWritten) __out.AppendLine(true);
                }
                if (__tmp91_outputWritten)
                {
                    __out.AppendLine(false); //1268:48
                }
            }
            if (metaMetaModel && cls.Name == "MetaModel") //1270:3
            {
                __out.AppendLine(true); //1271:1
                bool __tmp94_outputWritten = false;
                string __tmp93Prefix = "	"; //1272:1
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
                string __tmp96_line = ".ModelId "; //1272:21
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
                string __tmp98_line = ".IModel.Id => "; //1272:49
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
                string __tmp100_line = ".MModel.Id;"; //1272:110
                if (!string.IsNullOrEmpty(__tmp100_line))
                {
                    __out.Write(__tmp100_line);
                    __tmp94_outputWritten = true;
                }
                if (__tmp94_outputWritten) __out.AppendLine(true);
                if (__tmp94_outputWritten)
                {
                    __out.AppendLine(false); //1272:121
                }
                bool __tmp102_outputWritten = false;
                string __tmp103_line = "	string "; //1273:1
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
                string __tmp105_line = ".IModel.Name => this.Name;"; //1273:28
                if (!string.IsNullOrEmpty(__tmp105_line))
                {
                    __out.Write(__tmp105_line);
                    __tmp102_outputWritten = true;
                }
                if (__tmp102_outputWritten) __out.AppendLine(true);
                if (__tmp102_outputWritten)
                {
                    __out.AppendLine(false); //1273:54
                }
                bool __tmp107_outputWritten = false;
                string __tmp106Prefix = "	"; //1274:1
                var __tmp108 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp108.Write(Properties.CoreNs);
                var __tmp108Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp108.ToStringAndFree());
                bool __tmp108_last = __tmp108Reader.EndOfStream;
                while(!__tmp108_last)
                {
                    ReadOnlySpan<char> __tmp108_line = __tmp108Reader.ReadLine();
                    __tmp108_last = __tmp108Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp106Prefix))
                    {
                        __out.Write(__tmp106Prefix);
                        __tmp107_outputWritten = true;
                    }
                    if (!__tmp108_last || !__tmp108_line.IsEmpty)
                    {
                        __out.Write(__tmp108_line);
                        __tmp107_outputWritten = true;
                    }
                    if (!__tmp108_last) __out.AppendLine(true);
                }
                string __tmp109_line = ".ModelVersion "; //1274:21
                if (!string.IsNullOrEmpty(__tmp109_line))
                {
                    __out.Write(__tmp109_line);
                    __tmp107_outputWritten = true;
                }
                var __tmp110 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp110.Write(Properties.CoreNs);
                var __tmp110Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp110.ToStringAndFree());
                bool __tmp110_last = __tmp110Reader.EndOfStream;
                while(!__tmp110_last)
                {
                    ReadOnlySpan<char> __tmp110_line = __tmp110Reader.ReadLine();
                    __tmp110_last = __tmp110Reader.EndOfStream;
                    if (!__tmp110_last || !__tmp110_line.IsEmpty)
                    {
                        __out.Write(__tmp110_line);
                        __tmp107_outputWritten = true;
                    }
                    if (!__tmp110_last) __out.AppendLine(true);
                }
                string __tmp111_line = ".IModel.Version => "; //1274:54
                if (!string.IsNullOrEmpty(__tmp111_line))
                {
                    __out.Write(__tmp111_line);
                    __tmp107_outputWritten = true;
                }
                var __tmp112 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp112.Write(CSharpName(model, ModelKind.ImmutableInstance));
                var __tmp112Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp112.ToStringAndFree());
                bool __tmp112_last = __tmp112Reader.EndOfStream;
                while(!__tmp112_last)
                {
                    ReadOnlySpan<char> __tmp112_line = __tmp112Reader.ReadLine();
                    __tmp112_last = __tmp112Reader.EndOfStream;
                    if (!__tmp112_last || !__tmp112_line.IsEmpty)
                    {
                        __out.Write(__tmp112_line);
                        __tmp107_outputWritten = true;
                    }
                    if (!__tmp112_last) __out.AppendLine(true);
                }
                string __tmp113_line = ".MModel.Version;"; //1274:120
                if (!string.IsNullOrEmpty(__tmp113_line))
                {
                    __out.Write(__tmp113_line);
                    __tmp107_outputWritten = true;
                }
                if (__tmp107_outputWritten) __out.AppendLine(true);
                if (__tmp107_outputWritten)
                {
                    __out.AppendLine(false); //1274:136
                }
                bool __tmp115_outputWritten = false;
                string __tmp116_line = "	global::System.Collections.Generic.IEnumerable<global::MetaDslx.Modeling.IModelObject> "; //1275:1
                if (!string.IsNullOrEmpty(__tmp116_line))
                {
                    __out.Write(__tmp116_line);
                    __tmp115_outputWritten = true;
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
                        __tmp115_outputWritten = true;
                    }
                    if (!__tmp117_last) __out.AppendLine(true);
                }
                string __tmp118_line = ".IModel.Objects => "; //1275:108
                if (!string.IsNullOrEmpty(__tmp118_line))
                {
                    __out.Write(__tmp118_line);
                    __tmp115_outputWritten = true;
                }
                var __tmp119 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp119.Write(CSharpName(model, ModelKind.ImmutableInstance));
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
                string __tmp120_line = ".MModel.Objects;"; //1275:174
                if (!string.IsNullOrEmpty(__tmp120_line))
                {
                    __out.Write(__tmp120_line);
                    __tmp115_outputWritten = true;
                }
                if (__tmp115_outputWritten) __out.AppendLine(true);
                if (__tmp115_outputWritten)
                {
                    __out.AppendLine(false); //1275:190
                }
                bool __tmp122_outputWritten = false;
                string __tmp123_line = "	string "; //1276:1
                if (!string.IsNullOrEmpty(__tmp123_line))
                {
                    __out.Write(__tmp123_line);
                    __tmp122_outputWritten = true;
                }
                var __tmp124 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp124.Write(Properties.CoreNs);
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
                string __tmp125_line = ".IMetaModel.Uri => this.Uri;"; //1276:28
                if (!string.IsNullOrEmpty(__tmp125_line))
                {
                    __out.Write(__tmp125_line);
                    __tmp122_outputWritten = true;
                }
                if (__tmp122_outputWritten) __out.AppendLine(true);
                if (__tmp122_outputWritten)
                {
                    __out.AppendLine(false); //1276:56
                }
                bool __tmp127_outputWritten = false;
                string __tmp128_line = "	string "; //1277:1
                if (!string.IsNullOrEmpty(__tmp128_line))
                {
                    __out.Write(__tmp128_line);
                    __tmp127_outputWritten = true;
                }
                var __tmp129 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp129.Write(Properties.CoreNs);
                var __tmp129Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp129.ToStringAndFree());
                bool __tmp129_last = __tmp129Reader.EndOfStream;
                while(!__tmp129_last)
                {
                    ReadOnlySpan<char> __tmp129_line = __tmp129Reader.ReadLine();
                    __tmp129_last = __tmp129Reader.EndOfStream;
                    if (!__tmp129_last || !__tmp129_line.IsEmpty)
                    {
                        __out.Write(__tmp129_line);
                        __tmp127_outputWritten = true;
                    }
                    if (!__tmp129_last) __out.AppendLine(true);
                }
                string __tmp130_line = ".IMetaModel.Prefix => this.Prefix;"; //1277:28
                if (!string.IsNullOrEmpty(__tmp130_line))
                {
                    __out.Write(__tmp130_line);
                    __tmp127_outputWritten = true;
                }
                if (__tmp127_outputWritten) __out.AppendLine(true);
                if (__tmp127_outputWritten)
                {
                    __out.AppendLine(false); //1277:62
                }
                bool __tmp132_outputWritten = false;
                string __tmp131Prefix = "	"; //1278:1
                var __tmp133 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp133.Write(Properties.CoreNs);
                var __tmp133Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp133.ToStringAndFree());
                bool __tmp133_last = __tmp133Reader.EndOfStream;
                while(!__tmp133_last)
                {
                    ReadOnlySpan<char> __tmp133_line = __tmp133Reader.ReadLine();
                    __tmp133_last = __tmp133Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp131Prefix))
                    {
                        __out.Write(__tmp131Prefix);
                        __tmp132_outputWritten = true;
                    }
                    if (!__tmp133_last || !__tmp133_line.IsEmpty)
                    {
                        __out.Write(__tmp133_line);
                        __tmp132_outputWritten = true;
                    }
                    if (!__tmp133_last) __out.AppendLine(true);
                }
                string __tmp134_line = ".IModelGroup "; //1278:21
                if (!string.IsNullOrEmpty(__tmp134_line))
                {
                    __out.Write(__tmp134_line);
                    __tmp132_outputWritten = true;
                }
                var __tmp135 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp135.Write(Properties.CoreNs);
                var __tmp135Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp135.ToStringAndFree());
                bool __tmp135_last = __tmp135Reader.EndOfStream;
                while(!__tmp135_last)
                {
                    ReadOnlySpan<char> __tmp135_line = __tmp135Reader.ReadLine();
                    __tmp135_last = __tmp135Reader.EndOfStream;
                    if (!__tmp135_last || !__tmp135_line.IsEmpty)
                    {
                        __out.Write(__tmp135_line);
                        __tmp132_outputWritten = true;
                    }
                    if (!__tmp135_last) __out.AppendLine(true);
                }
                string __tmp136_line = ".IModel.ModelGroup => "; //1278:53
                if (!string.IsNullOrEmpty(__tmp136_line))
                {
                    __out.Write(__tmp136_line);
                    __tmp132_outputWritten = true;
                }
                var __tmp137 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp137.Write(CSharpName(model, ModelKind.ImmutableInstance));
                var __tmp137Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp137.ToStringAndFree());
                bool __tmp137_last = __tmp137Reader.EndOfStream;
                while(!__tmp137_last)
                {
                    ReadOnlySpan<char> __tmp137_line = __tmp137Reader.ReadLine();
                    __tmp137_last = __tmp137Reader.EndOfStream;
                    if (!__tmp137_last || !__tmp137_line.IsEmpty)
                    {
                        __out.Write(__tmp137_line);
                        __tmp132_outputWritten = true;
                    }
                    if (!__tmp137_last) __out.AppendLine(true);
                }
                string __tmp138_line = ".MModel.ModelGroup;"; //1278:122
                if (!string.IsNullOrEmpty(__tmp138_line))
                {
                    __out.Write(__tmp138_line);
                    __tmp132_outputWritten = true;
                }
                if (__tmp132_outputWritten) __out.AppendLine(true);
                if (__tmp132_outputWritten)
                {
                    __out.AppendLine(false); //1278:141
                }
                bool __tmp140_outputWritten = false;
                string __tmp141_line = "	string "; //1279:1
                if (!string.IsNullOrEmpty(__tmp141_line))
                {
                    __out.Write(__tmp141_line);
                    __tmp140_outputWritten = true;
                }
                var __tmp142 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp142.Write(Properties.CoreNs);
                var __tmp142Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp142.ToStringAndFree());
                bool __tmp142_last = __tmp142Reader.EndOfStream;
                while(!__tmp142_last)
                {
                    ReadOnlySpan<char> __tmp142_line = __tmp142Reader.ReadLine();
                    __tmp142_last = __tmp142Reader.EndOfStream;
                    if (!__tmp142_last || !__tmp142_line.IsEmpty)
                    {
                        __out.Write(__tmp142_line);
                        __tmp140_outputWritten = true;
                    }
                    if (!__tmp142_last) __out.AppendLine(true);
                }
                string __tmp143_line = ".IMetaModel.Namespace => this.Namespace.FullName;"; //1279:28
                if (!string.IsNullOrEmpty(__tmp143_line))
                {
                    __out.Write(__tmp143_line);
                    __tmp140_outputWritten = true;
                }
                if (__tmp140_outputWritten) __out.AppendLine(true);
                if (__tmp140_outputWritten)
                {
                    __out.AppendLine(false); //1279:77
                }
                __out.AppendLine(true); //1280:1
                bool __tmp145_outputWritten = false;
                string __tmp146_line = "	public "; //1281:1
                if (!string.IsNullOrEmpty(__tmp146_line))
                {
                    __out.Write(__tmp146_line);
                    __tmp145_outputWritten = true;
                }
                var __tmp147 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp147.Write(Properties.CoreNs);
                var __tmp147Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp147.ToStringAndFree());
                bool __tmp147_last = __tmp147Reader.EndOfStream;
                while(!__tmp147_last)
                {
                    ReadOnlySpan<char> __tmp147_line = __tmp147Reader.ReadLine();
                    __tmp147_last = __tmp147Reader.EndOfStream;
                    if (!__tmp147_last || !__tmp147_line.IsEmpty)
                    {
                        __out.Write(__tmp147_line);
                        __tmp145_outputWritten = true;
                    }
                    if (!__tmp147_last) __out.AppendLine(true);
                }
                string __tmp148_line = ".IModelFactory CreateFactory("; //1281:28
                if (!string.IsNullOrEmpty(__tmp148_line))
                {
                    __out.Write(__tmp148_line);
                    __tmp145_outputWritten = true;
                }
                var __tmp149 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp149.Write(Properties.CoreNs);
                var __tmp149Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp149.ToStringAndFree());
                bool __tmp149_last = __tmp149Reader.EndOfStream;
                while(!__tmp149_last)
                {
                    ReadOnlySpan<char> __tmp149_line = __tmp149Reader.ReadLine();
                    __tmp149_last = __tmp149Reader.EndOfStream;
                    if (!__tmp149_last || !__tmp149_line.IsEmpty)
                    {
                        __out.Write(__tmp149_line);
                        __tmp145_outputWritten = true;
                    }
                    if (!__tmp149_last) __out.AppendLine(true);
                }
                string __tmp150_line = ".MutableModel model, "; //1281:76
                if (!string.IsNullOrEmpty(__tmp150_line))
                {
                    __out.Write(__tmp150_line);
                    __tmp145_outputWritten = true;
                }
                var __tmp151 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp151.Write(Properties.CoreNs);
                var __tmp151Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp151.ToStringAndFree());
                bool __tmp151_last = __tmp151Reader.EndOfStream;
                while(!__tmp151_last)
                {
                    ReadOnlySpan<char> __tmp151_line = __tmp151Reader.ReadLine();
                    __tmp151_last = __tmp151Reader.EndOfStream;
                    if (!__tmp151_last || !__tmp151_line.IsEmpty)
                    {
                        __out.Write(__tmp151_line);
                        __tmp145_outputWritten = true;
                    }
                    if (!__tmp151_last) __out.AppendLine(true);
                }
                string __tmp152_line = ".ModelFactoryFlags flags = "; //1281:116
                if (!string.IsNullOrEmpty(__tmp152_line))
                {
                    __out.Write(__tmp152_line);
                    __tmp145_outputWritten = true;
                }
                var __tmp153 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp153.Write(Properties.CoreNs);
                var __tmp153Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp153.ToStringAndFree());
                bool __tmp153_last = __tmp153Reader.EndOfStream;
                while(!__tmp153_last)
                {
                    ReadOnlySpan<char> __tmp153_line = __tmp153Reader.ReadLine();
                    __tmp153_last = __tmp153Reader.EndOfStream;
                    if (!__tmp153_last || !__tmp153_line.IsEmpty)
                    {
                        __out.Write(__tmp153_line);
                        __tmp145_outputWritten = true;
                    }
                    if (!__tmp153_last) __out.AppendLine(true);
                }
                string __tmp154_line = ".ModelFactoryFlags.None)"; //1281:162
                if (!string.IsNullOrEmpty(__tmp154_line))
                {
                    __out.Write(__tmp154_line);
                    __tmp145_outputWritten = true;
                }
                if (__tmp145_outputWritten) __out.AppendLine(true);
                if (__tmp145_outputWritten)
                {
                    __out.AppendLine(false); //1281:186
                }
                __out.Write("	{"); //1282:1
                __out.AppendLine(false); //1282:3
                bool __tmp156_outputWritten = false;
                string __tmp157_line = "		return new "; //1283:1
                if (!string.IsNullOrEmpty(__tmp157_line))
                {
                    __out.Write(__tmp157_line);
                    __tmp156_outputWritten = true;
                }
                var __tmp158 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp158.Write(CSharpName(model, ModelKind.Factory));
                var __tmp158Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp158.ToStringAndFree());
                bool __tmp158_last = __tmp158Reader.EndOfStream;
                while(!__tmp158_last)
                {
                    ReadOnlySpan<char> __tmp158_line = __tmp158Reader.ReadLine();
                    __tmp158_last = __tmp158Reader.EndOfStream;
                    if (!__tmp158_last || !__tmp158_line.IsEmpty)
                    {
                        __out.Write(__tmp158_line);
                        __tmp156_outputWritten = true;
                    }
                    if (!__tmp158_last) __out.AppendLine(true);
                }
                string __tmp159_line = "(model, flags);"; //1283:51
                if (!string.IsNullOrEmpty(__tmp159_line))
                {
                    __out.Write(__tmp159_line);
                    __tmp156_outputWritten = true;
                }
                if (__tmp156_outputWritten) __out.AppendLine(true);
                if (__tmp156_outputWritten)
                {
                    __out.AppendLine(false); //1283:66
                }
                __out.Write("	}"); //1284:1
                __out.AppendLine(false); //1284:3
            }
            __out.Write("}"); //1286:1
            __out.AppendLine(false); //1286:2
            return __out.ToStringAndFree();
        }

        public string GenerateBuilderField(MetaModel model, MetaClass cls, MetaProperty prop) //1289:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "private "; //1290:1
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
            string __tmp5_line = " "; //1290:63
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
            string __tmp7_line = ";"; //1290:88
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //1290:89
            }
            return __out.ToStringAndFree();
        }

        public string GenerateBuilderPropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //1293:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.AppendLine(true); //1294:1
            if (cls.GetAllFinalProperties().Contains(prop)) //1295:2
            {
                bool __tmp2_outputWritten = false;
                string __tmp3_line = "public "; //1296:1
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
                string __tmp5_line = " "; //1296:62
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
                    __out.AppendLine(false); //1296:74
                }
            }
            else //1297:2
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
                    __out.AppendLine(false); //1298:54
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
                string __tmp13_line = " "; //1299:55
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
                string __tmp15_line = "."; //1299:111
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
                    __out.AppendLine(false); //1299:123
                }
            }
            __out.Write("{"); //1301:1
            __out.AppendLine(false); //1301:2
            if (prop.Type is MetaCollectionType) //1302:3
            {
                if (((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.Set || ((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiSet) //1303:4
                {
                    bool __tmp18_outputWritten = false;
                    string __tmp19_line = "	get { return this.GetSet<"; //1304:1
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
                    string __tmp21_line = ">("; //1304:113
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
                    string __tmp23_line = ", ref "; //1304:169
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
                    string __tmp25_line = "); }"; //1304:199
                    if (!string.IsNullOrEmpty(__tmp25_line))
                    {
                        __out.Write(__tmp25_line);
                        __tmp18_outputWritten = true;
                    }
                    if (__tmp18_outputWritten) __out.AppendLine(true);
                    if (__tmp18_outputWritten)
                    {
                        __out.AppendLine(false); //1304:203
                    }
                }
                else //1305:4
                {
                    bool __tmp27_outputWritten = false;
                    string __tmp28_line = "	get { return this.GetList<"; //1306:1
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
                    string __tmp30_line = ">("; //1306:114
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
                    string __tmp32_line = ", ref "; //1306:170
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
                    string __tmp34_line = "); }"; //1306:200
                    if (!string.IsNullOrEmpty(__tmp34_line))
                    {
                        __out.Write(__tmp34_line);
                        __tmp27_outputWritten = true;
                    }
                    if (__tmp27_outputWritten) __out.AppendLine(true);
                    if (__tmp27_outputWritten)
                    {
                        __out.AppendLine(false); //1306:204
                    }
                }
            }
            else if (IsReferenceType(prop.Type)) //1308:3
            {
                bool __tmp36_outputWritten = false;
                string __tmp37_line = "	get { return this.GetReference<"; //1309:1
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
                string __tmp39_line = ">("; //1309:87
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
                string __tmp41_line = "); }"; //1309:143
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Write(__tmp41_line);
                    __tmp36_outputWritten = true;
                }
                if (__tmp36_outputWritten) __out.AppendLine(true);
                if (__tmp36_outputWritten)
                {
                    __out.AppendLine(false); //1309:147
                }
            }
            else //1310:3
            {
                bool __tmp43_outputWritten = false;
                string __tmp44_line = "	get { return this.GetValue<"; //1311:1
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
                string __tmp46_line = ">("; //1311:83
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
                string __tmp48_line = "); }"; //1311:139
                if (!string.IsNullOrEmpty(__tmp48_line))
                {
                    __out.Write(__tmp48_line);
                    __tmp43_outputWritten = true;
                }
                if (__tmp43_outputWritten) __out.AppendLine(true);
                if (__tmp43_outputWritten)
                {
                    __out.AppendLine(false); //1311:143
                }
            }
            if ((prop.Kind == MetaPropertyKind.Normal) && !(prop.Type is MetaCollectionType)) //1313:3
            {
                if (IsReferenceType(prop.Type)) //1314:4
                {
                    bool __tmp50_outputWritten = false;
                    string __tmp51_line = "	set { this.SetReference<"; //1315:1
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
                    string __tmp53_line = ">("; //1315:80
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
                    string __tmp55_line = ", value); }"; //1315:136
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Write(__tmp55_line);
                        __tmp50_outputWritten = true;
                    }
                    if (__tmp50_outputWritten) __out.AppendLine(true);
                    if (__tmp50_outputWritten)
                    {
                        __out.AppendLine(false); //1315:147
                    }
                }
                else //1316:4
                {
                    bool __tmp57_outputWritten = false;
                    string __tmp58_line = "	set { this.SetValue<"; //1317:1
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
                    string __tmp60_line = ">("; //1317:76
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
                    string __tmp62_line = ", value); }"; //1317:132
                    if (!string.IsNullOrEmpty(__tmp62_line))
                    {
                        __out.Write(__tmp62_line);
                        __tmp57_outputWritten = true;
                    }
                    if (__tmp57_outputWritten) __out.AppendLine(true);
                    if (__tmp57_outputWritten)
                    {
                        __out.AppendLine(false); //1317:143
                    }
                }
            }
            __out.Write("}"); //1320:1
            __out.AppendLine(false); //1320:2
            if (!(prop.Type is MetaCollectionType)) //1321:2
            {
                __out.AppendLine(true); //1322:1
                bool __tmp64_outputWritten = false;
                string __tmp65_line = "void "; //1323:1
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
                string __tmp67_line = ".Set"; //1323:61
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
                string __tmp69_line = "Lazy(global::System.Func<"; //1323:76
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
                string __tmp71_line = "> lazy)"; //1323:155
                if (!string.IsNullOrEmpty(__tmp71_line))
                {
                    __out.Write(__tmp71_line);
                    __tmp64_outputWritten = true;
                }
                if (__tmp64_outputWritten) __out.AppendLine(true);
                if (__tmp64_outputWritten)
                {
                    __out.AppendLine(false); //1323:162
                }
                __out.Write("{"); //1324:1
                __out.AppendLine(false); //1324:2
                if (IsReferenceType(prop.Type)) //1325:3
                {
                    bool __tmp73_outputWritten = false;
                    string __tmp74_line = "	this.SetLazyReference("; //1326:1
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
                    string __tmp76_line = ", lazy);"; //1326:79
                    if (!string.IsNullOrEmpty(__tmp76_line))
                    {
                        __out.Write(__tmp76_line);
                        __tmp73_outputWritten = true;
                    }
                    if (__tmp73_outputWritten) __out.AppendLine(true);
                    if (__tmp73_outputWritten)
                    {
                        __out.AppendLine(false); //1326:87
                    }
                }
                else //1327:3
                {
                    bool __tmp78_outputWritten = false;
                    string __tmp79_line = "	this.SetLazyValue("; //1328:1
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
                    string __tmp81_line = ", lazy);"; //1328:75
                    if (!string.IsNullOrEmpty(__tmp81_line))
                    {
                        __out.Write(__tmp81_line);
                        __tmp78_outputWritten = true;
                    }
                    if (__tmp78_outputWritten) __out.AppendLine(true);
                    if (__tmp78_outputWritten)
                    {
                        __out.AppendLine(false); //1328:83
                    }
                }
                __out.Write("}"); //1330:1
                __out.AppendLine(false); //1330:2
                __out.AppendLine(true); //1331:1
                bool __tmp83_outputWritten = false;
                string __tmp84_line = "void "; //1332:1
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
                string __tmp86_line = ".Set"; //1332:61
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
                string __tmp88_line = "Lazy(global::System.Func<"; //1332:76
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
                string __tmp90_line = ", "; //1332:156
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
                string __tmp92_line = "> lazy)"; //1332:212
                if (!string.IsNullOrEmpty(__tmp92_line))
                {
                    __out.Write(__tmp92_line);
                    __tmp83_outputWritten = true;
                }
                if (__tmp83_outputWritten) __out.AppendLine(true);
                if (__tmp83_outputWritten)
                {
                    __out.AppendLine(false); //1332:219
                }
                __out.Write("{"); //1333:1
                __out.AppendLine(false); //1333:2
                if (IsReferenceType(prop.Type)) //1334:3
                {
                    bool __tmp94_outputWritten = false;
                    string __tmp95_line = "	this.SetLazyReference("; //1335:1
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
                    string __tmp97_line = ", lazy);"; //1335:79
                    if (!string.IsNullOrEmpty(__tmp97_line))
                    {
                        __out.Write(__tmp97_line);
                        __tmp94_outputWritten = true;
                    }
                    if (__tmp94_outputWritten) __out.AppendLine(true);
                    if (__tmp94_outputWritten)
                    {
                        __out.AppendLine(false); //1335:87
                    }
                }
                else //1336:3
                {
                    bool __tmp99_outputWritten = false;
                    string __tmp100_line = "	this.SetLazyValue("; //1337:1
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
                    string __tmp102_line = ", lazy);"; //1337:75
                    if (!string.IsNullOrEmpty(__tmp102_line))
                    {
                        __out.Write(__tmp102_line);
                        __tmp99_outputWritten = true;
                    }
                    if (__tmp99_outputWritten) __out.AppendLine(true);
                    if (__tmp99_outputWritten)
                    {
                        __out.AppendLine(false); //1337:83
                    }
                }
                __out.Write("}"); //1339:1
                __out.AppendLine(false); //1339:2
                __out.AppendLine(true); //1340:1
                bool __tmp104_outputWritten = false;
                string __tmp105_line = "void "; //1341:1
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
                string __tmp107_line = ".Set"; //1341:61
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
                string __tmp109_line = "Lazy(global::System.Func<"; //1341:76
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
                string __tmp111_line = ", "; //1341:158
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
                string __tmp113_line = "> immutableLazy, global::System.Func<"; //1341:216
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
                string __tmp115_line = ", "; //1341:308
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
                string __tmp117_line = "> mutableLazy)"; //1341:364
                if (!string.IsNullOrEmpty(__tmp117_line))
                {
                    __out.Write(__tmp117_line);
                    __tmp104_outputWritten = true;
                }
                if (__tmp104_outputWritten) __out.AppendLine(true);
                if (__tmp104_outputWritten)
                {
                    __out.AppendLine(false); //1341:378
                }
                __out.Write("{"); //1342:1
                __out.AppendLine(false); //1342:2
                if (IsReferenceType(prop.Type)) //1343:3
                {
                    bool __tmp119_outputWritten = false;
                    string __tmp120_line = "	this.SetLazyReference("; //1344:1
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
                    string __tmp122_line = ", immutableLazy, mutableLazy);"; //1344:79
                    if (!string.IsNullOrEmpty(__tmp122_line))
                    {
                        __out.Write(__tmp122_line);
                        __tmp119_outputWritten = true;
                    }
                    if (__tmp119_outputWritten) __out.AppendLine(true);
                    if (__tmp119_outputWritten)
                    {
                        __out.AppendLine(false); //1344:109
                    }
                }
                else //1345:3
                {
                    bool __tmp124_outputWritten = false;
                    string __tmp125_line = "	this.SetLazyValue("; //1346:1
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
                    string __tmp127_line = ", immutableLazy, mutableLazy);"; //1346:75
                    if (!string.IsNullOrEmpty(__tmp127_line))
                    {
                        __out.Write(__tmp127_line);
                        __tmp124_outputWritten = true;
                    }
                    if (__tmp124_outputWritten) __out.AppendLine(true);
                    if (__tmp124_outputWritten)
                    {
                        __out.AppendLine(false); //1346:105
                    }
                }
                __out.Write("}"); //1348:1
                __out.AppendLine(false); //1348:2
            }
            return __out.ToStringAndFree();
        }

        public string GenerateBuilderOperationImpl(MetaModel model, MetaClass cls, MetaOperation op) //1352:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.AppendLine(true); //1353:1
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
            string __tmp4_line = " "; //1354:68
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
            string __tmp6_line = "."; //1354:122
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
            string __tmp8_line = "("; //1354:132
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
            string __tmp10_line = ")"; //1354:202
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Write(__tmp10_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //1354:203
            }
            __out.Write("{"); //1355:1
            __out.AppendLine(false); //1355:2
            var finalOp = GetFinalOperation(cls, op); //1356:2
            bool __tmp12_outputWritten = false;
            string __tmp11Prefix = "    "; //1357:1
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
            string __tmp15_line = ".Implementation."; //1357:134
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
            string __tmp17_line = "_"; //1357:204
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
            string __tmp19_line = "("; //1357:219
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
            string __tmp21_line = ");"; //1357:296
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp12_outputWritten = true;
            }
            if (__tmp12_outputWritten) __out.AppendLine(true);
            if (__tmp12_outputWritten)
            {
                __out.AppendLine(false); //1357:298
            }
            __out.Write("}"); //1358:1
            __out.AppendLine(false); //1358:2
            return __out.ToStringAndFree();
        }

    }
}

