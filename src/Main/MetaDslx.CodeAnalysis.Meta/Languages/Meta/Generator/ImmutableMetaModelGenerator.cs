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
        MetaType GetMetaType(MetaTypedElement mtypedElement); //63:8
        MetaType GetMetaType(MetaOperation mop); //64:8
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

        internal MetaType GetMetaType(MetaTypedElement mtypedElement) //63:8
        {
            return this.extensionFunctions.GetMetaType(mtypedElement); //63:8
        }

        internal MetaType GetMetaType(MetaOperation mop) //64:8
        {
            return this.extensionFunctions.GetMetaType(mop); //64:8
        }

        public string GenerateDocumentation(MetaDocumentedElement elem) //66:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            var lines = elem.GetDocumentationLines(); //67:2
            if (lines.Count > 0) //68:2
            {
                var __loop3_results = 
                    (from line in __Enumerate((lines).GetEnumerator()) //69:8
                    select new { line = line}
                    ).ToList(); //69:3
                for (int __loop3_iteration = 0; __loop3_iteration < __loop3_results.Count; ++__loop3_iteration)
                {
                    var __tmp1 = __loop3_results[__loop3_iteration];
                    var line = __tmp1.line;
                    bool __tmp3_outputWritten = false;
                    string __tmp4_line = "///"; //70:1
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
                        __out.AppendLine(false); //70:10
                    }
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateAttributes(MetaElement elem) //75:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            var __loop4_results = 
                (from __loop4_var1 in __Enumerate((elem).GetEnumerator()) //76:7
                from attr in __Enumerate((__loop4_var1.Attributes).GetEnumerator()) //76:13
                select new { __loop4_var1 = __loop4_var1, attr = attr}
                ).ToList(); //76:2
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
                    __out.AppendLine(false); //77:41
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateMetamodel(MetaModel model) //81:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //82:1
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
                __out.AppendLine(false); //82:67
            }
            __out.Write("{"); //83:1
            __out.AppendLine(false); //83:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	using global::"; //84:1
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
            string __tmp9_line = ";"; //84:74
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Write(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //84:75
            }
            __out.AppendLine(true); //85:1
            bool __tmp11_outputWritten = false;
            string __tmp10Prefix = "	"; //86:1
            var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp12.Write(GenerateMetaModelInstance(model));
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
                __out.AppendLine(false); //86:36
            }
            __out.AppendLine(true); //87:1
            bool __tmp14_outputWritten = false;
            string __tmp13Prefix = "	"; //88:1
            var __tmp15 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp15.Write(GenerateFactory(model));
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
                var __tmp16 = __loop5_results[__loop5_iteration];
                var __loop5_var1 = __tmp16.__loop5_var1;
                var enm = __tmp16.enm;
                bool __tmp18_outputWritten = false;
                string __tmp17Prefix = "	"; //91:1
                var __tmp19 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp19.Write(GenerateEnum(model, enm));
                var __tmp19Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp19.ToStringAndFree());
                bool __tmp19_last = __tmp19Reader.EndOfStream;
                while(!__tmp19_last)
                {
                    ReadOnlySpan<char> __tmp19_line = __tmp19Reader.ReadLine();
                    __tmp19_last = __tmp19Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp17Prefix))
                    {
                        __out.Write(__tmp17Prefix);
                        __tmp18_outputWritten = true;
                    }
                    if (!__tmp19_last || !__tmp19_line.IsEmpty)
                    {
                        __out.Write(__tmp19_line);
                        __tmp18_outputWritten = true;
                    }
                    if (!__tmp19_last || __tmp18_outputWritten) __out.AppendLine(true);
                }
                if (__tmp18_outputWritten)
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
                var __tmp20 = __loop6_results[__loop6_iteration];
                var __loop6_var1 = __tmp20.__loop6_var1;
                var cls = __tmp20.cls;
                bool __tmp22_outputWritten = false;
                string __tmp21Prefix = "	"; //94:1
                var __tmp23 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp23.Write(GenerateClass(model, cls));
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
                    __out.AppendLine(false); //94:29
                }
            }
            __out.AppendLine(true); //96:1
            bool __tmp25_outputWritten = false;
            string __tmp24Prefix = "	"; //97:1
            var __tmp26 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp26.Write(GenerateMetaModelDescriptor(model));
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
                __out.AppendLine(false); //97:38
            }
            __out.Write("}"); //98:1
            __out.AppendLine(false); //98:2
            __out.AppendLine(true); //99:1
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "namespace "; //100:1
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Write(__tmp29_line);
                __tmp28_outputWritten = true;
            }
            var __tmp30 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp30.Write(CSharpName(model.Namespace, NamespaceKind.Internal, true));
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
                var __tmp31 = __loop7_results[__loop7_iteration];
                var __loop7_var1 = __tmp31.__loop7_var1;
                var cls = __tmp31.cls;
                bool __tmp33_outputWritten = false;
                string __tmp32Prefix = "	"; //103:1
                var __tmp34 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp34.Write(GenerateClassInternal(model, cls));
                var __tmp34Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp34.ToStringAndFree());
                bool __tmp34_last = __tmp34Reader.EndOfStream;
                while(!__tmp34_last)
                {
                    ReadOnlySpan<char> __tmp34_line = __tmp34Reader.ReadLine();
                    __tmp34_last = __tmp34Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp32Prefix))
                    {
                        __out.Write(__tmp32Prefix);
                        __tmp33_outputWritten = true;
                    }
                    if (!__tmp34_last || !__tmp34_line.IsEmpty)
                    {
                        __out.Write(__tmp34_line);
                        __tmp33_outputWritten = true;
                    }
                    if (!__tmp34_last || __tmp33_outputWritten) __out.AppendLine(true);
                }
                if (__tmp33_outputWritten)
                {
                    __out.AppendLine(false); //103:37
                }
            }
            __out.AppendLine(true); //105:1
            bool __tmp36_outputWritten = false;
            string __tmp35Prefix = "	"; //106:1
            var __tmp37 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp37.Write(GenerateMetaModelBuilderInstance(model));
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
                __out.AppendLine(false); //106:43
            }
            __out.AppendLine(true); //107:1
            bool __tmp39_outputWritten = false;
            string __tmp38Prefix = "	"; //108:1
            var __tmp40 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp40.Write(GenerateImplementationBase(model));
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
                __out.AppendLine(false); //108:37
            }
            __out.AppendLine(true); //109:1
            bool __tmp42_outputWritten = false;
            string __tmp41Prefix = "	"; //110:1
            var __tmp43 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp43.Write(GenerateImplementationProvider(model));
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
            string __tmp3_line = "private class "; //124:1
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
            string __tmp5_line = " : "; //124:53
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
            string __tmp7_line = ".ModelMetadata"; //124:75
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //124:89
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
            string __tmp12_line = "("; //126:47
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
            string __tmp14_line = ".IModel model, global::System.Collections.Immutable.ImmutableArray<string> namespaceSegments, string name, "; //126:67
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
            string __tmp16_line = ".ModelVersion version, string uri, string prefix)"; //126:193
            if (!string.IsNullOrEmpty(__tmp16_line))
            {
                __out.Write(__tmp16_line);
                __tmp9_outputWritten = true;
            }
            if (__tmp9_outputWritten) __out.AppendLine(true);
            if (__tmp9_outputWritten)
            {
                __out.AppendLine(false); //126:242
            }
            __out.Write("		: base(model, namespaceSegments, name, version, uri, prefix)"); //127:1
            __out.AppendLine(false); //127:63
            __out.Write("	{"); //128:1
            __out.AppendLine(false); //128:3
            __out.Write("	}"); //129:1
            __out.AppendLine(false); //129:3
            __out.AppendLine(true); //130:1
            bool __tmp18_outputWritten = false;
            string __tmp19_line = "    protected override "; //131:1
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
            string __tmp21_line = ".ModelMetadata Create("; //131:43
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp18_outputWritten = true;
            }
            var __tmp22 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp22.Write(Properties.CoreNs);
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
            string __tmp23_line = ".IModel model, global::System.Collections.Immutable.ImmutableArray<string> namespaceSegments, string name, "; //131:84
            if (!string.IsNullOrEmpty(__tmp23_line))
            {
                __out.Write(__tmp23_line);
                __tmp18_outputWritten = true;
            }
            var __tmp24 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp24.Write(Properties.CoreNs);
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
            string __tmp25_line = ".ModelVersion version, string uri, string prefix)"; //131:210
            if (!string.IsNullOrEmpty(__tmp25_line))
            {
                __out.Write(__tmp25_line);
                __tmp18_outputWritten = true;
            }
            if (__tmp18_outputWritten) __out.AppendLine(true);
            if (__tmp18_outputWritten)
            {
                __out.AppendLine(false); //131:259
            }
            __out.Write("    {"); //132:1
            __out.AppendLine(false); //132:6
            bool __tmp27_outputWritten = false;
            string __tmp28_line = "        return new "; //133:1
            if (!string.IsNullOrEmpty(__tmp28_line))
            {
                __out.Write(__tmp28_line);
                __tmp27_outputWritten = true;
            }
            var __tmp29 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp29.Write(CSharpName(model, ModelKind.Metadata));
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
            string __tmp30_line = "(model, namespaceSegments, name, version, uri, prefix);"; //133:58
            if (!string.IsNullOrEmpty(__tmp30_line))
            {
                __out.Write(__tmp30_line);
                __tmp27_outputWritten = true;
            }
            if (__tmp27_outputWritten) __out.AppendLine(true);
            if (__tmp27_outputWritten)
            {
                __out.AppendLine(false); //133:113
            }
            __out.Write("    }"); //134:1
            __out.AppendLine(false); //134:6
            __out.AppendLine(true); //135:1
            bool __tmp32_outputWritten = false;
            string __tmp33_line = "	public override "; //136:1
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
            string __tmp35_line = ".IModelFactory CreateFactory("; //136:37
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Write(__tmp35_line);
                __tmp32_outputWritten = true;
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
                    __tmp32_outputWritten = true;
                }
                if (!__tmp36_last) __out.AppendLine(true);
            }
            string __tmp37_line = ".MutableModel model, "; //136:85
            if (!string.IsNullOrEmpty(__tmp37_line))
            {
                __out.Write(__tmp37_line);
                __tmp32_outputWritten = true;
            }
            var __tmp38 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp38.Write(Properties.CoreNs);
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
            string __tmp39_line = ".ModelFactoryFlags flags = "; //136:125
            if (!string.IsNullOrEmpty(__tmp39_line))
            {
                __out.Write(__tmp39_line);
                __tmp32_outputWritten = true;
            }
            var __tmp40 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp40.Write(Properties.CoreNs);
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
            string __tmp41_line = ".ModelFactoryFlags.None)"; //136:171
            if (!string.IsNullOrEmpty(__tmp41_line))
            {
                __out.Write(__tmp41_line);
                __tmp32_outputWritten = true;
            }
            if (__tmp32_outputWritten) __out.AppendLine(true);
            if (__tmp32_outputWritten)
            {
                __out.AppendLine(false); //136:195
            }
            __out.Write("	{"); //137:1
            __out.AppendLine(false); //137:3
            bool __tmp43_outputWritten = false;
            string __tmp44_line = "		return new "; //138:1
            if (!string.IsNullOrEmpty(__tmp44_line))
            {
                __out.Write(__tmp44_line);
                __tmp43_outputWritten = true;
            }
            var __tmp45 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp45.Write(CSharpName(model, ModelKind.Factory));
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
            string __tmp46_line = "(model, flags);"; //138:51
            if (!string.IsNullOrEmpty(__tmp46_line))
            {
                __out.Write(__tmp46_line);
                __tmp43_outputWritten = true;
            }
            if (__tmp43_outputWritten) __out.AppendLine(true);
            if (__tmp43_outputWritten)
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
            string __tmp14_line = ".ModelMetadata MMetadata;"; //155:44
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //155:69
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
            string __tmp75_line = "		MModel = "; //180:1
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
            string __tmp77_line = ".instance.MModel.ToImmutable();"; //180:57
            if (!string.IsNullOrEmpty(__tmp77_line))
            {
                __out.Write(__tmp77_line);
                __tmp74_outputWritten = true;
            }
            if (__tmp74_outputWritten) __out.AppendLine(true);
            if (__tmp74_outputWritten)
            {
                __out.AppendLine(false); //180:88
            }
            __out.Write("		MMetadata = MModel.Metadata;"); //181:1
            __out.AppendLine(false); //181:31
            __out.AppendLine(true); //182:1
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //183:9
                from cst in __Enumerate((__loop11_var1).GetEnumerator()).OfType<MetaConstant>() //183:39
                select new { __loop11_var1 = __loop11_var1, cst = cst}
                ).ToList(); //183:4
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp78 = __loop11_results[__loop11_iteration];
                var __loop11_var1 = __tmp78.__loop11_var1;
                var cst = __tmp78.cst;
                if (metaMetaModel) //184:5
                {
                    bool __tmp80_outputWritten = false;
                    string __tmp79Prefix = "		"; //185:1
                    var __tmp81 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp81.Write(CSharpName(cst, model, ClassKind.ImmutableInstance));
                    var __tmp81Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp81.ToStringAndFree());
                    bool __tmp81_last = __tmp81Reader.EndOfStream;
                    while(!__tmp81_last)
                    {
                        ReadOnlySpan<char> __tmp81_line = __tmp81Reader.ReadLine();
                        __tmp81_last = __tmp81Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp79Prefix))
                        {
                            __out.Write(__tmp79Prefix);
                            __tmp80_outputWritten = true;
                        }
                        if (!__tmp81_last || !__tmp81_line.IsEmpty)
                        {
                            __out.Write(__tmp81_line);
                            __tmp80_outputWritten = true;
                        }
                        if (!__tmp81_last) __out.AppendLine(true);
                    }
                    string __tmp82_line = " = "; //185:55
                    if (!string.IsNullOrEmpty(__tmp82_line))
                    {
                        __out.Write(__tmp82_line);
                        __tmp80_outputWritten = true;
                    }
                    var __tmp83 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp83.Write(CSharpName(cst, model, ClassKind.BuilderInstance, true));
                    var __tmp83Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp83.ToStringAndFree());
                    bool __tmp83_last = __tmp83Reader.EndOfStream;
                    while(!__tmp83_last)
                    {
                        ReadOnlySpan<char> __tmp83_line = __tmp83Reader.ReadLine();
                        __tmp83_last = __tmp83Reader.EndOfStream;
                        if (!__tmp83_last || !__tmp83_line.IsEmpty)
                        {
                            __out.Write(__tmp83_line);
                            __tmp80_outputWritten = true;
                        }
                        if (!__tmp83_last) __out.AppendLine(true);
                    }
                    string __tmp84_line = ".ToImmutable(MModel);"; //185:114
                    if (!string.IsNullOrEmpty(__tmp84_line))
                    {
                        __out.Write(__tmp84_line);
                        __tmp80_outputWritten = true;
                    }
                    if (__tmp80_outputWritten) __out.AppendLine(true);
                    if (__tmp80_outputWritten)
                    {
                        __out.AppendLine(false); //185:135
                    }
                }
                else //186:5
                {
                    bool __tmp86_outputWritten = false;
                    string __tmp85Prefix = "		"; //187:1
                    var __tmp87 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp87.Write(CSharpName(cst, model, ClassKind.ImmutableInstance));
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
                    string __tmp88_line = " = "; //187:55
                    if (!string.IsNullOrEmpty(__tmp88_line))
                    {
                        __out.Write(__tmp88_line);
                        __tmp86_outputWritten = true;
                    }
                    var __tmp89 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp89.Write(CSharpName(cst, model, ClassKind.BuilderInstance, true));
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
                    string __tmp90_line = ".ToImmutable(MModel);"; //187:114
                    if (!string.IsNullOrEmpty(__tmp90_line))
                    {
                        __out.Write(__tmp90_line);
                        __tmp86_outputWritten = true;
                    }
                    if (__tmp86_outputWritten) __out.AppendLine(true);
                    if (__tmp86_outputWritten)
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
                var __tmp91 = __loop12_results[__loop12_iteration];
                var __loop12_var1 = __tmp91.__loop12_var1;
                var cls = __tmp91.cls;
                bool __tmp93_outputWritten = false;
                string __tmp92Prefix = "		"; //192:1
                var __tmp94 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp94.Write(CSharpName(cls, model, ClassKind.ImmutableInstance));
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
                string __tmp95_line = " = "; //192:55
                if (!string.IsNullOrEmpty(__tmp95_line))
                {
                    __out.Write(__tmp95_line);
                    __tmp93_outputWritten = true;
                }
                var __tmp96 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp96.Write(CSharpName(cls, model, ClassKind.BuilderInstance, true));
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
                string __tmp97_line = ".ToImmutable(MModel);"; //192:114
                if (!string.IsNullOrEmpty(__tmp97_line))
                {
                    __out.Write(__tmp97_line);
                    __tmp93_outputWritten = true;
                }
                if (__tmp93_outputWritten) __out.AppendLine(true);
                if (__tmp93_outputWritten)
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
                    var __tmp98 = __loop13_results[__loop13_iteration];
                    var __loop13_var1 = __tmp98.__loop13_var1;
                    var prop = __tmp98.prop;
                    bool __tmp100_outputWritten = false;
                    string __tmp99Prefix = "		"; //194:1
                    var __tmp101 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp101.Write(CSharpName(prop, model, PropertyKind.ImmutableInstance));
                    var __tmp101Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp101.ToStringAndFree());
                    bool __tmp101_last = __tmp101Reader.EndOfStream;
                    while(!__tmp101_last)
                    {
                        ReadOnlySpan<char> __tmp101_line = __tmp101Reader.ReadLine();
                        __tmp101_last = __tmp101Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp99Prefix))
                        {
                            __out.Write(__tmp99Prefix);
                            __tmp100_outputWritten = true;
                        }
                        if (!__tmp101_last || !__tmp101_line.IsEmpty)
                        {
                            __out.Write(__tmp101_line);
                            __tmp100_outputWritten = true;
                        }
                        if (!__tmp101_last) __out.AppendLine(true);
                    }
                    string __tmp102_line = " = "; //194:59
                    if (!string.IsNullOrEmpty(__tmp102_line))
                    {
                        __out.Write(__tmp102_line);
                        __tmp100_outputWritten = true;
                    }
                    var __tmp103 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp103.Write(CSharpName(prop, model, PropertyKind.BuilderInstance, true));
                    var __tmp103Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp103.ToStringAndFree());
                    bool __tmp103_last = __tmp103Reader.EndOfStream;
                    while(!__tmp103_last)
                    {
                        ReadOnlySpan<char> __tmp103_line = __tmp103Reader.ReadLine();
                        __tmp103_last = __tmp103Reader.EndOfStream;
                        if (!__tmp103_last || !__tmp103_line.IsEmpty)
                        {
                            __out.Write(__tmp103_line);
                            __tmp100_outputWritten = true;
                        }
                        if (!__tmp103_last) __out.AppendLine(true);
                    }
                    string __tmp104_line = ".ToImmutable(MModel);"; //194:122
                    if (!string.IsNullOrEmpty(__tmp104_line))
                    {
                        __out.Write(__tmp104_line);
                        __tmp100_outputWritten = true;
                    }
                    if (__tmp100_outputWritten) __out.AppendLine(true);
                    if (__tmp100_outputWritten)
                    {
                        __out.AppendLine(false); //194:143
                    }
                }
            }
            __out.AppendLine(true); //197:1
            bool __tmp106_outputWritten = false;
            string __tmp105Prefix = "		"; //198:1
            var __tmp107 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp107.Write(CSharpName(model, ModelKind.ImmutableInstance));
            var __tmp107Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp107.ToStringAndFree());
            bool __tmp107_last = __tmp107Reader.EndOfStream;
            while(!__tmp107_last)
            {
                ReadOnlySpan<char> __tmp107_line = __tmp107Reader.ReadLine();
                __tmp107_last = __tmp107Reader.EndOfStream;
                if (!string.IsNullOrEmpty(__tmp105Prefix))
                {
                    __out.Write(__tmp105Prefix);
                    __tmp106_outputWritten = true;
                }
                if (!__tmp107_last || !__tmp107_line.IsEmpty)
                {
                    __out.Write(__tmp107_line);
                    __tmp106_outputWritten = true;
                }
                if (!__tmp107_last) __out.AppendLine(true);
            }
            string __tmp108_line = ".initialized = true;"; //198:50
            if (!string.IsNullOrEmpty(__tmp108_line))
            {
                __out.Write(__tmp108_line);
                __tmp106_outputWritten = true;
            }
            if (__tmp106_outputWritten) __out.AppendLine(true);
            if (__tmp106_outputWritten)
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
            string __tmp16_line = ".ModelMetadata MMetadata;"; //214:30
            if (!string.IsNullOrEmpty(__tmp16_line))
            {
                __out.Write(__tmp16_line);
                __tmp13_outputWritten = true;
            }
            if (__tmp13_outputWritten) __out.AppendLine(true);
            if (__tmp13_outputWritten)
            {
                __out.AppendLine(false); //214:55
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
            if (!metaMetaModel && model.MModel.ModelGroup != null) //235:4
            {
                bool __tmp55_outputWritten = false;
                string __tmp56_line = "		this.MModelGroup = new "; //236:1
                if (!string.IsNullOrEmpty(__tmp56_line))
                {
                    __out.Write(__tmp56_line);
                    __tmp55_outputWritten = true;
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
                        __tmp55_outputWritten = true;
                    }
                    if (!__tmp57_last) __out.AppendLine(true);
                }
                string __tmp58_line = ".MutableModelGroup();"; //236:45
                if (!string.IsNullOrEmpty(__tmp58_line))
                {
                    __out.Write(__tmp58_line);
                    __tmp55_outputWritten = true;
                }
                if (__tmp55_outputWritten) __out.AppendLine(true);
                if (__tmp55_outputWritten)
                {
                    __out.AppendLine(false); //236:66
                }
                var __loop16_results = 
                    (from refModel in __Enumerate((model.MModel.ModelGroup.References).GetEnumerator()) //237:11
                    select new { refModel = refModel}
                    ).ToList(); //237:5
                for (int __loop16_iteration = 0; __loop16_iteration < __loop16_results.Count; ++__loop16_iteration)
                {
                    var __tmp59 = __loop16_results[__loop16_iteration];
                    var refModel = __tmp59.refModel;
                    bool __tmp61_outputWritten = false;
                    string __tmp62_line = "		this.MModelGroup.AddReference("; //238:1
                    if (!string.IsNullOrEmpty(__tmp62_line))
                    {
                        __out.Write(__tmp62_line);
                        __tmp61_outputWritten = true;
                    }
                    var __tmp63 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp63.Write(refModel.Metadata.NamespaceName);
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
                    string __tmp64_line = "."; //238:66
                    if (!string.IsNullOrEmpty(__tmp64_line))
                    {
                        __out.Write(__tmp64_line);
                        __tmp61_outputWritten = true;
                    }
                    var __tmp65 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp65.Write(refModel.Metadata.Name);
                    var __tmp65Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp65.ToStringAndFree());
                    bool __tmp65_last = __tmp65Reader.EndOfStream;
                    while(!__tmp65_last)
                    {
                        ReadOnlySpan<char> __tmp65_line = __tmp65Reader.ReadLine();
                        __tmp65_last = __tmp65Reader.EndOfStream;
                        if (!__tmp65_last || !__tmp65_line.IsEmpty)
                        {
                            __out.Write(__tmp65_line);
                            __tmp61_outputWritten = true;
                        }
                        if (!__tmp65_last) __out.AppendLine(true);
                    }
                    string __tmp66_line = "Instance.MModel);"; //238:91
                    if (!string.IsNullOrEmpty(__tmp66_line))
                    {
                        __out.Write(__tmp66_line);
                        __tmp61_outputWritten = true;
                    }
                    if (__tmp61_outputWritten) __out.AppendLine(true);
                    if (__tmp61_outputWritten)
                    {
                        __out.AppendLine(false); //238:108
                    }
                }
            }
            bool __tmp68_outputWritten = false;
            string __tmp69_line = "		this.MModel = "; //241:1
            if (!string.IsNullOrEmpty(__tmp69_line))
            {
                __out.Write(__tmp69_line);
                __tmp68_outputWritten = true;
            }
            if (metaMetaModel || model.MModel.ModelGroup == null) //241:18
            {
                string __tmp71_line = "new "; //241:72
                if (!string.IsNullOrEmpty(__tmp71_line))
                {
                    __out.Write(__tmp71_line);
                    __tmp68_outputWritten = true;
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
                        __tmp68_outputWritten = true;
                    }
                    if (!__tmp72_last) __out.AppendLine(true);
                }
                string __tmp73_line = ".MutableModel"; //241:95
                if (!string.IsNullOrEmpty(__tmp73_line))
                {
                    __out.Write(__tmp73_line);
                    __tmp68_outputWritten = true;
                }
            }
            else //241:109
            {
                string __tmp75_line = "this.MModelGroup.CreateModel"; //241:114
                if (!string.IsNullOrEmpty(__tmp75_line))
                {
                    __out.Write(__tmp75_line);
                    __tmp68_outputWritten = true;
                }
            }
            string __tmp77_line = "(namespaceName: \""; //241:150
            if (!string.IsNullOrEmpty(__tmp77_line))
            {
                __out.Write(__tmp77_line);
                __tmp68_outputWritten = true;
            }
            var __tmp78 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp78.Write(CSharpName(model.Namespace, NamespaceKind.Public, true));
            var __tmp78Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp78.ToStringAndFree());
            bool __tmp78_last = __tmp78Reader.EndOfStream;
            while(!__tmp78_last)
            {
                ReadOnlySpan<char> __tmp78_line = __tmp78Reader.ReadLine();
                __tmp78_last = __tmp78Reader.EndOfStream;
                if (!__tmp78_last || !__tmp78_line.IsEmpty)
                {
                    __out.Write(__tmp78_line);
                    __tmp68_outputWritten = true;
                }
                if (!__tmp78_last) __out.AppendLine(true);
            }
            string __tmp79_line = "\", name: \""; //241:223
            if (!string.IsNullOrEmpty(__tmp79_line))
            {
                __out.Write(__tmp79_line);
                __tmp68_outputWritten = true;
            }
            var __tmp80 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp80.Write(CSharpName(model));
            var __tmp80Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp80.ToStringAndFree());
            bool __tmp80_last = __tmp80Reader.EndOfStream;
            while(!__tmp80_last)
            {
                ReadOnlySpan<char> __tmp80_line = __tmp80Reader.ReadLine();
                __tmp80_last = __tmp80Reader.EndOfStream;
                if (!__tmp80_last || !__tmp80_line.IsEmpty)
                {
                    __out.Write(__tmp80_line);
                    __tmp68_outputWritten = true;
                }
                if (!__tmp80_last) __out.AppendLine(true);
            }
            string __tmp81_line = "\", version: new "; //241:253
            if (!string.IsNullOrEmpty(__tmp81_line))
            {
                __out.Write(__tmp81_line);
                __tmp68_outputWritten = true;
            }
            var __tmp82 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp82.Write(Properties.CoreNs);
            var __tmp82Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp82.ToStringAndFree());
            bool __tmp82_last = __tmp82Reader.EndOfStream;
            while(!__tmp82_last)
            {
                ReadOnlySpan<char> __tmp82_line = __tmp82Reader.ReadLine();
                __tmp82_last = __tmp82Reader.EndOfStream;
                if (!__tmp82_last || !__tmp82_line.IsEmpty)
                {
                    __out.Write(__tmp82_line);
                    __tmp68_outputWritten = true;
                }
                if (!__tmp82_last) __out.AppendLine(true);
            }
            string __tmp83_line = ".ModelVersion("; //241:288
            if (!string.IsNullOrEmpty(__tmp83_line))
            {
                __out.Write(__tmp83_line);
                __tmp68_outputWritten = true;
            }
            var __tmp84 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp84.Write(model.MajorVersion);
            var __tmp84Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp84.ToStringAndFree());
            bool __tmp84_last = __tmp84Reader.EndOfStream;
            while(!__tmp84_last)
            {
                ReadOnlySpan<char> __tmp84_line = __tmp84Reader.ReadLine();
                __tmp84_last = __tmp84Reader.EndOfStream;
                if (!__tmp84_last || !__tmp84_line.IsEmpty)
                {
                    __out.Write(__tmp84_line);
                    __tmp68_outputWritten = true;
                }
                if (!__tmp84_last) __out.AppendLine(true);
            }
            string __tmp85_line = ", "; //241:322
            if (!string.IsNullOrEmpty(__tmp85_line))
            {
                __out.Write(__tmp85_line);
                __tmp68_outputWritten = true;
            }
            var __tmp86 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp86.Write(model.MinorVersion);
            var __tmp86Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp86.ToStringAndFree());
            bool __tmp86_last = __tmp86Reader.EndOfStream;
            while(!__tmp86_last)
            {
                ReadOnlySpan<char> __tmp86_line = __tmp86Reader.ReadLine();
                __tmp86_last = __tmp86Reader.EndOfStream;
                if (!__tmp86_last || !__tmp86_line.IsEmpty)
                {
                    __out.Write(__tmp86_line);
                    __tmp68_outputWritten = true;
                }
                if (!__tmp86_last) __out.AppendLine(true);
            }
            string __tmp87_line = "), uri: \""; //241:344
            if (!string.IsNullOrEmpty(__tmp87_line))
            {
                __out.Write(__tmp87_line);
                __tmp68_outputWritten = true;
            }
            var __tmp88 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp88.Write(model.Uri);
            var __tmp88Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp88.ToStringAndFree());
            bool __tmp88_last = __tmp88Reader.EndOfStream;
            while(!__tmp88_last)
            {
                ReadOnlySpan<char> __tmp88_line = __tmp88Reader.ReadLine();
                __tmp88_last = __tmp88Reader.EndOfStream;
                if (!__tmp88_last || !__tmp88_line.IsEmpty)
                {
                    __out.Write(__tmp88_line);
                    __tmp68_outputWritten = true;
                }
                if (!__tmp88_last) __out.AppendLine(true);
            }
            string __tmp89_line = "\", prefix: \""; //241:364
            if (!string.IsNullOrEmpty(__tmp89_line))
            {
                __out.Write(__tmp89_line);
                __tmp68_outputWritten = true;
            }
            var __tmp90 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp90.Write(model.Prefix != null ? model.Prefix : CSharpName(model));
            var __tmp90Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp90.ToStringAndFree());
            bool __tmp90_last = __tmp90Reader.EndOfStream;
            while(!__tmp90_last)
            {
                ReadOnlySpan<char> __tmp90_line = __tmp90Reader.ReadLine();
                __tmp90_last = __tmp90Reader.EndOfStream;
                if (!__tmp90_last || !__tmp90_line.IsEmpty)
                {
                    __out.Write(__tmp90_line);
                    __tmp68_outputWritten = true;
                }
                if (!__tmp90_last) __out.AppendLine(true);
            }
            string __tmp91_line = "\", factoryConstructor: ("; //241:434
            if (!string.IsNullOrEmpty(__tmp91_line))
            {
                __out.Write(__tmp91_line);
                __tmp68_outputWritten = true;
            }
            var __tmp92 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp92.Write(Properties.CoreNs);
            var __tmp92Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp92.ToStringAndFree());
            bool __tmp92_last = __tmp92Reader.EndOfStream;
            while(!__tmp92_last)
            {
                ReadOnlySpan<char> __tmp92_line = __tmp92Reader.ReadLine();
                __tmp92_last = __tmp92Reader.EndOfStream;
                if (!__tmp92_last || !__tmp92_line.IsEmpty)
                {
                    __out.Write(__tmp92_line);
                    __tmp68_outputWritten = true;
                }
                if (!__tmp92_last) __out.AppendLine(true);
            }
            string __tmp93_line = ".MutableModel model, "; //241:477
            if (!string.IsNullOrEmpty(__tmp93_line))
            {
                __out.Write(__tmp93_line);
                __tmp68_outputWritten = true;
            }
            var __tmp94 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp94.Write(Properties.CoreNs);
            var __tmp94Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp94.ToStringAndFree());
            bool __tmp94_last = __tmp94Reader.EndOfStream;
            while(!__tmp94_last)
            {
                ReadOnlySpan<char> __tmp94_line = __tmp94Reader.ReadLine();
                __tmp94_last = __tmp94Reader.EndOfStream;
                if (!__tmp94_last || !__tmp94_line.IsEmpty)
                {
                    __out.Write(__tmp94_line);
                    __tmp68_outputWritten = true;
                }
                if (!__tmp94_last) __out.AppendLine(true);
            }
            string __tmp95_line = ".ModelFactoryFlags flags) => new "; //241:517
            if (!string.IsNullOrEmpty(__tmp95_line))
            {
                __out.Write(__tmp95_line);
                __tmp68_outputWritten = true;
            }
            var __tmp96 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp96.Write(CSharpName(model, ModelKind.Factory));
            var __tmp96Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp96.ToStringAndFree());
            bool __tmp96_last = __tmp96Reader.EndOfStream;
            while(!__tmp96_last)
            {
                ReadOnlySpan<char> __tmp96_line = __tmp96Reader.ReadLine();
                __tmp96_last = __tmp96Reader.EndOfStream;
                if (!__tmp96_last || !__tmp96_line.IsEmpty)
                {
                    __out.Write(__tmp96_line);
                    __tmp68_outputWritten = true;
                }
                if (!__tmp96_last) __out.AppendLine(true);
            }
            string __tmp97_line = "(model, flags));"; //241:587
            if (!string.IsNullOrEmpty(__tmp97_line))
            {
                __out.Write(__tmp97_line);
                __tmp68_outputWritten = true;
            }
            if (__tmp68_outputWritten) __out.AppendLine(true);
            if (__tmp68_outputWritten)
            {
                __out.AppendLine(false); //241:603
            }
            __out.Write("		this.MMetadata = this.MModel.Metadata;"); //242:1
            __out.AppendLine(false); //242:41
            __out.Write("	}"); //243:1
            __out.AppendLine(false); //243:3
            __out.AppendLine(true); //244:1
            __out.Write("	internal void Create()"); //245:1
            __out.AppendLine(false); //245:24
            __out.Write("	{"); //246:1
            __out.AppendLine(false); //246:3
            __out.Write("		lock (this)"); //247:1
            __out.AppendLine(false); //247:14
            __out.Write("		{"); //248:1
            __out.AppendLine(false); //248:4
            __out.Write("			if (this.creating || this.created) return;"); //249:1
            __out.AppendLine(false); //249:46
            __out.Write("			this.creating = true;"); //250:1
            __out.AppendLine(false); //250:25
            __out.Write("		}"); //251:1
            __out.AppendLine(false); //251:4
            __out.Write("		this.CreateInstances();"); //252:1
            __out.AppendLine(false); //252:26
            bool __tmp99_outputWritten = false;
            string __tmp98Prefix = "		"; //253:1
            var __tmp100 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp100.Write(CSharpName(model, ModelKind.ImplementationProvider));
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
            string __tmp101_line = ".Implementation."; //253:55
            if (!string.IsNullOrEmpty(__tmp101_line))
            {
                __out.Write(__tmp101_line);
                __tmp99_outputWritten = true;
            }
            var __tmp102 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp102.Write(CSharpName(model, ModelKind.BuilderInstance));
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
            string __tmp103_line = "(this);"; //253:116
            if (!string.IsNullOrEmpty(__tmp103_line))
            {
                __out.Write(__tmp103_line);
                __tmp99_outputWritten = true;
            }
            if (__tmp99_outputWritten) __out.AppendLine(true);
            if (__tmp99_outputWritten)
            {
                __out.AppendLine(false); //253:123
            }
            __out.Write("        foreach (global::MetaDslx.Modeling.MutableObject obj in this.MModel.Objects)"); //254:1
            __out.AppendLine(false); //254:85
            __out.Write("        {"); //255:1
            __out.AppendLine(false); //255:10
            __out.Write("            obj.MMakeCreated();"); //256:1
            __out.AppendLine(false); //256:32
            __out.Write("        }"); //257:1
            __out.AppendLine(false); //257:10
            __out.Write("		lock (this)"); //258:1
            __out.AppendLine(false); //258:14
            __out.Write("		{"); //259:1
            __out.AppendLine(false); //259:4
            __out.Write("			this.created = true;"); //260:1
            __out.AppendLine(false); //260:24
            __out.Write("		}"); //261:1
            __out.AppendLine(false); //261:4
            __out.Write("	}"); //262:1
            __out.AppendLine(false); //262:3
            __out.AppendLine(true); //263:1
            __out.Write("	internal void EvaluateLazyValues()"); //264:1
            __out.AppendLine(false); //264:36
            __out.Write("	{"); //265:1
            __out.AppendLine(false); //265:3
            __out.Write("		if (!this.created) return;"); //266:1
            __out.AppendLine(false); //266:29
            __out.Write("		this.MModel.EvaluateLazyValues();"); //267:1
            __out.AppendLine(false); //267:36
            __out.Write("	}"); //268:1
            __out.AppendLine(false); //268:3
            __out.AppendLine(true); //269:1
            __out.Write("	private void CreateInstances()"); //270:1
            __out.AppendLine(false); //270:32
            __out.Write("	{"); //271:1
            __out.AppendLine(false); //271:3
            bool __tmp105_outputWritten = false;
            string __tmp104Prefix = "		"; //272:1
            var __tmp106 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp106.Write(Properties.MetaNs);
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
            string __tmp107_line = ".MetaFactory factory = new "; //272:22
            if (!string.IsNullOrEmpty(__tmp107_line))
            {
                __out.Write(__tmp107_line);
                __tmp105_outputWritten = true;
            }
            var __tmp108 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp108.Write(Properties.MetaNs);
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
            string __tmp109_line = ".MetaFactory(this.MModel, "; //272:68
            if (!string.IsNullOrEmpty(__tmp109_line))
            {
                __out.Write(__tmp109_line);
                __tmp105_outputWritten = true;
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
                    __tmp105_outputWritten = true;
                }
                if (!__tmp110_last) __out.AppendLine(true);
            }
            string __tmp111_line = ".ModelFactoryFlags.DontMakeObjectsCreated);"; //272:113
            if (!string.IsNullOrEmpty(__tmp111_line))
            {
                __out.Write(__tmp111_line);
                __tmp105_outputWritten = true;
            }
            if (__tmp105_outputWritten) __out.AppendLine(true);
            if (__tmp105_outputWritten)
            {
                __out.AppendLine(false); //272:156
            }
            if (!metaMetaModel) //273:4
            {
                bool __tmp113_outputWritten = false;
                string __tmp112Prefix = "		"; //274:1
                var __tmp114 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp114.Write(CSharpName(model, ModelKind.Factory));
                var __tmp114Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp114.ToStringAndFree());
                bool __tmp114_last = __tmp114Reader.EndOfStream;
                while(!__tmp114_last)
                {
                    ReadOnlySpan<char> __tmp114_line = __tmp114Reader.ReadLine();
                    __tmp114_last = __tmp114Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp112Prefix))
                    {
                        __out.Write(__tmp112Prefix);
                        __tmp113_outputWritten = true;
                    }
                    if (!__tmp114_last || !__tmp114_line.IsEmpty)
                    {
                        __out.Write(__tmp114_line);
                        __tmp113_outputWritten = true;
                    }
                    if (!__tmp114_last) __out.AppendLine(true);
                }
                string __tmp115_line = " constantFactory = new "; //274:40
                if (!string.IsNullOrEmpty(__tmp115_line))
                {
                    __out.Write(__tmp115_line);
                    __tmp113_outputWritten = true;
                }
                var __tmp116 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp116.Write(CSharpName(model, ModelKind.Factory));
                var __tmp116Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp116.ToStringAndFree());
                bool __tmp116_last = __tmp116Reader.EndOfStream;
                while(!__tmp116_last)
                {
                    ReadOnlySpan<char> __tmp116_line = __tmp116Reader.ReadLine();
                    __tmp116_last = __tmp116Reader.EndOfStream;
                    if (!__tmp116_last || !__tmp116_line.IsEmpty)
                    {
                        __out.Write(__tmp116_line);
                        __tmp113_outputWritten = true;
                    }
                    if (!__tmp116_last) __out.AppendLine(true);
                }
                string __tmp117_line = "(this.MModel, global::MetaDslx.Modeling.ModelFactoryFlags.DontMakeObjectsCreated);"; //274:100
                if (!string.IsNullOrEmpty(__tmp117_line))
                {
                    __out.Write(__tmp117_line);
                    __tmp113_outputWritten = true;
                }
                if (__tmp113_outputWritten) __out.AppendLine(true);
                if (__tmp113_outputWritten)
                {
                    __out.AppendLine(false); //274:182
                }
            }
            __out.AppendLine(true); //276:1
            var __loop17_results = 
                (from __loop17_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //277:9
                from cst in __Enumerate((__loop17_var1).GetEnumerator()).OfType<MetaConstant>() //277:39
                select new { __loop17_var1 = __loop17_var1, cst = cst}
                ).ToList(); //277:4
            for (int __loop17_iteration = 0; __loop17_iteration < __loop17_results.Count; ++__loop17_iteration)
            {
                var __tmp118 = __loop17_results[__loop17_iteration];
                var __loop17_var1 = __tmp118.__loop17_var1;
                var cst = __tmp118.cst;
                if (metaMetaModel) //278:5
                {
                    bool __tmp120_outputWritten = false;
                    string __tmp119Prefix = "		"; //279:1
                    var __tmp121 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp121.Write(CSharpName(cst, model, ClassKind.BuilderInstance));
                    var __tmp121Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp121.ToStringAndFree());
                    bool __tmp121_last = __tmp121Reader.EndOfStream;
                    while(!__tmp121_last)
                    {
                        ReadOnlySpan<char> __tmp121_line = __tmp121Reader.ReadLine();
                        __tmp121_last = __tmp121Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp119Prefix))
                        {
                            __out.Write(__tmp119Prefix);
                            __tmp120_outputWritten = true;
                        }
                        if (!__tmp121_last || !__tmp121_line.IsEmpty)
                        {
                            __out.Write(__tmp121_line);
                            __tmp120_outputWritten = true;
                        }
                        if (!__tmp121_last) __out.AppendLine(true);
                    }
                    string __tmp122_line = " = factory."; //279:53
                    if (!string.IsNullOrEmpty(__tmp122_line))
                    {
                        __out.Write(__tmp122_line);
                        __tmp120_outputWritten = true;
                    }
                    var __tmp123 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp123.Write(CSharpName(cst.Type, model, ClassKind.Immutable));
                    var __tmp123Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp123.ToStringAndFree());
                    bool __tmp123_last = __tmp123Reader.EndOfStream;
                    while(!__tmp123_last)
                    {
                        ReadOnlySpan<char> __tmp123_line = __tmp123Reader.ReadLine();
                        __tmp123_last = __tmp123Reader.EndOfStream;
                        if (!__tmp123_last || !__tmp123_line.IsEmpty)
                        {
                            __out.Write(__tmp123_line);
                            __tmp120_outputWritten = true;
                        }
                        if (!__tmp123_last) __out.AppendLine(true);
                    }
                    string __tmp124_line = "();"; //279:113
                    if (!string.IsNullOrEmpty(__tmp124_line))
                    {
                        __out.Write(__tmp124_line);
                        __tmp120_outputWritten = true;
                    }
                    if (__tmp120_outputWritten) __out.AppendLine(true);
                    if (__tmp120_outputWritten)
                    {
                        __out.AppendLine(false); //279:116
                    }
                }
                else //280:5
                {
                    bool __tmp126_outputWritten = false;
                    string __tmp125Prefix = "		"; //281:1
                    var __tmp127 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp127.Write(CSharpName(cst, model, ClassKind.BuilderInstance));
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
                    string __tmp128_line = " = constantFactory."; //281:53
                    if (!string.IsNullOrEmpty(__tmp128_line))
                    {
                        __out.Write(__tmp128_line);
                        __tmp126_outputWritten = true;
                    }
                    var __tmp129 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp129.Write(CSharpName(cst.Type, model, ClassKind.Immutable));
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
                    string __tmp130_line = "();"; //281:121
                    if (!string.IsNullOrEmpty(__tmp130_line))
                    {
                        __out.Write(__tmp130_line);
                        __tmp126_outputWritten = true;
                    }
                    if (__tmp126_outputWritten) __out.AppendLine(true);
                    if (__tmp126_outputWritten)
                    {
                        __out.AppendLine(false); //281:124
                    }
                }
                bool __tmp132_outputWritten = false;
                string __tmp131Prefix = "		"; //283:1
                var __tmp133 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp133.Write(CSharpName(cst, model, ClassKind.BuilderInstance));
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
                string __tmp134_line = ".MName = \""; //283:53
                if (!string.IsNullOrEmpty(__tmp134_line))
                {
                    __out.Write(__tmp134_line);
                    __tmp132_outputWritten = true;
                }
                var __tmp135 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp135.Write(cst.Name);
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
                string __tmp136_line = "\";"; //283:73
                if (!string.IsNullOrEmpty(__tmp136_line))
                {
                    __out.Write(__tmp136_line);
                    __tmp132_outputWritten = true;
                }
                if (__tmp132_outputWritten) __out.AppendLine(true);
                if (__tmp132_outputWritten)
                {
                    __out.AppendLine(false); //283:75
                }
            }
            __out.AppendLine(true); //285:1
            var __loop18_results = 
                (from obj in __Enumerate((instances).GetEnumerator()) //286:9
                select new { obj = obj}
                ).ToList(); //286:4
            for (int __loop18_iteration = 0; __loop18_iteration < __loop18_results.Count; ++__loop18_iteration)
            {
                var __tmp137 = __loop18_results[__loop18_iteration];
                var obj = __tmp137.obj;
                bool __tmp139_outputWritten = false;
                string __tmp138Prefix = "		"; //287:1
                var __tmp140 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp140.Write(GenerateInstance(model, metaMetaModel, obj, instanceNames));
                var __tmp140Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp140.ToStringAndFree());
                bool __tmp140_last = __tmp140Reader.EndOfStream;
                while(!__tmp140_last)
                {
                    ReadOnlySpan<char> __tmp140_line = __tmp140Reader.ReadLine();
                    __tmp140_last = __tmp140Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp138Prefix))
                    {
                        __out.Write(__tmp138Prefix);
                        __tmp139_outputWritten = true;
                    }
                    if (!__tmp140_last || !__tmp140_line.IsEmpty)
                    {
                        __out.Write(__tmp140_line);
                        __tmp139_outputWritten = true;
                    }
                    if (!__tmp140_last || __tmp139_outputWritten) __out.AppendLine(true);
                }
                if (__tmp139_outputWritten)
                {
                    __out.AppendLine(false); //287:63
                }
            }
            __out.AppendLine(true); //289:1
            var __loop19_results = 
                (from obj in __Enumerate((instances).GetEnumerator()) //290:9
                select new { obj = obj}
                ).ToList(); //290:4
            for (int __loop19_iteration = 0; __loop19_iteration < __loop19_results.Count; ++__loop19_iteration)
            {
                var __tmp141 = __loop19_results[__loop19_iteration];
                var obj = __tmp141.obj;
                bool __tmp143_outputWritten = false;
                string __tmp142Prefix = "		"; //291:1
                var __tmp144 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp144.Write(GenerateInstanceProperties(model, metaMetaModel, obj, instanceNames));
                var __tmp144Reader = new global::MetaDslx.CodeGeneration.CodeReader(__tmp144.ToStringAndFree());
                bool __tmp144_last = __tmp144Reader.EndOfStream;
                while(!__tmp144_last)
                {
                    ReadOnlySpan<char> __tmp144_line = __tmp144Reader.ReadLine();
                    __tmp144_last = __tmp144Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp142Prefix))
                    {
                        __out.Write(__tmp142Prefix);
                        __tmp143_outputWritten = true;
                    }
                    if (!__tmp144_last || !__tmp144_line.IsEmpty)
                    {
                        __out.Write(__tmp144_line);
                        __tmp143_outputWritten = true;
                    }
                    if (!__tmp144_last || __tmp143_outputWritten) __out.AppendLine(true);
                }
                if (__tmp143_outputWritten)
                {
                    __out.AppendLine(false); //291:73
                }
            }
            __out.Write("	}"); //293:1
            __out.AppendLine(false); //293:3
            __out.Write("}"); //294:1
            __out.AppendLine(false); //294:2
            return __out.ToStringAndFree();
        }

        public string GenerateInstanceDeclaration(MetaModel model, bool metaMetaModel, ImmutableObject obj, ImmutableDictionary<ImmutableObject,string> instanceNames) //297:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            if (obj != null && obj.MMetaClass != null && instanceNames.ContainsKey(obj)) //298:2
            {
                string name = instanceNames[obj]; //299:3
                if (metaMetaModel) //300:3
                {
                    if (name.StartsWith("__")) //301:4
                    {
                        bool __tmp2_outputWritten = false;
                        string __tmp3_line = "private "; //302:1
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
                        string __tmp5_line = " "; //302:62
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
                        string __tmp7_line = ";"; //302:69
                        if (!string.IsNullOrEmpty(__tmp7_line))
                        {
                            __out.Write(__tmp7_line);
                            __tmp2_outputWritten = true;
                        }
                        if (__tmp2_outputWritten) __out.AppendLine(true);
                        if (__tmp2_outputWritten)
                        {
                            __out.AppendLine(false); //302:70
                        }
                    }
                    else //303:4
                    {
                        bool __tmp9_outputWritten = false;
                        string __tmp10_line = "internal "; //304:1
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
                        string __tmp12_line = " "; //304:63
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
                        string __tmp14_line = ";"; //304:70
                        if (!string.IsNullOrEmpty(__tmp14_line))
                        {
                            __out.Write(__tmp14_line);
                            __tmp9_outputWritten = true;
                        }
                        if (__tmp9_outputWritten) __out.AppendLine(true);
                        if (__tmp9_outputWritten)
                        {
                            __out.AppendLine(false); //304:71
                        }
                    }
                }
                else //306:3
                {
                    if (name.StartsWith("__")) //307:4
                    {
                        bool __tmp16_outputWritten = false;
                        string __tmp17_line = "private "; //308:1
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
                        string __tmp19_line = " "; //308:68
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
                        string __tmp21_line = ";"; //308:75
                        if (!string.IsNullOrEmpty(__tmp21_line))
                        {
                            __out.Write(__tmp21_line);
                            __tmp16_outputWritten = true;
                        }
                        if (__tmp16_outputWritten) __out.AppendLine(true);
                        if (__tmp16_outputWritten)
                        {
                            __out.AppendLine(false); //308:76
                        }
                    }
                    else //309:4
                    {
                        bool __tmp23_outputWritten = false;
                        string __tmp24_line = "internal "; //310:1
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
                        string __tmp26_line = " "; //310:69
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
                        string __tmp28_line = ";"; //310:76
                        if (!string.IsNullOrEmpty(__tmp28_line))
                        {
                            __out.Write(__tmp28_line);
                            __tmp23_outputWritten = true;
                        }
                        if (__tmp23_outputWritten) __out.AppendLine(true);
                        if (__tmp23_outputWritten)
                        {
                            __out.AppendLine(false); //310:77
                        }
                    }
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateInstance(MetaModel model, bool metaMetaModel, ImmutableObject obj, ImmutableDictionary<ImmutableObject,string> instanceNames) //316:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            if (obj != null && obj.MMetaClass != null && instanceNames.ContainsKey(obj)) //317:2
            {
                string name = instanceNames[obj]; //318:3
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
                string __tmp4_line = " = factory."; //319:7
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
                string __tmp6_line = "();"; //319:73
                if (!string.IsNullOrEmpty(__tmp6_line))
                {
                    __out.Write(__tmp6_line);
                    __tmp2_outputWritten = true;
                }
                if (__tmp2_outputWritten) __out.AppendLine(true);
                if (__tmp2_outputWritten)
                {
                    __out.AppendLine(false); //319:76
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateInstanceProperties(MetaModel model, bool metaMetaModel, ImmutableObject obj, ImmutableDictionary<ImmutableObject,string> instanceNames) //323:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            if (obj != null && obj.MMetaClass != null && instanceNames.ContainsKey(obj)) //324:2
            {
                var __loop20_results = 
                    (from __loop20_var1 in __Enumerate((obj).GetEnumerator()) //325:8
                    from prop in __Enumerate((__loop20_var1.MProperties).GetEnumerator()) //325:13
                    where !prop.IsDerived && !prop.IsDerivedUnion //325:30
                    select new { __loop20_var1 = __loop20_var1, prop = prop}
                    ).ToList(); //325:3
                for (int __loop20_iteration = 0; __loop20_iteration < __loop20_results.Count; ++__loop20_iteration)
                {
                    var __tmp1 = __loop20_results[__loop20_iteration];
                    var __loop20_var1 = __tmp1.__loop20_var1;
                    var prop = __tmp1.prop;
                    if (obj is MetaConstant && prop.Name == "Value") //326:4
                    {
                        string name = instanceNames[obj]; //327:5
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
                        string __tmp5_line = ".SetValueLazy(() => "; //328:7
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
                        string __tmp7_line = ");"; //328:93
                        if (!string.IsNullOrEmpty(__tmp7_line))
                        {
                            __out.Write(__tmp7_line);
                            __tmp3_outputWritten = true;
                        }
                        if (__tmp3_outputWritten) __out.AppendLine(true);
                        if (__tmp3_outputWritten)
                        {
                            __out.AppendLine(false); //328:95
                        }
                    }
                    else //329:4
                    {
                        object propValue = obj.MGet(prop); //330:5
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
                            __out.AppendLine(false); //331:91
                        }
                    }
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateInstancePropertyValue(MetaModel model, bool metaMetaModel, ImmutableObject obj, ModelProperty prop, object value, ImmutableDictionary<ImmutableObject,string> instanceNames) //337:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string name = instanceNames[obj]; //338:2
            ImmutableObject valueObject = value as ImmutableObject; //339:2
            MetaDeclaration valueDecl = value as MetaDeclaration; //340:2
            IEnumerable<object> valueCollection = value as IEnumerable<object>; //341:2
            if (value == null) //342:2
            {
                if (prop.MutableType != null && prop.MutableType.IsClass) //343:3
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
                    string __tmp4_line = "."; //344:7
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
                    string __tmp6_line = " = null;"; //344:19
                    if (!string.IsNullOrEmpty(__tmp6_line))
                    {
                        __out.Write(__tmp6_line);
                        __tmp2_outputWritten = true;
                    }
                    if (__tmp2_outputWritten) __out.AppendLine(true);
                    if (__tmp2_outputWritten)
                    {
                        __out.AppendLine(false); //344:27
                    }
                }
                else //345:3
                {
                    bool __tmp8_outputWritten = false;
                    string __tmp9_line = "// "; //346:1
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
                    string __tmp11_line = "."; //346:10
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
                    string __tmp13_line = " = null;"; //346:22
                    if (!string.IsNullOrEmpty(__tmp13_line))
                    {
                        __out.Write(__tmp13_line);
                        __tmp8_outputWritten = true;
                    }
                    if (__tmp8_outputWritten) __out.AppendLine(true);
                    if (__tmp8_outputWritten)
                    {
                        __out.AppendLine(false); //346:30
                    }
                }
            }
            else if (value is string) //348:2
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
                string __tmp17_line = "."; //349:7
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
                string __tmp19_line = " = \""; //349:19
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
                string __tmp21_line = "\";"; //349:50
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Write(__tmp21_line);
                    __tmp15_outputWritten = true;
                }
                if (__tmp15_outputWritten) __out.AppendLine(true);
                if (__tmp15_outputWritten)
                {
                    __out.AppendLine(false); //349:52
                }
            }
            else if (value is bool) //350:2
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
                string __tmp25_line = "."; //351:7
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
                string __tmp27_line = " = "; //351:19
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
                string __tmp29_line = ";"; //351:50
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Write(__tmp29_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //351:51
                }
            }
            else if (value.GetType().IsPrimitive) //352:2
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
                string __tmp33_line = "."; //353:7
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
                string __tmp35_line = " = "; //353:19
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
                string __tmp37_line = ";"; //353:40
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Write(__tmp37_line);
                    __tmp31_outputWritten = true;
                }
                if (__tmp31_outputWritten) __out.AppendLine(true);
                if (__tmp31_outputWritten)
                {
                    __out.AppendLine(false); //353:41
                }
            }
            else if (value is MetaAttribute) //354:2
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
                string __tmp41_line = "."; //355:7
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
                string __tmp43_line = " = "; //355:19
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
                string __tmp45_line = ";"; //355:72
                if (!string.IsNullOrEmpty(__tmp45_line))
                {
                    __out.Write(__tmp45_line);
                    __tmp39_outputWritten = true;
                }
                if (__tmp39_outputWritten) __out.AppendLine(true);
                if (__tmp39_outputWritten)
                {
                    __out.AppendLine(false); //355:73
                }
            }
            else if (value is Enum) //356:2
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
                string __tmp49_line = "."; //357:7
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
                string __tmp51_line = " = "; //357:19
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
                string __tmp53_line = ";"; //357:58
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Write(__tmp53_line);
                    __tmp47_outputWritten = true;
                }
                if (__tmp47_outputWritten) __out.AppendLine(true);
                if (__tmp47_outputWritten)
                {
                    __out.AppendLine(false); //357:59
                }
            }
            else if (value is Type) //358:2
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
                string __tmp57_line = "."; //359:7
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
                string __tmp59_line = " = typeof("; //359:19
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
                string __tmp61_line = ");"; //359:53
                if (!string.IsNullOrEmpty(__tmp61_line))
                {
                    __out.Write(__tmp61_line);
                    __tmp55_outputWritten = true;
                }
                if (__tmp55_outputWritten) __out.AppendLine(true);
                if (__tmp55_outputWritten)
                {
                    __out.AppendLine(false); //359:55
                }
            }
            else if (value is MetaExternalType) //360:2
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
                string __tmp65_line = ".Set"; //361:7
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
                string __tmp67_line = "Lazy(() => "; //361:22
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
                string __tmp69_line = ");"; //361:80
                if (!string.IsNullOrEmpty(__tmp69_line))
                {
                    __out.Write(__tmp69_line);
                    __tmp63_outputWritten = true;
                }
                if (__tmp63_outputWritten) __out.AppendLine(true);
                if (__tmp63_outputWritten)
                {
                    __out.AppendLine(false); //361:82
                }
            }
            else if (value is MetaPrimitiveType) //362:2
            {
                if (metaMetaModel) //363:3
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
                    string __tmp73_line = ".Set"; //364:7
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
                    string __tmp75_line = "Lazy(() => "; //364:22
                    if (!string.IsNullOrEmpty(__tmp75_line))
                    {
                        __out.Write(__tmp75_line);
                        __tmp71_outputWritten = true;
                    }
                    var __tmp76 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp76.Write(CSharpName(((MetaPrimitiveType)value), model, ClassKind.BuilderInstance, false));
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
                    string __tmp77_line = ");"; //364:113
                    if (!string.IsNullOrEmpty(__tmp77_line))
                    {
                        __out.Write(__tmp77_line);
                        __tmp71_outputWritten = true;
                    }
                    if (__tmp71_outputWritten) __out.AppendLine(true);
                    if (__tmp71_outputWritten)
                    {
                        __out.AppendLine(false); //364:115
                    }
                }
                else //365:3
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
                    string __tmp81_line = ".Set"; //366:7
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
                    string __tmp83_line = "Lazy(() => "; //366:22
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
                    string __tmp85_line = ".ToMutable());"; //366:114
                    if (!string.IsNullOrEmpty(__tmp85_line))
                    {
                        __out.Write(__tmp85_line);
                        __tmp79_outputWritten = true;
                    }
                    if (__tmp79_outputWritten) __out.AppendLine(true);
                    if (__tmp79_outputWritten)
                    {
                        __out.AppendLine(false); //366:128
                    }
                }
            }
            else if (valueDecl != null && valueDecl is MetaConstant) //368:2
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
                string __tmp89_line = ".Set"; //369:7
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
                string __tmp91_line = "Lazy(() => "; //369:22
                if (!string.IsNullOrEmpty(__tmp91_line))
                {
                    __out.Write(__tmp91_line);
                    __tmp87_outputWritten = true;
                }
                var __tmp92 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp92.Write(CSharpName(((MetaConstant)valueDecl), model, ClassKind.BuilderInstance, false));
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
                string __tmp93_line = ");"; //369:112
                if (!string.IsNullOrEmpty(__tmp93_line))
                {
                    __out.Write(__tmp93_line);
                    __tmp87_outputWritten = true;
                }
                if (__tmp87_outputWritten) __out.AppendLine(true);
                if (__tmp87_outputWritten)
                {
                    __out.AppendLine(false); //369:114
                }
            }
            else if (valueObject != null && instanceNames.ContainsKey(valueObject)) //370:2
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
                string __tmp97_line = ".Set"; //371:7
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
                string __tmp99_line = "Lazy(() => "; //371:22
                if (!string.IsNullOrEmpty(__tmp99_line))
                {
                    __out.Write(__tmp99_line);
                    __tmp95_outputWritten = true;
                }
                var __tmp100 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp100.Write(instanceNames[valueObject]);
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
                string __tmp101_line = ");"; //371:61
                if (!string.IsNullOrEmpty(__tmp101_line))
                {
                    __out.Write(__tmp101_line);
                    __tmp95_outputWritten = true;
                }
                if (__tmp95_outputWritten) __out.AppendLine(true);
                if (__tmp95_outputWritten)
                {
                    __out.AppendLine(false); //371:63
                }
            }
            else if (valueDecl != null && valueDecl is MetaType) //372:2
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
                string __tmp105_line = ".Set"; //373:7
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
                string __tmp107_line = "Lazy(() => "; //373:22
                if (!string.IsNullOrEmpty(__tmp107_line))
                {
                    __out.Write(__tmp107_line);
                    __tmp103_outputWritten = true;
                }
                var __tmp108 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp108.Write(CSharpName(((MetaType)valueDecl), model, ClassKind.ImmutableInstance, true));
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
                string __tmp109_line = ");"; //373:109
                if (!string.IsNullOrEmpty(__tmp109_line))
                {
                    __out.Write(__tmp109_line);
                    __tmp103_outputWritten = true;
                }
                if (__tmp103_outputWritten) __out.AppendLine(true);
                if (__tmp103_outputWritten)
                {
                    __out.AppendLine(false); //373:111
                }
            }
            else if (valueCollection != null) //374:2
            {
                var __loop21_results = 
                    (from cvalue in __Enumerate((valueCollection).GetEnumerator()) //375:8
                    select new { cvalue = cvalue}
                    ).ToList(); //375:3
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
                        __out.AppendLine(false); //376:98
                    }
                }
            }
            else //378:2
            {
                bool __tmp115_outputWritten = false;
                string __tmp116_line = "// TODO: "; //379:1
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
                string __tmp118_line = "."; //379:16
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
                    __out.AppendLine(false); //379:28
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateInstancePropertyCollectionValue(MetaModel model, bool metaMetaModel, ImmutableObject obj, ModelProperty prop, object value, ImmutableDictionary<ImmutableObject,string> instanceNames) //383:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string name = instanceNames[obj]; //384:2
            ImmutableObject valueObject = value as ImmutableObject; //385:2
            MetaDeclaration valueDecl = value as MetaDeclaration; //386:2
            IEnumerable<object> valueCollection = value as IEnumerable<object>; //387:2
            if (value == null) //388:2
            {
                if (prop.MutableType != null && prop.MutableType.IsClass) //389:3
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
                    string __tmp4_line = "."; //390:7
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
                    string __tmp6_line = ".Add(null);"; //390:19
                    if (!string.IsNullOrEmpty(__tmp6_line))
                    {
                        __out.Write(__tmp6_line);
                        __tmp2_outputWritten = true;
                    }
                    if (__tmp2_outputWritten) __out.AppendLine(true);
                    if (__tmp2_outputWritten)
                    {
                        __out.AppendLine(false); //390:30
                    }
                }
                else //391:3
                {
                    bool __tmp8_outputWritten = false;
                    string __tmp9_line = "// "; //392:1
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
                    string __tmp11_line = "."; //392:10
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
                    string __tmp13_line = ".Add(null);"; //392:22
                    if (!string.IsNullOrEmpty(__tmp13_line))
                    {
                        __out.Write(__tmp13_line);
                        __tmp8_outputWritten = true;
                    }
                    if (__tmp8_outputWritten) __out.AppendLine(true);
                    if (__tmp8_outputWritten)
                    {
                        __out.AppendLine(false); //392:33
                    }
                }
            }
            else if (value is string) //394:2
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
                string __tmp17_line = "."; //395:7
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
                string __tmp19_line = ".Add(\""; //395:19
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
                string __tmp21_line = "\");"; //395:52
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Write(__tmp21_line);
                    __tmp15_outputWritten = true;
                }
                if (__tmp15_outputWritten) __out.AppendLine(true);
                if (__tmp15_outputWritten)
                {
                    __out.AppendLine(false); //395:55
                }
            }
            else if (value is bool) //396:2
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
                string __tmp25_line = "."; //397:7
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
                string __tmp27_line = ".Add("; //397:19
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
                string __tmp29_line = ");"; //397:52
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Write(__tmp29_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //397:54
                }
            }
            else if (value.GetType().IsPrimitive) //398:2
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
                string __tmp33_line = "."; //399:7
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
                string __tmp35_line = ".Add("; //399:19
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
                string __tmp37_line = ");"; //399:42
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Write(__tmp37_line);
                    __tmp31_outputWritten = true;
                }
                if (__tmp31_outputWritten) __out.AppendLine(true);
                if (__tmp31_outputWritten)
                {
                    __out.AppendLine(false); //399:44
                }
            }
            else if (value is MetaAttribute) //400:2
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
                string __tmp41_line = "."; //401:7
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
                string __tmp43_line = ".Add("; //401:19
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
                string __tmp45_line = ");"; //401:74
                if (!string.IsNullOrEmpty(__tmp45_line))
                {
                    __out.Write(__tmp45_line);
                    __tmp39_outputWritten = true;
                }
                if (__tmp39_outputWritten) __out.AppendLine(true);
                if (__tmp39_outputWritten)
                {
                    __out.AppendLine(false); //401:76
                }
            }
            else if (value is Enum) //402:2
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
                string __tmp49_line = "."; //403:7
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
                string __tmp51_line = ".Add("; //403:19
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
                string __tmp53_line = ");"; //403:60
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Write(__tmp53_line);
                    __tmp47_outputWritten = true;
                }
                if (__tmp47_outputWritten) __out.AppendLine(true);
                if (__tmp47_outputWritten)
                {
                    __out.AppendLine(false); //403:62
                }
            }
            else if (value is Type) //404:2
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
                string __tmp57_line = "."; //405:7
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
                string __tmp59_line = " = typeof("; //405:19
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
                string __tmp61_line = ");"; //405:53
                if (!string.IsNullOrEmpty(__tmp61_line))
                {
                    __out.Write(__tmp61_line);
                    __tmp55_outputWritten = true;
                }
                if (__tmp55_outputWritten) __out.AppendLine(true);
                if (__tmp55_outputWritten)
                {
                    __out.AppendLine(false); //405:55
                }
            }
            else if (value is MetaExternalType) //406:2
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
                string __tmp65_line = "."; //407:7
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
                string __tmp67_line = ".AddLazy(() => "; //407:19
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
                string __tmp69_line = ");"; //407:81
                if (!string.IsNullOrEmpty(__tmp69_line))
                {
                    __out.Write(__tmp69_line);
                    __tmp63_outputWritten = true;
                }
                if (__tmp63_outputWritten) __out.AppendLine(true);
                if (__tmp63_outputWritten)
                {
                    __out.AppendLine(false); //407:83
                }
            }
            else if (value is MetaPrimitiveType) //408:2
            {
                if (metaMetaModel) //409:3
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
                    string __tmp73_line = "."; //410:7
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
                    string __tmp75_line = ".AddLazy(() => "; //410:19
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
                    string __tmp77_line = ");"; //410:116
                    if (!string.IsNullOrEmpty(__tmp77_line))
                    {
                        __out.Write(__tmp77_line);
                        __tmp71_outputWritten = true;
                    }
                    if (__tmp71_outputWritten) __out.AppendLine(true);
                    if (__tmp71_outputWritten)
                    {
                        __out.AppendLine(false); //410:118
                    }
                }
                else //411:3
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
                    string __tmp81_line = "."; //412:7
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
                    string __tmp83_line = ".AddLazy(() => "; //412:19
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
                    string __tmp85_line = ".ToMutable());"; //412:115
                    if (!string.IsNullOrEmpty(__tmp85_line))
                    {
                        __out.Write(__tmp85_line);
                        __tmp79_outputWritten = true;
                    }
                    if (__tmp79_outputWritten) __out.AppendLine(true);
                    if (__tmp79_outputWritten)
                    {
                        __out.AppendLine(false); //412:129
                    }
                }
            }
            else if (valueObject != null && instanceNames.ContainsKey(valueObject)) //414:2
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
                string __tmp89_line = "."; //415:7
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
                string __tmp91_line = ".AddLazy(() => "; //415:19
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
                string __tmp93_line = ");"; //415:62
                if (!string.IsNullOrEmpty(__tmp93_line))
                {
                    __out.Write(__tmp93_line);
                    __tmp87_outputWritten = true;
                }
                if (__tmp87_outputWritten) __out.AppendLine(true);
                if (__tmp87_outputWritten)
                {
                    __out.AppendLine(false); //415:64
                }
            }
            else if (valueDecl != null && valueDecl is MetaType) //416:2
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
                string __tmp97_line = "."; //417:7
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
                string __tmp99_line = ".AddLazy(() => "; //417:19
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
                string __tmp101_line = ");"; //417:110
                if (!string.IsNullOrEmpty(__tmp101_line))
                {
                    __out.Write(__tmp101_line);
                    __tmp95_outputWritten = true;
                }
                if (__tmp95_outputWritten) __out.AppendLine(true);
                if (__tmp95_outputWritten)
                {
                    __out.AppendLine(false); //417:112
                }
            }
            else if (valueDecl != null && valueDecl is MetaConstant) //418:2
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
                string __tmp105_line = "."; //419:7
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
                string __tmp107_line = ".AddLazy(() => "; //419:19
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
                string __tmp109_line = ");"; //419:114
                if (!string.IsNullOrEmpty(__tmp109_line))
                {
                    __out.Write(__tmp109_line);
                    __tmp103_outputWritten = true;
                }
                if (__tmp103_outputWritten) __out.AppendLine(true);
                if (__tmp103_outputWritten)
                {
                    __out.AppendLine(false); //419:116
                }
            }
            else //420:2
            {
                bool __tmp111_outputWritten = false;
                string __tmp112_line = "// TODO: "; //421:1
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
                string __tmp114_line = "."; //421:16
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
                    __out.AppendLine(false); //421:28
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateFactory(MetaModel model) //425:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //426:2
            bool metaMetaModel = IsMetaMetaModel(model); //427:2
            __out.Write("/// <summary>"); //428:1
            __out.AppendLine(false); //428:14
            __out.Write("/// Factory class for creating instances of model elements."); //429:1
            __out.AppendLine(false); //429:60
            __out.Write("/// </summary>"); //430:1
            __out.AppendLine(false); //430:15
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //431:1
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
            string __tmp5_line = " : "; //431:51
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
            string __tmp7_line = ".ModelFactoryBase"; //431:73
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //431:90
            }
            __out.Write("{"); //432:1
            __out.AppendLine(false); //432:2
            bool __tmp9_outputWritten = false;
            string __tmp10_line = "	public "; //433:1
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
            string __tmp12_line = "("; //433:46
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
            string __tmp14_line = ".MutableModel model, "; //433:66
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
            string __tmp16_line = ".ModelFactoryFlags flags = "; //433:106
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
            string __tmp18_line = ".ModelFactoryFlags.None)"; //433:152
            if (!string.IsNullOrEmpty(__tmp18_line))
            {
                __out.Write(__tmp18_line);
                __tmp9_outputWritten = true;
            }
            if (__tmp9_outputWritten) __out.AppendLine(true);
            if (__tmp9_outputWritten)
            {
                __out.AppendLine(false); //433:176
            }
            __out.Write("		: base(model, flags)"); //434:1
            __out.AppendLine(false); //434:23
            __out.Write("	{"); //435:1
            __out.AppendLine(false); //435:3
            bool __tmp20_outputWritten = false;
            string __tmp19Prefix = "		"; //436:1
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
            string __tmp22_line = ".Initialize();"; //436:43
            if (!string.IsNullOrEmpty(__tmp22_line))
            {
                __out.Write(__tmp22_line);
                __tmp20_outputWritten = true;
            }
            if (__tmp20_outputWritten) __out.AppendLine(true);
            if (__tmp20_outputWritten)
            {
                __out.AppendLine(false); //436:57
            }
            __out.Write("	}"); //437:1
            __out.AppendLine(false); //437:3
            __out.AppendLine(true); //438:1
            bool __tmp24_outputWritten = false;
            string __tmp25_line = "	public override "; //439:1
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
            string __tmp27_line = ".ModelMetadata MMetadata => "; //439:37
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
            string __tmp29_line = ".MMetadata;"; //439:118
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Write(__tmp29_line);
                __tmp24_outputWritten = true;
            }
            if (__tmp24_outputWritten) __out.AppendLine(true);
            if (__tmp24_outputWritten)
            {
                __out.AppendLine(false); //439:129
            }
            __out.AppendLine(true); //440:1
            bool __tmp31_outputWritten = false;
            string __tmp32_line = "	public override "; //441:1
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
            string __tmp34_line = ".MutableObject Create(string type)"; //441:37
            if (!string.IsNullOrEmpty(__tmp34_line))
            {
                __out.Write(__tmp34_line);
                __tmp31_outputWritten = true;
            }
            if (__tmp31_outputWritten) __out.AppendLine(true);
            if (__tmp31_outputWritten)
            {
                __out.AppendLine(false); //441:71
            }
            __out.Write("	{"); //442:1
            __out.AppendLine(false); //442:3
            __out.Write("		switch (type)"); //443:1
            __out.AppendLine(false); //443:16
            __out.Write("		{"); //444:1
            __out.AppendLine(false); //444:4
            var __loop22_results = 
                (from __loop22_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //445:10
                from cls in __Enumerate((__loop22_var1).GetEnumerator()).OfType<MetaClass>() //445:40
                select new { __loop22_var1 = __loop22_var1, cls = cls}
                ).ToList(); //445:5
            for (int __loop22_iteration = 0; __loop22_iteration < __loop22_results.Count; ++__loop22_iteration)
            {
                var __tmp35 = __loop22_results[__loop22_iteration];
                var __loop22_var1 = __tmp35.__loop22_var1;
                var cls = __tmp35.cls;
                if (!cls.IsAbstract) //446:6
                {
                    bool __tmp37_outputWritten = false;
                    string __tmp38_line = "			case \""; //447:1
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
                    string __tmp40_line = "\": return this."; //447:33
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
                    string __tmp42_line = "();"; //447:71
                    if (!string.IsNullOrEmpty(__tmp42_line))
                    {
                        __out.Write(__tmp42_line);
                        __tmp37_outputWritten = true;
                    }
                    if (__tmp37_outputWritten) __out.AppendLine(true);
                    if (__tmp37_outputWritten)
                    {
                        __out.AppendLine(false); //447:74
                    }
                }
            }
            __out.Write("			default:"); //450:1
            __out.AppendLine(false); //450:12
            bool __tmp44_outputWritten = false;
            string __tmp45_line = "				throw new "; //451:1
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
            string __tmp47_line = ".ModelException("; //451:34
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
            string __tmp49_line = ".ModelErrorCode.ERR_UnknownTypeName.ToDiagnosticWithNoLocation(type));"; //451:69
            if (!string.IsNullOrEmpty(__tmp49_line))
            {
                __out.Write(__tmp49_line);
                __tmp44_outputWritten = true;
            }
            if (__tmp44_outputWritten) __out.AppendLine(true);
            if (__tmp44_outputWritten)
            {
                __out.AppendLine(false); //451:139
            }
            __out.Write("		}"); //452:1
            __out.AppendLine(false); //452:4
            __out.Write("	}"); //453:1
            __out.AppendLine(false); //453:3
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //454:8
                from cls in __Enumerate((__loop23_var1).GetEnumerator()).OfType<MetaClass>() //454:38
                select new { __loop23_var1 = __loop23_var1, cls = cls}
                ).ToList(); //454:3
            for (int __loop23_iteration = 0; __loop23_iteration < __loop23_results.Count; ++__loop23_iteration)
            {
                var __tmp50 = __loop23_results[__loop23_iteration];
                var __loop23_var1 = __tmp50.__loop23_var1;
                var cls = __tmp50.cls;
                if (!cls.IsAbstract) //455:4
                {
                    __out.AppendLine(true); //456:1
                    __out.Write("	/// <summary>"); //457:1
                    __out.AppendLine(false); //457:15
                    bool __tmp52_outputWritten = false;
                    string __tmp53_line = "	/// Creates a new instance of "; //458:1
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
                    string __tmp55_line = "."; //458:55
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Write(__tmp55_line);
                        __tmp52_outputWritten = true;
                    }
                    if (__tmp52_outputWritten) __out.AppendLine(true);
                    if (__tmp52_outputWritten)
                    {
                        __out.AppendLine(false); //458:56
                    }
                    __out.Write("	/// </summary>"); //459:1
                    __out.AppendLine(false); //459:16
                    bool __tmp57_outputWritten = false;
                    string __tmp58_line = "	public "; //460:1
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
                    string __tmp60_line = " "; //460:51
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
                    string __tmp62_line = "()"; //460:100
                    if (!string.IsNullOrEmpty(__tmp62_line))
                    {
                        __out.Write(__tmp62_line);
                        __tmp57_outputWritten = true;
                    }
                    if (__tmp57_outputWritten) __out.AppendLine(true);
                    if (__tmp57_outputWritten)
                    {
                        __out.AppendLine(false); //460:102
                    }
                    __out.Write("	{"); //461:1
                    __out.AppendLine(false); //461:3
                    bool __tmp64_outputWritten = false;
                    string __tmp63Prefix = "		"; //462:1
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
                    string __tmp66_line = ".MutableObject obj = this.CreateObject(new "; //462:22
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
                    string __tmp68_line = "());"; //462:102
                    if (!string.IsNullOrEmpty(__tmp68_line))
                    {
                        __out.Write(__tmp68_line);
                        __tmp64_outputWritten = true;
                    }
                    if (__tmp64_outputWritten) __out.AppendLine(true);
                    if (__tmp64_outputWritten)
                    {
                        __out.AppendLine(false); //462:106
                    }
                    bool __tmp70_outputWritten = false;
                    string __tmp71_line = "		return ("; //463:1
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
                    string __tmp73_line = ")obj;"; //463:53
                    if (!string.IsNullOrEmpty(__tmp73_line))
                    {
                        __out.Write(__tmp73_line);
                        __tmp70_outputWritten = true;
                    }
                    if (__tmp70_outputWritten) __out.AppendLine(true);
                    if (__tmp70_outputWritten)
                    {
                        __out.AppendLine(false); //463:58
                    }
                    __out.Write("	}"); //464:1
                    __out.AppendLine(false); //464:3
                }
            }
            __out.Write("}"); //467:1
            __out.AppendLine(false); //467:2
            __out.AppendLine(true); //468:1
            return __out.ToStringAndFree();
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //471:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //472:2
            bool metaMetaModel = IsMetaMetaModel(model); //473:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public static class "; //474:1
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
                __out.AppendLine(false); //474:61
            }
            __out.Write("{"); //475:1
            __out.AppendLine(false); //475:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	private static global::System.Collections.Generic.List<"; //476:1
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
            string __tmp9_line = ".ModelProperty> properties;"; //476:76
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Write(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //476:103
            }
            __out.AppendLine(true); //477:1
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	static "; //478:1
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
            string __tmp14_line = "()"; //478:49
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //478:51
            }
            __out.Write("	{"); //479:1
            __out.AppendLine(false); //479:3
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "		properties = new global::System.Collections.Generic.List<"; //480:1
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
            string __tmp19_line = ".ModelProperty>();"; //480:79
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Write(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //480:97
            }
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //481:9
                from cls in __Enumerate((__loop24_var1).GetEnumerator()).OfType<MetaClass>() //481:39
                select new { __loop24_var1 = __loop24_var1, cls = cls}
                ).ToList(); //481:4
            for (int __loop24_iteration = 0; __loop24_iteration < __loop24_results.Count; ++__loop24_iteration)
            {
                var __tmp20 = __loop24_results[__loop24_iteration];
                var __loop24_var1 = __tmp20.__loop24_var1;
                var cls = __tmp20.cls;
                bool __tmp22_outputWritten = false;
                string __tmp21Prefix = "		"; //482:1
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
                string __tmp24_line = ".Initialize();"; //482:48
                if (!string.IsNullOrEmpty(__tmp24_line))
                {
                    __out.Write(__tmp24_line);
                    __tmp22_outputWritten = true;
                }
                if (__tmp22_outputWritten) __out.AppendLine(true);
                if (__tmp22_outputWritten)
                {
                    __out.AppendLine(false); //482:62
                }
            }
            var __loop25_results = 
                (from __loop25_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //484:9
                from cls in __Enumerate((__loop25_var1).GetEnumerator()).OfType<MetaClass>() //484:39
                from prop in __Enumerate((cls.Properties).GetEnumerator()) //484:62
                select new { __loop25_var1 = __loop25_var1, cls = cls, prop = prop}
                ).ToList(); //484:4
            for (int __loop25_iteration = 0; __loop25_iteration < __loop25_results.Count; ++__loop25_iteration)
            {
                var __tmp25 = __loop25_results[__loop25_iteration];
                var __loop25_var1 = __tmp25.__loop25_var1;
                var cls = __tmp25.cls;
                var prop = __tmp25.prop;
                bool __tmp27_outputWritten = false;
                string __tmp28_line = "		properties.Add("; //485:1
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
                string __tmp30_line = ");"; //485:73
                if (!string.IsNullOrEmpty(__tmp30_line))
                {
                    __out.Write(__tmp30_line);
                    __tmp27_outputWritten = true;
                }
                if (__tmp27_outputWritten) __out.AppendLine(true);
                if (__tmp27_outputWritten)
                {
                    __out.AppendLine(false); //485:75
                }
            }
            __out.Write("	}"); //487:1
            __out.AppendLine(false); //487:3
            __out.AppendLine(true); //488:1
            __out.Write("	public static void Initialize()"); //489:1
            __out.AppendLine(false); //489:33
            __out.Write("	{"); //490:1
            __out.AppendLine(false); //490:3
            __out.Write("	}"); //491:1
            __out.AppendLine(false); //491:3
            __out.AppendLine(true); //492:1
            bool __tmp32_outputWritten = false;
            string __tmp33_line = "	public const string MUri = \""; //493:1
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
            string __tmp35_line = "\";"; //493:41
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Write(__tmp35_line);
                __tmp32_outputWritten = true;
            }
            if (__tmp32_outputWritten) __out.AppendLine(true);
            if (__tmp32_outputWritten)
            {
                __out.AppendLine(false); //493:43
            }
            bool __tmp37_outputWritten = false;
            string __tmp38_line = "	public const string MPrefix = \""; //494:1
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
            string __tmp40_line = "\";"; //494:47
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Write(__tmp40_line);
                __tmp37_outputWritten = true;
            }
            if (__tmp37_outputWritten) __out.AppendLine(true);
            if (__tmp37_outputWritten)
            {
                __out.AppendLine(false); //494:49
            }
            var __loop26_results = 
                (from __loop26_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //495:8
                from cls in __Enumerate((__loop26_var1).GetEnumerator()).OfType<MetaClass>() //495:38
                select new { __loop26_var1 = __loop26_var1, cls = cls}
                ).ToList(); //495:3
            for (int __loop26_iteration = 0; __loop26_iteration < __loop26_results.Count; ++__loop26_iteration)
            {
                var __tmp41 = __loop26_results[__loop26_iteration];
                var __loop26_var1 = __tmp41.__loop26_var1;
                var cls = __tmp41.cls;
                __out.AppendLine(true); //496:1
                bool __tmp43_outputWritten = false;
                string __tmp42Prefix = "	"; //497:1
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
                    __out.AppendLine(false); //497:39
                }
            }
            __out.Write("}"); //499:1
            __out.AppendLine(false); //499:2
            return __out.ToStringAndFree();
        }

        public string GenerateDescriptorClass(MetaModel model, MetaClass cls) //502:1
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
                __out.AppendLine(false); //503:29
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
                __out.AppendLine(false); //504:26
            }
            if (cls.SymbolType != null) //505:2
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
                string __tmp10_line = "global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof("; //506:6
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
                string __tmp12_line = "))"; //506:103
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
                    __out.AppendLine(false); //506:110
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
            string __tmp17_line = ".ModelObjectDescriptorAttribute(typeof("; //508:24
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
            string __tmp19_line = "), typeof("; //508:105
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
            string __tmp21_line = "), typeof("; //508:164
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
            string __tmp23_line = ")"; //508:221
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
            string __tmp25_line = ")"; //508:258
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
                __out.AppendLine(false); //508:264
            }
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "public static class "; //509:1
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
                __out.AppendLine(false); //509:66
            }
            __out.Write("{"); //510:1
            __out.AppendLine(false); //510:2
            bool __tmp32_outputWritten = false;
            string __tmp33_line = "	private static "; //511:1
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
            string __tmp35_line = ".ModelObjectDescriptor descriptor;"; //511:36
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Write(__tmp35_line);
                __tmp32_outputWritten = true;
            }
            if (__tmp32_outputWritten) __out.AppendLine(true);
            if (__tmp32_outputWritten)
            {
                __out.AppendLine(false); //511:70
            }
            __out.AppendLine(true); //512:1
            bool __tmp37_outputWritten = false;
            string __tmp38_line = "	static "; //513:1
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
            string __tmp40_line = "()"; //513:54
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Write(__tmp40_line);
                __tmp37_outputWritten = true;
            }
            if (__tmp37_outputWritten) __out.AppendLine(true);
            if (__tmp37_outputWritten)
            {
                __out.AppendLine(false); //513:56
            }
            __out.Write("	{"); //514:1
            __out.AppendLine(false); //514:3
            bool __tmp42_outputWritten = false;
            string __tmp43_line = "		descriptor = "; //515:1
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
            string __tmp45_line = ".ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof("; //515:35
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
            string __tmp47_line = "));"; //515:141
            if (!string.IsNullOrEmpty(__tmp47_line))
            {
                __out.Write(__tmp47_line);
                __tmp42_outputWritten = true;
            }
            if (__tmp42_outputWritten) __out.AppendLine(true);
            if (__tmp42_outputWritten)
            {
                __out.AppendLine(false); //515:144
            }
            __out.Write("	}"); //516:1
            __out.AppendLine(false); //516:3
            __out.AppendLine(true); //517:1
            __out.Write("	internal static void Initialize()"); //518:1
            __out.AppendLine(false); //518:35
            __out.Write("	{"); //519:1
            __out.AppendLine(false); //519:3
            __out.Write("	}"); //520:1
            __out.AppendLine(false); //520:3
            __out.AppendLine(true); //521:1
            bool __tmp49_outputWritten = false;
            string __tmp50_line = "	public static "; //522:1
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
            string __tmp52_line = ".ModelObjectDescriptor MDescriptor"; //522:35
            if (!string.IsNullOrEmpty(__tmp52_line))
            {
                __out.Write(__tmp52_line);
                __tmp49_outputWritten = true;
            }
            if (__tmp49_outputWritten) __out.AppendLine(true);
            if (__tmp49_outputWritten)
            {
                __out.AppendLine(false); //522:69
            }
            __out.Write("	{"); //523:1
            __out.AppendLine(false); //523:3
            __out.Write("		get { return descriptor; }"); //524:1
            __out.AppendLine(false); //524:29
            __out.Write("	}"); //525:1
            __out.AppendLine(false); //525:3
            __out.AppendLine(true); //526:1
            bool __tmp54_outputWritten = false;
            string __tmp55_line = "	public static "; //527:1
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
            string __tmp57_line = ".MetaClass MMetaClass"; //527:35
            if (!string.IsNullOrEmpty(__tmp57_line))
            {
                __out.Write(__tmp57_line);
                __tmp54_outputWritten = true;
            }
            if (__tmp54_outputWritten) __out.AppendLine(true);
            if (__tmp54_outputWritten)
            {
                __out.AppendLine(false); //527:56
            }
            __out.Write("	{"); //528:1
            __out.AppendLine(false); //528:3
            bool __tmp59_outputWritten = false;
            string __tmp60_line = "		get { return "; //529:1
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
            string __tmp62_line = "; }"; //529:73
            if (!string.IsNullOrEmpty(__tmp62_line))
            {
                __out.Write(__tmp62_line);
                __tmp59_outputWritten = true;
            }
            if (__tmp59_outputWritten) __out.AppendLine(true);
            if (__tmp59_outputWritten)
            {
                __out.AppendLine(false); //529:76
            }
            __out.Write("	}"); //530:1
            __out.AppendLine(false); //530:3
            var __loop27_results = 
                (from __loop27_var1 in __Enumerate((cls).GetEnumerator()) //531:8
                from prop in __Enumerate((__loop27_var1.Properties).GetEnumerator()) //531:13
                select new { __loop27_var1 = __loop27_var1, prop = prop}
                ).ToList(); //531:3
            for (int __loop27_iteration = 0; __loop27_iteration < __loop27_results.Count; ++__loop27_iteration)
            {
                var __tmp63 = __loop27_results[__loop27_iteration];
                var __loop27_var1 = __tmp63.__loop27_var1;
                var prop = __tmp63.prop;
                bool __tmp65_outputWritten = false;
                string __tmp64Prefix = "	"; //532:1
                var __tmp66 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp66.Write(GenerateDescriptorProperty(model, cls, prop, GetMetaType(prop)));
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
                    __out.AppendLine(false); //532:67
                }
            }
            __out.Write("}"); //534:1
            __out.AppendLine(false); //534:2
            return __out.ToStringAndFree();
        }

        public string GetDescriptorAncestors(MetaModel model, MetaClass cls) //537:1
        {
            string result = ""; //538:2
            var __loop28_results = 
                (from __loop28_var1 in __Enumerate((cls).GetEnumerator()) //539:7
                from super in __Enumerate((__loop28_var1.SuperClasses).GetEnumerator()) //539:12
                select new { __loop28_var1 = __loop28_var1, super = super}
                ).ToList(); //539:2
            for (int __loop28_iteration = 0; __loop28_iteration < __loop28_results.Count; ++__loop28_iteration)
            {
                string delim; //539:30
                if (__loop28_iteration+1 < __loop28_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop28_results[__loop28_iteration];
                var __loop28_var1 = __tmp1.__loop28_var1;
                var super = __tmp1.super;
                result += "typeof(" + CSharpName(super, model, ClassKind.Descriptor, true) + ")" + delim; //540:3
            }
            if (result.Length > 0) //542:2
            {
                result = ", BaseDescriptors = new global::System.Type[] { " + result + " }"; //543:3
            }
            return result; //545:2
        }

        public string GenerateDescriptorProperty(MetaModel model, MetaClass cls, MetaProperty prop, MetaType propType) //548:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.AppendLine(true); //549:1
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
                __out.AppendLine(false); //550:30
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
                __out.AppendLine(false); //551:27
            }
            if (prop.SymbolProperty != null) //552:2
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
                string __tmp10_line = "global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute(\""; //553:6
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
                string __tmp12_line = "\")"; //553:101
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
                    __out.AppendLine(false); //553:108
                }
            }
            bool __tmp15_outputWritten = false;
            var __tmp16 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp16.Write(GenerateDescriptorPropertyAttributes(model, cls, prop, propType));
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
                __out.AppendLine(false); //555:67
            }
            bool __tmp18_outputWritten = false;
            string __tmp19_line = "public static readonly "; //556:1
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
            string __tmp21_line = ".ModelProperty "; //556:43
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
            string __tmp23_line = " ="; //556:107
            if (!string.IsNullOrEmpty(__tmp23_line))
            {
                __out.Write(__tmp23_line);
                __tmp18_outputWritten = true;
            }
            if (__tmp18_outputWritten) __out.AppendLine(true);
            if (__tmp18_outputWritten)
            {
                __out.AppendLine(false); //556:109
            }
            bool __tmp25_outputWritten = false;
            string __tmp24Prefix = "    "; //557:1
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
            string __tmp27_line = ".ModelProperty.Register(declaringType: typeof("; //557:24
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
            string __tmp29_line = "), name: \""; //557:115
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
            string __tmp31_line = "\","; //557:149
            if (!string.IsNullOrEmpty(__tmp31_line))
            {
                __out.Write(__tmp31_line);
                __tmp25_outputWritten = true;
            }
            if (__tmp25_outputWritten) __out.AppendLine(true);
            if (__tmp25_outputWritten)
            {
                __out.AppendLine(false); //557:151
            }
            if (propType is MetaCollectionType) //558:2
            {
                MetaCollectionType collType = (MetaCollectionType)propType; //559:3
                bool __tmp33_outputWritten = false;
                string __tmp34_line = "        immutableType: typeof("; //560:1
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
                string __tmp36_line = "),"; //560:95
                if (!string.IsNullOrEmpty(__tmp36_line))
                {
                    __out.Write(__tmp36_line);
                    __tmp33_outputWritten = true;
                }
                if (__tmp33_outputWritten) __out.AppendLine(true);
                if (__tmp33_outputWritten)
                {
                    __out.AppendLine(false); //560:97
                }
                bool __tmp38_outputWritten = false;
                string __tmp39_line = "        mutableType: typeof("; //561:1
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
                string __tmp41_line = "),"; //561:91
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Write(__tmp41_line);
                    __tmp38_outputWritten = true;
                }
                if (__tmp38_outputWritten) __out.AppendLine(true);
                if (__tmp38_outputWritten)
                {
                    __out.AppendLine(false); //561:93
                }
            }
            else //562:2
            {
                bool __tmp43_outputWritten = false;
                string __tmp44_line = "        immutableType: typeof("; //563:1
                if (!string.IsNullOrEmpty(__tmp44_line))
                {
                    __out.Write(__tmp44_line);
                    __tmp43_outputWritten = true;
                }
                var __tmp45 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp45.Write(CSharpName(propType, null, ClassKind.Immutable, true));
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
                string __tmp46_line = "),"; //563:85
                if (!string.IsNullOrEmpty(__tmp46_line))
                {
                    __out.Write(__tmp46_line);
                    __tmp43_outputWritten = true;
                }
                if (__tmp43_outputWritten) __out.AppendLine(true);
                if (__tmp43_outputWritten)
                {
                    __out.AppendLine(false); //563:87
                }
                bool __tmp48_outputWritten = false;
                string __tmp49_line = "        mutableType: typeof("; //564:1
                if (!string.IsNullOrEmpty(__tmp49_line))
                {
                    __out.Write(__tmp49_line);
                    __tmp48_outputWritten = true;
                }
                var __tmp50 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp50.Write(CSharpName(propType, null, ClassKind.Builder, true));
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
                string __tmp51_line = "),"; //564:81
                if (!string.IsNullOrEmpty(__tmp51_line))
                {
                    __out.Write(__tmp51_line);
                    __tmp48_outputWritten = true;
                }
                if (__tmp48_outputWritten) __out.AppendLine(true);
                if (__tmp48_outputWritten)
                {
                    __out.AppendLine(false); //564:83
                }
            }
            bool __tmp53_outputWritten = false;
            string __tmp54_line = "		metaProperty: () => "; //566:1
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
            string __tmp56_line = ","; //566:84
            if (!string.IsNullOrEmpty(__tmp56_line))
            {
                __out.Write(__tmp56_line);
                __tmp53_outputWritten = true;
            }
            if (__tmp53_outputWritten) __out.AppendLine(true);
            if (__tmp53_outputWritten)
            {
                __out.AppendLine(false); //566:85
            }
            bool __tmp58_outputWritten = false;
            string __tmp59_line = "		defaultValue: "; //567:1
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
            string __tmp61_line = ");"; //567:73
            if (!string.IsNullOrEmpty(__tmp61_line))
            {
                __out.Write(__tmp61_line);
                __tmp58_outputWritten = true;
            }
            if (__tmp58_outputWritten) __out.AppendLine(true);
            if (__tmp58_outputWritten)
            {
                __out.AppendLine(false); //567:75
            }
            return __out.ToStringAndFree();
        }

        public string GenerateDescriptorPropertyAttributes(MetaModel model, MetaClass cls, MetaProperty prop, MetaType propType) //570:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            if (propType is MetaCollectionType) //571:2
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
                    __out.AppendLine(false); //572:48
                }
            }
            if (propType is MetaCollectionType && (((MetaCollectionType)propType).Kind == MetaCollectionKind.MultiSet || ((MetaCollectionType)propType).Kind == MetaCollectionKind.MultiList)) //574:2
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
                    __out.AppendLine(false); //575:47
                }
            }
            if (propType is MetaCollectionType && (((MetaCollectionType)propType).Kind == MetaCollectionKind.List || ((MetaCollectionType)propType).Kind == MetaCollectionKind.MultiList)) //577:2
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
                    __out.AppendLine(false); //578:45
                }
            }
            if (prop.IsContainment) //580:2
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
                    __out.AppendLine(false); //581:49
                }
            }
            if (prop.Kind != MetaPropertyKind.Normal) //583:2
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
                    __out.AppendLine(false); //584:46
                }
            }
            if (prop.Kind == MetaPropertyKind.Derived) //586:2
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
                    __out.AppendLine(false); //587:45
                }
            }
            if (prop.Kind == MetaPropertyKind.DerivedUnion) //589:2
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
                    __out.AppendLine(false); //590:50
                }
            }
            var __loop29_results = 
                (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //592:7
                select new { p = p}
                ).ToList(); //592:2
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
                    __out.AppendLine(false); //593:146
                }
            }
            var __loop30_results = 
                (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //595:7
                select new { p = p}
                ).ToList(); //595:2
            for (int __loop30_iteration = 0; __loop30_iteration < __loop30_results.Count; ++__loop30_iteration)
            {
                var __tmp30 = __loop30_results[__loop30_iteration];
                var p = __tmp30.p;
                if (cls.GetAllSuperClasses(true).Contains(p.Class)) //596:3
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
                        __out.AppendLine(false); //597:145
                    }
                }
                else //598:3
                {
                    bool __tmp39_outputWritten = false;
                    string __tmp40_line = "// ERROR: subsetted property '"; //599:1
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
                    string __tmp42_line = "' must be a property of this class or an ancestor class"; //599:83
                    if (!string.IsNullOrEmpty(__tmp42_line))
                    {
                        __out.Write(__tmp42_line);
                        __tmp39_outputWritten = true;
                    }
                    if (__tmp39_outputWritten) __out.AppendLine(true);
                    if (__tmp39_outputWritten)
                    {
                        __out.AppendLine(false); //599:138
                    }
                }
            }
            var __loop31_results = 
                (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //602:7
                select new { p = p}
                ).ToList(); //602:2
            for (int __loop31_iteration = 0; __loop31_iteration < __loop31_results.Count; ++__loop31_iteration)
            {
                var __tmp43 = __loop31_results[__loop31_iteration];
                var p = __tmp43.p;
                if (cls.GetAllSuperClasses(true).Contains(p.Class)) //603:3
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
                        __out.AppendLine(false); //604:147
                    }
                }
                else //605:3
                {
                    bool __tmp52_outputWritten = false;
                    string __tmp53_line = "// ERROR: redefined property '"; //606:1
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
                    string __tmp55_line = "' must be a property of this class or an ancestor class"; //606:83
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Write(__tmp55_line);
                        __tmp52_outputWritten = true;
                    }
                    if (__tmp52_outputWritten) __out.AppendLine(true);
                    if (__tmp52_outputWritten)
                    {
                        __out.AppendLine(false); //606:138
                    }
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateImplementationProvider(MetaModel model) //611:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //612:1
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
                __out.AppendLine(false); //612:68
            }
            __out.Write("{"); //613:1
            __out.AppendLine(false); //613:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	// If there is a compile error at this line, create a new class called "; //614:1
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
                __out.AppendLine(false); //614:117
            }
            bool __tmp10_outputWritten = false;
            string __tmp11_line = "	// which is a subclass of "; //615:1
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
            string __tmp13_line = ":"; //615:82
            if (!string.IsNullOrEmpty(__tmp13_line))
            {
                __out.Write(__tmp13_line);
                __tmp10_outputWritten = true;
            }
            if (__tmp10_outputWritten) __out.AppendLine(true);
            if (__tmp10_outputWritten)
            {
                __out.AppendLine(false); //615:83
            }
            bool __tmp15_outputWritten = false;
            string __tmp16_line = "	private static "; //616:1
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
            string __tmp18_line = " implementation = new "; //616:61
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
            string __tmp20_line = "();"; //616:127
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Write(__tmp20_line);
                __tmp15_outputWritten = true;
            }
            if (__tmp15_outputWritten) __out.AppendLine(true);
            if (__tmp15_outputWritten)
            {
                __out.AppendLine(false); //616:130
            }
            __out.AppendLine(true); //617:1
            bool __tmp22_outputWritten = false;
            string __tmp23_line = "	public static "; //618:1
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
            string __tmp25_line = " Implementation"; //618:60
            if (!string.IsNullOrEmpty(__tmp25_line))
            {
                __out.Write(__tmp25_line);
                __tmp22_outputWritten = true;
            }
            if (__tmp22_outputWritten) __out.AppendLine(true);
            if (__tmp22_outputWritten)
            {
                __out.AppendLine(false); //618:75
            }
            __out.Write("	{"); //619:1
            __out.AppendLine(false); //619:3
            __out.Write("		get { return implementation; }"); //620:1
            __out.AppendLine(false); //620:33
            __out.Write("	}"); //621:1
            __out.AppendLine(false); //621:3
            __out.Write("}"); //622:1
            __out.AppendLine(false); //622:2
            return __out.ToStringAndFree();
        }

        public string GenerateImplementationBase(MetaModel model) //625:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //626:2
            bool metaMetaModel = IsMetaMetaModel(model); //627:2
            __out.Write("/// <summary>"); //628:1
            __out.AppendLine(false); //628:14
            __out.Write("/// Base class for implementing the behavior of the model elements."); //629:1
            __out.AppendLine(false); //629:68
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "/// This class has to be be overriden in "; //630:1
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
            string __tmp5_line = " to provide custom"; //630:92
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Write(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //630:110
            }
            __out.Write("/// implementation for the constructors, operations and property values."); //631:1
            __out.AppendLine(false); //631:73
            __out.Write("/// </summary>"); //632:1
            __out.AppendLine(false); //632:15
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "internal abstract class "; //633:1
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
                __out.AppendLine(false); //633:73
            }
            __out.Write("{"); //634:1
            __out.AppendLine(false); //634:2
            __out.Write("	/// <summary>"); //635:1
            __out.AppendLine(false); //635:15
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	/// Implements the constructor: "; //636:1
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
            string __tmp14_line = "()"; //636:79
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //636:81
            }
            __out.Write("	/// </summary>"); //637:1
            __out.AppendLine(false); //637:16
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "	internal virtual void "; //638:1
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
            string __tmp19_line = "("; //638:69
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
            string __tmp21_line = " _this)"; //638:115
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //638:122
            }
            __out.Write("	{"); //639:1
            __out.AppendLine(false); //639:3
            __out.Write("	}"); //640:1
            __out.AppendLine(false); //640:3
            var __loop32_results = 
                (from __loop32_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //641:8
                from cls in __Enumerate((__loop32_var1).GetEnumerator()).OfType<MetaClass>() //641:38
                select new { __loop32_var1 = __loop32_var1, cls = cls}
                ).ToList(); //641:3
            for (int __loop32_iteration = 0; __loop32_iteration < __loop32_results.Count; ++__loop32_iteration)
            {
                var __tmp22 = __loop32_results[__loop32_iteration];
                var __loop32_var1 = __tmp22.__loop32_var1;
                var cls = __tmp22.cls;
                __out.AppendLine(true); //642:1
                __out.Write("	/// <summary>"); //643:1
                __out.AppendLine(false); //643:15
                bool __tmp24_outputWritten = false;
                string __tmp25_line = "	/// Implements the constructor: "; //644:1
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
                string __tmp27_line = "()"; //644:78
                if (!string.IsNullOrEmpty(__tmp27_line))
                {
                    __out.Write(__tmp27_line);
                    __tmp24_outputWritten = true;
                }
                if (__tmp24_outputWritten) __out.AppendLine(true);
                if (__tmp24_outputWritten)
                {
                    __out.AppendLine(false); //644:80
                }
                __out.Write("	/// </summary>"); //645:1
                __out.AppendLine(false); //645:16
                if ((from __loop33_var1 in __Enumerate((cls).GetEnumerator()) //646:15
                from sup in __Enumerate((__loop33_var1.SuperClasses).GetEnumerator()) //646:20
                select new { __loop33_var1 = __loop33_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //646:3
                {
                    __out.Write("	/// Direct superclasses: "); //647:1
                    __out.AppendLine(false); //647:27
                    __out.Write("	/// <ul>"); //648:1
                    __out.AppendLine(false); //648:10
                    var __loop34_results = 
                        (from __loop34_var1 in __Enumerate((cls).GetEnumerator()) //649:8
                        from sup in __Enumerate((__loop34_var1.SuperClasses).GetEnumerator()) //649:13
                        select new { __loop34_var1 = __loop34_var1, sup = sup}
                        ).ToList(); //649:3
                    for (int __loop34_iteration = 0; __loop34_iteration < __loop34_results.Count; ++__loop34_iteration)
                    {
                        var __tmp28 = __loop34_results[__loop34_iteration];
                        var __loop34_var1 = __tmp28.__loop34_var1;
                        var sup = __tmp28.sup;
                        bool __tmp30_outputWritten = false;
                        string __tmp31_line = "	///     <li>"; //650:1
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
                        string __tmp33_line = "</li>"; //650:64
                        if (!string.IsNullOrEmpty(__tmp33_line))
                        {
                            __out.Write(__tmp33_line);
                            __tmp30_outputWritten = true;
                        }
                        if (__tmp30_outputWritten) __out.AppendLine(true);
                        if (__tmp30_outputWritten)
                        {
                            __out.AppendLine(false); //650:69
                        }
                    }
                    __out.Write("	/// </ul>"); //652:1
                    __out.AppendLine(false); //652:11
                    __out.Write("	/// All superclasses:"); //653:1
                    __out.AppendLine(false); //653:23
                    __out.Write("	/// <ul>"); //654:1
                    __out.AppendLine(false); //654:10
                    var __loop35_results = 
                        (from __loop35_var1 in __Enumerate((cls).GetEnumerator()) //655:8
                        from sup in __Enumerate((__loop35_var1.GetAllSuperClasses(false)).GetEnumerator()) //655:13
                        select new { __loop35_var1 = __loop35_var1, sup = sup}
                        ).ToList(); //655:3
                    for (int __loop35_iteration = 0; __loop35_iteration < __loop35_results.Count; ++__loop35_iteration)
                    {
                        var __tmp34 = __loop35_results[__loop35_iteration];
                        var __loop35_var1 = __tmp34.__loop35_var1;
                        var sup = __tmp34.sup;
                        bool __tmp36_outputWritten = false;
                        string __tmp37_line = "	///     <li>"; //656:1
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
                        string __tmp39_line = "</li>"; //656:64
                        if (!string.IsNullOrEmpty(__tmp39_line))
                        {
                            __out.Write(__tmp39_line);
                            __tmp36_outputWritten = true;
                        }
                        if (__tmp36_outputWritten) __out.AppendLine(true);
                        if (__tmp36_outputWritten)
                        {
                            __out.AppendLine(false); //656:69
                        }
                    }
                    __out.Write("	/// </ul>"); //658:1
                    __out.AppendLine(false); //658:11
                }
                if ((from __loop36_var1 in __Enumerate((cls).GetEnumerator()) //660:15
                from prop in __Enumerate((__loop36_var1.Properties).GetEnumerator()) //660:20
                where prop.Kind == MetaPropertyKind.Readonly //660:36
                select new { __loop36_var1 = __loop36_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //660:3
                {
                    __out.Write("	/// Initializes the following readonly properties:"); //661:1
                    __out.AppendLine(false); //661:52
                    __out.Write("	/// <ul>"); //662:1
                    __out.AppendLine(false); //662:10
                    var __loop37_results = 
                        (from __loop37_var1 in __Enumerate((cls).GetEnumerator()) //663:8
                        from prop in __Enumerate((__loop37_var1.Properties).GetEnumerator()) //663:13
                        where prop.Kind == MetaPropertyKind.Readonly //663:29
                        select new { __loop37_var1 = __loop37_var1, prop = prop}
                        ).ToList(); //663:3
                    for (int __loop37_iteration = 0; __loop37_iteration < __loop37_results.Count; ++__loop37_iteration)
                    {
                        var __tmp40 = __loop37_results[__loop37_iteration];
                        var __loop37_var1 = __tmp40.__loop37_var1;
                        var prop = __tmp40.prop;
                        bool __tmp42_outputWritten = false;
                        string __tmp43_line = "	///     <li>"; //664:1
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
                        string __tmp45_line = "</li>"; //664:38
                        if (!string.IsNullOrEmpty(__tmp45_line))
                        {
                            __out.Write(__tmp45_line);
                            __tmp42_outputWritten = true;
                        }
                        if (__tmp42_outputWritten) __out.AppendLine(true);
                        if (__tmp42_outputWritten)
                        {
                            __out.AppendLine(false); //664:43
                        }
                    }
                    __out.Write("	/// </ul>"); //666:1
                    __out.AppendLine(false); //666:11
                }
                if ((from __loop38_var1 in __Enumerate((cls).GetEnumerator()) //668:15
                from prop in __Enumerate((__loop38_var1.Properties).GetEnumerator()) //668:20
                where prop.Kind == MetaPropertyKind.Lazy //668:36
                select new { __loop38_var1 = __loop38_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //668:3
                {
                    __out.Write("	/// Initializes the following lazy properties:"); //669:1
                    __out.AppendLine(false); //669:48
                    __out.Write("	/// <ul>"); //670:1
                    __out.AppendLine(false); //670:10
                    var __loop39_results = 
                        (from __loop39_var1 in __Enumerate((cls).GetEnumerator()) //671:8
                        from prop in __Enumerate((__loop39_var1.Properties).GetEnumerator()) //671:13
                        where prop.Kind == MetaPropertyKind.Lazy //671:29
                        select new { __loop39_var1 = __loop39_var1, prop = prop}
                        ).ToList(); //671:3
                    for (int __loop39_iteration = 0; __loop39_iteration < __loop39_results.Count; ++__loop39_iteration)
                    {
                        var __tmp46 = __loop39_results[__loop39_iteration];
                        var __loop39_var1 = __tmp46.__loop39_var1;
                        var prop = __tmp46.prop;
                        bool __tmp48_outputWritten = false;
                        string __tmp49_line = "	///     <li>"; //672:1
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
                        string __tmp51_line = "</li>"; //672:38
                        if (!string.IsNullOrEmpty(__tmp51_line))
                        {
                            __out.Write(__tmp51_line);
                            __tmp48_outputWritten = true;
                        }
                        if (__tmp48_outputWritten) __out.AppendLine(true);
                        if (__tmp48_outputWritten)
                        {
                            __out.AppendLine(false); //672:43
                        }
                    }
                    __out.Write("	/// </ul>"); //674:1
                    __out.AppendLine(false); //674:11
                }
                if ((from __loop40_var1 in __Enumerate((cls).GetEnumerator()) //676:15
                from prop in __Enumerate((__loop40_var1.Properties).GetEnumerator()) //676:20
                where prop.Kind == MetaPropertyKind.Derived //676:36
                select new { __loop40_var1 = __loop40_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //676:3
                {
                    __out.Write("	/// Initializes the following derived properties:"); //677:1
                    __out.AppendLine(false); //677:51
                    __out.Write("	/// <ul>"); //678:1
                    __out.AppendLine(false); //678:10
                    var __loop41_results = 
                        (from __loop41_var1 in __Enumerate((cls).GetEnumerator()) //679:8
                        from prop in __Enumerate((__loop41_var1.Properties).GetEnumerator()) //679:13
                        where prop.Kind == MetaPropertyKind.Derived //679:29
                        select new { __loop41_var1 = __loop41_var1, prop = prop}
                        ).ToList(); //679:3
                    for (int __loop41_iteration = 0; __loop41_iteration < __loop41_results.Count; ++__loop41_iteration)
                    {
                        var __tmp52 = __loop41_results[__loop41_iteration];
                        var __loop41_var1 = __tmp52.__loop41_var1;
                        var prop = __tmp52.prop;
                        bool __tmp54_outputWritten = false;
                        string __tmp55_line = "	///     <li>"; //680:1
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
                        string __tmp57_line = "</li>"; //680:38
                        if (!string.IsNullOrEmpty(__tmp57_line))
                        {
                            __out.Write(__tmp57_line);
                            __tmp54_outputWritten = true;
                        }
                        if (__tmp54_outputWritten) __out.AppendLine(true);
                        if (__tmp54_outputWritten)
                        {
                            __out.AppendLine(false); //680:43
                        }
                    }
                    __out.Write("	/// </ul>"); //682:1
                    __out.AppendLine(false); //682:11
                }
                bool __tmp59_outputWritten = false;
                string __tmp60_line = "	public virtual void "; //684:1
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
                string __tmp62_line = "("; //684:66
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
                string __tmp64_line = " _this)"; //684:109
                if (!string.IsNullOrEmpty(__tmp64_line))
                {
                    __out.Write(__tmp64_line);
                    __tmp59_outputWritten = true;
                }
                if (__tmp59_outputWritten) __out.AppendLine(true);
                if (__tmp59_outputWritten)
                {
                    __out.AppendLine(false); //684:116
                }
                __out.Write("	{"); //685:1
                __out.AppendLine(false); //685:3
                bool __tmp66_outputWritten = false;
                string __tmp67_line = "		this.Call"; //686:1
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
                string __tmp69_line = "SuperConstructors(_this);"; //686:56
                if (!string.IsNullOrEmpty(__tmp69_line))
                {
                    __out.Write(__tmp69_line);
                    __tmp66_outputWritten = true;
                }
                if (__tmp66_outputWritten) __out.AppendLine(true);
                if (__tmp66_outputWritten)
                {
                    __out.AppendLine(false); //686:81
                }
                var __loop42_results = 
                    (from __loop42_var1 in __Enumerate((cls).GetEnumerator()) //687:9
                    from prop in __Enumerate((__loop42_var1.GetAllFinalProperties()).GetEnumerator()) //687:14
                    select new { __loop42_var1 = __loop42_var1, prop = prop}
                    ).ToList(); //687:4
                for (int __loop42_iteration = 0; __loop42_iteration < __loop42_results.Count; ++__loop42_iteration)
                {
                    var __tmp70 = __loop42_results[__loop42_iteration];
                    var __loop42_var1 = __tmp70.__loop42_var1;
                    var prop = __tmp70.prop;
                    var propType = GetMetaType(prop); //688:5
                    if (metaMetaModel && cls.Name == "MetaConstant" && prop.Name == "Value") //689:5
                    {
                    }
                    else if (prop.DefaultValue != null) //690:5
                    {
                        if (!(propType is MetaCollectionType)) //691:6
                        {
                            bool __tmp72_outputWritten = false;
                            string __tmp73_line = "		_this.Set"; //692:1
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
                            string __tmp75_line = "Lazy(() => "; //692:58
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
                            string __tmp77_line = ");"; //692:88
                            if (!string.IsNullOrEmpty(__tmp77_line))
                            {
                                __out.Write(__tmp77_line);
                                __tmp72_outputWritten = true;
                            }
                            if (__tmp72_outputWritten) __out.AppendLine(true);
                            if (__tmp72_outputWritten)
                            {
                                __out.AppendLine(false); //692:90
                            }
                        }
                        else //693:6
                        {
                            __out.Write("		// ERROR: default value for collection"); //694:1
                            __out.AppendLine(false); //694:41
                            bool __tmp79_outputWritten = false;
                            string __tmp80_line = "		// _this."; //695:1
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
                            string __tmp82_line = " = "; //695:58
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
                            string __tmp84_line = ";"; //695:80
                            if (!string.IsNullOrEmpty(__tmp84_line))
                            {
                                __out.Write(__tmp84_line);
                                __tmp79_outputWritten = true;
                            }
                            if (__tmp79_outputWritten) __out.AppendLine(true);
                            if (__tmp79_outputWritten)
                            {
                                __out.AppendLine(false); //695:81
                            }
                        }
                    }
                    else if (prop.Kind == MetaPropertyKind.Lazy || prop.Kind == MetaPropertyKind.Derived) //697:5
                    {
                        if (!(propType is MetaCollectionType)) //698:6
                        {
                            bool __tmp86_outputWritten = false;
                            string __tmp87_line = "		_this.Set"; //699:1
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
                            string __tmp89_line = "Lazy(this."; //699:58
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
                            string __tmp91_line = "_ComputeProperty_"; //699:119
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
                            string __tmp93_line = ");"; //699:160
                            if (!string.IsNullOrEmpty(__tmp93_line))
                            {
                                __out.Write(__tmp93_line);
                                __tmp86_outputWritten = true;
                            }
                            if (__tmp86_outputWritten) __out.AppendLine(true);
                            if (__tmp86_outputWritten)
                            {
                                __out.AppendLine(false); //699:162
                            }
                        }
                        else //700:6
                        {
                            bool __tmp95_outputWritten = false;
                            string __tmp96_line = "		_this."; //701:1
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
                            string __tmp98_line = ".AddRangeLazy<"; //701:55
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
                            string __tmp100_line = ">(this."; //701:118
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
                            string __tmp102_line = "_ComputeProperty_"; //701:176
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
                            string __tmp104_line = ");"; //701:217
                            if (!string.IsNullOrEmpty(__tmp104_line))
                            {
                                __out.Write(__tmp104_line);
                                __tmp95_outputWritten = true;
                            }
                            if (__tmp95_outputWritten) __out.AppendLine(true);
                            if (__tmp95_outputWritten)
                            {
                                __out.AppendLine(false); //701:219
                            }
                        }
                    }
                    else if (prop.Kind == MetaPropertyKind.Readonly) //703:5
                    {
                        if (!(propType is MetaCollectionType)) //704:6
                        {
                            bool __tmp106_outputWritten = false;
                            string __tmp107_line = "		_this.Set"; //705:1
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
                            string __tmp109_line = "Lazy(this."; //705:58
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
                            string __tmp111_line = "_ComputeProperty_"; //705:119
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
                            string __tmp113_line = ");"; //705:160
                            if (!string.IsNullOrEmpty(__tmp113_line))
                            {
                                __out.Write(__tmp113_line);
                                __tmp106_outputWritten = true;
                            }
                            if (__tmp106_outputWritten) __out.AppendLine(true);
                            if (__tmp106_outputWritten)
                            {
                                __out.AppendLine(false); //705:162
                            }
                        }
                        else //706:6
                        {
                            bool __tmp115_outputWritten = false;
                            string __tmp116_line = "		_this."; //707:1
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
                            string __tmp118_line = ".AddRangeLazy("; //707:55
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
                            string __tmp120_line = "_ComputeProperty_"; //707:120
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
                            string __tmp122_line = ");"; //707:161
                            if (!string.IsNullOrEmpty(__tmp122_line))
                            {
                                __out.Write(__tmp122_line);
                                __tmp115_outputWritten = true;
                            }
                            if (__tmp115_outputWritten) __out.AppendLine(true);
                            if (__tmp115_outputWritten)
                            {
                                __out.AppendLine(false); //707:163
                            }
                        }
                    }
                }
                __out.Write("	}"); //711:1
                __out.AppendLine(false); //711:3
                __out.AppendLine(true); //712:1
                __out.Write("	/// <summary>"); //713:1
                __out.AppendLine(false); //713:15
                bool __tmp124_outputWritten = false;
                string __tmp125_line = "	/// Calls the super constructors of "; //714:1
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
                    __out.AppendLine(false); //714:82
                }
                __out.Write("	/// </summary>"); //715:1
                __out.AppendLine(false); //715:16
                bool __tmp128_outputWritten = false;
                string __tmp129_line = "	protected virtual void Call"; //716:1
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
                string __tmp131_line = "SuperConstructors("; //716:73
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
                string __tmp133_line = " _this)"; //716:133
                if (!string.IsNullOrEmpty(__tmp133_line))
                {
                    __out.Write(__tmp133_line);
                    __tmp128_outputWritten = true;
                }
                if (__tmp128_outputWritten) __out.AppendLine(true);
                if (__tmp128_outputWritten)
                {
                    __out.AppendLine(false); //716:140
                }
                __out.Write("	{"); //717:1
                __out.AppendLine(false); //717:3
                var __loop43_results = 
                    (from __loop43_var1 in __Enumerate((cls).GetEnumerator()) //718:8
                    from sup in __Enumerate((__loop43_var1.GetAllSuperClasses(false)).GetEnumerator()) //718:13
                    select new { __loop43_var1 = __loop43_var1, sup = sup}
                    ).ToList(); //718:3
                for (int __loop43_iteration = 0; __loop43_iteration < __loop43_results.Count; ++__loop43_iteration)
                {
                    var __tmp134 = __loop43_results[__loop43_iteration];
                    var __loop43_var1 = __tmp134.__loop43_var1;
                    var sup = __tmp134.sup;
                    if (model.Namespace.Declarations.Contains(sup)) //719:4
                    {
                        bool __tmp136_outputWritten = false;
                        string __tmp137_line = "		this."; //720:1
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
                        string __tmp139_line = "(_this);"; //720:52
                        if (!string.IsNullOrEmpty(__tmp139_line))
                        {
                            __out.Write(__tmp139_line);
                            __tmp136_outputWritten = true;
                        }
                        if (__tmp136_outputWritten) __out.AppendLine(true);
                        if (__tmp136_outputWritten)
                        {
                            __out.AppendLine(false); //720:60
                        }
                    }
                    else //721:4
                    {
                        bool __tmp141_outputWritten = false;
                        string __tmp140Prefix = "		"; //722:1
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
                        string __tmp143_line = "."; //722:69
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
                        string __tmp145_line = "(_this);"; //722:114
                        if (!string.IsNullOrEmpty(__tmp145_line))
                        {
                            __out.Write(__tmp145_line);
                            __tmp141_outputWritten = true;
                        }
                        if (__tmp141_outputWritten) __out.AppendLine(true);
                        if (__tmp141_outputWritten)
                        {
                            __out.AppendLine(false); //722:122
                        }
                    }
                }
                __out.Write("	}"); //725:1
                __out.AppendLine(false); //725:3
                __out.AppendLine(true); //726:2
                var __loop44_results = 
                    (from __loop44_var1 in __Enumerate((cls).GetEnumerator()) //727:8
                    from prop in __Enumerate((__loop44_var1.Properties).GetEnumerator()) //727:13
                    where prop.Kind == MetaPropertyKind.Readonly || prop.Kind == MetaPropertyKind.Lazy || prop.Kind == MetaPropertyKind.Derived //727:29
                    select new { __loop44_var1 = __loop44_var1, prop = prop}
                    ).ToList(); //727:3
                for (int __loop44_iteration = 0; __loop44_iteration < __loop44_results.Count; ++__loop44_iteration)
                {
                    var __tmp146 = __loop44_results[__loop44_iteration];
                    var __loop44_var1 = __tmp146.__loop44_var1;
                    var prop = __tmp146.prop;
                    if (metaMetaModel && cls.Name == "MetaConstant" && prop.Name == "Value") //728:4
                    {
                    }
                    else //729:4
                    {
                        __out.Write("	/// <summary>"); //730:1
                        __out.AppendLine(false); //730:15
                        bool __tmp148_outputWritten = false;
                        string __tmp149_line = "	/// Computes the value of the property: "; //731:1
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
                        string __tmp151_line = "."; //731:86
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
                            __out.AppendLine(false); //731:111
                        }
                        __out.Write("	/// </summary	"); //732:1
                        __out.AppendLine(false); //732:16
                        bool __tmp154_outputWritten = false;
                        string __tmp155_line = "	public abstract "; //733:1
                        if (!string.IsNullOrEmpty(__tmp155_line))
                        {
                            __out.Write(__tmp155_line);
                            __tmp154_outputWritten = true;
                        }
                        var __tmp156 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp156.Write(CSharpName(GetMetaType(prop), model, ClassKind.BuilderOperation, true));
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
                        string __tmp157_line = " "; //733:89
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
                        string __tmp159_line = "_ComputeProperty_"; //733:134
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
                        string __tmp161_line = "("; //733:175
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
                        string __tmp163_line = " _this);"; //733:218
                        if (!string.IsNullOrEmpty(__tmp163_line))
                        {
                            __out.Write(__tmp163_line);
                            __tmp154_outputWritten = true;
                        }
                        if (__tmp154_outputWritten) __out.AppendLine(true);
                        if (__tmp154_outputWritten)
                        {
                            __out.AppendLine(false); //733:226
                        }
                    }
                }
                __out.AppendLine(true); //736:2
                var __loop45_results = 
                    (from __loop45_var1 in __Enumerate((cls).GetEnumerator()) //737:8
                    from op in __Enumerate((__loop45_var1.Operations).GetEnumerator()) //737:13
                    select new { __loop45_var1 = __loop45_var1, op = op}
                    ).ToList(); //737:3
                for (int __loop45_iteration = 0; __loop45_iteration < __loop45_results.Count; ++__loop45_iteration)
                {
                    var __tmp164 = __loop45_results[__loop45_iteration];
                    var __loop45_var1 = __tmp164.__loop45_var1;
                    var op = __tmp164.op;
                    if (!op.IsBuilder) //738:4
                    {
                        __out.AppendLine(true); //739:2
                        __out.Write("	/// <summary>"); //740:1
                        __out.AppendLine(false); //740:15
                        bool __tmp166_outputWritten = false;
                        string __tmp167_line = "	/// Implements the operation: "; //741:1
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
                        string __tmp169_line = "."; //741:76
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
                        string __tmp171_line = "()"; //741:86
                        if (!string.IsNullOrEmpty(__tmp171_line))
                        {
                            __out.Write(__tmp171_line);
                            __tmp166_outputWritten = true;
                        }
                        if (__tmp166_outputWritten) __out.AppendLine(true);
                        if (__tmp166_outputWritten)
                        {
                            __out.AppendLine(false); //741:88
                        }
                        __out.Write("	/// </summary>"); //742:1
                        __out.AppendLine(false); //742:16
                        bool __tmp173_outputWritten = false;
                        string __tmp174_line = "	public virtual "; //743:1
                        if (!string.IsNullOrEmpty(__tmp174_line))
                        {
                            __out.Write(__tmp174_line);
                            __tmp173_outputWritten = true;
                        }
                        var __tmp175 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp175.Write(CSharpName(GetMetaType(op), model, ClassKind.ImmutableOperation, true));
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
                        string __tmp176_line = " "; //743:88
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
                        string __tmp178_line = "_"; //743:133
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
                        string __tmp180_line = "("; //743:143
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
                        string __tmp182_line = ")"; //743:209
                        if (!string.IsNullOrEmpty(__tmp182_line))
                        {
                            __out.Write(__tmp182_line);
                            __tmp173_outputWritten = true;
                        }
                        if (__tmp173_outputWritten) __out.AppendLine(true);
                        if (__tmp173_outputWritten)
                        {
                            __out.AppendLine(false); //743:210
                        }
                        __out.Write("	{"); //744:1
                        __out.AppendLine(false); //744:3
                        bool __tmp184_outputWritten = false;
                        string __tmp183Prefix = "		"; //745:1
                        var __tmp185 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp185.Write(GetReturn(CSharpName(GetMetaType(op), model, ClassKind.ImmutableOperation, true)));
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
                        string __tmp186_line = "this."; //745:85
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
                        string __tmp188_line = "_"; //745:139
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
                        string __tmp190_line = "("; //745:149
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
                        string __tmp192_line = ")"; //745:218
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
                        string __tmp194_line = ";"; //745:277
                        if (!string.IsNullOrEmpty(__tmp194_line))
                        {
                            __out.Write(__tmp194_line);
                            __tmp184_outputWritten = true;
                        }
                        if (__tmp184_outputWritten) __out.AppendLine(true);
                        if (__tmp184_outputWritten)
                        {
                            __out.AppendLine(false); //745:278
                        }
                        __out.Write("	}"); //746:1
                        __out.AppendLine(false); //746:3
                    }
                    __out.AppendLine(true); //748:2
                    __out.Write("	/// <summary>"); //749:1
                    __out.AppendLine(false); //749:15
                    bool __tmp196_outputWritten = false;
                    string __tmp197_line = "	/// Implements the operation: "; //750:1
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
                    string __tmp199_line = "."; //750:74
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
                    string __tmp201_line = "()"; //750:84
                    if (!string.IsNullOrEmpty(__tmp201_line))
                    {
                        __out.Write(__tmp201_line);
                        __tmp196_outputWritten = true;
                    }
                    if (__tmp196_outputWritten) __out.AppendLine(true);
                    if (__tmp196_outputWritten)
                    {
                        __out.AppendLine(false); //750:86
                    }
                    __out.Write("	/// </summary>"); //751:1
                    __out.AppendLine(false); //751:16
                    bool __tmp203_outputWritten = false;
                    string __tmp204_line = "	public abstract "; //752:1
                    if (!string.IsNullOrEmpty(__tmp204_line))
                    {
                        __out.Write(__tmp204_line);
                        __tmp203_outputWritten = true;
                    }
                    var __tmp205 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp205.Write(CSharpName(GetMetaType(op), model, ClassKind.BuilderOperation, true));
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
                    string __tmp206_line = " "; //752:87
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
                    string __tmp208_line = "_"; //752:132
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
                    string __tmp210_line = "("; //752:142
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
                    string __tmp212_line = ");"; //752:206
                    if (!string.IsNullOrEmpty(__tmp212_line))
                    {
                        __out.Write(__tmp212_line);
                        __tmp203_outputWritten = true;
                    }
                    if (__tmp203_outputWritten) __out.AppendLine(true);
                    if (__tmp203_outputWritten)
                    {
                        __out.AppendLine(false); //752:208
                    }
                }
                __out.AppendLine(true); //754:2
            }
            var __loop46_results = 
                (from __loop46_var1 in __Enumerate((model).GetEnumerator()) //756:8
                from Namespace in __Enumerate((__loop46_var1.Namespace).GetEnumerator()) //756:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //756:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //756:40
                select new { __loop46_var1 = __loop46_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //756:3
            for (int __loop46_iteration = 0; __loop46_iteration < __loop46_results.Count; ++__loop46_iteration)
            {
                var __tmp213 = __loop46_results[__loop46_iteration];
                var __loop46_var1 = __tmp213.__loop46_var1;
                var Namespace = __tmp213.Namespace;
                var Declarations = __tmp213.Declarations;
                var enm = __tmp213.enm;
                var __loop47_results = 
                    (from __loop47_var1 in __Enumerate((enm).GetEnumerator()) //757:8
                    from op in __Enumerate((__loop47_var1.Operations).GetEnumerator()) //757:13
                    select new { __loop47_var1 = __loop47_var1, op = op}
                    ).ToList(); //757:3
                for (int __loop47_iteration = 0; __loop47_iteration < __loop47_results.Count; ++__loop47_iteration)
                {
                    var __tmp214 = __loop47_results[__loop47_iteration];
                    var __loop47_var1 = __tmp214.__loop47_var1;
                    var op = __tmp214.op;
                    __out.AppendLine(true); //758:2
                    __out.Write("	/// <summary>"); //759:1
                    __out.AppendLine(false); //759:15
                    bool __tmp216_outputWritten = false;
                    string __tmp217_line = "	/// Implements the operation: "; //760:1
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
                    string __tmp219_line = "."; //760:76
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
                        __out.AppendLine(false); //760:86
                    }
                    __out.Write("	/// </summary>"); //761:1
                    __out.AppendLine(false); //761:16
                    bool __tmp222_outputWritten = false;
                    string __tmp223_line = "	public abstract "; //762:1
                    if (!string.IsNullOrEmpty(__tmp223_line))
                    {
                        __out.Write(__tmp223_line);
                        __tmp222_outputWritten = true;
                    }
                    var __tmp224 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp224.Write(CSharpName(GetMetaType(op), model, ClassKind.ImmutableOperation, true));
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
                    string __tmp225_line = " "; //762:89
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
                    string __tmp227_line = "_"; //762:134
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
                    string __tmp229_line = "("; //762:144
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
                    string __tmp231_line = ");"; //762:210
                    if (!string.IsNullOrEmpty(__tmp231_line))
                    {
                        __out.Write(__tmp231_line);
                        __tmp222_outputWritten = true;
                    }
                    if (__tmp222_outputWritten) __out.AppendLine(true);
                    if (__tmp222_outputWritten)
                    {
                        __out.AppendLine(false); //762:212
                    }
                }
                __out.AppendLine(true); //764:2
            }
            __out.Write("}"); //766:1
            __out.AppendLine(false); //766:2
            return __out.ToStringAndFree();
        }

        public string GenerateImplementation(MetaModel model) //769:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //770:2
            bool metaMetaModel = IsMetaMetaModel(model); //771:2
            __out.Write("/// <summary>"); //772:1
            __out.AppendLine(false); //772:14
            __out.Write("/// Class for implementing the behavior of the model elements."); //773:1
            __out.AppendLine(false); //773:63
            __out.Write("/// </summary>"); //774:1
            __out.AppendLine(false); //774:15
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //775:1
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
            string __tmp5_line = " : "; //775:60
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
                __out.AppendLine(false); //775:111
            }
            __out.Write("{"); //776:1
            __out.AppendLine(false); //776:2
            var __loop48_results = 
                (from __loop48_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //777:8
                from cls in __Enumerate((__loop48_var1).GetEnumerator()).OfType<MetaClass>() //777:38
                select new { __loop48_var1 = __loop48_var1, cls = cls}
                ).ToList(); //777:3
            for (int __loop48_iteration = 0; __loop48_iteration < __loop48_results.Count; ++__loop48_iteration)
            {
                var __tmp7 = __loop48_results[__loop48_iteration];
                var __loop48_var1 = __tmp7.__loop48_var1;
                var cls = __tmp7.cls;
                var __loop49_results = 
                    (from __loop49_var1 in __Enumerate((cls).GetEnumerator()) //778:8
                    from prop in __Enumerate((__loop49_var1.Properties).GetEnumerator()) //778:13
                    where prop.Kind == MetaPropertyKind.Readonly || prop.Kind == MetaPropertyKind.Lazy || prop.Kind == MetaPropertyKind.Derived //778:29
                    select new { __loop49_var1 = __loop49_var1, prop = prop}
                    ).ToList(); //778:3
                for (int __loop49_iteration = 0; __loop49_iteration < __loop49_results.Count; ++__loop49_iteration)
                {
                    var __tmp8 = __loop49_results[__loop49_iteration];
                    var __loop49_var1 = __tmp8.__loop49_var1;
                    var prop = __tmp8.prop;
                    var propType = GetMetaType(prop); //779:4
                    if (metaMetaModel && cls.Name == "MetaConstant" && prop.Name == "Value") //780:4
                    {
                    }
                    else //781:4
                    {
                        __out.AppendLine(true); //782:2
                        __out.Write("	/// <summary>"); //783:1
                        __out.AppendLine(false); //783:15
                        bool __tmp10_outputWritten = false;
                        string __tmp11_line = "	/// Computes the value of the property: "; //784:1
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
                        string __tmp13_line = "."; //784:86
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
                            __out.AppendLine(false); //784:111
                        }
                        __out.Write("	/// </summary	"); //785:1
                        __out.AppendLine(false); //785:16
                        bool __tmp16_outputWritten = false;
                        string __tmp17_line = "	public override "; //786:1
                        if (!string.IsNullOrEmpty(__tmp17_line))
                        {
                            __out.Write(__tmp17_line);
                            __tmp16_outputWritten = true;
                        }
                        var __tmp18 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp18.Write(CSharpName(propType, model, ClassKind.BuilderOperation, true));
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
                        string __tmp19_line = " "; //786:80
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
                        string __tmp21_line = "_ComputeProperty_"; //786:125
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
                        string __tmp23_line = "("; //786:166
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
                        string __tmp25_line = " _this)"; //786:209
                        if (!string.IsNullOrEmpty(__tmp25_line))
                        {
                            __out.Write(__tmp25_line);
                            __tmp16_outputWritten = true;
                        }
                        if (__tmp16_outputWritten) __out.AppendLine(true);
                        if (__tmp16_outputWritten)
                        {
                            __out.AppendLine(false); //786:216
                        }
                        __out.Write("	{"); //787:1
                        __out.AppendLine(false); //787:3
                        bool __tmp27_outputWritten = false;
                        string __tmp26Prefix = "		"; //788:1
                        var __tmp28 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                        __tmp28.Write(GetDefaultReturn(CSharpName(propType, model, ClassKind.BuilderOperation, true)));
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
                            __out.AppendLine(false); //788:83
                        }
                        __out.Write("	}"); //789:1
                        __out.AppendLine(false); //789:3
                    }
                }
                var __loop50_results = 
                    (from __loop50_var1 in __Enumerate((cls).GetEnumerator()) //792:8
                    from op in __Enumerate((__loop50_var1.Operations).GetEnumerator()) //792:13
                    select new { __loop50_var1 = __loop50_var1, op = op}
                    ).ToList(); //792:3
                for (int __loop50_iteration = 0; __loop50_iteration < __loop50_results.Count; ++__loop50_iteration)
                {
                    var __tmp29 = __loop50_results[__loop50_iteration];
                    var __loop50_var1 = __tmp29.__loop50_var1;
                    var op = __tmp29.op;
                    __out.AppendLine(true); //793:2
                    __out.Write("	/// <summary>"); //794:1
                    __out.AppendLine(false); //794:15
                    bool __tmp31_outputWritten = false;
                    string __tmp32_line = "	/// Implements the operation: "; //795:1
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
                    string __tmp34_line = "."; //795:74
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
                    string __tmp36_line = "()"; //795:84
                    if (!string.IsNullOrEmpty(__tmp36_line))
                    {
                        __out.Write(__tmp36_line);
                        __tmp31_outputWritten = true;
                    }
                    if (__tmp31_outputWritten) __out.AppendLine(true);
                    if (__tmp31_outputWritten)
                    {
                        __out.AppendLine(false); //795:86
                    }
                    __out.Write("	/// </summary>"); //796:1
                    __out.AppendLine(false); //796:16
                    bool __tmp38_outputWritten = false;
                    string __tmp39_line = "	public override "; //797:1
                    if (!string.IsNullOrEmpty(__tmp39_line))
                    {
                        __out.Write(__tmp39_line);
                        __tmp38_outputWritten = true;
                    }
                    var __tmp40 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp40.Write(CSharpName(GetMetaType(op), model, ClassKind.BuilderOperation, true));
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
                    string __tmp41_line = " "; //797:87
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
                    string __tmp43_line = "_"; //797:132
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
                    string __tmp45_line = "("; //797:142
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
                    string __tmp47_line = ")"; //797:206
                    if (!string.IsNullOrEmpty(__tmp47_line))
                    {
                        __out.Write(__tmp47_line);
                        __tmp38_outputWritten = true;
                    }
                    if (__tmp38_outputWritten) __out.AppendLine(true);
                    if (__tmp38_outputWritten)
                    {
                        __out.AppendLine(false); //797:207
                    }
                    __out.Write("	{"); //798:1
                    __out.AppendLine(false); //798:3
                    bool __tmp49_outputWritten = false;
                    string __tmp48Prefix = "		"; //799:1
                    var __tmp50 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp50.Write(GetDefaultReturn(CSharpName(GetMetaType(op), model, ClassKind.BuilderOperation, true)));
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
                        __out.AppendLine(false); //799:90
                    }
                    __out.Write("	}"); //800:1
                    __out.AppendLine(false); //800:3
                }
                __out.AppendLine(true); //802:2
            }
            var __loop51_results = 
                (from __loop51_var1 in __Enumerate((model).GetEnumerator()) //804:8
                from Namespace in __Enumerate((__loop51_var1.Namespace).GetEnumerator()) //804:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //804:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //804:40
                select new { __loop51_var1 = __loop51_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //804:3
            for (int __loop51_iteration = 0; __loop51_iteration < __loop51_results.Count; ++__loop51_iteration)
            {
                var __tmp51 = __loop51_results[__loop51_iteration];
                var __loop51_var1 = __tmp51.__loop51_var1;
                var Namespace = __tmp51.Namespace;
                var Declarations = __tmp51.Declarations;
                var enm = __tmp51.enm;
                var __loop52_results = 
                    (from __loop52_var1 in __Enumerate((enm).GetEnumerator()) //805:8
                    from op in __Enumerate((__loop52_var1.Operations).GetEnumerator()) //805:13
                    select new { __loop52_var1 = __loop52_var1, op = op}
                    ).ToList(); //805:3
                for (int __loop52_iteration = 0; __loop52_iteration < __loop52_results.Count; ++__loop52_iteration)
                {
                    var __tmp52 = __loop52_results[__loop52_iteration];
                    var __loop52_var1 = __tmp52.__loop52_var1;
                    var op = __tmp52.op;
                    __out.AppendLine(true); //806:2
                    __out.Write("	/// <summary>"); //807:1
                    __out.AppendLine(false); //807:15
                    bool __tmp54_outputWritten = false;
                    string __tmp55_line = "	/// Implements the operation: "; //808:1
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
                    string __tmp57_line = "."; //808:76
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
                        __out.AppendLine(false); //808:86
                    }
                    __out.Write("	/// </summary>"); //809:1
                    __out.AppendLine(false); //809:16
                    bool __tmp60_outputWritten = false;
                    string __tmp61_line = "	public override "; //810:1
                    if (!string.IsNullOrEmpty(__tmp61_line))
                    {
                        __out.Write(__tmp61_line);
                        __tmp60_outputWritten = true;
                    }
                    var __tmp62 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp62.Write(CSharpName(GetMetaType(op), model, ClassKind.ImmutableOperation, true));
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
                    string __tmp63_line = " "; //810:89
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
                    string __tmp65_line = "_"; //810:134
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
                    string __tmp67_line = "("; //810:144
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
                    string __tmp69_line = ")"; //810:210
                    if (!string.IsNullOrEmpty(__tmp69_line))
                    {
                        __out.Write(__tmp69_line);
                        __tmp60_outputWritten = true;
                    }
                    if (__tmp60_outputWritten) __out.AppendLine(true);
                    if (__tmp60_outputWritten)
                    {
                        __out.AppendLine(false); //810:211
                    }
                    __out.Write("	{"); //811:1
                    __out.AppendLine(false); //811:3
                    bool __tmp71_outputWritten = false;
                    string __tmp70Prefix = "		"; //812:1
                    var __tmp72 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp72.Write(GetDefaultReturn(CSharpName(GetMetaType(op), model, ClassKind.ImmutableOperation, true)));
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
                        __out.AppendLine(false); //812:92
                    }
                    __out.Write("	}"); //813:1
                    __out.AppendLine(false); //813:3
                }
                __out.AppendLine(true); //815:2
            }
            __out.Write("}"); //817:1
            __out.AppendLine(false); //817:2
            return __out.ToStringAndFree();
        }

        public string GetImplParameters(MetaModel model, MetaClass cls, MetaOperation op, ClassKind kind) //820:1
        {
            string result = CSharpName(cls, model, kind) + " _this"; //821:2
            string delim = ", "; //822:2
            var __loop53_results = 
                (from __loop53_var1 in __Enumerate((op).GetEnumerator()) //823:7
                from param in __Enumerate((__loop53_var1.Parameters).GetEnumerator()) //823:11
                select new { __loop53_var1 = __loop53_var1, param = param}
                ).ToList(); //823:2
            for (int __loop53_iteration = 0; __loop53_iteration < __loop53_results.Count; ++__loop53_iteration)
            {
                var __tmp1 = __loop53_results[__loop53_iteration];
                var __loop53_var1 = __tmp1.__loop53_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(GetMetaType(param), model, kind, true) + " " + param.Name; //824:3
            }
            return result; //826:2
        }

        public string GetImplParameters(MetaModel model, MetaEnum enm, MetaOperation op, ClassKind kind) //829:1
        {
            string result = CSharpName(enm, model, kind) + " _this"; //830:2
            string delim = ", "; //831:2
            var __loop54_results = 
                (from __loop54_var1 in __Enumerate((op).GetEnumerator()) //832:7
                from param in __Enumerate((__loop54_var1.Parameters).GetEnumerator()) //832:11
                select new { __loop54_var1 = __loop54_var1, param = param}
                ).ToList(); //832:2
            for (int __loop54_iteration = 0; __loop54_iteration < __loop54_results.Count; ++__loop54_iteration)
            {
                var __tmp1 = __loop54_results[__loop54_iteration];
                var __loop54_var1 = __tmp1.__loop54_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(GetMetaType(param), model, kind, true) + " " + param.Name; //833:3
            }
            return result; //835:2
        }

        public string GenerateEnum(MetaModel model, MetaEnum enm) //839:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.AppendLine(true); //840:1
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
                __out.AppendLine(false); //841:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public enum "; //842:1
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
                __out.AppendLine(false); //842:36
            }
            __out.Write("{"); //843:1
            __out.AppendLine(false); //843:2
            var __loop55_results = 
                (from __loop55_var1 in __Enumerate((enm).GetEnumerator()) //844:8
                from value in __Enumerate((__loop55_var1.EnumLiterals).GetEnumerator()) //844:13
                select new { __loop55_var1 = __loop55_var1, value = value}
                ).ToList(); //844:3
            for (int __loop55_iteration = 0; __loop55_iteration < __loop55_results.Count; ++__loop55_iteration)
            {
                string delim; //844:31
                if (__loop55_iteration+1 < __loop55_results.Count) delim = ",";
                else delim = string.Empty;
                var __tmp8 = __loop55_results[__loop55_iteration];
                var __loop55_var1 = __tmp8.__loop55_var1;
                var value = __tmp8.value;
                bool __tmp10_outputWritten = false;
                string __tmp9Prefix = "	"; //845:1
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
                    __out.AppendLine(false); //845:32
                }
                bool __tmp13_outputWritten = false;
                string __tmp12Prefix = "	"; //846:1
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
                    __out.AppendLine(false); //846:21
                }
            }
            __out.Write("}"); //848:1
            __out.AppendLine(false); //848:2
            __out.AppendLine(true); //849:1
            bool __tmp17_outputWritten = false;
            string __tmp18_line = "public static class "; //850:1
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
            string __tmp20_line = "Extensions"; //850:31
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Write(__tmp20_line);
                __tmp17_outputWritten = true;
            }
            if (__tmp17_outputWritten) __out.AppendLine(true);
            if (__tmp17_outputWritten)
            {
                __out.AppendLine(false); //850:41
            }
            __out.Write("{"); //851:1
            __out.AppendLine(false); //851:2
            var __loop56_results = 
                (from __loop56_var1 in __Enumerate((enm).GetEnumerator()) //852:8
                from op in __Enumerate((__loop56_var1.Operations).GetEnumerator()) //852:13
                select new { __loop56_var1 = __loop56_var1, op = op}
                ).ToList(); //852:3
            for (int __loop56_iteration = 0; __loop56_iteration < __loop56_results.Count; ++__loop56_iteration)
            {
                var __tmp21 = __loop56_results[__loop56_iteration];
                var __loop56_var1 = __tmp21.__loop56_var1;
                var op = __tmp21.op;
                bool __tmp23_outputWritten = false;
                string __tmp24_line = "	public static "; //853:1
                if (!string.IsNullOrEmpty(__tmp24_line))
                {
                    __out.Write(__tmp24_line);
                    __tmp23_outputWritten = true;
                }
                var __tmp25 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp25.Write(CSharpName(GetMetaType(op), model, ClassKind.ImmutableOperation));
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
                string __tmp26_line = " "; //853:81
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
                string __tmp28_line = "("; //853:91
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
                string __tmp30_line = ")"; //853:161
                if (!string.IsNullOrEmpty(__tmp30_line))
                {
                    __out.Write(__tmp30_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //853:162
                }
                __out.Write("	{"); //854:1
                __out.AppendLine(false); //854:3
                bool __tmp32_outputWritten = false;
                string __tmp31Prefix = "		"; //855:1
                var __tmp33 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp33.Write(GetReturn(CSharpName(GetMetaType(op), model, ClassKind.ImmutableOperation)));
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
                string __tmp35_line = ".Implementation."; //855:131
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
                string __tmp37_line = "_"; //855:195
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
                string __tmp39_line = "("; //855:205
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
                string __tmp41_line = ");"; //855:278
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Write(__tmp41_line);
                    __tmp32_outputWritten = true;
                }
                if (__tmp32_outputWritten) __out.AppendLine(true);
                if (__tmp32_outputWritten)
                {
                    __out.AppendLine(false); //855:280
                }
                __out.Write("	}"); //856:1
                __out.AppendLine(false); //856:3
            }
            __out.Write("}"); //858:1
            __out.AppendLine(false); //858:2
            return __out.ToStringAndFree();
        }

        public string GetEnumImplParameters(MetaModel model, MetaEnum enm, MetaOperation op, ClassKind kind) //861:1
        {
            string result = "this " + CSharpName(enm, model, kind) + " _this"; //862:2
            string delim = ", "; //863:2
            var __loop57_results = 
                (from __loop57_var1 in __Enumerate((op).GetEnumerator()) //864:7
                from param in __Enumerate((__loop57_var1.Parameters).GetEnumerator()) //864:11
                select new { __loop57_var1 = __loop57_var1, param = param}
                ).ToList(); //864:2
            for (int __loop57_iteration = 0; __loop57_iteration < __loop57_results.Count; ++__loop57_iteration)
            {
                var __tmp1 = __loop57_results[__loop57_iteration];
                var __loop57_var1 = __tmp1.__loop57_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(GetMetaType(param), model, kind) + " " + param.Name; //865:3
            }
            return result; //867:2
        }

        public string GetEnumImplCallParameterNames(MetaModel model, MetaOperation op, ClassKind kind) //870:1
        {
            string result = "_this"; //871:2
            string delim = ", "; //872:2
            var __loop58_results = 
                (from __loop58_var1 in __Enumerate((op).GetEnumerator()) //873:7
                from param in __Enumerate((__loop58_var1.Parameters).GetEnumerator()) //873:11
                select new { __loop58_var1 = __loop58_var1, param = param}
                ).ToList(); //873:2
            for (int __loop58_iteration = 0; __loop58_iteration < __loop58_results.Count; ++__loop58_iteration)
            {
                var __tmp1 = __loop58_results[__loop58_iteration];
                var __loop58_var1 = __tmp1.__loop58_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //874:3
            }
            return result; //876:2
        }

        public string GetClassParameters(MetaModel model, MetaClass cls, MetaOperation op, ClassKind kind) //879:1
        {
            string result = ""; //880:2
            var __loop59_results = 
                (from __loop59_var1 in __Enumerate((op).GetEnumerator()) //881:7
                from param in __Enumerate((__loop59_var1.Parameters).GetEnumerator()) //881:11
                select new { __loop59_var1 = __loop59_var1, param = param}
                ).ToList(); //881:2
            for (int __loop59_iteration = 0; __loop59_iteration < __loop59_results.Count; ++__loop59_iteration)
            {
                string delim; //881:27
                if (__loop59_iteration+1 < __loop59_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop59_results[__loop59_iteration];
                var __loop59_var1 = __tmp1.__loop59_var1;
                var param = __tmp1.param;
                result += CSharpName(GetMetaType(param), model, kind, true) + " " + param.Name + delim; //882:3
            }
            return result; //884:2
        }

        public string GetClassImplCallParameterNames(MetaModel model, MetaOperation op, ClassKind kind) //887:1
        {
            string result = "this"; //888:2
            string delim = ", "; //889:2
            var __loop60_results = 
                (from __loop60_var1 in __Enumerate((op).GetEnumerator()) //890:7
                from param in __Enumerate((__loop60_var1.Parameters).GetEnumerator()) //890:11
                select new { __loop60_var1 = __loop60_var1, param = param}
                ).ToList(); //890:2
            for (int __loop60_iteration = 0; __loop60_iteration < __loop60_results.Count; ++__loop60_iteration)
            {
                var __tmp1 = __loop60_results[__loop60_iteration];
                var __loop60_var1 = __tmp1.__loop60_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //891:3
            }
            return result; //893:2
        }

        public string GetReturn(string returnType) //896:1
        {
            if (returnType == "void") //897:5
            {
                return ""; //898:3
            }
            else //899:2
            {
                return "return "; //900:3
            }
        }

        public string GetDefaultReturn(string returnType) //904:1
        {
            if (returnType == "void") //905:5
            {
                return ""; //906:3
            }
            else //907:2
            {
                return "return default(" + returnType + ");"; //908:3
            }
        }

        public string GenerateClass(MetaModel model, MetaClass cls) //912:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.AppendLine(true); //913:1
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
                __out.AppendLine(false); //914:37
            }
            __out.AppendLine(true); //915:1
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
                __out.AppendLine(false); //916:35
            }
            return __out.ToStringAndFree();
        }

        public string GenerateClassInternal(MetaModel model, MetaClass cls) //919:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.AppendLine(true); //920:1
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
                __out.AppendLine(false); //921:30
            }
            __out.AppendLine(true); //922:1
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
                __out.AppendLine(false); //923:41
            }
            __out.AppendLine(true); //924:1
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
                __out.AppendLine(false); //925:39
            }
            return __out.ToStringAndFree();
        }

        public string GenerateIdClass(MetaModel model, MetaClass cls) //928:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //929:1
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
            string __tmp5_line = " : "; //929:53
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
            string __tmp7_line = ".ObjectId"; //929:75
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //929:84
            }
            __out.Write("{"); //930:1
            __out.AppendLine(false); //930:2
            bool __tmp9_outputWritten = false;
            string __tmp10_line = "	public override "; //931:1
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
            string __tmp12_line = ".ModelObjectDescriptor Descriptor { get { return "; //931:37
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
            string __tmp14_line = ".MDescriptor; } }"; //931:136
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Write(__tmp14_line);
                __tmp9_outputWritten = true;
            }
            if (__tmp9_outputWritten) __out.AppendLine(true);
            if (__tmp9_outputWritten)
            {
                __out.AppendLine(false); //931:153
            }
            __out.AppendLine(true); //932:1
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "	public override "; //933:1
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
            string __tmp19_line = ".ImmutableObjectBase CreateImmutable("; //933:37
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
            string __tmp21_line = ".ImmutableModel model)"; //933:93
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //933:115
            }
            __out.Write("	{"); //934:1
            __out.AppendLine(false); //934:3
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "		return new "; //935:1
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
            string __tmp26_line = "(this, model);"; //935:62
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Write(__tmp26_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //935:76
            }
            __out.Write("	}"); //936:1
            __out.AppendLine(false); //936:3
            __out.AppendLine(true); //937:1
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "	public override "; //938:1
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
            string __tmp31_line = ".MutableObjectBase CreateMutable("; //938:37
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
            string __tmp33_line = ".MutableModel model, bool creating)"; //938:89
            if (!string.IsNullOrEmpty(__tmp33_line))
            {
                __out.Write(__tmp33_line);
                __tmp28_outputWritten = true;
            }
            if (__tmp28_outputWritten) __out.AppendLine(true);
            if (__tmp28_outputWritten)
            {
                __out.AppendLine(false); //938:124
            }
            __out.Write("	{"); //939:1
            __out.AppendLine(false); //939:3
            bool __tmp35_outputWritten = false;
            string __tmp36_line = "		return new "; //940:1
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
            string __tmp38_line = "(this, model, creating);"; //940:60
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Write(__tmp38_line);
                __tmp35_outputWritten = true;
            }
            if (__tmp35_outputWritten) __out.AppendLine(true);
            if (__tmp35_outputWritten)
            {
                __out.AppendLine(false); //940:84
            }
            __out.Write("	}"); //941:1
            __out.AppendLine(false); //941:3
            __out.Write("}"); //942:1
            __out.AppendLine(false); //942:2
            return __out.ToStringAndFree();
        }

        public string GenerateImmutableClass(MetaModel model, MetaClass cls) //945:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool metaMetaModel = IsMetaMetaModel(model); //946:2
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
                __out.AppendLine(false); //947:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public interface "; //948:1
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
                __out.AppendLine(false); //948:97
            }
            __out.Write("{"); //949:1
            __out.AppendLine(false); //949:2
            var __loop61_results = 
                (from __loop61_var1 in __Enumerate((cls).GetEnumerator()) //950:8
                from prop in __Enumerate((__loop61_var1.Properties).GetEnumerator()) //950:13
                select new { __loop61_var1 = __loop61_var1, prop = prop}
                ).ToList(); //950:3
            for (int __loop61_iteration = 0; __loop61_iteration < __loop61_results.Count; ++__loop61_iteration)
            {
                var __tmp9 = __loop61_results[__loop61_iteration];
                var __loop61_var1 = __tmp9.__loop61_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //951:1
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
                    __out.AppendLine(false); //951:42
                }
            }
            __out.AppendLine(true); //953:1
            var __loop62_results = 
                (from __loop62_var1 in __Enumerate((cls).GetEnumerator()) //954:8
                from op in __Enumerate((__loop62_var1.Operations).GetEnumerator()) //954:13
                where !op.IsBuilder //954:27
                select new { __loop62_var1 = __loop62_var1, op = op}
                ).ToList(); //954:3
            for (int __loop62_iteration = 0; __loop62_iteration < __loop62_results.Count; ++__loop62_iteration)
            {
                var __tmp13 = __loop62_results[__loop62_iteration];
                var __loop62_var1 = __tmp13.__loop62_var1;
                var op = __tmp13.op;
                bool __tmp15_outputWritten = false;
                string __tmp14Prefix = "	"; //955:1
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
                    __out.AppendLine(false); //955:41
                }
            }
            __out.AppendLine(true); //957:1
            __out.Write("	/// <summary>"); //958:1
            __out.AppendLine(false); //958:15
            bool __tmp18_outputWritten = false;
            string __tmp19_line = "	/// Convert the <see cref=\""; //959:1
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
            string __tmp21_line = "\"/> object to a builder <see cref=\""; //959:73
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
            string __tmp23_line = "\"/> object."; //959:150
            if (!string.IsNullOrEmpty(__tmp23_line))
            {
                __out.Write(__tmp23_line);
                __tmp18_outputWritten = true;
            }
            if (__tmp18_outputWritten) __out.AppendLine(true);
            if (__tmp18_outputWritten)
            {
                __out.AppendLine(false); //959:161
            }
            __out.Write("	/// </summary>"); //960:1
            __out.AppendLine(false); //960:16
            bool __tmp25_outputWritten = false;
            string __tmp26_line = "	new "; //961:1
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
            string __tmp28_line = " ToMutable();"; //961:54
            if (!string.IsNullOrEmpty(__tmp28_line))
            {
                __out.Write(__tmp28_line);
                __tmp25_outputWritten = true;
            }
            if (__tmp25_outputWritten) __out.AppendLine(true);
            if (__tmp25_outputWritten)
            {
                __out.AppendLine(false); //961:67
            }
            __out.Write("	/// <summary>"); //962:1
            __out.AppendLine(false); //962:15
            bool __tmp30_outputWritten = false;
            string __tmp31_line = "	/// Convert the <see cref=\""; //963:1
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
            string __tmp33_line = "\"/> object to a builder <see cref=\""; //963:73
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
            string __tmp35_line = "\"/> object"; //963:150
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Write(__tmp35_line);
                __tmp30_outputWritten = true;
            }
            if (__tmp30_outputWritten) __out.AppendLine(true);
            if (__tmp30_outputWritten)
            {
                __out.AppendLine(false); //963:160
            }
            __out.Write("	/// by taking the builder version from the given model."); //964:1
            __out.AppendLine(false); //964:57
            __out.Write("	/// </summary>"); //965:1
            __out.AppendLine(false); //965:16
            __out.Write("	/// <param name=\"model\">The mutable model from which the return value is taken from.</param>"); //966:1
            __out.AppendLine(false); //966:94
            bool __tmp37_outputWritten = false;
            string __tmp38_line = "	new "; //967:1
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
            string __tmp40_line = " ToMutable("; //967:54
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
            string __tmp42_line = ".MutableModel model);"; //967:84
            if (!string.IsNullOrEmpty(__tmp42_line))
            {
                __out.Write(__tmp42_line);
                __tmp37_outputWritten = true;
            }
            if (__tmp37_outputWritten) __out.AppendLine(true);
            if (__tmp37_outputWritten)
            {
                __out.AppendLine(false); //967:105
            }
            __out.Write("}"); //968:1
            __out.AppendLine(false); //968:2
            return __out.ToStringAndFree();
        }

        public string GenerateImmutableProperty(MetaModel model, MetaProperty prop) //971:1
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
                __out.AppendLine(false); //972:30
            }
            if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name) || (IsMetaMetaModel(model) && prop.Class.Name == "MetaModel")) //973:2
            {
                __out.Write("new "); //974:1
            }
            bool __tmp5_outputWritten = false;
            var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp6.Write(CSharpName(GetMetaType(prop), model, ClassKind.Immutable, true));
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
            string __tmp7_line = " "; //976:65
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
            string __tmp9_line = " { get; }"; //976:114
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Write(__tmp9_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //976:123
            }
            return __out.ToStringAndFree();
        }

        public string GenerateImmutableOperation(MetaModel model, MetaOperation op) //979:1
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
                __out.AppendLine(false); //980:28
            }
            bool __tmp5_outputWritten = false;
            var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp6.Write(CSharpName(GetMetaType(op), model, ClassKind.ImmutableOperation, true));
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
            string __tmp7_line = " "; //981:72
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
            string __tmp9_line = "("; //981:82
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
            string __tmp11_line = ");"; //981:157
            if (!string.IsNullOrEmpty(__tmp11_line))
            {
                __out.Write(__tmp11_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //981:159
            }
            return __out.ToStringAndFree();
        }

        public string GetImmutableOperationParameters(MetaModel model, MetaOperation op, ClassKind kind) //984:1
        {
            string result = ""; //985:2
            var __loop63_results = 
                (from __loop63_var1 in __Enumerate((op).GetEnumerator()) //986:7
                from param in __Enumerate((__loop63_var1.Parameters).GetEnumerator()) //986:11
                select new { __loop63_var1 = __loop63_var1, param = param}
                ).ToList(); //986:2
            for (int __loop63_iteration = 0; __loop63_iteration < __loop63_results.Count; ++__loop63_iteration)
            {
                string delim; //986:27
                if (__loop63_iteration+1 < __loop63_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop63_results[__loop63_iteration];
                var __loop63_var1 = __tmp1.__loop63_var1;
                var param = __tmp1.param;
                result += CSharpName(GetMetaType(param), model, kind, true) + " " + param.Name + delim; //987:3
            }
            return result; //989:2
        }

        public string GetImmutableAncestors(MetaModel model, MetaClass cls) //992:1
        {
            string result = ""; //993:2
            var __loop64_results = 
                (from __loop64_var1 in __Enumerate((cls).GetEnumerator()) //994:7
                from super in __Enumerate((__loop64_var1.SuperClasses).GetEnumerator()) //994:12
                select new { __loop64_var1 = __loop64_var1, super = super}
                ).ToList(); //994:2
            for (int __loop64_iteration = 0; __loop64_iteration < __loop64_results.Count; ++__loop64_iteration)
            {
                string delim; //994:30
                if (__loop64_iteration+1 < __loop64_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop64_results[__loop64_iteration];
                var __loop64_var1 = __tmp1.__loop64_var1;
                var super = __tmp1.super;
                result += CSharpName(super, model, ClassKind.Immutable, true) + delim; //995:3
            }
            if (result == "") //997:2
            {
                result = Properties.CoreNs + ".ImmutableObject"; //998:3
            }
            result = " : " + result; //1000:2
            return result; //1001:2
        }

        public string GenerateBuilderClass(MetaModel model, MetaClass cls) //1004:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool metaMetaModel = IsMetaMetaModel(model); //1005:2
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
                __out.AppendLine(false); //1006:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public interface "; //1007:1
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
                __out.AppendLine(false); //1007:93
            }
            __out.Write("{"); //1008:1
            __out.AppendLine(false); //1008:2
            var __loop65_results = 
                (from __loop65_var1 in __Enumerate((cls).GetEnumerator()) //1009:8
                from prop in __Enumerate((__loop65_var1.Properties).GetEnumerator()) //1009:13
                select new { __loop65_var1 = __loop65_var1, prop = prop}
                ).ToList(); //1009:3
            for (int __loop65_iteration = 0; __loop65_iteration < __loop65_results.Count; ++__loop65_iteration)
            {
                var __tmp9 = __loop65_results[__loop65_iteration];
                var __loop65_var1 = __tmp9.__loop65_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //1010:1
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
                    __out.AppendLine(false); //1010:40
                }
            }
            __out.AppendLine(true); //1012:1
            var __loop66_results = 
                (from __loop66_var1 in __Enumerate((cls).GetEnumerator()) //1013:8
                from op in __Enumerate((__loop66_var1.Operations).GetEnumerator()) //1013:13
                select new { __loop66_var1 = __loop66_var1, op = op}
                ).ToList(); //1013:3
            for (int __loop66_iteration = 0; __loop66_iteration < __loop66_results.Count; ++__loop66_iteration)
            {
                var __tmp13 = __loop66_results[__loop66_iteration];
                var __loop66_var1 = __tmp13.__loop66_var1;
                var op = __tmp13.op;
                bool __tmp15_outputWritten = false;
                string __tmp14Prefix = "	"; //1014:1
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
                    __out.AppendLine(false); //1014:39
                }
            }
            __out.AppendLine(true); //1016:1
            __out.Write("	/// <summary>"); //1017:1
            __out.AppendLine(false); //1017:15
            bool __tmp18_outputWritten = false;
            string __tmp19_line = "	/// Convert the <see cref=\""; //1018:1
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
            string __tmp21_line = "\"/> object to an immutable <see cref=\""; //1018:71
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
            string __tmp23_line = "\"/> object."; //1018:153
            if (!string.IsNullOrEmpty(__tmp23_line))
            {
                __out.Write(__tmp23_line);
                __tmp18_outputWritten = true;
            }
            if (__tmp18_outputWritten) __out.AppendLine(true);
            if (__tmp18_outputWritten)
            {
                __out.AppendLine(false); //1018:164
            }
            __out.Write("	/// </summary>"); //1019:1
            __out.AppendLine(false); //1019:16
            bool __tmp25_outputWritten = false;
            string __tmp26_line = "	new "; //1020:1
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
            string __tmp28_line = " ToImmutable();"; //1020:56
            if (!string.IsNullOrEmpty(__tmp28_line))
            {
                __out.Write(__tmp28_line);
                __tmp25_outputWritten = true;
            }
            if (__tmp25_outputWritten) __out.AppendLine(true);
            if (__tmp25_outputWritten)
            {
                __out.AppendLine(false); //1020:71
            }
            __out.Write("	/// <summary>"); //1021:1
            __out.AppendLine(false); //1021:15
            bool __tmp30_outputWritten = false;
            string __tmp31_line = "	/// Convert the <see cref=\""; //1022:1
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
            string __tmp33_line = "\"/> object to an immutable <see cref=\""; //1022:71
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
            string __tmp35_line = "\"/> object"; //1022:153
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Write(__tmp35_line);
                __tmp30_outputWritten = true;
            }
            if (__tmp30_outputWritten) __out.AppendLine(true);
            if (__tmp30_outputWritten)
            {
                __out.AppendLine(false); //1022:163
            }
            __out.Write("	/// by taking the immutable version from the given model."); //1023:1
            __out.AppendLine(false); //1023:59
            __out.Write("	/// </summary>"); //1024:1
            __out.AppendLine(false); //1024:16
            __out.Write("	/// <param name=\"model\">The immutable model from which the return value is taken from.</param>"); //1025:1
            __out.AppendLine(false); //1025:96
            bool __tmp37_outputWritten = false;
            string __tmp38_line = "	new "; //1026:1
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
            string __tmp40_line = " ToImmutable("; //1026:56
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
            string __tmp42_line = ".ImmutableModel model);"; //1026:88
            if (!string.IsNullOrEmpty(__tmp42_line))
            {
                __out.Write(__tmp42_line);
                __tmp37_outputWritten = true;
            }
            if (__tmp37_outputWritten) __out.AppendLine(true);
            if (__tmp37_outputWritten)
            {
                __out.AppendLine(false); //1026:111
            }
            __out.Write("}"); //1027:1
            __out.AppendLine(false); //1027:2
            return __out.ToStringAndFree();
        }

        public string GenerateBuilderProperty(MetaModel model, MetaProperty prop) //1030:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            var propType = GetMetaType(prop); //1031:2
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
                __out.AppendLine(false); //1032:30
            }
            if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name) || (IsMetaMetaModel(model) && prop.Class.Name == "MetaModel")) //1033:3
            {
                __out.Write("new "); //1034:1
            }
            if ((prop.Kind == MetaPropertyKind.Normal) && !(propType is MetaCollectionType)) //1036:3
            {
                bool __tmp5_outputWritten = false;
                var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp6.Write(CSharpName(propType, model, ClassKind.Builder, true));
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
                string __tmp7_line = " "; //1037:54
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
                string __tmp9_line = " { get; set; }"; //1037:101
                if (!string.IsNullOrEmpty(__tmp9_line))
                {
                    __out.Write(__tmp9_line);
                    __tmp5_outputWritten = true;
                }
                if (__tmp5_outputWritten) __out.AppendLine(true);
                if (__tmp5_outputWritten)
                {
                    __out.AppendLine(false); //1037:115
                }
            }
            else //1038:3
            {
                bool __tmp11_outputWritten = false;
                var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp12.Write(CSharpName(propType, model, ClassKind.Builder, true));
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
                string __tmp13_line = " "; //1039:54
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
                string __tmp15_line = " { get; }"; //1039:101
                if (!string.IsNullOrEmpty(__tmp15_line))
                {
                    __out.Write(__tmp15_line);
                    __tmp11_outputWritten = true;
                }
                if (__tmp11_outputWritten) __out.AppendLine(true);
                if (__tmp11_outputWritten)
                {
                    __out.AppendLine(false); //1039:110
                }
            }
            if (!(propType is MetaCollectionType)) //1041:3
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
                    __out.AppendLine(false); //1042:30
                }
                if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name)) //1043:4
                {
                    __out.Write("new "); //1044:1
                }
                bool __tmp20_outputWritten = false;
                string __tmp21_line = "void Set"; //1046:1
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
                string __tmp23_line = "Lazy(global::System.Func<"; //1046:55
                if (!string.IsNullOrEmpty(__tmp23_line))
                {
                    __out.Write(__tmp23_line);
                    __tmp20_outputWritten = true;
                }
                var __tmp24 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp24.Write(CSharpName(propType, model, ClassKind.Builder, true));
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
                string __tmp25_line = "> lazy);"; //1046:133
                if (!string.IsNullOrEmpty(__tmp25_line))
                {
                    __out.Write(__tmp25_line);
                    __tmp20_outputWritten = true;
                }
                if (__tmp20_outputWritten) __out.AppendLine(true);
                if (__tmp20_outputWritten)
                {
                    __out.AppendLine(false); //1046:141
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
                    __out.AppendLine(false); //1047:30
                }
                if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name)) //1048:4
                {
                    __out.Write("new "); //1049:1
                }
                bool __tmp30_outputWritten = false;
                string __tmp31_line = "void Set"; //1051:1
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
                string __tmp33_line = "Lazy(global::System.Func<"; //1051:55
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
                string __tmp35_line = ", "; //1051:129
                if (!string.IsNullOrEmpty(__tmp35_line))
                {
                    __out.Write(__tmp35_line);
                    __tmp30_outputWritten = true;
                }
                var __tmp36 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp36.Write(CSharpName(propType, model, ClassKind.Builder, true));
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
                string __tmp37_line = "> lazy);"; //1051:184
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Write(__tmp37_line);
                    __tmp30_outputWritten = true;
                }
                if (__tmp30_outputWritten) __out.AppendLine(true);
                if (__tmp30_outputWritten)
                {
                    __out.AppendLine(false); //1051:192
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
                    __out.AppendLine(false); //1052:30
                }
                if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name)) //1053:4
                {
                    __out.Write("new "); //1054:1
                }
                bool __tmp42_outputWritten = false;
                string __tmp43_line = "void Set"; //1056:1
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
                string __tmp45_line = "Lazy(global::System.Func<"; //1056:55
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
                string __tmp47_line = ", "; //1056:131
                if (!string.IsNullOrEmpty(__tmp47_line))
                {
                    __out.Write(__tmp47_line);
                    __tmp42_outputWritten = true;
                }
                var __tmp48 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp48.Write(CSharpName(propType, model, ClassKind.Immutable, true));
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
                string __tmp49_line = "> immutableLazy, global::System.Func<"; //1056:188
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
                string __tmp51_line = ", "; //1056:274
                if (!string.IsNullOrEmpty(__tmp51_line))
                {
                    __out.Write(__tmp51_line);
                    __tmp42_outputWritten = true;
                }
                var __tmp52 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp52.Write(CSharpName(propType, model, ClassKind.Builder, true));
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
                string __tmp53_line = "> mutableLazy);"; //1056:329
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Write(__tmp53_line);
                    __tmp42_outputWritten = true;
                }
                if (__tmp42_outputWritten) __out.AppendLine(true);
                if (__tmp42_outputWritten)
                {
                    __out.AppendLine(false); //1056:344
                }
            }
            return __out.ToStringAndFree();
        }

        public string GenerateBuilderOperation(MetaModel model, MetaOperation op) //1060:1
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
                __out.AppendLine(false); //1061:28
            }
            bool __tmp5_outputWritten = false;
            var __tmp6 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp6.Write(CSharpName(GetMetaType(op), model, ClassKind.BuilderOperation, true));
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
            string __tmp7_line = " "; //1062:70
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
            string __tmp9_line = "("; //1062:80
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
            string __tmp11_line = ");"; //1062:151
            if (!string.IsNullOrEmpty(__tmp11_line))
            {
                __out.Write(__tmp11_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //1062:153
            }
            return __out.ToStringAndFree();
        }

        public string GetBuilderOperationParameters(MetaModel model, MetaOperation op, ClassKind kind) //1065:1
        {
            string result = ""; //1066:2
            var __loop67_results = 
                (from __loop67_var1 in __Enumerate((op).GetEnumerator()) //1067:7
                from param in __Enumerate((__loop67_var1.Parameters).GetEnumerator()) //1067:11
                select new { __loop67_var1 = __loop67_var1, param = param}
                ).ToList(); //1067:2
            for (int __loop67_iteration = 0; __loop67_iteration < __loop67_results.Count; ++__loop67_iteration)
            {
                string delim; //1067:27
                if (__loop67_iteration+1 < __loop67_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop67_results[__loop67_iteration];
                var __loop67_var1 = __tmp1.__loop67_var1;
                var param = __tmp1.param;
                result += CSharpName(GetMetaType(param), model, kind, true) + " " + param.Name + delim; //1068:3
            }
            return result; //1070:2
        }

        public string GetBuilderAncestors(MetaModel model, MetaClass cls) //1073:1
        {
            string result = ""; //1074:2
            var __loop68_results = 
                (from __loop68_var1 in __Enumerate((cls).GetEnumerator()) //1075:7
                from super in __Enumerate((__loop68_var1.SuperClasses).GetEnumerator()) //1075:12
                select new { __loop68_var1 = __loop68_var1, super = super}
                ).ToList(); //1075:2
            for (int __loop68_iteration = 0; __loop68_iteration < __loop68_results.Count; ++__loop68_iteration)
            {
                string delim; //1075:30
                if (__loop68_iteration+1 < __loop68_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop68_results[__loop68_iteration];
                var __loop68_var1 = __tmp1.__loop68_var1;
                var super = __tmp1.super;
                result += CSharpName(super, model, ClassKind.Builder, true) + delim; //1076:3
            }
            if (result == "") //1078:2
            {
                result = Properties.CoreNs + ".MutableObject"; //1079:3
            }
            result = " : " + result; //1081:2
            return result; //1082:2
        }

        public string GenerateImmutableImplClass(MetaModel model, MetaClass cls) //1085:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool metaMetaModel = IsMetaMetaModel(model); //1086:2
            string metaNs = metaMetaModel ? "" : Properties.MetaNs + "."; //1087:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //1088:1
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
            string __tmp5_line = " : "; //1088:64
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
            string __tmp7_line = ".ImmutableObjectBase, "; //1088:86
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
                __out.AppendLine(false); //1088:152
            }
            __out.Write("{"); //1089:1
            __out.AppendLine(false); //1089:2
            var __loop69_results = 
                (from __loop69_var1 in __Enumerate((cls).GetEnumerator()) //1090:8
                from prop in __Enumerate((__loop69_var1.GetAllProperties()).GetEnumerator()) //1090:13
                select new { __loop69_var1 = __loop69_var1, prop = prop}
                ).ToList(); //1090:3
            for (int __loop69_iteration = 0; __loop69_iteration < __loop69_results.Count; ++__loop69_iteration)
            {
                var __tmp9 = __loop69_results[__loop69_iteration];
                var __loop69_var1 = __tmp9.__loop69_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //1091:1
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
                    __out.AppendLine(false); //1091:44
                }
            }
            __out.AppendLine(true); //1093:2
            bool __tmp14_outputWritten = false;
            string __tmp15_line = "	internal "; //1094:1
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
            string __tmp17_line = "("; //1094:59
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
            string __tmp19_line = ".ObjectId id, "; //1094:79
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
            string __tmp21_line = ".ImmutableModel model)"; //1094:112
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp14_outputWritten = true;
            }
            if (__tmp14_outputWritten) __out.AppendLine(true);
            if (__tmp14_outputWritten)
            {
                __out.AppendLine(false); //1094:134
            }
            __out.Write("		: base(id, model)"); //1095:1
            __out.AppendLine(false); //1095:20
            __out.Write("	{"); //1096:1
            __out.AppendLine(false); //1096:3
            __out.Write("	}"); //1097:1
            __out.AppendLine(false); //1097:3
            __out.AppendLine(true); //1098:2
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "	public override "; //1099:1
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
            string __tmp26_line = ".ModelMetadata MMetadata => "; //1099:37
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
            string __tmp28_line = ".MMetadata;"; //1099:118
            if (!string.IsNullOrEmpty(__tmp28_line))
            {
                __out.Write(__tmp28_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //1099:129
            }
            __out.AppendLine(true); //1100:2
            bool __tmp30_outputWritten = false;
            string __tmp31_line = "	public override "; //1101:1
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
            string __tmp33_line = "MetaClass MMetaClass => "; //1101:26
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
            string __tmp35_line = ";"; //1101:108
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Write(__tmp35_line);
                __tmp30_outputWritten = true;
            }
            if (__tmp30_outputWritten) __out.AppendLine(true);
            if (__tmp30_outputWritten)
            {
                __out.AppendLine(false); //1101:109
            }
            __out.AppendLine(true); //1102:2
            bool __tmp37_outputWritten = false;
            string __tmp38_line = "	public new "; //1103:1
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
            string __tmp40_line = " ToMutable()"; //1103:55
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Write(__tmp40_line);
                __tmp37_outputWritten = true;
            }
            if (__tmp37_outputWritten) __out.AppendLine(true);
            if (__tmp37_outputWritten)
            {
                __out.AppendLine(false); //1103:67
            }
            __out.Write("	{"); //1104:1
            __out.AppendLine(false); //1104:3
            bool __tmp42_outputWritten = false;
            string __tmp43_line = "		return ("; //1105:1
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
            string __tmp45_line = ")base.ToMutable();"; //1105:53
            if (!string.IsNullOrEmpty(__tmp45_line))
            {
                __out.Write(__tmp45_line);
                __tmp42_outputWritten = true;
            }
            if (__tmp42_outputWritten) __out.AppendLine(true);
            if (__tmp42_outputWritten)
            {
                __out.AppendLine(false); //1105:71
            }
            __out.Write("	}"); //1106:1
            __out.AppendLine(false); //1106:3
            __out.AppendLine(true); //1107:2
            bool __tmp47_outputWritten = false;
            string __tmp48_line = "	public new "; //1108:1
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
            string __tmp50_line = " ToMutable("; //1108:55
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
            string __tmp52_line = ".MutableModel model)"; //1108:85
            if (!string.IsNullOrEmpty(__tmp52_line))
            {
                __out.Write(__tmp52_line);
                __tmp47_outputWritten = true;
            }
            if (__tmp47_outputWritten) __out.AppendLine(true);
            if (__tmp47_outputWritten)
            {
                __out.AppendLine(false); //1108:105
            }
            __out.Write("	{"); //1109:1
            __out.AppendLine(false); //1109:3
            bool __tmp54_outputWritten = false;
            string __tmp55_line = "		return ("; //1110:1
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
            string __tmp57_line = ")base.ToMutable(model);"; //1110:53
            if (!string.IsNullOrEmpty(__tmp57_line))
            {
                __out.Write(__tmp57_line);
                __tmp54_outputWritten = true;
            }
            if (__tmp54_outputWritten) __out.AppendLine(true);
            if (__tmp54_outputWritten)
            {
                __out.AppendLine(false); //1110:76
            }
            __out.Write("	}"); //1111:1
            __out.AppendLine(false); //1111:3
            var __loop70_results = 
                (from __loop70_var1 in __Enumerate((cls).GetEnumerator()) //1112:8
                from sup in __Enumerate((__loop70_var1.GetAllSuperClasses(false)).GetEnumerator()) //1112:13
                select new { __loop70_var1 = __loop70_var1, sup = sup}
                ).ToList(); //1112:3
            for (int __loop70_iteration = 0; __loop70_iteration < __loop70_results.Count; ++__loop70_iteration)
            {
                var __tmp58 = __loop70_results[__loop70_iteration];
                var __loop70_var1 = __tmp58.__loop70_var1;
                var sup = __tmp58.sup;
                __out.AppendLine(true); //1113:2
                bool __tmp60_outputWritten = false;
                string __tmp59Prefix = "	"; //1114:1
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
                string __tmp62_line = " "; //1114:50
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
                string __tmp64_line = ".ToMutable()"; //1114:101
                if (!string.IsNullOrEmpty(__tmp64_line))
                {
                    __out.Write(__tmp64_line);
                    __tmp60_outputWritten = true;
                }
                if (__tmp60_outputWritten) __out.AppendLine(true);
                if (__tmp60_outputWritten)
                {
                    __out.AppendLine(false); //1114:113
                }
                __out.Write("	{"); //1115:1
                __out.AppendLine(false); //1115:3
                __out.Write("		return this.ToMutable();"); //1116:1
                __out.AppendLine(false); //1116:27
                __out.Write("	}"); //1117:1
                __out.AppendLine(false); //1117:3
                __out.AppendLine(true); //1118:2
                bool __tmp66_outputWritten = false;
                string __tmp65Prefix = "	"; //1119:1
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
                string __tmp68_line = " "; //1119:50
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
                string __tmp70_line = ".ToMutable("; //1119:101
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
                string __tmp72_line = ".MutableModel model)"; //1119:131
                if (!string.IsNullOrEmpty(__tmp72_line))
                {
                    __out.Write(__tmp72_line);
                    __tmp66_outputWritten = true;
                }
                if (__tmp66_outputWritten) __out.AppendLine(true);
                if (__tmp66_outputWritten)
                {
                    __out.AppendLine(false); //1119:151
                }
                __out.Write("	{"); //1120:1
                __out.AppendLine(false); //1120:3
                __out.Write("		return this.ToMutable(model);"); //1121:1
                __out.AppendLine(false); //1121:32
                __out.Write("	}"); //1122:1
                __out.AppendLine(false); //1122:3
            }
            var __loop71_results = 
                (from __loop71_var1 in __Enumerate((cls).GetEnumerator()) //1124:8
                from prop in __Enumerate((__loop71_var1.GetAllProperties()).GetEnumerator()) //1124:13
                select new { __loop71_var1 = __loop71_var1, prop = prop}
                ).ToList(); //1124:3
            for (int __loop71_iteration = 0; __loop71_iteration < __loop71_results.Count; ++__loop71_iteration)
            {
                var __tmp73 = __loop71_results[__loop71_iteration];
                var __loop71_var1 = __tmp73.__loop71_var1;
                var prop = __tmp73.prop;
                __out.AppendLine(true); //1125:2
                bool __tmp75_outputWritten = false;
                string __tmp74Prefix = "	"; //1126:1
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
                    __out.AppendLine(false); //1126:51
                }
            }
            var __loop72_results = 
                (from __loop72_var1 in __Enumerate((cls).GetEnumerator()) //1128:8
                from op in __Enumerate((__loop72_var1.GetAllOperations()).GetEnumerator()) //1128:13
                where !op.IsBuilder //1128:35
                select new { __loop72_var1 = __loop72_var1, op = op}
                ).ToList(); //1128:3
            for (int __loop72_iteration = 0; __loop72_iteration < __loop72_results.Count; ++__loop72_iteration)
            {
                var __tmp77 = __loop72_results[__loop72_iteration];
                var __loop72_var1 = __tmp77.__loop72_var1;
                var op = __tmp77.op;
                __out.AppendLine(true); //1129:2
                bool __tmp79_outputWritten = false;
                string __tmp78Prefix = "	"; //1130:1
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
                    __out.AppendLine(false); //1130:50
                }
            }
            __out.Write("}"); //1132:1
            __out.AppendLine(false); //1132:2
            return __out.ToStringAndFree();
        }

        public string GenerateImmutableField(MetaModel model, MetaClass cls, MetaProperty prop) //1135:1
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
                __out.AppendLine(false); //1136:54
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "private "; //1137:1
            if (!string.IsNullOrEmpty(__tmp6_line))
            {
                __out.Write(__tmp6_line);
                __tmp5_outputWritten = true;
            }
            var __tmp7 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp7.Write(CSharpName(GetMetaType(prop), model, ClassKind.Immutable, true));
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
            string __tmp8_line = " "; //1137:73
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
            string __tmp10_line = ";"; //1137:98
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Write(__tmp10_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //1137:99
            }
            return __out.ToStringAndFree();
        }

        public string GenerateImmutablePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //1140:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            var propType = GetMetaType(prop); //1141:2
            __out.AppendLine(true); //1142:1
            if (cls.GetAllFinalProperties().Contains(prop)) //1143:2
            {
                bool __tmp2_outputWritten = false;
                string __tmp3_line = "public "; //1144:1
                if (!string.IsNullOrEmpty(__tmp3_line))
                {
                    __out.Write(__tmp3_line);
                    __tmp2_outputWritten = true;
                }
                var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp4.Write(CSharpName(propType, model, ClassKind.Immutable, true));
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
                string __tmp5_line = " "; //1144:63
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
                    __out.AppendLine(false); //1144:75
                }
            }
            else //1145:2
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
                    __out.AppendLine(false); //1146:54
                }
                bool __tmp11_outputWritten = false;
                var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp12.Write(CSharpName(propType, model, ClassKind.Immutable, true));
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
                string __tmp13_line = " "; //1147:56
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
                string __tmp15_line = "."; //1147:114
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
                    __out.AppendLine(false); //1147:126
                }
            }
            __out.Write("{"); //1149:1
            __out.AppendLine(false); //1149:2
            if (propType is MetaCollectionType) //1150:6
            {
                if (((MetaCollectionType)propType).Kind == MetaCollectionKind.Set || ((MetaCollectionType)propType).Kind == MetaCollectionKind.MultiSet) //1151:4
                {
                    bool __tmp18_outputWritten = false;
                    string __tmp19_line = "    get { return this.GetSet<"; //1152:1
                    if (!string.IsNullOrEmpty(__tmp19_line))
                    {
                        __out.Write(__tmp19_line);
                        __tmp18_outputWritten = true;
                    }
                    var __tmp20 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp20.Write(CSharpName(((MetaCollectionType)propType).InnerType, model, ClassKind.Immutable, true));
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
                    string __tmp21_line = ">("; //1152:117
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
                    string __tmp23_line = ", ref "; //1152:173
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
                    string __tmp25_line = "); }"; //1152:203
                    if (!string.IsNullOrEmpty(__tmp25_line))
                    {
                        __out.Write(__tmp25_line);
                        __tmp18_outputWritten = true;
                    }
                    if (__tmp18_outputWritten) __out.AppendLine(true);
                    if (__tmp18_outputWritten)
                    {
                        __out.AppendLine(false); //1152:207
                    }
                }
                else //1153:4
                {
                    bool __tmp27_outputWritten = false;
                    string __tmp28_line = "    get { return this.GetList<"; //1154:1
                    if (!string.IsNullOrEmpty(__tmp28_line))
                    {
                        __out.Write(__tmp28_line);
                        __tmp27_outputWritten = true;
                    }
                    var __tmp29 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp29.Write(CSharpName(((MetaCollectionType)propType).InnerType, model, ClassKind.Immutable, true));
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
                    string __tmp30_line = ">("; //1154:118
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
                    string __tmp32_line = ", ref "; //1154:174
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
                    string __tmp34_line = "); }"; //1154:204
                    if (!string.IsNullOrEmpty(__tmp34_line))
                    {
                        __out.Write(__tmp34_line);
                        __tmp27_outputWritten = true;
                    }
                    if (__tmp27_outputWritten) __out.AppendLine(true);
                    if (__tmp27_outputWritten)
                    {
                        __out.AppendLine(false); //1154:208
                    }
                }
            }
            else if (IsReferenceType(propType)) //1156:3
            {
                bool __tmp36_outputWritten = false;
                string __tmp37_line = "    get { return this.GetReference<"; //1157:1
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Write(__tmp37_line);
                    __tmp36_outputWritten = true;
                }
                var __tmp38 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp38.Write(CSharpName(propType, model, ClassKind.Immutable, true));
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
                string __tmp39_line = ">("; //1157:91
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
                string __tmp41_line = ", ref "; //1157:147
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
                string __tmp43_line = "); }"; //1157:177
                if (!string.IsNullOrEmpty(__tmp43_line))
                {
                    __out.Write(__tmp43_line);
                    __tmp36_outputWritten = true;
                }
                if (__tmp36_outputWritten) __out.AppendLine(true);
                if (__tmp36_outputWritten)
                {
                    __out.AppendLine(false); //1157:181
                }
            }
            else //1158:3
            {
                bool __tmp45_outputWritten = false;
                string __tmp46_line = "    get { return this.GetValue<"; //1159:1
                if (!string.IsNullOrEmpty(__tmp46_line))
                {
                    __out.Write(__tmp46_line);
                    __tmp45_outputWritten = true;
                }
                var __tmp47 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp47.Write(CSharpName(propType, model, ClassKind.Immutable, true));
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
                string __tmp48_line = ">("; //1159:87
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
                string __tmp50_line = ", ref "; //1159:143
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
                string __tmp52_line = "); }"; //1159:173
                if (!string.IsNullOrEmpty(__tmp52_line))
                {
                    __out.Write(__tmp52_line);
                    __tmp45_outputWritten = true;
                }
                if (__tmp45_outputWritten) __out.AppendLine(true);
                if (__tmp45_outputWritten)
                {
                    __out.AppendLine(false); //1159:177
                }
            }
            __out.Write("}"); //1161:1
            __out.AppendLine(false); //1161:2
            return __out.ToStringAndFree();
        }

        public string GenerateImmutableOperationImpl(MetaModel model, MetaClass cls, MetaOperation op) //1164:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.AppendLine(true); //1165:1
            bool __tmp2_outputWritten = false;
            var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp3.Write(CSharpName(GetMetaType(op), model, ClassKind.ImmutableOperation, true));
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
            string __tmp4_line = " "; //1166:72
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
            string __tmp6_line = "."; //1166:128
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
            string __tmp8_line = "("; //1166:138
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
            string __tmp10_line = ")"; //1166:210
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Write(__tmp10_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //1166:211
            }
            __out.Write("{"); //1167:1
            __out.AppendLine(false); //1167:2
            var finalOp = GetFinalOperation(cls, op); //1168:2
            bool __tmp12_outputWritten = false;
            string __tmp11Prefix = "    "; //1169:1
            var __tmp13 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp13.Write(GetReturn(CSharpName(GetMetaType(finalOp), model, ClassKind.ImmutableOperation)));
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
            string __tmp15_line = ".Implementation."; //1169:138
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
            string __tmp17_line = "_"; //1169:208
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
            string __tmp19_line = "("; //1169:223
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
            string __tmp21_line = ");"; //1169:302
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp12_outputWritten = true;
            }
            if (__tmp12_outputWritten) __out.AppendLine(true);
            if (__tmp12_outputWritten)
            {
                __out.AppendLine(false); //1169:304
            }
            __out.Write("}"); //1170:1
            __out.AppendLine(false); //1170:2
            return __out.ToStringAndFree();
        }

        public string GenerateBuilderImplClass(MetaModel model, MetaClass cls) //1173:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool metaMetaModel = IsMetaMetaModel(model); //1174:2
            string metaNs = metaMetaModel ? "" : Properties.MetaNs + "."; //1175:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //1176:1
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
            string __tmp5_line = " : "; //1176:62
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
            string __tmp7_line = ".MutableObjectBase, "; //1176:84
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
                __out.AppendLine(false); //1176:146
            }
            __out.Write("{"); //1177:1
            __out.AppendLine(false); //1177:2
            var __loop73_results = 
                (from __loop73_var1 in __Enumerate((cls).GetEnumerator()) //1178:8
                from prop in __Enumerate((__loop73_var1.GetAllProperties()).GetEnumerator()) //1178:13
                where GetMetaType(prop) is MetaCollectionType //1178:37
                select new { __loop73_var1 = __loop73_var1, prop = prop}
                ).ToList(); //1178:3
            for (int __loop73_iteration = 0; __loop73_iteration < __loop73_results.Count; ++__loop73_iteration)
            {
                var __tmp9 = __loop73_results[__loop73_iteration];
                var __loop73_var1 = __tmp9.__loop73_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //1179:1
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
                    __out.AppendLine(false); //1179:42
                }
            }
            __out.AppendLine(true); //1181:2
            bool __tmp14_outputWritten = false;
            string __tmp15_line = "	internal "; //1182:1
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
            string __tmp17_line = "("; //1182:57
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
            string __tmp19_line = ".ObjectId id, "; //1182:77
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
            string __tmp21_line = ".MutableModel model, bool creating)"; //1182:110
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp14_outputWritten = true;
            }
            if (__tmp14_outputWritten) __out.AppendLine(true);
            if (__tmp14_outputWritten)
            {
                __out.AppendLine(false); //1182:145
            }
            __out.Write("		: base(id, model, creating)"); //1183:1
            __out.AppendLine(false); //1183:30
            __out.Write("	{"); //1184:1
            __out.AppendLine(false); //1184:3
            __out.Write("	}"); //1185:1
            __out.AppendLine(false); //1185:3
            __out.AppendLine(true); //1186:2
            __out.Write("	protected override void MInit()"); //1187:1
            __out.AppendLine(false); //1187:33
            __out.Write("	{"); //1188:1
            __out.AppendLine(false); //1188:3
            bool __tmp23_outputWritten = false;
            string __tmp22Prefix = "		"; //1189:1
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
            string __tmp25_line = ".Implementation."; //1189:55
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
            string __tmp27_line = "(this);"; //1189:115
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Write(__tmp27_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //1189:122
            }
            __out.Write("	}"); //1190:1
            __out.AppendLine(false); //1190:3
            __out.AppendLine(true); //1191:2
            bool __tmp29_outputWritten = false;
            string __tmp30_line = "	public override "; //1192:1
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
            string __tmp32_line = ".ModelMetadata MMetadata => "; //1192:37
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
            string __tmp34_line = ".MMetadata;"; //1192:118
            if (!string.IsNullOrEmpty(__tmp34_line))
            {
                __out.Write(__tmp34_line);
                __tmp29_outputWritten = true;
            }
            if (__tmp29_outputWritten) __out.AppendLine(true);
            if (__tmp29_outputWritten)
            {
                __out.AppendLine(false); //1192:129
            }
            __out.AppendLine(true); //1193:2
            bool __tmp36_outputWritten = false;
            string __tmp37_line = "	public override "; //1194:1
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
            string __tmp39_line = "MetaClass MMetaClass => "; //1194:26
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
            string __tmp41_line = ";"; //1194:108
            if (!string.IsNullOrEmpty(__tmp41_line))
            {
                __out.Write(__tmp41_line);
                __tmp36_outputWritten = true;
            }
            if (__tmp36_outputWritten) __out.AppendLine(true);
            if (__tmp36_outputWritten)
            {
                __out.AppendLine(false); //1194:109
            }
            __out.AppendLine(true); //1195:2
            bool __tmp43_outputWritten = false;
            string __tmp44_line = "	public new "; //1196:1
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
            string __tmp46_line = " ToImmutable()"; //1196:57
            if (!string.IsNullOrEmpty(__tmp46_line))
            {
                __out.Write(__tmp46_line);
                __tmp43_outputWritten = true;
            }
            if (__tmp43_outputWritten) __out.AppendLine(true);
            if (__tmp43_outputWritten)
            {
                __out.AppendLine(false); //1196:71
            }
            __out.Write("	{"); //1197:1
            __out.AppendLine(false); //1197:3
            bool __tmp48_outputWritten = false;
            string __tmp49_line = "		return ("; //1198:1
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
            string __tmp51_line = ")base.ToImmutable();"; //1198:55
            if (!string.IsNullOrEmpty(__tmp51_line))
            {
                __out.Write(__tmp51_line);
                __tmp48_outputWritten = true;
            }
            if (__tmp48_outputWritten) __out.AppendLine(true);
            if (__tmp48_outputWritten)
            {
                __out.AppendLine(false); //1198:75
            }
            __out.Write("	}"); //1199:1
            __out.AppendLine(false); //1199:3
            __out.AppendLine(true); //1200:2
            bool __tmp53_outputWritten = false;
            string __tmp54_line = "	public new "; //1201:1
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
            string __tmp56_line = " ToImmutable("; //1201:57
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
            string __tmp58_line = ".ImmutableModel model)"; //1201:89
            if (!string.IsNullOrEmpty(__tmp58_line))
            {
                __out.Write(__tmp58_line);
                __tmp53_outputWritten = true;
            }
            if (__tmp53_outputWritten) __out.AppendLine(true);
            if (__tmp53_outputWritten)
            {
                __out.AppendLine(false); //1201:111
            }
            __out.Write("	{"); //1202:1
            __out.AppendLine(false); //1202:3
            bool __tmp60_outputWritten = false;
            string __tmp61_line = "		return ("; //1203:1
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
            string __tmp63_line = ")base.ToImmutable(model);"; //1203:55
            if (!string.IsNullOrEmpty(__tmp63_line))
            {
                __out.Write(__tmp63_line);
                __tmp60_outputWritten = true;
            }
            if (__tmp60_outputWritten) __out.AppendLine(true);
            if (__tmp60_outputWritten)
            {
                __out.AppendLine(false); //1203:80
            }
            __out.Write("	}"); //1204:1
            __out.AppendLine(false); //1204:3
            var __loop74_results = 
                (from __loop74_var1 in __Enumerate((cls).GetEnumerator()) //1205:8
                from sup in __Enumerate((__loop74_var1.GetAllSuperClasses(false)).GetEnumerator()) //1205:13
                select new { __loop74_var1 = __loop74_var1, sup = sup}
                ).ToList(); //1205:3
            for (int __loop74_iteration = 0; __loop74_iteration < __loop74_results.Count; ++__loop74_iteration)
            {
                var __tmp64 = __loop74_results[__loop74_iteration];
                var __loop74_var1 = __tmp64.__loop74_var1;
                var sup = __tmp64.sup;
                __out.AppendLine(true); //1206:2
                bool __tmp66_outputWritten = false;
                string __tmp65Prefix = "	"; //1207:1
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
                string __tmp68_line = " "; //1207:52
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
                string __tmp70_line = ".ToImmutable()"; //1207:101
                if (!string.IsNullOrEmpty(__tmp70_line))
                {
                    __out.Write(__tmp70_line);
                    __tmp66_outputWritten = true;
                }
                if (__tmp66_outputWritten) __out.AppendLine(true);
                if (__tmp66_outputWritten)
                {
                    __out.AppendLine(false); //1207:115
                }
                __out.Write("	{"); //1208:1
                __out.AppendLine(false); //1208:3
                __out.Write("		return this.ToImmutable();"); //1209:1
                __out.AppendLine(false); //1209:29
                __out.Write("	}"); //1210:1
                __out.AppendLine(false); //1210:3
                __out.AppendLine(true); //1211:2
                bool __tmp72_outputWritten = false;
                string __tmp71Prefix = "	"; //1212:1
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
                string __tmp74_line = " "; //1212:52
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
                string __tmp76_line = ".ToImmutable("; //1212:101
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
                string __tmp78_line = ".ImmutableModel model)"; //1212:133
                if (!string.IsNullOrEmpty(__tmp78_line))
                {
                    __out.Write(__tmp78_line);
                    __tmp72_outputWritten = true;
                }
                if (__tmp72_outputWritten) __out.AppendLine(true);
                if (__tmp72_outputWritten)
                {
                    __out.AppendLine(false); //1212:155
                }
                __out.Write("	{"); //1213:1
                __out.AppendLine(false); //1213:3
                __out.Write("		return this.ToImmutable(model);"); //1214:1
                __out.AppendLine(false); //1214:34
                __out.Write("	}"); //1215:1
                __out.AppendLine(false); //1215:3
            }
            var __loop75_results = 
                (from __loop75_var1 in __Enumerate((cls).GetEnumerator()) //1217:8
                from prop in __Enumerate((__loop75_var1.GetAllProperties()).GetEnumerator()) //1217:13
                select new { __loop75_var1 = __loop75_var1, prop = prop}
                ).ToList(); //1217:3
            for (int __loop75_iteration = 0; __loop75_iteration < __loop75_results.Count; ++__loop75_iteration)
            {
                var __tmp79 = __loop75_results[__loop75_iteration];
                var __loop75_var1 = __tmp79.__loop75_var1;
                var prop = __tmp79.prop;
                __out.AppendLine(true); //1218:2
                bool __tmp81_outputWritten = false;
                string __tmp80Prefix = "	"; //1219:1
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
                    __out.AppendLine(false); //1219:49
                }
            }
            var __loop76_results = 
                (from __loop76_var1 in __Enumerate((cls).GetEnumerator()) //1221:8
                from op in __Enumerate((__loop76_var1.GetAllOperations()).GetEnumerator()) //1221:13
                select new { __loop76_var1 = __loop76_var1, op = op}
                ).ToList(); //1221:3
            for (int __loop76_iteration = 0; __loop76_iteration < __loop76_results.Count; ++__loop76_iteration)
            {
                var __tmp83 = __loop76_results[__loop76_iteration];
                var __loop76_var1 = __tmp83.__loop76_var1;
                var op = __tmp83.op;
                __out.AppendLine(true); //1222:2
                bool __tmp85_outputWritten = false;
                string __tmp84Prefix = "	"; //1223:1
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
                    __out.AppendLine(false); //1223:48
                }
            }
            __out.Write("}"); //1225:1
            __out.AppendLine(false); //1225:2
            return __out.ToStringAndFree();
        }

        public string GenerateBuilderField(MetaModel model, MetaClass cls, MetaProperty prop) //1228:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "private "; //1229:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Write(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp4.Write(CSharpName(GetMetaType(prop), model, ClassKind.Builder, true));
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
            string __tmp5_line = " "; //1229:71
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
            string __tmp7_line = ";"; //1229:96
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Write(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //1229:97
            }
            return __out.ToStringAndFree();
        }

        public string GenerateBuilderPropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //1232:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            var propType = GetMetaType(prop); //1233:2
            __out.AppendLine(true); //1234:1
            if (cls.GetAllFinalProperties().Contains(prop)) //1235:2
            {
                bool __tmp2_outputWritten = false;
                string __tmp3_line = "public "; //1236:1
                if (!string.IsNullOrEmpty(__tmp3_line))
                {
                    __out.Write(__tmp3_line);
                    __tmp2_outputWritten = true;
                }
                var __tmp4 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp4.Write(CSharpName(propType, model, ClassKind.Builder, true));
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
                string __tmp5_line = " "; //1236:61
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
                    __out.AppendLine(false); //1236:73
                }
            }
            else //1237:2
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
                    __out.AppendLine(false); //1238:54
                }
                bool __tmp11_outputWritten = false;
                var __tmp12 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp12.Write(CSharpName(propType, model, ClassKind.Builder, true));
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
                string __tmp13_line = " "; //1239:54
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
                string __tmp15_line = "."; //1239:110
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
                    __out.AppendLine(false); //1239:122
                }
            }
            __out.Write("{"); //1241:1
            __out.AppendLine(false); //1241:2
            if (propType is MetaCollectionType) //1242:3
            {
                if (((MetaCollectionType)propType).Kind == MetaCollectionKind.Set || ((MetaCollectionType)propType).Kind == MetaCollectionKind.MultiSet) //1243:4
                {
                    bool __tmp18_outputWritten = false;
                    string __tmp19_line = "	get { return this.GetSet<"; //1244:1
                    if (!string.IsNullOrEmpty(__tmp19_line))
                    {
                        __out.Write(__tmp19_line);
                        __tmp18_outputWritten = true;
                    }
                    var __tmp20 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp20.Write(CSharpName(((MetaCollectionType)propType).InnerType, model, ClassKind.Builder, true));
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
                    string __tmp21_line = ">("; //1244:112
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
                    string __tmp23_line = ", ref "; //1244:168
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
                    string __tmp25_line = "); }"; //1244:198
                    if (!string.IsNullOrEmpty(__tmp25_line))
                    {
                        __out.Write(__tmp25_line);
                        __tmp18_outputWritten = true;
                    }
                    if (__tmp18_outputWritten) __out.AppendLine(true);
                    if (__tmp18_outputWritten)
                    {
                        __out.AppendLine(false); //1244:202
                    }
                }
                else //1245:4
                {
                    bool __tmp27_outputWritten = false;
                    string __tmp28_line = "	get { return this.GetList<"; //1246:1
                    if (!string.IsNullOrEmpty(__tmp28_line))
                    {
                        __out.Write(__tmp28_line);
                        __tmp27_outputWritten = true;
                    }
                    var __tmp29 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp29.Write(CSharpName(((MetaCollectionType)propType).InnerType, model, ClassKind.Builder, true));
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
                    string __tmp30_line = ">("; //1246:113
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
                    string __tmp32_line = ", ref "; //1246:169
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
                    string __tmp34_line = "); }"; //1246:199
                    if (!string.IsNullOrEmpty(__tmp34_line))
                    {
                        __out.Write(__tmp34_line);
                        __tmp27_outputWritten = true;
                    }
                    if (__tmp27_outputWritten) __out.AppendLine(true);
                    if (__tmp27_outputWritten)
                    {
                        __out.AppendLine(false); //1246:203
                    }
                }
            }
            else if (IsReferenceType(propType)) //1248:3
            {
                bool __tmp36_outputWritten = false;
                string __tmp37_line = "	get { return this.GetReference<"; //1249:1
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Write(__tmp37_line);
                    __tmp36_outputWritten = true;
                }
                var __tmp38 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp38.Write(CSharpName(propType, model, ClassKind.Builder, true));
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
                string __tmp39_line = ">("; //1249:86
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
                string __tmp41_line = "); }"; //1249:142
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Write(__tmp41_line);
                    __tmp36_outputWritten = true;
                }
                if (__tmp36_outputWritten) __out.AppendLine(true);
                if (__tmp36_outputWritten)
                {
                    __out.AppendLine(false); //1249:146
                }
            }
            else //1250:3
            {
                bool __tmp43_outputWritten = false;
                string __tmp44_line = "	get { return this.GetValue<"; //1251:1
                if (!string.IsNullOrEmpty(__tmp44_line))
                {
                    __out.Write(__tmp44_line);
                    __tmp43_outputWritten = true;
                }
                var __tmp45 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp45.Write(CSharpName(propType, model, ClassKind.Builder, true));
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
                string __tmp46_line = ">("; //1251:82
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
                string __tmp48_line = "); }"; //1251:138
                if (!string.IsNullOrEmpty(__tmp48_line))
                {
                    __out.Write(__tmp48_line);
                    __tmp43_outputWritten = true;
                }
                if (__tmp43_outputWritten) __out.AppendLine(true);
                if (__tmp43_outputWritten)
                {
                    __out.AppendLine(false); //1251:142
                }
            }
            if ((prop.Kind == MetaPropertyKind.Normal) && !(propType is MetaCollectionType)) //1253:3
            {
                if (IsReferenceType(propType)) //1254:4
                {
                    bool __tmp50_outputWritten = false;
                    string __tmp51_line = "	set { this.SetReference<"; //1255:1
                    if (!string.IsNullOrEmpty(__tmp51_line))
                    {
                        __out.Write(__tmp51_line);
                        __tmp50_outputWritten = true;
                    }
                    var __tmp52 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp52.Write(CSharpName(propType, model, ClassKind.Builder, true));
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
                    string __tmp53_line = ">("; //1255:79
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
                    string __tmp55_line = ", value); }"; //1255:135
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Write(__tmp55_line);
                        __tmp50_outputWritten = true;
                    }
                    if (__tmp50_outputWritten) __out.AppendLine(true);
                    if (__tmp50_outputWritten)
                    {
                        __out.AppendLine(false); //1255:146
                    }
                }
                else //1256:4
                {
                    bool __tmp57_outputWritten = false;
                    string __tmp58_line = "	set { this.SetValue<"; //1257:1
                    if (!string.IsNullOrEmpty(__tmp58_line))
                    {
                        __out.Write(__tmp58_line);
                        __tmp57_outputWritten = true;
                    }
                    var __tmp59 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                    __tmp59.Write(CSharpName(propType, model, ClassKind.Builder, true));
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
                    string __tmp60_line = ">("; //1257:75
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
                    string __tmp62_line = ", value); }"; //1257:131
                    if (!string.IsNullOrEmpty(__tmp62_line))
                    {
                        __out.Write(__tmp62_line);
                        __tmp57_outputWritten = true;
                    }
                    if (__tmp57_outputWritten) __out.AppendLine(true);
                    if (__tmp57_outputWritten)
                    {
                        __out.AppendLine(false); //1257:142
                    }
                }
            }
            __out.Write("}"); //1260:1
            __out.AppendLine(false); //1260:2
            if (!(propType is MetaCollectionType)) //1261:2
            {
                __out.AppendLine(true); //1262:1
                bool __tmp64_outputWritten = false;
                string __tmp65_line = "void "; //1263:1
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
                string __tmp67_line = ".Set"; //1263:61
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
                string __tmp69_line = "Lazy(global::System.Func<"; //1263:76
                if (!string.IsNullOrEmpty(__tmp69_line))
                {
                    __out.Write(__tmp69_line);
                    __tmp64_outputWritten = true;
                }
                var __tmp70 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp70.Write(CSharpName(propType, model, ClassKind.Builder, true));
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
                string __tmp71_line = "> lazy)"; //1263:154
                if (!string.IsNullOrEmpty(__tmp71_line))
                {
                    __out.Write(__tmp71_line);
                    __tmp64_outputWritten = true;
                }
                if (__tmp64_outputWritten) __out.AppendLine(true);
                if (__tmp64_outputWritten)
                {
                    __out.AppendLine(false); //1263:161
                }
                __out.Write("{"); //1264:1
                __out.AppendLine(false); //1264:2
                if (IsReferenceType(propType)) //1265:3
                {
                    bool __tmp73_outputWritten = false;
                    string __tmp74_line = "	this.SetLazyReference("; //1266:1
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
                    string __tmp76_line = ", lazy);"; //1266:79
                    if (!string.IsNullOrEmpty(__tmp76_line))
                    {
                        __out.Write(__tmp76_line);
                        __tmp73_outputWritten = true;
                    }
                    if (__tmp73_outputWritten) __out.AppendLine(true);
                    if (__tmp73_outputWritten)
                    {
                        __out.AppendLine(false); //1266:87
                    }
                }
                else //1267:3
                {
                    bool __tmp78_outputWritten = false;
                    string __tmp79_line = "	this.SetLazyValue("; //1268:1
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
                    string __tmp81_line = ", lazy);"; //1268:75
                    if (!string.IsNullOrEmpty(__tmp81_line))
                    {
                        __out.Write(__tmp81_line);
                        __tmp78_outputWritten = true;
                    }
                    if (__tmp78_outputWritten) __out.AppendLine(true);
                    if (__tmp78_outputWritten)
                    {
                        __out.AppendLine(false); //1268:83
                    }
                }
                __out.Write("}"); //1270:1
                __out.AppendLine(false); //1270:2
                __out.AppendLine(true); //1271:1
                bool __tmp83_outputWritten = false;
                string __tmp84_line = "void "; //1272:1
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
                string __tmp86_line = ".Set"; //1272:61
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
                string __tmp88_line = "Lazy(global::System.Func<"; //1272:76
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
                string __tmp90_line = ", "; //1272:156
                if (!string.IsNullOrEmpty(__tmp90_line))
                {
                    __out.Write(__tmp90_line);
                    __tmp83_outputWritten = true;
                }
                var __tmp91 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp91.Write(CSharpName(propType, model, ClassKind.Builder, true));
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
                string __tmp92_line = "> lazy)"; //1272:211
                if (!string.IsNullOrEmpty(__tmp92_line))
                {
                    __out.Write(__tmp92_line);
                    __tmp83_outputWritten = true;
                }
                if (__tmp83_outputWritten) __out.AppendLine(true);
                if (__tmp83_outputWritten)
                {
                    __out.AppendLine(false); //1272:218
                }
                __out.Write("{"); //1273:1
                __out.AppendLine(false); //1273:2
                if (IsReferenceType(propType)) //1274:3
                {
                    bool __tmp94_outputWritten = false;
                    string __tmp95_line = "	this.SetLazyReference("; //1275:1
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
                    string __tmp97_line = ", lazy);"; //1275:79
                    if (!string.IsNullOrEmpty(__tmp97_line))
                    {
                        __out.Write(__tmp97_line);
                        __tmp94_outputWritten = true;
                    }
                    if (__tmp94_outputWritten) __out.AppendLine(true);
                    if (__tmp94_outputWritten)
                    {
                        __out.AppendLine(false); //1275:87
                    }
                }
                else //1276:3
                {
                    bool __tmp99_outputWritten = false;
                    string __tmp100_line = "	this.SetLazyValue("; //1277:1
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
                    string __tmp102_line = ", lazy);"; //1277:75
                    if (!string.IsNullOrEmpty(__tmp102_line))
                    {
                        __out.Write(__tmp102_line);
                        __tmp99_outputWritten = true;
                    }
                    if (__tmp99_outputWritten) __out.AppendLine(true);
                    if (__tmp99_outputWritten)
                    {
                        __out.AppendLine(false); //1277:83
                    }
                }
                __out.Write("}"); //1279:1
                __out.AppendLine(false); //1279:2
                __out.AppendLine(true); //1280:1
                bool __tmp104_outputWritten = false;
                string __tmp105_line = "void "; //1281:1
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
                string __tmp107_line = ".Set"; //1281:61
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
                string __tmp109_line = "Lazy(global::System.Func<"; //1281:76
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
                string __tmp111_line = ", "; //1281:158
                if (!string.IsNullOrEmpty(__tmp111_line))
                {
                    __out.Write(__tmp111_line);
                    __tmp104_outputWritten = true;
                }
                var __tmp112 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp112.Write(CSharpName(propType, model, ClassKind.Immutable, true));
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
                string __tmp113_line = "> immutableLazy, global::System.Func<"; //1281:215
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
                string __tmp115_line = ", "; //1281:307
                if (!string.IsNullOrEmpty(__tmp115_line))
                {
                    __out.Write(__tmp115_line);
                    __tmp104_outputWritten = true;
                }
                var __tmp116 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
                __tmp116.Write(CSharpName(propType, model, ClassKind.Builder, true));
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
                string __tmp117_line = "> mutableLazy)"; //1281:362
                if (!string.IsNullOrEmpty(__tmp117_line))
                {
                    __out.Write(__tmp117_line);
                    __tmp104_outputWritten = true;
                }
                if (__tmp104_outputWritten) __out.AppendLine(true);
                if (__tmp104_outputWritten)
                {
                    __out.AppendLine(false); //1281:376
                }
                __out.Write("{"); //1282:1
                __out.AppendLine(false); //1282:2
                if (IsReferenceType(propType)) //1283:3
                {
                    bool __tmp119_outputWritten = false;
                    string __tmp120_line = "	this.SetLazyReference("; //1284:1
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
                    string __tmp122_line = ", immutableLazy, mutableLazy);"; //1284:79
                    if (!string.IsNullOrEmpty(__tmp122_line))
                    {
                        __out.Write(__tmp122_line);
                        __tmp119_outputWritten = true;
                    }
                    if (__tmp119_outputWritten) __out.AppendLine(true);
                    if (__tmp119_outputWritten)
                    {
                        __out.AppendLine(false); //1284:109
                    }
                }
                else //1285:3
                {
                    bool __tmp124_outputWritten = false;
                    string __tmp125_line = "	this.SetLazyValue("; //1286:1
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
                    string __tmp127_line = ", immutableLazy, mutableLazy);"; //1286:75
                    if (!string.IsNullOrEmpty(__tmp127_line))
                    {
                        __out.Write(__tmp127_line);
                        __tmp124_outputWritten = true;
                    }
                    if (__tmp124_outputWritten) __out.AppendLine(true);
                    if (__tmp124_outputWritten)
                    {
                        __out.AppendLine(false); //1286:105
                    }
                }
                __out.Write("}"); //1288:1
                __out.AppendLine(false); //1288:2
            }
            return __out.ToStringAndFree();
        }

        public string GenerateBuilderOperationImpl(MetaModel model, MetaClass cls, MetaOperation op) //1292:1
        {
            var __out = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __out.AppendLine(true); //1293:1
            bool __tmp2_outputWritten = false;
            var __tmp3 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp3.Write(CSharpName(GetMetaType(op), model, ClassKind.BuilderOperation, true));
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
            string __tmp4_line = " "; //1294:70
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
            string __tmp6_line = "."; //1294:124
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
            string __tmp8_line = "("; //1294:134
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
            string __tmp10_line = ")"; //1294:204
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Write(__tmp10_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //1294:205
            }
            __out.Write("{"); //1295:1
            __out.AppendLine(false); //1295:2
            var finalOp = GetFinalOperation(cls, op); //1296:2
            bool __tmp12_outputWritten = false;
            string __tmp11Prefix = "    "; //1297:1
            var __tmp13 = global::MetaDslx.CodeGeneration.CodeBuilder.GetInstance();
            __tmp13.Write(GetReturn(CSharpName(GetMetaType(finalOp), model, ClassKind.BuilderOperation)));
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
            string __tmp15_line = ".Implementation."; //1297:136
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
            string __tmp17_line = "_"; //1297:206
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
            string __tmp19_line = "("; //1297:221
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
            string __tmp21_line = ");"; //1297:298
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Write(__tmp21_line);
                __tmp12_outputWritten = true;
            }
            if (__tmp12_outputWritten) __out.AppendLine(true);
            if (__tmp12_outputWritten)
            {
                __out.AppendLine(false); //1297:300
            }
            __out.Write("}"); //1298:1
            __out.AppendLine(false); //1298:2
            return __out.ToStringAndFree();
        }

    }
}

