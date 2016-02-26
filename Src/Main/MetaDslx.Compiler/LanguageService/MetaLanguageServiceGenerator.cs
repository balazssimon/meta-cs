using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler //1:1
{
    using __Hidden_MetaLanguageServiceGenerator_151985501;
    namespace __Hidden_MetaLanguageServiceGenerator_151985501
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

        public MetaLanguageServiceGenerator() //2:1
        {
            this.Properties = new __Properties();
        }

        public MetaLanguageServiceGenerator(object instances) : this() //2:1
        {
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
            __out.AppendLine(false); //12:14
            __out.Append("using System.Collections.Generic;"); //13:1
            __out.AppendLine(false); //13:34
            __out.Append("using System.ComponentModel;"); //14:1
            __out.AppendLine(false); //14:29
            __out.Append("using System.Diagnostics;"); //15:1
            __out.AppendLine(false); //15:26
            __out.Append("using System.IO;"); //16:1
            __out.AppendLine(false); //16:17
            __out.Append("using System.Linq;"); //17:1
            __out.AppendLine(false); //17:19
            __out.Append("using System.Runtime.InteropServices;"); //18:1
            __out.AppendLine(false); //18:38
            __out.Append("using System.Text;"); //19:1
            __out.AppendLine(false); //19:19
            __out.Append("using System.Threading.Tasks;"); //20:1
            __out.AppendLine(false); //20:30
            __out.Append("using Microsoft.VisualStudio.OLE.Interop;"); //21:1
            __out.AppendLine(false); //21:42
            __out.Append("using Microsoft.VisualStudio.Package;"); //22:1
            __out.AppendLine(false); //22:38
            __out.Append("using Microsoft.VisualStudio.Shell.Interop;"); //23:1
            __out.AppendLine(false); //23:44
            __out.Append("using Microsoft.VisualStudio.TextManager.Interop;"); //24:1
            __out.AppendLine(false); //24:50
            __out.Append("using Antlr4.Runtime;"); //25:1
            __out.AppendLine(false); //25:22
            __out.Append("using MetaDslx.Compiler;"); //26:1
            __out.AppendLine(false); //26:25
            __out.Append("using System.Drawing;"); //27:1
            __out.AppendLine(false); //27:22
            __out.Append("using Microsoft.VisualStudio;"); //28:1
            __out.AppendLine(false); //28:30
            __out.Append("using Microsoft.VisualStudio.Shell;"); //29:1
            __out.AppendLine(false); //29:36
            __out.AppendLine(true); //30:1
            __out.Append("using VsCommands2K = Microsoft.VisualStudio.VSConstants.VSStd2KCmdID;"); //31:1
            __out.AppendLine(false); //31:70
            __out.AppendLine(true); //32:1
            string __tmp2Line = "namespace "; //33:1
            if (__tmp2Line != null) __out.Append(__tmp2Line);
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(Properties.LanguageServiceNamespace);
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(__tmp3_first || !__tmp3_last)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if (__tmp3Line != null) __out.Append(__tmp3Line);
                    if (!__tmp3_last) __out.AppendLine(true);
                    __out.AppendLine(false); //33:48
                }
            }
            __out.Append("{"); //34:1
            __out.AppendLine(false); //34:2
            string __tmp5Line = "    public class "; //35:1
            if (__tmp5Line != null) __out.Append(__tmp5Line);
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(Properties.LanguageClassName);
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(__tmp6_first || !__tmp6_last)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if (__tmp6Line != null) __out.Append(__tmp6Line);
                    if (!__tmp6_last) __out.AppendLine(true);
                }
            }
            string __tmp7Line = "LanguageAuthoringScope : AuthoringScope"; //35:48
            if (__tmp7Line != null) __out.Append(__tmp7Line);
            __out.AppendLine(false); //35:87
            __out.Append("    {"); //36:1
            __out.AppendLine(false); //36:6
            __out.Append("        public override string GetDataTipText(int line, int col, out TextSpan span)"); //37:1
            __out.AppendLine(false); //37:84
            __out.Append("        {"); //38:1
            __out.AppendLine(false); //38:10
            __out.Append("            span = new TextSpan();"); //39:1
            __out.AppendLine(false); //39:35
            __out.Append("            return null;"); //40:1
            __out.AppendLine(false); //40:25
            __out.Append("        }"); //41:1
            __out.AppendLine(false); //41:10
            __out.Append("        public override Declarations GetDeclarations(IVsTextView view, int line, int col, TokenInfo info, ParseReason reason)"); //43:1
            __out.AppendLine(false); //43:126
            __out.Append("        {"); //44:1
            __out.AppendLine(false); //44:10
            __out.Append("            return null;"); //45:1
            __out.AppendLine(false); //45:25
            __out.Append("        }"); //46:1
            __out.AppendLine(false); //46:10
            __out.Append("        public override Methods GetMethods(int line, int col, string name)"); //48:1
            __out.AppendLine(false); //48:75
            __out.Append("        {"); //49:1
            __out.AppendLine(false); //49:10
            __out.Append("            return null;"); //50:1
            __out.AppendLine(false); //50:25
            __out.Append("        }"); //51:1
            __out.AppendLine(false); //51:10
            __out.Append("        public override string Goto(Microsoft.VisualStudio.VSConstants.VSStd97CmdID cmd, IVsTextView textView, int line, int col, out TextSpan span)"); //53:1
            __out.AppendLine(false); //53:149
            __out.Append("        {"); //54:1
            __out.AppendLine(false); //54:10
            __out.Append("            span = new TextSpan();"); //55:1
            __out.AppendLine(false); //55:35
            __out.Append("            return null;"); //56:1
            __out.AppendLine(false); //56:25
            __out.Append("        }"); //57:1
            __out.AppendLine(false); //57:10
            __out.Append("    }"); //58:1
            __out.AppendLine(false); //58:6
            string __tmp9Line = "	public class "; //60:1
            if (__tmp9Line != null) __out.Append(__tmp9Line);
            StringBuilder __tmp10 = new StringBuilder();
            __tmp10.Append(Properties.LanguageClassName);
            using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
            {
                bool __tmp10_first = true;
                bool __tmp10_last = __tmp10Reader.EndOfStream;
                while(__tmp10_first || !__tmp10_last)
                {
                    __tmp10_first = false;
                    string __tmp10Line = __tmp10Reader.ReadLine();
                    __tmp10_last = __tmp10Reader.EndOfStream;
                    if (__tmp10Line != null) __out.Append(__tmp10Line);
                    if (!__tmp10_last) __out.AppendLine(true);
                }
            }
            string __tmp11Line = "LanguageColorizer : Colorizer"; //60:45
            if (__tmp11Line != null) __out.Append(__tmp11Line);
            __out.AppendLine(false); //60:74
            __out.Append("    {"); //61:1
            __out.AppendLine(false); //61:6
            string __tmp13Line = "        public "; //62:1
            if (__tmp13Line != null) __out.Append(__tmp13Line);
            StringBuilder __tmp14 = new StringBuilder();
            __tmp14.Append(Properties.LanguageClassName);
            using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
            {
                bool __tmp14_first = true;
                bool __tmp14_last = __tmp14Reader.EndOfStream;
                while(__tmp14_first || !__tmp14_last)
                {
                    __tmp14_first = false;
                    string __tmp14Line = __tmp14Reader.ReadLine();
                    __tmp14_last = __tmp14Reader.EndOfStream;
                    if (__tmp14Line != null) __out.Append(__tmp14Line);
                    if (!__tmp14_last) __out.AppendLine(true);
                }
            }
            string __tmp15Line = "LanguageColorizer(LanguageService svc, IVsTextLines buffer, IScanner scanner)"; //62:46
            if (__tmp15Line != null) __out.Append(__tmp15Line);
            __out.AppendLine(false); //62:123
            __out.Append("            : base(svc, buffer, scanner)"); //63:1
            __out.AppendLine(false); //63:41
            __out.Append("        {"); //64:1
            __out.AppendLine(false); //64:10
            __out.Append("        }"); //65:1
            __out.AppendLine(false); //65:10
            __out.Append("        #region IVsColorizer Members"); //67:1
            __out.AppendLine(false); //67:37
            string __tmp17Line = "        public override int ColorizeLine(int line, int length, IntPtr ptr, int state, uint"; //69:1
            if (__tmp17Line != null) __out.Append(__tmp17Line);
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append("[]");
            using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
            {
                bool __tmp18_first = true;
                bool __tmp18_last = __tmp18Reader.EndOfStream;
                while(__tmp18_first || !__tmp18_last)
                {
                    __tmp18_first = false;
                    string __tmp18Line = __tmp18Reader.ReadLine();
                    __tmp18_last = __tmp18Reader.EndOfStream;
                    if (__tmp18Line != null) __out.Append(__tmp18Line);
                    if (!__tmp18_last) __out.AppendLine(true);
                }
            }
            string __tmp19Line = " attrs)"; //69:97
            if (__tmp19Line != null) __out.Append(__tmp19Line);
            __out.AppendLine(false); //69:104
            __out.Append("        {"); //70:1
            __out.AppendLine(false); //70:10
            __out.Append("            if (attrs == null) return state;"); //71:1
            __out.AppendLine(false); //71:45
            __out.Append("            int linepos = 0;"); //72:1
            __out.AppendLine(false); //72:29
            __out.Append("            // Must initialize the colors in all cases, otherwise you get "); //73:1
            __out.AppendLine(false); //73:75
            __out.Append("            // random color junk on the screen."); //74:1
            __out.AppendLine(false); //74:48
            __out.Append("            for (linepos = 0; linepos < attrs.Length; linepos++)"); //75:1
            __out.AppendLine(false); //75:65
            string __tmp21Line = "                attrs"; //76:1
            if (__tmp21Line != null) __out.Append(__tmp21Line);
            StringBuilder __tmp22 = new StringBuilder();
            __tmp22.Append("[linepos]");
            using(StreamReader __tmp22Reader = new StreamReader(this.__ToStream(__tmp22.ToString())))
            {
                bool __tmp22_first = true;
                bool __tmp22_last = __tmp22Reader.EndOfStream;
                while(__tmp22_first || !__tmp22_last)
                {
                    __tmp22_first = false;
                    string __tmp22Line = __tmp22Reader.ReadLine();
                    __tmp22_last = __tmp22Reader.EndOfStream;
                    if (__tmp22Line != null) __out.Append(__tmp22Line);
                    if (!__tmp22_last) __out.AppendLine(true);
                }
            }
            string __tmp23Line = " = (uint)TokenColor.Text;"; //76:35
            if (__tmp23Line != null) __out.Append(__tmp23Line);
            __out.AppendLine(false); //76:60
            __out.Append("            if (this.Scanner != null)"); //77:1
            __out.AppendLine(false); //77:38
            __out.Append("            {"); //78:1
            __out.AppendLine(false); //78:14
            __out.Append("                try"); //79:1
            __out.AppendLine(false); //79:20
            __out.Append("                {"); //80:1
            __out.AppendLine(false); //80:18
            __out.Append("                    string text = Marshal.PtrToStringUni(ptr, length);"); //81:1
            __out.AppendLine(false); //81:71
            __out.Append("                    this.Scanner.SetSource(text, 0);"); //83:1
            __out.AppendLine(false); //83:53
            __out.Append("                    TokenInfo tokenInfo = new TokenInfo();"); //85:1
            __out.AppendLine(false); //85:59
            __out.Append("                    tokenInfo.EndIndex = -1;"); //87:1
            __out.AppendLine(false); //87:45
            __out.Append("                    while (this.Scanner.ScanTokenAndProvideInfoAboutIt(tokenInfo, ref state))"); //89:1
            __out.AppendLine(false); //89:94
            __out.Append("                    {"); //90:1
            __out.AppendLine(false); //90:22
            __out.Append("                        for (linepos = tokenInfo.StartIndex; linepos <= tokenInfo.EndIndex; linepos++)"); //91:1
            __out.AppendLine(false); //91:103
            __out.Append("                        {"); //92:1
            __out.AppendLine(false); //92:26
            __out.Append("                            if (linepos >= 0 && linepos < attrs.Length)"); //93:1
            __out.AppendLine(false); //93:72
            __out.Append("                            {"); //94:1
            __out.AppendLine(false); //94:30
            string __tmp25Line = "                                attrs"; //95:1
            if (__tmp25Line != null) __out.Append(__tmp25Line);
            StringBuilder __tmp26 = new StringBuilder();
            __tmp26.Append("[linepos]");
            using(StreamReader __tmp26Reader = new StreamReader(this.__ToStream(__tmp26.ToString())))
            {
                bool __tmp26_first = true;
                bool __tmp26_last = __tmp26Reader.EndOfStream;
                while(__tmp26_first || !__tmp26_last)
                {
                    __tmp26_first = false;
                    string __tmp26Line = __tmp26Reader.ReadLine();
                    __tmp26_last = __tmp26Reader.EndOfStream;
                    if (__tmp26Line != null) __out.Append(__tmp26Line);
                    if (!__tmp26_last) __out.AppendLine(true);
                }
            }
            string __tmp27Line = " = (uint)tokenInfo.Color;"; //95:51
            if (__tmp27Line != null) __out.Append(__tmp27Line);
            __out.AppendLine(false); //95:76
            __out.Append("                            }"); //96:1
            __out.AppendLine(false); //96:30
            __out.Append("                        }"); //97:1
            __out.AppendLine(false); //97:26
            __out.Append("                    }"); //98:1
            __out.AppendLine(false); //98:22
            __out.Append("                }"); //99:1
            __out.AppendLine(false); //99:18
            __out.Append("                catch (Exception)"); //100:1
            __out.AppendLine(false); //100:34
            __out.Append("                {"); //101:1
            __out.AppendLine(false); //101:18
            __out.Append("                    // Ignore exceptions"); //102:1
            __out.AppendLine(false); //102:41
            __out.Append("                }"); //103:1
            __out.AppendLine(false); //103:18
            __out.Append("            }"); //104:1
            __out.AppendLine(false); //104:14
            __out.Append("            return state;"); //105:1
            __out.AppendLine(false); //105:26
            __out.Append("        }"); //106:1
            __out.AppendLine(false); //106:10
            __out.Append("        public override int GetStartState(out int piStartState)"); //108:1
            __out.AppendLine(false); //108:64
            __out.Append("        {"); //109:1
            __out.AppendLine(false); //109:10
            __out.Append("            piStartState = 0;"); //110:1
            __out.AppendLine(false); //110:30
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //111:1
            __out.AppendLine(false); //111:60
            __out.Append("        }"); //112:1
            __out.AppendLine(false); //112:10
            __out.Append("        public override int GetStateAtEndOfLine(int iLine, int iLength, IntPtr pText, int iState)"); //114:1
            __out.AppendLine(false); //114:98
            __out.Append("        {"); //115:1
            __out.AppendLine(false); //115:10
            __out.Append("            string text = Marshal.PtrToStringUni(pText, iLength);"); //116:1
            __out.AppendLine(false); //116:66
            __out.Append("            if (text != null)"); //117:1
            __out.AppendLine(false); //117:30
            __out.Append("            {"); //118:1
            __out.AppendLine(false); //118:14
            __out.Append("                this.Scanner.SetSource(text, 0);"); //119:1
            __out.AppendLine(false); //119:49
            string __tmp29Line = "                (("; //120:1
            if (__tmp29Line != null) __out.Append(__tmp29Line);
            StringBuilder __tmp30 = new StringBuilder();
            __tmp30.Append(Properties.LanguageClassName);
            using(StreamReader __tmp30Reader = new StreamReader(this.__ToStream(__tmp30.ToString())))
            {
                bool __tmp30_first = true;
                bool __tmp30_last = __tmp30Reader.EndOfStream;
                while(__tmp30_first || !__tmp30_last)
                {
                    __tmp30_first = false;
                    string __tmp30Line = __tmp30Reader.ReadLine();
                    __tmp30_last = __tmp30Reader.EndOfStream;
                    if (__tmp30Line != null) __out.Append(__tmp30Line);
                    if (!__tmp30_last) __out.AppendLine(true);
                }
            }
            string __tmp31Line = "LanguageScanner)this.Scanner).ScanLine(ref iState);"; //120:49
            if (__tmp31Line != null) __out.Append(__tmp31Line);
            __out.AppendLine(false); //120:100
            __out.Append("            }"); //121:1
            __out.AppendLine(false); //121:14
            __out.Append("            return iState;"); //122:1
            __out.AppendLine(false); //122:27
            __out.Append("        }"); //123:1
            __out.AppendLine(false); //123:10
            __out.Append("        public override int GetStateMaintenanceFlag(out int pfFlag)"); //125:1
            __out.AppendLine(false); //125:68
            __out.Append("        {"); //126:1
            __out.AppendLine(false); //126:10
            __out.Append("            pfFlag = 1;"); //127:1
            __out.AppendLine(false); //127:24
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //128:1
            __out.AppendLine(false); //128:60
            __out.Append("        }"); //129:1
            __out.AppendLine(false); //129:10
            __out.Append("        #endregion"); //131:1
            __out.AppendLine(false); //131:19
            __out.Append("    }"); //132:1
            __out.AppendLine(false); //132:6
            string __tmp33Line = "    public abstract class "; //135:1
            if (__tmp33Line != null) __out.Append(__tmp33Line);
            StringBuilder __tmp34 = new StringBuilder();
            __tmp34.Append(Properties.LanguageClassName);
            using(StreamReader __tmp34Reader = new StreamReader(this.__ToStream(__tmp34.ToString())))
            {
                bool __tmp34_first = true;
                bool __tmp34_last = __tmp34Reader.EndOfStream;
                while(__tmp34_first || !__tmp34_last)
                {
                    __tmp34_first = false;
                    string __tmp34Line = __tmp34Reader.ReadLine();
                    __tmp34_last = __tmp34Reader.EndOfStream;
                    if (__tmp34Line != null) __out.Append(__tmp34Line);
                    if (!__tmp34_last) __out.AppendLine(true);
                }
            }
            string __tmp35Line = "LanguageConfigBase"; //135:57
            if (__tmp35Line != null) __out.Append(__tmp35Line);
            __out.AppendLine(false); //135:75
            __out.Append("    {"); //136:1
            __out.AppendLine(false); //136:6
            string __tmp37Line = "        private static "; //137:1
            if (__tmp37Line != null) __out.Append(__tmp37Line);
            StringBuilder __tmp38 = new StringBuilder();
            __tmp38.Append(Properties.LanguageClassName);
            using(StreamReader __tmp38Reader = new StreamReader(this.__ToStream(__tmp38.ToString())))
            {
                bool __tmp38_first = true;
                bool __tmp38_last = __tmp38Reader.EndOfStream;
                while(__tmp38_first || !__tmp38_last)
                {
                    __tmp38_first = false;
                    string __tmp38Line = __tmp38Reader.ReadLine();
                    __tmp38_last = __tmp38Reader.EndOfStream;
                    if (__tmp38Line != null) __out.Append(__tmp38Line);
                    if (!__tmp38_last) __out.AppendLine(true);
                }
            }
            string __tmp39Line = "LanguageConfig instance = null;"; //137:54
            if (__tmp39Line != null) __out.Append(__tmp39Line);
            __out.AppendLine(false); //137:85
            string __tmp41Line = "        public static "; //138:1
            if (__tmp41Line != null) __out.Append(__tmp41Line);
            StringBuilder __tmp42 = new StringBuilder();
            __tmp42.Append(Properties.LanguageClassName);
            using(StreamReader __tmp42Reader = new StreamReader(this.__ToStream(__tmp42.ToString())))
            {
                bool __tmp42_first = true;
                bool __tmp42_last = __tmp42Reader.EndOfStream;
                while(__tmp42_first || !__tmp42_last)
                {
                    __tmp42_first = false;
                    string __tmp42Line = __tmp42Reader.ReadLine();
                    __tmp42_last = __tmp42Reader.EndOfStream;
                    if (__tmp42Line != null) __out.Append(__tmp42Line);
                    if (!__tmp42_last) __out.AppendLine(true);
                }
            }
            string __tmp43Line = "LanguageConfig Instance"; //138:53
            if (__tmp43Line != null) __out.Append(__tmp43Line);
            __out.AppendLine(false); //138:76
            __out.Append("        {"); //139:1
            __out.AppendLine(false); //139:10
            __out.Append("            get "); //140:1
            __out.AppendLine(false); //140:17
            __out.Append("            {"); //141:1
            __out.AppendLine(false); //141:14
            __out.Append("                if (instance == null)"); //142:1
            __out.AppendLine(false); //142:38
            __out.Append("                {"); //143:1
            __out.AppendLine(false); //143:18
            string __tmp45Line = "					// If there is a compile error in the following line, create a class "; //144:1
            if (__tmp45Line != null) __out.Append(__tmp45Line);
            StringBuilder __tmp46 = new StringBuilder();
            __tmp46.Append(Properties.LanguageClassName);
            using(StreamReader __tmp46Reader = new StreamReader(this.__ToStream(__tmp46.ToString())))
            {
                bool __tmp46_first = true;
                bool __tmp46_last = __tmp46Reader.EndOfStream;
                while(__tmp46_first || !__tmp46_last)
                {
                    __tmp46_first = false;
                    string __tmp46Line = __tmp46Reader.ReadLine();
                    __tmp46_last = __tmp46Reader.EndOfStream;
                    if (__tmp46Line != null) __out.Append(__tmp46Line);
                    if (!__tmp46_last) __out.AppendLine(true);
                }
            }
            string __tmp47Line = "LanguageConfig"; //144:105
            if (__tmp47Line != null) __out.Append(__tmp47Line);
            __out.AppendLine(false); //144:119
            string __tmp49Line = "					// which is a subclass of "; //145:1
            if (__tmp49Line != null) __out.Append(__tmp49Line);
            StringBuilder __tmp50 = new StringBuilder();
            __tmp50.Append(Properties.LanguageClassName);
            using(StreamReader __tmp50Reader = new StreamReader(this.__ToStream(__tmp50.ToString())))
            {
                bool __tmp50_first = true;
                bool __tmp50_last = __tmp50Reader.EndOfStream;
                while(__tmp50_first || !__tmp50_last)
                {
                    __tmp50_first = false;
                    string __tmp50Line = __tmp50Reader.ReadLine();
                    __tmp50_last = __tmp50Reader.EndOfStream;
                    if (__tmp50Line != null) __out.Append(__tmp50Line);
                    if (!__tmp50_last) __out.AppendLine(true);
                }
            }
            string __tmp51Line = "LanguageConfigBase"; //145:62
            if (__tmp51Line != null) __out.Append(__tmp51Line);
            __out.AppendLine(false); //145:80
            string __tmp53Line = "                    instance = new "; //146:1
            if (__tmp53Line != null) __out.Append(__tmp53Line);
            StringBuilder __tmp54 = new StringBuilder();
            __tmp54.Append(Properties.LanguageClassName);
            using(StreamReader __tmp54Reader = new StreamReader(this.__ToStream(__tmp54.ToString())))
            {
                bool __tmp54_first = true;
                bool __tmp54_last = __tmp54Reader.EndOfStream;
                while(__tmp54_first || !__tmp54_last)
                {
                    __tmp54_first = false;
                    string __tmp54Line = __tmp54Reader.ReadLine();
                    __tmp54_last = __tmp54Reader.EndOfStream;
                    if (__tmp54Line != null) __out.Append(__tmp54Line);
                    if (!__tmp54_last) __out.AppendLine(true);
                }
            }
            string __tmp55Line = "LanguageConfig();"; //146:66
            if (__tmp55Line != null) __out.Append(__tmp55Line);
            __out.AppendLine(false); //146:83
            __out.Append("                }"); //147:1
            __out.AppendLine(false); //147:18
            __out.Append("                return instance;"); //148:1
            __out.AppendLine(false); //148:33
            __out.Append("            }"); //149:1
            __out.AppendLine(false); //149:14
            __out.Append("        }"); //150:1
            __out.AppendLine(false); //150:10
            string __tmp57Line = "        private List<"; //151:1
            if (__tmp57Line != null) __out.Append(__tmp57Line);
            StringBuilder __tmp58 = new StringBuilder();
            __tmp58.Append(Properties.LanguageClassName);
            using(StreamReader __tmp58Reader = new StreamReader(this.__ToStream(__tmp58.ToString())))
            {
                bool __tmp58_first = true;
                bool __tmp58_last = __tmp58Reader.EndOfStream;
                while(__tmp58_first || !__tmp58_last)
                {
                    __tmp58_first = false;
                    string __tmp58Line = __tmp58Reader.ReadLine();
                    __tmp58_last = __tmp58Reader.EndOfStream;
                    if (__tmp58Line != null) __out.Append(__tmp58Line);
                    if (!__tmp58_last) __out.AppendLine(true);
                }
            }
            string __tmp59Line = "LanguageColorableItem> colorableItems = new List<"; //151:52
            if (__tmp59Line != null) __out.Append(__tmp59Line);
            StringBuilder __tmp60 = new StringBuilder();
            __tmp60.Append(Properties.LanguageClassName);
            using(StreamReader __tmp60Reader = new StreamReader(this.__ToStream(__tmp60.ToString())))
            {
                bool __tmp60_first = true;
                bool __tmp60_last = __tmp60Reader.EndOfStream;
                while(__tmp60_first || !__tmp60_last)
                {
                    __tmp60_first = false;
                    string __tmp60Line = __tmp60Reader.ReadLine();
                    __tmp60_last = __tmp60Reader.EndOfStream;
                    if (__tmp60Line != null) __out.Append(__tmp60Line);
                    if (!__tmp60_last) __out.AppendLine(true);
                }
            }
            string __tmp61Line = "LanguageColorableItem>();"; //151:131
            if (__tmp61Line != null) __out.Append(__tmp61Line);
            __out.AppendLine(false); //151:156
            string __tmp63Line = "        public IList<"; //152:1
            if (__tmp63Line != null) __out.Append(__tmp63Line);
            StringBuilder __tmp64 = new StringBuilder();
            __tmp64.Append(Properties.LanguageClassName);
            using(StreamReader __tmp64Reader = new StreamReader(this.__ToStream(__tmp64.ToString())))
            {
                bool __tmp64_first = true;
                bool __tmp64_last = __tmp64Reader.EndOfStream;
                while(__tmp64_first || !__tmp64_last)
                {
                    __tmp64_first = false;
                    string __tmp64Line = __tmp64Reader.ReadLine();
                    __tmp64_last = __tmp64Reader.EndOfStream;
                    if (__tmp64Line != null) __out.Append(__tmp64Line);
                    if (!__tmp64_last) __out.AppendLine(true);
                }
            }
            string __tmp65Line = "LanguageColorableItem> ColorableItems"; //152:52
            if (__tmp65Line != null) __out.Append(__tmp65Line);
            __out.AppendLine(false); //152:89
            __out.Append("        {"); //153:1
            __out.AppendLine(false); //153:10
            __out.Append("            get { return colorableItems; }"); //154:1
            __out.AppendLine(false); //154:43
            __out.Append("        }"); //155:1
            __out.AppendLine(false); //155:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, Color foregroundColor)"); //156:1
            __out.AppendLine(false); //156:93
            __out.Append("        {"); //157:1
            __out.AppendLine(false); //157:10
            __out.Append("            return CreateColor(name, type, foregroundColor, false, false);"); //158:1
            __out.AppendLine(false); //158:75
            __out.Append("        }"); //159:1
            __out.AppendLine(false); //159:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, COLORINDEX foregroundIndex)"); //160:1
            __out.AppendLine(false); //160:98
            __out.Append("        {"); //161:1
            __out.AppendLine(false); //161:10
            __out.Append("            return CreateColor(name, type, foregroundIndex, false, false);"); //162:1
            __out.AppendLine(false); //162:75
            __out.Append("        }"); //163:1
            __out.AppendLine(false); //163:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, Color foregroundColor, bool bold, bool strikethrough)"); //164:1
            __out.AppendLine(false); //164:124
            __out.Append("        {"); //165:1
            __out.AppendLine(false); //165:10
            string __tmp67Line = "            colorableItems.Add(new "; //166:1
            if (__tmp67Line != null) __out.Append(__tmp67Line);
            StringBuilder __tmp68 = new StringBuilder();
            __tmp68.Append(Properties.LanguageClassName);
            using(StreamReader __tmp68Reader = new StreamReader(this.__ToStream(__tmp68.ToString())))
            {
                bool __tmp68_first = true;
                bool __tmp68_last = __tmp68Reader.EndOfStream;
                while(__tmp68_first || !__tmp68_last)
                {
                    __tmp68_first = false;
                    string __tmp68Line = __tmp68Reader.ReadLine();
                    __tmp68_last = __tmp68Reader.EndOfStream;
                    if (__tmp68Line != null) __out.Append(__tmp68Line);
                    if (!__tmp68_last) __out.AppendLine(true);
                }
            }
            string __tmp69Line = "LanguageColorableItem(name, type, (COLORINDEX)(-1), COLORINDEX.CI_USERTEXT_BK, foregroundColor, Color.White, bold, strikethrough));"; //166:66
            if (__tmp69Line != null) __out.Append(__tmp69Line);
            __out.AppendLine(false); //166:197
            __out.Append("            return (TokenColor)colorableItems.Count;"); //167:1
            __out.AppendLine(false); //167:53
            __out.Append("        }"); //168:1
            __out.AppendLine(false); //168:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, COLORINDEX foregroundIndex, bool bold, bool strikethrough)"); //169:1
            __out.AppendLine(false); //169:129
            __out.Append("        {"); //170:1
            __out.AppendLine(false); //170:10
            string __tmp71Line = "            colorableItems.Add(new "; //171:1
            if (__tmp71Line != null) __out.Append(__tmp71Line);
            StringBuilder __tmp72 = new StringBuilder();
            __tmp72.Append(Properties.LanguageClassName);
            using(StreamReader __tmp72Reader = new StreamReader(this.__ToStream(__tmp72.ToString())))
            {
                bool __tmp72_first = true;
                bool __tmp72_last = __tmp72Reader.EndOfStream;
                while(__tmp72_first || !__tmp72_last)
                {
                    __tmp72_first = false;
                    string __tmp72Line = __tmp72Reader.ReadLine();
                    __tmp72_last = __tmp72Reader.EndOfStream;
                    if (__tmp72Line != null) __out.Append(__tmp72Line);
                    if (!__tmp72_last) __out.AppendLine(true);
                }
            }
            string __tmp73Line = "LanguageColorableItem(name, type, foregroundIndex, COLORINDEX.CI_USERTEXT_BK, Color.Black, Color.White, bold, strikethrough));"; //171:66
            if (__tmp73Line != null) __out.Append(__tmp73Line);
            __out.AppendLine(false); //171:192
            __out.Append("            return (TokenColor)colorableItems.Count;"); //172:1
            __out.AppendLine(false); //172:53
            __out.Append("        }"); //173:1
            __out.AppendLine(false); //173:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, COLORINDEX foregroundIndex, COLORINDEX backgroundIndex, Color foregroundColor, Color backgroundColor, bool bold, bool strikethrough)"); //174:1
            __out.AppendLine(false); //174:203
            __out.Append("        {"); //175:1
            __out.AppendLine(false); //175:10
            string __tmp75Line = "            colorableItems.Add(new "; //176:1
            if (__tmp75Line != null) __out.Append(__tmp75Line);
            StringBuilder __tmp76 = new StringBuilder();
            __tmp76.Append(Properties.LanguageClassName);
            using(StreamReader __tmp76Reader = new StreamReader(this.__ToStream(__tmp76.ToString())))
            {
                bool __tmp76_first = true;
                bool __tmp76_last = __tmp76Reader.EndOfStream;
                while(__tmp76_first || !__tmp76_last)
                {
                    __tmp76_first = false;
                    string __tmp76Line = __tmp76Reader.ReadLine();
                    __tmp76_last = __tmp76Reader.EndOfStream;
                    if (__tmp76Line != null) __out.Append(__tmp76Line);
                    if (!__tmp76_last) __out.AppendLine(true);
                }
            }
            string __tmp77Line = "LanguageColorableItem(name, type, foregroundIndex, backgroundIndex, foregroundColor, backgroundColor, bold, strikethrough));"; //176:66
            if (__tmp77Line != null) __out.Append(__tmp77Line);
            __out.AppendLine(false); //176:190
            __out.Append("            return (TokenColor)colorableItems.Count;"); //177:1
            __out.AppendLine(false); //177:53
            __out.Append("        }"); //178:1
            __out.AppendLine(false); //178:10
            __out.Append("    }"); //179:1
            __out.AppendLine(false); //179:6
            string __tmp79Line = "    public class "; //180:1
            if (__tmp79Line != null) __out.Append(__tmp79Line);
            StringBuilder __tmp80 = new StringBuilder();
            __tmp80.Append(Properties.LanguageClassName);
            using(StreamReader __tmp80Reader = new StreamReader(this.__ToStream(__tmp80.ToString())))
            {
                bool __tmp80_first = true;
                bool __tmp80_last = __tmp80Reader.EndOfStream;
                while(__tmp80_first || !__tmp80_last)
                {
                    __tmp80_first = false;
                    string __tmp80Line = __tmp80Reader.ReadLine();
                    __tmp80_last = __tmp80Reader.EndOfStream;
                    if (__tmp80Line != null) __out.Append(__tmp80Line);
                    if (!__tmp80_last) __out.AppendLine(true);
                }
            }
            string __tmp81Line = "LanguageColorableItem : IVsColorableItem, IVsHiColorItem"; //180:48
            if (__tmp81Line != null) __out.Append(__tmp81Line);
            __out.AppendLine(false); //180:104
            __out.Append("    {"); //181:1
            __out.AppendLine(false); //181:6
            __out.Append("        // Indicates that the returned RGB value is really an index"); //182:1
            __out.AppendLine(false); //182:68
            __out.Append("        // into a predefined list of colors."); //183:1
            __out.AppendLine(false); //183:45
            __out.Append("        private const uint COLOR_INDEXED = 0x01000000;"); //184:1
            __out.AppendLine(false); //184:55
            __out.Append("        public string DisplayName { get; private set; }"); //186:1
            __out.AppendLine(false); //186:56
            __out.Append("        public TokenType TokenType { get; private set; }"); //187:1
            __out.AppendLine(false); //187:57
            __out.Append("        public COLORINDEX BackgroundIndex { get; private set; }"); //188:1
            __out.AppendLine(false); //188:64
            __out.Append("        public COLORINDEX ForegroundIndex { get; private set; }"); //189:1
            __out.AppendLine(false); //189:64
            __out.Append("        public uint BackgroundColor { get; private set; }"); //190:1
            __out.AppendLine(false); //190:58
            __out.Append("        public uint ForegroundColor { get; private set; }"); //191:1
            __out.AppendLine(false); //191:58
            __out.Append("        public uint FontFlags { get; private set; }"); //192:1
            __out.AppendLine(false); //192:52
            string __tmp83Line = "        public "; //194:1
            if (__tmp83Line != null) __out.Append(__tmp83Line);
            StringBuilder __tmp84 = new StringBuilder();
            __tmp84.Append(Properties.LanguageClassName);
            using(StreamReader __tmp84Reader = new StreamReader(this.__ToStream(__tmp84.ToString())))
            {
                bool __tmp84_first = true;
                bool __tmp84_last = __tmp84Reader.EndOfStream;
                while(__tmp84_first || !__tmp84_last)
                {
                    __tmp84_first = false;
                    string __tmp84Line = __tmp84Reader.ReadLine();
                    __tmp84_last = __tmp84Reader.EndOfStream;
                    if (__tmp84Line != null) __out.Append(__tmp84Line);
                    if (!__tmp84_last) __out.AppendLine(true);
                }
            }
            string __tmp85Line = "LanguageColorableItem(string displayName, TokenType tokenType, COLORINDEX foregroundIndex, COLORINDEX backgroundIndex, Color foregroundColor, Color backgroundColor, bool bold, bool strikethrough)"; //194:46
            if (__tmp85Line != null) __out.Append(__tmp85Line);
            __out.AppendLine(false); //194:241
            __out.Append("        {"); //195:1
            __out.AppendLine(false); //195:10
            __out.Append("            this.DisplayName = displayName;"); //196:1
            __out.AppendLine(false); //196:44
            __out.Append("            this.TokenType = tokenType;"); //197:1
            __out.AppendLine(false); //197:40
            __out.Append("            this.BackgroundIndex = backgroundIndex;"); //198:1
            __out.AppendLine(false); //198:52
            __out.Append("            this.ForegroundIndex = foregroundIndex;"); //199:1
            __out.AppendLine(false); //199:52
            __out.Append("            this.BackgroundColor = (uint)System.Drawing.ColorTranslator.ToWin32(backgroundColor);"); //200:1
            __out.AppendLine(false); //200:98
            __out.Append("            this.ForegroundColor = (uint)System.Drawing.ColorTranslator.ToWin32(foregroundColor);"); //201:1
            __out.AppendLine(false); //201:98
            __out.Append("            this.FontFlags = (uint)FONTFLAGS.FF_DEFAULT;"); //202:1
            __out.AppendLine(false); //202:57
            __out.Append("            if (bold)"); //203:1
            __out.AppendLine(false); //203:22
            __out.Append("                this.FontFlags = this.FontFlags | (uint)FONTFLAGS.FF_BOLD;"); //204:1
            __out.AppendLine(false); //204:75
            __out.Append("            if (strikethrough)"); //205:1
            __out.AppendLine(false); //205:31
            __out.Append("                this.FontFlags = this.FontFlags | (uint)FONTFLAGS.FF_STRIKETHROUGH;"); //206:1
            __out.AppendLine(false); //206:84
            __out.Append("        }"); //207:1
            __out.AppendLine(false); //207:10
            __out.Append("        #region IVsColorableItem Members"); //209:1
            __out.AppendLine(false); //209:41
            string __tmp87Line = "        public int GetDefaultColors(COLORINDEX"; //210:1
            if (__tmp87Line != null) __out.Append(__tmp87Line);
            StringBuilder __tmp88 = new StringBuilder();
            __tmp88.Append("[]");
            using(StreamReader __tmp88Reader = new StreamReader(this.__ToStream(__tmp88.ToString())))
            {
                bool __tmp88_first = true;
                bool __tmp88_last = __tmp88Reader.EndOfStream;
                while(__tmp88_first || !__tmp88_last)
                {
                    __tmp88_first = false;
                    string __tmp88Line = __tmp88Reader.ReadLine();
                    __tmp88_last = __tmp88Reader.EndOfStream;
                    if (__tmp88Line != null) __out.Append(__tmp88Line);
                    if (!__tmp88_last) __out.AppendLine(true);
                }
            }
            string __tmp89Line = " piForeground, COLORINDEX"; //210:53
            if (__tmp89Line != null) __out.Append(__tmp89Line);
            StringBuilder __tmp90 = new StringBuilder();
            __tmp90.Append("[]");
            using(StreamReader __tmp90Reader = new StreamReader(this.__ToStream(__tmp90.ToString())))
            {
                bool __tmp90_first = true;
                bool __tmp90_last = __tmp90Reader.EndOfStream;
                while(__tmp90_first || !__tmp90_last)
                {
                    __tmp90_first = false;
                    string __tmp90Line = __tmp90Reader.ReadLine();
                    __tmp90_last = __tmp90Reader.EndOfStream;
                    if (__tmp90Line != null) __out.Append(__tmp90Line);
                    if (!__tmp90_last) __out.AppendLine(true);
                }
            }
            string __tmp91Line = " piBackground)"; //210:84
            if (__tmp91Line != null) __out.Append(__tmp91Line);
            __out.AppendLine(false); //210:98
            __out.Append("        {"); //211:1
            __out.AppendLine(false); //211:10
            __out.Append("            if (null == piForeground)"); //212:1
            __out.AppendLine(false); //212:38
            __out.Append("            {"); //213:1
            __out.AppendLine(false); //213:14
            __out.Append("                throw new ArgumentNullException(\"piForeground\");"); //214:1
            __out.AppendLine(false); //214:65
            __out.Append("            }"); //215:1
            __out.AppendLine(false); //215:14
            __out.Append("            if (0 == piForeground.Length)"); //216:1
            __out.AppendLine(false); //216:42
            __out.Append("            {"); //217:1
            __out.AppendLine(false); //217:14
            __out.Append("                throw new ArgumentOutOfRangeException(\"piForeground\");"); //218:1
            __out.AppendLine(false); //218:71
            __out.Append("            }"); //219:1
            __out.AppendLine(false); //219:14
            string __tmp93Line = "            piForeground"; //220:1
            if (__tmp93Line != null) __out.Append(__tmp93Line);
            StringBuilder __tmp94 = new StringBuilder();
            __tmp94.Append("[0]");
            using(StreamReader __tmp94Reader = new StreamReader(this.__ToStream(__tmp94.ToString())))
            {
                bool __tmp94_first = true;
                bool __tmp94_last = __tmp94Reader.EndOfStream;
                while(__tmp94_first || !__tmp94_last)
                {
                    __tmp94_first = false;
                    string __tmp94Line = __tmp94Reader.ReadLine();
                    __tmp94_last = __tmp94Reader.EndOfStream;
                    if (__tmp94Line != null) __out.Append(__tmp94Line);
                    if (!__tmp94_last) __out.AppendLine(true);
                }
            }
            string __tmp95Line = " = this.ForegroundIndex;"; //220:32
            if (__tmp95Line != null) __out.Append(__tmp95Line);
            __out.AppendLine(false); //220:56
            __out.Append("            if (null == piBackground)"); //221:1
            __out.AppendLine(false); //221:38
            __out.Append("            {"); //222:1
            __out.AppendLine(false); //222:14
            __out.Append("                throw new ArgumentNullException(\"piBackground\");"); //223:1
            __out.AppendLine(false); //223:65
            __out.Append("            }"); //224:1
            __out.AppendLine(false); //224:14
            __out.Append("            if (0 == piBackground.Length)"); //225:1
            __out.AppendLine(false); //225:42
            __out.Append("            {"); //226:1
            __out.AppendLine(false); //226:14
            __out.Append("                throw new ArgumentOutOfRangeException(\"piBackground\");"); //227:1
            __out.AppendLine(false); //227:71
            __out.Append("            }"); //228:1
            __out.AppendLine(false); //228:14
            string __tmp97Line = "            piBackground"; //229:1
            if (__tmp97Line != null) __out.Append(__tmp97Line);
            StringBuilder __tmp98 = new StringBuilder();
            __tmp98.Append("[0]");
            using(StreamReader __tmp98Reader = new StreamReader(this.__ToStream(__tmp98.ToString())))
            {
                bool __tmp98_first = true;
                bool __tmp98_last = __tmp98Reader.EndOfStream;
                while(__tmp98_first || !__tmp98_last)
                {
                    __tmp98_first = false;
                    string __tmp98Line = __tmp98Reader.ReadLine();
                    __tmp98_last = __tmp98Reader.EndOfStream;
                    if (__tmp98Line != null) __out.Append(__tmp98Line);
                    if (!__tmp98_last) __out.AppendLine(true);
                }
            }
            string __tmp99Line = " = this.BackgroundIndex;"; //229:32
            if (__tmp99Line != null) __out.Append(__tmp99Line);
            __out.AppendLine(false); //229:56
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //230:1
            __out.AppendLine(false); //230:60
            __out.Append("        }"); //231:1
            __out.AppendLine(false); //231:10
            __out.Append("        public int GetDefaultFontFlags(out uint pdwFontFlags)"); //232:1
            __out.AppendLine(false); //232:62
            __out.Append("        {"); //233:1
            __out.AppendLine(false); //233:10
            __out.Append("            pdwFontFlags = this.FontFlags;"); //234:1
            __out.AppendLine(false); //234:43
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //235:1
            __out.AppendLine(false); //235:60
            __out.Append("        }"); //236:1
            __out.AppendLine(false); //236:10
            __out.Append("        public int GetDisplayName(out string pbstrName)"); //237:1
            __out.AppendLine(false); //237:56
            __out.Append("        {"); //238:1
            __out.AppendLine(false); //238:10
            __out.Append("            pbstrName = this.DisplayName;"); //239:1
            __out.AppendLine(false); //239:42
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //240:1
            __out.AppendLine(false); //240:60
            __out.Append("        }"); //241:1
            __out.AppendLine(false); //241:10
            __out.Append("        public int GetColorData(int cdElement, out uint pcrColor)"); //243:1
            __out.AppendLine(false); //243:66
            __out.Append("        {"); //244:1
            __out.AppendLine(false); //244:10
            __out.Append("            int retval = VSConstants.E_NOTIMPL;"); //245:1
            __out.AppendLine(false); //245:48
            __out.Append("            pcrColor = 0;"); //246:1
            __out.AppendLine(false); //246:26
            __out.Append("            switch ((__tagVSCOLORDATA)cdElement)"); //248:1
            __out.AppendLine(false); //248:49
            __out.Append("            {"); //249:1
            __out.AppendLine(false); //249:14
            __out.Append("                case __tagVSCOLORDATA.CD_BACKGROUND:"); //250:1
            __out.AppendLine(false); //250:53
            __out.Append("                    pcrColor = this.BackgroundIndex > 0 ?"); //251:1
            __out.AppendLine(false); //251:58
            __out.Append("                                   (uint)this.BackgroundIndex | COLOR_INDEXED"); //252:1
            __out.AppendLine(false); //252:78
            __out.Append("                                   : this.BackgroundColor;"); //253:1
            __out.AppendLine(false); //253:59
            __out.Append("                    retval = VSConstants.S_OK;"); //254:1
            __out.AppendLine(false); //254:47
            __out.Append("                    break;"); //255:1
            __out.AppendLine(false); //255:27
            __out.Append("                case __tagVSCOLORDATA.CD_FOREGROUND:"); //257:1
            __out.AppendLine(false); //257:53
            __out.Append("                case __tagVSCOLORDATA.CD_LINECOLOR:"); //258:1
            __out.AppendLine(false); //258:52
            __out.Append("                    pcrColor = this.ForegroundIndex > 0 ?"); //259:1
            __out.AppendLine(false); //259:58
            __out.Append("                                   (uint)this.ForegroundIndex | COLOR_INDEXED"); //260:1
            __out.AppendLine(false); //260:78
            __out.Append("                                   : this.ForegroundColor;"); //261:1
            __out.AppendLine(false); //261:59
            __out.Append("                    retval = VSConstants.S_OK;"); //262:1
            __out.AppendLine(false); //262:47
            __out.Append("                    break;"); //263:1
            __out.AppendLine(false); //263:27
            __out.Append("                default:"); //265:1
            __out.AppendLine(false); //265:25
            __out.Append("                    retval = VSConstants.E_INVALIDARG;"); //266:1
            __out.AppendLine(false); //266:55
            __out.Append("                    break;"); //267:1
            __out.AppendLine(false); //267:27
            __out.Append("            }"); //268:1
            __out.AppendLine(false); //268:14
            __out.Append("            return retval;"); //269:1
            __out.AppendLine(false); //269:27
            __out.Append("        }"); //271:1
            __out.AppendLine(false); //271:10
            __out.Append("        #endregion"); //272:1
            __out.AppendLine(false); //272:19
            __out.Append("    }"); //273:1
            __out.AppendLine(false); //273:6
            string __tmp100Prefix = "    "; //276:1
            StringBuilder __tmp101 = new StringBuilder();
            __tmp101.Append("[ComVisible(true)]");
            using(StreamReader __tmp101Reader = new StreamReader(this.__ToStream(__tmp101.ToString())))
            {
                bool __tmp101_first = true;
                bool __tmp101_last = __tmp101Reader.EndOfStream;
                while(__tmp101_first || !__tmp101_last)
                {
                    __tmp101_first = false;
                    string __tmp101Line = __tmp101Reader.ReadLine();
                    __tmp101_last = __tmp101Reader.EndOfStream;
                    __out.Append(__tmp100Prefix);
                    if (__tmp101Line != null) __out.Append(__tmp101Line);
                    if (!__tmp101_last) __out.AppendLine(true);
                    __out.AppendLine(false); //276:27
                }
            }
            string __tmp102Prefix = "    "; //277:1
            StringBuilder __tmp103 = new StringBuilder();
            __tmp103.Append("[Guid(" + Properties.LanguageClassName + "LanguageConfig." + Properties.LanguageClassName + "GeneratorServiceGuid)]");
            using(StreamReader __tmp103Reader = new StreamReader(this.__ToStream(__tmp103.ToString())))
            {
                bool __tmp103_first = true;
                bool __tmp103_last = __tmp103Reader.EndOfStream;
                while(__tmp103_first || !__tmp103_last)
                {
                    __tmp103_first = false;
                    string __tmp103Line = __tmp103Reader.ReadLine();
                    __tmp103_last = __tmp103Reader.EndOfStream;
                    __out.Append(__tmp102Prefix);
                    if (__tmp103Line != null) __out.Append(__tmp103Line);
                    if (!__tmp103_last) __out.AppendLine(true);
                    __out.AppendLine(false); //277:116
                }
            }
            string __tmp104Prefix = "    "; //278:1
            StringBuilder __tmp105 = new StringBuilder();
            __tmp105.Append("[ProvideObject(typeof(" + Properties.LanguageClassName + "GeneratorService), RegisterUsing = RegistrationMethod.CodeBase)]");
            using(StreamReader __tmp105Reader = new StreamReader(this.__ToStream(__tmp105.ToString())))
            {
                bool __tmp105_first = true;
                bool __tmp105_last = __tmp105Reader.EndOfStream;
                while(__tmp105_first || !__tmp105_last)
                {
                    __tmp105_first = false;
                    string __tmp105Line = __tmp105Reader.ReadLine();
                    __tmp105_last = __tmp105Reader.EndOfStream;
                    __out.Append(__tmp104Prefix);
                    if (__tmp105Line != null) __out.Append(__tmp105Line);
                    if (!__tmp105_last) __out.AppendLine(true);
                    __out.AppendLine(false); //278:127
                }
            }
            string __tmp106Prefix = "    "; //279:1
            StringBuilder __tmp107 = new StringBuilder();
            __tmp107.Append("[CodeGeneratorRegistration(typeof(" + Properties.LanguageClassName + "GeneratorService), " + Properties.LanguageClassName + "LanguageConfig.GeneratorName, \"{fae04ec1-301f-11d3-bf4b-00c04f79efbc}\", GeneratorRegKeyName = " + Properties.LanguageClassName + "LanguageConfig.FileExtension)]");
            using(StreamReader __tmp107Reader = new StreamReader(this.__ToStream(__tmp107.ToString())))
            {
                bool __tmp107_first = true;
                bool __tmp107_last = __tmp107Reader.EndOfStream;
                while(__tmp107_first || !__tmp107_last)
                {
                    __tmp107_first = false;
                    string __tmp107Line = __tmp107Reader.ReadLine();
                    __tmp107_last = __tmp107Reader.EndOfStream;
                    __out.Append(__tmp106Prefix);
                    if (__tmp107Line != null) __out.Append(__tmp107Line);
                    if (!__tmp107_last) __out.AppendLine(true);
                    __out.AppendLine(false); //279:284
                }
            }
            string __tmp108Prefix = "    "; //280:1
            StringBuilder __tmp109 = new StringBuilder();
            __tmp109.Append("[CodeGeneratorRegistration(typeof(" + Properties.LanguageClassName + "GeneratorService), " + Properties.LanguageClassName + "LanguageConfig.GeneratorServiceName, \"{fae04ec1-301f-11d3-bf4b-00c04f79efbc}\", GeneratorRegKeyName = " + Properties.LanguageClassName + "LanguageConfig.GeneratorName, GeneratesDesignTimeSource = true)]");
            using(StreamReader __tmp109Reader = new StreamReader(this.__ToStream(__tmp109.ToString())))
            {
                bool __tmp109_first = true;
                bool __tmp109_last = __tmp109Reader.EndOfStream;
                while(__tmp109_first || !__tmp109_last)
                {
                    __tmp109_first = false;
                    string __tmp109Line = __tmp109Reader.ReadLine();
                    __tmp109_last = __tmp109Reader.EndOfStream;
                    __out.Append(__tmp108Prefix);
                    if (__tmp109Line != null) __out.Append(__tmp109Line);
                    if (!__tmp109_last) __out.AppendLine(true);
                    __out.AppendLine(false); //280:325
                }
            }
            if (Properties.GenerateMultipleFiles) //281:3
            {
                string __tmp111Line = "    public class "; //282:1
                if (__tmp111Line != null) __out.Append(__tmp111Line);
                StringBuilder __tmp112 = new StringBuilder();
                __tmp112.Append(Properties.LanguageClassName);
                using(StreamReader __tmp112Reader = new StreamReader(this.__ToStream(__tmp112.ToString())))
                {
                    bool __tmp112_first = true;
                    bool __tmp112_last = __tmp112Reader.EndOfStream;
                    while(__tmp112_first || !__tmp112_last)
                    {
                        __tmp112_first = false;
                        string __tmp112Line = __tmp112Reader.ReadLine();
                        __tmp112_last = __tmp112Reader.EndOfStream;
                        if (__tmp112Line != null) __out.Append(__tmp112Line);
                        if (!__tmp112_last) __out.AppendLine(true);
                    }
                }
                string __tmp113Line = "GeneratorService : VsMultipleFileGenerator<object>"; //282:48
                if (__tmp113Line != null) __out.Append(__tmp113Line);
                __out.AppendLine(false); //282:98
                __out.Append("    {"); //283:1
                __out.AppendLine(false); //283:6
                __out.Append("        protected override MultipleFileGenerator<object> CreateGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)"); //284:1
                __out.AppendLine(false); //284:146
                __out.Append("		{"); //285:1
                __out.AppendLine(false); //285:4
                string __tmp115Line = "            // If there is a compile error in the following line, create a class "; //286:1
                if (__tmp115Line != null) __out.Append(__tmp115Line);
                StringBuilder __tmp116 = new StringBuilder();
                __tmp116.Append(Properties.LanguageClassName);
                using(StreamReader __tmp116Reader = new StreamReader(this.__ToStream(__tmp116.ToString())))
                {
                    bool __tmp116_first = true;
                    bool __tmp116_last = __tmp116Reader.EndOfStream;
                    while(__tmp116_first || !__tmp116_last)
                    {
                        __tmp116_first = false;
                        string __tmp116Line = __tmp116Reader.ReadLine();
                        __tmp116_last = __tmp116Reader.EndOfStream;
                        if (__tmp116Line != null) __out.Append(__tmp116Line);
                        if (!__tmp116_last) __out.AppendLine(true);
                    }
                }
                string __tmp117Line = "Generator"; //286:112
                if (__tmp117Line != null) __out.Append(__tmp117Line);
                __out.AppendLine(false); //286:121
                __out.Append("            // which is a subclass of MultipleFileGenerator<object>"); //287:1
                __out.AppendLine(false); //287:68
                string __tmp119Line = "			return new "; //288:1
                if (__tmp119Line != null) __out.Append(__tmp119Line);
                StringBuilder __tmp120 = new StringBuilder();
                __tmp120.Append(Properties.LanguageClassName);
                using(StreamReader __tmp120Reader = new StreamReader(this.__ToStream(__tmp120.ToString())))
                {
                    bool __tmp120_first = true;
                    bool __tmp120_last = __tmp120Reader.EndOfStream;
                    while(__tmp120_first || !__tmp120_last)
                    {
                        __tmp120_first = false;
                        string __tmp120Line = __tmp120Reader.ReadLine();
                        __tmp120_last = __tmp120Reader.EndOfStream;
                        if (__tmp120Line != null) __out.Append(__tmp120Line);
                        if (!__tmp120_last) __out.AppendLine(true);
                    }
                }
                string __tmp121Line = "Generator(inputFilePath, inputFileContents, defaultNamespace);"; //288:45
                if (__tmp121Line != null) __out.Append(__tmp121Line);
                __out.AppendLine(false); //288:107
                __out.Append("		}"); //289:1
                __out.AppendLine(false); //289:4
                __out.AppendLine(true); //290:1
                __out.Append("        public override string GetDefaultFileExtension()"); //291:1
                __out.AppendLine(false); //291:57
                __out.Append("        {"); //292:1
                __out.AppendLine(false); //292:10
                string __tmp123Line = "            return "; //293:1
                if (__tmp123Line != null) __out.Append(__tmp123Line);
                StringBuilder __tmp124 = new StringBuilder();
                __tmp124.Append(Properties.LanguageClassName);
                using(StreamReader __tmp124Reader = new StreamReader(this.__ToStream(__tmp124.ToString())))
                {
                    bool __tmp124_first = true;
                    bool __tmp124_last = __tmp124Reader.EndOfStream;
                    while(__tmp124_first || !__tmp124_last)
                    {
                        __tmp124_first = false;
                        string __tmp124Line = __tmp124Reader.ReadLine();
                        __tmp124_last = __tmp124Reader.EndOfStream;
                        if (__tmp124Line != null) __out.Append(__tmp124Line);
                        if (!__tmp124_last) __out.AppendLine(true);
                    }
                }
                string __tmp125Line = "Generator.DefaultExtension;"; //293:50
                if (__tmp125Line != null) __out.Append(__tmp125Line);
                __out.AppendLine(false); //293:77
                __out.Append("        }"); //294:1
                __out.AppendLine(false); //294:10
                __out.Append("    }"); //295:1
                __out.AppendLine(false); //295:6
            }
            else //296:3
            {
                string __tmp127Line = "    public class "; //297:1
                if (__tmp127Line != null) __out.Append(__tmp127Line);
                StringBuilder __tmp128 = new StringBuilder();
                __tmp128.Append(Properties.LanguageClassName);
                using(StreamReader __tmp128Reader = new StreamReader(this.__ToStream(__tmp128.ToString())))
                {
                    bool __tmp128_first = true;
                    bool __tmp128_last = __tmp128Reader.EndOfStream;
                    while(__tmp128_first || !__tmp128_last)
                    {
                        __tmp128_first = false;
                        string __tmp128Line = __tmp128Reader.ReadLine();
                        __tmp128_last = __tmp128Reader.EndOfStream;
                        if (__tmp128Line != null) __out.Append(__tmp128Line);
                        if (!__tmp128_last) __out.AppendLine(true);
                    }
                }
                string __tmp129Line = "GeneratorService : VsSingleFileGenerator"; //297:48
                if (__tmp129Line != null) __out.Append(__tmp129Line);
                __out.AppendLine(false); //297:88
                __out.Append("    {"); //298:1
                __out.AppendLine(false); //298:6
                __out.Append("        protected override SingleFileGenerator CreateGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)"); //299:1
                __out.AppendLine(false); //299:136
                __out.Append("		{"); //300:1
                __out.AppendLine(false); //300:4
                string __tmp131Line = "            // If there is a compile error in the following line, create a class "; //301:1
                if (__tmp131Line != null) __out.Append(__tmp131Line);
                StringBuilder __tmp132 = new StringBuilder();
                __tmp132.Append(Properties.LanguageClassName);
                using(StreamReader __tmp132Reader = new StreamReader(this.__ToStream(__tmp132.ToString())))
                {
                    bool __tmp132_first = true;
                    bool __tmp132_last = __tmp132Reader.EndOfStream;
                    while(__tmp132_first || !__tmp132_last)
                    {
                        __tmp132_first = false;
                        string __tmp132Line = __tmp132Reader.ReadLine();
                        __tmp132_last = __tmp132Reader.EndOfStream;
                        if (__tmp132Line != null) __out.Append(__tmp132Line);
                        if (!__tmp132_last) __out.AppendLine(true);
                    }
                }
                string __tmp133Line = "Generator"; //301:112
                if (__tmp133Line != null) __out.Append(__tmp133Line);
                __out.AppendLine(false); //301:121
                __out.Append("            // which is a subclass of SingleFileGenerator"); //302:1
                __out.AppendLine(false); //302:58
                string __tmp135Line = "			return new "; //303:1
                if (__tmp135Line != null) __out.Append(__tmp135Line);
                StringBuilder __tmp136 = new StringBuilder();
                __tmp136.Append(Properties.LanguageClassName);
                using(StreamReader __tmp136Reader = new StreamReader(this.__ToStream(__tmp136.ToString())))
                {
                    bool __tmp136_first = true;
                    bool __tmp136_last = __tmp136Reader.EndOfStream;
                    while(__tmp136_first || !__tmp136_last)
                    {
                        __tmp136_first = false;
                        string __tmp136Line = __tmp136Reader.ReadLine();
                        __tmp136_last = __tmp136Reader.EndOfStream;
                        if (__tmp136Line != null) __out.Append(__tmp136Line);
                        if (!__tmp136_last) __out.AppendLine(true);
                    }
                }
                string __tmp137Line = "Generator(inputFilePath, inputFileContents, defaultNamespace);"; //303:45
                if (__tmp137Line != null) __out.Append(__tmp137Line);
                __out.AppendLine(false); //303:107
                __out.Append("		}"); //304:1
                __out.AppendLine(false); //304:4
                __out.AppendLine(true); //305:1
                __out.Append("        public override string GetDefaultFileExtension()"); //306:1
                __out.AppendLine(false); //306:57
                __out.Append("        {"); //307:1
                __out.AppendLine(false); //307:10
                string __tmp139Line = "            return "; //308:1
                if (__tmp139Line != null) __out.Append(__tmp139Line);
                StringBuilder __tmp140 = new StringBuilder();
                __tmp140.Append(Properties.LanguageClassName);
                using(StreamReader __tmp140Reader = new StreamReader(this.__ToStream(__tmp140.ToString())))
                {
                    bool __tmp140_first = true;
                    bool __tmp140_last = __tmp140Reader.EndOfStream;
                    while(__tmp140_first || !__tmp140_last)
                    {
                        __tmp140_first = false;
                        string __tmp140Line = __tmp140Reader.ReadLine();
                        __tmp140_last = __tmp140Reader.EndOfStream;
                        if (__tmp140Line != null) __out.Append(__tmp140Line);
                        if (!__tmp140_last) __out.AppendLine(true);
                    }
                }
                string __tmp141Line = "Generator.DefaultExtension;"; //308:50
                if (__tmp141Line != null) __out.Append(__tmp141Line);
                __out.AppendLine(false); //308:77
                __out.Append("        }"); //309:1
                __out.AppendLine(false); //309:10
                __out.Append("    }"); //310:1
                __out.AppendLine(false); //310:6
            }
            string __tmp143Line = "    public class "; //314:1
            if (__tmp143Line != null) __out.Append(__tmp143Line);
            StringBuilder __tmp144 = new StringBuilder();
            __tmp144.Append(Properties.LanguageClassName);
            using(StreamReader __tmp144Reader = new StreamReader(this.__ToStream(__tmp144.ToString())))
            {
                bool __tmp144_first = true;
                bool __tmp144_last = __tmp144Reader.EndOfStream;
                while(__tmp144_first || !__tmp144_last)
                {
                    __tmp144_first = false;
                    string __tmp144Line = __tmp144Reader.ReadLine();
                    __tmp144_last = __tmp144Reader.EndOfStream;
                    if (__tmp144Line != null) __out.Append(__tmp144Line);
                    if (!__tmp144_last) __out.AppendLine(true);
                }
            }
            string __tmp145Line = "LanguageScanner : IScanner"; //314:48
            if (__tmp145Line != null) __out.Append(__tmp145Line);
            __out.AppendLine(false); //314:74
            __out.Append("    {"); //315:1
            __out.AppendLine(false); //315:6
            __out.Append("        private int currentOffset;"); //316:1
            __out.AppendLine(false); //316:35
            __out.Append("        private string currentLine;"); //317:1
            __out.AppendLine(false); //317:36
            string __tmp147Line = "        private "; //318:1
            if (__tmp147Line != null) __out.Append(__tmp147Line);
            StringBuilder __tmp148 = new StringBuilder();
            __tmp148.Append(Properties.LanguageFullName);
            using(StreamReader __tmp148Reader = new StreamReader(this.__ToStream(__tmp148.ToString())))
            {
                bool __tmp148_first = true;
                bool __tmp148_last = __tmp148Reader.EndOfStream;
                while(__tmp148_first || !__tmp148_last)
                {
                    __tmp148_first = false;
                    string __tmp148Line = __tmp148Reader.ReadLine();
                    __tmp148_last = __tmp148Reader.EndOfStream;
                    if (__tmp148Line != null) __out.Append(__tmp148Line);
                    if (!__tmp148_last) __out.AppendLine(true);
                }
            }
            string __tmp149Line = "Lexer lexer;"; //318:46
            if (__tmp149Line != null) __out.Append(__tmp149Line);
            __out.AppendLine(false); //318:58
            __out.Append("        private IEnumerable<SyntaxAnnotation> modeAnnotations;"); //319:1
            __out.AppendLine(false); //319:63
            __out.Append("        private IEnumerable<SyntaxAnnotation> syntaxAnnotations;"); //320:1
            __out.AppendLine(false); //320:65
            __out.Append("        private Dictionary<LanguageScannerState, int> inverseStates;"); //321:1
            __out.AppendLine(false); //321:69
            __out.Append("        private Dictionary<int, LanguageScannerState> states;"); //322:1
            __out.AppendLine(false); //322:62
            __out.Append("        private int lastState;"); //323:1
            __out.AppendLine(false); //323:31
            string __tmp151Line = "        public "; //325:1
            if (__tmp151Line != null) __out.Append(__tmp151Line);
            StringBuilder __tmp152 = new StringBuilder();
            __tmp152.Append(Properties.LanguageClassName);
            using(StreamReader __tmp152Reader = new StreamReader(this.__ToStream(__tmp152.ToString())))
            {
                bool __tmp152_first = true;
                bool __tmp152_last = __tmp152Reader.EndOfStream;
                while(__tmp152_first || !__tmp152_last)
                {
                    __tmp152_first = false;
                    string __tmp152Line = __tmp152Reader.ReadLine();
                    __tmp152_last = __tmp152Reader.EndOfStream;
                    if (__tmp152Line != null) __out.Append(__tmp152Line);
                    if (!__tmp152_last) __out.AppendLine(true);
                }
            }
            string __tmp153Line = "LanguageScanner()"; //325:46
            if (__tmp153Line != null) __out.Append(__tmp153Line);
            __out.AppendLine(false); //325:63
            __out.Append("        {"); //326:1
            __out.AppendLine(false); //326:10
            __out.Append("            this.inverseStates = new Dictionary<LanguageScannerState, int>();"); //327:1
            __out.AppendLine(false); //327:78
            __out.Append("            this.states = new Dictionary<int, LanguageScannerState>();"); //328:1
            __out.AppendLine(false); //328:71
            __out.Append("            this.lastState = 0;"); //329:1
            __out.AppendLine(false); //329:32
            string __tmp154Prefix = "            "; //330:1
            StringBuilder __tmp155 = new StringBuilder();
            __tmp155.Append(Properties.LanguageFullName);
            using(StreamReader __tmp155Reader = new StreamReader(this.__ToStream(__tmp155.ToString())))
            {
                bool __tmp155_first = true;
                bool __tmp155_last = __tmp155Reader.EndOfStream;
                while(__tmp155_first || !__tmp155_last)
                {
                    __tmp155_first = false;
                    string __tmp155Line = __tmp155Reader.ReadLine();
                    __tmp155_last = __tmp155Reader.EndOfStream;
                    __out.Append(__tmp154Prefix);
                    if (__tmp155Line != null) __out.Append(__tmp155Line);
                    if (!__tmp155_last) __out.AppendLine(true);
                }
            }
            string __tmp156Line = "LexerAnnotator annotator = new "; //330:42
            if (__tmp156Line != null) __out.Append(__tmp156Line);
            StringBuilder __tmp157 = new StringBuilder();
            __tmp157.Append(Properties.LanguageFullName);
            using(StreamReader __tmp157Reader = new StreamReader(this.__ToStream(__tmp157.ToString())))
            {
                bool __tmp157_first = true;
                bool __tmp157_last = __tmp157Reader.EndOfStream;
                while(__tmp157_first || !__tmp157_last)
                {
                    __tmp157_first = false;
                    string __tmp157Line = __tmp157Reader.ReadLine();
                    __tmp157_last = __tmp157Reader.EndOfStream;
                    if (__tmp157Line != null) __out.Append(__tmp157Line);
                    if (!__tmp157_last) __out.AppendLine(true);
                }
            }
            string __tmp158Line = "LexerAnnotator();"; //330:102
            if (__tmp158Line != null) __out.Append(__tmp158Line);
            __out.AppendLine(false); //330:119
            __out.Append("            List<SyntaxAnnotation> mal = new List<SyntaxAnnotation>();"); //331:1
            __out.AppendLine(false); //331:71
            __out.Append("            foreach (var annotList in annotator.ModeAnnotations.Values)"); //332:1
            __out.AppendLine(false); //332:72
            __out.Append("            {"); //333:1
            __out.AppendLine(false); //333:14
            __out.Append("                foreach (var annot in annotList)"); //334:1
            __out.AppendLine(false); //334:49
            __out.Append("                {"); //335:1
            __out.AppendLine(false); //335:18
            __out.Append("                    if (annot is SyntaxAnnotation)"); //336:1
            __out.AppendLine(false); //336:51
            __out.Append("                    {"); //337:1
            __out.AppendLine(false); //337:22
            __out.Append("                        mal.Add((SyntaxAnnotation)annot);"); //338:1
            __out.AppendLine(false); //338:58
            __out.Append("                    }"); //339:1
            __out.AppendLine(false); //339:22
            __out.Append("                }"); //340:1
            __out.AppendLine(false); //340:18
            __out.Append("            }"); //341:1
            __out.AppendLine(false); //341:14
            __out.Append("            this.modeAnnotations = mal;"); //342:1
            __out.AppendLine(false); //342:40
            __out.Append("            List<SyntaxAnnotation> sal = new List<SyntaxAnnotation>();"); //343:1
            __out.AppendLine(false); //343:71
            __out.Append("            foreach (var annotList in annotator.TokenAnnotations.Values)"); //344:1
            __out.AppendLine(false); //344:73
            __out.Append("            {"); //345:1
            __out.AppendLine(false); //345:14
            __out.Append("                foreach (var annot in annotList)"); //346:1
            __out.AppendLine(false); //346:49
            __out.Append("                {"); //347:1
            __out.AppendLine(false); //347:18
            __out.Append("                    if (annot is SyntaxAnnotation)"); //348:1
            __out.AppendLine(false); //348:51
            __out.Append("                    {"); //349:1
            __out.AppendLine(false); //349:22
            __out.Append("                        sal.Add((SyntaxAnnotation)annot);"); //350:1
            __out.AppendLine(false); //350:58
            __out.Append("                    }"); //351:1
            __out.AppendLine(false); //351:22
            __out.Append("                }"); //352:1
            __out.AppendLine(false); //352:18
            __out.Append("            }"); //353:1
            __out.AppendLine(false); //353:14
            __out.Append("            this.syntaxAnnotations = sal;"); //354:1
            __out.AppendLine(false); //354:42
            __out.Append("        }"); //355:1
            __out.AppendLine(false); //355:10
            string __tmp160Line = "        private void LoadState(int state, "; //357:1
            if (__tmp160Line != null) __out.Append(__tmp160Line);
            StringBuilder __tmp161 = new StringBuilder();
            __tmp161.Append(Properties.LanguageFullName);
            using(StreamReader __tmp161Reader = new StreamReader(this.__ToStream(__tmp161.ToString())))
            {
                bool __tmp161_first = true;
                bool __tmp161_last = __tmp161Reader.EndOfStream;
                while(__tmp161_first || !__tmp161_last)
                {
                    __tmp161_first = false;
                    string __tmp161Line = __tmp161Reader.ReadLine();
                    __tmp161_last = __tmp161Reader.EndOfStream;
                    if (__tmp161Line != null) __out.Append(__tmp161Line);
                    if (!__tmp161_last) __out.AppendLine(true);
                }
            }
            string __tmp162Line = "Lexer lexer)"; //357:72
            if (__tmp162Line != null) __out.Append(__tmp162Line);
            __out.AppendLine(false); //357:84
            __out.Append("        {"); //358:1
            __out.AppendLine(false); //358:10
            __out.Append("            LanguageScannerState value = default(LanguageScannerState);"); //359:1
            __out.AppendLine(false); //359:72
            __out.Append("            this.states.TryGetValue(state, out value);"); //360:1
            __out.AppendLine(false); //360:55
            __out.Append("            value.Restore(lexer);"); //361:1
            __out.AppendLine(false); //361:34
            __out.Append("        }"); //362:1
            __out.AppendLine(false); //362:10
            string __tmp164Line = "        private int SaveState("; //364:1
            if (__tmp164Line != null) __out.Append(__tmp164Line);
            StringBuilder __tmp165 = new StringBuilder();
            __tmp165.Append(Properties.LanguageFullName);
            using(StreamReader __tmp165Reader = new StreamReader(this.__ToStream(__tmp165.ToString())))
            {
                bool __tmp165_first = true;
                bool __tmp165_last = __tmp165Reader.EndOfStream;
                while(__tmp165_first || !__tmp165_last)
                {
                    __tmp165_first = false;
                    string __tmp165Line = __tmp165Reader.ReadLine();
                    __tmp165_last = __tmp165Reader.EndOfStream;
                    if (__tmp165Line != null) __out.Append(__tmp165Line);
                    if (!__tmp165_last) __out.AppendLine(true);
                }
            }
            string __tmp166Line = "Lexer lexer)"; //364:60
            if (__tmp166Line != null) __out.Append(__tmp166Line);
            __out.AppendLine(false); //364:72
            __out.Append("        {"); //365:1
            __out.AppendLine(false); //365:10
            __out.Append("            int result = 0;"); //366:1
            __out.AppendLine(false); //366:28
            __out.Append("            LanguageScannerState state = new LanguageScannerState(lexer);"); //367:1
            __out.AppendLine(false); //367:74
            __out.Append("            if (!this.inverseStates.TryGetValue(state, out result))"); //368:1
            __out.AppendLine(false); //368:68
            __out.Append("            {"); //369:1
            __out.AppendLine(false); //369:14
            __out.Append("                result = ++lastState;"); //370:1
            __out.AppendLine(false); //370:38
            __out.Append("                this.states.Add(result, state);"); //371:1
            __out.AppendLine(false); //371:48
            __out.Append("                this.inverseStates.Add(state, result);"); //372:1
            __out.AppendLine(false); //372:55
            __out.Append("            }"); //373:1
            __out.AppendLine(false); //373:14
            __out.Append("            return result;"); //374:1
            __out.AppendLine(false); //374:27
            __out.Append("        }"); //375:1
            __out.AppendLine(false); //375:10
            __out.Append("        public bool ScanTokenAndProvideInfoAboutIt(TokenInfo tokenInfo, ref int state)"); //377:1
            __out.AppendLine(false); //377:87
            __out.Append("        {"); //378:1
            __out.AppendLine(false); //378:10
            __out.Append("            try"); //379:1
            __out.AppendLine(false); //379:16
            __out.Append("            {"); //380:1
            __out.AppendLine(false); //380:14
            __out.Append("                if (this.lexer == null)"); //381:1
            __out.AppendLine(false); //381:40
            __out.Append("                {"); //382:1
            __out.AppendLine(false); //382:18
            string __tmp168Line = "                    this.lexer = new "; //383:1
            if (__tmp168Line != null) __out.Append(__tmp168Line);
            StringBuilder __tmp169 = new StringBuilder();
            __tmp169.Append(Properties.LanguageFullName);
            using(StreamReader __tmp169Reader = new StreamReader(this.__ToStream(__tmp169.ToString())))
            {
                bool __tmp169_first = true;
                bool __tmp169_last = __tmp169Reader.EndOfStream;
                while(__tmp169_first || !__tmp169_last)
                {
                    __tmp169_first = false;
                    string __tmp169Line = __tmp169Reader.ReadLine();
                    __tmp169_last = __tmp169Reader.EndOfStream;
                    if (__tmp169Line != null) __out.Append(__tmp169Line);
                    if (!__tmp169_last) __out.AppendLine(true);
                }
            }
            string __tmp170Line = "Lexer(new AntlrInputStream(this.currentLine + \""; //383:67
            if (__tmp170Line != null) __out.Append(__tmp170Line);
            string __tmp171Line = "\\"; //383:114
            if (__tmp171Line != null) __out.Append(__tmp171Line);
            string __tmp172Line = "r"; //383:115
            if (__tmp172Line != null) __out.Append(__tmp172Line);
            string __tmp173Line = "\\"; //383:116
            if (__tmp173Line != null) __out.Append(__tmp173Line);
            string __tmp174Line = "n\"));"; //383:117
            if (__tmp174Line != null) __out.Append(__tmp174Line);
            __out.AppendLine(false); //383:122
            __out.Append("                }"); //384:1
            __out.AppendLine(false); //384:18
            __out.Append("                this.LoadState(state, this.lexer);"); //385:1
            __out.AppendLine(false); //385:51
            __out.Append("                IToken token = this.lexer.NextToken();"); //386:1
            __out.AppendLine(false); //386:55
            __out.Append("                int tokenType = -1;"); //387:1
            __out.AppendLine(false); //387:36
            __out.Append("                foreach (var modeAnnot in this.modeAnnotations)"); //389:1
            __out.AppendLine(false); //389:64
            __out.Append("                {"); //390:1
            __out.AppendLine(false); //390:18
            __out.Append("                    if (this.lexer.CurrentMode >= modeAnnot.First && this.lexer.CurrentMode <= modeAnnot.Last)"); //391:1
            __out.AppendLine(false); //391:111
            __out.Append("                    {"); //392:1
            __out.AppendLine(false); //392:22
            __out.Append("                        tokenType = modeAnnot.Kind;"); //393:1
            __out.AppendLine(false); //393:52
            __out.Append("                        break;"); //394:1
            __out.AppendLine(false); //394:31
            __out.Append("                    }"); //395:1
            __out.AppendLine(false); //395:22
            __out.Append("                }"); //396:1
            __out.AppendLine(false); //396:18
            __out.Append("                foreach (var syntaxAnnot in this.syntaxAnnotations)"); //397:1
            __out.AppendLine(false); //397:68
            __out.Append("                {"); //398:1
            __out.AppendLine(false); //398:18
            __out.Append("                    if (token.Type >= syntaxAnnot.First && token.Type <= syntaxAnnot.Last)"); //399:1
            __out.AppendLine(false); //399:91
            __out.Append("                    {"); //400:1
            __out.AppendLine(false); //400:22
            __out.Append("                        tokenType = syntaxAnnot.Kind;"); //401:1
            __out.AppendLine(false); //401:54
            __out.Append("                        break;"); //402:1
            __out.AppendLine(false); //402:31
            __out.Append("                    }"); //403:1
            __out.AppendLine(false); //403:22
            __out.Append("                }"); //404:1
            __out.AppendLine(false); //404:18
            string __tmp176Line = "                if (tokenType >= 1 && tokenType <= "; //406:1
            if (__tmp176Line != null) __out.Append(__tmp176Line);
            StringBuilder __tmp177 = new StringBuilder();
            __tmp177.Append(Properties.LanguageClassName);
            using(StreamReader __tmp177Reader = new StreamReader(this.__ToStream(__tmp177.ToString())))
            {
                bool __tmp177_first = true;
                bool __tmp177_last = __tmp177Reader.EndOfStream;
                while(__tmp177_first || !__tmp177_last)
                {
                    __tmp177_first = false;
                    string __tmp177Line = __tmp177Reader.ReadLine();
                    __tmp177_last = __tmp177Reader.EndOfStream;
                    if (__tmp177Line != null) __out.Append(__tmp177Line);
                    if (!__tmp177_last) __out.AppendLine(true);
                }
            }
            string __tmp178Line = "LanguageConfig.Instance.ColorableItems.Count)"; //406:82
            if (__tmp178Line != null) __out.Append(__tmp178Line);
            __out.AppendLine(false); //406:127
            __out.Append("                {"); //407:1
            __out.AppendLine(false); //407:18
            string __tmp179Prefix = "                    "; //408:1
            StringBuilder __tmp180 = new StringBuilder();
            __tmp180.Append(Properties.LanguageClassName);
            using(StreamReader __tmp180Reader = new StreamReader(this.__ToStream(__tmp180.ToString())))
            {
                bool __tmp180_first = true;
                bool __tmp180_last = __tmp180Reader.EndOfStream;
                while(__tmp180_first || !__tmp180_last)
                {
                    __tmp180_first = false;
                    string __tmp180Line = __tmp180Reader.ReadLine();
                    __tmp180_last = __tmp180Reader.EndOfStream;
                    __out.Append(__tmp179Prefix);
                    if (__tmp180Line != null) __out.Append(__tmp180Line);
                    if (!__tmp180_last) __out.AppendLine(true);
                }
            }
            string __tmp181Line = "LanguageColorableItem colorItem = "; //408:51
            if (__tmp181Line != null) __out.Append(__tmp181Line);
            StringBuilder __tmp182 = new StringBuilder();
            __tmp182.Append(Properties.LanguageClassName);
            using(StreamReader __tmp182Reader = new StreamReader(this.__ToStream(__tmp182.ToString())))
            {
                bool __tmp182_first = true;
                bool __tmp182_last = __tmp182Reader.EndOfStream;
                while(__tmp182_first || !__tmp182_last)
                {
                    __tmp182_first = false;
                    string __tmp182Line = __tmp182Reader.ReadLine();
                    __tmp182_last = __tmp182Reader.EndOfStream;
                    if (__tmp182Line != null) __out.Append(__tmp182Line);
                    if (!__tmp182_last) __out.AppendLine(true);
                }
            }
            string __tmp183Line = "LanguageConfig.Instance.ColorableItems"; //408:115
            if (__tmp183Line != null) __out.Append(__tmp183Line);
            StringBuilder __tmp184 = new StringBuilder();
            __tmp184.Append("[tokenType - 1]");
            using(StreamReader __tmp184Reader = new StreamReader(this.__ToStream(__tmp184.ToString())))
            {
                bool __tmp184_first = true;
                bool __tmp184_last = __tmp184Reader.EndOfStream;
                while(__tmp184_first || !__tmp184_last)
                {
                    __tmp184_first = false;
                    string __tmp184Line = __tmp184Reader.ReadLine();
                    __tmp184_last = __tmp184Reader.EndOfStream;
                    if (__tmp184Line != null) __out.Append(__tmp184Line);
                    if (!__tmp184_last) __out.AppendLine(true);
                }
            }
            string __tmp185Line = ";"; //408:172
            if (__tmp185Line != null) __out.Append(__tmp185Line);
            __out.AppendLine(false); //408:173
            __out.Append("                    tokenInfo.Token = token.Type;"); //409:1
            __out.AppendLine(false); //409:50
            __out.Append("                    tokenInfo.Type = colorItem.TokenType;"); //410:1
            __out.AppendLine(false); //410:58
            __out.Append("                    tokenInfo.Color = (TokenColor)tokenType;"); //411:1
            __out.AppendLine(false); //411:61
            __out.Append("                    tokenInfo.Trigger = TokenTriggers.None;"); //412:1
            __out.AppendLine(false); //412:60
            __out.Append("                }"); //413:1
            __out.AppendLine(false); //413:18
            __out.Append("                else"); //414:1
            __out.AppendLine(false); //414:21
            __out.Append("                {"); //415:1
            __out.AppendLine(false); //415:18
            __out.Append("                    tokenInfo.Token = token.Type;"); //416:1
            __out.AppendLine(false); //416:50
            __out.Append("                    tokenInfo.Type = TokenType.Text;"); //417:1
            __out.AppendLine(false); //417:53
            __out.Append("                    tokenInfo.Color = TokenColor.Text;"); //418:1
            __out.AppendLine(false); //418:55
            __out.Append("                    tokenInfo.Trigger = TokenTriggers.None;"); //419:1
            __out.AppendLine(false); //419:60
            __out.Append("                }"); //420:1
            __out.AppendLine(false); //420:18
            __out.Append("                if (string.IsNullOrEmpty(token.Text) || this.currentOffset >= this.currentLine.Length)"); //422:1
            __out.AppendLine(false); //422:103
            __out.Append("                {"); //423:1
            __out.AppendLine(false); //423:18
            __out.Append("                    return false;"); //424:1
            __out.AppendLine(false); //424:34
            __out.Append("                }"); //425:1
            __out.AppendLine(false); //425:18
            __out.Append("                tokenInfo.StartIndex = this.currentOffset;"); //426:1
            __out.AppendLine(false); //426:59
            __out.Append("                this.currentOffset += token.Text.Length;"); //427:1
            __out.AppendLine(false); //427:57
            __out.Append("                tokenInfo.EndIndex = this.currentOffset - 1;"); //428:1
            __out.AppendLine(false); //428:61
            __out.Append("                state = this.SaveState(lexer);"); //429:1
            __out.AppendLine(false); //429:47
            __out.Append("                return true;"); //430:1
            __out.AppendLine(false); //430:29
            __out.Append("            }"); //431:1
            __out.AppendLine(false); //431:14
            __out.Append("            catch (Exception)"); //432:1
            __out.AppendLine(false); //432:30
            __out.Append("            {"); //433:1
            __out.AppendLine(false); //433:14
            __out.Append("                return false;"); //434:1
            __out.AppendLine(false); //434:30
            __out.Append("            }"); //435:1
            __out.AppendLine(false); //435:14
            __out.Append("        }"); //436:1
            __out.AppendLine(false); //436:10
            __out.Append("        public void SetSource(string source, int offset)"); //438:1
            __out.AppendLine(false); //438:57
            __out.Append("        {"); //439:1
            __out.AppendLine(false); //439:10
            __out.Append("            //if (this.currentOffset != offset || this.currentLine != source)"); //440:1
            __out.AppendLine(false); //440:78
            __out.Append("            {"); //441:1
            __out.AppendLine(false); //441:14
            __out.Append("                this.currentOffset = offset;"); //442:1
            __out.AppendLine(false); //442:45
            __out.Append("                this.currentLine = source;"); //443:1
            __out.AppendLine(false); //443:43
            __out.Append("                this.lexer = null;"); //444:1
            __out.AppendLine(false); //444:35
            __out.Append("            }"); //445:1
            __out.AppendLine(false); //445:14
            __out.Append("        }"); //446:1
            __out.AppendLine(false); //446:10
            __out.Append("        internal void ScanLine(ref int state)"); //447:1
            __out.AppendLine(false); //447:46
            __out.Append("        {"); //448:1
            __out.AppendLine(false); //448:10
            __out.Append("            while (this.ScanTokenAndProvideInfoAboutIt(new TokenInfo(), ref state)) ;"); //449:1
            __out.AppendLine(false); //449:86
            __out.Append("        }"); //450:1
            __out.AppendLine(false); //450:10
            __out.Append("        internal struct LanguageScannerState"); //452:1
            __out.AppendLine(false); //452:45
            __out.Append("        {"); //453:1
            __out.AppendLine(false); //453:10
            string __tmp187Line = "            public LanguageScannerState("; //454:1
            if (__tmp187Line != null) __out.Append(__tmp187Line);
            StringBuilder __tmp188 = new StringBuilder();
            __tmp188.Append(Properties.LanguageFullName);
            using(StreamReader __tmp188Reader = new StreamReader(this.__ToStream(__tmp188.ToString())))
            {
                bool __tmp188_first = true;
                bool __tmp188_last = __tmp188Reader.EndOfStream;
                while(__tmp188_first || !__tmp188_last)
                {
                    __tmp188_first = false;
                    string __tmp188Line = __tmp188Reader.ReadLine();
                    __tmp188_last = __tmp188Reader.EndOfStream;
                    if (__tmp188Line != null) __out.Append(__tmp188Line);
                    if (!__tmp188_last) __out.AppendLine(true);
                }
            }
            string __tmp189Line = "Lexer lexer)"; //454:70
            if (__tmp189Line != null) __out.Append(__tmp189Line);
            __out.AppendLine(false); //454:82
            __out.Append("            {"); //455:1
            __out.AppendLine(false); //455:14
            __out.Append("                this._mode = lexer.CurrentMode;"); //456:1
            __out.AppendLine(false); //456:48
            __out.Append("                this._modeStack = lexer.ModeStack.Count > 0 ? new List<int>(lexer.ModeStack) : null;"); //457:1
            __out.AppendLine(false); //457:101
            __out.Append("                this._type = lexer.Type;"); //458:1
            __out.AppendLine(false); //458:41
            __out.Append("                this._channel = lexer.Channel;"); //459:1
            __out.AppendLine(false); //459:47
            __out.Append("                this._state = lexer.State;"); //460:1
            __out.AppendLine(false); //460:43
            __out.Append("            }"); //461:1
            __out.AppendLine(false); //461:14
            __out.Append("            internal int _state;"); //463:1
            __out.AppendLine(false); //463:33
            __out.Append("            internal int _mode;"); //464:1
            __out.AppendLine(false); //464:32
            __out.Append("            internal List<int> _modeStack;"); //465:1
            __out.AppendLine(false); //465:43
            __out.Append("            internal int _type;"); //466:1
            __out.AppendLine(false); //466:32
            __out.Append("            internal int _channel;"); //467:1
            __out.AppendLine(false); //467:35
            string __tmp191Line = "            public void Restore("; //469:1
            if (__tmp191Line != null) __out.Append(__tmp191Line);
            StringBuilder __tmp192 = new StringBuilder();
            __tmp192.Append(Properties.LanguageFullName);
            using(StreamReader __tmp192Reader = new StreamReader(this.__ToStream(__tmp192.ToString())))
            {
                bool __tmp192_first = true;
                bool __tmp192_last = __tmp192Reader.EndOfStream;
                while(__tmp192_first || !__tmp192_last)
                {
                    __tmp192_first = false;
                    string __tmp192Line = __tmp192Reader.ReadLine();
                    __tmp192_last = __tmp192Reader.EndOfStream;
                    if (__tmp192Line != null) __out.Append(__tmp192Line);
                    if (!__tmp192_last) __out.AppendLine(true);
                }
            }
            string __tmp193Line = "Lexer lexer)"; //469:62
            if (__tmp193Line != null) __out.Append(__tmp193Line);
            __out.AppendLine(false); //469:74
            __out.Append("            {"); //470:1
            __out.AppendLine(false); //470:14
            __out.Append("                lexer.CurrentMode = this._mode;"); //471:1
            __out.AppendLine(false); //471:48
            __out.Append("                lexer.ModeStack.Clear();"); //472:1
            __out.AppendLine(false); //472:41
            __out.Append("                if (this._modeStack != null)"); //473:1
            __out.AppendLine(false); //473:45
            __out.Append("                {"); //474:1
            __out.AppendLine(false); //474:18
            __out.Append("                    foreach (var item in this._modeStack)"); //475:1
            __out.AppendLine(false); //475:58
            __out.Append("                    {"); //476:1
            __out.AppendLine(false); //476:22
            __out.Append("                        lexer.ModeStack.Push(item);"); //477:1
            __out.AppendLine(false); //477:52
            __out.Append("                    }"); //478:1
            __out.AppendLine(false); //478:22
            __out.Append("                }"); //479:1
            __out.AppendLine(false); //479:18
            __out.Append("                lexer.Type = this._type;"); //480:1
            __out.AppendLine(false); //480:41
            __out.Append("                lexer.Channel = this._channel;"); //481:1
            __out.AppendLine(false); //481:47
            __out.Append("                lexer.State = this._state;"); //482:1
            __out.AppendLine(false); //482:43
            __out.Append("            }"); //483:1
            __out.AppendLine(false); //483:14
            __out.Append("            public override bool Equals(object obj)"); //485:1
            __out.AppendLine(false); //485:52
            __out.Append("            {"); //486:1
            __out.AppendLine(false); //486:14
            __out.Append("                LanguageScannerState rhs = (LanguageScannerState)obj;"); //487:1
            __out.AppendLine(false); //487:70
            __out.Append("                if (rhs._mode != this._mode) return false;"); //488:1
            __out.AppendLine(false); //488:59
            __out.Append("                if (rhs._type != this._type) return false;"); //489:1
            __out.AppendLine(false); //489:59
            __out.Append("                if (rhs._state != this._state) return false;"); //490:1
            __out.AppendLine(false); //490:61
            __out.Append("                if (rhs._channel != this._channel) return false;"); //491:1
            __out.AppendLine(false); //491:65
            __out.Append("                if (rhs._modeStack == null && this._modeStack != null) return false;"); //492:1
            __out.AppendLine(false); //492:85
            __out.Append("                if (rhs._modeStack != null && this._modeStack == null) return false;"); //493:1
            __out.AppendLine(false); //493:85
            __out.Append("                if (rhs._modeStack != null && this._modeStack != null)"); //494:1
            __out.AppendLine(false); //494:71
            __out.Append("                {"); //495:1
            __out.AppendLine(false); //495:18
            __out.Append("                    if (rhs._modeStack.Count != this._modeStack.Count) return false;"); //496:1
            __out.AppendLine(false); //496:85
            __out.Append("                    for (int i = 0; i < rhs._modeStack.Count; ++i)"); //497:1
            __out.AppendLine(false); //497:67
            __out.Append("                    {"); //498:1
            __out.AppendLine(false); //498:22
            string __tmp195Line = "                        if (rhs._modeStack"; //499:1
            if (__tmp195Line != null) __out.Append(__tmp195Line);
            StringBuilder __tmp196 = new StringBuilder();
            __tmp196.Append("[i]");
            using(StreamReader __tmp196Reader = new StreamReader(this.__ToStream(__tmp196.ToString())))
            {
                bool __tmp196_first = true;
                bool __tmp196_last = __tmp196Reader.EndOfStream;
                while(__tmp196_first || !__tmp196_last)
                {
                    __tmp196_first = false;
                    string __tmp196Line = __tmp196Reader.ReadLine();
                    __tmp196_last = __tmp196Reader.EndOfStream;
                    if (__tmp196Line != null) __out.Append(__tmp196Line);
                    if (!__tmp196_last) __out.AppendLine(true);
                }
            }
            string __tmp197Line = " != this._modeStack"; //499:50
            if (__tmp197Line != null) __out.Append(__tmp197Line);
            StringBuilder __tmp198 = new StringBuilder();
            __tmp198.Append("[i]");
            using(StreamReader __tmp198Reader = new StreamReader(this.__ToStream(__tmp198.ToString())))
            {
                bool __tmp198_first = true;
                bool __tmp198_last = __tmp198Reader.EndOfStream;
                while(__tmp198_first || !__tmp198_last)
                {
                    __tmp198_first = false;
                    string __tmp198Line = __tmp198Reader.ReadLine();
                    __tmp198_last = __tmp198Reader.EndOfStream;
                    if (__tmp198Line != null) __out.Append(__tmp198Line);
                    if (!__tmp198_last) __out.AppendLine(true);
                }
            }
            string __tmp199Line = ") return false;"; //499:76
            if (__tmp199Line != null) __out.Append(__tmp199Line);
            __out.AppendLine(false); //499:91
            __out.Append("                    }"); //500:1
            __out.AppendLine(false); //500:22
            __out.Append("                }"); //501:1
            __out.AppendLine(false); //501:18
            __out.Append("                return true;"); //502:1
            __out.AppendLine(false); //502:29
            __out.Append("            }"); //503:1
            __out.AppendLine(false); //503:14
            __out.Append("            public override int GetHashCode()"); //505:1
            __out.AppendLine(false); //505:46
            __out.Append("            {"); //506:1
            __out.AppendLine(false); //506:14
            __out.Append("                int result = 0;"); //507:1
            __out.AppendLine(false); //507:32
            __out.Append("                result "); //508:1
            __out.Append("^"); //508:24
            __out.Append("= this._mode.GetHashCode();"); //508:25
            __out.AppendLine(false); //508:52
            __out.Append("                result "); //509:1
            __out.Append("^"); //509:24
            __out.Append("= this._type.GetHashCode();"); //509:25
            __out.AppendLine(false); //509:52
            __out.Append("                result "); //510:1
            __out.Append("^"); //510:24
            __out.Append("= this._state.GetHashCode();"); //510:25
            __out.AppendLine(false); //510:53
            __out.Append("                result "); //511:1
            __out.Append("^"); //511:24
            __out.Append("= this._channel.GetHashCode();"); //511:25
            __out.AppendLine(false); //511:55
            __out.Append("                if (this._modeStack != null)"); //512:1
            __out.AppendLine(false); //512:45
            __out.Append("                {"); //513:1
            __out.AppendLine(false); //513:18
            __out.Append("                    result "); //514:1
            __out.Append("^"); //514:28
            __out.Append("= this._modeStack.GetHashCode();"); //514:29
            __out.AppendLine(false); //514:61
            __out.Append("                }"); //515:1
            __out.AppendLine(false); //515:18
            __out.Append("                return result;"); //516:1
            __out.AppendLine(false); //516:31
            __out.Append("            }"); //517:1
            __out.AppendLine(false); //517:14
            __out.Append("        }"); //518:1
            __out.AppendLine(false); //518:10
            __out.Append("    }"); //519:1
            __out.AppendLine(false); //519:6
            string __tmp200Prefix = "    "; //521:1
            StringBuilder __tmp201 = new StringBuilder();
            __tmp201.Append("[ComVisible(true)]");
            using(StreamReader __tmp201Reader = new StreamReader(this.__ToStream(__tmp201.ToString())))
            {
                bool __tmp201_first = true;
                bool __tmp201_last = __tmp201Reader.EndOfStream;
                while(__tmp201_first || !__tmp201_last)
                {
                    __tmp201_first = false;
                    string __tmp201Line = __tmp201Reader.ReadLine();
                    __tmp201_last = __tmp201Reader.EndOfStream;
                    __out.Append(__tmp200Prefix);
                    if (__tmp201Line != null) __out.Append(__tmp201Line);
                    if (!__tmp201_last) __out.AppendLine(true);
                    __out.AppendLine(false); //521:27
                }
            }
            string __tmp202Prefix = "    "; //522:1
            StringBuilder __tmp203 = new StringBuilder();
            __tmp203.Append("[Guid(" + Properties.LanguageClassName + "LanguageConfig." + Properties.LanguageClassName + "LanguageServiceGuid)]");
            using(StreamReader __tmp203Reader = new StreamReader(this.__ToStream(__tmp203.ToString())))
            {
                bool __tmp203_first = true;
                bool __tmp203_last = __tmp203Reader.EndOfStream;
                while(__tmp203_first || !__tmp203_last)
                {
                    __tmp203_first = false;
                    string __tmp203Line = __tmp203Reader.ReadLine();
                    __tmp203_last = __tmp203Reader.EndOfStream;
                    __out.Append(__tmp202Prefix);
                    if (__tmp203Line != null) __out.Append(__tmp203Line);
                    if (!__tmp203_last) __out.AppendLine(true);
                    __out.AppendLine(false); //522:115
                }
            }
            string __tmp205Line = "    public class "; //523:1
            if (__tmp205Line != null) __out.Append(__tmp205Line);
            StringBuilder __tmp206 = new StringBuilder();
            __tmp206.Append(Properties.LanguageClassName);
            using(StreamReader __tmp206Reader = new StreamReader(this.__ToStream(__tmp206.ToString())))
            {
                bool __tmp206_first = true;
                bool __tmp206_last = __tmp206Reader.EndOfStream;
                while(__tmp206_first || !__tmp206_last)
                {
                    __tmp206_first = false;
                    string __tmp206Line = __tmp206Reader.ReadLine();
                    __tmp206_last = __tmp206Reader.EndOfStream;
                    if (__tmp206Line != null) __out.Append(__tmp206Line);
                    if (!__tmp206_last) __out.AppendLine(true);
                }
            }
            string __tmp207Line = "LanguageService : LanguageService"; //523:48
            if (__tmp207Line != null) __out.Append(__tmp207Line);
            __out.AppendLine(false); //523:81
            __out.Append("    {"); //524:1
            __out.AppendLine(false); //524:6
            __out.Append("        private LanguagePreferences preferences;"); //525:1
            __out.AppendLine(false); //525:49
            string __tmp209Line = "        private "; //526:1
            if (__tmp209Line != null) __out.Append(__tmp209Line);
            StringBuilder __tmp210 = new StringBuilder();
            __tmp210.Append(Properties.LanguageClassName);
            using(StreamReader __tmp210Reader = new StreamReader(this.__ToStream(__tmp210.ToString())))
            {
                bool __tmp210_first = true;
                bool __tmp210_last = __tmp210Reader.EndOfStream;
                while(__tmp210_first || !__tmp210_last)
                {
                    __tmp210_first = false;
                    string __tmp210Line = __tmp210Reader.ReadLine();
                    __tmp210_last = __tmp210Reader.EndOfStream;
                    if (__tmp210Line != null) __out.Append(__tmp210Line);
                    if (!__tmp210_last) __out.AppendLine(true);
                }
            }
            string __tmp211Line = "LanguageScanner scanner;"; //526:47
            if (__tmp211Line != null) __out.Append(__tmp211Line);
            __out.AppendLine(false); //526:71
            string __tmp213Line = "        public "; //528:1
            if (__tmp213Line != null) __out.Append(__tmp213Line);
            StringBuilder __tmp214 = new StringBuilder();
            __tmp214.Append(Properties.LanguageClassName);
            using(StreamReader __tmp214Reader = new StreamReader(this.__ToStream(__tmp214.ToString())))
            {
                bool __tmp214_first = true;
                bool __tmp214_last = __tmp214Reader.EndOfStream;
                while(__tmp214_first || !__tmp214_last)
                {
                    __tmp214_first = false;
                    string __tmp214Line = __tmp214Reader.ReadLine();
                    __tmp214_last = __tmp214Reader.EndOfStream;
                    if (__tmp214Line != null) __out.Append(__tmp214Line);
                    if (!__tmp214_last) __out.AppendLine(true);
                }
            }
            string __tmp215Line = "LanguageService()"; //528:46
            if (__tmp215Line != null) __out.Append(__tmp215Line);
            __out.AppendLine(false); //528:63
            __out.Append("        {"); //529:1
            __out.AppendLine(false); //529:10
            __out.Append("			// Creating the config instance"); //530:1
            __out.AppendLine(false); //530:35
            string __tmp216Prefix = "			"; //531:1
            StringBuilder __tmp217 = new StringBuilder();
            __tmp217.Append(Properties.LanguageClassName);
            using(StreamReader __tmp217Reader = new StreamReader(this.__ToStream(__tmp217.ToString())))
            {
                bool __tmp217_first = true;
                bool __tmp217_last = __tmp217Reader.EndOfStream;
                while(__tmp217_first || !__tmp217_last)
                {
                    __tmp217_first = false;
                    string __tmp217Line = __tmp217Reader.ReadLine();
                    __tmp217_last = __tmp217Reader.EndOfStream;
                    __out.Append(__tmp216Prefix);
                    if (__tmp217Line != null) __out.Append(__tmp217Line);
                    if (!__tmp217_last) __out.AppendLine(true);
                }
            }
            string __tmp218Line = "LanguageConfigBase.Instance.ToString();"; //531:34
            if (__tmp218Line != null) __out.Append(__tmp218Line);
            __out.AppendLine(false); //531:73
            __out.Append("        }"); //532:1
            __out.AppendLine(false); //532:10
            __out.Append("        public override string GetFormatFilterList()"); //534:1
            __out.AppendLine(false); //534:53
            __out.Append("        {"); //535:1
            __out.AppendLine(false); //535:10
            string __tmp220Line = "            return "; //536:1
            if (__tmp220Line != null) __out.Append(__tmp220Line);
            StringBuilder __tmp221 = new StringBuilder();
            __tmp221.Append(Properties.LanguageClassName);
            using(StreamReader __tmp221Reader = new StreamReader(this.__ToStream(__tmp221.ToString())))
            {
                bool __tmp221_first = true;
                bool __tmp221_last = __tmp221Reader.EndOfStream;
                while(__tmp221_first || !__tmp221_last)
                {
                    __tmp221_first = false;
                    string __tmp221Line = __tmp221Reader.ReadLine();
                    __tmp221_last = __tmp221Reader.EndOfStream;
                    if (__tmp221Line != null) __out.Append(__tmp221Line);
                    if (!__tmp221_last) __out.AppendLine(true);
                }
            }
            string __tmp222Line = "LanguageConfig.FilterList;"; //536:50
            if (__tmp222Line != null) __out.Append(__tmp222Line);
            __out.AppendLine(false); //536:76
            __out.Append("        }"); //537:1
            __out.AppendLine(false); //537:10
            __out.Append("        public override LanguagePreferences GetLanguagePreferences()"); //539:1
            __out.AppendLine(false); //539:69
            __out.Append("        {"); //540:1
            __out.AppendLine(false); //540:10
            __out.Append("            if (preferences == null)"); //541:1
            __out.AppendLine(false); //541:37
            __out.Append("            {"); //542:1
            __out.AppendLine(false); //542:14
            string __tmp224Line = "                preferences = new LanguagePreferences(this.Site, typeof("; //543:1
            if (__tmp224Line != null) __out.Append(__tmp224Line);
            StringBuilder __tmp225 = new StringBuilder();
            __tmp225.Append(Properties.LanguageClassName);
            using(StreamReader __tmp225Reader = new StreamReader(this.__ToStream(__tmp225.ToString())))
            {
                bool __tmp225_first = true;
                bool __tmp225_last = __tmp225Reader.EndOfStream;
                while(__tmp225_first || !__tmp225_last)
                {
                    __tmp225_first = false;
                    string __tmp225Line = __tmp225Reader.ReadLine();
                    __tmp225_last = __tmp225Reader.EndOfStream;
                    if (__tmp225Line != null) __out.Append(__tmp225Line);
                    if (!__tmp225_last) __out.AppendLine(true);
                }
            }
            string __tmp226Line = "LanguageService).GUID, this.Name);"; //543:103
            if (__tmp226Line != null) __out.Append(__tmp226Line);
            __out.AppendLine(false); //543:137
            __out.Append("                preferences.Init();"); //544:1
            __out.AppendLine(false); //544:36
            __out.Append("            }"); //545:1
            __out.AppendLine(false); //545:14
            __out.Append("            return preferences;"); //546:1
            __out.AppendLine(false); //546:32
            __out.Append("        }"); //547:1
            __out.AppendLine(false); //547:10
            __out.Append("        public override IScanner GetScanner(IVsTextLines buffer)"); //549:1
            __out.AppendLine(false); //549:65
            __out.Append("        {"); //550:1
            __out.AppendLine(false); //550:10
            __out.Append("            if (scanner == null)"); //551:1
            __out.AppendLine(false); //551:33
            __out.Append("            {"); //552:1
            __out.AppendLine(false); //552:14
            string __tmp228Line = "                scanner = new "; //553:1
            if (__tmp228Line != null) __out.Append(__tmp228Line);
            StringBuilder __tmp229 = new StringBuilder();
            __tmp229.Append(Properties.LanguageClassName);
            using(StreamReader __tmp229Reader = new StreamReader(this.__ToStream(__tmp229.ToString())))
            {
                bool __tmp229_first = true;
                bool __tmp229_last = __tmp229Reader.EndOfStream;
                while(__tmp229_first || !__tmp229_last)
                {
                    __tmp229_first = false;
                    string __tmp229Line = __tmp229Reader.ReadLine();
                    __tmp229_last = __tmp229Reader.EndOfStream;
                    if (__tmp229Line != null) __out.Append(__tmp229Line);
                    if (!__tmp229_last) __out.AppendLine(true);
                }
            }
            string __tmp230Line = "LanguageScanner();"; //553:61
            if (__tmp230Line != null) __out.Append(__tmp230Line);
            __out.AppendLine(false); //553:79
            __out.Append("            }"); //554:1
            __out.AppendLine(false); //554:14
            __out.Append("            return scanner;"); //555:1
            __out.AppendLine(false); //555:28
            __out.Append("        }"); //556:1
            __out.AppendLine(false); //556:10
            __out.Append("        public override Microsoft.VisualStudio.Package.Source CreateSource(IVsTextLines buffer)"); //558:1
            __out.AppendLine(false); //558:96
            __out.Append("        {"); //559:1
            __out.AppendLine(false); //559:10
            string __tmp232Line = "            return new "; //560:1
            if (__tmp232Line != null) __out.Append(__tmp232Line);
            StringBuilder __tmp233 = new StringBuilder();
            __tmp233.Append(Properties.LanguageClassName);
            using(StreamReader __tmp233Reader = new StreamReader(this.__ToStream(__tmp233.ToString())))
            {
                bool __tmp233_first = true;
                bool __tmp233_last = __tmp233Reader.EndOfStream;
                while(__tmp233_first || !__tmp233_last)
                {
                    __tmp233_first = false;
                    string __tmp233Line = __tmp233Reader.ReadLine();
                    __tmp233_last = __tmp233Reader.EndOfStream;
                    if (__tmp233Line != null) __out.Append(__tmp233Line);
                    if (!__tmp233_last) __out.AppendLine(true);
                }
            }
            string __tmp234Line = "LanguageSource(this, buffer, this.GetColorizer(buffer));"; //560:54
            if (__tmp234Line != null) __out.Append(__tmp234Line);
            __out.AppendLine(false); //560:110
            __out.Append("        }"); //561:1
            __out.AppendLine(false); //561:10
            __out.Append("        #region Custom Colors"); //563:1
            __out.AppendLine(false); //563:30
            __out.Append("        public override int GetColorableItem(int index, out IVsColorableItem item)"); //564:1
            __out.AppendLine(false); //564:83
            __out.Append("        {"); //565:1
            __out.AppendLine(false); //565:10
            string __tmp236Line = "            if (index >= 1 && index <= "; //566:1
            if (__tmp236Line != null) __out.Append(__tmp236Line);
            StringBuilder __tmp237 = new StringBuilder();
            __tmp237.Append(Properties.LanguageClassName);
            using(StreamReader __tmp237Reader = new StreamReader(this.__ToStream(__tmp237.ToString())))
            {
                bool __tmp237_first = true;
                bool __tmp237_last = __tmp237Reader.EndOfStream;
                while(__tmp237_first || !__tmp237_last)
                {
                    __tmp237_first = false;
                    string __tmp237Line = __tmp237Reader.ReadLine();
                    __tmp237_last = __tmp237Reader.EndOfStream;
                    if (__tmp237Line != null) __out.Append(__tmp237Line);
                    if (!__tmp237_last) __out.AppendLine(true);
                }
            }
            string __tmp238Line = "LanguageConfig.Instance.ColorableItems.Count)"; //566:70
            if (__tmp238Line != null) __out.Append(__tmp238Line);
            __out.AppendLine(false); //566:115
            __out.Append("            {"); //567:1
            __out.AppendLine(false); //567:14
            string __tmp240Line = "                item = "; //568:1
            if (__tmp240Line != null) __out.Append(__tmp240Line);
            StringBuilder __tmp241 = new StringBuilder();
            __tmp241.Append(Properties.LanguageClassName);
            using(StreamReader __tmp241Reader = new StreamReader(this.__ToStream(__tmp241.ToString())))
            {
                bool __tmp241_first = true;
                bool __tmp241_last = __tmp241Reader.EndOfStream;
                while(__tmp241_first || !__tmp241_last)
                {
                    __tmp241_first = false;
                    string __tmp241Line = __tmp241Reader.ReadLine();
                    __tmp241_last = __tmp241Reader.EndOfStream;
                    if (__tmp241Line != null) __out.Append(__tmp241Line);
                    if (!__tmp241_last) __out.AppendLine(true);
                }
            }
            string __tmp242Line = "LanguageConfig.Instance.ColorableItems"; //568:54
            if (__tmp242Line != null) __out.Append(__tmp242Line);
            StringBuilder __tmp243 = new StringBuilder();
            __tmp243.Append("[index - 1]");
            using(StreamReader __tmp243Reader = new StreamReader(this.__ToStream(__tmp243.ToString())))
            {
                bool __tmp243_first = true;
                bool __tmp243_last = __tmp243Reader.EndOfStream;
                while(__tmp243_first || !__tmp243_last)
                {
                    __tmp243_first = false;
                    string __tmp243Line = __tmp243Reader.ReadLine();
                    __tmp243_last = __tmp243Reader.EndOfStream;
                    if (__tmp243Line != null) __out.Append(__tmp243Line);
                    if (!__tmp243_last) __out.AppendLine(true);
                }
            }
            string __tmp244Line = ";"; //568:107
            if (__tmp244Line != null) __out.Append(__tmp244Line);
            __out.AppendLine(false); //568:108
            __out.Append("                return Microsoft.VisualStudio.VSConstants.S_OK;"); //569:1
            __out.AppendLine(false); //569:64
            __out.Append("            }"); //570:1
            __out.AppendLine(false); //570:14
            __out.Append("            else"); //571:1
            __out.AppendLine(false); //571:17
            __out.Append("            {"); //572:1
            __out.AppendLine(false); //572:14
            string __tmp246Line = "                item = "; //573:1
            if (__tmp246Line != null) __out.Append(__tmp246Line);
            StringBuilder __tmp247 = new StringBuilder();
            __tmp247.Append(Properties.LanguageClassName);
            using(StreamReader __tmp247Reader = new StreamReader(this.__ToStream(__tmp247.ToString())))
            {
                bool __tmp247_first = true;
                bool __tmp247_last = __tmp247Reader.EndOfStream;
                while(__tmp247_first || !__tmp247_last)
                {
                    __tmp247_first = false;
                    string __tmp247Line = __tmp247Reader.ReadLine();
                    __tmp247_last = __tmp247Reader.EndOfStream;
                    if (__tmp247Line != null) __out.Append(__tmp247Line);
                    if (!__tmp247_last) __out.AppendLine(true);
                }
            }
            string __tmp248Line = "LanguageConfig.Instance.ColorableItems"; //573:54
            if (__tmp248Line != null) __out.Append(__tmp248Line);
            StringBuilder __tmp249 = new StringBuilder();
            __tmp249.Append("[0]");
            using(StreamReader __tmp249Reader = new StreamReader(this.__ToStream(__tmp249.ToString())))
            {
                bool __tmp249_first = true;
                bool __tmp249_last = __tmp249Reader.EndOfStream;
                while(__tmp249_first || !__tmp249_last)
                {
                    __tmp249_first = false;
                    string __tmp249Line = __tmp249Reader.ReadLine();
                    __tmp249_last = __tmp249Reader.EndOfStream;
                    if (__tmp249Line != null) __out.Append(__tmp249Line);
                    if (!__tmp249_last) __out.AppendLine(true);
                }
            }
            string __tmp250Line = ";"; //573:99
            if (__tmp250Line != null) __out.Append(__tmp250Line);
            __out.AppendLine(false); //573:100
            __out.Append("                return Microsoft.VisualStudio.VSConstants.S_OK;"); //574:1
            __out.AppendLine(false); //574:64
            __out.Append("            }"); //575:1
            __out.AppendLine(false); //575:14
            __out.Append("        }"); //576:1
            __out.AppendLine(false); //576:10
            __out.Append("        public override int GetItemCount(out int count)"); //578:1
            __out.AppendLine(false); //578:56
            __out.Append("        {"); //579:1
            __out.AppendLine(false); //579:10
            string __tmp252Line = "            count = "; //580:1
            if (__tmp252Line != null) __out.Append(__tmp252Line);
            StringBuilder __tmp253 = new StringBuilder();
            __tmp253.Append(Properties.LanguageClassName);
            using(StreamReader __tmp253Reader = new StreamReader(this.__ToStream(__tmp253.ToString())))
            {
                bool __tmp253_first = true;
                bool __tmp253_last = __tmp253Reader.EndOfStream;
                while(__tmp253_first || !__tmp253_last)
                {
                    __tmp253_first = false;
                    string __tmp253Line = __tmp253Reader.ReadLine();
                    __tmp253_last = __tmp253Reader.EndOfStream;
                    if (__tmp253Line != null) __out.Append(__tmp253Line);
                    if (!__tmp253_last) __out.AppendLine(true);
                }
            }
            string __tmp254Line = "LanguageConfig.Instance.ColorableItems.Count;"; //580:51
            if (__tmp254Line != null) __out.Append(__tmp254Line);
            __out.AppendLine(false); //580:96
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //581:1
            __out.AppendLine(false); //581:60
            __out.Append("        }"); //582:1
            __out.AppendLine(false); //582:10
            __out.Append("        #endregion"); //583:1
            __out.AppendLine(false); //583:19
            __out.Append("        public override void OnIdle(bool periodic)"); //585:1
            __out.AppendLine(false); //585:51
            __out.Append("        {"); //586:1
            __out.AppendLine(false); //586:10
            __out.Append("            // from IronPythonLanguage sample"); //587:1
            __out.AppendLine(false); //587:46
            __out.Append("            // this appears to be necessary to get a parse request with ParseReason = Check?"); //588:1
            __out.AppendLine(false); //588:93
            string __tmp255Prefix = "            "; //589:1
            StringBuilder __tmp256 = new StringBuilder();
            __tmp256.Append(Properties.LanguageClassName);
            using(StreamReader __tmp256Reader = new StreamReader(this.__ToStream(__tmp256.ToString())))
            {
                bool __tmp256_first = true;
                bool __tmp256_last = __tmp256Reader.EndOfStream;
                while(__tmp256_first || !__tmp256_last)
                {
                    __tmp256_first = false;
                    string __tmp256Line = __tmp256Reader.ReadLine();
                    __tmp256_last = __tmp256Reader.EndOfStream;
                    __out.Append(__tmp255Prefix);
                    if (__tmp256Line != null) __out.Append(__tmp256Line);
                    if (!__tmp256_last) __out.AppendLine(true);
                }
            }
            string __tmp257Line = "LanguageSource src = ("; //589:43
            if (__tmp257Line != null) __out.Append(__tmp257Line);
            StringBuilder __tmp258 = new StringBuilder();
            __tmp258.Append(Properties.LanguageClassName);
            using(StreamReader __tmp258Reader = new StreamReader(this.__ToStream(__tmp258.ToString())))
            {
                bool __tmp258_first = true;
                bool __tmp258_last = __tmp258Reader.EndOfStream;
                while(__tmp258_first || !__tmp258_last)
                {
                    __tmp258_first = false;
                    string __tmp258Line = __tmp258Reader.ReadLine();
                    __tmp258_last = __tmp258Reader.EndOfStream;
                    if (__tmp258Line != null) __out.Append(__tmp258Line);
                    if (!__tmp258_last) __out.AppendLine(true);
                }
            }
            string __tmp259Line = "LanguageSource)GetSource(this.LastActiveTextView);"; //589:95
            if (__tmp259Line != null) __out.Append(__tmp259Line);
            __out.AppendLine(false); //589:145
            __out.Append("            if (src != null && src.LastParseTime >= Int32.MaxValue >> 12)"); //590:1
            __out.AppendLine(false); //590:74
            __out.Append("            {"); //591:1
            __out.AppendLine(false); //591:14
            __out.Append("                src.LastParseTime = 0;"); //592:1
            __out.AppendLine(false); //592:39
            __out.Append("            }"); //593:1
            __out.AppendLine(false); //593:14
            __out.Append("            base.OnIdle(periodic);"); //594:1
            __out.AppendLine(false); //594:35
            __out.Append("        }"); //595:1
            __out.AppendLine(false); //595:10
            __out.Append("        public override string Name"); //597:1
            __out.AppendLine(false); //597:36
            __out.Append("        {"); //598:1
            __out.AppendLine(false); //598:10
            string __tmp261Line = "            get { return "; //599:1
            if (__tmp261Line != null) __out.Append(__tmp261Line);
            StringBuilder __tmp262 = new StringBuilder();
            __tmp262.Append(Properties.LanguageClassName);
            using(StreamReader __tmp262Reader = new StreamReader(this.__ToStream(__tmp262.ToString())))
            {
                bool __tmp262_first = true;
                bool __tmp262_last = __tmp262Reader.EndOfStream;
                while(__tmp262_first || !__tmp262_last)
                {
                    __tmp262_first = false;
                    string __tmp262Line = __tmp262Reader.ReadLine();
                    __tmp262_last = __tmp262Reader.EndOfStream;
                    if (__tmp262Line != null) __out.Append(__tmp262Line);
                    if (!__tmp262_last) __out.AppendLine(true);
                }
            }
            string __tmp263Line = "LanguageConfig.LanguageName; }"; //599:56
            if (__tmp263Line != null) __out.Append(__tmp263Line);
            __out.AppendLine(false); //599:86
            __out.Append("        }"); //600:1
            __out.AppendLine(false); //600:10
            __out.Append("        public override ViewFilter CreateViewFilter(CodeWindowManager mgr, IVsTextView newView)"); //602:1
            __out.AppendLine(false); //602:96
            __out.Append("        {"); //603:1
            __out.AppendLine(false); //603:10
            string __tmp265Line = "            return new "; //604:1
            if (__tmp265Line != null) __out.Append(__tmp265Line);
            StringBuilder __tmp266 = new StringBuilder();
            __tmp266.Append(Properties.LanguageClassName);
            using(StreamReader __tmp266Reader = new StreamReader(this.__ToStream(__tmp266.ToString())))
            {
                bool __tmp266_first = true;
                bool __tmp266_last = __tmp266Reader.EndOfStream;
                while(__tmp266_first || !__tmp266_last)
                {
                    __tmp266_first = false;
                    string __tmp266Line = __tmp266Reader.ReadLine();
                    __tmp266_last = __tmp266Reader.EndOfStream;
                    if (__tmp266Line != null) __out.Append(__tmp266Line);
                    if (!__tmp266_last) __out.AppendLine(true);
                }
            }
            string __tmp267Line = "LanguageViewFilter(mgr, newView);"; //604:54
            if (__tmp267Line != null) __out.Append(__tmp267Line);
            __out.AppendLine(false); //604:87
            __out.Append("        }"); //605:1
            __out.AppendLine(false); //605:10
            __out.Append("        public override Colorizer GetColorizer(IVsTextLines buffer)"); //607:1
            __out.AppendLine(false); //607:68
            __out.Append("        {"); //608:1
            __out.AppendLine(false); //608:10
            string __tmp269Line = "            return new "; //609:1
            if (__tmp269Line != null) __out.Append(__tmp269Line);
            StringBuilder __tmp270 = new StringBuilder();
            __tmp270.Append(Properties.LanguageClassName);
            using(StreamReader __tmp270Reader = new StreamReader(this.__ToStream(__tmp270.ToString())))
            {
                bool __tmp270_first = true;
                bool __tmp270_last = __tmp270Reader.EndOfStream;
                while(__tmp270_first || !__tmp270_last)
                {
                    __tmp270_first = false;
                    string __tmp270Line = __tmp270Reader.ReadLine();
                    __tmp270_last = __tmp270Reader.EndOfStream;
                    if (__tmp270Line != null) __out.Append(__tmp270Line);
                    if (!__tmp270_last) __out.AppendLine(true);
                }
            }
            string __tmp271Line = "LanguageColorizer(this, buffer, this.GetScanner(buffer));"; //609:54
            if (__tmp271Line != null) __out.Append(__tmp271Line);
            __out.AppendLine(false); //609:111
            __out.Append("        }"); //610:1
            __out.AppendLine(false); //610:10
            __out.Append("        public override AuthoringScope ParseSource(ParseRequest req)"); //612:1
            __out.AppendLine(false); //612:69
            __out.Append("        {"); //613:1
            __out.AppendLine(false); //613:10
            string __tmp272Prefix = "            "; //614:1
            StringBuilder __tmp273 = new StringBuilder();
            __tmp273.Append(Properties.LanguageClassName);
            using(StreamReader __tmp273Reader = new StreamReader(this.__ToStream(__tmp273.ToString())))
            {
                bool __tmp273_first = true;
                bool __tmp273_last = __tmp273Reader.EndOfStream;
                while(__tmp273_first || !__tmp273_last)
                {
                    __tmp273_first = false;
                    string __tmp273Line = __tmp273Reader.ReadLine();
                    __tmp273_last = __tmp273Reader.EndOfStream;
                    __out.Append(__tmp272Prefix);
                    if (__tmp273Line != null) __out.Append(__tmp273Line);
                    if (!__tmp273_last) __out.AppendLine(true);
                }
            }
            string __tmp274Line = "LanguageSource source = ("; //614:43
            if (__tmp274Line != null) __out.Append(__tmp274Line);
            StringBuilder __tmp275 = new StringBuilder();
            __tmp275.Append(Properties.LanguageClassName);
            using(StreamReader __tmp275Reader = new StreamReader(this.__ToStream(__tmp275.ToString())))
            {
                bool __tmp275_first = true;
                bool __tmp275_last = __tmp275Reader.EndOfStream;
                while(__tmp275_first || !__tmp275_last)
                {
                    __tmp275_first = false;
                    string __tmp275Line = __tmp275Reader.ReadLine();
                    __tmp275_last = __tmp275Reader.EndOfStream;
                    if (__tmp275Line != null) __out.Append(__tmp275Line);
                    if (!__tmp275_last) __out.AppendLine(true);
                }
            }
            string __tmp276Line = "LanguageSource)this.GetSource(req.FileName);"; //614:98
            if (__tmp276Line != null) __out.Append(__tmp276Line);
            __out.AppendLine(false); //614:142
            __out.Append("            switch (req.Reason)"); //615:1
            __out.AppendLine(false); //615:32
            __out.Append("            {"); //616:1
            __out.AppendLine(false); //616:14
            __out.Append("                case ParseReason.Check:"); //617:1
            __out.AppendLine(false); //617:40
            __out.Append("                    // This is where you perform your syntax highlighting."); //618:1
            __out.AppendLine(false); //618:75
            __out.Append("                    // Parse entire source as given in req.Text."); //619:1
            __out.AppendLine(false); //619:65
            __out.Append("                    // Store results in the AuthoringScope object."); //620:1
            __out.AppendLine(false); //620:67
            __out.Append("                    string fileName = Path.GetFileName(req.FileName);"); //621:1
            __out.AppendLine(false); //621:70
            __out.Append("                    string outputDir = Path.GetDirectoryName(req.FileName);"); //622:1
            __out.AppendLine(false); //622:76
            string __tmp277Prefix = "                    "; //623:1
            StringBuilder __tmp278 = new StringBuilder();
            __tmp278.Append(Properties.LanguageClassName);
            using(StreamReader __tmp278Reader = new StreamReader(this.__ToStream(__tmp278.ToString())))
            {
                bool __tmp278_first = true;
                bool __tmp278_last = __tmp278Reader.EndOfStream;
                while(__tmp278_first || !__tmp278_last)
                {
                    __tmp278_first = false;
                    string __tmp278Line = __tmp278Reader.ReadLine();
                    __tmp278_last = __tmp278Reader.EndOfStream;
                    __out.Append(__tmp277Prefix);
                    if (__tmp278Line != null) __out.Append(__tmp278Line);
                    if (!__tmp278_last) __out.AppendLine(true);
                }
            }
            string __tmp279Line = "Compiler compiler = new "; //623:51
            if (__tmp279Line != null) __out.Append(__tmp279Line);
            StringBuilder __tmp280 = new StringBuilder();
            __tmp280.Append(Properties.LanguageClassName);
            using(StreamReader __tmp280Reader = new StreamReader(this.__ToStream(__tmp280.ToString())))
            {
                bool __tmp280_first = true;
                bool __tmp280_last = __tmp280Reader.EndOfStream;
                while(__tmp280_first || !__tmp280_last)
                {
                    __tmp280_first = false;
                    string __tmp280Line = __tmp280Reader.ReadLine();
                    __tmp280_last = __tmp280Reader.EndOfStream;
                    if (__tmp280Line != null) __out.Append(__tmp280Line);
                    if (!__tmp280_last) __out.AppendLine(true);
                }
            }
            string __tmp281Line = "Compiler(req.Text, fileName);"; //623:105
            if (__tmp281Line != null) __out.Append(__tmp281Line);
            __out.AppendLine(false); //623:134
            __out.Append("                    compiler.Compile();"); //624:1
            __out.AppendLine(false); //624:40
            __out.Append("                    foreach (var msg in compiler.Diagnostics.GetMessages())"); //625:1
            __out.AppendLine(false); //625:76
            __out.Append("                    {"); //626:1
            __out.AppendLine(false); //626:22
            __out.Append("                        TextSpan span = new TextSpan();"); //627:1
            __out.AppendLine(false); //627:56
            __out.Append("                        span.iStartLine = msg.TextSpan.StartLine - 1;"); //628:1
            __out.AppendLine(false); //628:70
            __out.Append("                        span.iEndLine = msg.TextSpan.EndLine - 1;"); //629:1
            __out.AppendLine(false); //629:66
            __out.Append("                        span.iStartIndex = msg.TextSpan.StartPosition - 1;"); //630:1
            __out.AppendLine(false); //630:75
            __out.Append("                        span.iEndIndex = msg.TextSpan.EndPosition - 1;"); //631:1
            __out.AppendLine(false); //631:71
            __out.Append("                        Severity severity = Severity.Error;"); //632:1
            __out.AppendLine(false); //632:60
            __out.Append("                        switch (msg.Severity)"); //633:1
            __out.AppendLine(false); //633:46
            __out.Append("                        {"); //634:1
            __out.AppendLine(false); //634:26
            __out.Append("                            case MetaDslx.Core.Severity.Error:"); //635:1
            __out.AppendLine(false); //635:63
            __out.Append("                                severity = Severity.Error;"); //636:1
            __out.AppendLine(false); //636:59
            __out.Append("                                break;"); //637:1
            __out.AppendLine(false); //637:39
            __out.Append("                            case MetaDslx.Core.Severity.Warning:"); //638:1
            __out.AppendLine(false); //638:65
            __out.Append("                                severity = Severity.Warning;"); //639:1
            __out.AppendLine(false); //639:61
            __out.Append("                                break;"); //640:1
            __out.AppendLine(false); //640:39
            __out.Append("                            case MetaDslx.Core.Severity.Info:"); //641:1
            __out.AppendLine(false); //641:62
            __out.Append("                                severity = Severity.Hint;"); //642:1
            __out.AppendLine(false); //642:58
            __out.Append("                                break;"); //643:1
            __out.AppendLine(false); //643:39
            __out.Append("                        }"); //644:1
            __out.AppendLine(false); //644:26
            __out.Append("                        req.Sink.AddError(req.FileName, msg.Message, span, severity);"); //645:1
            __out.AppendLine(false); //645:86
            __out.Append("                    }"); //646:1
            __out.AppendLine(false); //646:22
            __out.Append("                    break;"); //647:1
            __out.AppendLine(false); //647:27
            __out.Append("            }"); //648:1
            __out.AppendLine(false); //648:14
            string __tmp283Line = "            return new "; //649:1
            if (__tmp283Line != null) __out.Append(__tmp283Line);
            StringBuilder __tmp284 = new StringBuilder();
            __tmp284.Append(Properties.LanguageClassName);
            using(StreamReader __tmp284Reader = new StreamReader(this.__ToStream(__tmp284.ToString())))
            {
                bool __tmp284_first = true;
                bool __tmp284_last = __tmp284Reader.EndOfStream;
                while(__tmp284_first || !__tmp284_last)
                {
                    __tmp284_first = false;
                    string __tmp284Line = __tmp284Reader.ReadLine();
                    __tmp284_last = __tmp284Reader.EndOfStream;
                    if (__tmp284Line != null) __out.Append(__tmp284Line);
                    if (!__tmp284_last) __out.AppendLine(true);
                }
            }
            string __tmp285Line = "LanguageAuthoringScope();"; //649:54
            if (__tmp285Line != null) __out.Append(__tmp285Line);
            __out.AppendLine(false); //649:79
            __out.Append("        }"); //650:1
            __out.AppendLine(false); //650:10
            __out.Append("    }"); //651:1
            __out.AppendLine(false); //651:6
            string __tmp287Line = "	public class "; //653:1
            if (__tmp287Line != null) __out.Append(__tmp287Line);
            StringBuilder __tmp288 = new StringBuilder();
            __tmp288.Append(Properties.LanguageClassName);
            using(StreamReader __tmp288Reader = new StreamReader(this.__ToStream(__tmp288.ToString())))
            {
                bool __tmp288_first = true;
                bool __tmp288_last = __tmp288Reader.EndOfStream;
                while(__tmp288_first || !__tmp288_last)
                {
                    __tmp288_first = false;
                    string __tmp288Line = __tmp288Reader.ReadLine();
                    __tmp288_last = __tmp288Reader.EndOfStream;
                    if (__tmp288Line != null) __out.Append(__tmp288Line);
                    if (!__tmp288_last) __out.AppendLine(true);
                }
            }
            string __tmp289Line = "LanguageSource : Microsoft.VisualStudio.Package.Source"; //653:45
            if (__tmp289Line != null) __out.Append(__tmp289Line);
            __out.AppendLine(false); //653:99
            __out.Append("    {"); //654:1
            __out.AppendLine(false); //654:6
            string __tmp291Line = "        public "; //655:1
            if (__tmp291Line != null) __out.Append(__tmp291Line);
            StringBuilder __tmp292 = new StringBuilder();
            __tmp292.Append(Properties.LanguageClassName);
            using(StreamReader __tmp292Reader = new StreamReader(this.__ToStream(__tmp292.ToString())))
            {
                bool __tmp292_first = true;
                bool __tmp292_last = __tmp292Reader.EndOfStream;
                while(__tmp292_first || !__tmp292_last)
                {
                    __tmp292_first = false;
                    string __tmp292Line = __tmp292Reader.ReadLine();
                    __tmp292_last = __tmp292Reader.EndOfStream;
                    if (__tmp292Line != null) __out.Append(__tmp292Line);
                    if (!__tmp292_last) __out.AppendLine(true);
                }
            }
            string __tmp293Line = "LanguageSource(LanguageService service, IVsTextLines textLines, Colorizer colorizer)"; //655:46
            if (__tmp293Line != null) __out.Append(__tmp293Line);
            __out.AppendLine(false); //655:130
            __out.Append("            : base(service, textLines, colorizer)"); //656:1
            __out.AppendLine(false); //656:50
            __out.Append("        {"); //657:1
            __out.AppendLine(false); //657:10
            __out.Append("        }"); //659:1
            __out.AppendLine(false); //659:10
            __out.Append("    }"); //660:1
            __out.AppendLine(false); //660:6
            string __tmp295Line = "    public class "; //662:1
            if (__tmp295Line != null) __out.Append(__tmp295Line);
            StringBuilder __tmp296 = new StringBuilder();
            __tmp296.Append(Properties.LanguageClassName);
            using(StreamReader __tmp296Reader = new StreamReader(this.__ToStream(__tmp296.ToString())))
            {
                bool __tmp296_first = true;
                bool __tmp296_last = __tmp296Reader.EndOfStream;
                while(__tmp296_first || !__tmp296_last)
                {
                    __tmp296_first = false;
                    string __tmp296Line = __tmp296Reader.ReadLine();
                    __tmp296_last = __tmp296Reader.EndOfStream;
                    if (__tmp296Line != null) __out.Append(__tmp296Line);
                    if (!__tmp296_last) __out.AppendLine(true);
                }
            }
            string __tmp297Line = "LanguageViewFilter : ViewFilter"; //662:48
            if (__tmp297Line != null) __out.Append(__tmp297Line);
            __out.AppendLine(false); //662:79
            __out.Append("    {"); //663:1
            __out.AppendLine(false); //663:6
            string __tmp299Line = "        public "; //664:1
            if (__tmp299Line != null) __out.Append(__tmp299Line);
            StringBuilder __tmp300 = new StringBuilder();
            __tmp300.Append(Properties.LanguageClassName);
            using(StreamReader __tmp300Reader = new StreamReader(this.__ToStream(__tmp300.ToString())))
            {
                bool __tmp300_first = true;
                bool __tmp300_last = __tmp300Reader.EndOfStream;
                while(__tmp300_first || !__tmp300_last)
                {
                    __tmp300_first = false;
                    string __tmp300Line = __tmp300Reader.ReadLine();
                    __tmp300_last = __tmp300Reader.EndOfStream;
                    if (__tmp300Line != null) __out.Append(__tmp300Line);
                    if (!__tmp300_last) __out.AppendLine(true);
                }
            }
            string __tmp301Line = "LanguageViewFilter(CodeWindowManager mgr, IVsTextView view)"; //664:46
            if (__tmp301Line != null) __out.Append(__tmp301Line);
            __out.AppendLine(false); //664:105
            __out.Append("            : base(mgr, view)"); //665:1
            __out.AppendLine(false); //665:30
            __out.Append("        {"); //666:1
            __out.AppendLine(false); //666:10
            __out.Append("        }"); //668:1
            __out.AppendLine(false); //668:10
            __out.Append("        public override void HandlePostExec(ref Guid guidCmdGroup, uint nCmdId, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut, bool bufferWasChanged)"); //670:1
            __out.AppendLine(false); //670:150
            __out.Append("        {"); //671:1
            __out.AppendLine(false); //671:10
            __out.Append("            if (guidCmdGroup == typeof(VsCommands2K).GUID)"); //672:1
            __out.AppendLine(false); //672:59
            __out.Append("            {"); //673:1
            __out.AppendLine(false); //673:14
            __out.Append("                VsCommands2K cmd = (VsCommands2K)nCmdId;"); //674:1
            __out.AppendLine(false); //674:57
            __out.Append("                switch (cmd)"); //675:1
            __out.AppendLine(false); //675:29
            __out.Append("                {"); //676:1
            __out.AppendLine(false); //676:18
            __out.Append("                    case VsCommands2K.UP:"); //677:1
            __out.AppendLine(false); //677:42
            __out.Append("                    case VsCommands2K.UP_EXT:"); //678:1
            __out.AppendLine(false); //678:46
            __out.Append("                    case VsCommands2K.UP_EXT_COL:"); //679:1
            __out.AppendLine(false); //679:50
            __out.Append("                    case VsCommands2K.DOWN:"); //680:1
            __out.AppendLine(false); //680:44
            __out.Append("                    case VsCommands2K.DOWN_EXT:"); //681:1
            __out.AppendLine(false); //681:48
            __out.Append("                    case VsCommands2K.DOWN_EXT_COL:"); //682:1
            __out.AppendLine(false); //682:52
            __out.Append("                        Source.OnCommand(TextView, cmd, '"); //683:1
            __out.Append("\\"); //683:58
            __out.Append("0');"); //683:59
            __out.AppendLine(false); //683:63
            __out.Append("                        return;"); //684:1
            __out.AppendLine(false); //684:32
            __out.Append("                }"); //685:1
            __out.AppendLine(false); //685:18
            __out.Append("            }"); //686:1
            __out.AppendLine(false); //686:14
            __out.Append("            base.HandlePostExec(ref guidCmdGroup, nCmdId, nCmdexecopt, pvaIn, pvaOut, bufferWasChanged);"); //687:1
            __out.AppendLine(false); //687:105
            __out.Append("        }"); //688:1
            __out.AppendLine(false); //688:10
            __out.Append("    }"); //689:1
            __out.AppendLine(false); //689:6
            __out.Append("}"); //691:1
            __out.AppendLine(false); //691:2
            return __out.ToString();
        }

        private class StringBuilder
        {
            private bool newLine;
            private System.Text.StringBuilder builder = new System.Text.StringBuilder();
            
            public StringBuilder()
            {
                this.newLine = true;
            }
            
            public void Append(string str)
            {
                if (str == null) return;
                if (!string.IsNullOrEmpty(str))
                {
                    this.newLine = false;
                }
                builder.Append(str);
            }
            
            public void Append(object obj)
            {
                if (obj == null) return;
                string text = obj.ToString();
                this.Append(text);
            }
            
            public void AppendLine(bool force = false)
            {
                if (force || !this.newLine)
                {
                    builder.AppendLine();
                    this.newLine = true;
                }
            }
            
            public override string ToString()
            {
                return builder.ToString();
            }
        }
    }
}
