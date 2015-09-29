using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler //1:1
{
    using __Hidden_MetaLanguageServiceGenerator_797619903;
    namespace __Hidden_MetaLanguageServiceGenerator_797619903
    {
        internal static class __Extensions
        {
            internal static IEnumerator<T> GetEnumerator<T>(this T item)
            {
                if (item == null) return new List<T>().GetEnumerator();
                else return new List<T> { item }.GetEnumerator();
            }
        }
    }

    public class MetaLanguageServiceGenerator //2:1
    {
        private object Instances; //2:1
        public MetaLanguageServiceGenerator(object instances) //2:1
        {
            this.Properties = new __Properties();
            this.Instances = instances;
        }

        private Stream __ToStream(string text)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(text);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private static IEnumerable<T> __Enumerate<T>(IEnumerator<T> items)
        {
            while (items.MoveNext())
            {
                yield return items.Current;
            }
        }

        private int counter = 0;
        private int NextCounter()
        {
            return ++counter;
        }

        public __Properties Properties { get; private set; } //4:1

        public class __Properties //4:1
        {
            internal __Properties()
            {
                this.LanguageServiceNamespace = null; //5:36
                this.LanguageClassName = null; //6:29
                this.LanguageFullName = null; //7:28
                this.GenerateMultipleFiles = false; //8:31
            }
            public string LanguageServiceNamespace { get; set; } //5:2
            public string LanguageClassName { get; set; } //6:2
            public string LanguageFullName { get; set; } //7:2
            public bool GenerateMultipleFiles { get; set; } //8:2
        }

        public string Generate() //11:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("using System;"); //12:1
            __out.AppendLine(); //12:14
            __out.Append("using System.Collections.Generic;"); //13:1
            __out.AppendLine(); //13:34
            __out.Append("using System.ComponentModel;"); //14:1
            __out.AppendLine(); //14:29
            __out.Append("using System.Diagnostics;"); //15:1
            __out.AppendLine(); //15:26
            __out.Append("using System.IO;"); //16:1
            __out.AppendLine(); //16:17
            __out.Append("using System.Linq;"); //17:1
            __out.AppendLine(); //17:19
            __out.Append("using System.Runtime.InteropServices;"); //18:1
            __out.AppendLine(); //18:38
            __out.Append("using System.Text;"); //19:1
            __out.AppendLine(); //19:19
            __out.Append("using System.Threading.Tasks;"); //20:1
            __out.AppendLine(); //20:30
            __out.Append("using Microsoft.VisualStudio.OLE.Interop;"); //21:1
            __out.AppendLine(); //21:42
            __out.Append("using Microsoft.VisualStudio.Package;"); //22:1
            __out.AppendLine(); //22:38
            __out.Append("using Microsoft.VisualStudio.Shell.Interop;"); //23:1
            __out.AppendLine(); //23:44
            __out.Append("using Microsoft.VisualStudio.TextManager.Interop;"); //24:1
            __out.AppendLine(); //24:50
            __out.Append("using Antlr4.Runtime;"); //25:1
            __out.AppendLine(); //25:22
            __out.Append("using MetaDslx.Compiler;"); //26:1
            __out.AppendLine(); //26:25
            __out.Append("using System.Drawing;"); //27:1
            __out.AppendLine(); //27:22
            __out.Append("using Microsoft.VisualStudio;"); //28:1
            __out.AppendLine(); //28:30
            __out.Append("using VsCommands2K = Microsoft.VisualStudio.VSConstants.VSStd2KCmdID;"); //30:1
            __out.AppendLine(); //30:70
            string __tmp1Prefix = "namespace "; //32:1
            string __tmp2Suffix = string.Empty; 
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(Properties.LanguageServiceNamespace);
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //32:48
                }
            }
            __out.Append("{"); //33:1
            __out.AppendLine(); //33:2
            string __tmp4Prefix = "    public class "; //34:1
            string __tmp5Suffix = "LanguageAuthoringScope : AuthoringScope"; //34:48
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(Properties.LanguageClassName);
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                while(__tmp6_first || !__tmp6Reader.EndOfStream)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    if (__tmp6Line == null)
                    {
                        __tmp6Line = "";
                    }
                    __out.Append(__tmp4Prefix);
                    __out.Append(__tmp6Line);
                    __out.Append(__tmp5Suffix);
                    __out.AppendLine(); //34:87
                }
            }
            __out.Append("    {"); //35:1
            __out.AppendLine(); //35:6
            __out.Append("        public override string GetDataTipText(int line, int col, out TextSpan span)"); //36:1
            __out.AppendLine(); //36:84
            __out.Append("        {"); //37:1
            __out.AppendLine(); //37:10
            __out.Append("            span = new TextSpan();"); //38:1
            __out.AppendLine(); //38:35
            __out.Append("            return null;"); //39:1
            __out.AppendLine(); //39:25
            __out.Append("        }"); //40:1
            __out.AppendLine(); //40:10
            __out.Append("        public override Declarations GetDeclarations(IVsTextView view, int line, int col, TokenInfo info, ParseReason reason)"); //42:1
            __out.AppendLine(); //42:126
            __out.Append("        {"); //43:1
            __out.AppendLine(); //43:10
            __out.Append("            return null;"); //44:1
            __out.AppendLine(); //44:25
            __out.Append("        }"); //45:1
            __out.AppendLine(); //45:10
            __out.Append("        public override Methods GetMethods(int line, int col, string name)"); //47:1
            __out.AppendLine(); //47:75
            __out.Append("        {"); //48:1
            __out.AppendLine(); //48:10
            __out.Append("            return null;"); //49:1
            __out.AppendLine(); //49:25
            __out.Append("        }"); //50:1
            __out.AppendLine(); //50:10
            __out.Append("        public override string Goto(Microsoft.VisualStudio.VSConstants.VSStd97CmdID cmd, IVsTextView textView, int line, int col, out TextSpan span)"); //52:1
            __out.AppendLine(); //52:149
            __out.Append("        {"); //53:1
            __out.AppendLine(); //53:10
            __out.Append("            span = new TextSpan();"); //54:1
            __out.AppendLine(); //54:35
            __out.Append("            return null;"); //55:1
            __out.AppendLine(); //55:25
            __out.Append("        }"); //56:1
            __out.AppendLine(); //56:10
            __out.Append("    }"); //57:1
            __out.AppendLine(); //57:6
            string __tmp7Prefix = "	public class "; //59:1
            string __tmp8Suffix = "LanguageColorizer : Colorizer"; //59:45
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(Properties.LanguageClassName);
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_first = true;
                while(__tmp9_first || !__tmp9Reader.EndOfStream)
                {
                    __tmp9_first = false;
                    string __tmp9Line = __tmp9Reader.ReadLine();
                    if (__tmp9Line == null)
                    {
                        __tmp9Line = "";
                    }
                    __out.Append(__tmp7Prefix);
                    __out.Append(__tmp9Line);
                    __out.Append(__tmp8Suffix);
                    __out.AppendLine(); //59:74
                }
            }
            __out.Append("    {"); //60:1
            __out.AppendLine(); //60:6
            string __tmp10Prefix = "        public "; //61:1
            string __tmp11Suffix = "LanguageColorizer(LanguageService svc, IVsTextLines buffer, IScanner scanner)"; //61:46
            StringBuilder __tmp12 = new StringBuilder();
            __tmp12.Append(Properties.LanguageClassName);
            using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
            {
                bool __tmp12_first = true;
                while(__tmp12_first || !__tmp12Reader.EndOfStream)
                {
                    __tmp12_first = false;
                    string __tmp12Line = __tmp12Reader.ReadLine();
                    if (__tmp12Line == null)
                    {
                        __tmp12Line = "";
                    }
                    __out.Append(__tmp10Prefix);
                    __out.Append(__tmp12Line);
                    __out.Append(__tmp11Suffix);
                    __out.AppendLine(); //61:123
                }
            }
            __out.Append("            : base(svc, buffer, scanner)"); //62:1
            __out.AppendLine(); //62:41
            __out.Append("        {"); //63:1
            __out.AppendLine(); //63:10
            __out.Append("        }"); //64:1
            __out.AppendLine(); //64:10
            __out.Append("        #region IVsColorizer Members"); //66:1
            __out.AppendLine(); //66:37
            string __tmp13Prefix = "        public override int ColorizeLine(int line, int length, IntPtr ptr, int state, uint"; //68:1
            string __tmp14Suffix = " attrs)"; //68:97
            StringBuilder __tmp15 = new StringBuilder();
            __tmp15.Append("[]");
            using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
            {
                bool __tmp15_first = true;
                while(__tmp15_first || !__tmp15Reader.EndOfStream)
                {
                    __tmp15_first = false;
                    string __tmp15Line = __tmp15Reader.ReadLine();
                    if (__tmp15Line == null)
                    {
                        __tmp15Line = "";
                    }
                    __out.Append(__tmp13Prefix);
                    __out.Append(__tmp15Line);
                    __out.Append(__tmp14Suffix);
                    __out.AppendLine(); //68:104
                }
            }
            __out.Append("        {"); //69:1
            __out.AppendLine(); //69:10
            __out.Append("            if (attrs == null) return state;"); //70:1
            __out.AppendLine(); //70:45
            __out.Append("            int linepos = 0;"); //71:1
            __out.AppendLine(); //71:29
            __out.Append("            // Must initialize the colors in all cases, otherwise you get "); //72:1
            __out.AppendLine(); //72:75
            __out.Append("            // random color junk on the screen."); //73:1
            __out.AppendLine(); //73:48
            __out.Append("            for (linepos = 0; linepos < attrs.Length; linepos++)"); //74:1
            __out.AppendLine(); //74:65
            string __tmp16Prefix = "                attrs"; //75:1
            string __tmp17Suffix = " = (uint)TokenColor.Text;"; //75:35
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append("[linepos]");
            using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
            {
                bool __tmp18_first = true;
                while(__tmp18_first || !__tmp18Reader.EndOfStream)
                {
                    __tmp18_first = false;
                    string __tmp18Line = __tmp18Reader.ReadLine();
                    if (__tmp18Line == null)
                    {
                        __tmp18Line = "";
                    }
                    __out.Append(__tmp16Prefix);
                    __out.Append(__tmp18Line);
                    __out.Append(__tmp17Suffix);
                    __out.AppendLine(); //75:60
                }
            }
            __out.Append("            if (this.Scanner != null)"); //76:1
            __out.AppendLine(); //76:38
            __out.Append("            {"); //77:1
            __out.AppendLine(); //77:14
            __out.Append("                try"); //78:1
            __out.AppendLine(); //78:20
            __out.Append("                {"); //79:1
            __out.AppendLine(); //79:18
            __out.Append("                    string text = Marshal.PtrToStringUni(ptr, length);"); //80:1
            __out.AppendLine(); //80:71
            __out.Append("                    this.Scanner.SetSource(text, 0);"); //82:1
            __out.AppendLine(); //82:53
            __out.Append("                    TokenInfo tokenInfo = new TokenInfo();"); //84:1
            __out.AppendLine(); //84:59
            __out.Append("                    tokenInfo.EndIndex = -1;"); //86:1
            __out.AppendLine(); //86:45
            __out.Append("                    while (this.Scanner.ScanTokenAndProvideInfoAboutIt(tokenInfo, ref state))"); //88:1
            __out.AppendLine(); //88:94
            __out.Append("                    {"); //89:1
            __out.AppendLine(); //89:22
            __out.Append("                        for (linepos = tokenInfo.StartIndex; linepos <= tokenInfo.EndIndex; linepos++)"); //90:1
            __out.AppendLine(); //90:103
            __out.Append("                        {"); //91:1
            __out.AppendLine(); //91:26
            __out.Append("                            if (linepos >= 0 && linepos < attrs.Length)"); //92:1
            __out.AppendLine(); //92:72
            __out.Append("                            {"); //93:1
            __out.AppendLine(); //93:30
            string __tmp19Prefix = "                                attrs"; //94:1
            string __tmp20Suffix = " = (uint)tokenInfo.Color;"; //94:51
            StringBuilder __tmp21 = new StringBuilder();
            __tmp21.Append("[linepos]");
            using(StreamReader __tmp21Reader = new StreamReader(this.__ToStream(__tmp21.ToString())))
            {
                bool __tmp21_first = true;
                while(__tmp21_first || !__tmp21Reader.EndOfStream)
                {
                    __tmp21_first = false;
                    string __tmp21Line = __tmp21Reader.ReadLine();
                    if (__tmp21Line == null)
                    {
                        __tmp21Line = "";
                    }
                    __out.Append(__tmp19Prefix);
                    __out.Append(__tmp21Line);
                    __out.Append(__tmp20Suffix);
                    __out.AppendLine(); //94:76
                }
            }
            __out.Append("                            }"); //95:1
            __out.AppendLine(); //95:30
            __out.Append("                        }"); //96:1
            __out.AppendLine(); //96:26
            __out.Append("                    }"); //97:1
            __out.AppendLine(); //97:22
            __out.Append("                }"); //98:1
            __out.AppendLine(); //98:18
            __out.Append("                catch (Exception)"); //99:1
            __out.AppendLine(); //99:34
            __out.Append("                {"); //100:1
            __out.AppendLine(); //100:18
            __out.Append("                    // Ignore exceptions"); //101:1
            __out.AppendLine(); //101:41
            __out.Append("                }"); //102:1
            __out.AppendLine(); //102:18
            __out.Append("            }"); //103:1
            __out.AppendLine(); //103:14
            __out.Append("            return state;"); //104:1
            __out.AppendLine(); //104:26
            __out.Append("        }"); //105:1
            __out.AppendLine(); //105:10
            __out.Append("        public override int GetStartState(out int piStartState)"); //107:1
            __out.AppendLine(); //107:64
            __out.Append("        {"); //108:1
            __out.AppendLine(); //108:10
            __out.Append("            piStartState = 0;"); //109:1
            __out.AppendLine(); //109:30
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //110:1
            __out.AppendLine(); //110:60
            __out.Append("        }"); //111:1
            __out.AppendLine(); //111:10
            __out.Append("        public override int GetStateAtEndOfLine(int iLine, int iLength, IntPtr pText, int iState)"); //113:1
            __out.AppendLine(); //113:98
            __out.Append("        {"); //114:1
            __out.AppendLine(); //114:10
            __out.Append("            string text = Marshal.PtrToStringUni(pText, iLength);"); //115:1
            __out.AppendLine(); //115:66
            __out.Append("            if (text != null)"); //116:1
            __out.AppendLine(); //116:30
            __out.Append("            {"); //117:1
            __out.AppendLine(); //117:14
            __out.Append("                this.Scanner.SetSource(text, 0);"); //118:1
            __out.AppendLine(); //118:49
            string __tmp22Prefix = "                (("; //119:1
            string __tmp23Suffix = "LanguageScanner)this.Scanner).ScanLine(ref iState);"; //119:49
            StringBuilder __tmp24 = new StringBuilder();
            __tmp24.Append(Properties.LanguageClassName);
            using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
            {
                bool __tmp24_first = true;
                while(__tmp24_first || !__tmp24Reader.EndOfStream)
                {
                    __tmp24_first = false;
                    string __tmp24Line = __tmp24Reader.ReadLine();
                    if (__tmp24Line == null)
                    {
                        __tmp24Line = "";
                    }
                    __out.Append(__tmp22Prefix);
                    __out.Append(__tmp24Line);
                    __out.Append(__tmp23Suffix);
                    __out.AppendLine(); //119:100
                }
            }
            __out.Append("            }"); //120:1
            __out.AppendLine(); //120:14
            __out.Append("            return iState;"); //121:1
            __out.AppendLine(); //121:27
            __out.Append("        }"); //122:1
            __out.AppendLine(); //122:10
            __out.Append("        public override int GetStateMaintenanceFlag(out int pfFlag)"); //124:1
            __out.AppendLine(); //124:68
            __out.Append("        {"); //125:1
            __out.AppendLine(); //125:10
            __out.Append("            pfFlag = 1;"); //126:1
            __out.AppendLine(); //126:24
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //127:1
            __out.AppendLine(); //127:60
            __out.Append("        }"); //128:1
            __out.AppendLine(); //128:10
            __out.Append("        #endregion"); //130:1
            __out.AppendLine(); //130:19
            __out.Append("    }"); //131:1
            __out.AppendLine(); //131:6
            string __tmp25Prefix = "    public abstract class "; //134:1
            string __tmp26Suffix = "LanguageConfigBase"; //134:57
            StringBuilder __tmp27 = new StringBuilder();
            __tmp27.Append(Properties.LanguageClassName);
            using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
            {
                bool __tmp27_first = true;
                while(__tmp27_first || !__tmp27Reader.EndOfStream)
                {
                    __tmp27_first = false;
                    string __tmp27Line = __tmp27Reader.ReadLine();
                    if (__tmp27Line == null)
                    {
                        __tmp27Line = "";
                    }
                    __out.Append(__tmp25Prefix);
                    __out.Append(__tmp27Line);
                    __out.Append(__tmp26Suffix);
                    __out.AppendLine(); //134:75
                }
            }
            __out.Append("    {"); //135:1
            __out.AppendLine(); //135:6
            string __tmp28Prefix = "        private static "; //136:1
            string __tmp29Suffix = "LanguageConfig instance = null;"; //136:54
            StringBuilder __tmp30 = new StringBuilder();
            __tmp30.Append(Properties.LanguageClassName);
            using(StreamReader __tmp30Reader = new StreamReader(this.__ToStream(__tmp30.ToString())))
            {
                bool __tmp30_first = true;
                while(__tmp30_first || !__tmp30Reader.EndOfStream)
                {
                    __tmp30_first = false;
                    string __tmp30Line = __tmp30Reader.ReadLine();
                    if (__tmp30Line == null)
                    {
                        __tmp30Line = "";
                    }
                    __out.Append(__tmp28Prefix);
                    __out.Append(__tmp30Line);
                    __out.Append(__tmp29Suffix);
                    __out.AppendLine(); //136:85
                }
            }
            string __tmp31Prefix = "        public static "; //137:1
            string __tmp32Suffix = "LanguageConfig Instance"; //137:53
            StringBuilder __tmp33 = new StringBuilder();
            __tmp33.Append(Properties.LanguageClassName);
            using(StreamReader __tmp33Reader = new StreamReader(this.__ToStream(__tmp33.ToString())))
            {
                bool __tmp33_first = true;
                while(__tmp33_first || !__tmp33Reader.EndOfStream)
                {
                    __tmp33_first = false;
                    string __tmp33Line = __tmp33Reader.ReadLine();
                    if (__tmp33Line == null)
                    {
                        __tmp33Line = "";
                    }
                    __out.Append(__tmp31Prefix);
                    __out.Append(__tmp33Line);
                    __out.Append(__tmp32Suffix);
                    __out.AppendLine(); //137:76
                }
            }
            __out.Append("        {"); //138:1
            __out.AppendLine(); //138:10
            __out.Append("            get "); //139:1
            __out.AppendLine(); //139:17
            __out.Append("            {"); //140:1
            __out.AppendLine(); //140:14
            __out.Append("                if (instance == null)"); //141:1
            __out.AppendLine(); //141:38
            __out.Append("                {"); //142:1
            __out.AppendLine(); //142:18
            string __tmp34Prefix = "					// If there is a compile error in the following line, create a class "; //143:1
            string __tmp35Suffix = "LanguageConfig"; //143:105
            StringBuilder __tmp36 = new StringBuilder();
            __tmp36.Append(Properties.LanguageClassName);
            using(StreamReader __tmp36Reader = new StreamReader(this.__ToStream(__tmp36.ToString())))
            {
                bool __tmp36_first = true;
                while(__tmp36_first || !__tmp36Reader.EndOfStream)
                {
                    __tmp36_first = false;
                    string __tmp36Line = __tmp36Reader.ReadLine();
                    if (__tmp36Line == null)
                    {
                        __tmp36Line = "";
                    }
                    __out.Append(__tmp34Prefix);
                    __out.Append(__tmp36Line);
                    __out.Append(__tmp35Suffix);
                    __out.AppendLine(); //143:119
                }
            }
            string __tmp37Prefix = "					// which is a subclass of "; //144:1
            string __tmp38Suffix = "LanguageConfigBase"; //144:62
            StringBuilder __tmp39 = new StringBuilder();
            __tmp39.Append(Properties.LanguageClassName);
            using(StreamReader __tmp39Reader = new StreamReader(this.__ToStream(__tmp39.ToString())))
            {
                bool __tmp39_first = true;
                while(__tmp39_first || !__tmp39Reader.EndOfStream)
                {
                    __tmp39_first = false;
                    string __tmp39Line = __tmp39Reader.ReadLine();
                    if (__tmp39Line == null)
                    {
                        __tmp39Line = "";
                    }
                    __out.Append(__tmp37Prefix);
                    __out.Append(__tmp39Line);
                    __out.Append(__tmp38Suffix);
                    __out.AppendLine(); //144:80
                }
            }
            string __tmp40Prefix = "                    instance = new "; //145:1
            string __tmp41Suffix = "LanguageConfig();"; //145:66
            StringBuilder __tmp42 = new StringBuilder();
            __tmp42.Append(Properties.LanguageClassName);
            using(StreamReader __tmp42Reader = new StreamReader(this.__ToStream(__tmp42.ToString())))
            {
                bool __tmp42_first = true;
                while(__tmp42_first || !__tmp42Reader.EndOfStream)
                {
                    __tmp42_first = false;
                    string __tmp42Line = __tmp42Reader.ReadLine();
                    if (__tmp42Line == null)
                    {
                        __tmp42Line = "";
                    }
                    __out.Append(__tmp40Prefix);
                    __out.Append(__tmp42Line);
                    __out.Append(__tmp41Suffix);
                    __out.AppendLine(); //145:83
                }
            }
            __out.Append("                }"); //146:1
            __out.AppendLine(); //146:18
            __out.Append("                return instance;"); //147:1
            __out.AppendLine(); //147:33
            __out.Append("            }"); //148:1
            __out.AppendLine(); //148:14
            __out.Append("        }"); //149:1
            __out.AppendLine(); //149:10
            string __tmp43Prefix = "        private List<"; //150:1
            string __tmp44Suffix = "LanguageColorableItem>();"; //150:131
            StringBuilder __tmp45 = new StringBuilder();
            __tmp45.Append(Properties.LanguageClassName);
            using(StreamReader __tmp45Reader = new StreamReader(this.__ToStream(__tmp45.ToString())))
            {
                bool __tmp45_first = true;
                while(__tmp45_first || !__tmp45Reader.EndOfStream)
                {
                    __tmp45_first = false;
                    string __tmp45Line = __tmp45Reader.ReadLine();
                    if (__tmp45Line == null)
                    {
                        __tmp45Line = "";
                    }
                    __out.Append(__tmp43Prefix);
                    __out.Append(__tmp45Line);
                }
            }
            string __tmp46Line = "LanguageColorableItem> colorableItems = new List<"; //150:52
            __out.Append(__tmp46Line);
            StringBuilder __tmp47 = new StringBuilder();
            __tmp47.Append(Properties.LanguageClassName);
            using(StreamReader __tmp47Reader = new StreamReader(this.__ToStream(__tmp47.ToString())))
            {
                bool __tmp47_first = true;
                while(__tmp47_first || !__tmp47Reader.EndOfStream)
                {
                    __tmp47_first = false;
                    string __tmp47Line = __tmp47Reader.ReadLine();
                    if (__tmp47Line == null)
                    {
                        __tmp47Line = "";
                    }
                    __out.Append(__tmp47Line);
                    __out.Append(__tmp44Suffix);
                    __out.AppendLine(); //150:156
                }
            }
            string __tmp48Prefix = "        public IList<"; //151:1
            string __tmp49Suffix = "LanguageColorableItem> ColorableItems"; //151:52
            StringBuilder __tmp50 = new StringBuilder();
            __tmp50.Append(Properties.LanguageClassName);
            using(StreamReader __tmp50Reader = new StreamReader(this.__ToStream(__tmp50.ToString())))
            {
                bool __tmp50_first = true;
                while(__tmp50_first || !__tmp50Reader.EndOfStream)
                {
                    __tmp50_first = false;
                    string __tmp50Line = __tmp50Reader.ReadLine();
                    if (__tmp50Line == null)
                    {
                        __tmp50Line = "";
                    }
                    __out.Append(__tmp48Prefix);
                    __out.Append(__tmp50Line);
                    __out.Append(__tmp49Suffix);
                    __out.AppendLine(); //151:89
                }
            }
            __out.Append("        {"); //152:1
            __out.AppendLine(); //152:10
            __out.Append("            get { return colorableItems; }"); //153:1
            __out.AppendLine(); //153:43
            __out.Append("        }"); //154:1
            __out.AppendLine(); //154:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, Color foregroundColor)"); //155:1
            __out.AppendLine(); //155:93
            __out.Append("        {"); //156:1
            __out.AppendLine(); //156:10
            __out.Append("            return CreateColor(name, type, foregroundColor, false, false);"); //157:1
            __out.AppendLine(); //157:75
            __out.Append("        }"); //158:1
            __out.AppendLine(); //158:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, COLORINDEX foregroundIndex)"); //159:1
            __out.AppendLine(); //159:98
            __out.Append("        {"); //160:1
            __out.AppendLine(); //160:10
            __out.Append("            return CreateColor(name, type, foregroundIndex, false, false);"); //161:1
            __out.AppendLine(); //161:75
            __out.Append("        }"); //162:1
            __out.AppendLine(); //162:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, Color foregroundColor, bool bold, bool strikethrough)"); //163:1
            __out.AppendLine(); //163:124
            __out.Append("        {"); //164:1
            __out.AppendLine(); //164:10
            string __tmp51Prefix = "            colorableItems.Add(new "; //165:1
            string __tmp52Suffix = "LanguageColorableItem(name, type, (COLORINDEX)(-1), COLORINDEX.CI_USERTEXT_BK, foregroundColor, Color.White, bold, strikethrough));"; //165:66
            StringBuilder __tmp53 = new StringBuilder();
            __tmp53.Append(Properties.LanguageClassName);
            using(StreamReader __tmp53Reader = new StreamReader(this.__ToStream(__tmp53.ToString())))
            {
                bool __tmp53_first = true;
                while(__tmp53_first || !__tmp53Reader.EndOfStream)
                {
                    __tmp53_first = false;
                    string __tmp53Line = __tmp53Reader.ReadLine();
                    if (__tmp53Line == null)
                    {
                        __tmp53Line = "";
                    }
                    __out.Append(__tmp51Prefix);
                    __out.Append(__tmp53Line);
                    __out.Append(__tmp52Suffix);
                    __out.AppendLine(); //165:197
                }
            }
            __out.Append("            return (TokenColor)colorableItems.Count;"); //166:1
            __out.AppendLine(); //166:53
            __out.Append("        }"); //167:1
            __out.AppendLine(); //167:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, COLORINDEX foregroundIndex, bool bold, bool strikethrough)"); //168:1
            __out.AppendLine(); //168:129
            __out.Append("        {"); //169:1
            __out.AppendLine(); //169:10
            string __tmp54Prefix = "            colorableItems.Add(new "; //170:1
            string __tmp55Suffix = "LanguageColorableItem(name, type, foregroundIndex, COLORINDEX.CI_USERTEXT_BK, Color.Black, Color.White, bold, strikethrough));"; //170:66
            StringBuilder __tmp56 = new StringBuilder();
            __tmp56.Append(Properties.LanguageClassName);
            using(StreamReader __tmp56Reader = new StreamReader(this.__ToStream(__tmp56.ToString())))
            {
                bool __tmp56_first = true;
                while(__tmp56_first || !__tmp56Reader.EndOfStream)
                {
                    __tmp56_first = false;
                    string __tmp56Line = __tmp56Reader.ReadLine();
                    if (__tmp56Line == null)
                    {
                        __tmp56Line = "";
                    }
                    __out.Append(__tmp54Prefix);
                    __out.Append(__tmp56Line);
                    __out.Append(__tmp55Suffix);
                    __out.AppendLine(); //170:192
                }
            }
            __out.Append("            return (TokenColor)colorableItems.Count;"); //171:1
            __out.AppendLine(); //171:53
            __out.Append("        }"); //172:1
            __out.AppendLine(); //172:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, COLORINDEX foregroundIndex, COLORINDEX backgroundIndex, Color foregroundColor, Color backgroundColor, bool bold, bool strikethrough)"); //173:1
            __out.AppendLine(); //173:203
            __out.Append("        {"); //174:1
            __out.AppendLine(); //174:10
            string __tmp57Prefix = "            colorableItems.Add(new "; //175:1
            string __tmp58Suffix = "LanguageColorableItem(name, type, foregroundIndex, backgroundIndex, foregroundColor, backgroundColor, bold, strikethrough));"; //175:66
            StringBuilder __tmp59 = new StringBuilder();
            __tmp59.Append(Properties.LanguageClassName);
            using(StreamReader __tmp59Reader = new StreamReader(this.__ToStream(__tmp59.ToString())))
            {
                bool __tmp59_first = true;
                while(__tmp59_first || !__tmp59Reader.EndOfStream)
                {
                    __tmp59_first = false;
                    string __tmp59Line = __tmp59Reader.ReadLine();
                    if (__tmp59Line == null)
                    {
                        __tmp59Line = "";
                    }
                    __out.Append(__tmp57Prefix);
                    __out.Append(__tmp59Line);
                    __out.Append(__tmp58Suffix);
                    __out.AppendLine(); //175:190
                }
            }
            __out.Append("            return (TokenColor)colorableItems.Count;"); //176:1
            __out.AppendLine(); //176:53
            __out.Append("        }"); //177:1
            __out.AppendLine(); //177:10
            __out.Append("    }"); //178:1
            __out.AppendLine(); //178:6
            string __tmp60Prefix = "    public class "; //179:1
            string __tmp61Suffix = "LanguageColorableItem : IVsColorableItem, IVsHiColorItem"; //179:48
            StringBuilder __tmp62 = new StringBuilder();
            __tmp62.Append(Properties.LanguageClassName);
            using(StreamReader __tmp62Reader = new StreamReader(this.__ToStream(__tmp62.ToString())))
            {
                bool __tmp62_first = true;
                while(__tmp62_first || !__tmp62Reader.EndOfStream)
                {
                    __tmp62_first = false;
                    string __tmp62Line = __tmp62Reader.ReadLine();
                    if (__tmp62Line == null)
                    {
                        __tmp62Line = "";
                    }
                    __out.Append(__tmp60Prefix);
                    __out.Append(__tmp62Line);
                    __out.Append(__tmp61Suffix);
                    __out.AppendLine(); //179:104
                }
            }
            __out.Append("    {"); //180:1
            __out.AppendLine(); //180:6
            __out.Append("        // Indicates that the returned RGB value is really an index"); //181:1
            __out.AppendLine(); //181:68
            __out.Append("        // into a predefined list of colors."); //182:1
            __out.AppendLine(); //182:45
            __out.Append("        private const uint COLOR_INDEXED = 0x01000000;"); //183:1
            __out.AppendLine(); //183:55
            __out.Append("        public string DisplayName { get; private set; }"); //185:1
            __out.AppendLine(); //185:56
            __out.Append("        public TokenType TokenType { get; private set; }"); //186:1
            __out.AppendLine(); //186:57
            __out.Append("        public COLORINDEX BackgroundIndex { get; private set; }"); //187:1
            __out.AppendLine(); //187:64
            __out.Append("        public COLORINDEX ForegroundIndex { get; private set; }"); //188:1
            __out.AppendLine(); //188:64
            __out.Append("        public uint BackgroundColor { get; private set; }"); //189:1
            __out.AppendLine(); //189:58
            __out.Append("        public uint ForegroundColor { get; private set; }"); //190:1
            __out.AppendLine(); //190:58
            __out.Append("        public uint FontFlags { get; private set; }"); //191:1
            __out.AppendLine(); //191:52
            string __tmp63Prefix = "        public "; //193:1
            string __tmp64Suffix = "LanguageColorableItem(string displayName, TokenType tokenType, COLORINDEX foregroundIndex, COLORINDEX backgroundIndex, Color foregroundColor, Color backgroundColor, bool bold, bool strikethrough)"; //193:46
            StringBuilder __tmp65 = new StringBuilder();
            __tmp65.Append(Properties.LanguageClassName);
            using(StreamReader __tmp65Reader = new StreamReader(this.__ToStream(__tmp65.ToString())))
            {
                bool __tmp65_first = true;
                while(__tmp65_first || !__tmp65Reader.EndOfStream)
                {
                    __tmp65_first = false;
                    string __tmp65Line = __tmp65Reader.ReadLine();
                    if (__tmp65Line == null)
                    {
                        __tmp65Line = "";
                    }
                    __out.Append(__tmp63Prefix);
                    __out.Append(__tmp65Line);
                    __out.Append(__tmp64Suffix);
                    __out.AppendLine(); //193:241
                }
            }
            __out.Append("        {"); //194:1
            __out.AppendLine(); //194:10
            __out.Append("            this.DisplayName = displayName;"); //195:1
            __out.AppendLine(); //195:44
            __out.Append("            this.TokenType = tokenType;"); //196:1
            __out.AppendLine(); //196:40
            __out.Append("            this.BackgroundIndex = backgroundIndex;"); //197:1
            __out.AppendLine(); //197:52
            __out.Append("            this.ForegroundIndex = foregroundIndex;"); //198:1
            __out.AppendLine(); //198:52
            __out.Append("            this.BackgroundColor = (uint)System.Drawing.ColorTranslator.ToWin32(backgroundColor);"); //199:1
            __out.AppendLine(); //199:98
            __out.Append("            this.ForegroundColor = (uint)System.Drawing.ColorTranslator.ToWin32(foregroundColor);"); //200:1
            __out.AppendLine(); //200:98
            __out.Append("            this.FontFlags = (uint)FONTFLAGS.FF_DEFAULT;"); //201:1
            __out.AppendLine(); //201:57
            __out.Append("            if (bold)"); //202:1
            __out.AppendLine(); //202:22
            __out.Append("                this.FontFlags = this.FontFlags | (uint)FONTFLAGS.FF_BOLD;"); //203:1
            __out.AppendLine(); //203:75
            __out.Append("            if (strikethrough)"); //204:1
            __out.AppendLine(); //204:31
            __out.Append("                this.FontFlags = this.FontFlags | (uint)FONTFLAGS.FF_STRIKETHROUGH;"); //205:1
            __out.AppendLine(); //205:84
            __out.Append("        }"); //206:1
            __out.AppendLine(); //206:10
            __out.Append("        #region IVsColorableItem Members"); //208:1
            __out.AppendLine(); //208:41
            string __tmp66Prefix = "        public int GetDefaultColors(COLORINDEX"; //209:1
            string __tmp67Suffix = " piBackground)"; //209:84
            StringBuilder __tmp68 = new StringBuilder();
            __tmp68.Append("[]");
            using(StreamReader __tmp68Reader = new StreamReader(this.__ToStream(__tmp68.ToString())))
            {
                bool __tmp68_first = true;
                while(__tmp68_first || !__tmp68Reader.EndOfStream)
                {
                    __tmp68_first = false;
                    string __tmp68Line = __tmp68Reader.ReadLine();
                    if (__tmp68Line == null)
                    {
                        __tmp68Line = "";
                    }
                    __out.Append(__tmp66Prefix);
                    __out.Append(__tmp68Line);
                }
            }
            string __tmp69Line = " piForeground, COLORINDEX"; //209:53
            __out.Append(__tmp69Line);
            StringBuilder __tmp70 = new StringBuilder();
            __tmp70.Append("[]");
            using(StreamReader __tmp70Reader = new StreamReader(this.__ToStream(__tmp70.ToString())))
            {
                bool __tmp70_first = true;
                while(__tmp70_first || !__tmp70Reader.EndOfStream)
                {
                    __tmp70_first = false;
                    string __tmp70Line = __tmp70Reader.ReadLine();
                    if (__tmp70Line == null)
                    {
                        __tmp70Line = "";
                    }
                    __out.Append(__tmp70Line);
                    __out.Append(__tmp67Suffix);
                    __out.AppendLine(); //209:98
                }
            }
            __out.Append("        {"); //210:1
            __out.AppendLine(); //210:10
            __out.Append("            if (null == piForeground)"); //211:1
            __out.AppendLine(); //211:38
            __out.Append("            {"); //212:1
            __out.AppendLine(); //212:14
            __out.Append("                throw new ArgumentNullException(\"piForeground\");"); //213:1
            __out.AppendLine(); //213:65
            __out.Append("            }"); //214:1
            __out.AppendLine(); //214:14
            __out.Append("            if (0 == piForeground.Length)"); //215:1
            __out.AppendLine(); //215:42
            __out.Append("            {"); //216:1
            __out.AppendLine(); //216:14
            __out.Append("                throw new ArgumentOutOfRangeException(\"piForeground\");"); //217:1
            __out.AppendLine(); //217:71
            __out.Append("            }"); //218:1
            __out.AppendLine(); //218:14
            string __tmp71Prefix = "            piForeground"; //219:1
            string __tmp72Suffix = " = this.ForegroundIndex;"; //219:32
            StringBuilder __tmp73 = new StringBuilder();
            __tmp73.Append("[0]");
            using(StreamReader __tmp73Reader = new StreamReader(this.__ToStream(__tmp73.ToString())))
            {
                bool __tmp73_first = true;
                while(__tmp73_first || !__tmp73Reader.EndOfStream)
                {
                    __tmp73_first = false;
                    string __tmp73Line = __tmp73Reader.ReadLine();
                    if (__tmp73Line == null)
                    {
                        __tmp73Line = "";
                    }
                    __out.Append(__tmp71Prefix);
                    __out.Append(__tmp73Line);
                    __out.Append(__tmp72Suffix);
                    __out.AppendLine(); //219:56
                }
            }
            __out.Append("            if (null == piBackground)"); //220:1
            __out.AppendLine(); //220:38
            __out.Append("            {"); //221:1
            __out.AppendLine(); //221:14
            __out.Append("                throw new ArgumentNullException(\"piBackground\");"); //222:1
            __out.AppendLine(); //222:65
            __out.Append("            }"); //223:1
            __out.AppendLine(); //223:14
            __out.Append("            if (0 == piBackground.Length)"); //224:1
            __out.AppendLine(); //224:42
            __out.Append("            {"); //225:1
            __out.AppendLine(); //225:14
            __out.Append("                throw new ArgumentOutOfRangeException(\"piBackground\");"); //226:1
            __out.AppendLine(); //226:71
            __out.Append("            }"); //227:1
            __out.AppendLine(); //227:14
            string __tmp74Prefix = "            piBackground"; //228:1
            string __tmp75Suffix = " = this.BackgroundIndex;"; //228:32
            StringBuilder __tmp76 = new StringBuilder();
            __tmp76.Append("[0]");
            using(StreamReader __tmp76Reader = new StreamReader(this.__ToStream(__tmp76.ToString())))
            {
                bool __tmp76_first = true;
                while(__tmp76_first || !__tmp76Reader.EndOfStream)
                {
                    __tmp76_first = false;
                    string __tmp76Line = __tmp76Reader.ReadLine();
                    if (__tmp76Line == null)
                    {
                        __tmp76Line = "";
                    }
                    __out.Append(__tmp74Prefix);
                    __out.Append(__tmp76Line);
                    __out.Append(__tmp75Suffix);
                    __out.AppendLine(); //228:56
                }
            }
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //229:1
            __out.AppendLine(); //229:60
            __out.Append("        }"); //230:1
            __out.AppendLine(); //230:10
            __out.Append("        public int GetDefaultFontFlags(out uint pdwFontFlags)"); //231:1
            __out.AppendLine(); //231:62
            __out.Append("        {"); //232:1
            __out.AppendLine(); //232:10
            __out.Append("            pdwFontFlags = this.FontFlags;"); //233:1
            __out.AppendLine(); //233:43
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //234:1
            __out.AppendLine(); //234:60
            __out.Append("        }"); //235:1
            __out.AppendLine(); //235:10
            __out.Append("        public int GetDisplayName(out string pbstrName)"); //236:1
            __out.AppendLine(); //236:56
            __out.Append("        {"); //237:1
            __out.AppendLine(); //237:10
            __out.Append("            pbstrName = this.DisplayName;"); //238:1
            __out.AppendLine(); //238:42
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //239:1
            __out.AppendLine(); //239:60
            __out.Append("        }"); //240:1
            __out.AppendLine(); //240:10
            __out.Append("        public int GetColorData(int cdElement, out uint pcrColor)"); //242:1
            __out.AppendLine(); //242:66
            __out.Append("        {"); //243:1
            __out.AppendLine(); //243:10
            __out.Append("            int retval = VSConstants.E_NOTIMPL;"); //244:1
            __out.AppendLine(); //244:48
            __out.Append("            pcrColor = 0;"); //245:1
            __out.AppendLine(); //245:26
            __out.Append("            switch ((__tagVSCOLORDATA)cdElement)"); //247:1
            __out.AppendLine(); //247:49
            __out.Append("            {"); //248:1
            __out.AppendLine(); //248:14
            __out.Append("                case __tagVSCOLORDATA.CD_BACKGROUND:"); //249:1
            __out.AppendLine(); //249:53
            __out.Append("                    pcrColor = this.BackgroundIndex > 0 ?"); //250:1
            __out.AppendLine(); //250:58
            __out.Append("                                   (uint)this.BackgroundIndex | COLOR_INDEXED"); //251:1
            __out.AppendLine(); //251:78
            __out.Append("                                   : this.BackgroundColor;"); //252:1
            __out.AppendLine(); //252:59
            __out.Append("                    retval = VSConstants.S_OK;"); //253:1
            __out.AppendLine(); //253:47
            __out.Append("                    break;"); //254:1
            __out.AppendLine(); //254:27
            __out.Append("                case __tagVSCOLORDATA.CD_FOREGROUND:"); //256:1
            __out.AppendLine(); //256:53
            __out.Append("                case __tagVSCOLORDATA.CD_LINECOLOR:"); //257:1
            __out.AppendLine(); //257:52
            __out.Append("                    pcrColor = this.ForegroundIndex > 0 ?"); //258:1
            __out.AppendLine(); //258:58
            __out.Append("                                   (uint)this.ForegroundIndex | COLOR_INDEXED"); //259:1
            __out.AppendLine(); //259:78
            __out.Append("                                   : this.ForegroundColor;"); //260:1
            __out.AppendLine(); //260:59
            __out.Append("                    retval = VSConstants.S_OK;"); //261:1
            __out.AppendLine(); //261:47
            __out.Append("                    break;"); //262:1
            __out.AppendLine(); //262:27
            __out.Append("                default:"); //264:1
            __out.AppendLine(); //264:25
            __out.Append("                    retval = VSConstants.E_INVALIDARG;"); //265:1
            __out.AppendLine(); //265:55
            __out.Append("                    break;"); //266:1
            __out.AppendLine(); //266:27
            __out.Append("            }"); //267:1
            __out.AppendLine(); //267:14
            __out.Append("            return retval;"); //268:1
            __out.AppendLine(); //268:27
            __out.Append("        }"); //270:1
            __out.AppendLine(); //270:10
            __out.Append("        #endregion"); //271:1
            __out.AppendLine(); //271:19
            __out.Append("    }"); //272:1
            __out.AppendLine(); //272:6
            string __tmp77Prefix = "    "; //275:1
            string __tmp78Suffix = string.Empty; 
            StringBuilder __tmp79 = new StringBuilder();
            __tmp79.Append("[ComVisible(true)]");
            using(StreamReader __tmp79Reader = new StreamReader(this.__ToStream(__tmp79.ToString())))
            {
                bool __tmp79_first = true;
                while(__tmp79_first || !__tmp79Reader.EndOfStream)
                {
                    __tmp79_first = false;
                    string __tmp79Line = __tmp79Reader.ReadLine();
                    if (__tmp79Line == null)
                    {
                        __tmp79Line = "";
                    }
                    __out.Append(__tmp77Prefix);
                    __out.Append(__tmp79Line);
                    __out.Append(__tmp78Suffix);
                    __out.AppendLine(); //275:27
                }
            }
            string __tmp80Prefix = "    "; //276:1
            string __tmp81Suffix = string.Empty; 
            StringBuilder __tmp82 = new StringBuilder();
            __tmp82.Append("[Guid(" + Properties.LanguageClassName + "LanguageConfig." + Properties.LanguageClassName + "LanguageGeneratorServiceGuid)]");
            using(StreamReader __tmp82Reader = new StreamReader(this.__ToStream(__tmp82.ToString())))
            {
                bool __tmp82_first = true;
                while(__tmp82_first || !__tmp82Reader.EndOfStream)
                {
                    __tmp82_first = false;
                    string __tmp82Line = __tmp82Reader.ReadLine();
                    if (__tmp82Line == null)
                    {
                        __tmp82Line = "";
                    }
                    __out.Append(__tmp80Prefix);
                    __out.Append(__tmp82Line);
                    __out.Append(__tmp81Suffix);
                    __out.AppendLine(); //276:124
                }
            }
            if (Properties.GenerateMultipleFiles) //277:3
            {
                string __tmp83Prefix = "    public class "; //278:1
                string __tmp84Suffix = "LanguageGeneratorService : VsMultipleFileGenerator<object>"; //278:48
                StringBuilder __tmp85 = new StringBuilder();
                __tmp85.Append(Properties.LanguageClassName);
                using(StreamReader __tmp85Reader = new StreamReader(this.__ToStream(__tmp85.ToString())))
                {
                    bool __tmp85_first = true;
                    while(__tmp85_first || !__tmp85Reader.EndOfStream)
                    {
                        __tmp85_first = false;
                        string __tmp85Line = __tmp85Reader.ReadLine();
                        if (__tmp85Line == null)
                        {
                            __tmp85Line = "";
                        }
                        __out.Append(__tmp83Prefix);
                        __out.Append(__tmp85Line);
                        __out.Append(__tmp84Suffix);
                        __out.AppendLine(); //278:106
                    }
                }
                __out.Append("    {"); //279:1
                __out.AppendLine(); //279:6
                __out.Append("        protected override MultipleFileGenerator<object> CreateGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)"); //280:1
                __out.AppendLine(); //280:146
                __out.Append("		{"); //281:1
                __out.AppendLine(); //281:4
                string __tmp86Prefix = "            // If there is a compile error in the following line, create a class "; //282:1
                string __tmp87Suffix = "Generator"; //282:112
                StringBuilder __tmp88 = new StringBuilder();
                __tmp88.Append(Properties.LanguageClassName);
                using(StreamReader __tmp88Reader = new StreamReader(this.__ToStream(__tmp88.ToString())))
                {
                    bool __tmp88_first = true;
                    while(__tmp88_first || !__tmp88Reader.EndOfStream)
                    {
                        __tmp88_first = false;
                        string __tmp88Line = __tmp88Reader.ReadLine();
                        if (__tmp88Line == null)
                        {
                            __tmp88Line = "";
                        }
                        __out.Append(__tmp86Prefix);
                        __out.Append(__tmp88Line);
                        __out.Append(__tmp87Suffix);
                        __out.AppendLine(); //282:121
                    }
                }
                __out.Append("            // which is a subclass of MultipleFileGenerator<object>"); //283:1
                __out.AppendLine(); //283:68
                string __tmp89Prefix = "			return new "; //284:1
                string __tmp90Suffix = "Generator(inputFilePath, inputFileContents, defaultNamespace);"; //284:45
                StringBuilder __tmp91 = new StringBuilder();
                __tmp91.Append(Properties.LanguageClassName);
                using(StreamReader __tmp91Reader = new StreamReader(this.__ToStream(__tmp91.ToString())))
                {
                    bool __tmp91_first = true;
                    while(__tmp91_first || !__tmp91Reader.EndOfStream)
                    {
                        __tmp91_first = false;
                        string __tmp91Line = __tmp91Reader.ReadLine();
                        if (__tmp91Line == null)
                        {
                            __tmp91Line = "";
                        }
                        __out.Append(__tmp89Prefix);
                        __out.Append(__tmp91Line);
                        __out.Append(__tmp90Suffix);
                        __out.AppendLine(); //284:107
                    }
                }
                __out.Append("		}"); //285:1
                __out.AppendLine(); //285:4
                __out.Append("    }"); //286:1
                __out.AppendLine(); //286:6
            }
            else //287:3
            {
                string __tmp92Prefix = "    public class "; //288:1
                string __tmp93Suffix = "LanguageGeneratorService : VsSingleFileGenerator"; //288:48
                StringBuilder __tmp94 = new StringBuilder();
                __tmp94.Append(Properties.LanguageClassName);
                using(StreamReader __tmp94Reader = new StreamReader(this.__ToStream(__tmp94.ToString())))
                {
                    bool __tmp94_first = true;
                    while(__tmp94_first || !__tmp94Reader.EndOfStream)
                    {
                        __tmp94_first = false;
                        string __tmp94Line = __tmp94Reader.ReadLine();
                        if (__tmp94Line == null)
                        {
                            __tmp94Line = "";
                        }
                        __out.Append(__tmp92Prefix);
                        __out.Append(__tmp94Line);
                        __out.Append(__tmp93Suffix);
                        __out.AppendLine(); //288:96
                    }
                }
                __out.Append("    {"); //289:1
                __out.AppendLine(); //289:6
                __out.Append("        protected override SingleFileGenerator CreateGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)"); //290:1
                __out.AppendLine(); //290:136
                __out.Append("		{"); //291:1
                __out.AppendLine(); //291:4
                string __tmp95Prefix = "            // If there is a compile error in the following line, create a class "; //292:1
                string __tmp96Suffix = "Generator"; //292:112
                StringBuilder __tmp97 = new StringBuilder();
                __tmp97.Append(Properties.LanguageClassName);
                using(StreamReader __tmp97Reader = new StreamReader(this.__ToStream(__tmp97.ToString())))
                {
                    bool __tmp97_first = true;
                    while(__tmp97_first || !__tmp97Reader.EndOfStream)
                    {
                        __tmp97_first = false;
                        string __tmp97Line = __tmp97Reader.ReadLine();
                        if (__tmp97Line == null)
                        {
                            __tmp97Line = "";
                        }
                        __out.Append(__tmp95Prefix);
                        __out.Append(__tmp97Line);
                        __out.Append(__tmp96Suffix);
                        __out.AppendLine(); //292:121
                    }
                }
                __out.Append("            // which is a subclass of SingleFileGenerator"); //293:1
                __out.AppendLine(); //293:58
                string __tmp98Prefix = "			return new "; //294:1
                string __tmp99Suffix = "Generator(inputFilePath, inputFileContents, defaultNamespace);"; //294:45
                StringBuilder __tmp100 = new StringBuilder();
                __tmp100.Append(Properties.LanguageClassName);
                using(StreamReader __tmp100Reader = new StreamReader(this.__ToStream(__tmp100.ToString())))
                {
                    bool __tmp100_first = true;
                    while(__tmp100_first || !__tmp100Reader.EndOfStream)
                    {
                        __tmp100_first = false;
                        string __tmp100Line = __tmp100Reader.ReadLine();
                        if (__tmp100Line == null)
                        {
                            __tmp100Line = "";
                        }
                        __out.Append(__tmp98Prefix);
                        __out.Append(__tmp100Line);
                        __out.Append(__tmp99Suffix);
                        __out.AppendLine(); //294:107
                    }
                }
                __out.Append("		}"); //295:1
                __out.AppendLine(); //295:4
                __out.Append("    }"); //296:1
                __out.AppendLine(); //296:6
            }
            string __tmp101Prefix = "    public class "; //300:1
            string __tmp102Suffix = "LanguageScanner : IScanner"; //300:48
            StringBuilder __tmp103 = new StringBuilder();
            __tmp103.Append(Properties.LanguageClassName);
            using(StreamReader __tmp103Reader = new StreamReader(this.__ToStream(__tmp103.ToString())))
            {
                bool __tmp103_first = true;
                while(__tmp103_first || !__tmp103Reader.EndOfStream)
                {
                    __tmp103_first = false;
                    string __tmp103Line = __tmp103Reader.ReadLine();
                    if (__tmp103Line == null)
                    {
                        __tmp103Line = "";
                    }
                    __out.Append(__tmp101Prefix);
                    __out.Append(__tmp103Line);
                    __out.Append(__tmp102Suffix);
                    __out.AppendLine(); //300:74
                }
            }
            __out.Append("    {"); //301:1
            __out.AppendLine(); //301:6
            __out.Append("        private int currentOffset;"); //302:1
            __out.AppendLine(); //302:35
            __out.Append("        private string currentLine;"); //303:1
            __out.AppendLine(); //303:36
            string __tmp104Prefix = "        private "; //304:1
            string __tmp105Suffix = "Lexer lexer;"; //304:46
            StringBuilder __tmp106 = new StringBuilder();
            __tmp106.Append(Properties.LanguageFullName);
            using(StreamReader __tmp106Reader = new StreamReader(this.__ToStream(__tmp106.ToString())))
            {
                bool __tmp106_first = true;
                while(__tmp106_first || !__tmp106Reader.EndOfStream)
                {
                    __tmp106_first = false;
                    string __tmp106Line = __tmp106Reader.ReadLine();
                    if (__tmp106Line == null)
                    {
                        __tmp106Line = "";
                    }
                    __out.Append(__tmp104Prefix);
                    __out.Append(__tmp106Line);
                    __out.Append(__tmp105Suffix);
                    __out.AppendLine(); //304:58
                }
            }
            __out.Append("        private IEnumerable<SyntaxAnnotation> modeAnnotations;"); //305:1
            __out.AppendLine(); //305:63
            __out.Append("        private IEnumerable<SyntaxAnnotation> syntaxAnnotations;"); //306:1
            __out.AppendLine(); //306:65
            __out.Append("        private Dictionary<LanguageScannerState, int> inverseStates;"); //307:1
            __out.AppendLine(); //307:69
            __out.Append("        private Dictionary<int, LanguageScannerState> states;"); //308:1
            __out.AppendLine(); //308:62
            __out.Append("        private int lastState;"); //309:1
            __out.AppendLine(); //309:31
            string __tmp107Prefix = "        public "; //311:1
            string __tmp108Suffix = "LanguageScanner()"; //311:46
            StringBuilder __tmp109 = new StringBuilder();
            __tmp109.Append(Properties.LanguageClassName);
            using(StreamReader __tmp109Reader = new StreamReader(this.__ToStream(__tmp109.ToString())))
            {
                bool __tmp109_first = true;
                while(__tmp109_first || !__tmp109Reader.EndOfStream)
                {
                    __tmp109_first = false;
                    string __tmp109Line = __tmp109Reader.ReadLine();
                    if (__tmp109Line == null)
                    {
                        __tmp109Line = "";
                    }
                    __out.Append(__tmp107Prefix);
                    __out.Append(__tmp109Line);
                    __out.Append(__tmp108Suffix);
                    __out.AppendLine(); //311:63
                }
            }
            __out.Append("        {"); //312:1
            __out.AppendLine(); //312:10
            __out.Append("            this.inverseStates = new Dictionary<LanguageScannerState, int>();"); //313:1
            __out.AppendLine(); //313:78
            __out.Append("            this.states = new Dictionary<int, LanguageScannerState>();"); //314:1
            __out.AppendLine(); //314:71
            __out.Append("            this.lastState = 0;"); //315:1
            __out.AppendLine(); //315:32
            string __tmp110Prefix = "            "; //316:1
            string __tmp111Suffix = "LexerAnnotator();"; //316:102
            StringBuilder __tmp112 = new StringBuilder();
            __tmp112.Append(Properties.LanguageFullName);
            using(StreamReader __tmp112Reader = new StreamReader(this.__ToStream(__tmp112.ToString())))
            {
                bool __tmp112_first = true;
                while(__tmp112_first || !__tmp112Reader.EndOfStream)
                {
                    __tmp112_first = false;
                    string __tmp112Line = __tmp112Reader.ReadLine();
                    if (__tmp112Line == null)
                    {
                        __tmp112Line = "";
                    }
                    __out.Append(__tmp110Prefix);
                    __out.Append(__tmp112Line);
                }
            }
            string __tmp113Line = "LexerAnnotator annotator = new "; //316:42
            __out.Append(__tmp113Line);
            StringBuilder __tmp114 = new StringBuilder();
            __tmp114.Append(Properties.LanguageFullName);
            using(StreamReader __tmp114Reader = new StreamReader(this.__ToStream(__tmp114.ToString())))
            {
                bool __tmp114_first = true;
                while(__tmp114_first || !__tmp114Reader.EndOfStream)
                {
                    __tmp114_first = false;
                    string __tmp114Line = __tmp114Reader.ReadLine();
                    if (__tmp114Line == null)
                    {
                        __tmp114Line = "";
                    }
                    __out.Append(__tmp114Line);
                    __out.Append(__tmp111Suffix);
                    __out.AppendLine(); //316:119
                }
            }
            __out.Append("            List<SyntaxAnnotation> mal = new List<SyntaxAnnotation>();"); //317:1
            __out.AppendLine(); //317:71
            __out.Append("            foreach (var annotList in annotator.ModeAnnotations.Values)"); //318:1
            __out.AppendLine(); //318:72
            __out.Append("            {"); //319:1
            __out.AppendLine(); //319:14
            __out.Append("                foreach (var annot in annotList)"); //320:1
            __out.AppendLine(); //320:49
            __out.Append("                {"); //321:1
            __out.AppendLine(); //321:18
            __out.Append("                    if (annot is SyntaxAnnotation)"); //322:1
            __out.AppendLine(); //322:51
            __out.Append("                    {"); //323:1
            __out.AppendLine(); //323:22
            __out.Append("                        mal.Add((SyntaxAnnotation)annot);"); //324:1
            __out.AppendLine(); //324:58
            __out.Append("                    }"); //325:1
            __out.AppendLine(); //325:22
            __out.Append("                }"); //326:1
            __out.AppendLine(); //326:18
            __out.Append("            }"); //327:1
            __out.AppendLine(); //327:14
            __out.Append("            this.modeAnnotations = mal;"); //328:1
            __out.AppendLine(); //328:40
            __out.Append("            List<SyntaxAnnotation> sal = new List<SyntaxAnnotation>();"); //329:1
            __out.AppendLine(); //329:71
            __out.Append("            foreach (var annotList in annotator.TokenAnnotations.Values)"); //330:1
            __out.AppendLine(); //330:73
            __out.Append("            {"); //331:1
            __out.AppendLine(); //331:14
            __out.Append("                foreach (var annot in annotList)"); //332:1
            __out.AppendLine(); //332:49
            __out.Append("                {"); //333:1
            __out.AppendLine(); //333:18
            __out.Append("                    if (annot is SyntaxAnnotation)"); //334:1
            __out.AppendLine(); //334:51
            __out.Append("                    {"); //335:1
            __out.AppendLine(); //335:22
            __out.Append("                        sal.Add((SyntaxAnnotation)annot);"); //336:1
            __out.AppendLine(); //336:58
            __out.Append("                    }"); //337:1
            __out.AppendLine(); //337:22
            __out.Append("                }"); //338:1
            __out.AppendLine(); //338:18
            __out.Append("            }"); //339:1
            __out.AppendLine(); //339:14
            __out.Append("            this.syntaxAnnotations = sal;"); //340:1
            __out.AppendLine(); //340:42
            __out.Append("        }"); //341:1
            __out.AppendLine(); //341:10
            string __tmp115Prefix = "        private void LoadState(int state, "; //343:1
            string __tmp116Suffix = "Lexer lexer)"; //343:72
            StringBuilder __tmp117 = new StringBuilder();
            __tmp117.Append(Properties.LanguageFullName);
            using(StreamReader __tmp117Reader = new StreamReader(this.__ToStream(__tmp117.ToString())))
            {
                bool __tmp117_first = true;
                while(__tmp117_first || !__tmp117Reader.EndOfStream)
                {
                    __tmp117_first = false;
                    string __tmp117Line = __tmp117Reader.ReadLine();
                    if (__tmp117Line == null)
                    {
                        __tmp117Line = "";
                    }
                    __out.Append(__tmp115Prefix);
                    __out.Append(__tmp117Line);
                    __out.Append(__tmp116Suffix);
                    __out.AppendLine(); //343:84
                }
            }
            __out.Append("        {"); //344:1
            __out.AppendLine(); //344:10
            __out.Append("            LanguageScannerState value = default(LanguageScannerState);"); //345:1
            __out.AppendLine(); //345:72
            __out.Append("            this.states.TryGetValue(state, out value);"); //346:1
            __out.AppendLine(); //346:55
            __out.Append("            value.Restore(lexer);"); //347:1
            __out.AppendLine(); //347:34
            __out.Append("        }"); //348:1
            __out.AppendLine(); //348:10
            string __tmp118Prefix = "        private int SaveState("; //350:1
            string __tmp119Suffix = "Lexer lexer)"; //350:60
            StringBuilder __tmp120 = new StringBuilder();
            __tmp120.Append(Properties.LanguageFullName);
            using(StreamReader __tmp120Reader = new StreamReader(this.__ToStream(__tmp120.ToString())))
            {
                bool __tmp120_first = true;
                while(__tmp120_first || !__tmp120Reader.EndOfStream)
                {
                    __tmp120_first = false;
                    string __tmp120Line = __tmp120Reader.ReadLine();
                    if (__tmp120Line == null)
                    {
                        __tmp120Line = "";
                    }
                    __out.Append(__tmp118Prefix);
                    __out.Append(__tmp120Line);
                    __out.Append(__tmp119Suffix);
                    __out.AppendLine(); //350:72
                }
            }
            __out.Append("        {"); //351:1
            __out.AppendLine(); //351:10
            __out.Append("            int result = 0;"); //352:1
            __out.AppendLine(); //352:28
            __out.Append("            LanguageScannerState state = new LanguageScannerState(lexer);"); //353:1
            __out.AppendLine(); //353:74
            __out.Append("            if (!this.inverseStates.TryGetValue(state, out result))"); //354:1
            __out.AppendLine(); //354:68
            __out.Append("            {"); //355:1
            __out.AppendLine(); //355:14
            __out.Append("                result = ++lastState;"); //356:1
            __out.AppendLine(); //356:38
            __out.Append("                this.states.Add(result, state);"); //357:1
            __out.AppendLine(); //357:48
            __out.Append("                this.inverseStates.Add(state, result);"); //358:1
            __out.AppendLine(); //358:55
            __out.Append("            }"); //359:1
            __out.AppendLine(); //359:14
            __out.Append("            return result;"); //360:1
            __out.AppendLine(); //360:27
            __out.Append("        }"); //361:1
            __out.AppendLine(); //361:10
            __out.Append("        public bool ScanTokenAndProvideInfoAboutIt(TokenInfo tokenInfo, ref int state)"); //363:1
            __out.AppendLine(); //363:87
            __out.Append("        {"); //364:1
            __out.AppendLine(); //364:10
            __out.Append("            try"); //365:1
            __out.AppendLine(); //365:16
            __out.Append("            {"); //366:1
            __out.AppendLine(); //366:14
            __out.Append("                if (this.lexer == null)"); //367:1
            __out.AppendLine(); //367:40
            __out.Append("                {"); //368:1
            __out.AppendLine(); //368:18
            string __tmp121Prefix = "                    this.lexer = new "; //369:1
            string __tmp122Suffix = "n\"));"; //369:117
            StringBuilder __tmp123 = new StringBuilder();
            __tmp123.Append(Properties.LanguageFullName);
            using(StreamReader __tmp123Reader = new StreamReader(this.__ToStream(__tmp123.ToString())))
            {
                bool __tmp123_first = true;
                while(__tmp123_first || !__tmp123Reader.EndOfStream)
                {
                    __tmp123_first = false;
                    string __tmp123Line = __tmp123Reader.ReadLine();
                    if (__tmp123Line == null)
                    {
                        __tmp123Line = "";
                    }
                    __out.Append(__tmp121Prefix);
                    __out.Append(__tmp123Line);
                }
            }
            string __tmp124Line = "Lexer(new AntlrInputStream(this.currentLine + \""; //369:67
            __out.Append(__tmp124Line);
            string __tmp125Line = "\\"; //369:114
            __out.Append(__tmp125Line);
            string __tmp126Line = "r"; //369:115
            __out.Append(__tmp126Line);
            string __tmp127Line = "\\"; //369:116
            __out.Append(__tmp127Line);
            __out.Append(__tmp122Suffix);
            __out.AppendLine(); //369:122
            __out.Append("                }"); //370:1
            __out.AppendLine(); //370:18
            __out.Append("                this.LoadState(state, this.lexer);"); //371:1
            __out.AppendLine(); //371:51
            __out.Append("                IToken token = this.lexer.NextToken();"); //372:1
            __out.AppendLine(); //372:55
            __out.Append("                int tokenType = -1;"); //373:1
            __out.AppendLine(); //373:36
            __out.Append("                foreach (var modeAnnot in this.modeAnnotations)"); //375:1
            __out.AppendLine(); //375:64
            __out.Append("                {"); //376:1
            __out.AppendLine(); //376:18
            __out.Append("                    if (this.lexer.CurrentMode >= modeAnnot.First && this.lexer.CurrentMode <= modeAnnot.Last)"); //377:1
            __out.AppendLine(); //377:111
            __out.Append("                    {"); //378:1
            __out.AppendLine(); //378:22
            __out.Append("                        tokenType = modeAnnot.Kind;"); //379:1
            __out.AppendLine(); //379:52
            __out.Append("                        break;"); //380:1
            __out.AppendLine(); //380:31
            __out.Append("                    }"); //381:1
            __out.AppendLine(); //381:22
            __out.Append("                }"); //382:1
            __out.AppendLine(); //382:18
            __out.Append("                foreach (var syntaxAnnot in this.syntaxAnnotations)"); //383:1
            __out.AppendLine(); //383:68
            __out.Append("                {"); //384:1
            __out.AppendLine(); //384:18
            __out.Append("                    if (token.Type >= syntaxAnnot.First && token.Type <= syntaxAnnot.Last)"); //385:1
            __out.AppendLine(); //385:91
            __out.Append("                    {"); //386:1
            __out.AppendLine(); //386:22
            __out.Append("                        tokenType = syntaxAnnot.Kind;"); //387:1
            __out.AppendLine(); //387:54
            __out.Append("                        break;"); //388:1
            __out.AppendLine(); //388:31
            __out.Append("                    }"); //389:1
            __out.AppendLine(); //389:22
            __out.Append("                }"); //390:1
            __out.AppendLine(); //390:18
            string __tmp128Prefix = "                if (tokenType >= 1 && tokenType <= "; //392:1
            string __tmp129Suffix = "LanguageConfig.Instance.ColorableItems.Count)"; //392:82
            StringBuilder __tmp130 = new StringBuilder();
            __tmp130.Append(Properties.LanguageClassName);
            using(StreamReader __tmp130Reader = new StreamReader(this.__ToStream(__tmp130.ToString())))
            {
                bool __tmp130_first = true;
                while(__tmp130_first || !__tmp130Reader.EndOfStream)
                {
                    __tmp130_first = false;
                    string __tmp130Line = __tmp130Reader.ReadLine();
                    if (__tmp130Line == null)
                    {
                        __tmp130Line = "";
                    }
                    __out.Append(__tmp128Prefix);
                    __out.Append(__tmp130Line);
                    __out.Append(__tmp129Suffix);
                    __out.AppendLine(); //392:127
                }
            }
            __out.Append("                {"); //393:1
            __out.AppendLine(); //393:18
            string __tmp131Prefix = "                    "; //394:1
            string __tmp132Suffix = ";"; //394:172
            StringBuilder __tmp133 = new StringBuilder();
            __tmp133.Append(Properties.LanguageClassName);
            using(StreamReader __tmp133Reader = new StreamReader(this.__ToStream(__tmp133.ToString())))
            {
                bool __tmp133_first = true;
                while(__tmp133_first || !__tmp133Reader.EndOfStream)
                {
                    __tmp133_first = false;
                    string __tmp133Line = __tmp133Reader.ReadLine();
                    if (__tmp133Line == null)
                    {
                        __tmp133Line = "";
                    }
                    __out.Append(__tmp131Prefix);
                    __out.Append(__tmp133Line);
                }
            }
            string __tmp134Line = "LanguageColorableItem colorItem = "; //394:51
            __out.Append(__tmp134Line);
            StringBuilder __tmp135 = new StringBuilder();
            __tmp135.Append(Properties.LanguageClassName);
            using(StreamReader __tmp135Reader = new StreamReader(this.__ToStream(__tmp135.ToString())))
            {
                bool __tmp135_first = true;
                while(__tmp135_first || !__tmp135Reader.EndOfStream)
                {
                    __tmp135_first = false;
                    string __tmp135Line = __tmp135Reader.ReadLine();
                    if (__tmp135Line == null)
                    {
                        __tmp135Line = "";
                    }
                    __out.Append(__tmp135Line);
                }
            }
            string __tmp136Line = "LanguageConfig.Instance.ColorableItems"; //394:115
            __out.Append(__tmp136Line);
            StringBuilder __tmp137 = new StringBuilder();
            __tmp137.Append("[tokenType - 1]");
            using(StreamReader __tmp137Reader = new StreamReader(this.__ToStream(__tmp137.ToString())))
            {
                bool __tmp137_first = true;
                while(__tmp137_first || !__tmp137Reader.EndOfStream)
                {
                    __tmp137_first = false;
                    string __tmp137Line = __tmp137Reader.ReadLine();
                    if (__tmp137Line == null)
                    {
                        __tmp137Line = "";
                    }
                    __out.Append(__tmp137Line);
                    __out.Append(__tmp132Suffix);
                    __out.AppendLine(); //394:173
                }
            }
            __out.Append("                    tokenInfo.Token = token.Type;"); //395:1
            __out.AppendLine(); //395:50
            __out.Append("                    tokenInfo.Type = colorItem.TokenType;"); //396:1
            __out.AppendLine(); //396:58
            __out.Append("                    tokenInfo.Color = (TokenColor)tokenType;"); //397:1
            __out.AppendLine(); //397:61
            __out.Append("                    tokenInfo.Trigger = TokenTriggers.None;"); //398:1
            __out.AppendLine(); //398:60
            __out.Append("                }"); //399:1
            __out.AppendLine(); //399:18
            __out.Append("                else"); //400:1
            __out.AppendLine(); //400:21
            __out.Append("                {"); //401:1
            __out.AppendLine(); //401:18
            __out.Append("                    tokenInfo.Token = token.Type;"); //402:1
            __out.AppendLine(); //402:50
            __out.Append("                    tokenInfo.Type = TokenType.Text;"); //403:1
            __out.AppendLine(); //403:53
            __out.Append("                    tokenInfo.Color = TokenColor.Text;"); //404:1
            __out.AppendLine(); //404:55
            __out.Append("                    tokenInfo.Trigger = TokenTriggers.None;"); //405:1
            __out.AppendLine(); //405:60
            __out.Append("                }"); //406:1
            __out.AppendLine(); //406:18
            __out.Append("                if (string.IsNullOrEmpty(token.Text) || this.currentOffset >= this.currentLine.Length)"); //408:1
            __out.AppendLine(); //408:103
            __out.Append("                {"); //409:1
            __out.AppendLine(); //409:18
            __out.Append("                    return false;"); //410:1
            __out.AppendLine(); //410:34
            __out.Append("                }"); //411:1
            __out.AppendLine(); //411:18
            __out.Append("                tokenInfo.StartIndex = this.currentOffset;"); //412:1
            __out.AppendLine(); //412:59
            __out.Append("                this.currentOffset += token.Text.Length;"); //413:1
            __out.AppendLine(); //413:57
            __out.Append("                tokenInfo.EndIndex = this.currentOffset - 1;"); //414:1
            __out.AppendLine(); //414:61
            __out.Append("                state = this.SaveState(lexer);"); //415:1
            __out.AppendLine(); //415:47
            __out.Append("                return true;"); //416:1
            __out.AppendLine(); //416:29
            __out.Append("            }"); //417:1
            __out.AppendLine(); //417:14
            __out.Append("            catch (Exception)"); //418:1
            __out.AppendLine(); //418:30
            __out.Append("            {"); //419:1
            __out.AppendLine(); //419:14
            __out.Append("                return false;"); //420:1
            __out.AppendLine(); //420:30
            __out.Append("            }"); //421:1
            __out.AppendLine(); //421:14
            __out.Append("        }"); //422:1
            __out.AppendLine(); //422:10
            __out.Append("        public void SetSource(string source, int offset)"); //424:1
            __out.AppendLine(); //424:57
            __out.Append("        {"); //425:1
            __out.AppendLine(); //425:10
            __out.Append("            //if (this.currentOffset != offset || this.currentLine != source)"); //426:1
            __out.AppendLine(); //426:78
            __out.Append("            {"); //427:1
            __out.AppendLine(); //427:14
            __out.Append("                this.currentOffset = offset;"); //428:1
            __out.AppendLine(); //428:45
            __out.Append("                this.currentLine = source;"); //429:1
            __out.AppendLine(); //429:43
            __out.Append("                this.lexer = null;"); //430:1
            __out.AppendLine(); //430:35
            __out.Append("            }"); //431:1
            __out.AppendLine(); //431:14
            __out.Append("        }"); //432:1
            __out.AppendLine(); //432:10
            __out.Append("        internal void ScanLine(ref int state)"); //433:1
            __out.AppendLine(); //433:46
            __out.Append("        {"); //434:1
            __out.AppendLine(); //434:10
            __out.Append("            while (this.ScanTokenAndProvideInfoAboutIt(new TokenInfo(), ref state)) ;"); //435:1
            __out.AppendLine(); //435:86
            __out.Append("        }"); //436:1
            __out.AppendLine(); //436:10
            __out.Append("        internal struct LanguageScannerState"); //438:1
            __out.AppendLine(); //438:45
            __out.Append("        {"); //439:1
            __out.AppendLine(); //439:10
            string __tmp138Prefix = "            public LanguageScannerState("; //440:1
            string __tmp139Suffix = "Lexer lexer)"; //440:70
            StringBuilder __tmp140 = new StringBuilder();
            __tmp140.Append(Properties.LanguageFullName);
            using(StreamReader __tmp140Reader = new StreamReader(this.__ToStream(__tmp140.ToString())))
            {
                bool __tmp140_first = true;
                while(__tmp140_first || !__tmp140Reader.EndOfStream)
                {
                    __tmp140_first = false;
                    string __tmp140Line = __tmp140Reader.ReadLine();
                    if (__tmp140Line == null)
                    {
                        __tmp140Line = "";
                    }
                    __out.Append(__tmp138Prefix);
                    __out.Append(__tmp140Line);
                    __out.Append(__tmp139Suffix);
                    __out.AppendLine(); //440:82
                }
            }
            __out.Append("            {"); //441:1
            __out.AppendLine(); //441:14
            __out.Append("                this._mode = lexer.CurrentMode;"); //442:1
            __out.AppendLine(); //442:48
            __out.Append("                this._modeStack = lexer.ModeStack.Count > 0 ? new List<int>(lexer.ModeStack) : null;"); //443:1
            __out.AppendLine(); //443:101
            __out.Append("                this._type = lexer.Type;"); //444:1
            __out.AppendLine(); //444:41
            __out.Append("                this._channel = lexer.Channel;"); //445:1
            __out.AppendLine(); //445:47
            __out.Append("                this._state = lexer.State;"); //446:1
            __out.AppendLine(); //446:43
            __out.Append("            }"); //447:1
            __out.AppendLine(); //447:14
            __out.Append("            internal int _state;"); //449:1
            __out.AppendLine(); //449:33
            __out.Append("            internal int _mode;"); //450:1
            __out.AppendLine(); //450:32
            __out.Append("            internal List<int> _modeStack;"); //451:1
            __out.AppendLine(); //451:43
            __out.Append("            internal int _type;"); //452:1
            __out.AppendLine(); //452:32
            __out.Append("            internal int _channel;"); //453:1
            __out.AppendLine(); //453:35
            string __tmp141Prefix = "            public void Restore("; //455:1
            string __tmp142Suffix = "Lexer lexer)"; //455:62
            StringBuilder __tmp143 = new StringBuilder();
            __tmp143.Append(Properties.LanguageFullName);
            using(StreamReader __tmp143Reader = new StreamReader(this.__ToStream(__tmp143.ToString())))
            {
                bool __tmp143_first = true;
                while(__tmp143_first || !__tmp143Reader.EndOfStream)
                {
                    __tmp143_first = false;
                    string __tmp143Line = __tmp143Reader.ReadLine();
                    if (__tmp143Line == null)
                    {
                        __tmp143Line = "";
                    }
                    __out.Append(__tmp141Prefix);
                    __out.Append(__tmp143Line);
                    __out.Append(__tmp142Suffix);
                    __out.AppendLine(); //455:74
                }
            }
            __out.Append("            {"); //456:1
            __out.AppendLine(); //456:14
            __out.Append("                lexer.CurrentMode = this._mode;"); //457:1
            __out.AppendLine(); //457:48
            __out.Append("                lexer.ModeStack.Clear();"); //458:1
            __out.AppendLine(); //458:41
            __out.Append("                if (this._modeStack != null)"); //459:1
            __out.AppendLine(); //459:45
            __out.Append("                {"); //460:1
            __out.AppendLine(); //460:18
            __out.Append("                    foreach (var item in this._modeStack)"); //461:1
            __out.AppendLine(); //461:58
            __out.Append("                    {"); //462:1
            __out.AppendLine(); //462:22
            __out.Append("                        lexer.ModeStack.Push(item);"); //463:1
            __out.AppendLine(); //463:52
            __out.Append("                    }"); //464:1
            __out.AppendLine(); //464:22
            __out.Append("                }"); //465:1
            __out.AppendLine(); //465:18
            __out.Append("                lexer.Type = this._type;"); //466:1
            __out.AppendLine(); //466:41
            __out.Append("                lexer.Channel = this._channel;"); //467:1
            __out.AppendLine(); //467:47
            __out.Append("                lexer.State = this._state;"); //468:1
            __out.AppendLine(); //468:43
            __out.Append("            }"); //469:1
            __out.AppendLine(); //469:14
            __out.Append("            public override bool Equals(object obj)"); //471:1
            __out.AppendLine(); //471:52
            __out.Append("            {"); //472:1
            __out.AppendLine(); //472:14
            __out.Append("                LanguageScannerState rhs = (LanguageScannerState)obj;"); //473:1
            __out.AppendLine(); //473:70
            __out.Append("                if (rhs._mode != this._mode) return false;"); //474:1
            __out.AppendLine(); //474:59
            __out.Append("                if (rhs._type != this._type) return false;"); //475:1
            __out.AppendLine(); //475:59
            __out.Append("                if (rhs._state != this._state) return false;"); //476:1
            __out.AppendLine(); //476:61
            __out.Append("                if (rhs._channel != this._channel) return false;"); //477:1
            __out.AppendLine(); //477:65
            __out.Append("                if (rhs._modeStack == null && this._modeStack != null) return false;"); //478:1
            __out.AppendLine(); //478:85
            __out.Append("                if (rhs._modeStack != null && this._modeStack == null) return false;"); //479:1
            __out.AppendLine(); //479:85
            __out.Append("                if (rhs._modeStack != null && this._modeStack != null)"); //480:1
            __out.AppendLine(); //480:71
            __out.Append("                {"); //481:1
            __out.AppendLine(); //481:18
            __out.Append("                    if (rhs._modeStack.Count != this._modeStack.Count) return false;"); //482:1
            __out.AppendLine(); //482:85
            __out.Append("                    for (int i = 0; i < rhs._modeStack.Count; ++i)"); //483:1
            __out.AppendLine(); //483:67
            __out.Append("                    {"); //484:1
            __out.AppendLine(); //484:22
            string __tmp144Prefix = "                        if (rhs._modeStack"; //485:1
            string __tmp145Suffix = ") return false;"; //485:76
            StringBuilder __tmp146 = new StringBuilder();
            __tmp146.Append("[i]");
            using(StreamReader __tmp146Reader = new StreamReader(this.__ToStream(__tmp146.ToString())))
            {
                bool __tmp146_first = true;
                while(__tmp146_first || !__tmp146Reader.EndOfStream)
                {
                    __tmp146_first = false;
                    string __tmp146Line = __tmp146Reader.ReadLine();
                    if (__tmp146Line == null)
                    {
                        __tmp146Line = "";
                    }
                    __out.Append(__tmp144Prefix);
                    __out.Append(__tmp146Line);
                }
            }
            string __tmp147Line = " != this._modeStack"; //485:50
            __out.Append(__tmp147Line);
            StringBuilder __tmp148 = new StringBuilder();
            __tmp148.Append("[i]");
            using(StreamReader __tmp148Reader = new StreamReader(this.__ToStream(__tmp148.ToString())))
            {
                bool __tmp148_first = true;
                while(__tmp148_first || !__tmp148Reader.EndOfStream)
                {
                    __tmp148_first = false;
                    string __tmp148Line = __tmp148Reader.ReadLine();
                    if (__tmp148Line == null)
                    {
                        __tmp148Line = "";
                    }
                    __out.Append(__tmp148Line);
                    __out.Append(__tmp145Suffix);
                    __out.AppendLine(); //485:91
                }
            }
            __out.Append("                    }"); //486:1
            __out.AppendLine(); //486:22
            __out.Append("                }"); //487:1
            __out.AppendLine(); //487:18
            __out.Append("                return true;"); //488:1
            __out.AppendLine(); //488:29
            __out.Append("            }"); //489:1
            __out.AppendLine(); //489:14
            __out.Append("            public override int GetHashCode()"); //491:1
            __out.AppendLine(); //491:46
            __out.Append("            {"); //492:1
            __out.AppendLine(); //492:14
            __out.Append("                int result = 0;"); //493:1
            __out.AppendLine(); //493:32
            __out.Append("                result "); //494:1
            __out.Append("^"); //494:24
            __out.Append("= this._mode.GetHashCode();"); //494:25
            __out.AppendLine(); //494:52
            __out.Append("                result "); //495:1
            __out.Append("^"); //495:24
            __out.Append("= this._type.GetHashCode();"); //495:25
            __out.AppendLine(); //495:52
            __out.Append("                result "); //496:1
            __out.Append("^"); //496:24
            __out.Append("= this._state.GetHashCode();"); //496:25
            __out.AppendLine(); //496:53
            __out.Append("                result "); //497:1
            __out.Append("^"); //497:24
            __out.Append("= this._channel.GetHashCode();"); //497:25
            __out.AppendLine(); //497:55
            __out.Append("                if (this._modeStack != null)"); //498:1
            __out.AppendLine(); //498:45
            __out.Append("                {"); //499:1
            __out.AppendLine(); //499:18
            __out.Append("                    result "); //500:1
            __out.Append("^"); //500:28
            __out.Append("= this._modeStack.GetHashCode();"); //500:29
            __out.AppendLine(); //500:61
            __out.Append("                }"); //501:1
            __out.AppendLine(); //501:18
            __out.Append("                return result;"); //502:1
            __out.AppendLine(); //502:31
            __out.Append("            }"); //503:1
            __out.AppendLine(); //503:14
            __out.Append("        }"); //504:1
            __out.AppendLine(); //504:10
            __out.Append("    }"); //505:1
            __out.AppendLine(); //505:6
            string __tmp149Prefix = "    "; //507:1
            string __tmp150Suffix = string.Empty; 
            StringBuilder __tmp151 = new StringBuilder();
            __tmp151.Append("[ComVisible(true)]");
            using(StreamReader __tmp151Reader = new StreamReader(this.__ToStream(__tmp151.ToString())))
            {
                bool __tmp151_first = true;
                while(__tmp151_first || !__tmp151Reader.EndOfStream)
                {
                    __tmp151_first = false;
                    string __tmp151Line = __tmp151Reader.ReadLine();
                    if (__tmp151Line == null)
                    {
                        __tmp151Line = "";
                    }
                    __out.Append(__tmp149Prefix);
                    __out.Append(__tmp151Line);
                    __out.Append(__tmp150Suffix);
                    __out.AppendLine(); //507:27
                }
            }
            string __tmp152Prefix = "    "; //508:1
            string __tmp153Suffix = string.Empty; 
            StringBuilder __tmp154 = new StringBuilder();
            __tmp154.Append("[Guid(" + Properties.LanguageClassName + "LanguageConfig." + Properties.LanguageClassName + "LanguageServiceGuid)]");
            using(StreamReader __tmp154Reader = new StreamReader(this.__ToStream(__tmp154.ToString())))
            {
                bool __tmp154_first = true;
                while(__tmp154_first || !__tmp154Reader.EndOfStream)
                {
                    __tmp154_first = false;
                    string __tmp154Line = __tmp154Reader.ReadLine();
                    if (__tmp154Line == null)
                    {
                        __tmp154Line = "";
                    }
                    __out.Append(__tmp152Prefix);
                    __out.Append(__tmp154Line);
                    __out.Append(__tmp153Suffix);
                    __out.AppendLine(); //508:115
                }
            }
            string __tmp155Prefix = "    public class "; //509:1
            string __tmp156Suffix = "LanguageService : LanguageService"; //509:48
            StringBuilder __tmp157 = new StringBuilder();
            __tmp157.Append(Properties.LanguageClassName);
            using(StreamReader __tmp157Reader = new StreamReader(this.__ToStream(__tmp157.ToString())))
            {
                bool __tmp157_first = true;
                while(__tmp157_first || !__tmp157Reader.EndOfStream)
                {
                    __tmp157_first = false;
                    string __tmp157Line = __tmp157Reader.ReadLine();
                    if (__tmp157Line == null)
                    {
                        __tmp157Line = "";
                    }
                    __out.Append(__tmp155Prefix);
                    __out.Append(__tmp157Line);
                    __out.Append(__tmp156Suffix);
                    __out.AppendLine(); //509:81
                }
            }
            __out.Append("    {"); //510:1
            __out.AppendLine(); //510:6
            __out.Append("        private LanguagePreferences preferences;"); //511:1
            __out.AppendLine(); //511:49
            string __tmp158Prefix = "        private "; //512:1
            string __tmp159Suffix = "LanguageScanner scanner;"; //512:47
            StringBuilder __tmp160 = new StringBuilder();
            __tmp160.Append(Properties.LanguageClassName);
            using(StreamReader __tmp160Reader = new StreamReader(this.__ToStream(__tmp160.ToString())))
            {
                bool __tmp160_first = true;
                while(__tmp160_first || !__tmp160Reader.EndOfStream)
                {
                    __tmp160_first = false;
                    string __tmp160Line = __tmp160Reader.ReadLine();
                    if (__tmp160Line == null)
                    {
                        __tmp160Line = "";
                    }
                    __out.Append(__tmp158Prefix);
                    __out.Append(__tmp160Line);
                    __out.Append(__tmp159Suffix);
                    __out.AppendLine(); //512:71
                }
            }
            string __tmp161Prefix = "        public "; //514:1
            string __tmp162Suffix = "LanguageService()"; //514:46
            StringBuilder __tmp163 = new StringBuilder();
            __tmp163.Append(Properties.LanguageClassName);
            using(StreamReader __tmp163Reader = new StreamReader(this.__ToStream(__tmp163.ToString())))
            {
                bool __tmp163_first = true;
                while(__tmp163_first || !__tmp163Reader.EndOfStream)
                {
                    __tmp163_first = false;
                    string __tmp163Line = __tmp163Reader.ReadLine();
                    if (__tmp163Line == null)
                    {
                        __tmp163Line = "";
                    }
                    __out.Append(__tmp161Prefix);
                    __out.Append(__tmp163Line);
                    __out.Append(__tmp162Suffix);
                    __out.AppendLine(); //514:63
                }
            }
            __out.Append("        {"); //515:1
            __out.AppendLine(); //515:10
            __out.Append("			// Creating the config instance"); //516:1
            __out.AppendLine(); //516:35
            string __tmp164Prefix = "			"; //517:1
            string __tmp165Suffix = "LanguageConfigBase.Instance.ToString();"; //517:34
            StringBuilder __tmp166 = new StringBuilder();
            __tmp166.Append(Properties.LanguageClassName);
            using(StreamReader __tmp166Reader = new StreamReader(this.__ToStream(__tmp166.ToString())))
            {
                bool __tmp166_first = true;
                while(__tmp166_first || !__tmp166Reader.EndOfStream)
                {
                    __tmp166_first = false;
                    string __tmp166Line = __tmp166Reader.ReadLine();
                    if (__tmp166Line == null)
                    {
                        __tmp166Line = "";
                    }
                    __out.Append(__tmp164Prefix);
                    __out.Append(__tmp166Line);
                    __out.Append(__tmp165Suffix);
                    __out.AppendLine(); //517:73
                }
            }
            __out.Append("        }"); //518:1
            __out.AppendLine(); //518:10
            __out.Append("        public override string GetFormatFilterList()"); //520:1
            __out.AppendLine(); //520:53
            __out.Append("        {"); //521:1
            __out.AppendLine(); //521:10
            string __tmp167Prefix = "            return "; //522:1
            string __tmp168Suffix = "LanguageConfig.FilterList;"; //522:50
            StringBuilder __tmp169 = new StringBuilder();
            __tmp169.Append(Properties.LanguageClassName);
            using(StreamReader __tmp169Reader = new StreamReader(this.__ToStream(__tmp169.ToString())))
            {
                bool __tmp169_first = true;
                while(__tmp169_first || !__tmp169Reader.EndOfStream)
                {
                    __tmp169_first = false;
                    string __tmp169Line = __tmp169Reader.ReadLine();
                    if (__tmp169Line == null)
                    {
                        __tmp169Line = "";
                    }
                    __out.Append(__tmp167Prefix);
                    __out.Append(__tmp169Line);
                    __out.Append(__tmp168Suffix);
                    __out.AppendLine(); //522:76
                }
            }
            __out.Append("        }"); //523:1
            __out.AppendLine(); //523:10
            __out.Append("        public override LanguagePreferences GetLanguagePreferences()"); //525:1
            __out.AppendLine(); //525:69
            __out.Append("        {"); //526:1
            __out.AppendLine(); //526:10
            __out.Append("            if (preferences == null)"); //527:1
            __out.AppendLine(); //527:37
            __out.Append("            {"); //528:1
            __out.AppendLine(); //528:14
            string __tmp170Prefix = "                preferences = new LanguagePreferences(this.Site, typeof("; //529:1
            string __tmp171Suffix = "LanguageService).GUID, this.Name);"; //529:103
            StringBuilder __tmp172 = new StringBuilder();
            __tmp172.Append(Properties.LanguageClassName);
            using(StreamReader __tmp172Reader = new StreamReader(this.__ToStream(__tmp172.ToString())))
            {
                bool __tmp172_first = true;
                while(__tmp172_first || !__tmp172Reader.EndOfStream)
                {
                    __tmp172_first = false;
                    string __tmp172Line = __tmp172Reader.ReadLine();
                    if (__tmp172Line == null)
                    {
                        __tmp172Line = "";
                    }
                    __out.Append(__tmp170Prefix);
                    __out.Append(__tmp172Line);
                    __out.Append(__tmp171Suffix);
                    __out.AppendLine(); //529:137
                }
            }
            __out.Append("                preferences.Init();"); //530:1
            __out.AppendLine(); //530:36
            __out.Append("            }"); //531:1
            __out.AppendLine(); //531:14
            __out.Append("            return preferences;"); //532:1
            __out.AppendLine(); //532:32
            __out.Append("        }"); //533:1
            __out.AppendLine(); //533:10
            __out.Append("        public override IScanner GetScanner(IVsTextLines buffer)"); //535:1
            __out.AppendLine(); //535:65
            __out.Append("        {"); //536:1
            __out.AppendLine(); //536:10
            __out.Append("            if (scanner == null)"); //537:1
            __out.AppendLine(); //537:33
            __out.Append("            {"); //538:1
            __out.AppendLine(); //538:14
            string __tmp173Prefix = "                scanner = new "; //539:1
            string __tmp174Suffix = "LanguageScanner();"; //539:61
            StringBuilder __tmp175 = new StringBuilder();
            __tmp175.Append(Properties.LanguageClassName);
            using(StreamReader __tmp175Reader = new StreamReader(this.__ToStream(__tmp175.ToString())))
            {
                bool __tmp175_first = true;
                while(__tmp175_first || !__tmp175Reader.EndOfStream)
                {
                    __tmp175_first = false;
                    string __tmp175Line = __tmp175Reader.ReadLine();
                    if (__tmp175Line == null)
                    {
                        __tmp175Line = "";
                    }
                    __out.Append(__tmp173Prefix);
                    __out.Append(__tmp175Line);
                    __out.Append(__tmp174Suffix);
                    __out.AppendLine(); //539:79
                }
            }
            __out.Append("            }"); //540:1
            __out.AppendLine(); //540:14
            __out.Append("            return scanner;"); //541:1
            __out.AppendLine(); //541:28
            __out.Append("        }"); //542:1
            __out.AppendLine(); //542:10
            __out.Append("        public override Microsoft.VisualStudio.Package.Source CreateSource(IVsTextLines buffer)"); //544:1
            __out.AppendLine(); //544:96
            __out.Append("        {"); //545:1
            __out.AppendLine(); //545:10
            string __tmp176Prefix = "            return new "; //546:1
            string __tmp177Suffix = "LanguageSource(this, buffer, this.GetColorizer(buffer));"; //546:54
            StringBuilder __tmp178 = new StringBuilder();
            __tmp178.Append(Properties.LanguageClassName);
            using(StreamReader __tmp178Reader = new StreamReader(this.__ToStream(__tmp178.ToString())))
            {
                bool __tmp178_first = true;
                while(__tmp178_first || !__tmp178Reader.EndOfStream)
                {
                    __tmp178_first = false;
                    string __tmp178Line = __tmp178Reader.ReadLine();
                    if (__tmp178Line == null)
                    {
                        __tmp178Line = "";
                    }
                    __out.Append(__tmp176Prefix);
                    __out.Append(__tmp178Line);
                    __out.Append(__tmp177Suffix);
                    __out.AppendLine(); //546:110
                }
            }
            __out.Append("        }"); //547:1
            __out.AppendLine(); //547:10
            __out.Append("        #region Custom Colors"); //549:1
            __out.AppendLine(); //549:30
            __out.Append("        public override int GetColorableItem(int index, out IVsColorableItem item)"); //550:1
            __out.AppendLine(); //550:83
            __out.Append("        {"); //551:1
            __out.AppendLine(); //551:10
            string __tmp179Prefix = "            if (index >= 1 && index <= "; //552:1
            string __tmp180Suffix = "LanguageConfig.Instance.ColorableItems.Count)"; //552:70
            StringBuilder __tmp181 = new StringBuilder();
            __tmp181.Append(Properties.LanguageClassName);
            using(StreamReader __tmp181Reader = new StreamReader(this.__ToStream(__tmp181.ToString())))
            {
                bool __tmp181_first = true;
                while(__tmp181_first || !__tmp181Reader.EndOfStream)
                {
                    __tmp181_first = false;
                    string __tmp181Line = __tmp181Reader.ReadLine();
                    if (__tmp181Line == null)
                    {
                        __tmp181Line = "";
                    }
                    __out.Append(__tmp179Prefix);
                    __out.Append(__tmp181Line);
                    __out.Append(__tmp180Suffix);
                    __out.AppendLine(); //552:115
                }
            }
            __out.Append("            {"); //553:1
            __out.AppendLine(); //553:14
            string __tmp182Prefix = "                item = "; //554:1
            string __tmp183Suffix = ";"; //554:107
            StringBuilder __tmp184 = new StringBuilder();
            __tmp184.Append(Properties.LanguageClassName);
            using(StreamReader __tmp184Reader = new StreamReader(this.__ToStream(__tmp184.ToString())))
            {
                bool __tmp184_first = true;
                while(__tmp184_first || !__tmp184Reader.EndOfStream)
                {
                    __tmp184_first = false;
                    string __tmp184Line = __tmp184Reader.ReadLine();
                    if (__tmp184Line == null)
                    {
                        __tmp184Line = "";
                    }
                    __out.Append(__tmp182Prefix);
                    __out.Append(__tmp184Line);
                }
            }
            string __tmp185Line = "LanguageConfig.Instance.ColorableItems"; //554:54
            __out.Append(__tmp185Line);
            StringBuilder __tmp186 = new StringBuilder();
            __tmp186.Append("[index - 1]");
            using(StreamReader __tmp186Reader = new StreamReader(this.__ToStream(__tmp186.ToString())))
            {
                bool __tmp186_first = true;
                while(__tmp186_first || !__tmp186Reader.EndOfStream)
                {
                    __tmp186_first = false;
                    string __tmp186Line = __tmp186Reader.ReadLine();
                    if (__tmp186Line == null)
                    {
                        __tmp186Line = "";
                    }
                    __out.Append(__tmp186Line);
                    __out.Append(__tmp183Suffix);
                    __out.AppendLine(); //554:108
                }
            }
            __out.Append("                return Microsoft.VisualStudio.VSConstants.S_OK;"); //555:1
            __out.AppendLine(); //555:64
            __out.Append("            }"); //556:1
            __out.AppendLine(); //556:14
            __out.Append("            else"); //557:1
            __out.AppendLine(); //557:17
            __out.Append("            {"); //558:1
            __out.AppendLine(); //558:14
            string __tmp187Prefix = "                item = "; //559:1
            string __tmp188Suffix = ";"; //559:99
            StringBuilder __tmp189 = new StringBuilder();
            __tmp189.Append(Properties.LanguageClassName);
            using(StreamReader __tmp189Reader = new StreamReader(this.__ToStream(__tmp189.ToString())))
            {
                bool __tmp189_first = true;
                while(__tmp189_first || !__tmp189Reader.EndOfStream)
                {
                    __tmp189_first = false;
                    string __tmp189Line = __tmp189Reader.ReadLine();
                    if (__tmp189Line == null)
                    {
                        __tmp189Line = "";
                    }
                    __out.Append(__tmp187Prefix);
                    __out.Append(__tmp189Line);
                }
            }
            string __tmp190Line = "LanguageConfig.Instance.ColorableItems"; //559:54
            __out.Append(__tmp190Line);
            StringBuilder __tmp191 = new StringBuilder();
            __tmp191.Append("[0]");
            using(StreamReader __tmp191Reader = new StreamReader(this.__ToStream(__tmp191.ToString())))
            {
                bool __tmp191_first = true;
                while(__tmp191_first || !__tmp191Reader.EndOfStream)
                {
                    __tmp191_first = false;
                    string __tmp191Line = __tmp191Reader.ReadLine();
                    if (__tmp191Line == null)
                    {
                        __tmp191Line = "";
                    }
                    __out.Append(__tmp191Line);
                    __out.Append(__tmp188Suffix);
                    __out.AppendLine(); //559:100
                }
            }
            __out.Append("                return Microsoft.VisualStudio.VSConstants.S_OK;"); //560:1
            __out.AppendLine(); //560:64
            __out.Append("            }"); //561:1
            __out.AppendLine(); //561:14
            __out.Append("        }"); //562:1
            __out.AppendLine(); //562:10
            __out.Append("        public override int GetItemCount(out int count)"); //564:1
            __out.AppendLine(); //564:56
            __out.Append("        {"); //565:1
            __out.AppendLine(); //565:10
            string __tmp192Prefix = "            count = "; //566:1
            string __tmp193Suffix = "LanguageConfig.Instance.ColorableItems.Count;"; //566:51
            StringBuilder __tmp194 = new StringBuilder();
            __tmp194.Append(Properties.LanguageClassName);
            using(StreamReader __tmp194Reader = new StreamReader(this.__ToStream(__tmp194.ToString())))
            {
                bool __tmp194_first = true;
                while(__tmp194_first || !__tmp194Reader.EndOfStream)
                {
                    __tmp194_first = false;
                    string __tmp194Line = __tmp194Reader.ReadLine();
                    if (__tmp194Line == null)
                    {
                        __tmp194Line = "";
                    }
                    __out.Append(__tmp192Prefix);
                    __out.Append(__tmp194Line);
                    __out.Append(__tmp193Suffix);
                    __out.AppendLine(); //566:96
                }
            }
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //567:1
            __out.AppendLine(); //567:60
            __out.Append("        }"); //568:1
            __out.AppendLine(); //568:10
            __out.Append("        #endregion"); //569:1
            __out.AppendLine(); //569:19
            __out.Append("        public override void OnIdle(bool periodic)"); //571:1
            __out.AppendLine(); //571:51
            __out.Append("        {"); //572:1
            __out.AppendLine(); //572:10
            __out.Append("            // from IronPythonLanguage sample"); //573:1
            __out.AppendLine(); //573:46
            __out.Append("            // this appears to be necessary to get a parse request with ParseReason = Check?"); //574:1
            __out.AppendLine(); //574:93
            string __tmp195Prefix = "            "; //575:1
            string __tmp196Suffix = "LanguageSource)GetSource(this.LastActiveTextView);"; //575:95
            StringBuilder __tmp197 = new StringBuilder();
            __tmp197.Append(Properties.LanguageClassName);
            using(StreamReader __tmp197Reader = new StreamReader(this.__ToStream(__tmp197.ToString())))
            {
                bool __tmp197_first = true;
                while(__tmp197_first || !__tmp197Reader.EndOfStream)
                {
                    __tmp197_first = false;
                    string __tmp197Line = __tmp197Reader.ReadLine();
                    if (__tmp197Line == null)
                    {
                        __tmp197Line = "";
                    }
                    __out.Append(__tmp195Prefix);
                    __out.Append(__tmp197Line);
                }
            }
            string __tmp198Line = "LanguageSource src = ("; //575:43
            __out.Append(__tmp198Line);
            StringBuilder __tmp199 = new StringBuilder();
            __tmp199.Append(Properties.LanguageClassName);
            using(StreamReader __tmp199Reader = new StreamReader(this.__ToStream(__tmp199.ToString())))
            {
                bool __tmp199_first = true;
                while(__tmp199_first || !__tmp199Reader.EndOfStream)
                {
                    __tmp199_first = false;
                    string __tmp199Line = __tmp199Reader.ReadLine();
                    if (__tmp199Line == null)
                    {
                        __tmp199Line = "";
                    }
                    __out.Append(__tmp199Line);
                    __out.Append(__tmp196Suffix);
                    __out.AppendLine(); //575:145
                }
            }
            __out.Append("            if (src != null && src.LastParseTime >= Int32.MaxValue >> 12)"); //576:1
            __out.AppendLine(); //576:74
            __out.Append("            {"); //577:1
            __out.AppendLine(); //577:14
            __out.Append("                src.LastParseTime = 0;"); //578:1
            __out.AppendLine(); //578:39
            __out.Append("            }"); //579:1
            __out.AppendLine(); //579:14
            __out.Append("            base.OnIdle(periodic);"); //580:1
            __out.AppendLine(); //580:35
            __out.Append("        }"); //581:1
            __out.AppendLine(); //581:10
            __out.Append("        public override string Name"); //583:1
            __out.AppendLine(); //583:36
            __out.Append("        {"); //584:1
            __out.AppendLine(); //584:10
            string __tmp200Prefix = "            get { return "; //585:1
            string __tmp201Suffix = "LanguageConfig.LanguageName; }"; //585:56
            StringBuilder __tmp202 = new StringBuilder();
            __tmp202.Append(Properties.LanguageClassName);
            using(StreamReader __tmp202Reader = new StreamReader(this.__ToStream(__tmp202.ToString())))
            {
                bool __tmp202_first = true;
                while(__tmp202_first || !__tmp202Reader.EndOfStream)
                {
                    __tmp202_first = false;
                    string __tmp202Line = __tmp202Reader.ReadLine();
                    if (__tmp202Line == null)
                    {
                        __tmp202Line = "";
                    }
                    __out.Append(__tmp200Prefix);
                    __out.Append(__tmp202Line);
                    __out.Append(__tmp201Suffix);
                    __out.AppendLine(); //585:86
                }
            }
            __out.Append("        }"); //586:1
            __out.AppendLine(); //586:10
            __out.Append("        public override ViewFilter CreateViewFilter(CodeWindowManager mgr, IVsTextView newView)"); //588:1
            __out.AppendLine(); //588:96
            __out.Append("        {"); //589:1
            __out.AppendLine(); //589:10
            string __tmp203Prefix = "            return new "; //590:1
            string __tmp204Suffix = "LanguageViewFilter(mgr, newView);"; //590:54
            StringBuilder __tmp205 = new StringBuilder();
            __tmp205.Append(Properties.LanguageClassName);
            using(StreamReader __tmp205Reader = new StreamReader(this.__ToStream(__tmp205.ToString())))
            {
                bool __tmp205_first = true;
                while(__tmp205_first || !__tmp205Reader.EndOfStream)
                {
                    __tmp205_first = false;
                    string __tmp205Line = __tmp205Reader.ReadLine();
                    if (__tmp205Line == null)
                    {
                        __tmp205Line = "";
                    }
                    __out.Append(__tmp203Prefix);
                    __out.Append(__tmp205Line);
                    __out.Append(__tmp204Suffix);
                    __out.AppendLine(); //590:87
                }
            }
            __out.Append("        }"); //591:1
            __out.AppendLine(); //591:10
            __out.Append("        public override Colorizer GetColorizer(IVsTextLines buffer)"); //593:1
            __out.AppendLine(); //593:68
            __out.Append("        {"); //594:1
            __out.AppendLine(); //594:10
            string __tmp206Prefix = "            return new "; //595:1
            string __tmp207Suffix = "LanguageColorizer(this, buffer, this.GetScanner(buffer));"; //595:54
            StringBuilder __tmp208 = new StringBuilder();
            __tmp208.Append(Properties.LanguageClassName);
            using(StreamReader __tmp208Reader = new StreamReader(this.__ToStream(__tmp208.ToString())))
            {
                bool __tmp208_first = true;
                while(__tmp208_first || !__tmp208Reader.EndOfStream)
                {
                    __tmp208_first = false;
                    string __tmp208Line = __tmp208Reader.ReadLine();
                    if (__tmp208Line == null)
                    {
                        __tmp208Line = "";
                    }
                    __out.Append(__tmp206Prefix);
                    __out.Append(__tmp208Line);
                    __out.Append(__tmp207Suffix);
                    __out.AppendLine(); //595:111
                }
            }
            __out.Append("        }"); //596:1
            __out.AppendLine(); //596:10
            __out.Append("        public override AuthoringScope ParseSource(ParseRequest req)"); //598:1
            __out.AppendLine(); //598:69
            __out.Append("        {"); //599:1
            __out.AppendLine(); //599:10
            string __tmp209Prefix = "            "; //600:1
            string __tmp210Suffix = "LanguageSource)this.GetSource(req.FileName);"; //600:98
            StringBuilder __tmp211 = new StringBuilder();
            __tmp211.Append(Properties.LanguageClassName);
            using(StreamReader __tmp211Reader = new StreamReader(this.__ToStream(__tmp211.ToString())))
            {
                bool __tmp211_first = true;
                while(__tmp211_first || !__tmp211Reader.EndOfStream)
                {
                    __tmp211_first = false;
                    string __tmp211Line = __tmp211Reader.ReadLine();
                    if (__tmp211Line == null)
                    {
                        __tmp211Line = "";
                    }
                    __out.Append(__tmp209Prefix);
                    __out.Append(__tmp211Line);
                }
            }
            string __tmp212Line = "LanguageSource source = ("; //600:43
            __out.Append(__tmp212Line);
            StringBuilder __tmp213 = new StringBuilder();
            __tmp213.Append(Properties.LanguageClassName);
            using(StreamReader __tmp213Reader = new StreamReader(this.__ToStream(__tmp213.ToString())))
            {
                bool __tmp213_first = true;
                while(__tmp213_first || !__tmp213Reader.EndOfStream)
                {
                    __tmp213_first = false;
                    string __tmp213Line = __tmp213Reader.ReadLine();
                    if (__tmp213Line == null)
                    {
                        __tmp213Line = "";
                    }
                    __out.Append(__tmp213Line);
                    __out.Append(__tmp210Suffix);
                    __out.AppendLine(); //600:142
                }
            }
            __out.Append("            switch (req.Reason)"); //601:1
            __out.AppendLine(); //601:32
            __out.Append("            {"); //602:1
            __out.AppendLine(); //602:14
            __out.Append("                case ParseReason.Check:"); //603:1
            __out.AppendLine(); //603:40
            __out.Append("                    // This is where you perform your syntax highlighting."); //604:1
            __out.AppendLine(); //604:75
            __out.Append("                    // Parse entire source as given in req.Text."); //605:1
            __out.AppendLine(); //605:65
            __out.Append("                    // Store results in the AuthoringScope object."); //606:1
            __out.AppendLine(); //606:67
            string __tmp214Prefix = "                    "; //607:1
            string __tmp215Suffix = "Compiler(req.Text);"; //607:105
            StringBuilder __tmp216 = new StringBuilder();
            __tmp216.Append(Properties.LanguageClassName);
            using(StreamReader __tmp216Reader = new StreamReader(this.__ToStream(__tmp216.ToString())))
            {
                bool __tmp216_first = true;
                while(__tmp216_first || !__tmp216Reader.EndOfStream)
                {
                    __tmp216_first = false;
                    string __tmp216Line = __tmp216Reader.ReadLine();
                    if (__tmp216Line == null)
                    {
                        __tmp216Line = "";
                    }
                    __out.Append(__tmp214Prefix);
                    __out.Append(__tmp216Line);
                }
            }
            string __tmp217Line = "Compiler compiler = new "; //607:51
            __out.Append(__tmp217Line);
            StringBuilder __tmp218 = new StringBuilder();
            __tmp218.Append(Properties.LanguageClassName);
            using(StreamReader __tmp218Reader = new StreamReader(this.__ToStream(__tmp218.ToString())))
            {
                bool __tmp218_first = true;
                while(__tmp218_first || !__tmp218Reader.EndOfStream)
                {
                    __tmp218_first = false;
                    string __tmp218Line = __tmp218Reader.ReadLine();
                    if (__tmp218Line == null)
                    {
                        __tmp218Line = "";
                    }
                    __out.Append(__tmp218Line);
                    __out.Append(__tmp215Suffix);
                    __out.AppendLine(); //607:124
                }
            }
            __out.Append("                    compiler.Compile();"); //608:1
            __out.AppendLine(); //608:40
            __out.Append("                    foreach (var msg in compiler.Diagnostics.GetMessages())"); //609:1
            __out.AppendLine(); //609:76
            __out.Append("                    {"); //610:1
            __out.AppendLine(); //610:22
            __out.Append("                        TextSpan span = new TextSpan();"); //611:1
            __out.AppendLine(); //611:56
            __out.Append("                        span.iStartLine = msg.TextSpan.StartLine - 1;"); //612:1
            __out.AppendLine(); //612:70
            __out.Append("                        span.iEndLine = msg.TextSpan.EndLine - 1;"); //613:1
            __out.AppendLine(); //613:66
            __out.Append("                        span.iStartIndex = msg.TextSpan.StartPosition - 1;"); //614:1
            __out.AppendLine(); //614:75
            __out.Append("                        span.iEndIndex = msg.TextSpan.EndPosition - 1;"); //615:1
            __out.AppendLine(); //615:71
            __out.Append("                        Severity severity = Severity.Error;"); //616:1
            __out.AppendLine(); //616:60
            __out.Append("                        switch (msg.Severity)"); //617:1
            __out.AppendLine(); //617:46
            __out.Append("                        {"); //618:1
            __out.AppendLine(); //618:26
            __out.Append("                            case MetaDslx.Core.Severity.Error:"); //619:1
            __out.AppendLine(); //619:63
            __out.Append("                                severity = Severity.Error;"); //620:1
            __out.AppendLine(); //620:59
            __out.Append("                                break;"); //621:1
            __out.AppendLine(); //621:39
            __out.Append("                            case MetaDslx.Core.Severity.Warning:"); //622:1
            __out.AppendLine(); //622:65
            __out.Append("                                severity = Severity.Warning;"); //623:1
            __out.AppendLine(); //623:61
            __out.Append("                                break;"); //624:1
            __out.AppendLine(); //624:39
            __out.Append("                            case MetaDslx.Core.Severity.Info:"); //625:1
            __out.AppendLine(); //625:62
            __out.Append("                                severity = Severity.Hint;"); //626:1
            __out.AppendLine(); //626:58
            __out.Append("                                break;"); //627:1
            __out.AppendLine(); //627:39
            __out.Append("                        }"); //628:1
            __out.AppendLine(); //628:26
            __out.Append("                        req.Sink.AddError(req.FileName, msg.Message, span, severity);"); //629:1
            __out.AppendLine(); //629:86
            __out.Append("                    }"); //630:1
            __out.AppendLine(); //630:22
            __out.Append("                    break;"); //631:1
            __out.AppendLine(); //631:27
            __out.Append("            }"); //632:1
            __out.AppendLine(); //632:14
            string __tmp219Prefix = "            return new "; //633:1
            string __tmp220Suffix = "LanguageAuthoringScope();"; //633:54
            StringBuilder __tmp221 = new StringBuilder();
            __tmp221.Append(Properties.LanguageClassName);
            using(StreamReader __tmp221Reader = new StreamReader(this.__ToStream(__tmp221.ToString())))
            {
                bool __tmp221_first = true;
                while(__tmp221_first || !__tmp221Reader.EndOfStream)
                {
                    __tmp221_first = false;
                    string __tmp221Line = __tmp221Reader.ReadLine();
                    if (__tmp221Line == null)
                    {
                        __tmp221Line = "";
                    }
                    __out.Append(__tmp219Prefix);
                    __out.Append(__tmp221Line);
                    __out.Append(__tmp220Suffix);
                    __out.AppendLine(); //633:79
                }
            }
            __out.Append("        }"); //634:1
            __out.AppendLine(); //634:10
            __out.Append("    }"); //635:1
            __out.AppendLine(); //635:6
            string __tmp222Prefix = "	public class "; //637:1
            string __tmp223Suffix = "LanguageSource : Microsoft.VisualStudio.Package.Source"; //637:45
            StringBuilder __tmp224 = new StringBuilder();
            __tmp224.Append(Properties.LanguageClassName);
            using(StreamReader __tmp224Reader = new StreamReader(this.__ToStream(__tmp224.ToString())))
            {
                bool __tmp224_first = true;
                while(__tmp224_first || !__tmp224Reader.EndOfStream)
                {
                    __tmp224_first = false;
                    string __tmp224Line = __tmp224Reader.ReadLine();
                    if (__tmp224Line == null)
                    {
                        __tmp224Line = "";
                    }
                    __out.Append(__tmp222Prefix);
                    __out.Append(__tmp224Line);
                    __out.Append(__tmp223Suffix);
                    __out.AppendLine(); //637:99
                }
            }
            __out.Append("    {"); //638:1
            __out.AppendLine(); //638:6
            string __tmp225Prefix = "        public "; //639:1
            string __tmp226Suffix = "LanguageSource(LanguageService service, IVsTextLines textLines, Colorizer colorizer)"; //639:46
            StringBuilder __tmp227 = new StringBuilder();
            __tmp227.Append(Properties.LanguageClassName);
            using(StreamReader __tmp227Reader = new StreamReader(this.__ToStream(__tmp227.ToString())))
            {
                bool __tmp227_first = true;
                while(__tmp227_first || !__tmp227Reader.EndOfStream)
                {
                    __tmp227_first = false;
                    string __tmp227Line = __tmp227Reader.ReadLine();
                    if (__tmp227Line == null)
                    {
                        __tmp227Line = "";
                    }
                    __out.Append(__tmp225Prefix);
                    __out.Append(__tmp227Line);
                    __out.Append(__tmp226Suffix);
                    __out.AppendLine(); //639:130
                }
            }
            __out.Append("            : base(service, textLines, colorizer)"); //640:1
            __out.AppendLine(); //640:50
            __out.Append("        {"); //641:1
            __out.AppendLine(); //641:10
            __out.Append("        }"); //643:1
            __out.AppendLine(); //643:10
            __out.Append("    }"); //644:1
            __out.AppendLine(); //644:6
            string __tmp228Prefix = "    public class "; //646:1
            string __tmp229Suffix = "LanguageViewFilter : ViewFilter"; //646:48
            StringBuilder __tmp230 = new StringBuilder();
            __tmp230.Append(Properties.LanguageClassName);
            using(StreamReader __tmp230Reader = new StreamReader(this.__ToStream(__tmp230.ToString())))
            {
                bool __tmp230_first = true;
                while(__tmp230_first || !__tmp230Reader.EndOfStream)
                {
                    __tmp230_first = false;
                    string __tmp230Line = __tmp230Reader.ReadLine();
                    if (__tmp230Line == null)
                    {
                        __tmp230Line = "";
                    }
                    __out.Append(__tmp228Prefix);
                    __out.Append(__tmp230Line);
                    __out.Append(__tmp229Suffix);
                    __out.AppendLine(); //646:79
                }
            }
            __out.Append("    {"); //647:1
            __out.AppendLine(); //647:6
            string __tmp231Prefix = "        public "; //648:1
            string __tmp232Suffix = "LanguageViewFilter(CodeWindowManager mgr, IVsTextView view)"; //648:46
            StringBuilder __tmp233 = new StringBuilder();
            __tmp233.Append(Properties.LanguageClassName);
            using(StreamReader __tmp233Reader = new StreamReader(this.__ToStream(__tmp233.ToString())))
            {
                bool __tmp233_first = true;
                while(__tmp233_first || !__tmp233Reader.EndOfStream)
                {
                    __tmp233_first = false;
                    string __tmp233Line = __tmp233Reader.ReadLine();
                    if (__tmp233Line == null)
                    {
                        __tmp233Line = "";
                    }
                    __out.Append(__tmp231Prefix);
                    __out.Append(__tmp233Line);
                    __out.Append(__tmp232Suffix);
                    __out.AppendLine(); //648:105
                }
            }
            __out.Append("            : base(mgr, view)"); //649:1
            __out.AppendLine(); //649:30
            __out.Append("        {"); //650:1
            __out.AppendLine(); //650:10
            __out.Append("        }"); //652:1
            __out.AppendLine(); //652:10
            __out.Append("        public override void HandlePostExec(ref Guid guidCmdGroup, uint nCmdId, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut, bool bufferWasChanged)"); //654:1
            __out.AppendLine(); //654:150
            __out.Append("        {"); //655:1
            __out.AppendLine(); //655:10
            __out.Append("            if (guidCmdGroup == typeof(VsCommands2K).GUID)"); //656:1
            __out.AppendLine(); //656:59
            __out.Append("            {"); //657:1
            __out.AppendLine(); //657:14
            __out.Append("                VsCommands2K cmd = (VsCommands2K)nCmdId;"); //658:1
            __out.AppendLine(); //658:57
            __out.Append("                switch (cmd)"); //659:1
            __out.AppendLine(); //659:29
            __out.Append("                {"); //660:1
            __out.AppendLine(); //660:18
            __out.Append("                    case VsCommands2K.UP:"); //661:1
            __out.AppendLine(); //661:42
            __out.Append("                    case VsCommands2K.UP_EXT:"); //662:1
            __out.AppendLine(); //662:46
            __out.Append("                    case VsCommands2K.UP_EXT_COL:"); //663:1
            __out.AppendLine(); //663:50
            __out.Append("                    case VsCommands2K.DOWN:"); //664:1
            __out.AppendLine(); //664:44
            __out.Append("                    case VsCommands2K.DOWN_EXT:"); //665:1
            __out.AppendLine(); //665:48
            __out.Append("                    case VsCommands2K.DOWN_EXT_COL:"); //666:1
            __out.AppendLine(); //666:52
            __out.Append("                        Source.OnCommand(TextView, cmd, '"); //667:1
            __out.Append("\\"); //667:58
            __out.Append("0');"); //667:59
            __out.AppendLine(); //667:63
            __out.Append("                        return;"); //668:1
            __out.AppendLine(); //668:32
            __out.Append("                }"); //669:1
            __out.AppendLine(); //669:18
            __out.Append("            }"); //670:1
            __out.AppendLine(); //670:14
            __out.Append("            base.HandlePostExec(ref guidCmdGroup, nCmdId, nCmdexecopt, pvaIn, pvaOut, bufferWasChanged);"); //671:1
            __out.AppendLine(); //671:105
            __out.Append("        }"); //672:1
            __out.AppendLine(); //672:10
            __out.Append("    }"); //673:1
            __out.AppendLine(); //673:6
            __out.Append("}"); //675:1
            __out.AppendLine(); //675:2
            return __out.ToString();
        }

    }
}

